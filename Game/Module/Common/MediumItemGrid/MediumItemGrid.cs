using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Kurotato;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Module.RoleUi.RoleDevelop;
using CSharpScript.Game.Module.Skin;
using UnrealEngine;

namespace CSharpScript.Game.Module.Common.MediumItemGrid
{
	// Token: 0x02005E52 RID: 24146
	[NullableContext(2)]
	[Nullable(0)]
	public class MediumItemGrid : ItemGridBase
	{
		// Token: 0x0603CC2B RID: 248875 RVA: 0x00F6D7C4 File Offset: 0x00F6B9C4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 11;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUISprite));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603CC2C RID: 248876 RVA: 0x00F6D959 File Offset: 0x00F6BB59
		protected override UUIItem OnSetUnderTextAdditionItem()
		{
			return base.GetItem(7);
		}

		// Token: 0x0603CC2D RID: 248877 RVA: 0x00F6D962 File Offset: 0x00F6BB62
		protected override UUIItem OnSetBottomAdditionItem()
		{
			return base.GetItem(5);
		}

		// Token: 0x0603CC2E RID: 248878 RVA: 0x00F6D96B File Offset: 0x00F6BB6B
		protected override UUIItem OnSetTopAdditionItem()
		{
			return base.GetItem(4);
		}

		// Token: 0x0603CC2F RID: 248879 RVA: 0x00F6D974 File Offset: 0x00F6BB74
		protected override void UnBindComponentEvents()
		{
			this.UnBindReduceButtonCallback();
			this.UnBindEmptySlotButtonCallback();
			this.UnBindReduceLongPress();
		}

		// Token: 0x0603CC30 RID: 248880 RVA: 0x00F6D988 File Offset: 0x00F6BB88
		[NullableContext(1)]
		public void Apply<[Nullable(0)] T>(T parameters) where T : IMediumItemGridBase
		{
			base.ClearVisibleComponent();
			base.ClearComponentList();
			if (parameters.Type == EMediumItemGridType.Empty)
			{
				this.ApplyEmptyMediumItemGrid(parameters as EmptyItemGrid);
			}
			if (parameters.Type == EMediumItemGridType.OnlyEmpty)
			{
				this.ApplyOnlyEmptyMediumItemGrid(parameters as OnlyEmptyItemGrid);
			}
			if (parameters.Type == EMediumItemGridType.Prop)
			{
				this.ApplyPropMediumItemGrid(parameters as PropMediumItemGrid);
			}
			if (parameters.Type == EMediumItemGridType.Phantom)
			{
				this.ApplyPhantomMediumItemGrid(parameters as PhantomMediumItemGrid);
			}
			if (parameters.Type == EMediumItemGridType.Character)
			{
				this.ApplyCharacterMediumItemGrid(parameters as CharacterMediumItemGrid);
			}
			if (parameters.Type == EMediumItemGridType.ForecastCharacter)
			{
				this.ApplyForecastCharacterMediumItemGrid(parameters as ForecastCharacterMediumItemGrid);
			}
			if (parameters.Type == EMediumItemGridType.Kurotato)
			{
				this.ApplyKurotatoWeaponMediumItemGrid(parameters as KurotatoMediumItemGrid);
			}
			base.RefreshComponentVisible();
			base.RefreshComponentHierarchyIndex();
		}

		// Token: 0x0603CC31 RID: 248881 RVA: 0x00F6DA94 File Offset: 0x00F6BC94
		[NullableContext(1)]
		private void ApplyEmptyMediumItemGrid(EmptyItemGrid parameters)
		{
			this.Data = parameters.Data;
			this.SetEmptySlotVisible(true);
			this.SetTexture(null);
			this.SetQuality(null);
			this.SetBgVisible(false);
			this.SetBottomTextVisible(false);
			base.SetExtendToggleEnable(true, false);
			this.ApplyEmptyDisplay(parameters);
		}

		// Token: 0x0603CC32 RID: 248882 RVA: 0x00F6DAF0 File Offset: 0x00F6BCF0
		[NullableContext(1)]
		private void ApplyOnlyEmptyMediumItemGrid(OnlyEmptyItemGrid parameters)
		{
			this.Data = parameters.Data;
			this.SetTexture(null);
			this.SetQuality(null);
			this.SetBgVisible(false);
			this.SetBottomTextVisible(false);
			base.SetExtendToggleEnable(true, false);
			this.SetBottomTextVisible(false);
			this.SetOnlyEmptyVisible(true, parameters);
		}

		// Token: 0x0603CC33 RID: 248883 RVA: 0x00F6DB4C File Offset: 0x00F6BD4C
		[NullableContext(1)]
		private void ApplyPropMediumItemGrid(PropMediumItemGrid parameters)
		{
			int? starLevel = parameters.StarLevel;
			bool? isNewVisible = parameters.IsNewVisible;
			EMediumItemGridBuffType? buffIconType = parameters.BuffIconType;
			bool? isRedDotVisible = parameters.IsRedDotVisible;
			bool? isLockVisible = parameters.IsLockVisible;
			bool? isDeprecate = parameters.IsDeprecate;
			int? level = parameters.Level;
			bool? isLevelInfinite = parameters.IsLevelInfinite;
			bool? isLevelTextUseChangeColor = parameters.IsLevelTextUseChangeColor;
			float? coolDown = parameters.CoolDown;
			float? totalCoolDown = parameters.TotalCoolDown;
			bool? isProhibit = parameters.IsProhibit;
			LongPressButton reduceButtonInfo = parameters.ReduceButtonInfo;
			bool? isGreenSelected = parameters.IsGreenSelected;
			bool? isWarning = parameters.IsWarning;
			bool? isCheckTick = parameters.IsCheckTick;
			bool? isTimeFlagVisible = parameters.IsTimeFlagVisible;
			bool? isReceivedFlagVisible = parameters.IsReceivedFlagVisible;
			RoleHeadInfo roleHeadInfo = parameters.RoleHeadInfo;
			int? sortIndex = parameters.SortIndex;
			bool? isDisable = parameters.IsDisable;
			bool? isMainVisionVisible = parameters.IsMainVisionVisible;
			int? visionFetterGroupId = parameters.VisionFetterGroupId;
			VisionRoleHeadInfo visionRoleHeadInfo = parameters.VisionRoleHeadInfo;
			DangoRoleHeadInfo dangoRoleHeadInfo = parameters.DangoRoleHeadInfo;
			MediumItemGridComposeTag composeIconTag = parameters.ComposeIconTag;
			bool? changeAble = parameters.ChangeAble;
			bool? isUpGrade = parameters.IsUpGrade;
			string[] tagPathList = parameters.TagPathList;
			string subIconPath = parameters.SubIconPath;
			string rightTopValue = parameters.RightTopValue;
			bool value = ConfigBase<InventoryConfig>.Instance.GetItemDataTypeByConfigId(parameters.ItemConfigId) == InventoryDefine.EItemDataType.PhantomItem;
			bool? isBranchUpgrade = parameters.IsBranchUpgrade;
			bool? isRecommendVisible = parameters.IsRecommendVisible;
			MediumWarningPanelInfo warningPanelInfo = parameters.WarningPanelInfo;
			this.SetStartLevel(starLevel);
			this.SetBuffSprite(buffIconType);
			this.SetLevelAndLock(level, isLockVisible, isLevelTextUseChangeColor, new bool?(value), isDeprecate, isLevelInfinite);
			this.SetRecommendVisible(isRecommendVisible);
			this.SetItemPrice(parameters.ItemPrice);
			this.SetCoolDown(coolDown, totalCoolDown);
			this.SetIsProhibit(isProhibit);
			this.SetReduceButton(reduceButtonInfo);
			this.SetGreenSelected(isGreenSelected);
			this.SetWarningIcon(isWarning);
			this.SetCheckTickVisible(isCheckTick);
			this.SetTimeFlagVisible(isTimeFlagVisible);
			this.SetReceivedFlagVisible(isReceivedFlagVisible);
			this.SetRoleHead(roleHeadInfo);
			this.SetSortIndex(sortIndex, false);
			this.SetIsDisable(isDisable);
			this.SetRogueFinish(parameters.IsRogueFinish);
			this.SetIsMainVision(isMainVisionVisible);
			if (!parameters.IsNewOverRedDot.GetValueOrDefault())
			{
				this.SetRedDotVisible(isRedDotVisible);
				this.SetNewVisible(new bool?(!isRedDotVisible.GetValueOrDefault() && isNewVisible.GetValueOrDefault()));
			}
			else
			{
				this.SetNewVisible(new bool?(isNewVisible.GetValueOrDefault()));
				this.SetRedDotVisible(new bool?(!isNewVisible.GetValueOrDefault() && isRedDotVisible.GetValueOrDefault()));
			}
			this.SetVisionFetterGroup(visionFetterGroupId);
			this.SetVisionRoleHead(visionRoleHeadInfo);
			this.SetComposeIcon(composeIconTag);
			this.SetComposeChangeAble(changeAble);
			this.SetDangoRoleHead(dangoRoleHeadInfo);
			this.SetUpGradeVisible(isUpGrade);
			this.SetTagsInfo(tagPathList);
			this.SetSubIconPath(subIconPath);
			this.SetRightTopValueInfo(rightTopValue);
			this.SetIsBranchUpgrade(isBranchUpgrade);
			this.SetWarningPanelInfo(warningPanelInfo);
			this.SetRoundCount(parameters.RoundCount);
			this.ApplyPropBaseDisplay(parameters);
		}

