using System;

namespace CSharpScript.Game.Module.Activity.ActivityContent.WheelTower
{
	// Token: 0x02006224 RID: 25124
	public class WheelTowerMedalItemData : IWheelTowerMedalItemData
	{
		// Token: 0x17009C24 RID: 39972
		// (get) Token: 0x0603F651 RID: 259665 RVA: 0x0103EED7 File Offset: 0x0103D0D7
		// (set) Token: 0x0603F652 RID: 259666 RVA: 0x0103EEDF File Offset: 0x0103D0DF
		public int GroupId { get; set; }

		// Token: 0x17009C25 RID: 39973
		// (get) Token: 0x0603F653 RID: 259667 RVA: 0x0103EEE8 File Offset: 0x0103D0E8
		// (set) Token: 0x0603F654 RID: 259668 RVA: 0x0103EEF0 File Offset: 0x0103D0F0
		public bool? IsLast { get; set; }

		// Token: 0x17009C26 RID: 39974
		// (get) Token: 0x0603F655 RID: 259669 RVA: 0x0103EEF9 File Offset: 0x0103D0F9
		// (set) Token: 0x0603F656 RID: 259670 RVA: 0x0103EF01 File Offset: 0x0103D101
		public bool? DisableInteract { get; set; }

		// Token: 0x17009C27 RID: 39975
		// (get) Token: 0x0603F657 RID: 259671 RVA: 0x0103EF0A File Offset: 0x0103D10A
		// (set) Token: 0x0603F658 RID: 259672 RVA: 0x0103EF12 File Offset: 0x0103D112
		public bool? HideDetails { get; set; }
	}
}
