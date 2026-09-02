using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;

// Token: 0x020028BB RID: 10427
[NullableContext(2)]
[Nullable(0)]
public class RoleSkillInnerPassiveSkillItem : RoleSkillTreeSkillItemBase
{
	// Token: 0x06014B03 RID: 84739 RVA: 0x005BA9C8 File Offset: 0x005B8BC8
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

	// Token: 0x06014B04 RID: 84740 RVA: 0x005BAB3B File Offset: 0x005B8D3B
	protected override UUIItem GetSkillIconItem()
	{
		return base.GetItem(0);
	}

	// Token: 0x06014B05 RID: 84741 RVA: 0x005BAB44 File Offset: 0x005B8D44
	protected override UUIText GetLevelText()
	{
		return base.GetText(1);
	}

	// Token: 0x06014B06 RID: 84742 RVA: 0x005BAB4D File Offset: 0x005B8D4D
	protected override UUIText GetNameText()
	{
		return base.GetText(2);
	}

	// Token: 0x06014B07 RID: 84743 RVA: 0x005BAB56 File Offset: 0x005B8D56
	protected override UUIItem GetStrongArrowUpItem()
	{
		return base.GetItem(3);
	}

	// Token: 0x06014B08 RID: 84744 RVA: 0x005BAB5F File Offset: 0x005B8D5F
	public override ESkillTreeNodeType? GetType()
	{
		return new ESkillTreeNodeType?(ESkillTreeNodeType.InnerPassiveSkill);
	}

	// Token: 0x06014B09 RID: 84745 RVA: 0x005BAB67 File Offset: 0x005B8D67
	protected override UUIItem GetLeftBranchItem()
	{
		return base.GetItem(4);
	}

	// Token: 0x06014B0A RID: 84746 RVA: 0x005BAB70 File Offset: 0x005B8D70
	protected override UUISprite GetLeftBranchIcon()
	{
		return base.GetSprite(5);
	}

	// Token: 0x06014B0B RID: 84747 RVA: 0x005BAB79 File Offset: 0x005B8D79
	protected override UUIItem GetRightBranchItem()
	{
		return base.GetItem(6);
	}

	// Token: 0x06014B0C RID: 84748 RVA: 0x005BAB82 File Offset: 0x005B8D82
	protected override UUISprite GetRightBranchIcon()
	{
		return base.GetSprite(7);
	}

	// Token: 0x06014B0D RID: 84749 RVA: 0x005BAB8B File Offset: 0x005B8D8B
	protected override UUIItem GetShowTagItem()
	{
		return base.GetItem(8);
	}

	// Token: 0x06014B0E RID: 84750 RVA: 0x005BAB94 File Offset: 0x005B8D94
	protected override UUITexture GetShowTagTex()
	{
		return base.GetTexture(9);
	}

	// Token: 0x02008C01 RID: 35841
	[NullableContext(0)]
	private enum EComponents
	{
		// Token: 0x0402F28A RID: 193162
		SkillIconItem,
		// Token: 0x0402F28B RID: 193163
		LevelText,
		// Token: 0x0402F28C RID: 193164
		NameText,
		// Token: 0x0402F28D RID: 193165
		StrongArrowUpItem,
		// Token: 0x0402F28E RID: 193166
		LeftBranchItem,
		// Token: 0x0402F28F RID: 193167
		LeftBranchIconSprite,
		// Token: 0x0402F290 RID: 193168
		RightBranchItem,
		// Token: 0x0402F291 RID: 193169
		RightBranchIconSprite,
		// Token: 0x0402F292 RID: 193170
		ShowTagItem,
		// Token: 0x0402F293 RID: 193171
		ShowTagTex
	}
}
