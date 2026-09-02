using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using AkiClient.Game.Aki.Character.BaseSeqCharacter;
using AkiClient.Game.Aki.Character.Role.Common.Data.Enum;
using AkiClient.Game.Aki.Data.GaCha.Struct;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.Npc;
using AkiClient.Game.Aki.Scene.NewGacha.BP;
using CSharpScript.Core.Common;
using CSharpScript.Game.Camera;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.BlackScreen;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Render;
using CSharpScript.Game.Ui;
using CSharpScript.Game.Utils;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001D06 RID: 7430
[NullableContext(2)]
[Nullable(0)]
public class GachaScanView : GachaSceneView
{
	// Token: 0x0600DA24 RID: 55844 RVA: 0x003A892D File Offset: 0x003A6B2D
	[NullableContext(1)]
	public GachaScanView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600DA25 RID: 55845 RVA: 0x003A8953 File Offset: 0x003A6B53
	[NullableContext(1)]
	private global::GachaResult GetCurResult()
	{
		return this.GachaResult[this.CurIndex];
	}

	// Token: 0x0600DA26 RID: 55846 RVA: 0x003A8962 File Offset: 0x003A6B62
	private global::GachaResult GetLastResult()
	{
		if (this.LastIndex < 0)
		{
			return null;
		}
		return this.GachaResult[this.LastIndex];
	}

