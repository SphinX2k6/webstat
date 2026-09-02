using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Protocol;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002346 RID: 9030
[NullableContext(1)]
[Nullable(0)]
public class OnlineHallSettingButton : UiPanelBase
{
	// Token: 0x060113BF RID: 70591 RVA: 0x004BC1F4 File Offset: 0x004BA3F4
	public OnlineHallSettingButton(AActor uiContainerActor, WorldEnterPermission type)
	{
		this.Type = type;
		base.CreateThenShowByActor(uiContainerActor, null);
	}

	// Token: 0x060113C0 RID: 70592 RVA: 0x004BC20C File Offset: 0x004BA40C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x060113C1 RID: 70593 RVA: 0x004BC275 File Offset: 0x004BA475
	protected override void OnStart()
	{
		this.InitType(this.Type);
		this.AddEvents();
	}

	// Token: 0x060113C2 RID: 70594 RVA: 0x004BC289 File Offset: 0x004BA489
	protected override void OnBeforeDestroy()
	{
		this.RemoveEvents();
	}

	// Token: 0x060113C3 RID: 70595 RVA: 0x004BC291 File Offset: 0x004BA491
	private void AddEvents()
	{
		base.GetExtendToggle(0).OnStateChange.Add(new Action<EToggleState>(this.OnSettingButtonClicked));
	}

	// Token: 0x060113C4 RID: 70596 RVA: 0x004BC2B0 File Offset: 0x004BA4B0
	private void RemoveEvents()
	{
		base.GetExtendToggle(0).OnStateChange.Remove(new Action<EToggleState>(this.OnSettingButtonClicked));
	}

	// Token: 0x060113C5 RID: 70597 RVA: 0x004BC2CF File Offset: 0x004BA4CF
	public void BindOnSettingButtonClickedCallback(Action<WorldEnterPermission> onSettingButtonClickedCallback)
	{
		this.OnSettingButtonClickedCallback = onSettingButtonClickedCallback;
	}

	// Token: 0x060113C6 RID: 70598 RVA: 0x004BC2D8 File Offset: 0x004BA4D8
	public void BindCanToggleExecuteChange(Func<WorldEnterPermission, bool> toggle)
	{
		this.OnCanToggleClicked = toggle;
	}

	// Token: 0x060113C7 RID: 70599 RVA: 0x004BC2E1 File Offset: 0x004BA4E1
	private bool CanToggleExecuteChange()
	{
		return this.OnCanToggleClicked == null || this.OnCanToggleClicked(this.Type);
	}

	// Token: 0x060113C8 RID: 70600 RVA: 0x004BC300 File Offset: 0x004BA500
	public void SetSelected(bool bSelected)
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (bSelected)
		{
			extendToggle.SetToggleStateForce(EToggleState.ETT_Checked, false, false, false);
			return;
		}
		extendToggle.SetToggleStateForce(EToggleState.ETT_UnChecked, false, false, false);
	}

	// Token: 0x060113C9 RID: 70601 RVA: 0x004BC330 File Offset: 0x004BA530
	private void InitType(WorldEnterPermission type)
	{
		UUIText text = base.GetText(1);
		string str = "PermissionsSetting_";
		int num = (int)type;
		string textTableId = str + num.ToString();
		Singleton<LguiUtil>.Instance.SetLocalText(text, textTableId, Array.Empty<object>());
		base.GetExtendToggle(0).CanExecuteChange.Bind(new Func<bool>(this.CanToggleExecuteChange));
	}

	// Token: 0x060113CA RID: 70602 RVA: 0x004BC387 File Offset: 0x004BA587
	private void OnSettingButtonClicked(EToggleState state)
	{
		if (state != EToggleState.ETT_Checked)
		{
			return;
		}
		if (this.OnSettingButtonClickedCallback != null)
		{
			this.OnSettingButtonClickedCallback(this.Type);
		}
	}

	// Token: 0x0400877B RID: 34683
	[Nullable(2)]
	private Action<WorldEnterPermission> OnSettingButtonClickedCallback;

	// Token: 0x0400877C RID: 34684
	private readonly WorldEnterPermission Type;

	// Token: 0x0400877D RID: 34685
	[Nullable(2)]
	private Func<WorldEnterPermission, bool> OnCanToggleClicked;

	// Token: 0x02008655 RID: 34389
	[NullableContext(0)]
	private enum EChildType
	{
		// Token: 0x0402D6F7 RID: 186103
		Tog,
		// Token: 0x0402D6F8 RID: 186104
		TogText
	}
}
