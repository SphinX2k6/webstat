using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02001144 RID: 4420
[NullableContext(1)]
[Nullable(0)]
public static class RhythmGameModelDefine
{
	// Token: 0x04003813 RID: 14355
	[StaticVariableRuleIgnore]
	public static IReadOnlyDictionary<EKuroRhythmGameRating, string> RhythmGameHitResultTexture = new Dictionary<EKuroRhythmGameRating, string>
	{
		{
			EKuroRhythmGameRating.Perfect,
			"T_RhythmGamePerfect"
		},
		{
			EKuroRhythmGameRating.Great,
			"T_RhythmGameGreat"
		},
		{
			EKuroRhythmGameRating.Good,
			"T_RhythmGameGood"
		},
		{
			EKuroRhythmGameRating.Bad,
			"T_RhythmGameBad"
		},
		{
			EKuroRhythmGameRating.Miss,
			"T_RhythmGameMiss"
		},
		{
			EKuroRhythmGameRating.EKuroRhythmGameRating_MAX,
			""
		}
	};

	// Token: 0x04003814 RID: 14356
	public const string RHYTHM_GAME_TUNNEL_LINE_HIT_EFFECT = "/Game/Aki/Effect/DataAsset/Niagara/Scene/3_2/3_2YinYou/DA_FX_Yinyou_Rectangle_Sparks_02.DA_FX_Yinyou_Rectangle_Sparks_02";

	// Token: 0x04003815 RID: 14357
	[StaticVariableRuleIgnore]
	private static IReadOnlyDictionary<string, string> RhythmGameHitEffectPath = new Dictionary<string, string>
	{
		{
			"IconBurstSparks01",
			"/Game/Aki/Effect/EffectGroup/Scenes/3_2/3_2YinYou/DA_Fx_Group_Yinyou_Icon_Burst_Sparks_01.DA_Fx_Group_Yinyou_Icon_Burst_Sparks_01"
		},
		{
			"IconBurstSparks02",
			"/Game/Aki/Effect/EffectGroup/Scenes/3_2/3_2YinYou/DA_Fx_Group_Yinyou_Icon_Burst_Sparks_02.DA_Fx_Group_Yinyou_Icon_Burst_Sparks_02"
		},
		{
			"IconBurstSparks03",
			"/Game/Aki/Effect/EffectGroup/Scenes/3_2/3_2YinYou/DA_Fx_Group_Yinyou_Icon_Burst_Sparks_03.DA_Fx_Group_Yinyou_Icon_Burst_Sparks_03"
		},
		{
			"IconCylind",
			"/Game/Aki/Effect/EffectGroup/Scenes/3_2/3_2YinYou/DA_Fx_Group_Yinyou_Icon_Cylind.DA_Fx_Group_Yinyou_Icon_Cylind"
		},
		{
			"IconCylindB",
			"/Game/Aki/Effect/EffectGroup/Scenes/3_2/3_2YinYou/DA_Fx_Group_Yinyou_Icon_Cylind_B.DA_Fx_Group_Yinyou_Icon_Cylind_B"
		},
		{
			"IconCylindW",
			"/Game/Aki/Effect/EffectGroup/Scenes/3_2/3_2YinYou/DA_Fx_Group_Yinyou_Icon_Cylind_W.DA_Fx_Group_Yinyou_Icon_Cylind_W"
		},
		{
			"RectangleSparks",
			"/Game/Aki/Effect/EffectGroup/Scenes/3_2/3_2YinYou/DA_Fx_Group_Yinyou_Rectangle_Sparks_01.DA_Fx_Group_Yinyou_Rectangle_Sparks_01"
		},
		{
			"ChuanYue",
			"/Game/Aki/Effect/EffectGroup/Scenes/3_2/3_2YinYou/DA_Fx_Group_SYinyou_ChuanYue_02.DA_Fx_Group_SYinyou_ChuanYue_02"
		},
		{
			"BurstSparksG",
			"/Game/Aki/Effect/EffectGroup/Scenes/3_2/3_2YinYou/DA_Fx_Group_Yinyou_Burst_Sparks_G.DA_Fx_Group_Yinyou_Burst_Sparks_G"
		},
		{
			"BurstSparksB",
			"/Game/Aki/Effect/EffectGroup/Scenes/3_2/3_2YinYou/DA_Fx_Group_Yinyou_Burst_Sparks_B.DA_Fx_Group_Yinyou_Burst_Sparks_B"
		},
		{
			"BurstSparksW",
			"/Game/Aki/Effect/EffectGroup/Scenes/3_2/3_2YinYou/DA_Fx_Group_Yinyou_Burst_Sparks_W.DA_Fx_Group_Yinyou_Burst_Sparks_W"
		}
	};

