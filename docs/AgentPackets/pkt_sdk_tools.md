# GÓI NGỮ CẢNH ĐỘC LẬP: Tools, Save System & SDK Engineer
- **Role ID:** `sdk_tools` | **Model Chính:** `antigravity-argon` | **Worker Phụ Trợ:** `codex-5.6-luna`
- **CHỈ ĐƯỢC ĐỌC (Strict Read-Lock):** `docs/AgentPackets/pkt_sdk_tools.md`, `docs/Contracts/`, `Assets/Scripts/Core/`
- **CHỈ ĐƯỢC GHI (Strict Write-Lock):** `Assets/Scripts/Services/`, `Assets/Scripts/Editor/`
- **QUY TẮC TIẾT KIỆM TOKEN:** Tuyệt đối KHÔNG quét toàn bộ cây thư mục dự án (`dir /s`, `ls -R`, `find`, `grep` toàn cục). Chỉ mở đúng các đường dẫn cấp phép ở trên.

---
# NHIỆM VỤ CHUYÊN MÔN: SDK, SAVE & TOOLING (THACH-SANH-SOUL-OF-GOODNESS)
- **Đầu ra cốt lõi:** Hệ thống Lưu/Tải dữ liệu an toàn (Save/Load & Cloud Sync), lớp bọc tích hợp IAP/Ads/Analytics, đa ngôn ngữ (Localization) và công cụ tự động hóa Editor tại `Assets/Scripts/Services/` và `Assets/Scripts/EditorTools/`.
- **Tiêu chuẩn kỹ thuật:**
  1. **Chống sập khi mất mạng / thiếu SDK:** Mọi dịch vụ bên thứ ba (Quảng cáo, Thanh toán, Tracking) phải bọc sau Interface có chế độ giả lập (Mock/Fallback Provider) để game luôn chạy mượt trên máy dev ngay cả khi chưa nạp khóa SDK thật.
  2. **Toàn vẹn Dữ liệu Người chơi:** File Save bắt buộc có đánh số phiên bản (`schema_version`), cơ chế ghi nguyên tử (ghi ra file tạm `.tmp` hoàn tất mới đổi tên đè file chính) và kiểm tra mã băm chống hỏng dữ liệu.
- **LUẬT CẤM:** Không gọi trực tiếp hàm SDK quảng cáo/thanh toán rải rác bên trong `Assets/Scripts/Gameplay/`.
