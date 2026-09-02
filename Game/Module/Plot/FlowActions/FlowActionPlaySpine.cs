using System;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Common.Event;

namespace CSharpScript.Game.Module.Plot.FlowActions
{
	// Token: 0x0200542E RID: 21550
	public class FlowActionPlaySpine : FlowActionBase
	{
		// Token: 0x06036F7E RID: 225150 RVA: 0x00DF3E5C File Offset: 0x00DF205C
		protected override void OnExecute()
		{
			SetSpineAnimation setSpineAnimation = this.ActionInfo.Params as SetSpineAnimation;
			if (setSpineAnimation != null && setSpineAnimation.Config.Type == ESetSpineAnimation.Play)
			{
				Singleton<EventSystem>.Instance.Emit<string, bool>(EEventName.PlayPlotSpine, setSpineAnimation.Config.Name, setSpineAnimation.Config.IsLoop);
			}
		}

		// Token: 0x06036F7F RID: 225151 RVA: 0x00DF3EB0 File Offset: 0x00DF20B0
		protected override void OnBackgroundExecute()
		{
		}
	}
}
