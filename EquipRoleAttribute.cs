using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020024F8 RID: 9464
internal class EquipRoleAttribute : UiPanelBase
{
	// Token: 0x06012620 RID: 75296 RVA: 0x0050DFA2 File Offset: 0x0050C1A2
	[NullableContext(1)]
	public EquipRoleAttribute(UUIItem actor)
	{
		base.CreateThenShowByActor(actor.GetOwner(), null);
	}

	// Token: 0x06012621 RID: 75297 RVA: 0x0050DFB7 File Offset: 0x0050C1B7
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUITexture)),
			new ValueTuple<int, Type>(1, typeof(UUIText))
		};
	}

	// Token: 0x06012622 RID: 75298 RVA: 0x0050DFF0 File Offset: 0x0050C1F0
	[NullableContext(1)]
	public void Update(PhantomBattleData data)
	{
		if (ControllerBase<PhantomBattleController>.Instance.CheckIsEquip(data.GetUniqueId()))
		{
			int? equipRole = ControllerBase<PhantomBattleController>.Instance.GetEquipRole(data.GetUniqueId());
			RoleSkinModel instance = ModelBase<RoleSkinModel>.Instance;
			RoleSkinData roleSkinData = (instance != null) ? instance.GetRoleSkinDataByRoleId(equipRole.Value) : null;
			if (roleSkinData == null)
			{
				return;
			}
			RoleSkin roleSkinConfig = roleSkinData.GetRoleSkinConfig();
			string tag = "RoleIcon1";
			string roleSkinConfigParam = ConfigBase<ComponentConfig>.Instance.GetRoleSkinConfigParam(tag);
			if (roleSkinConfigParam != null && roleSkinConfigParam != "")
			{
				RoleSkin roleSkin = roleSkinConfig;
				PropertyInfo property = roleSkin.GetType().GetProperty(roleSkinConfigParam);
				if (property != null)
				{
					string text = property.GetValue(roleSkin) as string;
					if (text != null)
					{
						base.SetTextureByPath(text, base.GetTexture(0), null, null);
					}
				}
			}
			string item = ConfigBase<RoleConfig>.Instance.GetRoleName(roleSkinConfig.Name);
			IReadOnlyList<MainRoleConfig> allMainRoleConfig = ConfigBase<RoleConfig>.Instance.GetAllMainRoleConfig();
			bool flag = false;
			int count = allMainRoleConfig.Count;
			for (int i = 0; i < count; i++)
			{
				int id = allMainRoleConfig[i].Id;
				int? num = equipRole;
				if (id == num.GetValueOrDefault() & num != null)
				{
					flag = true;
					break;
				}
			}
			if (flag)
			{
				item = ModelBase<FunctionModel>.Instance.GetPlayerName();
			}
			Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(1), "VisionEquipping", new <>z__ReadOnlySingleElementList<object>(item));
		}
	}

	// Token: 0x02008811 RID: 34833
	private enum EUnderRoleAttribute
	{
		// Token: 0x0402DF6B RID: 188267
		RoleTexture,
		// Token: 0x0402DF6C RID: 188268
		RoleText
	}
}
