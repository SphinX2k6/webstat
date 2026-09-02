using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02002D5A RID: 11610
[NullableContext(2)]
[Nullable(0)]
public class WeeklyRogueRoleGroupInfo : IWeeklyRogueRoleGroupInfo
{
	// Token: 0x17001ED4 RID: 7892
	// (get) Token: 0x06017702 RID: 96002 RVA: 0x006800E8 File Offset: 0x0067E2E8
	// (set) Token: 0x06017703 RID: 96003 RVA: 0x006800F0 File Offset: 0x0067E2F0
	public bool IsTitleType { get; set; }

	// Token: 0x17001ED5 RID: 7893
	// (get) Token: 0x06017704 RID: 96004 RVA: 0x006800F9 File Offset: 0x0067E2F9
	// (set) Token: 0x06017705 RID: 96005 RVA: 0x00680101 File Offset: 0x0067E301
	public IWeeklyRogueRoleGroupTitleInfo TitleInfo { get; set; }

	// Token: 0x17001ED6 RID: 7894
	// (get) Token: 0x06017706 RID: 96006 RVA: 0x0068010A File Offset: 0x0067E30A
	// (set) Token: 0x06017707 RID: 96007 RVA: 0x00680112 File Offset: 0x0067E312
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public List<RoleDataBase> DataList { [return: Nullable(new byte[]
	{
		2,
		1
	})] get; [param: Nullable(new byte[]
	{
		2,
		1
	})] set; }
}
