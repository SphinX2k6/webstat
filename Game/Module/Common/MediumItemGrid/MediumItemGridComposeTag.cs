using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Common.MediumItemGrid
{
	// Token: 0x02005E60 RID: 24160
	[RequiredMember]
	public class MediumItemGridComposeTag
	{
		// Token: 0x0603CCB1 RID: 249009 RVA: 0x00F6FE0B File Offset: 0x00F6E00B
		[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
		[CompilerFeatureRequired("RequiredMembers")]
		public MediumItemGridComposeTag()
		{
		}

		// Token: 0x0402223E RID: 139838
		[RequiredMember]
		public bool IsRefreshItem;

		// Token: 0x0402223F RID: 139839
		[RequiredMember]
		public bool IsLimitTimeItem;

		// Token: 0x04022240 RID: 139840
		[RequiredMember]
		public EMediumItemGridBuffType BuffItem;
	}
}
