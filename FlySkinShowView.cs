using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using AkiClient.Game.Aki.Data.UiRoleCamera.Struct;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.MaterialController;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Common.UiCamera;
using CSharpScript.Game.Module.Skin;
using CSharpScript.Game.Module.UiCameraAnimation.UiCameraContext;
using CSharpScript.Game.Ui;
using CSharpScript.Game.Utils;
using UnrealEngine;

// Token: 0x02002A33 RID: 10803
[NullableContext(2)]
[Nullable(0)]
public class FlySkinShowView : UiTickViewBase
{
	// Token: 0x060159A0 RID: 88480 RVA: 0x005FCDC8 File Offset: 0x005FAFC8
	[NullableContext(1)]
	public FlySkinShowView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x060159A1 RID: 88481 RVA: 0x005FCDE4 File Offset: 0x005FAFE4
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(2, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(3, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(4, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(5, typeof(UUIText)),
			new ValueTuple<int, Type>(6, typeof(UUIText)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(9, typeof(UUIItem)),
			new ValueTuple<int, Type>(10, typeof(UUIHorizontalLayout)),
			new ValueTuple<int, Type>(11, typeof(UUIItem)),
			new ValueTuple<int, Type>(14, typeof(UUITexture)),
			new ValueTuple<int, Type>(12, typeof(UUIText)),
			new ValueTuple<int, Type>(13, typeof(UUIItem)),
			new ValueTuple<int, Type>(15, typeof(UUIText)),
			new ValueTuple<int, Type>(16, typeof(UUIText)),
			new ValueTuple<int, Type>(17, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(18, typeof(UUIItem)),
			new ValueTuple<int, Type>(19, typeof(UUIText)),
			new ValueTuple<int, Type>(20, typeof(UUIItem)),
			new ValueTuple<int, Type>(21, typeof(UUIText)),
			new ValueTuple<int, Type>(22, typeof(UUITexture)),
			new ValueTuple<int, Type>(23, typeof(UUITexture)),
			new ValueTuple<int, Type>(24, typeof(UUITexture)),
			new ValueTuple<int, Type>(25, typeof(UUIItem)),
			new ValueTuple<int, Type>(26, typeof(UUITexture)),
			new ValueTuple<int, Type>(27, typeof(UUIItem)),
			new ValueTuple<int, Type>(28, typeof(UUIItem)),
			new ValueTuple<int, Type>(29, typeof(UUIDraggableComponent)),
			new ValueTuple<int, Type>(30, typeof(UUITexture)),
			new ValueTuple<int, Type>(31, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(32, typeof(UUIItem)),
			new ValueTuple<int, Type>(33, typeof(UUIItem)),
			new ValueTuple<int, Type>(34, typeof(UUITexture)),
			new ValueTuple<int, Type>(35, typeof(UUIText)),
			new ValueTuple<int, Type>(36, typeof(UUITexture)),
			new ValueTuple<int, Type>(37, typeof(UUIText)),
			new ValueTuple<int, Type>(45, typeof(UUIItem)),
			new ValueTuple<int, Type>(46, typeof(UUIItem)),
			new ValueTuple<int, Type>(51, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(1, new Action<EToggleState>(this.OnClickOnlyUiToggle))
		};
	}

	// Token: 0x060159A2 RID: 88482 RVA: 0x005FD1C5 File Offset: 0x005FB3C5
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<UiCameraHandleData>(EEventName.OnActivateUiCameraAnimationHandle, new Action<UiCameraHandleData>(this.OnActivateUiCameraAnimationHandle));
	}

	// Token: 0x060159A3 RID: 88483 RVA: 0x005FD1E3 File Offset: 0x005FB3E3
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnActivateUiCameraAnimationHandle, new Action<UiCameraHandleData>(this.OnActivateUiCameraAnimationHandle));
	}

	// Token: 0x060159A4 RID: 88484 RVA: 0x005FD204 File Offset: 0x005FB404
	protected override void OnStart()
	{
		int itemId = (int)(this.OpenParam ?? 0);
		this.SkinData = ModelBase<FlySkinModel>.Instance.GetFlySkinData(itemId);
		if (this.SkinData != null)
		{
			this.CurrentFlySkinType = (EFlySkinType)this.SkinData.GetFlySkinConfig().SkinType;
		}
		this.CaptionItem = new PopupCaptionItem(base.GetItem(0));
		this.CaptionItem.SetCloseCallBack(new Action(this.OnCloseView));
		this.CaptionItem.SetTitleLocalText("FlySkinShopTitle_Text");
		this.CaptionItem.SetTitleIconByResourceId("FlySkinShopTitle_Icon");
		this.CaptionItem.SetHelpBtnActive(false);
		this.CaptionItem.SetHelpCallBack(new Action(this.OnClickedHelpButton));
		base.GetItem(7).SetUIActive(false);
		base.GetItem(25).SetUIActive(false);
		base.GetItem(13).SetUIActive(false);
		base.GetButton(2).RootUIComp.Get().SetUIActive(false);
		UUIItem item = base.GetItem(45);
		if (item != null)
		{
			item.SetUIActive(false);
		}
		UUIItem item2 = base.GetItem(46);
		if (item2 != null)
		{
			item2.SetUIActive(false);
		}
		UUIButtonComponent button = base.GetButton(3);
		if (button != null)
		{
			button.RootUIComp.Get().SetUIActive(false);
		}
		UUIButtonComponent button2 = base.GetButton(4);
		if (button2 != null)
		{
			button2.RootUIComp.Get().SetUIActive(false);
		}
		UUIItem item3 = base.GetItem(51);
		if (item3 != null)
		{
			item3.SetUIActive(false);
		}
		base.GetItem(9).SetUIActive(false);
	}

	// Token: 0x060159A5 RID: 88485 RVA: 0x005FD393 File Offset: 0x005FB593
	protected override void OnHandleLoadScene()
	{
		this.InitGliderObserver();
		this.InitCameraInputData();
	}

	// Token: 0x060159A6 RID: 88486 RVA: 0x005FD3A4 File Offset: 0x005FB5A4
	private void InitGliderObserver()
	{
		Singleton<UiSceneManager>.Instance.InitGliderSkeletalHandle();
		SkeletalObserverHandle gliderSkeletalHandle = Singleton<UiSceneManager>.Instance.GetGliderSkeletalHandle();
		if (gliderSkeletalHandle == null)
		{
			return;
		}
		UiModelBase model = gliderSkeletalHandle.Model;
		UiModelActorComponent uiModelActorComponent = (model != null) ? model.CheckGetComponent<UiModelActorComponent>() : null;
		if (uiModelActorComponent != null)
		{
			uiModelActorComponent.SetTransformByTag(FlySkinDefine.DEFAULT_FLY_SKIN_CASE);
		}
		this.GliderObserver = gliderSkeletalHandle;
	}

	// Token: 0x060159A7 RID: 88487 RVA: 0x005FD3F4 File Offset: 0x005FB5F4
	public void InitCameraInputData()
	{
		string rowName = "翱翔滑翔皮肤旋转查看";
		SUiRoleCameraSetting? roleCameraConfig = ConfigBase<UiRoleCameraConfig>.Instance.GetRoleCameraConfig(rowName);
		if (roleCameraConfig == null)
		{
			return;
		}
		SkeletalObserverHandle gliderObserver = this.GliderObserver;
		if (((gliderObserver != null) ? gliderObserver.Model : null) == null)
		{
			return;
		}
		AActor actorWithTag = UKuroCollectActorComponent.GetActorWithTag(FNameUtil.GetDynamicFName(FlySkinDefine.flySkinTypeToCase[this.CurrentFlySkinType]).Value, ECollectActorType.UI);
		if (actorWithTag == null)
		{
			return;
		}
		FVectorDouble fvectorDouble = actorWithTag.D_K2_GetActorLocation();
		UiCameraInputComponentData data = new UiCameraInputComponentData
		{
			DragComponent = base.GetDraggable(29),
			CameraSettingConfig = roleCameraConfig.Value,
			SourceLocation = fvectorDouble
		};
		this.CameraInputComponent.InitData(data);
		this.CameraInputComponent.CanCameraInput = false;
	}

	// Token: 0x060159A8 RID: 88488 RVA: 0x005FD4AA File Offset: 0x005FB6AA
	protected override void OnBeforeShow()
	{
		this.TryPushCamera();
		this.TryLoadModel();
		this.RefreshView();
		this.CameraInputComponent.Start();
		this.CameraInputComponent.TryActivate();
	}

	// Token: 0x060159A9 RID: 88489 RVA: 0x005FD4D8 File Offset: 0x005FB6D8
	private void RefreshView()
	{
		if (this.SkinData == null)
		{
			return;
		}
		bool uiactive = this.SkinData.GetSkinGrade() == 1;
		base.GetItem(33).SetUIActive(uiactive);
		base.GetItem(32).SetUIActive(uiactive);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), this.SkinData.GetTitleName(), Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(6), this.SkinData.GetSubTitle(), Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(12), this.SkinData.GetDesc(), Array.Empty<object>());
		base.SetTextureByPath(this.SkinData.GetPreviewTextureInBuyView(), base.GetTexture(23), null, null);
		base.SetTextureByPath(this.SkinData.GetBuyPreviewQualityBgPath(), base.GetTexture(22), null, null);
		base.GetItem(18).SetUIActive(false);
		base.GetItem(20).SetUIActive(false);
	}

