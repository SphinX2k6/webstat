using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;

// Token: 0x02001546 RID: 5446
[NullableContext(1)]
[Nullable(0)]
public class ActivityRegressTabItemPanel : CommonTabItemBase
{
	// Token: 0x060098D0 RID: 39120 RVA: 0x00280658 File Offset: 0x0027E858
	protected unsafe override void OnRegisterComponent()
	{
		int num = 6;
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
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(1, new Action<EToggleState>(this.ToggleClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x060098D1 RID: 39121 RVA: 0x00280782 File Offset: 0x0027E982
	protected override void OnStart()
	{
		base.OnStart();
		base.GetExtendToggle(1).SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
		base.GetItem(2).SetUIActive(false);
		base.GetSprite(0).SetUIActive(true);
	}

	// Token: 0x060098D2 RID: 39122 RVA: 0x002807B8 File Offset: 0x0027E9B8
	protected override void OnRefresh(CommonTabItemData data, bool isSelected, int gridIndex)
	{
		if (data.Data != null)
		{
			base.UpdateTabIcon(data.Data.GetIcon() ?? string.Empty);
			CommonTabTitleData titleData = data.Data.GetTitleData();
			this.UpdateTitle(((titleData != null) ? titleData.TextId : null) ?? string.Empty);
			this.UnBindRedDot();
			if (data.RedDotName != null)
			{
				this.BindRedDot(data.RedDotName.Value, data.RedDotUid.GetValueOrDefault());
			}
		}
	}

	// Token: 0x060098D3 RID: 39123 RVA: 0x0028083C File Offset: 0x0027EA3C
	private void ToggleClick(EToggleState state)
	{
		if (state == EToggleState.ETT_Checked)
		{
			this.SelectedCallBack(base.GridIndex);
		}
	}

	// Token: 0x060098D4 RID: 39124 RVA: 0x00280855 File Offset: 0x0027EA55
	public override void OnSelected(bool fireEvent)
	{
		this.SelectedCallBack(base.GridIndex);
	}

	// Token: 0x060098D5 RID: 39125 RVA: 0x00280868 File Offset: 0x0027EA68
	protected override void OnUpdateTabIcon(string iconPath)
	{
		if (string.IsNullOrEmpty(iconPath))
		{
			return;
		}
		this.SetSpriteByPath(iconPath, base.GetSprite(0), false, null, new Action<bool>(this.RefreshTransition));
	}

	// Token: 0x060098D6 RID: 39126 RVA: 0x002808A4 File Offset: 0x0027EAA4
	public void UpdateTitle(string textId)
	{
		UUIText text = base.GetText(5);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(text, textId, Array.Empty<object>());
	}

	// Token: 0x060098D7 RID: 39127 RVA: 0x002808CC File Offset: 0x0027EACC
	protected void RefreshTransition(bool _)
	{
		UUIExtendToggleSpriteTransition uiExtendToggleSpriteTransition = base.GetUiExtendToggleSpriteTransition(3);
		if (uiExtendToggleSpriteTransition != null)
		{
			uiExtendToggleSpriteTransition.SetAllStateSprite(base.GetSprite(0).GetSprite());
		}
	}

	// Token: 0x060098D8 RID: 39128 RVA: 0x002808F6 File Offset: 0x0027EAF6
	protected override void OnSetToggleState(EToggleState state, bool bFire)
	{
		base.GetExtendToggle(1).SetToggleState(state, bFire, false, false);
	}

	// Token: 0x060098D9 RID: 39129 RVA: 0x00280909 File Offset: 0x0027EB09
	protected override UUIExtendToggle GetTabToggle()
	{
		return base.GetExtendToggle(1);
	}

	// Token: 0x060098DA RID: 39130 RVA: 0x00280912 File Offset: 0x0027EB12
	protected override void OnBeforeDestroy()
	{
		this.UnBindRedDot();
	}

	// Token: 0x060098DB RID: 39131 RVA: 0x0028091A File Offset: 0x0027EB1A
	protected override void OnClear()
	{
		this.UnBindRedDot();
	}

	// Token: 0x060098DC RID: 39132 RVA: 0x00280922 File Offset: 0x0027EB22
	public void BindRedDot(ERedDotName redDotName, int uId = 0)
	{
		this.RedDotName = new ERedDotName?(redDotName);
		ControllerBase<RedDotController>.Instance.BindRedDot(redDotName, base.GetItem(2), null, uId);
	}

	// Token: 0x060098DD RID: 39133 RVA: 0x00280944 File Offset: 0x0027EB44
	public void UnBindRedDot()
	{
		if (this.RedDotName != null)
		{
			ControllerBase<RedDotController>.Instance.UnBindRedDot(this.RedDotName.Value);
			this.RedDotName = null;
		}
	}

	// Token: 0x040046AB RID: 18091
	protected ERedDotName? RedDotName;

	// Token: 0x02007902 RID: 30978
	[NullableContext(0)]
	private class EComponents
	{
		// Token: 0x04029969 RID: 170345
		public const int Icon = 0;

		// Token: 0x0402996A RID: 170346
		public const int Toggle = 1;

		// Token: 0x0402996B RID: 170347
		public const int RedDot = 2;

		// Token: 0x0402996C RID: 170348
		public const int SprIcon = 3;

		// Token: 0x0402996D RID: 170349
		public const int SprSubIcon = 4;

		// Token: 0x0402996E RID: 170350
		public const int TxtName = 5;
	}
}
