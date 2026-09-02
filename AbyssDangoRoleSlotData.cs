using System;
using System.Runtime.CompilerServices;

// Token: 0x020012D1 RID: 4817
public class AbyssDangoRoleSlotData
{
	// Token: 0x0600816A RID: 33130 RVA: 0x00223A63 File Offset: 0x00221C63
	public int GetSlotIndex()
	{
		return this.SlotIndex;
	}

	// Token: 0x0600816B RID: 33131 RVA: 0x00223A6B File Offset: 0x00221C6B
	public int GetDangoId()
	{
		return this.DangoRoleId;
	}

	// Token: 0x0600816C RID: 33132 RVA: 0x00223A73 File Offset: 0x00221C73
	public int GetIncId()
	{
		return this.UniqueId;
	}

	// Token: 0x0600816D RID: 33133 RVA: 0x00223A7B File Offset: 0x00221C7B
	public int GetEquipId()
	{
		return this.ItemId;
	}

	// Token: 0x0600816E RID: 33134 RVA: 0x00223A83 File Offset: 0x00221C83
	[NullableContext(1)]
	public string GetPassiveSkillDesc()
	{
		if (this.ItemId > 0)
		{
			return ModelBase<DangoAbyssModel>.Instance.GetPluginItemInfoById(this.UniqueId).GetPassiveSkillDesc();
		}
		return "";
	}

	// Token: 0x0600816F RID: 33135 RVA: 0x00223AA9 File Offset: 0x00221CA9
	public void SetDangoRoleId(int id)
	{
		this.DangoRoleId = id;
	}

	// Token: 0x06008170 RID: 33136 RVA: 0x00223AB2 File Offset: 0x00221CB2
	public void Refresh(int slotIndex, int uniqueId, int itemId)
	{
		this.SlotIndex = slotIndex;
		this.UniqueId = uniqueId;
		this.ItemId = itemId;
	}

	// Token: 0x04003DC2 RID: 15810
	private int SlotIndex = -1;

	// Token: 0x04003DC3 RID: 15811
	private int UniqueId;

	// Token: 0x04003DC4 RID: 15812
	private int ItemId;

	// Token: 0x04003DC5 RID: 15813
	private int DangoRoleId;
}
