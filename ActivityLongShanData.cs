using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Activity.ActivityContent.LongShan;
using CSharpScript.Game.Module.Map;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.SkipInterface;
using Google.Protobuf.Collections;

// Token: 0x02001353 RID: 4947
[NullableContext(1)]
[Nullable(0)]
public class ActivityLongShanData : ActivityBaseData
{
	// Token: 0x06008760 RID: 34656 RVA: 0x0023A844 File Offset: 0x00238A44
	protected override void OnInit(ActivityData data)
	{
		this.InitScoreReward();
	}

	// Token: 0x06008761 RID: 34657 RVA: 0x0023A84C File Offset: 0x00238A4C
	protected unsafe override void PhraseEx(ActivityData data)
	{
		Dictionary<int, CSharpScript.Game.Module.Activity.ActivityContent.LongShan.LongShanStageInfo> stages = this.Stages;
		if (stages != null)
		{
			stages.Clear();
		}
		this.Stages = (this.Stages ?? new Dictionary<int, CSharpScript.Game.Module.Activity.ActivityContent.LongShan.LongShanStageInfo>());
		this.StageIds = Array.Empty<int>();
		IReadOnlyList<LongShanStage> configList = ConfigLongShanStageAll.GetConfigList(base.Id, true);
		if (configList != null)
		{
			List<int> list = new List<int>();
			using (IEnumerator<LongShanStage> enumerator = configList.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					LongShanStage config = enumerator.Current;
					list.Add(config.Id);
					LongShanActivity longShanActivityData = data.LongShanActivityData;
					Aki.Protocol.LongShanStageInfo longShanStageInfo;
					if (longShanActivityData == null)
					{
						longShanStageInfo = null;
					}
					else
					{
						RepeatedField<Aki.Protocol.LongShanStageInfo> stages2 = longShanActivityData.Stages;
						longShanStageInfo = ((stages2 != null) ? stages2.FirstOrDefault((Aki.Protocol.LongShanStageInfo x) => x.Id == config.Id) : null);
					}
					Aki.Protocol.LongShanStageInfo longShanStageInfo2 = longShanStageInfo;
					if (longShanStageInfo2 != null)
					{
						CSharpScript.Game.Module.Activity.ActivityContent.LongShan.LongShanStageInfo value = new CSharpScript.Game.Module.Activity.ActivityContent.LongShan.LongShanStageInfo(longShanStageInfo2);
						this.Stages[config.Id] = value;
					}
				}
			}
			this.StageIds = list.ToArray();
		}
		LongShanActivity longShanActivityData2 = data.LongShanActivityData;
		RepeatedField<int> repeatedField = (longShanActivityData2 != null) ? longShanActivityData2.ScoreRewardedIds : null;
		if (repeatedField == null)
		{
			return;
		}
		foreach (int num in repeatedField)
		{
			LongShanScoreRewardData scoreRewardDataById = this.GetScoreRewardDataById(num);
			if (scoreRewardDataById == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Activity;
				ELogAuthor author = ELogAuthor.CXJ;
				string message = "[LongShanActivity] 奖励Id不存在";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("ActivityId", base.Id);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("RewardId", num);
				instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			}
			else
			{
				scoreRewardDataById.Achieved = true;
			}
		}
	}

	// Token: 0x06008762 RID: 34658 RVA: 0x0023AA30 File Offset: 0x00238C30
	public void InitScoreReward()
	{
		this.ScoreRewards.Clear();
		this.ScoreRewardIds = Array.Empty<int>();
		IEnumerable<LongShanScoreReward> enumerable = ConfigLongShanScoreRewardByActivityId.GetConfigList(base.Id, true) ?? Array.Empty<LongShanScoreReward>();
		List<int> list = new List<int>();
		foreach (LongShanScoreReward longShanScoreReward in enumerable)
		{
			list.Add(longShanScoreReward.Id);
			LongShanScoreRewardData longShanScoreRewardData = new LongShanScoreRewardData();
			longShanScoreRewardData.Id = longShanScoreReward.Id;
			longShanScoreRewardData.Goal = longShanScoreReward.Score;
			longShanScoreRewardData.DropId = longShanScoreReward.DropId;
			longShanScoreRewardData.GetCurrentScore = new Func<int>(this.GetScoreItemCount);
			this.ScoreItemId = longShanScoreReward.ItemId;
			this.ScoreItemTotal = Math.Max(this.ScoreItemTotal, longShanScoreRewardData.Goal);
			this.ScoreRewards[longShanScoreReward.Id] = longShanScoreRewardData;
		}
		this.ScoreRewardIds = list.ToArray();
	}

	// Token: 0x06008763 RID: 34659 RVA: 0x0023AB38 File Offset: 0x00238D38
	public void UpdateStage(Aki.Protocol.LongShanStageInfo[] stageInfos)
	{
		foreach (Aki.Protocol.LongShanStageInfo longShanStageInfo in stageInfos)
		{
			CSharpScript.Game.Module.Activity.ActivityContent.LongShan.LongShanStageInfo longShanStageInfo2;
			if (this.Stages.TryGetValue(longShanStageInfo.Id, out longShanStageInfo2) && longShanStageInfo2 != null)
			{
				CSharpScript.Game.Module.Activity.ActivityContent.LongShan.LongShanStageInfo longShanStageInfo3 = new CSharpScript.Game.Module.Activity.ActivityContent.LongShan.LongShanStageInfo(longShanStageInfo);
				this.Stages[longShanStageInfo.Id] = longShanStageInfo3;
				this.OnStageInfoChange(longShanStageInfo2, longShanStageInfo3);
			}
		}
		Singleton<EventSystem>.Instance.Emit(EEventName.LongShanUpdate);
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, base.Id);
	}

	// Token: 0x06008764 RID: 34660 RVA: 0x0023ABBC File Offset: 0x00238DBC
	public void OnStageInfoChange(CSharpScript.Game.Module.Activity.ActivityContent.LongShan.LongShanStageInfo oldStage, CSharpScript.Game.Module.Activity.ActivityContent.LongShan.LongShanStageInfo newStage)
	{
		foreach (KeyValuePair<int, LongShanTaskInfo> keyValuePair in oldStage.TaskInfoMap)
		{
			int key = keyValuePair.Key;
			LongShanTaskInfo value = keyValuePair.Value;
			LongShanTaskInfo newTask;
			if (newStage.TaskInfoMap.TryGetValue(key, out newTask))
			{
				this.OnStageTaskInfoChange(key, value, newTask);
			}
		}
	}

	// Token: 0x06008765 RID: 34661 RVA: 0x0023AC34 File Offset: 0x00238E34
	public void OnStageTaskInfoChange(int taskId, LongShanTaskInfo oldTask, LongShanTaskInfo newTask)
	{
		if (!oldTask.IsFinished && newTask.IsFinished)
		{
			int jumpId = ConfigLongShanTaskById.GetConfig(taskId, true).Value.JumpId;
			if (jumpId > 0)
			{
				AccessPath? accessPathConfig = ConfigBase<SkipInterfaceConfig>.Instance.GetAccessPathConfig(jumpId);
				if (accessPathConfig != null && accessPathConfig.Value.SkipName == 8)
				{
					int value = int.Parse(accessPathConfig.Value.Val1);
					ModelBase<MapModel>.Instance.RemoveMapMarksByConfigId(new EMarkType?(EMarkType.Entity), new int?(value));
				}
			}
		}
	}

	// Token: 0x06008766 RID: 34662 RVA: 0x0023ACC4 File Offset: 0x00238EC4
	public void UpdateScoreRewardStatus(int[] ids)
	{
		foreach (int id in ids)
		{
			LongShanScoreRewardData scoreRewardDataById = this.GetScoreRewardDataById(id);
			if (scoreRewardDataById != null)
			{
				scoreRewardDataById.Achieved = true;
			}
		}
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, base.Id);
	}

	// Token: 0x06008767 RID: 34663 RVA: 0x0023AD0D File Offset: 0x00238F0D
	public override bool NeedSelfControlFirstRedPoint()
	{
		return false;
	}

	// Token: 0x06008768 RID: 34664 RVA: 0x0023AD10 File Offset: 0x00238F10
	[NullableContext(2)]
	public Aki.Protocol.LongShanStageInfo GetStageInfoById(int id)
	{
		CSharpScript.Game.Module.Activity.ActivityContent.LongShan.LongShanStageInfo longShanStageInfo;
		if (this.Stages == null || !this.Stages.TryGetValue(id, out longShanStageInfo))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Activity;
			ELogAuthor author = ELogAuthor.CXJ;
			string message = "龙山活动阶段数据为空";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("stageId", id);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		if (longShanStageInfo.ProtoStageInfo == null)
		{
			return null;
		}
		if (!longShanStageInfo.ProtoStageInfo.Unlock)
		{
			return null;
		}
		return longShanStageInfo.ProtoStageInfo;
	}

	// Token: 0x06008769 RID: 34665 RVA: 0x0023AD88 File Offset: 0x00238F88
	public Aki.Protocol.LongShanStageInfo GetStageInfoByIdIncludeLock(int id)
	{
		CSharpScript.Game.Module.Activity.ActivityContent.LongShan.LongShanStageInfo longShanStageInfo;
		if (this.Stages != null && this.Stages.TryGetValue(id, out longShanStageInfo) && longShanStageInfo != null && longShanStageInfo.ProtoStageInfo != null)
		{
			return longShanStageInfo.ProtoStageInfo;
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Activity;
		ELogAuthor author = ELogAuthor.CXJ;
		string message = "龙山活动阶段数据为空";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("stageId", id);
		instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		return null;
	}

	// Token: 0x0600876A RID: 34666 RVA: 0x0023ADF0 File Offset: 0x00238FF0
	public List<int> GetFinishedAndUnclaimedTasksByStageId(int stageId)
	{
		Aki.Protocol.LongShanStageInfo stageInfoById = this.GetStageInfoById(stageId);
		if (stageInfoById == null)
		{
			return new List<int>();
		}
		List<int> list = new List<int>();
		foreach (LongShanTaskInfo longShanTaskInfo in stageInfoById.Tasks)
		{
			if (longShanTaskInfo.IsFinished && !longShanTaskInfo.IsTaken)
			{
				list.Add(longShanTaskInfo.Id);
			}
		}
		return list;
	}

	// Token: 0x0600876B RID: 34667 RVA: 0x0023AE6C File Offset: 0x0023906C
	public int TaskSort(LongShanTaskInfo a, LongShanTaskInfo b)
	{
		if (a.IsTaken != b.IsTaken)
		{
			if (!a.IsTaken)
			{
				return -1;
			}
			return 1;
		}
		else if (a.IsFinished != b.IsFinished)
		{
			if (!a.IsFinished)
			{
				return 1;
			}
			return -1;
		}
		else
		{
			int sortId = ConfigLongShanTaskById.GetConfig(a.Id, true).Value.SortId;
			int sortId2 = ConfigLongShanTaskById.GetConfig(b.Id, true).Value.SortId;
			if (sortId != sortId2)
			{
				return sortId - sortId2;
			}
			return a.Id - b.Id;
		}
	}

	// Token: 0x0600876C RID: 34668 RVA: 0x0023AEFC File Offset: 0x002390FC
	public int GetProgress(int id)
	{
		Aki.Protocol.LongShanStageInfo stageInfoById = this.GetStageInfoById(id);
		if (stageInfoById == null)
		{
			return 0;
		}
		RepeatedField<LongShanTaskInfo> tasks = stageInfoById.Tasks;
		float num;
		if (tasks == null)
		{
			num = (float)0;
		}
		else
		{
			num = (float)tasks.Count((LongShanTaskInfo x) => x.IsTaken);
		}
		return (int)Math.Ceiling((double)(num * 1f / (float)stageInfoById.Tasks.Count * 100f));
	}

	// Token: 0x0600876D RID: 34669 RVA: 0x0023AF68 File Offset: 0x00239168
	public bool IsStageUnlock(int stageId)
	{
		bool flag = this.IsStageReachOpenTime(stageId);
		Aki.Protocol.LongShanStageInfo stageInfoByIdIncludeLock = this.GetStageInfoByIdIncludeLock(stageId);
		return stageInfoByIdIncludeLock != null && stageInfoByIdIncludeLock.Unlock && flag;
	}

	// Token: 0x0600876E RID: 34670 RVA: 0x0023AF94 File Offset: 0x00239194
	public bool IsStageReachOpenTime(int stageId)
	{
		Aki.Protocol.LongShanStageInfo stageInfoByIdIncludeLock = this.GetStageInfoByIdIncludeLock(stageId);
		if (stageInfoByIdIncludeLock == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Activity;
			ELogAuthor author = ELogAuthor.CXJ;
			string message = "龙山活动阶段数据为空";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("stageId", stageId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return false;
		}
		double serverTimeStamp = Singleton<TimeUtil>.Instance.GetServerTimeStamp();
		long beginOpenTime = stageInfoByIdIncludeLock.BeginOpenTime;
		return beginOpenTime == 0L || (double)beginOpenTime < serverTimeStamp;
	}

	// Token: 0x0600876F RID: 34671 RVA: 0x0023AFFC File Offset: 0x002391FC
	public float GetScoreRewardRelativeProgress(int scoreRewardId)
	{
		List<LongShanScoreRewardData> allScoreRewardData = this.GetAllScoreRewardData();
		int num = allScoreRewardData.FindIndex((LongShanScoreRewardData data) => data.Id == scoreRewardId);
		int goal = allScoreRewardData[num].Goal;
		int num2 = num - 1;
		int num3 = 0;
		if (num2 >= 0)
		{
			num3 = allScoreRewardData[num2].Goal;
		}
		return (float)(this.GetScoreItemCount() - num3) / (float)(goal - num3);
	}

	// Token: 0x06008770 RID: 34672 RVA: 0x0023B06C File Offset: 0x0023926C
	public bool CheckStageRed(int id)
	{
		Aki.Protocol.LongShanStageInfo stageInfoById = this.GetStageInfoById(id);
		if (stageInfoById == null)
		{
			return false;
		}
		if (ModelBase<ActivityModel>.Instance.GetActivityCacheData(base.Id, 0, id, 0, 0) == 0)
		{
			return true;
		}
		if (stageInfoById.Tasks != null)
		{
			return stageInfoById.Tasks.Any((LongShanTaskInfo x) => x.IsFinished && !x.IsTaken);
		}
		return false;
	}

	// Token: 0x06008771 RID: 34673 RVA: 0x0023B0D2 File Offset: 0x002392D2
	public void SaveNewStageFlag(int stageId)
	{
		ModelBase<ActivityModel>.Instance.SaveActivityData(base.Id, stageId, 0, 0, 1);
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, base.Id);
	}

	// Token: 0x06008772 RID: 34674 RVA: 0x0023B100 File Offset: 0x00239300
	public bool CheckAnyStageRed()
	{
		if (this.StageIds != null)
		{
			foreach (int id in this.StageIds)
			{
				if (this.CheckStageRed(id))
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x06008773 RID: 34675 RVA: 0x0023B13C File Offset: 0x0023933C
	public bool CheckScoreRewardRedDot()
	{
		using (List<LongShanScoreRewardData>.Enumerator enumerator = this.GetAllScoreRewardData().GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.GetState() == EActivityTaskState.FinishedAndUnclaimed)
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x06008774 RID: 34676 RVA: 0x0023B198 File Offset: 0x00239398
	public override bool GetExDataRedPointShowState()
	{
		return this.CheckAnyStageRed() || this.CheckScoreRewardRedDot();
	}

	// Token: 0x06008775 RID: 34677 RVA: 0x0023B1AC File Offset: 0x002393AC
	protected override bool GetExDataFinishShowState()
	{
		using (List<LongShanScoreRewardData>.Enumerator enumerator = this.GetAllScoreRewardData().GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.GetState() != EActivityTaskState.FinishedAndClaimed)
				{
					return false;
				}
			}
		}
		if (this.StageIds != null)
		{
			foreach (int id in this.StageIds)
			{
				if (this.GetProgress(id) != 100)
				{
					return false;
				}
			}
		}
		return true;
	}

	// Token: 0x06008776 RID: 34678 RVA: 0x0023B238 File Offset: 0x00239438
	public List<LongShanScoreRewardData> GetAllScoreRewardData()
	{
		return (from a in this.ScoreRewards.Values
		orderby a.Goal
		select a).ToList<LongShanScoreRewardData>();
	}

	// Token: 0x06008777 RID: 34679 RVA: 0x0023B270 File Offset: 0x00239470
	public LongShanScoreRewardData GetScoreRewardDataById(int id)
	{
		LongShanScoreRewardData result;
		this.ScoreRewards.TryGetValue(id, out result);
		return result;
	}

	// Token: 0x06008778 RID: 34680 RVA: 0x0023B28D File Offset: 0x0023948D
	public int GetScoreItemCount()
	{
		return ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(this.ScoreItemId, 0);
	}

	// Token: 0x06008779 RID: 34681 RVA: 0x0023B2A0 File Offset: 0x002394A0
	public int[] GetAllAvailableScoreRewardIds()
	{
		List<int> list = new List<int>();
		foreach (LongShanScoreRewardData longShanScoreRewardData in this.GetAllScoreRewardData())
		{
			if (longShanScoreRewardData.GetState() == EActivityTaskState.FinishedAndUnclaimed)
			{
				list.Add(longShanScoreRewardData.Id);
			}
		}
		return list.ToArray();
	}

	// Token: 0x04003FC1 RID: 16321
	private const int TASK_FINISH_PERCENT = 100;

	// Token: 0x04003FC2 RID: 16322
	[Nullable(2)]
	public int[] StageIds;

	// Token: 0x04003FC3 RID: 16323
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Dictionary<int, CSharpScript.Game.Module.Activity.ActivityContent.LongShan.LongShanStageInfo> Stages;

	// Token: 0x04003FC4 RID: 16324
	public int[] ScoreRewardIds = Array.Empty<int>();

	// Token: 0x04003FC5 RID: 16325
	private readonly Dictionary<int, LongShanScoreRewardData> ScoreRewards = new Dictionary<int, LongShanScoreRewardData>();

	// Token: 0x04003FC6 RID: 16326
	public int ScoreItemId;

	// Token: 0x04003FC7 RID: 16327
	public int ScoreItemTotal;
}
