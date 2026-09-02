using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Inventory;
using Google.Protobuf.Collections;

// Token: 0x02001453 RID: 5203
[NullableContext(1)]
[Nullable(0)]
public class ActivityNewcomerJourneyData : ActivityBaseData
{
	// Token: 0x060090FE RID: 37118 RVA: 0x00262108 File Offset: 0x00260308
	protected override void PhraseEx(ActivityData data)
	{
		if (data.NewbieAdventureV2Pb == null)
		{
			return;
		}
		this.ChapterDataMap.Clear();
		foreach (NewbieAdventureV2ChapterPb newbieAdventureV2ChapterPb in data.NewbieAdventureV2Pb.Chapter)
		{
			NewcomerJourneyChapterData newcomerJourneyChapterData = new NewcomerJourneyChapterData(newbieAdventureV2ChapterPb.Id);
			List<NewcomerJourneyTaskData> list = new List<NewcomerJourneyTaskData>();
			newcomerJourneyChapterData.TaskDataList = list;
			newcomerJourneyChapterData.ChapterId = newbieAdventureV2ChapterPb.Id;
			newcomerJourneyChapterData.Data = newbieAdventureV2ChapterPb;
			this.ChapterDataMap[newbieAdventureV2ChapterPb.Id] = newcomerJourneyChapterData;
			Dictionary<int, NewcomerJourneyTaskData> dictionary = new Dictionary<int, NewcomerJourneyTaskData>();
			foreach (ConditionTask conditionTask in newbieAdventureV2ChapterPb.Task)
			{
				NewcomerJourneyTaskData newcomerJourneyTaskData = new NewcomerJourneyTaskData(conditionTask.Id);
				newcomerJourneyTaskData.Config = ConfigBase<ActivityNewcomerJourneyConfig>.Instance.GetTaskById(conditionTask.Id);
				newcomerJourneyTaskData.TaskData = conditionTask;
				newcomerJourneyTaskData.ChapterId = newbieAdventureV2ChapterPb.Id;
				list.Add(newcomerJourneyTaskData);
				dictionary[conditionTask.Id] = newcomerJourneyTaskData;
			}
			newcomerJourneyChapterData.TaskDataMap = dictionary;
			AdventureTaskChapterV2? chapterById = ConfigBase<ActivityNewcomerJourneyConfig>.Instance.GetChapterById(newbieAdventureV2ChapterPb.Id);
			if (chapterById != null && chapterById.Value.RolesLength > 0)
			{
				this.ChooseRoleChapterId = chapterById.Value.Id;
			}
		}
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, base.Id);
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.ActivityViewRefreshCurrent, base.Id);
	}

	// Token: 0x060090FF RID: 37119 RVA: 0x002622D4 File Offset: 0x002604D4
	public override bool GetExDataRedPointShowState()
	{
		foreach (int chapterId in this.ChapterDataMap.Keys)
		{
			if (this.GetChapterHasReward(chapterId))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06009100 RID: 37120 RVA: 0x00262338 File Offset: 0x00260538
	public void UpdateChapterData(List<NewbieAdventureV2ChapterPb> dataList)
	{
		foreach (NewbieAdventureV2ChapterPb newbieAdventureV2ChapterPb in dataList)
		{
			NewcomerJourneyChapterData newcomerJourneyChapterData;
			if (this.ChapterDataMap.TryGetValue(newbieAdventureV2ChapterPb.Id, out newcomerJourneyChapterData) && newcomerJourneyChapterData.TaskDataMap != null)
			{
				Dictionary<int, NewcomerJourneyTaskData> taskDataMap = newcomerJourneyChapterData.TaskDataMap;
				RepeatedField<ConditionTask> task = newbieAdventureV2ChapterPb.Task;
				if (task != null)
				{
					foreach (ConditionTask conditionTask in task)
					{
						NewcomerJourneyTaskData newcomerJourneyTaskData;
						if (taskDataMap.TryGetValue(conditionTask.Id, out newcomerJourneyTaskData))
						{
							newcomerJourneyTaskData.TaskData = conditionTask;
						}
					}
				}
			}
		}
	}

	// Token: 0x06009101 RID: 37121 RVA: 0x00262404 File Offset: 0x00260604
	public List<int> GetPreviewCharacterList()
	{
		if (this.PreviewCharacterList == null || this.PreviewCharacterList.Count <= 0)
		{
			this.PreviewCharacterList = new List<int>();
			AdventureTaskChapterV2? chapterById = ConfigBase<ActivityNewcomerJourneyConfig>.Instance.GetChapterById(this.ChooseRoleChapterId);
			if (chapterById != null && chapterById.Value.RolesLength > 0)
			{
				foreach (int id in chapterById.Value.GetRolesArray())
				{
					AdventureRole? roleById = ConfigBase<ActivityNewcomerJourneyConfig>.Instance.GetRoleById(id);
					this.PreviewCharacterList.Add(roleById.Value.TrialRoleId);
				}
			}
		}
		return this.PreviewCharacterList;
	}

	// Token: 0x06009102 RID: 37122 RVA: 0x002624B4 File Offset: 0x002606B4
	public bool GetCanGetCharacter()
	{
		NewcomerJourneyChapterData newcomerJourneyChapterData;
		if (!this.ChapterDataMap.TryGetValue(this.ChooseRoleChapterId, out newcomerJourneyChapterData))
		{
			return false;
		}
		int chapterCompleteNum = this.GetChapterCompleteNum(this.ChooseRoleChapterId);
		AdventureTaskChapterV2? chapterById = ConfigBase<ActivityNewcomerJourneyConfig>.Instance.GetChapterById(this.ChooseRoleChapterId);
		return chapterById != null && chapterById.Value.RewardUnlockCount <= chapterCompleteNum && !newcomerJourneyChapterData.Data.RewardRoleId;
	}

	// Token: 0x06009103 RID: 37123 RVA: 0x00262524 File Offset: 0x00260724
	public bool GetCharacterHasGet()
	{
		NewcomerJourneyChapterData newcomerJourneyChapterData;
		return this.ChapterDataMap.TryGetValue(this.ChooseRoleChapterId, out newcomerJourneyChapterData) && newcomerJourneyChapterData.Data.RewardRoleId;
	}

	// Token: 0x06009104 RID: 37124 RVA: 0x00262554 File Offset: 0x00260754
	public bool GetChapterCanGetReward(int chapterId)
	{
		NewcomerJourneyChapterData newcomerJourneyChapterData;
		if (!this.ChapterDataMap.TryGetValue(chapterId, out newcomerJourneyChapterData))
		{
			return false;
		}
		int chapterCompleteNum = this.GetChapterCompleteNum(chapterId);
		AdventureTaskChapterV2? chapterById = ConfigBase<ActivityNewcomerJourneyConfig>.Instance.GetChapterById(chapterId);
		return chapterById != null && chapterById.Value.RewardUnlockCount <= chapterCompleteNum && !newcomerJourneyChapterData.Data.RewardDrop && !this.GetChapterIsLock(chapterId);
	}

	// Token: 0x06009105 RID: 37125 RVA: 0x002625C4 File Offset: 0x002607C4
	public bool GetChapterRewardHasGet(int chapterId)
	{
		NewcomerJourneyChapterData newcomerJourneyChapterData;
		return this.ChapterDataMap.TryGetValue(chapterId, out newcomerJourneyChapterData) && newcomerJourneyChapterData.Data.RewardDrop;
	}

	// Token: 0x06009106 RID: 37126 RVA: 0x002625F0 File Offset: 0x002607F0
	public bool GetChapterHasReward(int chapterId)
	{
		NewcomerJourneyChapterData newcomerJourneyChapterData;
		if (!this.ChapterDataMap.TryGetValue(chapterId, out newcomerJourneyChapterData))
		{
			return false;
		}
		if (this.GetChapterIsLock(chapterId))
		{
			return false;
		}
		if (this.GetChapterCanGetReward(chapterId))
		{
			return true;
		}
		bool result = false;
		using (List<NewcomerJourneyTaskData>.Enumerator enumerator = this.GetChapterTaskList(chapterId).GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.TaskData.Status == ConditionTaskState.ConditionTaskFinish)
				{
					result = true;
					break;
				}
			}
		}
		return result;
	}

	// Token: 0x06009107 RID: 37127 RVA: 0x00262678 File Offset: 0x00260878
	public List<TItem> GetChapterRewardList(int chapterId)
	{
		NewcomerJourneyChapterData newcomerJourneyChapterData;
		if (!this.ChapterDataMap.TryGetValue(chapterId, out newcomerJourneyChapterData))
		{
			return new List<TItem>();
		}
		AdventureTaskChapterV2? chapterById = ConfigBase<ActivityNewcomerJourneyConfig>.Instance.GetChapterById(newcomerJourneyChapterData.Data.Id);
		Dictionary<int, int> dropShowInfo = ConfigBase<AdventureGuideConfig>.Instance.GetDropShowInfo(chapterById.Value.DropId);
		List<TItem> list = new List<TItem>();
		foreach (int num in dropShowInfo.Keys)
		{
			TItem item = new TItem(new InventoryDefine.GetItemData(num, 0), dropShowInfo[num]);
			list.Add(item);
		}
		return list;
	}

	// Token: 0x06009108 RID: 37128 RVA: 0x00262734 File Offset: 0x00260934
	public List<NewcomerJourneyTaskData> GetChapterTaskList(int chapterId)
	{
		NewcomerJourneyChapterData newcomerJourneyChapterData;
		if (!this.ChapterDataMap.TryGetValue(chapterId, out newcomerJourneyChapterData))
		{
			return new List<NewcomerJourneyTaskData>();
		}
		List<NewcomerJourneyTaskData> taskDataList = newcomerJourneyChapterData.TaskDataList;
		taskDataList.Sort(delegate(NewcomerJourneyTaskData a, NewcomerJourneyTaskData b)
		{
			int num = ActivityNewcomerJourneyData.<GetChapterTaskList>g__GetPriority|13_0(a.TaskData.Status);
			int num2 = ActivityNewcomerJourneyData.<GetChapterTaskList>g__GetPriority|13_0(b.TaskData.Status);
			if (num != num2)
			{
				return num - num2;
			}
			return a.TaskData.Id - b.TaskData.Id;
		});
		return taskDataList;
	}

	// Token: 0x06009109 RID: 37129 RVA: 0x00262784 File Offset: 0x00260984
	public List<AdventureTaskChapterV2> GetChapterList()
	{
		List<AdventureTaskChapterV2> list = new List<AdventureTaskChapterV2>();
		foreach (NewcomerJourneyChapterData newcomerJourneyChapterData in this.ChapterDataMap.Values)
		{
			list.Add(ConfigBase<ActivityNewcomerJourneyConfig>.Instance.GetChapterById(newcomerJourneyChapterData.Data.Id).Value);
		}
		list.Sort((AdventureTaskChapterV2 a, AdventureTaskChapterV2 b) => a.Sort - b.Sort);
		return list;
	}

	// Token: 0x0600910A RID: 37130 RVA: 0x00262824 File Offset: 0x00260A24
	public int GetChapterCompleteNum(int chapterId)
	{
		NewcomerJourneyChapterData newcomerJourneyChapterData;
		if (!this.ChapterDataMap.TryGetValue(chapterId, out newcomerJourneyChapterData) || newcomerJourneyChapterData.Data.Task == null)
		{
			return 0;
		}
		return newcomerJourneyChapterData.Data.Task.Count((ConditionTask task) => task.Status >= ConditionTaskState.ConditionTaskTaken);
	}

	// Token: 0x0600910B RID: 37131 RVA: 0x00262880 File Offset: 0x00260A80
	public bool GetChapterTaskAllComplete(int chapterId)
	{
		int chapterCompleteNum = this.GetChapterCompleteNum(chapterId);
		NewcomerJourneyChapterData newcomerJourneyChapterData;
		return this.ChapterDataMap.TryGetValue(chapterId, out newcomerJourneyChapterData) && newcomerJourneyChapterData.Data.Task.Count <= chapterCompleteNum && !this.GetChapterIsLock(chapterId);
	}

	// Token: 0x0600910C RID: 37132 RVA: 0x002628CC File Offset: 0x00260ACC
	public bool GetChapterIsLock(int chapterId)
	{
		AdventureTaskChapterV2? chapterById = ConfigBase<ActivityNewcomerJourneyConfig>.Instance.GetChapterById(chapterId);
		if (chapterById == null)
		{
			return true;
		}
		if (chapterById.Value.Sort == 1)
		{
			return false;
		}
		AdventureTaskChapterV2? adventureTaskChapterV = null;
		foreach (NewcomerJourneyChapterData newcomerJourneyChapterData in this.ChapterDataMap.Values)
		{
			AdventureTaskChapterV2? chapterById2 = ConfigBase<ActivityNewcomerJourneyConfig>.Instance.GetChapterById(newcomerJourneyChapterData.Data.Id);
			if (chapterById2 != null && chapterById2.Value.Sort == chapterById.Value.Sort - 1)
			{
				adventureTaskChapterV = chapterById2;
				break;
			}
		}
		return adventureTaskChapterV == null || this.GetChapterCompleteNum(adventureTaskChapterV.Value.Id) < chapterById.Value.LevelUnlockCount;
	}

	// Token: 0x0600910D RID: 37133 RVA: 0x002629CC File Offset: 0x00260BCC
	public int GetLastUnLockChapterIndex()
	{
		List<AdventureTaskChapterV2> chapterList = this.GetChapterList();
		if (chapterList == null)
		{
			return -1;
		}
		int num = 1;
		foreach (AdventureTaskChapterV2 adventureTaskChapterV in chapterList)
		{
			if (!this.GetChapterIsLock(adventureTaskChapterV.Id) && num < adventureTaskChapterV.Sort)
			{
				num = adventureTaskChapterV.Sort;
			}
		}
		return num;
	}

	// Token: 0x0600910E RID: 37134 RVA: 0x00262A44 File Offset: 0x00260C44
	protected override bool GetExDataFinishShowState()
	{
		bool flag = true;
		foreach (int chapterId in this.ChapterDataMap.Keys)
		{
			if (!this.GetChapterRewardHasGet(chapterId) || !this.GetChapterTaskAllComplete(chapterId))
			{
				flag = false;
				break;
			}
		}
		return flag && this.GetCharacterHasGet();
	}

	// Token: 0x06009110 RID: 37136 RVA: 0x00262AD2 File Offset: 0x00260CD2
	[CompilerGenerated]
	internal static int <GetChapterTaskList>g__GetPriority|13_0(ConditionTaskState status)
	{
		switch (status)
		{
		case ConditionTaskState.ConditionTaskRunning:
			return 1;
		case ConditionTaskState.ConditionTaskFinish:
			return 0;
		}
		return 2;
	}

	// Token: 0x04004338 RID: 17208
	private readonly Dictionary<int, NewcomerJourneyChapterData> ChapterDataMap = new Dictionary<int, NewcomerJourneyChapterData>();

	// Token: 0x04004339 RID: 17209
	[Nullable(2)]
	private List<int> PreviewCharacterList;

	// Token: 0x0400433A RID: 17210
	public int ChooseRoleChapterId = -1;
}
