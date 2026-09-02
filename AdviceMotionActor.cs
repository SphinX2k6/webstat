using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using AkiClient.Game.Aki.Data.Entity.Struct;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.Manager;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.MaterialController;
using CSharpScript.Game.Module.Advice;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001776 RID: 6006
[NullableContext(2)]
[Nullable(0)]
public class AdviceMotionActor
{
	// Token: 0x0600A91D RID: 43293 RVA: 0x002D0D00 File Offset: 0x002CEF00
	public void PlayMotion(int entityId)
	{
		this.CurrentEntity = entityId;
		this.InitInternalActor(entityId, delegate
		{
			this.PlayInteractAnimation(entityId);
		});
	}

	// Token: 0x0600A91E RID: 43294 RVA: 0x002D0D48 File Offset: 0x002CEF48
	[NullableContext(1)]
	private void InitInternalActor(int entityId, Action loadMeshCompleteCall)
	{
		Entity entity = Singleton<EntitySystem>.Instance.Get(entityId);
		if (entity == null)
		{
			return;
		}
		SceneItemActorComponent component = entity.GetComponent<SceneItemActorComponent>();
		CreatureDataComponent component2 = entity.GetComponent<CreatureDataComponent>();
		if (component != null)
		{
			bool flag;
			if (component2 == null)
			{
				flag = (null != null);
			}
			else
			{
				AdviceEntityData adviceInfo = component2.GetAdviceInfo();
				flag = (((adviceInfo != null) ? adviceInfo.GetAdviceData() : null) != null);
			}
			if (flag)
			{
				long adviceMotionId = component2.GetAdviceInfo().GetAdviceData().GetAdviceMotionId();
				if (adviceMotionId == 0L)
				{
					return;
				}
				if (this.ActorInternal == null)
				{
					this.ActorInternal = Singleton<ActorSystem>.Instance.Get(AActor.StaticClass(), component.ActorTransform, null, true);
					AActor actorInternal = this.ActorInternal;
					this.SkeletalMeshInternal = (((actorInternal != null) ? actorInternal.AddComponentByClass(USkeletalMeshComponent.StaticClass(), false, Singleton<MathUtils>.Instance.DefaultTransform, false, default(FName)) : null) as USkeletalMeshComponent);
					AActor actorInternal2 = this.ActorInternal;
					this.CharRenderingComponent = (((actorInternal2 != null) ? actorInternal2.AddComponentByClass(CharRenderingComponent.StaticClass(), false, Singleton<MathUtils>.Instance.DefaultTransform, false, default(FName)) : null) as CharRenderingComponent);
					if (this.SkeletalMeshInternal != null)
					{
						this.SkeletalMeshInternal.SetEnableGravity(false);
						this.SkeletalMeshInternal.SetCollisionEnabled(ECollisionEnabled.NoCollision);
						this.SkeletalMeshInternal.SetSimulatePhysics(false);
					}
					if (this.CharRenderingComponent != null)
					{
						this.CharRenderingComponent.Init(ECharacterRenderingType.LocalPlayer);
					}
				}
				FHitResult fhitResult = new FHitResult();
				AActor actorInternal3 = this.ActorInternal;
				if (actorInternal3 != null)
				{
					actorInternal3.D_K2_SetActorRelativeLocation(component.ActorLocationProxy.ToUeVector(false), false, ref fhitResult, true);
				}
				AActor actorInternal4 = this.ActorInternal;
				if (actorInternal4 != null)
				{
					actorInternal4.K2_SetActorRotation(component.ActorRotationProxy.ToUeRotator(), false);
				}
				int? motionRoleId = ConfigBase<MotionConfig>.Instance.GetMotionRoleId((int)adviceMotionId);
				RoleInfo? roleConfig = ConfigBase<RoleConfig>.Instance.GetRoleConfig(motionRoleId.GetValueOrDefault());
				if (roleConfig == null)
				{
					return;
				}
				SModelConfig modelConfig = ModelUtil.GetModelConfig(roleConfig.Value.MeshId);
				if (modelConfig == null)
				{
					return;
				}
				string memoryTag = Singleton<UiConfig>.Instance.GetMemoryTag(EUiViewName.AdviceInfoView);
				Singleton<ResourceSystem>.Instance.LoadAsync<USkeletalMesh>(modelConfig.网格体.ToAssetPathName(), delegate([Nullable(2)] USkeletalMesh result, string path)
				{
					if (this.SkeletalMeshInternal != null && result != null)
					{
						this.SkeletalMeshInternal.SetSkeletalMesh(result, true);
						this.SkeletalMeshInternal.SetHiddenInGame(true, false);
					}
					loadMeshCompleteCall();
				}, 100, memoryTag);
				if (this.ActorInternal != null)
				{
					this.ActorInternal.OnDestroyed.Add(new Action<AActor>(this.OnActorDestroy));
				}
				return;
			}
		}
	}

