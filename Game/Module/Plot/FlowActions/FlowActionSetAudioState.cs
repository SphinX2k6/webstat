using System;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Module.Audio;

namespace CSharpScript.Game.Module.Plot.FlowActions
{
	// Token: 0x02005431 RID: 21553
	public class FlowActionSetAudioState : FlowActionBase
	{
		// Token: 0x06036F89 RID: 225161 RVA: 0x00DF4164 File Offset: 0x00DF2364
		protected override void OnExecute()
		{
			SetAudioState setAudioState = this.ActionInfo.Params as SetAudioState;
			if (setAudioState == null)
			{
				return;
			}
			ControllerBase<GameAudioController>.Instance.UpdateAudioStatebyClient(setAudioState.AudioConfig);
		}

		// Token: 0x06036F8A RID: 225162 RVA: 0x00DF4196 File Offset: 0x00DF2396
		protected override void OnBackgroundExecute()
		{
			this.OnExecute();
		}
	}
}
