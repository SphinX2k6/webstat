using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.AdventureGuide;

// Token: 0x02001AAF RID: 6831
[NullableContext(1)]
[Nullable(0)]
public class DamageUiDefine
{
	// Token: 0x04005DD6 RID: 24022
	public const string DEFAULT_DAMAGE_DYNAMIC_BATCH = "UiItem_DamageView_Num_Prefab";

	// Token: 0x04005DD7 RID: 24023
	public const string DEFAULT_DAMAGE_VIEW = "UiItem_DamageView_Sim_Prefab";

	// Token: 0x04005DD8 RID: 24024
	[StaticVariableRuleIgnore]
	public static readonly Dictionary<EDungeonSubType, string> inst2DamageDynamicBatch = new Dictionary<EDungeonSubType, string>
	{
		{
			EDungeonSubType.PinballBattle,
			"UiItem_DamageViewCatapultStory_Num_Prefab"
		},
		{
			EDungeonSubType.Kurotato,
			"UiItem_DamageView_Num_Potato_Prefab"
		}
	};

	// Token: 0x04005DD9 RID: 24025
	[StaticVariableRuleIgnore]
	public static readonly Dictionary<EDungeonSubType, string> inst2DamageView = new Dictionary<EDungeonSubType, string>
	{
		{
			EDungeonSubType.PinballBattle,
			"UiItem_DamageView_Sim_Prefab"
		}
	};
}
