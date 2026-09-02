using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.DiffPatch.Update;
using CSharpScript.Launcher.Download;

namespace CSharpScript.Launcher.Update
{
	// Token: 0x020044D2 RID: 17618
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class VideoUpdateManager : Singleton<VideoUpdateManager>
	{
		// Token: 0x0602E7B1 RID: 190385 RVA: 0x00B01908 File Offset: 0x00AFFB08
		private VideoUpdater CreateUpdater(string name)
		{
			VideoUpdater videoUpdater = new VideoUpdater();
			videoUpdater.Downloader = new UrlPrefixDownload();
			UpdateReportEvent reportEvent = new UpdateReportEvent(name);
			VideoUpdateUiEvent uiEvent = new VideoUpdateUiEvent();
			videoUpdater.DiffUpdater = new DiffUpdate(new List<ResPackageInfo>(), videoUpdater.Downloader, uiEvent, reportEvent, true, EUpdateType.IndependentLang);
			videoUpdater.Init(uiEvent);
			return videoUpdater;
		}

		// Token: 0x0602E7B2 RID: 190386 RVA: 0x00B01957 File Offset: 0x00AFFB57
		public VideoUpdater GetInGameUpdater()
		{
			if (this.InGameUpdater == null)
			{
				this.InGameUpdater = this.CreateUpdater("in-game");
			}
			return this.InGameUpdater;
		}

		// Token: 0x0602E7B3 RID: 190387 RVA: 0x00B01978 File Offset: 0x00AFFB78
		public VideoUpdater GetVideoUpdater(EVideoResSizeType resType)
		{
			if (this.VideoUpdaterMap.ContainsKey(resType))
			{
				return this.VideoUpdaterMap[resType];
			}
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
			defaultInterpolatedStringHandler.AppendFormatted<EVideoResSizeType>(resType);
			VideoUpdater videoUpdater = this.CreateUpdater(defaultInterpolatedStringHandler.ToStringAndClear());
			this.VideoUpdaterMap[resType] = videoUpdater;
			return videoUpdater;
		}

		// Token: 0x0602E7B4 RID: 190388 RVA: 0x00B019D0 File Offset: 0x00AFFBD0
		public VideoUpdater GetVideoUpdaterWithName(EVideoResSizeType resType, string name)
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
			defaultInterpolatedStringHandler.AppendFormatted<EVideoResSizeType>(resType);
			defaultInterpolatedStringHandler.AppendLiteral("_");
			defaultInterpolatedStringHandler.AppendFormatted(name);
			string text = defaultInterpolatedStringHandler.ToStringAndClear();
			if (this.VideoUpdaterMapWithName.ContainsKey(text))
			{
				return this.VideoUpdaterMapWithName[text];
			}
			VideoUpdater videoUpdater = this.CreateUpdater(text);
			this.VideoUpdaterMapWithName[text] = videoUpdater;
			return videoUpdater;
		}

		// Token: 0x0602E7B5 RID: 190389 RVA: 0x00B01A3B File Offset: 0x00AFFC3B
		public VideoUpdater GetLoginLoadingUpdater()
		{
			if (this.LoginLoadingUpdater == null)
			{
				this.LoginLoadingUpdater = this.CreateUpdater("login-loading");
			}
			return this.LoginLoadingUpdater;
		}

		// Token: 0x0602E7B6 RID: 190390 RVA: 0x00B01A5C File Offset: 0x00AFFC5C
		public void StopAllDownload()
		{
			if (this.InGameUpdater != null)
			{
				this.InGameUpdater.Pause();
			}
		}

		// Token: 0x0401A684 RID: 108164
		[Nullable(2)]
		private VideoUpdater LoginLoadingUpdater;

		// Token: 0x0401A685 RID: 108165
		[Nullable(2)]
		private VideoUpdater InGameUpdater;

		// Token: 0x0401A686 RID: 108166
		private readonly Dictionary<string, VideoUpdater> VideoUpdaterMapWithName = new Dictionary<string, VideoUpdater>();

		// Token: 0x0401A687 RID: 108167
		private readonly Dictionary<EVideoResSizeType, VideoUpdater> VideoUpdaterMap = new Dictionary<EVideoResSizeType, VideoUpdater>();
	}
}
