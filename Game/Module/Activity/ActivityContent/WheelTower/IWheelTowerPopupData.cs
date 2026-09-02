using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.WheelTower
{
	// Token: 0x0200620F RID: 25103
	[NullableContext(1)]
	public interface IWheelTowerPopupData
	{
		// Token: 0x17009BA7 RID: 39847
		// (get) Token: 0x0603F54C RID: 259404
		// (set) Token: 0x0603F54D RID: 259405
		int TotalScore { get; set; }

		// Token: 0x17009BA8 RID: 39848
		// (get) Token: 0x0603F54E RID: 259406
		// (set) Token: 0x0603F54F RID: 259407
		int RoundScore { get; set; }

		// Token: 0x17009BA9 RID: 39849
		// (get) Token: 0x0603F550 RID: 259408
		// (set) Token: 0x0603F551 RID: 259409
		int ScoreRecord { get; set; }

		// Token: 0x17009BAA RID: 39850
		// (get) Token: 0x0603F552 RID: 259410
		// (set) Token: 0x0603F553 RID: 259411
		List<int> TeamRoleIdList { get; set; }

		// Token: 0x17009BAB RID: 39851
		// (get) Token: 0x0603F554 RID: 259412
		// (set) Token: 0x0603F555 RID: 259413
		int BuffId { get; set; }
	}
}
