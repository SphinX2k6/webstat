using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Aki.TDConfigMgr.Action;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.DeadRevive;
using CSharpScript.Game.Module.Teleport;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.LevelGamePlay.ResetPlayer
{
	// Token: 0x02006B2B RID: 27435
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class ResetPlayerController : ControllerBase<ResetPlayerController>
	{
		// Token: 0x06043C96 RID: 277654 RVA: 0x01183214 File Offset: 0x01181414
		protected override bool OnInit()
		{
			Singleton<Net>.Instance.Register<ActionResetPosPrePerformanceNotify>(ENotifyMessageId.ActionResetPosPrePerformanceNotify, new Action<ActionResetPosPrePerformanceNotify, Net.CallbackStatus>(this.ActionResetPosPrePerformanceNotify));
			return true;
		}

		// Token: 0x06043C97 RID: 277655 RVA: 0x01183233 File Offset: 0x01181433
		protected override bool OnLeaveLevel()
		{
			this.StopReset();
			return true;
		}

		// Token: 0x06043C98 RID: 277656 RVA: 0x0118323C File Offset: 0x0118143C
		protected override bool OnChangeMode()
		{
			this.StopReset();
			return true;
		}

		// Token: 0x06043C99 RID: 277657 RVA: 0x01183245 File Offset: 0x01181445
		protected override bool OnClear()
		{
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.ActionResetPosPrePerformanceNotify);
			return true;
		}

		// Token: 0x06043C9A RID: 277658 RVA: 0x01183258 File Offset: 0x01181458
		private void ActionResetPosPrePerformanceNotify(ActionResetPosPrePerformanceNotify notify, [Nullable(2)] Net.CallbackStatus _)
		{
			IActionResetReplyData replyData = new IActionResetReplyData
			{
				PlayerId = notify.PlayerId,
				IncId = notify.IncId,
				Index = notify.Index
			};
			EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
			BaseTagComponent baseTagComponent;
			if (getCurrentEntity == null)
			{
				baseTagComponent = null;
			}
			else
			{
				WorldEntity entity = getCurrentEntity.Entity;
				baseTagComponent = ((entity != null) ? entity.GetComponent<BaseTagComponent>() : null);
			}
			BaseTagComponent baseTagComponent2 = baseTagComponent;
			if (ModelBase<SceneTeamModel>.Instance.IsAllDid() || (baseTagComponent2 != null && baseTagComponent2.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.溺水"])))
			{
				Singleton<global::Log>.Instance.Warn(ELogModule.LevelPlay, ELogAuthor.LYY, "玩家重置时正在溺水或已死亡，不执行", default(ReadOnlySpan<ValueTuple<string, object>>));
				this.InterruptExecuteRequest(replyData);
				return;
			}
			ResetPlayerModel instance = ModelBase<ResetPlayerModel>.Instance;
			if (instance.IsReseting)
			{
				Singleton<global::Log>.Instance.Warn(ELogModule.LevelPlay, ELogAuthor.LYY, "玩家重置中，不可重复执行", default(ReadOnlySpan<ValueTuple<string, object>>));
				this.InterruptExecuteRequest(replyData);
				return;
			}
			if (this.GetPlayerCueComp() == null)
			{
				Singleton<global::Log>.Instance.Error(ELogModule.LevelPlay, ELogAuthor.LYY, "执行重置时，玩家实体不存在", default(ReadOnlySpan<ValueTuple<string, object>>));
				this.InterruptExecuteRequest(replyData);
				return;
			}
			ResetPlayerPosWithPresentation resetPlayerPosWithPresentation = Json.Parse<ResetPlayerPosWithPresentation>(notify.Params, null);
			if (resetPlayerPosWithPresentation == null)
			{
				Singleton<global::Log>.Instance.Error(ELogModule.LevelPlay, ELogAuthor.LYY, "执行重置时，参数错误", default(ReadOnlySpan<ValueTuple<string, object>>));
				this.InterruptExecuteRequest(replyData);
				return;
			}
			IResetPresentationFailure presentation = resetPlayerPosWithPresentation.Presentation;
			if (presentation.Type != EResetPresentationType.Failure)
			{
				this.InterruptExecuteRequest(replyData);
				return;
			}
			IResetPresentationFailure resetPresentationFailure = presentation;
			List<int> gamePlayCues = resetPresentationFailure.GamePlayCues;
			instance.IsReseting = true;
			ControllerBase<InputDistributeController>.Instance.RefreshInputTag();
			ModelBase<DeadReviveModel>.Instance.SetSkipFallInjure(ESkipFallInjureReason.ResetPlayer, true);
			EntityHandle getCurrentEntity2 = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
			UeMovementTickManageComponent ueMovementTickManageComponent;
			if (getCurrentEntity2 == null)
			{
				ueMovementTickManageComponent = null;
			}
			else
			{
				WorldEntity entity2 = getCurrentEntity2.Entity;
				ueMovementTickManageComponent = ((entity2 != null) ? entity2.GetComponent<UeMovementTickManageComponent>() : null);
			}
			UeMovementTickManageComponent ueMovementTickManageComponent2 = ueMovementTickManageComponent;
			if (ueMovementTickManageComponent2 != null)
			{
				ueMovementTickManageComponent2.DisableByKey(EEntityDisableKey.ResetPlayer, true);
				instance.DisableMoveEntityHandle = getCurrentEntity2;
			}
			if (gamePlayCues != null)
			{
				BaseGameplayCueComponent playerCueComp = this.GetPlayerCueComp();
				if (playerCueComp != null)
				{
					foreach (int num in gamePlayCues)
					{
						instance.CueHandleSet.Add(playerCueComp.AddCue((long)num, null));
					}
				}
			}
			TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
			{
				this.ContinueExecuteRequest(replyData);
			}, resetPresentationFailure.Duration * 1000f, null, null, true, 1f);
		}

		// Token: 0x06043C9B RID: 277659 RVA: 0x011834D8 File Offset: 0x011816D8
		private void InterruptExecuteRequest(IActionResetReplyData data)
		{
			ActionResetPosPrePerformanceEndRequest actionResetPosPrePerformanceEndRequest = new ActionResetPosPrePerformanceEndRequest();
			actionResetPosPrePerformanceEndRequest.ContinueExecute = false;
			actionResetPosPrePerformanceEndRequest.PlayerId = data.PlayerId;
			actionResetPosPrePerformanceEndRequest.IncId = data.IncId;
			actionResetPosPrePerformanceEndRequest.Index = data.Index;
			Singleton<Net>.Instance.Call<ActionResetPosPrePerformanceEndResponse>(ERequestMessageId.ActionResetPosPrePerformanceEndRequest, actionResetPosPrePerformanceEndRequest, null, 0);
		}

		// Token: 0x06043C9C RID: 277660 RVA: 0x01183528 File Offset: 0x01181728
		private void ContinueExecuteRequest(IActionResetReplyData data)
		{
			ActionResetPosPrePerformanceEndRequest actionResetPosPrePerformanceEndRequest = new ActionResetPosPrePerformanceEndRequest();
			actionResetPosPrePerformanceEndRequest.ContinueExecute = true;
			actionResetPosPrePerformanceEndRequest.PlayerId = data.PlayerId;
			actionResetPosPrePerformanceEndRequest.IncId = data.IncId;
			actionResetPosPrePerformanceEndRequest.Index = data.Index;
			Singleton<Net>.Instance.Call<ActionResetPosPrePerformanceEndResponse>(ERequestMessageId.ActionResetPosPrePerformanceEndRequest, actionResetPosPrePerformanceEndRequest, delegate(ActionResetPosPrePerformanceEndResponse response, Net.CallbackStatus _)
			{
				if (response == null || response.Code != ErrorCode.Success)
				{
					Singleton<global::Log>.Instance.Error(ELogModule.LevelPlay, ELogAuthor.LYY, "玩家重置请求传送失败", default(ReadOnlySpan<ValueTuple<string, object>>));
					this.StopReset();
					return;
				}
				if (!ModelBase<TeleportModel>.Instance.IsTeleport)
				{
					this.StopReset();
					return;
				}
				if (ModelBase<GameModeModel>.Instance.LoadingPhase < ELoadingPhase.OpenLoadingEnd)
				{
					Singleton<EventSystem>.Instance.Add(EEventName.TeleportOpenLoadingEnd, new Action(this.OnTeleportOpenLoadingEnd));
				}
				else
				{
					this.RemovePlayerCue();
				}
				Singleton<EventSystem>.Instance.Add<TeleportContext>(EEventName.TeleportComplete, new Action<TeleportContext>(this.OnTeleportComplete));
			}, 0);
		}

		// Token: 0x06043C9D RID: 277661 RVA: 0x01183583 File Offset: 0x01181783
		private void OnTeleportOpenLoadingEnd()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.TeleportOpenLoadingEnd, new Action(this.OnTeleportOpenLoadingEnd));
			this.RemovePlayerCue();
		}

		// Token: 0x06043C9E RID: 277662 RVA: 0x011835A7 File Offset: 0x011817A7
		[NullableContext(2)]
		private void OnTeleportComplete(TeleportContext _)
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.TeleportComplete, new Action<TeleportContext>(this.OnTeleportComplete));
			this.StopReset();
		}

		// Token: 0x06043C9F RID: 277663 RVA: 0x011835CC File Offset: 0x011817CC
		private void StopReset()
		{
			ResetPlayerModel instance = ModelBase<ResetPlayerModel>.Instance;
			if (!instance.IsReseting)
			{
				return;
			}
			instance.IsReseting = false;
			ControllerBase<InputDistributeController>.Instance.RefreshInputTag();
			this.RemovePlayerCue();
			ModelBase<DeadReviveModel>.Instance.SetSkipFallInjure(ESkipFallInjureReason.ResetPlayer, false);
			EntityHandle disableMoveEntityHandle = instance.DisableMoveEntityHandle;
			if (disableMoveEntityHandle != null && disableMoveEntityHandle.Valid)
			{
				WorldEntity entity = disableMoveEntityHandle.Entity;
				UeMovementTickManageComponent ueMovementTickManageComponent = (entity != null) ? entity.GetComponent<UeMovementTickManageComponent>() : null;
				if (ueMovementTickManageComponent != null)
				{
					ueMovementTickManageComponent.EnableByKey(EEntityDisableKey.ResetPlayer, true);
				}
			}
			instance.DisableMoveEntityHandle = null;
		}

		// Token: 0x06043CA0 RID: 277664 RVA: 0x01183644 File Offset: 0x01181844
		private void RemovePlayerCue()
		{
			ResetPlayerModel instance = ModelBase<ResetPlayerModel>.Instance;
			if (instance.CueHandleSet.Count <= 0)
			{
				return;
			}
			BaseGameplayCueComponent playerCueComp = this.GetPlayerCueComp();
			if (playerCueComp == null)
			{
				instance.CueHandleSet.Clear();
				return;
			}
			foreach (int num in instance.CueHandleSet)
			{
				playerCueComp.RemoveCueByHandle((long)num);
			}
		}

		// Token: 0x06043CA1 RID: 277665 RVA: 0x011836C4 File Offset: 0x011818C4
		[NullableContext(2)]
		private BaseGameplayCueComponent GetPlayerCueComp()
		{
			int playerId = ModelBase<CreatureModel>.Instance.GetPlayerId();
			WorldEntity playerEntity = ControllerBase<FormationDataController>.Instance.GetPlayerEntity(playerId);
			if (playerEntity == null)
			{
				return null;
			}
			return playerEntity.GetComponent<PlayerGameplayCueComponent>();
		}
	}
}
