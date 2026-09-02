using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.DollGrabMachine.View
{
	// Token: 0x02006EFC RID: 28412
	[NullableContext(1)]
	public interface IDollDescriptionItemData
	{
		// Token: 0x1700A439 RID: 42041
		// (get) Token: 0x06044D91 RID: 282001
		// (set) Token: 0x06044D92 RID: 282002
		string IconPath { get; set; }

		// Token: 0x1700A43A RID: 42042
		// (get) Token: 0x06044D93 RID: 282003
		// (set) Token: 0x06044D94 RID: 282004
		string TextTitle { get; set; }

		// Token: 0x1700A43B RID: 42043
		// (get) Token: 0x06044D95 RID: 282005
		// (set) Token: 0x06044D96 RID: 282006
		string TextContent { get; set; }
	}
}
