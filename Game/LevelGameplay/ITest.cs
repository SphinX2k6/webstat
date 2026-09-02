using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay
{
	// Token: 0x02006A56 RID: 27222
	[NullableContext(1)]
	public interface ITest
	{
		// Token: 0x1700A24E RID: 41550
		// (get) Token: 0x06043529 RID: 275753
		// (set) Token: 0x0604352A RID: 275754
		int TestSameType { get; set; }

		// Token: 0x1700A24F RID: 41551
		// (get) Token: 0x0604352B RID: 275755
		// (set) Token: 0x0604352C RID: 275756
		string TestDifferentType { get; set; }
	}
}
