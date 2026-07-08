import usb.core
import usb.util
import yaml
import serial
import serial.tools.list_ports
import sys
import platform

class EspressifUSBManager:
    def __init__(self, vendor_id, product_id):
        self.vendor_id = vendor_id
        self.product_id = product_id
        self.config_file = "espressif_config.yaml"

    def find_serial_port(self):
        """
        Tìm tên cổng serial (/dev/ttyUSBx) dựa trên VID/PID.
        """
        ports = serial.tools.list_ports.comports()
        for port in ports:
            if port.vid == self.vendor_id and port.pid == self.product_id:
                return port.device
        return None

    def export_config(self):
        """
        Trích xuất thông tin phần cứng và cổng serial hiện tại để lưu vào YAML.
        """
        print(f"--- Đang trích xuất cấu hình cho {hex(self.vendor_id)}:{hex(self.product_id)} ---")
        
        # Tìm thông tin qua pyusb (yêu cầu driver libusb trên Windows)
        dev = usb.core.find(idVendor=self.vendor_id, idProduct=self.product_id)
        
        # Tìm tên cổng qua pyserial
        port_name = self.find_serial_port()

        if not dev and not port_name:
            print("Lỗi: Không tìm thấy thiết bị.")
            return False

        config_data = {
            'system_info': {
                'os': platform.system(),
                'node': platform.node()
            },
            'hardware': {
                'vendor_id': hex(self.vendor_id),
                'product_id': hex(self.product_id),
                'manufacturer': usb.util.get_string(dev, dev.iManufacturer) if dev and dev.iManufacturer else "Unknown",
                'product': usb.util.get_string(dev, dev.iProduct) if dev and dev.iProduct else "Unknown",
                'serial_number': usb.util.get_string(dev, dev.iSerialNumber) if dev and dev.iSerialNumber else "None",
            },
            'serial_config': {
                'port': port_name,
                'baudrate': 115200,
                'timeout': 1,
                'bytesize': 8,
                'parity': 'N',
                'stopbits': 1
            }
        }

        try:
            with open(self.config_file, 'w', encoding='utf-8') as f:
                yaml.dump(config_data, f, default_flow_style=False, sort_keys=False)
            print(f"Thành công! Đã lưu cấu hình vào {self.config_file}")
            return True
        except Exception as e:
            print(f"Lỗi khi lưu file YAML: {e}")
            return False

    def load_and_connect(self):
        """
        Đọc file YAML và thiết lập kết nối Serial.
        """
        try:
            with open(self.config_file, 'r', encoding='utf-8') as f:
                config = yaml.safe_load(f)
            
            s_cfg = config['serial_config']
            
            # Kiểm tra xem cổng trong file có còn tồn tại không (đề phòng đổi cổng)
            current_port = self.find_serial_port()
            port_to_use = current_port if current_port else s_cfg['port']

            if not port_to_use:
                print("Lỗi: Không tìm thấy cổng kết nối.")
                return None

            print(f"Đang mở kết nối tới {port_to_use}...")
            ser = serial.Serial(
                port=port_to_use,
                baudrate=s_cfg['baudrate'],
                timeout=s_cfg['timeout'],
                bytesize=s_cfg.get('bytesize', 8),
                parity=s_cfg.get('parity', 'N'),
                stopbits=s_cfg.get('stopbits', 1)
            )
            return ser
        except FileNotFoundError:
            print(f"Lỗi: Không tìm thấy file {self.config_file}. Vui lòng chạy xuất cấu hình trước.")
        except Exception as e:
            print(f"Lỗi khi thiết lập Serial: {e}")
        return None

def main():
    manager = EspressifUSBManager(vendor_id=0x10c4, product_id=0xea60)

    # Bước 1: Xuất cấu hình (Chỉ cần chạy 1 lần hoặc khi thay đổi thiết bị)
    if manager.export_config():
        
        # Bước 2: Load cấu hình và sử dụng để kết nối
        ser = manager.load_and_connect()
        
        if ser and ser.is_open:
            print(f"--- Đã kết nối Serial thành công qua cấu hình YAML ---")
            try:
                # Ví dụ đọc dữ liệu thử
                while True:
                    if ser.in_waiting > 0:
                        data = ser.read(ser.in_waiting).decode('utf-8', errors='ignore')
                        print(data, end='')
            except KeyboardInterrupt:
                print("\nĐang đóng kết nối...")
            finally:
                ser.close()

if __name__ == "__main__":
    main()