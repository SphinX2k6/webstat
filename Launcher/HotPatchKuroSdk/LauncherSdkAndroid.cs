using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.Json;
using UnrealEngine;

namespace CSharpScript.Launcher.HotPatchKuroSdk
{
	// Token: 0x02004607 RID: 17927
	[NullableContext(1)]
	[Nullable(0)]
	public class LauncherSdkAndroid : LauncherSdkBase
	{
		// Token: 0x0602EE4A RID: 192074 RVA: 0x00B1B2C4 File Offset: 0x00B194C4
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

		// Token: 0x0602EE4B RID: 192075 RVA: 0x00B1B37C File Offset: 0x00B1957C
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

		// Token: 0x0602EE4C RID: 192076 RVA: 0x00B1B3B8 File Offset: 0x00B195B8
		public override string GetChannelId()
		{
			string[] array = UKuroSDKManager.GetSdkParams("").Split(',', StringSplitOptions.None);
			for (int i = 0; i < array.Length; i++)
			{
				string[] array2 = array[i].Split('=', StringSplitOptions.None);
				if (array2.Length == 2 && array2[0] == "channelId")
				{
					return array2[1];
				}
			}
			return "";
		}
	}
}
