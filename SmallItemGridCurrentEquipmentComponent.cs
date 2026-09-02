using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;

// Token: 0x02001A1C RID: 6684
[NullableContext(1)]
[Nullable(0)]
public class SmallItemGridCurrentEquipmentComponent : SmallItemGridVisibleComponent
{
	// Token: 0x0600BFDA RID: 49114 RVA: 0x0032BF10 File Offset: 0x0032A110
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600BFDB RID: 49115 RVA: 0x0032BF7C File Offset: 0x0032A17C
	protected override void OnStart()
	{
		FColor color = FColor.FromHex("D5A831FF");
		base.GetSprite(0).SetColor(color);
		FColor color2 = FColor.FromHex("FFFFFFFF");
		base.GetSprite(1).SetColor(color2);
	}

	// Token: 0x0600BFDC RID: 49116 RVA: 0x0032BFB9 File Offset: 0x0032A1B9
	[NullableContext(2)]
	protected override string GetResourceId()
	{
		return "UiItem_ItemSelTick";
	}

	// Token: 0x0600BFDD RID: 49117 RVA: 0x0032BFC0 File Offset: 0x0032A1C0
	protected override void OnRefresh(object bVisible)
	{
		base.OnRefresh(bVisible);
		base.SetUiActive((bool)bVisible);
	}

	// Token: 0x0600BFDE RID: 49118 RVA: 0x0032BFD5 File Offset: 0x0032A1D5
	public override EItemGridComponentLayoutLevel GetLayoutLevel()
	{
		return EItemGridComponentLayoutLevel.Bottom;
	}

	// Token: 0x040059EB RID: 23019
	private const string BG_COLOR = "D5A831FF";

	// Token: 0x040059EC RID: 23020
	private const string TOP_COLOR = "FFFFFFFF";

	// Token: 0x02007CF7 RID: 31991
	[NullableContext(0)]
	private enum EChildType
	{
		// Token: 0x0402AA0A RID: 174602
		Sprite,
		// Token: 0x0402AA0B RID: 174603
		TopSprite
	}
}
