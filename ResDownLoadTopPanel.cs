using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.BattleUi;
using CSharpScript.Game.Module.BattleUi.Views;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002769 RID: 10089
public class ResDownLoadTopPanel : BattleVisibleChildView
{
	// Token: 0x06013E87 RID: 81543 RVA: 0x0058C1E0 File Offset: 0x0058A3E0
	protected unsafe override void OnRegisterComponent()
	{
		int num = 3;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.OnDownLoadBtnClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06013E88 RID: 81544 RVA: 0x0058C2A7 File Offset: 0x0058A4A7
	[NullableContext(1)]
	public override void Initialize(object param = null)
	{
		base.Initialize(param);
		base.InitChildType(EBattleUiChild.MiniMap);
		base.SetVisible(1, false);
	}

	// Token: 0x06013E89 RID: 81545 RVA: 0x0058C2BF File Offset: 0x0058A4BF
	public override void Reset()
	{
		base.Reset();
	}

	// Token: 0x06013E8A RID: 81546 RVA: 0x0058C2C7 File Offset: 0x0058A4C7
	private void AddEventListeners()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnRefreshSubPackDownLoadState, new Action(this.ResDownLoadStateRefresh));
		Singleton<EventSystem>.Instance.Add(EEventName.OnRefreshSubPackageDownLoadByPriority, new Action(this.ResDownLoadStateRefresh));
	}

	// Token: 0x06013E8B RID: 81547 RVA: 0x0058C301 File Offset: 0x0058A501
	private void RemoveEventListeners()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnRefreshSubPackDownLoadState, new Action(this.ResDownLoadStateRefresh));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnRefreshSubPackageDownLoadByPriority, new Action(this.ResDownLoadStateRefresh));
	}

	// Token: 0x06013E8C RID: 81548 RVA: 0x0058C33B File Offset: 0x0058A53B
	private void OnDownLoadBtnClick()
	{
		if (!Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.SubPackageDownLoadView))
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.SubPackageDownLoadView, null, null);
		}
	}

	// Token: 0x06013E8D RID: 81549 RVA: 0x0058C35F File Offset: 0x0058A55F
	private void ResDownLoadStateRefresh()
	{
		if (!ModelBase<SubPackageDownLoadModel>.Instance.NeedShowBattleViewButton())
		{
			this.EndShow();
			return;
		}
		this.Update();
	}

	// Token: 0x06013E8E RID: 81550 RVA: 0x0058C37A File Offset: 0x0058A57A
	public void Update()
	{
		this.Refresh();
	}

	// Token: 0x06013E8F RID: 81551 RVA: 0x0058C384 File Offset: 0x0058A584
	public void Refresh()
	{
		if (ModelBase<SubPackageDownLoadModel>.Instance.DownLoadingSubPackageId == 0 && ModelBase<SubPackageDownLoadModel>.Instance.PauseSubPackageId == 0)
		{
			base.GetText(2).SetUIActive(false);
			base.GetTexture(0).SetFillAmount(0f);
			return;
		}
		base.GetText(2).SetUIActive(true);
		UUITexture texture = base.GetTexture(0);
		ValueTuple<float, ESubPackageDownLoadState> valueTuple = ModelBase<SubPackageDownLoadModel>.Instance.DownLoadPercentage();
		texture.SetFillAmount(valueTuple.Item1);
		FColor? fcolor;
		if (valueTuple.Item2 == ESubPackageDownLoadState.DownLoading)
		{
			UUIItem texture2 = base.GetTexture(0);
			bool bUseChangeColor = false;
			fcolor = new FColor?(texture.changeColor);
			texture2.SetChangeColor(bUseChangeColor, fcolor);
			base.GetText(2).SetText(ModelBase<SubPackageDownLoadModel>.Instance.ByteConverter(ModelBase<SubPackageDownLoadModel>.Instance.GetSubPackageDownLoadSpeed()) + "/s", true);
			return;
		}
		UUIItem texture3 = base.GetTexture(0);
		bool bUseChangeColor2 = true;
		fcolor = new FColor?(texture.changeColor);
		texture3.SetChangeColor(bUseChangeColor2, fcolor);
		base.GetText(2).SetText(Math.Floor((double)valueTuple.Item1 * 100.0).ToString() + "%", true);
	}

	// Token: 0x06013E90 RID: 81552 RVA: 0x0058C494 File Offset: 0x0058A694
	public void StartShow()
	{
		this.Update();
		base.SetVisible(1, true);
		if (this.TimerHandle != null)
		{
			TimerSystem.GameplayTimeInstance.Remove(this.TimerHandle);
			this.TimerHandle = null;
		}
		this.TimerHandle = TimerSystem.GameplayTimeInstance.Forever(delegate(float _)
		{
			this.Update();
		}, (float)Singleton<TimeUtil>.Instance.InverseMillisecond, 1f, null, null, true);
	}

	// Token: 0x06013E91 RID: 81553 RVA: 0x0058C4FE File Offset: 0x0058A6FE
	public void EndShow()
	{
		base.SetVisible(1, false);
		if (this.TimerHandle != null)
		{
			TimerSystem.GameplayTimeInstance.Remove(this.TimerHandle);
			this.TimerHandle = null;
		}
	}

	// Token: 0x06013E92 RID: 81554 RVA: 0x0058C528 File Offset: 0x0058A728
	public void SetOtherHide(bool isHide)
	{
		base.SetVisible(2, !isHide);
	}

	// Token: 0x06013E93 RID: 81555 RVA: 0x0058C535 File Offset: 0x0058A735
	protected override void OnBeforeDestroy()
	{
		if (this.TimerHandle != null)
		{
			TimerSystem.GameplayTimeInstance.Remove(this.TimerHandle);
			this.TimerHandle = null;
		}
	}

	// Token: 0x06013E94 RID: 81556 RVA: 0x0058C557 File Offset: 0x0058A757
	protected override void OnBeforeShow()
	{
		this.AddEventListeners();
	}

	// Token: 0x06013E95 RID: 81557 RVA: 0x0058C55F File Offset: 0x0058A75F
	protected override void OnBeforeHide()
	{
		this.RemoveEventListeners();
	}

	// Token: 0x04009AE7 RID: 39655
	[Nullable(2)]
	private TimerHandle TimerHandle;

	// Token: 0x02008B20 RID: 35616
	private enum EVisibleReason
	{
		// Token: 0x0402EE98 RID: 192152
		Default = 1,
		// Token: 0x0402EE99 RID: 192153
		Other
	}

	// Token: 0x02008B21 RID: 35617
	private enum EComponentDefine
	{
		// Token: 0x0402EE9B RID: 192155
		DownLoadBarTexture,
		// Token: 0x0402EE9C RID: 192156
		DownLoadBtn,
		// Token: 0x0402EE9D RID: 192157
		Text
	}
}
