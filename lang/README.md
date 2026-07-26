# Nemesis Menu - Language System Documentation

## Overview

The Nemesis Menu supports multi-language translations loaded from JSON files.
Language files are stored locally in the `lang/` subfolder inside the Zsettings folder
(the same folder where `Mod.json` lives).

## JSON Format

Each language file is a flat JSON object with string key-value pairs:

```json
{
  "tab.combat": "战斗",
  "flight.label": "飞行",
  "flight.desc": "切换飞行模式"
}
```

### Key Naming Convention

| Prefix | Example | Description |
|--------|---------|-------------|
| `tab.*` | `tab.combat` | Sidebar tab names |
| `sidebar.*` | `sidebar.combat` | Sidebar group headers |
| `page.*.name` | `page.combat.name` | Page header title |
| `page.*.desc` | `page.combat.desc` | Page header description |
| `subtab.*` | `subtab.kill_aura` | Subtab labels |
| `group.*` | `group.movement` | Content group headers |
| `{feature}.label` | `flight.label` | Toggle/checkbox label |
| `{feature}.desc` | `flight.desc` | Toggle/checkbox description |
| `{feature}.hint` | `search.hint` | Input field placeholder |
| `weather.*` | `weather.sunny` | Weather type names |
| `ka_mode.*` | `ka_mode.dot` | Kill aura mode names |
| `cmd.*` | `cmd.no_fog` | Console command preset names |
| `lang.*` | `lang.fetching` | Language UI strings |
| `notify.*` | `notify.buff_added` | Notification messages |
| `create_config.label` | — | Button labels |

## Complete Key List

### Tabs
- `tab.combat`, `tab.buffs`, `tab.player`, `tab.esp`, `tab.world`
- `tab.farming`, `tab.teleport`, `tab.dungeon`, `tab.misc`, `tab.language`, `tab.configs`

### Sidebar Groups
- `sidebar.combat`, `sidebar.buffs`, `sidebar.player`, `sidebar.visual`
- `sidebar.farming`, `sidebar.teleport`, `sidebar.settings`

### Page Headers
- `page.combat.name` / `page.combat.desc`
- `page.buffs.name` / `page.buffs.desc`
- `page.player.name` / `page.player.desc`
- `page.esp.name` / `page.esp.desc`
- `page.world.name` / `page.world.desc`
- `page.farming.name` / `page.farming.desc`
- `page.teleport.name` / `page.teleport.desc`
- `page.dungeon.name` / `page.dungeon.desc`
- `page.misc.name` / `page.misc.desc`
- `page.configs.name` / `page.configs.desc`
- `page.settings.name` / `page.settings.desc`

### Subtabs
- `subtab.kill_aura`, `subtab.assists`
- `subtab.entities`, `subtab.overlay`
- `subtab.features`, `subtab.bridge`

### Content Groups
- `group.movement`, `group.defense`, `group.view`
- `group.kill_aura`, `group.attack`, `group.multiplier`, `group.automation`
- `group.resonance`, `group.effects`, `group.buff_selection`, `group.buff_tools`
- `group.general`, `group.entities`, `group.labels`
- `group.time`, `group.environment`, `group.helpers`
- `group.vacuum`, `group.auto`, `group.distances`
- `group.teleport`, `group.ui`, `group.unlocks`, `group.auto_claim`
- `group.dungeon_quest`, `group.enter_dungeon`
- `group.uid_customization`, `group.tools`, `group.diagnostics`, `group.console`
- `group.list`, `group.language`

### Player Section
- `flight.label` / `flight.desc`
- `noclip.label` / `noclip.desc`
- `noclip_speed.label`
- `player_speed.label` / `player_speed.desc`
- `speed_value.label`
- `vehicle_speed.label` / `vehicle_speed.desc`
- `infinite_stamina.label` / `infinite_stamina.desc`
- `illusive_sprint.label` / `illusive_sprint.desc`
- `godmode.label` / `godmode.desc`
- `waterwalk.label` / `waterwalk.desc`
- `antidither.label` / `antidither.desc`
- `mario_jump.label` / `mario_jump.desc`
- `first_person.label` / `first_person.desc`

### Combat Section
- `kill_aura.label` / `kill_aura.desc`
- `ka_radius.label`
- `ka_mode.label` / `ka_mode.desc`
- `ka_mode.dot`, `ka_mode.instant`, `ka_mode.drown`
- `airstrike.label` / `airstrike.desc`
- `always_crit.label` / `always_crit.desc`
- `onehit.label` / `onehit.desc`
- `nocd.label` / `nocd.desc`
- `hit_mult.label` / `hit_mult.desc`
- `hit_count.label`
- `auto_dodge.label` / `auto_dodge.desc`
- `auto_parry.label` / `auto_parry.desc`
- `auto_rvheal.label` / `auto_rvheal.desc`

### Buffs Section
- `inf_forte.label` / `inf_forte.desc`
- `inf_ult.label` / `inf_ult.desc`
- `inf_intro_outro.label` / `inf_intro_outro.desc`
- `max_reso_chain.label` / `max_reso_chain.desc`
- `super_buff.label` / `super_buff.desc`
- `echoes_buff.label` / `echoes_buff.desc`
- `material_shell_buff.label` / `material_shell_buff.desc`
- `search.label` / `search.desc` / `search.hint`
- `apply_selected.label`
- `buff_id.label` / `buff_id.desc` / `buff_id.hint`
- `add_buff.label`
- `clear_buffs.label`

