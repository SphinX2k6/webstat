using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Plot.Flow;
using Google.Protobuf.Collections;

namespace CSharpScript.Game.Module.MingSu
{
	// Token: 0x02005738 RID: 22328
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Model(0)]
	public class MingSuModel : ModelBase<MingSuModel>
	{
		// Token: 0x06038D15 RID: 232725 RVA: 0x00E64622 File Offset: 0x00E62822
		protected override bool OnInit()
		{
			this.InitData();
			Singleton<EventSystem>.Instance.Add<int, int>(EEventName.OnCommonItemCountAnyChange, new Action<int, int>(this.OnCommonItemCountAnyChange));
			return true;
		}

		// Token: 0x06038D16 RID: 232726 RVA: 0x00E64647 File Offset: 0x00E62847
		protected override bool OnClear()
		{
			Singleton<EventSystem>.Instance.Remove<int, int>(EEventName.OnCommonItemCountAnyChange, new Action<int, int>(this.OnCommonItemCountAnyChange));
			return true;
		}

		// Token: 0x06038D17 RID: 232727 RVA: 0x00E64666 File Offset: 0x00E62866
		public void InitData()
		{
			this.InitMingSuMap();
			this.InitDragonPoolCompositeRewardIdSet();
			this.InitMingSuItemIdSet();
		}

		// Token: 0x06038D18 RID: 232728 RVA: 0x00E6467A File Offset: 0x00E6287A
		public bool IsIdInDragonPoolCompositeRewardIdSet(int id)
		{
			return this.IsDragonPoolCompositeRewardIdSet.Contains(id);
		}

		// Token: 0x06038D19 RID: 232729 RVA: 0x00E64688 File Offset: 0x00E62888
		public void SetCurrentDragonPoolId(int dragonPoolId)
		{
			this.CurrentDragonPoolId = dragonPoolId;
		}

		// Token: 0x06038D1A RID: 232730 RVA: 0x00E64691 File Offset: 0x00E62891
		public int GetCurrentDragonPoolId()
		{
			return this.CurrentDragonPoolId;
		}

		// Token: 0x06038D1B RID: 232731 RVA: 0x00E64699 File Offset: 0x00E62899
		public void SetCollectItemConfigId(int itemConfigId)
		{
			this.CollectItemConfigId = itemConfigId;
		}

		// Token: 0x06038D1C RID: 232732 RVA: 0x00E646A2 File Offset: 0x00E628A2
		public int GetCollectItemConfigId()
		{
			return this.CollectItemConfigId;
		}

		// Token: 0x06038D1D RID: 232733 RVA: 0x00E646AC File Offset: 0x00E628AC
		public void RefreshDragonPoolActiveStatus(int dragonPoolId, int finishedLevel)
		{
			MingSuInstance mingSuInstance;
			if (this.DragonPoolInstanceMap.TryGetValue(dragonPoolId, out mingSuInstance))
			{
				mingSuInstance.SetDragonPoolState(finishedLevel);
			}
		}

		// Token: 0x06038D1E RID: 232734 RVA: 0x00E646D0 File Offset: 0x00E628D0
		public void RefreshDragonPoolDropItems(DragonPoolConf dragonPoolConf)
		{
			MingSuInstance mingSuInstance;
			if (!this.DragonPoolInstanceMap.TryGetValue(dragonPoolConf.DragonPoolId, out mingSuInstance))
			{
				return;
			}
			RepeatedField<ItemDict> dropItems = dragonPoolConf.DropItems;
			ItemDict[] array = new ItemDict[dropItems.Count];
			for (int i = 0; i < dropItems.Count; i++)
			{
				array[i] = dropItems[i];
			}
			mingSuInstance.SetDropItemList(array);
		}

		// Token: 0x06038D1F RID: 232735 RVA: 0x00E64728 File Offset: 0x00E62928
		public void RefreshDarkCoastGuardInfo(int dragonPoolId, int[] guardIds, int[] receivedList)
		{
			DarkCoastDeliveryData darkCoastDeliveryData = this.GetDragonPoolInstanceById(dragonPoolId) as DarkCoastDeliveryData;
			if (darkCoastDeliveryData == null)
			{
				return;
			}
			darkCoastDeliveryData.RefreshLevelDataState(guardIds, receivedList);
		}

		// Token: 0x06038D20 RID: 232736 RVA: 0x00E64750 File Offset: 0x00E62950
		public void RefreshDragonPoolLevel(int dragonPoolId, int level)
		{
			MingSuInstance mingSuInstance;
			if (this.DragonPoolInstanceMap.TryGetValue(dragonPoolId, out mingSuInstance))
			{
				mingSuInstance.SetDragonPoolLevel(level);
			}
		}

		// Token: 0x06038D21 RID: 232737 RVA: 0x00E64774 File Offset: 0x00E62974
		public void RefreshDragonPoolHadCoreCount(int dragonPoolId, int coreCount)
		{
			MingSuInstance mingSuInstance;
			if (this.DragonPoolInstanceMap.TryGetValue(dragonPoolId, out mingSuInstance))
			{
				mingSuInstance.SetHadCoreCount(coreCount);
			}
		}

		// Token: 0x06038D22 RID: 232738 RVA: 0x00E64798 File Offset: 0x00E62998
		public void RefreshDragonPoolLevelGains(int dragonPoolId, int levelGain)
		{
			MingSuInstance mingSuInstance;
			if (this.DragonPoolInstanceMap.TryGetValue(dragonPoolId, out mingSuInstance))
			{
				mingSuInstance.SetLevelGainList(levelGain);
			}
		}

		// Token: 0x06038D23 RID: 232739 RVA: 0x00E647BC File Offset: 0x00E629BC
		public void UpdateDragonPoolInfoMap(RepeatedField<DragonPoolInfo> dragonPoolInfoList)
		{
			for (int i = 0; i < dragonPoolInfoList.Count; i++)
			{
				this.DoUpdateDragonPoolInfoMap(dragonPoolInfoList[i]);
			}
		}

		// Token: 0x06038D24 RID: 232740 RVA: 0x00E647E7 File Offset: 0x00E629E7
		public void DoUpdateDragonPoolInfoMap(DragonPoolInfo dragonPoolInfo)
		{
			this.RefreshDragonPoolActiveStatus(dragonPoolInfo.DragonPoolId, dragonPoolInfo.LevelGains);
			this.RefreshDragonPoolLevel(dragonPoolInfo.DragonPoolId, dragonPoolInfo.Level);
			this.RefreshDragonPoolHadCoreCount(dragonPoolInfo.DragonPoolId, dragonPoolInfo.InjectedCoreItemCount);
		}

		// Token: 0x06038D25 RID: 232741 RVA: 0x00E64820 File Offset: 0x00E62A20
		private void InitMingSuMap()
		{
			IReadOnlyList<DragonPool> configList = ConfigDragonPoolAll.GetConfigList(true);
			if (configList != null)
			{
				for (int i = 0; i < configList.Count; i++)
				{
					DragonPool dragonPool = configList[i];
					MingSuInstance mingSuInstanceById = this.GetMingSuInstanceById(dragonPool.Id);
					this.DragonPoolInstanceMap[dragonPool.Id] = mingSuInstanceById;
				}
			}
		}

		// Token: 0x06038D26 RID: 232742 RVA: 0x00E64874 File Offset: 0x00E62A74
		private void InitDragonPoolCompositeRewardIdSet()
		{
			List<int> isDragonPoolCompositeRewardIdList = ConfigBase<CollectItemConfig>.Instance.GetIsDragonPoolCompositeRewardIdList();
			if (isDragonPoolCompositeRewardIdList == null)
			{
				return;
			}
			for (int i = 0; i < isDragonPoolCompositeRewardIdList.Count; i++)
			{
				this.IsDragonPoolCompositeRewardIdSet.Add(isDragonPoolCompositeRewardIdList[i]);
			}
		}

		// Token: 0x06038D27 RID: 232743 RVA: 0x00E648B4 File Offset: 0x00E62AB4
		private void InitMingSuItemIdSet()
		{
			IReadOnlyList<DragonPool> allDragonPoolConfigList = ConfigBase<CollectItemConfig>.Instance.GetAllDragonPoolConfigList();
			if (allDragonPoolConfigList == null)
			{
				return;
			}
			for (int i = 0; i < allDragonPoolConfigList.Count; i++)
			{
				DragonPool dragonPool = allDragonPoolConfigList[i];
				this.MingSuItemIdSet.Add(dragonPool.CoreId);
			}
		}

		// Token: 0x06038D28 RID: 232744 RVA: 0x00E648FC File Offset: 0x00E62AFC
		private MingSuInstance GetMingSuInstanceById(int id)
		{
			if (id == 3)
			{
				return new DarkCoastDeliveryData(id);
			}
			return new MingSuInstance(id);
		}

		// Token: 0x06038D29 RID: 232745 RVA: 0x00E64910 File Offset: 0x00E62B10
		[NullableContext(2)]
		public MingSuInstance GetDragonPoolInstanceById(int dragonPoolId)
		{
			MingSuInstance result;
			this.DragonPoolInstanceMap.TryGetValue(dragonPoolId, out result);
			return result;
		}

		// Token: 0x06038D2A RID: 232746 RVA: 0x00E64930 File Offset: 0x00E62B30
		public int GetTargetDragonPoolLevelById(int dragonPoolId)
		{
			MingSuInstance dragonPoolInstanceById = this.GetDragonPoolInstanceById(dragonPoolId);
			if (dragonPoolInstanceById != null)
			{
				return dragonPoolInstanceById.GetDragonPoolLevel();
			}
			return 0;
		}

		// Token: 0x06038D2B RID: 232747 RVA: 0x00E64950 File Offset: 0x00E62B50
		public int GetTargetDragonPoolMaxLevelById(int dragonPoolId)
		{
			MingSuInstance dragonPoolInstanceById = this.GetDragonPoolInstanceById(dragonPoolId);
			if (dragonPoolInstanceById != null)
			{
				return dragonPoolInstanceById.GetDragonPoolMaxLevel();
			}
			return 0;
		}

		// Token: 0x06038D2C RID: 232748 RVA: 0x00E64970 File Offset: 0x00E62B70
		public int GetTargetDragonPoolCoreCountById(int dragonPoolId)
		{
			MingSuInstance dragonPoolInstanceById = this.GetDragonPoolInstanceById(dragonPoolId);
			if (dragonPoolInstanceById != null)
			{
				return dragonPoolInstanceById.GetHadCoreCount();
			}
			return 0;
		}

		// Token: 0x06038D2D RID: 232749 RVA: 0x00E64990 File Offset: 0x00E62B90
		public int GetTargetDragonPoolLevelNeedCoreById(int dragonPoolId, int level)
		{
			MingSuInstance dragonPoolInstanceById = this.GetDragonPoolInstanceById(dragonPoolId);
			if (dragonPoolInstanceById != null)
			{
				return dragonPoolInstanceById.GetNeedCoreCount(level);
			}
			return 0;
		}

		// Token: 0x06038D2E RID: 232750 RVA: 0x00E649B4 File Offset: 0x00E62BB4
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public List<IRewardItemData> GetTargetDragonPoolLevelRewardById(int dragonPoolId, int level)
		{
			MingSuInstance dragonPoolInstanceById = this.GetDragonPoolInstanceById(dragonPoolId);
			if (dragonPoolInstanceById == null)
			{
				return null;
			}
			ItemDict[] dropItemList = dragonPoolInstanceById.GetDropItemList();
			if (dropItemList == null || dropItemList.Length <= level)
			{
				return null;
			}
			RepeatedField<ItemEntry> items = dropItemList[level].Items;
			if (items == null || items.Count == 0)
			{
				return null;
			}
			List<IRewardItemData> list = new List<IRewardItemData>();
			for (int i = 0; i < items.Count; i++)
			{
				ItemEntry itemEntry = items[i];
				ItemConfig itemConfigData = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(itemEntry.ItemId);
				if (itemConfigData != null)
				{
					list.Add(new RewardItemData
					{
						ItemInfo = itemConfigData,
						Count = itemEntry.ItemCount
					});
				}
			}
			return list;
		}

		// Token: 0x06038D2F RID: 232751 RVA: 0x00E64A54 File Offset: 0x00E62C54
		[NullableContext(2)]
		public List<TItem> GetTargetDragonPoolLevelRewardByIdEx(int dragonPoolId, int level)
		{
			MingSuInstance dragonPoolInstanceById = this.GetDragonPoolInstanceById(dragonPoolId);
			if (dragonPoolInstanceById == null)
			{
				return null;
			}
			ItemDict[] dropItemList = dragonPoolInstanceById.GetDropItemList();
			if (dropItemList == null || dropItemList.Length <= level)
			{
				return null;
			}
			RepeatedField<ItemEntry> items = dropItemList[level].Items;
			if (items == null || items.Count == 0)
			{
				return null;
			}
			List<TItem> list = new List<TItem>();
			for (int i = 0; i < items.Count; i++)
			{
				ItemEntry itemEntry = items[i];
				list.Add(new TItem(new InventoryDefine.GetItemData(itemEntry.ItemId, 0), itemEntry.ItemCount));
			}
			return list;
		}

		// Token: 0x06038D30 RID: 232752 RVA: 0x00E64ADC File Offset: 0x00E62CDC
		public int GetTargetDragonPoolCoreById(int dragonPoolId)
		{
			MingSuInstance dragonPoolInstanceById = this.GetDragonPoolInstanceById(dragonPoolId);
			if (dragonPoolInstanceById != null)
			{
				return dragonPoolInstanceById.GetCoreId();
			}
			return 0;
		}

		// Token: 0x06038D31 RID: 232753 RVA: 0x00E64AFC File Offset: 0x00E62CFC
		public int GetTargetDragonPoolActiveById(int dragonPoolId)
		{
			MingSuInstance dragonPoolInstanceById = this.GetDragonPoolInstanceById(dragonPoolId);
			if (dragonPoolInstanceById != null)
			{
				return dragonPoolInstanceById.GetDragonPoolState();
			}
			return 0;
		}

		// Token: 0x06038D32 RID: 232754 RVA: 0x00E64B1C File Offset: 0x00E62D1C
		public int GetItemCount(int itemId)
		{
			return ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(itemId, 0);
		}

		// Token: 0x06038D33 RID: 232755 RVA: 0x00E64B2A File Offset: 0x00E62D2A
		public ItemInfo? GetItemInfoById(int itemId)
		{
			return ConfigItemInfoById.GetConfig(itemId, true);
		}

		// Token: 0x06038D34 RID: 232756 RVA: 0x00E64B34 File Offset: 0x00E62D34
		[NullableContext(2)]
		public DarkCoastDeliveryLevelData GetDarkCoastDeliveryDataByLevelPlayId(int levelPlayId)
		{
			DarkCoastDeliveryData darkCoastDeliveryData = this.GetDragonPoolInstanceById(3) as DarkCoastDeliveryData;
			if (darkCoastDeliveryData == null)
			{
				return null;
			}
			List<DarkCoastDeliveryLevelData> levelDataList = darkCoastDeliveryData.GetLevelDataList();
			for (int i = 0; i < levelDataList.Count; i++)
			{
				DarkCoastDeliveryLevelData darkCoastDeliveryLevelData = levelDataList[i];
				if (darkCoastDeliveryLevelData.Config.LevelPlayId == levelPlayId)
				{
					return darkCoastDeliveryLevelData;
				}
			}
			return null;
		}

		// Token: 0x06038D35 RID: 232757 RVA: 0x00E64B88 File Offset: 0x00E62D88
		public bool CheckUp(int dragonPoolId)
		{
			int i = this.GetTargetDragonPoolLevelById(dragonPoolId);
			int[] goalList = this.GetDragonPoolInstanceById(dragonPoolId).GetGoalList();
			int targetDragonPoolMaxLevelById = this.GetTargetDragonPoolMaxLevelById(dragonPoolId);
			int targetDragonPoolCoreCountById = this.GetTargetDragonPoolCoreCountById(dragonPoolId);
			int num = 0;
			while (i < targetDragonPoolMaxLevelById)
			{
				int num2 = goalList[i];
				num += num2;
				i++;
			}
			num -= targetDragonPoolCoreCountById;
			int targetDragonPoolCoreById = this.GetTargetDragonPoolCoreById(dragonPoolId);
			int itemCount = this.GetItemCount(targetDragonPoolCoreById);
			ItemInfo? itemInfoById = this.GetItemInfoById(targetDragonPoolCoreById);
			if (itemCount == 0)
			{
				return false;
			}
			string localTextNew = ConfigMultiTextLang.GetLocalTextNew(itemInfoById.Value.Name, null);
			this.SetUpData(new UpData
			{
				UseCoreCount = ((itemCount >= num) ? num : itemCount),
				CoreName = (localTextNew ?? "")
			});
			return true;
		}

		// Token: 0x06038D36 RID: 232758 RVA: 0x00E64C44 File Offset: 0x00E62E44
		public bool CanLevelUp(int dragonPoolId)
		{
			int targetDragonPoolLevelById = this.GetTargetDragonPoolLevelById(dragonPoolId);
			MingSuInstance dragonPoolInstanceById = this.GetDragonPoolInstanceById(dragonPoolId);
			if (dragonPoolInstanceById == null)
			{
				return false;
			}
			int needCoreCount = dragonPoolInstanceById.GetNeedCoreCount(targetDragonPoolLevelById);
			int hadCoreCount = dragonPoolInstanceById.GetHadCoreCount();
			int itemCount = this.GetItemCount(dragonPoolInstanceById.GetCoreId());
			return hadCoreCount + itemCount >= needCoreCount;
		}

		// Token: 0x06038D37 RID: 232759 RVA: 0x00E64C8C File Offset: 0x00E62E8C
		public int GetCanUpPoolId()
		{
			int result = 0;
			foreach (KeyValuePair<int, MingSuInstance> keyValuePair in this.DragonPoolInstanceMap)
			{
				int key = keyValuePair.Key;
				MingSuInstance value = keyValuePair.Value;
				int dragonPoolLevel = value.GetDragonPoolLevel();
				int num = value.GetNeedCoreCount(dragonPoolLevel) - value.GetHadCoreCount();
				int targetDragonPoolCoreById = this.GetTargetDragonPoolCoreById(key);
				if (this.GetItemCount(targetDragonPoolCoreById) >= num)
				{
					result = key;
					break;
				}
			}
			return result;
		}

		// Token: 0x06038D38 RID: 232760 RVA: 0x00E64D24 File Offset: 0x00E62F24
		private void SetUpData(IUpData upData)
		{
			EConfirmBoxConfigId configId = EConfirmBoxConfigId.MingsuTip;
			this.UpData = new ConfirmBoxDataNew(configId);
			this.UpData.SetTextArgs(new string[]
			{
				upData.CoreName,
				upData.UseCoreCount.ToString()
			});
		}

		// Token: 0x06038D39 RID: 232761 RVA: 0x00E64D6B File Offset: 0x00E62F6B
		[NullableContext(2)]
		public ConfirmBoxDataNew GetUpData()
		{
			return this.UpData;
		}

		// Token: 0x17009131 RID: 37169
		// (get) Token: 0x06038D3B RID: 232763 RVA: 0x00E64D7C File Offset: 0x00E62F7C
		// (set) Token: 0x06038D3A RID: 232762 RVA: 0x00E64D73 File Offset: 0x00E62F73
		public int MingSuLastLevel
		{
			get
			{
				return this.LastLevel;
			}
			set
			{
				this.LastLevel = value;
			}
		}

		// Token: 0x06038D3C RID: 232764 RVA: 0x00E64D84 File Offset: 0x00E62F84
		private void OnCommonItemCountAnyChange(int configId, int count)
		{
			if (!this.MingSuItemIdSet.Contains(configId))
			{
				return;
			}
			DragonPool? dragonPoolConfigByCoreId = ConfigBase<CollectItemConfig>.Instance.GetDragonPoolConfigByCoreId(configId);
			if (dragonPoolConfigByCoreId == null)
			{
				return;
			}
			if (!this.CheckDragonPoolJustCanLevelUp(dragonPoolConfigByCoreId.Value.Id))
			{
				return;
			}
			if (dragonPoolConfigByCoreId.Value.QuestId == 0)
			{
				if (dragonPoolConfigByCoreId.Value.CanLevelUpTipsLength == 3)
				{
					string flowListName = dragonPoolConfigByCoreId.Value.CanLevelUpTips(0);
					int flowId = int.Parse(dragonPoolConfigByCoreId.Value.CanLevelUpTips(1));
					int stateId = int.Parse(dragonPoolConfigByCoreId.Value.CanLevelUpTips(2));
					ControllerBase<FlowController>.Instance.StartFlow(flowListName, flowId, stateId, null, 0L, false, false, false, null);
				}
				return;
			}
			int questState = (int)ModelBase<QuestNewModel>.Instance.GetQuestState(dragonPoolConfigByCoreId.Value.QuestId);
			int[] plotStateListArray = dragonPoolConfigByCoreId.Value.GetPlotStateListArray();
			if (plotStateListArray == null || plotStateListArray.Length <= questState)
			{
				return;
			}
			int num = plotStateListArray[questState];
			if (num == 0)
			{
				return;
			}
			MingSuPlot? mingSuPlotConfigById = ConfigBase<CollectItemConfig>.Instance.GetMingSuPlotConfigById(num);
			if (mingSuPlotConfigById == null || mingSuPlotConfigById.Value.CanLevelUpTipsLength < 3)
			{
				return;
			}
			string flowListName2 = mingSuPlotConfigById.Value.CanLevelUpTips(0);
			int flowId2 = int.Parse(mingSuPlotConfigById.Value.CanLevelUpTips(1));
			int stateId2 = int.Parse(mingSuPlotConfigById.Value.CanLevelUpTips(2));
			ControllerBase<FlowController>.Instance.StartFlow(flowListName2, flowId2, stateId2, null, 0L, false, false, false, null);
		}

		// Token: 0x06038D3D RID: 232765 RVA: 0x00E64F14 File Offset: 0x00E63114
		private bool CheckDragonPoolJustCanLevelUp(int dragonPoolId)
		{
			MingSuInstance dragonPoolInstanceById = this.GetDragonPoolInstanceById(dragonPoolId);
			int[] goalList = dragonPoolInstanceById.GetGoalList();
			int targetDragonPoolCoreCountById = this.GetTargetDragonPoolCoreCountById(dragonPoolId);
			int itemCount = this.GetItemCount(dragonPoolInstanceById.GetCoreId());
			int num = targetDragonPoolCoreCountById + itemCount;
			int targetDragonPoolMaxLevelById = this.GetTargetDragonPoolMaxLevelById(dragonPoolId);
			int targetDragonPoolLevelById = this.GetTargetDragonPoolLevelById(dragonPoolId);
			int num2 = 0;
			for (int i = targetDragonPoolLevelById; i < targetDragonPoolMaxLevelById; i++)
			{
				int num3 = goalList[i];
				num2 += num3;
				if (num == num2)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x040205E5 RID: 132581
		private readonly Dictionary<int, MingSuInstance> DragonPoolInstanceMap = new Dictionary<int, MingSuInstance>();

		// Token: 0x040205E6 RID: 132582
		private readonly HashSet<int> IsDragonPoolCompositeRewardIdSet = new HashSet<int>();

		// Token: 0x040205E7 RID: 132583
		[Nullable(2)]
		private ConfirmBoxDataNew UpData;

		// Token: 0x040205E8 RID: 132584
		private int CurrentDragonPoolId;

		// Token: 0x040205E9 RID: 132585
		[Nullable(2)]
		public object UpgradeFlow;

		// Token: 0x040205EA RID: 132586
		public int CurrentPreviewLevel;

		// Token: 0x040205EB RID: 132587
		private int CollectItemConfigId;

		// Token: 0x040205EC RID: 132588
		public long? CurrentInteractCreatureDataLongId;

		// Token: 0x040205ED RID: 132589
		private readonly HashSet<int> MingSuItemIdSet = new HashSet<int>();

		// Token: 0x040205EE RID: 132590
		private int LastLevel;
	}
}
