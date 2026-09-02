using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Module.RoleUi;

// Token: 0x02001B46 RID: 6982
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class EditFormationModel : ModelBase<EditFormationModel>
{
	// Token: 0x0600C9C9 RID: 51657 RVA: 0x00359D0C File Offset: 0x00357F0C
	public void UpdatePlayerFormations(IList<PlayerFightFormations> playerFormations)
	{
		this.FormationDataMap.Clear();
		int num = 0;
		Dictionary<int, List<ValueTuple<Aki.Protocol.FormationRoleInfo, int, bool>>> dictionary = new Dictionary<int, List<ValueTuple<Aki.Protocol.FormationRoleInfo, int, bool>>>();
		foreach (PlayerFightFormations playerFightFormations in playerFormations)
		{
			int playerId = playerFightFormations.PlayerId;
			int num2 = playerId;
			int? id = ModelBase<PlayerInfoModel>.Instance.GetId();
			bool flag = num2 == id.GetValueOrDefault() & id != null;
			foreach (FightFormationNotifyInfo fightFormationNotifyInfo in playerFightFormations.Formations)
			{
				int formationId = fightFormationNotifyInfo.FormationId;
				if (flag || formationId <= 0)
				{
					if (flag && fightFormationNotifyInfo.IsCurrent)
					{
						num = formationId;
					}
					if (!dictionary.ContainsKey(formationId))
					{
						dictionary[formationId] = new List<ValueTuple<Aki.Protocol.FormationRoleInfo, int, bool>>();
					}
					List<ValueTuple<Aki.Protocol.FormationRoleInfo, int, bool>> list = dictionary[formationId];
					foreach (Aki.Protocol.FormationRoleInfo formationRoleInfo in fightFormationNotifyInfo.RoleInfos)
					{
						bool item = flag && formationRoleInfo.RoleId == fightFormationNotifyInfo.CurRole;
						list.Add(new ValueTuple<Aki.Protocol.FormationRoleInfo, int, bool>(formationRoleInfo, playerId, item));
					}
				}
			}
		}
		foreach (KeyValuePair<int, List<ValueTuple<Aki.Protocol.FormationRoleInfo, int, bool>>> keyValuePair in dictionary)
		{
			int key = keyValuePair.Key;
			EditFormationData editFormationData = new EditFormationData(key);
			this.FormationDataMap[key] = editFormationData;
			foreach (ValueTuple<Aki.Protocol.FormationRoleInfo, int, bool> valueTuple in keyValuePair.Value)
			{
				Aki.Protocol.FormationRoleInfo item2 = valueTuple.Item1;
				int item3 = valueTuple.Item2;
				bool item4 = valueTuple.Item3;
				editFormationData.AddRoleData(item2.RoleId, item2.RoleSkinId, item2.Level, item3, item4, item2.SkillBranchId);
			}
			if (key == num)
			{
				this.CurrentFormationData = editFormationData;
			}
		}
	}

	// Token: 0x0600C9CA RID: 51658 RVA: 0x00359F9C File Offset: 0x0035819C
	public void ChangeEditedMainRole()
	{
		RoleModel instance = ModelBase<RoleModel>.Instance;
		foreach (EditingRoleData[] array in this.EditingFormationMap.Values)
		{
			foreach (EditingRoleData editingRoleData in array)
			{
				int roleId = editingRoleData.RoleId;
				if (instance.IsMainRole(roleId))
				{
					int? newMainRoleId = instance.GetNewMainRoleId(roleId);
					if (newMainRoleId != null)
					{
						int num = roleId;
						int? num2 = newMainRoleId;
						if (!(num == num2.GetValueOrDefault() & num2 != null))
						{
							editingRoleData.RoleId = newMainRoleId.Value;
						}
					}
				}
			}
		}
	}

	// Token: 0x0600C9CB RID: 51659 RVA: 0x0035A054 File Offset: 0x00358254
	public void InitEditingFormationMap()
	{
		this.EditingFormationMap.Clear();
		foreach (EditFormationData editFormationData in this.FormationDataMap.Values)
		{
			int formationId = editFormationData.FormationId;
			foreach (EditFormationRoleData editFormationRoleData in editFormationData.GetRoleDataMap().Values)
			{
				this.SetEditingRoleId(formationId, editFormationRoleData.Position, editFormationRoleData.ConfigId, true);
			}
		}
	}

	// Token: 0x0600C9CC RID: 51660 RVA: 0x0035A10C File Offset: 0x0035830C
	public bool IsRoleDead(int roleConfigId)
	{
		SceneTeamItem teamItem = ModelBase<SceneTeamModel>.Instance.GetTeamItem((long)roleConfigId, new GetTeamItemOptions
		{
			ParamType = ETeamParamType.ConfigId,
			OnlyMyRole = new bool?(true)
		});
		if (teamItem != null)
		{
			return teamItem.IsDead();
		}
		RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(roleConfigId, true);
		return roleDataById == null || roleDataById.GetAttributeData().GetAttrValueById(3) <= 0;
	}

	// Token: 0x0600C9CD RID: 51661 RVA: 0x0035A16C File Offset: 0x0035836C
	public bool SetEditingRoleId(int editFormationId, int editPosition, int roleId = 0, bool fillEmpty = true)
	{
		if (editPosition > 3 || editPosition <= 0)
		{
			return false;
		}
		if (!this.IsMyPosition(editPosition))
		{
			return false;
		}
		if (!this.EditingFormationMap.ContainsKey(editFormationId))
		{
			EditingRoleData[] array = new EditingRoleData[3];
			this.EditingFormationMap[editFormationId] = array;
			for (int i = 1; i <= 3; i++)
			{
				array[i - 1] = new EditingRoleData(i);
			}
		}
		EditingRoleData[] array2 = this.EditingFormationMap[editFormationId];
		List<int> list = new List<int>();
		foreach (EditingRoleData editingRoleData in array2)
		{
			if (editingRoleData.Position == editPosition)
			{
				editingRoleData.RoleId = roleId;
			}
			int roleId2 = editingRoleData.RoleId;
			if (roleId2 != 0)
			{
				list.Add(roleId2);
			}
		}
		if (ModelBase<GameModeModel>.Instance.IsMulti || !fillEmpty)
		{
			return true;
		}
		foreach (EditingRoleData editingRoleData2 in array2)
		{
			int num = editingRoleData2.Position - 1;
			if (num < list.Count)
			{
				editingRoleData2.RoleId = list[num];
			}
			else
			{
				editingRoleData2.RoleId = 0;
			}
		}
		return true;
	}

	// Token: 0x0600C9CE RID: 51662 RVA: 0x0035A27C File Offset: 0x0035847C
	public int GetEditingRoleId(int editFormationId, int position)
	{
		if (this.EditingFormationMap.ContainsKey(editFormationId))
		{
			foreach (EditingRoleData editingRoleData in this.EditingFormationMap[editFormationId])
			{
				if (editingRoleData.Position == position)
				{
					return editingRoleData.RoleId;
				}
			}
		}
		return 0;
	}

	// Token: 0x0600C9CF RID: 51663 RVA: 0x0035A2C8 File Offset: 0x003584C8
	public int GetEditingRolePosition(int editFormationId, int roleConfigId)
	{
		if (this.EditingFormationMap.ContainsKey(editFormationId))
		{
			foreach (EditingRoleData editingRoleData in this.EditingFormationMap[editFormationId])
			{
				if (editingRoleData.RoleId == roleConfigId)
				{
					return editingRoleData.Position;
				}
			}
		}
		return -1;
	}

	// Token: 0x0600C9D0 RID: 51664 RVA: 0x0035A314 File Offset: 0x00358514
	public int[] GetEditingRoleIdList(int editFormationId)
	{
		List<int> list = new List<int>();
		if (!this.EditingFormationMap.ContainsKey(editFormationId))
		{
			return list.ToArray();
		}
		EditingRoleData[] array = this.EditingFormationMap[editFormationId];
		for (int i = 0; i < array.Length; i++)
		{
			int roleId = array[i].RoleId;
			if (roleId != 0)
			{
				list.Add(roleId);
			}
		}
		return list.ToArray();
	}

	// Token: 0x0600C9D1 RID: 51665 RVA: 0x0035A370 File Offset: 0x00358570
	public HashSet<int> GetEditingRoleIdSet(int editFormationId)
	{
		HashSet<int> hashSet = new HashSet<int>();
		if (!this.EditingFormationMap.ContainsKey(editFormationId))
		{
			return hashSet;
		}
		EditingRoleData[] array = this.EditingFormationMap[editFormationId];
		for (int i = 0; i < array.Length; i++)
		{
			int roleId = array[i].RoleId;
			if (roleId != 0)
			{
				hashSet.Add(roleId);
			}
		}
		return hashSet;
	}

	// Token: 0x0600C9D2 RID: 51666 RVA: 0x0035A3C4 File Offset: 0x003585C4
	public Dictionary<int, int[]> GetAllEditingFormation()
	{
		Dictionary<int, int[]> dictionary = new Dictionary<int, int[]>();
		foreach (KeyValuePair<int, EditingRoleData[]> keyValuePair in this.EditingFormationMap)
		{
			int key = keyValuePair.Key;
			EditingRoleData[] value = keyValuePair.Value;
			List<int> list = new List<int>();
			EditingRoleData[] array = value;
			for (int i = 0; i < array.Length; i++)
			{
				int roleId = array[i].RoleId;
				if (roleId != 0)
				{
					list.Add(roleId);
				}
			}
			dictionary[key] = list.ToArray();
		}
		return dictionary;
	}

	// Token: 0x0600C9D3 RID: 51667 RVA: 0x0035A46C File Offset: 0x0035866C
	public bool IsInEditingFormation(int editFormationId, int configId)
	{
		return this.GetEditingRolePosition(editFormationId, configId) > 0;
	}

	// Token: 0x0600C9D4 RID: 51668 RVA: 0x0035A479 File Offset: 0x00358679
	[NullableContext(2)]
	public EditFormationData GetFormationData(int formationId)
	{
		if (this.FormationDataMap.ContainsKey(formationId))
		{
			return this.FormationDataMap[formationId];
		}
		return null;
	}

	// Token: 0x1700103F RID: 4159
	// (get) Token: 0x0600C9D5 RID: 51669 RVA: 0x0035A497 File Offset: 0x00358697
	[Nullable(2)]
	public EditFormationData GetCurrentFormationData
	{
		[NullableContext(2)]
		get
		{
			return this.CurrentFormationData;
		}
	}

	// Token: 0x17001040 RID: 4160
	// (get) Token: 0x0600C9D6 RID: 51670 RVA: 0x0035A4A0 File Offset: 0x003586A0
	public int? GetCurrentFormationId
	{
		get
		{
			EditFormationData currentFormationData = this.CurrentFormationData;
			if (currentFormationData == null)
			{
				return null;
			}
			return new int?(currentFormationData.FormationId);
		}
	}

	// Token: 0x0600C9D7 RID: 51671 RVA: 0x0035A4CC File Offset: 0x003586CC
	public bool IsRoleInCurrentFormation(int roleId)
	{
		if (this.CurrentFormationData == null)
		{
			return false;
		}
		int[] getRoleIdList = this.CurrentFormationData.GetRoleIdList;
		for (int i = 0; i < getRoleIdList.Length; i++)
		{
			if (getRoleIdList[i] == roleId)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x0600C9D8 RID: 51672 RVA: 0x0035A508 File Offset: 0x00358708
	public void ApplyCurrentFormationData(int formationId)
	{
		if (this.FormationDataMap.ContainsKey(formationId))
		{
			EditFormationData editFormationData = this.FormationDataMap[formationId];
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Formation;
			ELogAuthor author = ELogAuthor.LYY;
			string message = "设置当前编队数据 [ApplyCurrentFormationData]";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("data", editFormationData);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			this.CurrentFormationData = editFormationData;
		}
	}

	// Token: 0x0600C9D9 RID: 51673 RVA: 0x0035A560 File Offset: 0x00358760
	public bool IsMyPosition(int position)
	{
		if (!ModelBase<GameModeModel>.Instance.IsMulti)
		{
			return true;
		}
		bool isMyTeam = ModelBase<OnlineModel>.Instance.GetIsMyTeam();
		EditFormationData getCurrentFormationData = this.GetCurrentFormationData;
		EditFormationRoleData editFormationRoleData = (getCurrentFormationData != null) ? getCurrentFormationData.GetRoleDataByPosition(position) : null;
		bool flag;
		if (editFormationRoleData == null)
		{
			flag = true;
		}
		else
		{
			int configId = editFormationRoleData.ConfigId;
			flag = false;
		}
		if (flag || editFormationRoleData.ConfigId == 0)
		{
			return isMyTeam;
		}
		int? id = ModelBase<PlayerInfoModel>.Instance.GetId();
		int playerId = editFormationRoleData.PlayerId;
		return id.GetValueOrDefault() == playerId & id != null;
	}

	// Token: 0x0600C9DA RID: 51674 RVA: 0x0035A5D8 File Offset: 0x003587D8
	public int GetFormationAverageLevel()
	{
		float num = 0f;
		int num2 = 0;
		foreach (EntityHandle entityHandle in ModelBase<SceneTeamModel>.Instance.GetTeamEntities(false))
		{
			WorldEntity entity = entityHandle.Entity;
			BaseAttributeComponent baseAttributeComponent = (entity != null) ? entity.GetComponent<BaseAttributeComponent>() : null;
			if (baseAttributeComponent != null)
			{
				num += baseAttributeComponent.GetCurrentValue(EAttributeType.Lv);
				num2++;
			}
		}
		if (num2 > 0)
		{
			return (int)(num / (float)num2);
		}
		return 0;
	}

	// Token: 0x0600C9DB RID: 51675 RVA: 0x0035A660 File Offset: 0x00358860
	public int[] GetFormationAllSpecialTrialRole()
	{
		HashSet<int> hashSet = new HashSet<int>();
		foreach (EditFormationData editFormationData in this.FormationDataMap.Values)
		{
			foreach (int num in editFormationData.GetRoleIdListWithTrial(true))
			{
				if (RoleUtils.IsSpecialTrialRole(num))
				{
					hashSet.Add(num);
				}
			}
		}
		return hashSet.ToArray<int>();
	}

	// Token: 0x0600C9DC RID: 51676 RVA: 0x0035A708 File Offset: 0x00358908
	public bool IsFormationHasSpecialTrialRole()
	{
		foreach (EditFormationData editFormationData in this.FormationDataMap.Values)
		{
			using (List<int>.Enumerator enumerator2 = editFormationData.GetRoleIdListWithTrial(true).GetEnumerator())
			{
				while (enumerator2.MoveNext())
				{
					if (RoleUtils.IsSpecialTrialRole(enumerator2.Current))
					{
						return true;
					}
				}
			}
		}
		return false;
	}

	// Token: 0x0600C9DD RID: 51677 RVA: 0x0035A7A0 File Offset: 0x003589A0
	public bool IsEditingFormationHasSpecialTrialRole()
	{
		foreach (int[] array in this.GetAllEditingFormation().Values)
		{
			for (int i = 0; i < array.Length; i++)
			{
				if (RoleUtils.IsSpecialTrialRole(array[i]))
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x0600C9DE RID: 51678 RVA: 0x0035A810 File Offset: 0x00358A10
	public bool IsCurFormationHasSpecialTrialRole()
	{
		if (this.CurrentFormationData == null)
		{
			return false;
		}
		return this.CurrentFormationData.GetRoleIdList.Any((int id) => RoleUtils.IsSpecialTrialRole(id));
	}

	// Token: 0x0600C9DF RID: 51679 RVA: 0x0035A84C File Offset: 0x00358A4C
	public int GetCurrentFormationSkillBranchId(int position)
	{
		EditFormationData currentFormationData = this.CurrentFormationData;
		EditFormationRoleData editFormationRoleData = (currentFormationData != null) ? currentFormationData.GetRoleDataByPosition(position) : null;
		if (editFormationRoleData != null && editFormationRoleData.MultiSkillBranchIndex == 0)
		{
			return 0;
		}
		return editFormationRoleData.MultiSkillBranchIndex;
	}

	// Token: 0x0400609B RID: 24731
	private const int HEALTH_ID = 3;

	// Token: 0x0400609C RID: 24732
	private readonly Dictionary<int, EditFormationData> FormationDataMap = new Dictionary<int, EditFormationData>();

	// Token: 0x0400609D RID: 24733
	[Nullable(2)]
	private EditFormationData CurrentFormationData;

	// Token: 0x0400609E RID: 24734
	private readonly Dictionary<int, EditingRoleData[]> EditingFormationMap = new Dictionary<int, EditingRoleData[]>();
}
