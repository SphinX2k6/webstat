using System;

namespace CSharpScript.Game.Module.Kurotato
{
	// Token: 0x02005A66 RID: 23142
	public interface IKurotatoSaveData
	{
		// Token: 0x17009580 RID: 38272
		// (get) Token: 0x0603A8C7 RID: 239815
		// (set) Token: 0x0603A8C8 RID: 239816
		long SaveTimestamp { get; set; }

		// Token: 0x17009581 RID: 38273
		// (get) Token: 0x0603A8C9 RID: 239817
		// (set) Token: 0x0603A8CA RID: 239818
		int RoleLevel { get; set; }

		// Token: 0x17009582 RID: 38274
		// (get) Token: 0x0603A8CB RID: 239819
		// (set) Token: 0x0603A8CC RID: 239820
		int WaveNum { get; set; }
	}
}
