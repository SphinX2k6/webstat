using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Module.PermanentRogue;
using CSharpScript.Game.Module.RogueBattle;
using CSharpScript.Game.Ui;
using CSharpScript.Module.InstanceDungeon;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.MapRogue
{
	// Token: 0x020058F9 RID: 22777
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Controller(0)]
	public class MapRogueController : UiControllerBase<MapRogueController>, IStaticVariableResetter
	{
		// Token: 0x06039CFE RID: 236798 RVA: 0x00EA3E36 File Offset: 0x00EA2036
		protected override bool OnInit()
		{
			return true;
		}

		// Token: 0x06039CFF RID: 236799 RVA: 0x00EA3E3C File Offset: 0x00EA203C
		protected override void OnRegisterNetEvent()
		{
			Singleton<Net>.Instance.Register<RogueResOpDataUpdateNotify>(ENotifyMessageId.RogueResOpDataUpdateNotify, new Action<RogueResOpDataUpdateNotify, Net.CallbackStatus>(this.OnRogueResOpDataUpdateNotify));
			Singleton<Net>.Instance.Register<RogueResInstGlobalDataNotify>(ENotifyMessageId.RogueResInstGlobalDataNotify, new Action<RogueResInstGlobalDataNotify, Net.CallbackStatus>(this.OnRogueResInstGlobalDataNotify));
			Singleton<Net>.Instance.Register<RogueResGridDataUpdateNotify>(ENotifyMessageId.RogueResGridDataUpdateNotify, new Action<RogueResGridDataUpdateNotify, Net.CallbackStatus>(this.OnRogueResGridDataUpdateNotify));
			Singleton<Net>.Instance.Register<RogueResMoodUpdateNotify>(ENotifyMessageId.RogueResMoodUpdateNotify, new Action<RogueResMoodUpdateNotify, Net.CallbackStatus>(this.OnRogueResMoodUpdateNotify));
			Singleton<Net>.Instance.Register<RogueResPlayerStatusUpdateNotify>(ENotifyMessageId.RogueResPlayerStatusUpdateNotify, new Action<RogueResPlayerStatusUpdateNotify, Net.CallbackStatus>(this.OnRogueResPlayerStatusUpdateNotify));
			Singleton<Net>.Instance.Register<RogueResTeamLevelUpdateNotify>(ENotifyMessageId.RogueResTeamLevelUpdateNotify, new Action<RogueResTeamLevelUpdateNotify, Net.CallbackStatus>(this.OnRogueResTeamLevelUpdateNotify));
			Singleton<Net>.Instance.Register<RogueResMoodRangeUpdateNotify>(ENotifyMessageId.RogueResMoodRangeUpdateNotify, new Action<RogueResMoodRangeUpdateNotify, Net.CallbackStatus>(this.OnRogueResMoodRangeUpdateNotify));
		}

		// Token: 0x06039D00 RID: 236800 RVA: 0x00EA3F10 File Offset: 0x00EA2110
		protected override void OnUnRegisterNetEvent()
		{
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.RogueResOpDataUpdateNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.RogueResInstGlobalDataNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.RogueResGridDataUpdateNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.RogueResMoodUpdateNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.RogueResPlayerStatusUpdateNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.RogueResTeamLevelUpdateNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.RogueResMoodRangeUpdateNotify);
		}

		// Token: 0x06039D01 RID: 236801 RVA: 0x00EA3F8D File Offset: 0x00EA218D
		protected override void OnAddEvents()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.WorldDoneAndCloseLoading, new Action(this.OnWorldDoneAndCloseLoading));
		}

		// Token: 0x06039D02 RID: 236802 RVA: 0x00EA3FAB File Offset: 0x00EA21AB
		protected override void OnRemoveEvents()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.WorldDoneAndCloseLoading, new Action(this.OnWorldDoneAndCloseLoading));
		}

		// Token: 0x06039D03 RID: 236803 RVA: 0x00EA3FCC File Offset: 0x00EA21CC
		private void OnRogueResInstGlobalDataNotify(RogueResInstGlobalDataNotify notify, [Nullable(2)] Net.CallbackStatus _)
		{
			IGameInfoInitData gameInfo = new GameInfoInitData
			{
				InstanceId = notify.InstId,
				RandomSeed = notify.RandomSeedId,
				MapGrids = ModelBase<MapRogueModel>.Instance.CreateMapGridDataList(notify.RogueResGridDatas, notify.RandomSeedId),
				MapWidth = notify.Columns,
				MapHeight = notify.Rows,
				PlayerGridIndex = notify.Index,
				MoodMin = notify.MinMood,
				MoodMax = notify.MaxMood,
				InitMood = notify.Mood,
				TeamLv = notify.TeamLevel,
				InBattle = notify.InBattle,
				CurrencyItemId = notify.GoldItem,
				MoodRuleId = notify.MoodRuleId,
				RoleLevel = notify.RoleLevel,
				RoleMaxStar = notify.RoleMaxStar
			};
			ModelBase<MapRogueModel>.Instance.ResetGameInfo();
			ModelBase<MapRogueModel>.Instance.RefreshGameInfo(gameInfo);
			RogueResOpDataNotify rogueResOpDataNotify = notify.RogueResOpDataNotify;
			if (((rogueResOpDataNotify != null) ? rogueResOpDataNotify.RogueResOpDatas : null) != null)
			{
				ModelBase<MapRogueModel>.Instance.GenerateOpList(notify.RogueResOpDataNotify.RogueResOpDatas);
			}
			if (notify.RogueResInstOptionsNotify != null)
			{
				RogueBattleModel instance = ModelBase<RogueBattleModel>.Instance;
				if (instance != null)
				{
					instance.InitOptionData(notify.RogueResInstOptionsNotify);
				}
			}
			if (notify.RogueResGainDataTotalNotify != null)
			{
				RogueBattleModel instance2 = ModelBase<RogueBattleModel>.Instance;
				if (instance2 != null)
				{
					instance2.InitGainData(notify.RogueResGainDataTotalNotify);
				}
			}
			if (notify.RogueResFormations != null)
			{
				ModelBase<RogueBattleModel>.Instance.InitFormationData(notify.RogueResFormations.ToList<RogueResFormation>());
			}
			ModelBase<RogueBattleModel>.Instance.MaxRoleStar = notify.RoleMaxStar;
		}

		// Token: 0x06039D04 RID: 236804 RVA: 0x00EA414C File Offset: 0x00EA234C
		private void OnRogueResGridDataUpdateNotify(RogueResGridDataUpdateNotify notify, [Nullable(2)] Net.CallbackStatus _)
		{
			MapRogueGameInfo gameInfo = ModelBase<MapRogueModel>.Instance.GameInfo;
			if (gameInfo == null)
			{
				return;
			}
			foreach (KeyValuePair<int, RogueResGridData> keyValuePair in notify.RogueResGridDataDict)
			{
				int key = keyValuePair.Key;
				RogueResGridData value = keyValuePair.Value;
				ModelBase<MapRogueModel>.Instance.RefreshMapGridData(key, value);
			}
			if (notify.HasPlayerIndex)
			{
				gameInfo.PlayerGridIndex = notify.PlayerIndex;
			}
		}

		// Token: 0x06039D05 RID: 236805 RVA: 0x00EA41D4 File Offset: 0x00EA23D4
		private void OnRogueResMoodUpdateNotify(RogueResMoodUpdateNotify notify, [Nullable(2)] Net.CallbackStatus _)
		{
			if (ModelBase<MapRogueModel>.Instance.GameInfo == null)
			{
				return;
			}
			ModelBase<MapRogueModel>.Instance.GameInfo.SetMood(notify.Mood, new int?(notify.EventType), null, null, notify.IgnorePerformance);
			ModelBase<MapRogueModel>.Instance.GameInfo.MoodRuleId = notify.MoodRuleId;
		}

		// Token: 0x06039D06 RID: 236806 RVA: 0x00EA423C File Offset: 0x00EA243C
		private void OnRogueResMoodRangeUpdateNotify(RogueResMoodRangeUpdateNotify notify, [Nullable(2)] Net.CallbackStatus _)
		{
			MapRogueGameInfo gameInfo = ModelBase<MapRogueModel>.Instance.GameInfo;
			if (gameInfo == null)
			{
				return;
			}
			gameInfo.SetMood(gameInfo.Mood, null, new int?(notify.MinMood), new int?(notify.MaxMood), false);
		}

		// Token: 0x06039D07 RID: 236807 RVA: 0x00EA4284 File Offset: 0x00EA2484
		private void OnRogueResPlayerStatusUpdateNotify(RogueResPlayerStatusUpdateNotify notify, [Nullable(2)] Net.CallbackStatus _)
		{
			MapRogueGameInfo gameInfo = ModelBase<MapRogueModel>.Instance.GameInfo;
			if (gameInfo == null)
			{
				return;
			}
			gameInfo.InBattle = notify.InBattle;
			if (gameInfo.IsEnd)
			{
				return;
			}
			if (notify.InBattle)
			{
				if (gameInfo.HasBindView)
				{
					gameInfo.EnterBattleFlag = true;
					Singleton<UiManager>.Instance.CloseView(EUiViewName.MapRogueMainView, null);
				}
			}
			else if (!gameInfo.HasBindView)
			{
				Singleton<UiManager>.Instance.OpenView(EUiViewName.MapRogueMainView, null, null);
			}
			foreach (MapRogueOp mapRogueOp in ModelBase<MapRogueModel>.Instance.GetAllOpData())
			{
				mapRogueOp.BattleStateUpdate(notify.InBattle, gameInfo);
			}
			if (!notify.InBattle)
			{
				foreach (EntityHandle entityHandle in ModelBase<SceneTeamModel>.Instance.GetTeamEntities(true))
				{
					WorldEntity entity = entityHandle.Entity;
					if (entity != null)
					{
						BaseSkillComponent component = entity.GetComponent<BaseSkillComponent>();
						if (component != null)
						{
							component.StopAllSkills("RogueBattleStateUpdate");
						}
					}
				}
			}
		}

		// Token: 0x06039D08 RID: 236808 RVA: 0x00EA43AC File Offset: 0x00EA25AC
		private void OnRogueResTeamLevelUpdateNotify(RogueResTeamLevelUpdateNotify notify, [Nullable(2)] Net.CallbackStatus _)
		{
			if (ModelBase<MapRogueModel>.Instance.GameInfo == null)
			{
				return;
			}
			ModelBase<MapRogueModel>.Instance.GameInfo.SetTeamLv(notify.TeamLevel, new int?(notify.EventType));
			ModelBase<MapRogueModel>.Instance.SetRoleLevel(notify.RoleLevel);
		}

		// Token: 0x06039D09 RID: 236809 RVA: 0x00EA43EC File Offset: 0x00EA25EC
		public UniTask RequestInstResultEnd()
		{
			MapRogueController.<RequestInstResultEnd>d__11 <RequestInstResultEnd>d__;
			<RequestInstResultEnd>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RequestInstResultEnd>d__.<>1__state = -1;
			<RequestInstResultEnd>d__.<>t__builder.Start<MapRogueController.<RequestInstResultEnd>d__11>(ref <RequestInstResultEnd>d__);
			return <RequestInstResultEnd>d__.<>t__builder.Task;
		}

		// Token: 0x06039D0A RID: 236810 RVA: 0x00EA4428 File Offset: 0x00EA2628
		public void RequestInstLeave()
		{
			int instanceId = ModelBase<InstanceDungeonEntranceModel>.Instance.InstanceId;
			if (instanceId != 0)
			{
				ControllerBase<ActivityPermanentRogueController>.Instance.SetReturnToWorld(instanceId);
			}
			MapRogueGameInfo gameInfo = ModelBase<MapRogueModel>.Instance.GameInfo;
			if (gameInfo != null)
			{
				gameInfo.IsEnd = true;
			}
			ControllerBase<InstanceDungeonEntranceController>.Instance.LeaveInstanceDungeonRequest(LeaveInstWay.Default).ContinueWith(delegate(bool success)
			{
				if (gameInfo != null)
				{
					gameInfo.IsEnd = success;
				}
				if (success)
				{
					ModelBase<MapRogueModel>.Instance.ResetGameInfo();
				}
			});
		}

		// Token: 0x06039D0B RID: 236811 RVA: 0x00EA4498 File Offset: 0x00EA2698
		[NullableContext(2)]
		public void RequestBackToMap(Action<bool> callback = null)
		{
			RogueResGridEventRequest message = RogueResGridEventRequest.Create();
			Singleton<Net>.Instance.Call<RogueResGridEventResponse>(ERequestMessageId.RogueResGridEventRequest, message, delegate(RogueResGridEventResponse response, Net.CallbackStatus _)
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
				else if (response.ErrCode != Aki.Protocol.ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrCode, EResponseMessageId.RogueResGridEventResponse, null, true, true);
					Action<bool> callback3 = callback;
					if (callback3 == null)
					{
						return;
					}
					callback3(false);
					return;
				}
				else
				{
					Action<bool> callback4 = callback;
					if (callback4 == null)
					{
						return;
					}
					callback4(true);
					return;
				}
			}, 0);
		}

		// Token: 0x06039D0C RID: 236812 RVA: 0x00EA44D5 File Offset: 0x00EA26D5
		private void OnWorldDoneAndCloseLoading()
		{
			if (ModelBase<MapRogueModel>.Instance.GameInfo == null)
			{
				return;
			}
			if (!this.CheckInMapRogueInstance())
			{
				return;
			}
			ModelBase<MapRogueModel>.Instance.ExecuteOpDataList();
		}

		// Token: 0x06039D0D RID: 236813 RVA: 0x00EA44F8 File Offset: 0x00EA26F8
		private void OnRogueResOpDataUpdateNotify(RogueResOpDataUpdateNotify notify, [Nullable(2)] Net.CallbackStatus _)
		{
			if (ModelBase<MapRogueModel>.Instance.GameInfo == null)
			{
				return;
			}
			foreach (int incId in notify.Removes)
			{
				ModelBase<MapRogueModel>.Instance.RemoveOpData(incId);
			}
			foreach (RogueResOpData data in notify.Updates)
			{
				ModelBase<MapRogueModel>.Instance.UpdateOpData(data);
			}
			foreach (RogueResOpData data2 in notify.Adds)
			{
				ModelBase<MapRogueModel>.Instance.AddOpData(data2, true);
			}
			ModelBase<MapRogueModel>.Instance.ExecuteOpDataList();
		}

		// Token: 0x06039D0E RID: 236814 RVA: 0x00EA45E4 File Offset: 0x00EA27E4
		public void RequestMove(List<int> pathList, [Nullable(2)] Action<bool> callback = null)
		{
			RogueResMoveRequest rogueResMoveRequest = RogueResMoveRequest.Create();
			MoveOp moveOp = MoveOp.Create();
			moveOp.Paths.AddRange(pathList);
			rogueResMoveRequest.MoveOp = moveOp;
			Singleton<Net>.Instance.Call<RogueResMoveResponse>(ERequestMessageId.RogueResMoveRequest, rogueResMoveRequest, delegate(RogueResMoveResponse response, Net.CallbackStatus _)
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
				else if (response.ErrCode != Aki.Protocol.ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrCode, EResponseMessageId.RogueResMoveResponse, null, true, true);
					Action<bool> callback3 = callback;
					if (callback3 == null)
					{
						return;
					}
					callback3(false);
					return;
				}
				else
				{
					Action<bool> callback4 = callback;
					if (callback4 == null)
					{
						return;
					}
					callback4(true);
					return;
				}
			}, 0);
		}

		// Token: 0x06039D0F RID: 236815 RVA: 0x00EA463C File Offset: 0x00EA283C
		[NullableContext(2)]
		public void RequestExecuteOp(int incId, int clientId, Action<bool> callback = null)
		{
			RogueResOpDoneRequest rogueResOpDoneRequest = RogueResOpDoneRequest.Create();
			rogueResOpDoneRequest.IncId = incId;
			rogueResOpDoneRequest.ClientSelectId = clientId;
			Singleton<Net>.Instance.Call<RogueResOpDoneResponse>(ERequestMessageId.RogueResOpDoneRequest, rogueResOpDoneRequest, delegate(RogueResOpDoneResponse response, Net.CallbackStatus _)
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
					if (response.ErrCode != Aki.Protocol.ErrorCode.Success)
					{
						ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrCode, EResponseMessageId.RogueResOpDoneResponse, null, true, true);
						Action<bool> callback3 = callback;
						if (callback3 != null)
						{
							callback3(false);
						}
					}
					Action<bool> callback4 = callback;
					if (callback4 != null)
					{
						callback4(true);
					}
					MapRogueGameInfo gameInfo = ModelBase<MapRogueModel>.Instance.GameInfo;
					if (gameInfo == null)
					{
						return;
					}
					gameInfo.SetInteractAvailable(EMapForbiddenTag.WaitExecuteOp, true);
					return;
				}
			}, 0);
		}

		// Token: 0x06039D10 RID: 236816 RVA: 0x00EA4688 File Offset: 0x00EA2888
		public void RequestExecuteOpMultiSelect(int incId, List<int> clientIds, [Nullable(2)] Action<bool> callback = null)
		{
			RogueResOpDoneRequest rogueResOpDoneRequest = RogueResOpDoneRequest.Create();
			rogueResOpDoneRequest.IncId = incId;
			rogueResOpDoneRequest.ClientSelectIds.AddRange(clientIds);
			Singleton<Net>.Instance.Call<RogueResOpDoneResponse>(ERequestMessageId.RogueResOpDoneRequest, rogueResOpDoneRequest, delegate(RogueResOpDoneResponse response, Net.CallbackStatus _)
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
					if (response.ErrCode != Aki.Protocol.ErrorCode.Success)
					{
						ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrCode, EResponseMessageId.RogueResOpDoneResponse, null, true, true);
						Action<bool> callback3 = callback;
						if (callback3 != null)
						{
							callback3(false);
						}
					}
					Action<bool> callback4 = callback;
					if (callback4 != null)
					{
						callback4(true);
					}
					MapRogueGameInfo gameInfo = ModelBase<MapRogueModel>.Instance.GameInfo;
					if (gameInfo == null)
					{
						return;
					}
					gameInfo.SetInteractAvailable(EMapForbiddenTag.WaitExecuteOp, true);
					return;
				}
			}, 0);
		}

		// Token: 0x06039D11 RID: 236817 RVA: 0x00EA46D8 File Offset: 0x00EA28D8
		public bool CheckInMapRogueInstance()
		{
			if (!ControllerBase<GameModeController>.Instance.IsInInstance())
			{
				return false;
			}
			int instanceId = ModelBase<CreatureModel>.Instance.GetInstanceId();
			InstanceDungeon? config = ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(instanceId);
			return config != null && config.Value.InstSubType == 34;
		}

		// Token: 0x06039D12 RID: 236818 RVA: 0x00EA4729 File Offset: 0x00EA2929
		protected override void OnAddOpenViewCheckFunction()
		{
			Singleton<UiManager>.Instance.AddOpenViewCheckFunction(EUiViewName.MapRogueMainView, new Func<EUiViewName, object, bool>(this.CanOpenMainView), "MapRogueController.CanOpenMainView");
		}

		// Token: 0x06039D13 RID: 236819 RVA: 0x00EA474B File Offset: 0x00EA294B
		protected override void OnRemoveOpenViewCheckFunction()
		{
			Singleton<UiManager>.Instance.RemoveOpenViewCheckFunction(EUiViewName.MapRogueMainView, new Func<EUiViewName, object, bool>(this.CanOpenMainView));
		}

		// Token: 0x06039D14 RID: 236820 RVA: 0x00EA4768 File Offset: 0x00EA2968
		private bool CanOpenMainView(EUiViewName viewName, object param)
		{
			if (!this.CheckInMapRogueInstance())
			{
				return false;
			}
			MapRogueGameInfo gameInfo = ModelBase<MapRogueModel>.Instance.GameInfo;
			return gameInfo != null && !gameInfo.InBattle;
		}

		// Token: 0x06039D15 RID: 236821 RVA: 0x00EA479C File Offset: 0x00EA299C
		public void OpenRogueTipsView(ERogueTipsType type, string textId, [Nullable(new byte[]
		{
			2,
			1
		})] string[] textParam = null, [Nullable(2)] Action finishCallback = null)
		{
			RogueTipsData param = new RogueTipsData
			{
				TextId = textId,
				TextParam = (textParam ?? new string[0]),
				FinishCallback = finishCallback
			};
			if (type == ERogueTipsType.Normal)
			{
				Singleton<UiManager>.Instance.OpenView(EUiViewName.MapRogueFloatTipsAView, param, null);
				return;
			}
			Singleton<UiManager>.Instance.OpenView(EUiViewName.MapRogueFloatTipsBView, param, null);
		}

		// Token: 0x06039D16 RID: 236822 RVA: 0x00EA47F5 File Offset: 0x00EA29F5
		public void OpenRogueMenuView()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.RogueBattleMapSummaryView, null, null);
		}

		// Token: 0x06039D17 RID: 236823 RVA: 0x00EA4808 File Offset: 0x00EA2A08
		public void OpenRogueFetterView(int? fetterId = null)
		{
			RogueBattleMapSummeryOpenInfo param = new RogueBattleMapSummeryOpenInfo
			{
				TabName = EUiTabViewName.RogueBattleMapSummaryFettersTabView,
				FetterId = fetterId
			};
			Singleton<UiManager>.Instance.OpenView(EUiViewName.RogueBattleMapSummaryView, param, null);
		}

		// Token: 0x06039D18 RID: 236824 RVA: 0x00EA4840 File Offset: 0x00EA2A40
		public void OpenExploreEnd(bool exitToMap = false)
		{
			ExploreEndViewData exploreEndViewData = new ExploreEndViewData();
			exploreEndViewData.ExitToMap = exitToMap;
			Singleton<UiManager>.Instance.OpenView(EUiViewName.MapRogueExploreEndView, exploreEndViewData, null);
		}

		// Token: 0x06039D19 RID: 236825 RVA: 0x00EA486C File Offset: 0x00EA2A6C
		public void OpenExplore()
		{
			ExploreEndViewData param = new ExploreEndViewData();
			Singleton<UiManager>.Instance.OpenView(EUiViewName.MapRogueExploreView, param, null);
		}

		// Token: 0x06039D1A RID: 236826 RVA: 0x00EA4890 File Offset: 0x00EA2A90
		public void OpenMapHelpView()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.RogueBattleMapHelpView, null, null);
		}
	}
}
