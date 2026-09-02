using System;
using System.Runtime.CompilerServices;

// Token: 0x02000E77 RID: 3703
[NullableContext(2)]
[Nullable(0)]
public class EffectAudioInfo : IEffectAudioInfo
{
	// Token: 0x1700066F RID: 1647
	// (get) Token: 0x06005A2D RID: 23085 RVA: 0x00161018 File Offset: 0x0015F218
	// (set) Token: 0x06005A2E RID: 23086 RVA: 0x00161020 File Offset: 0x0015F220
	public int ActorUid { get; set; }

	// Token: 0x17000670 RID: 1648
	// (get) Token: 0x06005A2F RID: 23087 RVA: 0x00161029 File Offset: 0x0015F229
	// (set) Token: 0x06005A30 RID: 23088 RVA: 0x00161031 File Offset: 0x0015F231
	public object EffectActor { get; set; }

	// Token: 0x17000671 RID: 1649
	// (get) Token: 0x06005A31 RID: 23089 RVA: 0x0016103A File Offset: 0x0015F23A
	// (set) Token: 0x06005A32 RID: 23090 RVA: 0x00161042 File Offset: 0x0015F242
	public bool? IsTransform { get; set; }

	// Token: 0x17000672 RID: 1650
	// (get) Token: 0x06005A33 RID: 23091 RVA: 0x0016104B File Offset: 0x0015F24B
	// (set) Token: 0x06005A34 RID: 23092 RVA: 0x00161053 File Offset: 0x0015F253
	public Action Callback { get; set; }
}
