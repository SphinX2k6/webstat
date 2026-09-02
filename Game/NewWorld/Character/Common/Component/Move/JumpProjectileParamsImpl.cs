using System;
using CSharpScript.Game.NewWorld.Character.Common.Controller;

namespace CSharpScript.Game.NewWorld.Character.Common.Component.Move
{
	// Token: 0x0200492E RID: 18734
	public class JumpProjectileParamsImpl : IJumpProjectileParams
	{
		// Token: 0x1700836D RID: 33645
		// (get) Token: 0x06030FB8 RID: 200632 RVA: 0x00C2BA5F File Offset: 0x00C29C5F
		// (set) Token: 0x06030FB9 RID: 200633 RVA: 0x00C2BA67 File Offset: 0x00C29C67
		public float Length { get; set; }

		// Token: 0x1700836E RID: 33646
		// (get) Token: 0x06030FBA RID: 200634 RVA: 0x00C2BA70 File Offset: 0x00C29C70
		// (set) Token: 0x06030FBB RID: 200635 RVA: 0x00C2BA78 File Offset: 0x00C29C78
		public float AllTime { get; set; }

		// Token: 0x1700836F RID: 33647
		// (get) Token: 0x06030FBC RID: 200636 RVA: 0x00C2BA81 File Offset: 0x00C29C81
		// (set) Token: 0x06030FBD RID: 200637 RVA: 0x00C2BA89 File Offset: 0x00C29C89
		public float Height0 { get; set; }

		// Token: 0x17008370 RID: 33648
		// (get) Token: 0x06030FBE RID: 200638 RVA: 0x00C2BA92 File Offset: 0x00C29C92
		// (set) Token: 0x06030FBF RID: 200639 RVA: 0x00C2BA9A File Offset: 0x00C29C9A
		public float ProjectileA { get; set; }

		// Token: 0x17008371 RID: 33649
		// (get) Token: 0x06030FC0 RID: 200640 RVA: 0x00C2BAA3 File Offset: 0x00C29CA3
		// (set) Token: 0x06030FC1 RID: 200641 RVA: 0x00C2BAAB File Offset: 0x00C29CAB
		public float ProjectileB { get; set; }
	}
}
