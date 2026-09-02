using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.Define;

namespace CSharpScript.Launcher.DiffPatch.Data
{
	// Token: 0x02004650 RID: 18000
	[NullableContext(1)]
	[Nullable(0)]
	public class ResourceVersionInfo : ResVersionInfo
	{
		// Token: 0x0602EF9B RID: 192411 RVA: 0x00B215CD File Offset: 0x00B1F7CD
		public ResourceVersionInfo(string packageVersion, string remoteVersion, Dictionary<string, string> remoteManifestHashMap) : base(packageVersion, remoteVersion, remoteManifestHashMap)
		{
		}

		// Token: 0x0602EF9C RID: 192412 RVA: 0x00B215D8 File Offset: 0x00B1F7D8
		public override string GetResType()
		{
			return EResType.Resource.ToEnumString();
		}
	}
}
