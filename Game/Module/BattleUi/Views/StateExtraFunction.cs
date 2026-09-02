using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Component;
using CSharpScript.Game.Module.Battle;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x0200610D RID: 24845
	public static class StateExtraFunction
	{
		// Token: 0x0603EC48 RID: 257096 RVA: 0x01012DC8 File Offset: 0x01010FC8
		[NullableContext(2)]
		public static ExtraItemParams GetExtraItemParamsByCreatureData(CreatureDataComponent creatureDataComp)
		{
			if (creatureDataComp == null)
			{
				return null;
			}
			AttributeComponent attributeComponent = creatureDataComp.GetAttributeComponent();
			int valueOrDefault = ((attributeComponent != null) ? attributeComponent.MoraleLevel : null).GetValueOrDefault();
			if (valueOrDefault != 0)
			{
				MoraleLevelItemParams moraleLevelItemParams = new MoraleLevelItemParams();
				moraleLevelItemParams.Type = EExtraItemType.MoraleLevel;
				moraleLevelItemParams.ResourceId = "UiItem_MonsterMoraleLevel";
				moraleLevelItemParams.MoraleLevel = valueOrDefault;
				moraleLevelItemParams.Creator = delegate()
				{
					MoraleMonsterLevelItem moraleMonsterLevelItem = new MoraleMonsterLevelItem();
					moraleMonsterLevelItem.InitExtraItemType(EExtraItemType.MoraleLevel);
					return moraleMonsterLevelItem;
				};
				return moraleLevelItemParams;
			}
			int honamiStoryLevel = creatureDataComp.HonamiStoryLevel;
			if (honamiStoryLevel != 0)
			{
				HonamiStoryLevelItemParams honamiStoryLevelItemParams = new HonamiStoryLevelItemParams();
				honamiStoryLevelItemParams.Type = EExtraItemType.HonamiStoryLevel;
				honamiStoryLevelItemParams.ResourceId = "UiItem_HonamiStoryMainTipLevel";
				honamiStoryLevelItemParams.HonamiStoryLevel = honamiStoryLevel;
				honamiStoryLevelItemParams.Creator = delegate()
				{
					HonamiStoryMonsterLevelItem honamiStoryMonsterLevelItem = new HonamiStoryMonsterLevelItem();
					honamiStoryMonsterLevelItem.InitExtraItemType(EExtraItemType.HonamiStoryLevel);
					return honamiStoryMonsterLevelItem;
				};
				return honamiStoryLevelItemParams;
			}
			AttributeComponent attributeComponent2 = creatureDataComp.GetAttributeComponent();
			int valueOrDefault2 = ((attributeComponent2 != null) ? attributeComponent2.FlagChallengeMonsterLevel : null).GetValueOrDefault();
			if (valueOrDefault2 != 0)
			{
				FlagChallengeLevelItemParams flagChallengeLevelItemParams = new FlagChallengeLevelItemParams();
				flagChallengeLevelItemParams.Type = EExtraItemType.FlagChallengeLevel;
				flagChallengeLevelItemParams.ResourceId = "UiItem_MonsterFlagChallengeLevel";
				flagChallengeLevelItemParams.FlagChallengeLevel = valueOrDefault2;
				flagChallengeLevelItemParams.Creator = delegate()
				{
					FlagChallengeMonsterLevelItem flagChallengeMonsterLevelItem = new FlagChallengeMonsterLevelItem();
					flagChallengeMonsterLevelItem.InitExtraItemType(EExtraItemType.FlagChallengeLevel);
					return flagChallengeMonsterLevelItem;
				};
				return flagChallengeLevelItemParams;
			}
			return null;
		}
	}
}
