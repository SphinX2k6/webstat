using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

// Token: 0x02002E69 RID: 11881
[NullableContext(2)]
[Nullable(0)]
public struct GameplayCueParam
{
	// Token: 0x0400BB96 RID: 48022
	public IActiveBuff Buff;

	// Token: 0x0400BB97 RID: 48023
	public Action BeginCallback;

	// Token: 0x0400BB98 RID: 48024
	public Action EndCallback;

	// Token: 0x0400BB99 RID: 48025
	public bool? Sync;

	// Token: 0x0400BB9A RID: 48026
	public EntityHandle Instigator;

	// Token: 0x0400BB9B RID: 48027
	public bool Instant;

	// Token: 0x0400BB9C RID: 48028
	public string SocketNameOverride;

	// Token: 0x0400BB9D RID: 48029
	public FVector? RelativePositionOverride;

	// Token: 0x0400BB9E RID: 48030
	public FVector? RelativeRotationOverride;

	// Token: 0x0400BB9F RID: 48031
	public FVector? ScaleOverride;

	// Token: 0x0400BBA0 RID: 48032
	public GameplayCue CueConfig;

	// Token: 0x0400BBA1 RID: 48033
	[Nullable(1)]
	public EntityHandle EntityHandle;

	// Token: 0x0400BBA2 RID: 48034
	[Nullable(1)]
	public BaseGameplayCueComponent CueComp;
}
