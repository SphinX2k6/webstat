using System;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x0200644A RID: 25674
	public class RoverlikeBlessingItemData : IRoverlikeBlessingItemData
	{
		// Token: 0x17009E04 RID: 40452
		// (get) Token: 0x0604070D RID: 263949 RVA: 0x01085269 File Offset: 0x01083469
		// (set) Token: 0x0604070E RID: 263950 RVA: 0x01085271 File Offset: 0x01083471
		public int BlessId { get; set; }

		// Token: 0x17009E05 RID: 40453
		// (get) Token: 0x0604070F RID: 263951 RVA: 0x0108527A File Offset: 0x0108347A
		// (set) Token: 0x06040710 RID: 263952 RVA: 0x01085282 File Offset: 0x01083482
		public int? IncId { get; set; }

		// Token: 0x17009E06 RID: 40454
		// (get) Token: 0x06040711 RID: 263953 RVA: 0x0108528B File Offset: 0x0108348B
		// (set) Token: 0x06040712 RID: 263954 RVA: 0x01085293 File Offset: 0x01083493
		public bool? AllowToggleInteract { get; set; }

		// Token: 0x17009E07 RID: 40455
		// (get) Token: 0x06040713 RID: 263955 RVA: 0x0108529C File Offset: 0x0108349C
		// (set) Token: 0x06040714 RID: 263956 RVA: 0x010852A4 File Offset: 0x010834A4
		public bool? IsUp { get; set; }

		// Token: 0x17009E08 RID: 40456
		// (get) Token: 0x06040715 RID: 263957 RVA: 0x010852AD File Offset: 0x010834AD
		// (set) Token: 0x06040716 RID: 263958 RVA: 0x010852B5 File Offset: 0x010834B5
		public bool? CheckSameSlot { get; set; }

		// Token: 0x17009E09 RID: 40457
		// (get) Token: 0x06040717 RID: 263959 RVA: 0x010852BE File Offset: 0x010834BE
		// (set) Token: 0x06040718 RID: 263960 RVA: 0x010852C6 File Offset: 0x010834C6
		public bool? ShowRecommend { get; set; }
	}
}
