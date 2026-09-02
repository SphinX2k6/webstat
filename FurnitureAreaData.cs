using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x0200102D RID: 4141
[NullableContext(1)]
[Nullable(0)]
public class FurnitureAreaData
{
	// Token: 0x06006BB2 RID: 27570 RVA: 0x001C3A80 File Offset: 0x001C1C80
	public void DeepCopy(FurnitureAreaData other)
	{
		this.AreaId = other.AreaId;
		this.MapId = other.MapId;
		this.Atmosphere = other.Atmosphere;
		this.MaxAtmosphere = other.MaxAtmosphere;
		this.SceneSlotDataMap.Clear();
		foreach (KeyValuePair<int, FurnitureSceneSlotData> keyValuePair in other.SceneSlotDataMap)
		{
			FurnitureSceneSlotData furnitureSceneSlotData = new FurnitureSceneSlotData();
			furnitureSceneSlotData.DeepCopy(keyValuePair.Value);
			this.SceneSlotDataMap[keyValuePair.Key] = furnitureSceneSlotData;
		}
		this.FurnitureUseCountMap.Clear();
		foreach (KeyValuePair<int, int> keyValuePair2 in other.FurnitureUseCountMap)
		{
			this.FurnitureUseCountMap[keyValuePair2.Key] = keyValuePair2.Value;
		}
	}