		// Token: 0x0603CC34 RID: 248884 RVA: 0x00F6DDF4 File Offset: 0x00F6BFF4
		[NullableContext(1)]
		private void ApplyPhantomMediumItemGrid(PhantomMediumItemGrid parameters)
		{
			int? starLevel = parameters.StarLevel;
			bool? isMainVisionVisible = parameters.IsMainVisionVisible;
			RoleHeadInfo roleHeadInfo = parameters.RoleHeadInfo;
			bool? isNewVisible = parameters.IsNewVisible;
			bool? isLockVisible = parameters.IsLockVisible;
			bool? isDeprecate = parameters.IsDeprecate;
			bool? isPhantomLock = parameters.IsPhantomLock;
			DevelopRewardInfo developRewardInfo = parameters.DevelopRewardInfo;
			bool? isRedDotVisible = parameters.IsRedDotVisible;
			int? level = parameters.Level;
			bool? isLevelTextUseChangeColor = parameters.IsLevelTextUseChangeColor;
			int? fetterGroupId = parameters.FetterGroupId;
			VisionRoleHeadInfo visionRoleHeadInfo = parameters.VisionRoleHeadInfo;
			EMediumItemGridPhantomSpecialSkill? specialSkill = parameters.SpecialSkill;
			int? sortNum = parameters.SortNum;
			bool? isDisable = parameters.IsDisable;
			MediumWarningPanelInfo warningPanelInfo = parameters.WarningPanelInfo;
			this.SetStartLevel(starLevel);
			this.SetRedDotVisible(isRedDotVisible);
			this.SetIsMainVision(isMainVisionVisible);
			this.SetRoleHead(roleHeadInfo);
			this.SetLevelAndLock(level, isLockVisible, isLevelTextUseChangeColor, new bool?(true), isDeprecate, null);
			this.SetIsPhantomLock(isPhantomLock);
			this.SetDevelopRewardInfo(developRewardInfo);
			this.SetNewVisible(new bool?(isNewVisible.GetValueOrDefault()));
			this.SetVisionFetterGroup(fetterGroupId);
			this.SetVisionRoleHead(visionRoleHeadInfo);
			this.SetPhantomIsSpecialSkill(specialSkill);
			this.SetPhantomSortNum(sortNum);
			this.SetIsDisable(isDisable);
			this.SetWarningPanelInfo(warningPanelInfo);
			this.ApplyPhantomBaseDisplay(parameters);
		}

		// Token: 0x0603CC35 RID: 248885 RVA: 0x00F6DF1C File Offset: 0x00F6C11C
		[NullableContext(1)]
		private void ApplyCharacterMediumItemGrid(CharacterMediumItemGrid parameters)
		{
			this.SetFrameEffectVisible(parameters.FrameEffect);
			this.SetElement(parameters.ElementId);
			this.SetSortIndex(parameters.Index, parameters.HighlightIndex.GetValueOrDefault());
			this.SetTeamIcon(parameters.IsInTeam);
			this.SetRecommendVisible(parameters.IsRecommendVisible);
			this.SetUnRecommendVisible(parameters.IsUnRecommendVisible);
			this.SetIsDisable(parameters.IsDisable);
			MediumRoleRightBottomTag roleRightBottomTagVisible = null;
			if (parameters.IsRecommendBottomVisible.GetValueOrDefault() || parameters.IsTrialBottomVisible.GetValueOrDefault())
			{
				roleRightBottomTagVisible = new MediumRoleRightBottomTag
				{
					IsTrialRole = parameters.IsTrialBottomVisible.GetValueOrDefault(),
					IsRecommendRole = parameters.IsRecommendBottomVisible.GetValueOrDefault()
				};
			}
			this.SetRoleRightBottomTagVisible(roleRightBottomTagVisible);
			MediumTrialRoleRightBottomTag trialRoleRightBottomTagVisible = null;
			if (parameters.IsTrialRoleVisible.GetValueOrDefault())
			{
				trialRoleRightBottomTagVisible = new MediumTrialRoleRightBottomTag
				{
					IsTrialRole = parameters.IsTrialRoleVisible.GetValueOrDefault(),
					TrialRoleId = parameters.ItemConfigId.GetValueOrDefault()
				};
			}
			this.SetTrialRoleRightBottomTagVisible(trialRoleRightBottomTagVisible);
			this.SetLevelAndLock(parameters.Level, parameters.IsShowLock, parameters.IsLevelTextUseChangeColor, null, null, null);
			this.SetNewVisible(new bool?(parameters.IsNewVisible.GetValueOrDefault()));
			this.SetRoleCost(parameters.ShowCostData);
			this.SetHalfAreaInfo(parameters.HalfAreaInfo);
			this.SetWeeklyRogueTag(parameters.IsShowWeeklyRogueTag);
			this.SetLevelAndStar(parameters.LvAndStar);
			this.SetRoleDevTag(parameters.RoleDevTag);
			this.SetRoleDevelopTagMark(parameters.IsRoleDevelopTagMark);
			this.SetAddLevel(parameters.AddLevel);
			this.SetRoleSkillBranch(parameters.SkillBranchIndex, parameters.ItemConfigId, parameters.IsTrialRoleVisible);
			this.SetArchiveIcon(parameters.IsShowArchive);
			this.SetRoleSkillBranch(parameters.SkillBranchIndex, null, null);
			this.ApplyCharacterBaseDisplay(parameters);
		}

		// Token: 0x0603CC36 RID: 248886 RVA: 0x00F6E0F7 File Offset: 0x00F6C2F7
		[NullableContext(1)]
		private void ApplyForecastCharacterMediumItemGrid(ForecastCharacterMediumItemGrid parameters)
		{
			this.ApplyForecastCharacterBaseDisplay(parameters);
		}

		// Token: 0x0603CC37 RID: 248887 RVA: 0x00F6E100 File Offset: 0x00F6C300
		[NullableContext(1)]
		private void ApplyKurotatoWeaponMediumItemGrid(KurotatoMediumItemGrid param)
		{
			UUITexture texture = base.GetTexture(1);
			if (texture != null)
			{
				texture.SetUIActive(true);
			}
			if (param.CardType == EKurotatoCardType.Weapon)
			{
				string icon = ConfigBase<KurotatoConfig>.Instance.GetWeaponGroupConfigByWeaponId(param.Id).Value.Icon;
				base.SetTextureByPath(icon, texture, null, null);
				this.SetBottomTextId(param.BottomTextId, param.BottomTextParameter);
				this.SetBottomText(param.BottomText);
				this.SetSkinQuality(null);
			}
			else
			{
				string icon2 = ConfigBase<KurotatoConfig>.Instance.GetItemConfigByItemId(param.Id).Value.Icon;
				base.SetTextureByPath(icon2, texture, null, null);
				this.SetBottomTextId(param.BottomTextId, param.BottomTextParameter);
				this.SetBottomText(param.BottomText);
				this.SetSkinQuality(null);
				this.SetRightTopValueInfo(param.RightTopValue);
			}
			this.SetNewVisible(param.IsNewVisible);
			this.SetIsDisable(param.IsDisable);
			this.SetLevelAndLock(null, param.IsDisable, null, null, null, null);
			this.SetKurotatoItemQuality(param);
			this.SetBottomTextVisible(true);
			this.SetBgVisible(true);
			base.SetExtendToggleEnable(true, false);
		}

		// Token: 0x0603CC38 RID: 248888 RVA: 0x00F6E270 File Offset: 0x00F6C470
		[NullableContext(1)]
		private void SetKurotatoItemQuality(KurotatoMediumItemGrid param)
		{
			int id = param.Id;
			UUISprite sprite = base.GetSprite(0);
			if (this.QualityItemConfigId == id)
			{
				sprite.SetUIActive(true);
				return;
			}
			this.SetSpriteByPath(ConfigBase<KurotatoConfig>.Instance.GetQualityByQuality(param.QualityId.Value).Value.MediumItemGridQualitySpritePath, sprite, true, null, null);
			sprite.SetUIActive(true);
			this.QualityItemConfigId = id;
		}

		// Token: 0x0603CC39 RID: 248889 RVA: 0x00F6E2E3 File Offset: 0x00F6C4E3
		public void SetWeeklyRogueTag(bool? isShowWeeklyRogueTag)
		{
			base.RefreshComponent(typeof(MediumItemGridWeeklyRogueTagComponent), new bool?(isShowWeeklyRogueTag.GetValueOrDefault()), isShowWeeklyRogueTag);
		}

		// Token: 0x0603CC3A RID: 248890 RVA: 0x00F6E308 File Offset: 0x00F6C508
		public void SetRogueFinish(bool? isRogueFinish)
		{
			base.RefreshComponent(typeof(MediumItemGridRogueFinishComponent), new bool?(isRogueFinish.GetValueOrDefault()), isRogueFinish);
		}

