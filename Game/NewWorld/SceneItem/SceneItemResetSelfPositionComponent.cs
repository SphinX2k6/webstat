using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Aki.TDConfigMgr.Component;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.LevelGamePlay;
using CSharpScript.Game.NewWorld.SceneItem.Manipulate;

namespace CSharpScript.Game.NewWorld.SceneItem
{
	// Token: 0x0200480D RID: 18445
	[NullableContext(2)]
	[Nullable(0)]
	public class SceneItemResetSelfPositionComponent : EntityComponent
	{
		// Token: 0x0602FFD5 RID: 196565 RVA: 0x00B9C0D0 File Offset: 0x00B9A2D0
		protected override bool OnInitData(IEntityArgs args = null)
		{
			ResetSelfPosComponent config = args.GetP1<CreateEntityData>().GetParam<SceneItemResetSelfPositionComponent>() as ResetSelfPosComponent;
			this.Config = config;
			float resetRadius = this.Config.ResetRadius;
			this.ResetRadiusSquared = (double)(this.Config.ResetRadius * this.Config.ResetRadius);
			this.CheckInterval = 500f;
			return true;
		}

		// Token: 0x0602FFD6 RID: 196566 RVA: 0x00B9C12C File Offset: 0x00B9A32C
		protected override bool OnStart()
		{
			this.ActorComp = base.Entity.CheckGetComponent<SceneItemActorComponent>();
			this.MoveSyncComp = base.Entity.CheckGetComponent<SceneItemMovementSyncComponent>();
			if (base.Entity.CheckGetComponent<SceneItemManipulatableComponent>() == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.SceneItem;
				ELogAuthor author = ELogAuthor.ZYL;
				string message = "[SceneItemResetSelfPositionComponent] OnStart失败，实体不是可被控物";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("PbDataID", this.ActorComp.CreatureData.GetPbDataId());
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return false;
			}
			this.DisableTickChecking("[SceneItemResetSelfPositionComponent] 初始关闭检查距离Tick");
			Singleton<EventSystem>.Instance.AddWithTarget<SceneItemManipulatableComponent.EManipulatableState, SceneItemManipulatableComponent.EManipulatableState, Entity, SceneItemManipulableBaseState, SceneItemManipulableBaseState>(base.Entity, EEventName.OnManipulatableItemStateModified, new Action<SceneItemManipulatableComponent.EManipulatableState, SceneItemManipulatableComponent.EManipulatableState, Entity, SceneItemManipulableBaseState, SceneItemManipulableBaseState>(this.OnManipulatableItemStateModified));
			return true;
		}

		// Token: 0x0602FFD7 RID: 196567 RVA: 0x00B9C1D3 File Offset: 0x00B9A3D3
		protected override void OnActivate()
		{
			if (this.ResetRadiusSquared != -1.0)
			{
				this.TickHandle = TimerSystem.Instance.Forever(delegate(float _)
				{
					this.CheckAndResetSelfPos();
				}, this.CheckInterval, 1f, null, null, true);
			}
		}

		// Token: 0x0602FFD8 RID: 196568 RVA: 0x00B9C210 File Offset: 0x00B9A410
		protected override bool OnEnd()
		{
			if (Singleton<EventSystem>.Instance.HasWithTarget<SceneItemManipulatableComponent.EManipulatableState, SceneItemManipulatableComponent.EManipulatableState, Entity, SceneItemManipulableBaseState, SceneItemManipulableBaseState>(base.Entity, EEventName.OnManipulatableItemStateModified, new Action<SceneItemManipulatableComponent.EManipulatableState, SceneItemManipulatableComponent.EManipulatableState, Entity, SceneItemManipulableBaseState, SceneItemManipulableBaseState>(this.OnManipulatableItemStateModified)))
			{
				Singleton<EventSystem>.Instance.RemoveWithTarget<SceneItemManipulatableComponent.EManipulatableState, SceneItemManipulatableComponent.EManipulatableState, Entity, SceneItemManipulableBaseState, SceneItemManipulableBaseState>(base.Entity, EEventName.OnManipulatableItemStateModified, new Action<SceneItemManipulatableComponent.EManipulatableState, SceneItemManipulatableComponent.EManipulatableState, Entity, SceneItemManipulableBaseState, SceneItemManipulableBaseState>(this.OnManipulatableItemStateModified));
			}
			if (this.TickHandle != null)
			{
				TimerSystem.Instance.Remove(this.TickHandle);
				this.TickHandle = null;
			}
			return true;
		}

