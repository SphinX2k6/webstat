using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002D63 RID: 11619
public class WorldLevelChangeConfirmView : UiViewBase
{
	// Token: 0x06017756 RID: 96086 RVA: 0x00680A79 File Offset: 0x0067EC79
	[NullableContext(1)]
	public WorldLevelChangeConfirmView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06017757 RID: 96087 RVA: 0x00680A84 File Offset: 0x0067EC84
	protected unsafe override void OnRegisterComponent()
	{
		int num = 7;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
		this.ComponentRegisterInfos = list;
		num2 = 3;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnCloseBtnClick));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(4, new Action(this.OnCancelBtnClick));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(5, new Action(this.OnConfirmBtnClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06017758 RID: 96088 RVA: 0x00680C15 File Offset: 0x0067EE15
	protected override void OnStart()
	{
		this.SetTitleText();
		this.SetWorldLevelChangeText();
		this.SetDescribeText();
	}

	// Token: 0x06017759 RID: 96089 RVA: 0x00680C29 File Offset: 0x0067EE29
	private void SetTitleText()
	{
		base.GetText(6).SetText(ModelBase<WorldLevelModel>.Instance.WorldLevelMultilingualText, true);
	}

	// Token: 0x0601775A RID: 96090 RVA: 0x00680C44 File Offset: 0x0067EE44
	private void SetWorldLevelChangeText()
	{
		Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(0), "LvString", new <>z__ReadOnlySingleElementList<object>(ModelBase<WorldLevelModel>.Instance.CurWorldLevel));
		Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(1), "LvString", new <>z__ReadOnlySingleElementList<object>(ModelBase<WorldLevelModel>.Instance.WorldLevelChangeTarget));
	}

	// Token: 0x0601775B RID: 96091 RVA: 0x00680CA8 File Offset: 0x0067EEA8
	private void SetDescribeText()
	{
		string textById = ConfigBase<TextConfig>.Instance.GetTextById("WorldLevelINotice");
		base.GetText(2).SetText(textById ?? "", true);
	}

	// Token: 0x0601775C RID: 96092 RVA: 0x00680CDC File Offset: 0x0067EEDC
	private void OnCloseBtnClick()
	{
		Singleton<UiManager>.Instance.CloseView(EUiViewName.WorldLevelChangeConfirmView, null);
	}

	// Token: 0x0601775D RID: 96093 RVA: 0x00680CEE File Offset: 0x0067EEEE
	private void OnCancelBtnClick()
	{
		Singleton<UiManager>.Instance.CloseView(EUiViewName.WorldLevelChangeConfirmView, null);
	}

	// Token: 0x0601775E RID: 96094 RVA: 0x00680D00 File Offset: 0x0067EF00
	private void OnConfirmBtnClick()
	{
		if (ModelBase<WorldLevelModel>.Instance.CurWorldLevel > ModelBase<WorldLevelModel>.Instance.WorldLevelChangeTarget)
		{
			if (Global.BaseCharacter.CharacterActorComponent.Entity.GetComponent<BaseTagComponent>().HasTag(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.进入战斗"]))
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByText(ConfigBase<TextConfig>.Instance.GetTextById("WorldLevelDownReject") ?? "");
			}
			else
			{
				ControllerBase<WorldLevelController>.Instance.SendWorldLevelDownRequest();
			}
		}
		else
		{
			ControllerBase<WorldLevelController>.Instance.SendWorldLevelRegainRequest();
		}
		Singleton<UiManager>.Instance.CloseView(EUiViewName.WorldLevelChangeConfirmView, null);
	}
}
