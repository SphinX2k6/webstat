using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02002799 RID: 10137
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class RoleSelectModel : ModelBase<RoleSelectModel>
{
	// Token: 0x0601402B RID: 81963 RVA: 0x00594968 File Offset: 0x00592B68
	public int GetRoleIndex(int roleConfigId)
	{
		foreach (KeyValuePair<int, RoleDataBase> keyValuePair in this.RoleIndexMap)
		{
			if (keyValuePair.Value.GetDataId() == roleConfigId)
			{
				return keyValuePair.Key;
			}
		}
		return 0;
	}

	// Token: 0x0601402C RID: 81964 RVA: 0x005949D0 File Offset: 0x00592BD0
	public void ClearData()
	{
		this.SelectedRoleSet.Clear();
		this.RoleIndexMap.Clear();
	}

	// Token: 0x04009BE5 RID: 39909
	public readonly HashSet<int> SelectedRoleSet = new HashSet<int>();

	// Token: 0x04009BE6 RID: 39910
	public readonly Dictionary<int, RoleDataBase> RoleIndexMap = new Dictionary<int, RoleDataBase>();
}
