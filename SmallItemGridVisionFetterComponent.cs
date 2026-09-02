using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001A42 RID: 6722
public class SmallItemGridVisionFetterComponent : SmallItemGridComponent
{
	// Token: 0x0600C06D RID: 49261 RVA: 0x0032D162 File Offset: 0x0032B362
	[NullableContext(1)]
	protected override string GetResourceId()
	{
		return "UiItem_ItemBElementB";
	}

	// Token: 0x0600C06E RID: 49262 RVA: 0x0032D16C File Offset: 0x0032B36C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 1;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int index = 0;
		*span[index] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600C06F RID: 49263 RVA: 0x0032D1B4 File Offset: 0x0032B3B4
	protected override UniTask OnBeforeStartAsync()
	{
		SmallItemGridVisionFetterComponent.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<SmallItemGridVisionFetterComponent.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600C070 RID: 49264 RVA: 0x0032D1F8 File Offset: 0x0032B3F8
	[NullableContext(2)]
	protected override void OnRefresh(object data)
	{
		PhantomFetterGroup fetterGroupById = ConfigBase<PhantomBattleConfig>.Instance.GetFetterGroupById((int)data);
		this.SetActive(true);
		this.VisionFetterSuitItem.Update(new PhantomFetterGroup?(fetterGroupById));
	}

	// Token: 0x040059FD RID: 23037
	[Nullable(2)]
	private VisionFetterSuitItem VisionFetterSuitItem;

	// Token: 0x02007D06 RID: 32006
	private enum EComponent
	{
		// Token: 0x0402AA2C RID: 174636
		ElementItem
	}
}
