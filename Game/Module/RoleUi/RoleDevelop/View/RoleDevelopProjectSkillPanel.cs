using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.RoleDev;
using CSharpScript.Game.Module.RoleUi.RoleDevelop.Data;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.RoleUi.RoleDevelop.View
{
	// Token: 0x020050C1 RID: 20673
	[NullableContext(1)]
	[Nullable(0)]
	public class RoleDevelopProjectSkillPanel : RoleDevelopProjectBasePanel
	{
		// Token: 0x06035434 RID: 218164 RVA: 0x00D5B47C File Offset: 0x00D5967C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 17;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIVerticalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.OnClickSwitchState));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06035435 RID: 218165 RVA: 0x00D5B71C File Offset: 0x00D5991C
		protected override UniTask OnBeforeStartAsync()
		{
			RoleDevelopProjectSkillPanel.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RoleDevelopProjectSkillPanel.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06035436 RID: 218166 RVA: 0x00D5B760 File Offset: 0x00D59960
		private UniTask InitSkillSlotItems()
		{
			RoleDevelopProjectSkillPanel.<InitSkillSlotItems>d__8 <InitSkillSlotItems>d__;
			<InitSkillSlotItems>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitSkillSlotItems>d__.<>4__this = this;
			<InitSkillSlotItems>d__.<>1__state = -1;
			<InitSkillSlotItems>d__.<>t__builder.Start<RoleDevelopProjectSkillPanel.<InitSkillSlotItems>d__8>(ref <InitSkillSlotItems>d__);
			return <InitSkillSlotItems>d__.<>t__builder.Task;
		}

		// Token: 0x06035437 RID: 218167 RVA: 0x00D5B7A4 File Offset: 0x00D599A4
		private UniTask InitButtons()
		{
			RoleDevelopProjectSkillPanel.<InitButtons>d__9 <InitButtons>d__;
			<InitButtons>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitButtons>d__.<>4__this = this;
			<InitButtons>d__.<>1__state = -1;
			<InitButtons>d__.<>t__builder.Start<RoleDevelopProjectSkillPanel.<InitButtons>d__9>(ref <InitButtons>d__);
			return <InitButtons>d__.<>t__builder.Task;
		}

		// Token: 0x06035438 RID: 218168 RVA: 0x00D5B7E8 File Offset: 0x00D599E8
		private void RefreshSkillSlotItems()
		{
			List<RoleDevelopSkillData> skillDevelopData = this.Data.GetProjectData().GetSkillDevelopData();
			for (int i = 0; i < this.SkillSlotItems.Count; i++)
			{
				this.SkillSlotItems[i].Refresh(skillDevelopData[i]);
			}
		}

		// Token: 0x06035439 RID: 218169 RVA: 0x00D5B834 File Offset: 0x00D59A34
		private void RefreshItemLayout()
		{
			List<RoleDevelopProjectMaterialItemData> skillDevelopProjectViewItems = this.Data.GetProjectData().GetSkillDevelopProjectViewItems();
			foreach (RoleDevelopProjectMaterialItemData roleDevelopProjectMaterialItemData in skillDevelopProjectViewItems)
			{
				ERoleDevelopLogSubPage value;
				if (this.SkillDevelopMaterialTypeToLogSubPageMap.TryGetValue(roleDevelopProjectMaterialItemData.GroupItem.Type, out value))
				{
					roleDevelopProjectMaterialItemData.LogSubPage = new ERoleDevelopLogSubPage?(value);
					roleDevelopProjectMaterialItemData.LogRoleId = new int?(this.Data.GetId());
					roleDevelopProjectMaterialItemData.LogMainPage = new ERoleDevelopCategoryType?(ERoleDevelopCategoryType.Skill);
				}
			}
			this.ItemLayout.RefreshByData(skillDevelopProjectViewItems, null, false);
			base.GetItem(16).SetUIActive(skillDevelopProjectViewItems.Count > 0);
		}

		// Token: 0x0603543A RID: 218170 RVA: 0x00D5B8F8 File Offset: 0x00D59AF8
		private void RefreshTitle()
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(15), "RoleProject_SkillUpgradePrefect", Array.Empty<object>());
			base.GetButton(1).RootUIComp.Get().SetUIActive(false);
			base.GetText(0).SetUIActive(false);
		}

		// Token: 0x0603543B RID: 218171 RVA: 0x00D5B948 File Offset: 0x00D59B48
		private void RefreshButtons()
		{
			int id = this.Data.GetId();
			bool flag = RoleDevelopUtil.IsProspectRole(id);
			bool flag2 = ModelBase<RoleModel>.Instance.IsRoleOwned(id);
			bool flag3 = flag2 && !flag;
			base.GetItem(7).SetUIActive(flag3);
			base.GetItem(11).SetUIActive(!flag3);
			UUIItem item = base.GetItem(9);
			if (!flag2)
			{
				this.NormalButtonItem.SetUiActive(false);
				this.HighLightButtonItem.SetUiActive(false);
				item.SetUIActive(false);
				return;
			}
			RoleDevelopProjectBaseData projectData = this.Data.GetProjectData();
			bool uiActive;
			bool uiActive2;
			string textId;
			bool uiactive;
			if (projectData.IsSkillPlanFinished())
			{
				List<RoleDevelopSkillData> skillDevelopData = projectData.GetSkillDevelopData();
				int breachLevel = ModelBase<RoleModel>.Instance.GetRoleDataById(id, true).GetLevelData().GetBreachLevel();
				bool flag4 = skillDevelopData.TrueForAll((RoleDevelopSkillData skill) => skill.CurrentLevel >= skill.TargetLevel);
				uiActive = true;
				uiActive2 = false;
				textId = "RoleProject_Button02";
				uiactive = (flag4 && breachLevel < 6);
			}
			else
			{
				bool flag5 = RoleDevelopUtil.CheckIsAllNeedItemsEnoughOrCanBeFilled(projectData.GetSkillPlanNeedItems());
				uiActive = !flag5;
				uiActive2 = flag5;
				textId = "RoleProject_Button01";
				uiactive = false;
			}
			this.NormalButtonItem.SetLocalTextNew(textId, Array.Empty<object>());
			this.HighLightButtonItem.SetLocalTextNew(textId, Array.Empty<object>());
			this.NormalButtonItem.SetUiActive(uiActive);
			this.HighLightButtonItem.SetUiActive(uiActive2);
			item.SetUIActive(uiactive);
		}

		// Token: 0x0603543C RID: 218172 RVA: 0x00D5BAAF File Offset: 0x00D59CAF
		public override void OnCommonItemCountAnyChange(int configId)
		{
			this.RefreshButtons();
			this.ItemLayout.RefreshWithoutDataSync();
		}

		// Token: 0x0603543D RID: 218173 RVA: 0x00D5BAC2 File Offset: 0x00D59CC2
		protected override void OnRefreshView(bool forceRefresh)
		{
			this.RefreshSkillSlotItems();
			this.RefreshItemLayout();
			this.RefreshTitle();
			this.RefreshButtons();
		}

		// Token: 0x0603543E RID: 218174 RVA: 0x00D5BADC File Offset: 0x00D59CDC
		private void OnClickSwitchState()
		{
			base.StopSequenceByName("Switch", false, true);
			base.PlaySequenceByName("Switch", false);
			ControllerBase<RoleController>.Instance.LogRoleDevelopClick(this.Data.GetId(), ERoleDevelopCategoryType.Skill, ERoleDevelopLogSubPage.SkillDevelopSwitchPlan, null);
		}

		// Token: 0x0603543F RID: 218175 RVA: 0x00D5BB24 File Offset: 0x00D59D24
		private void OnClickBtnJump(int value)
		{
			int id = this.Data.GetId();
			if (!ModelBase<RoleModel>.Instance.IsRoleOwned(id))
			{
				return;
			}
			RoleDevSkillMergeViewParams param = new RoleDevSkillMergeViewParams
			{
				RoleId = id,
				SkillNodeIndex = ConfigBase<RoleDevConfig>.Instance.GetDefaultSkillNodeIndex()
			};
			Singleton<UiManager>.Instance.OpenView(EUiViewName.RoleSkillMergeView, param, null);
			ERoleDevelopLogSubPage subPage = this.Data.GetProjectData().IsSkillPlanFinished() ? ERoleDevelopLogSubPage.SkillDevelopPerfectJump : ERoleDevelopLogSubPage.SkillDevelopJump;
			ControllerBase<RoleController>.Instance.LogRoleDevelopClick(id, ERoleDevelopCategoryType.Skill, subPage, null);
		}

		// Token: 0x06035440 RID: 218176 RVA: 0x00D5BBA8 File Offset: 0x00D59DA8
		private RoleDevelopProjectMaterialItem CreateMaterialItem()
		{
			return new RoleDevelopProjectMaterialItem();
		}

		// Token: 0x0401EA4B RID: 125515
		private readonly Dictionary<EItemMaterialType, ERoleDevelopLogSubPage> SkillDevelopMaterialTypeToLogSubPageMap = new Dictionary<EItemMaterialType, ERoleDevelopLogSubPage>
		{
			{
				EItemMaterialType.Weekly,
				ERoleDevelopLogSubPage.SkillDevelopSkillMaterial
			},
			{
				EItemMaterialType.WeaponSkill,
				ERoleDevelopLogSubPage.SkillDevelopWeaponAndSkillMaterial1
			},
			{
				EItemMaterialType.Drop,
				ERoleDevelopLogSubPage.SkillDevelopWeaponAndSkillMaterial2
			}
		};

		// Token: 0x0401EA4C RID: 125516
		private List<RoleDevelopProjectSkillSlotItem> SkillSlotItems = new List<RoleDevelopProjectSkillSlotItem>();

		// Token: 0x0401EA4D RID: 125517
		private ButtonItem NormalButtonItem;

		// Token: 0x0401EA4E RID: 125518
		private ButtonItem HighLightButtonItem;

		// Token: 0x0401EA4F RID: 125519
		private GenericLayout<RoleDevelopProjectMaterialItem, RoleDevelopProjectMaterialItemData> ItemLayout;

		// Token: 0x0200B051 RID: 45137
		[NullableContext(0)]
		public static class EComponentType
		{
			// Token: 0x04036B3B RID: 224059
			public const int TxtSwitchState = 0;

			// Token: 0x04036B3C RID: 224060
			public const int BtnSwitchState = 1;

			// Token: 0x04036B3D RID: 224061
			public const int PanelSkillSlot0 = 2;

			// Token: 0x04036B3E RID: 224062
			public const int PanelSkillSlot1 = 3;

			// Token: 0x04036B3F RID: 224063
			public const int PanelSkillSlot2 = 4;

			// Token: 0x04036B40 RID: 224064
			public const int PanelSkillSlot3 = 5;

			// Token: 0x04036B41 RID: 224065
			public const int PanelSkillSlot4 = 6;

			// Token: 0x04036B42 RID: 224066
			public const int PanelItemRight = 7;

			// Token: 0x04036B43 RID: 224067
			public const int BtnItemJump = 8;

			// Token: 0x04036B44 RID: 224068
			public const int PanelTxtOffset = 9;

			// Token: 0x04036B45 RID: 224069
			public const int BtnItemPerfectJump = 10;

			// Token: 0x04036B46 RID: 224070
			public const int PanelItemRightLine = 11;

			// Token: 0x04036B47 RID: 224071
			public const int PanelItemDetailLayout = 12;

			// Token: 0x04036B48 RID: 224072
			public const int PanelItemList = 13;

			// Token: 0x04036B49 RID: 224073
			public const int PanelSwitch = 14;

			// Token: 0x04036B4A RID: 224074
			public const int TxtTitle = 15;

			// Token: 0x04036B4B RID: 224075
			public const int PanelItemDescription = 16;
		}
	}
}
