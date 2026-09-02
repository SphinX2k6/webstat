using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.PhantomArena
{
	// Token: 0x02005493 RID: 21651
	[RequiredMember]
	public class BattleShopViewOpenParam
	{
		// Token: 0x060371AF RID: 225711 RVA: 0x00DFD93A File Offset: 0x00DFBB3A
		[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
		[CompilerFeatureRequired("RequiredMembers")]
		public BattleShopViewOpenParam()
		{
		}

		// Token: 0x0401FB96 RID: 129942
		[RequiredMember]
		public EUiTabViewName TabViewName;

		// Token: 0x0401FB97 RID: 129943
		[RequiredMember]
		public int ActivityId;
	}
}
