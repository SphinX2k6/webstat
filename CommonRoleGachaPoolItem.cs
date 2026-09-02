using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001CE3 RID: 7395
public class CommonRoleGachaPoolItem : GachaPoolItem
{
	// Token: 0x0600D8F4 RID: 55540 RVA: 0x003A1744 File Offset: 0x0039F944
	public CommonRoleGachaPoolItem(GachaDefine.EGachaViewType gachaType) : base(gachaType)
	{
	}

	// Token: 0x0600D8F5 RID: 55541 RVA: 0x003A1750 File Offset: 0x0039F950
	protected unsafe override void OnRegisterComponent()
	{
		int num = 5;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUITexture));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600D8F6 RID: 55542 RVA: 0x003A181C File Offset: 0x0039FA1C
	protected override UniTask OnBeforeStartAsync()
	{
		CommonRoleGachaPoolItem.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<CommonRoleGachaPoolItem.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600D8F7 RID: 55543 RVA: 0x003A1860 File Offset: 0x0039FA60
	public override void Refresh()
	{
		if (this.GachaViewInfo == null)
		{
			return;
		}
		int[] showIdListArray = this.GachaViewInfo.Value.GetShowIdListArray();
		int num = 0;
		while (num < showIdListArray.Length && num < this.DescComponentList.Count)
		{
			this.DescComponentList[num].Update(showIdListArray[num], false);
			num++;
		}
		base.SetTextureByPath(this.GachaViewInfo.Value.TextTexture, base.GetTexture(4), null, null);
	}

	// Token: 0x04006799 RID: 26521
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<RoleDescribeComponent> DescComponentList;

	// Token: 0x02008033 RID: 32819
	private enum EComponent
	{
		// Token: 0x0402B9C6 RID: 178630
		ContentTexture,
		// Token: 0x0402B9C7 RID: 178631
		DescItem1,
		// Token: 0x0402B9C8 RID: 178632
		DescItem2,
		// Token: 0x0402B9C9 RID: 178633
		DescItem3,
		// Token: 0x0402B9CA RID: 178634
		ThemeTextTexture
	}
}
