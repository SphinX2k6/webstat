using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;

// Token: 0x02001A66 RID: 6758
[NullableContext(1)]
[Nullable(0)]
public class EditFormationTabItem : CommonTabItemBase
{
	// Token: 0x0600C17F RID: 49535 RVA: 0x0032F33C File Offset: 0x0032D53C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 5;
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
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(1, new Action<EToggleState>(this.ToggleClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600C180 RID: 49536 RVA: 0x0032F445 File Offset: 0x0032D645
	protected override void OnStart()
	{
		base.OnStart();
		base.GetExtendToggle(1).SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
		base.GetItem(2).SetUIActive(false);
	}

	// Token: 0x0600C181 RID: 49537 RVA: 0x0032F46B File Offset: 0x0032D66B
	protected override void OnBeforeDestroy()
	{
		this.UnBindRedDot();
	}

	// Token: 0x0600C182 RID: 49538 RVA: 0x0032F473 File Offset: 0x0032D673
	private void ToggleClick(EToggleState state)
	{
		if (state == EToggleState.ETT_Checked)
		{
			this.SelectedCallBack(base.GridIndex);
		}
	}

	// Token: 0x0600C183 RID: 49539 RVA: 0x0032F48C File Offset: 0x0032D68C
	public void ShowTeamBattleTips()
	{
		base.GetItem(4).SetUIActive(true);
	}

	// Token: 0x0600C184 RID: 49540 RVA: 0x0032F49B File Offset: 0x0032D69B
	protected override void OnRefresh(CommonTabItemData data, bool isSelected, int gridIndex)
	{
		CommonTabData data2 = data.Data;
		base.UpdateTabIcon(((data2 != null) ? data2.GetIcon() : null) ?? "");
	}

	// Token: 0x0600C185 RID: 49541 RVA: 0x0032F4C0 File Offset: 0x0032D6C0
	protected override void OnUpdateTabIcon(string iconPath)
	{
		this.SetSpriteByPath(iconPath, base.GetSprite(0), false, null, new Action<bool>(this.RefreshTransition));
	}

	// Token: 0x0600C186 RID: 49542 RVA: 0x0032F4F4 File Offset: 0x0032D6F4
	protected void RefreshTransition(bool result)
	{
		UUIExtendToggleSpriteTransition uiExtendToggleSpriteTransition = base.GetUiExtendToggleSpriteTransition(3);
		if (uiExtendToggleSpriteTransition != null)
		{
			uiExtendToggleSpriteTransition.SetAllStateSprite(base.GetSprite(0).GetSprite());
		}
	}

	// Token: 0x0600C187 RID: 49543 RVA: 0x0032F51E File Offset: 0x0032D71E
	protected override void OnSetToggleState(EToggleState state, bool bFire)
	{
		base.GetExtendToggle(1).SetToggleState(state, bFire, false, false);
	}

	// Token: 0x0600C188 RID: 49544 RVA: 0x0032F531 File Offset: 0x0032D731
	protected override UUIExtendToggle GetTabToggle()
	{
		return base.GetExtendToggle(1);
	}

	// Token: 0x0600C189 RID: 49545 RVA: 0x0032F53A File Offset: 0x0032D73A
	public void BindRedDot(ERedDotName redDotName, int uId = 0)
	{
		this.RedDotName = new ERedDotName?(redDotName);
		if (this.RedDotName != null)
		{
			ControllerBase<RedDotController>.Instance.BindRedDot(redDotName, base.GetItem(2), null, uId);
		}
	}

	// Token: 0x0600C18A RID: 49546 RVA: 0x0032F569 File Offset: 0x0032D769
	public void UnBindRedDot()
	{
		if (this.RedDotName != null)
		{
			ControllerBase<RedDotController>.Instance.UnBindRedDot(this.RedDotName.Value);
			this.RedDotName = null;
		}
	}

	// Token: 0x04005A93 RID: 23187
	private ERedDotName? RedDotName;

	// Token: 0x02007D1F RID: 32031
	[NullableContext(0)]
	private class EEditFormationTabItem
	{
		// Token: 0x0402AA82 RID: 174722
		public const int Icon = 0;

		// Token: 0x0402AA83 RID: 174723
		public const int Toggle = 1;

		// Token: 0x0402AA84 RID: 174724
		public const int RedDot = 2;

		// Token: 0x0402AA85 RID: 174725
		public const int Transition = 3;

		// Token: 0x0402AA86 RID: 174726
		public const int ItemTip = 4;
	}
}
