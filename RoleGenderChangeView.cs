using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Module.Skin;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020027AD RID: 10157
public class RoleGenderChangeView : UiViewBase
{
	// Token: 0x060140FD RID: 82173 RVA: 0x00599A69 File Offset: 0x00597C69
	[NullableContext(1)]
	public RoleGenderChangeView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x060140FE RID: 82174 RVA: 0x00599A74 File Offset: 0x00597C74
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUITexture)),
			new ValueTuple<int, Type>(1, typeof(UUITexture)),
			new ValueTuple<int, Type>(2, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(3, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(4, typeof(UUIText)),
			new ValueTuple<int, Type>(5, typeof(UUIText)),
			new ValueTuple<int, Type>(6, typeof(UUIText)),
			new ValueTuple<int, Type>(7, typeof(UUIInteractionGroup))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(2, new Action(this.OnClickCancel)),
			new ValueTuple<int, Delegate>(3, new Action(this.OnClickConfirm))
		};
	}

	// Token: 0x060140FF RID: 82175 RVA: 0x00599B78 File Offset: 0x00597D78
	protected override void OnStart()
	{
		int? curSelectMainRoleId = ModelBase<RoleModel>.Instance.GetCurSelectMainRoleId();
		int? num = curSelectMainRoleId;
		int num2 = 0;
		if (num.GetValueOrDefault() == num2 & num != null)
		{
			return;
		}
		RoleInfo? roleConfig = ConfigBase<RoleConfig>.Instance.GetRoleConfig(curSelectMainRoleId.Value);
		if (roleConfig == null)
		{
			return;
		}
		int sex = ModelBase<WorldLevelModel>.Instance.Sex;
		int elementId = roleConfig.Value.ElementId;
		LoginDefine.ELoginSex gender = (sex == 1) ? LoginDefine.ELoginSex.Girl : LoginDefine.ELoginSex.Boy;
		IReadOnlyList<MainRoleConfig> mainRoleByGender = ConfigBase<RoleConfig>.Instance.GetMainRoleByGender(gender);
		if (mainRoleByGender == null)
		{
			return;
		}
		int count = mainRoleByGender.Count;
		RoleInfo? roleInfo = null;
		int? num3 = null;
		for (int i = 0; i < count; i++)
		{
			MainRoleConfig mainRoleConfig = mainRoleByGender[i];
			RoleInfo? roleConfig2 = ConfigBase<RoleConfig>.Instance.GetRoleConfig(mainRoleConfig.Id);
			if (roleConfig2 != null && elementId == roleConfig2.Value.ElementId)
			{
				num3 = new int?(mainRoleConfig.Id);
				roleInfo = roleConfig2;
				break;
			}
		}
		if (roleInfo == null)
		{
			return;
		}
		ValueTuple<string, string> roleHeadIcon = this.GetRoleHeadIcon(roleConfig.Value, roleInfo.Value);
		base.SetRoleIcon(roleHeadIcon.Item1, base.GetTexture(0), curSelectMainRoleId.Value, null, null);
		if (num3 != null)
		{
			base.SetRoleIcon(roleHeadIcon.Item2, base.GetTexture(1), num3.Value, null, null);
		}
		bool interactable = ModelBase<MainRoleModel>.Instance.CanChangeSex();
		UUIInteractionGroup interactionGroup = base.GetInteractionGroup(7);
		if (interactionGroup != null)
		{
			interactionGroup.SetInteractable(interactable);
		}
		int value = ConfigCommonParamById.GetIntConfig("ChangeSexCd").Value;
		Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(4), "GenderTransfer", new <>z__ReadOnlySingleElementList<object>(Math.Round((double)value / Singleton<TimeUtil>.Instance.Hour)));
		Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(5), "Cancel", Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(6), "Confirm", Array.Empty<object>());
	}

	// Token: 0x06014100 RID: 82176 RVA: 0x00599D88 File Offset: 0x00597F88
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnRoleChangeEnd, new Action(this.OnRoleChangeEnd));
	}

	// Token: 0x06014101 RID: 82177 RVA: 0x00599DA6 File Offset: 0x00597FA6
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnRoleChangeEnd, new Action(this.OnRoleChangeEnd));
	}

	// Token: 0x06014102 RID: 82178 RVA: 0x00599DC4 File Offset: 0x00597FC4
	private void OnRoleChangeEnd()
	{
		ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("GenderTransferSuccess", Array.Empty<object>());
		base.CloseMe(null);
	}

	// Token: 0x06014103 RID: 82179 RVA: 0x00599DE1 File Offset: 0x00597FE1
	protected void OnClickCancel()
	{
		base.CloseMe(null);
	}

	// Token: 0x06014104 RID: 82180 RVA: 0x00599DEC File Offset: 0x00597FEC
	protected void OnClickConfirm()
	{
		TsBaseCharacter baseCharacter = Global.BaseCharacter;
		bool flag;
		if (baseCharacter == null)
		{
			flag = (null != null);
		}
		else
		{
			CharacterActorComponent characterActorComponent = baseCharacter.CharacterActorComponent;
			flag = (((characterActorComponent != null) ? characterActorComponent.Entity : null) != null);
		}
		if (flag)
		{
			BaseTagComponent component = baseCharacter.CharacterActorComponent.Entity.GetComponent<BaseTagComponent>();
			if (component != null && component.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.进入战斗"]))
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByText(ConfigBase<TextConfig>.Instance.GetTextById("CanNotTransferInFight"));
				base.CloseMe(null);
				return;
			}
		}
		if (ModelBase<RoleModel>.Instance.HasAnyTrialRole())
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Text_CanNotChangeSexWhenTrail_Text", Array.Empty<object>());
			base.CloseMe(null);
			return;
		}
		ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.RoleGenderChangeConfirmBox);
		confirmBoxDataNew.FunctionMap.Add(2, new Action(this.SendRoleSexChangeRequest));
		ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
	}

	// Token: 0x06014105 RID: 82181 RVA: 0x00599EBC File Offset: 0x005980BC
	private void SendRoleSexChangeRequest()
	{
		int sex = (ModelBase<WorldLevelModel>.Instance.Sex != 1) ? 1 : 0;
		ControllerBase<MainRoleController>.Instance.SendRoleSexChangeRequest(sex);
	}

	// Token: 0x06014106 RID: 82182 RVA: 0x00599EE8 File Offset: 0x005980E8
	[return: TupleElementNames(new string[]
	{
		"FromPath",
		"TargetPath"
	})]
	[return: Nullable(new byte[]
	{
		0,
		2,
		2
	})]
	private ValueTuple<string, string> GetRoleHeadIcon(RoleInfo fromConfig, RoleInfo targetConfig)
	{
		RoleInstance roleInstanceById = ModelBase<RoleModel>.Instance.GetRoleInstanceById(fromConfig.Id);
		if (roleInstanceById == null)
		{
			return new ValueTuple<string, string>(fromConfig.RoleHeadIconBig, targetConfig.RoleHeadIconBig);
		}
		int roleSkinId = roleInstanceById.GetRoleSkinId();
		RoleSkinData roleSkinData = ModelBase<RoleSkinModel>.Instance.GetRoleSkinData(roleSkinId);
		if (roleSkinData == null)
		{
			return new ValueTuple<string, string>(fromConfig.RoleHeadIconBig, targetConfig.RoleHeadIconBig);
		}
		bool flag = ModelBase<PlayerInfoModel>.Instance.GetPlayerGender() == EPlayerGender.Female;
		IReadOnlyList<RoleSkin> skinGroupList = ConfigBase<SkinConfig>.Instance.GetSkinGroupList(roleSkinData.GetRoleSkinConfig().GroupId);
		if (skinGroupList == null)
		{
			return new ValueTuple<string, string>(fromConfig.RoleHeadIconBig, targetConfig.RoleHeadIconBig);
		}
		string item = null;
		foreach (RoleSkin roleSkin in skinGroupList)
		{
			if (flag)
			{
				if (roleSkin.RoleId == 1501)
				{
					item = roleSkin.RoleHeadIconBig;
				}
			}
			else if (roleSkin.RoleId == 1502)
			{
				item = roleSkin.RoleHeadIconBig;
			}
		}
		return new ValueTuple<string, string>(roleSkinData.GetRoleSkinConfig().RoleHeadIconBig, item);
	}

	// Token: 0x04009C45 RID: 40005
	private const int MALE_CONFIGID = 1501;

	// Token: 0x04009C46 RID: 40006
	private const int FEMALE_CONFIGID = 1502;

	// Token: 0x02008B6C RID: 35692
	public enum ERoleGenderChangeViewDefine
	{
		// Token: 0x0402EFFB RID: 192507
		LeftIcon,
		// Token: 0x0402EFFC RID: 192508
		RightIcon,
		// Token: 0x0402EFFD RID: 192509
		CancelButton,
		// Token: 0x0402EFFE RID: 192510
		ConfirmButton,
		// Token: 0x0402EFFF RID: 192511
		TitleText,
		// Token: 0x0402F000 RID: 192512
		LeftButtonText,
		// Token: 0x0402F001 RID: 192513
		RightButtonText,
		// Token: 0x0402F002 RID: 192514
		ConfirmButtonInteractionGroup
	}
}
