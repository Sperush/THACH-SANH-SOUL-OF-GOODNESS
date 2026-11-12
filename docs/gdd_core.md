# GDD CỐT LÕI — THẠCH SANH: SOUL OF GOODNESS
- **Phụ trách:** `game_director` | **Engine:** Unity 3D (`3d-action-midcore`) | **Mục tiêu hiệu năng:** 60 FPS

---

## 1. VÒNG LẶP CHIẾN ĐẤU 3 TẦNG (3-TIER GAMEPLAY LOOP)

### 1.1. Vòng lặp Vi mô (30 giây — Micro Loop)
- **Thao tác (Action):** Di chuyển định hướng (Lock-on / Free-cam) -> Đọc đòn cảnh báo của địch (Telegraph) -> Né đòn (Dodge/Roll) hoặc Đỡ đòn (Parry) -> Phản công bằng chuỗi Rìu Thần (Light/Heavy Combo).
- **Phản hồi tức thời (Feedback):** Đòn trúng kích hoạt Hit-stop, rung Cinemachine Impulse, lóe VFX tia lửa/hồn khí và SFX va chạm sắc gọn.
- **Phần thưởng thị giác &Tài nguyên (Reward):** Tích điểm **Linh Hồn Thiện Lành (Goodness Soul / Nộ khí)** và làm suy giảm thanh **Choáng (Stagger/Poise)** của mục tiêu.

### 1.2. Vòng lặp Phiên chơi (3–5 phút — Session Loop)
- **Mục tiêu màn chơi:** Vượt qua các điểm nghẽn quái vật (Encounter Zones) tại Rừng Già / Hang Động / Đền Cổ và đánh bại Boss trấn ải.
- **Độ căng thẳng (Tension Curve):**
  - *Phút 1–2:* Giao tranh nhóm quái nhỏ (Lizard/Creeps), tích trữ tài nguyên và làm nóng thao tác.
  - *Phút 3–4:* Chạm trán Tinh Anh hoặc Boss Pha 1; kiểm tra kỹ năng đọc nhịp đòn và quản lý Thể lực (Stamina).
  - *Phút 4–5:* Boss cuồng nộ (Pha 2) với nhịp tấn công dồn dập; kết thúc bằng đòn kết liễu hoặc hóa giải bằng Tiếng Đàn Thần.

### 1.3. Vòng lặp Giữ chân Dài hạn (Macro Loop)
- **Nâng cấp & Mở khóa:** Thu thập Linh Thạch và Tinh Hoa sau mỗi ải để:
  1. Cường hóa sát thương và mở khóa nhánh combo Rìu Thần.
  2. Mở khóa/Nâng cấp kỹ năng **Cung Thần** (tầm xa) và **Đàn Thần** (khống chế/hồi phục).
  3. Mở rộng giới hạn Máu (HP), Thể lực (Stamina) và số lần dùng **Niêu Cơm Thần** (vật phẩm hồi phục tự làm đầy tại điểm nghỉ).

---

## 2. CƠ CHẾ VŨ KHÍ & KỸ NĂNG CỦA THẠCH SANH

