using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Audio;

// Token: 0x02000E78 RID: 3704
[NullableContext(1)]
public interface IPendingEffectInfo
{
	// Token: 0x17000673 RID: 1651
	// (get) Token: 0x06005A36 RID: 23094
	// (set) Token: 0x06005A37 RID: 23095
	IAudioInfo EffectModel { get; set; }

	// Token: 0x17000674 RID: 1652
	// (get) Token: 0x06005A38 RID: 23096
	// (set) Token: 0x06005A39 RID: 23097
	ERoleAudioPriorityType? Priority { get; set; }
}
