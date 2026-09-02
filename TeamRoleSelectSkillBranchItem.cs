using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;

// Token: 0x0200279C RID: 10140
public class TeamRoleSelectSkillBranchItem : CommonRoleSkillBranchSwitchItem
{
	// Token: 0x06014043 RID: 81987 RVA: 0x005951D0 File Offset: 0x005933D0
	protected unsafe override void OnRegisterComponent()
	{
		int num = 6;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(base.OnToggleStateChange));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06014044 RID: 81988 RVA: 0x005952FA File Offset: 0x005934FA
	[NullableContext(1)]
	protected override UUIExtendToggle GetBranchToggle()
	{
		return base.GetExtendToggle(0);
	}

	// Token: 0x06014045 RID: 81989 RVA: 0x00595304 File Offset: 0x00593504
	[NullableContext(1)]
	protected override SkillBranchSwitchItemGroup[] CollectBranchItems()
	{
		return new SkillBranchSwitchItemGroup[]
		{
			new SkillBranchSwitchItemGroup
			{
				SpriteTagIcon = base.GetSprite(2),
				ActiveIndexHandler = delegate(bool active)
				{
					base.GetItem(3).SetUIActive(active);
				}
			},
			new SkillBranchSwitchItemGroup
			{
				SpriteTagIcon = base.GetSprite(4),
				ActiveIndexHandler = delegate(bool active)
				{
					base.GetItem(5).SetUIActive(active);
					this.SetMiddleTagItemToRight(active);
				}
			}
		};
	}

	// Token: 0x06014046 RID: 81990 RVA: 0x00595368 File Offset: 0x00593568
	private void SetMiddleTagItemToRight(bool isRight)
	{
		UUIItem item = base.GetItem(1);
		FVector fvector = new FVector(0f, (float)(isRight ? 180 : 0), 0f);
		FRotator frotator = FRotator.MakeFromEuler(fvector);
		item.SetUIRelativeRotation(frotator);
	}

	// Token: 0x02008B51 RID: 35665
	private enum EChild
	{
		// Token: 0x0402EF6A RID: 192362
		Toggle,
		// Token: 0x0402EF6B RID: 192363
		ItemMiddle,
		// Token: 0x0402EF6C RID: 192364
		SpriteTagIconL,
		// Token: 0x0402EF6D RID: 192365
		ItemTagL,
		// Token: 0x0402EF6E RID: 192366
		SpriteTagIconR,
		// Token: 0x0402EF6F RID: 192367
		ItemTagR
	}
}
