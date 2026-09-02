using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x0200199E RID: 6558
public class TipsGetWayItem : UiPanelBase
{
	// Token: 0x0600BC50 RID: 48208 RVA: 0x0031FADA File Offset: 0x0031DCDA
	[NullableContext(1)]
	public TipsGetWayItem(UUIItem uiItem, IGetWayItemData data)
	{
		this.Data = data;
		base.CreateThenShowByActor(uiItem.GetOwner(), null);
	}

	// Token: 0x0600BC51 RID: 48209 RVA: 0x0031FAF8 File Offset: 0x0031DCF8
	protected unsafe override void OnRegisterComponent()
	{
		int num = 4;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		this.ComponentRegisterInfos = list;
		num2 = 2;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnButtonClicked));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.OnButtonClicked));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600BC52 RID: 48210 RVA: 0x0031FC04 File Offset: 0x0031DE04
	protected override void OnStart()
	{
		this.ButtonFunction = this.Data.Function;
		EGetWayItemType type = this.Data.Type;
		if (type != EGetWayItemType.Locked)
		{
			if (type == EGetWayItemType.CanJump)
			{
				base.GetButton(0).RootUIComp.Get().SetUIActive(true);
				base.GetButton(1).RootUIComp.Get().SetUIActive(false);
				base.GetText(2).ShowTextNew(this.Data.Text);
				return;
			}
		}
		else
		{
			base.GetButton(0).RootUIComp.Get().SetUIActive(false);
			base.GetButton(1).RootUIComp.Get().SetUIActive(true);
			base.GetText(3).ShowTextNew(this.Data.Text);
		}
	}

	// Token: 0x0600BC53 RID: 48211 RVA: 0x0031FCD0 File Offset: 0x0031DED0
	protected override void OnBeforeDestroy()
	{
		this.Data = null;
		this.ButtonFunction = null;
	}

	// Token: 0x0600BC54 RID: 48212 RVA: 0x0031FCE0 File Offset: 0x0031DEE0
	private void OnButtonClicked()
	{
		if (this.ButtonFunction != null)
		{
			this.ButtonFunction();
		}
	}

	// Token: 0x04005922 RID: 22818
	[Nullable(2)]
	private IGetWayItemData Data;

	// Token: 0x04005923 RID: 22819
	[Nullable(2)]
	private Action ButtonFunction;

	// Token: 0x02007CA2 RID: 31906
	private class EGetWayItemNode
	{
		// Token: 0x0402A8DA RID: 174298
		public const int BtnLink = 0;

		// Token: 0x0402A8DB RID: 174299
		public const int BtnLocked = 1;

		// Token: 0x0402A8DC RID: 174300
		public const int TxtLink = 2;

		// Token: 0x0402A8DD RID: 174301
		public const int TxtLocked = 3;
	}
}
