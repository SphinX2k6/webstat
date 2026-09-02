using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.TypeScript.Game.NewWorld.Bullet.LogicDataClass;
using CSharpScript.Game.NewWorld.SceneItem.RefCompController;
using UnrealEngine;

// Token: 0x02002DCC RID: 11724
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1,
	1
})]
public class BulletLogicSpawnObstacles : BulletLogicController<LogicDataSpawnObstacles, object>
{
	// Token: 0x06017A20 RID: 96800 RVA: 0x00695176 File Offset: 0x00693376
	public BulletLogicSpawnObstacles(LogicDataSpawnObstacles data, Entity entity) : base(data, entity)
	{
	}

	// Token: 0x06017A21 RID: 96801 RVA: 0x00695180 File Offset: 0x00693380
	public override void OnInit()
	{
		LogicDataSpawnObstacles logicController = this.LogicController;
		FTransformDouble defaultTransformDouble = Singleton<MathUtils>.Instance.DefaultTransformDouble;
		this.Actor = Singleton<ActorSystem>.Instance.Get(AActor.StaticClass(), defaultTransformDouble, null, true);
		EBulletLogicObstacles model = logicController.Model;
		UPrimitiveComponent uprimitiveComponent = null;
		BulletInfo bulletInfo = this.Bullet.GetBulletInfo();
		if (model == EBulletLogicObstacles.圆柱)
		{
			UStaticMeshComponent ustaticMeshComponent = this.Actor.AddComponentByClass(UStaticMeshComponent.StaticClass(), false, Singleton<MathUtils>.Instance.DefaultTransform, true, default(FName)) as UStaticMeshComponent;
			ustaticMeshComponent.SetStaticMesh(logicController.Mesh);
			uprimitiveComponent = ustaticMeshComponent;
		}
		else if (model == EBulletLogicObstacles.长方体)
		{
			uprimitiveComponent = (this.Actor.AddComponentByClass(UBoxComponent.StaticClass(), false, Singleton<MathUtils>.Instance.DefaultTransform, true, default(FName)) as UBoxComponent);
		}
		if (uprimitiveComponent != null)
		{
			uprimitiveComponent.SetCollisionProfileName(logicController.ProfileName, false);
			uprimitiveComponent.bCanCharacterStandOn = logicController.CanStandOn;
			this.Actor.Tags.Add(Singleton<CharacterNameDefines>.Instance.NO_SLIDE);
			uprimitiveComponent.SetGenerateOverlapEvents(false);
			uprimitiveComponent.CreationMethod = EComponentCreationMethod.Instance;
			uprimitiveComponent.SetVisibility(logicController.ShowModel, false);
			this.Actor.FinishAddComponent(uprimitiveComponent, false, Singleton<MathUtils>.Instance.DefaultTransform);
			if (logicController.NeedAttach)
			{
				EAttachmentRule eattachmentRule = EAttachmentRule.SnapToTarget;
				this.Actor.K2_AttachToActor(bulletInfo.Actor, FNameUtil.NONE, eattachmentRule, eattachmentRule, EAttachmentRule.KeepWorld, false, true);
			}
			else
			{
				FHitResult fhitResult = null;
				AActor actor = this.Actor;
				FTransformDouble ftransformDouble = bulletInfo.Actor.D_GetTransform();
				actor.D_K2_SetActorTransform(ftransformDouble, false, ref fhitResult, true);
			}
			if (model == EBulletLogicObstacles.圆柱)
			{
				Vector vector = BulletPool.CreateVector(false);
				Vector vector2 = vector;
				FVector size = logicController.Size;
				vector2.FromUeVector(size);
				vector.MultiplyEqual(0.019999999552965164);
				uprimitiveComponent.D_SetRelativeScale3D(vector.ToUeVector(false));
				BulletPool.RecycleVector(vector);
			}
			else if (model == EBulletLogicObstacles.长方体)
			{
				(uprimitiveComponent as UBoxComponent).D_SetBoxExtent(UKismetMathLibrary.Conv_VectorToVectorDouble(logicController.Size), true);
			}
		}
		if (logicController.IsAirWall)
		{
			this.Actor.Tags.Add(RefCompAirWallController.AIR_WALL);
		}
	}

	// Token: 0x06017A22 RID: 96802 RVA: 0x0069537C File Offset: 0x0069357C
	public override void OnBulletDestroy()
	{
		if (this.LogicController.NeedAttach)
		{
			this.Actor.K2_DetachFromActor(EDetachmentRule.KeepRelative, EDetachmentRule.KeepRelative, EDetachmentRule.KeepRelative);
		}
		Singleton<ActorSystem>.Instance.Put("BulletLogicSpawnObstacles.OnBulletDestroy", this.Actor, null);
	}

	// Token: 0x0400B61E RID: 46622
	[Nullable(2)]
	private AActor Actor;
}
