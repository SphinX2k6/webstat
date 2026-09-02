using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;

// Token: 0x020029A3 RID: 10659
[NullableContext(1)]
[Nullable(0)]
public class ShipTowerTeamData
{
	// Token: 0x060153D9 RID: 87001 RVA: 0x005E2C84 File Offset: 0x005E0E84
	public ShipTowerTeamData()
	{
		this.RoleList = new List<ShipTowerRoleData>();
		this.TeamInstName = "";
		this.AreaName = "";
		this.TeamName = "";
	}

	// Token: 0x060153DA RID: 87002 RVA: 0x005E2CB8 File Offset: 0x005E0EB8
	public void Init(int instId, int index, int stageId)
	{
		this.InstId = instId;
		this.Index = index;
		this.StageId = stageId;
		InstanceDungeon? instanceDungeonCfg = this.GetInstanceDungeonCfg(null);
		this.TeamInstName = (((instanceDungeonCfg != null) ? instanceDungeonCfg.GetValueOrDefault().MapName : null) ?? "MapName");
		string teamName = (index == 0) ? "GhostShipTeamName_Text1" : "GhostShipTeamName_Text2";
		this.TeamName = teamName;
		string areaName = (index == 0) ? "GhostShipTeamName_Text3" : "GhostShipTeamName_Text4";
		this.AreaName = areaName;
		for (int i = 0; i < 3; i++)
		{
			ShipTowerRoleData item = new ShipTowerRoleData
			{
				RoleId = 0,
				RoleIdEdit = 0,
				TeamIndex = index,
				TeamId = 0,
				PositionIndex = i,
				BelongTo = ((index == 0) ? ETeamBelong.FirstPart : ETeamBelong.LowPart),
				SkillBranchId = 0,
				SkillBranchIdEdit = 0
			};
			this.RoleList.Add(item);
		}
	}

	// Token: 0x060153DB RID: 87003 RVA: 0x005E2DA6 File Offset: 0x005E0FA6
	public List<ShipTowerRoleData> GetUseRoleList()
	{
		return this.RoleList;
	}

	// Token: 0x060153DC RID: 87004 RVA: 0x005E2DB0 File Offset: 0x005E0FB0
	public void UpdateToEdit()
	{
		foreach (ShipTowerRoleData shipTowerRoleData in this.RoleList)
		{
			this.UpdateRoleIdEdit(shipTowerRoleData, shipTowerRoleData.RoleId, false);
			shipTowerRoleData.SkillBranchIdEdit = shipTowerRoleData.SkillBranchId;
		}
		this.UpdateBuffDataEdit(this.BuffData);
	}

	// Token: 0x060153DD RID: 87005 RVA: 0x005E2E24 File Offset: 0x005E1024
	public void CopyTeamRoleToEdit(ShipTowerTeamData targetTeamData)
	{
		for (int i = 0; i < this.RoleList.Count; i++)
		{
			ShipTowerRoleData shipTowerRoleData = this.RoleList[i];
			ShipTowerRoleData shipTowerRoleData2 = (i < targetTeamData.RoleList.Count) ? targetTeamData.RoleList[i] : null;
			int roleId = (shipTowerRoleData2 != null) ? shipTowerRoleData2.RoleIdEdit : 0;
			this.UpdateRoleIdEdit(shipTowerRoleData, roleId, false);
			shipTowerRoleData.SkillBranchId = ((shipTowerRoleData2 != null) ? shipTowerRoleData2.SkillBranchId : 0);
		}
	}

	// Token: 0x060153DE RID: 87006 RVA: 0x005E2E9C File Offset: 0x005E109C
	public void CopyIdsToEdit(List<int> roleIdList)
	{
		for (int i = 0; i < this.RoleList.Count; i++)
		{
			ShipTowerRoleData data = this.RoleList[i];
			int roleId = (i < roleIdList.Count) ? roleIdList[i] : 0;
			this.UpdateRoleIdEdit(data, roleId, true);
		}
	}

