using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Inventory;

// Token: 0x0200205A RID: 8282
[NullableContext(1)]
[Nullable(0)]
public class ItemMainTypeMapping
{
	// Token: 0x0600FC4E RID: 64590 RVA: 0x00455057 File Offset: 0x00453257
	public ItemMainTypeMapping(InventoryDefine.EItemMainTypeId itemMainType)
	{
		this.MainType = itemMainType;
	}

	// Token: 0x0600FC4F RID: 64591 RVA: 0x00455071 File Offset: 0x00453271
	public void Add(ItemDataBase itemData)
	{
		this.ItemDataSet.Add(itemData);
	}

	// Token: 0x0600FC50 RID: 64592 RVA: 0x00455080 File Offset: 0x00453280
	public void Remove(ItemDataBase itemData)
	{
		this.ItemDataSet.Remove(itemData);
	}

	// Token: 0x0600FC51 RID: 64593 RVA: 0x0045508F File Offset: 0x0045328F
	public HashSet<ItemDataBase> GetSet()
	{
		return this.ItemDataSet;
	}

	// Token: 0x0600FC52 RID: 64594 RVA: 0x00455098 File Offset: 0x00453298
	public bool HasRedDot()
	{
		using (HashSet<ItemDataBase>.Enumerator enumerator = this.ItemDataSet.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.HasRedDot())
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x04007914 RID: 30996
	public readonly InventoryDefine.EItemMainTypeId MainType;

	// Token: 0x04007915 RID: 30997
	private readonly HashSet<ItemDataBase> ItemDataSet = new HashSet<ItemDataBase>();
}
