using System;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.BaseConfig;
using UnrealEngine;

namespace CSharpScript.Launcher.Platform.PlatformSdk
{
	// Token: 0x0200455E RID: 17758
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class PlatformSdkManagerNew : Singleton<PlatformSdkManagerNew>
	{
		// Token: 0x0602EB7A RID: 191354 RVA: 0x00B11988 File Offset: 0x00B0FB88
		public bool Initialize(UObject worldContext)
		{
			if (!this.IsSdkOn)
			{
				Singleton<LauncherLog>.Instance.Info("[PlatformSdkNew] PlatformSdkManagerNew.Initialize: 平台Sdk未开启", default(ReadOnlySpan<ValueTuple<string, object>>));
				return true;
			}
			this.SwitchPlatformSdk();
			Singleton<PlatformSdkConfig>.Instance.Initialize();
			Singleton<PlatformSdkServer>.Instance.Initialize();
			return this.PlatformSdk.Initialize(worldContext);
		}

		// Token: 0x0602EB7B RID: 191355 RVA: 0x00B119E2 File Offset: 0x00B0FBE2
		public void UnInitialize()
		{
			PlatformSdkNew platformSdk = this.PlatformSdk;
			if (platformSdk == null)
			{
				return;
			}
			platformSdk.UnInitialize();
		}

		// Token: 0x0602EB7C RID: 191356 RVA: 0x00B119F8 File Offset: 0x00B0FBF8
		private void SwitchPlatformSdk()
		{
			LauncherLog instance = Singleton<LauncherLog>.Instance;
			string message = "当前平台";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("type", Singleton<Platform>.Instance.Type);
			instance.Info(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			if (Singleton<Platform>.Instance.Type == EPlatformType.PS5)
			{
				this.PlatformSdk = new PlayStation5Sdk();
			}
		}

		// Token: 0x0602EB7D RID: 191357 RVA: 0x00B11A4E File Offset: 0x00B0FC4E
		public PlatformSdkNew GetPlatformSdk()
		{
			return this.PlatformSdk;
		}

		// Token: 0x17008060 RID: 32864
		// (get) Token: 0x0602EB7E RID: 191358 RVA: 0x00B11A56 File Offset: 0x00B0FC56
		public bool IsSdkOn
		{
			get
			{
				return Singleton<Platform>.Instance.Type == EPlatformType.PS5 && Singleton<BaseConfigController>.Instance.GetPublicValue("UseSDK") == "1";
			}
		}

		// Token: 0x17008061 RID: 32865
		// (get) Token: 0x0602EB7F RID: 191359 RVA: 0x00B11A80 File Offset: 0x00B0FC80
		public bool IfNeedPlatformSdkConfig
		{
			get
			{
				return Singleton<Platform>.Instance.Type == EPlatformType.PS5 && Singleton<BaseConfigController>.Instance.GetPublicValue("UseSDK") == "1";
			}
		}

		// Token: 0x0401A8B1 RID: 108721
		private PlatformSdkNew PlatformSdk = new PlatformSdkNew();
	}
}
