using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;

// Token: 0x02001A63 RID: 6755
[NullableContext(1)]
[Nullable(0)]
public class CommonTabItem : CommonTabItemBase
{
	// Token: 0x0600C14D RID: 49485 RVA: 0x0032EE88 File Offset: 0x0032D088
	protected unsafe override void OnRegisterComponent()
	{
		int num = 4;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIExtendToggleSpriteTransition));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(1, new Action<EToggleState>(this.ToggleClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600C14E RID: 49486 RVA: 0x0032EF70 File Offset: 0x0032D170
	protected override void OnStart()
	{
		base.OnStart();
		base.GetExtendToggle(1).SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
		Action callback = delegate()
		{
			Action onUndeterminedClick = this.OnUndeterminedClick;
			if (onUndeterminedClick == null)
			{
				return;
			}
			onUndeterminedClick();
		};
		base.GetExtendToggle(1).OnUndeterminedClicked.Add(callback);
		base.GetItem(2).SetUIActive(false);
	}

	// Token: 0x0600C14F RID: 49487 RVA: 0x0032EFC0 File Offset: 0x0032D1C0
	protected override void OnBeforeDestroy()
	{
		if (this.NeedUnBindAll)
		{
			this.UnBindRedDot();
			return;
		}
		this.UnBindGivenUid(this.RedDotUid);
	}

	// Token: 0x0600C150 RID: 49488 RVA: 0x0032EFE0 File Offset: 0x0032D1E0
	protected override void OnRefresh(CommonTabItemData data, bool isSelected, int gridIndex)
	{
		CommonTabData data2 = data.Data;
		base.UpdateTabIcon(((data2 != null) ? data2.GetIcon() : null) ?? "");
		this.UnBindRedDot();
		this.NeedUnBindAll = data.NeedUnBindAllRedDot;
		if (data.RedDotName != null)
		{
			this.RedDotUid = data.RedDotUid;
			this.BindRedDot(data.RedDotName.Value, data.RedDotUid);
			return;
		}
		UUIItem item = base.GetItem(2);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(false);
	}

	// Token: 0x0600C151 RID: 49489 RVA: 0x0032F063 File Offset: 0x0032D263
	private void ToggleClick(EToggleState state)
	{
		if (state == EToggleState.ETT_Checked)
		{
			this.SelectedCallBack(base.GridIndex);
		}
	}

	// Token: 0x0600C152 RID: 49490 RVA: 0x0032F07C File Offset: 0x0032D27C
	public override void OnSelected(bool fireEvent)
	{
		this.SelectedCallBack(base.GridIndex);
	}

	// Token: 0x0600C153 RID: 49491 RVA: 0x0032F090 File Offset: 0x0032D290
	protected override void OnUpdateTabIcon(string iconPath)
	{
		if (iconPath != "")
		{
			this.SetSpriteByPath(iconPath, base.GetSprite(0), false, null, new Action<bool>(this.RefreshTransition));
		}
	}

	// Token: 0x0600C154 RID: 49492 RVA: 0x0032F0D0 File Offset: 0x0032D2D0
	protected void RefreshTransition(bool result)
	{
		UUIExtendToggleSpriteTransition uiExtendToggleSpriteTransition = base.GetUiExtendToggleSpriteTransition(3);
		if (uiExtendToggleSpriteTransition != null)
		{
			uiExtendToggleSpriteTransition.SetAllStateSprite(base.GetSprite(0).GetSprite());
		}
	}

	// Token: 0x0600C155 RID: 49493 RVA: 0x0032F0FA File Offset: 0x0032D2FA
	public void SetToggleStateForce(EToggleState state, bool bFire)
	{
		base.GetExtendToggle(1).SetToggleStateForce(state, bFire, false, false);
	}

	// Token: 0x0600C156 RID: 49494 RVA: 0x0032F10C File Offset: 0x0032D30C
	public void SetCanClickWhenDisable(bool state)
	{
		base.GetExtendToggle(1).SetCanClickWhenDisable(state);
	}

	// Token: 0x0600C157 RID: 49495 RVA: 0x0032F11B File Offset: 0x0032D31B
	public void SetOnUndeterminedClick(Action call)
	{
		this.OnUndeterminedClick = call;
	}

	// Token: 0x0600C158 RID: 49496 RVA: 0x0032F124 File Offset: 0x0032D324
	protected override void OnSetToggleState(EToggleState state, bool bFire)
	{
		base.GetExtendToggle(1).SetToggleState(state, bFire, false, false);
	}

	// Token: 0x0600C159 RID: 49497 RVA: 0x0032F137 File Offset: 0x0032D337
	protected override UUIExtendToggle GetTabToggle()
	{
		return base.GetExtendToggle(1);
	}

	// Token: 0x0600C15A RID: 49498 RVA: 0x0032F140 File Offset: 0x0032D340
	public virtual void BindRedDot(ERedDotName redDotName, int? uId = 0)
	{
		this.RedDotName = new ERedDotName?(redDotName);
		if (this.RedDotName != null)
		{
			ControllerBase<RedDotController>.Instance.BindRedDot(redDotName, base.GetItem(2), null, uId.GetValueOrDefault());
		}
	}

	// Token: 0x0600C15B RID: 49499 RVA: 0x0032F175 File Offset: 0x0032D375
	public virtual void UnBindRedDot()
	{
		if (this.RedDotName != null)
		{
			ControllerBase<RedDotController>.Instance.UnBindRedDot(this.RedDotName.Value);
			this.RedDotName = null;
		}
	}

	// Token: 0x0600C15C RID: 49500 RVA: 0x0032F1A5 File Offset: 0x0032D3A5
	protected void UnBindGivenUid(int? uid = 0)
	{
		if (this.RedDotName != null)
		{
			ControllerBase<RedDotController>.Instance.UnBindGivenUi(this.RedDotName.Value, base.GetItem(2), uid.GetValueOrDefault());
			this.RedDotName = null;
		}
	}

	// Token: 0x0600C15D RID: 49501 RVA: 0x0032F1E3 File Offset: 0x0032D3E3
	public void SetRedDotState(bool bVisible)
	{
		UUIItem item = base.GetItem(2);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(bVisible);
	}

	// Token: 0x0600C15E RID: 49502 RVA: 0x0032F1F7 File Offset: 0x0032D3F7
	public UUISprite GetIconSprite()
	{
		return base.GetSprite(0);
	}

	// Token: 0x0600C15F RID: 49503 RVA: 0x0032F200 File Offset: 0x0032D400
	protected override void OnClear()
	{
		this.UnBindRedDot();
	}

	// Token: 0x04005A83 RID: 23171
	[Nullable(2)]
	private Action OnUndeterminedClick;

	// Token: 0x04005A84 RID: 23172
	protected ERedDotName? RedDotName;

	// Token: 0x04005A85 RID: 23173
	protected int? RedDotUid;

	// Token: 0x04005A86 RID: 23174
	protected bool NeedUnBindAll = true;

	// Token: 0x02007D1E RID: 32030
	[NullableContext(0)]
	private class ECommonTabItem
	{
		// Token: 0x0402AA7E RID: 174718
		public const int Icon = 0;

		// Token: 0x0402AA7F RID: 174719
		public const int Toggle = 1;

		// Token: 0x0402AA80 RID: 174720
		public const int RedDot = 2;

		// Token: 0x0402AA81 RID: 174721
		public const int Transition = 3;
	}
}
