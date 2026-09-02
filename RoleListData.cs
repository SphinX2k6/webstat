using System;
using System.Runtime.CompilerServices;

// Token: 0x02001229 RID: 4649
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1,
	1
})]
public class RoleListData : MultiTemplateGridDataBase<BabelTowerRoleListItemData, BabelTowerRoleListItem>
{
	// Token: 0x06007BAF RID: 31663 RVA: 0x00206EBF File Offset: 0x002050BF
	public override int GetTemplateIndex()
	{
		return 1;
	}

	// Token: 0x06007BB0 RID: 31664 RVA: 0x00206EC2 File Offset: 0x002050C2
	public override BabelTowerRoleListItem CreateProxy()
	{
		return new BabelTowerRoleListItem();
	}
}
