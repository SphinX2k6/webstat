using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.DiffPatch.Data;
using CSharpScript.Launcher.DiffPatch.Update;
using CSharpScript.Launcher.Platform;
using CSharpScript.Launcher.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Launcher.Update.ResourceDiffUpdate.Module
{
	// Token: 0x020044E4 RID: 17636
	[NullableContext(1)]
	[Nullable(0)]
	public class VoiceResourceModule : BaseResourceModule
	{
		// Token: 0x0602E82F RID: 190511 RVA: 0x00B05624 File Offset: 0x00B03824
		[NullableContext(0)]
		public override UniTask<bool> PrepareManifests()
		{
			VoiceResourceModule.<PrepareManifests>d__1 <PrepareManifests>d__;
			<PrepareManifests>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<PrepareManifests>d__.<>1__state = -1;
			<PrepareManifests>d__.<>t__builder.Start<VoiceResourceModule.<PrepareManifests>d__1>(ref <PrepareManifests>d__);
			return <PrepareManifests>d__.<>t__builder.Task;
		}

		// Token: 0x0602E830 RID: 190512 RVA: 0x00B05660 File Offset: 0x00B03860
		public unsafe override PackClassification ClassifyPacks(ResourceSelectionContext context, bool forceMax = false)
		{
			HashSet<string> hashSet = new HashSet<string>(Singleton<LauncherLanguageLib>.Instance.GetUsedAudioCodes());
			bool flag = !this.IsVoiceDownloadEnable();
			List<ResPackageInfo> list = new List<ResPackageInfo>();
			long num = 0L;
			foreach (KeyValuePair<string, ResPackageInfo> keyValuePair in ResPackageInfo.RoleVoiceInfos)
			{
				string key = keyValuePair.Key;
				ResPackageInfo value = keyValuePair.Value;
				if (!flag)
				{
					string audioCodeFromPackKey = this.GetAudioCodeFromPackKey(key);
					if (!hashSet.Contains(audioCodeFromPackKey) && string.IsNullOrEmpty(value.ResourceVersionInfo.RecordVersion))
					{
						continue;
					}
				}
				List<RequireFileInfo> item = value.AnalyzeRequireFiles(false).Item1;
				long num2 = 0L;
				foreach (RequireFileInfo requireFileInfo in item)
				{
					num2 += requireFileInfo.Size;
				}
				Singleton<LauncherLog>.Instance.Info("RoleVoice package 已下载过的角色语音包 " + key + ", 会自动参与更新.", default(ReadOnlySpan<ValueTuple<string, object>>));
				list.Add(value);
				num += num2;
			}
			LauncherLog instance = Singleton<LauncherLog>.Instance;
			string message = "RoleVoice package 分类完成";
			<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("downloadAll", flag);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("usedAudioCodes", string.Join(",", hashSet));
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("count", list.Count);
			ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3);
			string item2 = "totalSize";
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(3, 1);
			defaultInterpolatedStringHandler.AppendFormatted<long>(num / 1048576L);
			defaultInterpolatedStringHandler.AppendLiteral(" MB");
			ptr = new ValueTuple<string, object>(item2, defaultInterpolatedStringHandler.ToStringAndClear());
			instance.Info(message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
			return new PackClassification
			{
				MinPacks = list,
				MaxPacks = list,
				MinSize = num,
				MaxSize = num
			};
		}

		// Token: 0x0602E831 RID: 190513 RVA: 0x00B0587C File Offset: 0x00B03A7C
		public bool IsVoiceDownloadEnable()
		{
			return Singleton<VideoResUpdate>.Instance.GetIsSeparateVideo() && !Singleton<Platform>.Instance.IsCloudGame() && !Singleton<Platform>.Instance.IsMacPlatform();
		}

		// Token: 0x0602E832 RID: 190514 RVA: 0x00B058A8 File Offset: 0x00B03AA8
		public override long GetLocalSize(IReadOnlyList<string> pakNames)
		{
			long num = 0L;
			foreach (string text in pakNames)
			{
				ResPackageInfo roleVoiceInfo = ResPackageInfo.GetRoleVoiceInfo(text);
				if (roleVoiceInfo != null)
				{
					long item = roleVoiceInfo.AnalyzeRequireFiles(false).Rest.Item1;
					num += item;
				}
				else
				{
					Singleton<LauncherLog>.Instance.Warn("RoleVoice package 获取角色语音大小时未找到资源包信息: " + text, default(ReadOnlySpan<ValueTuple<string, object>>));
				}
			}
			return num;
		}

		// Token: 0x0602E833 RID: 190515 RVA: 0x00B05930 File Offset: 0x00B03B30
		public override void Delete(IReadOnlyList<string> pakNames)
		{
			foreach (string text in pakNames)
			{
				ResPackageInfo roleVoiceInfo = ResPackageInfo.GetRoleVoiceInfo(text);
				if (roleVoiceInfo != null)
				{
					roleVoiceInfo.DeleteLocalFiles();
					roleVoiceInfo.ClearRecord();
				}
				else
				{
					Singleton<LauncherLog>.Instance.Warn("RoleVoice package 卸载角色语音时未找到资源包信息: " + text, default(ReadOnlySpan<ValueTuple<string, object>>));
				}
			}
		}

		// Token: 0x0602E834 RID: 190516 RVA: 0x00B059A8 File Offset: 0x00B03BA8
		public long GetLocalSizeByAudioCode(string audioCode)
		{
			long num = 0L;
			ResPackageInfo languageInfo = ResPackageInfo.GetLanguageInfo(audioCode);
			if (languageInfo != null)
			{
				ValueTuple<List<RequireFileInfo>, long, long, long, long, long, long, ValueTuple<long, int>> valueTuple = languageInfo.AnalyzeRequireFiles(false);
				long num2 = valueTuple.Item2 + valueTuple.Rest.Item1;
				num += num2;
			}
			foreach (ValueTuple<string, ResPackageInfo> valueTuple2 in this.GetRoleVoicesByAudioCode(audioCode))
			{
				ValueTuple<List<RequireFileInfo>, long, long, long, long, long, long, ValueTuple<long, int>> valueTuple3 = valueTuple2.Item2.AnalyzeRequireFiles(false);
				long num3 = valueTuple3.Item2 + valueTuple3.Rest.Item1;
				num += num3;
			}
			return num;
		}

		// Token: 0x0602E835 RID: 190517 RVA: 0x00B05A4C File Offset: 0x00B03C4C
		public void DeleteByAudioCode(string audioCode)
		{
			ResPackageInfo languageInfo = ResPackageInfo.GetLanguageInfo(audioCode);
			if (languageInfo != null)
			{
				languageInfo.DeleteLocalFiles();
				languageInfo.ClearRecord();
				Singleton<LauncherLog>.Instance.Info("RoleVoice package 已删除语言包: " + audioCode, default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			foreach (ValueTuple<string, ResPackageInfo> valueTuple in this.GetRoleVoicesByAudioCode(audioCode))
			{
				string item = valueTuple.Item1;
				ResPackageInfo item2 = valueTuple.Item2;
				item2.DeleteLocalFiles();
				item2.ClearRecord();
				Singleton<LauncherLog>.Instance.Info("RoleVoice package 已删除角色语音包: " + item, default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			LanguageUpdater updater = Singleton<LanguageUpdateManager>.Instance.GetUpdater(audioCode);
			if (updater != null)
			{
				updater.CalculateDownloadStatus("VoiceModule DeleteByAudioCode");
				updater.Status = ELanguageDownloadStatus.None;
			}
		}

		// Token: 0x0602E836 RID: 190518 RVA: 0x00B05B24 File Offset: 0x00B03D24
		private string GetAudioCodeFromPackKey(string packKey)
		{
			string[] array = packKey.Split('_', StringSplitOptions.None);
			return array[array.Length - 1];
		}

		// Token: 0x0602E837 RID: 190519 RVA: 0x00B05B38 File Offset: 0x00B03D38
		[return: Nullable(new byte[]
		{
			1,
			0,
			1,
			1
		})]
		private List<ValueTuple<string, ResPackageInfo>> GetRoleVoicesByAudioCode(string audioCode)
		{
			List<ValueTuple<string, ResPackageInfo>> list = new List<ValueTuple<string, ResPackageInfo>>();
			foreach (KeyValuePair<string, ResPackageInfo> keyValuePair in ResPackageInfo.RoleVoiceInfos)
			{
				if (this.GetAudioCodeFromPackKey(keyValuePair.Key) == audioCode)
				{
					list.Add(new ValueTuple<string, ResPackageInfo>(keyValuePair.Key, keyValuePair.Value));
				}
			}
			return list;
		}

		// Token: 0x0401A6CD RID: 108237
		private const long MB_SIZE = 1048576L;
	}
}
