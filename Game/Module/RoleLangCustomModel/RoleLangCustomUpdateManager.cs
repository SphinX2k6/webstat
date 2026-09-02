using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Launcher.Update;
using CSharpScript.Launcher.Update.ResourceDiffUpdate;
using CSharpScript.Launcher.Update.ResourceDiffUpdate.Updater;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.RoleLangCustomModel
{
	// Token: 0x020050F4 RID: 20724
	[NullableContext(1)]
	[Nullable(0)]
	public class RoleLangCustomUpdateManager
	{
		// Token: 0x06035692 RID: 218770 RVA: 0x00D65B97 File Offset: 0x00D63D97
		public void Init()
		{
		}

		// Token: 0x06035693 RID: 218771 RVA: 0x00D65B99 File Offset: 0x00D63D99
		public void Clear()
		{
			this.UpdaterMap.Clear();
			this.CreatingMap.Clear();
			this.CreatingPauseMap.Clear();
			this.RunningSet.Clear();
		}

		// Token: 0x06035694 RID: 218772 RVA: 0x00D65BC8 File Offset: 0x00D63DC8
		public string GetPackageName(IRoleLangCustomLangPackageInfo info)
		{
			string roleLangStateGroup = ConfigBase<RoleConfig>.Instance.GetRoleLangStateGroup(info.RoleId);
			if (StringUtils.IsBlank(roleLangStateGroup))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Role;
				ELogAuthor author = ELogAuthor.WHJ;
				string message = "GetPackageName StateGroup 为空";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("roleId", info.RoleId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return "";
			}
			string audioCode = Singleton<LanguageSystem>.Instance.GetLanguageDefineByType(info.LangIndex).AudioCode;
			return StringUtils.Format("{0}_{1}", new string[]
			{
				roleLangStateGroup,
				audioCode
			});
		}

		// Token: 0x06035695 RID: 218773 RVA: 0x00D65C54 File Offset: 0x00D63E54
		[NullableContext(0)]
		public UniTask<bool> StartDownload([Nullable(1)] IRoleLangCustomLangPackageInfo info)
		{
			RoleLangCustomUpdateManager.<StartDownload>d__10 <StartDownload>d__;
			<StartDownload>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<StartDownload>d__.<>4__this = this;
			<StartDownload>d__.info = info;
			<StartDownload>d__.<>1__state = -1;
			<StartDownload>d__.<>t__builder.Start<RoleLangCustomUpdateManager.<StartDownload>d__10>(ref <StartDownload>d__);
			return <StartDownload>d__.<>t__builder.Task;
		}

		// Token: 0x06035696 RID: 218774 RVA: 0x00D65CA0 File Offset: 0x00D63EA0
		protected void CheckAllDownloadComplete(EResDownloadStatus state)
		{
			if (state == EResDownloadStatus.NoSpace)
			{
				double now = Singleton<Time>.Instance.Now;
				if (now - this.NoSpaceTime < 1000.0)
				{
					return;
				}
				this.NoSpaceTime = now;
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("VoiceDIY_Tips_OutOfMemory", Array.Empty<object>());
				return;
			}
			else
			{
				if (state != EResDownloadStatus.Down)
				{
					return;
				}
				List<string> list = new List<string>();
				foreach (KeyValuePair<string, ResourceDiffUpdater> keyValuePair in this.UpdaterMap)
				{
					if (keyValuePair.Value.UpdateStatus == EResDownloadStatus.Down)
					{
						list.Add(keyValuePair.Key);
					}
				}
				foreach (string key in list)
				{
					this.UpdaterMap.Remove(key);
				}
				using (Dictionary<string, ResourceDiffUpdater>.ValueCollection.Enumerator enumerator3 = this.UpdaterMap.Values.GetEnumerator())
				{
					while (enumerator3.MoveNext())
					{
						if (enumerator3.Current.UpdateStatus == EResDownloadStatus.Downloading)
						{
							return;
						}
					}
				}
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Notice_VoiceDIY_Download_Success", Array.Empty<object>());
				return;
			}
		}

		// Token: 0x06035697 RID: 218775 RVA: 0x00D65DF8 File Offset: 0x00D63FF8
		public bool IsDownloading(IRoleLangCustomLangPackageInfo info)
		{
			string packageName = this.GetPackageName(info);
			if (this.CreatingMap.ContainsKey(packageName))
			{
				return !this.CreatingPauseMap.Contains(packageName);
			}
			ResourceDiffUpdater resourceDiffUpdater;
			return this.UpdaterMap.TryGetValue(packageName, out resourceDiffUpdater) && resourceDiffUpdater.UpdateStatus == EResDownloadStatus.Downloading;
		}

		// Token: 0x06035698 RID: 218776 RVA: 0x00D65E48 File Offset: 0x00D64048
		public unsafe void PauseDownload(IRoleLangCustomLangPackageInfo info)
		{
			string packageName = this.GetPackageName(info);
			if (this.CreatingMap.ContainsKey(packageName))
			{
				this.CreatingPauseMap.Add(packageName);
				return;
			}
			ResourceDiffUpdater resourceDiffUpdater;
			if (!this.UpdaterMap.TryGetValue(packageName, out resourceDiffUpdater))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Role;
				ELogAuthor author = ELogAuthor.WHJ;
				string message = "PauseDownload 未找到 Updater";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("roleId", info.RoleId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("langType", info.LangIndex);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("name", packageName);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
				return;
			}
			resourceDiffUpdater.Stop();
		}

		// Token: 0x06035699 RID: 218777 RVA: 0x00D65F14 File Offset: 0x00D64114
		public List<int> GetDownloadProgress(IRoleLangCustomLangPackageInfo info)
		{
			string packageName = this.GetPackageName(info);
			ResourceDiffUpdater resourceDiffUpdater;
			if (this.UpdaterMap.TryGetValue(packageName, out resourceDiffUpdater) && resourceDiffUpdater.UpdateStatus == EResDownloadStatus.Downloading && resourceDiffUpdater.ViewInfo != null)
			{
				return new List<int>
				{
					(int)resourceDiffUpdater.ViewInfo.SavedSize,
					(int)resourceDiffUpdater.ViewInfo.TotalSize
				};
			}
			ResPackageInfo roleVoiceInfo = ResPackageInfo.GetRoleVoiceInfo(packageName);
			if (roleVoiceInfo == null)
			{
				return new List<int>
				{
					0,
					1
				};
			}
			ValueTuple<long, long> valueTuple = roleVoiceInfo.CalculateSavedSizeAndTotalSize();
			long item = valueTuple.Item1;
			long item2 = valueTuple.Item2;
			return new List<int>
			{
				(int)item,
				(int)item2
			};
		}

		// Token: 0x0603569A RID: 218778 RVA: 0x00D65FBC File Offset: 0x00D641BC
		public long GetDownloadingSavedSizeTotal()
		{
			long num = 0L;
			foreach (ResourceDiffUpdater resourceDiffUpdater in this.UpdaterMap.Values)
			{
				if (resourceDiffUpdater.UpdateStatus == EResDownloadStatus.Downloading)
				{
					ResourceUpdateViewAgent viewInfo = resourceDiffUpdater.ViewInfo;
					if (viewInfo != null)
					{
						num += viewInfo.SavedSize;
					}
				}
			}
			return num;
		}

		// Token: 0x0603569B RID: 218779 RVA: 0x00D66030 File Offset: 0x00D64230
		public ELanguageDownloadStatus GetDownloadStatus(IRoleLangCustomLangPackageInfo info)
		{
			if (!Singleton<ResourceDiffUpdaterManager>.Instance.VoiceModule.IsVoiceDownloadEnable())
			{
				return ELanguageDownloadStatus.Done;
			}
			string packageName = this.GetPackageName(info);
			ResPackageInfo roleVoiceInfo = ResPackageInfo.GetRoleVoiceInfo(packageName);
			if (roleVoiceInfo != null && roleVoiceInfo.IsCompleteDownload())
			{
				return ELanguageDownloadStatus.Done;
			}
			if (this.CreatingMap.ContainsKey(packageName))
			{
				return ELanguageDownloadStatus.Half;
			}
			ResourceDiffUpdater resourceDiffUpdater;
			if (!this.UpdaterMap.TryGetValue(packageName, out resourceDiffUpdater))
			{
				return ELanguageDownloadStatus.None;
			}
			EResDownloadStatus updateStatus = resourceDiffUpdater.UpdateStatus;
			if (updateStatus - EResDownloadStatus.Downloading <= 1)
			{
				return ELanguageDownloadStatus.Half;
			}
			if (updateStatus != EResDownloadStatus.Down)
			{
				return ELanguageDownloadStatus.None;
			}
			return ELanguageDownloadStatus.Done;
		}

		// Token: 0x0603569C RID: 218780 RVA: 0x00D660A8 File Offset: 0x00D642A8
		public void DeletePackage(List<IRoleLangCustomLangPackageInfo> infoList)
		{
			List<string> list = new List<string>();
			foreach (IRoleLangCustomLangPackageInfo info in infoList)
			{
				string packageName = this.GetPackageName(info);
				ResourceDiffUpdater resourceDiffUpdater;
				if (this.UpdaterMap.TryGetValue(packageName, out resourceDiffUpdater))
				{
					if (resourceDiffUpdater.UpdateStatus == EResDownloadStatus.Downloading)
					{
						resourceDiffUpdater.Stop();
					}
					this.UpdaterMap.Remove(packageName);
				}
				list.Add(packageName);
			}
			Singleton<ResourceDiffUpdaterManager>.Instance.VoiceModule.Delete(list);
		}

		// Token: 0x0603569D RID: 218781 RVA: 0x00D66144 File Offset: 0x00D64344
		public bool IsListDownloading()
		{
			if (this.ListCreating != null)
			{
				return !this.ListCreatingPaused;
			}
			ResourceDiffUpdater listUpdater = this.ListUpdater;
			return listUpdater != null && listUpdater.UpdateStatus == EResDownloadStatus.Downloading;
		}

		// Token: 0x0603569E RID: 218782 RVA: 0x00D6616C File Offset: 0x00D6436C
		private List<string> GetListPackageNames(List<IRoleLangCustomLangPackageInfo> infoList)
		{
			List<string> list = new List<string>();
			foreach (IRoleLangCustomLangPackageInfo info in infoList)
			{
				string packageName = this.GetPackageName(info);
				if (!StringUtils.IsBlank(packageName))
				{
					list.Add(packageName);
				}
			}
			return list;
		}

		// Token: 0x0603569F RID: 218783 RVA: 0x00D661D4 File Offset: 0x00D643D4
		[NullableContext(0)]
		public UniTask<bool> StartDownloadList([Nullable(1)] List<IRoleLangCustomLangPackageInfo> infoList)
		{
			RoleLangCustomUpdateManager.<StartDownloadList>d__23 <StartDownloadList>d__;
			<StartDownloadList>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<StartDownloadList>d__.<>4__this = this;
			<StartDownloadList>d__.infoList = infoList;
			<StartDownloadList>d__.<>1__state = -1;
			<StartDownloadList>d__.<>t__builder.Start<RoleLangCustomUpdateManager.<StartDownloadList>d__23>(ref <StartDownloadList>d__);
			return <StartDownloadList>d__.<>t__builder.Task;
		}

		// Token: 0x060356A0 RID: 218784 RVA: 0x00D66220 File Offset: 0x00D64420
		public void PauseDownloadList()
		{
			if (this.ListCreating != null)
			{
				this.ListCreatingPaused = true;
				return;
			}
			if (this.ListUpdater == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.Role, ELogAuthor.WHJ, "PauseDownloadList 未找到 ListUpdater", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			this.ListUpdater.Stop();
		}

		// Token: 0x060356A1 RID: 218785 RVA: 0x00D66270 File Offset: 0x00D64470
		public void DeletePackageList(List<IRoleLangCustomLangPackageInfo> infoList)
		{
			List<string> listPackageNames = this.GetListPackageNames(infoList);
			if (this.ListUpdater != null)
			{
				if (this.ListUpdater.UpdateStatus == EResDownloadStatus.Downloading)
				{
					this.ListUpdater.Stop();
				}
				this.ListUpdater = null;
			}
			this.ListCreatingPaused = false;
			if (listPackageNames.Count == 0)
			{
				return;
			}
			Singleton<ResourceDiffUpdaterManager>.Instance.VoiceModule.Delete(listPackageNames);
		}

		// Token: 0x0401EADA RID: 125658
		private const string PACKAGE_NAME = "{0}_{1}";

		// Token: 0x0401EADB RID: 125659
		private const int COOLDOWNTIME = 1000;

		// Token: 0x0401EADC RID: 125660
		private readonly Dictionary<string, ResourceDiffUpdater> UpdaterMap = new Dictionary<string, ResourceDiffUpdater>();

		// Token: 0x0401EADD RID: 125661
		[Nullable(new byte[]
		{
			1,
			1,
			1,
			2
		})]
		private readonly Dictionary<string, UniTaskCompletionSource<ResourceDiffUpdater>> CreatingMap = new Dictionary<string, UniTaskCompletionSource<ResourceDiffUpdater>>();

		// Token: 0x0401EADE RID: 125662
		private readonly HashSet<string> CreatingPauseMap = new HashSet<string>();

		// Token: 0x0401EADF RID: 125663
		private readonly HashSet<string> RunningSet = new HashSet<string>();

		// Token: 0x0401EAE0 RID: 125664
		protected double NoSpaceTime;

		// Token: 0x0401EAE1 RID: 125665
		[Nullable(2)]
		private ResourceDiffUpdater ListUpdater;

		// Token: 0x0401EAE2 RID: 125666
		[Nullable(2)]
		private UniTaskCompletionSource<ResourceDiffUpdater> ListCreating;

		// Token: 0x0401EAE3 RID: 125667
		private bool ListCreatingPaused;
	}
}
