using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001D91 RID: 7569
[NullableContext(2)]
[Nullable(0)]
public class TrapDefenseMachineSelectSlider : UiPanelBase
{
	// Token: 0x0600DF15 RID: 57109 RVA: 0x003C05AD File Offset: 0x003BE7AD
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUISliderComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIDraggableComponent))
		};
	}

	// Token: 0x0600DF16 RID: 57110 RVA: 0x003C05E8 File Offset: 0x003BE7E8
	protected override void OnStart()
	{
		this.Sequence = new UiSequencePlayer(base.GetRootItem());
		this.Slider = base.GetSlider(0);
		this.Slider.OnValueChangeCb.Bind(new Action<float>(this.OnTouchSliderValueChange));
		UUIDraggableComponent draggable = base.GetDraggable(1);
		draggable.OnPointerDownCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnTouchSliderPointerDown));
		draggable.OnPointerDragCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnTouchSliderDrag));
		draggable.OnPointerUpCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnTouchSliderPointerUp));
		draggable.OnPointerEndDragCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnTouchSliderEndDrag));
	}

	// Token: 0x0600DF17 RID: 57111 RVA: 0x003C0691 File Offset: 0x003BE891
	protected override void OnBeforeDestroy()
	{
		if (this.Sequence != null)
		{
			this.Sequence.Clear();
			this.Sequence = null;
		}
	}

	// Token: 0x0600DF18 RID: 57112 RVA: 0x003C06AD File Offset: 0x003BE8AD
	private void OnTouchSliderValueChange(float value)
	{
		Action<float> sliderValueChangeNotify = this.SliderValueChangeNotify;
		if (sliderValueChangeNotify == null)
		{
			return;
		}
		sliderValueChangeNotify(value);
	}

	// Token: 0x0600DF19 RID: 57113 RVA: 0x003C06C0 File Offset: 0x003BE8C0
	private void OnTouchSliderPointerDown(ULGUIPointerEventData eventData)
	{
		UiSequencePlayer sequence = this.Sequence;
		if (sequence != null)
		{
			sequence.StopSequenceByKey("ClickOut", false, true);
		}
		UiSequencePlayer sequence2 = this.Sequence;
		if (sequence2 != null)
		{
			sequence2.PlaySequence("Click", false, null);
		}
		this.Index = (double)((float)Math.Floor((double)this.Slider.Value));
		this.IsNeedEndAnim = true;
		FVector pointerPosition = eventData.pointerPosition;
		Singleton<LguiUtil>.Instance.ConvertPointerPositionToLguiPosition(pointerPosition, this.LastDragPos);
		Action sliderPointerDownNotify = this.SliderPointerDownNotify;
		if (sliderPointerDownNotify == null)
		{
			return;
		}
		sliderPointerDownNotify();
	}

	// Token: 0x0600DF1A RID: 57114 RVA: 0x003C0750 File Offset: 0x003BE950
	private void OnTouchSliderDrag(ULGUIPointerEventData eventData)
	{
		FVector pointerPosition = eventData.pointerPosition;
		Singleton<LguiUtil>.Instance.ConvertPointerPositionToLguiPosition(pointerPosition, this.CurDragPos);
		this.TempVector2D.DeepCopy(this.CurDragPos);
		this.TempVector2D.SubtractionEqual(this.LastDragPos);
		if (this.TempVector2D.X == 0.0)
		{
			return;
		}
		double num = this.TempVector2D.X * 0.02250000089406967 + this.Index;
		this.LastDragPos.DeepCopy(this.CurDragPos);
		if ((int)Math.Floor(num) == (int)this.Index)
		{
			this.Index = num;
			return;
		}
		this.Index = num;
		int num2 = (int)Math.Floor(this.Index);
		this.SetSliderValue((float)num2, true);
	}

	// Token: 0x0600DF1B RID: 57115 RVA: 0x003C0814 File Offset: 0x003BEA14
	private void OnTouchSliderPointerUp(ULGUIPointerEventData eventData)
	{
		if (!this.IsNeedEndAnim)
		{
			return;
		}
		this.IsNeedEndAnim = false;
		UiSequencePlayer sequence = this.Sequence;
		if (sequence != null)
		{
			sequence.StopSequenceByKey("Click", false, true);
		}
		UiSequencePlayer sequence2 = this.Sequence;
		if (sequence2 != null)
		{
			sequence2.PlaySequence("ClickOut", false, null);
		}
		Action sliderEndDragNotify = this.SliderEndDragNotify;
		if (sliderEndDragNotify == null)
		{
			return;
		}
		sliderEndDragNotify();
	}

	// Token: 0x0600DF1C RID: 57116 RVA: 0x003C087C File Offset: 0x003BEA7C
	private void OnTouchSliderEndDrag(ULGUIPointerEventData eventData)
	{
		if (!this.IsNeedEndAnim)
		{
			return;
		}
		this.IsNeedEndAnim = false;
		UiSequencePlayer sequence = this.Sequence;
		if (sequence != null)
		{
			sequence.PlaySequence("ClickOut", false, null);
		}
		Action sliderEndDragNotify = this.SliderEndDragNotify;
		if (sliderEndDragNotify == null)
		{
			return;
		}
		sliderEndDragNotify();
	}

	// Token: 0x0600DF1D RID: 57117 RVA: 0x003C08C9 File Offset: 0x003BEAC9
	public void SetSliderValue(float value, bool bFireEvent)
	{
		this.Slider.SetValue(value, bFireEvent);
	}

	// Token: 0x0600DF1E RID: 57118 RVA: 0x003C08D8 File Offset: 0x003BEAD8
	public void RefreshSliderMaxValue(float maxValue)
	{
		this.Slider.SetMaxValue(maxValue, true, false);
	}

	// Token: 0x04006B44 RID: 27460
	private const float INTERVAL = 0.0225f;

	// Token: 0x04006B45 RID: 27461
	protected UiSequencePlayer Sequence;

	// Token: 0x04006B46 RID: 27462
	protected double Index;

	// Token: 0x04006B47 RID: 27463
	[Nullable(1)]
	private readonly Vector2D LastDragPos = Vector2D.Create();

	// Token: 0x04006B48 RID: 27464
	[Nullable(1)]
	private readonly Vector2D CurDragPos = Vector2D.Create();

	// Token: 0x04006B49 RID: 27465
	[Nullable(1)]
	private readonly Vector2D TempVector2D = Vector2D.Create();

	// Token: 0x04006B4A RID: 27466
	private bool IsNeedEndAnim;

	// Token: 0x04006B4B RID: 27467
	[Nullable(1)]
	private UUISliderComponent Slider;

	// Token: 0x04006B4C RID: 27468
	public Action SliderPointerDownNotify;

	// Token: 0x04006B4D RID: 27469
	public Action<float> SliderValueChangeNotify;

	// Token: 0x04006B4E RID: 27470
	public Action SliderEndDragNotify;

	// Token: 0x02008125 RID: 33061
	[NullableContext(0)]
	private static class EComponentDefine
	{
		// Token: 0x0402BE7A RID: 179834
		public const int TouchSlider = 0;

		// Token: 0x0402BE7B RID: 179835
		public const int TouchSliderDrag = 1;
	}
}
