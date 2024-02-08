# TRẠM PHUN KEO - TRẠM 3

## TỔNG QUAN

**Trạm Phun Keo** được xây dựng để thực hiện tác vụ phun keo cho sản phẩm, 1 trong 4 tác vụ quan trọng (khoan lỗ, bắt vít, phun keo, dán nhãn) trong quy trình tự động hoá hệ YASKAWA. **Trạm Phun Keo** là sự phối kết hợp giữa các hệ thống tự động: hệ Servo 3 trục XYZ, hệ Robot 6 trục, PLC và các Servo Drive, Xử lý ảnh sử dụng Camera và Barcode Reader, giao diện giám sát vận hành HMI.
- Phôi di chuyển từ trạm 2 và dừng lại trên băng tải trạm 3 bằng cảm biến. 
- Kích hoạt camera scan vít từ trạm 2:  
 - Nếu lỗi (thiếu vít), cho bang tải chạy tiếp.
 - Nếu không lỗi, trục XYZ đưa phôi từ băng tải đến bàn jig.
 - kích hoạt barcode để nhận biết loại sản phẩm.
 - robot di chuyển tới bàn jig để thực hiện phun keo theo loại sản phẩm.
 - trục xyz đưa phôi trở lại bang tải.

## PHỤ LỤC

- [Robot](#robot)
- [Vision](#vision)
- [Trục XYZ](#truc-xyz)

## ROBOT
Robot 6 bậc tự do GP4 có khâu tác động cuối được trang bị lazer có chức năng thay thế cho tool phun keo.

## VISION
Camera có chức năng chụp và xử lý ảnh, phân biệt loại phôi lỗi hoặc không lỗi để tiếp tục thực hiện các tác vụ tiếp theo.

## TRỤC XYZ
Gồm 3 servo được gắn với 3 trục vitme, theo kèm với các sensors: home, forward travel limit, reverse travel limit; được trang bị tool giác hút cho mục đích gắp thả vật. Chúng được điều khiển bằng 3 driver kết nối với MP4.
