using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Skin;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020024E3 RID: 9443
public class VisionAssembleItem : UiPanelBase
{
	// Token: 0x0601255C RID: 75100 RVA: 0x0050A2B4 File Offset: 0x005084B4
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUISprite)),
			new ValueTuple<int, Type>(2, typeof(UUITexture)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUISprite)),
			new ValueTuple<int, Type>(6, typeof(UUITexture)),
			new ValueTuple<int, Type>(7, typeof(UUIText))
		};
	}

	// Token: 0x0601255D RID: 75101 RVA: 0x0050A37C File Offset: 0x0050857C
	protected override UniTask OnBeforeStartAsync()
	{
		VisionAssembleItem.<OnBeforeStartAsync>d__3 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<VisionAssembleItem.<OnBeforeStartAsync>d__3>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0601255E RID: 75102 RVA: 0x0050A3BF File Offset: 0x005085BF
	public void Reset()
	{
		base.GetItem(0).SetUIActive(false);
	}

	// Token: 0x0601255F RID: 75103 RVA: 0x0050A3CE File Offset: 0x005085CE
	public void Update(int visionId)
	{
		base.GetItem(0).SetUIActive(true);
		this.RefreshQualitySprite(visionId);
		this.RefreshSuitElement(visionId);
		this.RefreshTextureIcon(visionId);
		this.RefreshRoleItem(visionId);
		this.RefreshCostText(visionId);
	}

	// Token: 0x06012560 RID: 75104 RVA: 0x0050A400 File Offset: 0x00508600
	private void RefreshRoleItem(int visionId)
	{
		int? phantomEquipOnRoleId = ModelBase<PhantomBattleModel>.Instance.GetPhantomEquipOnRoleId(visionId);
		if (phantomEquipOnRoleId == null)
		{
			base.GetItem(4).SetUIActive(false);
			return;
		}
		if (ModelBase<RoleModel>.Instance.GetRoleDataById(phantomEquipOnRoleId.Value, true) == null)
		{
			base.GetItem(4).SetUIActive(false);
			return;
		}
		base.GetItem(4).SetUIActive(true);
		this.RefreshLightSprite(visionId);
		this.RefreshRoleTexture(visionId);
	}

	// Token: 0x06012561 RID: 75105 RVA: 0x0050A470 File Offset: 0x00508670
	private void RefreshRoleTexture(int visionId)
	{
		UUITexture roleTexture = base.GetTexture(6);
		int? phantomEquipOnRoleId = ModelBase<PhantomBattleModel>.Instance.GetPhantomEquipOnRoleId(visionId);
		RoleDataBase roleDataBase = (phantomEquipOnRoleId != null) ? ModelBase<RoleModel>.Instance.GetRoleDataById(phantomEquipOnRoleId.Value, true) : null;
		if (roleDataBase == null)
		{
			roleTexture.SetUIActive(false);
			return;
		}
		int roleSkinId = roleDataBase.GetRoleSkinId();
		string card = ConfigBase<SkinConfig>.Instance.GetRoleSkinConfig(roleSkinId).Value.Card;
		base.SetRoleSkinIcon(card, roleTexture, roleSkinId, null, delegate(bool _)
		{
			roleTexture.SetUIActive(true);
		});
	}

	// Token: 0x06012562 RID: 75106 RVA: 0x0050A518 File Offset: 0x00508718
	private void RefreshQualitySprite(int visionId)
	{
		int quality = ModelBase<PhantomBattleModel>.Instance.GetPhantomBattleData(visionId).GetQuality();
		string phantomQualityBgSprite = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomQualityBgSprite(quality);
		this.SetSpriteByPath(phantomQualityBgSprite, base.GetSprite(1), false, null, null);
	}

	// Token: 0x06012563 RID: 75107 RVA: 0x0050A55C File Offset: 0x0050875C
	private void RefreshLightSprite(int visionId)
	{
		string resourcePath;
		if (ModelBase<PhantomBattleModel>.Instance.CheckPhantomIsMain(visionId))
		{
			resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("SP_ItemHeadBg1");
		}
		else
		{
			resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("SP_ItemHeadBg2");
		}
		this.SetSpriteByPath(resourcePath, base.GetSprite(5), false, null, null);
	}

	// Token: 0x06012564 RID: 75108 RVA: 0x0050A5B4 File Offset: 0x005087B4
	private void RefreshSuitElement(int visionId)
	{
		PhantomBattleData phantomBattleData = ModelBase<PhantomBattleModel>.Instance.GetPhantomBattleData(visionId);
		PhantomFetterGroup fetterGroupById = ConfigBase<PhantomBattleConfig>.Instance.GetFetterGroupById(phantomBattleData.GetFetterGroupId());
		this.VisionFetterSuitItem.Update(new PhantomFetterGroup?(fetterGroupById));
	}

	// Token: 0x06012565 RID: 75109 RVA: 0x0050A5F0 File Offset: 0x005087F0
	private void RefreshTextureIcon(int visionId)
	{
		PhantomBattleData phantomBattleData = ModelBase<PhantomBattleModel>.Instance.GetPhantomBattleData(visionId);
		ItemConfig itemConfigData = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(phantomBattleData.GetConfigId(true));
		base.SetTextureByPath(itemConfigData.IconMiddle, base.GetTexture(2), null, null);
	}

	// Token: 0x06012566 RID: 75110 RVA: 0x0050A638 File Offset: 0x00508838
	private void RefreshCostText(int visionId)
	{
		PhantomBattleData phantomBattleData = ModelBase<PhantomBattleModel>.Instance.GetPhantomBattleData(visionId);
		base.GetText(7).SetText(phantomBattleData.GetCost().ToString(), true);
	}

	// Token: 0x04008EFB RID: 36603
	[Nullable(2)]
	private VisionFetterSuitItem VisionFetterSuitItem;

	// Token: 0x020087F1 RID: 34801
	private enum EComponent
	{
		// Token: 0x0402DED7 RID: 188119
		Item,
		// Token: 0x0402DED8 RID: 188120
		QualitySprite,
		// Token: 0x0402DED9 RID: 188121
		TextureIcon,
		// Token: 0x0402DEDA RID: 188122
		ElementItem,
		// Token: 0x0402DEDB RID: 188123
		RoleItem,
		// Token: 0x0402DEDC RID: 188124
		RoleLightSprite,
		// Token: 0x0402DEDD RID: 188125
		RoleTexture,
		// Token: 0x0402DEDE RID: 188126
		CostText
	}
}
