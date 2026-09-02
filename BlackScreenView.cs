using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002C42 RID: 11330
public class BlackScreenView : UiPanelBase
{
	// Token: 0x06016B15 RID: 92949 RVA: 0x0064CE94 File Offset: 0x0064B094
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

	// Token: 0x06016B16 RID: 92950 RVA: 0x0064CEDC File Offset: 0x0064B0DC
	[NullableContext(2)]
	public AActor GetBlackScreenTextureActor()
	{
		UUITexture texture = base.GetTexture(0);
		if (texture == null)
		{
			return null;
		}
		return texture.GetOwner();
	}

	// Token: 0x02008F65 RID: 36709
	private enum EChildType
	{
		// Token: 0x04030267 RID: 197223
		BlackTexture
	}
}
