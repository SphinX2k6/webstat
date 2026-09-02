using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x02006793 RID: 26515
	[NullableContext(1)]
	[Nullable(0)]
	public class DockyardBackpackOriginalData
	{
		// Token: 0x060421A4 RID: 270756 RVA: 0x010F5ADC File Offset: 0x010F3CDC
		private void PrintPosDataLog()
		{
			if (ModelBase<DockyardModel>.Instance.IsPrintLog)
			{
				StringBuilder stringBuilder = new StringBuilder();
				foreach (DockyardItemBlockOriginalData dockyardItemBlockOriginalData in this.ItemDataMap.Values)
				{
					stringBuilder.Append(dockyardItemBlockOriginalData.IncId);
					stringBuilder.Append(':');
					stringBuilder.Append(dockyardItemBlockOriginalData.ItemId);
					stringBuilder.Append(',');
				}
				foreach (List<int> list in this.PosDataDoublyList)
				{
					stringBuilder.Append('\n');
					foreach (int num in list)
					{
						stringBuilder.Append(num.ToString().PadLeft(4, ' '));
						stringBuilder.Append(',');
					}
				}
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Dockyard;
				ELogAuthor author = ELogAuthor.XXJ;
				string message = "捕鱼背包数据";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("道具以及格子数据", stringBuilder.ToString());
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
		}

		// Token: 0x060421A5 RID: 270757 RVA: 0x010F5C38 File Offset: 0x010F3E38
		public void RefreshPosData()
		{
			this.PosDataDoublyList.Clear();
			int fishingCabinShape = ModelBase<DockyardModel>.Instance.FishingCabinShape;
			FishingGridItemShape fishingShapeConfig = ConfigBase<FishingConfig>.Instance.GetFishingShapeConfig(fishingCabinShape);
			for (int i = 0; i < 7; i++)
			{
				this.PosDataDoublyList.Add(new List<int>());
				for (int j = 0; j < 8; j++)
				{
					int[] arrayIntArray = fishingShapeConfig.FillState()[i].GetArrayIntArray();
					if (j >= arrayIntArray.Length || arrayIntArray[j] == 0)
					{
						this.PosDataDoublyList[i].Add(-1);
					}
					else
					{
						this.PosDataDoublyList[i].Add(0);
					}
				}
			}
			foreach (DockyardItemBlockOriginalData dockyardItemBlockOriginalData in this.ItemDataMap.Values)
			{
				List<List<int>> list = DockyardPanelUtil.RotateOriginalPosData(dockyardItemBlockOriginalData.PosDoublyList, dockyardItemBlockOriginalData.Rotate);
				int num = 0;
				int count = list.Count;
				int num2 = 0;
				int count2 = list[0].Count;
				for (int k = num; k < count; k++)
				{
					for (int l = num2; l < count2; l++)
					{
						if (list[k][l] == 1)
						{
							int index = k + dockyardItemBlockOriginalData.GetServerData().Pos.Y;
							int index2 = l + dockyardItemBlockOriginalData.GetServerData().Pos.X;
							this.PosDataDoublyList[index][index2] = dockyardItemBlockOriginalData.IncId;
						}
					}
				}
			}
			Singleton<EventSystem>.Instance.Emit(EEventName.FishingRefreshBackpackData);
			this.PrintPosDataLog();
		}

		// Token: 0x060421A6 RID: 270758 RVA: 0x010F5DEC File Offset: 0x010F3FEC
		public void SetQuicklySellData(int shapeId, int ratio)
		{
			this.QuicklySellDataId = shapeId;
			this.QuicklySellRatio = ratio;
		}

		// Token: 0x060421A7 RID: 270759 RVA: 0x010F5DFC File Offset: 0x010F3FFC
		public void SetBackpackDataListFromServer(List<FishingItemInfo> dataList)
		{
			this.ItemDataMap.Clear();
			foreach (FishingItemInfo fishingItemInfo in dataList)
			{
				DockyardItemBlockOriginalData value = new DockyardItemBlockOriginalData(fishingItemInfo);
				this.ItemDataMap.Add(fishingItemInfo.IncrId, value);
			}
		}

		// Token: 0x060421A8 RID: 270760 RVA: 0x010F5E68 File Offset: 0x010F4068
		public List<DockyardItemBlockOriginalData> GetBackpackItemList()
		{
			return this.ItemDataMap.Values.ToList<DockyardItemBlockOriginalData>();
		}

		// Token: 0x060421A9 RID: 270761 RVA: 0x010F5E7A File Offset: 0x010F407A
		[NullableContext(2)]
		public DockyardItemBlockOriginalData GetBackpackItemData(int uniqueId)
		{
			return this.ItemDataMap.GetValueOrDefault(uniqueId);
		}

		// Token: 0x1700A0D5 RID: 41173
		// (get) Token: 0x060421AA RID: 270762 RVA: 0x010F5E88 File Offset: 0x010F4088
		public int BackpackUseSize
		{
			get
			{
				int num = 0;
				foreach (List<int> list in this.PosDataDoublyList)
				{
					using (List<int>.Enumerator enumerator2 = list.GetEnumerator())
					{
						while (enumerator2.MoveNext())
						{
							if (enumerator2.Current > 0)
							{
								num++;
							}
						}
					}
				}
				return num;
			}
		}

		// Token: 0x1700A0D6 RID: 41174
		// (get) Token: 0x060421AB RID: 270763 RVA: 0x010F5F14 File Offset: 0x010F4114
		public int BackpackSize
		{
			get
			{
				int num = 0;
				foreach (List<int> list in this.PosDataDoublyList)
				{
					using (List<int>.Enumerator enumerator2 = list.GetEnumerator())
					{
						while (enumerator2.MoveNext())
						{
							if (enumerator2.Current > -1)
							{
								num++;
							}
						}
					}
				}
				return num;
			}
		}

		// Token: 0x060421AC RID: 270764 RVA: 0x010F5FA0 File Offset: 0x010F41A0
		public int GetItemCountByItemId(int itemId)
		{
			int num = 0;
			using (Dictionary<int, DockyardItemBlockOriginalData>.ValueCollection.Enumerator enumerator = this.ItemDataMap.Values.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.ItemId == itemId)
					{
						num++;
					}
				}
			}
			return num;
		}

		// Token: 0x060421AD RID: 270765 RVA: 0x010F6000 File Offset: 0x010F4200
		public List<DockyardItemBlockOriginalData> GetItemListByItemId(int itemId)
		{
			List<DockyardItemBlockOriginalData> list = new List<DockyardItemBlockOriginalData>();
			foreach (DockyardItemBlockOriginalData dockyardItemBlockOriginalData in this.ItemDataMap.Values)
			{
				if (dockyardItemBlockOriginalData.ItemId == itemId)
				{
					list.Add(dockyardItemBlockOriginalData);
				}
			}
			return list;
		}

		// Token: 0x04024D81 RID: 150913
		private readonly Dictionary<int, DockyardItemBlockOriginalData> ItemDataMap = new Dictionary<int, DockyardItemBlockOriginalData>();

		// Token: 0x04024D82 RID: 150914
		public readonly List<List<int>> PosDataDoublyList = new List<List<int>>();

		// Token: 0x04024D83 RID: 150915
		public int QuicklySellDataId;

		// Token: 0x04024D84 RID: 150916
		public int QuicklySellRatio;
	}
}
