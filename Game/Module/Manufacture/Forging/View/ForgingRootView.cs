using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.Common.NumberSelect;
using CSharpScript.Game.Module.FilterSort.Sort.SortEntrance;
using CSharpScript.Game.Module.Interaction;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.Manufacture.Common;
using CSharpScript.Game.Module.Manufacture.Common.Item;
using CSharpScript.Game.Module.Manufacture.Compose;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Manufacture.Forging.View
{
	// Token: 0x020059B1 RID: 22961
	[NullableContext(1)]
	[Nullable(0)]
	public class ForgingRootView : UiViewBase
	{
		// Token: 0x0603A202 RID: 238082 RVA: 0x00EB6978 File Offset: 0x00EB4B78
		public ForgingRootView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603A203 RID: 238083 RVA: 0x00EB6994 File Offset: 0x00EB4B94
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.GetForgingData, new Action(this.ShowForgingRootView));
			Singleton<EventSystem>.Instance.Add(EEventName.OpenHelpRole, new Action<int>(this.OpenRoleView));
			Singleton<EventSystem>.Instance.Add(EEventName.ForgingSuccess, new Action(this.OnForgingResponse));
			Singleton<EventSystem>.Instance.Add(EEventName.ForgingFail, new Action(this.OnForgingResponse));
			this.RefreshTimer = TimerSystem.Instance.Forever(new TTimerAction(this.OnSecondTimerRefresh), 1000f, 1f, null, null, true);
		}

		// Token: 0x0603A204 RID: 238084 RVA: 0x00EB6A3C File Offset: 0x00EB4C3C
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.GetForgingData, new Action(this.ShowForgingRootView));
			Singleton<EventSystem>.Instance.Remove(EEventName.OpenHelpRole, new Action<int>(this.OpenRoleView));
			Singleton<EventSystem>.Instance.Remove(EEventName.ForgingSuccess, new Action(this.RefreshItemScrollView));
			Singleton<EventSystem>.Instance.Remove(EEventName.ForgingFail, new Action(this.RefreshItemScrollView));
			if (this.RefreshTimer != null && TimerSystem.Instance.Has(this.RefreshTimer))
			{
				TimerSystem.Instance.Remove(this.RefreshTimer);
				this.RefreshTimer = null;
			}
		}

		// Token: 0x0603A205 RID: 238085 RVA: 0x00EB6AEB File Offset: 0x00EB4CEB
		private void OnSecondTimerRefresh(float _)
		{
			this.RefreshBottomText();
			if (this.CheckIsLimitCountRefresh())
			{
				this.<OnSecondTimerRefresh>g__Temp|26_0().Forget();
				return;
			}
			if (this.CheckHasItemTimeOut())
			{
				this.<OnSecondTimerRefresh>g__Temp|26_1().Forget();
			}
		}

		// Token: 0x0603A206 RID: 238086 RVA: 0x00EB6B1A File Offset: 0x00EB4D1A
		private void RefreshBottomText()
		{
			this.NeedShowBottomText = false;
			this.RefreshItemRefreshTime();
			this.RefreshLimitCount();
			UUIItem item = base.GetItem(29);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(this.NeedShowBottomText);
		}

		// Token: 0x0603A207 RID: 238087 RVA: 0x00EB6B48 File Offset: 0x00EB4D48
		private void RefreshItemRefreshTime()
		{
			string refreshLimitTime = ModelBase<ForgingModel>.Instance.GetRefreshLimitTime();
			if (!string.IsNullOrEmpty(refreshLimitTime))
			{
				this.NeedShowBottomText = true;
				UUIText text = base.GetText(26);
				if (text != null)
				{
					text.SetUIActive(true);
				}
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(26), "RefreshTime", new <>z__ReadOnlySingleElementList<object>(refreshLimitTime));
				return;
			}
			UUIText text2 = base.GetText(26);
			if (text2 == null)
			{
				return;
			}
			text2.SetUIActive(false);
		}

		// Token: 0x0603A208 RID: 238088 RVA: 0x00EB6BB4 File Offset: 0x00EB4DB4
		private bool CheckIsLimitCountRefresh()
		{
			return ModelBase<ForgingModel>.Instance.GetRefreshLimitTimeValue() <= 0.0;
		}

		// Token: 0x0603A209 RID: 238089 RVA: 0x00EB6BD0 File Offset: 0x00EB4DD0
		private bool CheckHasItemTimeOut()
		{
			List<IWeaponForgingData> itemList = this.GetItemList(true);
			if (itemList == null)
			{
				return false;
			}
			foreach (IWeaponForgingData weaponForgingData in itemList)
			{
				if (weaponForgingData.ExistEndTime > 0.0 && !Singleton<TimeUtil>.Instance.IsInTimeSpan(weaponForgingData.ExistStartTime, weaponForgingData.ExistEndTime))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0603A20A RID: 238090 RVA: 0x00EB6C54 File Offset: 0x00EB4E54
		protected unsafe override void OnRegisterComponent()
		{
			int num = 35;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUILoopScrollViewComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIHorizontalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(15, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(17, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(18, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(19, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(20, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(21, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(22, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(23, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(24, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(25, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(26, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(27, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(28, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(29, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(30, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(31, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(32, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(34, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(33, typeof(UUIText));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(27, new Action(this.OnClickConfirmButton));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603A20B RID: 238091 RVA: 0x00EB7158 File Offset: 0x00EB5358
		protected override UniTask OnBeforeStartAsync()
		{
			ForgingRootView.<OnBeforeStartAsync>d__32 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<ForgingRootView.<OnBeforeStartAsync>d__32>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603A20C RID: 238092 RVA: 0x00EB719C File Offset: 0x00EB539C
		protected override void OnStart()
		{
			this.FilterComponent = new FilterEntrance<IWeaponForgingData>(base.GetItem(3), new TUpdateDataListFunction<IWeaponForgingData>(this.OnFilterSortRefresh));
			this.SortComponent = new SortEntrance<IWeaponForgingData>(base.GetItem(4), new TUpdateDataListFunction<IWeaponForgingData>(this.OnFilterSortRefresh));
			this.FilterComponent.SetActive(false);
			this.ForgingItemScrollView = new LoopScrollView<ForgingMediumItemGrid, IWeaponForgingData>(base.GetLoopScrollViewComponent(1), base.GetLoopScrollViewComponent(1).TemplateGrid, new Func<ForgingMediumItemGrid>(this.OnGridProxyCreate), false);
			ControllerBase<ForgingController>.Instance.RegisterCurrentInteractionEntity();
			Singleton<CommonManager>.Instance.SetCurrentSystem(ESystemType.ForgingSystem);
			ModelBase<ForgingModel>.Instance.CurrentForgingViewType = EForgingViewType.ForgingMainType;
			ModelBase<ForgingModel>.Instance.CurrentInteractCreatureDataLongId = ModelBase<InteractionModel>.Instance.InteractCreatureDataLongId;
			if (ModelBase<InteractionModel>.Instance.CurrentInteractEntityId == null)
			{
				Singleton<Log>.Instance.Info(ELogModule.Forging, ELogAuthor.WZ, "[LevelEventOpenSystem] 打开合成界面时找不到交互对象，直接关闭界面", default(ReadOnlySpan<ValueTuple<string, object>>));
				base.CloseMe(null);
			}
		}

		// Token: 0x0603A20D RID: 238093 RVA: 0x00EB728F File Offset: 0x00EB548F
		protected override void OnBeforeShow()
		{
			this.UpdateForgingItemScroll();
			this.ShowForgingRootView();
		}

		// Token: 0x0603A20E RID: 238094 RVA: 0x00EB72A0 File Offset: 0x00EB54A0
		protected override void OnBeforeDestroy()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnExecuteUiCameraSequenceEvent, new Action<string>(this.OnExecuteUiCameraSequenceEvent));
			this.FilterComponent.Destroy(null);
			this.SortComponent.Destroy(null);
			ControllerBase<ForgingController>.Instance.PlayLeaveForgingAudio();
			ControllerBase<ForgingController>.Instance.ClearCurrentInteractionEntityDisplay();
			ModelBase<ForgingModel>.Instance.CurrentForgingRoleId = 0;
		}

		// Token: 0x0603A20F RID: 238095 RVA: 0x00EB7300 File Offset: 0x00EB5500
		private void ShowForgingRootView()
		{
			this.SortComponent.UpdateData(EFilterSortGroupId.ForgingList, this.GetItemList(true), Array.Empty<object>());
		}

		// Token: 0x0603A210 RID: 238096 RVA: 0x00EB731B File Offset: 0x00EB551B
		private void OnExecuteUiCameraSequenceEvent(string sequenceEventName)
		{
			if (sequenceEventName != "OnBlackScreen")
			{
				return;
			}
			ControllerBase<ForgingController>.Instance.PlayForgingEnterDisplay(null);
		}

		// Token: 0x0603A211 RID: 238097 RVA: 0x00EB7336 File Offset: 0x00EB5536
		private ForgingMediumItemGrid OnGridProxyCreate()
		{
			ForgingMediumItemGrid forgingMediumItemGrid = new ForgingMediumItemGrid();
			forgingMediumItemGrid.BindOnExtendToggleStateChanged(new Action<MediumItemGridExtendCallback>(this.OnComposeItemClick));
			return forgingMediumItemGrid;
		}

		// Token: 0x0603A212 RID: 238098 RVA: 0x00EB7350 File Offset: 0x00EB5550
		private void OnComposeItemClick(MediumItemGridExtendCallback callbackParameter)
		{
			IWeaponForgingData weaponForgingData = (IWeaponForgingData)callbackParameter.Data;
			this.ForgingItemScrollView.DeselectCurrentGridProxy(false);
			this.SelectedForgingIndex = this.WeaponForgingDataList.IndexOf(weaponForgingData);
			this.SelectedForgingData = weaponForgingData;
			if (!this.ForgingItemScrollView.IsGridDisplaying(this.SelectedForgingIndex))
			{
				return;
			}
			if (weaponForgingData.IsNew)
			{
				weaponForgingData.IsNew = false;
				ModelBase<NewFlagModel>.Instance.RemoveNewFlag(ELocalStoragePlayerKey.ForgingLevelKey, weaponForgingData.ItemId);
			}
			this.ForgingItemScrollView.SelectGridProxy(this.SelectedForgingIndex, false);
			this.ForgingItemScrollView.RefreshGridProxy(this.SelectedForgingIndex);
			this.RefreshItemTips(weaponForgingData);
			this.CheckCanInteractConfirm(weaponForgingData);
			this.RefreshForging(weaponForgingData);
		}

		// Token: 0x0603A213 RID: 238099 RVA: 0x00EB73FC File Offset: 0x00EB55FC
		private void RefreshItemTips(IWeaponForgingData data)
		{
			ForgeFormula? forgeFormulaById = ConfigBase<ForgingConfig>.Instance.GetForgeFormulaById(data.ItemId);
			WeaponConf? weaponConfigByItemId = ConfigBase<global::WeaponConfig>.Instance.GetWeaponConfigByItemId(forgeFormulaById.Value.ItemId);
			base.GetText(8).ShowTextNew(((weaponConfigByItemId != null) ? weaponConfigByItemId.GetValueOrDefault().WeaponName : null) ?? "");
			int itemCountByConfigId = ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(forgeFormulaById.Value.ItemId, 0);
			Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(7), "Have", new <>z__ReadOnlySingleElementList<object>(itemCountByConfigId));
		}

		// Token: 0x0603A214 RID: 238100 RVA: 0x00EB74A4 File Offset: 0x00EB56A4
		private void CheckCanInteractConfirm(IWeaponForgingData data)
		{
			bool flag = true;
			ForgingModel instance = ModelBase<ForgingModel>.Instance;
			bool flag2 = instance.CheckUnlock(data);
			bool isCoinEnough = instance.CheckCoinEnough(data.ItemId);
			bool flag3 = instance.CheckLimitCount(data);
			string textById;
			if (flag2)
			{
				textById = ConfigBase<TextConfig>.Instance.GetTextById("WeaponMaking");
				flag = instance.CheckMaterialEnough(data.ItemId);
			}
			else
			{
				textById = ConfigBase<TextConfig>.Instance.GetTextById("UnlockWeapon");
			}
			base.GetText(30).SetText(textById, true);
			base.GetText(31).SetText(this.GetDisableText(flag2, flag, isCoinEnough, flag3), true);
			base.GetItem(28).SetUIActive(!flag2 || !flag || !flag3);
			base.GetButton(27).RootUIComp.Get().SetUIActive(flag2 && flag && flag3);
		}

		// Token: 0x0603A215 RID: 238101 RVA: 0x00EB7574 File Offset: 0x00EB5774
		private string GetDisableText(bool isUnlock, bool isMatEnough, bool isCoinEnough, bool isMakeCountEnough)
		{
			if (!isUnlock)
			{
				return ConfigMultiTextLang.GetLocalTextNew("GenericPrompt_Unlocked_TipsText", null);
			}
			if (!isMatEnough)
			{
				string localTextNew = ConfigMultiTextLang.GetLocalTextNew("LackMakeMaterial", null);
				if (!isCoinEnough)
				{
					return StringUtils.Format(localTextNew, new string[]
					{
						ConfigBase<CSharpScript.Game.Module.Item.ItemConfig>.Instance.GetItemName(ControllerBase<ForgingController>.Instance.ForgingCostId)
					});
				}
				return StringUtils.Format(localTextNew, new string[]
				{
					ConfigMultiTextLang.GetLocalTextNew("Material_Text", null)
				});
			}
			else
			{
				if (isMakeCountEnough)
				{
					return "";
				}
				string refreshLimitTime = ModelBase<ForgingModel>.Instance.GetRefreshLimitTime();
				if (refreshLimitTime != null)
				{
					return StringUtils.Format(ConfigMultiTextLang.GetLocalTextNew("LackMakeCount", null), new string[]
					{
						refreshLimitTime
					});
				}
				return ConfigMultiTextLang.GetLocalTextNew("LackMakeCountWithoutTime", null);
			}
		}

		// Token: 0x0603A216 RID: 238102 RVA: 0x00EB761F File Offset: 0x00EB581F
		private ForgingRootView.StarItem InitStarItem()
		{
			return new ForgingRootView.StarItem();
		}

		// Token: 0x0603A217 RID: 238103 RVA: 0x00EB7628 File Offset: 0x00EB5828
		private ManufactureMaterialItem OnMaterialItemCreate()
		{
			ManufactureMaterialItem manufactureMaterialItem = new ManufactureMaterialItem();
			manufactureMaterialItem.BindOnCanExecuteChange((object _, bool _, EToggleState _) => false);
			manufactureMaterialItem.BindOnExtendToggleClicked(delegate(MediumItemGridExtendCallback callbackParameter)
			{
				ISingleItemInfo singleItemInfo = (ISingleItemInfo)callbackParameter.Data;
				ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(singleItemInfo.Proto_ItemId, true, null);
			});
			return manufactureMaterialItem;
		}

		// Token: 0x0603A218 RID: 238104 RVA: 0x00EB7684 File Offset: 0x00EB5884
		private void SetSum(int sum)
		{
			this.Count = sum;
			if (this.ItemData != null)
			{
				int maxCreateCount = ControllerBase<ForgingController>.Instance.GetMaxCreateCount(this.ItemData.ItemId);
				this.NumberSelect.SetAddButtonInteractive(sum < maxCreateCount);
				this.NumberSelect.SetReduceButtonInteractive(sum > 1);
			}
			string numberSelectTipsText = StringUtils.Format(ConfigMultiTextLang.GetLocalTextNew("Text_ItemSelectForgeQuantityTip_text", null), new string[]
			{
				this.Count.ToString()
			});
			this.NumberSelect.SetNumberSelectTipsText(numberSelectTipsText);
			this.RefreshMaterialNeedNum();
		}

		// Token: 0x0603A219 RID: 238105 RVA: 0x00EB770C File Offset: 0x00EB590C
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

		// Token: 0x0603A21A RID: 238106 RVA: 0x00EB7790 File Offset: 0x00EB5990
		private void RefreshCommon(IWeaponForgingData data)
		{
			this.ItemData = data;
			this.Count = 1;
			int maxCreateCount = Singleton<CommonManager>.Instance.GetMaxCreateCount(this.ItemData.ItemId);
			this.NumberSelect.Refresh(maxCreateCount);
			this.NumberSelect.SetAddReduceButtonActive(true);
			this.NumberSelect.SetReduceButtonInteractive(false);
			ForgeFormula? forgeFormulaById = ConfigBase<ForgingConfig>.Instance.GetForgeFormulaById(data.ItemId);
			WeaponConf? weaponItemConfig = ConfigBase<InventoryConfig>.Instance.GetWeaponItemConfig(forgeFormulaById.Value.ItemId);
			string[] weaponConfigDescParams = ModelBase<WeaponModel>.Instance.GetWeaponConfigDescParams(weaponItemConfig.Value, 1);
			string newText = StringUtils.Format(ConfigMultiTextLang.GetLocalTextNew(weaponItemConfig.Value.Desc, null), weaponConfigDescParams);
			base.GetText(20).SetText(newText, true);
		}

		// Token: 0x0603A21B RID: 238107 RVA: 0x00EB7854 File Offset: 0x00EB5A54
		[return: TupleElementNames(new string[]
		{
			"hasCoin",
			"coinCount",
			"list"
		})]
		[return: Nullable(new byte[]
		{
			0,
			1,
			1
		})]
		private ValueTuple<bool, int, List<ISingleItemInfo>> FilterMaterialList(List<ISingleItemInfo> list)
		{
			bool hasCoin = false;
			int coinCount = 0;
			List<ISingleItemInfo> item = list.Where(delegate(ISingleItemInfo value)
			{
				if (value.Proto_ItemId != ControllerBase<ComposeController>.Instance.ComposeCoinId)
				{
					return true;
				}
				hasCoin = true;
				coinCount = value.Proto_ItemNum;
				return false;
			}).ToList<ISingleItemInfo>();
			return new ValueTuple<bool, int, List<ISingleItemInfo>>(hasCoin, coinCount, item);
		}

		// Token: 0x0603A21C RID: 238108 RVA: 0x00EB78A0 File Offset: 0x00EB5AA0
		private void RefreshMaterial()
		{
			if (this.ItemData.IsUnlock > 0)
			{
				this.UnlockMaterialComponent.SetUiActive(false);
				this.MaterialScrollView.SetActive(true);
				List<ISingleItemInfo> forgingMaterialList = ModelBase<ForgingModel>.Instance.GetForgingMaterialList(this.ItemData.ItemId);
				ValueTuple<bool, int, List<ISingleItemInfo>> valueTuple = this.FilterMaterialList(forgingMaterialList);
				this.HasCoin = valueTuple.Item1;
				this.SingleNeedCoinCount = valueTuple.Item2;
				this.MaterialScrollView.RefreshByData(valueTuple.Item3, new Action(this.RefreshMaterialNeedNum), false);
				return;
			}
			this.UnlockMaterialComponent.SetUiActive(true);
			this.MaterialScrollView.SetActive(false);
			ForgeFormula? forgeFormulaById = ConfigBase<ForgingConfig>.Instance.GetForgeFormulaById(this.ItemData.ItemId);
			ItemInfo? itemConfig = ConfigBase<InventoryConfig>.Instance.GetItemConfig(forgeFormulaById.Value.FormulaItemId);
			if (itemConfig == null)
			{
				return;
			}
			PropMediumItemGrid parameters = new PropMediumItemGrid
			{
				Data = forgeFormulaById.Value.FormulaItemId,
				ItemConfigId = new int?(forgeFormulaById.Value.FormulaItemId),
				BottomTextId = itemConfig.Value.Name,
				IsProhibit = new bool?(true),
				IsOmitBottomText = new bool?(true)
			};
			this.UnlockMaterialComponent.Apply<PropMediumItemGrid>(parameters);
		}

		// Token: 0x0603A21D RID: 238109 RVA: 0x00EB79F4 File Offset: 0x00EB5BF4
		private void RefreshCost(bool hasCoin, int count)
		{
			base.GetItem(32).GetParentAsUIItem().SetUIActive(hasCoin);
			if (hasCoin)
			{
				int itemCountByConfigId = ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(ControllerBase<ComposeController>.Instance.ComposeCoinId, 0);
				ItemInfo? config = ConfigBase<CSharpScript.Game.Module.Item.ItemConfig>.Instance.GetConfig(ControllerBase<ComposeController>.Instance.ComposeCoinId);
				if (itemCountByConfigId < count)
				{
					base.GetText(33).SetText(StringUtils.Format("<color=#c25757>{0}</color>", new string[]
					{
						count.ToString()
					}), true);
				}
				else
				{
					base.GetText(33).SetText(count.ToString(), true);
				}
				base.SetTextureByPath(config.Value.IconSmall, base.GetTexture(34), null, null);
			}
		}

		// Token: 0x0603A21E RID: 238110 RVA: 0x00EB7AB0 File Offset: 0x00EB5CB0
		private void RefreshLimitCount()
		{
			IWeaponForgingData itemData = this.ItemData;
			if (((itemData != null) ? itemData.TotalMakeCountInLimitTime : 0) > 0)
			{
				this.NeedShowBottomText = true;
				UUIText text = base.GetText(25);
				if (text != null)
				{
					text.SetUIActive(true);
				}
				int num = this.ItemData.TotalMakeCountInLimitTime - this.ItemData.MadeCountInLimitTime;
				this.NumberSelect.SetLimitMaxValue(Math.Max(1, num));
				string text2 = num.ToString();
				if (num == 0)
				{
					text2 = StringUtils.Format("<color=#c25757>{0}</color>", new string[]
					{
						num.ToString()
					});
				}
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(25), "MakeLimit", new <>z__ReadOnlyArray<object>(new object[]
				{
					text2,
					this.ItemData.TotalMakeCountInLimitTime
				}));
				return;
			}
			this.NumberSelect.ResetLimitMaxValue();
			UUIText text3 = base.GetText(25);
			if (text3 == null)
			{
				return;
			}
			text3.SetUIActive(false);
		}

		// Token: 0x0603A21F RID: 238111 RVA: 0x00EB7B95 File Offset: 0x00EB5D95
		private void UpdateForgingItemScroll()
		{
			this.SortComponent.UpdateData(EFilterSortGroupId.ForgingList, this.GetItemList(true), Array.Empty<object>());
		}

		// Token: 0x0603A220 RID: 238112 RVA: 0x00EB7BB0 File Offset: 0x00EB5DB0
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		private List<IWeaponForgingData> GetItemList(bool needFilter = true)
		{
			List<IWeaponForgingData> list = ModelBase<ForgingModel>.Instance.GetForgingDataList();
			if (list != null && needFilter)
			{
				list = (from value in list
				where value.IsUnlock > 0 || value.FormulaItemId > 0
				select value).ToList<IWeaponForgingData>();
			}
			return list;
		}

		// Token: 0x0603A221 RID: 238113 RVA: 0x00EB7BFC File Offset: 0x00EB5DFC
		private void RefreshItemScrollView()
		{
			this.ForgingItemScrollView.ReloadData(this.WeaponForgingDataList, false);
		}

		// Token: 0x0603A222 RID: 238114 RVA: 0x00EB7C10 File Offset: 0x00EB5E10
		private void OnForgingResponse()
		{
			this.SortComponent.UpdateData(EFilterSortGroupId.ForgingList, this.GetItemList(true), Array.Empty<object>());
		}

		// Token: 0x0603A223 RID: 238115 RVA: 0x00EB7C2C File Offset: 0x00EB5E2C
		private void OnClickConfirmButton()
		{
			if (!base.GetButton(27).IsSelfInteractive)
			{
				ControllerBase<ForgingController>.Instance.PlayForgingFailDisplay(delegate
				{
					ControllerBase<ForgingController>.Instance.PlayForgingLoopDisplay();
				});
				return;
			}
			if (this.ItemData.IsUnlock == 0)
			{
				ControllerBase<ForgingController>.Instance.SendForgeFormulaUnlockRequest(this.ItemData.ItemId);
				return;
			}
			Singleton<CommonManager>.Instance.SendManufacture(this.ItemData.ItemId, this.Count);
		}

		// Token: 0x0603A224 RID: 238116 RVA: 0x00EB7CB0 File Offset: 0x00EB5EB0
		private void OnClickBackBtn()
		{
			base.CloseMe(null);
		}

		// Token: 0x0603A225 RID: 238117 RVA: 0x00EB7CBC File Offset: 0x00EB5EBC
		private void OnFilterSortRefresh(List<IWeaponForgingData> list, bool isOutSideChange, EFilterSortType operationType)
		{
			this.WeaponForgingDataList = list;
			this.WeaponForgingDataList = (from value in this.WeaponForgingDataList
			where value.ExistStartTime <= 0.0 || Singleton<TimeUtil>.Instance.IsInTimeSpan(value.ExistStartTime, value.ExistEndTime)
			select value).ToList<IWeaponForgingData>();
			this.RefreshItemScrollView();
			if (this.WeaponForgingDataList.Count == 0)
			{
				return;
			}
			this.SetSelectedForgingItem(true);
		}

		// Token: 0x0603A226 RID: 238118 RVA: 0x00EB7D20 File Offset: 0x00EB5F20
		private void OpenRoleView(int itemId)
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.ManufactureHelpRoleView, this.SelectedForgingData.ItemId, null);
		}

		// Token: 0x0603A227 RID: 238119 RVA: 0x00EB7D42 File Offset: 0x00EB5F42
		private void RefreshForging(IWeaponForgingData data)
		{
			this.RefreshCommon(data);
			this.RefreshMaterial();
			this.RefreshBottomText();
			this.RefreshWeaponTips();
			this.NumberSelect.SetUiActive(data.IsUnlock > 0);
		}

		// Token: 0x0603A228 RID: 238120 RVA: 0x00EB7D74 File Offset: 0x00EB5F74
		private void SetSelectedForgingItem(bool isNeedScroll = false)
		{
			this.ForgingItemScrollView.DeselectCurrentGridProxy(false);
			if (isNeedScroll)
			{
				this.ForgingItemScrollView.ScrollToGridIndex(this.SelectedForgingIndex, true);
			}
			this.ForgingItemScrollView.SelectGridProxy(this.SelectedForgingIndex, false);
			IWeaponForgingData data = this.WeaponForgingDataList[this.SelectedForgingIndex];
			this.RefreshItemTips(data);
			this.CheckCanInteractConfirm(data);
			this.RefreshForging(data);
		}

		// Token: 0x0603A229 RID: 238121 RVA: 0x00EB7DDC File Offset: 0x00EB5FDC
		private void RefreshWeaponTips()
		{
			ForgeFormula? forgeFormulaById = ConfigBase<ForgingConfig>.Instance.GetForgeFormulaById(this.ItemData.ItemId);
			this.WeaponConfig = ConfigBase<global::WeaponConfig>.Instance.GetWeaponConfigByItemId(forgeFormulaById.Value.ItemId);
			this.WeaponBreachConfig = ConfigBase<global::WeaponConfig>.Instance.GetWeaponBreach(this.WeaponConfig.Value.BreachId, 1);
			this.RefreshSkillNameText();
			this.RefreshWeaponLevel();
			this.RefreshStar();
			this.RefreshWeaponAttribute();
			this.RefreshWeaponItem();
		}

		// Token: 0x0603A22A RID: 238122 RVA: 0x00EB7E60 File Offset: 0x00EB6060
		private void RefreshSkillNameText()
		{
			WeaponReson? weaponResonanceConfig = ConfigBase<global::WeaponConfig>.Instance.GetWeaponResonanceConfig(this.WeaponConfig.Value.ResonId, 1);
			if (weaponResonanceConfig != null)
			{
				base.GetText(19).ShowTextNew(weaponResonanceConfig.Value.Name);
			}
		}

		// Token: 0x0603A22B RID: 238123 RVA: 0x00EB7EB4 File Offset: 0x00EB60B4
		private void RefreshWeaponLevel()
		{
			int num = 1;
			int levelLimit = this.WeaponBreachConfig.Value.LevelLimit;
			Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(9), "ForgingWeaponLevel", new <>z__ReadOnlyArray<object>(new object[]
			{
				num,
				levelLimit
			}));
		}

		// Token: 0x0603A22C RID: 238124 RVA: 0x00EB7F0C File Offset: 0x00EB610C
		private void RefreshStar()
		{
			int weaponBreachMaxLevel = ModelBase<WeaponModel>.Instance.GetWeaponBreachMaxLevel(this.WeaponConfig.Value.BreachId);
			EStartState[] data = Enumerable.Repeat<EStartState>(EStartState.OFF, weaponBreachMaxLevel).ToArray<EStartState>();
			this.StarView.RefreshByData(data, null, false);
		}

		// Token: 0x0603A22D RID: 238125 RVA: 0x00EB7F54 File Offset: 0x00EB6154
		private void RefreshWeaponAttribute()
		{
			PropertyIndex? propertyIndexInfo = ConfigBase<PropertyIndexConfig>.Instance.GetPropertyIndexInfo(this.WeaponConfig.Value.FirstPropId.Value.Id);
			UUIText text = base.GetText(13);
			if (text != null)
			{
				text.ShowTextNew(propertyIndexInfo.Value.Name);
			}
			base.SetTextureByPath(propertyIndexInfo.Value.Icon, base.GetTexture(12), null, null);
			float curveValue = ModelBase<WeaponModel>.Instance.GetCurveValue(this.WeaponConfig.Value.FirstCurve, this.WeaponConfig.Value.FirstPropId.Value.Value, 1, 0);
			string formatAttributeValueString = ModelBase<AttributeModel>.Instance.GetFormatAttributeValueString(this.WeaponConfig.Value.FirstPropId.Value.Id, (double)curveValue, this.WeaponConfig.Value.FirstPropId.Value.IsRatio);
			UUIText text2 = base.GetText(14);
			if (text2 != null)
			{
				text2.SetText(formatAttributeValueString, true);
			}
			PropertyIndex? propertyIndexInfo2 = ConfigBase<PropertyIndexConfig>.Instance.GetPropertyIndexInfo(this.WeaponConfig.Value.SecondPropId.Value.Id);
			UUIText text3 = base.GetText(16);
			if (text3 != null)
			{
				text3.ShowTextNew(propertyIndexInfo2.Value.Name);
			}
			base.SetTextureByPath(propertyIndexInfo.Value.Icon, base.GetTexture(15), null, null);
			float curveValue2 = ModelBase<WeaponModel>.Instance.GetCurveValue(this.WeaponConfig.Value.SecondCurve, this.WeaponConfig.Value.SecondPropId.Value.Value, 1, 0);
			string formatAttributeValueString2 = ModelBase<AttributeModel>.Instance.GetFormatAttributeValueString(this.WeaponConfig.Value.SecondPropId.Value.Id, (double)curveValue2, this.WeaponConfig.Value.SecondPropId.Value.IsRatio);
			UUIText text4 = base.GetText(17);
			if (text4 != null)
			{
				text4.SetText(formatAttributeValueString2, true);
			}
			Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(18), "WeaponResonanceItemLevelText", new <>z__ReadOnlySingleElementList<object>("1"));
		}

		// Token: 0x0603A22E RID: 238126 RVA: 0x00EB81EC File Offset: 0x00EB63EC
		private void RefreshWeaponItem()
		{
			base.SetTextureByPath(this.WeaponConfig.Value.Icon, base.GetTexture(6), null, null);
			QualityInfo? qualityConfig = ConfigBase<CSharpScript.Game.Module.Item.ItemConfig>.Instance.GetQualityConfig(this.WeaponConfig.Value.QualityId);
			if (qualityConfig == null)
			{
				return;
			}
			this.SetSpriteByPath(qualityConfig.Value.ComposeQualityBg, base.GetSprite(5), false, null, null);
		}

		// Token: 0x0603A22F RID: 238127 RVA: 0x00EB8274 File Offset: 0x00EB6474
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
		{
			LoopScrollView<ForgingMediumItemGrid, IWeaponForgingData> forgingItemScrollView = this.ForgingItemScrollView;
			if (forgingItemScrollView == null || !forgingItemScrollView.DataInited)
			{
				return null;
			}
			int displayIndex = int.Parse(configParams[0]);
			UUIItem gridByDisplayIndex = this.ForgingItemScrollView.GetGridByDisplayIndex(displayIndex);
			if (gridByDisplayIndex != null)
			{
				return new UUIItem[]
				{
					gridByDisplayIndex,
					gridByDisplayIndex
				};
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Guide;
			ELogAuthor author = ELogAuthor.JT;
			string message = "印造界面聚焦引导的额外参数配置错误";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("configParams", configParams);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}

		// Token: 0x0603A230 RID: 238128 RVA: 0x00EB82EC File Offset: 0x00EB64EC
		[CompilerGenerated]
		private UniTask <OnSecondTimerRefresh>g__Temp|26_0()
		{
			ForgingRootView.<<OnSecondTimerRefresh>g__Temp|26_0>d <<OnSecondTimerRefresh>g__Temp|26_0>d;
			<<OnSecondTimerRefresh>g__Temp|26_0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<<OnSecondTimerRefresh>g__Temp|26_0>d.<>4__this = this;
			<<OnSecondTimerRefresh>g__Temp|26_0>d.<>1__state = -1;
			<<OnSecondTimerRefresh>g__Temp|26_0>d.<>t__builder.Start<ForgingRootView.<<OnSecondTimerRefresh>g__Temp|26_0>d>(ref <<OnSecondTimerRefresh>g__Temp|26_0>d);
			return <<OnSecondTimerRefresh>g__Temp|26_0>d.<>t__builder.Task;
		}

		// Token: 0x0603A231 RID: 238129 RVA: 0x00EB8330 File Offset: 0x00EB6530
		[CompilerGenerated]
		private UniTask <OnSecondTimerRefresh>g__Temp|26_1()
		{
			ForgingRootView.<<OnSecondTimerRefresh>g__Temp|26_1>d <<OnSecondTimerRefresh>g__Temp|26_1>d;
			<<OnSecondTimerRefresh>g__Temp|26_1>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<<OnSecondTimerRefresh>g__Temp|26_1>d.<>4__this = this;
			<<OnSecondTimerRefresh>g__Temp|26_1>d.<>1__state = -1;
			<<OnSecondTimerRefresh>g__Temp|26_1>d.<>t__builder.Start<ForgingRootView.<<OnSecondTimerRefresh>g__Temp|26_1>d>(ref <<OnSecondTimerRefresh>g__Temp|26_1>d);
			return <<OnSecondTimerRefresh>g__Temp|26_1>d.<>t__builder.Task;
		}

		// Token: 0x04020F70 RID: 135024
		private const int TIMERGAP = 1000;

		// Token: 0x04020F71 RID: 135025
		[Nullable(2)]
		private PopupCaptionItem CaptionItem;

		// Token: 0x04020F72 RID: 135026
		private int SelectedForgingIndex;

		// Token: 0x04020F73 RID: 135027
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private LoopScrollView<ForgingMediumItemGrid, IWeaponForgingData> ForgingItemScrollView;

		// Token: 0x04020F74 RID: 135028
		private List<IWeaponForgingData> WeaponForgingDataList = new List<IWeaponForgingData>();

		// Token: 0x04020F75 RID: 135029
		[Nullable(2)]
		private IWeaponForgingData SelectedForgingData;

		// Token: 0x04020F76 RID: 135030
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private FilterEntrance<IWeaponForgingData> FilterComponent;

		// Token: 0x04020F77 RID: 135031
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private SortEntrance<IWeaponForgingData> SortComponent;

		// Token: 0x04020F78 RID: 135032
		[Nullable(2)]
		private TimerHandle RefreshTimer;

		// Token: 0x04020F79 RID: 135033
		[Nullable(2)]
		private NumberSelectComponent NumberSelect;

		// Token: 0x04020F7A RID: 135034
		private bool NeedShowBottomText;

		// Token: 0x04020F7B RID: 135035
		private int Count = 1;

		// Token: 0x04020F7C RID: 135036
		[Nullable(2)]
		private IWeaponForgingData ItemData;

		// Token: 0x04020F7D RID: 135037
		private bool HasCoin;

		// Token: 0x04020F7E RID: 135038
		private int SingleNeedCoinCount;

		// Token: 0x04020F7F RID: 135039
		[Nullable(2)]
		private MediumItemGrid UnlockMaterialComponent;

		// Token: 0x04020F80 RID: 135040
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericScrollViewNew<ManufactureMaterialItem, ISingleItemInfo> MaterialScrollView;

		// Token: 0x04020F81 RID: 135041
		private WeaponConf? WeaponConfig;

		// Token: 0x04020F82 RID: 135042
		private WeaponBreach? WeaponBreachConfig;

		// Token: 0x04020F83 RID: 135043
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericLayout<ForgingRootView.StarItem, EStartState> StarView;

		// Token: 0x04020F84 RID: 135044
		private const int CurrentLevel = 1;

		// Token: 0x04020F85 RID: 135045
		private const int CurrentBreach = 0;

		// Token: 0x0200B971 RID: 47473
		[NullableContext(0)]
		private enum EForgingRootDefine
		{
			// Token: 0x04039475 RID: 234613
			CaptionItem,
			// Token: 0x04039476 RID: 234614
			ItemLoopScroll,
			// Token: 0x04039477 RID: 234615
			LoopScrollItem,
			// Token: 0x04039478 RID: 234616
			FilterItem,
			// Token: 0x04039479 RID: 234617
			SortItem,
			// Token: 0x0403947A RID: 234618
			ItemQualitySprite,
			// Token: 0x0403947B RID: 234619
			ItemTexture,
			// Token: 0x0403947C RID: 234620
			ItemNumberText,
			// Token: 0x0403947D RID: 234621
			ItemNameText,
			// Token: 0x0403947E RID: 234622
			ItemLevelText,
			// Token: 0x0403947F RID: 234623
			StarLayout,
			// Token: 0x04039480 RID: 234624
			StarItem,
			// Token: 0x04039481 RID: 234625
			WeaponFirstAttributeIconTexture,
			// Token: 0x04039482 RID: 234626
			WeaponFirstAttributeNameText,
			// Token: 0x04039483 RID: 234627
			WeaponFirstAttributeNumberText,
			// Token: 0x04039484 RID: 234628
			WeaponSecondAttributeIconTexture,
			// Token: 0x04039485 RID: 234629
			WeaponSecondAttributeNameText,
			// Token: 0x04039486 RID: 234630
			WeaponSecondAttributeNumberText,
			// Token: 0x04039487 RID: 234631
			WeaponRankText,
			// Token: 0x04039488 RID: 234632
			WeaponRankDesText,
			// Token: 0x04039489 RID: 234633
			WeaponMainText,
			// Token: 0x0403948A RID: 234634
			MaterialItem,
			// Token: 0x0403948B RID: 234635
			MaterialScrollView,
			// Token: 0x0403948C RID: 234636
			MaterialScrollContent,
			// Token: 0x0403948D RID: 234637
			NumberSelectItem,
			// Token: 0x0403948E RID: 234638
			BottomLeftText,
			// Token: 0x0403948F RID: 234639
			BottomTimeText,
			// Token: 0x04039490 RID: 234640
			ConfirmBtn,
			// Token: 0x04039491 RID: 234641
			LockItem,
			// Token: 0x04039492 RID: 234642
			BottomTextRootItem,
			// Token: 0x04039493 RID: 234643
			ConfirmText,
			// Token: 0x04039494 RID: 234644
			LockText,
			// Token: 0x04039495 RID: 234645
			CostItem,
			// Token: 0x04039496 RID: 234646
			CostCountText,
			// Token: 0x04039497 RID: 234647
			CostIconTexture
		}

		// Token: 0x0200B972 RID: 47474
		[NullableContext(0)]
		private enum EStarItemComponents
		{
			// Token: 0x04039499 RID: 234649
			ImgStarOn,
			// Token: 0x0403949A RID: 234650
			ImgStarOff
		}

		// Token: 0x0200B973 RID: 47475
		[Nullable(0)]
		public class StarItem : UiPanelBase, IGridProxy<EStartState>
		{
			// Token: 0x1700A990 RID: 43408
			// (get) Token: 0x0604D5EF RID: 316911 RVA: 0x0155B672 File Offset: 0x01559872
			// (set) Token: 0x0604D5F0 RID: 316912 RVA: 0x0155B67A File Offset: 0x0155987A
			[Nullable(new byte[]
			{
				2,
				1
			})]
			public IScrollViewDelegate<IGridProxy<EStartState>, EStartState> ScrollViewDelegate { [return: Nullable(new byte[]
			{
				2,
				1
			})] get; [param: Nullable(new byte[]
			{
				2,
				1
			})] set; }

			// Token: 0x1700A991 RID: 43409
			// (get) Token: 0x0604D5F1 RID: 316913 RVA: 0x0155B683 File Offset: 0x01559883
			// (set) Token: 0x0604D5F2 RID: 316914 RVA: 0x0155B68B File Offset: 0x0155988B
			public int GridIndex { get; set; }

			// Token: 0x1700A992 RID: 43410
			// (get) Token: 0x0604D5F3 RID: 316915 RVA: 0x0155B694 File Offset: 0x01559894
			// (set) Token: 0x0604D5F4 RID: 316916 RVA: 0x0155B69C File Offset: 0x0155989C
			public int DisplayIndex { get; set; }

			// Token: 0x0604D5F5 RID: 316917 RVA: 0x0155B6A5 File Offset: 0x015598A5
			public void Refresh(EStartState data, bool isSelected, int gridIndex)
			{
				if (data == EStartState.ON)
				{
					base.GetSprite(0).SetUIActive(true);
					base.GetSprite(1).SetUIActive(false);
					return;
				}
				base.GetSprite(0).SetUIActive(false);
				base.GetSprite(1).SetUIActive(true);
			}

			// Token: 0x0604D5F6 RID: 316918 RVA: 0x0155B6E2 File Offset: 0x015598E2
			public void Clear()
			{
			}

			// Token: 0x0604D5F7 RID: 316919 RVA: 0x0155B6E4 File Offset: 0x015598E4
			public void OnSelected(bool fireEvent)
			{
			}

			// Token: 0x0604D5F8 RID: 316920 RVA: 0x0155B6E6 File Offset: 0x015598E6
			public void OnDeselected(bool fireEvent)
			{
			}

			// Token: 0x0604D5F9 RID: 316921 RVA: 0x0155B6E8 File Offset: 0x015598E8
			public void CreateThenShowByActor(AActor actor)
			{
				base.CreateThenShowByActor(actor, null);
			}

			// Token: 0x0604D5FA RID: 316922 RVA: 0x0155B6F4 File Offset: 0x015598F4
			public UniTask CreateThenShowByActorAsync(AActor actor)
			{
				ForgingRootView.StarItem.<CreateThenShowByActorAsync>d__17 <CreateThenShowByActorAsync>d__;
				<CreateThenShowByActorAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
				<CreateThenShowByActorAsync>d__.<>4__this = this;
				<CreateThenShowByActorAsync>d__.actor = actor;
				<CreateThenShowByActorAsync>d__.<>1__state = -1;
				<CreateThenShowByActorAsync>d__.<>t__builder.Start<ForgingRootView.StarItem.<CreateThenShowByActorAsync>d__17>(ref <CreateThenShowByActorAsync>d__);
				return <CreateThenShowByActorAsync>d__.<>t__builder.Task;
			}

			// Token: 0x0604D5FB RID: 316923 RVA: 0x0155B740 File Offset: 0x01559940
			public UniTask CreateByActorAsync(AActor actor)
			{
				ForgingRootView.StarItem.<CreateByActorAsync>d__18 <CreateByActorAsync>d__;
				<CreateByActorAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
				<CreateByActorAsync>d__.<>4__this = this;
				<CreateByActorAsync>d__.actor = actor;
				<CreateByActorAsync>d__.<>1__state = -1;
				<CreateByActorAsync>d__.<>t__builder.Start<ForgingRootView.StarItem.<CreateByActorAsync>d__18>(ref <CreateByActorAsync>d__);
				return <CreateByActorAsync>d__.<>t__builder.Task;
			}

			// Token: 0x0604D5FC RID: 316924 RVA: 0x0155B78B File Offset: 0x0155998B
			public object GetKey(EStartState data, int gridIndex)
			{
				return data;
			}

			// Token: 0x0604D5FD RID: 316925 RVA: 0x0155B794 File Offset: 0x01559994
			protected unsafe override void OnRegisterComponent()
			{
				int num = 2;
				List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
				CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
				Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
				int num2 = 0;
				*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
				num2++;
				*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
				this.ComponentRegisterInfos = list;
				this.BtnBindInfo = new List<ValueTuple<int, Delegate>>();
			}

			// Token: 0x0604D5FE RID: 316926 RVA: 0x0155B808 File Offset: 0x01559A08
			public void SetState(bool isOn)
			{
			}
		}
	}
}
