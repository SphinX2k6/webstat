using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x0200610F RID: 24847
	[NullableContext(1)]
	[Nullable(0)]
	[RequiredMember]
	public class ExtraItemParams
	{
		// Token: 0x0603EC49 RID: 257097 RVA: 0x01012EFD File Offset: 0x010110FD
		[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
		[CompilerFeatureRequired("RequiredMembers")]
		public ExtraItemParams()
		{
		}

		// Token: 0x0402334E RID: 144206
		[RequiredMember]
		public Func<StateExtraItemBase> Creator;

		// Token: 0x0402334F RID: 144207
		[RequiredMember]
		public EExtraItemType Type;

		// Token: 0x04023350 RID: 144208
		[RequiredMember]
		public string ResourceId;
	}
}
