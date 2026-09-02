using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.BossRush
{
	// Token: 0x020069C1 RID: 27073
	[NullableContext(1)]
	[Nullable(0)]
	internal class TeamItem : UiPanelBase
	{
		// Token: 0x060431EF RID: 274927 RVA: 0x0113DCF0 File Offset: 0x0113BEF0
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUIText)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUIHorizontalLayout)),
				new ValueTuple<int, Type>(6, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(0, new Action(this.OnClickButton))
			};
		}

		// Token: 0x060431F0 RID: 274928 RVA: 0x0113DDC5 File Offset: 0x0113BFC5
		private void OnClickButton()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.MultiTeamRoleSelectView, this.GetSelectViewData(), null);
		}

		// Token: 0x060431F1 RID: 274929 RVA: 0x0113DDE0 File Offset: 0x0113BFE0
		private MultiTeamRoleSelectData GetSelectViewData()
		{
			RoleInstance[] roleList = ModelBase<RoleModel>.Instance.GetRoleList();
			List<MultiTeamRoleGridData> list = new List<MultiTeamRoleGridData>();
			foreach (RoleInstance roleInstance in roleList)
			{
				if (roleInstance.GetRoleId() != 0)
				{
					MultiTeamRoleGridData item = MultiTeamRoleGridData.Phrase(roleInstance, false, false, false, false);
					list.Add(item);
				}
			}
			List<MultiTeamRoleGridData> list2 = new List<MultiTeamRoleGridData>();
			if (this.CurrentTeamData == null || this.CurrentTeamData.LevelInfo == null)
			{
				return this.CreateMultiTeamRoleSelectData(new List<MultiTeamRoleData>(), list);
			}
			int fightFormationId = this.CurrentTeamData.LevelInfo.GetInstanceDungeonConfig().Value.FightFormationId;
			FightFormation? fightFormationConfig = ConfigBase<EditBattleTeamConfig>.Instance.GetFightFormationConfig(fightFormationId);
			if (fightFormationConfig != null)
			{
				foreach (int id in fightFormationConfig.Value.TrialRole())
				{
					TrialRoleInfo? trialRoleConfigByGroupId = ConfigBase<RoleConfig>.Instance.GetTrialRoleConfigByGroupId(id);
					if (trialRoleConfigByGroupId != null)
					{
						RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(trialRoleConfigByGroupId.Value.Id, true);
						if (roleDataById != null)
						{
							list2.Add(MultiTeamRoleGridData.Phrase(roleDataById, false, false, false, false));
						}
					}
				}
			}
			MultiTeamRoleData item2 = MultiTeamRoleData.Phrase("BossRushNormalRole", list);
			List<MultiTeamRoleData> list3 = new List<MultiTeamRoleData>();
			if (list2.Count > 0)
			{
				MultiTeamRoleData item3 = MultiTeamRoleData.Phrase("BossRushTrailRole", list2);
				list3.Add(item3);
			}
			list3.Add(item2);
			MultiTeamRoleSelectData multiTeamRoleSelectData = MultiTeamRoleSelectData.Phrase(new EFilterSortGroupId?(EFilterSortGroupId.EditFormation), 3, this.CurrentTeamData.GetCurrentTeamMembers(), null, null, delegate(int[] idList, int[] tagList)
			{
				for (int j = 0; j < idList.Length; j++)
				{
					int roleId = idList[j];
					this.CurrentTeamData.SetIndexTeamMembers(j, roleId);
				}
				this.CurrentTeamData.ReSortTeamMembers();
				this.Refresh(this.CurrentTeamData);
				Action onChangeRoleCallBack = this.OnChangeRoleCallBack;
				if (onChangeRoleCallBack == null)
				{
					return;
				}
				onChangeRoleCallBack();
			}, null, list3, null, "");
			multiTeamRoleSelectData.IfCanSelectCheck = new Func<int, int[], bool>(this.IfCanSelectCheck);
			return multiTeamRoleSelectData;
		}

		// Token: 0x060431F2 RID: 274930 RVA: 0x0113DF88 File Offset: 0x0113C188
		private MultiTeamRoleSelectData CreateMultiTeamRoleSelectData(List<MultiTeamRoleData> teamRoleDataList, List<MultiTeamRoleGridData> currentRoleTeamRoleGridData)
		{
			MultiTeamRoleData item = MultiTeamRoleData.Phrase("BossRushNormalRole", currentRoleTeamRoleGridData);
			teamRoleDataList.Add(item);
			EFilterSortGroupId? useWay = new EFilterSortGroupId?(EFilterSortGroupId.EditFormation);
			int teamLength = 3;
			BossRushTeamInfo currentTeamData = this.CurrentTeamData;
			return MultiTeamRoleSelectData.Phrase(useWay, teamLength, ((currentTeamData != null) ? currentTeamData.GetCurrentTeamMembers() : null) ?? new int[0], null, null, delegate(int[] idList, int[] tagList)
			{
				if (this.CurrentTeamData != null)
				{
					for (int i = 0; i < idList.Length; i++)
					{
						int roleId = idList[i];
						this.CurrentTeamData.SetIndexTeamMembers(i, roleId);
					}
					this.CurrentTeamData.ReSortTeamMembers();
					this.Refresh(this.CurrentTeamData);
					Action onChangeRoleCallBack = this.OnChangeRoleCallBack;
					if (onChangeRoleCallBack == null)
					{
						return;
					}
					onChangeRoleCallBack();
				}
			}, null, teamRoleDataList, null, "");
		}

		// Token: 0x060431F3 RID: 274931 RVA: 0x0113DFE6 File Offset: 0x0113C1E6
		public void BindOnSelectRoleCall(Action callBack)
		{
			this.OnChangeRoleCallBack = callBack;
		}

		// Token: 0x060431F4 RID: 274932 RVA: 0x0113DFF0 File Offset: 0x0113C1F0
		private bool IfCanSelectCheck(int roleConfigId, int[] selectedRoleList)
		{
			if (selectedRoleList.Contains(roleConfigId))
			{
				return true;
			}
			if (this.CurrentTeamData == null || this.CurrentTeamData.LevelInfo == null)
			{
				return false;
			}
			int fightFormationId = this.CurrentTeamData.LevelInfo.GetInstanceDungeonConfig().Value.FightFormationId;
			FightFormation? fightFormationConfig = ConfigBase<EditBattleTeamConfig>.Instance.GetFightFormationConfig(fightFormationId);
			if (fightFormationConfig == null)
			{
				return false;
			}
			int num = roleConfigId;
			foreach (int id in fightFormationConfig.Value.TrialRole())
			{
				TrialRoleInfo? trialRoleConfigByGroupId = ConfigBase<RoleConfig>.Instance.GetTrialRoleConfigByGroupId(id);
				if (trialRoleConfigByGroupId != null && trialRoleConfigByGroupId.Value.Id == roleConfigId)
				{
					num = trialRoleConfigByGroupId.Value.ParentId;
					break;
				}
			}
			if (num != roleConfigId && selectedRoleList.Contains(num))
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("BossRushSameFormation", Array.Empty<object>());
				return false;
			}
			foreach (int num2 in selectedRoleList)
			{
				int num3 = num2;
				TrialRoleInfo? trialRoleConfigByGroupId2 = ConfigBase<RoleConfig>.Instance.GetTrialRoleConfigByGroupId(num2);
				if (trialRoleConfigByGroupId2 != null)
				{
					num3 = trialRoleConfigByGroupId2.Value.ParentId;
				}
				if (num3 == num)
				{
					ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("BossRushSameFormation", Array.Empty<object>());
					return false;
				}
			}
			return true;
		}

		// Token: 0x060431F5 RID: 274933 RVA: 0x0113E14C File Offset: 0x0113C34C
		protected override UniTask OnBeforeStartAsync()
		{
			TeamItem.<OnBeforeStartAsync>d__12 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<TeamItem.<OnBeforeStartAsync>d__12>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060431F6 RID: 274934 RVA: 0x0113E18F File Offset: 0x0113C38F
		private BossRushTeamRoleItem CreateTeamRoleItem()
		{
			return new BossRushTeamRoleItem();
		}

		// Token: 0x060431F7 RID: 274935 RVA: 0x0113E196 File Offset: 0x0113C396
		public void Refresh(BossRushTeamInfo data)
		{
			this.CurrentTeamData = data;
			this.RefreshRecommendLevelText(data);
			this.RefreshElementItem(data);
			this.RefreshTeamRole(data);
			this.RefreshRecommendElementText(data);
		}

		// Token: 0x060431F8 RID: 274936 RVA: 0x0113E1BC File Offset: 0x0113C3BC
		private void RefreshRecommendElementText(BossRushTeamInfo data)
		{
			if (data == null || data.GetCurrentSelectLevel() == null)
			{
				return;
			}
			string textStringId = (data.GetCurrentSelectLevel().GetRecommendElementIdArray().Length != 0) ? "BossRushRecommendElement" : "BossRushRecommendElementNone";
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), textStringId, Array.Empty<object>());
		}

		// Token: 0x060431F9 RID: 274937 RVA: 0x0113E208 File Offset: 0x0113C408
		private void RefreshRecommendLevelText(BossRushTeamInfo data)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), "BossRushRecommendLevel", new <>z__ReadOnlySingleElementList<object>(data.GetRecommendLevel().ToString()));
		}

		// Token: 0x060431FA RID: 274938 RVA: 0x0113E240 File Offset: 0x0113C440
		private void RefreshElementItem(BossRushTeamInfo data)
		{
			foreach (CommonElementItem commonElementItem in this.ElementItemArray)
			{
				commonElementItem.SetActive(false);
			}
			if (data == null || data.GetCurrentSelectLevel() == null)
			{
				return;
			}
			int[] recommendElementIdArray = data.GetCurrentSelectLevel().GetRecommendElementIdArray();
			for (int i = 0; i < recommendElementIdArray.Length; i++)
			{
				if (recommendElementIdArray[i] != 0 && i < this.ElementItemArray.Count)
				{
					this.ElementItemArray[i].SetActive(true);
					this.ElementItemArray[i].Refresh(recommendElementIdArray[i], false, i);
				}
			}
		}

		// Token: 0x060431FB RID: 274939 RVA: 0x0113E2F4 File Offset: 0x0113C4F4
		private void OnSelectTeamRole()
		{
			Action onChangeRoleCallBack = this.OnChangeRoleCallBack;
			if (onChangeRoleCallBack == null)
			{
				return;
			}
			onChangeRoleCallBack();
		}

		// Token: 0x060431FC RID: 274940 RVA: 0x0113E308 File Offset: 0x0113C508
		public void RefreshTeamRole(BossRushTeamInfo data)
		{
			if (data == null || this.TeamLayout == null)
			{
				return;
			}
			int[] currentTeamMembers = data.GetCurrentTeamMembers();
			int num = 3;
			List<BossRushTeamData> list = new List<BossRushTeamData>();
			foreach (int roleId in currentTeamMembers)
			{
				list.Add(new BossRushTeamData
				{
					RoleId = roleId,
					TeamInfo = data,
					OnSelectRole = new Action(this.OnSelectTeamRole)
				});
			}
			while (list.Count < num)
			{
				list.Add(new BossRushTeamData
				{
					RoleId = 0,
					TeamInfo = data,
					OnSelectRole = new Action(this.OnSelectTeamRole)
				});
			}
			this.TeamLayout.RefreshByData(list, null, false);
		}

		// Token: 0x04025678 RID: 153208
		[Nullable(2)]
		private CommonElementItem ElementItem1;

		// Token: 0x04025679 RID: 153209
		[Nullable(2)]
		private CommonElementItem ElementItem2;

		// Token: 0x0402567A RID: 153210
		private readonly List<CommonElementItem> ElementItemArray = new List<CommonElementItem>();

		// Token: 0x0402567B RID: 153211
		[Nullable(2)]
		private Action OnChangeRoleCallBack;

		// Token: 0x0402567C RID: 153212
		[Nullable(2)]
		protected BossRushTeamInfo CurrentTeamData;

		// Token: 0x0402567D RID: 153213
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<BossRushTeamRoleItem, BossRushTeamData> TeamLayout;
	}
}
