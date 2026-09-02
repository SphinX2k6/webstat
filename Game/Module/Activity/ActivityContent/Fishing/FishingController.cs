using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Aki.Config;
using Aki.Protocol;
using AkiClient.Game.Aki.Character.BaseCharacter;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.LevelGamePlay.FishingQte;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Game.Module.Map;
using CSharpScript.Game.Module.Teleport;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x020067DC RID: 26588
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Controller(0)]
	public class FishingController : UiControllerBase<FishingController>
	{
		// Token: 0x0604253A RID: 271674 RVA: 0x01102BB0 File Offset: 0x01100DB0
		public void OpenDockyardView()
		{
			DockyardViewModel param = new DockyardViewModel();
			Singleton<UiManager>.Instance.OpenView(EUiViewName.DockyardView, param, null);
		}

		// Token: 0x0604253B RID: 271675 RVA: 0x01102BD4 File Offset: 0x01100DD4
		public void OpenDockyardWareHouseView(bool inGameplayFlow = false)
		{
			DockyardWareHouseViewModel dockyardWareHouseViewModel = new DockyardWareHouseViewModel();
			dockyardWareHouseViewModel.InGameplayFlow = inGameplayFlow;
			Singleton<UiManager>.Instance.OpenView(EUiViewName.DockyardWareHouseView, dockyardWareHouseViewModel, null);
		}

		// Token: 0x0604253C RID: 271676 RVA: 0x01102C00 File Offset: 0x01100E00
		public UniTask OpenDockyardCageView(int configId)
		{
			FishingController.<OpenDockyardCageView>d__4 <OpenDockyardCageView>d__;
			<OpenDockyardCageView>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OpenDockyardCageView>d__.configId = configId;
			<OpenDockyardCageView>d__.<>1__state = -1;
			<OpenDockyardCageView>d__.<>t__builder.Start<FishingController.<OpenDockyardCageView>d__4>(ref <OpenDockyardCageView>d__);
			return <OpenDockyardCageView>d__.<>t__builder.Task;
		}

		// Token: 0x0604253D RID: 271677 RVA: 0x01102C44 File Offset: 0x01100E44
		public void OpenDockyardInteractView(int configId, int actionIncId)
		{
			DockyardInteractViewModel dockyardInteractViewModel = new DockyardInteractViewModel();
			dockyardInteractViewModel.ConfigId = configId;
			dockyardInteractViewModel.ActionIncId = actionIncId;
			Singleton<UiManager>.Instance.OpenView(EUiViewName.DockyardInteractView, dockyardInteractViewModel, null);
		}

		// Token: 0x0604253E RID: 271678 RVA: 0x01102C76 File Offset: 0x01100E76
		public void OpenDockyardShopView(EDockyardShopTabType? tabType = null)
		{
			if (!ModelBase<FunctionModel>.Instance.IsOpen(10077))
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Fishing_NotOpenFunction", Array.Empty<object>());
				return;
			}
			Singleton<UiManager>.Instance.OpenView(EUiViewName.DockyardShopMainView, tabType, null);
		}

		// Token: 0x0604253F RID: 271679 RVA: 0x01102CB4 File Offset: 0x01100EB4
		public void OpenFishingTechRootView()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.FishingTechRootView, null, null);
		}

		// Token: 0x06042540 RID: 271680 RVA: 0x01102CC7 File Offset: 0x01100EC7
		public void OpenFishingHandBookView()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.FishingHandBookView, null, null);
		}

		// Token: 0x06042541 RID: 271681 RVA: 0x01102CDA File Offset: 0x01100EDA
		public void OpenFishingQuestView()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.FishingQuestView, null, null);
		}

		// Token: 0x06042542 RID: 271682 RVA: 0x01102CF0 File Offset: 0x01100EF0
		protected override void OnAddOpenViewCheckFunction()
		{
			Singleton<UiManager>.Instance.AddOpenViewCheckFunction(EUiViewName.FishingQuestView, new Func<EUiViewName, object, bool>(this.CanOpenQuestView), "FishingController.CanOpenFishingQuestView");
			Singleton<UiManager>.Instance.AddOpenViewCheckFunction(EUiViewName.FishingHandBookView, new Func<EUiViewName, object, bool>(this.CanOpenHandBookView), "FishingController.CanOpenHandBookView");
			Singleton<UiManager>.Instance.AddOpenViewCheckFunction(EUiViewName.FishingTechRootView, new Func<EUiViewName, object, bool>(this.CanOpenTechRootView), "FishingController.CanOpenTechRootView");
			Singleton<UiManager>.Instance.AddOpenViewCheckFunction(EUiViewName.DockyardShopMainView, new Func<EUiViewName, object, bool>(this.CanOpenDockyardShopView), "FishingController.CanOpenDockyardShopView");
		}

		// Token: 0x06042543 RID: 271683 RVA: 0x01102D80 File Offset: 0x01100F80
		protected override void OnRemoveOpenViewCheckFunction()
		{
			Singleton<UiManager>.Instance.RemoveOpenViewCheckFunction(EUiViewName.FishingQuestView, new Func<EUiViewName, object, bool>(this.CanOpenQuestView));
			Singleton<UiManager>.Instance.RemoveOpenViewCheckFunction(EUiViewName.FishingHandBookView, new Func<EUiViewName, object, bool>(this.CanOpenHandBookView));
			Singleton<UiManager>.Instance.RemoveOpenViewCheckFunction(EUiViewName.FishingTechRootView, new Func<EUiViewName, object, bool>(this.CanOpenTechRootView));
			Singleton<UiManager>.Instance.RemoveOpenViewCheckFunction(EUiViewName.DockyardShopMainView, new Func<EUiViewName, object, bool>(this.CanOpenDockyardShopView));
		}

		// Token: 0x06042544 RID: 271684 RVA: 0x01102DF9 File Offset: 0x01100FF9
		private bool CanOpenQuestView(EUiViewName viewName, object param)
		{
			bool flag = ModelBase<FunctionModel>.Instance.IsOpen(EFunctionType.FishingEntrust);
			if (!flag)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Fishing_NotOpenFunction", Array.Empty<object>());
			}
			return flag;
		}

		// Token: 0x06042545 RID: 271685 RVA: 0x01102E21 File Offset: 0x01101021
		private bool CanOpenHandBookView(EUiViewName viewName, object param)
		{
			bool flag = ModelBase<FunctionModel>.Instance.IsOpen(EFunctionType.FishingHandBook);
			if (!flag)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Fishing_NotOpenFunction", Array.Empty<object>());
			}
			return flag;
		}

		// Token: 0x06042546 RID: 271686 RVA: 0x01102E49 File Offset: 0x01101049
		private bool CanOpenTechRootView(EUiViewName viewName, object param)
		{
			bool flag = ModelBase<FunctionModel>.Instance.IsOpen(EFunctionType.FishingTech);
			if (!flag)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Fishing_NotOpenFunction", Array.Empty<object>());
			}
			return flag;
		}

		// Token: 0x06042547 RID: 271687 RVA: 0x01102E71 File Offset: 0x01101071
		private bool CanOpenDockyardShopView(EUiViewName viewName, object param)
		{
			bool flag = ModelBase<FunctionModel>.Instance.IsOpen(EFunctionType.FishingItemDelete);
			if (!flag)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Fishing_NotOpenFunction", Array.Empty<object>());
			}
			return flag;
		}

		// Token: 0x06042548 RID: 271688 RVA: 0x01102E9C File Offset: 0x0110109C
		public void FishingInputHandler(string actionName)
		{
			if (actionName == "切换角色1")
			{
				this.OpenDockyardView();
				return;
			}
			if (actionName == "切换角色2")
			{
				this.OpenFishingQuestView();
				return;
			}
			if (actionName == "切换角色3")
			{
				this.OpenFishingTechRootView();
				return;
			}
			if (!(actionName == "切换角色4"))
			{
				return;
			}
			this.OpenFishingHandBookView();
		}

		// Token: 0x06042549 RID: 271689 RVA: 0x01102EFC File Offset: 0x011010FC
		protected override void OnAddEvents()
		{
			Singleton<EventSystem>.Instance.Add<EFunctionType, bool>(EEventName.OnFunctionOpenSet, new Action<EFunctionType, bool>(this.RequestFishingInfo));
			Singleton<EventSystem>.Instance.Add<EFunctionType, bool>(EEventName.OnFunctionOpenUpdate, new Action<EFunctionType, bool>(this.RequestFishingInfo));
			Singleton<EventSystem>.Instance.Add<IProto_NormalItem, int, int>(EEventName.OnCommonItemCountRefresh, new Action<IProto_NormalItem, int, int>(this.ShowFishingLevelUp));
			Singleton<EventSystem>.Instance.Add<EUiViewName, int>(EEventName.CloseView, new Action<EUiViewName, int>(this.OnCloseViewFinish));
		}

		// Token: 0x0604254A RID: 271690 RVA: 0x01102F78 File Offset: 0x01101178
		protected override void OnRemoveEvents()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnFunctionOpenSet, new Action<EFunctionType, bool>(this.RequestFishingInfo));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnFunctionOpenUpdate, new Action<EFunctionType, bool>(this.RequestFishingInfo));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnCommonItemCountRefresh, new Action<IProto_NormalItem, int, int>(this.ShowFishingLevelUp));
			Singleton<EventSystem>.Instance.Remove(EEventName.CloseView, new Action<EUiViewName, int>(this.OnCloseViewFinish));
		}

		// Token: 0x0604254B RID: 271691 RVA: 0x01102FF4 File Offset: 0x011011F4
		protected override void OnRegisterNetEvent()
		{
			Singleton<Net>.Instance.Register<FishingInfoUpdateNotify>(ENotifyMessageId.FishingInfoUpdateNotify, delegate(FishingInfoUpdateNotify response, [Nullable(2)] Net.CallbackStatus _)
			{
			});
			Singleton<Net>.Instance.Register<FishingShipInfoUpdateNotify>(ENotifyMessageId.FishingShipInfoUpdateNotify, delegate(FishingShipInfoUpdateNotify data, [Nullable(2)] Net.CallbackStatus _)
			{
				FishingShipInfo shipInfo = data.ShipInfo;
				if (shipInfo != null)
				{
					ModelBase<DockyardModel>.Instance.UpdateDockyardData(shipInfo.CabinInfo);
					ModelBase<FishingModel>.Instance.GetShipData().RefreshData(shipInfo);
					if (shipInfo.EntityId == 0L)
					{
						ModelBase<MapModel>.Instance.RemoveFishingShipMarkAndCache();
					}
				}
			});
			Singleton<Net>.Instance.Register<FishingNetCabinUpdateNotify>(ENotifyMessageId.FishingNetCabinUpdateNotify, delegate(FishingNetCabinUpdateNotify response, [Nullable(2)] Net.CallbackStatus _)
			{
				ModelBase<DockyardModel>.Instance.SetTrawlDataListFromServer(response.NetCabinItems.ToList<FishingItemInfo>());
			});
			Singleton<Net>.Instance.Register<FishingTechInfoUpdateNotify>(ENotifyMessageId.FishingTechInfoUpdateNotify, delegate(FishingTechInfoUpdateNotify response, [Nullable(2)] Net.CallbackStatus _)
			{
				ModelBase<FishingModel>.Instance.UpdateFishingTechData(response.TechInfo);
			});
			Singleton<Net>.Instance.Register<FishingIllustratedInfoUpdateNotify>(ENotifyMessageId.FishingIllustratedInfoUpdateNotify, delegate(FishingIllustratedInfoUpdateNotify response, [Nullable(2)] Net.CallbackStatus _)
			{
				ModelBase<FishingModel>.Instance.RefreshHandBookData(response.IllustratedInfo);
				ModelBase<FishingModel>.Instance.FishingItemHandBookUnlockTraceList.AddRange(response.UnlockDetections);
			});
			Singleton<Net>.Instance.Register<FishingIllustratedRewardInfoUpdateNotify>(ENotifyMessageId.FishingIllustratedRewardInfoUpdateNotify, delegate(FishingIllustratedRewardInfoUpdateNotify response, [Nullable(2)] Net.CallbackStatus _)
			{
				ModelBase<FishingModel>.Instance.RefreshHandBookDataReward(response.RewardInfo);
			});
			Singleton<Net>.Instance.Register<FishingSceneFishCageInfoUpdateNotify>(ENotifyMessageId.FishingSceneFishCageInfoUpdateNotify, delegate(FishingSceneFishCageInfoUpdateNotify response, [Nullable(2)] Net.CallbackStatus _)
			{
				ModelBase<FishingModel>.Instance.AddCageDataFromServer(response.SceneConfigId, response.Cage);
			});
			Singleton<Net>.Instance.Register<SceneFishPointInfoUpdateNotify>(ENotifyMessageId.SceneFishPointInfoUpdateNotify, delegate(SceneFishPointInfoUpdateNotify response, [Nullable(2)] Net.CallbackStatus _)
			{
				if (response.FishPoint != null)
				{
					if (response.IsRemove)
					{
						ModelBase<FishingModel>.Instance.RemoveOneFishingPointData(response.SceneConfigId, response.FishPoint);
						return;
					}
					ModelBase<FishingModel>.Instance.RefreshFishingPointData(response.SceneConfigId, response.FishPoint);
				}
			});
			Singleton<Net>.Instance.Register<SceneTempFishPointInfoUpdateNotify>(ENotifyMessageId.SceneTempFishPointInfoUpdateNotify, delegate(SceneTempFishPointInfoUpdateNotify response, [Nullable(2)] Net.CallbackStatus _)
			{
				if (response.FishPoint != null)
				{
					if (response.IsRemove)
					{
						ModelBase<FishingModel>.Instance.RemoveTempFishingPointData(response.FishPoint);
					}
					else
					{
						ModelBase<FishingModel>.Instance.SetTempFishingPointData(response.SceneConfigId, response.FishPoint);
					}
					Singleton<EventSystem>.Instance.Emit(EEventName.OnRefreshTempFishingPointNum);
				}
			});
			Singleton<Net>.Instance.Register<FishingShipForceBackNotify>(ENotifyMessageId.FishingShipForceBackNotify, delegate(FishingShipForceBackNotify response, [Nullable(2)] Net.CallbackStatus _)
			{
			});
			Singleton<Net>.Instance.Register<FishingItemAddNotify>(ENotifyMessageId.FishingItemAddNotify, delegate(FishingItemAddNotify response, [Nullable(2)] Net.CallbackStatus _)
			{
				foreach (FishingItemInfo trawlData in response.NetCabinItem)
				{
					ModelBase<DockyardModel>.Instance.SetTrawlData(trawlData);
				}
				foreach (FishingItemInfo wareHouseData in response.TempCabinItem)
				{
					ModelBase<DockyardModel>.Instance.SetWareHouseData(wareHouseData);
				}
			});
			Singleton<Net>.Instance.Register<FishingNoticeUpdateNotify>(ENotifyMessageId.FishingNoticeUpdateNotify, delegate(FishingNoticeUpdateNotify response, [Nullable(2)] Net.CallbackStatus _)
			{
				ModelBase<FishingModel>.Instance.RoleTalkIds = response.NoticeIds.ToList<int>();
			});
			Singleton<Net>.Instance.Register<HandInInfoUpdateNotify>(ENotifyMessageId.HandInInfoUpdateNotify, delegate(HandInInfoUpdateNotify response, [Nullable(2)] Net.CallbackStatus _)
			{
				ModelBase<FishingModel>.Instance.UpdateInteractData(response.HandInInfo);
			});
			Singleton<Net>.Instance.Register<FishingEntrustUpdateNotify>(ENotifyMessageId.FishingEntrustUpdateNotify, delegate(FishingEntrustUpdateNotify response, [Nullable(2)] Net.CallbackStatus _)
			{
				if (ModelBase<FishingQuestModel>.Instance.CurrentTraceEntrust != response.TraceEntrusts)
				{
					ModelBase<FishingQuestModel>.Instance.CurrentTraceEntrust = response.TraceEntrusts;
					ModelBase<FishingQuestModel>.Instance.TraceEntrust();
				}
				ModelBase<FishingQuestModel>.Instance.EntrustRefreshCostRatio = response.EntrustRefreshRatio;
				ModelBase<FishingQuestModel>.Instance.UpdateEntrusts(response.Entrusts.ToDictionary((KeyValuePair<int, FishingEntrustStatus> x) => x.Key, (KeyValuePair<int, FishingEntrustStatus> x) => x.Value));
			});
			Singleton<Net>.Instance.Register<FishingBoatDieNotify>(ENotifyMessageId.FishingBoatDieNotify, new Action<FishingBoatDieNotify, Net.CallbackStatus>(this.FishingBoatDieNotify));
			Singleton<Net>.Instance.Register<FishingPortUnlockNotify>(ENotifyMessageId.FishingPortUnlockNotify, delegate(FishingPortUnlockNotify response, [Nullable(2)] Net.CallbackStatus _)
			{
				ModelBase<FishingModel>.Instance.UnlockPort.AddRange(response.UnlockPortId);
			});
			Singleton<Net>.Instance.Register<FishingGhostStateNotify>(ENotifyMessageId.FishingGhostStateNotify, new Action<FishingGhostStateNotify, Net.CallbackStatus>(this.FishingGhostStateNotify));
			Singleton<Net>.Instance.Register<FishingSkinUnlockNotify>(ENotifyMessageId.FishingSkinUnlockNotify, delegate(FishingSkinUnlockNotify response, [Nullable(2)] Net.CallbackStatus _)
			{
				ModelBase<FishingModel>.Instance.UnlockShipSkin.AddRange(response.UnlockSkins);
			});
			Singleton<Net>.Instance.Register<FishingPortUpdateNotify>(ENotifyMessageId.FishingPortUpdateNotify, delegate(FishingPortUpdateNotify response, [Nullable(2)] Net.CallbackStatus _)
			{
				FishingShipData shipData = ModelBase<FishingModel>.Instance.GetShipData();
				shipData.SetLastPortId(response.LastPortId);
				shipData.SetIsInPortInternal(response.IsInPort);
			});
		}

		// Token: 0x0604254C RID: 271692 RVA: 0x01103358 File Offset: 0x01101558
		protected override void OnUnRegisterNetEvent()
		{
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.FishingInfoUpdateNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.FishingShipInfoUpdateNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.FishingNetCabinUpdateNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.FishingTechInfoUpdateNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.FishingIllustratedInfoUpdateNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.FishingIllustratedRewardInfoUpdateNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.FishingSceneFishCageInfoUpdateNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.SceneFishPointInfoUpdateNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.FishingShipForceBackNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.FishingItemAddNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.FishingNoticeUpdateNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.HandInInfoUpdateNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.FishingEntrustUpdateNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.FishingBoatDieNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.FishingPortUnlockNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.FishingGhostStateNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.FishingSkinUnlockNotify);
		}

		// Token: 0x0604254D RID: 271693 RVA: 0x01103478 File Offset: 0x01101678
		private void FishingGhostStateNotify(FishingGhostStateNotify data, [Nullable(2)] Net.CallbackStatus _)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Fishing;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "幽灵船玩法状态通知";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("是否开启", data.Open);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			if (data.Open)
			{
				Singleton<UiManager>.Instance.OpenView(EUiViewName.FishingWarningTips, null, null);
				return;
			}
			Singleton<UiManager>.Instance.CloseView(EUiViewName.FishingWarningTips, null);
		}

		// Token: 0x0604254E RID: 271694 RVA: 0x011034E4 File Offset: 0x011016E4
		private void FishingBoatDieNotify(FishingBoatDieNotify data, [Nullable(2)] Net.CallbackStatus _)
		{
			FishingController.<>c__DisplayClass22_0 CS$<>8__locals1 = new FishingController.<>c__DisplayClass22_0();
			CS$<>8__locals1.data = data;
			FishingController.<>c__DisplayClass22_0 CS$<>8__locals2 = CS$<>8__locals1;
			FishingBoatDieNotify data2 = CS$<>8__locals1.data;
			CS$<>8__locals2.position = ((data2 != null) ? data2.Pos : null);
			if (CS$<>8__locals1.position == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.Teleport, ELogAuthor.LYY, "捕鱼船死亡时目标位置错误", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
			{
				FishingShipData shipData = ModelBase<FishingModel>.Instance.GetShipData();
				EntityHandle entityHandle = shipData.GetEntityHandle();
				object obj;
				if (entityHandle == null)
				{
					obj = null;
				}
				else
				{
					WorldEntity entity = entityHandle.Entity;
					obj = ((entity != null) ? entity.GetComponent<FishingBoatDeathComponent>() : null);
				}
				object obj2 = obj;
				if (obj2 != null)
				{
					obj2.ExecuteRevive();
				}
				bool flag = shipData.IsShipDriving();
				FVectorDouble targetPosition = new FVectorDouble((double)CS$<>8__locals1.position.X, (double)CS$<>8__locals1.position.Y, (double)CS$<>8__locals1.position.Z);
				Aki.Protocol.Rotator rot = CS$<>8__locals1.data.Rot;
				float pitch = (rot != null) ? rot.Pitch : 0f;
				Aki.Protocol.Rotator rot2 = CS$<>8__locals1.data.Rot;
				float yaw = (rot2 != null) ? rot2.Yaw : 0f;
				Aki.Protocol.Rotator rot3 = CS$<>8__locals1.data.Rot;
				global::Rotator targetRotation = global::Rotator.Create(pitch, yaw, (rot3 != null) ? rot3.Roll : 0f);
				TransitionOptionPb transitionOptionPb = TransitionOptionPb.Create();
				transitionOptionPb.TransitionType = TransitionType.CenterText;
				TransitionFlowPb transitionFlowPb = TransitionFlowPb.Create();
				transitionFlowPb.FlowListName = "剧情_V2.1航海活动主线";
				transitionFlowPb.FlowId = 20;
				transitionFlowPb.StateId = 1;
				transitionOptionPb.TransitionFlow = transitionFlowPb;
				if (flag)
				{
					ControllerBase<TeleportController>.Instance.TeleportPlayerInVehicle(new ITeleportContextParam
					{
						ClientReason = "FishingBoatDie",
						TargetPosition = targetPosition,
						TargetRotation = targetRotation,
						ServerReason = new TeleportReason?(TeleportReason.FlowAction),
						Option = transitionOptionPb
					});
					return;
				}
				ControllerBase<TeleportController>.Instance.TeleportPlayer(new ITeleportContextParam
				{
					ClientReason = "FishingBoatDie",
					TargetPosition = targetPosition,
					TargetRotation = targetRotation,
					ServerReason = new TeleportReason?(TeleportReason.FlowAction),
					Option = transitionOptionPb
				});
			}, 1300f, null, null, true, 1f);
		}

		// Token: 0x0604254F RID: 271695 RVA: 0x01103564 File Offset: 0x01101764
		private void RequestFishingInfo(EFunctionType id, bool isOpen)
		{
			if (id != EFunctionType.Fishing)
			{
				return;
			}
			if (!isOpen)
			{
				return;
			}
			FishingInfoRequest message = FishingInfoRequest.Create();
			Singleton<Net>.Instance.Call<FishingInfoResponse>(ERequestMessageId.FishingInfoRequest, message, delegate(FishingInfoResponse response, Net.CallbackStatus _)
			{
				if (response == null)
				{
					return;
				}
				ModelBase<DockyardModel>.Instance.SetFishingShipData(response.FishingInfo.ShipInfo);
				ModelBase<FishingQuestModel>.Instance.CurrentTraceEntrust = response.FishingInfo.TraceEntrusts;
				ModelBase<FishingQuestModel>.Instance.TraceEntrust();
				ModelBase<FishingModel>.Instance.RoleTalkIds = response.FishingInfo.NoticeIds.ToList<int>();
				ModelBase<FishingModel>.Instance.UnlockPort = response.FishingInfo.UnlockPortId.ToList<int>();
				ModelBase<FishingModel>.Instance.CurrentShipSkin = response.FishingInfo.ShipInfo.SkinId;
				ModelBase<FishingModel>.Instance.UnlockShipSkin = response.FishingInfo.UnlockSkins.ToList<int>();
				ModelBase<FishingQuestModel>.Instance.UpdateEntrusts(response.FishingInfo.Entrusts.ToDictionary((KeyValuePair<int, FishingEntrustStatus> x) => x.Key, (KeyValuePair<int, FishingEntrustStatus> x) => x.Value));
				ModelBase<FishingModel>.Instance.GetShipData().RefreshData(response.FishingInfo.ShipInfo);
				ModelBase<FishingModel>.Instance.SetFishingTechData(response.FishingInfo.FishingTech.ToList<FishingTechInfo>());
				ModelBase<FishingModel>.Instance.SetCageDataMapFromServer(response.FishingInfo.SceneCages.ToDictionary<int, SceneFishCageInfo>());
				ModelBase<FishingModel>.Instance.SetInteractData(response.FishingInfo.HandInInfo.ToList<HandInInfo>());
				ModelBase<FishingModel>.Instance.SetAllFishingPointData(response.FishingInfo.SceneFishPoints.ToDictionary((KeyValuePair<int, SceneFishPointInfo> x) => x.Key, (KeyValuePair<int, SceneFishPointInfo> x) => x.Value));
				ModelBase<FishingModel>.Instance.SetHandBookData(response.FishingInfo.IllustratedInfo);
				ModelBase<FishingQuestModel>.Instance.EntrustRefreshCostRatio = response.FishingInfo.EntrustRefreshRatio;
				Singleton<EventSystem>.Instance.Emit(EEventName.OnRefreshTempFishingPointNum);
			}, 0);
		}

		// Token: 0x06042550 RID: 271696 RVA: 0x011035B4 File Offset: 0x011017B4
		private void ShowFishingLevelUp(IProto_NormalItem normalItem, int count, int lastCount)
		{
			if (normalItem.Id == ModelBase<FishingModel>.Instance.FishingReputationItemId)
			{
				FishingLevelUpData fishingLevelUpData = new FishingLevelUpData(lastCount, count);
				ModelBase<FishingModel>.Instance.SetFishingLevelUpInfo(fishingLevelUpData);
				Singleton<UiManager>.Instance.OpenView(EUiViewName.FishingLevelUpTips, fishingLevelUpData, null);
			}
		}

		// Token: 0x06042551 RID: 271697 RVA: 0x011035F8 File Offset: 0x011017F8
		private void OnCloseViewFinish(EUiViewName viewName, int i)
		{
			if (viewName != EUiViewName.DockyardWareHouseView && viewName != EUiViewName.CommonRewardView)
			{
				return;
			}
			FishingLevelUpData fishingLevelUpInfo = ModelBase<FishingModel>.Instance.GetFishingLevelUpInfo();
			if (fishingLevelUpInfo != null && fishingLevelUpInfo.IsLevelUp())
			{
				this.TryOpenFishingLevelUpView();
			}
		}

		// Token: 0x06042552 RID: 271698 RVA: 0x0110363C File Offset: 0x0110183C
		private void TryOpenFishingLevelUpView()
		{
			if (!this.CanOpenFishingLevelUpView())
			{
				return;
			}
			FishingLevelUpData fishingLevelUpInfo = ModelBase<FishingModel>.Instance.GetFishingLevelUpInfo();
			ModelBase<FishingModel>.Instance.ClearLastFishingExp();
			Singleton<UiManager>.Instance.OpenView(EUiViewName.FishingLevelUpView, fishingLevelUpInfo, null);
		}

		// Token: 0x06042553 RID: 271699 RVA: 0x01103678 File Offset: 0x01101878
		private bool CanOpenFishingLevelUpView()
		{
			return Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.BattleView) || (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.FishingQuestView) && ModelBase<FishingModel>.Instance.IsInDock);
		}

		// Token: 0x06042554 RID: 271700 RVA: 0x011036AC File Offset: 0x011018AC
		public void RequestMultiFishingIllustratedRewardRequest(int[] rewardIds)
		{
			MulFishingIllustratedRewardRequest mulFishingIllustratedRewardRequest = MulFishingIllustratedRewardRequest.Create();
			mulFishingIllustratedRewardRequest.RewardId.AddRange(rewardIds);
			Singleton<Net>.Instance.Call<MulFishingIllustratedRewardResponse>(ERequestMessageId.MulFishingIllustratedRewardRequest, mulFishingIllustratedRewardRequest, delegate(MulFishingIllustratedRewardResponse response, Net.CallbackStatus _)
			{
				if (response == null)
				{
					return;
				}
				if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 19179, null, true, true);
				}
			}, 0);
		}

		// Token: 0x06042555 RID: 271701 RVA: 0x011036FC File Offset: 0x011018FC
		private unsafe void PrintRequestRightFishingDataListLog(List<FishingItemInfo> dataList, CabinType type)
		{
			if (ModelBase<DockyardModel>.Instance.IsPrintLog)
			{
				StringBuilder stringBuilder = new StringBuilder();
				foreach (FishingItemInfo fishingItemInfo in dataList)
				{
					stringBuilder.Append("\n");
					StringBuilder stringBuilder2 = stringBuilder;
					StringBuilder stringBuilder3 = stringBuilder2;
					StringBuilder.AppendInterpolatedStringHandler appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(53, 5, stringBuilder2);
					appendInterpolatedStringHandler.AppendLiteral("IcId: ");
					appendInterpolatedStringHandler.AppendFormatted<int>(fishingItemInfo.IncrId);
					appendInterpolatedStringHandler.AppendLiteral(", ItemId: ");
					appendInterpolatedStringHandler.AppendFormatted<int>(fishingItemInfo.ItemId);
					appendInterpolatedStringHandler.AppendLiteral(", RowIndex: ");
					appendInterpolatedStringHandler.AppendFormatted<int>(fishingItemInfo.Pos.Y);
					appendInterpolatedStringHandler.AppendLiteral(", ColumnIndex: ");
					appendInterpolatedStringHandler.AppendFormatted<int>(fishingItemInfo.Pos.X);
					appendInterpolatedStringHandler.AppendLiteral(", Rotate: ");
					appendInterpolatedStringHandler.AppendFormatted<FishingItemRotate>(fishingItemInfo.Rotate);
					stringBuilder3.Append(ref appendInterpolatedStringHandler);
				}
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Dockyard;
				ELogAuthor author = ELogAuthor.XXJ;
				string message = "输出请求前的背包数据信息";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("请求类型", type);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("背包道具信息", stringBuilder.ToString());
				instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			}
		}

		// Token: 0x06042556 RID: 271702 RVA: 0x0110386C File Offset: 0x01101A6C
		public void RequestFishingCabinPut(IRequestCabinPut requestData)
		{
			FishingCabinPutRequest fishingCabinPutRequest = FishingCabinPutRequest.Create();
			fishingCabinPutRequest.CabinType = requestData.Type;
			fishingCabinPutRequest.Id = requestData.RequestId.GetValueOrDefault();
			fishingCabinPutRequest.LeftFishingItems.AddRange(requestData.LeftDataList);
			fishingCabinPutRequest.RightFishingItems.AddRange(requestData.RightDataList);
			fishingCabinPutRequest.RemoveIncrId = requestData.RemoveIncId.GetValueOrDefault();
			this.PrintRequestRightFishingDataListLog(requestData.RightDataList, requestData.Type);
			Singleton<Net>.Instance.Call<FishingCabinPutResponse>(ERequestMessageId.FishingCabinPutRequest, fishingCabinPutRequest, delegate(FishingCabinPutResponse response, Net.CallbackStatus _)
			{
				if (response == null)
				{
					return;
				}
				bool flag = response.ErrorCode == Aki.Protocol.ErrorCode.Success;
				if (!flag)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 24704, null, true, true);
				}
				Action<bool> callback = requestData.Callback;
				if (callback == null)
				{
					return;
				}
				callback(flag);
			}, 0);
		}

		// Token: 0x06042557 RID: 271703 RVA: 0x01103934 File Offset: 0x01101B34
		public void RequestFishingQuickSell(Action<bool> callback)
		{
			FishingQuickSellRequest message = FishingQuickSellRequest.Create();
			Singleton<Net>.Instance.Call<FishingQuickSellResponse>(ERequestMessageId.FishingQuickSellRequest, message, delegate(FishingQuickSellResponse response, Net.CallbackStatus _)
			{
				if (response == null)
				{
					return;
				}
				bool flag = response.ErrorCode == Aki.Protocol.ErrorCode.Success;
				if (!flag)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 22350, null, true, true);
				}
				callback(flag);
			}, 0);
		}

		// Token: 0x06042558 RID: 271704 RVA: 0x01103974 File Offset: 0x01101B74
		public void TryRequestFishingSell(List<int> incIdList, List<int> itemIdList, bool banSkip, Action<bool> callback)
		{
			if (ModelBase<FishingQuestModel>.Instance.OnFishingItemSell(itemIdList, banSkip, delegate
			{
				this.RequestFishingSell(incIdList, callback);
			}))
			{
				return;
			}
			this.RequestFishingSell(incIdList, callback);
		}

		// Token: 0x06042559 RID: 271705 RVA: 0x011039CC File Offset: 0x01101BCC
		public void RequestFishingSell(List<int> incIdList, Action<bool> callback)
		{
			FishingSellRequest fishingSellRequest = FishingSellRequest.Create();
			fishingSellRequest.IncrIds.AddRange(incIdList);
			Singleton<Net>.Instance.Call<FishingSellResponse>(ERequestMessageId.FishingSellRequest, fishingSellRequest, delegate(FishingSellResponse response, Net.CallbackStatus _)
			{
				if (response == null)
				{
					return;
				}
				bool flag = response.ErrorCode == Aki.Protocol.ErrorCode.Success;
				if (!flag)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 16427, null, true, true);
				}
				callback(flag);
			}, 0);
		}

		// Token: 0x0604255A RID: 271706 RVA: 0x01103A18 File Offset: 0x01101C18
		public void RequestFishingSailingRequest(bool fix, int portId, int time)
		{
			FishingSailingRequest fishingSailingRequest = FishingSailingRequest.Create();
			fishingSailingRequest.Fix = fix;
			fishingSailingRequest.PortId = portId;
			Singleton<Net>.Instance.Call<FishingSailingResponse>(ERequestMessageId.FishingSailingRequest, fishingSailingRequest, delegate(FishingSailingResponse response, Net.CallbackStatus _)
			{
				if (response == null)
				{
					return;
				}
				if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 22805, null, true, true);
					return;
				}
				Singleton<UiManager>.Instance.CloseView(EUiViewName.SailingView, null);
				Singleton<UiManager>.Instance.CloseView(EUiViewName.FishingDockView, null);
				ModelBase<FishingModel>.Instance.SaveLocalSailingIsFix(fix);
				if (time == 1)
				{
					ControllerBase<TimeOfDayController>.Instance.AdjustTime(18000.0, SceneDateUpdateReason.LevelPlayAuto, 0U, true);
				}
				else if (time == 2)
				{
					ControllerBase<TimeOfDayController>.Instance.AdjustTime(68400.0, SceneDateUpdateReason.LevelPlayAuto, 0U, true);
				}
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnFishingSailing, ModelBase<FishingQuestModel>.Instance.CurrentTraceEntrust);
			}, 0);
		}

		// Token: 0x0604255B RID: 271707 RVA: 0x01103A70 File Offset: 0x01101C70
		public void RequestFishingShipFixRequest()
		{
			FishingShipFixRequest message = FishingShipFixRequest.Create();
			Singleton<Net>.Instance.Call<FishingShipFixResponse>(ERequestMessageId.FishingShipFixRequest, message, delegate(FishingShipFixResponse response, Net.CallbackStatus _)
			{
				if (response == null)
				{
					return;
				}
				if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 28661, null, true, true);
				}
			}, 0);
		}

		// Token: 0x0604255C RID: 271708 RVA: 0x01103AB4 File Offset: 0x01101CB4
		public void RequestFishingEntrustHandInRequest(int entrustId, IReadOnlyList<FishingHandInItem> itemList)
		{
			FishingEntrustHandInRequest fishingEntrustHandInRequest = FishingEntrustHandInRequest.Create();
			fishingEntrustHandInRequest.EntrustId = entrustId;
			fishingEntrustHandInRequest.HandInItem.AddRange(itemList);
			Singleton<Net>.Instance.Call<FishingEntrustHandInResponse>(ERequestMessageId.FishingEntrustHandInRequest, fishingEntrustHandInRequest, delegate(FishingEntrustHandInResponse response, Net.CallbackStatus _)
			{
				if (response == null)
				{
					return;
				}
				if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 15438, null, true, true);
					return;
				}
				Singleton<EventSystem>.Instance.Emit<bool, int?>(EEventName.FishingRefreshQuestView, false, null);
				ModelBase<FishingQuestModel>.Instance.AutoTraceEntrust();
			}, 0);
		}

		// Token: 0x0604255D RID: 271709 RVA: 0x01103B0C File Offset: 0x01101D0C
		public void RequestFishingEntrustTrace(int entrustId)
		{
			FishingEntrustTraceRequest fishingEntrustTraceRequest = FishingEntrustTraceRequest.Create();
			fishingEntrustTraceRequest.EntrustId = entrustId;
			Singleton<Net>.Instance.Call<FishingEntrustTraceResponse>(ERequestMessageId.FishingEntrustTraceRequest, fishingEntrustTraceRequest, delegate(FishingEntrustTraceResponse response, Net.CallbackStatus _)
			{
				if (response == null)
				{
					return;
				}
				if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 27197, null, true, true);
					ModelBase<FishingQuestModel>.Instance.TraceFormClick = false;
					return;
				}
				Singleton<EventSystem>.Instance.Emit<bool, int?>(EEventName.FishingRefreshQuestView, true, null);
			}, 0);
		}

		// Token: 0x0604255E RID: 271710 RVA: 0x01103B58 File Offset: 0x01101D58
		public void RequestFishingEntrustRefresh(int entrustId)
		{
			FishingEntrustRefreshRequest fishingEntrustRefreshRequest = FishingEntrustRefreshRequest.Create();
			fishingEntrustRefreshRequest.EntrustId = entrustId;
			Singleton<Net>.Instance.Call<FishingEntrustRefreshResponse>(ERequestMessageId.FishingEntrustRefreshRequest, fishingEntrustRefreshRequest, delegate(FishingEntrustRefreshResponse response, Net.CallbackStatus _)
			{
				if (response == null)
				{
					return;
				}
				if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 18982, null, true, true);
					return;
				}
				int entrustId2 = response.EntrustId;
				Singleton<EventSystem>.Instance.Emit<bool, int?>(EEventName.FishingRefreshQuestView, false, new int?(entrustId2));
			}, 0);
		}

		// Token: 0x0604255F RID: 271711 RVA: 0x01103BA4 File Offset: 0x01101DA4
		public void RequestFishingEntrustAccept(int entrustId, bool isAccept, Action func = null)
		{
			FishingEntrustAcceptRequest fishingEntrustAcceptRequest = FishingEntrustAcceptRequest.Create();
			fishingEntrustAcceptRequest.EntrustId = entrustId;
			fishingEntrustAcceptRequest.Accept = isAccept;
			Singleton<Net>.Instance.Call<FishingEntrustAcceptResponse>(ERequestMessageId.FishingEntrustAcceptRequest, fishingEntrustAcceptRequest, delegate(FishingEntrustAcceptResponse response, Net.CallbackStatus _)
			{
				if (response == null)
				{
					return;
				}
				if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 29762, null, true, true);
					return;
				}
				Singleton<EventSystem>.Instance.Emit<bool, int?>(EEventName.FishingRefreshQuestView, true, null);
				Action func2 = func;
				if (func2 == null)
				{
					return;
				}
				func2();
			}, 0);
		}

		// Token: 0x06042560 RID: 271712 RVA: 0x01103BF0 File Offset: 0x01101DF0
		public void RequestFishingTechLevelUp(int nodeId)
		{
			FishingTechLevelUpRequest fishingTechLevelUpRequest = FishingTechLevelUpRequest.Create();
			fishingTechLevelUpRequest.NodeId = nodeId;
			Singleton<Net>.Instance.Call<FishingTechLevelUpResponse>(ERequestMessageId.FishingTechLevelUpRequest, fishingTechLevelUpRequest, delegate(FishingTechLevelUpResponse response, Net.CallbackStatus _)
			{
				if (response == null)
				{
					return;
				}
				if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 23064, null, true, true);
					return;
				}
				FishingTech fishingTechById = ConfigBase<FishingConfig>.Instance.GetFishingTechById(nodeId);
				int techNodeCurrentLevel = ModelBase<FishingModel>.Instance.GetTechNodeCurrentLevel(nodeId);
				if (techNodeCurrentLevel == 0)
				{
					return;
				}
				FishingTechEffect fishingTechEffectById = ConfigBase<FishingConfig>.Instance.GetFishingTechEffectById(fishingTechById.Effect(techNodeCurrentLevel - 1));
				LevelUpSuccessEffectData param = new LevelUpSuccessEffectData
				{
					Title = "FishingTechLevelUpSuccessTitle",
					TextList = new List<SingleText>
					{
						new SingleText
						{
							TextId = fishingTechEffectById.Desc,
							Params = fishingTechEffectById.ShowParams()
						}
					}
				};
				Singleton<UiManager>.Instance.OpenView(EUiViewName.FishingTechLevelUpSuccessView, param, null);
				this.PlayRoleTechAudio((EFishingTechNodeType)fishingTechById.Type);
			}, 0);
		}

		// Token: 0x06042561 RID: 271713 RVA: 0x01103C40 File Offset: 0x01101E40
		public UniTask RequestFishingPointInfo(int sceneId, int id)
		{
			FishingController.<RequestFishingPointInfo>d__41 <RequestFishingPointInfo>d__;
			<RequestFishingPointInfo>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RequestFishingPointInfo>d__.sceneId = sceneId;
			<RequestFishingPointInfo>d__.id = id;
			<RequestFishingPointInfo>d__.<>1__state = -1;
			<RequestFishingPointInfo>d__.<>t__builder.Start<FishingController.<RequestFishingPointInfo>d__41>(ref <RequestFishingPointInfo>d__);
			return <RequestFishingPointInfo>d__.<>t__builder.Task;
		}

		// Token: 0x06042562 RID: 271714 RVA: 0x01103C8C File Offset: 0x01101E8C
		public void RequestFishingShipSkinChange(int skinId)
		{
			FishingShipSkinChangeRequest fishingShipSkinChangeRequest = FishingShipSkinChangeRequest.Create();
			fishingShipSkinChangeRequest.SkinId = skinId;
			fishingShipSkinChangeRequest.PortId = ModelBase<FishingModel>.Instance.DockId;
			Singleton<Net>.Instance.Call<FishingShipSkinChangeResponse>(ERequestMessageId.FishingShipSkinChangeRequest, fishingShipSkinChangeRequest, delegate(FishingShipSkinChangeResponse response, Net.CallbackStatus _)
			{
				if (response == null)
				{
					return;
				}
				if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 17864, null, true, true);
					return;
				}
				ModelBase<FishingModel>.Instance.CurrentShipSkin = skinId;
				Singleton<EventSystem>.Instance.Emit(EEventName.FishingShipSkinChangeSuccess);
			}, 0);
		}

		// Token: 0x06042563 RID: 271715 RVA: 0x01103CE5 File Offset: 0x01101EE5
		private void RecordNeedShowExitConfirmBox(bool isSelectOn)
		{
			ModelBase<DockyardModel>.Instance.IsNeedShowExitConfirmBox = !isSelectOn;
		}

		// Token: 0x06042564 RID: 271716 RVA: 0x01103CF8 File Offset: 0x01101EF8
		public void ShowExitFishingViewConfirm(Action closeFunc)
		{
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.DockyardExitFishing);
			confirmBoxDataNew.FunctionMap[2] = closeFunc;
			confirmBoxDataNew.HasToggle = true;
			confirmBoxDataNew.ToggleText = ConfigMultiTextLang.GetLocalTextNew("Fishing_LoginRepeat", null);
			confirmBoxDataNew.SetToggleFunction(new Action<bool>(this.RecordNeedShowExitConfirmBox));
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
		}

		// Token: 0x06042565 RID: 271717 RVA: 0x01103D54 File Offset: 0x01101F54
		[NullableContext(2)]
		public void ShowConfirmBoxAndRequestFishingExit(Action<bool> callback = null)
		{
			bool flag = ModelBase<DockyardModel>.Instance.GetWareHouseDataSize() > 0;
			Action<bool> <>9__1;
			Action action = delegate()
			{
				FishingController instance = ControllerBase<FishingController>.Instance;
				Action<bool> callback2;
				if ((callback2 = <>9__1) == null)
				{
					callback2 = (<>9__1 = delegate(bool success)
					{
						FishingQteGameInfo gameInfo = ModelBase<FishingQteModel>.Instance.GameInfo;
						if (gameInfo != null)
						{
							gameInfo.SetGameStage(EFishingQteStage.Destroy);
						}
						Action<bool> callback3 = callback;
						if (callback3 == null)
						{
							return;
						}
						callback3(success);
					});
				}
				instance.RequestFishingExit(callback2);
			};
			if (flag && ModelBase<DockyardModel>.Instance.IsNeedShowExitConfirmBox)
			{
				ControllerBase<FishingController>.Instance.ShowExitFishingViewConfirm(action);
				return;
			}
			action();
		}

		// Token: 0x06042566 RID: 271718 RVA: 0x01103DA8 File Offset: 0x01101FA8
		[NullableContext(2)]
		public void RequestFishingExit(Action<bool> callback = null)
		{
			FishingExitRequest message = FishingExitRequest.Create();
			Singleton<Net>.Instance.Call<FishingExitResponse>(ERequestMessageId.FishingExitRequest, message, delegate(FishingExitResponse response, Net.CallbackStatus _)
			{
				if (response == null)
				{
					Action<bool> callback2 = callback;
					if (callback2 == null)
					{
						return;
					}
					callback2(false);
					return;
				}
				else
				{
					Action<bool> callback3 = callback;
					if (callback3 == null)
					{
						return;
					}
					callback3(true);
					return;
				}
			}, 0);
		}

		// Token: 0x06042567 RID: 271719 RVA: 0x01103DE5 File Offset: 0x01101FE5
		public bool IsInFishingShip()
		{
			return ModelBase<FishingModel>.Instance.GetShipData().IsShipDriving();
		}

		// Token: 0x06042568 RID: 271720 RVA: 0x01103DF8 File Offset: 0x01101FF8
		public void ConfirmToTeleportToPort(Action closeFunc)
		{
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.ConfirmToTeleportToPort);
			confirmBoxDataNew.FunctionMap[2] = closeFunc;
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
		}

		// Token: 0x06042569 RID: 271721 RVA: 0x01103E2C File Offset: 0x0110202C
		public void TeleportToPortPosition(int portId)
		{
			FishingPort fishingPortConfig = ConfigBase<FishingConfig>.Instance.GetFishingPortConfig(portId);
			FishingPosition fishingPortPosition = ConfigBase<FishingConfig>.Instance.GetFishingPortPosition(fishingPortConfig.AshorePoint);
			EntityHandle entityHandle = ModelBase<FishingModel>.Instance.GetShipData().GetEntityHandle();
			object obj;
			if (entityHandle == null)
			{
				obj = null;
			}
			else
			{
				WorldEntity entity = entityHandle.Entity;
				obj = ((entity != null) ? entity.GetComponent<BaseVehiclePerformComponent>() : null);
			}
			object obj2 = obj;
			if (obj2 != null)
			{
				obj2.TryLeave(Global.BaseCharacter.CharacterActorComponent.Entity, ELeaveVehicleType.StandUp);
			}
			int[] array = fishingPortPosition.Position();
			global::Vector vector = global::Vector.Create((double)array[0], (double)array[1], (double)array[2]);
			int[] array2 = fishingPortPosition.Rotation();
			global::Rotator rotator = global::Rotator.Create((float)array2[1], (float)array2[2], (float)array2[0]);
			ITeleportContextParam param = new ITeleportContextParam
			{
				ClientReason = "FishingController",
				TargetPosition = vector.ToUeVector(false),
				TargetRotation = rotator.ToUeRotator()
			};
			ControllerBase<TeleportController>.Instance.TeleportPlayer(param);
		}

		// Token: 0x0604256A RID: 271722 RVA: 0x01103F14 File Offset: 0x01102114
		public void RequestFishingHandIn(IRequestHandleIn requestData)
		{
			FishingHandInRequest fishingHandInRequest = FishingHandInRequest.Create();
			fishingHandInRequest.Id = requestData.InteractId;
			fishingHandInRequest.LeftFishingItems.AddRange(requestData.LeftDataList);
			fishingHandInRequest.RightFishingItems.AddRange(requestData.RightDataList);
			fishingHandInRequest.RemoveIncrId = requestData.RemoveIncId.GetValueOrDefault();
			fishingHandInRequest.ActionIncrId = requestData.ActionIncId;
			Singleton<Net>.Instance.Call<FishingHandInResponse>(ERequestMessageId.FishingHandInRequest, fishingHandInRequest, delegate(FishingHandInResponse response, Net.CallbackStatus _)
			{
				if (response == null)
				{
					return;
				}
				bool flag = response.ErrorCode == Aki.Protocol.ErrorCode.Success;
				if (!flag)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 24484, null, true, true);
				}
				Action<bool, bool> callback = requestData.Callback;
				if (callback == null)
				{
					return;
				}
				callback(flag, response.HandInComplete);
			}, 0);
		}

		// Token: 0x0604256B RID: 271723 RVA: 0x01103FB8 File Offset: 0x011021B8
		public EFishingSkillCheckResult CheckFishingSkillCanBegin(EFishingSkillType type)
		{
			if (type != EFishingSkillType.炸鱼)
			{
				if (type != EFishingSkillType.鱼饵)
				{
					return EFishingSkillCheckResult.Usable;
				}
				if (!this.CheckFishingSkillCostEnough())
				{
					return EFishingSkillCheckResult.ItemNotEnough;
				}
				if (ModelBase<FishingModel>.Instance.GetTempFishingPointNum() >= ModelBase<FishingModel>.Instance.GetTempFishingPointLimit())
				{
					return EFishingSkillCheckResult.TempFishingPointLimit;
				}
				return EFishingSkillCheckResult.Usable;
			}
			else
			{
				if (!this.CheckFishingSkillCostEnough())
				{
					return EFishingSkillCheckResult.ItemNotEnough;
				}
				return EFishingSkillCheckResult.Usable;
			}
		}

		// Token: 0x0604256C RID: 271724 RVA: 0x01103FF8 File Offset: 0x011021F8
		public void ShowFishingSkillTips(EFishingSkillType type, EFishingSkillCheckResult result)
		{
			switch (result)
			{
			case EFishingSkillCheckResult.ItemNotEnough:
				if (type == EFishingSkillType.炸鱼)
				{
					ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Fishing_SkillTip1", Array.Empty<object>());
					return;
				}
				if (type == EFishingSkillType.鱼饵)
				{
					ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Fishing_SkillTip3", Array.Empty<object>());
					return;
				}
				break;
			case EFishingSkillCheckResult.SkillInCd:
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Fishing_SkillTip2", Array.Empty<object>());
				return;
			case EFishingSkillCheckResult.TempFishingPointLimit:
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Fishing_SkillTip6", Array.Empty<object>());
				break;
			default:
				return;
			}
		}

		// Token: 0x0604256D RID: 271725 RVA: 0x01104075 File Offset: 0x01102275
		public void BeginFishingSkill(EFishingSkillType type)
		{
			switch (type)
			{
			case EFishingSkillType.传送:
				ControllerBase<FishingController>.Instance.RequestFishingSkillTeleport();
				return;
			case EFishingSkillType.炸鱼:
				ControllerBase<FishingController>.Instance.RequestFishingSkillBomb();
				return;
			case EFishingSkillType.鱼饵:
				ControllerBase<FishingController>.Instance.RequestFishingSkillBait();
				return;
			default:
				return;
			}
		}

		// Token: 0x0604256E RID: 271726 RVA: 0x011040AC File Offset: 0x011022AC
		private void RequestFishingSkillTeleport()
		{
			FishingSkillTeleportRequest message = FishingSkillTeleportRequest.Create();
			Singleton<Net>.Instance.Call<FishingSkillTeleportResponse>(ERequestMessageId.FishingSkillTeleportRequest, message, delegate(FishingSkillTeleportResponse _, Net.CallbackStatus _)
			{
			}, 0);
		}

		// Token: 0x0604256F RID: 271727 RVA: 0x011040F0 File Offset: 0x011022F0
		private void RequestFishingSkillBomb()
		{
			int fishingSkillCostId = this.GetFishingSkillCostId();
			if (fishingSkillCostId <= 0)
			{
				return;
			}
			FishingSkillBombRequest fishingSkillBombRequest = FishingSkillBombRequest.Create();
			fishingSkillBombRequest.ItemId = fishingSkillCostId;
			Singleton<Net>.Instance.Call<FishingSkillBombResponse>(ERequestMessageId.FishingSkillBombRequest, fishingSkillBombRequest, delegate(FishingSkillBombResponse response, Net.CallbackStatus _)
			{
				if (response == null || response.ErrorCode != Aki.Protocol.ErrorCode.Success)
				{
					return;
				}
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Fishing_SkillTip5", Array.Empty<object>());
				List<DockyardItemBlockOriginalData> list = new List<DockyardItemBlockOriginalData>();
				foreach (FishingItemInfo data in response.Items)
				{
					DockyardItemBlockOriginalData item = new DockyardItemBlockOriginalData(data);
					list.Add(item);
				}
				ControllerBase<FishingQteController>.Instance.OpenFishingSuccessView(list, null);
			}, 0);
		}

		// Token: 0x06042570 RID: 271728 RVA: 0x01104148 File Offset: 0x01102348
		private void RequestFishingSkillBait()
		{
			int fishingSkillCostId = this.GetFishingSkillCostId();
			if (fishingSkillCostId <= 0)
			{
				return;
			}
			FishingSkillBaitRequest fishingSkillBaitRequest = FishingSkillBaitRequest.Create();
			fishingSkillBaitRequest.ItemId = fishingSkillCostId;
			Singleton<Net>.Instance.Call<FishingSkillBaitResponse>(ERequestMessageId.FishingSkillBaitRequest, fishingSkillBaitRequest, delegate(FishingSkillBaitResponse response, Net.CallbackStatus _)
			{
				if (response != null && response.ErrorCode == Aki.Protocol.ErrorCode.Success)
				{
					ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Fishing_SkillTip4", Array.Empty<object>());
				}
			}, 0);
		}

		// Token: 0x06042571 RID: 271729 RVA: 0x011041A0 File Offset: 0x011023A0
		private bool CheckFishingSkillCostEnough()
		{
			int fishingSkillCostId = this.GetFishingSkillCostId();
			return fishingSkillCostId > 0 && ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(fishingSkillCostId, 0) > 0;
		}

		// Token: 0x06042572 RID: 271730 RVA: 0x011041CC File Offset: 0x011023CC
		public int GetFishingSkillCostId()
		{
			int currentExploreSkillId = ModelBase<RouletteModel>.Instance.CurrentExploreSkillId;
			ExploreTools value;
			ExploreTools? exploreTools = ModelBase<RouletteModel>.Instance.UnlockExploreSkillDataMap.TryGetValue(currentExploreSkillId, out value) ? new ExploreTools?(value) : null;
			if (exploreTools == null)
			{
				return 0;
			}
			Dictionary<int, int> dictionary = exploreTools.Value.Cost();
			if (dictionary.Count <= 0)
			{
				return 0;
			}
			return dictionary.Keys.First<int>();
		}

		// Token: 0x06042573 RID: 271731 RVA: 0x0110423D File Offset: 0x0110243D
		public void FishingTeleportToBoat()
		{
			if (!ModelBase<TeleportModel>.Instance.AllowTeleportByUi)
			{
				ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("TrialRoleTransmitLimit", Array.Empty<object>());
				return;
			}
			if (TeleportMisc.ShowTeleportConfirmBox(new Action(this.RequestFishingTeleportToBoat)))
			{
				return;
			}
			this.RequestFishingTeleportToBoat();
		}

		// Token: 0x06042574 RID: 271732 RVA: 0x0110427C File Offset: 0x0110247C
		private void RequestFishingTeleportToBoat()
		{
			ModelBase<GameModeModel>.Instance.IsTeleport = true;
			FishingTeleportToBoatRequest message = FishingTeleportToBoatRequest.Create();
			Singleton<Net>.Instance.Call<FishingTeleportToBoatResponse>(ERequestMessageId.FishingTeleportToBoatRequest, message, delegate(FishingTeleportToBoatResponse response, Net.CallbackStatus _)
			{
				if (response != null && response.ErrorCode != Aki.Protocol.ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 15169, null, true, true);
				}
				ModelBase<GameModeModel>.Instance.IsTeleport = false;
			}, 0);
		}

		// Token: 0x06042575 RID: 271733 RVA: 0x011042CC File Offset: 0x011024CC
		public void PlayRoleTechAudio(EFishingTechNodeType type)
		{
			this.StopRoleTechAudio();
			double num = Math.Ceiling(new Random().NextDouble() * 3.0);
			string text = "";
			if (type == EFishingTechNodeType.MainRole)
			{
				text = ((ModelBase<PlayerInfoModel>.Instance.GetPlayerGender() == EPlayerGender.Female) ? "play_vo_nvzhu_sys_fishing_techupgrade0" : "play_vo_nanzhu_sys_fishing_techupgrade0");
			}
			else if (type == EFishingTechNodeType.Phoebe)
			{
				text = "play_vo_feibi_sys_fishing_techupgrade0";
			}
			if (text == "")
			{
				return;
			}
			text += num.ToString();
			this.RoleTechAudioHandle = text;
			Singleton<AudioSystem>.Instance.PostEvent(text);
		}

		// Token: 0x06042576 RID: 271734 RVA: 0x01104358 File Offset: 0x01102558
		public void StopRoleTechAudio()
		{
			if (!StringUtils.IsEmpty(this.RoleTechAudioHandle))
			{
				Singleton<AudioSystem>.Instance.ExecuteAction(this.RoleTechAudioHandle, EAudioActionType.Stop, null);
				this.RoleTechAudioHandle = "";
			}
		}

		// Token: 0x06042577 RID: 271735 RVA: 0x01104398 File Offset: 0x01102598
		public void HideEffectInWorld()
		{
			foreach (int pbDataId in FishingDefine.fishingEffectList)
			{
				EntityHandle entityByPbDataId = ModelBase<CreatureModel>.Instance.GetEntityByPbDataId(pbDataId);
				if (entityByPbDataId != null)
				{
					WorldEntity entity = entityByPbDataId.Entity;
					if (entity != null)
					{
						entity.DisableByKey(EEntityDisableKey.FishingEffect, true);
					}
				}
			}
		}

		// Token: 0x06042578 RID: 271736 RVA: 0x01104408 File Offset: 0x01102608
		public void ShowEffectInWorld()
		{
			foreach (int pbDataId in FishingDefine.fishingEffectList)
			{
				EntityHandle entityByPbDataId = ModelBase<CreatureModel>.Instance.GetEntityByPbDataId(pbDataId);
				if (entityByPbDataId != null)
				{
					WorldEntity entity = entityByPbDataId.Entity;
					if (entity != null)
					{
						entity.EnableByKey(EEntityDisableKey.FishingEffect, true);
					}
				}
			}
		}

		// Token: 0x04024EA4 RID: 151204
		private const int FISHING_SHIP_DEAD_TIME = 1300;

		// Token: 0x04024EA5 RID: 151205
		private string RoleTechAudioHandle = "";
	}
}
