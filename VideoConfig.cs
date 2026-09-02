using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Plot;

// Token: 0x02002CE1 RID: 11489
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class VideoConfig : ConfigBase<VideoConfig>
{
	// Token: 0x0601726F RID: 94831 RVA: 0x0066A214 File Offset: 0x00668414
	protected override bool OnInit()
	{
		return true;
	}

	// Token: 0x06017270 RID: 94832 RVA: 0x0066A217 File Offset: 0x00668417
	protected override bool OnClear()
	{
		return true;
	}

	// Token: 0x06017271 RID: 94833 RVA: 0x0066A21C File Offset: 0x0066841C
	public VideoData? GetVideoData(string videoName)
	{
		EPlayerGender eplayerGender = ModelBase<PlayerInfoModel>.Instance.GetPlayerGender();
		if (eplayerGender == EPlayerGender.None)
		{
			eplayerGender = EPlayerGender.Female;
		}
		VideoData? config = ConfigVideoDataByCgNameAndGirlOrBoy.GetConfig(videoName, (int)eplayerGender, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Video;
			ELogAuthor author = ELogAuthor.ZWY;
			string message = "找不到cg视频配置！";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("名称", videoName);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}
		return config;
	}

	// Token: 0x06017272 RID: 94834 RVA: 0x0066A278 File Offset: 0x00668478
	public IReadOnlyList<VideoSubtitle> GetVideoCaptions(string videoName, string language)
	{
		IReadOnlyList<VideoCaption> configList = ConfigVideoCaptionByCgName.GetConfigList(videoName, true);
		if (configList == null || configList.Count == 0)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Video;
			ELogAuthor author = ELogAuthor.ZWY;
			string message = "找不到cg字幕配置！";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("名称", videoName);
			instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return new List<VideoSubtitle>();
		}
		List<VideoSubtitle> list = new List<VideoSubtitle>();
		if (!(language == "en"))
		{
			if (!(language == "ja"))
			{
				if (!(language == "ko"))
				{
					goto IL_18F;
				}
				goto IL_133;
			}
		}
		else
		{
			using (IEnumerator<VideoCaption> enumerator = configList.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					VideoCaption videoCaption = enumerator.Current;
					if (videoCaption.DurationEn != 0)
					{
						list.Add(new VideoSubtitle(videoCaption.ShowMomentEn, videoCaption.DurationEn, videoCaption.CaptionText, videoCaption.CaptionId, videoCaption.IsPlaySubtitleVoice));
					}
				}
				goto IL_18F;
			}
		}
		using (IEnumerator<VideoCaption> enumerator = configList.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				VideoCaption videoCaption2 = enumerator.Current;
				if (videoCaption2.DurationJa != 0)
				{
					list.Add(new VideoSubtitle(videoCaption2.ShowMomentJa, videoCaption2.DurationJa, videoCaption2.CaptionText, videoCaption2.CaptionId, videoCaption2.IsPlaySubtitleVoice));
				}
			}
			goto IL_18F;
		}
		IL_133:
		foreach (VideoCaption videoCaption3 in configList)
		{
			if (videoCaption3.DurationKo != 0)
			{
				list.Add(new VideoSubtitle(videoCaption3.ShowMomentKo, videoCaption3.DurationKo, videoCaption3.CaptionText, videoCaption3.CaptionId, videoCaption3.IsPlaySubtitleVoice));
			}
		}
		IL_18F:
		if (list.Count > 0)
		{
			return list;
		}
		foreach (VideoCaption videoCaption4 in configList)
		{
			list.Add(new VideoSubtitle(videoCaption4.ShowMoment, videoCaption4.Duration, videoCaption4.CaptionText, videoCaption4.CaptionId, videoCaption4.IsPlaySubtitleVoice));
		}
		return list;
	}

	// Token: 0x06017273 RID: 94835 RVA: 0x0066A4A8 File Offset: 0x006686A8
	public IReadOnlyList<VideoQteConfig> GetVideoQte(string videoName, string language)
	{
		IReadOnlyList<VideoQte> configList = ConfigVideoQteByCgName.GetConfigList(videoName, true);
		if (configList == null || configList.Count == 0)
		{
			return new List<VideoQteConfig>();
		}
		List<VideoQteConfig> list = new List<VideoQteConfig>();
		if (!(language == "en"))
		{
			if (!(language == "ja"))
			{
				if (!(language == "ko"))
				{
					goto IL_125;
				}
				goto IL_DE;
			}
		}
		else
		{
			using (IEnumerator<VideoQte> enumerator = configList.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					VideoQte videoQte = enumerator.Current;
					if (videoQte.ShowMomentEn != 0)
					{
						list.Add(new VideoQteConfig(videoQte.ShowMomentEn, videoQte.QteId));
					}
				}
				goto IL_125;
			}
		}
		using (IEnumerator<VideoQte> enumerator = configList.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				VideoQte videoQte2 = enumerator.Current;
				if (videoQte2.ShowMomentJa != 0)
				{
					list.Add(new VideoQteConfig(videoQte2.ShowMomentJa, videoQte2.QteId));
				}
			}
			goto IL_125;
		}
		IL_DE:
		foreach (VideoQte videoQte3 in configList)
		{
			if (videoQte3.ShowMomentKo != 0)
			{
				list.Add(new VideoQteConfig(videoQte3.ShowMomentKo, videoQte3.QteId));
			}
		}
		IL_125:
		if (list.Count > 0)
		{
			return list;
		}
		foreach (VideoQte videoQte4 in configList)
		{
			list.Add(new VideoQteConfig(videoQte4.ShowMoment, videoQte4.QteId));
		}
		return list;
	}

	// Token: 0x06017274 RID: 94836 RVA: 0x0066A658 File Offset: 0x00668858
	public string GetVideoCaptionText(VideoSubtitle videoCaption)
	{
		string localTextNew = ConfigMultiTextLang.GetLocalTextNew(videoCaption.CaptionText, null);
		return ModelBase<PlotModel>.Instance.PlotTextReplacer.Replace(localTextNew, false) ?? string.Empty;
	}

	// Token: 0x06017275 RID: 94837 RVA: 0x0066A68C File Offset: 0x0066888C
	public IReadOnlyList<VideoSound> GetVideoSounds(string videoName)
	{
		IReadOnlyList<VideoSound> configList = ConfigVideoSoundByCgNameAndGirlOrBoy.GetConfigList(videoName, 2, true);
		if (configList == null || configList.Count == 0)
		{
			EPlayerGender eplayerGender = ModelBase<PlayerInfoModel>.Instance.GetPlayerGender();
			if (eplayerGender == EPlayerGender.None)
			{
				eplayerGender = EPlayerGender.Female;
			}
			configList = ConfigVideoSoundByCgNameAndGirlOrBoy.GetConfigList(videoName, (int)eplayerGender, true);
		}
		if (configList == null || configList.Count == 0)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Video;
			ELogAuthor author = ELogAuthor.ZWY;
			string message = "找不到cg字幕配置！";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("名称", videoName);
			instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return new List<VideoSound>();
		}
		return configList;
	}
}
