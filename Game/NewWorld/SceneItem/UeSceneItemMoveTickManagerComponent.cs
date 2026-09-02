using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.SceneItem
{
	// Token: 0x02004817 RID: 18455
	[NullableContext(1)]
	[Nullable(0)]
	public class UeSceneItemMoveTickManagerComponent : EntityComponent
	{
		// Token: 0x0603007A RID: 196730 RVA: 0x00BA343C File Offset: 0x00BA163C
		protected override bool OnStart()
		{
			this.ActorComp = base.Entity.GetComponent<SceneItemActorComponent>();
			if (base.Entity.GameBudgetConfig.GroupName == FNameUtil.GetDynamicFName("MoveSceneItemEntity"))
			{
				this.NeedTickOutside = true;
			}
			this.MoveComponent = (this.ActorComp.Owner.GetComponentByClass(UKuroSceneItemMoveComponent.StaticClass()) as UKuroSceneItemMoveComponent);
			UKuroSceneItemMoveComponent moveComponent = this.MoveComponent;
			if (moveComponent == null || !moveComponent.IsValid())
			{
				AActor owner = this.ActorComp.Owner;
				TSubclassOf<UActorComponent> @class = UKuroSceneItemMoveComponent.StaticClass();
				bool bManualAttachment = false;
				FTransform ftransform = new FTransform();
				this.MoveComponent = (owner.AddComponentByClass(@class, bManualAttachment, ftransform, false, default(FName)) as UKuroSceneItemMoveComponent);
				UKuroSceneItemMoveComponent moveComponent2 = this.MoveComponent;
				FVectorDouble fvectorDouble = this.ActorComp.ActorGravityDirectProxy.ToUeVector(false);
				moveComponent2.Kuro_SetGravityDirect(fvectorDouble);
				this.MoveComponent.SetTickingMoveEnable(false);
				if (this.NeedTickOutside)
				{
					this.MoveComponent.SetKuroOnlyTickOutside(true);
				}
			}
			Singleton<EventSystem>.Instance.AddWithTarget<Entity, bool>(base.Entity, EEventName.OnChangeBasedPlatform, new Action<Entity, bool>(this.OnChangeBasedMovementActor));
			return true;
		}

		// Token: 0x0603007B RID: 196731 RVA: 0x00BA3573 File Offset: 0x00BA1773
		protected override bool OnEnd()
		{
			Singleton<EventSystem>.Instance.RemoveWithTarget<Entity, bool>(base.Entity, EEventName.OnChangeBasedPlatform, new Action<Entity, bool>(this.OnChangeBasedMovementActor));
			return true;
		}

		// Token: 0x0603007C RID: 196732 RVA: 0x00BA3598 File Offset: 0x00BA1798
		private void OnChangeBasedMovementActor(Entity entity, bool isEnter)
		{
			if (isEnter)
			{
				this.StandOnEntity.Add(entity);
				return;
			}
			CharacterDriveVehicleComponent component = entity.GetComponent<CharacterDriveVehicleComponent>();
			if (((component != null) ? component.VehicleEntity : null) != base.Entity)
			{
				this.StandOnEntity.Remove(entity);
			}
		}

		// Token: 0x0603007D RID: 196733 RVA: 0x00BA35D4 File Offset: 0x00BA17D4
		public void TickMovement(float delta, bool bForceTick = false)
		{
			if (bForceTick || (this.NeedTickOutside && this.LastTickTime < Singleton<Time>.Instance.Frame))
			{
				UKuroSceneItemMoveComponent moveComponent = this.MoveComponent;
				if (moveComponent != null && moveComponent.IsValid())
				{
					UKuroSceneItemMoveComponent moveComponent2 = this.MoveComponent;
					if (moveComponent2 != null)
					{
						moveComponent2.KuroTickComponentOutside(delta * 0.001f);
					}
					SceneItemActorComponent actorComp = this.ActorComp;
					if (actorComp != null)
					{
						actorComp.ResetAllCachedTime();
					}
					foreach (Entity entity in this.StandOnEntity)
					{
						BaseActorComponent component = entity.GetComponent<BaseActorComponent>();
						if (component != null)
						{
							component.ResetAllCachedTime();
						}
					}
					this.LastTickTime = Singleton<Time>.Instance.Frame;
				}
			}
		}

		// Token: 0x0603007E RID: 196734 RVA: 0x00BA36A0 File Offset: 0x00BA18A0
		public override bool ClearComponent(EntityComponent componentTemplate)
		{
			if (!base.ClearComponent(componentTemplate))
			{
				return false;
			}
			UeSceneItemMoveTickManagerComponent ueSceneItemMoveTickManagerComponent = (UeSceneItemMoveTickManagerComponent)componentTemplate;
			if (base.CanResetComponentProperty("ActorComp"))
			{
				if (ueSceneItemMoveTickManagerComponent.ActorComp == null)
				{
					this.ActorComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<SceneItemActorComponent>(this.ActorComp), "ActorComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("MoveComponent"))
			{
				if (ueSceneItemMoveTickManagerComponent.MoveComponent == null)
				{
					this.MoveComponent = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<UKuroSceneItemMoveComponent>(this.MoveComponent), "MoveComponent"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("StandOnEntity") && ueSceneItemMoveTickManagerComponent.StandOnEntity != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Entity>(this.StandOnEntity), "StandOnEntity"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("LastTickTime"))
			{
				this.LastTickTime = ueSceneItemMoveTickManagerComponent.LastTickTime;
			}
			if (base.CanResetComponentProperty("NeedTickOutside"))
			{
				this.NeedTickOutside = ueSceneItemMoveTickManagerComponent.NeedTickOutside;
			}
			return true;
		}

		// Token: 0x0401B942 RID: 112962
		[Nullable(2)]
		private SceneItemActorComponent ActorComp;

		// Token: 0x0401B943 RID: 112963
		[Nullable(2)]
		private UKuroSceneItemMoveComponent MoveComponent;

		// Token: 0x0401B944 RID: 112964
		private readonly HashSet<Entity> StandOnEntity = new HashSet<Entity>();

		// Token: 0x0401B945 RID: 112965
		private int LastTickTime = -1;

		// Token: 0x0401B946 RID: 112966
		private bool NeedTickOutside;
	}
}
