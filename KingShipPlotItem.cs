using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Module.Plot.Flow;
using CSharpScript.Game.Module.Plot.PlotView;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020020A6 RID: 8358
internal class KingShipPlotItem : UiPanelBase
{
	// Token: 0x0600FF39 RID: 65337 RVA: 0x00461684 File Offset: 0x0045F884
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIScrollViewComponent)),
			new ValueTuple<int, Type>(9, typeof(UUIItem)),
			new ValueTuple<int, Type>(10, typeof(UUILayoutBase)),
			new ValueTuple<int, Type>(11, typeof(UUIItem)),
			new ValueTuple<int, Type>(12, typeof(UUISliderComponent))
		};
	}

	// Token: 0x0600FF3A RID: 65338 RVA: 0x004617C0 File Offset: 0x0045F9C0
	protected override UniTask OnBeforeStartAsync()
	{
		KingShipPlotItem.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<KingShipPlotItem.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600FF3B RID: 65339 RVA: 0x00461804 File Offset: 0x0045FA04
	[NullableContext(1)]
	public void RefreshPlot(List<string> flowId)
	{
		this.PlotDataList.Clear();
		this.CurrentShowPlotIndex = 0;
		List<ActionInfo> flowStateActions = ConfigBase<FlowConfig>.Instance.GetFlowStateActions(flowId[0], int.Parse(flowId[1]), int.Parse(flowId[2]));
		if (flowStateActions != null)
		{
			foreach (ActionInfo actionInfo in flowStateActions)
			{
				if (actionInfo.Name == EAction.ShowTalk)
				{
					foreach (ITalkItem item in ((ShowTalk)actionInfo.Params).TalkItems)
					{
						this.PlotDataList.Add(item);
					}
				}
			}
		}
		this.ShowPlot();
	}

	// Token: 0x0600FF3C RID: 65340 RVA: 0x004618F0 File Offset: 0x0045FAF0
	public void ShowPlot()
	{
		int count = this.PlotDataList.Count;
		if (this.CurrentShowPlotIndex >= count)
		{
			DynamicMaskButton maskButton = this.MaskButton;
			if (maskButton != null)
			{
				maskButton.SetUiActive(false);
			}
			Singleton<UiManager>.Instance.CloseView(EUiViewName.KingShipPlotView, null);
			return;
		}
		ITalkItem inPlotSubtitleInfo = this.PlotDataList[this.CurrentShowPlotIndex];
		PlotTextCommonLogic commonLogic = this.CommonLogic;
		if (commonLogic == null)
		{
			return;
		}
		commonLogic.UpdatePlotSubtitle(inPlotSubtitleInfo);
	}

	// Token: 0x0600FF3D RID: 65341 RVA: 0x00461958 File Offset: 0x0045FB58
	private void OnMaskBtnClick()
	{
		this.CurrentShowPlotIndex++;
		this.ShowPlot();
		Singleton<AudioSystem>.Instance.PostEvent("play_ui_ia_com_confirm");
	}

	// Token: 0x0600FF3E RID: 65342 RVA: 0x0046197E File Offset: 0x0045FB7E
	protected override void OnBeforeDestroy()
	{
		DynamicMaskButton maskButton = this.MaskButton;
		if (maskButton != null)
		{
			maskButton.Destroy(null);
		}
		PlotTextCommonLogic commonLogic = this.CommonLogic;
		if (commonLogic == null)
		{
			return;
		}
		commonLogic.Clear();
	}

	// Token: 0x0600FF3F RID: 65343 RVA: 0x004619A4 File Offset: 0x0045FBA4
	public UniTask DestroyPortraitItem()
	{
		KingShipPlotItem.<DestroyPortraitItem>d__11 <DestroyPortraitItem>d__;
		<DestroyPortraitItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<DestroyPortraitItem>d__.<>4__this = this;
		<DestroyPortraitItem>d__.<>1__state = -1;
		<DestroyPortraitItem>d__.<>t__builder.Start<KingShipPlotItem.<DestroyPortraitItem>d__11>(ref <DestroyPortraitItem>d__);
		return <DestroyPortraitItem>d__.<>t__builder.Task;
	}

	// Token: 0x04007A6E RID: 31342
	[Nullable(1)]
	private List<ITalkItem> PlotDataList = new List<ITalkItem>();

	// Token: 0x04007A6F RID: 31343
	private int CurrentShowPlotIndex;

	// Token: 0x04007A70 RID: 31344
	[Nullable(2)]
	private DynamicMaskButton MaskButton;

	// Token: 0x04007A71 RID: 31345
	[Nullable(2)]
	private PlotTextCommonLogic CommonLogic;

	// Token: 0x02008432 RID: 33842
	private class EKingShipPlotItemDefine
	{
		// Token: 0x0402CCE4 RID: 183524
		public const int NpcName = 0;

		// Token: 0x0402CCE5 RID: 183525
		public const int NpcTitle = 1;

		// Token: 0x0402CCE6 RID: 183526
		public const int Content = 2;

		// Token: 0x0402CCE7 RID: 183527
		public const int LineItem = 3;

		// Token: 0x0402CCE8 RID: 183528
		public const int PlotItem = 4;

		// Token: 0x0402CCE9 RID: 183529
		public const int LeftPoint = 5;

		// Token: 0x0402CCEA RID: 183530
		public const int RightPoint = 6;

		// Token: 0x0402CCEB RID: 183531
		public const int CenterPoint = 7;

		// Token: 0x0402CCEC RID: 183532
		public const int TextScrollView = 8;

		// Token: 0x0402CCED RID: 183533
		public const int OptionPanel = 9;

		// Token: 0x0402CCEE RID: 183534
		public const int OptionLayout = 10;

		// Token: 0x0402CCEF RID: 183535
		public const int OptionItem = 11;

		// Token: 0x0402CCF0 RID: 183536
		public const int OptionLimitBar = 12;
	}
}
