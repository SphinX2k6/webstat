using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02002793 RID: 10131
[NullableContext(1)]
[Nullable(0)]
public class MultiTeamRoleData
{
	// Token: 0x06013FE1 RID: 81889 RVA: 0x0059217E File Offset: 0x0059037E
	public string GetTitle()
	{
		return this.Title;
	}

	// Token: 0x06013FE2 RID: 81890 RVA: 0x00592188 File Offset: 0x00590388
	public List<RoleDataBase> GetSourceRoleList()
	{
		List<RoleDataBase> list = new List<RoleDataBase>();
		foreach (MultiTeamRoleGridData multiTeamRoleGridData in this.MultiTeamRoleGridDataList)
		{
			RoleDataBase role = multiTeamRoleGridData.GetRole();
			if (role != null)
			{
				list.Add(role);
			}
		}
		return list;
	}

	// Token: 0x06013FE3 RID: 81891 RVA: 0x005921EC File Offset: 0x005903EC
	public void SetSortedRoleList([Nullable(new byte[]
	{
		2,
		1
	})] List<RoleDataBase> roleList)
	{
		if (roleList == null)
		{
			this.SortedTeamRoleList = new List<MultiTeamRoleGridData>();
			foreach (MultiTeamRoleGridData multiTeamRoleGridData in this.MultiTeamRoleGridDataList)
			{
				if (multiTeamRoleGridData.GetRole() != null)
				{
					this.SortedTeamRoleList.Add(multiTeamRoleGridData);
				}
			}
			return;
		}
		this.SortedRoleList = roleList;
		this.SortedTeamRoleList = new List<MultiTeamRoleGridData>();
		foreach (MultiTeamRoleGridData multiTeamRoleGridData2 in this.MultiTeamRoleGridDataList)
		{
			RoleDataBase role = multiTeamRoleGridData2.GetRole();
			if (role != null && this.SortedRoleList.Contains(role))
			{
				this.SortedTeamRoleList.Add(multiTeamRoleGridData2);
			}
		}
		this.SortedTeamRoleList.Sort(delegate(MultiTeamRoleGridData a, MultiTeamRoleGridData b)
		{
			RoleDataBase role2 = a.GetRole();
			RoleDataBase role3 = b.GetRole();
			if (role2 == null || role3 == null)
			{
				return 0;
			}
			return this.SortedRoleList.IndexOf(role2) - this.SortedRoleList.IndexOf(role3);
		});
	}

	// Token: 0x06013FE4 RID: 81892 RVA: 0x005922E4 File Offset: 0x005904E4
	public List<MultiTeamRoleGridData> GetShowMultiTeamRoleGridDataList()
	{
		return this.SortedTeamRoleList;
	}

	// Token: 0x06013FE5 RID: 81893 RVA: 0x005922EC File Offset: 0x005904EC
	public static MultiTeamRoleData Phrase(string title, List<MultiTeamRoleGridData> roleList)
	{
		MultiTeamRoleData multiTeamRoleData = new MultiTeamRoleData();
		multiTeamRoleData.Title = title;
		multiTeamRoleData.MultiTeamRoleGridDataList = roleList;
		multiTeamRoleData.SetSortedRoleList(null);
		return multiTeamRoleData;
	}

	// Token: 0x04009BAB RID: 39851
	private string Title = "";

	// Token: 0x04009BAC RID: 39852
	private List<MultiTeamRoleGridData> MultiTeamRoleGridDataList = new List<MultiTeamRoleGridData>();

	// Token: 0x04009BAD RID: 39853
	private List<MultiTeamRoleGridData> SortedTeamRoleList = new List<MultiTeamRoleGridData>();

	// Token: 0x04009BAE RID: 39854
	private List<RoleDataBase> SortedRoleList = new List<RoleDataBase>();
}
