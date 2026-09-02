using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.PhantomArena.Common.CardItem.Item
{
	// Token: 0x0200553E RID: 21822
	[RequiredMember]
	public class DetailViewCardItemData : CardInfoBase
	{
		// Token: 0x06037A44 RID: 227908 RVA: 0x00E1DD89 File Offset: 0x00E1BF89
		[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
		[CompilerFeatureRequired("RequiredMembers")]
		public DetailViewCardItemData()
		{
		}

		// Token: 0x0401FE50 RID: 130640
		[RequiredMember]
		public bool IsLock;
	}
}
