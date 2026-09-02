using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Skin;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002A4D RID: 10829
public class FlySkinChildTabItem : UiPanelBase
{
	// Token: 0x06015B1A RID: 88858 RVA: 0x006059E4 File Offset: 0x00603BE4
	protected unsafe override void OnRegisterComponent()
	{
		int num = 3;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06015B1B RID: 88859 RVA: 0x00605A6E File Offset: 0x00603C6E
	protected override void OnBeforeDestroy()
	{
		this.UnBindRedDot();
	}

	// Token: 0x06015B1C RID: 88860 RVA: 0x00605A78 File Offset: 0x00603C78
	public void Update(EFlySkinType skinType)
	{
		this.SkinType = skinType;
		string flySkinTabName = ConfigBase<SkinConfig>.Instance.GetFlySkinTabName(skinType);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), flySkinTabName, Array.Empty<object>());
		this.UnBindRedDot();
		this.BindRedDot();
	}

	// Token: 0x06015B1D RID: 88861 RVA: 0x00605ABC File Offset: 0x00603CBC
	private void BindRedDot()
	{
		UUIItem item = base.GetItem(2);
		ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.FlySkinChildTab, item, null, (int)this.SkinType);
	}

	// Token: 0x06015B1E RID: 88862 RVA: 0x00605AE8 File Offset: 0x00603CE8
	private void UnBindRedDot()
	{
		UUIItem item = base.GetItem(2);
		ControllerBase<RedDotController>.Instance.UnBindGivenUi(ERedDotName.FlySkinChildTab, item, (int)this.SkinType);
	}

	// Token: 0x06015B1F RID: 88863 RVA: 0x00605B10 File Offset: 0x00603D10
	public void SetItemToggleState(EToggleState state, bool? bFireEvent = null)
	{
		base.GetExtendToggle(1).SetToggleState(state, bFireEvent != null && bFireEvent.Value, false, false);
	}

	// Token: 0x06015B20 RID: 88864 RVA: 0x00605B35 File Offset: 0x00603D35
	[NullableContext(1)]
	public void AddItemToggleStateChange(Action<EToggleState> stateChangeCallback)
	{
		base.GetExtendToggle(1).OnStateChange.Add(stateChangeCallback);
	}

	// Token: 0x06015B21 RID: 88865 RVA: 0x00605B49 File Offset: 0x00603D49
	[NullableContext(1)]
	public void SetCanItemToggleStateChange(Func<bool> canChangeCallBack)
	{
		base.GetExtendToggle(1).CanExecuteChange.Bind(canChangeCallBack);
	}

	// Token: 0x0400A688 RID: 42632
	private EFlySkinType SkinType = EFlySkinType.Paragliding;

	// Token: 0x02008DD9 RID: 36313
	private enum EComponent
	{
		// Token: 0x0402FBC2 RID: 195522
		NameText,
		// Token: 0x0402FBC3 RID: 195523
		ItemToggle,
		// Token: 0x0402FBC4 RID: 195524
		RedDotItem
	}
}
