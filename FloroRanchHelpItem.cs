using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02001EBD RID: 7869
internal class FloroRanchHelpItem : GridProxyAbstract<HelpText>
{
	// Token: 0x0600E89B RID: 59547 RVA: 0x003EE6C8 File Offset: 0x003EC8C8
	protected unsafe override void OnRegisterComponent()
	{
		int num = 1;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int index = 0;
		*span[index] = new ValueTuple<int, Type>(0, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600E89C RID: 59548 RVA: 0x003EE710 File Offset: 0x003EC910
	public override void Refresh(HelpText data, bool isSelected, int gridIndex)
	{
		UUIText text = base.GetText(0);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(text, data.Content, Array.Empty<object>());
	}

	// Token: 0x02008201 RID: 33281
	private enum EFloroRanchHelpItemComponents
	{
		// Token: 0x0402C195 RID: 180629
		TextContent
	}
}
