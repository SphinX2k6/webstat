using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.PhantomArena.Prepare.DeckBuilder;

namespace CSharpScript.Game.Module.PhantomArena
{
	// Token: 0x0200549A RID: 21658
	[NullableContext(1)]
	[Nullable(0)]
	[RequiredMember]
	public class PhantomArenaReportDeckUpdateContext
	{
		// Token: 0x060371B6 RID: 225718 RVA: 0x00DFD972 File Offset: 0x00DFBB72
		[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
		[CompilerFeatureRequired("RequiredMembers")]
		public PhantomArenaReportDeckUpdateContext()
		{
		}

		// Token: 0x0401FBAD RID: 129965
		[RequiredMember]
		public int ActivityId;

		// Token: 0x0401FBAE RID: 129966
		[RequiredMember]
		public DeckInfo DeckInfo;

		// Token: 0x0401FBAF RID: 129967
		[RequiredMember]
		public EPhantomArenaReportDeckOperation Operation;

		// Token: 0x0401FBB0 RID: 129968
		[RequiredMember]
		public Dictionary<int, int> QuicklyBuildDeckUseTimes;

		// Token: 0x0401FBB1 RID: 129969
		[RequiredMember]
		public int LastQuicklyBuildId;
	}
}
