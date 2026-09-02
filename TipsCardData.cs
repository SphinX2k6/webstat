using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Item;

// Token: 0x0200198B RID: 6539
public class TipsCardData : ItemTipsData
{
	// Token: 0x0600BBEE RID: 48110 RVA: 0x0031EB49 File Offset: 0x0031CD49
	[NullableContext(1)]
	public TipsCardData(ItemTipsParam data) : base(data)
	{
		this.ItemType = EItemTipsType.Card;
	}
}
