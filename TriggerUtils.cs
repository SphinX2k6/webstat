using System;
using System.Runtime.CompilerServices;

// Token: 0x02002FC4 RID: 12228
public static class TriggerUtils
{
	// Token: 0x06018EE2 RID: 102114 RVA: 0x007102BC File Offset: 0x0070E4BC
	[NullableContext(2)]
	public static object GetTarget(Entity owner, ETriggerTargetType targetType)
	{
		switch (targetType)
		{
		case ETriggerTargetType.Self:
			return owner;
		case ETriggerTargetType.LocalFormation:
			return SceneTeam.Local;
		case ETriggerTargetType.AllFormation:
			return SceneTeam.All;
		case ETriggerTargetType.Enemy:
			return null;
		default:
			return null;
		}
	}
}
