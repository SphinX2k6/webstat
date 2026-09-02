using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Skin.Skip;
using CSharpScript.Game.Module.SkipInterface;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02002A44 RID: 10820
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class SkinObtainItem : GridProxyAbstract<ISkinSkipData>
{
	// Token: 0x06015AB3 RID: 88755 RVA: 0x006041D8 File Offset: 0x006023D8
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

	// Token: 0x06015AB4 RID: 88756 RVA: 0x006042E1 File Offset: 0x006024E1
	private void OnClick()
	{
		if (this.Data.Type == ESkinSkipType.CanJump)
		{
			SkipTaskManager.RunByConfigId(this.Data.Id, this.Data.ConfigId);
		}
	}

	// Token: 0x06015AB5 RID: 88757 RVA: 0x00604314 File Offset: 0x00602514
	public override void Refresh(ISkinSkipData data, bool isSelected, int gridIndex)
	{
		this.Data = data;
		bool flag = this.Data.Type == ESkinSkipType.CanJump;
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

	// Token: 0x0400A66C RID: 42604
	private ISkinSkipData Data;

	// Token: 0x02008DCE RID: 36302
	[NullableContext(0)]
	private enum EComponentDefine
	{
		// Token: 0x0402FB96 RID: 195478
		Button,
		// Token: 0x0402FB97 RID: 195479
		UnlockItem,
		// Token: 0x0402FB98 RID: 195480
		LockItem,
		// Token: 0x0402FB99 RID: 195481
		Name,
		// Token: 0x0402FB9A RID: 195482
		LockName
	}
}
