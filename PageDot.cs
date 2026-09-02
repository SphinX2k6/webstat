using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x020019FD RID: 6653
[Nullable(new byte[]
{
	0,
	1
})]
public class PageDot<[Nullable(2)] TData> : GridProxyAbstract<TData>
{
	// Token: 0x0600BE68 RID: 48744 RVA: 0x003265CC File Offset: 0x003247CC
	protected unsafe override void OnRegisterComponent()
	{
		int num = 1;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int index = 0;
		*span[index] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600BE69 RID: 48745 RVA: 0x00326614 File Offset: 0x00324814
	protected override void OnStart()
	{
		this.UpdateShow(false);
	}

	// Token: 0x0600BE6A RID: 48746 RVA: 0x0032661D File Offset: 0x0032481D
	[NullableContext(1)]
	public override void Refresh(TData data, bool isSelected, int gridIndex)
	{
	}

	// Token: 0x0600BE6B RID: 48747 RVA: 0x0032661F File Offset: 0x0032481F
	public void UpdateShow(bool show)
	{
		base.GetItem(0).SetUIActive(show);
	}

	// Token: 0x02007CE5 RID: 31973
	private class EComponent
	{
		// Token: 0x0402A9BC RID: 174524
		public const int DotPic = 0;
	}
}