| Vũ khí / Kỹ năng | Vai trò Chiến thuật | Hành vi Thực thi & Quy tắc Tương tác | Tiêu hao / Hồi chiêu |
| :--- | :--- | :--- | :--- |
| **Rìu Thần (Cận chiến chủ đạo)** | Sát thương vật lý & Phá giáp/Stagger | - **Light Combo (3 nhịp):** Nhanh, thu hồi đòn ngắn, tích Nộ khí ổn định.<br>- **Heavy Attack (Bổ dọc/Xoay lốc):** Khung hình bất khuất nhẹ (Hyper-armor), gây sát thương Poise lớn, hất văng quái nhỏ. | Heavy tốn 25 Stamina; Light không tốn Stamina. |
| **Cung Thần (Tầm xa linh hoạt)** | Cấu rỉa, bắn điểm yếu & ngắt chiêu | - **Bắn nhanh (Quick Shot):** Tự động hướng về mục tiêu Lock-on.<br>- **Bắn tụ lực (Charged Piercing Arrow):** Giữ nút 0.8s, bắn mũi tên ánh sáng xuyên mục tiêu, gây choáng nếu trúng điểm yếu của Boss (mắt/đầu). | Tiêu hao 20 Stamina/phát tụ lực; Cooldown 6s. |
| **Đàn Thần (Khống chế & Hồi phục)** | Giải vây AoE, làm dịu cuồng nộ Boss | Kích hoạt sóng âm thanh tròn bán kính 8m trong 2.5s: đẩy lùi quái thường, làm chậm 40% tốc độ Boss, xóa trạng thái Cuồng Nộ tạm thời và hồi 15% HP cho Thạch Sanh. | Tiêu hao 100% thanh Linh Hồn (Nộ khí); Cooldown 25s. |
| **Né Đòn / Đỡ Đòn (Dodge / Parry)** | Phòng thủ chủ động | - **Dodge Roll:** 0.25s I-frame hoàn toàn.<br>- **Perfect Parry:** Đỡ đúng 0.15s trước khi đòn chạm -> Phản chấn làm tăng 35% thanh Stagger của địch. | Dodge tốn 15 Stamina; Perfect Parry hoàn lại 10 Stamina. |

---

## 3. CÁC PHA HÀNH VI CỦA BOSS (BOSS BEHAVIOR PHASES)

Áp dụng khung FSM/Behavior Tree chuẩn cho các Boss chính (**Chằn Tinh**, **Đại Bàng Tinh**, **Hồ Tinh**):

| Pha | Ngưỡng Máu (HP) | Quy tắc Hành vi & Nhịp độ | Cơ chế Phản khắc (Counterplay) |
| :--- | :--- | :--- | :--- |
| **Pha 1: Thăm dò (Normal)** | `100% -> 60% HP` | Chuỗi 2 đòn cận chiến cơ bản + 1 đòn quét vùng (Sweep/Slam). Thời gian nghỉ sau chuỗi đòn (Recovery window): `1.5s – 2.0s`. | Né ngang/sau lưng khi Boss vung tay cảnh báo (0.6s telegraph), trả 1 chuỗi Light Combo. |
| **Pha 2: Cuồng Nộ (Enraged)** | `60% -> 25% HP` | Boss gầm lớn (đẩy lùi nhẹ), tốc độ ra đòn tăng 20%. Mở khóa đòn lao nhanh (Dash/Dive) và đòn AoE tầm xa/triệu hồi tay sai (Lizard/Minion). Recovery giảm còn `1.0s`. | Dùng **Cung Thần** bắn điểm yếu khi Boss tụ chiêu hoặc dùng **Đàn Thần** để ngắt trạng thái cường hóa. |
| **Pha 3: Tuyệt Vọng (Desperation)** | `< 25% HP` | Kết hợp chuỗi 3–4 đòn liên hoàn kèm sát thương vùng (Hazard trên mặt đất). Thanh Stagger tự hồi chậm hơn nhưng sát thương Boss tăng 30%. | Tập trung Perfect Parry hoặc Heavy Attack dồn đầy thanh Stagger để kích hoạt trạng thái **Gục Ngã (Groggy 4.0s)** và tung đòn Kết Liễu. |

---

## 4. MA TRẬN PHẢN HỒI (JUICE & FEEDBACK MATRIX)

Mọi thao tác chính bắt buộc kích hoạt đồng bộ 4 kênh phản hồi dưới đây:

