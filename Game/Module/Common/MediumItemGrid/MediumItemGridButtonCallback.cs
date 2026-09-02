using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Common.MediumItemGrid
{
	// Token: 0x02005E63 RID: 24163
	[RequiredMember]
	public class MediumItemGridButtonCallback
	{
		// Token: 0x0603CCB3 RID: 249011 RVA: 0x00F6FE1B File Offset: 0x00F6E01B
		[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
		[CompilerFeatureRequired("RequiredMembers")]
		public MediumItemGridButtonCallback()
		{
		}

		// Token: 0x04022249 RID: 139849
		[Nullable(1)]
		[RequiredMember]
		public MediumItemGrid MediumItemGrid;

		// Token: 0x0402224A RID: 139850
		[Nullable(2)]
		public object Data;
	}
}
