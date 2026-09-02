using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents.OpenSystem
{
	// Token: 0x02006C7E RID: 27774
	public class OpenSystemRegionQuest : OpenSystemBase
	{
		// Token: 0x060442CC RID: 279244 RVA: 0x011B2BFA File Offset: 0x011B0DFA
		[NullableContext(1)]
		public OpenSystemRegionQuest(LevelEventOpenSystem eventBase) : base(eventBase)
		{
		}

		// Token: 0x060442CD RID: 279245 RVA: 0x011B2C03 File Offset: 0x011B0E03
		[NullableContext(2)]
		public override EUiViewName? GetViewName(OpenSystemBoard inParams = null, GeneralContext context = null)
		{
			return new EUiViewName?(EUiViewName.RegionalQuestView);
		}
	}
}
