using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnrealEngine;

// Token: 0x020028BA RID: 10426
public class RoleSkillInnerPassiveSkillAndOuterPassiveSkillItem : RoleSkillChainItem
{
	// Token: 0x06014B00 RID: 84736 RVA: 0x005BA820 File Offset: 0x005B8A20
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

	// Token: 0x06014B01 RID: 84737 RVA: 0x005BA8EC File Offset: 0x005B8AEC
	protected override void OnStart()
	{
		RoleSkillInnerPassiveSkillItem roleSkillInnerPassiveSkillItem = new RoleSkillInnerPassiveSkillItem();
		roleSkillInnerPassiveSkillItem.CreateThenShowByActor(base.GetItem(0).GetOwner(), null);
		roleSkillInnerPassiveSkillItem.SetSkillBranchEnable(this.IsSkillBranchEnable);
		this.SkillNodeItemList.Add(roleSkillInnerPassiveSkillItem);
		foreach (RoleSkillInnerPassiveSkillAndOuterPassiveSkillItem.EComponent name in new RoleSkillInnerPassiveSkillAndOuterPassiveSkillItem.EComponent[]
		{
			RoleSkillInnerPassiveSkillAndOuterPassiveSkillItem.EComponent.OuterPassiveSkillItem1,
			RoleSkillInnerPassiveSkillAndOuterPassiveSkillItem.EComponent.OuterPassiveSkillItem2
		})
		{
			UUIItem item = base.GetItem((int)name);
			RoleSkillOuterPassiveSkillItem roleSkillOuterPassiveSkillItem = new RoleSkillOuterPassiveSkillItem();
			roleSkillOuterPassiveSkillItem.SetSkillBranchEnable(this.IsSkillBranchEnable);
			roleSkillOuterPassiveSkillItem.CreateThenShowByActor(item.GetOwner(), null);
			this.SkillNodeItemList.Add(roleSkillOuterPassiveSkillItem);
		}
		foreach (RoleSkillInnerPassiveSkillAndOuterPassiveSkillItem.EComponent name2 in new RoleSkillInnerPassiveSkillAndOuterPassiveSkillItem.EComponent[]
		{
			RoleSkillInnerPassiveSkillAndOuterPassiveSkillItem.EComponent.LineItem1,
			RoleSkillInnerPassiveSkillAndOuterPassiveSkillItem.EComponent.LineItem2
		})
		{
			UUIItem item2 = base.GetItem((int)name2);
			this.LineItemList.Add(item2);
		}
	}

	// Token: 0x02008C00 RID: 35840
	private enum EComponent
	{
		// Token: 0x0402F284 RID: 193156
		InnerPassiveSkillItem,
		// Token: 0x0402F285 RID: 193157
		OuterPassiveSkillItem1,
		// Token: 0x0402F286 RID: 193158
		OuterPassiveSkillItem2,
		// Token: 0x0402F287 RID: 193159
		LineItem1,
		// Token: 0x0402F288 RID: 193160
		LineItem2
	}
}
