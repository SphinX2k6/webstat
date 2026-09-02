using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using AkiClient.Game.Aki.Data.Entity.Struct;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.Manager;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.MaterialController;
using CSharpScript.Game;
using CSharpScript.Game.Camera;
using CSharpScript.Game.Module.Advice;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Render;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x0200176D RID: 5997
[NullableContext(2)]
[Nullable(0)]
public class AdviceCreateActor
{
	// Token: 0x0600A8C4 RID: 43204 RVA: 0x002CF050 File Offset: 0x002CD250
	public void Init()
	{
		this.InitInternalActor();
		this.LoadDefaultModel();
	}

	// Token: 0x0600A8C5 RID: 43205 RVA: 0x002CF05E File Offset: 0x002CD25E
	public void PlayAnimation(int motionId)
	{
		this.SetInteractionActorActive(false);
		this.Play(motionId);
	}

	// Token: 0x0600A8C6 RID: 43206 RVA: 0x002CF070 File Offset: 0x002CD270
	private void SetInteractionActorActive(bool state)
	{
		TArray<AActor> sceneInteractionAllActorsInLevel = SceneInteractionManager.Get().GetSceneInteractionAllActorsInLevel(this.SceneInteractionLevelHandleId);
		if (sceneInteractionAllActorsInLevel == null)
		{
			return;
		}
		int num = sceneInteractionAllActorsInLevel.Num();
		for (int i = 0; i < num; i++)
		{
			AActor aactor = sceneInteractionAllActorsInLevel.Get(i);
			if (aactor != null)
			{
				aactor.SetActorHiddenInGame(!state);
			}
		}
	}

	// Token: 0x0600A8C7 RID: 43207 RVA: 0x002CF0BA File Offset: 0x002CD2BA
	public void HideAnimation()
	{
		this.ClearTimer();
		this.RemoveMat();
		if (this.SkeletalMeshInternal != null)
		{
			this.SkeletalMeshInternal.SetHiddenInGame(true, false);
			this.SkeletalMeshInternal.Stop();
		}
		this.SetInteractionActorActive(true);
	}

	// Token: 0x0600A8C8 RID: 43208 RVA: 0x002CF0F0 File Offset: 0x002CD2F0
	private void LoadDefaultModel()
	{
		SModelConfig modelConfig = ModelUtil.GetModelConfig(ConfigBase<AdviceConfig>.Instance.GetAdviceDefaultModelConfig());
		if (modelConfig == null)
		{
			return;
		}
		FSoftObjectPath 场景交互物 = modelConfig.场景交互物;
		if (场景交互物 == null)
		{
			return;
		}
		global::Vector vector = global::Vector.Create();
		Rotator rotator = Rotator.Create();
		TsBaseCharacter baseCharacter = Global.BaseCharacter;
		if (((baseCharacter != null) ? baseCharacter.CharacterActorComponent : null) == null)
		{
			return;
		}
		vector.DeepCopy(baseCharacter.CharacterActorComponent.ActorLocationProxy);
		global::Vector vector2 = vector;
		double z = vector2.Z;
		UCapsuleComponent capsuleComponent = baseCharacter.CharacterActorComponent.Actor.CapsuleComponent;
		vector2.Z = z - (double)((capsuleComponent != null) ? capsuleComponent.GetScaledCapsuleHalfHeight() : 0f);
		rotator.DeepCopy(baseCharacter.CharacterActorComponent.ActorRotationProxy);
		AActor currentCameraActor = ModelBase<CameraModel>.Instance.MainModel.CurrentCameraActor;
		if (currentCameraActor != null)
		{
			rotator.Yaw = currentCameraActor.D_GetTransform().Rotator().Yaw + 90f;
		}
		this.SceneInteractionLevelHandleId = SceneInteractionManager.Get().CreateSceneInteractionLevel(场景交互物.AssetPathName.ToString(), new EKuroSceneInteractionState?(EKuroSceneInteractionState.State1), vector.ToUeVector(false), rotator.ToUeRotator(), null, true, false, 0, null);
	}

