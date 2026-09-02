using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.PhantomArena
{
	// Token: 0x02005495 RID: 21653
	[RequiredMember]
	public class BattleResultCardsViewOpenParam
	{
		// Token: 0x060371B1 RID: 225713 RVA: 0x00DFD94A File Offset: 0x00DFBB4A
		[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
		[CompilerFeatureRequired("RequiredMembers")]
		public BattleResultCardsViewOpenParam()
		{
		}

		// Token: 0x0401FB9A RID: 129946
		[Nullable(1)]
		[RequiredMember]
		public List<int> CardIdList;

		// Token: 0x0401FB9B RID: 129947
		[Nullable(2)]
		public Action CallbackOnClose;

		// Token: 0x0401FB9C RID: 129948
		[RequiredMember]
		public bool IsNewPhantomArenaActivity;
	}
}
