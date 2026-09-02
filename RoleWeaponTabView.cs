using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using AkiClient.Game.Aki.Character.Role.Common.Data.Enum;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Module.Skin;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020028EA RID: 10474
[NullableContext(2)]
[Nullable(0)]
public class RoleWeaponTabView : UiTabViewBase
{
	// Token: 0x06014CD8 RID: 85208 RVA: 0x005C30E0 File Offset: 0x005C12E0
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(2, new Action(this.OnSkinClick))
		};
	}

	// Token: 0x06014CD9 RID: 85209 RVA: 0x005C318C File Offset: 0x005C138C
	private UniTask InitWeaponDetailTips()
	{
		RoleWeaponTabView.<InitWeaponDetailTips>d__6 <InitWeaponDetailTips>d__;
		<InitWeaponDetailTips>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitWeaponDetailTips>d__.<>4__this = this;
		<InitWeaponDetailTips>d__.<>1__state = -1;
		<InitWeaponDetailTips>d__.<>t__builder.Start<RoleWeaponTabView.<InitWeaponDetailTips>d__6>(ref <InitWeaponDetailTips>d__);
		return <InitWeaponDetailTips>d__.<>t__builder.Task;
	}

	// Token: 0x06014CDA RID: 85210 RVA: 0x005C31D0 File Offset: 0x005C13D0
	private UniTask InitEquipItem()
	{
		RoleWeaponTabView.<InitEquipItem>d__7 <InitEquipItem>d__;
		<InitEquipItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitEquipItem>d__.<>4__this = this;
		<InitEquipItem>d__.<>1__state = -1;
		<InitEquipItem>d__.<>t__builder.Start<RoleWeaponTabView.<InitEquipItem>d__7>(ref <InitEquipItem>d__);
		return <InitEquipItem>d__.<>t__builder.Task;
	}

	// Token: 0x06014CDB RID: 85211 RVA: 0x005C3214 File Offset: 0x005C1414
	private UniTask InitWarningItem()
	{
		RoleWeaponTabView.<InitWarningItem>d__8 <InitWarningItem>d__;
		<InitWarningItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitWarningItem>d__.<>4__this = this;
		<InitWarningItem>d__.<>1__state = -1;
		<InitWarningItem>d__.<>t__builder.Start<RoleWeaponTabView.<InitWarningItem>d__8>(ref <InitWarningItem>d__);
		return <InitWarningItem>d__.<>t__builder.Task;
	}

	// Token: 0x06014CDC RID: 85212 RVA: 0x005C3258 File Offset: 0x005C1458
	protected override UniTask OnBeforeStartAsync()
	{
		RoleWeaponTabView.<OnBeforeStartAsync>d__9 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<RoleWeaponTabView.<OnBeforeStartAsync>d__9>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06014CDD RID: 85213 RVA: 0x005C329B File Offset: 0x005C149B
	protected override void OnStart()
	{
		this.WeaponDetailTipsComponent.SetCanShowEquip(false);
		this.WeaponDetailTipsComponent.SetReplaceFunction(new TWeaponDetailsTipsFunctionWithNumber(this.ReplaceClick));
		this.WeaponDetailTipsComponent.SetCultureFunction(new TWeaponDetailsTipsFunctionWithNumber(this.CultureClick));
	}

	// Token: 0x06014CDE RID: 85214 RVA: 0x005C32D8 File Offset: 0x005C14D8
	protected override void AddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<int, bool>(EEventName.OnItemLock, new Action<int, bool>(this.ItemLockEvent));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.RoleSystemChangeRole, new Action<int>(this.UpdateWeaponEvent));
		Singleton<EventSystem>.Instance.Add(EEventName.ResetRoleFlag, new Action(this.ResetRoleFlag));
	}

	// Token: 0x06014CDF RID: 85215 RVA: 0x005C333C File Offset: 0x005C153C
	protected override void RemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnItemLock, new Action<int, bool>(this.ItemLockEvent));
		Singleton<EventSystem>.Instance.Remove(EEventName.RoleSystemChangeRole, new Action<int>(this.UpdateWeaponEvent));
		Singleton<EventSystem>.Instance.Remove(EEventName.ResetRoleFlag, new Action(this.ResetRoleFlag));
	}

	// Token: 0x06014CE0 RID: 85216 RVA: 0x005C339D File Offset: 0x005C159D
	private void ResetRoleFlag()
	{
		this.HasUpdateRole = false;
	}

	// Token: 0x06014CE1 RID: 85217 RVA: 0x005C33A6 File Offset: 0x005C15A6
	protected override void OnBeforeShow()
	{
		ModelBase<WeaponModel>.Instance.SetCurSelectViewName(EWeaponViewName.RoleWeaponTabView);
		if (this.HasUpdateRole)
		{
			this.PlayMontageStart(true);
			this.HasUpdateRole = false;
		}
		else
		{
			this.PlayMontageStart(false);
		}
		this.RefreshWeaponDetailTipsComponent();
	}

	// Token: 0x06014CE2 RID: 85218 RVA: 0x005C33D8 File Offset: 0x005C15D8
	protected override void OnBeforeDestroy()
	{
		if (this.WeaponDetailTipsComponent != null)
		{
			this.WeaponDetailTipsComponent.Destroy(null);
			this.WeaponDetailTipsComponent = null;
		}
	}

	// Token: 0x06014CE3 RID: 85219 RVA: 0x005C33F8 File Offset: 0x005C15F8
	private void ReplaceClick(int incId)
	{
		RoleViewViewModel roleViewViewModel = new RoleViewViewModel(this.RoleViewAgent.GetCurSelectRoleId(), false, this.RoleViewAgent.Source);
		roleViewViewModel.WeaponIncId = incId;
		ControllerBase<RoleController>.Instance.OpenRoleViewByViewModel(EUiViewName.WeaponReplaceView, roleViewViewModel);
	}

	// Token: 0x06014CE4 RID: 85220 RVA: 0x005C343C File Offset: 0x005C163C
	private void CultureClick(int incId)
	{
		WeaponInstance weaponDataByIncId = ModelBase<WeaponModel>.Instance.GetWeaponDataByIncId(incId);
		if (weaponDataByIncId == null)
		{
			return;
		}
		int skinIdByRoleId = ModelBase<WeaponSkinModel>.Instance.GetSkinIdByRoleId(weaponDataByIncId.GetRoleId());
		WeaponRootViewParam param = new WeaponRootViewParam
		{
			WeaponIncId = incId,
			WeaponSkinId = skinIdByRoleId,
			IsFromRoleRootView = true
		};
		ControllerBase<WeaponController>.Instance.RoleFadeIn(Singleton<UiSceneManager>.Instance.GetRoleSystemRoleActor(), "RoleFadeInCurve");
		Singleton<UiManager>.Instance.OpenView(EUiViewName.WeaponRootView, param, null);
	}

	// Token: 0x06014CE5 RID: 85221 RVA: 0x005C34AF File Offset: 0x005C16AF
	private void ItemLockEvent(int uniqueId, bool bLock)
	{
		this.WeaponDetailTipsComponent.UpdateWeaponLock(bLock);
	}

	// Token: 0x06014CE6 RID: 85222 RVA: 0x005C34BD File Offset: 0x005C16BD
	private void UpdateWeaponEvent(int i)
	{
		this.HasUpdateRole = true;
		this.PlayMontageStart(true);
		this.RefreshWeaponDetailTipsComponent();
	}

	// Token: 0x06014CE7 RID: 85223 RVA: 0x005C34D3 File Offset: 0x005C16D3
	protected void PlayMontageStart(bool reLoop = false)
	{
		ControllerBase<RoleController>.Instance.PlayRoleMontage(EPerformanceRoleState.Weapon, reLoop, false, false);
	}

	// Token: 0x06014CE8 RID: 85224 RVA: 0x005C34E4 File Offset: 0x005C16E4
	private void RefreshWeaponDetailTipsComponent()
	{
		RoleDataBase curSelectRoleData = this.RoleViewAgent.GetCurSelectRoleData();
		if (curSelectRoleData == null)
		{
			return;
		}
		WeaponDataBase weaponDataByRoleDataId = ModelBase<WeaponModel>.Instance.GetWeaponDataByRoleDataId(curSelectRoleData.GetDataId(), true);
		if (weaponDataByRoleDataId == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Role;
			ELogAuthor author = ELogAuthor.BB;
			string message = "RoleWeaponTabView获取不到武器数据";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("roleId", curSelectRoleData.GetDataId());
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		this.WeaponDetailTipsComponent.UpdateComponent(weaponDataByRoleDataId);
		bool flag = ModelBase<WeaponModel>.Instance.RedDotWeaponBreachCondition(curSelectRoleData.GetDataId());
		bool flag2 = ModelBase<WeaponModel>.Instance.RedDotWeaponResonanceConditionByRole(curSelectRoleData.GetDataId());
		this.WeaponDetailTipsComponent.UpdateWeaponBreachRedDot(flag || flag2);
		this.RefreshEquipItem();
		this.RefreshSkinBtn();
		this.RefreshRedDot();
		this.RefreshWarningItem();
	}

	// Token: 0x06014CE9 RID: 85225 RVA: 0x005C359C File Offset: 0x005C179C
	private void RefreshEquipItem()
	{
		if (!this.RoleViewAgent.GetRoleSystemUiParams().SwitchSkin)
		{
			CommonEquippedItem equipItem = this.EquipItem;
			if (equipItem == null)
			{
				return;
			}
			equipItem.SetIconRootItemState(false);
			return;
		}
		else
		{
			RoleDataBase curSelectRoleData = this.RoleViewAgent.GetCurSelectRoleData();
			if (curSelectRoleData == null)
			{
				return;
			}
			int skinIdByRoleId = ModelBase<WeaponSkinModel>.Instance.GetSkinIdByRoleId(curSelectRoleData.GetDataId());
			if (skinIdByRoleId == -1)
			{
				CommonEquippedItem equipItem2 = this.EquipItem;
				if (equipItem2 == null)
				{
					return;
				}
				equipItem2.SetIconRootItemState(false);
				return;
			}
			else
			{
				WeaponSkin weaponSkinConfig = ConfigBase<SkinConfig>.Instance.GetWeaponSkinConfig(skinIdByRoleId);
				CommonEquippedItem equipItem3 = this.EquipItem;
				if (equipItem3 != null)
				{
					equipItem3.SetEquipIcon(weaponSkinConfig.IconSmall);
				}
				this.EquipItem.SetEquipText("WeaponTipsRoleText", new object[]
				{
					new TableTextArgNew(weaponSkinConfig.Name, Array.Empty<object>())
				});
				CommonEquippedItem equipItem4 = this.EquipItem;
				if (equipItem4 == null)
				{
					return;
				}
				equipItem4.SetIconRootItemState(true);
				return;
			}
		}
	}

	// Token: 0x06014CEA RID: 85226 RVA: 0x005C3664 File Offset: 0x005C1864
	private void RefreshSkinBtn()
	{
		if (!this.RoleViewAgent.GetRoleSystemUiParams().SwitchSkin)
		{
			UUIButtonComponent button = base.GetButton(2);
			if (button == null)
			{
				return;
			}
			button.RootUIComp.Get().SetUIActive(false);
			return;
		}
		else
		{
			RoleDataBase curSelectRoleData = this.RoleViewAgent.GetCurSelectRoleData();
			if (curSelectRoleData == null || curSelectRoleData.IsTrialRole())
			{
				UUIButtonComponent button2 = base.GetButton(2);
				if (button2 == null)
				{
					return;
				}
				button2.RootUIComp.Get().SetUIActive(false);
				return;
			}
			else
			{
				UUIButtonComponent button3 = base.GetButton(2);
				if (button3 == null)
				{
					return;
				}
				button3.RootUIComp.Get().SetUIActive(true);
				return;
			}
		}
	}

	// Token: 0x06014CEB RID: 85227 RVA: 0x005C36FC File Offset: 0x005C18FC
	private void RefreshRedDot()
	{
		if (this.RoleViewAgent.GetRoleSystemUiParams().SwitchSkin)
		{
			RoleDataBase curSelectRoleData = this.RoleViewAgent.GetCurSelectRoleData();
			if (curSelectRoleData == null)
			{
				return;
			}
			WeaponDataBase weaponDataByRoleDataId = ModelBase<WeaponModel>.Instance.GetWeaponDataByRoleDataId(curSelectRoleData.GetDataId(), true);
			if (weaponDataByRoleDataId == null)
			{
				return;
			}
			int weaponType = weaponDataByRoleDataId.GetWeaponConfig().Value.WeaponType;
			bool uiactive = ModelBase<WeaponSkinModel>.Instance.HasWeaponSkinRedDot(weaponType);
			UUIItem item = base.GetItem(3);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(uiactive);
			return;
		}
		else
		{
			UUIItem item2 = base.GetItem(3);
			if (item2 == null)
			{
				return;
			}
			item2.SetUIActive(false);
			return;
		}
	}

	// Token: 0x06014CEC RID: 85228 RVA: 0x005C378C File Offset: 0x005C198C
	private void RefreshWarningItem()
	{
		if (this.RoleViewAgent.Source == ERoleViewSource.WheelTower)
		{
			int curSelectRoleId = this.RoleViewAgent.GetCurSelectRoleId();
			IConflictInfo conflictInfo = ModelBase<WheelTowerModel>.Instance.CheckConflict(curSelectRoleId);
			if (conflictInfo != null && conflictInfo.WeaponConflict)
			{
				CommonWarningItem warningItem = this.WarningItem;
				if (warningItem != null)
				{
					warningItem.SetUiActive(true);
				}
				int conflictWeaponRoleId = ModelBase<WheelTowerModel>.Instance.GetConflictWeaponRoleId(curSelectRoleId);
				RoleInfo? roleConfig = ConfigBase<RoleConfig>.Instance.GetRoleConfig(conflictWeaponRoleId);
				CommonWarningItem warningItem2 = this.WarningItem;
				if (warningItem2 != null)
				{
					warningItem2.SetWarningIcon(roleConfig.Value.Card);
				}
				string multiTextByKey = ConfigBase<TextConfig>.Instance.GetMultiTextByKey(roleConfig.Value.Name);
				CommonWarningItem warningItem3 = this.WarningItem;
				if (warningItem3 == null)
				{
					return;
				}
				warningItem3.SetLocalTextNew("WheelTower_Conflict_Warning_Tip", new object[]
				{
					multiTextByKey
				});
				return;
			}
		}
		CommonWarningItem warningItem4 = this.WarningItem;
		if (warningItem4 == null)
		{
			return;
		}
		warningItem4.SetUiActive(false);
	}

	// Token: 0x06014CED RID: 85229 RVA: 0x005C386C File Offset: 0x005C1A6C
	private void OnSkinClick()
	{
		int curSelectRoleId = this.RoleViewAgent.GetCurSelectRoleId();
		ControllerBase<SkinController>.Instance.SkipToSkinView(curSelectRoleId, EUiTabViewName.WeaponSkinTabView, false, -1, null, null, null);
	}

	// Token: 0x06014CEE RID: 85230 RVA: 0x005C38AA File Offset: 0x005C1AAA
	[NullableContext(1)]
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
	{
		return this.WeaponDetailTipsComponent.GetGuideUiItemAndUiItemForShowEx(configParams);
	}

	// Token: 0x0400A022 RID: 40994
	private RoleViewAgent RoleViewAgent;

	// Token: 0x0400A023 RID: 40995
	private WeaponDetailTipsComponent WeaponDetailTipsComponent;

	// Token: 0x0400A024 RID: 40996
	private CommonEquippedItem EquipItem;

	// Token: 0x0400A025 RID: 40997
	private CommonWarningItem WarningItem;

	// Token: 0x0400A026 RID: 40998
	private bool HasUpdateRole;

	// Token: 0x02008C3D RID: 35901
	[NullableContext(0)]
	private enum ERoleWeaponTabViewDefine
	{
		// Token: 0x0402F3CD RID: 193485
		WeaponDetailTipsItem,
		// Token: 0x0402F3CE RID: 193486
		EquipRootItem,
		// Token: 0x0402F3CF RID: 193487
		SkinBtn,
		// Token: 0x0402F3D0 RID: 193488
		SkinRedDot,
		// Token: 0x0402F3D1 RID: 193489
		ItemWarning
	}
}
