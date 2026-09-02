using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x0200001E RID: 30
[NullableContext(1)]
[Nullable(0)]
public class AudioDefine
{
	// Token: 0x06000081 RID: 129 RVA: 0x00004864 File Offset: 0x00002A64
	static AudioDefine()
	{
		HashSet<string> hashSet = new HashSet<string>();
		foreach (string item in AudioDefine.GlobalRtpcs)
		{
			hashSet.Add(item);
		}
		foreach (string item2 in AudioDefine.EntityTypeControlRtpcs)
		{
			hashSet.Add(item2);
		}
		foreach (string item3 in AudioDefine.MotorControlRtpcs)
		{
			hashSet.Add(item3);
		}
		foreach (string item4 in AudioDefine.OtherEntityControlRtpcs)
		{
			hashSet.Add(item4);
		}
		AudioDefine.Rtpcs = hashSet;
		AudioDefine.SwitchGroups = new Dictionary<string, IReadOnlySet<string>>
		{
			{
				"role_name",
				new HashSet<string>()
			},
			{
				"char_p1orp3",
				new HashSet<string>
				{
					"p1",
					"p3"
				}
			},
			{
				"actor_ui_switch",
				new HashSet<string>
				{
					"scene",
					"sys_ui"
				}
			},
			{
				"phone_call",
				new HashSet<string>
				{
					"call_01",
					"call_02",
					"call_03",
					"call_04"
				}
			},
			{
				"role_move",
				new HashSet<string>
				{
					"fall",
					"fly",
					"highspeed",
					"normal",
					"sit",
					"slide"
				}
			},
			{
				"footstep_ground_texture",
				new HashSet<string>
				{
					"ConcreteSurface",
					"DirtSurface",
					"FabricSurface",
					"GrassSurface",
					"IceSurface",
					"MetalHardSurface",
					"MetalSheetSurface",
					"SandSurface",
					"SnowSurface",
					"WaterSurface",
					"WoodFloorSurface"
				}
			},
			{
				"footstep_shoes",
				new HashSet<string>
				{
					"fs_boots",
					"fs_heels"
				}
			},
			{
				"footstep_variant",
				new HashSet<string>()
			},
			{
				"footstep_texture",
				new HashSet<string>()
			},
			{
				"motor_wheel_texture",
				new HashSet<string>()
			},
			{
				"foley_variant",
				new HashSet<string>()
			},
			{
				"role_interact_water",
				new HashSet<string>
				{
					"cloud",
					"default"
				}
			},
			{
				"katixiya_morph",
				new HashSet<string>
				{
					"change",
					"original"
				}
			},
			{
				"aimisi_morph",
				new HashSet<string>
				{
					"change",
					"original"
				}
			}
		};
		AudioDefine.StateGroups = new Dictionary<string, IReadOnlySet<string>>
		{
			{
				"platform",
				new HashSet<string>()
			},
			{
				"language",
				new HashSet<string>()
			},
			{
				"role_name",
				new HashSet<string>()
			},
			{
				"ui_gacha_times",
				new HashSet<string>
				{
					"one",
					"ten"
				}
			},
			{
				"ui_gacha_quality",
				new HashSet<string>
				{
					"golden",
					"normal",
					"purple"
				}
			},
			{
				"ui_gacha_quality_max",
				new HashSet<string>
				{
					"golden",
					"normal",
					"purple"
				}
			},
			{
				"ui_rogue_settle",
				new HashSet<string>
				{
					"settle_a",
					"settle_b",
					"settle_c",
					"settle_s"
				}
			},
			{
				"music_group",
				new HashSet<string>
				{
					"battle",
					"field",
					"none"
				}
			},
			{
				"plot_video",
				new HashSet<string>
				{
					"playing",
					"none"
				}
			},
			{
				"plot_level",
				new HashSet<string>
				{
					"level_a",
					"level_b",
					"level_c",
					"level_d",
					"none"
				}
			},
			{
				"wuyinqu_type",
				new HashSet<string>
				{
					"purified",
					"unpurified",
					"none"
				}
			},
			{
				"battle_music_state",
				new HashSet<string>
				{
					"battle_in",
					"battle_strong",
					"perceived",
					"none"
				}
			},
			{
				"monster_type",
				new HashSet<string>
				{
					"boss_common",
					"elite",
					"medium",
					"small",
					"none"
				}
			},
			{
				"role_move",
				new HashSet<string>
				{
					"fall",
					"fly",
					"highspeed",
					"hook",
					"normal",
					"sit",
					"ski",
					"slide",
					"none"
				}
			},
			{
				"game_rogue_room_type",
				new HashSet<string>()
			},
			{
				"game_rogue_combat_combo_rank",
				new HashSet<string>
				{
					"a",
					"b",
					"c",
					"d",
					"s",
					"ss",
					"none"
				}
			},
			{
				"player_rover_gender",
				new HashSet<string>
				{
					"female",
					"male"
				}
			},
			{
				"input_controller_type",
				new HashSet<string>
				{
					"gamepad",
					"Keyboard",
					"touch"
				}
			},
			{
				"weather_type",
				new HashSet<string>
				{
					"cloudy",
					"rainy",
					"snowy",
					"sunny",
					"thunder_rain",
					"none"
				}
			},
			{
				"reconnect_auto_login",
				new HashSet<string>
				{
					"in_auto_login",
					"not_in_auto_login"
				}
			},
			{
				"loading",
				new HashSet<string>
				{
					"default",
					"fade",
					"others",
					"seamless",
					"none"
				}
			},
			{
				"game_rogue_link_state",
				new HashSet<string>
				{
					"in_link",
					"not_in_link"
				}
			},
			{
				"patch_jinxi_openbox_state",
				new HashSet<string>
				{
					"jinzhou",
					"none"
				}
			},
			{
				"country",
				new HashSet<string>()
			},
			{
				"filter",
				new HashSet<string>
				{
					"ui_default",
					"none"
				}
			},
			{
				"caccona_gal_music",
				new HashSet<string>()
			},
			{
				"dungeon_2_3_race_music",
				new HashSet<string>
				{
					"complete",
					"race_finals",
					"race_groupstage",
					"race_matchpoint",
					"none"
				}
			},
			{
				"game_maprogue_map_type",
				new HashSet<string>()
			},
			{
				"game_maprogue_map_vibe",
				new HashSet<string>()
			},
			{
				"mute_nature_voice",
				new HashSet<string>
				{
					"mute",
					"none"
				}
			},
			{
				"plot_phantom_arena_battle_state",
				new HashSet<string>
				{
					"ending",
					"none"
				}
			},
			{
				"arena_battle",
				new HashSet<string>
				{
					"battle_3d",
					"none"
				}
			},
			{
				"sp_rogue_link_vo_reuse_burst",
				new HashSet<string>
				{
					"vo_reuse",
					"none"
				}
			},
			{
				"game_sys_fightphoto",
				new HashSet<string>
				{
					"pause",
					"slow",
					"none"
				}
			},
			{
				"level_2_5_time_slow",
				new HashSet<string>
				{
					"enable",
					"none"
				}
			},
			{
				"tower_defence_music_2_6",
				new HashSet<string>
				{
					"battle",
					"none"
				}
			},
			{
				"master_bus_by_focus_state",
				new HashSet<string>
				{
					"mute_all_sound",
					"none"
				}
			},
			{
				"system_motor_radio",
				new HashSet<string>
				{
					"playing",
					"none"
				}
			},
			{
				"game_sys_fever",
				new HashSet<string>
				{
					"fever",
					"none"
				}
			},
			{
				"global_seq_speed",
				new HashSet<string>
				{
					"faster",
					"slower",
					"none"
				}
			},
			{
				"game_scene_season",
				new HashSet<string>
				{
					"autumn",
					"spring",
					"summer",
					"winter"
				}
			},
			{
				"ui_music_3_5_wawaji",
				new HashSet<string>
				{
					"stage1",
					"stage2",
					"stage3"
				}
			},
			{
				"instrument_game_mode",
				new HashSet<string>
				{
					"mute_other_bgm",
					"none"
				}
			}
		};
	}

