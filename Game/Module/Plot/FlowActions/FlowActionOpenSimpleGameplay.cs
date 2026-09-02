using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.LevelGamePlay;
using CSharpScript.Game.LevelGamePlay.Hourglass;
using CSharpScript.Game.LevelGamePlay.ItemInspect;
using CSharpScript.Game.LevelGamePlay.SceneInspection;
using CSharpScript.Game.Module.Interaction;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.Plot.FlowActions
{
	// Token: 0x02005429 RID: 21545
	public class FlowActionOpenSimpleGameplay : FlowActionBase
	{
		// Token: 0x06036F63 RID: 225123 RVA: 0x00DF37FC File Offset: 0x00DF19FC
		protected override void OnExecute()
		{
			OpenSimpleGameplay openSimpleGameplay = this.ActionInfo.Params as OpenSimpleGameplay;
			if (openSimpleGameplay == null)
			{
				return;
			}
			ESimpleGameplayType type = openSimpleGameplay.GameplayConfig.Type;
			if (type > ESimpleGameplayType.DaemonHack)
			{
				if (type != ESimpleGameplayType.QteHourglass)
				{
					if (type == ESimpleGameplayType.SceneInspection)
					{
						long flowIncId = this.Context.FlowIncId;
						GeneralContext context = this.Context.Context;
						PlotContext context2 = PlotContext.Create(flowIncId, (context != null) ? context.SubType : null);
						CheckInteractionOpenParam param = new CheckInteractionOpenParam
						{
							Config = (ISceneInspection)openSimpleGameplay.GameplayConfig,
							Context = context2
						};
						Singleton<UiManager>.Instance.OpenViewByPlot(EUiViewName.CheckInteractionView, param, null);
						return;
					}
				}
				else
				{
					ModelBase<QteHourglassModel>.Instance.OpenGameplay((IQteHourglass)openSimpleGameplay.GameplayConfig);
					base.FinishExecute(true, true);
				}
				return;
			}
			if (type == ESimpleGameplayType.ItemInspection)
			{
				ItemInspectController instance = ControllerBase<ItemInspectController>.Instance;
				IItemInspection config = (IItemInspection)openSimpleGameplay.GameplayConfig;
				Action<EUiViewName> onBeforeOpenView;
				if ((onBeforeOpenView = FlowActionOpenSimpleGameplay.<>O.<0>__RegisterOpenViewName) == null)
				{
					onBeforeOpenView = (FlowActionOpenSimpleGameplay.<>O.<0>__RegisterOpenViewName = new Action<EUiViewName>(TsInteractionUtils.RegisterOpenViewName));
				}
				instance.OpenItemInspect(config, onBeforeOpenView, delegate(bool _)
				{
					base.FinishExecute(true, true);
				});
				return;
			}
			if (type != ESimpleGameplayType.DaemonHack)
			{
				return;
			}
			IDaemonHack daemonHack = (IDaemonHack)openSimpleGameplay.GameplayConfig;
			ControllerBase<GolemHackingController>.Instance.OpenGameplayViewByPlot(daemonHack.Ids, delegate(bool result)
			{
				if (result)
				{
					base.FinishExecute(true, true);
				}
			}, daemonHack.FinishOnClose.GetValueOrDefault());
		}

		// Token: 0x06036F64 RID: 225124 RVA: 0x00DF3944 File Offset: 0x00DF1B44
		protected override void OnInterruptExecute()
		{
			if ((this.ActionInfo.Params as OpenSimpleGameplay).GameplayConfig.Type == ESimpleGameplayType.ItemInspection)
			{
				ControllerBase<ItemInspectController>.Instance.InterruptItemInspect();
			}
		}

		// Token: 0x0200B3AC RID: 45996
		[CompilerGenerated]
		private static class <>O
		{
			// Token: 0x04037A52 RID: 227922
			public static Action<EUiViewName> <0>__RegisterOpenViewName;
		}
	}
}
