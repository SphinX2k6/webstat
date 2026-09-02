using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Item;

// Token: 0x02001993 RID: 6547
public class TipsPinballItemData : TipsMaterialData
{
	// Token: 0x0600BBFD RID: 48125 RVA: 0x0031EC5B File Offset: 0x0031CE5B
	[NullableContext(1)]
	public TipsPinballItemData(ItemTipsParam data) : base(data)
	{
		this.ItemType = EItemTipsType.PinballItem;
	}
}
