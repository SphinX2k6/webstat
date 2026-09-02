using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BossPiling.View.Item
{
	// Token: 0x02005F0E RID: 24334
	[NullableContext(1)]
	[Nullable(0)]
	public class BossPilingTeamPanel : UiPanelBase
	{
		// Token: 0x0603D1C5 RID: 250309 RVA: 0x00F860C5 File Offset: 0x00F842C5
		public BossPilingTeamPanel(int levelId)
		{
			this.LevelId = levelId;
		}

		// Token: 0x0603D1C6 RID: 250310 RVA: 0x00F860F8 File Offset: 0x00F842F8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 7;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIHorizontalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickedBtn));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603D1C7 RID: 250311 RVA: 0x00F86244 File Offset: 0x00F84444
		protected override UniTask OnBeforeStartAsync()
		{
			BossPilingTeamPanel.<OnBeforeStartAsync>d__10 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<BossPilingTeamPanel.<OnBeforeStartAsync>d__10>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603D1C8 RID: 250312 RVA: 0x00F86288 File Offset: 0x00F84488
		protected override void OnStart()
		{
			BossPilingLevels value = ConfigBase<BossPilingConfig>.Instance.GetLevelInfo(this.LevelId).Value;
			if (value.RecommendFetter().Length != 0)
			{
				BossPilingFetterItem element = this.Element1;
				if (element != null)
				{
					element.SetUiActive(true);
				}
				BossPilingFetterItem element2 = this.Element1;
				if (element2 != null)
				{
					element2.Refresh(value.RecommendFetter()[0]);
				}
			}
			else
			{
				BossPilingFetterItem element3 = this.Element1;
				if (element3 != null)
				{
					element3.SetUiActive(false);
				}
			}
			if (value.RecommendFetter().Length > 1)
			{
				BossPilingFetterItem element4 = this.Element2;
				if (element4 != null)
				{
					element4.SetUiActive(true);
				}
				BossPilingFetterItem element5 = this.Element2;
				if (element5 != null)
				{
					element5.Refresh(value.RecommendFetter()[1]);
				}
			}
			else
			{
				BossPilingFetterItem element6 = this.Element2;
				if (element6 != null)
				{
					element6.SetUiActive(false);
				}
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), "BossPilingActivity_DungeonDetail13", new <>z__ReadOnlySingleElementList<object>(value.RecommendLevel));
			BossPilingLevelInfo levelInfo = ModelBase<BossPilingModel>.Instance.GetActivityData().GetLevelInfo(this.LevelId);
			this.RoleData = new List<int>(levelInfo.SelectedRoleIds);
			for (int i = this.RoleData.Count; i < 3; i++)
			{
				this.RoleData.Add(0);
			}
			this.TagData = new List<int>(levelInfo.SelectedTagBranchIds);
			for (int j = this.TagData.Count; j < 3; j++)
			{
				this.TagData.Add(0);
			}
			this.RefreshRoleList();
			Singleton<EventSystem>.Instance.Add(EEventName.OnRoleChangeEnd, new Action(this.OnRoleChangeEnd));
			Singleton<EventSystem>.Instance.Add<int>(EEventName.OnRoleSkillBranchInGamePlayChanged, new Action<int>(this.OnRoleTagChange));
		}

		// Token: 0x0603D1C9 RID: 250313 RVA: 0x00F86429 File Offset: 0x00F84629
		protected override void OnBeforeDestroy()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnRoleChangeEnd, new Action(this.OnRoleChangeEnd));
			Singleton<EventSystem>.Instance.Remove<int>(EEventName.OnRoleSkillBranchInGamePlayChanged, new Action<int>(this.OnRoleTagChange));
		}

		// Token: 0x0603D1CA RID: 250314 RVA: 0x00F86463 File Offset: 0x00F84663
		[return: Nullable(new byte[]
		{
			0,
			1,
			1
		})]
		public ValueTuple<List<int>, List<int>> GetTeamListResult()
		{
			return new ValueTuple<List<int>, List<int>>(this.RoleData, this.TagData);
		}

		// Token: 0x0603D1CB RID: 250315 RVA: 0x00F86478 File Offset: 0x00F84678
		protected void RefreshRoleList()
		{
			List<BossPilingTeamRoleInfo> list = new List<BossPilingTeamRoleInfo>();
			for (int i = 0; i < this.RoleData.Count; i++)
			{
				BossPilingTeamRoleInfo item = new BossPilingTeamRoleInfo
				{
					RoleId = this.RoleData[i],
					TagId = this.TagData[i]
				};
				list.Add(item);
			}
			this.Layout.RefreshByData(list, null, false);
		}

		// Token: 0x0603D1CC RID: 250316 RVA: 0x00F864E0 File Offset: 0x00F846E0
		private BossPilingRoleItem CreateItem()
		{
			return new BossPilingRoleItem
			{
				OnClickedCb = new Action<int, int>(this.OnClickedCb)
			};
		}

		// Token: 0x0603D1CD RID: 250317 RVA: 0x00F864FC File Offset: 0x00F846FC
		private MultiTeamRoleSelectData GetSelectViewData()
		{
			RoleInstance[] roleList = ModelBase<RoleModel>.Instance.GetRoleList();
			List<MultiTeamRoleGridData> list = new List<MultiTeamRoleGridData>();
			BossPilingLevels value = ConfigBase<BossPilingConfig>.Instance.GetLevelInfo(this.LevelId).Value;
			int fightFormationId = ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(value.InstIds()[0]).Value.FightFormationId;
			FightFormation value2 = ConfigBase<EditBattleTeamConfig>.Instance.GetFightFormationConfig(fightFormationId).Value;
			foreach (RoleInstance roleInstance in roleList)
			{
				if (roleInstance.GetRoleId() != 0)
				{
					MultiTeamRoleGridData item = MultiTeamRoleGridData.Phrase(roleInstance, false, value2.RecommendFormation().Contains(roleInstance.GetRoleId()), false, false);
					list.Add(item);
				}
			}
			List<MultiTeamRoleGridData> list2 = new List<MultiTeamRoleGridData>();
			foreach (int id in value2.TrialRoleIter())
			{
				TrialRoleInfo? trialRoleConfigByGroupId = ConfigBase<RoleConfig>.Instance.GetTrialRoleConfigByGroupId(id);
				RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(trialRoleConfigByGroupId.Value.Id, true);
				if (roleDataById != null)
				{
					list2.Add(MultiTeamRoleGridData.Phrase(roleDataById, false, false, false, false));
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
			MultiTeamRoleSelectData multiTeamRoleSelectData = MultiTeamRoleSelectData.Phrase(new EFilterSortGroupId?(EFilterSortGroupId.EditFormation), 3, this.RoleData.ToArray(), delegate
			{
				for (int j = 0; j < this.RoleData.Count; j++)
				{
					int num = this.RoleData[j];
					if (this.TagChangeRoleSet.Contains(num))
					{
						this.TagData[j] = ModelBase<RoleModel>.Instance.GetRoleSkillBranchIdInCurrentGamePlay(num);
					}
					if (ModelBase<RoleModel>.Instance.IsMainRole(num))
					{
						int? curSelectMainRoleId = ModelBase<RoleModel>.Instance.GetCurSelectMainRoleId();
						int? num2 = curSelectMainRoleId;
						int num3 = num;
						if (!(num2.GetValueOrDefault() == num3 & num2 != null))
						{
							num2 = curSelectMainRoleId;
							num3 = 0;
							if (!(num2.GetValueOrDefault() == num3 & num2 != null))
							{
								this.RoleData[j] = curSelectMainRoleId.Value;
							}
						}
					}
				}
				this.RefreshRoleList();
			}, null, delegate(int[] idList, int[] tagConfigId)
			{
				for (int j = 0; j < idList.Length; j++)
				{
					this.RoleData[j] = idList[j];
					this.TagData[j] = tagConfigId[j];
				}
				this.RefreshRoleList();
			}, null, list3, null, "");
			multiTeamRoleSelectData.IfCanSelectCheck = new Func<int, int[], bool>(this.IfCanSelectCheck);
			MultiTeamTagDataItem multiTeamTagData = MultiTeamTagDataItem.Phrase(this.TagData.ToArray(), ESkillBranchCacheType.BossPiling);
			multiTeamRoleSelectData.SetMultiTeamTagData(multiTeamTagData);
			this.TagChangeRoleSet.Clear();
			return multiTeamRoleSelectData;
		}

		// Token: 0x0603D1CE RID: 250318 RVA: 0x00F866F4 File Offset: 0x00F848F4
		private bool IfCanSelectCheck(int roleConfigId, int[] selectedRoleList)
		{
			RoleConfig instance = ConfigBase<RoleConfig>.Instance;
			int? num = (instance != null) ? new int?(instance.GetBaseRoleId(roleConfigId)) : null;
			foreach (int num2 in selectedRoleList)
			{
				if (num2 != 0)
				{
					RoleConfig instance2 = ConfigBase<RoleConfig>.Instance;
					int? num3 = (instance2 != null) ? new int?(instance2.GetBaseRoleId(num2)) : null;
					int? num4 = num;
					if ((num3.GetValueOrDefault() == num4.GetValueOrDefault() & num3 != null == (num4 != null)) && roleConfigId != num2)
					{
						ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("BossRushSameFormation", Array.Empty<object>());
						return false;
					}
				}
			}
			return true;
		}

		// Token: 0x0603D1CF RID: 250319 RVA: 0x00F8679D File Offset: 0x00F8499D
		private void OnClickedCb(int roleId, int index)
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.MultiTeamRoleSelectView, this.GetSelectViewData(), null);
		}

		// Token: 0x0603D1D0 RID: 250320 RVA: 0x00F867B5 File Offset: 0x00F849B5
		private void OnClickedBtn()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.MultiTeamRoleSelectView, this.GetSelectViewData(), null);
		}

		// Token: 0x0603D1D1 RID: 250321 RVA: 0x00F867D0 File Offset: 0x00F849D0
		private void OnRoleChangeEnd()
		{
			for (int i = 0; i < this.RoleData.Count; i++)
			{
				int num = this.RoleData[i];
				if (ModelBase<RoleModel>.Instance.IsMainRole(num))
				{
					int? curSelectMainRoleId = ModelBase<RoleModel>.Instance.GetCurSelectMainRoleId();
					int? num2 = curSelectMainRoleId;
					int num3 = num;
					if (!(num2.GetValueOrDefault() == num3 & num2 != null))
					{
						num2 = curSelectMainRoleId;
						num3 = 0;
						if (!(num2.GetValueOrDefault() == num3 & num2 != null))
						{
							this.RoleData[i] = curSelectMainRoleId.Value;
						}
					}
				}
			}
			this.RefreshRoleList();
		}

		// Token: 0x0603D1D2 RID: 250322 RVA: 0x00F86865 File Offset: 0x00F84A65
		private void OnRoleTagChange(int roleId)
		{
			this.TagChangeRoleSet.Add(roleId);
		}

		// Token: 0x04022459 RID: 140377
		protected GenericLayout<BossPilingRoleItem, BossPilingTeamRoleInfo> Layout;

		// Token: 0x0402245A RID: 140378
		protected BossPilingFetterItem Element1;

		// Token: 0x0402245B RID: 140379
		protected BossPilingFetterItem Element2;

		// Token: 0x0402245C RID: 140380
		protected List<int> RoleData = new List<int>();

		// Token: 0x0402245D RID: 140381
		protected HashSet<int> TagChangeRoleSet = new HashSet<int>();

		// Token: 0x0402245E RID: 140382
		protected List<int> TagData = new List<int>();

		// Token: 0x0402245F RID: 140383
		protected int LevelId;

		// Token: 0x0200BF0D RID: 48909
		[NullableContext(0)]
		private enum EDefine
		{
			// Token: 0x0403ACE6 RID: 240870
			Btn,
			// Token: 0x0403ACE7 RID: 240871
			TxtLevel,
			// Token: 0x0403ACE8 RID: 240872
			TxtFetter,
			// Token: 0x0403ACE9 RID: 240873
			ElementItem1,
			// Token: 0x0403ACEA RID: 240874
			ElementItem2,
			// Token: 0x0403ACEB RID: 240875
			PanelRole,
			// Token: 0x0403ACEC RID: 240876
			RoleItem
		}
	}
}
