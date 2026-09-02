using System;
using System.Runtime.CompilerServices;

// Token: 0x02001EE4 RID: 7908
[NullableContext(2)]
[Nullable(0)]
public class HonamiStoryRoleEquipSlotData
{
	// Token: 0x0600EA60 RID: 60000 RVA: 0x003F9930 File Offset: 0x003F7B30
	public HonamiStoryRoleEquipSlotData(int slotId)
	{
		this.SlotId = slotId;
	}

	// Token: 0x0600EA61 RID: 60001 RVA: 0x003F993F File Offset: 0x003F7B3F
	public int GetSlotId()
	{
		return this.SlotId;
	}

	// Token: 0x0600EA62 RID: 60002 RVA: 0x003F9947 File Offset: 0x003F7B47
	public bool GetIsUnlock()
	{
		return this.IsUnlock;
	}

	// Token: 0x0600EA63 RID: 60003 RVA: 0x003F994F File Offset: 0x003F7B4F
	public void SetIsUnlock(bool value)
	{
		this.IsUnlock = value;
	}

	// Token: 0x0600EA64 RID: 60004 RVA: 0x003F9958 File Offset: 0x003F7B58
	public void SetItemData(HonamiStoryEquipItemData itemData)
	{
		this.ItemData = itemData;
	}

	// Token: 0x0600EA65 RID: 60005 RVA: 0x003F9961 File Offset: 0x003F7B61
	public HonamiStoryEquipItemData GetItemData()
	{
		return this.ItemData;
	}

	// Token: 0x040070FA RID: 28922
	private bool IsUnlock;

	// Token: 0x040070FB RID: 28923
	private HonamiStoryEquipItemData ItemData;

	// Token: 0x040070FC RID: 28924
	private readonly int SlotId;
}
