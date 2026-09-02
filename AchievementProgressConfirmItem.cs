using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02000FE6 RID: 4070
public class AchievementProgressConfirmItem : UiPanelBase
{
	// Token: 0x06006908 RID: 26888 RVA: 0x001B60A4 File Offset: 0x001B42A4
	[NullableContext(1)]
	public AchievementProgressConfirmItem(UUIItem uiItem)
	{
		base.CreateThenShowByActor(uiItem.GetOwner(), null);
	}

	// Token: 0x06006909 RID: 26889 RVA: 0x001B60BC File Offset: 0x001B42BC
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickButton));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600690A RID: 26890 RVA: 0x001B6162 File Offset: 0x001B4362
	[NullableContext(1)]
	public void SetClickCallback(Action call)
	{
		this.OnClickCallback = call;
	}

	// Token: 0x0600690B RID: 26891 RVA: 0x001B616B File Offset: 0x001B436B
	private void OnClickButton()
	{
		Action onClickCallback = this.OnClickCallback;
		if (onClickCallback == null)
		{
			return;
		}
		onClickCallback();
	}

	// Token: 0x0600690C RID: 26892 RVA: 0x001B617D File Offset: 0x001B437D
	public void RefreshRedPoint(bool value)
	{
		base.GetItem(1).SetUIActive(value);
	}

	// Token: 0x040031EF RID: 12783
	[Nullable(2)]
	private Action OnClickCallback;

	// Token: 0x020073C4 RID: 29636
	private enum EComponents
	{
		// Token: 0x040280E7 RID: 164071
		ConfirmBtn,
		// Token: 0x040280E8 RID: 164072
		RedDot
	}
}
