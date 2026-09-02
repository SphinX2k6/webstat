using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.HonamiStory;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001F5B RID: 8027
[NullableContext(1)]
[Nullable(0)]
public class HonamiStoryWeaponSelectView : UiViewBase
{
	// Token: 0x0600F041 RID: 61505 RVA: 0x0041A4CD File Offset: 0x004186CD
	public HonamiStoryWeaponSelectView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600F042 RID: 61506 RVA: 0x0041A4E4 File Offset: 0x004186E4
	protected unsafe override void OnRegisterComponent()
	{
		int num = 21;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIVerticalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIMultiTemplateLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIVerticalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(17, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(18, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(19, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(20, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600F043 RID: 61507 RVA: 0x0041A7CD File Offset: 0x004189CD
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<bool>(EEventName.OnHonamiStorySkillDescModeChange, new Action<bool>(this.OnSkillDescModeChange));
	}

	// Token: 0x0600F044 RID: 61508 RVA: 0x0041A7EB File Offset: 0x004189EB
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove<bool>(EEventName.OnHonamiStorySkillDescModeChange, new Action<bool>(this.OnSkillDescModeChange));
	}

	// Token: 0x0600F045 RID: 61509 RVA: 0x0041A80C File Offset: 0x00418A0C
	protected override UniTask OnBeforeStartAsync()
	{
		HonamiStoryWeaponSelectView.<OnBeforeStartAsync>d__15 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<HonamiStoryWeaponSelectView.<OnBeforeStartAsync>d__15>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600F046 RID: 61510 RVA: 0x0041A850 File Offset: 0x00418A50
	protected override void OnStart()
	{
		TermExplanationRegistryParam param = new TermExplanationRegistryParam
		{
			UiText = base.GetText(8),
			ViewType = ETermExplanationViewType.Center,
			ReportType = ETermExplanationReportType.HonamiStory
		};
		ControllerBase<TermExplanationController>.Instance.RegisterTextHyperlinkByParam(param);
	}

	// Token: 0x0600F047 RID: 61511 RVA: 0x0041A88B File Offset: 0x00418A8B
	protected override void OnBeforeShow()
	{
		UUIItem item = base.GetItem(19);
		if (item != null)
		{
			item.SetUIActive(false);
		}
		this.UpdateDetailView();
	}

	// Token: 0x0600F048 RID: 61512 RVA: 0x0041A8A8 File Offset: 0x00418AA8
	protected override void OnBeforeHide()
	{
		HashSet<int> hashSet = LocalStorage.GetPlayer<HashSet<int>>(ELocalStoragePlayerKey.HonamiStoryWeaponUnlockSet, null) ?? new HashSet<int>();
		hashSet.Clear();
		LocalStorage.SetPlayer<HashSet<int>>(ELocalStoragePlayerKey.HonamiStoryWeaponUnlockSet, hashSet);
		Singleton<EventSystem>.Instance.Emit(EEventName.OnHonamiStoryBackpackClickWeapon);
	}

	// Token: 0x0600F049 RID: 61513 RVA: 0x0041A8EC File Offset: 0x00418AEC
	private void UpdateDetailView()
	{
		if (this.CurSelectWeaponToggleItem == null)
		{
			return;
		}
		bool flag = HonamiStoryUtil.CheckInHonamiStoryDungeon();
		bool flag2 = ModelBase<FunctionModel>.Instance.IsOpen(10123);
		HonamiStoryWeaponData weaponData = ModelBase<HonamiStoryModel>.Instance.GetWeaponData(this.CurSelectWeaponToggleItem.WeaponId);
		if (weaponData == null)
		{
			return;
		}
		bool isUnlock = weaponData.IsUnlock;
		UUIItem item = base.GetItem(18);
		if (item != null)
		{
			item.SetUIActive(isUnlock);
		}
		UUIItem item2 = base.GetItem(17);
		if (item2 != null)
		{
			item2.SetUIActive(isUnlock);
		}
		UUIItem item3 = base.GetItem(3);
		if (item3 != null)
		{
			item3.SetUIActive(isUnlock && !flag && flag2);
		}
		this.PanelLock.SetActive(!isUnlock);
		HonamiStoryWeapon value = weaponData.Config.Value;
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(6), value.Name, Array.Empty<object>());
		bool skillDescMode = ModelBase<HonamiStoryModel>.Instance.GetSkillDescMode();
		string textStringId = skillDescMode ? value.AttributesDescriptionSimple : value.AttributesDescription;
		string[] args = skillDescMode ? value.AttributesDescriptionSimpleArgs() : value.AttributesDescriptionArgs();
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(8), textStringId, args);
		UUIText text = base.GetText(16);
		if (text != null)
		{
			text.ShowTextNew(value.GetWayDes);
		}
		if (isUnlock)
		{
			GenericLayout<HonamiStoryWeaponTagItem, int> tagLayout = this.TagLayout;
			if (tagLayout != null)
			{
				tagLayout.RefreshByData(value.PluginTags().ToList<int>(), null, false);
			}
			int[] array = value.SuitId();
			List<IHonamiStoryWeaponSuitData> list = new List<IHonamiStoryWeaponSuitData>();
			foreach (int suitId in array)
			{
				list.Add(new HonamiStoryWeaponSuitData
				{
					SuitId = suitId,
					EquipData = this.EquipData
				});
			}
			GenericLayout<HonamiStoryWeaponSuitInfoItem, IHonamiStoryWeaponSuitData> suitVerticalLayout = this.SuitVerticalLayout;
			if (suitVerticalLayout != null)
			{
				suitVerticalLayout.RefreshByData(list, null, false);
			}
		}
		else
		{
			this.PanelLock.SetTextByTextId(weaponData.Config.Value.LockDescription, Array.Empty<string>());
		}
		this.RefreshConfirmButton();
	}

	// Token: 0x0600F04A RID: 61514 RVA: 0x0041AAD4 File Offset: 0x00418CD4
	private void RefreshConfirmButton()
	{
		switch (ModelBase<HonamiStoryModel>.Instance.CheckSelectWeaponState(this.CurSelectWeaponToggleItem.WeaponId, this.EquipData))
		{
		case EHonamiStoryWeaponState.Remove:
			this.ConfirmButtonItem.SetLocalTextNew("HonamiStory_Remove", Array.Empty<object>());
			return;
		case EHonamiStoryWeaponState.Equip:
			this.ConfirmButtonItem.SetLocalTextNew("HonamiStory_Equip", Array.Empty<object>());
			return;
		case EHonamiStoryWeaponState.Change:
			this.ConfirmButtonItem.SetLocalTextNew("HonamiStory_Change", Array.Empty<object>());
			return;
		default:
			return;
		}
	}

	// Token: 0x0600F04B RID: 61515 RVA: 0x0041AB51 File Offset: 0x00418D51
	private void InitData()
	{
		this.EquipData = (HonamiStoryRoleEquipData)this.OpenParam;
	}

	// Token: 0x0600F04C RID: 61516 RVA: 0x0041AB64 File Offset: 0x00418D64
	private void InitComponents()
	{
		this.WeaponPanelVerticalLayout = new GenericLayout<HonamiStoryWeaponPanelItem, EHonamiStoryWeaponType>(base.GetVerticalLayout(1), new Func<HonamiStoryWeaponPanelItem>(this.CreateWeaponPanelItem), (AUIBaseActor)base.GetItem(2).GetOwner(), true, true);
		this.TagLayout = new GenericLayout<HonamiStoryWeaponTagItem, int>(base.GetMultiTemplateLayout(10), new Func<HonamiStoryWeaponTagItem>(this.CreateTagItem), null, false, true);
		this.SuitVerticalLayout = new GenericLayout<HonamiStoryWeaponSuitInfoItem, IHonamiStoryWeaponSuitData>(base.GetVerticalLayout(13), new Func<HonamiStoryWeaponSuitInfoItem>(this.CreateSuitItem), null, false, true);
		this.PopupCaption = new PopupCaptionItem(base.GetItem(4));
		this.PopupCaption.SetCloseCallBack(new Action(this.OnClickBack));
		this.PopupCaption.SetHelpBtnActive(true);
		this.PopupCaption.SetHelpCallBack(delegate
		{
			ControllerBase<HelpController>.Instance.OpenHelpById(436);
		});
		this.ConfirmButtonItem = new ButtonItem(base.GetItem(3));
		this.ConfirmButtonItem.SetFunction(new Action<int>(this.OnClickConfirm));
	}

	// Token: 0x0600F04D RID: 61517 RVA: 0x0041AC6E File Offset: 0x00418E6E
	private HonamiStoryWeaponPanelItem CreateWeaponPanelItem()
	{
		HonamiStoryWeaponPanelItem honamiStoryWeaponPanelItem = new HonamiStoryWeaponPanelItem();
		honamiStoryWeaponPanelItem.BindWeaponToggleClick(new Action<HonamiStoryWeaponToggleItem>(this.OnWeaponToggleClick));
		return honamiStoryWeaponPanelItem;
	}

	// Token: 0x0600F04E RID: 61518 RVA: 0x0041AC87 File Offset: 0x00418E87
	private HonamiStoryWeaponTagItem CreateTagItem()
	{
		return new HonamiStoryWeaponTagItem();
	}

	// Token: 0x0600F04F RID: 61519 RVA: 0x0041AC8E File Offset: 0x00418E8E
	private HonamiStoryWeaponSuitInfoItem CreateSuitItem()
	{
		return new HonamiStoryWeaponSuitInfoItem();
	}

	// Token: 0x0600F050 RID: 61520 RVA: 0x0041AC98 File Offset: 0x00418E98
	private void InitWeaponToggleList()
	{
		if (this.CurSelectWeaponToggleItem != null)
		{
			this.CurSelectWeaponToggleItem.OnDeselected();
			this.CurSelectWeaponToggleItem = null;
		}
		int weaponId = this.EquipData.GetWeaponId();
		List<HonamiStoryWeaponPanelItem> layoutItemList = this.WeaponPanelVerticalLayout.GetLayoutItemList();
		this.WeaponToggleList.Clear();
		foreach (HonamiStoryWeaponPanelItem honamiStoryWeaponPanelItem in layoutItemList)
		{
			foreach (HonamiStoryWeaponToggleItem honamiStoryWeaponToggleItem in honamiStoryWeaponPanelItem.WeaponToggleList)
			{
				this.WeaponToggleList.Add(honamiStoryWeaponToggleItem);
				if (honamiStoryWeaponToggleItem.WeaponId == weaponId)
				{
					this.CurSelectWeaponToggleItem = honamiStoryWeaponToggleItem;
				}
			}
		}
		if (this.CurSelectWeaponToggleItem == null && this.WeaponToggleList.Count > 0)
		{
			this.CurSelectWeaponToggleItem = this.WeaponToggleList[0];
		}
		HonamiStoryWeaponToggleItem curSelectWeaponToggleItem = this.CurSelectWeaponToggleItem;
		if (curSelectWeaponToggleItem != null)
		{
			curSelectWeaponToggleItem.OnSelected();
		}
		this.UpdateDetailView();
	}

	// Token: 0x0600F051 RID: 61521 RVA: 0x0041ADB0 File Offset: 0x00418FB0
	private void OnWeaponToggleClick(HonamiStoryWeaponToggleItem toggleItem)
	{
		if (this.CurSelectWeaponToggleItem == toggleItem)
		{
			return;
		}
		HonamiStoryWeaponToggleItem curSelectWeaponToggleItem = this.CurSelectWeaponToggleItem;
		if (curSelectWeaponToggleItem != null)
		{
			curSelectWeaponToggleItem.OnDeselected();
		}
		this.CurSelectWeaponToggleItem = toggleItem;
		this.CurSelectWeaponToggleItem.OnSelected();
		this.UpdateDetailView();
	}

	// Token: 0x0600F052 RID: 61522 RVA: 0x0041ADE8 File Offset: 0x00418FE8
	private void OnClickConfirm(int _)
	{
		if (this.CurSelectWeaponToggleItem == null || this.EquipData == null)
		{
			return;
		}
		EHonamiStoryWeaponState ehonamiStoryWeaponState = ModelBase<HonamiStoryModel>.Instance.CheckSelectWeaponState(this.CurSelectWeaponToggleItem.WeaponId, this.EquipData);
		int weaponId = 0;
		if (ehonamiStoryWeaponState != EHonamiStoryWeaponState.Remove)
		{
			if (ehonamiStoryWeaponState - EHonamiStoryWeaponState.Equip <= 1)
			{
				weaponId = this.CurSelectWeaponToggleItem.WeaponId;
			}
		}
		else
		{
			weaponId = 0;
		}
		HonamiStoryRoleEquipData honamiStoryRoleEquipData = ModelBase<HonamiStoryModel>.Instance.GetWeaponEquipState(weaponId) ?? this.CurSelectWeaponToggleItem.GetEquipData();
		if (honamiStoryRoleEquipData != null && honamiStoryRoleEquipData.GetRoleId() != 0 && this.EquipData.GetRoleId() != honamiStoryRoleEquipData.GetRoleId())
		{
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.HonamiStoryEquipWeaponConfirm);
			confirmBoxDataNew.FunctionMap.Add(2, delegate
			{
				this.DressRequest(weaponId, this.EquipData.GetPosition());
			});
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
			return;
		}
		this.DressRequest(weaponId, this.EquipData.GetPosition());
	}

	// Token: 0x0600F053 RID: 61523 RVA: 0x0041AEDE File Offset: 0x004190DE
	private void DressRequest(int weaponId, int position)
	{
		ControllerBase<HonamiStoryController>.Instance.SendHonamiStoryWeaponDressRequest(weaponId, position, delegate
		{
			this.UpdateDetailView();
			foreach (HonamiStoryWeaponToggleItem honamiStoryWeaponToggleItem in this.WeaponToggleList)
			{
				if (honamiStoryWeaponToggleItem != null)
				{
					honamiStoryWeaponToggleItem.RefreshItem();
					honamiStoryWeaponToggleItem.RefreshCurSelectLightSprite(this.EquipData);
				}
			}
		});
	}

	// Token: 0x0600F054 RID: 61524 RVA: 0x0041AEF8 File Offset: 0x004190F8
	private void OnClickBack()
	{
		base.CloseMe(null);
	}

	// Token: 0x0600F055 RID: 61525 RVA: 0x0041AF01 File Offset: 0x00419101
	private void OnSkillDescModeChange(bool _)
	{
		this.UpdateDetailView();
	}

	// Token: 0x0400737B RID: 29563
	public PopupCaptionItem PopupCaption;

	// Token: 0x0400737C RID: 29564
	[Nullable(2)]
	private HonamiStoryRoleEquipData EquipData;

	// Token: 0x0400737D RID: 29565
	[Nullable(2)]
	private HonamiStoryWeaponToggleItem CurSelectWeaponToggleItem;

	// Token: 0x0400737E RID: 29566
	private readonly List<HonamiStoryWeaponToggleItem> WeaponToggleList = new List<HonamiStoryWeaponToggleItem>();

	// Token: 0x0400737F RID: 29567
	private GenericLayout<HonamiStoryWeaponPanelItem, EHonamiStoryWeaponType> WeaponPanelVerticalLayout;

	// Token: 0x04007380 RID: 29568
	private GenericLayout<HonamiStoryWeaponTagItem, int> TagLayout;

	// Token: 0x04007381 RID: 29569
	private GenericLayout<HonamiStoryWeaponSuitInfoItem, IHonamiStoryWeaponSuitData> SuitVerticalLayout;

	// Token: 0x04007382 RID: 29570
	private ButtonItem ConfirmButtonItem;

	// Token: 0x04007383 RID: 29571
	private FunctionalPanelConditionLock PanelLock;

	// Token: 0x04007384 RID: 29572
	[Nullable(2)]
	private HonamiStorySkillDescToggle DescToggleItem;

	// Token: 0x020082E5 RID: 33509
	[NullableContext(0)]
	private enum EHonamiStoryWeaponSelectComponent
	{
		// Token: 0x0402C611 RID: 181777
		SkillModeToggle,
		// Token: 0x0402C612 RID: 181778
		WeaponPanelVerticalLayout,
		// Token: 0x0402C613 RID: 181779
		WeaponPanelItem,
		// Token: 0x0402C614 RID: 181780
		ConfirmButton,
		// Token: 0x0402C615 RID: 181781
		ItemCaption,
		// Token: 0x0402C616 RID: 181782
		DetailPanel,
		// Token: 0x0402C617 RID: 181783
		WeaponName,
		// Token: 0x0402C618 RID: 181784
		WeaponSkillTitle,
		// Token: 0x0402C619 RID: 181785
		WeaponSkillDesc,
		// Token: 0x0402C61A RID: 181786
		TagTitle,
		// Token: 0x0402C61B RID: 181787
		TagLayout,
		// Token: 0x0402C61C RID: 181788
		TagItem,
		// Token: 0x0402C61D RID: 181789
		SuitTitle,
		// Token: 0x0402C61E RID: 181790
		SuitVerticalLayout,
		// Token: 0x0402C61F RID: 181791
		SuitItem,
		// Token: 0x0402C620 RID: 181792
		GetTitleText,
		// Token: 0x0402C621 RID: 181793
		GetDescText,
		// Token: 0x0402C622 RID: 181794
		TagPanel,
		// Token: 0x0402C623 RID: 181795
		SuitPanel,
		// Token: 0x0402C624 RID: 181796
		GetPanel,
		// Token: 0x0402C625 RID: 181797
		LockPanel
	}
}
