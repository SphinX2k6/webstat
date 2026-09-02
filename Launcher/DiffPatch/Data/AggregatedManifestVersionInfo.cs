using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Launcher.DiffPatch.Data
{
	// Token: 0x02004653 RID: 18003
	[NullableContext(1)]
	[Nullable(0)]
	public class AggregatedManifestVersionInfo : ResVersionInfo
	{
		// Token: 0x0602EFA6 RID: 192422 RVA: 0x00B21702 File Offset: 0x00B1F902
		public AggregatedManifestVersionInfo(string packageVersion, string remoteVersion, Dictionary<string, string> remoteManifestHashMap) : base(packageVersion, remoteVersion, remoteManifestHashMap)
		{
		}

		// Token: 0x0602EFA7 RID: 192423 RVA: 0x00B2170D File Offset: 0x00B1F90D
		public override string GetResType()
		{
			return "Aggregated";
		}

		// Token: 0x0602EFA8 RID: 192424 RVA: 0x00B21714 File Offset: 0x00B1F914
		public override string GetManifestFileName()
		{
			return "ManifestAggregated";
		}
	}
}
