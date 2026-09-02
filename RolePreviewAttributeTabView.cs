using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using AkiClient.Game.Aki.Character.Role.Common.Data.Enum;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Module.Util.Layout;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020028E8 RID: 10472
public class RolePreviewAttributeTabView : UiTabViewBase
{
	// Token: 0x06014CBA RID: 85178 RVA: 0x005C2878 File Offset: 0x005C0A78
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUITexture)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIVerticalLayout)),
			new ValueTuple<int, Type>(4, typeof(UUIText)),
			new ValueTuple<int, Type>(5, typeof(UUIHorizontalLayout)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(8, typeof(UUITexture))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(7, new Action(this.RoleTagClick))
		};
	}

	// Token: 0x06014CBB RID: 85179 RVA: 0x005C297C File Offset: 0x005C0B7C
	protected override void OnStart()
	{
		this.RoleViewAgent = (this.ExtraParams as RoleViewAgent);
		if (this.RoleViewAgent == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Role;
			ELogAuthor author = ELogAuthor.BB;
			string message = "RoleViewAgent为空";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("界面名称", "RolePreviewAttributeTabView");
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		this.AttributeLayout = new GenericLayoutNew<CSharpScript.Game.Module.RoleUi.RoleAttributeItem>(base.GetVerticalLayout(3), new CSharpScript.Game.Module.Util.Layout.TLayoutRefresh<CSharpScript.Game.Module.RoleUi.RoleAttributeItem>(this.InitRoleAttributeItem), null);
		this.RoleTagLayout = new GenericLayout<RoleTagSmallIconItem, int>(base.GetHorizontalLayout(5), new Func<RoleTagSmallIconItem>(this.InitRoleTagItem), null, false, true);
	}

	// Token: 0x06014CBC RID: 85180 RVA: 0x005C2A0E File Offset: 0x005C0C0E
	protected override void AddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.RoleSystemChangeRole, new Action<int>(this.OnRoleChange));
	}

	// Token: 0x06014CBD RID: 85181 RVA: 0x005C2A2C File Offset: 0x005C0C2C
	protected override void RemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.RoleSystemChangeRole, new Action<int>(this.OnRoleChange));
	}

	// Token: 0x06014CBE RID: 85182 RVA: 0x005C2A4C File Offset: 0x005C0C4C
	protected override void OnBeforeShow()
	{
		this.PlayMontageStart();
		int curSelectRoleId = this.RoleViewAgent.GetCurSelectRoleId();
		this.OnRefresh(curSelectRoleId);
	}

	// Token: 0x06014CBF RID: 85183 RVA: 0x005C2A72 File Offset: 0x005C0C72
	protected override void OnBeforeDestroy()
	{
		this.RoleInstance = null;
		GenericLayoutNew<CSharpScript.Game.Module.RoleUi.RoleAttributeItem> attributeLayout = this.AttributeLayout;
		if (attributeLayout != null)
		{
			attributeLayout.ClearChildren();
		}
		this.AttributeLayout = null;
	}

	// Token: 0x06014CC0 RID: 85184 RVA: 0x005C2A93 File Offset: 0x005C0C93
	private void OnRoleChange(int roleId)
	{
		this.PlayMontageStartWithReLoop();
		this.OnRefresh(roleId);
	}

	// Token: 0x06014CC1 RID: 85185 RVA: 0x005C2AA2 File Offset: 0x005C0CA2
	protected void PlayMontageStart()
	{
		ControllerBase<RoleController>.Instance.PlayRoleMontage(EPerformanceRoleState.Attribute_Perform, false, false, false);
	}

	// Token: 0x06014CC2 RID: 85186 RVA: 0x005C2AB2 File Offset: 0x005C0CB2
	protected void PlayMontageStartWithReLoop()
	{
		ControllerBase<RoleController>.Instance.PlayRoleMontage(EPerformanceRoleState.Attribute_Perform, false, true, false);
	}

	// Token: 0x06014CC3 RID: 85187 RVA: 0x005C2AC2 File Offset: 0x005C0CC2
	private void OnRefresh(int roleId)
	{
		this.RoleInstance = ModelBase<RoleModel>.Instance.GetRoleDataById(roleId, true);
		if (this.RoleInstance == null)
		{
			return;
		}
		this.UpdateName();
		this.UpdateAttributeInfo();
		this.UpdateAttributeLayout();
		this.UpdateDescription();
		this.UpdateRoleTag();
	}

	// Token: 0x06014CC4 RID: 85188 RVA: 0x005C2B00 File Offset: 0x005C0D00
	private void UpdateAttributeInfo()
	{
		ElementInfo? elementInfo = this.RoleInstance.GetElementInfo();
		if (elementInfo == null)
		{
			return;
		}
		base.SetElementIcon(elementInfo.Value.Icon, base.GetTexture(1), this.RoleInstance.GetRoleConfig().ElementId, null);
		string icon = elementInfo.Value.Icon;
		this.SetSpriteByPath(icon, base.GetSprite(8), false, null, null);
		string elementInfoLocalName = ConfigBase<ElementInfoConfig>.Instance.GetElementInfoLocalName(elementInfo.Value.Name);
		base.GetText(2).SetText(elementInfoLocalName, true);
	}

	// Token: 0x06014CC5 RID: 85189 RVA: 0x005C2BB0 File Offset: 0x005C0DB0
	private void UpdateName()
	{
		base.GetText(0).SetText(this.RoleInstance.GetName(null), true);
	}

	// Token: 0x06014CC6 RID: 85190 RVA: 0x005C2BE0 File Offset: 0x005C0DE0
	private void UpdateAttributeLayout()
	{
		FavorRoleInfo? favorRoleInfoConfig = ConfigBase<RoleFavorConfig>.Instance.GetFavorRoleInfoConfig(this.RoleInstance.GetRoleId());
		RoleInfo roleConfig = this.RoleInstance.GetRoleConfig();
		List<IAttributeInfo> list = new List<IAttributeInfo>();
		string weaponTypeName = ConfigBase<WeaponConfig>.Instance.GetWeaponTypeName(roleConfig.WeaponType);
		AttributeInfo item = new AttributeInfo
		{
			Name = "Text_Weapon_Text",
			CurText = weaponTypeName
		};
		list.Add(item);
		if (favorRoleInfoConfig != null)
		{
			string localTextNew = ConfigMultiTextLang.GetLocalTextNew(favorRoleInfoConfig.Value.Sex, null);
			AttributeInfo item2 = new AttributeInfo
			{
				Name = "PrefabTextItem_3159729083_Text",
				CurText = localTextNew
			};
			list.Add(item2);
			string localTextNew2 = ConfigMultiTextLang.GetLocalTextNew(favorRoleInfoConfig.Value.Country, null);
			AttributeInfo item3 = new AttributeInfo
			{
				Name = "PrefabTextItem_3969856612_Text",
				CurText = localTextNew2
			};
			list.Add(item3);
			string localTextNew3 = ConfigMultiTextLang.GetLocalTextNew(favorRoleInfoConfig.Value.Influence, null);
			AttributeInfo item4 = new AttributeInfo
			{
				Name = "PrefabTextItem_152395022_Text",
				CurText = localTextNew3
			};
			list.Add(item4);
		}
		string localTextNew4 = ConfigMultiTextLang.GetLocalTextNew(RoleFavorUtil.GetCurLanguageCvName(this.RoleInstance.GetRoleId()), null);
		AttributeInfo item5 = new AttributeInfo
		{
			Name = "Text_CharacterVoice_Text",
			CurText = localTextNew4
		};
		list.Add(item5);
		bool flag = true;
		foreach (IAttributeInfo attributeInfo in list)
		{
			attributeInfo.ShowArrow = new bool?(false);
			attributeInfo.InnerShowBg = new bool?(flag);
			flag = !flag;
		}
		GenericLayoutNew<CSharpScript.Game.Module.RoleUi.RoleAttributeItem> attributeLayout = this.AttributeLayout;
		if (attributeLayout == null)
		{
			return;
		}
		attributeLayout.RebuildLayoutByDataNew<IAttributeInfo>(list, null);
	}

	// Token: 0x06014CC7 RID: 85191 RVA: 0x005C2DB4 File Offset: 0x005C0FB4
	[NullableContext(1)]
	private ILayoutItem<CSharpScript.Game.Module.RoleUi.RoleAttributeItem> InitRoleAttributeItem(object data, UUIItem uiItem, int index)
	{
		CSharpScript.Game.Module.RoleUi.RoleAttributeItem roleAttributeItem = new CSharpScript.Game.Module.RoleUi.RoleAttributeItem();
		roleAttributeItem.SetRootActor(uiItem.GetOwner(), true);
		roleAttributeItem.Refresh((IAttributeInfo)data);
		return new LayoutItem<CSharpScript.Game.Module.RoleUi.RoleAttributeItem>
		{
			Key = index,
			Value = roleAttributeItem
		};
	}

	// Token: 0x06014CC8 RID: 85192 RVA: 0x005C2DF8 File Offset: 0x005C0FF8
	private void UpdateRoleTag()
	{
		int[] roleTagByRoleInfo = ModelBase<RoleModel>.Instance.GetRoleTagByRoleInfo(this.RoleInstance.GetRoleConfig());
		this.RoleTagLayout.RefreshByData(new List<int>(roleTagByRoleInfo), null, false);
	}

	// Token: 0x06014CC9 RID: 85193 RVA: 0x005C2E30 File Offset: 0x005C1030
	private void UpdateDescription()
	{
		RoleInfo roleConfig = this.RoleInstance.GetRoleConfig();
		base.GetText(4).ShowTextNew(roleConfig.Introduction);
	}

	// Token: 0x06014CCA RID: 85194 RVA: 0x005C2E5C File Offset: 0x005C105C
	[NullableContext(1)]
	private RoleTagSmallIconItem InitRoleTagItem()
	{
		return new RoleTagSmallIconItem();
	}

	// Token: 0x06014CCB RID: 85195 RVA: 0x005C2E64 File Offset: 0x005C1064
	protected void RoleTagClick()
	{
		RoleInfo roleConfig = this.RoleInstance.GetRoleConfig();
		int[] roleTagByRoleInfo = ModelBase<RoleModel>.Instance.GetRoleTagByRoleInfo(roleConfig);
		Singleton<UiManager>.Instance.OpenView(EUiViewName.RoleTagDetailView, roleTagByRoleInfo, null);
	}

	// Token: 0x0400A01C RID: 40988
	[Nullable(2)]
	protected RoleViewAgent RoleViewAgent;

	// Token: 0x0400A01D RID: 40989
	[Nullable(2)]
	protected RoleDataBase RoleInstance;

	// Token: 0x0400A01E RID: 40990
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayoutNew<CSharpScript.Game.Module.RoleUi.RoleAttributeItem> AttributeLayout;

	// Token: 0x0400A01F RID: 40991
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<RoleTagSmallIconItem, int> RoleTagLayout;

	// Token: 0x02008C3B RID: 35899
	private enum EPreviewAttributeViewNode
	{
		// Token: 0x0402F3C0 RID: 193472
		TextName,
		// Token: 0x0402F3C1 RID: 193473
		IconAttribute,
		// Token: 0x0402F3C2 RID: 193474
		TextAttribute,
		// Token: 0x0402F3C3 RID: 193475
		AttributeLayout,
		// Token: 0x0402F3C4 RID: 193476
		TextDescription,
		// Token: 0x0402F3C5 RID: 193477
		LayoutRoleTag,
		// Token: 0x0402F3C6 RID: 193478
		ItemRoleTag,
		// Token: 0x0402F3C7 RID: 193479
		ButtonRoleTag,
		// Token: 0x0402F3C8 RID: 193480
		IconAttributeBg
	}
}