| Sự kiện Tương tác | Vật lý & Hit-stop | Camera Cinemachine | Hình ảnh (Anim / VFX) | Âm thanh & UI (SFX / HUD) |
| :--- | :--- | :--- | :--- | :--- |
| **Rìu Thần — Đòn Thường (Light Hit)** | Hit-stop `0.04s` (TimeScale `0.1`); đẩy lùi quái nhỏ `0.3m`. | Impulse Shake nhẹ: Amplitude `0.4`, Frequency `1.5`, Duration `0.08s`. | Slash trail vàng đồng; tia lửa va chạm tại điểm tiếp xúc; Flash trắng địch `0.05s`. | SFX chém sắt + tiếng thịt/giáp; thanh HP địch tụt tức thời kèm lớp trễ (delayed bar) màu trắng. |
| **Rìu Thần — Đòn Nặng / Phá Giáp (Heavy / Stagger Break)** | Hit-stop `0.10s` (TimeScale `0.05`); Knockback mạnh `2.0m` hoặc đánh ngã. | Impulse Shake mạnh: Amplitude `1.8`, Frequency `2.5`, Duration `0.20s`; FOV nhích `-3°` rồi trả về trong `0.25s`. | Vệt chém rực sáng, sóng xung kích bụi đất dưới chân, hiệu ứng vỡ khiên/choáng trên đầu địch. | SFX nổ trầm kim khí + tiếng gầm choáng; số sát thương Chí mạng phóng đại `1.4x` màu cam đỏ. |
| **Cung Thần — Bắn Trúng Điểm Yếu (Weakpoint Hit)** | Hit-stop `0.07s` tại khoảnh khắc mũi tên xuyên mục tiêu; ngắt ngay Animation tụ chiêu của Boss. | Zoom-in nhẹ FOV `-4°` khi kéo cung; giật nhẹ trục Z (`0.8` Amp) khi thả dây. | Vệt tên ánh sáng hoàng kim; vòng nổ hào quang xanh-vàng tại điểm yếu. | SFX dây cung căng + tiếng chuông ngân xuyên thấu; tâm ngắm (Reticle) nháy đỏ-vàng xác nhận Crit. |
| **Đàn Thần — Kích hoạt Sóng Âm (Soul Melody AoE)** | Đẩy lùi toàn bộ địch trong bán kính `4m` đầu tiên; làm chậm chuyển động địch trong vùng. | Camera nâng nhẹ góc nhìn, mở rộng FOV `+5°` trong `2.5s` để bao quát chiến trường. | Sóng âm đồng tâm màu xanh ngọc - vàng kim lan tỏa; hạt linh hồn bay quanh Thạch Sanh. | Nhạc tiếng đàn bầu/đàn tính vang vọng,压 (ducking) âm lượng SFX quái xuống `-6dB`; viền màn hình sáng dịu. |
| **Thạch Sanh Trúng Đòn Nặng (Player Heavy Damaged)** | Hit-stop `0.08s`; nhân vật bị đẩy lùi và vào trạng thái Stagger `0.5s`. | Impulse Shake gắt: Amplitude `2.2`, Duration `0.25s`; lệch trục nghiêng (Dutch Angle `±2°`). | Anim giật lùi; VFX máu/tia tối; Vignette đỏ nháy ở rìa màn hình (`0.3s`). | SFX va đập nặng + tiếng rên nhân vật; thanh HP người chơi rung lắc và nháy đỏ. |

---

## 5. TIÊU CHÍ NGHIỆM THU ĐỊNH LƯỢNG (ACCEPTANCE CRITERIA CHO CONTRACTS)

1. **Độ trễ điều khiển (Input Responsiveness):** Khung hình khởi phát đòn đánh (Startup) của Light Attack $\le 0.15\text{s}$; Dodge Roll nhận lệnh hủy hoạt ảnh (Animation Cancel) trong pha thu hồi đòn (Recovery) dưới `0.05s`.
2. **Điều kiện Thắng/Thua rõ ràng:**
   - **Thắng:** HP Boss về `0` -> Kích hoạt Slow-motion (`TimeScale = 0.2` trong `1.5s`), khóa nhận sát thương, mở cổng qua màn/nhận thưởng.
   - **Thua:** HP Thạch Sanh về `0` -> Phát hoạt ảnh gục ngã, hiện màn hình *Thất Bại / Hồi Sinh tại Điểm Lưu* sau `2.0s`.
3. **Đồng bộ Ma trận Juice:** 100% đòn đánh của Thạch Sanh và Boss phải gọi qua interface phản hồi tập trung (Hit-stop + Cinemachine Impulse + VFX Pool + Audio Cue), đảm bảo khung hình ổn định $\ge 60\text{ FPS}$.
