using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x0200603B RID: 24635
	public class HonamiStoryRoleItemData
	{
		// Token: 0x04022D61 RID: 142689
		public int RoleId;

		// Token: 0x04022D62 RID: 142690
		public int ItemSubType;

		// Token: 0x04022D63 RID: 142691
		public bool BuffActive;

		// Token: 0x04022D64 RID: 142692
		[Nullable(2)]
		public List<int> SuitIdList;

		// Token: 0x04022D65 RID: 142693
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public List<HonamiStoryWeaponSuitActiveData> SuitDataList;
	}
}
