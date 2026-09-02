using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common;
using CSharpScript.Game.Module.PayShop;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x020067A5 RID: 26533
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Model(0)]
	public class DockyardModel : ModelBase<DockyardModel>
	{
		// Token: 0x1700A0F5 RID: 41205
		// (get) Token: 0x060422AF RID: 271023 RVA: 0x010F9450 File Offset: 0x010F7650
		public bool IsTrawlOpen
		{
			get
			{
				return ModelBase<FishingModel>.Instance.GetFishingTechUnlockByEffectType(EFishingTechType.TrawlTech);
			}
		}

		// Token: 0x1700A0F6 RID: 41206
		// (get) Token: 0x060422B0 RID: 271024 RVA: 0x010F9460 File Offset: 0x010F7660
		public int TrawlSize
		{
			get
			{
				float num = (float)ModelBase<FishingModel>.Instance.GetFishingCurrentLevelTechEffectByEffectType(EFishingTechType.TrawlTech);
				if (num > 0f)
				{
					return ConfigBase<FishingConfig>.Instance.GetFishingTechEffectById((int)num).Params(0);
				}
				return 0;
			}
		}

		// Token: 0x060422B1 RID: 271025 RVA: 0x010F949C File Offset: 0x010F769C
		public void SetTrawlDataListFromServer(List<FishingItemInfo> dataList)
		{
			this.TrawlDataMap.Clear();
			foreach (FishingItemInfo fishingItemInfo in dataList)
			{
				DockyardItemBlockOriginalData value = new DockyardItemBlockOriginalData(fishingItemInfo);
				this.TrawlDataMap[fishingItemInfo.IncrId] = value;
			}
		}

		// Token: 0x060422B2 RID: 271026 RVA: 0x010F9508 File Offset: 0x010F7708
		[NullableContext(2)]
		public DockyardItemBlockOriginalData GetDataByTrawl(int uniqueId)
		{
			DockyardItemBlockOriginalData result;
			this.TrawlDataMap.TryGetValue(uniqueId, out result);
			return result;
		}

		// Token: 0x060422B3 RID: 271027 RVA: 0x010F9525 File Offset: 0x010F7725
		public List<DockyardItemBlockOriginalData> GetTrawlDataList()
		{
			return this.TrawlDataMap.Values.ToList<DockyardItemBlockOriginalData>();
		}

		// Token: 0x060422B4 RID: 271028 RVA: 0x010F9538 File Offset: 0x010F7738
		public void SetTrawlData(FishingItemInfo data)
		{
			DockyardItemBlockOriginalData value = new DockyardItemBlockOriginalData(data);
			this.TrawlDataMap[data.IncrId] = value;
		}

		// Token: 0x060422B5 RID: 271029 RVA: 0x010F9560 File Offset: 0x010F7760
		private void SetWareHouseDataListFromServer(List<FishingItemInfo> dataList)
		{
			this.WareHouseDataMap.Clear();
			foreach (FishingItemInfo fishingItemInfo in dataList)
			{
				DockyardItemBlockOriginalData value = new DockyardItemBlockOriginalData(fishingItemInfo);
				this.WareHouseDataMap[fishingItemInfo.IncrId] = value;
			}
		}

		// Token: 0x060422B6 RID: 271030 RVA: 0x010F95CC File Offset: 0x010F77CC
		[NullableContext(2)]
		public DockyardItemBlockOriginalData GetDataByWareHouse(int uniqueId)
		{
			DockyardItemBlockOriginalData result;
			this.WareHouseDataMap.TryGetValue(uniqueId, out result);
			return result;
		}

		// Token: 0x060422B7 RID: 271031 RVA: 0x010F95E9 File Offset: 0x010F77E9
		public List<DockyardItemBlockOriginalData> GetWareHouseDataList()
		{
			return this.WareHouseDataMap.Values.ToList<DockyardItemBlockOriginalData>();
		}

		// Token: 0x060422B8 RID: 271032 RVA: 0x010F95FB File Offset: 0x010F77FB
		public int GetWareHouseDataSize()
		{
			return this.WareHouseDataMap.Count;
		}

		// Token: 0x060422B9 RID: 271033 RVA: 0x010F9608 File Offset: 0x010F7808
		public void SetWareHouseData(FishingItemInfo data)
		{
			DockyardItemBlockOriginalData value = new DockyardItemBlockOriginalData(data);
			this.WareHouseDataMap[data.IncrId] = value;
		}

		// Token: 0x060422BA RID: 271034 RVA: 0x010F962E File Offset: 0x010F782E
		public int GetQuicklySellId()
		{
			return this.BackpackData.QuicklySellDataId;
		}

		// Token: 0x060422BB RID: 271035 RVA: 0x010F963B File Offset: 0x010F783B
		public float GetQuicklySellRatio()
		{
			return (float)this.BackpackData.QuicklySellRatio;
		}

		// Token: 0x060422BC RID: 271036 RVA: 0x010F9649 File Offset: 0x010F7849
		public List<DockyardItemBlockOriginalData> GetBackpackItemList()
		{
			return this.BackpackData.GetBackpackItemList();
		}

		// Token: 0x060422BD RID: 271037 RVA: 0x010F9656 File Offset: 0x010F7856
		public void AddListItemReadFlag(int itemId)
		{
			NewFlagModel instance = ModelBase<NewFlagModel>.Instance;
			if (instance != null)
			{
				instance.AddNewFlag(ELocalStoragePlayerKey.DockyardListItemRead, itemId);
			}
			NewFlagModel instance2 = ModelBase<NewFlagModel>.Instance;
			if (instance2 == null)
			{
				return;
			}
			instance2.SaveNewFlagConfig(ELocalStoragePlayerKey.DockyardListItemRead);
		}

		// Token: 0x060422BE RID: 271038 RVA: 0x010F967E File Offset: 0x010F787E
		public bool CheckListItemReadFlag(int itemId)
		{
			return ModelBase<NewFlagModel>.Instance.HasNewFlag(ELocalStoragePlayerKey.DockyardListItemRead, itemId);
		}

		// Token: 0x1700A0F7 RID: 41207
		// (get) Token: 0x060422BF RID: 271039 RVA: 0x010F968D File Offset: 0x010F788D
		public bool IsQuicklySellOpen
		{
			get
			{
				return this.BackpackData.QuicklySellDataId != 0;
			}
		}

		// Token: 0x060422C0 RID: 271040 RVA: 0x010F969D File Offset: 0x010F789D
		private void RefreshFishingCabinShape(int level)
		{
			this.FishingCabinShape = level;
		}

		// Token: 0x060422C1 RID: 271041 RVA: 0x010F96A6 File Offset: 0x010F78A6
		public void SetFishingShipData(FishingShipInfo fishingShipData)
		{
			this.SetDockyardData(fishingShipData.CabinInfo);
		}

		// Token: 0x060422C2 RID: 271042 RVA: 0x010F96B4 File Offset: 0x010F78B4
		public void SetDockyardData(CabinInfo dockyardData)
		{
			this.RefreshFishingCabinShape(dockyardData.CabinShape);
			this.BackpackData.SetBackpackDataListFromServer(dockyardData.FishingItems.ToList<FishingItemInfo>());
			this.BackpackData.SetQuicklySellData(dockyardData.QuickSellShape, dockyardData.QuickSellRatio);
			this.SetTrawlDataListFromServer(dockyardData.NetCabinItems.ToList<FishingItemInfo>());
			this.SetWareHouseDataListFromServer(dockyardData.TempCabinItems.ToList<FishingItemInfo>());
			this.BackpackData.RefreshPosData();
		}

		// Token: 0x060422C3 RID: 271043 RVA: 0x010F9728 File Offset: 0x010F7928
		public void UpdateDockyardData(CabinInfo dockyardData)
		{
			this.SetDockyardData(dockyardData);
			Singleton<Log>.Instance.Info(ELogModule.Dockyard, ELogAuthor.XXJ, "船舱数据刷新", default(ReadOnlySpan<ValueTuple<string, object>>));
		}

		// Token: 0x060422C4 RID: 271044 RVA: 0x010F975C File Offset: 0x010F795C
		[NullableContext(2)]
		public DockyardItemBlockOriginalData GetItemBlockData(int uniqueId)
		{
			DockyardItemBlockOriginalData backpackItemData = this.BackpackData.GetBackpackItemData(uniqueId);
			if (backpackItemData != null)
			{
				return backpackItemData;
			}
			return this.WareHouseDataMap.GetValueOrDefault(uniqueId);
		}

		// Token: 0x060422C5 RID: 271045 RVA: 0x010F9787 File Offset: 0x010F7987
		public List<PayShopGoods> GetShopDataList()
		{
			return ModelBase<PayShopModel>.Instance.GetPayShopTabData((PayShopDefine.EPayShopTabType)this.ShopId, 1, true);
		}

		// Token: 0x1700A0F8 RID: 41208
		// (get) Token: 0x060422C6 RID: 271046 RVA: 0x010F979B File Offset: 0x010F799B
		public int BackpackUseSize
		{
			get
			{
				return this.BackpackData.BackpackUseSize;
			}
		}

		// Token: 0x1700A0F9 RID: 41209
		// (get) Token: 0x060422C7 RID: 271047 RVA: 0x010F97A8 File Offset: 0x010F79A8
		public int BackpackSize
		{
			get
			{
				return this.BackpackData.BackpackSize;
			}
		}

		// Token: 0x1700A0FA RID: 41210
		// (get) Token: 0x060422C8 RID: 271048 RVA: 0x010F97B5 File Offset: 0x010F79B5
		public List<List<int>> BackpackPosDataDoublyList
		{
			get
			{
				return this.BackpackData.PosDataDoublyList;
			}
		}

		// Token: 0x060422C9 RID: 271049 RVA: 0x010F97C2 File Offset: 0x010F79C2
		public int GetItemCountByItemId(int itemId)
		{
			return this.BackpackData.GetItemCountByItemId(itemId);
		}

		// Token: 0x060422CA RID: 271050 RVA: 0x010F97D0 File Offset: 0x010F79D0
		public List<DockyardItemBlockOriginalData> GetItemListByItemId(int itemId)
		{
			return this.BackpackData.GetItemListByItemId(itemId);
		}

		// Token: 0x1700A0FB RID: 41211
		// (get) Token: 0x060422CB RID: 271051 RVA: 0x010F97E0 File Offset: 0x010F79E0
		public int ShopId
		{
			get
			{
				int dockId = ModelBase<FishingModel>.Instance.DockId;
				return ConfigBase<FishingConfig>.Instance.GetFishingPortConfig(dockId).ShopId;
			}
		}

		// Token: 0x04024DC4 RID: 150980
		private Dictionary<int, DockyardItemBlockOriginalData> TrawlDataMap = new Dictionary<int, DockyardItemBlockOriginalData>();

		// Token: 0x04024DC5 RID: 150981
		private Dictionary<int, DockyardItemBlockOriginalData> WareHouseDataMap = new Dictionary<int, DockyardItemBlockOriginalData>();

		// Token: 0x04024DC6 RID: 150982
		private DockyardBackpackOriginalData BackpackData = new DockyardBackpackOriginalData();

		// Token: 0x04024DC7 RID: 150983
		public bool IsPrintLog;

		// Token: 0x04024DC8 RID: 150984
		public bool IsNeedShowExitConfirmBox;

		// Token: 0x04024DC9 RID: 150985
		public int FishingCabinShape;
	}
}
