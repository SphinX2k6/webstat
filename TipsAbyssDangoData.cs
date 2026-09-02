using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Item;

// Token: 0x0200198F RID: 6543
public class TipsAbyssDangoData : ItemTipsData
{
	// Token: 0x0600BBF9 RID: 48121 RVA: 0x0031EB94 File Offset: 0x0031CD94
	[NullableContext(1)]
	public TipsAbyssDangoData(ItemTipsParam data) : base(data)
	{
		this.ItemType = EItemTipsType.AbyssDango;
		this.IsIconByType = true;
		this.IsQualityByType = true;
		if (data.ExtraParam != null)
		{
			IDangoExtraParam dangoExtraParam = data.ExtraParam as IDangoExtraParam;
			this.DangoId = dangoExtraParam.DangoId;
			this.SlotIndex = dangoExtraParam.SlotIndex;
		}
	}

	// Token: 0x040058F9 RID: 22777
	public int DangoId = -1;

	// Token: 0x040058FA RID: 22778
	public int SlotIndex = -1;
}
