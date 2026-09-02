using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020028B9 RID: 10425
[NullableContext(1)]
[Nullable(0)]
public class RoleSkillIconItem : UiPanelBase
{
	// Token: 0x06014AEB RID: 84715 RVA: 0x005BA287 File Offset: 0x005B8487
	public RoleSkillIconItem(UUIItem uiItem, bool useTexture = false)
	{
		this.UseTexture = useTexture;
		base.CreateThenShowByActor(uiItem.GetOwner(), null);
	}

	// Token: 0x06014AEC RID: 84716 RVA: 0x005BA2A4 File Offset: 0x005B84A4
	protected unsafe override void OnRegisterComponent()
	{
		int num = 4;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		if (this.UseTexture)
		{
			this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(1, typeof(UUITexture)));
			this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(5, typeof(UUITexture)));
			this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(6, typeof(UUITexture)));
			this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(7, typeof(UUIExtendToggleTextureTransition)));
		}
		else
		{
			this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(1, typeof(UUISprite)));
			this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(5, typeof(UUISprite)));
			this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(6, typeof(UUISprite)));
			this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(7, typeof(UUIExtendToggleSpriteTransition)));
		}
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.ToggleCallBackInternal));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06014AED RID: 84717 RVA: 0x005BA46E File Offset: 0x005B866E
	private void ToggleCallBackInternal(EToggleState toggleState)
	{
		Action toggleCallBack = this.ToggleCallBack;
		if (toggleCallBack == null)
		{
			return;
		}
		toggleCallBack();
	}

	// Token: 0x06014AEE RID: 84718 RVA: 0x005BA480 File Offset: 0x005B8680
	public void Update(int roleId, int skillNodeId)
	{
		this.SetId(roleId, skillNodeId);
		this.Refresh();
	}

	// Token: 0x06014AEF RID: 84719 RVA: 0x005BA490 File Offset: 0x005B8690
	public void SetId(int roleId, int skillNodeId)
	{
		this.RoleId = roleId;
		this.SkillNodeId = skillNodeId;
		this.SkillTreeNodeConfig = new SkillTree?(ConfigBase<RoleSkillConfig>.Instance.GetSkillTreeNode(this.SkillNodeId).Value);
		int skillId = this.SkillTreeNodeConfig.Value.SkillId;
		this.SkillId = skillId;
		this.SkillConfig = ((this.SkillId > 0) ? ConfigBase<RoleSkillConfig>.Instance.GetSkillConfigById(skillId) : null);
		this.UpgradeSkillId = ((skillId > 0) ? ModelBase<RoleModel>.Instance.GetUpgradeSkillIdIfUpgraded(skillId, roleId) : 0);
		this.UpgradeSkillConfig = ((this.UpgradeSkillId > 0) ? ConfigBase<RoleSkillConfig>.Instance.GetSkillConfigById(this.UpgradeSkillId) : null);
	}

	// Token: 0x06014AF0 RID: 84720 RVA: 0x005BA551 File Offset: 0x005B8751
	public void Refresh()
	{
		this.RefreshSkillIcon();
		this.RefreshState();
	}

	// Token: 0x06014AF1 RID: 84721 RVA: 0x005BA560 File Offset: 0x005B8760
	public void RefreshState()
	{
		int roleSkillTreeNodeLevel = ModelBase<RoleModel>.Instance.GetRoleSkillTreeNodeLevel(this.RoleId, this.SkillNodeId);
		UUIItem item = base.GetItem(2);
		if (item != null)
		{
			item.SetUIActive(roleSkillTreeNodeLevel > 0);
		}
		UUIItem uuiitem = this.UseTexture ? base.GetTexture(5) : base.GetSprite(5);
		if (uuiitem != null)
		{
			UUIItem uuiitem2 = uuiitem;
			bool bUseChangeColor = roleSkillTreeNodeLevel > 0;
			FColor? fcolor = new FColor?(uuiitem.changeColor);
			uuiitem2.SetChangeColor(bUseChangeColor, fcolor);
		}
		uuiitem = (this.UseTexture ? base.GetTexture(6) : base.GetSprite(6));
		if (uuiitem != null)
		{
			UUIItem uuiitem3 = uuiitem;
			bool bUseChangeColor2 = roleSkillTreeNodeLevel > 0;
			FColor? fcolor = new FColor?(uuiitem.changeColor);
			uuiitem3.SetChangeColor(bUseChangeColor2, fcolor);
		}
		ESkillTreeNodeState? roleSkillTreeNodeState = ModelBase<RoleModel>.Instance.GetRoleSkillTreeNodeState(this.RoleId, this.SkillNodeId);
		UUIItem item2 = base.GetItem(4);
		if (item2 != null)
		{
			item2.SetUIActive(roleSkillTreeNodeState.GetValueOrDefault() == ESkillTreeNodeState.Lock);
		}
		UUIItem item3 = base.GetItem(3);
		if (item3 == null)
		{
			return;
		}
		item3.SetUIActive(roleSkillTreeNodeState.GetValueOrDefault() != ESkillTreeNodeState.Lock && roleSkillTreeNodeLevel == 0);
	}

	// Token: 0x06014AF2 RID: 84722 RVA: 0x005BA658 File Offset: 0x005B8858
	public void RefreshSkillIcon()
	{
		string text;
		if (this.SkillId > 0 && this.SkillConfig != null)
		{
			text = this.SkillConfig.Value.Icon;
		}
		else
		{
			text = this.SkillTreeNodeConfig.Value.PropertyNodeIcon;
		}
		if (!string.IsNullOrEmpty(text))
		{
			this.SetSkillIconByPath(text);
		}
	}

	// Token: 0x06014AF3 RID: 84723 RVA: 0x005BA6B6 File Offset: 0x005B88B6
	private void SetSkillIconByPath(string iconPath)
	{
		if (this.UseTexture)
		{
			this.SetIconByTexture(1, iconPath);
			this.SetIconByTexture(5, iconPath);
			this.SetIconByTexture(6, iconPath);
			return;
		}
		this.SetIconBySprite(1, iconPath);
		this.SetIconBySprite(5, iconPath);
		this.SetIconBySprite(6, iconPath);
	}

	// Token: 0x06014AF4 RID: 84724 RVA: 0x005BA6F4 File Offset: 0x005B88F4
	private void SetIconByTexture(int name, string iconPath)
	{
		UUITexture iconTexture = base.GetTexture(name);
		if (iconTexture != null)
		{
			UUIExtendToggleTextureTransition transition = base.GetUiExtendToggleTextureTransition(7);
			Action<bool> callback = null;
			if (transition != null)
			{
				callback = delegate(bool _)
				{
					UUIExtendToggleTextureTransition transition = transition;
					if (transition == null)
					{
						return;
					}
					transition.SetAllTransitionStateTexture(iconTexture.GetTexture());
				};
			}
			base.SetTextureByPath(iconPath, iconTexture, null, callback);
		}
	}

	// Token: 0x06014AF5 RID: 84725 RVA: 0x005BA758 File Offset: 0x005B8958
	private void SetIconBySprite(int name, string iconPath)
	{
		UUISprite iconSprite = base.GetSprite(name);
		if (iconSprite != null)
		{
			UUIExtendToggleSpriteTransition transition = base.GetUiExtendToggleSpriteTransition(7);
			Action<bool> callback = null;
			if (transition != null)
			{
				callback = delegate(bool _)
				{
					UUIExtendToggleSpriteTransition transition = transition;
					if (transition == null)
					{
						return;
					}
					transition.SetAllStateSprite(iconSprite.GetSprite());
				};
			}
			this.SetSpriteByPath(iconPath, iconSprite, false, null, callback);
		}
	}

	// Token: 0x06014AF6 RID: 84726 RVA: 0x005BA7BC File Offset: 0x005B89BC
	public int GetRoleId()
	{
		return this.RoleId;
	}

	// Token: 0x06014AF7 RID: 84727 RVA: 0x005BA7C4 File Offset: 0x005B89C4
	public int GetSkillNodeId()
	{
		return this.SkillNodeId;
	}

	// Token: 0x06014AF8 RID: 84728 RVA: 0x005BA7CC File Offset: 0x005B89CC
	public int GetSkillId()
	{
		return this.SkillId;
	}

	// Token: 0x06014AF9 RID: 84729 RVA: 0x005BA7D4 File Offset: 0x005B89D4
	public int GetUpgradeSkillId()
	{
		return this.UpgradeSkillId;
	}

	// Token: 0x06014AFA RID: 84730 RVA: 0x005BA7DC File Offset: 0x005B89DC
	public SkillTree? GetSkillTreeNodeConfig()
	{
		return this.SkillTreeNodeConfig;
	}

	// Token: 0x06014AFB RID: 84731 RVA: 0x005BA7E4 File Offset: 0x005B89E4
	public Aki.Config.Skill? GetSkillConfig()
	{
		return this.SkillConfig;
	}

	// Token: 0x06014AFC RID: 84732 RVA: 0x005BA7EC File Offset: 0x005B89EC
	public Aki.Config.Skill? GetUpgradeSkillConfig()
	{
		return this.UpgradeSkillConfig;
	}

	// Token: 0x06014AFD RID: 84733 RVA: 0x005BA7F4 File Offset: 0x005B89F4
	public void SetToggleCallBack(Action callBack)
	{
		this.ToggleCallBack = callBack;
	}

	// Token: 0x06014AFE RID: 84734 RVA: 0x005BA7FD File Offset: 0x005B89FD
	public void SetToggleState(EToggleState state, bool bFireEvent = false)
	{
		base.GetExtendToggle(0).SetToggleState(state, bFireEvent, false, false);
	}

	// Token: 0x06014AFF RID: 84735 RVA: 0x005BA810 File Offset: 0x005B8A10
	public UUIItem GetToggleItem()
	{
		return base.GetExtendToggle(0).GetRootComponent();
	}

	// Token: 0x04009F91 RID: 40849
	private int RoleId;

	// Token: 0x04009F92 RID: 40850
	private int SkillNodeId;

	// Token: 0x04009F93 RID: 40851
	private int SkillId;

	// Token: 0x04009F94 RID: 40852
	private int UpgradeSkillId;

	// Token: 0x04009F95 RID: 40853
	private SkillTree? SkillTreeNodeConfig;

	// Token: 0x04009F96 RID: 40854
	private Aki.Config.Skill? SkillConfig;

	// Token: 0x04009F97 RID: 40855
	private Aki.Config.Skill? UpgradeSkillConfig;

	// Token: 0x04009F98 RID: 40856
	[Nullable(2)]
	private Action ToggleCallBack;

	// Token: 0x04009F99 RID: 40857
	private readonly bool UseTexture;

	// Token: 0x02008BFD RID: 35837
	[NullableContext(0)]
	private enum EComponents
	{
		// Token: 0x0402F277 RID: 193143
		Toggle,
		// Token: 0x0402F278 RID: 193144
		Icon,
		// Token: 0x0402F279 RID: 193145
		ActivatedItem,
		// Token: 0x0402F27A RID: 193146
		InactiveItem,
		// Token: 0x0402F27B RID: 193147
		LockItem,
		// Token: 0x0402F27C RID: 193148
		ExIcon1,
		// Token: 0x0402F27D RID: 193149
		ExIcon2,
		// Token: 0x0402F27E RID: 193150
		ExtendToggleTransition
	}
}