	// Token: 0x0600A8C9 RID: 43209 RVA: 0x002CF214 File Offset: 0x002CD414
	private void InitInternalActor()
	{
		if (this.ActorInternal == null)
		{
			this.ActorInternal = Singleton<ActorSystem>.Instance.Get(AActor.StaticClass(), Singleton<MathUtils>.Instance.DefaultTransformDouble, null, true);
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
		if (this.SkeletalMeshInternal != null)
		{
			this.SkeletalMeshInternal.SetHiddenInGame(true, false);
			this.SkeletalMeshInternal.Stop();
		}
		this.RefreshPosition();
		if (this.ActorInternal != null)
		{
			this.ActorInternal.OnDestroyed.Add(new Action<AActor>(this.OnActorDestroy));
		}
	}

	// Token: 0x0600A8CA RID: 43210 RVA: 0x002CF350 File Offset: 0x002CD550
	public void RefreshPosition()
	{
		global::Vector vector = global::Vector.Create();
		Rotator rotator = Rotator.Create();
		TsBaseCharacter baseCharacter = Global.BaseCharacter;
		if (((baseCharacter != null) ? baseCharacter.CharacterActorComponent : null) == null)
		{
			return;
		}
		vector.DeepCopy(baseCharacter.CharacterActorComponent.ActorLocationProxy);
		global::Vector vector2 = vector;
		double z = vector2.Z;
		UCapsuleComponent capsuleComponent = baseCharacter.CharacterActorComponent.Actor.CapsuleComponent;
		vector2.Z = z - (double)((capsuleComponent != null) ? capsuleComponent.GetScaledCapsuleHalfHeight() : 0f);
		rotator.DeepCopy(baseCharacter.CharacterActorComponent.ActorRotationProxy);
		AActor currentCameraActor = ModelBase<CameraModel>.Instance.MainModel.CurrentCameraActor;
		if (currentCameraActor != null)
		{
			rotator.Yaw = currentCameraActor.D_GetTransform().Rotator().Yaw + 90f;
		}
		FHitResult fhitResult = new FHitResult();
		AActor actorInternal = this.ActorInternal;
		if (actorInternal != null)
		{
			actorInternal.D_K2_SetActorLocation(vector.ToUeVector(false), false, ref fhitResult, true);
		}
		AActor actorInternal2 = this.ActorInternal;
		if (actorInternal2 == null)
		{
			return;
		}
		actorInternal2.K2_SetActorRotation(rotator.ToUeRotator(), false);
	}

	// Token: 0x0600A8CB RID: 43211 RVA: 0x002CF440 File Offset: 0x002CD640
	private void Play(int motionId)
	{
		this.PlayState = true;
		this.ClearTimer();
		this.RemoveMat();
		USkeletalMeshComponent meshComponent = this.SkeletalMeshInternal;
		if (this.SkeletalMeshInternal != null)
		{
			this.SkeletalMeshInternal.SetHiddenInGame(true, false);
			this.SkeletalMeshInternal.Stop();
		}
		int? motionRoleId = ConfigBase<MotionConfig>.Instance.GetMotionRoleId(motionId);
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
		this.AnimateAssetState = false;
		this.MeshLoadState = false;
		this.MatLoadState = false;
		this.CurrentAnimateAsset = null;
		string memoryTag = Singleton<UiConfig>.Instance.GetMemoryTag(EUiViewName.AdviceCreateView);
		Singleton<ResourceSystem>.Instance.LoadAsync<USkeletalMesh>(modelConfig.网格体.ToAssetPathName(), delegate([Nullable(2)] USkeletalMesh result, string path)
		{
			if (meshComponent != null && result != null)
			{
				meshComponent.SetSkeletalMesh(result, true);
			}
			this.MeshLoadState = true;
			this.CheckLoadStateAndShowActor();
		}, 100, memoryTag);
		string motionAnimation = ConfigBase<MotionConfig>.Instance.GetMotionAnimation(motionId);
		if (motionAnimation != null)
		{
			Singleton<ResourceSystem>.Instance.LoadAsync<UAnimationAsset>(motionAnimation, delegate([Nullable(2)] UAnimationAsset result, string path)
			{
				this.AnimateAssetState = true;
				this.CurrentAnimateAsset = result;
				this.CheckLoadStateAndShowActor();
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
			string adviceModelMat = ConfigBase<AdviceConfig>.Instance.GetAdviceModelMat();
			Singleton<ResourceSystem>.Instance.LoadAsync<PD_CharacterControllerData_C>(adviceModelMat, delegate([Nullable(2)] PD_CharacterControllerData_C result, string path)
			{
				this.MatLoadState = true;
				if (this.PlayState && this.CharRenderingComponent != null && result != null)
				{
					this.MaterialEffectHandle = this.CharRenderingComponent.AddMaterialControllerData(result);
				}
				this.CheckLoadStateAndShowActor();
			}, 100, memoryTag);
		}
		this.RevertTimer = TimerSystem.Instance.Delay(new TTimerAction(this.RevertToNormalModel), 3000f, null, null, true, 1f);
	}

	// Token: 0x0600A8CC RID: 43212 RVA: 0x002CF600 File Offset: 0x002CD800
	private void CheckLoadStateAndShowActor()
	{
		if (this.MatLoadState && this.MeshLoadState && this.AnimateAssetState && this.PlayState && this.SkeletalMeshInternal != null)
		{
			this.SkeletalMeshInternal.SetHiddenInGame(false, false);
			this.SkeletalMeshInternal.Play(true);
			if (this.CurrentAnimateAsset != null)
			{
				this.SkeletalMeshInternal.PlayAnimation(this.CurrentAnimateAsset as UAnimationAsset, false);
			}
		}
	}

	// Token: 0x0600A8CD RID: 43213 RVA: 0x002CF66D File Offset: 0x002CD86D
	private void RevertToNormalModel(float deltaTime)
	{
		this.RemoveMat();
		if (this.SkeletalMeshInternal != null)
		{
			this.SkeletalMeshInternal.SetHiddenInGame(true, false);
			this.SkeletalMeshInternal.Stop();
		}
		this.ClearTimer();
		this.SetInteractionActorActive(true);
	}

	// Token: 0x0600A8CE RID: 43214 RVA: 0x002CF6A2 File Offset: 0x002CD8A2
	private void RemoveMat()
	{
		if (this.CharRenderingComponent != null && this.MaterialEffectHandle > 0)
		{
			this.CharRenderingComponent.RemoveMaterialControllerDataWithEnding(this.MaterialEffectHandle);
			this.MaterialEffectHandle = 0;
		}
	}

	// Token: 0x0600A8CF RID: 43215 RVA: 0x002CF6D0 File Offset: 0x002CD8D0
	public void Destroy()
	{
		this.ClearTimer();
		SceneInteractionManager.Get().DestroySceneInteraction(this.SceneInteractionLevelHandleId);
		if (this.ActorInternal != null)
		{
			Singleton<ActorSystem>.Instance.Put("AdviceCreateActor.Destroy", this.ActorInternal, null);
			this.ActorInternal = null;
		}
		ModelBase<AdviceModel>.Instance.OnAdviceCreateActorDestroy();
	}

	// Token: 0x0600A8D0 RID: 43216 RVA: 0x002CF724 File Offset: 0x002CD924
	private void ClearTimer()
	{
		if (this.RevertTimer != null)
		{
			TimerSystem.Instance.Remove(this.RevertTimer);
			this.RevertTimer = null;
		}
	}

	// Token: 0x0600A8D1 RID: 43217 RVA: 0x002CF748 File Offset: 0x002CD948
	private void OnActorDestroy(AActor actor)
	{
		this.ClearTimer();
		AActor actorInternal = this.ActorInternal;
		if (actorInternal != null && actorInternal.IsValid())
		{
			Singleton<ActorSystem>.Instance.Put("AdviceCreateActor.OnActorDestroy", this.ActorInternal, null);
			this.ActorInternal = null;
		}
		ModelBase<AdviceModel>.Instance.OnAdviceCreateActorDestroy();
	}

	// Token: 0x04004F6D RID: 20333
	protected AActor ActorInternal;

	// Token: 0x04004F6E RID: 20334
	protected USkeletalMeshComponent SkeletalMeshInternal;

	// Token: 0x04004F6F RID: 20335
	private CharRenderingComponent CharRenderingComponent;

	// Token: 0x04004F70 RID: 20336
	private int MaterialEffectHandle;

	// Token: 0x04004F71 RID: 20337
	private bool PlayState;

	// Token: 0x04004F72 RID: 20338
	private int SceneInteractionLevelHandleId;

	// Token: 0x04004F73 RID: 20339
	private TimerHandle RevertTimer;

	// Token: 0x04004F74 RID: 20340
	private object CurrentAnimateAsset;

	// Token: 0x04004F75 RID: 20341
	private bool AnimateAssetState;

	// Token: 0x04004F76 RID: 20342
	private bool MeshLoadState;

	// Token: 0x04004F77 RID: 20343
	private bool MatLoadState;

	// Token: 0x04004F78 RID: 20344
	private const int REVERTIME = 3000;
}
