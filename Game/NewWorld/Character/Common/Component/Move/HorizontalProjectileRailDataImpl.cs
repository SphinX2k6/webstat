using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.NewWorld.Character.Common.Component.Move
{
	// Token: 0x0200492B RID: 18731
	public class HorizontalProjectileRailDataImpl : IHorizontalProjectileRailData, IRailParam, IConnectionRailData
	{
		// Token: 0x17008366 RID: 33638
		// (get) Token: 0x06030FA8 RID: 200616 RVA: 0x00C2B9CD File Offset: 0x00C29BCD
		// (set) Token: 0x06030FA9 RID: 200617 RVA: 0x00C2B9D5 File Offset: 0x00C29BD5
		public ERailMoveType RailType { get; set; }

		// Token: 0x17008367 RID: 33639
		// (get) Token: 0x06030FAA RID: 200618 RVA: 0x00C2B9DE File Offset: 0x00C29BDE
		// (set) Token: 0x06030FAB RID: 200619 RVA: 0x00C2B9E6 File Offset: 0x00C29BE6
		public ERailJumpType JumpType { get; set; }

		// Token: 0x17008368 RID: 33640
		// (get) Token: 0x06030FAC RID: 200620 RVA: 0x00C2B9EF File Offset: 0x00C29BEF
		// (set) Token: 0x06030FAD RID: 200621 RVA: 0x00C2B9F7 File Offset: 0x00C29BF7
		[Nullable(1)]
		public Vector RotatorFixedDirection { [NullableContext(1)] get; [NullableContext(1)] set; } = Vector.Create();

		// Token: 0x17008369 RID: 33641
		// (get) Token: 0x06030FAE RID: 200622 RVA: 0x00C2BA00 File Offset: 0x00C29C00
		// (set) Token: 0x06030FAF RID: 200623 RVA: 0x00C2BA08 File Offset: 0x00C29C08
		public int ConnectionNextRail { get; set; }

		// Token: 0x1700836A RID: 33642
		// (get) Token: 0x06030FB0 RID: 200624 RVA: 0x00C2BA11 File Offset: 0x00C29C11
		// (set) Token: 0x06030FB1 RID: 200625 RVA: 0x00C2BA19 File Offset: 0x00C29C19
		public float ConnectionStartDistance { get; set; }
	}
}
