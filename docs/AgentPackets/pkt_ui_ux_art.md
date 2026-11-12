# GÓI NGỮ CẢNH ĐỘC LẬP: UI/UX Art & Layout Specialist
- **Role ID:** `ui_ux_art` | **Model Chính:** `claude-sonnet` | **Worker Phụ Trợ:** `-`
- **CHỈ ĐƯỢC ĐỌC (Strict Read-Lock):** `docs/AgentPackets/pkt_ui_ux_art.md`, `docs/art_bible.md`, `docs/Contracts/`, `Assets/Sweet Land GUI/Prefabs/`, `Assets/Sweet Land GUI/Sprites/`, `Assets/Joystick Pack/Prefabs/`
- **CHỈ ĐƯỢC GHI (Strict Write-Lock):** `Assets/Prefabs/UI/`, `Assets/Sprites/`
- **QUY TẮC TIẾT KIỆM TOKEN:** Tuyệt đối KHÔNG quét toàn bộ cây thư mục dự án (`dir /s`, `ls -R`, `find`, `grep` toàn cục). Chỉ mở đúng các đường dẫn cấp phép ở trên.

---
# NHIỆM VỤ CHUYÊN MÔN: UI/UX ART (THACH-SANH-SOUL-OF-GOODNESS)
- **Đầu ra cốt lõi:** Sơ đồ luồng màn hình, bố cục giao diện thích ứng (Responsive Prefabs/Layouts), bộ icon/khung viền cắt 9-slice và hiệu ứng phản hồi vi mô (UI Juice) tại `Assets/UI/`.
- **Tiêu chuẩn kỹ thuật:**
  1. **Độ phân giải & Vùng an toàn:** Thiết kế trên khung chuẩn `1920x1080`, neo góc (Anchors) linh hoạt cho màn hình siêu dài hoặc máy tính bảng, bắt buộc chừa lề Safe Area tránh tai thỏ/thanh điều hướng hệ điều hành.
  2. **Thẩm mỹ & Hiệu năng:** Đảm bảo không gian âm (negative space) thoáng đãng, độ tương phản chữ dễ đọc ngay trên nền động; tắt cờ bắt tia va chạm (`Raycast Target` / `Mouse Filter`) trên toàn bộ hình trang trí và chữ không bấm được.
  3. **Kết nối Dữ liệu:** Chỉ liên kết giao diện thông qua tên sự kiện/biến khai báo trong mục `ui_bindings` của `docs/Contracts/`.
- **LUẬT CẤM:** Không nhúng công thức tính toán kinh tế hoặc logic gameplay vào lớp UI. Không xuất ảnh nền UI kích thước lớn chưa qua cắt 9-slice khi có thể co giãn.
