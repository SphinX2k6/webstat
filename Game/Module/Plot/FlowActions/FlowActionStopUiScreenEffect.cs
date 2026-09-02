using System;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Render.Effect.ScreenEffectSystem;

namespace CSharpScript.Game.Module.Plot.FlowActions
{
	// Token: 0x0200543E RID: 21566
	public class FlowActionStopUiScreenEffect : FlowActionBase
	{
		// Token: 0x06036FC9 RID: 225225 RVA: 0x00DF55F8 File Offset: 0x00DF37F8
		protected override void OnExecute()
		{
			StopUiScreenEffect stopUiScreenEffect = this.ActionInfo.Params as StopUiScreenEffect;
			ModelBase<ScreenEffectModel>.Instance.EndScreenEffectByPath(stopUiScreenEffect.EffectDaPath);
		}
	}
}
