# ART BIBLE — THẠCH SANH: SOUL OF GOODNESS
- **Phụ trách:** `art_director` | **Engine:** Unity 3D (`mobile_pc_hybrid_60fps`) | **Định hướng Mỹ thuật:** *Stylized Semi-Realistic Vietnamese Mythic Action* (Bán tả thực cách điệu đậm chất thần thoại Việt cổ)

---

## 1. BẢNG MÀU CHỦ ĐẠO (60 – 30 – 10 COLOR PALETTE)

Áp dụng quy tắc phân bổ 60% Nền môi trường – 30% Cấu trúc & Nhân vật – 10% Điểm nhấn tương tác/VFX:

| Nhóm Tỷ Lệ | Vai Trò Mỹ Thuật | Tên Màu | Mã Hex | Ứng Dụng Cụ Thể |
| :--- | :--- | :--- | :--- | :--- |
| **60% — Màu Nền Chủ Đạo (Dominant Environment)** | Tạo chiều sâu không gian rừng thiêng, hang động và đền đài cổ kính; không lấn át nhân vật. | **Rêu Rừng Già (Deep Jungle Moss)** | `#2D4A3E` | Tán cây, thảm cỏ trung cảnh, rừng cổ thụ (Nicrom/Santutu). |
| | | **Đá Cổ Thạch (Ancient Basalt)** | `#3A3F47` | Vách núi, nền đá đền đài, lòng hang tối, sườn núi. |
| | | **Sương Lam Chiều (Misty Twilight)** | `#6E8894` | Sương mù chiều sâu (Height/Distance Fog), bầu trời hậu cảnh. |
| **30% — Màu Bổ Trợ Cấu Trúc (Secondary Structure)** | Định hình khối nhân vật, kiến trúc gỗ/đồng Đông Sơn và trang phục truyền thống. | **Gỗ Lim / Đất Nung (Warm Terracotta)** | `#8C4A27` | Thân gỗ, khố/giáp da của Thạch Sanh (Blink), cột đền đài. |
| | | **Đồng Cổ Đông Sơn (Aged Bronze)** | `#B8863B` | Lưỡi Rìu Thần, họa tiết trống đồng, viền khung UI, giáp trụ. |
| | | **Vảy Chàm Rừng (Lizard Indigo)** | `#4A6B53` | Màu da/vảy chủ đạo của quái vật bò sát (Lizard) và tay sai. |
| **10% — Màu Nhấn Tương Phản Cao (High-Contrast Accent)** | Thu hút thị giác tức thời vào đòn đánh, kỹ năng, cảnh báo nguy hiểm và thanh trạng thái. | **Hoàng Kim Chính Nghĩa (Goodness Gold)** | `#FFD147` | Vệt chém Rìu Thần, mũi tên Cung Thần, điểm yếu Boss. |
| | | **Ngọc Linh Hồn (Jade Soul Cyan)** | `#3CE8B5` | Sóng âm Đàn Thần, hiệu ứng hồi máu, Niêu Cơm Thần. |
| | | **Huyết Ma Chằn Tinh (Malice Crimson)** | `#E62E3D` | Đòn cảnh báo không thể đỡ của Boss (Telegraph), máu, sát thương Chí mạng. |

---

## 2. NGÔN NGỮ HÌNH KHỐI, TỶ LỆ & PHÂN LỚP ĐỘ SÂU

### 2.1. Ngôn ngữ Hình khối (Shape Language) & Camera
- **Thạch Sanh (Hero):** Khối vuông và chữ V vững chãi (vai rộng, thế đứng đầm), các cạnh giáp và lưỡi Rìu Thần vát bevel rõ (`2–4cm` trong không gian 3D) để bắt sáng Rim Light sắc nét.
- **Quái vật & Boss (Lizard / Chằn Tinh):** Khối tam giác nhọn, gai góc và bất đối xứng, tạo cảm giác hung hãn, nguy hiểm.
- **Khoảng cách Camera thực tế:** Camera góc nhìn thứ 3 (Cinemachine Third-Person) đặt cách nhân vật `4.5m – 6.0m` (khám phá) và kéo ra `6.5m – 8.5m` (khi giao chiến Boss), góc nghiêng xuống `15° – 22°`. Do đó, chi tiết bề mặt phải ưu tiên mảng lớn dễ đọc (Medium/Macro details), lược bỏ chi tiết nhiễu hạt nhỏ (Micro-noise).

