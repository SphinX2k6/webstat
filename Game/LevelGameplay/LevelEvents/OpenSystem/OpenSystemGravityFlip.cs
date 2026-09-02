using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents.OpenSystem
{
	// Token: 0x02006C59 RID: 27737
	public class OpenSystemGravityFlip : OpenSystemBase
	{
		// Token: 0x0604425D RID: 279133 RVA: 0x011B1CA7 File Offset: 0x011AFEA7
		[NullableContext(1)]
		public OpenSystemGravityFlip(LevelEventOpenSystem eventBase) : base(eventBase)
		{
		}

		// Token: 0x0604425E RID: 279134 RVA: 0x011B1CB0 File Offset: 0x011AFEB0
		[NullableContext(2)]
		public override EUiViewName? GetViewName(OpenSystemBoard inParams = null, GeneralContext context = null)
		{
			return new EUiViewName?(EUiViewName.GravityFlipView);
		}
	}
}
