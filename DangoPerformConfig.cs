using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;

// Token: 0x02001B16 RID: 6934
public class DangoPerformConfig
{
	// Token: 0x04005FAB RID: 24491
	public EDangoActionPerformType ActionType;

	// Token: 0x04005FAC RID: 24492
	public EDangoActionTargetType ActionTargetType;

	// Token: 0x04005FAD RID: 24493
	public EDangoActionPerformType RecursionActionType;

	// Token: 0x04005FAE RID: 24494
	public int Duration;

	// Token: 0x04005FAF RID: 24495
	[Nullable(1)]
	public List<DangoPerformEffectConfig> EffectConfigList = new List<DangoPerformEffectConfig>();
}
