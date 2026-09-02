using System;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x0200644D RID: 25677
	public interface IRoverlikePropItemData
	{
		// Token: 0x17009E10 RID: 40464
		// (get) Token: 0x06040727 RID: 263975
		// (set) Token: 0x06040728 RID: 263976
		int ConfigId { get; set; }

		// Token: 0x17009E11 RID: 40465
		// (get) Token: 0x06040729 RID: 263977
		// (set) Token: 0x0604072A RID: 263978
		bool IsInGame { get; set; }

		// Token: 0x17009E12 RID: 40466
		// (get) Token: 0x0604072B RID: 263979
		// (set) Token: 0x0604072C RID: 263980
		int? IncId { get; set; }
	}
}
