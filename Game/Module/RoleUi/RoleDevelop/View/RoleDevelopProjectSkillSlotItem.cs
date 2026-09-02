using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.RoleDev;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.RoleUi.RoleDevelop.View
{
	// Token: 0x020050C2 RID: 20674
	public class RoleDevelopProjectSkillSlotItem : UiPanelBase
	{
		// Token: 0x06035442 RID: 218178 RVA: 0x00D5BBE8 File Offset: 0x00D59DE8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 6;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISpriteTransition));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUITexture));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnSkillSlotClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06035443 RID: 218179 RVA: 0x00D5BD12 File Offset: 0x00D59F12
		[NullableContext(1)]
		public void Refresh(RoleDevelopSkillData data)
		{
			this.Data = data;
			this.RefreshView();
		}

		// Token: 0x06035444 RID: 218180 RVA: 0x00D5BD24 File Offset: 0x00D59F24
		private void RefreshView()
		{
			RoleDevelopSkillData data = this.Data;
			bool flag = RoleDevelopUtil.IsAnyProspectRole(data.RoleId);
			UUIText text = base.GetText(2);
			base.GetSprite(1).SetUIActive(flag);
			base.GetUiSpriteTransition(0).RootUIComp.Get().SetUIActive(!flag);
			UUISprite sprite = base.GetSprite(0);
			if (sprite != null)
			{
				UUIItem uuiitem = sprite;
				bool bUseChangeColor = flag;
				FColor? fcolor = new FColor?(sprite.changeColor);
				uuiitem.SetChangeColor(bUseChangeColor, fcolor);
			}
			int currentLevel = data.CurrentLevel;
			if (flag)
			{
				Singleton<LguiUtil>.Instance.SetLocalText(text, "LevelRichText", new <>z__ReadOnlyArray<object>(new object[]
				{
					currentLevel,
					data.TargetLevel
				}));
				base.GetItem(4).SetUIActive(false);
			}
			else
			{
				int targetLevel = data.TargetLevel;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(4, 2);
				defaultInterpolatedStringHandler.AppendLiteral("Lv.");
				defaultInterpolatedStringHandler.AppendFormatted<int>(currentLevel);
				defaultInterpolatedStringHandler.AppendLiteral("/");
				defaultInterpolatedStringHandler.AppendFormatted<int>(targetLevel);
				string item = defaultInterpolatedStringHandler.ToStringAndClear();
				if (currentLevel >= targetLevel)
				{
					Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "RoleProject_SkillLevel01", new <>z__ReadOnlySingleElementList<object>(item));
				}
				else
				{
					Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "RoleProject_SkillLevel02", new <>z__ReadOnlySingleElementList<object>(item));
				}
				SkillTree? skillTreeNode = ConfigBase<RoleSkillConfig>.Instance.GetSkillTreeNode(data.SkillNodeId);
				string path;
				if (skillTreeNode.Value.SkillId > 0)
				{
					path = ConfigBase<RoleSkillConfig>.Instance.GetSkillConfigById(skillTreeNode.Value.SkillId).Value.Icon;
				}
				else
				{
					path = skillTreeNode.Value.PropertyNodeIcon;
				}
				base.SetSpriteTransitionByPath(path, base.GetUiSpriteTransition(0), EUISelectableSelectionState.EUISelectableSelectionState_MAX);
				this.RefreshShowTag(skillTreeNode.Value.SkillId);
			}
			bool selfInteractive = ModelBase<RoleModel>.Instance.IsRoleOwned(data.RoleId);
			base.GetButton(3).SetSelfInteractive(selfInteractive);
		}

		// Token: 0x06035445 RID: 218181 RVA: 0x00D5BF18 File Offset: 0x00D5A118
		private void RefreshShowTag(int skillId)
		{
			UUIItem item = base.GetItem(4);
			UUITexture texture = base.GetTexture(5);
			int skillShowTagType = ConfigBase<RoleSkillConfig>.Instance.GetSkillConfigById(skillId).Value.SkillShowTagType;
			item.SetUIActive(skillShowTagType != 0);
			if (skillShowTagType == 1)
			{
				string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("T_RoleDevelopRecommendA");
				base.SetTextureByPath(resourcePath, texture, null, null);
				return;
			}
			if (skillShowTagType == 2)
			{
				string resourcePath2 = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("T_RoleDevelopRecommend");
				base.SetTextureByPath(resourcePath2, texture, null, null);
			}
		}

		// Token: 0x06035446 RID: 218182 RVA: 0x00D5BFAC File Offset: 0x00D5A1AC
		private void OnSkillSlotClick()
		{
			if (this.Data == null)
			{
				return;
			}
			SkillTree? skillTreeNode = ConfigBase<RoleSkillConfig>.Instance.GetSkillTreeNode(this.Data.SkillNodeId);
			RoleDevSkillMergeViewParams param = new RoleDevSkillMergeViewParams
			{
				RoleId = this.Data.RoleId,
				SkillNodeIndex = ((skillTreeNode != null) ? skillTreeNode.GetValueOrDefault().NodeIndex : ConfigBase<RoleDevConfig>.Instance.GetDefaultSkillNodeIndex())
			};
			Singleton<UiManager>.Instance.OpenView(EUiViewName.RoleSkillMergeView, param, null);
		}

		// Token: 0x0401EA50 RID: 125520
		[Nullable(2)]
		private RoleDevelopSkillData Data;

		// Token: 0x0200B056 RID: 45142
		public static class EComponentType
		{
			// Token: 0x04036B5A RID: 224090
			public const int SpriteSkill = 0;

			// Token: 0x04036B5B RID: 224091
			public const int SpriteLock = 1;

			// Token: 0x04036B5C RID: 224092
			public const int TxtSkillNum = 2;

			// Token: 0x04036B5D RID: 224093
			public const int BtnSkillSlot = 3;

			// Token: 0x04036B5E RID: 224094
			public const int ItemTag = 4;

			// Token: 0x04036B5F RID: 224095
			public const int TextureTag = 5;
		}
	}
}
