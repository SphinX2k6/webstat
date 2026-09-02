using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.Sheriff.View;
using CSharpScript.Game.Module.WorldMap;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.Sheriff
{
	// Token: 0x02004FA7 RID: 20391
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Controller(0)]
	public class SheriffController : ActivityControllerBase<SheriffController>
	{
		// Token: 0x06034A0E RID: 215566 RVA: 0x00D33C91 File Offset: 0x00D31E91
		protected override void OnOpenView(ActivityBaseData data)
		{
		}

		// Token: 0x06034A0F RID: 215567 RVA: 0x00D33C93 File Offset: 0x00D31E93
		protected override string OnGetActivityResource(ActivityBaseData data)
		{
			return "UiView_ActivitySkyEye";
		}

		// Token: 0x06034A10 RID: 215568 RVA: 0x00D33C9A File Offset: 0x00D31E9A
		protected override ActivitySubViewBase OnCreateSubPageComponent(ActivityBaseData data)
		{
			return new SheriffSubView();
		}

		// Token: 0x06034A11 RID: 215569 RVA: 0x00D33CA1 File Offset: 0x00D31EA1
		protected override ActivityBaseData OnCreateActivityData(ActivityData data)
		{
			this.ActivityId = data.Id;
			return new SheriffActivityData();
		}

		// Token: 0x06034A12 RID: 215570 RVA: 0x00D33CB4 File Offset: 0x00D31EB4
		[NullableContext(2)]
		public SheriffActivityData GetActivityData()
		{
			SheriffActivityData sheriffActivityData = ModelBase<ActivityModel>.Instance.GetActivityById(this.ActivityId) as SheriffActivityData;
			if (sheriffActivityData == null)
			{
				return null;
			}
			return sheriffActivityData;
		}

		// Token: 0x06034A13 RID: 215571 RVA: 0x00D33CDD File Offset: 0x00D31EDD
		protected override bool OnGetIsOpeningActivityRelativeView()
		{
			return false;
		}

		// Token: 0x06034A14 RID: 215572 RVA: 0x00D33CE0 File Offset: 0x00D31EE0
		protected override void OnAddEvents()
		{
			Singleton<EventSystem>.Instance.Add<EFunctionType, bool>(EEventName.OnFunctionOpenSet, new Action<EFunctionType, bool>(this.RequestSheriffZoneInfo));
			Singleton<EventSystem>.Instance.Add<EFunctionType, bool>(EEventName.OnFunctionOpenUpdate, new Action<EFunctionType, bool>(this.RequestSheriffZoneInfo));
			Singleton<EventSystem>.Instance.Add<IProto_NormalItem, int, int>(EEventName.OnCommonItemCountRefresh, new Action<IProto_NormalItem, int, int>(this.OnCurrencyChange));
		}

		// Token: 0x06034A15 RID: 215573 RVA: 0x00D33D44 File Offset: 0x00D31F44
		protected override void OnRemoveEvents()
		{
			Singleton<EventSystem>.Instance.Remove<EFunctionType, bool>(EEventName.OnFunctionOpenSet, new Action<EFunctionType, bool>(this.RequestSheriffZoneInfo));
			Singleton<EventSystem>.Instance.Remove<EFunctionType, bool>(EEventName.OnFunctionOpenUpdate, new Action<EFunctionType, bool>(this.RequestSheriffZoneInfo));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnCommonItemCountRefresh, new Action<IProto_NormalItem, int, int>(this.OnCurrencyChange));
		}

		// Token: 0x06034A16 RID: 215574 RVA: 0x00D33DA5 File Offset: 0x00D31FA5
		private void OnCurrencyChange(IProto_NormalItem item, int count, int lastCount)
		{
			if (item.Id != ModelBase<SheriffModel>.Instance.GetShopCurrencyId())
			{
				return;
			}
			if (lastCount >= count)
			{
				return;
			}
			ModelBase<SheriffModel>.Instance.ReArmShopRedDot();
		}

		// Token: 0x06034A17 RID: 215575 RVA: 0x00D33DCC File Offset: 0x00D31FCC
		protected override void OnRegisterNetEvent()
		{
			Singleton<Net>.Instance.Register<SheriffAnomalyInfoUpdateNotify>(ENotifyMessageId.SheriffAnomalyInfoUpdateNotify, new Action<SheriffAnomalyInfoUpdateNotify, Net.CallbackStatus>(this.OnSheriffAnomalyInfoUpdateNotify));
			Singleton<Net>.Instance.Register<SheriffCriminalUpdateNotify>(ENotifyMessageId.SheriffCriminalUpdateNotify, new Action<SheriffCriminalUpdateNotify, Net.CallbackStatus>(this.OnSheriffCriminalUpdateNotify));
			Singleton<Net>.Instance.Register<SheriffZoneItemUpdateNotify>(ENotifyMessageId.SheriffZoneItemUpdateNotify, new Action<SheriffZoneItemUpdateNotify, Net.CallbackStatus>(this.OnSheriffZoneItemUpdateNotify));
		}

		// Token: 0x06034A18 RID: 215576 RVA: 0x00D33E2D File Offset: 0x00D3202D
		protected override void OnUnRegisterNetEvent()
		{
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.SheriffAnomalyInfoUpdateNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.SheriffCriminalUpdateNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.SheriffZoneItemUpdateNotify);
		}

		// Token: 0x06034A19 RID: 215577 RVA: 0x00D33E5F File Offset: 0x00D3205F
		public void OpenAnalysisClueView(int questionId)
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.SheriffMainView, questionId, null);
		}

		// Token: 0x06034A1A RID: 215578 RVA: 0x00D33E78 File Offset: 0x00D32078
		[NullableContext(0)]
		public UniTask<bool> OnUiGameplayFinish(int gameplayId, int progressId, int endingId)
		{
			SheriffController.<OnUiGameplayFinish>d__14 <OnUiGameplayFinish>d__;
			<OnUiGameplayFinish>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<OnUiGameplayFinish>d__.gameplayId = gameplayId;
			<OnUiGameplayFinish>d__.progressId = progressId;
			<OnUiGameplayFinish>d__.endingId = endingId;
			<OnUiGameplayFinish>d__.<>1__state = -1;
			<OnUiGameplayFinish>d__.<>t__builder.Start<SheriffController.<OnUiGameplayFinish>d__14>(ref <OnUiGameplayFinish>d__);
			return <OnUiGameplayFinish>d__.<>t__builder.Task;
		}

		// Token: 0x06034A1B RID: 215579 RVA: 0x00D33ECC File Offset: 0x00D320CC
		private void OnSheriffAnomalyInfoUpdateNotify(SheriffAnomalyInfoUpdateNotify message, [Nullable(2)] Net.CallbackStatus status)
		{
			ModelBase<SheriffModel>.Instance.UpdateAnomalyInfo(message.AnomalyInfos.ToList<SheriffAnomalyInfo>(), null);
			ModelBase<SheriffModel>.Instance.CheckNeedOpenReportPop();
		}

		// Token: 0x06034A1C RID: 215580 RVA: 0x00D33F04 File Offset: 0x00D32104
		private void OnSheriffCriminalUpdateNotify(SheriffCriminalUpdateNotify message, [Nullable(2)] Net.CallbackStatus status)
		{
			ModelBase<SheriffModel>.Instance.UpdateCriminalInfo(message.CriminalInfos.ToList<SheriffCriminalInfo>(), null);
		}

		// Token: 0x06034A1D RID: 215581 RVA: 0x00D33F2F File Offset: 0x00D3212F
		private void OnSheriffZoneItemUpdateNotify(SheriffZoneItemUpdateNotify message, [Nullable(2)] Net.CallbackStatus status)
		{
			ModelBase<SheriffModel>.Instance.UpdateZoneItemCount(message.ZoneId, (int)message.ItemCount);
			Singleton<EventSystem>.Instance.Emit<int, PayShopDefine.EPayShopTabType, int>(EEventName.RefreshGoods, 0, ModelBase<SheriffModel>.Instance.ShopId, 0);
		}

		// Token: 0x06034A1E RID: 215582 RVA: 0x00D33F64 File Offset: 0x00D32164
		private void RequestSheriffZoneInfo(EFunctionType id, bool isOpen)
		{
			if (this.ZoneConfigMap.Count == 0)
			{
				foreach (SheriffZone sheriffZone in ConfigBase<SheriffConfig>.Instance.GetZoneConfigAll())
				{
					this.ZoneConfigMap[(EFunctionType)sheriffZone.AnomalyFuncId] = sheriffZone.Id;
				}
			}
			if (!this.ZoneConfigMap.ContainsKey(id))
			{
				return;
			}
			if (!isOpen)
			{
				return;
			}
			SheriffZoneInfoRequest sheriffZoneInfoRequest = SheriffZoneInfoRequest.Create();
			int item = this.ZoneConfigMap[id];
			sheriffZoneInfoRequest.ZoneIds.Add(item);
			Singleton<Net>.Instance.Call<SheriffZoneInfoResponse>(ERequestMessageId.SheriffZoneInfoRequest, sheriffZoneInfoRequest, delegate(SheriffZoneInfoResponse response, Net.CallbackStatus _)
			{
				if (ControllerBase<ErrorCodeController>.Instance.CheckErrorCode(new Aki.Protocol.ErrorCode?(response.ErrorCode), EResponseMessageId.SheriffZoneInfoResponse, true))
				{
					return;
				}
				ModelBase<SheriffModel>.Instance.UpdateZoneInfo(response.ZoneInfos.ToList<SheriffZoneInfo>());
			}, 0);
		}

		// Token: 0x06034A1F RID: 215583 RVA: 0x00D34038 File Offset: 0x00D32238
		public void ReadTerminalFirstOpenRedDot()
		{
			SheriffActivityData activityData = this.GetActivityData();
			if (activityData == null)
			{
				return;
			}
			activityData.ReadTerminalFirstOpenRedDot();
		}

		// Token: 0x06034A20 RID: 215584 RVA: 0x00D3404C File Offset: 0x00D3224C
		[NullableContext(2)]
		public void OpenSheriffMap(SheriffMapPanelParam panelParams = null)
		{
			SheriffActivityData activityData = this.GetActivityData();
			if (activityData != null)
			{
				activityData.ReadRedDot();
			}
			SheriffMapPanelParam sheriffMapPanelParam = panelParams ?? new SheriffMapPanelParam();
			if (sheriffMapPanelParam.TabType == null)
			{
				sheriffMapPanelParam.TabType = new ESheriffMainTabType?(ESheriffMainTabType.Event);
			}
			if (sheriffMapPanelParam.TargetMarkId == null)
			{
				ESheriffMainTabType? tabType = sheriffMapPanelParam.TabType;
				if (tabType != null)
				{
					ESheriffMainTabType valueOrDefault = tabType.GetValueOrDefault();
					if (valueOrDefault != ESheriffMainTabType.Event)
					{
						if (valueOrDefault == ESheriffMainTabType.Quest)
						{
							SheriffQuestState questState = ModelBase<SheriffModel>.Instance.GetQuestState(1, ESheriffQuestType.POI);
							sheriffMapPanelParam.TargetMarkId = new int?(ModelBase<SheriffModel>.Instance.GetTargetMapMarkIdByQuestIds(questState.TotalList));
							int? targetMarkId = sheriffMapPanelParam.TargetMarkId;
							int num = 0;
							if (targetMarkId.GetValueOrDefault() == num & targetMarkId != null)
							{
								SheriffQuestState questState2 = ModelBase<SheriffModel>.Instance.GetQuestState(1, ESheriffQuestType.Branch);
								sheriffMapPanelParam.TargetMarkId = new int?(ModelBase<SheriffModel>.Instance.GetTargetMapMarkIdByQuestIds(questState2.TotalList));
							}
						}
					}
					else
					{
						sheriffMapPanelParam.TargetMarkId = new int?(ModelBase<SheriffModel>.Instance.GetTargetAnomalyMarkId());
					}
				}
			}
			WorldMapViewOpenParams mapOpenParam = new WorldMapViewOpenParams
			{
				MarkType = EMarkType.SheriffAnomaly,
				MarkId = sheriffMapPanelParam.TargetMarkId,
				IsNotFocal = new bool?(true),
				IsNotFocusTween = new bool?(true),
				SkipToExtraUiName = new EWorldMapExtraUiPanelName?(EWorldMapExtraUiPanelName.SheriffMapPanel),
				SkipToExtraUiParam = sheriffMapPanelParam
			};
			ControllerBase<WorldMapController>.Instance.OpenExtraUi(EWorldMapExtraUiPanelName.SheriffMapPanel, mapOpenParam, sheriffMapPanelParam);
		}

		// Token: 0x06034A21 RID: 215585 RVA: 0x00D341AC File Offset: 0x00D323AC
		public void OpenDetailClueFromQuestPanel()
		{
			SheriffShowClueViewPopInfo param = new SheriffShowClueViewPopInfo
			{
				AnomalyId = ModelBase<SheriffModel>.Instance.LastCacheAnomaly,
				ClueId = new int?(ModelBase<SheriffModel>.Instance.LastCacheClue)
			};
			Singleton<UiManager>.Instance.OpenView(EUiViewName.SheriffShowClueViewPop, param, null);
		}

		// Token: 0x06034A22 RID: 215586 RVA: 0x00D341F8 File Offset: 0x00D323F8
		public void OpenAnomalyConditionView(int anomalyId)
		{
			SheriffAnomaly? anomalyConfigById = ConfigBase<SheriffConfig>.Instance.GetAnomalyConfigById(anomalyId);
			if (anomalyConfigById == null)
			{
				return;
			}
			List<IActivityConditionData> list = new List<IActivityConditionData>();
			int[] groupConditionIds = ConfigBase<ConditionConfig>.Instance.GetGroupConditionIds(anomalyConfigById.Value.UnlockConditionGroupId);
			if (groupConditionIds == null)
			{
				return;
			}
			foreach (int conditionId in groupConditionIds)
			{
				Condition? conditionConfig = ConfigBase<ConditionConfig>.Instance.GetConditionConfig(conditionId);
				if (conditionConfig != null)
				{
					int accessType = -1;
					if (!string.IsNullOrEmpty(conditionConfig.Value.Description))
					{
						if (conditionConfig.Value.AccessId > 0)
						{
							AccessPath? configById = ConfigBase<GetWayConfig>.Instance.GetConfigById(conditionConfig.Value.AccessId);
							accessType = ((configById != null) ? configById.GetValueOrDefault().SkipName : -1);
						}
						ActivityConditionData item = new ActivityConditionData
						{
							ConditionId = conditionId,
							ConditionTextId = conditionConfig.Value.Description,
							IsFinished = false,
							AccessId = conditionConfig.Value.AccessId,
							AccessType = accessType
						};
						list.Add(item);
					}
				}
			}
			ConditionGroupData param = new ConditionGroupData(anomalyConfigById.Value.UnlockConditionGroupId, list, "", false);
			Singleton<UiManager>.Instance.OpenView(EUiViewName.CommonConditionView, param, null);
		}

		// Token: 0x06034A23 RID: 215587 RVA: 0x00D34368 File Offset: 0x00D32568
		public void OpenSheriffReportPop(int criminalId, bool bothPage)
		{
			SheriffReportPopViewParam param = new SheriffReportPopViewParam
			{
				CriminalId = criminalId,
				BothPage = bothPage
			};
			Singleton<UiManager>.Instance.OpenView(EUiViewName.SheriffReportPop, param, null);
		}

		// Token: 0x0401E560 RID: 124256
		public int ActivityId;

		// Token: 0x0401E561 RID: 124257
		public Dictionary<EFunctionType, int> ZoneConfigMap = new Dictionary<EFunctionType, int>();
	}
}
