using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Protocol;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001C5B RID: 7259
[Nullable(new byte[]
{
	0,
	1
})]
public class FloroRanchDungeonSettleRewardItem : GridProxyAbstract<FloroRanchSubInsSettleReward>
{
	// Token: 0x0600D3DF RID: 54239 RVA: 0x00387748 File Offset: 0x00385948
	protected unsafe override void OnRegisterComponent()
	{
		int num = 6;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickButton));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600D3E0 RID: 54240 RVA: 0x00387874 File Offset: 0x00385A74
	[NullableContext(1)]
	public override void Refresh(FloroRanchSubInsSettleReward data, bool isSelected, int gridIndex)
	{
		this.Data = data;
		if (data.Type == SubInsSettleRewardType.FloroRanchCard)
		{
			this.RefreshCard(data.Id);
			return;
		}
		if (data.Type == SubInsSettleRewardType.FloroRanchToy)
		{
			this.RefreshToy(data.Id);
			return;
		}
		this.RefreshSkill(data.Id);
	}

	// Token: 0x0600D3E1 RID: 54241 RVA: 0x003878C0 File Offset: 0x00385AC0
	private void RefreshCard(int id)
	{
		FloroRanchCardData floroRanchCardData = ModelBase<FloroRanchModel>.Instance.GetFloroRanchCardData(id);
		FloroRanchRarityData cardQualityData = floroRanchCardData.GetCardQualityData();
		base.SetTextureShowUntilLoaded(floroRanchCardData.GetIcon(), base.GetTexture(2), null);
		string rarityShopItemBg = cardQualityData.GetRarityShopItemBg();
		this.SetSpriteByPath(rarityShopItemBg, base.GetSprite(1), true, null, null);
		base.GetSprite(1).SetUIActive(true);
		base.GetButton(0).SetSelfInteractive(true);
		UUIItem item = base.GetItem(5);
		if (item != null)
		{
			item.SetUIActive(floroRanchCardData.IsSpecialPhantom);
		}
		UUIItem item2 = base.GetItem(3);
		if (item2 == null)
		{
			return;
		}
		item2.SetUIActive(false);
	}

	// Token: 0x0600D3E2 RID: 54242 RVA: 0x00387958 File Offset: 0x00385B58
	private void RefreshToy(int id)
	{
		FloroRanchToyData floroRanchToyData = ModelBase<FloroRanchModel>.Instance.GetFloroRanchToyData(id);
		FloroRanchRarityData toyQualityData = floroRanchToyData.GetToyQualityData();
		base.SetTextureShowUntilLoaded(floroRanchToyData.GetIcon(), base.GetTexture(2), null);
		string rarityShopItemBg = toyQualityData.GetRarityShopItemBg();
		this.SetSpriteByPath(rarityShopItemBg, base.GetSprite(1), true, null, null);
		base.GetSprite(1).SetUIActive(true);
		base.GetButton(0).SetSelfInteractive(true);
		UUIItem item = base.GetItem(5);
		if (item != null)
		{
			item.SetUIActive(false);
		}
		FloroRanchRaceData toyRaceData = floroRanchToyData.GetToyRaceData();
		if (toyRaceData != null)
		{
			UUIItem item2 = base.GetItem(3);
			if (item2 != null)
			{
				item2.SetUIActive(true);
			}
			base.SetTextureShowUntilLoaded(toyRaceData.SmallIcon, base.GetTexture(4), null);
			return;
		}
		UUIItem item3 = base.GetItem(3);
		if (item3 == null)
		{
			return;
		}
		item3.SetUIActive(false);
	}

	// Token: 0x0600D3E3 RID: 54243 RVA: 0x00387A1C File Offset: 0x00385C1C
	private void RefreshSkill(int id)
	{
		FloroRanchSkillData floroRanchSkillData = ModelBase<FloroRanchModel>.Instance.GetFloroRanchSkillData(id);
		base.SetTextureShowUntilLoaded(floroRanchSkillData.Icon, base.GetTexture(2), null);
		base.GetSprite(1).SetUIActive(false);
		base.GetButton(0).SetSelfInteractive(false);
		UUIItem item = base.GetItem(5);
		if (item != null)
		{
			item.SetUIActive(false);
		}
		UUIItem item2 = base.GetItem(3);
		if (item2 == null)
		{
			return;
		}
		item2.SetUIActive(false);
	}

	// Token: 0x0600D3E4 RID: 54244 RVA: 0x00387A88 File Offset: 0x00385C88
	private void OnClickButton()
	{
		if (this.Data == null)
		{
			return;
		}
		if (this.Data.Type == SubInsSettleRewardType.FloroRanchCard)
		{
			FloroRanchCardData floroRanchCardData = ModelBase<FloroRanchModel>.Instance.GetFloroRanchCardData(this.Data.Id);
			Singleton<UiManager>.Instance.OpenView(EUiViewName.FloroRanchCommonTipsView, new FloroRanchCommonTipParam
			{
				TipType = EFloroRanchCommonTipType.Card,
				CardData = floroRanchCardData
			}, null);
			return;
		}
		if (this.Data.Type == SubInsSettleRewardType.FloroRanchToy)
		{
			FloroRanchToyData floroRanchToyData = ModelBase<FloroRanchModel>.Instance.GetFloroRanchToyData(this.Data.Id);
			Singleton<UiManager>.Instance.OpenView(EUiViewName.FloroRanchCommonTipsView, new FloroRanchCommonTipParam
			{
				TipType = EFloroRanchCommonTipType.Toy,
				ToyData = floroRanchToyData
			}, null);
		}
	}

	// Token: 0x040064CC RID: 25804
	[Nullable(2)]
	private FloroRanchSubInsSettleReward Data;

	// Token: 0x02007F6F RID: 32623
	private class EComponent
	{
		// Token: 0x0402B62D RID: 177709
		public const int Button = 0;

		// Token: 0x0402B62E RID: 177710
		public const int QualitySprite = 1;

		// Token: 0x0402B62F RID: 177711
		public const int Texture = 2;

		// Token: 0x0402B630 RID: 177712
		public const int ItemToyRaceType = 3;

		// Token: 0x0402B631 RID: 177713
		public const int TextureToyRaceIcon = 4;

		// Token: 0x0402B632 RID: 177714
		public const int ItemPhantomIcon = 5;
	}
}
