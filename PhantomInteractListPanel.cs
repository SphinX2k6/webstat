using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020024DD RID: 9437
[NullableContext(1)]
[Nullable(0)]
public class PhantomInteractListPanel : UiPanelBase
{
	// Token: 0x1700175B RID: 5979
	// (get) Token: 0x06012513 RID: 75027 RVA: 0x00508AEF File Offset: 0x00506CEF
	// (set) Token: 0x06012514 RID: 75028 RVA: 0x00508AF7 File Offset: 0x00506CF7
	public bool UseLongPress { get; set; }

	// Token: 0x06012515 RID: 75029 RVA: 0x00508B00 File Offset: 0x00506D00
	public PhantomInteractListPanel(bool useLongPress)
	{
		this.UseLongPress = useLongPress;
	}

	// Token: 0x06012516 RID: 75030 RVA: 0x00508B40 File Offset: 0x00506D40
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIItem))
		};
	}

	// Token: 0x06012517 RID: 75031 RVA: 0x00508C20 File Offset: 0x00506E20
	protected override UniTask OnBeforeStartAsync()
	{
		PhantomInteractListPanel.<OnBeforeStartAsync>d__17 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<PhantomInteractListPanel.<OnBeforeStartAsync>d__17>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06012518 RID: 75032 RVA: 0x00508C64 File Offset: 0x00506E64
	private void RefreshLongPressItemPosition()
	{
		FVector? pointerEventDataPosition = Singleton<LguiEventSystemManager>.Instance.GetPointerEventDataPosition(0);
		Vector2D vector2D = Vector2D.Create((double)pointerEventDataPosition.Value.X, (double)pointerEventDataPosition.Value.Y);
		Vector2D vector2D2 = vector2D;
		ULGUICanvasScaler canvasScaler = Singleton<UiLayer>.Instance.UiRootItem.GetCanvasScaler();
		FVector2D fvector2D = vector2D.ToUeVector2D(false);
		vector2D2.FromUeVector2D(canvasScaler.ConvertPositionFromViewportToLGUICanvas(fvector2D));
		float offsetX = this.LongPressParam.OffsetX;
		float offsetY = this.LongPressParam.OffsetY;
		float inX = (float)vector2D.X + offsetX;
		float inY = (float)vector2D.Y + offsetY;
		UUIItem item = base.GetItem(8);
		FVector fvector = new FVector(inX, inY, 0f);
		item.SetLGUISpaceAbsolutePosition(fvector);
	}

	// Token: 0x06012519 RID: 75033 RVA: 0x00508D13 File Offset: 0x00506F13
	private void ClearDragClickTick()
	{
		if (this.LongPressTick != -1)
		{
			Singleton<TickSystem>.Instance.Remove(this.LongPressTick);
			this.LongPressTick = -1;
		}
	}

	// Token: 0x0601251A RID: 75034 RVA: 0x00508D36 File Offset: 0x00506F36
	protected override void OnBeforeDestroy()
	{
		this.ClearDragClickTick();
	}

	// Token: 0x0601251B RID: 75035 RVA: 0x00508D40 File Offset: 0x00506F40
	private void OnLongPressTick(float _)
	{
		ValueTuple<bool, bool> valueTuple = this.LongPressContext.Update(Singleton<Time>.Instance.DeltaTime);
		bool item = valueTuple.Item1;
		bool item2 = valueTuple.Item2;
		if (this.LongPressContext.IsBeforeLongPressThreshold())
		{
			return;
		}
		if (this.LongPressContext.CheckIsMoved())
		{
			this.OnListItemPointerUp(this.LongPressItemData);
			return;
		}
		if (item)
		{
			this.RefreshLongPressItemPosition();
		}
		if (this.LongPressContext.LongPressProgress < 1f)
		{
			PhantomInteractListLongPressPanel longPressPanel = this.LongPressPanel;
			if (longPressPanel != null)
			{
				longPressPanel.SetUiActive(true);
			}
			PhantomInteractListLongPressPanel longPressPanel2 = this.LongPressPanel;
			if (longPressPanel2 != null)
			{
				longPressPanel2.SetFillProgress(this.LongPressContext.LongPressProgress);
			}
		}
		else
		{
			PhantomInteractListLongPressPanel longPressPanel3 = this.LongPressPanel;
			if (longPressPanel3 != null)
			{
				longPressPanel3.SetUiActive(false);
			}
		}
		if (item2 && this.OnHoverCb != null && this.LongPressItemData != null)
		{
			this.OnHoverCb(this.LongPressItemData, true);
		}
	}

	// Token: 0x0601251C RID: 75036 RVA: 0x00508E19 File Offset: 0x00507019
	private void OnListItemClick(IPhantomInteractItemData itemData)
	{
		if (this.OnClickCb != null)
		{
			this.OnClickCb(itemData);
		}
	}

	// Token: 0x0601251D RID: 75037 RVA: 0x00508E2F File Offset: 0x0050702F
	private void OnListItemHover(IPhantomInteractItemData itemData, bool isHover)
	{
		if (this.OnHoverCb != null)
		{
			this.OnHoverCb(itemData, isHover);
		}
	}

	// Token: 0x0601251E RID: 75038 RVA: 0x00508E48 File Offset: 0x00507048
	private void OnListItemPointerDown(IPhantomInteractItemData itemData)
	{
		if (itemData.MonsterId <= 0)
		{
			return;
		}
		this.ClearDragClickTick();
		this.LongPressItemData = itemData;
		Ticker ticker = Singleton<TickSystem>.Instance.Add(new Action<float>(this.OnLongPressTick), "PhantomInteractDetailPressTick", ETickingGroup.TG_PrePhysics, true, 0, true);
		if (ticker != null)
		{
			this.LongPressTick = ticker.Id;
		}
		LongPressContext longPressContext = this.LongPressContext;
		if (longPressContext != null)
		{
			longPressContext.Reset();
		}
		LongPressContext longPressContext2 = this.LongPressContext;
		if (longPressContext2 != null)
		{
			longPressContext2.Start();
		}
		PhantomInteractListLongPressPanel longPressPanel = this.LongPressPanel;
		if (longPressPanel == null)
		{
			return;
		}
		longPressPanel.SetFillProgress(0f);
	}

	// Token: 0x0601251F RID: 75039 RVA: 0x00508ED4 File Offset: 0x005070D4
	private void OnListItemPointerUp(IPhantomInteractItemData itemData)
	{
		if (this.LongPressContext.IsBeforeLongPressThreshold())
		{
			if (this.OnClickCb != null)
			{
				this.OnClickCb(itemData);
			}
		}
		else if (this.OnHoverCb != null)
		{
			this.OnHoverCb(itemData, false);
		}
		this.ClearDragClickTick();
		this.LongPressItemData = null;
		PhantomInteractListLongPressPanel longPressPanel = this.LongPressPanel;
		if (longPressPanel != null)
		{
			longPressPanel.SetUiActive(false);
		}
		this.LongPressContext.Reset();
	}

	// Token: 0x06012520 RID: 75040 RVA: 0x00508F44 File Offset: 0x00507144
	private void OnListItemToggleChange(PhantomInteractListItem item, IPhantomInteractItemData itemData, bool isOn)
	{
		bool flag = itemData.ItemIndex == this.SelectIndex;
		if (isOn != flag)
		{
			item.SetSelected(flag);
		}
	}

	// Token: 0x06012521 RID: 75041 RVA: 0x00508F6C File Offset: 0x0050716C
	public void Refresh(List<IPhantomInteractItemData> itemDataList, bool showIndex, bool needAnim = true)
	{
		for (int i = 0; i < this.TogItems.Count; i++)
		{
			IPhantomInteractItemData itemData = null;
			if (i < itemDataList.Count)
			{
				itemData = itemDataList[i];
			}
			this.TogItems[i].Refresh(itemData, showIndex, needAnim);
		}
	}

	// Token: 0x06012522 RID: 75042 RVA: 0x00508FB8 File Offset: 0x005071B8
	public void SetSelectedItem(int index)
	{
		this.SelectIndex = index;
		foreach (PhantomInteractListItem phantomInteractListItem in this.TogItems)
		{
			phantomInteractListItem.SetSelected(index == phantomInteractListItem.ItemIndex);
		}
	}

	// Token: 0x06012523 RID: 75043 RVA: 0x0050901C File Offset: 0x0050721C
	private static ILongPressParam LoadLongPressParam()
	{
		return new LongPressParam
		{
			BeforeLongPressThreshold = (float)ConfigCommonParamById.GetIntConfig("PhantomInteractBeforeLongPressTime").GetValueOrDefault(),
			LongPressThreshold = (float)ConfigCommonParamById.GetIntConfig("PhantomInteractLongPressTime").GetValueOrDefault(),
			InvalidMoveDistance = (float)ConfigCommonParamById.GetIntConfig("PhantomInteractLongPressMoveDistance").GetValueOrDefault(),
			OffsetX = ConfigCommonParamById.GetFloatConfig("VisionScrollerOffsetX").GetValueOrDefault(),
			OffsetY = ConfigCommonParamById.GetFloatConfig("VisionScrollerOffsetY").GetValueOrDefault()
		};
	}

	// Token: 0x04008EDF RID: 36575
	private PhantomInteractListPanel.EComponent[] allTogItems = new PhantomInteractListPanel.EComponent[]
	{
		PhantomInteractListPanel.EComponent.TogItemT1,
		PhantomInteractListPanel.EComponent.TogItemT2,
		PhantomInteractListPanel.EComponent.TogItemT3,
		PhantomInteractListPanel.EComponent.TogItemT4,
		PhantomInteractListPanel.EComponent.TogItemB1,
		PhantomInteractListPanel.EComponent.TogItemB2,
		PhantomInteractListPanel.EComponent.TogItemB3,
		PhantomInteractListPanel.EComponent.TogItemB4
	};

	// Token: 0x04008EE0 RID: 36576
	private readonly List<PhantomInteractListItem> TogItems = new List<PhantomInteractListItem>();

	// Token: 0x04008EE1 RID: 36577
	[Nullable(2)]
	private PhantomInteractListLongPressPanel LongPressPanel;

	// Token: 0x04008EE2 RID: 36578
	[Nullable(2)]
	private ILongPressParam LongPressParam;

	// Token: 0x04008EE3 RID: 36579
	[Nullable(2)]
	private LongPressContext LongPressContext;

	// Token: 0x04008EE4 RID: 36580
	private int LongPressTick = -1;

	// Token: 0x04008EE5 RID: 36581
	[Nullable(2)]
	private IPhantomInteractItemData LongPressItemData;

	// Token: 0x04008EE6 RID: 36582
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Action<IPhantomInteractItemData> OnClickCb;

	// Token: 0x04008EE7 RID: 36583
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Action<IPhantomInteractItemData, bool> OnHoverCb;

	// Token: 0x04008EE8 RID: 36584
	private int SelectIndex = -1;

	// Token: 0x020087E7 RID: 34791
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402DE9D RID: 188061
		TogItemT1,
		// Token: 0x0402DE9E RID: 188062
		TogItemT2,
		// Token: 0x0402DE9F RID: 188063
		TogItemT3,
		// Token: 0x0402DEA0 RID: 188064
		TogItemT4,
		// Token: 0x0402DEA1 RID: 188065
		TogItemB1,
		// Token: 0x0402DEA2 RID: 188066
		TogItemB2,
		// Token: 0x0402DEA3 RID: 188067
		TogItemB3,
		// Token: 0x0402DEA4 RID: 188068
		TogItemB4,
		// Token: 0x0402DEA5 RID: 188069
		ItemLongPress
	}
}