	// Token: 0x0600A91F RID: 43295 RVA: 0x002D0F90 File Offset: 0x002CF190
	private void PlayInteractAnimation(int entityId)
	{
		this.ClearTimer();
		this.PlayState = true;
		this.RemoveMat();
		Entity entity = Singleton<EntitySystem>.Instance.Get(entityId);
		if (entity == null)
		{
			return;
		}
		CreatureDataComponent component = entity.GetComponent<CreatureDataComponent>();
		bool flag;
		if (component == null)
		{
			flag = (null != null);
		}
		else
		{
			AdviceEntityData adviceInfo = component.GetAdviceInfo();
			flag = (((adviceInfo != null) ? adviceInfo.GetAdviceData() : null) != null);
		}
		if (!flag)
		{
			return;
		}
		long adviceMotionId = component.GetAdviceInfo().GetAdviceData().GetAdviceMotionId();
		if (adviceMotionId == 0L)
		{
			return;
		}
		this.RemoveMat();
		USkeletalMeshComponent meshComponent = this.SkeletalMeshInternal;
		string motionAnimation = ConfigBase<MotionConfig>.Instance.GetMotionAnimation((int)adviceMotionId);
		string memoryTag = Singleton<UiConfig>.Instance.GetMemoryTag(EUiViewName.AdviceInfoView);
		if (motionAnimation != null)
		{
			Singleton<ResourceSystem>.Instance.LoadAsync<UAnimationAsset>(motionAnimation, delegate([Nullable(2)] UAnimationAsset result, string path)
			{
				if (this.PlayState && meshComponent != null && result != null)
				{
					meshComponent.PlayAnimation(result, false);
				}
				this.OnLoadCompleteCheckForShow();
			}, 100, memoryTag);
		}
		if (meshComponent != null)
		{
			meshComponent.SetPlayRate(1f);
			meshComponent.SetPosition(1f, true);
		}
		if (this.CharRenderingComponent != null && this.SkeletalMeshInternal != null)
		{
			this.CharRenderingComponent.AddComponentByCase(ECharacterControllerCaseType.BodyCase0, this.SkeletalMeshInternal);
		}
		if (this.CharRenderingComponent != null)
		{
			string adviceModelMat = ConfigBase<AdviceConfig>.Instance.GetAdviceModelMat();
			Singleton<ResourceSystem>.Instance.LoadAsync<PD_CharacterControllerData_C>(adviceModelMat, delegate([Nullable(2)] PD_CharacterControllerData_C result, string path)
			{
				if (this.PlayState && this.CharRenderingComponent != null && result != null)
				{
					this.MaterialEffectHandle = this.CharRenderingComponent.AddMaterialControllerData(result);
				}
				this.OnLoadCompleteCheckForShow();
			}, 100, memoryTag);
		}
		ModelBase<AdviceModel>.Instance.AddPlayingMotionEntity(this.CurrentEntity, this);
	}

	// Token: 0x0600A920 RID: 43296 RVA: 0x002D10E4 File Offset: 0x002CF2E4
	private void OnLoadCompleteCheckForShow()
	{
		USkeletalMeshComponent meshComponent = this.SkeletalMeshInternal;
		if (meshComponent != null && this.PlayState && this.MaterialEffectHandle > 0)
		{
			TimerSystem.Instance.Delay(delegate(float _)
			{
				if (meshComponent != null && this.PlayState && this.MaterialEffectHandle > 0)
				{
					meshComponent.SetHiddenInGame(false, false);
					this.RevertTimer = TimerSystem.Instance.Delay(new TTimerAction(this.RevertToNormalModel), 3000f, null, null, true, 1f);
				}
			}, 20f, null, null, true, 1f);
		}
	}

	// Token: 0x0600A921 RID: 43297 RVA: 0x002D1148 File Offset: 0x002CF348
	private void RevertToNormalModel(float deltaTime)
	{
		this.RemoveMat();
		USkeletalMeshComponent skeletalMeshInternal = this.SkeletalMeshInternal;
		if (skeletalMeshInternal != null)
		{
			skeletalMeshInternal.SetHiddenInGame(true, false);
		}
		this.RevertTimer = null;
		ModelBase<AdviceModel>.Instance.RecycleMotionActor(this);
		ModelBase<AdviceModel>.Instance.RemovePlayingMotionEntity(this.CurrentEntity);
	}

	// Token: 0x0600A922 RID: 43298 RVA: 0x002D118F File Offset: 0x002CF38F
	private void ClearTimer()
	{
		this.PlayState = false;
		if (this.RevertTimer != null)
		{
			TimerSystem.Instance.Remove(this.RevertTimer);
			this.RevertTimer = null;
		}
	}

	// Token: 0x0600A923 RID: 43299 RVA: 0x002D11B8 File Offset: 0x002CF3B8
	private void RemoveMat()
	{
		if (this.CharRenderingComponent != null && this.MaterialEffectHandle > 0)
		{
			this.CharRenderingComponent.RemoveMaterialControllerDataWithEnding(this.MaterialEffectHandle);
			this.MaterialEffectHandle = 0;
		}
	}

	// Token: 0x0600A924 RID: 43300 RVA: 0x002D11E4 File Offset: 0x002CF3E4
	public void OnActorDestroy(AActor actor)
	{
		this.ClearTimer();
		AActor actorInternal = this.ActorInternal;
		if (actorInternal != null && actorInternal.IsValid())
		{
			Singleton<ActorSystem>.Instance.Put("AdviceMotionActor.OnActorDestroy", this.ActorInternal, null);
			this.ActorInternal = null;
		}
		ModelBase<AdviceModel>.Instance.RemovePlayingMotionEntity(this.CurrentEntity);
		ModelBase<AdviceModel>.Instance.RemoveMotionActor(this);
	}

	// Token: 0x04004FB6 RID: 20406
	private TimerHandle RevertTimer;

	// Token: 0x04004FB7 RID: 20407
	protected AActor ActorInternal;

	// Token: 0x04004FB8 RID: 20408
	protected USkeletalMeshComponent SkeletalMeshInternal;

	// Token: 0x04004FB9 RID: 20409
	private CharRenderingComponent CharRenderingComponent;

	// Token: 0x04004FBA RID: 20410
	private int MaterialEffectHandle;

	// Token: 0x04004FBB RID: 20411
	private int CurrentEntity;

	// Token: 0x04004FBC RID: 20412
	private bool PlayState;

	// Token: 0x04004FBD RID: 20413
	private const int REVERTIME = 3000;
}
