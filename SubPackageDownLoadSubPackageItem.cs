using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002AB1 RID: 10929
internal class SubPackageDownLoadSubPackageItem : UiPanelBase
{
	// Token: 0x06015DD9 RID: 89561 RVA: 0x00611A70 File Offset: 0x0060FC70
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(3, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(4, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(5, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(6, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIItem)),
			new ValueTuple<int, Type>(9, typeof(UUIItem)),
			new ValueTuple<int, Type>(10, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(2, new Action(this.OnClickStartBtn)),
			new ValueTuple<int, Delegate>(3, new Action(this.OnClickDownLoadBtn)),
			new ValueTuple<int, Delegate>(4, new Action(this.OnClickStopBtn)),
			new ValueTuple<int, Delegate>(5, new Action(this.OnClickCancelBtn)),
			new ValueTuple<int, Delegate>(6, new Action(this.OnClickPriorityBtn))
		};
	}

	// Token: 0x06015DDA RID: 89562 RVA: 0x00611BFF File Offset: 0x0060FDFF
	protected override void OnStart()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnRefreshSubPackDownLoadState, new Action(this.OnRefreshSubPackDownLoadState));
	}

	// Token: 0x06015DDB RID: 89563 RVA: 0x00611C1D File Offset: 0x0060FE1D
	protected override void OnBeforeDestroy()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnRefreshSubPackDownLoadState, new Action(this.OnRefreshSubPackDownLoadState));
	}

	// Token: 0x06015DDC RID: 89564 RVA: 0x00611C3C File Offset: 0x0060FE3C
	public void RefreshItem(int id)
	{
		this.SubPackageId = id;
		DownLoadSubPackage? downLoadSubPackageById = ConfigBase<SubPackageConfig>.Instance.GetDownLoadSubPackageById(this.SubPackageId);
		if (downLoadSubPackageById == null)
		{
			return;
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), downLoadSubPackageById.Value.Title, Array.Empty<object>());
		this.RefreshState();
		this.RefreshProgressText();
	}

	// Token: 0x06015DDD RID: 89565 RVA: 0x00611C9C File Offset: 0x0060FE9C
	public void RefreshState()
	{
		this.State = ModelBase<SubPackageDownLoadModel>.Instance.GetSubPackageDownLoadItemStateById(this.SubPackageId);
		base.GetButton(2).RootUIComp.Get().SetUIActive(this.State == ESubPackageDownLoadState.Pause);
		base.GetButton(3).RootUIComp.Get().SetUIActive(this.State == ESubPackageDownLoadState.None);
		base.GetButton(4).RootUIComp.Get().SetUIActive(this.State == ESubPackageDownLoadState.DownLoading);
		base.GetButton(5).RootUIComp.Get().SetUIActive(this.State == ESubPackageDownLoadState.DownLoading || this.State == ESubPackageDownLoadState.Waiting || this.State == ESubPackageDownLoadState.Pause);
		base.GetButton(6).RootUIComp.Get().SetUIActive(this.State == ESubPackageDownLoadState.Waiting && ModelBase<SubPackageDownLoadModel>.Instance.IsKeyPackageDownLoadingFinish());
		base.GetItem(7).SetUIActive(this.State == ESubPackageDownLoadState.Waiting && !ModelBase<SubPackageDownLoadModel>.Instance.IsKeyPackageDownLoadingFinish());
		bool flag = this.State == ESubPackageDownLoadState.Finish;
		base.GetItem(8).SetUIActive(flag);
		UUIItem item = base.GetItem(9);
		UUIItem uuiitem = item;
		bool bUseChangeColor = flag;
		FColor? fcolor = new FColor?(item.changeColor);
		uuiitem.SetChangeColor(bUseChangeColor, fcolor);
		UUIText text = base.GetText(0);
		UUIItem uuiitem2 = text;
		bool bUseChangeColor2 = flag;
		fcolor = new FColor?(text.changeColor);
		uuiitem2.SetChangeColor(bUseChangeColor2, fcolor);
		UUIText text2 = base.GetText(1);
		UUIItem uuiitem3 = text2;
		bool bUseChangeColor3 = flag;
		fcolor = new FColor?(text2.changeColor);
		uuiitem3.SetChangeColor(bUseChangeColor3, fcolor);
	}

	// Token: 0x06015DDE RID: 89566 RVA: 0x00611E28 File Offset: 0x00610028
	private void RefreshProgressText()
	{
		long subPackageHaveDownLoadSpace = ModelBase<SubPackageDownLoadModel>.Instance.GetSubPackageHaveDownLoadSpace(this.SubPackageId);
		long subPackageSpace = ModelBase<SubPackageDownLoadModel>.Instance.GetSubPackageSpace(this.SubPackageId);
		if (subPackageHaveDownLoadSpace <= 0L || this.State == ESubPackageDownLoadState.Finish)
		{
			base.GetText(1).SetText(ModelBase<SubPackageDownLoadModel>.Instance.ByteConverter(subPackageSpace), true);
			return;
		}
		base.GetText(1).SetText(ModelBase<SubPackageDownLoadModel>.Instance.ByteConverter(subPackageHaveDownLoadSpace) + "/" + ModelBase<SubPackageDownLoadModel>.Instance.ByteConverter(subPackageSpace), true);
	}

	// Token: 0x06015DDF RID: 89567 RVA: 0x00611EAB File Offset: 0x006100AB
	public void RefreshDownLoadStateByTime()
	{
		if (this.State == ESubPackageDownLoadState.DownLoading)
		{
			this.RefreshProgressText();
		}
	}

	// Token: 0x06015DE0 RID: 89568 RVA: 0x00611EBC File Offset: 0x006100BC
	[NullableContext(1)]
	public UUIItem GetBtnItem()
	{
		return base.GetItem(10);
	}

	// Token: 0x06015DE1 RID: 89569 RVA: 0x00611EC6 File Offset: 0x006100C6
	private void OnClickStartBtn()
	{
		Action onClickBtn = this.OnClickBtn;
		if (onClickBtn != null)
		{
			onClickBtn();
		}
		ControllerBase<SubPackageController>.Instance.RestartSubPackageDownLoading(this.SubPackageId, new Action(this.RefreshDownLoadState));
	}

	// Token: 0x06015DE2 RID: 89570 RVA: 0x00611EF8 File Offset: 0x006100F8
	private void OnClickDownLoadBtn()
	{
		Action onClickBtn = this.OnClickBtn;
		if (onClickBtn != null)
		{
			onClickBtn();
		}
		if (ModelBase<SubPackageDownLoadModel>.Instance.IsKeyPackageDownLoading())
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("SubPackageDownLoad_Des_WaitKeyItemDownLoad", Array.Empty<object>());
		}
		ControllerBase<SubPackageController>.Instance.PushSubPackageDownLoading(new List<int>
		{
			this.SubPackageId
		}, new Action(this.RefreshDownLoadState));
	}

	// Token: 0x06015DE3 RID: 89571 RVA: 0x00611F5E File Offset: 0x0061015E
	private void OnClickStopBtn()
	{
		Action onClickBtn = this.OnClickBtn;
		if (onClickBtn != null)
		{
			onClickBtn();
		}
		ControllerBase<SubPackageController>.Instance.StopSubPackageDownLoading(this.SubPackageId, new Action(this.RefreshDownLoadState));
	}

	// Token: 0x06015DE4 RID: 89572 RVA: 0x00611F8D File Offset: 0x0061018D
	private void OnClickCancelBtn()
	{
		Action onClickBtn = this.OnClickBtn;
		if (onClickBtn != null)
		{
			onClickBtn();
		}
		ControllerBase<SubPackageController>.Instance.CancelSubPackageDownLoading(this.SubPackageId);
		this.RefreshDownLoadState();
	}

	// Token: 0x06015DE5 RID: 89573 RVA: 0x00611FB6 File Offset: 0x006101B6
	private void OnClickPriorityBtn()
	{
		Action onClickBtn = this.OnClickBtn;
		if (onClickBtn != null)
		{
			onClickBtn();
		}
		ControllerBase<SubPackageController>.Instance.PrioritySubPackageDownLoading(new List<int>
		{
			this.SubPackageId
		}, new Action(this.RefreshDownLoadState));
	}

	// Token: 0x06015DE6 RID: 89574 RVA: 0x00611FF1 File Offset: 0x006101F1
	private void RefreshDownLoadState()
	{
		Singleton<EventSystem>.Instance.Emit(EEventName.OnRefreshSubPackDownLoadState);
	}

	// Token: 0x06015DE7 RID: 89575 RVA: 0x00612003 File Offset: 0x00610203
	private void OnRefreshSubPackDownLoadState()
	{
		if (this.SubPackageId == 0)
		{
			return;
		}
		this.RefreshState();
		this.RefreshProgressText();
	}

	// Token: 0x0400A7E0 RID: 42976
	[Nullable(2)]
	public Action OnClickBtn;

	// Token: 0x0400A7E1 RID: 42977
	private int SubPackageId;

	// Token: 0x0400A7E2 RID: 42978
	private ESubPackageDownLoadState State = ESubPackageDownLoadState.None;
}