		// Token: 0x0602FFD9 RID: 196569 RVA: 0x00B9C284 File Offset: 0x00B9A484
		private void OnManipulatableItemStateModified(SceneItemManipulatableComponent.EManipulatableState oldStateEnum, SceneItemManipulatableComponent.EManipulatableState newStateEnum, [Nullable(1)] Entity entity, SceneItemManipulableBaseState oldState, SceneItemManipulableBaseState newState)
		{
			SceneItemMovementSyncComponent moveSyncComp = this.MoveSyncComp;
			if (moveSyncComp == null || !moveSyncComp.HasMoveAuthority())
			{
				return;
			}
			if ((this.IsCastState(oldStateEnum) || oldStateEnum == SceneItemManipulatableComponent.EManipulatableState.BeDropping) && !this.IsStopCheckOnCast)
			{
				this.DisableTickChecking("[SceneItemResetSelfPositionComponent] 结束被当前主控移动，停止检查距离Tick");
				if (this.ResetRadiusSquared != -1.0)
				{
					this.CheckAndResetSelfPos();
				}
			}
			if (newStateEnum == SceneItemManipulatableComponent.EManipulatableState.BeDrawing)
			{
				this.EnableTickChecking();
			}
			ResetSelfPosComponent config = this.Config;
			if (config != null && config.IsDisableResetPosAfterThrow.GetValueOrDefault() && this.IsCastState(newStateEnum))
			{
				this.DisableTickChecking("[SceneItemResetSelfPositionComponent] 被控物配置丢出时停止检测");
				this.IsStopCheckOnCast = true;
			}
			ResetSelfPosComponent config2 = this.Config;
			if (config2 != null && config2.IsResetPosAfterThrow.GetValueOrDefault() && newStateEnum == SceneItemManipulatableComponent.EManipulatableState.BeDropping)
			{
				if (this.TimerHandle != null)
				{
					TimerSystem.Instance.Remove(this.TimerHandle);
					this.TimerHandle = null;
				}
				this.TimerHandle = TimerSystem.Instance.Delay(delegate(float _)
				{
					this.TimerHandle = null;
					this.ResetSelfPos("ResetPositionTip2");
				}, 0.35f * (float)Singleton<TimeUtil>.Instance.InverseMillisecond, null, null, true, 1f);
			}
			ResetSelfPosComponent config3 = this.Config;
			float? num = (config3 != null) ? config3.ResetPosDelayTime : null;
			if (num != null && num.GetValueOrDefault() != 0f && (oldState == null || !oldState.IsNoLockCasting()) && newState != null && newState.IsNoLockCasting())
			{
				if (this.TimerHandle != null)
				{
					TimerSystem.Instance.Remove(this.TimerHandle);
					this.TimerHandle = null;
				}
				this.TimerHandle = TimerSystem.Instance.Delay(delegate(float _)
				{
					this.TimerHandle = null;
					this.ResetSelfPos(null);
				}, this.Config.ResetPosDelayTime.Value * (float)Singleton<TimeUtil>.Instance.InverseMillisecond, null, null, true, 1f);
			}
			if (newStateEnum == SceneItemManipulatableComponent.EManipulatableState.BeAdsorbed && this.TimerHandle != null)
			{
				TimerSystem.Instance.Remove(this.TimerHandle);
				this.TimerHandle = null;
			}
		}

		// Token: 0x0602FFDA RID: 196570 RVA: 0x00B9C478 File Offset: 0x00B9A678
		private void EnableTickChecking()
		{
			if (!this.GetTickCheckingEnabled())
			{
				TimerHandle tickHandle = this.TickHandle;
				if (tickHandle == null)
				{
					return;
				}
				tickHandle.Resume();
			}
		}

		// Token: 0x0602FFDB RID: 196571 RVA: 0x00B9C493 File Offset: 0x00B9A693
		[NullableContext(1)]
		private void DisableTickChecking(string reason)
		{
			if (this.GetTickCheckingEnabled())
			{
				TimerHandle tickHandle = this.TickHandle;
				if (tickHandle == null)
				{
					return;
				}
				tickHandle.Pause();
			}
		}

		// Token: 0x0602FFDC RID: 196572 RVA: 0x00B9C4AE File Offset: 0x00B9A6AE
		private bool GetTickCheckingEnabled()
		{
			TimerHandle tickHandle = this.TickHandle;
			return tickHandle == null || !tickHandle.IsPause();
		}

		// Token: 0x0602FFDD RID: 196573 RVA: 0x00B9C4C8 File Offset: 0x00B9A6C8
		private void CheckAndResetSelfPos()
		{
			bool selfPosInRangeCache = this.SelfPosInRangeCache;
			if (!this.CheckSelfPosInRange() && selfPosInRangeCache)
			{
				this.ResetSelfPos(null);
			}
		}

		// Token: 0x0602FFDE RID: 196574 RVA: 0x00B9C4F0 File Offset: 0x00B9A6F0
		private bool CheckSelfPosInRange()
		{
			global::Vector actorLocationProxy = this.ActorComp.ActorLocationProxy;
			if (actorLocationProxy == this.ActorLocationCache)
			{
				return this.SelfPosInRangeCache;
			}
			this.ActorLocationCache = global::Vector.Create(actorLocationProxy);
			Aki.Protocol.Vector initLocation = this.ActorComp.CreatureData.GetInitLocation();
			if (initLocation == null)
			{
				return this.SelfPosInRangeCache;
			}
			global::Vector v = global::Vector.Create(initLocation);
			this.SelfPosInRangeCache = (global::Vector.DistSquared(v, actorLocationProxy) <= this.ResetRadiusSquared);
			return this.SelfPosInRangeCache;
		}

