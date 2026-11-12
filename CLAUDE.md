# QUY CHUẨN ĐIỀU PHỐI ĐA AGENT — THACH-SANH-SOUL-OF-GOODNESS
- **Engine:** `unity` | **Profile:** `3d-action-midcore` | **Chế độ Ngân sách:** `production_flagship`

## LUẬT BẮT BUỘC CHO MỌI AI AGENT (ZERO CONTEXT POLLUTION)
1. Xác định rõ `role_id` được giao trước khi bắt đầu phiên làm việc.
2. **Chỉ đọc duy nhất** file gói ngữ cảnh của mình tại `docs/AgentPackets/pkt_<role_id>.md` và file hợp đồng tính năng được chỉ định trong `docs/Contracts/`.
3. **Cấm quét thư mục ngoài vùng cho phép.** Mọi thao tác ghi file ra ngoài cột `Write-Lock` dưới đây sẽ bị `pre_commit_gate.py` chặn tự động khi commit.

| Role ID | Model Đảm Nhiệm | Gói Ngữ Cảnh Bắt Buộc | Quyền Ghi Độc Quyền (Write-Lock) |
| :--- | :--- | :--- | :--- |
| `game_director` | `claude-opus` | `docs/AgentPackets/pkt_game_director.md` | `docs/gdd_core.md` |
| `art_director` | `claude-opus` | `docs/AgentPackets/pkt_art_director.md` | `docs/art_bible.md` |
| `tech_art` | `codex-6.1-sol` | `docs/AgentPackets/pkt_tech_art.md` | `docs/art_tech_spec.json`, `Assets/Shaders/Core/` |
| `concept_art` | `claude-opus` | `docs/AgentPackets/pkt_concept_art.md` | `Assets/Art/Concepts/` |
| `character_art` | `claude-sonnet` | `docs/AgentPackets/pkt_character_art.md` | `Assets/Prefabs/Characters/`, `Assets/Art/Characters/` |
| `environment_art` | `antigravity-carbon` | `docs/AgentPackets/pkt_environment_art.md` | `Assets/Scenes/`, `Assets/Prefabs/Environments/` |
| `texture_lighting` | `claude-sonnet` | `docs/AgentPackets/pkt_texture_lighting.md` | `Assets/Sprites/Materials/`, `Assets/Art/Materials/`, `Assets/Shaders/Surface/` |
| `animation` | `codex-6.1-terra` | `docs/AgentPackets/pkt_animation.md` | `Assets/Animations/` |
| `vfx_art` | `claude-sonnet` | `docs/AgentPackets/pkt_vfx_art.md` | `Assets/Prefabs/VFX/`, `Assets/Art/VFX/`, `Assets/Shaders/VFX/` |
| `ui_ux_art` | `claude-sonnet` | `docs/AgentPackets/pkt_ui_ux_art.md` | `Assets/Prefabs/UI/`, `Assets/Sprites/` |
| `engine_architect` | `codex-6.1-astra` | `docs/AgentPackets/pkt_engine_architect.md` | `Assets/Scripts/Core/`, `docs/Contracts/` |
| `core_gameplay` | `codex-6.1-terra` | `docs/AgentPackets/pkt_core_gameplay.md` | `Assets/Scripts/ThachSanh/`, `Assets/Scripts/Boss/`, `Assets/Scripts/Gameplay/` |
| `sdk_tools` | `antigravity-argon` | `docs/AgentPackets/pkt_sdk_tools.md` | `Assets/Scripts/Services/`, `Assets/Scripts/Editor/` |
| `audio_tech` | `antigravity-argon` | `docs/AgentPackets/pkt_audio_tech.md` | `Assets/Audio/`, `Assets/Scripts/Audio/` |
| `economy_level` | `codex-6.1-sol` | `docs/AgentPackets/pkt_economy_level.md` | `Assets/Data/Configs/`, `docs/balance_sheets.md` |
| `flash_gatekeeper` | `3.8-flash` | `docs/AgentPackets/pkt_flash_gatekeeper.md` | `docs/QA_Reports/` |
