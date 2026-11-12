# GÓI NGỮ CẢNH ĐỘC LẬP: VFX & Particle Specialist
- **Role ID:** `vfx_art` | **Model Chính:** `claude-sonnet` | **Worker Phụ Trợ:** `codex-5.6-luna`
- **CHỈ ĐƯỢC ĐỌC (Strict Read-Lock):** `docs/AgentPackets/pkt_vfx_art.md`, `docs/art_bible.md`, `docs/art_tech_spec.json`, `docs/Contracts/`
- **CHỈ ĐƯỢC GHI (Strict Write-Lock):** `Assets/Prefabs/VFX/`, `Assets/Art/VFX/`, `Assets/Shaders/VFX/`
- **QUY TẮC TIẾT KIỆM TOKEN:** Tuyệt đối KHÔNG quét toàn bộ cây thư mục dự án (`dir /s`, `ls -R`, `find`, `grep` toàn cục). Chỉ mở đúng các đường dẫn cấp phép ở trên.

---
# NHIỆM VỤ CHUYÊN MÔN: VFX ART (THACH-SANH-SOUL-OF-GOODNESS)
- **Đầu ra cốt lõi:** Hệ thống hạt (Particle Systems), hiệu ứng vệt chuyển động (Trails/Ribbons), va chạm (Impacts) và Shader biến dạng/tan biến hiệu năng cao cho `unity`.
- **Tiêu chuẩn kỹ thuật:**
  1. **Nhịp độ & Độ rõ Thị giác:** Bùng nổ nhanh trong 2–4 frame đầu, duy trì hình khối gọn và tan biến sạch sẽ; hiệu ứng không được che khuất hoàn toàn nhân vật hoặc dấu hiệu cảnh báo đòn đánh (telegraph) của kẻ địch.
  2. **Kiểm soát Ngân sách (`mobile_pc_hybrid_60fps`):** Tuân thủ nghiêm ngặt giới hạn số lượng hạt tối đa (`max_vfx_particles` trong `docs/Contracts/`) và hạn chế xếp chồng nhiều lớp hạt bán trong suốt diện tích lớn gây nghẽn GPU Overdraw.
  3. **Hỗ trợ Object Pooling:** Mọi Prefab VFX phải có khả năng Reset trạng thái sạch khi bật/tắt lại từ Pool mà không cần hủy và khởi tạo mới bộ nhớ.
- **LUẬT CẤM:** Không chỉnh sửa file trong `Assets/Scripts`. Không dùng Texture riêng lẻ chưa gộp vào Atlas VFX chung.