	// Token: 0x060153DF RID: 87007 RVA: 0x005E2EEC File Offset: 0x005E10EC
	public void UpdateRoleListByModel()
	{
		Dictionary<int, RoleDataBase> roleIndexMap = ModelBase<RoleSelectModel>.Instance.RoleIndexMap;
		foreach (ShipTowerRoleData shipTowerRoleData in this.RoleList)
		{
			int roleIndexInAllTeam = this.GetRoleIndexInAllTeam(shipTowerRoleData.PositionIndex + 1);
			int roleId = 0;
			RoleDataBase roleDataBase;
			if (roleIndexMap.TryGetValue(roleIndexInAllTeam, out roleDataBase))
			{
				roleId = roleDataBase.GetDataId();
			}
			this.UpdateRoleIdEdit(shipTowerRoleData, roleId, false);
		}
	}

	// Token: 0x060153E0 RID: 87008 RVA: 0x005E2F74 File Offset: 0x005E1174
	public void UpdateRoleListByFormationData(EditFormationData formationData)
	{
		ModelBase<RoleSelectModel>.Instance.ClearData();
		for (int i = 0; i < this.RoleList.Count; i++)
		{
			ShipTowerRoleData shipTowerRoleData = this.RoleList[i];
			int roleId = (i < formationData.GetRoleIdList.Length) ? formationData.GetRoleIdList[i] : 0;
			this.UpdateRoleIdEdit(shipTowerRoleData, roleId, false);
			this.AddRoleDataToRoleSelectModel(shipTowerRoleData, true);
		}
	}

	// Token: 0x060153E1 RID: 87009 RVA: 0x005E2FD8 File Offset: 0x005E11D8
	public void UpdateRoleListToRoleSelectModel()
	{
		ModelBase<RoleSelectModel>.Instance.ClearData();
		foreach (ShipTowerRoleData shipTowerRoleData in this.RoleList)
		{
			this.AddRoleDataToRoleSelectModel(shipTowerRoleData, true);
		}
	}

	// Token: 0x060153E2 RID: 87010 RVA: 0x005E3038 File Offset: 0x005E1238
	private void AddRoleDataToRoleSelectModel(ShipTowerRoleData shipTowerRoleData, bool addSet = true)
	{
		int roleIndexInAllTeam = this.GetRoleIndexInAllTeam(shipTowerRoleData.PositionIndex + 1);
		if (shipTowerRoleData.RoleIdEdit == 0)
		{
			ModelBase<RoleSelectModel>.Instance.RoleIndexMap.Remove(roleIndexInAllTeam);
			return;
		}
		RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(shipTowerRoleData.RoleIdEdit, true);
		if (roleDataById != null)
		{
			if (ModelBase<RoleSelectModel>.Instance.RoleIndexMap.ContainsKey(roleIndexInAllTeam))
			{
				ModelBase<RoleSelectModel>.Instance.RoleIndexMap[roleIndexInAllTeam] = roleDataById;
			}
			else
			{
				ModelBase<RoleSelectModel>.Instance.RoleIndexMap.Add(roleIndexInAllTeam, roleDataById);
			}
			if (addSet)
			{
				ModelBase<RoleSelectModel>.Instance.SelectedRoleSet.Add(roleDataById.GetDataId());
			}
		}
	}

	// Token: 0x060153E3 RID: 87011 RVA: 0x005E30D2 File Offset: 0x005E12D2
	public int GetRoleIndexInAllTeam(int pos)
	{
		return this.Index * 3 + pos;
	}

	// Token: 0x060153E4 RID: 87012 RVA: 0x005E30E0 File Offset: 0x005E12E0
	public void UpdateOtherTeamRoleToShipTowerModel()
	{
		foreach (ShipTowerRoleData roleData in this.RoleList)
		{
			ModelBase<ShipTowerModel>.Instance.AddOtherTeamRoleData(roleData);
		}
	}

	// Token: 0x060153E5 RID: 87013 RVA: 0x005E3138 File Offset: 0x005E1338
	public void UpdateAllTeamRoleToShipTowerModel()
	{
		foreach (ShipTowerRoleData roleData in this.RoleList)
		{
			ModelBase<ShipTowerModel>.Instance.AddAllTeamRoleData(roleData);
		}
	}

	// Token: 0x060153E6 RID: 87014 RVA: 0x005E3190 File Offset: 0x005E1390
	public bool UpdateOtherTeamRoleRepeat(ShipTowerTeamData indexTeamData)
	{
		List<int> roleIdListEdit = indexTeamData.GetRoleIdListEdit();
		bool result = false;
		foreach (ShipTowerRoleData shipTowerRoleData in this.RoleList)
		{
			if (shipTowerRoleData.RoleIdEdit != 0 && roleIdListEdit.Contains(shipTowerRoleData.RoleIdEdit))
			{
				this.UpdateRoleIdEdit(shipTowerRoleData, 0, false);
				result = true;
			}
		}
		return result;
	}

