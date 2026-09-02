using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using UnrealEngine;

// Token: 0x020019DD RID: 6621
public class MediumItemGridRoleRightBottomTag : MediumItemGridComponent
{
	// Token: 0x0600BDE0 RID: 48608 RVA: 0x00324DDC File Offset: 0x00322FDC
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600BDE1 RID: 48609 RVA: 0x00324E45 File Offset: 0x00323045
	[NullableContext(1)]
	protected override string GetResourceId()
	{
		return "UiItem_ItemTeanTag";
	}

	// Token: 0x0600BDE2 RID: 48610 RVA: 0x00324E4C File Offset: 0x0032304C
	[NullableContext(2)]
	protected override void OnRefresh(object obj)
	{
		MediumRoleRightBottomTag mediumRoleRightBottomTag = obj as MediumRoleRightBottomTag;
		if (mediumRoleRightBottomTag == null)
		{
			return;
		}
		UUIItem item = base.GetItem(0);
		if (item != null)
		{
			item.SetUIActive(mediumRoleRightBottomTag.IsRecommendRole);
		}
		UUIItem item2 = base.GetItem(1);
		if (item2 != null)
		{
			item2.SetUIActive(mediumRoleRightBottomTag.IsTrialRole);
		}
		this.SetActive(mediumRoleRightBottomTag.IsRecommendRole || mediumRoleRightBottomTag.IsTrialRole);
	}

	// Token: 0x02007CD0 RID: 31952
	private class EChildType
	{
		// Token: 0x0402A98B RID: 174475
		public const int ItemRecommend = 0;

		// Token: 0x0402A98C RID: 174476
		public const int ItemTrial = 1;
	}
}
