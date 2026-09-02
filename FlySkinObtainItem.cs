using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.SkipInterface;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02002A5A RID: 10842
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class FlySkinObtainItem : GridProxyAbstract<IFlySkinGetWayData>
{
	// Token: 0x06015B6E RID: 88942 RVA: 0x00606864 File Offset: 0x00604A64
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

	// Token: 0x06015B6F RID: 88943 RVA: 0x0060696D File Offset: 0x00604B6D
	private void OnClick()
	{
		if (this.Data.Type == EFlySkinGetWayType.CanJump)
		{
			SkipTaskManager.RunByConfigId(this.Data.Id, this.Data.ConfigId);
		}
	}

	// Token: 0x06015B70 RID: 88944 RVA: 0x006069A0 File Offset: 0x00604BA0
	public override void Refresh(IFlySkinGetWayData data, bool isSelected, int gridIndex)
	{
		this.Data = data;
		bool flag = this.Data.Type == EFlySkinGetWayType.CanJump;
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

	// Token: 0x0400A6A9 RID: 42665
	private IFlySkinGetWayData Data;

	// Token: 0x02008DDF RID: 36319
	[NullableContext(0)]
	private enum EComponentDefine
	{
		// Token: 0x0402FBCE RID: 195534
		Button,
		// Token: 0x0402FBCF RID: 195535
		UnlockItem,
		// Token: 0x0402FBD0 RID: 195536
		LockItem,
		// Token: 0x0402FBD1 RID: 195537
		Name,
		// Token: 0x0402FBD2 RID: 195538
		LockName
	}
}
