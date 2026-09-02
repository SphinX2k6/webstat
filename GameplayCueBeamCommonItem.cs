using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02002F91 RID: 12177
[NullableContext(1)]
[Nullable(0)]
public class GameplayCueBeamCommonItem
{
	// Token: 0x06018D69 RID: 101737 RVA: 0x00708761 File Offset: 0x00706961
	private GameplayCueBeamCommonItem(ABaseCharacter owner, string path)
	{
		this.Owner = owner;
		this.Path = path;
	}

	// Token: 0x06018D6A RID: 101738 RVA: 0x00708777 File Offset: 0x00706977
	public static GameplayCueBeamCommonItem Spawn(ABaseCharacter owner, string path, [Nullable(new byte[]
	{
		2,
		1
	})] Action<UNiagaraComponent> onNiagaraReady = null)
	{
		GameplayCueBeamCommonItem gameplayCueBeamCommonItem = new GameplayCueBeamCommonItem(owner, path);
		gameplayCueBeamCommonItem.IsActive = true;
		gameplayCueBeamCommonItem.OnNiagaraReady = onNiagaraReady;
		gameplayCueBeamCommonItem.SplineInternal = gameplayCueBeamCommonItem.SpawnBeamActor();
		return gameplayCueBeamCommonItem;
	}

	// Token: 0x06018D6B RID: 101739 RVA: 0x0070879C File Offset: 0x0070699C
	public void Tick(FVectorDouble[] points, float delta)
	{
		this.CurrentPoints = points;
		this.SplineInternal.GetOwner().D_K2_SetActorLocation(this.Owner.D_K2_GetActorLocation(), false, ref WorldGlobal.SweepHitResult, true);
		int num = points.Length;
		if (num != this.CurrentSplinePointCount)
		{
			this.RefreshSplinePoints(num);
		}
		for (int i = 0; i < num; i++)
		{
			this.SplineInternal.D_SetLocationAtSplinePoint(i, points[i], ESplineCoordinateSpace.World, true);
		}
	}

	// Token: 0x06018D6C RID: 101740 RVA: 0x00708808 File Offset: 0x00706A08
	public void Destroy()
	{
		this.IsActive = false;
		USplineComponent splineInternal = this.SplineInternal;
		AActor aactor = (splineInternal != null) ? splineInternal.GetOwner() : null;
		if (aactor != null)
		{
			Singleton<ActorSystem>.Instance.Put("GameplayCueBeamCommonItem.Destroy", aactor, null);
		}
	}

	// Token: 0x06018D6D RID: 101741 RVA: 0x00708844 File Offset: 0x00706A44
	public AActor GetOwner()
	{
		return this.SplineInternal.GetOwner();
	}

	// Token: 0x06018D6E RID: 101742 RVA: 0x00708854 File Offset: 0x00706A54
	private USplineComponent SpawnBeamActor()
	{
		AActor actor = Singleton<ActorSystem>.Instance.Get(AActor.StaticClass(), this.Owner.D_GetTransform(), null, true);
		USplineComponent splineComponent = actor.AddComponentByClass(USplineComponent.StaticClass(), false, Singleton<MathUtils>.Instance.DefaultTransform, false, default(FName)) as USplineComponent;
		splineComponent.ClearSplinePoints(true);
		Singleton<ResourceSystem>.Instance.LoadAsync<UNiagaraSystem>(this.Path, delegate([Nullable(2)] UNiagaraSystem effectObject, string _)
		{
			if (this.IsActive && effectObject != null && effectObject.IsValid())
			{
				AActor actor = actor;
				if (actor != null && actor.IsValid())
				{
					UNiagaraComponent uniagaraComponent = actor.AddComponentByClass(UNiagaraComponent.StaticClass(), false, Singleton<MathUtils>.Instance.DefaultTransform, false, default(FName)) as UNiagaraComponent;
					if (uniagaraComponent == null)
					{
						return;
					}
					uniagaraComponent.SetAsset(effectObject, true);
					Action<UNiagaraComponent> onNiagaraReady = this.OnNiagaraReady;
					if (onNiagaraReady != null)
					{
						onNiagaraReady(uniagaraComponent);
					}
					UKuroRenderingRuntimeBPPluginBPLibrary.SetNiagaraSplineComponent(uniagaraComponent, "NewSpline", splineComponent);
					return;
				}
			}
		}, 100, "js_undefined");
		return splineComponent;
	}

	// Token: 0x06018D6F RID: 101743 RVA: 0x007088FC File Offset: 0x00706AFC
	private void RefreshSplinePoints(int newSplinePointCount)
	{
		if (newSplinePointCount > this.CurrentSplinePointCount)
		{
			for (int i = 0; i < newSplinePointCount - this.CurrentSplinePointCount; i++)
			{
				FSplinePoint fsplinePoint = new FSplinePoint((float)(this.CurrentSplinePointCount + i), Vector.ZeroVector, Vector.ZeroVector, Vector.ZeroVector, Rotator.ZeroRotator, Vector.OneVector, ESplinePointType.Linear);
				this.SplineInternal.AddPoint(fsplinePoint, true);
			}
		}
		else
		{
			for (int j = this.CurrentSplinePointCount - 1; j >= newSplinePointCount; j--)
			{
				this.SplineInternal.RemoveSplinePoint(j, true);
			}
		}
		this.CurrentSplinePointCount = newSplinePointCount;
	}

	// Token: 0x0400C1E6 RID: 49638
	[Nullable(2)]
	private USplineComponent SplineInternal;

	// Token: 0x0400C1E7 RID: 49639
	private int CurrentSplinePointCount;

	// Token: 0x0400C1E8 RID: 49640
	private bool IsActive;

	// Token: 0x0400C1E9 RID: 49641
	[Nullable(2)]
	public FVectorDouble[] CurrentPoints;

	// Token: 0x0400C1EA RID: 49642
	private readonly ABaseCharacter Owner;

	// Token: 0x0400C1EB RID: 49643
	public readonly string Path;

	// Token: 0x0400C1EC RID: 49644
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Action<UNiagaraComponent> OnNiagaraReady;
}
