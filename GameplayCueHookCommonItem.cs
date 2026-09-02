using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Effect;
using CSharpScript.Game.Utils;
using UnrealEngine;

// Token: 0x02002F93 RID: 12179
[NullableContext(1)]
[Nullable(0)]
public class GameplayCueHookCommonItem
{
	// Token: 0x06018D76 RID: 101750 RVA: 0x00708B8D File Offset: 0x00706D8D
	private GameplayCueHookCommonItem(ABaseCharacter owner, FName socket, FVectorDouble targetPosition, string[] paths)
	{
		this.Owner = owner;
		this.Socket = socket;
		this.TargetPosition = targetPosition;
		this.Paths = paths;
	}

	// Token: 0x06018D77 RID: 101751 RVA: 0x00708BB2 File Offset: 0x00706DB2
	public static GameplayCueHookCommonItem Spawn(ABaseCharacter owner, FName socket, FVectorDouble targetPosition, string[] paths, bool lineAttach = true)
	{
		GameplayCueHookCommonItem gameplayCueHookCommonItem = new GameplayCueHookCommonItem(owner, socket, targetPosition, paths);
		gameplayCueHookCommonItem.IsActive = true;
		gameplayCueHookCommonItem.HookActor = gameplayCueHookCommonItem.SpawnHookActor(lineAttach);
		gameplayCueHookCommonItem.EffectViewHandle = gameplayCueHookCommonItem.CreateBallEffect();
		return gameplayCueHookCommonItem;
	}

	// Token: 0x06018D78 RID: 101752 RVA: 0x00708BE0 File Offset: 0x00706DE0
	public void Destroy()
	{
		this.IsActive = false;
		this.NiagaraComp = null;
		Singleton<ActorSystem>.Instance.Put("GameplayCueHookCommonItem.Destroy", this.HookActor, null);
		if (Singleton<EffectSystem>.Instance.IsValid(this.EffectViewHandle))
		{
			Singleton<EffectSystem>.Instance.StopEffectById(this.EffectViewHandle, "[GameplayCueHookCommonItem.Destroy]", true, null);
		}
		this.DestroyBallEffect();
	}

	// Token: 0x06018D79 RID: 101753 RVA: 0x00708C4C File Offset: 0x00706E4C
	public void Tick(FVectorDouble position)
	{
		this.TargetPosition.Set(position.X, position.Y, position.Z);
		if (Singleton<EffectSystem>.Instance.IsValid(this.EffectViewHandle))
		{
			Singleton<EffectSystem>.Instance.GetEffectActor(this.EffectViewHandle).D_K2_SetActorLocation(position, false, ref WorldGlobal.SweepHitResult, true);
		}
		FVector inValue = UKismetMathLibrary.WD_WorldToLocal(GlobalData.World, position);
		UNiagaraComponent niagaraComp = this.NiagaraComp;
		if (niagaraComp == null)
		{
			return;
		}
		niagaraComp.SetNiagaraVariableVec3("end", inValue);
	}

	// Token: 0x06018D7A RID: 101754 RVA: 0x00708CCC File Offset: 0x00706ECC
	private AActor SpawnHookActor(bool needAttach = true)
	{
		AActor actor = Singleton<ActorSystem>.Instance.Get(AActor.StaticClass(), this.Owner.D_GetTransform(), null, true);
		TTimerAction <>9__1;
		Singleton<ResourceSystem>.Instance.LoadAsync<UNiagaraSystem>(this.Paths[0], delegate([Nullable(2)] UNiagaraSystem effectObject, string _)
		{
			if (this.IsActive && effectObject != null && effectObject.IsValid())
			{
				AActor actor = actor;
				if (actor != null && actor.IsValid())
				{
					this.NiagaraComp = (actor.AddComponentByClass(UNiagaraComponent.StaticClass(), false, Singleton<MathUtils>.Instance.DefaultTransform, false, default(FName)) as UNiagaraComponent);
					this.NiagaraComp.SetAsset(effectObject, true);
					this.NiagaraComp.SetRenderInBurst(true);
					FVector inValue = UKismetMathLibrary.WD_WorldToLocal(GlobalData.World, this.TargetPosition);
					this.NiagaraComp.SetNiagaraVariableVec3("end", inValue);
					TimerSystemInstance instance = TimerSystem.Instance;
					TTimerAction action;
					if ((action = <>9__1) == null)
					{
						action = (<>9__1 = delegate(float _)
						{
							UKuroEffectLibrary.SetNiagaraSimulationMinDeltaTime(this.NiagaraComp, -1f);
						});
					}
					instance.Next(action, null, null);
					if (needAttach)
					{
						actor.K2_AttachToComponent(this.Owner.Mesh, this.Socket, EAttachmentRule.SnapToTarget, EAttachmentRule.SnapToTarget, EAttachmentRule.SnapToTarget, false, true);
						return;
					}
					USkeletalMeshComponent mesh = this.Owner.Mesh;
					FTransformDouble ftransformDouble = (mesh != null) ? mesh.D_GetSocketTransform(this.Socket, ERelativeTransformSpace.RTS_World) : this.Owner.D_GetTransform();
					actor.D_K2_SetActorTransform(ftransformDouble, false, null, false);
					return;
				}
			}
		}, 100, "js_undefined");
		return actor;
	}

