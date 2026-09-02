using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02000FA3 RID: 4003
[NullableContext(1)]
[Nullable(0)]
public class ProjectionPhotoDragItem : ProjectionPhotoItem
{
	// Token: 0x0600666D RID: 26221 RVA: 0x0019C8F8 File Offset: 0x0019AAF8
	[NullableContext(2)]
	public ProjectionPhotoDragItem(string photoPath) : base(photoPath)
	{
	}

	// Token: 0x0600666E RID: 26222 RVA: 0x0019C901 File Offset: 0x0019AB01
	protected override void OnAfterShow()
	{
		base.OnAfterShow();
		UUIItem rootItem = this.RootItem;
		if (rootItem == null)
		{
			return;
		}
		rootItem.SetRaycastTarget(false);
	}

	// Token: 0x0600666F RID: 26223 RVA: 0x0019C91C File Offset: 0x0019AB1C
	public void StartDrag(ProjectionPhotoItem projectionPhotoItem, UTexture texture)
	{
		if (this._ownerItem != projectionPhotoItem && this._ownerItem != null)
		{
			Singleton<Log>.Instance.Error(ELogModule.SceneGameplay, ELogAuthor.CH, "[ProjectionPhotoDragItem.StartDrag]开始拖拽失败，当前已经在拖拽中", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		this._ownerItem = projectionPhotoItem;
		this.PhotoTexture.SetTexture(texture);
		this.UpdateDrag();
		base.SetHidden(false);
		Singleton<AudioSystem>.Instance.PostEvent("play_interact_Camera_ui_photo_pickup");
		Singleton<EventSystem>.Instance.Emit(EEventName.OnProjectionPhotoItemStartDrag);
	}

	// Token: 0x06006670 RID: 26224 RVA: 0x0019C998 File Offset: 0x0019AB98
	public void UpdateDrag()
	{
		if (this._ownerItem == null)
		{
			return;
		}
		FVector? pointerEventDataPosition = Singleton<LguiEventSystemManager>.Instance.GetPointerEventDataPosition(0);
		if (pointerEventDataPosition == null)
		{
			return;
		}
		FVector2D fvector2D = new FVector2D(pointerEventDataPosition.Value.X, pointerEventDataPosition.Value.Y);
		FVector2D fvector2D2 = Singleton<UiLayer>.Instance.UiRootItem.GetCanvasScaler().ConvertPositionFromViewportToLGUICanvas(fvector2D);
		UUIItem rootItem = this.RootItem;
		FVector fvector = new FVector(fvector2D2.X, fvector2D2.Y, 0f);
		rootItem.SetLGUISpaceAbsolutePosition(fvector);
	}

	// Token: 0x06006671 RID: 26225 RVA: 0x0019CA1E File Offset: 0x0019AC1E
	public void StopDrag()
	{
		this._ownerItem = null;
		base.SetHidden(true);
		Singleton<AudioSystem>.Instance.PostEvent("play_interact_Camera_ui_photo_putdown");
		Singleton<EventSystem>.Instance.Emit(EEventName.OnProjectionPhotoItemEndDrag);
	}

	// Token: 0x0400309C RID: 12444
	private const string START_DRAG_EVENT = "play_interact_Camera_ui_photo_pickup";

	// Token: 0x0400309D RID: 12445
	private const string STOP_DRAG_EVENT = "play_interact_Camera_ui_photo_putdown";

	// Token: 0x0400309E RID: 12446
	[Nullable(2)]
	private ProjectionPhotoItem _ownerItem;
}
