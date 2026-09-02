using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Common.SmallItemGrid;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Kurotato;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Module.RoleUi.RoleDevelop;
using CSharpScript.Game.Module.Skin;
using Cysharp.Threading.Tasks;
using UnrealEngine;

// Token: 0x02001A12 RID: 6674
[NullableContext(2)]
[Nullable(0)]
public class SmallItemGrid : ItemGridBase
{
	// Token: 0x0600BF5E RID: 48990 RVA: 0x00329B44 File Offset: 0x00327D44
	protected unsafe override void OnRegisterComponent()
	{
		int num = 12;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUISprite));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600BF5F RID: 48991 RVA: 0x00329CFB File Offset: 0x00327EFB
	protected override void OnStart()
	{
		UUISprite sprite = base.GetSprite(8);
		if (sprite == null)
		{
			return;
		}
		sprite.SetUIActive(false);
	}

	// Token: 0x0600BF60 RID: 48992 RVA: 0x00329D0F File Offset: 0x00327F0F
	[NullableContext(1)]
	protected override UUIItem OnSetUnderTextAdditionItem()
	{
		return base.GetItem(9);
	}

	// Token: 0x0600BF61 RID: 48993 RVA: 0x00329D19 File Offset: 0x00327F19
	[NullableContext(1)]
	protected override UUIItem OnSetBottomAdditionItem()
	{
		return base.GetItem(5);
	}

	// Token: 0x0600BF62 RID: 48994 RVA: 0x00329D22 File Offset: 0x00327F22
	[NullableContext(1)]
	protected override UUIItem OnSetTopAdditionItem()
	{
		return base.GetItem(6);
	}

	// Token: 0x0600BF63 RID: 48995 RVA: 0x00329D2B File Offset: 0x00327F2B
	[NullableContext(1)]
	public override UUIExtendToggle GetItemGridExtendToggle()
	{
		return base.GetExtendToggle(7);
	}

	// Token: 0x0600BF64 RID: 48996 RVA: 0x00329D34 File Offset: 0x00327F34
	[NullableContext(1)]
	public void Apply<[Nullable(0)] T>(T parameters) where T : IMediumItemGridBase
	{
		base.ClearVisibleComponent();
		base.ClearComponentList();
		ESmallItemGridType type = parameters.Type;
		bool flag = type - ESmallItemGridType.Character <= 2;
		bool flag2;
		if (flag)
		{
			SmallItemGridBase smallItemGridBase = parameters as SmallItemGridBase;
			if (smallItemGridBase != null)
			{
				flag2 = smallItemGridBase.IsDoubleRewardVisible.GetValueOrDefault();
				goto IL_46;
			}
		}
		flag2 = false;
		IL_46:
		if (!flag2)
		{
			this.SetDoubleRewardVisible(false);
		}
		if (parameters.Type == ESmallItemGridType.Empty)
		{
			this.ApplyEmptySmallItemGrid(parameters as EmptySmallItemGrid);
		}
		if (parameters.Type == ESmallItemGridType.Prop)
		{
			this.ApplyPropSmallItemGrid(parameters as PropSmallItemGrid);
		}
		if (parameters.Type == ESmallItemGridType.Phantom)
		{
			this.ApplyPhantomSmallItemGrid(parameters as PhantomSmallItemGrid);
		}
		if (parameters.Type == ESmallItemGridType.Character)
		{
			this.ApplyCharacterSmallItemGrid(parameters as CharacterSmallItemGrid);
		}
		if (parameters.Type == ESmallItemGridType.ForecastCharacter)
		{
			this.ApplyForecastCharacterSmallItemGrid(parameters as ForecastCharacterSmallItemGrid);
		}
		if (parameters.Type == ESmallItemGridType.CharacterOrnament)
		{
			this.ApplyCharacterOrnamentSmallItemGrid(parameters as CharacterOrnamentSmallItemGrid);
		}
		if (parameters.Type == ESmallItemGridType.Kurotato)
		{
			this.ApplyKurotatoWeaponSmallItemGrid(parameters as KurotatoSmallItemGrid);
		}
		base.RefreshComponentVisible();
		base.RefreshComponentHierarchyIndex();
	}

	// Token: 0x0600BF65 RID: 48997 RVA: 0x00329E84 File Offset: 0x00328084
	public void ApplyEmptySmallItemGrid(EmptySmallItemGrid parameters)
	{
		this.SetEmptySlotVisible(true);
		this.SetTexture(null);
		this.SetSkinItemQuality(null);
		this.SetBottomTextVisible(false);
		this.SetQuality(null);
		base.SetExtendToggleEnable(false, false);
		this.SetElement(null);
		this.SetDirectionalFusionComponent(null);
	}

	// Token: 0x0600BF66 RID: 48998 RVA: 0x00329EEC File Offset: 0x003280EC
	public void ApplyEmptyWithoutAddSmallItemGrid(EmptySmallItemGrid parameters)
	{
		base.ClearVisibleComponent();
		base.ClearComponentList();
		this.SetDoubleRewardVisible(false);
		this.SetTexture(null);
		this.SetSkinItemQuality(null);
		this.SetBottomTextVisible(false);
		this.SetQuality(null);
		base.SetExtendToggleEnable(false, false);
		this.SetElement(null);
		base.RefreshComponentVisible();
		base.RefreshComponentHierarchyIndex();
	}

	// Token: 0x0600BF67 RID: 48999 RVA: 0x00329F5C File Offset: 0x0032815C
	public void ApplyPropSmallItemGrid(PropSmallItemGrid parameters)
	{
		if (parameters == null)
		{
			return;
		}
		bool valueOrDefault = parameters.IsLockVisible.GetValueOrDefault();
		bool valueOrDefault2 = parameters.IsReceivableVisible.GetValueOrDefault();
		bool valueOrDefault3 = parameters.IsLockVisibleBlack.GetValueOrDefault();
		bool valueOrDefault4 = parameters.IsStarReceivableVisible.GetValueOrDefault();
		bool valueOrDefault5 = parameters.IsReceivedVisible.GetValueOrDefault();
		bool? isNewVisible = parameters.IsNewVisible;
		bool? isNotFoundVisible = parameters.IsNotFoundVisible;
		int? coolDownTime = parameters.CoolDownTime;
		float? coolDown = (coolDownTime != null) ? new float?((float)coolDownTime.GetValueOrDefault()) : null;
		bool? isDisable = parameters.IsDisable;
		bool? isBirthdayEffectVisible = parameters.IsBirthdayEffectVisible;
		bool? isOrnamentConflictVisible = parameters.IsOrnamentConflictVisible;
		bool valueOrDefault6 = parameters.IsDoubleRewardVisible.GetValueOrDefault();
		this.SetIsDisable(isDisable);
		this.SetLockVisible(valueOrDefault);
		this.SetLockBlackVisible(valueOrDefault3);
		this.SetReceivableVisible(valueOrDefault2);
		this.SetReceivedVisible(valueOrDefault5);
		this.SetNewFlagVisible(isNewVisible);
		this.SetTimeFlagVisible(parameters.IsTimeFlagVisible);
		this.SetNotFoundVisible(isNotFoundVisible);
		this.SetCoolDown(coolDown, null);
		this.SetRedDotVisible(parameters.IsRedDotVisible);
		this.SetBirthdayEffect(isBirthdayEffectVisible);
		this.ApplyPropBaseDisplay(parameters);
		this.SetRoleDevelopStateTag(parameters.RoleDevelopStateTagType);
		this.SetStarReceivableVisible(valueOrDefault4);
		this.SetOrnamentConflictVisible(isOrnamentConflictVisible);
		this.SetDoubleRewardVisible(valueOrDefault6);
	}

	// Token: 0x0600BF68 RID: 49000 RVA: 0x0032A09C File Offset: 0x0032829C
	[NullableContext(1)]
	public void ApplyPhantomSmallItemGrid(PhantomSmallItemGrid parameters)
	{
		if (parameters == null)
		{
			return;
		}
		bool valueOrDefault = parameters.IsLockVisible.GetValueOrDefault();
		bool valueOrDefault2 = parameters.IsLockVisibleBlack.GetValueOrDefault();
		bool valueOrDefault3 = parameters.IsReceivableVisible.GetValueOrDefault();
		bool valueOrDefault4 = parameters.IsReceivedVisible.GetValueOrDefault();
		bool? isNewVisible = parameters.IsNewVisible;
		bool? isNotFoundVisible = parameters.IsNotFoundVisible;
		bool valueOrDefault5 = parameters.IsSelectedFlag.GetValueOrDefault();
		int? visionRoleHeadInfo = parameters.VisionRoleHeadInfo;
		int? fetterGroupId = parameters.FetterGroupId;
		this.SetLockVisible(valueOrDefault);
		this.SetLockAndDepracte(parameters.IsPhantomLock, parameters.IsPhantomDeprecate);
		this.SetLockBlackVisible(valueOrDefault2);
		this.SetReceivableVisible(valueOrDefault3);
		this.SetReceivedVisible(valueOrDefault4);
		this.SetNewFlagVisible(isNewVisible);
		this.SetNotFoundVisible(isNotFoundVisible);
		this.SetSelectedFlagVisible(valueOrDefault5);
		this.SetVisionRoleHead(visionRoleHeadInfo);
		this.SetVisionFetterGroup(fetterGroupId);
		this.SetRedDotVisible(parameters.IsRedDotVisible);
		this.ApplyPhantomBaseDisplay(parameters);
		this.SetDoubleRewardVisible(parameters.IsDoubleRewardVisible.GetValueOrDefault());
		this.SetMultiPlayerVisible(parameters.MultiPlayer);
	}

	// Token: 0x0600BF69 RID: 49001 RVA: 0x0032A190 File Offset: 0x00328390
	public void ApplyCharacterSmallItemGrid(CharacterSmallItemGrid parameters)
	{
		if (parameters == null)
		{
			return;
		}
		bool valueOrDefault = parameters.IsLockVisible.GetValueOrDefault();
		bool valueOrDefault2 = parameters.IsReceivableVisible.GetValueOrDefault();
		bool valueOrDefault3 = parameters.IsReceivedVisible.GetValueOrDefault();
		bool valueOrDefault4 = parameters.IsSelectedFlag.GetValueOrDefault();
		bool valueOrDefault5 = parameters.IsCookUp.GetValueOrDefault();
		bool valueOrDefault6 = parameters.IsBlack.GetValueOrDefault();
		this.SetIsBlack(valueOrDefault6);
		this.SetLockVisible(valueOrDefault);
		this.SetReceivableVisible(valueOrDefault2);
		this.SetReceivedVisible(valueOrDefault3);
		this.SetSelectedFlagVisible(valueOrDefault4);
		this.SetCookUpVisible(valueOrDefault5);
		this.SetElement(parameters.ElementId);
		this.SetRedDotVisible(parameters.IsRedDotVisible);
		this.ApplyCharacterBaseDisplay(parameters);
		this.SetDoubleRewardVisible(parameters.IsDoubleRewardVisible.GetValueOrDefault());
	}

	// Token: 0x0600BF6A RID: 49002 RVA: 0x0032A247 File Offset: 0x00328447
	public void ApplyForecastCharacterSmallItemGrid(ForecastCharacterSmallItemGrid parameters)
	{
		if (parameters == null)
		{
			return;
		}
		this.ApplyForecastCharacterBaseDisplay(parameters);
	}

	// Token: 0x0600BF6B RID: 49003 RVA: 0x0032A254 File Offset: 0x00328454
	[NullableContext(1)]
	public void ApplyKurotatoWeaponSmallItemGrid(KurotatoSmallItemGrid param)
	{
		this.SetRedDotVisible(param.IsRedDotVisible);
		this.SetReceivedVisible(param.IsReceivedVisible.GetValueOrDefault());
		if (param.CardType == EKurotatoCardType.Weapon)
		{
			KurotatoWeapon? config = ConfigKurotatoWeaponById.GetConfig(param.Id, true);
			if (config != null)
			{
				KurotatoWeaponGroup? config2 = ConfigKurotatoWeaponGroupById.GetConfig(config.Value.GroupId, true);
				if (config2 != null && !string.IsNullOrEmpty(config2.Value.Icon))
				{
					this.SetTextureByIconPath(config2.Value.Icon);
				}
			}
			this.SetSkinQuality(null);
		}
		else
		{
			KurotatoItem? config3 = ConfigKurotatoItemById.GetConfig(param.Id, true);
			if (config3 != null && !string.IsNullOrEmpty(config3.Value.Icon))
			{
				this.SetTextureByIconPath(config3.Value.Icon);
			}
			this.SetSkinQuality(null);
		}
		this.SetKurotatoItemQuality(param);
		this.RefreshBottomText(param);
		this.SetRightTopValueInfo(param.RightTopValue);
		base.SetExtendToggleEnable(true, false);
	}

	// Token: 0x0600BF6C RID: 49004 RVA: 0x0032A370 File Offset: 0x00328570
	[NullableContext(1)]
	private void SetKurotatoItemQuality(KurotatoSmallItemGrid param)
	{
		int id = param.Id;
		UUISprite sprite = base.GetSprite(0);
		if (this.QualityItemConfigId == id)
		{
			sprite.SetUIActive(true);
			return;
		}
		string mediumItemGridQualitySpritePath = ConfigKurotatoQualityById.GetConfig(param.QualityId.Value, true).Value.MediumItemGridQualitySpritePath;
		this.SetSpriteByPath(mediumItemGridQualitySpritePath, sprite, true, null, null);
		sprite.SetUIActive(true);
		this.QualityItemConfigId = id;
	}

	// Token: 0x0600BF6D RID: 49005 RVA: 0x0032A3E4 File Offset: 0x003285E4
	public void ApplyCharacterOrnamentSmallItemGrid(CharacterOrnamentSmallItemGrid parameters)
	{
		if (parameters == null)
		{
			return;
		}
		bool valueOrDefault = parameters.IsLockVisibleBlack.GetValueOrDefault();
		bool valueOrDefault2 = parameters.IsReceivableVisible.GetValueOrDefault();
		bool valueOrDefault3 = parameters.IsReceivedVisible.GetValueOrDefault();
		bool valueOrDefault4 = parameters.IsSelectedFlag.GetValueOrDefault();
		bool valueOrDefault5 = parameters.IsOrnamentConflictVisible.GetValueOrDefault();
		this.SetLockBlackVisible(valueOrDefault);
		this.SetReceivableVisible(valueOrDefault2);
		this.SetReceivedVisible(valueOrDefault3);
		this.SetSelectedFlagVisible(valueOrDefault4);
		this.SetOrnamentConflictVisible(new bool?(valueOrDefault5));
		this.SetRedDotVisible(parameters.IsRedDotVisible);
		this.ApplyCharacterOrnamentBaseDisplay(parameters);
	}

	// Token: 0x0600BF6E RID: 49006 RVA: 0x0032A470 File Offset: 0x00328670
	private void ApplyPropBaseDisplay(PropSmallItemGrid parameters)
	{
		if (parameters == null)
		{
			return;
		}
		int? itemConfigId = parameters.ItemConfigId;
		this.Data = parameters.Data;
		UUITexture texture = base.GetTexture(1);
		InventoryDefine.EItemDataType? eitemDataType = new InventoryDefine.EItemDataType?(ConfigBase<InventoryConfig>.Instance.GetItemDataTypeByConfigId(new int?(parameters.ItemConfigId.GetValueOrDefault())));
		if (parameters.IsIconHide != null && itemConfigId.GetValueOrDefault() > 0)
		{
			if (texture != null)
			{
				texture.SetUIActive(false);
			}
		}
		else if (!string.IsNullOrEmpty(parameters.IconPath))
		{
			base.SetTextureByPath(parameters.IconPath, texture, null, null);
		}
		else if (eitemDataType.GetValueOrDefault() == InventoryDefine.EItemDataType.DangoAbyssItem)
		{
			this.SetDangoItemTexture(itemConfigId.Value);
		}
		else if (eitemDataType.GetValueOrDefault() == InventoryDefine.EItemDataType.HonamiStoryItem)
		{
			this.SetHonamiStoryItemTexture(itemConfigId.Value);
		}
		else if (eitemDataType.GetValueOrDefault() == InventoryDefine.EItemDataType.MotorStickerItem)
		{
			this.SetMotorStickerTexture(itemConfigId.Value);
		}
		else
		{
			this.SetTexture(itemConfigId);
		}
		this.SetItemQuality(parameters);
		this.SetIconSprite(parameters.SpriteIconPath);
		this.RefreshBottomText(parameters);
		this.RefreshTopRightText(parameters);
		base.SetExtendToggleEnable(true, false);
		this.RefreshSkin(parameters, itemConfigId);
	}

	// Token: 0x0600BF6F RID: 49007 RVA: 0x0032A58F File Offset: 0x0032878F
	public void SetElement(int? elementId)
	{
		base.RefreshComponent(typeof(SmallItemGridElementComponent), new bool?(elementId != null), elementId);
	}

	// Token: 0x0600BF70 RID: 49008 RVA: 0x0032A5B4 File Offset: 0x003287B4
	public void SetDirectionalFusionComponent(int? phantomFetterId)
	{
		base.RefreshComponent(typeof(SmallItemGridDirectionalFusionComponent), new bool?(phantomFetterId != null), phantomFetterId);
	}

	// Token: 0x0600BF71 RID: 49009 RVA: 0x0032A5DC File Offset: 0x003287DC
	[NullableContext(1)]
	private void ApplyPhantomBaseDisplay(PhantomSmallItemGrid parameters)
	{
		if (parameters == null)
		{
			return;
		}
		int? itemConfigId = parameters.ItemConfigId;
		int? monsterId = parameters.MonsterId;
		int? phantomId = parameters.PhantomId;
		string qualityIconResourceId = parameters.QualityIconResourceId;
		bool? isQualityHidden = parameters.IsQualityHidden;
		bool? iconHidden = parameters.IconHidden;
		this.Data = parameters.Data;
		if (iconHidden.GetValueOrDefault())
		{
			UUITexture texture = base.GetTexture(1);
			if (texture != null)
			{
				texture.SetUIActive(false);
			}
		}
		else if (monsterId != null)
		{
			this.SetMonsterTexture(monsterId.Value);
		}
		else if (phantomId != null)
		{
			this.SetPhantomTexture(phantomId.Value);
		}
		else
		{
			this.SetTexture(itemConfigId);
		}
		UUISprite sprite = base.GetSprite(0);
		if (isQualityHidden.GetValueOrDefault())
		{
			sprite.SetUIActive(false);
		}
		else if (qualityIconResourceId != null)
		{
			this.SetQualityByResourceId(qualityIconResourceId);
			this.QualityItemConfigId = parameters.ItemConfigId.GetValueOrDefault();
		}
		else
		{
			this.SetQuality(itemConfigId);
		}
		this.RefreshBottomText(parameters);
		this.RefreshTopRightText(parameters);
		base.SetExtendToggleEnable(true, false);
	}

	// Token: 0x0600BF72 RID: 49010 RVA: 0x0032A6D0 File Offset: 0x003288D0
	private void ApplyCharacterBaseDisplay(SmallItemGridBase parameters)
	{
		if (parameters == null)
		{
			return;
		}
		int num = parameters.ItemConfigId.Value;
		this.Data = parameters.Data;
		UUITexture texture = base.GetTexture(1);
		if (num > 10000)
		{
			num = ConfigBase<RoleConfig>.Instance.GetTrialRoleConfig(num).Value.ParentId;
		}
		int? skinId = parameters.SkinId;
		if (skinId != null)
		{
			string roleHeadIconLarge = ConfigBase<SkinConfig>.Instance.GetRoleSkinConfig(skinId.Value).Value.RoleHeadIconLarge;
			base.SetRoleSkinIcon(roleHeadIconLarge, texture, skinId.Value, null, null);
		}
		else
		{
			string roleHeadIconBig = ConfigBase<RoleConfig>.Instance.GetRoleConfig(num).Value.RoleHeadIconBig;
			base.SetRoleIcon(roleHeadIconBig, texture, num, null, null);
		}
		texture.SetUIActive(true);
		this.SetNormalItemQualityInternal(parameters.IsQualityHidden, parameters.QualityId, new int?(num), parameters.QualityIcon, parameters.QualityType);
		this.RefreshBottomText(parameters);
		this.RefreshTopRightText(parameters);
		base.SetExtendToggleEnable(true, false);
	}

	// Token: 0x0600BF73 RID: 49011 RVA: 0x0032A7F0 File Offset: 0x003289F0
	private void ApplyForecastCharacterBaseDisplay(ForecastCharacterSmallItemGrid parameters)
	{
		if (parameters == null)
		{
			return;
		}
		this.Data = parameters.Data;
		IRoleDevProsProjectConfig roleDevProsProjectConfig = ConfigBase<RoleDevConfig>.Instance.GetRoleDevProsProjectConfig(parameters.RoleId.Value);
		int elementId = roleDevProsProjectConfig.ElementId;
		string roleHeadIcon = roleDevProsProjectConfig.RoleHeadIcon;
		this.SetTextureByIconPath(roleHeadIcon);
		this.SetBottomTextId("Text_LevelShow_Text", new object[]
		{
			1
		});
		this.SetElement(new int?(elementId));
		base.SetExtendToggleEnable(true, false);
	}

	// Token: 0x0600BF74 RID: 49012 RVA: 0x0032A864 File Offset: 0x00328A64
	private void ApplyCharacterOrnamentBaseDisplay(CharacterOrnamentSmallItemGrid parameters)
	{
		if (parameters == null)
		{
			return;
		}
		this.Data = parameters.Data;
		int value = parameters.ItemConfigId.Value;
		this.SetTexture(new int?(value));
		this.SetItemQuality(parameters);
		this.RefreshBottomText(parameters);
		this.RefreshTopRightText(parameters);
		base.SetExtendToggleEnable(true, false);
		this.RefreshSkin(parameters, new int?(value));
	}

	// Token: 0x0600BF75 RID: 49013 RVA: 0x0032A8C3 File Offset: 0x00328AC3
	public void SetLockVisible(bool bVisible)
	{
		base.RefreshComponent(typeof(SmallItemGridLockComponent), new bool?(bVisible), bVisible);
	}

	// Token: 0x0600BF76 RID: 49014 RVA: 0x0032A8E2 File Offset: 0x00328AE2
	public void SetArrowVisible(bool bVisible)
	{
		base.RefreshComponent(typeof(SmallItemGridArrowComponent), new bool?(bVisible), bVisible);
	}

	// Token: 0x0600BF77 RID: 49015 RVA: 0x0032A904 File Offset: 0x00328B04
	public void SetLockAndDepracte(bool? isLock, bool? isDeprecate)
	{
		ISmallItemGridLockAndDeprecate @params = new SmallItemGridLockAndDeprecate
		{
			IsLock = isLock,
			IsDeprecate = isDeprecate
		};
		bool value = isLock.GetValueOrDefault() || isDeprecate.GetValueOrDefault();
		base.RefreshComponent(typeof(SmallItemGridLockAndDeprecateComponent), new bool?(value), @params);
	}

	// Token: 0x0600BF78 RID: 49016 RVA: 0x0032A951 File Offset: 0x00328B51
	public void SetLockBlackVisible(bool bVisible)
	{
		base.RefreshComponent(typeof(SmallItemGridLockBlackComponent), new bool?(bVisible), bVisible);
	}

	// Token: 0x0600BF79 RID: 49017 RVA: 0x0032A970 File Offset: 0x00328B70
	public void SetLockBlackBigVisible(bool bVisible)
	{
		base.RefreshComponent(typeof(SmallItemGridLockBlackBigComponent), new bool?(bVisible), bVisible);
	}

	// Token: 0x0600BF7A RID: 49018 RVA: 0x0032A98F File Offset: 0x00328B8F
	public void SetCurrentEquipmentVisible(bool bVisible)
	{
		base.RefreshComponent(typeof(SmallItemGridCurrentEquipmentComponent), new bool?(bVisible), bVisible);
	}

	// Token: 0x0600BF7B RID: 49019 RVA: 0x0032A9AE File Offset: 0x00328BAE
	public void SetReceivableVisible(bool bVisible)
	{
		base.RefreshComponent(typeof(SmallItemGridReceivableComponent), new bool?(bVisible), bVisible);
	}

	// Token: 0x0600BF7C RID: 49020 RVA: 0x0032A9CD File Offset: 0x00328BCD
	public void SetStarReceivableVisible(bool bVisible)
	{
		base.RefreshComponent(typeof(SmallItemGridStarReceivableComponent), new bool?(bVisible), bVisible);
	}

	// Token: 0x0600BF7D RID: 49021 RVA: 0x0032A9EC File Offset: 0x00328BEC
	public void SetPreviewVisible(bool bVisible)
	{
		base.RefreshComponent(typeof(SmallItemGridPreviewComponent), new bool?(bVisible), bVisible);
	}

	// Token: 0x0600BF7E RID: 49022 RVA: 0x0032AA0B File Offset: 0x00328C0B
	public void SetReceivedVisible(bool bVisible)
	{
		base.RefreshComponent(typeof(SmallItemGridReceivedComponent), new bool?(bVisible), bVisible);
	}

	// Token: 0x0600BF7F RID: 49023 RVA: 0x0032AA2C File Offset: 0x00328C2C
	[NullableContext(1)]
	public void SetReceivedColor(string hexColor)
	{
		SmallItemGridReceivedComponent smallItemGridReceivedComponent = base.RefreshComponent(typeof(SmallItemGridReceivedComponent), new bool?(false), true) as SmallItemGridReceivedComponent;
		if (smallItemGridReceivedComponent == null)
		{
			return;
		}
		smallItemGridReceivedComponent.GetAsync().ContinueWith(delegate(ItemGridComponent component)
		{
			SmallItemGridReceivedComponent smallItemGridReceivedComponent2 = component as SmallItemGridReceivedComponent;
			if (smallItemGridReceivedComponent2 == null)
			{
				return;
			}
			smallItemGridReceivedComponent2.SetSpriteColor(hexColor);
		});
	}

	// Token: 0x0600BF80 RID: 49024 RVA: 0x0032AA84 File Offset: 0x00328C84
	public void SetSelectedFlagVisible(bool bVisible)
	{
		base.RefreshComponent(typeof(SmallItemGridSelectedFlagComponent), new bool?(bVisible), bVisible);
	}

	// Token: 0x0600BF81 RID: 49025 RVA: 0x0032AAA3 File Offset: 0x00328CA3
	public void SetSelectVisible(bool bVisible)
	{
		base.RefreshComponent(typeof(SmallItemGridSelectComponent), new bool?(bVisible), bVisible);
	}

	// Token: 0x0600BF82 RID: 49026 RVA: 0x0032AAC2 File Offset: 0x00328CC2
	private void SetCookUpVisible(bool bVisible)
	{
		base.RefreshComponent(typeof(SmallItemGridCookUpComponent), new bool?(bVisible), bVisible);
	}

	// Token: 0x0600BF83 RID: 49027 RVA: 0x0032AAE1 File Offset: 0x00328CE1
	public void SetFirstRewardVisible(bool bVisible)
	{
		base.RefreshComponent(typeof(SmallItemGridFirstRewardComponent), new bool?(bVisible), bVisible);
	}

	// Token: 0x0600BF84 RID: 49028 RVA: 0x0032AB00 File Offset: 0x00328D00
	public void SetExchangeRewardVisible(bool bVisible)
	{
		base.RefreshComponent(typeof(SmallItemGridExchangeRewardComponent), new bool?(bVisible), bVisible);
	}

	// Token: 0x0600BF85 RID: 49029 RVA: 0x0032AB1F File Offset: 0x00328D1F
	public void SetDoubleRewardVisible(bool bVisible)
	{
		base.RefreshComponent(typeof(SmallItemGridDoubleRewardComponent), new bool?(bVisible), bVisible);
	}

	// Token: 0x0600BF86 RID: 49030 RVA: 0x0032AB40 File Offset: 0x00328D40
	[NullableContext(1)]
	protected void SetTextureByIconPath(string iconPath)
	{
		UUITexture texture = base.GetTexture(1);
		if (texture != null)
		{
			texture.SetUIActive(true);
		}
		base.SetTextureByPath(iconPath, texture, null, null);
	}

	// Token: 0x0600BF87 RID: 49031 RVA: 0x0032AB74 File Offset: 0x00328D74
	private void SetTexture(int? itemConfigId)
	{
		UUITexture texture = base.GetTexture(1);
		if (itemConfigId == null)
		{
			texture.SetUIActive(false);
			return;
		}
		base.SetItemIcon(texture, itemConfigId.Value, null, null);
		texture.SetUIActive(true);
	}

	// Token: 0x0600BF88 RID: 49032 RVA: 0x0032ABBC File Offset: 0x00328DBC
	private void SetMotorStickerTexture(int itemId)
	{
		UUITexture texture = base.GetTexture(1);
		MotorSticker? motorSticker;
		string text = (ConfigBase<MotorDiyConfig>.Instance.GetMotorStickerConfig(itemId) != null) ? motorSticker.GetValueOrDefault().Icon : null;
		if (string.IsNullOrEmpty(text))
		{
			texture.SetUIActive(false);
			return;
		}
		base.SetTextureByPath(text, texture, null, null);
		texture.SetUIActive(true);
	}

	// Token: 0x0600BF89 RID: 49033 RVA: 0x0032AC24 File Offset: 0x00328E24
	private void SetDangoItemTexture(int itemId)
	{
		IDangoPluginIconInfo dangoPluginIcon = new DangoPluginIconInfo
		{
			PluginItemId = itemId
		};
		this.SetDangoPluginIcon(dangoPluginIcon);
		UUITexture texture = base.GetTexture(1);
		if (texture == null)
		{
			return;
		}
		texture.SetUIActive(false);
	}

	// Token: 0x0600BF8A RID: 49034 RVA: 0x0032AC58 File Offset: 0x00328E58
	private void SetHonamiStoryItemTexture(int itemId)
	{
		UUITexture texture = base.GetTexture(1);
		HonamiStoryItem? honamiStoryItem = ConfigBase<HonamiStoryConfig>.Instance.GetHonamiStoryItem(itemId);
		if (honamiStoryItem == null || honamiStoryItem == null)
		{
			texture.SetUIActive(false);
			return;
		}
		base.SetTextureByPath(honamiStoryItem.Value.IconMiddle, texture, null, null);
		texture.SetUIActive(true);
	}

	// Token: 0x0600BF8B RID: 49035 RVA: 0x0032ACBC File Offset: 0x00328EBC
	private void SetMonsterTexture(int monsterId)
	{
		UUITexture texture = base.GetTexture(1);
		string monsterIcon = ConfigBase<MonsterInfoConfig>.Instance.GetMonsterIcon(monsterId);
		base.SetTextureByPath(monsterIcon, texture, null, null);
		texture.SetUIActive(true);
	}

	// Token: 0x0600BF8C RID: 49036 RVA: 0x0032ACF8 File Offset: 0x00328EF8
	private void SetPhantomTexture(int phantomId)
	{
		UUITexture texture = base.GetTexture(1);
		base.SetTextureByPath(ConfigBase<PhantomBattleConfig>.Instance.GetPhantomItemById(phantomId).Value.IconMiddle, texture, null, null);
		texture.SetUIActive(true);
	}

	// Token: 0x0600BF8D RID: 49037 RVA: 0x0032AD40 File Offset: 0x00328F40
	[NullableContext(1)]
	public void RefreshSkin(SmallItemGridBase parameters, int? itemId)
	{
		ISmallItemGridSkinComponentParams smallItemGridSkinComponentParams = new SmallItemGridSkinComponentParams
		{
			SkinId = itemId,
			BottomText = parameters.BottomText
		};
		bool flag = false;
		if (itemId != null)
		{
			InventoryDefine.EItemDataType itemDataTypeByConfigId = ConfigBase<InventoryConfig>.Instance.GetItemDataTypeByConfigId(new int?(itemId.Value));
			flag = (itemDataTypeByConfigId == InventoryDefine.EItemDataType.WeaponSkinItem || itemDataTypeByConfigId == InventoryDefine.EItemDataType.RoleSkinItem || itemDataTypeByConfigId == InventoryDefine.EItemDataType.FlySkinItem || itemDataTypeByConfigId == InventoryDefine.EItemDataType.CalabashSkinItem || itemDataTypeByConfigId == InventoryDefine.EItemDataType.OrnamentItem);
		}
		if (flag)
		{
			this.SetBottomTextVisible(false);
		}
		base.RefreshComponent(typeof(SmallItemGridSkinComponent), new bool?(flag), flag ? smallItemGridSkinComponentParams : null);
	}

	// Token: 0x0600BF8E RID: 49038 RVA: 0x0032ADD0 File Offset: 0x00328FD0
	public void SetIconSprite(string iconSpritePath)
	{
		UUISprite sprite = base.GetSprite(11);
		if (string.IsNullOrEmpty(iconSpritePath))
		{
			if (sprite != null)
			{
				sprite.SetUIActive(false);
			}
			return;
		}
		this.SetSpriteByPath(iconSpritePath, sprite, false, null, null);
		if (sprite != null)
		{
			sprite.SetUIActive(true);
		}
	}

	// Token: 0x0600BF8F RID: 49039 RVA: 0x0032AE18 File Offset: 0x00329018
	public void RefreshSkinByDefault(int qualityId, InventoryDefine.EItemDataType itemType)
	{
		ISmallItemGridSkinComponentParams @params = new SmallItemGridSkinComponentParams
		{
			QualityId = new int?(qualityId)
		};
		if (itemType == InventoryDefine.EItemDataType.WeaponSkinItem || itemType == InventoryDefine.EItemDataType.RoleSkinItem || itemType == InventoryDefine.EItemDataType.FlySkinItem || itemType == InventoryDefine.EItemDataType.CalabashSkinItem || itemType == InventoryDefine.EItemDataType.OrnamentItem)
		{
			this.SetBottomTextVisible(false);
		}
		base.RefreshComponent(typeof(SmallItemGridSkinComponent), new bool?(true), @params);
	}

	// Token: 0x0600BF90 RID: 49040 RVA: 0x0032AE70 File Offset: 0x00329070
	[NullableContext(1)]
	public void SetItemQuality(SmallItemGridBase parameters)
	{
		if (parameters.ItemConfigId == null)
		{
			this.SetSkinQuality(null);
			this.SetNormalItemQuality(parameters);
			return;
		}
		InventoryDefine.EItemDataType itemDataTypeByConfigId = ConfigBase<InventoryConfig>.Instance.GetItemDataTypeByConfigId(new int?(parameters.ItemConfigId.Value));
		if (itemDataTypeByConfigId == InventoryDefine.EItemDataType.WeaponSkinItem || itemDataTypeByConfigId == InventoryDefine.EItemDataType.RoleSkinItem || itemDataTypeByConfigId == InventoryDefine.EItemDataType.FlySkinItem || itemDataTypeByConfigId == InventoryDefine.EItemDataType.CalabashSkinItem)
		{
			this.SetSkinQualityByParameters(parameters);
			return;
		}
		if (itemDataTypeByConfigId == InventoryDefine.EItemDataType.DangoAbyssItem)
		{
			this.SetDangoAbyssItemQuality(parameters);
			return;
		}
		if (itemDataTypeByConfigId == InventoryDefine.EItemDataType.HonamiStoryItem)
		{
			this.SetHonamiStoryItemQuality(parameters);
			return;
		}
		if (itemDataTypeByConfigId == InventoryDefine.EItemDataType.PinballRoleItem || itemDataTypeByConfigId == InventoryDefine.EItemDataType.PinballWeaponItem)
		{
			this.SetPinballItemQuality(parameters);
			return;
		}
		this.SetSkinQuality(null);
		this.SetNormalItemQuality(parameters);
	}

	// Token: 0x0600BF91 RID: 49041 RVA: 0x0032AF1C File Offset: 0x0032911C
	[NullableContext(1)]
	public void SetSkinQualityByParameters(SmallItemGridBase parameters)
	{
		this.SetQuality(null);
		this.SetSkinItemQuality(parameters);
	}

	// Token: 0x0600BF92 RID: 49042 RVA: 0x0032AF40 File Offset: 0x00329140
	public void SetQuality(int? itemConfigId = null)
	{
		UUISprite sprite = base.GetSprite(0);
		if (itemConfigId == null)
		{
			sprite.SetUIActive(false);
			return;
		}
		int qualityItemConfigId = this.QualityItemConfigId;
		int? num = itemConfigId;
		if (qualityItemConfigId == num.GetValueOrDefault() & num != null)
		{
			sprite.SetUIActive(true);
			return;
		}
		this.QualityItemConfigId = itemConfigId.Value;
		base.SetItemQualityIcon(sprite, itemConfigId.Value, null, CommonDefine.EQualityIconType.BackgroundSprite, null);
		sprite.SetUIActive(true);
	}

	// Token: 0x0600BF93 RID: 49043 RVA: 0x0032AFB8 File Offset: 0x003291B8
	public void SetSkinQuality(int? itemConfigId = null)
	{
		UUISprite sprite = base.GetSprite(8);
		if (itemConfigId == null)
		{
			sprite.SetUIActive(false);
			return;
		}
		int qualityItemConfigId = this.QualityItemConfigId;
		int? num = itemConfigId;
		if (qualityItemConfigId == num.GetValueOrDefault() & num != null)
		{
			sprite.SetUIActive(true);
			return;
		}
		this.QualityItemConfigId = itemConfigId.Value;
		ItemConfig itemConfigData = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(itemConfigId.Value);
		this.SetSpriteByPath(ConfigBase<CommonConfig>.Instance.GetItemQualityById(itemConfigData.QualityId).Value.SkinQuality, sprite, false, null, null);
		sprite.SetUIActive(true);
	}

	// Token: 0x0600BF94 RID: 49044 RVA: 0x0032B05C File Offset: 0x0032925C
	private void SetNormalItemQuality(SmallItemGridBase parameters)
	{
		UUISprite sprite = base.GetSprite(0);
		if (parameters == null)
		{
			sprite.SetUIActive(false);
			return;
		}
		this.SetNormalItemQualityInternal(parameters.IsQualityHidden, parameters.QualityId, parameters.ItemConfigId, parameters.QualityIcon, parameters.QualityType);
	}

	// Token: 0x0600BF95 RID: 49045 RVA: 0x0032B0A0 File Offset: 0x003292A0
	private void SetPinballItemQuality(SmallItemGridBase parameters)
	{
		if (parameters == null || parameters.ItemConfigId == null)
		{
			base.GetSprite(0).SetUIActive(false);
			return;
		}
		ItemConfig itemConfigData = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(parameters.ItemConfigId.Value);
		if (itemConfigData == null)
		{
			base.GetSprite(0).SetUIActive(false);
			return;
		}
		this.SetNormalItemQualityInternal(parameters.IsQualityHidden, new int?(parameters.QualityId ?? itemConfigData.QualityId), parameters.ItemConfigId, parameters.QualityIcon, new CommonDefine.EQualityIconType?(parameters.QualityType.GetValueOrDefault(CommonDefine.EQualityIconType.TypeAGridQualitySpritePath)));
	}

	// Token: 0x0600BF96 RID: 49046 RVA: 0x0032B140 File Offset: 0x00329340
	private void SetNormalItemQualityInternal(bool? isQualityHidden, int? qualityId, int? itemConfigId, string qualityIcon, CommonDefine.EQualityIconType? qualityType)
	{
		UUISprite sprite = base.GetSprite(0);
		if (isQualityHidden.GetValueOrDefault())
		{
			sprite.SetUIActive(false);
			return;
		}
		if (!string.IsNullOrEmpty(qualityIcon))
		{
			this.SetQualityIconById(qualityIcon);
			this.QualityItemConfigId = ((itemConfigId != null) ? itemConfigId.Value : 0);
			return;
		}
		int? num = qualityId;
		int num2 = 0;
		if (num.GetValueOrDefault() > num2 & num != null)
		{
			base.SetQualityIconById(sprite, qualityId.Value, null, qualityType, null);
			sprite.SetUIActive(true);
			this.QualityItemConfigId = ((itemConfigId != null) ? itemConfigId.Value : 0);
			return;
		}
		num = qualityId;
		num2 = 0;
		if (num.GetValueOrDefault() == num2 & num != null)
		{
			string defaultQualitySpritePath = ModelBase<SmallItemGridModel>.Instance.DefaultQualitySpritePath;
			this.SetSpriteByPath(defaultQualitySpritePath, sprite, false, null, null);
			sprite.SetUIActive(true);
			this.QualityItemConfigId = ((itemConfigId != null) ? itemConfigId.Value : 0);
			return;
		}
		this.SetQuality(itemConfigId);
	}

	// Token: 0x0600BF97 RID: 49047 RVA: 0x0032B244 File Offset: 0x00329444
	private void SetSkinItemQuality(SmallItemGridBase parameters)
	{
		UUISprite sprite = base.GetSprite(8);
		if (parameters == null)
		{
			sprite.SetUIActive(false);
			return;
		}
		if (parameters.IsQualityHidden.GetValueOrDefault())
		{
			sprite.SetUIActive(false);
			return;
		}
		int? qualityId = parameters.QualityId;
		int num = 0;
		if (qualityId.GetValueOrDefault() > num & qualityId != null)
		{
			this.SetSpriteByPath(ConfigBase<CommonConfig>.Instance.GetItemQualityById(parameters.QualityId.Value).Value.SkinQuality, sprite, false, null, null);
			sprite.SetUIActive(true);
			this.QualityItemConfigId = ((parameters.ItemConfigId != null) ? parameters.ItemConfigId.Value : 0);
			return;
		}
		qualityId = parameters.QualityId;
		num = 0;
		if (qualityId.GetValueOrDefault() == num & qualityId != null)
		{
			string defaultQualitySpritePath = ModelBase<SmallItemGridModel>.Instance.DefaultQualitySpritePath;
			this.SetSpriteByPath(defaultQualitySpritePath, sprite, false, null, null);
			sprite.SetUIActive(true);
			this.QualityItemConfigId = ((parameters.ItemConfigId != null) ? parameters.ItemConfigId.Value : 0);
			return;
		}
		this.SetSkinQuality(parameters.ItemConfigId);
	}

	// Token: 0x0600BF98 RID: 49048 RVA: 0x0032B36C File Offset: 0x0032956C
	private void SetDangoAbyssItemQuality(SmallItemGridBase parameters)
	{
		UUISprite sprite = base.GetSprite(0);
		if (parameters == null || parameters.ItemConfigId == null)
		{
			sprite.SetUIActive(false);
			return;
		}
		if (parameters.IsQualityHidden.GetValueOrDefault())
		{
			sprite.SetUIActive(false);
			return;
		}
		int qualityItemConfigId = this.QualityItemConfigId;
		int? itemConfigId = parameters.ItemConfigId;
		if (qualityItemConfigId == itemConfigId.GetValueOrDefault() & itemConfigId != null)
		{
			sprite.SetUIActive(true);
			return;
		}
		this.QualityItemConfigId = parameters.ItemConfigId.Value;
		AbyssQuality? abyssQualityByPluginItemId = ConfigBase<DangoAbyssConfig>.Instance.GetAbyssQualityByPluginItemId(parameters.ItemConfigId.Value);
		CommonDefine.EQualityIconType valueOrDefault = parameters.QualityType.GetValueOrDefault();
		string path = null;
		if (valueOrDefault == CommonDefine.EQualityIconType.BackgroundSprite)
		{
			path = (abyssQualityByPluginItemId.Value.BackgroundSprite ?? ModelBase<SmallItemGridModel>.Instance.DefaultQualitySpritePath);
		}
		else if (valueOrDefault == CommonDefine.EQualityIconType.MediumItemGridQualitySpritePath)
		{
			path = (abyssQualityByPluginItemId.Value.MediumItemGridQualitySpritePath ?? ModelBase<SmallItemGridModel>.Instance.DefaultQualitySpritePath);
		}
		this.SetSpriteByPath(path, sprite, false, null, null);
		sprite.SetUIActive(true);
	}

	// Token: 0x0600BF99 RID: 49049 RVA: 0x0032B470 File Offset: 0x00329670
	private void SetHonamiStoryItemQuality(SmallItemGridBase parameters)
	{
		UUISprite sprite = base.GetSprite(0);
		if (parameters == null || parameters.ItemConfigId == null)
		{
			sprite.SetUIActive(false);
			return;
		}
		if (parameters.IsQualityHidden.GetValueOrDefault())
		{
			sprite.SetUIActive(false);
			return;
		}
		int qualityItemConfigId = this.QualityItemConfigId;
		int? itemConfigId = parameters.ItemConfigId;
		if (qualityItemConfigId == itemConfigId.GetValueOrDefault() & itemConfigId != null)
		{
			sprite.SetUIActive(true);
			return;
		}
		this.QualityItemConfigId = parameters.ItemConfigId.Value;
		HonamiStoryItem? honamiStoryItem = ConfigBase<HonamiStoryConfig>.Instance.GetHonamiStoryItem(parameters.ItemConfigId.Value);
		HonamiStoryItemQuality? honamiStoryQuality = ConfigBase<HonamiStoryConfig>.Instance.GetHonamiStoryQuality(honamiStoryItem.Value.QualityId);
		CommonDefine.EQualityIconType valueOrDefault = parameters.QualityType.GetValueOrDefault();
		string path = null;
		if (valueOrDefault == CommonDefine.EQualityIconType.BackgroundSprite)
		{
			path = (honamiStoryQuality.Value.BackgroundSprite ?? ModelBase<SmallItemGridModel>.Instance.DefaultQualitySpritePath);
		}
		else if (valueOrDefault == CommonDefine.EQualityIconType.MediumItemGridQualitySpritePath)
		{
			path = (honamiStoryQuality.Value.MediumItemGridQualitySpritePath ?? ModelBase<SmallItemGridModel>.Instance.DefaultQualitySpritePath);
		}
		this.SetSpriteByPath(path, sprite, false, null, null);
		sprite.SetUIActive(true);
	}

	// Token: 0x0600BF9A RID: 49050 RVA: 0x0032B594 File Offset: 0x00329794
	[NullableContext(1)]
	public void SetItemQualityByPath(string qualityIconPath)
	{
		UUISprite sprite = base.GetSprite(0);
		if (sprite == null)
		{
			sprite.SetUIActive(false);
			return;
		}
		this.SetSpriteByPath(qualityIconPath, sprite, true, null, null);
		sprite.SetUIActive(true);
	}

	// Token: 0x0600BF9B RID: 49051 RVA: 0x0032B5D0 File Offset: 0x003297D0
	private void SetQualityByPath(string path)
	{
		UUISprite sprite = base.GetSprite(0);
		if (path == null)
		{
			if (sprite != null)
			{
				sprite.SetUIActive(false);
			}
			return;
		}
		if (StringUtils.IsEmpty(path))
		{
			if (sprite != null)
			{
				sprite.SetUIActive(false);
			}
			return;
		}
		this.SetSpriteByPath(path, sprite, true, null, null);
		if (sprite != null)
		{
			sprite.SetUIActive(true);
		}
	}

	// Token: 0x0600BF9C RID: 49052 RVA: 0x0032B623 File Offset: 0x00329823
	public void SetOrnamentConflictVisible(bool? bVisible)
	{
		base.RefreshComponent(typeof(SmallItemGridOrnamentConflictComponent), bVisible, bVisible);
	}

	// Token: 0x0600BF9D RID: 49053 RVA: 0x0032B640 File Offset: 0x00329840
	[NullableContext(1)]
	private void SetQualityByResourceId(string resourceId)
	{
		UUISprite sprite = base.GetSprite(0);
		if (sprite == null)
		{
			return;
		}
		string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resourceId);
		if (StringUtils.IsEmpty(resourcePath))
		{
			sprite.SetUIActive(false);
			return;
		}
		this.SetSpriteByPath(resourcePath, sprite, true, null, null);
		sprite.SetUIActive(true);
	}

	// Token: 0x0600BF9E RID: 49054 RVA: 0x0032B690 File Offset: 0x00329890
	[NullableContext(1)]
	private void RefreshBottomText(SmallItemGridBase parameters)
	{
		if (parameters == null)
		{
			return;
		}
		string bottomTextId = parameters.BottomTextId;
		string bottomText = parameters.BottomText;
		object[] bottomTextParameter = parameters.BottomTextParameter;
		bool flag = !StringUtils.IsEmpty(bottomTextId) || !StringUtils.IsEmpty(bottomText);
		this.SetBottomTextVisible(flag);
		if (flag)
		{
			this.SetBottomTextId(bottomTextId, bottomTextParameter);
			this.SetBottomText(bottomText);
		}
	}

	// Token: 0x0600BF9F RID: 49055 RVA: 0x0032B6E4 File Offset: 0x003298E4
	public void SetBottomTextId(string textId, [Nullable(new byte[]
	{
		2,
		1
	})] object[] textParameter)
	{
		UUIText text = base.GetText(3);
		if (StringUtils.IsEmpty(textId))
		{
			return;
		}
		if (textParameter != null)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, textId, textParameter);
			return;
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(text, textId, Array.Empty<object>());
	}

	// Token: 0x0600BFA0 RID: 49056 RVA: 0x0032B724 File Offset: 0x00329924
	public void SetBottomText(string text)
	{
		UUIText text2 = base.GetText(3);
		if (StringUtils.IsEmpty(text))
		{
			return;
		}
		text2.SetText(text, true);
	}

	// Token: 0x0600BFA1 RID: 49057 RVA: 0x0032B74A File Offset: 0x0032994A
	[NullableContext(1)]
	public void SetBottomTextColor(string hexColor)
	{
		base.GetText(3).SetColor(FColor.FromHex(hexColor));
	}

	// Token: 0x0600BFA2 RID: 49058 RVA: 0x0032B760 File Offset: 0x00329960
	public void SetBottomTextVisible(bool bVisible)
	{
		UUISprite sprite = base.GetSprite(4);
		UUIText text = base.GetText(3);
		if (sprite.IsUIActiveSelf() != bVisible)
		{
			sprite.SetUIActive(bVisible);
		}
		if (text.IsUIActiveSelf() != bVisible)
		{
			text.SetUIActive(bVisible);
		}
	}

	// Token: 0x0600BFA3 RID: 49059 RVA: 0x0032B7A0 File Offset: 0x003299A0
	[NullableContext(1)]
	public void RefreshTopRightText(SmallItemGridBase parameters)
	{
		ISmallItemTopRightTagComponentParams @params = new SmallItemTopRightTagComponentParams
		{
			TopRightTextBgColor = parameters.TopRightTextBgColor,
			TopRightTextColor = parameters.TopRightTextColor,
			TopRightTextId = parameters.TopRightTextId,
			TopRightText = parameters.TopRightText,
			TopRightTextParameter = parameters.TopRightTextParameter
		};
		bool value = !StringUtils.IsEmpty(parameters.TopRightTextId) || !StringUtils.IsEmpty(parameters.TopRightText);
		base.RefreshComponent(typeof(SmallItemTopRightTagComponent), new bool?(value), @params);
	}

	// Token: 0x0600BFA4 RID: 49060 RVA: 0x0032B828 File Offset: 0x00329A28
	public void SetRightTopValueInfo(string value)
	{
		bool value2 = !string.IsNullOrEmpty(value);
		base.RefreshComponent(typeof(SmallItemGridRightTopValueComponent), new bool?(value2), value);
	}

	// Token: 0x0600BFA5 RID: 49061 RVA: 0x0032B858 File Offset: 0x00329A58
	public void SetCoolDown(float? coolDown, float? totalCdTime = null)
	{
		ISmallItemGridCoolDownComponentParams @params = new SmallItemGridCoolDownComponentParams
		{
			CoolDown = coolDown,
			TotalCdTime = totalCdTime
		};
		Type typeFromHandle = typeof(SmallItemGridCoolDownComponent);
		bool value;
		if (coolDown != null)
		{
			float? num = coolDown;
			float num2 = 0f;
			value = (num.GetValueOrDefault() > num2 & num != null);
		}
		else
		{
			value = false;
		}
		base.RefreshComponent(typeFromHandle, new bool?(value), @params);
	}

	// Token: 0x0600BFA6 RID: 49062 RVA: 0x0032B8B6 File Offset: 0x00329AB6
	public void SetIsDisable(bool? isDisable)
	{
		base.RefreshComponent(typeof(SmallItemGridDisableComponent), new bool?(isDisable.GetValueOrDefault()), isDisable);
	}

	// Token: 0x0600BFA7 RID: 49063 RVA: 0x0032B8DC File Offset: 0x00329ADC
	[NullableContext(1)]
	public void SetDisableComponentColor(string hexColor, bool isDisable = true)
	{
		SmallItemGridDisableComponent smallItemGridDisableComponent = base.RefreshComponent(typeof(SmallItemGridDisableComponent), new bool?(false), isDisable) as SmallItemGridDisableComponent;
		if (smallItemGridDisableComponent == null)
		{
			return;
		}
		smallItemGridDisableComponent.GetAsync().ContinueWith(delegate(ItemGridComponent component)
		{
			SmallItemGridDisableComponent smallItemGridDisableComponent2 = component as SmallItemGridDisableComponent;
			if (smallItemGridDisableComponent2 == null)
			{
				return;
			}
			smallItemGridDisableComponent2.SetSpriteColor(hexColor);
		});
	}

	// Token: 0x0600BFA8 RID: 49064 RVA: 0x0032B934 File Offset: 0x00329B34
	public void SetIsBlack(bool isBlack)
	{
		base.RefreshComponent(typeof(SmallItemGridBlackComponent), new bool?(isBlack), isBlack);
	}

	// Token: 0x0600BFA9 RID: 49065 RVA: 0x0032B953 File Offset: 0x00329B53
	public void SetNewFlagVisible(bool? isVisible)
	{
		base.RefreshComponent(typeof(SmallItemGridNewFlagComponent), new bool?(isVisible.GetValueOrDefault()), isVisible);
	}

	// Token: 0x0600BFAA RID: 49066 RVA: 0x0032B978 File Offset: 0x00329B78
	public void SetTimeFlagVisible(bool? bVisible)
	{
		base.RefreshComponent(typeof(SmallItemGridTimeFlagComponent), bVisible, bVisible);
	}

	// Token: 0x0600BFAB RID: 49067 RVA: 0x0032B992 File Offset: 0x00329B92
	private void SetNotFoundVisible(bool? isVisible)
	{
		base.RefreshComponent(typeof(SmallItemGridNotFoundComponent), new bool?(isVisible.GetValueOrDefault()), isVisible);
	}

	// Token: 0x0600BFAC RID: 49068 RVA: 0x0032B9B7 File Offset: 0x00329BB7
	public void SetRedDotVisible(bool? isVisible)
	{
		base.RefreshComponent(typeof(SmallItemGridRedDotComponent), new bool?(isVisible.GetValueOrDefault()), isVisible);
	}

	// Token: 0x0600BFAD RID: 49069 RVA: 0x0032B9DC File Offset: 0x00329BDC
	public void SetRedDotNumCount(int? count)
	{
		bool flag = count != null && count.Value > 0;
		base.RefreshComponent(typeof(SmallItemGridRedDotNumComponent), new bool?(flag), flag ? count.Value : null);
	}

	// Token: 0x0600BFAE RID: 49070 RVA: 0x0032BA29 File Offset: 0x00329C29
	public void SetRoleDevelopStateTag(ERoleDevelopStateTagType? roleDevelopStateTagType)
	{
		base.RefreshComponent(typeof(SmallItemGridRoleDevelopStateTagComponent), new bool?(roleDevelopStateTagType != null), roleDevelopStateTagType);
	}

	// Token: 0x0600BFAF RID: 49071 RVA: 0x0032BA4E File Offset: 0x00329C4E
	public void SetDangoPluginIcon(IDangoPluginIconInfo dangoPluginIconInfo)
	{
		base.RefreshComponent(typeof(SmallItemGridDangoPluginIconComponent), new bool?(true), dangoPluginIconInfo);
	}

	// Token: 0x0600BFB0 RID: 49072 RVA: 0x0032BA68 File Offset: 0x00329C68
	public void SetBirthdayEffect(bool? bVisible)
	{
		base.RefreshComponent(typeof(SmallItemGridBirthdayEffectComponent), new bool?(true), bVisible);
	}

	// Token: 0x0600BFB1 RID: 49073 RVA: 0x0032BA88 File Offset: 0x00329C88
	public void SetEmptySlotVisible(bool isVisible)
	{
		SmallItemGridEmptySlotComponent smallItemGridEmptySlotComponent = base.RefreshComponent(typeof(SmallItemGridEmptySlotComponent), new bool?(isVisible), isVisible) as SmallItemGridEmptySlotComponent;
		if (smallItemGridEmptySlotComponent == null)
		{
			return;
		}
		if (isVisible)
		{
			smallItemGridEmptySlotComponent.BindEmptySlotButtonCallback(new Action(this.OnClickedEmptySlotButton));
			return;
		}
		smallItemGridEmptySlotComponent.UnBindEmptySlotButtonCallback();
	}

	// Token: 0x0600BFB2 RID: 49074 RVA: 0x0032BAD8 File Offset: 0x00329CD8
	protected void OnClickedEmptySlotButton()
	{
		if (this.OnClickedEmptySlotButtonCallback != null)
		{
			SmallItemGridButtonCallback obj = new SmallItemGridButtonCallback
			{
				SmallItemGrid = this,
				Data = this.Data
			};
			this.OnClickedEmptySlotButtonCallback(obj);
		}
	}

	// Token: 0x0600BFB3 RID: 49075 RVA: 0x0032BB12 File Offset: 0x00329D12
	private void SetVisionRoleHead(int? visionHeadInfo)
	{
		base.RefreshComponent(typeof(SmallItemGridVisionRoleHeadComponent), new bool?(visionHeadInfo != null), visionHeadInfo);
	}

	// Token: 0x0600BFB4 RID: 49076 RVA: 0x0032BB37 File Offset: 0x00329D37
	public void SetRoleHead(int? roleHeadInfo)
	{
		base.RefreshComponent(typeof(SmallItemGridRoleHeadComponent), new bool?(roleHeadInfo != null), roleHeadInfo);
	}

	// Token: 0x0600BFB5 RID: 49077 RVA: 0x0032BB5C File Offset: 0x00329D5C
	public void SetVisionFetterGroup(int? fetterGroupId)
	{
		Type typeFromHandle = typeof(SmallItemGridVisionFetterComponent);
		bool value;
		if (fetterGroupId != null)
		{
			int? num = fetterGroupId;
			int num2 = 0;
			value = (num.GetValueOrDefault() > num2 & num != null);
		}
		else
		{
			value = false;
		}
		base.RefreshComponent(typeFromHandle, new bool?(value), fetterGroupId);
	}

	// Token: 0x0600BFB6 RID: 49078 RVA: 0x0032BBA7 File Offset: 0x00329DA7
	public void BindEmptySlotButtonCallback([Nullable(new byte[]
	{
		2,
		1
	})] Action<SmallItemGridButtonCallback> callback)
	{
		this.OnClickedEmptySlotButtonCallback = callback;
	}

	// Token: 0x0600BFB7 RID: 49079 RVA: 0x0032BBB0 File Offset: 0x00329DB0
	public override void SetSelected(bool bSelected, bool bForce = false)
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(7);
		if (bSelected)
		{
			if (bForce)
			{
				extendToggle.SetToggleStateForce(EToggleState.ETT_Checked, false, false, false);
			}
			else
			{
				extendToggle.SetToggleState(EToggleState.ETT_Checked, false, false, false);
			}
		}
		else if (bForce)
		{
			extendToggle.SetToggleStateForce(EToggleState.ETT_UnChecked, false, false, false);
		}
		else
		{
			extendToggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
		}
		this.IsSelected = bSelected;
		this.IsForceSelected = bForce;
	}

	// Token: 0x0600BFB8 RID: 49080 RVA: 0x0032BC0C File Offset: 0x00329E0C
	[NullableContext(1)]
	public void SetIconByPath(string iconPath)
	{
		this.SetTextureByIconPath(iconPath);
	}

	// Token: 0x0600BFB9 RID: 49081 RVA: 0x0032BC15 File Offset: 0x00329E15
	public void SetLeftTopIconVisible(string path)
	{
		base.RefreshComponent(typeof(SmallItemGridLeftTopIconComponent), new bool?(path != null), path);
	}

	// Token: 0x0600BFBA RID: 49082 RVA: 0x0032BC32 File Offset: 0x00329E32
	public void SetMultiPlayerVisible(SmallItemMultiPlayer @params)
	{
		base.RefreshComponent(typeof(SmallItemGridMultiPlayerComponent), new bool?(@params != null && @params.Players.Count > 0), @params);
	}

	// Token: 0x0600BFBB RID: 49083 RVA: 0x0032BC60 File Offset: 0x00329E60
	[NullableContext(1)]
	private void SetQualityIconById(string qualityIcon)
	{
		UUISprite sprite = base.GetSprite(0);
		if (string.IsNullOrEmpty(qualityIcon))
		{
			sprite.SetUIActive(false);
			return;
		}
		this.SetSpriteByPath(qualityIcon, sprite, true, null, null);
		sprite.SetUIActive(true);
	}

	// Token: 0x040059E6 RID: 23014
	private int QualityItemConfigId;

	// Token: 0x040059E7 RID: 23015
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Action<SmallItemGridButtonCallback> OnClickedEmptySlotButtonCallback;

	// Token: 0x040059E8 RID: 23016
	private const int TRIAL_ROLE_ID = 10000;

	// Token: 0x02007CF3 RID: 31987
	[NullableContext(0)]
	private class EChildType
	{
		// Token: 0x0402A9F8 RID: 174584
		public const int QualitySprite = 0;

		// Token: 0x0402A9F9 RID: 174585
		public const int ItemTexture = 1;

		// Token: 0x0402A9FA RID: 174586
		public const int BottomTextItem = 2;

		// Token: 0x0402A9FB RID: 174587
		public const int BottomText = 3;

		// Token: 0x0402A9FC RID: 174588
		public const int BottomTextBgSprite = 4;

		// Token: 0x0402A9FD RID: 174589
		public const int BottomAdditionItem = 5;

		// Token: 0x0402A9FE RID: 174590
		public const int TopAdditionItem = 6;

		// Token: 0x0402A9FF RID: 174591
		public const int ExtendToggle = 7;

		// Token: 0x0402AA00 RID: 174592
		public const int SkinQualitySprite = 8;

		// Token: 0x0402AA01 RID: 174593
		public const int UnderTextAdditionItem = 9;

		// Token: 0x0402AA02 RID: 174594
		public const int AniLoop = 10;

		// Token: 0x0402AA03 RID: 174595
		public const int ItemSprite = 11;
	}
}
