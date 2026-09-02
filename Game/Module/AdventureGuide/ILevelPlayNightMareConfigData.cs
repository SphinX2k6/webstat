using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.AdventureGuide
{
	// Token: 0x020061A2 RID: 24994
	[NullableContext(1)]
	public interface ILevelPlayNightMareConfigData
	{
		// Token: 0x17009B31 RID: 39729
		// (get) Token: 0x0603F1D8 RID: 258520
		// (set) Token: 0x0603F1D9 RID: 258521
		int LevelPlayId { get; set; }

		// Token: 0x17009B32 RID: 39730
		// (get) Token: 0x0603F1DA RID: 258522
		// (set) Token: 0x0603F1DB RID: 258523
		string[] Vars { get; set; }

		// Token: 0x17009B33 RID: 39731
		// (get) Token: 0x0603F1DC RID: 258524
		// (set) Token: 0x0603F1DD RID: 258525
		int[] DefaultValues { get; set; }
	}
}
