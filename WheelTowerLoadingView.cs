using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020016CC RID: 5836
[NullableContext(2)]
[Nullable(0)]
public class WheelTowerLoadingView : LoadingViewBase
{
	// Token: 0x0600A1F8 RID: 41464 RVA: 0x002AA0AF File Offset: 0x002A82AF
	[NullableContext(1)]
	public WheelTowerLoadingView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600A1F9 RID: 41465 RVA: 0x002AA0B8 File Offset: 0x002A82B8
	protected unsafe override void OnRegisterComponent()
	{
		int num = 7;
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
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIHorizontalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600A1FA RID: 41466 RVA: 0x002AA1C8 File Offset: 0x002A83C8
	protected override UniTask OnBeforeStartAsync()
	{
		WheelTowerLoadingView.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<WheelTowerLoadingView.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600A1FB RID: 41467 RVA: 0x002AA20B File Offset: 0x002A840B
	[NullableContext(1)]
	private WheelTowerLoadingTeamRoleItem InitTeamItem()
	{
		return new WheelTowerLoadingTeamRoleItem();
	}

	// Token: 0x0600A1FC RID: 41468 RVA: 0x002AA212 File Offset: 0x002A8412
	protected override void UpdateProgressRate(float rate)
	{
		base.GetSprite(5).SetFillAmount(rate);
	}

	// Token: 0x0600A1FD RID: 41469 RVA: 0x002AA221 File Offset: 0x002A8421
	protected override void UpdateProgressValue(float value)
	{
		this.SetTextProgressValue(6, value, "");
	}

	// Token: 0x04004C1F RID: 19487
	private PopupCaptionItem CaptionItem;

	// Token: 0x04004C20 RID: 19488
	private WheelTowerModeTitleItem ModeTitleItem;

	// Token: 0x04004C21 RID: 19489
	private WheelTowerLoadingBuffInfoPanel BuffInfoPanel;

	// Token: 0x04004C22 RID: 19490
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<WheelTowerLoadingTeamRoleItem, int> TeamRoleLayout;
}
