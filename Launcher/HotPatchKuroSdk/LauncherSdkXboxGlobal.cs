using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.Json;
using UnrealEngine;

namespace CSharpScript.Launcher.HotPatchKuroSdk
{
	// Token: 0x0200460D RID: 17933
	public class LauncherSdkXboxGlobal : LauncherSdkBase
	{
		// Token: 0x0602EE62 RID: 192098 RVA: 0x00B1B8A4 File Offset: 0x00B19AA4
		[NullableContext(1)]
		public override void OpenUrl(string title, string url, bool isLandscape, bool transparent, bool webAccelerated, string identifier = "Default")
		{
			bool flag = false;
			if (transparent)
			{
				flag = true;
			}
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
					"titleBar",
					flag
				},
				{
					"webAccelerated",
					webAccelerated
				},
				{
					"identifier",
					identifier
				},
				{
					"innerbrowser",
					true
				}
			}, null);
			UKuroSDKManager.OpenWebView(url, title, isLandscape, transparent, webAccelerated, identifier, data);
		}
	}
}
