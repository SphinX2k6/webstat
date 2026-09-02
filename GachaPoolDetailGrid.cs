using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001CEB RID: 7403
public class GachaPoolDetailGrid : UiPanelBase
{
	// Token: 0x0600D94E RID: 55630 RVA: 0x003A4440 File Offset: 0x003A2640
	protected unsafe override void OnRegisterComponent()
	{
		int num = 4;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600D94F RID: 55631 RVA: 0x003A44EC File Offset: 0x003A26EC
	protected override UniTask OnBeforeStartAsync()
	{
		GachaPoolDetailGrid.<OnBeforeStartAsync>d__3 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<GachaPoolDetailGrid.<OnBeforeStartAsync>d__3>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x040067BE RID: 26558
	[Nullable(2)]
	public GachaPoolDetailData Data;

	// Token: 0x02008051 RID: 32849
	private enum EGachaPoolDetailGridDefine
	{
		// Token: 0x0402BA70 RID: 178800
		TxtDesc,
		// Token: 0x0402BA71 RID: 178801
		ContentItem,
		// Token: 0x0402BA72 RID: 178802
		Item,
		// Token: 0x0402BA73 RID: 178803
		TxtTitle
	}
}
