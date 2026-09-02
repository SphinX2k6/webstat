using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.PhantomArena
{
	// Token: 0x02005483 RID: 21635
	[NullableContext(2)]
	[Nullable(0)]
	[RequiredMember]
	public class CardInfoBase : CardFilterInfo
	{
		// Token: 0x0603719F RID: 225695 RVA: 0x00DFD8BA File Offset: 0x00DFBABA
		[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
		[CompilerFeatureRequired("RequiredMembers")]
		public CardInfoBase()
		{
		}

		// Token: 0x0401FB6A RID: 129898
		[RequiredMember]
		public int Attack;

		// Token: 0x0401FB6B RID: 129899
		[RequiredMember]
		public int Life;

		// Token: 0x0401FB6C RID: 129900
		[RequiredMember]
		public bool OutlookUnlocked;

		// Token: 0x0401FB6D RID: 129901
		[RequiredMember]
		public ECardFaceType CardFaceType;

		// Token: 0x0401FB6E RID: 129902
		public string CardFaceTexturePath;

		// Token: 0x0401FB6F RID: 129903
		public CardSpineData CardSpineData;

		// Token: 0x0401FB70 RID: 129904
		[RequiredMember]
		public ECardType CardType;
	}
}
