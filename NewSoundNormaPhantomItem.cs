using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02001753 RID: 5971
public class NewSoundNormaPhantomItem : GridProxyAbstract<int>
{
	// Token: 0x0600A7E9 RID: 42985 RVA: 0x002CB4F4 File Offset: 0x002C96F4
	protected unsafe override void OnRegisterComponent()
	{
		int num = 1;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int index = 0;
		*span[index] = new ValueTuple<int, Type>(0, typeof(UUITexture));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600A7EA RID: 42986 RVA: 0x002CB53C File Offset: 0x002C973C
	public override void Refresh(int data, bool isSelected, int gridIndex)
	{
	}

	// Token: 0x02007AB8 RID: 31416
	private enum EChildType
	{
		// Token: 0x0402A09F RID: 172191
		IconTexture
	}
}