	// Token: 0x060159AA RID: 88490 RVA: 0x005FD5E0 File Offset: 0x005FB7E0
	private void TryPushCamera()
	{
		string flySkinModelCameraId = ConfigBase<SkinConfig>.Instance.GetFlySkinModelCameraId(this.CurrentFlySkinType);
		this.WaitCameraId = flySkinModelCameraId;
		Singleton<UiCameraAnimationManager>.Instance.PushCameraHandleByHandleName(flySkinModelCameraId, true, true, "10010", false, null, null);
	}

	// Token: 0x060159AB RID: 88491 RVA: 0x005FD624 File Offset: 0x005FB824
	public void TryLoadModel()
	{
		SkeletalObserverHandle gliderObserver = this.GliderObserver;
		UiModelBase uiModelBase = (gliderObserver != null) ? gliderObserver.Model : null;
		if (uiModelBase == null)
		{
			return;
		}
		string transformByTag = FlySkinDefine.flySkinTypeToCase[this.CurrentFlySkinType];
		if (!this.CanLoadModel)
		{
			Singleton<UiModelUtil>.Instance.SetVisible(uiModelBase, false);
			UiModelActorComponent uiModelActorComponent = uiModelBase.CheckGetComponent<UiModelActorComponent>();
			if (uiModelActorComponent == null)
			{
				return;
			}
			uiModelActorComponent.SetTransformByTag(transformByTag);
			return;
		}
		else
		{
			SkinConfig instance = ConfigBase<SkinConfig>.Instance;
			EFlySkinType currentFlySkinType = this.CurrentFlySkinType;
			FlySkinConfig flySkinConfig = this.SkinData.GetFlySkinConfig();
			string standAnimPath = flySkinConfig.StandAnim;
			string flySkinSpawnEffectId = instance.GetFlySkinSpawnEffectId(currentFlySkinType);
			string flySkinSpawnMaterialController = instance.GetFlySkinSpawnMaterialController(currentFlySkinType);
			string effectPath = EffectUtil.GetEffectPath(flySkinSpawnEffectId);
			string changeMaterialControllerPath = EffectUtil.GetEffectPath(flySkinSpawnMaterialController);
			List<string> extraResourceList = new List<string>
			{
				standAnimPath,
				effectPath,
				changeMaterialControllerPath
			};
			UiModelLoadComponent loadComponent = uiModelBase.CheckGetComponent<UiModelLoadComponent>();
			if (loadComponent == null)
			{
				return;
			}
			UiModelActorComponent uiModelActorComponent2 = uiModelBase.CheckGetComponent<UiModelActorComponent>();
			if (uiModelActorComponent2 != null)
			{
				uiModelActorComponent2.SetTransformByTag(transformByTag);
			}
			Action loadFinishCallBack = delegate()
			{
				SkeletalObserverHandle gliderObserver2 = this.GliderObserver;
				UiModelBase uiModelBase2 = (gliderObserver2 != null) ? gliderObserver2.Model : null;
				if (uiModelBase2 == null)
				{
					return;
				}
				Singleton<UiModelUtil>.Instance.SetVisible(uiModelBase2, true);
				UiModelLoadComponent loadComponent = loadComponent;
				UAnimationAsset uanimationAsset = ((loadComponent != null) ? loadComponent.GetLoadedResource(standAnimPath) : null) as UAnimationAsset;
				if (uanimationAsset == null)
				{
					Singleton<Log>.Instance.Error(ELogModule.UiCommon, ELogAuthor.CXJ, "[FlySkin] 商城飞行皮肤待机动画预加载失败", default(ReadOnlySpan<ValueTuple<string, object>>));
				}
				UiModelAnimationComponent uiModelAnimationComponent = uiModelBase2.CheckGetComponent<UiModelAnimationComponent>();
				if (uanimationAsset != null && uiModelAnimationComponent != null)
				{
					uiModelAnimationComponent.PlayAnimation(uanimationAsset, true);
				}
				UiModelRenderingMaterialComponent uiModelRenderingMaterialComponent = uiModelBase2.CheckGetComponent<UiModelRenderingMaterialComponent>();
				PD_CharacterControllerData_C pd_CharacterControllerData_C = loadComponent.GetLoadedResource(changeMaterialControllerPath) as PD_CharacterControllerData_C;
				if (pd_CharacterControllerData_C != null && uiModelRenderingMaterialComponent != null)
				{
					uiModelRenderingMaterialComponent.AddRenderingMaterialByData(pd_CharacterControllerData_C);
				}
				Singleton<UiModelUtil>.Instance.PlayEffectOnRoot(uiModelBase2, "GliderEffect");
			};
			loadComponent.LoadModelByModelId(flySkinConfig.ModelId, true, loadFinishCallBack, extraResourceList);
			return;
		}
	}

