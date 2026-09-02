using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Flow
{
	// Token: 0x0200702E RID: 28718
	[NullableContext(2)]
	public interface IFinishState
	{
		// Token: 0x1700A506 RID: 42246
		// (get) Token: 0x0604588A RID: 284810
		// (set) Token: 0x0604588B RID: 284811
		[Nullable(1)]
		string Result { [NullableContext(1)] get; [NullableContext(1)] set; }

		// Token: 0x1700A507 RID: 42247
		// (get) Token: 0x0604588C RID: 284812
		// (set) Token: 0x0604588D RID: 284813
		string Arg1 { get; set; }

		// Token: 0x1700A508 RID: 42248
		// (get) Token: 0x0604588E RID: 284814
		// (set) Token: 0x0604588F RID: 284815
		string Arg2 { get; set; }
	}
}
