using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x0200610C RID: 24844
	[RequiredMember]
	public class HonamiStoryLevelItemParams : ExtraItemParams
	{
		// Token: 0x0603EC47 RID: 257095 RVA: 0x01012DBD File Offset: 0x01010FBD
		[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
		[CompilerFeatureRequired("RequiredMembers")]
		public HonamiStoryLevelItemParams()
		{
		}

		// Token: 0x04023348 RID: 144200
		[RequiredMember]
		public int HonamiStoryLevel;
	}
}
