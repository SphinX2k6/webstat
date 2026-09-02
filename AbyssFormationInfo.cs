using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x02001ABD RID: 6845
[NullableContext(1)]
[Nullable(0)]
public class AbyssFormationInfo
{
	// Token: 0x0600C496 RID: 50326 RVA: 0x0033E0C8 File Offset: 0x0033C2C8
	public void Phrase(AbyssRoleSelectUpdateNotify data)
	{
		this.RoleInfoList = Array.Empty<AbyssFormationRoleSelectInfo>();
		List<AbyssFormationRoleSelectInfo> list = new List<AbyssFormationRoleSelectInfo>();
		int count = data.PlayerInfos.Count;
		for (int i = 0; i < count; i++)
		{
			AbyssFormationRoleSelectInfo abyssFormationRoleSelectInfo = new AbyssFormationRoleSelectInfo();
			abyssFormationRoleSelectInfo.Phrase(data.PlayerInfos[i]);
			list.Add(abyssFormationRoleSelectInfo);
		}
		this.RoleInfoList = list.ToArray();
	}

	// Token: 0x04005E49 RID: 24137
	private AbyssFormationRoleSelectInfo[] RoleInfoList = Array.Empty<AbyssFormationRoleSelectInfo>();
}
