using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Activity.ActivityContent.MoonChasing;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020013F9 RID: 5113
[NullableContext(1)]
[Nullable(0)]
public class MoonChasingMemoryView : UiViewBase
{
	// Token: 0x06008DAF RID: 36271 RVA: 0x002538E2 File Offset: 0x00251AE2
	public MoonChasingMemoryView(UiViewInfo info) : base(info)
	{
	}

	// Token: 0x06008DB0 RID: 36272 RVA: 0x002538F8 File Offset: 0x00251AF8
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIDraggableComponent))
		};
	}

	// Token: 0x06008DB1 RID: 36273 RVA: 0x00253954 File Offset: 0x00251B54
	protected override UniTask OnBeforeStartAsync()
	{
		MoonChasingMemoryView.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<MoonChasingMemoryView.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06008DB2 RID: 36274 RVA: 0x00253997 File Offset: 0x00251B97
	protected override void OnStart()
	{
		this.CaptionItem = new PopupCaptionItem(base.GetItem(0));
		this.CaptionItem.SetCloseCallBack(delegate
		{
			base.CloseMe(null);
		});
	}

	// Token: 0x06008DB3 RID: 36275 RVA: 0x002539C4 File Offset: 0x00251BC4
	protected override void OnBeforeShow()
	{
		bool redDotVisible = ModelBase<MoonChasingModel>.Instance.CheckMemoryRedDotState();
		this.DetailBtn.SetRedDotVisible(redDotVisible);
	}

	// Token: 0x06008DB4 RID: 36276 RVA: 0x002539E8 File Offset: 0x00251BE8
	protected override void OnBeforeDestroy()
	{
		this.MoveComponent.Destroy();
	}

	// Token: 0x06008DB5 RID: 36277 RVA: 0x002539F5 File Offset: 0x00251BF5
	private void InitBtn()
	{
		this.DetailBtn = new ButtonItem(base.GetItem(1));
		this.DetailBtn.SetFunction(delegate(int _)
		{
			this.OnButtonJump();
		});
	}

	// Token: 0x06008DB6 RID: 36278 RVA: 0x00253A20 File Offset: 0x00251C20
	private void InitMoveComponent()
	{
		this.MoveComponent = new BuildingMapMoveComponent(base.GetDraggable(2), false, false, false);
		float valueOrDefault = ConfigCommonParamById.GetFloatConfig("MoonFiestaMapSizeParam").GetValueOrDefault(1f);
		this.MoveComponent.SetScaleSafeArea((double)valueOrDefault, 2.0);
		this.MoveComponent.SetScale((double)valueOrDefault, ESetScaleSource.Other, null);
	}

	// Token: 0x06008DB7 RID: 36279 RVA: 0x00253A80 File Offset: 0x00251C80
	private UniTask InitMapTile()
	{
		MoonChasingMemoryView.<InitMapTile>d__14 <InitMapTile>d__;
		<InitMapTile>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitMapTile>d__.<>4__this = this;
		<InitMapTile>d__.<>1__state = -1;
		<InitMapTile>d__.<>t__builder.Start<MoonChasingMemoryView.<InitMapTile>d__14>(ref <InitMapTile>d__);
		return <InitMapTile>d__.<>t__builder.Task;
	}

	// Token: 0x06008DB8 RID: 36280 RVA: 0x00253AC3 File Offset: 0x00251CC3
	private void OnButtonJump()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.MoonChasingMemoryDetailView, this.MemoryItemData, null);
		ModelBase<MoonChasingModel>.Instance.RemoveMemoryRedDot();
	}

	// Token: 0x04004209 RID: 16905
	[Nullable(2)]
	private BuildingMapTileModule MapTile;

	// Token: 0x0400420A RID: 16906
	private BuildingMapMoveComponent MoveComponent;

	// Token: 0x0400420B RID: 16907
	[Nullable(2)]
	private PopupCaptionItem CaptionItem;

	// Token: 0x0400420C RID: 16908
	private ButtonItem DetailBtn;

	// Token: 0x0400420D RID: 16909
	private List<IMemoryItemData> MemoryItemData = new List<IMemoryItemData>();

	// Token: 0x020077E7 RID: 30695
	[NullableContext(0)]
	private static class EComponents
	{
		// Token: 0x04029426 RID: 168998
		public const int Caption = 0;

		// Token: 0x04029427 RID: 168999
		public const int Button = 1;

		// Token: 0x04029428 RID: 169000
		public const int MapItem = 2;
	}
}
