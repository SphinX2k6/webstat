using System;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using CSharpScript.Launcher.Util;
using UnrealEngine;

namespace CSharpScript.Launcher.Platform
{
	// Token: 0x02004551 RID: 17745
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class CloudGameManagerLauncher : Singleton<CloudGameManagerLauncher>
	{
		// Token: 0x0602EB29 RID: 191273 RVA: 0x00B10850 File Offset: 0x00B0EA50
		public unsafe void Init()
		{
			if (!Singleton<Platform>.Instance.IsCloudGame())
			{
				return;
			}
			if (this.IsInited)
			{
				return;
			}
			this.IsInited = true;
			string commandLine = UKismetSystemLibrary.GetCommandLine();
			this.IsPreLaunch = commandLine.Contains("-CloudGamePreLaunch");
			bool flag = commandLine.Contains("-Reboot");
			Match match = this.CloudGameServerTagRegex.Match(commandLine);
			if (match.Success)
			{
				this.ServerTag = match.Groups[1].Value;
			}
			if (!this.IsPreLaunch)
			{
				Match match2 = new Regex("-CloudGamePlatform=([^\\s]+)").Match(commandLine);
				if (match2.Success)
				{
					Singleton<Platform>.Instance.CloudGamePlatform = match2.Groups[1].Value;
				}
			}
			if (this.IsPreLaunch && !flag)
			{
				Singleton<LauncherStorageLib>.Instance.LockDbPath(true, "CloudGameManagerLauncher");
			}
			LauncherLog instance = Singleton<LauncherLog>.Instance;
			string message = "云游戏初始化 launcher";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("IsPreLaunch", this.IsPreLaunch);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("isReboot", flag);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("ServerTag", this.ServerTag);
			instance.Info(message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
		}

		// Token: 0x0401A869 RID: 108649
		public const string CLOUD_GAME_REBOOT_CMD = "-Reboot";

		// Token: 0x0401A86A RID: 108650
		public const string CLOUD_GAME_PRE_LAUNCH_CMD = "-CloudGamePreLaunch";

		// Token: 0x0401A86B RID: 108651
		private readonly Regex CloudGameServerTagRegex = new Regex("-ServerTag=([^\\s]+)");

		// Token: 0x0401A86C RID: 108652
		private bool IsInited;

		// Token: 0x0401A86D RID: 108653
		public bool IsPreLaunch;

		// Token: 0x0401A86E RID: 108654
		public string ServerTag = "";
	}
}
