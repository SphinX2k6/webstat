using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Render;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using UnrealEngine;
using UnrealEngine.Extension;

// Token: 0x02000FA7 RID: 4007
[NullableContext(1)]
[Nullable(0)]
public class ProjectionPhotoSlider : UiPanelBase
{
	// Token: 0x06006694 RID: 26260 RVA: 0x0019D468 File Offset: 0x0019B668
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUINiagara)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUISprite)),
			new ValueTuple<int, Type>(3, typeof(UUISprite)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUINiagara)),
			new ValueTuple<int, Type>(6, typeof(UUINiagara)),
			new ValueTuple<int, Type>(7, typeof(UUINiagara))
		};
	}

	// Token: 0x06006695 RID: 26261 RVA: 0x0019D530 File Offset: 0x0019B730
	protected override UniTask OnBeforeStartAsync()
	{
		UUIItem rootItem = this.RootItem;
		object obj;
		if (rootItem == null)
		{
			obj = null;
		}
		else
		{
			AActor owner = rootItem.GetOwner();
			obj = ((owner != null) ? owner.GetComponentByClass(UUISliderComponent.StaticClass()) : null);
		}
		this.rootSlider = (obj as UUISliderComponent);
		UUISliderComponent uuisliderComponent = this.rootSlider;
		if (uuisliderComponent != null)
		{
			uuisliderComponent.SetValue(this.originValue, true);
		}
		if (this.rootSlider != null)
		{
			this.rootSlider.OnValueChangeCb.Bind(new Action<float>(this.OnValueChange));
			this.rootSlider.OnPointUpCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnPointUp));
		}
		this.niaBgPoint = base.GetUiNiagara(0);
		this.niaGlow = base.GetUiNiagara(5);
		UUINiagara uuiniagara = this.niaGlow;
		if (uuiniagara != null)
		{
			uuiniagara.SetUIActive(false);
		}
		this.niaRange = base.GetUiNiagara(7);
		UUINiagara uuiniagara2 = this.niaRange;
		if (uuiniagara2 != null)
		{
			uuiniagara2.SetUIActive(false);
		}
		this.ApplyNiaRangeAnchorByTarget();
		this.itemConfirm = base.GetItem(4);
		UUIItem uuiitem = this.itemConfirm;
		if (uuiitem != null)
		{
			uuiitem.SetUIActive(false);
		}
		this.cursorSprite = base.GetSprite(2);
		this.pointLineSprite = base.GetSprite(3);
		UUINiagara uuiniagara3 = this.niaBgPoint;
		if (uuiniagara3 != null)
		{
			uuiniagara3.SetNiagaraVarFloat("Offset", this.GetSliderOffsetValue(this.originValue));
		}
		UMaterialParameterCollection sceneCaptureParameterCollection = Singleton<RenderDataManager>.Instance.GetSceneCaptureParameterCollection();
		string key = this.isHorizontal ? "BlurIntensity" : "ColorSplitIntensity";
		if (sceneCaptureParameterCollection != null)
		{
			UKismetMaterialLibrary.SetScalarParameterValue(GlobalData.GameInstance.GetWorld(), sceneCaptureParameterCollection, FNameUtil.GetDynamicFName(key).Value, 0f);
		}
		Singleton<EventSystem>.Instance.Add(EEventName.OnProjectionPhotoFinishDrag, new Action(this.OnProjectionPhotoFinishDrag));
		if (!this.isHorizontal)
		{
			ControllerBase<InputDistributeController>.Instance.BindAxis("UiScroll1", new TInputHandle<float>(this.OnAxisInput));
		}
		else
		{
			ControllerBase<InputDistributeController>.Instance.BindAxes(new string[]
			{
				"UiIncrease",
				"UiReduce"
			}, new TInputHandle<float>(this.OnAxisInput));
		}
		this.sequencePlayer = new LevelSequencePlayer(this.RootItem);
		return base.OnBeforeStartAsync();
	}

	// Token: 0x06006696 RID: 26262 RVA: 0x0019D73E File Offset: 0x0019B93E
	protected override void OnAfterShow()
	{
		if (this.RootItem != null)
		{
			this.RootItem.SetUIActive(false);
		}
	}

	// Token: 0x06006697 RID: 26263 RVA: 0x0019D754 File Offset: 0x0019B954
	protected override void OnBeforeDestroy()
	{
		if (this.rootSlider != null)
		{
			this.rootSlider.OnValueChangeCb.Unbind();
			this.rootSlider.OnPointUpCallBack.Unbind();
		}
		if (!this.isHorizontal)
		{
			ControllerBase<InputDistributeController>.Instance.UnBindAxis("UiScroll1", new TInputHandle<float>(this.OnAxisInput));
		}
		else
		{
			ControllerBase<InputDistributeController>.Instance.UnBindAxes(new string[]
			{
				"UiIncrease",
				"UiReduce"
			}, new TInputHandle<float>(this.OnAxisInput));
		}
		Singleton<EventSystem>.Instance.Remove(EEventName.OnProjectionPhotoFinishDrag, new Action(this.OnProjectionPhotoFinishDrag));
		LevelSequencePlayer levelSequencePlayer = this.sequencePlayer;
		if (levelSequencePlayer != null)
		{
			levelSequencePlayer.Clear();
		}
		this.sequencePlayer = null;
	}

	// Token: 0x06006698 RID: 26264 RVA: 0x0019D80E File Offset: 0x0019BA0E
	public void SetConfig(float originValue, float targetValue, float sliderTolerance, bool isHorizontal)
	{
		this.originValue = originValue;
		this.targetValue = targetValue;
		this.sliderTolerance = sliderTolerance;
		this.isHorizontal = isHorizontal;
	}

	// Token: 0x06006699 RID: 26265 RVA: 0x0019D830 File Offset: 0x0019BA30
	private void OnValueChange(float value)
	{
		if (this.valueFirstChange && this.isHorizontal)
		{
			this.valueFirstChange = false;
			Singleton<EventSystem>.Instance.Emit(EEventName.OnHorizontalSliderValueFirstChange);
		}
		bool flag = this.finishFlag;
		this.finishFlag = (Math.Abs(value - this.targetValue) < this.sliderTolerance);
		if (flag != this.finishFlag)
		{
			this.PlayRangeSequence(this.finishFlag);
		}
		if (!flag && this.finishFlag)
		{
			Singleton<AudioSystem>.Instance.PostEvent("play_interact_camera_ui_slider_flash");
		}
		this.UpdateIndicatorChangeColor();
		float sliderOffsetValue = this.GetSliderOffsetValue(value);
		UUINiagara uuiniagara = this.niaBgPoint;
		if (uuiniagara != null)
		{
			uuiniagara.SetNiagaraVarFloat("Offset", sliderOffsetValue);
		}
		float normalizedDistance = this.GetNormalizedDistance(value, this.targetValue);
		UMaterialParameterCollection sceneCaptureParameterCollection = Singleton<RenderDataManager>.Instance.GetSceneCaptureParameterCollection();
		string key = this.isHorizontal ? "BlurIntensity" : "ColorSplitIntensity";
		if (sceneCaptureParameterCollection != null)
		{
			UKismetMaterialLibrary.SetScalarParameterValue(GlobalData.GameInstance.GetWorld(), sceneCaptureParameterCollection, FNameUtil.GetDynamicFName(key).Value, normalizedDistance);
		}
	}

	// Token: 0x0600669A RID: 26266 RVA: 0x0019D92A File Offset: 0x0019BB2A
	private void OnPointUp(ULGUIPointerEventData eventData)
	{
		this.FinishEffect();
	}

	// Token: 0x0600669B RID: 26267 RVA: 0x0019D934 File Offset: 0x0019BB34
	private void OnProjectionPhotoFinishDrag()
	{
		if (!this.IsDisabled() && this.RootItem != null)
		{
			this.RootItem.SetUIActive(true);
			this.valueFirstChange = true;
			UMaterialParameterCollection sceneCaptureParameterCollection = Singleton<RenderDataManager>.Instance.GetSceneCaptureParameterCollection();
			string key = this.isHorizontal ? "BlurIntensity" : "ColorSplitIntensity";
			float normalizedDistance = this.GetNormalizedDistance(this.originValue, this.targetValue);
			if (sceneCaptureParameterCollection != null)
			{
				UKismetMaterialLibrary.SetScalarParameterValue(GlobalData.GameInstance.GetWorld(), sceneCaptureParameterCollection, FNameUtil.GetDynamicFName(key).Value, normalizedDistance);
			}
		}
	}

	// Token: 0x0600669C RID: 26268 RVA: 0x0019D9BC File Offset: 0x0019BBBC
	private void PlayRangeSequence(bool isFinish)
	{
		LevelSequencePlayer levelSequencePlayer = this.sequencePlayer;
		if (levelSequencePlayer != null)
		{
			levelSequencePlayer.StopPlayingSequence(false, true);
		}
		LevelSequencePlayer levelSequencePlayer2 = this.sequencePlayer;
		if (levelSequencePlayer2 == null)
		{
			return;
		}
		levelSequencePlayer2.PlayLevelSequenceByName(isFinish ? "On" : "Off", false, null, false);
	}

	// Token: 0x0600669D RID: 26269 RVA: 0x0019DA08 File Offset: 0x0019BC08
	private void FinishEffect()
	{
		Singleton<EventSystem>.Instance.Emit(EEventName.OnProjectionPhotoSliderEndDrag);
		if (this.finishFlag)
		{
			UUINiagara uuiniagara = this.niaGlow;
			if (uuiniagara != null)
			{
				uuiniagara.SetUIActive(true);
			}
			UUISliderComponent uuisliderComponent = this.rootSlider;
			if (uuisliderComponent != null)
			{
				uuisliderComponent.SetSelfInteractive(false);
			}
			UUINiagara uuiniagara2 = this.niaBgPoint;
			if (uuiniagara2 != null)
			{
				uuiniagara2.SetAlpha(0.5f);
			}
			UUISprite uuisprite = this.cursorSprite;
			if (uuisprite != null)
			{
				bool bUseChangeColor = false;
				FColor? fcolor = new FColor?(this.cursorSprite.changeColor);
				uuisprite.SetChangeColor(bUseChangeColor, fcolor);
			}
			UUISprite uuisprite2 = this.pointLineSprite;
			if (uuisprite2 != null)
			{
				bool bUseChangeColor2 = false;
				FColor? fcolor = new FColor?(this.pointLineSprite.changeColor);
				uuisprite2.SetChangeColor(bUseChangeColor2, fcolor);
			}
			UUISprite uuisprite3 = this.cursorSprite;
			if (uuisprite3 != null)
			{
				uuisprite3.SetIsGray(true);
			}
			UUISprite uuisprite4 = this.pointLineSprite;
			if (uuisprite4 == null)
			{
				return;
			}
			uuisprite4.SetIsGray(true);
		}
	}

	// Token: 0x0600669E RID: 26270 RVA: 0x0019DAD8 File Offset: 0x0019BCD8
	private void OnAxisInput(string axisName, float value, InputIdentification _)
	{
		if (!base.GetActive())
		{
			return;
		}
		this.wasAxisInput = this.isAxisInput;
		if (this.isHorizontal)
		{
			if (axisName == "UiIncrease")
			{
				this.uiIncreaseAxisInput = (value != 0f);
			}
			else if (axisName == "UiReduce")
			{
				this.uiReduceAxisInput = (value != 0f);
			}
			this.isAxisInput = (this.uiIncreaseAxisInput || this.uiReduceAxisInput);
		}
		else
		{
			this.isAxisInput = (value != 0f);
		}
		if (this.wasAxisInput && !this.isAxisInput)
		{
			this.FinishEffect();
		}
	}

	// Token: 0x0600669F RID: 26271 RVA: 0x0019DB80 File Offset: 0x0019BD80
	private float GetSliderTrackWidth()
	{
		UUIItem sliderTrackUiItem = this.GetSliderTrackUiItem();
		float num = (sliderTrackUiItem != null) ? sliderTrackUiItem.GetWidth() : 0f;
		if (num <= 0f)
		{
			return 0f;
		}
		return num;
	}

	// Token: 0x060066A0 RID: 26272 RVA: 0x0019DBB4 File Offset: 0x0019BDB4
	[NullableContext(2)]
	private UUIItem GetSliderTrackUiItem()
	{
		UUISliderComponent uuisliderComponent = this.rootSlider;
		if (uuisliderComponent != null)
		{
			UUIItem uuiitem = ProjectionPhotoSlider.<GetSliderTrackUiItem>g__TryItem|33_0(uuisliderComponent.FillArea);
			if (uuiitem != null)
			{
				return uuiitem;
			}
			UUIItem uuiitem2 = ProjectionPhotoSlider.<GetSliderTrackUiItem>g__TryItem|33_0(uuisliderComponent.HandleArea);
			if (uuiitem2 != null)
			{
				return uuiitem2;
			}
			UUIItem uuiitem3 = ProjectionPhotoSlider.<GetSliderTrackUiItem>g__TryItem|33_0(uuisliderComponent.Fill);
			if (uuiitem3 != null)
			{
				return uuiitem3;
			}
		}
		return base.GetItem(1);
	}

	// Token: 0x060066A1 RID: 26273 RVA: 0x0019DC14 File Offset: 0x0019BE14
	private void ApplyNiaRangeAnchorByTarget()
	{
		if (this.IsDisabled() || this.niaRange == null)
		{
			return;
		}
		float sliderTrackWidth = this.GetSliderTrackWidth();
		if (sliderTrackWidth <= 0f)
		{
			return;
		}
		float num = this.isHorizontal ? 1f : 0.55f;
		float inX = (this.GetSliderOffsetValue(this.targetValue) - this.GetSliderOffsetValue(0.5f)) / num * sliderTrackWidth;
		FVector2D anchorOffset = this.niaRange.GetAnchorOffset();
		this.niaRange.SetAnchorOffset(new FVector2D(inX, anchorOffset.Y));
	}

	// Token: 0x060066A2 RID: 26274 RVA: 0x0019DC98 File Offset: 0x0019BE98
	private void UpdateIndicatorChangeColor()
	{
		bool flag = !this.finishFlag;
		UUISprite uuisprite = this.cursorSprite;
		FColor? fcolor;
		if (uuisprite != null)
		{
			bool bUseChangeColor = flag;
			fcolor = new FColor?(this.cursorSprite.changeColor);
			uuisprite.SetChangeColor(bUseChangeColor, fcolor);
		}
		UUISprite uuisprite2 = this.pointLineSprite;
		if (uuisprite2 == null)
		{
			return;
		}
		bool bUseChangeColor2 = flag;
		fcolor = new FColor?(this.pointLineSprite.changeColor);
		uuisprite2.SetChangeColor(bUseChangeColor2, fcolor);
	}

	// Token: 0x060066A3 RID: 26275 RVA: 0x0019DCF8 File Offset: 0x0019BEF8
	private bool IsDisabled()
	{
		return this.originValue == -1f && this.targetValue == -1f;
	}

	// Token: 0x060066A4 RID: 26276 RVA: 0x0019DD16 File Offset: 0x0019BF16
	private float GetSliderOffsetValue(float value)
	{
		if (!this.isHorizontal)
		{
			return 0.45f + value * 0.55f;
		}
		return value;
	}

	// Token: 0x060066A5 RID: 26277 RVA: 0x0019DD30 File Offset: 0x0019BF30
	private float GetNormalizedDistance(float value, float targetValue)
	{
		float num = Math.Max(targetValue, 1f - targetValue);
		return Math.Min(Math.Abs(value - targetValue) / num, 1f);
	}

	// Token: 0x060066A6 RID: 26278 RVA: 0x0019DD5F File Offset: 0x0019BF5F
	public bool IsFinish()
	{
		return this.IsDisabled() || this.finishFlag;
	}

	// Token: 0x060066A8 RID: 26280 RVA: 0x0019DD79 File Offset: 0x0019BF79
	[NullableContext(2)]
	[CompilerGenerated]
	internal static UUIItem <GetSliderTrackUiItem>g__TryItem|33_0(UUIItem item)
	{
		if (item == null || item.GetWidth() <= 0f)
		{
			return null;
		}
		return item;
	}

	// Token: 0x040030B2 RID: 12466
	private const float VerticalOffsetMin = 0.45f;

	// Token: 0x040030B3 RID: 12467
	private const string RIGHT_RANGE_AUDIO_EVENT = "play_interact_camera_ui_slider_flash";

	// Token: 0x040030B4 RID: 12468
	private float originValue;

	// Token: 0x040030B5 RID: 12469
	private float targetValue;

	// Token: 0x040030B6 RID: 12470
	private float sliderTolerance;

	// Token: 0x040030B7 RID: 12471
	private bool isHorizontal;

	// Token: 0x040030B8 RID: 12472
	private bool finishFlag;

	// Token: 0x040030B9 RID: 12473
	private bool valueFirstChange;

	// Token: 0x040030BA RID: 12474
	private bool isAxisInput;

	// Token: 0x040030BB RID: 12475
	private bool wasAxisInput;

	// Token: 0x040030BC RID: 12476
	private bool uiIncreaseAxisInput;

	// Token: 0x040030BD RID: 12477
	private bool uiReduceAxisInput;

	// Token: 0x040030BE RID: 12478
	[Nullable(2)]
	private LevelSequencePlayer sequencePlayer;

	// Token: 0x040030BF RID: 12479
	private UUISliderComponent rootSlider;

	// Token: 0x040030C0 RID: 12480
	private UUINiagara niaBgPoint;

	// Token: 0x040030C1 RID: 12481
	private UUINiagara niaGlow;

	// Token: 0x040030C2 RID: 12482
	private UUINiagara niaRange;

	// Token: 0x040030C3 RID: 12483
	private UUIItem itemConfirm;

	// Token: 0x040030C4 RID: 12484
	private UUISprite cursorSprite;

	// Token: 0x040030C5 RID: 12485
	private UUISprite pointLineSprite;

	// Token: 0x0200739F RID: 29599
	[NullableContext(0)]
	private enum EViewComponent
	{
		// Token: 0x04028035 RID: 163893
		NiaBgPoint,
		// Token: 0x04028036 RID: 163894
		PnlHandle,
		// Token: 0x04028037 RID: 163895
		SprCursor,
		// Token: 0x04028038 RID: 163896
		SprPointLine,
		// Token: 0x04028039 RID: 163897
		SprConfirm,
		// Token: 0x0402803A RID: 163898
		NiaGlow,
		// Token: 0x0402803B RID: 163899
		NiaCalibration,
		// Token: 0x0402803C RID: 163900
		NiaRange
	}
}
