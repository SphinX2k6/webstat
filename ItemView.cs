using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02002034 RID: 8244
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class ItemView : GridProxyAbstract<global::ItemViewData>
{
	// Token: 0x0600FB0B RID: 64267 RVA: 0x0044EAB0 File Offset: 0x0044CCB0
	protected unsafe override void OnRegisterComponent()
	{
		int num = 19;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(13, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(15, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(17, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(18, typeof(UUIText));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(5, new Action<EToggleState>(this.OnToggleStateChanged));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600FB0C RID: 64268 RVA: 0x0044ED92 File Offset: 0x0044CF92
	protected override void OnStart()
	{
		this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
	}

	// Token: 0x0600FB0D RID: 64269 RVA: 0x0044EDA5 File Offset: 0x0044CFA5
	protected override void OnBeforeDestroy()
	{
		this.OnItemButtonClickedCallback = null;
		this.LevelSequencePlayer.Clear();
		this.LevelSequencePlayer = null;
	}

	// Token: 0x0600FB0E RID: 64270 RVA: 0x0044EDC0 File Offset: 0x0044CFC0
	private void OnToggleStateChanged(EToggleState state)
	{
		if (this.OnItemButtonClickedCallback != null)
		{
			this.OnItemButtonClickedCallback(this.ItemViewData);
		}
	}

	// Token: 0x0600FB0F RID: 64271 RVA: 0x0044EDDB File Offset: 0x0044CFDB
	public void BindOnItemButtonClickedCallback(Action<global::ItemViewData> onItemButtonClicked)
	{
		this.OnItemButtonClickedCallback = onItemButtonClicked;
	}

	// Token: 0x0600FB10 RID: 64272 RVA: 0x0044EDE4 File Offset: 0x0044CFE4
	public override void Refresh(global::ItemViewData data, bool isSelected, int gridIndex)
	{
		this.RefreshItemViewByItemData(data);
		this.SetSelected(isSelected);
	}

	// Token: 0x0600FB11 RID: 64273 RVA: 0x0044EDF4 File Offset: 0x0044CFF4
	public override void OnSelected(bool fireEvent)
	{
		this.SetSelected(true);
	}

	// Token: 0x0600FB12 RID: 64274 RVA: 0x0044EDFD File Offset: 0x0044CFFD
	public override void OnDeselected(bool fireEvent)
	{
		this.SetSelected(false);
	}

	// Token: 0x0600FB13 RID: 64275 RVA: 0x0044EE08 File Offset: 0x0044D008
	public void RefreshItemViewByItemData(global::ItemViewData itemViewData)
	{
		this.ItemViewData = itemViewData;
		InventoryDefine.IItemViewDataInfo itemViewInfo = itemViewData.GetItemViewInfo();
		int qualityId = itemViewInfo.QualityId;
		bool isLock = itemViewInfo.IsLock;
		bool isNewItem = itemViewInfo.IsNewItem;
		InventoryDefine.EItemDataType itemDataType = itemViewInfo.ItemDataType;
		this.SetItemTexture();
		this.SetQualityIcon(qualityId);
		this.SetLock(isLock);
		this.SetIsNewItem(isNewItem);
		this.RefreshCdTimeDisplay();
		switch (itemDataType)
		{
		case InventoryDefine.EItemDataType.CommonItem:
		{
			int count = this.ItemViewData.GetCount();
			this.SetItemCount(count);
			return;
		}
		case InventoryDefine.EItemDataType.WeaponItem:
		{
			int uniqueId = (this.ItemViewData.GetItemDataBase() as WeaponItemData).GetUniqueId();
			int level = ModelBase<WeaponModel>.Instance.GetWeaponDataByIncId(uniqueId).GetLevel();
			this.SetItemLevel(level);
			return;
		}
		case InventoryDefine.EItemDataType.PhantomItem:
		{
			int uniqueId2 = (this.ItemViewData.GetItemDataBase() as PhantomItemData).GetUniqueId();
			int phantomLevel = ModelBase<PhantomBattleModel>.Instance.GetPhantomBattleData(uniqueId2).GetPhantomLevel();
			this.SetItemLevel(phantomLevel);
			return;
		}
		}
		int count2 = this.ItemViewData.GetCount();
		this.SetItemCount(count2);
	}

	// Token: 0x0600FB14 RID: 64276 RVA: 0x0044EF08 File Offset: 0x0044D108
	private void SetItemTexture()
	{
		UUITexture texture = base.GetTexture(0);
		base.SetItemIcon(texture, this.ItemViewData.GetConfigId(), null, null);
	}

	// Token: 0x0600FB15 RID: 64277 RVA: 0x0044EF3C File Offset: 0x0044D13C
	private void SetQualityIcon(int qualityId)
	{
		UUISprite sprite = base.GetSprite(2);
		if (sprite == null)
		{
			return;
		}
		base.SetItemQualityIcon(sprite, this.ItemViewData.GetConfigId(), null, CommonDefine.EQualityIconType.BackgroundSprite, null);
	}

	// Token: 0x0600FB16 RID: 64278 RVA: 0x0044EF74 File Offset: 0x0044D174
	public void SetSelected(bool bSelected)
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(5);
		if (bSelected)
		{
			extendToggle.SetToggleState(EToggleState.ETT_Checked, false, false, false);
			return;
		}
		extendToggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
	}

	// Token: 0x0600FB17 RID: 64279 RVA: 0x0044EFA4 File Offset: 0x0044D1A4
	private void SetLock(bool bLock)
	{
		UUISprite sprite = base.GetSprite(6);
		if (sprite == null)
		{
			return;
		}
		sprite.SetUIActive(bLock);
	}

	// Token: 0x0600FB18 RID: 64280 RVA: 0x0044EFC4 File Offset: 0x0044D1C4
	public void SetIsNewItem(bool bNewItem)
	{
		base.GetSprite(7).SetUIActive(bNewItem);
	}

	// Token: 0x0600FB19 RID: 64281 RVA: 0x0044EFD4 File Offset: 0x0044D1D4
	private void SetItemCount(int count)
	{
		UUIText text = base.GetText(4);
		if (text == null)
		{
			return;
		}
		text.SetText(count.ToString(), true);
		text.SetUIActive(true);
		UUIText text2 = base.GetText(3);
		if (text2 != null)
		{
			text2.SetUIActive(false);
		}
	}

	// Token: 0x0600FB1A RID: 64282 RVA: 0x0044F014 File Offset: 0x0044D214
	private void SetItemLevel(int weaponLevel)
	{
		UUIText text = base.GetText(3);
		if (text == null)
		{
			return;
		}
		Singleton<LguiUtil>.Instance.SetLocalText(text, "LevelShow", new <>z__ReadOnlySingleElementList<object>(weaponLevel));
		text.SetUIActive(true);
		UUIText text2 = base.GetText(4);
		if (text2 != null)
		{
			text2.SetUIActive(false);
		}
	}

	// Token: 0x0600FB1B RID: 64283 RVA: 0x0044F061 File Offset: 0x0044D261
	public void SetRoleHeadVisible(bool bVisible)
	{
		base.GetItem(14).SetUIActive(bVisible);
	}

	// Token: 0x0600FB1C RID: 64284 RVA: 0x0044F074 File Offset: 0x0044D274
	private void SetCdItemVisible(bool bVisible)
	{
		UUIItem item = base.GetItem(16);
		if (item.bIsUIActive == bVisible)
		{
			return;
		}
		item.SetUIActive(bVisible);
		if (bVisible)
		{
			this.LevelSequencePlayer.PlayLevelSequenceByName("EnterCd", false, null, false);
		}
	}

	// Token: 0x0600FB1D RID: 64285 RVA: 0x0044F0BC File Offset: 0x0044D2BC
	public void RefreshCdTimeDisplay()
	{
		int configId = this.ItemViewData.GetConfigId();
		BuffItemModel instance = ModelBase<BuffItemModel>.Instance;
		double buffItemRemainCdTime = instance.GetBuffItemRemainCdTime(configId);
		if (buffItemRemainCdTime <= 0.0)
		{
			this.SetCdItemVisible(false);
			return;
		}
		double buffItemTotalCdTime = instance.GetBuffItemTotalCdTime(configId);
		this.SetCdTimePercent(buffItemRemainCdTime, buffItemTotalCdTime);
		this.SetCdItemVisible(true);
	}

	// Token: 0x0600FB1E RID: 64286 RVA: 0x0044F110 File Offset: 0x0044D310
	private void SetCdTimePercent(double remainingCdTime, double totalCdTime)
	{
		double num = Math.Ceiling(remainingCdTime);
		UUISprite sprite = base.GetSprite(17);
		UUIText text = base.GetText(18);
		double num2 = num / totalCdTime;
		sprite.SetFillAmount((float)num2);
		text.SetText(num.ToString(), true);
	}

	// Token: 0x0400789C RID: 30876
	[Nullable(2)]
	private global::ItemViewData ItemViewData;

	// Token: 0x0400789D RID: 30877
	[Nullable(2)]
	private LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x0400789E RID: 30878
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Action<global::ItemViewData> OnItemButtonClickedCallback;

	// Token: 0x020083DC RID: 33756
	[NullableContext(0)]
	private enum EChildComponentType
	{
		// Token: 0x0402CB32 RID: 183090
		ItemTexture,
		// Token: 0x0402CB33 RID: 183091
		StarUiItem,
		// Token: 0x0402CB34 RID: 183092
		QualitySprite,
		// Token: 0x0402CB35 RID: 183093
		LevelText,
		// Token: 0x0402CB36 RID: 183094
		CountText,
		// Token: 0x0402CB37 RID: 183095
		ItemToggle,
		// Token: 0x0402CB38 RID: 183096
		LockSprite,
		// Token: 0x0402CB39 RID: 183097
		NewFlagSprite,
		// Token: 0x0402CB3A RID: 183098
		Star1,
		// Token: 0x0402CB3B RID: 183099
		Star2,
		// Token: 0x0402CB3C RID: 183100
		Star3,
		// Token: 0x0402CB3D RID: 183101
		Star4,
		// Token: 0x0402CB3E RID: 183102
		Star5,
		// Token: 0x0402CB3F RID: 183103
		Star6,
		// Token: 0x0402CB40 RID: 183104
		RoleHeadItem,
		// Token: 0x0402CB41 RID: 183105
		RoleHeadTexture,
		// Token: 0x0402CB42 RID: 183106
		CdItem,
		// Token: 0x0402CB43 RID: 183107
		CdSprite,
		// Token: 0x0402CB44 RID: 183108
		CdText
	}
}
