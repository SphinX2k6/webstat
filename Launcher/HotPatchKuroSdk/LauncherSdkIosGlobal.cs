using System;
using System.Runtime.CompilerServices;
using System.Text.Json;
using UnrealEngine;

namespace CSharpScript.Launcher.HotPatchKuroSdk
{
	// Token: 0x02004608 RID: 17928
	[NullableContext(1)]
	[Nullable(0)]
	public class LauncherSdkIosGlobal : LauncherSdkBase
	{
		// Token: 0x0602EE4E RID: 192078 RVA: 0x00B1B418 File Offset: 0x00B19618
		public override void OpenUrl(string title, string url, bool isLandscape, bool transparent, bool webAccelerated, string identifier = "Default")
		{
			UKuroSDKManager.OpenWebView(title, url, isLandscape, transparent, webAccelerated, identifier, "");
		}

		// Token: 0x0602EE4F RID: 192079 RVA: 0x00B1B42D File Offset: 0x00B1962D
		protected override string GetPlatformFontStr()
		{
			return base.GetDeviceFontAsset();
		}

		// Token: 0x0602EE50 RID: 192080 RVA: 0x00B1B438 File Offset: 0x00B19638
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
