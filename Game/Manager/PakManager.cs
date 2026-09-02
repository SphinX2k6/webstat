using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Launcher.DiffPatch.Update;
using CSharpScript.Launcher.Update;
using UnrealEngine;

namespace CSharpScript.Game.Manager
{
	// Token: 0x020069F5 RID: 27125
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class PakManager : Singleton<PakManager>
	{
		// Token: 0x06043361 RID: 275297 RVA: 0x011463D2 File Offset: 0x011445D2
		public void Init()
		{
			if (this.UpdateCheckTimerId != null)
			{
				this.UpdateCheckTimerId.Remove();
				this.UpdateCheckTimerId = null;
			}
			UKuroPakKeyLibrary.BindPakMountedCallback(global::DelegateUtils.ToManualReleaseDelegate<FKuroPakMountedCallback>(new Action<string>(this.OnPakMounted)));
			this.StartPakKeyCheckTimer();
			this.StartFileSha1CheckTimer();
		}

		// Token: 0x06043362 RID: 275298 RVA: 0x01146414 File Offset: 0x01144614
		[NullableContext(1)]
		private void OnPakMounted(string pakFilename)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Event;
			ELogAuthor author = ELogAuthor.LRA;
			string message = "Pak挂载";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Filename", pakFilename);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			ConfigMultiTextLang.ClearMultiTextLangStatementIdsAndCache();
		}

		// Token: 0x06043363 RID: 275299 RVA: 0x01146450 File Offset: 0x01144650
		public void TestPakMounted()
		{
			Singleton<Log>.Instance.Info(ELogModule.Event, ELogAuthor.LRA, "测试Pak挂载", default(ReadOnlySpan<ValueTuple<string, object>>));
			UKuroPakMountStatic.MountPak(UKuroLauncherLibrary.GameSavedDir() + "Saved/Paks/pakchunk103-WindowsNoEditor.pak", 9999);
		}

		// Token: 0x06043364 RID: 275300 RVA: 0x01146494 File Offset: 0x01144694
		private void StartPakKeyCheckTimer()
		{
			if (!Singleton<PakKeyUpdate>.Instance.NeedExtPakKeys)
			{
				return;
			}
			if (Singleton<PakKeyUpdate>.Instance.UpdateCheckInterval > 0)
			{
				Singleton<Log>.Instance.Info(ELogModule.Event, ELogAuthor.LRA, "启动 pak timer.", default(ReadOnlySpan<ValueTuple<string, object>>));
				int num = Singleton<PakKeyUpdate>.Instance.UpdateCheckInterval * 1000;
				this.UpdateCheckTimerId = TimerSystem.GameplayTimeInstance.Forever(delegate(float _)
				{
					Singleton<PakKeyUpdate>.Instance.CheckPakKey(null, null);
					if (Singleton<VideoResUpdate>.Instance.GetIsSeparateVideo())
					{
						Singleton<PakKeyUpdate>.Instance.CheckVideoPakKey(null, null);
					}
				}, (float)num, 1f, null, null, false);
			}
		}

		// Token: 0x06043365 RID: 275301 RVA: 0x01146524 File Offset: 0x01144724
		private void StartFileSha1CheckTimer()
		{
			if (this.FileSha1CheckTimerId != null)
			{
				this.FileSha1CheckTimerId.Remove();
				this.FileSha1CheckTimerId = null;
			}
			this.FileSha1CheckTimerId = TimerSystem.GameplayTimeInstance.Forever(delegate(float _)
			{
				this.ProcessingSha1CheckResult();
			}, 60000f, 1f, null, null, false);
		}

		// Token: 0x06043366 RID: 275302 RVA: 0x01146578 File Offset: 0x01144778
		private void ProcessingSha1CheckResult()
		{
			if (UKuroPakMountStatic.IsSha1CheckWorking())
			{
				return;
			}
			int sha1CheckFailedCount = UKuroPakMountStatic.GetSha1CheckFailedCount();
			if (sha1CheckFailedCount > 0)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.ErrorCode;
				ELogAuthor author = ELogAuthor.LRA;
				string message = "文件Sha1校验失败";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Count", sha1CheckFailedCount);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.ErrorCodeTips);
				string localTextNew = ConfigMultiTextLang.GetLocalTextNew("ResourceVerificationFailed_Text", null);
				confirmBoxDataNew.SetTextArgs(new string[]
				{
					localTextNew
				});
				confirmBoxDataNew.FunctionMap[1] = new Action(this.<ProcessingSha1CheckResult>g__ConfirmCallback|8_0);
				ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
				return;
			}
			if (this.FileSha1CheckTimerId != null)
			{
				this.FileSha1CheckTimerId.Remove();
				this.FileSha1CheckTimerId = null;
			}
		}

		// Token: 0x06043367 RID: 275303 RVA: 0x01146627 File Offset: 0x01144827
		private void HandleSha1CheckFailures()
		{
			ControllerBase<LoginController>.Instance.LogLoginProcessLink(LoginDefine.ELoginStatus.PatchVerifyFail, Aki.Protocol.ErrorCode.Success);
			UKuroPakMountStatic.UnmountAllPaks();
			UKuroPakMountStatic.DeleteSha1CheckFailedFiles();
			AppUtil.QuitGame("Pak");
		}

		// Token: 0x06043368 RID: 275304 RVA: 0x0114664A File Offset: 0x0114484A
		public void Clear()
		{
			if (this.FileSha1CheckTimerId != null)
			{
				this.FileSha1CheckTimerId.Remove();
				this.FileSha1CheckTimerId = null;
			}
			global::DelegateUtils.ReleaseManualReleaseDelegate(new Action<string>(this.OnPakMounted));
			UKuroPakKeyLibrary.UnbindPakMountedCallback();
		}

		// Token: 0x0604336B RID: 275307 RVA: 0x0114668D File Offset: 0x0114488D
		[CompilerGenerated]
		private void <ProcessingSha1CheckResult>g__ConfirmCallback|8_0()
		{
			this.HandleSha1CheckFailures();
		}

		// Token: 0x04025790 RID: 153488
		private TimerHandle UpdateCheckTimerId;

		// Token: 0x04025791 RID: 153489
		private TimerHandle FileSha1CheckTimerId;

		// Token: 0x04025792 RID: 153490
		private const int FileSha1CheckTimerInterval = 60000;
	}
}
