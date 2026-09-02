using System;
using System.Runtime.CompilerServices;

// Token: 0x02001227 RID: 4647
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1,
	1
})]
public class RoleGroupTitleData : MultiTemplateGridDataBase<RoleGroupTitleData_Data, RoleGroupTitleItem>
{
	// Token: 0x06007BA6 RID: 31654 RVA: 0x002069F2 File Offset: 0x00204BF2
	public override int GetTemplateIndex()
	{
		return 0;
	}

	// Token: 0x06007BA7 RID: 31655 RVA: 0x002069F5 File Offset: 0x00204BF5
	public override RoleGroupTitleItem CreateProxy()
	{
		return new RoleGroupTitleItem();
	}
}
