using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.NewWorld.Character.Common.Component.Abilities.Follow;
using CSharpScript.Game.NewWorld.Character.Custom.Components;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.SceneItem
{
	// Token: 0x02004808 RID: 18440
	[NullableContext(2)]
	[Nullable(0)]
	public class SceneItemQuantumDoorComponent : EntityComponent
	{
		// Token: 0x0602FF65 RID: 196453 RVA: 0x00B97DFC File Offset: 0x00B95FFC
		protected override bool OnStart()
		{
			this.RangeComp = base.Entity.GetComponent<RangeComponent>();
			this.ActorComp = base.Entity.GetComponent<SceneItemActorComponent>();
			if (!this.RangeComp || !this.ActorComp)
			{
				Singleton<Log>.Instance.Error(ELogModule.SceneItem, ELogAuthor.FJH, "[QuantumDoorComp] 组件缺失", default(ReadOnlySpan<ValueTuple<string, object>>));
				return false;
			}
			this.PassableParamName = FNameUtil.GetDynamicFName("Passable");
			this.HitPositionParamName = FNameUtil.GetDynamicFName("HitPositionWS");
			this.DiffusionProgressParamName = FNameUtil.GetDynamicFName("DiffusionProgress");
			Singleton<EventSystem>.Instance.AddWithTarget<bool, AActor>(base.Entity, EEventName.OnActorInOutRangeLocal, new Action<bool, AActor>(this.OnActorOverlapCallback));
			return true;
		}

		// Token: 0x0602FF66 RID: 196454 RVA: 0x00B97EB8 File Offset: 0x00B960B8
		protected override bool OnEnd()
		{
			if (Singleton<EventSystem>.Instance.HasWithTarget<bool, AActor>(base.Entity, EEventName.OnActorInOutRangeLocal, new Action<bool, AActor>(this.OnActorOverlapCallback)))
			{
				Singleton<EventSystem>.Instance.RemoveWithTarget<bool, AActor>(base.Entity, EEventName.OnActorInOutRangeLocal, new Action<bool, AActor>(this.OnActorOverlapCallback));
			}
			if (this.CollisionActor != null)
			{
				this.CollisionActor.OnActorHit.Clear();
				this.CollisionActor = null;
			}
			if (this.ProgressTimer != null)
			{
				TimerSystem.Instance.Remove(this.ProgressTimer);
				this.ProgressTimer = null;
			}
			if (Singleton<EventSystem>.Instance.Has<bool>(EEventName.OnPlayerFollowerEnableChange, new Action<bool>(this.OnPlayerFollowerEnableChange)))
			{
				Singleton<EventSystem>.Instance.Remove<bool>(EEventName.OnPlayerFollowerEnableChange, new Action<bool>(this.OnPlayerFollowerEnableChange));
			}
			return true;
		}

		// Token: 0x0602FF67 RID: 196455 RVA: 0x00B97F84 File Offset: 0x00B96184
		[NullableContext(1)]
		private void OnActorOverlapCallback(bool isEnter, AActor actor)
		{
			if (actor == ControllerBase<RoleTriggerController>.Instance.GetMyRoleTrigger())
			{
				if (this.QuantumDoorStaticMeshComp == null)
				{
					this.GetStaticMeshComponent();
					if (this.QuantumDoorStaticMeshComp == null)
					{
						return;
					}
				}
				if (isEnter)
				{
					if (!Singleton<EventSystem>.Instance.Has<bool>(EEventName.OnPlayerFollowerEnableChange, new Action<bool>(this.OnPlayerFollowerEnableChange)))
					{
						Singleton<EventSystem>.Instance.Add<bool>(EEventName.OnPlayerFollowerEnableChange, new Action<bool>(this.OnPlayerFollowerEnableChange));
					}
					bool flag = this.CheckFollowShooterActive();
					this.QuantumDoorStaticMeshComp.SetScalarParameterValueOnMaterials(this.PassableParamName ?? FNameUtil.NONE, flag > false);
					return;
				}
				if (Singleton<EventSystem>.Instance.Has<bool>(EEventName.OnPlayerFollowerEnableChange, new Action<bool>(this.OnPlayerFollowerEnableChange)))
				{
					Singleton<EventSystem>.Instance.Remove<bool>(EEventName.OnPlayerFollowerEnableChange, new Action<bool>(this.OnPlayerFollowerEnableChange));
				}
				this.QuantumDoorStaticMeshComp.SetScalarParameterValueOnMaterials(this.PassableParamName ?? FNameUtil.NONE, 0f);
			}
		}

		// Token: 0x0602FF68 RID: 196456 RVA: 0x00B98094 File Offset: 0x00B96294
		private void OnActorHitCallback(AActor selfActor, AActor otherActor, FVector hitPos, [Nullable(1)] FHitResult hitResult)
		{
			if (otherActor == Global.BaseCharacter.CharacterActorComponent.Owner)
			{
				if (this.ProgressTimer != null)
				{
					return;
				}
				if (this.QuantumDoorStaticMeshComp == null)
				{
					this.GetStaticMeshComponent();
					if (this.QuantumDoorStaticMeshComp == null)
					{
						return;
					}
				}
				this.Progress = 0f;
				FVector parameterValue = Global.BaseCharacter.CharacterActorComponent.ActorLocation.ToVector();
				this.QuantumDoorStaticMeshComp.SetVectorParameterValueOnMaterials(this.HitPositionParamName ?? FNameUtil.NONE, parameterValue);
				Singleton<AudioSystem>.Instance.PostEvent("play_interact_space_station_role_dead", this.CollisionActor, null);
				this.ProgressTimer = TimerSystem.Instance.Forever(delegate(float delta)
				{
					if (this.Progress >= 1f)
					{
						TimerSystem.Instance.Remove(this.ProgressTimer);
						this.ProgressTimer = null;
						return;
					}
					this.Progress += delta / 1600f;
					this.Progress = Math.Min(this.Progress, 1f);
					this.QuantumDoorStaticMeshComp.SetScalarParameterValueOnMaterials(this.DiffusionProgressParamName ?? FNameUtil.NONE, this.Progress);
				}, 20f, 1f, null, null, true);
			}
		}

		// Token: 0x0602FF69 RID: 196457 RVA: 0x00B9816C File Offset: 0x00B9636C
		private void GetStaticMeshComponent()
		{
			if (this.CollisionActor == null || !this.CollisionActor.IsValid())
			{
				AActor mainCollisionActor = this.ActorComp.GetMainCollisionActor();
				if (mainCollisionActor != null)
				{
					this.CollisionActor = mainCollisionActor;
					this.CollisionActor.OnActorHit.Add(new Action<AActor, AActor, FVector, FHitResult>(this.OnActorHitCallback));
					if (this.QuantumDoorStaticMeshComp == null)
					{
						AActor collisionActor = this.CollisionActor;
						UStaticMeshComponent ustaticMeshComponent = ((collisionActor != null) ? collisionActor.GetComponentByClass(UStaticMeshComponent.StaticClass()) : null) as UStaticMeshComponent;
						if (ustaticMeshComponent != null)
						{
							this.QuantumDoorStaticMeshComp = ustaticMeshComponent;
							return;
						}
					}
				}
			}
			Singleton<Log>.Instance.Error(ELogModule.SceneItem, ELogAuthor.FJH, "[QuantumDoorComp] 静态网格体组件缺失", default(ReadOnlySpan<ValueTuple<string, object>>));
		}

		// Token: 0x0602FF6A RID: 196458 RVA: 0x00B98214 File Offset: 0x00B96414
		private void OnPlayerFollowerEnableChange(bool isEnable)
		{
			if (this.QuantumDoorStaticMeshComp == null)
			{
				this.GetStaticMeshComponent();
				if (this.QuantumDoorStaticMeshComp == null)
				{
					return;
				}
			}
			EntityHandle playerFollowShooter = FollowUtils.GetPlayerFollowShooter(ModelBase<CreatureModel>.Instance.GetPlayerId());
			if (!playerFollowShooter)
			{
				return;
			}
			WorldEntity entity = playerFollowShooter.Entity;
			bool flag;
			if (entity == null)
			{
				flag = false;
			}
			else
			{
				CreatureDataComponent component = entity.GetComponent<CreatureDataComponent>();
				flag = (((component != null) ? new int?(component.SummonCfgId) : null).GetValueOrDefault() == 24000039);
			}
			bool flag2 = flag;
			this.QuantumDoorStaticMeshComp.SetScalarParameterValueOnMaterials(this.PassableParamName ?? FNameUtil.NONE, (float)((flag2 && isEnable) ? 1 : 0));
		}

		// Token: 0x0602FF6B RID: 196459 RVA: 0x00B982C0 File Offset: 0x00B964C0
		private bool CheckFollowShooterActive()
		{
			IPlayerFollowerFollowShooterHandler playerFollowerFollowShooterHandler = FollowUtils.GetPlayerFollowHandler(ModelBase<CreatureModel>.Instance.GetPlayerId(), EPlayerFollowerHandlerType.FollowShooter) as IPlayerFollowerFollowShooterHandler;
			if (playerFollowerFollowShooterHandler != null && playerFollowerFollowShooterHandler.IsFollowShooterEnable())
			{
				EntityHandle followShooter = playerFollowerFollowShooterHandler.GetFollowShooter();
				object obj;
				if (followShooter == null)
				{
					obj = null;
				}
				else
				{
					WorldEntity entity = followShooter.Entity;
					obj = ((entity != null) ? entity.GetComponent<CreatureDataComponent>() : null);
				}
				object obj2 = obj;
				return obj2 != null && obj2.SummonCfgId == 24000039;
			}
			return false;
		}

		// Token: 0x0602FF6C RID: 196460 RVA: 0x00B98320 File Offset: 0x00B96520
		[NullableContext(1)]
		public override bool ClearComponent(EntityComponent componentTemplate)
		{
			if (!base.ClearComponent(componentTemplate))
			{
				return false;
			}
			SceneItemQuantumDoorComponent sceneItemQuantumDoorComponent = (SceneItemQuantumDoorComponent)componentTemplate;
			if (base.CanResetComponentProperty("RangeComp"))
			{
				if (sceneItemQuantumDoorComponent.RangeComp == null)
				{
					this.RangeComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<RangeComponent>(this.RangeComp), "RangeComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("ActorComp"))
			{
				if (sceneItemQuantumDoorComponent.ActorComp == null)
				{
					this.ActorComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<SceneItemActorComponent>(this.ActorComp), "ActorComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("CollisionActor"))
			{
				if (sceneItemQuantumDoorComponent.CollisionActor == null)
				{
					this.CollisionActor = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<AActor>(this.CollisionActor), "CollisionActor"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("QuantumDoorStaticMeshComp"))
			{
				if (sceneItemQuantumDoorComponent.QuantumDoorStaticMeshComp == null)
				{
					this.QuantumDoorStaticMeshComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<UStaticMeshComponent>(this.QuantumDoorStaticMeshComp), "QuantumDoorStaticMeshComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("ProgressTimer"))
			{
				if (sceneItemQuantumDoorComponent.ProgressTimer == null)
				{
					this.ProgressTimer = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<TimerHandle>(this.ProgressTimer), "ProgressTimer"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("Progress"))
			{
				this.Progress = sceneItemQuantumDoorComponent.Progress;
			}
			if (base.CanResetComponentProperty("PassableParamName"))
			{
				this.PassableParamName = sceneItemQuantumDoorComponent.PassableParamName;
			}
			if (base.CanResetComponentProperty("HitPositionParamName"))
			{
				this.HitPositionParamName = sceneItemQuantumDoorComponent.HitPositionParamName;
			}
			if (base.CanResetComponentProperty("DiffusionProgressParamName"))
			{
				this.DiffusionProgressParamName = sceneItemQuantumDoorComponent.DiffusionProgressParamName;
			}
			return true;
		}

		// Token: 0x0401B869 RID: 112745
		private const float HIT_CD = 1600f;

		// Token: 0x0401B86A RID: 112746
		private const int FOLLOW_SHOOTER_ID = 24000039;

		// Token: 0x0401B86B RID: 112747
		[Nullable(1)]
		private const string DOOR_HIT_AK_EVENT_NAME = "play_interact_space_station_role_dead";

		// Token: 0x0401B86C RID: 112748
		private RangeComponent RangeComp;

		// Token: 0x0401B86D RID: 112749
		private SceneItemActorComponent ActorComp;

		// Token: 0x0401B86E RID: 112750
		private AActor CollisionActor;

		// Token: 0x0401B86F RID: 112751
		private UStaticMeshComponent QuantumDoorStaticMeshComp;

		// Token: 0x0401B870 RID: 112752
		private TimerHandle ProgressTimer;

		// Token: 0x0401B871 RID: 112753
		private float Progress;

		// Token: 0x0401B872 RID: 112754
		private FName? PassableParamName;

		// Token: 0x0401B873 RID: 112755
		private FName? HitPositionParamName;

		// Token: 0x0401B874 RID: 112756
		private FName? DiffusionProgressParamName;
	}
}
