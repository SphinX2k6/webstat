using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.LevelGamePlay;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Ui;
using Google.Protobuf.Collections;
using UnrealEngine;

// Token: 0x020028A0 RID: 10400
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class RoleModel : ModelBase<RoleModel>
{
	// Token: 0x17001B0F RID: 6927
	// (get) Token: 0x06014995 RID: 84373 RVA: 0x005B443F File Offset: 0x005B263F
	public bool IsInGamePlayRoleEdit
	{
		get
		{
			return this.RoleSkillBranchCacheTypeInternal > ESkillBranchCacheType.Normal;
		}
	}

	// Token: 0x17001B10 RID: 6928
	// (get) Token: 0x06014996 RID: 84374 RVA: 0x005B444A File Offset: 0x005B264A
	public ESkillBranchCacheType RoleSkillBranchCacheType
	{
		get
		{
			return this.RoleSkillBranchCacheTypeInternal;
		}
	}

	// Token: 0x17001B11 RID: 6929
	// (get) Token: 0x06014997 RID: 84375 RVA: 0x005B4452 File Offset: 0x005B2652
	// (set) Token: 0x06014998 RID: 84376 RVA: 0x005B445A File Offset: 0x005B265A
	public bool IsInRoleTrial
	{
		get
		{
			return this.IsInRoleTrialInternal;
		}
		set
		{
			bool flag = this.IsInRoleTrialInternal != value;
			this.IsInRoleTrialInternal = value;
			ModelBase<OnlineModel>.Instance.DisableOnline(EDisableOnlineType.TrialRole, value, 0, 0);
			if (flag)
			{
				Singleton<EventSystem>.Instance.Emit<bool>(EEventName.OnRoleTrialStateChanged, value);
			}
		}
	}

	// Token: 0x06014999 RID: 84377 RVA: 0x005B4490 File Offset: 0x005B2690
	public void SetCanUseSpecialTrialRole(bool value)
	{
		this.CanUseSpecialTrialRoleInternal = value;
	}

	// Token: 0x0601499A RID: 84378 RVA: 0x005B449C File Offset: 0x005B269C
	public bool CanUseSpecialTrialRole(int? instanceId = null)
	{
		if (ModelBase<GameModeModel>.Instance.IsMulti)
		{
			return false;
		}
		int? num = instanceId;
		InstanceDungeon? instanceDungeon;
		int? num2 = (num != null) ? num : ((ModelBase<GameModeModel>.Instance.InstanceDungeon != null) ? new int?(instanceDungeon.GetValueOrDefault().Id) : null);
		return (num2 == null || this.IsDungeonCanUseSpecialTrialRole(num2.Value)) && this.CanUseSpecialTrialRoleInternal;
	}

	// Token: 0x0601499B RID: 84379 RVA: 0x005B451C File Offset: 0x005B271C
	public bool IsDungeonCanUseSpecialTrialRole(int instanceId)
	{
		InstanceDungeon? config = ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(instanceId);
		if (config == null)
		{
			return false;
		}
		IReadOnlyList<int> intArrayConfig = ConfigCommonParamById.GetIntArrayConfig("NewTrialRoleEnableInsSubType");
		return intArrayConfig != null && intArrayConfig.IndexOf(config.Value.InstSubType) >= 0;
	}

	// Token: 0x0601499C RID: 84380 RVA: 0x005B456B File Offset: 0x005B276B
	protected override bool OnInit()
	{
		Singleton<EventSystem>.Instance.Add<EntityHandle, EntityHandle>(EEventName.OnChangeRole, new Action<EntityHandle, EntityHandle>(this.OnChangeRole));
		return true;
	}

	// Token: 0x0601499D RID: 84381 RVA: 0x005B458C File Offset: 0x005B278C
	public List<RoleDataBase> GetAllConfigRoleDataList()
	{
		List<RoleDataBase> list = new List<RoleDataBase>();
		HashSet<int> hashSet = new HashSet<int>();
		foreach (RoleInfo roleInfo in (ConfigBase<RoleConfig>.Instance.GetRoleList() ?? new List<RoleInfo>()))
		{
			if (roleInfo.RoleType == 1 && !hashSet.Contains(roleInfo.Id))
			{
				hashSet.Add(roleInfo.Id);
				int id = roleInfo.Id;
				RoleInstance roleInstance;
				bool flag = this.RoleInstanceMap.TryGetValue(id, out roleInstance);
				bool flag2 = RoleDevUtils.GetRoleTypeTagByRoleId(id) == ERoleTypeTag.Forecast;
				if ((flag || !this.IsMainRole(id)) && !flag2 && ModelBase<HandBookModel>.Instance.GetRoleCanShowInHandBook(id))
				{
					if (roleInstance == null)
					{
						roleInstance = new RoleInstance(id);
					}
					list.Add(roleInstance);
				}
			}
		}
		this.SortRoleDataList(list);
		return list;
	}

	// Token: 0x0601499E RID: 84382 RVA: 0x005B4678 File Offset: 0x005B2878
	public List<int> GetAllConfigRoleIdList()
	{
		List<int> list = new List<int>();
		HashSet<int> hashSet = new HashSet<int>();
		foreach (RoleInfo roleInfo in (ConfigBase<RoleConfig>.Instance.GetRoleList() ?? new List<RoleInfo>()))
		{
			if (roleInfo.RoleType == 1 && !hashSet.Contains(roleInfo.Id))
			{
				hashSet.Add(roleInfo.Id);
				int id = roleInfo.Id;
				RoleInstance roleInstance;
				bool flag = this.RoleInstanceMap.TryGetValue(id, out roleInstance);
				bool flag2 = RoleDevUtils.GetRoleTypeTagByRoleId(id) == ERoleTypeTag.Forecast;
				if ((flag || !this.IsMainRole(id)) && !flag2 && ModelBase<HandBookModel>.Instance.GetRoleCanShowInHandBook(id))
				{
					list.Add(id);
				}
			}
		}
		this.SortRoleIdList(list);
		return list;
	}

	// Token: 0x0601499F RID: 84383 RVA: 0x005B4750 File Offset: 0x005B2950
	public void SortRoleDataList(List<RoleDataBase> resultList)
	{
		resultList.Sort(new Comparison<RoleDataBase>(this.SortByFormationLevelQuality));
	}

	// Token: 0x060149A0 RID: 84384 RVA: 0x005B4764 File Offset: 0x005B2964
	private void SortRoleIdList(List<int> roleIdList)
	{
		roleIdList.Sort(delegate(int a, int b)
		{
			RoleDataBase roleDataByIdOrCreateDefault = this.GetRoleDataByIdOrCreateDefault(a);
			RoleDataBase roleDataByIdOrCreateDefault2 = this.GetRoleDataByIdOrCreateDefault(b);
			if (roleDataByIdOrCreateDefault == null || roleDataByIdOrCreateDefault2 == null)
			{
				return 0;
			}
			return this.SortByFormationLevelQuality(roleDataByIdOrCreateDefault, roleDataByIdOrCreateDefault2);
		});
	}

	// Token: 0x060149A1 RID: 84385 RVA: 0x005B4778 File Offset: 0x005B2978
	private int SortByFormationLevelQuality(RoleDataBase a, RoleDataBase b)
	{
		int num = this.SortFormation(a, b);
		if (num != 0)
		{
			return num;
		}
		int num2 = this.SortLevel(a, b);
		if (num2 != 0)
		{
			return num2;
		}
		return this.SortQuality(a, b);
	}

	// Token: 0x060149A2 RID: 84386 RVA: 0x005B47AC File Offset: 0x005B29AC
	private int SortFormation(RoleDataBase a, RoleDataBase b)
	{
		int num = -1;
		int num2 = -1;
		List<SceneTeamItem> teamItems = ModelBase<SceneTeamModel>.Instance.GetTeamItems(false);
		for (int i = 0; i < teamItems.Count; i++)
		{
			SceneTeamItem sceneTeamItem = teamItems[i];
			if (a.GetDataId() == sceneTeamItem.GetConfigId)
			{
				num = i;
			}
			if (b.GetDataId() == sceneTeamItem.GetConfigId)
			{
				num2 = i;
			}
		}
		SceneTeamItem sceneTeamItem2 = (num >= 0 && num < teamItems.Count) ? teamItems[num] : null;
		object obj = (num2 >= 0 && num2 < teamItems.Count) ? teamItems[num2] : null;
		bool flag = sceneTeamItem2 != null;
		bool flag2 = obj != null;
		if (!flag && !flag2)
		{
			return 0;
		}
		if (flag != flag2)
		{
			int num3 = (flag > false) ? 1 : 0;
			return ((flag2 > false) ? 1 : 0) - num3;
		}
		return num - num2;
	}

	// Token: 0x060149A3 RID: 84387 RVA: 0x005B4868 File Offset: 0x005B2A68
	private int SortLevel(RoleDataBase a, RoleDataBase b)
	{
		RoleLevelData levelData = a.GetLevelData();
		RoleLevelData levelData2 = b.GetLevelData();
		if (levelData.GetLevel() != levelData2.GetLevel())
		{
			return levelData2.GetLevel() - levelData.GetLevel();
		}
		if (levelData.GetBreachLevel() != levelData2.GetBreachLevel())
		{
			return levelData2.GetBreachLevel() - levelData.GetBreachLevel();
		}
		return 0;
	}

	// Token: 0x060149A4 RID: 84388 RVA: 0x005B48BC File Offset: 0x005B2ABC
	private int SortQuality(RoleDataBase a, RoleDataBase b)
	{
		int qualityId = a.GetRoleConfig().QualityId;
		int qualityId2 = b.GetRoleConfig().QualityId;
		if (qualityId != qualityId2)
		{
			return qualityId2 - qualityId;
		}
		return 0;
	}

	// Token: 0x060149A5 RID: 84389 RVA: 0x005B48F0 File Offset: 0x005B2AF0
	[NullableContext(2)]
	public RoleDataBase GetRoleDataByIdOrCreateDefault(int roleId)
	{
		if (ConfigBase<RoleConfig>.Instance.GetRoleConfig(roleId) == null)
		{
			return null;
		}
		RoleInstance result;
		if (!this.RoleInstanceMap.TryGetValue(roleId, out result))
		{
			result = new RoleInstance(roleId);
		}
		return result;
	}

	// Token: 0x060149A6 RID: 84390 RVA: 0x005B492C File Offset: 0x005B2B2C
	protected override bool OnClear()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnChangeRole, new Action<EntityHandle, EntityHandle>(this.OnChangeRole));
		ModelBase<NewFlagModel>.Instance.SaveNewFlagConfig(ELocalStoragePlayerKey.RoleDataItem);
		this.IsInRoleTrial = false;
		this.RoleInstanceMap.Clear();
		this.RoleRobotDataMap.Clear();
		this.RoleCommonRobotDataMap.Clear();
		this.RoleSpecialRobotDataMap.Clear();
		return true;
	}

	// Token: 0x060149A7 RID: 84391 RVA: 0x005B4998 File Offset: 0x005B2B98
	public void UpdateRoleInfoByServerData(roleInfo[] roleDataList)
	{
		foreach (roleInfo roleInfo in roleDataList)
		{
			this.UpdateRoleInfo(roleInfo);
		}
		Singleton<EventSystem>.Instance.Emit(EEventName.RoleInfoUpdate);
	}

	// Token: 0x060149A8 RID: 84392 RVA: 0x005B49D0 File Offset: 0x005B2BD0
	public void RoleChange(int sourceRoleId, roleInfo roleInfo)
	{
		this.RoleInstanceMap.Remove(sourceRoleId);
		this.UpdateRoleInfo(roleInfo);
		this.UpdateMainRoleMap(roleInfo.RoleId);
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.RoleSystemDeleteRole, sourceRoleId);
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.RoleSystemChangeRole, roleInfo.RoleId);
	}

	// Token: 0x060149A9 RID: 84393 RVA: 0x005B4A24 File Offset: 0x005B2C24
	public void UpdateRoleInfo(roleInfo roleInfo)
	{
		RoleInstance roleInstance = null;
		if (this.RoleInstanceMap.ContainsKey(roleInfo.RoleId))
		{
			roleInstance = this.RoleInstanceMap[roleInfo.RoleId];
		}
		if (roleInstance == null)
		{
			roleInstance = new RoleInstance(roleInfo.RoleId);
			this.RoleInstanceMap[roleInfo.RoleId] = roleInstance;
		}
		if (this.IsMainRole(roleInfo.RoleId))
		{
			Singleton<EventSystem>.Instance.Emit<EFunction>(EEventName.RefreshMenuSetting, EFunction.GENDERSETTING);
		}
		roleInstance.RefreshRoleInfo(roleInfo);
	}

	// Token: 0x060149AA RID: 84394 RVA: 0x005B4AA0 File Offset: 0x005B2CA0
	public void UpdateMainRoleMap(int newMainRoleId)
	{
		foreach (int key in this.GetMainRoleSet())
		{
			this.MainRoleIdMap[key] = newMainRoleId;
		}
	}

	// Token: 0x060149AB RID: 84395 RVA: 0x005B4AFC File Offset: 0x005B2CFC
	public void RoleLevelUp(int roleId, int exp, int level)
	{
		RoleInstance roleInstanceById = this.GetRoleInstanceById(roleId);
		RoleLevelData levelData = roleInstanceById.GetLevelData();
		int level2 = levelData.GetLevel();
		if (roleInstanceById != null)
		{
			levelData.SetLevel(level);
			levelData.SetExp(exp);
		}
		Singleton<EventSystem>.Instance.Emit(EEventName.RoleInfoUpdate);
		if (level2 < level)
		{
			Singleton<EventSystem>.Instance.Emit<int, int, int>(EEventName.RoleLevelUp, roleId, exp, level);
		}
	}

	// Token: 0x060149AC RID: 84396 RVA: 0x005B4B58 File Offset: 0x005B2D58
	public void RoleLevelUpReceiveItem(Dictionary<int, int> itemMap)
	{
		List<TItem> list = new List<TItem>();
		foreach (KeyValuePair<int, int> keyValuePair in itemMap)
		{
			int key = keyValuePair.Key;
			TItem item = new TItem
			{
				ItemData = new InventoryDefine.GetItemData(key, 0),
				Count = keyValuePair.Value
			};
			list.Add(item);
		}
		Singleton<EventSystem>.Instance.Emit<IReadOnlyList<TItem>>(EEventName.RoleLevelUpReceiveItem, list);
	}

	// Token: 0x060149AD RID: 84397 RVA: 0x005B4BF0 File Offset: 0x005B2DF0
	public void RoleBreakUp(int roleId, int breakLevel)
	{
		RoleInstance roleInstanceById = this.GetRoleInstanceById(roleId);
		if (roleInstanceById != null)
		{
			roleInstanceById.GetLevelData().SetBreachLevel(breakLevel);
		}
		Singleton<EventSystem>.Instance.Emit(EEventName.RoleInfoUpdate);
		Singleton<EventSystem>.Instance.Emit<int, int>(EEventName.RoleBreakUp, roleId, breakLevel);
	}

	// Token: 0x060149AE RID: 84398 RVA: 0x005B4C38 File Offset: 0x005B2E38
	public void RoleSkillLevelUp(int roleId, ArrayIntInt skillInfo)
	{
		RoleInstance roleInstanceById = this.GetRoleInstanceById(roleId);
		if (roleInstanceById != null)
		{
			roleInstanceById.RefreshSkillInfo(skillInfo.Key, skillInfo.Value);
		}
		Singleton<EventSystem>.Instance.Emit<int, ArrayIntInt>(EEventName.RoleSkillLevelUp, roleId, skillInfo);
	}

	// Token: 0x060149AF RID: 84399 RVA: 0x005B4C74 File Offset: 0x005B2E74
	public void RoleNameUpdate(int roleId, string name)
	{
		RoleInstance roleInstanceById = this.GetRoleInstanceById(roleId);
		if (roleInstanceById != null)
		{
			roleInstanceById.SetRoleName(name);
			Singleton<EventSystem>.Instance.Emit(EEventName.RoleRefreshName);
		}
	}

	// Token: 0x060149B0 RID: 84400 RVA: 0x005B4CA4 File Offset: 0x005B2EA4
	public void RoleAttrUpdate(int roleId, ArrayIntInt[] baseAttr, ArrayIntInt[] addAttr)
	{
		RoleInstance roleInstanceById = this.GetRoleInstanceById(roleId);
		if (roleInstanceById != null)
		{
			roleInstanceById.RefreshRoleAttr(baseAttr, addAttr);
		}
	}

	// Token: 0x060149B1 RID: 84401 RVA: 0x005B4CC4 File Offset: 0x005B2EC4
	public void RoleResonanceLockFinish(PbRoleResonLockFinishNotify notify)
	{
		this.RoleInstanceMap[notify.RoleId].GetResonanceData().SetResonanceLock(notify.ResonId);
	}

	// Token: 0x060149B2 RID: 84402 RVA: 0x005B4CE7 File Offset: 0x005B2EE7
	public RoleViewAgent GetRoleViewAgent(ERoleAgentType agentType)
	{
		if (agentType == ERoleAgentType.Preview)
		{
			return new RolePreviewAgent();
		}
		if (agentType != ERoleAgentType.RoleNewJoin)
		{
			return new RoleViewAgent();
		}
		return new RoleNewJoinAgent();
	}

	// Token: 0x17001B12 RID: 6930
	// (get) Token: 0x060149B3 RID: 84403 RVA: 0x005B4D04 File Offset: 0x005B2F04
	// (set) Token: 0x060149B4 RID: 84404 RVA: 0x005B4D0C File Offset: 0x005B2F0C
	public bool IsShowMultiSkillDesc
	{
		get
		{
			return this.IsShowMultiSkillDescInternal;
		}
		set
		{
			this.IsShowMultiSkillDescInternal = value;
		}
	}

	// Token: 0x17001B13 RID: 6931
	// (get) Token: 0x060149B5 RID: 84405 RVA: 0x005B4D15 File Offset: 0x005B2F15
	// (set) Token: 0x060149B6 RID: 84406 RVA: 0x005B4D1F File Offset: 0x005B2F1F
	public bool IsShowSkillResume
	{
		get
		{
			return LocalStorage.GetPlayer<bool>(ELocalStoragePlayerKey.ShowSkillResume, false);
		}
		set
		{
			LocalStorage.SetPlayer<bool>(ELocalStoragePlayerKey.ShowSkillResume, value);
		}
	}

	// Token: 0x17001B14 RID: 6932
	// (get) Token: 0x060149B7 RID: 84407 RVA: 0x005B4D2A File Offset: 0x005B2F2A
	// (set) Token: 0x060149B8 RID: 84408 RVA: 0x005B4D34 File Offset: 0x005B2F34
	public bool IsShowSkillShowTag
	{
		get
		{
			return LocalStorage.GetPlayer<bool>(ELocalStoragePlayerKey.ShowSkillShowTag, true);
		}
		set
		{
			LocalStorage.SetPlayer<bool>(ELocalStoragePlayerKey.ShowSkillShowTag, value);
		}
	}

	// Token: 0x060149B9 RID: 84409 RVA: 0x005B4D3F File Offset: 0x005B2F3F
	public bool IsSkillShowTagUnlocked()
	{
		return ModelBase<FunctionModel>.Instance.IsOpen(EFunctionType.RoleDev);
	}

	// Token: 0x060149BA RID: 84410 RVA: 0x005B4D50 File Offset: 0x005B2F50
	public ERoleSkillDescType GetRoleSkillDescType()
	{
		if (ModelBase<GameModeModel>.Instance.IsMulti)
		{
			return ERoleSkillDescType.MultiDesc;
		}
		return ERoleSkillDescType.ResumeDesc;
	}

	// Token: 0x060149BB RID: 84411 RVA: 0x005B4D64 File Offset: 0x005B2F64
	public RoleInstance[] GetRoleList()
	{
		List<int> list = new List<int>(this.RoleInstanceMap.Keys);
		this.SortRoleList(list);
		List<RoleInstance> list2 = new List<RoleInstance>();
		foreach (int key in list)
		{
			RoleInstance roleInstance = this.RoleInstanceMap[key];
			if (roleInstance.GetRoleConfig().RoleType == 1)
			{
				list2.Add(roleInstance);
			}
		}
		return list2.ToArray();
	}

	// Token: 0x060149BC RID: 84412 RVA: 0x005B4DF8 File Offset: 0x005B2FF8
	public RoleInstance[] GetRoleListWithoutMainRole()
	{
		List<int> list = new List<int>(this.RoleInstanceMap.Keys);
		this.SortRoleList(list);
		List<RoleInstance> list2 = new List<RoleInstance>();
		foreach (int num in list)
		{
			RoleInstance roleInstance = this.RoleInstanceMap[num];
			if (roleInstance.GetRoleConfig().RoleType == 1 && !this.IsMainRole(num))
			{
				list2.Add(roleInstance);
			}
		}
		return list2.ToArray();
	}

	// Token: 0x060149BD RID: 84413 RVA: 0x005B4E98 File Offset: 0x005B3098
	public List<RoleDataBase> GetRoleDataList(bool includeRobots = false)
	{
		List<RoleDataBase> list = new List<RoleDataBase>();
		foreach (int key in new List<int>(this.RoleInstanceMap.Keys))
		{
			RoleInstance roleInstance = this.RoleInstanceMap[key];
			if (roleInstance.GetRoleConfig().RoleType == 1)
			{
				list.Add(roleInstance);
			}
		}
		if (includeRobots)
		{
			foreach (int key2 in new List<int>(this.RoleSpecialRobotDataMap.Keys))
			{
				RoleSpecialRobotData roleSpecialRobotData;
				if (this.RoleSpecialRobotDataMap.TryGetValue(key2, out roleSpecialRobotData) && roleSpecialRobotData != null && roleSpecialRobotData.IsVisibleInFormation())
				{
					list.Add(roleSpecialRobotData);
				}
			}
		}
		list.Sort((RoleDataBase a, RoleDataBase b) => this.CompareByCondition(a.GetDataId(), b.GetDataId()));
		return list;
	}

	// Token: 0x060149BE RID: 84414 RVA: 0x005B4F9C File Offset: 0x005B319C
	public Dictionary<int, RoleDataBase> GetRoleDataMap(bool includeRobots = false)
	{
		Dictionary<int, RoleInstance> roleMap = this.GetRoleMap();
		if (!includeRobots)
		{
			Dictionary<int, RoleDataBase> dictionary = new Dictionary<int, RoleDataBase>();
			foreach (KeyValuePair<int, RoleInstance> keyValuePair in roleMap)
			{
				dictionary[keyValuePair.Key] = keyValuePair.Value;
			}
			return dictionary;
		}
		Dictionary<int, RoleDataBase> dictionary2 = new Dictionary<int, RoleDataBase>();
		foreach (KeyValuePair<int, RoleInstance> keyValuePair2 in roleMap)
		{
			dictionary2[keyValuePair2.Key] = keyValuePair2.Value;
		}
		foreach (KeyValuePair<int, RoleSpecialRobotData> keyValuePair3 in this.RoleSpecialRobotDataMap)
		{
			RoleSpecialRobotData value = keyValuePair3.Value;
			if (value != null && value.IsVisibleInFormation())
			{
				dictionary2[keyValuePair3.Key] = keyValuePair3.Value;
			}
		}
		return dictionary2;
	}

	// Token: 0x060149BF RID: 84415 RVA: 0x005B50C4 File Offset: 0x005B32C4
	public Dictionary<int, RoleInstance> GetRoleMap()
	{
		return this.RoleInstanceMap;
	}

	// Token: 0x060149C0 RID: 84416 RVA: 0x005B50CC File Offset: 0x005B32CC
	public Dictionary<int, RoleRobotData> GetRoleRobotMap()
	{
		return this.RoleRobotDataMap;
	}

	// Token: 0x060149C1 RID: 84417 RVA: 0x005B50D4 File Offset: 0x005B32D4
	public Dictionary<int, RoleRobotData> GetCommonRoleRobotMap()
	{
		return this.RoleCommonRobotDataMap;
	}

	// Token: 0x060149C2 RID: 84418 RVA: 0x005B50DC File Offset: 0x005B32DC
	public Dictionary<int, RoleSpecialRobotData> GetRoleFormationRobotMap()
	{
		return this.RoleSpecialRobotDataMap;
	}

	// Token: 0x060149C3 RID: 84419 RVA: 0x005B50E4 File Offset: 0x005B32E4
	public int? GetBattleTeamFirstRoleId()
	{
		SceneTeamItem getCurrentTeamItem = ModelBase<SceneTeamModel>.Instance.GetCurrentTeamItem;
		if (getCurrentTeamItem == null)
		{
			return null;
		}
		return new int?(getCurrentTeamItem.GetConfigId);
	}

	// Token: 0x060149C4 RID: 84420 RVA: 0x005B5114 File Offset: 0x005B3314
	private int CompareByCondition(int a, int b)
	{
		int num = -1;
		int num2 = -1;
		List<SceneTeamItem> teamItems = ModelBase<SceneTeamModel>.Instance.GetTeamItems(true);
		for (int i = 0; i < teamItems.Count; i++)
		{
			SceneTeamItem sceneTeamItem = teamItems[i];
			if (a == sceneTeamItem.GetConfigId)
			{
				num = i;
			}
			if (b == sceneTeamItem.GetConfigId)
			{
				num2 = i;
			}
		}
		SceneTeamItem sceneTeamItem2 = (num >= 0 && num < teamItems.Count) ? teamItems[num] : null;
		object obj = (num2 >= 0 && num2 < teamItems.Count) ? teamItems[num2] : null;
		bool flag = sceneTeamItem2 != null;
		bool flag2 = obj != null;
		if (flag != flag2)
		{
			int num3 = (flag > false) ? 1 : 0;
			return ((flag2 > false) ? 1 : 0) - num3;
		}
		if (flag)
		{
			return num - num2;
		}
		RoleDataBase roleDataById = this.GetRoleDataById(a, true);
		RoleDataBase roleDataById2 = this.GetRoleDataById(b, true);
		return this.DefaultSortFunc(roleDataById, roleDataById2);
	}

	// Token: 0x060149C5 RID: 84421 RVA: 0x005B51E0 File Offset: 0x005B33E0
	private void SortRoleList(List<int> roleIdList)
	{
		roleIdList.Sort(delegate(int a, int b)
		{
			int num = -1;
			int num2 = -1;
			List<SceneTeamItem> teamItems = ModelBase<SceneTeamModel>.Instance.GetTeamItems(true);
			for (int i = 0; i < teamItems.Count; i++)
			{
				SceneTeamItem sceneTeamItem = teamItems[i];
				if (a == sceneTeamItem.GetConfigId)
				{
					num = i;
				}
				if (b == sceneTeamItem.GetConfigId)
				{
					num2 = i;
				}
			}
			SceneTeamItem sceneTeamItem2 = (num >= 0) ? teamItems[num] : null;
			object obj = (num2 >= 0) ? teamItems[num2] : null;
			bool flag = sceneTeamItem2 != null;
			bool flag2 = obj != null;
			if (flag != flag2)
			{
				int num3 = (flag > false) ? 1 : 0;
				return ((flag2 > false) ? 1 : 0) - num3;
			}
			if (flag)
			{
				return num - num2;
			}
			RoleDataBase roleDataById = this.GetRoleDataById(a, true);
			RoleDataBase roleDataById2 = this.GetRoleDataById(b, true);
			return this.DefaultSortFunc(roleDataById, roleDataById2);
		});
	}

	// Token: 0x060149C6 RID: 84422 RVA: 0x005B51F4 File Offset: 0x005B33F4
	public int DefaultSortFunc(RoleDataBase a, RoleDataBase b)
	{
		RoleLevelData levelData = a.GetLevelData();
		RoleLevelData levelData2 = b.GetLevelData();
		if (levelData.GetLevel() != levelData2.GetLevel())
		{
			return levelData2.GetLevel() - levelData.GetLevel();
		}
		if (a.GetRoleConfig().QualityId != b.GetRoleConfig().QualityId)
		{
			return b.GetRoleConfig().QualityId - a.GetRoleConfig().QualityId;
		}
		if (a.GetRoleConfig().Priority != b.GetRoleConfig().Priority)
		{
			return b.GetRoleConfig().Priority - a.GetRoleConfig().Priority;
		}
		return -1;
	}

	// Token: 0x060149C7 RID: 84423 RVA: 0x005B52A4 File Offset: 0x005B34A4
	[NullableContext(2)]
	public RoleDataBase GetRoleDataById(int id, bool isSelf = true)
	{
		RoleDataBase roleDataBase = null;
		if (!isSelf)
		{
			return new RoleOnlineInstanceData(id);
		}
		if (id > 100000)
		{
			roleDataBase = this.GetRoleRobotData(id);
		}
		else
		{
			if (this.RoleInstanceMap.ContainsKey(id))
			{
				roleDataBase = this.RoleInstanceMap[id];
			}
			if (roleDataBase == null && this.IsMainRole(id))
			{
				int? newMainRoleId = this.GetNewMainRoleId(id);
				if (newMainRoleId != null && this.RoleInstanceMap.ContainsKey(newMainRoleId.Value))
				{
					roleDataBase = this.RoleInstanceMap[newMainRoleId.Value];
				}
			}
		}
		return roleDataBase;
	}

	// Token: 0x060149C8 RID: 84424 RVA: 0x005B5330 File Offset: 0x005B3530
	public int? GetNewMainRoleId(int oldMainRoleId)
	{
		if (this.MainRoleIdMap.ContainsKey(oldMainRoleId))
		{
			return new int?(this.MainRoleIdMap[oldMainRoleId]);
		}
		return null;
	}

	// Token: 0x060149C9 RID: 84425 RVA: 0x005B5368 File Offset: 0x005B3568
	[NullableContext(2)]
	public RoleDataBase GetRoleDataByTrialRoleId(int trialRoleId)
	{
		RoleDataBase roleDataBase = null;
		if (!RoleUtils.IsTrialRole(trialRoleId))
		{
			return roleDataBase;
		}
		int trailRoleRealRoleId = RoleUtils.GetTrailRoleRealRoleId(trialRoleId);
		RoleInstance roleInstance;
		if (this.RoleInstanceMap.TryGetValue(trailRoleRealRoleId, out roleInstance))
		{
			roleDataBase = roleInstance;
		}
		if (roleDataBase == null && this.IsMainRole(trailRoleRealRoleId))
		{
			roleDataBase = this.GetCurSelectMainRoleInstance();
		}
		if (roleDataBase == null)
		{
			roleDataBase = this.GetRoleRobotData(trialRoleId);
		}
		return roleDataBase;
	}

	// Token: 0x060149CA RID: 84426 RVA: 0x005B53BC File Offset: 0x005B35BC
	public RoleRobotData GetRoleRobotData(int id)
	{
		RoleRobotData roleRobotData = null;
		if (this.RoleRobotDataMap.ContainsKey(id))
		{
			roleRobotData = this.RoleRobotDataMap[id];
		}
		if (roleRobotData == null)
		{
			if (RoleUtils.IsSpecialTrialRole(id))
			{
				roleRobotData = new RoleSpecialRobotData(id);
				this.RoleSpecialRobotDataMap[id] = (roleRobotData as RoleSpecialRobotData);
			}
			else
			{
				roleRobotData = new RoleRobotData(id);
				this.RoleCommonRobotDataMap[id] = roleRobotData;
			}
			this.RoleRobotDataMap[id] = roleRobotData;
		}
		return roleRobotData;
	}

	// Token: 0x060149CB RID: 84427 RVA: 0x005B5430 File Offset: 0x005B3630
	public bool HasAnyTrialRole()
	{
		using (List<int>.Enumerator enumerator = this.GetRoleSystemRoleList(false).GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current > 100000)
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x060149CC RID: 84428 RVA: 0x005B548C File Offset: 0x005B368C
	[NullableContext(2)]
	public RoleInstance GetRoleInstanceById(int id)
	{
		if (this.RoleInstanceMap.ContainsKey(id))
		{
			return this.RoleInstanceMap[id];
		}
		return null;
	}

	// Token: 0x060149CD RID: 84429 RVA: 0x005B54AC File Offset: 0x005B36AC
	public string GetRoleName(int roleId, int? playerId = null)
	{
		RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(roleId, true);
		if (roleDataById != null)
		{
			return roleDataById.GetName(playerId);
		}
		return ConfigMultiTextLang.GetLocalTextNew(ConfigBase<RoleConfig>.Instance.GetRoleConfig(roleId).Value.Name, null);
	}

	// Token: 0x060149CE RID: 84430 RVA: 0x005B54F4 File Offset: 0x005B36F4
	private int SimulateAutoAddExpItem(int needExp, ISelectedData[] sourceList, Func<ISelectedData, int> getExp)
	{
		int num = 0;
		ModelBase<WeaponModel>.Instance.AutoAddExpItemEx(needExp, sourceList, getExp);
		foreach (ISelectedData selectedData in sourceList)
		{
			num += selectedData.SelectedCount * getExp(selectedData);
		}
		return num;
	}

	// Token: 0x060149CF RID: 84431 RVA: 0x005B5538 File Offset: 0x005B3738
	public ISelectedData[] GetExpItemInInventory()
	{
		List<ISelectedData> list = new List<ISelectedData>();
		foreach (ItemInfo itemInfo in ModelBase<RoleModel>.Instance.GetRoleCostExpList())
		{
			SelectedData item = new SelectedData
			{
				IncId = 0,
				ItemId = itemInfo.Id,
				Count = ModelBase<InventoryModel>.Instance.GetCommonItemCount(itemInfo.Id, 0),
				SelectedCount = 0
			};
			list.Add(item);
		}
		return list.ToArray();
	}

	// Token: 0x060149D0 RID: 84432 RVA: 0x005B55B4 File Offset: 0x005B37B4
	public int GetSelectLevelUpItemNeedMoney(int roleId)
	{
		int levelUpNeedExp = this.GetRoleInstanceById(roleId).GetLevelData().GetLevelUpNeedExp();
		ISelectedData[] expItemInInventory = this.GetExpItemInInventory();
		int exp = this.SimulateAutoAddExpItem(levelUpNeedExp, expItemInInventory, (ISelectedData data) => this.GetRoleExpItemExp(data.ItemId).Value);
		return this.GetMoneyToLevelUp(exp);
	}

	// Token: 0x060149D1 RID: 84433 RVA: 0x005B55F8 File Offset: 0x005B37F8
	public int GetMoneyToLevelUp(int exp)
	{
		int value = ConfigCommonParamById.GetIntConfig("ExpConversionCount").Value;
		return (int)Math.Ceiling((double)(exp * value) / 1000.0);
	}

	// Token: 0x060149D2 RID: 84434 RVA: 0x005B562C File Offset: 0x005B382C
	public bool GetHasEnoughMoneyLevelUp(int roleId)
	{
		int selectLevelUpItemNeedMoney = this.GetSelectLevelUpItemNeedMoney(roleId);
		int playerMoney = ModelBase<PlayerInfoModel>.Instance.GetPlayerMoney(2);
		return selectLevelUpItemNeedMoney <= playerMoney;
	}

	// Token: 0x060149D3 RID: 84435 RVA: 0x005B5654 File Offset: 0x005B3854
	public bool GetSelectHasEnoughItemToLevelUp(int roleId)
	{
		RoleInstance roleInstanceById = this.GetRoleInstanceById(roleId);
		RoleLevelData roleLevelData = (roleInstanceById != null) ? roleInstanceById.GetLevelData() : null;
		int? num = (roleLevelData != null) ? new int?(roleLevelData.GetLevelUpNeedExp()) : null;
		int num2 = 0;
		foreach (ItemInfo itemInfo in this.GetRoleCostExpList())
		{
			int commonItemCount = ModelBase<InventoryModel>.Instance.GetCommonItemCount(itemInfo.Id, 0);
			num2 += this.GetRoleExpItemExp(itemInfo.Id).Value * commonItemCount;
		}
		return num2 >= num.Value;
	}

	// Token: 0x060149D4 RID: 84436 RVA: 0x005B56F0 File Offset: 0x005B38F0
	public ERoleBreachState GetRoleBreachState(int roleId)
	{
		RoleLevelData levelData = this.GetRoleInstanceById(roleId).GetLevelData();
		RoleBreach? breachConfig = levelData.GetBreachConfig(levelData.GetBreachLevel() + 1);
		if (breachConfig == null)
		{
			return ERoleBreachState.MaxLevel;
		}
		if (!ControllerBase<LevelGeneralController>.Instance.CheckCondition(breachConfig.Value.ConditionId.ToString(), null, true, Array.Empty<object>()))
		{
			return ERoleBreachState.NoEnoughCondition;
		}
		foreach (KeyValuePair<int, int> keyValuePair in breachConfig.Value.BreachConsume())
		{
			if (keyValuePair.Key == 2)
			{
				if (ModelBase<PlayerInfoModel>.Instance.GetPlayerMoney(2) < keyValuePair.Value)
				{
					return ERoleBreachState.NoEnoughMoney;
				}
			}
			else if (ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(keyValuePair.Key, 0) < keyValuePair.Value)
			{
				return ERoleBreachState.NoEnoughMaterial;
			}
		}
		return ERoleBreachState.CanBreach;
	}

	// Token: 0x060149D5 RID: 84437 RVA: 0x005B57E0 File Offset: 0x005B39E0
	public bool GetRoleNeedBreakUp(int roleId)
	{
		RoleInstance roleInstanceById = this.GetRoleInstanceById(roleId);
		return roleInstanceById != null && roleInstanceById.GetLevelData().GetRoleNeedBreakUp();
	}

	// Token: 0x060149D6 RID: 84438 RVA: 0x005B5808 File Offset: 0x005B3A08
	public ItemInfo[] GetRoleCostExpList()
	{
		List<ItemInfo> list = new List<ItemInfo>();
		IReadOnlyList<RoleExpItem> roleExpItemList = ConfigBase<RoleConfig>.Instance.GetRoleExpItemList();
		if (roleExpItemList != null)
		{
			foreach (RoleExpItem roleExpItem in roleExpItemList)
			{
				ItemInfo? config = ConfigBase<CSharpScript.Game.Module.Item.ItemConfig>.Instance.GetConfig(roleExpItem.Id);
				if (config != null)
				{
					list.Add(config.Value);
				}
			}
		}
		return list.ToArray();
	}

	// Token: 0x060149D7 RID: 84439 RVA: 0x005B588C File Offset: 0x005B3A8C
	public int? GetRoleExpItemExp(int itemId)
	{
		return ConfigBase<RoleConfig>.Instance.GetRoleExpItemExp(itemId);
	}

	// Token: 0x060149D8 RID: 84440 RVA: 0x005B589C File Offset: 0x005B3A9C
	public RoleInstance[] GetAllRoleList()
	{
		List<RoleInstance> list = new List<RoleInstance>();
		foreach (KeyValuePair<int, RoleInstance> keyValuePair in this.RoleInstanceMap)
		{
			list.Add(keyValuePair.Value);
		}
		return list.ToArray();
	}

	// Token: 0x060149D9 RID: 84441 RVA: 0x005B5904 File Offset: 0x005B3B04
	public List<int> GetRoleIdList()
	{
		List<int> list = new List<int>(this.RoleInstanceMap.Keys);
		this.SortRoleList(list);
		List<int> list2 = new List<int>();
		foreach (int num in list)
		{
			if (this.RoleInstanceMap[num].GetRoleConfig().RoleType == 1)
			{
				list2.Add(num);
			}
		}
		return list2;
	}

	// Token: 0x060149DA RID: 84442 RVA: 0x005B5990 File Offset: 0x005B3B90
	public RoleInstance[] GetOfficialRoleList()
	{
		List<RoleInstance> list = new List<RoleInstance>();
		foreach (KeyValuePair<int, RoleInstance> keyValuePair in this.RoleInstanceMap)
		{
			RoleInstance value = keyValuePair.Value;
			if (value.GetRoleConfig().RoleType == 1 && !value.IsTrialRole())
			{
				list.Add(value);
			}
		}
		return list.ToArray();
	}

	// Token: 0x060149DB RID: 84443 RVA: 0x005B5A14 File Offset: 0x005B3C14
	public UiDynamicTab[] GetRoleTabList()
	{
		List<UiDynamicTab> viewTabList = ConfigBase<DynamicTabConfig>.Instance.GetViewTabList(EUiViewName.RoleRootView);
		int count = viewTabList.Count;
		List<UiDynamicTab> list = new List<UiDynamicTab>();
		for (int i = 0; i < count; i++)
		{
			UiDynamicTab item = viewTabList[i];
			if (ModelBase<FunctionModel>.Instance.IsOpen(item.FunctionId))
			{
				list.Add(item);
			}
		}
		return list.ToArray();
	}

	// Token: 0x060149DC RID: 84444 RVA: 0x005B5A7C File Offset: 0x005B3C7C
	public UiDynamicTab[] GetNormalRoleTabList()
	{
		UiDynamicTab[] roleTabList = this.GetRoleTabList();
		List<UiDynamicTab> list = new List<UiDynamicTab>();
		foreach (UiDynamicTab item in roleTabList)
		{
			if (item.ChildViewName == EUiTabViewName.RoleAttributeTabView || item.ChildViewName == EUiTabViewName.RoleWeaponTabView || item.ChildViewName == EUiTabViewName.RolePhantomTabView || item.ChildViewName == EUiTabViewName.RoleSkillTabView || item.ChildViewName == EUiTabViewName.RoleResonanceTabNewView || item.ChildViewName == EUiTabViewName.RoleFavorTabView)
			{
				list.Add(item);
			}
		}
		return list.ToArray();
	}

	// Token: 0x060149DD RID: 84445 RVA: 0x005B5B50 File Offset: 0x005B3D50
	public UiDynamicTab[] GetTrialRoleTabList()
	{
		UiDynamicTab[] roleTabList = this.GetRoleTabList();
		List<UiDynamicTab> list = new List<UiDynamicTab>();
		foreach (UiDynamicTab item in roleTabList)
		{
			if (item.ChildViewName == EUiTabViewName.RoleAttributeTabView || item.ChildViewName == EUiTabViewName.RoleWeaponTabView || item.ChildViewName == EUiTabViewName.RolePhantomTabView || item.ChildViewName == EUiTabViewName.RoleSkillTabView || item.ChildViewName == EUiTabViewName.RoleResonanceTabNewView)
			{
				list.Add(item);
			}
		}
		return list.ToArray();
	}

	// Token: 0x060149DE RID: 84446 RVA: 0x005B5C0C File Offset: 0x005B3E0C
	public UiDynamicTab[] GetSpecialTrialRoleTabList()
	{
		UiDynamicTab[] roleTabList = this.GetRoleTabList();
		if (roleTabList == null)
		{
			return new UiDynamicTab[0];
		}
		List<UiDynamicTab> list = new List<UiDynamicTab>();
		foreach (UiDynamicTab item in roleTabList)
		{
			if (item.ChildViewName == EUiTabViewName.RoleAttributeTabView || item.ChildViewName == EUiTabViewName.RoleWeaponTabView || item.ChildViewName == EUiTabViewName.RolePhantomTabView || item.ChildViewName == EUiTabViewName.RoleSkillTabView || item.ChildViewName == EUiTabViewName.RoleResonanceTabNewView)
			{
				list.Add(item);
			}
		}
		return list.ToArray();
	}

	// Token: 0x060149DF RID: 84447 RVA: 0x005B5CD8 File Offset: 0x005B3ED8
	public UiDynamicTab[] GetPreviewRoleTabList()
	{
		UiDynamicTab[] roleTabList = this.GetRoleTabList();
		List<UiDynamicTab> list = new List<UiDynamicTab>();
		foreach (UiDynamicTab item in roleTabList)
		{
			if (item.ChildViewName == EUiTabViewName.RolePreviewAttributeTabView || item.ChildViewName == EUiTabViewName.RoleSkillTabView || item.ChildViewName == EUiTabViewName.RoleResonanceTabNewView)
			{
				list.Add(item);
			}
		}
		return list.ToArray();
	}

	// Token: 0x060149E0 RID: 84448 RVA: 0x005B5D5D File Offset: 0x005B3F5D
	public UiDynamicTab[] GetRoleTabListByUiParam(ERoleSystemMode roleMode)
	{
		switch (roleMode)
		{
		case ERoleSystemMode.Trial:
			return this.GetTrialRoleTabList();
		case ERoleSystemMode.Normal:
		case ERoleSystemMode.RoleNewJoin:
			return this.GetNormalRoleTabList();
		case ERoleSystemMode.Preview:
			return this.GetPreviewRoleTabList();
		case ERoleSystemMode.SpecialTrial:
			return this.GetSpecialTrialRoleTabList();
		default:
			return this.GetNormalRoleTabList();
		}
	}

	// Token: 0x060149E1 RID: 84449 RVA: 0x005B5DA0 File Offset: 0x005B3FA0
	public bool RedDotRoleSelectionListCondition()
	{
		HashSet<int> newFlagSet = ModelBase<NewFlagModel>.Instance.GetNewFlagSet(ELocalStoragePlayerKey.RoleDataItem);
		if (newFlagSet == null)
		{
			return false;
		}
		foreach (RoleInstance roleInstance in this.GetAllRoleList())
		{
			if (newFlagSet.Contains(roleInstance.GetDataId()))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x060149E2 RID: 84450 RVA: 0x005B5DEC File Offset: 0x005B3FEC
	public bool RedDotRoleSystemRoleListCondition(int roleId)
	{
		bool flag = false;
		EditFormationData getCurrentFormationData = ModelBase<EditFormationModel>.Instance.GetCurrentFormationData;
		int[] array = (getCurrentFormationData != null) ? getCurrentFormationData.GetRoleIdList : null;
		if (array != null)
		{
			int[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				if (array2[i] == roleId)
				{
					flag = true;
					break;
				}
			}
		}
		if (!flag)
		{
			return this.RedDotResonanceTabCondition(roleId);
		}
		return this.RedDotResonanceTabCondition(roleId) || ModelBase<VisionRecommendModel>.Instance.CheckVisionOneKeyEquipRedDot(roleId);
	}

	// Token: 0x060149E3 RID: 84451 RVA: 0x005B5E58 File Offset: 0x005B4058
	public bool RedDotAttributeTabLevelUpCondition(int roleId)
	{
		RoleDataBase roleDataById = this.GetRoleDataById(roleId, true);
		return roleDataById != null && !roleDataById.IsTrialRole() && !roleDataById.GetLevelData().GetRoleIsMaxLevel() && (this.GetSelectHasEnoughItemToLevelUp(roleId) && this.GetHasEnoughMoneyLevelUp(roleId));
	}

	// Token: 0x060149E4 RID: 84452 RVA: 0x005B5EA0 File Offset: 0x005B40A0
	public bool RedDotAttributeTabBreakUpCondition(int roleId)
	{
		RoleDataBase roleDataById = this.GetRoleDataById(roleId, true);
		return roleDataById != null && !roleDataById.IsTrialRole() && roleDataById.GetLevelData().GetRoleNeedBreakUp() && this.RedDotAttributeTabBreachCondition(roleDataById);
	}

	// Token: 0x060149E5 RID: 84453 RVA: 0x005B5EDC File Offset: 0x005B40DC
	public bool RedDotFavorItemActiveCondition(int roleId)
	{
		RoleDataBase roleDataById = this.GetRoleDataById(roleId, true);
		return !roleDataById.IsTrialRole() && roleDataById.GetFavorData().IsExistCanUnlockFavorItem();
	}

	// Token: 0x060149E6 RID: 84454 RVA: 0x005B5F07 File Offset: 0x005B4107
	private bool RedDotAttributeTabBreachCondition(RoleDataBase roleInstance)
	{
		return roleInstance.GetLevelData().IsEnoughBreachConsume();
	}

	// Token: 0x060149E7 RID: 84455 RVA: 0x005B5F14 File Offset: 0x005B4114
	public bool RedDotResonanceTabCondition(int roleId)
	{
		RoleInstance roleInstanceById = ModelBase<RoleModel>.Instance.GetRoleInstanceById(roleId);
		if (roleInstanceById == null)
		{
			return false;
		}
		int roleResonanceGroupIndex = this.GetRoleResonanceGroupIndex(roleInstanceById);
		IReadOnlyList<ResonantChain> configList = ConfigResonantChainByGroupId.GetConfigList(roleInstanceById.GetRoleConfig().ResonanceId, true);
		if (roleResonanceGroupIndex < 0 || roleResonanceGroupIndex >= configList.Count)
		{
			return false;
		}
		foreach (DicIntInt dicIntInt in configList[roleResonanceGroupIndex].ActivateConsumeIter())
		{
			if (ModelBase<InventoryModel>.Instance.GetCommonItemCount(dicIntInt.Key, 0) < dicIntInt.Value)
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x060149E8 RID: 84456 RVA: 0x005B5FCC File Offset: 0x005B41CC
	public bool RedDotCondition()
	{
		return this.RedDotResonanceCondition() || this.RedDotRoleSkinCondition() || this.RedDotRoleOrnamentCondition();
	}

	// Token: 0x060149E9 RID: 84457 RVA: 0x005B5FE8 File Offset: 0x005B41E8
	public bool RedDotResonanceCondition()
	{
		foreach (RoleInstance roleInstance in this.GetAllRoleList())
		{
			if (this.RedDotResonanceTabCondition(roleInstance.GetDataId()))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x060149EA RID: 84458 RVA: 0x005B6020 File Offset: 0x005B4220
	public bool RedDotRoleSkinCondition()
	{
		foreach (RoleInstance roleInstance in this.GetAllRoleList())
		{
			if (ModelBase<RoleSkinModel>.Instance.HasRoleSkinRedDotByRoleId(roleInstance.GetDataId()))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x060149EB RID: 84459 RVA: 0x005B605C File Offset: 0x005B425C
	public bool RedDotResonanceTabHoleCondition(int roleId, int groupIndex)
	{
		RoleInstance roleInstanceById = ModelBase<RoleModel>.Instance.GetRoleInstanceById(roleId);
		if (roleInstanceById == null)
		{
			return false;
		}
		int roleResonanceGroupIndex = this.GetRoleResonanceGroupIndex(roleInstanceById);
		if (groupIndex - roleResonanceGroupIndex != 1)
		{
			return false;
		}
		ResonantChain resonantChain = this.GetRoleResonanceConfigList(roleInstanceById)[groupIndex - 1];
		bool result = true;
		foreach (DicIntInt dicIntInt in resonantChain.ActivateConsumeIter())
		{
			int key = dicIntInt.Key;
			int value = dicIntInt.Value;
			if (ModelBase<InventoryModel>.Instance.GetCommonItemCount(key, 0) < value)
			{
				result = false;
				break;
			}
		}
		return result;
	}

	// Token: 0x060149EC RID: 84460 RVA: 0x005B6104 File Offset: 0x005B4304
	public ERoleResonanceNodeState GetRoleResonanceState(RoleDataBase roleInstance, int GroupIndex)
	{
		int resonantChainGroupIndex = roleInstance.GetResonanceData().GetResonantChainGroupIndex();
		if (GroupIndex <= resonantChainGroupIndex)
		{
			return ERoleResonanceNodeState.Activated;
		}
		if (GroupIndex - 1 == resonantChainGroupIndex)
		{
			return ERoleResonanceNodeState.ToBeActivated;
		}
		return ERoleResonanceNodeState.NeedFrontActivated;
	}

	// Token: 0x060149ED RID: 84461 RVA: 0x005B612C File Offset: 0x005B432C
	public int GetRoleResonanceGroupIndex(RoleDataBase roleInstance)
	{
		return roleInstance.GetResonanceData().GetResonantChainGroupIndex();
	}

	// Token: 0x060149EE RID: 84462 RVA: 0x005B613C File Offset: 0x005B433C
	[return: Nullable(2)]
	public List<ResonantChain> GetRoleResonanceConfigList(RoleDataBase roleInstance)
	{
		int dataId = roleInstance.GetDataId();
		int resonantChainGroupId = ConfigBase<RoleConfig>.Instance.GetRoleConfig(dataId).Value.ResonantChainGroupId;
		return ConfigBase<RoleResonanceConfig>.Instance.GetRoleResonanceList(resonantChainGroupId);
	}

	// Token: 0x17001B15 RID: 6933
	// (get) Token: 0x060149EF RID: 84463 RVA: 0x005B6177 File Offset: 0x005B4377
	public RoleSkillResponseData RoleSkillResponseData
	{
		get
		{
			if (this.RoleSkillResponseDataInternal == null)
			{
				this.RoleSkillResponseDataInternal = new RoleSkillResponseData();
			}
			return this.RoleSkillResponseDataInternal;
		}
	}

	// Token: 0x060149F0 RID: 84464 RVA: 0x005B6194 File Offset: 0x005B4394
	public global::SkillEffect GetCurRoleSkillViewDataLocal(int roleId, int skillGroupId)
	{
		int skillLevel = this.GetRoleDataById(roleId, true).GetSkillData().GetSkillLevel(skillGroupId);
		return this.GetRoleSkillEffect(skillGroupId, skillLevel);
	}

	// Token: 0x060149F1 RID: 84465 RVA: 0x005B61C0 File Offset: 0x005B43C0
	public global::SkillEffect GetNextRoleSkillViewDataLocal(int roleId, int skillGroupId)
	{
		int skillLevel = this.GetRoleDataById(roleId, true).GetSkillData().GetSkillLevel(skillGroupId);
		int maxSkillLevel = ConfigBase<RoleSkillConfig>.Instance.GetSkillConfigById(skillGroupId).Value.MaxSkillLevel;
		int skillLevel2 = (skillLevel < maxSkillLevel) ? (skillLevel + 1) : maxSkillLevel;
		return this.GetRoleSkillEffect(skillGroupId, skillLevel2);
	}

	// Token: 0x060149F2 RID: 84466 RVA: 0x005B6214 File Offset: 0x005B4414
	public global::SkillEffect GetRoleSkillEffect(int skillGroupId, int skillLevel)
	{
		global::SkillEffect skillEffect = new global::SkillEffect();
		List<SkillDescription> list = ConfigCommon.ToList<SkillDescription>(ConfigBase<RoleSkillConfig>.Instance.GetAllRoleSkillDescConfigByGroupId(skillGroupId));
		for (int i = 0; i < list.Count; i++)
		{
			for (int j = i + 1; j < list.Count; j++)
			{
				if (list[i].Order > list[j].Order)
				{
					SkillDescription value = list[i];
					list[i] = list[j];
					list[j] = value;
				}
			}
		}
		List<global::OneSkillEffect> list2 = new List<global::OneSkillEffect>();
		foreach (SkillDescription skillDescription in list)
		{
			global::OneSkillEffect oneSkillEffect = new global::OneSkillEffect();
			oneSkillEffect.Id = skillDescription.Id;
			oneSkillEffect.Desc = new List<string>();
			foreach (StringArray stringArray in skillDescription.SkillDetailNumIter())
			{
				if (stringArray.ArrayString().Length != 0 && skillLevel <= stringArray.ArrayString().Length)
				{
					oneSkillEffect.Desc.Add((skillLevel - 1 >= 0) ? stringArray.ArrayString()[skillLevel - 1] : null);
				}
			}
			list2.Add(oneSkillEffect);
		}
		skillEffect.Level = skillLevel;
		skillEffect.EffectDescList = list2;
		return skillEffect;
	}

	// Token: 0x060149F3 RID: 84467 RVA: 0x005B6398 File Offset: 0x005B4598
	[NullableContext(2)]
	public void UpdateRoleSkillViewData(global::SkillEffect skillEffectList, global::SkillEffect nextSkillEffectList, int skillId)
	{
		this.RoleSkillResponseData.UpdateRoleSkillViewResponse(skillEffectList, nextSkillEffectList, skillId);
	}

	// Token: 0x060149F4 RID: 84468 RVA: 0x005B63A8 File Offset: 0x005B45A8
	public void UpdateRoleSkillNodeData(int roleId, ArraySkillNode[] skillNodeState)
	{
		RoleInstance roleInstanceById = ModelBase<RoleModel>.Instance.GetRoleInstanceById(roleId);
		if (roleInstanceById == null)
		{
			return;
		}
		RoleSkillData skillData = roleInstanceById.GetSkillData();
		if (skillData == null)
		{
			return;
		}
		int num = skillNodeState.Length;
		Dictionary<int, SkillNodeDataInfo> dictionary = new Dictionary<int, SkillNodeDataInfo>();
		for (int i = 0; i < num; i++)
		{
			ArraySkillNode arraySkillNode = skillNodeState[i];
			int skillNodeId = arraySkillNode.SkillNodeId;
			SkillNodeDataInfo value = new SkillNodeDataInfo(skillNodeId, arraySkillNode.IsActive, arraySkillNode.SkillId);
			dictionary.Add(skillNodeId, value);
		}
		skillData.SetSkillNodeStateData(dictionary);
	}

	// Token: 0x060149F5 RID: 84469 RVA: 0x005B6421 File Offset: 0x005B4621
	public int GetUpgradeSkillIdIfUpgraded(int skillId, int roleDataId)
	{
		return this.GetRoleDataById(roleDataId, true).GetSkillData().GetSkillIdAfterUpgrade(skillId);
	}

	// Token: 0x060149F6 RID: 84470 RVA: 0x005B6438 File Offset: 0x005B4638
	public void UpdateRoleFavorData(RoleFavor[] favorList)
	{
		int num = favorList.Length;
		for (int i = 0; i < num; i++)
		{
			this.UpdateRoleFavorDataSingle(favorList[i]);
		}
	}

	// Token: 0x060149F7 RID: 84471 RVA: 0x005B6460 File Offset: 0x005B4660
	public void UpdateRoleFavorCondition(Dictionary<int, ConditionInfo> conditionMap)
	{
		foreach (KeyValuePair<int, ConditionInfo> keyValuePair in conditionMap)
		{
			int key = keyValuePair.Key;
			ConditionInfo value = keyValuePair.Value;
			ModelBase<RoleFavorConditionModel>.Instance.UpdateRoleFavorCondition(key, value);
		}
	}

	// Token: 0x060149F8 RID: 84472 RVA: 0x005B64C4 File Offset: 0x005B46C4
	public void UpdateRoleFavorDataSingle(RoleFavor roleFavor)
	{
		int roleId = roleFavor.RoleId;
		RoleInstance roleInstanceById = ModelBase<RoleModel>.Instance.GetRoleInstanceById(roleId);
		if (roleInstanceById == null)
		{
			return;
		}
		RoleFavorData favorData = roleInstanceById.GetFavorData();
		if (favorData == null)
		{
			return;
		}
		int level = roleFavor.Level;
		int exp = roleFavor.Exp;
		RepeatedField<FavorItem> wordIds = roleFavor.WordIds;
		RepeatedField<FavorItem> storyIds = roleFavor.StoryIds;
		RepeatedField<FavorItem> goodsIds = roleFavor.GoodsIds;
		favorData.SetFavorLevel(level);
		favorData.SetFavorExp(exp);
		favorData.UpdateRoleFavorData(EFavorContentType.Voice, wordIds.ToArray<FavorItem>());
		favorData.UpdateRoleFavorData(EFavorContentType.ExperienceStory, storyIds.ToArray<FavorItem>());
		favorData.UpdateRoleFavorData(EFavorContentType.PreciousItem, goodsIds.ToArray<FavorItem>());
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.UpdateRoleFavorData, roleId);
	}

	// Token: 0x060149F9 RID: 84473 RVA: 0x005B6564 File Offset: 0x005B4764
	public void UpdateRoleFavorNewCanUnLockId(RoleFavorNewCanUnLockNotify info)
	{
		int roleId = info.RoleId;
		RoleInstance roleInstanceById = ModelBase<RoleModel>.Instance.GetRoleInstanceById(roleId);
		if (roleInstanceById == null)
		{
			return;
		}
		roleInstanceById.GetFavorData().UpdateCanUnlockId(info.ItemType, info.CanUnLockId);
	}

	// Token: 0x060149FA RID: 84474 RVA: 0x005B65A0 File Offset: 0x005B47A0
	public void UpdateRoleFavorLevelAndExp(RoleFavorLevelUpdateNotify info)
	{
		int roleId = info.RoleId;
		RoleFavorData favorData = ModelBase<RoleModel>.Instance.GetRoleInstanceById(roleId).GetFavorData();
		favorData.SetFavorLevel(info.Level);
		favorData.SetFavorExp(info.Exp);
	}

	// Token: 0x060149FB RID: 84475 RVA: 0x005B65DC File Offset: 0x005B47DC
	public void UpdateRoleSkinInfo(int roleId, int skinId)
	{
		RoleInstance roleInstanceById = ModelBase<RoleModel>.Instance.GetRoleInstanceById(roleId);
		if (roleInstanceById == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Role;
			ELogAuthor author = ELogAuthor.BB;
			string message = "UpdateRoleSkinInfo 无效roleId";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("roleId", roleId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		roleInstanceById.SetRoleSkinId(skinId);
	}

	// Token: 0x060149FC RID: 84476 RVA: 0x005B662C File Offset: 0x005B482C
	public void UpdateRoleBackgroundMusicEnabled(int roleDataId, bool enabled)
	{
		RoleInstance roleInstanceById = ModelBase<RoleModel>.Instance.GetRoleInstanceById(roleDataId);
		if (roleInstanceById == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Role;
			ELogAuthor author = ELogAuthor.LZK;
			string message = "UpdateRoleBackgroundMusicEnabled 无效roleId";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("roleId", roleDataId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		roleInstanceById.SetBackgroundMusicEnabled(enabled);
	}

	// Token: 0x060149FD RID: 84477 RVA: 0x005B667C File Offset: 0x005B487C
	public bool GetRoleBackgroundMusicEnabled(int roleDataId)
	{
		RoleInstance roleInstanceById = ModelBase<RoleModel>.Instance.GetRoleInstanceById(roleDataId);
		return roleInstanceById == null || roleInstanceById.GetBackgroundMusicEnabled();
	}

	// Token: 0x060149FE RID: 84478 RVA: 0x005B66A0 File Offset: 0x005B48A0
	public List<int> GetRoleSystemRoleList(bool includeRobots = false)
	{
		if (ModelBase<DangoAbyssModel>.Instance.CheckIfInSmallWorldInstance())
		{
			return this.GetRoleIdList();
		}
		if (ModelBase<GameModeModel>.Instance.IsMulti)
		{
			return this.GetRoleIdList();
		}
		List<SceneTeamItem> teamItems = ModelBase<SceneTeamModel>.Instance.GetTeamItems(false);
		List<int> list = new List<int>();
		foreach (SceneTeamItem sceneTeamItem in teamItems)
		{
			int getConfigId = sceneTeamItem.GetConfigId;
			RoleDataBase roleDataById = this.GetRoleDataById(getConfigId, true);
			if (roleDataById != null && roleDataById.IsTrialRole())
			{
				list.Add(getConfigId);
			}
		}
		int teamLength = ModelBase<SceneTeamModel>.Instance.GetTeamLength();
		if (ControllerBase<GameModeController>.Instance.IsInInstance() && list.Count > 0 && list.Count == teamLength)
		{
			return list;
		}
		if (list.Count > 0)
		{
			List<int> list2 = new List<int>(this.RoleInstanceMap.Keys);
			foreach (int item in list)
			{
				list2.Add(item);
			}
			if (includeRobots)
			{
				this.MergeSpecialRoleIdList(list2);
			}
			this.SortRoleList(list2);
			return list2;
		}
		List<int> roleIdList = this.GetRoleIdList();
		if (includeRobots)
		{
			List<int> list3 = new List<int>(roleIdList);
			this.MergeSpecialRoleIdList(list3);
			this.SortRoleList(list3);
			return list3;
		}
		return roleIdList;
	}

	// Token: 0x060149FF RID: 84479 RVA: 0x005B6808 File Offset: 0x005B4A08
	private void MergeSpecialRoleIdList(List<int> roleList)
	{
		foreach (RoleSpecialRobotData roleSpecialRobotData in this.RoleSpecialRobotDataMap.Values)
		{
			if (roleSpecialRobotData.IsVisibleInRoleSystem())
			{
				int dataId = roleSpecialRobotData.GetDataId();
				if (!roleList.Contains(dataId))
				{
					roleList.Add(dataId);
				}
			}
		}
	}

	// Token: 0x06014A00 RID: 84480 RVA: 0x005B6878 File Offset: 0x005B4A78
	public int GetRoleListHighestLevel()
	{
		int num = -1;
		foreach (KeyValuePair<int, RoleInstance> keyValuePair in this.RoleInstanceMap)
		{
			int level = keyValuePair.Value.GetLevelData().GetLevel();
			num = ((level > num) ? level : num);
		}
		foreach (KeyValuePair<int, RoleRobotData> keyValuePair2 in this.RoleRobotDataMap)
		{
			RoleRobotData value = keyValuePair2.Value;
			if (ModelBase<SceneTeamModel>.Instance.GetTeamItem((long)value.GetDataId(), new GetTeamItemOptions
			{
				ParamType = ETeamParamType.ConfigId
			}) != null)
			{
				int level2 = value.GetLevelData().GetLevel();
				num = ((level2 > num) ? level2 : num);
			}
		}
		return num;
	}

	// Token: 0x06014A01 RID: 84481 RVA: 0x005B6964 File Offset: 0x005B4B64
	public void UpdateCanChangeRoleIdList(int[] roleIds)
	{
		List<int> list = new List<int>(this.CanChangeRoleIdList);
		foreach (int item in roleIds)
		{
			list.Add(item);
		}
		this.CanChangeRoleIdList = list.ToArray();
	}

	// Token: 0x06014A02 RID: 84482 RVA: 0x005B69A4 File Offset: 0x005B4BA4
	public int[] GetCanChangeRoleIdList()
	{
		return this.CanChangeRoleIdList;
	}

	// Token: 0x06014A03 RID: 84483 RVA: 0x005B69AC File Offset: 0x005B4BAC
	public bool IsMainRole(int roleId)
	{
		return this.GetMainRoleSet().Contains(roleId);
	}

	// Token: 0x06014A04 RID: 84484 RVA: 0x005B69BA File Offset: 0x005B4BBA
	public bool IsLightMainRole(int roleId)
	{
		return this.GetLightMainRoleSet().Contains(roleId);
	}

	// Token: 0x06014A05 RID: 84485 RVA: 0x005B69C8 File Offset: 0x005B4BC8
	private HashSet<int> GetMainRoleSet()
	{
		if (this.MainRoleIdSet.Count == 0)
		{
			this.InitMainRoleIdSet();
		}
		return this.MainRoleIdSet;
	}

	// Token: 0x06014A06 RID: 84486 RVA: 0x005B69E3 File Offset: 0x005B4BE3
	private HashSet<int> GetLightMainRoleSet()
	{
		if (this.LightMainRoleIdSet.Count == 0)
		{
			this.InitLightMainRoleIdSet();
		}
		return this.LightMainRoleIdSet;
	}

	// Token: 0x06014A07 RID: 84487 RVA: 0x005B6A00 File Offset: 0x005B4C00
	private void InitMainRoleIdSet()
	{
		IReadOnlyList<MainRoleConfig> allMainRoleConfig = ConfigBase<RoleConfig>.Instance.GetAllMainRoleConfig();
		int count = allMainRoleConfig.Count;
		for (int i = 0; i < count; i++)
		{
			MainRoleConfig mainRoleConfig = allMainRoleConfig[i];
			this.MainRoleIdSet.Add(mainRoleConfig.Id);
		}
	}

	// Token: 0x06014A08 RID: 84488 RVA: 0x005B6A48 File Offset: 0x005B4C48
	private void InitLightMainRoleIdSet()
	{
		foreach (int item in ConfigCommonParamById.GetIntArrayConfig("LightMainRoleIdList"))
		{
			this.LightMainRoleIdSet.Add(item);
		}
	}

	// Token: 0x06014A09 RID: 84489 RVA: 0x005B6AA0 File Offset: 0x005B4CA0
	public int? GetCurSelectMainRoleId()
	{
		foreach (int num in this.GetMainRoleSet())
		{
			if (this.RoleInstanceMap.ContainsKey(num))
			{
				return new int?(num);
			}
		}
		return null;
	}

	// Token: 0x06014A0A RID: 84490 RVA: 0x005B6B10 File Offset: 0x005B4D10
	[NullableContext(2)]
	public RoleInstance GetCurSelectMainRoleInstance()
	{
		foreach (int key in this.GetMainRoleSet())
		{
			if (this.RoleInstanceMap.ContainsKey(key))
			{
				return this.RoleInstanceMap[key];
			}
		}
		return null;
	}

	// Token: 0x06014A0B RID: 84491 RVA: 0x005B6B7C File Offset: 0x005B4D7C
	public bool IsHasRole(int roleId)
	{
		if (!this.IsMainRole(roleId))
		{
			return this.GetRoleDataById(roleId, true) != null;
		}
		int? curSelectMainRoleId = this.GetCurSelectMainRoleId();
		if (curSelectMainRoleId == null)
		{
			return false;
		}
		RoleInfo? roleConfig = ConfigBase<RoleConfig>.Instance.GetRoleConfig(roleId);
		RoleInfo? roleConfig2 = ConfigBase<RoleConfig>.Instance.GetRoleConfig(curSelectMainRoleId.Value);
		return roleConfig != null && roleConfig2 != null && roleConfig.Value.ElementId == roleConfig2.Value.ElementId;
	}

	// Token: 0x06014A0C RID: 84492 RVA: 0x005B6C04 File Offset: 0x005B4E04
	public MainRoleConfig? GetCorrectMainRoleConfig(int roleId)
	{
		if (!this.IsMainRole(roleId))
		{
			MainRoleConfig? result = null;
			return result;
		}
		MainRoleConfig? mainRoleById = ConfigBase<RoleConfig>.Instance.GetMainRoleById(roleId);
		if (mainRoleById == null)
		{
			MainRoleConfig? result = null;
			return result;
		}
		EPlayerGender playerGender = ModelBase<PlayerInfoModel>.Instance.GetPlayerGender();
		RoleInfo? roleConfig = ConfigBase<RoleConfig>.Instance.GetRoleConfig(roleId);
		if (roleConfig == null)
		{
			MainRoleConfig? result = null;
			return result;
		}
		if (mainRoleById.Value.Gender != (int)playerGender)
		{
			IReadOnlyList<MainRoleConfig> mainRoleByGender = ConfigBase<RoleConfig>.Instance.GetMainRoleByGender((LoginDefine.ELoginSex)playerGender);
			if (mainRoleByGender != null)
			{
				foreach (MainRoleConfig value in mainRoleByGender)
				{
					RoleInfo? roleConfig2 = ConfigBase<RoleConfig>.Instance.GetRoleConfig(value.Id);
					if (roleConfig2 != null && roleConfig2.Value.ElementId == roleConfig.Value.ElementId)
					{
						return new MainRoleConfig?(value);
					}
				}
			}
		}
		return new MainRoleConfig?(mainRoleById.Value);
	}

	// Token: 0x06014A0D RID: 84493 RVA: 0x005B6D28 File Offset: 0x005B4F28
	public int GetRoleLevelUpExp(int roleId, int level)
	{
		RoleInfo? roleConfig = ConfigBase<RoleConfig>.Instance.GetRoleConfig(roleId);
		RoleLevelConsume? roleLevelConsume = ConfigBase<RoleConfig>.Instance.GetRoleLevelConsume(roleConfig.Value.LevelConsumeId, level);
		if (roleLevelConsume != null)
		{
			return roleLevelConsume.Value.ExpCount;
		}
		return 1;
	}

	// Token: 0x06014A0E RID: 84494 RVA: 0x005B6D78 File Offset: 0x005B4F78
	public Dictionary<int, int> CalculateExpBackItem(int overExp)
	{
		IReadOnlyList<RoleExpItem> roleExpItemList = ConfigBase<RoleConfig>.Instance.GetRoleExpItemList();
		int count = roleExpItemList.Count;
		int num = overExp;
		Dictionary<int, int> dictionary = new Dictionary<int, int>();
		for (int i = count - 1; i >= 0; i--)
		{
			int basicExp = roleExpItemList[i].BasicExp;
			int num2 = (int)Math.Floor((double)num / (double)basicExp);
			num %= basicExp;
			if (num2 > 0)
			{
				dictionary[roleExpItemList[i].Id] = num2;
			}
		}
		return dictionary;
	}

	// Token: 0x06014A0F RID: 84495 RVA: 0x005B6DF0 File Offset: 0x005B4FF0
	public int GetBaseAttributeById(int roleId, EAttributeType attributeId)
	{
		BaseProperty? config = ConfigBasePropertyById.GetConfig(ConfigBase<RoleConfig>.Instance.GetRoleConfig(roleId).Value.PropertyId, true);
		if (attributeId == EAttributeType.LifeMax)
		{
			return config.Value.LifeMax;
		}
		if (attributeId == EAttributeType.Atk)
		{
			return config.Value.Atk;
		}
		if (attributeId != EAttributeType.Def)
		{
			return 0;
		}
		return config.Value.Def;
	}

	// Token: 0x06014A10 RID: 84496 RVA: 0x005B6E60 File Offset: 0x005B5060
	public float GetAttributeRadioByLevel(EAttributeType attributeId, int level, int breachLevel)
	{
		RolePropertyGrowth? config = ConfigRolePropertyGrowthByLevelAndBreachLevel.GetConfig(level, breachLevel, true);
		if (attributeId == EAttributeType.LifeMax)
		{
			return (float)config.Value.LifeMaxRatio;
		}
		if (attributeId == EAttributeType.Atk)
		{
			return (float)config.Value.AtkRatio;
		}
		if (attributeId != EAttributeType.Def)
		{
			return 0f;
		}
		return (float)config.Value.DefRatio;
	}

	// Token: 0x06014A11 RID: 84497 RVA: 0x005B6EC0 File Offset: 0x005B50C0
	public int GetAttributeByLevel(int roleId, EAttributeType attributeId, int level, int breachLevel)
	{
		float baseAttributeById = (float)this.GetBaseAttributeById(roleId, attributeId);
		float attributeRadioByLevel = this.GetAttributeRadioByLevel(attributeId, level, breachLevel);
		return (int)Math.Floor((double)(baseAttributeById * attributeRadioByLevel * 0.0001f));
	}

	// Token: 0x06014A12 RID: 84498 RVA: 0x005B6EF0 File Offset: 0x005B50F0
	public int GetAddAttrLevelUp(int roleId, int srcLevel, int srcBreachLevel, int tarLevel, int tarBreachLevel, int attributeId)
	{
		int attributeByLevel = this.GetAttributeByLevel(roleId, (EAttributeType)attributeId, srcLevel, srcBreachLevel);
		return this.GetAttributeByLevel(roleId, (EAttributeType)attributeId, tarLevel, tarBreachLevel) - attributeByLevel;
	}

	// Token: 0x06014A13 RID: 84499 RVA: 0x005B6F18 File Offset: 0x005B5118
	public int GetRoleSkillTreeNodeLevel(int roleId, int skillNodeId)
	{
		SkillTree? skillTreeNode = ConfigBase<RoleSkillConfig>.Instance.GetSkillTreeNode(skillNodeId);
		if (skillTreeNode == null)
		{
			return 0;
		}
		RoleDataBase roleDataBase = this.GetRoleInstanceById(roleId);
		if (roleDataBase == null)
		{
			roleDataBase = this.GetRoleDataById(roleId, true);
		}
		return this.GetRoleSkillTreeNodeLevelByConfig(roleDataBase, skillTreeNode.Value);
	}

	// Token: 0x06014A14 RID: 84500 RVA: 0x005B6F5E File Offset: 0x005B515E
	public int GetRoleSkillTreeNodeLevelByConfig(RoleDataBase roleInstance, SkillTree config)
	{
		return roleInstance.GetSkillData().GetSkillNodeLevel(config);
	}

	// Token: 0x06014A15 RID: 84501 RVA: 0x005B6F6C File Offset: 0x005B516C
	public ESkillTreeNodeState? GetRoleSkillTreeNodeState(int roleId, int skillNodeId)
	{
		if (skillNodeId <= 0)
		{
			return null;
		}
		SkillTree? skillTreeNode = ConfigBase<RoleSkillConfig>.Instance.GetSkillTreeNode(skillNodeId);
		if (skillTreeNode == null)
		{
			return null;
		}
		RoleDataBase roleDataBase = this.GetRoleInstanceById(roleId);
		if (roleDataBase == null)
		{
			roleDataBase = this.GetRoleDataById(roleId, true);
		}
		return new ESkillTreeNodeState?(roleDataBase.GetSkillData().GetSkillTreeNodeState(skillTreeNode.Value, roleId));
	}

	// Token: 0x06014A16 RID: 84502 RVA: 0x005B6FD4 File Offset: 0x005B51D4
	public bool GetRoleSkillTreeNodeConsumeSatisfied(int roleId, int skillNodeId)
	{
		RoleInstance roleInstanceById = this.GetRoleInstanceById(roleId);
		return roleInstanceById != null && roleInstanceById.GetSkillData().IsSkillTreeNodeConsumeSatisfied(skillNodeId);
	}

	// Token: 0x06014A17 RID: 84503 RVA: 0x005B6FFC File Offset: 0x005B51FC
	public string GetSkillAttributeNameByOneSkillEffect(global::OneSkillEffect effect)
	{
		return ConfigBase<RoleSkillConfig>.Instance.GetRoleSkillDescriptionConfigById(effect.Id).Value.AttributeName;
	}

	// Token: 0x06014A18 RID: 84504 RVA: 0x005B702C File Offset: 0x005B522C
	public string GetSkillAttributeDescriptionByOneSkillEffect(global::OneSkillEffect effect)
	{
		SkillDescription? roleSkillDescriptionConfigById = ConfigBase<RoleSkillConfig>.Instance.GetRoleSkillDescriptionConfigById(effect.Id);
		string result;
		if (!StringUtils.IsBlank(roleSkillDescriptionConfigById.Value.Description))
		{
			string[] array = new string[effect.Desc.Count];
			for (int i = 0; i < effect.Desc.Count; i++)
			{
				array[i] = effect.Desc[i];
			}
			result = StringUtils.Format(ConfigMultiTextLang.GetLocalTextNew(roleSkillDescriptionConfigById.Value.Description, null), array);
		}
		else
		{
			StringBuilder stringBuilder = new StringBuilder();
			int count = effect.Desc.Count;
			for (int j = 0; j < count; j++)
			{
				stringBuilder.Append(effect.Desc[j]);
			}
			result = stringBuilder.ToString();
		}
		return result;
	}

	// Token: 0x06014A19 RID: 84505 RVA: 0x005B7104 File Offset: 0x005B5304
	public Dictionary<int, int[]> GetResonantItemRoleMap()
	{
		if (this.ResonantItemRoleMapInternal != null)
		{
			return this.ResonantItemRoleMapInternal;
		}
		this.ResonantItemRoleMapInternal = new Dictionary<int, int[]>();
		foreach (RoleInfo roleInfo in ConfigBase<RoleConfig>.Instance.GetRoleList())
		{
			if (roleInfo.ResonantChainGroupId > 0)
			{
				List<ResonantChain> roleResonanceList = ConfigBase<RoleResonanceConfig>.Instance.GetRoleResonanceList(roleInfo.ResonantChainGroupId);
				if (roleResonanceList != null)
				{
					foreach (ResonantChain resonantChain in roleResonanceList)
					{
						foreach (DicIntInt dicIntInt in resonantChain.ActivateConsumeIter())
						{
							int key = dicIntInt.Key;
							int value = dicIntInt.Value;
							int[] array = null;
							if (this.ResonantItemRoleMapInternal.ContainsKey(key))
							{
								array = this.ResonantItemRoleMapInternal[key];
							}
							if (array == null)
							{
								array = new int[0];
							}
							bool flag = false;
							int[] array2 = array;
							for (int i = 0; i < array2.Length; i++)
							{
								if (array2[i] == roleInfo.Id)
								{
									flag = true;
									break;
								}
							}
							if (!flag)
							{
								int[] array3 = new int[array.Length + 1];
								for (int j = 0; j < array.Length; j++)
								{
									array3[j] = array[j];
								}
								array3[array.Length] = roleInfo.Id;
								array = array3;
							}
							this.ResonantItemRoleMapInternal[key] = array;
						}
					}
				}
			}
		}
		return this.ResonantItemRoleMapInternal;
	}

	// Token: 0x06014A1A RID: 84506 RVA: 0x005B72F8 File Offset: 0x005B54F8
	[NullableContext(2)]
	public int[] GetResonantItemRoleId(int itemId)
	{
		ItemInfo? itemConfig = ConfigBase<InventoryConfig>.Instance.GetItemConfig(itemId);
		bool flag;
		if (itemConfig == null)
		{
			flag = true;
		}
		else
		{
			int[] array = itemConfig.GetValueOrDefault().ShowTypes();
			flag = !((array != null) ? new bool?(array.Contains(30)) : null).GetValueOrDefault();
		}
		if (flag)
		{
			return null;
		}
		int[] array3;
		int[] array2 = this.GetResonantItemRoleMap().TryGetValue(itemId, out array3) ? array3 : null;
		if (array2 != null && array2.Length != 0)
		{
			return array2;
		}
		return null;
	}

	// Token: 0x06014A1B RID: 84507 RVA: 0x005B7378 File Offset: 0x005B5578
	public bool CheckRoleResonantIfMax(int roleId)
	{
		RoleInstance roleInstanceById = this.GetRoleInstanceById(roleId);
		return roleInstanceById != null && this.GetRoleResonanceGroupIndex(roleInstanceById) >= ConfigBase<RoleResonanceConfig>.Instance.GetResonanceMaxLevel();
	}

	// Token: 0x06014A1C RID: 84508 RVA: 0x005B73A8 File Offset: 0x005B55A8
	public int GetRoleLeftResonantCount(int roleId)
	{
		RoleInstance roleInstanceById = this.GetRoleInstanceById(roleId);
		if (roleInstanceById == null)
		{
			return 0;
		}
		int roleResonanceGroupIndex = this.GetRoleResonanceGroupIndex(roleInstanceById);
		return ConfigBase<RoleResonanceConfig>.Instance.GetResonanceMaxLevel() - roleResonanceGroupIndex;
	}

	// Token: 0x06014A1D RID: 84509 RVA: 0x005B73D8 File Offset: 0x005B55D8
	public int GetRoleLeftResonantCountWithInventoryItem(int roleId)
	{
		RoleInstance roleInstanceById = this.GetRoleInstanceById(roleId);
		if (roleInstanceById == null)
		{
			return 0;
		}
		RoleInfo roleConfig = roleInstanceById.GetRoleConfig();
		int num = 0;
		foreach (KeyValuePair<int, int> keyValuePair in roleConfig.SpilloverItem())
		{
			num += ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(keyValuePair.Key, 0);
		}
		int roleResonanceGroupIndex = this.GetRoleResonanceGroupIndex(roleInstanceById);
		return ConfigBase<RoleResonanceConfig>.Instance.GetResonanceMaxLevel() - roleResonanceGroupIndex - num;
	}

	// Token: 0x06014A1E RID: 84510 RVA: 0x005B7468 File Offset: 0x005B5668
	public List<TItem> GetResonantItemConvertItemResult(int itemId)
	{
		int[] resonantItemRoleId = ModelBase<RoleModel>.Instance.GetResonantItemRoleId(itemId);
		if (resonantItemRoleId == null || resonantItemRoleId.Length == 0)
		{
			return new List<TItem>();
		}
		List<TItem> list = new List<TItem>();
		int id = resonantItemRoleId[0];
		RoleInfo? roleConfig = ConfigBase<RoleConfig>.Instance.GetRoleConfig(id);
		if (roleConfig != null)
		{
			for (int i = 0; i < roleConfig.Value.SpiloverCompensateLength; i++)
			{
				DicIntInt? dicIntInt = roleConfig.Value.SpiloverCompensate(i);
				if (dicIntInt != null)
				{
					TItem item = new TItem
					{
						ItemData = new InventoryDefine.GetItemData(dicIntInt.Value.Key, 0),
						Count = dicIntInt.Value.Value
					};
					list.Add(item);
				}
			}
		}
		else
		{
			RoleQualityInfo qualityConfig = this.GetRoleInstanceById(id).GetQualityConfig();
			for (int j = 0; j < qualityConfig.SpiloverCompensateLength; j++)
			{
				DicIntInt? dicIntInt2 = qualityConfig.SpiloverCompensate(j);
				if (dicIntInt2 != null)
				{
					TItem item2 = new TItem
					{
						ItemData = new InventoryDefine.GetItemData(dicIntInt2.Value.Key, 0),
						Count = dicIntInt2.Value.Value
					};
					list.Add(item2);
				}
			}
		}
		return list;
	}

	// Token: 0x06014A1F RID: 84511 RVA: 0x005B75BA File Offset: 0x005B57BA
	public bool InUltraSkill()
	{
		return this.InUltraSkillInternal;
	}

	// Token: 0x06014A20 RID: 84512 RVA: 0x005B75C4 File Offset: 0x005B57C4
	private void OnChangeRole(EntityHandle newEntityHandle, [Nullable(2)] EntityHandle oldEntityHandle)
	{
		if (oldEntityHandle != null)
		{
			WorldEntity entity = oldEntityHandle.Entity;
			((entity != null) ? entity.GetComponent<RoleTagComponent>() : null).RemoveTagAddOrRemoveListener(GameplayTagDefine.EGameplayTagId["角色.Common.技能通用标识.大招"], new BaseTagComponent.TTagSwitchedCallback(this.OnUltraTagChange));
		}
		if (newEntityHandle != null)
		{
			WorldEntity entity2 = newEntityHandle.Entity;
			RoleTagComponent roleTagComponent = (entity2 != null) ? entity2.GetComponent<RoleTagComponent>() : null;
			roleTagComponent.AddTagAddOrRemoveListener(GameplayTagDefine.EGameplayTagId["角色.Common.技能通用标识.大招"], new BaseTagComponent.TTagSwitchedCallback(this.OnUltraTagChange), null);
			if (this.InUltraSkillInternal != roleTagComponent.HasTag(GameplayTagDefine.EGameplayTagId["角色.Common.技能通用标识.大招"]))
			{
				this.InUltraSkillInternal = !this.InUltraSkillInternal;
				Singleton<EventSystem>.Instance.Emit<bool>(EEventName.OnEnterOrExitUltraSkill, this.InUltraSkillInternal);
			}
		}
	}

	// Token: 0x06014A21 RID: 84513 RVA: 0x005B7680 File Offset: 0x005B5880
	private void OnUltraTagChange(int tagId, bool tagExist)
	{
		if (tagId != GameplayTagDefine.EGameplayTagId["角色.Common.技能通用标识.大招"])
		{
			return;
		}
		this.InUltraSkillInternal = tagExist;
		Singleton<EventSystem>.Instance.Emit<bool>(EEventName.OnEnterOrExitUltraSkill, tagExist);
	}

	// Token: 0x06014A22 RID: 84514 RVA: 0x005B76AD File Offset: 0x005B58AD
	public int[] GetRoleTagByRoleInfo(RoleInfo roleInfo)
	{
		if (this.ClientCheckRoleIsUpgradeLightMainRole(roleInfo.Id))
		{
			return ConfigCommonParamById.GetIntArrayConfig("MainRoleReplaceTagList").ToArray<int>();
		}
		return roleInfo.GetTagArray();
	}

	// Token: 0x06014A23 RID: 84515 RVA: 0x005B76D8 File Offset: 0x005B58D8
	public bool ClientCheckRoleIsUpgradeLightMainRole(int roleId)
	{
		if (!this.IsLightMainRole(roleId))
		{
			return false;
		}
		int? intConfig = ConfigCommonParamById.GetIntConfig("MainRoleTagReplaceCondition");
		return ControllerBase<LevelGeneralController>.Instance.CheckCondition(intConfig.Value.ToString(), null, false, Array.Empty<object>());
	}

	// Token: 0x06014A24 RID: 84516 RVA: 0x005B771B File Offset: 0x005B591B
	public int[] GetRoleBranchIdList(int roleId)
	{
		return ConfigBase<RoleConfig>.Instance.GetRoleBranchIds(roleId);
	}

	// Token: 0x06014A25 RID: 84517 RVA: 0x005B7728 File Offset: 0x005B5928
	public int GetRoleCurrentBranchId(int roleId)
	{
		if (!this.IsRoleHasBranch(roleId))
		{
			return 0;
		}
		int result;
		if (this.RoleSkillBranchMap.TryGetValue(roleId, out result))
		{
			return result;
		}
		return this.GetRoleDefaultBranchId(roleId);
	}

	// Token: 0x06014A26 RID: 84518 RVA: 0x005B7759 File Offset: 0x005B5959
	public int GetRoleBranchIdByIndex(int roleId, int index)
	{
		return this.GetRoleBranchIdList(roleId)[index];
	}

	// Token: 0x06014A27 RID: 84519 RVA: 0x005B7764 File Offset: 0x005B5964
	public int GetRoleDefaultBranchId(int roleId)
	{
		return ConfigBase<RoleConfig>.Instance.GetRoleDefaultBranch(roleId);
	}

	// Token: 0x06014A28 RID: 84520 RVA: 0x005B7774 File Offset: 0x005B5974
	public int GetRoleCurrentBranchIndex(int roleId)
	{
		int[] roleBranchIdList = this.GetRoleBranchIdList(roleId);
		int skillBranch = this.GetRoleCurrentBranchId(roleId);
		return Array.FindIndex<int>(roleBranchIdList, (int id) => skillBranch == id);
	}

	// Token: 0x06014A29 RID: 84521 RVA: 0x005B77AC File Offset: 0x005B59AC
	public int GetRoleOppositeBranchId(int roleId)
	{
		int roleCurrentBranchIndex = this.GetRoleCurrentBranchIndex(roleId);
		return this.GetRoleBranchIdByIndex(roleId, (roleCurrentBranchIndex == 0) ? 1 : 0);
	}

	// Token: 0x06014A2A RID: 84522 RVA: 0x005B77CC File Offset: 0x005B59CC
	public int GetRoleDefaultBranchIndex(int roleId)
	{
		int[] roleBranchIdList = this.GetRoleBranchIdList(roleId);
		int skillBranch = this.GetRoleDefaultBranchId(roleId);
		return Array.FindIndex<int>(roleBranchIdList, (int id) => skillBranch == id);
	}

	// Token: 0x06014A2B RID: 84523 RVA: 0x005B7804 File Offset: 0x005B5A04
	public bool IsSkillNodeHasBranch(int nodeId)
	{
		int[] skillNodeBranchIdList = this.GetSkillNodeBranchIdList(nodeId);
		return skillNodeBranchIdList != null && skillNodeBranchIdList.Length == 2;
	}

	// Token: 0x06014A2C RID: 84524 RVA: 0x005B7824 File Offset: 0x005B5A24
	public bool IsInHideSkillBranchInstSubTypeList(int instSubType)
	{
		IReadOnlyList<int> readOnlyList = ConfigCommonParamById.GetIntArrayConfig("HideSkillBranchInstSubTypeList") ?? Array.Empty<int>();
		for (int i = 0; i < readOnlyList.Count; i++)
		{
			if (readOnlyList[i] == instSubType)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06014A2D RID: 84525 RVA: 0x005B7864 File Offset: 0x005B5A64
	public int GetSkillNodeCurrentBranchId(int roleId, int nodeId)
	{
		int roleCurrentBranchIndex = this.GetRoleCurrentBranchIndex(roleId);
		return ConfigBase<RoleConfig>.Instance.GetSkillNodeBranchIds(nodeId)[roleCurrentBranchIndex];
	}

	// Token: 0x06014A2E RID: 84526 RVA: 0x005B7886 File Offset: 0x005B5A86
	public int[] GetSkillNodeBranchIdList(int nodeId)
	{
		return ConfigBase<RoleConfig>.Instance.GetSkillNodeBranchIds(nodeId);
	}

	// Token: 0x06014A2F RID: 84527 RVA: 0x005B7893 File Offset: 0x005B5A93
	public void SetRoleBranch(int roleId, int skillBranch)
	{
		this.RoleSkillBranchMap[roleId] = skillBranch;
	}

	// Token: 0x06014A30 RID: 84528 RVA: 0x005B78A4 File Offset: 0x005B5AA4
	public bool IsRoleHasBranch(int roleId)
	{
		if (roleId == 0)
		{
			return false;
		}
		int[] roleBranchIdList = this.GetRoleBranchIdList(roleId);
		return roleBranchIdList != null && roleBranchIdList.Length == 2;
	}

	// Token: 0x06014A31 RID: 84529 RVA: 0x005B78C9 File Offset: 0x005B5AC9
	public bool CheckCanSwitchRoleBranch(bool showTips = false)
	{
		if (ControllerBase<RoleController>.Instance.CheckCharacterInBattleTag(true))
		{
			if (showTips)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("ForbiddenActionInFight", Array.Empty<object>());
			}
			return false;
		}
		return true;
	}

	// Token: 0x06014A32 RID: 84530 RVA: 0x005B78F2 File Offset: 0x005B5AF2
	public bool IsRoleOwned(int roleId)
	{
		return this.RoleInstanceMap.ContainsKey(roleId);
	}

	// Token: 0x06014A33 RID: 84531 RVA: 0x005B7900 File Offset: 0x005B5B00
	public int GetRoleBranchIndexById(int roleId, int skillBranchId)
	{
		return Array.FindIndex<int>(this.GetRoleBranchIdList(roleId), (int id) => skillBranchId == id);
	}

	// Token: 0x06014A34 RID: 84532 RVA: 0x005B7932 File Offset: 0x005B5B32
	public void StartGamePlayRoleEdit(ESkillBranchCacheType gamePlayType)
	{
		this.RoleSkillBranchCacheTypeInternal = gamePlayType;
	}

	// Token: 0x06014A35 RID: 84533 RVA: 0x005B793C File Offset: 0x005B5B3C
	public void ClearGamePlayRoleEdit(ESkillBranchCacheType gamePlayType)
	{
		Dictionary<int, int> dictionary2;
		Dictionary<int, int> dictionary = this.RoleSkillBranchGamePlayCacheMap.TryGetValue(gamePlayType, out dictionary2) ? dictionary2 : null;
		if (dictionary != null)
		{
			dictionary.Clear();
		}
		if (this.RoleSkillBranchCacheTypeInternal == gamePlayType)
		{
			this.RoleSkillBranchCacheTypeInternal = ESkillBranchCacheType.Normal;
		}
	}

	// Token: 0x06014A36 RID: 84534 RVA: 0x005B7977 File Offset: 0x005B5B77
	public void StartRecordRoleSkillBranchChangeRequest()
	{
		this.IsRecordRoleSkillBranchChangeRequset = true;
	}

	// Token: 0x06014A37 RID: 84535 RVA: 0x005B7980 File Offset: 0x005B5B80
	public void AddRoleSkillBranchChangeRequestRecord(int roleId)
	{
		if (this.IsRecordRoleSkillBranchChangeRequset)
		{
			this.RoleSkillBranchChangeRequsetRecord.Add(roleId);
		}
	}

	// Token: 0x06014A38 RID: 84536 RVA: 0x005B7997 File Offset: 0x005B5B97
	public List<int> StopRecordRoleSkillBranchChangeRequest()
	{
		List<int> result = new List<int>(this.RoleSkillBranchChangeRequsetRecord);
		this.RoleSkillBranchChangeRequsetRecord.Clear();
		this.IsRecordRoleSkillBranchChangeRequset = false;
		return result;
	}

	// Token: 0x06014A39 RID: 84537 RVA: 0x005B79B6 File Offset: 0x005B5BB6
	public bool RedDotRoleOrnamentCondition()
	{
		return ModelBase<RoleOrnamentModel>.Instance.CheckNewlyAcquiredOrnamentInMainView();
	}

	// Token: 0x06014A3A RID: 84538 RVA: 0x005B79C4 File Offset: 0x005B5BC4
	public void SetRoleSkillBranchGamePlayCache(int roleId, int branchId, ESkillBranchCacheType gamePlayType)
	{
		if (branchId == 0 || roleId == 0)
		{
			return;
		}
		Dictionary<int, int> dictionary2;
		Dictionary<int, int> dictionary = this.RoleSkillBranchGamePlayCacheMap.TryGetValue(gamePlayType, out dictionary2) ? dictionary2 : null;
		if (dictionary == null)
		{
			dictionary = new Dictionary<int, int>();
			this.RoleSkillBranchGamePlayCacheMap[gamePlayType] = dictionary;
		}
		dictionary[roleId] = branchId;
	}

	// Token: 0x06014A3B RID: 84539 RVA: 0x005B7A0B File Offset: 0x005B5C0B
	public int GetRoleSkillBranchIdInCurrentGamePlay(int roleId)
	{
		return this.GetRoleSkillBranchIdInGamePlay(roleId, this.RoleSkillBranchCacheTypeInternal);
	}

	// Token: 0x06014A3C RID: 84540 RVA: 0x005B7A1C File Offset: 0x005B5C1C
	public int GetRoleSkillBranchIdInGamePlay(int roleId, ESkillBranchCacheType gamePlayType)
	{
		if (roleId <= 0 || !this.IsRoleHasBranch(roleId))
		{
			return 0;
		}
		Dictionary<int, int> dictionary2;
		Dictionary<int, int> dictionary = this.RoleSkillBranchGamePlayCacheMap.TryGetValue(gamePlayType, out dictionary2) ? dictionary2 : null;
		int value;
		int? num = (dictionary != null && dictionary.TryGetValue(roleId, out value)) ? new int?(value) : null;
		if (num == null)
		{
			return this.GetRoleCurrentBranchId(roleId);
		}
		return num.Value;
	}

	// Token: 0x06014A3D RID: 84541 RVA: 0x005B7A8A File Offset: 0x005B5C8A
	public int GetRoleSkillBranchIndexInCurrentGamePlay(int roleId)
	{
		return this.GetRoleSkillBranchIndexInGamePlay(roleId, this.RoleSkillBranchCacheTypeInternal);
	}

	// Token: 0x06014A3E RID: 84542 RVA: 0x005B7A9C File Offset: 0x005B5C9C
	public int GetRoleSkillBranchIndexInGamePlay(int roleId, ESkillBranchCacheType gamePlayType)
	{
		int branchId = this.GetRoleSkillBranchIdInGamePlay(roleId, gamePlayType);
		if (branchId == 0)
		{
			return -1;
		}
		return Array.FindIndex<int>(this.GetRoleBranchIdList(roleId), (int id) => branchId == id);
	}

	// Token: 0x04009F32 RID: 40754
	private readonly Dictionary<int, RoleInstance> RoleInstanceMap = new Dictionary<int, RoleInstance>();

	// Token: 0x04009F33 RID: 40755
	private readonly Dictionary<int, RoleRobotData> RoleRobotDataMap = new Dictionary<int, RoleRobotData>();

	// Token: 0x04009F34 RID: 40756
	private readonly Dictionary<int, RoleRobotData> RoleCommonRobotDataMap = new Dictionary<int, RoleRobotData>();

	// Token: 0x04009F35 RID: 40757
	private readonly Dictionary<int, RoleSpecialRobotData> RoleSpecialRobotDataMap = new Dictionary<int, RoleSpecialRobotData>();

	// Token: 0x04009F36 RID: 40758
	private readonly HashSet<int> MainRoleIdSet = new HashSet<int>();

	// Token: 0x04009F37 RID: 40759
	private readonly HashSet<int> LightMainRoleIdSet = new HashSet<int>();

	// Token: 0x04009F38 RID: 40760
	private readonly Dictionary<int, int> MainRoleIdMap = new Dictionary<int, int>();

	// Token: 0x04009F39 RID: 40761
	private bool IsShowMultiSkillDescInternal;

	// Token: 0x04009F3A RID: 40762
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Dictionary<int, int[]> ResonantItemRoleMapInternal;

	// Token: 0x04009F3B RID: 40763
	private bool IsInRoleTrialInternal;

	// Token: 0x04009F3C RID: 40764
	public HashSet<int> RoleTrialIdList = new HashSet<int>();

	// Token: 0x04009F3D RID: 40765
	private bool CanUseSpecialTrialRoleInternal = true;

	// Token: 0x04009F3E RID: 40766
	private readonly Dictionary<int, int> RoleSkillBranchMap = new Dictionary<int, int>();

	// Token: 0x04009F3F RID: 40767
	private readonly Dictionary<ESkillBranchCacheType, Dictionary<int, int>> RoleSkillBranchGamePlayCacheMap = new Dictionary<ESkillBranchCacheType, Dictionary<int, int>>();

	// Token: 0x04009F40 RID: 40768
	private ESkillBranchCacheType RoleSkillBranchCacheTypeInternal;

	// Token: 0x04009F41 RID: 40769
	private readonly HashSet<int> RoleSkillBranchChangeRequsetRecord = new HashSet<int>();

	// Token: 0x04009F42 RID: 40770
	private bool IsRecordRoleSkillBranchChangeRequset;

	// Token: 0x04009F43 RID: 40771
	[Nullable(2)]
	private RoleSkillResponseData RoleSkillResponseDataInternal;

	// Token: 0x04009F44 RID: 40772
	private int[] CanChangeRoleIdList = new int[0];

	// Token: 0x04009F45 RID: 40773
	private bool InUltraSkillInternal;
}
