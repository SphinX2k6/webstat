using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020011D9 RID: 4569
public class BabelTowerBuffStarAndDescItem : UiPanelBase
{
	// Token: 0x0600789B RID: 30875 RVA: 0x001F9A44 File Offset: 0x001F7C44
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600789C RID: 30876 RVA: 0x001F9AAD File Offset: 0x001F7CAD
	[NullableContext(1)]
	public void Refresh(string starText, bool showStar, string descTextId)
	{
		base.GetText(0).SetUIActive(showStar);
		if (showStar)
		{
			base.GetText(0).SetText(starText, true);
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), descTextId, Array.Empty<object>());
	}

	// Token: 0x02007535 RID: 30005
	private class EComponents
	{
		// Token: 0x04028750 RID: 165712
		public const int StarNumText = 0;

		// Token: 0x04028751 RID: 165713
		public const int DescText = 1;
	}
}
