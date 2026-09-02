using System;
using System.Runtime.CompilerServices;

// Token: 0x02001E56 RID: 7766
[NullableContext(1)]
[Nullable(0)]
public class HandBookEntry
{
	// Token: 0x0600E61E RID: 58910 RVA: 0x003E1E61 File Offset: 0x003E0061
	public HandBookEntry(int id, string createTime, int num, bool isRead, uint createTimeStampSecond)
	{
		this.Id = id;
		this.CreateTime = createTime;
		this.Num = num;
		this.IsRead = isRead;
		this.CreateTimeStampSecond = createTimeStampSecond;
	}

	// Token: 0x04006EC4 RID: 28356
	public int Id;

	// Token: 0x04006EC5 RID: 28357
	public string CreateTime;

	// Token: 0x04006EC6 RID: 28358
	public uint CreateTimeStampSecond;

	// Token: 0x04006EC7 RID: 28359
	public int Num;

	// Token: 0x04006EC8 RID: 28360
	public bool IsRead;
}
