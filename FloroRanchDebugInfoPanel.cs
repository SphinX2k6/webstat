using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001C57 RID: 7255
public class FloroRanchDebugInfoPanel : UiPanelBase
{
	// Token: 0x0600D3B1 RID: 54193 RVA: 0x00386A38 File Offset: 0x00384C38
	protected unsafe override void OnRegisterComponent()
	{
		int num = 3;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUILoopScrollViewComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickCloseButton));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600D3B2 RID: 54194 RVA: 0x00386AFF File Offset: 0x00384CFF
	protected override void OnStart()
	{
		this.LoopScrollView = new LoopScrollView<FloroRanchDebugInfoItem, string>(base.GetLoopScrollViewComponent(1), base.GetItem(2).GetOwner() as AUIBaseActor, new Func<FloroRanchDebugInfoItem>(this.InitItem), false);
	}

	// Token: 0x0600D3B3 RID: 54195 RVA: 0x00386B34 File Offset: 0x00384D34
	protected override UniTask OnBeforeShowAsyncImplement()
	{
		FloroRanchDebugInfoPanel.<OnBeforeShowAsyncImplement>d__4 <OnBeforeShowAsyncImplement>d__;
		<OnBeforeShowAsyncImplement>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeShowAsyncImplement>d__.<>4__this = this;
		<OnBeforeShowAsyncImplement>d__.<>1__state = -1;
		<OnBeforeShowAsyncImplement>d__.<>t__builder.Start<FloroRanchDebugInfoPanel.<OnBeforeShowAsyncImplement>d__4>(ref <OnBeforeShowAsyncImplement>d__);
		return <OnBeforeShowAsyncImplement>d__.<>t__builder.Task;
	}

	// Token: 0x0600D3B4 RID: 54196 RVA: 0x00386B77 File Offset: 0x00384D77
	protected override void OnBeforeShow()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnFloroRanchDebugInfoRefresh, new Action(this.OnDebugInfoRefresh));
	}

	// Token: 0x0600D3B5 RID: 54197 RVA: 0x00386B95 File Offset: 0x00384D95
	protected override void OnBeforeHide()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnFloroRanchDebugInfoRefresh, new Action(this.OnDebugInfoRefresh));
	}

	// Token: 0x0600D3B6 RID: 54198 RVA: 0x00386BB3 File Offset: 0x00384DB3
	protected void OnClickCloseButton()
	{
		base.Hide(null);
	}

	// Token: 0x0600D3B7 RID: 54199 RVA: 0x00386BBC File Offset: 0x00384DBC
	[NullableContext(1)]
	protected FloroRanchDebugInfoItem InitItem()
	{
		return new FloroRanchDebugInfoItem();
	}

	// Token: 0x0600D3B8 RID: 54200 RVA: 0x00386BC4 File Offset: 0x00384DC4
	protected void OnDebugInfoRefresh()
	{
		List<string> actionInfoList = ModelBase<FloroRanchGamePlayModel>.Instance.ActionInfoList;
		this.LoopScrollView.RefreshByData(actionInfoList, false, null, false);
		this.LoopScrollView.ScrollToGridIndex(actionInfoList.Count - 1, true);
	}

	// Token: 0x040064C3 RID: 25795
	[Nullable(1)]
	protected LoopScrollView<FloroRanchDebugInfoItem, string> LoopScrollView;

	// Token: 0x02007F67 RID: 32615
	private class EComponent
	{
		// Token: 0x0402B5FB RID: 177659
		public const int CloseButton = 0;

		// Token: 0x0402B5FC RID: 177660
		public const int LoopScrollView = 1;

		// Token: 0x0402B5FD RID: 177661
		public const int TemplateActor = 2;
	}
}
