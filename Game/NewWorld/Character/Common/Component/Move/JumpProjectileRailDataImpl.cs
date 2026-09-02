using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.NewWorld.Character.Common.Controller;

namespace CSharpScript.Game.NewWorld.Character.Common.Component.Move
{
	// Token: 0x02004930 RID: 18736
	public class JumpProjectileRailDataImpl : IJumpProjectileRailData, IRailParam, IConnectionRailData, IJumpProjectileParams
	{
		// Token: 0x17008374 RID: 33652
		// (get) Token: 0x06030FC7 RID: 200647 RVA: 0x00C2BABC File Offset: 0x00C29CBC
		// (set) Token: 0x06030FC8 RID: 200648 RVA: 0x00C2BAC4 File Offset: 0x00C29CC4
		public ERailMoveType RailType { get; set; }

		// Token: 0x17008375 RID: 33653
		// (get) Token: 0x06030FC9 RID: 200649 RVA: 0x00C2BACD File Offset: 0x00C29CCD
		// (set) Token: 0x06030FCA RID: 200650 RVA: 0x00C2BAD5 File Offset: 0x00C29CD5
		public ERailJumpType JumpType { get; set; }

		// Token: 0x17008376 RID: 33654
		// (get) Token: 0x06030FCB RID: 200651 RVA: 0x00C2BADE File Offset: 0x00C29CDE
		// (set) Token: 0x06030FCC RID: 200652 RVA: 0x00C2BAE6 File Offset: 0x00C29CE6
		[Nullable(1)]
		public Vector RotatorFixedDirection { [NullableContext(1)] get; [NullableContext(1)] set; } = Vector.Create();

		// Token: 0x17008377 RID: 33655
		// (get) Token: 0x06030FCD RID: 200653 RVA: 0x00C2BAEF File Offset: 0x00C29CEF
		// (set) Token: 0x06030FCE RID: 200654 RVA: 0x00C2BAF7 File Offset: 0x00C29CF7
		public int ConnectionNextRail { get; set; }

		// Token: 0x17008378 RID: 33656
		// (get) Token: 0x06030FCF RID: 200655 RVA: 0x00C2BB00 File Offset: 0x00C29D00
		// (set) Token: 0x06030FD0 RID: 200656 RVA: 0x00C2BB08 File Offset: 0x00C29D08
		public float ConnectionStartDistance { get; set; }

		// Token: 0x17008379 RID: 33657
		// (get) Token: 0x06030FD1 RID: 200657 RVA: 0x00C2BB11 File Offset: 0x00C29D11
		// (set) Token: 0x06030FD2 RID: 200658 RVA: 0x00C2BB19 File Offset: 0x00C29D19
		public float Length { get; set; }

		// Token: 0x1700837A RID: 33658
		// (get) Token: 0x06030FD3 RID: 200659 RVA: 0x00C2BB22 File Offset: 0x00C29D22
		// (set) Token: 0x06030FD4 RID: 200660 RVA: 0x00C2BB2A File Offset: 0x00C29D2A
		public float AllTime { get; set; }

		// Token: 0x1700837B RID: 33659
		// (get) Token: 0x06030FD5 RID: 200661 RVA: 0x00C2BB33 File Offset: 0x00C29D33
		// (set) Token: 0x06030FD6 RID: 200662 RVA: 0x00C2BB3B File Offset: 0x00C29D3B
		public float Height0 { get; set; }

		// Token: 0x1700837C RID: 33660
		// (get) Token: 0x06030FD7 RID: 200663 RVA: 0x00C2BB44 File Offset: 0x00C29D44
		// (set) Token: 0x06030FD8 RID: 200664 RVA: 0x00C2BB4C File Offset: 0x00C29D4C
		public float ProjectileA { get; set; }

		// Token: 0x1700837D RID: 33661
		// (get) Token: 0x06030FD9 RID: 200665 RVA: 0x00C2BB55 File Offset: 0x00C29D55
		// (set) Token: 0x06030FDA RID: 200666 RVA: 0x00C2BB5D File Offset: 0x00C29D5D
		public float ProjectileB { get; set; }

		// Token: 0x1700837E RID: 33662
		// (get) Token: 0x06030FDB RID: 200667 RVA: 0x00C2BB66 File Offset: 0x00C29D66
		// (set) Token: 0x06030FDC RID: 200668 RVA: 0x00C2BB6E File Offset: 0x00C29D6E
		public float LastRate { get; set; }

		// Token: 0x1700837F RID: 33663
		// (get) Token: 0x06030FDD RID: 200669 RVA: 0x00C2BB77 File Offset: 0x00C29D77
		// (set) Token: 0x06030FDE RID: 200670 RVA: 0x00C2BB7F File Offset: 0x00C29D7F
		public float JumpTime { get; set; }
	}
}
