using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Component;
using AkiClient.Game.Aki.Data.Gameplay.WuWaGo;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.WuwaGo.Controller.GameplayEntity;
using CSharpScript.Game.Module.WuwaGo.Controller.Role;
using CSharpScript.Game.Module.WuwaGo.Model;
using CSharpScript.Game.Module.WuwaGo.Model.GameplayEntity;
using CSharpScript.Game.Module.WuwaGo.Model.Role;
using CSharpScript.Game.Module.WuwaGo.Movement;
using CSharpScript.Game.Module.WuwaGo.Round;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.WuwaGo.Controller.GameMode
{
	// Token: 0x02004B17 RID: 19223
	[NullableContext(1)]
	[Nullable(0)]
	public abstract class WuWaGoGameModeBase
	{
		// Token: 0x17008599 RID: 34201
		// (get) Token: 0x0603221E RID: 205342 RVA: 0x00C8B8F3 File Offset: 0x00C89AF3
		public WuWaGoGameData RuntimeGameData
		{
			get
			{
				return this.GameData;
			}
		}

		// Token: 0x1700859A RID: 34202
		// (get) Token: 0x0603221F RID: 205343 RVA: 0x00C8B8FB File Offset: 0x00C89AFB
		public IGameplayEntityLinkService GameplayEntityLinkService
		{
			get
			{
				return this.GameplayEntityLinkServiceInner;
			}
		}

		// Token: 0x1700859B RID: 34203
		// (get) Token: 0x06032220 RID: 205344 RVA: 0x00C8B903 File Offset: 0x00C89B03
		public bool IsCinematicPlaying
		{
			get
			{
				return this.CinematicPlaying;
			}
		}

		// Token: 0x1700859C RID: 34204
		// (get) Token: 0x06032221 RID: 205345 RVA: 0x00C8B90B File Offset: 0x00C89B0B
		public bool IsDeathSequenceActive
		{
			get
			{
				return this.DeathSequenceActiveInner;
			}
		}

		// Token: 0x06032222 RID: 205346 RVA: 0x00C8B914 File Offset: 0x00C89B14
		[NullableContext(0)]
		public UniTask<bool> Start([Nullable(1)] WuWaGoGameData gameData)
		{
			WuWaGoGameModeBase.<Start>d__30 <Start>d__;
			<Start>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<Start>d__.<>4__this = this;
			<Start>d__.gameData = gameData;
			<Start>d__.<>1__state = -1;
			<Start>d__.<>t__builder.Start<WuWaGoGameModeBase.<Start>d__30>(ref <Start>d__);
			return <Start>d__.<>t__builder.Task;
		}

		// Token: 0x06032223 RID: 205347 RVA: 0x00C8B960 File Offset: 0x00C89B60
		public bool End()
		{
			WuWaGoTimeStop.CancelAll("GameMode.End");
			bool result;
			try
			{
				Singleton<UiManager>.Instance.CloseView(EUiViewName.WuWaGoView, null);
				this.EnableDisabledEntity();
				this.RemoveEventListeners();
				this.CancelPendingDeathPopupWait();
				this.DeathSequenceActiveInner = false;
				this.ActiveDamageBatchReasons.Clear();
				this.PendingMainRoleDeadId = null;
				this.DestroyAllDeactivatedRoleControllers();
				foreach (KeyValuePair<int, WuWaGoRoleController> keyValuePair in this.AllRoleControllers)
				{
					int num;
					WuWaGoRoleController wuWaGoRoleController;
					keyValuePair.Deconstruct(out num, out wuWaGoRoleController);
					wuWaGoRoleController.Destroy();
				}
				this.AllRoleControllers.Clear();
				foreach (KeyValuePair<int, GameplayEntityControllerBase> keyValuePair2 in this.AllEntityControllers)
				{
					int num;
					GameplayEntityControllerBase gameplayEntityControllerBase;
					keyValuePair2.Deconstruct(out num, out gameplayEntityControllerBase);
					gameplayEntityControllerBase.Destroy();
				}
				this.AllEntityControllers.Clear();
				this.TickListeners.Clear();
				this.RollbackManager.Clear();
				this.RoundManager.Clear();
				this.AllGridControllers.Clear();
				this.DestroyAllRuntimeActors();
				this.RollbackManager = null;
				this.GridMutationService = null;
				this.GameplayEntityLinkServiceInner = null;
				result = this.OnEnd();
			}
			finally
			{
				WuWaGoTimeStop.Clear();
			}
			return result;
		}

		// Token: 0x06032224 RID: 205348 RVA: 0x00C8BAFC File Offset: 0x00C89CFC
		public void Tick(float delta)
		{
			this.RollbackManager.TickYield();
			if (this.RollbackManager.IsRestoring)
			{
				return;
			}
			this.OnTick(delta);
			this.TickRegisteredListeners(delta);
		}

		// Token: 0x06032225 RID: 205349 RVA: 0x00C8BB28 File Offset: 0x00C89D28
		private UniTask DisableCurrentEntityAsync()
		{
			WuWaGoGameModeBase.<DisableCurrentEntityAsync>d__33 <DisableCurrentEntityAsync>d__;
			<DisableCurrentEntityAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<DisableCurrentEntityAsync>d__.<>4__this = this;
			<DisableCurrentEntityAsync>d__.<>1__state = -1;
			<DisableCurrentEntityAsync>d__.<>t__builder.Start<WuWaGoGameModeBase.<DisableCurrentEntityAsync>d__33>(ref <DisableCurrentEntityAsync>d__);
			return <DisableCurrentEntityAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06032226 RID: 205350 RVA: 0x00C8BB6B File Offset: 0x00C89D6B
		private void EnableDisabledEntity()
		{
			if (this.DisabledEntity != null)
			{
				this.DisabledEntity.Enable(this.DisableId, "WuWaGo");
				this.DisabledEntity = null;
				this.DisableId = 0;
			}
		}

		// Token: 0x06032227 RID: 205351
		protected abstract bool OnStart();

		// Token: 0x06032228 RID: 205352 RVA: 0x00C8BB9A File Offset: 0x00C89D9A
		protected virtual void OnTick(float delta)
		{
		}

		// Token: 0x06032229 RID: 205353
		protected abstract bool OnEnd();

		// Token: 0x0603222A RID: 205354 RVA: 0x00C8BB9C File Offset: 0x00C89D9C
		private void AddEventListeners()
		{
			Singleton<EventSystem>.Instance.Add<int>(EEventName.OnWuWaGoRoleDead, new Action<int>(this.OnRoleDead));
			Singleton<EventSystem>.Instance.Add<bool, string>(EEventName.OnWuWaGoDamageBatchStateChanged, new Action<bool, string>(this.OnDamageBatchStateChanged));
			Singleton<EventSystem>.Instance.Add<EUiViewName, int>(EEventName.CloseView, new Action<EUiViewName, int>(this.OnAnyViewClose));
			Singleton<EventSystem>.Instance.Add<AActor, int>(EEventName.OnAnimNotifyMaterialControllerHandleAdded, new Action<AActor, int>(this.OnAnimNotifyMaterialHandleAdded));
		}

		// Token: 0x0603222B RID: 205355 RVA: 0x00C8BC18 File Offset: 0x00C89E18
		private void RemoveEventListeners()
		{
			Singleton<EventSystem>.Instance.Remove<int>(EEventName.OnWuWaGoRoleDead, new Action<int>(this.OnRoleDead));
			Singleton<EventSystem>.Instance.Remove<bool, string>(EEventName.OnWuWaGoDamageBatchStateChanged, new Action<bool, string>(this.OnDamageBatchStateChanged));
			Singleton<EventSystem>.Instance.Remove<EUiViewName, int>(EEventName.CloseView, new Action<EUiViewName, int>(this.OnAnyViewClose));
			Singleton<EventSystem>.Instance.Remove<AActor, int>(EEventName.OnAnimNotifyMaterialControllerHandleAdded, new Action<AActor, int>(this.OnAnimNotifyMaterialHandleAdded));
		}

		// Token: 0x0603222C RID: 205356 RVA: 0x00C8BC94 File Offset: 0x00C89E94
		private void OnAnimNotifyMaterialHandleAdded(AActor actor, int handle)
		{
			foreach (KeyValuePair<int, WuWaGoRoleController> keyValuePair in this.AllRoleControllers)
			{
				int num;
				WuWaGoRoleController wuWaGoRoleController;
				keyValuePair.Deconstruct(out num, out wuWaGoRoleController);
				WuWaGoRoleController wuWaGoRoleController2 = wuWaGoRoleController;
				if (wuWaGoRoleController2.BaseRole.GetActorAsObject() == actor)
				{
					wuWaGoRoleController2.BaseRole.AddMaterialHandle(handle);
					break;
				}
			}
		}

		// Token: 0x0603222D RID: 205357 RVA: 0x00C8BD0C File Offset: 0x00C89F0C
		private void OnRoleDead(int roleId)
		{
			WuWaGoRoleController wuWaGoRoleController;
			if (!this.AllRoleControllers.TryGetValue(roleId, out wuWaGoRoleController))
			{
				return;
			}
			if (this.CinematicPlaying && !wuWaGoRoleController.BaseRole.IsMonster)
			{
				return;
			}
			if (wuWaGoRoleController.BaseRole.IsMonster)
			{
				if (this.DeactivatedDeadRoleControllers.Contains(wuWaGoRoleController))
				{
					return;
				}
				this.DeactivateDeadRoleController(wuWaGoRoleController);
				this.DeactivatedDeadRoleControllers.Add(wuWaGoRoleController);
				return;
			}
			else
			{
				if (this.IsDamageBatchActive())
				{
					this.PendingMainRoleDeadId = new int?(roleId);
					return;
				}
				this.HandleMainRoleDead(wuWaGoRoleController.BaseRole as WuWaGoMainControlRole);
				return;
			}
		}

		// Token: 0x0603222E RID: 205358 RVA: 0x00C8BD98 File Offset: 0x00C89F98
		private void OnDamageBatchStateChanged(bool isActive, string reason)
		{
			if (isActive)
			{
				int num;
				this.ActiveDamageBatchReasons[reason] = (this.ActiveDamageBatchReasons.TryGetValue(reason, out num) ? (num + 1) : 1);
				return;
			}
			int num2;
			if (!this.ActiveDamageBatchReasons.TryGetValue(reason, out num2))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.WuWaGo;
				ELogAuthor author = ELogAuthor.YSQ;
				string message = "收到未开始的批处理伤害机关结束事件";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("reason", reason);
				instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			if (num2 <= 1)
			{
				this.ActiveDamageBatchReasons.Remove(reason);
			}
			else
			{
				this.ActiveDamageBatchReasons[reason] = num2 - 1;
			}
			if (!this.IsDamageBatchActive())
			{
				this.FlushPendingMainRoleDead();
			}
		}

		// Token: 0x0603222F RID: 205359 RVA: 0x00C8BE36 File Offset: 0x00C8A036
		public bool IsDamageBatchActive()
		{
			return this.ActiveDamageBatchReasons.Count > 0;
		}

		// Token: 0x06032230 RID: 205360 RVA: 0x00C8BE48 File Offset: 0x00C8A048
		private void FlushPendingMainRoleDead()
		{
			int? pendingMainRoleDeadId = this.PendingMainRoleDeadId;
			if (pendingMainRoleDeadId == null)
			{
				return;
			}
			this.PendingMainRoleDeadId = null;
			WuWaGoRoleController wuWaGoRoleController;
			if (!this.AllRoleControllers.TryGetValue(pendingMainRoleDeadId.Value, out wuWaGoRoleController) || wuWaGoRoleController.BaseRole.IsMonster || !wuWaGoRoleController.BaseRole.IsDead)
			{
				return;
			}
			this.HandleMainRoleDead(wuWaGoRoleController.BaseRole as WuWaGoMainControlRole);
		}

		// Token: 0x06032231 RID: 205361 RVA: 0x00C8BEB4 File Offset: 0x00C8A0B4
		private void HandleMainRoleDead(WuWaGoMainControlRole mainRole)
		{
			if (this.DeathSequenceActiveInner)
			{
				return;
			}
			mainRole.DeathCount++;
			this.RefreshPlayTipAvailable();
			this.RollbackManager.FlushPendingPlayerActionTracking();
			this.DeathSequenceActiveInner = true;
			this.RunDeathSequenceWithResetAsync().Forget();
		}

		// Token: 0x06032232 RID: 205362 RVA: 0x00C8BEF0 File Offset: 0x00C8A0F0
		private UniTask RunDeathSequenceWithResetAsync()
		{
			WuWaGoGameModeBase.<RunDeathSequenceWithResetAsync>d__46 <RunDeathSequenceWithResetAsync>d__;
			<RunDeathSequenceWithResetAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RunDeathSequenceWithResetAsync>d__.<>4__this = this;
			<RunDeathSequenceWithResetAsync>d__.<>1__state = -1;
			<RunDeathSequenceWithResetAsync>d__.<>t__builder.Start<WuWaGoGameModeBase.<RunDeathSequenceWithResetAsync>d__46>(ref <RunDeathSequenceWithResetAsync>d__);
			return <RunDeathSequenceWithResetAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06032233 RID: 205363 RVA: 0x00C8BF34 File Offset: 0x00C8A134
		private UniTask RunDeathSequenceAsync()
		{
			WuWaGoGameModeBase.<RunDeathSequenceAsync>d__47 <RunDeathSequenceAsync>d__;
			<RunDeathSequenceAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RunDeathSequenceAsync>d__.<>4__this = this;
			<RunDeathSequenceAsync>d__.<>1__state = -1;
			<RunDeathSequenceAsync>d__.<>t__builder.Start<WuWaGoGameModeBase.<RunDeathSequenceAsync>d__47>(ref <RunDeathSequenceAsync>d__);
			return <RunDeathSequenceAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06032234 RID: 205364 RVA: 0x00C8BF77 File Offset: 0x00C8A177
		private void OnAnyViewClose(EUiViewName viewName, int viewId)
		{
			if (viewName != EUiViewName.WuWaGoPopupView)
			{
				return;
			}
			this.CancelPendingDeathPopupWait();
		}

		// Token: 0x06032235 RID: 205365 RVA: 0x00C8BF90 File Offset: 0x00C8A190
		private void CancelPendingDeathPopupWait()
		{
			if (this.DeathPopupClosedPromise != null)
			{
				this.DeathPopupClosedPromise.SetResult(default(UniTaskVoid));
				this.DeathPopupClosedPromise = null;
			}
		}

		// Token: 0x06032236 RID: 205366 RVA: 0x00C8BFC0 File Offset: 0x00C8A1C0
		private void DeactivateDeadRoleController(WuWaGoRoleController controller)
		{
			this.RoundManager.RemoveController(controller);
			this.TickListeners.Remove(controller);
			controller.BaseRole.SetStandGrid(null, null);
			controller.BaseRole.SetHiddenInGame(true);
		}

		// Token: 0x06032237 RID: 205367 RVA: 0x00C8BFF4 File Offset: 0x00C8A1F4
		private void DestroyAllDeactivatedRoleControllers()
		{
			foreach (WuWaGoRoleController controller in this.DeactivatedDeadRoleControllers)
			{
				this.DestroyDeactivatedRoleController(controller);
			}
			this.DeactivatedDeadRoleControllers.Clear();
		}

		// Token: 0x06032238 RID: 205368 RVA: 0x00C8C054 File Offset: 0x00C8A254
		private void DestroyDeactivatedRoleController(WuWaGoRoleController controller)
		{
			WuWaGoRole baseRole = controller.BaseRole;
			this.AllRoleControllers.Remove(baseRole.Id);
			this.TickListeners.Remove(controller);
			this.GameData.RemoveRole(baseRole);
			controller.Destroy();
		}

		// Token: 0x06032239 RID: 205369 RVA: 0x00C8C09C File Offset: 0x00C8A29C
		public void RestoreDeactivatedRoleControllersFromRollback()
		{
			foreach (WuWaGoRoleController wuWaGoRoleController in this.DeactivatedDeadRoleControllers)
			{
				if (!wuWaGoRoleController.BaseRole.IsDead)
				{
					ERoundStep roleStep = this.GetRoleStep(wuWaGoRoleController.BaseRole.Type);
					this.RoundManager.RegisterUnit(roleStep, wuWaGoRoleController);
					this.TryRegisterTick(wuWaGoRoleController);
					wuWaGoRoleController.BaseRole.SetHiddenInGame(false);
					this.DeactivatedDeadRoleControllers.Remove(wuWaGoRoleController);
				}
			}
			foreach (KeyValuePair<int, WuWaGoRoleController> keyValuePair in this.AllRoleControllers)
			{
				int num;
				WuWaGoRoleController wuWaGoRoleController2;
				keyValuePair.Deconstruct(out num, out wuWaGoRoleController2);
				WuWaGoRoleController wuWaGoRoleController3 = wuWaGoRoleController2;
				if (wuWaGoRoleController3.BaseRole.IsMonster && !this.DeactivatedDeadRoleControllers.Contains(wuWaGoRoleController3) && wuWaGoRoleController3.BaseRole.IsDead)
				{
					this.DeactivateDeadRoleController(wuWaGoRoleController3);
					this.DeactivatedDeadRoleControllers.Add(wuWaGoRoleController3);
				}
			}
		}

		// Token: 0x0603223A RID: 205370 RVA: 0x00C8C1C0 File Offset: 0x00C8A3C0
		public void NotifyAllControllersRollbackRestore()
		{
			foreach (KeyValuePair<int, WuWaGoRoleController> keyValuePair in this.AllRoleControllers)
			{
				int num;
				WuWaGoRoleController wuWaGoRoleController;
				keyValuePair.Deconstruct(out num, out wuWaGoRoleController);
				wuWaGoRoleController.OnRollbackRestore();
			}
			foreach (KeyValuePair<int, GameplayEntityControllerBase> keyValuePair2 in this.AllEntityControllers)
			{
				int num;
				GameplayEntityControllerBase gameplayEntityControllerBase;
				keyValuePair2.Deconstruct(out num, out gameplayEntityControllerBase);
				gameplayEntityControllerBase.OnRollbackRestore();
			}
		}

		// Token: 0x0603223B RID: 205371 RVA: 0x00C8C26C File Offset: 0x00C8A46C
		public void NotifyGameplayEntityLinkServiceRollbackRestore()
		{
			this.GameplayEntityLinkServiceInner.OnRollbackRestore();
		}

		// Token: 0x0603223C RID: 205372 RVA: 0x00C8C27C File Offset: 0x00C8A47C
		public UniTask PlayPlayTipCinematicAsync()
		{
			WuWaGoGameModeBase.<PlayPlayTipCinematicAsync>d__56 <PlayPlayTipCinematicAsync>d__;
			<PlayPlayTipCinematicAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayPlayTipCinematicAsync>d__.<>4__this = this;
			<PlayPlayTipCinematicAsync>d__.<>1__state = -1;
			<PlayPlayTipCinematicAsync>d__.<>t__builder.Start<WuWaGoGameModeBase.<PlayPlayTipCinematicAsync>d__56>(ref <PlayPlayTipCinematicAsync>d__);
			return <PlayPlayTipCinematicAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603223D RID: 205373 RVA: 0x00C8C2BF File Offset: 0x00C8A4BF
		public void RequestInterruptPlayTipCinematic()
		{
			if (!this.CinematicPlaying)
			{
				return;
			}
			this.InterruptCinematicRequested = true;
		}

		// Token: 0x0603223E RID: 205374 RVA: 0x00C8C2D4 File Offset: 0x00C8A4D4
		public UniTask RollbackToLastStepAsync()
		{
			WuWaGoGameModeBase.<RollbackToLastStepAsync>d__58 <RollbackToLastStepAsync>d__;
			<RollbackToLastStepAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RollbackToLastStepAsync>d__.<>4__this = this;
			<RollbackToLastStepAsync>d__.<>1__state = -1;
			<RollbackToLastStepAsync>d__.<>t__builder.Start<WuWaGoGameModeBase.<RollbackToLastStepAsync>d__58>(ref <RollbackToLastStepAsync>d__);
			return <RollbackToLastStepAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603223F RID: 205375 RVA: 0x00C8C318 File Offset: 0x00C8A518
		public UniTask RollbackToSavePointAsync()
		{
			WuWaGoGameModeBase.<RollbackToSavePointAsync>d__59 <RollbackToSavePointAsync>d__;
			<RollbackToSavePointAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RollbackToSavePointAsync>d__.<>4__this = this;
			<RollbackToSavePointAsync>d__.<>1__state = -1;
			<RollbackToSavePointAsync>d__.<>t__builder.Start<WuWaGoGameModeBase.<RollbackToSavePointAsync>d__59>(ref <RollbackToSavePointAsync>d__);
			return <RollbackToSavePointAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06032240 RID: 205376 RVA: 0x00C8C35C File Offset: 0x00C8A55C
		public void NotifyArrivedSavePoint(WuWaGoGrid grid)
		{
			if (this.CinematicPlaying)
			{
				return;
			}
			WuWaGoGameplayEntityBase gameplayEntityByPbDataId = this.GameData.GetGameplayEntityByPbDataId(grid.EntityPbDataId);
			this.CurrentHintSource = (gameplayEntityByPbDataId as WuWaGoTraversalGridEntity);
			if (grid.EntityType.GetValueOrDefault() == EWuWaGoEntityType.SaveGrid)
			{
				this.RollbackManager.ResetForSavePoint();
				this.DestroyAllDeactivatedRoleControllers();
			}
			this.RefreshPlayTipAvailable();
		}

		// Token: 0x06032241 RID: 205377 RVA: 0x00C8C3B8 File Offset: 0x00C8A5B8
		public bool IsRollbackAvailable()
		{
			return !this.IsDamageBatchActive() && this.RollbackManager.IsAvailable;
		}

		// Token: 0x06032242 RID: 205378 RVA: 0x00C8C3CF File Offset: 0x00C8A5CF
		public bool CanUsePlayTip()
		{
			if (!this.IsCinematicPlaying && !this.IsDamageBatchActive() && !this.IsDeathSequenceActive && !this.IsRollbackRestoring)
			{
				WuWaGoMainControlRole mainControlRole = this.GameData.MainControlRole;
				return mainControlRole != null && mainControlRole.IsAcceptingInput;
			}
			return false;
		}

		// Token: 0x1700859D RID: 34205
		// (get) Token: 0x06032243 RID: 205379 RVA: 0x00C8C409 File Offset: 0x00C8A609
		public bool IsRollbackRestoring
		{
			get
			{
				return this.RollbackManager.IsRestoring;
			}
		}

		// Token: 0x06032244 RID: 205380 RVA: 0x00C8C416 File Offset: 0x00C8A616
		public bool CanExecuteGameplayEntityAction()
		{
			return !this.IsDeathSequenceActive && !this.IsRollbackRestoring && !this.RoundManager.ShouldAbortCurrentRound();
		}

		// Token: 0x06032245 RID: 205381 RVA: 0x00C8C438 File Offset: 0x00C8A638
		public void OnRollbackTriggered()
		{
			WuWaGoTimeStop.CancelAll("WuWaGo.Rollback");
			this.RoundManager.ResetForRollback();
		}

		// Token: 0x06032246 RID: 205382 RVA: 0x00C8C44F File Offset: 0x00C8A64F
		public void ResetPlayerActionCaptures()
		{
			this.RollbackManager.ResetPlayerActionCaptures();
		}

		// Token: 0x06032247 RID: 205383 RVA: 0x00C8C45C File Offset: 0x00C8A65C
		public void FlushPendingPlayerActionTracking()
		{
			this.RollbackManager.FlushPendingPlayerActionTracking();
		}

		// Token: 0x06032248 RID: 205384 RVA: 0x00C8C469 File Offset: 0x00C8A669
		public void BeginPlayerActionTracking()
		{
			this.RollbackManager.BeginPlayerActionTracking();
		}

		// Token: 0x06032249 RID: 205385 RVA: 0x00C8C476 File Offset: 0x00C8A676
		public void NotifyMainControlInputAcceptingChanged(bool accept)
		{
			this.RollbackManager.SetAcceptingInput(accept);
			Singleton<EventSystem>.Instance.Emit<bool>(EEventName.OnWuWaGoMainControlInputAcceptingChanged, accept);
		}

		// Token: 0x0603224A RID: 205386 RVA: 0x00C8C495 File Offset: 0x00C8A695
		public void SetMainControlInputAccepting(bool accept)
		{
			MainControlRoleController mainControlRoleController = this.GetMainControlRoleController();
			if (mainControlRoleController == null)
			{
				return;
			}
			mainControlRoleController.SetInputAcceptingFromExternal(accept);
		}

		// Token: 0x0603224B RID: 205387 RVA: 0x00C8C4A8 File Offset: 0x00C8A6A8
		private void RefreshPlayTipAvailable()
		{
			bool flag = this.ComputePlayTipAvailable();
			if (flag == this.LastEmittedPlayTipAvailable)
			{
				return;
			}
			this.LastEmittedPlayTipAvailable = flag;
			Singleton<EventSystem>.Instance.Emit<bool>(EEventName.OnWuWaGoPlayTipAvailable, flag);
		}

		// Token: 0x0603224C RID: 205388 RVA: 0x00C8C4E0 File Offset: 0x00C8A6E0
		private bool ComputePlayTipAvailable()
		{
			if (this.CinematicPlaying)
			{
				return false;
			}
			WuWaGoMainControlRole mainControlRole = this.GameData.MainControlRole;
			int num = (mainControlRole != null) ? mainControlRole.DeathCount : 0;
			BP_WuWaGo_C setting = WuWaGoGlobal.Setting;
			int num2 = (setting != null) ? setting.TipButtonShowDeadCount : 0;
			if (num < num2)
			{
				return false;
			}
			WuWaGoTraversalGridEntity currentHintSource = this.CurrentHintSource;
			IReadOnlyList<IWuWaGoHintStepBase> readOnlyList = (currentHintSource != null) ? currentHintSource.HintSteps : null;
			return readOnlyList != null && readOnlyList.Count > 0;
		}

		// Token: 0x0603224D RID: 205389 RVA: 0x00C8C546 File Offset: 0x00C8A746
		private void SetCinematicPlaying(bool playing)
		{
			if (this.CinematicPlaying == playing)
			{
				return;
			}
			this.CinematicPlaying = playing;
			if (playing)
			{
				this.InterruptCinematicRequested = false;
			}
			Singleton<EventSystem>.Instance.Emit<bool>(EEventName.OnWuWaGoCinematicPlayingChanged, playing);
			this.RefreshPlayTipAvailable();
		}

		// Token: 0x0603224E RID: 205390 RVA: 0x00C8C57C File Offset: 0x00C8A77C
		private void InitCurrentHintSource()
		{
			foreach (WuWaGoGameplayEntityBase wuWaGoGameplayEntityBase in this.GameData.GetGameplayEntitiesByType(EWuWaGoEntityType.StartGrid))
			{
				WuWaGoTraversalGridEntity wuWaGoTraversalGridEntity = wuWaGoGameplayEntityBase as WuWaGoTraversalGridEntity;
				if (wuWaGoTraversalGridEntity != null)
				{
					this.CurrentHintSource = wuWaGoTraversalGridEntity;
					this.RollbackManager.CaptureSavePointSnapshot();
					break;
				}
			}
		}

		// Token: 0x0603224F RID: 205391 RVA: 0x00C8C5E8 File Offset: 0x00C8A7E8
		[NullableContext(2)]
		private MainControlRoleController GetMainControlRoleController()
		{
			foreach (KeyValuePair<int, WuWaGoRoleController> keyValuePair in this.AllRoleControllers)
			{
				int num;
				WuWaGoRoleController wuWaGoRoleController;
				keyValuePair.Deconstruct(out num, out wuWaGoRoleController);
				MainControlRoleController mainControlRoleController = wuWaGoRoleController as MainControlRoleController;
				if (mainControlRoleController != null)
				{
					return mainControlRoleController;
				}
			}
			return null;
		}

		// Token: 0x06032250 RID: 205392 RVA: 0x00C8C658 File Offset: 0x00C8A858
		[NullableContext(2)]
		public GameplayEntityControllerBase GetEntityControllerByPbDataId(int pbDataId)
		{
			WuWaGoGameplayEntityBase gameplayEntityByPbDataId = this.GameData.GetGameplayEntityByPbDataId(pbDataId);
			if (gameplayEntityByPbDataId == null)
			{
				return null;
			}
			return this.AllEntityControllers.GetValueOrDefault(gameplayEntityByPbDataId.Id);
		}

		// Token: 0x06032251 RID: 205393 RVA: 0x00C8C688 File Offset: 0x00C8A888
		[NullableContext(2)]
		public WuWaGoRoleController GetRoleController(int roleId)
		{
			return this.AllRoleControllers.GetValueOrDefault(roleId);
		}

		// Token: 0x06032252 RID: 205394 RVA: 0x00C8C696 File Offset: 0x00C8A896
		[NullableContext(2)]
		public WuWaGoGridController GetGridControllerById(int gridId)
		{
			return this.AllGridControllers.GetValueOrDefault(gridId);
		}

		// Token: 0x06032253 RID: 205395 RVA: 0x00C8C6A4 File Offset: 0x00C8A8A4
		public void NotifyMoveMonsterActed()
		{
			this.RoundManager.NotifyMoveMonsterActed();
		}

		// Token: 0x06032254 RID: 205396 RVA: 0x00C8C6B4 File Offset: 0x00C8A8B4
		public UniTask ExecuteImmediateMovableFloorBatch(IReadOnlyList<int> pbDataIds, string batchSource)
		{
			WuWaGoGameModeBase.<ExecuteImmediateMovableFloorBatch>d__81 <ExecuteImmediateMovableFloorBatch>d__;
			<ExecuteImmediateMovableFloorBatch>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ExecuteImmediateMovableFloorBatch>d__.<>4__this = this;
			<ExecuteImmediateMovableFloorBatch>d__.pbDataIds = pbDataIds;
			<ExecuteImmediateMovableFloorBatch>d__.batchSource = batchSource;
			<ExecuteImmediateMovableFloorBatch>d__.<>1__state = -1;
			<ExecuteImmediateMovableFloorBatch>d__.<>t__builder.Start<WuWaGoGameModeBase.<ExecuteImmediateMovableFloorBatch>d__81>(ref <ExecuteImmediateMovableFloorBatch>d__);
			return <ExecuteImmediateMovableFloorBatch>d__.<>t__builder.Task;
		}

		// Token: 0x06032255 RID: 205397 RVA: 0x00C8C708 File Offset: 0x00C8A908
		public UniTask ExecutePostMovableFloorEnemyAttackJudgement(IWuWaGoMovableFloorBatchResult result)
		{
			WuWaGoGameModeBase.<ExecutePostMovableFloorEnemyAttackJudgement>d__82 <ExecutePostMovableFloorEnemyAttackJudgement>d__;
			<ExecutePostMovableFloorEnemyAttackJudgement>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ExecutePostMovableFloorEnemyAttackJudgement>d__.<>4__this = this;
			<ExecutePostMovableFloorEnemyAttackJudgement>d__.result = result;
			<ExecutePostMovableFloorEnemyAttackJudgement>d__.<>1__state = -1;
			<ExecutePostMovableFloorEnemyAttackJudgement>d__.<>t__builder.Start<WuWaGoGameModeBase.<ExecutePostMovableFloorEnemyAttackJudgement>d__82>(ref <ExecutePostMovableFloorEnemyAttackJudgement>d__);
			return <ExecutePostMovableFloorEnemyAttackJudgement>d__.<>t__builder.Task;
		}

		// Token: 0x06032256 RID: 205398 RVA: 0x00C8C754 File Offset: 0x00C8A954
		private bool ShouldStopPostMovableFloorEnemyAttackJudgement()
		{
			WuWaGoMainControlRole mainControlRole = this.GameData.MainControlRole;
			if (mainControlRole == null || mainControlRole.IsDead)
			{
				return true;
			}
			WuWaGoGrid gridById = this.GameData.GetGridById(mainControlRole.StandGridId);
			return gridById != null && gridById.IsEndPoint;
		}

		// Token: 0x06032257 RID: 205399 RVA: 0x00C8C798 File Offset: 0x00C8A998
		private void CreateAllRoleControllers(WuWaGoGameData gameData)
		{
			foreach (WuWaGoRole wuWaGoRole in gameData.AllRoles)
			{
				WuWaGoRoleController wuWaGoRoleController = this.CreateRoleController(wuWaGoRole);
				if (wuWaGoRoleController != null)
				{
					wuWaGoRoleController.Create();
					this.AllRoleControllers.Add(wuWaGoRole.Id, wuWaGoRoleController);
					ERoundStep roleStep = this.GetRoleStep(wuWaGoRole.Type);
					this.RoundManager.RegisterUnit(roleStep, wuWaGoRoleController);
					this.TryRegisterTick(wuWaGoRoleController);
				}
			}
		}

		// Token: 0x06032258 RID: 205400 RVA: 0x00C8C82C File Offset: 0x00C8AA2C
		[return: Nullable(2)]
		private WuWaGoRoleController CreateRoleController(WuWaGoRole role)
		{
			switch (role.Type)
			{
			case EWuWaGoRoleType.AircraftSoldiers:
				return new MainControlRoleController(role, this.GameData, this);
			case EWuWaGoRoleType.HeatFusionEnemy:
			{
				WuWaGoStaticMonster wuWaGoStaticMonster = role as WuWaGoStaticMonster;
				if (wuWaGoStaticMonster != null)
				{
					return new StaticMonsterController(wuWaGoStaticMonster, this.GameData, this);
				}
				return null;
			}
			case EWuWaGoRoleType.DiffractionEnemy:
			{
				WuWaGoMoveMonster wuWaGoMoveMonster = role as WuWaGoMoveMonster;
				if (wuWaGoMoveMonster != null)
				{
					return new MoveMonsterController(wuWaGoMoveMonster, this.GameData, this);
				}
				return null;
			}
			default:
				return null;
			}
		}

		// Token: 0x06032259 RID: 205401 RVA: 0x00C8C898 File Offset: 0x00C8AA98
		private void CreateAllEntityControllers(WuWaGoGameData gameData)
		{
			foreach (KeyValuePair<int, WuWaGoGameplayEntityBase> keyValuePair in gameData.AllGameplayEntities)
			{
				int num;
				WuWaGoGameplayEntityBase wuWaGoGameplayEntityBase;
				keyValuePair.Deconstruct(out num, out wuWaGoGameplayEntityBase);
				WuWaGoGameplayEntityBase wuWaGoGameplayEntityBase2 = wuWaGoGameplayEntityBase;
				GameplayEntityControllerBase gameplayEntityControllerBase = this.CreateEntityController(wuWaGoGameplayEntityBase2);
				if (gameplayEntityControllerBase != null && gameplayEntityControllerBase.Create())
				{
					this.AllEntityControllers.Add(wuWaGoGameplayEntityBase2.Id, gameplayEntityControllerBase);
					ERoundStep? entityStep = this.GetEntityStep(wuWaGoGameplayEntityBase2.EntityType);
					if (entityStep != null)
					{
						this.RoundManager.RegisterUnit(entityStep.Value, gameplayEntityControllerBase);
					}
					this.TryRegisterTick(gameplayEntityControllerBase);
				}
			}
		}

		// Token: 0x0603225A RID: 205402 RVA: 0x00C8C950 File Offset: 0x00C8AB50
		[return: Nullable(2)]
		private GameplayEntityControllerBase CreateEntityController(WuWaGoGameplayEntityBase entity)
		{
			switch (entity.EntityType)
			{
			case EWuWaGoEntityType.MovableFloor:
				return new MovableFloorController(entity, this.GameData, this);
			case EWuWaGoEntityType.PullRod:
				return new PullRodController(entity, this.GameData, this);
			case EWuWaGoEntityType.PressureTrigger:
				return new PressureTriggerController(entity, this.GameData, this);
			case EWuWaGoEntityType.Gear:
				return new GearTrapController(entity, this.GameData, this);
			case EWuWaGoEntityType.SpikeTrap:
				return new SpikeTrapController(entity, this.GameData, this);
			case EWuWaGoEntityType.BowTrap:
				return new BowTrapController(entity, this.GameData, this);
			case EWuWaGoEntityType.SaveGrid:
			case EWuWaGoEntityType.EndGrid:
			case EWuWaGoEntityType.StartGrid:
				return new TraversalGridController(entity, this.GameData, this);
			default:
				return null;
			}
		}

		// Token: 0x0603225B RID: 205403 RVA: 0x00C8C9F8 File Offset: 0x00C8ABF8
		private void CreateAllGridControllers(WuWaGoGameData gameData)
		{
			this.AllGridControllers.Clear();
			foreach (KeyValuePair<string, WuWaGoGrid> keyValuePair in gameData.Girds)
			{
				string text;
				WuWaGoGrid wuWaGoGrid;
				keyValuePair.Deconstruct(out text, out wuWaGoGrid);
				WuWaGoGrid wuWaGoGrid2 = wuWaGoGrid;
				this.AllGridControllers.Add(wuWaGoGrid2.Id, new WuWaGoGridController(wuWaGoGrid2));
			}
		}

		// Token: 0x0603225C RID: 205404 RVA: 0x00C8CA74 File Offset: 0x00C8AC74
		private void TryRegisterTick(IExecutableUnit controller)
		{
			FieldInfo field = controller.GetType().GetField("EnableTick", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
			if ((((field != null) ? field.GetValue(null) : null) as bool?).GetValueOrDefault())
			{
				this.TickListeners.Add(controller);
			}
		}

		// Token: 0x0603225D RID: 205405 RVA: 0x00C8CAC4 File Offset: 0x00C8ACC4
		private void TickRegisteredListeners(float delta)
		{
			foreach (IExecutableUnit executableUnit in this.TickListeners)
			{
				executableUnit.OnTick(delta);
			}
		}

		// Token: 0x0603225E RID: 205406 RVA: 0x00C8CB18 File Offset: 0x00C8AD18
		private ERoundStep GetRoleStep(EWuWaGoRoleType roleType)
		{
			if (roleType == EWuWaGoRoleType.AircraftSoldiers)
			{
				return ERoundStep.PlayerAction;
			}
			if (roleType - EWuWaGoRoleType.HeatFusionEnemy > 1)
			{
				return ERoundStep.MonsterAction;
			}
			return ERoundStep.MonsterAction;
		}

		// Token: 0x0603225F RID: 205407 RVA: 0x00C8CB2C File Offset: 0x00C8AD2C
		private ERoundStep? GetEntityStep(EWuWaGoEntityType entityType)
		{
			switch (entityType)
			{
			case EWuWaGoEntityType.MovableFloor:
				return new ERoundStep?(ERoundStep.MovableFloor);
			case EWuWaGoEntityType.PressureTrigger:
				return new ERoundStep?(ERoundStep.PressureTrigger);
			case EWuWaGoEntityType.Gear:
				return new ERoundStep?(ERoundStep.GearTrap);
			case EWuWaGoEntityType.SpikeTrap:
				return new ERoundStep?(ERoundStep.SpikeTrap);
			case EWuWaGoEntityType.BowTrap:
				return new ERoundStep?(ERoundStep.BowTrap);
			}
			return null;
		}

		// Token: 0x06032260 RID: 205408 RVA: 0x00C8CB88 File Offset: 0x00C8AD88
		private UniTask CreateAllAppliques(WuWaGoGameData gameData)
		{
			WuWaGoGameModeBase.<CreateAllAppliques>d__93 <CreateAllAppliques>d__;
			<CreateAllAppliques>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateAllAppliques>d__.gameData = gameData;
			<CreateAllAppliques>d__.<>1__state = -1;
			<CreateAllAppliques>d__.<>t__builder.Start<WuWaGoGameModeBase.<CreateAllAppliques>d__93>(ref <CreateAllAppliques>d__);
			return <CreateAllAppliques>d__.<>t__builder.Task;
		}

		// Token: 0x06032261 RID: 205409 RVA: 0x00C8CBCC File Offset: 0x00C8ADCC
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		private static UniTask<UStaticMesh> LoadPlaneMesh()
		{
			WuWaGoGameModeBase.<LoadPlaneMesh>d__94 <LoadPlaneMesh>d__;
			<LoadPlaneMesh>d__.<>t__builder = AsyncUniTaskMethodBuilder<UStaticMesh>.Create();
			<LoadPlaneMesh>d__.<>1__state = -1;
			<LoadPlaneMesh>d__.<>t__builder.Start<WuWaGoGameModeBase.<LoadPlaneMesh>d__94>(ref <LoadPlaneMesh>d__);
			return <LoadPlaneMesh>d__.<>t__builder.Task;
		}

		// Token: 0x06032262 RID: 205410 RVA: 0x00C8CC08 File Offset: 0x00C8AE08
		private UniTask CreateAllRoles(WuWaGoGameData gameData)
		{
			WuWaGoGameModeBase.<CreateAllRoles>d__95 <CreateAllRoles>d__;
			<CreateAllRoles>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateAllRoles>d__.gameData = gameData;
			<CreateAllRoles>d__.<>1__state = -1;
			<CreateAllRoles>d__.<>t__builder.Start<WuWaGoGameModeBase.<CreateAllRoles>d__95>(ref <CreateAllRoles>d__);
			return <CreateAllRoles>d__.<>t__builder.Task;
		}

		// Token: 0x06032263 RID: 205411 RVA: 0x00C8CC4C File Offset: 0x00C8AE4C
		private UniTask PreloadBpClass()
		{
			WuWaGoGameModeBase.<PreloadBpClass>d__96 <PreloadBpClass>d__;
			<PreloadBpClass>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PreloadBpClass>d__.<>1__state = -1;
			<PreloadBpClass>d__.<>t__builder.Start<WuWaGoGameModeBase.<PreloadBpClass>d__96>(ref <PreloadBpClass>d__);
			return <PreloadBpClass>d__.<>t__builder.Task;
		}

		// Token: 0x06032264 RID: 205412 RVA: 0x00C8CC88 File Offset: 0x00C8AE88
		private void DestroyAllRuntimeActors()
		{
			foreach (WuWaGoRole wuWaGoRole in this.GameData.AllRoles)
			{
				wuWaGoRole.Destroy();
			}
			foreach (KeyValuePair<string, WuWaGoGrid> keyValuePair in this.GameData.Girds)
			{
				string text;
				WuWaGoGrid wuWaGoGrid;
				keyValuePair.Deconstruct(out text, out wuWaGoGrid);
				wuWaGoGrid.Destroy();
			}
			foreach (KeyValuePair<int, WuWaGoGameplayEntityBase> keyValuePair2 in this.GameData.AllGameplayEntities)
			{
				int num;
				WuWaGoGameplayEntityBase wuWaGoGameplayEntityBase;
				keyValuePair2.Deconstruct(out num, out wuWaGoGameplayEntityBase);
				WuWaGoGameplayEntityBase wuWaGoGameplayEntityBase2 = wuWaGoGameplayEntityBase;
				wuWaGoGameplayEntityBase2.RestoreInitialStateForGameOver();
				wuWaGoGameplayEntityBase2.Destroy();
			}
		}

		// Token: 0x06032265 RID: 205413 RVA: 0x00C8CD8C File Offset: 0x00C8AF8C
		private List<MovableFloorController> GetMovableFloorControllersByPbDataIds(IReadOnlyList<int> pbDataIds)
		{
			HashSet<int> hashSet = new HashSet<int>(pbDataIds);
			List<MovableFloorController> list = new List<MovableFloorController>();
			foreach (KeyValuePair<int, GameplayEntityControllerBase> keyValuePair in this.AllEntityControllers)
			{
				int num;
				GameplayEntityControllerBase gameplayEntityControllerBase;
				keyValuePair.Deconstruct(out num, out gameplayEntityControllerBase);
				MovableFloorController movableFloorController = gameplayEntityControllerBase as MovableFloorController;
				if (movableFloorController != null && hashSet.Contains(movableFloorController.Entity.EntityPbDataId))
				{
					list.Add(movableFloorController);
				}
			}
			using (HashSet<int>.Enumerator enumerator2 = hashSet.GetEnumerator())
			{
				while (enumerator2.MoveNext())
				{
					int pbDataId = enumerator2.Current;
					if (list.Find((MovableFloorController controller) => controller.Entity.EntityPbDataId == pbDataId) == null)
					{
						Log instance = Singleton<Log>.Instance;
						ELogModule module = ELogModule.WuWaGo;
						ELogAuthor author = ELogAuthor.YSQ;
						string message = "移动板批量执行找不到目标Controller";
						ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("pbDataId", pbDataId);
						instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					}
				}
			}
			return list;
		}

		// Token: 0x06032266 RID: 205414 RVA: 0x00C8CEA8 File Offset: 0x00C8B0A8
		private UniTask AddRolePetrifyEffect()
		{
			WuWaGoGameModeBase.<AddRolePetrifyEffect>d__99 <AddRolePetrifyEffect>d__;
			<AddRolePetrifyEffect>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<AddRolePetrifyEffect>d__.<>4__this = this;
			<AddRolePetrifyEffect>d__.<>1__state = -1;
			<AddRolePetrifyEffect>d__.<>t__builder.Start<WuWaGoGameModeBase.<AddRolePetrifyEffect>d__99>(ref <AddRolePetrifyEffect>d__);
			return <AddRolePetrifyEffect>d__.<>t__builder.Task;
		}

		// Token: 0x06032267 RID: 205415 RVA: 0x00C8CEEC File Offset: 0x00C8B0EC
		public UniTask WaitPlayIntroAsync()
		{
			WuWaGoGameModeBase.<WaitPlayIntroAsync>d__100 <WaitPlayIntroAsync>d__;
			<WaitPlayIntroAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<WaitPlayIntroAsync>d__.<>4__this = this;
			<WaitPlayIntroAsync>d__.<>1__state = -1;
			<WaitPlayIntroAsync>d__.<>t__builder.Start<WuWaGoGameModeBase.<WaitPlayIntroAsync>d__100>(ref <WaitPlayIntroAsync>d__);
			return <WaitPlayIntroAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06032268 RID: 205416 RVA: 0x00C8CF30 File Offset: 0x00C8B130
		public void OnEnterIntro()
		{
			foreach (KeyValuePair<int, WuWaGoRoleController> keyValuePair in this.AllRoleControllers)
			{
				int num;
				WuWaGoRoleController wuWaGoRoleController;
				keyValuePair.Deconstruct(out num, out wuWaGoRoleController);
				wuWaGoRoleController.OnPlayIntroBegin();
			}
		}

		// Token: 0x06032269 RID: 205417 RVA: 0x00C8CF90 File Offset: 0x00C8B190
		public void OnEnterRunning()
		{
			foreach (KeyValuePair<int, WuWaGoRoleController> keyValuePair in this.AllRoleControllers)
			{
				int num;
				WuWaGoRoleController wuWaGoRoleController;
				keyValuePair.Deconstruct(out num, out wuWaGoRoleController);
				wuWaGoRoleController.OnEnterRunning();
			}
		}

		// Token: 0x0401D4D2 RID: 120018
		private const string WUWAGO = "WuWaGo";

		// Token: 0x0401D4D3 RID: 120019
		private const int DISABLE_ENTITY_WAIT_TIMEOUT_MS = 5000;

		// Token: 0x0401D4D4 RID: 120020
		protected readonly RoundManager RoundManager = new RoundManager();

		// Token: 0x0401D4D5 RID: 120021
		private RollbackManager RollbackManager;

		// Token: 0x0401D4D6 RID: 120022
		protected WuWaGoGameData GameData;

		// Token: 0x0401D4D7 RID: 120023
		private WuWaGoGridMutationService GridMutationService;

		// Token: 0x0401D4D8 RID: 120024
		private IGameplayEntityLinkService GameplayEntityLinkServiceInner;

		// Token: 0x0401D4D9 RID: 120025
		private readonly Dictionary<int, WuWaGoRoleController> AllRoleControllers = new Dictionary<int, WuWaGoRoleController>();

		// Token: 0x0401D4DA RID: 120026
		private readonly HashSet<WuWaGoRoleController> DeactivatedDeadRoleControllers = new HashSet<WuWaGoRoleController>();

		// Token: 0x0401D4DB RID: 120027
		private readonly Dictionary<int, GameplayEntityControllerBase> AllEntityControllers = new Dictionary<int, GameplayEntityControllerBase>();

		// Token: 0x0401D4DC RID: 120028
		private readonly Dictionary<int, WuWaGoGridController> AllGridControllers = new Dictionary<int, WuWaGoGridController>();

		// Token: 0x0401D4DD RID: 120029
		private readonly HashSet<IExecutableUnit> TickListeners = new HashSet<IExecutableUnit>();

		// Token: 0x0401D4DE RID: 120030
		private bool LastEmittedPlayTipAvailable;

		// Token: 0x0401D4DF RID: 120031
		[Nullable(2)]
		private WuWaGoTraversalGridEntity CurrentHintSource;

		// Token: 0x0401D4E0 RID: 120032
		private bool CinematicPlaying;

		// Token: 0x0401D4E1 RID: 120033
		private bool InterruptCinematicRequested;

		// Token: 0x0401D4E2 RID: 120034
		[Nullable(2)]
		private WorldEntity DisabledEntity;

		// Token: 0x0401D4E3 RID: 120035
		private int DisableId;

		// Token: 0x0401D4E4 RID: 120036
		[Nullable(2)]
		private CustomPromise<UniTaskVoid> DeathPopupClosedPromise;

		// Token: 0x0401D4E5 RID: 120037
		private bool DeathSequenceActiveInner;

		// Token: 0x0401D4E6 RID: 120038
		private readonly Dictionary<string, int> ActiveDamageBatchReasons = new Dictionary<string, int>();

		// Token: 0x0401D4E7 RID: 120039
		private int? PendingMainRoleDeadId;
	}
}
