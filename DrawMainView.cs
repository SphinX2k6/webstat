using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using AkiClient.Game.Aki.Scene.Gacha.Blueprint;
using CSharpScript.Game;
using CSharpScript.Game.Camera;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001CDA RID: 7386
[NullableContext(2)]
[Nullable(0)]
public class DrawMainView : GachaSceneView
{
	// Token: 0x0600D88B RID: 55435 RVA: 0x0039F6EE File Offset: 0x0039D8EE
	[NullableContext(1)]
	public DrawMainView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600D88C RID: 55436 RVA: 0x0039F710 File Offset: 0x0039D910
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIDraggableComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.OnClickSkipBtn));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600D88D RID: 55437 RVA: 0x0039F7B6 File Offset: 0x0039D9B6
	private void OnClickSkipBtn()
	{
		this.IsSkip = true;
		if (this.IsLoadComplete)
		{
			this.ShowNextView();
		}
	}

	// Token: 0x0600D88E RID: 55438 RVA: 0x0039F7D0 File Offset: 0x0039D9D0
	protected override void OnAfterOpenUiScene()
	{
		this.OriginCameraActor = ControllerBase<CameraController>.Instance.MainModel.CurrentCameraActor;
		int times = ModelBase<GachaModel>.Instance.CurGachaResult.Length;
		int num = 1;
		foreach (GachaResult gachaResult in ModelBase<GachaModel>.Instance.CurGachaResult)
		{
			ItemConfig itemConfigData = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(gachaResult.Proto_GachaReward.ItemId);
			int num2 = (itemConfigData != null) ? itemConfigData.QualityId : 0;
			if (num2 > num)
			{
				num = num2;
			}
		}
		GachaEffectConfig? gachaEffectConfigByTimesAndQuality = ConfigBase<GachaConfig>.Instance.GetGachaEffectConfigByTimesAndQuality(times, num);
		int num3 = 0;
		int num4 = 0;
		Global.CharacterController.GetViewportSize(ref num3, ref num4);
		this.GachaArtBP = (UKuroCollectActorComponent.GetActorWithTag(FNameUtil.GetDynamicFName("GachaBP").Value, ECollectActorType.Default) as BP_GachaArt_C);
		int num5 = num3;
		int num6 = num4;
		ControllerBase<CameraController>.Instance.SetViewTarget(this.GachaArtBP.SceneCameraActor, "OnAfterOpenUi", 0f, EViewTargetBlendFunction.VTBlend_Linear, 0f, null, null, "MainCamera", null, null);
		this.GachaArtBP.Gacha_Result = (E_GachaResult)num;
		this.DefaultProcess = gachaEffectConfigByTimesAndQuality.Value.DefaultProcess;
		this.Value = 0f;
		this.ChangeColorProcess = gachaEffectConfigByTimesAndQuality.Value.ChangeColorProcess;
		this.CompleteChangeColorProcess = gachaEffectConfigByTimesAndQuality.Value.CompleteChangeColorProcess;
		this.PlaySequenceProcess = gachaEffectConfigByTimesAndQuality.Value.PlaySequenceProcess;
		this.GachaArtBP.TSInitParameters(new FVector2D((float)num5, (float)num6), (float)num5 * this.DefaultProcess, this.FinalColor.Value, (E_GachaResult)num);
		Singleton<ResourceSystem>.Instance.LoadAsync<UCurveFloat>(gachaEffectConfigByTimesAndQuality.Value.SlideCurveAssetPath, delegate([Nullable(2)] UCurveFloat asset, string _)
		{
			this.SlideCurve = asset;
			UUIDraggableComponent draggable = base.GetDraggable(0);
			draggable.OnPointerDragCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnDragCallBack));
			draggable.OnPointerBeginDragCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnDragBeginCallBack));
			draggable.OnPointerEndDragCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnDragEndCallBack));
		}, 100, this.MemoryTag);
		ControllerBase<GachaController>.Instance.PreloadGachaResultResource(delegate(EUiRoleLoadResult result)
		{
			this.IsLoadComplete = true;
			if (this.IsDone || this.IsSkip)
			{
				this.ShowNextView();
			}
		});
	}

	// Token: 0x0600D88F RID: 55439 RVA: 0x0039F9C8 File Offset: 0x0039DBC8
	protected void InitLevelSequence()
	{
		int times = ModelBase<GachaModel>.Instance.CurGachaResult.Length;
		int num = 1;
		foreach (GachaResult gachaResult in ModelBase<GachaModel>.Instance.CurGachaResult)
		{
			ItemConfig itemConfigData = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(gachaResult.Proto_GachaReward.ItemId);
			int num2 = (itemConfigData != null) ? itemConfigData.QualityId : 0;
			if (num2 > num)
			{
				num = num2;
			}
		}
		GachaEffectConfig? gachaEffectConfigByTimesAndQuality = ConfigBase<GachaConfig>.Instance.GetGachaEffectConfigByTimesAndQuality(times, num);
		this.ShowSequencePath = gachaEffectConfigByTimesAndQuality.Value.FinalShowSequencePath;
		this.FinalColor = new FLinearColor?(new FLinearColor(gachaEffectConfigByTimesAndQuality.Value.FinalColor.Value.R, gachaEffectConfigByTimesAndQuality.Value.FinalColor.Value.G, gachaEffectConfigByTimesAndQuality.Value.FinalColor.Value.B, gachaEffectConfigByTimesAndQuality.Value.FinalColor.Value.A));
		Singleton<ResourceSystem>.Instance.LoadAsync<ULevelSequence>(this.ShowSequencePath, delegate([Nullable(2)] ULevelSequence levelSequenceObject, string _)
		{
			if (ObjectUtils.IsValid(levelSequenceObject))
			{
				FMovieSceneSequencePlaybackSettings fmovieSceneSequencePlaybackSettings = new FMovieSceneSequencePlaybackSettings();
				fmovieSceneSequencePlaybackSettings.bRestoreState = true;
				this.ShowSequence = (Singleton<ActorSystem>.Instance.Get(ALevelSequenceActor.StaticClass(), Singleton<MathUtils>.Instance.DefaultTransformDouble, null, false) as ALevelSequenceActor);
				this.ShowSequence.PlaybackSettings = fmovieSceneSequencePlaybackSettings;
				this.ShowSequence.SetSequence(levelSequenceObject);
				this.ShowSequencePlayer.OnFinished.Add(delegate()
				{
					this.IsDone = true;
					if (this.IsLoadComplete)
					{
						this.ShowNextView();
					}
				});
			}
		}, 100, this.MemoryTag);
	}

	// Token: 0x0600D890 RID: 55440 RVA: 0x0039FB14 File Offset: 0x0039DD14
	protected override void OnStart()
	{
		this.InitLevelSequence();
		this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
		int num = 0;
		int num2 = 0;
		Global.CharacterController.GetViewportSize(ref num, ref num2);
		this.ScreenX = (float)num;
	}

	// Token: 0x0600D891 RID: 55441 RVA: 0x0039FB52 File Offset: 0x0039DD52
	protected override void OnBeforeDestroy()
	{
		TimerSystem.GameplayTimeInstance.Next(delegate(float _)
		{
			Singleton<ActorSystem>.Instance.Put("DrawMainView.OnBeforeDestroy", this.ShowSequence, null);
		}, null, null);
		this.ShowSequence = null;
		this.LevelSequencePlayer.Clear();
	}

	// Token: 0x0600D892 RID: 55442 RVA: 0x0039FB80 File Offset: 0x0039DD80
	protected override void OnTick(float deltaTime)
	{
		BP_GachaArt_C gachaArtBP = this.GachaArtBP;
		if (gachaArtBP != null && gachaArtBP.SceneCameraActor.IsValid() && ModelBase<CameraModel>.Instance.MainModel.CurrentCameraActor != this.GachaArtBP.SceneCameraActor && !this.IsPlay)
		{
			ControllerBase<CameraController>.Instance.SetViewTarget(this.GachaArtBP.SceneCameraActor, "DrawMainView.OnTick", 0f, EViewTargetBlendFunction.VTBlend_Linear, 0f, null, null, "MainCamera", null, null);
		}
		if (!this.IsDrag && !this.IsShowTips && !this.IsPlay)
		{
			this.TipWaitTime += deltaTime;
			if (this.TipWaitTime >= 2000f)
			{
				this.LevelSequencePlayer.PlayLevelSequenceByName("DrawTipsShow", false, null, false);
				this.IsShowTips = true;
			}
		}
	}

	// Token: 0x0600D893 RID: 55443 RVA: 0x0039FC60 File Offset: 0x0039DE60
	public void OnDragBeginCallBack(ULGUIPointerEventData eventData)
	{
		this.BeginDragPosition = new FVector?(eventData.pointerPosition);
		this.BeginValue = this.StartValue;
		this.IsDrag = true;
		this.TipWaitTime = 0f;
		this.LevelSequencePlayer.PlayLevelSequenceByName("DrawTipsHide", false, null, false);
		this.IsShowTips = false;
	}

	// Token: 0x0600D894 RID: 55444 RVA: 0x0039FCC0 File Offset: 0x0039DEC0
	public void OnDragCallBack(ULGUIPointerEventData eventData)
	{
		this.MousePosition.X = eventData.pointerPosition.X;
		this.MousePosition.Y = eventData.pointerPosition.Y;
		float num = (eventData.pointerPosition.X - this.BeginDragPosition.Value.X) / this.ScreenX;
		this.Value = this.SlideCurve.GetFloatValue(num + this.BeginValue);
		this.StartValue = Singleton<MathUtils>.Instance.Clamp(num + this.BeginValue, 0f, 1f);
		if (this.Value > this.PlaySequenceProcess)
		{
			if (this.IsPlay)
			{
				return;
			}
			this.IsPlay = true;
			this.PlayShowSequence();
		}
		float colorChangeProcess = Singleton<MathUtils>.Instance.Clamp((this.Value - this.ChangeColorProcess) / (this.CompleteChangeColorProcess - this.ChangeColorProcess), 0f, 1f);
		BP_GachaArt_C gachaArtBP = this.GachaArtBP;
		if (gachaArtBP == null)
		{
			return;
		}
		gachaArtBP.TSUpdateParameters(this.Value, colorChangeProcess, this.MousePosition);
	}

	// Token: 0x0600D895 RID: 55445 RVA: 0x0039FDC9 File Offset: 0x0039DFC9
	public void OnDragEndCallBack(ULGUIPointerEventData eventData)
	{
		this.IsDrag = false;
	}

	// Token: 0x0600D896 RID: 55446 RVA: 0x0039FDD4 File Offset: 0x0039DFD4
	public void PlayShowSequence()
	{
		this.GachaArtBP.SetActorHiddenInGame(true);
		base.GetButton(1).RootUIComp.Get().SetUIActive(true);
		(base.GetDraggable(0).GetOwner().GetComponentByClass(UUIItem.StaticClass()) as UUIItem).SetUIActive(false);
		ALevelSequenceActor showSequence = this.ShowSequence;
		if (showSequence == null)
		{
			return;
		}
		showSequence.SequencePlayer.Play();
	}

	// Token: 0x0600D897 RID: 55447 RVA: 0x0039FE44 File Offset: 0x0039E044
	public void ShowNextView()
	{
		ULevelSequencePlayer showSequencePlayer = this.ShowSequencePlayer;
		if (showSequencePlayer != null)
		{
			showSequencePlayer.Stop();
		}
		ControllerBase<CameraController>.Instance.SetViewTarget(this.OriginCameraActor, "ShowNextView", 0f, EViewTargetBlendFunction.VTBlend_Linear, 0f, null, null, "MainCamera", null, null);
		base.CloseMe(null);
		Singleton<UiManager>.Instance.OpenView(EUiViewName.GachaScanView, null, null);
	}

	// Token: 0x04006753 RID: 26451
	private ALevelSequenceActor ShowSequence;

	// Token: 0x04006754 RID: 26452
	private readonly ULevelSequencePlayer ShowSequencePlayer;

	// Token: 0x04006755 RID: 26453
	[Nullable(1)]
	private string ShowSequencePath = "";

	// Token: 0x04006756 RID: 26454
	private AActor OriginCameraActor;

	// Token: 0x04006757 RID: 26455
	private BP_GachaArt_C GachaArtBP;

	// Token: 0x04006758 RID: 26456
	private float Value;

	// Token: 0x04006759 RID: 26457
	private float PlaySequenceProcess;

	// Token: 0x0400675A RID: 26458
	private float DefaultProcess;

	// Token: 0x0400675B RID: 26459
	private float ChangeColorProcess;

	// Token: 0x0400675C RID: 26460
	private FVector? BeginDragPosition;

	// Token: 0x0400675D RID: 26461
	private float CompleteChangeColorProcess;

	// Token: 0x0400675E RID: 26462
	private FLinearColor? FinalColor;

	// Token: 0x0400675F RID: 26463
	private FVector2D MousePosition = new FVector2D();

	// Token: 0x04006760 RID: 26464
	private float ScreenX;

	// Token: 0x04006761 RID: 26465
	private bool IsPlay;

	// Token: 0x04006762 RID: 26466
	public UCurveFloat SlideCurve;

	// Token: 0x04006763 RID: 26467
	private float StartValue;

	// Token: 0x04006764 RID: 26468
	private float BeginValue;

	// Token: 0x04006765 RID: 26469
	private bool IsLoadComplete;

	// Token: 0x04006766 RID: 26470
	private bool IsDone;

	// Token: 0x04006767 RID: 26471
	private bool IsSkip;

	// Token: 0x04006768 RID: 26472
	private float TipWaitTime;

	// Token: 0x04006769 RID: 26473
	private bool IsDrag;

	// Token: 0x0400676A RID: 26474
	private bool IsShowTips;

	// Token: 0x0400676B RID: 26475
	private LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x02008022 RID: 32802
	[NullableContext(0)]
	private enum EDrawMainViewDefine
	{
		// Token: 0x0402B98A RID: 178570
		DragArea,
		// Token: 0x0402B98B RID: 178571
		SkipBtn
	}
}
