using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.WorldMap;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x02006780 RID: 26496
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Controller(0)]
	public class ActivityFishingController : ActivityControllerBase<ActivityFishingController>
	{
		// Token: 0x060420C9 RID: 270537 RVA: 0x010F261C File Offset: 0x010F081C
		protected override bool OnGetIsOpeningActivityRelativeView()
		{
			return false;
		}

		// Token: 0x060420CA RID: 270538 RVA: 0x010F2620 File Offset: 0x010F0820
		protected override void OnOpenView(ActivityBaseData data)
		{
			if (ModelBase<GameModeModel>.Instance.IsMulti)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("CantUseInMultiplayerMode", Array.Empty<object>());
				return;
			}
			if (!data.GetPreGuideQuestFinishState())
			{
				int unFinishPreGuideQuestId = data.GetUnFinishPreGuideQuestId();
				Singleton<UiManager>.Instance.OpenView(EUiViewName.QuestView, unFinishPreGuideQuestId, null);
				return;
			}
			int num = ModelBase<FishingModel>.Instance.GetShipData().GetLastPortId();
			if (num <= 0)
			{
				num = 1;
			}
			FishingPort fishingPortConfig = ConfigBase<FishingConfig>.Instance.GetFishingPortConfig(num);
			ControllerBase<WorldMapController>.Instance.FocalMarkItem(EMarkType.FishingDock, fishingPortConfig.MarkId);
		}

		// Token: 0x060420CB RID: 270539 RVA: 0x010F26A9 File Offset: 0x010F08A9
		protected override string OnGetActivityResource(ActivityBaseData data)
		{
			return "UiItem_FishingActivity";
		}

		// Token: 0x060420CC RID: 270540 RVA: 0x010F26B0 File Offset: 0x010F08B0
		protected override ActivitySubViewBase OnCreateSubPageComponent(ActivityBaseData data)
		{
			return new ActivityFishingSubView();
		}

		// Token: 0x060420CD RID: 270541 RVA: 0x010F26B7 File Offset: 0x010F08B7
		protected override ActivityBaseData OnCreateActivityData(ActivityData data)
		{
			return new ActivityFishingData();
		}

		// Token: 0x060420CE RID: 270542 RVA: 0x010F26BE File Offset: 0x010F08BE
		public override void OnShowActivityFirstUnlockView(ActivityBaseData data)
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.FishingActivityUnlockView, null, null);
		}

		// Token: 0x060420CF RID: 270543 RVA: 0x010F26D4 File Offset: 0x010F08D4
		protected override void OnAddEvents()
		{
			EventSystem instance = Singleton<EventSystem>.Instance;
			EEventName name = EEventName.FishingRefreshHandBookRewardView;
			Action handle;
			if ((handle = ActivityFishingController.<>O.<0>__OnRefreshRedDot) == null)
			{
				handle = (ActivityFishingController.<>O.<0>__OnRefreshRedDot = new Action(ActivityFishingController.OnRefreshRedDot));
			}
			instance.Add(name, handle);
			EventSystem instance2 = Singleton<EventSystem>.Instance;
			EEventName name2 = EEventName.UnLockGoods;
			Action<IReadOnlyDictionary<int, HashSet<int>>> handle2;
			if ((handle2 = ActivityFishingController.<>O.<1>__OnUnlockGoods) == null)
			{
				handle2 = (ActivityFishingController.<>O.<1>__OnUnlockGoods = new Action<IReadOnlyDictionary<int, HashSet<int>>>(ActivityFishingController.OnUnlockGoods));
			}
			instance2.Add<IReadOnlyDictionary<int, HashSet<int>>>(name2, handle2);
		}

		// Token: 0x060420D0 RID: 270544 RVA: 0x010F2738 File Offset: 0x010F0938
		protected override void OnRemoveEvents()
		{
			EventSystem instance = Singleton<EventSystem>.Instance;
			EEventName name = EEventName.FishingRefreshHandBookRewardView;
			Action handle;
			if ((handle = ActivityFishingController.<>O.<0>__OnRefreshRedDot) == null)
			{
				handle = (ActivityFishingController.<>O.<0>__OnRefreshRedDot = new Action(ActivityFishingController.OnRefreshRedDot));
			}
			instance.Remove(name, handle);
			EventSystem instance2 = Singleton<EventSystem>.Instance;
			EEventName name2 = EEventName.UnLockGoods;
			Action<IReadOnlyDictionary<int, HashSet<int>>> handle2;
			if ((handle2 = ActivityFishingController.<>O.<1>__OnUnlockGoods) == null)
			{
				handle2 = (ActivityFishingController.<>O.<1>__OnUnlockGoods = new Action<IReadOnlyDictionary<int, HashSet<int>>>(ActivityFishingController.OnUnlockGoods));
			}
			instance2.Remove(name2, handle2);
		}

		// Token: 0x060420D1 RID: 270545 RVA: 0x010F279C File Offset: 0x010F099C
		protected override void OnRegisterNetEvent()
		{
			Net instance = Singleton<Net>.Instance;
			ENotifyMessageId id = ENotifyMessageId.FishingActivityLimitTaskNotify;
			Action<FishingActivityLimitTaskNotify, Net.CallbackStatus> callback;
			if ((callback = ActivityFishingController.<>O.<2>__OnFishingActivityLimitTaskNotify) == null)
			{
				callback = (ActivityFishingController.<>O.<2>__OnFishingActivityLimitTaskNotify = new Action<FishingActivityLimitTaskNotify, Net.CallbackStatus>(ActivityFishingController.OnFishingActivityLimitTaskNotify));
			}
			instance.Register<FishingActivityLimitTaskNotify>(id, callback);
			Net instance2 = Singleton<Net>.Instance;
			ENotifyMessageId id2 = ENotifyMessageId.FishingActivityMileStoneNotify;
			Action<FishingActivityMileStoneNotify, Net.CallbackStatus> callback2;
			if ((callback2 = ActivityFishingController.<>O.<3>__OnFishingActivityMileStoneNotify) == null)
			{
				callback2 = (ActivityFishingController.<>O.<3>__OnFishingActivityMileStoneNotify = new Action<FishingActivityMileStoneNotify, Net.CallbackStatus>(ActivityFishingController.OnFishingActivityMileStoneNotify));
			}
			instance2.Register<FishingActivityMileStoneNotify>(id2, callback2);
			Net instance3 = Singleton<Net>.Instance;
			ENotifyMessageId id3 = ENotifyMessageId.FishingActivityMilestoneItemNumNotify;
			Action<FishingActivityMilestoneItemNumNotify, Net.CallbackStatus> callback3;
			if ((callback3 = ActivityFishingController.<>O.<4>__OnFishingActivityMilestoneItemNumNotify) == null)
			{
				callback3 = (ActivityFishingController.<>O.<4>__OnFishingActivityMilestoneItemNumNotify = new Action<FishingActivityMilestoneItemNumNotify, Net.CallbackStatus>(ActivityFishingController.OnFishingActivityMilestoneItemNumNotify));
			}
			instance3.Register<FishingActivityMilestoneItemNumNotify>(id3, callback3);
		}

		// Token: 0x060420D2 RID: 270546 RVA: 0x010F282A File Offset: 0x010F0A2A
		protected override void OnUnRegisterNetEvent()
		{
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.FishingActivityLimitTaskNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.FishingActivityMileStoneNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.FishingActivityMilestoneItemNumNotify);
		}

		// Token: 0x060420D3 RID: 270547 RVA: 0x010F285C File Offset: 0x010F0A5C
		public static ActivityFishingData GetCurrentActivityData()
		{
			List<ActivityBaseData> currentActivitiesByType = ModelBase<ActivityModel>.Instance.GetCurrentActivitiesByType(ActivityType.FishingActivity);
			ActivityFishingData result = null;
			if (currentActivitiesByType != null)
			{
				foreach (ActivityBaseData activityBaseData in currentActivitiesByType)
				{
					result = (activityBaseData as ActivityFishingData);
				}
			}
			return result;
		}

		// Token: 0x060420D4 RID: 270548 RVA: 0x010F28BC File Offset: 0x010F0ABC
		private static void OnFishingActivityLimitTaskNotify(FishingActivityLimitTaskNotify message, [Nullable(2)] Net.CallbackStatus _)
		{
			ActivityFishingData currentActivityData = ActivityFishingController.GetCurrentActivityData();
			if (currentActivityData == null)
			{
				return;
			}
			currentActivityData.RefreshLimitTimeTaskDataList(message.ActivityTasks.ToList<ActivityTask>(), true);
			currentActivityData.RefreshActivityRedDotState();
		}

		// Token: 0x060420D5 RID: 270549 RVA: 0x010F28EC File Offset: 0x010F0AEC
		private static void OnFishingActivityMileStoneNotify(FishingActivityMileStoneNotify message, [Nullable(2)] Net.CallbackStatus _)
		{
			ActivityFishingData currentActivityData = ActivityFishingController.GetCurrentActivityData();
			if (currentActivityData == null)
			{
				return;
			}
			currentActivityData.RefreshMilestoneReward(message.MilestoneRewarded, true);
			currentActivityData.RefreshActivityRedDotState();
		}

		// Token: 0x060420D6 RID: 270550 RVA: 0x010F2918 File Offset: 0x010F0B18
		private static void OnFishingActivityMilestoneItemNumNotify(FishingActivityMilestoneItemNumNotify message, [Nullable(2)] Net.CallbackStatus _)
		{
			ActivityFishingData currentActivityData = ActivityFishingController.GetCurrentActivityData();
			if (currentActivityData == null)
			{
				return;
			}
			currentActivityData.MilestoneRewardItemAccumulate = message.MilestoneItemNum;
		}

		// Token: 0x060420D7 RID: 270551 RVA: 0x010F293B File Offset: 0x010F0B3B
		private static void OnUnlockGoods(IReadOnlyDictionary<int, HashSet<int>> payShopMap)
		{
			if (payShopMap.ContainsKey(209))
			{
				ActivityFishingController.OnRefreshRedDot();
			}
		}

		// Token: 0x060420D8 RID: 270552 RVA: 0x010F2950 File Offset: 0x010F0B50
		private static void OnRefreshRedDot()
		{
			ActivityFishingData currentActivityData = ActivityFishingController.GetCurrentActivityData();
			if (currentActivityData == null)
			{
				return;
			}
			currentActivityData.RefreshActivityRedDotState();
		}

		// Token: 0x060420D9 RID: 270553 RVA: 0x010F2970 File Offset: 0x010F0B70
		public static void FishingActivityLimitRewardRequest(int taskId)
		{
			FishingActivityLimitRewardRequest fishingActivityLimitRewardRequest = Aki.Protocol.FishingActivityLimitRewardRequest.Create();
			fishingActivityLimitRewardRequest.TaskId = taskId;
			Singleton<Net>.Instance.Call<FishingActivityLimitRewardResponse>(ERequestMessageId.FishingActivityLimitRewardRequest, fishingActivityLimitRewardRequest, delegate(FishingActivityLimitRewardResponse response, Net.CallbackStatus _)
			{
				if (response == null)
				{
					return;
				}
				if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 15946, null, true, true);
				}
			}, 0);
		}

		// Token: 0x060420DA RID: 270554 RVA: 0x010F29BC File Offset: 0x010F0BBC
		public static void FishingActivityMilestoneRewardRequest(List<int> ids)
		{
			FishingActivityMilestoneRewardRequest fishingActivityMilestoneRewardRequest = Aki.Protocol.FishingActivityMilestoneRewardRequest.Create();
			ActivityFishingData currentActivityData = ActivityFishingController.GetCurrentActivityData();
			if (currentActivityData == null)
			{
				return;
			}
			fishingActivityMilestoneRewardRequest.ActivityId = currentActivityData.Id;
			fishingActivityMilestoneRewardRequest.MilestoneId.AddRange(ids);
			Singleton<Net>.Instance.Call<FishingActivityMilestoneRewardResponse>(ERequestMessageId.FishingActivityMilestoneRewardRequest, fishingActivityMilestoneRewardRequest, delegate(FishingActivityMilestoneRewardResponse response, Net.CallbackStatus _)
			{
				if (response == null)
				{
					return;
				}
				if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 25741, null, true, true);
				}
			}, 0);
		}

		// Token: 0x0200C79F RID: 51103
		[CompilerGenerated]
		private static class <>O
		{
			// Token: 0x0403D755 RID: 251733
			[Nullable(0)]
			public static Action <0>__OnRefreshRedDot;

			// Token: 0x0403D756 RID: 251734
			[Nullable(new byte[]
			{
				0,
				1,
				1
			})]
			public static Action<IReadOnlyDictionary<int, HashSet<int>>> <1>__OnUnlockGoods;

			// Token: 0x0403D757 RID: 251735
			[Nullable(new byte[]
			{
				0,
				1,
				2
			})]
			public static Action<FishingActivityLimitTaskNotify, Net.CallbackStatus> <2>__OnFishingActivityLimitTaskNotify;

			// Token: 0x0403D758 RID: 251736
			[Nullable(new byte[]
			{
				0,
				1,
				2
			})]
			public static Action<FishingActivityMileStoneNotify, Net.CallbackStatus> <3>__OnFishingActivityMileStoneNotify;

			// Token: 0x0403D759 RID: 251737
			[Nullable(new byte[]
			{
				0,
				1,
				2
			})]
			public static Action<FishingActivityMilestoneItemNumNotify, Net.CallbackStatus> <4>__OnFishingActivityMilestoneItemNumNotify;
		}
	}
}
