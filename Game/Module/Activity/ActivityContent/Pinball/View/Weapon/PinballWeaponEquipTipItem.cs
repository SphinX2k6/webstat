using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Weapon
{
	// Token: 0x020065A4 RID: 26020
	[NullableContext(1)]
	[Nullable(0)]
	public class PinballWeaponEquipTipItem : UiPanelBase
	{
		// Token: 0x06041023 RID: 266275 RVA: 0x010AE264 File Offset: 0x010AC464
		protected unsafe override void OnRegisterComponent()
		{
			int num = 8;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06041024 RID: 266276 RVA: 0x010AE394 File Offset: 0x010AC594
		protected override UniTask OnBeforeStartAsync()
		{
			PinballWeaponEquipTipItem.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<PinballWeaponEquipTipItem.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06041025 RID: 266277 RVA: 0x010AE3D7 File Offset: 0x010AC5D7
		public void SetLockToggleShowState(bool bShow)
		{
			PinballWeaponTipsTopView weaponTopItem = this.WeaponTopItem;
			if (weaponTopItem == null)
			{
				return;
			}
			weaponTopItem.SetLockToggleShowState(bShow);
		}

		// Token: 0x06041026 RID: 266278 RVA: 0x010AE3EA File Offset: 0x010AC5EA
		public void Refresh(IPinballWeaponEquipTipItemData data)
		{
			this.Data = data;
			this.RefreshUi();
		}

		// Token: 0x06041027 RID: 266279 RVA: 0x010AE3FC File Offset: 0x010AC5FC
		public void RefreshUi()
		{
			if (this.Data == null)
			{
				return;
			}
			PinballWeaponData weaponData = this.Data.WeaponData;
			PinballWeaponTipsTopView weaponTopItem = this.WeaponTopItem;
			if (weaponTopItem != null)
			{
				weaponTopItem.Refresh(weaponData);
			}
			PinballWeaponAttrView weaponAttrItem = this.WeaponAttrItem;
			if (weaponAttrItem != null)
			{
				weaponAttrItem.Refresh(weaponData);
			}
			this.RefreshRoleItem();
			this.RefreshStateItem();
		}

		// Token: 0x06041028 RID: 266280 RVA: 0x010AE44E File Offset: 0x010AC64E
		public void RefreshLockToggleShowState()
		{
			PinballWeaponTipsTopView weaponTopItem = this.WeaponTopItem;
			if (weaponTopItem == null)
			{
				return;
			}
			weaponTopItem.RefreshLockToggleShowState();
		}

		// Token: 0x06041029 RID: 266281 RVA: 0x010AE460 File Offset: 0x010AC660
		public void RefreshRoleItem()
		{
			if (this.Data == null)
			{
				base.GetItem(4).SetUIActive(false);
				return;
			}
			int roleId = this.Data.WeaponData.RoleId;
			if (roleId <= 0)
			{
				base.GetItem(4).SetUIActive(false);
				return;
			}
			PinballRoleConfig? pinballRoleConfigById = ConfigBase<PinballConfig>.Instance.GetPinballRoleConfigById(roleId);
			if (pinballRoleConfigById == null)
			{
				base.GetItem(4).SetUIActive(false);
				return;
			}
			base.GetItem(4).SetUIActive(true);
			base.TrySetTextureByPath(pinballRoleConfigById.Value.SmallIcon, base.GetTexture(5), null, null);
			string localTextNew = ConfigMultiTextLang.GetLocalTextNew(ModelBase<PinballModel>.Instance.GetRoleNameByPinballRoleConfig(pinballRoleConfigById.Value), null);
			Singleton<LguiUtil>.Instance.TrySetLocalTextNew(base.GetText(6), "Pinball_Weapon_ArmedInfo2", new <>z__ReadOnlySingleElementList<object>(localTextNew));
		}

		// Token: 0x0604102A RID: 266282 RVA: 0x010AE534 File Offset: 0x010AC734
		public void RefreshStateItem()
		{
			if (this.Data == null)
			{
				return;
			}
			EPinballWeaponEquipState state = this.Data.State;
			ButtonItem equipButtonItem = this.EquipButtonItem;
			if (equipButtonItem != null)
			{
				equipButtonItem.SetUiActive(this.Data.ShowButton);
			}
			if (this.Data.ShowButton)
			{
				string textId;
				switch (state)
				{
				case EPinballWeaponEquipState.CanEquip:
					textId = "Pinball_Weapon_SelectInfo05";
					break;
				case EPinballWeaponEquipState.IsEquipped:
					textId = "Pinball_Weapon_ArmedInfo1";
					break;
				case EPinballWeaponEquipState.CanNotEquip:
					textId = "Pinball_Weapon_SelectInfo06";
					break;
				default:
					textId = "";
					break;
				}
				ButtonItem equipButtonItem2 = this.EquipButtonItem;
				if (equipButtonItem2 != null)
				{
					equipButtonItem2.SetLocalTextNew(textId, Array.Empty<object>());
				}
				ButtonItem equipButtonItem3 = this.EquipButtonItem;
				if (equipButtonItem3 == null)
				{
					return;
				}
				equipButtonItem3.SetEnableClick(state == EPinballWeaponEquipState.CanEquip);
			}
		}

		// Token: 0x0604102B RID: 266283 RVA: 0x010AE5E2 File Offset: 0x010AC7E2
		private void OnClickEquipButton()
		{
			if (this.Data == null)
			{
				return;
			}
			Action confirmDelegate = this.Data.ConfirmDelegate;
			if (confirmDelegate == null)
			{
				return;
			}
			confirmDelegate();
		}

		// Token: 0x0402472F RID: 149295
		private IPinballWeaponEquipTipItemData Data;

		// Token: 0x04024730 RID: 149296
		private PinballWeaponTipsTopView WeaponTopItem;

		// Token: 0x04024731 RID: 149297
		private PinballWeaponAttrView WeaponAttrItem;

		// Token: 0x04024732 RID: 149298
		private ButtonItem EquipButtonItem;

		// Token: 0x0200C59D RID: 50589
		[NullableContext(0)]
		private enum EComponent
		{
			// Token: 0x0403CD1C RID: 249116
			WeaponTopItem,
			// Token: 0x0403CD1D RID: 249117
			WeaponAttrRootItem,
			// Token: 0x0403CD1E RID: 249118
			CurEquipItem,
			// Token: 0x0403CD1F RID: 249119
			EquipButtonItem,
			// Token: 0x0403CD20 RID: 249120
			RoleItem,
			// Token: 0x0403CD21 RID: 249121
			RoleTexture,
			// Token: 0x0403CD22 RID: 249122
			RoleNameText,
			// Token: 0x0403CD23 RID: 249123
			DebugIdText
		}
	}
}
