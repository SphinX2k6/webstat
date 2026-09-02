using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;

// Token: 0x020028BD RID: 10429
[NullableContext(2)]
[Nullable(0)]
public class RoleSkillInnerSkillItem : RoleSkillTreeSkillItemBase
{
	// Token: 0x06014B13 RID: 84755 RVA: 0x005BAD50 File Offset: 0x005B8F50
	protected unsafe override void OnRegisterComponent()
	{
		int num = 10;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUITexture));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06014B14 RID: 84756 RVA: 0x005BAEC3 File Offset: 0x005B90C3
	protected override UUIItem GetSkillIconItem()
	{
		return base.GetItem(0);
	}

	// Token: 0x06014B15 RID: 84757 RVA: 0x005BAECC File Offset: 0x005B90CC
	protected override UUIText GetLevelText()
	{
		return base.GetText(1);
	}

	// Token: 0x06014B16 RID: 84758 RVA: 0x005BAED5 File Offset: 0x005B90D5
	protected override UUIText GetNameText()
	{
		return base.GetText(2);
	}

	// Token: 0x06014B17 RID: 84759 RVA: 0x005BAEDE File Offset: 0x005B90DE
	protected override UUIItem GetStrongArrowUpItem()
	{
		return base.GetItem(3);
	}

	// Token: 0x06014B18 RID: 84760 RVA: 0x005BAEE7 File Offset: 0x005B90E7
	public override ESkillTreeNodeType? GetType()
	{
		return new ESkillTreeNodeType?(ESkillTreeNodeType.InnerSkill);
	}

	// Token: 0x06014B19 RID: 84761 RVA: 0x005BAEEF File Offset: 0x005B90EF
	protected override UUIItem GetLeftBranchItem()
	{
		return base.GetItem(4);
	}

	// Token: 0x06014B1A RID: 84762 RVA: 0x005BAEF8 File Offset: 0x005B90F8
	protected override UUISprite GetLeftBranchIcon()
	{
		return base.GetSprite(5);
	}

	// Token: 0x06014B1B RID: 84763 RVA: 0x005BAF01 File Offset: 0x005B9101
	protected override UUIItem GetRightBranchItem()
	{
		return base.GetItem(6);
	}

	// Token: 0x06014B1C RID: 84764 RVA: 0x005BAF0A File Offset: 0x005B910A
	protected override UUISprite GetRightBranchIcon()
	{
		return base.GetSprite(7);
	}

	// Token: 0x06014B1D RID: 84765 RVA: 0x005BAF13 File Offset: 0x005B9113
	protected override UUIItem GetShowTagItem()
	{
		return base.GetItem(8);
	}

	// Token: 0x06014B1E RID: 84766 RVA: 0x005BAF1C File Offset: 0x005B911C
	protected override UUITexture GetShowTagTex()
	{
		return base.GetTexture(9);
	}

	// Token: 0x02008C03 RID: 35843
	[NullableContext(0)]
	private enum EComponents
	{
		// Token: 0x0402F29B RID: 193179
		SkillIconItem,
		// Token: 0x0402F29C RID: 193180
		LevelText,
		// Token: 0x0402F29D RID: 193181
		NameText,
		// Token: 0x0402F29E RID: 193182
		StrongArrowUpItem,
		// Token: 0x0402F29F RID: 193183
		LeftBranchItem,
		// Token: 0x0402F2A0 RID: 193184
		LeftBranchIconSprite,
		// Token: 0x0402F2A1 RID: 193185
		RightBranchItem,
		// Token: 0x0402F2A2 RID: 193186
		RightBranchIconSprite,
		// Token: 0x0402F2A3 RID: 193187
		ShowTagItem,
		// Token: 0x0402F2A4 RID: 193188
		ShowTagTex
	}
}
