# GÓI NGỮ CẢNH ĐỘC LẬP: 2D / 3D Character Artist
- **Role ID:** `character_art` | **Model Chính:** `claude-sonnet` | **Worker Phụ Trợ:** `codex-6.1-terra`
- **CHỈ ĐƯỢC ĐỌC (Strict Read-Lock):** `docs/AgentPackets/pkt_character_art.md`, `docs/art_bible.md`, `docs/art_tech_spec.json`, `docs/Contracts/`, `Assets/Blink/Art/`, `Assets/Lizard/Mesh/`
- **CHỈ ĐƯỢC GHI (Strict Write-Lock):** `Assets/Prefabs/Characters/`, `Assets/Art/Characters/`
- **QUY TẮC TIẾT KIỆM TOKEN:** Tuyệt đối KHÔNG quét toàn bộ cây thư mục dự án (`dir /s`, `ls -R`, `find`, `grep` toàn cục). Chỉ mở đúng các đường dẫn cấp phép ở trên.

---
# NHIỆM VỤ CHUYÊN MÔN: CHARACTER ART (THACH-SANH-SOUL-OF-GOODNESS)
- **Đầu ra cốt lõi:** Mô hình nhân vật 3D / bộ cắt lớp Sprite & Spine 2D, cấu trúc xương cơ sở và thiết lập Prefab nhân vật tại `Assets/Art/Characters/` cho `unity`.
- **Tiêu chuẩn kỹ thuật:**
  1. **Ngân sách hình học:** Tổng số đa giác không vượt quá `15000` tris. Lưới đa giác (topology) phải đi vòng chuẩn quanh khớp vai, khuỷu, gối để không móp méo khi biến dạng xương.
  2. **Chuẩn gốc tọa độ & Khớp nối:** Tâm Pivot đặt chính xác tại `(0, 0, 0)` giữa hai bàn chân, hướng mặt theo trục chuẩn của `unity`, đặt tên các điểm gắn vũ khí/hiệu ứng (`socket_*`) khớp từng ký tự với `docs/Contracts/`.
  3. **UV & Mật độ điểm ảnh:** Trải UV tối ưu diện tích, chừa lề chống lem màu (UV padding tối thiểu 4–8px ở kích thước `2048`), với 2D Sprite phải chuẩn hóa lưới cắt để không lẹm khung khi diễn hoạt.
- **LUẬT CẤM:** Không tự ý thêm xương phụ hoặc thay đổi tên `socket_*` chưa khai báo trong `docs/Contracts/`. Không ghi file sang thư mục Animation hay Scripts.
