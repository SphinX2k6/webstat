using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020016BF RID: 5823
public class WheelTowerBossBuffTip : UiViewBase
{
	// Token: 0x0600A1C1 RID: 41409 RVA: 0x002A8A08 File Offset: 0x002A6C08
	[NullableContext(1)]
	public WheelTowerBossBuffTip(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600A1C2 RID: 41410 RVA: 0x002A8A14 File Offset: 0x002A6C14
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnMaskBtnClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600A1C3 RID: 41411 RVA: 0x002A8ABC File Offset: 0x002A6CBC
	protected override UniTask OnBeforeStartAsync()
	{
		WheelTowerBossBuffTip.<OnBeforeStartAsync>d__2 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<WheelTowerBossBuffTip.<OnBeforeStartAsync>d__2>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600A1C4 RID: 41412 RVA: 0x002A8AFF File Offset: 0x002A6CFF
	private void OnMaskBtnClick()
	{
		base.CloseMe(null);
	}
}
