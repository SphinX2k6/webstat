using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.Skin.Tab.Weapon
{
	// Token: 0x02004F63 RID: 20323
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class WeaponSkinController : UiControllerBase<WeaponSkinController>
	{
		// Token: 0x06034693 RID: 214675 RVA: 0x00D1CCDF File Offset: 0x00D1AEDF
		protected override void OnAddEvents()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.OnLoadingNetDataDone, new Action(this.OnDataDone));
		}

		// Token: 0x06034694 RID: 214676 RVA: 0x00D1CCFD File Offset: 0x00D1AEFD
		protected override void OnRemoveEvents()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnLoadingNetDataDone, new Action(this.OnDataDone));
		}

		// Token: 0x06034695 RID: 214677 RVA: 0x00D1CD1B File Offset: 0x00D1AF1B
		private void OnDataDone()
		{
			this.EquipSkinDataRequest();
		}

		// Token: 0x06034696 RID: 214678 RVA: 0x00D1CD24 File Offset: 0x00D1AF24
		private void EquipSkinDataRequest()
		{
			LoadEquipInfoRequest message = LoadEquipInfoRequest.Create();
			Singleton<Net>.Instance.Call<LoadEquipInfoResponse>(ERequestMessageId.LoadEquipInfoRequest, message, delegate(LoadEquipInfoResponse response, [Nullable(2)] Net.CallbackStatus _)
			{
				if (response == null)
				{
					return;
				}
				ModelBase<WeaponSkinModel>.Instance.NotifyWeaponSkinData(response.EquipList);
			}, 0);
		}

		// Token: 0x06034697 RID: 214679 RVA: 0x00D1CD68 File Offset: 0x00D1AF68
		protected override void OnRegisterNetEvent()
		{
			Singleton<Net>.Instance.Register<WeaponSkinAddNotify>(ENotifyMessageId.WeaponSkinAddNotify, delegate(WeaponSkinAddNotify notify, [Nullable(2)] Net.CallbackStatus status)
			{
				if (notify != null)
				{
					if (notify.IsLogin)
					{
						ModelBase<WeaponSkinModel>.Instance.NotifyAllUnlockSkinData(notify.SkinIds);
						return;
					}
					ModelBase<WeaponSkinModel>.Instance.SetUnlockSkinData(notify.SkinIds);
				}
			});
			Singleton<Net>.Instance.Register<WeaponSkinUnLoadNotify>(ENotifyMessageId.WeaponSkinUnLoadNotify, delegate(WeaponSkinUnLoadNotify notify, [Nullable(2)] Net.CallbackStatus status)
			{
				if (notify != null)
				{
					ModelBase<WeaponSkinModel>.Instance.DeleteWeaponSkinData(notify.RoleId);
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.WeaponSkin;
					ELogAuthor author = ELogAuthor.XXJ;
					string message = "武器皮肤卸载成功";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("roleId", notify.RoleId);
					instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				}
			});
			Singleton<Net>.Instance.Register<EntityEquipSkinChangeNotify>(ENotifyMessageId.EntityEquipSkinChangeNotify, delegate(EntityEquipSkinChangeNotify notify, [Nullable(2)] Net.CallbackStatus status)
			{
				int num = (int)Singleton<MathUtils>.Instance.LongToNumber(notify.EntityId);
				CharacterWeaponComponent component = ModelBase<CreatureModel>.Instance.GetEntity((long)num).Entity.GetComponent<CharacterWeaponComponent>();
				if (component == null)
				{
					return;
				}
				component.OnEntityEquipSkinChangeNotify(notify);
			});
			Singleton<Net>.Instance.Register<EntityFlyEquipChangeNotify>(ENotifyMessageId.EntityFlyEquipChangeNotify, delegate(EntityFlyEquipChangeNotify notify, [Nullable(2)] Net.CallbackStatus status)
			{
				foreach (EntityFlySkin entityFlySkin in notify.SkinChanges)
				{
					int num = (int)Singleton<MathUtils>.Instance.LongToNumber(entityFlySkin.EntityId);
					CharacterWeaponComponent component = ModelBase<CreatureModel>.Instance.GetEntity((long)num).Entity.GetComponent<CharacterWeaponComponent>();
					if (component == null)
					{
						break;
					}
					component.OnEntitySoarWingOrParaglidingSkinChangeNotify(entityFlySkin);
				}
			});
			Singleton<Net>.Instance.Register<WeaponSkinUpdateNotify>(ENotifyMessageId.WeaponSkinUpdateNotify, new Action<WeaponSkinUpdateNotify, Net.CallbackStatus>(this.OnWeaponSkinUpdateNotify));
		}

		// Token: 0x06034698 RID: 214680 RVA: 0x00D1CE50 File Offset: 0x00D1B050
		protected override void OnUnRegisterNetEvent()
		{
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.WeaponSkinAddNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.WeaponSkinUnLoadNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.EntityEquipSkinChangeNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.EntityFlyEquipChangeNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.WeaponSkinUpdateNotify);
		}

		// Token: 0x06034699 RID: 214681 RVA: 0x00D1CEB0 File Offset: 0x00D1B0B0
		private unsafe void SendEquipSkinTakeOnRequest(int roleId, int skinId)
		{
			EquipSkinTakeOnRequest equipSkinTakeOnRequest = EquipSkinTakeOnRequest.Create();
			equipSkinTakeOnRequest.Data = RoleSkinEquipData.Create();
			equipSkinTakeOnRequest.Data.RoleID = roleId;
			equipSkinTakeOnRequest.Data.SkinItemId = skinId;
			Singleton<Net>.Instance.Call<EquipSkinTakeOnResponse>(ERequestMessageId.EquipSkinTakeOnRequest, equipSkinTakeOnRequest, delegate(EquipSkinTakeOnResponse response, [Nullable(2)] Net.CallbackStatus _)
			{
				if (response == null)
				{
					return;
				}
				if (response.ErrorCode == ErrorCode.Success)
				{
					ModelBase<WeaponSkinModel>.Instance.EquipWeaponSkinData(response.DataList);
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.WeaponSkin;
					ELogAuthor author = ELogAuthor.XXJ;
					string message = "武器皮肤装备成功";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("roleId", roleId);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("skinId", skinId);
					instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
					return;
				}
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 21170, null, true, true);
			}, 0);
		}

		// Token: 0x0603469A RID: 214682 RVA: 0x00D1CF24 File Offset: 0x00D1B124
		private void SendEquipSkinUnLoadRequest(int roleId)
		{
			if (roleId <= 0)
			{
				return;
			}
			EquipSkinUnLoadRequest equipSkinUnLoadRequest = EquipSkinUnLoadRequest.Create();
			equipSkinUnLoadRequest.RoleID = roleId;
			Singleton<Net>.Instance.Call<EquipSkinUnLoadResponse>(ERequestMessageId.EquipSkinUnLoadRequest, equipSkinUnLoadRequest, delegate(EquipSkinUnLoadResponse response, [Nullable(2)] Net.CallbackStatus _)
			{
				if (response == null)
				{
					return;
				}
				if (response.ErrorCode != ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 29003, null, true, true);
				}
			}, 0);
		}

		// Token: 0x0603469B RID: 214683 RVA: 0x00D1CF73 File Offset: 0x00D1B173
		public void SendEquipSkinRequest(int roleId, int skinId)
		{
			if (roleId <= 0)
			{
				return;
			}
			if (skinId == -1)
			{
				this.SendEquipSkinUnLoadRequest(roleId);
				return;
			}
			this.SendEquipSkinTakeOnRequest(roleId, skinId);
		}

		// Token: 0x0603469C RID: 214684 RVA: 0x00D1CF8E File Offset: 0x00D1B18E
		private void OnWeaponSkinUpdateNotify(WeaponSkinUpdateNotify notify, [Nullable(2)] Net.CallbackStatus status)
		{
			ModelBase<WeaponSkinModel>.Instance.RefreshUnlockSkinData(notify.SkinIds);
		}

		// Token: 0x0603469D RID: 214685 RVA: 0x00D1CFA0 File Offset: 0x00D1B1A0
		public void OpenWeaponSkinShowView(List<int> skinIdList)
		{
			WeaponSkinShowViewData weaponSkinShowViewData = new WeaponSkinShowViewData();
			weaponSkinShowViewData.SkinIdList = skinIdList;
			Singleton<UiManager>.Instance.OpenView(EUiViewName.WeaponSkinShowView, weaponSkinShowViewData, null);
		}
	}
}
