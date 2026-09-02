using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.Common.NumberSelect;
using CSharpScript.Game.Module.FilterSort.Sort.SortEntrance;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.Manufacture.Common;
using CSharpScript.Game.Module.Manufacture.Common.Item;
using CSharpScript.Game.Module.Manufacture.Compose.Item;
using CSharpScript.Game.Module.Manufacture.Compose.QuicklyPopup;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Manufacture.Compose.View
{
	// Token: 0x020059C3 RID: 22979
	[NullableContext(1)]
	[Nullable(0)]
	public class ComposeCarryOnView : UiViewBase
	{
		// Token: 0x0603A319 RID: 238361 RVA: 0x00EBC238 File Offset: 0x00EBA438
		public ComposeCarryOnView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603A31A RID: 238362 RVA: 0x00EBC2A0 File Offset: 0x00EBA4A0
		protected unsafe override void OnRegisterComponent()
		{
			int num = 44;
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
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(17, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(18, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(19, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(20, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(21, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(22, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(23, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(24, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(25, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(26, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(27, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(28, typeof(UUILoopScrollViewComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(29, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(30, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(31, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(32, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(33, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(34, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(35, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(36, typeof(UUIHorizontalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(37, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(38, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(39, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(40, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(41, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(42, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(43, typeof(UUIText));
			this.ComponentRegisterInfos = list;
			num2 = 3;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(4, new Action(this.OnClickComposeLevelBtn));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(24, new Action(this.OnClickConfirmBtn));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(27, new Action(this.OnClickLeftPopItemCloseBtn));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603A31B RID: 238363 RVA: 0x00EBC91C File Offset: 0x00EBAB1C
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.ComposeSuccess, new Action(this.OnCookResponse));
			Singleton<EventSystem>.Instance.Add(EEventName.ComposeFail, new Action(this.OnCookResponse));
			Singleton<EventSystem>.Instance.Add<EUiViewName, int>(EEventName.CloseView, new Action<EUiViewName, int>(this.OnCloseView));
			Singleton<EventSystem>.Instance.Add<EComposeListType, int>(EEventName.ComposeSwitchType, new Action<EComposeListType, int>(this.ComposeSwitchType));
			Singleton<EventSystem>.Instance.Add(EEventName.UpgradeComposeLevel, new Action(this.SwitchComposeLevelShow));
			Singleton<EventSystem>.Instance.Add<int, int>(EEventName.OnCommonItemCountAnyChange, new Action<int, int>(this.OnCommonItemCountAnyChange));
			this.RefreshTimer = TimerSystem.Instance.Forever(new TTimerAction(this.OnSecondTimerRefresh), 1000f, 1f, null, null, true);
		}

		// Token: 0x0603A31C RID: 238364 RVA: 0x00EBC9F8 File Offset: 0x00EBABF8
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.ComposeSuccess, new Action(this.OnCookResponse));
			Singleton<EventSystem>.Instance.Remove(EEventName.ComposeFail, new Action(this.OnCookResponse));
			Singleton<EventSystem>.Instance.Remove(EEventName.CloseView, new Action<EUiViewName, int>(this.OnCloseView));
			Singleton<EventSystem>.Instance.Remove(EEventName.ComposeSwitchType, new Action<EComposeListType, int>(this.ComposeSwitchType));
			Singleton<EventSystem>.Instance.Remove(EEventName.UpgradeComposeLevel, new Action(this.SwitchComposeLevelShow));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnCommonItemCountAnyChange, new Action<int, int>(this.OnCommonItemCountAnyChange));
			if (this.RefreshTimer != null && TimerSystem.Instance.Has(this.RefreshTimer))
			{
				TimerSystem.Instance.Remove(this.RefreshTimer);
				this.RefreshTimer = null;
			}
		}

		// Token: 0x0603A31D RID: 238365 RVA: 0x00EBCADC File Offset: 0x00EBACDC
		protected override UniTask OnBeforeStartAsync()
		{
			ComposeCarryOnView.<OnBeforeStartAsync>d__41 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<ComposeCarryOnView.<OnBeforeStartAsync>d__41>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603A31E RID: 238366 RVA: 0x00EBCB1F File Offset: 0x00EBAD1F
		protected override void OnStart()
		{
			Singleton<CommonManager>.Instance.SetCurrentSystem(ESystemType.ComposeSystem);
		}

		// Token: 0x0603A31F RID: 238367 RVA: 0x00EBCB2C File Offset: 0x00EBAD2C
		protected override void OnBeforeShow()
		{
			ComposeViewOpenData composeViewOpenData = this.OpenParam as ComposeViewOpenData;
			this.TipsItemData = ((composeViewOpenData != null) ? composeViewOpenData.SelectData : null);
			this.SkipSourceView = ((composeViewOpenData != null) ? composeViewOpenData.SkipSourceView : null);
			ISelectedData tipsItemData = this.TipsItemData;
			this.TargetItem = ((tipsItemData != null) ? tipsItemData.ItemId : 0);
			this.ShowComposeMainView((composeViewOpenData != null) ? this.TabList.IndexOf(composeViewOpenData.Type) : 0);
			this.TargetItem = 0;
		}

		// Token: 0x0603A320 RID: 238368 RVA: 0x00EBCBAD File Offset: 0x00EBADAD
		protected override void OnBeforeDestroy()
		{
			ModelBase<ComposeModel>.Instance.CurrentComposeListType = EComposeListType.Purification;
		}

		// Token: 0x0603A321 RID: 238369 RVA: 0x00EBCBBC File Offset: 0x00EBADBC
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
		{
			if (configParams.Length < 1)
			{
				return null;
			}
			int item = int.Parse(configParams[0]);
			int num = this.TabList.IndexOf((EComposeListType)item);
			if (num < 0)
			{
				return null;
			}
			TabComponentWithCaptionItem<CommonTabItem> tabComponent = this.TabComponent;
			UUIItem uuiitem;
			if (tabComponent == null)
			{
				uuiitem = null;
			}
			else
			{
				CommonTabItem tabItemByIndex = tabComponent.GetTabItemByIndex(num);
				uuiitem = ((tabItemByIndex != null) ? tabItemByIndex.GetRootItem() : null);
			}
			UUIItem uuiitem2 = uuiitem;
			if (uuiitem2 == null)
			{
				return null;
			}
			return new UUIItem[]
			{
				uuiitem2,
				uuiitem2
			};
		}

		// Token: 0x0603A322 RID: 238370 RVA: 0x00EBCC20 File Offset: 0x00EBAE20
		private void SetSum(int sum)
		{
			this.Count = sum;
			this.RefreshMaterialNeedNum();
			bool flag = ModelBase<ComposeModel>.Instance.CurrentComposeListType == EComposeListType.Collect;
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(30), flag ? "GatherCraft_Quantity_Text" : "Text_ItemSelectSynthesisQuantityTip_text", new <>z__ReadOnlySingleElementList<object>(this.Count));
			if (this.ItemData != null && this.ItemData.MainType == EComposeListType.ReagentProduction)
			{
				int maxCreateCount = ControllerBase<ComposeController>.Instance.GetMaxCreateCount(this.ItemData.ConfigId, this.ItemData);
				this.NumberSelect.SetAddButtonInteractive(sum < maxCreateCount);
				this.NumberSelect.SetReduceButtonInteractive(sum > 1);
				this.RefreshProficiency(true);
			}
		}

		// Token: 0x0603A323 RID: 238371 RVA: 0x00EBCCD0 File Offset: 0x00EBAED0
		private bool CanToggleChange(int arg1, bool? arg2)
		{
			if (this.NoCircleExhibitionView.MovingState())
			{
				return false;
			}
			if (Singleton<Info>.Instance.IsInGamepad())
			{
				return true;
			}
			int? intConfig = ConfigCommonParamById.GetIntConfig("panel_interval_time");
			return this.LastClickTime == 0.0 || Singleton<Time>.Instance.Now - this.LastClickTime >= (double)intConfig.Value;
		}

		// Token: 0x0603A324 RID: 238372 RVA: 0x00EBCD34 File Offset: 0x00EBAF34
		private void RefreshProficiency(bool isVisible)
		{
			if (!isVisible)
			{
				base.GetText(14).SetUIActive(false);
				return;
			}
			base.GetText(14).SetUIActive(true);
			IReagentProductionData reagentProductionData = this.ItemData as IReagentProductionData;
			SynthesisFormula? synthesisFormulaById = ConfigBase<ComposeConfig>.Instance.GetSynthesisFormulaById(reagentProductionData.ConfigId);
			int proficiency = synthesisFormulaById.Value.Proficiency;
			int maxProficiencyCount = synthesisFormulaById.Value.MaxProficiencyCount;
			this.SetExpNum(reagentProductionData.ComposeCount, proficiency, maxProficiencyCount, this.Count);
		}

		// Token: 0x0603A325 RID: 238373 RVA: 0x00EBCDB4 File Offset: 0x00EBAFB4
		private void RefreshMaterialNeedNum()
		{
			this.RefreshCost(this.HasCoin, this.SingleNeedCoinCount * this.Count);
			if (this.ItemData != null && ModelBase<ComposeModel>.Instance.IsInPurificationList())
			{
				List<IComposeItemData> source = ModelBase<ComposeModel>.Instance.CalculateNeedComposeMaterialList(this.ItemData.ConfigId, this.Count);
				ModelBase<ComposeModel>.Instance.SetCurrentComposeMaterialList((from item in source
				select new SingleItemInfo
				{
					ItemId = item.ItemId,
					ItemNum = item.RequiredNum
				}).ToList<SingleItemInfo>());
				List<IComposeItemData> uiList = source.AsEnumerable<IComposeItemData>().Reverse<IComposeItemData>().ToList<IComposeItemData>();
				GenericScrollViewNew<ManufactureMaterialItem, ISingleItemInfo> materialScrollView = this.MaterialScrollView;
				if (materialScrollView == null)
				{
					return;
				}
				materialScrollView.RefreshByData((from item in uiList
				select new ISingleItemInfo
				{
					Proto_ItemId = item.ItemId,
					Proto_ItemNum = item.RequiredNum,
					Proto_IsUnlock = true
				}).ToList<ISingleItemInfo>(), delegate
				{
					GenericScrollViewNew<ManufactureMaterialItem, ISingleItemInfo> materialScrollView3 = this.MaterialScrollView;
					List<ManufactureMaterialItem> list2 = (materialScrollView3 != null) ? materialScrollView3.GetScrollItemList() : null;
					if (list2 != null)
					{
						for (int i = 0; i < list2.Count; i++)
						{
							list2[i].SetNeedNum(uiList[i].RequiredNum);
						}
					}
				}, false);
				return;
			}
			else
			{
				GenericScrollViewNew<ManufactureMaterialItem, ISingleItemInfo> materialScrollView2 = this.MaterialScrollView;
				List<ManufactureMaterialItem> list = (materialScrollView2 != null) ? materialScrollView2.GetScrollItemList() : null;
				if (list == null)
				{
					return;
				}
				foreach (ManufactureMaterialItem manufactureMaterialItem in list)
				{
					manufactureMaterialItem.SetUiActive(true);
					manufactureMaterialItem.SetTimes(this.Count);
				}
				return;
			}
		}

		// Token: 0x0603A326 RID: 238374 RVA: 0x00EBCF18 File Offset: 0x00EBB118
		private void RefreshCost(bool hasCoin, int count)
		{
			if (!hasCoin)
			{
				UUITexture texture = base.GetTexture(32);
				if (texture != null)
				{
					texture.SetUIActive(false);
				}
				base.GetText(31).SetUIActive(false);
				return;
			}
			UUITexture texture2 = base.GetTexture(32);
			if (texture2 != null)
			{
				texture2.SetUIActive(true);
			}
			base.GetText(31).SetUIActive(true);
			int itemCountByConfigId = ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(ControllerBase<ComposeController>.Instance.ComposeCoinId, 0);
			ItemInfo? config = ConfigBase<CSharpScript.Game.Module.Item.ItemConfig>.Instance.GetConfig(ControllerBase<ComposeController>.Instance.ComposeCoinId);
			if (itemCountByConfigId < count)
			{
				base.GetText(31).SetText(StringUtils.Format("<color=#c25757>{0}</color>", new string[]
				{
					count.ToString()
				}), true);
			}
			else
			{
				base.GetText(31).SetText(count.ToString(), true);
			}
			base.SetTextureByPath(config.Value.IconSmall, base.GetTexture(32), null, null);
		}

		// Token: 0x0603A327 RID: 238375 RVA: 0x00EBD000 File Offset: 0x00EBB200
		private unsafe void SetExpNum(int count, int single, int sum, int times)
		{
			int num = single * sum;
			int num2 = count * single;
			int num3 = num - num2;
			string text = StringUtils.Format(ConfigBase<TextConfig>.Instance.GetTextById("CumulativeProficiency"), new string[]
			{
				num2.ToString(),
				num.ToString()
			});
			if (num3 > 0)
			{
				int val = Math.Min(num3, single * times);
				string textById = ConfigBase<TextConfig>.Instance.GetTextById("AddProficiency");
				string[] array = new string[1];
				int num4 = 0;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
				defaultInterpolatedStringHandler.AppendLiteral("+");
				defaultInterpolatedStringHandler.AppendFormatted<int>(Math.Min(val, num3));
				array[num4] = defaultInterpolatedStringHandler.ToStringAndClear();
				string text2 = StringUtils.Format(textById, array);
				<>y__InlineArray5<string> <>y__InlineArray = default(<>y__InlineArray5<string>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<string>, string>(ref <>y__InlineArray, 0) = text2;
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<string>, string>(ref <>y__InlineArray, 1) = " ";
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<string>, string>(ref <>y__InlineArray, 2) = "(";
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<string>, string>(ref <>y__InlineArray, 3) = text;
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<string>, string>(ref <>y__InlineArray, 4) = ")";
				string newText = string.Concat(<PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray5<string>, string>(<>y__InlineArray, 5));
				base.GetText(14).SetText(newText, true);
				return;
			}
			string text3 = StringUtils.Format(ConfigBase<TextConfig>.Instance.GetTextById("AddProficiency"), new string[]
			{
				""
			});
			<>y__InlineArray5<string> <>y__InlineArray2 = default(<>y__InlineArray5<string>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<string>, string>(ref <>y__InlineArray2, 0) = text3;
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<string>, string>(ref <>y__InlineArray2, 1) = " ";
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<string>, string>(ref <>y__InlineArray2, 2) = "(";
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<string>, string>(ref <>y__InlineArray2, 3) = text;
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<string>, string>(ref <>y__InlineArray2, 4) = ")";
			string newText2 = string.Concat(<PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray5<string>, string>(<>y__InlineArray2, 5));
			base.GetText(14).SetText(newText2, true);
		}

		// Token: 0x0603A328 RID: 238376 RVA: 0x00EBD198 File Offset: 0x00EBB398
		private ManufactureMaterialItem OnMaterialItemCreate()
		{
			ManufactureMaterialItem manufactureMaterialItem = new ManufactureMaterialItem();
			manufactureMaterialItem.BindOnCanExecuteChange((object _, bool _, EToggleState _) => false);
			manufactureMaterialItem.BindOnExtendToggleClicked(delegate(MediumItemGridExtendCallback callbackParameter)
			{
				ISingleItemInfo singleItemInfo = callbackParameter.Data as ISingleItemInfo;
				if (this.ItemData.MainType == EComposeListType.Exchange)
				{
					this.OpenLeftPopView();
					return;
				}
				ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(singleItemInfo.Proto_ItemId, true, null);
			});
			manufactureMaterialItem.BindEmptySlotButtonCallback(delegate(MediumItemGridButtonCallback _)
			{
				this.OpenLeftPopView();
			});
			return manufactureMaterialItem;
		}

		// Token: 0x0603A329 RID: 238377 RVA: 0x00EBD1F3 File Offset: 0x00EBB3F3
		private ComposeExchangeItem OnExchangeMaterialItemCreate()
		{
			ComposeExchangeItem composeExchangeItem = new ComposeExchangeItem();
			composeExchangeItem.BindOnExtendToggleClicked(delegate(MediumItemGridExtendCallback callbackParameter)
			{
				ISingleItemInfo singleItemInfo = callbackParameter.Data as ISingleItemInfo;
				UUIExtendToggle currentSelectExchangeScrollToggle = this.CurrentSelectExchangeScrollToggle;
				if (currentSelectExchangeScrollToggle != null)
				{
					currentSelectExchangeScrollToggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
				}
				this.CurrentSelectExchangeScrollToggle = callbackParameter.MediumItemGrid.GetItemGridExtendToggle();
				if (singleItemInfo.Proto_ItemNum <= 1)
				{
					ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(singleItemInfo.Proto_ItemId, true, null);
					return;
				}
				this.CurrentSelectExchangeMaterialItem = singleItemInfo.Proto_ItemId;
				this.RefreshExchangeMaterialBySelect(null);
			});
			return composeExchangeItem;
		}

		// Token: 0x0603A32A RID: 238378 RVA: 0x00EBD20C File Offset: 0x00EBB40C
		private void OnFilterSortRefresh(List<IBaseItemData> list, bool arg1, EFilterSortType arg2)
		{
			IEnumerable<IBaseItemData> source = from data in list
			where data.ExistStartTime <= 0.0 || Singleton<TimeUtil>.Instance.IsInTimeSpan(data.ExistStartTime, data.ExistEndTime)
			select data;
			this.SelectedItemId = 0;
			switch (ModelBase<ComposeModel>.Instance.CurrentComposeListType)
			{
			case EComposeListType.ReagentProduction:
				this.ReagentProductionDataList = source.Cast<IReagentProductionData>().ToList<IReagentProductionData>();
				break;
			case EComposeListType.Structure:
				this.StructureDataList = source.Cast<IStructureData>().ToList<IStructureData>();
				break;
			case EComposeListType.Purification:
				this.PurificationDataList = source.Cast<IPurificationData>().ToList<IPurificationData>();
				break;
			case EComposeListType.Exchange:
				this.ExchangeDataList = source.Cast<IExchangeData>().ToList<IExchangeData>();
				break;
			case EComposeListType.Collect:
				this.CollectDataList = source.Cast<ICollectData>().ToList<ICollectData>();
				break;
			}
			this.ComposeItemScrollView.DeselectCurrentGridProxy(false);
			this.RefreshItemScrollView();
			if (source.Count<IBaseItemData>() == 0)
			{
				return;
			}
			this.SetSelectedComposeItem(true);
		}

		// Token: 0x0603A32B RID: 238379 RVA: 0x00EBD2EE File Offset: 0x00EBB4EE
		private ComposeMediumItemGrid OnGridProxyCreate()
		{
			ComposeMediumItemGrid composeMediumItemGrid = new ComposeMediumItemGrid();
			composeMediumItemGrid.BindOnExtendToggleStateChanged(new Action<MediumItemGridExtendCallback>(this.OnComposeItemClick));
			return composeMediumItemGrid;
		}

		// Token: 0x0603A32C RID: 238380 RVA: 0x00EBD308 File Offset: 0x00EBB508
		private void RefreshItemScrollView()
		{
			switch (ModelBase<ComposeModel>.Instance.CurrentComposeListType)
			{
			case EComposeListType.ReagentProduction:
				this.ComposeItemScrollView.RefreshByData(this.ReagentProductionDataList.ConvertAll<IBaseItemData>(([Nullable(1)] IReagentProductionData v) => v), false, null, false);
				return;
			case EComposeListType.Structure:
				this.ComposeItemScrollView.RefreshByData(this.StructureDataList.ConvertAll<IBaseItemData>(([Nullable(1)] IStructureData v) => v), false, null, false);
				return;
			case EComposeListType.Purification:
				this.ComposeItemScrollView.RefreshByData(this.PurificationDataList.ConvertAll<IBaseItemData>(([Nullable(1)] IPurificationData v) => v), false, null, false);
				return;
			case EComposeListType.Exchange:
				this.ComposeItemScrollView.RefreshByData(this.ExchangeDataList.ConvertAll<IBaseItemData>(([Nullable(1)] IExchangeData v) => v), false, null, false);
				return;
			case EComposeListType.Collect:
				this.ComposeItemScrollView.RefreshByData(this.CollectDataList.ConvertAll<IBaseItemData>(([Nullable(1)] ICollectData v) => v), false, null, false);
				return;
			default:
				return;
			}
		}

		// Token: 0x0603A32D RID: 238381 RVA: 0x00EBD45C File Offset: 0x00EBB65C
		private void ShowComposeMainView(int selectNumber = 0)
		{
			if (selectNumber == 0)
			{
				EFilterSortGroupId groupId = EFilterSortGroupId.PurificationList;
				this.SortComponent.SetResultDataDirty();
				this.SortComponent.UpdateData(groupId, this.GetItemList(), Array.Empty<object>());
				int uniqueIdByGroupId = this.SortComponent.GetUniqueIdByGroupId(groupId);
				this.FilterComponent.SetSortUniqueId(uniqueIdByGroupId);
				this.FilterComponent.SetActive(true);
				this.FilterComponent.UpdateData(groupId, this.GetItemList(), Array.Empty<object>());
				int uniqueIdByGroupId2 = this.FilterComponent.GetUniqueIdByGroupId(groupId);
				this.SortComponent.SetFilterUniqueId(uniqueIdByGroupId2);
			}
			TabComponentWithCaptionItem<CommonTabItem> tabComponent = this.TabComponent;
			if (tabComponent != null)
			{
				tabComponent.SelectToggleByIndex(selectNumber, true);
			}
			this.OnShowRedDot();
			this.SwitchComposeLevelShow();
		}

		// Token: 0x0603A32E RID: 238382 RVA: 0x00EBD505 File Offset: 0x00EBB705
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		private List<IBaseItemData> GetItemList()
		{
			return this.GetItemListByType(ModelBase<ComposeModel>.Instance.CurrentComposeListType);
		}

		// Token: 0x0603A32F RID: 238383 RVA: 0x00EBD518 File Offset: 0x00EBB718
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		private List<IBaseItemData> GetItemListByType(EComposeListType type)
		{
			List<IBaseItemData> result;
			switch (type)
			{
			case EComposeListType.ReagentProduction:
			{
				List<IReagentProductionData> reagentProductionDataList = ModelBase<ComposeModel>.Instance.GetReagentProductionDataList();
				List<IBaseItemData> list;
				if (reagentProductionDataList == null)
				{
					list = null;
				}
				else
				{
					list = reagentProductionDataList.ConvertAll<IBaseItemData>(([Nullable(1)] IReagentProductionData v) => v);
				}
				result = list;
				break;
			}
			case EComposeListType.Structure:
			{
				List<IStructureData> structureDataList = ModelBase<ComposeModel>.Instance.GetStructureDataList();
				List<IBaseItemData> list2;
				if (structureDataList == null)
				{
					list2 = null;
				}
				else
				{
					list2 = structureDataList.ConvertAll<IBaseItemData>(([Nullable(1)] IStructureData v) => v);
				}
				result = list2;
				break;
			}
			case EComposeListType.Purification:
			{
				List<IPurificationData> purificationDataList = ModelBase<ComposeModel>.Instance.GetPurificationDataList();
				List<IBaseItemData> list3;
				if (purificationDataList == null)
				{
					list3 = null;
				}
				else
				{
					list3 = purificationDataList.ConvertAll<IBaseItemData>(([Nullable(1)] IPurificationData v) => v);
				}
				result = list3;
				break;
			}
			case EComposeListType.Exchange:
			{
				List<IExchangeData> exchangeDataList = ModelBase<ComposeModel>.Instance.GetExchangeDataList();
				List<IBaseItemData> list4;
				if (exchangeDataList == null)
				{
					list4 = null;
				}
				else
				{
					list4 = exchangeDataList.ConvertAll<IBaseItemData>(([Nullable(1)] IExchangeData v) => v);
				}
				result = list4;
				break;
			}
			case EComposeListType.Collect:
			{
				List<ICollectData> collectDataList = ModelBase<ComposeModel>.Instance.GetCollectDataList();
				List<IBaseItemData> list5;
				if (collectDataList == null)
				{
					list5 = null;
				}
				else
				{
					list5 = collectDataList.ConvertAll<IBaseItemData>(([Nullable(1)] ICollectData v) => v);
				}
				result = list5;
				break;
			}
			default:
				return null;
			}
			return result;
		}

		// Token: 0x0603A330 RID: 238384 RVA: 0x00EBD66C File Offset: 0x00EBB86C
		private void SwitchComposeLevelShow()
		{
			(base.GetButton(4).GetOwner() as AUIBaseActor).GetUIItem().SetUIActive(ModelBase<ComposeModel>.Instance.CurrentComposeListType == EComposeListType.ReagentProduction);
			int? composeMaxLevel = Singleton<CommonManager>.Instance.GetComposeMaxLevel();
			int? currentRewardLevel = Singleton<CommonManager>.Instance.GetCurrentRewardLevel();
			this.StartLevelComponent.ShowLevel(currentRewardLevel.Value, composeMaxLevel.Value);
			this.SetComposeLevelSprite();
		}

		// Token: 0x0603A331 RID: 238385 RVA: 0x00EBD6D6 File Offset: 0x00EBB8D6
		private void OnCommonItemCountAnyChange(int i, int i1)
		{
			if (ModelBase<ComposeModel>.Instance.CurrentComposeListType == EComposeListType.Exchange)
			{
				return;
			}
			this.TargetItem = this.SelectedItemId;
			this.SwitchComposeLevelShow();
			this.SwitchComposeItemScroll();
			this.TargetItem = 0;
		}

		// Token: 0x0603A332 RID: 238386 RVA: 0x00EBD708 File Offset: 0x00EBB908
		private void SetComposeLevelSprite()
		{
			if (ModelBase<ComposeModel>.Instance.CurrentComposeListType == EComposeListType.ReagentProduction)
			{
				string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("SP_ReagentProductionLevel");
				this.SetSpriteByPath(resourcePath, base.GetSprite(35), false, null, null);
			}
		}

		// Token: 0x0603A333 RID: 238387 RVA: 0x00EBD74C File Offset: 0x00EBB94C
		private void OnShowRedDot()
		{
			ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.ComposeReagentProduction, base.GetItem(34), null, 0);
		}

		// Token: 0x0603A334 RID: 238388 RVA: 0x00EBD764 File Offset: 0x00EBB964
		private void RefreshLimitTime()
		{
			if (this.ItemData.ExistEndTime <= 0.0 && this.ItemData.TotalMakeCountInLimitTime <= 0)
			{
				UUIText text = base.GetText(23);
				if (text == null)
				{
					return;
				}
				text.SetUIActive(false);
				return;
			}
			else
			{
				this.BottomTextNeedShow = true;
				UUIText text2 = base.GetText(23);
				if (text2 != null)
				{
					text2.SetUIActive(true);
				}
				if (this.ItemData.IsLimitForever)
				{
					global::CommonDefine.ICountDown remainTimeDataFormat = Singleton<TimeUtil>.Instance.GetRemainTimeDataFormat(this.ItemData.ExistEndTime - Singleton<TimeUtil>.Instance.GetServerTime());
					Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(23), "RemainingTime", new <>z__ReadOnlySingleElementList<object>(remainTimeDataFormat));
					return;
				}
				string refreshLimitTime = ModelBase<ComposeModel>.Instance.GetRefreshLimitTime();
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(23), "RefreshTime", new <>z__ReadOnlySingleElementList<object>(refreshLimitTime));
				return;
			}
		}

		// Token: 0x0603A335 RID: 238389 RVA: 0x00EBD838 File Offset: 0x00EBBA38
		private void RefreshMaterial()
		{
			this.Count = 1;
			int maxCreateCount = ControllerBase<ComposeController>.Instance.GetMaxCreateCount(this.ItemData.ConfigId, this.ItemData);
			this.NumberSelect.ResetLimitMaxValue();
			this.NumberSelect.Refresh(maxCreateCount);
			this.NumberSelect.SetMaxBtnShowState(maxCreateCount > 1);
			if (this.TipsItemData != null)
			{
				SynthesisFormula? synthesisFormula;
				int? num = (ConfigBase<ComposeConfig>.Instance.GetSynthesisFormulaById(this.ItemData.ConfigId) != null) ? new int?(synthesisFormula.GetValueOrDefault().ItemId) : null;
				int itemId = this.TipsItemData.ItemId;
				if (num.GetValueOrDefault() == itemId & num != null)
				{
					int num2 = this.TipsItemData.Count - this.TipsItemData.SelectedCount;
					if (num2 > 0)
					{
						if (num2 <= maxCreateCount)
						{
							this.NumberSelect.ChangeValue(num2, true);
						}
						else if (maxCreateCount >= 1)
						{
							this.NumberSelect.ChangeValue(maxCreateCount, true);
						}
					}
				}
			}
			this.NumberSelect.SetAddReduceButtonActive(true);
			this.NumberSelect.SetReduceButtonInteractive(this.Count > 1);
			this.NumberSelect.SetUiActive(this.ItemData.IsUnlock > 0);
			base.GetText(30).SetUIActive(this.ItemData.IsUnlock > 0);
			if (this.ItemData.IsUnlock > 0)
			{
				this.UnlockMaterialComponent.SetUiActive(false);
				this.MaterialScrollView.SetActive(true);
				List<ISingleItemInfo> list = ModelBase<ComposeModel>.Instance.GetComposeMaterialList(this.ItemData.ConfigId);
				ValueTuple<bool, int, List<ISingleItemInfo>> valueTuple = this.FilterMaterialList(list);
				bool item = valueTuple.Item1;
				int item2 = valueTuple.Item2;
				List<ISingleItemInfo> item3 = valueTuple.Item3;
				this.HasCoin = item;
				this.SingleNeedCoinCount = item2;
				list = item3;
				if (ModelBase<ComposeModel>.Instance.IsInPurificationList())
				{
					ModelBase<ComposeModel>.Instance.SetCurrentComposeMaterialList(new List<SingleItemInfo>());
					list.Reverse();
					foreach (ISingleItemInfo singleItemInfo in list)
					{
						ModelBase<ComposeModel>.Instance.GetCurrentComposeMaterialList().Add(new SingleItemInfo
						{
							ItemId = singleItemInfo.Proto_ItemId,
							ItemNum = singleItemInfo.Proto_ItemNum
						});
					}
				}
				this.MaterialScrollView.RefreshByData(list, new Action(this.RefreshMaterialNeedNum), false);
				return;
			}
			this.UnlockMaterialComponent.SetUiActive(true);
			this.MaterialScrollView.SetActive(false);
			SynthesisFormula? synthesisFormulaById = ConfigBase<ComposeConfig>.Instance.GetSynthesisFormulaById(this.ItemData.ConfigId);
			ItemInfo? itemConfig = ConfigBase<InventoryConfig>.Instance.GetItemConfig(synthesisFormulaById.Value.FormulaItemId);
			if (itemConfig == null)
			{
				return;
			}
			PropMediumItemGrid parameters = new PropMediumItemGrid
			{
				Data = synthesisFormulaById.Value.FormulaItemId,
				ItemConfigId = new int?(synthesisFormulaById.Value.FormulaItemId),
				BottomTextId = itemConfig.Value.Name,
				IsProhibit = new bool?(true),
				IsOmitBottomText = new bool?(true)
			};
			this.UnlockMaterialComponent.Apply<PropMediumItemGrid>(parameters);
		}

		// Token: 0x0603A336 RID: 238390 RVA: 0x00EBDB78 File Offset: 0x00EBBD78
		private void RefreshExchangeMaterial()
		{
			this.Count = 1;
			this.NumberSelect.SetAddReduceButtonActive(true);
			this.NumberSelect.SetReduceButtonInteractive(true);
			this.NumberSelect.SetUiActive(false);
			this.NumberSelect.SetMaxBtnShowState(true);
			base.GetText(30).SetUIActive(true);
			this.UnlockMaterialComponent.SetUiActive(false);
			this.MaterialScrollView.SetActive(true);
			this.HasCoin = false;
			this.SingleNeedCoinCount = 0;
			this.CurrentSelectExchangeMaterialItem = 0;
			GenericScrollViewNew<ManufactureMaterialItem, ISingleItemInfo> materialScrollView = this.MaterialScrollView;
			if (materialScrollView != null)
			{
				materialScrollView.RefreshByData(new <>z__ReadOnlySingleElementList<ISingleItemInfo>(new ISingleItemInfo
				{
					Proto_ItemId = 0,
					Proto_ItemNum = 0,
					Proto_IsUnlock = true,
					IsEmpty = new bool?(true)
				}), null, false);
			}
			this.NumberSelect.Refresh(0);
		}

		// Token: 0x0603A337 RID: 238391 RVA: 0x00EBDC44 File Offset: 0x00EBBE44
		[NullableContext(2)]
		private void RefreshExchangeMaterialBySelect(Action callback = null)
		{
			ComposeCarryOnView.<>c__DisplayClass67_0 CS$<>8__locals1 = new ComposeCarryOnView.<>c__DisplayClass67_0();
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.callback = callback;
			CS$<>8__locals1.<RefreshExchangeMaterialBySelect>g__RefreshDataAsync|0().Forget();
			NumberSelectComponent numberSelect = this.NumberSelect;
			if (numberSelect != null)
			{
				numberSelect.SetUiActive(true);
			}
			int itemCountByConfigId = ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(this.CurrentSelectExchangeMaterialItem, 0);
			NumberSelectComponent numberSelect2 = this.NumberSelect;
			if (numberSelect2 != null)
			{
				numberSelect2.Refresh(itemCountByConfigId / 2);
			}
			UUIText text = base.GetText(43);
			if (text == null)
			{
				return;
			}
			text.SetUIActive(false);
		}

		// Token: 0x0603A338 RID: 238392 RVA: 0x00EBDCBC File Offset: 0x00EBBEBC
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

		// Token: 0x0603A339 RID: 238393 RVA: 0x00EBDD08 File Offset: 0x00EBBF08
		private void SetSelectedComposeItem(bool isNeedScroll = false)
		{
			int num = 0;
			if (this.TargetItem != 0)
			{
				this.IsRefreshByClick = true;
			}
			switch (ModelBase<ComposeModel>.Instance.CurrentComposeListType)
			{
			case EComposeListType.ReagentProduction:
			{
				num = ((this.TargetItem != 0) ? this.GetTargetItemIndex(this.ReagentProductionDataList.Cast<IBaseItemData>().ToArray<IBaseItemData>()) : this.GetKeepSelectItemIndex(this.ReagentProductionDataList.Cast<IBaseItemData>().ToArray<IBaseItemData>()));
				IReagentProductionData reagentProductionData = this.ReagentProductionDataList[num];
				this.RefreshTips(reagentProductionData, true);
				this.SelectedItemId = ConfigBase<ComposeConfig>.Instance.GetSynthesisFormulaById(reagentProductionData.ConfigId).Value.ItemId;
				break;
			}
			case EComposeListType.Structure:
			{
				num = ((this.TargetItem != 0) ? this.GetTargetItemIndex(this.StructureDataList.Cast<IBaseItemData>().ToArray<IBaseItemData>()) : this.GetKeepSelectItemIndex(this.StructureDataList.Cast<IBaseItemData>().ToArray<IBaseItemData>()));
				IStructureData structureData = this.StructureDataList[num];
				this.RefreshTips(structureData, true);
				this.SelectedItemId = ConfigBase<ComposeConfig>.Instance.GetSynthesisFormulaById(structureData.ConfigId).Value.ItemId;
				break;
			}
			case EComposeListType.Purification:
			{
				num = ((this.TargetItem != 0) ? this.GetTargetItemIndex(this.PurificationDataList.Cast<IBaseItemData>().ToArray<IBaseItemData>()) : this.GetKeepSelectItemIndex(this.PurificationDataList.Cast<IBaseItemData>().ToArray<IBaseItemData>()));
				IPurificationData purificationData = this.PurificationDataList[num];
				this.RefreshTips(purificationData, true);
				this.SelectedItemId = ConfigBase<ComposeConfig>.Instance.GetSynthesisFormulaById(purificationData.ConfigId).Value.ItemId;
				break;
			}
			case EComposeListType.Exchange:
			{
				if (this.TargetItem != 0)
				{
					num = this.ExchangeDataList.FindIndex((IExchangeData data) => data.ConfigId == this.TargetItem);
				}
				else
				{
					num = this.ExchangeDataList.FindIndex((IExchangeData data) => data.ConfigId == this.SelectedItemId);
				}
				num = ((num >= 0) ? num : 0);
				IExchangeData exchangeData = this.ExchangeDataList[num];
				this.RefreshTips(exchangeData, true);
				this.SelectedItemId = exchangeData.ConfigId;
				break;
			}
			case EComposeListType.Collect:
			{
				num = ((this.TargetItem != 0) ? this.GetTargetItemIndex(this.CollectDataList.Cast<IBaseItemData>().ToArray<IBaseItemData>()) : this.GetKeepSelectItemIndex(this.CollectDataList.Cast<IBaseItemData>().ToArray<IBaseItemData>()));
				ICollectData collectData = this.CollectDataList[num];
				this.RefreshTips(collectData, true);
				this.SelectedItemId = ConfigBase<ComposeConfig>.Instance.GetSynthesisFormulaById(collectData.ConfigId).Value.ItemId;
				break;
			}
			}
			this.ComposeItemScrollView.DeselectCurrentGridProxy(false);
			if (isNeedScroll)
			{
				this.ComposeItemScrollView.ScrollToGridIndex(num, true);
			}
			this.ComposeItemScrollView.SelectGridProxy(num, false);
		}

		// Token: 0x0603A33A RID: 238394 RVA: 0x00EBDFC8 File Offset: 0x00EBC1C8
		private int GetTargetItemIndex(IBaseItemData[] itemList)
		{
			int num = Array.FindIndex<IBaseItemData>(itemList, delegate(IBaseItemData data)
			{
				SynthesisFormula? synthesisFormula;
				int? num2 = (ConfigBase<ComposeConfig>.Instance.GetSynthesisFormulaById(data.ConfigId) != null) ? new int?(synthesisFormula.GetValueOrDefault().ItemId) : null;
				int targetItem = this.TargetItem;
				return num2.GetValueOrDefault() == targetItem & num2 != null;
			});
			if (num < 0)
			{
				return 0;
			}
			return num;
		}

		// Token: 0x0603A33B RID: 238395 RVA: 0x00EBDFF0 File Offset: 0x00EBC1F0
		private int GetKeepSelectItemIndex(IBaseItemData[] itemList)
		{
			int num = Array.FindIndex<IBaseItemData>(itemList, delegate(IBaseItemData data)
			{
				SynthesisFormula? synthesisFormula;
				int? num2 = (ConfigBase<ComposeConfig>.Instance.GetSynthesisFormulaById(data.ConfigId) != null) ? new int?(synthesisFormula.GetValueOrDefault().ItemId) : null;
				int selectedItemId = this.SelectedItemId;
				return num2.GetValueOrDefault() == selectedItemId & num2 != null;
			});
			if (num < 0)
			{
				return 0;
			}
			return num;
		}

		// Token: 0x0603A33C RID: 238396 RVA: 0x00EBE018 File Offset: 0x00EBC218
		private void OnComposeItemClick(MediumItemGridExtendCallback callbackParameter)
		{
			IBaseItemData baseItemData = callbackParameter.Data as IBaseItemData;
			if (baseItemData == this.ItemData)
			{
				return;
			}
			this.IsRefreshByClick = true;
			int gridIndex = 0;
			this.ComposeItemScrollView.DeselectCurrentGridProxy(false);
			switch (baseItemData.MainType)
			{
			case EComposeListType.ReagentProduction:
				this.SelectedItemId = ConfigBase<ComposeConfig>.Instance.GetSynthesisFormulaById(baseItemData.ConfigId).Value.ItemId;
				gridIndex = this.ReagentProductionDataList.IndexOf((IReagentProductionData)baseItemData);
				break;
			case EComposeListType.Structure:
				this.SelectedItemId = ConfigBase<ComposeConfig>.Instance.GetSynthesisFormulaById(baseItemData.ConfigId).Value.ItemId;
				gridIndex = this.StructureDataList.IndexOf((IStructureData)baseItemData);
				break;
			case EComposeListType.Purification:
				this.SelectedItemId = ConfigBase<ComposeConfig>.Instance.GetSynthesisFormulaById(baseItemData.ConfigId).Value.ItemId;
				gridIndex = this.PurificationDataList.IndexOf((IPurificationData)baseItemData);
				break;
			case EComposeListType.Exchange:
				this.SelectedItemId = baseItemData.ConfigId;
				gridIndex = this.ExchangeDataList.IndexOf((IExchangeData)baseItemData);
				break;
			case EComposeListType.Collect:
				this.SelectedItemId = ConfigBase<ComposeConfig>.Instance.GetSynthesisFormulaById(baseItemData.ConfigId).Value.ItemId;
				gridIndex = this.CollectDataList.IndexOf((ICollectData)baseItemData);
				break;
			}
			if (!this.ComposeItemScrollView.IsGridDisplaying(gridIndex))
			{
				this.IsRefreshByClick = false;
				return;
			}
			if (baseItemData.IsNew)
			{
				ModelBase<NewFlagModel>.Instance.RemoveNewFlag(ELocalStoragePlayerKey.ComposeLevelKey, baseItemData.ConfigId);
				baseItemData.IsNew = false;
			}
			this.ComposeItemScrollView.SelectGridProxy(gridIndex, false);
			this.ComposeItemScrollView.RefreshGridProxy(gridIndex);
			this.RefreshTips(baseItemData, true);
		}

		// Token: 0x0603A33D RID: 238397 RVA: 0x00EBE1E1 File Offset: 0x00EBC3E1
		private void BackClick()
		{
			base.CloseMe(null);
		}

		// Token: 0x0603A33E RID: 238398 RVA: 0x00EBE1EA File Offset: 0x00EBC3EA
		private CommonTabItem TabItemProxyCreate([Nullable(2)] UUIItem uiItem, int? index)
		{
			return new CommonTabItem();
		}

		// Token: 0x0603A33F RID: 238399 RVA: 0x00EBE1F4 File Offset: 0x00EBC3F4
		private void ToggleCallBack(int index)
		{
			this.LastClickTime = Singleton<Time>.Instance.Now;
			EComposeListType ecomposeListType = this.TabList[index];
			if (ModelBase<ComposeModel>.Instance.CurrentComposeListType == ecomposeListType)
			{
				return;
			}
			ModelBase<ComposeModel>.Instance.CurrentComposeListType = ecomposeListType;
			this.SwitchComposeLevelShow();
			this.SwitchComposeItemScroll();
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer != null)
			{
				levelSequencePlayer.PlayLevelSequenceByName("Switch", true, null, false);
			}
			if (ecomposeListType != EComposeListType.Exchange)
			{
				Singleton<EventSystem>.Instance.Emit<string>(EEventName.FinishGuideStepByEvent, "ComposeCarryOnView");
			}
		}

		// Token: 0x0603A340 RID: 238400 RVA: 0x00EBE280 File Offset: 0x00EBC480
		private void SwitchComposeItemScroll()
		{
			this.FilterComponent.SetActive(false);
			this.SortComponent.SetActive(false);
			switch (ModelBase<ComposeModel>.Instance.CurrentComposeListType)
			{
			case EComposeListType.ReagentProduction:
			{
				this.FilterComponent.UpdateData(EFilterSortGroupId.ReagentList, this.GetItemList(), Array.Empty<object>());
				int uniqueIdByGroupId = this.FilterComponent.GetUniqueIdByGroupId(EFilterSortGroupId.ReagentList);
				this.SortComponent.SetFilterUniqueId(uniqueIdByGroupId);
				this.SortComponent.SetResultDataDirty();
				this.SortComponent.UpdateData(EFilterSortGroupId.ReagentList, this.GetItemList(), Array.Empty<object>());
				int uniqueIdByGroupId2 = this.SortComponent.GetUniqueIdByGroupId(EFilterSortGroupId.ReagentList);
				this.FilterComponent.SetSortUniqueId(uniqueIdByGroupId2);
				return;
			}
			case EComposeListType.Structure:
			{
				this.FilterComponent.UpdateData(EFilterSortGroupId.StructureList, this.GetItemList(), Array.Empty<object>());
				int uniqueIdByGroupId3 = this.FilterComponent.GetUniqueIdByGroupId(EFilterSortGroupId.StructureList);
				this.SortComponent.SetFilterUniqueId(uniqueIdByGroupId3);
				this.SortComponent.SetResultDataDirty();
				this.SortComponent.UpdateData(EFilterSortGroupId.StructureList, this.GetItemList(), Array.Empty<object>());
				int uniqueIdByGroupId4 = this.SortComponent.GetUniqueIdByGroupId(EFilterSortGroupId.StructureList);
				this.FilterComponent.SetSortUniqueId(uniqueIdByGroupId4);
				return;
			}
			case EComposeListType.Purification:
				this.SortComponent.SetResultDataDirty();
				this.SortComponent.UpdateData(EFilterSortGroupId.PurificationList, this.GetItemList(), Array.Empty<object>());
				return;
			case EComposeListType.Exchange:
				this.SortComponent.SetResultDataDirty();
				this.SortComponent.UpdateData(EFilterSortGroupId.ComposeExchange, this.GetItemList(), Array.Empty<object>());
				return;
			case EComposeListType.Collect:
				this.OnFilterSortRefresh(this.GetItemList(), false, EFilterSortType.Filter);
				return;
			default:
				return;
			}
		}

		// Token: 0x0603A341 RID: 238401 RVA: 0x00EBE408 File Offset: 0x00EBC608
		public void RefreshTips(IBaseItemData data, bool refreshDrag = true)
		{
			if (this.ItemData != null && this.ItemData.ConfigId != data.ConfigId)
			{
				ModelBase<ComposeModel>.Instance.CurrentComposeRoleId = 0;
			}
			this.ItemData = data;
			this.BottomTextNeedShow = false;
			switch (this.ItemData.MainType)
			{
			case EComposeListType.ReagentProduction:
				this.RefreshReagentProduction();
				break;
			case EComposeListType.Structure:
				this.RefreshStructure();
				break;
			case EComposeListType.Purification:
				this.RefreshPurification(refreshDrag);
				break;
			case EComposeListType.Exchange:
				this.RefreshExchange(refreshDrag);
				break;
			case EComposeListType.Collect:
				this.RefreshCollect(refreshDrag);
				break;
			}
			this.CheckCanInteractConfirm();
			this.RefreshLimitTime();
			this.RefreshLimitCount();
			this.RefreshBottomMiddleTips();
			this.RefreshBottomText();
			this.IsRefreshByClick = false;
		}

		// Token: 0x0603A342 RID: 238402 RVA: 0x00EBE4C4 File Offset: 0x00EBC6C4
		private void CheckCanInteractConfirm()
		{
			ComposeModel instance = ModelBase<ComposeModel>.Instance;
			bool flag = true;
			bool flag2 = true;
			bool isCoinEnough = true;
			bool flag3 = true;
			if (this.ItemData.MainType != EComposeListType.Exchange)
			{
				flag = instance.CheckComposeMaterialEnough(this.ItemData.ConfigId);
				flag2 = instance.CheckUnlock(this.ItemData);
				isCoinEnough = instance.CheckCoinEnough(this.ItemData.ConfigId);
				flag3 = instance.CheckLimitCount(this.ItemData);
			}
			base.GetText(38).SetText(this.GetDisableText(flag2, flag, isCoinEnough, flag3), true);
			base.GetItem(25).SetUIActive(!flag2 || !flag || !flag3);
			base.GetButton(24).RootUIComp.Get().SetUIActive(flag2 && flag && flag3);
		}

		// Token: 0x0603A343 RID: 238403 RVA: 0x00EBE57D File Offset: 0x00EBC77D
		public void RefreshReagentProduction()
		{
			this.RefreshTopB();
			this.RefreshProficiency(true);
			this.RefreshMaterial();
		}

		// Token: 0x0603A344 RID: 238404 RVA: 0x00EBE592 File Offset: 0x00EBC792
		public void RefreshStructure()
		{
			this.RefreshTopB();
			this.RefreshProficiency(false);
			this.RefreshMaterial();
		}

		// Token: 0x0603A345 RID: 238405 RVA: 0x00EBE5A7 File Offset: 0x00EBC7A7
		public void RefreshPurification(bool refreshDrag = true)
		{
			this.RefreshTopA(refreshDrag);
			if (this.ItemData.IsUnlock <= 0)
			{
				this.NumberSelect.Refresh(0);
			}
			this.RefreshMaterial();
			this.RefreshDragAbout();
		}

		// Token: 0x0603A346 RID: 238406 RVA: 0x00EBE5D6 File Offset: 0x00EBC7D6
		public void RefreshCollect(bool refreshDrag = true)
		{
			this.RefreshTopA(refreshDrag);
			if (this.ItemData.IsUnlock <= 0)
			{
				this.NumberSelect.Refresh(0);
			}
			this.RefreshMaterial();
			this.RefreshDragAbout();
		}

		// Token: 0x0603A347 RID: 238407 RVA: 0x00EBE605 File Offset: 0x00EBC805
		public void RefreshExchange(bool refreshDrag = true)
		{
			this.RefreshTopA(refreshDrag);
			if (this.ItemData.IsUnlock <= 0)
			{
				this.NumberSelect.Refresh(0);
			}
			this.RefreshExchangeMaterial();
			this.RefreshDragAbout();
		}

		// Token: 0x0603A348 RID: 238408 RVA: 0x00EBE634 File Offset: 0x00EBC834
		private void RefreshTopA(bool refreshDrag = true)
		{
			UUIItem item = base.GetItem(5);
			if (item != null)
			{
				item.SetUIActive(true);
			}
			UUIItem item2 = base.GetItem(9);
			if (item2 != null)
			{
				item2.SetUIActive(false);
			}
			SynthesisFormula? synthesisFormula;
			int itemId = (this.ItemData.MainType == EComposeListType.Exchange) ? this.ItemData.ConfigId : ((ConfigBase<ComposeConfig>.Instance.GetSynthesisFormulaById(this.ItemData.ConfigId) != null) ? synthesisFormula.GetValueOrDefault().ItemId : 0);
			string itemName = ConfigBase<CSharpScript.Game.Module.Item.ItemConfig>.Instance.GetItemName(itemId);
			base.GetText(6).SetText(itemName, true);
			if (!refreshDrag)
			{
				return;
			}
			List<IBaseItemData> sameGroupItem = ModelBase<ComposeModel>.Instance.GetSameGroupItem(this.ItemData);
			int attachTo = 0;
			for (int i = 0; i < sameGroupItem.Count; i++)
			{
				if (this.ItemData == sameGroupItem[i])
				{
					attachTo = i;
					break;
				}
			}
			NoCircleAttachView<IBaseItemData, ComposeCircleItem> noCircleExhibitionView = this.NoCircleExhibitionView;
			if (noCircleExhibitionView != null)
			{
				noCircleExhibitionView.ReloadView(sameGroupItem.Count, sameGroupItem.ToArray(), attachTo);
			}
			this.DragList = sameGroupItem;
		}

		// Token: 0x0603A349 RID: 238409 RVA: 0x00EBE738 File Offset: 0x00EBC938
		private void RefreshTopB()
		{
			UUIItem item = base.GetItem(9);
			if (item != null)
			{
				item.SetUIActive(true);
			}
			UUIItem item2 = base.GetItem(5);
			if (item2 != null)
			{
				item2.SetUIActive(false);
			}
			SynthesisFormula? synthesisFormulaById = ConfigBase<ComposeConfig>.Instance.GetSynthesisFormulaById(this.ItemData.ConfigId);
			string itemName = ConfigBase<CSharpScript.Game.Module.Item.ItemConfig>.Instance.GetItemName(synthesisFormulaById.Value.ItemId);
			base.GetText(13).SetText(itemName, true);
			int commonItemCount = ModelBase<InventoryModel>.Instance.GetCommonItemCount(synthesisFormulaById.Value.ItemId, 0);
			Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(12), "ItemTipsHaveNum", new <>z__ReadOnlySingleElementList<object>(commonItemCount));
			ItemInfo? config = ConfigBase<CSharpScript.Game.Module.Item.ItemConfig>.Instance.GetConfig(synthesisFormulaById.Value.ItemId);
			if (config == null)
			{
				return;
			}
			base.SetTextureByPath(config.Value.Icon, base.GetTexture(11), null, null);
			string itemAttributeDesc = ConfigBase<CSharpScript.Game.Module.Item.ItemConfig>.Instance.GetItemAttributeDesc(synthesisFormulaById.Value.ItemId);
			UUIText text = base.GetText(15);
			if (text != null)
			{
				text.SetText(itemAttributeDesc ?? "", true);
			}
			QualityInfo? qualityConfig = ConfigBase<CSharpScript.Game.Module.Item.ItemConfig>.Instance.GetQualityConfig(config.Value.QualityId);
			if (qualityConfig == null)
			{
				return;
			}
			this.SetSpriteByPath(qualityConfig.Value.ComposeQualityBg, base.GetSprite(10), false, null, null);
		}

		// Token: 0x0603A34A RID: 238410 RVA: 0x00EBE8C4 File Offset: 0x00EBCAC4
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
						ConfigBase<CSharpScript.Game.Module.Item.ItemConfig>.Instance.GetItemName(ControllerBase<ComposeController>.Instance.ComposeCoinId)
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
				string refreshLimitTime = ModelBase<ComposeModel>.Instance.GetRefreshLimitTime();
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

		// Token: 0x0603A34B RID: 238411 RVA: 0x00EBE970 File Offset: 0x00EBCB70
		private void RefreshLimitCount()
		{
			IBaseItemData itemData = this.ItemData;
			if (itemData.TotalMakeCountInLimitTime <= 0)
			{
				this.NumberSelect.ResetLimitMaxValue();
				base.GetText(21).SetUIActive(false);
				return;
			}
			this.BottomTextNeedShow = true;
			int num = itemData.TotalMakeCountInLimitTime - itemData.MadeCountInLimitTime;
			this.NumberSelect.SetLimitMaxValue(Math.Max(1, num));
			base.GetText(21).SetUIActive(true);
			string text = num.ToString();
			if (num == 0)
			{
				text = StringUtils.Format("<color=#c25757>{0}</color>", new string[]
				{
					num.ToString()
				});
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(21), "MakeLimit", new <>z__ReadOnlyArray<object>(new object[]
			{
				text,
				itemData.TotalMakeCountInLimitTime
			}));
		}

		// Token: 0x0603A34C RID: 238412 RVA: 0x00EBEA38 File Offset: 0x00EBCC38
		private bool ShouldShowBottomMiddleTips()
		{
			if (this.TipsItemData == null || this.TipsItemData.Count <= 0)
			{
				return false;
			}
			if (this.ItemData.MainType == EComposeListType.Exchange)
			{
				return this.ItemData.ConfigId == this.TipsItemData.ItemId;
			}
			SynthesisFormula? synthesisFormula;
			int? num = (ConfigBase<ComposeConfig>.Instance.GetSynthesisFormulaById(this.ItemData.ConfigId) != null) ? new int?(synthesisFormula.GetValueOrDefault().ItemId) : null;
			int itemId = this.TipsItemData.ItemId;
			return num.GetValueOrDefault() == itemId & num != null;
		}

		// Token: 0x0603A34D RID: 238413 RVA: 0x00EBEAE4 File Offset: 0x00EBCCE4
		private void RefreshBottomMiddleTips()
		{
			if (this.ShouldShowBottomMiddleTips())
			{
				this.BottomTextNeedShow = true;
				UUIText text = base.GetText(22);
				if (text != null)
				{
					text.SetUIActive(true);
				}
				int commonItemCount = ModelBase<InventoryModel>.Instance.GetCommonItemCount(this.TipsItemData.ItemId, 0);
				int count = this.TipsItemData.Count;
				string text2;
				if (commonItemCount < count)
				{
					text2 = StringUtils.Format("<color=#c25757>{0}</color>", new string[]
					{
						commonItemCount.ToString()
					});
				}
				else
				{
					text2 = StringUtils.Format("<color=#36cd33>{0}</color>", new string[]
					{
						commonItemCount.ToString()
					});
				}
				UUISprite sprite = base.GetSprite(42);
				if (sprite != null)
				{
					sprite.SetUIActive(commonItemCount >= count);
				}
				string textStringId;
				if (this.SkipSourceView != null)
				{
					textStringId = ComposeCarryOnView.SkipViewPrefixMap.GetValueOrDefault(this.SkipSourceView.Value, "ComposeNeedTips");
				}
				else
				{
					textStringId = "ComposeNeedTips";
				}
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(22), textStringId, new <>z__ReadOnlyArray<object>(new object[]
				{
					text2,
					count.ToString()
				}));
			}
			else
			{
				UUIText text3 = base.GetText(22);
				if (text3 != null)
				{
					text3.SetUIActive(false);
				}
			}
			UUIText text4 = base.GetText(43);
			if (text4 == null)
			{
				return;
			}
			text4.SetUIActive(this.ItemData.MainType == EComposeListType.Exchange && this.CurrentSelectExchangeMaterialItem == 0);
		}

		// Token: 0x0603A34E RID: 238414 RVA: 0x00EBEC36 File Offset: 0x00EBCE36
		private void RefreshBottomText()
		{
			base.GetItem(37).SetUIActive(this.BottomTextNeedShow);
		}

		// Token: 0x0603A34F RID: 238415 RVA: 0x00EBEC4C File Offset: 0x00EBCE4C
		[NullableContext(2)]
		private void MoveDragGrid(IBaseItemData data, EComposeListType type, bool? isFormClick = false)
		{
			if (data == null || this.ItemData == data || this.IsRefreshByClick || ModelBase<ComposeModel>.Instance.CurrentComposeListType != type)
			{
				return;
			}
			ModelBase<ComposeModel>.Instance.CurrentComposeRoleId = 0;
			this.ItemData = data;
			this.BottomTextNeedShow = false;
			if (this.ItemData.MainType == EComposeListType.Purification)
			{
				SynthesisFormula? synthesisFormulaById = ConfigBase<ComposeConfig>.Instance.GetSynthesisFormulaById(data.ConfigId);
				this.SelectedItemId = ((synthesisFormulaById != null) ? synthesisFormulaById.GetValueOrDefault().ItemId : 0);
				this.RefreshPurification(false);
			}
			if (this.ItemData.MainType == EComposeListType.Collect)
			{
				SynthesisFormula? synthesisFormulaById = ConfigBase<ComposeConfig>.Instance.GetSynthesisFormulaById(data.ConfigId);
				this.SelectedItemId = ((synthesisFormulaById != null) ? synthesisFormulaById.GetValueOrDefault().ItemId : 0);
				this.RefreshCollect(false);
			}
			if (this.ItemData.MainType == EComposeListType.Exchange)
			{
				this.SelectedItemId = data.ConfigId;
				this.RefreshExchange(false);
				this.RefreshExchangeView();
			}
			this.CheckCanInteractConfirm();
			this.RefreshLimitTime();
			this.RefreshLimitCount();
			this.RefreshBottomMiddleTips();
			this.RefreshBottomText();
			this.SelectComposeItem();
			if (isFormClick.GetValueOrDefault())
			{
				this.NoCircleExhibitionViewAttachTo();
			}
		}

		// Token: 0x0603A350 RID: 238416 RVA: 0x00EBED7C File Offset: 0x00EBCF7C
		private void RefreshDragAbout()
		{
			UUIItem item = base.GetItem(39);
			if (item != null)
			{
				item.SetUIActive(true);
			}
			UUIItem item2 = base.GetItem(40);
			if (item2 != null)
			{
				item2.SetUIActive(true);
			}
			IBaseItemData itemData = this.ItemData;
			int? num = (itemData != null) ? new int?(itemData.ConfigId) : null;
			int configId = this.DragList[0].ConfigId;
			if (num.GetValueOrDefault() == configId & num != null)
			{
				UUIItem item3 = base.GetItem(39);
				if (item3 != null)
				{
					item3.SetUIActive(false);
				}
			}
			IBaseItemData itemData2 = this.ItemData;
			num = ((itemData2 != null) ? new int?(itemData2.ConfigId) : null);
			configId = this.DragList[this.DragList.Count - 1].ConfigId;
			if (num.GetValueOrDefault() == configId & num != null)
			{
				UUIItem item4 = base.GetItem(40);
				if (item4 == null)
				{
					return;
				}
				item4.SetUIActive(false);
			}
		}

		// Token: 0x0603A351 RID: 238417 RVA: 0x00EBEE70 File Offset: 0x00EBD070
		private void NoCircleExhibitionViewAttachTo()
		{
			int showItemIndex = 0;
			for (int i = 0; i < this.DragList.Count; i++)
			{
				if (this.ItemData == this.DragList[i])
				{
					showItemIndex = i;
					break;
				}
			}
			NoCircleAttachView<IBaseItemData, ComposeCircleItem> noCircleExhibitionView = this.NoCircleExhibitionView;
			if (noCircleExhibitionView == null)
			{
				return;
			}
			noCircleExhibitionView.AttachToIndex(showItemIndex, false);
		}

		// Token: 0x0603A352 RID: 238418 RVA: 0x00EBEEC0 File Offset: 0x00EBD0C0
		private void SelectComposeItem()
		{
			int gridIndex = 0;
			switch (ModelBase<ComposeModel>.Instance.CurrentComposeListType)
			{
			case EComposeListType.ReagentProduction:
				gridIndex = this.GetScrollItemIndex(this.ReagentProductionDataList.Cast<IBaseItemData>().ToArray<IBaseItemData>());
				break;
			case EComposeListType.Structure:
				gridIndex = this.GetScrollItemIndex(this.StructureDataList.Cast<IBaseItemData>().ToArray<IBaseItemData>());
				break;
			case EComposeListType.Purification:
				gridIndex = this.GetScrollItemIndex(this.PurificationDataList.Cast<IBaseItemData>().ToArray<IBaseItemData>());
				break;
			case EComposeListType.Exchange:
				gridIndex = this.GetScrollItemIndex(this.ExchangeDataList.Cast<IBaseItemData>().ToArray<IBaseItemData>());
				break;
			case EComposeListType.Collect:
				gridIndex = this.GetScrollItemIndex(this.CollectDataList.Cast<IBaseItemData>().ToArray<IBaseItemData>());
				break;
			}
			LoopScrollView<ComposeMediumItemGrid, IBaseItemData> composeItemScrollView = this.ComposeItemScrollView;
			if (composeItemScrollView != null)
			{
				composeItemScrollView.ScrollToGridIndex(gridIndex, true);
			}
			LoopScrollView<ComposeMediumItemGrid, IBaseItemData> composeItemScrollView2 = this.ComposeItemScrollView;
			if (composeItemScrollView2 != null)
			{
				composeItemScrollView2.SelectGridProxy(gridIndex, false);
			}
			UUIExtendToggle itemGridExtendToggle = this.ComposeItemScrollView.UnsafeGetGridProxy(gridIndex, false).GetItemGridExtendToggle();
			ControllerBase<UiNavigationNewController>.Instance.SetNavigationFocusForViewSameGroup(itemGridExtendToggle.RootUIComp);
		}

		// Token: 0x0603A353 RID: 238419 RVA: 0x00EBEFC4 File Offset: 0x00EBD1C4
		private int GetScrollItemIndex(IBaseItemData[] dataList)
		{
			int num = Array.IndexOf<IBaseItemData>(dataList, this.ItemData);
			if (num < 0)
			{
				for (int i = 0; i < dataList.Length; i++)
				{
					if (dataList[i].ConfigId == this.ItemData.ConfigId)
					{
						return i;
					}
				}
			}
			return num;
		}

		// Token: 0x0603A354 RID: 238420 RVA: 0x00EBF008 File Offset: 0x00EBD208
		private void OpenLeftPopView()
		{
			UUIItem item = base.GetItem(26);
			if (item != null)
			{
				item.SetUIActive(true);
			}
			TabComponentWithCaptionItem<CommonTabItem> tabComponent = this.TabComponent;
			if (tabComponent != null)
			{
				tabComponent.SetCloseBtnShowState(false);
			}
			GenericScrollViewNew<ManufactureMaterialItem, ISingleItemInfo> materialScrollView = this.MaterialScrollView;
			if (materialScrollView != null)
			{
				ManufactureMaterialItem scrollItemByIndex = materialScrollView.GetScrollItemByIndex(0);
				if (scrollItemByIndex != null)
				{
					scrollItemByIndex.SetComposeChangeAble(new bool?(false));
				}
			}
			this.RefreshExchangeView();
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer != null)
			{
				levelSequencePlayer.PlayLevelSequenceByName("PopupShow", true, null, false);
			}
			Singleton<EventSystem>.Instance.Emit<string>(EEventName.FinishGuideStepByEvent, "ComposeCarryOnView");
		}

		// Token: 0x0603A355 RID: 238421 RVA: 0x00EBF09C File Offset: 0x00EBD29C
		private void RefreshExchangeView()
		{
			if (!base.GetItem(26).bIsUIActive)
			{
				return;
			}
			List<ISingleItemInfo> list = (from item in ModelBase<ComposeModel>.Instance.GetExchangeMaterialListByGroupId((this.ItemData as IExchangeData).ExchangeGroupId)
			where item.Proto_ItemId != this.ItemData.ConfigId
			select item).ToList<ISingleItemInfo>();
			list.Sort(delegate(ISingleItemInfo a, ISingleItemInfo b)
			{
				if (a.Proto_ItemNum != b.Proto_ItemNum)
				{
					return b.Proto_ItemNum - a.Proto_ItemNum;
				}
				return a.Proto_ItemId - b.Proto_ItemNum;
			});
			LoopScrollView<ComposeExchangeItem, ISingleItemInfo> exchangeScrollView = this.ExchangeScrollView;
			if (exchangeScrollView == null)
			{
				return;
			}
			exchangeScrollView.RefreshByData(list, false, null, false);
		}

		// Token: 0x0603A356 RID: 238422 RVA: 0x00EBF123 File Offset: 0x00EBD323
		private void OnSecondTimerRefresh(float _)
		{
			this.RefreshItemLimitTime();
			if (this.CheckIsLimitCountRefresh())
			{
				this.<OnSecondTimerRefresh>g__Temp|98_0().Forget();
				return;
			}
			if (this.CheckHasItemTimeOut())
			{
				this.<OnSecondTimerRefresh>g__Temp|98_1().Forget();
			}
		}

		// Token: 0x0603A357 RID: 238423 RVA: 0x00EBF154 File Offset: 0x00EBD354
		private bool CheckHasItemTimeOut()
		{
			List<IBaseItemData> itemList = this.GetItemList();
			if (itemList == null)
			{
				return false;
			}
			foreach (IBaseItemData baseItemData in itemList)
			{
				if (baseItemData.ExistEndTime > 0.0 && !Singleton<TimeUtil>.Instance.IsInTimeSpan(baseItemData.ExistStartTime, baseItemData.ExistEndTime))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0603A358 RID: 238424 RVA: 0x00EBF1D8 File Offset: 0x00EBD3D8
		private void OnCookResponse()
		{
			this.TargetItem = this.SelectedItemId;
			this.SwitchComposeItemScroll();
			this.RefreshExchangeView();
			this.TargetItem = 0;
		}

		// Token: 0x0603A359 RID: 238425 RVA: 0x00EBF1F9 File Offset: 0x00EBD3F9
		private bool CheckIsLimitCountRefresh()
		{
			return ModelBase<ComposeModel>.Instance.GetRefreshLimitTimeValue() <= 0.0;
		}

		// Token: 0x0603A35A RID: 238426 RVA: 0x00EBF213 File Offset: 0x00EBD413
		private void RefreshItemLimitTime()
		{
			if (this.ItemData != null && this.ItemData.ExistEndTime > 0.0)
			{
				this.RefreshLimitTime();
				this.RefreshBottomText();
			}
		}

		// Token: 0x0603A35B RID: 238427 RVA: 0x00EBF240 File Offset: 0x00EBD440
		private void OnCloseView(EUiViewName viewName, int viewId)
		{
			if (viewName != EUiViewName.CompositeRewardView)
			{
				return;
			}
			IUiPopFrameInterface childPopView = this.ChildPopView;
			if (childPopView != null)
			{
				childPopView.PopItem.SetActive(true);
			}
			IUiPopFrameInterface childPopView2 = this.ChildPopView;
			if (childPopView2 != null)
			{
				childPopView2.PlayLevelSequenceByName("Start", false);
			}
			Singleton<EventSystem>.Instance.Emit<bool>(EEventName.HangPlotViewHud, false);
		}

		// Token: 0x0603A35C RID: 238428 RVA: 0x00EBF29C File Offset: 0x00EBD49C
		private void ComposeSwitchType(EComposeListType type, int itemId)
		{
			if (ModelBase<ComposeModel>.Instance.CurrentComposeListType == type)
			{
				return;
			}
			ModelBase<ComposeModel>.Instance.CurrentComposeListType = type;
			this.TargetItem = itemId;
			this.SwitchComposeLevelShow();
			this.SwitchComposeItemScroll();
			int index = this.TabList.IndexOf(type);
			TabComponentWithCaptionItem<CommonTabItem> tabComponent = this.TabComponent;
			if (tabComponent != null)
			{
				tabComponent.SelectToggleByIndex(index, true);
			}
			this.SelectedItemId = this.TargetItem;
			this.TargetItem = 0;
			this.OnClickLeftPopItemCloseBtn();
		}

		// Token: 0x0603A35D RID: 238429 RVA: 0x00EBF310 File Offset: 0x00EBD510
		private CommonTabData GetCommonData(int index)
		{
			return new CommonTabData(ConfigBase<UiResourceConfig>.Instance.GetResourcePath(ComposeDefine.ComposeTypeSprite[this.TabList[index]]), new CommonTabTitleData(ComposeDefine.ComposeTypeName[this.TabList[index]], Array.Empty<object>()), null);
		}

		// Token: 0x0603A35E RID: 238430 RVA: 0x00EBF364 File Offset: 0x00EBD564
		private ComposeCircleItem CreateCircleItem(AActor actor, int index, int showNum)
		{
			ComposeCircleItem composeCircleItem = new ComposeCircleItem();
			composeCircleItem.CreateByActorAsync(actor, null, false);
			composeCircleItem.ButtonFunction = new Action<IBaseItemData, EComposeListType, bool?>(this.MoveDragGrid);
			composeCircleItem.CheckToggleCanClick = new Func<bool>(this.CheckToggleCanClick);
			composeCircleItem.ItemCurve = this.ItemCurve;
			return composeCircleItem;
		}

		// Token: 0x0603A35F RID: 238431 RVA: 0x00EBF3B0 File Offset: 0x00EBD5B0
		private bool CheckToggleCanClick()
		{
			return !this.NoCircleExhibitionView.MovingState();
		}

		// Token: 0x0603A360 RID: 238432 RVA: 0x00EBF3C2 File Offset: 0x00EBD5C2
		private void OnClickComposeLevelBtn()
		{
			ModelBase<ComposeModel>.Instance.CurrentComposeViewType = EComposeViewType.ComposeLevelType;
			Singleton<UiManager>.Instance.OpenView(EUiViewName.ComposeLevelView, null, null);
		}

		// Token: 0x0603A361 RID: 238433 RVA: 0x00EBF3E0 File Offset: 0x00EBD5E0
		private void OnClickConfirmBtn()
		{
			if (!base.GetButton(24).IsSelfInteractive)
			{
				ControllerBase<ComposeController>.Instance.PlayCompositeFailDisplay(delegate
				{
					ControllerBase<ComposeController>.Instance.PlayCompositeLoopDisplay();
				});
				return;
			}
			this.IsRefreshByClick = true;
			if (this.ItemData.MainType != EComposeListType.Exchange)
			{
				this.<OnClickConfirmBtn>g__SendManufactureAsync|109_1().Forget();
				return;
			}
			if (this.CurrentSelectExchangeMaterialItem == 0)
			{
				this.IsRefreshByClick = false;
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("ComposeExchangeNotFindItemTips", Array.Empty<object>());
				return;
			}
			this.<OnClickConfirmBtn>g__SendExchangeAsync|109_0().Forget();
		}

		// Token: 0x0603A362 RID: 238434 RVA: 0x00EBF478 File Offset: 0x00EBD678
		private void OnClickLeftPopItemCloseBtn()
		{
			UUIItem item = base.GetItem(26);
			if (item != null)
			{
				item.SetUIActive(false);
			}
			TabComponentWithCaptionItem<CommonTabItem> tabComponent = this.TabComponent;
			if (tabComponent != null)
			{
				tabComponent.SetCloseBtnShowState(true);
			}
			if (this.CurrentSelectExchangeMaterialItem != 0)
			{
				GenericScrollViewNew<ManufactureMaterialItem, ISingleItemInfo> materialScrollView = this.MaterialScrollView;
				if (materialScrollView != null)
				{
					ManufactureMaterialItem scrollItemByIndex = materialScrollView.GetScrollItemByIndex(0);
					if (scrollItemByIndex != null)
					{
						scrollItemByIndex.SetComposeChangeAble(new bool?(true));
					}
				}
			}
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer == null)
			{
				return;
			}
			levelSequencePlayer.PlayLevelSequenceByName("PopupHide", true, null, false);
		}

		// Token: 0x0603A36C RID: 238444 RVA: 0x00EBF6EC File Offset: 0x00EBD8EC
		[CompilerGenerated]
		private UniTask <OnSecondTimerRefresh>g__Temp|98_0()
		{
			ComposeCarryOnView.<<OnSecondTimerRefresh>g__Temp|98_0>d <<OnSecondTimerRefresh>g__Temp|98_0>d;
			<<OnSecondTimerRefresh>g__Temp|98_0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<<OnSecondTimerRefresh>g__Temp|98_0>d.<>4__this = this;
			<<OnSecondTimerRefresh>g__Temp|98_0>d.<>1__state = -1;
			<<OnSecondTimerRefresh>g__Temp|98_0>d.<>t__builder.Start<ComposeCarryOnView.<<OnSecondTimerRefresh>g__Temp|98_0>d>(ref <<OnSecondTimerRefresh>g__Temp|98_0>d);
			return <<OnSecondTimerRefresh>g__Temp|98_0>d.<>t__builder.Task;
		}

		// Token: 0x0603A36D RID: 238445 RVA: 0x00EBF730 File Offset: 0x00EBD930
		[CompilerGenerated]
		private UniTask <OnSecondTimerRefresh>g__Temp|98_1()
		{
			ComposeCarryOnView.<<OnSecondTimerRefresh>g__Temp|98_1>d <<OnSecondTimerRefresh>g__Temp|98_1>d;
			<<OnSecondTimerRefresh>g__Temp|98_1>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<<OnSecondTimerRefresh>g__Temp|98_1>d.<>4__this = this;
			<<OnSecondTimerRefresh>g__Temp|98_1>d.<>1__state = -1;
			<<OnSecondTimerRefresh>g__Temp|98_1>d.<>t__builder.Start<ComposeCarryOnView.<<OnSecondTimerRefresh>g__Temp|98_1>d>(ref <<OnSecondTimerRefresh>g__Temp|98_1>d);
			return <<OnSecondTimerRefresh>g__Temp|98_1>d.<>t__builder.Task;
		}

		// Token: 0x0603A36E RID: 238446 RVA: 0x00EBF774 File Offset: 0x00EBD974
		[CompilerGenerated]
		private UniTask <OnClickConfirmBtn>g__SendExchangeAsync|109_0()
		{
			ComposeCarryOnView.<<OnClickConfirmBtn>g__SendExchangeAsync|109_0>d <<OnClickConfirmBtn>g__SendExchangeAsync|109_0>d;
			<<OnClickConfirmBtn>g__SendExchangeAsync|109_0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<<OnClickConfirmBtn>g__SendExchangeAsync|109_0>d.<>4__this = this;
			<<OnClickConfirmBtn>g__SendExchangeAsync|109_0>d.<>1__state = -1;
			<<OnClickConfirmBtn>g__SendExchangeAsync|109_0>d.<>t__builder.Start<ComposeCarryOnView.<<OnClickConfirmBtn>g__SendExchangeAsync|109_0>d>(ref <<OnClickConfirmBtn>g__SendExchangeAsync|109_0>d);
			return <<OnClickConfirmBtn>g__SendExchangeAsync|109_0>d.<>t__builder.Task;
		}

		// Token: 0x0603A36F RID: 238447 RVA: 0x00EBF7B8 File Offset: 0x00EBD9B8
		[CompilerGenerated]
		private UniTask <OnClickConfirmBtn>g__SendManufactureAsync|109_1()
		{
			ComposeCarryOnView.<<OnClickConfirmBtn>g__SendManufactureAsync|109_1>d <<OnClickConfirmBtn>g__SendManufactureAsync|109_1>d;
			<<OnClickConfirmBtn>g__SendManufactureAsync|109_1>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<<OnClickConfirmBtn>g__SendManufactureAsync|109_1>d.<>4__this = this;
			<<OnClickConfirmBtn>g__SendManufactureAsync|109_1>d.<>1__state = -1;
			<<OnClickConfirmBtn>g__SendManufactureAsync|109_1>d.<>t__builder.Start<ComposeCarryOnView.<<OnClickConfirmBtn>g__SendManufactureAsync|109_1>d>(ref <<OnClickConfirmBtn>g__SendManufactureAsync|109_1>d);
			return <<OnClickConfirmBtn>g__SendManufactureAsync|109_1>d.<>t__builder.Task;
		}

		// Token: 0x04020FE8 RID: 135144
		private const int GAP = 112;

		// Token: 0x04020FE9 RID: 135145
		private const int TIMERGAP = 1000;

		// Token: 0x04020FEA RID: 135146
		[StaticVariableRuleIgnore]
		private static readonly Dictionary<EUiViewName, string> SkipViewPrefixMap = new Dictionary<EUiViewName, string>
		{
			{
				EUiViewName.RoleBreachView,
				"AutoSynthesis_ResonatorsAscendMaterial_Num"
			},
			{
				EUiViewName.WeaponRootView,
				"AutoSynthesis_WeaponAscendMaterial_Num"
			},
			{
				EUiViewName.RoleSkillTreeInfoView,
				"AutoSynthesis_ForteUpgradeMaterial_Num"
			}
		};

		// Token: 0x04020FEB RID: 135147
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TabComponentWithCaptionItem<CommonTabItem> TabComponent;

		// Token: 0x04020FEC RID: 135148
		[Nullable(2)]
		private NumberSelectComponent NumberSelect;

		// Token: 0x04020FED RID: 135149
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private FilterEntrance<IBaseItemData> FilterComponent;

		// Token: 0x04020FEE RID: 135150
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private SortEntrance<IBaseItemData> SortComponent;

		// Token: 0x04020FEF RID: 135151
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericScrollViewNew<ManufactureMaterialItem, ISingleItemInfo> MaterialScrollView;

		// Token: 0x04020FF0 RID: 135152
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private LoopScrollView<ComposeMediumItemGrid, IBaseItemData> ComposeItemScrollView;

		// Token: 0x04020FF1 RID: 135153
		[Nullable(2)]
		private StarLevelComponent StartLevelComponent;

		// Token: 0x04020FF2 RID: 135154
		[Nullable(2)]
		private MediumItemGrid UnlockMaterialComponent;

		// Token: 0x04020FF3 RID: 135155
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private NoCircleAttachView<IBaseItemData, ComposeCircleItem> NoCircleExhibitionView;

		// Token: 0x04020FF4 RID: 135156
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private LoopScrollView<ComposeExchangeItem, ISingleItemInfo> ExchangeScrollView;

		// Token: 0x04020FF5 RID: 135157
		[Nullable(2)]
		private UUIExtendToggle CurrentSelectExchangeScrollToggle;

		// Token: 0x04020FF6 RID: 135158
		[Nullable(2)]
		private LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x04020FF7 RID: 135159
		[Nullable(2)]
		private IBaseItemData ItemData;

		// Token: 0x04020FF8 RID: 135160
		private bool HasCoin;

		// Token: 0x04020FF9 RID: 135161
		private int SingleNeedCoinCount;

		// Token: 0x04020FFA RID: 135162
		private int Count = 1;

		// Token: 0x04020FFB RID: 135163
		private int SelectedItemId;

		// Token: 0x04020FFC RID: 135164
		private List<IReagentProductionData> ReagentProductionDataList = new List<IReagentProductionData>();

		// Token: 0x04020FFD RID: 135165
		private List<IStructureData> StructureDataList = new List<IStructureData>();

		// Token: 0x04020FFE RID: 135166
		private List<IPurificationData> PurificationDataList = new List<IPurificationData>();

		// Token: 0x04020FFF RID: 135167
		private List<ICollectData> CollectDataList = new List<ICollectData>();

		// Token: 0x04021000 RID: 135168
		private List<IExchangeData> ExchangeDataList = new List<IExchangeData>();

		// Token: 0x04021001 RID: 135169
		private List<EComposeListType> TabList = new List<EComposeListType>();

		// Token: 0x04021002 RID: 135170
		private bool BottomTextNeedShow;

		// Token: 0x04021003 RID: 135171
		[Nullable(2)]
		private UCurveFloat ItemCurve;

		// Token: 0x04021004 RID: 135172
		private bool IsRefreshByClick;

		// Token: 0x04021005 RID: 135173
		private int CurrentSelectExchangeMaterialItem;

		// Token: 0x04021006 RID: 135174
		[Nullable(2)]
		private TimerHandle RefreshTimer;

		// Token: 0x04021007 RID: 135175
		[Nullable(2)]
		private ISelectedData TipsItemData;

		// Token: 0x04021008 RID: 135176
		private int TargetItem;

		// Token: 0x04021009 RID: 135177
		private double LastClickTime;

		// Token: 0x0402100A RID: 135178
		private List<IBaseItemData> DragList = new List<IBaseItemData>();

		// Token: 0x0402100B RID: 135179
		private EUiViewName? SkipSourceView;

		// Token: 0x0200B987 RID: 47495
		[NullableContext(0)]
		public class EComponentDefine
		{
			// Token: 0x040394FB RID: 234747
			public const int CaptionItem = 0;

			// Token: 0x040394FC RID: 234748
			public const int LeftLoopScrollView = 1;

			// Token: 0x040394FD RID: 234749
			public const int LeftScrollItem = 2;

			// Token: 0x040394FE RID: 234750
			public const int SortItem = 3;

			// Token: 0x040394FF RID: 234751
			public const int ComposeLevelBtn = 4;

			// Token: 0x04039500 RID: 234752
			public const int DragRootItem = 5;

			// Token: 0x04039501 RID: 234753
			public const int DragItemNameText = 6;

			// Token: 0x04039502 RID: 234754
			public const int DragComponent = 7;

			// Token: 0x04039503 RID: 234755
			public const int DragItem = 8;

			// Token: 0x04039504 RID: 234756
			public const int ItemDesRootItem = 9;

			// Token: 0x04039505 RID: 234757
			public const int ItemDesQualitySprint = 10;

			// Token: 0x04039506 RID: 234758
			public const int ItemDesTexture = 11;

			// Token: 0x04039507 RID: 234759
			public const int ItemDesNumText = 12;

			// Token: 0x04039508 RID: 234760
			public const int ItemDesNameText = 13;

			// Token: 0x04039509 RID: 234761
			public const int ItemDesSubTitleText = 14;

			// Token: 0x0403950A RID: 234762
			public const int ItemDesMainText = 15;

			// Token: 0x0403950B RID: 234763
			public const int BottomLockItem = 16;

			// Token: 0x0403950C RID: 234764
			public const int BottomScrollView = 17;

			// Token: 0x0403950D RID: 234765
			public const int BottomScrollItem = 18;

			// Token: 0x0403950E RID: 234766
			public const int BottomAddItem = 19;

			// Token: 0x0403950F RID: 234767
			public const int BottomDesText = 20;

			// Token: 0x04039510 RID: 234768
			public const int BottomLeftText = 21;

			// Token: 0x04039511 RID: 234769
			public const int BottomMidText = 22;

			// Token: 0x04039512 RID: 234770
			public const int BottomTimeText = 23;

			// Token: 0x04039513 RID: 234771
			public const int ConfirmBtn = 24;

			// Token: 0x04039514 RID: 234772
			public const int LockItem = 25;

			// Token: 0x04039515 RID: 234773
			public const int LeftPopItem = 26;

			// Token: 0x04039516 RID: 234774
			public const int LeftPopItemCloseBtn = 27;

			// Token: 0x04039517 RID: 234775
			public const int LeftPopItemScrollView = 28;

			// Token: 0x04039518 RID: 234776
			public const int LeftPopItemScrollItem = 29;

			// Token: 0x04039519 RID: 234777
			public const int MakeCountText = 30;

			// Token: 0x0403951A RID: 234778
			public const int CostTxt = 31;

			// Token: 0x0403951B RID: 234779
			public const int CostIconTexture = 32;

			// Token: 0x0403951C RID: 234780
			public const int FilterItem = 33;

			// Token: 0x0403951D RID: 234781
			public const int RedDotItem = 34;

			// Token: 0x0403951E RID: 234782
			public const int ComposeLevelSprite = 35;

			// Token: 0x0403951F RID: 234783
			public const int StarLayout = 36;

			// Token: 0x04039520 RID: 234784
			public const int BottomTextRootItem = 37;

			// Token: 0x04039521 RID: 234785
			public const int TxtActivate = 38;

			// Token: 0x04039522 RID: 234786
			public const int DragLeftItem = 39;

			// Token: 0x04039523 RID: 234787
			public const int DragRightItem = 40;

			// Token: 0x04039524 RID: 234788
			public const int DragContentItem = 41;

			// Token: 0x04039525 RID: 234789
			public const int SprCheck = 42;

			// Token: 0x04039526 RID: 234790
			public const int TxtTips = 43;
		}
	}
}
