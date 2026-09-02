using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020028E5 RID: 10469
public class RolePhantomItem : UiPanelBase
{
	// Token: 0x06014CA7 RID: 85159 RVA: 0x005C2299 File Offset: 0x005C0499
	[NullableContext(1)]
	public RolePhantomItem(UUIItem uiItem, Action<int> onFunction, EPhantomItemIndex index)
	{
		base.CreateThenShowByActor(uiItem.GetOwner(), null);
		this.ClickFunction = onFunction;
		this.Index = index;
	}

	// Token: 0x06014CA8 RID: 85160 RVA: 0x005C22BC File Offset: 0x005C04BC
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(1, typeof(UUITexture)),
			new ValueTuple<int, Type>(2, typeof(UUISprite)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIText))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action(this.OnClick))
		};
	}

	// Token: 0x06014CA9 RID: 85161 RVA: 0x005C2365 File Offset: 0x005C0565
	public virtual void UpdateItem(int id)
	{
		this.Id = id;
		this.RefreshIcon();
		this.RefreshQuality();
		this.RefreshLevel();
	}

	// Token: 0x06014CAA RID: 85162 RVA: 0x005C2380 File Offset: 0x005C0580
	public void UpdateTrialItem(int itemId)
	{
		base.GetSprite(2).SetUIActive(itemId != 0);
		base.GetTexture(1).SetUIActive(itemId != 0);
		base.GetItem(4).SetUIActive(itemId != 0);
		if (itemId != 0)
		{
			CSharpScript.Game.Module.Inventory.ItemConfig itemConfigData = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(itemId);
			QualityInfo? qualityConfig = ConfigBase<CSharpScript.Game.Module.Item.ItemConfig>.Instance.GetQualityConfig(itemConfigData.QualityId);
			if (qualityConfig == null)
			{
				return;
			}
			this.SetSpriteByPath(qualityConfig.Value.BackgroundSprite, base.GetSprite(2), false, null, null);
			base.SetItemIcon(base.GetTexture(1), itemId, null, null);
			this.SetLevelText();
		}
	}

	// Token: 0x06014CAB RID: 85163 RVA: 0x005C242C File Offset: 0x005C062C
	private void RefreshIcon()
	{
		base.GetTexture(1).SetUIActive(this.Id != 0);
		if (this.Id == 0)
		{
			return;
		}
		PhantomBattleData phantomItemDataByUniqueId = ControllerBase<PhantomBattleController>.Instance.GetPhantomItemDataByUniqueId(this.Id);
		if (phantomItemDataByUniqueId == null)
		{
			return;
		}
		base.SetItemIcon(base.GetTexture(1), phantomItemDataByUniqueId.GetConfigId(false), null, null);
	}

	// Token: 0x06014CAC RID: 85164 RVA: 0x005C248C File Offset: 0x005C068C
	private void RefreshQuality()
	{
		base.GetSprite(2).SetUIActive(this.Id != 0);
		if (this.Id == 0)
		{
			return;
		}
		PhantomBattleData phantomItemDataByUniqueId = ControllerBase<PhantomBattleController>.Instance.GetPhantomItemDataByUniqueId(this.Id);
		if (phantomItemDataByUniqueId == null)
		{
			return;
		}
		QualityInfo? qualityConfig = ConfigBase<CSharpScript.Game.Module.Item.ItemConfig>.Instance.GetQualityConfig(phantomItemDataByUniqueId.GetQuality());
		if (qualityConfig == null)
		{
			return;
		}
		this.SetSpriteByPath(qualityConfig.Value.BackgroundSprite, base.GetSprite(2), false, null, null);
	}

	// Token: 0x06014CAD RID: 85165 RVA: 0x005C250E File Offset: 0x005C070E
	private void RefreshLevel()
	{
		base.GetItem(4).SetUIActive(this.Id != 0);
		if (this.Id == 0)
		{
			return;
		}
		this.SetLevelText();
	}

	// Token: 0x06014CAE RID: 85166 RVA: 0x005C2534 File Offset: 0x005C0734
	private void SetLevelText()
	{
		RoleInstance curSelectMainRoleInstance = ModelBase<RoleModel>.Instance.GetCurSelectMainRoleInstance();
		if (curSelectMainRoleInstance == null)
		{
			return;
		}
		PhantomDataBase dataByIndex = curSelectMainRoleInstance.GetPhantomData().GetDataByIndex((int)this.Index);
		if (dataByIndex == null)
		{
			base.GetItem(4).SetUIActive(false);
			return;
		}
		base.GetText(5).SetText(dataByIndex.GetPhantomLevel().ToString(), true);
	}

	// Token: 0x06014CAF RID: 85167 RVA: 0x005C258E File Offset: 0x005C078E
	protected void OnClick()
	{
		if (this.ClickFunction != null)
		{
			this.ClickFunction((int)this.Index);
		}
	}

	// Token: 0x06014CB0 RID: 85168 RVA: 0x005C25AC File Offset: 0x005C07AC
	protected void OnClickSkillButton()
	{
		RoleInstance curSelectMainRoleInstance = ModelBase<RoleModel>.Instance.GetCurSelectMainRoleInstance();
		if (curSelectMainRoleInstance == null)
		{
			return;
		}
		PhantomDataBase dataByIndex = curSelectMainRoleInstance.GetPhantomData().GetDataByIndex((int)this.Index);
		if (dataByIndex == null)
		{
			return;
		}
		Dictionary<string, object> param = new Dictionary<string, object>
		{
			{
				"SkillInfoData",
				ESkillInfoType.SkillType
			},
			{
				"SkillId",
				this.Id
			},
			{
				"SkillLevel",
				dataByIndex.GetPhantomLevel()
			}
		};
		Singleton<UiManager>.Instance.OpenView(EUiViewName.PhantomBattleSkillInfoView, param, null);
	}

	// Token: 0x0400A016 RID: 40982
	[Nullable(1)]
	protected readonly Action<int> ClickFunction;

	// Token: 0x0400A017 RID: 40983
	protected int Id;

	// Token: 0x0400A018 RID: 40984
	protected readonly EPhantomItemIndex Index;

	// Token: 0x02008C38 RID: 35896
	private enum EPhantomItemDefine
	{
		// Token: 0x0402F3AF RID: 193455
		ItemButton,
		// Token: 0x0402F3B0 RID: 193456
		PhantomIconTexture,
		// Token: 0x0402F3B1 RID: 193457
		QualitySprite,
		// Token: 0x0402F3B2 RID: 193458
		EquipSkillItem,
		// Token: 0x0402F3B3 RID: 193459
		LevelItem,
		// Token: 0x0402F3B4 RID: 193460
		LevelText
	}
}
