using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.TotalTopUp
{
	// Token: 0x0200625E RID: 25182
	[NullableContext(1)]
	[Nullable(0)]
	public class TotalTopUpRewardData
	{
		// Token: 0x040239DD RID: 145885
		public int Id;

		// Token: 0x040239DE RID: 145886
		public int Score;

		// Token: 0x040239DF RID: 145887
		public ETotalTopUpRewardState State;

		// Token: 0x040239E0 RID: 145888
		public List<int> ItemIdList = new List<int>();

		// Token: 0x040239E1 RID: 145889
		public Dictionary<int, int> ItemMap = new Dictionary<int, int>();

		// Token: 0x040239E2 RID: 145890
		public int FirstItemId;

		// Token: 0x040239E3 RID: 145891
		public int FirstItemCount;

		// Token: 0x040239E4 RID: 145892
		public List<int> PreviewButtonRegistry = new List<int>();

		// Token: 0x040239E5 RID: 145893
		[Nullable(2)]
		public TotalTopUpRolePackageData TotalTopUpRolePackageData;

		// Token: 0x040239E6 RID: 145894
		[Nullable(2)]
		public TotalTopUpWeaponPackageData TotalTopUpWeaponPackageData;
	}
}
