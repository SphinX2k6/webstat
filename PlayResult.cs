using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x0200001C RID: 28
[NullableContext(1)]
[Nullable(0)]
public class PlayResult
{
	// Token: 0x06000057 RID: 87 RVA: 0x00003CE4 File Offset: 0x00001EE4
	public void Reset()
	{
		this.PlayingIds.Clear();
		this.CallbackIds.Clear();
	}

	// Token: 0x06000058 RID: 88 RVA: 0x00003CFC File Offset: 0x00001EFC
	public void AddPlayingId(int id)
	{
		if (id != 0 && !this.PlayingIds.Contains(id))
		{
			this.PlayingIds.Add(id);
		}
	}

	// Token: 0x06000059 RID: 89 RVA: 0x00003D1B File Offset: 0x00001F1B
	public void AddCallbackId(int id)
	{
		if (id != 0 && !this.CallbackIds.Contains(id))
		{
			this.CallbackIds.Add(id);
		}
	}

	// Token: 0x0600005A RID: 90 RVA: 0x00003D3C File Offset: 0x00001F3C
	public void RemoveCallbackId(int id)
	{
		int num = this.CallbackIds.IndexOf(id);
		if (num > -1)
		{
			this.CallbackIds.RemoveAt(num);
		}
	}

	// Token: 0x04000044 RID: 68
	public string EventPath = "";

	// Token: 0x04000045 RID: 69
	public List<int> PlayingIds = new List<int>();

	// Token: 0x04000046 RID: 70
	public List<int> CallbackIds = new List<int>();
}
