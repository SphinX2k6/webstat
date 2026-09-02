using System;
using System.Runtime.CompilerServices;

// Token: 0x02002ED3 RID: 11987
[NullableContext(1)]
[Nullable(0)]
public class SkillOperationRecord
{
	// Token: 0x060189F2 RID: 100850 RVA: 0x006F03D9 File Offset: 0x006EE5D9
	public SkillOperationRecord(string name)
	{
		this.Name = name;
	}

	// Token: 0x060189F3 RID: 100851 RVA: 0x006F03E8 File Offset: 0x006EE5E8
	public void AddOptCountAndTime(int time, int count = 1)
	{
		this.TotalTime += time;
		this.TotalCount += count;
	}

	// Token: 0x060189F4 RID: 100852 RVA: 0x006F0406 File Offset: 0x006EE606
	public override string ToString()
	{
		return StringUtils.Format(SkillOperationRecord.SKILL_RECORD_FMT, new string[]
		{
			this.Name,
			this.TotalTime.ToString(),
			this.TotalCount.ToString()
		});
	}

	// Token: 0x0400BE93 RID: 48787
	private static readonly string SKILL_RECORD_FMT = "{0},{1},{2}";

	// Token: 0x0400BE94 RID: 48788
	private readonly string Name;

	// Token: 0x0400BE95 RID: 48789
	private int TotalTime;

	// Token: 0x0400BE96 RID: 48790
	private int TotalCount;
}
