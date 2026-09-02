using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.WheelTower
{
	// Token: 0x02006214 RID: 25108
	[NullableContext(1)]
	[Nullable(0)]
	public class WheelTowerSeasonScoreData : IWheelTowerSeasonScoreData
	{
		// Token: 0x17009BC6 RID: 39878
		// (get) Token: 0x0603F58C RID: 259468 RVA: 0x0103EA60 File Offset: 0x0103CC60
		// (set) Token: 0x0603F58D RID: 259469 RVA: 0x0103EA68 File Offset: 0x0103CC68
		public int Score { get; set; }

		// Token: 0x17009BC7 RID: 39879
		// (get) Token: 0x0603F58E RID: 259470 RVA: 0x0103EA71 File Offset: 0x0103CC71
		// (set) Token: 0x0603F58F RID: 259471 RVA: 0x0103EA79 File Offset: 0x0103CC79
		public int PrevScore { get; set; }

		// Token: 0x17009BC8 RID: 39880
		// (get) Token: 0x0603F590 RID: 259472 RVA: 0x0103EA82 File Offset: 0x0103CC82
		// (set) Token: 0x0603F591 RID: 259473 RVA: 0x0103EA8A File Offset: 0x0103CC8A
		public int TotalScore { get; set; }

		// Token: 0x17009BC9 RID: 39881
		// (get) Token: 0x0603F592 RID: 259474 RVA: 0x0103EA93 File Offset: 0x0103CC93
		// (set) Token: 0x0603F593 RID: 259475 RVA: 0x0103EA9B File Offset: 0x0103CC9B
		public int CurScore { get; set; }

		// Token: 0x17009BCA RID: 39882
		// (get) Token: 0x0603F594 RID: 259476 RVA: 0x0103EAA4 File Offset: 0x0103CCA4
		// (set) Token: 0x0603F595 RID: 259477 RVA: 0x0103EAAC File Offset: 0x0103CCAC
		public bool IsReceived { get; set; }

		// Token: 0x17009BCB RID: 39883
		// (get) Token: 0x0603F596 RID: 259478 RVA: 0x0103EAB5 File Offset: 0x0103CCB5
		// (set) Token: 0x0603F597 RID: 259479 RVA: 0x0103EABD File Offset: 0x0103CCBD
		public int DropId { get; set; }

		// Token: 0x17009BCC RID: 39884
		// (get) Token: 0x0603F598 RID: 259480 RVA: 0x0103EAC6 File Offset: 0x0103CCC6
		// (set) Token: 0x0603F599 RID: 259481 RVA: 0x0103EACE File Offset: 0x0103CCCE
		public int MotorPreviewId { get; set; }

		// Token: 0x17009BCD RID: 39885
		// (get) Token: 0x0603F59A RID: 259482 RVA: 0x0103EAD7 File Offset: 0x0103CCD7
		// (set) Token: 0x0603F59B RID: 259483 RVA: 0x0103EADF File Offset: 0x0103CCDF
		public int WeaponPreviewId { get; set; }

		// Token: 0x17009BCE RID: 39886
		// (get) Token: 0x0603F59C RID: 259484 RVA: 0x0103EAE8 File Offset: 0x0103CCE8
		// (set) Token: 0x0603F59D RID: 259485 RVA: 0x0103EAF0 File Offset: 0x0103CCF0
		public string PreviewIcon { get; set; }
	}
}
