using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Activity.ActivityContent.Roverlike;
using CSharpScript.Game.Module.Battle;
using CSharpScript.Game.Module.Kurotato;
using CSharpScript.Game.Module.LevelLoading;
using CSharpScript.Game.Module.Plot;
using CSharpScript.Game.Module.Teleport;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.DeadRevive
{
	// Token: 0x02005DC1 RID: 24001
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Controller(0)]
	public class DeadReviveController : UiControllerBase<DeadReviveController>
	{
		// Token: 0x0603C6CD RID: 247501 RVA: 0x00F56F0D File Offset: 0x00F5510D
		protected override bool OnChangeMode()
		{
			this.CloseReviveView();
			return true;
		}

		// Token: 0x0603C6CE RID: 247502 RVA: 0x00F56F18 File Offset: 0x00F55118
		protected override void OnAddEvents()
		{
			Singleton<Net>.Instance.Register<PlayerDeadNotify>(ENotifyMessageId.PlayerDeadNotify, new Action<PlayerDeadNotify, Net.CallbackStatus>(this.NotifyOnPlayerDead));
			Singleton<Net>.Instance.Register<PlayerReviveNotify>(ENotifyMessageId.PlayerReviveNotify, new Action<PlayerReviveNotify, Net.CallbackStatus>(this.NotifyOnPlayerRevive));
			Singleton<Net>.Instance.Register<AbyssReviveNotify>(ENotifyMessageId.AbyssReviveNotify, new Action<AbyssReviveNotify, Net.CallbackStatus>(this.AbyssReviveNotify));
			Singleton<Net>.Instance.Register<AbyssReviveTimeNotify>(ENotifyMessageId.AbyssReviveTimeNotify, new Action<AbyssReviveTimeNotify, Net.CallbackStatus>(this.AbyssReviveTimeNotify));
			Singleton<EventSystem>.Instance.Add<PlotResultInfo>(EEventName.PlotNetworkEnd, new Action<PlotResultInfo>(this.OnPlotNetworkEnd));
			Singleton<EventSystem>.Instance.Add<Entity>(EEventName.OnRevive, new Action<Entity>(this.OnRoleRevive));
		}

		// Token: 0x0603C6CF RID: 247503 RVA: 0x00F56FD0 File Offset: 0x00F551D0
		protected override void OnRemoveEvents()
		{
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.PlayerDeadNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.PlayerReviveNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.AbyssReviveNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.AbyssReviveTimeNotify);
			Singleton<EventSystem>.Instance.Remove(EEventName.PlotNetworkEnd, new Action<PlotResultInfo>(this.OnPlotNetworkEnd));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnRevive, new Action<Entity>(this.OnRoleRevive));
		}

		// Token: 0x0603C6D0 RID: 247504 RVA: 0x00F57058 File Offset: 0x00F55258
		[NullableContext(2)]
		public void ReviveRequest(bool useItem, Action<bool> finishCallback = null, int? customParam = null)
		{
			if (this.IsReviving)
			{
				return;
			}
			ReviveRequest reviveRequest = Aki.Protocol.ReviveRequest.Create();
			reviveRequest.UseItem = useItem;
			if (customParam != null)
			{
				reviveRequest.CustomParam = customParam.Value;
			}
			this.IsReviving = true;
			Singleton<Net>.Instance.Call<ReviveResponse>(ERequestMessageId.ReviveRequest, reviveRequest, delegate(ReviveResponse response, Net.CallbackStatus status)
			{
				this.IsReviving = false;
				if (response == null)
				{
					Action<bool> finishCallback2 = finishCallback;
					if (finishCallback2 == null)
					{
						return;
					}
					finishCallback2(false);
					return;
				}
				else if (response.ErrorCode != ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 28594, null, true, true);
					Action<bool> finishCallback3 = finishCallback;
					if (finishCallback3 == null)
					{
						return;
					}
					finishCallback3(false);
					return;
				}
				else
				{
					Action<bool> finishCallback4 = finishCallback;
					if (finishCallback4 == null)
					{
						return;
					}
					finishCallback4(true);
					return;
				}
			}, 0);
		}

		// Token: 0x0603C6D1 RID: 247505 RVA: 0x00F570CC File Offset: 0x00F552CC
		public void TryReviveRole(long creatureDataId, int roleId, bool needChangeRole = false)
		{
			ReviveCooldownData reviveCooldownData = null;
			ModelBase<DeadReviveModel>.Instance.ReviveCooldownCreatureMap.TryGetValue(creatureDataId, out reviveCooldownData);
			if (reviveCooldownData != null)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("TuanZiAbyss_RE_ReTime", new object[]
				{
					Math.Floor(0.5 + 0.0010000000474974513 * reviveCooldownData.RemainMilliseconds)
				});
				return;
			}
			EReviveMode reviveMode = ModelBase<DeadReviveModel>.Instance.ReviveMode;
			if (reviveMode == EReviveMode.Common)
			{
				ControllerBase<BuffItemControl>.Instance.TryUseResurrectionItem(roleId);
				return;
			}
			if (reviveMode != EReviveMode.ShareReviveTimes)
			{
				return;
			}
			this.TryReviveRoleByShare(roleId, needChangeRole);
		}

		// Token: 0x0603C6D2 RID: 247506 RVA: 0x00F57158 File Offset: 0x00F55358
		public void TryReviveRoleWhenCurrentRoleDead(long creatureDataId, int roleId)
		{
			if (ModelBase<DeadReviveModel>.Instance.ReviveMode != EReviveMode.ShareReviveTimes)
			{
				return;
			}
			EUiViewName? openedViewName = ModelBase<DeadReviveModel>.Instance.OpenedViewName;
			EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
			bool flag;
			if (getCurrentEntity == null)
			{
				flag = false;
			}
			else
			{
				WorldEntity entity = getCurrentEntity.Entity;
				flag = ((entity != null) ? new bool?(entity.Active) : null).GetValueOrDefault();
			}
			if (flag || openedViewName == null || !Singleton<UiManager>.Instance.IsViewOpen(openedViewName.Value))
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("AbyssDangoReviveWait", Array.Empty<object>());
				return;
			}
			this.TryReviveRole(creatureDataId, roleId, true);
		}

		// Token: 0x0603C6D3 RID: 247507 RVA: 0x00F571F4 File Offset: 0x00F553F4
		public void CheckOtherPlayerReviveCooldown(int playerId, long creatureDataId)
		{
			if (playerId == ModelBase<CreatureModel>.Instance.GetPlayerId())
			{
				return;
			}
			OnlineTeamData currentTeamListById = ModelBase<OnlineModel>.Instance.GetCurrentTeamListById(playerId);
			if (currentTeamListById == null)
			{
				return;
			}
			ReviveCooldownData reviveCooldownData = null;
			ModelBase<DeadReviveModel>.Instance.ReviveCooldownCreatureMap.TryGetValue(creatureDataId, out reviveCooldownData);
			if (reviveCooldownData != null)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("TuanZiAbyss_RE_TimeRemainder", new object[]
				{
					currentTeamListById.PlayerNumber,
					Math.Floor(0.5 + 0.0010000000474974513 * reviveCooldownData.RemainMilliseconds)
				});
			}
		}

		// Token: 0x0603C6D4 RID: 247508 RVA: 0x00F57284 File Offset: 0x00F55484
		[NullableContext(2)]
		private void NotifyOnPlayerDead(PlayerDeadNotify notify, Net.CallbackStatus status)
		{
			DeadReviveModel instance = ModelBase<DeadReviveModel>.Instance;
			int playerId = notify.PlayerId;
			int? id = ModelBase<PlayerInfoModel>.Instance.GetId();
			if (!(playerId == id.GetValueOrDefault() & id != null))
			{
				return;
			}
			instance.InitReviveConfig(notify.ReviveId);
			instance.ReviveLimitTime = (float)notify.DelaySeconds;
			instance.IsShowRevive = notify.IsShowRevive;
			instance.IsAutoRevive = notify.IsAutoRevive;
			ModelBase<DeadReviveModel>.Instance.BlockAllInput = true;
			ControllerBase<InputDistributeController>.Instance.RefreshInputTag();
			try
			{
				if (!notify.IsAutoRevive && notify.IsShowRevive && !this.IsInstChallengeFinish())
				{
					Singleton<UiManager>.Instance.ResetToBattleView(null);
				}
				LordGymModel instance2 = ModelBase<LordGymModel>.Instance;
				if (instance2.IsChallenging())
				{
					instance2.IsDeadInChallenge = true;
				}
				if (notify.IsLogin)
				{
					Singleton<EventSystem>.Instance.Add(EEventName.WorldDone, new Action(this.LoginDeadFinish));
				}
				else if (instance.SkipDeathAnim)
				{
					this.DeadFinish(0f);
				}
				else if (!ControllerBase<RoverlikeController>.Instance.CheckInRoverlike())
				{
					instance.DeadDelayTimer = TimerSystem.GameplayTimeInstance.Delay(new TTimerAction(this.DeadFinish), 3000f, null, null, true, 1f);
				}
			}
			catch (Exception ex)
			{
				Log instance3 = Singleton<Log>.Instance;
				ELogModule module = ELogModule.World;
				ELogAuthor author = ELogAuthor.LYY;
				string message = "玩家死亡异常";
				Exception error = ex;
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("error", ex.Message);
				instance3.ErrorWithStack(module, author, message, error, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				ModelBase<DeadReviveModel>.Instance.BlockAllInput = false;
				ControllerBase<InputDistributeController>.Instance.RefreshInputTag();
			}
		}

		// Token: 0x0603C6D5 RID: 247509 RVA: 0x00F5740C File Offset: 0x00F5560C
		private void LoginDeadFinish()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.WorldDone, new Action(this.LoginDeadFinish));
			ModelBase<DeadReviveModel>.Instance.DeadDelayTimer = TimerSystem.GameplayTimeInstance.Delay(new TTimerAction(this.DeadFinish), 1000f, null, null, true, 1f);
		}

		// Token: 0x0603C6D6 RID: 247510 RVA: 0x00F57464 File Offset: 0x00F55664
		private void DeadFinish(float delta)
		{
			ModelBase<DeadReviveModel>.Instance.DeadDelayTimer = null;
			if (ModelBase<DeadReviveModel>.Instance.IsAutoRevive)
			{
				Singleton<Log>.Instance.Info(ELogModule.World, ELogAuthor.LYY, "自动复活", default(ReadOnlySpan<ValueTuple<string, object>>));
				this.DoDeadFinish(true);
				return;
			}
			this.OpenReviveView();
		}

		// Token: 0x0603C6D7 RID: 247511 RVA: 0x00F574B4 File Offset: 0x00F556B4
		public void DoDeadFinish(bool needReviveRequest = true)
		{
			ModelBase<DeadReviveModel>.Instance.BlockAllInput = false;
			ControllerBase<InputDistributeController>.Instance.RefreshInputTag();
			if (needReviveRequest)
			{
				this.ReviveRequest(false, null, null);
			}
		}

		// Token: 0x0603C6D8 RID: 247512 RVA: 0x00F574EC File Offset: 0x00F556EC
		[NullableContext(2)]
		private unsafe void NotifyOnPlayerRevive(PlayerReviveNotify notify, Net.CallbackStatus status)
		{
			Aki.Protocol.Vector location = notify.Location;
			double inX = (double)((location != null) ? location.X : 0f);
			Aki.Protocol.Vector location2 = notify.Location;
			double inY = (double)((location2 != null) ? location2.Y : 0f);
			Aki.Protocol.Vector location3 = notify.Location;
			FVectorDouble fvectorDouble = new FVectorDouble(inX, inY, (double)((location3 != null) ? location3.Z : 0f));
			Aki.Protocol.Rotator rotator = notify.Rotator;
			float inPitch = (rotator != null) ? rotator.Pitch : 0f;
			Aki.Protocol.Rotator rotator2 = notify.Rotator;
			float inYaw = (rotator2 != null) ? rotator2.Yaw : 0f;
			Aki.Protocol.Rotator rotator3 = notify.Rotator;
			FRotator frotator = new FRotator(inPitch, inYaw, (rotator3 != null) ? rotator3.Roll : 0f);
			global::Vector vector = null;
			Aki.Protocol.Vector gravity = notify.Gravity;
			if (gravity != null)
			{
				vector = global::Vector.Create((double)gravity.X, (double)gravity.Y, (double)gravity.Z);
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.World;
			ELogAuthor author = ELogAuthor.LYY;
			string message = "执行复活流程";
			<>y__InlineArray5<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray5<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("PlayerId", notify.PlayerId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Location", fvectorDouble);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("Rotator", frotator);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("Gravity", vector);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 4) = new ValueTuple<string, object>("ReviveType", notify.ReviveType);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 5));
			int playerId = notify.PlayerId;
			int? id = ModelBase<PlayerInfoModel>.Instance.GetId();
			if (playerId == id.GetValueOrDefault() & id != null)
			{
				this.SelfRevive(notify, fvectorDouble, frotator, vector).Forget();
				return;
			}
			this.OtherPlayerRevive(notify, fvectorDouble, frotator);
		}

		// Token: 0x0603C6D9 RID: 247513 RVA: 0x00F576AC File Offset: 0x00F558AC
		private UniTask SelfRevive(PlayerReviveNotify notify, FVectorDouble location, FRotator rotator, [Nullable(2)] global::Vector gravity)
		{
			DeadReviveController.<SelfRevive>d__17 <SelfRevive>d__;
			<SelfRevive>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<SelfRevive>d__.<>4__this = this;
			<SelfRevive>d__.notify = notify;
			<SelfRevive>d__.location = location;
			<SelfRevive>d__.rotator = rotator;
			<SelfRevive>d__.gravity = gravity;
			<SelfRevive>d__.<>1__state = -1;
			<SelfRevive>d__.<>t__builder.Start<DeadReviveController.<SelfRevive>d__17>(ref <SelfRevive>d__);
			return <SelfRevive>d__.<>t__builder.Task;
		}

		// Token: 0x0603C6DA RID: 247514 RVA: 0x00F57710 File Offset: 0x00F55910
		private bool CanRevivePerform(FVectorDouble location)
		{
			if (!ControllerBase<GameModeController>.Instance.IsInInstance())
			{
				return false;
			}
			bool flag = false;
			foreach (EntityHandle entityHandle in ModelBase<SceneTeamModel>.Instance.GetTeamEntities(true))
			{
				WorldEntity entity = entityHandle.Entity;
				BaseTagComponent baseTagComponent = (entity != null) ? entity.GetComponent<BaseTagComponent>() : null;
				if (baseTagComponent != null && baseTagComponent.HasTag(GameplayTagDefine.EGameplayTagId["怪物.common.关卡.特殊复活通知"]))
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				return false;
			}
			if (!ControllerBase<TeleportController>.Instance.QueryCanTeleportNoLoading(location))
			{
				Singleton<Log>.Instance.Info(ELogModule.World, ELogAuthor.LYY, "复活位置不可无加载传送，不允许复活表演", default(ReadOnlySpan<ValueTuple<string, object>>));
				return false;
			}
			return true;
		}

		// Token: 0x0603C6DB RID: 247515 RVA: 0x00F577D4 File Offset: 0x00F559D4
		private void OnPlotNetworkEnd(PlotResultInfo plotResult)
		{
			long reviveFlowIncId = ModelBase<DeadReviveModel>.Instance.ReviveFlowIncId;
			if (reviveFlowIncId != 0L)
			{
				long? flowIncId = plotResult.FlowIncId;
				long num = reviveFlowIncId;
				if (flowIncId.GetValueOrDefault() == num & flowIncId != null)
				{
					this.NoLoadingTeleport(ModelBase<DeadReviveModel>.Instance.RevivePosition.Value, ModelBase<DeadReviveModel>.Instance.ReviveRotator, ModelBase<DeadReviveModel>.Instance.ReviveGravity, "RevivePerform");
					ControllerBase<LevelLoadingController>.Instance.CloseLoading(ELoadingReason.Common, "DeadRevive_PlotEnd", null, new float?(0.5f));
					ModelBase<DeadReviveModel>.Instance.ReviveFlowIncId = 0L;
				}
			}
		}

		// Token: 0x0603C6DC RID: 247516 RVA: 0x00F57864 File Offset: 0x00F55A64
		public void PlayerReviveEnded(float delta)
		{
			ControllerBase<SceneTeamController>.Instance.ShowControlledRole(ModelBase<PlayerInfoModel>.Instance.GetId().Value);
			SceneTeamItem sceneTeamItem = null;
			int changeRoleIdAfterRevive = ModelBase<DeadReviveModel>.Instance.ChangeRoleIdAfterRevive;
			if (changeRoleIdAfterRevive != 0)
			{
				sceneTeamItem = ModelBase<SceneTeamModel>.Instance.GetTeamItem((long)changeRoleIdAfterRevive, new GetTeamItemOptions
				{
					ParamType = ETeamParamType.ConfigId,
					OnlyMyRole = new bool?(true)
				});
			}
			ModelBase<DeadReviveModel>.Instance.ChangeRoleIdAfterRevive = 0;
			if (sceneTeamItem == null && !ModelBase<GameModeModel>.Instance.IsMulti)
			{
				List<SceneTeamItem> teamItems = ModelBase<SceneTeamModel>.Instance.GetTeamItems(true);
				if (teamItems.Count > 0)
				{
					sceneTeamItem = teamItems[0];
				}
			}
			if (sceneTeamItem != null)
			{
				ControllerBase<SceneTeamController>.Instance.RequestChangeRole(sceneTeamItem.GetCreatureDataId(), null);
			}
		}

		// Token: 0x0603C6DD RID: 247517 RVA: 0x00F57910 File Offset: 0x00F55B10
		private void OtherPlayerRevive(PlayerReviveNotify notify, FVectorDouble location, FRotator rotator)
		{
			foreach (ReviveRoleInformation reviveRoleInformation in notify.ReviveRoleInfos)
			{
				long entityId = reviveRoleInformation.EntityId;
				EntityHandle entity = ModelBase<CreatureModel>.Instance.GetEntity(entityId);
				if (entity != null && entity.Valid)
				{
					if (!entity.IsInit)
					{
						CreatureDataComponent component = entity.Entity.GetComponent<CreatureDataComponent>();
						if (component != null)
						{
							component.SetLivingStatus(LivingStatus.Alive);
						}
						Aki.Protocol.Vector location2 = notify.Location;
						if (location2 != null && component != null)
						{
							component.SetInitLocation(location2);
						}
					}
					else
					{
						CharacterActorComponent component2 = entity.Entity.GetComponent<CharacterActorComponent>();
						component2.SetInputRotator(rotator);
						component2.SetActorLocationAndRotation(location, rotator, "复活流程.复活其他角色", false, null);
						CharacterMovementSyncComponent component3 = entity.Entity.GetComponent<CharacterMovementSyncComponent>();
						if (component3 != null)
						{
							component3.ClearReplaySamples();
						}
					}
				}
			}
			ControllerBase<SceneTeamController>.Instance.ShowControlledRole(notify.PlayerId);
		}

		// Token: 0x0603C6DE RID: 247518 RVA: 0x00F57A0C File Offset: 0x00F55C0C
		private void OpenReviveView()
		{
			ValueTuple<EUiViewName?, object> reviveViewName = this.GetReviveViewName();
			EUiViewName? viewName = reviveViewName.Item1;
			object viewData = reviveViewName.Item2;
			if (viewName == null)
			{
				ModelBase<DeadReviveModel>.Instance.BlockAllInput = false;
				ControllerBase<InputDistributeController>.Instance.RefreshInputTag();
				return;
			}
			ModelBase<DeadReviveModel>.Instance.OpenedViewName = viewName;
			Singleton<UiManager>.Instance.ResetToBattleView(delegate(bool success)
			{
				if (ModelBase<SceneTeamModel>.Instance.GetGroupLivingState(ModelBase<PlayerInfoModel>.Instance.GetId().GetValueOrDefault(), ETeamGroupType.Battle) == ETeamLivingState.Alive)
				{
					ModelBase<DeadReviveModel>.Instance.BlockAllInput = false;
					ControllerBase<InputDistributeController>.Instance.RefreshInputTag();
					return;
				}
				Singleton<UiManager>.Instance.OpenView(viewName.Value, viewData, delegate(bool _, int _)
				{
					ModelBase<DeadReviveModel>.Instance.BlockAllInput = false;
					ControllerBase<InputDistributeController>.Instance.RefreshInputTag();
				});
			});
		}

		// Token: 0x0603C6DF RID: 247519 RVA: 0x00F57A88 File Offset: 0x00F55C88
		[return: Nullable(new byte[]
		{
			0,
			2
		})]
		private ValueTuple<EUiViewName?, object> GetReviveViewName()
		{
			if (this.IsInstChallengeFinish())
			{
				return new ValueTuple<EUiViewName?, object>(null, null);
			}
			if (ModelBase<DeadReviveModel>.Instance.ReviveMode == EReviveMode.ShareReviveTimes)
			{
				return new ValueTuple<EUiViewName?, object>(new EUiViewName?(EUiViewName.ShareTimesReviveView), null);
			}
			if (ModelBase<GameModeModel>.Instance.IsMulti)
			{
				if (ControllerBase<TowerDefenseController>.Instance.CheckInInstanceDungeon())
				{
					return new ValueTuple<EUiViewName?, object>(ControllerBase<TowerDefenseController>.Instance.TryGetReviveViewName(), null);
				}
				return new ValueTuple<EUiViewName?, object>(new EUiViewName?(EUiViewName.MultiReviveView), null);
			}
			else if (ControllerBase<KurotatoController>.Instance.CheckInKurotatoInstance())
			{
				KurotatoModel instance = ModelBase<KurotatoModel>.Instance;
				if (instance.GetSettlementData() != null)
				{
					return new ValueTuple<EUiViewName?, object>(null, null);
				}
				if (instance.GetIsSpecialWave())
				{
					ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.KurotatoEndSpecialWaveCombatConfirm);
					confirmBoxDataNew.FunctionMap[1] = delegate()
					{
						ControllerBase<KurotatoController>.Instance.RequestKurotatoEndSpecialWaveCombat().Forget<bool>();
					};
					return new ValueTuple<EUiViewName?, object>(ControllerBase<ConfirmBoxController>.Instance.GetUiViewName(532), confirmBoxDataNew);
				}
				EConfirmBoxConfigId configId = instance.IsReChallengeCountUnlimited() ? EConfirmBoxConfigId.KurotatoDieNoLimitConfirm : EConfirmBoxConfigId.KurotatoDieConfirm;
				ConfirmBoxDataNew confirmBoxDataNew2 = new ConfirmBoxDataNew(configId);
				confirmBoxDataNew2.IsMultipleView = true;
				if (!instance.IsReChallengeCountUnlimited())
				{
					confirmBoxDataNew2.SetTextArgs(new string[]
					{
						instance.GetRemainReChallengeCount().ToString()
					});
				}
				confirmBoxDataNew2.FunctionMap[1] = delegate()
				{
					ControllerBase<KurotatoController>.Instance.RequestKurotatoSettlement().Forget<bool>();
				};
				confirmBoxDataNew2.FunctionMap[2] = delegate()
				{
					ControllerBase<KurotatoController>.Instance.RequestKurotatoReChallenge(true).Forget<bool>();
				};
				return new ValueTuple<EUiViewName?, object>(ControllerBase<ConfirmBoxController>.Instance.GetUiViewName((int)configId), confirmBoxDataNew2);
			}
			else
			{
				if (!ModelBase<DeadReviveModel>.Instance.IsShowRevive)
				{
					return new ValueTuple<EUiViewName?, object>(null, null);
				}
				BabelTowerModel instance2 = ModelBase<BabelTowerModel>.Instance;
				if (instance2.CheckInBattleBabelTower() && instance2.CheckCanRevive())
				{
					BabelTowerInstanceData currentChallengeInstData = instance2.CurrentChallengeInstData;
					BabelTowerReviveViewData item = new BabelTowerReviveViewData
					{
						LevelId = currentChallengeInstData.LevelId,
						StarNum = currentChallengeInstData.CurStarNum
					};
					return new ValueTuple<EUiViewName?, object>(new EUiViewName?(EUiViewName.BabelTowerReviveView), item);
				}
				if (ModelBase<FlagChallengeBattleModel>.Instance.IsInFlagChallengeDungeon)
				{
					return new ValueTuple<EUiViewName?, object>(new EUiViewName?(EUiViewName.FlagChallengeReviveView), null);
				}
				return new ValueTuple<EUiViewName?, object>(new EUiViewName?(EUiViewName.ReviveView), null);
			}
		}

		// Token: 0x0603C6E0 RID: 247520 RVA: 0x00F57CDA File Offset: 0x00F55EDA
		private bool IsInstChallengeFinish()
		{
			return ModelBase<DangoAbyssModel>.Instance.CheckInAbyss() && ModelBase<DangoAbyssModel>.Instance.IsChallengeFinish();
		}

		// Token: 0x0603C6E1 RID: 247521 RVA: 0x00F57CF4 File Offset: 0x00F55EF4
		private void CloseReviveView()
		{
			EUiViewName? openedViewName = ModelBase<DeadReviveModel>.Instance.OpenedViewName;
			if (openedViewName != null && Singleton<UiManager>.Instance.IsViewOpen(openedViewName.Value))
			{
				Singleton<UiManager>.Instance.CloseView(openedViewName.Value, null);
			}
			ModelBase<DeadReviveModel>.Instance.OpenedViewName = null;
		}

		// Token: 0x0603C6E2 RID: 247522 RVA: 0x00F57D4C File Offset: 0x00F55F4C
		private void NoLoadingTeleport(FVectorDouble location, FRotator? rotator, [Nullable(2)] global::Vector gravity, string reason)
		{
			ITeleportContextParam param = new ITeleportContextParam
			{
				ClientReason = reason,
				TargetPosition = location,
				TargetRotation = rotator,
				TargetGravityDirect = gravity,
				TeleportMode = new ETeleportMode?(ETeleportMode.Auto)
			};
			ControllerBase<TeleportController>.Instance.TeleportPlayer(param).ContinueWith(delegate(bool result)
			{
				ControllerBase<SceneTeamController>.Instance.ShowControlledRole(ModelBase<PlayerInfoModel>.Instance.GetId().Value);
				TeleportFinishRequest message = TeleportFinishRequest.Create();
				Singleton<Net>.Instance.Call<TeleportFinishResponse>(ERequestMessageId.TeleportFinishRequest, message, delegate(TeleportFinishResponse response, Net.CallbackStatus status)
				{
				}, 0);
				int changeRoleIdAfterRevive = ModelBase<DeadReviveModel>.Instance.ChangeRoleIdAfterRevive;
				if (changeRoleIdAfterRevive != 0)
				{
					SceneTeamItem teamItem = ModelBase<SceneTeamModel>.Instance.GetTeamItem((long)changeRoleIdAfterRevive, new GetTeamItemOptions
					{
						ParamType = ETeamParamType.ConfigId,
						OnlyMyRole = new bool?(true)
					});
					ModelBase<DeadReviveModel>.Instance.ChangeRoleIdAfterRevive = 0;
					if (teamItem != null)
					{
						ControllerBase<SceneTeamController>.Instance.RequestChangeRole(teamItem.GetCreatureDataId(), null);
					}
				}
			}).Forget();
		}

		// Token: 0x0603C6E3 RID: 247523 RVA: 0x00F57DC4 File Offset: 0x00F55FC4
		[NullableContext(2)]
		private void AbyssReviveNotify(AbyssReviveNotify notify, Net.CallbackStatus status)
		{
			if (notify == null)
			{
				return;
			}
			DeadReviveModel instance = ModelBase<DeadReviveModel>.Instance;
			instance.CurrentShareReviveTimes = notify.CurReviveTimes;
			instance.MaxShareReviveTimes = notify.MaxReviveTimes;
			if (instance.MaxShareReviveTimes > 0)
			{
				instance.ReviveMode = EReviveMode.ShareReviveTimes;
			}
			Singleton<EventSystem>.Instance.Emit(EEventName.OnShareReviveTimesChange);
		}

		// Token: 0x0603C6E4 RID: 247524 RVA: 0x00F57E14 File Offset: 0x00F56014
		public void TryReviveCurrentRoleByShare()
		{
			SceneTeamItem getCurrentTeamItem = ModelBase<SceneTeamModel>.Instance.GetCurrentTeamItem;
			if (getCurrentTeamItem == null)
			{
				return;
			}
			this.RequestReviveRoleByShare(getCurrentTeamItem.GetConfigId);
		}

		// Token: 0x0603C6E5 RID: 247525 RVA: 0x00F57E3C File Offset: 0x00F5603C
		private void TryReviveRoleByShare(int roleId, bool needChangeRole)
		{
			if (ModelBase<DeadReviveModel>.Instance.CurrentShareReviveTimes <= 0)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("TuanZiAbyss_RE_NoNum", Array.Empty<object>());
				return;
			}
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.ShareReviveRole);
			confirmBoxDataNew.FunctionMap[2] = delegate()
			{
				if (needChangeRole)
				{
					ModelBase<DeadReviveModel>.Instance.ChangeRoleIdAfterRevive = roleId;
				}
				this.RequestReviveRoleByShare(roleId);
			};
			int currentShareReviveTimes = ModelBase<DeadReviveModel>.Instance.CurrentShareReviveTimes;
			int maxShareReviveTimes = ModelBase<DeadReviveModel>.Instance.MaxShareReviveTimes;
			confirmBoxDataNew.SetTextArgs(new string[]
			{
				currentShareReviveTimes.ToString(),
				maxShareReviveTimes.ToString()
			});
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
		}

		// Token: 0x0603C6E6 RID: 247526 RVA: 0x00F57EEC File Offset: 0x00F560EC
		private void RequestReviveRoleByShare(int roleId)
		{
			AbyssReviveCharacterRequest abyssReviveCharacterRequest = AbyssReviveCharacterRequest.Create();
			abyssReviveCharacterRequest.RoleId = roleId;
			Singleton<Net>.Instance.Call<AbyssReviveCharacterResponse>(ERequestMessageId.AbyssReviveCharacterRequest, abyssReviveCharacterRequest, delegate(AbyssReviveCharacterResponse _, Net.CallbackStatus _)
			{
			}, 0);
		}

		// Token: 0x0603C6E7 RID: 247527 RVA: 0x00F57F38 File Offset: 0x00F56138
		[NullableContext(2)]
		private void AbyssReviveTimeNotify(AbyssReviveTimeNotify notify, Net.CallbackStatus status)
		{
			foreach (AbyssEntityReviveTime abyssEntityReviveTime in notify.ReviveTimeList)
			{
				ModelBase<DeadReviveModel>.Instance.RegisterCooldown(abyssEntityReviveTime.EntityId, abyssEntityReviveTime.ReviveTime);
			}
		}

		// Token: 0x0603C6E8 RID: 247528 RVA: 0x00F57F94 File Offset: 0x00F56194
		private void OnRoleRevive(Entity entity)
		{
			CreatureDataComponent component = entity.GetComponent<CreatureDataComponent>();
			long creatureDataId = (component != null) ? component.GetCreatureDataId() : 0L;
			ModelBase<DeadReviveModel>.Instance.UnRegisterCooldown(creatureDataId);
		}

		// Token: 0x04021F81 RID: 139137
		private const int TIME_TO_REVIVE = 3000;

		// Token: 0x04021F82 RID: 139138
		private const int LOGIN_REVIVE = 1000;

		// Token: 0x04021F83 RID: 139139
		private const float OPEN_FADE_DURATION = 0.1f;

		// Token: 0x04021F84 RID: 139140
		private const float CLOSE_FADE_DURATION = 0.5f;

		// Token: 0x04021F85 RID: 139141
		private bool IsReviving;
	}
}
