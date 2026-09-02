using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Module.BattleUi;

namespace CSharpScript.Game.LevelGamePlay.Guarantee.GuaranteeActions
{
	// Token: 0x02006E71 RID: 28273
	public class GuaranteeActionDisableKey4Func : GuaranteeActionBase
	{
		// Token: 0x06044986 RID: 280966 RVA: 0x011D51FF File Offset: 0x011D33FF
		[NullableContext(2)]
		protected override void OnExecute(ActionParams @params = null)
		{
			ModelBase<BattleUiModel>.Instance.SetTimeDilationSkillButtonEnable(false);
		}
	}
}
