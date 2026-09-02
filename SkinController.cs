using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.ItemReward;
using CSharpScript.Game.Module.PayShop;
using CSharpScript.Game.Module.Skin;
using CSharpScript.Game.Ui;

// Token: 0x02002A3B RID: 10811
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class SkinController : UiControllerBase<SkinController>
{
	// Token: 0x06015A62 RID: 88674 RVA: 0x006027AC File Offset: 0x006009AC
	public void OpenObtainSkinView(RewardItemData[] skinRewardList, RewardItemData[] otherRewardList)
	{
		SkinObtainViewData skinObtainViewData = new SkinObtainViewData();
		skinObtainViewData.ObtainSkinData = skinRewardList;
		skinObtainViewData.OtherRewardData = otherRewardList;
		Singleton<UiManager>.Instance.OpenView(EUiViewName.SkinObtainView, skinObtainViewData, null);
	}

	// Token: 0x06015A63 RID: 88675 RVA: 0x006027E0 File Offset: 0x006009E0
	public void OpenObtainFlySkinView(RewardItemData[] skinRewardList, RewardItemData[] otherRewardList)
	{
		FlySkinObtainViewData flySkinObtainViewData = new FlySkinObtainViewData();
		flySkinObtainViewData.ObtainFlySkinData = skinRewardList.ToList<RewardItemData>();
		flySkinObtainViewData.OtherRewardData = otherRewardList.ToList<RewardItemData>();
		Singleton<UiManager>.Instance.OpenView(EUiViewName.FlySkinObtainView, flySkinObtainViewData, null);
	}

	// Token: 0x06015A64 RID: 88676 RVA: 0x0060281C File Offset: 0x00600A1C
	public void OpenBuyRoleSkinDetailView(PayShopGoods[] payShopData)
	{
		List<ShopSkinData> list = new List<ShopSkinData>();
		for (int i = 0; i < payShopData.Length; i++)
		{
			ShopSkinData item = ShopSkinData.Create(payShopData[i]);
			list.Add(item);
		}
		SkinBuyDetailViewData skinBuyDetailViewData = SkinBuyDetailViewData.Create(list);
		skinBuyDetailViewData.SetPreviewTitle("RoleSkinShopTitle_Text");
		Singleton<UiManager>.Instance.OpenView(EUiViewName.SkinBuyDetailView, skinBuyDetailViewData, null);
	}

	// Token: 0x06015A65 RID: 88677 RVA: 0x00602874 File Offset: 0x00600A74
	public void OpenBuyRoleSkinPreviewDetailViewByRoleSkinData(List<RoleSkinData> roleSkinData)
	{
		SkinBuyDetailViewData skinBuyDetailViewData = SkinBuyDetailViewData.CreateByRoleSkinData(roleSkinData);
		skinBuyDetailViewData.SetPreviewTitle("RoleSkinPreviewTitle_Text");
		Singleton<UiManager>.Instance.OpenView(EUiViewName.SkinBuyDetailView, skinBuyDetailViewData, null);
	}

	// Token: 0x06015A66 RID: 88678 RVA: 0x006028A4 File Offset: 0x00600AA4
	public void OpenBuyRoleSkinPreviewDetailViewByActivityRoleSkinData(RoleSkinData[] roleSkinData, bool isFemale)
	{
		SkinBuyDetailViewData skinBuyDetailViewData = SkinBuyDetailViewData.CreateByRoleSkinData(roleSkinData.ToList<RoleSkinData>());
		skinBuyDetailViewData.SetPreviewTitle("RoleSkinPreviewTitle_Text");
		skinBuyDetailViewData.SetIsActivityReward(true);
		if (isFemale)
		{
			skinBuyDetailViewData.SetIndex(1);
		}
		Singleton<UiManager>.Instance.OpenView(EUiViewName.SkinBuyDetailView, skinBuyDetailViewData, null);
	}

	// Token: 0x06015A67 RID: 88679 RVA: 0x006028EA File Offset: 0x00600AEA
	public void OpenSkinShowView(int skinId)
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.SkinShowView, skinId, null);
	}

	// Token: 0x06015A68 RID: 88680 RVA: 0x00602904 File Offset: 0x00600B04
	public void OpenEquipBuffItemShowView(int itemId, bool optionIsFemale = false)
	{
		int? curSelectMainRoleId = ModelBase<RoleModel>.Instance.GetCurSelectMainRoleId();
		bool flag = (curSelectMainRoleId ?? 0) == 0;
		if (flag)
		{
			return;
		}
		RoleInstance roleInstanceById = ModelBase<RoleModel>.Instance.GetRoleInstanceById(curSelectMainRoleId.Value);
		if (roleInstanceById == null)
		{
			return;
		}
		RoleSkinData roleSkinData = new RoleSkinData(roleInstanceById.GetRoleSkinId());
		EquipBuffItemDetailViewData equipBuffItemDetailViewData = new EquipBuffItemDetailViewData();
		equipBuffItemDetailViewData.RoleSkinData = roleSkinData;
		equipBuffItemDetailViewData.LoadFromItemId(itemId);
		ModelBase<BuffItemModel>.Instance.SetCurrentPreviewItemData(itemId, curSelectMainRoleId.Value);
		Singleton<UiManager>.Instance.OpenView(EUiViewName.EquipBuffItemDetailView, equipBuffItemDetailViewData, null);
	}

	// Token: 0x06015A69 RID: 88681 RVA: 0x00602994 File Offset: 0x00600B94
	public void SkipToSkinView(int roleId, EUiTabViewName tabViewName, bool needLoadRole, int selectRoleSkinId = -1, TOpenViewCallBack finishCallback = null, int? selectFlySkinId = null, EFlySkinTab? flySkinTab = null)
	{
		WeaponDataBase weaponDataByRoleDataId = ModelBase<WeaponModel>.Instance.GetWeaponDataByRoleDataId(roleId, true);
		if (!(weaponDataByRoleDataId is WeaponInstance))
		{
			return;
		}
		SkinViewData param = new SkinViewData
		{
			RoleId = roleId,
			WeaponId = (weaponDataByRoleDataId as WeaponInstance).GetIncId().Value,
			TabViewName = tabViewName,
			NeedLoadRole = needLoadRole,
			FlySkinId = selectFlySkinId,
			FlySkinTab = flySkinTab,
			SelectRoleSkinId = new int?(selectRoleSkinId)
		};
		Singleton<UiManager>.Instance.OpenView(EUiViewName.SkinRootView, param, finishCallback);
	}

	// Token: 0x06015A6A RID: 88682 RVA: 0x00602A1C File Offset: 0x00600C1C
	public void SkipToCalabashSkinView(int skinId)
	{
		int? curSelectMainRoleId = ModelBase<RoleModel>.Instance.GetCurSelectMainRoleId();
		bool flag = (curSelectMainRoleId ?? 0) == 0;
		if (flag)
		{
			return;
		}
		WeaponDataBase weaponDataByRoleDataId = ModelBase<WeaponModel>.Instance.GetWeaponDataByRoleDataId(curSelectMainRoleId.Value, true);
		if (!(weaponDataByRoleDataId is WeaponInstance))
		{
			return;
		}
		RoleSkinData roleSkinDataByRoleId = ModelBase<RoleSkinModel>.Instance.GetRoleSkinDataByRoleId(curSelectMainRoleId.Value);
		int value = (roleSkinDataByRoleId != null) ? roleSkinDataByRoleId.GetItemId() : -1;
		SkinViewData param = new SkinViewData
		{
			RoleId = curSelectMainRoleId.Value,
			WeaponId = (weaponDataByRoleDataId as WeaponInstance).GetIncId().Value,
			TabViewName = EUiTabViewName.CalabashSkinTabView,
			NeedLoadRole = true,
			CalabashSkinId = new int?(skinId),
			SelectRoleSkinId = new int?(value)
		};
		Singleton<UiManager>.Instance.OpenView(EUiViewName.SkinRootView, param, null);
	}

	// Token: 0x06015A6B RID: 88683 RVA: 0x00602AF5 File Offset: 0x00600CF5
	protected override void OnAddEvents()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnLoadingNetDataDone, new Action(this.OnLoadingNetDataDone));
	}

	// Token: 0x06015A6C RID: 88684 RVA: 0x00602B13 File Offset: 0x00600D13
	protected override void OnRemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnLoadingNetDataDone, new Action(this.OnLoadingNetDataDone));
	}

	// Token: 0x06015A6D RID: 88685 RVA: 0x00602B34 File Offset: 0x00600D34
	protected override void OnRegisterNetEvent()
	{
		Singleton<Net>.Instance.Register<RoleSkinAddNotify>(ENotifyMessageId.RoleSkinAddNotify, delegate(RoleSkinAddNotify response, [Nullable(2)] Net.CallbackStatus status)
		{
			ModelBase<RoleSkinModel>.Instance.UpdateUnlockRoleSkin(response.SkinIds.ToList<int>());
			ModelBase<RoleSkinModel>.Instance.UpdateWeaponSkinFirstWearRecord(response.SkinIds.ToList<int>());
			ModelBase<RoleSkinModel>.Instance.AddRoleSkinNewFlag(response.SkinIds.ToList<int>());
		});
		Singleton<Net>.Instance.Register<RoleSkinUpdateNotify>(ENotifyMessageId.RoleSkinUpdateNotify, delegate(RoleSkinUpdateNotify response, [Nullable(2)] Net.CallbackStatus status)
		{
			ModelBase<RoleSkinModel>.Instance.UpdateUnlockRoleSkinDataFull(response.SkinIds.ToList<int>());
			ModelBase<RoleSkinModel>.Instance.UpdateWeaponSkinFirstWearRecord(response.SkinIds.ToList<int>());
		});
	}

	// Token: 0x06015A6E RID: 88686 RVA: 0x00602B9F File Offset: 0x00600D9F
	protected override void OnUnRegisterNetEvent()
	{
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.RoleSkinAddNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.RoleSkinUpdateNotify);
	}

	// Token: 0x06015A6F RID: 88687 RVA: 0x00602BC1 File Offset: 0x00600DC1
	private void OnLoadingNetDataDone()
	{
		SkinController.RoleSkinDataRequest();
	}

	// Token: 0x06015A70 RID: 88688 RVA: 0x00602BC8 File Offset: 0x00600DC8
	private static void RoleSkinDataRequest()
	{
		RoleSkinRequest message = RoleSkinRequest.Create();
		Singleton<Net>.Instance.Call<RoleSkinResponse>(ERequestMessageId.RoleSkinRequest, message, delegate(RoleSkinResponse response, [Nullable(2)] Net.CallbackStatus status)
		{
			if (response == null)
			{
				return;
			}
			ModelBase<RoleSkinModel>.Instance.UpdateUnlockRoleSkin(response.SkinIds.ToList<int>());
		}, 0);
	}

	// Token: 0x06015A71 RID: 88689 RVA: 0x00602C0C File Offset: 0x00600E0C
	public bool CheckCanWearSkinAndShowTip()
	{
		BaseTagComponent component = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity.Entity.GetComponent<BaseTagComponent>();
		if (component.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.技能中"]) || component.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.进入战斗"]))
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Text_ForbiddenActionInFight_Text", Array.Empty<object>());
			return false;
		}
		if (component.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.动作状态.正常游泳"]))
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Text_ForbiddenActionInSwimming_Text", Array.Empty<object>());
			return false;
		}
		if (component.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.位置状态.攀爬"]))
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Text_ForbiddenActionInClimbing_Text", Array.Empty<object>());
			return false;
		}
		if (component.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.位置状态.空中"]))
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Text_ForbiddenActionMidair_Text", Array.Empty<object>());
			return false;
		}
		return true;
	}
}
