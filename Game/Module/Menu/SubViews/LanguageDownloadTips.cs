using System;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.Ui.HotFix;
using CSharpScript.Launcher.Update;

namespace CSharpScript.Game.Module.Menu.SubViews
{
	// Token: 0x02005798 RID: 22424
	[NullableContext(1)]
	[Nullable(0)]
	public class LanguageDownloadTips : ResourceUpdateViewBase
	{
		// Token: 0x06039081 RID: 233601 RVA: 0x00E73C26 File Offset: 0x00E71E26
		public LanguageDownloadTips(LanguageUpdater updater, string languageTest)
		{
			this.Updater = updater;
			this.LanguageText = languageTest;
		}

		// Token: 0x06039082 RID: 233602 RVA: 0x00E73C48 File Offset: 0x00E71E48
		public override void UpdatePatchProgress(long receiveSize, long curProgress, long totalProgress, long downloadSpeed)
		{
			if (this.Updater == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.HotPatch, ELogAuthor.WZ, "UpdatePatchProgress时，找不到对应的LanguageUpdater", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			if (curProgress == totalProgress)
			{
				this.Updater.CalculateDownloadStatus("LanguageDownloadTips UpdatePatchProgress");
				if (this.Updater.Status == ELanguageDownloadStatus.Done)
				{
					ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("LanguageDownloadFinished", new object[]
					{
						this.LanguageText
					});
				}
			}
		}

		// Token: 0x04020787 RID: 132999
		[Nullable(2)]
		private readonly LanguageUpdater Updater;

		// Token: 0x04020788 RID: 133000
		private readonly string LanguageText = "";
	}
}
