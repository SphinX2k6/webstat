using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Launcher.Ui.HotFix
{
	// Token: 0x02004517 RID: 17687
	[NullableContext(2)]
	[Nullable(0)]
	public class SubPackageHttpData
	{
		// Token: 0x0401A78B RID: 108427
		public int UserId;

		// Token: 0x0401A78C RID: 108428
		public List<int> NeedConfirmQuestIdSet;

		// Token: 0x0401A78D RID: 108429
		public List<int> FinishQuestIdSet;

		// Token: 0x0401A78E RID: 108430
		public List<int> CurrentBlockIdSet;

		// Token: 0x0401A78F RID: 108431
		public List<uint> Mp4FinishQuestFlag;

		// Token: 0x0401A790 RID: 108432
		public int Sex;

		// Token: 0x0401A791 RID: 108433
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public List<ResourcePackagePositionData> Positions;
	}
}
