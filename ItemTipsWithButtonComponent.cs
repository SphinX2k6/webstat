using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.SkipInterface;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001999 RID: 6553
[NullableContext(1)]
[Nullable(0)]
public class ItemTipsWithButtonComponent : UiPanelBase
{
	// Token: 0x0600BC27 RID: 48167 RVA: 0x0031F170 File Offset: 0x0031D370
	protected unsafe override void OnRegisterComponent()
	{
		int num = 6;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIHorizontalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIButtonComponent));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(5, new Action(this.OnClickPreview));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600BC28 RID: 48168 RVA: 0x0031F29C File Offset: 0x0031D49C
	protected override UniTask OnBeforeStartAsync()
	{
		ItemTipsWithButtonComponent.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ItemTipsWithButtonComponent.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600BC29 RID: 48169 RVA: 0x0031F2DF File Offset: 0x0031D4DF
	protected override void OnStart()
	{
		this.ButtonLayout = new GenericLayout<LayoutButtonItem, ButtonItemData>(base.GetHorizontalLayout(1), this.InitGridItem, base.GetItem(2).GetOwner() as AUIBaseActor, false, true);
	}

	// Token: 0x0600BC2A RID: 48170 RVA: 0x0031F30C File Offset: 0x0031D50C
	protected override void OnBeforeDestroy()
	{
		this.ItemTipsComponentContentComponent.Destroy(null);
		this.ButtonLayout.ClearChildren();
	}

	// Token: 0x0600BC2B RID: 48171 RVA: 0x0031F325 File Offset: 0x0031D525
	public void RefreshTips(ItemTipsData tipsData)
	{
		this.ItemTipsComponentContentComponent.Refresh(tipsData);
	}

	// Token: 0x0600BC2C RID: 48172 RVA: 0x0031F334 File Offset: 0x0031D534
	public void RefreshButton(List<IButtonInfo> buttonData)
	{
		this.ReloadFinishState = new CustomPromise();
		List<ButtonItemData> list = new List<ButtonItemData>();
		foreach (IButtonInfo buttonInfo in buttonData)
		{
			list.Add(new ButtonItemData
			{
				OnClickCallback = buttonInfo.Function,
				ButtonText = buttonInfo.Text,
				RedDotName = buttonInfo.RedDotName,
				Index = buttonInfo.Index
			});
		}
		this.ButtonLayout.RefreshByData(list, delegate
		{
			if (!this.ReloadFinishState.IsFulfilled)
			{
				CustomPromise reloadFinishState = this.ReloadFinishState;
				if (reloadFinishState == null)
				{
					return;
				}
				reloadFinishState.SetResult();
			}
		}, false);
	}

	// Token: 0x0600BC2D RID: 48173 RVA: 0x0031F3E4 File Offset: 0x0031D5E4
	public void ClearButtonList()
	{
		this.ButtonLayout.RefreshByData(new List<ButtonItemData>(), null, false);
	}

	// Token: 0x0600BC2E RID: 48174 RVA: 0x0031F3F8 File Offset: 0x0031D5F8
	public UniTask SetButtonTextByIndex(int index, string text, [Nullable(new byte[]
	{
		2,
		1
	})] string[] textParams = null)
	{
		ItemTipsWithButtonComponent.<SetButtonTextByIndex>d__13 <SetButtonTextByIndex>d__;
		<SetButtonTextByIndex>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<SetButtonTextByIndex>d__.<>4__this = this;
		<SetButtonTextByIndex>d__.index = index;
		<SetButtonTextByIndex>d__.text = text;
		<SetButtonTextByIndex>d__.textParams = textParams;
		<SetButtonTextByIndex>d__.<>1__state = -1;
		<SetButtonTextByIndex>d__.<>t__builder.Start<ItemTipsWithButtonComponent.<SetButtonTextByIndex>d__13>(ref <SetButtonTextByIndex>d__);
		return <SetButtonTextByIndex>d__.<>t__builder.Task;
	}

	// Token: 0x0600BC2F RID: 48175 RVA: 0x0031F454 File Offset: 0x0031D654
	public UniTask SetButtonEnableByIndex(int index, bool bEnable)
	{
		ItemTipsWithButtonComponent.<SetButtonEnableByIndex>d__14 <SetButtonEnableByIndex>d__;
		<SetButtonEnableByIndex>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<SetButtonEnableByIndex>d__.<>4__this = this;
		<SetButtonEnableByIndex>d__.index = index;
		<SetButtonEnableByIndex>d__.bEnable = bEnable;
		<SetButtonEnableByIndex>d__.<>1__state = -1;
		<SetButtonEnableByIndex>d__.<>t__builder.Start<ItemTipsWithButtonComponent.<SetButtonEnableByIndex>d__14>(ref <SetButtonEnableByIndex>d__);
		return <SetButtonEnableByIndex>d__.<>t__builder.Task;
	}

	// Token: 0x0600BC30 RID: 48176 RVA: 0x0031F4A8 File Offset: 0x0031D6A8
	public void SetButtonPanelVisible(bool isVisible)
	{
		base.GetHorizontalLayout(1).RootUIComp.Get().SetUIActive(isVisible);
	}

	// Token: 0x0600BC31 RID: 48177 RVA: 0x0031F4D0 File Offset: 0x0031D6D0
	public UniTask SetButtonRedDotVisible(int index, bool bVisible)
	{
		ItemTipsWithButtonComponent.<SetButtonRedDotVisible>d__16 <SetButtonRedDotVisible>d__;
		<SetButtonRedDotVisible>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<SetButtonRedDotVisible>d__.<>4__this = this;
		<SetButtonRedDotVisible>d__.index = index;
		<SetButtonRedDotVisible>d__.bVisible = bVisible;
		<SetButtonRedDotVisible>d__.<>1__state = -1;
		<SetButtonRedDotVisible>d__.<>t__builder.Start<ItemTipsWithButtonComponent.<SetButtonRedDotVisible>d__16>(ref <SetButtonRedDotVisible>d__);
		return <SetButtonRedDotVisible>d__.<>t__builder.Task;
	}

	// Token: 0x0600BC32 RID: 48178 RVA: 0x0031F523 File Offset: 0x0031D723
	public void SetVisible(bool isShow)
	{
		this.SetActive(isShow);
	}

	// Token: 0x0600BC33 RID: 48179 RVA: 0x0031F52C File Offset: 0x0031D72C
	public void SetTipsComponentLockButton(bool isShow)
	{
		this.ItemTipsComponentContentComponent.SetTipsComponentLockButton(isShow);
	}

	// Token: 0x0600BC34 RID: 48180 RVA: 0x0031F53A File Offset: 0x0031D73A
	[NullableContext(2)]
	public void SetLockStateData(IItemTipsLockStateData data = null)
	{
		this.LockState.UpdateData(data);
	}

	// Token: 0x0600BC35 RID: 48181 RVA: 0x0031F548 File Offset: 0x0031D748
	public void SetLockStateVisible(bool isShow = false)
	{
		this.LockState.SetActive(isShow);
	}

	// Token: 0x0600BC36 RID: 48182 RVA: 0x0031F556 File Offset: 0x0031D756
	public void SetPreviewVisible(bool isPreview = false)
	{
		base.GetItem(4).SetUIActive(isPreview);
	}

	// Token: 0x0600BC37 RID: 48183 RVA: 0x0031F568 File Offset: 0x0031D768
	private void OnClickPreview()
	{
		ESkipName tipsPreviewType = this.ItemTipsComponentContentComponent.GetTipsPreviewType();
		int tipsItemConfigId = this.ItemTipsComponentContentComponent.GetTipsItemConfigId();
		SkipTaskManager.Run(tipsPreviewType, new object[]
		{
			tipsItemConfigId
		});
	}

	// Token: 0x04005918 RID: 22808
	[Nullable(2)]
	private ItemTipsComponentContentComponent ItemTipsComponentContentComponent;

	// Token: 0x04005919 RID: 22809
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<LayoutButtonItem, ButtonItemData> ButtonLayout;

	// Token: 0x0400591A RID: 22810
	[Nullable(2)]
	private CustomPromise ReloadFinishState;

	// Token: 0x0400591B RID: 22811
	[Nullable(2)]
	private ItemTipsLockState LockState;

	// Token: 0x0400591C RID: 22812
	private readonly Func<LayoutButtonItem> InitGridItem = () => new LayoutButtonItem();

	// Token: 0x02007C96 RID: 31894
	[NullableContext(0)]
	private enum EItemTipsWithButtonNode
	{
		// Token: 0x0402A8AA RID: 174250
		TipsItem,
		// Token: 0x0402A8AB RID: 174251
		PanelBtn,
		// Token: 0x0402A8AC RID: 174252
		Button,
		// Token: 0x0402A8AD RID: 174253
		LockState,
		// Token: 0x0402A8AE RID: 174254
		PanelPreview,
		// Token: 0x0402A8AF RID: 174255
		BtnPreview
	}
}
