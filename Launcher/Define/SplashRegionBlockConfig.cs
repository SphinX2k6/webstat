using System;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace CSharpScript.Launcher.Define
{
	// Token: 0x02004665 RID: 18021
	[NullableContext(1)]
	[Nullable(0)]
	[StaticVariableRuleIgnore]
	public class SplashRegionBlockConfig
	{
		// Token: 0x0401AC41 RID: 109633
		private const int SECS_PER_DAY = 86400;

		// Token: 0x0401AC42 RID: 109634
		private const int CACHE_TTL_DAYS = 30;

		// Token: 0x0401AC43 RID: 109635
		public static readonly bool Enabled = false;

		// Token: 0x0401AC44 RID: 109636
		public static readonly string[] BlockedRegions = new string[]
		{
			"TW",
			"KR"
		};

		// Token: 0x0401AC45 RID: 109637
		public static readonly int CacheTtlSecs = 2592000;

		// Token: 0x0401AC46 RID: 109638
		public static readonly int RequestTimeoutSecs = 3;

		// Token: 0x0401AC47 RID: 109639
		public static readonly bool FallbackBlockOnFailure = false;

		// Token: 0x0401AC48 RID: 109640
		public static readonly bool TestMode = false;

		// Token: 0x0401AC49 RID: 109641
		public static readonly string TestForcedRegion = "";

		// Token: 0x0401AC4A RID: 109642
		public static readonly SplashRegionGeoIpProvider[] GeoIpProviders = new SplashRegionGeoIpProvider[]
		{
			new SplashRegionGeoIpProvider("country.is", "https://api.country.is/", new Regex("\"country\"\\s*:\\s*\"(?<code>[A-Za-z]{2})\"")),
			new SplashRegionGeoIpProvider("ipinfo.io", "https://ipinfo.io/json", new Regex("\"country\"\\s*:\\s*\"(?<code>[A-Za-z]{2})\"")),
			new SplashRegionGeoIpProvider("ipapi.is", "https://api.ipapi.is/", new Regex("\"country_code\"\\s*:\\s*\"(?<code>[A-Za-z]{2})\""))
		};
	}
}
