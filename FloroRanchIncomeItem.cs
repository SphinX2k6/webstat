using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.FloroRanch;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02001C61 RID: 7265
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class FloroRanchIncomeItem : GridProxyAbstract<IFloroRanchDetailData>
{
	// Token: 0x0600D405 RID: 54277 RVA: 0x003888CC File Offset: 0x00386ACC
	protected unsafe override void OnRegisterComponent()
	{
		int num = 10;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIExtendToggle));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(9, new Action<EToggleState>(this.OnClickCallBack));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600D406 RID: 54278 RVA: 0x00388A7D File Offset: 0x00386C7D
	public override void Refresh(IFloroRanchDetailData data, bool isSelected, int gridIndex)
	{
		this.EntityData = data.EntityData;
		this.RefreshView(data.Rank);
	}

	// Token: 0x0600D407 RID: 54279 RVA: 0x00388A98 File Offset: 0x00386C98
	private void RefreshView(int rank)
	{
		base.GetText(0).SetText(rank.ToString(), true);
		FloroRanchEntityDataComponent floroRanchEntityDataComponent = this.EntityData.CheckGetComponent<FloroRanchEntityDataComponent>();
		EFloroRanchEntityType entityType = floroRanchEntityDataComponent.EntityType;
		string coinText = ModelBase<FloroRanchModel>.Instance.GetCoinText(floroRanchEntityDataComponent.Income);
		FloroRanchCurrencyConfigData floroRanchCurrencyConfig = ModelBase<FloroRanchModel>.Instance.GetFloroRanchCurrencyConfig(ECurrencyType.Coin);
		base.SetTextureByPath(floroRanchCurrencyConfig.GetSmallIcon(), base.GetTexture(6), null, null);
		base.GetText(7).SetText(coinText, true);
		base.GetItem(3).SetUIActive(!floroRanchEntityDataComponent.IsValid);
		bool flag = floroRanchEntityDataComponent.Point != -1;
		base.GetItem(5).SetUIActive(flag);
		base.GetItem(8).SetUIActive(!flag);
		switch (entityType)
		{
		case EFloroRanchEntityType.Terrain:
			this.RefreshTerrain();
			return;
		case EFloroRanchEntityType.Card:
			this.RefreshCard();
			return;
		case EFloroRanchEntityType.Toy:
			this.RefreshToy();
			return;
		default:
			return;
		}
	}

	// Token: 0x0600D408 RID: 54280 RVA: 0x00388B80 File Offset: 0x00386D80
	private void RefreshCard()
	{
		FloroRanchCardData cardData = this.EntityData.CheckGetComponent<FloroRanchCardDataComponent>().CardData;
		FloroRanchRarityData cardQualityData = cardData.GetCardQualityData();
		this.SetSpriteByPath(cardQualityData.GetRaritySmallBg(), base.GetSprite(1), true, null, null);
		base.GetSprite(1).SetUIActive(true);
		string icon = cardData.GetIcon();
		base.SetTextureByPath(icon, base.GetTexture(2), null, null);
		string name = cardData.GetName();
		base.GetText(4).ShowTextNew(name);
	}

	// Token: 0x0600D409 RID: 54281 RVA: 0x00388C04 File Offset: 0x00386E04
	private void RefreshTerrain()
	{
		FloroRanchTerrainData terrainData = this.EntityData.CheckGetComponent<FloroRanchTerrainDataComponent>().TerrainData;
		base.GetSprite(1).SetUIActive(false);
		base.SetTextureByPath(terrainData.Icon, base.GetTexture(2), null, null);
		base.GetText(4).SetText(terrainData.Name, true);
	}

	// Token: 0x0600D40A RID: 54282 RVA: 0x00388C60 File Offset: 0x00386E60
	private void RefreshToy()
	{
		FloroRanchToyData toyData = this.EntityData.CheckGetComponent<FloroRanchToyDataComponent>().ToyData;
		FloroRanchRarityData toyQualityData = toyData.GetToyQualityData();
		this.SetSpriteByPath(toyQualityData.GetRaritySmallBg(), base.GetSprite(1), true, null, null);
		base.GetSprite(1).SetUIActive(true);
		string icon = toyData.GetIcon();
		base.SetTextureByPath(icon, base.GetTexture(2), null, null);
		string name = toyData.GetName();
		base.GetText(4).ShowTextNew(name);
	}

	// Token: 0x0600D40B RID: 54283 RVA: 0x00388CE1 File Offset: 0x00386EE1
	public void BindClickCallBack(Action<int, FloroRanchEntityBase> callBack)
	{
		this.CallBack = callBack;
	}

	// Token: 0x0600D40C RID: 54284 RVA: 0x00388CEA File Offset: 0x00386EEA
	private void OnClickCallBack(EToggleState toggleState)
	{
		Action<int, FloroRanchEntityBase> callBack = this.CallBack;
		if (callBack == null)
		{
			return;
		}
		callBack(base.GridIndex, this.EntityData);
	}

	// Token: 0x0600D40D RID: 54285 RVA: 0x00388D08 File Offset: 0x00386F08
	public void SetSelectState(bool isSelect)
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(9);
		if (extendToggle == null)
		{
			return;
		}
		extendToggle.SetToggleState(isSelect ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
	}

	// Token: 0x040064DA RID: 25818
	private FloroRanchEntityBase EntityData;

	// Token: 0x040064DB RID: 25819
	private Action<int, FloroRanchEntityBase> CallBack;

	// Token: 0x02007F7A RID: 32634
	[NullableContext(0)]
	private class EComponentDefine
	{
		// Token: 0x0402B66F RID: 177775
		public const int RankNum = 0;

		// Token: 0x0402B670 RID: 177776
		public const int QualitySprite = 1;

		// Token: 0x0402B671 RID: 177777
		public const int IconTexture = 2;

		// Token: 0x0402B672 RID: 177778
		public const int LockItem = 3;

		// Token: 0x0402B673 RID: 177779
		public const int Name = 4;

		// Token: 0x0402B674 RID: 177780
		public const int IncomeItem = 5;

		// Token: 0x0402B675 RID: 177781
		public const int CoinIconTexture = 6;

		// Token: 0x0402B676 RID: 177782
		public const int IncomeCoinNum = 7;

		// Token: 0x0402B677 RID: 177783
		public const int StateItem = 8;

		// Token: 0x0402B678 RID: 177784
		public const int Toggle = 9;
	}
}
