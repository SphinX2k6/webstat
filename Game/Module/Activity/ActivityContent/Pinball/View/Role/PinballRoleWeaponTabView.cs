using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Weapon;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Role
{
	// Token: 0x020065DF RID: 26079
	public class PinballRoleWeaponTabView : UiTabViewBase, IPinballRoleTabViewRoleChange, IPinballRoleTabViewRefresh
	{
		// Token: 0x06041271 RID: 266865 RVA: 0x010B6CCC File Offset: 0x010B4ECC
		protected unsafe override void OnRegisterComponent()
		{
			int num = 11;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIText));
			this.ComponentRegisterInfos = list;
			num2 = 2;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(4, new Action(this.OnClickWeaponButton));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(7, new Action(this.OnClickConfirmButton));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06041272 RID: 266866 RVA: 0x010B6EC4 File Offset: 0x010B50C4
		protected override UniTask OnBeforeStartAsync()
		{
			PinballRoleWeaponTabView.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<PinballRoleWeaponTabView.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06041273 RID: 266867 RVA: 0x010B6F08 File Offset: 0x010B5108
		protected override void OnBeforeShow()
		{
			this.ViewProxy = (IPinballRoleWeaponTabViewProxy)this.ExtraParams;
			this.RefreshView();
			UiBehaviorLevelSequence uiViewSequence = this.UiViewSequence;
			if (uiViewSequence == null)
			{
				return;
			}
			uiViewSequence.PlayOrReplaySequenceByName("Start", false, null);
		}

		// Token: 0x06041274 RID: 266868 RVA: 0x010B6F4C File Offset: 0x010B514C
		public void RefreshView()
		{
			IPinballRoleWeaponTabViewProxy viewProxy = this.ViewProxy;
			PinballRoleDataBase pinballRoleDataBase = (viewProxy != null) ? viewProxy.GetRoleData() : null;
			if (pinballRoleDataBase == null)
			{
				return;
			}
			PinballWeaponData weaponData = pinballRoleDataBase.GetWeaponData();
			bool flag = weaponData != null;
			base.GetItem(0).SetUIActive(flag);
			base.GetItem(8).SetUIActive(!flag);
			base.GetItem(9).SetUIActive(!flag);
			base.GetButton(7).RootUIComp.Get().SetUIActive(flag);
			if (flag)
			{
				PinballWeaponConfig? pinballWeaponConfigById = ConfigBase<PinballConfig>.Instance.GetPinballWeaponConfigById(weaponData.Id);
				PinballWeaponType? pinballWeaponTypeConfigById = ConfigBase<PinballConfig>.Instance.GetPinballWeaponTypeConfigById(pinballWeaponConfigById.Value.Type);
				base.SetTextureByPath(pinballWeaponTypeConfigById.Value.Icon2, base.GetTexture(1), null, null);
				base.SetTextureByPath(pinballWeaponConfigById.Value.Icon, base.GetTexture(5), null, null);
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), pinballWeaponConfigById.Value.Name, Array.Empty<object>());
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), pinballWeaponTypeConfigById.Value.Name, Array.Empty<object>());
				PinballWeaponAttrView attrView = this.AttrView;
				if (attrView != null)
				{
					attrView.Refresh(weaponData);
				}
			}
			else
			{
				PinballLevelConfig? pinballLevelConfigByRoleId = ConfigBase<PinballConfig>.Instance.GetPinballLevelConfigByRoleId(pinballRoleDataBase.GetId());
				if (pinballLevelConfigByRoleId == null)
				{
					return;
				}
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(10), "Pinball_Character_lockedinfo", new <>z__ReadOnlySingleElementList<object>(ConfigMultiTextLang.GetLocalTextNew(pinballLevelConfigByRoleId.Value.Name, null)));
			}
			ButtonItem confirmButtonItem = this.ConfirmButtonItem;
			if (confirmButtonItem == null)
			{
				return;
			}
			confirmButtonItem.SetRedDotVisible(ModelBase<PinballModel>.Instance.GetWeaponRedDot(this.ViewProxy.GetActivityData().Id, this.ViewProxy.GetRoleData().GetId()));
		}

		// Token: 0x06041275 RID: 266869 RVA: 0x010B7130 File Offset: 0x010B5330
		public void RefreshByRoleChange()
		{
			this.RefreshView();
		}

		// Token: 0x06041276 RID: 266870 RVA: 0x010B7138 File Offset: 0x010B5338
		private void OnClickWeaponButton()
		{
			this.OpenWeaponEquipView();
		}

		// Token: 0x06041277 RID: 266871 RVA: 0x010B7140 File Offset: 0x010B5340
		private void OnClickConfirmButton()
		{
			this.OpenWeaponEquipView();
		}

		// Token: 0x06041278 RID: 266872 RVA: 0x010B7148 File Offset: 0x010B5348
		public void OpenWeaponEquipView()
		{
			IPinballRoleWeaponTabViewProxy viewProxy = this.ViewProxy;
			PinballRoleDataBase pinballRoleDataBase = (viewProxy != null) ? viewProxy.GetRoleData() : null;
			IPinballRoleWeaponTabViewProxy viewProxy2 = this.ViewProxy;
			PinballActivityData pinballActivityData = (viewProxy2 != null) ? viewProxy2.GetActivityData() : null;
			if (pinballRoleDataBase == null || pinballActivityData == null)
			{
				return;
			}
			PinballWeaponEquipViewData param = new PinballWeaponEquipViewData
			{
				ActivityData = pinballActivityData,
				RoleData = pinballRoleDataBase
			};
			Singleton<UiManager>.Instance.OpenView(EUiViewName.PinballWeaponEquipView, param, null);
		}

		// Token: 0x040247C9 RID: 149449
		[Nullable(2)]
		protected IPinballRoleWeaponTabViewProxy ViewProxy;

		// Token: 0x040247CA RID: 149450
		[Nullable(2)]
		protected PinballWeaponAttrView AttrView;

		// Token: 0x040247CB RID: 149451
		[Nullable(2)]
		protected ButtonItem ConfirmButtonItem;

		// Token: 0x0200C5E7 RID: 50663
		private enum EComponent
		{
			// Token: 0x0403CE98 RID: 249496
			ActiveRootItem,
			// Token: 0x0403CE99 RID: 249497
			TypeIconTexture,
			// Token: 0x0403CE9A RID: 249498
			WeaponNameText,
			// Token: 0x0403CE9B RID: 249499
			WeaponTypeText,
			// Token: 0x0403CE9C RID: 249500
			WeaponButton,
			// Token: 0x0403CE9D RID: 249501
			WeaponIconTexture,
			// Token: 0x0403CE9E RID: 249502
			WeaponAttrRootItem,
			// Token: 0x0403CE9F RID: 249503
			ConfirmButton,
			// Token: 0x0403CEA0 RID: 249504
			LockItem,
			// Token: 0x0403CEA1 RID: 249505
			LockConditionItem,
			// Token: 0x0403CEA2 RID: 249506
			LockText
		}
	}
}
