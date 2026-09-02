using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;

// Token: 0x02001A20 RID: 6688
[NullableContext(1)]
[Nullable(0)]
public class SmallItemGridDisableComponent : SmallItemGridComponent
{
	// Token: 0x0600BFEA RID: 49130 RVA: 0x0032C20C File Offset: 0x0032A40C
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

	// Token: 0x0600BFEB RID: 49131 RVA: 0x0032C254 File Offset: 0x0032A454
	protected override void OnRefresh(object bVisible)
	{
		this.SetActive((bVisible as bool?).GetValueOrDefault());
	}

	// Token: 0x0600BFEC RID: 49132 RVA: 0x0032C27C File Offset: 0x0032A47C
	public void SetSpriteColor(string hexColor)
	{
		FColor color = FColor.FromHex(hexColor);
		base.GetSprite(0).SetColor(color);
	}

	// Token: 0x0600BFED RID: 49133 RVA: 0x0032C29D File Offset: 0x0032A49D
	protected override string GetResourceId()
	{
		return "UiItem_SmallItemDark";
	}

	// Token: 0x0600BFEE RID: 49134 RVA: 0x0032C2A4 File Offset: 0x0032A4A4
	public override EItemGridComponentLayoutLevel GetLayoutLevel()
	{
		return EItemGridComponentLayoutLevel.Bottom;
	}

	// Token: 0x02007CF9 RID: 31993
	[NullableContext(0)]
	private class EChildType
	{
		// Token: 0x0402AA0F RID: 174607
		public const int Sprite = 0;
	}
}
