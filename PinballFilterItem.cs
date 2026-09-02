using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x0200191C RID: 6428
[NullableContext(1)]
[Nullable(0)]
public class PinballFilterItem : UiPanelBase
{
	// Token: 0x0600B8E7 RID: 47335 RVA: 0x00312999 File Offset: 0x00310B99
	public PinballFilterItem(UUIItem uiItem)
	{
		base.CreateThenShowByActor(uiItem.GetOwner(), null);
	}

	// Token: 0x0600B8E8 RID: 47336 RVA: 0x003129B0 File Offset: 0x00310BB0
	protected unsafe override void OnRegisterComponent()
	{
		int num = 3;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(1, new Action<EToggleState>(this.ToggleEvent));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600B8E9 RID: 47337 RVA: 0x00312A77 File Offset: 0x00310C77
	private void ToggleEvent(EToggleState state)
	{
		TFilterItemToggleEvent toggleFunction = this.ToggleFunction;
		if (toggleFunction == null)
		{
			return;
		}
		toggleFunction(state, this.Data.FilterId, this.Data.Content);
	}

	// Token: 0x0600B8EA RID: 47338 RVA: 0x00312AA0 File Offset: 0x00310CA0
	private void SetContent()
	{
		string content = this.Data.Content;
		base.GetText(0).SetText(content, true);
	}

	// Token: 0x0600B8EB RID: 47339 RVA: 0x00312AC8 File Offset: 0x00310CC8
	private void SetIcon()
	{
		FilterItemData data = this.Data;
		string text = (data != null) ? data.GetIconPath() : null;
		this.Icon = new PinballFilterIconView();
		this.Icon.CreateThenShowByActor(base.GetItem(2).GetOwner(), null);
		if (!StringUtils.IsBlank(text))
		{
			PinballFilterIconView icon = this.Icon;
			if (icon != null)
			{
				icon.SetIcon(true, text);
			}
			PinballFilterIconView icon2 = this.Icon;
			if (icon2 == null)
			{
				return;
			}
			icon2.SetBgChangeColor(false, null);
			return;
		}
		else
		{
			PinballFilterIconView icon3 = this.Icon;
			if (icon3 != null)
			{
				icon3.SetIcon(false, "");
			}
			PinballFilterIconView icon4 = this.Icon;
			if (icon4 == null)
			{
				return;
			}
			icon4.SetBgChangeColor(true, new FColor?(FColor.FromHex(this.Data.ChangeColor)));
			return;
		}
	}

	// Token: 0x0600B8EC RID: 47340 RVA: 0x00312B7E File Offset: 0x00310D7E
	public void SetToggleFunction(TFilterItemToggleEvent toggleFunction)
	{
		this.ToggleFunction = toggleFunction;
	}

	// Token: 0x0600B8ED RID: 47341 RVA: 0x00312B88 File Offset: 0x00310D88
	public void SetToggleState(bool bSelected)
	{
		EToggleState state = bSelected ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
		base.GetExtendToggle(1).SetToggleState(state, false, false, false);
	}

	// Token: 0x0600B8EE RID: 47342 RVA: 0x00312BAE File Offset: 0x00310DAE
	public void ShowTemp(FilterItemData data, bool bSelected)
	{
		this.Data = data;
		this.SetContent();
		this.SetIcon();
		this.SetToggleState(bSelected);
	}

	// Token: 0x04005703 RID: 22275
	[Nullable(2)]
	private FilterItemData Data;

	// Token: 0x04005704 RID: 22276
	[Nullable(2)]
	private TFilterItemToggleEvent ToggleFunction;

	// Token: 0x04005705 RID: 22277
	[Nullable(2)]
	private PinballFilterIconView Icon;

	// Token: 0x02007C6F RID: 31855
	[NullableContext(0)]
	private enum EPinballFilterItemComponent
	{
		// Token: 0x0402A7F8 RID: 174072
		Name,
		// Token: 0x0402A7F9 RID: 174073
		Toggle,
		// Token: 0x0402A7FA RID: 174074
		Icon
	}
}