### 2.2. Phân lớp Độ sâu (Value & Depth Hierarchy)
- **Tiền cảnh (Gameplay — Nhân vật, Boss, VFX):** Độ bão hòa màu cao nhất (`Saturation 85–100%`), độ tương phản sáng-tối mạnh nhất để tách biệt hoàn toàn khỏi mặt đất.
- **Trung cảnh (Environment — Mặt đất, Cây cối, Đá):** Độ bão hòa trung bình (`Saturation 50–70%`), giá trị sáng (Value) giữ ở mức trung tính (`35–60%`) để làm nền cho các vệt chém VFX.
- **Hậu cảnh (Backdrop — Núi xa, Rừng sâu):** Độ bão hòa thấp (`Saturation 20–40%`), hòa dần vào lớp sương mù `#6E8894` theo khoảng cách.

---

## 3. QUY CHUẨN ĐỒNG BỘ ÁNH SÁNG & VẬT LIỆU GIỮA 4 GÓI 3D HIỆN CÓ

Dự án sử dụng kết hợp các gói tài nguyên có xuất xứ khác nhau (**Blink**, **Lizard**, **Nicrom**, **Santutu**). Để tránh hiện tượng lệch tông ("lẩu thập cẩm" giữa PBR tả thực và Low-poly/Hand-painted), mọi tài nguyên phải tuân thủ quy chuẩn đồng bộ sau:

### 3.1. Ma trận Chuyển đổi & Đồng bộ Vật liệu (Material Harmonization)

| Gói Tài Nguyên | Đặc Điểm Gốc | Quy Chuẩn Đồng Bộ Hóa (PBR Stylized Unified) | Thông Số Kỹ Thuật Bắt Buộc |
| :--- | :--- | :--- | :--- |
| **Blink** *(Nhân vật, Giáp, Vũ khí)* | PBR bán tả thực, contrast cao, normal map sắc. | Giữ làm **chuẩn gốc cho Nhân vật**. Giảm nhẹ độ nhiễu hạt vải/da để tiệp với môi trường cách điệu. | `Metallic`: `0.0` (Da/Vải) hoặc `0.85` (Rìu/Đồng `#B8863B`).<br>`Smoothness`: Da `0.35`, Vải `0.15–0.25`, Kim loại `0.65–0.75`. |
| **Lizard** *(Quái vật bò sát / Boss)* | PBR tả thực, độ bóng (Specular) ướt cao, chi tiết vảy gắt. | Áp bộ lọc Color Tint xanh chàm `#4A6B53` hoặc nâu đá; giảm bớt kênh Normal ở tần số cao; thêm **Fresnel Rim Light** mỏng để nổi bật trong hang tối. | `Normal Scale`: `0.7 – 0.85` (tránh gắt sáng).<br>`Smoothness`: Khống chế `0.45 – 0.60` (vảy ẩm vừa phải).<br>Bật Emission đỏ `#E62E3D` ở mắt/vết nứt khi Cuồng Nộ. |
| **Nicrom** *(Môi trường thiên nhiên, Đá, Cây)* | Stylized / Palette-based hoặc Hand-painted nhẹ, ít bóng. | Nâng cấp sang Shader môi trường đồng nhất có hỗ trợ **Triplanar / Vertex Color blending** và đổ bóng mềm, tránh bệt màu phẳng lì khi đặt cạnh nhân vật Blink. | `Smoothness`: Đá/Gỗ khóa ở `0.15 – 0.25`; Cỏ/Lá `0.20` kèm Subsurface Scattering giả lập nhẹ màu `#4F7A42`. |
| **Santutu** *(Kiến trúc, Đền đài, Đạo cụ)* | Chi tiết kiến trúc Á Đông/Cổ đại, màu gốc thường tươi hoặc lệch sắc độ. | Cân chỉnh lại Albedo Value về dải `30–70%` (tránh cháy trắng `#FFFFFF` hoặc đen đặc `#000000`); phủ lớp rêu phong `#2D4A3E` ở chân công trình để hòa quyện với địa hình Nicrom. | `Albedo Luminance`: `0.18 – 0.75`.<br>`Occlusion Strength`: `0.6 – 0.8` để tạo khối sâu ở các khe gạch/tượng đá. |

