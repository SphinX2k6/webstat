using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;

// Token: 0x02001B5A RID: 7002
public class FormationSkillBranchItem : CommonRoleSkillBranchSwitchItem
{
	// Token: 0x0600CAC0 RID: 51904 RVA: 0x00360CAC File Offset: 0x0035EEAC
	protected unsafe override void OnRegisterComponent()
	{
		int num = 7;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(base.OnToggleStateChange));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600CAC1 RID: 51905 RVA: 0x00360DF7 File Offset: 0x0035EFF7
	[NullableContext(1)]
	protected override UUIExtendToggle GetBranchToggle()
	{
		return base.GetExtendToggle(0);
	}

	// Token: 0x0600CAC2 RID: 51906 RVA: 0x00360E00 File Offset: 0x0035F000
	[NullableContext(1)]
	protected override SkillBranchSwitchItemGroup[] CollectBranchItems()
	{
		return new SkillBranchSwitchItemGroup[]
		{
			new SkillBranchSwitchItemGroup
			{
				SpriteTagIcon = base.GetSprite(3),
				ActiveIndexHandler = delegate(bool active)
				{
					base.GetItem(4).SetUIActive(active);
					base.GetSprite(1).SetUIActive(active);
				}
			},
			new SkillBranchSwitchItemGroup
			{
				SpriteTagIcon = base.GetSprite(5),
				ActiveIndexHandler = delegate(bool active)
				{
					base.GetItem(6).SetUIActive(active);
					base.GetSprite(2).SetUIActive(active);
				}
			}
		};
	}

	// Token: 0x02007E47 RID: 32327
	private enum EChild
	{
		// Token: 0x0402B04F RID: 176207
		Toggle,
		// Token: 0x0402B050 RID: 176208
		SpriteTagBgL,
		// Token: 0x0402B051 RID: 176209
		SpriteTagBgR,
		// Token: 0x0402B052 RID: 176210
		SpriteTagIconL,
		// Token: 0x0402B053 RID: 176211
		ItemTagL,
		// Token: 0x0402B054 RID: 176212
		SpriteTagIconR,
		// Token: 0x0402B055 RID: 176213
		ItemTagR
	}
}
