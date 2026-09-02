using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02001035 RID: 4149
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class FurnitureConfig : ConfigBase<FurnitureConfig>
{
	// Token: 0x06006C01 RID: 27649 RVA: 0x001C48D1 File Offset: 0x001C2AD1
	public SpringFestival? GetGameplayConfigById(int handleId)
	{
		return ConfigSpringFestivalByActivityId.GetConfig(handleId, true);
	}

	// Token: 0x06006C02 RID: 27650 RVA: 0x001C48DA File Offset: 0x001C2ADA
	public Furniture? GetFurnitureConfig(int furnitureId)
	{
		return ConfigFurnitureById.GetConfig(furnitureId, true);
	}

	// Token: 0x06006C03 RID: 27651 RVA: 0x001C48E3 File Offset: 0x001C2AE3
	public IReadOnlyList<Furniture> GetFurnitureConfigListByTagId(int tagId)
	{
		return ConfigFurnitureByTagId.GetConfigList(tagId, true);
	}

	// Token: 0x06006C04 RID: 27652 RVA: 0x001C48EC File Offset: 0x001C2AEC
	public SpringFestivalArea? GetFurnitureAreaConfig(int areaId)
	{
		return ConfigSpringFestivalAreaById.GetConfig(areaId, true);
	}

	// Token: 0x06006C05 RID: 27653 RVA: 0x001C48F5 File Offset: 0x001C2AF5
	public FurnitureDiyTag? GetFurnitureTagConfig(int tagId)
	{
		return ConfigFurnitureDiyTagById.GetConfig(tagId, true);
	}

	// Token: 0x06006C06 RID: 27654 RVA: 0x001C4900 File Offset: 0x001C2B00
	public bool HasFurnitureLimit(int furnitureId)
	{
		Furniture? furnitureConfig = this.GetFurnitureConfig(furnitureId);
		return furnitureConfig != null && furnitureConfig.Value.LimitCount > 0;
	}

	// Token: 0x06006C07 RID: 27655 RVA: 0x001C4932 File Offset: 0x001C2B32
	public FurniturePresetConfig? GetFurniturePresetConfig(int areaId)
	{
		return ConfigFurniturePresetConfigByAreaId.GetConfig(areaId, true);
	}

	// Token: 0x06006C08 RID: 27656 RVA: 0x001C493B File Offset: 0x001C2B3B
	public IReadOnlyList<FurnitureDiyTag> GetFurnitureTagConfigList()
	{
		return ConfigFurnitureDiyTagAll.GetConfigList(true);
	}

	// Token: 0x06006C09 RID: 27657 RVA: 0x001C4943 File Offset: 0x001C2B43
	public AtmosphereLevel? GetAtmosphereLevelConfig(int handleId, int level)
	{
		return ConfigAtmosphereLevelByActivityIdAndLevel.GetConfig(handleId, level, true);
	}

	// Token: 0x06006C0A RID: 27658 RVA: 0x001C494D File Offset: 0x001C2B4D
	public IReadOnlyList<AtmosphereLevel> GetAtmosphereLevelConfigList(int handleId)
	{
		return ConfigAtmosphereLevelByActivityId.GetConfigList(handleId, true);
	}

	// Token: 0x06006C0B RID: 27659 RVA: 0x001C4956 File Offset: 0x001C2B56
	public IReadOnlyList<Furniture> GetFurnitureConfigListByHandleId(int handleId)
	{
		return ConfigFurnitureByActivityId.GetConfigList(handleId, true);
	}

	// Token: 0x06006C0C RID: 27660 RVA: 0x001C495F File Offset: 0x001C2B5F
	public FurnitureQualityConfig? GetFurnitureQualityConfig(int qualityId)
	{
		return ConfigFurnitureQualityConfigById.GetConfig(qualityId, true);
	}

	// Token: 0x06006C0D RID: 27661 RVA: 0x001C4968 File Offset: 0x001C2B68
	public FurnitureFilterConfig? GetFurnitureFilterConfig(int filterId)
	{
		return ConfigFurnitureFilterConfigById.GetConfig(filterId, true);
	}

	// Token: 0x06006C0E RID: 27662 RVA: 0x001C4971 File Offset: 0x001C2B71
	public IReadOnlyList<FurnitureFilterConfig> GetFurnitureFilterConfigList()
	{
		return ConfigFurnitureFilterConfigAll.GetConfigList(true);
	}

	// Token: 0x06006C0F RID: 27663 RVA: 0x001C4979 File Offset: 0x001C2B79
	public IReadOnlyList<Furniture> GetFurnitureConfigListBySourceTypeAndGetWayId(int sourceType, int getWayId)
	{
		return ConfigFurnitureBySourceTypeAndGetWayId.GetConfigList(sourceType, getWayId, true);
	}

	// Token: 0x06006C10 RID: 27664 RVA: 0x001C4983 File Offset: 0x001C2B83
	public IReadOnlyList<SpringFestivalArea> GetFurnitureAreaConfigListByFloorId(int floorId)
	{
		return ConfigSpringFestivalAreaByFloor.GetConfigList(floorId, true);
	}

	// Token: 0x06006C11 RID: 27665 RVA: 0x001C498C File Offset: 0x001C2B8C
	public IReadOnlyList<Furniture> GetFurnitureConfigList()
	{
		return ConfigFurnitureAll.GetConfigList(true);
	}

	// Token: 0x06006C12 RID: 27666 RVA: 0x001C4994 File Offset: 0x001C2B94
	public IReadOnlyList<SpringFestivalArea> GetFurnitureAreaConfigList()
	{
		return ConfigSpringFestivalAreaByAll.GetConfigList(true);
	}

	// Token: 0x06006C13 RID: 27667 RVA: 0x001C499C File Offset: 0x001C2B9C
	public SpringFestivalArea? GetFurnitureAreaConfigBySlotEntityId(int slotEntityId)
	{
		IReadOnlyList<SpringFestivalArea> furnitureAreaConfigList = this.GetFurnitureAreaConfigList();
		if (furnitureAreaConfigList == null)
		{
			return null;
		}
		foreach (SpringFestivalArea value in furnitureAreaConfigList)
		{
			int[] slotEntityIdsArray = value.GetSlotEntityIdsArray();
			if (slotEntityIdsArray != null)
			{
				for (int i = 0; i < slotEntityIdsArray.Length; i++)
				{
					if (slotEntityIdsArray[i] == slotEntityId)
					{
						return new SpringFestivalArea?(value);
					}
				}
			}
		}
		return null;
	}

	// Token: 0x06006C14 RID: 27668 RVA: 0x001C4A30 File Offset: 0x001C2C30
	public SpringFestivalAreaCamera? GetAreaCameraConfig(int id)
	{
		return ConfigSpringFestivalAreaCameraById.GetConfig(id, true);
	}
}