### ESP Section
- `esp.label` / `esp.desc`
- `esp_radius.label`
- `max_entities.label`
- `show_monster.label` / `show_monster.desc`
- `show_treasure.label` / `show_treasure.desc`
- `show_collect.label` / `show_collect.desc`
- `show_animal.label` / `show_animal.desc`
- `show_casket.label` / `show_casket.desc`
- `show_puzzle.label` / `show_puzzle.desc`
- `show_rock.label` / `show_rock.desc`
- `show_blobfly.label` / `show_blobfly.desc`
- `show_mutterfly.label` / `show_mutterfly.desc`
- `show_name.label` / `show_name.desc`
- `show_distance.label` / `show_distance.desc`
- `show_box.label` / `show_box.desc`
- `trap_chests.label` / `trap_chests.desc`

### World Section
- `world_speed.label` / `world_speed.desc`
- `freeze_time.label` / `freeze_time.desc`
- `weather_type.label` / `weather_type.desc`
- `weather.sunny`, `weather.cloudy`, `weather.thunder`, `weather.snow`, `weather.rain`
- `apply_weather.label`
- `fov.label`
- `apply_fov.label`
- `plot_skip.label` / `plot_skip.desc`
- `treasure_tracking.label` / `treasure_tracking.desc`
- `debug_entity.label` / `debug_entity.desc`
- `perception_range.label` / `perception_range.desc`

### Farming Section
- `mob_vacuum.label` / `mob_vacuum.desc`
- `vacuum_collect.label` / `vacuum_collect.desc`
- `auto_collect_material.label` / `auto_collect_material.desc`
- `auto_loot.label` / `auto_loot.desc`
- `auto_pick_treasure.label` / `auto_pick_treasure.desc`
- `auto_echo_farm.label` / `auto_echo_farm.desc`
- `auto_absorb.label` / `auto_absorb.desc`
- `auto_destroy.label` / `auto_destroy.desc`
- `kill_animal.label` / `kill_animal.desc`
- `auto_puzzle.label` / `auto_puzzle.desc`
- `auto_sonance_casket.label` / `auto_sonance_casket.desc`
- `auto_quest.label` / `auto_quest.desc`
- `auto_open_tp.label` / `auto_open_tp.desc`
- `auto_lament_recon.label` / `auto_lament_recon.desc`
- `auto_loot_distance.label`
- `auto_treasure_distance.label`
- `auto_absorb_distance.label`

### Teleport Section
- `mark_tp.label` / `mark_tp.desc`
- `quest_tp.label` / `quest_tp.desc`
- `waypoints_longrange.label` / `waypoints_longrange.desc`
- `auto_tp_monster.label` / `auto_tp_monster.desc`

### Dungeon Section
- `skip_entrance.label` / `skip_entrance.desc`
- `auto_challenge.label` / `auto_challenge.desc`
- `auto_claim_reward.label` / `auto_claim_reward.desc`
- `entrance_id.label` / `entrance_id.hint`
- `enter_dungeon.label`

### Misc Section
- `show_fps.label` / `show_fps.desc`
- `fps_unlocker.label` / `fps_unlocker.desc`
- `always_cursor.label` / `always_cursor.desc`
- `stream_proof.label` / `stream_proof.desc`
- `menu_key.label` / `menu_key.desc`
- `force_unlock.label` / `force_unlock.desc`
- `treasure_tp_overlay.label` / `treasure_tp_overlay.desc`
- `auto_claim_tasks.label` / `auto_claim_tasks.desc`
- `auto_claim_bp.label` / `auto_claim_bp.desc`
- `auto_claim_trophies.label` / `auto_claim_trophies.desc`
- `auto_restart_dungeon.label` / `auto_restart_dungeon.desc`
- `fix_stuck_quest.label` / `fix_stuck_quest.desc`
- `uid_text.label` / `uid_text.desc` / `uid_text.hint`
- `uid_color.label` / `uid_color.desc`
- `apply_uid.label`
- `enable_controllers.label`
- `force_unlock_skins.label`
- `test_bridge.label`
- `save_config.label`
- `watermark.label` / `watermark.desc`
- `show_keybinds.label` / `show_keybinds.desc`
- `command.label` / `command.desc` / `command.hint`
- `send_command.label`
- `cmd_presets.label` / `cmd_presets.desc`
- `cmd.debug_camera`, `cmd.no_fog`, `cmd.enable_fog`, `cmd.show_stats`
- `cmd.freecam_10`, `cmd.freecam_50`, `cmd.freecam_100`

### Configs Section
- `create_config.label`

### Language Section
- `lang.current`, `lang.fetching`, `lang.refresh`
- `lang.downloading`, `lang.active`, `lang.download`

### Notifications
- `notify.config_loaded`, `notify.config_saved`, `notify.config_deleted`, `notify.config_created`
- `notify.buff_added`, `notify.invalid_buff_id`, `notify.buffs_cleared`
- `notify.weather_applied`, `notify.fov_applied`
- `notify.uid_applied`, `notify.controllers_enabled`, `notify.unlocking_skins`
- `notify.bridge_test`, `notify.config_saved_modjson`, `notify.command_sent`
- `notify.entering_dungeon`, `notify.invalid_entrance_id`, `notify.applied`


