using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents.OpenSystem
{
	// Token: 0x02006C44 RID: 27716
	public class OpenSystemContributionLevel : OpenSystemBase
	{
		// Token: 0x0604421F RID: 279071 RVA: 0x011B1418 File Offset: 0x011AF618
		[NullableContext(1)]
		public OpenSystemContributionLevel(LevelEventOpenSystem eventBase) : base(eventBase)
		{
		}

		// Token: 0x06044220 RID: 279072 RVA: 0x011B1421 File Offset: 0x011AF621
		[NullableContext(2)]
		public override EUiViewName? GetViewName(OpenSystemBoard inParams = null, GeneralContext context = null)
		{
			return new EUiViewName?(EUiViewName.RegionalQuestView);
		}
	}
}
