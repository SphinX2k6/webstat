using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.Define;

namespace CSharpScript.Launcher.DiffPatch.Data
{
	// Token: 0x02004655 RID: 18005
	[NullableContext(1)]
	[Nullable(0)]
	public class RoleVoiceItemVersionInfo : OptionalDownloadVersionInfo
	{
		// Token: 0x0602EFB0 RID: 192432 RVA: 0x00B21757 File Offset: 0x00B1F957
		public RoleVoiceItemVersionInfo(string packageVersion, string remoteVersion, Dictionary<string, string> remoteManifestHash, string packKey) : base(packageVersion, remoteVersion, remoteManifestHash, packKey)
		{
		}

		// Token: 0x0602EFB1 RID: 192433 RVA: 0x00B21764 File Offset: 0x00B1F964
		public override string GetResType()
		{
			return "RoleVoice/" + this.PackKey;
		}

		// Token: 0x0602EFB2 RID: 192434 RVA: 0x00B21776 File Offset: 0x00B1F976
		protected override string GetVersionRecordKey()
		{
			return "Version_" + EResType.Optional.ToEnumString() + "_" + this.PackKey;
		}

		// Token: 0x0602EFB3 RID: 192435 RVA: 0x00B21793 File Offset: 0x00B1F993
		public override string GetManifestFileName()
		{
			return "";
		}

		// Token: 0x0602EFB4 RID: 192436 RVA: 0x00B2179A File Offset: 0x00B1F99A
		public override bool NeedRecordMount()
		{
			return false;
		}

		// Token: 0x0602EFB5 RID: 192437 RVA: 0x00B2179D File Offset: 0x00B1F99D
		public string GetPackKey()
		{
			return this.PackKey;
		}
	}
}
