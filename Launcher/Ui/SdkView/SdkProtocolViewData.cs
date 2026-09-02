using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.BaseConfig;
using CSharpScript.Launcher.Platform.PlatformSdk;

namespace CSharpScript.Launcher.Ui.SdkView
{
	// Token: 0x020044FD RID: 17661
	[NullableContext(1)]
	[Nullable(0)]
	public class SdkProtocolViewData
	{
		// Token: 0x0602E8C6 RID: 190662 RVA: 0x00B07530 File Offset: 0x00B05730
		public static SdkProtocolViewData CreateViewData(Action enterCallback, Action cancelCallback)
		{
			bool flag = Singleton<BaseConfigController>.Instance.GetPublicValue("SdkArea") != "CN";
			List<SdkProtocolViewLayoutData> list = new List<SdkProtocolViewLayoutData>();
			if (flag)
			{
				string teamOfService = Singleton<PlatformSdkConfig>.Instance.GetTermsOfService();
				string privacyPolicy = Singleton<PlatformSdkConfig>.Instance.GetPrivacyPolicy();
				if (!string.IsNullOrEmpty(teamOfService))
				{
					list.Add(SdkProtocolViewLayoutData.CreateLayoutData("UserProtocol", "手柄LT", delegate(SdkProtocolView owner)
					{
						SdkProtocolViewData.OpenWebView(owner, teamOfService);
					}));
				}
				if (!string.IsNullOrEmpty(privacyPolicy))
				{
					list.Add(SdkProtocolViewLayoutData.CreateLayoutData("PrivacyPolicy", "手柄RT", delegate(SdkProtocolView owner)
					{
						SdkProtocolViewData.OpenWebView(owner, privacyPolicy);
					}));
				}
			}
			else
			{
				string teamOfService = Singleton<PlatformSdkConfig>.Instance.GetTermsOfService();
				string privacyPolicy = Singleton<PlatformSdkConfig>.Instance.GetPrivacyPolicy();
				string childPolicy = Singleton<PlatformSdkConfig>.Instance.GetChildPolicy();
				if (!string.IsNullOrEmpty(teamOfService))
				{
					list.Add(SdkProtocolViewLayoutData.CreateLayoutData("UserProtocol", "手柄LT", delegate(SdkProtocolView owner)
					{
						SdkProtocolViewData.OpenWebView(owner, teamOfService);
					}));
				}
				if (!string.IsNullOrEmpty(privacyPolicy))
				{
					list.Add(SdkProtocolViewLayoutData.CreateLayoutData("PrivacyPolicy", "手柄RT", delegate(SdkProtocolView owner)
					{
						SdkProtocolViewData.OpenWebView(owner, privacyPolicy);
					}));
				}
				if (!string.IsNullOrEmpty(childPolicy))
				{
					list.Add(SdkProtocolViewLayoutData.CreateLayoutData("ChildProtocol", "手柄右边上键", delegate(SdkProtocolView owner)
					{
						SdkProtocolViewData.OpenWebView(owner, childPolicy);
					}));
				}
			}
			return SdkProtocolViewData.Create("SdkProtocolTitle", "SdkProtocolDesc", enterCallback, cancelCallback, list);
		}

		// Token: 0x0602E8C7 RID: 190663 RVA: 0x00B076BD File Offset: 0x00B058BD
		private static void OpenWebView(SdkProtocolView owner, string url)
		{
			PlatformSdkNew platformSdk = Singleton<PlatformSdkManagerNew>.Instance.GetPlatformSdk();
			if (platformSdk == null)
			{
				return;
			}
			platformSdk.OpenWebView(url, null);
		}

		// Token: 0x0602E8C8 RID: 190664 RVA: 0x00B076D5 File Offset: 0x00B058D5
		public static SdkProtocolViewData Create(string titleId, string descTextId, Action enterCallback, Action cancelCallback, List<SdkProtocolViewLayoutData> layoutData)
		{
			return new SdkProtocolViewData
			{
				TitleId = titleId,
				DescTextId = descTextId,
				EnterCallback = enterCallback,
				CancelCallback = cancelCallback,
				LayoutData = layoutData
			};
		}

		// Token: 0x0401A71F RID: 108319
		public string TitleId = "";

		// Token: 0x0401A720 RID: 108320
		public string DescTextId = "";

		// Token: 0x0401A721 RID: 108321
		[Nullable(2)]
		public Action EnterCallback;

		// Token: 0x0401A722 RID: 108322
		[Nullable(2)]
		public Action CancelCallback;

		// Token: 0x0401A723 RID: 108323
		public List<SdkProtocolViewLayoutData> LayoutData = new List<SdkProtocolViewLayoutData>();
	}
}
