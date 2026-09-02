using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;

// Token: 0x0200268F RID: 9871
public class QuestReviewNodeStarDestroyItem : QuestReviewNodeItemBase
{
	// Token: 0x06013786 RID: 79750 RVA: 0x0056D3BC File Offset: 0x0056B5BC
	protected unsafe override void OnRegisterComponent()
	{
		int num = 3;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06013787 RID: 79751 RVA: 0x0056D448 File Offset: 0x0056B648
	[NullableContext(1)]
	public override void Refresh(IQuestReviewNodeParam param)
	{
		base.GetRootItem().SetAlpha(1f);
		base.GetSprite(0).SetAlpha(0.5f);
		base.GetSprite(1).SetAlpha(0.5f);
		base.GetSprite(1).SetUIActive(!param.IsLastSlotEmpty);
		base.GetItem(2).SetUIActive(!param.IsLastSlotEmpty);
		this.SetSpriteByPath(param.RoundIcon, base.GetSprite(1), false, null, null);
		FColor color = FColor.FromHex(param.LineColorHex);
		base.GetSprite(0).SetColor(color);
		int num = param.IsLastSlot ? 0 : -190;
		base.GetSprite(0).SetStretchRight((float)num);
	}

	// Token: 0x02008A37 RID: 35383
	private class ENodeStarDestroyComponentDefine
	{
		// Token: 0x0402E9B6 RID: 190902
		public const int SpriteLineHorizontal = 0;

		// Token: 0x0402E9B7 RID: 190903
		public const int SpriteStartPoint = 1;

		// Token: 0x0402E9B8 RID: 190904
		public const int ItemAnimRound = 2;
	}
}
