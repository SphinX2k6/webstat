using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x0200243B RID: 9275
[NullableContext(1)]
[Nullable(0)]
public class PersonalRoleDisplayItem : GridProxyAbstract<int>
{
	// Token: 0x06011EF1 RID: 73457 RVA: 0x004EF3B8 File Offset: 0x004ED5B8
	public PersonalRoleDisplayItem(UUIItem item)
	{
		if (item != null)
		{
			this.CreateThenShowByActor(item.GetOwner());
		}
	}

	// Token: 0x06011EF2 RID: 73458 RVA: 0x004EF3D0 File Offset: 0x004ED5D0
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUITexture)),
			new ValueTuple<int, Type>(1, typeof(UUISprite)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIText)),
			new ValueTuple<int, Type>(5, typeof(UUITexture)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIText)),
			new ValueTuple<int, Type>(9, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(10, typeof(UUIItem)),
			new ValueTuple<int, Type>(11, typeof(UUIItem)),
			new ValueTuple<int, Type>(12, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(9, new Action(this.OnClickItem))
		};
	}

	// Token: 0x06011EF3 RID: 73459 RVA: 0x004EF518 File Offset: 0x004ED718
	public override void Refresh(int roleId, bool isSelected, int gridIndex)
	{
		this.InitAllItemState();
		this.RoleId = roleId;
		this.GirdIndex = gridIndex;
		base.GetTexture(0).SetUIActive(this.RoleId != -1);
		if (this.RoleId == -1)
		{
			return;
		}
		bool flag = ModelBase<RoleModel>.Instance.GetRoleInstanceById(this.RoleId) != null;
		base.GetItem(12).SetUIActive(!flag);
		base.SetTextureByPath(ConfigBase<RoleConfig>.Instance.GetRoleConfig(this.RoleId).Value.RoleHeadIconBig, base.GetTexture(0), null, null);
		this.RefreshQualitySprite();
	}

	// Token: 0x06011EF4 RID: 73460 RVA: 0x004EF5C0 File Offset: 0x004ED7C0
	private void RefreshQualitySprite()
	{
		int qualityId = ConfigBase<RoleConfig>.Instance.GetRoleConfig(this.RoleId).Value.QualityId;
		this.SetSpriteByPath(ConfigBase<RoleConfig>.Instance.GetRoleQualityInfo(qualityId).Value.Image, base.GetSprite(1), false, null, null);
	}

	// Token: 0x06011EF5 RID: 73461 RVA: 0x004EF624 File Offset: 0x004ED824
	public void ShowLevelText()
	{
		UUIText text = base.GetText(2);
		text.SetUIActive(true);
		RoleInstance roleInstanceById = ModelBase<RoleModel>.Instance.GetRoleInstanceById(this.RoleId);
		if (roleInstanceById != null)
		{
			RoleLevelData levelData = roleInstanceById.GetLevelData();
			if (levelData != null)
			{
				int level = levelData.GetLevel();
				Singleton<LguiUtil>.Instance.SetLocalText(text, "LevelShow", new <>z__ReadOnlySingleElementList<object>(level));
			}
		}
	}

	// Token: 0x06011EF6 RID: 73462 RVA: 0x004EF680 File Offset: 0x004ED880
	public void ShowNameText()
	{
		UUIText text = base.GetText(4);
		text.SetUIActive(true);
		RoleInfo? roleConfig = ConfigBase<RoleConfig>.Instance.GetRoleConfig(this.RoleId);
		if (roleConfig != null)
		{
			text.ShowTextNew(roleConfig.Value.Name);
		}
	}

	// Token: 0x06011EF7 RID: 73463 RVA: 0x004EF6CC File Offset: 0x004ED8CC
	public void InitAllItemState()
	{
		base.GetText(2).SetUIActive(false);
		base.GetItem(3).SetUIActive(false);
		base.GetText(4).SetUIActive(false);
		base.GetTexture(5).SetUIActive(false);
		base.GetItem(7).SetUIActive(false);
		base.GetText(8).SetUIActive(false);
		base.GetItem(10).SetUIActive(false);
		base.GetItem(11).SetUIActive(false);
	}

	// Token: 0x06011EF8 RID: 73464 RVA: 0x004EF743 File Offset: 0x004ED943
	private void OnClickItem()
	{
		this.OnClickCallback(this.RoleId, this.GirdIndex);
	}

	// Token: 0x06011EF9 RID: 73465 RVA: 0x004EF75C File Offset: 0x004ED95C
	public void SetToggleState(EToggleState state)
	{
	}

	// Token: 0x06011EFA RID: 73466 RVA: 0x004EF75E File Offset: 0x004ED95E
	public void SetClickCallback(TPersonalRoleDisplayItemClickFunction clickFunction)
	{
		this.OnClickCallback = clickFunction;
	}

	// Token: 0x06011EFB RID: 73467 RVA: 0x004EF767 File Offset: 0x004ED967
	public int GetRoleId()
	{
		return this.RoleId;
	}

	// Token: 0x06011EFC RID: 73468 RVA: 0x004EF76F File Offset: 0x004ED96F
	public int GetGirdIndex()
	{
		return this.GirdIndex;
	}

	// Token: 0x06011EFD RID: 73469 RVA: 0x004EF777 File Offset: 0x004ED977
	public void SetUseState(bool isUsing)
	{
		base.GetItem(10).SetUIActive(isUsing);
	}

	// Token: 0x06011EFE RID: 73470 RVA: 0x004EF787 File Offset: 0x004ED987
	public void SetSelectState(int curSelectRoleId, bool bFireEvent = false)
	{
	}

	// Token: 0x04008C8B RID: 35979
	private int RoleId;

	// Token: 0x04008C8C RID: 35980
	private int GirdIndex;

	// Token: 0x04008C8D RID: 35981
	[Nullable(2)]
	private TPersonalRoleDisplayItemClickFunction OnClickCallback;
}
