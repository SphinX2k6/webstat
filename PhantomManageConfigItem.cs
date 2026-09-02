using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x0200201B RID: 8219
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
public class PhantomManageConfigItem : GridProxyAbstract<PhantomManageConfigData>, IStaticVariableResetter
{
	// Token: 0x0600F9C6 RID: 63942 RVA: 0x004463CC File Offset: 0x004445CC
	static PhantomManageConfigItem()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(PhantomManageConfigItem.CreateStaticDefaultValue), new Action(PhantomManageConfigItem.ResetStaticDefaultValue));
	}

	// Token: 0x0600F9C7 RID: 63943 RVA: 0x004463EB File Offset: 0x004445EB
	public static void CreateStaticDefaultValue()
	{
		PhantomManageConfigItem.CallbackBtnSelect = null;
		PhantomManageConfigItem.ViewModel = null;
	}

	// Token: 0x0600F9C8 RID: 63944 RVA: 0x004463F9 File Offset: 0x004445F9
	public static void ResetStaticDefaultValue()
	{
		PhantomManageConfigItem.CallbackBtnSelect = null;
		PhantomManageConfigItem.ViewModel = null;
	}

	// Token: 0x0600F9C9 RID: 63945 RVA: 0x00446408 File Offset: 0x00444608
	protected unsafe override void OnRegisterComponent()
	{
		int num = 4;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIExtendToggle));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(3, new Action<EToggleState>(this.OnClickedBtnSelect));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600F9CA RID: 63946 RVA: 0x004464F0 File Offset: 0x004446F0
	protected override void OnStart()
	{
		base.GetExtendToggle(3).CanExecuteChange.Bind(() => base.GetExtendToggle(3).GetToggleState() != EToggleState.ETT_Checked || !this.GetSelectState());
		this.Canvas = (base.GetRootActor().GetComponentByClass(ULGUICanvas.StaticClass()) as ULGUICanvas);
	}

	// Token: 0x0600F9CB RID: 63947 RVA: 0x00446530 File Offset: 0x00444730
	[NullableContext(1)]
	public override void Refresh(PhantomManageConfigData data, bool isSelected, int gridIndex)
	{
		data.SetDisplayIndex(base.DisplayIndex);
		this.Data = data;
		string indexString = data.GetIndexString();
		base.GetText(0).SetText(indexString, true);
		base.GetText(1).SetText(data.GetName(), true);
		base.GetSprite(2).SetUIActive(data.GetIsOn());
		bool selectState = this.GetSelectState();
		EToggleState state = selectState ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
		bool editState = this.GetEditState();
		base.GetExtendToggle(3).SetToggleState(state, false, false, false);
		base.GetExtendToggle(3).SetSelfInteractive(!editState);
		base.GetRootItem().SetBubbleUpToParent(!editState);
		this.Canvas.SetSortOrder((selectState && editState) ? 1 : 0, true);
	}

	// Token: 0x0600F9CC RID: 63948 RVA: 0x004465E5 File Offset: 0x004447E5
	[NullableContext(1)]
	public override object GetKey(PhantomManageConfigData data, int displayIndex)
	{
		return data.GetIndex();
	}

	// Token: 0x0600F9CD RID: 63949 RVA: 0x004465F2 File Offset: 0x004447F2
	private void OnClickedBtnSelect(EToggleState toggleState)
	{
		if (this.Data != null && PhantomManageConfigItem.CallbackBtnSelect != null)
		{
			PhantomManageConfigItem.CallbackBtnSelect(this.Data);
		}
	}

	// Token: 0x0600F9CE RID: 63950 RVA: 0x00446614 File Offset: 0x00444814
	private bool GetSelectState()
	{
		if (this.Data != null && PhantomManageConfigItem.ViewModel != null)
		{
			PhantomManageConfigData selectConfig = PhantomManageConfigItem.ViewModel.GetSelectConfig();
			return selectConfig.GetIndex() == this.Data.GetIndex() && this.Data.GetType() == selectConfig.GetType();
		}
		return false;
	}

	// Token: 0x0600F9CF RID: 63951 RVA: 0x00446665 File Offset: 0x00444865
	private bool GetEditState()
	{
		return this.Data != null && PhantomManageConfigItem.ViewModel != null && PhantomManageConfigItem.ViewModel.GetEditState();
	}

	// Token: 0x0400780E RID: 30734
	private PhantomManageConfigData Data;

	// Token: 0x0400780F RID: 30735
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public static Action<PhantomManageConfigData> CallbackBtnSelect;

	// Token: 0x04007810 RID: 30736
	public static PhantomManageConfigViewModel ViewModel;

	// Token: 0x04007811 RID: 30737
	private ULGUICanvas Canvas;

	// Token: 0x020083B7 RID: 33719
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402CA99 RID: 182937
		TextNumber,
		// Token: 0x0402CA9A RID: 182938
		TextName,
		// Token: 0x0402CA9B RID: 182939
		SpriteOn,
		// Token: 0x0402CA9C RID: 182940
		BtnItem
	}
}
