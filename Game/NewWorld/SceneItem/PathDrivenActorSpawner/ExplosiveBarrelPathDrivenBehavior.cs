using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.GamePlay.PathDrivenActor;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Effect;
using UnrealEngine;
using UnrealEngine.Extension;

namespace CSharpScript.Game.NewWorld.SceneItem.PathDrivenActorSpawner
{
	// Token: 0x02004832 RID: 18482
	[NullableContext(1)]
	[Nullable(0)]
	public class ExplosiveBarrelPathDrivenBehavior : IPathDrivenActorBehavior
	{
		// Token: 0x06030174 RID: 196980 RVA: 0x00BA9F8D File Offset: 0x00BA818D
		public ExplosiveBarrelPathDrivenBehavior(int? ownerPbDataId)
		{
			this.OwnerPbDataId = ownerPbDataId;
			this.ExplosiveBarrelHitEventTagId = GameplayTagDefine.EGameplayTagId["关卡.事件.无限爆炸桶.爆炸桶命中"];
		}

		// Token: 0x06030175 RID: 196981 RVA: 0x00BA9FC8 File Offset: 0x00BA81C8
		public unsafe bool Initialize(IPathDrivenActorRuntimeData runtimeData)
		{
			AActor actor = runtimeData.Actor;
			string text = (actor != null && actor.IsValid()) ? actor.GetClass().ToClass().GetName() : null;
			if (actor == null || !actor.IsValid() || text != "BP_ExplosiveBarrel_C")
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.PathDrivenActor;
				ELogAuthor author = ELogAuthor.WRY;
				string message = "[ExplosiveBarrelPathDrivenBehavior] Actor类型不是BP_ExplosiveBarrel_C";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("PbDataId", this.OwnerPbDataId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("ActorClass", text);
				instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return false;
			}
			this.RuntimeData = runtimeData;
			BP_ExplosiveBarrel_C bp_ExplosiveBarrel_C = actor as BP_ExplosiveBarrel_C;
			UStaticMeshComponent staticMesh = bp_ExplosiveBarrel_C.StaticMesh;
			float barrelRadius = bp_ExplosiveBarrel_C.BarrelRadius;
			if (staticMesh == null || !staticMesh.IsValid())
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.PathDrivenActor;
				ELogAuthor author2 = ELogAuthor.WRY;
				string message2 = "[ExplosiveBarrelPathDrivenBehavior] 爆炸桶缺少ExplosiveBarrel组件";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("PbDataId", this.OwnerPbDataId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("ActorClass", actor.GetClass().ToClass().GetName());
				instance2.Warn(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
				return false;
			}
			if (barrelRadius <= 0.01f)
			{
				Log instance3 = Singleton<Log>.Instance;
				ELogModule module3 = ELogModule.PathDrivenActor;
				ELogAuthor author3 = ELogAuthor.WRY;
				string message3 = "[ExplosiveBarrelPathDrivenBehavior] 爆炸桶BarrelRadius非法";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray3 = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 0) = new ValueTuple<string, object>("PbDataId", this.OwnerPbDataId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 1) = new ValueTuple<string, object>("ActorClass", actor.GetClass().ToClass().GetName());
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 2) = new ValueTuple<string, object>("BarrelRadius", barrelRadius);
				instance3.Warn(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray3, 3));
				return false;
			}
			this.BarrelRadius = barrelRadius;
			string text2 = bp_ExplosiveBarrel_C.ExplodeEffectAsset.ToAssetPathName();
			this.ExplodeEffectPath = ((!string.IsNullOrEmpty(text2) && text2 != "None") ? text2 : "");
			this.AudioEvent = (bp_ExplosiveBarrel_C.AudioEvent ?? "");
			this.StaticMeshComponent = staticMesh;
			this.LastSplineDistance = runtimeData.MoveComponent.GetDistanceAlongSpline();
			actor.OnActorBeginOverlap.Add(new Action<AActor, AActor>(this.HandleActorBeginOverlap));
			this.StartRollingAudio(actor);
			return true;
		}

		// Token: 0x06030176 RID: 196982 RVA: 0x00BAA23C File Offset: 0x00BA843C
		public void PrepareCollisionBeforeSpawn(IPathDrivenActorRuntimeData runtimeData)
		{
			UStaticMeshComponent staticMeshComponent = this.StaticMeshComponent;
			if (staticMeshComponent != null)
			{
				staticMeshComponent.SetGenerateOverlapEvents(false);
			}
			UStaticMeshComponent staticMeshComponent2 = this.StaticMeshComponent;
			if (staticMeshComponent2 == null)
			{
				return;
			}
			staticMeshComponent2.SetCollisionEnabled(ECollisionEnabled.NoCollision);
		}

		// Token: 0x06030177 RID: 196983 RVA: 0x00BAA264 File Offset: 0x00BA8464
		public void RestoreCollisionAfterSpawn(IPathDrivenActorRuntimeData runtimeData)
		{
			UStaticMeshComponent staticMeshComponent = this.StaticMeshComponent;
			if (staticMeshComponent == null || !staticMeshComponent.IsValid())
			{
				return;
			}
			staticMeshComponent.SetCollisionEnabled(ECollisionEnabled.QueryOnly);
			staticMeshComponent.SetGenerateOverlapEvents(true);
		}

		// Token: 0x06030178 RID: 196984 RVA: 0x00BAA298 File Offset: 0x00BA8498
		public void ClearCollisionBeforeRecycle(IPathDrivenActorRuntimeData runtimeData)
		{
			UStaticMeshComponent staticMeshComponent = this.StaticMeshComponent;
			if (staticMeshComponent != null)
			{
				staticMeshComponent.SetGenerateOverlapEvents(false);
			}
			UStaticMeshComponent staticMeshComponent2 = this.StaticMeshComponent;
			if (staticMeshComponent2 == null)
			{
				return;
			}
			staticMeshComponent2.SetCollisionEnabled(ECollisionEnabled.NoCollision);
		}

		// Token: 0x06030179 RID: 196985 RVA: 0x00BAA2C0 File Offset: 0x00BA84C0
		public void Tick(IPathDrivenActorRuntimeData runtimeData, float deltaSeconds)
		{
			if (!runtimeData.Finished)
			{
				UKuroSceneItemMoveComponent moveComponent = runtimeData.MoveComponent;
				if (moveComponent != null && moveComponent.IsValid())
				{
					UStaticMeshComponent staticMeshComponent = this.StaticMeshComponent;
					if (staticMeshComponent == null || !staticMeshComponent.IsValid())
					{
						return;
					}
					float distanceAlongSpline = runtimeData.MoveComponent.GetDistanceAlongSpline();
					float num = distanceAlongSpline - this.LastSplineDistance;
					this.LastSplineDistance = distanceAlongSpline;
					if (num == 0f)
					{
						return;
					}
					double num2 = (double)num / (6.283185307179586 * (double)this.BarrelRadius) * 360.0;
					FHitResult fhitResult = null;
					staticMeshComponent.K2_AddLocalRotation(new FRotator(0f, (float)num2, 0f), false, ref fhitResult, false);
					return;
				}
			}
		}

		// Token: 0x0603017A RID: 196986 RVA: 0x00BAA368 File Offset: 0x00BA8568
		public void OnFinishing(IPathDrivenActorRuntimeData runtimeData, EPathDrivenActorFinishReason reason)
		{
			this.StopRollingAudio();
			AActor actor = runtimeData.Actor;
			FTransformDouble? actorTransform = (actor != null && actor.IsValid()) ? new FTransformDouble?(actor.D_GetTransform()) : null;
			this.TryPlayExplodeEffect(runtimeData, actorTransform);
			if (reason == EPathDrivenActorFinishReason.Overlap)
			{
				this.TryEmitOverlapHitEvent();
			}
		}

		// Token: 0x0603017B RID: 196987 RVA: 0x00BAA3B8 File Offset: 0x00BA85B8
		public void Cleanup(IPathDrivenActorRuntimeData runtimeData)
		{
			this.StopRollingAudio();
			AActor actor = runtimeData.Actor;
			if (actor != null && actor.IsValid())
			{
				runtimeData.Actor.OnActorBeginOverlap.Remove(new Action<AActor, AActor>(this.HandleActorBeginOverlap));
			}
			this.ExplodeEffectPath = "";
			this.AudioEvent = "";
			this.StaticMeshComponent = null;
			this.LastSplineDistance = 0f;
			this.RuntimeData = null;
		}

		// Token: 0x0603017C RID: 196988 RVA: 0x00BAA42C File Offset: 0x00BA862C
		private void StartRollingAudio(AActor actor)
		{
			if (string.IsNullOrEmpty(this.AudioEvent) || this.AudioHandle != 0 || (actor == null || !actor.IsValid()))
			{
				return;
			}
			this.AudioHandle = Singleton<AudioSystem>.Instance.PostEvent(this.AudioEvent, actor, null);
		}

		// Token: 0x0603017D RID: 196989 RVA: 0x00BAA480 File Offset: 0x00BA8680
		private void StopRollingAudio()
		{
			if (this.AudioHandle == 0)
			{
				return;
			}
			Singleton<AudioSystem>.Instance.ExecuteAction(this.AudioHandle, EAudioActionType.Stop, new ExecuteActionArgs?(new ExecuteActionArgs
			{
				TransitionDuration = new int?(700)
			}));
			this.AudioHandle = 0;
		}

		// Token: 0x0603017E RID: 196990 RVA: 0x00BAA4D0 File Offset: 0x00BA86D0
		private unsafe void TryPlayExplodeEffect(IPathDrivenActorRuntimeData runtimeData, FTransformDouble? actorTransform)
		{
			if (actorTransform == null || string.IsNullOrEmpty(this.ExplodeEffectPath) || GlobalData.World == null)
			{
				return;
			}
			int id = Singleton<EffectSystem>.Instance.SpawnEffect(GlobalData.World, actorTransform, this.ExplodeEffectPath, "[ExplosiveBarrelPathDrivenBehavior] PlayExplodeEffect", null, EEffectType.Scene, null, null, null, false, false);
			if (!Singleton<EffectSystem>.Instance.IsValid(id))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.PathDrivenActor;
				ELogAuthor author = ELogAuthor.WRY;
				string message = "[ExplosiveBarrelPathDrivenBehavior] 爆炸桶爆炸效果播放失败";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("PbDataId", this.OwnerPbDataId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("EffectPath", this.ExplodeEffectPath);
				instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			}
		}

		// Token: 0x0603017F RID: 196991 RVA: 0x00BAA594 File Offset: 0x00BA8794
		private unsafe void TryEmitOverlapHitEvent()
		{
			FGameplayTag? gameplayTagById = GameplayTagUtils.GetGameplayTagById(this.ExplosiveBarrelHitEventTagId);
			if (gameplayTagById == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.PathDrivenActor;
				ELogAuthor author = ELogAuthor.WRY;
				string message = "[ExplosiveBarrelPathDrivenBehavior] 爆炸桶命中事件Tag无效";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("PbDataId", this.OwnerPbDataId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("TagId", this.ExplosiveBarrelHitEventTagId);
				instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return;
			}
			Singleton<EventSystem>.Instance.Emit<FGameplayTag>(EEventName.CheckClientEvent, gameplayTagById.Value);
		}

		// Token: 0x06030180 RID: 196992 RVA: 0x00BAA638 File Offset: 0x00BA8838
		[NullableContext(2)]
		private void HandleActorBeginOverlap(AActor overlappedActor, AActor otherActor)
		{
			TsBaseCharacter baseCharacter = Global.BaseCharacter;
			AActor aactor;
			if (baseCharacter == null)
			{
				aactor = null;
			}
			else
			{
				CharacterActorComponent characterActorComponent = baseCharacter.CharacterActorComponent;
				aactor = ((characterActorComponent != null) ? characterActorComponent.Owner : null);
			}
			AActor aactor2 = aactor;
			TsBaseCharacter baseCharacter2 = Global.BaseCharacter;
			TsBaseVehicle tsBaseVehicle;
			if (baseCharacter2 == null)
			{
				tsBaseVehicle = null;
			}
			else
			{
				CharacterActorComponent characterActorComponent2 = baseCharacter2.CharacterActorComponent;
				if (characterActorComponent2 == null)
				{
					tsBaseVehicle = null;
				}
				else
				{
					Entity entity = characterActorComponent2.Entity;
					if (entity == null)
					{
						tsBaseVehicle = null;
					}
					else
					{
						RoleDriveVehicleComponent component = entity.GetComponent<RoleDriveVehicleComponent>();
						if (component == null)
						{
							tsBaseVehicle = null;
						}
						else
						{
							Entity vehicleEntity = component.VehicleEntity;
							if (vehicleEntity == null)
							{
								tsBaseVehicle = null;
							}
							else
							{
								VehicleActorComponent component2 = vehicleEntity.GetComponent<VehicleActorComponent>();
								tsBaseVehicle = ((component2 != null) ? component2.Actor : null);
							}
						}
					}
				}
			}
			TsBaseVehicle tsBaseVehicle2 = tsBaseVehicle;
			if (overlappedActor == null || !overlappedActor.IsValid() || (otherActor == null || !otherActor.IsValid()) || otherActor == overlappedActor || (otherActor != aactor2 && otherActor != tsBaseVehicle2))
			{
				return;
			}
			IPathDrivenActorRuntimeData runtimeData = this.RuntimeData;
			if (runtimeData == null)
			{
				return;
			}
			runtimeData.RequestFinish(EPathDrivenActorFinishReason.Overlap);
		}

		// Token: 0x0401B9D0 RID: 113104
		public const string EXPLOSIVE_BARREL_CLASS_NAME = "BP_ExplosiveBarrel_C";

		// Token: 0x0401B9D1 RID: 113105
		private const float MIN_BARREL_RADIUS = 0.01f;

		// Token: 0x0401B9D2 RID: 113106
		private readonly int? OwnerPbDataId;

		// Token: 0x0401B9D3 RID: 113107
		private readonly int ExplosiveBarrelHitEventTagId;

		// Token: 0x0401B9D4 RID: 113108
		private float BarrelRadius;

		// Token: 0x0401B9D5 RID: 113109
		private string ExplodeEffectPath = "";

		// Token: 0x0401B9D6 RID: 113110
		private string AudioEvent = "";

		// Token: 0x0401B9D7 RID: 113111
		private int AudioHandle;

		// Token: 0x0401B9D8 RID: 113112
		[Nullable(2)]
		private UStaticMeshComponent StaticMeshComponent;

		// Token: 0x0401B9D9 RID: 113113
		private float LastSplineDistance;

		// Token: 0x0401B9DA RID: 113114
		[Nullable(2)]
		private IPathDrivenActorRuntimeData RuntimeData;
	}
}
