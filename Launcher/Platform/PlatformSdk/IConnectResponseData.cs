using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Launcher.Platform.PlatformSdk
{
	// Token: 0x020045A8 RID: 17832
	[NullableContext(1)]
	[Nullable(0)]
	public class IConnectResponseData
	{
		// Token: 0x0401A97C RID: 108924
		public ThirdLogin thirdLogin;

		// Token: 0x0401A97D RID: 108925
		public int heartFreq;

		// Token: 0x0401A97E RID: 108926
		public int heartEnable;

		// Token: 0x0401A97F RID: 108927
		public string uagr;

		// Token: 0x0401A980 RID: 108928
		public string pagr;

		// Token: 0x0401A981 RID: 108929
		public string childArgUrl;

		// Token: 0x0401A982 RID: 108930
		public string pwdLife;

		// Token: 0x0401A983 RID: 108931
		public ClientSwitch clientSwitch;

		// Token: 0x0401A984 RID: 108932
		public ClientUrl clientUrl;

		// Token: 0x0401A985 RID: 108933
		public int kefuInterval;

		// Token: 0x0401A986 RID: 108934
		public ThirdShareParams thirdShareParams;

		// Token: 0x0401A987 RID: 108935
		public int regionMinAge;

		// Token: 0x0401A988 RID: 108936
		public bool ageCheckBox;

		// Token: 0x0401A989 RID: 108937
		public bool didSmSwitch;

		// Token: 0x0401A98A RID: 108938
		public bool didTxSwitch;

		// Token: 0x0401A98B RID: 108939
		public bool geetestSwitch;

		// Token: 0x0401A98C RID: 108940
		public bool audioSwitch;

		// Token: 0x0401A98D RID: 108941
		public bool iosCrossDistrict;

		// Token: 0x0401A98E RID: 108942
		public bool googleCrossDistrict;

		// Token: 0x0401A98F RID: 108943
		public int googlePcConsumeIntervalSec;
	}
}
