using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Audio;

// Token: 0x02000E79 RID: 3705
[NullableContext(1)]
[Nullable(0)]
public class PendingEffectInfo : IPendingEffectInfo
{
	// Token: 0x17000675 RID: 1653
	// (get) Token: 0x06005A3A RID: 23098 RVA: 0x00161064 File Offset: 0x0015F264
	// (set) Token: 0x06005A3B RID: 23099 RVA: 0x0016106C File Offset: 0x0015F26C
	public IAudioInfo EffectModel { get; set; }

	// Token: 0x17000676 RID: 1654
	// (get) Token: 0x06005A3C RID: 23100 RVA: 0x00161075 File Offset: 0x0015F275
	// (set) Token: 0x06005A3D RID: 23101 RVA: 0x0016107D File Offset: 0x0015F27D
	public ERoleAudioPriorityType? Priority { get; set; }
}
