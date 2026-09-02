using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using AkiClient.Game.Aki.Scene.NewGacha.BP;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.BlackScreen;
using CSharpScript.Game.Module.UiCameraAnimation.UiCameraContext;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020028FC RID: 10492
[NullableContext(2)]
[Nullable(0)]
public class RoleNewJoinView : UiViewBase
{
	// Token: 0x06014D67 RID: 85351 RVA: 0x005C586D File Offset: 0x005C3A6D
	[NullableContext(1)]
	public RoleNewJoinView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06014D68 RID: 85352 RVA: 0x005C5878 File Offset: 0x005C3A78
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUITexture)),
			new ValueTuple<int, Type>(3, typeof(UUITexture)),
			new ValueTuple<int, Type>(4, typeof(UUIHorizontalLayout)),
			new ValueTuple<int, Type>(5, typeof(UUIText)),
			new ValueTuple<int, Type>(6, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(7, typeof(UUIButtonComponent))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(6, new Action(this.DetailBtn)),
			new ValueTuple<int, Delegate>(7, new Action(this.CloseBtn))
		};
	}

	// Token: 0x06014D69 RID: 85353 RVA: 0x005C597C File Offset: 0x005C3B7C
	protected override void OnBeforeCreate()
	{
		this.RoleId = (int)(this.OpenParam ?? 0);
		RoleInfo? roleInfoById = ConfigBase<GachaConfig>.Instance.GetRoleInfoById(this.RoleId);
		if (roleInfoById != null)
		{
			this.CurQuality = roleInfoById.Value.QualityId;
		}
		this.GachaSequence = new UiBehaviorGachaSequence();
		base.AddUiBehavior(this.GachaSequence);
	}

	// Token: 0x06014D6A RID: 85354 RVA: 0x005C59EC File Offset: 0x005C3BEC
	protected override UniTask OnCreateAsync()
	{
		RoleNewJoinView.<OnCreateAsync>d__16 <OnCreateAsync>d__;
		<OnCreateAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnCreateAsync>d__.<>1__state = -1;
		<OnCreateAsync>d__.<>t__builder.Start<RoleNewJoinView.<OnCreateAsync>d__16>(ref <OnCreateAsync>d__);
		return <OnCreateAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06014D6B RID: 85355 RVA: 0x005C5A28 File Offset: 0x005C3C28
	protected override UniTask OnBeforeStartAsync()
	{
		RoleNewJoinView.<OnBeforeStartAsync>d__17 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<RoleNewJoinView.<OnBeforeStartAsync>d__17>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06014D6C RID: 85356 RVA: 0x005C5A6B File Offset: 0x005C3C6B
	protected override void OnStart()
	{
		this.StarLayout = new SimpleGenericLayout(base.GetHorizontalLayout(4));
	}

	// Token: 0x06014D6D RID: 85357 RVA: 0x005C5A7F File Offset: 0x005C3C7F
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<string>(EEventName.PlaySequenceEventByStringParam, new Action<string>(this.OnSequenceEventByStringParam));
		Singleton<EventSystem>.Instance.Add(EEventName.CloseGachaSceneView, new Action(this.CloseViewEvent));
	}

	// Token: 0x06014D6E RID: 85358 RVA: 0x005C5ABC File Offset: 0x005C3CBC
	protected override void OnHandleLoadScene()
	{
		this.SceneCamera = UKuroCollectActorComponent.GetActorWithTag(FNameUtil.GetDynamicFName("SceneCamera1").Value, ECollectActorType.Default);
		if (this.GachaSequence != null && this.SceneCamera != null)
		{
			this.GachaSequence.BindSceneSequenceCamera(this.SceneCamera);
		}
		this.CameraEffect = (UKuroCollectActorComponent.GetActorWithTag(FNameUtil.GetDynamicFName("Flash1").Value, ECollectActorType.Default) as ANiagaraActor);
		this.EffectGold = (UKuroCollectActorComponent.GetActorWithTag(FNameUtil.GetDynamicFName("BurstGold").Value, ECollectActorType.Default) as ANiagaraActor);
		this.EffectPurple = (UKuroCollectActorComponent.GetActorWithTag(FNameUtil.GetDynamicFName("BurstPurple").Value, ECollectActorType.Default) as ANiagaraActor);
		this.EffectWhite = (UKuroCollectActorComponent.GetActorWithTag(FNameUtil.GetDynamicFName("BurstWhite").Value, ECollectActorType.Default) as ANiagaraActor);
		this.UpdateInteractBP = (UKuroCollectActorComponent.GetActorWithTag(FNameUtil.GetDynamicFName("UpdateInteractBP").Value, ECollectActorType.Default) as BP_UpdateInteract_C);
		if (this.UpdateInteractBP != null)
		{
			this.UpdateInteractBP.SetTickableWhenPaused(true);
			if (this.GachaSequence != null)
			{
				this.GachaSequence.BindUpdateInteractBp(this.UpdateInteractBP);
			}
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
		this.UiCameraHandleData = Singleton<UiCameraAnimationManager>.Instance.PushCameraHandleByHandleName("1041_New", true, true, "10007", false, null, null);
	}

	// Token: 0x06014D6F RID: 85359 RVA: 0x005C5DC9 File Offset: 0x005C3FC9
	protected override void OnAfterShow()
	{
		this.IsDetail = false;
		this.Refresh();
	}

	// Token: 0x06014D70 RID: 85360 RVA: 0x005C5DD8 File Offset: 0x005C3FD8
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.PlaySequenceEventByStringParam, new Action<string>(this.OnSequenceEventByStringParam));
		Singleton<EventSystem>.Instance.Remove(EEventName.CloseGachaSceneView, new Action(this.CloseViewEvent));
	}

	// Token: 0x06014D71 RID: 85361 RVA: 0x005C5E12 File Offset: 0x005C4012
	protected override void OnBeforeDestroy()
	{
		if (this.UiCameraHandleData != null)
		{
			Singleton<UiCameraAnimationManager>.Instance.PopCameraHandle(this.UiCameraHandleData, "10007");
		}
	}

	// Token: 0x06014D72 RID: 85362 RVA: 0x005C5E34 File Offset: 0x005C4034
	[NullableContext(1)]
	protected void OnSequenceEventByStringParam(string param)
	{
		if (!(param == "Flash1"))
		{
			if (!(param == "Flash2"))
			{
				return;
			}
			if (this.CurQuality == 5)
			{
				if (this.EffectGold != null)
				{
					this.EffectGold.SetActorHiddenInGame(false);
					UNiagaraComponent niagaraComponent = this.EffectGold.NiagaraComponent;
					if (niagaraComponent == null)
					{
						return;
					}
					niagaraComponent.ReinitializeSystem();
					return;
				}
			}
			else if (this.CurQuality == 4)
			{
				if (this.EffectPurple != null)
				{
					this.EffectPurple.SetActorHiddenInGame(false);
					UNiagaraComponent niagaraComponent2 = this.EffectPurple.NiagaraComponent;
					if (niagaraComponent2 == null)
					{
						return;
					}
					niagaraComponent2.ReinitializeSystem();
					return;
				}
			}
			else if (this.CurQuality == 3 && this.EffectWhite != null)
			{
				this.EffectWhite.SetActorHiddenInGame(false);
				UNiagaraComponent niagaraComponent3 = this.EffectWhite.NiagaraComponent;
				if (niagaraComponent3 == null)
				{
					return;
				}
				niagaraComponent3.ReinitializeSystem();
			}
			return;
		}
		else
		{
			ANiagaraActor cameraEffect = this.CameraEffect;
			if (cameraEffect == null)
			{
				return;
			}
			UNiagaraComponent niagaraComponent4 = cameraEffect.NiagaraComponent;
			if (niagaraComponent4 == null)
			{
				return;
			}
			niagaraComponent4.ReinitializeSystem();
			return;
		}
	}

	// Token: 0x06014D73 RID: 85363 RVA: 0x005C5F14 File Offset: 0x005C4114
	private void Refresh()
	{
		this.HideBackgroundEffects();
		this.RefreshView();
		this.PlayGachaSequence();
		this.UiViewSequence.StopPrevSequence(false, false);
		this.UiViewSequence.PlaySequence("Show", true, null);
	}

	// Token: 0x06014D74 RID: 85364 RVA: 0x005C5F5C File Offset: 0x005C415C
	private void RefreshView()
	{
		int roleId = this.RoleId;
		RoleInfo? roleInfoById = ConfigBase<GachaConfig>.Instance.GetRoleInfoById(roleId);
		if (roleInfoById == null)
		{
			return;
		}
		ElementInfo? elementConfig = ConfigBase<CommonConfig>.Instance.GetElementConfig(roleInfoById.Value.ElementId);
		if (elementConfig != null)
		{
			base.GetTexture(3).SetColor(FColor.FromHex(elementConfig.Value.ElementColor));
			UUITexture texture = base.GetTexture(2);
			base.SetTextureByPath(elementConfig.Value.Icon, texture, null, null);
			FColor color = FColor.FromHex(elementConfig.Value.ElementColor);
			if (texture != null)
			{
				texture.SetColor(color);
			}
		}
		base.GetText(0).ShowTextNew(roleInfoById.Value.Name);
		base.GetText(5).ShowTextNew(roleInfoById.Value.Introduction);
		this.StarLayout.RebuildLayout(this.CurQuality);
		ControllerBase<BlackScreenController>.Instance.RemoveBlackScreen("Close", EUiViewName.RoleNewJoinView);
	}

	// Token: 0x06014D75 RID: 85365 RVA: 0x005C607C File Offset: 0x005C427C
	protected void PlayGachaSequence()
	{
		if (this.GachaSequence == null)
		{
			return;
		}
		FMovieSceneSequencePlaybackSettings fmovieSceneSequencePlaybackSettings = new FMovieSceneSequencePlaybackSettings();
		fmovieSceneSequencePlaybackSettings.bRestoreState = true;
		fmovieSceneSequencePlaybackSettings.bPauseAtEnd = true;
		this.GachaSequence.SetSequencePlayBackSetting(this.RoleId, fmovieSceneSequencePlaybackSettings);
		this.GachaSequence.PlayRoleSequence(this.RoleId, 0);
		this.ShowRole();
	}

	// Token: 0x06014D76 RID: 85366 RVA: 0x005C60D0 File Offset: 0x005C42D0
	private void ShowRole()
	{
		RoleInfo? roleInfoById = ConfigBase<GachaConfig>.Instance.GetRoleInfoById(this.RoleId);
		if (roleInfoById == null)
		{
			return;
		}
		if (roleInfoById.Value.Id == 1302)
		{
			BP_UpdateInteract_C updateInteractBP = this.UpdateInteractBP;
			if (updateInteractBP == null)
			{
				return;
			}
			updateInteractBP.Yinlin();
			return;
		}
		else if (roleInfoById.Value.Id == 1404)
		{
			BP_UpdateInteract_C updateInteractBP2 = this.UpdateInteractBP;
			if (updateInteractBP2 == null)
			{
				return;
			}
			updateInteractBP2.Jiyan();
			return;
		}
		else if (roleInfoById.Value.Id == 1203)
		{
			BP_UpdateInteract_C updateInteractBP3 = this.UpdateInteractBP;
			if (updateInteractBP3 == null)
			{
				return;
			}
			updateInteractBP3.Anke();
			return;
		}
		else if (roleInfoById.Value.Id == 1503)
		{
			BP_UpdateInteract_C updateInteractBP4 = this.UpdateInteractBP;
			if (updateInteractBP4 == null)
			{
				return;
			}
			updateInteractBP4.Jueyuan();
			return;
		}
		else if (roleInfoById.Value.Id == 1301)
		{
			BP_UpdateInteract_C updateInteractBP5 = this.UpdateInteractBP;
			if (updateInteractBP5 == null)
			{
				return;
			}
			updateInteractBP5.Kakaluo();
			return;
		}
		else if (roleInfoById.Value.Id == 1603)
		{
			BP_UpdateInteract_C updateInteractBP6 = this.UpdateInteractBP;
			if (updateInteractBP6 == null)
			{
				return;
			}
			updateInteractBP6.Chun();
			return;
		}
		else if (roleInfoById.Value.Id == 1104)
		{
			BP_UpdateInteract_C updateInteractBP7 = this.UpdateInteractBP;
			if (updateInteractBP7 == null)
			{
				return;
			}
			updateInteractBP7.Awu();
			return;
		}
		else
		{
			if (roleInfoById.Value.QualityId != 5)
			{
				if (roleInfoById.Value.QualityId == 4)
				{
					BP_UpdateInteract_C updateInteractBP8 = this.UpdateInteractBP;
					if (updateInteractBP8 == null)
					{
						return;
					}
					updateInteractBP8.CharacterPurple();
				}
				return;
			}
			BP_UpdateInteract_C updateInteractBP9 = this.UpdateInteractBP;
			if (updateInteractBP9 == null)
			{
				return;
			}
			updateInteractBP9.CharacterGolden();
			return;
		}
	}

	// Token: 0x06014D77 RID: 85367 RVA: 0x005C6250 File Offset: 0x005C4450
	private void HideBackgroundEffects()
	{
		if (this.EffectGold != null)
		{
			this.EffectGold.SetActorHiddenInGame(true);
			UNiagaraComponent niagaraComponent = this.EffectGold.NiagaraComponent;
			if (niagaraComponent != null)
			{
				niagaraComponent.Deactivate();
			}
		}
		if (this.EffectPurple != null)
		{
			this.EffectPurple.SetActorHiddenInGame(true);
			UNiagaraComponent niagaraComponent2 = this.EffectPurple.NiagaraComponent;
			if (niagaraComponent2 != null)
			{
				niagaraComponent2.Deactivate();
			}
		}
		if (this.EffectWhite != null)
		{
			this.EffectWhite.SetActorHiddenInGame(true);
			UNiagaraComponent niagaraComponent3 = this.EffectWhite.NiagaraComponent;
			if (niagaraComponent3 == null)
			{
				return;
			}
			niagaraComponent3.Deactivate();
		}
	}

	// Token: 0x06014D78 RID: 85368 RVA: 0x005C62DA File Offset: 0x005C44DA
	private void Finish()
	{
		Singleton<EventSystem>.Instance.Emit(EEventName.CloseGachaSceneView);
	}

	// Token: 0x06014D79 RID: 85369 RVA: 0x005C62EC File Offset: 0x005C44EC
	protected void CloseViewEvent()
	{
		this.BindCloseUiScene();
	}

	// Token: 0x06014D7A RID: 85370 RVA: 0x005C62F4 File Offset: 0x005C44F4
	private void BindCloseUiScene()
	{
		this.AfterCloseUiScene(true);
	}

	// Token: 0x06014D7B RID: 85371 RVA: 0x005C62FD File Offset: 0x005C44FD
	private void AfterCloseUiScene(bool ret)
	{
		if (!ret)
		{
			return;
		}
		if (Singleton<UiManager>.Instance.IsViewShow(this.ViewInfo.Name))
		{
			base.CloseMe(null);
		}
		Singleton<EventSystem>.Instance.Emit(EEventName.AfterCloseGachaScene);
	}

	// Token: 0x06014D7C RID: 85372 RVA: 0x005C6331 File Offset: 0x005C4531
	private void CloseBtn()
	{
		this.Finish();
	}

	// Token: 0x06014D7D RID: 85373 RVA: 0x005C6339 File Offset: 0x005C4539
	private void DetailBtn()
	{
		if (this.IsDetail)
		{
			return;
		}
		this.IsDetail = true;
		this.ClickDetail().Forget();
	}

	// Token: 0x06014D7E RID: 85374 RVA: 0x005C6358 File Offset: 0x005C4558
	private UniTask ClickDetail()
	{
		RoleNewJoinView.<ClickDetail>d__36 <ClickDetail>d__;
		<ClickDetail>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<ClickDetail>d__.<>4__this = this;
		<ClickDetail>d__.<>1__state = -1;
		<ClickDetail>d__.<>t__builder.Start<RoleNewJoinView.<ClickDetail>d__36>(ref <ClickDetail>d__);
		return <ClickDetail>d__.<>t__builder.Task;
	}

	// Token: 0x0400A056 RID: 41046
	private int RoleId;

	// Token: 0x0400A057 RID: 41047
	protected UiCameraHandleData UiCameraHandleData;

	// Token: 0x0400A058 RID: 41048
	private ANiagaraActor CameraEffect;

	// Token: 0x0400A059 RID: 41049
	private ANiagaraActor EffectGold;

	// Token: 0x0400A05A RID: 41050
	private ANiagaraActor EffectPurple;

	// Token: 0x0400A05B RID: 41051
	private ANiagaraActor EffectWhite;

	// Token: 0x0400A05C RID: 41052
	private AActor SceneCamera;

	// Token: 0x0400A05D RID: 41053
	private BP_UpdateInteract_C UpdateInteractBP;

	// Token: 0x0400A05E RID: 41054
	private SimpleGenericLayout StarLayout;

	// Token: 0x0400A05F RID: 41055
	private UiBehaviorGachaSequence GachaSequence;

	// Token: 0x0400A060 RID: 41056
	private int CurQuality;

	// Token: 0x0400A061 RID: 41057
	private bool IsDetail;

	// Token: 0x02008C4A RID: 35914
	[NullableContext(0)]
	private enum ERoleNewJoinComponents
	{
		// Token: 0x0402F404 RID: 193540
		NameText,
		// Token: 0x0402F405 RID: 193541
		AttributesItem,
		// Token: 0x0402F406 RID: 193542
		AttributesTexture,
		// Token: 0x0402F407 RID: 193543
		AttributesBoxSprite,
		// Token: 0x0402F408 RID: 193544
		StarParentItem,
		// Token: 0x0402F409 RID: 193545
		TxtDetail,
		// Token: 0x0402F40A RID: 193546
		BtnConfirm,
		// Token: 0x0402F40B RID: 193547
		BtnBack
	}
}
