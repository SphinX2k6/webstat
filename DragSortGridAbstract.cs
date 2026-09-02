using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002317 RID: 8983
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
public abstract class DragSortGridAbstract<TData> : GridProxyAbstract<TData>
{
	// Token: 0x06011144 RID: 69956
	protected abstract UUIDraggableComponent GetDraggableComp();

	// Token: 0x06011145 RID: 69957 RVA: 0x004B0D40 File Offset: 0x004AEF40
	protected override void OnStart()
	{
		UUIDraggableComponent draggableComp = this.GetDraggableComp();
		if (draggableComp != null)
		{
			draggableComp.OnPointerDragCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnDrag));
			draggableComp.OnPointerBeginDragCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnDragBegin));
			draggableComp.OnPointerEndDragCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnDragEnd));
			draggableComp.OnPointerDownCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnPointerDown));
			draggableComp.OnPointerUpCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnPointerUp));
			draggableComp.OnPointerCancelCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnPointerCancel));
		}
		this.OnStartImplement();
	}

	// Token: 0x06011146 RID: 69958 RVA: 0x004B0DEA File Offset: 0x004AEFEA
	private void OnDragBegin(ULGUIPointerEventData data)
	{
		Action<DragSortGridAbstract<TData>> onDragBeginCallback = this.OnDragBeginCallback;
		if (onDragBeginCallback == null)
		{
			return;
		}
		onDragBeginCallback(this);
	}

	// Token: 0x06011147 RID: 69959 RVA: 0x004B0DFD File Offset: 0x004AEFFD
	private void OnDragEnd(ULGUIPointerEventData data)
	{
		Action<DragSortGridAbstract<TData>> onDragEndCallback = this.OnDragEndCallback;
		if (onDragEndCallback == null)
		{
			return;
		}
		onDragEndCallback(this);
	}

	// Token: 0x06011148 RID: 69960 RVA: 0x004B0E10 File Offset: 0x004AF010
	private void OnDrag(ULGUIPointerEventData eventData)
	{
		Action<DragSortGridAbstract<TData>> onDragCallback = this.OnDragCallback;
		if (onDragCallback == null)
		{
			return;
		}
		onDragCallback(this);
	}

	// Token: 0x06011149 RID: 69961 RVA: 0x004B0E23 File Offset: 0x004AF023
	private void OnPointerDown(ULGUIPointerEventData data)
	{
		Action<DragSortGridAbstract<TData>> onPointerDownCallback = this.OnPointerDownCallback;
		if (onPointerDownCallback == null)
		{
			return;
		}
		onPointerDownCallback(this);
	}

	// Token: 0x0601114A RID: 69962 RVA: 0x004B0E36 File Offset: 0x004AF036
	private void OnPointerUp(ULGUIPointerEventData data)
	{
		Action<DragSortGridAbstract<TData>> onPointerUpCallback = this.OnPointerUpCallback;
		if (onPointerUpCallback == null)
		{
			return;
		}
		onPointerUpCallback(this);
	}

	// Token: 0x0601114B RID: 69963 RVA: 0x004B0E49 File Offset: 0x004AF049
	private void OnPointerCancel(ULGUIPointerEventData data)
	{
		Action<DragSortGridAbstract<TData>> onPointerUpCallback = this.OnPointerUpCallback;
		if (onPointerUpCallback == null)
		{
			return;
		}
		onPointerUpCallback(this);
	}

	// Token: 0x0601114C RID: 69964 RVA: 0x004B0E5C File Offset: 0x004AF05C
	public void RefreshDragPosition()
	{
		FVector? pointerEventDataPosition = Singleton<LguiEventSystemManager>.Instance.GetPointerEventDataPosition(0);
		Vector2D vector2D = Vector2D.Create((double)((pointerEventDataPosition != null) ? pointerEventDataPosition.GetValueOrDefault().X : 0f), (double)((pointerEventDataPosition != null) ? pointerEventDataPosition.GetValueOrDefault().Y : 0f));
		if (Singleton<UiLayer>.Instance.UiRootItem != null && Singleton<UiLayer>.Instance.UiRootItem.GetRootCanvas() != null)
		{
			Vector2D vector2D2 = vector2D;
			ULGUICanvasScaler canvasScaler = Singleton<UiLayer>.Instance.UiRootItem.GetCanvasScaler();
			FVector2D fvector2D = vector2D.ToUeVector2D(false);
			vector2D2.FromUeVector2D(canvasScaler.ConvertPositionFromViewportToLGUICanvas(fvector2D));
		}
		float inY = (float)vector2D.Y;
		UUIItem rootItem = this.RootItem;
		if (rootItem == null)
		{
			return;
		}
		FVector fvector = new FVector(this.RootItem.GetLGUISpaceAbsolutePosition().X, inY, 0f);
		rootItem.SetLGUISpaceAbsolutePosition(fvector);
	}

	// Token: 0x04008656 RID: 34390
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	public Action<DragSortGridAbstract<TData>> OnDragCallback;

	// Token: 0x04008657 RID: 34391
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	public Action<DragSortGridAbstract<TData>> OnDragBeginCallback;

	// Token: 0x04008658 RID: 34392
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	public Action<DragSortGridAbstract<TData>> OnDragEndCallback;

	// Token: 0x04008659 RID: 34393
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	public Action<DragSortGridAbstract<TData>> OnPointerDownCallback;

	// Token: 0x0400865A RID: 34394
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	public Action<DragSortGridAbstract<TData>> OnPointerUpCallback;

	// Token: 0x0400865B RID: 34395
	public DragSortGridData DragData;
}
