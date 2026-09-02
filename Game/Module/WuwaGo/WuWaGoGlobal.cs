using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Component;
using AkiClient.Game.Aki.Data.Gameplay.WuWaGo;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.WuwaGo
{
	// Token: 0x02004AB6 RID: 19126
	[NullableContext(2)]
	[Nullable(0)]
	public class WuWaGoGlobal : IStaticVariableResetter
	{
		// Token: 0x06031DB3 RID: 204211 RVA: 0x00C79E02 File Offset: 0x00C78002
		static WuWaGoGlobal()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(WuWaGoGlobal.CreateStaticDefaultValue), new Action(WuWaGoGlobal.ResetStaticDefaultValue));
		}

		// Token: 0x06031DB4 RID: 204212 RVA: 0x00C79E21 File Offset: 0x00C78021
		public static void CreateStaticDefaultValue()
		{
			WuWaGoGlobal._roleAttackAnimMap = new Dictionary<EWuWaGoRoleType, List<UAnimMontage>>();
			WuWaGoGlobal._roleDeathAnimMap = new Dictionary<EWuWaGoRoleType, List<UAnimMontage>>();
			WuWaGoGlobal._roleBeHitAnimMap = new Dictionary<EWuWaGoRoleType, List<UAnimMontage>>();
			WuWaGoGlobal._roleClimbAnimMap = new Dictionary<EWuWaGoRoleType, Dictionary<EWuWaGoClimbMontage, UAnimMontage>>();
			WuWaGoGlobal._preloadedAudioEvents = new HashSet<string>();
		}

		// Token: 0x06031DB5 RID: 204213 RVA: 0x00C79E58 File Offset: 0x00C78058
		public static void ResetStaticDefaultValue()
		{
			WuWaGoGlobal.ReleaseAudioEvents();
			WuWaGoGlobal._settingDataAsset = null;
			WuWaGoGlobal._roleAttackAnimMap = null;
			WuWaGoGlobal._roleDeathAnimMap = null;
			WuWaGoGlobal._roleBeHitAnimMap = null;
			WuWaGoGlobal._roleClimbAnimMap = null;
			WuWaGoGlobal._mainControlPullRodOpenMontage = null;
			WuWaGoGlobal._mainControlPullRodCloseMontage = null;
			WuWaGoGlobal._spikeFallMontage = null;
			WuWaGoGlobal._alertMontage = null;
			WuWaGoGlobal._idleMontage = null;
			WuWaGoGlobal._preloadedAudioEvents = null;
		}

		// Token: 0x17008514 RID: 34068
		// (get) Token: 0x06031DB6 RID: 204214 RVA: 0x00C79EAC File Offset: 0x00C780AC
		public static BP_WuWaGo_C Setting
		{
			get
			{
				if (WuWaGoGlobal._settingDataAsset == null)
				{
					Singleton<Log>.Instance.Error(ELogModule.WuWaGo, ELogAuthor.YSQ, "SettingDataAsset is null", default(ReadOnlySpan<ValueTuple<string, object>>));
					return null;
				}
				return WuWaGoGlobal._settingDataAsset;
			}
		}

		// Token: 0x06031DB7 RID: 204215 RVA: 0x00C79EE8 File Offset: 0x00C780E8
		[return: Nullable(new byte[]
		{
			0,
			2
		})]
		public static UniTask<BP_WuWaGo_C> LoadSettingData()
		{
			WuWaGoGlobal.<LoadSettingData>d__17 <LoadSettingData>d__;
			<LoadSettingData>d__.<>t__builder = AsyncUniTaskMethodBuilder<BP_WuWaGo_C>.Create();
			<LoadSettingData>d__.<>1__state = -1;
			<LoadSettingData>d__.<>t__builder.Start<WuWaGoGlobal.<LoadSettingData>d__17>(ref <LoadSettingData>d__);
			return <LoadSettingData>d__.<>t__builder.Task;
		}

		// Token: 0x06031DB8 RID: 204216 RVA: 0x00C79F24 File Offset: 0x00C78124
		public static void ClearSettingData()
		{
			WuWaGoGlobal.ReleaseAudioEvents();
			WuWaGoGlobal._settingDataAsset = null;
			Dictionary<EWuWaGoRoleType, List<UAnimMontage>> roleAttackAnimMap = WuWaGoGlobal._roleAttackAnimMap;
			if (roleAttackAnimMap != null)
			{
				roleAttackAnimMap.Clear();
			}
			Dictionary<EWuWaGoRoleType, List<UAnimMontage>> roleDeathAnimMap = WuWaGoGlobal._roleDeathAnimMap;
			if (roleDeathAnimMap != null)
			{
				roleDeathAnimMap.Clear();
			}
			Dictionary<EWuWaGoRoleType, List<UAnimMontage>> roleBeHitAnimMap = WuWaGoGlobal._roleBeHitAnimMap;
			if (roleBeHitAnimMap != null)
			{
				roleBeHitAnimMap.Clear();
			}
			Dictionary<EWuWaGoRoleType, Dictionary<EWuWaGoClimbMontage, UAnimMontage>> roleClimbAnimMap = WuWaGoGlobal._roleClimbAnimMap;
			if (roleClimbAnimMap != null)
			{
				roleClimbAnimMap.Clear();
			}
			WuWaGoGlobal._mainControlPullRodOpenMontage = null;
			WuWaGoGlobal._mainControlPullRodCloseMontage = null;
			WuWaGoGlobal._spikeFallMontage = null;
			WuWaGoGlobal._alertMontage = null;
			WuWaGoGlobal._idleMontage = null;
		}

		// Token: 0x06031DB9 RID: 204217 RVA: 0x00C79F9C File Offset: 0x00C7819C
		public static string GetRoleClassPath(EWuWaGoRoleType type)
		{
			string result = null;
			switch (type)
			{
			case EWuWaGoRoleType.AircraftSoldiers:
			{
				BP_WuWaGo_C setting = WuWaGoGlobal.Setting;
				result = ((setting != null) ? setting.MainControlClass.ToAssetPathName() : null);
				break;
			}
			case EWuWaGoRoleType.HeatFusionEnemy:
			{
				BP_WuWaGo_C setting2 = WuWaGoGlobal.Setting;
				result = ((setting2 != null) ? setting2.StaticMonsterClass.ToAssetPathName() : null);
				break;
			}
			case EWuWaGoRoleType.DiffractionEnemy:
			{
				BP_WuWaGo_C setting3 = WuWaGoGlobal.Setting;
				result = ((setting3 != null) ? setting3.MoveMonsterClass.ToAssetPathName() : null);
				break;
			}
			}
			return result;
		}

		// Token: 0x06031DBA RID: 204218 RVA: 0x00C7A00C File Offset: 0x00C7820C
		public static string GetRoleAnimClassPath(EWuWaGoRoleType type)
		{
			string result = null;
			switch (type)
			{
			case EWuWaGoRoleType.AircraftSoldiers:
			{
				BP_WuWaGo_C setting = WuWaGoGlobal.Setting;
				result = ((setting != null) ? setting.MainControlAnimationBlueprint.ToAssetPathName() : null);
				break;
			}
			case EWuWaGoRoleType.DiffractionEnemy:
			{
				BP_WuWaGo_C setting2 = WuWaGoGlobal.Setting;
				result = ((setting2 != null) ? setting2.MoveMonsterAnimationBlueprint.ToAssetPathName() : null);
				break;
			}
			}
			return result;
		}

		// Token: 0x06031DBB RID: 204219 RVA: 0x00C7A060 File Offset: 0x00C78260
		public static string GetMonsterAttackRangeEffect(EWuWaGoRoleType type)
		{
			string result = null;
			switch (type)
			{
			case EWuWaGoRoleType.HeatFusionEnemy:
			{
				BP_WuWaGo_C setting = WuWaGoGlobal.Setting;
				result = ((setting != null) ? setting.StaticMonsterAttackRangeEffect.ToAssetPathName() : null);
				break;
			}
			case EWuWaGoRoleType.DiffractionEnemy:
			{
				BP_WuWaGo_C setting2 = WuWaGoGlobal.Setting;
				result = ((setting2 != null) ? setting2.MoveMonsterAttackRangeEffect.ToAssetPathName() : null);
				break;
			}
			}
			return result;
		}

		// Token: 0x06031DBC RID: 204220 RVA: 0x00C7A0B4 File Offset: 0x00C782B4
		public static string GetAppliqueMaterialPath(EWuWaGoGridLinkType linkType)
		{
			if (WuWaGoGlobal.Setting == null)
			{
				return null;
			}
			string result = null;
			switch (linkType)
			{
			case EWuWaGoGridLinkType.SingleLinkGrid:
				result = WuWaGoGlobal.Setting.SingleLinkGridMaterial.ToAssetPathName();
				break;
			case EWuWaGoGridLinkType.RightAngleLinkGrid:
				result = WuWaGoGlobal.Setting.RightAngleLinkGridMaterial.ToAssetPathName();
				break;
			case EWuWaGoGridLinkType.ThreeLinkGrid:
				result = WuWaGoGlobal.Setting.ThreeLinkGridMaterial.ToAssetPathName();
				break;
			case EWuWaGoGridLinkType.StraightLinkGrid:
				result = WuWaGoGlobal.Setting.StraightLinkGridMaterial.ToAssetPathName();
				break;
			case EWuWaGoGridLinkType.AllLinkGrid:
				result = WuWaGoGlobal.Setting.AllLinkGridMaterial.ToAssetPathName();
				break;
			}
			return result;
		}

		// Token: 0x06031DBD RID: 204221 RVA: 0x00C7A143 File Offset: 0x00C78343
		[NullableContext(1)]
		public static List<UAnimMontage> GetRoleAttackAnimations(EWuWaGoRoleType type)
		{
			Dictionary<EWuWaGoRoleType, List<UAnimMontage>> roleAttackAnimMap = WuWaGoGlobal._roleAttackAnimMap;
			return ((roleAttackAnimMap != null) ? roleAttackAnimMap.GetValueOrDefault(type) : null) ?? new List<UAnimMontage>();
		}

		// Token: 0x06031DBE RID: 204222 RVA: 0x00C7A160 File Offset: 0x00C78360
		[NullableContext(1)]
		public static List<UAnimMontage> GetRoleDeathAnimations(EWuWaGoRoleType type)
		{
			Dictionary<EWuWaGoRoleType, List<UAnimMontage>> roleDeathAnimMap = WuWaGoGlobal._roleDeathAnimMap;
			return ((roleDeathAnimMap != null) ? roleDeathAnimMap.GetValueOrDefault(type) : null) ?? new List<UAnimMontage>();
		}

		// Token: 0x06031DBF RID: 204223 RVA: 0x00C7A17D File Offset: 0x00C7837D
		[NullableContext(1)]
		public static List<UAnimMontage> GetRoleBeHitAnimations(EWuWaGoRoleType type)
		{
			Dictionary<EWuWaGoRoleType, List<UAnimMontage>> roleBeHitAnimMap = WuWaGoGlobal._roleBeHitAnimMap;
			return ((roleBeHitAnimMap != null) ? roleBeHitAnimMap.GetValueOrDefault(type) : null) ?? new List<UAnimMontage>();
		}

		// Token: 0x06031DC0 RID: 204224 RVA: 0x00C7A19A File Offset: 0x00C7839A
		public static UAnimMontage GetRoleClimbMontage(EWuWaGoRoleType type, EWuWaGoClimbMontage action)
		{
			Dictionary<EWuWaGoRoleType, Dictionary<EWuWaGoClimbMontage, UAnimMontage>> roleClimbAnimMap = WuWaGoGlobal._roleClimbAnimMap;
			if (roleClimbAnimMap == null)
			{
				return null;
			}
			Dictionary<EWuWaGoClimbMontage, UAnimMontage> valueOrDefault = roleClimbAnimMap.GetValueOrDefault(type);
			if (valueOrDefault == null)
			{
				return null;
			}
			return valueOrDefault.GetValueOrDefault(action);
		}

		// Token: 0x06031DC1 RID: 204225 RVA: 0x00C7A1B9 File Offset: 0x00C783B9
		public static UAnimMontage GetMainControlPullRodMontageByState(EGameplayEntityState currentState)
		{
			if (currentState == EGameplayEntityState.Normal)
			{
				return WuWaGoGlobal._mainControlPullRodOpenMontage;
			}
			if (currentState != EGameplayEntityState.Activated)
			{
				return null;
			}
			return WuWaGoGlobal._mainControlPullRodCloseMontage;
		}

		// Token: 0x06031DC2 RID: 204226 RVA: 0x00C7A1D2 File Offset: 0x00C783D2
		public static UAnimMontage GetSpikeFallMontage()
		{
			return WuWaGoGlobal._spikeFallMontage;
		}

		// Token: 0x06031DC3 RID: 204227 RVA: 0x00C7A1D9 File Offset: 0x00C783D9
		public static UAnimMontage GetAlertMontage()
		{
			return WuWaGoGlobal._alertMontage;
		}

		// Token: 0x06031DC4 RID: 204228 RVA: 0x00C7A1E0 File Offset: 0x00C783E0
		public static UAnimMontage GetIdleMontage()
		{
			return WuWaGoGlobal._idleMontage;
		}

		// Token: 0x06031DC5 RID: 204229 RVA: 0x00C7A1E8 File Offset: 0x00C783E8
		public static string GetAudioEvent(EWuWaGoAudioEventIndex index)
		{
			BP_WuWaGo_C setting = WuWaGoGlobal.Setting;
			TArray<string> tarray = (setting != null) ? setting.AudioEvents : null;
			if (tarray == null || index < EWuWaGoAudioEventIndex.MovableFloorMove || index >= (EWuWaGoAudioEventIndex)tarray.Num())
			{
				return null;
			}
			return WuWaGoGlobal.ParseAudioEventName(tarray.Get((int)index));
		}

		// Token: 0x06031DC6 RID: 204230 RVA: 0x00C7A228 File Offset: 0x00C78428
		private static UniTask PreloadRoleAnimations()
		{
			WuWaGoGlobal.<PreloadRoleAnimations>d__32 <PreloadRoleAnimations>d__;
			<PreloadRoleAnimations>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PreloadRoleAnimations>d__.<>1__state = -1;
			<PreloadRoleAnimations>d__.<>t__builder.Start<WuWaGoGlobal.<PreloadRoleAnimations>d__32>(ref <PreloadRoleAnimations>d__);
			return <PreloadRoleAnimations>d__.<>t__builder.Task;
		}

		// Token: 0x06031DC7 RID: 204231 RVA: 0x00C7A264 File Offset: 0x00C78464
		private static void PreloadAudioEvents(BP_WuWaGo_C setting)
		{
			TArray<string> tarray = (setting != null) ? setting.AudioEvents : null;
			if (tarray == null)
			{
				return;
			}
			for (int i = 0; i < tarray.Num(); i++)
			{
				string text = WuWaGoGlobal.ParseAudioEventName(tarray.Get(i));
				if (text != null)
				{
					HashSet<string> preloadedAudioEvents = WuWaGoGlobal._preloadedAudioEvents;
					if (preloadedAudioEvents == null || !preloadedAudioEvents.Contains(text))
					{
						Singleton<AudioSystem>.Instance.PreloadAudioEvent(text);
						HashSet<string> preloadedAudioEvents2 = WuWaGoGlobal._preloadedAudioEvents;
						if (preloadedAudioEvents2 != null)
						{
							preloadedAudioEvents2.Add(text);
						}
					}
				}
			}
		}

		// Token: 0x06031DC8 RID: 204232 RVA: 0x00C7A2D4 File Offset: 0x00C784D4
		private static void ReleaseAudioEvents()
		{
			if (WuWaGoGlobal._preloadedAudioEvents == null)
			{
				return;
			}
			foreach (string @event in WuWaGoGlobal._preloadedAudioEvents)
			{
				Singleton<AudioSystem>.Instance.ReleaseAudioEvent(@event);
			}
			WuWaGoGlobal._preloadedAudioEvents.Clear();
		}

		// Token: 0x06031DC9 RID: 204233 RVA: 0x00C7A33C File Offset: 0x00C7853C
		private static string ParseAudioEventName(string source)
		{
			if (source == null || StringUtils.IsBlank(source))
			{
				return null;
			}
			string text = Singleton<AudioSystem>.Instance.parseAudioEventPath(source);
			if (!(text == "none"))
			{
				return text;
			}
			return null;
		}

		// Token: 0x06031DCA RID: 204234 RVA: 0x00C7A374 File Offset: 0x00C78574
		[NullableContext(1)]
		private static UniTask PreloadMainControlPullRodMontages(BP_WuWaGo_C setting)
		{
			WuWaGoGlobal.<PreloadMainControlPullRodMontages>d__36 <PreloadMainControlPullRodMontages>d__;
			<PreloadMainControlPullRodMontages>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PreloadMainControlPullRodMontages>d__.setting = setting;
			<PreloadMainControlPullRodMontages>d__.<>1__state = -1;
			<PreloadMainControlPullRodMontages>d__.<>t__builder.Start<WuWaGoGlobal.<PreloadMainControlPullRodMontages>d__36>(ref <PreloadMainControlPullRodMontages>d__);
			return <PreloadMainControlPullRodMontages>d__.<>t__builder.Task;
		}

		// Token: 0x06031DCB RID: 204235 RVA: 0x00C7A3B8 File Offset: 0x00C785B8
		[NullableContext(1)]
		private static UniTask PreloadSpikeFallMontage(BP_WuWaGo_C setting)
		{
			WuWaGoGlobal.<PreloadSpikeFallMontage>d__37 <PreloadSpikeFallMontage>d__;
			<PreloadSpikeFallMontage>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PreloadSpikeFallMontage>d__.setting = setting;
			<PreloadSpikeFallMontage>d__.<>1__state = -1;
			<PreloadSpikeFallMontage>d__.<>t__builder.Start<WuWaGoGlobal.<PreloadSpikeFallMontage>d__37>(ref <PreloadSpikeFallMontage>d__);
			return <PreloadSpikeFallMontage>d__.<>t__builder.Task;
		}

		// Token: 0x06031DCC RID: 204236 RVA: 0x00C7A3FC File Offset: 0x00C785FC
		[NullableContext(1)]
		private static UniTask PreloadAlertMontage(BP_WuWaGo_C setting)
		{
			WuWaGoGlobal.<PreloadAlertMontage>d__38 <PreloadAlertMontage>d__;
			<PreloadAlertMontage>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PreloadAlertMontage>d__.setting = setting;
			<PreloadAlertMontage>d__.<>1__state = -1;
			<PreloadAlertMontage>d__.<>t__builder.Start<WuWaGoGlobal.<PreloadAlertMontage>d__38>(ref <PreloadAlertMontage>d__);
			return <PreloadAlertMontage>d__.<>t__builder.Task;
		}

		// Token: 0x06031DCD RID: 204237 RVA: 0x00C7A440 File Offset: 0x00C78640
		[NullableContext(1)]
		private static UniTask PreloadIdleMontage(BP_WuWaGo_C setting)
		{
			WuWaGoGlobal.<PreloadIdleMontage>d__39 <PreloadIdleMontage>d__;
			<PreloadIdleMontage>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PreloadIdleMontage>d__.setting = setting;
			<PreloadIdleMontage>d__.<>1__state = -1;
			<PreloadIdleMontage>d__.<>t__builder.Start<WuWaGoGlobal.<PreloadIdleMontage>d__39>(ref <PreloadIdleMontage>d__);
			return <PreloadIdleMontage>d__.<>t__builder.Task;
		}

		// Token: 0x06031DCE RID: 204238 RVA: 0x00C7A484 File Offset: 0x00C78684
		[NullableContext(1)]
		private static UniTask PreloadOneRoleAnim(EWuWaGoRoleType type, SWuWaGoRoleAnim anim)
		{
			WuWaGoGlobal.<PreloadOneRoleAnim>d__40 <PreloadOneRoleAnim>d__;
			<PreloadOneRoleAnim>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PreloadOneRoleAnim>d__.type = type;
			<PreloadOneRoleAnim>d__.anim = anim;
			<PreloadOneRoleAnim>d__.<>1__state = -1;
			<PreloadOneRoleAnim>d__.<>t__builder.Start<WuWaGoGlobal.<PreloadOneRoleAnim>d__40>(ref <PreloadOneRoleAnim>d__);
			return <PreloadOneRoleAnim>d__.<>t__builder.Task;
		}

		// Token: 0x06031DCF RID: 204239 RVA: 0x00C7A4D0 File Offset: 0x00C786D0
		[return: Nullable(new byte[]
		{
			0,
			1,
			1
		})]
		private static UniTask<List<UAnimMontage>> LoadMontageArray([Nullable(new byte[]
		{
			2,
			1,
			1
		})] TArray<TSoftObjectPtr<UAnimMontage>> softPtr)
		{
			WuWaGoGlobal.<LoadMontageArray>d__41 <LoadMontageArray>d__;
			<LoadMontageArray>d__.<>t__builder = AsyncUniTaskMethodBuilder<List<UAnimMontage>>.Create();
			<LoadMontageArray>d__.softPtr = softPtr;
			<LoadMontageArray>d__.<>1__state = -1;
			<LoadMontageArray>d__.<>t__builder.Start<WuWaGoGlobal.<LoadMontageArray>d__41>(ref <LoadMontageArray>d__);
			return <LoadMontageArray>d__.<>t__builder.Task;
		}

		// Token: 0x06031DD0 RID: 204240 RVA: 0x00C7A514 File Offset: 0x00C78714
		[return: Nullable(new byte[]
		{
			0,
			1,
			1
		})]
		private static UniTask<Dictionary<EWuWaGoClimbMontage, UAnimMontage>> LoadMontageMap([Nullable(new byte[]
		{
			2,
			0,
			1,
			1
		})] TMap<TEnumAsByte<EWuWaGoClimbMontage>, TSoftObjectPtr<UAnimMontage>> softMap)
		{
			WuWaGoGlobal.<LoadMontageMap>d__42 <LoadMontageMap>d__;
			<LoadMontageMap>d__.<>t__builder = AsyncUniTaskMethodBuilder<Dictionary<EWuWaGoClimbMontage, UAnimMontage>>.Create();
			<LoadMontageMap>d__.softMap = softMap;
			<LoadMontageMap>d__.<>1__state = -1;
			<LoadMontageMap>d__.<>t__builder.Start<WuWaGoGlobal.<LoadMontageMap>d__42>(ref <LoadMontageMap>d__);
			return <LoadMontageMap>d__.<>t__builder.Task;
		}

		// Token: 0x06031DD1 RID: 204241 RVA: 0x00C7A558 File Offset: 0x00C78758
		[return: Nullable(new byte[]
		{
			0,
			2
		})]
		private static UniTask<UAnimMontage> LoadMontage(string path = null)
		{
			WuWaGoGlobal.<LoadMontage>d__43 <LoadMontage>d__;
			<LoadMontage>d__.<>t__builder = AsyncUniTaskMethodBuilder<UAnimMontage>.Create();
			<LoadMontage>d__.path = path;
			<LoadMontage>d__.<>1__state = -1;
			<LoadMontage>d__.<>t__builder.Start<WuWaGoGlobal.<LoadMontage>d__43>(ref <LoadMontage>d__);
			return <LoadMontage>d__.<>t__builder.Task;
		}

		// Token: 0x0401D2FD RID: 119549
		[Nullable(1)]
		private const string SETTING_DA_PATH = "/Game/Aki/Data/Gameplay/WuWaGo/DA_WuWaGo.DA_WuWaGo";

		// Token: 0x0401D2FE RID: 119550
		private static BP_WuWaGo_C _settingDataAsset;

		// Token: 0x0401D2FF RID: 119551
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private static Dictionary<EWuWaGoRoleType, List<UAnimMontage>> _roleAttackAnimMap;

		// Token: 0x0401D300 RID: 119552
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private static Dictionary<EWuWaGoRoleType, List<UAnimMontage>> _roleDeathAnimMap;

		// Token: 0x0401D301 RID: 119553
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private static Dictionary<EWuWaGoRoleType, List<UAnimMontage>> _roleBeHitAnimMap;

		// Token: 0x0401D302 RID: 119554
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private static Dictionary<EWuWaGoRoleType, Dictionary<EWuWaGoClimbMontage, UAnimMontage>> _roleClimbAnimMap;

		// Token: 0x0401D303 RID: 119555
		private static UAnimMontage _mainControlPullRodOpenMontage;

		// Token: 0x0401D304 RID: 119556
		private static UAnimMontage _mainControlPullRodCloseMontage;

		// Token: 0x0401D305 RID: 119557
		private static UAnimMontage _spikeFallMontage;

		// Token: 0x0401D306 RID: 119558
		private static UAnimMontage _alertMontage;

		// Token: 0x0401D307 RID: 119559
		private static UAnimMontage _idleMontage;

		// Token: 0x0401D308 RID: 119560
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private static HashSet<string> _preloadedAudioEvents;
	}
}
