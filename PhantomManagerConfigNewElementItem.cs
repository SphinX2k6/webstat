using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002483 RID: 9347
public class PhantomManagerConfigNewElementItem : UiPanelBase
{
	// Token: 0x0601223D RID: 74301 RVA: 0x004FC8B4 File Offset: 0x004FAAB4
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0601223E RID: 74302 RVA: 0x004FC920 File Offset: 0x004FAB20
	[NullableContext(1)]
	public void Refresh(string path)
	{
		base.SetTextureByPath(path, base.GetTexture(1), null, null);
	}

	// Token: 0x0200879C RID: 34716
	private enum EElement
	{
		// Token: 0x0402DD7F RID: 187775
		Sprite,
		// Token: 0x0402DD80 RID: 187776
		Texture
	}
}
