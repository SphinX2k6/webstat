using System;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.Plot.FlowActions
{
	// Token: 0x0200543C RID: 21564
	public class FlowActionShowCenterText : FlowActionBase
	{
		// Token: 0x06036FBF RID: 225215 RVA: 0x00DF5330 File Offset: 0x00DF3530
		protected unsafe override void OnExecute()
		{
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.Plot;
			ELogAuthor author = ELogAuthor.FZX;
			string message = "黑屏白字行为不再维护，请策划使用ShowTalk形式的黑幕白字";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("id", this.Context.FormatId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("action", this.ActionInfo.ActionId);
			instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			ShowCenterText inShowCenterText = this.ActionInfo.Params as ShowCenterText;
			ModelBase<PlotModel>.Instance.ShowCenterText(inShowCenterText, new Action(this.OnShowCenterTextFinished));
		}

		// Token: 0x06036FC0 RID: 225216 RVA: 0x00DF53D1 File Offset: 0x00DF35D1
		private void OnShowCenterTextFinished()
		{
			this.Runner.FinishShowCenterTextAction(delegate
			{
				base.FinishExecute(true, true);
			});
		}

		// Token: 0x06036FC1 RID: 225217 RVA: 0x00DF53EA File Offset: 0x00DF35EA
		protected override void OnInterruptExecute()
		{
			Singleton<EventSystem>.Instance.Emit(EEventName.OnPlotTransitionRemoveCallback);
			if (Singleton<UiManager>.Instance.IsViewShow(EUiViewName.PlotTransitionView))
			{
				Singleton<UiManager>.Instance.CloseView(EUiViewName.PlotTransitionView, null);
			}
			base.FinishExecute(true, true);
		}
	}
}
