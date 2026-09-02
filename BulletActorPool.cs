using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02002D97 RID: 11671
[NullableContext(1)]
[Nullable(0)]
public static class BulletActorPool
{
	// Token: 0x06017875 RID: 96373 RVA: 0x0068B174 File Offset: 0x00689374
	public static AKuroEntityActor Get(EBulletShape shape)
	{
		AKuroEntityActor akuroEntityActor = null;
		if (BulletActorPool.ActorPool.ContainsKey(shape))
		{
			List<AKuroEntityActor> list = BulletActorPool.ActorPool[shape];
			while (akuroEntityActor == null && list.Count > 0)
			{
				akuroEntityActor = list[list.Count - 1];
				list.RemoveAt(list.Count - 1);
				if (akuroEntityActor == null || !akuroEntityActor.IsValid())
				{
					akuroEntityActor = null;
				}
			}
		}
		if (akuroEntityActor == null)
		{
			akuroEntityActor = (Singleton<ActorSystem>.Instance.Get(AKuroEntityActor.StaticClass(), Singleton<MathUtils>.Instance.DefaultTransformDouble, null, true) as AKuroEntityActor);
			if (((akuroEntityActor != null) ? akuroEntityActor.GetComponentByClass(USceneComponent.StaticClass()) : null) == null)
			{
				akuroEntityActor.AddComponentByClass(USceneComponent.StaticClass(), false, Singleton<MathUtils>.Instance.DefaultTransform, false, default(FName));
			}
			akuroEntityActor.bAutoDestroyWhenFinished = false;
			akuroEntityActor.SetActorEnableCollision(false);
		}
		return akuroEntityActor;
	}

	// Token: 0x06017876 RID: 96374 RVA: 0x0068B248 File Offset: 0x00689448
	public static void Recycle(AKuroEntityActor actor, EBulletShape shape, bool needDetach = false)
	{
		actor.SetActorHiddenInGame(true);
		actor.SetActorEnableCollision(false);
		if (needDetach)
		{
			actor.K2_DetachFromActor(EDetachmentRule.KeepWorld, EDetachmentRule.KeepWorld, EDetachmentRule.KeepWorld);
			actor.D_SetActorScale3D(Vector.OneVectorDouble);
		}
		if (Singleton<BulletConstant>.Instance.OpenActorRecycleCheck)
		{
			if (actor.D_GetActorScale3D() != Vector.OneVectorDouble)
			{
				Singleton<Log>.Instance.Error(ELogModule.Bullet, ELogAuthor.CFT, "bullet actor scale invalid", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			UShapeComponent ushapeComponent = actor.GetComponentByClass(UShapeComponent.StaticClass()) as UShapeComponent;
			if (ushapeComponent != null && ushapeComponent.RelativeScale3D != Vector.OneVector)
			{
				Singleton<Log>.Instance.Error(ELogModule.Bullet, ELogAuthor.CFT, "bullet collisionComp scale invalid", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
		}
		List<AKuroEntityActor> list;
		if (!BulletActorPool.ActorPool.TryGetValue(shape, out list))
		{
			list = new List<AKuroEntityActor>();
			BulletActorPool.ActorPool.Add(shape, list);
		}
		if (list.Count > 30)
		{
			Singleton<ActorSystem>.Instance.Put("BulletActorPool.Recycle", actor, null);
			return;
		}
		list.Add(actor);
	}

	// Token: 0x06017877 RID: 96375 RVA: 0x0068B340 File Offset: 0x00689540
	public static void Preload()
	{
		BulletActorPool.PreloadByShape(EBulletShape.Cube, UBoxComponent.StaticClass());
		BulletActorPool.PreloadByShape(EBulletShape.Sphere, USphereComponent.StaticClass());
		BulletActorPool.PreloadByShape(EBulletShape.Cylinder, UBoxComponent.StaticClass());
		BulletActorPool.PreloadByShape(EBulletShape.Ray, default(UClassStackOnlyPtr));
	}

	// Token: 0x06017878 RID: 96376 RVA: 0x0068B380 File Offset: 0x00689580
	private static void PreloadByShape(EBulletShape shape, UClassStackOnlyPtr compClass)
	{
		List<AKuroEntityActor> list;
		if (!BulletActorPool.ActorPool.TryGetValue(shape, out list))
		{
			list = new List<AKuroEntityActor>();
			BulletActorPool.ActorPool.Add(shape, list);
		}
		for (int i = list.Count; i < 5; i++)
		{
			AKuroEntityActor akuroEntityActor = Singleton<ActorSystem>.Instance.Get(AKuroEntityActor.StaticClass(), Singleton<MathUtils>.Instance.DefaultTransformDouble, null, true) as AKuroEntityActor;
			if (((akuroEntityActor != null) ? akuroEntityActor.GetComponentByClass(USceneComponent.StaticClass()) : null) == null)
			{
				akuroEntityActor.AddComponentByClass(USceneComponent.StaticClass(), false, Singleton<MathUtils>.Instance.DefaultTransform, false, default(FName));
			}
			akuroEntityActor.bAutoDestroyWhenFinished = false;
			akuroEntityActor.SetActorHiddenInGame(true);
			akuroEntityActor.SetActorEnableCollision(false);
			if (compClass.IsValid())
			{
				if (GlobalData.IsPlayInEditor && Singleton<BulletConstant>.Instance.CollisionCompVisibleInEditor)
				{
					UActorComponent uactorComponent = akuroEntityActor.AddComponentByClass(compClass, false, Singleton<MathUtils>.Instance.DefaultTransform, true, default(FName));
					uactorComponent.CreationMethod = EComponentCreationMethod.Instance;
					akuroEntityActor.FinishAddComponent(uactorComponent, false, Singleton<MathUtils>.Instance.DefaultTransform);
				}
				else
				{
					akuroEntityActor.AddComponentByClass(compClass, false, Singleton<MathUtils>.Instance.DefaultTransform, false, default(FName));
				}
			}
			list.Add(akuroEntityActor);
		}
	}

	// Token: 0x06017879 RID: 96377 RVA: 0x0068B4C0 File Offset: 0x006896C0
	public static void Clear()
	{
		foreach (List<AKuroEntityActor> list in BulletActorPool.ActorPool.Values)
		{
			foreach (AKuroEntityActor actor in list)
			{
				Singleton<ActorSystem>.Instance.Put("BulletActorPool.Clear", actor, null);
			}
		}
		BulletActorPool.ActorPool.Clear();
	}

	// Token: 0x0400B486 RID: 46214
	private const int SIZE_POOL = 30;

	// Token: 0x0400B487 RID: 46215
	private const int PRE_ADD_COUNT = 5;

	// Token: 0x0400B488 RID: 46216
	[StaticVariableRuleIgnore]
	private static readonly Dictionary<EBulletShape, List<AKuroEntityActor>> ActorPool = new Dictionary<EBulletShape, List<AKuroEntityActor>>();
}