		// Token: 0x0603CC3B RID: 248891 RVA: 0x00F6E32D File Offset: 0x00F6C52D
		public void SetGreenSelected(bool? isShowSelect)
		{
			base.RefreshComponent(typeof(MediumItemGridVisionGreenSelectComponent), new bool?(isShowSelect.GetValueOrDefault()), isShowSelect);
		}

		// Token: 0x0603CC3C RID: 248892 RVA: 0x00F6E352 File Offset: 0x00F6C552
		public void SetWarningIcon(bool? isShowSelect)
		{
			base.RefreshComponent(typeof(MediumItemGridVisionWarningComponent), isShowSelect, isShowSelect);
		}

		// Token: 0x0603CC3D RID: 248893 RVA: 0x00F6E36C File Offset: 0x00F6C56C
		public void SetDangoRoleHead(DangoRoleHeadInfo roleHeadInfo)
		{
			Type typeFromHandle = typeof(MediumItemGridDangoRoleHeadComponent);
			bool value;
			if (roleHeadInfo != null)
			{
				int? dangoConfigId = roleHeadInfo.DangoConfigId;
				int num = 0;
				value = (dangoConfigId.GetValueOrDefault() > num & dangoConfigId != null);
			}
			else
			{
				value = false;
			}
			ItemGridComponent itemGridComponent = base.RefreshComponent(typeFromHandle, new bool?(value), roleHeadInfo);
			if (itemGridComponent == null)
			{
				return;
			}
			ItemGridComponent component = itemGridComponent;
			bool bVisible;
			if (roleHeadInfo != null)
			{
				int? dangoConfigId = roleHeadInfo.DangoConfigId;
				int num = 0;
				bVisible = (dangoConfigId.GetValueOrDefault() > num & dangoConfigId != null);
			}
			else
			{
				bVisible = false;
			}
			base.SetComponentVisible(component, bVisible);
		}

		// Token: 0x0603CC3E RID: 248894 RVA: 0x00F6E3DD File Offset: 0x00F6C5DD
		public void SetDangoPluginIcon(IDangoPluginIconInfo dangoPluginIconInfo)
		{
			base.RefreshComponent(typeof(MediumItemGridDangoPluginIconComponent), new bool?(true), dangoPluginIconInfo);
		}

		// Token: 0x0603CC3F RID: 248895 RVA: 0x00F6E3F8 File Offset: 0x00F6C5F8
		public void SetBuffSprite(EMediumItemGridBuffType? buffIconType)
		{
			Type typeFromHandle = typeof(MediumItemGridBuffIconComponent);
			bool value;
			if (buffIconType != null)
			{
				EMediumItemGridBuffType? emediumItemGridBuffType = buffIconType;
				EMediumItemGridBuffType emediumItemGridBuffType2 = EMediumItemGridBuffType.None;
				value = !(emediumItemGridBuffType.GetValueOrDefault() == emediumItemGridBuffType2 & emediumItemGridBuffType != null);
			}
			else
			{
				value = false;
			}
			base.RefreshComponent(typeFromHandle, new bool?(value), buffIconType);
		}

		// Token: 0x0603CC40 RID: 248896 RVA: 0x00F6E446 File Offset: 0x00F6C646
		public void SetIsPhantomLock(bool? isPhantomLock)
		{
			base.RefreshComponent(typeof(MediumItemGridPhantomLockComponent), new bool?(isPhantomLock.GetValueOrDefault()), isPhantomLock);
		}

		// Token: 0x0603CC41 RID: 248897 RVA: 0x00F6E46C File Offset: 0x00F6C66C
		public void SetLevelAndLock(int? level, bool? isLockVisible, bool? isLevelUseChangeColor = null, bool? isUseVision = null, bool? isDeprecate = null, bool? isLevelInfinite = null)
		{
			MediumLevelAndLock @params = new MediumLevelAndLock
			{
				Level = level,
				IsLevelInfinite = isLevelInfinite,
				IsLockVisible = isLockVisible,
				IsLevelUseChangeColor = isLevelUseChangeColor,
				IsUseVision = isUseVision,
				IsDeprecate = isDeprecate
			};
			base.RefreshComponent(typeof(MediumItemGridLevelAndLockComponent), new bool?(level != null || isLockVisible.GetValueOrDefault() || isLevelInfinite.GetValueOrDefault()), @params);
		}

		// Token: 0x0603CC42 RID: 248898 RVA: 0x00F6E4E0 File Offset: 0x00F6C6E0
		public void SetLevelAndStar(IMediumLevelAndStar data)
		{
			base.RefreshComponent(typeof(MediumItemGridLvAndStarComponent), new bool?((data != null && data.Level != null) || (data != null && data.Star != null)), data);
		}

		// Token: 0x0603CC43 RID: 248899 RVA: 0x00F6E52E File Offset: 0x00F6C72E
		public void SetItemPrice(IMediumItemPrice data)
		{
			base.RefreshComponent(typeof(MediumItemGridItemPriceComponent), new bool?(data != null), data);
		}

		// Token: 0x0603CC44 RID: 248900 RVA: 0x00F6E54B File Offset: 0x00F6C74B
		public void SetFrameEffectVisible(bool? bVisible)
		{
			base.RefreshComponent(typeof(MediumItemGridFrameEffectComponent), new bool?(bVisible.GetValueOrDefault()), bVisible);
		}

		// Token: 0x0603CC45 RID: 248901 RVA: 0x00F6E570 File Offset: 0x00F6C770
		public void SetRedDotVisible(bool? isRedDotVisible)
		{
			base.RefreshComponent(typeof(MediumItemGridRedDotComponent), new bool?(isRedDotVisible.GetValueOrDefault()), isRedDotVisible);
		}

		// Token: 0x0603CC46 RID: 248902 RVA: 0x00F6E595 File Offset: 0x00F6C795
		public void SetNewVisible(bool? isNewVisible)
		{
			base.RefreshComponent(typeof(MediumItemGridNewFlagComponent), new bool?(isNewVisible.GetValueOrDefault()), isNewVisible);
		}

		// Token: 0x0603CC47 RID: 248903 RVA: 0x00F6E5BA File Offset: 0x00F6C7BA
		public void SetStartLevel(int? startLevel)
		{
		}

		// Token: 0x0603CC48 RID: 248904 RVA: 0x00F6E5BC File Offset: 0x00F6C7BC
		public void SetRoleHead(RoleHeadInfo roleHeadInfo)
		{
			Type typeFromHandle = typeof(MediumItemGridRoleHeadComponent);
			bool value;
			if (roleHeadInfo != null)
			{
				int? roleConfigId = roleHeadInfo.RoleConfigId;
				int num = 0;
				value = (roleConfigId.GetValueOrDefault() > num & roleConfigId != null);
			}
			else
			{
				value = false;
			}
			base.RefreshComponent(typeFromHandle, new bool?(value), roleHeadInfo);
		}

		// Token: 0x0603CC49 RID: 248905 RVA: 0x00F6E604 File Offset: 0x00F6C804
		public void SetVisionRoleHead(VisionRoleHeadInfo roleHeadInfo)
		{
			Type typeFromHandle = typeof(MediumItemGridVisionRoleHeadComponent);
			bool value;
			if (roleHeadInfo != null)
			{
				int? roleConfigId = roleHeadInfo.RoleConfigId;
				int num = 0;
				value = (roleConfigId.GetValueOrDefault() > num & roleConfigId != null);
			}
			else
			{
				value = false;
			}
			base.RefreshComponent(typeFromHandle, new bool?(value), roleHeadInfo);
		}

		// Token: 0x0603CC4A RID: 248906 RVA: 0x00F6E64C File Offset: 0x00F6C84C
		public void SetPhantomIsSpecialSkill(EMediumItemGridPhantomSpecialSkill? specialSkill)
		{
			bool flag;
			if (specialSkill != null)
			{
				EMediumItemGridPhantomSpecialSkill? emediumItemGridPhantomSpecialSkill = specialSkill;
				EMediumItemGridPhantomSpecialSkill emediumItemGridPhantomSpecialSkill2 = EMediumItemGridPhantomSpecialSkill.Hide;
				flag = !(emediumItemGridPhantomSpecialSkill.GetValueOrDefault() == emediumItemGridPhantomSpecialSkill2 & emediumItemGridPhantomSpecialSkill != null);
			}
			else
			{
				flag = false;
			}
			bool value = flag;
			base.RefreshComponent(typeof(MediumItemGridPhantomSpecialSkillComponent), new bool?(value), specialSkill);
		}

		// Token: 0x0603CC4B RID: 248907 RVA: 0x00F6E69C File Offset: 0x00F6C89C
		public void SetPhantomSortNum(int? sortNum)
		{
			bool flag;
			if (sortNum != null)
			{
				int? num = sortNum;
				int num2 = 0;
				flag = (num.GetValueOrDefault() > num2 & num != null);
			}
			else
			{
				flag = false;
			}
			bool value = flag;
			base.RefreshComponent(typeof(MediumItemGridPhantomSortNumComponent), new bool?(value), sortNum);
		}

