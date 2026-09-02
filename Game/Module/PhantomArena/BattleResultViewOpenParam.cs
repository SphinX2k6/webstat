using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

namespace CSharpScript.Game.Module.PhantomArena
{
	// Token: 0x02005492 RID: 21650
	[RequiredMember]
	public class BattleResultViewOpenParam
	{
		// Token: 0x060371AE RID: 225710 RVA: 0x00DFD932 File Offset: 0x00DFBB32
		[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
		[CompilerFeatureRequired("RequiredMembers")]
		public BattleResultViewOpenParam()
		{
		}

		// Token: 0x0401FB94 RID: 129940
		[Nullable(1)]
		[RequiredMember]
		public PhantomBattleBoardSettleNotify Result;

		// Token: 0x0401FB95 RID: 129941
		[Nullable(2)]
		public Action<bool> CallbackOnClose;
	}
}
