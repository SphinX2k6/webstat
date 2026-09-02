using System;
using System.Runtime.CompilerServices;

// Token: 0x020027B8 RID: 10168
[NullableContext(1)]
[Nullable(0)]
public class RoleAnimAudioData
{
	// Token: 0x060141B1 RID: 82353 RVA: 0x0059DCB8 File Offset: 0x0059BEB8
	public RoleAnimAudioData(bool canInterrupt, string audioPath)
	{
		this.CanInterrupt = canInterrupt;
		this.AudioPath = audioPath;
	}

	// Token: 0x04009C6B RID: 40043
	public readonly bool CanInterrupt;

	// Token: 0x04009C6C RID: 40044
	public readonly string AudioPath;
}
