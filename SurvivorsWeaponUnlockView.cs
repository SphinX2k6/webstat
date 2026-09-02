using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002B64 RID: 11108
public class SurvivorsWeaponUnlockView : UiViewBase
{
	// Token: 0x0601623B RID: 90683 RVA: 0x00624F3B File Offset: 0x0062313B
	[NullableContext(1)]
	public SurvivorsWeaponUnlockView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0601623C RID: 90684 RVA: 0x00624F44 File Offset: 0x00623144
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIText)),
			new ValueTuple<int, Type>(5, typeof(UUIScrollViewWithScrollbarComponent))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action(this.OnClickClose))
		};
	}

	// Token: 0x0601623D RID: 90685 RVA: 0x00625004 File Offset: 0x00623204
	protected override void OnStart()
	{
		if (ModelBase<SurvivorsRogueModel>.Instance.ActivityData == null)
		{
			base.CloseMe(null);
			return;
		}
		int[] array = this.OpenParam as int[];
		this.ScrollView = new GenericScrollViewNew<CardScrollItem, int>(base.GetScrollViewWithScrollbar(5), () => new CardScrollItem(), null, true, null);
		if (array != null)
		{
			this.ScrollView.RefreshByData(array.ToList<int>(), null, false);
		}
	}

	// Token: 0x0601623E RID: 90686 RVA: 0x0062507B File Offset: 0x0062327B
	private void OnClickClose()
	{
		base.CloseMe(null);
	}

	// Token: 0x0400AB13 RID: 43795
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericScrollViewNew<CardScrollItem, int> ScrollView;
}
