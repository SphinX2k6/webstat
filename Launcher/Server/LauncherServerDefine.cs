using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Launcher.Server
{
	// Token: 0x02004537 RID: 17719
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class LauncherServerDefine : Singleton<LauncherServerDefine>
	{
		// Token: 0x0602EA6E RID: 191086 RVA: 0x00B0DB6C File Offset: 0x00B0BD6C
		public string[] GetServerLimitConfig(string region)
		{
			if (this.RegionMap.Count == 0)
			{
				this.RegionMap["America"] = this.America;
				this.RegionMap["Asia"] = this.Asia;
				this.RegionMap["Europe"] = this.Europe;
				this.RegionMap["HMT"] = this.HMT;
				this.RegionMap["SEA"] = this.SEA;
			}
			string[] result;
			if (!this.RegionMap.TryGetValue(region, out result))
			{
				return Array.Empty<string>();
			}
			return result;
		}

		// Token: 0x0401A7E6 RID: 108518
		public const string DEFAULTSERVERREGION = "America";

		// Token: 0x0401A7E7 RID: 108519
		public const string SEASERVER = "SEA";

		// Token: 0x0401A7E8 RID: 108520
		public const string CNSERVERNAME = "Default";

		// Token: 0x0401A7E9 RID: 108521
		public const int DEFAULTPING = 9999;

		// Token: 0x0401A7EA RID: 108522
		public const int ICMP_TIME_OUT = 2;

		// Token: 0x0401A7EB RID: 108523
		private readonly Dictionary<string, string[]> RegionMap = new Dictionary<string, string[]>();

		// Token: 0x0401A7EC RID: 108524
		private readonly string[] America = new string[]
		{
			"ar",
			"bo",
			"br",
			"ca",
			"cl",
			"co",
			"cr",
			"ec",
			"sv",
			"gt",
			"hn",
			"mx",
			"ni",
			"pa",
			"py",
			"pe",
			"us",
			"uy"
		};

		// Token: 0x0401A7ED RID: 108525
		private readonly string[] Asia = new string[]
		{
			"jp",
			"kr"
		};

		// Token: 0x0401A7EE RID: 108526
		private readonly string[] Europe = new string[]
		{
			"at",
			"bh",
			"be",
			"bg",
			"hr",
			"cy",
			"cz",
			"dk",
			"fi",
			"fr",
			"de",
			"gr",
			"hu",
			"is",
			"ie",
			"il",
			"it",
			"kw",
			"lb",
			"lu",
			"mt",
			"nl",
			"no",
			"om",
			"pl",
			"pt",
			"qa",
			"ro",
			"ru",
			"sa",
			"sk",
			"si",
			"za",
			"es",
			"se",
			"ch",
			"tr",
			"ua",
			"ae",
			"gb"
		};

		// Token: 0x0401A7EF RID: 108527
		private readonly string[] HMT = new string[]
		{
			"tw",
			"hk"
		};

		// Token: 0x0401A7F0 RID: 108528
		private readonly string[] SEA = new string[]
		{
			"au",
			"nz",
			"in",
			"id",
			"my",
			"sg",
			"th"
		};
	}
}