	// Token: 0x06018D7B RID: 101755 RVA: 0x00708D3C File Offset: 0x00706F3C
	private int CreateBallEffect()
	{
		if (this.Paths.Length < 2)
		{
			return 0;
		}
		ABaseCharacter owner = this.Owner;
		TsBaseCharacter tsBaseCharacter = owner as TsBaseCharacter;
		int entityId;
		if (tsBaseCharacter == null)
		{
			TsBaseVehicle tsBaseVehicle = owner as TsBaseVehicle;
			if (tsBaseVehicle == null)
			{
				<PrivateImplementationDetails>.ThrowSwitchExpressionException(owner);
			}
			else
			{
				entityId = tsBaseVehicle.EntityId;
			}
		}
		else
		{
			entityId = tsBaseCharacter.EntityId;
		}
		int num = entityId;
		EffectSystem instance = Singleton<EffectSystem>.Instance;
		UObject owner2 = this.Owner;
		FTransformDouble? ftransformDouble = new FTransformDouble?(new FTransformDouble(ref this.TargetPosition));
		int num2 = instance.SpawnEffect(owner2, ftransformDouble, this.Paths[1], "[GameplayCueHookCommonItem.CreateBallEffect]", new EffectContext(new int?(num), null, false), EEffectType.Fight, null, null, null, false, false);
		EffectUtil.SetAdditionalEffectTimeScaleByEntity(ModelBase<CreatureModel>.Instance.GetEntityById(num), num2);
		return num2;
	}

	// Token: 0x06018D7C RID: 101756 RVA: 0x00708DEC File Offset: 0x00706FEC
	private void DestroyBallEffect()
	{
		if (this.Paths.Length < 3)
		{
			return;
		}
		ABaseCharacter owner = this.Owner;
		TsBaseCharacter tsBaseCharacter = owner as TsBaseCharacter;
		int entityId;
		if (tsBaseCharacter == null)
		{
			TsBaseVehicle tsBaseVehicle = owner as TsBaseVehicle;
			if (tsBaseVehicle == null)
			{
				<PrivateImplementationDetails>.ThrowSwitchExpressionException(owner);
			}
			else
			{
				entityId = tsBaseVehicle.EntityId;
			}
		}
		else
		{
			entityId = tsBaseCharacter.EntityId;
		}
		int num = entityId;
		EffectSystem instance = Singleton<EffectSystem>.Instance;
		UObject owner2 = this.Owner;
		FTransformDouble? ftransformDouble = new FTransformDouble?(new FTransformDouble(ref this.TargetPosition));
		int effectId = instance.SpawnEffect(owner2, ftransformDouble, this.Paths[2], "[GameplayCueHookCommonItem.DestroyBallEffect]", new EffectContext(new int?(num), null, false), EEffectType.Fight, null, null, null, false, false);
		EffectUtil.SetAdditionalEffectTimeScaleByEntity(ModelBase<CreatureModel>.Instance.GetEntityById(num), effectId);
	}

	// Token: 0x0400C1F3 RID: 49651
	[Nullable(2)]
	private AActor HookActor;

	// Token: 0x0400C1F4 RID: 49652
	private int EffectViewHandle;

	// Token: 0x0400C1F5 RID: 49653
	private bool IsActive;

	// Token: 0x0400C1F6 RID: 49654
	[Nullable(2)]
	private UNiagaraComponent NiagaraComp;

	// Token: 0x0400C1F7 RID: 49655
	private readonly ABaseCharacter Owner;

	// Token: 0x0400C1F8 RID: 49656
	private readonly FName Socket;

	// Token: 0x0400C1F9 RID: 49657
	public FVectorDouble TargetPosition;

	// Token: 0x0400C1FA RID: 49658
	public readonly string[] Paths;
}
