using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02002D59 RID: 11609
[NullableContext(2)]
public interface IWeeklyRogueRoleGroupInfo
{
	// Token: 0x17001ED1 RID: 7889
	// (get) Token: 0x060176FC RID: 95996
	// (set) Token: 0x060176FD RID: 95997
	bool IsTitleType { get; set; }

	// Token: 0x17001ED2 RID: 7890
	// (get) Token: 0x060176FE RID: 95998
	// (set) Token: 0x060176FF RID: 95999
	IWeeklyRogueRoleGroupTitleInfo TitleInfo { get; set; }

	// Token: 0x17001ED3 RID: 7891
	// (get) Token: 0x06017700 RID: 96000
	// (set) Token: 0x06017701 RID: 96001
	[Nullable(new byte[]
	{
		2,
		1
	})]
	List<RoleDataBase> DataList { [return: Nullable(new byte[]
	{
		2,
		1
	})] get; [param: Nullable(new byte[]
	{
		2,
		1
	})] set; }
}