	// Token: 0x060159AC RID: 88492 RVA: 0x005FD74D File Offset: 0x005FB94D
	protected override void OnBeforeHide()
	{
		UiCameraInputComponent cameraInputComponent = this.CameraInputComponent;
		if (cameraInputComponent == null)
		{
			return;
		}
		cameraInputComponent.End();
	}

	// Token: 0x060159AD RID: 88493 RVA: 0x005FD75F File Offset: 0x005FB95F
	protected override void OnBeforeDestroy()
	{
		UiCameraManager.Get().DestroyUiCameraComponent(typeof(UiCameraControlRotationComponent));
		this.DestroyGliderObserver();
	}

	// Token: 0x060159AE RID: 88494 RVA: 0x005FD77B File Offset: 0x005FB97B
	private void DestroyGliderObserver()
	{
		Singleton<UiSceneManager>.Instance.DestroyGliderSkeletalHandle();
		this.GliderObserver = null;
	}

	// Token: 0x060159AF RID: 88495 RVA: 0x005FD78E File Offset: 0x005FB98E
	private void OnCloseView()
	{
		base.CloseMe(null);
	}

	// Token: 0x060159B0 RID: 88496 RVA: 0x005FD798 File Offset: 0x005FB998
	private void OnClickOnlyUiToggle(EToggleState toggleState)
	{
		bool state = base.GetItem(28).bIsUIActive;
		if (!state)
		{
			base.GetItem(28).SetUIActive(!state);
			base.PlaySequence("UiIn", delegate
			{
			}, true);
		}
		else
		{
			base.PlaySequence("UiOut", delegate
			{
				if (this.IsDestroyOrDestroying)
				{
					return;
				}
				this.GetItem(28).SetUIActive(!state);
			}, true);
		}
		UUIItem item = base.GetItem(46);
		if (item != null)
		{
			item.SetUIActive(state);
		}
		this.CameraInputComponent.CanCameraInput = state;
		this.TryPushCamera();
	}

