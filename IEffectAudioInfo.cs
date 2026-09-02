using System;
using System.Runtime.CompilerServices;

// Token: 0x02000E76 RID: 3702
[NullableContext(2)]
public interface IEffectAudioInfo
{
	// Token: 0x1700066B RID: 1643
	// (get) Token: 0x06005A25 RID: 23077
	// (set) Token: 0x06005A26 RID: 23078
	int ActorUid { get; set; }

	// Token: 0x1700066C RID: 1644
	// (get) Token: 0x06005A27 RID: 23079
	// (set) Token: 0x06005A28 RID: 23080
	object EffectActor { get; set; }

	// Token: 0x1700066D RID: 1645
	// (get) Token: 0x06005A29 RID: 23081
	// (set) Token: 0x06005A2A RID: 23082
	bool? IsTransform { get; set; }

	// Token: 0x1700066E RID: 1646
	// (get) Token: 0x06005A2B RID: 23083
	// (set) Token: 0x06005A2C RID: 23084
	Action Callback { get; set; }
}
