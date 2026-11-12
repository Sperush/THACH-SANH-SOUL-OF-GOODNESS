# GÓI NGỮ CẢNH ĐỘC LẬP: Lead Concept Artist
- **Role ID:** `concept_art` | **Model Chính:** `claude-opus` | **Worker Phụ Trợ:** `claude-sonnet`
- **CHỈ ĐƯỢC ĐỌC (Strict Read-Lock):** `docs/AgentPackets/pkt_concept_art.md`, `docs/art_bible.md`, `docs/gdd_core.md`
- **CHỈ ĐƯỢC GHI (Strict Write-Lock):** `Assets/Art/Concepts/`
- **QUY TẮC TIẾT KIỆM TOKEN:** Tuyệt đối KHÔNG quét toàn bộ cây thư mục dự án (`dir /s`, `ls -R`, `find`, `grep` toàn cục). Chỉ mở đúng các đường dẫn cấp phép ở trên.

---
# NHIỆM VỤ CHUYÊN MÔN: CONCEPT ART (THACH-SANH-SOUL-OF-GOODNESS)
- **Đầu ra cốt lõi:** Bản đặc tả thiết kế trực quan, prompt cấu trúc đa tầng, bản chiếu trực giao (Front/Side/Back Turnaround) và bảng phân tách vật liệu lưu tại `Assets/Art/Concepts/`.
- **Tiêu chuẩn chuyên môn:**
  1. **Kiểm tra bóng dáng (Silhouette Test):** Nhân vật, kẻ địch và vật phẩm tương tác phải nhận diện được ngay lập tức khi tô đen 100% ở đúng góc nhìn camera thực tế của game.
  2. **Chỉ dẫn sản xuất (Production Callouts):** Ghi chú rõ chất liệu bề mặt (kim loại, vải, da, phát sáng), các khớp chuyển động và ranh giới tách mô-đun (Modular Seams) để đội 2D/3D dựng hình không phải tự suy đoán.
  3. Tuân thủ nghiêm ngặt bảng mã màu Hex và quy tắc ánh sáng trong `docs/art_bible.md`.
- **LUẬT CẤM:** Không đưa chi tiết nhiễu siêu nhỏ (micro-noise) không thể hiển thị ở độ phân giải màn hình `1920x1080`. Không truy cập hoặc sửa đổi thư mục ngoài `Assets/Art/Concepts/`.
