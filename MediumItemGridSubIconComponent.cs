using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;

// Token: 0x020019E4 RID: 6628
public class MediumItemGridSubIconComponent : MediumItemGridComponent
{
	// Token: 0x0600BE01 RID: 48641 RVA: 0x003254A3 File Offset: 0x003236A3
	[NullableContext(1)]
	protected override string GetResourceId()
	{
		return "UiItem_ItemAIcon";
	}

	// Token: 0x0600BE02 RID: 48642 RVA: 0x003254AC File Offset: 0x003236AC
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

	// Token: 0x0600BE03 RID: 48643 RVA: 0x003254F4 File Offset: 0x003236F4
	[NullableContext(2)]
	protected override void OnRefresh(object data)
	{
		string text = data as string;
		if (text == null)
		{
			return;
		}
		bool flag = !string.IsNullOrEmpty(text);
		this.SetActive(flag);
		if (flag)
		{
			base.SetTextureShowUntilLoaded(text, base.GetTexture(0), null);
		}
	}

	// Token: 0x0600BE04 RID: 48644 RVA: 0x0032552F File Offset: 0x0032372F
	public override EItemGridComponentLayoutLevel GetLayoutLevel()
	{
		return EItemGridComponentLayoutLevel.UnderText;
	}

	// Token: 0x02007CD7 RID: 31959
	private class EChildType
	{
		// Token: 0x0402A994 RID: 174484
		public const int TextureIcon = 0;
	}
}
