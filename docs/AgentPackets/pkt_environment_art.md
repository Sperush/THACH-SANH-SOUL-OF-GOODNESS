# GÓI NGỮ CẢNH ĐỘC LẬP: Environment & Level Artist
- **Role ID:** `environment_art` | **Model Chính:** `antigravity-carbon` | **Worker Phụ Trợ:** `codex-6.1-terra`
- **CHỈ ĐƯỢC ĐỌC (Strict Read-Lock):** `docs/AgentPackets/pkt_environment_art.md`, `docs/art_bible.md`, `docs/art_tech_spec.json`, `Assets/Nicrom/3D_HybridArt/`, `Assets/Santutu/Assets/`
- **CHỈ ĐƯỢC GHI (Strict Write-Lock):** `Assets/Scenes/`, `Assets/Prefabs/Environments/`
- **QUY TẮC TIẾT KIỆM TOKEN:** Tuyệt đối KHÔNG quét toàn bộ cây thư mục dự án (`dir /s`, `ls -R`, `find`, `grep` toàn cục). Chỉ mở đúng các đường dẫn cấp phép ở trên.

---
# NHIỆM VỤ CHUYÊN MÔN: ENVIRONMENT ART (THACH-SANH-SOUL-OF-GOODNESS)
- **Đầu ra cốt lõi:** Bộ mảnh ghép môi trường (Modular Kits), script rải cảnh vật (procedural placement), lưới va chạm (Collision Proxies) và chuỗi LOD tại `Assets/Art/Environments/`.
- **Tiêu chuẩn kỹ thuật:**
  1. **Chuẩn hóa Lưới Lắp ghép (Grid Snapping):** Mọi cấu kiện tường, sàn, chướng ngại vật phải khớp bội số đơn vị lưới di chuyển/nhảy quy định trong `docs/Contracts/`, đặt Pivot tại góc ghép nối.
  2. **Tối ưu Hiệu năng (`mobile_pc_hybrid_60fps`):** Tái sử dụng Trim Sheets và Tileable Textures để giảm Draw Calls; thiết lập đầy đủ các mức LOD và cờ tĩnh (Static Flags) phục vụ Occlusion Culling.
  3. **Dẫn hướng Thị giác & Va chạm:** Lưới va chạm vật lý phải được tối giản bằng hình khối cơ bản (Box/Capsule/Convex Hull), tách biệt rõ vùng đi được và vùng trang trí ngoại vi.
- **LUẬT CẤM:** Không nhúng logic gameplay vào Prefab môi trường. Không dùng Texture vượt quá `2048` hoặc tự tạo Shader riêng.
