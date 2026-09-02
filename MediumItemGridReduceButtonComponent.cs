using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using UnrealEngine;

// Token: 0x020019D7 RID: 6615
[NullableContext(2)]
[Nullable(0)]
public class MediumItemGridReduceButtonComponent : MediumItemGridComponent
{
	// Token: 0x0600BDBF RID: 48575 RVA: 0x003247D8 File Offset: 0x003229D8
	protected unsafe override void OnRegisterComponent()
	{
		int num = 1;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickedReduceButton));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600BDC0 RID: 48576 RVA: 0x0032485D File Offset: 0x00322A5D
	[NullableContext(1)]
	protected override string GetResourceId()
	{
		return "UiItem_ItemBtnReduce";
	}

	// Token: 0x0600BDC1 RID: 48577 RVA: 0x00324864 File Offset: 0x00322A64
	protected override void OnInitialize()
	{
		this.LongPressButton = new LongPressButtonItem(null, null, null);
	}

	// Token: 0x0600BDC2 RID: 48578 RVA: 0x00324890 File Offset: 0x00322A90
	protected override void OnStart()
	{
		UUIButtonComponent button = base.GetButton(0);
		LongPressButtonItem longPressButton = this.LongPressButton;
		if (longPressButton == null)
		{
			return;
		}
		longPressButton.Initialize(button, new Action<bool>(this.OnLongPressActive), null, null, null);
	}

	// Token: 0x0600BDC3 RID: 48579 RVA: 0x003248CC File Offset: 0x00322ACC
	protected override void OnDeactivate()
	{
		UUIButtonComponent button = base.GetButton(0);
		if (button != null)
		{
			button.OnPointDownCallBack.Unbind();
		}
		if (button != null)
		{
			button.OnPointUpCallBack.Unbind();
		}
		LongPressButtonItem longPressButton = this.LongPressButton;
		if (longPressButton != null)
		{
			longPressButton.Clear();
		}
		this.LongPressButton = null;
		this.LongPressConfigId = null;
		this.OnClickedCallback = null;
	}

	// Token: 0x0600BDC4 RID: 48580 RVA: 0x0032492C File Offset: 0x00322B2C
	protected override void OnRefresh(object data)
	{
		LongPressButton longPressButton = data as LongPressButton;
		if (longPressButton == null)
		{
			return;
		}
		bool? isVisible = longPressButton.IsVisible;
		LongPressButtonItem.ELongPressConfigId? longPressConfigId = longPressButton.LongPressConfigId;
		this.LongPressConfigId = longPressConfigId;
		this.SetActive(isVisible.GetValueOrDefault());
		if (this.LongPressConfigId != null && this.LongPressButton != null && !this.LongPressButton.IsActivate())
		{
			this.LongPressButton.Activate(this.LongPressConfigId.Value);
		}
	}

	// Token: 0x0600BDC5 RID: 48581 RVA: 0x0032499E File Offset: 0x00322B9E
	private void OnLongPressActive(bool isShortPress)
	{
		Action<bool> onLongPressClickCallback = this.OnLongPressClickCallback;
		if (onLongPressClickCallback == null)
		{
			return;
		}
		onLongPressClickCallback(isShortPress);
	}

	// Token: 0x0600BDC6 RID: 48582 RVA: 0x003249B1 File Offset: 0x00322BB1
	[NullableContext(1)]
	public void BindReduceButtonCallback(Action onClickedReduceButton)
	{
		this.OnClickedCallback = onClickedReduceButton;
	}

	// Token: 0x0600BDC7 RID: 48583 RVA: 0x003249BA File Offset: 0x00322BBA
	public void UnBindReduceButtonCallback()
	{
		this.OnClickedCallback = null;
	}

	// Token: 0x0600BDC8 RID: 48584 RVA: 0x003249C3 File Offset: 0x00322BC3
	[NullableContext(1)]
	public void BindLongPressCallback(Action<bool> callback)
	{
		this.OnLongPressClickCallback = callback;
	}

	// Token: 0x0600BDC9 RID: 48585 RVA: 0x003249CC File Offset: 0x00322BCC
	public void UnBindLongPressCallback()
	{
		this.OnLongPressClickCallback = null;
		LongPressButtonItem longPressButton = this.LongPressButton;
		if (longPressButton == null)
		{
			return;
		}
		longPressButton.Deactivate();
	}

	// Token: 0x0600BDCA RID: 48586 RVA: 0x003249E5 File Offset: 0x00322BE5
	private void OnClickedReduceButton()
	{
		Action onClickedCallback = this.OnClickedCallback;
		if (onClickedCallback == null)
		{
			return;
		}
		onClickedCallback();
	}

	// Token: 0x0600BDCB RID: 48587 RVA: 0x003249F7 File Offset: 0x00322BF7
	public UUIButtonComponent GetReduceButton()
	{
		return base.GetButton(0);
	}

	// Token: 0x04005969 RID: 22889
	private Action OnClickedCallback;

	// Token: 0x0400596A RID: 22890
	private LongPressButtonItem LongPressButton;

	// Token: 0x0400596B RID: 22891
	private Action<bool> OnLongPressClickCallback;

	// Token: 0x0400596C RID: 22892
	private LongPressButtonItem.ELongPressConfigId? LongPressConfigId;

	// Token: 0x02007CCB RID: 31947
	[NullableContext(0)]
	private class EChildType
	{
		// Token: 0x0402A983 RID: 174467
		public const int ReduceButton = 0;
	}
}