	// Token: 0x0400004B RID: 75
	public const string STATENORMAL = "normal";

	// Token: 0x0400004C RID: 76
	public const string STATEINCUTSCENE = "incutscene";

	// Token: 0x0400004D RID: 77
	public const string STATEBACKGROUND = "background";

	// Token: 0x0400004E RID: 78
	public const string PLOT_VIDEO_GROUP = "plot_video";

	// Token: 0x0400004F RID: 79
	public const string PLOT_VIDEO = "playing";

	// Token: 0x04000050 RID: 80
	public const string PLOT_NOT_VIDEO = "none";

	// Token: 0x04000051 RID: 81
	public const string RTPCSPEEDUP = "Cutscene_speedup";

	// Token: 0x04000052 RID: 82
	public const string RTPCTEXTREPLY = "Set_TextReply";

	// Token: 0x04000053 RID: 83
	public const string RTPCWINDINTENSITY = "amb_wind_intensity";

	// Token: 0x04000054 RID: 84
	public const string RTPCRAININTENSITY = "amb_rain_intensity";

	// Token: 0x04000055 RID: 85
	public const string RTPCSNOWINTENSITY = "amb_snow_intensity";

	// Token: 0x04000056 RID: 86
	public const string RTPCGLOBALWET = "global_wet";

