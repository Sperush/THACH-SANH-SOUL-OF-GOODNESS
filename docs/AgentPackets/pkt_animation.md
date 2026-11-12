# GÓI NGỮ CẢNH ĐỘC LẬP: 2D / 3D Technical Animator
- **Role ID:** `animation` | **Model Chính:** `codex-6.1-terra` | **Worker Phụ Trợ:** `antigravity-argon`
- **CHỈ ĐƯỢC ĐỌC (Strict Read-Lock):** `docs/AgentPackets/pkt_animation.md`, `docs/Contracts/`, `Assets/Blink/Art/`, `Assets/Lizard/Animation/`, `Assets/Lizard/Controller/`
- **CHỈ ĐƯỢC GHI (Strict Write-Lock):** `Assets/Animations/`
- **QUY TẮC TIẾT KIỆM TOKEN:** Tuyệt đối KHÔNG quét toàn bộ cây thư mục dự án (`dir /s`, `ls -R`, `find`, `grep` toàn cục). Chỉ mở đúng các đường dẫn cấp phép ở trên.

---
# NHIỆM VỤ CHUYÊN MÔN: ANIMATION (THACH-SANH-SOUL-OF-GOODNESS)
- **Đầu ra cốt lõi:** Clip diễn hoạt, sơ đồ máy trạng thái (Animator State Machine), Blend Trees, ràng buộc IK/FK và cấu hình sự kiện khung hình tại `Assets/Art/Animations/`.
- **Tiêu chuẩn kỹ thuật:**
  1. **Nhịp điệu Cảm giác Chơi (Game Feel Timing):** Phân tách rõ 3 pha Lấy đà (Anticipation) – Tung đòn/Tác động (Active/Apex) – Thu hồi (Recovery) với đường cong nội suy dứt khoát, cho phép hủy hoạt ảnh (animation cancel) mượt ở pha Recovery.
  2. **Đồng bộ Hợp đồng 1:1:** Mọi tên biến điều khiển (`anim_triggers`) và mốc thời gian phát sự kiện (`anim_events_ms`) phải khớp chính xác tuyệt đối từng chữ và mili-giây với file `docs/Contracts/`.
  3. **Tối ưu Dữ liệu:** Nén đường cong keyframe (Keyframe Reduction) loại bỏ các xương tĩnh không dịch chuyển, quy định rõ dùng In-Place hay Root Motion theo đúng yêu cầu của `docs/Contracts/`.
- **LUẬT CẤM:** Không tự đổi tên xương của Character Art, không viết code xử lý sát thương hay âm thanh trực tiếp bên trong thư mục `Assets/Scripts`.
