using System;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.LevelGamePlay.Guarantee
{
	// Token: 0x02006E6C RID: 28268
	public class GuaranteeFadeInParams : ActionParams, IGuaranteeFadeInParams
	{
		// Token: 0x1700A39A RID: 41882
		// (get) Token: 0x06044972 RID: 280946 RVA: 0x011D4CB8 File Offset: 0x011D2EB8
		// (set) Token: 0x06044973 RID: 280947 RVA: 0x011D4CC0 File Offset: 0x011D2EC0
		public bool? KeepFadeAfterTreeRollBack { get; set; }
	}
}
