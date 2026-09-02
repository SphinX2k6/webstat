using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Module.Kurotato.Data;
using CSharpScript.Game.Module.Kurotato.View.Activity;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.Kurotato
{
	// Token: 0x02005A26 RID: 23078
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Controller(0)]
	public class KurotatoActivityController : ActivityControllerBase<KurotatoActivityController>
	{
		// Token: 0x0603A6E6 RID: 239334 RVA: 0x00ED123E File Offset: 0x00ECF43E
		protected override void OnOpenView(ActivityBaseData data)
		{
		}

		// Token: 0x0603A6E7 RID: 239335 RVA: 0x00ED1240 File Offset: 0x00ECF440
		protected override string OnGetActivityResource(ActivityBaseData data)
		{
			return "UiView_ActivitySurvivorMain";
		}

		// Token: 0x0603A6E8 RID: 239336 RVA: 0x00ED1247 File Offset: 0x00ECF447
		protected override ActivitySubViewBase OnCreateSubPageComponent(ActivityBaseData data)
		{
			return new ActivitySubViewKurotato();
		}

		// Token: 0x0603A6E9 RID: 239337 RVA: 0x00ED1250 File Offset: 0x00ECF450
		protected override ActivityBaseData OnCreateActivityData(ActivityData data)
		{
			CSharpScript.Game.Module.Kurotato.Data.KurotatoActivityData kurotatoActivityData = new CSharpScript.Game.Module.Kurotato.Data.KurotatoActivityData();
			this.ActivityData = kurotatoActivityData;
			return kurotatoActivityData;
		}

		// Token: 0x0603A6EA RID: 239338 RVA: 0x00ED126C File Offset: 0x00ECF46C
		protected override bool OnGetIsOpeningActivityRelativeView()
		{
			EUiViewName[] array = new EUiViewName[]
			{
				EUiViewName.KurotatoMainView,
				EUiViewName.KurotatoLimitedTimeRewardView
			};
			for (int i = 0; i < array.Length; i++)
			{
				if (Singleton<UiManager>.Instance.IsViewOpen(array[i]))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0603A6EB RID: 239339 RVA: 0x00ED12BC File Offset: 0x00ECF4BC
		[NullableContext(2)]
		public CSharpScript.Game.Module.Kurotato.Data.KurotatoActivityData GetActivityData()
		{
			if (this.ActivityData == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.Kurotato, ELogAuthor.CXJ, "Kurotato活动数据不存在", default(ReadOnlySpan<ValueTuple<string, object>>));
				return null;
			}
			return this.ActivityData;
		}

		// Token: 0x0603A6EC RID: 239340 RVA: 0x00ED12F8 File Offset: 0x00ECF4F8
		[NullableContext(0)]
		protected override UniTask<bool> OnOpenSubView(EUiViewName viewName, int activityId = 0)
		{
			KurotatoActivityController.<OnOpenSubView>d__7 <OnOpenSubView>d__;
			<OnOpenSubView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<OnOpenSubView>d__.<>4__this = this;
			<OnOpenSubView>d__.viewName = viewName;
			<OnOpenSubView>d__.<>1__state = -1;
			<OnOpenSubView>d__.<>t__builder.Start<KurotatoActivityController.<OnOpenSubView>d__7>(ref <OnOpenSubView>d__);
			return <OnOpenSubView>d__.<>t__builder.Task;
		}

		// Token: 0x0603A6ED RID: 239341 RVA: 0x00ED1344 File Offset: 0x00ECF544
		protected override void OnRegisterNetEvent()
		{
			Singleton<Net>.Instance.Register<KurotatoRoleUnlockNotify>(ENotifyMessageId.KurotatoRoleUnlockNotify, new Action<KurotatoRoleUnlockNotify, Net.CallbackStatus>(this.OnKurotatoRoleUnlockNotify));
			Singleton<Net>.Instance.Register<KurotatoLevelDataUpdateNotify>(ENotifyMessageId.KurotatoLevelDataUpdateNotify, new Action<KurotatoLevelDataUpdateNotify, Net.CallbackStatus>(this.OnKurotatoLevelDataUpdateNotify));
			Singleton<Net>.Instance.Register<KurotatoWeaponUnlockNotify>(ENotifyMessageId.KurotatoWeaponUnlockNotify, new Action<KurotatoWeaponUnlockNotify, Net.CallbackStatus>(this.OnKurotatoWeaponUnlockNotify));
			Singleton<Net>.Instance.Register<KurotatoItemUnlockNotify>(ENotifyMessageId.KurotatoItemUnlockNotify, new Action<KurotatoItemUnlockNotify, Net.CallbackStatus>(this.OnKurotatoItemUnlockNotify));
			Singleton<Net>.Instance.Register<KurotatoResTaskUpdateNotify>(ENotifyMessageId.KurotatoResTaskUpdateNotify, new Action<KurotatoResTaskUpdateNotify, Net.CallbackStatus>(this.OnKurotatoNormalRewardUpdateNotify));
			Singleton<Net>.Instance.Register<KurotatoLimitTaskUpdateNotify>(ENotifyMessageId.KurotatoLimitTaskUpdateNotify, new Action<KurotatoLimitTaskUpdateNotify, Net.CallbackStatus>(this.OnKurotatoLimitTimeRewardUpdateNotify));
		}

		// Token: 0x0603A6EE RID: 239342 RVA: 0x00ED13FC File Offset: 0x00ECF5FC
		protected override void OnUnRegisterNetEvent()
		{
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.KurotatoRoleUnlockNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.KurotatoLevelDataUpdateNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.KurotatoWeaponUnlockNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.KurotatoItemUnlockNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.KurotatoResTaskUpdateNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.KurotatoLimitTaskUpdateNotify);
		}

		// Token: 0x0603A6EF RID: 239343 RVA: 0x00ED146C File Offset: 0x00ECF66C
		private void OnKurotatoRoleUnlockNotify(KurotatoRoleUnlockNotify notify, [Nullable(2)] Net.CallbackStatus status)
		{
			CSharpScript.Game.Module.Kurotato.Data.KurotatoActivityData activityData = this.GetActivityData();
			if (activityData == null)
			{
				return;
			}
			activityData.UpdateRoleData(notify.KurotatoRoleInfos, true);
		}

		// Token: 0x0603A6F0 RID: 239344 RVA: 0x00ED1494 File Offset: 0x00ECF694
		private void OnKurotatoLevelDataUpdateNotify(KurotatoLevelDataUpdateNotify notify, [Nullable(2)] Net.CallbackStatus status)
		{
			CSharpScript.Game.Module.Kurotato.Data.KurotatoActivityData activityData = this.GetActivityData();
			if (activityData == null)
			{
				return;
			}
			activityData.UpdateLevelData(notify.KurotatoLevelInfos, true);
		}

		// Token: 0x0603A6F1 RID: 239345 RVA: 0x00ED14BC File Offset: 0x00ECF6BC
		private void OnKurotatoWeaponUnlockNotify(KurotatoWeaponUnlockNotify notify, [Nullable(2)] Net.CallbackStatus status)
		{
			CSharpScript.Game.Module.Kurotato.Data.KurotatoActivityData activityData = this.GetActivityData();
			if (activityData == null)
			{
				return;
			}
			activityData.UpdateKurotatoWeaponDataList(notify.UnlockWeapons, true);
		}

		// Token: 0x0603A6F2 RID: 239346 RVA: 0x00ED14E4 File Offset: 0x00ECF6E4
		private void OnKurotatoItemUnlockNotify(KurotatoItemUnlockNotify notify, [Nullable(2)] Net.CallbackStatus status)
		{
			CSharpScript.Game.Module.Kurotato.Data.KurotatoActivityData activityData = this.GetActivityData();
			if (activityData == null)
			{
				return;
			}
			activityData.UpdateKurotatoItemDataList(notify.UnlockItems, true);
		}

		// Token: 0x0603A6F3 RID: 239347 RVA: 0x00ED150C File Offset: 0x00ECF70C
		private void OnKurotatoNormalRewardUpdateNotify(KurotatoResTaskUpdateNotify notify, [Nullable(2)] Net.CallbackStatus status)
		{
			CSharpScript.Game.Module.Kurotato.Data.KurotatoActivityData activityData = this.GetActivityData();
			if (activityData == null)
			{
				return;
			}
			activityData.UpdateNormalRewardData(notify.ResTasks);
		}

		// Token: 0x0603A6F4 RID: 239348 RVA: 0x00ED1530 File Offset: 0x00ECF730
		private void OnKurotatoLimitTimeRewardUpdateNotify(KurotatoLimitTaskUpdateNotify notify, [Nullable(2)] Net.CallbackStatus status)
		{
			CSharpScript.Game.Module.Kurotato.Data.KurotatoActivityData activityData = this.GetActivityData();
			if (activityData == null)
			{
				return;
			}
			activityData.UpdateLimitTimeRewardData(notify.LimitTasks);
		}

		// Token: 0x0603A6F5 RID: 239349 RVA: 0x00ED1554 File Offset: 0x00ECF754
		public void RequestNormalReward(List<int> taskIds)
		{
			KurotatoResTaskReceiveRequest kurotatoResTaskReceiveRequest = KurotatoResTaskReceiveRequest.Create();
			kurotatoResTaskReceiveRequest.TaskIds.AddRange(taskIds);
			Singleton<Net>.Instance.Call<KurotatoResTaskReceiveResponse>(ERequestMessageId.KurotatoResTaskReceiveRequest, kurotatoResTaskReceiveRequest, delegate(KurotatoResTaskReceiveResponse response, Net.CallbackStatus _)
			{
				if (response == null)
				{
					return;
				}
				if (response.ErrorCode != ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, EResponseMessageId.KurotatoResTaskReceiveResponse, null, true, true);
					return;
				}
				CSharpScript.Game.Module.Kurotato.Data.KurotatoActivityData activityData = this.GetActivityData();
				if (activityData == null)
				{
					return;
				}
				activityData.SetNormalRewardReceived(taskIds);
			}, 0);
		}

		// Token: 0x0603A6F6 RID: 239350 RVA: 0x00ED15AC File Offset: 0x00ECF7AC
		public void RequestLimitTimeReward(List<int> taskIds, [Nullable(2)] Action finishCallback)
		{
			KurotatoLimitTaskReceiveRequest kurotatoLimitTaskReceiveRequest = KurotatoLimitTaskReceiveRequest.Create();
			kurotatoLimitTaskReceiveRequest.TaskIds.AddRange(taskIds);
			Singleton<Net>.Instance.Call<KurotatoLimitTaskReceiveResponse>(ERequestMessageId.KurotatoLimitTaskReceiveRequest, kurotatoLimitTaskReceiveRequest, delegate(KurotatoLimitTaskReceiveResponse response, Net.CallbackStatus _)
			{
				if (response == null)
				{
					return;
				}
				if (response.ErrorCode != ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, EResponseMessageId.KurotatoLimitTaskReceiveResponse, null, true, true);
				}
				CSharpScript.Game.Module.Kurotato.Data.KurotatoActivityData activityData = this.GetActivityData();
				if (activityData == null)
				{
					return;
				}
				activityData.SetLimitTimeRewardReceived(taskIds);
				Action finishCallback2 = finishCallback;
				if (finishCallback2 == null)
				{
					return;
				}
				finishCallback2();
			}, 0);
		}

		// Token: 0x0603A6F7 RID: 239351 RVA: 0x00ED1608 File Offset: 0x00ECF808
		[NullableContext(2)]
		public void RequestScoreRewardReceive(Action finishCallback)
		{
			KurotatoScoreTaskReceiveRequest kurotatoScoreTaskReceiveRequest = KurotatoScoreTaskReceiveRequest.Create();
			CSharpScript.Game.Module.Kurotato.Data.KurotatoActivityData activityData = this.GetActivityData();
			if (activityData == null)
			{
				return;
			}
			List<int> canClaimedScoreIdList = activityData.GetCanClaimedScoreRewardList();
			kurotatoScoreTaskReceiveRequest.TaskIds.AddRange(canClaimedScoreIdList);
			Singleton<Net>.Instance.Call<KurotatoScoreTaskReceiveResponse>(ERequestMessageId.KurotatoScoreTaskReceiveRequest, kurotatoScoreTaskReceiveRequest, delegate(KurotatoScoreTaskReceiveResponse response, Net.CallbackStatus _)
			{
				if (response == null)
				{
					return;
				}
				if (response.ErrorCode != ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, EResponseMessageId.KurotatoScoreTaskReceiveResponse, null, true, true);
					return;
				}
				activityData.SetScoreRewardReceived(canClaimedScoreIdList);
				Action finishCallback2 = finishCallback;
				if (finishCallback2 == null)
				{
					return;
				}
				finishCallback2();
			}, 0);
		}

		// Token: 0x0603A6F8 RID: 239352 RVA: 0x00ED167C File Offset: 0x00ECF87C
		public override void OnShowActivityFirstUnlockView(ActivityBaseData data)
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.KurotatoActivityOpenView, null, null);
		}

		// Token: 0x04021170 RID: 135536
		[Nullable(2)]
		private CSharpScript.Game.Module.Kurotato.Data.KurotatoActivityData ActivityData;
	}
}
