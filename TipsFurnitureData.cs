using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Item;

// Token: 0x02001992 RID: 6546
public class TipsFurnitureData : ItemTipsData
{
	// Token: 0x0600BBFC RID: 48124 RVA: 0x0031EC4A File Offset: 0x0031CE4A
	[NullableContext(1)]
	public TipsFurnitureData(ItemTipsParam data) : base(data)
	{
		this.ItemType = EItemTipsType.Furniture;
	}
}
