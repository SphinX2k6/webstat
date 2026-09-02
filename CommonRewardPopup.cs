using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020018A8 RID: 6312
[NullableContext(1)]
[Nullable(0)]
public class CommonRewardPopup : UiPanelBase
{
	// Token: 0x0600B551 RID: 46417 RVA: 0x003044FE File Offset: 0x003026FE
	public CommonRewardPopup(UUIItem parentItem)
	{
		base.CreateByResourceIdAsync("UiItem_RewardPopup", parentItem, false);
	}

	// Token: 0x0600B552 RID: 46418 RVA: 0x00304520 File Offset: 0x00302720
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIHorizontalLayout)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIButtonComponent))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(3, new Action(this.OnMaskBtnClick))
		};
	}

	// Token: 0x0600B553 RID: 46419 RVA: 0x003045B3 File Offset: 0x003027B3
	protected override void OnBeforeCreateImplement()
	{
		this.Sequence = new UiBehaviorLevelSequence(this);
		base.AddUiBehavior(this.Sequence);
	}

	// Token: 0x0600B554 RID: 46420 RVA: 0x003045D0 File Offset: 0x003027D0
	protected override void OnStart()
	{
		this.RewardPanel = new GenericLayout<RewardPanelItem, DailyActivityDefine.RewardTuple>(base.GetHorizontalLayout(0), new Func<RewardPanelItem>(this.CreateRewardItem), null, false, true);
		this.SetActive(false);
		foreach (Action action in this.OperationMap.Values)
		{
			action();
		}
	}

	// Token: 0x0600B555 RID: 46421 RVA: 0x00304650 File Offset: 0x00302850
	protected override UniTask OnShowAsyncImplementImplement()
	{
		CommonRewardPopup.<OnShowAsyncImplementImplement>d__9 <OnShowAsyncImplementImplement>d__;
		<OnShowAsyncImplementImplement>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnShowAsyncImplementImplement>d__.<>4__this = this;
		<OnShowAsyncImplementImplement>d__.<>1__state = -1;
		<OnShowAsyncImplementImplement>d__.<>t__builder.Start<CommonRewardPopup.<OnShowAsyncImplementImplement>d__9>(ref <OnShowAsyncImplementImplement>d__);
		return <OnShowAsyncImplementImplement>d__.<>t__builder.Task;
	}

	// Token: 0x0600B556 RID: 46422 RVA: 0x00304694 File Offset: 0x00302894
	protected override UniTask OnHideAsyncImplementImplement()
	{
		CommonRewardPopup.<OnHideAsyncImplementImplement>d__10 <OnHideAsyncImplementImplement>d__;
		<OnHideAsyncImplementImplement>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnHideAsyncImplementImplement>d__.<>4__this = this;
		<OnHideAsyncImplementImplement>d__.<>1__state = -1;
		<OnHideAsyncImplementImplement>d__.<>t__builder.Start<CommonRewardPopup.<OnHideAsyncImplementImplement>d__10>(ref <OnHideAsyncImplementImplement>d__);
		return <OnHideAsyncImplementImplement>d__.<>t__builder.Task;
	}

	// Token: 0x0600B557 RID: 46423 RVA: 0x003046D7 File Offset: 0x003028D7
	protected override void OnBeforeDestroy()
	{
		this.RewardPanel.ClearChildren();
		this.RewardPanel = null;
		this.PopUpData = null;
		this.OperationMap.Clear();
	}

	// Token: 0x0600B558 RID: 46424 RVA: 0x003046FD File Offset: 0x003028FD
	public void Refresh(RewardPopupData data)
	{
		this.PopUpData = data;
		if (base.InAsyncLoading())
		{
			this.OperationMap.Add("Refresh", new Action(this.<Refresh>g__callback|12_0));
			return;
		}
		this.<Refresh>g__callback|12_0();
	}

	// Token: 0x0600B559 RID: 46425 RVA: 0x00304731 File Offset: 0x00302931
	private RewardPanelItem CreateRewardItem()
	{
		return new RewardPanelItem();
	}

	// Token: 0x0600B55A RID: 46426 RVA: 0x00304738 File Offset: 0x00302938
	private void OnMaskBtnClick()
	{
		this.SetActive(false);
	}

	// Token: 0x0600B55B RID: 46427 RVA: 0x00304744 File Offset: 0x00302944
	[CompilerGenerated]
	private void <Refresh>g__callback|12_0()
	{
		if (this.PopUpData.RewardLists.Count == 0)
		{
			return;
		}
		FVector fvector = this.PopUpData.MountItem.GetLGUISpaceAbsolutePosition();
		if (this.PopUpData.PosBias != null)
		{
			FVector value = this.PopUpData.PosBias.Value;
			fvector = fvector + value;
		}
		base.GetItem(2).SetLGUISpaceAbsolutePosition(fvector);
		this.RewardPanel.RefreshByDataAsync(this.PopUpData.RewardLists, false, null).ContinueWith(delegate()
		{
			this.SetActive(true);
		});
	}

	// Token: 0x0400559C RID: 21916
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<RewardPanelItem, DailyActivityDefine.RewardTuple> RewardPanel;

	// Token: 0x0400559D RID: 21917
	[Nullable(2)]
	private RewardPopupData PopUpData;

	// Token: 0x0400559E RID: 21918
	private readonly Dictionary<string, Action> OperationMap = new Dictionary<string, Action>();

	// Token: 0x0400559F RID: 21919
	[Nullable(2)]
	private UiBehaviorLevelSequence Sequence;

	// Token: 0x02007C31 RID: 31793
	[NullableContext(0)]
	private enum EPopupComponent
	{
		// Token: 0x0402A6B1 RID: 173745
		PanelLayout,
		// Token: 0x0402A6B2 RID: 173746
		RewardItem,
		// Token: 0x0402A6B3 RID: 173747
		Panel,
		// Token: 0x0402A6B4 RID: 173748
		MaskBtn
	}
}
