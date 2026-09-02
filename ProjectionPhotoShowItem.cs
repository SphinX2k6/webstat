using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using UnrealEngine;
using UnrealEngine.Extension;

// Token: 0x02000FA6 RID: 4006
[NullableContext(2)]
[Nullable(0)]
public class ProjectionPhotoShowItem : UiPanelBase
{
	// Token: 0x06006685 RID: 26245 RVA: 0x0019CE30 File Offset: 0x0019B030
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(1, typeof(UUITexture)),
			new ValueTuple<int, Type>(2, typeof(UUISprite)),
			new ValueTuple<int, Type>(3, typeof(UUISprite)),
			new ValueTuple<int, Type>(4, typeof(UUISprite))
		};
	}

	// Token: 0x06006686 RID: 26246 RVA: 0x0019CEB8 File Offset: 0x0019B0B8
	protected override UniTask OnBeforeStartAsync()
	{
		this.ButtonRoot = base.GetButton(0);
		this.NormalSprite = base.GetSprite(2);
		this.DragInSprite = base.GetSprite(3);
		this.PutSprite = base.GetSprite(4);
		(this.ButtonRoot.GetOwner().GetComponentByClass(UUIItem.StaticClass()) as UUIItem).SetRaycastTarget(true);
		this.SetHidden(false);
		return base.OnBeforeStartAsync();
	}

	// Token: 0x06006687 RID: 26247 RVA: 0x0019CF2C File Offset: 0x0019B12C
	protected override void OnStart()
	{
		base.OnStart();
		this.ButtonRoot.OnPointEnterCallBack.Bind(new Action(this.OnPointEnter));
		this.ButtonRoot.OnPointExitCallBack.Bind(new Action(this.OnPointExit));
		Singleton<EventSystem>.Instance.Add(EEventName.OnProjectionPhotoItemStartDrag, new Action(this.OnProjectionPhotoItemStartDrag));
		Singleton<EventSystem>.Instance.Add(EEventName.OnProjectionPhotoItemEndDrag, new Action(this.OnProjectionPhotoItemEndDrag));
		Singleton<EventSystem>.Instance.Add(EEventName.OnProjectionPhotoItemDragCancel, new Action(this.OnPointExit));
		this.UpdateRootScaleToMatch3D();
		Singleton<EventSystem>.Instance.Add(EEventName.UIViewPortSizeChanged, new Action(this.OnViewPortSizeChanged));
	}

	// Token: 0x06006688 RID: 26248 RVA: 0x0019CFEC File Offset: 0x0019B1EC
	protected override void OnBeforeDestroy()
	{
		base.OnBeforeDestroy();
		this.ButtonRoot.OnPointEnterCallBack.Unbind();
		this.ButtonRoot.OnPointExitCallBack.Unbind();
		Singleton<EventSystem>.Instance.Remove(EEventName.OnProjectionPhotoItemStartDrag, new Action(this.OnProjectionPhotoItemStartDrag));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnProjectionPhotoItemEndDrag, new Action(this.OnProjectionPhotoItemEndDrag));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnProjectionPhotoItemDragCancel, new Action(this.OnPointExit));
		Singleton<EventSystem>.Instance.Remove(EEventName.UIViewPortSizeChanged, new Action(this.OnViewPortSizeChanged));
	}

	// Token: 0x06006689 RID: 26249 RVA: 0x0019D08C File Offset: 0x0019B28C
	protected override void OnAfterShow()
	{
		base.OnAfterShow();
		this.SetHidden(this.IsHidden);
	}

	// Token: 0x0600668A RID: 26250 RVA: 0x0019D0A0 File Offset: 0x0019B2A0
	private void OnFinishDrag(bool inRange)
	{
		if (inRange)
		{
			this.SetState(ProjectionPhotoShowItem.State.Put);
			Singleton<EventSystem>.Instance.Emit(EEventName.OnProjectionPhotoFinishDrag);
			return;
		}
		this.SetState(ProjectionPhotoShowItem.State.Normal);
	}

	// Token: 0x0600668B RID: 26251 RVA: 0x0019D0C4 File Offset: 0x0019B2C4
	private void OnPointEnter()
	{
		if (!this.IsDragging)
		{
			return;
		}
		this.SetState(ProjectionPhotoShowItem.State.DragIn);
		this.InRange = true;
		Singleton<Log>.Instance.Info(ELogModule.LevelPlay, ELogAuthor.CH, "[ProjectionPhotoShowItem] OnPointEnter", default(ReadOnlySpan<ValueTuple<string, object>>));
	}

	// Token: 0x0600668C RID: 26252 RVA: 0x0019D104 File Offset: 0x0019B304
	private void OnPointExit()
	{
		if (!this.IsDragging)
		{
			return;
		}
		this.SetState(ProjectionPhotoShowItem.State.Normal);
		this.InRange = false;
		Singleton<Log>.Instance.Info(ELogModule.LevelPlay, ELogAuthor.CH, "[ProjectionPhotoShowItem] OnPointExit", default(ReadOnlySpan<ValueTuple<string, object>>));
	}

	// Token: 0x0600668D RID: 26253 RVA: 0x0019D144 File Offset: 0x0019B344
	public void SetHidden(bool isHidden)
	{
		this.IsHidden = isHidden;
		(this.ButtonRoot.GetOwner().GetComponentByClass(UUIItem.StaticClass()) as UUIItem).SetUIActive(!this.IsHidden);
	}

	// Token: 0x0600668E RID: 26254 RVA: 0x0019D17A File Offset: 0x0019B37A
	private void OnProjectionPhotoItemStartDrag()
	{
		this.IsDragging = true;
	}

	// Token: 0x0600668F RID: 26255 RVA: 0x0019D183 File Offset: 0x0019B383
	private void OnProjectionPhotoItemEndDrag()
	{
		this.OnFinishDrag(this.InRange);
		this.InRange = false;
		this.IsDragging = false;
	}

	// Token: 0x06006690 RID: 26256 RVA: 0x0019D1A0 File Offset: 0x0019B3A0
	private void SetState(ProjectionPhotoShowItem.State state)
	{
		switch (state)
		{
		case ProjectionPhotoShowItem.State.Normal:
			this.NormalSprite.SetUIActive(true);
			this.DragInSprite.SetUIActive(false);
			this.PutSprite.SetUIActive(false);
			return;
		case ProjectionPhotoShowItem.State.DragIn:
			this.NormalSprite.SetUIActive(false);
			this.DragInSprite.SetUIActive(true);
			this.PutSprite.SetUIActive(false);
			return;
		case ProjectionPhotoShowItem.State.Put:
			this.NormalSprite.SetUIActive(false);
			this.DragInSprite.SetUIActive(false);
			this.PutSprite.SetUIActive(true);
			return;
		default:
			return;
		}
	}

	// Token: 0x06006691 RID: 26257 RVA: 0x0019D22E File Offset: 0x0019B42E
	private void OnViewPortSizeChanged()
	{
		this.UpdateRootScaleToMatch3D();
	}

	// Token: 0x06006692 RID: 26258 RVA: 0x0019D238 File Offset: 0x0019B438
	private unsafe void UpdateRootScaleToMatch3D()
	{
		if (this.RootItem == null)
		{
			return;
		}
		UWorld world = GlobalData.World;
		if (world == null)
		{
			return;
		}
		Vector2D viewportSize = LGuiExtension.GetViewportSize();
		if (viewportSize.X <= 0.0 || viewportSize.Y <= 0.0)
		{
			return;
		}
		float num = 1.7777778f;
		double num2 = viewportSize.X / viewportSize.Y;
		double num3 = (double)num / Math.Min(num2, (double)num);
		this.RootItem.SetUIItemScale(new FVector((float)num3, (float)num3, 1f));
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.LevelPlay;
		ELogAuthor author = ELogAuthor.CH;
		string message = "[ProjectionPhotoShowItem] UpdateRootScaleToMatch3D";
		<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
		ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0);
		string item = "viewport";
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
		defaultInterpolatedStringHandler.AppendFormatted<double>(viewportSize.X);
		defaultInterpolatedStringHandler.AppendLiteral("x");
		defaultInterpolatedStringHandler.AppendFormatted<double>(viewportSize.Y);
		ptr = new ValueTuple<string, object>(item, defaultInterpolatedStringHandler.ToStringAndClear());
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("currentAspect", num2);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("baselineAspect", num);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("correction", num3);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
		string value = num2.ToString("F3");
		string value2 = num3.ToString("F3");
		defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
		defaultInterpolatedStringHandler.AppendFormatted<double>(viewportSize.X);
		defaultInterpolatedStringHandler.AppendLiteral("x");
		defaultInterpolatedStringHandler.AppendFormatted<double>(viewportSize.Y);
		string value3 = defaultInterpolatedStringHandler.ToStringAndClear();
		defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(33, 3);
		defaultInterpolatedStringHandler.AppendLiteral("[Viewport] ");
		defaultInterpolatedStringHandler.AppendFormatted(value3);
		defaultInterpolatedStringHandler.AppendLiteral("  aspect=");
		defaultInterpolatedStringHandler.AppendFormatted(value);
		defaultInterpolatedStringHandler.AppendLiteral("  correction=");
		defaultInterpolatedStringHandler.AppendFormatted(value2);
		string inString = defaultInterpolatedStringHandler.ToStringAndClear();
		UKismetSystemLibrary.PrintString(world, inString, true, false, new FLinearColor?(new FLinearColor(1f, 1f, 0f, 1f)), 5f);
	}

	// Token: 0x040030A7 RID: 12455
	private const float BaselineWidth = 1920f;

	// Token: 0x040030A8 RID: 12456
	private const float BaselineHeight = 1080f;

	// Token: 0x040030A9 RID: 12457
	private const float DebugPrintDurationSec = 5f;

	// Token: 0x040030AA RID: 12458
	[Nullable(1)]
	private const string DebugPrintDecimals = "F3";

	// Token: 0x040030AB RID: 12459
	private UUIButtonComponent ButtonRoot;

	// Token: 0x040030AC RID: 12460
	private UUISprite NormalSprite;

	// Token: 0x040030AD RID: 12461
	private UUISprite DragInSprite;

	// Token: 0x040030AE RID: 12462
	private UUISprite PutSprite;

	// Token: 0x040030AF RID: 12463
	private bool IsHidden = true;

	// Token: 0x040030B0 RID: 12464
	private bool InRange;

	// Token: 0x040030B1 RID: 12465
	private bool IsDragging;

	// Token: 0x0200739D RID: 29597
	[NullableContext(0)]
	private enum EViewComponent
	{
		// Token: 0x0402802B RID: 163883
		Root,
		// Token: 0x0402802C RID: 163884
		TexPhoto,
		// Token: 0x0402802D RID: 163885
		SprNormal,
		// Token: 0x0402802E RID: 163886
		SprDragIn,
		// Token: 0x0402802F RID: 163887
		SprPut
	}

	// Token: 0x0200739E RID: 29598
	[NullableContext(0)]
	private enum State
	{
		// Token: 0x04028031 RID: 163889
		Normal,
		// Token: 0x04028032 RID: 163890
		DragIn,
		// Token: 0x04028033 RID: 163891
		Put
	}
}
