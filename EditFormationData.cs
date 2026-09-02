using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.RoleUi;

// Token: 0x02001B42 RID: 6978
[NullableContext(1)]
[Nullable(0)]
public class EditFormationData
{
	// Token: 0x0600C9BB RID: 51643 RVA: 0x0035999F File Offset: 0x00357B9F
	public EditFormationData(int formationId)
	{
		this.FormationId = formationId;
	}

	// Token: 0x0600C9BC RID: 51644 RVA: 0x003599C4 File Offset: 0x00357BC4
	public void AddRoleData(int roleId, int skinId, int level, int playerId, bool isCurrent = false, int multiSkillBranchIndex = 0)
	{
		int num = this.RoleIdList.Count + 1;
		this.RoleIdList.Add(roleId);
		EditFormationRoleData value = new EditFormationRoleData(num, roleId, skinId, level, playerId, multiSkillBranchIndex);
		this.RoleDataMap[num] = value;
		if (isCurrent)
		{
			this.CurrentPosition = num;
		}
	}

	// Token: 0x0600C9BD RID: 51645 RVA: 0x00359A11 File Offset: 0x00357C11
	[NullableContext(2)]
	public EditFormationRoleData GetRoleDataByPosition(int position)
	{
		if (this.RoleDataMap.ContainsKey(position))
		{
			return this.RoleDataMap[position];
		}
		return null;
	}

	// Token: 0x0600C9BE RID: 51646 RVA: 0x00359A30 File Offset: 0x00357C30
	[NullableContext(2)]
	public EditFormationRoleData GetRoleDataById(int roleId)
	{
		foreach (EditFormationRoleData editFormationRoleData in this.RoleDataMap.Values)
		{
			if (editFormationRoleData.ConfigId == roleId)
			{
				return editFormationRoleData;
			}
		}
		return null;
	}

	// Token: 0x0600C9BF RID: 51647 RVA: 0x00359A94 File Offset: 0x00357C94
	public List<int> GetRoleIdListWithTrial(bool includeTrial)
	{
		List<int> list = new List<int>();
		foreach (int item in this.RoleIdList)
		{
			list.Add(item);
		}
		if (includeTrial)
		{
			return list;
		}
		List<int> list2 = new List<int>();
		for (int i = 0; i < list.Count; i++)
		{
			if (!RoleUtils.IsTrialRole(list[i]))
			{
				list2.Add(list[i]);
			}
		}
		return list2;
	}

	// Token: 0x1700103B RID: 4155
	// (get) Token: 0x0600C9C0 RID: 51648 RVA: 0x00359B2C File Offset: 0x00357D2C
	public int[] GetRoleIdList
	{
		get
		{
			return this.RoleIdList.ToArray();
		}
	}

	// Token: 0x1700103C RID: 4156
	// (get) Token: 0x0600C9C1 RID: 51649 RVA: 0x00359B39 File Offset: 0x00357D39
	public List<int> RoleIds
	{
		get
		{
			return this.RoleIdList;
		}
	}

	// Token: 0x0600C9C2 RID: 51650 RVA: 0x00359B44 File Offset: 0x00357D44
	public void SetCurrentRole(int roleId)
	{
		foreach (EditFormationRoleData editFormationRoleData in this.RoleDataMap.Values)
		{
			if (editFormationRoleData.ConfigId == roleId)
			{
				this.CurrentPosition = editFormationRoleData.Position;
			}
		}
	}

	// Token: 0x0600C9C3 RID: 51651 RVA: 0x00359BAC File Offset: 0x00357DAC
	public Dictionary<int, EditFormationRoleData> GetRoleDataMap()
	{
		return this.RoleDataMap;
	}

	// Token: 0x0600C9C4 RID: 51652 RVA: 0x00359BB4 File Offset: 0x00357DB4
	public Dictionary<int, EditFormationRoleData> GetRoleDataMapWithTrial(bool includeTrial)
	{
		if (includeTrial)
		{
			return this.GetRoleDataMap();
		}
		Dictionary<int, EditFormationRoleData> dictionary = new Dictionary<int, EditFormationRoleData>();
		foreach (KeyValuePair<int, EditFormationRoleData> keyValuePair in this.GetRoleDataMap())
		{
			if (!RoleUtils.IsTrialRole(keyValuePair.Value.ConfigId))
			{
				dictionary.Add(keyValuePair.Key, keyValuePair.Value);
			}
		}
		return dictionary;
	}

	// Token: 0x1700103D RID: 4157
	// (get) Token: 0x0600C9C5 RID: 51653 RVA: 0x00359C38 File Offset: 0x00357E38
	public int GetCurrentRoleConfigId
	{
		get
		{
			int index = this.CurrentPosition - 1;
			return this.RoleIdList[index];
		}
	}

	// Token: 0x1700103E RID: 4158
	// (get) Token: 0x0600C9C6 RID: 51654 RVA: 0x00359C5A File Offset: 0x00357E5A
	public int GetCurrentRolePosition
	{
		get
		{
			return this.CurrentPosition;
		}
	}

	// Token: 0x04006085 RID: 24709
	public readonly int FormationId;

	// Token: 0x04006086 RID: 24710
	private int CurrentPosition;

	// Token: 0x04006087 RID: 24711
	private readonly List<int> RoleIdList = new List<int>();

	// Token: 0x04006088 RID: 24712
	private readonly Dictionary<int, EditFormationRoleData> RoleDataMap = new Dictionary<int, EditFormationRoleData>();
}
