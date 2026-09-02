using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.FlagChallenge
{
	// Token: 0x02005D3E RID: 23870
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class FlagChallengeStyleRes : Singleton<FlagChallengeStyleRes>
	{
		// Token: 0x0603C303 RID: 246531 RVA: 0x00F42C60 File Offset: 0x00F40E60
		public FlagChallengeStyleRes()
		{
			Dictionary<EFlagChallengeUiStyleType, FlagChallengeStyleFlat> dictionary = new Dictionary<EFlagChallengeUiStyleType, FlagChallengeStyleFlat>();
			dictionary[EFlagChallengeUiStyleType.Green] = new FlagChallengeStyleFlat
			{
				LevelTabItemNormal = "T_MoraleTabNorGreen",
				LevelTabItemHover = "T_MoraleTabHoldGreen",
				LevelTabItemSelect = "T_MoraleTabSleGreen",
				AreaItemBg = "T_MoraleItemBgGreen",
				AreaItemLevelBg = "SP_MoraleMonsterLvGreen",
				AreaItemMap1 = "T_MoraleMapGreen01",
				AreaItemMap2 = "T_MoraleMapGreen02",
				AreaItemMap3 = "T_MoraleMapGreen03",
				AreaItemMap4 = "T_MoraleMapGreen04",
				AreaItemMap5 = "T_MoraleMapGreen05",
				LevelMapBg = "T_MoraleMapBgGreen",
				LevelMapTopBg = "T_MoraleMapBgTopGreen",
				LevelListLight = "T_MoraleListLightGreen",
				LevelSetOffLight = "T_MoraleLightSetoffGreen",
				LevelFrame = "T_MoraleFrameGreen",
				LevelTitleBg = "T_MoraleTitleBgGreen",
				AreaDetailItemBg1 = "T_MoraleGreenItem1",
				AreaDetailItemBg2 = "T_MoraleGreenItem2",
				AreaDetailItemBg3 = "T_MoraleGreenItem3",
				AreaDetailItemBg4 = "T_MoraleGreenItem4",
				AreaDetailItemBg5 = "T_MoraleGreenItem5",
				StrongholdItemIncompleteBg1 = "T_UnOccFlagLargerGreenNor",
				StrongholdItemCompleteBg1 = "T_UnOccFlagLargerGreenDone",
				StrongholdItemIncompleteIcon1 = "T_UnOccFlagLargerGreenNor1",
				StrongholdItemCompleteIcon1 = "T_UnOccFlagLargerGreenDone1",
				StrongholdItemIncompleteBg2 = "T_UnOccFlagBossGreenNor",
				StrongholdItemCompleteBg2 = "T_UnOccFlagBossGreenDone",
				StrongholdItemIncompleteIcon2 = "T_UnOccFlagBossGreenNor1",
				StrongholdItemCompleteIcon2 = "T_UnOccFlagBossGreenDone1",
				MaskBg = "T_MoraleMaskGreen"
			};
			dictionary[EFlagChallengeUiStyleType.Yellow] = new FlagChallengeStyleFlat
			{
				LevelTabItemNormal = "T_MoraleTabNorYellow",
				LevelTabItemHover = "T_MoraleTabHoldYellow",
				LevelTabItemSelect = "T_MoraleTabSleYellow",
				AreaItemBg = "T_MoraleItemBgYellow",
				AreaItemLevelBg = "SP_MoraleMonsterLvYellow",
				AreaItemMap1 = "T_MoraleMapYellow01",
				AreaItemMap2 = "T_MoraleMapYellow02",
				AreaItemMap3 = "T_MoraleMapYellow03",
				AreaItemMap4 = "T_MoraleMapYellow04",
				AreaItemMap5 = "T_MoraleMapYellow05",
				LevelMapBg = "T_MoraleMapBgYellow",
				LevelMapTopBg = "T_MoraleMapBgTopYellow",
				LevelListLight = "T_MoraleListLightYellow",
				LevelSetOffLight = "T_MoraleLightSetoffYellow",
				LevelFrame = "T_MoraleFrameYellow",
				LevelTitleBg = "T_MoraleTitleBgYellow",
				AreaDetailItemBg1 = "T_MoraleYellowItem1",
				AreaDetailItemBg2 = "T_MoraleYellowItem2",
				AreaDetailItemBg3 = "T_MoraleYellowItem3",
				AreaDetailItemBg4 = "T_MoraleYellowItem4",
				AreaDetailItemBg5 = "T_MoraleYellowItem5",
				StrongholdItemIncompleteBg1 = "T_UnOccFlagLargerYellowNor",
				StrongholdItemCompleteBg1 = "T_UnOccFlagLargerYellowDone",
				StrongholdItemIncompleteIcon1 = "T_UnOccFlagLargerYellowNor1",
				StrongholdItemCompleteIcon1 = "T_UnOccFlagLargerYellowDone1",
				StrongholdItemIncompleteBg2 = "T_UnOccFlagBossYellowNor",
				StrongholdItemCompleteBg2 = "T_UnOccFlagBossYellowDone",
				StrongholdItemIncompleteIcon2 = "T_UnOccFlagBossYellowNor1",
				StrongholdItemCompleteIcon2 = "T_UnOccFlagBossYellowDone1",
				MaskBg = "T_MoraleMaskYellow"
			};
			dictionary[EFlagChallengeUiStyleType.Red] = new FlagChallengeStyleFlat
			{
				LevelTabItemNormal = "T_MoraleTabNorRed",
				LevelTabItemHover = "T_MoraleTabHoldRed",
				LevelTabItemSelect = "T_MoraleTabSleRed",
				AreaItemBg = "T_MoraleItemBgRed",
				AreaItemLevelBg = "SP_MoraleMonsterLvRed",
				AreaItemMap1 = "T_MoraleMapRed01",
				AreaItemMap2 = "T_MoraleMapRed02",
				AreaItemMap3 = "T_MoraleMapRed03",
				AreaItemMap4 = "T_MoraleMapRed04",
				AreaItemMap5 = "T_MoraleMapRed05",
				LevelMapBg = "T_MoraleMapBgRed",
				LevelMapTopBg = "T_MoraleMapBgTopRed",
				LevelListLight = "T_MoraleListLightRed",
				LevelSetOffLight = "T_MoraleLightSetoffRed",
				LevelFrame = "T_MoraleFrameRed",
				LevelTitleBg = "T_MoraleTitleBgRed",
				AreaDetailItemBg1 = "T_MoraleRedItem1",
				AreaDetailItemBg2 = "T_MoraleRedItem2",
				AreaDetailItemBg3 = "T_MoraleRedItem3",
				AreaDetailItemBg4 = "T_MoraleRedItem4",
				AreaDetailItemBg5 = "T_MoraleRedItem5",
				StrongholdItemIncompleteBg1 = "T_UnOccFlagLargerRedNor",
				StrongholdItemCompleteBg1 = "T_UnOccFlagLargerRedDone",
				StrongholdItemIncompleteIcon1 = "T_UnOccFlagLargerRedNor1",
				StrongholdItemCompleteIcon1 = "T_UnOccFlagLargerRedDone1",
				StrongholdItemIncompleteBg2 = "T_UnOccFlagBossRedNor",
				StrongholdItemCompleteBg2 = "T_UnOccFlagBossRedDone",
				StrongholdItemIncompleteIcon2 = "T_UnOccFlagBossRedNor1",
				StrongholdItemCompleteIcon2 = "T_UnOccFlagBossRedDone1",
				MaskBg = "T_MoraleMaskRed"
			};
			dictionary[EFlagChallengeUiStyleType.Hidden] = new FlagChallengeStyleFlat
			{
				LevelTabItemNormal = "T_MoraleTabNorRed",
				LevelTabItemHover = "T_MoraleTabHoldRed",
				LevelTabItemSelect = "T_MoraleTabSleRed",
				AreaItemBg = "T_MoraleItemBgRed",
				AreaItemLevelBg = "SP_MoraleMonsterLvRed",
				AreaItemMap1 = "T_MoraleMapRed01",
				AreaItemMap2 = "T_MoraleMapHide2",
				AreaItemMap3 = "T_MoraleMapHide3",
				AreaItemMap4 = "T_MoraleMapHide4",
				AreaItemMap5 = "T_MoraleMapRed05",
				LevelMapBg = "T_MoraleMapBgRed",
				LevelMapTopBg = "T_MoraleMapBgTopRed",
				LevelListLight = "T_MoraleListLightRed",
				LevelSetOffLight = "T_MoraleLightSetoffRed",
				LevelFrame = "T_MoraleFrameRed",
				LevelTitleBg = "T_MoraleTitleBgRed",
				AreaDetailItemBg1 = "T_MoraleRedItem1",
				AreaDetailItemBg2 = "T_MoraleRedItem2",
				AreaDetailItemBg3 = "T_MoraleRedItem3",
				AreaDetailItemBg4 = "T_MoraleRedItem4",
				AreaDetailItemBg5 = "T_MoraleRedItem5",
				StrongholdItemIncompleteBg1 = "T_UnOccFlagLargerRedNor",
				StrongholdItemCompleteBg1 = "T_UnOccFlagLargerRedDone",
				StrongholdItemIncompleteIcon1 = "T_UnOccFlagLargerRedNor1",
				StrongholdItemCompleteIcon1 = "T_UnOccFlagLargerRedDone1",
				StrongholdItemIncompleteBg2 = "T_UnOccFlagBossRedNor",
				StrongholdItemCompleteBg2 = "T_UnOccFlagBossRedDone",
				StrongholdItemIncompleteIcon2 = "T_UnOccFlagBossRedNor1",
				StrongholdItemCompleteIcon2 = "T_UnOccFlagBossRedDone1",
				MaskBg = "T_MoraleMaskRed"
			};
			this.Data = dictionary.ToFrozenDictionary(null);
			base..ctor();
		}

		// Token: 0x04021C92 RID: 138386
		[StaticVariableRuleIgnore]
		public readonly FrozenDictionary<EFlagChallengeUiStyleType, FlagChallengeStyleFlat> Data;
	}
}
