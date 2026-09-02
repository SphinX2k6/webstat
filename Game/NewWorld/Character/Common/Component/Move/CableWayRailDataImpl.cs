using System;

namespace CSharpScript.Game.NewWorld.Character.Common.Component.Move
{
	// Token: 0x0200492D RID: 18733
	public class CableWayRailDataImpl : ICableWayRailData, IRailParam
	{
		// Token: 0x1700836B RID: 33643
		// (get) Token: 0x06030FB3 RID: 200627 RVA: 0x00C2BA35 File Offset: 0x00C29C35
		// (set) Token: 0x06030FB4 RID: 200628 RVA: 0x00C2BA3D File Offset: 0x00C29C3D
		public ERailMoveType RailType { get; set; }

		// Token: 0x1700836C RID: 33644
		// (get) Token: 0x06030FB5 RID: 200629 RVA: 0x00C2BA46 File Offset: 0x00C29C46
		// (set) Token: 0x06030FB6 RID: 200630 RVA: 0x00C2BA4E File Offset: 0x00C29C4E
		public ERailJumpType JumpType { get; set; }
	}
}
