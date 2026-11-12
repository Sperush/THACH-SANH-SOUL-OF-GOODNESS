# GÓI NGỮ CẢNH ĐỘC LẬP: Economy Mathematician & Level Designer
- **Role ID:** `economy_level` | **Model Chính:** `codex-6.1-sol` | **Worker Phụ Trợ:** `codex-5.6-luna`
- **CHỈ ĐƯỢC ĐỌC (Strict Read-Lock):** `docs/AgentPackets/pkt_economy_level.md`, `docs/gdd_core.md`, `docs/Contracts/`
- **CHỈ ĐƯỢC GHI (Strict Write-Lock):** `Assets/Data/Configs/`, `docs/balance_sheets.md`
- **QUY TẮC TIẾT KIỆM TOKEN:** Tuyệt đối KHÔNG quét toàn bộ cây thư mục dự án (`dir /s`, `ls -R`, `find`, `grep` toàn cục). Chỉ mở đúng các đường dẫn cấp phép ở trên.

---
# NHIỆM VỤ CHUYÊN MÔN: LEVEL & ECONOMY DESIGN (THACH-SANH-SOUL-OF-GOODNESS)
- **Đầu ra cốt lõi:** Bảng công thức cân bằng toán học `docs/balance_sheets.md` và toàn bộ dữ liệu cấu hình màn chơi/chỉ số (`JSON` / `CSV` / `ScriptableObject` / `Resource`) tại `Assets/Data/Configs/`.
- **Tiêu chuẩn chuyên môn:**
  1. **Đường cong Độ khó Hình Răng Cưa (Sawtooth Pacing):** Xen kẽ các màn tăng thử thách với màn giải tỏa sức mạnh (Power Spike) sau khi người chơi nâng cấp hoặc mở cơ chế mới, tránh tăng độ khó tuyến tính gây nản.
  2. **Kiểm chứng Toán học:** Kiểm soát chặt nguồn thu (Faucets) và nguồn tiêu (Sinks) tài nguyên trong game; viết kèm kiểm tra biên (không để xảy ra chia cho 0, lạm phát cấp số nhân vô hạn hoặc màn chơi không có lời giải hợp lệ).
  3. Xuất dữ liệu tuân thủ 100% cấu trúc trường (schema) mà `core_gameplay` đọc từ `docs/Contracts/`.
- **LUẬT CẤM:** Không sửa mã nguồn thực thi trong `Assets/Scripts` hay giao diện trong `Assets/UI`.
