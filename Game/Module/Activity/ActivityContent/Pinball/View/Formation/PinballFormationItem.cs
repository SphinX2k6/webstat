using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Weapon;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Formation
{
	// Token: 0x02006625 RID: 26149
	public class PinballFormationItem : UiPanelBase
	{
		// Token: 0x06041544 RID: 267588 RVA: 0x010C16AC File Offset: 0x010BF8AC
		protected unsafe override void OnRegisterComponent()
		{
			int num = 13;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(USpineSkeletonAnimationComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(USpineSkeletonAnimationComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUITexture));
			this.ComponentRegisterInfos = list;
			num2 = 2;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickRoleBtn));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(9, new Action(this.OnClickWeaponBtn));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06041545 RID: 267589 RVA: 0x010C18E8 File Offset: 0x010BFAE8
		protected override UniTask OnBeforeStartAsync()
		{
			PinballFormationItem.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<PinballFormationItem.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06041546 RID: 267590 RVA: 0x010C192B File Offset: 0x010BFB2B
		public void RefreshItem(int roleId)
		{
			this.RoleId = roleId;
			base.GetItem(11).SetUIActive(this.RoleId <= 0);
			this.RefreshRoleSpine();
			this.RefreshRoleInfo();
			this.RefreshWeaponItem();
		}

		// Token: 0x06041547 RID: 267591 RVA: 0x010C1960 File Offset: 0x010BFB60
		private void RefreshRoleSpine()
		{
			if (this.RoleId <= 0)
			{
				base.GetItem(1).SetUIActive(false);
				return;
			}
			PinballRoleConfig? pinballRoleConfigById = ConfigBase<PinballConfig>.Instance.GetPinballRoleConfigById(this.RoleId);
			if (pinballRoleConfigById == null)
			{
				return;
			}
			UniTask.WhenAll(new List<UniTask>
			{
				base.SetSpineAssetByPath(pinballRoleConfigById.Value.SpineAtlasPath, pinballRoleConfigById.Value.SpineSkeletonDataPath, base.GetSpine(3)),
				base.SetSpineAssetByPath(pinballRoleConfigById.Value.SpineAtlasPath, pinballRoleConfigById.Value.SpineSkeletonDataPath, base.GetSpine(2))
			}.ToArray()).ContinueWith(delegate()
			{
				base.GetItem(1).SetUIActive(true);
				base.GetSpine(2).SetAnimation(0, "Idle_Fight", true);
				base.GetSpine(3).SetAnimation(0, "Idle_Fight", true);
			}).Forget();
		}

		// Token: 0x06041548 RID: 267592 RVA: 0x010C1A28 File Offset: 0x010BFC28
		private void RefreshRoleInfo()
		{
			if (this.RoleId <= 0)
			{
				base.GetItem(4).SetUIActive(false);
				base.GetItem(5).SetUIActive(false);
				base.GetTexture(12).SetUIActive(false);
				return;
			}
			PinballRoleConfig? pinballRoleConfigById = ConfigBase<PinballConfig>.Instance.GetPinballRoleConfigById(this.RoleId);
			if (pinballRoleConfigById == null)
			{
				return;
			}
			this.IsTrail = pinballRoleConfigById.Value.IsTrail;
			base.GetItem(4).SetUIActive(this.IsTrail);
			base.GetItem(5).SetUIActive(true);
			base.GetTexture(12).SetUIActive(true);
			RoleConfig instance = ConfigBase<RoleConfig>.Instance;
			RoleInfo? roleInfo = (instance != null) ? instance.GetRoleConfig(pinballRoleConfigById.Value.RoleId) : null;
			if (roleInfo == null)
			{
				return;
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(6), roleInfo.Value.Name, Array.Empty<object>());
			PinballRoleBdIconItem pinballRoleBdIconItem = this.PinballRoleBdIconItem;
			if (pinballRoleBdIconItem != null)
			{
				pinballRoleBdIconItem.RefreshItem(pinballRoleConfigById.Value.Bd);
			}
			if (!this.IsTrail)
			{
				base.GetText(8).SetText("Lv." + ModelBase<PinballModel>.Instance.GetRoleLevel(this.RoleId).ToString(), true);
			}
			else
			{
				base.GetText(8).SetText("Lv." + pinballRoleConfigById.Value.InitLevelId.ToString(), true);
			}
			PinballClassConfig? pinballClassConfigById = ConfigBase<PinballConfig>.Instance.GetPinballClassConfigById(pinballRoleConfigById.Value.PinballClass(0));
			UTexture newTexture = Singleton<ResourceSystem>.Instance.Load<UTexture>(pinballClassConfigById.Value.HoverBigIcon, "js_undefined");
			UUITextureTransitionComponent uuitextureTransitionComponent = base.GetTexture(12).GetOwner().GetComponentByClass(UUITextureTransitionComponent.StaticClass()) as UUITextureTransitionComponent;
			uuitextureTransitionComponent.SetStateTexture(EUISelectableSelectionState.Highlighted, newTexture);
			uuitextureTransitionComponent.SetStateTexture(EUISelectableSelectionState.Pressed, newTexture);
			UTexture newTexture2 = Singleton<ResourceSystem>.Instance.Load<UTexture>(pinballClassConfigById.Value.BigIcon, "js_undefined");
			uuitextureTransitionComponent.SetStateTexture(EUISelectableSelectionState.Normal, newTexture2);
		}

		// Token: 0x06041549 RID: 267593 RVA: 0x010C1C44 File Offset: 0x010BFE44
		private void RefreshWeaponItem()
		{
			if (this.RoleId <= 0)
			{
				base.GetButton(9).RootUIComp.Get().SetUIActive(false);
				return;
			}
			if (this.IsTrail)
			{
				PinballRoleConfig? pinballRoleConfigById = ConfigBase<PinballConfig>.Instance.GetPinballRoleConfigById(this.RoleId);
				PinballWeaponConfig? pinballWeaponConfigById = ConfigBase<PinballConfig>.Instance.GetPinballWeaponConfigById(pinballRoleConfigById.Value.InitWeapon);
				base.GetButton(9).RootUIComp.Get().SetUIActive(true);
				base.SetTextureByPath(pinballWeaponConfigById.Value.Icon, base.GetTexture(10), null, null);
				return;
			}
			PinballWeaponData roleWeapon = ModelBase<PinballModel>.Instance.GetRoleWeapon(this.RoleId);
			if (roleWeapon == null || roleWeapon.Id <= 0)
			{
				base.GetButton(9).RootUIComp.Get().SetUIActive(false);
				return;
			}
			base.GetButton(9).RootUIComp.Get().SetUIActive(true);
			base.SetTextureByPath(roleWeapon.Icon, base.GetTexture(10), null, null);
		}

		// Token: 0x0604154A RID: 267594 RVA: 0x010C1D62 File Offset: 0x010BFF62
		private void OnClickRoleBtn()
		{
			Action<int> onClickRoleBtnCallBack = this.OnClickRoleBtnCallBack;
			if (onClickRoleBtnCallBack == null)
			{
				return;
			}
			onClickRoleBtnCallBack(this.RoleId);
		}

		// Token: 0x0604154B RID: 267595 RVA: 0x010C1D7C File Offset: 0x010BFF7C
		private void OnClickWeaponBtn()
		{
			PinballActivityData activityData = ModelBase<PinballModel>.Instance.ActivityData;
			if (activityData == null)
			{
				return;
			}
			if (this.IsTrail)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("PinballFilterTrailClickTips", Array.Empty<object>());
				return;
			}
			PinballWeaponEquipViewData param = new PinballWeaponEquipViewData
			{
				ActivityData = activityData,
				RoleData = activityData.GetRoleData(this.RoleId)
			};
			Singleton<UiManager>.Instance.OpenView(EUiViewName.PinballWeaponEquipView, param, null);
		}

		// Token: 0x040248BC RID: 149692
		private int RoleId;

		// Token: 0x040248BD RID: 149693
		private bool IsTrail;

		// Token: 0x040248BE RID: 149694
		[Nullable(2)]
		private PinballRoleBdIconItem PinballRoleBdIconItem;

		// Token: 0x040248BF RID: 149695
		[Nullable(2)]
		public Action<int> OnClickRoleBtnCallBack;

		// Token: 0x0200C64F RID: 50767
		private enum EComponent
		{
			// Token: 0x0403D0AA RID: 250026
			RoleBtn,
			// Token: 0x0403D0AB RID: 250027
			RoleItem,
			// Token: 0x0403D0AC RID: 250028
			ShadowSpine,
			// Token: 0x0403D0AD RID: 250029
			RoleSpine,
			// Token: 0x0403D0AE RID: 250030
			TrailRoleItem,
			// Token: 0x0403D0AF RID: 250031
			RoleInfoItem,
			// Token: 0x0403D0B0 RID: 250032
			RoleNameText,
			// Token: 0x0403D0B1 RID: 250033
			BdIconItem,
			// Token: 0x0403D0B2 RID: 250034
			RoleLevelText,
			// Token: 0x0403D0B3 RID: 250035
			WeaponBtn,
			// Token: 0x0403D0B4 RID: 250036
			WeaponTexture,
			// Token: 0x0403D0B5 RID: 250037
			EmptyItem,
			// Token: 0x0403D0B6 RID: 250038
			ClassTexture
		}
	}
}
