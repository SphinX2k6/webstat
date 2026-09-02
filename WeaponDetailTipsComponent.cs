using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Common;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002D10 RID: 11536
[NullableContext(1)]
[Nullable(0)]
public class WeaponDetailTipsComponent : UiPanelBase
{
	// Token: 0x0601745F RID: 95327 RVA: 0x00673430 File Offset: 0x00671630
	protected unsafe override void OnRegisterComponent()
	{
		int num = 16;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIHorizontalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIVerticalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(13, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIText));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(3, new Action<EToggleState>(this.LockToggleClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06017460 RID: 95328 RVA: 0x006736AC File Offset: 0x006718AC
	private void LockToggleClick(EToggleState state)
	{
		bool bLock = state != EToggleState.ETT_Checked;
		int weaponIncId = this.GetWeaponIncId();
		if (weaponIncId <= 0)
		{
			return;
		}
		ControllerBase<InventoryController>.Instance.ItemLockRequest(weaponIncId, bLock);
	}

	// Token: 0x06017461 RID: 95329 RVA: 0x006736DC File Offset: 0x006718DC
	protected override void OnStart()
	{
		this.ReplaceButtonItem = new ButtonItem(base.GetItem(11));
		this.CultureButtonItem = new ButtonItem(base.GetItem(12));
		this.StarLayout = new GenericLayout<CSharpScript.Game.Module.RoleUi.StarItem, IStarItemData>(base.GetHorizontalLayout(4), new Func<CSharpScript.Game.Module.RoleUi.StarItem>(this.InitStarItem), null, false, true);
		this.AttributeLayout = new GenericLayout<AttributeItem, CSharpScript.Game.Module.Common.AttributeData>(base.GetVerticalLayout(5), new Func<AttributeItem>(this.InitAttributeItem), null, false, true);
		this.EquipItem = new CommonEquippedItem();
		this.EquipItem.CreateThenShowByActor(base.GetItem(10).GetOwner(), null);
	}

	// Token: 0x06017462 RID: 95330 RVA: 0x00673775 File Offset: 0x00671975
	public void SetCanShowEquip(bool canShowEquip = false)
	{
		this.CanShowEquip = canShowEquip;
		if (!this.CanShowEquip)
		{
			CommonEquippedItem equipItem = this.EquipItem;
			if (equipItem == null)
			{
				return;
			}
			equipItem.SetIconRootItemState(false);
		}
	}

	// Token: 0x06017463 RID: 95331 RVA: 0x00673797 File Offset: 0x00671997
	public void SetCanShowLock(bool canShowLock)
	{
		this.CanShowLock = canShowLock;
	}

	// Token: 0x06017464 RID: 95332 RVA: 0x006737A0 File Offset: 0x006719A0
	private void UpdateAttribute(WeaponConf weaponConfig)
	{
		WeaponAttributeParam[] array = new WeaponAttributeParam[]
		{
			new WeaponAttributeParam
			{
				PropId = weaponConfig.FirstPropId.Value,
				CurveId = weaponConfig.FirstCurve
			},
			new WeaponAttributeParam
			{
				PropId = weaponConfig.SecondPropId.Value,
				CurveId = weaponConfig.SecondCurve
			}
		};
		int level = this.WeaponData.GetLevel();
		int breachLevel = this.WeaponData.GetBreachLevel();
		List<CSharpScript.Game.Module.Common.AttributeData> list = new List<CSharpScript.Game.Module.Common.AttributeData>();
		foreach (WeaponAttributeParam weaponAttributeParam in array)
		{
			ConfigPropValue propId = weaponAttributeParam.PropId;
			float curveValue = ModelBase<WeaponModel>.Instance.GetCurveValue(weaponAttributeParam.CurveId, propId.Value, level, breachLevel);
			CSharpScript.Game.Module.Common.AttributeData item = new CSharpScript.Game.Module.Common.AttributeData
			{
				Id = propId.Id,
				IsRatio = propId.IsRatio,
				CurValue = curveValue,
				BgActive = new bool?(true)
			};
			list.Add(item);
		}
		this.AttributeLayout.RefreshByData(list, null, false);
	}

	// Token: 0x06017465 RID: 95333 RVA: 0x006738B4 File Offset: 0x00671AB4
	private void UpdateStar(int breachLevel, int maxLevel)
	{
		IStarItemData[] array = new IStarItemData[maxLevel];
		for (int i = 0; i < maxLevel; i++)
		{
			StarItemData starItemData = new StarItemData
			{
				StarOnActive = (i < breachLevel),
				StarOffActive = (i >= breachLevel),
				StarNextActive = false,
				StarLoopActive = false,
				PlayLoopSequence = false,
				PlayActivateSequence = false
			};
			array[i] = starItemData;
		}
		this.StarLayout.RefreshByData(array.ToList<IStarItemData>(), null, false);
	}

	// Token: 0x06017466 RID: 95334 RVA: 0x00673924 File Offset: 0x00671B24
	private CSharpScript.Game.Module.RoleUi.StarItem InitStarItem()
	{
		return new CSharpScript.Game.Module.RoleUi.StarItem();
	}

	// Token: 0x06017467 RID: 95335 RVA: 0x0067392B File Offset: 0x00671B2B
	private AttributeItem InitAttributeItem()
	{
		return new AttributeItem();
	}

	// Token: 0x06017468 RID: 95336 RVA: 0x00673934 File Offset: 0x00671B34
	private void UpdateWeaponIcon(int weaponType)
	{
		foreach (Mapping mapping in ConfigBase<MappingConfig>.Instance.GetWeaponConfList())
		{
			if (weaponType == mapping.Value)
			{
				this.SetSpriteByPath(mapping.Icon, base.GetSprite(0), false, null, null);
				this.SetSpriteByPath(mapping.Icon, base.GetSprite(13), false, null, null);
				break;
			}
		}
	}

	// Token: 0x06017469 RID: 95337 RVA: 0x006739CC File Offset: 0x00671BCC
	public void UpdateComponent(WeaponDataBase weaponData)
	{
		this.WeaponData = weaponData;
		WeaponConf value = weaponData.GetWeaponConfig().Value;
		int level = weaponData.GetLevel();
		int breachLevel = weaponData.GetBreachLevel();
		string weaponName = value.WeaponName;
		int weaponBreachMaxLevel = ModelBase<WeaponModel>.Instance.GetWeaponBreachMaxLevel(value.BreachId);
		WeaponBreach? breachConfig = weaponData.GetBreachConfig();
		int resonanceLevel = weaponData.GetResonanceLevel();
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), "Level_Text_New", new <>z__ReadOnlyArray<object>(new object[]
		{
			level,
			breachConfig.Value.LevelLimit
		}));
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(15), "Level_Text_New_Suffix", new <>z__ReadOnlySingleElementList<object>(breachConfig.Value.LevelLimit.ToString()));
		base.GetItem(14).SetUIActive(level >= breachConfig.Value.LevelLimit);
		FColor color = FColor.FromHex(ConfigBase<ItemConfig>.Instance.GetQualityConfig(value.QualityId).Value.DropColor);
		base.GetText(1).SetColor(color);
		base.GetText(1).ShowTextNew(weaponName);
		this.UpdateWeaponIcon(value.WeaponType);
		this.UpdateAttribute(value);
		this.UpdateStar(breachLevel, weaponBreachMaxLevel);
		Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(6), "WeaponResonanceItemLevelText", new <>z__ReadOnlySingleElementList<object>(resonanceLevel));
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(9), value.BgDescription, Array.Empty<object>());
		WeaponReson? weaponResonanceConfig = ConfigBase<WeaponConfig>.Instance.GetWeaponResonanceConfig(value.ResonId, resonanceLevel);
		if (weaponResonanceConfig != null)
		{
			base.GetText(7).SetUIActive(true);
			base.GetText(8).SetUIActive(true);
			base.GetText(7).SetText(ConfigBase<WeaponConfig>.Instance.GetWeaponResonanceDesc(weaponResonanceConfig.Value.Name), true);
			string[] weaponConfigDescParams = ModelBase<WeaponModel>.Instance.GetWeaponConfigDescParams(value, resonanceLevel);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(8), value.Desc, weaponConfigDescParams);
		}
		else
		{
			base.GetText(7).SetUIActive(false);
			base.GetText(8).SetUIActive(false);
		}
		WeaponInstance weaponInstance = weaponData as WeaponInstance;
		if (weaponInstance != null)
		{
			this.SetLockToggleActive(true);
			this.SetReplaceCultureActive(true);
			int value2 = weaponInstance.GetIncId().Value;
			this.ReplaceButtonItem.SetData(value2);
			this.CultureButtonItem.SetData(value2);
			this.UpdateWeaponLock(weaponInstance.IsLock());
			return;
		}
		this.SetLockToggleActive(false);
		this.SetReplaceCultureActive(false);
	}

	// Token: 0x0601746A RID: 95338 RVA: 0x00673C6C File Offset: 0x00671E6C
	public void UpdateWeaponLock(bool isLock)
	{
		EToggleState state = isLock ? EToggleState.ETT_UnChecked : EToggleState.ETT_Checked;
		base.GetExtendToggle(3).SetToggleState(state, false, false, false);
	}

	// Token: 0x0601746B RID: 95339 RVA: 0x00673C92 File Offset: 0x00671E92
	public void UpdateWeaponBreachRedDot(bool state)
	{
		this.CultureButtonItem.SetRedDotVisible(state);
	}

	// Token: 0x0601746C RID: 95340 RVA: 0x00673CA0 File Offset: 0x00671EA0
	public void SetReplaceFunction(TWeaponDetailsTipsFunctionWithNumber replaceFunction)
	{
		this.ReplaceButtonItem.SetFunction(new Action<int>(replaceFunction.Invoke));
	}

	// Token: 0x0601746D RID: 95341 RVA: 0x00673CB9 File Offset: 0x00671EB9
	public void SetReplaceEnableClick(bool bEnableClick)
	{
		this.ReplaceButtonItem.SetEnableClick(bEnableClick);
	}

	// Token: 0x0601746E RID: 95342 RVA: 0x00673CC7 File Offset: 0x00671EC7
	public void SetCultureFunction(TWeaponDetailsTipsFunctionWithNumber cultureFunction)
	{
		this.CultureButtonItem.SetFunction(new Action<int>(cultureFunction.Invoke));
	}

	// Token: 0x0601746F RID: 95343 RVA: 0x00673CE0 File Offset: 0x00671EE0
	public void UpdateEquip(int roleId)
	{
		if (!this.CanShowEquip)
		{
			return;
		}
		WeaponInstance weaponInstance = this.WeaponData as WeaponInstance;
		if (weaponInstance != null)
		{
			int roleId2 = weaponInstance.GetRoleId();
			if (roleId2 == 0)
			{
				this.EquipItem.SetCurrentEquippedState(false);
				this.EquipItem.SetIconRootItemState(false);
				this.ReplaceButtonItem.SetEnableClick(true);
				return;
			}
			this.ReplaceButtonItem.SetEnableClick(roleId2 != roleId);
			this.EquipItem.SetCurrentEquippedState(true);
			this.EquipItem.SetIconRootItemState(true);
			RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(roleId2, true);
			RoleSkinData roleSkinData = ModelBase<RoleSkinModel>.Instance.GetRoleSkinData(roleDataById.GetRoleSkinId());
			this.EquipItem.SetEquipIcon(roleSkinData.GetRoleSkinConfig().RoleHeadIcon);
			this.EquipItem.SetEquipText("WeaponTipsRoleText", new object[]
			{
				new TableTextArgNew(roleSkinData.GetName(), Array.Empty<object>())
			});
		}
	}

	// Token: 0x06017470 RID: 95344 RVA: 0x00673DC4 File Offset: 0x00671FC4
	public int GetWeaponIncId()
	{
		WeaponInstance weaponInstance = this.WeaponData as WeaponInstance;
		if (weaponInstance != null)
		{
			return weaponInstance.GetIncId().GetValueOrDefault();
		}
		return 0;
	}

	// Token: 0x06017471 RID: 95345 RVA: 0x00673DF0 File Offset: 0x00671FF0
	private void SetLockToggleActive(bool value)
	{
		base.GetExtendToggle(3).RootUIComp.Get().SetUIActive(value && this.CanShowLock);
	}

	// Token: 0x06017472 RID: 95346 RVA: 0x00673E22 File Offset: 0x00672022
	private void SetReplaceCultureActive(bool value)
	{
		this.ReplaceButtonItem.SetActive(value);
		this.CultureButtonItem.SetActive(value);
	}

	// Token: 0x06017473 RID: 95347 RVA: 0x00673E3C File Offset: 0x0067203C
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
	{
		if (configParams.Length < 1)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Guide;
			ELogAuthor author = ELogAuthor.TL;
			string message = "武器详情界面聚焦引导的额外参数配置错误";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("configParams", configParams);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		UUIItem guideUiItem = base.GetGuideUiItem(configParams[1]);
		if (guideUiItem == null)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Guide;
			ELogAuthor author2 = ELogAuthor.TL;
			string message2 = "武器详情界面聚焦引导的额外参数配置错误";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("configParams", configParams);
			instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			return null;
		}
		return new UUIItem[]
		{
			guideUiItem,
			guideUiItem
		};
	}

	// Token: 0x0400B2DC RID: 45788
	[Nullable(2)]
	protected WeaponDataBase WeaponData;

	// Token: 0x0400B2DD RID: 45789
	[Nullable(2)]
	protected ButtonItem ReplaceButtonItem;

	// Token: 0x0400B2DE RID: 45790
	[Nullable(2)]
	protected ButtonItem CultureButtonItem;

	// Token: 0x0400B2DF RID: 45791
	protected bool CanShowEquip;

	// Token: 0x0400B2E0 RID: 45792
	[Nullable(2)]
	private CommonEquippedItem EquipItem;

	// Token: 0x0400B2E1 RID: 45793
	protected bool CanShowLock = true;

	// Token: 0x0400B2E2 RID: 45794
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	protected GenericLayout<CSharpScript.Game.Module.RoleUi.StarItem, IStarItemData> StarLayout;

	// Token: 0x0400B2E3 RID: 45795
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	protected GenericLayout<AttributeItem, CSharpScript.Game.Module.Common.AttributeData> AttributeLayout;

	// Token: 0x02008FD7 RID: 36823
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0403045C RID: 197724
		WeaponSprite,
		// Token: 0x0403045D RID: 197725
		WeaponNameText,
		// Token: 0x0403045E RID: 197726
		LevelText,
		// Token: 0x0403045F RID: 197727
		LockToggle,
		// Token: 0x04030460 RID: 197728
		StarHorizontalLayout,
		// Token: 0x04030461 RID: 197729
		AttributeLayout,
		// Token: 0x04030462 RID: 197730
		ResonanceLevelText,
		// Token: 0x04030463 RID: 197731
		SkillNameText,
		// Token: 0x04030464 RID: 197732
		SkillDescText,
		// Token: 0x04030465 RID: 197733
		BgDescText,
		// Token: 0x04030466 RID: 197734
		EquipItem,
		// Token: 0x04030467 RID: 197735
		ReplaceItem,
		// Token: 0x04030468 RID: 197736
		CultureItem,
		// Token: 0x04030469 RID: 197737
		WeaponSpriteBg,
		// Token: 0x0403046A RID: 197738
		MaxItem,
		// Token: 0x0403046B RID: 197739
		MaxLevelText
	}
}
