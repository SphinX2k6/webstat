using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001524 RID: 5412
[NullableContext(2)]
[Nullable(0)]
public class ActivityRegressMainSubViewBase : UiPanelBase
{
	// Token: 0x060097B1 RID: 38833 RVA: 0x0027C248 File Offset: 0x0027A448
	protected override void OnStart()
	{
		base.OnStart();
		UUIItem rootItem = base.GetRootItem();
		this.SequencePlayer = new UiSequencePlayer(rootItem);
	}

	// Token: 0x060097B2 RID: 38834 RVA: 0x0027C26E File Offset: 0x0027A46E
	[NullableContext(1)]
	public void BindPassRecallBaseCallBack(TRegressOnPassRecallBaseCallback callBack)
	{
		this.PassRecallBaseCallBack = callBack;
	}

	// Token: 0x060097B3 RID: 38835 RVA: 0x0027C277 File Offset: 0x0027A477
	public void UnBindPassRecallBaseCallBack()
	{
		this.PassRecallBaseCallBack = null;
	}

	// Token: 0x060097B4 RID: 38836 RVA: 0x0027C280 File Offset: 0x0027A480
	protected void InvokePassRecallBaseCallBack(RegressBase config, EActivityMainSubViewNewType subViewType)
	{
		TRegressOnPassRecallBaseCallback passRecallBaseCallBack = this.PassRecallBaseCallBack;
		if (passRecallBaseCallBack == null)
		{
			return;
		}
		passRecallBaseCallBack(config, subViewType);
	}

	// Token: 0x060097B5 RID: 38837 RVA: 0x0027C294 File Offset: 0x0027A494
	public void Update(int subTabIndex = 0)
	{
		this.OnUpdate(subTabIndex);
	}

	// Token: 0x060097B6 RID: 38838 RVA: 0x0027C29D File Offset: 0x0027A49D
	protected virtual void OnUpdate(int subTabIndex)
	{
	}

	// Token: 0x060097B7 RID: 38839 RVA: 0x0027C2A0 File Offset: 0x0027A4A0
	protected override void OnBeforeShow()
	{
		base.OnBeforeShow();
		this.SequencePlayer.StopSequenceByKey("Start", false, false);
		CustomPromise<bool> stopPromise = new CustomPromise<bool>();
		this.SequencePlayer.PlaySequenceAsync("Start", stopPromise, false, false, null);
	}

	// Token: 0x060097B8 RID: 38840 RVA: 0x0027C2E8 File Offset: 0x0027A4E8
	public virtual void OnParentShow()
	{
		this.SequencePlayer.StopSequenceByKey("Start", false, false);
		CustomPromise<bool> stopPromise = new CustomPromise<bool>();
		this.SequencePlayer.PlaySequenceAsync("Start", stopPromise, false, false, null);
	}

	// Token: 0x04004658 RID: 18008
	protected TRegressOnPassRecallBaseCallback PassRecallBaseCallBack;

	// Token: 0x04004659 RID: 18009
	protected UiSequencePlayer SequencePlayer;
}
