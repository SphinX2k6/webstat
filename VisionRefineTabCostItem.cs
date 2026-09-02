using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using UnrealEngine;

// Token: 0x02001826 RID: 6182
[NullableContext(1)]
[Nullable(0)]
public class VisionRefineTabCostItem : UiPanelBase, IGridProxy<VisionRefineTabCostItemData>
{
	// Token: 0x0600B00F RID: 45071 RVA: 0x002EED5F File Offset: 0x002ECF5F
	public void Clear()
	{
		this.DataCache = null;
		this.DisplayIndex = 0;
		this.GridIndex = 0;
	}

	// Token: 0x17000E58 RID: 3672
	// (get) Token: 0x0600B010 RID: 45072 RVA: 0x002EED76 File Offset: 0x002ECF76
	// (set) Token: 0x0600B011 RID: 45073 RVA: 0x002EED7E File Offset: 0x002ECF7E
	public int DisplayIndex { get; set; }

	// Token: 0x0600B012 RID: 45074 RVA: 0x002EED87 File Offset: 0x002ECF87
	[return: Nullable(2)]
	public object GetKey(VisionRefineTabCostItemData data, int gridIndex)
	{
		return data.CostType;
	}

	// Token: 0x17000E59 RID: 3673
	// (get) Token: 0x0600B013 RID: 45075 RVA: 0x002EED94 File Offset: 0x002ECF94
	// (set) Token: 0x0600B014 RID: 45076 RVA: 0x002EED9C File Offset: 0x002ECF9C
	public int GridIndex { get; set; }

	// Token: 0x0600B015 RID: 45077 RVA: 0x002EEDA8 File Offset: 0x002ECFA8
	public void OnDeselected(bool fireEvent)
	{
		if (this.DataCache != null)
		{
			this.DataCache.IsChosen = false;
		}
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle != null)
		{
			extendToggle.SetToggleState(EToggleState.ETT_UnChecked, fireEvent, false, false);
		}
	}

	// Token: 0x0600B016 RID: 45078 RVA: 0x002EEDE0 File Offset: 0x002ECFE0
	public void OnSelected(bool fireEvent)
	{
		if (this.DataCache != null)
		{
			this.DataCache.IsChosen = true;
		}
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle != null)
		{
			extendToggle.SetToggleState(EToggleState.ETT_Checked, fireEvent, false, false);
		}
	}

	// Token: 0x17000E5A RID: 3674
	// (get) Token: 0x0600B017 RID: 45079 RVA: 0x002EEE17 File Offset: 0x002ED017
	// (set) Token: 0x0600B018 RID: 45080 RVA: 0x002EEE1F File Offset: 0x002ED01F
	[Nullable(new byte[]
	{
		2,
		1,
		1,
		1
	})]
	public IScrollViewDelegate<IGridProxy<VisionRefineTabCostItemData>, VisionRefineTabCostItemData> ScrollViewDelegate { [return: Nullable(new byte[]
	{
		2,
		1,
		1,
		1
	})] get; [param: Nullable(new byte[]
	{
		2,
		1,
		1,
		1
	})] set; }

	// Token: 0x0600B019 RID: 45081 RVA: 0x002EEE28 File Offset: 0x002ED028
	public void Refresh(VisionRefineTabCostItemData data, bool isSelected, int gridIndex)
	{
		this.DataCache = data;
		if (data.TabTextId != null)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), data.TabTextId, Array.Empty<object>());
		}
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle != null)
		{
			extendToggle.SetToggleState(data.IsChosen ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
		}
	}

	// Token: 0x0600B01A RID: 45082 RVA: 0x002EEE81 File Offset: 0x002ED081
	public UniTask RefreshAsync(VisionRefineTabCostItemData data, bool isSelected, int gridIndex)
	{
		this.Refresh(data, isSelected, gridIndex);
		return UniTask.CompletedTask;
	}

	// Token: 0x0600B01B RID: 45083 RVA: 0x002EEE94 File Offset: 0x002ED094
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(1, typeof(UUIText))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClick))
		};
	}

	// Token: 0x0600B01C RID: 45084 RVA: 0x002EEEFB File Offset: 0x002ED0FB
	protected override void OnStart()
	{
		base.GetExtendToggle(0).bLockStateOnSelect = true;
	}

	// Token: 0x0600B01D RID: 45085 RVA: 0x002EEF0A File Offset: 0x002ED10A
	private void OnClick(EToggleState toggleState)
	{
		VisionRefineTabCostItemData dataCache = this.DataCache;
		if (dataCache == null)
		{
			return;
		}
		Action onClick = dataCache.OnClick;
		if (onClick == null)
		{
			return;
		}
		onClick();
	}

	// Token: 0x0600B01E RID: 45086 RVA: 0x002EEF28 File Offset: 0x002ED128
	public bool CheckChosen(EVisionRefineCostType currentChosen)
	{
		VisionRefineTabCostItemData dataCache = this.DataCache;
		EVisionRefineCostType? evisionRefineCostType = (dataCache != null) ? new EVisionRefineCostType?(dataCache.CostType) : null;
		return currentChosen == evisionRefineCostType.GetValueOrDefault() & evisionRefineCostType != null;
	}

	// Token: 0x0400537A RID: 21370
	[Nullable(2)]
	private VisionRefineTabCostItemData DataCache;

	// Token: 0x02007BAC RID: 31660
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402A45F RID: 173151
		Toggle,
		// Token: 0x0402A460 RID: 173152
		Text
	}
}
