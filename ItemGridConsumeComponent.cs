using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020018C6 RID: 6342
[NullableContext(1)]
[Nullable(0)]
public class ItemGridConsumeComponent : UiPanelBase
{
	// Token: 0x0600B628 RID: 46632 RVA: 0x00307174 File Offset: 0x00305374
	public ItemGridConsumeComponent(UUIItem uiItem, CommonMultipleConsumeFunction consumeFunction, EUiViewName? belongView = null, bool needSettingComponent = false)
	{
		this.SourceItem = uiItem;
		this.ConsumeFunction = consumeFunction;
		this.BelongView = belongView;
		this.NeedSettingComponent = needSettingComponent;
	}

	// Token: 0x0600B629 RID: 46633 RVA: 0x003071C8 File Offset: 0x003053C8
	public UniTask Init()
	{
		ItemGridConsumeComponent.<Init>d__19 <Init>d__;
		<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<Init>d__.<>4__this = this;
		<Init>d__.<>1__state = -1;
		<Init>d__.<>t__builder.Start<ItemGridConsumeComponent.<Init>d__19>(ref <Init>d__);
		return <Init>d__.<>t__builder.Task;
	}

	// Token: 0x0600B62A RID: 46634 RVA: 0x0030720C File Offset: 0x0030540C
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(7, typeof(UUITexture)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIScrollViewWithScrollbarComponent)),
			new ValueTuple<int, Type>(3, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(9, typeof(UUIText)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(10, typeof(UUIItem)),
			new ValueTuple<int, Type>(11, typeof(UUIItem)),
			new ValueTuple<int, Type>(12, typeof(UUIItem)),
			new ValueTuple<int, Type>(15, typeof(UUIText)),
			new ValueTuple<int, Type>(20, typeof(UUIText))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(3, new Action(this.AutoClick))
		};
		if (this.NeedSettingComponent)
		{
			this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(18, typeof(UUIButtonComponent)));
			this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(19, typeof(UUIItem)));
			this.BtnBindInfo.Add(new ValueTuple<int, Delegate>(18, new Action(this.OnSettingBtnClick)));
		}
	}

	// Token: 0x0600B62B RID: 46635 RVA: 0x003073F5 File Offset: 0x003055F5
	private OneTextDropDownItem CreateDropDownItem(UUIItem uiItem, QualityInfo data)
	{
		return new OneTextDropDownItem(uiItem);
	}

	// Token: 0x0600B62C RID: 46636 RVA: 0x003073FD File Offset: 0x003055FD
	private OneTextTitleItem CreateTitleItem(UUIItem uiItem)
	{
		return new OneTextTitleItem(uiItem);
	}

	// Token: 0x0600B62D RID: 46637 RVA: 0x00307408 File Offset: 0x00305608
	protected override UniTask OnBeforeStartAsync()
	{
		ItemGridConsumeComponent.<OnBeforeStartAsync>d__23 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ItemGridConsumeComponent.<OnBeforeStartAsync>d__23>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600B62E RID: 46638 RVA: 0x0030744C File Offset: 0x0030564C
	public void InitFilter(EItemGridConsumeLocalDropDown dropDownKey, Action<int> onSelectCall)
	{
		this.DropDownCall = onSelectCall;
		this.CurrentDropDownKey = new EItemGridConsumeLocalDropDown?(dropDownKey);
		int currentDropDownSelectIndex;
		if ((LocalStorage.GetPlayer<Dictionary<int, int>>(ELocalStoragePlayerKey.ItemGridDropDown, null) ?? new Dictionary<int, int>()).TryGetValue((int)dropDownKey, out currentDropDownSelectIndex))
		{
			this.CurrentDropDownSelectIndex = currentDropDownSelectIndex;
		}
		IReadOnlyList<QualityInfo> configList = ConfigQualityInfoAll.GetConfigList(true);
		this.CommonDropDown.SetOnSelectCall(new Action<int, QualityInfo>(this.OnDropDownSelectCall));
		this.CommonDropDown.SetShowType(ECommonDropDownShowType.Up);
		this.CommonDropDown.InitScroll(configList, new Func<QualityInfo, TableTextArgNew>(this.GetDropDownTextId), this.CurrentDropDownSelectIndex, true);
		this.DropDownCall(this.CurrentDropDownSelectIndex);
		base.GetItem(2).SetUIActive(true);
	}

	// Token: 0x0600B62F RID: 46639 RVA: 0x003074F5 File Offset: 0x003056F5
	private TableTextArgNew GetDropDownTextId(QualityInfo data)
	{
		return new TableTextArgNew(data.ConsumeFilterText, Array.Empty<object>());
	}

	// Token: 0x0600B630 RID: 46640 RVA: 0x00307508 File Offset: 0x00305708
	public bool HasSelect()
	{
		return this.GetSelectedGridCount() > 0;
	}

	// Token: 0x0600B631 RID: 46641 RVA: 0x00307514 File Offset: 0x00305714
	public int GetSelectedGridCount()
	{
		int num = 0;
		if (this.ConsumeList == null || this.ConsumeList.Count == 0)
		{
			return num;
		}
		foreach (TCommonMultipleConsumeData tcommonMultipleConsumeData in this.ConsumeList)
		{
			if (tcommonMultipleConsumeData.ItemData.ItemId == 0)
			{
				break;
			}
			num++;
		}
		return num;
	}

	// Token: 0x0600B632 RID: 46642 RVA: 0x00307590 File Offset: 0x00305790
	private void RefreshAutoSelectText()
	{
		if (this.HasSelect())
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(15), "DeleteSelect", Array.Empty<object>());
			return;
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(15), this.SelectTextId, Array.Empty<object>());
	}

	// Token: 0x0600B633 RID: 46643 RVA: 0x003075DF File Offset: 0x003057DF
	public void UpdateAutoSelectTextByTextId(string textId)
	{
		this.SelectTextId = textId;
		this.RefreshAutoSelectText();
	}

	// Token: 0x0600B634 RID: 46644 RVA: 0x003075F0 File Offset: 0x003057F0
	private void AutoClick()
	{
		if (!this.HasSelect())
		{
			if (this.ConsumeFunction.AutoFunction != null)
			{
				this.ConsumeFunction.AutoFunction(this.CurrentDropDownSelectIndex);
				return;
			}
		}
		else
		{
			Action deleteSelectFunction = this.ConsumeFunction.DeleteSelectFunction;
			if (deleteSelectFunction == null)
			{
				return;
			}
			deleteSelectFunction();
		}
	}

	// Token: 0x0600B635 RID: 46645 RVA: 0x0030763E File Offset: 0x0030583E
	private void OnSettingBtnClick()
	{
		Action settingBtnClickCallBack = this.SettingBtnClickCallBack;
		if (settingBtnClickCallBack == null)
		{
			return;
		}
		settingBtnClickCallBack();
	}

	// Token: 0x0600B636 RID: 46646 RVA: 0x00307650 File Offset: 0x00305850
	protected override void OnStart()
	{
		this.StrengthItem = new ButtonItem(base.GetItem(11));
		this.StrengthItem.SetFunction(delegate(int dataId)
		{
			TCommonMultipleConsumeFunction strengthFunction = this.ConsumeFunction.StrengthFunction;
			if (strengthFunction == null)
			{
				return;
			}
			strengthFunction(dataId);
		});
		UUIScrollViewWithScrollbarComponent scrollViewWithScrollbar = base.GetScrollViewWithScrollbar(5);
		this.ScrollView = new GenericScrollViewNew<ConsumeMediumItemGrid, TCommonMultipleConsumeData>(scrollViewWithScrollbar, new Func<ConsumeMediumItemGrid>(this.InitItem), null, false, null);
		base.GetItem(2).SetUIActive(false);
		this.MaxCount = ConfigBase<WeaponConfig>.Instance.GetMaterialItemMaxCount();
		this.SetSettingButtonVisible(false);
	}

	// Token: 0x0600B637 RID: 46647 RVA: 0x003076D0 File Offset: 0x003058D0
	private void OnDropDownSelectCall(int index, QualityInfo data)
	{
		this.CurrentDropDownSelectIndex = index;
		Dictionary<int, int> dictionary = LocalStorage.GetPlayer<Dictionary<int, int>>(ELocalStoragePlayerKey.ItemGridDropDown, null) ?? new Dictionary<int, int>();
		dictionary[(int)this.CurrentDropDownKey.Value] = index;
		LocalStorage.SetPlayer<Dictionary<int, int>>(ELocalStoragePlayerKey.ItemGridDropDown, dictionary);
		Action<int> dropDownCall = this.DropDownCall;
		if (dropDownCall == null)
		{
			return;
		}
		dropDownCall(index);
	}

	// Token: 0x0600B638 RID: 46648 RVA: 0x00307722 File Offset: 0x00305922
	public int GetCurrentDropDownSelectIndex()
	{
		return this.CurrentDropDownSelectIndex;
	}

	// Token: 0x0600B639 RID: 46649 RVA: 0x0030772C File Offset: 0x0030592C
	private ConsumeMediumItemGrid InitItem()
	{
		ConsumeMediumItemGrid consumeMediumItemGrid = new ConsumeMediumItemGrid();
		this.BindItemEvents(consumeMediumItemGrid);
		return consumeMediumItemGrid;
	}

	// Token: 0x0600B63A RID: 46650 RVA: 0x00307748 File Offset: 0x00305948
	private void BindItemEvents(ConsumeMediumItemGrid propItem)
	{
		propItem.BindReduceLongPress(delegate(bool isShortPress, MediumItemGrid mediumItemGrid, object data)
		{
			if (data == null)
			{
				return;
			}
			TCommonMultipleConsumeData tcommonMultipleConsumeData = (TCommonMultipleConsumeData)data;
			TCommonMultipleConsumeFunctionWithInt reduceItemFunction = this.ConsumeFunction.ReduceItemFunction;
			if (reduceItemFunction == null)
			{
				return;
			}
			reduceItemFunction(new int?(tcommonMultipleConsumeData.ItemData.IncId), new int?(tcommonMultipleConsumeData.ItemData.ItemId));
		});
		propItem.BindOnExtendToggleClicked(delegate(MediumItemGridExtendCallback callbackParameter)
		{
			TCommonMultipleConsumeData tcommonMultipleConsumeData = (TCommonMultipleConsumeData)callbackParameter.Data;
			TCommonMultipleConsumeFunctionWithInt materialItemFunction = this.ConsumeFunction.MaterialItemFunction;
			if (materialItemFunction == null)
			{
				return;
			}
			materialItemFunction(new int?(tcommonMultipleConsumeData.ItemData.IncId), new int?(tcommonMultipleConsumeData.ItemData.ItemId));
		});
		propItem.BindEmptySlotButtonCallback(delegate(MediumItemGridButtonCallback callbackParameter)
		{
			Action itemClickFunction = this.ConsumeFunction.ItemClickFunction;
			if (itemClickFunction == null)
			{
				return;
			}
			itemClickFunction();
		});
		propItem.BindOnCanExecuteChange((object _1, bool _2, EToggleState _3) => false);
	}

	// Token: 0x0600B63B RID: 46651 RVA: 0x003077B0 File Offset: 0x003059B0
	protected override void OnBeforeDestroy()
	{
		if (this.StrengthItem != null)
		{
			this.StrengthItem.Destroy(null);
			this.StrengthItem = null;
		}
		CommonDropDown<TableTextArgNew, QualityInfo> commonDropDown = this.CommonDropDown;
		if (commonDropDown != null)
		{
			commonDropDown.Destroy(null);
		}
		if (this.SettingRedDotName != null)
		{
			ControllerBase<RedDotController>.Instance.UnBindGivenUi(this.SettingRedDotName.Value, base.GetItem(19), 0);
		}
	}

	// Token: 0x0600B63C RID: 46652 RVA: 0x00307818 File Offset: 0x00305A18
	public void UpdateComponent(int moneyId, int costCount, List<TCommonMultipleConsumeData> consumeList)
	{
		this.ConsumeList = consumeList;
		this.ScrollView.RefreshByData(this.ConsumeList, null, false);
		int selectedGridCount = this.GetSelectedGridCount();
		Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(0), "WeaponMaterialLengthText", new <>z__ReadOnlyArray<object>(new object[]
		{
			selectedGridCount,
			this.MaxCount
		}));
		UUIText text = base.GetText(8);
		int playerMoney = ModelBase<PlayerInfoModel>.Instance.GetPlayerMoney(moneyId);
		this.CurrentCostCount = costCount;
		text.SetText(costCount.ToString(), true);
		this.EnoughMoney = (playerMoney >= costCount);
		UUIItem uuiitem = text;
		bool bUseChangeColor = playerMoney < costCount;
		FColor? fcolor = new FColor?(text.changeColor);
		uuiitem.SetChangeColor(bUseChangeColor, fcolor);
		this.RefreshAutoSelectText();
	}

	// Token: 0x0600B63D RID: 46653 RVA: 0x003078D2 File Offset: 0x00305AD2
	public void SetMaxState(bool inMax)
	{
		this.SetCostRootItemState(!inMax);
		this.SetStrengthItemEnable(!inMax);
		this.SetMaxItemEnable(inMax);
		this.SetMaterialRootItemEnable(!inMax);
	}

	// Token: 0x0600B63E RID: 46654 RVA: 0x003078F9 File Offset: 0x00305AF9
	public void SetCostRootItemState(bool state)
	{
		base.GetItem(6).SetUIActive(state);
	}

	// Token: 0x0600B63F RID: 46655 RVA: 0x00307908 File Offset: 0x00305B08
	public void SetStrengthItemText(string text)
	{
		this.StrengthItem.SetLocalTextNew(text, Array.Empty<object>());
	}

	// Token: 0x0600B640 RID: 46656 RVA: 0x0030791B File Offset: 0x00305B1B
	public void SetStrengthItemEnable(bool state)
	{
		this.StrengthItem.SetEnableClick(state);
		this.StrengthItem.SetActive(state);
	}

	// Token: 0x0600B641 RID: 46657 RVA: 0x00307935 File Offset: 0x00305B35
	public void SetMaxItemEnable(bool state)
	{
		base.GetItem(12).SetUIActive(state);
	}

	// Token: 0x0600B642 RID: 46658 RVA: 0x00307945 File Offset: 0x00305B45
	public void SetMaterialRootItemEnable(bool state)
	{
		base.GetItem(10).SetUIActive(state);
	}

	// Token: 0x0600B643 RID: 46659 RVA: 0x00307958 File Offset: 0x00305B58
	public void SetConsumeListEnable(bool state)
	{
		UUIScrollViewWithScrollbarComponent scrollViewWithScrollbar = base.GetScrollViewWithScrollbar(5);
		if (scrollViewWithScrollbar == null)
		{
			return;
		}
		scrollViewWithScrollbar.RootUIComp.Get().SetUIActive(state);
	}

	// Token: 0x0600B644 RID: 46660 RVA: 0x00307984 File Offset: 0x00305B84
	public bool GetEnoughMoney()
	{
		return this.EnoughMoney;
	}

	// Token: 0x0600B645 RID: 46661 RVA: 0x0030798C File Offset: 0x00305B8C
	public void SetMaxCount(int count)
	{
		this.MaxCount = count;
	}

	// Token: 0x0600B646 RID: 46662 RVA: 0x00307995 File Offset: 0x00305B95
	public int GetMaxCount()
	{
		return this.MaxCount;
	}

	// Token: 0x0600B647 RID: 46663 RVA: 0x0030799D File Offset: 0x00305B9D
	public void RefreshConditionText(string str)
	{
		base.GetText(9).ShowTextNew(str);
	}

	// Token: 0x0600B648 RID: 46664 RVA: 0x003079B0 File Offset: 0x00305BB0
	public void SetConsumeTexture(int itemId)
	{
		base.SetItemIcon(base.GetTexture(7), itemId, null, null);
	}

	// Token: 0x0600B649 RID: 46665 RVA: 0x003079D8 File Offset: 0x00305BD8
	public void SetSettingButtonVisible(bool bVisible)
	{
		if (!this.NeedSettingComponent)
		{
			return;
		}
		UUIButtonComponent button = base.GetButton(18);
		if (button == null)
		{
			return;
		}
		button.RootUIComp.Get().SetUIActive(bVisible);
	}

	// Token: 0x0600B64A RID: 46666 RVA: 0x00307A0E File Offset: 0x00305C0E
	public void SetSettingButtonClickCallBack(Action callBack)
	{
		this.SettingBtnClickCallBack = callBack;
	}

	// Token: 0x0600B64B RID: 46667 RVA: 0x00307A17 File Offset: 0x00305C17
	public void BindSettingButtonRedDot(ERedDotName name)
	{
		if (!this.NeedSettingComponent)
		{
			return;
		}
		this.SettingRedDotName = new ERedDotName?(name);
		ControllerBase<RedDotController>.Instance.BindRedDot(name, base.GetItem(19), null, 0);
	}

	// Token: 0x0600B64C RID: 46668 RVA: 0x00307A43 File Offset: 0x00305C43
	public void SetMaxItemText(string text)
	{
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(20), text, Array.Empty<object>());
	}

	// Token: 0x0600B64D RID: 46669 RVA: 0x00307A5D File Offset: 0x00305C5D
	public int GetCurrentCostCount()
	{
		return this.CurrentCostCount;
	}

	// Token: 0x040055CC RID: 21964
	[Nullable(2)]
	protected ButtonItem StrengthItem;

	// Token: 0x040055CD RID: 21965
	[Nullable(new byte[]
	{
		2,
		1
	})]
	protected GenericScrollViewNew<ConsumeMediumItemGrid, TCommonMultipleConsumeData> ScrollView;

	// Token: 0x040055CE RID: 21966
	protected List<TCommonMultipleConsumeData> ConsumeList = new List<TCommonMultipleConsumeData>();

	// Token: 0x040055CF RID: 21967
	private int CurrentDropDownSelectIndex = 3;

	// Token: 0x040055D0 RID: 21968
	protected int MaxCount;

	// Token: 0x040055D1 RID: 21969
	protected bool EnoughMoney = true;

	// Token: 0x040055D2 RID: 21970
	protected int CurrentCostCount;

	// Token: 0x040055D3 RID: 21971
	protected string SelectTextId = "AutoSelect";

	// Token: 0x040055D4 RID: 21972
	protected ERedDotName? SettingRedDotName;

	// Token: 0x040055D5 RID: 21973
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private CommonDropDown<TableTextArgNew, QualityInfo> CommonDropDown;

	// Token: 0x040055D6 RID: 21974
	[Nullable(2)]
	private Action<int> DropDownCall;

	// Token: 0x040055D7 RID: 21975
	private EItemGridConsumeLocalDropDown? CurrentDropDownKey;

	// Token: 0x040055D8 RID: 21976
	[Nullable(2)]
	private readonly UUIItem SourceItem;

	// Token: 0x040055D9 RID: 21977
	[Nullable(2)]
	private Action SettingBtnClickCallBack;

	// Token: 0x040055DA RID: 21978
	protected CommonMultipleConsumeFunction ConsumeFunction;

	// Token: 0x040055DB RID: 21979
	public EUiViewName? BelongView;

	// Token: 0x040055DC RID: 21980
	public bool NeedSettingComponent;

	// Token: 0x02007C3F RID: 31807
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402A6EF RID: 173807
		AddMaterialText,
		// Token: 0x0402A6F0 RID: 173808
		PanelButton,
		// Token: 0x0402A6F1 RID: 173809
		DropDownItem,
		// Token: 0x0402A6F2 RID: 173810
		AutoButton,
		// Token: 0x0402A6F3 RID: 173811
		LoopItem,
		// Token: 0x0402A6F4 RID: 173812
		ScrollView,
		// Token: 0x0402A6F5 RID: 173813
		CostRootItem,
		// Token: 0x0402A6F6 RID: 173814
		ConsumeTexture,
		// Token: 0x0402A6F7 RID: 173815
		ConsumeText,
		// Token: 0x0402A6F8 RID: 173816
		ConditionText,
		// Token: 0x0402A6F9 RID: 173817
		MaterialRootItem,
		// Token: 0x0402A6FA RID: 173818
		StrengthItem,
		// Token: 0x0402A6FB RID: 173819
		MaxItem,
		// Token: 0x0402A6FC RID: 173820
		LockItem,
		// Token: 0x0402A6FD RID: 173821
		TopButtons,
		// Token: 0x0402A6FE RID: 173822
		AutoButtonText,
		// Token: 0x0402A6FF RID: 173823
		LockText,
		// Token: 0x0402A700 RID: 173824
		LockTipButton,
		// Token: 0x0402A701 RID: 173825
		SettingButton,
		// Token: 0x0402A702 RID: 173826
		SettingButtonRedDotItem,
		// Token: 0x0402A703 RID: 173827
		MaxItemText
	}
}