	// Token: 0x04003816 RID: 14358
	[StaticVariableRuleIgnore]
	private static IReadOnlyList<string> EffectGroupA = new <>z__ReadOnlyArray<string>(new string[]
	{
		RhythmGameModelDefine.RhythmGameHitEffectPath["IconBurstSparks02"],
		RhythmGameModelDefine.RhythmGameHitEffectPath["IconCylind"]
	});

	// Token: 0x04003817 RID: 14359
	[StaticVariableRuleIgnore]
	private static IReadOnlyList<string> EffectGroupB = new <>z__ReadOnlyArray<string>(new string[]
	{
		RhythmGameModelDefine.RhythmGameHitEffectPath["IconBurstSparks01"],
		RhythmGameModelDefine.RhythmGameHitEffectPath["IconCylindB"]
	});

	// Token: 0x04003818 RID: 14360
	[StaticVariableRuleIgnore]
	private static IReadOnlyList<string> EffectGroupC = new <>z__ReadOnlyArray<string>(new string[]
	{
		RhythmGameModelDefine.RhythmGameHitEffectPath["IconBurstSparks03"],
		RhythmGameModelDefine.RhythmGameHitEffectPath["IconCylindW"]
	});

	// Token: 0x04003819 RID: 14361
	[StaticVariableRuleIgnore]
	private static IReadOnlyList<string> EffectGroupLine = new <>z__ReadOnlySingleElementList<string>(RhythmGameModelDefine.RhythmGameHitEffectPath["RectangleSparks"]);

	// Token: 0x0400381A RID: 14362
	[StaticVariableRuleIgnore]
	private static IReadOnlyList<string> EffectGroupHit = new <>z__ReadOnlySingleElementList<string>(RhythmGameModelDefine.RhythmGameHitEffectPath["ChuanYue"]);

	// Token: 0x0400381B RID: 14363
	[StaticVariableRuleIgnore]
	public static IReadOnlyDictionary<EKuroRhythmGameNoteType, IReadOnlyList<string>> RhythmGameHitResultEffect = new Dictionary<EKuroRhythmGameNoteType, IReadOnlyList<string>>
	{
		{
			EKuroRhythmGameNoteType.None,
			Array.Empty<string>()
		},
		{
			EKuroRhythmGameNoteType.KuroTapA,
			RhythmGameModelDefine.EffectGroupA
		},
		{
			EKuroRhythmGameNoteType.KuroTapB,
			RhythmGameModelDefine.EffectGroupB
		},
		{
			EKuroRhythmGameNoteType.KuroTapLeft,
			RhythmGameModelDefine.EffectGroupC
		},
		{
			EKuroRhythmGameNoteType.KuroTapRight,
			RhythmGameModelDefine.EffectGroupC
		},
		{
			EKuroRhythmGameNoteType.KuroFlickLeft,
			RhythmGameModelDefine.EffectGroupC
		},
		{
			EKuroRhythmGameNoteType.KuroFlickRight,
			RhythmGameModelDefine.EffectGroupC
		},
		{
			EKuroRhythmGameNoteType.Kuro3DFlickLeft,
			Array.Empty<string>()
		},
		{
			EKuroRhythmGameNoteType.Kuro3DFlickRight,
			Array.Empty<string>()
		},
		{
			EKuroRhythmGameNoteType.KuroLine,
			RhythmGameModelDefine.EffectGroupLine
		},
		{
			EKuroRhythmGameNoteType.KuroLineHold,
			RhythmGameModelDefine.EffectGroupLine
		},
		{
			EKuroRhythmGameNoteType.KuroLineHit,
			RhythmGameModelDefine.EffectGroupHit
		},
		{
			EKuroRhythmGameNoteType.KuroEvent,
			Array.Empty<string>()
		},
		{
			EKuroRhythmGameNoteType.EKuroRhythmGameNoteType_MAX,
			Array.Empty<string>()
		}
	};

