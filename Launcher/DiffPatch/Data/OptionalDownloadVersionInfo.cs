using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.Define;

namespace CSharpScript.Launcher.DiffPatch.Data
{
	// Token: 0x02004651 RID: 18001
	[NullableContext(1)]
	[Nullable(0)]
	public class OptionalDownloadVersionInfo : ResVersionInfo
	{
		// Token: 0x0602EF9D RID: 192413 RVA: 0x00B215E0 File Offset: 0x00B1F7E0
		public OptionalDownloadVersionInfo(string packageVersion, string remoteVersion, Dictionary<string, string> remoteManifestHash, string packKey) : base(packageVersion, remoteVersion, remoteManifestHash)
		{
			this.PackKey = packKey;
		}

		// Token: 0x0602EF9E RID: 192414 RVA: 0x00B215FE File Offset: 0x00B1F7FE
		public override string GetResType()
		{
			return EResType.Optional.ToEnumString() + "_" + this.PackKey;
		}

		// Token: 0x0401ABCA RID: 109514
		protected readonly string PackKey = "";
	}
}
