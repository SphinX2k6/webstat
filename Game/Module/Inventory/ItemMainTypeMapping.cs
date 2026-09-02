using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Inventory
{
	// Token: 0x02005B88 RID: 23432
	[NullableContext(1)]
	[Nullable(0)]
	public class ItemMainTypeMapping
	{
		// Token: 0x0603B3D3 RID: 242643 RVA: 0x00EFF8E4 File Offset: 0x00EFDAE4
		public ItemMainTypeMapping(InventoryDefine.EItemMainTypeId itemMainType)
		{
			this.MainType = itemMainType;
		}

		// Token: 0x0603B3D4 RID: 242644 RVA: 0x00EFF8FE File Offset: 0x00EFDAFE
		public void Add(ItemDataBase itemData)
		{
			this.ItemDataSet.Add(itemData);
		}

		// Token: 0x0603B3D5 RID: 242645 RVA: 0x00EFF90D File Offset: 0x00EFDB0D
		public void Remove(ItemDataBase itemData)
		{
			this.ItemDataSet.Remove(itemData);
		}

		// Token: 0x0603B3D6 RID: 242646 RVA: 0x00EFF91C File Offset: 0x00EFDB1C
		public HashSet<ItemDataBase> GetSet()
		{
			return this.ItemDataSet;
		}

		// Token: 0x0603B3D7 RID: 242647 RVA: 0x00EFF924 File Offset: 0x00EFDB24
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

		// Token: 0x04021677 RID: 136823
		public readonly InventoryDefine.EItemMainTypeId MainType;

		// Token: 0x04021678 RID: 136824
		private readonly HashSet<ItemDataBase> ItemDataSet = new HashSet<ItemDataBase>();
	}
}
