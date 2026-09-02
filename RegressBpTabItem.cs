using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02001534 RID: 5428
[NullableContext(1)]
[Nullable(0)]
internal class RegressBpTabItem : CommonTabItemBase
{
	// Token: 0x06009822 RID: 38946 RVA: 0x0027D4D4 File Offset: 0x0027B6D4
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.ToggleClick))
		};
	}

	// Token: 0x06009823 RID: 38947 RVA: 0x0027D580 File Offset: 0x0027B780
	protected override void OnRefresh(CommonTabItemData data, bool isSelected, int gridIndex)
	{
		UUIText text = base.GetText(1);
		CommonTabData data2 = data.Data;
		string text2;
		if (data2 == null)
		{
			text2 = null;
		}
		else
		{
			CommonTabTitleData titleData = data2.GetTitleData();
			text2 = ((titleData != null) ? titleData.TextId : null);
		}
		text.ShowTextNew(text2 ?? "");
		this.UnBindRedDot();
		if (data.RedDotName != null)
		{
			this.BindRedDot(data.RedDotName.Value, data.RedDotUid.GetValueOrDefault());
		}
	}

	// Token: 0x06009824 RID: 38948 RVA: 0x0027D5EF File Offset: 0x0027B7EF
	public void BindRedDot(ERedDotName redDotName, int uId = 0)
	{
		this.RedDotName = new ERedDotName?(redDotName);
		if (this.RedDotName != null)
		{
			ControllerBase<RedDotController>.Instance.BindRedDot(redDotName, base.GetItem(4), null, uId);
		}
	}

	// Token: 0x06009825 RID: 38949 RVA: 0x0027D61E File Offset: 0x0027B81E
	public void UnBindRedDot()
	{
		if (this.RedDotName != null)
		{
			ControllerBase<RedDotController>.Instance.UnBindRedDot(this.RedDotName.Value);
			this.RedDotName = null;
		}
	}

	// Token: 0x06009826 RID: 38950 RVA: 0x0027D64E File Offset: 0x0027B84E
	protected override void OnUpdateTabIcon(string iconPath)
	{
	}

	// Token: 0x06009827 RID: 38951 RVA: 0x0027D650 File Offset: 0x0027B850
	protected override void OnSetToggleState(EToggleState state, bool bFire)
	{
		base.GetExtendToggle(0).SetToggleState(state, bFire, false, false);
	}

	// Token: 0x06009828 RID: 38952 RVA: 0x0027D663 File Offset: 0x0027B863
	protected override UUIExtendToggle GetTabToggle()
	{
		return base.GetExtendToggle(0);
	}

	// Token: 0x06009829 RID: 38953 RVA: 0x0027D66C File Offset: 0x0027B86C
	private void ToggleClick(EToggleState state)
	{
		if (state == EToggleState.ETT_Checked)
		{
			this.SelectedCallBack(base.GridIndex);
		}
	}

	// Token: 0x0600982A RID: 38954 RVA: 0x0027D685 File Offset: 0x0027B885
	public override void OnSelected(bool fireEvent)
	{
		this.SelectedCallBack(base.GridIndex);
	}

	// Token: 0x0600982B RID: 38955 RVA: 0x0027D698 File Offset: 0x0027B898
	protected override void OnBeforeDestroy()
	{
		this.UnBindRedDot();
	}

	// Token: 0x0600982C RID: 38956 RVA: 0x0027D6A0 File Offset: 0x0027B8A0
	protected override void OnClear()
	{
		this.UnBindRedDot();
	}

	// Token: 0x0400467F RID: 18047
	private ERedDotName? RedDotName;

	// Token: 0x020078E6 RID: 30950
	[NullableContext(0)]
	private class ETabItemComponents
	{
		// Token: 0x040298DE RID: 170206
		public const int Toggle = 0;

		// Token: 0x040298DF RID: 170207
		public const int TxtType = 1;

		// Token: 0x040298E0 RID: 170208
		public const int PanelUp = 2;

		// Token: 0x040298E1 RID: 170209
		public const int PanelFinish = 3;

		// Token: 0x040298E2 RID: 170210
		public const int PanelRedDot = 4;
	}
}