	// Token: 0x04000057 RID: 87
	public const string RTPC_COVER_LEVEL = "ui_cover_level";

	// Token: 0x04000058 RID: 88
	public const string RTPC_COVER_ALPHA = "ui_cover_alpha";

	// Token: 0x04000059 RID: 89
	public const string RTPC_COVER_LEVEL_DELTA = "ui_cover_level_delta";

	// Token: 0x0400005A RID: 90
	public const string RPTC_COVER_LEVEL_OPENING = "ui_cover_level_opening";

	// Token: 0x0400005B RID: 91
	public const string RPTC_COVER_LEVEL_CLOSING = "ui_cover_level_closing";

	// Token: 0x0400005C RID: 92
	public const string RPTC_SKIP_PROGRESS = "ui_plot_skip_progress";

	// Token: 0x0400005D RID: 93
	public const string RTPC_DOLBY_ATMOS = "dolby_atmos";

	// Token: 0x0400005E RID: 94
	public const string RTPC_SPLINE_DRAG_PROGRESS = "level_spline_drag_progress";

	// Token: 0x0400005F RID: 95
	public const string RTPC_SPLINE_DRAG_SPEED_RATIO = "level_spline_drag_speed_ratio";

	// Token: 0x04000060 RID: 96
	public const float ENTITY_TIMESCALE_ENABLE_THRESHOLD = 0.8f;

	// Token: 0x04000061 RID: 97
	public const float ENTITY_TIMESCALE_PAUSE_THRESHOLD = 0.0625f;

	// Token: 0x04000062 RID: 98
	public const int SPEEDUP = 15;

	// Token: 0x04000063 RID: 99
	public const int RESETSPEED = 0;

	// Token: 0x04000064 RID: 100
	public static readonly IReadOnlySet<string> GlobalRtpcs = new HashSet<string>
	{
		"amb_rain_intensity",
		"amb_snow_intensity",
		"amb_wind_intensity",
		"cutscene_speedup",
		"dolby_atmos",
		"global_seq_rate",
		"global_wet",
		"interact_level_chun_huaqiao",
		"mini_game_lifepoint_spreading_grids",
		"mini_game_lifepoint_spreading_speed",
		"mini_game_lifepoint_spreads_counting",
		"physical_obj_mass",
		"physical_obj_velocity",
		"player_z",
		"plot_seq_qte_time_scale",
		"reverb_azi_count",
		"reverb_eleva_distance",
		"set_textreply",
		"sys_game_prizedrawing_ticket_torn",
		"time_local",
		"time",
		"ui_cover_alpha",
		"ui_cover_level_closing",
		"ui_cover_level_delta",
		"ui_cover_level_opening",
		"ui_cover_level",
		"ui_plot_skip_progress",
		"woodman_azimuth",
		"woodman_block",
		"woodman_heartbeat",
		"season_mpc_value"
	};

	// Token: 0x04000065 RID: 101
	public static readonly IReadOnlySet<string> EntityTypeControlRtpcs = new HashSet<string>
	{
		"entity_type_volume_control_animal",
		"entity_type_volume_control_custom_other",
		"entity_type_volume_control_monster",
		"entity_type_volume_control_npc",
		"entity_type_volume_control_player_role",
		"entity_type_volume_control_scene_item",
		"entity_type_volume_control_vehicle",
		"entity_type_volume_control_vision"
	};

	// Token: 0x04000066 RID: 102
	public static readonly IReadOnlySet<string> MotorControlRtpcs = new HashSet<string>
	{
		"motor_air_land_time_seconds",
		"motor_crash_strength",
		"motor_engine_speed",
		"motor_nos_energe_percent",
		"motor_nos_energe",
		"motor_speed"
	};

	// Token: 0x04000067 RID: 103
	public static readonly IReadOnlySet<string> OtherEntityControlRtpcs = new HashSet<string>
	{
		"amb_water_depth",
		"effect_count",
		"entity_time_scale_combat",
		"level_spline_drag_progress",
		"level_spline_drag_speed_ratio",
		"perform_qte_progress_default",
		"phonograph_switch_to_2d",
		"role_priority",
		"role_skill_music_volume",
		"vehicle_speed",
		"projectorpuzzle_rotation"
	};

	// Token: 0x04000068 RID: 104
	public static readonly IReadOnlySet<string> Rtpcs;

	// Token: 0x04000069 RID: 105
	public static readonly IReadOnlyDictionary<string, IReadOnlySet<string>> SwitchGroups;

	// Token: 0x0400006A RID: 106
	public static readonly IReadOnlyDictionary<string, IReadOnlySet<string>> StateGroups;
}
