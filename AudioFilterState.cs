using System;
using System.Runtime.CompilerServices;

// Token: 0x02000027 RID: 39
[NullableContext(1)]
[Nullable(0)]
public class AudioFilterState : IFilterState
{
	// Token: 0x17000007 RID: 7
	// (get) Token: 0x060000A5 RID: 165 RVA: 0x00005B3B File Offset: 0x00003D3B
	// (set) Token: 0x060000A6 RID: 166 RVA: 0x00005B43 File Offset: 0x00003D43
	public string State { get; set; } = "none";

	// Token: 0x060000A7 RID: 167 RVA: 0x00005B4C File Offset: 0x00003D4C
	public AudioFilterState(int uid, string state, int? priority = null)
	{
		this.Uid = uid;
		this.State = state;
		this.Priority = priority.GetValueOrDefault();
	}

	// Token: 0x060000A8 RID: 168 RVA: 0x00005B7C File Offset: 0x00003D7C
	public static int Compare(AudioFilterState a, AudioFilterState b)
	{
		int num = b.Priority - a.Priority;
		if (num != 0)
		{
			return num;
		}
		return b.Uid - a.Uid;
	}

	// Token: 0x0400007D RID: 125
	public int Priority;

	// Token: 0x0400007E RID: 126
	public int Uid;
}
