using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02002805 RID: 10245
[NullableContext(1)]
[Nullable(0)]
public class ForecastRoleDevPhantomData : RoleDevPhantomViewItemDataBase
{
	// Token: 0x06014395 RID: 82837 RVA: 0x005A1E21 File Offset: 0x005A0021
	protected override void InitByRoleType(int roleId)
	{
		this.RefreshSuitDataList();
	}

	// Token: 0x06014396 RID: 82838 RVA: 0x005A1E29 File Offset: 0x005A0029
	protected override List<RoleDevPhantomSuitItemData> GetSuitDataList()
	{
		return this.SuitDataListInternal;
	}

	// Token: 0x06014397 RID: 82839 RVA: 0x005A1E31 File Offset: 0x005A0031
	public override void RefreshSuitDataList()
	{
		this.SuitDataListInternal.Clear();
	}

	// Token: 0x04009D69 RID: 40297
	private List<RoleDevPhantomSuitItemData> SuitDataListInternal = new List<RoleDevPhantomSuitItemData>();
}
