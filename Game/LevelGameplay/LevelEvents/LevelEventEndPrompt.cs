using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Module.GenericPrompt;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006B91 RID: 27537
	public class LevelEventEndPrompt : LevelEventBase
	{
		// Token: 0x06043F57 RID: 278359 RVA: 0x0119B447 File Offset: 0x01199647
		public LevelEventEndPrompt(int id) : base(id)
		{
		}

		// Token: 0x06043F58 RID: 278360 RVA: 0x0119B450 File Offset: 0x01199650
		[NullableContext(1)]
		public override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			EndCommonTip endCommonTip = inParams as EndCommonTip;
			if (endCommonTip == null)
			{
				return;
			}
			GenericPromptController.CancelPromptByPromptKey(endCommonTip.Token);
		}
	}
}