	// Token: 0x0600DA27 RID: 55847 RVA: 0x003A897C File Offset: 0x003A6B7C
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUITexture)),
			new ValueTuple<int, Type>(5, typeof(UUITexture)),
			new ValueTuple<int, Type>(6, typeof(UUIHorizontalLayout)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIItem)),
			new ValueTuple<int, Type>(9, typeof(UUIItem)),
			new ValueTuple<int, Type>(10, typeof(UUIItem)),
			new ValueTuple<int, Type>(11, typeof(UUIItem)),
			new ValueTuple<int, Type>(12, typeof(UUIItem)),
			new ValueTuple<int, Type>(13, typeof(UUIItem)),
			new ValueTuple<int, Type>(14, typeof(UUIItem)),
			new ValueTuple<int, Type>(15, typeof(UUITexture)),
			new ValueTuple<int, Type>(16, typeof(UUIText)),
			new ValueTuple<int, Type>(18, typeof(UUIItem)),
			new ValueTuple<int, Type>(19, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(20, typeof(UUIItem)),
			new ValueTuple<int, Type>(21, typeof(UUIItem)),
			new ValueTuple<int, Type>(22, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action(this.SkipBtn)),
			new ValueTuple<int, Delegate>(1, new Action(this.NextBtn)),
			new ValueTuple<int, Delegate>(19, new Action(this.ShareBtn))
		};
	}

	// Token: 0x0600DA28 RID: 55848 RVA: 0x003A8BDC File Offset: 0x003A6DDC
	protected override UniTask OnBeforeStartAsync()
	{
		GachaScanView.<OnBeforeStartAsync>d__41 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<GachaScanView.<OnBeforeStartAsync>d__41>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600DA29 RID: 55849 RVA: 0x003A8C20 File Offset: 0x003A6E20
	protected override void OnAfterOpenUiScene()
	{
		this.SceneCamera = UKuroCollectActorComponent.GetActorWithTag(FNameUtil.GetDynamicFName("SceneCamera1").Value, ECollectActorType.Default);
		this.CameraEffect = (UKuroCollectActorComponent.GetActorWithTag(FNameUtil.GetDynamicFName("Flash1").Value, ECollectActorType.Default) as ANiagaraActor);
		this.EffectGold = (UKuroCollectActorComponent.GetActorWithTag(FNameUtil.GetDynamicFName("BurstGold").Value, ECollectActorType.Default) as ANiagaraActor);
		this.EffectPurple = (UKuroCollectActorComponent.GetActorWithTag(FNameUtil.GetDynamicFName("BurstPurple").Value, ECollectActorType.Default) as ANiagaraActor);
		this.EffectWhite = (UKuroCollectActorComponent.GetActorWithTag(FNameUtil.GetDynamicFName("BurstWhite").Value, ECollectActorType.Default) as ANiagaraActor);
		this.UpdateInteractBP = (UKuroCollectActorComponent.GetActorWithTag(FNameUtil.GetDynamicFName("UpdateInteractBP").Value, ECollectActorType.Default) as BP_UpdateInteract_C);
		if (this.UpdateInteractBP != null)
		{
			this.UpdateInteractBP.SetTickableWhenPaused(true);
		}
		if (this.CameraEffect != null && this.SceneCamera != null)
		{
			this.CameraEffect.K2_AttachToActor(this.SceneCamera, null, EAttachmentRule.SnapToTarget, EAttachmentRule.SnapToTarget, EAttachmentRule.SnapToTarget, false, true);
		}
		if (this.EffectGold != null && this.SceneCamera != null)
		{
			this.EffectGold.K2_AttachToActor(this.SceneCamera, null, EAttachmentRule.SnapToTarget, EAttachmentRule.SnapToTarget, EAttachmentRule.SnapToTarget, false, true);
		}
		if (this.EffectPurple != null && this.SceneCamera != null)
		{
			this.EffectPurple.K2_AttachToActor(this.SceneCamera, null, EAttachmentRule.SnapToTarget, EAttachmentRule.SnapToTarget, EAttachmentRule.SnapToTarget, false, true);
		}
		if (this.EffectWhite != null && this.SceneCamera != null)
		{
			this.EffectWhite.K2_AttachToActor(this.SceneCamera, null, EAttachmentRule.SnapToTarget, EAttachmentRule.SnapToTarget, EAttachmentRule.SnapToTarget, false, true);
		}
		FVectorDouble newRelativeLocation = new FVectorDouble(200.0, 0.0, 0.0);
		FVectorDouble newRelativeLocation2 = new FVectorDouble(60.0, 0.0, 0.0);
		FRotator newRelativeRotation = new FRotator(0f, 90f, 0f);
		FHitResult fhitResult = new FHitResult();
		FHitResult fhitResult2 = new FHitResult();
		if (this.CameraEffect != null)
		{
			this.CameraEffect.D_K2_SetActorRelativeLocation(newRelativeLocation2, false, ref fhitResult, false);
			this.CameraEffect.K2_SetActorRelativeRotation(newRelativeRotation, false, ref fhitResult2, false);
		}
		if (this.EffectGold != null)
		{
			this.EffectGold.D_K2_SetActorRelativeLocation(newRelativeLocation, false, ref fhitResult, false);
			this.EffectGold.K2_SetActorRelativeRotation(newRelativeRotation, false, ref fhitResult2, false);
		}
		if (this.EffectPurple != null)
		{
			this.EffectPurple.D_K2_SetActorRelativeLocation(newRelativeLocation, false, ref fhitResult, false);
			this.EffectPurple.K2_SetActorRelativeRotation(newRelativeRotation, false, ref fhitResult2, false);
		}
		if (this.EffectWhite != null)
		{
			this.EffectWhite.D_K2_SetActorRelativeLocation(newRelativeLocation, false, ref fhitResult, false);
			this.EffectWhite.K2_SetActorRelativeRotation(newRelativeRotation, false, ref fhitResult2, false);
		}
	}

	// Token: 0x0600DA2A RID: 55850 RVA: 0x003A8ECC File Offset: 0x003A70CC
	private void HideBackgroundEffects()
	{
		ANiagaraActor effectGold = this.EffectGold;
		if (effectGold != null)
		{
			effectGold.SetActorHiddenInGame(true);
		}
		ANiagaraActor effectPurple = this.EffectPurple;
		if (effectPurple != null)
		{
			effectPurple.SetActorHiddenInGame(true);
		}
		ANiagaraActor effectWhite = this.EffectWhite;
		if (effectWhite != null)
		{
			effectWhite.SetActorHiddenInGame(true);
		}
		ANiagaraActor effectGold2 = this.EffectGold;
		if (effectGold2 != null)
		{
			UNiagaraComponent niagaraComponent = effectGold2.NiagaraComponent;
			if (niagaraComponent != null)
			{
				niagaraComponent.Deactivate();
			}
		}
		ANiagaraActor effectPurple2 = this.EffectPurple;
		if (effectPurple2 != null)
		{
			UNiagaraComponent niagaraComponent2 = effectPurple2.NiagaraComponent;
			if (niagaraComponent2 != null)
			{
				niagaraComponent2.Deactivate();
			}
		}
		ANiagaraActor effectWhite2 = this.EffectWhite;
		if (effectWhite2 == null)
		{
			return;
		}
		UNiagaraComponent niagaraComponent3 = effectWhite2.NiagaraComponent;
		if (niagaraComponent3 == null)
		{
			return;
		}
		niagaraComponent3.Deactivate();
	}

	// Token: 0x0600DA2B RID: 55851 RVA: 0x003A8F64 File Offset: 0x003A7164
	private void InitProduct()
	{
		this.ConvertItem = new SmallItemGrid();
		this.ConvertItem.Initialize(base.GetItem(8).GetOwner());
		this.ExtraItem = new SmallItemGrid();
		this.ExtraItem.Initialize(base.GetItem(10).GetOwner());
	}

	// Token: 0x0600DA2C RID: 55852 RVA: 0x003A8FB8 File Offset: 0x003A71B8
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<string>(EEventName.PlaySequenceEventByStringParam, new Action<string>(this.OnSequenceEventByStringParam));
		Singleton<EventSystem>.Instance.Add(EEventName.OnFirstShare, new Action(this.RefreshShare));
		Singleton<EventSystem>.Instance.Add<string>(EEventName.OnActivitySequenceEmitEvent, new Action<string>(this.OnActivitySequenceEmitEvent));
	}

	// Token: 0x0600DA2D RID: 55853 RVA: 0x003A901C File Offset: 0x003A721C
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.PlaySequenceEventByStringParam, new Action<string>(this.OnSequenceEventByStringParam));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnFirstShare, new Action(this.RefreshShare));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnActivitySequenceEmitEvent, new Action<string>(this.OnActivitySequenceEmitEvent));
	}

	// Token: 0x0600DA2E RID: 55854 RVA: 0x003A9080 File Offset: 0x003A7280
	protected void Refresh()
	{
		this.HideBackgroundEffects();
		GachaReward proto_GachaReward = this.GetCurResult().Proto_GachaReward;
		int num = (proto_GachaReward != null) ? proto_GachaReward.ItemId : 0;
		if (num <= 0)
		{
			Singleton<Log>.Instance.Error(ELogModule.Gacha, ELogAuthor.LZK, "抽卡获得物品为空", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		GachaDefine.EItemQuality gachaQuality = ModelBase<GachaModel>.Instance.GetGachaQuality(num);
		if (gachaQuality == GachaDefine.EItemQuality.Blue)
		{
			Singleton<AudioSystem>.Instance.SetState("ui_gacha_quality", "normal", true);
		}
		else if (gachaQuality == GachaDefine.EItemQuality.Purple)
		{
			Singleton<AudioSystem>.Instance.SetState("ui_gacha_quality", "purple", true);
		}
		else if (gachaQuality == GachaDefine.EItemQuality.Gold)
		{
			Singleton<AudioSystem>.Instance.SetState("ui_gacha_quality", "golden", true);
		}
		Singleton<AudioSystem>.Instance.PostEvent("ui_gacha_scan_next");
		if (gachaQuality != GachaDefine.EItemQuality.Gold)
		{
			this.AfterFiveStarAnimation();
			return;
		}
		base.GetItem(12).SetUIActive(true);
		LevelSequencePlayer fiveStarLevelSequencePlayer = this.FiveStarLevelSequencePlayer;
		if (fiveStarLevelSequencePlayer == null)
		{
			return;
		}
		fiveStarLevelSequencePlayer.PlayLevelSequenceByName("Start", true, null, false);
	}

	// Token: 0x0600DA2F RID: 55855 RVA: 0x003A9174 File Offset: 0x003A7374
	private void RefreshShare()
	{
		bool flag = this.CurQuality >= 5 && ControllerBase<ChannelController>.Instance.CouldShare();
		UUIItem item = base.GetItem(18);
		if (item != null)
		{
			item.SetUIActive(flag);
		}
		if (flag)
		{
			ShareReward? config = ConfigShareRewardById.GetConfig((ConfigBase<GachaConfig>.Instance.GetItemIdType(this.GetCurResult().Proto_GachaReward.ItemId) == InventoryDefine.EItemDataType.WeaponItem) ? 4 : 3, true);
			if (config == null)
			{
				return;
			}
			bool flag2 = ModelBase<ChannelModel>.Instance.CouldGetShareReward((EShareActionId)config.Value.Id);
			UUIItem item2 = base.GetItem(20);
			if (item2 != null)
			{
				item2.SetUIActive(flag2);
			}
			if (flag2)
			{
				List<ValueTuple<int, int>> list = new List<ValueTuple<int, int>>();
				foreach (KeyValuePair<int, int> keyValuePair in config.Value.Reward())
				{
					list.Add(new ValueTuple<int, int>(keyValuePair.Key, keyValuePair.Value));
				}
				ValueTuple<int, int> valueTuple = list[0];
				ShareRewardInfo shareRewardInfo = this.ShareRewardInfo;
				if (shareRewardInfo == null)
				{
					return;
				}
				shareRewardInfo.SetItemInfo(valueTuple.Item1, valueTuple.Item2);
			}
		}
	}

	// Token: 0x0600DA30 RID: 55856 RVA: 0x003A92AC File Offset: 0x003A74AC
	protected void AfterFiveStarAnimation()
	{
		this.RefreshModel();
		this.RefreshView();
		this.RefreshShare();
	}

	// Token: 0x0600DA31 RID: 55857 RVA: 0x003A92C0 File Offset: 0x003A74C0
	protected unsafe void RefreshView()
	{
		global::GachaResult curResult = this.GetCurResult();
		int itemId = curResult.Proto_GachaReward.ItemId;
		InventoryDefine.EItemDataType itemIdType = ConfigBase<GachaConfig>.Instance.GetItemIdType(curResult.Proto_GachaReward.ItemId);
		CSharpScript.Game.Module.Inventory.ItemConfig itemConfigData = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(itemId);
		if (itemConfigData == null)
		{
			return;
		}
		RoleInfo? roleInfo = null;
		LevelSequencePlayer uiLevelSequencePlayer = this.UiLevelSequencePlayer;
		if (uiLevelSequencePlayer != null)
		{
			uiLevelSequencePlayer.StopSequenceByKey("Show", false, false);
		}
		LevelSequencePlayer uiLevelSequencePlayer2 = this.UiLevelSequencePlayer;
		if (uiLevelSequencePlayer2 != null)
		{
			uiLevelSequencePlayer2.StopSequenceByKey("ConvertShow", false, false);
		}
		base.GetItem(13).SetAlpha(0f);
		base.GetItem(22).SetAlpha(0f);
		base.GetItem(18).GetParentAsUIItem().SetUIActive(false);
		int qualityId;
		if (itemIdType != InventoryDefine.EItemDataType.RoleItem)
		{
			if (itemIdType != InventoryDefine.EItemDataType.WeaponItem)
			{
			}
			base.GetItem(3).SetUIActive(true);
			WeaponConf? weaponConfigByItemId = ConfigBase<WeaponConfig>.Instance.GetWeaponConfigByItemId(itemId);
			if (weaponConfigByItemId == null)
			{
				return;
			}
			GachaWeaponTransform? gachaWeaponTransformConfig = ConfigBase<GachaConfig>.Instance.GetGachaWeaponTransformConfig(weaponConfigByItemId.Value.WeaponType);
			if (gachaWeaponTransformConfig != null)
			{
				base.SetTextureByPath(gachaWeaponTransformConfig.Value.WeaponTypeTexture, base.GetTexture(4), null, null);
			}
			FVector uiitemScale = new FVector(0.8f, 0.8f, 0.8f);
			base.GetTexture(4).SetUIItemScale(uiitemScale);
			base.GetTexture(4).SetColor(ColorUtils.ColorWhile);
			qualityId = itemConfigData.QualityId;
			base.GetText(2).ShowTextNew(itemConfigData.Name);
		}
		else
		{
			base.GetItem(3).SetUIActive(true);
			RoleInfo? roleInfoById = ConfigBase<GachaConfig>.Instance.GetRoleInfoById(itemId);
			if (roleInfoById == null)
			{
				return;
			}
			roleInfo = new RoleInfo?(roleInfoById.Value);
			qualityId = roleInfo.Value.QualityId;
			int elementId = roleInfo.Value.ElementId;
			ElementInfo? elementConfig = ConfigBase<CommonConfig>.Instance.GetElementConfig(elementId);
			if (elementConfig != null)
			{
				base.GetTexture(5).SetColor(FColor.FromHex(elementConfig.Value.ElementColor));
				UUITexture texture = base.GetTexture(4);
				base.SetTextureByPath(elementConfig.Value.Icon, texture, null, null);
				FColor color = FColor.FromHex(elementConfig.Value.ElementColor);
				texture.SetColor(color);
			}
			base.GetText(2).ShowTextNew(roleInfo.Value.Name);
		}
		bool flag = qualityId == 5 || (qualityId == 4 && curResult.IsNew);
		base.GetButton(0).RootUIComp.Get().SetUIActive(!flag);
		this.StarLayout.RebuildLayout(qualityId);
		IReadOnlyList<GachaReward> proto_TransformRewards = curResult.Proto_TransformRewards;
		UUIItem item = base.GetItem(11);
		if (item != null)
		{
			item.SetUIActive(curResult.IsNew);
		}
		base.GetItem(7).SetUIActive(proto_TransformRewards != null && proto_TransformRewards.Count > 0);
		if (curResult.Proto_TransformRewards != null && curResult.Proto_TransformRewards.Count > 0)
		{
			this.ConvertItem.SetActive(true);
			GachaReward reward = curResult.Proto_TransformRewards[0];
			PropSmallItemGrid parameters = new PropSmallItemGrid
			{
				ItemConfigId = new int?(reward.ItemId),
				BottomText = reward.ItemCount.ToString(),
				Data = null
			};
			this.ConvertItem.Apply<PropSmallItemGrid>(parameters);
			this.ConvertItem.BindOnCanExecuteChange((object _1, bool _2, EToggleState _3) => false);
			this.ConvertItem.BindOnExtendToggleRelease(delegate(MediumItemGridExtendCallback _)
			{
				ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(reward.ItemId, true, null);
			});
		}
		else
		{
			this.ConvertItem.SetActive(false);
		}
		IReadOnlyList<GachaReward> proto_ExtraRewards = curResult.Proto_ExtraRewards;
		base.GetItem(9).SetUIActive(((proto_ExtraRewards != null) ? proto_ExtraRewards.Count : 0) > 0);
		if (proto_ExtraRewards != null && proto_ExtraRewards.Count > 0)
		{
			this.ExtraItem.SetActive(true);
			GachaReward reward = proto_ExtraRewards[0];
			PropSmallItemGrid parameters2 = new PropSmallItemGrid
			{
				ItemConfigId = new int?(reward.ItemId),
				BottomText = reward.ItemCount.ToString(),
				Data = null
			};
			this.ExtraItem.Apply<PropSmallItemGrid>(parameters2);
			this.ExtraItem.BindOnCanExecuteChange((object _1, bool _2, EToggleState _3) => false);
			this.ExtraItem.BindOnExtendToggleRelease(delegate(MediumItemGridExtendCallback _)
			{
				ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(reward.ItemId, true, null);
			});
		}
		else
		{
			this.ExtraItem.SetActive(false);
		}
		if (((proto_ExtraRewards != null) ? proto_ExtraRewards.Count : 0) > 1)
		{
			GachaReward gachaReward = proto_ExtraRewards[1];
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Gacha;
			ELogAuthor author = ELogAuthor.ZJC;
			string message = "转换奖励只能有一个!, 请检查配置表";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("itemId", gachaReward.ItemId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("itemCount", gachaReward.ItemCount);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		}
		GachaReward proto_BottomExtraReward = curResult.Proto_BottomExtraReward;
		base.GetItem(14).GetParentAsUIItem().SetUIActive(false);
		if (proto_BottomExtraReward != null && proto_BottomExtraReward.ItemId > 0 && proto_BottomExtraReward.ItemCount > 0)
		{
			base.SetItemIcon(base.GetTexture(15), proto_BottomExtraReward.ItemId, null, null);
			UUIText text = base.GetText(16);
			if (text != null)
			{
				text.SetText(proto_BottomExtraReward.ItemCount.ToString(), true);
			}
			base.GetItem(14).SetUIActive(true);
			return;
		}
		base.GetItem(14).SetUIActive(false);
	}

	// Token: 0x0600DA32 RID: 55858 RVA: 0x003A98B8 File Offset: 0x003A7AB8
	protected void RefreshModel()
	{
		global::GachaResult lastResult = this.GetLastResult();
		if (lastResult != null)
		{
			int itemId = lastResult.Proto_GachaReward.ItemId;
			InventoryDefine.EItemDataType itemIdType = ConfigBase<GachaConfig>.Instance.GetItemIdType(itemId);
			if (itemIdType != InventoryDefine.EItemDataType.RoleItem)
			{
				if (itemIdType == InventoryDefine.EItemDataType.WeaponItem)
				{
					this.HideWeaponObserver();
				}
			}
			else
			{
				this.HideRoleSequence();
			}
		}
		global::GachaResult curResult = this.GetCurResult();
		if (curResult != null)
		{
			int itemId2 = curResult.Proto_GachaReward.ItemId;
			GachaTextureInfo? gachaTextureInfo = ConfigBase<GachaConfig>.Instance.GetGachaTextureInfo(itemId2);
			if (gachaTextureInfo == null)
			{
				return;
			}
			string gachaSequencePath = ModelBase<GachaModel>.Instance.GetGachaSequencePath(itemId2);
			InventoryDefine.EItemDataType itemIdType2 = ConfigBase<GachaConfig>.Instance.GetItemIdType(itemId2);
			ULevelSequence loadedSequence = ModelBase<GachaModel>.Instance.GetLoadedSequence(gachaSequencePath);
			Singleton<GameSettingsDeviceRender>.Instance.TemporaryDisableFrameGeneration("RefreshModel");
			UKuroSequencePerformanceManager.OpenKuroPerformanceMode(loadedSequence);
			this.DestroySequence();
			ControllerBase<CameraController>.Instance.SetViewTarget(this.SceneCamera, "GachaScanView.RefreshModel", 0f, EViewTargetBlendFunction.VTBlend_Linear, 0f, null, null, "MainCamera", null, null);
			FMovieSceneSequencePlaybackSettings fmovieSceneSequencePlaybackSettings = new FMovieSceneSequencePlaybackSettings();
			fmovieSceneSequencePlaybackSettings.bRestoreState = true;
			fmovieSceneSequencePlaybackSettings.bPauseAtEnd = true;
			this.SequenceActor = (Singleton<ActorSystem>.Instance.Spawn(ALevelSequenceActor.StaticClass(), Singleton<MathUtils>.Instance.DefaultTransformDouble, null) as ALevelSequenceActor);
			if (this.SequenceActor == null)
			{
				return;
			}
			this.SequenceActor.PlaybackSettings = fmovieSceneSequencePlaybackSettings;
			this.LevelSequencePlayer = this.SequenceActor.SequencePlayer;
			this.SequenceActor.SetSequence(loadedSequence);
			UKuroSequenceRuntimeFunctionLibrary.SetSequenceInUiScene(loadedSequence, true);
			this.SequenceActor.SetTickableWhenPaused(true);
			this.SequenceActor.AddBindingByTag(GachaScanView.SCENE_CAMERA_TAG, this.SceneCamera, false, true);
			if (ControllerBase<RenderModuleController>.Instance.DebugNewUiSceneWorkflow)
			{
				if (gachaTextureInfo.Value.BindPoint != null && gachaTextureInfo.Value.BindPoint.Length > 0)
				{
					this.SequenceActor.bOverrideInstanceData = true;
					UDefaultLevelSequenceInstanceData udefaultLevelSequenceInstanceData = this.SequenceActor.DefaultInstanceData as UDefaultLevelSequenceInstanceData;
					if (udefaultLevelSequenceInstanceData != null)
					{
						udefaultLevelSequenceInstanceData.TransformOriginActor = UKuroCollectActorComponent.GetActorWithTag(FNameUtil.GetDynamicFName(gachaTextureInfo.Value.BindPoint).Value, ECollectActorType.UI);
					}
				}
				else
				{
					this.SequenceActor.bOverrideInstanceData = true;
					UDefaultLevelSequenceInstanceData udefaultLevelSequenceInstanceData2 = this.SequenceActor.DefaultInstanceData as UDefaultLevelSequenceInstanceData;
					if (udefaultLevelSequenceInstanceData2 != null)
					{
						AActor actorWithTag = UKuroCollectActorComponent.GetActorWithTag(FNameUtil.GetDynamicFName("KuroUiSceneRoot").Value, ECollectActorType.UI);
						if (actorWithTag != null)
						{
							FTransform transformOrigin = UKismetMathLibrary.Conv_TransformDoubleToTransform(actorWithTag.D_GetTransform());
							udefaultLevelSequenceInstanceData2.TransformOrigin = transformOrigin;
						}
					}
				}
			}
			else if (gachaTextureInfo.Value.BindPoint != null && gachaTextureInfo.Value.BindPoint.Length > 0)
			{
				this.SequenceActor.bOverrideInstanceData = true;
				UDefaultLevelSequenceInstanceData udefaultLevelSequenceInstanceData3 = this.SequenceActor.DefaultInstanceData as UDefaultLevelSequenceInstanceData;
				if (udefaultLevelSequenceInstanceData3 != null)
				{
					udefaultLevelSequenceInstanceData3.TransformOriginActor = UKuroCollectActorComponent.GetActorWithTag(FNameUtil.GetDynamicFName(gachaTextureInfo.Value.BindPoint).Value, ECollectActorType.UI);
				}
			}
			TArray<UObject> bindingByTagInTemplate = this.SequenceActor.GetBindingByTagInTemplate(GachaScanView.SCENE_ROLE_TAG, true);
			int num = bindingByTagInTemplate.Num();
			for (int i = 0; i < num; i++)
			{
				AActor aactor = bindingByTagInTemplate.Get(i) as AActor;
				if (aactor != null)
				{
					TArray<UActorComponent> tarray = aactor.K2_GetComponentsByClass(USkeletalMeshComponent.StaticClass());
					int num2 = tarray.Num();
					for (int j = 0; j < num2; j++)
					{
						UActorComponent uactorComponent = tarray.Get(j);
						if (uactorComponent != null)
						{
							uactorComponent.SetTickableWhenPaused(true);
						}
					}
					if (num2 == 0)
					{
						ASkeletalMeshActor askeletalMeshActor = aactor as ASkeletalMeshActor;
						if (askeletalMeshActor != null)
						{
							USkeletalMeshComponent skeletalMeshComponent = askeletalMeshActor.SkeletalMeshComponent;
							if (skeletalMeshComponent != null)
							{
								skeletalMeshComponent.SetTickableWhenPaused(true);
							}
						}
					}
					if (aactor is BP_BaseRole_Seq_V2_C)
					{
						aactor.SetTickableWhenPaused(true);
						aactor.PrimaryActorTick.bTickEvenWhenPaused = true;
					}
					BP_NpcCombinedMesh_C bp_NpcCombinedMesh_C = aactor as BP_NpcCombinedMesh_C;
					if (bp_NpcCombinedMesh_C != null)
					{
						bp_NpcCombinedMesh_C.SetTickableWhenPaused(true);
						bp_NpcCombinedMesh_C.SetSkelTickableWhenPaused(true);
						bp_NpcCombinedMesh_C.PrimaryActorTick.bTickEvenWhenPaused = true;
					}
				}
			}
			this.IsCanContinue = false;
			if (itemIdType2 == InventoryDefine.EItemDataType.RoleItem)
			{
				this.LevelSequencePlayer.OnPause.Add(delegate()
				{
					this.IsCanContinue = true;
				});
				FFrameTime time = this.LevelSequencePlayer.GetStartTime().Time;
				this.LevelSequencePlayer.PlayTo(new FMovieSceneSequencePlaybackParams(time, 0f, "A", EMovieScenePositionType.MarkedFrame, EUpdatePositionMethod.Play));
			}
			else
			{
				this.LevelSequencePlayer.OnPause.Add(delegate()
				{
					if (!this.IsWeaponToEnd)
					{
						this.IsWeaponToEnd = true;
						ULevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
						if (levelSequencePlayer == null)
						{
							return;
						}
						levelSequencePlayer.Play();
					}
				});
				this.IsWeaponToEnd = false;
				FFrameTime time2 = this.LevelSequencePlayer.GetStartTime().Time;
				this.LevelSequencePlayer.PlayTo(new FMovieSceneSequencePlaybackParams(time2, 0f, "A", EMovieScenePositionType.MarkedFrame, EUpdatePositionMethod.Play));
			}
			PersonalUtil.ApplyTickableWhenPausedOnRuntimeBindings(this.SequenceActor, true);
			if (this.PlayUiSequenceTimerId != null)
			{
				TimerSystem.GameplayTimeInstance.Remove(this.PlayUiSequenceTimerId);
				this.PlayUiSequenceTimerId = null;
			}
			int beforeEndFrame = 120;
			switch (itemIdType2)
			{
			case InventoryDefine.EItemDataType.RoleItem:
			{
				RoleInfo? roleInfoById = ConfigBase<GachaConfig>.Instance.GetRoleInfoById(itemId2);
				if (roleInfoById != null)
				{
					this.CurQuality = roleInfoById.Value.QualityId;
				}
				beforeEndFrame = this.RoleBeforeEndFrame;
				this.ShowRole();
				break;
			}
			case InventoryDefine.EItemDataType.WeaponItem:
			{
				this.ShowItemObserver(itemId2);
				WeaponConf? weaponConfigByItemId = ConfigBase<WeaponConfig>.Instance.GetWeaponConfigByItemId(itemId2);
				if (weaponConfigByItemId != null)
				{
					this.CurQuality = weaponConfigByItemId.Value.QualityId;
				}
				beforeEndFrame = ModelBase<GachaModel>.Instance.GetGachaSequenceEndFrame(itemId2);
				break;
			}
			}
			this.UiLevelSequencePlayer.StopSequenceByKey("Show", false, false);
			this.PlayUiSequenceTimerId = TimerSystem.GameplayTimeInstance.Forever(delegate(float _)
			{
				int value = this.LevelSequencePlayer.GetCurrentTime().Time.FrameNumber.Value;
				if (this.LevelSequencePlayer.GetEndTime().Time.FrameNumber.Value - value < beforeEndFrame)
				{
					this.UiLevelSequencePlayer.PlayLevelSequenceByName("Show", false, null, false);
					TimerSystem.GameplayTimeInstance.Remove(this.PlayUiSequenceTimerId);
					this.PlayUiSequenceTimerId = null;
				}
			}, 100f, 1f, null, null, true);
		}
	}

	// Token: 0x0600DA33 RID: 55859 RVA: 0x003A9E80 File Offset: 0x003A8080
	private void HideWeaponObserver()
	{
		SkeletalObserverHandle gachaItemObserver = this.GachaItemObserver;
		UiModelBase uiModelBase = (gachaItemObserver != null) ? gachaItemObserver.Model : null;
		SkeletalObserverHandle gachaWeaponScabbardObserver = this.GachaWeaponScabbardObserver;
		UiModelBase uiModelBase2 = (gachaWeaponScabbardObserver != null) ? gachaWeaponScabbardObserver.Model : null;
		if (uiModelBase != null)
		{
			Singleton<UiModelUtil>.Instance.SetVisible(uiModelBase, false);
		}
		if (uiModelBase2 != null)
		{
			Singleton<UiModelUtil>.Instance.SetVisible(uiModelBase2, false);
		}
		this.DestroySequence();
	}

	// Token: 0x0600DA34 RID: 55860 RVA: 0x003A9EDC File Offset: 0x003A80DC
	private void ShowRole()
	{
		int itemId = this.GetCurResult().Proto_GachaReward.ItemId;
		RoleInfo? roleInfoById = ConfigBase<GachaConfig>.Instance.GetRoleInfoById(itemId);
		if (roleInfoById == null)
		{
			return;
		}
		if (roleInfoById.Value.QualityId == 5)
		{
			BP_UpdateInteract_C updateInteractBP = this.UpdateInteractBP;
			if (updateInteractBP == null)
			{
				return;
			}
			updateInteractBP.UpdateGachaShowItem(roleInfoById.Value.Id, 4);
			return;
		}
		else
		{
			BP_UpdateInteract_C updateInteractBP2 = this.UpdateInteractBP;
			if (updateInteractBP2 == null)
			{
				return;
			}
			updateInteractBP2.UpdateGachaShowItem(roleInfoById.Value.Id, 3);
			return;
		}
	}

	// Token: 0x0600DA35 RID: 55861 RVA: 0x003A9F63 File Offset: 0x003A8163
	private void HideRoleSequence()
	{
		this.DestroySequence();
	}

	// Token: 0x0600DA36 RID: 55862 RVA: 0x003A9F6C File Offset: 0x003A816C
	private void DestroySequence()
	{
		if (this.LevelSequencePlayer != null)
		{
			this.LevelSequencePlayer.OnStop.Clear();
			this.LevelSequencePlayer.Stop();
			this.LevelSequencePlayer = null;
		}
		ALevelSequenceActor sequenceActor = this.SequenceActor;
		if (sequenceActor != null && sequenceActor.IsValid())
		{
			this.SequenceActor.ResetBindings();
			this.SequenceActor.SetSequence(null);
			this.SequenceActor.K2_DestroyActor();
			this.SequenceActor = null;
		}
	}

	// Token: 0x0600DA37 RID: 55863 RVA: 0x003A9FE0 File Offset: 0x003A81E0
	private void ShowItemObserver(int itemId)
	{
		if (ConfigBase<GachaConfig>.Instance.GetItemIdType(itemId) == InventoryDefine.EItemDataType.WeaponItem)
		{
			this.HandleWeapon(itemId);
		}
	}

	// Token: 0x0600DA38 RID: 55864 RVA: 0x003A9FF8 File Offset: 0x003A81F8
	private void HandleWeapon(int itemId)
	{
		GachaScanView.<>c__DisplayClass57_0 CS$<>8__locals1 = new GachaScanView.<>c__DisplayClass57_0();
		SkeletalObserverHandle gachaItemObserver = this.GachaItemObserver;
		if (gachaItemObserver == null)
		{
			return;
		}
		WeaponConf? weaponConfigByItemId = ConfigBase<WeaponConfig>.Instance.GetWeaponConfigByItemId(itemId);
		if (weaponConfigByItemId == null)
		{
			return;
		}
		SGachaWeaponTransform? value;
		CS$<>8__locals1.transformData = (DataTableUtil.TryGetDataTableRowStruct<SGachaWeaponTransform>(this.WeaponDataTable, itemId.ToString(), out value) ? value : ConfigBase<GachaConfig>.Instance.GetGachaWeaponTransformConfig(weaponConfigByItemId.Value.WeaponType));
		CS$<>8__locals1.weaponModel = gachaItemObserver.Model;
		if (CS$<>8__locals1.weaponModel == null)
		{
			return;
		}
		UiModelLoadComponent uiModelLoadComponent = CS$<>8__locals1.weaponModel.CheckGetComponent<UiModelLoadComponent>();
		CS$<>8__locals1.weaponActorComponent = CS$<>8__locals1.weaponModel.CheckGetComponent<UiModelActorComponent>();
		Action loadFinishCallBack = delegate()
		{
			if (CS$<>8__locals1.transformData == null || !CS$<>8__locals1.transformData.ShowScabbard)
			{
				Singleton<UiModelUtil>.Instance.SetVisible(CS$<>8__locals1.weaponModel, true);
			}
			AActor actorWithTag = UKuroCollectActorComponent.GetActorWithTag(FNameUtil.GetDynamicFName("WeaponCase").Value, ECollectActorType.UI);
			UiModelActorComponent weaponActorComponent = CS$<>8__locals1.weaponActorComponent;
			if (((weaponActorComponent != null) ? weaponActorComponent.Actor : null) != null && actorWithTag != null)
			{
				CS$<>8__locals1.weaponActorComponent.Actor.K2_AttachToActor(actorWithTag, null, EAttachmentRule.SnapToTarget, EAttachmentRule.SnapToTarget, EAttachmentRule.SnapToTarget, false, true);
			}
			if (CS$<>8__locals1.transformData != null)
			{
				global::Transform transform = global::Transform.Create();
				global::Vector rotation = CS$<>8__locals1.transformData.Rotation;
				global::Rotator rotator = global::Rotator.Create((float)rotation.Y, (float)rotation.Z, (float)rotation.X);
				float size = CS$<>8__locals1.transformData.Size;
				global::Vector vector = global::Vector.Create((double)size, (double)size, (double)size);
				transform.SetLocation(new FVector((float)CS$<>8__locals1.transformData.Location.X, (float)CS$<>8__locals1.transformData.Location.Y, (float)CS$<>8__locals1.transformData.Location.Z));
				transform.SetRotation(rotator.Quaternion(null));
				transform.SetScale3D(vector.ToUeVector(false));
				FHitResult fhitResult = new FHitResult();
				UiModelActorComponent weaponActorComponent2 = CS$<>8__locals1.weaponActorComponent;
				if (weaponActorComponent2 != null)
				{
					USkeletalMeshComponent mainMeshComponent = weaponActorComponent2.MainMeshComponent;
					if (mainMeshComponent != null)
					{
						FTransformDouble ftransformDouble = transform.ToUeTransform();
						mainMeshComponent.D_K2_SetRelativeTransform(ftransformDouble, false, ref fhitResult, false);
					}
				}
				UiModelRotateComponent uiModelRotateComponent = CS$<>8__locals1.weaponModel.CheckGetComponent<UiModelRotateComponent>();
				if (uiModelRotateComponent != null)
				{
					uiModelRotateComponent.SetRotateParam(CS$<>8__locals1.transformData.RotateTime, ERotateAxis.Yaw, true);
				}
				FRotator newRotation = new FRotator((float)CS$<>8__locals1.transformData.AxisRotate.Y, (float)CS$<>8__locals1.transformData.AxisRotate.Z, (float)CS$<>8__locals1.transformData.AxisRotate.X);
				UiModelActorComponent weaponActorComponent3 = CS$<>8__locals1.weaponActorComponent;
				if (weaponActorComponent3 != null)
				{
					AActor actor = weaponActorComponent3.Actor;
					if (actor != null)
					{
						actor.K2_SetActorRotation(newRotation, false);
					}
				}
				if (uiModelRotateComponent == null)
				{
					return;
				}
				uiModelRotateComponent.StartRotate();
			}
		};
		int weaponBreachMaxLevel = ModelBase<WeaponModel>.Instance.GetWeaponBreachMaxLevel(weaponConfigByItemId.Value.BreachId);
		Singleton<UiModelUtil>.Instance.SetWeaponLevelMaterialBreachLevel(CS$<>8__locals1.weaponModel, weaponBreachMaxLevel);
		if (uiModelLoadComponent != null)
		{
			uiModelLoadComponent.LoadModelByModelId(weaponConfigByItemId.Value.ModelId, false, loadFinishCallBack, null);
		}
		if (weaponConfigByItemId.Value.QualityId == 5)
		{
			BP_UpdateInteract_C updateInteractBP = this.UpdateInteractBP;
			if (updateInteractBP != null)
			{
				updateInteractBP.WeaponGolden();
			}
		}
		else if (weaponConfigByItemId.Value.QualityId == 4)
		{
			BP_UpdateInteract_C updateInteractBP2 = this.UpdateInteractBP;
			if (updateInteractBP2 != null)
			{
				updateInteractBP2.WeaponPurple();
			}
		}
		else if (weaponConfigByItemId.Value.QualityId == 3)
		{
			BP_UpdateInteract_C updateInteractBP3 = this.UpdateInteractBP;
			if (updateInteractBP3 != null)
			{
				updateInteractBP3.WeaponNormal();
			}
		}
		GachaScanView.<>c__DisplayClass57_0 CS$<>8__locals2 = CS$<>8__locals1;
		SkeletalObserverHandle gachaWeaponScabbardObserver = this.GachaWeaponScabbardObserver;
		CS$<>8__locals2.scabbardModel = ((gachaWeaponScabbardObserver != null) ? gachaWeaponScabbardObserver.Model : null);
		if (CS$<>8__locals1.scabbardModel == null)
		{
			return;
		}
		int[] array = weaponConfigByItemId.Value.Models();
		if (CS$<>8__locals1.transformData == null || !CS$<>8__locals1.transformData.ShowScabbard || array == null || array.Length <= 1)
		{
			Singleton<UiModelUtil>.Instance.SetVisible(CS$<>8__locals1.scabbardModel, false);
			return;
		}
		int modelId = array[1];
		UiModelLoadComponent uiModelLoadComponent2 = CS$<>8__locals1.scabbardModel.CheckGetComponent<UiModelLoadComponent>();
		Action loadFinishCallBack2 = delegate()
		{
			UiModelActorComponent uiModelActorComponent = CS$<>8__locals1.scabbardModel.CheckGetComponent<UiModelActorComponent>();
			if (((uiModelActorComponent != null) ? uiModelActorComponent.Actor : null) != null)
			{
				UiModelActorComponent weaponActorComponent = CS$<>8__locals1.weaponActorComponent;
				if (((weaponActorComponent != null) ? weaponActorComponent.Actor : null) != null)
				{
					uiModelActorComponent.Actor.K2_AttachToActor(CS$<>8__locals1.weaponActorComponent.Actor, null, EAttachmentRule.SnapToTarget, EAttachmentRule.KeepWorld, EAttachmentRule.KeepWorld, false, true);
				}
			}
			if (CS$<>8__locals1.transformData != null)
			{
				global::Transform transform = global::Transform.Create();
				transform.SetLocation(new FVector((float)CS$<>8__locals1.transformData.ScabbardOffset.X, (float)CS$<>8__locals1.transformData.ScabbardOffset.Y, (float)CS$<>8__locals1.transformData.ScabbardOffset.Z));
				FHitResult fhitResult = new FHitResult();
				if (uiModelActorComponent != null)
				{
					USkeletalMeshComponent mainMeshComponent = uiModelActorComponent.MainMeshComponent;
					if (mainMeshComponent != null)
					{
						FTransformDouble ftransformDouble = transform.ToUeTransform();
						mainMeshComponent.D_K2_SetRelativeTransform(ftransformDouble, false, ref fhitResult, false);
					}
				}
			}
			Singleton<UiModelUtil>.Instance.SetVisible(CS$<>8__locals1.scabbardModel, true);
		};
		Singleton<UiModelUtil>.Instance.SetWeaponLevelMaterialBreachLevel(CS$<>8__locals1.scabbardModel, weaponBreachMaxLevel);
		if (uiModelLoadComponent2 == null)
		{
			return;
		}
		uiModelLoadComponent2.LoadModelByModelId(modelId, false, loadFinishCallBack2, null);
	}

	// Token: 0x0600DA39 RID: 55865 RVA: 0x003AA212 File Offset: 0x003A8412
	private void ShareBtn()
	{
		ControllerBase<ChannelController>.Instance.ShareGacha(new global::GachaResult[]
		{
			this.GetCurResult()
		});
	}

	// Token: 0x0600DA3A RID: 55866 RVA: 0x003AA22D File Offset: 0x003A842D
	private void SkipBtn()
	{
		this.IsOnlyShowGold = true;
		this.AddIndex();
	}

	// Token: 0x0600DA3B RID: 55867 RVA: 0x003AA23C File Offset: 0x003A843C
	private void NextBtn()
	{
		if (!this.IsCanContinue)
		{
			return;
		}
		this.AddIndex();
	}

	// Token: 0x0600DA3C RID: 55868 RVA: 0x003AA250 File Offset: 0x003A8450
	protected void AddIndex()
	{
		if (this.CurIndex >= this.GachaResult.Length - 1)
		{
			this.Finish();
			return;
		}
		if (this.IsOnlyShowGold)
		{
			int num = this.FindNextGoldIndex();
			if (num <= 0)
			{
				this.Finish();
				return;
			}
			this.LastIndex = this.CurIndex;
			this.CurIndex = num;
		}
		else
		{
			this.LastIndex = this.CurIndex;
			this.CurIndex++;
		}
		this.Refresh();
	}

	// Token: 0x0600DA3D RID: 55869 RVA: 0x003AA2C8 File Offset: 0x003A84C8
	private int FindNextGoldIndex()
	{
		for (int i = this.CurIndex + 1; i < this.GachaResult.Length; i++)
		{
			global::GachaResult gachaResult = this.GachaResult[i];
			int itemId = gachaResult.Proto_GachaReward.ItemId;
			GachaDefine.EItemQuality gachaQuality = ModelBase<GachaModel>.Instance.GetGachaQuality(itemId);
			if (gachaQuality == GachaDefine.EItemQuality.Gold || (gachaQuality >= GachaDefine.EItemQuality.Purple && gachaResult.IsNew))
			{
				return i;
			}
		}
		return -1;
	}

	// Token: 0x0600DA3E RID: 55870 RVA: 0x003AA323 File Offset: 0x003A8523
	protected void Finish()
	{
		ModelBase<GachaModel>.Instance.CanCloseView = true;
		this.FinishAsync().Forget();
		ModelBase<GachaModel>.Instance.CanCloseView = false;
	}

	// Token: 0x0600DA3F RID: 55871 RVA: 0x003AA348 File Offset: 0x003A8548
	private UniTask FinishAsync()
	{
		GachaScanView.<FinishAsync>d__64 <FinishAsync>d__;
		<FinishAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<FinishAsync>d__.<>4__this = this;
		<FinishAsync>d__.<>1__state = -1;
		<FinishAsync>d__.<>t__builder.Start<GachaScanView.<FinishAsync>d__64>(ref <FinishAsync>d__);
		return <FinishAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600DA40 RID: 55872 RVA: 0x003AA38C File Offset: 0x003A858C
	protected override void OnBeforeShow()
	{
		base.OnBeforeShow();
		ControllerBase<BlackScreenController>.Instance.RemoveBlackScreen("Close", "GachaSkip");
		Singleton<UiSceneManager>.Instance.InitGachaItemObserver();
		this.GachaItemObserver = Singleton<UiSceneManager>.Instance.GetGachaItemObserver();
		ModelBase<WeaponModel>.Instance.SetCurSelectViewName(EWeaponViewName.GachaScanView);
		this.GachaWeaponScabbardObserver = Singleton<UiSceneManager>.Instance.InitWeaponScabbardObserver();
		BP_GachaInteract_C bp_GachaInteract_C = UKuroCollectActorComponent.GetActorWithTag(FNameUtil.GetDynamicFName("GachaBP").Value, ECollectActorType.Default) as BP_GachaInteract_C;
		if (bp_GachaInteract_C != null && !bp_GachaInteract_C.IsSkip)
		{
			bp_GachaInteract_C.WhiteScreenOff();
		}
		UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.Kuro.KuroBloomEnable 1", null);
		this.WeaponDataTable = Singleton<ResourceSystem>.Instance.Load<UDataTable>("/Game/Aki/Data/GaCha/GachaWeaponTransform.GachaWeaponTransform", this.MemoryTag);
		this.InitProduct();
		IGachaViewOpenData gachaViewOpenData = this.OpenParam as IGachaViewOpenData;
		this.IsOnlyShowGold = (gachaViewOpenData != null && gachaViewOpenData.IsOnlyShowGold);
		if (this.IsOnlyShowGold)
		{
			this.CurIndex = -1;
			int num = this.FindNextGoldIndex();
			if (num > 0)
			{
				this.CurIndex = num;
			}
			else
			{
				this.CurIndex = 0;
			}
		}
		else
		{
			this.CurIndex = 0;
		}
		this.StarLayout = new SimpleGenericLayout(base.GetHorizontalLayout(6));
		this.UiLevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
		this.UiLevelSequencePlayer.BindSequenceCloseEvent(new TSequenceEndEvent(this.OnUiLevelSequenceStop), false);
		int? intConfig = ConfigCommonParamById.GetIntConfig("GachaRoleBeforeEndFrame");
		if (intConfig != null)
		{
			this.RoleBeforeEndFrame = intConfig.Value;
		}
		int? intConfig2 = ConfigCommonParamById.GetIntConfig("GachaWeaponBeforeEndFrame");
		if (intConfig2 != null)
		{
			this.WeaponBeforeEndFrame = intConfig2.Value;
		}
		this.Refresh();
	}

	// Token: 0x0600DA41 RID: 55873 RVA: 0x003AA520 File Offset: 0x003A8720
	protected override void OnBeforeHideImplement()
	{
		Singleton<GameSettingsManager>.Instance.ReApply(EFunction.BLOOM, EGameSettingsApplyReason.AnyTime, true);
		BP_UpdateInteract_C updateInteractBP = this.UpdateInteractBP;
		if (updateInteractBP != null && updateInteractBP.IsValid())
		{
			BP_UpdateInteract_C updateInteractBP2 = this.UpdateInteractBP;
			if (updateInteractBP2 != null)
			{
				updateInteractBP2.EndGachaScene();
			}
		}
		ModelBase<WeaponModel>.Instance.SetCurSelectViewName(EWeaponViewName.None);
	}

	// Token: 0x0600DA42 RID: 55874 RVA: 0x003AA570 File Offset: 0x003A8770
	protected override void OnBeforeDestroyImplementImplement()
	{
		this.WeaponDataTable = null;
		LevelSequencePlayer fiveStarLevelSequencePlayer = this.FiveStarLevelSequencePlayer;
		if (fiveStarLevelSequencePlayer != null)
		{
			fiveStarLevelSequencePlayer.Clear();
		}
		LevelSequencePlayer uiLevelSequencePlayer = this.UiLevelSequencePlayer;
		if (uiLevelSequencePlayer != null)
		{
			uiLevelSequencePlayer.Clear();
		}
		Singleton<UiSceneManager>.Instance.DestroyGachaItemObserver();
		Singleton<UiSceneManager>.Instance.DestroyWeaponScabbardObserver(this.GachaWeaponScabbardObserver);
		if (this.PlayUiSequenceTimerId != null)
		{
			TimerSystem.GameplayTimeInstance.Remove(this.PlayUiSequenceTimerId);
			this.PlayUiSequenceTimerId = null;
		}
	}

	// Token: 0x0600DA43 RID: 55875 RVA: 0x003AA5E0 File Offset: 0x003A87E0
	[NullableContext(1)]
	protected void OnSequenceEventByStringParam(string param)
	{
		SkeletalObserverHandle gachaItemObserver = this.GachaItemObserver;
		SkeletalObserverHandle gachaWeaponScabbardObserver = this.GachaWeaponScabbardObserver;
		UiModelBase uiModelBase = (gachaItemObserver != null) ? gachaItemObserver.Model : null;
		UiModelBase uiModelBase2 = (gachaWeaponScabbardObserver != null) ? gachaWeaponScabbardObserver.Model : null;
		if (!(param == "Flash1"))
		{
			if (!(param == "Flash2"))
			{
				if (!(param == "WeaponDA"))
				{
					if (!(param == "WeaponEffect"))
					{
						if (!(param == "RemoveWeaponDA"))
						{
							return;
						}
						if (uiModelBase != null)
						{
							Singleton<UiModelUtil>.Instance.RemoveRenderingMaterial(uiModelBase, this.MaterialId);
							Singleton<UiModelUtil>.Instance.RemoveRenderingMaterial(uiModelBase, this.WeaponColorMaterialId);
						}
						if (uiModelBase2 != null)
						{
							Singleton<UiModelUtil>.Instance.RemoveRenderingMaterial(uiModelBase2, this.ScabbardMaterialId);
							Singleton<UiModelUtil>.Instance.RemoveRenderingMaterial(uiModelBase2, this.WeaponColorScabbardMaterialId);
						}
					}
					else if (this.CurQuality == 5)
					{
						if (uiModelBase != null)
						{
							this.WeaponColorMaterialId = Singleton<UiModelUtil>.Instance.SetRenderingMaterial(uiModelBase, "GachaBurstGoldController");
						}
						if (uiModelBase2 != null)
						{
							this.WeaponColorScabbardMaterialId = Singleton<UiModelUtil>.Instance.SetRenderingMaterial(uiModelBase2, "GachaBurstGoldController");
							return;
						}
					}
					else if (this.CurQuality == 4)
					{
						if (uiModelBase != null)
						{
							this.WeaponColorMaterialId = Singleton<UiModelUtil>.Instance.SetRenderingMaterial(uiModelBase, "GachaBurstPurpleController");
						}
						if (uiModelBase2 != null)
						{
							this.WeaponColorScabbardMaterialId = Singleton<UiModelUtil>.Instance.SetRenderingMaterial(uiModelBase2, "GachaBurstPurpleController");
							return;
						}
					}
					else if (this.CurQuality == 3)
					{
						if (uiModelBase != null)
						{
							this.WeaponColorMaterialId = Singleton<UiModelUtil>.Instance.SetRenderingMaterial(uiModelBase, "GachaBurstWhiteController");
						}
						if (uiModelBase2 != null)
						{
							this.WeaponColorScabbardMaterialId = Singleton<UiModelUtil>.Instance.SetRenderingMaterial(uiModelBase2, "GachaBurstWhiteController");
							return;
						}
					}
				}
				else
				{
					if (uiModelBase != null)
					{
						this.MaterialId = Singleton<UiModelUtil>.Instance.SetRenderingMaterial(uiModelBase, "GachaMaterialController");
					}
					if (uiModelBase2 != null)
					{
						this.ScabbardMaterialId = Singleton<UiModelUtil>.Instance.SetRenderingMaterial(uiModelBase2, "GachaMaterialController");
						return;
					}
				}
			}
			else
			{
				Singleton<AudioSystem>.Instance.PostEvent("ui_gacha_scan_burst");
				if (this.CurQuality == 5)
				{
					this.EffectGold.SetActorHiddenInGame(false);
					ANiagaraActor effectGold = this.EffectGold;
					if (effectGold == null)
					{
						return;
					}
					effectGold.NiagaraComponent.ReinitializeSystem();
					return;
				}
				else if (this.CurQuality == 4)
				{
					this.EffectPurple.SetActorHiddenInGame(false);
					ANiagaraActor effectPurple = this.EffectPurple;
					if (effectPurple == null)
					{
						return;
					}
					effectPurple.NiagaraComponent.ReinitializeSystem();
					return;
				}
				else if (this.CurQuality == 3)
				{
					this.EffectWhite.SetActorHiddenInGame(false);
					ANiagaraActor effectWhite = this.EffectWhite;
					if (effectWhite == null)
					{
						return;
					}
					effectWhite.NiagaraComponent.ReinitializeSystem();
					return;
				}
			}
			return;
		}
		this.CameraEffect.NiagaraComponent.ReinitializeSystem();
	}

	// Token: 0x0600DA44 RID: 55876 RVA: 0x003AA840 File Offset: 0x003A8A40
	protected override void OnBeforeDestroy()
	{
		base.AddChild(this.ConvertItem);
		base.AddChild(this.ExtraItem);
		this.HideRoleSequence();
		ModelBase<GachaModel>.Instance.ReleaseLoadGachaSequence();
		Singleton<GameSettingsDeviceRender>.Instance.CancelTemporaryDisableFrameGeneration("RefreshModel");
		UKuroSequencePerformanceManager.CloseKuroPerformanceMode();
		if (this.NeedProcessSkyBlending)
		{
			UKuroSequencePerformanceManager.SimpleExecuteCommand("r.SkyBlending.AllowSettingLerpPerFrame 0");
		}
		if (Singleton<Info>.Instance.IsLowMemoryDevice && this.OriginDepthOfFieldQuality != 0)
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(22, 1);
			defaultInterpolatedStringHandler.AppendLiteral("r.DepthOfFieldQuality ");
			defaultInterpolatedStringHandler.AppendFormatted<int>(this.OriginDepthOfFieldQuality);
			UKuroSequencePerformanceManager.SimpleExecuteCommand(defaultInterpolatedStringHandler.ToStringAndClear());
		}
		if (Singleton<Info>.Instance.IsMacPlatform())
		{
			UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.AllowHardwareOcclusion 1", null);
		}
		RenderUtil.EndPSOSyncMode();
	}

	// Token: 0x0600DA45 RID: 55877 RVA: 0x003AA900 File Offset: 0x003A8B00
	[NullableContext(1)]
	private void OnActivitySequenceEmitEvent(string param)
	{
		if (this.StarLayout == null)
		{
			return;
		}
		if (param == "GachaStart")
		{
			UUIInturnAnimController uuiinturnAnimController = base.GetHorizontalLayout(6).GetOwner().GetComponentByClass(UUIInturnAnimController.StaticClass()) as UUIInturnAnimController;
			if (uuiinturnAnimController != null)
			{
				uuiinturnAnimController.Play("", this.StarLayout.GetDisplayCount(), false);
			}
		}
	}

	// Token: 0x0600DA46 RID: 55878 RVA: 0x003AA95E File Offset: 0x003A8B5E
	[NullableContext(1)]
	private void OnUiLevelSequenceStop(string seqName)
	{
		if (seqName == "Show" && this.IsWeaponToEnd)
		{
			this.IsCanContinue = true;
		}
	}

	// Token: 0x0400681D RID: 26653
	public static readonly FName SCENE_CAMERA_TAG = FNameUtil.GetDynamicFName("SequenceCamera").Value;

	// Token: 0x0400681E RID: 26654
	public static readonly FName SCENE_ROLE_TAG = FNameUtil.GetDynamicFName("Role").Value;

	// Token: 0x0400681F RID: 26655
	[Nullable(new byte[]
	{
		2,
		1
	})]
	protected global::GachaResult[] GachaResult;

	// Token: 0x04006820 RID: 26656
	protected int CurIndex;

	// Token: 0x04006821 RID: 26657
	protected int LastIndex = -1;

	// Token: 0x04006822 RID: 26658
	private SmallItemGrid ConvertItem;

	// Token: 0x04006823 RID: 26659
	private SmallItemGrid ExtraItem;

	// Token: 0x04006824 RID: 26660
	private ULevelSequencePlayer LevelSequencePlayer;

	// Token: 0x04006825 RID: 26661
	private LevelSequencePlayer FiveStarLevelSequencePlayer;

	// Token: 0x04006826 RID: 26662
	private LevelSequencePlayer UiLevelSequencePlayer;

	// Token: 0x04006827 RID: 26663
	private ALevelSequenceActor SequenceActor;

	// Token: 0x04006828 RID: 26664
	private ANiagaraActor CameraEffect;

	// Token: 0x04006829 RID: 26665
	private ANiagaraActor EffectGold;

	// Token: 0x0400682A RID: 26666
	private ANiagaraActor EffectPurple;

	// Token: 0x0400682B RID: 26667
	private ANiagaraActor EffectWhite;

	// Token: 0x0400682C RID: 26668
	private AActor SceneCamera;

	// Token: 0x0400682D RID: 26669
	private SimpleGenericLayout StarLayout;

	// Token: 0x0400682E RID: 26670
	private ShareRewardInfo ShareRewardInfo;

	// Token: 0x0400682F RID: 26671
	private int MaterialId;

	// Token: 0x04006830 RID: 26672
	private int ScabbardMaterialId;

	// Token: 0x04006831 RID: 26673
	private int WeaponColorMaterialId;

	// Token: 0x04006832 RID: 26674
	private int WeaponColorScabbardMaterialId;

	// Token: 0x04006833 RID: 26675
	private BP_UpdateInteract_C UpdateInteractBP;

	// Token: 0x04006834 RID: 26676
	private int CurQuality;

	// Token: 0x04006835 RID: 26677
	private bool IsOnlyShowGold;

	// Token: 0x04006836 RID: 26678
	private UDataTable WeaponDataTable;

	// Token: 0x04006837 RID: 26679
	private TimerHandle PlayUiSequenceTimerId;

	// Token: 0x04006838 RID: 26680
	private int RoleBeforeEndFrame = 190;

	// Token: 0x04006839 RID: 26681
	private int WeaponBeforeEndFrame = 190;

	// Token: 0x0400683A RID: 26682
	private bool IsCanContinue;

	// Token: 0x0400683B RID: 26683
	private bool IsWeaponToEnd;

	// Token: 0x0400683C RID: 26684
	private AActor OriginalCamera;

	// Token: 0x0400683D RID: 26685
	private bool NeedProcessSkyBlending;

	// Token: 0x0400683E RID: 26686
	private int OriginDepthOfFieldQuality;

	// Token: 0x0400683F RID: 26687
	private SkeletalObserverHandle GachaItemObserver;

	// Token: 0x04006840 RID: 26688
	private SkeletalObserverHandle GachaWeaponScabbardObserver;

	// Token: 0x02008075 RID: 32885
	[NullableContext(0)]
	private enum EGachaScanCom
	{
		// Token: 0x0402BB21 RID: 178977
		SkipBtn,
		// Token: 0x0402BB22 RID: 178978
		NextBtn,
		// Token: 0x0402BB23 RID: 178979
		NameText,
		// Token: 0x0402BB24 RID: 178980
		AttributesItem,
		// Token: 0x0402BB25 RID: 178981
		AttributeTexture,
		// Token: 0x0402BB26 RID: 178982
		AttributeBoxTexture,
		// Token: 0x0402BB27 RID: 178983
		StarLayout,
		// Token: 0x0402BB28 RID: 178984
		ConvertParentItem,
		// Token: 0x0402BB29 RID: 178985
		ConvertItem,
		// Token: 0x0402BB2A RID: 178986
		ExtraParentItem,
		// Token: 0x0402BB2B RID: 178987
		ExtraItem,
		// Token: 0x0402BB2C RID: 178988
		NewItem,
		// Token: 0x0402BB2D RID: 178989
		FiveStarPanel,
		// Token: 0x0402BB2E RID: 178990
		InfoPanel,
		// Token: 0x0402BB2F RID: 178991
		BottomExtraRewardParentItem,
		// Token: 0x0402BB30 RID: 178992
		BottomExtraRewardTexture,
		// Token: 0x0402BB31 RID: 178993
		BottomExtraRewardCountText,
		// Token: 0x0402BB32 RID: 178994
		BottomExtraRewardNameText,
		// Token: 0x0402BB33 RID: 178995
		ShareInfo,
		// Token: 0x0402BB34 RID: 178996
		ShareBtn,
		// Token: 0x0402BB35 RID: 178997
		ShareReward,
		// Token: 0x0402BB36 RID: 178998
		ShareRewardTip,
		// Token: 0x0402BB37 RID: 178999
		PanelMask
	}
}
