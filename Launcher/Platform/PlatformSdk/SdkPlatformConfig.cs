using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Launcher.Platform.PlatformSdk
{
	// Token: 0x0200455B RID: 17755
	[NullableContext(1)]
	[Nullable(0)]
	public class SdkPlatformConfig
	{
		// Token: 0x0401A899 RID: 108697
		public string PrivacyPolicy;

		// Token: 0x0401A89A RID: 108698
		public string TermsOfService;

		// Token: 0x0401A89B RID: 108699
		public string ChildProtocol;

		// Token: 0x0401A89C RID: 108700
		public List<string> ServerUrl;

		// Token: 0x0401A89D RID: 108701
		public List<string> PayUrl;

		// Token: 0x0401A89E RID: 108702
		public string client_id;

		// Token: 0x0401A89F RID: 108703
		public string client_secret;

		// Token: 0x0401A8A0 RID: 108704
		public string platform_pkg;

		// Token: 0x0401A8A1 RID: 108705
		public string platform_client_id;

		// Token: 0x0401A8A2 RID: 108706
		public string platform_client_secret;

		// Token: 0x0401A8A3 RID: 108707
		public string UserCenterUrl;

		// Token: 0x0401A8A4 RID: 108708
		public string CustomServiceUrl;

		// Token: 0x0401A8A5 RID: 108709
		public string DataReportUrl;

		// Token: 0x0401A8A6 RID: 108710
		public string DataReportId;

		// Token: 0x0401A8A7 RID: 108711
		public string kuro_DataReportUrl;

		// Token: 0x0401A8A8 RID: 108712
		public Dictionary<string, CsLinkEntry> cs_links;
	}
}
