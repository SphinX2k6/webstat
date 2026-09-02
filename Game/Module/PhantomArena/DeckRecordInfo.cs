using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.PhantomArena
{
	// Token: 0x02005489 RID: 21641
	[RequiredMember]
	public class DeckRecordInfo
	{
		// Token: 0x060371A5 RID: 225701 RVA: 0x00DFD8EA File Offset: 0x00DFBAEA
		[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
		[CompilerFeatureRequired("RequiredMembers")]
		public DeckRecordInfo()
		{
		}

		// Token: 0x0401FB81 RID: 129921
		[Nullable(1)]
		[RequiredMember]
		public Dictionary<int, int> CardMap;
	}
}
