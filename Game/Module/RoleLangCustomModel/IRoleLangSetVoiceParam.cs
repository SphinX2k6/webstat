using System;

namespace CSharpScript.Game.Module.RoleLangCustomModel
{
	// Token: 0x020050F0 RID: 20720
	public interface IRoleLangSetVoiceParam
	{
		// Token: 0x17008C35 RID: 35893
		// (get) Token: 0x06035655 RID: 218709
		// (set) Token: 0x06035656 RID: 218710
		int RoleId { get; set; }

		// Token: 0x17008C36 RID: 35894
		// (get) Token: 0x06035657 RID: 218711
		// (set) Token: 0x06035658 RID: 218712
		int Lang { get; set; }

		// Token: 0x17008C37 RID: 35895
		// (get) Token: 0x06035659 RID: 218713
		// (set) Token: 0x0603565A RID: 218714
		bool NeedRequest { get; set; }

		// Token: 0x17008C38 RID: 35896
		// (get) Token: 0x0603565B RID: 218715
		// (set) Token: 0x0603565C RID: 218716
		bool IsCustom { get; set; }

		// Token: 0x17008C39 RID: 35897
		// (get) Token: 0x0603565D RID: 218717
		// (set) Token: 0x0603565E RID: 218718
		bool IsCover { get; set; }
	}
}
