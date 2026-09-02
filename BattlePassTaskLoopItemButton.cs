using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x0200238B RID: 9099
internal class BattlePassTaskLoopItemButton : UiPanelBase
{
	// Token: 0x060116EB RID: 71403 RVA: 0x004CE3C8 File Offset: 0x004CC5C8
	protected unsafe override void OnRegisterComponent()
	{
		int num = 3;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x060116EC RID: 71404 RVA: 0x004CE452 File Offset: 0x004CC652
	[NullableContext(2)]
	public void RefreshTextByTextId(string textId)
	{
		Singleton<LguiUtil>.Instance.TrySetLocalTextNew(base.GetText(1), textId, Array.Empty<object>());
	}

	// Token: 0x020086A5 RID: 34469
	private enum EButtonComponent
	{
		// Token: 0x0402D8AE RID: 186542
		Button,
		// Token: 0x0402D8AF RID: 186543
		Text,
		// Token: 0x0402D8B0 RID: 186544
		RedDotItem
	}
}
