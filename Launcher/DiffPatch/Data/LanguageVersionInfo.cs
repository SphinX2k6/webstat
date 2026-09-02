using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.Define;
using CSharpScript.Launcher.Platform;
using CSharpScript.Launcher.Util;

namespace CSharpScript.Launcher.DiffPatch.Data
{
	// Token: 0x02004652 RID: 18002
	[NullableContext(1)]
	[Nullable(0)]
	public class LanguageVersionInfo : ResVersionInfo
	{
		// Token: 0x0602EF9F RID: 192415 RVA: 0x00B21616 File Offset: 0x00B1F816
		public LanguageVersionInfo(string packageVersion, string remoteVersion, Dictionary<string, string> remoteManifestHash, string languageCode) : base(packageVersion, remoteVersion, remoteManifestHash)
		{
			this.LanguageCode = languageCode;
		}

		// Token: 0x0602EFA0 RID: 192416 RVA: 0x00B21634 File Offset: 0x00B1F834
		public override string GetResType()
		{
			return EResType.Lang.ToEnumString() + "_" + this.LanguageCode;
		}

		// Token: 0x0602EFA1 RID: 192417 RVA: 0x00B2164C File Offset: 0x00B1F84C
		public override bool IsLangRes()
		{
			return true;
		}

		// Token: 0x0602EFA2 RID: 192418 RVA: 0x00B21650 File Offset: 0x00B1F850
		public override bool SkipUpdate()
		{
			if (Singleton<Platform>.Instance.IsCloudGame())
			{
				return false;
			}
			if (this.LanguageCode == Singleton<LauncherLanguageLib>.Instance.GetPackageAudioLanguage())
			{
				return false;
			}
			string text = Singleton<LauncherStorageLib>.Instance.GetDeviceSavedString(this.GetUseLanguageSaveKey(), "").Trim();
			return text == null || text.Length <= 0;
		}

		// Token: 0x0602EFA3 RID: 192419 RVA: 0x00B216B0 File Offset: 0x00B1F8B0
		public override bool RecordUse(bool bUse)
		{
			string value = bUse ? "1" : "";
			return Singleton<LauncherStorageLib>.Instance.SetDeviceSavedString(this.GetUseLanguageSaveKey(), value);
		}

		// Token: 0x0602EFA4 RID: 192420 RVA: 0x00B216DE File Offset: 0x00B1F8DE
		protected override bool ClearUseRecord()
		{
			return Singleton<LauncherStorageLib>.Instance.DeleteDeviceSavedString(this.GetUseLanguageSaveKey());
		}

		// Token: 0x0602EFA5 RID: 192421 RVA: 0x00B216F0 File Offset: 0x00B1F8F0
		private string GetUseLanguageSaveKey()
		{
			return "UseLanguage_" + this.LanguageCode;
		}

		// Token: 0x0401ABCB RID: 109515
		private readonly string LanguageCode = "";
	}
}