	// Token: 0x06006BB3 RID: 27571 RVA: 0x001C3B90 File Offset: 0x001C1D90
	public bool Compare(FurnitureAreaData other)
	{
		if (this.AreaId != other.AreaId)
		{
			return false;
		}
		if (this.MapId != other.MapId)
		{
			return false;
		}
		if (this.Atmosphere != other.Atmosphere)
		{
			return false;
		}
		if (this.MaxAtmosphere != other.MaxAtmosphere)
		{
			return false;
		}
		if (this.SceneSlotDataMap.Count != other.SceneSlotDataMap.Count)
		{
			return false;
		}
		foreach (KeyValuePair<int, FurnitureSceneSlotData> keyValuePair in this.SceneSlotDataMap)
		{
			FurnitureSceneSlotData other2;
			if (!other.SceneSlotDataMap.TryGetValue(keyValuePair.Key, out other2))
			{
				return false;
			}
			if (!keyValuePair.Value.Compare(other2))
			{
				return false;
			}
		}
		if (this.FurnitureUseCountMap.Count != other.FurnitureUseCountMap.Count)
		{
			return false;
		}
		foreach (KeyValuePair<int, int> keyValuePair2 in this.FurnitureUseCountMap)
		{
			int num;
			if (!other.FurnitureUseCountMap.TryGetValue(keyValuePair2.Key, out num))
			{
				return false;
			}
			if (keyValuePair2.Value != num)
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x06006BB4 RID: 27572 RVA: 0x001C3CEC File Offset: 0x001C1EEC
	public void SetAreaId(int areaId)
	{
		this.AreaId = areaId;
	}

	// Token: 0x06006BB5 RID: 27573 RVA: 0x001C3CF5 File Offset: 0x001C1EF5
	public void SetMapId(int mapId)
	{
		this.MapId = mapId;
	}

	// Token: 0x06006BB6 RID: 27574 RVA: 0x001C3CFE File Offset: 0x001C1EFE
	public void SetAtmosphere(int atmosphere)
	{
		this.Atmosphere = atmosphere;
	}

	// Token: 0x06006BB7 RID: 27575 RVA: 0x001C3D07 File Offset: 0x001C1F07
	public void SetMaxAtmosphere(int maxAtmosphere)
	{
		this.MaxAtmosphere = maxAtmosphere;
	}

	// Token: 0x06006BB8 RID: 27576 RVA: 0x001C3D10 File Offset: 0x001C1F10
	public FurnitureSceneSlotData CreateSceneSlotData(int slotEntityId)
	{
		FurnitureSceneSlotData furnitureSceneSlotData = new FurnitureSceneSlotData();
		furnitureSceneSlotData.SetSceneSlotData(this.MapId, slotEntityId);
		this.SceneSlotDataMap[slotEntityId] = furnitureSceneSlotData;
		return furnitureSceneSlotData;
	}

	// Token: 0x06006BB9 RID: 27577 RVA: 0x001C3D40 File Offset: 0x001C1F40
	public void SetSlotPlacedData(int slotEntityId, int subSlotIndex, int furnitureConfigId)
	{
		FurnitureSceneSlotData sceneSlotData;
		if (!this.SceneSlotDataMap.TryGetValue(slotEntityId, out sceneSlotData))
		{
			return;
		}
		if (subSlotIndex == -1)
		{
			this.SetSceneSlotPlacedDataInternal(sceneSlotData, furnitureConfigId);
			return;
		}
		this.SetSubSlotPlacedDataInternal(sceneSlotData, subSlotIndex, furnitureConfigId);
	}

	// Token: 0x06006BBA RID: 27578 RVA: 0x001C3D74 File Offset: 0x001C1F74
	public void ClearSlotPlacedData()
	{
		this.FurnitureUseCountMap.Clear();
		foreach (FurnitureSceneSlotData furnitureSceneSlotData in this.SceneSlotDataMap.Values)
		{
			furnitureSceneSlotData.UnPlaceFurniture();
		}
		this.Atmosphere = 0;
	}

	// Token: 0x06006BBB RID: 27579 RVA: 0x001C3DDC File Offset: 0x001C1FDC
	private void SetSceneSlotPlacedDataInternal(FurnitureSceneSlotData sceneSlotData, int furnitureConfigId)
	{
		for (int i = 0; i < sceneSlotData.GetSubSlotDataListLength(); i++)
		{
			FurnitureSubSlotData subSlotData = sceneSlotData.GetSubSlotData(i);
			if (subSlotData != null)
			{
				this.ReduceFurnitureCount(subSlotData.GetPlacedFurnitureConfigId());
			}
		}
		this.UnPlaceFurnitureInternal(sceneSlotData);
		if (furnitureConfigId > 0)
		{
			this.PlaceFurnitureInternal(sceneSlotData, furnitureConfigId);
		}
	}

	// Token: 0x06006BBC RID: 27580 RVA: 0x001C3E24 File Offset: 0x001C2024
	private void SetSubSlotPlacedDataInternal(FurnitureSceneSlotData sceneSlotData, int subSlotIndex, int furnitureConfigId)
	{
		FurnitureSubSlotData subSlotData = sceneSlotData.GetSubSlotData(subSlotIndex);
		if (subSlotData == null)
		{
			return;
		}
		this.UnPlaceFurnitureInternal(subSlotData);
		if (furnitureConfigId > 0)
		{
			this.PlaceFurnitureInternal(subSlotData, furnitureConfigId);
		}
	}

	// Token: 0x06006BBD RID: 27581 RVA: 0x001C3E50 File Offset: 0x001C2050
	private void PlaceFurnitureInternal(FurnitureSlotDataBase slotData, int furnitureConfigId)
	{
		slotData.PlaceFurniture(furnitureConfigId);
		this.AddFurnitureCount(furnitureConfigId);
	}

	// Token: 0x06006BBE RID: 27582 RVA: 0x001C3E60 File Offset: 0x001C2060
	private void UnPlaceFurnitureInternal(FurnitureSlotDataBase slotData)
	{
		this.ReduceFurnitureCount(slotData.GetPlacedFurnitureConfigId());
		slotData.UnPlaceFurniture();
	}

	// Token: 0x06006BBF RID: 27583 RVA: 0x001C3E74 File Offset: 0x001C2074
	protected void AddFurnitureCount(int furnitureConfigId)
	{
		if (furnitureConfigId <= 0)
		{
			return;
		}
		int num;
		this.FurnitureUseCountMap.TryGetValue(furnitureConfigId, out num);
		this.FurnitureUseCountMap[furnitureConfigId] = num + 1;
	}

	// Token: 0x06006BC0 RID: 27584 RVA: 0x001C3EA4 File Offset: 0x001C20A4
	protected void ReduceFurnitureCount(int furnitureConfigId)
	{
		if (furnitureConfigId <= 0)
		{
			return;
		}
		if (!this.FurnitureUseCountMap.ContainsKey(furnitureConfigId))
		{
			return;
		}
		int num2;
		int num = (this.FurnitureUseCountMap.TryGetValue(furnitureConfigId, out num2) ? num2 : 0) - 1;
		if (num <= 0)
		{
			this.FurnitureUseCountMap.Remove(furnitureConfigId);
			return;
		}
		this.FurnitureUseCountMap[furnitureConfigId] = num;
	}

	// Token: 0x06006BC1 RID: 27585 RVA: 0x001C3EFB File Offset: 0x001C20FB
	public int GetPlacedFurnitureConfigId(int slotEntityId, int subSlotIndex)
	{
		FurnitureSlotDataBase slotData = this.GetSlotData(slotEntityId, subSlotIndex);
		if (slotData == null)
		{
			return 0;
		}
		return slotData.GetPlacedFurnitureConfigId();
	}

	// Token: 0x06006BC2 RID: 27586 RVA: 0x001C3F10 File Offset: 0x001C2110
	[NullableContext(2)]
	public FurnitureSceneSlotData GetSceneSlotData(int slotEntityId)
	{
		FurnitureSceneSlotData result;
		if (!this.SceneSlotDataMap.TryGetValue(slotEntityId, out result))
		{
			return null;
		}
		return result;
	}

	// Token: 0x06006BC3 RID: 27587 RVA: 0x001C3F30 File Offset: 0x001C2130
	[NullableContext(2)]
	public FurnitureSlotDataBase GetSlotData(int slotEntityId, int subSlotIndex)
	{
		if (subSlotIndex == -1)
		{
			return this.GetSceneSlotData(slotEntityId);
		}
		FurnitureSceneSlotData sceneSlotData = this.GetSceneSlotData(slotEntityId);
		if (sceneSlotData == null)
		{
			return null;
		}
		return sceneSlotData.GetSubSlotData(subSlotIndex);
	}

	// Token: 0x06006BC4 RID: 27588 RVA: 0x001C3F51 File Offset: 0x001C2151
	public IReadOnlyDictionary<int, FurnitureSceneSlotData> GetSceneSlotDataMap()
	{
		return this.SceneSlotDataMap;
	}

	// Token: 0x06006BC5 RID: 27589 RVA: 0x001C3F59 File Offset: 0x001C2159
	public int GetAreaId()
	{
		return this.AreaId;
	}

	// Token: 0x06006BC6 RID: 27590 RVA: 0x001C3F61 File Offset: 0x001C2161
	public int GetMapId()
	{
		return this.MapId;
	}

	// Token: 0x06006BC7 RID: 27591 RVA: 0x001C3F69 File Offset: 0x001C2169
	public int GetAtmosphere()
	{
		return this.Atmosphere;
	}

	// Token: 0x06006BC8 RID: 27592 RVA: 0x001C3F71 File Offset: 0x001C2171
	public int GetMaxAtmosphere()
	{
		return this.MaxAtmosphere;
	}

	// Token: 0x06006BC9 RID: 27593 RVA: 0x001C3F7C File Offset: 0x001C217C
	public int GetFurnitureUseCount(int furnitureConfigId)
	{
		int result;
		if (!this.FurnitureUseCountMap.TryGetValue(furnitureConfigId, out result))
		{
			return 0;
		}
		return result;
	}

	// Token: 0x06006BCA RID: 27594 RVA: 0x001C3F9C File Offset: 0x001C219C
	public int GetPlacedSceneSlotCount()
	{
		int num = 0;
		using (Dictionary<int, FurnitureSceneSlotData>.ValueCollection.Enumerator enumerator = this.SceneSlotDataMap.Values.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.IsPlaced())
				{
					num++;
				}
			}
		}
		return num;
	}

