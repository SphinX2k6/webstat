using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelAi.Tasks
{
	// Token: 0x02006E27 RID: 28199
	public class LevelAiTaskSetItemCollision : LevelAiTask
	{
		// Token: 0x06044728 RID: 280360 RVA: 0x011C7F0A File Offset: 0x011C610A
		protected override ELevelAiNodeResult ExecuteTask()
		{
			if (this.IsIgnore)
			{
				this.IgnoreCollision();
			}
			else
			{
				this.ResetCollision();
			}
			return ELevelAiNodeResult.Succeeded;
		}

		// Token: 0x06044729 RID: 280361 RVA: 0x011C7F24 File Offset: 0x011C6124
		[NullableContext(1)]
		private void IgnoreActorsCollision(SceneItemActorComponent actorComp, bool bCollision)
		{
			CreatureDataComponent component = actorComp.Entity.GetComponent<CreatureDataComponent>();
			BaseCharacterComponent component2 = base.CreatureDataComponent.Entity.GetComponent<BaseCharacterComponent>();
			int pbDataId = component.GetPbDataId();
			int? ownerEntity = ModelBase<CreatureModel>.Instance.GetOwnerEntity(pbDataId);
			SceneItemActorComponent sceneItemActorComponent;
			if (ownerEntity != null)
			{
				EntityHandle entityByPbDataId = ModelBase<CreatureModel>.Instance.GetEntityByPbDataId(ownerEntity.Value);
				if (entityByPbDataId != null)
				{
					sceneItemActorComponent = entityByPbDataId.Entity.GetComponent<SceneItemActorComponent>();
				}
				else
				{
					sceneItemActorComponent = actorComp;
				}
			}
			else
			{
				sceneItemActorComponent = actorComp;
			}
			if (sceneItemActorComponent == null)
			{
				return;
			}
			TArray<AActor> tarray = new TArray<AActor>();
			sceneItemActorComponent.Owner.GetAttachedActors(ref tarray, true);
			int num = tarray.Num();
			for (int i = 0; i < num; i++)
			{
				AActor aactor = tarray.Get(i);
				TArray<AActor> tarray2 = new TArray<AActor>();
				aactor.GetAttachedActors(ref tarray2, true);
				int num2 = tarray2.Num();
				for (int j = 0; j < num2; j++)
				{
					component2.Actor.CapsuleComponent.IgnoreActorWhenMoving(tarray2.Get(j), bCollision);
				}
			}
		}

		// Token: 0x0604472A RID: 280362 RVA: 0x011C8018 File Offset: 0x011C6218
		private void ResetCollision()
		{
			SceneItemActorComponent component = this.ItemEntity.Entity.GetComponent<SceneItemActorComponent>();
			if (component == null)
			{
				return;
			}
			BaseCharacterComponent component2 = base.CreatureDataComponent.Entity.GetComponent<BaseCharacterComponent>();
			this.IgnoreActorsCollision(component, false);
			component2.Actor.CapsuleComponent.SetCollisionResponseToChannel(ECollisionChannel.ECC_Pawn, ECollisionResponse.ECR_Block);
		}

		// Token: 0x0604472B RID: 280363 RVA: 0x011C8064 File Offset: 0x011C6264
		private void IgnoreCollision()
		{
			SceneItemActorComponent component = this.ItemEntity.Entity.GetComponent<SceneItemActorComponent>();
			if (component == null)
			{
				return;
			}
			this.IgnoreActorsCollision(component, true);
			base.CreatureDataComponent.Entity.GetComponent<BaseCharacterComponent>().Actor.CapsuleComponent.SetCollisionResponseToChannel(ECollisionChannel.ECC_Pawn, ECollisionResponse.ECR_Ignore);
		}

		// Token: 0x04026179 RID: 156025
		[Nullable(2)]
		public EntityHandle ItemEntity;

		// Token: 0x0402617A RID: 156026
		public bool IsIgnore;
	}
}