		// Token: 0x0602FFDF RID: 196575 RVA: 0x00B9C565 File Offset: 0x00B9A765
		private void ResetSelfPos(string promptId)
		{
			ControllerBase<LevelGamePlayController>.Instance.OnManipulatableItemExitAreaInternal(base.Entity, promptId, 0L);
		}

		// Token: 0x0602FFE0 RID: 196576 RVA: 0x00B9C57A File Offset: 0x00B9A77A
		private bool IsCastState(SceneItemManipulatableComponent.EManipulatableState state)
		{
			return state == SceneItemManipulatableComponent.EManipulatableState.BeCastingToTarget || state == SceneItemManipulatableComponent.EManipulatableState.BeCastingToOutlet || state == SceneItemManipulatableComponent.EManipulatableState.BeCastingFree || state == SceneItemManipulatableComponent.EManipulatableState.BeCastingProjectile;
		}

		// Token: 0x0602FFE1 RID: 196577 RVA: 0x00B9C58F File Offset: 0x00B9A78F
		public void StopTimerOnResetPos()
		{
			if (this.TimerHandle != null)
			{
				TimerSystem.Instance.Remove(this.TimerHandle);
				this.TimerHandle = null;
			}
		}

		// Token: 0x0602FFE2 RID: 196578 RVA: 0x00B9C5B4 File Offset: 0x00B9A7B4
		[NullableContext(1)]
		public override bool ClearComponent(EntityComponent componentTemplate)
		{
			if (!base.ClearComponent(componentTemplate))
			{
				return false;
			}
			SceneItemResetSelfPositionComponent sceneItemResetSelfPositionComponent = (SceneItemResetSelfPositionComponent)componentTemplate;
			if (base.CanResetComponentProperty("Config"))
			{
				if (sceneItemResetSelfPositionComponent.Config == null)
				{
					this.Config = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<ResetSelfPosComponent>(this.Config), "Config"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("ActorComp"))
			{
				if (sceneItemResetSelfPositionComponent.ActorComp == null)
				{
					this.ActorComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<SceneItemActorComponent>(this.ActorComp), "ActorComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("MoveSyncComp"))
			{
				if (sceneItemResetSelfPositionComponent.MoveSyncComp == null)
				{
					this.MoveSyncComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<SceneItemMovementSyncComponent>(this.MoveSyncComp), "MoveSyncComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("ResetRadiusSquared"))
			{
				this.ResetRadiusSquared = sceneItemResetSelfPositionComponent.ResetRadiusSquared;
			}
			if (base.CanResetComponentProperty("CheckInterval"))
			{
				this.CheckInterval = sceneItemResetSelfPositionComponent.CheckInterval;
			}
			if (base.CanResetComponentProperty("SelfPosInRangeCache"))
			{
				this.SelfPosInRangeCache = sceneItemResetSelfPositionComponent.SelfPosInRangeCache;
			}
			if (base.CanResetComponentProperty("ActorLocationCache"))
			{
				if (sceneItemResetSelfPositionComponent.ActorLocationCache == null)
				{
					this.ActorLocationCache = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<global::Vector>(this.ActorLocationCache), "ActorLocationCache"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("IsStopCheckOnCast"))
			{
				this.IsStopCheckOnCast = sceneItemResetSelfPositionComponent.IsStopCheckOnCast;
			}
			if (base.CanResetComponentProperty("TimerHandle"))
			{
				if (sceneItemResetSelfPositionComponent.TimerHandle == null)
				{
					this.TimerHandle = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<TimerHandle>(this.TimerHandle), "TimerHandle"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("TickHandle"))
			{
				if (sceneItemResetSelfPositionComponent.TickHandle == null)
				{
					this.TickHandle = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<TimerHandle>(this.TickHandle), "TickHandle"))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x0401B8BB RID: 112827
		private const float TICK_CHECK_INTERVAL = 500f;

		// Token: 0x0401B8BC RID: 112828
		private const float FIX_DELAY = 0.35f;

		// Token: 0x0401B8BD RID: 112829
		private ResetSelfPosComponent Config;

		// Token: 0x0401B8BE RID: 112830
		private SceneItemActorComponent ActorComp;

		// Token: 0x0401B8BF RID: 112831
		private SceneItemMovementSyncComponent MoveSyncComp;

		// Token: 0x0401B8C0 RID: 112832
		private double ResetRadiusSquared = -1.0;

		// Token: 0x0401B8C1 RID: 112833
		private float CheckInterval;

		// Token: 0x0401B8C2 RID: 112834
		private bool SelfPosInRangeCache = true;

		// Token: 0x0401B8C3 RID: 112835
		private global::Vector ActorLocationCache;

		// Token: 0x0401B8C4 RID: 112836
		private bool IsStopCheckOnCast;

		// Token: 0x0401B8C5 RID: 112837
		private TimerHandle TimerHandle;

		// Token: 0x0401B8C6 RID: 112838
		private TimerHandle TickHandle;
	}
}
