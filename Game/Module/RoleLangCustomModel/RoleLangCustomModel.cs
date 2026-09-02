using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Common;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.ServerStorage;
using CSharpScript.Game.ServerStorage.Container;
using CSharpScript.Game.Ui;
using CSharpScript.Launcher.Update;
using CSharpScript.Launcher.Update.ResourceDiffUpdate;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.RoleLangCustomModel
{
	// Token: 0x020050F3 RID: 20723
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Model(0)]
	public class RoleLangCustomModel : ModelBase<RoleLangCustomModel>
	{
		// Token: 0x0603566A RID: 218730 RVA: 0x00D645EA File Offset: 0x00D627EA
		protected override bool OnInit()
		{
			this.UpdateManager = new RoleLangCustomUpdateManager();
			this.UpdateManager.Init();
			return true;
		}

		// Token: 0x0603566B RID: 218731 RVA: 0x00D64603 File Offset: 0x00D62803
		protected override bool OnClear()
		{
			this.UpdateManager.Clear();
			return true;
		}

		// Token: 0x0603566C RID: 218732 RVA: 0x00D64611 File Offset: 0x00D62811
		public RoleLangCustomUpdateManager GetUpdateManager()
		{
			return this.UpdateManager;
		}

		// Token: 0x0603566D RID: 218733 RVA: 0x00D6461C File Offset: 0x00D6281C
		public bool CheckPackageAudioDownloading(int audioType)
		{
			string audioCodeById = Singleton<GameSettingsManager>.Instance.GetAudioCodeById(audioType);
			if (StringUtils.IsBlank(audioCodeById))
			{
				return false;
			}
			LanguageUpdater updater = Singleton<LanguageUpdateManager>.Instance.GetUpdater(audioCodeById);
			return updater != null && updater.IsDownloading;
		}

		// Token: 0x0603566E RID: 218734 RVA: 0x00D64658 File Offset: 0x00D62858
		public List<RoleInstance> GetRoleList()
		{
			List<RoleInstance> list = new List<RoleInstance>();
			foreach (RoleInstance roleInstance in ModelBase<RoleModel>.Instance.GetRoleList())
			{
				if (!StringUtils.IsBlank(ConfigBase<RoleConfig>.Instance.GetRoleLangStateGroup(roleInstance.GetRoleId())))
				{
					list.Add(roleInstance);
				}
			}
			return list;
		}

		// Token: 0x0603566F RID: 218735 RVA: 0x00D646A7 File Offset: 0x00D628A7
		public bool GetCanSetCustom()
		{
			return this.CanSetCustom;
		}

		// Token: 0x06035670 RID: 218736 RVA: 0x00D646AF File Offset: 0x00D628AF
		public bool GetStartLoadingInited()
		{
			return this.StartLoadingInited;
		}

		// Token: 0x06035671 RID: 218737 RVA: 0x00D646B7 File Offset: 0x00D628B7
		public bool NeedDeleteButton()
		{
			return Singleton<ResourceDiffUpdaterManager>.Instance.VoiceModule.IsVoiceDownloadEnable() && Singleton<GameSettingsManager>.Instance.IsValid(EFunction.VOICEPACKMANAGER, true);
		}

		// Token: 0x06035672 RID: 218738 RVA: 0x00D646DC File Offset: 0x00D628DC
		public unsafe void CheckAndApplyPlayerVoiceAll()
		{
			bool global = LocalStorage.GetGlobal<bool>(ELocalStorageGlobalKey.RoleLangCustomNeedCover, false);
			string packageAudio = Singleton<LanguageSystem>.Instance.PackageAudio;
			int languageTypeByAudioCode = Singleton<LanguageSystem>.Instance.GetLanguageTypeByAudioCode(packageAudio);
			Dictionary<int, int> dictionary = this.CleanLegacyRoleVoiceMap(LocalStorage.GetPlayer<Dictionary<int, int>>(ELocalStoragePlayerKey.RoleVoiceMap, null) ?? new Dictionary<int, int>());
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Role;
			ELogAuthor author = ELogAuthor.WHJ;
			string message = "PlayerVoice CheckAndApplyPlayerVoiceAll 进入";
			<>y__InlineArray7<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray7<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("coverAll", global);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("CanSetCustom", this.CanSetCustom);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("StartLoadingInited", this.StartLoadingInited);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("NeedCoverAllPlayer", this.NeedCoverAllPlayer);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 4) = new ValueTuple<string, object>("packageAudioCode", packageAudio);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 5) = new ValueTuple<string, object>("packageLangType", languageTypeByAudioCode);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 6) = new ValueTuple<string, object>("roleVoiceMap", JsonSerializer.Serialize<Dictionary<int, int>>(dictionary, null));
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 7));
			LocalStorage.SetGlobal<bool>(ELocalStorageGlobalKey.RoleLangCustomNeedCover, false);
			if (global)
			{
				this.NeedCoverAllPlayer = true;
				Singleton<Log>.Instance.Info(ELogModule.Role, ELogAuthor.WHJ, "PlayerVoice CheckAndApplyPlayerVoiceAll 命中 coverAll，转交 ApplyPlayerVoiceAll", default(ReadOnlySpan<ValueTuple<string, object>>));
				this.ApplyPlayerVoiceAll();
				return;
			}
			this.StartLoadingInited = true;
			int num = languageTypeByAudioCode;
			IReadOnlyList<RoleInfo> readOnlyList = ConfigBase<RoleConfig>.Instance.GetRoleListByType(ERoleType.Common) ?? new List<RoleInfo>();
			Dictionary<int, int> dictionary2 = dictionary;
			List<int> list = new List<int>();
			foreach (RoleInfo roleInfo in readOnlyList)
			{
				int realId = this.GetRealId(roleInfo.Id);
				int langIndex = dictionary2.ContainsKey(realId) ? dictionary2[realId] : num;
				bool flag = this.CheckAudioPackageValid(new RoleLangCustomLangPackageInfo
				{
					RoleId = roleInfo.Id,
					LangIndex = langIndex
				});
				this.ApplyPlayerVoice(roleInfo.Id, !flag);
				if (!flag)
				{
					list.Add(roleInfo.Id);
				}
			}
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Role;
			ELogAuthor author2 = ELogAuthor.WHJ;
			string message2 = "PlayerVoice CheckAndApplyPlayerVoiceAll 完成";
			<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray4<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("allRoleCount", readOnlyList.Count);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("coverRoleCount", list.Count);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("coverRoleList", JsonSerializer.Serialize<List<int>>(list, null));
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 3) = new ValueTuple<string, object>("fallbackLangType", num);
			instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 4));
			if (list.Count > 0)
			{
				this.SystemSettingLogReport(num, ERoleLangLogReportType.NoResource, list.Count == readOnlyList.Count);
			}
		}

		// Token: 0x06035673 RID: 218739 RVA: 0x00D649FC File Offset: 0x00D62BFC
		private Dictionary<int, int> CleanLegacyRoleVoiceMap(Dictionary<int, int> roleMap)
		{
			bool flag = false;
			Dictionary<int, int> dictionary = new Dictionary<int, int>();
			foreach (KeyValuePair<int, int> keyValuePair in roleMap)
			{
				int num;
				int num2;
				keyValuePair.Deconstruct(out num, out num2);
				int key = num;
				int num3 = num2;
				try
				{
					Singleton<LanguageSystem>.Instance.GetLanguageDefineByType(num3);
				}
				catch
				{
					flag = true;
					continue;
				}
				dictionary[key] = num3;
			}
			if (flag)
			{
				Singleton<Log>.Instance.Info(ELogModule.Role, ELogAuthor.WHJ, "PlayerVoice 清理旧格式 RoleVoiceMap", default(ReadOnlySpan<ValueTuple<string, object>>));
				LocalStorage.SetPlayer<Dictionary<int, int>>(ELocalStoragePlayerKey.RoleVoiceMap, dictionary);
			}
			return dictionary;
		}

		// Token: 0x06035674 RID: 218740 RVA: 0x00D64AB4 File Offset: 0x00D62CB4
		public bool CheckAudioPackageValid(IRoleLangCustomLangPackageInfo info)
		{
			return !UKuroLauncherLibrary.NeedHotPatch() || !Singleton<ResourceDiffUpdaterManager>.Instance.VoiceModule.IsVoiceDownloadEnable() || this.UpdateManager.GetDownloadStatus(info) == ELanguageDownloadStatus.Done;
		}

		// Token: 0x06035675 RID: 218741 RVA: 0x00D64AE0 File Offset: 0x00D62CE0
		public unsafe void ApplyPlayerVoiceAll()
		{
			string packageAudio = Singleton<LanguageSystem>.Instance.PackageAudio;
			int languageTypeByAudioCode = Singleton<LanguageSystem>.Instance.GetLanguageTypeByAudioCode(packageAudio);
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Role;
			ELogAuthor author = ELogAuthor.WHJ;
			string message = "PlayerVoice ApplyPlayerVoiceAll 进入";
			<>y__InlineArray5<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray5<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("CanSetCustom", this.CanSetCustom);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("StartLoadingInited", this.StartLoadingInited);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("NeedCoverAllPlayer", this.NeedCoverAllPlayer);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("packageAudioCode", packageAudio);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 4) = new ValueTuple<string, object>("packageLangType", languageTypeByAudioCode);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 5));
			if (!this.GetCanSetCustom())
			{
				Singleton<Log>.Instance.Info(ELogModule.Role, ELogAuthor.WHJ, "PlayerVoice ApplyPlayerVoiceAll 提前退出：CanSetCustom 为 false", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			bool needCoverAllPlayer = this.NeedCoverAllPlayer;
			this.NeedCoverAllPlayer = false;
			IReadOnlyList<RoleInfo> readOnlyList = ConfigBase<RoleConfig>.Instance.GetRoleListByType(ERoleType.Common) ?? new List<RoleInfo>();
			if (needCoverAllPlayer)
			{
				this.ClearAllMark();
			}
			foreach (RoleInfo roleInfo in readOnlyList)
			{
				this.ApplyPlayerVoice(roleInfo.Id, needCoverAllPlayer);
			}
			if (this.StartLoadingInited)
			{
				Dictionary<int, int> dictionary = LocalStorage.GetPlayer<Dictionary<int, int>>(ELocalStoragePlayerKey.RoleVoiceMap, null) ?? new Dictionary<int, int>();
				List<RoleVoiceSetting> list = new List<RoleVoiceSetting>();
				HashSet<int> hashSet = new HashSet<int>();
				foreach (RoleInfo roleInfo2 in readOnlyList)
				{
					int id = roleInfo2.Id;
					int realId = this.GetRealId(id);
					if (!dictionary.ContainsKey(realId) && !hashSet.Contains(realId) && (ModelBase<RoleModel>.Instance.IsMainRole(id) || ModelBase<RoleModel>.Instance.GetRoleDataById(id, true) != null))
					{
						RoleVoiceSetting roleVoiceSetting = RoleVoiceSetting.Create();
						roleVoiceSetting.RoleId = realId;
						int languageTypeByAudioCode2 = Singleton<LanguageSystem>.Instance.GetLanguageTypeByAudioCode(Singleton<LanguageSystem>.Instance.PackageAudio);
						roleVoiceSetting.VoiceLanguage = languageTypeByAudioCode2;
						list.Add(roleVoiceSetting);
						hashSet.Add(realId);
					}
				}
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.Role;
				ELogAuthor author2 = ELogAuthor.WHJ;
				string message2 = "PlayerVoice ApplyPlayerVoiceAll 上报服务器";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("needCoverAll", needCoverAllPlayer);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("allRoleCount", readOnlyList.Count);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("uploadCount", list.Count);
				instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 3));
				ControllerBase<RoleController>.Instance.RequestPlayerRoleVoiceSet(list);
			}
			else
			{
				Log instance3 = Singleton<Log>.Instance;
				ELogModule module3 = ELogModule.Role;
				ELogAuthor author3 = ELogAuthor.WHJ;
				string message3 = "PlayerVoice ApplyPlayerVoiceAll 跳过上报：StartLoadingInited 为 false";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray3 = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 0) = new ValueTuple<string, object>("needCoverAll", needCoverAllPlayer);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 1) = new ValueTuple<string, object>("allRoleCount", readOnlyList.Count);
				instance3.Info(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray3, 2));
			}
			this.StartLoadingInited = true;
			int num = languageTypeByAudioCode;
			Log instance4 = Singleton<Log>.Instance;
			ELogModule module4 = ELogModule.Role;
			ELogAuthor author4 = ELogAuthor.WHJ;
			string message4 = "PlayerVoice ApplyPlayerVoiceAll 完成";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray4 = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 0) = new ValueTuple<string, object>("langType", num);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 1) = new ValueTuple<string, object>("needCoverAll", needCoverAllPlayer);
			instance4.Info(module4, author4, message4, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray4, 2));
			this.SystemSettingLogReport(num, ERoleLangLogReportType.Player, needCoverAllPlayer);
		}

		// Token: 0x06035676 RID: 218742 RVA: 0x00D64EB8 File Offset: 0x00D630B8
		public void GetServerVoiceData(List<RoleVoice> serverData)
		{
			this.ServerVoiceData.Clear();
			foreach (RoleVoice roleVoice in serverData)
			{
				this.ServerVoiceData[roleVoice.RoleId] = roleVoice.VoiceId;
			}
			this.HasCheckServer = true;
		}

		// Token: 0x06035677 RID: 218743 RVA: 0x00D64F28 File Offset: 0x00D63128
		public bool CheckServerVoiceDataSame(bool fromSettingAll = false)
		{
			if (this.HasConfirm || (this.HasCheckServer && this.ServerVoiceData.Count == 0))
			{
				return true;
			}
			bool flag = false;
			HashSet<int> hashSet = LocalStorage.GetPlayer<HashSet<int>>(ELocalStoragePlayerKey.RoleLangCustomRecord, null) ?? new HashSet<int>();
			ServerStorageSet serverStorageSet = ModelBase<ServerStorageModel>.Instance.Get(EClientStorageSystemIdType.RoleLangCustomRecord) as ServerStorageSet;
			if (hashSet.Count != serverStorageSet.Size())
			{
				flag = true;
			}
			else
			{
				foreach (int value in hashSet)
				{
					if (!serverStorageSet.Has(value))
					{
						flag = true;
						break;
					}
				}
			}
			Dictionary<int, int> dictionary = LocalStorage.GetPlayer<Dictionary<int, int>>(ELocalStoragePlayerKey.RoleVoiceMap, null) ?? new Dictionary<int, int>();
			if (!flag)
			{
				foreach (int key in serverStorageSet.GetContainer())
				{
					if (!this.ServerVoiceData.ContainsKey(key))
					{
						flag = true;
						break;
					}
					if (!dictionary.ContainsKey(key))
					{
						flag = true;
						break;
					}
					int num = this.ServerVoiceData[key];
					if (dictionary[key] != num)
					{
						flag = true;
						break;
					}
				}
			}
			if (!flag)
			{
				this.HasConfirm = true;
				return true;
			}
			if (Singleton<CloudGameManager>.Instance.IsCloudGame)
			{
				this.OnClickedConfirmConfirm();
				return true;
			}
			this.ConfirmViewMask.SetMask("RoleLangNetConfirmPop", true);
			Singleton<UiManager>.Instance.OpenView(EUiViewName.RoleLangNetConfirmPop, fromSettingAll, delegate(bool _, int viewId)
			{
				if (!fromSettingAll && Singleton<UiManager>.Instance.GetViewByName(EUiViewName.RoleRootView) != null)
				{
					Singleton<UiManager>.Instance.GetViewByName(EUiViewName.RoleRootView).AddChildViewById(viewId);
				}
				else if (fromSettingAll && Singleton<UiManager>.Instance.GetViewByName(EUiViewName.RoleLangCustomView) != null)
				{
					Singleton<UiManager>.Instance.GetViewByName(EUiViewName.RoleLangCustomView).AddChildViewById(viewId);
				}
				this.ConfirmViewMask.SetMask("RoleLangNetConfirmPop", false);
			});
			return false;
		}

		// Token: 0x06035678 RID: 218744 RVA: 0x00D650E0 File Offset: 0x00D632E0
		public List<IRoleLangCustomLangPackageInfo> CheckNoResourceInfo()
		{
			List<IRoleLangCustomLangPackageInfo> list = new List<IRoleLangCustomLangPackageInfo>();
			HashSet<int> hashSet = new HashSet<int>();
			Dictionary<int, int> dictionary = LocalStorage.GetPlayer<Dictionary<int, int>>(ELocalStoragePlayerKey.RoleVoiceMap, null) ?? new Dictionary<int, int>();
			foreach (int num in (ModelBase<ServerStorageModel>.Instance.Get(EClientStorageSystemIdType.RoleLangCustomRecord) as ServerStorageSet).GetContainer())
			{
				if (!hashSet.Contains(num) && this.ServerVoiceData.ContainsKey(num))
				{
					int num2 = this.ServerVoiceData[num];
					if (!dictionary.ContainsKey(num) || dictionary[num] != num2)
					{
						int roleIdByRealId = this.GetRoleIdByRealId(num);
						RoleLangCustomLangPackageInfo roleLangCustomLangPackageInfo = new RoleLangCustomLangPackageInfo
						{
							RoleId = roleIdByRealId,
							LangIndex = num2
						};
						if (!this.CheckAudioPackageValid(roleLangCustomLangPackageInfo))
						{
							list.Add(roleLangCustomLangPackageInfo);
							hashSet.Add(num);
						}
					}
				}
			}
			return list;
		}

		// Token: 0x06035679 RID: 218745 RVA: 0x00D651E0 File Offset: 0x00D633E0
		protected int GetRealId(int roleId)
		{
			int result = roleId;
			if (ModelBase<RoleModel>.Instance.IsMainRole(roleId))
			{
				result = ConfigBase<RoleConfig>.Instance.GetMainRoleById(roleId).Value.Gender;
			}
			return result;
		}

		// Token: 0x0603567A RID: 218746 RVA: 0x00D6521C File Offset: 0x00D6341C
		protected int GetRoleIdByRealId(int realRoleId)
		{
			if (realRoleId != 0 && realRoleId != 1)
			{
				return realRoleId;
			}
			return ConfigBase<RoleConfig>.Instance.GetMainRoleByGender((LoginDefine.ELoginSex)realRoleId)[0].Id;
		}

		// Token: 0x0603567B RID: 218747 RVA: 0x00D65250 File Offset: 0x00D63450
		public void OnClickedConfirmClose()
		{
			this.HasConfirm = true;
			Dictionary<int, int> dictionary = LocalStorage.GetPlayer<Dictionary<int, int>>(ELocalStoragePlayerKey.RoleVoiceMap, null) ?? new Dictionary<int, int>();
			List<RoleVoiceSetting> list = new List<RoleVoiceSetting>();
			HashSet<int> hashSet = new HashSet<int>();
			foreach (KeyValuePair<int, int> keyValuePair in dictionary)
			{
				int num;
				int num2;
				keyValuePair.Deconstruct(out num, out num2);
				int roleId = num;
				int voiceLanguage = num2;
				RoleVoiceSetting roleVoiceSetting = RoleVoiceSetting.Create();
				roleVoiceSetting.RoleId = roleId;
				roleVoiceSetting.VoiceLanguage = voiceLanguage;
				list.Add(roleVoiceSetting);
			}
			foreach (RoleInfo roleInfo in (ConfigBase<RoleConfig>.Instance.GetRoleListByType(ERoleType.Common) ?? new List<RoleInfo>()))
			{
				int id = roleInfo.Id;
				int realId = this.GetRealId(id);
				if (!dictionary.ContainsKey(realId) && !hashSet.Contains(realId) && (ModelBase<RoleModel>.Instance.IsMainRole(id) || ModelBase<RoleModel>.Instance.GetRoleInstanceById(id) != null))
				{
					RoleVoiceSetting roleVoiceSetting2 = RoleVoiceSetting.Create();
					roleVoiceSetting2.RoleId = realId;
					int languageTypeByAudioCode = Singleton<LanguageSystem>.Instance.GetLanguageTypeByAudioCode(Singleton<LanguageSystem>.Instance.PackageAudio);
					roleVoiceSetting2.VoiceLanguage = languageTypeByAudioCode;
					list.Add(roleVoiceSetting2);
					hashSet.Add(realId);
				}
			}
			ControllerBase<RoleController>.Instance.RequestPlayerRoleVoiceSet(list).ContinueWith(delegate(bool value)
			{
				if (!value)
				{
					return;
				}
				HashSet<int> values = LocalStorage.GetPlayer<HashSet<int>>(ELocalStoragePlayerKey.RoleLangCustomRecord, null) ?? new HashSet<int>();
				(ModelBase<ServerStorageModel>.Instance.Get(EClientStorageSystemIdType.RoleLangCustomRecord) as ServerStorageSet).Overwrite(values);
			}).Forget();
		}

		// Token: 0x0603567C RID: 218748 RVA: 0x00D653FC File Offset: 0x00D635FC
		public void OnClickedConfirmConfirm()
		{
			this.HasConfirm = true;
			HashSet<int> hashSet = new HashSet<int>((ModelBase<ServerStorageModel>.Instance.Get(EClientStorageSystemIdType.RoleLangCustomRecord) as ServerStorageSet).GetContainer());
			LocalStorage.SetPlayer<HashSet<int>>(ELocalStoragePlayerKey.RoleLangCustomRecord, hashSet);
			foreach (int num in hashSet)
			{
				int lang = this.ServerVoiceData[num];
				int roleIdByRealId = this.GetRoleIdByRealId(num);
				RoleLangSetVoiceParam playerVoice = new RoleLangSetVoiceParam
				{
					RoleId = roleIdByRealId,
					Lang = lang,
					NeedRequest = false,
					IsCustom = true,
					IsCover = false
				};
				this.SetPlayerVoice(playerVoice);
			}
			int languageTypeByAudioCode = Singleton<LanguageSystem>.Instance.GetLanguageTypeByAudioCode(Singleton<LanguageSystem>.Instance.PackageAudio);
			foreach (RoleInfo roleInfo in (ConfigBase<RoleConfig>.Instance.GetRoleListByType(ERoleType.Common) ?? new List<RoleInfo>()))
			{
				int id = roleInfo.Id;
				if (!hashSet.Contains(this.GetRealId(id)))
				{
					RoleLangSetVoiceParam playerVoice2 = new RoleLangSetVoiceParam
					{
						RoleId = id,
						Lang = languageTypeByAudioCode,
						NeedRequest = false,
						IsCustom = false,
						IsCover = true
					};
					this.SetPlayerVoice(playerVoice2);
				}
			}
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RoleLangCustomRefresh, -1);
		}

		// Token: 0x0603567D RID: 218749 RVA: 0x00D65578 File Offset: 0x00D63778
		public UniTask RequestServerVoiceData()
		{
			RoleLangCustomModel.<RequestServerVoiceData>d__29 <RequestServerVoiceData>d__;
			<RequestServerVoiceData>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RequestServerVoiceData>d__.<>4__this = this;
			<RequestServerVoiceData>d__.<>1__state = -1;
			<RequestServerVoiceData>d__.<>t__builder.Start<RoleLangCustomModel.<RequestServerVoiceData>d__29>(ref <RequestServerVoiceData>d__);
			return <RequestServerVoiceData>d__.<>t__builder.Task;
		}

		// Token: 0x0603567E RID: 218750 RVA: 0x00D655BC File Offset: 0x00D637BC
		public void ApplyPlayerVoice(int roleId, bool cover = false)
		{
			if (StringUtils.IsBlank(ConfigBase<RoleConfig>.Instance.GetRoleLangStateGroup(roleId)))
			{
				return;
			}
			if (cover)
			{
				RoleLangSetVoiceParam playerVoice = new RoleLangSetVoiceParam
				{
					RoleId = roleId,
					Lang = Singleton<LanguageSystem>.Instance.GetLanguageTypeByAudioCode(Singleton<LanguageSystem>.Instance.PackageAudio),
					NeedRequest = false,
					IsCustom = false,
					IsCover = true
				};
				this.SetPlayerVoice(playerVoice);
				return;
			}
			int realId = this.GetRealId(roleId);
			Dictionary<int, int> player = LocalStorage.GetPlayer<Dictionary<int, int>>(ELocalStoragePlayerKey.RoleVoiceMap, null);
			int lang;
			if (player == null || !player.ContainsKey(realId))
			{
				lang = Singleton<LanguageSystem>.Instance.GetLanguageTypeByAudioCode(Singleton<LanguageSystem>.Instance.PackageAudio);
			}
			else
			{
				lang = player[realId];
			}
			RoleLangSetVoiceParam playerVoice2 = new RoleLangSetVoiceParam
			{
				RoleId = roleId,
				Lang = lang,
				NeedRequest = false,
				IsCustom = false,
				IsCover = cover
			};
			this.SetPlayerVoice(playerVoice2);
		}

		// Token: 0x0603567F RID: 218751 RVA: 0x00D65694 File Offset: 0x00D63894
		public unsafe void SetPlayerVoice(IRoleLangSetVoiceParam param)
		{
			int roleId = param.RoleId;
			bool needRequest = param.NeedRequest;
			bool isCustom = param.IsCustom;
			bool isCover = param.IsCover;
			string roleLangStateGroup = ConfigBase<RoleConfig>.Instance.GetRoleLangStateGroup(roleId);
			Dictionary<int, int> dictionary = LocalStorage.GetPlayer<Dictionary<int, int>>(ELocalStoragePlayerKey.RoleVoiceMap, null) ?? new Dictionary<int, int>();
			if (StringUtils.IsBlank(roleLangStateGroup))
			{
				return;
			}
			if (isCustom)
			{
				this.MarkRoleNeedCustom(roleId);
			}
			else if (isCover)
			{
				this.RemoveRoleMark(roleId);
			}
			int lang = param.Lang;
			int realId = this.GetRealId(roleId);
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Role;
			ELogAuthor author = ELogAuthor.WHJ;
			string message = "PlayerVoice 切换语音";
			<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("roleId", roleId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("languageCode", lang);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("isCustom", isCustom);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("isCover", isCover);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
			if (isCustom)
			{
				dictionary[realId] = lang;
			}
			else if (isCover)
			{
				dictionary.Remove(realId);
			}
			global::LanguageDefine languageDefineByType = Singleton<LanguageSystem>.Instance.GetLanguageDefineByType(lang);
			Singleton<AudioSystem>.Instance.SetState(roleLangStateGroup, languageDefineByType.AudioCode, false);
			if (isCustom || isCover)
			{
				LocalStorage.SetPlayer<Dictionary<int, int>>(ELocalStoragePlayerKey.RoleVoiceMap, dictionary);
			}
			RoleVoiceSetting roleVoiceSetting = RoleVoiceSetting.Create();
			roleVoiceSetting.RoleId = realId;
			roleVoiceSetting.VoiceLanguage = this.GetRoleLangType(roleId);
			if (needRequest)
			{
				ControllerBase<RoleController>.Instance.RequestPlayerRoleVoiceSet(new List<RoleVoiceSetting>
				{
					roleVoiceSetting
				});
			}
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RoleLangCustomRefresh, roleId);
		}

		// Token: 0x06035680 RID: 218752 RVA: 0x00D65844 File Offset: 0x00D63A44
		public void MarkRoleNeedCustom(int roleId)
		{
			HashSet<int> hashSet = LocalStorage.GetPlayer<HashSet<int>>(ELocalStoragePlayerKey.RoleLangCustomRecord, null) ?? new HashSet<int>();
			ServerStorageSet serverStorageSet = ModelBase<ServerStorageModel>.Instance.Get(EClientStorageSystemIdType.RoleLangCustomRecord) as ServerStorageSet;
			int realId = this.GetRealId(roleId);
			hashSet.Add(realId);
			LocalStorage.SetPlayer<HashSet<int>>(ELocalStoragePlayerKey.RoleLangCustomRecord, hashSet);
			serverStorageSet.Add(realId);
		}

		// Token: 0x06035681 RID: 218753 RVA: 0x00D6589C File Offset: 0x00D63A9C
		public void RemoveRoleMark(int roleId)
		{
			HashSet<int> hashSet = LocalStorage.GetPlayer<HashSet<int>>(ELocalStoragePlayerKey.RoleLangCustomRecord, null) ?? new HashSet<int>();
			int realId = this.GetRealId(roleId);
			hashSet.Remove(realId);
			LocalStorage.SetPlayer<HashSet<int>>(ELocalStoragePlayerKey.RoleLangCustomRecord, hashSet);
			if (this.HasConfirm)
			{
				(ModelBase<ServerStorageModel>.Instance.Get(EClientStorageSystemIdType.RoleLangCustomRecord) as ServerStorageSet).Remove(realId);
			}
		}

		// Token: 0x06035682 RID: 218754 RVA: 0x00D658F9 File Offset: 0x00D63AF9
		public bool CheckIsMark(int roleId)
		{
			return (LocalStorage.GetPlayer<HashSet<int>>(ELocalStoragePlayerKey.RoleLangCustomRecord, null) ?? new HashSet<int>()).Contains(this.GetRealId(roleId));
		}

		// Token: 0x06035683 RID: 218755 RVA: 0x00D6591B File Offset: 0x00D63B1B
		public void ClearAllMark()
		{
			LocalStorage.SetPlayer<HashSet<int>>(ELocalStoragePlayerKey.RoleLangCustomRecord, new HashSet<int>());
			(ModelBase<ServerStorageModel>.Instance.Get(EClientStorageSystemIdType.RoleLangCustomRecord) as ServerStorageSet).Overwrite(new HashSet<int>());
		}

		// Token: 0x06035684 RID: 218756 RVA: 0x00D65948 File Offset: 0x00D63B48
		public int GetRoleLangType(int roleId)
		{
			if (StringUtils.IsBlank(ConfigBase<RoleConfig>.Instance.GetRoleLangStateGroup(roleId)))
			{
				return Singleton<LanguageSystem>.Instance.GetLanguageTypeByAudioCode(Singleton<LanguageSystem>.Instance.PackageAudio);
			}
			Dictionary<int, int> dictionary = LocalStorage.GetPlayer<Dictionary<int, int>>(ELocalStoragePlayerKey.RoleVoiceMap, null) ?? new Dictionary<int, int>();
			int realId = this.GetRealId(roleId);
			int num = dictionary.ContainsKey(realId) ? dictionary[realId] : -1;
			if (num == -1)
			{
				return Singleton<LanguageSystem>.Instance.GetLanguageTypeByAudioCode(Singleton<LanguageSystem>.Instance.PackageAudio);
			}
			return num;
		}

		// Token: 0x06035685 RID: 218757 RVA: 0x00D659C8 File Offset: 0x00D63BC8
		public UniTask UploadAllPlayerVoiceLanguage()
		{
			RoleLangCustomModel.<UploadAllPlayerVoiceLanguage>d__37 <UploadAllPlayerVoiceLanguage>d__;
			<UploadAllPlayerVoiceLanguage>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<UploadAllPlayerVoiceLanguage>d__.<>1__state = -1;
			<UploadAllPlayerVoiceLanguage>d__.<>t__builder.Start<RoleLangCustomModel.<UploadAllPlayerVoiceLanguage>d__37>(ref <UploadAllPlayerVoiceLanguage>d__);
			return <UploadAllPlayerVoiceLanguage>d__.<>t__builder.Task;
		}

		// Token: 0x06035686 RID: 218758 RVA: 0x00D65A03 File Offset: 0x00D63C03
		public ELanguageDownloadStatus GetDownloadStatus(IRoleLangCustomLangPackageInfo info)
		{
			if (!UKuroLauncherLibrary.NeedHotPatch() || !Singleton<ResourceDiffUpdaterManager>.Instance.VoiceModule.IsVoiceDownloadEnable())
			{
				return ELanguageDownloadStatus.Done;
			}
			return this.UpdateManager.GetDownloadStatus(info);
		}

		// Token: 0x06035687 RID: 218759 RVA: 0x00D65A2B File Offset: 0x00D63C2B
		public List<int> GetDownloadProgress(int roleId, int langType)
		{
			return this.UpdateManager.GetDownloadProgress(new RoleLangCustomLangPackageInfo
			{
				RoleId = roleId,
				LangIndex = langType
			});
		}

		// Token: 0x06035688 RID: 218760 RVA: 0x00D65A4B File Offset: 0x00D63C4B
		public void StartDownloading(IRoleLangCustomLangPackageInfo info)
		{
			this.UpdateManager.StartDownload(info);
		}

		// Token: 0x06035689 RID: 218761 RVA: 0x00D65A5A File Offset: 0x00D63C5A
		public void PauseDownloading(IRoleLangCustomLangPackageInfo info)
		{
			this.UpdateManager.PauseDownload(info);
		}

		// Token: 0x0603568A RID: 218762 RVA: 0x00D65A68 File Offset: 0x00D63C68
		public void StartDownloadingList(List<IRoleLangCustomLangPackageInfo> infoList)
		{
			this.UpdateManager.StartDownloadList(infoList);
		}

		// Token: 0x0603568B RID: 218763 RVA: 0x00D65A77 File Offset: 0x00D63C77
		public void PauseDownloadingList()
		{
			this.UpdateManager.PauseDownloadList();
		}

		// Token: 0x0603568C RID: 218764 RVA: 0x00D65A84 File Offset: 0x00D63C84
		public bool IsListDownloading()
		{
			return this.UpdateManager.IsListDownloading();
		}

		// Token: 0x0603568D RID: 218765 RVA: 0x00D65A91 File Offset: 0x00D63C91
		public void DeletePackageList(List<IRoleLangCustomLangPackageInfo> infoList)
		{
			this.UpdateManager.DeletePackageList(infoList);
		}

		// Token: 0x0603568E RID: 218766 RVA: 0x00D65AA0 File Offset: 0x00D63CA0
		public bool CheckSpaceEnough(IRoleLangCustomLangPackageInfo info)
		{
			string packageName = this.UpdateManager.GetPackageName(info);
			string checkPath = UKuroLauncherLibrary.GameSavedDir();
			long num = 0L;
			UKuroLauncherLibrary.GetTotalAndFreeSpace(checkPath, ref num);
			long num2 = num;
			long num3 = 0L;
			ResPackageInfo roleVoiceInfo = ResPackageInfo.GetRoleVoiceInfo(packageName);
			if (roleVoiceInfo != null)
			{
				ValueTuple<long, long> valueTuple = roleVoiceInfo.CalculateSavedSizeAndTotalSize();
				long item = valueTuple.Item1;
				num3 = valueTuple.Item2 - item;
			}
			return num2 >= num3 + 10485760L;
		}

		// Token: 0x0603568F RID: 218767 RVA: 0x00D65AFC File Offset: 0x00D63CFC
		public int PlayVoiceOnSetVoice(int roleId)
		{
			RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(roleId, true);
			RoleSkinAudio? roleConfig = ConfigBase<AudioConfig>.Instance.GetRoleConfig(roleDataById.GetRoleSkinId());
			return Singleton<AudioSystem>.Instance.PostEvent(roleConfig.Value.JoinTeamEvent);
		}

		// Token: 0x06035690 RID: 218768 RVA: 0x00D65B40 File Offset: 0x00D63D40
		public void SystemSettingLogReport(int lang, ERoleLangLogReportType type, bool isAll)
		{
			RoleLangCustomSettingEvent roleLangCustomSettingEvent = new RoleLangCustomSettingEvent();
			roleLangCustomSettingEvent.i_language = lang;
			roleLangCustomSettingEvent.i_way = (int)type;
			roleLangCustomSettingEvent.i_cover = (isAll ? 1 : 2);
			ControllerBase<LogReportController>.Instance.LogReport(roleLangCustomSettingEvent);
		}

		// Token: 0x0401EAD0 RID: 125648
		public int RoleViewRoleId;

		// Token: 0x0401EAD1 RID: 125649
		public bool CanSetCustom;

		// Token: 0x0401EAD2 RID: 125650
		public bool NeedCoverAllPlayer;

		// Token: 0x0401EAD3 RID: 125651
		private bool StartLoadingInited;

		// Token: 0x0401EAD4 RID: 125652
		private readonly Dictionary<int, int> ServerVoiceData = new Dictionary<int, int>();

		// Token: 0x0401EAD5 RID: 125653
		private bool HasCheckServer;

		// Token: 0x0401EAD6 RID: 125654
		private bool HasConfirm;

		// Token: 0x0401EAD7 RID: 125655
		private RoleLangCustomUpdateManager UpdateManager;

		// Token: 0x0401EAD8 RID: 125656
		private readonly UiMask ConfirmViewMask = new UiMask();

		// Token: 0x0401EAD9 RID: 125657
		private const string ConfirmMaskTag = "RoleLangNetConfirmPop";
	}
}
