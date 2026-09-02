using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Map;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001B82 RID: 7042
[NullableContext(1)]
[Nullable(0)]
public class ExploreAreaItem : UiPanelBase
{
	// Token: 0x0600CC89 RID: 52361 RVA: 0x0036728E File Offset: 0x0036548E
	public void Initialize(UUIItem uiItem)
	{
		base.CreateByActorAsync(uiItem.GetOwner(), null, false);
	}

	// Token: 0x0600CC8A RID: 52362 RVA: 0x003672A0 File Offset: 0x003654A0
	protected unsafe override void OnRegisterComponent()
	{
		int num = 5;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIExtendToggle));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(4, new Action<EToggleState>(this.OnExtendToggleStateChanged));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600CC8B RID: 52363 RVA: 0x003673A9 File Offset: 0x003655A9
	protected override void OnStart()
	{
		base.GetExtendToggle(4).CanExecuteChange.Bind(new Func<bool>(this.OnCanExecuteChange));
	}

	// Token: 0x0600CC8C RID: 52364 RVA: 0x003673C8 File Offset: 0x003655C8
	protected override void OnBeforeDestroy()
	{
		this.OnSelectedCallback = null;
		this.OnCanExecuteChangeCallback = null;
		base.GetExtendToggle(4).CanExecuteChange.Unbind();
	}

	// Token: 0x0600CC8D RID: 52365 RVA: 0x003673EC File Offset: 0x003655EC
	private void OnExtendToggleStateChanged(EToggleState toggleState)
	{
		if (this.OnSelectedCallback != null && this.Data != null)
		{
			bool arg = base.GetExtendToggle(4).GetToggleState() == EToggleState.ETT_Checked;
			this.OnSelectedCallback(this, this.Data, arg);
		}
	}

	// Token: 0x0600CC8E RID: 52366 RVA: 0x0036742C File Offset: 0x0036562C
	public void Refresh(ExploreAreaViewData data)
	{
		this.Data = data;
		int areaId = data.AreaId;
		bool uiactive = MapUtil.GetWorldMapLevelOneAreaId() == areaId;
		int selectedAreaId = ModelBase<ExploreProgressModel>.Instance.SelectedAreaId;
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), data.NameId, Array.Empty<object>());
		UUIText text = base.GetText(2);
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
		defaultInterpolatedStringHandler.AppendFormatted<double>(Math.Floor((double)data.Progress));
		defaultInterpolatedStringHandler.AppendLiteral("%");
		text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
		base.GetItem(3).SetUIActive(false);
		base.GetSprite(0).SetUIActive(uiactive);
		this.SetSelected(selectedAreaId == areaId, true);
	}

	// Token: 0x0600CC8F RID: 52367 RVA: 0x003674D8 File Offset: 0x003656D8
	private bool OnCanExecuteChange()
	{
		Func<bool> onCanExecuteChangeCallback = this.OnCanExecuteChangeCallback;
		return onCanExecuteChangeCallback == null || onCanExecuteChangeCallback();
	}

	// Token: 0x0600CC90 RID: 52368 RVA: 0x003674EB File Offset: 0x003656EB
	public void BindCanExecuteChange(Func<bool> onCanExecuteChange)
	{
		this.OnCanExecuteChangeCallback = onCanExecuteChange;
	}

	// Token: 0x0600CC91 RID: 52369 RVA: 0x003674F4 File Offset: 0x003656F4
	public void SetSelected(bool bSelected, bool bFireEvent = false)
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(4);
		if (bSelected)
		{
			extendToggle.SetToggleState(EToggleState.ETT_Checked, bFireEvent, false, false);
			return;
		}
		extendToggle.SetToggleState(EToggleState.ETT_UnChecked, bFireEvent, false, false);
	}

	// Token: 0x0600CC92 RID: 52370 RVA: 0x00367523 File Offset: 0x00365723
	public void BindOnSelected(Action<ExploreAreaItem, ExploreAreaViewData, bool> onSelectedCallback)
	{
		this.OnSelectedCallback = onSelectedCallback;
	}

	// Token: 0x040061CF RID: 25039
	[Nullable(2)]
	private ExploreAreaViewData Data;

	// Token: 0x040061D0 RID: 25040
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private Action<ExploreAreaItem, ExploreAreaViewData, bool> OnSelectedCallback;

	// Token: 0x040061D1 RID: 25041
	[Nullable(2)]
	private Func<bool> OnCanExecuteChangeCallback;

	// Token: 0x02007E62 RID: 32354
	[NullableContext(0)]
	private enum EChildType
	{
		// Token: 0x0402B0D2 RID: 176338
		LocationSprite,
		// Token: 0x0402B0D3 RID: 176339
		TitleText,
		// Token: 0x0402B0D4 RID: 176340
		ProgressText,
		// Token: 0x0402B0D5 RID: 176341
		RedDotItem,
		// Token: 0x0402B0D6 RID: 176342
		ExtendToggle
	}
}
