using System;
using System.Runtime.CompilerServices;

// Token: 0x020018F4 RID: 6388
[NullableContext(1)]
[Nullable(0)]
public class EditFormationRoleFilter : RoleFilter
{
	// Token: 0x0600B76E RID: 46958 RVA: 0x0030CD73 File Offset: 0x0030AF73
	public override TDefaultFilter[] DefaultFilterList()
	{
		return new TDefaultFilter[]
		{
			new TDefaultFilter(this.IsEditFormation)
		};
	}

	// Token: 0x0600B76F RID: 46959 RVA: 0x0030CD8C File Offset: 0x0030AF8C
	private bool IsEditFormation(object data)
	{
		int dataId = ((RoleDataBase)data).GetDataId();
		return ModelBase<RoleSelectModel>.Instance.GetRoleIndex(dataId) > 0;
	}
}
