using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.FlagChallenge
{
	// Token: 0x02005D76 RID: 23926
	[NullableContext(1)]
	[Nullable(0)]
	public class FlagChallengeSelectRoleView : UiViewBase
	{
		// Token: 0x170098A5 RID: 39077
		// (get) Token: 0x0603C435 RID: 246837 RVA: 0x00F4A01E File Offset: 0x00F4821E
		[Nullable(2)]
		public new FlagChallengeSelectRoleViewParams OpenParam
		{
			[NullableContext(2)]
			get
			{
				return this.OpenParam as FlagChallengeSelectRoleViewParams;
			}
		}

		// Token: 0x0603C436 RID: 246838 RVA: 0x00F4A02B File Offset: 0x00F4822B
		public FlagChallengeSelectRoleView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603C437 RID: 246839 RVA: 0x00F4A040 File Offset: 0x00F48240
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIScrollViewWithScrollbarComponent)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(6, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(7, typeof(UUIText)),
				new ValueTuple<int, Type>(8, typeof(UUIText)),
				new ValueTuple<int, Type>(9, typeof(UUIItem)),
				new ValueTuple<int, Type>(10, typeof(UUIText)),
				new ValueTuple<int, Type>(11, typeof(UUIArtText)),
				new ValueTuple<int, Type>(12, typeof(UUIHorizontalLayout)),
				new ValueTuple<int, Type>(13, typeof(UUIItem)),
				new ValueTuple<int, Type>(14, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(5, new Action(this.OnConfirmBtnClick)),
				new ValueTuple<int, Delegate>(6, new Action(this.OnDetailBtnClick))
			};
		}

		// Token: 0x0603C438 RID: 246840 RVA: 0x00F4A1E4 File Offset: 0x00F483E4
		protected override UniTask OnBeforeStartAsync()
		{
			FlagChallengeSelectRoleView.<OnBeforeStartAsync>d__13 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<FlagChallengeSelectRoleView.<OnBeforeStartAsync>d__13>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603C439 RID: 246841 RVA: 0x00F4A228 File Offset: 0x00F48428
		protected override void OnStart()
		{
			this.PopupCaption = new PopupCaptionItem(base.GetItem(0));
			this.PopupCaption.SetCloseCallBack(new Action(this.OnCloseClick));
			ConfigBase<FlagChallengeConfig>.Instance.GetFormationHelpId();
			this.PopupCaption.SetHelpBtnActive(true);
			this.PopupCaption.SetHelpCallBack(new Action(this.OnHelpClick));
			this.RoleLayout = new GenericLayout<FlagChallengeFormationRoleItem, IFlagChallengeFormationRoleItemData>(base.GetHorizontalLayout(12), new Func<FlagChallengeFormationRoleItem>(this.CreateFormationRoleItem), null, false, true);
			this.RefreshFormationRoles();
			UUIScrollViewWithScrollbarComponent scrollViewWithScrollbar = base.GetScrollViewWithScrollbar(1);
			AUIBaseActor gridActor = base.GetItem(3).GetOwner() as AUIBaseActor;
			this.RoleCategoryScroll = new GenericScrollViewNew<FlagChallengeRoleCategoryItem, FlagChallengeRoleCategoryItemData>(scrollViewWithScrollbar, new Func<FlagChallengeRoleCategoryItem>(this.CreateRoleCategoryItem), gridActor, false, null);
			this.RefreshScrollView(this.RoleDataList);
			UUIItem item = base.GetItem(4);
			this.FilterSortEntrance = new FilterSortEntrance<RoleDataBase>(item, new TUpdateDataListFunction<RoleDataBase>(this.UpdateRoleList));
			this.FilterSortEntrance.UpdateData(EFilterSortGroupId.EditFormation, this.RoleDataList, Array.Empty<object>());
			int fixedLevel = ModelBase<FlagChallengeModel>.Instance.GetFixedLevel(this.ActivityId);
			base.GetArtText(11).SetText(fixedLevel.ToString());
			FlagChallengeLevel? levelConfig = ConfigBase<FlagChallengeConfig>.Instance.GetLevelConfig(this.LevelId);
			base.GetText(7).ShowTextNew(levelConfig.Value.Name);
			FlagStronghold? strongholdConfig = ConfigBase<FlagChallengeConfig>.Instance.GetStrongholdConfig(this.StrongholdId);
			base.GetText(8).ShowTextNew(strongholdConfig.Value.Name);
			base.GetText(10).ShowTextNew(strongholdConfig.Value.MonsterDesc);
			FlagChallengeStrongholdData strongholdData = ModelBase<FlagChallengeModel>.Instance.GetFlagChallengeData(this.ActivityId).GetStrongholdData(this.StrongholdId);
			int totalLevel = ModelBase<FlagChallengeModel>.Instance.GetTotalLevel(this.ActivityId);
			base.GetItem(14).SetUIActive(!strongholdData.IsPass && totalLevel < strongholdConfig.Value.RecommendLevel);
		}

		// Token: 0x0603C43A RID: 246842 RVA: 0x00F4A428 File Offset: 0x00F48628
		protected override void OnBeforeDestroy()
		{
			List<int> formationRoleIdList = this.GetFormationRoleIdList();
			ModelBase<FlagChallengeModel>.Instance.SaveFormationInfo(this.ActivityId, new HashSet<int>(formationRoleIdList));
			ModelBase<RoleSelectModel>.Instance.ClearData();
		}

		// Token: 0x0603C43B RID: 246843 RVA: 0x00F4A45C File Offset: 0x00F4865C
		private void InitViewData()
		{
			FlagChallengeSelectRoleViewParams openParam = this.OpenParam;
			this.ActivityId = openParam.ActivityId;
			this.LevelId = openParam.LevelId;
			this.StrongholdId = openParam.StrongholdId;
			this.RoleDataList = ModelBase<RoleModel>.Instance.GetRoleDataList(false);
			this.RoleDataList.Sort((RoleDataBase a, RoleDataBase b) => b.GetRoleConfig().Priority - a.GetRoleConfig().Priority);
			List<RoleDataBase> trialRoleDataList = this.GetTrialRoleDataList();
			HashSet<int> formationInfo = ModelBase<FlagChallengeModel>.Instance.GetFlagChallengeData(this.ActivityId).GetFormationInfo();
			List<int> list = new List<int>();
			foreach (int num in formationInfo)
			{
				RoleDataBase roleDataBase = null;
				foreach (RoleDataBase roleDataBase2 in this.RoleDataList)
				{
					if (roleDataBase2.GetRoleId() == num)
					{
						roleDataBase = roleDataBase2;
						break;
					}
				}
				RoleDataBase roleDataBase3 = null;
				foreach (RoleDataBase roleDataBase4 in trialRoleDataList)
				{
					if (roleDataBase4.GetRoleId() == num)
					{
						roleDataBase3 = roleDataBase4;
						break;
					}
				}
				if (roleDataBase3 == null)
				{
					if (roleDataBase == null)
					{
						list.Add(num);
					}
				}
				else if (!ModelBase<RoleModel>.Instance.IsRoleOwned(num))
				{
					list.Add(num);
				}
			}
			foreach (int item in list)
			{
				formationInfo.Remove(item);
			}
			ModelBase<RoleSelectModel>.Instance.ClearData();
			int num2 = 1;
			foreach (int num3 in formationInfo)
			{
				ModelBase<RoleSelectModel>.Instance.SelectedRoleSet.Add(num3);
				ModelBase<RoleSelectModel>.Instance.RoleIndexMap.Add(num2, ModelBase<RoleModel>.Instance.GetRoleDataById(num3, true));
				num2++;
			}
		}

		// Token: 0x0603C43C RID: 246844 RVA: 0x00F4A6B8 File Offset: 0x00F488B8
		private void RefreshScrollView(List<RoleDataBase> ownRoleList)
		{
			List<FlagChallengeRoleCategoryItemData> list = new List<FlagChallengeRoleCategoryItemData>();
			List<RoleDataBase> trialRoleList = this.GetTrialRoleDataList();
			if (trialRoleList.Count > 0)
			{
				list.Add(new FlagChallengeRoleCategoryItemData
				{
					CategoryType = EFlagChallengeRoleCategoryType.TrialRole,
					TitleKey = "Morale_32_Role_TempRole_Title",
					RoleList = trialRoleList,
					CanSelectRole = new Func<int, EToggleState, bool>(this.CanSelectRole),
					OnSelectRole = new Action<int, EToggleState>(this.OnSelectRole)
				});
			}
			list.Add(new FlagChallengeRoleCategoryItemData
			{
				CategoryType = EFlagChallengeRoleCategoryType.Role,
				TitleKey = "Morale_32_Role_MyRole_Title",
				RoleList = ownRoleList,
				CanSelectRole = new Func<int, EToggleState, bool>(this.CanSelectRole),
				OnSelectRole = new Action<int, EToggleState>(this.OnSelectRole)
			});
			this.RoleCategoryScroll.RefreshByData(list, delegate
			{
				EFlagChallengeRoleCategoryType eflagChallengeRoleCategoryType = (trialRoleList.Count > 0) ? EFlagChallengeRoleCategoryType.TrialRole : EFlagChallengeRoleCategoryType.Role;
				UUIItem itemByKey = this.RoleCategoryScroll.GetItemByKey((int)eflagChallengeRoleCategoryType);
				if (itemByKey != null)
				{
					this.RoleCategoryScroll.ScrollTo(itemByKey, false);
				}
			}, false);
		}

		// Token: 0x0603C43D RID: 246845 RVA: 0x00F4A7A4 File Offset: 0x00F489A4
		private List<RoleDataBase> GetTrialRoleDataList()
		{
			List<RoleDataBase> list = new List<RoleDataBase>();
			List<int> trialRoleIdList = this.GetTrialRoleIdList();
			if (trialRoleIdList != null)
			{
				foreach (int id in trialRoleIdList)
				{
					RoleConfig instance = ConfigBase<RoleConfig>.Instance;
					TrialRoleInfo? trialRoleInfo = (instance != null) ? instance.GetTrialRoleConfigByGroupId(id) : null;
					RoleModel instance2 = ModelBase<RoleModel>.Instance;
					RoleDataBase roleDataBase = (instance2 != null) ? instance2.GetRoleDataById(trialRoleInfo.Value.Id, true) : null;
					if (roleDataBase != null)
					{
						list.Add(roleDataBase);
					}
				}
			}
			return list;
		}

		// Token: 0x0603C43E RID: 246846 RVA: 0x00F4A84C File Offset: 0x00F48A4C
		private List<int> GetTrialRoleIdList()
		{
			int instId = ConfigBase<FlagChallengeConfig>.Instance.GetLevelConfig(this.LevelId).Value.InstId;
			InstanceDungeonConfig instance = ConfigBase<InstanceDungeonConfig>.Instance;
			InstanceDungeon? instanceDungeon = (instance != null) ? instance.GetConfig(instId) : null;
			if (instanceDungeon == null)
			{
				return new List<int>();
			}
			EditBattleTeamConfig instance2 = ConfigBase<EditBattleTeamConfig>.Instance;
			FightFormation? fightFormation = (instance2 != null) ? instance2.GetFightFormationConfig(instanceDungeon.Value.FightFormationId) : null;
			if (fightFormation == null)
			{
				return new List<int>();
			}
			return fightFormation.Value.TrialRoleIter().ToList<int>();
		}

		// Token: 0x0603C43F RID: 246847 RVA: 0x00F4A8F8 File Offset: 0x00F48AF8
		private void RefreshFormationRoles()
		{
			RoleSelectModel instance = ModelBase<RoleSelectModel>.Instance;
			List<IFlagChallengeFormationRoleItemData> list = new List<IFlagChallengeFormationRoleItemData>();
			for (int i = 1; i <= 3; i++)
			{
				RoleDataBase roleData;
				instance.RoleIndexMap.TryGetValue(i, out roleData);
				FlagChallengeFormationRoleItemData item = new FlagChallengeFormationRoleItemData
				{
					Index = i,
					RoleData = roleData
				};
				list.Add(item);
			}
			this.RoleLayout.RefreshByData(list, null, false);
		}

		// Token: 0x0603C440 RID: 246848 RVA: 0x00F4A958 File Offset: 0x00F48B58
		private List<int> GetFormationRoleIdList()
		{
			List<int> list = new List<int>();
			for (int i = 1; i <= 3; i++)
			{
				RoleDataBase roleDataBase;
				if (ModelBase<RoleSelectModel>.Instance.RoleIndexMap.TryGetValue(i, out roleDataBase) && roleDataBase != null)
				{
					list.Add(roleDataBase.GetRoleId());
				}
			}
			return list;
		}

		// Token: 0x0603C441 RID: 246849 RVA: 0x00F4A99C File Offset: 0x00F48B9C
		private void UpdateRoleList(List<RoleDataBase> list, bool isShowText, EFilterSortType _)
		{
			Dictionary<int, RoleDataBase> roleIndexMap = ModelBase<RoleSelectModel>.Instance.RoleIndexMap;
			List<RoleDataBase> list2 = new List<RoleDataBase>();
			for (int i = 1; i <= 3; i++)
			{
				RoleDataBase roleDataBase;
				if (roleIndexMap.TryGetValue(i, out roleDataBase) && !roleDataBase.IsTrialRole())
				{
					list2.Add(roleDataBase);
				}
			}
			foreach (RoleDataBase item in list)
			{
				if (!list2.Contains(item))
				{
					list2.Add(item);
				}
			}
			this.RefreshScrollView(list2);
		}

		// Token: 0x0603C442 RID: 246850 RVA: 0x00F4AA38 File Offset: 0x00F48C38
		private FlagChallengeRoleCategoryItem CreateRoleCategoryItem()
		{
			return new FlagChallengeRoleCategoryItem();
		}

		// Token: 0x0603C443 RID: 246851 RVA: 0x00F4AA3F File Offset: 0x00F48C3F
		private void OnCloseClick()
		{
			base.CloseMe(null);
		}

		// Token: 0x0603C444 RID: 246852 RVA: 0x00F4AA48 File Offset: 0x00F48C48
		private void OnHelpClick()
		{
			int formationHelpId = ConfigBase<FlagChallengeConfig>.Instance.GetFormationHelpId();
			ControllerBase<HelpController>.Instance.OpenHelpById(formationHelpId);
		}

		// Token: 0x0603C445 RID: 246853 RVA: 0x00F4AA6C File Offset: 0x00F48C6C
		private void OnConfirmBtnClick()
		{
			List<int> ids = this.GetFormationRoleIdList();
			if (ids.Count == 0)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("AtLeastOnePlayer", Array.Empty<object>());
				return;
			}
			FlagChallengeLevel? levelConfig = ConfigBase<FlagChallengeConfig>.Instance.GetLevelConfig(this.LevelId);
			if (ids.Count < 3)
			{
				ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.FlagChallengeFormationNotFullConfirm);
				confirmBoxDataNew.FunctionMap.Add(2, delegate
				{
					ControllerBase<FlagChallengeController>.Instance.RequestChallenge(levelConfig.Value.InstId, this.StrongholdId, ids);
				});
				ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
				return;
			}
			ControllerBase<FlagChallengeController>.Instance.RequestChallenge(levelConfig.Value.InstId, this.StrongholdId, ids);
		}

		// Token: 0x0603C446 RID: 246854 RVA: 0x00F4AB34 File Offset: 0x00F48D34
		private void OnDetailBtnClick()
		{
			IEnumerable<int> trialRoleIdList = this.GetTrialRoleIdList();
			List<int> roleIdList = ModelBase<RoleModel>.Instance.GetRoleIdList();
			List<int> list = new List<int>(trialRoleIdList);
			list.AddRange(roleIdList);
			HashSet<int> selectedRoleSet = ModelBase<RoleSelectModel>.Instance.SelectedRoleSet;
			List<int> list2 = new List<int>();
			foreach (int item in list)
			{
				if (!selectedRoleSet.Contains(item))
				{
					list2.Add(item);
				}
			}
			List<int> list3 = new List<int>(this.GetFormationRoleIdList());
			list3.AddRange(list2);
			ControllerBase<RoleController>.Instance.OpenRoleMainViewByParam(new OpenRoleMainViewData
			{
				AgentType = ERoleAgentType.Normal,
				RoleIdList = list3,
				TeamPositionType = new ETeamPositionType?(ETeamPositionType.RoleSelect)
			});
		}

		// Token: 0x0603C447 RID: 246855 RVA: 0x00F4ABF8 File Offset: 0x00F48DF8
		private bool CanSelectRole(int roleId, EToggleState state)
		{
			if (state != EToggleState.ETT_UnChecked)
			{
				return true;
			}
			if (ModelBase<RoleSelectModel>.Instance.SelectedRoleSet.Count >= 3)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("EditBattleTeamRoleFull", Array.Empty<object>());
				return false;
			}
			if (RoleUtils.HasSameRole(roleId, ModelBase<RoleSelectModel>.Instance.SelectedRoleSet.ToArray<int>(), null))
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("EditBattleTeamSameRole", Array.Empty<object>());
				return false;
			}
			return true;
		}

		// Token: 0x0603C448 RID: 246856 RVA: 0x00F4AC6C File Offset: 0x00F48E6C
		private void OnSelectRole(int roleId, EToggleState state)
		{
			RoleSelectModel instance = ModelBase<RoleSelectModel>.Instance;
			if (state == EToggleState.ETT_Checked)
			{
				instance.SelectedRoleSet.Add(roleId);
				for (int i = 1; i <= 3; i++)
				{
					if (!instance.RoleIndexMap.ContainsKey(i))
					{
						RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(roleId, true);
						instance.RoleIndexMap.Add(i, roleDataById);
						break;
					}
				}
			}
			else
			{
				instance.SelectedRoleSet.Remove(roleId);
				foreach (KeyValuePair<int, RoleDataBase> keyValuePair in instance.RoleIndexMap)
				{
					if (keyValuePair.Value.GetDataId() == roleId)
					{
						instance.RoleIndexMap.Remove(keyValuePair.Key);
						break;
					}
				}
			}
			this.RefreshFormationRoles();
		}

		// Token: 0x0603C449 RID: 246857 RVA: 0x00F4AD40 File Offset: 0x00F48F40
		private FlagChallengeFormationRoleItem CreateFormationRoleItem()
		{
			FlagChallengeFormationRoleItem flagChallengeFormationRoleItem = new FlagChallengeFormationRoleItem();
			flagChallengeFormationRoleItem.SetClickCallback(new Action<int>(this.OnClickFormationRoleItem));
			return flagChallengeFormationRoleItem;
		}

		// Token: 0x0603C44A RID: 246858 RVA: 0x00F4AD59 File Offset: 0x00F48F59
		private void OnClickFormationRoleItem(int roleId)
		{
			if (!ModelBase<RoleSelectModel>.Instance.SelectedRoleSet.Contains(roleId))
			{
				return;
			}
			this.OnSelectRole(roleId, EToggleState.ETT_UnChecked);
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnFlagChallengeRoleSelectCategoryUpdate, roleId);
		}

		// Token: 0x04021E22 RID: 138786
		private int ActivityId;

		// Token: 0x04021E23 RID: 138787
		private int LevelId;

		// Token: 0x04021E24 RID: 138788
		private int StrongholdId;

		// Token: 0x04021E25 RID: 138789
		private PopupCaptionItem PopupCaption;

		// Token: 0x04021E26 RID: 138790
		private GenericScrollViewNew<FlagChallengeRoleCategoryItem, FlagChallengeRoleCategoryItemData> RoleCategoryScroll;

		// Token: 0x04021E27 RID: 138791
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private FilterSortEntrance<RoleDataBase> FilterSortEntrance;

		// Token: 0x04021E28 RID: 138792
		private FlagChallengeStrongholdPanel StrongholdPanel;

		// Token: 0x04021E29 RID: 138793
		private List<RoleDataBase> RoleDataList = new List<RoleDataBase>();

		// Token: 0x04021E2A RID: 138794
		private GenericLayout<FlagChallengeFormationRoleItem, IFlagChallengeFormationRoleItemData> RoleLayout;
	}
}
