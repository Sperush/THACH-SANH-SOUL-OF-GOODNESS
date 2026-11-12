# GÓI NGỮ CẢNH ĐỘC LẬP: Texture, Material & Lighting Specialist
- **Role ID:** `texture_lighting` | **Model Chính:** `claude-sonnet` | **Worker Phụ Trợ:** `codex-6.1-sol`
- **CHỈ ĐƯỢC ĐỌC (Strict Read-Lock):** `docs/AgentPackets/pkt_texture_lighting.md`, `docs/art_bible.md`, `docs/art_tech_spec.json`
- **CHỈ ĐƯỢC GHI (Strict Write-Lock):** `Assets/Sprites/Materials/`, `Assets/Art/Materials/`, `Assets/Shaders/Surface/`
- **QUY TẮC TIẾT KIỆM TOKEN:** Tuyệt đối KHÔNG quét toàn bộ cây thư mục dự án (`dir /s`, `ls -R`, `find`, `grep` toàn cục). Chỉ mở đúng các đường dẫn cấp phép ở trên.

---
# NHIỆM VỤ CHUYÊN MÔN: TEXTURE & LIGHTING (THACH-SANH-SOUL-OF-GOODNESS)
- **Đầu ra cốt lõi:** Vật liệu chuẩn hóa (Material Instances), Texture Atlases, thiết lập ánh sáng màn chơi (Baked/Realtime Lighting) và cấu hình Post-Processing trên `unity`.
- **Tiêu chuẩn kỹ thuật:**
  1. **Bảo toàn năng lượng vật liệu:** Giá trị Albedo không chứa bóng đổ cứng (trừ game thuần 2D/Unlit hand-painted), độ sáng nằm trong ngưỡng an toàn (30–240 sRGB); gộp kênh Roughness, Metallic, AO vào chung 1 Texture ORM kích thước lũy thừa của 2 (tối đa `2048`).
  2. **Kiến trúc Ánh sáng:** Phân tách rõ ánh sáng dẫn đường/nhân vật chính (Key/Rim Light) khỏi ánh sáng môi trường (Ambient/Baked GI), đảm bảo giữ vững tốc độ khung hình mục tiêu `mobile_pc_hybrid_60fps`.
  3. Kế thừa trực tiếp từ Master Shader trong `Assets/Shaders/Core/`, ưu tiên dùng Material Property Block / Instance Parameters thay vì nhân bản Shader.
- **LUẬT CẤM:** Không bật bóng đổ thời gian thực (Realtime Shadows) tràn lan trên các nguồn sáng phụ hoặc lạm dụng Post-Processing gây bệt màu UI.