	// Token: 0x060159B1 RID: 88497 RVA: 0x005FD858 File Offset: 0x005FBA58
	[NullableContext(1)]
	private void OnActivateUiCameraAnimationHandle(UiCameraHandleData handleData)
	{
		if (handleData.HandleName == this.WaitCameraId)
		{
			this.WaitCameraId = null;
			if (!this.CanLoadModel)
			{
				this.CanLoadModel = true;
				this.TryLoadModel();
			}
		}
	}

	// Token: 0x060159B2 RID: 88498 RVA: 0x005FD889 File Offset: 0x005FBA89
	private void OnClickedHelpButton()
	{
		ControllerBase<HelpController>.Instance.OpenHelpById(318);
	}

	// Token: 0x0400A61F RID: 42527
	private FlySkinData SkinData;

	// Token: 0x0400A620 RID: 42528
	private EFlySkinType CurrentFlySkinType = EFlySkinType.Paragliding;

	// Token: 0x0400A621 RID: 42529
	private SkeletalObserverHandle GliderObserver;

	// Token: 0x0400A622 RID: 42530
	[Nullable(1)]
	public UiCameraInputComponent CameraInputComponent = new UiCameraInputComponent();

	// Token: 0x0400A623 RID: 42531
	private string WaitCameraId;

