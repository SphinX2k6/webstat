using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.SkipInterface;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.TotalTopUp
{
	// Token: 0x0200625C RID: 25180
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Controller(0)]
	public class TotalTopUpController : ActivityControllerBase<TotalTopUpController>
	{
		// Token: 0x0603F750 RID: 259920 RVA: 0x01044525 File Offset: 0x01042725
		protected override void OnRegisterNetEvent()
		{
			Singleton<Net>.Instance.Register<TotalTopUpActivityInfoNotify>(ENotifyMessageId.TotalTopUpActivityInfoNotify, new Action<TotalTopUpActivityInfoNotify, Net.CallbackStatus>(this.OnTotalTopUpUpdateNotify));
			Singleton<Net>.Instance.Register<TotalTopUpRewardNotify>(ENotifyMessageId.TotalTopUpRewardNotify, new Action<TotalTopUpRewardNotify, Net.CallbackStatus>(this.OnRewardNotify));
		}

		// Token: 0x0603F751 RID: 259921 RVA: 0x0104455F File Offset: 0x0104275F
		protected override void OnUnRegisterNetEvent()
		{
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.TotalTopUpActivityInfoNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.TotalTopUpRewardNotify);
		}

		// Token: 0x0603F752 RID: 259922 RVA: 0x01044581 File Offset: 0x01042781
		protected override void OnAddEvents()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.OnViewDone, new Action<EUiViewName, UiViewBase>(this.OnShopViewOpen));
		}

		// Token: 0x0603F753 RID: 259923 RVA: 0x0104459C File Offset: 0x0104279C
		protected override void OnRemoveEvents()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnViewDone, new Action<EUiViewName, UiViewBase>(this.OnShopViewOpen));
		}

		// Token: 0x0603F754 RID: 259924 RVA: 0x010445B8 File Offset: 0x010427B8
		private void OnShopViewOpen(EUiViewName viewName, UiViewBase viewBase)
		{
			if (viewName != EUiViewName.PayShopRootView)
			{
				return;
			}
			TotalTopUpData singleActivityData = this.GetSingleActivityData();
			if (singleActivityData == null)
			{
				return;
			}
			singleActivityData.HasRequestedScoreInfo = false;
			TotalTopUpUtil.Debug("商店界面关闭，重置积分信息请求状态", default(ReadOnlySpan<ValueTuple<string, object>>));
		}

		// Token: 0x0603F755 RID: 259925 RVA: 0x010445F8 File Offset: 0x010427F8
		[NullableContext(2)]
		public TotalTopUpData GetSingleActivityData()
		{
			int type = 83;
			List<ActivityBaseData> activitiesByType = ModelBase<ActivityModel>.Instance.GetActivitiesByType(type);
			if (activitiesByType == null || activitiesByType.Count <= 0)
			{
				return null;
			}
			if (activitiesByType.Count > 1)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.ActivityTotalTopUp;
				ELogAuthor author = ELogAuthor.TZJ;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(21, 1);
				defaultInterpolatedStringHandler.AppendLiteral("multiple data found: ");
				defaultInterpolatedStringHandler.AppendFormatted<int>(activitiesByType.Count);
				instance.Error(module, author, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
				return null;
			}
			ActivityBaseData activityBaseData = activitiesByType[0];
			if (activityBaseData == null)
			{
				return null;
			}
			if (!activityBaseData.CheckIfInOpenTime())
			{
				return null;
			}
			return activityBaseData as TotalTopUpData;
		}

		// Token: 0x0603F756 RID: 259926 RVA: 0x01044690 File Offset: 0x01042890
		private void OnTotalTopUpUpdateNotify(TotalTopUpActivityInfoNotify response, [Nullable(2)] Net.CallbackStatus status)
		{
			TotalTopUpUtil.Debug("收到Activity Info Notify", default(ReadOnlySpan<ValueTuple<string, object>>));
			if (response.TotalTopUpActivityInfo == null)
			{
				return;
			}
			TotalTopUpData singleActivityData = this.GetSingleActivityData();
			if (singleActivityData == null)
			{
				return;
			}
			singleActivityData.InitData(response.TotalTopUpActivityInfo, singleActivityData.Id);
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.ActivityViewRefreshCurrent, singleActivityData.Id);
		}

		// Token: 0x0603F757 RID: 259927 RVA: 0x010446EC File Offset: 0x010428EC
		private void OnRewardNotify(TotalTopUpRewardNotify response, [Nullable(2)] Net.CallbackStatus status)
		{
			List<int> list = new List<int>();
			foreach (TotalTopUpRewardInfo totalTopUpRewardInfo in response.TotalTopUpRewardInfo)
			{
				list.Add(totalTopUpRewardInfo.Id);
			}
			string message = "收到奖励通知";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("RewardId", string.Join<int>(",", list));
			TotalTopUpUtil.Debug(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			TotalTopUpData singleActivityData = this.GetSingleActivityData();
			if (singleActivityData == null)
			{
				return;
			}
			singleActivityData.UpdateReward(response.TotalTopUpRewardInfo.ToList<TotalTopUpRewardInfo>());
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.ActivityViewRefreshCurrent, singleActivityData.Id);
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, singleActivityData.Id);
		}

		// Token: 0x0603F758 RID: 259928 RVA: 0x010447B8 File Offset: 0x010429B8
		protected override void OnOpenView(ActivityBaseData data)
		{
		}

		// Token: 0x0603F759 RID: 259929 RVA: 0x010447BA File Offset: 0x010429BA
		protected override string OnGetActivityResource(ActivityBaseData data)
		{
			return "UiView_CumulativeRechargeMain";
		}

		// Token: 0x0603F75A RID: 259930 RVA: 0x010447C1 File Offset: 0x010429C1
		protected override ActivitySubViewBase OnCreateSubPageComponent(ActivityBaseData data)
		{
			return new TotalTopUpView();
		}

		// Token: 0x0603F75B RID: 259931 RVA: 0x010447C8 File Offset: 0x010429C8
		protected override ActivityBaseData OnCreateActivityData(ActivityData data)
		{
			TotalTopUpData totalTopUpData = new TotalTopUpData();
			if (data.TotalTopUpActivityInfo != null)
			{
				totalTopUpData.InitData(data.TotalTopUpActivityInfo, data.Id);
			}
			return totalTopUpData;
		}

		// Token: 0x0603F75C RID: 259932 RVA: 0x010447F6 File Offset: 0x010429F6
		protected override bool OnGetIsOpeningActivityRelativeView()
		{
			return false;
		}

		// Token: 0x0603F75D RID: 259933 RVA: 0x010447FC File Offset: 0x010429FC
		public unsafe void RequestClaim(int rewardId, int? selectId = null)
		{
			TotalTopUpUtil.Debug("发送请求领取奖励", default(ReadOnlySpan<ValueTuple<string, object>>));
			TotalTopUpRewardRequest totalTopUpRewardRequest = TotalTopUpRewardRequest.Create();
			totalTopUpRewardRequest.TotalTopUpRewardId = rewardId;
			if (selectId != null)
			{
				totalTopUpRewardRequest.SelectedId.Add(selectId.Value);
			}
			Singleton<Net>.Instance.Call<TotalTopUpRewardResponse>(ERequestMessageId.TotalTopUpRewardRequest, totalTopUpRewardRequest, delegate(TotalTopUpRewardResponse response, Net.CallbackStatus _)
			{
				if (response == null || response.ErrorCode != ErrorCode.Success)
				{
					string message = "领取奖励失败";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("RewardId", rewardId);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("ErrorCode", ((response != null) ? new ErrorCode?(response.ErrorCode) : null) ?? ErrorCode.UnKnownError);
					TotalTopUpUtil.Error(message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView((response != null) ? response.ErrorCode : ErrorCode.UnKnownError, 29488, null, true, true);
				}
			}, 0);
		}

		// Token: 0x0603F75E RID: 259934 RVA: 0x01044874 File Offset: 0x01042A74
		[NullableContext(0)]
		public UniTask<bool> RequestScoreInfoAsync(int timeoutMs = 0)
		{
			TotalTopUpController.<RequestScoreInfoAsync>d__14 <RequestScoreInfoAsync>d__;
			<RequestScoreInfoAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<RequestScoreInfoAsync>d__.<>4__this = this;
			<RequestScoreInfoAsync>d__.timeoutMs = timeoutMs;
			<RequestScoreInfoAsync>d__.<>1__state = -1;
			<RequestScoreInfoAsync>d__.<>t__builder.Start<TotalTopUpController.<RequestScoreInfoAsync>d__14>(ref <RequestScoreInfoAsync>d__);
			return <RequestScoreInfoAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603F75F RID: 259935 RVA: 0x010448C0 File Offset: 0x01042AC0
		public int GetGoodsScore(int id)
		{
			TotalTopUpData singleActivityData = this.GetSingleActivityData();
			if (singleActivityData == null)
			{
				return 0;
			}
			int result;
			if (!singleActivityData.GoodsScoreMap.TryGetValue(id, out result))
			{
				return 0;
			}
			return result;
		}

		// Token: 0x0603F760 RID: 259936 RVA: 0x010448EC File Offset: 0x01042AEC
		public int GetRechargeItemScore(int id)
		{
			TotalTopUpData singleActivityData = this.GetSingleActivityData();
			if (singleActivityData == null)
			{
				return 0;
			}
			int result;
			if (!singleActivityData.RechargeItemMap.TryGetValue(id, out result))
			{
				return 0;
			}
			return result;
		}

		// Token: 0x0603F761 RID: 259937 RVA: 0x01044918 File Offset: 0x01042B18
		public bool CheckCurrentTotalUpRunning()
		{
			TotalTopUpData singleActivityData = this.GetSingleActivityData();
			return singleActivityData != null && singleActivityData.CheckIfInOpenTime();
		}

		// Token: 0x0603F762 RID: 259938 RVA: 0x01044938 File Offset: 0x01042B38
		public void SkipToCurrentActivityView()
		{
			TotalTopUpData singleActivityData = this.GetSingleActivityData();
			if (singleActivityData == null)
			{
				TotalTopUpUtil.Error("跳转累计充值活动界面失败，找不到活动数据", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			if (this.TryResumePreviousView(EUiViewName.PayShopRootView, EUiViewName.CommonActivityView, new Action<UiViewBase>(this.<SkipToCurrentActivityView>g__Callback|18_0)))
			{
				return;
			}
			SkipTaskManager.Run(ESkipName.SkipToActivity, new object[]
			{
				singleActivityData.Id
			});
		}

		// Token: 0x0603F763 RID: 259939 RVA: 0x010449A0 File Offset: 0x01042BA0
		public void SkipToPayShop(PayShopDefine.EPayShopTabType shopId, int tabIndex)
		{
			TotalTopUpController.<>c__DisplayClass19_0 CS$<>8__locals1 = new TotalTopUpController.<>c__DisplayClass19_0();
			CS$<>8__locals1.shopId = shopId;
			CS$<>8__locals1.tabIndex = tabIndex;
			if (this.TryResumePreviousView(EUiViewName.CommonActivityView, EUiViewName.PayShopRootView, new Action<UiViewBase>(CS$<>8__locals1.<SkipToPayShop>g__Callback|0)))
			{
				return;
			}
			ESkipName name = ESkipName.SkipTaskPayShopToSpecifyTab;
			object[] array = new object[2];
			int num = 0;
			int shopId2 = (int)CS$<>8__locals1.shopId;
			array[num] = shopId2.ToString();
			array[1] = CS$<>8__locals1.tabIndex.ToString();
			SkipTaskManager.Run(name, array);
		}

		// Token: 0x0603F764 RID: 259940 RVA: 0x01044A0C File Offset: 0x01042C0C
		public bool TryResumePreviousView(EUiViewName fromViewName, EUiViewName toViewName, Action<UiViewBase> callbackBeforeClose)
		{
			UiViewBase uiViewBase = Singleton<UiModel>.Instance.PeekNormalView(0);
			if (uiViewBase == null || uiViewBase.ViewInfo.Name != fromViewName)
			{
				return false;
			}
			UiViewBase uiViewBase2 = Singleton<UiModel>.Instance.PeekNormalView(1);
			if (uiViewBase2 == null || uiViewBase2.ViewInfo.Name != toViewName)
			{
				return false;
			}
			if (callbackBeforeClose != null)
			{
				callbackBeforeClose(uiViewBase2);
			}
			uiViewBase.CloseMe(null);
			return true;
		}

		// Token: 0x0603F765 RID: 259941 RVA: 0x01044A74 File Offset: 0x01042C74
		public string GetCurrentScoreIconPath()
		{
			TotalTopUpData singleActivityData = this.GetSingleActivityData();
			if (singleActivityData == null)
			{
				return string.Empty;
			}
			TotalTopUpData totalTopUpData = singleActivityData;
			return ((totalTopUpData.ViewConfig != null) ? totalTopUpData.ViewConfig.GetValueOrDefault().ScoreIcon : null) ?? string.Empty;
		}

		// Token: 0x0603F767 RID: 259943 RVA: 0x01044AC4 File Offset: 0x01042CC4
		[CompilerGenerated]
		private void <SkipToCurrentActivityView>g__Callback|18_0(UiViewBase _)
		{
			TotalTopUpData singleActivityData = this.GetSingleActivityData();
			if (singleActivityData == null)
			{
				TotalTopUpUtil.Error("恢复累计充值活动界面失败，找不到活动数据", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.ActivityViewChange, singleActivityData.Id);
		}
	}
}
