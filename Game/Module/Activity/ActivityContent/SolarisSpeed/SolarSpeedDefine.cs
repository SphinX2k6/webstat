using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.SolarisSpeed
{
	// Token: 0x02006371 RID: 25457
	[NullableContext(1)]
	[Nullable(0)]
	public class SolarSpeedDefine : IStaticVariableResetter
	{
		// Token: 0x0603FEE5 RID: 261861 RVA: 0x0106651E File Offset: 0x0106471E
		static SolarSpeedDefine()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(SolarSpeedDefine.CreateStaticDefaultValue), new Action(SolarSpeedDefine.ResetStaticDefaultValue));
		}

		// Token: 0x0603FEE6 RID: 261862 RVA: 0x01066540 File Offset: 0x01064740
		public static void CreateStaticDefaultValue()
		{
			SolarSpeedDefine.rankBgPathMap = new List<string>
			{
				"/Game/Aki/UI/UIResources/UiTips/Image/GongduolaOnlineResult/T_ResultBgPlayer.T_ResultBgPlayer",
				"/Game/Aki/UI/UIResources/UiTips/Image/GongduolaOnlineResult/T_ResultBgOtherPlayer.T_ResultBgOtherPlayer",
				"/Game/Aki/UI/UIResources/UiTips/Image/GongduolaOnlineResult/T_ResultBgBronze.T_ResultBgBronze"
			};
			SolarSpeedDefine.medalTexPathMap = new List<string>
			{
				"/Game/Aki/UI/UIResources/Common/Image/Com/T_IconMedalGold.T_IconMedalGold",
				"/Game/Aki/UI/UIResources/Common/Image/Com/T_IconMedalSilver.T_IconMedalSilver",
				"/Game/Aki/UI/UIResources/Common/Image/Com/T_IconMedalBronze.T_IconMedalBronze"
			};
			SolarSpeedDefine.medalColorHex = new List<string>
			{
				"e1a846",
				"5488C2",
				"c89b76"
			};
			SolarSpeedDefine.fxColorHex = new List<string>
			{
				"FFFFFF",
				"96C4FF",
				"B4A8E4"
			};
			SolarSpeedDefine.playerIndexIconMap = new List<string>
			{
				"/Game/Aki/UI/UIResources/Common/Atlas/SP_Common1P.SP_Common1P",
				"/Game/Aki/UI/UIResources/Common/Atlas/SP_Common2P.SP_Common2P",
				"/Game/Aki/UI/UIResources/Common/Atlas/SP_Common3P.SP_Common3P"
			};
			SolarSpeedDefine.playerIndexSelfIconMap = new List<string>
			{
				"/Game/Aki/UI/UIResources/Common/Atlas/SP_CommonSelf1P.SP_CommonSelf1P",
				"/Game/Aki/UI/UIResources/Common/Atlas/SP_CommonSelf2P.SP_CommonSelf2P",
				"/Game/Aki/UI/UIResources/Common/Atlas/SP_CommonSelf3P.SP_CommonSelf3P"
			};
			SolarSpeedDefine.avatarPattern = new List<string>
			{
				"T_AvatarPatternGold",
				"T_AvatarPatternSilver",
				"T_AvatarPatternCopper"
			};
			SolarSpeedDefine.linePattern = new List<string>
			{
				"T_DescLineGold",
				"T_DescLineSilver",
				"T_DescLineCopper"
			};
			SolarSpeedDefine.bgPattern = new List<string>
			{
				"T_ResultBgPlayer",
				"T_ResultBgOtherPlayer",
				"T_ResultBgBronze"
			};
			SolarSpeedDefine.bonusRewardList = new List<int>
			{
				25,
				26,
				27,
				28,
				29,
				30
			};
		}

		// Token: 0x0603FEE7 RID: 261863 RVA: 0x0106670A File Offset: 0x0106490A
		public static void ResetStaticDefaultValue()
		{
			SolarSpeedDefine.rankBgPathMap = null;
			SolarSpeedDefine.medalTexPathMap = null;
			SolarSpeedDefine.medalColorHex = null;
			SolarSpeedDefine.fxColorHex = null;
			SolarSpeedDefine.playerIndexIconMap = null;
			SolarSpeedDefine.playerIndexSelfIconMap = null;
			SolarSpeedDefine.avatarPattern = null;
			SolarSpeedDefine.linePattern = null;
			SolarSpeedDefine.bgPattern = null;
			SolarSpeedDefine.bonusRewardList = null;
		}

		// Token: 0x04023E90 RID: 147088
		public const int SOLAR_SPEED_INSTANCE_ENTRANCE_ID = 9000;

		// Token: 0x04023E91 RID: 147089
		public const int SOLAR_SPEED_BONUS_LEVEL_ID = 99;

		// Token: 0x04023E92 RID: 147090
		public const string SOLAR_SPEED_REWARD_TITLE_TEXT_ID = "LianjiPaoku_Reward_Title";

		// Token: 0x04023E93 RID: 147091
		public const string SOLAR_SPEED_REWARD_PROGRESS_TEXT_ID = "LianjiPaoku_Reward_Desc";

		// Token: 0x04023E94 RID: 147092
		public const string SOLAR_SPEED_REWARD_BUTTON_TEXT_ID = "LianjiPaoku_Button_Receive";

		// Token: 0x04023E95 RID: 147093
		public const string SOLAR_SPEED_CLOSE_BUTTON_TEXT_ID_IN_SETTLE = "LianjiPaoku_End_Leave";

		// Token: 0x04023E96 RID: 147094
		public const string SOLAR_SPEED_CONFIRM_BUTTON_TEXT_ID_IN_SETTLE = "LianjiPaoku_End_Again";

		// Token: 0x04023E97 RID: 147095
		public const string SOLAR_SPEED_CONFIRM_DESC_TEXT_ID_IN_SETTLE = "LianjiPaoku_End_BestScore";

		// Token: 0x04023E98 RID: 147096
		public const string SOLAR_SPEED_RANK_SCORE_TEXT_ID_IN_SETTLE = "LianjiPaoku_End_RankScore";

		// Token: 0x04023E99 RID: 147097
		public const string SOLAR_SPEED_GOLD_SCORE_TEXT_ID_IN_SETTLE = "LianjiPaoku_End_PickRank";

		// Token: 0x04023E9A RID: 147098
		public const string SOLAR_SPEED_DISTANCE_SCORE_TEXT_ID_IN_SETTLE = "LianjiPaoku_End_CompleteRank";

		// Token: 0x04023E9B RID: 147099
		public const string SOLAR_SPEED_RECORD_TEXT_ID_IN_SETTLE = "LianjiPaoku_End_HistoryRank";

		// Token: 0x04023E9C RID: 147100
		public const string SOLAR_SPEED_HIGHEST_RANK_TEXT_ID = "LianjiPaoku_Top_Rank";

		// Token: 0x04023E9D RID: 147101
		public const string SOLAR_SPEED_HIGHEST_SCORE_TEXT_ID = "LianjiPaoku_Top_Score";

		// Token: 0x04023E9E RID: 147102
		public const string SOLAR_SPEED_LAP_RECORD_TEXT_ID = "LianjiPaoku_Top_Time";

		// Token: 0x04023E9F RID: 147103
		public const string SOLAR_SPEED_LAP_RECORD_NO_RECORD_TEXT_ID = "LianjiPaoku_Top_Time_No_Time";

		// Token: 0x04023EA0 RID: 147104
		public const string SOLAR_SPEED_UNLOCK_AFTER_DAYS = "LianjiPaokuReward_Level_UnLock";

		// Token: 0x04023EA1 RID: 147105
		public const string SOLAR_SPEED_MOST_RECORD_TEXT_ID = "LianjiPaokuReward_Level_TopScore";

		// Token: 0x04023EA2 RID: 147106
		public const string SOLAR_SPEED_NO_RECORD_TEXT_ID = "LianjiPaokuReward_Level_NoRecords";

		// Token: 0x04023EA3 RID: 147107
		public const string SOLAR_SPEED_REWARD_TITLE_TEXT_ID_IN_SUBVIEW = "LianjiPaokuReward_9000_Preview";

		// Token: 0x04023EA4 RID: 147108
		public const string SOLAR_SPEED_REWARD_PROGRESS_TEXT_ID_IN_SUBVIEW = "parkour_award_2_1";

		// Token: 0x04023EA5 RID: 147109
		public const string SOLAR_SPEED_CONFIRM_BUTTON_TEXT_ID_IN_SUBVIEW = "PrefabTextItem_3950726357_Text";

		// Token: 0x04023EA6 RID: 147110
		public const string SOLAR_SPEED_BONUS_REWARD_TEXT_ID_IN_REWARD = "LianjiPaoku_Bonus_Level_Title";

		// Token: 0x04023EA7 RID: 147111
		public const string SOLAR_SPEED_CONFIRM_BUTTON_TEXT_ID_IN_RESULT = "PrefabTextItem_1234291298_Text";

		// Token: 0x04023EA8 RID: 147112
		public const string SOLAR_SPEED_ADD_FRIEND_TIPS_TEXT_ID = "LianjiPaoku_Button_AddFr_Tip";

		// Token: 0x04023EA9 RID: 147113
		public const string SOLAR_SPEED_REWARD_CANNOT_OPEN_TIPS_TEXT_ID = "LianjiPaoku_Reward_Cannot_Open_Tips";

		// Token: 0x04023EAA RID: 147114
		public const string SOLAR_SPEED_BONUS_LEVEL_ICON_PATH = "/Game/Aki/UI/UIResources/Common/Image/ComImg/T_ComRomeText_07.T_ComRomeText_07";

		// Token: 0x04023EAB RID: 147115
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public static IReadOnlyList<string> rankBgPathMap;

		// Token: 0x04023EAC RID: 147116
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public static IReadOnlyList<string> medalTexPathMap;

		// Token: 0x04023EAD RID: 147117
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public static IReadOnlyList<string> medalColorHex;

		// Token: 0x04023EAE RID: 147118
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public static IReadOnlyList<string> fxColorHex;

		// Token: 0x04023EAF RID: 147119
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public static IReadOnlyList<string> playerIndexIconMap;

		// Token: 0x04023EB0 RID: 147120
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public static IReadOnlyList<string> playerIndexSelfIconMap;

		// Token: 0x04023EB1 RID: 147121
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public static IReadOnlyList<string> avatarPattern;

		// Token: 0x04023EB2 RID: 147122
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public static IReadOnlyList<string> linePattern;

		// Token: 0x04023EB3 RID: 147123
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public static IReadOnlyList<string> bgPattern;

		// Token: 0x04023EB4 RID: 147124
		[Nullable(2)]
		public static IReadOnlyList<int> bonusRewardList;
	}
}
