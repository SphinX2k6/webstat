using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Util;

// Token: 0x02002225 RID: 8741
[NullableContext(1)]
[Nullable(0)]
public class MailAttachmentData : ScrollViewDataBase
{
	// Token: 0x06010814 RID: 67604 RVA: 0x0048252D File Offset: 0x0048072D
	public MailAttachmentData(int id, int count, bool picked)
	{
		this.ItemId = id;
		this.Count = count;
		this.WasPicked = picked;
		this.Config = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(this.ItemId);
	}

	// Token: 0x06010815 RID: 67605 RVA: 0x00482560 File Offset: 0x00480760
	public int GetItemId()
	{
		return this.ItemId;
	}

	// Token: 0x06010816 RID: 67606 RVA: 0x00482568 File Offset: 0x00480768
	public int GetCount()
	{
		return this.Count;
	}

	// Token: 0x06010817 RID: 67607 RVA: 0x00482570 File Offset: 0x00480770
	public bool GetPicked()
	{
		return this.WasPicked;
	}

	// Token: 0x06010818 RID: 67608 RVA: 0x00482578 File Offset: 0x00480778
	public ItemConfig GetItemConfig()
	{
		return this.Config;
	}

	// Token: 0x040081E0 RID: 33248
	private readonly int ItemId;

	// Token: 0x040081E1 RID: 33249
	private readonly int Count;

	// Token: 0x040081E2 RID: 33250
	private readonly bool WasPicked;

	// Token: 0x040081E3 RID: 33251
	private readonly ItemConfig Config;
}
