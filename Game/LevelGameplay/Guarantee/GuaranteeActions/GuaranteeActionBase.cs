using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.LevelGamePlay.Guarantee.GuaranteeActions
{
	// Token: 0x02006E6F RID: 28271
	[NullableContext(2)]
	[Nullable(0)]
	public class GuaranteeActionBase
	{
		// Token: 0x0604497E RID: 280958 RVA: 0x011D506A File Offset: 0x011D326A
		[NullableContext(1)]
		public void Execute(GuaranteeActionInfo actionInfo, GuaranteeContext context)
		{
			this.ActionInfo = actionInfo;
			this.Context = context;
			this.OnExecute(actionInfo.Params);
		}

		// Token: 0x0604497F RID: 280959 RVA: 0x011D5086 File Offset: 0x011D3286
		public void Clear(ActionParams @params = null, GeneralContext instigatorContext = null)
		{
			this.OnClear(@params, instigatorContext);
		}

		// Token: 0x06044980 RID: 280960 RVA: 0x011D5090 File Offset: 0x011D3290
		protected virtual void OnExecute(ActionParams @params = null)
		{
		}

		// Token: 0x06044981 RID: 280961 RVA: 0x011D5092 File Offset: 0x011D3292
		protected virtual void OnClear(ActionParams @params = null, GeneralContext instigatorContext = null)
		{
		}

		// Token: 0x040262F3 RID: 156403
		public EGuaranteeAction Type;

		// Token: 0x040262F4 RID: 156404
		protected GuaranteeActionInfo ActionInfo;

		// Token: 0x040262F5 RID: 156405
		protected GuaranteeContext Context;
	}
}
