using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Protocol;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001CEA RID: 7402
public class GachaPoolDetailView : UiViewBase
{
	// Token: 0x0600D94A RID: 55626 RVA: 0x003A4330 File Offset: 0x003A2530
	[NullableContext(1)]
	public GachaPoolDetailView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600D94B RID: 55627 RVA: 0x003A433C File Offset: 0x003A253C
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

	// Token: 0x0600D94C RID: 55628 RVA: 0x003A43E8 File Offset: 0x003A25E8
	protected override UniTask OnBeforeStartAsync()
	{
		GachaPoolDetailView.<OnBeforeStartAsync>d__3 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<GachaPoolDetailView.<OnBeforeStartAsync>d__3>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600D94D RID: 55629 RVA: 0x003A442B File Offset: 0x003A262B
	[NullableContext(1)]
	[CompilerGenerated]
	internal static int <OnBeforeStartAsync>g__SortFunc|3_0(GachaPoolDrop a, GachaPoolDrop b)
	{
		if (!a.IsUp)
		{
			return (b.IsUp > false) ? 1 : 0;
		}
		return -1;
	}

	// Token: 0x0200804E RID: 32846
	private enum EGachaPoolDetailViewDefine
	{
		// Token: 0x0402BA60 RID: 178784
		TxtDetail,
		// Token: 0x0402BA61 RID: 178785
		GridContent,
		// Token: 0x0402BA62 RID: 178786
		GridItem,
		// Token: 0x0402BA63 RID: 178787
		TxtTitle
	}
}
