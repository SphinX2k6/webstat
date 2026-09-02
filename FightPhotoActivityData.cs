using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;

// Token: 0x0200131C RID: 4892
[NullableContext(1)]
[Nullable(0)]
public class FightPhotoActivityData : ActivityBaseData
{
	// Token: 0x06008539 RID: 34105 RVA: 0x002315FC File Offset: 0x0022F7FC
	private unsafe void InitLevelGroupData()
	{
		IReadOnlyList<PhotoFightActivityGroup> configList = ConfigPhotoFightActivityGroupByActivityId.GetConfigList(base.Id, true);
		if (configList == null)
		{
			return;
		}
		foreach (PhotoFightActivityGroup config in configList)
		{
			FightPhotoLevelGroupData fightPhotoLevelGroupData = new FightPhotoLevelGroupData(config);
			this.LevelGroupDataMap[config.Id] = fightPhotoLevelGroupData;
			this.LevelGroupDataList.Add(fightPhotoLevelGroupData);
			Span<int> levelIdList = fightPhotoLevelGroupData.LevelIdList;
			for (int i = 0; i < levelIdList.Length; i++)
			{
				int num = *levelIdList[i];
				PhotoFightActivity? config2 = ConfigPhotoFightActivityById.GetConfig(num, true);
				if (config2 == null)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.FightPhotograph;
					ELogAuthor author = ELogAuthor.CXJ;
					string message = "战斗拍照关卡配置不存在";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("levelId", num);
					instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				}
				else
				{
					FightPhotoLevelData fightPhotoLevelData = new FightPhotoLevelData(config2.Value);
					fightPhotoLevelData.LevelGroupData = fightPhotoLevelGroupData;
					this.LevelDataMap[num] = fightPhotoLevelData;
					fightPhotoLevelGroupData.PushFightPhotoLevel(fightPhotoLevelData);
				}
			}
		}
		this.LevelGroupDataList.Sort((FightPhotoLevelGroupData a, FightPhotoLevelGroupData b) => a.SortId - b.SortId);
	}

	// Token: 0x0600853A RID: 34106 RVA: 0x0023174C File Offset: 0x0022F94C
	[NullableContext(2)]
	private FightPhotoLevelGroupData GetLevelGroupData(int levelGroupId)
	{
		FightPhotoLevelGroupData result;
		if (!this.LevelGroupDataMap.TryGetValue(levelGroupId, out result))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.FightPhotograph;
			ELogAuthor author = ELogAuthor.CXJ;
			string message = "战斗拍照关卡组配置不存在";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("levelGroupId", levelGroupId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return result;
	}

	// Token: 0x0600853B RID: 34107 RVA: 0x0023179C File Offset: 0x0022F99C
	[NullableContext(2)]
	public FightPhotoLevelData GetLevelData(int levelId)
	{
		FightPhotoLevelData result;
		if (!this.LevelDataMap.TryGetValue(levelId, out result))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.FightPhotograph;
			ELogAuthor author = ELogAuthor.CXJ;
			string message = "战斗拍照关卡配置不存在";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("levelId", levelId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return result;
	}

	// Token: 0x0600853C RID: 34108 RVA: 0x002317EC File Offset: 0x0022F9EC
	[NullableContext(2)]
	public FightPhotoLevelData GetLevelDataById(int levelId)
	{
		FightPhotoLevelData result;
		this.LevelDataMap.TryGetValue(levelId, out result);
		return result;
	}

	// Token: 0x0600853D RID: 34109 RVA: 0x0023180C File Offset: 0x0022FA0C
	[NullableContext(2)]
	public FightPhotoLevelData GetNextLevelData(int currentLevelId)
	{
		FightPhotoLevelData currentLevelData;
		if (!this.LevelDataMap.TryGetValue(currentLevelId, out currentLevelData))
		{
			return null;
		}
		List<FightPhotoLevelData> levelDataList = currentLevelData.LevelGroupData.LevelDataList;
		int num = levelDataList.FindIndex((FightPhotoLevelData d) => d.LevelId == currentLevelId);
		if (num >= 0 && num + 1 < levelDataList.Count)
		{
			return levelDataList[num + 1];
		}
		int num2 = this.LevelGroupDataList.FindIndex((FightPhotoLevelGroupData g) => g.Id == currentLevelData.LevelGroupData.Id);
		if (num2 < 0 || num2 + 1 >= this.LevelGroupDataList.Count)
		{
			return null;
		}
		List<FightPhotoLevelData> levelDataList2 = this.LevelGroupDataList[num2 + 1].LevelDataList;
		if (levelDataList2.Count <= 0)
		{
			return null;
		}
		return levelDataList2[0];
	}

	// Token: 0x0600853E RID: 34110 RVA: 0x002318D8 File Offset: 0x0022FAD8
	public void UpdateLevelGroupData(IReadOnlyList<PhotoFightLevelGroupPb> levelGroupInfoList)
	{
		foreach (PhotoFightLevelGroupPb photoFightLevelGroupPb in levelGroupInfoList)
		{
			FightPhotoLevelGroupData levelGroupData = this.GetLevelGroupData(photoFightLevelGroupPb.GroupId);
			if (levelGroupData != null)
			{
				levelGroupData.UnlockTime = Singleton<MathUtils>.Instance.LongToNumber(photoFightLevelGroupPb.OpenTime);
				this.UpdateLevelData(photoFightLevelGroupPb.PhotoFightLevelInfo, true);
			}
		}
	}

	// Token: 0x0600853F RID: 34111 RVA: 0x0023194C File Offset: 0x0022FB4C
	public void UpdateLevelData(IReadOnlyList<PhotoFightLevelPb> levelInfoList, bool isInit = true)
	{
		foreach (PhotoFightLevelPb photoFightLevelPb in levelInfoList)
		{
			FightPhotoLevelData levelData = this.GetLevelData(photoFightLevelPb.LevelId);
			if (levelData != null)
			{
				if (!isInit && levelData.IsDifficulty && !levelData.IsUnLock && photoFightLevelPb.IsOpen)
				{
					this.IsNeedShowTip = true;
				}
				levelData.IsUnLock = photoFightLevelPb.IsOpen;
				levelData.IsFinished = (photoFightLevelPb.ClearTimes > 0);
				levelData.SetRoleIdList(photoFightLevelPb.Roles.ToList<int>());
			}
		}
	}

	// Token: 0x06008540 RID: 34112 RVA: 0x002319EC File Offset: 0x0022FBEC
	public int GetSelectLevelGroupDataIndex()
	{
		FightPhotoLevelData currentLevel = this.GetCurrentLevelData(false);
		if (currentLevel != null)
		{
			return this.LevelGroupDataList.FindIndex((FightPhotoLevelGroupData data) => data.Id == currentLevel.LevelGroupData.Id);
		}
		return this.GetFirstUnFinishedLevelGroupDataIndex();
	}

	// Token: 0x06008541 RID: 34113 RVA: 0x00231A34 File Offset: 0x0022FC34
	public int GetFirstUnFinishedLevelGroupDataIndex()
	{
		int count = this.LevelGroupDataList.Count;
		int num = -1;
		for (int i = 0; i < count; i++)
		{
			FightPhotoLevelGroupData fightPhotoLevelGroupData = this.LevelGroupDataList[i];
			if (fightPhotoLevelGroupData.IsUnLock && !fightPhotoLevelGroupData.IsFinished)
			{
				return i;
			}
			if (num == -1 && !fightPhotoLevelGroupData.IsUnLock)
			{
				num = i;
			}
		}
		if (num != -1)
		{
			return num - 1;
		}
		return count - 1;
	}

	// Token: 0x06008542 RID: 34114 RVA: 0x00231A94 File Offset: 0x0022FC94
	public bool IsLevelHasRedDot()
	{
		using (Dictionary<int, FightPhotoLevelData>.ValueCollection.Enumerator enumerator = this.LevelDataMap.Values.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.HasRedDot)
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x06008543 RID: 34115 RVA: 0x00231AF4 File Offset: 0x0022FCF4
	public List<FightPhotoLevelGroupData> GetLevelGroupDataList()
	{
		return this.LevelGroupDataList;
	}

	// Token: 0x06008544 RID: 34116 RVA: 0x00231AFC File Offset: 0x0022FCFC
	public int GetTotalLevelNum()
	{
		return this.LevelGroupDataMap.Count;
	}

	// Token: 0x06008545 RID: 34117 RVA: 0x00231B0C File Offset: 0x0022FD0C
	public int GetFinishedLevelNum()
	{
		int num = 0;
		using (Dictionary<int, FightPhotoLevelGroupData>.ValueCollection.Enumerator enumerator = this.LevelGroupDataMap.Values.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.IsFinished)
				{
					num++;
				}
			}
		}
		return num;
	}

	// Token: 0x06008546 RID: 34118 RVA: 0x00231B6C File Offset: 0x0022FD6C
	private void InitTaskData()
	{
		IReadOnlyList<PhotoFightReward> configList = ConfigPhotoFightRewardByActivityId.GetConfigList(base.Id, true);
		if (configList == null)
		{
			return;
		}
		foreach (PhotoFightReward config in configList)
		{
			FightPhotoTaskData fightPhotoTaskData = new FightPhotoTaskData(config);
			this.TaskDataMap[config.Id] = fightPhotoTaskData;
			List<FightPhotoTaskData> list;
			if (!this.TabToTaskDataListMap.TryGetValue(fightPhotoTaskData.TabType, out list))
			{
				list = new List<FightPhotoTaskData>();
				this.TabToTaskDataListMap[fightPhotoTaskData.TabType] = list;
			}
			list.Add(fightPhotoTaskData);
		}
	}

	// Token: 0x06008547 RID: 34119 RVA: 0x00231C10 File Offset: 0x0022FE10
	[NullableContext(2)]
	private FightPhotoTaskData GetFightPhotoTaskData(int taskId)
	{
		FightPhotoTaskData result;
		if (!this.TaskDataMap.TryGetValue(taskId, out result))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.FightPhotograph;
			ELogAuthor author = ELogAuthor.CXJ;
			string message = "战斗拍照任务配置不存在";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("taskId", taskId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return result;
	}

	// Token: 0x06008548 RID: 34120 RVA: 0x00231C60 File Offset: 0x0022FE60
	public void UpdateTaskData(IReadOnlyList<PhotoFightTargetPb> targetInfoList)
	{
		foreach (PhotoFightTargetPb photoFightTargetPb in targetInfoList)
		{
			FightPhotoTaskData fightPhotoTaskData = this.GetFightPhotoTaskData(photoFightTargetPb.Id);
			if (fightPhotoTaskData != null)
			{
				fightPhotoTaskData.Status = TaskStateResolver.TaskState[photoFightTargetPb.Status];
			}
		}
	}

	// Token: 0x06008549 RID: 34121 RVA: 0x00231CC8 File Offset: 0x0022FEC8
	public void RequestTaskReward(int tabId)
	{
		List<FightPhotoTaskData> taskDataList = this.GetTaskDataList(tabId);
		List<int> list = new List<int>();
		foreach (FightPhotoTaskData fightPhotoTaskData in taskDataList)
		{
			if (fightPhotoTaskData.IsUnclaimed)
			{
				list.Add(fightPhotoTaskData.Id);
			}
		}
		ControllerBase<FightPhotoController>.Instance.RequestTaskReward(list.ToArray());
	}

	// Token: 0x0600854A RID: 34122 RVA: 0x00231D40 File Offset: 0x0022FF40
	public void UpdateTaskRewardStatus(IReadOnlyList<PhotoFightTargetPb> taskInfoList)
	{
		foreach (PhotoFightTargetPb photoFightTargetPb in taskInfoList)
		{
			FightPhotoTaskData fightPhotoTaskData = this.GetFightPhotoTaskData(photoFightTargetPb.Id);
			if (fightPhotoTaskData != null)
			{
				fightPhotoTaskData.Status = TaskStateResolver.TaskState[photoFightTargetPb.Status];
			}
		}
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, base.Id);
	}

	// Token: 0x0600854B RID: 34123 RVA: 0x00231DC0 File Offset: 0x0022FFC0
	public bool IsTaskHasRedDot()
	{
		using (Dictionary<int, FightPhotoTaskData>.ValueCollection.Enumerator enumerator = this.TaskDataMap.Values.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.IsUnclaimed)
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x0600854C RID: 34124 RVA: 0x00231E20 File Offset: 0x00230020
	public bool IsTaskHasRedDotByTab(int tabId)
	{
		List<FightPhotoTaskData> list;
		if (!this.TabToTaskDataListMap.TryGetValue(tabId, out list))
		{
			list = new List<FightPhotoTaskData>();
		}
		using (List<FightPhotoTaskData>.Enumerator enumerator = list.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.IsUnclaimed)
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x0600854D RID: 34125 RVA: 0x00231E8C File Offset: 0x0023008C
	public List<FightPhotoTaskData> GetTaskDataList(int tabId)
	{
		List<FightPhotoTaskData> list;
		if (!this.TabToTaskDataListMap.TryGetValue(tabId, out list))
		{
			list = new List<FightPhotoTaskData>();
		}
		list.Sort(new Comparison<FightPhotoTaskData>(this.SortTaskData));
		return list;
	}

	// Token: 0x0600854E RID: 34126 RVA: 0x00231EC2 File Offset: 0x002300C2
	private int SortTaskData(FightPhotoTaskData a, FightPhotoTaskData b)
	{
		if (a.Status != b.Status)
		{
			return a.Status - b.Status;
		}
		return a.Id - b.Id;
	}

	// Token: 0x0600854F RID: 34127 RVA: 0x00231EED File Offset: 0x002300ED
	public int GetTotalTaskNum()
	{
		return this.TaskDataMap.Count;
	}

	// Token: 0x06008550 RID: 34128 RVA: 0x00231EFC File Offset: 0x002300FC
	public int GetFinishedTaskNum()
	{
		int num = 0;
		using (Dictionary<int, FightPhotoTaskData>.ValueCollection.Enumerator enumerator = this.TaskDataMap.Values.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.IsFinished)
				{
					num++;
				}
			}
		}
		return num;
	}

	// Token: 0x06008551 RID: 34129 RVA: 0x00231F5C File Offset: 0x0023015C
	public List<PhotoFightRewardTab> GetFightPhotoTaskTabList()
	{
		if (this.FightPhotoTaskTabList.Count == 0)
		{
			IReadOnlyList<PhotoFightRewardTab> configList = ConfigPhotoFightRewardTabByActivityId.GetConfigList(base.Id, true);
			if (configList != null)
			{
				this.FightPhotoTaskTabList = new List<PhotoFightRewardTab>(configList);
			}
		}
		return this.FightPhotoTaskTabList;
	}

	// Token: 0x06008552 RID: 34130 RVA: 0x00231F98 File Offset: 0x00230198
	[NullableContext(2)]
	public FightPhotoLevelData GetCurrentLevelData(bool isNeedLog = true)
	{
		if (this.CurrentLevelId != 0)
		{
			return this.GetLevelData(this.CurrentLevelId);
		}
		if (ControllerBase<FightPhotoController>.Instance.CheckInFightPhotoDungeon())
		{
			PhotoFightActivity? config = ConfigPhotoFightActivityByInstId.GetConfig(ModelBase<CreatureModel>.Instance.GetInstanceId(), true);
			if (config != null)
			{
				this.CurrentLevelId = config.Value.Id;
			}
		}
		if (this.CurrentLevelId == 0)
		{
			if (isNeedLog)
			{
				Singleton<Log>.Instance.Error(ELogModule.FightPhotograph, ELogAuthor.CXJ, "当前不存在正在进行的战斗拍照关卡", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			return null;
		}
		return this.GetLevelData(this.CurrentLevelId);
	}

	// Token: 0x06008553 RID: 34131 RVA: 0x0023202D File Offset: 0x0023022D
	public int GetCurrentLevelId()
	{
		return this.CurrentLevelId;
	}

	// Token: 0x06008554 RID: 34132 RVA: 0x00232035 File Offset: 0x00230235
	public void SetCurrentLevelId(int id)
	{
		this.CurrentLevelId = id;
	}

	// Token: 0x17000B43 RID: 2883
	// (get) Token: 0x06008555 RID: 34133 RVA: 0x0023203E File Offset: 0x0023023E
	// (set) Token: 0x06008556 RID: 34134 RVA: 0x00232046 File Offset: 0x00230246
	public bool IsNeedShowFightPhotoMainView
	{
		get
		{
			return this.NeedShowFightPhotoMainView;
		}
		set
		{
			this.NeedShowFightPhotoMainView = value;
		}
	}

	// Token: 0x06008557 RID: 34135 RVA: 0x00232050 File Offset: 0x00230250
	protected override void OnInit(ActivityData data)
	{
		PhotoFightActivityPb photoFightActivityData = data.PhotoFightActivityData;
		if (photoFightActivityData == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.FightPhotograph, ELogAuthor.CXJ, "PhotoFightActivityData未初始化 无效activityInfo", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		this.InitLevelGroupData();
		this.InitTaskData();
		this.UpdateLevelGroupData(photoFightActivityData.PhotoFightLevelGroupInfo);
		this.UpdateTaskData(photoFightActivityData.Targets);
	}

	// Token: 0x06008558 RID: 34136 RVA: 0x002320AB File Offset: 0x002302AB
	public override bool GetExDataRedPointShowState()
	{
		return this.CheckRedDot();
	}

	// Token: 0x06008559 RID: 34137 RVA: 0x002320B3 File Offset: 0x002302B3
	public bool CheckRedDot()
	{
		return base.IsUnLock() && base.GetPreGuideQuestFinishState() && (this.IsTaskHasRedDot() || this.IsLevelHasRedDot());
	}

	// Token: 0x0600855A RID: 34138 RVA: 0x002320DC File Offset: 0x002302DC
	protected override bool GetExDataFinishShowState()
	{
		using (List<FightPhotoLevelGroupData>.Enumerator enumerator = this.LevelGroupDataList.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (!enumerator.Current.IsFinished)
				{
					return false;
				}
			}
		}
		using (Dictionary<int, FightPhotoTaskData>.ValueCollection.Enumerator enumerator2 = this.TaskDataMap.Values.GetEnumerator())
		{
			while (enumerator2.MoveNext())
			{
				if (!enumerator2.Current.IsFinished)
				{
					return false;
				}
			}
		}
		return true;
	}

	// Token: 0x04003F19 RID: 16153
	private readonly Dictionary<int, FightPhotoLevelGroupData> LevelGroupDataMap = new Dictionary<int, FightPhotoLevelGroupData>();

	// Token: 0x04003F1A RID: 16154
	private readonly Dictionary<int, FightPhotoLevelData> LevelDataMap = new Dictionary<int, FightPhotoLevelData>();

	// Token: 0x04003F1B RID: 16155
	private readonly List<FightPhotoLevelGroupData> LevelGroupDataList = new List<FightPhotoLevelGroupData>();

	// Token: 0x04003F1C RID: 16156
	public bool IsNeedShowTip;

	// Token: 0x04003F1D RID: 16157
	private readonly Dictionary<int, FightPhotoTaskData> TaskDataMap = new Dictionary<int, FightPhotoTaskData>();

	// Token: 0x04003F1E RID: 16158
	private readonly Dictionary<int, List<FightPhotoTaskData>> TabToTaskDataListMap = new Dictionary<int, List<FightPhotoTaskData>>();

	// Token: 0x04003F1F RID: 16159
	private List<PhotoFightRewardTab> FightPhotoTaskTabList = new List<PhotoFightRewardTab>();

	// Token: 0x04003F20 RID: 16160
	private int CurrentLevelId;

	// Token: 0x04003F21 RID: 16161
	private bool NeedShowFightPhotoMainView;
}
