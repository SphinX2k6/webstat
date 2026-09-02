using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;

// Token: 0x020028C6 RID: 10438
[NullableContext(2)]
[Nullable(0)]
public class RoleSkillOuterAttributeSkillItem : RoleSkillTreeSkillItemBase
{
	// Token: 0x06014B5C RID: 84828 RVA: 0x005BC1D8 File Offset: 0x005BA3D8
	protected unsafe override void OnRegisterComponent()
	{
		int num = 3;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06014B5D RID: 84829 RVA: 0x005BC262 File Offset: 0x005BA462
	protected override UUIItem GetSkillIconItem()
	{
		return base.GetItem(0);
	}

	// Token: 0x06014B5E RID: 84830 RVA: 0x005BC26B File Offset: 0x005BA46B
	protected override UUIItem GetLockItem()
	{
		return base.GetItem(1);
	}

	// Token: 0x06014B5F RID: 84831 RVA: 0x005BC274 File Offset: 0x005BA474
	protected override UUIItem GetStrongArrowUpItem()
	{
		return base.GetItem(2);
	}

	// Token: 0x06014B60 RID: 84832 RVA: 0x005BC27D File Offset: 0x005BA47D
	public override ESkillTreeNodeType? GetType()
	{
		return new ESkillTreeNodeType?(ESkillTreeNodeType.OuterAttribute);
	}

	// Token: 0x06014B61 RID: 84833 RVA: 0x005BC285 File Offset: 0x005BA485
	public override bool IsIconTexture()
	{
		return true;
	}

	// Token: 0x02008C12 RID: 35858
	[NullableContext(0)]
	private enum EComponents
	{
		// Token: 0x0402F2EA RID: 193258
		SkillIconItem,
		// Token: 0x0402F2EB RID: 193259
		LockItem,
		// Token: 0x0402F2EC RID: 193260
		StrongArrowUpItem
	}
}
