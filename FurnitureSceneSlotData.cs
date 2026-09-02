using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Component;

// Token: 0x0200102E RID: 4142
[NullableContext(1)]
[Nullable(0)]
public class FurnitureSceneSlotData : FurnitureSlotDataBase
{
	// Token: 0x06006BCF RID: 27599 RVA: 0x001C416A File Offset: 0x001C236A
	public override EFurnitureSlotType GetSlotType()
	{
		return EFurnitureSlotType.SceneSlot;
	}

	// Token: 0x06006BD0 RID: 27600 RVA: 0x001C4170 File Offset: 0x001C2370
	public void SetSceneSlotData(int mapId, int slotEntityId)
	{
		this.MapId = mapId;
		this.SlotEntityId = slotEntityId;
		IFurnitureSlot sceneSlotEntitySlotInfo = ModelBase<FurnitureModel>.Instance.GetSceneSlotEntitySlotInfo(mapId, slotEntityId);
		if (sceneSlotEntitySlotInfo == null)
		{
			return;
		}
		this.SlotTagId = sceneSlotEntitySlotInfo.FurnitureTag;
		this.ExcludedFurnitureIds = (sceneSlotEntitySlotInfo.ExcludedFurnitureIds ?? new List<int>());
	}

	// Token: 0x06006BD1 RID: 27601 RVA: 0x001C41C0 File Offset: 0x001C23C0
	public void DeepCopy(FurnitureSceneSlotData other)
	{
		base.DeepCopy(other);
		this.SlotEntityId = other.SlotEntityId;
		this.SubSlotDataList = new List<FurnitureSubSlotData>();
		for (int i = 0; i < other.SubSlotDataList.Count; i++)
		{
			FurnitureSubSlotData other2 = other.SubSlotDataList[i];
			FurnitureSubSlotData furnitureSubSlotData = new FurnitureSubSlotData();
			furnitureSubSlotData.DeepCopy(other2);
			this.SubSlotDataList.Add(furnitureSubSlotData);
		}
		this.MapId = other.MapId;
	}

