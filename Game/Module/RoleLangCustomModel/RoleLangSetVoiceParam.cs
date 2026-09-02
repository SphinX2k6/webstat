using System;

namespace CSharpScript.Game.Module.RoleLangCustomModel
{
	// Token: 0x020050F1 RID: 20721
	public class RoleLangSetVoiceParam : IRoleLangSetVoiceParam
	{
		// Token: 0x17008C3A RID: 35898
		// (get) Token: 0x0603565F RID: 218719 RVA: 0x00D6458D File Offset: 0x00D6278D
		// (set) Token: 0x06035660 RID: 218720 RVA: 0x00D64595 File Offset: 0x00D62795
		public int RoleId { get; set; }

		// Token: 0x17008C3B RID: 35899
		// (get) Token: 0x06035661 RID: 218721 RVA: 0x00D6459E File Offset: 0x00D6279E
		// (set) Token: 0x06035662 RID: 218722 RVA: 0x00D645A6 File Offset: 0x00D627A6
		public int Lang { get; set; }

		// Token: 0x17008C3C RID: 35900
		// (get) Token: 0x06035663 RID: 218723 RVA: 0x00D645AF File Offset: 0x00D627AF
		// (set) Token: 0x06035664 RID: 218724 RVA: 0x00D645B7 File Offset: 0x00D627B7
		public bool NeedRequest { get; set; }

		// Token: 0x17008C3D RID: 35901
		// (get) Token: 0x06035665 RID: 218725 RVA: 0x00D645C0 File Offset: 0x00D627C0
		// (set) Token: 0x06035666 RID: 218726 RVA: 0x00D645C8 File Offset: 0x00D627C8
		public bool IsCustom { get; set; }

		// Token: 0x17008C3E RID: 35902
		// (get) Token: 0x06035667 RID: 218727 RVA: 0x00D645D1 File Offset: 0x00D627D1
		// (set) Token: 0x06035668 RID: 218728 RVA: 0x00D645D9 File Offset: 0x00D627D9
		public bool IsCover { get; set; }
	}
}
