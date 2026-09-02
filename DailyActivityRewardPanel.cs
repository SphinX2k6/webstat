using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001AA6 RID: 6822
[NullableContext(1)]
[Nullable(0)]
public class DailyActivityRewardPanel : UiPanelBase
{
	// Token: 0x0600C35F RID: 50015 RVA: 0x00337B4C File Offset: 0x00335D4C
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIHorizontalLayout)),
			new ValueTuple<int, Type>(1, typeof(UUIItem))
		};
	}

	// Token: 0x0600C360 RID: 50016 RVA: 0x00337B85 File Offset: 0x00335D85
	protected override void OnStart()
	{
		this.RewardLayout = new GenericLayout<DailyActivityRewardItem, DailyActivityRewardData>(base.GetHorizontalLayout(0), new Func<DailyActivityRewardItem>(this.OnCreateRewardItem), null, false, true);
	}

	// Token: 0x0600C361 RID: 50017 RVA: 0x00337BA8 File Offset: 0x00335DA8
	protected override void OnBeforeDestroy()
	{
		this.RefreshIdContainer = null;
	}

	// Token: 0x0600C362 RID: 50018 RVA: 0x00337BB4 File Offset: 0x00335DB4
	public void Init()
	{
		DailyActivityDefine.IActivityRewardPanelDataAdapter activityRewardPanelDataAdapter = this.DataAdapter ?? new DailyActivityRewardAdapter();
		IReadOnlyDictionary<int, DailyActivityDefine.IActivityGoalData> goalMap = activityRewardPanelDataAdapter.GoalMap;
		this.CurrentValue = activityRewardPanelDataAdapter.CurrentValue;
		this.MaxValue = activityRewardPanelDataAdapter.MaxValue;
		double num = (this.MaxValue > 0.0) ? (this.CurrentValue / this.MaxValue) : 0.0;
		int count = goalMap.Count;
		List<DailyActivityRewardData> list = new List<DailyActivityRewardData>();
		foreach (DailyActivityDefine.IActivityGoalData activityGoalData in goalMap.Values)
		{
			list.Add(new DailyActivityRewardData(activityGoalData.Id, num, count));
		}
		this.TotalRewardCount = list.Count;
		if (this.TotalRewardCount <= 0)
		{
			return;
		}
		this.RewardDataList = list;
		this.RewardLayout.RefreshByData(list, null, false);
		this.SetProgressBarPercent(num);
	}

	// Token: 0x0600C363 RID: 50019 RVA: 0x00337CAC File Offset: 0x00335EAC
	[NullableContext(2)]
	public UUIItem GetRewardItemByIndex(int index)
	{
		return this.RewardLayout.GetItemByIndex(index);
	}

	// Token: 0x0600C364 RID: 50020 RVA: 0x00337CBC File Offset: 0x00335EBC
	private void RefreshAllRewardItem()
	{
		foreach (DailyActivityRewardItem dailyActivityRewardItem in this.RewardLayout.GetLayoutItemList())
		{
			dailyActivityRewardItem.RefreshSelf();
		}
	}

	// Token: 0x0600C365 RID: 50021 RVA: 0x00337D14 File Offset: 0x00335F14
	private void RefreshRewardItem(int goalId)
	{
		int num = -1;
		for (int i = 0; i < this.RewardDataList.Count; i++)
		{
			if (this.RewardDataList[i].RewardId == goalId)
			{
				num = i;
				break;
			}
		}
		if (num < 0)
		{
			return;
		}
		this.RewardLayout.GetLayoutItemList()[num].RefreshSelf();
	}

	// Token: 0x0600C366 RID: 50022 RVA: 0x00337D6C File Offset: 0x00335F6C
	private void RefreshRewardItemDynamic(double value)
	{
		if (this.RefreshIdContainer.Count != 0)
		{
			ValueTuple<int, int> valueTuple = this.RefreshIdContainer[0];
			if ((double)valueTuple.Item1 <= value)
			{
				this.RefreshRewardItem(valueTuple.Item2);
				this.RefreshIdContainer.RemoveAt(0);
			}
		}
	}

	// Token: 0x0600C367 RID: 50023 RVA: 0x00337DB8 File Offset: 0x00335FB8
	private UniTask PlayItemRewardAnimAsync(int goalId)
	{
		DailyActivityRewardPanel.<PlayItemRewardAnimAsync>d__20 <PlayItemRewardAnimAsync>d__;
		<PlayItemRewardAnimAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PlayItemRewardAnimAsync>d__.<>4__this = this;
		<PlayItemRewardAnimAsync>d__.goalId = goalId;
		<PlayItemRewardAnimAsync>d__.<>1__state = -1;
		<PlayItemRewardAnimAsync>d__.<>t__builder.Start<DailyActivityRewardPanel.<PlayItemRewardAnimAsync>d__20>(ref <PlayItemRewardAnimAsync>d__);
		return <PlayItemRewardAnimAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600C368 RID: 50024 RVA: 0x00337E04 File Offset: 0x00336004
	private UniTask GroupPlayItemRewardAnimAsync(List<int> goalIds)
	{
		DailyActivityRewardPanel.<GroupPlayItemRewardAnimAsync>d__21 <GroupPlayItemRewardAnimAsync>d__;
		<GroupPlayItemRewardAnimAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<GroupPlayItemRewardAnimAsync>d__.<>4__this = this;
		<GroupPlayItemRewardAnimAsync>d__.goalIds = goalIds;
		<GroupPlayItemRewardAnimAsync>d__.<>1__state = -1;
		<GroupPlayItemRewardAnimAsync>d__.<>t__builder.Start<DailyActivityRewardPanel.<GroupPlayItemRewardAnimAsync>d__21>(ref <GroupPlayItemRewardAnimAsync>d__);
		return <GroupPlayItemRewardAnimAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600C369 RID: 50025 RVA: 0x00337E50 File Offset: 0x00336050
	private void GroupPlayItemRewardAnim(List<int> goalIds)
	{
		DailyActivityRewardPanel.<>c__DisplayClass22_0 CS$<>8__locals1 = new DailyActivityRewardPanel.<>c__DisplayClass22_0();
		CS$<>8__locals1.<>4__this = this;
		CS$<>8__locals1.goalIds = goalIds;
		UiAsyncTask task = new UiAsyncTask("Reward", delegate()
		{
			DailyActivityRewardPanel.<>c__DisplayClass22_0.<<GroupPlayItemRewardAnim>b__0>d <<GroupPlayItemRewardAnim>b__0>d;
			<<GroupPlayItemRewardAnim>b__0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<<GroupPlayItemRewardAnim>b__0>d.<>4__this = CS$<>8__locals1;
			<<GroupPlayItemRewardAnim>b__0>d.<>1__state = -1;
			<<GroupPlayItemRewardAnim>b__0>d.<>t__builder.Start<DailyActivityRewardPanel.<>c__DisplayClass22_0.<<GroupPlayItemRewardAnim>b__0>d>(ref <<GroupPlayItemRewardAnim>b__0>d);
			return <<GroupPlayItemRewardAnim>b__0>d.<>t__builder.Task;
		}, null);
		base.RunAsyncTask(task);
	}

	// Token: 0x0600C36A RID: 50026 RVA: 0x00337E94 File Offset: 0x00336094
	public void OnTickRefresh(float deltaTime)
	{
		if (!this.IsShowAnimate)
		{
			return;
		}
		this.AnimateRunTime += (double)deltaTime * Singleton<TimeUtil>.Instance.Millisecond;
		double alpha = (this.AnimateRunTime / 0.5 > 1.0) ? 1.0 : (this.AnimateRunTime / 0.5);
		this.CurrentValue = Singleton<MathUtils>.Instance.Lerp(this.CurrentSaveValue, (double)this.GoalValue, alpha);
		double progressBarPercent = (this.MaxValue > 0.0) ? (this.CurrentValue / this.MaxValue) : 0.0;
		this.RefreshRewardItemDynamic(this.CurrentValue);
		this.SetProgressBarPercent(progressBarPercent);
		if (this.CurrentValue == (double)this.GoalValue)
		{
			this.EndProgressAnimate();
		}
	}

	// Token: 0x0600C36B RID: 50027 RVA: 0x00337F6C File Offset: 0x0033616C
	private void SetProgressBarPercent(double percent)
	{
		foreach (DailyActivityRewardItem dailyActivityRewardItem in this.RewardLayout.GetLayoutItemList())
		{
			dailyActivityRewardItem.RefreshProgress(percent);
		}
	}

	// Token: 0x0600C36C RID: 50028 RVA: 0x00337FC4 File Offset: 0x003361C4
	private void StartProgressAnimate(float goalValue)
	{
		this.GoalValue = goalValue;
		this.CurrentSaveValue = this.CurrentValue;
		this.AnimateRunTime = 0.0;
		this.IsShowAnimate = true;
	}

	// Token: 0x0600C36D RID: 50029 RVA: 0x00337FF0 File Offset: 0x003361F0
	private void EndProgressAnimate()
	{
		this.IsShowAnimate = false;
		this.CurrentValue = (double)this.GoalValue;
		double progressBarPercent = (this.MaxValue > 0.0) ? Singleton<MathUtils>.Instance.Clamp((double)this.GoalValue / this.MaxValue, 0.0, 1.0) : 0.0;
		this.RefreshAllRewardItem();
		this.SetProgressBarPercent(progressBarPercent);
	}

	// Token: 0x0600C36E RID: 50030 RVA: 0x00338068 File Offset: 0x00336268
	public void RefreshProgressBarDynamic(float value)
	{
		if ((double)value <= this.CurrentValue)
		{
			return;
		}
		if (this.IsShowAnimate)
		{
			this.EndProgressAnimate();
		}
		IEnumerable<KeyValuePair<int, DailyActivityDefine.IActivityGoalData>> goalMap = (this.DataAdapter ?? new DailyActivityRewardAdapter()).GoalMap;
		this.RefreshIdContainer = new List<ValueTuple<int, int>>();
		foreach (KeyValuePair<int, DailyActivityDefine.IActivityGoalData> keyValuePair in goalMap)
		{
			int key = keyValuePair.Key;
			DailyActivityDefine.IActivityGoalData value2 = keyValuePair.Value;
			if (this.CurrentValue < (double)value2.Goal && (float)value2.Goal <= value)
			{
				this.RefreshIdContainer.Add(new ValueTuple<int, int>(value2.Goal, key));
			}
		}
		this.StartProgressAnimate(value);
	}

	// Token: 0x0600C36F RID: 50031 RVA: 0x00338128 File Offset: 0x00336328
	private void OnRewardTake(IReadOnlyList<int> ids)
	{
		foreach (int goalId in ids)
		{
			this.RefreshRewardItem(goalId);
		}
	}

	// Token: 0x0600C370 RID: 50032 RVA: 0x00338170 File Offset: 0x00336370
	private void RequestGetAllAvailableReward()
	{
		DailyActivityDefine.IActivityRewardPanelDataAdapter activityRewardPanelDataAdapter = this.DataAdapter ?? new DailyActivityRewardAdapter();
		List<int> idList = activityRewardPanelDataAdapter.GetCanRewardIdList();
		Action onClose = delegate()
		{
			this.GroupPlayItemRewardAnim(idList);
		};
		activityRewardPanelDataAdapter.RequestReward(idList, onClose);
	}

	// Token: 0x0600C371 RID: 50033 RVA: 0x003381C0 File Offset: 0x003363C0
	private DailyActivityRewardItem OnCreateRewardItem()
	{
		return new DailyActivityRewardItem
		{
			RewardRequestDelegate = new Action(this.RequestGetAllAvailableReward),
			DataAdapter = this.DataAdapter
		};
	}

	// Token: 0x04005DA8 RID: 23976
	private const float PROGRESS_ANIMATE_TIME = 0.5f;

	// Token: 0x04005DA9 RID: 23977
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<DailyActivityRewardItem, DailyActivityRewardData> RewardLayout;

	// Token: 0x04005DAA RID: 23978
	private double CurrentValue;

	// Token: 0x04005DAB RID: 23979
	private double MaxValue;

	// Token: 0x04005DAC RID: 23980
	private float GoalValue;

	// Token: 0x04005DAD RID: 23981
	private double CurrentSaveValue;

	// Token: 0x04005DAE RID: 23982
	private bool IsShowAnimate;

	// Token: 0x04005DAF RID: 23983
	private double AnimateRunTime;

	// Token: 0x04005DB0 RID: 23984
	[Nullable(new byte[]
	{
		2,
		0
	})]
	private List<ValueTuple<int, int>> RefreshIdContainer = new List<ValueTuple<int, int>>();

	// Token: 0x04005DB1 RID: 23985
	private List<DailyActivityRewardData> RewardDataList = new List<DailyActivityRewardData>();

	// Token: 0x04005DB2 RID: 23986
	private int TotalRewardCount;

	// Token: 0x04005DB3 RID: 23987
	[Nullable(2)]
	public DailyActivityDefine.IActivityRewardPanelDataAdapter DataAdapter;
}
