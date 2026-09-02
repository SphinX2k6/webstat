using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002930 RID: 10544
[NullableContext(1)]
[Nullable(0)]
public class RouletteGridBase : UiPanelBase
{
	// Token: 0x06014EF7 RID: 85751 RVA: 0x005CB3E8 File Offset: 0x005C95E8
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUITexture)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIExtendToggleSpriteTransition)),
			new ValueTuple<int, Type>(6, typeof(UUISprite)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIItem)),
			new ValueTuple<int, Type>(9, typeof(UUIText)),
			new ValueTuple<int, Type>(10, typeof(UUIText)),
			new ValueTuple<int, Type>(11, typeof(UUIItem))
		};
	}

	// Token: 0x06014EF8 RID: 85752 RVA: 0x005CB50C File Offset: 0x005C970C
	protected override void OnStart()
	{
		this.IsIconTexture = false;
		ULGUIBehaviour uiExtendToggleSpriteTransition = base.GetUiExtendToggleSpriteTransition(5);
		UUITexture texture = base.GetTexture(2);
		uiExtendToggleSpriteTransition.RootUIComp.Get().SetUIActive(false);
		texture.SetUIActive(false);
		this.Toggle = base.GetExtendToggle(0);
		this.Toggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
		this.Toggle.CanExecuteChange.Bind(new Func<bool>(this.CanToggleExecuteChange));
		this.SetGridEquipped(false);
		this.SetRedDotVisible(false);
	}

	// Token: 0x06014EF9 RID: 85753 RVA: 0x005CB590 File Offset: 0x005C9790
	protected override void OnBeforeDestroy()
	{
		this.UnBindRedDot();
		this.Data = null;
		UUIExtendToggle toggle = this.Toggle;
		if (toggle != null)
		{
			toggle.CanExecuteChange.Unbind();
		}
		this.Toggle = null;
	}

	// Token: 0x06014EFA RID: 85754 RVA: 0x005CB5BC File Offset: 0x005C97BC
	protected virtual UniTask Init()
	{
		return UniTask.CompletedTask;
	}

	// Token: 0x06014EFB RID: 85755 RVA: 0x005CB5C3 File Offset: 0x005C97C3
	public bool IsDataValid()
	{
		return this.Data != null && this.Data.Id != 0;
	}

	// Token: 0x06014EFC RID: 85756 RVA: 0x005CB5E0 File Offset: 0x005C97E0
	public void RefreshGrid(RouletteData data)
	{
		this.Data = data;
		this.HideBeforeRefreshState();
		UiAsyncTask task = new UiAsyncTask("RouletteGridBase.RefreshGrid", delegate()
		{
			RouletteGridBase.<<RefreshGrid>b__9_0>d <<RefreshGrid>b__9_0>d;
			<<RefreshGrid>b__9_0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<<RefreshGrid>b__9_0>d.<>4__this = this;
			<<RefreshGrid>b__9_0>d.<>1__state = -1;
			<<RefreshGrid>b__9_0>d.<>t__builder.Start<RouletteGridBase.<<RefreshGrid>b__9_0>d>(ref <<RefreshGrid>b__9_0>d);
			return <<RefreshGrid>b__9_0>d.<>t__builder.Task;
		}, null);
		base.RunAsyncTask(task);
	}

	// Token: 0x06014EFD RID: 85757 RVA: 0x005CB61C File Offset: 0x005C981C
	public void BindRedDot(ERedDotName redDotName, int uId = 0)
	{
		UUIItem item = base.GetItem(11);
		if (item == null)
		{
			return;
		}
		this.UnBindRedDot();
		this.RedDotName = new ERedDotName?(redDotName);
		if (this.RedDotName != null)
		{
			ControllerBase<RedDotController>.Instance.BindRedDot(this.RedDotName.Value, item, null, uId);
		}
	}

	// Token: 0x06014EFE RID: 85758 RVA: 0x005CB670 File Offset: 0x005C9870
	public void UnBindRedDot()
	{
		if (this.RedDotName != null)
		{
			UUIItem item = base.GetItem(11);
			ControllerBase<RedDotController>.Instance.UnBindGivenUi(this.RedDotName.Value, item, 0);
			this.RedDotName = null;
		}
	}

	// Token: 0x06014EFF RID: 85759 RVA: 0x005CB6B6 File Offset: 0x005C98B6
	public void SetRedDotVisible(bool bVisible)
	{
		base.GetItem(11).SetUIActive(bVisible);
	}

	// Token: 0x06014F00 RID: 85760 RVA: 0x005CB6C8 File Offset: 0x005C98C8
	protected UUIItem GetIconItem(bool? isTexture = null)
	{
		if (isTexture ?? this.IsIconTexture)
		{
			return base.GetTexture(2);
		}
		return base.GetUiExtendToggleSpriteTransition(5).RootUIComp.Get();
	}

	// Token: 0x06014F01 RID: 85761 RVA: 0x005CB710 File Offset: 0x005C9910
	protected UniTask LoadSpriteIcon(string path)
	{
		RouletteGridBase.<LoadSpriteIcon>d__14 <LoadSpriteIcon>d__;
		<LoadSpriteIcon>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<LoadSpriteIcon>d__.<>4__this = this;
		<LoadSpriteIcon>d__.path = path;
		<LoadSpriteIcon>d__.<>1__state = -1;
		<LoadSpriteIcon>d__.<>t__builder.Start<RouletteGridBase.<LoadSpriteIcon>d__14>(ref <LoadSpriteIcon>d__);
		return <LoadSpriteIcon>d__.<>t__builder.Task;
	}

	// Token: 0x06014F02 RID: 85762 RVA: 0x005CB75C File Offset: 0x005C995C
	protected UniTask LoadTextureIcon(string path)
	{
		RouletteGridBase.<LoadTextureIcon>d__15 <LoadTextureIcon>d__;
		<LoadTextureIcon>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<LoadTextureIcon>d__.<>4__this = this;
		<LoadTextureIcon>d__.path = path;
		<LoadTextureIcon>d__.<>1__state = -1;
		<LoadTextureIcon>d__.<>t__builder.Start<RouletteGridBase.<LoadTextureIcon>d__15>(ref <LoadTextureIcon>d__);
		return <LoadTextureIcon>d__.<>t__builder.Task;
	}

	// Token: 0x06014F03 RID: 85763 RVA: 0x005CB7A8 File Offset: 0x005C99A8
	protected UniTask LoadIconByItemId(int itemId)
	{
		RouletteGridBase.<LoadIconByItemId>d__16 <LoadIconByItemId>d__;
		<LoadIconByItemId>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<LoadIconByItemId>d__.<>4__this = this;
		<LoadIconByItemId>d__.itemId = itemId;
		<LoadIconByItemId>d__.<>1__state = -1;
		<LoadIconByItemId>d__.<>t__builder.Start<RouletteGridBase.<LoadIconByItemId>d__16>(ref <LoadIconByItemId>d__);
		return <LoadIconByItemId>d__.<>t__builder.Task;
	}

	// Token: 0x06014F04 RID: 85764 RVA: 0x005CB7F4 File Offset: 0x005C99F4
	private void HideBeforeRefreshState()
	{
		base.GetItem(1).SetUIActive(false);
		base.GetItem(4).SetUIActive(false);
		base.GetItem(8).SetUIActive(false);
		base.GetText(10).SetUIActive(false);
		this.GetIconItem(new bool?(true)).SetUIActive(false);
		this.GetIconItem(new bool?(false)).SetUIActive(false);
	}

	// Token: 0x06014F05 RID: 85765 RVA: 0x005CB85C File Offset: 0x005C9A5C
	private void RefreshGridState()
	{
		if (this.Data == null)
		{
			return;
		}
		EGridBehavior state = this.Data.State;
		if (state == EGridBehavior.NotShow)
		{
			this.SetActive(false);
			return;
		}
		base.GetItem(1).SetUIActive(state == EGridBehavior.CanAdd);
		base.GetItem(4).SetUIActive(state == EGridBehavior.Forbidden);
		bool showIndex = this.Data.ShowIndex;
		base.GetItem(8).SetUIActive(showIndex);
		if (showIndex)
		{
			string newText = (this.Data.GridIndex + 1).ToString();
			base.GetText(9).SetText(newText, true);
		}
		base.GetText(10).SetUIActive(this.Data.ShowNum);
		if (this.Data.ShowNum)
		{
			base.GetText(10).SetText(this.Data.DataNum.ToString(), true);
		}
		this.GetIconItem(new bool?(!this.IsIconTexture)).SetUIActive(false);
		this.GetIconItem(new bool?(this.IsIconTexture)).SetUIActive(state == EGridBehavior.Normal || state == EGridBehavior.Forbidden || state == EGridBehavior.Lock);
	}

	// Token: 0x06014F06 RID: 85766 RVA: 0x005CB96C File Offset: 0x005C9B6C
	public void SetGridEquipped(bool bSelect)
	{
		base.GetItem(3).SetUIActive(bSelect);
	}

	// Token: 0x06014F07 RID: 85767 RVA: 0x005CB97B File Offset: 0x005C9B7B
	public void BindOnCanToggleExecuteChange(Func<RouletteData, EToggleState, bool> onItemClicked)
	{
		this.OnCanToggleClicked = onItemClicked;
	}

	// Token: 0x06014F08 RID: 85768 RVA: 0x005CB984 File Offset: 0x005C9B84
	private bool CanToggleExecuteChange()
	{
		return this.OnCanToggleClicked == null || this.Data == null || this.Toggle == null || this.OnCanToggleClicked(this.Data, this.Toggle.GetToggleState());
	}

	// Token: 0x06014F09 RID: 85769 RVA: 0x005CB9BC File Offset: 0x005C9BBC
	private void SetRouletteGridSelectEvent(EToggleState state)
	{
		if (state == EToggleState.ETT_Checked && this.Data != null)
		{
			Singleton<EventSystem>.Instance.Emit<RouletteData>(EEventName.OnRouletteItemSelect, this.Data);
		}
	}

	// Token: 0x06014F0A RID: 85770 RVA: 0x005CB9E0 File Offset: 0x005C9BE0
	private void SetGridEmitEquipRing(EToggleState state)
	{
		this.SetGridEquipped(state == EToggleState.ETT_Checked);
	}

	// Token: 0x06014F0B RID: 85771 RVA: 0x005CB9EC File Offset: 0x005C9BEC
	public void AddToggleStateChangeEvent(Action<EToggleState> eventHandler)
	{
		this.Toggle.OnStateChange.Add(eventHandler);
	}

	// Token: 0x06014F0C RID: 85772 RVA: 0x005CB9FF File Offset: 0x005C9BFF
	public void RemoveToggleStateChangeEvent(Action<EToggleState> eventHandler)
	{
		this.Toggle.OnStateChange.Remove(eventHandler);
	}

	// Token: 0x06014F0D RID: 85773 RVA: 0x005CBA12 File Offset: 0x005C9C12
	public void SetGridToggleChangeEvent()
	{
		this.AddToggleStateChangeEvent(new Action<EToggleState>(this.SetRouletteGridSelectEvent));
		this.AddToggleStateChangeEvent(new Action<EToggleState>(this.SetGridEmitEquipRing));
	}

	// Token: 0x06014F0E RID: 85774 RVA: 0x005CBA38 File Offset: 0x005C9C38
	public void RemoveGridToggleChangeEvent()
	{
		this.RemoveToggleStateChangeEvent(new Action<EToggleState>(this.SetRouletteGridSelectEvent));
		this.RemoveToggleStateChangeEvent(new Action<EToggleState>(this.SetGridEmitEquipRing));
	}

	// Token: 0x06014F0F RID: 85775 RVA: 0x005CBA5E File Offset: 0x005C9C5E
	public void SetToggleSelfInteractive(bool bActive)
	{
		this.Toggle.SetSelfInteractive(bActive);
	}

	// Token: 0x06014F10 RID: 85776 RVA: 0x005CBA6C File Offset: 0x005C9C6C
	public void SetGridToggleState(bool bSelect, bool bFireEvent = true)
	{
		EToggleState state = bSelect ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
		this.Toggle.SetToggleState(state, bFireEvent, false, false);
	}

	// Token: 0x06014F11 RID: 85777 RVA: 0x005CBA91 File Offset: 0x005C9C91
	public void SetGridToggleNavigation(bool bSelect)
	{
		if (bSelect)
		{
			ControllerBase<UiNavigationNewController>.Instance.SetNavigationFocusForView(this.RootItem, false, false, false);
		}
	}

	// Token: 0x06014F12 RID: 85778 RVA: 0x005CBAAA File Offset: 0x005C9CAA
	public void SelectOnGrid(bool bSelect)
	{
		this.OnSelect(bSelect);
	}

	// Token: 0x06014F13 RID: 85779 RVA: 0x005CBAB3 File Offset: 0x005C9CB3
	protected virtual void OnSelect(bool bSelect)
	{
	}

	// Token: 0x0400A14C RID: 41292
	[Nullable(2)]
	public RouletteData Data;

	// Token: 0x0400A14D RID: 41293
	[Nullable(2)]
	protected UUIExtendToggle Toggle;

	// Token: 0x0400A14E RID: 41294
	protected bool IsIconTexture;

	// Token: 0x0400A14F RID: 41295
	private ERedDotName? RedDotName;

	// Token: 0x0400A150 RID: 41296
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Func<RouletteData, EToggleState, bool> OnCanToggleClicked;
}
