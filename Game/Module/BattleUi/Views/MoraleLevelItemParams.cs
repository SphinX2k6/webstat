using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x0200610B RID: 24843
	[RequiredMember]
	public class MoraleLevelItemParams : ExtraItemParams
	{
		// Token: 0x0603EC46 RID: 257094 RVA: 0x01012DB5 File Offset: 0x01010FB5
		[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
		[CompilerFeatureRequired("RequiredMembers")]
		public MoraleLevelItemParams()
		{
		}

		// Token: 0x04023347 RID: 144199
		[RequiredMember]
		public int MoraleLevel;
	}
}
