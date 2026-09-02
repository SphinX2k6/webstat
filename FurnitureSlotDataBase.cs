using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02001033 RID: 4147
[NullableContext(1)]
[Nullable(0)]
public abstract class FurnitureSlotDataBase
{
	// Token: 0x06006BEB RID: 27627
	public abstract EFurnitureSlotType GetSlotType();

	// Token: 0x06006BEC RID: 27628
	public abstract void PlaceFurniture(int furnitureConfigId);

	// Token: 0x06006BED RID: 27629
	public abstract void UnPlaceFurniture();

	// Token: 0x06006BEE RID: 27630 RVA: 0x001C46A1 File Offset: 0x001C28A1
	public void DeepCopy(FurnitureSlotDataBase other)
	{
		this.PlacedFurnitureConfigId = other.PlacedFurnitureConfigId;
		this.SlotTagId = other.SlotTagId;
		this.ExcludedFurnitureIds = new List<int>(other.ExcludedFurnitureIds);
	}

	// Token: 0x06006BEF RID: 27631 RVA: 0x001C46CC File Offset: 0x001C28CC
	public bool Compare(FurnitureSlotDataBase other)
	{
		if (this.PlacedFurnitureConfigId != other.PlacedFurnitureConfigId)
		{
			return false;
		}
		if (this.SlotTagId != other.SlotTagId)
		{
			return false;
		}
		if (this.ExcludedFurnitureIds.Count != other.ExcludedFurnitureIds.Count)
		{
			return false;
		}
		for (int i = 0; i < this.ExcludedFurnitureIds.Count; i++)
		{
			if (this.ExcludedFurnitureIds[i] != other.ExcludedFurnitureIds[i])
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x06006BF0 RID: 27632 RVA: 0x001C4746 File Offset: 0x001C2946
	public int GetPlacedFurnitureConfigId()
	{
		return this.PlacedFurnitureConfigId;
	}

	// Token: 0x06006BF1 RID: 27633 RVA: 0x001C474E File Offset: 0x001C294E
	public int GetSlotTagId()
	{
		return this.SlotTagId;
	}

	// Token: 0x06006BF2 RID: 27634 RVA: 0x001C4756 File Offset: 0x001C2956
	public List<int> GetExcludedFurnitureIds()
	{
		return this.ExcludedFurnitureIds;
	}

	// Token: 0x06006BF3 RID: 27635 RVA: 0x001C4760 File Offset: 0x001C2960
	public bool CheckCanPlace(int furnitureConfigId)
	{
		Furniture? furnitureConfig = ConfigBase<FurnitureConfig>.Instance.GetFurnitureConfig(furnitureConfigId);
		return furnitureConfig != null && this.CheckCanPlaceByConfig(furnitureConfig.Value);
	}

	// Token: 0x06006BF4 RID: 27636 RVA: 0x001C4794 File Offset: 0x001C2994
	public bool CheckCanPlaceByConfig(Furniture config)
	{
		int id = config.Id;
		int num = -1;
		for (int i = 0; i < this.ExcludedFurnitureIds.Count; i++)
		{
			if (this.ExcludedFurnitureIds[i] == id)
			{
				num = i;
				break;
			}
		}
		return num == -1 && config.TagId == this.SlotTagId;
	}

	// Token: 0x06006BF5 RID: 27637 RVA: 0x001C47EC File Offset: 0x001C29EC
	public bool IsPlaced()
	{
		return this.PlacedFurnitureConfigId != 0;
	}

	// Token: 0x0400334E RID: 13134
	protected int PlacedFurnitureConfigId;

	// Token: 0x0400334F RID: 13135
	protected int SlotTagId;

	// Token: 0x04003350 RID: 13136
	protected List<int> ExcludedFurnitureIds = new List<int>();
}
