using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;

// Token: 0x02001A35 RID: 6709
[NullableContext(1)]
[Nullable(0)]
public class SmallItemGridReceivedComponent : SmallItemGridComponent
{
	// Token: 0x0600C02E RID: 49198 RVA: 0x0032C928 File Offset: 0x0032AB28
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

	// Token: 0x0600C02F RID: 49199 RVA: 0x0032C970 File Offset: 0x0032AB70
	protected override void OnRefresh(object bVisible)
	{
		this.SetActive((bVisible as bool?).GetValueOrDefault());
	}

	// Token: 0x0600C030 RID: 49200 RVA: 0x0032C996 File Offset: 0x0032AB96
	public void SetSpriteColor(string hexColor)
	{
		base.GetSprite(0).SetColor(FColor.FromHex(hexColor));
	}

	// Token: 0x0600C031 RID: 49201 RVA: 0x0032C9AA File Offset: 0x0032ABAA
	protected override string GetResourceId()
	{
		return "UiItem_ItemBReceived";
	}

	// Token: 0x0600C032 RID: 49202 RVA: 0x0032C9B1 File Offset: 0x0032ABB1
	public override EItemGridComponentLayoutLevel GetLayoutLevel()
	{
		return EItemGridComponentLayoutLevel.Top;
	}

	// Token: 0x02007D00 RID: 32000
	[NullableContext(0)]
	private class EChildType
	{
		// Token: 0x0402AA1C RID: 174620
		public const int Sprite = 0;
	}
}
