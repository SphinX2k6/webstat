using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.Pawn.Controllers
{
	// Token: 0x020048A6 RID: 18598
	[NullableContext(1)]
	[Nullable(0)]
	public class PawnChairController : SubEntityInteractLogicController
	{
		// Token: 0x06030753 RID: 198483 RVA: 0x00BE1013 File Offset: 0x00BDF213
		public PawnChairController(CreatureDataComponent creatureDataComp) : base(creatureDataComp)
		{
		}

		// Token: 0x06030754 RID: 198484 RVA: 0x00BE1024 File Offset: 0x00BDF224
		public override bool Possess(Entity masterEntity, bool force = false)
		{
			this.MasterEntity = masterEntity;
			return true;
		}

		// Token: 0x06030755 RID: 198485 RVA: 0x00BE102E File Offset: 0x00BDF22E
		public override bool UnPossess(Entity masterEntity)
		{
			this.MasterEntity = null;
			return true;
		}

		// Token: 0x06030756 RID: 198486 RVA: 0x00BE1038 File Offset: 0x00BDF238
		public Vector GetSitLocation()
		{
			Vector tmpVector = SubEntityInteractLogicController.TmpVector;
			tmpVector.Reset();
			Vector tmpVector2 = SubEntityInteractLogicController.TmpVector2;
			BaseActorComponent component = this.Entity.GetComponent<BaseActorComponent>();
			tmpVector2.DeepCopy(component.ActorLocationProxy);
			BaseCharacterComponent component2 = this.MasterEntity.GetComponent<BaseCharacterComponent>();
			float scaledHalfHeight = component2.ScaledHalfHeight;
			Vector actorLocationProxy = component2.ActorLocationProxy;
			((this.RealSceneItemActorComp != null) ? this.RealSceneItemActorComp.ActorRightProxy : component.ActorRightProxy).Multiply((double)this.SitPointOffset, tmpVector);
			tmpVector2.Z = ((this.RealSceneItemActorComp != null) ? (this.RealSceneItemActorComp.ActorLocationProxy.Z + (double)scaledHalfHeight) : actorLocationProxy.Z);
			tmpVector.AdditionEqual(tmpVector2);
			return tmpVector;
		}

		// Token: 0x06030757 RID: 198487 RVA: 0x00BE10E4 File Offset: 0x00BDF2E4
		public Vector GetForwardDirection()
		{
			return this.Entity.GetComponent<BaseActorComponent>().ActorRightProxy;
		}

		// Token: 0x06030758 RID: 198488 RVA: 0x00BE10F8 File Offset: 0x00BDF2F8
		private unsafe void IgnoreChairActorsCollision(bool bCollision)
		{
			if (this.RealSceneItemActorComp == null || this.MasterEntity == null)
			{
				return;
			}
			if (!this.RealSceneItemActorComp.GetIsSceneInteractionLoadCompleted())
			{
				return;
			}
			ECollisionResponse newResponse = bCollision ? ECollisionResponse.ECR_Ignore : ECollisionResponse.ECR_Block;
			BaseCharacterComponent component = this.MasterEntity.GetComponent<BaseCharacterComponent>();
			TArray<AActor> tarray = new TArray<AActor>();
			this.RealSceneItemActorComp.Owner.GetAttachedActors(ref tarray, true);
			int num = tarray.Num();
			if (num == 0)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.AI;
				ELogAuthor author = ELogAuthor.YJX;
				string message = "[PawnChairController.IgnoreChairActorsCollision] 场景交互物体未加载完全";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("itemPbDataId", this.CreatureDataComp.GetPbDataId());
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("OwnerPbDataId", this.RealSceneItemActorComp.CreatureData.GetPbDataId());
				instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			}
			for (int i = 0; i < num; i++)
			{
				AActor aactor = tarray.Get(i);
				TArray<AActor> tarray2 = new TArray<AActor>();
				aactor.GetAttachedActors(ref tarray2, true);
				int num2 = tarray2.Num();
				for (int j = 0; j < num2; j++)
				{
					AActor aactor2 = tarray2.Get(j);
					if (aactor2.IsValid())
					{
						component.Actor.IgnoreActorWhenMoving(tarray2.Get(j), bCollision, true);
						AStaticMeshActor astaticMeshActor = aactor2 as AStaticMeshActor;
						if (astaticMeshActor != null && astaticMeshActor.IsValid())
						{
							UStaticMeshComponent ustaticMeshComponent = astaticMeshActor.GetComponentByClass(UStaticMeshComponent.StaticClass()) as UStaticMeshComponent;
							if (ustaticMeshComponent != null)
							{
								ustaticMeshComponent.SetCollisionResponseToChannel(ECollisionChannel.ECC_Pawn, newResponse);
							}
						}
					}
				}
			}
		}

		// Token: 0x06030759 RID: 198489 RVA: 0x00BE1281 File Offset: 0x00BDF481
		public void ResetCollision()
		{
			if (this.Entity.GetComponent<SceneItemActorComponent>() == null)
			{
				return;
			}
			this.IgnoreChairActorsCollision(false);
		}

		// Token: 0x0603075A RID: 198490 RVA: 0x00BE1298 File Offset: 0x00BDF498
		public void IgnoreCollision()
		{
			if (this.Entity.GetComponent<SceneItemActorComponent>() == null)
			{
				return;
			}
			this.IgnoreChairActorsCollision(true);
		}

		// Token: 0x0603075B RID: 198491 RVA: 0x00BE12B0 File Offset: 0x00BDF4B0
		public bool IsSceneInteractionLoadCompleted()
		{
			SceneItemActorComponent component = this.Entity.GetComponent<SceneItemActorComponent>();
			if (component == null || !component.GetIsSceneInteractionLoadCompleted())
			{
				return false;
			}
			int pbDataId = this.CreatureDataComp.GetPbDataId();
			int? ownerEntity = ModelBase<CreatureModel>.Instance.GetOwnerEntity(pbDataId);
			if (ownerEntity == null)
			{
				this.RealSceneItemActorComp = component;
				return true;
			}
			EntityHandle entityByPbDataId = ModelBase<CreatureModel>.Instance.GetEntityByPbDataId(ownerEntity.Value);
			if (entityByPbDataId == null || !entityByPbDataId.Valid)
			{
				return false;
			}
			this.RealSceneItemActorComp = entityByPbDataId.Entity.GetComponent<SceneItemActorComponent>();
			return this.RealSceneItemActorComp != null && this.RealSceneItemActorComp.GetIsSceneInteractionLoadCompleted();
		}

		// Token: 0x0401BD5A RID: 114010
		private readonly int SitPointOffset = 40;

		// Token: 0x0401BD5B RID: 114011
		[Nullable(2)]
		private SceneItemActorComponent RealSceneItemActorComp;
	}
}
