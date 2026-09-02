using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Common.MediumItemGrid
{
	// Token: 0x02005E65 RID: 24165
	[RequiredMember]
	public class DevelopRewardInfo
	{
		// Token: 0x0603CCB5 RID: 249013 RVA: 0x00F6FE2B File Offset: 0x00F6E02B
		[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
		[CompilerFeatureRequired("RequiredMembers")]
		public DevelopRewardInfo()
		{
		}

		// Token: 0x0402224D RID: 139853
		public bool? IsUnlock;

		// Token: 0x0402224E RID: 139854
		[RequiredMember]
		public int DevelopRewardLevel;

		// Token: 0x0402224F RID: 139855
		[RequiredMember]
		public int UnlockLevel;
	}
}
