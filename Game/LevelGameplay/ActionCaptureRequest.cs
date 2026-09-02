using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.LevelGamePlay
{
	// Token: 0x02006A0F RID: 27151
	public class ActionCaptureRequest : ActionParams
	{
		// Token: 0x040257D6 RID: 153558
		[Nullable(2)]
		public ActionSendGameplayEvent SuccessEvent;
	}
}
