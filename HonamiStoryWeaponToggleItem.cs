using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.HonamiStory;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001F72 RID: 8050
[NullableContext(1)]
[Nullable(0)]
public class HonamiStoryWeaponToggleItem : UiPanelBase, IGridProxy<IHonamiStoryWeaponToggleItemData>
{
	// Token: 0x17001267 RID: 4711
	// (get) Token: 0x0600F116 RID: 61718 RVA: 0x0041E077 File Offset: 0x0041C277
	// (set) Token: 0x0600F117 RID: 61719 RVA: 0x0041E07F File Offset: 0x0041C27F
	[Nullable(new byte[]
	{
		2,
		1,
		1,
		1
	})]
	public IScrollViewDelegate<IGridProxy<IHonamiStoryWeaponToggleItemData>, IHonamiStoryWeaponToggleItemData> ScrollViewDelegate { [return: Nullable(new byte[]
	{
		2,
		1,
		1,
		1
	})] get; [param: Nullable(new byte[]
	{
		2,
		1,
		1,
		1
	})] set; }

	// Token: 0x17001268 RID: 4712
	// (get) Token: 0x0600F118 RID: 61720 RVA: 0x0041E088 File Offset: 0x0041C288
	// (set) Token: 0x0600F119 RID: 61721 RVA: 0x0041E090 File Offset: 0x0041C290
	public int GridIndex { get; set; }

	// Token: 0x17001269 RID: 4713
	// (get) Token: 0x0600F11A RID: 61722 RVA: 0x0041E099 File Offset: 0x0041C299
	// (set) Token: 0x0600F11B RID: 61723 RVA: 0x0041E0A1 File Offset: 0x0041C2A1
	public int DisplayIndex { get; set; }

