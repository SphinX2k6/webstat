using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;

// Token: 0x0200268E RID: 9870
[NullableContext(1)]
[Nullable(0)]
public class QuestReviewNodeStarItem : QuestReviewNodeItemBase
{
	// Token: 0x06013782 RID: 79746 RVA: 0x0056D20C File Offset: 0x0056B40C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 4;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUISprite));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06013783 RID: 79747 RVA: 0x0056D2B8 File Offset: 0x0056B4B8
	public override void Refresh(IQuestReviewNodeParam param)
	{
		base.GetRootItem().SetAlpha(1f);
		base.GetSprite(0).SetAlpha(0.5f);
		base.GetSprite(2).SetAlpha(0.5f);
		base.GetSprite(1).SetAlpha(0.5f);
		base.GetSprite(1).SetUIActive(!param.IsLastSlotEmpty);
		this.SetSpriteByPath(param.RoundIcon, base.GetSprite(1), false, null, null);
		this.SetSpriteByPath(param.StarIcon, base.GetSprite(3), false, null, null);
		base.GetSprite(0).SetUIActive(true);
		base.GetSprite(2).SetUIActive(false);
		int num = param.IsLastSlot ? 0 : -190;
		this.SpriteLineHorizontal.SetStretchRight((float)num);
		FColor color = FColor.FromHex(param.LineColorHex);
		this.SpriteLineHorizontal.SetColor(color);
	}

	// Token: 0x17001869 RID: 6249
	// (get) Token: 0x06013784 RID: 79748 RVA: 0x0056D3A9 File Offset: 0x0056B5A9
	private UUISprite SpriteLineHorizontal
	{
		get
		{
			return base.GetSprite(0);
		}
	}

	// Token: 0x02008A36 RID: 35382
	[NullableContext(0)]
	private class ENodeStarComponentDefine
	{
		// Token: 0x0402E9B2 RID: 190898
		public const int SpriteLineHorizontalSolid = 0;

		// Token: 0x0402E9B3 RID: 190899
		public const int SpriteStartPoint = 1;

		// Token: 0x0402E9B4 RID: 190900
		public const int SpriteLineHorizontalDotted = 2;

		// Token: 0x0402E9B5 RID: 190901
		public const int SpriteIcon = 3;
	}
}
