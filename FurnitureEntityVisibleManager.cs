using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02001069 RID: 4201
[NullableContext(1)]
[Nullable(0)]
public class FurnitureEntityVisibleManager
{
	// Token: 0x06006D1B RID: 27931 RVA: 0x001C5FE2 File Offset: 0x001C41E2
	public void LockFurnitureEntity()
	{
		this.FurnitureEntityLock = true;
	}

	// Token: 0x06006D1C RID: 27932 RVA: 0x001C5FEB File Offset: 0x001C41EB
	public void UnlockFurnitureEntity()
	{
		this.FurnitureEntityLock = false;
	}

	// Token: 0x06006D1D RID: 27933 RVA: 0x001C5FF4 File Offset: 0x001C41F4
	public void DisabledAllEntities()
	{
		if (this.DisabledEntityList.Count > 0)
		{
			return;
		}
		IReadOnlyList<EntityHandle> allEntities = ModelBase<CreatureModel>.Instance.GetAllEntities();
		if (allEntities == null)
		{
			return;
		}
		int handleId = ModelBase<FurnitureModel>.Instance.HandleId;
		SpringFestival value = ConfigBase<FurnitureConfig>.Instance.GetGameplayConfigById(handleId).Value;
		int[] entityWhiteListArray = value.GetEntityWhiteListArray();
		int shopNpcEntityId = value.ShopNpcEntityId;
		foreach (EntityHandle entityHandle in allEntities)
		{
			WorldEntity entity = entityHandle.Entity;
			if (entity != null && entity.Active)
			{
				CreatureDataComponent component = entity.GetComponent<CreatureDataComponent>();
				if (component != null && this.EntityTypeFilter(component))
				{
					bool flag = false;
					for (int i = 0; i < entityWhiteListArray.Length; i++)
					{
						if (entityWhiteListArray[i] == entityHandle.PbDataId)
						{
							flag = true;
							break;
						}
					}
					if (!flag && entityHandle.PbDataId != shopNpcEntityId)
					{
						ControllerBase<CreatureController>.Instance.SetEntityEnable(entity, false, "进入家具装修状态", false);
						this.DisabledEntityList.Add(entityHandle);
					}
				}
			}
		}
	}

	// Token: 0x06006D1E RID: 27934 RVA: 0x001C6114 File Offset: 0x001C4314
	public void EnabledAllEntities()
	{
		this.EnableAllFurnitureEntity();
		if (this.DisabledEntityList.Count == 0)
		{
			return;
		}
		foreach (EntityHandle entityHandle in this.DisabledEntityList)
		{
			WorldEntity entity = entityHandle.Entity;
			if (entity != null)
			{
				ControllerBase<CreatureController>.Instance.SetEntityEnable(entity, true, "离开家具装修状态", false);
			}
		}
		this.DisabledEntityList.Clear();
	}

	// Token: 0x06006D1F RID: 27935 RVA: 0x001C619C File Offset: 0x001C439C
	public void EnableAllFurnitureEntity()
	{
		if (this.FurnitureEntityLock)
		{
			return;
		}
		IReadOnlyList<EntityHandle> allEntities = ModelBase<CreatureModel>.Instance.GetAllEntities();
		if (allEntities == null)
		{
			return;
		}
		foreach (EntityHandle entityHandle in allEntities)
		{
			WorldEntity entity = entityHandle.Entity;
			if (entity != null && !entity.Active)
			{
				CreatureDataComponent component = entity.GetComponent<CreatureDataComponent>();
				if (component != null)
				{
					int furnitureSlotId = component.FurnitureSlotId;
					int furnitureId = component.FurnitureId;
					if (furnitureSlotId > 0 && furnitureId > 0)
					{
						ControllerBase<CreatureController>.Instance.SetEntityEnable(entity, true, "进入家具装修状态", false);
					}
				}
			}
		}
	}

	// Token: 0x06006D20 RID: 27936 RVA: 0x001C623C File Offset: 0x001C443C
	public bool TryEnableFurnitureEntity(EntityHandle entityHandle)
	{
		if (this.FurnitureEntityLock)
		{
			return false;
		}
		WorldEntity entity = entityHandle.Entity;
		if (entity == null)
		{
			return false;
		}
		if (entity.Active)
		{
			return false;
		}
		CreatureDataComponent component = entity.GetComponent<CreatureDataComponent>();
		if (component == null)
		{
			return false;
		}
		int furnitureSlotId = component.FurnitureSlotId;
		int furnitureId = component.FurnitureId;
		if (furnitureSlotId <= 0 || furnitureId <= 0)
		{
			return false;
		}
		ControllerBase<CreatureController>.Instance.SetEntityEnable(entity, true, "FurnitureAddByAoi", false);
		return true;
	}

	// Token: 0x06006D21 RID: 27937 RVA: 0x001C62A0 File Offset: 0x001C44A0
	public void EnableSpareShopNpcEntity()
	{
		int handleId = ModelBase<FurnitureModel>.Instance.HandleId;
		int spareShopNpcEntityId = ConfigBase<FurnitureConfig>.Instance.GetGameplayConfigById(handleId).Value.SpareShopNpcEntityId;
		this.SpareShopNpcEntityHandle = ModelBase<CreatureModel>.Instance.GetEntityByPbDataId(spareShopNpcEntityId);
		EntityHandle spareShopNpcEntityHandle = this.SpareShopNpcEntityHandle;
		WorldEntity worldEntity = (spareShopNpcEntityHandle != null) ? spareShopNpcEntityHandle.Entity : null;
		if (worldEntity == null)
		{
			return;
		}
		ControllerBase<CreatureController>.Instance.SetEntityEnable(worldEntity, true, "进入家具装修状态", false);
	}

	// Token: 0x06006D22 RID: 27938 RVA: 0x001C6310 File Offset: 0x001C4510
	public void DisableSpareShopNpcEntity()
	{
		EntityHandle spareShopNpcEntityHandle = this.SpareShopNpcEntityHandle;
		WorldEntity worldEntity = (spareShopNpcEntityHandle != null) ? spareShopNpcEntityHandle.Entity : null;
		if (worldEntity == null)
		{
			return;
		}
		ControllerBase<CreatureController>.Instance.SetEntityEnable(worldEntity, false, "退出家具装修状态", false);
		this.SpareShopNpcEntityHandle = null;
	}

	// Token: 0x06006D23 RID: 27939 RVA: 0x001C634D File Offset: 0x001C454D
	private bool EntityTypeFilter(CreatureDataComponent creatureComponent)
	{
		return creatureComponent.IsRole() || creatureComponent.IsPlayer() || creatureComponent.IsNpc() || creatureComponent.IsSceneItem() || creatureComponent.IsAnimal();
	}

	// Token: 0x040033D4 RID: 13268
	private readonly List<EntityHandle> DisabledEntityList = new List<EntityHandle>();

	// Token: 0x040033D5 RID: 13269
	[Nullable(2)]
	private EntityHandle SpareShopNpcEntityHandle;

	// Token: 0x040033D6 RID: 13270
	private bool FurnitureEntityLock;
}
