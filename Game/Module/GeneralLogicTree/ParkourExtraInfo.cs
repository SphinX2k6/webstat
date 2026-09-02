using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.GeneralLogicTree
{
	// Token: 0x02005CCC RID: 23756
	public class ParkourExtraInfo : GeneralLogicTreeNodeExtraInfo
	{
		// Token: 0x0603BE84 RID: 245380 RVA: 0x00F2EC0E File Offset: 0x00F2CE0E
		public ParkourExtraInfo()
		{
			this.Type = EExtraInfoType.Parkour;
		}

		// Token: 0x04021ACC RID: 137932
		[Nullable(2)]
		public Dictionary<int, int> TotalScore;
	}
}
