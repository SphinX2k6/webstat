using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.Json;
using UnrealEngine;

namespace CSharpScript.Launcher.HotPatchKuroSdk
{
	// Token: 0x0200460C RID: 17932
	[NullableContext(1)]
	[Nullable(0)]
	public class LauncherSdkOpenHarmony : LauncherSdkBase
	{
		// Token: 0x0602EE5E RID: 192094 RVA: 0x00B1B764 File Offset: 0x00B19964
		public override void OpenUrl(string title, string url, bool isLandscape, bool transparent, bool webAccelerated, string identifier = "Default")
		{
			string data = JsonSerializer.Serialize<Dictionary<string, object>>(new Dictionary<string, object>
			{
				{
					"title",
					title
				},
				{
					"url",
					url
				},
				{
					"transparent",
					transparent
				},
				{
					"webAccelerated",
					webAccelerated
				},
				{
					"isLandscape",
					isLandscape
				},
				{
					"identifier",
					identifier
				},
				{
					"refreshButtonShowed",
					true
				},
				{
					"transparentCloseButtonAlwaysShowed",
					false
				},
				{
					"showInDialog",
					true
				}
			}, null);
			UKuroSDKManager.OpenWebView(url, title, isLandscape, transparent, webAccelerated, identifier, data);
		}

		// Token: 0x0602EE5F RID: 192095 RVA: 0x00B1B81C File Offset: 0x00B19A1C
		protected override string GetPlatformFontStr()
		{
			string deviceFontAsset = base.GetDeviceFontAsset();
			return JsonSerializer.Serialize<Dictionary<string, string>>(new Dictionary<string, string>
			{
				{
					"fontType",
					"1"
				},
				{
					"fontPath",
					deviceFontAsset
				}
			}, null);
		}

		// Token: 0x0602EE60 RID: 192096 RVA: 0x00B1B858 File Offset: 0x00B19A58
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
