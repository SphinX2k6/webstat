using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using Aki.Protocol.Summon;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Ui;

// Token: 0x020028F3 RID: 10483
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class TrialRoleModel : ModelBase<TrialRoleModel>
{
	// Token: 0x06014D2D RID: 85293 RVA: 0x005C44E8 File Offset: 0x005C26E8
	public void AddTrialRoles(List<ITrialRoleCreateData> dataList)
	{
		foreach (ITrialRoleCreateData data in dataList)
		{
			this.AddTrialRole(data);
		}
	}

	// Token: 0x06014D2E RID: 85294 RVA: 0x005C4538 File Offset: 0x005C2738
	public void AddTrialRole(ITrialRoleCreateData data)
	{
		int trialRoleId = data.TrialRoleId;
		if (!RoleUtils.IsSpecialTrialRole(trialRoleId))
		{
			return;
		}
		TrialRoleConfig instance = ConfigBase<TrialRoleConfig>.Instance;
		int? num = (instance != null) ? instance.GetTrialRoleGroupId(trialRoleId) : null;
		if (num == null)
		{
			return;
		}
		if (this.TrialRoleGroupMap.ContainsKey(num.Value))
		{
			return;
		}
		TrialRoleGroupData trialRoleGroupData = new TrialRoleGroupData(trialRoleId);
		trialRoleGroupData.SetIsUnlocked(data.IsUnlocked);
		this.TrialRoleGroupList.Add(trialRoleGroupData);
		this.TrialRoleGroupMap[trialRoleGroupData.TrialRoleGroupId] = trialRoleGroupData;
		ETrialRoleType trialRoleType = trialRoleGroupData.TrialRoleType;
		if (!this.TrialRoleTypeMap.ContainsKey(trialRoleType))
		{
			this.TrialRoleTypeMap[trialRoleType] = new List<TrialRoleGroupData>();
		}
		this.TrialRoleTypeMap[trialRoleType].Add(trialRoleGroupData);
	}

	// Token: 0x06014D2F RID: 85295 RVA: 0x005C45FC File Offset: 0x005C27FC
	public List<TrialRoleGroupData> GetDataListByType(ETrialRoleType trialRoleType)
	{
		List<TrialRoleGroupData> result;
		if (this.TrialRoleTypeMap.TryGetValue(trialRoleType, out result))
		{
			return result;
		}
		return new List<TrialRoleGroupData>();
	}

	// Token: 0x06014D30 RID: 85296 RVA: 0x005C4620 File Offset: 0x005C2820
	[NullableContext(2)]
	public TrialRoleGroupData GetDataByGroupId(int groupId)
	{
		TrialRoleGroupData result;
		if (this.TrialRoleGroupMap.TryGetValue(groupId, out result))
		{
			return result;
		}
		return null;
	}

	// Token: 0x06014D31 RID: 85297 RVA: 0x005C4640 File Offset: 0x005C2840
	[NullableContext(2)]
	public TrialRoleGroupData GetCurUseTrialRole(ETrialRoleType trialRoleType)
	{
		TrialRoleGroupData result;
		if (this.CurUseTrailRoleMap.TryGetValue(trialRoleType, out result))
		{
			return result;
		}
		return null;
	}

	// Token: 0x06014D32 RID: 85298 RVA: 0x005C4660 File Offset: 0x005C2860
	public void SetCurUseTrialRole(int trialRoleId, roleInfo trialRoleInfo)
	{
		if (!RoleUtils.IsTrialRole(trialRoleId))
		{
			return;
		}
		TrialRoleConfig instance = ConfigBase<TrialRoleConfig>.Instance;
		int? num = (instance != null) ? instance.GetTrialRoleGroupId(trialRoleId) : null;
		if (num == null)
		{
			return;
		}
		this.SetCurUseTrialRoleByGroupId(num.Value);
		if (trialRoleInfo != null)
		{
			ETrialRoleType trialRoleType = RoleUtils.GetTrialRoleType(trialRoleId);
			TrialRoleGroupData curUseTrialRole = this.GetCurUseTrialRole(trialRoleType);
			if (curUseTrialRole != null)
			{
				curUseTrialRole.SetActivatedRoleAttr(trialRoleInfo.BaseProp, trialRoleInfo.AddProp);
			}
		}
	}

	// Token: 0x06014D33 RID: 85299 RVA: 0x005C46D0 File Offset: 0x005C28D0
	public void SetCurUseTrialRoleByGroupId(int groupId)
	{
		TrialRoleGroupData trialRoleGroupData;
		if (!this.TrialRoleGroupMap.TryGetValue(groupId, out trialRoleGroupData))
		{
			return;
		}
		ETrialRoleType trialRoleType = trialRoleGroupData.TrialRoleType;
		TrialRoleGroupData trialRoleGroupData2 = null;
		TrialRoleGroupData trialRoleGroupData3;
		if (this.CurUseTrailRoleMap.TryGetValue(trialRoleType, out trialRoleGroupData3))
		{
			trialRoleGroupData2 = trialRoleGroupData3;
		}
		if (trialRoleGroupData2 != null)
		{
			RoleSpecialRobotData trialRoleData = trialRoleGroupData2.TrialRoleData;
			if (trialRoleData != null)
			{
				trialRoleData.SetIsVisibleInFormation(false);
			}
		}
		if (trialRoleGroupData2 != null)
		{
			RoleSpecialRobotData trialRoleData2 = trialRoleGroupData2.TrialRoleData;
			if (trialRoleData2 != null)
			{
				trialRoleData2.SetIsVisibleInRoleSystem(false);
			}
		}
		this.CurUseTrailRoleMap[trialRoleType] = trialRoleGroupData;
		RoleSpecialRobotData trialRoleData3 = trialRoleGroupData.TrialRoleData;
		if (trialRoleData3 != null)
		{
			trialRoleData3.SetIsVisibleInFormation(true);
		}
		RoleSpecialRobotData trialRoleData4 = trialRoleGroupData.TrialRoleData;
		if (trialRoleData4 != null)
		{
			trialRoleData4.SetIsVisibleInRoleSystem(true);
		}
		Singleton<EventSystem>.Instance.Emit<int?, int>(EEventName.OnCurTrialRoleGroupChanged, (trialRoleGroupData2 != null) ? new int?(trialRoleGroupData2.TrialRoleGroupId) : null, trialRoleGroupData.TrialRoleGroupId);
	}

	// Token: 0x06014D34 RID: 85300 RVA: 0x005C4794 File Offset: 0x005C2994
	[NullableContext(2)]
	public void SetGroupTrialRoleId(int trialRoleId, roleInfo trialRoleInfo)
	{
		TrialRoleConfig instance = ConfigBase<TrialRoleConfig>.Instance;
		int? num = (instance != null) ? instance.GetTrialRoleGroupId(trialRoleId) : null;
		if (num == null)
		{
			return;
		}
		TrialRoleGroupData trialRoleGroupData;
		if (!this.TrialRoleGroupMap.TryGetValue(num.Value, out trialRoleGroupData))
		{
			return;
		}
		if (trialRoleGroupData.IsLocked())
		{
			this.SaveTrialRoleUnlockRedDotById(trialRoleGroupData.TrialRoleGroupId, true);
		}
		int trialRoleId2 = trialRoleGroupData.TrialRoleId;
		trialRoleGroupData.SetActivatedTrialRoleId(trialRoleId);
		trialRoleGroupData.SetIsUnlocked(true);
		bool flag = this.GetCurUseTrialRole(trialRoleGroupData.TrialRoleType) == trialRoleGroupData;
		trialRoleGroupData.SetIsVisibleInFormation(flag);
		trialRoleGroupData.SetIsVisibleInRoleSystem(flag);
		if (trialRoleInfo != null)
		{
			trialRoleGroupData.SetActivatedRoleAttr(trialRoleInfo.BaseProp, trialRoleInfo.AddProp);
		}
		EditFormationData getCurrentFormationData = ModelBase<EditFormationModel>.Instance.GetCurrentFormationData;
		if (((getCurrentFormationData != null) ? getCurrentFormationData.GetRoleIdList : null).Contains(trialRoleId))
		{
			TrialRoleConfig instance2 = ConfigBase<TrialRoleConfig>.Instance;
			TrialRoleInfo? trialRoleInfo2 = (instance2 != null) ? instance2.GetTrialRoleConfig(trialRoleId2) : null;
			TrialRoleConfig instance3 = ConfigBase<TrialRoleConfig>.Instance;
			TrialRoleInfo? trialRoleInfo3 = (instance3 != null) ? instance3.GetTrialRoleConfig(trialRoleId) : null;
			if (trialRoleInfo2 != null && trialRoleInfo3 != null && trialRoleInfo3.Value.Level > trialRoleInfo2.Value.Level)
			{
				this.TrialRoleLvUpSet.Add(num.Value);
			}
		}
		Singleton<EventSystem>.Instance.Emit<int, int, int>(EEventName.OnGroupTrialRoleChanged, trialRoleId2, trialRoleId, trialRoleGroupData.TrialRoleGroupId);
	}

	// Token: 0x06014D35 RID: 85301 RVA: 0x005C48F8 File Offset: 0x005C2AF8
	public void SaveTrialRoleUnlockRedDotById(int groupId, bool isUnlock)
	{
		Dictionary<int, bool> dictionary = LocalStorage.GetPlayer<Dictionary<int, bool>>(ELocalStoragePlayerKey.TrialRoleGroupUnlock, null);
		if (dictionary == null)
		{
			dictionary = new Dictionary<int, bool>();
		}
		bool flag;
		if (dictionary.TryGetValue(groupId, out flag) && flag == isUnlock)
		{
			return;
		}
		dictionary[groupId] = isUnlock;
		LocalStorage.SetPlayer<Dictionary<int, bool>>(ELocalStoragePlayerKey.TrialRoleGroupUnlock, dictionary);
		Singleton<EventSystem>.Instance.Emit(EEventName.OnGroupTrialRoleRedDotUpdate);
	}

	// Token: 0x06014D36 RID: 85302 RVA: 0x005C4950 File Offset: 0x005C2B50
	public bool GetTrialRoleUnlockRedDotById(int groupId)
	{
		Dictionary<int, bool> player = LocalStorage.GetPlayer<Dictionary<int, bool>>(ELocalStoragePlayerKey.TrialRoleGroupUnlock, null);
		bool flag;
		return player != null && player.TryGetValue(groupId, out flag) && flag;
	}

	// Token: 0x06014D37 RID: 85303 RVA: 0x005C497C File Offset: 0x005C2B7C
	public bool GetUpgradeRedDotById(int groupId)
	{
		TrialRoleGroupData dataByGroupId = this.GetDataByGroupId(groupId);
		return dataByGroupId != null && dataByGroupId.CanUpgrade();
	}

	// Token: 0x06014D38 RID: 85304 RVA: 0x005C499C File Offset: 0x005C2B9C
	public bool CheckCanOperateTrialRole()
	{
		ScrollingTipsController instance = ControllerBase<ScrollingTipsController>.Instance;
		if (!ModelBase<FunctionModel>.Instance.IsOpen(10007))
		{
			return false;
		}
		if (ModelBase<FunctionModel>.Instance.IsLockByBehaviorTree(10007))
		{
			instance.ShowTipsById(this.ForbiddenStatTips, Array.Empty<object>());
			return false;
		}
		if (!ModelBase<RoleModel>.Instance.CanUseSpecialTrialRole(null))
		{
			instance.ShowTipsById(this.ForbiddenStatTips, Array.Empty<object>());
			return false;
		}
		if (ControllerBase<InstanceDungeonEntranceController>.Instance.CheckInstanceShieldView(EUiViewName.EditFormationView))
		{
			instance.ShowTipsById(this.ForbiddenStatTips, Array.Empty<object>());
			return false;
		}
		SceneTeamModel instance2 = ModelBase<SceneTeamModel>.Instance;
		if (instance2.IsPhantomTeam)
		{
			instance.ShowTipsById("PhantomFormationEnterFormationTip", Array.Empty<object>());
			return false;
		}
		EntityHandle getCurrentEntity = instance2.GetCurrentEntity;
		if (getCurrentEntity == null || !getCurrentEntity.Valid)
		{
			return false;
		}
		int playerId = ModelBase<CreatureModel>.Instance.GetPlayerId();
		if (instance2.GetCurrentGroupLivingState(playerId) == ETeamLivingState.Dead)
		{
			return false;
		}
		WorldEntity entity = getCurrentEntity.Entity;
		BaseTagComponent baseTagComponent = (entity != null) ? entity.GetComponent<BaseTagComponent>() : null;
		if (baseTagComponent == null || !baseTagComponent.Valid)
		{
			return false;
		}
		WorldEntity entity2 = getCurrentEntity.Entity;
		CharacterBuffComponent characterBuffComponent = (entity2 != null) ? entity2.GetComponent<CharacterBuffComponent>() : null;
		if (characterBuffComponent == null || !characterBuffComponent.Valid)
		{
			return false;
		}
		WorldEntity entity3 = getCurrentEntity.Entity;
		RoleDriveVehicleComponent roleDriveVehicleComponent = (entity3 != null) ? entity3.GetComponent<RoleDriveVehicleComponent>() : null;
		if (roleDriveVehicleComponent != null && roleDriveVehicleComponent.IsOnVehicle)
		{
			instance.ShowTipsById(this.ForbiddenStatTips, Array.Empty<object>());
			return false;
		}
		if (ControllerBase<RoleController>.Instance.IsInRoleTrial())
		{
			instance.ShowTipsById(this.ForbiddenStatTips, Array.Empty<object>());
			ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("TrialRoleTeamLimit", Array.Empty<object>());
			return false;
		}
		if (baseTagComponent.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.位置状态.水中"]))
		{
			instance.ShowTipsById(this.ForbiddenStatTips, Array.Empty<object>());
			return false;
		}
		if (baseTagComponent.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.溺水"]))
		{
			instance.ShowTipsById(this.ForbiddenStatTips, Array.Empty<object>());
			return false;
		}
		if (baseTagComponent.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.位置状态.空中"]))
		{
			instance.ShowTipsById(this.ForbiddenStatTips, Array.Empty<object>());
			return false;
		}
		if (baseTagComponent.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.进入战斗"]))
		{
			instance.ShowTipsById("ForbiddenActionInFight", Array.Empty<object>());
			return false;
		}
		if (baseTagComponent.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.位置状态.攀爬"]))
		{
			instance.ShowTipsById(this.ForbiddenStatTips, Array.Empty<object>());
			return false;
		}
		if (baseTagComponent.HasTag(GameplayTagDefine.EGameplayTagId["角色.Common.BUFF通用标识.不能切人"]))
		{
			instance.ShowTipsById(this.ForbiddenStatTips, Array.Empty<object>());
			return false;
		}
		if (baseTagComponent.HasTag(GameplayTagDefine.EGameplayTagId["角色.BaseRole.技能通用标识.幻象变身中"]))
		{
			EntityHandle summonedEntity = PhantomUtil.GetSummonedEntity(getCurrentEntity.Entity, ESummonType.ConcomitantVision, 1);
			if (summonedEntity != null)
			{
				WorldEntity entity4 = summonedEntity.Entity;
				bool flag;
				if (entity4 == null)
				{
					flag = false;
				}
				else
				{
					BaseTagComponent component = entity4.GetComponent<BaseTagComponent>();
					flag = ((component != null) ? new bool?(component.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.位置状态.空中"])) : null).GetValueOrDefault();
				}
				if (flag)
				{
					instance.ShowTipsById(this.ForbiddenStatTips, Array.Empty<object>());
					return false;
				}
			}
		}
		if (characterBuffComponent.GetBuffTotalStackById(90003001L, false) > 0)
		{
			instance.ShowTipsById(this.ForbiddenStatTips, Array.Empty<object>());
			return false;
		}
		WorldEntity entity5 = getCurrentEntity.Entity;
		CharacterWalkOnWaterComponent characterWalkOnWaterComponent = (entity5 != null) ? entity5.GetComponent<CharacterWalkOnWaterComponent>() : null;
		if (characterWalkOnWaterComponent != null && characterWalkOnWaterComponent.WalkOnWaterStage > EWalkOnWaterStage.None)
		{
			instance.ShowTipsById(this.ForbiddenStatTips, Array.Empty<object>());
			return false;
		}
		return instance2.CurrentGroupType.GetValueOrDefault() == ETeamGroupType.Battle;
	}

	// Token: 0x06014D39 RID: 85305 RVA: 0x005C4D20 File Offset: 0x005C2F20
	public void SetTrialRoleVisibility(int roleId, bool isVisible)
	{
		if (!RoleUtils.IsSpecialTrialRole(roleId))
		{
			return;
		}
		RoleSpecialRobotData roleSpecialRobotData = ModelBase<RoleModel>.Instance.GetRoleDataById(roleId, true) as RoleSpecialRobotData;
		if (roleSpecialRobotData == null)
		{
			return;
		}
		roleSpecialRobotData.SetIsVisibleInFormation(isVisible);
		roleSpecialRobotData.SetIsVisibleInRoleSystem(isVisible);
	}

	// Token: 0x0400A03A RID: 41018
	private readonly List<TrialRoleGroupData> TrialRoleGroupList = new List<TrialRoleGroupData>();

	// Token: 0x0400A03B RID: 41019
	private readonly Dictionary<int, TrialRoleGroupData> TrialRoleGroupMap = new Dictionary<int, TrialRoleGroupData>();

	// Token: 0x0400A03C RID: 41020
	private readonly Dictionary<ETrialRoleType, List<TrialRoleGroupData>> TrialRoleTypeMap = new Dictionary<ETrialRoleType, List<TrialRoleGroupData>>();

	// Token: 0x0400A03D RID: 41021
	private readonly Dictionary<ETrialRoleType, TrialRoleGroupData> CurUseTrailRoleMap = new Dictionary<ETrialRoleType, TrialRoleGroupData>();

	// Token: 0x0400A03E RID: 41022
	private readonly HashSet<int> TrialRoleLvUpSet = new HashSet<int>();

	// Token: 0x0400A03F RID: 41023
	private readonly string ForbiddenStatTips = "TrialRoleOperateForbidState";
}
