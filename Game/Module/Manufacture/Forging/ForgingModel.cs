using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Common;
using CSharpScript.Game.Module.Manufacture.Common;

namespace CSharpScript.Game.Module.Manufacture.Forging
{
	// Token: 0x020059A7 RID: 22951
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class ForgingModel : ModelBase<ForgingModel>
	{
		// Token: 0x0603A19C RID: 237980 RVA: 0x00EB427E File Offset: 0x00EB247E
		public void SaveLimitRefreshTime(long refreshTime)
		{
			this.LimitRefreshTime = (double)refreshTime * Singleton<TimeUtil>.Instance.Millisecond;
		}

		// Token: 0x0603A19D RID: 237981 RVA: 0x00EB4294 File Offset: 0x00EB2494
		[NullableContext(2)]
		public string GetRefreshLimitTime()
		{
			if (this.LimitRefreshTime == 0.0)
			{
				return null;
			}
			double serverTime = Singleton<TimeUtil>.Instance.GetServerTime();
			return Singleton<TimeUtil>.Instance.GetRemainTimeDataFormat(this.LimitRefreshTime - serverTime).CountDownText;
		}

		// Token: 0x0603A19E RID: 237982 RVA: 0x00EB42D8 File Offset: 0x00EB24D8
		public double GetRefreshLimitTimeValue()
		{
			if (this.LimitRefreshTime <= 0.0)
			{
				return 1.0;
			}
			double serverTime = Singleton<TimeUtil>.Instance.GetServerTime();
			return Singleton<TimeUtil>.Instance.GetRemainTimeDataFormat(this.LimitRefreshTime - serverTime).RemainingTime;
		}

		// Token: 0x0603A19F RID: 237983 RVA: 0x00EB4324 File Offset: 0x00EB2524
		protected override bool OnInit()
		{
			this.ForgingEnterFlow = new PlayFlow
			{
				StateId = ConfigCommonParamById.GetIntConfig("ForgingEnterStateId").Value,
				FlowListName = ConfigCommonParamById.GetStringConfig("ForgingEnterFlowListName"),
				FlowId = ConfigCommonParamById.GetIntConfig("ForgingEnterFlowId").Value
			};
			this.ForgingSuccessFlow = new PlayFlow
			{
				StateId = ConfigCommonParamById.GetIntConfig("ForgingSuccessStateId").Value,
				FlowListName = ConfigCommonParamById.GetStringConfig("ForgingSuccessFlowListName"),
				FlowId = ConfigCommonParamById.GetIntConfig("ForgingSuccessFlowId").Value
			};
			this.ForgingFailFlow = new PlayFlow
			{
				StateId = ConfigCommonParamById.GetIntConfig("ForgingFailStateId").Value,
				FlowListName = ConfigCommonParamById.GetStringConfig("ForgingFailFlowListName"),
				FlowId = ConfigCommonParamById.GetIntConfig("ForgingFailFlowId").Value
			};
			return true;
		}

		// Token: 0x0603A1A0 RID: 237984 RVA: 0x00EB4413 File Offset: 0x00EB2613
		protected override bool OnClear()
		{
			this.ForgingEnterFlow = null;
			this.ForgingSuccessFlow = null;
			this.ForgingFailFlow = null;
			return true;
		}

		// Token: 0x17009484 RID: 38020
		// (get) Token: 0x0603A1A1 RID: 237985 RVA: 0x00EB442B File Offset: 0x00EB262B
		// (set) Token: 0x0603A1A2 RID: 237986 RVA: 0x00EB4433 File Offset: 0x00EB2633
		public EForgingViewType CurrentForgingViewType
		{
			get
			{
				return this.ForgingViewType;
			}
			set
			{
				this.ForgingViewType = value;
			}
		}

		// Token: 0x0603A1A3 RID: 237987 RVA: 0x00EB443C File Offset: 0x00EB263C
		public void CreateForgingDataList()
		{
			if (this.ForgingDataList == null)
			{
				this.ForgingDataList = new List<IWeaponForgingData>();
			}
			this.ForgingDataList.Clear();
			foreach (ForgeFormula forgeFormula in ConfigBase<ForgingConfig>.Instance.GetForgeList())
			{
				int id = forgeFormula.Id;
				ForgeFormula? forgeFormulaById = ConfigBase<ForgingConfig>.Instance.GetForgeFormulaById(id);
				WeaponConf? weaponConfigByItemId = ConfigBase<WeaponConfig>.Instance.GetWeaponConfigByItemId(forgeFormulaById.Value.ItemId);
				IWeaponForgingData weaponForgingData = new IWeaponForgingData
				{
					MainType = EForgingListType.WeaponForging,
					ItemId = id,
					IsUnlock = 0,
					FormulaItemId = forgeFormulaById.Value.FormulaItemId,
					UniqueId = 0,
					IsNew = ModelBase<NewFlagModel>.Instance.HasNewFlag(ELocalStoragePlayerKey.ForgingLevelKey, id),
					IsForging = 0,
					Quality = weaponConfigByItemId.Value.QualityId,
					LastRoleId = 0,
					WeaponType = weaponConfigByItemId.Value.WeaponType,
					ExistStartTime = 0.0,
					ExistEndTime = 0.0,
					MadeCountInLimitTime = 0,
					TotalMakeCountInLimitTime = 0,
					SortId = forgeFormulaById.Value.SortId
				};
				this.ForgingDataList.Add(weaponForgingData);
				this.ForgingDataMap[id] = weaponForgingData;
				weaponForgingData.IsForging = ((this.CheckCanForging(id) > false) ? 1 : 0);
			}
		}

		// Token: 0x0603A1A4 RID: 237988 RVA: 0x00EB45DC File Offset: 0x00EB27DC
		private void RemoveForgingDataByItemId(int itemId)
		{
			int index = this.ForgingDataList.FindIndex((IWeaponForgingData v) => v.ItemId == itemId);
			this.ForgingDataList.RemoveAt(index);
			this.ForgingDataMap.Remove(itemId);
		}

		// Token: 0x0603A1A5 RID: 237989 RVA: 0x00EB462C File Offset: 0x00EB282C
		public bool CheckCanForging(int id)
		{
			IWeaponForgingData forgingDataById = this.GetForgingDataById(id);
			return this.CheckUnlock(forgingDataById) && this.CheckLimitCount(forgingDataById) && this.CheckCoinEnough(forgingDataById.ItemId) && this.CheckMaterialEnough(forgingDataById.ItemId);
		}

		// Token: 0x0603A1A6 RID: 237990 RVA: 0x00EB4670 File Offset: 0x00EB2870
		public bool CheckCoinEnough(int id)
		{
			ForgeFormula? forgeFormulaById = ConfigBase<ForgingConfig>.Instance.GetForgeFormulaById(id);
			return ModelBase<InventoryModel>.Instance.CheckIsCoinEnough(ControllerBase<ForgingController>.Instance.ForgingCostId, forgeFormulaById.Value.ConsumeItems());
		}

		// Token: 0x0603A1A7 RID: 237991 RVA: 0x00EB46AC File Offset: 0x00EB28AC
		public bool CheckLimitCount(IWeaponForgingData data)
		{
			return data.TotalMakeCountInLimitTime <= 0 || data.MadeCountInLimitTime < data.TotalMakeCountInLimitTime;
		}

		// Token: 0x0603A1A8 RID: 237992 RVA: 0x00EB46C7 File Offset: 0x00EB28C7
		public bool CheckUnlock(IWeaponForgingData data)
		{
			return data.IsUnlock > 0;
		}

		// Token: 0x0603A1A9 RID: 237993 RVA: 0x00EB46D4 File Offset: 0x00EB28D4
		public bool CheckMaterialEnough(int id)
		{
			foreach (OneItemConfig oneItemConfig in ConfigBase<ForgingConfig>.Instance.GetForgeFormulaById(id).Value.ConsumeItems())
			{
				int itemCountByConfigId = ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(oneItemConfig.ItemId, 0);
				if (oneItemConfig.Count > itemCountByConfigId)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x0603A1AA RID: 237994 RVA: 0x00EB4738 File Offset: 0x00EB2938
		public void UpdateForgingDataList(IList<OneForgeInfo> forgingDataList)
		{
			foreach (OneForgeInfo oneForgeInfo in forgingDataList)
			{
				int id = oneForgeInfo.Id;
				IWeaponForgingData forgingDataById = this.GetForgingDataById(id);
				if (forgingDataById != null)
				{
					forgingDataById.LastRoleId = oneForgeInfo.LastRoleId;
					forgingDataById.ExistStartTime = (double)oneForgeInfo.LimitBeginTime * Singleton<TimeUtil>.Instance.Millisecond;
					forgingDataById.ExistEndTime = (double)Singleton<MathUtils>.Instance.LongToNumber(oneForgeInfo.LimitEndTime) * Singleton<TimeUtil>.Instance.Millisecond;
					forgingDataById.MadeCountInLimitTime = oneForgeInfo.LimitForgeCount;
					forgingDataById.TotalMakeCountInLimitTime = oneForgeInfo.LimitCount;
					forgingDataById.IsUnlock = 1;
					forgingDataById.IsForging = ((this.CheckCanForging(id) > false) ? 1 : 0);
				}
			}
		}

		// Token: 0x0603A1AB RID: 237995 RVA: 0x00EB4808 File Offset: 0x00EB2A08
		public void UpdateForgingByServerConfig(IList<OneForgeInfo> forgeConfigs)
		{
			foreach (OneForgeInfo oneForgeInfo in forgeConfigs)
			{
				double num = (double)oneForgeInfo.LimitBeginTime * Singleton<TimeUtil>.Instance.Millisecond;
				double num2 = (double)oneForgeInfo.LimitEndTime * Singleton<TimeUtil>.Instance.Millisecond;
				int id = oneForgeInfo.Id;
				IWeaponForgingData forgingDataById = this.GetForgingDataById(id);
				if (forgingDataById != null)
				{
					if ((num == 0.0 && num2 == 0.0) || Singleton<TimeUtil>.Instance.IsInTimeSpan(num, num2))
					{
						forgingDataById.ExistStartTime = num;
						forgingDataById.ExistEndTime = num2;
					}
					else
					{
						this.RemoveForgingDataByItemId(id);
					}
				}
			}
		}

		// Token: 0x0603A1AC RID: 237996 RVA: 0x00EB48C4 File Offset: 0x00EB2AC4
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public List<IWeaponForgingData> GetForgingDataList()
		{
			return this.ForgingDataList;
		}

		// Token: 0x0603A1AD RID: 237997 RVA: 0x00EB48CC File Offset: 0x00EB2ACC
		[NullableContext(2)]
		public IWeaponForgingData GetForgingDataById(int id)
		{
			IWeaponForgingData result;
			if (!this.ForgingDataMap.TryGetValue(id, out result))
			{
				return null;
			}
			return result;
		}

		// Token: 0x0603A1AE RID: 237998 RVA: 0x00EB48EC File Offset: 0x00EB2AEC
		public int GetForgingRoleId(int itemId)
		{
			IWeaponForgingData forgingDataById = this.GetForgingDataById(itemId);
			if (forgingDataById != null && forgingDataById.LastRoleId > 0)
			{
				return forgingDataById.LastRoleId;
			}
			return ModelBase<PlayerInfoModel>.Instance.GetPlayerRoleId();
		}

		// Token: 0x0603A1AF RID: 237999 RVA: 0x00EB4920 File Offset: 0x00EB2B20
		public List<ISingleItemInfo> GetForgingMaterialList(int itemId)
		{
			List<ISingleItemInfo> list = new List<ISingleItemInfo>();
			foreach (OneItemConfig oneItemConfig in ConfigBase<ForgingConfig>.Instance.GetForgeFormulaById(itemId).Value.ConsumeItems())
			{
				list.Add(new ISingleItemInfo
				{
					Proto_ItemId = oneItemConfig.ItemId,
					Proto_ItemNum = oneItemConfig.Count,
					Proto_IsUnlock = true
				});
			}
			return list;
		}

		// Token: 0x0603A1B0 RID: 238000 RVA: 0x00EB4994 File Offset: 0x00EB2B94
		public void UpdateForgingItemList(IList<SingleItemInfo> itemList)
		{
			if (this.ForgingItemList == null)
			{
				this.ForgingItemList = new List<ICommonPopItemData>();
			}
			this.ForgingItemList.Clear();
			foreach (SingleItemInfo singleItemInfo in itemList)
			{
				this.ForgingItemList.Add(new ICommonPopItemData
				{
					ItemId = singleItemInfo.ItemId,
					ItemNum = singleItemInfo.ItemNum
				});
			}
		}

		// Token: 0x0603A1B1 RID: 238001 RVA: 0x00EB4A1C File Offset: 0x00EB2C1C
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public List<ICommonPopItemData> GetForgingItemList()
		{
			return this.ForgingItemList;
		}

		// Token: 0x17009485 RID: 38021
		// (get) Token: 0x0603A1B2 RID: 238002 RVA: 0x00EB4A24 File Offset: 0x00EB2C24
		// (set) Token: 0x0603A1B3 RID: 238003 RVA: 0x00EB4A2C File Offset: 0x00EB2C2C
		public int CurrentForgingRoleId
		{
			get
			{
				return this.ForgingRoleId;
			}
			set
			{
				this.ForgingRoleId = value;
			}
		}

		// Token: 0x0603A1B4 RID: 238004 RVA: 0x00EB4A38 File Offset: 0x00EB2C38
		public void UpdateHelpRoleItemDataList()
		{
			if (this.ForgingRoleItemDataList == null)
			{
				this.ForgingRoleItemDataList = new List<ICommonRoleItemData>();
			}
			this.ForgingRoleItemDataList.Clear();
			foreach (RoleInstance roleInstance in ModelBase<RoleModel>.Instance.GetRoleList())
			{
				this.ForgingRoleItemDataList.Add(new ICommonRoleItemData
				{
					RoleId = roleInstance.GetRoleId(),
					RoleName = roleInstance.GetRoleRealName(),
					RoleIcon = roleInstance.GetRoleConfig().RoleHeadIcon,
					IsBuff = false,
					ItemId = 0
				});
			}
		}

		// Token: 0x0603A1B5 RID: 238005 RVA: 0x00EB4ACC File Offset: 0x00EB2CCC
		public List<ICommonRoleItemData> GetHelpRoleItemDataList(int itemId)
		{
			if (this.ForgingRoleItemDataList == null)
			{
				this.UpdateHelpRoleItemDataList();
			}
			foreach (ICommonRoleItemData commonRoleItemData in this.ForgingRoleItemDataList)
			{
				commonRoleItemData.ItemId = itemId;
				commonRoleItemData.IsBuff = ControllerBase<ForgingController>.Instance.CheckIsBuff(commonRoleItemData.RoleId, itemId);
			}
			this.ForgingRoleItemDataList.Sort(new Comparison<ICommonRoleItemData>(this.SortHelpRoleItemDataList));
			return this.ForgingRoleItemDataList;
		}

		// Token: 0x0603A1B6 RID: 238006 RVA: 0x00EB4B64 File Offset: 0x00EB2D64
		private int SortHelpRoleItemDataList(ICommonRoleItemData dataA, ICommonRoleItemData dataB)
		{
			if (dataA.IsBuff == dataB.IsBuff)
			{
				return dataA.RoleId - dataB.RoleId;
			}
			if (dataA.IsBuff)
			{
				return -1;
			}
			return 1;
		}

		// Token: 0x04020F3B RID: 134971
		private double LimitRefreshTime = -1.0;

		// Token: 0x04020F3C RID: 134972
		public long? CurrentInteractCreatureDataLongId;

		// Token: 0x04020F3D RID: 134973
		private EForgingViewType ForgingViewType;

		// Token: 0x04020F3E RID: 134974
		[Nullable(2)]
		public PlayFlow ForgingEnterFlow;

		// Token: 0x04020F3F RID: 134975
		[Nullable(2)]
		public PlayFlow ForgingSuccessFlow;

		// Token: 0x04020F40 RID: 134976
		[Nullable(2)]
		public PlayFlow ForgingFailFlow;

		// Token: 0x04020F41 RID: 134977
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private List<IWeaponForgingData> ForgingDataList;

		// Token: 0x04020F42 RID: 134978
		private readonly Dictionary<int, IWeaponForgingData> ForgingDataMap = new Dictionary<int, IWeaponForgingData>();

		// Token: 0x04020F43 RID: 134979
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private List<ICommonPopItemData> ForgingItemList;

		// Token: 0x04020F44 RID: 134980
		private int ForgingRoleId;

		// Token: 0x04020F45 RID: 134981
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private List<ICommonRoleItemData> ForgingRoleItemDataList;
	}
}