		// Token: 0x0603CC4C RID: 248908 RVA: 0x00F6E6E9 File Offset: 0x00F6C8E9
		public void SetComposeIcon(MediumItemGridComposeTag composeTag)
		{
			base.RefreshComponent(typeof(MediumItemGridComposeTag), new bool?(composeTag != null), composeTag);
		}

		// Token: 0x0603CC4D RID: 248909 RVA: 0x00F6E706 File Offset: 0x00F6C906
		public void SetComposeChangeAble(bool? isChangeAble)
		{
			base.RefreshComponent(typeof(MediumItemGridChangeAbleComponent), new bool?(isChangeAble.GetValueOrDefault()), isChangeAble);
		}

		// Token: 0x0603CC4E RID: 248910 RVA: 0x00F6E72B File Offset: 0x00F6C92B
		public void SetVisionSlotState(EMediumItemGridVisionSlotState[] visionSlotStateList)
		{
			base.RefreshComponent(typeof(MediumItemGridVisionSlotComponent), new bool?(visionSlotStateList != null && visionSlotStateList.Length != 0), visionSlotStateList);
		}

		// Token: 0x0603CC4F RID: 248911 RVA: 0x00F6E74F File Offset: 0x00F6C94F
		public void SetDevelopRewardInfo(DevelopRewardInfo developRewardInfo)
		{
			base.RefreshComponent(typeof(MediumItemGridDevelopRewardComponent), new bool?(developRewardInfo != null), developRewardInfo);
		}

		// Token: 0x0603CC50 RID: 248912 RVA: 0x00F6E76C File Offset: 0x00F6C96C
		public void SetIsMainVision(bool? isMainVisionVisible)
		{
			base.RefreshComponent(typeof(MediumItemGridMainVisionComponent), new bool?(isMainVisionVisible.GetValueOrDefault()), isMainVisionVisible);
		}

