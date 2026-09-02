using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Scene.KuroProjectilePathTracer;
using UnrealEngine;

// Token: 0x02003073 RID: 12403
[NullableContext(2)]
[Nullable(0)]
public class CharacterThrowComponent : EntityComponent
{
	// Token: 0x1700225D RID: 8797
	// (get) Token: 0x06019804 RID: 104452 RVA: 0x00762F70 File Offset: 0x00761170
	public BP_KuroProjectilePathTracer_C ProjectilePathTracer
	{
		get
		{
			if (this.ProjectilePathTracerInternal == null)
			{
				this.ProjectilePathTracerInternal = (Singleton<ActorSystem>.Instance.Get(BP_KuroProjectilePathTracer_C.StaticClass(), Singleton<MathUtils>.Instance.DefaultTransformDouble, null, true) as BP_KuroProjectilePathTracer_C);
			}
			return this.ProjectilePathTracerInternal;
		}
	}

	// Token: 0x06019805 RID: 104453 RVA: 0x00762FA6 File Offset: 0x007611A6
	[NullableContext(1)]
	public void SetPredictProjectileInfo(bool returnValue, ref TArray<FVector> outPathPosition, FVector outLastTraceDestination, FHitResult outHit)
	{
		BP_KuroProjectilePathTracer_C projectilePathTracer = this.ProjectilePathTracer;
		if (projectilePathTracer == null)
		{
			return;
		}
		projectilePathTracer.SetPredictProjectileInfo(returnValue, ref outPathPosition, outLastTraceDestination, outHit);
	}

	// Token: 0x06019806 RID: 104454 RVA: 0x00762FBD File Offset: 0x007611BD
	public void SetVisible(bool isShow)
	{
		BP_KuroProjectilePathTracer_C projectilePathTracer = this.ProjectilePathTracer;
		if (projectilePathTracer == null)
		{
			return;
		}
		projectilePathTracer.SetVisible(isShow);
	}

	// Token: 0x06019807 RID: 104455 RVA: 0x00762FD0 File Offset: 0x007611D0
	[NullableContext(1)]
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		CharacterThrowComponent characterThrowComponent = (CharacterThrowComponent)componentTemplate;
		if (base.CanResetComponentProperty("ProjectilePathTracerInternal"))
		{
			if (characterThrowComponent.ProjectilePathTracerInternal == null)
			{
				this.ProjectilePathTracerInternal = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BP_KuroProjectilePathTracer_C>(this.ProjectilePathTracerInternal), "ProjectilePathTracerInternal"))
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x0400CA60 RID: 51808
	private BP_KuroProjectilePathTracer_C ProjectilePathTracerInternal;
}
