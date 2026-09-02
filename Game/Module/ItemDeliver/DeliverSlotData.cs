using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Quest;

namespace CSharpScript.Game.Module.ItemDeliver
{
	// Token: 0x02005B65 RID: 23397
	[NullableContext(1)]
	[Nullable(0)]
	public class DeliverSlotData
	{
		// Token: 0x0603B2DE RID: 242398 RVA: 0x00EF989C File Offset: 0x00EF7A9C
		public void Initialize(List<int> itemIdList, int needCount, EHandInItemType handInType)
		{
			this.ItemRangeList = itemIdList;
			this.ItemRangeSet = new HashSet<int>(itemIdList);
			this.NeedCount = needCount;
			this.HandInType = handInType;
			this.CurrentItemConfigId = 0;
			this.CurrentCount = 0;
		}

		// Token: 0x0603B2DF RID: 242399 RVA: 0x00EF98CD File Offset: 0x00EF7ACD
		public bool SetItem(int itemConfigId, int count)
		{
			if (!this.CanSet(itemConfigId))
			{
				return false;
			}
			this.CurrentItemConfigId = itemConfigId;
			this.CurrentCount = count;
			return true;
		}

		// Token: 0x0603B2E0 RID: 242400 RVA: 0x00EF98E9 File Offset: 0x00EF7AE9
		public void ClearItem()
		{
			this.CurrentItemConfigId = 0;
			this.CurrentCount = 0;
		}

		// Token: 0x0603B2E1 RID: 242401 RVA: 0x00EF98F9 File Offset: 0x00EF7AF9
		public bool CanSet(int itemConfigId)
		{
			return (this.CurrentItemConfigId <= 0 || this.CurrentItemConfigId == itemConfigId) && this.ItemRangeSet.Contains(itemConfigId);
		}

		// Token: 0x0603B2E2 RID: 242402 RVA: 0x00EF9920 File Offset: 0x00EF7B20
		public bool IsEnough()
		{
			return this.CurrentCount >= this.NeedCount;
		}

		// Token: 0x0603B2E3 RID: 242403 RVA: 0x00EF9933 File Offset: 0x00EF7B33
		public bool HasItem()
		{
			return this.CurrentItemConfigId > 0;
		}

		// Token: 0x0603B2E4 RID: 242404 RVA: 0x00EF993E File Offset: 0x00EF7B3E
		public IReadOnlySet<int> GetItemRangeSet()
		{
			return this.ItemRangeSet;
		}

		// Token: 0x0603B2E5 RID: 242405 RVA: 0x00EF9946 File Offset: 0x00EF7B46
		public IReadOnlyList<int> GetItemRangeList()
		{
			return this.ItemRangeList;
		}

		// Token: 0x0603B2E6 RID: 242406 RVA: 0x00EF994E File Offset: 0x00EF7B4E
		public int GetNeedCount()
		{
			return this.NeedCount;
		}

		// Token: 0x0603B2E7 RID: 242407 RVA: 0x00EF9956 File Offset: 0x00EF7B56
		public int GetCurrentItemConfigId()
		{
			return this.CurrentItemConfigId;
		}

		// Token: 0x0603B2E8 RID: 242408 RVA: 0x00EF995E File Offset: 0x00EF7B5E
		public int GetCurrentCount()
		{
			return this.CurrentCount;
		}

		// Token: 0x0603B2E9 RID: 242409 RVA: 0x00EF9966 File Offset: 0x00EF7B66
		public void SetCurrentCount(int count)
		{
			this.CurrentCount = count;
		}

		// Token: 0x040215B4 RID: 136628
		private List<int> ItemRangeList = new List<int>();

		// Token: 0x040215B5 RID: 136629
		private HashSet<int> ItemRangeSet = new HashSet<int>();

		// Token: 0x040215B6 RID: 136630
		private int NeedCount;

		// Token: 0x040215B7 RID: 136631
		public EHandInItemType HandInType;

		// Token: 0x040215B8 RID: 136632
		private int CurrentItemConfigId;

		// Token: 0x040215B9 RID: 136633
		private int CurrentCount;
	}
}
