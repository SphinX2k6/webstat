using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.Define;

namespace CSharpScript.Launcher.DiffPatch.Data
{
	// Token: 0x0200464F RID: 17999
	[NullableContext(1)]
	[Nullable(0)]
	public class LauncherVersionInfo : ResVersionInfo
	{
		// Token: 0x0602EF99 RID: 192409 RVA: 0x00B215BA File Offset: 0x00B1F7BA
		public LauncherVersionInfo(string packageVersion, string remoteVersion, Dictionary<string, string> remoteManifestHashMap) : base(packageVersion, remoteVersion, remoteManifestHashMap)
		{
		}

		// Token: 0x0602EF9A RID: 192410 RVA: 0x00B215C5 File Offset: 0x00B1F7C5
		public override string GetResType()
		{
			return EResType.Launcher.ToEnumString();
		}
	}
}
