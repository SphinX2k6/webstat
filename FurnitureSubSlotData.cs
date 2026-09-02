using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02001034 RID: 4148
[NullableContext(1)]
[Nullable(0)]
public class FurnitureSubSlotData : FurnitureSlotDataBase
{
	// Token: 0x06006BF7 RID: 27639 RVA: 0x001C480A File Offset: 0x001C2A0A
	public override EFurnitureSlotType GetSlotType()
	{
		return EFurnitureSlotType.SubSlot;
	}

	// Token: 0x06006BF8 RID: 27640 RVA: 0x001C480D File Offset: 0x001C2A0D
	public void DeepCopy(FurnitureSubSlotData other)
	{
		base.DeepCopy(other);
		this.RootFurnitureEntityId = other.RootFurnitureEntityId;
		this.RootFurnitureConfigId = other.RootFurnitureConfigId;
		this.SlotIndex = other.SlotIndex;
	}

	// Token: 0x06006BF9 RID: 27641 RVA: 0x001C483A File Offset: 0x001C2A3A
	public bool Compare(FurnitureSubSlotData other)
	{
		return base.Compare(other) && this.RootFurnitureEntityId == other.RootFurnitureEntityId && this.RootFurnitureConfigId == other.RootFurnitureConfigId && this.SlotIndex == other.SlotIndex;
	}

	// Token: 0x06006BFA RID: 27642 RVA: 0x001C4878 File Offset: 0x001C2A78
	public void SetSlotData(int rootFurnitureEntityId, int rootFurnitureConfigId, int slotIndex, int slotTagId, List<int> excludedFurnitureIds)
	{
		this.RootFurnitureEntityId = rootFurnitureEntityId;
		this.RootFurnitureConfigId = rootFurnitureConfigId;
		this.SlotIndex = slotIndex;
		this.SlotTagId = slotTagId;
		this.ExcludedFurnitureIds = excludedFurnitureIds;
	}

	// Token: 0x06006BFB RID: 27643 RVA: 0x001C489F File Offset: 0x001C2A9F
	public override void PlaceFurniture(int furnitureConfigId)
	{
		this.PlacedFurnitureConfigId = furnitureConfigId;
	}

	// Token: 0x06006BFC RID: 27644 RVA: 0x001C48A8 File Offset: 0x001C2AA8
	public override void UnPlaceFurniture()
	{
		this.PlacedFurnitureConfigId = 0;
	}

	// Token: 0x06006BFD RID: 27645 RVA: 0x001C48B1 File Offset: 0x001C2AB1
	public int GetRootFurnitureEntityId()
	{
		return this.RootFurnitureEntityId;
	}

	// Token: 0x06006BFE RID: 27646 RVA: 0x001C48B9 File Offset: 0x001C2AB9
	public int GetRootFurnitureConfigId()
	{
		return this.RootFurnitureConfigId;
	}

	// Token: 0x06006BFF RID: 27647 RVA: 0x001C48C1 File Offset: 0x001C2AC1
	public int GetSlotIndex()
	{
		return this.SlotIndex;
	}

	// Token: 0x04003351 RID: 13137
	protected int RootFurnitureEntityId;

	// Token: 0x04003352 RID: 13138
	protected int RootFurnitureConfigId;

	// Token: 0x04003353 RID: 13139
	protected int SlotIndex;
}