	// Token: 0x0400381C RID: 14364
	[StaticVariableRuleIgnore]
	public static IReadOnlyDictionary<EKuroRhythmGameNoteType, string> RhythmGameHitResultExternalEffect = new Dictionary<EKuroRhythmGameNoteType, string>
	{
		{
			EKuroRhythmGameNoteType.None,
			""
		},
		{
			EKuroRhythmGameNoteType.KuroTapA,
			RhythmGameModelDefine.RhythmGameHitEffectPath["BurstSparksG"]
		},
		{
			EKuroRhythmGameNoteType.KuroTapB,
			RhythmGameModelDefine.RhythmGameHitEffectPath["BurstSparksB"]
		},
		{
			EKuroRhythmGameNoteType.KuroTapLeft,
			RhythmGameModelDefine.RhythmGameHitEffectPath["BurstSparksW"]
		},
		{
			EKuroRhythmGameNoteType.KuroTapRight,
			RhythmGameModelDefine.RhythmGameHitEffectPath["BurstSparksW"]
		},
		{
			EKuroRhythmGameNoteType.KuroFlickLeft,
			RhythmGameModelDefine.RhythmGameHitEffectPath["BurstSparksW"]
		},
		{
			EKuroRhythmGameNoteType.KuroFlickRight,
			RhythmGameModelDefine.RhythmGameHitEffectPath["BurstSparksW"]
		},
		{
			EKuroRhythmGameNoteType.Kuro3DFlickLeft,
			""
		},
		{
			EKuroRhythmGameNoteType.Kuro3DFlickRight,
			""
		},
		{
			EKuroRhythmGameNoteType.KuroLine,
			""
		},
		{
			EKuroRhythmGameNoteType.KuroLineHold,
			""
		},
		{
			EKuroRhythmGameNoteType.KuroLineHit,
			""
		},
		{
			EKuroRhythmGameNoteType.KuroEvent,
			""
		},
		{
			EKuroRhythmGameNoteType.EKuroRhythmGameNoteType_MAX,
			""
		}
	};

	// Token: 0x0400381D RID: 14365
	[StaticVariableRuleIgnore]
	public static IReadOnlyList<string> RhythmGameLockIconEffect = new <>z__ReadOnlyArray<string>(new string[]
	{
		"/Game/Aki/Effect/EffectGroup/Scenes/3_2/3_2YinYou/DA_Fx_Group_Yinyou_Suoding_01.DA_Fx_Group_Yinyou_Suoding_01",
		"/Game/Aki/Effect/EffectGroup/Scenes/3_2/3_2YinYou/DA_Fx_Group_Yinyou_Suoding_02.DA_Fx_Group_Yinyou_Suoding_02",
		"/Game/Aki/Effect/EffectGroup/Scenes/3_2/3_2YinYou/DA_Fx_Group_Yinyou_Suoding_03.DA_Fx_Group_Yinyou_Suoding_03"
	});

	// Token: 0x0400381E RID: 14366
	[StaticVariableRuleIgnore]
	public static IReadOnlyList<string> RhythmGameHighSpeedEffect = new <>z__ReadOnlySingleElementList<string>("/Game/Aki/Effect/EffectGroup/Scenes/3_2/3_2YinYou/DA_Fx_Group_Yinyou_LineScreen.DA_Fx_Group_Yinyou_LineScreen");

