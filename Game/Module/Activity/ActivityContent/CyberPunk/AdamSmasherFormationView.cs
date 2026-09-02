using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.CyberPunk
{
	// Token: 0x02006962 RID: 26978
	[NullableContext(1)]
	[Nullable(0)]
	public class AdamSmasherFormationView : UiViewBase
	{
		// Token: 0x06042EF8 RID: 274168 RVA: 0x0112ED0A File Offset: 0x0112CF0A
		public AdamSmasherFormationView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06042EF9 RID: 274169 RVA: 0x0112ED40 File Offset: 0x0112CF40
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIDynScrollViewComponent)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(7, typeof(UUIHorizontalLayout)),
				new ValueTuple<int, Type>(8, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIText)),
				new ValueTuple<int, Type>(5, typeof(UUIText)),
				new ValueTuple<int, Type>(6, typeof(UUIText)),
				new ValueTuple<int, Type>(9, typeof(UUIItem)),
				new ValueTuple<int, Type>(10, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIItem))
			};
		}

		// Token: 0x06042EFA RID: 274170 RVA: 0x0112EE4C File Offset: 0x0112D04C
		protected override UniTask OnBeforeStartAsync()
		{
			AdamSmasherFormationView.<OnBeforeStartAsync>d__16 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<AdamSmasherFormationView.<OnBeforeStartAsync>d__16>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06042EFB RID: 274171 RVA: 0x0112EE8F File Offset: 0x0112D08F
		protected override void OnStart()
		{
			this.FilterSortEntranceItem.UpdateData(EFilterSortGroupId.EditBattleTeam, this.AllRoleList, Array.Empty<object>());
			this.OnFilterSortUpdate(this.AllRoleList, false, EFilterSortType.Sort);
			this.DynamicRoleGroupLayout.LateScrollTo(0);
			this.RefreshTargetInfo();
			this.RefreshButtonState();
		}

		// Token: 0x06042EFC RID: 274172 RVA: 0x0112EECE File Offset: 0x0112D0CE
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add<IReadOnlySet<int>>(EEventName.OnActivityClose, new Action<IReadOnlySet<int>>(this.OnActivityClose));
		}

		// Token: 0x06042EFD RID: 274173 RVA: 0x0112EEEC File Offset: 0x0112D0EC
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove<IReadOnlySet<int>>(EEventName.OnActivityClose, new Action<IReadOnlySet<int>>(this.OnActivityClose));
		}

		// Token: 0x06042EFE RID: 274174 RVA: 0x0112EF0A File Offset: 0x0112D10A
		protected override void OnBeforeDestroy()
		{
			ModelBase<RoleSelectModel>.Instance.ClearData();
			FilterSortEntrance<RoleDataBase> filterSortEntranceItem = this.FilterSortEntranceItem;
			if (filterSortEntranceItem != null)
			{
				filterSortEntranceItem.Destroy(null);
			}
			this.FilterSortEntranceItem = null;
		}

		// Token: 0x06042EFF RID: 274175 RVA: 0x0112EF30 File Offset: 0x0112D130
		private UniTask InitRoleGroupLayout()
		{
			AdamSmasherFormationView.<InitRoleGroupLayout>d__21 <InitRoleGroupLayout>d__;
			<InitRoleGroupLayout>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitRoleGroupLayout>d__.<>4__this = this;
			<InitRoleGroupLayout>d__.<>1__state = -1;
			<InitRoleGroupLayout>d__.<>t__builder.Start<AdamSmasherFormationView.<InitRoleGroupLayout>d__21>(ref <InitRoleGroupLayout>d__);
			return <InitRoleGroupLayout>d__.<>t__builder.Task;
		}

		// Token: 0x06042F00 RID: 274176 RVA: 0x0112EF74 File Offset: 0x0112D174
		private AdamFormationRoleGroupInfo[] GenerateAllRoleGroupInfo([Nullable(new byte[]
		{
			2,
			1
		})] List<RoleDataBase> roleList = null)
		{
			if (roleList == null)
			{
				roleList = this.AllRoleList;
			}
			List<AdamFormationRoleGroupInfo> list = new List<AdamFormationRoleGroupInfo>();
			List<RoleDataBase> classifiedRoleList = this.GetClassifiedRoleList(roleList, true);
			AdamFormationRoleGroupTitleInfo titleInfo = new AdamFormationRoleGroupTitleInfo
			{
				TitleTextId = "AdamChallenge_TrialRole",
				IsEmpty = (classifiedRoleList.Count == 0)
			};
			list.Add(new AdamFormationRoleGroupInfo
			{
				IsTitleType = true,
				TitleInfo = titleInfo
			});
			if (classifiedRoleList.Count > 0)
			{
				list.Add(new AdamFormationRoleGroupInfo
				{
					IsTitleType = false,
					DataList = classifiedRoleList.ToArray()
				});
			}
			List<RoleDataBase> classifiedRoleList2 = this.GetClassifiedRoleList(roleList, false);
			AdamFormationRoleGroupTitleInfo titleInfo2 = new AdamFormationRoleGroupTitleInfo
			{
				TitleTextId = "AdamChallenge_OwnRole",
				IsEmpty = (classifiedRoleList2.Count == 0)
			};
			list.Add(new AdamFormationRoleGroupInfo
			{
				IsTitleType = true,
				TitleInfo = titleInfo2
			});
			if (classifiedRoleList2.Count > 0)
			{
				list.Add(new AdamFormationRoleGroupInfo
				{
					IsTitleType = false,
					DataList = classifiedRoleList2.ToArray()
				});
			}
			return list.ToArray();
		}

		// Token: 0x06042F01 RID: 274177 RVA: 0x0112F06C File Offset: 0x0112D26C
		private List<RoleDataBase> GetClassifiedRoleList(List<RoleDataBase> wholeRoleList, bool needTrial)
		{
			List<RoleDataBase> list = new List<RoleDataBase>();
			foreach (RoleDataBase roleDataBase in wholeRoleList)
			{
				if (roleDataBase.IsTrialRole() == needTrial)
				{
					list.Add(roleDataBase);
				}
			}
			Dictionary<RoleDataBase, int> originalOrder = new Dictionary<RoleDataBase, int>();
			for (int i = 0; i < list.Count; i++)
			{
				originalOrder[list[i]] = i;
			}
			list.Sort(delegate(RoleDataBase a, RoleDataBase b)
			{
				int level = a.GetLevelData().GetLevel();
				int level2 = b.GetLevelData().GetLevel();
				if (level == level2)
				{
					int num = (this.RecommendedRoleIdSet.Contains(a.GetDataId()) > false) ? 1 : 0;
					int num2 = (this.RecommendedRoleIdSet.Contains(b.GetDataId()) > false) ? 1 : 0;
					if (num != num2)
					{
						return num2 - num;
					}
				}
				int num4;
				int num3 = originalOrder.TryGetValue(a, out num4) ? num4 : 0;
				int num6;
				int num5 = originalOrder.TryGetValue(b, out num6) ? num6 : 0;
				return num3 - num5;
			});
			return list;
		}

		// Token: 0x06042F02 RID: 274178 RVA: 0x0112F120 File Offset: 0x0112D320
		private void OnFilterSortUpdate(List<RoleDataBase> list, bool isOutSideChange, EFilterSortType operationType)
		{
			Dictionary<int, RoleDataBase> roleIndexMap = ModelBase<RoleSelectModel>.Instance.RoleIndexMap;
			List<RoleDataBase> list2 = new List<RoleDataBase>();
			for (int i = 1; i <= 3; i++)
			{
				RoleDataBase item;
				if (roleIndexMap.TryGetValue(i, out item))
				{
					list2.Add(item);
				}
			}
			foreach (RoleDataBase item2 in list)
			{
				if (!list2.Contains(item2))
				{
					list2.Add(item2);
				}
			}
			this.DynamicRoleGroupLayout.RefreshByData(this.GenerateAllRoleGroupInfo(list2), false, false);
		}

		// Token: 0x06042F03 RID: 274179 RVA: 0x0112F1C0 File Offset: 0x0112D3C0
		private AdamFormationRoleContainer OnCreateRoleGroup(AdamFormationRoleGroupInfo data, UUIItem uiItem, int index)
		{
			return new AdamFormationRoleContainer
			{
				RefreshRole = new Action<RoleDataBase>(this.RefreshRoleSelect),
				RecommendedRoleIdSet = this.RecommendedRoleIdSet
			};
		}

		// Token: 0x06042F04 RID: 274180 RVA: 0x0112F1E5 File Offset: 0x0112D3E5
		private void RefreshRoleSelect(RoleDataBase roleData)
		{
			this.CurSelectRole = roleData;
			this.RefreshTeamSelect();
			this.RefreshButtonState();
		}

		// Token: 0x06042F05 RID: 274181 RVA: 0x0112F1FA File Offset: 0x0112D3FA
		private WeeklyRogueRolePosItem CreateTeamSlotItem()
		{
			return new WeeklyRogueRolePosItem
			{
				OnBtnClickFunc = new Action<RoleDataBase>(this.OnBtnRolePosClick)
			};
		}

		// Token: 0x06042F06 RID: 274182 RVA: 0x0112F214 File Offset: 0x0112D414
		[NullableContext(2)]
		private void OnBtnRolePosClick(RoleDataBase data)
		{
			if (data == null)
			{
				return;
			}
			Dictionary<int, RoleDataBase> roleIndexMap = ModelBase<RoleSelectModel>.Instance.RoleIndexMap;
			HashSet<int> selectedRoleSet = ModelBase<RoleSelectModel>.Instance.SelectedRoleSet;
			foreach (KeyValuePair<int, RoleDataBase> keyValuePair in roleIndexMap)
			{
				if (keyValuePair.Value == data)
				{
					roleIndexMap.Remove(keyValuePair.Key);
					selectedRoleSet.Remove(data.GetDataId());
					break;
				}
			}
			AdamFormationRoleContainer[] scrollItemItems = this.DynamicRoleGroupLayout.GetScrollItemItems();
			for (int i = 0; i < scrollItemItems.Length; i++)
			{
				scrollItemItems[i].Refresh();
			}
			this.RefreshTeamSelect();
			this.RefreshButtonState();
		}

		// Token: 0x06042F07 RID: 274183 RVA: 0x0112F2D4 File Offset: 0x0112D4D4
		private List<int> GetCurrentSelectRoleList()
		{
			Dictionary<int, RoleDataBase> roleIndexMap = ModelBase<RoleSelectModel>.Instance.RoleIndexMap;
			List<int> list = new List<int>();
			for (int i = 1; i <= 3; i++)
			{
				RoleDataBase roleDataBase;
				if (roleIndexMap.TryGetValue(i, out roleDataBase))
				{
					list.Add(roleDataBase.GetDataId());
				}
			}
			return list;
		}

		// Token: 0x06042F08 RID: 274184 RVA: 0x0112F318 File Offset: 0x0112D518
		private void RefreshTeamSelect()
		{
			Dictionary<int, RoleDataBase> roleIndexMap = ModelBase<RoleSelectModel>.Instance.RoleIndexMap;
			List<IWeeklyRogueRolePosInfo> list = new List<IWeeklyRogueRolePosInfo>();
			for (int i = 1; i <= 3; i++)
			{
				WeeklyRogueRolePosInfo weeklyRogueRolePosInfo = new WeeklyRogueRolePosInfo();
				RoleDataBase data;
				if (roleIndexMap.TryGetValue(i, out data))
				{
					weeklyRogueRolePosInfo.Data = data;
					weeklyRogueRolePosInfo.IsRecommend = new bool?(false);
				}
				list.Add(weeklyRogueRolePosInfo);
			}
			this.TeamSlotLayout.RefreshByData(list, null, false);
		}

		// Token: 0x06042F09 RID: 274185 RVA: 0x0112F37C File Offset: 0x0112D57C
		private void RefreshButtonState()
		{
			bool enableClick = ModelBase<RoleSelectModel>.Instance.RoleIndexMap.Count > 0;
			ButtonItem startChallengeButtonItem = this.StartChallengeButtonItem;
			if (startChallengeButtonItem == null)
			{
				return;
			}
			startChallengeButtonItem.SetEnableClick(enableClick);
		}

		// Token: 0x06042F0A RID: 274186 RVA: 0x0112F3B0 File Offset: 0x0112D5B0
		private void OnClickStartChallenge(int a)
		{
			List<int> currentSelectRoleList = this.GetCurrentSelectRoleList();
			if (currentSelectRoleList.Count == 0)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("NoRole", Array.Empty<object>());
				return;
			}
			Singleton<Log>.Instance.Info(ELogModule.Activity, ELogAuthor.SWC, "[AdamSmasherFormation] 提交编队开始挑战", default(ReadOnlySpan<ValueTuple<string, object>>));
			Singleton<UiLayer>.Instance.SetShowMaskLayer("AdamSmasherFormationView.StartChallenge", true);
			ControllerBase<AdamSmasherController>.Instance.RequestStartChallenge(this.StageId, currentSelectRoleList).ContinueWith(delegate(bool Result)
			{
				Singleton<UiLayer>.Instance.SetShowMaskLayer("AdamSmasherFormationView.StartChallenge", false);
			});
		}

		// Token: 0x06042F0B RID: 274187 RVA: 0x0112F448 File Offset: 0x0112D648
		private void OnClickRoleDetail(int a)
		{
			if (this.CurSelectRole == null)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("CharacterDetailsTip", Array.Empty<object>());
				return;
			}
			int dataId = this.CurSelectRole.GetDataId();
			List<int> currentSelectRoleList = this.GetCurrentSelectRoleList();
			List<int> ownedRoleIds = (from role in this.CachedOwnRoleList
			select role.GetDataId()).ToList<int>();
			List<int> ownedSelectedFirst = (from id in currentSelectRoleList
			where ownedRoleIds.Contains(id)
			select id).ToList<int>();
			List<int> list = new List<int>(ownedSelectedFirst);
			list.AddRange(from id in ownedRoleIds
			where !ownedSelectedFirst.Contains(id)
			select id);
			OpenRoleMainViewData param = new OpenRoleMainViewData
			{
				AgentType = ERoleAgentType.Normal,
				SelectRoleId = new int?(dataId),
				RoleIdList = list,
				TeamPositionType = new ETeamPositionType?(ETeamPositionType.RoleSelect)
			};
			ControllerBase<RoleController>.Instance.OpenRoleMainViewByParam(param);
		}

		// Token: 0x06042F0C RID: 274188 RVA: 0x0112F53F File Offset: 0x0112D73F
		private void OnClickHelp()
		{
			ControllerBase<HelpController>.Instance.OpenHelpById(this.GetHelpId());
		}

		// Token: 0x06042F0D RID: 274189 RVA: 0x0112F551 File Offset: 0x0112D751
		private void OnClickClose()
		{
			base.CloseMe(null);
		}

		// Token: 0x06042F0E RID: 274190 RVA: 0x0112F55A File Offset: 0x0112D75A
		private void OnActivityClose(IReadOnlySet<int> closeActivities)
		{
			if (closeActivities.Contains(ControllerBase<CyberPunkController>.Instance.CurrentActivityId))
			{
				ControllerBase<ActivityController>.Instance.ShowActivityRefreshAndBackToBattleView();
			}
		}

		// Token: 0x06042F0F RID: 274191 RVA: 0x0112F578 File Offset: 0x0112D778
		private void RefreshTargetInfo()
		{
			CyberPunkConfig instance = ConfigBase<CyberPunkConfig>.Instance;
			EdgeRunnerLordGym? edgeRunnerLordGym = (instance != null) ? instance.GetStageConfig(this.StageId) : null;
			if (edgeRunnerLordGym == null)
			{
				return;
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), "AdamChallenge_Level", new <>z__ReadOnlySingleElementList<object>(edgeRunnerLordGym.Value.Level));
			if (edgeRunnerLordGym.Value.BuffNumLength > 0)
			{
				string[] array = new string[edgeRunnerLordGym.Value.BuffNumLength];
				for (int i = 0; i < edgeRunnerLordGym.Value.BuffNumLength; i++)
				{
					array[i] = edgeRunnerLordGym.Value.BuffNum(i);
				}
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(6), edgeRunnerLordGym.Value.BuffDesc, array);
				return;
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(6), edgeRunnerLordGym.Value.BuffDesc, Array.Empty<object>());
		}

		// Token: 0x06042F10 RID: 274192 RVA: 0x0112F67F File Offset: 0x0112D87F
		private int GetHelpId()
		{
			return 0;
		}

		// Token: 0x040254A7 RID: 152743
		public const int FORMATION_MAX_NUM = 3;

		// Token: 0x040254A8 RID: 152744
		[Nullable(2)]
		private PopupCaptionItem CaptionItem;

		// Token: 0x040254A9 RID: 152745
		[Nullable(2)]
		private ButtonItem RoleDetailButtonItem;

		// Token: 0x040254AA RID: 152746
		[Nullable(2)]
		private ButtonItem StartChallengeButtonItem;

		// Token: 0x040254AB RID: 152747
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private FilterSortEntrance<RoleDataBase> FilterSortEntranceItem;

		// Token: 0x040254AC RID: 152748
		[Nullable(new byte[]
		{
			2,
			1,
			1,
			1
		})]
		protected DynamicScrollView<AdamFormationRoleContainer, AdamFormationRoleSizeItem, AdamFormationRoleGroupInfo> DynamicRoleGroupLayout;

		// Token: 0x040254AD RID: 152749
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<WeeklyRogueRolePosItem, IWeeklyRogueRolePosInfo> TeamSlotLayout;

		// Token: 0x040254AE RID: 152750
		private List<RoleDataBase> AllRoleList = new List<RoleDataBase>();

		// Token: 0x040254AF RID: 152751
		private readonly List<RoleDataBase> CachedTrialRoleList = new List<RoleDataBase>();

		// Token: 0x040254B0 RID: 152752
		private List<RoleDataBase> CachedOwnRoleList = new List<RoleDataBase>();

		// Token: 0x040254B1 RID: 152753
		private HashSet<int> RecommendedRoleIdSet = new HashSet<int>();

		// Token: 0x040254B2 RID: 152754
		private int StageId;

		// Token: 0x040254B3 RID: 152755
		[Nullable(2)]
		private RoleDataBase CurSelectRole;

		// Token: 0x0200C902 RID: 51458
		[NullableContext(0)]
		private enum EComponent
		{
			// Token: 0x0403DD4D RID: 253261
			Caption,
			// Token: 0x0403DD4E RID: 253262
			DynamicGroupLayout,
			// Token: 0x0403DD4F RID: 253263
			DynamicGroupItem,
			// Token: 0x0403DD50 RID: 253264
			FilterSortItem,
			// Token: 0x0403DD51 RID: 253265
			BossNameText,
			// Token: 0x0403DD52 RID: 253266
			BossLevelText,
			// Token: 0x0403DD53 RID: 253267
			BuffDescText,
			// Token: 0x0403DD54 RID: 253268
			RoleListLayout,
			// Token: 0x0403DD55 RID: 253269
			RoleListGroupItem,
			// Token: 0x0403DD56 RID: 253270
			BtnRoleDetail,
			// Token: 0x0403DD57 RID: 253271
			BtnStartChallenge
		}
	}
}
