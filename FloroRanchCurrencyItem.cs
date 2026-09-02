using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001C51 RID: 7249
public class FloroRanchCurrencyItem : UiPanelBase
{
	// Token: 0x0600D38B RID: 54155 RVA: 0x00386508 File Offset: 0x00384708
	protected unsafe override void OnRegisterComponent()
	{
		int num = 4;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITextureTransitionComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600D38C RID: 54156 RVA: 0x003865F0 File Offset: 0x003847F0
	[NullableContext(1)]
	public void SetCurrencyData(FloroRanchCurrencyData currencyData)
	{
		this.CurrencyData = currencyData;
		UUITexture texture = base.GetTexture(0);
		base.SetTextureByPath(this.CurrencyData.GetIconPath(), texture, null, delegate(bool _)
		{
			this.SetTextureAllTransition();
		});
		int amount = this.CurrencyData.GetAmount();
		base.GetText(2).SetText(ModelBase<FloroRanchModel>.Instance.GetCoinText(amount), true);
	}

	// Token: 0x0600D38D RID: 54157 RVA: 0x00386658 File Offset: 0x00384858
	private void SetTextureAllTransition()
	{
		UUITextureTransitionComponent uiTextureTransitionComponent = base.GetUiTextureTransitionComponent(1);
		if (uiTextureTransitionComponent != null)
		{
			uiTextureTransitionComponent.SetAllStateTexture(base.GetTexture(0).GetTexture());
		}
	}

	// Token: 0x0600D38E RID: 54158 RVA: 0x00386684 File Offset: 0x00384884
	private void OnClick()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.FloroRanchCommonTipsView, new FloroRanchCommonTipParam
		{
			TipType = EFloroRanchCommonTipType.Currency,
			CurrencyData = this.CurrencyData,
			RemoveCallback = null,
			EntityData = null,
			ToyData = null,
			CardData = null
		}, null);
	}

	// Token: 0x040064BA RID: 25786
	[Nullable(1)]
	private FloroRanchCurrencyData CurrencyData;

	// Token: 0x02007F61 RID: 32609
	private class EComponentDefine
	{
		// Token: 0x0402B5EC RID: 177644
		public const int Texture = 0;

		// Token: 0x0402B5ED RID: 177645
		public const int TextureTransition = 1;

		// Token: 0x0402B5EE RID: 177646
		public const int CountText = 2;

		// Token: 0x0402B5EF RID: 177647
		public const int Button = 3;
	}
}
