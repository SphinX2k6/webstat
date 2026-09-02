using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using Aki.TDConfigMgr.Quest;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.LevelGamePlay;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Game.Module.Map;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.Map.Mark;
using CSharpScript.Game.Module.Map.Misc;
using CSharpScript.Game.Module.Map.View.BaseMap.Assistant.MapLifeEvent;
using CSharpScript.Game.Module.Teleport;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;

namespace CSharpScript.Game.Module.WorldMap
{
	// Token: 0x02004B1B RID: 19227
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class WorldMapController : UiControllerBase<WorldMapController>
	{
		// Token: 0x060322A0 RID: 205472 RVA: 0x00C8E1C0 File Offset: 0x00C8C3C0
		protected override bool OnInit()
		{
			Singleton<InputManager>.Instance.RegisterOpenViewFunc(EUiViewName.WorldMapView, new Action(this.RegisterOpenView));
			return true;
		}

		// Token: 0x060322A1 RID: 205473 RVA: 0x00C8E1DE File Offset: 0x00C8C3DE
		private void RegisterOpenView()
		{
			this.OpenView(EOpenMapType.HotKey, true, null, null);
		}

		// Token: 0x060322A2 RID: 205474 RVA: 0x00C8E1EA File Offset: 0x00C8C3EA
		protected override bool OnLeaveLevel()
		{
			if (this.CheckStreamingCompletedTimerId != null && TimerSystem.GameplayTimeInstance.Has(this.CheckStreamingCompletedTimerId))
			{
				TimerSystem.GameplayTimeInstance.Remove(this.CheckStreamingCompletedTimerId);
			}
			return true;
		}

		// Token: 0x060322A3 RID: 205475 RVA: 0x00C8E218 File Offset: 0x00C8C418
		protected override void OnAddEvents()
		{
			Singleton<EventSystem>.Instance.Add<EUiViewName, int>(EEventName.OpenView, new Action<EUiViewName, int>(this.OnOpenFunctionView));
			Singleton<EventSystem>.Instance.Add<EUiViewName, int>(EEventName.CloseView, new Action<EUiViewName, int>(this.OnCloseFunctionView));
			Singleton<EventSystem>.Instance.Add(EEventName.WorldDone, new Action(this.OnWorldDone));
			Singleton<EventSystem>.Instance.Add(EEventName.CsNotifyTsOpenWorldMapView, new Action<EMarkType, int, bool>(this.OnCsNotifyOpenWorldMapView));
		}

		// Token: 0x060322A4 RID: 205476 RVA: 0x00C8E290 File Offset: 0x00C8C490
		protected override void OnRemoveEvents()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OpenView, new Action<EUiViewName, int>(this.OnOpenFunctionView));
			Singleton<EventSystem>.Instance.Remove(EEventName.CloseView, new Action<EUiViewName, int>(this.OnCloseFunctionView));
			Singleton<EventSystem>.Instance.Remove(EEventName.WorldDone, new Action(this.OnWorldDone));
			Singleton<EventSystem>.Instance.Remove(EEventName.CsNotifyTsOpenWorldMapView, new Action<EMarkType, int, bool>(this.OnCsNotifyOpenWorldMapView));
		}

		// Token: 0x060322A5 RID: 205477 RVA: 0x00C8E306 File Offset: 0x00C8C506
		private void OnOpenFunctionView(EUiViewName viewName, int viewId)
		{
			if (viewName != EUiViewName.FunctionOpenView)
			{
				return;
			}
			this.OpenFuncList = ModelBase<FunctionModel>.Instance.GetNewOpenFunctionIdList();
		}

		// Token: 0x060322A6 RID: 205478 RVA: 0x00C8E328 File Offset: 0x00C8C528
		private void OnCloseFunctionView(EUiViewName viewName, int viewId)
		{
			if (viewName != EUiViewName.FunctionOpenView)
			{
				return;
			}
			if (this.OpenFuncList == null)
			{
				return;
			}
			MapMarkRelativeSubType? mapMarkRelativeSubType = null;
			foreach (int functionType in this.OpenFuncList)
			{
				mapMarkRelativeSubType = ConfigBase<MapConfig>.Instance.GetMapMarkFuncTypeConfigByFuncId(functionType);
				if (mapMarkRelativeSubType != null)
				{
					break;
				}
			}
			if (mapMarkRelativeSubType != null)
			{
				WorldMapViewOpenParams data = new WorldMapViewOpenParams
				{
					MarkType = EMarkType.None,
					MarkId = new int?(0),
					StartWorldPosition = Vector2D.Create((double)mapMarkRelativeSubType.Value.Position.Value.X, (double)mapMarkRelativeSubType.Value.Position.Value.Y),
					StartScale = new float?(mapMarkRelativeSubType.Value.Scale),
					OpenFogId = new int?(0)
				};
				if (!ModelBase<LoadingModel>.Instance.IsLoading)
				{
					this.OpenView(EOpenMapType.Other, false, data, null);
					MapLifeEventTriggerParam<MapLifeEventTriggerLevelPlayParam> value = new MapLifeEventTriggerParam<MapLifeEventTriggerLevelPlayParam>
					{
						State = true,
						Data = new MapLifeEventTriggerLevelPlayParam
						{
							RelativeType = EMarkRelativeType.LevelPlay,
							RelativeSubType = mapMarkRelativeSubType.Value.Id
						}
					};
					if (ModelBase<MapModel>.Instance.MapLifeEventListenerTriggerMap != null)
					{
						ModelBase<MapModel>.Instance.MapLifeEventListenerTriggerMap[EMapLifeEventListenerType.SceneGameplayUnlock] = value;
					}
				}
			}
		}

		// Token: 0x060322A7 RID: 205479 RVA: 0x00C8E4B4 File Offset: 0x00C8C6B4
		public void TryTeleport(int teleportId, TOnTelSuccessCallBack successAction = null)
		{
			if (!ModelBase<TeleportModel>.Instance.AllowTeleportByUi)
			{
				ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("TrialRoleTransmitLimit", Array.Empty<object>());
				return;
			}
			if (ModelBase<MapModel>.Instance.IsInstanceTeleportUnlock(teleportId))
			{
				this.TryEntityTeleport(teleportId, successAction);
				return;
			}
			Teleporter? teleportConfigById = ConfigBase<MapConfig>.Instance.GetTeleportConfigById(teleportId);
			if (teleportConfigById == null)
			{
				ELogAuthor author = ELogAuthor.LYX;
				string message = "[地图系统]传送失败,找不到传送配置";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("teleportId", teleportId);
				MapLogger.Error(author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			global::Vector entityPosition = ModelBase<WorldMapModel>.Instance.GetEntityPosition(teleportConfigById.Value.TeleportEntityConfigId, teleportConfigById.Value.MapId);
			if (ControllerBase<QuestNewController>.Instance.IsTrackPositionOutFailRange(entityPosition))
			{
				ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.TeleportOutOfQuestRangeConfirm);
				confirmBoxDataNew.FunctionMap[2] = delegate()
				{
					TeleportMisc.SendTeleportTransferRequest(teleportId);
					TOnTelSuccessCallBack successAction3 = successAction;
					if (successAction3 == null)
					{
						return;
					}
					successAction3();
				};
				ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
				return;
			}
			TeleportMisc.SendTeleportTransferRequest(teleportId);
			TOnTelSuccessCallBack successAction2 = successAction;
			if (successAction2 == null)
			{
				return;
			}
			successAction2();
		}

		// Token: 0x060322A8 RID: 205480 RVA: 0x00C8E5E6 File Offset: 0x00C8C7E6
		public void TryEntityTeleport(int teleportId, TOnTelSuccessCallBack successAction = null)
		{
			if (!ModelBase<TeleportModel>.Instance.AllowTeleportByUi)
			{
				ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("TrialRoleTransmitLimit", Array.Empty<object>());
				return;
			}
			if (!ModelBase<MapModel>.Instance.IsInstanceTeleportUnlock(teleportId))
			{
				return;
			}
			TeleportMisc.SendTeleportTransferRequestByEntityId(teleportId);
			if (successAction != null)
			{
				successAction();
			}
		}

		// Token: 0x060322A9 RID: 205481 RVA: 0x00C8E628 File Offset: 0x00C8C828
		public void TryTeleportByEntityId(int instEntityTeleportId, TOnTelSuccessCallBack successAction = null)
		{
			if (!ModelBase<TeleportModel>.Instance.AllowTeleportByUi)
			{
				ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("TrialRoleTransmitLimit", Array.Empty<object>());
				return;
			}
			if (!ConfigBase<MapConfig>.Instance.GetIsInstanceTeleporterExist(instEntityTeleportId))
			{
				ELogAuthor author = ELogAuthor.LYX;
				string message = "[地图系统]传送失败,找不到传送配置";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("InstEntityTeleportId", instEntityTeleportId);
				MapLogger.Error(author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			if (ConfigBase<MapConfig>.Instance.GetInstEntityTeleportConfigById(instEntityTeleportId) == null)
			{
				return;
			}
			TeleportMisc.SendTeleportTransferRequestByEntityId(instEntityTeleportId);
			if (successAction != null)
			{
				successAction();
			}
		}

		// Token: 0x060322AA RID: 205482 RVA: 0x00C8E6B0 File Offset: 0x00C8C8B0
		public void MapOpenPush(int openType)
		{
			MapOpenPush message = new MapOpenPush
			{
				OpenType = (MapOpenType)openType
			};
			Singleton<Net>.Instance.Send(EPushMessageId.MapOpenPush, message);
		}

		// Token: 0x060322AB RID: 205483 RVA: 0x00C8E6DC File Offset: 0x00C8C8DC
		public void OpenView(EOpenMapType openType, bool isBattleViewOpen, object data = null, Action<bool, int> callback = null)
		{
			WorldMapController.<>c__DisplayClass13_0 CS$<>8__locals1 = new WorldMapController.<>c__DisplayClass13_0();
			CS$<>8__locals1.data = data;
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.openType = openType;
			CS$<>8__locals1.callback = callback;
			if (ModelBase<WorldMapModel>.Instance.PendingOpenWorldMapQuestId != null)
			{
				if (Singleton<EventSystem>.Instance.Has(EEventName.AfterLogicTreeChildQuestNodeStatusChange, new Action<GeneralContext, ChildQuestNodeStatus, ChildQuestNodeStatus>(this.OnChildQuestNodeStatusChanged)))
				{
					Singleton<EventSystem>.Instance.Remove(EEventName.AfterLogicTreeChildQuestNodeStatusChange, new Action<GeneralContext, ChildQuestNodeStatus, ChildQuestNodeStatus>(this.OnChildQuestNodeStatusChanged));
				}
				ModelBase<WorldMapModel>.Instance.PendingOpenWorldMapQuestId = null;
			}
			ModelBase<WorldMapModel>.Instance.IsBattleViewOpen = isBattleViewOpen;
			if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.WorldMapView) || Singleton<UiManager>.Instance.IsViewHide(EUiViewName.WorldMapView))
			{
				Singleton<UiManager>.Instance.CloseViewAsync(EUiViewName.WorldMapView).ContinueWith(delegate(bool _)
				{
					base.<OpenView>g__OpenWorldMapViewFunc|0();
				});
				return;
			}
			CS$<>8__locals1.<OpenView>g__OpenWorldMapViewFunc|0();
		}

		// Token: 0x060322AC RID: 205484 RVA: 0x00C8E7BC File Offset: 0x00C8C9BC
		public void FocalMarkItem(EMarkType markType, int markId)
		{
			WorldMapModel instance = ModelBase<WorldMapModel>.Instance;
			EMarkType? currentFocalMarkType = instance.CurrentFocalMarkType;
			int? currentFocalMarkId = instance.CurrentFocalMarkId;
			EMarkType? emarkType = currentFocalMarkType;
			if (emarkType.GetValueOrDefault() == markType & emarkType != null)
			{
				int? num = currentFocalMarkId;
				if (num.GetValueOrDefault() == markId & num != null)
				{
					goto IL_88;
				}
			}
			if (Singleton<UiManager>.Instance.IsViewShow(EUiViewName.ItemTipsView))
			{
				Singleton<UiManager>.Instance.CloseView(EUiViewName.ItemTipsView, null);
			}
			if (Singleton<UiManager>.Instance.IsViewShow(EUiViewName.CommonRewardView))
			{
				Singleton<UiManager>.Instance.CloseView(EUiViewName.CommonRewardView, null);
			}
			IL_88:
			instance.CurrentFocalMarkType = new EMarkType?(markType);
			instance.CurrentFocalMarkId = new int?(markId);
			if (Singleton<UiManager>.Instance.IsViewShow(EUiViewName.WorldMapView))
			{
				Singleton<UiManager>.Instance.CloseAllPopView();
				Singleton<EventSystem>.Instance.Emit(EEventName.CloseAllExtraUiFromMap);
				Singleton<EventSystem>.Instance.Emit<EMarkType, int>(EEventName.OnWorldMapTrackMarkItem, markType, markId);
				return;
			}
			WorldMapViewOpenParams data = new WorldMapViewOpenParams
			{
				MarkType = markType,
				MarkId = new int?(markId),
				OpenFogId = new int?(0)
			};
			this.OpenView(EOpenMapType.Mouse, false, data, delegate(bool success, int viewId)
			{
				if (success)
				{
					Singleton<UiManager>.Instance.CloseAllPopView();
				}
			});
		}

		// Token: 0x060322AD RID: 205485 RVA: 0x00C8E8F5 File Offset: 0x00C8CAF5
		public void ClearFocalMarkItem()
		{
			WorldMapModel instance = ModelBase<WorldMapModel>.Instance;
			instance.CurrentFocalMarkType = null;
			instance.CurrentFocalMarkId = null;
		}

		// Token: 0x060322AE RID: 205486 RVA: 0x00C8E914 File Offset: 0x00C8CB14
		public void CloseWorldMap()
		{
			if (Singleton<UiManager>.Instance.IsViewShow(EUiViewName.WorldMapView))
			{
				Singleton<EventSystem>.Instance.Emit(EEventName.DestroyAllUiCameraAnimationHandles);
				Singleton<UiManager>.Instance.ResetToBattleView(null);
				return;
			}
			if (Singleton<UiManager>.Instance.IsViewShow(EUiViewName.FunctionView))
			{
				Singleton<UiManager>.Instance.CloseView(EUiViewName.FunctionView, null);
			}
		}

		// Token: 0x060322AF RID: 205487 RVA: 0x00C8E96F File Offset: 0x00C8CB6F
		protected override bool OnClear()
		{
			if (this.CheckStreamingCompletedTimerId != null)
			{
				TimerSystem.GameplayTimeInstance.Remove(this.CheckStreamingCompletedTimerId);
				this.CheckStreamingCompletedTimerId = null;
			}
			return true;
		}

		// Token: 0x060322B0 RID: 205488 RVA: 0x00C8E992 File Offset: 0x00C8CB92
		protected override void OnAddOpenViewCheckFunction()
		{
			Singleton<UiManager>.Instance.AddOpenViewCheckFunction(EUiViewName.WorldMapView, new Func<EUiViewName, object, bool>(this.CanOpenView), "WorldMapController.CanOpenView");
		}

		// Token: 0x060322B1 RID: 205489 RVA: 0x00C8E9B4 File Offset: 0x00C8CBB4
		protected override void OnRemoveOpenViewCheckFunction()
		{
			Singleton<UiManager>.Instance.RemoveOpenViewCheckFunction(EUiViewName.WorldMapView, new Func<EUiViewName, object, bool>(this.CanOpenView));
		}

		// Token: 0x060322B2 RID: 205490 RVA: 0x00C8E9D4 File Offset: 0x00C8CBD4
		[NullableContext(1)]
		private bool CanOpenView(EUiViewName viewName, object param)
		{
			if (ModelBase<WorldMapModel>.Instance.LevelEventDisableFlag)
			{
				ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("DisableMapView", Array.Empty<object>());
				return false;
			}
			if (!ModelBase<FunctionModel>.Instance.IsOpen(10015))
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("PhantomLock", Array.Empty<object>());
				return false;
			}
			if (ModelBase<FunctionModel>.Instance.IsLockByBehaviorTree(10015))
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("UnableSystem", Array.Empty<object>());
				return false;
			}
			return true;
		}

		// Token: 0x060322B3 RID: 205491 RVA: 0x00C8EA52 File Offset: 0x00C8CC52
		private void OnWorldDone()
		{
			this.CheckAndRequestLastBigSceneInfo();
		}

		// Token: 0x060322B4 RID: 205492 RVA: 0x00C8EA5C File Offset: 0x00C8CC5C
		[NullableContext(1)]
		public void FocusNearestTargetOnWorldMap(QueryNearestTeleporterResult result)
		{
			MapTeleportQueryInfo info = result.Info;
			int value = (info != null) ? info.MarkId : result.TargetMarkId;
			MapTeleportQueryInfo info2 = result.Info;
			EMarkType markType = (info2 != null) ? info2.MarkType : result.TargetMarkType;
			WorldMapViewOpenParams data = new WorldMapViewOpenParams
			{
				MarkId = new int?(value),
				MarkType = markType
			};
			this.OpenView(EOpenMapType.Other, false, data, null);
		}

		// Token: 0x060322B5 RID: 205493 RVA: 0x00C8EABC File Offset: 0x00C8CCBC
		private void CheckAndRequestLastBigSceneInfo()
		{
			ILastBigSceneMiniMapInfo lastBigSceneMiniMapInfo = ModelBase<WorldMapModel>.Instance.LastBigSceneMiniMapInfo;
			int num = (lastBigSceneMiniMapInfo != null) ? lastBigSceneMiniMapInfo.InstanceDungeonId : 0;
			int instanceId = ModelBase<CreatureModel>.Instance.GetInstanceId();
			if (ModelBase<MapModel>.Instance.CurrentInWorld)
			{
				ModelBase<WorldMapModel>.Instance.LastBigSceneMiniMapInfo = null;
				return;
			}
			if (ModelBase<WorldMapModel>.Instance.InstIsType(instanceId, InstanceType.BigWorldInstance, EDungeonSubType.WorldDungeon))
			{
				ModelBase<WorldMapModel>.Instance.LastBigSceneMiniMapInfo = null;
				return;
			}
			if (num != instanceId)
			{
				this.RequestLastBigSceneMiniMapInfo(instanceId);
			}
		}

		// Token: 0x060322B6 RID: 205494 RVA: 0x00C8EB2C File Offset: 0x00C8CD2C
		private void RequestLastBigSceneMiniMapInfo(int dungeonId)
		{
			LastBigSceneMiniMapInfoRequest message = LastBigSceneMiniMapInfoRequest.Create();
			Singleton<Net>.Instance.Call<LastBigSceneMiniMapInfoResponse>(ERequestMessageId.LastBigSceneMiniMapInfoRequest, message, delegate(LastBigSceneMiniMapInfoResponse response, Net.CallbackStatus status)
			{
				if (response.Code != Aki.Protocol.ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.Code, 25112, null, true, true);
				}
				LastBigSceneMiniMapInfo lastBigSceneMiniMapInfo = new LastBigSceneMiniMapInfo
				{
					InstanceDungeonId = dungeonId,
					Position = global::Vector.Create((double)response.PosX, (double)response.PosY, (double)response.PosZ)
				};
				ModelBase<WorldMapModel>.Instance.LastBigSceneMiniMapInfo = lastBigSceneMiniMapInfo;
			}, 0);
		}

		// Token: 0x060322B7 RID: 205495 RVA: 0x00C8EB6C File Offset: 0x00C8CD6C
		public void SkipToExploreAreaDetailView(int areaId, EExploreType? exploreType = null)
		{
			if (Singleton<UiManager>.Instance.IsViewShow(EUiViewName.WorldMapView))
			{
				Singleton<EventSystem>.Instance.Emit<int, EExploreType?>(EEventName.OpenExploreAreaDetailViewFromMap, areaId, exploreType);
				return;
			}
			WorldMapViewOpenParams worldMapViewOpenParams = new WorldMapViewOpenParams();
			worldMapViewOpenParams.MarkId = null;
			worldMapViewOpenParams.MarkType = EMarkType.None;
			WorldMapViewOpenParams worldMapViewOpenParams2 = worldMapViewOpenParams;
			int[] array = new int[2];
			array[0] = areaId;
			int num = 1;
			EExploreType? eexploreType = exploreType;
			array[num] = ((eexploreType != null) ? new int?((int)eexploreType.GetValueOrDefault()) : null).GetValueOrDefault();
			worldMapViewOpenParams2.SkipToExploreAreaDetailView = array;
			WorldMapViewOpenParams data = worldMapViewOpenParams;
			this.OpenView(EOpenMapType.Other, false, data, null);
		}

		// Token: 0x060322B8 RID: 205496 RVA: 0x00C8EC04 File Offset: 0x00C8CE04
		public void StartListenChildQuestNodeStatusChangedAndOpenWorldMap(int questId)
		{
			ModelBase<WorldMapModel>.Instance.PendingOpenWorldMapQuestId = new int?(questId);
			if (!Singleton<EventSystem>.Instance.Has(EEventName.AfterLogicTreeChildQuestNodeStatusChange, new Action<GeneralContext, ChildQuestNodeStatus, ChildQuestNodeStatus>(this.OnChildQuestNodeStatusChanged)))
			{
				Singleton<EventSystem>.Instance.Add<GeneralContext, ChildQuestNodeStatus, ChildQuestNodeStatus>(EEventName.AfterLogicTreeChildQuestNodeStatusChange, new Action<GeneralContext, ChildQuestNodeStatus, ChildQuestNodeStatus>(this.OnChildQuestNodeStatusChanged));
			}
		}

		// Token: 0x060322B9 RID: 205497 RVA: 0x00C8EC5C File Offset: 0x00C8CE5C
		[NullableContext(1)]
		private void OnChildQuestNodeStatusChanged(GeneralContext context, ChildQuestNodeStatus _2, ChildQuestNodeStatus _3)
		{
			int? pendingOpenWorldMapQuestId = ModelBase<WorldMapModel>.Instance.PendingOpenWorldMapQuestId;
			if (pendingOpenWorldMapQuestId == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.LevelEvent;
				ELogAuthor author = ELogAuthor.LYX;
				string message = "【疑难杂症】地图聚焦行为->任务id被提前清空了";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("questId", pendingOpenWorldMapQuestId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				Singleton<EventSystem>.Instance.Remove(EEventName.AfterLogicTreeChildQuestNodeStatusChange, new Action<GeneralContext, ChildQuestNodeStatus, ChildQuestNodeStatus>(this.OnChildQuestNodeStatusChanged));
				return;
			}
			GeneralLogicTreeContext generalLogicTreeContext = context as GeneralLogicTreeContext;
			if (generalLogicTreeContext != null)
			{
				int treeConfigId = generalLogicTreeContext.TreeConfigId;
				int? pendingOpenWorldMapQuestId2 = ModelBase<WorldMapModel>.Instance.PendingOpenWorldMapQuestId;
				if (treeConfigId == pendingOpenWorldMapQuestId2.GetValueOrDefault() & pendingOpenWorldMapQuestId2 != null)
				{
					Singleton<EventSystem>.Instance.Remove(EEventName.AfterLogicTreeChildQuestNodeStatusChange, new Action<GeneralContext, ChildQuestNodeStatus, ChildQuestNodeStatus>(this.OnChildQuestNodeStatusChanged));
					int questIdValue = ModelBase<WorldMapModel>.Instance.PendingOpenWorldMapQuestId.Value;
					ModelBase<WorldMapModel>.Instance.PendingOpenWorldMapQuestId = null;
					QuestMarkCreateInfo markByQuestId = ModelBase<MapModel>.Instance.GetMarkByQuestId(questIdValue);
					if (markByQuestId == null)
					{
						Log instance2 = Singleton<Log>.Instance;
						ELogModule module2 = ELogModule.LevelEvent;
						ELogAuthor author2 = ELogAuthor.LYX;
						string message2 = "地图聚焦行为失败->任务仍没有创建标记";
						ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("questId", questIdValue);
						instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
						return;
					}
					WorldMapViewOpenParams data = new WorldMapViewOpenParams
					{
						MarkId = markByQuestId.MarkId,
						MarkType = markByQuestId.MarkType
					};
					this.OpenView(EOpenMapType.Other, false, data, delegate(bool success, int viewId)
					{
						Singleton<EventSystem>.Instance.Emit<int>(EEventName.WorldMapOpenedForQuestMapFocus, questIdValue);
					});
				}
			}
		}

		// Token: 0x060322BA RID: 205498 RVA: 0x00C8EDC8 File Offset: 0x00C8CFC8
		private void OnCsNotifyOpenWorldMapView(EMarkType markType, int markId, bool isNotFocusTween)
		{
			WorldMapViewOpenParams param = new WorldMapViewOpenParams
			{
				MarkType = markType,
				MarkId = new int?(markId),
				OpenFogId = new int?(0),
				IsNotFocusTween = new bool?(isNotFocusTween)
			};
			Singleton<UiManager>.Instance.OpenView(EUiViewName.WorldMapView, param, null);
		}

		// Token: 0x060322BB RID: 205499 RVA: 0x00C8EE18 File Offset: 0x00C8D018
		[NullableContext(1)]
		public void RequestNavigationFindPath(global::Vector startPos, global::Vector endPos, int mapId)
		{
			NavigationFindPathRequest navigationFindPathRequest = NavigationFindPathRequest.Create();
			navigationFindPathRequest.StartPos = new Aki.Protocol.Vector
			{
				X = (float)startPos.X,
				Y = (float)startPos.Y,
				Z = (float)startPos.Z
			};
			navigationFindPathRequest.EndPos = new Aki.Protocol.Vector
			{
				X = (float)endPos.X,
				Y = (float)endPos.Y,
				Z = (float)endPos.Z
			};
			navigationFindPathRequest.MapId = mapId;
			Singleton<Net>.Instance.Call<NavigationFindPathResponse>(ERequestMessageId.NavigationFindPathRequest, navigationFindPathRequest, delegate(NavigationFindPathResponse response, Net.CallbackStatus status)
			{
				if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 27663, null, true, true);
				}
			}, 0);
		}

		// Token: 0x060322BC RID: 205500 RVA: 0x00C8EEC6 File Offset: 0x00C8D0C6
		public void EnableWorldNavigationDebug(bool isEnable)
		{
			WorldNavigation.SetEnableDebug(isEnable);
		}

		// Token: 0x060322BD RID: 205501 RVA: 0x00C8EED0 File Offset: 0x00C8D0D0
		[NullableContext(1)]
		public void OpenExtraUi(EWorldMapExtraUiPanelName panelName, IWorldMapViewOpenParams mapOpenParam, [Nullable(2)] object param = null)
		{
			if (Singleton<UiManager>.Instance.IsViewShow(EUiViewName.WorldMapView))
			{
				Singleton<EventSystem>.Instance.Emit<NavigateMark>(EEventName.WorldMapNavigate, new NavigateMark
				{
					MarkId = mapOpenParam.MarkId.Value,
					MarkType = mapOpenParam.MarkType,
					Focal = new bool?(false),
					FocusTween = new bool?(false)
				});
				Singleton<EventSystem>.Instance.Emit<EWorldMapExtraUiPanelName, object>(EEventName.OpenExtraUiFromMap, panelName, param);
				return;
			}
			this.OpenView(EOpenMapType.Other, false, mapOpenParam, null);
		}

		// Token: 0x0401D4FB RID: 120059
		private TimerHandle CheckStreamingCompletedTimerId;

		// Token: 0x0401D4FC RID: 120060
		private List<int> OpenFuncList;
	}
}
