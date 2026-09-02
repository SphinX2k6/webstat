using System;
using Aki.TDConfigMgr.Component;

namespace CSharpScript.Game.NewWorld.Character.Common.Component.Move
{
	// Token: 0x02004928 RID: 18728
	public class SplineRailDataImpl : ISplineRailData, IRailParam
	{
		// Token: 0x1700835E RID: 33630
		// (get) Token: 0x06030F97 RID: 200599 RVA: 0x00C2B970 File Offset: 0x00C29B70
		// (set) Token: 0x06030F98 RID: 200600 RVA: 0x00C2B978 File Offset: 0x00C29B78
		public ERailMoveType RailType { get; set; }

		// Token: 0x1700835F RID: 33631
		// (get) Token: 0x06030F99 RID: 200601 RVA: 0x00C2B981 File Offset: 0x00C29B81
		// (set) Token: 0x06030F9A RID: 200602 RVA: 0x00C2B989 File Offset: 0x00C29B89
		public ERailJumpType JumpType { get; set; }

		// Token: 0x17008360 RID: 33632
		// (get) Token: 0x06030F9B RID: 200603 RVA: 0x00C2B992 File Offset: 0x00C29B92
		// (set) Token: 0x06030F9C RID: 200604 RVA: 0x00C2B99A File Offset: 0x00C29B9A
		public int DefaultNextRailId { get; set; }

		// Token: 0x17008361 RID: 33633
		// (get) Token: 0x06030F9D RID: 200605 RVA: 0x00C2B9A3 File Offset: 0x00C29BA3
		// (set) Token: 0x06030F9E RID: 200606 RVA: 0x00C2B9AB File Offset: 0x00C29BAB
		public ETriggerKey DefaultTriggerKey { get; set; }

		// Token: 0x17008362 RID: 33634
		// (get) Token: 0x06030F9F RID: 200607 RVA: 0x00C2B9B4 File Offset: 0x00C29BB4
		// (set) Token: 0x06030FA0 RID: 200608 RVA: 0x00C2B9BC File Offset: 0x00C29BBC
		public int RailId { get; set; }
	}
}
