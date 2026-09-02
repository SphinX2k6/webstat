using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Gameplay.RhythmGame;
using AkiClient.Game.Aki.Data.Level.PlaneYinyou.BP;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Effect;
using UnrealEngine;

// Token: 0x02001146 RID: 4422
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class RhythmGameShipController : ControllerBase<RhythmGameShipController>
{
	// Token: 0x06007470 RID: 29808 RVA: 0x001E7EC0 File Offset: 0x001E60C0
	public void Initialize(BP_Plane_C shipActor)
	{
		this.ShipActor = shipActor;
		USkeletalMeshComponent skeletalMesh = shipActor.SkeletalMesh;
		this.ShipAnimInstance = (((skeletalMesh != null) ? skeletalMesh.GetAnimInstance() : null) as ABP_Plane_C);
		this.SwitchFireLevel();
		this.SpawnLockIcon();
		Singleton<EventSystem>.Instance.Add(EEventName.OnRhythmGameSpeedLevelConfigIndexChanged, new Action<int>(this.OnSpeedLevelChanged));
	}

	// Token: 0x06007471 RID: 29809 RVA: 0x001E7F1C File Offset: 0x001E611C
	public void Release()
	{
		this.ShipActor = null;
		if (Singleton<EventSystem>.Instance.Has(EEventName.OnRhythmGameSpeedLevelConfigIndexChanged, new Action<int>(this.OnSpeedLevelChanged)))
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnRhythmGameSpeedLevelConfigIndexChanged, new Action<int>(this.OnSpeedLevelChanged));
		}
		if (this.FireEffectHandle != -1)
		{
			Singleton<EffectSystem>.Instance.StopEffectById(this.FireEffectHandle, "[RhythmGameShipController] Release Fire Effect", false, null);
			this.FireEffectHandle = -1;
		}
		if (this.FireworksEffectHandle != -1)
		{
			this.StopFireworksEffect();
		}
		if (this.HighSpeedEffectHandles.Count > 0)
		{
			foreach (int handle in this.HighSpeedEffectHandles)
			{
				Singleton<EffectSystem>.Instance.StopEffectById(handle, "[RhythmGameShipController] Stop High Speed Effect", false, null);
			}
			this.HighSpeedEffectHandles.Clear();
		}
		if (this.FeverEffectHandles.Count > 0)
		{
			foreach (int handle2 in this.FeverEffectHandles)
			{
				Singleton<EffectSystem>.Instance.StopEffectById(handle2, "[RhythmGameShipController] Stop Fever Effect", false, null);
			}
			this.FeverEffectHandles.Clear();
		}
		if (this.HitLockEffectHandle != -1)
		{
			Singleton<EffectSystem>.Instance.StopEffectById(this.HitLockEffectHandle, "[RhythmGameShipController] Release Hit Lock Effect", false, null);
			this.HitLockEffectHandle = -1;
		}
		if (this.SparksLineEffectHandle != -1)
		{
			this.StopSparksLineEffect();
		}
		if (this.DestroyHitLockEffectHandle != null)
		{
			TimerSystem.Instance.Remove(this.DestroyHitLockEffectHandle);
			this.DestroyHitLockEffectHandle = null;
		}
		this.StopLockIconEffect();
	}

	// Token: 0x06007472 RID: 29810 RVA: 0x001E80F0 File Offset: 0x001E62F0
	private void OnSpeedLevelChanged(int value)
	{
		this.SwitchFireLevel();
		if (value >= 3)
		{
			this.SpawnHighSpeedEffect();
		}
		else
		{
			this.StopHighSpeedEffect();
		}
		if (value >= 4)
		{
			this.SpawnFeverEffect();
			this.SpawnFireworksEffect();
			this.SpawnSparksLineEffect();
			return;
		}
		this.StopFeverEffect();
		this.StopFireworksEffect();
		this.StopSparksLineEffect();
	}

	// Token: 0x06007473 RID: 29811 RVA: 0x001E8140 File Offset: 0x001E6340
	private int SpawnAttachedEffect(string effectPath, string logContext, USceneComponent attachComponent, FName? socketName = null, [Nullable(new byte[]
	{
		2,
		0,
		1,
		1
	})] Action<OneOf<KuroEffectActorHandle, AActor>> onSpawned = null)
	{
		EffectSystem instance = Singleton<EffectSystem>.Instance;
		UObject world = GlobalData.World;
		FTransformDouble? ftransformDouble = new FTransformDouble?(Singleton<MathUtils>.Instance.DefaultTransformDouble);
		int num = instance.SpawnEffect(world, ftransformDouble, effectPath, logContext, null, EEffectType.Scene, null, null, null, false, false);
		OneOf<KuroEffectActorHandle, AActor> effectActor = Singleton<EffectSystem>.Instance.GetEffectActor(num);
		effectActor.K2_AttachToComponent(attachComponent, socketName, EAttachmentRule.SnapToTarget, EAttachmentRule.SnapToTarget, EAttachmentRule.SnapToTarget, false);
		if (onSpawned != null)
		{
			onSpawned(effectActor);
		}
		return num;
	}

	// Token: 0x06007474 RID: 29812 RVA: 0x001E81A0 File Offset: 0x001E63A0
	private void StopEffect(int handle, string logContext)
	{
		if (handle != -1)
		{
			Singleton<EffectSystem>.Instance.StopEffectById(handle, logContext, false, null);
		}
	}

	// Token: 0x06007475 RID: 29813 RVA: 0x001E81C8 File Offset: 0x001E63C8
	private void SwitchFireLevel()
	{
		if (this.ShipActor == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.RhythmGame, ELogAuthor.CH, "[RhythmGameShipController] ShipActor is null", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		RhythmGameSpeedLevelConfig currentSpeedLevelConfig = ModelBase<RhythmGameModel>.Instance.GetCurrentSpeedLevelConfig();
		string text = (currentSpeedLevelConfig != null) ? currentSpeedLevelConfig.FireEffectDa.ToAssetPathName() : null;
		if (text == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.RhythmGame, ELogAuthor.CH, "[RhythmGameShipController] FireEffectPath is null", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		this.StopEffect(this.FireEffectHandle, "[RhythmGameShipController] Play New Fire Effect");
		this.FireEffectHandle = -1;
		this.FireEffectHandle = this.SpawnAttachedEffect(text, "[RhythmGameShipController] Play New Fire Effect", this.ShipActor.SkeletalMesh, new FName?(new FName("Bone_Prop001")), delegate([Nullable(new byte[]
		{
			0,
			1,
			1
		})] OneOf<KuroEffectActorHandle, AActor> actor)
		{
			FTransformDouble ftransformDouble = new FTransformDouble();
			FQuat fquat = new FRotator(0f, 90f, 0f).Quaternion();
			ftransformDouble.SetRotation(fquat);
			FHitResult fhitResult = new FHitResult();
			actor.D_K2_SetActorRelativeTransform(ftransformDouble, false, ref fhitResult, false);
		});
	}

	// Token: 0x06007476 RID: 29814 RVA: 0x001E82A0 File Offset: 0x001E64A0
	private void SpawnHighSpeedEffect()
	{
		if (this.ShipActor == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.RhythmGame, ELogAuthor.CH, "[RhythmGameShipController] ShipActor is null", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		if (this.HighSpeedEffectHandles.Count > 0)
		{
			return;
		}
		foreach (string effectPath in RhythmGameModelDefine.RhythmGameHighSpeedEffect)
		{
			this.HighSpeedEffectHandles.Add(this.SpawnAttachedEffect(effectPath, "[RhythmGameShipController] Spawn High Speed Effect", this.ShipActor.SkeletalMesh, null, null));
		}
	}

	// Token: 0x06007477 RID: 29815 RVA: 0x001E8348 File Offset: 0x001E6548
	private void StopHighSpeedEffect()
	{
		foreach (int handle in this.HighSpeedEffectHandles)
		{
			Singleton<EffectSystem>.Instance.StopEffectById(handle, "[RhythmGameShipController] Stop High Speed Effect", false, null);
		}
		this.HighSpeedEffectHandles.Clear();
	}

	// Token: 0x06007478 RID: 29816 RVA: 0x001E83BC File Offset: 0x001E65BC
	private void SpawnFeverEffect()
	{
		if (this.ShipActor == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.RhythmGame, ELogAuthor.CH, "[RhythmGameShipController] ShipActor is null", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		if (this.FeverEffectHandles.Count > 0)
		{
			return;
		}
		foreach (string effectPath in RhythmGameModelDefine.RhythmGameFeverEffect)
		{
			this.FeverEffectHandles.Add(this.SpawnAttachedEffect(effectPath, "[RhythmGameShipController] Spawn Fever Effect", this.ShipActor.SkeletalMesh, null, null));
		}
	}

	// Token: 0x06007479 RID: 29817 RVA: 0x001E8464 File Offset: 0x001E6664
	private void StopFeverEffect()
	{
		foreach (int handle in this.FeverEffectHandles)
		{
			Singleton<EffectSystem>.Instance.StopEffectById(handle, "[RhythmGameShipController] Stop Fever Effect", false, null);
		}
		this.FeverEffectHandles.Clear();
	}

	// Token: 0x0600747A RID: 29818 RVA: 0x001E84D8 File Offset: 0x001E66D8
	private void SpawnFireworksEffect()
	{
		if (this.ShipActor == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.RhythmGame, ELogAuthor.CH, "[RhythmGameShipController] ShipActor is null", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		if (this.FireworksEffectHandle != -1)
		{
			return;
		}
		TsGameSplineActor splineActor = ControllerBase<RhythmGameController>.Instance.GetSplineActor();
		if (splineActor == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.RhythmGame, ELogAuthor.CH, "[RhythmGameShipController] SplineActor is null", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		USplineComponent curSplineComponent = ModelBase<RhythmGameModel>.Instance.CurSplineComponent;
		float currentSplineDistance = ControllerBase<RhythmGameController>.Instance.GetRhythmGameShipController().GetCurrentSplineDistance();
		FVectorDouble fvectorDouble = (curSplineComponent != null) ? curSplineComponent.D_GetLocationAtDistanceAlongSpline(currentSplineDistance, ESplineCoordinateSpace.World) : new FVectorDouble();
		FTransformDouble value = new FTransformDouble();
		value.SetLocation(fvectorDouble);
		FQuat fquat = ((curSplineComponent != null) ? curSplineComponent.GetRotationAtDistanceAlongSpline(currentSplineDistance, ESplineCoordinateSpace.World) : new FRotator()).Quaternion();
		value.SetRotation(fquat);
		EffectSystem instance = Singleton<EffectSystem>.Instance;
		UObject world = GlobalData.World;
		FTransformDouble? ftransformDouble = new FTransformDouble?(value);
		this.FireworksEffectHandle = instance.SpawnEffect(world, ftransformDouble, "/Game/Aki/Effect/EffectGroup/Scenes/3_2/3_2YinYou/DA_Fx_Group_Sparks.DA_Fx_Group_Sparks", "[RhythmGameShipController] Spawn Fireworks Effect", null, EEffectType.Scene, null, null, null, false, false);
		OneOf<KuroEffectActorHandle, AActor> effectActor = Singleton<EffectSystem>.Instance.GetEffectActor(this.FireworksEffectHandle);
		AActor parent = splineActor;
		FName? fname = null;
		effectActor.K2_AttachToActor(parent, fname, EAttachmentRule.KeepWorld, EAttachmentRule.KeepWorld, EAttachmentRule.KeepWorld, false);
		Singleton<AudioSystem>.Instance.PostEvent("play_ui_rhythmship_gamefirework");
	}

	// Token: 0x0600747B RID: 29819 RVA: 0x001E8610 File Offset: 0x001E6810
	private void StopFireworksEffect()
	{
		if (this.FireworksEffectHandle != -1)
		{
			Singleton<EffectSystem>.Instance.StopEffectById(this.FireworksEffectHandle, "[RhythmGameShipController] Stop Fireworks Effect", false, null);
			this.FireworksEffectHandle = -1;
		}
	}

	// Token: 0x0600747C RID: 29820 RVA: 0x001E8650 File Offset: 0x001E6850
	private void SpawnSparksLineEffect()
	{
		if (this.ShipActor == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.RhythmGame, ELogAuthor.CH, "[RhythmGameShipController] ShipActor is null", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		if (this.SparksLineEffectHandle != -1)
		{
			return;
		}
		TsGameSplineActor splineActor = ControllerBase<RhythmGameController>.Instance.GetSplineActor();
		if (splineActor == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.RhythmGame, ELogAuthor.CH, "[RhythmGameShipController] SplineActor is null", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		USplineComponent curSplineComponent = ModelBase<RhythmGameModel>.Instance.CurSplineComponent;
		float currentSplineDistance = ControllerBase<RhythmGameController>.Instance.GetRhythmGameShipController().GetCurrentSplineDistance();
		FVectorDouble fvectorDouble = (curSplineComponent != null) ? curSplineComponent.D_GetLocationAtDistanceAlongSpline(currentSplineDistance, ESplineCoordinateSpace.World) : new FVectorDouble();
		FTransformDouble value = new FTransformDouble();
		value.SetLocation(fvectorDouble);
		FQuat fquat = ((curSplineComponent != null) ? curSplineComponent.GetRotationAtDistanceAlongSpline(currentSplineDistance, ESplineCoordinateSpace.World) : new FRotator()).Quaternion();
		value.SetRotation(fquat);
		EffectSystem instance = Singleton<EffectSystem>.Instance;
		UObject world = GlobalData.World;
		FTransformDouble? ftransformDouble = new FTransformDouble?(value);
		this.SparksLineEffectHandle = instance.SpawnEffect(world, ftransformDouble, "/Game/Aki/Effect/EffectGroup/Scenes/3_2/3_2YinYou/DA_Fx_Group_SparkLine.DA_Fx_Group_SparkLine", "[RhythmGameShipController] Spawn Sparks Line Effect", null, EEffectType.Scene, null, null, null, false, false);
		OneOf<KuroEffectActorHandle, AActor> effectActor = Singleton<EffectSystem>.Instance.GetEffectActor(this.SparksLineEffectHandle);
		AActor parent = splineActor;
		FName? fname = null;
		effectActor.K2_AttachToActor(parent, fname, EAttachmentRule.KeepWorld, EAttachmentRule.KeepWorld, EAttachmentRule.KeepWorld, false);
	}

	// Token: 0x0600747D RID: 29821 RVA: 0x001E8778 File Offset: 0x001E6978
	private void StopSparksLineEffect()
	{
		if (this.SparksLineEffectHandle != -1)
		{
			Singleton<EffectSystem>.Instance.StopEffectById(this.SparksLineEffectHandle, "[RhythmGameShipController] Stop Sparks Line Effect", false, null);
			this.SparksLineEffectHandle = -1;
		}
	}

	// Token: 0x0600747E RID: 29822 RVA: 0x001E87B8 File Offset: 0x001E69B8
	public void SpawnLockIcon()
	{
		if (this.ShipActor == null)
		{
			return;
		}
		if (this.LockIconEffectHandles.Count > 0)
		{
			return;
		}
		for (int i = 0; i < 2; i++)
		{
			string effectPath = RhythmGameModelDefine.RhythmGameLockIconEffect[i];
			this.LockIconEffectHandles.Add(this.SpawnAttachedEffect(effectPath, "[RhythmGameShipController] Spawn Lock Icon", this.ShipActor.SkeletalMesh, null, delegate([Nullable(new byte[]
			{
				0,
				1,
				1
			})] OneOf<KuroEffectActorHandle, AActor> actor)
			{
				FTransformDouble ftransformDouble = this.ShipActor.SkeletalMesh.D_GetRelativeTransform().Inverse();
				FQuat fquat = new FRotator(0f, 0f, 0f).Quaternion();
				ftransformDouble.SetRotation(fquat);
				FHitResult fhitResult = new FHitResult();
				actor.D_K2_SetActorRelativeTransform(ftransformDouble, false, ref fhitResult, false);
			}));
		}
	}

	// Token: 0x0600747F RID: 29823 RVA: 0x001E882C File Offset: 0x001E6A2C
	public void StopLockIconEffect()
	{
		foreach (int handle in this.LockIconEffectHandles)
		{
			Singleton<EffectSystem>.Instance.StopEffectById(handle, "[RhythmGameShipController] Stop Lock Icon Effect", false, null);
		}
		this.LockIconEffectHandles.Clear();
	}

	// Token: 0x06007480 RID: 29824 RVA: 0x001E88A0 File Offset: 0x001E6AA0
	public void TriggerTunnelTranslationAnim(bool isLeft)
	{
		if (this.ShipAnimInstance == null)
		{
			return;
		}
		if (isLeft)
		{
			this.ShipAnimInstance.InputSwingL = true;
			TimerSystem.Instance.Delay(delegate(float _)
			{
				this.ShipAnimInstance.InputSwingL = false;
			}, 20f, null, null, true, 1f);
			return;
		}
		this.ShipAnimInstance.InputSwingR = true;
		TimerSystem.Instance.Delay(delegate(float _)
		{
			this.ShipAnimInstance.InputSwingR = false;
		}, 20f, null, null, true, 1f);
	}

	// Token: 0x06007481 RID: 29825 RVA: 0x001E891C File Offset: 0x001E6B1C
	public void TriggerHitLockEffect()
	{
		if (this.ShipActor == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.RhythmGame, ELogAuthor.CH, "[RhythmGameShipController] ShipActor is null", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		if (this.LockIconEffectHandles.Count == 0)
		{
			Singleton<Log>.Instance.Info(ELogModule.RhythmGame, ELogAuthor.CH, "[RhythmGameShipController] LockIconEffectHandles is empty, no need to trigger hit lock effect", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		string text = RhythmGameModelDefine.RhythmGameLockIconEffect[2];
		if (text == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.RhythmGame, ELogAuthor.CH, "[RhythmGameShipController] HitLockEffect is null", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		if (this.DestroyHitLockEffectHandle != null)
		{
			TimerSystem.Instance.Remove(this.DestroyHitLockEffectHandle);
			this.DestroyHitLockEffectHandle = null;
		}
		if (this.HitLockEffectHandle != -1)
		{
			this.StopEffect(this.HitLockEffectHandle, "[RhythmGameShipController] Trigger Hit Lock Effect");
			this.HitLockEffectHandle = -1;
		}
		this.HitLockEffectHandle = this.SpawnAttachedEffect(text, "[RhythmGameShipController] Trigger Hit Lock Effect", this.ShipActor.SkeletalMesh, null, delegate([Nullable(new byte[]
		{
			0,
			1,
			1
		})] OneOf<KuroEffectActorHandle, AActor> actor)
		{
			FTransformDouble ftransformDouble = this.ShipActor.SkeletalMesh.D_GetRelativeTransform().Inverse();
			FQuat fquat = new FRotator(0f, 0f, 0f).Quaternion();
			ftransformDouble.SetRotation(fquat);
			FHitResult fhitResult = new FHitResult();
			actor.D_K2_SetActorRelativeTransform(ftransformDouble, false, ref fhitResult, false);
		});
		this.DestroyHitLockEffectHandle = TimerSystem.Instance.Delay(delegate(float _)
		{
			if (this.HitLockEffectHandle != -1)
			{
				Singleton<EffectSystem>.Instance.StopEffectById(this.HitLockEffectHandle, "[RhythmGameShipController] Destroy Hit Lock Effect", false, null);
				this.HitLockEffectHandle = -1;
			}
			this.DestroyHitLockEffectHandle = null;
		}, 500f, null, null, true, 1f);
	}

	// Token: 0x06007482 RID: 29826 RVA: 0x001E8A4C File Offset: 0x001E6C4C
	public void TriggerTranslationAnim(bool isLeft)
	{
		if (this.ShipAnimInstance == null)
		{
			return;
		}
		if (isLeft)
		{
			this.ShipAnimInstance.InputMoveL = true;
			this.ShipAnimInstance.Horzontal = -1f;
			TimerSystem.Instance.Delay(delegate(float _)
			{
				this.ShipAnimInstance.InputMoveL = false;
			}, 20f, null, null, true, 1f);
			return;
		}
		this.ShipAnimInstance.InputMoveR = true;
		this.ShipAnimInstance.Horzontal = 1f;
		TimerSystem.Instance.Delay(delegate(float _)
		{
			this.ShipAnimInstance.InputMoveR = false;
		}, 20f, null, null, true, 1f);
	}

	// Token: 0x06007483 RID: 29827 RVA: 0x001E8AE8 File Offset: 0x001E6CE8
	public void TriggerRollAnim(bool isLeft)
	{
		if (this.ShipAnimInstance == null)
		{
			return;
		}
		if (isLeft)
		{
			this.ShipAnimInstance.InputRollL = true;
			TimerSystem.Instance.Delay(delegate(float _)
			{
				this.ShipAnimInstance.InputRollL = false;
			}, 20f, null, null, true, 1f);
			return;
		}
		this.ShipAnimInstance.InputRollR = true;
		TimerSystem.Instance.Delay(delegate(float _)
		{
			this.ShipAnimInstance.InputRollR = false;
		}, 20f, null, null, true, 1f);
	}

	// Token: 0x06007484 RID: 29828 RVA: 0x001E8B64 File Offset: 0x001E6D64
	public void TriggerLineHit()
	{
		if (this.ShipAnimInstance == null)
		{
			return;
		}
		if (this.LineHitIsL3)
		{
			this.ShipAnimInstance.InputRollL3 = true;
			TimerSystem.Instance.Delay(delegate(float _)
			{
				this.ShipAnimInstance.InputRollL3 = false;
			}, 20f, null, null, true, 1f);
		}
		else
		{
			this.ShipAnimInstance.InputRollR3 = true;
			TimerSystem.Instance.Delay(delegate(float _)
			{
				this.ShipAnimInstance.InputRollR3 = false;
			}, 20f, null, null, true, 1f);
		}
		this.LineHitIsL3 = !this.LineHitIsL3;
	}

	// Token: 0x06007485 RID: 29829 RVA: 0x001E8BF4 File Offset: 0x001E6DF4
	public void TriggerJumpAnim()
	{
		if (this.ShipAnimInstance == null)
		{
			return;
		}
		this.ShipAnimInstance.InputJump = true;
		TimerSystem.Instance.Delay(delegate(float _)
		{
			this.ShipAnimInstance.InputJump = false;
		}, 20f, null, null, true, 1f);
		TimerSystem.Instance.Delay(delegate(float _)
		{
			this.ShipAnimInstance.Horzontal = 0f;
		}, (float)ControllerBase<RhythmGameController>.Instance.GetCurrentBeatDurationMs(), null, null, true, 1f);
	}

	// Token: 0x06007486 RID: 29830 RVA: 0x001E8C64 File Offset: 0x001E6E64
	public void SpawnStartTrailEffect()
	{
		if (this.ShipActor == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.RhythmGame, ELogAuthor.CH, "[RhythmGameShipController] ShipActor is null", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		if (this.SparksLineEffectHandle != -1)
		{
			return;
		}
		TsGameSplineActor splineActor = ControllerBase<RhythmGameController>.Instance.GetSplineActor();
		if (splineActor == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.RhythmGame, ELogAuthor.CH, "[RhythmGameShipController] SplineActor is null", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		USplineComponent curSplineComponent = ModelBase<RhythmGameModel>.Instance.CurSplineComponent;
		float currentSplineDistance = ControllerBase<RhythmGameController>.Instance.GetRhythmGameShipController().GetCurrentSplineDistance();
		FVectorDouble fvectorDouble = (curSplineComponent != null) ? curSplineComponent.D_GetLocationAtDistanceAlongSpline(currentSplineDistance, ESplineCoordinateSpace.World) : new FVectorDouble();
		FTransformDouble value = new FTransformDouble();
		value.SetLocation(fvectorDouble);
		FQuat fquat = ((curSplineComponent != null) ? curSplineComponent.GetRotationAtDistanceAlongSpline(currentSplineDistance, ESplineCoordinateSpace.World) : new FRotator()).Quaternion();
		value.SetRotation(fquat);
		EffectSystem instance = Singleton<EffectSystem>.Instance;
		UObject world = GlobalData.World;
		FTransformDouble? ftransformDouble = new FTransformDouble?(value);
		int id = instance.SpawnEffect(world, ftransformDouble, "/Game/Aki/Effect/EffectGroup/Scenes/3_2/3_2YinYou/DA_Fx_Group_StartTrail.DA_Fx_Group_StartTrail", "[RhythmGameShipController] Spawn Start Trail Effect", null, EEffectType.Scene, null, null, null, false, false);
		OneOf<KuroEffectActorHandle, AActor> effectActor = Singleton<EffectSystem>.Instance.GetEffectActor(id);
		AActor parent = splineActor;
		FName? fname = null;
		effectActor.K2_AttachToActor(parent, fname, EAttachmentRule.KeepWorld, EAttachmentRule.KeepWorld, EAttachmentRule.KeepWorld, false);
	}

	// Token: 0x04003834 RID: 14388
	[Nullable(2)]
	private BP_Plane_C ShipActor;

	// Token: 0x04003835 RID: 14389
	[Nullable(2)]
	private ABP_Plane_C ShipAnimInstance;

	// Token: 0x04003836 RID: 14390
	private int FireEffectHandle = -1;

	// Token: 0x04003837 RID: 14391
	private bool LineHitIsL3 = true;

	// Token: 0x04003838 RID: 14392
	private readonly List<int> LockIconEffectHandles = new List<int>();

	// Token: 0x04003839 RID: 14393
	private int HitLockEffectHandle = -1;

	// Token: 0x0400383A RID: 14394
	[Nullable(2)]
	private TimerHandle DestroyHitLockEffectHandle;

	// Token: 0x0400383B RID: 14395
	private readonly List<int> HighSpeedEffectHandles = new List<int>();

	// Token: 0x0400383C RID: 14396
	private readonly List<int> FeverEffectHandles = new List<int>();

	// Token: 0x0400383D RID: 14397
	private int FireworksEffectHandle = -1;

	// Token: 0x0400383E RID: 14398
	private int SparksLineEffectHandle = -1;
}
