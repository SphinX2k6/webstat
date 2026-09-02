using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;

// Token: 0x020027A9 RID: 10153
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class MainRoleController : UiControllerBase<MainRoleController>
{
	// Token: 0x060140C4 RID: 82116 RVA: 0x00598B1A File Offset: 0x00596D1A
	protected override void OnAddOpenViewCheckFunction()
	{
		Singleton<UiManager>.Instance.AddOpenViewCheckFunction(EUiViewName.RoleGenderChangeView, new Func<EUiViewName, object, bool>(this.CanOpenView), "MainRoleController.CanOpenView");
	}

	// Token: 0x060140C5 RID: 82117 RVA: 0x00598B3C File Offset: 0x00596D3C
	protected override void OnRemoveOpenViewCheckFunction()
	{
		Singleton<UiManager>.Instance.RemoveOpenViewCheckFunction(EUiViewName.RoleGenderChangeView, new Func<EUiViewName, object, bool>(this.CanOpenView));
	}

	// Token: 0x060140C6 RID: 82118 RVA: 0x00598B5C File Offset: 0x00596D5C
	private bool CanOpenView(EUiViewName viewName, object param)
	{
		TsBaseCharacter baseCharacter = Global.BaseCharacter;
		bool? flag;
		if (baseCharacter == null)
		{
			flag = null;
		}
		else
		{
			BaseTagComponent component = baseCharacter.CharacterActorComponent.Entity.GetComponent<BaseTagComponent>();
			flag = ((component != null) ? new bool?(component.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.进入战斗"])) : null);
		}
		bool? flag2 = flag;
		bool flag3 = ControllerBase<GameModeController>.Instance.IsInInstance();
		if (flag2.GetValueOrDefault())
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByText(ConfigBase<TextConfig>.Instance.GetTextById("CanNotTransferInFight"));
			return false;
		}
		if (flag3)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByText(ConfigBase<TextConfig>.Instance.GetTextById("CanNotTransferInInstance"));
			return false;
		}
		return ModelBase<SubPackageDownLoadModel>.Instance.CheckGenderHaveSubPackage();
	}

	// Token: 0x060140C7 RID: 82119 RVA: 0x00598C14 File Offset: 0x00596E14
	public bool IsCanChangeRole(int roleId)
	{
		int[] canChangeRoleIdList = ModelBase<RoleModel>.Instance.GetCanChangeRoleIdList();
		int num = canChangeRoleIdList.Length;
		for (int i = 0; i < num; i++)
		{
			if (canChangeRoleIdList[i] == roleId)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x060140C8 RID: 82120 RVA: 0x00598C45 File Offset: 0x00596E45
	public bool IsMainRole(int roleId)
	{
		return ModelBase<RoleModel>.Instance.IsMainRole(roleId);
	}

	// Token: 0x060140C9 RID: 82121 RVA: 0x00598C58 File Offset: 0x00596E58
	public void SendRoleSexChangeRequest(int sex)
	{
		RoleSexChangeRequest roleSexChangeRequest = RoleSexChangeRequest.Create();
		roleSexChangeRequest.Sex = sex;
		Singleton<Net>.Instance.Call<RoleSexChangeResponse>(ERequestMessageId.RoleSexChangeRequest, roleSexChangeRequest, delegate(RoleSexChangeResponse response, Net.CallbackStatus _)
		{
			if (response == null)
			{
				return;
			}
			if (response.ErrorCode == ErrorCode.Success)
			{
				ModelBase<WorldLevelModel>.Instance.Sex = response.Sex;
				this.RequestNewRoleInfo();
				Singleton<EventSystem>.Instance.Emit(EEventName.OnRoleChangeEnd);
				return;
			}
			ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 25854, null, true, true);
		}, 0);
	}

	// Token: 0x060140CA RID: 82122 RVA: 0x00598C90 File Offset: 0x00596E90
	public void SendRoleElementChangeRequest(int elementType)
	{
		RoleElementChangeRequest roleElementChangeRequest = RoleElementChangeRequest.Create();
		roleElementChangeRequest.ElementType = elementType;
		Singleton<Net>.Instance.Call<RoleElementChangeResponse>(ERequestMessageId.RoleElementChangeRequest, roleElementChangeRequest, delegate(RoleElementChangeResponse response, Net.CallbackStatus _)
		{
			if (response == null)
			{
				return;
			}
			if (response.ErrorCode != ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 26044, null, true, true);
				return;
			}
			Singleton<EventSystem>.Instance.Emit(EEventName.OnRoleChangeEnd);
			this.RequestNewRoleInfo();
		}, 0);
	}

	// Token: 0x060140CB RID: 82123 RVA: 0x00598CC7 File Offset: 0x00596EC7
	private void RequestNewRoleInfo()
	{
		ControllerBase<EditFormationController>.Instance.RefreshMainRoleInfo();
		ControllerBase<EditBattleTeamController>.Instance.RefreshMainRoleInfo();
	}

	// Token: 0x060140CC RID: 82124 RVA: 0x00598CE0 File Offset: 0x00596EE0
	protected override void OnRegisterNetEvent()
	{
		Singleton<Net>.Instance.Register<RoleChangeNotify>(ENotifyMessageId.RoleChangeNotify, delegate(RoleChangeNotify notify, [Nullable(2)] Net.CallbackStatus _)
		{
			int sourceRoleId = notify.SourceRoleId;
			roleInfo roleInfo = notify.RoleInfo;
			ModelBase<PhantomBattleModel>.Instance.DeleteBattleData(sourceRoleId);
			ModelBase<RoleModel>.Instance.RoleChange(sourceRoleId, roleInfo);
		});
		Singleton<Net>.Instance.Register<RoleChangeUnlockNotify>(ENotifyMessageId.RoleChangeUnlockNotify, delegate(RoleChangeUnlockNotify notify, [Nullable(2)] Net.CallbackStatus _)
		{
			if (notify != null)
			{
				int[] array = new int[notify.UnlockRoleIds.Count];
				for (int i = 0; i < notify.UnlockRoleIds.Count; i++)
				{
					array[i] = notify.UnlockRoleIds[i];
				}
				ModelBase<RoleModel>.Instance.UpdateCanChangeRoleIdList(array);
				ModelBase<MainRoleModel>.Instance.UpdateCanChangeSexTime(notify.CanChangeSexTime);
			}
		});
	}

	// Token: 0x060140CD RID: 82125 RVA: 0x00598D4B File Offset: 0x00596F4B
	protected override void OnUnRegisterNetEvent()
	{
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.RoleChangeNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.RoleChangeUnlockNotify);
	}
}
