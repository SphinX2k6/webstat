using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using UnrealEngine;

// Token: 0x0200181D RID: 6173
[NullableContext(1)]
[Nullable(0)]
public class VisionRefineRefineTab : UiPanelBase, IGridProxy<VisionRefineRefineTabData>
{
	// Token: 0x17000E52 RID: 3666
	// (get) Token: 0x0600AFCA RID: 45002 RVA: 0x002EDDF9 File Offset: 0x002EBFF9
	// (set) Token: 0x0600AFCB RID: 45003 RVA: 0x002EDE01 File Offset: 0x002EC001
	[Nullable(new byte[]
	{
		2,
		1,
		1,
		1
	})]
	public IScrollViewDelegate<IGridProxy<VisionRefineRefineTabData>, VisionRefineRefineTabData> ScrollViewDelegate { [return: Nullable(new byte[]
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

	// Token: 0x17000E53 RID: 3667
	// (get) Token: 0x0600AFCC RID: 45004 RVA: 0x002EDE0A File Offset: 0x002EC00A
	// (set) Token: 0x0600AFCD RID: 45005 RVA: 0x002EDE12 File Offset: 0x002EC012
	public int GridIndex { get; set; }

	// Token: 0x17000E54 RID: 3668
	// (get) Token: 0x0600AFCE RID: 45006 RVA: 0x002EDE1B File Offset: 0x002EC01B
	// (set) Token: 0x0600AFCF RID: 45007 RVA: 0x002EDE23 File Offset: 0x002EC023
	public int DisplayIndex { get; set; }

	// Token: 0x0600AFD0 RID: 45008 RVA: 0x002EDE2C File Offset: 0x002EC02C
	public void Refresh(VisionRefineRefineTabData data, bool isSelected, int gridIndex)
	{
		this.DataCache = data;
		if (data.TabTextId != null)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), data.TabTextId, Array.Empty<object>());
		}
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle != null)
		{
			if (!extendToggle.CanExecuteChange.IsBound())
			{
				extendToggle.CanExecuteChange.Bind(new Func<bool>(this.OnCanChangeExecute));
			}
			extendToggle.SetToggleStateForce(data.IsChosen ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
		}
	}

	// Token: 0x0600AFD1 RID: 45009 RVA: 0x002EDEA8 File Offset: 0x002EC0A8
	public UniTask RefreshAsync(VisionRefineRefineTabData data, bool isSelected, int gridIndex)
	{
		this.Refresh(data, isSelected, gridIndex);
		return UniTask.CompletedTask;
	}

	// Token: 0x0600AFD2 RID: 45010 RVA: 0x002EDEB8 File Offset: 0x002EC0B8
	public void Clear()
	{
		this.DataCache = null;
		this.DisplayIndex = 0;
		this.GridIndex = 0;
	}

	// Token: 0x0600AFD3 RID: 45011 RVA: 0x002EDED0 File Offset: 0x002EC0D0
	public void OnSelected(bool fireEvent)
	{
		if (this.DataCache != null)
		{
			this.DataCache.IsChosen = true;
		}
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle != null)
		{
			extendToggle.SetToggleStateForce(EToggleState.ETT_Checked, fireEvent, false, false);
		}
	}

	// Token: 0x0600AFD4 RID: 45012 RVA: 0x002EDF08 File Offset: 0x002EC108
	public void OnDeselected(bool fireEvent)
	{
		if (this.DataCache != null)
		{
			this.DataCache.IsChosen = false;
		}
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle != null)
		{
			extendToggle.SetToggleStateForce(EToggleState.ETT_UnChecked, fireEvent, false, false);
		}
	}

	// Token: 0x0600AFD5 RID: 45013 RVA: 0x002EDF3E File Offset: 0x002EC13E
	[return: Nullable(2)]
	public object GetKey(VisionRefineRefineTabData data, int gridIndex)
	{
		return data;
	}

	// Token: 0x0600AFD6 RID: 45014 RVA: 0x002EDF44 File Offset: 0x002EC144
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

	// Token: 0x0600AFD7 RID: 45015 RVA: 0x002EDFAB File Offset: 0x002EC1AB
	private void OnClick(EToggleState toggleState)
	{
		VisionRefineRefineTabData dataCache = this.DataCache;
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

	// Token: 0x0600AFD8 RID: 45016 RVA: 0x002EDFC7 File Offset: 0x002EC1C7
	private bool OnCanChangeExecute()
	{
		VisionRefineRefineTabData dataCache = this.DataCache;
		return ((dataCache != null) ? dataCache.CanChangeExecute : null) == null || this.DataCache.CanChangeExecute(this.DataCache.RefineType);
	}

	// Token: 0x0600AFD9 RID: 45017 RVA: 0x002EDFFC File Offset: 0x002EC1FC
	public bool CheckChosen(EVisionRefineRefineType currentChosen)
	{
		VisionRefineRefineTabData dataCache = this.DataCache;
		EVisionRefineRefineType? evisionRefineRefineType = (dataCache != null) ? new EVisionRefineRefineType?(dataCache.RefineType) : null;
		return currentChosen == evisionRefineRefineType.GetValueOrDefault() & evisionRefineRefineType != null;
	}

	// Token: 0x04005353 RID: 21331
	[Nullable(2)]
	private VisionRefineRefineTabData DataCache;

	// Token: 0x02007BA0 RID: 31648
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402A412 RID: 173074
		Toggle,
		// Token: 0x0402A413 RID: 173075
		Text
	}
}
