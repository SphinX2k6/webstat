using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x02001ABE RID: 6846
[NullableContext(1)]
[Nullable(0)]
public class AbyssFormationRoleSelectInfo
{
	// Token: 0x0600C498 RID: 50328 RVA: 0x0033E13C File Offset: 0x0033C33C
	public int GetPlayerId()
	{
		return this.PlayerId;
	}

	// Token: 0x0600C499 RID: 50329 RVA: 0x0033E144 File Offset: 0x0033C344
	public AbyssFormationRoleSelectDetailInfo[] GetRoleSelectDetailInfoList()
	{
		return this.RoleSelectDetailInfoList;
	}

	// Token: 0x0600C49A RID: 50330 RVA: 0x0033E14C File Offset: 0x0033C34C
	public void Phrase(AbyssRoleSelectInfo data)
	{
		this.PlayerId = data.PlayerId;
		this.RoleSelectDetailInfoList = Array.Empty<AbyssFormationRoleSelectDetailInfo>();
		List<AbyssFormationRoleSelectDetailInfo> list = new List<AbyssFormationRoleSelectDetailInfo>();
		int count = data.RoleInfos.Count;
		for (int i = 0; i < count; i++)
		{
			AbyssFormationRoleSelectDetailInfo abyssFormationRoleSelectDetailInfo = new AbyssFormationRoleSelectDetailInfo();
			abyssFormationRoleSelectDetailInfo.Phrase(data.RoleInfos[i]);
			list.Add(abyssFormationRoleSelectDetailInfo);
		}
		this.RoleSelectDetailInfoList = list.ToArray();
	}

	// Token: 0x04005E4A RID: 24138
	private int PlayerId;

	// Token: 0x04005E4B RID: 24139
	private AbyssFormationRoleSelectDetailInfo[] RoleSelectDetailInfoList = Array.Empty<AbyssFormationRoleSelectDetailInfo>();
}
