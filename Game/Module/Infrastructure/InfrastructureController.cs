using System;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.Infrastructure
{
	// Token: 0x02005C4B RID: 23627
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Controller(0)]
	public class InfrastructureController : ActivityControllerBase<InfrastructureController>
	{
		// Token: 0x0603BAD7 RID: 244439 RVA: 0x00F1E020 File Offset: 0x00F1C220
		protected override void OnOpenView(ActivityBaseData data)
		{
		}

		// Token: 0x0603BAD8 RID: 244440 RVA: 0x00F1E022 File Offset: 0x00F1C222
		protected override string OnGetActivityResource(ActivityBaseData data)
		{
			return "UiItem_InfrastructureActivityMain";
		}

		// Token: 0x0603BAD9 RID: 244441 RVA: 0x00F1E029 File Offset: 0x00F1C229
		protected override ActivitySubViewBase OnCreateSubPageComponent(ActivityBaseData data)
		{
			return new InfrActivityMainView();
		}

		// Token: 0x0603BADA RID: 244442 RVA: 0x00F1E030 File Offset: 0x00F1C230
		protected override bool OnGetIsOpeningActivityRelativeView()
		{
			foreach (EUiViewName viewName in new EUiViewName[]
			{
				EUiViewName.InfrLimitTaskMainView
			})
			{
				if (Singleton<UiManager>.Instance.IsViewOpen(viewName))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0603BADB RID: 244443 RVA: 0x00F1E078 File Offset: 0x00F1C278
		protected override ActivityBaseData OnCreateActivityData(ActivityData data)
		{
			InfrastructureActivityData infrastructureActivityData = new InfrastructureActivityData();
			ModelBase<InfrastructureModel>.Instance.SetActivityData(infrastructureActivityData);
			return infrastructureActivityData;
		}

		// Token: 0x0603BADC RID: 244444 RVA: 0x00F1E098 File Offset: 0x00F1C298
		protected override void OnRegisterNetEvent()
		{
			Singleton<Net>.Instance.Register<InfrFireAddNotify>(ENotifyMessageId.InfrFireAddNotify, new Action<InfrFireAddNotify, Net.CallbackStatus>(this.OnInfrFireAddNotify));
			Singleton<Net>.Instance.Register<InfrFireUpdateNotify>(ENotifyMessageId.InfrFireUpdateNotify, new Action<InfrFireUpdateNotify, Net.CallbackStatus>(this.OnInfrFireUpdateNotify));
			Singleton<Net>.Instance.Register<InfrRoadUpdateNotify>(ENotifyMessageId.InfrRoadUpdateNotify, new Action<InfrRoadUpdateNotify, Net.CallbackStatus>(this.OnInfrRoadUpdateNotify));
			Singleton<Net>.Instance.Register<InfrLibraryTaskUpdateNotify>(ENotifyMessageId.InfrLibraryTaskUpdateNotify, new Action<InfrLibraryTaskUpdateNotify, Net.CallbackStatus>(this.OnInfrLibraryTaskUpdateNotify));
			Singleton<Net>.Instance.Register<FireShopCoinNotify>(ENotifyMessageId.FireShopCoinNotify, new Action<FireShopCoinNotify, Net.CallbackStatus>(this.OnFireShopCoinNotify));
			Singleton<Net>.Instance.Register<InfrThemeActivityTaskDataUpdateNotify>(ENotifyMessageId.InfrThemeActivityTaskDataUpdateNotify, new Action<InfrThemeActivityTaskDataUpdateNotify, Net.CallbackStatus>(this.OnInfrThemeActivityTaskDataUpdateNotify));
		}

		// Token: 0x0603BADD RID: 244445 RVA: 0x00F1E150 File Offset: 0x00F1C350
		protected override void OnUnRegisterNetEvent()
		{
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.InfrFireAddNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.InfrFireUpdateNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.InfrRoadUpdateNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.InfrLibraryTaskUpdateNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.FireShopCoinNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.InfrThemeActivityTaskDataUpdateNotify);
		}

		// Token: 0x0603BADE RID: 244446 RVA: 0x00F1E1C0 File Offset: 0x00F1C3C0
		[NullableContext(0)]
		public UniTask<bool> RequestInfrastructureInfoRequest()
		{
			InfrastructureController.<RequestInfrastructureInfoRequest>d__7 <RequestInfrastructureInfoRequest>d__;
			<RequestInfrastructureInfoRequest>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<RequestInfrastructureInfoRequest>d__.<>1__state = -1;
			<RequestInfrastructureInfoRequest>d__.<>t__builder.Start<InfrastructureController.<RequestInfrastructureInfoRequest>d__7>(ref <RequestInfrastructureInfoRequest>d__);
			return <RequestInfrastructureInfoRequest>d__.<>t__builder.Task;
		}

		// Token: 0x0603BADF RID: 244447 RVA: 0x00F1E1FC File Offset: 0x00F1C3FC
		[NullableContext(0)]
		public UniTask<bool> RequestInfrastructureArchiveTaskReward()
		{
			InfrastructureController.<RequestInfrastructureArchiveTaskReward>d__8 <RequestInfrastructureArchiveTaskReward>d__;
			<RequestInfrastructureArchiveTaskReward>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<RequestInfrastructureArchiveTaskReward>d__.<>1__state = -1;
			<RequestInfrastructureArchiveTaskReward>d__.<>t__builder.Start<InfrastructureController.<RequestInfrastructureArchiveTaskReward>d__8>(ref <RequestInfrastructureArchiveTaskReward>d__);
			return <RequestInfrastructureArchiveTaskReward>d__.<>t__builder.Task;
		}

		// Token: 0x0603BAE0 RID: 244448 RVA: 0x00F1E238 File Offset: 0x00F1C438
		[NullableContext(0)]
		public UniTask<bool> RequestInfrastructurePhoneTaskReward()
		{
			InfrastructureController.<RequestInfrastructurePhoneTaskReward>d__9 <RequestInfrastructurePhoneTaskReward>d__;
			<RequestInfrastructurePhoneTaskReward>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<RequestInfrastructurePhoneTaskReward>d__.<>1__state = -1;
			<RequestInfrastructurePhoneTaskReward>d__.<>t__builder.Start<InfrastructureController.<RequestInfrastructurePhoneTaskReward>d__9>(ref <RequestInfrastructurePhoneTaskReward>d__);
			return <RequestInfrastructurePhoneTaskReward>d__.<>t__builder.Task;
		}

		// Token: 0x0603BAE1 RID: 244449 RVA: 0x00F1E274 File Offset: 0x00F1C474
		[NullableContext(0)]
		public UniTask<bool> RequestInfrastructureLevelUp()
		{
			InfrastructureController.<RequestInfrastructureLevelUp>d__10 <RequestInfrastructureLevelUp>d__;
			<RequestInfrastructureLevelUp>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<RequestInfrastructureLevelUp>d__.<>1__state = -1;
			<RequestInfrastructureLevelUp>d__.<>t__builder.Start<InfrastructureController.<RequestInfrastructureLevelUp>d__10>(ref <RequestInfrastructureLevelUp>d__);
			return <RequestInfrastructureLevelUp>d__.<>t__builder.Task;
		}

		// Token: 0x0603BAE2 RID: 244450 RVA: 0x00F1E2B0 File Offset: 0x00F1C4B0
		[NullableContext(0)]
		public UniTask<bool> RequestInfrastructureRoadBuild(int roadId)
		{
			InfrastructureController.<RequestInfrastructureRoadBuild>d__11 <RequestInfrastructureRoadBuild>d__;
			<RequestInfrastructureRoadBuild>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<RequestInfrastructureRoadBuild>d__.roadId = roadId;
			<RequestInfrastructureRoadBuild>d__.<>1__state = -1;
			<RequestInfrastructureRoadBuild>d__.<>t__builder.Start<InfrastructureController.<RequestInfrastructureRoadBuild>d__11>(ref <RequestInfrastructureRoadBuild>d__);
			return <RequestInfrastructureRoadBuild>d__.<>t__builder.Task;
		}

		// Token: 0x0603BAE3 RID: 244451 RVA: 0x00F1E2F4 File Offset: 0x00F1C4F4
		[NullableContext(0)]
		public UniTask<bool> RequestInfrastructureManualSwitchTraceRoad(int roadId)
		{
			InfrastructureController.<RequestInfrastructureManualSwitchTraceRoad>d__12 <RequestInfrastructureManualSwitchTraceRoad>d__;
			<RequestInfrastructureManualSwitchTraceRoad>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<RequestInfrastructureManualSwitchTraceRoad>d__.roadId = roadId;
			<RequestInfrastructureManualSwitchTraceRoad>d__.<>1__state = -1;
			<RequestInfrastructureManualSwitchTraceRoad>d__.<>t__builder.Start<InfrastructureController.<RequestInfrastructureManualSwitchTraceRoad>d__12>(ref <RequestInfrastructureManualSwitchTraceRoad>d__);
			return <RequestInfrastructureManualSwitchTraceRoad>d__.<>t__builder.Task;
		}

		// Token: 0x0603BAE4 RID: 244452 RVA: 0x00F1E338 File Offset: 0x00F1C538
		[NullableContext(0)]
		public UniTask<bool> RequestInfrManualCancelTraceRoadRequest()
		{
			InfrastructureController.<RequestInfrManualCancelTraceRoadRequest>d__13 <RequestInfrManualCancelTraceRoadRequest>d__;
			<RequestInfrManualCancelTraceRoadRequest>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<RequestInfrManualCancelTraceRoadRequest>d__.<>1__state = -1;
			<RequestInfrManualCancelTraceRoadRequest>d__.<>t__builder.Start<InfrastructureController.<RequestInfrManualCancelTraceRoadRequest>d__13>(ref <RequestInfrManualCancelTraceRoadRequest>d__);
			return <RequestInfrManualCancelTraceRoadRequest>d__.<>t__builder.Task;
		}

		// Token: 0x0603BAE5 RID: 244453 RVA: 0x00F1E374 File Offset: 0x00F1C574
		[return: Nullable(new byte[]
		{
			0,
			2
		})]
		public UniTask<InfrFireNoticeResponse> RequestInfrastructureFireNotice()
		{
			InfrastructureController.<RequestInfrastructureFireNotice>d__14 <RequestInfrastructureFireNotice>d__;
			<RequestInfrastructureFireNotice>d__.<>t__builder = AsyncUniTaskMethodBuilder<InfrFireNoticeResponse>.Create();
			<RequestInfrastructureFireNotice>d__.<>1__state = -1;
			<RequestInfrastructureFireNotice>d__.<>t__builder.Start<InfrastructureController.<RequestInfrastructureFireNotice>d__14>(ref <RequestInfrastructureFireNotice>d__);
			return <RequestInfrastructureFireNotice>d__.<>t__builder.Task;
		}

		// Token: 0x0603BAE6 RID: 244454 RVA: 0x00F1E3B0 File Offset: 0x00F1C5B0
		[NullableContext(0)]
		public UniTask<bool> RequestInfrArchiveReadRequest([Nullable(1)] int[] archiveIds)
		{
			InfrastructureController.<RequestInfrArchiveReadRequest>d__15 <RequestInfrArchiveReadRequest>d__;
			<RequestInfrArchiveReadRequest>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<RequestInfrArchiveReadRequest>d__.archiveIds = archiveIds;
			<RequestInfrArchiveReadRequest>d__.<>1__state = -1;
			<RequestInfrArchiveReadRequest>d__.<>t__builder.Start<InfrastructureController.<RequestInfrArchiveReadRequest>d__15>(ref <RequestInfrArchiveReadRequest>d__);
			return <RequestInfrArchiveReadRequest>d__.<>t__builder.Task;
		}

		// Token: 0x0603BAE7 RID: 244455 RVA: 0x00F1E3F3 File Offset: 0x00F1C5F3
		private void OnFireShopCoinNotify(FireShopCoinNotify data, [Nullable(2)] Net.CallbackStatus _)
		{
			ModelBase<InfrastructureModel>.Instance.SetFireShopCoinData(data);
		}

		// Token: 0x0603BAE8 RID: 244456 RVA: 0x00F1E400 File Offset: 0x00F1C600
		private void OnInfrThemeActivityTaskDataUpdateNotify(InfrThemeActivityTaskDataUpdateNotify data, [Nullable(2)] Net.CallbackStatus _)
		{
			ModelBase<InfrastructureModel>.Instance.UpdateActivityTaskData(data);
		}

		// Token: 0x0603BAE9 RID: 244457 RVA: 0x00F1E410 File Offset: 0x00F1C610
		[NullableContext(0)]
		public UniTask<bool> RequestInfrLimitTaskRewardRequest(int activityId, [Nullable(1)] int[] taskIds)
		{
			InfrastructureController.<RequestInfrLimitTaskRewardRequest>d__18 <RequestInfrLimitTaskRewardRequest>d__;
			<RequestInfrLimitTaskRewardRequest>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<RequestInfrLimitTaskRewardRequest>d__.taskIds = taskIds;
			<RequestInfrLimitTaskRewardRequest>d__.<>1__state = -1;
			<RequestInfrLimitTaskRewardRequest>d__.<>t__builder.Start<InfrastructureController.<RequestInfrLimitTaskRewardRequest>d__18>(ref <RequestInfrLimitTaskRewardRequest>d__);
			return <RequestInfrLimitTaskRewardRequest>d__.<>t__builder.Task;
		}

		// Token: 0x0603BAEA RID: 244458 RVA: 0x00F1E453 File Offset: 0x00F1C653
		private void OnInfrFireAddNotify(InfrFireAddNotify data, [Nullable(2)] Net.CallbackStatus _)
		{
			ModelBase<InfrastructureModel>.Instance.AddFireLevel(data);
			Singleton<EventSystem>.Instance.Emit<float>(EEventName.InfrastructureFireExpAdd, (float)data.Add);
		}

		// Token: 0x0603BAEB RID: 244459 RVA: 0x00F1E477 File Offset: 0x00F1C677
		private void OnInfrFireUpdateNotify(InfrFireUpdateNotify data, [Nullable(2)] Net.CallbackStatus _)
		{
			ModelBase<InfrastructureModel>.Instance.SetFireData(data.FireInfo);
		}

		// Token: 0x0603BAEC RID: 244460 RVA: 0x00F1E489 File Offset: 0x00F1C689
		private void OnInfrRoadUpdateNotify(InfrRoadUpdateNotify data, [Nullable(2)] Net.CallbackStatus _)
		{
			ModelBase<InfrastructureModel>.Instance.SetRoadData(data.RoadInfo);
		}

		// Token: 0x0603BAED RID: 244461 RVA: 0x00F1E49C File Offset: 0x00F1C69C
		private void OnInfrLibraryTaskUpdateNotify(InfrLibraryTaskUpdateNotify data, [Nullable(2)] Net.CallbackStatus _)
		{
			ModelBase<InfrastructureModel>.Instance.SetArchiveTaskData(data.ArchiveTasks.ToArray<InfrTaskPb>());
			ModelBase<InfrastructureModel>.Instance.SetPhoneTaskData(data.PhoneTasks.ToArray<InfrTaskPb>());
			InfrastructureActivityData activityData = ModelBase<InfrastructureModel>.Instance.GetActivityData();
			if (activityData != null)
			{
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, activityData.Id);
			}
		}

		// Token: 0x0603BAEE RID: 244462 RVA: 0x00F1E4F8 File Offset: 0x00F1C6F8
		public void OpenMaterialDelivery(ActionInfrastructureItemDeliveryType deliveryType, int roadId, int actionId, InfrastructureDefine.EMaterialDeliveryOpenSource openSource)
		{
			InfrastructureDefine.InfrMaterialsDeliveryOpenParam param = new InfrastructureDefine.InfrMaterialsDeliveryOpenParam
			{
				DeliveryType = deliveryType,
				RoadId = roadId,
				ActionId = new int?(actionId),
				OpenSource = openSource
			};
			ModelBase<InfrastructureModel>.Instance.SetInteractingRoadId(roadId);
			Singleton<UiManager>.Instance.OpenView(EUiViewName.InfrMaterialsDeliveryView, param, null);
		}

		// Token: 0x0603BAEF RID: 244463 RVA: 0x00F1E54C File Offset: 0x00F1C74C
		[NullableContext(0)]
		public UniTask<int?> OpenInfrastructureMainView([Nullable(2)] InfrastructureDefine.IInfrMainViewOpenParam param = null)
		{
			InfrastructureController.<OpenInfrastructureMainView>d__24 <OpenInfrastructureMainView>d__;
			<OpenInfrastructureMainView>d__.<>t__builder = AsyncUniTaskMethodBuilder<int?>.Create();
			<OpenInfrastructureMainView>d__.param = param;
			<OpenInfrastructureMainView>d__.<>1__state = -1;
			<OpenInfrastructureMainView>d__.<>t__builder.Start<InfrastructureController.<OpenInfrastructureMainView>d__24>(ref <OpenInfrastructureMainView>d__);
			return <OpenInfrastructureMainView>d__.<>t__builder.Task;
		}

		// Token: 0x0603BAF0 RID: 244464 RVA: 0x00F1E58F File Offset: 0x00F1C78F
		public override void OnShowActivityFirstUnlockView(ActivityBaseData data)
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.InfrOpeningTipsView, null, null);
		}
	}
}
