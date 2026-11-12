# GÓI NGỮ CẢNH ĐỘC LẬP: Core Gameplay & Physics Engineer
- **Role ID:** `core_gameplay` | **Model Chính:** `codex-6.1-terra` | **Worker Phụ Trợ:** `antigravity-carbon`
- **CHỈ ĐƯỢC ĐỌC (Strict Read-Lock):** `docs/AgentPackets/pkt_core_gameplay.md`, `docs/Contracts/`, `Assets/Scripts/Core/`, `Assets/Joystick Pack/Scripts/`
- **CHỈ ĐƯỢC GHI (Strict Write-Lock):** `Assets/Scripts/ThachSanh/`, `Assets/Scripts/Boss/`, `Assets/Scripts/Gameplay/`
- **QUY TẮC TIẾT KIỆM TOKEN:** Tuyệt đối KHÔNG quét toàn bộ cây thư mục dự án (`dir /s`, `ls -R`, `find`, `grep` toàn cục). Chỉ mở đúng các đường dẫn cấp phép ở trên.

---
# NHIỆM VỤ CHUYÊN MÔN: CORE GAMEPLAY (THACH-SANH-SOUL-OF-GOODNESS)
- **Đầu ra cốt lõi:** Logic điều khiển nhân vật, xử lý va chạm/vật lý vi mô, camera hành động, AI đối thủ và vòng lặp luật chơi cốt lõi tại `Assets/Scripts/Gameplay/` trên `unity`.
- **Tiêu chuẩn kỹ thuật:**
  1. **Độ nhạy Điều khiển (Input & Game Feel):** Tích hợp bộ đệm thao tác (Input Buffering 100–150ms), thời gian ân hạn mép vực (Coyote Time), nhịp dừng đòn (Hit-stop) và rung chấn camera có kiểm soát theo thông số cấu hình ngoài.
  2. **Hướng Dữ liệu (Data-Driven):** Cấm gán cứng con số ma thuật (magic numbers) như tốc độ, sát thương, thời gian hồi chiêu vào trong mã nguồn; bắt buộc đọc từ `Assets/Data/Configs/`.
  3. **Tuân thủ Hợp đồng:** Gọi đúng tên hằng số `anim_triggers`, `sockets` và phát đúng sự kiện `ui_bindings` đã quy định trong `docs/Contracts/`.
- **LUẬT CẤM:** Không sửa đổi khung kiến trúc gốc tại `Assets/Scripts/Core/` hoặc can thiệp vào Prefab giao diện trong `Assets/UI/`.
