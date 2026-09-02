using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.MaterialController;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Effect;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.CyberPunk
{
	// Token: 0x02006967 RID: 26983
	[NullableContext(1)]
	[Nullable(0)]
	public class AdamSmasherSelectView : UiViewBase
	{
		// Token: 0x06042F26 RID: 274214 RVA: 0x0112FDF4 File Offset: 0x0112DFF4
		public AdamSmasherSelectView(UiViewInfo viewInfo)
		{
			FRotator frotator = new FRotator(0f, 0f, 0f);
			FVectorDouble fvectorDouble = new FVectorDouble(0.0, 0.0, 0.0);
			FVectorDouble fvectorDouble2 = new FVectorDouble(1.0, 1.0, 1.0);
			FVector fvector = fvectorDouble2;
			this.CacheTransform = new FTransformDouble(ref frotator, ref fvectorDouble, ref fvector);
			base..ctor(viewInfo);
		}

		// Token: 0x06042F27 RID: 274215 RVA: 0x0112FEA0 File Offset: 0x0112E0A0
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIVerticalLayout)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIText)),
				new ValueTuple<int, Type>(4, typeof(UUIText)),
				new ValueTuple<int, Type>(5, typeof(UUIText)),
				new ValueTuple<int, Type>(6, typeof(UUIText)),
				new ValueTuple<int, Type>(7, typeof(UUIScrollViewWithScrollbarComponent)),
				new ValueTuple<int, Type>(8, typeof(UUIText)),
				new ValueTuple<int, Type>(9, typeof(UUIText)),
				new ValueTuple<int, Type>(10, typeof(UUIText)),
				new ValueTuple<int, Type>(11, typeof(UUIScrollViewWithScrollbarComponent)),
				new ValueTuple<int, Type>(12, typeof(UUIItem)),
				new ValueTuple<int, Type>(13, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(14, typeof(UUIItem))
			};
		}

		// Token: 0x06042F28 RID: 274216 RVA: 0x01130008 File Offset: 0x0112E208
		protected override UniTask OnBeforeStartAsync()
		{
			AdamSmasherSelectView.<OnBeforeStartAsync>d__13 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<AdamSmasherSelectView.<OnBeforeStartAsync>d__13>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06042F29 RID: 274217 RVA: 0x0113004C File Offset: 0x0112E24C
		protected override void OnStart()
		{
			ActivityModel instance = ModelBase<ActivityModel>.Instance;
			ActivityBaseData activityBaseData = (instance != null) ? instance.GetActivityById(ControllerBase<CyberPunkController>.Instance.CurrentActivityId) : null;
			if (activityBaseData != null && activityBaseData.CheckIfClose() && ControllerBase<AdamSmasherController>.Instance.IsInAdamSmasherDungeon())
			{
				ControllerBase<InstanceDungeonEntranceController>.Instance.LeaveInstanceDungeon().ContinueWith(delegate(bool Result)
				{
					base.CloseMe(null);
				});
			}
			this.CaptionItem.SetCloseCallBack(new Action(this.OnClickClose));
			this.CaptionItem.SetHelpCallBack(new Action(this.OnClickHelp));
			this.CaptionItem.SetHomeBtnShowState(true);
			this.ChallengeButtonItem.SetFunction(new Action<int>(this.OnClickChallenge));
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), "AdamChallenge_Name", Array.Empty<object>());
			this.StageListLayout = new GenericLayout<AdamSmasherStageItem, IAdamSmasherStageItemData>(base.GetVerticalLayout(1), new Func<AdamSmasherStageItem>(this.CreateStageItem), null, false, true);
			this.InitStageList();
			this.RefreshView();
			this.MarkBossEntranceFirstClicked();
		}

		// Token: 0x06042F2A RID: 274218 RVA: 0x01130149 File Offset: 0x0112E349
		private void MarkBossEntranceFirstClicked()
		{
			if (LocalStorage.GetPlayer<bool>(ELocalStoragePlayerKey.CyberPunkBossEntranceFirstClicked, false))
			{
				return;
			}
			LocalStorage.SetPlayer<bool>(ELocalStoragePlayerKey.CyberPunkBossEntranceFirstClicked, true);
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, ControllerBase<CyberPunkController>.Instance.CurrentActivityId);
		}

		// Token: 0x06042F2B RID: 274219 RVA: 0x0113017F File Offset: 0x0112E37F
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add<IReadOnlySet<int>>(EEventName.OnActivityClose, new Action<IReadOnlySet<int>>(this.OnActivityClose));
		}

		// Token: 0x06042F2C RID: 274220 RVA: 0x0113019D File Offset: 0x0112E39D
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove<IReadOnlySet<int>>(EEventName.OnActivityClose, new Action<IReadOnlySet<int>>(this.OnActivityClose));
		}

		// Token: 0x06042F2D RID: 274221 RVA: 0x011301BB File Offset: 0x0112E3BB
		protected override void OnBeforeDestroy()
		{
			this.ClearMaterialControllers();
			this.ClearSceneEffects("[AdamSmasherSelectView.OnBeforeDestroy]");
		}

		// Token: 0x06042F2E RID: 274222 RVA: 0x011301D0 File Offset: 0x0112E3D0
		private void InitStageList()
		{
			CyberPunkConfig instance = ConfigBase<CyberPunkConfig>.Instance;
			this.CachedStageList = (((instance != null) ? instance.GetStageConfigList(ControllerBase<CyberPunkController>.Instance.CurrentActivityId) : null) ?? Array.Empty<EdgeRunnerLordGym>());
			if (this.CachedStageList.Count == 0)
			{
				Singleton<Log>.Instance.Warn(ELogModule.Activity, ELogAuthor.SWC, "[AdamSmasherSelectView] 关卡列表为空", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			int num = 0;
			for (int i = this.CachedStageList.Count - 1; i >= 0; i--)
			{
				EdgeRunnerLordGym edgeRunnerLordGym = this.CachedStageList[i];
				if (ControllerBase<AdamSmasherController>.Instance.IsStageUnlocked(edgeRunnerLordGym.Id))
				{
					num = edgeRunnerLordGym.Id;
					break;
				}
			}
			if (num == 0 && this.CachedStageList.Count > 0)
			{
				num = this.CachedStageList[0].Id;
			}
			this.SelectedStageId = num;
		}

		// Token: 0x06042F2F RID: 274223 RVA: 0x011302A8 File Offset: 0x0112E4A8
		protected override void OnHandleLoadScene()
		{
			if (!Singleton<UiSceneManager>.Instance.HasAdamSmasherSkeletalHandle())
			{
				Singleton<UiSceneManager>.Instance.InitAdamSmasherSkeletalHandle();
			}
			SkeletalObserverHandle adamSmasherSkeletalHandle = Singleton<UiSceneManager>.Instance.GetAdamSmasherSkeletalHandle();
			if (((adamSmasherSkeletalHandle != null) ? adamSmasherSkeletalHandle.Model : null) != null)
			{
				Singleton<UiModelUtil>.Instance.SetTransformByTag(adamSmasherSkeletalHandle.Model, "MonsterCase");
			}
			this.RefreshStageScenePresentation().Forget();
		}

		// Token: 0x06042F30 RID: 274224 RVA: 0x01130304 File Offset: 0x0112E504
		protected override void OnHandleReleaseScene()
		{
			this.ClearMaterialControllers();
			this.ClearSceneEffects("[AdamSmasherSelectView.OnHandleReleaseScene]");
			Singleton<UiSceneManager>.Instance.DestroyAdamSmasherSkeletalHandle();
		}

		// Token: 0x06042F31 RID: 274225 RVA: 0x01130321 File Offset: 0x0112E521
		private void RefreshView()
		{
			this.RefreshStageList();
			this.RefreshSelectedStage();
			this.RefreshRemainTime();
		}

		// Token: 0x06042F32 RID: 274226 RVA: 0x01130338 File Offset: 0x0112E538
		private void RefreshStageList()
		{
			List<IAdamSmasherStageItemData> list = new List<IAdamSmasherStageItemData>();
			for (int i = 0; i < this.CachedStageList.Count; i++)
			{
				EdgeRunnerLordGym edgeRunnerLordGym = this.CachedStageList[i];
				list.Add(new AdamSmasherStageItemData
				{
					StageId = edgeRunnerLordGym.Id,
					IndexText = (i + 1).ToString(),
					Name = (edgeRunnerLordGym.Title ?? ""),
					IsUnlocked = ControllerBase<AdamSmasherController>.Instance.IsStageUnlocked(edgeRunnerLordGym.Id),
					IsHard = (edgeRunnerLordGym.IsHard == 1)
				});
			}
			this.StageListLayout.RefreshByData(list, delegate
			{
				this.RefreshAllStageToggleState();
			}, false);
		}

		// Token: 0x06042F33 RID: 274227 RVA: 0x011303F0 File Offset: 0x0112E5F0
		private void RefreshSelectedStage()
		{
			this.RefreshRightPanel();
		}

		// Token: 0x06042F34 RID: 274228 RVA: 0x011303F8 File Offset: 0x0112E5F8
		private void RefreshRightPanel()
		{
			CyberPunkConfig instance = ConfigBase<CyberPunkConfig>.Instance;
			EdgeRunnerLordGym? edgeRunnerLordGym = (instance != null) ? instance.GetStageConfig(this.SelectedStageId) : null;
			if (edgeRunnerLordGym == null)
			{
				return;
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), "AdamChallenge_Level", new <>z__ReadOnlySingleElementList<object>(edgeRunnerLordGym.Value.Level));
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(6), edgeRunnerLordGym.Value.Title, Array.Empty<object>());
			if (edgeRunnerLordGym.Value.BuffNumLength > 0)
			{
				string[] array = new string[edgeRunnerLordGym.Value.BuffNumLength];
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = edgeRunnerLordGym.Value.BuffNum(i);
				}
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(8), edgeRunnerLordGym.Value.BuffDesc, array);
			}
			else
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(8), edgeRunnerLordGym.Value.BuffDesc, Array.Empty<object>());
			}
			string stageRecordText = ControllerBase<AdamSmasherController>.Instance.GetStageRecordText(this.SelectedStageId);
			if (!string.IsNullOrEmpty(stageRecordText))
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(9), "AdamChallenge_BestScore", Array.Empty<object>());
				base.GetText(10).SetText(stageRecordText, true);
			}
			else
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(9), "NoPassRecord", Array.Empty<object>());
				base.GetText(10).SetText("", true);
			}
			this.RefreshRewardList();
			this.RefreshChallengeButtonState();
		}

		// Token: 0x06042F35 RID: 274229 RVA: 0x011305A0 File Offset: 0x0112E7A0
		private void RefreshRewardList()
		{
			List<TItem> selectedStageRewardPreview = ControllerBase<AdamSmasherController>.Instance.GetSelectedStageRewardPreview(this.SelectedStageId);
			if (selectedStageRewardPreview != null && selectedStageRewardPreview.Count > 0)
			{
				this.RewardScroll.RefreshByData(selectedStageRewardPreview, null, false);
			}
		}

		// Token: 0x06042F36 RID: 274230 RVA: 0x011305D8 File Offset: 0x0112E7D8
		private void RefreshChallengeButtonState()
		{
			bool flag = ControllerBase<AdamSmasherController>.Instance.IsStageUnlocked(this.SelectedStageId);
			ButtonItem challengeButtonItem = this.ChallengeButtonItem;
			if (challengeButtonItem != null)
			{
				challengeButtonItem.SetEnableClick(flag);
			}
			UUIButtonComponent button = base.GetButton(13);
			if (button != null)
			{
				button.RootUIComp.Get().SetUIActive(flag);
			}
			AdamSmasherLockBtnPanel lockBtnItem = this.LockBtnItem;
			if (lockBtnItem == null)
			{
				return;
			}
			lockBtnItem.SetUiActive(!flag);
		}

		// Token: 0x06042F37 RID: 274231 RVA: 0x01130640 File Offset: 0x0112E840
		private void RefreshRemainTime()
		{
			CyberPunkController instance = ControllerBase<CyberPunkController>.Instance;
			string text = (instance != null) ? instance.GetTimeVisibleAndRemainTimeText() : null;
			if (!string.IsNullOrEmpty(text))
			{
				UUIText text2 = base.GetText(3);
				if (text2 == null)
				{
					return;
				}
				text2.SetText(text, true);
			}
		}

		// Token: 0x06042F38 RID: 274232 RVA: 0x0113067C File Offset: 0x0112E87C
		private void RefreshAllStageToggleState()
		{
			GenericLayout<AdamSmasherStageItem, IAdamSmasherStageItemData> stageListLayout = this.StageListLayout;
			List<AdamSmasherStageItem> list = (stageListLayout != null) ? stageListLayout.GetLayoutItemList() : null;
			if (list == null)
			{
				return;
			}
			foreach (AdamSmasherStageItem adamSmasherStageItem in list)
			{
				adamSmasherStageItem.SetToggleActive(adamSmasherStageItem.GetStageId() == this.SelectedStageId);
			}
		}

		// Token: 0x06042F39 RID: 274233 RVA: 0x011306EC File Offset: 0x0112E8EC
		public void ChangeStageId(int stageId)
		{
			this.SelectedStageId = stageId;
			this.RefreshAllStageToggleState();
			this.RefreshSelectedStage();
			this.RefreshStageScenePresentation().Forget();
		}

		// Token: 0x06042F3A RID: 274234 RVA: 0x0113070C File Offset: 0x0112E90C
		private UniTask RefreshStageScenePresentation()
		{
			AdamSmasherSelectView.<RefreshStageScenePresentation>d__31 <RefreshStageScenePresentation>d__;
			<RefreshStageScenePresentation>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshStageScenePresentation>d__.<>4__this = this;
			<RefreshStageScenePresentation>d__.<>1__state = -1;
			<RefreshStageScenePresentation>d__.<>t__builder.Start<AdamSmasherSelectView.<RefreshStageScenePresentation>d__31>(ref <RefreshStageScenePresentation>d__);
			return <RefreshStageScenePresentation>d__.<>t__builder.Task;
		}

		// Token: 0x06042F3B RID: 274235 RVA: 0x01130750 File Offset: 0x0112E950
		private EdgeRunnerLordGym? GetSelectedStageConfig()
		{
			CyberPunkConfig instance = ConfigBase<CyberPunkConfig>.Instance;
			if (instance == null)
			{
				return null;
			}
			return instance.GetStageConfig(this.SelectedStageId);
		}

		// Token: 0x06042F3C RID: 274236 RVA: 0x0113077C File Offset: 0x0112E97C
		private void RefreshSceneEffects(EdgeRunnerLordGym stageConfig)
		{
			string text = stageConfig.LordUISceneEffect ?? "";
			this.ClearSceneEffects("[AdamSmasherSelectView.RefreshSceneEffects]");
			if (StringUtils.IsBlank(text))
			{
				return;
			}
			List<int> sceneEffectHandleList = this.SceneEffectHandleList;
			EffectSystem instance = Singleton<EffectSystem>.Instance;
			UObject world = GlobalData.World;
			FTransformDouble? ftransformDouble = new FTransformDouble?(this.CacheTransform);
			sceneEffectHandleList.Add(instance.SpawnEffect(world, ftransformDouble, text, "AdamSmasherSceneEffect", null, EEffectType.UiScene3D, null, null, null, false, false));
		}

		// Token: 0x06042F3D RID: 274237 RVA: 0x011307E4 File Offset: 0x0112E9E4
		private UniTask LoadStageModel(EdgeRunnerLordGym stageConfig)
		{
			AdamSmasherSelectView.<LoadStageModel>d__34 <LoadStageModel>d__;
			<LoadStageModel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<LoadStageModel>d__.<>4__this = this;
			<LoadStageModel>d__.stageConfig = stageConfig;
			<LoadStageModel>d__.<>1__state = -1;
			<LoadStageModel>d__.<>t__builder.Start<AdamSmasherSelectView.<LoadStageModel>d__34>(ref <LoadStageModel>d__);
			return <LoadStageModel>d__.<>t__builder.Task;
		}

		// Token: 0x06042F3E RID: 274238 RVA: 0x01130830 File Offset: 0x0112EA30
		private void ApplyModelTransform(EdgeRunnerLordGym stageConfig, UiModelActorComponent actorComponent)
		{
			float[] locationArray = stageConfig.GetLocationArray();
			float[] rotatorArray = stageConfig.GetRotatorArray();
			float[] zoomArray = stageConfig.GetZoomArray();
			if (locationArray == null || rotatorArray == null || zoomArray == null || locationArray.Length < 3 || rotatorArray.Length < 3 || zoomArray.Length < 3)
			{
				return;
			}
			FRotator frotator = new FRotator(rotatorArray[0], rotatorArray[1], rotatorArray[2]);
			FVector fvector = new FVector(locationArray[0], locationArray[1], locationArray[2]);
			FVector fvector2 = new FVector(zoomArray[0], zoomArray[1], zoomArray[2]);
			FTransform newTransform = new FTransform(ref frotator, ref fvector, ref fvector2);
			FHitResult fhitResult = new FHitResult();
			actorComponent.SetAllMeshComponentRelativeTransform(newTransform, false, ref fhitResult, false);
		}

		// Token: 0x06042F3F RID: 274239 RVA: 0x011308C0 File Offset: 0x0112EAC0
		private void ApplyModelMaterialController(string materialControllerPath, UiModelLoadComponent loadComponent)
		{
			this.ClearMaterialControllers();
			if (StringUtils.IsBlank(materialControllerPath))
			{
				return;
			}
			SkeletalObserverHandle adamSmasherSkeletalHandle = Singleton<UiSceneManager>.Instance.GetAdamSmasherSkeletalHandle();
			UiModelRenderingMaterialComponent uiModelRenderingMaterialComponent;
			if (adamSmasherSkeletalHandle == null)
			{
				uiModelRenderingMaterialComponent = null;
			}
			else
			{
				UiModelBase model = adamSmasherSkeletalHandle.Model;
				uiModelRenderingMaterialComponent = ((model != null) ? model.CheckGetComponent<UiModelRenderingMaterialComponent>() : null);
			}
			UiModelRenderingMaterialComponent uiModelRenderingMaterialComponent2 = uiModelRenderingMaterialComponent;
			PD_CharacterControllerData_C pd_CharacterControllerData_C = loadComponent.GetLoadedResource(materialControllerPath) as PD_CharacterControllerData_C;
			if (pd_CharacterControllerData_C == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Activity;
				ELogAuthor author = ELogAuthor.SWC;
				string message = "[AdamSmasherSelectView] 材质控制器加载失败";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("MaterialController", materialControllerPath);
				instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			int? num = (uiModelRenderingMaterialComponent2 != null) ? new int?(uiModelRenderingMaterialComponent2.AddRenderingMaterialByData(pd_CharacterControllerData_C)) : null;
			if (num != null)
			{
				this.MaterialControllerHandleList.Add(num.Value);
			}
		}

		// Token: 0x06042F40 RID: 274240 RVA: 0x01130974 File Offset: 0x0112EB74
		private void ClearSceneEffects(string reason)
		{
			foreach (int num in this.SceneEffectHandleList)
			{
				if (Singleton<EffectSystem>.Instance.IsValid(num))
				{
					Singleton<EffectSystem>.Instance.StopEffectById(num, reason, true, null);
				}
			}
			this.SceneEffectHandleList.Clear();
		}

		// Token: 0x06042F41 RID: 274241 RVA: 0x011309F0 File Offset: 0x0112EBF0
		private void ClearMaterialControllers()
		{
			if (this.MaterialControllerHandleList.Count <= 0)
			{
				return;
			}
			SkeletalObserverHandle adamSmasherSkeletalHandle = Singleton<UiSceneManager>.Instance.GetAdamSmasherSkeletalHandle();
			UiModelRenderingMaterialComponent uiModelRenderingMaterialComponent;
			if (adamSmasherSkeletalHandle == null)
			{
				uiModelRenderingMaterialComponent = null;
			}
			else
			{
				UiModelBase model = adamSmasherSkeletalHandle.Model;
				uiModelRenderingMaterialComponent = ((model != null) ? model.CheckGetComponent<UiModelRenderingMaterialComponent>() : null);
			}
			UiModelRenderingMaterialComponent uiModelRenderingMaterialComponent2 = uiModelRenderingMaterialComponent;
			foreach (int materialId in this.MaterialControllerHandleList)
			{
				if (uiModelRenderingMaterialComponent2 != null)
				{
					uiModelRenderingMaterialComponent2.RemoveRenderingMaterial(materialId);
				}
			}
			this.MaterialControllerHandleList.Clear();
		}

		// Token: 0x06042F42 RID: 274242 RVA: 0x01130A84 File Offset: 0x0112EC84
		private void OnClickChallenge(int a)
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.AdamSmasherFormationView, this.SelectedStageId, null);
		}

		// Token: 0x06042F43 RID: 274243 RVA: 0x01130AA1 File Offset: 0x0112ECA1
		private void OnClickHelp()
		{
			ControllerBase<HelpController>.Instance.OpenHelpById(0);
		}

		// Token: 0x06042F44 RID: 274244 RVA: 0x01130AB0 File Offset: 0x0112ECB0
		private void OnClickClose()
		{
			if (ControllerBase<AdamSmasherController>.Instance.IsInAdamSmasherDungeon())
			{
				ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.CyberPunkExitDungeonConfirm);
				confirmBoxDataNew.FunctionMap[2] = delegate()
				{
					ControllerBase<InstanceDungeonEntranceController>.Instance.LeaveInstanceDungeon().ContinueWith(delegate(bool Result)
					{
						base.CloseMe(null);
					});
				};
				ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
				return;
			}
			base.CloseMe(null);
		}

		// Token: 0x06042F45 RID: 274245 RVA: 0x01130B00 File Offset: 0x0112ED00
		private void OnActivityClose(IReadOnlySet<int> closeActivities)
		{
			if (closeActivities.Contains(ControllerBase<CyberPunkController>.Instance.CurrentActivityId))
			{
				if (ControllerBase<AdamSmasherController>.Instance.IsInAdamSmasherDungeon())
				{
					ControllerBase<InstanceDungeonEntranceController>.Instance.LeaveInstanceDungeon().Forget<bool>();
					return;
				}
				ControllerBase<ActivityController>.Instance.ShowActivityRefreshAndBackToBattleView();
			}
		}

		// Token: 0x06042F46 RID: 274246 RVA: 0x01130B3C File Offset: 0x0112ED3C
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
		{
			if (configParams.Length == 0)
			{
				return null;
			}
			if (!(configParams[0] == "BackToBattleViewBtn"))
			{
				return null;
			}
			UActorComponent componentInChildren = ULGUIBPLibrary.GetComponentInChildren(base.GetRootActor(), TsUiHomeHelper.StaticClass(), false);
			AActor aactor = (componentInChildren != null) ? componentInChildren.GetOwner() : null;
			if (aactor == null)
			{
				return null;
			}
			UUIButtonComponent uuibuttonComponent = ULGUIBPLibrary.GetComponentInChildren(aactor, UUIButtonComponent.StaticClass(), false) as UUIButtonComponent;
			UUIItem uuiitem = (uuibuttonComponent != null) ? uuibuttonComponent.GetRootComponent() : null;
			if (uuiitem == null)
			{
				return null;
			}
			return new UUIItem[]
			{
				uuiitem,
				uuiitem
			};
		}

		// Token: 0x06042F47 RID: 274247 RVA: 0x01130BBE File Offset: 0x0112EDBE
		private AdamSmasherStageItem CreateStageItem()
		{
			return new AdamSmasherStageItem();
		}

		// Token: 0x06042F48 RID: 274248 RVA: 0x01130BC5 File Offset: 0x0112EDC5
		private CommonItemSmallItemGrid CreateRewardItem()
		{
			return new CommonItemSmallItemGrid
			{
				ShowReceivedCallBack = ((TItem _) => ControllerBase<AdamSmasherController>.Instance.IsStageCleared(this.SelectedStageId))
			};
		}

		// Token: 0x040254C1 RID: 152769
		[Nullable(2)]
		private PopupCaptionItem CaptionItem;

		// Token: 0x040254C2 RID: 152770
		[Nullable(2)]
		private ButtonItem ChallengeButtonItem;

		// Token: 0x040254C3 RID: 152771
		[Nullable(2)]
		private AdamSmasherLockBtnPanel LockBtnItem;

		// Token: 0x040254C4 RID: 152772
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<AdamSmasherStageItem, IAdamSmasherStageItemData> StageListLayout;

		// Token: 0x040254C5 RID: 152773
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericScrollViewNew<CommonItemSmallItemGrid, TItem> RewardScroll;

		// Token: 0x040254C6 RID: 152774
		private IReadOnlyList<EdgeRunnerLordGym> CachedStageList = Array.Empty<EdgeRunnerLordGym>();

		// Token: 0x040254C7 RID: 152775
		private int SelectedStageId = 1;

		// Token: 0x040254C8 RID: 152776
		private readonly List<int> SceneEffectHandleList = new List<int>();

		// Token: 0x040254C9 RID: 152777
		private readonly List<int> MaterialControllerHandleList = new List<int>();

		// Token: 0x040254CA RID: 152778
		private readonly FTransformDouble CacheTransform;

		// Token: 0x0200C90B RID: 51467
		[NullableContext(0)]
		private enum EComponent
		{
			// Token: 0x0403DD74 RID: 253300
			Caption,
			// Token: 0x0403DD75 RID: 253301
			StageList,
			// Token: 0x0403DD76 RID: 253302
			SpStageItem,
			// Token: 0x0403DD77 RID: 253303
			RemainTimeText,
			// Token: 0x0403DD78 RID: 253304
			BossNameText,
			// Token: 0x0403DD79 RID: 253305
			BossLevelText,
			// Token: 0x0403DD7A RID: 253306
			BuffTitleText,
			// Token: 0x0403DD7B RID: 253307
			BuffDescScroll,
			// Token: 0x0403DD7C RID: 253308
			BuffDescText,
			// Token: 0x0403DD7D RID: 253309
			RecordTitleText,
			// Token: 0x0403DD7E RID: 253310
			RecordValueText,
			// Token: 0x0403DD7F RID: 253311
			RewardScroll,
			// Token: 0x0403DD80 RID: 253312
			RewardItem,
			// Token: 0x0403DD81 RID: 253313
			ChallengeButton,
			// Token: 0x0403DD82 RID: 253314
			LockButton
		}
	}
}