	// Token: 0x0400381F RID: 14367
	[StaticVariableRuleIgnore]
	public static IReadOnlyList<string> RhythmGameFeverEffect = new <>z__ReadOnlyArray<string>(new string[]
	{
		"/Game/Aki/Effect/EffectGroup/Scenes/3_2/3_2YinYou/DA_Fx_Group_Yinyou_Screen.DA_Fx_Group_Yinyou_Screen",
		"/Game/Aki/Effect/EffectGroup/Scenes/3_2/3_2YinYou/DA_Fx_Group_SpeedLine.DA_Fx_Group_SpeedLine"
	});

	// Token: 0x04003820 RID: 14368
	public const string RHYTHM_GAME_START_EFFECT = "/Game/Aki/Effect/EffectGroup/Scenes/3_2/3_2YinYou/DA_Fx_Group_Start.DA_Fx_Group_Start";

	// Token: 0x04003821 RID: 14369
	public const string RHYTHM_GAME_SPARKS_LINE_EFFECT = "/Game/Aki/Effect/EffectGroup/Scenes/3_2/3_2YinYou/DA_Fx_Group_SparkLine.DA_Fx_Group_SparkLine";

	// Token: 0x04003822 RID: 14370
	public const string RHYTHM_GAME_FIREWORKS_EFFECT = "/Game/Aki/Effect/EffectGroup/Scenes/3_2/3_2YinYou/DA_Fx_Group_Sparks.DA_Fx_Group_Sparks";

	// Token: 0x04003823 RID: 14371
	public const string RHYTHM_GAME_START_TRAIL_EFFECT = "/Game/Aki/Effect/EffectGroup/Scenes/3_2/3_2YinYou/DA_Fx_Group_StartTrail.DA_Fx_Group_StartTrail";

	// Token: 0x04003824 RID: 14372
	public const string RHYTHM_GAME_HIT_EVENT_NAME = "play_ui_rhythmship_gamenote_normal";

	// Token: 0x04003825 RID: 14373
	public const string RHYTHM_GAME_LINE_EVENT_NAME = "play_ui_rhythmship_gamenote_line";

	// Token: 0x04003826 RID: 14374
	public const string RHYTHM_GAME_LINE_HOLD_EVENT_NAME = "play_ui_rhythmship_gamenote_line_loop";

	// Token: 0x04003827 RID: 14375
	public const string RHYTHM_GAME_LINE_HIT_EVENT_NAME = "play_ui_rhythmship_gamenote_air";

	// Token: 0x04003828 RID: 14376
	public const string RHYTHM_GAME_FLICK_EVENT_NAME = "play_ui_rhythmship_gamenote_spin";

	// Token: 0x04003829 RID: 14377
	public const string RHYTHM_GAME_FEVER_LOOP_EVENT_NAME = "play_ui_rhythmship_gamefever_start_loop";

	// Token: 0x0400382A RID: 14378
	public const string RHYTHM_GAME_FEVER_END_EVENT_NAME = "play_ui_rhythmship_gamefever_end";

	// Token: 0x0400382B RID: 14379
	public const string RHYTHM_GAME_SPEED_UP_EVENT_NAME = "play_ui_rhythmship_gamespeedlevel_up";

	// Token: 0x0400382C RID: 14380
	public const string RHYTHM_GAME_SPEED_DOWN_EVENT_NAME = "play_ui_rhythmship_gamespeedlevel_down";

	// Token: 0x0400382D RID: 14381
	public const string RHYTHM_GAME_FIREWORKS_EVENT_NAME = "play_ui_rhythmship_gamefirework";

	// Token: 0x0400382E RID: 14382
	public const string RHYTHM_GAME_END_TIP_SSS_EVENT_NAME = "play_ui_rhythmship_success_sss";

	// Token: 0x0400382F RID: 14383
	public const string RHYTHM_GAME_END_TIP_NORMAL_EVENT_NAME = "play_ui_rhythmship_success_normal";

	// Token: 0x04003830 RID: 14384
	public const string RHYTHM_GAME_START_EVENT_NAME = "play_ui_rhythmship_gameship_start";
}
