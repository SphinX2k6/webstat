using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.LevelGamePlay.Guarantee
{
	// Token: 0x02006E65 RID: 28261
	public class GuaranteeActionInfo : ActionParams
	{
		// Token: 0x040262E8 RID: 156392
		public EGuaranteeAction Name;

		// Token: 0x040262E9 RID: 156393
		[Nullable(2)]
		public ActionParams Params;
	}
}
