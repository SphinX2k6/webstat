using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.AdventureGuide;

// Token: 0x02001AA9 RID: 6825
public static class DamageNumFormatRuleDefine
{
	// Token: 0x04005DD4 RID: 24020
	[Nullable(1)]
	[StaticVariableRuleIgnore]
	public static readonly Dictionary<EDungeonSubType, IDamageNumFormatRule> DamageNumFormatRuleMap = new Dictionary<EDungeonSubType, IDamageNumFormatRule>
	{
		{
			EDungeonSubType.PinballBattle,
			new PinballBattleDamageNumFormatRule()
		},
		{
			EDungeonSubType.BossPiling,
			new BossPillingBattleDamageNumFormatRule()
		}
	};
}
