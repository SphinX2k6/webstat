using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;

// Token: 0x020019E2 RID: 6626
public class MediumItemGridSpriteIconComponent : MediumItemGridComponent
{
	// Token: 0x0600BDF6 RID: 48630 RVA: 0x003251F4 File Offset: 0x003233F4
	protected unsafe override void OnRegisterComponent()
	{
		int num = 1;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int index = 0;
		*span[index] = new ValueTuple<int, Type>(0, typeof(UUISprite));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600BDF7 RID: 48631 RVA: 0x0032523C File Offset: 0x0032343C
	[NullableContext(1)]
	protected override string GetResourceId()
	{
		return "UiItem_ItemSprite";
	}

	// Token: 0x0600BDF8 RID: 48632 RVA: 0x00325244 File Offset: 0x00323444
	[NullableContext(2)]
	protected override void OnRefresh(object data)
	{
		string text = data as string;
		if (text == null || string.IsNullOrEmpty(text))
		{
			this.SetActive(false);
			return;
		}
		UUISprite sprite = base.GetSprite(0);
		this.SetSpriteByPath(text, sprite, false, null, null);
		this.SetActive(true);
	}

	// Token: 0x02007CD5 RID: 31957
	private class EChildType
	{
		// Token: 0x0402A991 RID: 174481
		public const int SpriteIcon = 0;
	}
}