	// Token: 0x06006BCB RID: 27595 RVA: 0x001C3FFC File Offset: 0x001C21FC
	public int GetPlacedSlotCount()
	{
		int num = 0;
		foreach (FurnitureSceneSlotData furnitureSceneSlotData in this.SceneSlotDataMap.Values)
		{
			if (furnitureSceneSlotData.IsPlaced())
			{
				num += 1 + this.GetPlacedSubSlotCount(furnitureSceneSlotData);
			}
		}
		return num;
	}

	// Token: 0x06006BCC RID: 27596 RVA: 0x001C4064 File Offset: 0x001C2264
	public int GetPlacedSubSlotCount(FurnitureSceneSlotData sceneSlotData)
	{
		int num = 0;
		using (List<FurnitureSubSlotData>.Enumerator enumerator = sceneSlotData.GetSubSlotDataList().GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.IsPlaced())
				{
					num++;
				}
			}
		}
		return num;
	}

	// Token: 0x06006BCD RID: 27597 RVA: 0x001C40C0 File Offset: 0x001C22C0
	public void UpdateAtmosphere()
	{
		int num = 0;
		foreach (KeyValuePair<int, int> keyValuePair in this.FurnitureUseCountMap)
		{
			Furniture? furnitureConfig = ConfigBase<FurnitureConfig>.Instance.GetFurnitureConfig(keyValuePair.Key);
			if (furnitureConfig != null)
			{
				num += furnitureConfig.Value.Atmosphere * keyValuePair.Value;
			}
		}
		this.Atmosphere = num;
	}

	// Token: 0x04003340 RID: 13120
	private int AreaId;

	// Token: 0x04003341 RID: 13121
	private int MapId;

	// Token: 0x04003342 RID: 13122
	protected int Atmosphere;

	// Token: 0x04003343 RID: 13123
	protected int MaxAtmosphere;

	// Token: 0x04003344 RID: 13124
	protected Dictionary<int, FurnitureSceneSlotData> SceneSlotDataMap = new Dictionary<int, FurnitureSceneSlotData>();

	// Token: 0x04003345 RID: 13125
	protected Dictionary<int, int> FurnitureUseCountMap = new Dictionary<int, int>();

	// Token: 0x04003346 RID: 13126
	public bool UsePreset;
}
