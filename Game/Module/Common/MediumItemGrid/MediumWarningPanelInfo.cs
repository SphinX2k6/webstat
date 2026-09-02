using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Common.MediumItemGrid
{
	// Token: 0x02005E6D RID: 24173
	[RequiredMember]
	public class MediumWarningPanelInfo
	{
		// Token: 0x0603CCBD RID: 249021 RVA: 0x00F6FE6B File Offset: 0x00F6E06B
		[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
		[CompilerFeatureRequired("RequiredMembers")]
		public MediumWarningPanelInfo()
		{
		}

		// Token: 0x0402225E RID: 139870
		[Nullable(1)]
		[RequiredMember]
		public string TipText;

		// Token: 0x0402225F RID: 139871
		[Nullable(2)]
		public string IconPath;
	}
}
