using System;
using System.Runtime.CompilerServices;
using System.Text.Json;
using UnrealEngine;

namespace CSharpScript.Launcher.HotPatchKuroSdk
{
	// Token: 0x02004609 RID: 17929
	[NullableContext(1)]
	[Nullable(0)]
	public class LauncherSdkMacGlobal : LauncherSdkBase
	{
		// Token: 0x0602EE52 RID: 192082 RVA: 0x00B1B483 File Offset: 0x00B19683
		public override void OpenUrl(string title, string url, bool isLandscape, bool transparent, bool webAccelerated, string identifier = "Default")
		{
			UKuroSDKManager.OpenWebView(title, url, isLandscape, transparent, webAccelerated, identifier, "");
		}

		// Token: 0x0602EE53 RID: 192083 RVA: 0x00B1B498 File Offset: 0x00B19698
		protected override string GetPlatformFontStr()
		{
			return base.GetDeviceFontAsset();
		}

		// Token: 0x0602EE54 RID: 192084 RVA: 0x00B1B4A0 File Offset: 0x00B196A0
		public override string GetChannelId()
		{
			string sdkParams = UKuroSDKManager.GetSdkParams("");
			if (!base.IsValidJsonStr(sdkParams))
			{
				return "";
			}
			UserInfo userInfo = JsonSerializer.Deserialize<UserInfo>(sdkParams, null);
			return ((userInfo != null) ? userInfo.channelId : null) ?? "";
		}
	}
}
