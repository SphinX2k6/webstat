using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.Json;
using UnrealEngine;

namespace CSharpScript.Launcher.HotPatchKuroSdk
{
	// Token: 0x02004606 RID: 17926
	public class LauncherSdkCloud : LauncherSdkBase
	{
		// Token: 0x0602EE48 RID: 192072 RVA: 0x00B1B23C File Offset: 0x00B1943C
		[NullableContext(1)]
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
				}
			}, null);
			UKuroCloudGameWrapper.SendDataToPipeBinaryWithKey("OpenWebView", data);
		}
	}
}
