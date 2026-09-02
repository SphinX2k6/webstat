using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002765 RID: 10085
public class ReportView : UiViewBase
{
	// Token: 0x06013E66 RID: 81510 RVA: 0x0058B6FF File Offset: 0x005898FF
	[NullableContext(1)]
	public ReportView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06013E67 RID: 81511 RVA: 0x0058B710 File Offset: 0x00589910
	protected override void OnRegisterComponent()
	{
		base.OnRegisterComponent();
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(2, typeof(UUITextInputComponent)),
			new ValueTuple<int, Type>(3, typeof(UUILoopScrollViewComponent)),
			new ValueTuple<int, Type>(4, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action(this.OnClickCancelBtn)),
			new ValueTuple<int, Delegate>(1, new Action(this.OnClickConfirmBtn))
		};
	}

	// Token: 0x06013E68 RID: 81512 RVA: 0x0058B7D8 File Offset: 0x005899D8
	protected override void OnStart()
	{
		this.TargetPlayerInfo = (this.OpenParam as ReportPersonInfo);
		this.ReportInfoList = Singleton<ReportConfig>.Instance.GetReportConfigList();
		if (this.ReportInfoList == null)
		{
			this.ReportInfoList = Array.Empty<ReportPlayerInfo>();
		}
		this.ReportLayout = new LoopScrollView<ReportRowView, ReportPlayerInfo>(base.GetLoopScrollViewComponent(3), (AUIBaseActor)base.GetItem(4).GetOwner(), new Func<ReportRowView>(this.CreateGrid), false);
		if (this.ReportInfoList.Count > 0)
		{
			this.ReasonId = this.ReportInfoList[0].Id;
		}
		this.ReportLayout.ReloadData(this.ReportInfoList, false);
	}

	// Token: 0x06013E69 RID: 81513 RVA: 0x0058B883 File Offset: 0x00589A83
	protected override void OnBeforeDestroy()
	{
		if (this.ReportLayout != null)
		{
			this.ReportLayout.ClearGridProxies();
		}
	}

	// Token: 0x06013E6A RID: 81514 RVA: 0x0058B898 File Offset: 0x00589A98
	[NullableContext(1)]
	public ReportRowView CreateGrid()
	{
		ReportRowView reportRowView = new ReportRowView();
		reportRowView.SetToggleFunction(new Action<int>(this.OnToggleClick));
		return reportRowView;
	}

	// Token: 0x06013E6B RID: 81515 RVA: 0x0058B8B1 File Offset: 0x00589AB1
	private void OnClickCancelBtn()
	{
		Singleton<UiManager>.Instance.CloseView(EUiViewName.ReportView, null);
	}

	// Token: 0x06013E6C RID: 81516 RVA: 0x0058B8C4 File Offset: 0x00589AC4
	private void OnClickConfirmBtn()
	{
		UUITextInputComponent inputText = base.GetInputText(2);
		if (this.ReasonId == -1)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("ReportReasonNotSelect", Array.Empty<object>());
			return;
		}
		ReportController.ReportPlayerRequest(this.TargetPlayerInfo, this.ReasonId, inputText.GetText(), null);
	}

	// Token: 0x06013E6D RID: 81517 RVA: 0x0058B90F File Offset: 0x00589B0F
	private void OnToggleClick(int id)
	{
		this.ReasonId = id;
	}

	// Token: 0x04009ADF RID: 39647
	[Nullable(2)]
	private ReportPersonInfo TargetPlayerInfo;

	// Token: 0x04009AE0 RID: 39648
	private int ReasonId = -1;

	// Token: 0x04009AE1 RID: 39649
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private LoopScrollView<ReportRowView, ReportPlayerInfo> ReportLayout;

	// Token: 0x04009AE2 RID: 39650
	[Nullable(2)]
	private IReadOnlyList<ReportPlayerInfo> ReportInfoList;

	// Token: 0x02008B1D RID: 35613
	private static class EChildComponentType
	{
		// Token: 0x0402EE87 RID: 192135
		public const int CancelBtn = 0;

		// Token: 0x0402EE88 RID: 192136
		public const int ConfirmBtn = 1;

		// Token: 0x0402EE89 RID: 192137
		public const int ReportInputBox = 2;

		// Token: 0x0402EE8A RID: 192138
		public const int ReportContainer = 3;

		// Token: 0x0402EE8B RID: 192139
		public const int ReportRowTemplate = 4;
	}
}