	// Token: 0x0400A624 RID: 42532
	private PopupCaptionItem CaptionItem;

	// Token: 0x0400A625 RID: 42533
	private bool CanLoadModel;

	// Token: 0x02008DAE RID: 36270
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402FA8C RID: 195212
		CaptionItem,
		// Token: 0x0402FA8D RID: 195213
		OnlyUiToggle,
		// Token: 0x0402FA8E RID: 195214
		DetailIconButton,
		// Token: 0x0402FA8F RID: 195215
		ButtonLeft,
		// Token: 0x0402FA90 RID: 195216
		ButtonRight,
		// Token: 0x0402FA91 RID: 195217
		TitleText,
		// Token: 0x0402FA92 RID: 195218
		SubTitleText,
		// Token: 0x0402FA93 RID: 195219
		SwitchItem,
		// Token: 0x0402FA94 RID: 195220
		ToggleLeft,
		// Token: 0x0402FA95 RID: 195221
		ExtraRewardItem,
		// Token: 0x0402FA96 RID: 195222
		ExtraRewardContentHorizontalLayout,
		// Token: 0x0402FA97 RID: 195223
		RewardItem,
		// Token: 0x0402FA98 RID: 195224
		DescText,
		// Token: 0x0402FA99 RID: 195225
		NotHaveRoleItem,
		// Token: 0x0402FA9A RID: 195226
		BuyItemIcon,
		// Token: 0x0402FA9B RID: 195227
		NowPrice,
		// Token: 0x0402FA9C RID: 195228
		BeforePrice,
		// Token: 0x0402FA9D RID: 195229
		BuyButton,
		// Token: 0x0402FA9E RID: 195230
		DiscountItem,
		// Token: 0x0402FA9F RID: 195231
		DiscountText,
		// Token: 0x0402FAA0 RID: 195232
		LeftTimeItem,
		// Token: 0x0402FAA1 RID: 195233
		LeftTimeText,
		// Token: 0x0402FAA2 RID: 195234
		QualityTexture,
		// Token: 0x0402FAA3 RID: 195235
		ItemTexture,
		// Token: 0x0402FAA4 RID: 195236
		FrameTexture,
		// Token: 0x0402FAA5 RID: 195237
		WeaponRootItem,
		// Token: 0x0402FAA6 RID: 195238
		WeaponTexture,
		// Token: 0x0402FAA7 RID: 195239
		HaveItem,
		// Token: 0x0402FAA8 RID: 195240
		HideUiParentItem,
		// Token: 0x0402FAA9 RID: 195241
		DragComponent,
		// Token: 0x0402FAAA RID: 195242
		WeaponQualityTexture,
		// Token: 0x0402FAAB RID: 195243
		ToggleRight,
		// Token: 0x0402FAAC RID: 195244
		EffectItemB,
		// Token: 0x0402FAAD RID: 195245
		EffectItemA,
		// Token: 0x0402FAAE RID: 195246
		TextureToggleLeft,
		// Token: 0x0402FAAF RID: 195247
		TextToggleLeft,
		// Token: 0x0402FAB0 RID: 195248
		TextureToggleRight,
		// Token: 0x0402FAB1 RID: 195249
		TextToggleRight,
		// Token: 0x0402FAB2 RID: 195250
		ItemGamePadKeyTipA = 45,
		// Token: 0x0402FAB3 RID: 195251
		ItemGamePadKeyTipB,
		// Token: 0x0402FAB4 RID: 195252
		ToggleLayout,
		// Token: 0x0402FAB5 RID: 195253
		ToggleMale,
		// Token: 0x0402FAB6 RID: 195254
		ToggleFemale,
		// Token: 0x0402FAB7 RID: 195255
		ExtraRewardText,
		// Token: 0x0402FAB8 RID: 195256
		ItemBuyPanel
	}
}
