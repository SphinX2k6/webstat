using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Input;

namespace CSharpScript.Game.LevelGamePlay.Guarantee.GuaranteeActions
{
	// Token: 0x02006E73 RID: 28275
	public class GuaranteeActionEnablePlayerMoveControl : GuaranteeActionBase
	{
		// Token: 0x0604498A RID: 280970 RVA: 0x011D5312 File Offset: 0x011D3512
		[NullableContext(2)]
		protected override void OnExecute(ActionParams @params)
		{
			ControllerBase<InputController>.Instance.SetMoveControlEnabled(true, true, true, true);
		}
	}
}
