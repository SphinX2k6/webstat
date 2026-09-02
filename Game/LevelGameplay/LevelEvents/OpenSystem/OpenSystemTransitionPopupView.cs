using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Module.Plot.PlotView;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents.OpenSystem
{
	// Token: 0x02006C97 RID: 27799
	[NullableContext(1)]
	[Nullable(0)]
	public class OpenSystemTransitionPopupView : OpenSystemBase
	{
		// Token: 0x06044317 RID: 279319 RVA: 0x011B3513 File Offset: 0x011B1713
		public OpenSystemTransitionPopupView(LevelEventOpenSystem eventBase) : base(eventBase)
		{
		}

		// Token: 0x06044318 RID: 279320 RVA: 0x011B351C File Offset: 0x011B171C
		[return: Nullable(0)]
		public override UniTask<bool> ExecuteOpenView(OpenSystemBoard inParams, GeneralContext context)
		{
			OpenSystemTransitionPopupView.<ExecuteOpenView>d__1 <ExecuteOpenView>d__;
			<ExecuteOpenView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<ExecuteOpenView>d__.<>4__this = this;
			<ExecuteOpenView>d__.inParams = inParams;
			<ExecuteOpenView>d__.context = context;
			<ExecuteOpenView>d__.<>1__state = -1;
			<ExecuteOpenView>d__.<>t__builder.Start<OpenSystemTransitionPopupView.<ExecuteOpenView>d__1>(ref <ExecuteOpenView>d__);
			return <ExecuteOpenView>d__.<>t__builder.Task;
		}

		// Token: 0x06044319 RID: 279321 RVA: 0x011B3570 File Offset: 0x011B1770
		[NullableContext(2)]
		public override EUiViewName? GetViewName(OpenSystemBoard inParams = null, GeneralContext context = null)
		{
			if (inParams == null)
			{
				return null;
			}
			if (inParams.TransitionPopupConfig != null)
			{
				return this.GetViewNameByPopupConfig(inParams.TransitionPopupConfig);
			}
			TransitionPopup? config = ConfigTransitionPopupById.GetConfig(inParams.BoardId, true);
			if (config == null)
			{
				return null;
			}
			return new EUiViewName?(this.GetViewNameByConfig(config.Value));
		}

		// Token: 0x0604431A RID: 279322 RVA: 0x011B35D4 File Offset: 0x011B17D4
		private EUiViewName? GetViewNameByPopupConfig(ITransitionPopupConfig popupConfig)
		{
			switch (popupConfig.PopupStyle.Type)
			{
			case ETransitionPopupStyleType.LeftTopTip:
				return new EUiViewName?(EUiViewName.PlotHintView);
			case ETransitionPopupStyleType.LeftBottomTransition:
				return new EUiViewName?(EUiViewName.TransitionPopupView);
			case ETransitionPopupStyleType.ArtText:
				return new EUiViewName?(EUiViewName.PlotWordArtView);
			default:
				return null;
			}
		}

		// Token: 0x0604431B RID: 279323 RVA: 0x011B362C File Offset: 0x011B182C
		private object BuildViewParams(EUiViewName viewName, ITransitionPopupConfig popupConfig, bool inPlot)
		{
			ITransitionPopupStyle popupStyle = popupConfig.PopupStyle;
			if (popupStyle.Type == ETransitionPopupStyleType.ArtText)
			{
				return new PlotWordArtViewParams
				{
					Config = ((ITransitionPopupArtText)popupStyle).ArtTextType,
					Duration = popupConfig.Duration
				};
			}
			return new TransitionPopupViewParams
			{
				Style = popupStyle,
				InPlot = inPlot,
				Duration = popupConfig.Duration
			};
		}

		// Token: 0x0604431C RID: 279324 RVA: 0x011B368B File Offset: 0x011B188B
		private EUiViewName GetViewNameByConfig(TransitionPopup config)
		{
			if (config.Style == 2)
			{
				return EUiViewName.PlotHintView;
			}
			return EUiViewName.TransitionPopupView;
		}
	}
}
