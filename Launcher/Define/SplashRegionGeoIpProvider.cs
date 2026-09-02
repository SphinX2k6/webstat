using System;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace CSharpScript.Launcher.Define
{
	// Token: 0x02004664 RID: 18020
	[NullableContext(1)]
	[Nullable(0)]
	public class SplashRegionGeoIpProvider
	{
		// Token: 0x0602EFEF RID: 192495 RVA: 0x00B224FB File Offset: 0x00B206FB
		public SplashRegionGeoIpProvider(string name, string url, Regex countryRegex)
		{
			this.Name = name;
			this.Url = url;
			this.CountryRegex = countryRegex;
		}

		// Token: 0x0401AC3E RID: 109630
		public readonly string Name;

		// Token: 0x0401AC3F RID: 109631
		public readonly string Url;

		// Token: 0x0401AC40 RID: 109632
		public readonly Regex CountryRegex;
	}
}
