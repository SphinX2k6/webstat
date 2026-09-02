using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.Item;
using AkiClient.Game.Aki.CreatureTools;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.SceneItem.Model
{
	// Token: 0x02004845 RID: 18501
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Model(0)]
	public class SceneInteractionModel : ModelBase<SceneInteractionModel>
	{
		// Token: 0x06030225 RID: 197157 RVA: 0x00BAC9BC File Offset: 0x00BAABBC
		[return: Nullable(2)]
		public EntityHandle GetEntityByBaseItem(AActor actor)
		{
			if (!this.IsInitBaseItemInfo)
			{
				this.IsInitBaseItemInfo = true;
				UKuroLevelPlayLibrary.RegisterBaseItemInfo(BP_BaseItem_C.StaticClass(), "EntityId");
			}
			int entityIdByBaseItem = UKuroLevelPlayLibrary.GetEntityIdByBaseItem(actor);
			CreatureModel instance = ModelBase<CreatureModel>.Instance;
			if (instance == null)
			{
				return null;
			}
			return instance.GetEntityById(entityIdByBaseItem);
		}

		// Token: 0x06030226 RID: 197158 RVA: 0x00BACA00 File Offset: 0x00BAAC00
		[return: Nullable(2)]
		public EntityHandle GetEntityByActor(AActor actor, bool isAccurate = false)
		{
			AActor baseItemByActor = this.GetBaseItemByActor(actor, isAccurate);
			if (baseItemByActor == null)
			{
				return null;
			}
			return ActorUtils.GetEntityByActor(baseItemByActor, true);
		}

		// Token: 0x06030227 RID: 197159 RVA: 0x00BACA24 File Offset: 0x00BAAC24
		[return: Nullable(2)]
		public AActor GetBaseItemByActor(AActor actor, bool isAccurate = false)
		{
			if (actor == null || !actor.IsValid())
			{
				return null;
			}
			AActor aactor = actor.GetOwner();
			if (aactor == null)
			{
				if (isAccurate)
				{
					return null;
				}
				aactor = this.GetEntityActorByChildActor(actor);
				if (aactor == null)
				{
					return null;
				}
			}
			if (UKuroStaticLibrary.IsObjectClassByName(aactor, Singleton<CharacterNameDefines>.Instance.BP_BASEITEM))
			{
				return aactor;
			}
			if (isAccurate)
			{
				return null;
			}
			return this.GetEntityActorByChildActor(actor);
		}

		// Token: 0x06030228 RID: 197160 RVA: 0x00BACA80 File Offset: 0x00BAAC80
		[return: Nullable(2)]
		private AActor GetEntityActorByChildActor(AActor childActor)
		{
			AActor aactor = childActor;
			while (aactor != null && !(aactor is IBPI_CreatureInterface_C))
			{
				aactor = aactor.GetAttachParentActor();
			}
			if (aactor == null)
			{
				return null;
			}
			IBPI_CreatureInterface_C ibpi_CreatureInterface_C = aactor as IBPI_CreatureInterface_C;
			Entity entity = Singleton<EntitySystem>.Instance.Get(ibpi_CreatureInterface_C.GetEntityId());
			if (entity == null || !entity.Valid)
			{
				return null;
			}
			return aactor;
		}

		// Token: 0x0401BA17 RID: 113175
		private bool IsInitBaseItemInfo;

		// Token: 0x0401BA18 RID: 113176
		private readonly Stat StatGetEntityByActor = Stat.Create("SceneInteractionModel.GetEntityByActor", "", "");
	}
}
