using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02000FA4 RID: 4004
[NullableContext(2)]
[Nullable(0)]
public class ProjectionPhotoItem : UiPanelBase
{
	// Token: 0x06006672 RID: 26226 RVA: 0x0019CA4E File Offset: 0x0019AC4E
	public ProjectionPhotoItem(string photoPath)
	{
	}

	// Token: 0x06006673 RID: 26227 RVA: 0x0019CA64 File Offset: 0x0019AC64
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(1, typeof(UUITexture)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem))
		};
	}

	// Token: 0x06006674 RID: 26228 RVA: 0x0019CAD4 File Offset: 0x0019ACD4
	protected override UniTask OnBeforeStartAsync()
	{
		ProjectionPhotoItem.<OnBeforeStartAsync>d__11 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ProjectionPhotoItem.<OnBeforeStartAsync>d__11>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06006675 RID: 26229 RVA: 0x0019CB18 File Offset: 0x0019AD18
	protected override void OnStart()
	{
		this.ButtonRoot.OnPointerBeginDragCallBack.Bind(new Func<ULGUIPointerEventData, bool>(this.OnPointerBeginDrag));
		this.ButtonRoot.OnPointerDragCallBack.Bind(new Func<ULGUIPointerEventData, bool>(this.OnPointerDrag));
		this.ButtonRoot.OnPointerEndDragCallBack.Bind(new Func<ULGUIPointerEventData, bool>(this.OnPointerEndDrag));
		this.ButtonRoot.OnPointDownCallBack.Bind(new Action(this.OnPointDown));
		this.ButtonRoot.OnPointUpCallBack.Bind(new Action(this.OnPointUp));
	}

	// Token: 0x06006676 RID: 26230 RVA: 0x0019CBB4 File Offset: 0x0019ADB4
	protected override void OnBeforeDestroy()
	{
		this.ButtonRoot.OnPointerBeginDragCallBack.Unbind();
		this.ButtonRoot.OnPointerDragCallBack.Unbind();
		this.ButtonRoot.OnPointerEndDragCallBack.Unbind();
		this.ButtonRoot.OnPointDownCallBack.Unbind();
		this.ButtonRoot.OnPointUpCallBack.Unbind();
	}

	// Token: 0x06006677 RID: 26231 RVA: 0x0019CC14 File Offset: 0x0019AE14
	protected override void OnAfterShow()
	{
		base.OnAfterShow();
		this.SetHidden(this.IsHidden);
		UUIButtonComponent buttonRoot = this.ButtonRoot;
		if (buttonRoot != null)
		{
			buttonRoot.SetSelfInteractive(!this.IsDisable);
		}
		UUIItem grayItem = this.GrayItem;
		if (grayItem == null)
		{
			return;
		}
		grayItem.SetUIActive(this.IsDisable);
	}

	// Token: 0x06006678 RID: 26232 RVA: 0x0019CC64 File Offset: 0x0019AE64
	public void SetDisable(bool isDisable)
	{
		this.IsDisable = isDisable;
		UUIItem grayItem = this.GrayItem;
		if (grayItem != null)
		{
			grayItem.SetUIActive(isDisable);
		}
		UUIItem disableItem = this.DisableItem;
		if (disableItem != null)
		{
			disableItem.SetUIActive(this.IsDisable);
		}
		UUIButtonComponent buttonRoot = this.ButtonRoot;
		if (buttonRoot == null)
		{
			return;
		}
		buttonRoot.SetSelfInteractive(!isDisable);
	}

	// Token: 0x06006679 RID: 26233 RVA: 0x0019CCB5 File Offset: 0x0019AEB5
	public void SetHidden(bool isHidden)
	{
		this.IsHidden = isHidden;
		this.RootItem.SetUIActive(!isHidden);
	}

	// Token: 0x0600667A RID: 26234 RVA: 0x0019CCD0 File Offset: 0x0019AED0
	public UniTask SetPhoto(string photoPath)
	{
		ProjectionPhotoItem.<SetPhoto>d__17 <SetPhoto>d__;
		<SetPhoto>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<SetPhoto>d__.<>4__this = this;
		<SetPhoto>d__.photoPath = photoPath;
		<SetPhoto>d__.<>1__state = -1;
		<SetPhoto>d__.<>t__builder.Start<ProjectionPhotoItem.<SetPhoto>d__17>(ref <SetPhoto>d__);
		return <SetPhoto>d__.<>t__builder.Task;
	}

	// Token: 0x0600667B RID: 26235 RVA: 0x0019CD1B File Offset: 0x0019AF1B
	private bool OnPointerBeginDrag(ULGUIPointerEventData eventData)
	{
		if (this.IsDisable || this.DragItem == null || eventData == null)
		{
			return false;
		}
		this.DragItem.StartDrag(this, this.PhotoTexture.GetTexture());
		return true;
	}

	// Token: 0x0600667C RID: 26236 RVA: 0x0019CD4A File Offset: 0x0019AF4A
	private bool OnPointerDrag(ULGUIPointerEventData eventData)
	{
		if (this.IsDisable || this.DragItem == null || eventData == null)
		{
			return false;
		}
		this.DragItem.UpdateDrag();
		return true;
	}

	// Token: 0x0600667D RID: 26237 RVA: 0x0019CD6D File Offset: 0x0019AF6D
	private bool OnPointerEndDrag(ULGUIPointerEventData eventData)
	{
		if (this.IsDisable || this.DragItem == null)
		{
			return false;
		}
		this.DragItem.StopDrag();
		return true;
	}

	// Token: 0x0600667E RID: 26238 RVA: 0x0019CD8D File Offset: 0x0019AF8D
	[NullableContext(1)]
	public void SetDragItem(ProjectionPhotoDragItem dragItem)
	{
		this.DragItem = dragItem;
	}

	// Token: 0x0600667F RID: 26239 RVA: 0x0019CD96 File Offset: 0x0019AF96
	private void OnPointDown()
	{
		Singleton<EventSystem>.Instance.Emit(EEventName.OnProjectionPhotoItemPointDown);
	}

	// Token: 0x06006680 RID: 26240 RVA: 0x0019CDA8 File Offset: 0x0019AFA8
	private void OnPointUp()
	{
		Singleton<EventSystem>.Instance.Emit(EEventName.OnProjectionPhotoItemPointUp);
	}

	// Token: 0x0400309F RID: 12447
	[CompilerGenerated]
	private string <photoPath>P = photoPath;

	// Token: 0x040030A0 RID: 12448
	private UUIButtonComponent ButtonRoot;

	// Token: 0x040030A1 RID: 12449
	protected UUITexture PhotoTexture;

	// Token: 0x040030A2 RID: 12450
	private UUIItem DisableItem;

	// Token: 0x040030A3 RID: 12451
	private UUIItem GrayItem;

	// Token: 0x040030A4 RID: 12452
	private ProjectionPhotoDragItem DragItem;

	// Token: 0x040030A5 RID: 12453
	private bool IsDisable;

	// Token: 0x040030A6 RID: 12454
	private bool IsHidden = true;

	// Token: 0x02007399 RID: 29593
	[NullableContext(0)]
	private enum EViewComponent
	{
		// Token: 0x0402801C RID: 163868
		Root,
		// Token: 0x0402801D RID: 163869
		TexPhoto,
		// Token: 0x0402801E RID: 163870
		PnlDisable,
		// Token: 0x0402801F RID: 163871
		PnlGrayState
	}
}
