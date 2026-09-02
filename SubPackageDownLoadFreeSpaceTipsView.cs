using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using CSharpScript.Launcher.DiffPatch.Update;
using CSharpScript.Launcher.Update.ResourceDiffUpdate;
using UnrealEngine;

// Token: 0x02002AA9 RID: 10921
public class SubPackageDownLoadFreeSpaceTipsView : UiViewBase
{
	// Token: 0x06015DAC RID: 89516 RVA: 0x00610783 File Offset: 0x0060E983
	[NullableContext(1)]
	public SubPackageDownLoadFreeSpaceTipsView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06015DAD RID: 89517 RVA: 0x0061078C File Offset: 0x0060E98C
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(3, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(4, typeof(UUIText)),
			new ValueTuple<int, Type>(5, typeof(UUIText)),
			new ValueTuple<int, Type>(6, typeof(UUIText))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(2, new Action(this.OnClickCancelBtn)),
			new ValueTuple<int, Delegate>(3, new Action(this.OnClickConfirmBtn))
		};
	}

	// Token: 0x06015DAE RID: 89518 RVA: 0x00610879 File Offset: 0x0060EA79
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnRefreshSubPackClearData, new Action(this.OnRefreshSubPackClearData));
	}

	// Token: 0x06015DAF RID: 89519 RVA: 0x00610897 File Offset: 0x0060EA97
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnRefreshSubPackClearData, new Action(this.OnRefreshSubPackClearData));
	}

	// Token: 0x06015DB0 RID: 89520 RVA: 0x006108B8 File Offset: 0x0060EAB8
	protected override void OnStart()
	{
		this.TargetSubPackageId = (int)this.OpenParam;
		ModelBase<SubPackageDownLoadModel>.Instance.HaveTipsOutOfSpaceList.Add(this.TargetSubPackageId);
		long subPackageSpace = ModelBase<SubPackageDownLoadModel>.Instance.GetSubPackageSpace(this.TargetSubPackageId);
		long subPackageHaveDownLoadSpace = ModelBase<SubPackageDownLoadModel>.Instance.GetSubPackageHaveDownLoadSpace(this.TargetSubPackageId);
		long requiredSpace = subPackageSpace - subPackageHaveDownLoadSpace;
		ControllerBase<SubPackageController>.Instance.ReportSubPackageOutOfSpaceLogEvent(this.TargetSubPackageId, requiredSpace, Singleton<VideoResUpdate>.Instance.GetFreeSpace());
	}

	// Token: 0x06015DB1 RID: 89521 RVA: 0x0061092A File Offset: 0x0060EB2A
	protected override void OnBeforeShow()
	{
		this.RefreshView();
		this.RefreshButton();
	}

	// Token: 0x06015DB2 RID: 89522 RVA: 0x00610938 File Offset: 0x0060EB38
	private void OnClickCancelBtn()
	{
		if (ModelBase<SubPackageDownLoadModel>.Instance.GetAllCanClearSpace() > 0L && Singleton<ResourceDiffUpdaterManager>.Instance.IsGrayBoxHit())
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.SubPackageDownLoadMobileClearPopView, this.TargetSubPackageId, null);
			return;
		}
		base.CloseMe(null);
	}

	// Token: 0x06015DB3 RID: 89523 RVA: 0x00610978 File Offset: 0x0060EB78
	private void OnClickConfirmBtn()
	{
		long freeSpace = Singleton<VideoResUpdate>.Instance.GetFreeSpace();
		long subPackageSpace = ModelBase<SubPackageDownLoadModel>.Instance.GetSubPackageSpace(this.TargetSubPackageId);
		long subPackageHaveDownLoadSpace = ModelBase<SubPackageDownLoadModel>.Instance.GetSubPackageHaveDownLoadSpace(this.TargetSubPackageId);
		long num = subPackageSpace - subPackageHaveDownLoadSpace;
		if (freeSpace > num)
		{
			ControllerBase<SubPackageController>.Instance.PrioritySubPackageDownLoading(new List<int>
			{
				this.TargetSubPackageId
			}, null);
			base.CloseMe(null);
			return;
		}
		this.RefreshView();
		this.RefreshButton();
	}

	// Token: 0x06015DB4 RID: 89524 RVA: 0x006109E8 File Offset: 0x0060EBE8
	private void RefreshView()
	{
		long subPackageSpace = ModelBase<SubPackageDownLoadModel>.Instance.GetSubPackageSpace(this.TargetSubPackageId);
		long subPackageHaveDownLoadSpace = ModelBase<SubPackageDownLoadModel>.Instance.GetSubPackageHaveDownLoadSpace(this.TargetSubPackageId);
		long byteValue = subPackageSpace - subPackageHaveDownLoadSpace;
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), "DownLoadText_NeedSpace", new <>z__ReadOnlySingleElementList<object>(ModelBase<SubPackageDownLoadModel>.Instance.ByteConverter(byteValue)));
		long freeSpace = Singleton<VideoResUpdate>.Instance.GetFreeSpace();
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), "DownLoadText_LeftSpace", new <>z__ReadOnlySingleElementList<object>("<color=#c25757>" + ModelBase<SubPackageDownLoadModel>.Instance.ByteConverter(freeSpace) + "</color>"));
	}

	// Token: 0x06015DB5 RID: 89525 RVA: 0x00610A80 File Offset: 0x0060EC80
	private void RefreshButton()
	{
		long allCanClearSpace = ModelBase<SubPackageDownLoadModel>.Instance.GetAllCanClearSpace();
		if (allCanClearSpace > 0L && Singleton<ResourceDiffUpdaterManager>.Instance.IsGrayBoxHit())
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(6), "SubPackageCanClearButton", new <>z__ReadOnlySingleElementList<object>(ModelBase<SubPackageDownLoadModel>.Instance.ByteConverter(allCanClearSpace)));
		}
		else
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(6), "SubPackageHaveNoSpaceClear", Array.Empty<object>());
		}
		base.GetButton(2).SetSelfInteractive(allCanClearSpace > 0L);
	}

	// Token: 0x06015DB6 RID: 89526 RVA: 0x00610AFD File Offset: 0x0060ECFD
	private void OnRefreshSubPackClearData()
	{
		this.RefreshView();
		this.RefreshButton();
	}

	// Token: 0x0400A7AC RID: 42924
	private int TargetSubPackageId;

	// Token: 0x02008E1B RID: 36379
	private class EComponentDefine
	{
		// Token: 0x0402FCED RID: 195821
		public const int NeedSpaceText = 0;

		// Token: 0x0402FCEE RID: 195822
		public const int LeftSpaceText = 1;

		// Token: 0x0402FCEF RID: 195823
		public const int CancelBtn = 2;

		// Token: 0x0402FCF0 RID: 195824
		public const int ConfirmBtn = 3;

		// Token: 0x0402FCF1 RID: 195825
		public const int TitleText = 4;

		// Token: 0x0402FCF2 RID: 195826
		public const int DesText = 5;

		// Token: 0x0402FCF3 RID: 195827
		public const int CloseBtnText = 6;
	}
}
