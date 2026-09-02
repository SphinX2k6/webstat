using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Activity.ActivityContent.MoonChasing;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020013A1 RID: 5025
[NullableContext(1)]
[Nullable(0)]
public class BuildingMainModule : UiPanelBase
{
	// Token: 0x06008A68 RID: 35432 RVA: 0x00247154 File Offset: 0x00245354
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIDraggableComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUISliderComponent)),
			new ValueTuple<int, Type>(3, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(4, typeof(UUIButtonComponent))
		};
	}

	// Token: 0x06008A69 RID: 35433 RVA: 0x002471DC File Offset: 0x002453DC
	private UniTask InitMapTile()
	{
		BuildingMainModule.<InitMapTile>d__7 <InitMapTile>d__;
		<InitMapTile>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitMapTile>d__.<>4__this = this;
		<InitMapTile>d__.<>1__state = -1;
		<InitMapTile>d__.<>t__builder.Start<BuildingMainModule.<InitMapTile>d__7>(ref <InitMapTile>d__);
		return <InitMapTile>d__.<>t__builder.Task;
	}

	// Token: 0x06008A6A RID: 35434 RVA: 0x00247220 File Offset: 0x00245420
	private void InitMoveComponent()
	{
		this.MoveComponent = new BuildingMapMoveComponent(base.GetDraggable(0), true, true, false);
		this.MoveComponent.SetScaleSafeArea(0.44999998807907104, 0.6000000238418579);
		this.MoveComponent.SetChangeScaleCallback(new Action<ESetScaleSource>(this.OnChangeSlider));
	}

	// Token: 0x06008A6B RID: 35435 RVA: 0x00247278 File Offset: 0x00245478
	private void InitZoom()
	{
		this.Slider = base.GetSlider(2);
		this.Slider.SetMinValue((float)this.MoveComponent.MapScaleSafeArea.Min, false, false);
		this.Slider.SetMaxValue((float)this.MoveComponent.MapScaleSafeArea.Max, false, false);
		this.Slider.OnValueChangeCb.Bind(new Action<float>(this.OnSliderValueChange));
		this.Slider.SetValue((float)this.MoveComponent.MapScaleSafeArea.Min, true);
		this.ZoomIn = new LongPressButton(base.GetButton(3), delegate(float _)
		{
			this.OnZoomIn();
		}, 100);
		this.ZoomOut = new LongPressButton(base.GetButton(4), delegate(float _)
		{
			this.OnZoomOut();
		}, 100);
		UUIItem item = base.GetItem(1);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(false);
	}

	// Token: 0x06008A6C RID: 35436 RVA: 0x0024735C File Offset: 0x0024555C
	protected override UniTask OnBeforeStartAsync()
	{
		BuildingMainModule.<OnBeforeStartAsync>d__10 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<BuildingMainModule.<OnBeforeStartAsync>d__10>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06008A6D RID: 35437 RVA: 0x0024739F File Offset: 0x0024559F
	protected override void OnStart()
	{
		this.InitMoveComponent();
		this.InitZoom();
	}

	// Token: 0x06008A6E RID: 35438 RVA: 0x002473AD File Offset: 0x002455AD
	public void RefreshModule()
	{
		this.MapTile.RefreshRole();
	}

	// Token: 0x06008A6F RID: 35439 RVA: 0x002473BA File Offset: 0x002455BA
	protected override void OnBeforeShow()
	{
		this.MoveComponent.BindTouch();
		this.MoveComponent.AddGamepadEvent();
	}

	// Token: 0x06008A70 RID: 35440 RVA: 0x002473D2 File Offset: 0x002455D2
	protected override void OnAfterHide()
	{
		this.MoveComponent.UnbindTouch();
		this.MoveComponent.RemoveGamepadEvent();
	}

	// Token: 0x06008A71 RID: 35441 RVA: 0x002473EA File Offset: 0x002455EA
	protected override void OnBeforeDestroy()
	{
		this.MoveComponent.Destroy();
	}

	// Token: 0x06008A72 RID: 35442 RVA: 0x002473F7 File Offset: 0x002455F7
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
	{
		return this.MapTile.GetGuideUiItemAndUiItemForShowEx(configParams);
	}

	// Token: 0x06008A73 RID: 35443 RVA: 0x00247405 File Offset: 0x00245605
	private void OnChangeSlider(ESetScaleSource source)
	{
		if (source != ESetScaleSource.Slider)
		{
			this.Slider.SetValue((float)this.MoveComponent.MapScale, false);
		}
	}

	// Token: 0x06008A74 RID: 35444 RVA: 0x00247423 File Offset: 0x00245623
	private void OnZoomOut()
	{
		this.MoveComponent.LongPressScroll((float)(-(float)this.MoveComponent.ScaleStep));
	}

	// Token: 0x06008A75 RID: 35445 RVA: 0x0024743D File Offset: 0x0024563D
	private void OnZoomIn()
	{
		this.MoveComponent.LongPressScroll((float)this.MoveComponent.ScaleStep);
	}

	// Token: 0x06008A76 RID: 35446 RVA: 0x00247456 File Offset: 0x00245656
	private void OnSliderValueChange(float value)
	{
		this.MoveComponent.SliderScroll(value);
	}

	// Token: 0x06008A77 RID: 35447 RVA: 0x00247464 File Offset: 0x00245664
	public void HideBuildingModule()
	{
		UUIItem item = base.GetItem(1);
		if (item != null)
		{
			item.SetUIActive(false);
		}
		this.MapTile.SetBuildingItemActive(false);
	}

	// Token: 0x06008A78 RID: 35448 RVA: 0x00247485 File Offset: 0x00245685
	public void ShowBuilding()
	{
		UUIItem item = base.GetItem(1);
		if (item != null)
		{
			item.SetUIActive(true);
		}
		this.MapTile.SetBuildingItemActive(true);
	}

	// Token: 0x06008A79 RID: 35449 RVA: 0x002474A6 File Offset: 0x002456A6
	public void RefreshBuilding(int buildingId)
	{
		this.MapTile.RefreshBuildingItem(buildingId);
	}

	// Token: 0x040040D0 RID: 16592
	private BuildingMapTileModule MapTile;

	// Token: 0x040040D1 RID: 16593
	private BuildingMapMoveComponent MoveComponent;

	// Token: 0x040040D2 RID: 16594
	private UUISliderComponent Slider;

	// Token: 0x040040D3 RID: 16595
	protected LongPressButton ZoomIn;

	// Token: 0x040040D4 RID: 16596
	protected LongPressButton ZoomOut;

	// Token: 0x0200774D RID: 30541
	[NullableContext(0)]
	private static class EComponentDefine
	{
		// Token: 0x0402914C RID: 168268
		public const int MapItem = 0;

		// Token: 0x0402914D RID: 168269
		public const int ZoomItem = 1;

		// Token: 0x0402914E RID: 168270
		public const int ScaleSlider = 2;

		// Token: 0x0402914F RID: 168271
		public const int ZoomIn = 3;

		// Token: 0x04029150 RID: 168272
		public const int ZoomOut = 4;
	}
}