		// Token: 0x0603CC51 RID: 248913 RVA: 0x00F6E794 File Offset: 0x00F6C994
		public void SetCoolDown(float? coolDown, float? totalCdTime)
		{
			MediumItemGridCoolDownComponentParams @params = new MediumItemGridCoolDownComponentParams
			{
				CoolDown = coolDown,
				TotalCdTime = totalCdTime
			};
			Type typeFromHandle = typeof(MediumItemGridCoolDownComponent);
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

		// Token: 0x0603CC52 RID: 248914 RVA: 0x00F6E7F2 File Offset: 0x00F6C9F2
		public void SetIsProhibit(bool? isProhibit)
		{
			base.RefreshComponent(typeof(MediumItemGridProhibitComponent), new bool?(isProhibit.GetValueOrDefault()), isProhibit);
		}

		// Token: 0x0603CC53 RID: 248915 RVA: 0x00F6E818 File Offset: 0x00F6CA18
		public void SetReduceButton(LongPressButton reduceButtonInfo)
		{
			bool? flag = (reduceButtonInfo != null) ? reduceButtonInfo.IsVisible : null;
			MediumItemGridReduceButtonComponent mediumItemGridReduceButtonComponent = base.RefreshComponent(typeof(MediumItemGridReduceButtonComponent), new bool?(flag.GetValueOrDefault()), reduceButtonInfo) as MediumItemGridReduceButtonComponent;
			if (mediumItemGridReduceButtonComponent == null)
			{
				return;
			}
			if (flag.GetValueOrDefault())
			{
				mediumItemGridReduceButtonComponent.BindReduceButtonCallback(new Action(this.OnClickedReduceButton));
				mediumItemGridReduceButtonComponent.BindLongPressCallback(new Action<bool>(this.OnReduceButtonLongPressActive));
				return;
			}
			mediumItemGridReduceButtonComponent.UnBindReduceButtonCallback();
			mediumItemGridReduceButtonComponent.UnBindLongPressCallback();
		}

		// Token: 0x0603CC54 RID: 248916 RVA: 0x00F6E89B File Offset: 0x00F6CA9B
		public void SetRoundCount(int? round)
		{
			base.RefreshComponent(typeof(MediumItemGridRoundCountComponent), new bool?(round != null), round);
		}

		// Token: 0x0603CC55 RID: 248917 RVA: 0x00F6E8C0 File Offset: 0x00F6CAC0
		public void SetWarningPanelInfo(MediumWarningPanelInfo info = null)
		{
			base.RefreshComponent(typeof(MediumItemGridWarningPanelComponent), new bool?(info != null), info);
		}

		// Token: 0x0603CC56 RID: 248918 RVA: 0x00F6E8E0 File Offset: 0x00F6CAE0
		public void SetSortIndex(int? sortIndex, bool highlight = false)
		{
			if (highlight)
			{
				base.RefreshComponent(typeof(MediumItemGridSortHighlightIndexComponent), new bool?(sortIndex != null), sortIndex);
				return;
			}
			base.RefreshComponent(typeof(MediumItemGridSortIndexComponent), new bool?(sortIndex != null), sortIndex);
		}

		// Token: 0x0603CC57 RID: 248919 RVA: 0x00F6E937 File Offset: 0x00F6CB37
		public void SetTeamIcon(bool? isInTeam)
		{
			base.RefreshComponent(typeof(MediumItemGridTeamIconComponent), new bool?(isInTeam != null), isInTeam);
		}

		// Token: 0x0603CC58 RID: 248920 RVA: 0x00F6E95C File Offset: 0x00F6CB5C
		[NullableContext(1)]
		public void BindReduceLongPress(Action<bool, MediumItemGrid, object> callback)
		{
			this.OnReduceButtonLongActiveCallback = callback;
		}

		// Token: 0x0603CC59 RID: 248921 RVA: 0x00F6E965 File Offset: 0x00F6CB65
		public void UnBindReduceLongPress()
		{
			this.OnReduceButtonLongActiveCallback = null;
		}

		// Token: 0x0603CC5A RID: 248922 RVA: 0x00F6E96E File Offset: 0x00F6CB6E
		private void OnReduceButtonLongPressActive(bool isShortPress)
		{
			if (this.OnReduceButtonLongActiveCallback != null)
			{
				this.OnReduceButtonLongActiveCallback(isShortPress, this, this.Data);
			}
		}

		// Token: 0x0603CC5B RID: 248923 RVA: 0x00F6E98C File Offset: 0x00F6CB8C
		private void OnClickedReduceButton()
		{
			if (this.OnClickedReduceButtonCallback != null)
			{
				MediumItemGridButtonCallback obj = new MediumItemGridButtonCallback
				{
					MediumItemGrid = this,
					Data = this.Data
				};
				this.OnClickedReduceButtonCallback(obj);
			}
		}

		// Token: 0x0603CC5C RID: 248924 RVA: 0x00F6E9C8 File Offset: 0x00F6CBC8
		public void SetCheckTickVisible(bool? isCheckTick)
		{
			MediumItemGridCheckTickComponentParams @params = new MediumItemGridCheckTickComponentParams
			{
				IsCheckTick = isCheckTick
			};
			base.RefreshComponent(typeof(MediumItemGridCheckTickComponent), new bool?(isCheckTick.GetValueOrDefault()), @params);
		}

		// Token: 0x0603CC5D RID: 248925 RVA: 0x00F6EA00 File Offset: 0x00F6CC00
		public void SetCheckTickPerformance(bool? isCheckTick, string hexColor, float? alpha, string tickHexColor)
		{
			MediumItemGridCheckTickComponentParams @params = new MediumItemGridCheckTickComponentParams
			{
				IsCheckTick = isCheckTick,
				HexColor = hexColor,
				Alpha = alpha,
				TickHexColor = tickHexColor
			};
			base.RefreshComponent(typeof(MediumItemGridCheckTickComponent), new bool?(isCheckTick.GetValueOrDefault()), @params);
		}

		// Token: 0x0603CC5E RID: 248926 RVA: 0x00F6EA4E File Offset: 0x00F6CC4E
		public void SetTimeFlagVisible(bool? isTimeFlagVisible)
		{
			base.RefreshComponent(typeof(MediumItemGridTimeFlagComponent), new bool?(isTimeFlagVisible.GetValueOrDefault()), isTimeFlagVisible);
		}

		// Token: 0x0603CC5F RID: 248927 RVA: 0x00F6EA73 File Offset: 0x00F6CC73
		public void SetReceivedFlagVisible(bool? isReceivedFlagVisible)
		{
			base.RefreshComponent(typeof(MediumItemGridReceivedComponent), new bool?(isReceivedFlagVisible.GetValueOrDefault()), isReceivedFlagVisible);
		}

		// Token: 0x0603CC60 RID: 248928 RVA: 0x00F6EA98 File Offset: 0x00F6CC98
		public void SetEmptySlotVisible(bool isVisible)
		{
			MediumItemGridEmptySlotComponent mediumItemGridEmptySlotComponent = base.RefreshComponent(typeof(MediumItemGridEmptySlotComponent), new bool?(isVisible), isVisible) as MediumItemGridEmptySlotComponent;
			if (mediumItemGridEmptySlotComponent == null)
			{
				return;
			}
			if (isVisible)
			{
				mediumItemGridEmptySlotComponent.BindEmptySlotButtonCallback(new Action(this.OnClickedEmptySlotButton));
				return;
			}
			mediumItemGridEmptySlotComponent.UnBindEmptySlotButtonCallback();
		}

		// Token: 0x0603CC61 RID: 248929 RVA: 0x00F6EAE8 File Offset: 0x00F6CCE8
		public void SetOnlyEmptyVisible(bool isVisible, OnlyEmptyItemGrid parameters)
		{
			MediumItemGridEmptyComponent mediumItemGridEmptyComponent = base.RefreshComponent(typeof(MediumItemGridEmptyComponent), new bool?(isVisible), isVisible) as MediumItemGridEmptyComponent;
			if (mediumItemGridEmptyComponent == null)
			{
				return;
			}
			mediumItemGridEmptyComponent.OnClickedCallback = ((parameters != null) ? parameters.OnClickedCallback : null);
			mediumItemGridEmptyComponent.SetClickable(parameters != null && parameters.IsClickable.GetValueOrDefault());
		}

		// Token: 0x0603CC62 RID: 248930 RVA: 0x00F6EB44 File Offset: 0x00F6CD44
		private void SetBgVisible(bool bVisible)
		{
			UUISprite sprite = base.GetSprite(3);
			if (sprite == null)
			{
				return;
			}
			sprite.SetUIActive(bVisible);
		}

		// Token: 0x0603CC63 RID: 248931 RVA: 0x00F6EB58 File Offset: 0x00F6CD58
		private void OnClickedEmptySlotButton()
		{
			if (this.OnClickedEmptySlotButtonCallback != null)
			{
				MediumItemGridButtonCallback obj = new MediumItemGridButtonCallback
				{
					MediumItemGrid = this,
					Data = this.Data
				};
				this.OnClickedEmptySlotButtonCallback(obj);
			}
		}

		// Token: 0x0603CC64 RID: 248932 RVA: 0x00F6EB92 File Offset: 0x00F6CD92
		public void SetElement(int? elementId)
		{
			base.RefreshComponent(typeof(MediumItemGridElementComponent), new bool?(elementId != null), elementId);
		}

		// Token: 0x0603CC65 RID: 248933 RVA: 0x00F6EBB7 File Offset: 0x00F6CDB7
		public void SetRecommendVisible(bool? isRecommendVisible)
		{
			base.RefreshComponent(typeof(MediumItemGridRecommendComponent), new bool?(isRecommendVisible.GetValueOrDefault()), isRecommendVisible);
		}

		// Token: 0x0603CC66 RID: 248934 RVA: 0x00F6EBDC File Offset: 0x00F6CDDC
		public void SetUnRecommendVisible(bool? isUnRecommendVisible)
		{
			base.RefreshComponent(typeof(MediumItemGridUnRecommendComponent), new bool?(isUnRecommendVisible.GetValueOrDefault()), isUnRecommendVisible);
		}

		// Token: 0x0603CC67 RID: 248935 RVA: 0x00F6EC01 File Offset: 0x00F6CE01
		public void SetIsDisable(bool? isRoleDisable)
		{
			base.RefreshComponent(typeof(MediumItemGridDisableComponent), new bool?(isRoleDisable.GetValueOrDefault()), isRoleDisable);
		}

		// Token: 0x0603CC68 RID: 248936 RVA: 0x00F6EC28 File Offset: 0x00F6CE28
		public void SetVisionFetterGroup(int? fetterGroupId)
		{
			Type typeFromHandle = typeof(MediumItemGridVisionFetterComponent);
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

		// Token: 0x0603CC69 RID: 248937 RVA: 0x00F6EC74 File Offset: 0x00F6CE74
		public bool IsDisable()
		{
			ItemGridComponent itemGridComponent = base.GetItemGridComponent(typeof(MediumItemGridDisableComponent));
			return itemGridComponent != null && itemGridComponent.GetActive();
		}

		// Token: 0x0603CC6A RID: 248938 RVA: 0x00F6EC9D File Offset: 0x00F6CE9D
		public void SetTrialRoleVisible(bool? isTrialRoleVisible)
		{
			base.RefreshComponent(typeof(MediumItemGridTimeFlagComponent), new bool?(isTrialRoleVisible.GetValueOrDefault()), isTrialRoleVisible);
		}

		// Token: 0x0603CC6B RID: 248939 RVA: 0x00F6ECC2 File Offset: 0x00F6CEC2
		public void SetRoleRightBottomTagVisible(MediumRoleRightBottomTag roleRightBottomTag)
		{
			base.RefreshComponent(typeof(MediumItemGridRoleRightBottomTag), new bool?(roleRightBottomTag != null), roleRightBottomTag);
		}

		// Token: 0x0603CC6C RID: 248940 RVA: 0x00F6ECDF File Offset: 0x00F6CEDF
		public void SetTrialRoleRightBottomTagVisible(MediumTrialRoleRightBottomTag trialRoleRightBottomTag)
		{
			base.RefreshComponent(typeof(MediumItemGridTrialRoleRightBottomTag), new bool?(trialRoleRightBottomTag != null), trialRoleRightBottomTag);
		}

		// Token: 0x0603CC6D RID: 248941 RVA: 0x00F6ECFC File Offset: 0x00F6CEFC
		public void SetIconSprite(string iconSpritePath)
		{
			UUISprite sprite = base.GetSprite(10);
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

		// Token: 0x0603CC6E RID: 248942 RVA: 0x00F6ED42 File Offset: 0x00F6CF42
		public void SetSkinIcon(int? itemConfigId)
		{
			if (itemConfigId == null)
			{
				return;
			}
			base.RefreshComponent(typeof(MediumItemGridSkinComponent), new bool?(true), itemConfigId);
		}

		// Token: 0x0603CC6F RID: 248943 RVA: 0x00F6ED6C File Offset: 0x00F6CF6C
		private void SetIconTexture(string iconPath)
		{
			UUITexture texture = base.GetTexture(1);
			if (texture == null)
			{
				return;
			}
			if (string.IsNullOrEmpty(iconPath))
			{
				texture.SetUIActive(false);
				return;
			}
			texture.SetUIActive(true);
			base.SetTextureByPath(iconPath, texture, null, null);
		}

		// Token: 0x0603CC70 RID: 248944 RVA: 0x00F6EDB0 File Offset: 0x00F6CFB0
		[NullableContext(1)]
		public void ApplyEmptyDisplay(EmptyItemGrid parameters)
		{
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

		// Token: 0x0603CC71 RID: 248945 RVA: 0x00F6EE00 File Offset: 0x00F6D000
		[NullableContext(1)]
		public void ApplyPropBaseDisplay(PropMediumItemGrid parameters)
		{
			int? itemConfigId = parameters.ItemConfigId;
			string bottomTextId = parameters.BottomTextId;
			string bottomText = parameters.BottomText;
			object[] bottomTextParameter = parameters.BottomTextParameter;
			string spriteIconPath = parameters.SpriteIconPath;
			this.Data = parameters.Data;
			UUITexture texture = base.GetTexture(1);
			InventoryConfig instance = ConfigBase<InventoryConfig>.Instance;
			InventoryDefine.EItemDataType? eitemDataType = (instance != null) ? new InventoryDefine.EItemDataType?(instance.GetItemDataTypeByConfigId(parameters.ItemConfigId)) : null;
			if (parameters.IsIconHide.GetValueOrDefault())
			{
				if (texture != null)
				{
					texture.SetUIActive(false);
				}
			}
			else if (!string.IsNullOrEmpty(parameters.IconPath))
			{
				base.SetTextureByPath(parameters.IconPath, texture, null, null);
				if (texture != null)
				{
					texture.SetUIActive(true);
				}
			}
			else if (eitemDataType.GetValueOrDefault() == InventoryDefine.EItemDataType.DangoAbyssItem)
			{
				this.SetDangoItemTexture(itemConfigId);
			}
			else if (eitemDataType.GetValueOrDefault() == InventoryDefine.EItemDataType.MotorStickerItem)
			{
				this.SetMotorStickerTexture(itemConfigId.Value);
			}
			else
			{
				this.SetTexture(itemConfigId);
			}
			if (eitemDataType.GetValueOrDefault() == InventoryDefine.EItemDataType.WeaponSkinItem || eitemDataType.GetValueOrDefault() == InventoryDefine.EItemDataType.OrnamentItem)
			{
				this.SetSkinIcon(itemConfigId);
			}
			this.SetIconSprite(spriteIconPath);
			this.SetItemQuality(parameters);
			bool flag = !StringUtils.IsEmpty(bottomTextId) || !StringUtils.IsEmpty(bottomText);
			this.SetBottomTextVisible(flag);
			if (flag)
			{
				this.SetBottomTextId(bottomTextId, bottomTextParameter);
				this.SetBottomText(bottomText);
			}
			base.SetExtendToggleEnable(true, false);
			this.SetBgVisible(true);
		}

		// Token: 0x0603CC72 RID: 248946 RVA: 0x00F6EF60 File Offset: 0x00F6D160
		[NullableContext(1)]
		public void ApplyPhantomBaseDisplay(PhantomMediumItemGrid parameters)
		{
			int? itemConfigId = parameters.ItemConfigId;
			string bottomTextId = parameters.BottomTextId;
			string bottomText = parameters.BottomText;
			object[] bottomTextParameter = parameters.BottomTextParameter;
			int? monsterId = parameters.MonsterId;
			this.Data = parameters.Data;
			if (monsterId != null)
			{
				this.SetMonsterTexture(monsterId);
			}
			else
			{
				this.SetTexture(itemConfigId);
			}
			this.SetNormalItemQualityInternal(parameters.IsQualityHidden, parameters.QualityId, parameters.ItemConfigId, parameters.QualityIcon, parameters.QualityType);
			bool flag = !StringUtils.IsEmpty(bottomTextId) || !StringUtils.IsEmpty(bottomText);
			this.SetBottomTextVisible(flag);
			if (flag)
			{
				this.SetBottomTextId(bottomTextId, bottomTextParameter);
				this.SetBottomText(bottomText);
			}
			base.SetExtendToggleEnable(true, false);
			this.SetBgVisible(true);
		}

		// Token: 0x0603CC73 RID: 248947 RVA: 0x00F6F01C File Offset: 0x00F6D21C
		[NullableContext(1)]
		public void ApplyCharacterBaseDisplay(CharacterMediumItemGrid parameters)
		{
			int? itemConfigId = parameters.ItemConfigId;
			string bottomTextId = parameters.BottomTextId;
			string bottomText = parameters.BottomText;
			object[] bottomTextParameter = parameters.BottomTextParameter;
			int skinId = parameters.SkinId;
			this.Data = parameters.Data;
			UUITexture texture = base.GetTexture(1);
			int? num = itemConfigId;
			int num2 = 10000;
			if (num.GetValueOrDefault() > num2 & num != null)
			{
				itemConfigId = new int?(ConfigBase<RoleConfig>.Instance.GetTrialRoleConfig(itemConfigId.Value).Value.ParentId);
			}
			string roleHeadIconLarge = ConfigBase<SkinConfig>.Instance.GetRoleSkinConfig(skinId).Value.RoleHeadIconLarge;
			base.SetRoleSkinIcon(roleHeadIconLarge, texture, skinId, null, null);
			if (texture != null)
			{
				texture.SetUIActive(true);
			}
			this.SetNormalItemQualityInternal(parameters.IsQualityHidden, parameters.QualityId, itemConfigId, parameters.QualityIcon, parameters.QualityType);
			bool flag = !StringUtils.IsEmpty(bottomTextId) || !StringUtils.IsEmpty(bottomText);
			this.SetBottomTextVisible(flag);
			if (flag)
			{
				this.SetBottomTextId(bottomTextId, bottomTextParameter);
				this.SetBottomText(bottomText);
			}
			base.SetExtendToggleEnable(true, false);
			this.SetBgVisible(true);
		}

		// Token: 0x0603CC74 RID: 248948 RVA: 0x00F6F150 File Offset: 0x00F6D350
		[NullableContext(1)]
		public void ApplyForecastCharacterBaseDisplay(ForecastCharacterMediumItemGrid parameters)
		{
			this.Data = parameters.Data;
			RoleDisplayModelBase roleDisplayModelBase = parameters.Data as RoleDisplayModelBase;
			this.SetIconTexture(parameters.IconPath);
			this.SetElement((roleDisplayModelBase != null) ? new int?(roleDisplayModelBase.ElementId) : null);
			this.SetBottomText(parameters.BottomText);
			bool flag = !StringUtils.IsEmpty(parameters.BottomTextId) || !StringUtils.IsEmpty(parameters.BottomText);
			this.SetBottomTextVisible(flag);
			if (flag)
			{
				this.SetBottomTextId(parameters.BottomTextId, parameters.BottomTextParameter);
				this.SetBottomText(parameters.BottomText);
			}
			this.SetRoleDevTag(parameters.RoleDevTag);
			base.SetExtendToggleEnable(true, false);
			this.SetBgVisible(true);
		}

		// Token: 0x0603CC75 RID: 248949 RVA: 0x00F6F210 File Offset: 0x00F6D410
		private void SetTexture(int? itemConfigId)
		{
			UUITexture texture = base.GetTexture(1);
			if (texture == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Quest;
				ELogAuthor author = ELogAuthor.LRX;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(41, 2);
				defaultInterpolatedStringHandler.AppendFormatted(base.GetType().Name);
				defaultInterpolatedStringHandler.AppendLiteral(":GetTexture with ");
				defaultInterpolatedStringHandler.AppendFormatted<int>(1);
				defaultInterpolatedStringHandler.AppendLiteral(" return null UUITexture!");
				instance.Error(module, author, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			if (itemConfigId == null)
			{
				texture.SetUIActive(false);
				return;
			}
			int textureItemConfigId = this.TextureItemConfigId;
			int? num = itemConfigId;
			if (textureItemConfigId == num.GetValueOrDefault() & num != null)
			{
				texture.SetUIActive(true);
				return;
			}
			this.TextureItemConfigId = itemConfigId.Value;
			base.SetItemIcon(texture, itemConfigId.Value, null, null);
			texture.SetUIActive(true);
		}

		// Token: 0x0603CC76 RID: 248950 RVA: 0x00F6F2E4 File Offset: 0x00F6D4E4
		private void SetDangoItemTexture(int? itemId)
		{
			DangoPluginIconInfo dangoPluginIcon = new DangoPluginIconInfo
			{
				PluginItemId = itemId.GetValueOrDefault()
			};
			this.SetDangoPluginIcon(dangoPluginIcon);
			UUITexture texture = base.GetTexture(1);
			if (texture == null)
			{
				return;
			}
			texture.SetUIActive(false);
		}

		// Token: 0x0603CC77 RID: 248951 RVA: 0x00F6F320 File Offset: 0x00F6D520
		private void SetMonsterTexture(int? monsterId)
		{
			UUITexture texture = base.GetTexture(1);
			if (monsterId == null)
			{
				if (texture != null)
				{
					texture.SetUIActive(false);
				}
				return;
			}
			string monsterIcon = ConfigBase<MonsterInfoConfig>.Instance.GetMonsterIcon(monsterId.Value);
			base.SetTextureByPath(monsterIcon, texture, null, null);
			if (texture != null)
			{
				texture.SetUIActive(true);
			}
		}

		// Token: 0x0603CC78 RID: 248952 RVA: 0x00F6F378 File Offset: 0x00F6D578
		private void SetQuality(int? itemConfigId)
		{
			UUISprite sprite = base.GetSprite(0);
			if (itemConfigId == null)
			{
				if (sprite != null)
				{
					sprite.SetUIActive(false);
				}
				return;
			}
			int qualityItemConfigId = this.QualityItemConfigId;
			int? num = itemConfigId;
			if (qualityItemConfigId == num.GetValueOrDefault() & num != null)
			{
				if (sprite != null)
				{
					sprite.SetUIActive(true);
				}
				return;
			}
			base.SetItemQualityIcon(sprite, itemConfigId.Value, null, CommonDefine.EQualityIconType.MediumItemGridQualitySpritePath, null);
			if (sprite != null)
			{
				sprite.SetUIActive(true);
			}
			this.QualityItemConfigId = itemConfigId.Value;
		}

		// Token: 0x0603CC79 RID: 248953 RVA: 0x00F6F3F8 File Offset: 0x00F6D5F8
		private void SetDangoAbyssItemQuality(int? itemConfigId)
		{
			UUISprite sprite = base.GetSprite(0);
			if (itemConfigId == null)
			{
				if (sprite != null)
				{
					sprite.SetUIActive(false);
				}
				return;
			}
			int qualityItemConfigId = this.QualityItemConfigId;
			int? num = itemConfigId;
			if (qualityItemConfigId == num.GetValueOrDefault() & num != null)
			{
				if (sprite != null)
				{
					sprite.SetUIActive(true);
				}
				return;
			}
			this.SetSpriteByPath(ConfigBase<DangoAbyssConfig>.Instance.GetAbyssQualityByPluginItemId(itemConfigId.Value).Value.MediumItemGridQualitySpritePath, sprite, true, null, null);
			if (sprite != null)
			{
				sprite.SetUIActive(true);
			}
			this.QualityItemConfigId = itemConfigId.Value;
		}

		// Token: 0x0603CC7A RID: 248954 RVA: 0x00F6F494 File Offset: 0x00F6D694
		private void SetQualityByResourceId(string resourceId)
		{
			UUISprite sprite = base.GetSprite(0);
			if (string.IsNullOrEmpty(resourceId))
			{
				if (sprite != null)
				{
					sprite.SetUIActive(false);
				}
				return;
			}
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resourceId);
			if (StringUtils.IsEmpty(resourcePath))
			{
				if (sprite != null)
				{
					sprite.SetUIActive(false);
				}
				return;
			}
			this.SetSpriteByPath(resourcePath, sprite, true, null, null);
			if (sprite != null)
			{
				sprite.SetUIActive(true);
			}
		}

		// Token: 0x0603CC7B RID: 248955 RVA: 0x00F6F4F8 File Offset: 0x00F6D6F8
		private void SetQualityByPath(string path)
		{
			UUISprite sprite = base.GetSprite(0);
			bool flag = !string.IsNullOrEmpty(path);
			if (sprite != null)
			{
				sprite.SetUIActive(flag);
			}
			if (flag)
			{
				this.SetSpriteByPath(path, sprite, false, null, null);
			}
		}

		// Token: 0x0603CC7C RID: 248956 RVA: 0x00F6F538 File Offset: 0x00F6D738
		public void SetSkinQuality(int? itemConfigId)
		{
			UUISprite sprite = base.GetSprite(8);
			if (itemConfigId == null)
			{
				if (sprite != null)
				{
					sprite.SetUIActive(false);
				}
				return;
			}
			int qualityItemConfigId = this.QualityItemConfigId;
			int? num = itemConfigId;
			if (qualityItemConfigId == num.GetValueOrDefault() & num != null)
			{
				if (sprite != null)
				{
					sprite.SetUIActive(true);
				}
				return;
			}
			UUISprite sprite2 = base.GetSprite(0);
			if (sprite2 != null)
			{
				sprite2.SetUIActive(false);
			}
			this.QualityItemConfigId = itemConfigId.Value;
			ItemConfig itemConfigData = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(itemConfigId.Value);
			this.SetSpriteByPath(ConfigBase<CommonConfig>.Instance.GetItemQualityById(itemConfigData.QualityId).Value.SkinQualityItemA, sprite, false, null, null);
			if (sprite != null)
			{
				sprite.SetUIActive(true);
			}
		}

		// Token: 0x0603CC7D RID: 248957 RVA: 0x00F6F5F8 File Offset: 0x00F6D7F8
		[NullableContext(1)]
		private void SetPinballItemQuality(MediumItemGridBase parameters)
		{
			if (parameters == null || parameters.ItemConfigId == null)
			{
				UUISprite sprite = base.GetSprite(0);
				if (sprite == null)
				{
					return;
				}
				sprite.SetUIActive(false);
				return;
			}
			else
			{
				InventoryConfig instance = ConfigBase<InventoryConfig>.Instance;
				ItemConfig itemConfig = (instance != null) ? instance.GetItemConfigData(parameters.ItemConfigId.Value) : null;
				if (itemConfig != null)
				{
					this.SetNormalItemQualityInternal(parameters.IsQualityHidden, new int?(parameters.QualityId ?? itemConfig.QualityId), parameters.ItemConfigId, parameters.QualityIcon, new CommonDefine.EQualityIconType?(parameters.QualityType.GetValueOrDefault(CommonDefine.EQualityIconType.TypeAGridQualitySpritePath)));
					return;
				}
				UUISprite sprite2 = base.GetSprite(0);
				if (sprite2 == null)
				{
					return;
				}
				sprite2.SetUIActive(false);
				return;
			}
		}

		// Token: 0x0603CC7E RID: 248958 RVA: 0x00F6F6A8 File Offset: 0x00F6D8A8
		[NullableContext(1)]
		private void SetItemQuality(MediumItemGridBase parameters)
		{
			int? itemConfigId = parameters.ItemConfigId;
			bool? isQualityHidden = parameters.IsQualityHidden;
			int? qualityId = parameters.QualityId;
			string qualityIcon = parameters.QualityIcon;
			CommonDefine.EQualityIconType? qualityType = parameters.QualityType;
			UUISprite sprite = base.GetSprite(0);
			if (isQualityHidden.GetValueOrDefault())
			{
				if (sprite != null)
				{
					sprite.SetUIActive(false);
				}
				return;
			}
			if (!string.IsNullOrEmpty(qualityIcon))
			{
				this.SetQualityByPath(qualityIcon);
				this.QualityItemConfigId = itemConfigId.GetValueOrDefault();
				return;
			}
			if (qualityId != null)
			{
				int? num = qualityId;
				int num2 = 0;
				if (num.GetValueOrDefault() > num2 & num != null)
				{
					base.SetQualityIconById(sprite, qualityId.Value, null, new CommonDefine.EQualityIconType?(qualityType.GetValueOrDefault(CommonDefine.EQualityIconType.MediumItemGridQualitySpritePath)), null);
					if (sprite != null)
					{
						sprite.SetUIActive(true);
					}
					this.QualityItemConfigId = itemConfigId.GetValueOrDefault();
					return;
				}
			}
			InventoryConfig instance = ConfigBase<InventoryConfig>.Instance;
			InventoryDefine.EItemDataType? eitemDataType = (instance != null) ? new InventoryDefine.EItemDataType?(instance.GetItemDataTypeByConfigId(parameters.ItemConfigId)) : null;
			if (eitemDataType != null)
			{
				InventoryDefine.EItemDataType valueOrDefault = eitemDataType.GetValueOrDefault();
				if (valueOrDefault == InventoryDefine.EItemDataType.WeaponSkinItem)
				{
					this.SetSkinQuality(parameters.ItemConfigId);
					return;
				}
				if (valueOrDefault == InventoryDefine.EItemDataType.DangoAbyssItem)
				{
					this.SetDangoAbyssItemQuality(parameters.ItemConfigId);
					return;
				}
				if (valueOrDefault - InventoryDefine.EItemDataType.PinballRoleItem <= 1)
				{
					this.SetPinballItemQuality(parameters);
					return;
				}
			}
			this.SetSkinQuality(null);
			this.SetQuality(itemConfigId);
		}

		// Token: 0x0603CC7F RID: 248959 RVA: 0x00F6F804 File Offset: 0x00F6DA04
		private void SetNormalItemQualityInternal(bool? isQualityHidden, int? qualityId, int? itemConfigId, string qualityIcon, CommonDefine.EQualityIconType? qualityType)
		{
			UUISprite sprite = base.GetSprite(0);
			if (isQualityHidden.GetValueOrDefault())
			{
				if (sprite != null)
				{
					sprite.SetUIActive(false);
				}
				return;
			}
			if (!string.IsNullOrEmpty(qualityIcon))
			{
				this.SetQualityByPath(qualityIcon);
				this.QualityItemConfigId = itemConfigId.GetValueOrDefault();
				return;
			}
			if (qualityId != null)
			{
				int? num = qualityId;
				int num2 = 0;
				if (num.GetValueOrDefault() > num2 & num != null)
				{
					base.SetQualityIconById(sprite, qualityId.Value, null, new CommonDefine.EQualityIconType?(qualityType.GetValueOrDefault(CommonDefine.EQualityIconType.MediumItemGridQualitySpritePath)), null);
					if (sprite != null)
					{
						sprite.SetUIActive(true);
					}
					this.QualityItemConfigId = itemConfigId.GetValueOrDefault();
					return;
				}
			}
			this.SetQuality(itemConfigId);
		}

		// Token: 0x0603CC80 RID: 248960 RVA: 0x00F6F8B4 File Offset: 0x00F6DAB4
		private void SetMotorStickerTexture(int itemId)
		{
			UUITexture texture = base.GetTexture(1);
			MotorDiyConfig instance = ConfigBase<MotorDiyConfig>.Instance;
			MotorSticker? motorSticker;
			string text = (instance != null) ? ((instance.GetMotorStickerConfig(itemId) != null) ? motorSticker.GetValueOrDefault().IconMiddle : null) : null;
			if (string.IsNullOrEmpty(text))
			{
				if (texture != null)
				{
					texture.SetUIActive(false);
				}
				return;
			}
			base.SetTextureByPath(text, texture, null, null);
			if (texture != null)
			{
				texture.SetUIActive(true);
			}
		}

		// Token: 0x0603CC81 RID: 248961 RVA: 0x00F6F928 File Offset: 0x00F6DB28
		public void SetCurTagIcon(bool? isShow)
		{
			base.RefreshComponent(typeof(MediumItemGridCurTagComponent), isShow, isShow);
		}

		// Token: 0x0603CC82 RID: 248962 RVA: 0x00F6F944 File Offset: 0x00F6DB44
		public void SetBottomTextVisible(bool bVisible)
		{
			UUIText text = base.GetText(2);
			if (text != null && text.IsUIActiveSelf() == bVisible)
			{
				return;
			}
			if (text != null)
			{
				text.SetUIActive(bVisible);
			}
		}

		// Token: 0x0603CC83 RID: 248963 RVA: 0x00F6F970 File Offset: 0x00F6DB70
		public void SetBottomTextId(string textId, [Nullable(new byte[]
		{
			2,
			1
		})] object[] textParameter)
		{
			UUIText text = base.GetText(2);
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

		// Token: 0x0603CC84 RID: 248964 RVA: 0x00F6F9B0 File Offset: 0x00F6DBB0
		public void SetBottomText(string text)
		{
			UUIText text2 = base.GetText(2);
			if (StringUtils.IsEmpty(text))
			{
				return;
			}
			if (text2 != null)
			{
				text2.SetText(text, true);
			}
		}

		// Token: 0x0603CC85 RID: 248965 RVA: 0x00F6F9D9 File Offset: 0x00F6DBD9
		[NullableContext(1)]
		public void BindReduceButtonCallback(Action<MediumItemGridButtonCallback> onClickedReduceButton, [Nullable(2)] object data = null)
		{
			this.OnClickedReduceButtonCallback = onClickedReduceButton;
		}

		// Token: 0x0603CC86 RID: 248966 RVA: 0x00F6F9E2 File Offset: 0x00F6DBE2
		public void UnBindReduceButtonCallback()
		{
			this.OnClickedReduceButtonCallback = null;
		}

		// Token: 0x0603CC87 RID: 248967 RVA: 0x00F6F9EB File Offset: 0x00F6DBEB
		[NullableContext(1)]
		public void BindEmptySlotButtonCallback(Action<MediumItemGridButtonCallback> onClickedEmptySlotButton)
		{
			this.OnClickedEmptySlotButtonCallback = onClickedEmptySlotButton;
		}

		// Token: 0x0603CC88 RID: 248968 RVA: 0x00F6F9F4 File Offset: 0x00F6DBF4
		public void UnBindEmptySlotButtonCallback()
		{
			this.OnClickedEmptySlotButtonCallback = null;
		}

		// Token: 0x0603CC89 RID: 248969 RVA: 0x00F6F9FD File Offset: 0x00F6DBFD
		public override UUIExtendToggle GetItemGridExtendToggle()
		{
			return base.GetExtendToggle(6);
		}

		// Token: 0x0603CC8A RID: 248970 RVA: 0x00F6FA06 File Offset: 0x00F6DC06
		private void SetRoleCost(MediumItemGridCostComponentData costData)
		{
			base.RefreshComponent(typeof(MediumItemGridCostComponent), new bool?(costData != null), costData);
		}

		// Token: 0x0603CC8B RID: 248971 RVA: 0x00F6FA23 File Offset: 0x00F6DC23
		[NullableContext(1)]
		public void SetBottomTextColor(string hexColor)
		{
			UUIText text = base.GetText(2);
			if (text == null)
			{
				return;
			}
			text.SetColor(FColor.FromHex(hexColor));
		}

		// Token: 0x0603CC8C RID: 248972 RVA: 0x00F6FA3C File Offset: 0x00F6DC3C
		public void SetHalfAreaInfo(HaveAreaInfo info)
		{
			bool value = info != null;
			base.RefreshComponent(typeof(MediumItemGridHalfAreaComponent), new bool?(value), info);
		}

		// Token: 0x0603CC8D RID: 248973 RVA: 0x00F6FA66 File Offset: 0x00F6DC66
		public void SetUpGradeVisible(bool? visible)
		{
			base.RefreshComponent(typeof(MediumItemGridUpgradeComponent), new bool?(visible.GetValueOrDefault()), visible);
		}

		// Token: 0x0603CC8E RID: 248974 RVA: 0x00F6FA8C File Offset: 0x00F6DC8C
		public void SetTagsInfo([Nullable(new byte[]
		{
			2,
			1
		})] string[] tags)
		{
			bool value = tags != null && tags.Length != 0;
			base.RefreshComponent(typeof(MediumItemGridTagsComponent), new bool?(value), tags);
		}

		// Token: 0x0603CC8F RID: 248975 RVA: 0x00F6FAC0 File Offset: 0x00F6DCC0
		public void SetRightTopValueInfo(string value)
		{
			bool value2 = !string.IsNullOrEmpty(value);
			base.RefreshComponent(typeof(MediumItemGridRightTopValueComponent), new bool?(value2), value);
		}

		// Token: 0x0603CC90 RID: 248976 RVA: 0x00F6FAEF File Offset: 0x00F6DCEF
		public void SetIsBranchUpgrade(bool? isShow)
		{
			base.RefreshComponent(typeof(MediumItemGridBranchUpgradeComponent), new bool?(isShow.GetValueOrDefault()), isShow);
		}

		// Token: 0x0603CC91 RID: 248977 RVA: 0x00F6FB14 File Offset: 0x00F6DD14
		public void SetSubIconPath(string path)
		{
			base.RefreshComponent(typeof(MediumItemGridSubIconComponent), new bool?(!string.IsNullOrEmpty(path)), path);
		}

		// Token: 0x0603CC92 RID: 248978 RVA: 0x00F6FB36 File Offset: 0x00F6DD36
		public void SetRoleDevTag(ERoleDevelopHotRoleTag? tagType)
		{
			base.RefreshComponent(typeof(MediumItemGridRoleDevTagComponent), new bool?(tagType != null), tagType);
		}

		// Token: 0x0603CC93 RID: 248979 RVA: 0x00F6FB5B File Offset: 0x00F6DD5B
		public void SetRoleDevelopTagMark(bool? isRoleDevelopTagMarkVisible)
		{
			base.RefreshComponent(typeof(MediumItemGridRoleDevelopTagMarkComponent), new bool?(isRoleDevelopTagMarkVisible.GetValueOrDefault()), isRoleDevelopTagMarkVisible);
		}

		// Token: 0x0603CC94 RID: 248980 RVA: 0x00F6FB80 File Offset: 0x00F6DD80
		public void SetRoleSkillBranch(int? index, int? itemConfigId = null, bool? isTrialRoleVisible = null)
		{
			int? num = index;
			if (num != null && itemConfigId != null && !isTrialRoleVisible.GetValueOrDefault())
			{
				int num2 = itemConfigId.Value;
				if (num2 > 10000)
				{
					num2 = ConfigBase<RoleConfig>.Instance.GetTrialRoleConfig(num2).Value.ParentId;
				}
				if (!ModelBase<RoleModel>.Instance.IsHasRole(num2))
				{
					num = null;
				}
			}
			base.RefreshComponent(typeof(MediumItemGridRoleSkillBranchComponent), new bool?(num != null), num);
		}

		// Token: 0x0603CC95 RID: 248981 RVA: 0x00F6FC0E File Offset: 0x00F6DE0E
		public void SetAddLevel(int? addLevel)
		{
			base.RefreshComponent(typeof(MediumItemGridAddLevelComponent), new bool?(addLevel != null), addLevel);
		}

		// Token: 0x0603CC96 RID: 248982 RVA: 0x00F6FC33 File Offset: 0x00F6DE33
		public void SetArchiveIcon(bool? isShow)
		{
			base.RefreshComponent(typeof(MediumItemGridArchiveComponent), new bool?(isShow.GetValueOrDefault()), isShow);
		}

		// Token: 0x0603CC97 RID: 248983 RVA: 0x00F6FC58 File Offset: 0x00F6DE58
		public void SetWarningTips(bool? isShow)
		{
			base.RefreshComponent(typeof(MediumItemGridWarningTipsComponent), new bool?(isShow.GetValueOrDefault()), isShow);
		}

		// Token: 0x0603CC98 RID: 248984 RVA: 0x00F6FC7D File Offset: 0x00F6DE7D
		public void SetUpgradeArrow(bool? isShow)
		{
			base.RefreshComponent(typeof(MediumItemGridUpgradeArrowComponent), new bool?(isShow.GetValueOrDefault()), isShow);
		}

		// Token: 0x0603CC99 RID: 248985 RVA: 0x00F6FCA2 File Offset: 0x00F6DEA2
		public void SetTemplateIcon(bool? isShow)
		{
			base.RefreshComponent(typeof(MediumItemGridTemplateIconComponent), new bool?(isShow.GetValueOrDefault()), isShow);
		}

		// Token: 0x040221B5 RID: 139701
		private const int TRIAL_ROLE_ID = 10000;

		// Token: 0x040221B6 RID: 139702
		private int TextureItemConfigId;

		// Token: 0x040221B7 RID: 139703
		private int QualityItemConfigId;

		// Token: 0x040221B8 RID: 139704
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Action<MediumItemGridButtonCallback> OnClickedReduceButtonCallback;

		// Token: 0x040221B9 RID: 139705
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Action<MediumItemGridButtonCallback> OnClickedEmptySlotButtonCallback;

		// Token: 0x040221BA RID: 139706
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private Action<bool, MediumItemGrid, object> OnReduceButtonLongActiveCallback;

		// Token: 0x0200BE78 RID: 48760
		[NullableContext(0)]
		private class EChildType
		{
			// Token: 0x0403AA5A RID: 240218
			public const int QualitySprite = 0;

			// Token: 0x0403AA5B RID: 240219
			public const int ItemTexture = 1;

			// Token: 0x0403AA5C RID: 240220
			public const int BottomText = 2;

			// Token: 0x0403AA5D RID: 240221
			public const int BgSprite = 3;

			// Token: 0x0403AA5E RID: 240222
			public const int TopAdditionItem = 4;

			// Token: 0x0403AA5F RID: 240223
			public const int BottomAdditionItem = 5;

			// Token: 0x0403AA60 RID: 240224
			public const int ExtendToggle = 6;

			// Token: 0x0403AA61 RID: 240225
			public const int UnderTextAdditionItem = 7;

			// Token: 0x0403AA62 RID: 240226
			public const int SkinQualitySprite = 8;

			// Token: 0x0403AA63 RID: 240227
			public const int AniLoop = 9;

			// Token: 0x0403AA64 RID: 240228
			public const int ItemSprite = 10;
		}
	}
}
