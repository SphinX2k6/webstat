using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball
{
	// Token: 0x0200658F RID: 25999
	[NullableContext(1)]
	public interface IPinballMainRootViewOpenParam
	{
		// Token: 0x17009EB5 RID: 40629
		// (get) Token: 0x06040F72 RID: 266098
		// (set) Token: 0x06040F73 RID: 266099
		string ChildView { get; set; }

		// Token: 0x17009EB6 RID: 40630
		// (get) Token: 0x06040F74 RID: 266100
		// (set) Token: 0x06040F75 RID: 266101
		int? LevelId { get; set; }

		// Token: 0x17009EB7 RID: 40631
		// (get) Token: 0x06040F76 RID: 266102
		// (set) Token: 0x06040F77 RID: 266103
		bool? IsFromInstanceDungeon { get; set; }
	}
}
