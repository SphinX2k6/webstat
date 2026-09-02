using System;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.Update;
using UnrealEngine;

namespace CSharpScript.Game.Module.Menu.SubViews
{
	// Token: 0x0200579B RID: 22427
	public class VoiceLanguageSelectToggle : LanguageToggleBase
	{
		// Token: 0x06039097 RID: 233623 RVA: 0x00E746CB File Offset: 0x00E728CB
		protected override void OnRegisterComponent()
		{
			base.OnRegisterComponent();
		}

		// Token: 0x06039098 RID: 233624 RVA: 0x00E746D4 File Offset: 0x00E728D4
		protected override void OnStart()
		{
			base.OnStart();
			string audioCodeById = Singleton<GameSettingsManager>.Instance.GetAudioCodeById(this.Index);
			this.Updater = Singleton<LanguageUpdateManager>.Instance.GetUpdater(audioCodeById);
			UUIText text = base.GetText(2);
			text.SetUIActive(true);
			if (this.PreToggled)
			{
				Singleton<LguiUtil>.Instance.SetLocalText(text, "InUse", Array.Empty<object>());
				return;
			}
			if (this.Updater.Status != ELanguageDownloadStatus.Done)
			{
				Singleton<LguiUtil>.Instance.SetLocalText(text, "NotDownloaded", Array.Empty<object>());
				return;
			}
			text.SetText("", true);
		}

		// Token: 0x0402078D RID: 133005
		[Nullable(2)]
		public LanguageUpdater Updater;
	}
}
