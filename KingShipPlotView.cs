using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020020A4 RID: 8356
public class KingShipPlotView : UiViewBase
{
	// Token: 0x0600FF33 RID: 65331 RVA: 0x00461553 File Offset: 0x0045F753
	[NullableContext(1)]
	public KingShipPlotView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600FF34 RID: 65332 RVA: 0x0046155C File Offset: 0x0045F75C
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUITexture)),
			new ValueTuple<int, Type>(1, typeof(UUIItem))
		};
	}

	// Token: 0x0600FF35 RID: 65333 RVA: 0x00461598 File Offset: 0x0045F798
	protected override UniTask OnBeforeStartAsync()
	{
		KingShipPlotView.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<KingShipPlotView.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600FF36 RID: 65334 RVA: 0x004615DC File Offset: 0x0045F7DC
	protected override void OnStart()
	{
		IKingShipPlotViewData kingShipPlotViewData = (IKingShipPlotViewData)this.OpenParam;
		KingShipPlotItem kingShipPlotItem = this.KingShipPlotItem;
		if (kingShipPlotItem != null)
		{
			kingShipPlotItem.RefreshPlot(kingShipPlotViewData.FlowId);
		}
		base.SetTextureByPath(kingShipPlotViewData.Path, base.GetTexture(0), null, null);
	}

	// Token: 0x0600FF37 RID: 65335 RVA: 0x00461629 File Offset: 0x0045F829
	protected override void OnBeforeDestroy()
	{
		((IKingShipPlotViewData)this.OpenParam).OnCloseCallBack();
	}

	// Token: 0x0600FF38 RID: 65336 RVA: 0x00461640 File Offset: 0x0045F840
	protected override UniTask OnPlayingCloseSequenceAsync()
	{
		KingShipPlotView.<OnPlayingCloseSequenceAsync>d__7 <OnPlayingCloseSequenceAsync>d__;
		<OnPlayingCloseSequenceAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnPlayingCloseSequenceAsync>d__.<>4__this = this;
		<OnPlayingCloseSequenceAsync>d__.<>1__state = -1;
		<OnPlayingCloseSequenceAsync>d__.<>t__builder.Start<KingShipPlotView.<OnPlayingCloseSequenceAsync>d__7>(ref <OnPlayingCloseSequenceAsync>d__);
		return <OnPlayingCloseSequenceAsync>d__.<>t__builder.Task;
	}

	// Token: 0x04007A6C RID: 31340
	[Nullable(2)]
	private KingShipPlotItem KingShipPlotItem;

	// Token: 0x0200842F RID: 33839
	private class EComponentDefine
	{
		// Token: 0x0402CCDA RID: 183514
		public const int BgTexture = 0;

		// Token: 0x0402CCDB RID: 183515
		public const int PlotItem = 1;
	}
}
