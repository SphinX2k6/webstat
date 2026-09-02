using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Common.MediumItemGrid
{
	// Token: 0x02005E62 RID: 24162
	[RequiredMember]
	public class MediumItemGridExtendCallback
	{
		// Token: 0x0603CCB2 RID: 249010 RVA: 0x00F6FE13 File Offset: 0x00F6E013
		[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
		[CompilerFeatureRequired("RequiredMembers")]
		public MediumItemGridExtendCallback()
		{
		}

		// Token: 0x04022246 RID: 139846
		[Nullable(1)]
		[RequiredMember]
		public ItemGridBase MediumItemGrid;

		// Token: 0x04022247 RID: 139847
		[RequiredMember]
		public EToggleState State;

		// Token: 0x04022248 RID: 139848
		[Nullable(2)]
		public object Data;
	}
}
