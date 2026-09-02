using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002C07 RID: 11271
public class TowerTitleItem : UiPanelBase
{
	// Token: 0x060167C5 RID: 92101 RVA: 0x006400C3 File Offset: 0x0063E2C3
	[NullableContext(1)]
	public TowerTitleItem(UUIItem uiItem, [Nullable(2)] Action onClickBackBtnHandle)
	{
		this.OnClickBackBtnHandle = onClickBackBtnHandle;
		base.CreateThenShowByActor(uiItem.GetOwner(), null);
	}

	// Token: 0x060167C6 RID: 92102 RVA: 0x006400E0 File Offset: 0x0063E2E0
	protected unsafe override void OnRegisterComponent()
	{
		int num = 4;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnClickBackBtn));
		this.BtnBindInfo = list2;
	}

	// Token: 0x060167C7 RID: 92103 RVA: 0x006401C8 File Offset: 0x0063E3C8
	protected override void OnStart()
	{
	}

	// Token: 0x060167C8 RID: 92104 RVA: 0x006401CA File Offset: 0x0063E3CA
	[NullableContext(1)]
	public void RefreshText(string textId, params string[] arg)
	{
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), textId, arg);
	}

	// Token: 0x060167C9 RID: 92105 RVA: 0x006401DF File Offset: 0x0063E3DF
	private void OnClickBackBtn()
	{
		Action onClickBackBtnHandle = this.OnClickBackBtnHandle;
		if (onClickBackBtnHandle == null)
		{
			return;
		}
		onClickBackBtnHandle();
	}

	// Token: 0x060167CA RID: 92106 RVA: 0x006401F1 File Offset: 0x0063E3F1
	protected override void OnBeforeDestroy()
	{
		this.OnClickBackBtnHandle = null;
	}

	// Token: 0x0400ADFB RID: 44539
	[Nullable(2)]
	private Action OnClickBackBtnHandle;

	// Token: 0x02008F05 RID: 36613
	private enum EChildType
	{
		// Token: 0x040300AC RID: 196780
		TitleSprite,
		// Token: 0x040300AD RID: 196781
		TitleText,
		// Token: 0x040300AE RID: 196782
		HelpBtn,
		// Token: 0x040300AF RID: 196783
		BackBtn
	}
}
