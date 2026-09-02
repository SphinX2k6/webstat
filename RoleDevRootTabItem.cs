using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02002803 RID: 10243
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class RoleDevRootTabItem : GridProxyAbstract<IRoleDevRootTabData>
{
	// Token: 0x06014386 RID: 82822 RVA: 0x005A1B14 File Offset: 0x0059FD14
	protected unsafe override void OnRegisterComponent()
	{
		int num = 4;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickToggle));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06014387 RID: 82823 RVA: 0x005A1BFC File Offset: 0x0059FDFC
	public override void Refresh(IRoleDevRootTabData data, bool isSelected, int gridIndex)
	{
		this.TabIndexInternal = gridIndex;
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), data.TabName, Array.Empty<object>());
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle != null)
		{
			extendToggle.SetToggleState(isSelected ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
		}
		UUIItem item = base.GetItem(2);
		if (item != null)
		{
			item.SetUIActive(data.TabIsUpgrade);
		}
		UUIItem item2 = base.GetItem(3);
		if (item2 == null)
		{
			return;
		}
		item2.SetUIActive(data.TabIsFinish);
	}

	// Token: 0x17001A02 RID: 6658
	// (get) Token: 0x06014388 RID: 82824 RVA: 0x005A1C78 File Offset: 0x0059FE78
	public int TabIndex
	{
		get
		{
			return this.TabIndexInternal;
		}
	}

	// Token: 0x06014389 RID: 82825 RVA: 0x005A1C80 File Offset: 0x0059FE80
	public override void OnSelected(bool fireEvent)
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle == null)
		{
			return;
		}
		extendToggle.SetToggleState(EToggleState.ETT_Checked, fireEvent, false, false);
	}

	// Token: 0x0601438A RID: 82826 RVA: 0x005A1C98 File Offset: 0x0059FE98
	public override void OnDeselected(bool fireEvent)
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle == null)
		{
			return;
		}
		extendToggle.SetToggleState(EToggleState.ETT_UnChecked, fireEvent, false, false);
	}

	// Token: 0x0601438B RID: 82827 RVA: 0x005A1CB0 File Offset: 0x0059FEB0
	public override object GetKey(IRoleDevRootTabData data, int gridIndex)
	{
		return gridIndex;
	}

	// Token: 0x0601438C RID: 82828 RVA: 0x005A1CB8 File Offset: 0x0059FEB8
	protected override void OnStart()
	{
		base.GetExtendToggle(0).CanExecuteChange.Bind(new Func<bool>(this.OnCanExecuteChange));
	}

	// Token: 0x0601438D RID: 82829 RVA: 0x005A1CD7 File Offset: 0x0059FED7
	public void SetToggleState(EToggleState state, bool fireEvent = false)
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle == null)
		{
			return;
		}
		extendToggle.SetToggleState(state, fireEvent, false, false);
	}

	// Token: 0x0601438E RID: 82830 RVA: 0x005A1CEF File Offset: 0x0059FEEF
	public EToggleState GetToggleState()
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle == null)
		{
			return EToggleState.ETT_UnChecked;
		}
		return extendToggle.GetToggleState();
	}

	// Token: 0x0601438F RID: 82831 RVA: 0x005A1D03 File Offset: 0x0059FF03
	protected void OnClickToggle(EToggleState state)
	{
		if (state == EToggleState.ETT_Checked)
		{
			Action<int> onClickToggleCallBack = this.OnClickToggleCallBack;
			if (onClickToggleCallBack == null)
			{
				return;
			}
			onClickToggleCallBack(this.TabIndex);
		}
	}

	// Token: 0x06014390 RID: 82832 RVA: 0x005A1D1F File Offset: 0x0059FF1F
	private bool OnCanExecuteChange()
	{
		Func<int, EToggleState, bool> canClickCallBack = this.CanClickCallBack;
		return canClickCallBack == null || canClickCallBack(this.TabIndex, this.GetToggleState());
	}

	// Token: 0x04009D66 RID: 40294
	private int TabIndexInternal;

	// Token: 0x04009D67 RID: 40295
	[Nullable(2)]
	public Action<int> OnClickToggleCallBack;

	// Token: 0x04009D68 RID: 40296
	[Nullable(2)]
	public Func<int, EToggleState, bool> CanClickCallBack;

	// Token: 0x02008B95 RID: 35733
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402F0AE RID: 192686
		Toggle,
		// Token: 0x0402F0AF RID: 192687
		TabName,
		// Token: 0x0402F0B0 RID: 192688
		ItemUp,
		// Token: 0x0402F0B1 RID: 192689
		ItemFinish
	}
}
