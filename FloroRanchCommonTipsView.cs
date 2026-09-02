using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001C2A RID: 7210
public class FloroRanchCommonTipsView : UiViewBase
{
	// Token: 0x0600D1B8 RID: 53688 RVA: 0x0037ABCC File Offset: 0x00378DCC
	[NullableContext(1)]
	public FloroRanchCommonTipsView(UiViewInfo info) : base(info)
	{
	}

	// Token: 0x0600D1B9 RID: 53689 RVA: 0x0037ABD8 File Offset: 0x00378DD8
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.OnCloseButtonClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600D1BA RID: 53690 RVA: 0x0037AC80 File Offset: 0x00378E80
	protected override UniTask OnBeforeStartAsync()
	{
		FloroRanchCommonTipsView.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<FloroRanchCommonTipsView.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600D1BB RID: 53691 RVA: 0x0037ACC4 File Offset: 0x00378EC4
	protected override void OnBeforeShow()
	{
		IFloroRanchCommonTipParam param = this.OpenParam as IFloroRanchCommonTipParam;
		this.CommonTipItem.RefreshInfoTipByParam(param);
	}

	// Token: 0x0600D1BC RID: 53692 RVA: 0x0037ACE9 File Offset: 0x00378EE9
	private void OnCloseButtonClick()
	{
		base.CloseMe(null);
	}

	// Token: 0x0400640E RID: 25614
	[Nullable(1)]
	private FloroRanchCommonTipItem CommonTipItem;

	// Token: 0x02007F0A RID: 32522
	private class EComponentDefine
	{
		// Token: 0x0402B3A1 RID: 177057
		public const int CommonTipItem = 0;

		// Token: 0x0402B3A2 RID: 177058
		public const int CloseButton = 1;
	}
}
