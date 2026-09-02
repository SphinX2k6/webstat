using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Battle
{
	// Token: 0x02006637 RID: 26167
	[NullableContext(1)]
	public interface IPinballBattleLevelInfoTargetData
	{
		// Token: 0x17009F71 RID: 40817
		// (get) Token: 0x060415C3 RID: 267715
		// (set) Token: 0x060415C4 RID: 267716
		bool IsSpecial { get; set; }

		// Token: 0x17009F72 RID: 40818
		// (get) Token: 0x060415C5 RID: 267717
		// (set) Token: 0x060415C6 RID: 267718
		bool IsFinish { get; set; }

		// Token: 0x17009F73 RID: 40819
		// (get) Token: 0x060415C7 RID: 267719
		// (set) Token: 0x060415C8 RID: 267720
		string Desc { get; set; }

		// Token: 0x17009F74 RID: 40820
		// (get) Token: 0x060415C9 RID: 267721
		// (set) Token: 0x060415CA RID: 267722
		int Value { get; set; }
	}
}
