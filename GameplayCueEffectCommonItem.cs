using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Effect;
using UnrealEngine;

// Token: 0x02002F92 RID: 12178
[NullableContext(1)]
[Nullable(0)]
public class GameplayCueEffectCommonItem
{
	// Token: 0x06018D70 RID: 101744 RVA: 0x0070898A File Offset: 0x00706B8A
	private GameplayCueEffectCommonItem(ABaseCharacter owner, FVectorDouble targetPosition, string[] paths)
	{
		this.Owner = owner;
		this.TargetPosition = targetPosition;
		this.Paths = paths;
	}

	// Token: 0x06018D71 RID: 101745 RVA: 0x007089B0 File Offset: 0x00706BB0
	[return: Nullable(2)]
	public static GameplayCueEffectCommonItem Spawn(ABaseCharacter owner, FVectorDouble targetPosition, string[] paths)
	{
		GameplayCueEffectCommonItem gameplayCueEffectCommonItem = new GameplayCueEffectCommonItem(owner, targetPosition, paths);
		int num = gameplayCueEffectCommonItem.CreateEffect();
		if (Singleton<EffectSystem>.Instance.IsValid(num))
		{
			gameplayCueEffectCommonItem.EffectViewHandle = num;
			gameplayCueEffectCommonItem.SetVisible(false);
			return gameplayCueEffectCommonItem;
		}
		return null;
	}

	// Token: 0x06018D72 RID: 101746 RVA: 0x007089EC File Offset: 0x00706BEC
	public void Destroy()
	{
		this.EffectActor.Clear();
		if (Singleton<EffectSystem>.Instance.IsValid(this.EffectViewHandle))
		{
			Singleton<EffectSystem>.Instance.StopEffectById(this.EffectViewHandle, "[GameplayCueEffectCommonItem.Destroy]", true, null);
		}
	}

	// Token: 0x06018D73 RID: 101747 RVA: 0x00708A38 File Offset: 0x00706C38
	[NullableContext(2)]
	public void Refresh(bool visible, Vector location = null, Rotator rotation = null)
	{
		this.SetVisible(visible);
		if (!visible)
		{
			return;
		}
		if (location != null && rotation != null)
		{
			OneOf<KuroEffectActorHandle, AActor> effectActor = this.EffectActor;
			FVectorDouble fvectorDouble = location.ToUeVector(false);
			FRotator frotator = rotation.ToUeRotator();
			effectActor.D_K2_SetActorLocationAndRotation(fvectorDouble, frotator, false, ref WorldGlobal.SweepHitResult, true);
			return;
		}
		if (location != null)
		{
			OneOf<KuroEffectActorHandle, AActor> effectActor2 = this.EffectActor;
			FVectorDouble fvectorDouble = location.ToUeVector(false);
			effectActor2.D_K2_SetActorLocation(fvectorDouble, false, ref WorldGlobal.SweepHitResult, true);
		}
		if (rotation != null)
		{
			OneOf<KuroEffectActorHandle, AActor> effectActor3 = this.EffectActor;
			FRotator frotator = rotation.ToUeRotator();
			effectActor3.K2_SetActorRotation(frotator, false);
		}
	}

	// Token: 0x06018D74 RID: 101748 RVA: 0x00708AB6 File Offset: 0x00706CB6
	public void SetVisible(bool visible)
	{
		if (this.IsVisible == visible)
		{
			return;
		}
		this.IsVisible = visible;
		this.EffectActor.SetActorHiddenInGame(!visible);
	}

	// Token: 0x06018D75 RID: 101749 RVA: 0x00708AD8 File Offset: 0x00706CD8
	private int CreateEffect()
	{
		if (this.Paths.Length == 0)
		{
			return 0;
		}
		EffectSystem instance = Singleton<EffectSystem>.Instance;
		UObject owner = this.Owner;
		FTransformDouble? ftransformDouble = new FTransformDouble?(new FTransformDouble(ref this.TargetPosition));
		string path = this.Paths[0];
		ABaseCharacter owner2 = this.Owner;
		TsBaseCharacter tsBaseCharacter = owner2 as TsBaseCharacter;
		int entityId;
		if (tsBaseCharacter == null)
		{
			TsBaseVehicle tsBaseVehicle = owner2 as TsBaseVehicle;
			if (tsBaseVehicle == null)
			{
				<PrivateImplementationDetails>.ThrowSwitchExpressionException(owner2);
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
		int num = instance.SpawnEffect(owner, ftransformDouble, path, "[GameplayCueEffectCommonItem.CreateEffect]", new EffectContext(new int?(entityId), null, false), EEffectType.Fight, null, null, null, false, false);
		this.EffectActor = Singleton<EffectSystem>.Instance.GetEffectActor(num);
		return num;
	}

	// Token: 0x0400C1ED RID: 49645
	private int EffectViewHandle;

	// Token: 0x0400C1EE RID: 49646
	[Nullable(new byte[]
	{
		0,
		1,
		1
	})]
	private OneOf<KuroEffectActorHandle, AActor> EffectActor;

	// Token: 0x0400C1EF RID: 49647
	private bool IsVisible = true;

	// Token: 0x0400C1F0 RID: 49648
	private readonly ABaseCharacter Owner;

	// Token: 0x0400C1F1 RID: 49649
	public readonly FVectorDouble TargetPosition;

	// Token: 0x0400C1F2 RID: 49650
	public readonly string[] Paths;
}
