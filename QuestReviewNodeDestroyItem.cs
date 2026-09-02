using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;

// Token: 0x0200268D RID: 9869
public class QuestReviewNodeDestroyItem : QuestReviewNodeItemBase
{
	// Token: 0x0601377F RID: 79743 RVA: 0x0056D10C File Offset: 0x0056B30C
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

	// Token: 0x06013780 RID: 79744 RVA: 0x0056D178 File Offset: 0x0056B378
	[NullableContext(1)]
	public override void Refresh(IQuestReviewNodeParam param)
	{
		base.GetRootItem().SetAlpha(1f);
		base.GetSprite(0).SetAlpha(0.5f);
		base.GetSprite(1).SetAlpha(0.5f);
		base.GetSprite(1).SetUIActive(!param.IsLastSlotEmpty);
		this.SetSpriteByPath(param.RoundIcon, base.GetSprite(1), false, null, null);
		FColor color = FColor.FromHex(param.LineColorHex);
		base.GetSprite(0).SetColor(color);
	}

	// Token: 0x02008A35 RID: 35381
	private class ENodeDestroyComponentDefine
	{
		// Token: 0x0402E9B0 RID: 190896
		public const int SpriteLineHorizontal = 0;

		// Token: 0x0402E9B1 RID: 190897
		public const int SpriteStartPoint = 1;
	}
}
