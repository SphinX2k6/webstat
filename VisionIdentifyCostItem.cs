using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.Common.NumberSelect;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002522 RID: 9506
[NullableContext(1)]
[Nullable(0)]
internal class VisionIdentifyCostItem : UiPanelBase
{
	// Token: 0x06012791 RID: 75665 RVA: 0x00515D99 File Offset: 0x00513F99
	public VisionIdentifyCostItem(UUIItem uiItem)
	{
		this.SourceItem = uiItem;
	}

	// Token: 0x06012792 RID: 75666 RVA: 0x00515DA8 File Offset: 0x00513FA8
	public void Init()
	{
		base.SetRootActor(this.SourceItem.GetOwner(), true);
	}

	// Token: 0x06012793 RID: 75667 RVA: 0x00515DBC File Offset: 0x00513FBC
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIText)),
			new ValueTuple<int, Type>(6, typeof(UUIText)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIItem)),
			new ValueTuple<int, Type>(9, typeof(UUITexture)),
			new ValueTuple<int, Type>(10, typeof(UUIText)),
			new ValueTuple<int, Type>(11, typeof(UUIItem)),
			new ValueTuple<int, Type>(12, typeof(UUIItem)),
			new ValueTuple<int, Type>(13, typeof(UUIText))
		};
	}

	// Token: 0x06012794 RID: 75668 RVA: 0x00515F10 File Offset: 0x00514110
	protected override void OnStart()
	{
		this.NumberSelect = new NumberSelectComponent(base.GetItem(8));
		this.StrengthItem = new ButtonItem(base.GetItem(11));
		this.StrengthItem.SetFunction(new Action<int>(this.OnClickStrengthButton));
		this.ItemGridVariantSelect = new MediumItemGrid();
		this.ItemGridVariantSelect.Initialize(base.GetItem(12).GetOwner());
		this.ItemGridVariantSelect.BindOnExtendToggleStateChanged(new Action<MediumItemGridExtendCallback>(this.OnClickedRewardItem));
	}

	// Token: 0x06012795 RID: 75669 RVA: 0x00515F94 File Offset: 0x00514194
	private void OnClickedRewardItem(MediumItemGridExtendCallback callbackParameter)
	{
		MediumItemGrid itemGridVariantSelect = this.ItemGridVariantSelect;
		if (itemGridVariantSelect != null)
		{
			itemGridVariantSelect.SetSelected(false, true);
		}
		int currentIdentifyCostId = this.Data.GetCurrentIdentifyCostId();
		List<ItemDataBase> itemDataBaseByConfigId = ModelBase<InventoryModel>.Instance.GetItemDataBaseByConfigId(currentIdentifyCostId);
		int num = 0;
		if (itemDataBaseByConfigId.Count > 0)
		{
			num = itemDataBaseByConfigId[0].GetUniqueId();
		}
		if (num != 0 && num > 0)
		{
			ControllerBase<ItemController>.Instance.OpenItemTipsByItemUid(num, currentIdentifyCostId, true, null);
			return;
		}
		ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(currentIdentifyCostId, true, null);
	}

	// Token: 0x06012796 RID: 75670 RVA: 0x00516008 File Offset: 0x00514208
	private void OnClickStrengthButton(int _)
	{
		if (!this.GetRedItemEnoughItemState(this.Data))
		{
			ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("LevelUpMaterialShort", Array.Empty<object>());
			return;
		}
		if (!this.Data.GetIfHaveEnoughIdentifyGold(this.CurrentConsumeSelectNum()))
		{
			ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("IdentifyNotEnoughMoney", Array.Empty<object>());
			return;
		}
		this.RequestIdentify().Forget();
	}

	// Token: 0x06012797 RID: 75671 RVA: 0x0051606C File Offset: 0x0051426C
	private UniTask RequestIdentify()
	{
		VisionIdentifyCostItem.<RequestIdentify>d__13 <RequestIdentify>d__;
		<RequestIdentify>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RequestIdentify>d__.<>4__this = this;
		<RequestIdentify>d__.<>1__state = -1;
		<RequestIdentify>d__.<>t__builder.Start<VisionIdentifyCostItem.<RequestIdentify>d__13>(ref <RequestIdentify>d__);
		return <RequestIdentify>d__.<>t__builder.Task;
	}

	// Token: 0x06012798 RID: 75672 RVA: 0x005160AF File Offset: 0x005142AF
	private TableTextArgNew GetExchangeTableText(int selectValue)
	{
		return new TableTextArgNew(ConfigBase<TextConfig>.Instance.GetTextContentIdById("IdentifyCount"), new <>z__ReadOnlySingleElementList<object>(selectValue));
	}

	// Token: 0x06012799 RID: 75673 RVA: 0x005160D0 File Offset: 0x005142D0
	private void RefreshStrengthButton()
	{
	}

	// Token: 0x0601279A RID: 75674 RVA: 0x005160D2 File Offset: 0x005142D2
	private void ValueChangeFunction(int selectValue)
	{
		this.RefreshView();
		Action onChangeValueCall = this.OnChangeValueCall;
		if (onChangeValueCall == null)
		{
			return;
		}
		onChangeValueCall();
	}

	// Token: 0x0601279B RID: 75675 RVA: 0x005160EC File Offset: 0x005142EC
	private void RefreshItemShow(PhantomDataBase data)
	{
		int currentIdentifyCostId = data.GetCurrentIdentifyCostId();
		ItemInfo? itemConfig = ConfigBase<InventoryConfig>.Instance.GetItemConfig(currentIdentifyCostId);
		if (itemConfig == null)
		{
			return;
		}
		PropMediumItemGrid propMediumItemGrid = new PropMediumItemGrid
		{
			ItemConfigId = new int?(currentIdentifyCostId),
			StarLevel = new int?(itemConfig.Value.QualityId)
		};
		int currentIdentifyCostValue = data.GetCurrentIdentifyCostValue();
		List<ItemDataBase> itemDataBaseByConfigId = ModelBase<InventoryModel>.Instance.GetItemDataBaseByConfigId(currentIdentifyCostId);
		int num = 0;
		if (itemDataBaseByConfigId.Count > 0)
		{
			num = itemDataBaseByConfigId[0].GetCount();
		}
		int num2 = 0;
		if (this.CurrentConsumeSelectNum() > 0)
		{
			num2 = currentIdentifyCostValue * this.CurrentConsumeSelectNum();
		}
		if (num >= currentIdentifyCostValue)
		{
			propMediumItemGrid.BottomText = StringUtils.Format(ConfigMultiTextLang.GetLocalTextNew("Text_CollectProgress_Text", null), new string[]
			{
				num.ToString(),
				num2.ToString()
			});
		}
		else
		{
			propMediumItemGrid.BottomText = StringUtils.Format(ConfigMultiTextLang.GetLocalTextNew("Text_ItemCostNotEnough_Text", null), new string[]
			{
				num.ToString(),
				num2.ToString()
			});
		}
		this.ItemGridVariantSelect.Apply<PropMediumItemGrid>(propMediumItemGrid);
	}

	// Token: 0x0601279C RID: 75676 RVA: 0x005161FC File Offset: 0x005143FC
	private void RefreshNumSelectComponent(PhantomDataBase data)
	{
		int currentCanIdentifyCount = data.GetCurrentCanIdentifyCount();
		INumberSelectData data2 = new INumberSelectData
		{
			MaxNumber = currentCanIdentifyCount,
			GetExchangeTableText = new Func<int, TableTextArgNew>(this.GetExchangeTableText),
			ValueChangeFunction = new Action<int>(this.ValueChangeFunction)
		};
		this.NumberSelect.SetMinValue(0);
		this.NumberSelect.Init(data2);
		this.NumberSelect.SetAddReduceButtonActive(true);
		this.NumberSelect.SetMinTextShowState(true);
		this.NumberSelect.SetAddReduceButtonInteractive(currentCanIdentifyCount > 1);
		this.NumberSelect.SetReduceButtonInteractive(this.CurrentConsumeSelectNum() > 1);
	}

	// Token: 0x0601279D RID: 75677 RVA: 0x00516294 File Offset: 0x00514494
	private void RefreshConsume(PhantomDataBase data)
	{
		int identifyCostItemId = data.GetIdentifyCostItemId();
		base.SetItemIcon(base.GetTexture(9), identifyCostItemId, null, null);
		UUIText text = base.GetText(10);
		if (text == null)
		{
			return;
		}
		text.SetText((data.GetIdentifyCostItemValue() * this.CurrentConsumeSelectNum()).ToString(), true);
		UUIItem uuiitem = text;
		bool bUseChangeColor = !data.GetIfHaveEnoughIdentifyGold(this.CurrentConsumeSelectNum());
		FColor? fcolor = new FColor?(text.changeColor);
		uuiitem.SetChangeColor(bUseChangeColor, fcolor);
	}

	// Token: 0x0601279E RID: 75678 RVA: 0x00516310 File Offset: 0x00514510
	private void RefreshGreenItem(PhantomDataBase data)
	{
		bool ifNeedShowGreenItem = this.GetIfNeedShowGreenItem(data);
		base.GetItem(3).SetUIActive(ifNeedShowGreenItem);
	}

	// Token: 0x0601279F RID: 75679 RVA: 0x00516334 File Offset: 0x00514534
	private bool GetIfNeedShowGreenItem(PhantomDataBase data)
	{
		List<VisionSubPropData> levelSubPropData = data.GetLevelSubPropData(data.GetPhantomLevel());
		bool result = true;
		using (List<VisionSubPropData>.Enumerator enumerator = levelSubPropData.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.SlotState != EVisionSlotState.UnlockAndHaveProp)
				{
					result = false;
					break;
				}
			}
		}
		return result;
	}

	// Token: 0x060127A0 RID: 75680 RVA: 0x00516394 File Offset: 0x00514594
	private void RefreshRedItem(PhantomDataBase data)
	{
		bool redItemShowState = this.GetRedItemShowState(data);
		base.GetItem(4).SetUIActive(redItemShowState);
		if (redItemShowState)
		{
			if (!data.GetIfHaveEnoughIdentifyConsumeItem(this.CurrentConsumeSelectNum()))
			{
				base.GetText(5).SetText(ConfigMultiTextLang.GetLocalTextNew("IdentifyNotEnough", null), true);
				return;
			}
			Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(5), "IdentifyNeedLevelText", new <>z__ReadOnlySingleElementList<object>(data.GetNextIdentifyLevel()));
		}
	}

	// Token: 0x060127A1 RID: 75681 RVA: 0x00516406 File Offset: 0x00514606
	private bool GetRedItemEnoughItemState(PhantomDataBase data)
	{
		return data.GetIfHaveEnoughIdentifyConsumeItem(this.CurrentConsumeSelectNum());
	}

	// Token: 0x060127A2 RID: 75682 RVA: 0x00516414 File Offset: 0x00514614
	private bool GetRedItemShowState(PhantomDataBase data)
	{
		bool ifHaveEnoughIdentifyConsumeItem = data.GetIfHaveEnoughIdentifyConsumeItem(this.CurrentConsumeSelectNum());
		bool ifHaveUnIdentifySubProp = data.GetIfHaveUnIdentifySubProp();
		return !this.GetIfNeedShowGreenItem(data) && (!ifHaveUnIdentifySubProp || !ifHaveEnoughIdentifyConsumeItem);
	}

	// Token: 0x060127A3 RID: 75683 RVA: 0x0051644C File Offset: 0x0051464C
	private void RefreshItemShowState(PhantomDataBase data)
	{
		bool ifNeedShowGreenItem = this.GetIfNeedShowGreenItem(data);
		bool redItemShowState = this.GetRedItemShowState(data);
		bool flag = ifNeedShowGreenItem || redItemShowState;
		base.GetItem(7).SetUIActive(!flag);
		base.GetItem(11).SetUIActive(!flag);
		if (redItemShowState)
		{
			bool ifHaveEnoughIdentifyConsumeItem = data.GetIfHaveEnoughIdentifyConsumeItem(this.CurrentConsumeSelectNum());
			base.GetItem(2).SetUIActive(!ifHaveEnoughIdentifyConsumeItem);
		}
		if (ifNeedShowGreenItem)
		{
			base.GetItem(2).SetUIActive(false);
		}
		if (!redItemShowState && !ifNeedShowGreenItem)
		{
			base.GetItem(2).SetUIActive(true);
		}
	}

	// Token: 0x060127A4 RID: 75684 RVA: 0x005164D1 File Offset: 0x005146D1
	public int CurrentConsumeSelectNum()
	{
		return this.NumberSelect.GetSelectNumber();
	}

	// Token: 0x060127A5 RID: 75685 RVA: 0x005164DE File Offset: 0x005146DE
	public void Update(PhantomDataBase data)
	{
		this.Data = data;
		this.RefreshNumSelectComponent(this.Data);
		this.RefreshView();
	}

	// Token: 0x060127A6 RID: 75686 RVA: 0x005164F9 File Offset: 0x005146F9
	public void SetOnChangeValueCallBack(Action call)
	{
		this.OnChangeValueCall = call;
	}

	// Token: 0x060127A7 RID: 75687 RVA: 0x00516504 File Offset: 0x00514704
	private void RefreshNumberSelectIdentifyText(PhantomDataBase data)
	{
		if (!data.GetIfHaveEnoughIdentifyConsumeItem(this.CurrentConsumeSelectNum()) && this.CurrentConsumeSelectNum() == 1)
		{
			string numberSelectTipsText = StringUtils.Format(ConfigMultiTextLang.GetLocalTextNew(ConfigBase<TextConfig>.Instance.GetTextContentIdById("IdentifyCount"), null), new string[]
			{
				"0"
			});
			this.NumberSelect.SetNumberSelectTipsText(numberSelectTipsText);
		}
	}

	// Token: 0x060127A8 RID: 75688 RVA: 0x00516560 File Offset: 0x00514760
	private void RefreshView()
	{
		this.RefreshConsume(this.Data);
		this.RefreshRedItem(this.Data);
		this.RefreshGreenItem(this.Data);
		this.RefreshItemShowState(this.Data);
		this.RefreshItemShow(this.Data);
		this.RefreshStrengthButton();
		this.RefreshNumberSelectIdentifyText(this.Data);
	}

	// Token: 0x04009023 RID: 36899
	[Nullable(2)]
	private readonly UUIItem SourceItem;

	// Token: 0x04009024 RID: 36900
	[Nullable(2)]
	private NumberSelectComponent NumberSelect;

	// Token: 0x04009025 RID: 36901
	[Nullable(2)]
	private PhantomDataBase Data;

	// Token: 0x04009026 RID: 36902
	[Nullable(2)]
	private ButtonItem StrengthItem;

	// Token: 0x04009027 RID: 36903
	[Nullable(2)]
	private Action OnChangeValueCall;

	// Token: 0x04009028 RID: 36904
	[Nullable(2)]
	private MediumItemGrid ItemGridVariantSelect;

	// Token: 0x02008843 RID: 34883
	[NullableContext(0)]
	private enum EVisionIdentifyCostItemEnum
	{
		// Token: 0x0402E05D RID: 188509
		TitleText,
		// Token: 0x0402E05E RID: 188510
		MoneyItem,
		// Token: 0x0402E05F RID: 188511
		ConsumeItemParent,
		// Token: 0x0402E060 RID: 188512
		GreenItem,
		// Token: 0x0402E061 RID: 188513
		RedItem,
		// Token: 0x0402E062 RID: 188514
		RedText,
		// Token: 0x0402E063 RID: 188515
		GreenText,
		// Token: 0x0402E064 RID: 188516
		IdentifyTitleItem,
		// Token: 0x0402E065 RID: 188517
		NumSelectComponent,
		// Token: 0x0402E066 RID: 188518
		ConsumeTexture,
		// Token: 0x0402E067 RID: 188519
		ConsumeText,
		// Token: 0x0402E068 RID: 188520
		ConfirmButtonItem,
		// Token: 0x0402E069 RID: 188521
		ItemBase,
		// Token: 0x0402E06A RID: 188522
		ItemDownText
	}
}
