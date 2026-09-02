using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Protocol;
using CSharpScript.Game.Module.FloroRanch;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001C50 RID: 7248
[NullableContext(1)]
[Nullable(0)]
public class FloroRanchCommonTipItem : UiPanelBase
{
	// Token: 0x0600D37C RID: 54140 RVA: 0x00385750 File Offset: 0x00383950
	protected unsafe override void OnRegisterComponent()
	{
		int num = 27;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIVerticalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(15, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(17, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(18, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(19, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(20, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(21, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(22, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(23, typeof(UUIScrollViewWithScrollbarComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(24, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(25, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(26, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(14, new Action(this.OnDeleteButtonClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600D37D RID: 54141 RVA: 0x00385B43 File Offset: 0x00383D43
	protected override void OnStart()
	{
		this.BuffLayout = new GenericLayout<FloroRanchBuffItem, FloroRanchBuffData>(base.GetVerticalLayout(12), this.CreateBuffItem, null, false, true);
		UUIExtendToggle extendToggle = base.GetExtendToggle(24);
		if (extendToggle != null)
		{
			extendToggle.SetToggleStateForce(EToggleState.ETT_UnDetermined, false, false, false);
		}
		this.RegisterTermExplanation();
	}

	// Token: 0x0600D37E RID: 54142 RVA: 0x00385B7E File Offset: 0x00383D7E
	protected override void OnBeforeDestroy()
	{
		this.UnRegisterTermExplanation();
	}

	// Token: 0x0600D37F RID: 54143 RVA: 0x00385B88 File Offset: 0x00383D88
	public void RefreshInfoTipByParam(IFloroRanchCommonTipParam param)
	{
		this.ParamData = param;
		this.InitTipItem();
		switch (param.TipType)
		{
		case EFloroRanchCommonTipType.Entity:
			this.RefreshEntityTip();
			break;
		case EFloroRanchCommonTipType.Currency:
			this.RefreshCurrencyTip();
			break;
		case EFloroRanchCommonTipType.Toy:
			this.RefreshToyTip(param.ToyData);
			break;
		case EFloroRanchCommonTipType.Card:
			this.RefreshCardTip(param.CardData, null);
			break;
		}
		UUIScrollViewWithScrollbarComponent scrollViewWithScrollbar = base.GetScrollViewWithScrollbar(23);
		if (scrollViewWithScrollbar != null)
		{
			scrollViewWithScrollbar.SetScrollProgress(0f);
		}
		UUIItem rootItem = base.GetRootItem();
		if (rootItem == null)
		{
			return;
		}
		rootItem.SetUIActive(true);
	}

	// Token: 0x0600D380 RID: 54144 RVA: 0x00385C18 File Offset: 0x00383E18
	private void InitTipItem()
	{
		UUIText text = base.GetText(2);
		if (text != null)
		{
			text.SetUIActive(false);
		}
		UUIButtonComponent button = base.GetButton(14);
		if (button != null)
		{
			UUIItem uuiitem = button.RootUIComp.Get();
			if (uuiitem != null)
			{
				uuiitem.SetUIActive(false);
			}
		}
		base.GetItem(26).SetUIActive(false);
		UUIItem item = base.GetItem(11);
		if (item != null)
		{
			item.SetUIActive(false);
		}
		UUIItem item2 = base.GetItem(7);
		if (item2 != null)
		{
			item2.SetUIActive(false);
		}
		UUIItem item3 = base.GetItem(4);
		if (item3 != null)
		{
			item3.SetUIActive(false);
		}
		UUIItem item4 = base.GetItem(20);
		if (item4 != null)
		{
			item4.SetUIActive(false);
		}
		UUIItem item5 = base.GetItem(21);
		if (item5 != null)
		{
			item5.SetUIActive(false);
		}
		UUIText text2 = base.GetText(25);
		if (text2 == null)
		{
			return;
		}
		text2.SetUIActive(false);
	}

	// Token: 0x0600D381 RID: 54145 RVA: 0x00385CE4 File Offset: 0x00383EE4
	private void RefreshCurrencyTip()
	{
		IFloroRanchCommonTipParam paramData = this.ParamData;
		FloroRanchCurrencyData floroRanchCurrencyData = (paramData != null) ? paramData.CurrencyData : null;
		if (floroRanchCurrencyData == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.FloroRanchGamePlay, ELogAuthor.LRC, "currencyData为空", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		UUIText text = base.GetText(1);
		if (text != null)
		{
			text.ShowTextNew(floroRanchCurrencyData.ConfigData.GetName());
		}
		UUIText text2 = base.GetText(10);
		if (text2 != null)
		{
			text2.ShowTextNew(floroRanchCurrencyData.ConfigData.GetDesc());
		}
		base.SetTextureShowUntilLoaded(floroRanchCurrencyData.ConfigData.GetIcon(), base.GetTexture(3), null);
		FloroRanchRarityData qualityData = floroRanchCurrencyData.ConfigData.GetQualityData();
		base.SetTextureShowUntilLoaded(qualityData.GetRarityDetailCardBigBg(), base.GetTexture(18), null);
		base.SetTextureShowUntilLoaded(qualityData.GetRarityDetailCardSmallBg(), base.GetTexture(19), null);
		this.Price = 0;
	}

	// Token: 0x0600D382 RID: 54146 RVA: 0x00385DB8 File Offset: 0x00383FB8
	private void RefreshEntityTip()
	{
		IFloroRanchCommonTipParam paramData = this.ParamData;
		FloroRanchEntityBase floroRanchEntityBase = (paramData != null) ? paramData.EntityData : null;
		if (floroRanchEntityBase == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.FloroRanchGamePlay, ELogAuthor.LRC, "cardEntity为空", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		EFloroRanchEntityType entityType = floroRanchEntityBase.EntityType;
		FloroRanchEntityDataComponent floroRanchEntityDataComponent = floroRanchEntityBase.CheckGetComponent<FloroRanchEntityDataComponent>();
		if (entityType == EFloroRanchEntityType.Card)
		{
			FloroRanchCardDataComponent floroRanchCardDataComponent = floroRanchEntityBase.CheckGetComponent<FloroRanchCardDataComponent>();
			this.RefreshCardTip(floroRanchCardDataComponent.CardData, floroRanchEntityDataComponent.DailySaleData);
			UUIText text = base.GetText(17);
			if (text != null)
			{
				text.ShowTextNew("Farm_Edit3".ToString());
			}
			UUIButtonComponent button = base.GetButton(14);
			if (button != null)
			{
				UUIItem uuiitem = button.RootUIComp.Get();
				if (uuiitem != null)
				{
					uuiitem.SetUIActive(true);
				}
			}
		}
		else if (entityType == EFloroRanchEntityType.Toy)
		{
			FloroRanchToyDataComponent floroRanchToyDataComponent = floroRanchEntityBase.CheckGetComponent<FloroRanchToyDataComponent>();
			FloroRanchToyData toyData = floroRanchToyDataComponent.ToyData;
			int level = floroRanchToyDataComponent.Level;
			if (level > 0)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(25), "Farm_ToyLevelText", new <>z__ReadOnlySingleElementList<object>(level));
			}
			UUIText text2 = base.GetText(25);
			if (text2 != null)
			{
				text2.SetUIActive(level > 0);
			}
			this.RefreshToyTip(toyData);
			bool flag = toyData.CheckCanSell();
			if (flag)
			{
				UUIText text3 = base.GetText(17);
				if (text3 != null)
				{
					text3.ShowTextNew("Farm_Edit2".ToString());
				}
			}
			base.GetItem(26).SetUIActive(!flag);
			UUIButtonComponent button2 = base.GetButton(14);
			if (button2 != null)
			{
				UUIItem uuiitem2 = button2.RootUIComp.Get();
				if (uuiitem2 != null)
				{
					uuiitem2.SetUIActive(flag);
				}
			}
		}
		this.RefreshTag(floroRanchEntityDataComponent.TagData);
		this.RefreshBuffTip(floroRanchEntityBase);
	}

	// Token: 0x0600D383 RID: 54147 RVA: 0x00385F54 File Offset: 0x00384154
	private void RefreshCardTip(FloroRanchCardData cardData, FloroRanchCurrencyData currencyData)
	{
		UUIText text = base.GetText(2);
		if (text != null)
		{
			text.ShowTextNew("Farm_CardType1");
		}
		UUIText text2 = base.GetText(2);
		if (text2 != null)
		{
			text2.SetUIActive(true);
		}
		UUIText text3 = base.GetText(1);
		if (text3 != null)
		{
			text3.ShowTextNew(cardData.GetName());
		}
		this.RefreshTag(cardData.TagData);
		base.SetTextureShowUntilLoaded(cardData.GetIcon(), base.GetTexture(3), null);
		UUIText text4 = base.GetText(6);
		if (text4 != null)
		{
			text4.ShowTextNew(cardData.GetRaceName());
		}
		FloroRanchCurrencyData floroRanchCurrencyData = currencyData;
		if (floroRanchCurrencyData == null)
		{
			floroRanchCurrencyData = new FloroRanchCurrencyData(ECurrencyType.Salary);
			floroRanchCurrencyData.SetAmount(cardData.GetBasicSalary());
		}
		int amount = floroRanchCurrencyData.GetAmount();
		UUIText text5 = base.GetText(9);
		if (text5 != null)
		{
			text5.SetText(ModelBase<FloroRanchModel>.Instance.GetCoinText(amount), true);
		}
		base.SetTextureShowUntilLoaded(floroRanchCurrencyData.ConfigData.GetSmallIcon(), base.GetTexture(8), null);
		base.GetItem(7).SetUIActive(true);
		FloroRanchRaceData floroRanchRaceData = ModelBase<FloroRanchModel>.Instance.GetFloroRanchRaceData(cardData.GetRace());
		if (floroRanchRaceData != null)
		{
			base.SetTextureShowUntilLoaded(floroRanchRaceData.SmallIcon, base.GetTexture(5), null);
			UUIItem item = base.GetItem(4);
			if (item != null)
			{
				item.SetUIActive(true);
			}
		}
		FloroRanchRarityData cardQualityData = cardData.GetCardQualityData();
		base.SetTextureShowUntilLoaded(cardQualityData.GetRarityDetailCardBigBg(), base.GetTexture(18), null);
		base.SetTextureShowUntilLoaded(cardQualityData.GetRarityDetailCardSmallBg(), base.GetTexture(19), null);
		FloroRanchCurrencyData diamondData = ModelBase<FloroRanchGamePlayModel>.Instance.DiamondData;
		int deleteCost = cardData.GetDeleteCost();
		this.Price = deleteCost;
		UUIText text6 = base.GetText(16);
		UUIText uuitext = text6;
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
		defaultInterpolatedStringHandler.AppendLiteral("-");
		defaultInterpolatedStringHandler.AppendFormatted<int>(deleteCost);
		uuitext.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
		if (diamondData.GetAmount() < deleteCost)
		{
			text6.useChangeColor = true;
		}
		else
		{
			text6.useChangeColor = false;
		}
		base.SetTextureShowUntilLoaded(diamondData.ConfigData.GetSmallIcon(), base.GetTexture(15), null);
		UUIItem item2 = base.GetItem(20);
		if (item2 == null)
		{
			return;
		}
		item2.SetUIActive(cardData.IsSpecialPhantom);
	}

	// Token: 0x0600D384 RID: 54148 RVA: 0x00386150 File Offset: 0x00384350
	private void RefreshToyTip(FloroRanchToyData toyData)
	{
		UUIText text = base.GetText(2);
		if (text != null)
		{
			text.ShowTextNew("Farm_CardType2");
		}
		UUIText text2 = base.GetText(2);
		if (text2 != null)
		{
			text2.SetUIActive(true);
		}
		UUIText text3 = base.GetText(1);
		if (text3 != null)
		{
			text3.ShowTextNew(toyData.GetName());
		}
		this.RefreshTag(toyData.TagData);
		base.SetTextureShowUntilLoaded(toyData.GetIcon(), base.GetTexture(3), null);
		FloroRanchRarityData toyQualityData = toyData.GetToyQualityData();
		base.SetTextureShowUntilLoaded(toyQualityData.GetRarityDetailCardBigBg(), base.GetTexture(18), null);
		base.SetTextureShowUntilLoaded(toyQualityData.GetRarityDetailCardSmallBg(), base.GetTexture(19), null);
		int deleteEarn = toyData.GetDeleteEarn();
		UUIText text4 = base.GetText(16);
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
		defaultInterpolatedStringHandler.AppendLiteral("+");
		defaultInterpolatedStringHandler.AppendFormatted<int>(deleteEarn);
		text4.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
		text4.useChangeColor = false;
		FloroRanchCurrencyConfigData floroRanchCurrencyConfig = ModelBase<FloroRanchModel>.Instance.GetFloroRanchCurrencyConfig(ECurrencyType.Diamond);
		base.SetTextureShowUntilLoaded(floroRanchCurrencyConfig.GetSmallIcon(), base.GetTexture(15), null);
		FloroRanchRaceData toyRaceData = toyData.GetToyRaceData();
		if (toyRaceData != null)
		{
			UUIItem item = base.GetItem(21);
			if (item != null)
			{
				item.SetUIActive(true);
			}
			base.SetTextureShowUntilLoaded(toyRaceData.SmallIcon, base.GetTexture(22), null);
		}
		this.Price = 0;
	}

	// Token: 0x0600D385 RID: 54149 RVA: 0x0038628C File Offset: 0x0038448C
	private void RefreshTag(FloroRanchTagData tagData)
	{
		if (tagData.TagId <= 0)
		{
			UUIText text = base.GetText(10);
			if (text == null)
			{
				return;
			}
			text.SetUIActive(false);
			return;
		}
		else
		{
			UUIText text2 = base.GetText(10);
			if (text2 != null)
			{
				text2.SetText(tagData.Desc, true);
			}
			UUIText text3 = base.GetText(10);
			if (text3 == null)
			{
				return;
			}
			text3.SetUIActive(true);
			return;
		}
	}

	// Token: 0x0600D386 RID: 54150 RVA: 0x003862E4 File Offset: 0x003844E4
	private void RefreshBuffTip(FloroRanchEntityBase entityData)
	{
		FloroRanchEntityDataComponent floroRanchEntityDataComponent = entityData.CheckGetComponent<FloroRanchEntityDataComponent>();
		if (floroRanchEntityDataComponent == null)
		{
			return;
		}
		List<FloroRanchBuffData> tipShowBuffList = floroRanchEntityDataComponent.TipShowBuffList;
		if (tipShowBuffList != null && tipShowBuffList.Count <= 0)
		{
			return;
		}
		GenericLayout<FloroRanchBuffItem, FloroRanchBuffData> buffLayout = this.BuffLayout;
		if (buffLayout != null)
		{
			buffLayout.RefreshByData(tipShowBuffList, null, false);
		}
		UUIItem item = base.GetItem(11);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(true);
	}

	// Token: 0x0600D387 RID: 54151 RVA: 0x00386338 File Offset: 0x00384538
	private void RegisterTermExplanation()
	{
		TermExplanationRegistryParam param = new TermExplanationRegistryParam
		{
			UiText = base.GetText(10),
			ViewType = ETermExplanationViewType.Center,
			Style = new ETermExplanationViewStyle?(ETermExplanationViewStyle.FloroRanch),
			ReportType = ETermExplanationReportType.FloroRanch,
			Group = new ETermExplanationGroup?(this.TermGroup)
		};
		ControllerBase<TermExplanationController>.Instance.RegisterTextHyperlinkByParam(param);
	}

	// Token: 0x0600D388 RID: 54152 RVA: 0x00386390 File Offset: 0x00384590
	private void UnRegisterTermExplanation()
	{
		ControllerBase<TermExplanationController>.Instance.UnRegisterTextHyperlink(base.GetText(10));
	}

	// Token: 0x0600D389 RID: 54153 RVA: 0x003863A4 File Offset: 0x003845A4
	private void OnDeleteButtonClick()
	{
		if (this.ParamData == null || this.ParamData.TipType != EFloroRanchCommonTipType.Entity)
		{
			return;
		}
		FloroRanchEntityBase entityData = this.ParamData.EntityData;
		if (entityData == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.FloroRanchGamePlay, ELogAuthor.LRC, "删除按钮点击 entityData为空", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		if (entityData.EntityType == EFloroRanchEntityType.Toy)
		{
			FloroRanchToyDataComponent floroRanchToyDataComponent = entityData.CheckGetComponent<FloroRanchToyDataComponent>();
			if (floroRanchToyDataComponent != null)
			{
				FloroRanchToyData toyData = floroRanchToyDataComponent.ToyData;
				if (toyData != null && toyData.CheckCanSell())
				{
					goto IL_92;
				}
			}
			return;
		}
		IL_92:
		if (ModelBase<FloroRanchGamePlayModel>.Instance.DiamondData.GetAmount() < this.Price)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Farm_MoneyNotEnough".ToString(), Array.Empty<object>());
			return;
		}
		int subInstanceId = ModelBase<FloroRanchGamePlayModel>.Instance.SubInstanceId;
		int entityId = entityData.EntityId;
		global::FloroRanchActivityData currentActivityData = ModelBase<FloroRanchGamePlayModel>.Instance.GetCurrentActivityData();
		if (currentActivityData == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.FloroRanchGamePlay, ELogAuthor.LRC, "删除按钮点击 当前不在弗洛洛玩法内，无法执行删除", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		ControllerBase<FloroRanchController>.Instance.SendFloroRanchPlayRemoveUnitRequest(currentActivityData.Id, subInstanceId, entityId, delegate(FloroRanchPlayRemoveUnitResponse _)
		{
			Action<FloroRanchEntityBase> removeCallback = this.ParamData.RemoveCallback;
			if (removeCallback == null)
			{
				return;
			}
			removeCallback(entityData);
		});
	}

	// Token: 0x040064B5 RID: 25781
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<FloroRanchBuffItem, FloroRanchBuffData> BuffLayout;

	// Token: 0x040064B6 RID: 25782
	private IFloroRanchCommonTipParam ParamData;

	// Token: 0x040064B7 RID: 25783
	private int Price;

	// Token: 0x040064B8 RID: 25784
	public ETermExplanationGroup TermGroup;

	// Token: 0x040064B9 RID: 25785
	private readonly Func<FloroRanchBuffItem> CreateBuffItem = () => new FloroRanchBuffItem();

	// Token: 0x02007F5E RID: 32606
	[NullableContext(0)]
	private class EComponentDefine
	{
		// Token: 0x0402B5CD RID: 177613
		public const int TipItem = 0;

		// Token: 0x0402B5CE RID: 177614
		public const int Name = 1;

		// Token: 0x0402B5CF RID: 177615
		public const int TypeName = 2;

		// Token: 0x0402B5D0 RID: 177616
		public const int IconTexture = 3;

		// Token: 0x0402B5D1 RID: 177617
		public const int CardRaceItem = 4;

		// Token: 0x0402B5D2 RID: 177618
		public const int CardRaceIcon = 5;

		// Token: 0x0402B5D3 RID: 177619
		public const int CardRace = 6;

		// Token: 0x0402B5D4 RID: 177620
		public const int SalaryItem = 7;

		// Token: 0x0402B5D5 RID: 177621
		public const int BasicSalaryIconTexture = 8;

		// Token: 0x0402B5D6 RID: 177622
		public const int Salary = 9;

		// Token: 0x0402B5D7 RID: 177623
		public const int TagDesc = 10;

		// Token: 0x0402B5D8 RID: 177624
		public const int BuffPanel = 11;

		// Token: 0x0402B5D9 RID: 177625
		public const int BuffLayout = 12;

		// Token: 0x0402B5DA RID: 177626
		public const int BuffItem = 13;

		// Token: 0x0402B5DB RID: 177627
		public const int DeleteButton = 14;

		// Token: 0x0402B5DC RID: 177628
		public const int DeleteIconTexture = 15;

		// Token: 0x0402B5DD RID: 177629
		public const int DeleteNumber = 16;

		// Token: 0x0402B5DE RID: 177630
		public const int DeleteButtonText = 17;

		// Token: 0x0402B5DF RID: 177631
		public const int QualityTexture = 18;

		// Token: 0x0402B5E0 RID: 177632
		public const int QualityBTexture = 19;

		// Token: 0x0402B5E1 RID: 177633
		public const int PhantomIconItem = 20;

		// Token: 0x0402B5E2 RID: 177634
		public const int ToyRaceItem = 21;

		// Token: 0x0402B5E3 RID: 177635
		public const int ToyRaceIcon = 22;

		// Token: 0x0402B5E4 RID: 177636
		public const int ScrollView = 23;

		// Token: 0x0402B5E5 RID: 177637
		public const int Toggle = 24;

		// Token: 0x0402B5E6 RID: 177638
		public const int ToyLevelText = 25;

		// Token: 0x0402B5E7 RID: 177639
		public const int NoSellItem = 26;
	}
}
