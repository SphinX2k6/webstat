using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200248B RID: 9355
public class PhantomBattleFettersView : UiViewBase
{
	// Token: 0x06012279 RID: 74361 RVA: 0x004FE1A6 File Offset: 0x004FC3A6
	[NullableContext(1)]
	public PhantomBattleFettersView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0601227A RID: 74362 RVA: 0x004FE1AF File Offset: 0x004FC3AF
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem))
		};
	}

	// Token: 0x0601227B RID: 74363 RVA: 0x004FE1E8 File Offset: 0x004FC3E8
	protected override UniTask OnBeforeStartAsync()
	{
		PhantomBattleFettersView.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<PhantomBattleFettersView.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0601227C RID: 74364 RVA: 0x004FE22B File Offset: 0x004FC42B
	protected override void OnBeforeShow()
	{
		if (this.GroupId > 0)
		{
			this.ViewItem.SelectByFetterId(this.GroupId);
			this.GroupId = 0;
		}
	}

	// Token: 0x0601227D RID: 74365 RVA: 0x004FE250 File Offset: 0x004FC450
	private void OnFastFilter()
	{
		ModelBase<PhantomBattleModel>.Instance.CurrentSelectFetterGroupId = this.ViewItem.GetCurrentSelectGroupId();
		UiViewBase viewByName = Singleton<UiManager>.Instance.GetViewByName(EUiViewName.VisionEquipmentView);
		if (viewByName != null)
		{
			Singleton<UiManager>.Instance.CloseView(this.ViewInfo.Name, null);
			viewByName.SetActive(true);
			Singleton<EventSystem>.Instance.Emit(EEventName.VisionFilterMonster);
			return;
		}
		PhantomUtil.CloseAndOpenVisionEquipmentView(this.ViewInfo.Name, this.RoleId, -1);
	}

	// Token: 0x0601227E RID: 74366 RVA: 0x004FE2CC File Offset: 0x004FC4CC
	protected override UniTask OnPlayingStartSequenceAsync()
	{
		PhantomBattleFettersView.<OnPlayingStartSequenceAsync>d__10 <OnPlayingStartSequenceAsync>d__;
		<OnPlayingStartSequenceAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnPlayingStartSequenceAsync>d__.<>4__this = this;
		<OnPlayingStartSequenceAsync>d__.<>1__state = -1;
		<OnPlayingStartSequenceAsync>d__.<>t__builder.Start<PhantomBattleFettersView.<OnPlayingStartSequenceAsync>d__10>(ref <OnPlayingStartSequenceAsync>d__);
		return <OnPlayingStartSequenceAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0601227F RID: 74367 RVA: 0x004FE310 File Offset: 0x004FC510
	protected override UniTask OnPlayingCloseSequenceAsync()
	{
		PhantomBattleFettersView.<OnPlayingCloseSequenceAsync>d__11 <OnPlayingCloseSequenceAsync>d__;
		<OnPlayingCloseSequenceAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnPlayingCloseSequenceAsync>d__.<>4__this = this;
		<OnPlayingCloseSequenceAsync>d__.<>1__state = -1;
		<OnPlayingCloseSequenceAsync>d__.<>t__builder.Start<PhantomBattleFettersView.<OnPlayingCloseSequenceAsync>d__11>(ref <OnPlayingCloseSequenceAsync>d__);
		return <OnPlayingCloseSequenceAsync>d__.<>t__builder.Task;
	}

	// Token: 0x04008DA0 RID: 36256
	[Nullable(2)]
	private PhantomBattleFettersViewItem ViewItem;

	// Token: 0x04008DA1 RID: 36257
	[Nullable(2)]
	private PopupCaptionItem PopupCaptionItem;

	// Token: 0x04008DA2 RID: 36258
	private int RoleId;

	// Token: 0x04008DA3 RID: 36259
	private int GroupId;

	// Token: 0x020087A9 RID: 34729
	private enum EComponent
	{
		// Token: 0x0402DDBE RID: 187838
		CaptionItem,
		// Token: 0x0402DDBF RID: 187839
		ViewItem
	}
}
