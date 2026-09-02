using System;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MoonSignIn
{
	// Token: 0x02006726 RID: 26406
	internal class MoonSignInDetailViewOpenData : IMoonSignInDetailViewOpenData
	{
		// Token: 0x1700A0A2 RID: 41122
		// (get) Token: 0x06041DEF RID: 269807 RVA: 0x010E632F File Offset: 0x010E452F
		// (set) Token: 0x06041DF0 RID: 269808 RVA: 0x010E6337 File Offset: 0x010E4537
		public int MoonId { get; set; }

		// Token: 0x1700A0A3 RID: 41123
		// (get) Token: 0x06041DF1 RID: 269809 RVA: 0x010E6340 File Offset: 0x010E4540
		// (set) Token: 0x06041DF2 RID: 269810 RVA: 0x010E6348 File Offset: 0x010E4548
		public bool? Wishing { get; set; } = new bool?(false);
	}
}
