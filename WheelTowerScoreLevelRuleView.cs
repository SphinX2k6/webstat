using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Activity.ActivityContent.WheelTower;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020016F4 RID: 5876
public class WheelTowerScoreLevelRuleView : UiViewBase
{
	// Token: 0x0600A2EC RID: 41708 RVA: 0x002B01CB File Offset: 0x002AE3CB
	[NullableContext(1)]
	public WheelTowerScoreLevelRuleView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600A2ED RID: 41709 RVA: 0x002B01D4 File Offset: 0x002AE3D4
	protected unsafe override void OnRegisterComponent()
	{
		int num = 4;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUILoopScrollViewComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600A2EE RID: 41710 RVA: 0x002B0280 File Offset: 0x002AE480
	protected override UniTask OnBeforeStartAsync()
	{
		WheelTowerScoreLevelRuleView.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<WheelTowerScoreLevelRuleView.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600A2EF RID: 41711 RVA: 0x002B02C3 File Offset: 0x002AE4C3
	private void OnCloseBtnClick()
	{
		base.CloseMe(null);
	}

	// Token: 0x04004D5E RID: 19806
	[Nullable(2)]
	private PopupCaptionItem CaptionItem;

	// Token: 0x04004D5F RID: 19807
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private LoopScrollView<WheelTowerScoreLevelTargetItem, WheelTowerScoreLevelTargetData> TargetLoopScroll;
}
