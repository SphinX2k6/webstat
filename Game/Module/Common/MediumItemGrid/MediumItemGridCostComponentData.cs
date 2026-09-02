using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Common.MediumItemGrid
{
	// Token: 0x02005E6B RID: 24171
	[RequiredMember]
	public class MediumItemGridCostComponentData
	{
		// Token: 0x0603CCBB RID: 249019 RVA: 0x00F6FE5B File Offset: 0x00F6E05B
		[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
		[CompilerFeatureRequired("RequiredMembers")]
		public MediumItemGridCostComponentData()
		{
		}

		// Token: 0x04022259 RID: 139865
		[RequiredMember]
		public int Cost;

		// Token: 0x0402225A RID: 139866
		[RequiredMember]
		public FColor Color;

		// Token: 0x0402225B RID: 139867
		[Nullable(2)]
		public string Text;
	}
}
