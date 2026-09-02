using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x0200101E RID: 4126
[NullableContext(1)]
[Nullable(0)]
public class DrinksMenuPanel : UiPanelBase
{
	// Token: 0x06006B52 RID: 27474 RVA: 0x001C132C File Offset: 0x001BF52C
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIScrollViewWithScrollbarComponent)),
			new ValueTuple<int, Type>(2, typeof(UUIVerticalLayout)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIScrollViewWithScrollbarComponent)),
			new ValueTuple<int, Type>(5, typeof(UUIGridLayout)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(8, typeof(UUIText))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(7, new Action(this.OnClickedConfirm))
		};
	}

	// Token: 0x06006B53 RID: 27475 RVA: 0x001C1430 File Offset: 0x001BF630
	protected override void OnStart()
	{
		this.FlavorScroll = new GenericScrollViewNew<DrinksMenuFlavorItem, int>(base.GetScrollViewWithScrollbar(1), new Func<DrinksMenuFlavorItem>(this.CreateDrinksItem), null, false, null);
		this.OrnamentScroll = new GenericScrollViewNew<DrinksMenuOrnamentItem, int>(base.GetScrollViewWithScrollbar(4), new Func<DrinksMenuOrnamentItem>(this.CreateOrnamentItem), null, false, null);
		this.OrnamentList.Clear();
		foreach (DrinksOrnament drinksOrnament in ConfigBase<DrinksConfig>.Instance.GetAllOrnament())
		{
			this.OrnamentList.Add(drinksOrnament.Id);
		}
		this.OrnamentList.Sort((int a, int b) => a - b);
		this.OrnamentScroll.RefreshByData(this.OrnamentList, null, false);
	}

	// Token: 0x06006B54 RID: 27476 RVA: 0x001C1518 File Offset: 0x001BF718
	public void SetRaycastOnStepEnd()
	{
		UUIButtonComponent button = base.GetButton(7);
		if (button == null)
		{
			return;
		}
		button.RootUIComp.Get().SetRaycastTarget(false);
	}

	// Token: 0x06006B55 RID: 27477 RVA: 0x001C1544 File Offset: 0x001BF744
	public void UpdateOnStepStart()
	{
		UUIButtonComponent button = base.GetButton(7);
		if (button != null)
		{
			button.RootUIComp.Get().SetRaycastTarget(true);
		}
		EDrinksPlayStep curStep = ModelBase<DrinksModel>.Instance.GetCurStep();
		UUIScrollViewWithScrollbarComponent scrollViewWithScrollbar = base.GetScrollViewWithScrollbar(1);
		if (scrollViewWithScrollbar != null)
		{
			scrollViewWithScrollbar.RootUIComp.Get().SetUIActive(curStep != EDrinksPlayStep.Ornament);
		}
		UUIScrollViewWithScrollbarComponent scrollViewWithScrollbar2 = base.GetScrollViewWithScrollbar(4);
		if (scrollViewWithScrollbar2 != null)
		{
			scrollViewWithScrollbar2.RootUIComp.Get().SetUIActive(curStep == EDrinksPlayStep.Ornament);
		}
		DrinksStepConfig? stepConfig = ConfigBase<DrinksConfig>.Instance.GetStepConfig(curStep);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(8), stepConfig.Value.MenuButtonTxt, Array.Empty<object>());
		if (curStep == EDrinksPlayStep.Ornament)
		{
			this.CurrentSelectedOrnament = 0;
			GenericScrollViewNew<DrinksMenuOrnamentItem, int> ornamentScroll = this.OrnamentScroll;
			if (ornamentScroll != null)
			{
				ornamentScroll.RefreshByData(this.OrnamentList, delegate
				{
					GenericScrollViewNew<DrinksMenuOrnamentItem, int> ornamentScroll2 = this.OrnamentScroll;
					if (ornamentScroll2 == null)
					{
						return;
					}
					ornamentScroll2.ScrollToTop(0);
				}, true);
			}
		}
		else if (curStep == EDrinksPlayStep.Batching)
		{
			DrinksResultInfo currentPlayData = ModelBase<DrinksModel>.Instance.GetCurrentPlayData();
			this.CurrentSelectedBatching.Clear();
			if (currentPlayData.Batching != null)
			{
				foreach (int item in currentPlayData.Batching)
				{
					this.CurrentSelectedBatching.Add(item);
				}
			}
			this.RefreshFlavor(curStep);
		}
		else
		{
			DrinksResultInfo currentPlayData2 = ModelBase<DrinksModel>.Instance.GetCurrentPlayData();
			this.CurrentSelectedDrinks = ((curStep == EDrinksPlayStep.Drink1) ? currentPlayData2.DrinkBase[0] : currentPlayData2.DrinkBase[1]);
			this.RefreshFlavor(curStep);
		}
		if (curStep == EDrinksPlayStep.Batching)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), stepConfig.Value.MenuTitle, new <>z__ReadOnlySingleElementList<object>(this.CurrentSelectedBatching.Count));
			this.BatchingKey = stepConfig.Value.MenuTitle;
		}
		else
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), stepConfig.Value.MenuTitle, Array.Empty<object>());
		}
		bool flag = curStep == EDrinksPlayStep.Ornament || curStep == EDrinksPlayStep.Batching;
		bool flag2 = !flag && this.CurrentSelectedDrinks != 0;
		UUIButtonComponent button2 = base.GetButton(7);
		if (button2 != null)
		{
			button2.SetSelfInteractive(flag || flag2);
		}
		if (curStep == EDrinksPlayStep.Batching)
		{
			Singleton<EventSystem>.Instance.Emit<string>(EEventName.OnGuideTriggerEvent, "MakeDrinkBatchingShow");
		}
		if (curStep == EDrinksPlayStep.Ornament)
		{
			Singleton<EventSystem>.Instance.Emit(EEventName.NotifyGuideBreakFocus);
		}
	}

	// Token: 0x06006B56 RID: 27478 RVA: 0x001C17BC File Offset: 0x001BF9BC
	public void RefreshFlavor(EDrinksPlayStep step)
	{
		if (step == EDrinksPlayStep.Batching)
		{
			if (this.BatchingList.Count == 0)
			{
				foreach (DrinksBatching drinksBatching in ConfigBase<DrinksConfig>.Instance.GetAllBatching())
				{
					this.BatchingList.Add(drinksBatching.Id);
				}
			}
			this.FlavorScroll.RefreshByData(this.BatchingList, delegate
			{
				if (this.CurrentSelectedBatching.Count > 0)
				{
					int num = 0;
					using (HashSet<int>.Enumerator enumerator3 = this.CurrentSelectedBatching.GetEnumerator())
					{
						if (enumerator3.MoveNext())
						{
							num = enumerator3.Current;
						}
					}
					using (List<DrinksMenuFlavorItem>.Enumerator enumerator4 = this.FlavorScroll.GetScrollItemList().GetEnumerator())
					{
						while (enumerator4.MoveNext())
						{
							DrinksMenuFlavorItem drinksMenuFlavorItem = enumerator4.Current;
							if (drinksMenuFlavorItem.Id == num)
							{
								GenericScrollViewNew<DrinksMenuFlavorItem, int> flavorScroll = this.FlavorScroll;
								if (flavorScroll == null)
								{
									break;
								}
								flavorScroll.ScrollTo(drinksMenuFlavorItem.GetRootItem(), false);
								break;
							}
						}
						goto IL_B2;
					}
				}
				GenericScrollViewNew<DrinksMenuFlavorItem, int> flavorScroll2 = this.FlavorScroll;
				if (flavorScroll2 != null)
				{
					flavorScroll2.ScrollToTop(0);
				}
				IL_B2:
				ControllerBase<UiNavigationNewController>.Instance.MarkViewHandleRefreshNavigationDirty();
			}, true);
			return;
		}
		IReadOnlyList<DrinksDrinkBase> allDrinkBase = ConfigBase<DrinksConfig>.Instance.GetAllDrinkBase();
		if (this.DrinksList.Count == 0)
		{
			foreach (DrinksDrinkBase drinksDrinkBase in allDrinkBase)
			{
				if (drinksDrinkBase.QTENum == 1)
				{
					this.DrinksList.Add(drinksDrinkBase.Id);
				}
			}
		}
		this.FlavorScroll.RefreshByData(this.DrinksList, delegate
		{
			if (this.CurrentSelectedDrinks != 0)
			{
				using (List<DrinksMenuFlavorItem>.Enumerator enumerator3 = this.FlavorScroll.GetScrollItemList().GetEnumerator())
				{
					while (enumerator3.MoveNext())
					{
						DrinksMenuFlavorItem drinksMenuFlavorItem = enumerator3.Current;
						if (drinksMenuFlavorItem.Id == this.CurrentSelectedDrinks)
						{
							GenericScrollViewNew<DrinksMenuFlavorItem, int> flavorScroll = this.FlavorScroll;
							if (flavorScroll == null)
							{
								break;
							}
							flavorScroll.ScrollTo(drinksMenuFlavorItem.GetRootItem(), false);
							break;
						}
					}
					goto IL_7B;
				}
			}
			GenericScrollViewNew<DrinksMenuFlavorItem, int> flavorScroll2 = this.FlavorScroll;
			if (flavorScroll2 != null)
			{
				flavorScroll2.ScrollToTop(0);
			}
			IL_7B:
			ControllerBase<UiNavigationNewController>.Instance.MarkViewHandleRefreshNavigationDirty();
		}, true);
	}

	// Token: 0x06006B57 RID: 27479 RVA: 0x001C18CC File Offset: 0x001BFACC
	private DrinksMenuFlavorItem CreateDrinksItem()
	{
		return new DrinksMenuFlavorItem
		{
			IsSelectOnCb = new Func<int, bool>(this.GetToggleStateSelected),
			IsEnableCb = new Func<int, bool>(this.GetIsToggleEnable),
			OnToggleStateChangeFunction = new Action<UUIExtendToggle, UUIButtonComponent, int, bool>(this.OnToggleStateChange)
		};
	}

	// Token: 0x06006B58 RID: 27480 RVA: 0x001C1909 File Offset: 0x001BFB09
	private DrinksMenuOrnamentItem CreateOrnamentItem()
	{
		return new DrinksMenuOrnamentItem
		{
			IsSelectOnCb = new Func<int, bool>(this.GetToggleStateSelected),
			OnToggleStateChangeFunction = new Action<int>(this.OnOrnamentToggleStateChange)
		};
	}

	// Token: 0x06006B59 RID: 27481 RVA: 0x001C1934 File Offset: 0x001BFB34
	private bool GetToggleStateSelected(int id)
	{
		EDrinksPlayStep curStep = ModelBase<DrinksModel>.Instance.GetCurStep();
		if (curStep == EDrinksPlayStep.Drink1 || curStep == EDrinksPlayStep.Drink2)
		{
			return this.CurrentSelectedDrinks == id;
		}
		if (curStep == EDrinksPlayStep.Ornament)
		{
			return this.CurrentSelectedOrnament == id;
		}
		return this.CurrentSelectedBatching.Contains(id);
	}

	// Token: 0x06006B5A RID: 27482 RVA: 0x001C1977 File Offset: 0x001BFB77
	private bool GetIsToggleEnable(int id)
	{
		return ModelBase<DrinksModel>.Instance.GetCurStep() != EDrinksPlayStep.Batching || this.CurrentSelectedBatching.Count < 2 || this.CurrentSelectedBatching.Contains(id);
	}

	// Token: 0x06006B5B RID: 27483 RVA: 0x001C19A4 File Offset: 0x001BFBA4
	private void OnToggleStateChange(UUIExtendToggle toggle, UUIButtonComponent reduceButton, int id, bool isSelected)
	{
		EDrinksPlayStep curStep = ModelBase<DrinksModel>.Instance.GetCurStep();
		if (curStep == EDrinksPlayStep.Drink1 || curStep == EDrinksPlayStep.Drink2)
		{
			this.CurrentSelectedDrinks = (isSelected ? id : 0);
			UUIButtonComponent button = base.GetButton(7);
			if (button != null)
			{
				button.SetSelfInteractive(this.CurrentSelectedDrinks != 0);
			}
			ModelBase<DrinksModel>.Instance.UpdateDrinkBase(this.CurrentSelectedDrinks, false);
			this.FlavorScroll.RefreshByData(this.DrinksList, null, false);
			return;
		}
		if (isSelected && this.CurrentSelectedBatching.Count >= 2)
		{
			toggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
			reduceButton.RootUIComp.Get().SetUIActive(false);
			return;
		}
		if (isSelected)
		{
			if (this.CurrentSelectedBatching.Count >= 2)
			{
				Singleton<Log>.Instance.Error(ELogModule.Drinks, ELogAuthor.WHJ, "CurrentSelectedBatching Size Error", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			this.CurrentSelectedBatching.Add(id);
		}
		else
		{
			if (!this.CurrentSelectedBatching.Contains(id))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Drinks;
				ELogAuthor author = ELogAuthor.WHJ;
				string message = "CurrentSelectedBatching includes Error";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", id);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			this.CurrentSelectedBatching.Remove(id);
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), this.BatchingKey, new <>z__ReadOnlySingleElementList<object>(this.CurrentSelectedBatching.Count));
		this.FlavorScroll.RefreshByData(this.BatchingList, null, false);
		ModelBase<DrinksModel>.Instance.UpdateBatching(this.CurrentSelectedBatching, false);
	}

	// Token: 0x06006B5C RID: 27484 RVA: 0x001C1B1F File Offset: 0x001BFD1F
	private void OnOrnamentToggleStateChange(int id)
	{
		this.CurrentSelectedOrnament = id;
		GenericScrollViewNew<DrinksMenuOrnamentItem, int> ornamentScroll = this.OrnamentScroll;
		if (ornamentScroll != null)
		{
			ornamentScroll.RefreshByData(this.OrnamentList, null, false);
		}
		ModelBase<DrinksModel>.Instance.UpdateOrnament(this.CurrentSelectedOrnament, false);
	}

	// Token: 0x06006B5D RID: 27485 RVA: 0x001C1B54 File Offset: 0x001BFD54
	private void OnClickedConfirm()
	{
		DrinksModel instance = ModelBase<DrinksModel>.Instance;
		EDrinksPlayStep? edrinksPlayStep = (instance != null) ? new EDrinksPlayStep?(instance.GetCurStep()) : null;
		if (edrinksPlayStep.GetValueOrDefault() == EDrinksPlayStep.Ornament)
		{
			ModelBase<DrinksModel>.Instance.UpdateOrnament(this.CurrentSelectedOrnament, true);
			return;
		}
		if (edrinksPlayStep.GetValueOrDefault() == EDrinksPlayStep.Batching)
		{
			if (this.CurrentSelectedBatching.Count > 2)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Drinks;
				ELogAuthor author = ELogAuthor.WHJ;
				string message = "Batching Select Size Error";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("set", this.CurrentSelectedBatching);
				instance2.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			if (this.CurrentSelectedBatching.Count > 0)
			{
				Singleton<UiLayer>.Instance.SetShowMaskLayer(EUiViewName.DrinksGameplayView, true);
			}
			ModelBase<DrinksModel>.Instance.UpdateBatching(this.CurrentSelectedBatching, true);
			return;
		}
		else
		{
			if (this.CurrentSelectedDrinks == 0)
			{
				return;
			}
			Singleton<UiLayer>.Instance.SetShowMaskLayer(EUiViewName.DrinksGameplayView, true);
			ModelBase<DrinksModel>.Instance.UpdateDrinkBase(this.CurrentSelectedDrinks, true);
			return;
		}
	}

	// Token: 0x06006B5E RID: 27486 RVA: 0x001C1C48 File Offset: 0x001BFE48
	[NullableContext(2)]
	public UUIItem GuideGetOrnamentItem(int id)
	{
		int index = this.OrnamentList.IndexOf(id);
		GenericScrollViewNew<DrinksMenuOrnamentItem, int> ornamentScroll = this.OrnamentScroll;
		UUIItem uuiitem = (ornamentScroll != null) ? ornamentScroll.GetItemByIndex(index) : null;
		if (uuiitem == null)
		{
			return null;
		}
		GenericScrollViewNew<DrinksMenuOrnamentItem, int> ornamentScroll2 = this.OrnamentScroll;
		if (ornamentScroll2 != null)
		{
			ornamentScroll2.LateScrollTo(uuiitem, null, false);
		}
		return uuiitem;
	}

	// Token: 0x040032FE RID: 13054
	[Nullable(new byte[]
	{
		2,
		1
	})]
	protected GenericScrollViewNew<DrinksMenuFlavorItem, int> FlavorScroll;

	// Token: 0x040032FF RID: 13055
	protected int CurrentSelectedDrinks;

	// Token: 0x04003300 RID: 13056
	[Nullable(new byte[]
	{
		2,
		1
	})]
	protected GenericScrollViewNew<DrinksMenuOrnamentItem, int> OrnamentScroll;

	// Token: 0x04003301 RID: 13057
	protected HashSet<int> CurrentSelectedBatching = new HashSet<int>();

	// Token: 0x04003302 RID: 13058
	protected int CurrentSelectedOrnament;

	// Token: 0x04003303 RID: 13059
	protected List<int> OrnamentList = new List<int>();

	// Token: 0x04003304 RID: 13060
	protected List<int> DrinksList = new List<int>();

	// Token: 0x04003305 RID: 13061
	protected List<int> BatchingList = new List<int>();

	// Token: 0x04003306 RID: 13062
	protected string BatchingKey = "";

	// Token: 0x02007400 RID: 29696
	[NullableContext(0)]
	private static class EDefine
	{
		// Token: 0x040281EF RID: 164335
		public const int Title = 0;

		// Token: 0x040281F0 RID: 164336
		public const int ScrollDrink = 1;

		// Token: 0x040281F1 RID: 164337
		public const int ContentDrink = 2;

		// Token: 0x040281F2 RID: 164338
		public const int ItemDrink = 3;

		// Token: 0x040281F3 RID: 164339
		public const int ScrollBatching = 4;

		// Token: 0x040281F4 RID: 164340
		public const int ContentBatching = 5;

		// Token: 0x040281F5 RID: 164341
		public const int ItemBatching = 6;

		// Token: 0x040281F6 RID: 164342
		public const int BtnConfirm = 7;

		// Token: 0x040281F7 RID: 164343
		public const int TxtConfirm = 8;
	}
}
