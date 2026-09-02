using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002C08 RID: 11272
public class TowerUnlockView : UiViewBase
{
	// Token: 0x060167CB RID: 92107 RVA: 0x006401FA File Offset: 0x0063E3FA
	[NullableContext(1)]
	public TowerUnlockView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x060167CC RID: 92108 RVA: 0x00640204 File Offset: 0x0063E404
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickedCloseButton));
		this.BtnBindInfo = list2;
	}

	// Token: 0x060167CD RID: 92109 RVA: 0x006402AA File Offset: 0x0063E4AA
	private void OnClickedCloseButton()
	{
		if (!this.CanClick)
		{
			return;
		}
		base.CloseMe(null);
	}

	// Token: 0x060167CE RID: 92110 RVA: 0x006402BC File Offset: 0x0063E4BC
	protected override void OnStart()
	{
		int num = (int)this.OpenParam;
		if (num == 4)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), "PrefabTextItem_2260577568_Text", Array.Empty<object>());
			return;
		}
		string newTowerDifficultTitle = ConfigBase<TowerClimbConfig>.Instance.GetNewTowerDifficultTitle(num);
		UUIText text = base.GetText(1);
		if (text == null)
		{
			return;
		}
		text.SetText(newTowerDifficultTitle, true);
	}

	// Token: 0x060167CF RID: 92111 RVA: 0x00640314 File Offset: 0x0063E514
	protected override void OnAfterPlayStartSequence()
	{
		this.CanClick = true;
	}

	// Token: 0x0400ADFC RID: 44540
	private bool CanClick;

	// Token: 0x02008F06 RID: 36614
	private enum EChildType
	{
		// Token: 0x040300B1 RID: 196785
		BtnMask,
		// Token: 0x040300B2 RID: 196786
		TxtTitle
	}
}
