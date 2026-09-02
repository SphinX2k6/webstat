using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001093 RID: 4243
public class FurnitureGetWayView : UiViewBase
{
	// Token: 0x06006EAC RID: 28332 RVA: 0x001CCDC0 File Offset: 0x001CAFC0
	[NullableContext(1)]
	public FurnitureGetWayView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06006EAD RID: 28333 RVA: 0x001CCDCC File Offset: 0x001CAFCC
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(2, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(1, new Action(this.OnClickCloseButton))
		};
	}

	// Token: 0x06006EAE RID: 28334 RVA: 0x001CCE4C File Offset: 0x001CB04C
	protected override UniTask OnBeforeStartAsync()
	{
		FurnitureGetWayView.<OnBeforeStartAsync>d__3 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<FurnitureGetWayView.<OnBeforeStartAsync>d__3>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06006EAF RID: 28335 RVA: 0x001CCE8F File Offset: 0x001CB08F
	private void OnClickCloseButton()
	{
		base.CloseMe(null);
	}

	// Token: 0x040034C8 RID: 13512
	[Nullable(2)]
	protected FurnitureGetWayItem GetWayItem;
}
