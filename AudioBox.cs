using System;
using System.Runtime.CompilerServices;

// Token: 0x0200002B RID: 43
public class AudioBox
{
	// Token: 0x060000B5 RID: 181 RVA: 0x00005F0C File Offset: 0x0000410C
	[NullableContext(1)]
	public static int Compare(AudioBox a, AudioBox b)
	{
		int num = b.Priority - a.Priority;
		if (num == 0)
		{
			num--;
		}
		return num;
	}

	// Token: 0x060000B6 RID: 182 RVA: 0x00005F2F File Offset: 0x0000412F
	public AudioBox(int priority, int pbDataId, EAudioBoxType boxType)
	{
		this.Priority = priority;
		this.PbDataId = pbDataId;
		this.BoxType = boxType;
	}

	// Token: 0x0400008C RID: 140
	public int Priority;

	// Token: 0x0400008D RID: 141
	public int PbDataId;

	// Token: 0x0400008E RID: 142
	public EAudioBoxType BoxType;
}
