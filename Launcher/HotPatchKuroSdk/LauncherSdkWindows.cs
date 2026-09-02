using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.Encodings.Web;
using System.Text.Json;
using UnrealEngine;

namespace CSharpScript.Launcher.HotPatchKuroSdk
{
	// Token: 0x0200460A RID: 17930
	[NullableContext(1)]
	[Nullable(0)]
	public class LauncherSdkWindows : LauncherSdkBase
	{
		// Token: 0x0602EE56 RID: 192086 RVA: 0x00B1B4EC File Offset: 0x00B196EC
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
					"innerbrowser",
					true
				},
				{
					"identifier",
					identifier
				}
			}, null);
			UKuroSDKManager.OpenWebView(url, title, isLandscape, transparent, webAccelerated, identifier, data);
		}

		// Token: 0x0602EE57 RID: 192087 RVA: 0x00B1B570 File Offset: 0x00B19770
		protected override string GetPlatformFontStr()
		{
			string currentFontName = base.GetCurrentFontName();
			string value = UBlueprintPathsLibrary.RootDir() + "Client/Binaries/Win64/ThirdParty/KrPcSdk_Mainland/" + base.GetDeviceFontAsset();
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			dictionary.Add("name", currentFontName);
			dictionary.Add("path", value);
			JsonSerializerOptions options = new JsonSerializerOptions
			{
				Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
			};
			return JsonSerializer.Serialize<Dictionary<string, string>>(dictionary, options);
		}

		// Token: 0x0602EE58 RID: 192088 RVA: 0x00B1B5D0 File Offset: 0x00B197D0
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
