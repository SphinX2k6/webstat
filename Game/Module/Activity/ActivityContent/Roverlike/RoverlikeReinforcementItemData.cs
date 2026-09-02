using System;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x0200644C RID: 25676
	public class RoverlikeReinforcementItemData : IRoverlikeReinforcementItemData
	{
		// Token: 0x17009E0D RID: 40461
		// (get) Token: 0x06040720 RID: 263968 RVA: 0x010852D7 File Offset: 0x010834D7
		// (set) Token: 0x06040721 RID: 263969 RVA: 0x010852DF File Offset: 0x010834DF
		public int ConfigId { get; set; }

		// Token: 0x17009E0E RID: 40462
		// (get) Token: 0x06040722 RID: 263970 RVA: 0x010852E8 File Offset: 0x010834E8
		// (set) Token: 0x06040723 RID: 263971 RVA: 0x010852F0 File Offset: 0x010834F0
		public int? IncId { get; set; }

		// Token: 0x17009E0F RID: 40463
		// (get) Token: 0x06040724 RID: 263972 RVA: 0x010852F9 File Offset: 0x010834F9
		// (set) Token: 0x06040725 RID: 263973 RVA: 0x01085301 File Offset: 0x01083501
		public bool? AllowToggleInteract { get; set; }
	}
}
