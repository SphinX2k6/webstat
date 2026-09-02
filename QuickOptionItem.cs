using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02001213 RID: 4627
public class QuickOptionItem : GridProxyAbstract<BabelTowerQuick>
{
	// Token: 0x06007AB6 RID: 31414 RVA: 0x00200C2C File Offset: 0x001FEE2C
	public BabelTowerQuick? GetCurrentData()
	{
		return this.CurrentData;
	}

	// Token: 0x06007AB7 RID: 31415 RVA: 0x00200C34 File Offset: 0x001FEE34
	private bool CheckIfLocked(BabelTowerQuick data)
	{
		for (int i = 0; i < data.BuffGroupLength; i++)
		{
			int key = data.BuffGroup(i);
			IBabelTowerSelectInfo valueOrDefault = ModelBase<BabelTowerModel>.Instance.DeTermSelectInfo.GetValueOrDefault(key);
			if (valueOrDefault != null && valueOrDefault.State == EBabelTowerDeTermState.Lock)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06007AB8 RID: 31416 RVA: 0x00200C80 File Offset: 0x001FEE80
	protected unsafe override void OnRegisterComponent()
	{
		int num = 6;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIArtText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnQuickItemClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06007AB9 RID: 31417 RVA: 0x00200DAA File Offset: 0x001FEFAA
	[NullableContext(2)]
	public UUIExtendToggle GetQuickToggle()
	{
		return base.GetExtendToggle(0);
	}

	// Token: 0x06007ABA RID: 31418 RVA: 0x00200DB4 File Offset: 0x001FEFB4
	private void OnQuickItemClick(EToggleState state)
	{
		if (this.IsLocked)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("BabelQuickLevelUnlock", Array.Empty<object>());
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			if (extendToggle != null)
			{
				extendToggle.SetToggleStateForce(EToggleState.ETT_UnChecked, false, false, false);
			}
			return;
		}
		if (state == EToggleState.ETT_Checked)
		{
			Action<BabelTowerQuick, int> onQuickOptionClickWithIndex = this.OnQuickOptionClickWithIndex;
			if (onQuickOptionClickWithIndex == null)
			{
				return;
			}
			onQuickOptionClickWithIndex(this.CurrentData.Value, base.GridIndex);
		}
	}

	// Token: 0x06007ABB RID: 31419 RVA: 0x00200E18 File Offset: 0x001FF018
	public override void Refresh(BabelTowerQuick data, bool isSelected, int gridIndex)
	{
		this.QuickId = data.Id;
		this.CurrentData = new BabelTowerQuick?(data);
		this.IsLocked = this.CheckIfLocked(data);
		UUIItem rootItem = this.RootItem;
		if (rootItem != null)
		{
			rootItem.SetUIActive(true);
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), data.Des, Array.Empty<object>());
		this.SetDeLevelArt(data, isSelected);
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle != null)
		{
			extendToggle.SetToggleStateForce(isSelected ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
		}
		UUIItem item = base.GetItem(5);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(this.IsLocked);
	}

	// Token: 0x06007ABC RID: 31420 RVA: 0x00200EB4 File Offset: 0x001FF0B4
	private void SetDeLevelArt(BabelTowerQuick data, bool isSelected)
	{
		UUIArtText artText = base.GetArtText(4);
		if (artText == null)
		{
			return;
		}
		int num = 0;
		for (int i = 0; i < data.BuffGroupLength; i++)
		{
			int id = data.BuffGroup(i);
			BabelTowerDeTerm babelTowerDeTerm = ConfigBase<BabelTowerConfig>.Instance.GetBabelTowerDeTerm(id);
			num += babelTowerDeTerm.Star;
		}
		artText.SetText(((num < 10) ? "0" : "") + num.ToString());
		BabelTowerDifficulty? babelTowerDifficulty = ModelBase<BabelTowerModel>.Instance.CalculateDifficultyConfigByStarNum(data.ActivityId, num);
		if (babelTowerDifficulty != null)
		{
			FColor color = FColor.FromHex(babelTowerDifficulty.GetValueOrDefault().TextBgColor);
			UUISprite sprite = base.GetSprite(1);
			if (sprite != null)
			{
				sprite.SetColor(color);
			}
			this.SetDifficultyText(data.DifficultyTextKey);
			return;
		}
	}

	// Token: 0x06007ABD RID: 31421 RVA: 0x00200F81 File Offset: 0x001FF181
	[NullableContext(1)]
	private void SetDifficultyText(string textKey)
	{
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), textKey, Array.Empty<object>());
	}

	// Token: 0x04003ADC RID: 15068
	public int QuickId;

	// Token: 0x04003ADD RID: 15069
	[Nullable(2)]
	public Action<BabelTowerQuick, int> OnQuickOptionClickWithIndex;

	// Token: 0x04003ADE RID: 15070
	private BabelTowerQuick? CurrentData;

	// Token: 0x04003ADF RID: 15071
	private bool IsLocked;

	// Token: 0x02007566 RID: 30054
	private class EBuffItemSubComponent
	{
		// Token: 0x0402881F RID: 165919
		public const int QuickItem = 0;

		// Token: 0x04028820 RID: 165920
		public const int ColorSprite = 1;

		// Token: 0x04028821 RID: 165921
		public const int TitleText = 2;

		// Token: 0x04028822 RID: 165922
		public const int DescText = 3;

		// Token: 0x04028823 RID: 165923
		public const int DeLevelArt = 4;

		// Token: 0x04028824 RID: 165924
		public const int LockItem = 5;
	}
}
