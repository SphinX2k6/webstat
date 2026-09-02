using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.NewWorld.Vehicle.Common
{
	// Token: 0x020047D6 RID: 18390
	[NullableContext(1)]
	[Nullable(0)]
	public class VehicleLockOnComponent : BaseLockOnComponent
	{
		// Token: 0x170081DE RID: 33246
		// (get) Token: 0x0602FB3A RID: 195386 RVA: 0x00B69F41 File Offset: 0x00B68141
		public new static Type[] Dependencies
		{
			get
			{
				return new Type[]
				{
					typeof(VehicleActorComponent)
				};
			}
		}

		// Token: 0x0602FB3B RID: 195387 RVA: 0x00B69F58 File Offset: 0x00B68158
		protected override bool OnStart()
		{
			base.OnStart();
			this.IsLookAt = false;
			this.ActorComp = base.Entity.GetComponent<VehicleActorComponent>();
			this.CreatureComp = base.Entity.GetComponent<CreatureDataComponent>();
			this.InputComp = base.Entity.GetComponent<VehicleInputComponent>();
			this.MoveComp = base.Entity.GetComponent<VehicleMoveComponent>();
			base.SetLockOnConfig(6, 0);
			return true;
		}

		// Token: 0x0602FB3C RID: 195388 RVA: 0x00B69FC0 File Offset: 0x00B681C0
		protected override void OnTick(float delta)
		{
			this.TickMoveDir();
			this.TickCurrentInfo();
			base.Check(delta);
			base.OnTick(delta);
		}

		// Token: 0x0602FB3D RID: 195389 RVA: 0x00B69FDC File Offset: 0x00B681DC
		private void TickCurrentInfo()
		{
			if (base.IsHardLock || this.IsLookAt)
			{
				return;
			}
			LockOnInfo getCurrentInfo = base.GetCurrentInfo;
			bool flag;
			if (getCurrentInfo == null)
			{
				flag = false;
			}
			else
			{
				EntityHandle entityHandle = getCurrentInfo.EntityHandle;
				flag = ((entityHandle != null) ? new bool?(entityHandle.Valid) : null).GetValueOrDefault();
			}
			if (flag && this.CurSoftLockConfig != null && (base.IsEntityContainsDisableSoftLockTag(base.GetCurrentInfo.EntityHandle) || base.CannotBeDetected(this.CurSoftLockConfig.Value, base.GetCurrentInfo.EntityHandle, base.GetCurrentInfo.EntityHandle.Entity.GetComponent<BaseActorComponent>().ActorLocationProxy)))
			{
				base.SetCurrentInfo(null);
				this.SetShowTarget(null, "", false);
			}
		}

		// Token: 0x0602FB3E RID: 195390 RVA: 0x00B6A09C File Offset: 0x00B6829C
		private void TickMoveDir()
		{
			if (!this.InputComp)
			{
				return;
			}
			Vector moveDirectionCache = this.InputComp.GetMoveDirectionCache();
			if (this.InputComp.GetCameraInput().Item1 != 0f || !this.MoveDirCache.Equals(moveDirectionCache, 1E-08))
			{
				this.MoveDirCache.Set(moveDirectionCache.X, moveDirectionCache.Y, 0.0);
				this.InputDirect.DeepCopy(this.ActorComp.InputDirectProxy);
				Vector moveDirCache = this.MoveDirCache;
				if (moveDirCache == null || !moveDirCache.IsNearlyZero(1E-08))
				{
					this.HasChangeInput = true;
					return;
				}
			}
			if (this.SpeedUpCleanTarget())
			{
				this.HasChangeInput = true;
			}
		}

		// Token: 0x0602FB3F RID: 195391 RVA: 0x00B6A160 File Offset: 0x00B68360
		public bool SpeedUpCleanTarget()
		{
			VehicleMoveComponent moveComp = this.MoveComp;
			return moveComp != null && moveComp.Valid && this.MoveComp.Speed > 420f && !this.TagComponent.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.技能中"]);
		}

		// Token: 0x0602FB40 RID: 195392 RVA: 0x00B6A1B4 File Offset: 0x00B683B4
		protected override int GetSelfCamp()
		{
			if (this.ActorComp.Owner is TsBaseVehicle)
			{
				BaseVehiclePerformComponent component = base.Entity.GetComponent<BaseVehiclePerformComponent>();
				if (((component != null) ? component.Driver : null) != null)
				{
					BaseActorComponent component2 = component.Driver.GetComponent<BaseActorComponent>();
					TsBaseCharacter tsBaseCharacter = ((component2 != null) ? component2.Owner : null) as TsBaseCharacter;
					if (tsBaseCharacter != null)
					{
						return (int)tsBaseCharacter.Camp;
					}
				}
			}
			return -1;
		}

		// Token: 0x0602FB41 RID: 195393 RVA: 0x00B6A218 File Offset: 0x00B68418
		[NullableContext(2)]
		protected override void SetAndShowTarget(LockOnInfo bestInfo, bool showTarget)
		{
			base.SetCurrentInfo(bestInfo);
			if (bestInfo != null)
			{
				EntityHandle entityHandle = bestInfo.EntityHandle;
				if (((entityHandle != null) ? new bool?(entityHandle.Valid) : null).GetValueOrDefault())
				{
					LockOnDebug.SetDebugArrow(bestInfo, EColorType.Green);
				}
			}
			if (showTarget)
			{
				this.SetShowTargetBySkill(base.GetCurrentTarget(), base.GetCurrentTargetSocketName());
			}
		}

		// Token: 0x0602FB42 RID: 195394 RVA: 0x00B6A278 File Offset: 0x00B68478
		private bool SetShowTargetBySkill([Nullable(2)] EntityHandle target, string socketName = "")
		{
			if (base.IsHardLock)
			{
				return false;
			}
			if (target == null || !target.Valid || !target.Entity.Active)
			{
				return this.SetShowTarget(null, "", false);
			}
			return this.SetShowTarget(target, socketName, false);
		}

		// Token: 0x0602FB43 RID: 195395 RVA: 0x00B6A2C4 File Offset: 0x00B684C4
		public override bool SetShowTarget([Nullable(2)] EntityHandle target, string socketName = "", bool isHardLock = false)
		{
			if (base.ShowTarget == target && base.ShowTargetSocket == socketName)
			{
				return true;
			}
			this.ShowTargetSetTime = Singleton<Time>.Instance.WorldTime;
			this.ShowTargetInternal = target;
			this.ShowTargetSocketInternal = socketName;
			return true;
		}

		// Token: 0x0602FB44 RID: 195396 RVA: 0x00B6A300 File Offset: 0x00B68500
		public override bool ClearComponent(EntityComponent componentTemplate)
		{
			if (!base.ClearComponent(componentTemplate))
			{
				return false;
			}
			VehicleLockOnComponent vehicleLockOnComponent = (VehicleLockOnComponent)componentTemplate;
			if (base.CanResetComponentProperty("StatTickMoveDir") && vehicleLockOnComponent.StatTickMoveDir != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Stat>(this.StatTickMoveDir), "StatTickMoveDir"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("StatTickCurrentInfo") && vehicleLockOnComponent.StatTickCurrentInfo != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Stat>(this.StatTickCurrentInfo), "StatTickCurrentInfo"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("StatCheck") && vehicleLockOnComponent.StatCheck != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Stat>(this.StatCheck), "StatCheck"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("ActorComp"))
			{
				if (vehicleLockOnComponent.ActorComp == null)
				{
					this.ActorComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<VehicleActorComponent>(this.ActorComp), "ActorComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("InputComp"))
			{
				if (vehicleLockOnComponent.InputComp == null)
				{
					this.InputComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<VehicleInputComponent>(this.InputComp), "InputComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("MoveComp"))
			{
				if (vehicleLockOnComponent.MoveComp == null)
				{
					this.MoveComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<VehicleMoveComponent>(this.MoveComp), "MoveComp"))
				{
					return false;
				}
			}
			return !base.CanResetComponentProperty("MoveDirCache") || vehicleLockOnComponent.MoveDirCache == null || base.CheckClearObject(EntityComponentSystem.ClearObject<Vector>(this.MoveDirCache), "MoveDirCache");
		}

		// Token: 0x0401B545 RID: 111941
		private const int VEHICLE_SKILLTARGET_LOCKON_ID = 6;

		// Token: 0x0401B546 RID: 111942
		private const float VEHICLE_CLEAN_TARGET_SPEED_THRESHOLD = 420f;

		// Token: 0x0401B547 RID: 111943
		[StaticVariableRuleIgnore]
		private readonly Stat StatTickMoveDir = Stat.Create("VehicleLockOnComponent.StatTickMoveDir", "", "");

		// Token: 0x0401B548 RID: 111944
		[StaticVariableRuleIgnore]
		private readonly Stat StatTickCurrentInfo = Stat.Create("VehicleLockOnComponent.StatTickCurrentInfo", "", "");

		// Token: 0x0401B549 RID: 111945
		[StaticVariableRuleIgnore]
		private readonly Stat StatCheck = Stat.Create("VehicleLockOnComponent.StatCheck", "", "");

		// Token: 0x0401B54A RID: 111946
		[Nullable(2)]
		private VehicleActorComponent ActorComp;

		// Token: 0x0401B54B RID: 111947
		[Nullable(2)]
		private VehicleInputComponent InputComp;

		// Token: 0x0401B54C RID: 111948
		[Nullable(2)]
		private VehicleMoveComponent MoveComp;

		// Token: 0x0401B54D RID: 111949
		private readonly Vector MoveDirCache = Vector.Create();
	}
}
