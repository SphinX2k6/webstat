using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x020063B5 RID: 25525
	public static class RoverlikeFloatTextKeyMap
	{
		// Token: 0x060401B9 RID: 262585 RVA: 0x0106EFA4 File Offset: 0x0106D1A4
		// Note: this type is marked as 'beforefieldinit'.
		static RoverlikeFloatTextKeyMap()
		{
			Dictionary<ERoverlikeFloatTextType, RoverlikeFloatTextKeyPair> dictionary = new Dictionary<ERoverlikeFloatTextType, RoverlikeFloatTextKeyPair>();
			dictionary[ERoverlikeFloatTextType.HpMax] = new RoverlikeFloatTextKeyPair
			{
				Increment = "RoverRogue_EffectHintHpMaxGet",
				Decrements = "RoverRogue_EffectHintHpMaxLose"
			};
			dictionary[ERoverlikeFloatTextType.Coin] = new RoverlikeFloatTextKeyPair
			{
				Increment = "RoverRogue_EffectHintGoldGet",
				Decrements = "RoverRogue_EffectHintGoldLose"
			};
			dictionary[ERoverlikeFloatTextType.TalentPoint] = new RoverlikeFloatTextKeyPair
			{
				Increment = "RoverRogue_EffectHintTalentPointGet",
				Decrements = "RoverRogue_EffectHintTalentPointGet"
			};
			dictionary[ERoverlikeFloatTextType.GoldEfficiency] = new RoverlikeFloatTextKeyPair
			{
				Increment = "RoverRogue_EffectHintGoldEfficiencyGet",
				Decrements = "RoverRogue_EffectHintGoldEfficiencyLose"
			};
			dictionary[ERoverlikeFloatTextType.ItemRound] = new RoverlikeFloatTextKeyPair
			{
				Increment = "RoverRogue_EffectHintItemDurationGet",
				Decrements = "RoverRogue_EffectHintItemDurationLose"
			};
			dictionary[ERoverlikeFloatTextType.Attr] = new RoverlikeFloatTextKeyPair
			{
				Increment = "RoverRogue_EventGetAttribute",
				Decrements = "RoverRogue_EventGetAttribute"
			};
			RoverlikeFloatTextKeyMap.Map = dictionary;
		}

		// Token: 0x04023FAE RID: 147374
		[Nullable(1)]
		[StaticVariableRuleIgnore]
		public static readonly Dictionary<ERoverlikeFloatTextType, RoverlikeFloatTextKeyPair> Map;
	}
}
