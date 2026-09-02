using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.Common.NumberSelect;
using CSharpScript.Game.Module.Cook.View;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.Manufacture.Common;
using CSharpScript.Game.Module.Manufacture.Common.Item;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Cook
{
	// Token: 0x02005DFC RID: 24060
	[NullableContext(1)]
	[Nullable(0)]
	public class CookingIngredientsVerticalView : UiPanelBase
	{
		// Token: 0x170098D6 RID: 39126
		// (get) Token: 0x0603C87F RID: 247935 RVA: 0x00F5FA2B File Offset: 0x00F5DC2B
		public int CurrentSetCount
		{
			get
			{
				return this.Count;
			}
		}

		// Token: 0x0603C880 RID: 247936 RVA: 0x00F5FA34 File Offset: 0x00F5DC34
		protected unsafe override void OnRegisterComponent()
		{
			int num = 22;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(19, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(17, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(18, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(20, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(21, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(22, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(23, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(24, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(25, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(13, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(26, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>();
		}

		// Token: 0x0603C881 RID: 247937 RVA: 0x00F5FD50 File Offset: 0x00F5DF50
		protected override UniTask OnBeforeStartAsync()
		{
			CookingIngredientsVerticalView.<OnBeforeStartAsync>d__14 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<CookingIngredientsVerticalView.<OnBeforeStartAsync>d__14>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603C882 RID: 247938 RVA: 0x00F5FD94 File Offset: 0x00F5DF94
		protected override void OnStart()
		{
			base.GetItem(18).SetUIActive(false);
			base.GetItem(1).SetUIActive(false);
			base.GetItem(16).SetUIActive(true);
			base.GetItem(18).SetUIActive(true);
			base.GetItem(22).SetUIActive(false);
			base.GetText(23).ShowTextNew("NeedMaterialTitleText");
			base.GetText(17).ShowTextNew("PrefabTextItem_MaterialChoose_Text");
			UUIItem item = base.GetItem(8);
			this.NumberSelect = new NumberSelectComponent(item);
			INumberSelectData data = new INumberSelectData
			{
				MaxNumber = 0,
				ValueChangeFunction = new Action<int>(this.SetSum)
			};
			this.NumberSelect.Init(data);
			this.NumberSelect.SetUiActive(true);
			this.NumberSelect.SetNumberSelectTipsVisible(false);
			this.NumberSelect.SetAddReduceButtonActive(true);
			base.GetText(12).SetUIActive(false);
			this.UnlockMaterialComponent = new MediumItemGrid();
			this.UnlockMaterialComponent.Initialize(base.GetItem(21).GetOwner());
			this.UnlockMaterialComponent.BindOnCanExecuteChange((object _, bool _, EToggleState _) => false);
			this.UnlockMaterialComponent.BindOnExtendToggleClicked(delegate(MediumItemGridExtendCallback callbackParameter)
			{
				int itemId = (int)callbackParameter.Data;
				ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(itemId, true, null);
			});
		}

		// Token: 0x0603C883 RID: 247939 RVA: 0x00F5FEF2 File Offset: 0x00F5E0F2
		protected override void OnBeforeDestroy()
		{
			this.SvInfoView = null;
			this.MaterialScrollView = null;
			this.OnChangeMaterialSelectionDelegate = null;
		}

		// Token: 0x0603C884 RID: 247940 RVA: 0x00F5FF0C File Offset: 0x00F5E10C
		private ManufactureMaterialItem OnMaterialItemCreate()
		{
			ManufactureMaterialItem manufactureMaterialItem = new ManufactureMaterialItem();
			manufactureMaterialItem.BindOnCanExecuteChange((object _, bool _, EToggleState _) => false);
			manufactureMaterialItem.BindOnExtendToggleClicked(delegate(MediumItemGridExtendCallback callbackParameter)
			{
				ISingleItemInfo singleItemInfo = callbackParameter.Data as ISingleItemInfo;
				if (singleItemInfo.Proto_IsUnlock)
				{
					ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(singleItemInfo.Proto_ItemId, true, null);
					return;
				}
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("ItemSelectCookUnlockTip", Array.Empty<object>());
			});
			return manufactureMaterialItem;
		}

		// Token: 0x0603C885 RID: 247941 RVA: 0x00F5FF68 File Offset: 0x00F5E168
		private void OnClickChangeRole()
		{
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.OpenCookRole, this.ItemData.ItemId);
		}

		// Token: 0x0603C886 RID: 247942 RVA: 0x00F5FF88 File Offset: 0x00F5E188
		private void SetSum(int sum)
		{
			this.Count = sum;
			this.RefreshMaterialNeedNum();
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(10), "Text_ItemSelectCookQuantityTip_text", new <>z__ReadOnlySingleElementList<object>(this.Count));
			if (this.ItemData != null && this.ItemData.MainType == ECookListType.Cooking)
			{
				this.RefreshProficiency((ICookingData)this.ItemData, this.Count);
			}
			if (this.ItemData != null)
			{
				int maxCreateCount = ControllerBase<CookController>.Instance.GetMaxCreateCount(this.ItemData.ItemId, this.ItemData.MainType);
				this.NumberSelect.SetAddButtonInteractive(sum < maxCreateCount);
				this.NumberSelect.SetReduceButtonInteractive(sum > 1);
			}
		}

		// Token: 0x0603C887 RID: 247943 RVA: 0x00F6003C File Offset: 0x00F5E23C
		private bool CheckDataValid(object itemData)
		{
			if (itemData == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.Cook, ELogAuthor.LK, "缺少itemData数据", default(ReadOnlySpan<ValueTuple<string, object>>));
				return false;
			}
			return true;
		}

		// Token: 0x0603C888 RID: 247944 RVA: 0x00F60070 File Offset: 0x00F5E270
		private void SetRecommendedRoleTexture(ICookingData itemData)
		{
			if (!this.CheckDataValid(itemData))
			{
				return;
			}
			int? currentCookRoleId = ModelBase<CookModel>.Instance.CurrentCookRoleId;
			if (currentCookRoleId == null)
			{
				currentCookRoleId = new int?(ModelBase<CookModel>.Instance.GetCookRoleId(itemData.ItemId));
				ModelBase<CookModel>.Instance.CurrentCookRoleId = currentCookRoleId;
			}
			this.ProficiencyViewComponent.SetRoleTexture(currentCookRoleId.Value, itemData.ItemId);
		}

		// Token: 0x0603C889 RID: 247945 RVA: 0x00F600D8 File Offset: 0x00F5E2D8
		private void RefreshMaterialNeedNum()
		{
			this.RefreshCost(this.HasCoin, this.SingleNeedCoinCount * this.Count);
			GenericScrollViewNew<ManufactureMaterialItem, ISingleItemInfo> materialScrollView = this.MaterialScrollView;
			List<ManufactureMaterialItem> list = (materialScrollView != null) ? materialScrollView.GetScrollItemList() : null;
			if (list == null)
			{
				return;
			}
			foreach (ManufactureMaterialItem manufactureMaterialItem in list)
			{
				manufactureMaterialItem.SetTimes(this.Count);
			}
		}

		// Token: 0x0603C88A RID: 247946 RVA: 0x00F6015C File Offset: 0x00F5E35C
		private void SetTypeName(string tag, ECookListType cookType)
		{
			string textById = ConfigBase<TextConfig>.Instance.GetTextById(tag);
			if (cookType == ECookListType.Cooking)
			{
				this.SvInfoView.SetTypeName(null);
				this.ProficiencyViewComponent.SetTypeContent(textById);
				return;
			}
			if (cookType != ECookListType.Machining)
			{
				this.SvInfoView.SetTypeName(null);
				this.ProficiencyViewComponent.SetTypeContent(null);
				return;
			}
			this.SvInfoView.SetTypeName(textById);
			this.ProficiencyViewComponent.SetTypeContent(null);
		}

		// Token: 0x0603C88B RID: 247947 RVA: 0x00F601C8 File Offset: 0x00F5E3C8
		private void RefreshLimitTime(ICookingData itemData)
		{
			if (itemData.ExistEndTime <= 0.0)
			{
				base.GetItem(24).SetUIActive(false);
				this.NumberSelect.ResetLimitMaxValue();
				return;
			}
			base.GetItem(24).SetUIActive(true);
			global::CommonDefine.ICountDown remainTimeDataFormat = Singleton<TimeUtil>.Instance.GetRemainTimeDataFormat(itemData.ExistEndTime - Singleton<TimeUtil>.Instance.GetServerTime());
			base.GetText(25).SetText(remainTimeDataFormat.CountDownText, true);
		}

		// Token: 0x0603C88C RID: 247948 RVA: 0x00F60240 File Offset: 0x00F5E440
		[NullableContext(2)]
		private void RefreshLimitCount(ICookingData itemData = null)
		{
			if (itemData == null || itemData.LimitTotalCount <= 0)
			{
				base.GetItem(3).SetUIActive(false);
				this.NumberSelect.ResetLimitMaxValue();
				return;
			}
			int num = itemData.LimitTotalCount - itemData.CookCount;
			this.NumberSelect.SetLimitMaxValue(Math.Max(1, num));
			string text = num.ToString();
			if (num == 0)
			{
				text = StringUtils.Format("<color=#c25757>{0}</color>", new string[]
				{
					num.ToString()
				});
			}
			base.GetItem(3).SetUIActive(true);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), "MakeLimit", new <>z__ReadOnlyArray<object>(new object[]
			{
				text,
				itemData.LimitTotalCount
			}));
		}

		// Token: 0x0603C88D RID: 247949 RVA: 0x00F602F8 File Offset: 0x00F5E4F8
		private void RefreshCost(bool hasCoin, int count)
		{
			base.GetText(12).GetParentAsUIItem().SetUIActive(hasCoin);
			if (hasCoin)
			{
				int commonItemCount = ModelBase<InventoryModel>.Instance.GetCommonItemCount(ControllerBase<CookController>.Instance.CookCoinId, 0);
				ItemInfo? config = ConfigBase<ItemConfig>.Instance.GetConfig(ControllerBase<CookController>.Instance.CookCoinId);
				if (commonItemCount < count)
				{
					base.GetText(11).SetText(StringUtils.Format("<color=#c25757>{0}</color>", new string[]
					{
						count.ToString()
					}), true);
				}
				else
				{
					base.GetText(11).SetText(count.ToString(), true);
				}
				base.SetTextureByPath(config.Value.IconSmall, base.GetTexture(13), null, null);
			}
		}

		// Token: 0x0603C88E RID: 247950 RVA: 0x00F603B4 File Offset: 0x00F5E5B4
		public void RefreshProficiency(ICookingData data, int times)
		{
			CookFormula cookFormulaById = ConfigBase<CookConfig>.Instance.GetCookFormulaById(data.ItemId);
			int proficiency = cookFormulaById.Proficiency;
			int maxProficiencyCount = cookFormulaById.MaxProficiencyCount;
			this.ProficiencyViewComponent.SetExpNum(data.CookCount, proficiency, maxProficiencyCount, times);
			this.SetRecommendedRoleTexture(data);
		}

		// Token: 0x0603C88F RID: 247951 RVA: 0x00F60400 File Offset: 0x00F5E600
		[return: Nullable(new byte[]
		{
			0,
			1,
			1
		})]
		private ValueTuple<bool, int, List<ISingleItemInfo>> FilterMaterialList(List<ISingleItemInfo> list)
		{
			bool item = false;
			int item2 = 0;
			List<ISingleItemInfo> list2 = new List<ISingleItemInfo>();
			foreach (ISingleItemInfo singleItemInfo in list)
			{
				if (singleItemInfo.Proto_ItemId != ControllerBase<CookController>.Instance.CookCoinId)
				{
					list2.Add(singleItemInfo);
				}
				else
				{
					item = true;
					item2 = singleItemInfo.Proto_ItemNum;
				}
			}
			return new ValueTuple<bool, int, List<ISingleItemInfo>>(item, item2, list2);
		}

		// Token: 0x0603C890 RID: 247952 RVA: 0x00F60484 File Offset: 0x00F5E684
		public void OnSecondTimerRefresh()
		{
			if (this.ItemData == null)
			{
				return;
			}
			if (this.ItemData.MainType == ECookListType.Cooking)
			{
				this.RefreshLimitTime((ICookingData)this.ItemData);
			}
		}

		// Token: 0x0603C891 RID: 247953 RVA: 0x00F604B0 File Offset: 0x00F5E6B0
		public void RefreshCooking(object itemData)
		{
			ICookItemData cookItemData = itemData as ICookItemData;
			if (cookItemData == null)
			{
				return;
			}
			this.ItemData = cookItemData;
			this.Count = 1;
			ICookingData cookingData = cookItemData as ICookingData;
			if (cookingData == null)
			{
				return;
			}
			this.NumberSelect.SetUiActive(cookingData.IsUnLock);
			base.GetItem(9).SetUIActive(cookingData.IsUnLock);
			this.SvInfoView.RefreshCooking(cookingData, this.Count);
			base.GetItem(26).SetUIActive(true);
			this.RefreshProficiency(cookingData, this.Count);
			this.SetTypeName("Dishes", ECookListType.Cooking);
			if (cookingData.IsUnLock)
			{
				base.GetItem(20).SetUIActive(false);
				base.GetItem(18).SetUIActive(true);
				List<ISingleItemInfo> cookMaterialList = ModelBase<CookModel>.Instance.GetCookMaterialList(this.ItemData.ItemId, ECookListType.Cooking);
				List<ISingleItemInfo> item = this.FilterMaterialList(cookMaterialList).Item3;
				this.MaterialScrollView.RefreshByData(item, new Action(this.RefreshMaterialNeedNum), false);
				this.NumberSelect.SetUiActive(true);
				base.GetItem(9).SetUIActive(true);
				this.RefreshLimitTime((ICookingData)this.ItemData);
				this.RefreshLimitCount((ICookingData)this.ItemData);
				int maxCreateCount = ControllerBase<CookController>.Instance.GetMaxCreateCount(this.ItemData.ItemId, ModelBase<CookModel>.Instance.CurrentCookListType);
				this.NumberSelect.Refresh(maxCreateCount);
				this.NumberSelect.SetAddReduceButtonActive(true);
				this.NumberSelect.SetReduceButtonInteractive(false);
				return;
			}
			this.RefreshLimitCount(null);
			base.GetItem(20).SetUIActive(true);
			base.GetItem(18).SetUIActive(false);
			CookFormula cookFormulaById = ConfigBase<CookConfig>.Instance.GetCookFormulaById(this.ItemData.ItemId);
			ItemInfo? config = ConfigBase<ItemConfig>.Instance.GetConfig(cookFormulaById.FormulaItemId);
			if (config == null)
			{
				return;
			}
			PropMediumItemGrid parameters = new PropMediumItemGrid
			{
				Data = cookFormulaById.FormulaItemId,
				ItemConfigId = new int?(cookFormulaById.FormulaItemId),
				BottomTextId = config.Value.Name,
				IsProhibit = new bool?(true),
				IsOmitBottomText = new bool?(true)
			};
			this.UnlockMaterialComponent.Apply<PropMediumItemGrid>(parameters);
		}

		// Token: 0x0603C892 RID: 247954 RVA: 0x00F606E4 File Offset: 0x00F5E8E4
		public void RefreshMachining(object itemData)
		{
			if (itemData == null)
			{
				return;
			}
			base.GetItem(20).SetUIActive(false);
			base.GetItem(18).SetUIActive(true);
			this.ItemData = (ICookItemData)itemData;
			this.SetTypeName("Accessory", ECookListType.Machining);
			this.SvInfoView.RefreshMachining((IMachiningData)this.ItemData);
			base.GetItem(26).SetUIActive(false);
			MaterialSelectionCacheData.TmpSelectedMaterialData = new List<ISelectedData>();
			this.ShowMaterialItemRemoveControl = false;
			List<ISingleItemInfo> cookMaterialList = ModelBase<CookModel>.Instance.GetCookMaterialList(this.ItemData.ItemId, this.ItemData.MainType);
			ModelBase<CookModel>.Instance.CreateTmpMachiningItemList(cookMaterialList);
			this.MaterialScrollView.RefreshByData(cookMaterialList, new Action(this.RefreshMaterialNeedNum), false);
			bool flag = true;
			using (List<ISingleItemInfo>.Enumerator enumerator = cookMaterialList.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (!enumerator.Current.Proto_IsUnlock)
					{
						flag = false;
						break;
					}
				}
			}
			this.NumberSelect.SetUiActive(flag);
			base.GetItem(9).SetUIActive(flag);
			if (!flag)
			{
				return;
			}
			int maxCreateCount = ControllerBase<CookController>.Instance.GetMaxCreateCount(this.ItemData.ItemId, ModelBase<CookModel>.Instance.CurrentCookListType);
			this.NumberSelect.ResetLimitMaxValue();
			this.NumberSelect.Refresh(maxCreateCount);
			this.NumberSelect.SetAddReduceButtonActive(true);
			this.NumberSelect.SetReduceButtonInteractive(false);
			base.GetItem(24).SetUIActive(false);
			base.GetItem(3).SetUIActive(false);
		}

		// Token: 0x04022095 RID: 139413
		[Nullable(2)]
		private SvInfo SvInfoView;

		// Token: 0x04022096 RID: 139414
		[Nullable(2)]
		public ICookItemData ItemData;

		// Token: 0x04022097 RID: 139415
		[Nullable(2)]
		private NumberSelectComponent NumberSelect;

		// Token: 0x04022098 RID: 139416
		private int Count = 1;

		// Token: 0x04022099 RID: 139417
		public bool ShowMaterialItemRemoveControl;

		// Token: 0x0402209A RID: 139418
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericScrollViewNew<ManufactureMaterialItem, ISingleItemInfo> MaterialScrollView;

		// Token: 0x0402209B RID: 139419
		[Nullable(2)]
		private CookProficiencyView ProficiencyViewComponent;

		// Token: 0x0402209C RID: 139420
		private bool HasCoin;

		// Token: 0x0402209D RID: 139421
		private int SingleNeedCoinCount;

		// Token: 0x0402209E RID: 139422
		[Nullable(2)]
		private MediumItemGrid UnlockMaterialComponent;

		// Token: 0x0402209F RID: 139423
		[Nullable(2)]
		public Action OnChangeMaterialSelectionDelegate;

		// Token: 0x0200BE43 RID: 48707
		[NullableContext(0)]
		private enum EVerticalGroupComponents
		{
			// Token: 0x0403A924 RID: 239908
			SvInfo,
			// Token: 0x0403A925 RID: 239909
			PnlLimit,
			// Token: 0x0403A926 RID: 239910
			TxtLimitNum,
			// Token: 0x0403A927 RID: 239911
			PnlQuota,
			// Token: 0x0403A928 RID: 239912
			TxtQuotaNum,
			// Token: 0x0403A929 RID: 239913
			AmountItem = 8,
			// Token: 0x0403A92A RID: 239914
			PnlCost,
			// Token: 0x0403A92B RID: 239915
			MakeCount,
			// Token: 0x0403A92C RID: 239916
			TxtCost,
			// Token: 0x0403A92D RID: 239917
			TxtPlace,
			// Token: 0x0403A92E RID: 239918
			ImgCostIcon,
			// Token: 0x0403A92F RID: 239919
			PnlTitle = 16,
			// Token: 0x0403A930 RID: 239920
			TxtMaterialBarTitle,
			// Token: 0x0403A931 RID: 239921
			PnlLeftItem,
			// Token: 0x0403A932 RID: 239922
			MaterialScrollView,
			// Token: 0x0403A933 RID: 239923
			PnlCenterItem,
			// Token: 0x0403A934 RID: 239924
			LockGrid,
			// Token: 0x0403A935 RID: 239925
			PnlLock,
			// Token: 0x0403A936 RID: 239926
			TxtLock,
			// Token: 0x0403A937 RID: 239927
			PnlLimitedTime,
			// Token: 0x0403A938 RID: 239928
			TxtTime,
			// Token: 0x0403A939 RID: 239929
			ProficiencyView
		}
	}
}
