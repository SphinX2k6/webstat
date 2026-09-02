using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001CE4 RID: 7396
[NullableContext(1)]
[Nullable(0)]
public class GachaButton : UiPanelBase
{
	// Token: 0x0600D8F8 RID: 55544 RVA: 0x003A18EA File Offset: 0x0039FAEA
	public GachaButton(int times)
	{
		this.Times = times;
	}

	// Token: 0x0600D8F9 RID: 55545 RVA: 0x003A18FC File Offset: 0x0039FAFC
	protected unsafe override void OnRegisterComponent()
	{
		int num = 10;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.GachaBtn));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600D8FA RID: 55546 RVA: 0x003A1AAC File Offset: 0x0039FCAC
	private void GachaBtn()
	{
		ProtoGachaInfo gachaInfo = this.GachaPoolData.GachaInfo;
		if (gachaInfo == null)
		{
			return;
		}
		if (gachaInfo.UsePoolId == 0)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("GachaNoOption", Array.Empty<object>());
			return;
		}
		if (this.LastOpenTime != 0.0 && Singleton<Time>.Instance.Now - this.LastOpenTime <= 1000.0)
		{
			return;
		}
		this.LastOpenTime = Singleton<Time>.Instance.Now;
		ValueTuple<bool, EConfirmBoxConfigId?> valueTuple = ModelBase<GachaModel>.Instance.CheckCountIsEnough(gachaInfo, this.Times);
		if (!valueTuple.Item1)
		{
			EConfirmBoxConfigId? item = valueTuple.Item2;
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(item.Value);
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
			return;
		}
		int commonItemCount = ModelBase<InventoryModel>.Instance.GetCommonItemCount(gachaInfo.ItemId, 0);
		if (gachaInfo.Id == 5 && commonItemCount <= 0)
		{
			ConfirmBoxDataNew confirmBoxDataNew2 = new ConfirmBoxDataNew(EConfirmBoxConfigId.GachaJumpToMail);
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew2);
			return;
		}
		int num = this.ConsumeCount - commonItemCount;
		if (num <= 0)
		{
			ControllerBase<GachaController>.Instance.GachaRequest(gachaInfo.Id, this.Times, this.GachaPoolData.PoolInfo.Id);
			return;
		}
		ExchangeSimulation exchangeSimulation = ModelBase<ItemExchangeModel>.Instance.CalculateConsume(gachaInfo.ItemId, num, 0, true);
		if (exchangeSimulation == null)
		{
			return;
		}
		CommonExchangeData exchangeData = new CommonExchangeData();
		exchangeData.InitByItemId(gachaInfo.ItemId);
		if (ConfigBase<CommonConfig>.Instance.GetBetaBlockRecharge().GetValueOrDefault())
		{
			ConfirmBoxDataNew confirmBoxDataNew3 = new ConfirmBoxDataNew(EConfirmBoxConfigId.BetaDisableGacha);
			confirmBoxDataNew3.SetTextArgs(new string[]
			{
				exchangeData.GetDestName()
			});
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew3);
			return;
		}
		ConfirmBoxDataNew confirmBoxDataNew4 = new ConfirmBoxDataNew(EConfirmBoxConfigId.GachaCurrency);
		confirmBoxDataNew4.SetTextArgs(new string[]
		{
			num.ToString(),
			exchangeData.GetDestName(),
			exchangeSimulation.ConsumeCount.ToString(),
			exchangeData.GetSrcName()
		});
		confirmBoxDataNew4.FunctionMap.Add(2, delegate
		{
			this.ExChangeSecondCurrency(exchangeData, exchangeSimulation.ExChangeTime, exchangeSimulation.ConsumeCount);
		});
		ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew4);
	}

	// Token: 0x0600D8FB RID: 55547 RVA: 0x003A1CE0 File Offset: 0x0039FEE0
	private void ExChangeSecondCurrency(CommonExchangeData exchangeData, int exChangeTime, int needSecondCount)
	{
		int commonItemCount = ModelBase<InventoryModel>.Instance.GetCommonItemCount(exchangeData.GetSrcItemId(), 0);
		if (commonItemCount >= needSecondCount)
		{
			ControllerBase<ItemExchangeController>.Instance.ItemExchangeRequest(exchangeData.GetDestItemId(), exChangeTime, false, delegate(int itemId, int itemCount)
			{
				if (ModelBase<InventoryModel>.Instance.GetCommonItemCount(exchangeData.GetDestItemId(), 0) >= exChangeTime)
				{
					ControllerBase<GachaController>.Instance.GachaRequest(this.GachaPoolData.GachaInfo.Id, this.Times, this.GachaPoolData.PoolInfo.Id);
				}
			});
			return;
		}
		ExchangeSimulation exchangeSimulation = ModelBase<ItemExchangeModel>.Instance.CalculateConsume(exchangeData.GetSrcItemId(), needSecondCount - commonItemCount, 0, true);
		if (exchangeSimulation == null)
		{
			return;
		}
		CommonExchangeData nextExchangeData = new CommonExchangeData();
		nextExchangeData.InitByItemId(exchangeData.GetSrcItemId());
		ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.SecondCurrency);
		confirmBoxDataNew.SetTextArgs(new string[]
		{
			nextExchangeData.GetDestName(),
			nextExchangeData.GetSrcName(),
			nextExchangeData.GetDestName()
		});
		confirmBoxDataNew.FunctionMap.Add(2, delegate
		{
			this.ExChangeFirstCurrency(nextExchangeData, exchangeSimulation.ExChangeTime, exchangeSimulation.ConsumeCount);
		});
		ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
	}

	// Token: 0x0600D8FC RID: 55548 RVA: 0x003A1DF8 File Offset: 0x0039FFF8
	private void ExChangeFirstCurrency(CommonExchangeData exchangeData, int exChangeTime, int needSecondCount)
	{
		if (ModelBase<InventoryModel>.Instance.GetCommonItemCount(exchangeData.GetSrcItemId(), 0) >= needSecondCount)
		{
			ControllerBase<ItemExchangeController>.Instance.ItemExchangeRequest(exchangeData.GetDestItemId(), exChangeTime, true, null);
			return;
		}
		ControllerBase<ConfirmBoxController>.Instance.ShowFirstCurrencyConfirm();
	}

	// Token: 0x0600D8FD RID: 55549 RVA: 0x003A1E2C File Offset: 0x003A002C
	protected override UniTask OnBeforeStartAsync()
	{
		GachaButton.<OnBeforeStartAsync>d__13 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<GachaButton.<OnBeforeStartAsync>d__13>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600D8FE RID: 55550 RVA: 0x003A1E70 File Offset: 0x003A0070
	public void Refresh(GachaPoolData data, EffectiveGachaButtonInfo buttonInfo)
	{
		this.GachaPoolData = data;
		this.ConsumeCount = buttonInfo.Consume;
		ProtoGachaInfo gachaInfo = data.GachaInfo;
		if (ConfigBase<InventoryConfig>.Instance.GetItemConfigData(gachaInfo.ItemId) == null)
		{
			return;
		}
		base.SetItemIcon(base.GetTexture(1), gachaInfo.ItemId, null, null);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), "Text_GachaExChangeCountDescribe_Text", new <>z__ReadOnlySingleElementList<object>(this.ConsumeCount));
		Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(3), "GachaText", new <>z__ReadOnlySingleElementList<object>(this.Times.ToString()));
		if (buttonInfo.IsDiscount && buttonInfo.OriginConsume != null)
		{
			base.GetItem(7).SetUIActive(true);
			base.GetText(8).SetText(buttonInfo.OriginConsume.Value.ToString(), true);
		}
		else
		{
			base.GetItem(7).SetUIActive(false);
		}
		int id = data.PoolInfo.Id;
		GachaDefine.EGachaViewType? gachaViewType = ConfigBase<GachaConfig>.Instance.GetGachaViewType(id);
		if (gachaViewType.GetValueOrDefault() == GachaDefine.EGachaViewType.NewPlayer)
		{
			GachaViewTypeInfo? gachaViewTypeConfig = ConfigBase<GachaConfig>.Instance.GetGachaViewTypeConfig((int)gachaViewType.Value);
			base.GetItem(4).SetUIActive(true);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), gachaViewTypeConfig.Value.TagText, Array.Empty<object>());
			FColor color = FColor.FromHex(gachaViewTypeConfig.Value.TagColor);
			base.GetSprite(6).SetColor(color);
		}
		else
		{
			base.GetItem(4).SetUIActive(false);
		}
		this.RefreshTag(buttonInfo);
		if (gachaViewType.GetValueOrDefault() == GachaDefine.EGachaViewType.NewPlayer)
		{
			base.GetItem(9).SetUIActive(true);
		}
	}

	// Token: 0x0600D8FF RID: 55551 RVA: 0x003A2020 File Offset: 0x003A0220
	private void RefreshTag(EffectiveGachaButtonInfo buttonInfo)
	{
		UUIItem item = base.GetItem(9);
		GachaTagInfo customTag = buttonInfo.GetCustomTag();
		if (customTag != null)
		{
			item.SetUIActive(true);
			this.TagItemA.SetUiActive(false);
			this.TagItemB.SetUiActive(true);
			this.TagItemB.SetContent(customTag.Text);
			return;
		}
		this.TagItemB.SetUiActive(false);
		GachaTagInfo discountTag = buttonInfo.GetDiscountTag();
		if (discountTag == null)
		{
			this.TagItemA.SetUiActive(false);
			item.SetUIActive(false);
			return;
		}
		item.SetUIActive(true);
		this.TagItemA.SetUiActive(true);
		if (discountTag.Kind == EGachaTagKind.Free)
		{
			this.TagItemA.SetLocalText("SaleTag_1", Array.Empty<object>());
			return;
		}
		this.TagItemA.SetLocalText("SaleTag_2", new object[]
		{
			discountTag.DiscountPct.Value
		});
	}

	// Token: 0x0400679A RID: 26522
	private const long CLICKCD = 1000L;

	// Token: 0x0400679B RID: 26523
	[Nullable(2)]
	private GachaPoolData GachaPoolData;

	// Token: 0x0400679C RID: 26524
	public readonly int Times;

	// Token: 0x0400679D RID: 26525
	private int ConsumeCount;

	// Token: 0x0400679E RID: 26526
	private double LastOpenTime;

	// Token: 0x0400679F RID: 26527
	[Nullable(2)]
	private GachaDiscountTagItem TagItemA;

	// Token: 0x040067A0 RID: 26528
	[Nullable(2)]
	private GachaDiscountTagItem TagItemB;

	// Token: 0x02008035 RID: 32821
	[NullableContext(0)]
	private enum EGachaButton
	{
		// Token: 0x0402B9D0 RID: 178640
		GachaBtn,
		// Token: 0x0402B9D1 RID: 178641
		ConsumeTexture,
		// Token: 0x0402B9D2 RID: 178642
		ConsumeText,
		// Token: 0x0402B9D3 RID: 178643
		GachaText,
		// Token: 0x0402B9D4 RID: 178644
		DiscountItem,
		// Token: 0x0402B9D5 RID: 178645
		DiscountText,
		// Token: 0x0402B9D6 RID: 178646
		DiscountSprite,
		// Token: 0x0402B9D7 RID: 178647
		PanelNum02,
		// Token: 0x0402B9D8 RID: 178648
		TextNum02,
		// Token: 0x0402B9D9 RID: 178649
		PanelTag
	}
}
