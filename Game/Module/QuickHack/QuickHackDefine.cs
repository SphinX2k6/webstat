using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.BattleUi;

namespace CSharpScript.Game.Module.QuickHack
{
	// Token: 0x020052EA RID: 21226
	[NullableContext(1)]
	[Nullable(0)]
	public class QuickHackDefine
	{
		// Token: 0x0401F24C RID: 127564
		public const string QUICK_HACK_SKILL_ENABLE_BG = "QuickHackSkillEnableBg";

		// Token: 0x0401F24D RID: 127565
		public const string QUICK_HACK_SKILL_ENABLE_HOLD_BG = "QuickHackSkillEnableHoldBg";

		// Token: 0x0401F24E RID: 127566
		public const string QUICK_HACK_SKILL_DISABLE_BG = "QuickHackSkillDisableBg";

		// Token: 0x0401F24F RID: 127567
		public const string QUICK_HACK_SKILL_DISABLE_HOLD_BG = "QuickHackSkillDisableHoldBg";

		// Token: 0x0401F250 RID: 127568
		public const string QUICK_HACK_SKILL_ENABLE_ICON_BG = "QuickHackSkillEnableIconBg";

		// Token: 0x0401F251 RID: 127569
		public const string QUICK_HACK_SKILL_DISABLE_ICON_BG = "QuickHackSkillDisableIconBg";

		// Token: 0x0401F252 RID: 127570
		public const string QUICK_HACK_SKILL_ENABLE_RAM_ICON = "QuickHackSkillEnableRamIcon";

		// Token: 0x0401F253 RID: 127571
		public const string QUICK_HACK_SKILL_DISABLE_RAM_ICON = "QuickHackSkillDisableRamIcon";

		// Token: 0x0401F254 RID: 127572
		public const string QUICK_HACK_SKILL_ENABLE_TAG_BG = "QuickHackSkillEnableTagBg";

		// Token: 0x0401F255 RID: 127573
		public const string QUICK_HACK_SKILL_DISABLE_TAG_BG = "QuickHackSkillDisableTagBg";

		// Token: 0x0401F256 RID: 127574
		public const string QUICK_HACK_MARKS_ITEM = "QuickHackMarksItem";

		// Token: 0x0401F257 RID: 127575
		public const string QUICK_HACK_RAM_TITLE_TEXT = "QuickHack_Desc_1";

		// Token: 0x0401F258 RID: 127576
		public const string QUICK_HACK_DURATION_LIMIT_TEXT = "QuickHack_Desc_2";

		// Token: 0x0401F259 RID: 127577
		public const string QUICK_HACK_CONDITION_FAIL_TEXT = "QuickHack_Prohibit_1";

		// Token: 0x0401F25A RID: 127578
		public const string QUICK_HACK_TARGET_NOT_MATCH_TEXT = "QuickHack_Prohibit_2";

		// Token: 0x0401F25B RID: 127579
		public const string QUICK_HACK_RAM_NOT_ENOUGH_TEXT = "QuickHack_Prohibit_3";

		// Token: 0x0401F25C RID: 127580
		public const string QUICK_HACK_USAGE_COUNT_NOT_ENOUGH_TEXT = "QuickHack_Prohibit_4";

		// Token: 0x0401F25D RID: 127581
		public const string QUICK_HACK_MONSTER_NOT_MATCH_TEXT = "QuickHack_Prohibit_5";

		// Token: 0x0401F25E RID: 127582
		public const string QUICK_HACK_TARGET_HAS_BEEN_HACK_TEXT = "QuickHack_Prohibit_6";

		// Token: 0x0401F25F RID: 127583
		public const string QUICK_HACK_SKILL_ENABLE_STATE_TEXT = "Skill_10001511_HackSkill101";

		// Token: 0x0401F260 RID: 127584
		public const string QUICK_HACK_SKILL_DISABLE_STATE_TEXT = "Skill_10001511_HackSkill102";

		// Token: 0x0401F261 RID: 127585
		public const string QUICK_HACK_SKILL_DURATION_TEXT = "QuickHack_SkillMessage_1";

		// Token: 0x0401F262 RID: 127586
		public const string QUICK_HACK_SKILL_UPLOAD_TEXT = "QuickHack_SkillMessage_2";

		// Token: 0x0401F263 RID: 127587
		public const string QUICK_HACK_NO_TARGET_TEXT = "QuickHack_Desc_12";

		// Token: 0x0401F264 RID: 127588
		[StaticVariableRuleIgnore]
		public static readonly List<int> quickHackSkillItemOffsets = new List<int>
		{
			0,
			-10,
			-30,
			-40,
			-20,
			20,
			50
		};

		// Token: 0x0401F265 RID: 127589
		public const string QUICK_HACK_AUTO_USE_SKILL_LONG_PRESS = "QuickHackAutoUseSkillLongPressTime";

		// Token: 0x0401F266 RID: 127590
		public const string QUICK_HACK_TRY_EXIT_LONG_PRESS = "QuickHackTryExitLongPressTime";

