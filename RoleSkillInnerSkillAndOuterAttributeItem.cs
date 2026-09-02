using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnrealEngine;

// Token: 0x020028BC RID: 10428
public class RoleSkillInnerSkillAndOuterAttributeItem : RoleSkillChainItem
{
	// Token: 0x06014B10 RID: 84752 RVA: 0x005BABA8 File Offset: 0x005B8DA8
	protected unsafe override void OnRegisterComponent()
	{
		int num = 5;
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
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06014B11 RID: 84753 RVA: 0x005BAC74 File Offset: 0x005B8E74
	protected override void OnStart()
	{
		RoleSkillInnerSkillItem roleSkillInnerSkillItem = new RoleSkillInnerSkillItem();
		roleSkillInnerSkillItem.SetSkillBranchEnable(this.IsSkillBranchEnable);
		roleSkillInnerSkillItem.CreateThenShowByActor(base.GetItem(0).GetOwner(), null);
		this.SkillNodeItemList.Add(roleSkillInnerSkillItem);
		foreach (RoleSkillInnerSkillAndOuterAttributeItem.EComponent name in new RoleSkillInnerSkillAndOuterAttributeItem.EComponent[]
		{
			RoleSkillInnerSkillAndOuterAttributeItem.EComponent.OuterAttributeItem1,
			RoleSkillInnerSkillAndOuterAttributeItem.EComponent.OuterAttributeItem2
		})
		{
			UUIItem item = base.GetItem((int)name);
			RoleSkillOuterAttributeSkillItem roleSkillOuterAttributeSkillItem = new RoleSkillOuterAttributeSkillItem();
			roleSkillOuterAttributeSkillItem.SetSkillBranchEnable(this.IsSkillBranchEnable);
			roleSkillOuterAttributeSkillItem.CreateThenShowByActor(item.GetOwner(), null);
			this.SkillNodeItemList.Add(roleSkillOuterAttributeSkillItem);
		}
		foreach (RoleSkillInnerSkillAndOuterAttributeItem.EComponent name2 in new RoleSkillInnerSkillAndOuterAttributeItem.EComponent[]
		{
			RoleSkillInnerSkillAndOuterAttributeItem.EComponent.LineItem1,
			RoleSkillInnerSkillAndOuterAttributeItem.EComponent.LineItem2
		})
		{
			UUIItem item2 = base.GetItem((int)name2);
			this.LineItemList.Add(item2);
		}
	}

	// Token: 0x02008C02 RID: 35842
	private enum EComponent
	{
		// Token: 0x0402F295 RID: 193173
		InnerSkillItem,
		// Token: 0x0402F296 RID: 193174
		OuterAttributeItem1,
		// Token: 0x0402F297 RID: 193175
		OuterAttributeItem2,
		// Token: 0x0402F298 RID: 193176
		LineItem1,
		// Token: 0x0402F299 RID: 193177
		LineItem2
	}
}
