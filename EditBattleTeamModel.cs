using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Module.InstanceDungeon.Define;
using CSharpScript.Game.Module.RoleUi;

// Token: 0x02001B3C RID: 6972
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class EditBattleTeamModel : ModelBase<EditBattleTeamModel>
{
	// Token: 0x17001021 RID: 4129
	// (get) Token: 0x0600C915 RID: 51477 RVA: 0x0035430D File Offset: 0x0035250D
	// (set) Token: 0x0600C916 RID: 51478 RVA: 0x00354315 File Offset: 0x00352515
	public bool NeedEntrance
	{
		get
		{
			return this.IsNeedEntrance;
		}
		set
		{
			this.IsNeedEntrance = value;
		}
	}

	// Token: 0x17001022 RID: 4130
	// (get) Token: 0x0600C917 RID: 51479 RVA: 0x0035431E File Offset: 0x0035251E
	// (set) Token: 0x0600C918 RID: 51480 RVA: 0x00354326 File Offset: 0x00352526
	public bool InstanceMultiEnter
	{
		get
		{
			return this.InstanceMultiEnterInternal;
		}
		set
		{
			this.InstanceMultiEnterInternal = value;
		}
	}

	// Token: 0x17001023 RID: 4131
	// (get) Token: 0x0600C919 RID: 51481 RVA: 0x0035432F File Offset: 0x0035252F
	// (set) Token: 0x0600C91A RID: 51482 RVA: 0x00354337 File Offset: 0x00352537
	public bool CanUseSpecialTrialRole
	{
		get
		{
			return this.CanUseSpecialTrialRoleIntl;
		}
		set
		{
			this.CanUseSpecialTrialRoleIntl = value;
		}
	}

	// Token: 0x0600C91B RID: 51483 RVA: 0x00354340 File Offset: 0x00352540
	public void SetInstanceDungeonId(int? instanceDungeonId)
	{
		this.InstanceDungeonId = instanceDungeonId;
	}

	// Token: 0x17001024 RID: 4132
	// (get) Token: 0x0600C91C RID: 51484 RVA: 0x00354349 File Offset: 0x00352549
	public int? GetInstanceDungeonId
	{
		get
		{
			return this.InstanceDungeonId;
		}
	}

	// Token: 0x17001025 RID: 4133
	// (get) Token: 0x0600C91D RID: 51485 RVA: 0x00354354 File Offset: 0x00352554
	public int[] GetAllRoleConfigIdList
	{
		get
		{
			List<int> list = new List<int>();
			for (int i = 1; i <= 4; i++)
			{
				EditBattleRoleSlotData roleSlotData = this.GetRoleSlotData(i);
				if (roleSlotData != null && roleSlotData.HasRole)
				{
					int configId = roleSlotData.GetRoleData.ConfigId;
					list.Add(configId);
				}
			}
			return list.ToArray();
		}
	}

	// Token: 0x17001026 RID: 4134
	// (get) Token: 0x0600C91E RID: 51486 RVA: 0x003543A0 File Offset: 0x003525A0
	public bool IsAllRoleDie
	{
		get
		{
			foreach (EditBattleRoleSlotData editBattleRoleSlotData in this.GetAllRoleSlotData)
			{
				if (editBattleRoleSlotData.HasRole)
				{
					int configId = editBattleRoleSlotData.GetRoleData.ConfigId;
					if (this.IsTrialRole(configId))
					{
						return false;
					}
					if (!ModelBase<EditFormationModel>.Instance.IsRoleDead(configId))
					{
						return false;
					}
				}
			}
			return true;
		}
	}

	// Token: 0x17001027 RID: 4135
	// (get) Token: 0x0600C91F RID: 51487 RVA: 0x003543F8 File Offset: 0x003525F8
	[Nullable(new byte[]
	{
		0,
		1,
		1
	})]
	public ValueTuple<List<int>, List<int>> GetOwnRoleConfigIdList
	{
		[return: Nullable(new byte[]
		{
			0,
			1,
			1
		})]
		get
		{
			List<int> list = new List<int>();
			List<int> list2 = new List<int>();
			int? id = ModelBase<PlayerInfoModel>.Instance.GetId();
			for (int i = 1; i <= 4; i++)
			{
				EditBattleRoleSlotData roleSlotData = this.GetRoleSlotData(i);
				if (roleSlotData != null && roleSlotData.HasRole)
				{
					EditBattleRoleData getRoleData = roleSlotData.GetRoleData;
					int? num = id;
					int playerId = getRoleData.PlayerId;
					if (num.GetValueOrDefault() == playerId & num != null)
					{
						int configId = getRoleData.ConfigId;
						list.Add(configId);
						list2.Add(i - 1);
					}
				}
			}
			return new ValueTuple<List<int>, List<int>>(list, list2);
		}
	}

	// Token: 0x17001028 RID: 4136
	// (get) Token: 0x0600C920 RID: 51488 RVA: 0x0035448C File Offset: 0x0035268C
	public bool IsMultiInstanceDungeon
	{
		get
		{
			InstanceDungeon? getCurrentDungeonConfig = this.GetCurrentDungeonConfig;
			if (getCurrentDungeonConfig == null)
			{
				return this.InstanceMultiEnter;
			}
			return getCurrentDungeonConfig.Value.OnlineType != InstOnlineType.Single && this.InstanceMultiEnter;
		}
	}

	// Token: 0x0600C921 RID: 51489 RVA: 0x003544CC File Offset: 0x003526CC
	public void SetLeaderPlayerId(int? playerId)
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Formation;
		ELogAuthor author = ELogAuthor.LYY;
		string message = "[EditBattleTeam]设置队长";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("PlayerId", playerId);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		this.LeaderPlayerId = playerId;
	}

	// Token: 0x17001029 RID: 4137
	// (get) Token: 0x0600C922 RID: 51490 RVA: 0x0035450C File Offset: 0x0035270C
	public int? GetLeaderPlayerId
	{
		get
		{
			return this.LeaderPlayerId;
		}
	}

	// Token: 0x1700102A RID: 4138
	// (get) Token: 0x0600C923 RID: 51491 RVA: 0x00354514 File Offset: 0x00352714
	public bool GetLeaderIsSelf
	{
		get
		{
			if (this.GetLeaderPlayerId == null)
			{
				return false;
			}
			int? id = ModelBase<PlayerInfoModel>.Instance.GetId();
			int? getLeaderPlayerId = this.GetLeaderPlayerId;
			return id.GetValueOrDefault() == getLeaderPlayerId.GetValueOrDefault() & id != null == (getLeaderPlayerId != null);
		}
	}

	// Token: 0x1700102B RID: 4139
	// (get) Token: 0x0600C924 RID: 51492 RVA: 0x00354566 File Offset: 0x00352766
	public bool IsInInstanceDungeon
	{
		get
		{
			return ControllerBase<GameModeController>.Instance.IsInInstance();
		}
	}

	// Token: 0x1700102C RID: 4140
	// (get) Token: 0x0600C925 RID: 51493 RVA: 0x00354574 File Offset: 0x00352774
	public bool IsMatchingTeamLackConfirmBoxCanEnterInstance
	{
		get
		{
			return this.GetInstanceDungeonId != null && ConfigBase<InstanceDungeonEntranceConfig>.Instance.GetEntranceIdByInstanceId(this.GetInstanceDungeonId.Value) != 9000;
		}
	}

	// Token: 0x0600C926 RID: 51494 RVA: 0x003545B8 File Offset: 0x003527B8
	[NullableContext(0)]
	[return: TupleElementNames(new string[]
	{
		"CanAdd",
		"LimitRoleId"
	})]
	public ValueTuple<bool, int> GetAllRoleCanAddToTeam()
	{
		foreach (int num in this.GetAllRoleConfigIdList)
		{
			if (!this.CanAddRoleToEditTeam(num))
			{
				return new ValueTuple<bool, int>(false, num);
			}
		}
		return new ValueTuple<bool, int>(true, 0);
	}

	// Token: 0x0600C927 RID: 51495 RVA: 0x003545F8 File Offset: 0x003527F8
	public void InitTrailRoleInstance()
	{
		this.TrialRoleInstanceMap.Clear();
		int[] trialRoleArray = this.GetCurrentFightFormation.Value.GetTrialRoleArray();
		RoleModel instance = ModelBase<RoleModel>.Instance;
		if (trialRoleArray == null)
		{
			return;
		}
		foreach (int num in trialRoleArray)
		{
			if (!this.TrialRoleInstanceMap.ContainsKey(num))
			{
				RoleDataBase roleDataById = instance.GetRoleDataById(ConfigBase<RoleConfig>.Instance.GetTrialRoleIdConfigByGroupId(num), true);
				this.TrialRoleInstanceMap[num] = roleDataById;
			}
		}
	}

	// Token: 0x0600C928 RID: 51496 RVA: 0x00354684 File Offset: 0x00352884
	public RoleDataBase[] GetRoleList()
	{
		RoleModel instance = ModelBase<RoleModel>.Instance;
		List<RoleDataBase> list = new List<RoleDataBase>();
		Dictionary<int, RoleDataBase> roleDataMap = instance.GetRoleDataMap(true);
		if (this.HasLimitRole())
		{
			foreach (int id in this.GetCurrentLimitRoleIdList())
			{
				RoleDataBase roleDataById = instance.GetRoleDataById(id, true);
				if (roleDataById != null)
				{
					int dataId = roleDataById.GetDataId();
					if (this.CanAddRoleToEditTeam(dataId))
					{
						list.Add(roleDataById);
					}
				}
			}
		}
		else
		{
			foreach (RoleDataBase roleDataBase in roleDataMap.Values)
			{
				int dataId2 = roleDataBase.GetDataId();
				if (this.CanAddRoleToEditTeam(dataId2))
				{
					list.Add(roleDataBase);
				}
			}
			foreach (RoleDataBase item in this.TrialRoleInstanceMap.Values)
			{
				list.Add(item);
			}
		}
		if (this.CurrentGenderRoleList == null)
		{
			this.CurrentGenderRoleList = new List<int>().ToArray();
			int sex = ModelBase<WorldLevelModel>.Instance.Sex;
			IReadOnlyList<MainRoleConfig> mainRoleByGender = ConfigBase<RoleConfig>.Instance.GetMainRoleByGender((LoginDefine.ELoginSex)sex);
			if (mainRoleByGender != null)
			{
				List<int> list2 = new List<int>();
				foreach (MainRoleConfig mainRoleConfig in mainRoleByGender)
				{
					list2.Add(mainRoleConfig.Id);
				}
				this.CurrentGenderRoleList = list2.ToArray();
			}
		}
		int j = 0;
		while (j < list.Count)
		{
			int roleId = list[j].GetRoleId();
			if (instance.IsMainRole(roleId) && !this.CurrentGenderRoleList.Contains(roleId))
			{
				list.RemoveAt(j);
			}
			else
			{
				j++;
			}
		}
		return list.ToArray();
	}

	// Token: 0x0600C929 RID: 51497 RVA: 0x00354880 File Offset: 0x00352A80
	public bool HasAnyLimit()
	{
		return this.HasLimitRole() || this.HasLimitCount() || this.HasLimitElement() || this.HasLimitExtra();
	}

	// Token: 0x0600C92A RID: 51498 RVA: 0x003548AC File Offset: 0x00352AAC
	[NullableContext(2)]
	private int[] GetCurrentLimitRoleIdList()
	{
		FightFormation? getCurrentFightFormation = this.GetCurrentFightFormation;
		if (getCurrentFightFormation == null)
		{
			return null;
		}
		return getCurrentFightFormation.Value.GetLimitRoleArray();
	}

	// Token: 0x0600C92B RID: 51499 RVA: 0x003548DC File Offset: 0x00352ADC
	private bool HasLimitRole()
	{
		int[] currentLimitRoleIdList = this.GetCurrentLimitRoleIdList();
		return currentLimitRoleIdList != null && currentLimitRoleIdList.Length != 0;
	}

	// Token: 0x0600C92C RID: 51500 RVA: 0x003548FC File Offset: 0x00352AFC
	private bool HasLimitCount()
	{
		FightFormation? getCurrentFightFormation = this.GetCurrentFightFormation;
		if (getCurrentFightFormation == null)
		{
			return false;
		}
		int limitCountLength = getCurrentFightFormation.Value.LimitCountLength;
		return limitCountLength != 3 && limitCountLength > 0;
	}

	// Token: 0x0600C92D RID: 51501 RVA: 0x00354938 File Offset: 0x00352B38
	private bool HasLimitElement()
	{
		FightFormation? getCurrentFightFormation = this.GetCurrentFightFormation;
		return getCurrentFightFormation != null && getCurrentFightFormation.Value.LitmitElementLength > 0;
	}

	// Token: 0x0600C92E RID: 51502 RVA: 0x00354969 File Offset: 0x00352B69
	private bool HasLimitExtra()
	{
		return this.IsEditBattleTeamForMowingInstance();
	}

	// Token: 0x0600C92F RID: 51503 RVA: 0x00354978 File Offset: 0x00352B78
	public bool IsEditBattleTeamForMowingInstance()
	{
		if (this.InstanceDungeonId == null)
		{
			return false;
		}
		InstanceDungeon? config = ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(this.InstanceDungeonId.Value);
		return ((config != null) ? new int?(config.GetValueOrDefault().InstSubType) : null).Value == 19;
	}

	// Token: 0x0600C930 RID: 51504 RVA: 0x003549E0 File Offset: 0x00352BE0
	public bool CanAddRoleToEditTeam(int configId)
	{
		if (this.IsTrialRole(configId))
		{
			return true;
		}
		bool flag = this.IsInLimitRole(configId);
		bool flag2 = this.IsInLimitElement(configId);
		return flag && flag2;
	}

	// Token: 0x0600C931 RID: 51505 RVA: 0x00354A0C File Offset: 0x00352C0C
	public bool IsInLimitRoleCount(int roleCount)
	{
		Span<int> limitRoleCountList = this.GetLimitRoleCountList();
		return limitRoleCountList == null || limitRoleCountList.Contains(roleCount);
	}

	// Token: 0x0600C932 RID: 51506 RVA: 0x00354A38 File Offset: 0x00352C38
	public bool IsInLimitRole(int roleConfigId)
	{
		FightFormation? getCurrentFightFormation = this.GetCurrentFightFormation;
		return getCurrentFightFormation == null || getCurrentFightFormation.Value.LimitRoleLength <= 0 || getCurrentFightFormation.Value.GetLimitRoleBytes().Contains(roleConfigId);
	}

	// Token: 0x0600C933 RID: 51507 RVA: 0x00354A80 File Offset: 0x00352C80
	public bool IsInLimitElement(int roleConfigId)
	{
		FightFormation? getCurrentFightFormation = this.GetCurrentFightFormation;
		if (getCurrentFightFormation == null)
		{
			return true;
		}
		RoleInfo? roleConfig = ConfigBase<RoleConfig>.Instance.GetRoleConfig(roleConfigId);
		if (roleConfig == null)
		{
			return false;
		}
		int elementId = roleConfig.Value.ElementId;
		return getCurrentFightFormation.Value.LitmitElementLength <= 0 || getCurrentFightFormation.Value.GetLitmitElementBytes().Contains(elementId);
	}

	// Token: 0x0600C934 RID: 51508 RVA: 0x00354AF4 File Offset: 0x00352CF4
	[NullableContext(0)]
	public Span<int> GetLimitRoleCountList()
	{
		FightFormation? getCurrentFightFormation = this.GetCurrentFightFormation;
		if (getCurrentFightFormation == null)
		{
			return Span<int>.Empty;
		}
		if (getCurrentFightFormation.Value.LimitCountLength == 0)
		{
			return Span<int>.Empty;
		}
		return getCurrentFightFormation.Value.GetLimitCountBytes();
	}

	// Token: 0x0600C935 RID: 51509 RVA: 0x00354B40 File Offset: 0x00352D40
	public unsafe int GetMaxLimitRoleCount()
	{
		Span<int> limitRoleCountList = this.GetLimitRoleCountList();
		if (limitRoleCountList.Length == 0)
		{
			return 0;
		}
		int index = limitRoleCountList.Length - 1;
		return *limitRoleCountList[index];
	}

	// Token: 0x1700102D RID: 4141
	// (get) Token: 0x0600C936 RID: 51510 RVA: 0x00354B74 File Offset: 0x00352D74
	public InstanceDungeon? GetCurrentDungeonConfig
	{
		get
		{
			if (this.GetInstanceDungeonId == null)
			{
				return null;
			}
			return new InstanceDungeon?(ConfigBase<EditBattleTeamConfig>.Instance.GetDungeonConfig(this.GetInstanceDungeonId.Value));
		}
	}

	// Token: 0x1700102E RID: 4142
	// (get) Token: 0x0600C937 RID: 51511 RVA: 0x00354BB8 File Offset: 0x00352DB8
	public FightFormation? GetCurrentFightFormation
	{
		get
		{
			InstanceDungeon? getCurrentDungeonConfig = this.GetCurrentDungeonConfig;
			if (getCurrentDungeonConfig == null)
			{
				return null;
			}
			int fightFormationId = getCurrentDungeonConfig.Value.FightFormationId;
			if (fightFormationId == 0)
			{
				return null;
			}
			return ConfigBase<EditBattleTeamConfig>.Instance.GetFightFormationConfig(fightFormationId);
		}
	}

	// Token: 0x0600C938 RID: 51512 RVA: 0x00354C08 File Offset: 0x00352E08
	public void CreateAllRoleSlotData()
	{
		for (int i = 1; i <= 4; i++)
		{
			EditBattleRoleSlotData value = new EditBattleRoleSlotData(i);
			this.RoleSlotDataMap[i] = value;
		}
	}

	// Token: 0x0600C939 RID: 51513 RVA: 0x00354C38 File Offset: 0x00352E38
	public void ResetAllRoleSlotData()
	{
		foreach (EditBattleRoleSlotData editBattleRoleSlotData in this.RoleSlotDataMap.Values)
		{
			editBattleRoleSlotData.ResetRoleData();
		}
		this.TrialRoleInstanceMap.Clear();
		Singleton<Log>.Instance.Info(ELogModule.Formation, ELogAuthor.LYY, "[EditBattleTeam]还原所有战前编队数据", default(ReadOnlySpan<ValueTuple<string, object>>));
	}

	// Token: 0x0600C93A RID: 51514 RVA: 0x00354CB4 File Offset: 0x00352EB4
	public bool HasSameConfigIdInAnyOwnRoleSlot(int configId)
	{
		foreach (EditBattleRoleSlotData editBattleRoleSlotData in this.RoleSlotDataMap.Values)
		{
			EditBattleRoleData getRoleData = editBattleRoleSlotData.GetRoleData;
			if (getRoleData != null && getRoleData.IsSelf)
			{
				int? getRoleConfigId = editBattleRoleSlotData.GetRoleConfigId;
				if (getRoleConfigId.GetValueOrDefault() == configId & getRoleConfigId != null)
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x0600C93B RID: 51515 RVA: 0x00354D40 File Offset: 0x00352F40
	public int GetPlayerRoleNumber(int? playerId)
	{
		int num = 0;
		foreach (KeyValuePair<int, EditBattleRoleSlotData> keyValuePair in this.RoleSlotDataMap)
		{
			EditBattleRoleSlotData value = keyValuePair.Value;
			int? num2 = playerId;
			EditBattleRoleData getRoleData = value.GetRoleData;
			int? num3 = (getRoleData != null) ? new int?(getRoleData.PlayerId) : null;
			if (num2.GetValueOrDefault() == num3.GetValueOrDefault() & num2 != null == (num3 != null))
			{
				num++;
			}
		}
		return num;
	}

	// Token: 0x0600C93C RID: 51516 RVA: 0x00354DE0 File Offset: 0x00352FE0
	public int GetParentRolePositionInEditBattleTeam(int roleConfigId)
	{
		if (!this.IsTrialRole(roleConfigId))
		{
			foreach (EditBattleRoleSlotData editBattleRoleSlotData in this.GetAllRoleSlotData)
			{
				EditBattleRoleData getRoleData = editBattleRoleSlotData.GetRoleData;
				if (getRoleData != null)
				{
					TrialRoleInfo? getTrialRoleConfig = getRoleData.GetTrialRoleConfig;
					if (getTrialRoleConfig != null && getTrialRoleConfig.Value.ParentId == roleConfigId)
					{
						return editBattleRoleSlotData.GetPosition;
					}
				}
			}
			return -1;
		}
		int id = ConfigBase<RoleConfig>.Instance.GetRoleConfig(roleConfigId).Value.Id;
		EditBattleRoleSlotData slotDataByConfigId = this.GetSlotDataByConfigId(id);
		if (slotDataByConfigId == null)
		{
			return -1;
		}
		return slotDataByConfigId.GetPosition;
	}

	// Token: 0x1700102F RID: 4143
	// (get) Token: 0x0600C93D RID: 51517 RVA: 0x00354E84 File Offset: 0x00353084
	public int GetOwnRoleCountInRoleSlot
	{
		get
		{
			int num = 0;
			foreach (EditBattleRoleSlotData editBattleRoleSlotData in this.RoleSlotDataMap.Values)
			{
				EditBattleRoleData getRoleData = editBattleRoleSlotData.GetRoleData;
				if (getRoleData != null && getRoleData.IsSelf)
				{
					num++;
				}
			}
			return num;
		}
	}

	// Token: 0x0600C93E RID: 51518 RVA: 0x00354EEC File Offset: 0x003530EC
	public int GetRoleCountInRoleSlot()
	{
		int num = 0;
		using (Dictionary<int, EditBattleRoleSlotData>.ValueCollection.Enumerator enumerator = this.RoleSlotDataMap.Values.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.GetRoleData != null)
				{
					num++;
				}
			}
		}
		return num;
	}

	// Token: 0x0600C93F RID: 51519 RVA: 0x00354F4C File Offset: 0x0035314C
	public unsafe void PrintRoleSlotsDebugString()
	{
		for (int i = 1; i <= 4; i++)
		{
			EditBattleRoleSlotData roleSlotData = this.GetRoleSlotData(i);
			if (roleSlotData.HasRole)
			{
				EditBattleRoleData getRoleData = roleSlotData.GetRoleData;
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Formation;
				ELogAuthor author = ELogAuthor.LYY;
				string message = "[EditBattleTeam]战前编队 Position 号位的角色信息: RoleData ";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Position", i);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("RoleData", getRoleData);
				instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			}
			else
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.Formation;
				ELogAuthor author2 = ELogAuthor.LYY;
				string message2 = "[EditBattleTeam]战前编队 Position 号位没有角色";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Position", i);
				instance2.Info(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
		}
	}

	// Token: 0x0600C940 RID: 51520 RVA: 0x0035500A File Offset: 0x0035320A
	public void SetCurrentEditPosition(int position)
	{
		this.CurrentEditPosition = new int?(position);
	}

	// Token: 0x17001030 RID: 4144
	// (get) Token: 0x0600C941 RID: 51521 RVA: 0x00355018 File Offset: 0x00353218
	[Nullable(2)]
	public EditBattleRoleSlotData GetCurrentEditRoleSlotData
	{
		[NullableContext(2)]
		get
		{
			if (this.CurrentEditPosition == null)
			{
				return null;
			}
			return this.GetRoleSlotData(this.CurrentEditPosition.Value);
		}
	}

	// Token: 0x0600C942 RID: 51522 RVA: 0x0035503C File Offset: 0x0035323C
	public bool IsInEditBattleTeam(int roleConfigId, bool isOwnRole = false)
	{
		int? id = ModelBase<PlayerInfoModel>.Instance.GetId();
		foreach (EditBattleRoleSlotData editBattleRoleSlotData in this.RoleSlotDataMap.Values)
		{
			EditBattleRoleData getRoleData = editBattleRoleSlotData.GetRoleData;
			if (getRoleData != null)
			{
				if (isOwnRole)
				{
					int? num = id;
					int playerId = getRoleData.PlayerId;
					if (!(num.GetValueOrDefault() == playerId & num != null))
					{
						continue;
					}
				}
				if (getRoleData.ConfigId == roleConfigId)
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x0600C943 RID: 51523 RVA: 0x003550D4 File Offset: 0x003532D4
	public int GetEditBattleTeamPositionByConfigId(int roleConfigId)
	{
		EditBattleRoleSlotData slotDataByConfigId = this.GetSlotDataByConfigId(roleConfigId);
		if (slotDataByConfigId == null)
		{
			return -1;
		}
		return slotDataByConfigId.GetPosition;
	}

	// Token: 0x0600C944 RID: 51524 RVA: 0x003550F4 File Offset: 0x003532F4
	[NullableContext(2)]
	public EditBattleRoleSlotData GetSlotDataByConfigId(int roleConfigId)
	{
		foreach (EditBattleRoleSlotData editBattleRoleSlotData in this.RoleSlotDataMap.Values)
		{
			EditBattleRoleData getRoleData = editBattleRoleSlotData.GetRoleData;
			if (getRoleData != null && getRoleData.ConfigId == roleConfigId)
			{
				return editBattleRoleSlotData;
			}
		}
		return null;
	}

	// Token: 0x0600C945 RID: 51525 RVA: 0x00355160 File Offset: 0x00353360
	public void InitAllRoleSlotData()
	{
		if (!this.IsMultiInstanceDungeon)
		{
			this.InitAllSingleRoleData();
			return;
		}
		ModelBase<InstanceDungeonModel>.Instance.SetPrewarFormationDataList();
		IReadOnlyList<PrewarFormationData> prewarFormationDataList = ModelBase<InstanceDungeonModel>.Instance.GetPrewarFormationDataList();
		this.InitAllMultiRoleData(prewarFormationDataList.ToArray<PrewarFormationData>());
	}

	// Token: 0x0600C946 RID: 51526 RVA: 0x0035519D File Offset: 0x0035339D
	[NullableContext(2)]
	public EditBattleRoleSlotData GetRoleSlotData(int position)
	{
		if (!this.RoleSlotDataMap.ContainsKey(position))
		{
			return null;
		}
		return this.RoleSlotDataMap[position];
	}

	// Token: 0x0600C947 RID: 51527 RVA: 0x003551BC File Offset: 0x003533BC
	public void RefreshAllEmptySlotData()
	{
		for (int i = 1; i <= this.RoleSlotDataMap.Count; i++)
		{
			if (this.RoleSlotDataMap.ContainsKey(i))
			{
				EditBattleRoleSlotData editBattleRoleSlotData = this.RoleSlotDataMap[i];
				if (editBattleRoleSlotData.GetRoleData == null)
				{
					for (int j = i + 1; j <= this.RoleSlotDataMap.Count; j++)
					{
						if (this.RoleSlotDataMap.ContainsKey(j))
						{
							EditBattleRoleSlotData editBattleRoleSlotData2 = this.RoleSlotDataMap[j];
							EditBattleRoleData getRoleData = editBattleRoleSlotData2.GetRoleData;
							if (getRoleData != null)
							{
								editBattleRoleSlotData.SetRoleData(getRoleData);
								editBattleRoleSlotData2.ResetRoleData();
								break;
							}
						}
					}
				}
			}
		}
	}

	// Token: 0x17001031 RID: 4145
	// (get) Token: 0x0600C948 RID: 51528 RVA: 0x00355254 File Offset: 0x00353454
	public EditBattleRoleSlotData[] GetAllRoleSlotData
	{
		get
		{
			List<EditBattleRoleSlotData> list = new List<EditBattleRoleSlotData>();
			foreach (EditBattleRoleSlotData item in this.RoleSlotDataMap.Values)
			{
				list.Add(item);
			}
			return list.ToArray();
		}
	}

	// Token: 0x17001032 RID: 4146
	// (get) Token: 0x0600C949 RID: 51529 RVA: 0x003552B8 File Offset: 0x003534B8
	public int[] SelfRoleSlotDataRoleIdList
	{
		get
		{
			List<int> list = new List<int>();
			foreach (EditBattleRoleSlotData editBattleRoleSlotData in this.RoleSlotDataMap.Values)
			{
				EditBattleRoleData getRoleData = editBattleRoleSlotData.GetRoleData;
				if (getRoleData != null && getRoleData.IsSelf)
				{
					int? getRoleConfigId = editBattleRoleSlotData.GetRoleConfigId;
					int num = 0;
					if (!(getRoleConfigId.GetValueOrDefault() == num & getRoleConfigId != null))
					{
						list.Add(editBattleRoleSlotData.GetRoleConfigId.Value);
					}
				}
			}
			return list.ToArray();
		}
	}

	// Token: 0x0600C94A RID: 51530 RVA: 0x0035535C File Offset: 0x0035355C
	public void SetPlayerReady(int playerId, bool bReady)
	{
		foreach (KeyValuePair<int, EditBattleRoleSlotData> keyValuePair in this.RoleSlotDataMap)
		{
			EditBattleRoleSlotData value = keyValuePair.Value;
			if (value.HasRole)
			{
				EditBattleRoleData getRoleData = value.GetRoleData;
				if (getRoleData.PlayerId == playerId)
				{
					getRoleData.SetReady(bReady);
					int getPosition = value.GetPosition;
					Singleton<EventSystem>.Instance.Emit<int, bool>(EEventName.OnRefreshEditBattleRoleReady, getPosition, bReady);
				}
			}
		}
	}

	// Token: 0x17001033 RID: 4147
	// (get) Token: 0x0600C94B RID: 51531 RVA: 0x003553EC File Offset: 0x003535EC
	public bool GetIsAllReady
	{
		get
		{
			EditBattleRoleSlotData[] getAllRoleSlotData = this.GetAllRoleSlotData;
			int? id = ModelBase<PlayerInfoModel>.Instance.GetId();
			bool getLeaderIsSelf = this.GetLeaderIsSelf;
			foreach (EditBattleRoleSlotData editBattleRoleSlotData in getAllRoleSlotData)
			{
				if (editBattleRoleSlotData.HasRole)
				{
					EditBattleRoleData getRoleData = editBattleRoleSlotData.GetRoleData;
					if (getLeaderIsSelf)
					{
						int playerId = getRoleData.PlayerId;
						int? num = id;
						int num2 = playerId;
						if (num.GetValueOrDefault() == num2 & num != null)
						{
							goto IL_63;
						}
					}
					if (!getRoleData.IsReady)
					{
						return false;
					}
				}
				IL_63:;
			}
			return true;
		}
	}

	// Token: 0x17001034 RID: 4148
	// (get) Token: 0x0600C94C RID: 51532 RVA: 0x00355468 File Offset: 0x00353668
	public bool HasSameRole
	{
		get
		{
			EditBattleRoleSlotData[] getAllRoleSlotData = this.GetAllRoleSlotData;
			foreach (EditBattleRoleSlotData editBattleRoleSlotData in getAllRoleSlotData)
			{
				if (editBattleRoleSlotData.HasRole && editBattleRoleSlotData.GetRoleData.IsSelf)
				{
					EditBattleRoleData getRoleData = editBattleRoleSlotData.GetRoleData;
					int num = getRoleData.ConfigId;
					if (this.IsTrialRole(num))
					{
						num = getRoleData.GetTrialRoleConfig.Value.ParentId;
					}
					foreach (EditBattleRoleSlotData editBattleRoleSlotData2 in getAllRoleSlotData)
					{
						if (editBattleRoleSlotData2.HasRole && editBattleRoleSlotData.GetPosition != editBattleRoleSlotData2.GetPosition)
						{
							EditBattleRoleData getRoleData2 = editBattleRoleSlotData2.GetRoleData;
							int num2 = getRoleData2.ConfigId;
							if (this.IsTrialRole(num2))
							{
								num2 = getRoleData2.GetTrialRoleConfig.Value.ParentId;
							}
							if (num == num2)
							{
								return true;
							}
						}
					}
				}
			}
			return false;
		}
	}

	// Token: 0x17001035 RID: 4149
	// (get) Token: 0x0600C94D RID: 51533 RVA: 0x0035555C File Offset: 0x0035375C
	public bool HasSpecialTrialRole
	{
		get
		{
			foreach (EditBattleRoleSlotData editBattleRoleSlotData in this.GetAllRoleSlotData)
			{
				if (editBattleRoleSlotData.HasRole && editBattleRoleSlotData.GetRoleData.IsSelf && RoleUtils.IsSpecialTrialRole(editBattleRoleSlotData.GetRoleData.ConfigId))
				{
					return true;
				}
			}
			return false;
		}
	}

	// Token: 0x0600C94E RID: 51534 RVA: 0x003555AC File Offset: 0x003537AC
	public bool IsRoleConflict(int playerId, int roleId)
	{
		foreach (KeyValuePair<int, EditBattleRoleSlotData> keyValuePair in this.RoleSlotDataMap)
		{
			EditBattleRoleSlotData value = keyValuePair.Value;
			if (value != null)
			{
				EditBattleRoleData getRoleData = value.GetRoleData;
				if (getRoleData == null || getRoleData.PlayerId != playerId)
				{
					int? getRoleConfigId = value.GetRoleConfigId;
					if (getRoleConfigId.GetValueOrDefault() == roleId & getRoleConfigId != null)
					{
						return true;
					}
				}
			}
		}
		return false;
	}

	// Token: 0x17001036 RID: 4150
	// (get) Token: 0x0600C94F RID: 51535 RVA: 0x00355644 File Offset: 0x00353844
	public bool GetSelfIsReady
	{
		get
		{
			int valueOrDefault = ModelBase<PlayerInfoModel>.Instance.GetId().GetValueOrDefault();
			return ModelBase<InstanceDungeonModel>.Instance.GetPrewarPlayerReadyState(valueOrDefault);
		}
	}

	// Token: 0x0600C950 RID: 51536 RVA: 0x00355670 File Offset: 0x00353870
	public void RefreshAllMultiRoleData()
	{
		IReadOnlyList<PrewarFormationData> prewarFormationDataList = ModelBase<InstanceDungeonModel>.Instance.GetPrewarFormationDataList();
		int count = prewarFormationDataList.Count;
		for (int i = 0; i < 3; i++)
		{
			EditBattleRoleSlotData editBattleRoleSlotData = this.RoleSlotDataMap[i + 1];
			if (i + 1 > count)
			{
				editBattleRoleSlotData.ResetRoleData();
			}
			else
			{
				editBattleRoleSlotData.SetRoleDataByPrewarInfo(prewarFormationDataList[i]);
			}
		}
		Singleton<EventSystem>.Instance.Emit<ERefreshEditBattleRoleSlotDataReason>(EEventName.OnRefreshEditBattleRoleSlotData, ERefreshEditBattleRoleSlotDataReason.RefreshPrewarTeamOnline);
	}

	// Token: 0x0600C951 RID: 51537 RVA: 0x003556D8 File Offset: 0x003538D8
	public unsafe void InitAllMultiRoleData(PrewarFormationData[] prewarFormations)
	{
		this.ResetAllRoleSlotData();
		foreach (PrewarFormationData prewarFormationData in prewarFormations)
		{
			int index = prewarFormationData.GetIndex();
			EditBattleRoleSlotData roleSlotData = this.GetRoleSlotData(index);
			if (roleSlotData != null)
			{
				if (prewarFormationData.IsEmpty() && prewarFormationData.IsLeader())
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.Formation;
					ELogAuthor author = ELogAuthor.LYY;
					string message = "[EditBattleTeam]此位置没有角色:{Position}";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("{Position}", index);
					instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				}
				else if (!prewarFormationData.IsEmpty())
				{
					EditBattleRoleData roleData = this.CreateRoleDataFromPrewarData(prewarFormationData);
					roleSlotData.SetRoleData(roleData);
					Log instance2 = Singleton<Log>.Instance;
					ELogModule module2 = ELogModule.Formation;
					ELogAuthor author2 = ELogAuthor.LYY;
					string message2 = "[EditBattleTeam]当初始化所有联机战前编队数据时,玩家在线索引:OnlineIndex,玩家信息:PrewarFormation";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("OnlineIndex", prewarFormationData.GetOnlineNumber());
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("PrewarFormation", prewarFormationData);
					instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
					if (prewarFormationData.IsLeader())
					{
						int playerId = prewarFormationData.GetPlayerId();
						this.SetLeaderPlayerId(new int?(playerId));
					}
				}
			}
		}
		if (this.GetLeaderPlayerId == null)
		{
			int? id = ModelBase<PlayerInfoModel>.Instance.GetId();
			this.SetLeaderPlayerId(id);
		}
		Singleton<EventSystem>.Instance.Emit<ERefreshEditBattleRoleSlotDataReason>(EEventName.OnRefreshEditBattleRoleSlotData, ERefreshEditBattleRoleSlotDataReason.InitPrewarTeamOnline);
		this.PrintRoleSlotsDebugString();
	}

	// Token: 0x0600C952 RID: 51538 RVA: 0x00355840 File Offset: 0x00353A40
	public unsafe void InitAllSingleRoleData()
	{
		this.ResetAllRoleSlotData();
		int? id = ModelBase<PlayerInfoModel>.Instance.GetId();
		this.SetLeaderPlayerId(id);
		this.InitTrailRoleInstance();
		FightFormation? getCurrentFightFormation = this.GetCurrentFightFormation;
		int[] autoRoleArray = getCurrentFightFormation.Value.GetAutoRoleArray();
		if (getCurrentFightFormation.Value.AutoRoleLength > 0)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Formation;
			ELogAuthor author = ELogAuthor.LYY;
			string message = "[EditBattleTeam]当初始化所有单人战前编队数据时,此编队填写了自动上阵角色";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("autoRoleGroupIdList", autoRoleArray);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			int num = 1;
			Span<int> autoRoleBytes = getCurrentFightFormation.Value.GetAutoRoleBytes();
			for (int i = 0; i < autoRoleBytes.Length; i++)
			{
				int num2 = *autoRoleBytes[i];
				EditBattleRoleSlotData roleSlotData = this.GetRoleSlotData(num);
				if (roleSlotData != null)
				{
					if (!this.TrialRoleInstanceMap.ContainsKey(num2))
					{
						Log instance2 = Singleton<Log>.Instance;
						ELogModule module2 = ELogModule.Formation;
						ELogAuthor author2 = ELogAuthor.LYY;
						string message2 = "[EditBattleTeam]自动上阵角色配置的角色Id不在试用角色列表中";
						ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("autoRoleGroupConfigId", num2);
						instance2.Warn(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
					}
					else
					{
						RoleDataBase roleInstance = this.TrialRoleInstanceMap[num2];
						EditBattleRoleData roleData = this.CreateRoleDataFromRoleInstance(roleInstance);
						roleSlotData.SetRoleData(roleData);
						num++;
					}
				}
			}
			Singleton<EventSystem>.Instance.Emit<ERefreshEditBattleRoleSlotDataReason>(EEventName.OnRefreshEditBattleRoleSlotData, ERefreshEditBattleRoleSlotDataReason.AutoTempRole);
			this.PrintRoleSlotsDebugString();
			return;
		}
		if (this.HasAnyLimit())
		{
			Singleton<Log>.Instance.Info(ELogModule.Formation, ELogAuthor.LYY, "[EditBattleTeam]单人战前编队存在编队限制,将不会读取编队数据初始化", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		int[] array = null;
		DangoAbyssModel instance3 = ModelBase<DangoAbyssModel>.Instance;
		if (instance3 != null && instance3.GetInAbyssFlow())
		{
			int[] array2 = new int[0];
			if (ModelBase<DangoAbyssModel>.Instance.GetFormationSelectRoleList(ModelBase<DangoAbyssModel>.Instance.CurrentSelectChallengeId).Length != 0)
			{
				array2 = ModelBase<DangoAbyssModel>.Instance.GetFormationSelectRoleList(ModelBase<DangoAbyssModel>.Instance.CurrentSelectChallengeId);
			}
			else if (ModelBase<DangoAbyssModel>.Instance.GetFormationSelectRoleList(ModelBase<DangoAbyssModel>.Instance.CurrentSelectChallengeId - 1).Length != 0)
			{
				array2 = ModelBase<DangoAbyssModel>.Instance.GetFormationSelectRoleList(ModelBase<DangoAbyssModel>.Instance.CurrentSelectChallengeId - 1);
			}
			RoleDataBase[] roleList = this.GetRoleList();
			List<int> list = new List<int>();
			foreach (int num3 in array2)
			{
				bool flag = false;
				if (roleList != null)
				{
					RoleDataBase[] array4 = roleList;
					for (int j = 0; j < array4.Length; j++)
					{
						if (array4[j].GetDataId() == num3)
						{
							flag = true;
							break;
						}
					}
				}
				if (flag)
				{
					list.Add(num3);
				}
			}
			array = list.ToArray();
		}
		if (ModelBase<TowerModel>.Instance.IsOpenFloorFormation())
		{
			List<int> floorFormation = ModelBase<TowerModel>.Instance.GetFloorFormation(ModelBase<TowerModel>.Instance.CurrentSelectFloor);
			List<int> list2;
			if (ModelBase<TowerModel>.Instance.CheckInTower())
			{
				list2 = ((floorFormation != null && floorFormation.Count > 0) ? floorFormation : ModelBase<TowerModel>.Instance.CurrentTowerFormation);
			}
			else
			{
				list2 = floorFormation;
			}
			ControllerBase<EditBattleTeamController>.Instance.ResetSlotDataThenSetEditBattleTeamByRoleId(list2.ToArray());
		}
		else
		{
			DangoAbyssModel instance4 = ModelBase<DangoAbyssModel>.Instance;
			if (instance4 != null && instance4.GetInAbyssFlow() && array != null && array != null && array.Length != 0)
			{
				ControllerBase<EditBattleTeamController>.Instance.SetEditBattleTeamByRoleId(array);
			}
			else
			{
				int num4 = 1;
				string accountName = ModelBase<PlayerInfoModel>.Instance.GetAccountName(true);
				int value = 1;
				bool isSelf = true;
				RoleModel instance5 = ModelBase<RoleModel>.Instance;
				foreach (EditFormationRoleData editFormationRoleData in ModelBase<EditFormationModel>.Instance.GetCurrentFormationData.GetRoleDataMap().Values)
				{
					int configId = editFormationRoleData.ConfigId;
					int roleSkinId = editFormationRoleData.RoleSkinId;
					if (configId > 0)
					{
						int? num5 = id;
						int i = editFormationRoleData.PlayerId;
						if (num5.GetValueOrDefault() == i & num5 != null)
						{
							Log instance6 = Singleton<Log>.Instance;
							ELogModule module3 = ELogModule.Formation;
							ELogAuthor author3 = ELogAuthor.LYY;
							string message3 = "[EditBattleTeam]当初始化所有单人战前编队数据时,编队位置:{Position},角色Id:{ConfigId},玩家Id:{PlayerId}";
							<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
							*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("{Position}", num4);
							*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("{ConfigId}", configId);
							*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("{PlayerId}", editFormationRoleData.PlayerId);
							instance6.Info(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
							int maxLimitRoleCount = this.GetMaxLimitRoleCount();
							if (maxLimitRoleCount <= 0 || num4 <= maxLimitRoleCount)
							{
								EditBattleRoleSlotData roleSlotData2 = this.GetRoleSlotData(num4);
								if (this.CanAddRoleToEditTeam(configId))
								{
									EditBattleRoleData editBattleRoleData = new EditBattleRoleData();
									RoleDataBase roleDataById = instance5.GetRoleDataById(configId, true);
									int level = (roleDataById != null) ? roleDataById.GetLevelData().GetLevel() : 0;
									editBattleRoleData.Init(id.Value, configId, roleSkinId, new int?(value), accountName, level, isSelf, true);
									roleSlotData2.SetRoleData(editBattleRoleData);
									num4++;
								}
							}
						}
					}
				}
			}
		}
		Singleton<EventSystem>.Instance.Emit<ERefreshEditBattleRoleSlotDataReason>(EEventName.OnRefreshEditBattleRoleSlotData, ERefreshEditBattleRoleSlotDataReason.InitPrewarTeamOffline);
		this.PrintRoleSlotsDebugString();
	}

	// Token: 0x0600C953 RID: 51539 RVA: 0x00355D0C File Offset: 0x00353F0C
	public EditBattleRoleData CreateRoleDataFromPrewarData(PrewarFormationData data)
	{
		int configId = data.GetConfigId();
		int skinId = data.GetSkinId();
		int onlineNumber = data.GetOnlineNumber();
		string playerName = data.GetPlayerName();
		int playerId = data.GetPlayerId();
		int level = data.GetLevel();
		bool isSelf = data.IsSelf();
		bool isReady = data.GetIsReady();
		EditBattleRoleData editBattleRoleData = new EditBattleRoleData();
		editBattleRoleData.Init(playerId, configId, skinId, new int?(onlineNumber), playerName, level, isSelf, isReady);
		editBattleRoleData.ThirdPartyOnlineId = data.GetPlayerOnlineId();
		return editBattleRoleData;
	}

	// Token: 0x0600C954 RID: 51540 RVA: 0x00355D80 File Offset: 0x00353F80
	public EditBattleRoleData CreateRoleDataFromRoleInstance(RoleDataBase roleInstance)
	{
		int dataId = roleInstance.GetDataId();
		RoleLevelData levelData = roleInstance.GetLevelData();
		int roleSkinId = roleInstance.GetRoleSkinId();
		int value = 1;
		int? id = ModelBase<PlayerInfoModel>.Instance.GetId();
		string accountName = ModelBase<PlayerInfoModel>.Instance.GetAccountName(true);
		int level = levelData.GetLevel();
		bool isSelf = true;
		bool getSelfIsReady = this.GetSelfIsReady;
		EditBattleRoleData editBattleRoleData = new EditBattleRoleData();
		editBattleRoleData.Init(id.Value, dataId, roleSkinId, new int?(value), accountName, level, isSelf, getSelfIsReady);
		return editBattleRoleData;
	}

	// Token: 0x0600C955 RID: 51541 RVA: 0x00355DEF File Offset: 0x00353FEF
	public bool IsTrialRole(int configId)
	{
		return configId > 100000;
	}

	// Token: 0x0600C956 RID: 51542 RVA: 0x00355DFC File Offset: 0x00353FFC
	public void ChangeMainRoleData()
	{
		if (ModelBase<GameModeModel>.Instance.IsMulti)
		{
			return;
		}
		RoleModel instance = ModelBase<RoleModel>.Instance;
		foreach (EditBattleRoleSlotData editBattleRoleSlotData in this.RoleSlotDataMap.Values)
		{
			EditBattleRoleData getRoleData = editBattleRoleSlotData.GetRoleData;
			int? num = (getRoleData != null) ? new int?(getRoleData.ConfigId) : null;
			if (num != null && !this.IsTrialRole(num.Value) && instance.IsMainRole(num.Value))
			{
				int? newMainRoleId = instance.GetNewMainRoleId(num.Value);
				if (newMainRoleId != null)
				{
					int? num2 = num;
					int? num3 = newMainRoleId;
					if (!(num2.GetValueOrDefault() == num3.GetValueOrDefault() & num2 != null == (num3 != null)))
					{
						getRoleData.ConfigId = newMainRoleId.Value;
					}
				}
			}
		}
		Singleton<EventSystem>.Instance.Emit<ERefreshEditBattleRoleSlotDataReason>(EEventName.OnRefreshEditBattleRoleSlotData, ERefreshEditBattleRoleSlotDataReason.ChangeMainRoleOffline);
	}

	// Token: 0x04006066 RID: 24678
	private const int LIMIT_COUNT_MAX_LENGTH = 3;

	// Token: 0x04006067 RID: 24679
	private readonly Dictionary<int, EditBattleRoleSlotData> RoleSlotDataMap = new Dictionary<int, EditBattleRoleSlotData>();

	// Token: 0x04006068 RID: 24680
	private int? CurrentEditPosition;

	// Token: 0x04006069 RID: 24681
	private int? InstanceDungeonId;

	// Token: 0x0400606A RID: 24682
	private int? LeaderPlayerId;

	// Token: 0x0400606B RID: 24683
	private readonly Dictionary<int, RoleDataBase> TrialRoleInstanceMap = new Dictionary<int, RoleDataBase>();

	// Token: 0x0400606C RID: 24684
	[Nullable(2)]
	private int[] CurrentGenderRoleList;

	// Token: 0x0400606D RID: 24685
	private bool IsNeedEntrance = true;

	// Token: 0x0400606E RID: 24686
	private bool CanUseSpecialTrialRoleIntl;

	// Token: 0x0400606F RID: 24687
	public bool IsFormTeleportAction;

	// Token: 0x04006070 RID: 24688
	[Nullable(2)]
	public FastReturnDungeonContext FastReturnDungeonContext;

	// Token: 0x04006071 RID: 24689
	private bool InstanceMultiEnterInternal;
}
