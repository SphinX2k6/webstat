using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x0200142C RID: 5164
internal class BuffScrollItem : UiPanelBase
{
	// Token: 0x06008F95 RID: 36757 RVA: 0x0025B1C4 File Offset: 0x002593C4
	protected unsafe override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(1, typeof(UUITexture)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIItem))
		};
		int num = 1;
		List<ValueTuple<int, Delegate>> list = new List<ValueTuple<int, Delegate>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list, num);
		Span<ValueTuple<int, Delegate>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list);
		int index = 0;
		*span[index] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickToggle));
		this.BtnBindInfo = list;
	}

	// Token: 0x06008F96 RID: 36758 RVA: 0x0025B2A0 File Offset: 0x002594A0
	protected override void OnStart()
	{
		base.GetExtendToggle(0).CanExecuteChange.Unbind();
		base.GetExtendToggle(0).CanExecuteChange.Bind(new Func<bool>(this.CanClickLikeToggle));
		base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
	}

	// Token: 0x06008F97 RID: 36759 RVA: 0x0025B2EC File Offset: 0x002594EC
	private bool CanClickLikeToggle()
	{
		return this.CurrentData != null && this.CurrentData.CheckClickAble != null && this.CurrentData.CheckClickAble(this.CurrentData);
	}

	// Token: 0x06008F98 RID: 36760 RVA: 0x0025B31D File Offset: 0x0025951D
	private void OnClickToggle(EToggleState toggleState)
	{
		this.CurrentData.OnClickToggle(this.CurrentData);
	}

	// Token: 0x06008F99 RID: 36761 RVA: 0x0025B338 File Offset: 0x00259538
	public void SetToggleActiveState(bool state)
	{
		base.GetExtendToggle(0).RootUIComp.Get().SetUIActive(state);
	}

	// Token: 0x06008F9A RID: 36762 RVA: 0x0025B35F File Offset: 0x0025955F
	[NullableContext(1)]
	public void Refresh(BuffScrollItemData data, bool isSelected, int gridIndex)
	{
		this.CurrentData = data;
		this.RefreshLockState();
		this.RefreshToggleState();
		this.RefreshName();
		this.RefreshDesc();
		this.RefreshBuffTexture();
		this.RefreshSelectedTag();
	}

	// Token: 0x06008F9B RID: 36763 RVA: 0x0025B38C File Offset: 0x0025958C
	private void RefreshSelectedTag()
	{
		base.GetItem(5).SetUIActive(this.CurrentData.SelectedAtStart);
	}

	// Token: 0x06008F9C RID: 36764 RVA: 0x0025B3A8 File Offset: 0x002595A8
	private void RefreshToggleState()
	{
		EToggleState state = this.CurrentData.Selected ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
		base.GetExtendToggle(0).SetToggleState(state, false, false, false);
	}

	// Token: 0x06008F9D RID: 36765 RVA: 0x0025B3D8 File Offset: 0x002595D8
	private void RefreshLockState()
	{
		base.GetItem(4).SetUIActive(false);
	}

	// Token: 0x06008F9E RID: 36766 RVA: 0x0025B3E8 File Offset: 0x002595E8
	private void RefreshName()
	{
		MowTowerBuffRe? mowingTowerBuffById = ConfigBase<MowingTowerConfig>.Instance.GetMowingTowerBuffById(this.CurrentData.BuffId);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), mowingTowerBuffById.Value.Name, Array.Empty<object>());
	}

	// Token: 0x06008F9F RID: 36767 RVA: 0x0025B430 File Offset: 0x00259630
	private void RefreshDesc()
	{
		MowTowerBuffRe? mowingTowerBuffById = ConfigBase<MowingTowerConfig>.Instance.GetMowingTowerBuffById(this.CurrentData.BuffId);
		List<string> list = new List<string>();
		int descriptionParamLength = mowingTowerBuffById.Value.DescriptionParamLength;
		for (int i = 0; i < descriptionParamLength; i++)
		{
			string text = mowingTowerBuffById.Value.DescriptionParam(i);
			Match match = new Regex("\\[(.*?)\\]").Match(text ?? "");
			if (match.Success && match.Groups.Count > 1)
			{
				string[] array = match.Groups[1].Value.Split(',', StringSplitOptions.None);
				for (int j = 0; j < array.Length; j++)
				{
					list.Add(array[j]);
				}
			}
		}
		object[] array2 = new object[list.Count];
		for (int k = 0; k < list.Count; k++)
		{
			array2[k] = list[k];
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), mowingTowerBuffById.Value.Description, array2);
	}

	// Token: 0x06008FA0 RID: 36768 RVA: 0x0025B554 File Offset: 0x00259754
	private void RefreshBuffTexture()
	{
		string texture = ConfigBase<MowingTowerConfig>.Instance.GetMowingTowerBuffById(this.CurrentData.BuffId).Value.Texture;
		base.SetTextureByPath(texture, base.GetTexture(1), null, null);
	}

	// Token: 0x040042A3 RID: 17059
	[Nullable(2)]
	private BuffScrollItemData CurrentData;
}
