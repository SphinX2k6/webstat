using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.SkipInterface;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02002A62 RID: 10850
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class RoleOrnamentObtainItem : GridProxyAbstract<IGetWayItemData>
{
	// Token: 0x06015BCE RID: 89038 RVA: 0x0060813C File Offset: 0x0060633C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 5;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06015BCF RID: 89039 RVA: 0x00608245 File Offset: 0x00606445
	private void OnClick()
	{
		if (this.Data.Type == EGetWayItemType.CanJump)
		{
			SkipTaskManager.RunByConfigId(this.Data.Id, this.Data.Id);
		}
	}

	// Token: 0x06015BD0 RID: 89040 RVA: 0x00608278 File Offset: 0x00606478
	public override void Refresh(IGetWayItemData data, bool isSelected, int gridIndex)
	{
		this.Data = data;
		bool flag = this.Data.Type == EGetWayItemType.CanJump;
		UUIItem item = base.GetItem(1);
		if (item != null)
		{
			item.SetUIActive(flag);
		}
		UUIItem item2 = base.GetItem(2);
		if (item2 != null)
		{
			item2.SetUIActive(!flag);
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), this.Data.Text, Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), this.Data.Text, Array.Empty<object>());
	}

	// Token: 0x0400A6CB RID: 42699
	private IGetWayItemData Data;

	// Token: 0x02008DE6 RID: 36326
	[NullableContext(0)]
	private enum EComponentDefine
	{
		// Token: 0x0402FBF4 RID: 195572
		Button,
		// Token: 0x0402FBF5 RID: 195573
		UnlockItem,
		// Token: 0x0402FBF6 RID: 195574
		LockItem,
		// Token: 0x0402FBF7 RID: 195575
		Name,
		// Token: 0x0402FBF8 RID: 195576
		LockName
	}
}
