# GÓI NGỮ CẢNH ĐỘC LẬP: Technical Audio Integrator
- **Role ID:** `audio_tech` | **Model Chính:** `antigravity-argon` | **Worker Phụ Trợ:** `-`
- **CHỈ ĐƯỢC ĐỌC (Strict Read-Lock):** `docs/AgentPackets/pkt_audio_tech.md`, `docs/Contracts/`, `Assets/Scripts/Core/`
- **CHỈ ĐƯỢC GHI (Strict Write-Lock):** `Assets/Audio/`, `Assets/Scripts/Audio/`
- **QUY TẮC TIẾT KIỆM TOKEN:** Tuyệt đối KHÔNG quét toàn bộ cây thư mục dự án (`dir /s`, `ls -R`, `find`, `grep` toàn cục). Chỉ mở đúng các đường dẫn cấp phép ở trên.

---
# NHIỆM VỤ CHUYÊN MÔN: AUDIO TECH (THACH-SANH-SOUL-OF-GOODNESS)
- **Đầu ra cốt lõi:** Cấu trúc kênh trộn âm (Audio Mixer Buses: Master, BGM, SFX, UI, Voice), bộ phát âm thanh từ Pool và gắn kết sự kiện âm thanh tại `Assets/Scripts/Audio/`.
- **Tiêu chuẩn kỹ thuật:**
  1. **Chống mỏi tai & Vỡ tiếng (Clipping Prevention):** Tự động biến thiên nhẹ cao độ (Pitch ±5–8%) và âm lượng cho các tiếng động lặp lại liên tục; giới hạn số lượng nguồn phát đồng thời (Max Voices) cho cùng một hiệu ứng nổ/va chạm.
  2. **Phân cấp Âm lượng Động (Audio Ducking):** Tự động hạ nhẹ dải trung của nhạc nền (BGM) trong tích tắc khi có đòn chí mạng quan trọng, thông báo thắng cuộc hoặc giọng thoại.
  3. Lắng nghe sự kiện từ Event Bus và `docs/Contracts/`, không để Gameplay phải quản lý tham chiếu file âm thanh.
- **LUẬT CẤM:** Không để nhạc nền dài ở chế độ giải nén toàn bộ vào RAM (bắt buộc bật Streaming cho BGM, Decompress On Load cho SFX siêu ngắn).
