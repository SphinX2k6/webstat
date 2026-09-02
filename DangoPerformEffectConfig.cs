using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using UnrealEngine;

// Token: 0x02001B15 RID: 6933
[NullableContext(1)]
[Nullable(0)]
public class DangoPerformEffectConfig
{
	// Token: 0x04005FA6 RID: 24486
	public string EffectPath = "";

	// Token: 0x04005FA7 RID: 24487
	public EDangoPerformLocationType PerformLocationType = EDangoPerformLocationType.当前团子位置;

	// Token: 0x04005FA8 RID: 24488
	public Vector LocationOffset = Vector.Create();

	// Token: 0x04005FA9 RID: 24489
	public FName? AttachSocket;

	// Token: 0x04005FAA RID: 24490
	public int DelayTime;
}
