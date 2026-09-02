using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;

// Token: 0x020028C7 RID: 10439
[NullableContext(2)]
[Nullable(0)]
public class RoleSkillOuterPassiveSkillItem : RoleSkillTreeSkillItemBase
{
	// Token: 0x06014B63 RID: 84835 RVA: 0x005BC290 File Offset: 0x005BA490
	protected unsafe override void OnRegisterComponent()
	{
		int num = 8;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUISprite));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06014B64 RID: 84836 RVA: 0x005BC3BF File Offset: 0x005BA5BF
	protected override UUIItem GetSkillIconItem()
	{
		return base.GetItem(0);
	}

	// Token: 0x06014B65 RID: 84837 RVA: 0x005BC3C8 File Offset: 0x005BA5C8
	protected override UUIItem GetLockItem()
	{
		return base.GetItem(1);
	}

	// Token: 0x06014B66 RID: 84838 RVA: 0x005BC3D1 File Offset: 0x005BA5D1
	protected override UUIText GetNameText()
	{
		return base.GetText(3);
	}

	// Token: 0x06014B67 RID: 84839 RVA: 0x005BC3DA File Offset: 0x005BA5DA
	protected override UUIItem GetStrongArrowUpItem()
	{
		return base.GetItem(2);
	}

	// Token: 0x06014B68 RID: 84840 RVA: 0x005BC3E3 File Offset: 0x005BA5E3
	public override ESkillTreeNodeType? GetType()
	{
		return new ESkillTreeNodeType?(ESkillTreeNodeType.OuterPassiveSkill);
	}

	// Token: 0x06014B69 RID: 84841 RVA: 0x005BC3EB File Offset: 0x005BA5EB
	protected override UUIItem GetLeftBranchItem()
	{
		return base.GetItem(4);
	}

	// Token: 0x06014B6A RID: 84842 RVA: 0x005BC3F4 File Offset: 0x005BA5F4
	protected override UUISprite GetLeftBranchIcon()
	{
		return base.GetSprite(5);
	}

	// Token: 0x06014B6B RID: 84843 RVA: 0x005BC3FD File Offset: 0x005BA5FD
	protected override UUIItem GetRightBranchItem()
	{
		return base.GetItem(6);
	}

	// Token: 0x06014B6C RID: 84844 RVA: 0x005BC406 File Offset: 0x005BA606
	protected override UUISprite GetRightBranchIcon()
	{
		return base.GetSprite(7);
	}

	// Token: 0x02008C13 RID: 35859
	[NullableContext(0)]
	private enum EComponents
	{
		// Token: 0x0402F2EE RID: 193262
		SkillIconItem,
		// Token: 0x0402F2EF RID: 193263
		LockItem,
		// Token: 0x0402F2F0 RID: 193264
		StrongArrowUpItem,
		// Token: 0x0402F2F1 RID: 193265
		NameText,
		// Token: 0x0402F2F2 RID: 193266
		LeftBranchItem,
		// Token: 0x0402F2F3 RID: 193267
		LeftBranchIconSprite,
		// Token: 0x0402F2F4 RID: 193268
		RightBranchItem,
		// Token: 0x0402F2F5 RID: 193269
		RightBranchIconSprite
	}
}
