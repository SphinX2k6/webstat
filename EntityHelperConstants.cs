using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x0200009A RID: 154
public static class EntityHelperConstants
{
	// Token: 0x040003B6 RID: 950
	[Nullable(1)]
	[StaticVariableRuleIgnore]
	public static readonly FName[] GlobalEntityTypeQueryName = new FName[]
	{
		"NormalEntity",
		"NormalEntityAlwaysTickGroup",
		"NormalEntityAlwaysTickWhitoutNotRenderedGroup",
		"MoveSceneItemEntity",
		"SimpleNpcEntity",
		"NormalNpcEntity",
		"CharacterEntity",
		"BossEntity",
		"PlayerAlwaysTickGroup"
	};
}
