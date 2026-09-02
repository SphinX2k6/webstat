using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Common;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002926 RID: 10534
[NullableContext(1)]
[Nullable(0)]
public abstract class RouletteComponentBase : UiPanelBase
{
	// Token: 0x06014E75 RID: 85621 RVA: 0x005C93B0 File Offset: 0x005C75B0
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIItem)),
			new ValueTuple<int, Type>(9, typeof(UUIItem)),
			new ValueTuple<int, Type>(10, typeof(UUIItem)),
			new ValueTuple<int, Type>(11, typeof(UUIItem))
		};
	}

	// Token: 0x06014E76 RID: 85622 RVA: 0x005C94D3 File Offset: 0x005C76D3
	protected override void OnStart()
	{
		base.GetItem(2).SetUIActive(false);
		base.GetItem(3).SetUIActive(false);
		this.SelectRingItem = base.GetItem(2);
	}

	// Token: 0x06014E77 RID: 85623 RVA: 0x005C94FC File Offset: 0x005C76FC
	protected override void OnBeforeDestroy()
	{
		this.SelectRingItem = null;
		this.TempRotator = null;
		this.DestroyGridList();
		if (this.AreaIndexToGridIndex != null)
		{
			this.AreaIndexToGridIndex.Clear();
			this.AreaIndexToGridIndex = null;
		}
		this.ToggleEventList = new List<Action<EToggleState>>();
	}

	// Token: 0x06014E78 RID: 85624 RVA: 0x005C953C File Offset: 0x005C773C
	public void Reset()
	{
		this.AreaIndex = 0;
		this.Angle = -1;
		this.RefreshRouletteComponent();
	}

	// Token: 0x06014E79 RID: 85625 RVA: 0x005C9554 File Offset: 0x005C7754
	private void RebuildGridList()
	{
		this.DestroyGridList();
		List<ValueTuple<List<int>, ERouletteComponentNode, ERouletteGridType>> rouletteInfoMap = this.GetRouletteInfoMap();
		if (rouletteInfoMap == null)
		{
			return;
		}
		int num = 0;
		Dictionary<ERouletteGridType, int> dictionary = new Dictionary<ERouletteGridType, int>
		{
			{
				ERouletteGridType.Explore,
				0
			},
			{
				ERouletteGridType.Function,
				0
			},
			{
				ERouletteGridType.EquipItem,
				0
			}
		};
		foreach (ValueTuple<List<int>, ERouletteComponentNode, ERouletteGridType> valueTuple in rouletteInfoMap)
		{
			foreach (int key in valueTuple.Item1)
			{
				if (this.AreaIndexToGridIndex != null)
				{
					this.AreaIndexToGridIndex[key] = num;
				}
			}
			ERouletteComponentNode item = valueTuple.Item2;
			ERouletteGridType item2 = valueTuple.Item3;
			int num2;
			if (!dictionary.TryGetValue(item2, out num2))
			{
				num2 = 0;
			}
			RouletteData rouletteData = new RouletteData();
			rouletteData.Id = this.GetGridId(num2, item2);
			rouletteData.GridIndex = num;
			rouletteData.DataIndex = num2;
			rouletteData.GridType = item2;
			UUIItem item3 = base.GetItem((int)item);
			RouletteGridBase generator = RouletteGridGenerator.GetGenerator(item2);
			generator.SetRootActor(item3.GetOwner(), true);
			this.GridDataDecorator(rouletteData);
			generator.RefreshGrid(rouletteData);
			bool flag = this.IsCurrentEquippedId(rouletteData);
			if (flag)
			{
				this.CurrentEquipGridIndex = rouletteData.GridIndex;
			}
			generator.SetGridEquipped(flag);
			this.InitGridEvent(generator);
			this.RouletteGridList.Add(generator);
			dictionary[item2] = num2 + 1;
			num++;
		}
	}

	// Token: 0x06014E7A RID: 85626 RVA: 0x005C9710 File Offset: 0x005C7910
	protected virtual int GetGridId(int index, ERouletteGridType gridType)
	{
		return 0;
	}

	// Token: 0x06014E7B RID: 85627 RVA: 0x005C9713 File Offset: 0x005C7913
	[return: Nullable(new byte[]
	{
		2,
		0,
		1
	})]
	protected virtual List<ValueTuple<List<int>, ERouletteComponentNode, ERouletteGridType>> GetRouletteInfoMap()
	{
		return null;
	}

	// Token: 0x06014E7C RID: 85628 RVA: 0x005C9718 File Offset: 0x005C7918
	protected virtual void InitGridEvent(RouletteGridBase grid)
	{
		foreach (Action<EToggleState> eventHandler in this.ToggleEventList)
		{
			grid.AddToggleStateChangeEvent(eventHandler);
		}
	}

	// Token: 0x06014E7D RID: 85629 RVA: 0x005C976C File Offset: 0x005C796C
	protected virtual RouletteData GridDataDecorator(RouletteData data)
	{
		data.State = this.JudgeGridStateByData(data.Id, data.GridType);
		return data;
	}

	// Token: 0x06014E7E RID: 85630 RVA: 0x005C9788 File Offset: 0x005C7988
	public void AddAllGridToggleCanExecuteChangeEvent(Func<RouletteData, EToggleState, bool> onItemClicked)
	{
		foreach (RouletteGridBase rouletteGridBase in this.RouletteGridList)
		{
			rouletteGridBase.BindOnCanToggleExecuteChange(onItemClicked);
		}
	}

	// Token: 0x06014E7F RID: 85631 RVA: 0x005C97DC File Offset: 0x005C79DC
	protected virtual bool IsCurrentEquippedId(RouletteData gridData)
	{
		return false;
	}

	// Token: 0x06014E80 RID: 85632 RVA: 0x005C97DF File Offset: 0x005C79DF
	protected virtual EGridBehavior JudgeGridStateByData(int id, ERouletteGridType gridType)
	{
		return EGridBehavior.Normal;
	}

	// Token: 0x06014E81 RID: 85633 RVA: 0x005C97E4 File Offset: 0x005C79E4
	private void DestroyGridList()
	{
		foreach (RouletteGridBase rouletteGridBase in this.RouletteGridList)
		{
			rouletteGridBase.SetGridEquipped(false);
			rouletteGridBase.SetGridToggleState(false, true);
		}
		this.RouletteGridList = new List<RouletteGridBase>();
	}

	// Token: 0x06014E82 RID: 85634 RVA: 0x005C9848 File Offset: 0x005C7A48
	protected virtual void GamepadReturnEmptyGrid()
	{
	}

	// Token: 0x06014E83 RID: 85635 RVA: 0x005C984C File Offset: 0x005C7A4C
	protected void RefreshCurrentGridIndex(int newAreaIndex)
	{
		this.AreaIndex = newAreaIndex;
		if (this.AreaIndexToGridIndex == null)
		{
			return;
		}
		int currentGridIndex;
		if (this.AreaIndexToGridIndex.TryGetValue(this.AreaIndex, out currentGridIndex))
		{
			this.CurrentGridIndex = currentGridIndex;
			this.IsEmptyChoose = false;
			return;
		}
		if (Singleton<Info>.Instance.IsInGamepad())
		{
			this.GamepadReturnEmptyGrid();
			return;
		}
		this.CurrentGridIndex = -1;
		this.IsEmptyChoose = true;
	}

	// Token: 0x06014E84 RID: 85636 RVA: 0x005C98AE File Offset: 0x005C7AAE
	[NullableContext(2)]
	public RouletteGridBase GetCurrentGrid()
	{
		if (this.CurrentGridIndex == -1)
		{
			return null;
		}
		if (this.CurrentGridIndex >= 0 && this.CurrentGridIndex < this.RouletteGridList.Count)
		{
			return this.RouletteGridList[this.CurrentGridIndex];
		}
		return null;
	}

	// Token: 0x06014E85 RID: 85637 RVA: 0x005C98EC File Offset: 0x005C7AEC
	public void SetAllGridToggleSelfInteractive(bool bActive)
	{
		foreach (RouletteGridBase rouletteGridBase in this.RouletteGridList)
		{
			rouletteGridBase.SetToggleSelfInteractive(bActive);
		}
	}

	// Token: 0x06014E86 RID: 85638 RVA: 0x005C9940 File Offset: 0x005C7B40
	[NullableContext(0)]
	public ValueTuple<int, int> GetCurrentIndexAndAngle()
	{
		return new ValueTuple<int, int>(this.AreaIndex, this.Angle);
	}

	// Token: 0x06014E87 RID: 85639 RVA: 0x005C9953 File Offset: 0x005C7B53
	protected void RefreshRouletteComponent()
	{
		this.RefreshCurrentShowName();
		this.RefreshTips();
	}

	// Token: 0x06014E88 RID: 85640 RVA: 0x005C9964 File Offset: 0x005C7B64
	public void Refresh(int? newAreaIndex, int? newAngle)
	{
		if (newAreaIndex != null && this.AreaIndex != newAreaIndex.Value)
		{
			bool flag = this.AreaIndex == 0;
			Dictionary<int, int> areaIndexToGridIndex = this.AreaIndexToGridIndex;
			int num = (areaIndexToGridIndex != null) ? areaIndexToGridIndex.GetValueOrDefault(this.AreaIndex, -1) : -1;
			Dictionary<int, int> areaIndexToGridIndex2 = this.AreaIndexToGridIndex;
			int num2 = (areaIndexToGridIndex2 != null) ? areaIndexToGridIndex2.GetValueOrDefault(newAreaIndex.Value, -1) : -1;
			bool flag2 = num != num2;
			if (!flag && flag2)
			{
				this.SetCurrentToggleState(false);
			}
			this.RefreshCurrentGridIndex(newAreaIndex.Value);
			if (!this.IsEmptyChoose && flag2)
			{
				this.SetCurrentToggleState(true);
			}
			this.RefreshCurrentShowName();
			if (flag || this.IsEmptyChoose)
			{
				this.SetRingVisible(!this.IsEmptyChoose);
			}
			this.RefreshTips();
		}
		if (newAngle != null && this.Angle != newAngle.Value)
		{
			this.Angle = newAngle.Value;
			if (!this.IsEmptyChoose)
			{
				this.SetRingRotate(this.Angle);
			}
		}
	}

	// Token: 0x06014E89 RID: 85641 RVA: 0x005C9A61 File Offset: 0x005C7C61
	protected virtual void SetCurrentToggleState(bool bSelect)
	{
	}

	// Token: 0x06014E8A RID: 85642 RVA: 0x005C9A64 File Offset: 0x005C7C64
	private void SetRingRotate(int angle)
	{
		if (this.TempRotator == null || this.SelectRingItem == null)
		{
			return;
		}
		this.TempRotator = new FRotator?(new FRotator(this.TempRotator.Value.Pitch, (float)angle, this.TempRotator.Value.Roll));
		UUIItem selectRingItem = this.SelectRingItem;
		FRotator value = this.TempRotator.Value;
		selectRingItem.SetUIRelativeRotation(value);
	}

	// Token: 0x06014E8B RID: 85643 RVA: 0x005C9AD2 File Offset: 0x005C7CD2
	public void SetRingVisible(bool bVisible)
	{
		UUIItem selectRingItem = this.SelectRingItem;
		if (selectRingItem == null)
		{
			return;
		}
		selectRingItem.SetUIActive(bVisible);
	}

	// Token: 0x06014E8C RID: 85644 RVA: 0x005C9AE8 File Offset: 0x005C7CE8
	protected virtual void RefreshCurrentShowName()
	{
		RouletteGridBase currentGrid = this.GetCurrentGrid();
		string text;
		if (currentGrid == null)
		{
			text = null;
		}
		else
		{
			RouletteData data = currentGrid.Data;
			text = ((data != null) ? data.Name : null);
		}
		string text2 = text;
		text2 = (text2 ?? "Text_ProbeToolFunctionNotice2_Text");
		this.RefreshName(text2);
	}

	// Token: 0x06014E8D RID: 85645 RVA: 0x005C9B26 File Offset: 0x005C7D26
	protected void RefreshName(string textId)
	{
		base.GetText(0).ShowTextNew(textId);
	}

	// Token: 0x06014E8E RID: 85646 RVA: 0x005C9B35 File Offset: 0x005C7D35
	public void SetNameVisible(bool bVisible)
	{
		base.GetText(0).SetUIActive(bVisible);
	}

	// Token: 0x06014E8F RID: 85647 RVA: 0x005C9B44 File Offset: 0x005C7D44
	protected virtual void RefreshTips()
	{
	}

	// Token: 0x06014E90 RID: 85648 RVA: 0x005C9B48 File Offset: 0x005C7D48
	[NullableContext(2)]
	public void RefreshTipsByText(string tipsText, bool needReplace = false)
	{
		if (tipsText == null)
		{
			return;
		}
		UUIText text = base.GetText(1);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(text, tipsText, Array.Empty<object>());
	}

	// Token: 0x06014E91 RID: 85649 RVA: 0x005C9B72 File Offset: 0x005C7D72
	public void SetTipsActive(bool bActive)
	{
		base.GetText(1).SetUIActive(bActive);
	}

	// Token: 0x06014E92 RID: 85650 RVA: 0x005C9B81 File Offset: 0x005C7D81
	public void RefreshRouletteType()
	{
		this.RefreshRouletteItem();
		this.Reset();
		this.RebuildGridList();
	}

	// Token: 0x06014E93 RID: 85651 RVA: 0x005C9B95 File Offset: 0x005C7D95
	protected virtual void RefreshRouletteItem()
	{
	}

	// Token: 0x06014E94 RID: 85652 RVA: 0x005C9B97 File Offset: 0x005C7D97
	public void RefreshRoulettePlatformType()
	{
		this.Reset();
	}

	// Token: 0x06014E95 RID: 85653 RVA: 0x005C9B9F File Offset: 0x005C7D9F
	public void RefreshRouletteInputType()
	{
		this.Reset();
	}

	// Token: 0x0400A126 RID: 41254
	[Nullable(2)]
	private UUIItem SelectRingItem;

	// Token: 0x0400A127 RID: 41255
	protected int Angle = -1;

	// Token: 0x0400A128 RID: 41256
	protected int AreaIndex;

	// Token: 0x0400A129 RID: 41257
	private FRotator? TempRotator = new FRotator?(new FRotator(0f, 0f, 0f));

	// Token: 0x0400A12A RID: 41258
	protected int CurrentGridIndex = -1;

	// Token: 0x0400A12B RID: 41259
	protected int CurrentEquipGridIndex = -1;

	// Token: 0x0400A12C RID: 41260
	protected bool IsEmptyChoose = true;

	// Token: 0x0400A12D RID: 41261
	protected List<RouletteGridBase> RouletteGridList = new List<RouletteGridBase>();

	// Token: 0x0400A12E RID: 41262
	[Nullable(2)]
	protected Dictionary<int, int> AreaIndexToGridIndex = new Dictionary<int, int>();

	// Token: 0x0400A12F RID: 41263
	protected List<Action<EToggleState>> ToggleEventList = new List<Action<EToggleState>>();
}
