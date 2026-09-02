using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.NewWorld.Character.Common.Component.Move
{
	// Token: 0x02004929 RID: 18729
	[NullableContext(1)]
	public interface IConnectionRailData
	{
		// Token: 0x17008363 RID: 33635
		// (get) Token: 0x06030FA2 RID: 200610
		// (set) Token: 0x06030FA3 RID: 200611
		Vector RotatorFixedDirection { get; set; }

		// Token: 0x17008364 RID: 33636
		// (get) Token: 0x06030FA4 RID: 200612
		// (set) Token: 0x06030FA5 RID: 200613
		int ConnectionNextRail { get; set; }

		// Token: 0x17008365 RID: 33637
		// (get) Token: 0x06030FA6 RID: 200614
		// (set) Token: 0x06030FA7 RID: 200615
		float ConnectionStartDistance { get; set; }
	}
}
