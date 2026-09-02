using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Audio;
using UnrealEngine;

// Token: 0x02000E74 RID: 3700
[NullableContext(1)]
public interface IEffectActorInfo
{
	// Token: 0x1700065B RID: 1627
	// (get) Token: 0x06005A04 RID: 23044
	// (set) Token: 0x06005A05 RID: 23045
	int ActorUid { get; set; }

	// Token: 0x1700065C RID: 1628
	// (get) Token: 0x06005A06 RID: 23046
	// (set) Token: 0x06005A07 RID: 23047
	AActor Actor { get; set; }

	// Token: 0x1700065D RID: 1629
	// (get) Token: 0x06005A08 RID: 23048
	// (set) Token: 0x06005A09 RID: 23049
	UAkComponent AkComponent { get; set; }

	// Token: 0x1700065E RID: 1630
	// (get) Token: 0x06005A0A RID: 23050
	// (set) Token: 0x06005A0B RID: 23051
	TArray<FVector> Locations { get; set; }

	// Token: 0x1700065F RID: 1631
	// (get) Token: 0x06005A0C RID: 23052
	// (set) Token: 0x06005A0D RID: 23053
	HashSet<int> EffectUidList { get; set; }

	// Token: 0x17000660 RID: 1632
	// (get) Token: 0x06005A0E RID: 23054
	// (set) Token: 0x06005A0F RID: 23055
	int AudioHandle { get; set; }

	// Token: 0x17000661 RID: 1633
	// (get) Token: 0x06005A10 RID: 23056
	// (set) Token: 0x06005A11 RID: 23057
	IAudioInfo EffectModel { get; set; }

	// Token: 0x17000662 RID: 1634
	// (get) Token: 0x06005A12 RID: 23058
	// (set) Token: 0x06005A13 RID: 23059
	ERoleAudioPriorityType? Priority { get; set; }
}
