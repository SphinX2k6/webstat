using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Map;
using CSharpScript.Game.Module.SkipInterface;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200137C RID: 4988
public class ActivitySubViewMapExplore : ActivitySubViewBase
{
	// Token: 0x060088C7 RID: 35015 RVA: 0x002409E4 File Offset: 0x0023EBE4
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUIText)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIText)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIText)),
			new ValueTuple<int, Type>(9, typeof(UUIText)),
			new ValueTuple<int, Type>(10, typeof(UUIScrollViewWithScrollbarComponent)),
			new ValueTuple<int, Type>(11, typeof(UUIItem)),
			new ValueTuple<int, Type>(12, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(13, typeof(UUIText)),
			new ValueTuple<int, Type>(14, typeof(UUIItem)),
			new ValueTuple<int, Type>(15, typeof(UUITexture)),
			new ValueTuple<int, Type>(16, typeof(UUITexture))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(12, new Action(this.OnBtnJump))
		};
	}

	// Token: 0x060088C8 RID: 35016 RVA: 0x00240BA0 File Offset: 0x0023EDA0
	private void OnBtnJump()
	{
		if (this.ExploreInfo == null)
		{
			return;
		}
		ExploreActivity value = this.ExploreInfo.Value;
		int recommendAreaListLength = value.RecommendAreaListLength;
		if (recommendAreaListLength == 0)
		{
			return;
		}
		ExploreAreaData jumpExploreInfo = this.GetJumpExploreInfo();
		if (jumpExploreInfo == null)
		{
			return;
		}
		int areaId = jumpExploreInfo.AreaId;
		if (!ModelBase<MapModel>.Instance.CheckAreasUnlocked(areaId, true))
		{
			int num = -1;
			for (int i = 0; i < recommendAreaListLength; i++)
			{
				if (value.RecommendAreaList(i) == areaId)
				{
					num = i;
					break;
				}
			}
			if (num >= 0 && num < value.SourceListLength)
			{
				int num2 = value.SourceList(num);
				if (num2 != 0)
				{
					SkipTaskManager.RunByConfigId(num2, null);
					return;
				}
			}
		}
		List<ExploreAreaItemData> recommendExploreItemDataList = jumpExploreInfo.GetRecommendExploreItemDataList(false);
		ExploreAreaItemData exploreAreaItemData = null;
		if (recommendExploreItemDataList != null)
		{
			for (int j = 0; j < recommendExploreItemDataList.Count; j++)
			{
				if (!recommendExploreItemDataList[j].IsCompleted())
				{
					exploreAreaItemData = recommendExploreItemDataList[j];
					break;
				}
			}
		}
		SkipTaskManager.Run(ESkipName.SkipToExploreAreaDetailView, new object[]
		{
			areaId,
			(exploreAreaItemData != null) ? new EExploreType?(exploreAreaItemData.ExploreType) : null
		});
	}

	// Token: 0x060088C9 RID: 35017 RVA: 0x00240CC0 File Offset: 0x0023EEC0
	[NullableContext(2)]
	public ExploreAreaData GetJumpExploreInfo()
	{
		if (this.ExploreInfo == null)
		{
			return null;
		}
		ExploreActivity value = this.ExploreInfo.Value;
		int recommendAreaListLength = value.RecommendAreaListLength;
		if (recommendAreaListLength == 1)
		{
			return ModelBase<ExploreProgressModel>.Instance.GetExploreAreaData(value.RecommendAreaList(0));
		}
		ExploreAreaData exploreAreaData = null;
		for (int i = 0; i < recommendAreaListLength; i++)
		{
			int areaId = value.RecommendAreaList(i);
			ExploreAreaData exploreAreaData2 = ModelBase<ExploreProgressModel>.Instance.GetExploreAreaData(areaId);
			if (exploreAreaData2 != null && (exploreAreaData == null || exploreAreaData2.GetProgress() < exploreAreaData.GetProgress()))
			{
				exploreAreaData = exploreAreaData2;
			}
		}
		return exploreAreaData;
	}

	// Token: 0x060088CA RID: 35018 RVA: 0x00240D48 File Offset: 0x0023EF48
	protected override UniTask OnBeforeStartAsync()
	{
		ActivitySubViewMapExplore.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ActivitySubViewMapExplore.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060088CB RID: 35019 RVA: 0x00240D8B File Offset: 0x0023EF8B
	[NullableContext(1)]
	private ActivitySubMapExploreItem CreateItem()
	{
		return new ActivitySubMapExploreItem
		{
			GetRewardCallBack = new Action<IActivitySubMapExploreItemData>(this.OnGetReward)
		};
	}

	// Token: 0x060088CC RID: 35020 RVA: 0x00240DA4 File Offset: 0x0023EFA4
	[NullableContext(1)]
	private void OnGetReward(IActivitySubMapExploreItemData data)
	{
		ActivityMapExploreController activityMapExploreController = ActivityManager.GetActivityController(this.ActivityBaseData.Type) as ActivityMapExploreController;
		if (activityMapExploreController != null)
		{
			activityMapExploreController.RequestGetReward(data.TaskId);
		}
	}

	// Token: 0x060088CD RID: 35021 RVA: 0x00240DD8 File Offset: 0x0023EFD8
	protected override void OnStart()
	{
		ActivityMapExploreData activityMapExploreData = this.ActivityBaseData as ActivityMapExploreData;
		if (activityMapExploreData != null && activityMapExploreData.IsFirstUnlockState(EActivityExploreFirstUnlockState.Set))
		{
			activityMapExploreData.SetFirstUnlockState(EActivityExploreFirstUnlockState.Done);
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, activityMapExploreData.Id);
		}
	}

	// Token: 0x060088CE RID: 35022 RVA: 0x00240E1A File Offset: 0x0023F01A
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.ActivityMapExploreStateUpdate, new Action(this.OnActivityMapExploreStateUpdate));
	}

	// Token: 0x060088CF RID: 35023 RVA: 0x00240E38 File Offset: 0x0023F038
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.ActivityMapExploreStateUpdate, new Action(this.OnActivityMapExploreStateUpdate));
	}

	// Token: 0x060088D0 RID: 35024 RVA: 0x00240E58 File Offset: 0x0023F058
	protected override void OnRefreshView()
	{
		this.UpdateTaskList();
		ActivityMapExploreData activityMapExploreData = this.ActivityBaseData as ActivityMapExploreData;
		if (activityMapExploreData == null)
		{
			return;
		}
		this.ExploreInfo = ConfigBase<ActivityMapExploreConfig>.Instance.GetActivityInfo(activityMapExploreData.Id);
		if (this.ExploreInfo == null)
		{
			return;
		}
		ExploreActivity value = this.ExploreInfo.Value;
		string percentDesc = value.PercentDesc;
		string areaTitle = value.AreaTitle;
		bool flag = !string.IsNullOrEmpty(percentDesc) && !string.IsNullOrEmpty(areaTitle);
		UUIText text = base.GetText(0);
		UUIText text2 = base.GetText(1);
		UUIText text3 = base.GetText(2);
		if (flag)
		{
			int areaId = (value.RecommendAreaListLength > 0) ? value.RecommendAreaList(0) : 0;
			string multiTextByKey = ConfigBase<TextConfig>.Instance.GetMultiTextByKey(percentDesc ?? "", percentDesc ?? "");
			text.SetText(multiTextByKey, true);
			ExploreAreaData exploreAreaData = ModelBase<ExploreProgressModel>.Instance.GetExploreAreaData(areaId);
			int value2 = (exploreAreaData != null) ? exploreAreaData.GetProgress() : 0;
			UUIText uuitext = text2;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
			defaultInterpolatedStringHandler.AppendFormatted<int>(value2);
			defaultInterpolatedStringHandler.AppendLiteral("%");
			uuitext.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text3, areaTitle ?? "", Array.Empty<object>());
		}
		text.SetUIActive(flag);
		text2.SetUIActive(flag);
		text3.SetUIActive(flag);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), value.MainTitle ?? "", Array.Empty<object>());
		this.UpdateRemainTime();
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(6), value.Desc ?? "", Array.Empty<object>());
		base.GetText(8).SetText(value.SumRewardNum.ToString(), true);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(9), value.SumRewardDesc ?? "", Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(13), "Activity_Exploration_Go", Array.Empty<object>());
		this.UpdateUnlockedState();
		UUITexture texture = base.GetTexture(16);
		UUITexture texture2 = base.GetTexture(15);
		base.SetTextureShowUntilLoaded(value.Bg ?? "", texture, null);
		base.SetTextureShowUntilLoaded(value.Bg ?? "", texture2, null);
	}

	// Token: 0x060088D1 RID: 35025 RVA: 0x002410B0 File Offset: 0x0023F2B0
	public void UpdateRemainTime()
	{
		if (this.ActivityBaseData == null)
		{
			return;
		}
		ValueTuple<bool, string, long> timeVisibleAndRemainTime = ModelBase<ActivityModel>.Instance.GetTimeVisibleAndRemainTime(this.ActivityBaseData, null);
		bool item = timeVisibleAndRemainTime.Item1;
		string item2 = timeVisibleAndRemainTime.Item2;
		UUIText text = base.GetText(4);
		text.SetText(item2, true);
		text.SetUIActive(item);
	}

	// Token: 0x060088D2 RID: 35026 RVA: 0x002410F9 File Offset: 0x0023F2F9
	protected override void OnTimer(float gap)
	{
		this.UpdateRemainTime();
	}

	// Token: 0x060088D3 RID: 35027 RVA: 0x00241104 File Offset: 0x0023F304
	private void UpdateTaskList()
	{
		ActivityMapExploreData activityMapExploreData = this.ActivityBaseData as ActivityMapExploreData;
		if (activityMapExploreData == null)
		{
			return;
		}
		GenericScrollViewNew<ActivitySubMapExploreItem, IActivitySubMapExploreItemData> itemLayout = this.ItemLayout;
		if (itemLayout != null)
		{
			itemLayout.SelectGridProxy(-1, false);
		}
		GenericScrollViewNew<ActivitySubMapExploreItem, IActivitySubMapExploreItemData> itemLayout2 = this.ItemLayout;
		if (itemLayout2 == null)
		{
			return;
		}
		itemLayout2.RefreshByData(activityMapExploreData.TaskList, null, true);
	}

	// Token: 0x060088D4 RID: 35028 RVA: 0x0024114C File Offset: 0x0023F34C
	private void UpdateUnlockedState()
	{
		ActivityMapExploreData activityMapExploreData = this.ActivityBaseData as ActivityMapExploreData;
		if (activityMapExploreData == null || this.PanelLock == null)
		{
			return;
		}
		bool flag = activityMapExploreData.CanPreOpen();
		this.PanelLock.SetUiActive(!flag);
		base.GetButton(12).RootUIComp.Get().SetUIActive(flag);
		if (flag)
		{
			return;
		}
		this.PanelLock.SetButtonVisible(true);
		bool flag2 = activityMapExploreData.HasPreOpenCondition();
		int preOpenConditionGroupId = activityMapExploreData.PreOpenConditionGroupId;
		int num = flag2 ? preOpenConditionGroupId : activityMapExploreData.ConditionGroupId;
		if (num != 0)
		{
			string conditionGroupHintText = LevelGeneralCommons.GetConditionGroupHintText(num);
			if (!string.IsNullOrEmpty(conditionGroupHintText))
			{
				this.PanelLock.SetTextByTextId(conditionGroupHintText, Array.Empty<string>());
			}
		}
	}

	// Token: 0x060088D5 RID: 35029 RVA: 0x002411F2 File Offset: 0x0023F3F2
	private void OnActivityMapExploreStateUpdate()
	{
		this.UpdateTaskList();
	}

	// Token: 0x0400403D RID: 16445
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericScrollViewNew<ActivitySubMapExploreItem, IActivitySubMapExploreItemData> ItemLayout;

	// Token: 0x0400403E RID: 16446
	[Nullable(2)]
	private FunctionalPanelConditionLock PanelLock;

	// Token: 0x0400403F RID: 16447
	private ExploreActivity? ExploreInfo;

	// Token: 0x02007721 RID: 30497
	private class EChildType
	{
		// Token: 0x0402905D RID: 168029
		public const int TxtLeftTitle = 0;

		// Token: 0x0402905E RID: 168030
		public const int TxtProgress = 1;

		// Token: 0x0402905F RID: 168031
		public const int TxtAreaName = 2;

		// Token: 0x04029060 RID: 168032
		public const int TxtMainTitle = 3;

		// Token: 0x04029061 RID: 168033
		public const int TxtRemainTime = 4;

		// Token: 0x04029062 RID: 168034
		public const int ItemDescRoot = 5;

		// Token: 0x04029063 RID: 168035
		public const int TxtDesc = 6;

		// Token: 0x04029064 RID: 168036
		public const int ItemRewardTitleRoot = 7;

		// Token: 0x04029065 RID: 168037
		public const int TxtRewardNum = 8;

		// Token: 0x04029066 RID: 168038
		public const int TxtRewardDesc = 9;

		// Token: 0x04029067 RID: 168039
		public const int ScrollBarReward = 10;

		// Token: 0x04029068 RID: 168040
		public const int ItemReward = 11;

		// Token: 0x04029069 RID: 168041
		public const int BtnJump = 12;

		// Token: 0x0402906A RID: 168042
		public const int TxtJumpDesc = 13;

		// Token: 0x0402906B RID: 168043
		public const int ItemUnlocked = 14;

		// Token: 0x0402906C RID: 168044
		public const int TextureLeftBg = 15;

		// Token: 0x0402906D RID: 168045
		public const int TextureLeftBgAni = 16;
	}
}