### 3.2. Quy chuẩn Ánh sáng & Hậu kỳ (Lighting & Post-Processing — 60 FPS)
1. **Directional Light (Mặt trời / Ánh trăng):**
   - *Ban ngày / Rừng cổ:* Màu vàng ấm `#FFF1D6`, Cường độ `1.2 – 1.5`, góc chiếu `35° – 50°`, Shadow Strength `0.75` (Soft Shadows).
   - *Hang động / Boss Arena:* Màu xanh lam lạnh `#8CA8BE`, Cường độ `0.6 – 0.8`, kết hợp Point Light đuốc lửa màu cam `#FF7A29` (giới hạn tối đa 4 đèn realtime trong khung hình).
2. **Ánh sáng Môi trường (Ambient / Skybox Gradient):**
   - Sky Color: `#6E8894` | Equator Color: `#3D4E48` | Ground Color: `#222629` (đảm bảo vùng tối dưới bóng cây luôn có sắc xanh-xám dịu, không bị đen kịt).
3. **Post-Processing chuẩn mực:**
   - **Tonemapping:** ACES (giúp các hiệu ứng VFX vàng `#FFD147` và xanh ngọc `#3CE8B5` rực sáng tự nhiên).
   - **Bloom:** Threshold `1.1`, Intensity `0.35`, Scatter `0.6` (chỉ phát sáng ở VFX, lưỡi rìu tụ lực và mắt Boss).
   - **Color Grading:** Contrast `+10`, Saturation `+5`, Lift nhẹ sắc ấm ở Highlights và sắc lạnh ở Shadows.

---

## 4. PHONG CÁCH GIAO DIỆN (UI / UX ART DIRECTION)

- **Chủ đề:** *Hoàng Kim & Đá Cổ Đông Sơn (Ancient Bronze & Basalt Minimalist)* — tối giản diện tích chiếm dụng màn hình (tối đa 12% diện tích màn hình trong lúc chiến đấu) để ưu tiên tầm nhìn hành động.
- **Khung viền & Họa tiết:** Nền khung HUD màu đá đen bán trong suốt (`#1C2026`, Alpha `80%`), viền mảnh `2px` màu Đồng cổ `#B8863B`, điểm xuyết họa tiết hoa văn kỷ hà / chim Lạc cách điệu ở các góc khóa.
- **Hệ thống Thanh Trạng thái (Status Bars):**
  - **Thanh Máu (HP):** Đỏ son `#D9383A` chuyển sắc nhẹ sang `#FF6B6B`, có lớp nền trễ (Delayed damage bar) màu vàng trắng `#FFF3C4` tụt sau `0.4s`.
  - **Thanh Thể Lực (Stamina):** Xanh lục bảo sáng `#4CE08A` (đổi sang cam nhấp nháy khi cạn kiệt).
  - **Thanh Linh Hồn / Nộ Khí (Goodness Soul):** Xanh ngọc `#3CE8B5` chuyển sang Vàng kim `#FFD147` kèm hiệu ứng hạt sáng lấp lánh khi đầy 100% (sẵn sàng kích hoạt Đàn Thần).
  - **Thanh Choáng của Boss (Stagger Bar):** Đặt ngay dưới thanh HP Boss ở đỉnh màn hình, màu vàng đồng `#E5A93C`, phát sáng rực khi đạt 100%.
- **Typography & Iconography:**
  - Font tiêu đề/Số sát thương: Serif có chân góc cạnh, nét khắc đá khỏe khoắn, có viền tối `2px` để đọc rõ trên mọi nền sáng.
  - Font nội dung/thông số: Sans-serif rõ nét, hỗ trợ đầy đủ tiếng Việt có dấu ở kích thước tối thiểu `18px` (trên chuẩn 1080p).
  - Icon kỹ năng (Rìu, Cung, Đàn, Niêu Cơm): Vẽ phẳng cách điệu 2.5D với 2-3 sắc độ đồng-vàng trên nền tối, sáng rực viền `#FFD147` khi hết Cooldown.
