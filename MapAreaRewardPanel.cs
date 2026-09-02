using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001B8F RID: 7055
[NullableContext(1)]
[Nullable(0)]
public class MapAreaRewardPanel : UiPanelBase
{
	// Token: 0x0600CD0F RID: 52495 RVA: 0x00369430 File Offset: 0x00367630
	protected unsafe override void OnRegisterComponent()
	{
		int num = 7;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIHorizontalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUISprite));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600CD10 RID: 52496 RVA: 0x00369540 File Offset: 0x00367740
	protected override void OnStart()
	{
		this.RewardLayout = new GenericLayout<MapAreaRewardItem, DailyActivityDefine.IActivityGoalData>(base.GetHorizontalLayout(3), new Func<MapAreaRewardItem>(this.OnCreateRewardItem), null, false, true);
		UUIItem item = base.GetItem(0);
		this.MaxProgressWidth = item.GetWidth();
		this.ProgressBarItem = base.GetItem(0);
	}

	// Token: 0x0600CD11 RID: 52497 RVA: 0x0036958F File Offset: 0x0036778F
	protected override void OnBeforeDestroy()
	{
		this.ProgressBarItem = null;
		this.RefreshIdContainer = null;
		this.RewardPopup = null;
	}

	// Token: 0x0600CD12 RID: 52498 RVA: 0x003695A6 File Offset: 0x003677A6
	public void Init(IMapAreaRewardParam param)
	{
		this.ChangeParamData(param);
	}

	// Token: 0x0600CD13 RID: 52499 RVA: 0x003695AF File Offset: 0x003677AF
	public void InitCommonRewardPopup(UUIItem rootItem)
	{
		this.RewardPopup = new CommonRewardPopup(rootItem);
	}

	// Token: 0x0600CD14 RID: 52500 RVA: 0x003695C0 File Offset: 0x003677C0
	public void ChangeParamData(IMapAreaRewardParam param)
	{
		this.ParamData = param;
		this.CurrentValue = param.InitValue;
		this.CurrentFinishedRewardCount = 0;
		this.IdToIndexMap.Clear();
		for (int i = 0; i < param.RewardDataList.Count; i++)
		{
			DailyActivityDefine.IActivityGoalData activityGoalData = param.RewardDataList[i];
			if (activityGoalData.State != EDailyActiveState.Unfinished)
			{
				this.CurrentFinishedRewardCount++;
			}
			this.IdToIndexMap[activityGoalData.Id] = i;
		}
		this.RewardLayout.RefreshByData(param.RewardDataList, null, false);
		base.GetSprite(2).SetUIActive(false);
		base.GetSprite(6).SetUIActive(false);
		if (param.RewardDataList.Count != 0)
		{
			this.RewardWidth = 120f;
			this.LineWidth = (this.MaxProgressWidth - this.RewardWidth * (float)(param.RewardDataList.Count - 1)) / (float)param.RewardDataList.Count;
			this.SetProgressBarPercent((float)this.CurrentValue / (float)param.MaxValue);
			return;
		}
		UUIItem rootItem = this.RootItem;
		if (rootItem == null)
		{
			return;
		}
		rootItem.SetUIActive(false);
	}

	// Token: 0x0600CD15 RID: 52501 RVA: 0x003696DC File Offset: 0x003678DC
	public void OnTickRefresh(float deltaTime)
	{
		if (!this.IsShowAnimate)
		{
			return;
		}
		this.AnimateRunTime += (double)deltaTime * Singleton<TimeUtil>.Instance.Millisecond;
		double alpha = Singleton<MathUtils>.Instance.Clamp(this.AnimateRunTime / 0.5, 0.0, 1.0);
		this.CurrentValue = (int)Singleton<MathUtils>.Instance.Lerp((double)this.CurrentSaveValue, (double)this.GoalValue, alpha);
		float progressBarPercent = Singleton<MathUtils>.Instance.Clamp((float)this.CurrentValue / (float)this.ParamData.MaxValue, 0f, 1f);
		this.RefreshRewardItemDynamic(this.CurrentValue);
		this.SetProgressBarPercent(progressBarPercent);
		if (this.CurrentValue == this.GoalValue)
		{
			this.EndProgressAnimate();
		}
	}

	// Token: 0x0600CD16 RID: 52502 RVA: 0x003697AC File Offset: 0x003679AC
	public void RefreshProgressBarDynamic(int value)
	{
		if (value <= this.CurrentValue)
		{
			return;
		}
		if (this.IsShowAnimate)
		{
			this.EndProgressAnimate();
		}
		this.RefreshIdContainer = new List<ValueTuple<int, int>>();
		foreach (DailyActivityDefine.IActivityGoalData activityGoalData in this.ParamData.RewardDataList)
		{
			if (this.CurrentValue < activityGoalData.Goal && activityGoalData.Goal <= value)
			{
				this.RefreshIdContainer.Add(new ValueTuple<int, int>(activityGoalData.Goal, activityGoalData.Id));
			}
		}
		this.StartProgressAnimate(value);
	}

	// Token: 0x0600CD17 RID: 52503 RVA: 0x0036985C File Offset: 0x00367A5C
	public void UpdateRewardIds(IReadOnlyList<int> ids)
	{
		foreach (int goalId in ids)
		{
			this.RefreshRewardItem(goalId);
		}
	}

	// Token: 0x0600CD18 RID: 52504 RVA: 0x003698A4 File Offset: 0x00367AA4
	protected override void OnBeforeHide()
	{
		CommonRewardPopup rewardPopup = this.RewardPopup;
		if (rewardPopup == null)
		{
			return;
		}
		rewardPopup.SetActive(false);
	}

	// Token: 0x0600CD19 RID: 52505 RVA: 0x003698B8 File Offset: 0x00367AB8
	private void RefreshAllRewardItem()
	{
		int num = 0;
		foreach (MapAreaRewardItem mapAreaRewardItem in this.RewardLayout.GetLayoutItemList())
		{
			mapAreaRewardItem.RefreshSelf();
			if (mapAreaRewardItem.DailyActiveState.GetValueOrDefault() != EDailyActiveState.Unfinished)
			{
				num++;
			}
		}
		this.CurrentFinishedRewardCount = num;
	}

	// Token: 0x0600CD1A RID: 52506 RVA: 0x0036992C File Offset: 0x00367B2C
	private void RefreshRewardItem(int goalId)
	{
		int index;
		if (this.IdToIndexMap.TryGetValue(goalId, out index))
		{
			MapAreaRewardItem layoutItemByIndex = this.RewardLayout.GetLayoutItemByIndex(index);
			if (layoutItemByIndex == null)
			{
				return;
			}
			layoutItemByIndex.RefreshSelf();
		}
	}

	// Token: 0x0600CD1B RID: 52507 RVA: 0x00369960 File Offset: 0x00367B60
	private void RefreshRewardItemDynamic(int value)
	{
		if (this.RefreshIdContainer.Count == 0)
		{
			return;
		}
		ValueTuple<int, int> valueTuple = this.RefreshIdContainer[0];
		if (valueTuple.Item1 <= value)
		{
			this.RefreshRewardItem(valueTuple.Item2);
			this.RefreshIdContainer.RemoveAt(0);
			this.CurrentFinishedRewardCount++;
		}
	}

	// Token: 0x0600CD1C RID: 52508 RVA: 0x003699B8 File Offset: 0x00367BB8
	private void SetProgressBarPercent(float percent)
	{
		int count = this.ParamData.RewardDataList.Count;
		float num = (float)Math.Min(this.CurrentFinishedRewardCount, count - 1) * this.RewardWidth;
		float num2 = this.LineWidth * (float)count * Math.Min(percent, 1f);
		float stretchRight = this.MaxProgressWidth - num - num2;
		this.ProgressBarItem.SetStretchRight(stretchRight);
	}

	// Token: 0x0600CD1D RID: 52509 RVA: 0x00369A1A File Offset: 0x00367C1A
	private void StartProgressAnimate(int goalValue)
	{
		this.GoalValue = goalValue;
		this.CurrentSaveValue = this.CurrentValue;
		this.AnimateRunTime = 0.0;
		this.IsShowAnimate = true;
	}

	// Token: 0x0600CD1E RID: 52510 RVA: 0x00369A48 File Offset: 0x00367C48
	private void EndProgressAnimate()
	{
		this.IsShowAnimate = false;
		this.CurrentValue = this.GoalValue;
		float progressBarPercent = Singleton<MathUtils>.Instance.Clamp((float)this.GoalValue / (float)this.ParamData.MaxValue, 0f, 1f);
		this.RefreshAllRewardItem();
		this.SetProgressBarPercent(progressBarPercent);
	}

	// Token: 0x0600CD1F RID: 52511 RVA: 0x00369AA0 File Offset: 0x00367CA0
	private MapAreaRewardItem OnCreateRewardItem()
	{
		UUISprite sprite = base.GetSprite(2);
		UUIItem item = base.GetItem(1);
		UUIItem item2 = base.GetItem(5);
		UUISprite sprite2 = base.GetSprite(6);
		Singleton<LguiUtil>.Instance.CopyItem(sprite2, item2);
		Singleton<LguiUtil>.Instance.CopyItem(sprite, item);
		return new MapAreaRewardItem(this.ParamData.GetRewardCallback, new Action<RewardPopupData>(this.OpenRewardCallback));
	}

	// Token: 0x0600CD20 RID: 52512 RVA: 0x00369B03 File Offset: 0x00367D03
	private void OpenRewardCallback(RewardPopupData data)
	{
		CommonRewardPopup rewardPopup = this.RewardPopup;
		if (rewardPopup == null)
		{
			return;
		}
		rewardPopup.Refresh(data);
	}

	// Token: 0x040061FB RID: 25083
	private const float PROGRESS_ANIMATE_TIME = 0.5f;

	// Token: 0x040061FC RID: 25084
	private const int REWARD_WIDTH = 120;

	// Token: 0x040061FD RID: 25085
	private IMapAreaRewardParam ParamData;

	// Token: 0x040061FE RID: 25086
	private GenericLayout<MapAreaRewardItem, DailyActivityDefine.IActivityGoalData> RewardLayout;

	// Token: 0x040061FF RID: 25087
	[Nullable(2)]
	private UUIItem ProgressBarItem;

	// Token: 0x04006200 RID: 25088
	private int CurrentValue;

	// Token: 0x04006201 RID: 25089
	private int GoalValue;

	// Token: 0x04006202 RID: 25090
	private int CurrentSaveValue;

	// Token: 0x04006203 RID: 25091
	private bool IsShowAnimate;

	// Token: 0x04006204 RID: 25092
	private double AnimateRunTime;

	// Token: 0x04006205 RID: 25093
	[Nullable(new byte[]
	{
		2,
		0
	})]
	private List<ValueTuple<int, int>> RefreshIdContainer = new List<ValueTuple<int, int>>();

	// Token: 0x04006206 RID: 25094
	private readonly Dictionary<int, int> IdToIndexMap = new Dictionary<int, int>();

	// Token: 0x04006207 RID: 25095
	private int CurrentFinishedRewardCount;

	// Token: 0x04006208 RID: 25096
	private float MaxProgressWidth;

	// Token: 0x04006209 RID: 25097
	private float RewardWidth;

	// Token: 0x0400620A RID: 25098
	private float LineWidth;

	// Token: 0x0400620B RID: 25099
	[Nullable(2)]
	private CommonRewardPopup RewardPopup;

	// Token: 0x02007E71 RID: 32369
	[NullableContext(0)]
	private enum EActivityPanelItem
	{
		// Token: 0x0402B123 RID: 176419
		ProgressPanel,
		// Token: 0x0402B124 RID: 176420
		BarPanel,
		// Token: 0x0402B125 RID: 176421
		BarSprite,
		// Token: 0x0402B126 RID: 176422
		RewardPanel,
		// Token: 0x0402B127 RID: 176423
		RewardItem,
		// Token: 0x0402B128 RID: 176424
		PanelBackground,
		// Token: 0x0402B129 RID: 176425
		BackgroundSprite
	}
}
