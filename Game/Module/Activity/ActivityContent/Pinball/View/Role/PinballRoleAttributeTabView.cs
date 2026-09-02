using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Role
{
	// Token: 0x020065CC RID: 26060
	[NullableContext(1)]
	[Nullable(0)]
	public class PinballRoleAttributeTabView : UiTabViewBase, IPinballRoleTabViewRoleChange, IPinballRoleTabViewRefresh
	{
		// Token: 0x060411BB RID: 266683 RVA: 0x010B4248 File Offset: 0x010B2448
		protected unsafe override void OnRegisterComponent()
		{
			int num = 20;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUILayoutBase));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUILayoutBase));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(17, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(18, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(19, typeof(UUIText));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(8, new Action(this.OnAttrDetailButtonClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x060411BC RID: 266684 RVA: 0x010B454C File Offset: 0x010B274C
		protected override UniTask OnBeforeStartAsync()
		{
			PinballRoleAttributeTabView.<OnBeforeStartAsync>d__16 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<PinballRoleAttributeTabView.<OnBeforeStartAsync>d__16>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060411BD RID: 266685 RVA: 0x010B4590 File Offset: 0x010B2790
		protected override void OnBeforeShow()
		{
			this.Proxy = (IPinballRoleAttributeTabViewProxy)this.ExtraParams;
			this.RefreshView();
			UiBehaviorLevelSequence uiViewSequence = this.UiViewSequence;
			if (uiViewSequence == null)
			{
				return;
			}
			uiViewSequence.PlayOrReplaySequenceByName("Start", false, null);
		}

		// Token: 0x060411BE RID: 266686 RVA: 0x010B45D3 File Offset: 0x010B27D3
		protected override void AddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.OnPinballRoleLevelUp, new Action<int, int, int>(this.OnPinballRoleLevelUp));
		}

		// Token: 0x060411BF RID: 266687 RVA: 0x010B45F1 File Offset: 0x010B27F1
		protected override void RemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnPinballRoleLevelUp, new Action<int, int, int>(this.OnPinballRoleLevelUp));
		}

		// Token: 0x060411C0 RID: 266688 RVA: 0x010B4610 File Offset: 0x010B2810
		private UniTask InitTabItemsAsync()
		{
			PinballRoleAttributeTabView.<InitTabItemsAsync>d__20 <InitTabItemsAsync>d__;
			<InitTabItemsAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitTabItemsAsync>d__.<>4__this = this;
			<InitTabItemsAsync>d__.<>1__state = -1;
			<InitTabItemsAsync>d__.<>t__builder.Start<PinballRoleAttributeTabView.<InitTabItemsAsync>d__20>(ref <InitTabItemsAsync>d__);
			return <InitTabItemsAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060411C1 RID: 266689 RVA: 0x010B4654 File Offset: 0x010B2854
		private UniTask InitLevelUpItemsAsync()
		{
			PinballRoleAttributeTabView.<InitLevelUpItemsAsync>d__21 <InitLevelUpItemsAsync>d__;
			<InitLevelUpItemsAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitLevelUpItemsAsync>d__.<>4__this = this;
			<InitLevelUpItemsAsync>d__.<>1__state = -1;
			<InitLevelUpItemsAsync>d__.<>t__builder.Start<PinballRoleAttributeTabView.<InitLevelUpItemsAsync>d__21>(ref <InitLevelUpItemsAsync>d__);
			return <InitLevelUpItemsAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060411C2 RID: 266690 RVA: 0x010B4697 File Offset: 0x010B2897
		private void InitAttrLayout()
		{
			this.AttributeLayout = new GenericLayout<PinballAttributeItem, IPinballAttributeItemData>(base.GetLayoutBase(6), new Func<PinballAttributeItem>(this.CreateAttrItem), base.GetItem(7).GetOwner() as AUIBaseActor, false, true);
		}

		// Token: 0x060411C3 RID: 266691 RVA: 0x010B46CA File Offset: 0x010B28CA
		private void InitSkillScroll()
		{
			this.SkillDetailScrollView = new GenericScrollViewNew<PinballRoleSkillDetailItem, PinballSkillDisplayConfig>(base.GetScrollViewWithScrollbar(11), new Func<PinballRoleSkillDetailItem>(this.CreateSkillDetailItem), base.GetItem(12).GetOwner() as AUIBaseActor, false, null);
		}

		// Token: 0x060411C4 RID: 266692 RVA: 0x010B46FF File Offset: 0x010B28FF
		private void InitRoleClassLayout()
		{
			this.RoleClassLayout = new GenericLayout<PinballRoleClassItem, IPinballRoleClassItemData>(base.GetLayoutBase(9), new Func<PinballRoleClassItem>(this.CreateRoleClassItem), base.GetItem(10).GetOwner() as AUIBaseActor, false, true);
		}

		// Token: 0x060411C5 RID: 266693 RVA: 0x010B4734 File Offset: 0x010B2934
		public void RefreshView()
		{
			this.RefreshRoleInfo();
			this.RefreshCurTabView();
		}

		// Token: 0x060411C6 RID: 266694 RVA: 0x010B4744 File Offset: 0x010B2944
		public void RefreshRoleInfo()
		{
			if (this.Proxy == null)
			{
				return;
			}
			PinballRoleDataBase roleData = this.Proxy.GetRoleData();
			PinballRoleConfig? pinballRoleConfigById = ConfigBase<PinballConfig>.Instance.GetPinballRoleConfigById(roleData.GetId());
			if (pinballRoleConfigById == null)
			{
				return;
			}
			string roleNameByPinballRoleConfig = ModelBase<PinballModel>.Instance.GetRoleNameByPinballRoleConfig(pinballRoleConfigById.Value);
			int level = roleData.GetLevel();
			int maxLevelByPinballRoleConfig = ModelBase<PinballModel>.Instance.GetMaxLevelByPinballRoleConfig(pinballRoleConfigById.Value);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), roleNameByPinballRoleConfig, Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), "Pinball_Character_level_01", new <>z__ReadOnlyArray<object>(new object[]
			{
				level.ToString(),
				maxLevelByPinballRoleConfig.ToString()
			}));
			int bd = pinballRoleConfigById.Value.Bd;
			PinballBdConfig? pinballRoleBdConfigById = ConfigBase<PinballConfig>.Instance.GetPinballRoleBdConfigById(bd);
			if (pinballRoleBdConfigById == null)
			{
				return;
			}
			base.SetTextureByPath(pinballRoleBdConfigById.Value.MiddleIcon, base.GetTexture(0), null, null);
			this.RefreshLevelUpItems();
			this.RefreshStateItem();
		}

		// Token: 0x060411C7 RID: 266695 RVA: 0x010B4858 File Offset: 0x010B2A58
		private void BuildClassDataList()
		{
			this.RoleClassDataList.Clear();
			if (this.Proxy == null)
			{
				return;
			}
			this.RoleClassDataList.Clear();
			PinballRoleConfig config = this.Proxy.GetRoleData().GetConfig();
			PinballBdConfig? pinballRoleBdConfigById = ConfigBase<PinballConfig>.Instance.GetPinballRoleBdConfigById(config.Bd);
			if (pinballRoleBdConfigById == null)
			{
				return;
			}
			PinballRoleClassItemData item = new PinballRoleClassItemData
			{
				Name = pinballRoleBdConfigById.Value.BdName,
				IconPath = pinballRoleBdConfigById.Value.Icon,
				BgColor = pinballRoleBdConfigById.Value.BgColor
			};
			this.RoleClassDataList.Add(item);
			int pinballClassLength = config.PinballClassLength;
			for (int i = 0; i < pinballClassLength; i++)
			{
				int id = config.PinballClass(i);
				PinballClassConfig? pinballClassConfigById = ConfigBase<PinballConfig>.Instance.GetPinballClassConfigById(id);
				if (pinballClassConfigById != null)
				{
					PinballRoleClassItemData item2 = new PinballRoleClassItemData
					{
						Name = pinballClassConfigById.Value.PinballClassName,
						IconPath = pinballClassConfigById.Value.Icon,
						BgColor = pinballClassConfigById.Value.BgColor
					};
					this.RoleClassDataList.Add(item2);
				}
			}
		}

		// Token: 0x060411C8 RID: 266696 RVA: 0x010B4998 File Offset: 0x010B2B98
		public void RefreshClassLayout()
		{
			this.BuildClassDataList();
			GenericLayout<PinballRoleClassItem, IPinballRoleClassItemData> roleClassLayout = this.RoleClassLayout;
			if (roleClassLayout == null)
			{
				return;
			}
			roleClassLayout.RefreshByData(this.RoleClassDataList, null, false);
		}

		// Token: 0x060411C9 RID: 266697 RVA: 0x010B49B8 File Offset: 0x010B2BB8
		private void BuildAttrItemDataList()
		{
			if (this.Proxy == null)
			{
				return;
			}
			this.RoleAttributeDataList.Clear();
			int id = this.Proxy.GetActivityData().Id;
			PinballActivity? pinballActivityConfigByActivityId = ConfigBase<PinballConfig>.Instance.GetPinballActivityConfigByActivityId(id);
			if (pinballActivityConfigByActivityId == null)
			{
				return;
			}
			int mainAttrShowListLength = pinballActivityConfigByActivityId.Value.MainAttrShowListLength;
			PinballRoleDataBase roleData = this.Proxy.GetRoleData();
			for (int i = 0; i < mainAttrShowListLength; i++)
			{
				int num = pinballActivityConfigByActivityId.Value.MainAttrShowList(i);
				PinballPropertyIndex? pinballPropertyIndexConfigById = ConfigBase<PinballConfig>.Instance.GetPinballPropertyIndexConfigById(num);
				if (pinballPropertyIndexConfigById != null)
				{
					int num2 = roleData.GetAttribute((EPinballAttr)num);
					if (num == 7)
					{
						num2 += 10000;
					}
					PinballAttributeItemData item = new PinballAttributeItemData
					{
						IsBgShow = (i % 2 == 1),
						AttributeConfig = pinballPropertyIndexConfigById.Value,
						AttributeValue = num2
					};
					this.RoleAttributeDataList.Add(item);
				}
			}
		}

		// Token: 0x060411CA RID: 266698 RVA: 0x010B4AAD File Offset: 0x010B2CAD
		public void RefreshAttributeView()
		{
			this.BuildAttrItemDataList();
			GenericLayout<PinballAttributeItem, IPinballAttributeItemData> attributeLayout = this.AttributeLayout;
			if (attributeLayout != null)
			{
				attributeLayout.RefreshByData(this.RoleAttributeDataList, null, false);
			}
			this.RefreshClassLayout();
		}

		// Token: 0x060411CB RID: 266699 RVA: 0x010B4AD4 File Offset: 0x010B2CD4
		private void BuildSkillDetailDataList()
		{
			if (this.Proxy == null)
			{
				return;
			}
			this.RoleSkillDataList.Clear();
			PinballRoleConfig config = this.Proxy.GetRoleData().GetConfig();
			int skillDisplayListLength = config.SkillDisplayListLength;
			for (int i = 0; i < skillDisplayListLength; i++)
			{
				int id = config.SkillDisplayList(i);
				PinballSkillDisplayConfig? pinballSkillDisplayConfigById = ConfigBase<PinballConfig>.Instance.GetPinballSkillDisplayConfigById(id);
				if (pinballSkillDisplayConfigById != null)
				{
					this.RoleSkillDataList.Add(pinballSkillDisplayConfigById.Value);
				}
			}
		}

		// Token: 0x060411CC RID: 266700 RVA: 0x010B4B4B File Offset: 0x010B2D4B
		public void RefreshSkillTabView()
		{
			this.BuildSkillDetailDataList();
			GenericScrollViewNew<PinballRoleSkillDetailItem, PinballSkillDisplayConfig> skillDetailScrollView = this.SkillDetailScrollView;
			if (skillDetailScrollView == null)
			{
				return;
			}
			skillDetailScrollView.RefreshByData(this.RoleSkillDataList, null, false);
		}

		// Token: 0x060411CD RID: 266701 RVA: 0x010B4B6B File Offset: 0x010B2D6B
		public void RefreshCurTabView()
		{
			if (this.SelectedTabIndex == EPinballRoleAttributeTabIndex.Attr)
			{
				this.RefreshAttributeView();
				return;
			}
			if (this.SelectedTabIndex == EPinballRoleAttributeTabIndex.Skill)
			{
				this.RefreshSkillTabView();
			}
		}

		// Token: 0x060411CE RID: 266702 RVA: 0x010B4B8C File Offset: 0x010B2D8C
		[NullableContext(2)]
		private IPinballRoleLevelUpButtonItemData BuildLevelUpItemDataByTimes(int times, bool bToMaxLevel)
		{
			IPinballRoleAttributeTabViewProxy proxy = this.Proxy;
			PinballActivityData pinballActivityData = (proxy != null) ? proxy.GetActivityData() : null;
			IPinballRoleAttributeTabViewProxy proxy2 = this.Proxy;
			PinballRoleDataBase pinballRoleDataBase = (proxy2 != null) ? proxy2.GetRoleData() : null;
			PinballRoleConfig? pinballRoleConfig = (pinballRoleDataBase != null) ? new PinballRoleConfig?(pinballRoleDataBase.GetConfig()) : null;
			if (pinballActivityData == null || pinballRoleDataBase == null || pinballRoleConfig == null)
			{
				return null;
			}
			int id = pinballActivityData.Id;
			int roleLevelUpCostItemId = ModelBase<PinballModel>.Instance.GetRoleLevelUpCostItemId(id);
			int itemCountByConfigId = ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(roleLevelUpCostItemId, 0);
			int level = pinballRoleDataBase.GetLevel();
			int targetLevel = level + times;
			int roleLevelUpCostCount = ModelBase<PinballModel>.Instance.GetRoleLevelUpCostCount(pinballRoleConfig.Value.GradeUpGroup, level, targetLevel);
			CostData costItemData = new CostData
			{
				ItemId = roleLevelUpCostItemId,
				Count = itemCountByConfigId,
				Cost = roleLevelUpCostCount
			};
			return new PinballRoleLevelUpButtonItemData
			{
				Times = times,
				IsToMaxLevel = bToMaxLevel,
				ConfirmDelegate = new Action<int>(this.OnLevelUpConfirm),
				CostItemData = costItemData
			};
		}

		// Token: 0x060411CF RID: 266703 RVA: 0x010B4C88 File Offset: 0x010B2E88
		public void RefreshLevelUpItems()
		{
			IPinballRoleAttributeTabViewProxy proxy = this.Proxy;
			PinballRoleDataBase pinballRoleDataBase = (proxy != null) ? proxy.GetRoleData() : null;
			if (pinballRoleDataBase == null)
			{
				return;
			}
			int id = pinballRoleDataBase.GetId();
			bool flag = pinballRoleDataBase.IsLocked();
			UUIItem item = base.GetItem(13);
			if (item != null)
			{
				item.SetUIActive(false);
			}
			if (flag)
			{
				UUIItem item2 = base.GetItem(14);
				if (item2 != null)
				{
					item2.SetUIActive(false);
				}
				PinballLevelConfig? pinballLevelConfigByRoleId = ConfigBase<PinballConfig>.Instance.GetPinballLevelConfigByRoleId(id);
				if (pinballLevelConfigByRoleId == null)
				{
					return;
				}
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(19), "Pinball_Character_lockedinfo", new <>z__ReadOnlySingleElementList<object>(ConfigMultiTextLang.GetLocalTextNew(pinballLevelConfigByRoleId.Value.Name, null)));
				return;
			}
			else
			{
				int level = pinballRoleDataBase.GetLevel();
				int maxLevelByPinballByRoleId = ModelBase<PinballModel>.Instance.GetMaxLevelByPinballByRoleId(id);
				if (level != maxLevelByPinballByRoleId)
				{
					UUIItem item3 = base.GetItem(14);
					if (item3 != null)
					{
						item3.SetUIActive(true);
					}
					IPinballRoleLevelUpButtonItemData pinballRoleLevelUpButtonItemData = this.BuildLevelUpItemDataByTimes(1, false);
					int num = maxLevelByPinballByRoleId - level;
					IPinballRoleLevelUpButtonItemData pinballRoleLevelUpButtonItemData2;
					if (num < 10)
					{
						pinballRoleLevelUpButtonItemData2 = this.BuildLevelUpItemDataByTimes(num, true);
					}
					else
					{
						pinballRoleLevelUpButtonItemData2 = this.BuildLevelUpItemDataByTimes(10, false);
					}
					if (pinballRoleLevelUpButtonItemData != null)
					{
						PinballRoleLevelUpButtonItem singleLevelUpButtonItem = this.SingleLevelUpButtonItem;
						if (singleLevelUpButtonItem != null)
						{
							singleLevelUpButtonItem.Refresh(pinballRoleLevelUpButtonItemData);
						}
					}
					if (pinballRoleLevelUpButtonItemData2 != null)
					{
						PinballRoleLevelUpButtonItem multipleLevelUpButtonItem = this.MultipleLevelUpButtonItem;
						if (multipleLevelUpButtonItem == null)
						{
							return;
						}
						multipleLevelUpButtonItem.Refresh(pinballRoleLevelUpButtonItemData2);
					}
					return;
				}
				UUIItem item4 = base.GetItem(14);
				if (item4 == null)
				{
					return;
				}
				item4.SetUIActive(false);
				return;
			}
		}

		// Token: 0x060411D0 RID: 266704 RVA: 0x010B4DC8 File Offset: 0x010B2FC8
		public void RefreshStateItem()
		{
			if (this.Proxy == null)
			{
				return;
			}
			PinballRoleDataBase roleData = this.Proxy.GetRoleData();
			if (roleData == null)
			{
				return;
			}
			IPinballRoleAttributeTabViewProxy proxy = this.Proxy;
			bool? flag;
			if (proxy == null)
			{
				flag = null;
			}
			else
			{
				PinballRoleDataBase roleData2 = proxy.GetRoleData();
				flag = ((roleData2 != null) ? new bool?(roleData2.IsLocked()) : null);
			}
			bool? flag2 = flag;
			bool valueOrDefault = flag2.GetValueOrDefault(true);
			bool uiactive = false;
			UUIItem item = base.GetItem(18);
			if (item != null)
			{
				item.SetUIActive(valueOrDefault);
			}
			if (!valueOrDefault)
			{
				uiactive = ModelBase<PinballModel>.Instance.IsRoleMaxLevel(roleData.GetId());
			}
			UUIItem item2 = base.GetItem(17);
			if (item2 == null)
			{
				return;
			}
			item2.SetUIActive(uiactive);
		}

		// Token: 0x060411D1 RID: 266705 RVA: 0x010B4E68 File Offset: 0x010B3068
		public void RefreshByRoleChange()
		{
			this.RefreshView();
		}

		// Token: 0x060411D2 RID: 266706 RVA: 0x010B4E70 File Offset: 0x010B3070
		private void SelectTabIndex(EPinballRoleAttributeTabIndex tabIndex)
		{
			if (this.SelectedTabIndex == tabIndex)
			{
				return;
			}
			EPinballRoleAttributeTabIndex selectedTabIndex = this.SelectedTabIndex;
			this.SelectedTabIndex = tabIndex;
			this.TabItemDataList[(int)selectedTabIndex].IsSelected = false;
			this.TabItems[(int)selectedTabIndex].RefreshSelectState(false);
			this.TabItemDataList[(int)tabIndex].IsSelected = true;
			this.TabItems[(int)tabIndex].RefreshSelectState(false);
			this.TabRootItems[(int)selectedTabIndex].SetUIActive(false);
			this.TabRootItems[(int)tabIndex].SetUIActive(true);
			this.RefreshCurTabView();
		}

		// Token: 0x060411D3 RID: 266707 RVA: 0x010B4F07 File Offset: 0x010B3107
		private PinballAttributeItem CreateAttrItem()
		{
			return new PinballAttributeItem();
		}

		// Token: 0x060411D4 RID: 266708 RVA: 0x010B4F0E File Offset: 0x010B310E
		private PinballRoleSkillDetailItem CreateSkillDetailItem()
		{
			return new PinballRoleSkillDetailItem();
		}

		// Token: 0x060411D5 RID: 266709 RVA: 0x010B4F15 File Offset: 0x010B3115
		private PinballRoleClassItem CreateRoleClassItem()
		{
			return new PinballRoleClassItem();
		}

		// Token: 0x060411D6 RID: 266710 RVA: 0x010B4F1C File Offset: 0x010B311C
		private void OnLevelUpConfirm(int times)
		{
			if (this.Proxy == null)
			{
				return;
			}
			PinballActivityData activityData = this.Proxy.GetActivityData();
			if (activityData == null)
			{
				return;
			}
			PinballRoleDataBase roleData = this.Proxy.GetRoleData();
			if (roleData == null)
			{
				return;
			}
			this.OnLevelUpConfirmAsync(activityData.Id, roleData.GetId(), times).Forget();
		}

		// Token: 0x060411D7 RID: 266711 RVA: 0x010B4F6C File Offset: 0x010B316C
		private UniTask OnLevelUpConfirmAsync(int activityId, int roleId, int times)
		{
			PinballRoleAttributeTabView.<OnLevelUpConfirmAsync>d__43 <OnLevelUpConfirmAsync>d__;
			<OnLevelUpConfirmAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnLevelUpConfirmAsync>d__.<>4__this = this;
			<OnLevelUpConfirmAsync>d__.activityId = activityId;
			<OnLevelUpConfirmAsync>d__.roleId = roleId;
			<OnLevelUpConfirmAsync>d__.times = times;
			<OnLevelUpConfirmAsync>d__.<>1__state = -1;
			<OnLevelUpConfirmAsync>d__.<>t__builder.Start<PinballRoleAttributeTabView.<OnLevelUpConfirmAsync>d__43>(ref <OnLevelUpConfirmAsync>d__);
			return <OnLevelUpConfirmAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060411D8 RID: 266712 RVA: 0x010B4FC8 File Offset: 0x010B31C8
		private void OnPinballRoleLevelUp(int activityId, int roleId, int addLevel)
		{
			IPinballRoleAttributeTabViewProxy proxy = this.Proxy;
			int? num;
			if (proxy == null)
			{
				num = null;
			}
			else
			{
				PinballActivityData activityData = proxy.GetActivityData();
				num = ((activityData != null) ? new int?(activityData.Id) : null);
			}
			int? num2 = num;
			if (!(activityId == num2.GetValueOrDefault() & num2 != null))
			{
				return;
			}
			IPinballRoleAttributeTabViewProxy proxy2 = this.Proxy;
			int? num3;
			if (proxy2 == null)
			{
				num3 = null;
			}
			else
			{
				PinballRoleDataBase roleData = proxy2.GetRoleData();
				num3 = ((roleData != null) ? new int?(roleData.GetId()) : null);
			}
			num2 = num3;
			if (!(roleId == num2.GetValueOrDefault() & num2 != null))
			{
				return;
			}
			this.RefreshView();
		}

		// Token: 0x060411D9 RID: 266713 RVA: 0x010B5070 File Offset: 0x010B3270
		private void OnAttrDetailButtonClick()
		{
			if (this.Proxy == null)
			{
				return;
			}
			PinballActivityData activityData = this.Proxy.GetActivityData();
			if (activityData == null)
			{
				return;
			}
			List<IPinballAttributeDetailItemData> list = new List<IPinballAttributeDetailItemData>();
			int id = activityData.Id;
			PinballActivity? pinballActivityConfigByActivityId = ConfigBase<PinballConfig>.Instance.GetPinballActivityConfigByActivityId(id);
			if (pinballActivityConfigByActivityId == null)
			{
				return;
			}
			int attrShowListLength = pinballActivityConfigByActivityId.Value.AttrShowListLength;
			PinballRoleDataBase roleData = this.Proxy.GetRoleData();
			for (int i = 0; i < attrShowListLength; i++)
			{
				int id2 = pinballActivityConfigByActivityId.Value.AttrShowList(i);
				PinballPropertyIndex? pinballPropertyIndexConfigById = ConfigBase<PinballConfig>.Instance.GetPinballPropertyIndexConfigById(id2);
				if (pinballPropertyIndexConfigById != null)
				{
					PinballAttributeDetailItemData item = new PinballAttributeDetailItemData
					{
						IsBgShow = (i % 2 == 1),
						AttributeConfig = pinballPropertyIndexConfigById.Value,
						AttributeValue = roleData.GetAttribute((EPinballAttr)id2),
						IsExpanded = false
					};
					list.Add(item);
				}
			}
			Singleton<UiManager>.Instance.OpenView(EUiViewName.PinballAttributeDetailView, list, null);
		}

		// Token: 0x0402478D RID: 149389
		[Nullable(2)]
		protected IPinballRoleAttributeTabViewProxy Proxy;

		// Token: 0x0402478E RID: 149390
		private EPinballRoleAttributeTabIndex SelectedTabIndex = EPinballRoleAttributeTabIndex.None;

		// Token: 0x0402478F RID: 149391
		private readonly List<IPinballRoleAttributeTabItemData> TabItemDataList = new List<IPinballRoleAttributeTabItemData>();

		// Token: 0x04024790 RID: 149392
		private readonly List<IPinballAttributeItemData> RoleAttributeDataList = new List<IPinballAttributeItemData>();

		// Token: 0x04024791 RID: 149393
		private readonly List<PinballSkillDisplayConfig> RoleSkillDataList = new List<PinballSkillDisplayConfig>();

		// Token: 0x04024792 RID: 149394
		private readonly List<IPinballRoleClassItemData> RoleClassDataList = new List<IPinballRoleClassItemData>();

		// Token: 0x04024793 RID: 149395
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<PinballAttributeItem, IPinballAttributeItemData> AttributeLayout;

		// Token: 0x04024794 RID: 149396
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericScrollViewNew<PinballRoleSkillDetailItem, PinballSkillDisplayConfig> SkillDetailScrollView;

		// Token: 0x04024795 RID: 149397
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<PinballRoleClassItem, IPinballRoleClassItemData> RoleClassLayout;

		// Token: 0x04024796 RID: 149398
		private readonly List<PinballRoleAttributeTabItem> TabItems = new List<PinballRoleAttributeTabItem>();

		// Token: 0x04024797 RID: 149399
		private readonly List<UUIItem> TabRootItems = new List<UUIItem>();

		// Token: 0x04024798 RID: 149400
		[Nullable(2)]
		private PinballRoleLevelUpButtonItem LevelUpButtonItem;

		// Token: 0x04024799 RID: 149401
		[Nullable(2)]
		private PinballRoleLevelUpButtonItem SingleLevelUpButtonItem;

		// Token: 0x0402479A RID: 149402
		[Nullable(2)]
		private PinballRoleLevelUpButtonItem MultipleLevelUpButtonItem;

		// Token: 0x0200C5CC RID: 50636
		[NullableContext(0)]
		private enum EComponent
		{
			// Token: 0x0403CE16 RID: 249366
			BdTexture,
			// Token: 0x0403CE17 RID: 249367
			NameText,
			// Token: 0x0403CE18 RID: 249368
			LevelText,
			// Token: 0x0403CE19 RID: 249369
			AttrTabItem,
			// Token: 0x0403CE1A RID: 249370
			SkillTabItem,
			// Token: 0x0403CE1B RID: 249371
			AttrRootItem,
			// Token: 0x0403CE1C RID: 249372
			AttrItemLayout,
			// Token: 0x0403CE1D RID: 249373
			AttrTemplateItem,
			// Token: 0x0403CE1E RID: 249374
			AttrDetailButton,
			// Token: 0x0403CE1F RID: 249375
			RoleClassLayout,
			// Token: 0x0403CE20 RID: 249376
			RoleClassTemplateItem,
			// Token: 0x0403CE21 RID: 249377
			SkillDetailScrollView,
			// Token: 0x0403CE22 RID: 249378
			SkillDetailTemplateItem,
			// Token: 0x0403CE23 RID: 249379
			SingleLevelUpRootItem,
			// Token: 0x0403CE24 RID: 249380
			MultipleLevelUpRootItem,
			// Token: 0x0403CE25 RID: 249381
			SingleLevelUpItem,
			// Token: 0x0403CE26 RID: 249382
			MultipleLevelUpItem,
			// Token: 0x0403CE27 RID: 249383
			MaxLevelItem,
			// Token: 0x0403CE28 RID: 249384
			LockItem,
			// Token: 0x0403CE29 RID: 249385
			LockText
		}
	}
}
