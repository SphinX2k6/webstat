using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Quest;
using CSharpScript.Game.LevelGamePlay;

namespace CSharpScript.Game.Module.ItemDeliver
{
	// Token: 0x02005B64 RID: 23396
	[NullableContext(1)]
	[Nullable(0)]
	public class DeliverData
	{
		// Token: 0x0603B2D8 RID: 242392 RVA: 0x00EF972F File Offset: 0x00EF792F
		[NullableContext(2)]
		public DeliverData([Nullable(1)] string npcName, string titleTextId = null, string descriptionTextId = null, GeneralContext content = null)
		{
			this.Context = content;
			this.NpcName = npcName;
			this.TitleTextId = titleTextId;
			this.DescriptionTextId = descriptionTextId;
		}

		// Token: 0x0603B2D9 RID: 242393 RVA: 0x00EF976A File Offset: 0x00EF796A
		public void Clear()
		{
			this.Context = null;
			this.SlotDataList.Clear();
			this.NpcName = "";
			this.DescriptionTextId = "";
		}

		// Token: 0x0603B2DA RID: 242394 RVA: 0x00EF9794 File Offset: 0x00EF7994
		[return: Nullable(2)]
		public DeliverSlotData AddSlotData(List<int> itemIdList, int needCount, EHandInItemType handInType)
		{
			if (itemIdList == null || itemIdList.Count == 0)
			{
				return null;
			}
			DeliverSlotData deliverSlotData = new DeliverSlotData();
			deliverSlotData.Initialize(itemIdList, needCount, handInType);
			this.SlotDataList.Add(deliverSlotData);
			return deliverSlotData;
		}

		// Token: 0x0603B2DB RID: 242395 RVA: 0x00EF97CA File Offset: 0x00EF79CA
		public List<DeliverSlotData> GetSlotDataList()
		{
			return this.SlotDataList;
		}

		// Token: 0x0603B2DC RID: 242396 RVA: 0x00EF97D4 File Offset: 0x00EF79D4
		public bool IsSlotEnough(int itemConfigId)
		{
			foreach (DeliverSlotData deliverSlotData in this.SlotDataList)
			{
				if (deliverSlotData.HasItem() && deliverSlotData.GetCurrentItemConfigId() == itemConfigId && deliverSlotData.IsEnough())
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0603B2DD RID: 242397 RVA: 0x00EF9840 File Offset: 0x00EF7A40
		public bool HasEmptySlot()
		{
			using (List<DeliverSlotData>.Enumerator enumerator = this.SlotDataList.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (!enumerator.Current.HasItem())
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x040215AF RID: 136623
		[Nullable(2)]
		public GeneralContext Context;

		// Token: 0x040215B0 RID: 136624
		private readonly List<DeliverSlotData> SlotDataList = new List<DeliverSlotData>();

		// Token: 0x040215B1 RID: 136625
		public string NpcName = "";

		// Token: 0x040215B2 RID: 136626
		[Nullable(2)]
		public string TitleTextId;

		// Token: 0x040215B3 RID: 136627
		[Nullable(2)]
		public string DescriptionTextId;
	}
}
