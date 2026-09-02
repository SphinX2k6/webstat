using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020023D4 RID: 9172
public class PayShopAccumulateItem : UiPanelBase
{
	// Token: 0x06011BBC RID: 72636 RVA: 0x004DEEE0 File Offset: 0x004DD0E0
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06011BBD RID: 72637 RVA: 0x004DEF4C File Offset: 0x004DD14C
	public void RefreshCurrencyTex(int currencyId)
	{
		UUITexture texture = base.GetTexture(1);
		texture.SetUIActive(false);
		base.SetItemIcon(base.GetTexture(1), currencyId, null, delegate(bool _)
		{
			texture.SetUIActive(true);
		});
	}

	// Token: 0x06011BBE RID: 72638 RVA: 0x004DEF9B File Offset: 0x004DD19B
	[NullableContext(1)]
	public void RefreshTextById(string textId, IReadOnlyList<string> args)
	{
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), textId, args);
	}

	// Token: 0x02008707 RID: 34567
	private class EComponentDefine
	{
		// Token: 0x0402DABA RID: 187066
		public const int TxtNum = 0;

		// Token: 0x0402DABB RID: 187067
		public const int TexNumIcon = 1;
	}
}
