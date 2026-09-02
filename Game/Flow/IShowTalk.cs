using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Flow
{
	// Token: 0x0200702B RID: 28715
	[NullableContext(1)]
	public interface IShowTalk
	{
		// Token: 0x1700A502 RID: 42242
		// (get) Token: 0x06045882 RID: 284802
		// (set) Token: 0x06045883 RID: 284803
		bool? ResetCamera { get; set; }

		// Token: 0x1700A503 RID: 42243
		// (get) Token: 0x06045884 RID: 284804
		// (set) Token: 0x06045885 RID: 284805
		ITalkItem[] TalkItems { get; set; }
	}
}
