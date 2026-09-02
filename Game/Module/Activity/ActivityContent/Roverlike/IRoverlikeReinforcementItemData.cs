using System;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x0200644B RID: 25675
	public interface IRoverlikeReinforcementItemData
	{
		// Token: 0x17009E0A RID: 40458
		// (get) Token: 0x0604071A RID: 263962
		// (set) Token: 0x0604071B RID: 263963
		int ConfigId { get; set; }

		// Token: 0x17009E0B RID: 40459
		// (get) Token: 0x0604071C RID: 263964
		// (set) Token: 0x0604071D RID: 263965
		int? IncId { get; set; }

		// Token: 0x17009E0C RID: 40460
		// (get) Token: 0x0604071E RID: 263966
		// (set) Token: 0x0604071F RID: 263967
		bool? AllowToggleInteract { get; set; }
	}
}
