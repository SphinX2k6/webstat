using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common;

namespace CSharpScript.Game.Module.Item
{
	// Token: 0x02005B7F RID: 23423
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Model(0)]
	public class ItemModel : ModelBase<ItemModel>
	{
		// Token: 0x0603B356 RID: 242518 RVA: 0x00EFBA84 File Offset: 0x00EF9C84
		protected override bool OnInit()
		{
			this.LastCloseTimeStamp = 0.0;
			this.WaitPhantomList = new List<int>();
			this.WaitVillageInfrTreeList = new List<int>();
			return true;
		}

		// Token: 0x0603B357 RID: 242519 RVA: 0x00EFBAAC File Offset: 0x00EF9CAC
		protected override bool OnClear()
		{
			this.WaitItemList.Clear();
			this.GetItemConfigIdList.Clear();
			this.WaitPhantomList.Clear();
			this.WaitVillageInfrTreeList.Clear();
			return true;
		}

		// Token: 0x0603B358 RID: 242520 RVA: 0x00EFBADB File Offset: 0x00EF9CDB
		public void LoadGetItemConfigIdList()
		{
			this.GetItemConfigIdList = (LocalStorage.GetPlayer<List<int>>(ELocalStoragePlayerKey.GetItemConfigListSaveKey, null) ?? new List<int>());
		}

		// Token: 0x0603B359 RID: 242521 RVA: 0x00EFBAF4 File Offset: 0x00EF9CF4
		public void AddGetItemConfigIdList(int configId)
		{
			this.GetItemConfigIdList.Add(configId);
			this.SaveGetItemConfigIdList();
		}

		// Token: 0x0603B35A RID: 242522 RVA: 0x00EFBB08 File Offset: 0x00EF9D08
		public bool IsGotItem(int configId)
		{
			return this.GetItemConfigIdList.Contains(configId);
		}

		// Token: 0x0603B35B RID: 242523 RVA: 0x00EFBB16 File Offset: 0x00EF9D16
		public void SaveGetItemConfigIdList()
		{
			LocalStorage.SetPlayer<List<int>>(ELocalStoragePlayerKey.GetItemConfigListSaveKey, this.GetItemConfigIdList);
		}

		// Token: 0x0603B35C RID: 242524 RVA: 0x00EFBB26 File Offset: 0x00EF9D26
		public bool IsWaitItemListEmpty()
		{
			return this.WaitItemList.Count == 0;
		}

		// Token: 0x0603B35D RID: 242525 RVA: 0x00EFBB36 File Offset: 0x00EF9D36
		public void PushWaitItemList(int itemId)
		{
			this.WaitItemList.Add(itemId);
		}

		// Token: 0x0603B35E RID: 242526 RVA: 0x00EFBB44 File Offset: 0x00EF9D44
		public int? ShiftWaitItemList()
		{
			if (this.WaitItemList.Count == 0)
			{
				return null;
			}
			int value = this.WaitItemList[0];
			this.WaitItemList.RemoveAt(0);
			return new int?(value);
		}

		// Token: 0x0603B35F RID: 242527 RVA: 0x00EFBB85 File Offset: 0x00EF9D85
		public bool IsWaitPhantomListEmpty()
		{
			return this.WaitPhantomList.Count == 0;
		}

		// Token: 0x0603B360 RID: 242528 RVA: 0x00EFBB95 File Offset: 0x00EF9D95
		public void PushWaitPhantomItem(int uniqueId)
		{
			this.WaitPhantomList.Add(uniqueId);
		}

		// Token: 0x0603B361 RID: 242529 RVA: 0x00EFBBA4 File Offset: 0x00EF9DA4
		public int? ShiftWaitPhantomList()
		{
			if (this.WaitPhantomList.Count == 0)
			{
				return null;
			}
			int value = this.WaitPhantomList[0];
			this.WaitPhantomList.RemoveAt(0);
			return new int?(value);
		}

		// Token: 0x0603B362 RID: 242530 RVA: 0x00EFBBE5 File Offset: 0x00EF9DE5
		public bool IsWaitVillageInfrTreeListEmpty()
		{
			return this.WaitVillageInfrTreeList.Count == 0;
		}

		// Token: 0x0603B363 RID: 242531 RVA: 0x00EFBBF5 File Offset: 0x00EF9DF5
		public void PushWaitVillageInfrTree(int treeId)
		{
			this.WaitVillageInfrTreeList.Add(treeId);
		}

		// Token: 0x0603B364 RID: 242532 RVA: 0x00EFBC04 File Offset: 0x00EF9E04
		public int? ShiftWaitVillageInfrTree()
		{
			if (this.WaitVillageInfrTreeList.Count == 0)
			{
				return null;
			}
			int value = this.WaitVillageInfrTreeList[0];
			this.WaitVillageInfrTreeList.RemoveAt(0);
			return new int?(value);
		}

		// Token: 0x0603B365 RID: 242533 RVA: 0x00EFBC45 File Offset: 0x00EF9E45
		public void GmClearWaitItemList()
		{
			this.WaitItemList = new List<int>();
		}

		// Token: 0x04021616 RID: 136726
		public double LastCloseTimeStamp;

		// Token: 0x04021617 RID: 136727
		private List<int> WaitItemList = new List<int>();

		// Token: 0x04021618 RID: 136728
		private List<int> WaitPhantomList = new List<int>();

		// Token: 0x04021619 RID: 136729
		private List<int> WaitVillageInfrTreeList = new List<int>();

		// Token: 0x0402161A RID: 136730
		private List<int> GetItemConfigIdList = new List<int>();
	}
}