	// Token: 0x060153E7 RID: 87015 RVA: 0x005E3208 File Offset: 0x005E1408
	public void RemoveRoleIdEdit(int? roleId = null)
	{
		if (roleId == null || roleId.Value == 0)
		{
			return;
		}
		foreach (ShipTowerRoleData shipTowerRoleData in this.RoleList)
		{
			if (shipTowerRoleData.RoleIdEdit == roleId.Value)
			{
				this.UpdateRoleIdEdit(shipTowerRoleData, 0, false);
			}
		}
	}

	// Token: 0x060153E8 RID: 87016 RVA: 0x005E3280 File Offset: 0x005E1480
	public void UpdateRoleIndexInAllTeam()
	{
		foreach (ShipTowerRoleData shipTowerRoleData in this.RoleList)
		{
			this.AddRoleDataToRoleSelectModel(shipTowerRoleData, false);
		}
	}

	// Token: 0x060153E9 RID: 87017 RVA: 0x005E32D4 File Offset: 0x005E14D4
	[NullableContext(2)]
	public void UseBuff(ShipTowerBuffData buffData = null)
	{
		this.UpdateBuffDataEdit(buffData);
	}

	// Token: 0x060153EA RID: 87018 RVA: 0x005E32E0 File Offset: 0x005E14E0
	public bool IsSetRoleFinish()
	{
		using (List<ShipTowerRoleData>.Enumerator enumerator = this.RoleList.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.RoleId <= 0)
				{
					return false;
				}
			}
		}
		return true;
	}

	// Token: 0x060153EB RID: 87019 RVA: 0x005E333C File Offset: 0x005E153C
	public bool IsSetRoleFinishEdit()
	{
		using (List<ShipTowerRoleData>.Enumerator enumerator = this.RoleList.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.RoleIdEdit <= 0)
				{
					return false;
				}
			}
		}
		return true;
	}

	// Token: 0x060153EC RID: 87020 RVA: 0x005E3398 File Offset: 0x005E1598
	public bool IsSetBuffFinish()
	{
		return this.BuffData != null;
	}

	// Token: 0x060153ED RID: 87021 RVA: 0x005E33A3 File Offset: 0x005E15A3
	public bool IsSetBuffFinishEdit()
	{
		return this.BuffDataEdit != null;
	}

	// Token: 0x060153EE RID: 87022 RVA: 0x005E33B0 File Offset: 0x005E15B0
	public bool TeamIsEmpty()
	{
		if (this.IsSetBuffFinishEdit())
		{
			return false;
		}
		using (List<ShipTowerRoleData>.Enumerator enumerator = this.RoleList.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.RoleIdEdit != 0)
				{
					return false;
				}
			}
		}
		return true;
	}

	// Token: 0x060153EF RID: 87023 RVA: 0x005E3414 File Offset: 0x005E1614
	public void ExChangeTeamData(ShipTowerTeamData otherTeam)
	{
		ShipTowerBuffData buffDataEdit = this.BuffDataEdit;
		int? buffId = (buffDataEdit != null) ? new int?(buffDataEdit.Id) : null;
		this.UpdateBuffDataEdit(otherTeam.BuffDataEdit);
		otherTeam.UpdateBuffIdEdit(buffId);
		List<int> roleIdListEdit = this.GetRoleIdListEdit();
		this.CopyIdsToEdit(otherTeam.GetRoleIdListEdit());
		otherTeam.CopyIdsToEdit(roleIdListEdit);
		this.UpdateRoleListToRoleSelectModel();
	}

	// Token: 0x060153F0 RID: 87024 RVA: 0x005E3474 File Offset: 0x005E1674
	public void ProtoSetRole(int roleId, int index)
	{
		ShipTowerRoleData shipTowerRoleData = this.RoleList[index];
		if (shipTowerRoleData != null)
		{
			this.UpdateRoleId(shipTowerRoleData, roleId);
			this.UpdateRoleIdEdit(shipTowerRoleData, roleId, false);
		}
	}

	// Token: 0x060153F1 RID: 87025 RVA: 0x005E34A4 File Offset: 0x005E16A4
	public void ProtoSetBuff(int? buffId = null)
	{
		ShipTowerBuffData buffDataByBuffId = ModelBase<ShipTowerModel>.Instance.GetBuffDataByBuffId(buffId.GetValueOrDefault());
		this.UpdateBuffData(buffDataByBuffId);
		this.UpdateBuffDataEdit(buffDataByBuffId);
	}

	// Token: 0x060153F2 RID: 87026 RVA: 0x005E34D4 File Offset: 0x005E16D4
	public void ProtoSetSkillBranch(int skillBranchId, int index)
	{
		ShipTowerRoleData shipTowerRoleData = this.RoleList[index];
		if (shipTowerRoleData != null)
		{
			shipTowerRoleData.SkillBranchId = skillBranchId;
			shipTowerRoleData.SkillBranchIdEdit = skillBranchId;
		}
	}

	// Token: 0x060153F3 RID: 87027 RVA: 0x005E34FF File Offset: 0x005E16FF
	public void UpdateCurrentScore(int score)
	{
		this.CurrentScore = score;
	}

	// Token: 0x060153F4 RID: 87028 RVA: 0x005E3508 File Offset: 0x005E1708
	public List<int> GetRoleIdList()
	{
		List<int> list = new List<int>();
		foreach (ShipTowerRoleData shipTowerRoleData in this.RoleList)
		{
			list.Add(shipTowerRoleData.RoleId);
		}
		return list;
	}

	// Token: 0x060153F5 RID: 87029 RVA: 0x005E3568 File Offset: 0x005E1768
	public List<int> GetRoleIdListEdit()
	{
		List<int> list = new List<int>();
		foreach (ShipTowerRoleData shipTowerRoleData in this.RoleList)
		{
			list.Add(shipTowerRoleData.RoleIdEdit);
		}
		return list;
	}

	// Token: 0x060153F6 RID: 87030 RVA: 0x005E35C8 File Offset: 0x005E17C8
	public void ResetStage()
	{
		foreach (ShipTowerRoleData shipTowerRoleData in this.RoleList)
		{
			this.UpdateRoleId(shipTowerRoleData, 0);
			this.UpdateRoleIdEdit(shipTowerRoleData, 0, false);
			shipTowerRoleData.SkillBranchId = 0;
			shipTowerRoleData.SkillBranchIdEdit = 0;
		}
		this.UpdateBuffData(null);
		this.UpdateBuffDataEdit(null);
		this.UpdateCurrentScore(0);
	}

	// Token: 0x060153F7 RID: 87031 RVA: 0x005E3648 File Offset: 0x005E1848
	public void CoverChallenge()
	{
		foreach (ShipTowerRoleData shipTowerRoleData in this.RoleList)
		{
			this.UpdateRoleId(shipTowerRoleData, shipTowerRoleData.RoleIdEdit);
			shipTowerRoleData.SkillBranchId = shipTowerRoleData.SkillBranchIdEdit;
		}
		this.UpdateBuffData(this.BuffDataEdit);
		this.UpdateCurrentScore(this.NewChallengeScore);
	}

	// Token: 0x060153F8 RID: 87032 RVA: 0x005E36C8 File Offset: 0x005E18C8
	private void UpdateRoleId(ShipTowerRoleData data, int roleId = 0)
	{
		data.RoleId = roleId;
	}

	// Token: 0x060153F9 RID: 87033 RVA: 0x005E36D4 File Offset: 0x005E18D4
	private void UpdateRoleIdEdit(ShipTowerRoleData data, int roleId = 0, bool isCheck = false)
	{
		data.RoleIdEdit = roleId;
		if (roleId <= 0)
		{
			data.RoleIdEdit = 0;
			return;
		}
		if (isCheck)
		{
			data.RoleIdEdit = (ModelBase<ShipTowerModel>.Instance.IsCanUseRole(roleId) ? roleId : 0);
			return;
		}
		RoleModel instance = ModelBase<RoleModel>.Instance;
		if (instance != null && instance.IsMainRole(roleId))
		{
			data.RoleIdEdit = ModelBase<RoleModel>.Instance.GetCurSelectMainRoleId().GetValueOrDefault(roleId);
		}
	}

	// Token: 0x060153FA RID: 87034 RVA: 0x005E373C File Offset: 0x005E193C
	[NullableContext(2)]
	private void UpdateBuffData(ShipTowerBuffData buffData = null)
	{
		this.BuffData = buffData;
	}

	// Token: 0x060153FB RID: 87035 RVA: 0x005E3745 File Offset: 0x005E1945
	[NullableContext(2)]
	private void UpdateBuffDataEdit(ShipTowerBuffData buffData = null)
	{
		this.BuffDataEdit = buffData;
	}

	// Token: 0x060153FC RID: 87036 RVA: 0x005E3750 File Offset: 0x005E1950
	public void UpdateBuffIdEdit(int? buffId = null)
	{
		ShipTowerBuffData buffDataByBuffId = ModelBase<ShipTowerModel>.Instance.GetBuffDataByBuffId(buffId.GetValueOrDefault());
		this.UpdateBuffDataEdit(buffDataByBuffId);
	}

	// Token: 0x060153FD RID: 87037 RVA: 0x005E3778 File Offset: 0x005E1978
	public void CopyBuffIdToEdit(int buffId, int stageId)
	{
		ShipTowerBuffData buffDataByBuffId = ModelBase<ShipTowerModel>.Instance.GetBuffDataByBuffId(buffId);
		if (buffDataByBuffId == null || !buffDataByBuffId.IsCanUse(new int?(stageId)))
		{
			this.UpdateBuffDataEdit(null);
			return;
		}
		this.UpdateBuffDataEdit(buffDataByBuffId);
	}

	// Token: 0x060153FE RID: 87038 RVA: 0x005E37B8 File Offset: 0x005E19B8
	[NullableContext(2)]
	public void ProtoTeamEditFromResult(BattleFormation result = null)
	{
		if (result != null)
		{
			for (int i = 0; i < result.SelectRoles.Count; i++)
			{
				int roleId = result.SelectRoles[i];
				this.UpdateRoleIdEdit(this.RoleList[i], roleId, false);
			}
		}
		this.UpdateBuffIdEdit((result != null) ? new int?(result.BuffSelect) : null);
		if (((result != null) ? result.SkillBranchIds : null) != null)
		{
			for (int j = 0; j < result.SkillBranchIds.Count; j++)
			{
				this.RoleList[j].SkillBranchIdEdit = result.SkillBranchIds[j];
			}
		}
	}

	// Token: 0x060153FF RID: 87039 RVA: 0x005E385F File Offset: 0x005E1A5F
	public void ProtoSetNewChallengeScore(int score)
	{
		this.NewChallengeScore = score;
	}

	// Token: 0x06015400 RID: 87040 RVA: 0x005E3868 File Offset: 0x005E1A68
	public InstanceDungeon? GetInstanceDungeonCfg(int? id = null)
	{
		InstanceDungeon? config = ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(id ?? this.InstId);
		if (config != null)
		{
			return new InstanceDungeon?(config.Value);
		}
		return null;
	}

	// Token: 0x06015401 RID: 87041 RVA: 0x005E38B9 File Offset: 0x005E1AB9
	public SlashTowerStageInfo? GetShipTowerStageCfg()
	{
		return ConfigBase<ShipTowerConfig>.Instance.GetStageInfoCfgByInstId(this.InstId);
	}

	// Token: 0x06015402 RID: 87042 RVA: 0x005E38CC File Offset: 0x005E1ACC
	public unsafe ShipTowerMonsterWordItemData GetInfoAttr()
	{
		InstanceDungeon? instanceDungeonCfg = this.GetInstanceDungeonCfg(null);
		string text = "GhostShipMonster_Text1";
		string multiTextByKey = ConfigBase<TextConfig>.Instance.GetMultiTextByKey(((instanceDungeonCfg != null) ? instanceDungeonCfg.GetValueOrDefault().DungeonDesc : null) ?? "", ((instanceDungeonCfg != null) ? instanceDungeonCfg.GetValueOrDefault().DungeonDesc : null) ?? "");
		ShipTowerMonsterWordItemData shipTowerMonsterWordItemData = new ShipTowerMonsterWordItemData();
		shipTowerMonsterWordItemData.Title = ConfigBase<TextConfig>.Instance.GetMultiTextByKey(text, text);
		int num = 1;
		List<ShipTowerMonsterWordInfoItemData> list = new List<ShipTowerMonsterWordInfoItemData>(num);
		CollectionsMarshal.SetCount<ShipTowerMonsterWordInfoItemData>(list, num);
		Span<ShipTowerMonsterWordInfoItemData> span = CollectionsMarshal.AsSpan<ShipTowerMonsterWordInfoItemData>(list);
		int index = 0;
		*span[index] = new ShipTowerMonsterWordInfoItemData
		{
			Desc = multiTextByKey
		};
		shipTowerMonsterWordItemData.InfoList = list;
		return shipTowerMonsterWordItemData;
	}

	// Token: 0x06015403 RID: 87043 RVA: 0x005E3994 File Offset: 0x005E1B94
	[NullableContext(2)]
	public ShipTowerMonsterWordItemData GetInfoWord()
	{
		SlashTowerStageInfo? shipTowerStageCfg = this.GetShipTowerStageCfg();
		List<ShipTowerMonsterWordInfoItemData> list = new List<ShipTowerMonsterWordInfoItemData>();
		if (((shipTowerStageCfg != null) ? shipTowerStageCfg.GetValueOrDefault().BuffId() : null) != null)
		{
			foreach (int num in shipTowerStageCfg.Value.BuffId())
			{
				SlashTowerTagInfo? wordInfoCfgById = ConfigBase<ShipTowerConfig>.Instance.GetWordInfoCfgById(num);
				if (wordInfoCfgById != null)
				{
					ShipTowerWordItemData wordInfoById = this.GetWordInfoById(num, wordInfoCfgById);
					string multiTextByKey = ConfigBase<TextConfig>.Instance.GetMultiTextByKey(wordInfoCfgById.Value.Desc, wordInfoCfgById.Value.Desc);
					ShipTowerMonsterWordInfoItemData item = new ShipTowerMonsterWordInfoItemData
					{
						Desc = multiTextByKey,
						Title = (((wordInfoById != null) ? wordInfoById.Title : null) ?? ""),
						TitleColor = ((wordInfoById != null) ? wordInfoById.TitleColor : null),
						IconPath = (((wordInfoById != null) ? wordInfoById.IconPath : null) ?? "")
					};
					list.Add(item);
				}
			}
		}
		if (list.Count == 0)
		{
			string text = "GhostShipMonsterNull_Text";
			string multiTextByKey2 = ConfigBase<TextConfig>.Instance.GetMultiTextByKey(text, text);
			list.Add(new ShipTowerMonsterWordInfoItemData
			{
				Desc = multiTextByKey2
			});
		}
		string text2 = "GhostShipMonster_Text2";
		return new ShipTowerMonsterWordItemData
		{
			Title = ConfigBase<TextConfig>.Instance.GetMultiTextByKey(text2, text2),
			InfoList = list
		};
	}

	// Token: 0x06015404 RID: 87044 RVA: 0x005E3B0C File Offset: 0x005E1D0C
	public ShipTowerMonsterListItemData GetMonsterListItemData()
	{
		string text = "GhostShipMonster_Text3";
		return new ShipTowerMonsterListItemData
		{
			Title = ConfigBase<TextConfig>.Instance.GetMultiTextByKey(text, text),
			MonsterInfoList = this.GetMonsterInfoList()
		};
	}

	// Token: 0x06015405 RID: 87045 RVA: 0x005E3B44 File Offset: 0x005E1D44
	public List<ShipTowerMonsterInfoItemData> GetMonsterInfoList()
	{
		List<ShipTowerMonsterInfoItemData> list = new List<ShipTowerMonsterInfoItemData>();
		int instId = this.InstId;
		SlashTowerStageInfo? shipTowerStageCfg = this.GetShipTowerStageCfg();
		int curWorldLevel = ModelBase<WorldLevelModel>.Instance.CurWorldLevel;
		int recommendLevel = ConfigBase<InstanceDungeonConfig>.Instance.GetRecommendLevel(instId, curWorldLevel);
		if (((shipTowerStageCfg != null) ? shipTowerStageCfg.GetValueOrDefault().MonsterId() : null) != null)
		{
			foreach (int monsterId in shipTowerStageCfg.Value.MonsterId())
			{
				Aki.Config.MonsterInfo? monsterInfoConfig = ConfigBase<MonsterInfoConfig>.Instance.GetMonsterInfoConfig(monsterId);
				string monsterIcon = ConfigBase<MonsterInfoConfig>.Instance.GetMonsterIcon(monsterId);
				ShipTowerMonsterInfoItemData item = new ShipTowerMonsterInfoItemData
				{
					Title = (((monsterInfoConfig != null) ? monsterInfoConfig.GetValueOrDefault().Name : null) ?? ""),
					Level = recommendLevel,
					MonsterIcon = monsterIcon,
					ElementList = ((((monsterInfoConfig != null) ? monsterInfoConfig.GetValueOrDefault().ElementIdArray() : null) != null) ? new List<int>(monsterInfoConfig.Value.ElementIdArray()) : new List<int>())
				};
				list.Add(item);
			}
		}
		return list;
	}

	// Token: 0x06015406 RID: 87046 RVA: 0x005E3C78 File Offset: 0x005E1E78
	public List<ShipTowerWordItemData> GetWordInfoList()
	{
		SlashTowerStageInfo? shipTowerStageCfg = this.GetShipTowerStageCfg();
		List<ShipTowerWordItemData> list = new List<ShipTowerWordItemData>();
		if (((shipTowerStageCfg != null) ? shipTowerStageCfg.GetValueOrDefault().BuffId() : null) != null)
		{
			foreach (int buffId in shipTowerStageCfg.Value.BuffId())
			{
				ShipTowerWordItemData wordInfoById = this.GetWordInfoById(buffId, null);
				if (wordInfoById != null)
				{
					list.Add(wordInfoById);
				}
			}
		}
		return list;
	}

	// Token: 0x06015407 RID: 87047 RVA: 0x005E3CF8 File Offset: 0x005E1EF8
	[NullableContext(2)]
	private ShipTowerWordItemData GetWordInfoById(int buffId, SlashTowerTagInfo? tagCfg = null)
	{
		SlashTowerTagInfo? slashTowerTagInfo = tagCfg;
		SlashTowerTagInfo? slashTowerTagInfo2 = (slashTowerTagInfo != null) ? slashTowerTagInfo : ConfigBase<ShipTowerConfig>.Instance.GetWordInfoCfgById(buffId);
		if (slashTowerTagInfo2 != null)
		{
			string multiTextByKey = ConfigBase<TextConfig>.Instance.GetMultiTextByKey(slashTowerTagInfo2.Value.Name, slashTowerTagInfo2.Value.Name);
			return new ShipTowerWordItemData
			{
				Title = multiTextByKey,
				IconPath = slashTowerTagInfo2.Value.Path,
				TitleColor = slashTowerTagInfo2.Value.Color
			};
		}
		return null;
	}

	// Token: 0x06015408 RID: 87048 RVA: 0x005E3D8C File Offset: 0x005E1F8C
	public void UpdateMainRoleToEdit()
	{
		foreach (ShipTowerRoleData shipTowerRoleData in this.RoleList)
		{
			if (shipTowerRoleData.RoleIdEdit > 0)
			{
				RoleModel instance = ModelBase<RoleModel>.Instance;
				if (instance != null && instance.IsMainRole(shipTowerRoleData.RoleIdEdit))
				{
					this.UpdateRoleIdEdit(shipTowerRoleData, shipTowerRoleData.RoleIdEdit, false);
				}
			}
		}
	}

	// Token: 0x0400A3DC RID: 41948
	public int InstId;

	// Token: 0x0400A3DD RID: 41949
	public int Index;

	// Token: 0x0400A3DE RID: 41950
	public readonly List<ShipTowerRoleData> RoleList;

	// Token: 0x0400A3DF RID: 41951
	[Nullable(2)]
	public ShipTowerBuffData BuffData;

	// Token: 0x0400A3E0 RID: 41952
	[Nullable(2)]
	public ShipTowerBuffData BuffDataEdit;

	// Token: 0x0400A3E1 RID: 41953
	public int StageId;

	// Token: 0x0400A3E2 RID: 41954
	public int CurrentScore;

	// Token: 0x0400A3E3 RID: 41955
	public int NewChallengeScore;

	// Token: 0x0400A3E4 RID: 41956
	public string TeamInstName;

	// Token: 0x0400A3E5 RID: 41957
	public string AreaName;

	// Token: 0x0400A3E6 RID: 41958
	public string TeamName;
}
