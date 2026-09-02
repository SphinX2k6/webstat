using System;

namespace CSharpScript.Launcher.Define
{
	// Token: 0x02004660 RID: 18016
	public class LaunchLanguageDefineConfig
	{
		// Token: 0x170080B1 RID: 32945
		// (get) Token: 0x0602EFD5 RID: 192469 RVA: 0x00B222C5 File Offset: 0x00B204C5
		public int LanguageType { get; }

		// Token: 0x170080B2 RID: 32946
		// (get) Token: 0x0602EFD6 RID: 192470 RVA: 0x00B222CD File Offset: 0x00B204CD
		public bool IsShow { get; }

		// Token: 0x0602EFD7 RID: 192471 RVA: 0x00B222D5 File Offset: 0x00B204D5
		public LaunchLanguageDefineConfig(int languageType, bool isShow)
		{
			this.LanguageType = languageType;
			this.IsShow = isShow;
		}
	}
}