		// Token: 0x0401F267 RID: 127591
		public const string QUICK_HACK_FORCE_EXIT_LONG_PRESS = "QuickHackForceExitLongPressTime";

		// Token: 0x0401F268 RID: 127592
		public const int QUICK_HACK_PER_RAM_WIDTH = 28;

		// Token: 0x0401F269 RID: 127593
		public const string QUICK_HACK_RAM_SELECTED_CURVE = "/Game/Aki/UI/UIResources/UiLevel/Curve/CyberSynergy/Curve_BarPawY.Curve_BarPawY";

		// Token: 0x0401F26A RID: 127594
		public const int QUICK_HACK_RAM_SELECTED_MAX_FRAME = 34;

		// Token: 0x0401F26B RID: 127595
		public const int QUICK_HACK_RAM_SELECTED_FRAME_PER_SECOND = 60;

		// Token: 0x0401F26C RID: 127596
		public const int QUICK_HACK_RAM_SELECTED_Y_MIN = 0;

		// Token: 0x0401F26D RID: 127597
		public const int QUICK_HACK_RAM_SELECTED_Y_MAX = 6;

		// Token: 0x0401F26E RID: 127598
		[StaticVariableRuleIgnore]
		public static readonly List<EBattleUiChild> battleViewExcludeChildren = new List<EBattleUiChild>
		{
			EBattleUiChild.HeadState,
			EBattleUiChild.BossState,
			EBattleUiChild.DamageView
		};

		// Token: 0x0401F26F RID: 127599
		[StaticVariableRuleIgnore]
		public static readonly List<EBattleUiChild> commonBattleViewExcludeChildren = new List<EBattleUiChild>
		{
			EBattleUiChild.HeadState,
			EBattleUiChild.BossState,
			EBattleUiChild.DamageView
		};

		// Token: 0x0401F270 RID: 127600
		public const string QUICK_HACK_SKILL_ENABLE_CLICK_COLOR = "#55DAFFFF";

		// Token: 0x0401F271 RID: 127601
		public const string QUICK_HACK_SKILL_DISABLE_CLICK_COLOR = "#FF5753FF";

		// Token: 0x0401F272 RID: 127602
		public const string QUICK_HACK_POST_PROCESS_EFFECT_PATH = "/Game/Aki/Effect/DataAsset/FilterDA/DA_PostProcess_Filter_Green.DA_PostProcess_Filter_Green";

		// Token: 0x0401F273 RID: 127603
		public const float QUICK_HACK_SCREEN_TARGET_EXTEND = 0.1f;

		// Token: 0x0401F274 RID: 127604
		public const string QUICK_HACK_AUDIO_COMMON_MARKS_LOOP = "play_ui_focus_mode_scanning_loop";

		// Token: 0x0401F275 RID: 127605
		public const string QUICK_HACK_AUDIO_COMMON_MARKS_FINISH = "play_ui_focus_mode_scanning_qh_done";

		// Token: 0x0401F276 RID: 127606
		public const string QUICK_HACK_AUDIO_COMMON_SELECT_SKILL = "play_ui_focus_mode_scanning_choice";

		// Token: 0x0401F277 RID: 127607
		public const string QUICK_HACK_AUDIO_BATTLE_MARKS_LOOP = "play_role_lucy_bat_burst01_qh_loop";

		// Token: 0x0401F278 RID: 127608
		public const string QUICK_HACK_AUDIO_BATTLE_MARKS_FINISH = "play_role_lucy_bat_burst01_qh_done";

		// Token: 0x0401F279 RID: 127609
		public const string QUICK_HACK_AUDIO_BATTLE_SELECT_SKILL = "play_role_lucy_bat_burst01_qh_select";

		// Token: 0x0401F27A RID: 127610
		public const string QUICK_HACK_AUDIO_BATTLE_USE_SKILL = "play_role_lucy_bat_burst01_qh_scanning";

		// Token: 0x0401F27B RID: 127611
		public const string QUICK_HACK_MARK_RED_COLOR = "#FF4F4BFF";

		// Token: 0x0401F27C RID: 127612
		public const string QUICK_HACK_MARK_BLUE_COLOR = "#6CF4F8FF";

		// Token: 0x0401F27D RID: 127613
		public const int QUICK_HACK_MONSTER_MARK_UPLOAD_TIME = 200;

		// Token: 0x0401F27E RID: 127614
		public const string QUICK_HACK_MARK_BACKGROUND_BLUE = "QuickHackMarkBackgroundBlue";

		// Token: 0x0401F27F RID: 127615
		public const string QUICK_HACK_MARK_PROGRESS_BLUE = "QuickHackMarkProgressBlue";

		// Token: 0x0401F280 RID: 127616
		public const string QUICK_HACK_MARK_BACKGROUND_RED = "QuickHackMarkBackgroundRed";

		// Token: 0x0401F281 RID: 127617
		public const string QUICK_HACK_MARK_PROGRESS_RED = "QuickHackMarkProgressRed";
	}
}