	// Token: 0x0600F11C RID: 61724 RVA: 0x0041E0AC File Offset: 0x0041C2AC
	protected unsafe override void OnRegisterComponent()
	{
		int num = 16;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(13, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(14, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(15, typeof(UUISprite));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(5, new Action<EToggleState>(this.OnToggle));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600F11D RID: 61725 RVA: 0x0041E328 File Offset: 0x0041C528
	protected override UniTask OnBeforeStartAsync()
	{
		HonamiStoryWeaponToggleItem.<OnBeforeStartAsync>d__20 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<HonamiStoryWeaponToggleItem.<OnBeforeStartAsync>d__20>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600F11E RID: 61726 RVA: 0x0041E36B File Offset: 0x0041C56B
	public void Refresh(IHonamiStoryWeaponToggleItemData data, bool isSelected, int gridIndex)
	{
		this.WeaponIdInternal = data.WeaponId;
		this.UseWayInternal = data.UseWay;
		if (data.EquipData != null)
		{
			this.EquipData = data.EquipData;
		}
		this.RefreshItem();
	}

	// Token: 0x0600F11F RID: 61727 RVA: 0x0041E3A0 File Offset: 0x0041C5A0
	public void RefreshItem()
	{
		UUIItem item = base.GetItem(9);
		if (item != null)
		{
			item.SetUIActive(false);
		}
		UUIItem item2 = base.GetItem(11);
		if (item2 != null)
		{
			item2.SetUIActive(false);
		}
		HonamiStoryWeaponData weaponData = ModelBase<HonamiStoryModel>.Instance.GetWeaponData(this.WeaponIdInternal);
		if (this.WeaponIdInternal <= 0 || weaponData == null)
		{
			UUIItem item3 = base.GetItem(8);
			if (item3 != null)
			{
				item3.SetUIActive(false);
			}
			string resourceId = HonamiStoryUtil.CheckInHonamiStoryDungeon() ? "SP_EquipBozaiLock" : "SP_EquipBozaiNor";
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resourceId);
			UUISprite sprite = base.GetSprite(13);
			this.SetSpriteByPath(resourcePath, sprite, false, null, delegate(bool _)
			{
				UUIExtendToggleSpriteTransition uuiextendToggleSpriteTransition = sprite.GetOwner().GetComponentByClass(UUIExtendToggleSpriteTransition.StaticClass()) as UUIExtendToggleSpriteTransition;
				if (uuiextendToggleSpriteTransition == null)
				{
					return;
				}
				uuiextendToggleSpriteTransition.SetAllStateSprite(sprite.GetSprite());
			});
			sprite.SetUIActive(true);
			return;
		}
		HonamiStoryWeapon? config = weaponData.Config;
		bool isUnlock = weaponData.IsUnlock;
		UUIItem item4 = base.GetItem(7);
		if (item4 != null)
		{
			item4.SetUIActive(!isUnlock);
		}
		UUIItem item5 = base.GetItem(6);
		if (item5 != null)
		{
			item5.SetUIActive(isUnlock);
		}
		if (isUnlock)
		{
			int[] source = config.Value.SuitId();
			this.RefreshSuitActiveItems(source.ToList<int>());
			if (this.UseWayInternal == EHonamiStoryWeaponUseWay.Change)
			{
				HonamiStoryRoleEquipData honamiStoryRoleEquipData = this.EquipData;
				if (honamiStoryRoleEquipData == null)
				{
					honamiStoryRoleEquipData = ModelBase<HonamiStoryModel>.Instance.GetWeaponEquipState(this.WeaponIdInternal);
				}
				if (honamiStoryRoleEquipData != null)
				{
					int roleId = honamiStoryRoleEquipData.GetRoleId();
					if (roleId > 0)
					{
						RoleInfo? roleConfig = ConfigBase<RoleConfig>.Instance.GetRoleConfig(roleId);
						if (roleConfig != null)
						{
							base.SetRoleIcon(roleConfig.Value.RoleHeadIcon, base.GetTexture(10), roleId, null, null);
							UUIItem item6 = base.GetItem(9);
							if (item6 != null)
							{
								item6.SetUIActive(true);
							}
						}
					}
					else
					{
						int position = honamiStoryRoleEquipData.GetPosition();
						base.GetText(12).SetText((position + 1).ToString(), true);
						UUIItem item7 = base.GetItem(11);
						if (item7 != null)
						{
							item7.SetUIActive(true);
						}
					}
				}
			}
		}
		this.SetNewItemShow(false);
		base.SetTextureByPath(config.Value.IconToggle, base.GetTexture(0), null, null);
		UUIItem item8 = base.GetItem(8);
		if (item8 != null)
		{
			item8.SetUIActive(true);
		}
		base.GetSprite(13).SetUIActive(false);
	}

	// Token: 0x0600F120 RID: 61728 RVA: 0x0041E5EC File Offset: 0x0041C7EC
	public void RefreshCurSelectLightSprite(HonamiStoryRoleEquipData curSelectEquipData)
	{
		base.GetSprite(14).SetUIActive(false);
		base.GetSprite(15).SetUIActive(false);
		if (this.UseWayInternal == EHonamiStoryWeaponUseWay.Change)
		{
			HonamiStoryRoleEquipData honamiStoryRoleEquipData = this.EquipData;
			if (honamiStoryRoleEquipData == null)
			{
				honamiStoryRoleEquipData = ModelBase<HonamiStoryModel>.Instance.GetWeaponEquipState(this.WeaponIdInternal);
			}
			if (honamiStoryRoleEquipData != null && honamiStoryRoleEquipData.GetPosition() == curSelectEquipData.GetPosition())
			{
				base.GetSprite(14).SetUIActive(true);
				base.GetSprite(15).SetUIActive(true);
			}
		}
	}

	// Token: 0x0600F121 RID: 61729 RVA: 0x0041E668 File Offset: 0x0041C868
	private void RefreshSuitActiveItems(List<int> suitIdList)
	{
		HonamiStoryRoleEquipData honamiStoryRoleEquipData = this.EquipData;
		if (honamiStoryRoleEquipData == null)
		{
			honamiStoryRoleEquipData = ModelBase<HonamiStoryModel>.Instance.GetWeaponEquipState(this.WeaponIdInternal);
		}
		int num = Math.Min(suitIdList.Count, 3);
		for (int i = 0; i < num; i++)
		{
			int suitId = suitIdList[i];
			this.SuitActiveItemList[i].Refresh(new HonamiStoryWeaponSuitData
			{
				SuitId = suitId,
				EquipData = honamiStoryRoleEquipData
			});
			this.SuitActiveItemList[i].SetUiActive(true);
		}
		for (int j = num; j < 3; j++)
		{
			this.SuitActiveItemList[j].SetUiActive(false);
		}
	}

	// Token: 0x1700126A RID: 4714
	// (get) Token: 0x0600F122 RID: 61730 RVA: 0x0041E70A File Offset: 0x0041C90A
	public int WeaponId
	{
		get
		{
			return this.WeaponIdInternal;
		}
	}

	// Token: 0x0600F123 RID: 61731 RVA: 0x0041E712 File Offset: 0x0041C912
	[NullableContext(2)]
	public HonamiStoryRoleEquipData GetEquipData()
	{
		return this.EquipData;
	}

	// Token: 0x0600F124 RID: 61732 RVA: 0x0041E71A File Offset: 0x0041C91A
	public void BindWeaponToggleClick(Action<HonamiStoryWeaponToggleItem> callback)
	{
		this.OnWeaponToggleClick = callback;
	}

	// Token: 0x0600F125 RID: 61733 RVA: 0x0041E724 File Offset: 0x0041C924
	private void OnUndeterminedClicked()
	{
		HashSet<int> hashSet = LocalStorage.GetPlayer<HashSet<int>>(ELocalStoragePlayerKey.HonamiStoryWeaponUnlockSet, null) ?? new HashSet<int>();
		hashSet.Remove(this.WeaponIdInternal);
		LocalStorage.SetPlayer<HashSet<int>>(ELocalStoragePlayerKey.HonamiStoryWeaponUnlockSet, hashSet);
		Action<HonamiStoryWeaponToggleItem> onWeaponToggleClick = this.OnWeaponToggleClick;
		if (onWeaponToggleClick != null)
		{
			onWeaponToggleClick(this);
		}
		this.SetNewItemShow(true);
	}

	// Token: 0x0600F126 RID: 61734 RVA: 0x0041E778 File Offset: 0x0041C978
	private void OnToggle(EToggleState toggleState)
	{
		this.OnUndeterminedClicked();
	}

	// Token: 0x0600F127 RID: 61735 RVA: 0x0041E780 File Offset: 0x0041C980
	public void OnSelected()
	{
		base.GetExtendToggle(5).SetToggleStateForce(EToggleState.ETT_Checked, false, false, false);
	}

	// Token: 0x0600F128 RID: 61736 RVA: 0x0041E792 File Offset: 0x0041C992
	public void OnDeselected()
	{
		base.GetExtendToggle(5).SetToggleStateForce(EToggleState.ETT_UnChecked, false, false, false);
	}

	// Token: 0x0600F129 RID: 61737 RVA: 0x0041E7A4 File Offset: 0x0041C9A4
	public void Clear()
	{
	}

	// Token: 0x0600F12A RID: 61738 RVA: 0x0041E7A6 File Offset: 0x0041C9A6
	public void OnSelected(bool fireEvent)
	{
	}

	// Token: 0x0600F12B RID: 61739 RVA: 0x0041E7A8 File Offset: 0x0041C9A8
	public void OnDeselected(bool fireEvent)
	{
	}

	// Token: 0x0600F12C RID: 61740 RVA: 0x0041E7AA File Offset: 0x0041C9AA
	public object GetKey(IHonamiStoryWeaponToggleItemData data, int gridIndex)
	{
		return this.GridIndex;
	}

	// Token: 0x0600F12D RID: 61741 RVA: 0x0041E7B7 File Offset: 0x0041C9B7
	public void SetIsEnable(bool value)
	{
		UUIItem rootItem = this.RootItem;
		if (rootItem != null)
		{
			rootItem.SetAlpha(value ? 1f : 0.4f);
		}
		UUIExtendToggle extendToggle = base.GetExtendToggle(5);
		if (extendToggle == null)
		{
			return;
		}
		extendToggle.SetSelfInteractive(value);
	}

	// Token: 0x0600F12E RID: 61742 RVA: 0x0041E7EC File Offset: 0x0041C9EC
	public void SetNewItemShow(bool needEmit = true)
	{
		HashSet<int> hashSet = LocalStorage.GetPlayer<HashSet<int>>(ELocalStoragePlayerKey.HonamiStoryWeaponUnlockSet, null) ?? new HashSet<int>();
		if (this.UseWayInternal == EHonamiStoryWeaponUseWay.Equip)
		{
			bool uiactive = hashSet.Count > 0;
			UUIItem item = base.GetItem(4);
			if (item != null)
			{
				item.SetUIActive(uiactive);
			}
		}
		else
		{
			bool uiactive2 = hashSet.Contains(this.WeaponIdInternal);
			UUIItem item2 = base.GetItem(4);
			if (item2 != null)
			{
				item2.SetUIActive(uiactive2);
			}
		}
		if (needEmit)
		{
			Singleton<EventSystem>.Instance.Emit(EEventName.OnHonamiStoryBackpackClickWeapon);
		}
	}

	// Token: 0x0600F12F RID: 61743 RVA: 0x0041E868 File Offset: 0x0041CA68
	public void ResetToggleState()
	{
		base.GetExtendToggle(5).SetToggleStateForce(EToggleState.ETT_UnChecked, false, false, false);
	}

	// Token: 0x040073C8 RID: 29640
	private const int SUIT_ITEM_COUNT = 3;

	// Token: 0x040073C9 RID: 29641
	private int WeaponIdInternal;

	// Token: 0x040073CA RID: 29642
	private EHonamiStoryWeaponUseWay UseWayInternal;

	// Token: 0x040073CB RID: 29643
	private Action<HonamiStoryWeaponToggleItem> OnWeaponToggleClick;

	// Token: 0x040073CC RID: 29644
	private List<HonamiStoryWeaponSuitActiveItem> SuitActiveItemList = new List<HonamiStoryWeaponSuitActiveItem>();

	// Token: 0x040073CD RID: 29645
	[Nullable(2)]
	private HonamiStoryRoleEquipData EquipData;

	// Token: 0x0200830D RID: 33549
	[NullableContext(0)]
	private enum EHonamiStoryWeaponToggleItemComponent
	{
		// Token: 0x0402C6EB RID: 181995
		IconTexture,
		// Token: 0x0402C6EC RID: 181996
		SuitItemOne,
		// Token: 0x0402C6ED RID: 181997
		SuitItemTwo,
		// Token: 0x0402C6EE RID: 181998
		SuitItemThree,
		// Token: 0x0402C6EF RID: 181999
		NewItem,
		// Token: 0x0402C6F0 RID: 182000
		Toggle,
		// Token: 0x0402C6F1 RID: 182001
		SuitPanel,
		// Token: 0x0402C6F2 RID: 182002
		LockPanel,
		// Token: 0x0402C6F3 RID: 182003
		InfoPanel,
		// Token: 0x0402C6F4 RID: 182004
		RoleItem,
		// Token: 0x0402C6F5 RID: 182005
		RoleTexture,
		// Token: 0x0402C6F6 RID: 182006
		NumItem,
		// Token: 0x0402C6F7 RID: 182007
		NumText,
		// Token: 0x0402C6F8 RID: 182008
		SpriteEmpty,
		// Token: 0x0402C6F9 RID: 182009
		SpriteRoleLight,
		// Token: 0x0402C6FA RID: 182010
		SpriteNumLight
	}
}