	// Token: 0x06006BD2 RID: 27602 RVA: 0x001C4234 File Offset: 0x001C2434
	public bool Compare(FurnitureSceneSlotData other)
	{
		if (!base.Compare(other))
		{
			return false;
		}
		if (this.MapId != other.MapId)
		{
			return false;
		}
		if (this.SlotEntityId != other.SlotEntityId)
		{
			return false;
		}
		if (this.SubSlotDataList.Count != other.SubSlotDataList.Count)
		{
			return false;
		}
		for (int i = 0; i < this.SubSlotDataList.Count; i++)
		{
			if (!this.SubSlotDataList[i].Compare(other.SubSlotDataList[i]))
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x06006BD3 RID: 27603 RVA: 0x001C42C0 File Offset: 0x001C24C0
	public IFurnitureSceneSlotDiff GetSceneSlotDiff(FurnitureSceneSlotData other)
	{
		int rootFurnitureToUnPlace = 0;
		int rootFurnitureToPlace = 0;
		if (this.PlacedFurnitureConfigId != other.PlacedFurnitureConfigId)
		{
			rootFurnitureToUnPlace = this.PlacedFurnitureConfigId;
			rootFurnitureToPlace = other.PlacedFurnitureConfigId;
		}
		List<FurnitureSubSlotData> subSlotDataList = this.GetSubSlotDataList();
		List<FurnitureSubSlotData> subSlotDataList2 = other.GetSubSlotDataList();
		int[] array = new int[subSlotDataList.Count];
		int[] array2 = new int[subSlotDataList2.Count];
		for (int i = 0; i < this.SubSlotDataList.Count; i++)
		{
			int placedFurnitureConfigId = this.SubSlotDataList[i].GetPlacedFurnitureConfigId();
			if (placedFurnitureConfigId <= 0)
			{
				array[i] = 0;
			}
			else if (i >= subSlotDataList2.Count)
			{
				array[i] = placedFurnitureConfigId;
			}
			else
			{
				int placedFurnitureConfigId2 = subSlotDataList2[i].GetPlacedFurnitureConfigId();
				if (placedFurnitureConfigId != placedFurnitureConfigId2)
				{
					array[i] = placedFurnitureConfigId;
				}
				else
				{
					array[i] = 0;
				}
			}
		}
		for (int j = 0; j < subSlotDataList2.Count; j++)
		{
			int placedFurnitureConfigId3 = subSlotDataList2[j].GetPlacedFurnitureConfigId();
			if (placedFurnitureConfigId3 <= 0)
			{
				array2[j] = 0;
			}
			else if (j >= subSlotDataList.Count)
			{
				array2[j] = placedFurnitureConfigId3;
			}
			else if (subSlotDataList[j].GetPlacedFurnitureConfigId() != placedFurnitureConfigId3)
			{
				array2[j] = placedFurnitureConfigId3;
			}
			else
			{
				array2[j] = 0;
			}
		}
		return new FurnitureSceneSlotDiff
		{
			RootFurnitureToUnPlace = rootFurnitureToUnPlace,
			RootFurnitureToPlace = rootFurnitureToPlace,
			SubFurnitureListToUnPlace = array,
			SubFurnitureListToPlace = array2
		};
	}

	// Token: 0x06006BD4 RID: 27604 RVA: 0x001C4410 File Offset: 0x001C2610
	public override void PlaceFurniture(int furnitureConfigId)
	{
		this.PlacedFurnitureConfigId = furnitureConfigId;
		this.ClearSubSlotDataList();
		IReadOnlyList<IFurnitureSlot> subSlotInfos = ModelBase<FurnitureModel>.Instance.GetSubSlotInfos(furnitureConfigId);
		if (subSlotInfos == null)
		{
			return;
		}
		for (int i = 0; i < subSlotInfos.Count; i++)
		{
			IFurnitureSlot furnitureSlot = subSlotInfos[i];
			FurnitureSubSlotData furnitureSubSlotData = new FurnitureSubSlotData();
			furnitureSubSlotData.SetSlotData(this.SlotEntityId, furnitureConfigId, i, furnitureSlot.FurnitureTag, furnitureSlot.ExcludedFurnitureIds ?? new List<int>());
			this.SubSlotDataList.Add(furnitureSubSlotData);
		}
	}

	// Token: 0x06006BD5 RID: 27605 RVA: 0x001C4488 File Offset: 0x001C2688
	public override void UnPlaceFurniture()
	{
		this.PlacedFurnitureConfigId = 0;
		this.ClearSubSlotDataList();
	}

	// Token: 0x06006BD6 RID: 27606 RVA: 0x001C4497 File Offset: 0x001C2697
	public void ClearSubSlotDataList()
	{
		this.SubSlotDataList.Clear();
	}

	// Token: 0x06006BD7 RID: 27607 RVA: 0x001C44A4 File Offset: 0x001C26A4
	public FurnitureSubSlotData GetSubSlotData(int index)
	{
		return this.SubSlotDataList[index];
	}

	// Token: 0x06006BD8 RID: 27608 RVA: 0x001C44B2 File Offset: 0x001C26B2
	public int GetSubSlotDataListLength()
	{
		return this.SubSlotDataList.Count;
	}

	// Token: 0x06006BD9 RID: 27609 RVA: 0x001C44BF File Offset: 0x001C26BF
	public List<FurnitureSubSlotData> GetSubSlotDataList()
	{
		return this.SubSlotDataList;
	}

	// Token: 0x06006BDA RID: 27610 RVA: 0x001C44C7 File Offset: 0x001C26C7
	public int GetSlotEntityId()
	{
		return this.SlotEntityId;
	}

	// Token: 0x04003347 RID: 13127
	protected int SlotEntityId;

	// Token: 0x04003348 RID: 13128
	protected List<FurnitureSubSlotData> SubSlotDataList = new List<FurnitureSubSlotData>();

	// Token: 0x04003349 RID: 13129
	protected int MapId;
}
