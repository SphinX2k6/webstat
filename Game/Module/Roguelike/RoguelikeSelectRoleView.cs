using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Module.UiComponent;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x02005193 RID: 20883
	[NullableContext(1)]
	[Nullable(0)]
	public class RoguelikeSelectRoleView : UiViewBase
	{
		// Token: 0x06035B7D RID: 220029 RVA: 0x00D7F9A1 File Offset: 0x00D7DBA1
		protected override void OnBeforeCreate()
		{
			this.UiSceneRoleActor = Singleton<UiSceneManager>.Instance.InitRoleSystemRoleActor(EUiModelUseWay.RoleInRogueView);
		}

		// Token: 0x06035B7E RID: 220030 RVA: 0x00D7F9B8 File Offset: 0x00D7DBB8
		public RoguelikeSelectRoleView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x06035B7F RID: 220031 RVA: 0x00D7FA14 File Offset: 0x00D7DC14
		protected unsafe override void OnRegisterComponent()
		{
			int num = 16;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIDynScrollViewComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIText));
			this.ComponentRegisterInfos = list;
			num2 = 5;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.OnBtnBack));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnBtnConfirm));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(8, new Action(this.OnBtnEntrySelect));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(10, new Action(this.OnBtnDetail));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(12, new Action(this.OnBtnHelp));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06035B80 RID: 220032 RVA: 0x00D7FD20 File Offset: 0x00D7DF20
		protected override UniTask OnBeforeStartAsync()
		{
			RoguelikeSelectRoleView.<OnBeforeStartAsync>d__21 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RoguelikeSelectRoleView.<OnBeforeStartAsync>d__21>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06035B81 RID: 220033 RVA: 0x00D7FD63 File Offset: 0x00D7DF63
		protected override void OnStart()
		{
			RoguelikeSelectRoleGrid.CurSelectRoleItem = null;
			RoguelikeSelectRoleGrid.CurSelectRoleId = 0;
			this.InitRoleList();
			this.IsFirstIn = false;
		}

		// Token: 0x06035B82 RID: 220034 RVA: 0x00D7FD7E File Offset: 0x00D7DF7E
		protected override void OnBeforeShow()
		{
			UiSceneUtils.SetSceneFloorReflection(true, false);
		}

		// Token: 0x06035B83 RID: 220035 RVA: 0x00D7FD88 File Offset: 0x00D7DF88
		protected void InitRoleList()
		{
			int id = (int)this.OpenParam;
			InstanceDungeon? config = ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(id);
			Aki.Config.FightFormation? formationConfig = ConfigBase<EditBattleTeamConfig>.Instance.GetFightFormationConfig(config.Value.FightFormationId);
			List<RoleDataBase> trailRoleInstanceList = this.GetTrailRoleInstanceList(this.TrialRoleIdList);
			if (trailRoleInstanceList.Count > 0)
			{
				this.RoguelikeSelectRoleDataList.Add(new RoguelikeSelectRoleData(ERoguelikeSelectRoleType.Trail, trailRoleInstanceList, this.AddRoleLevel, this.AddWeaponLevel, this.MaxLevel, formationConfig.Value.LimitRole().ToList<int>(), null));
			}
			int[] showRoleList = formationConfig.Value.LimitRole();
			RoleInstance[] roleList = ModelBase<RoleModel>.Instance.GetRoleList();
			ModelBase<RoguelikeModel>.Instance.SelectRoleViewShowRoleList = this.UnlockRoleList;
			ModelBase<RoguelikeModel>.Instance.SelectRoleViewRecommendRoleList = formationConfig.Value.RecommendFormation().ToList<int>();
			List<RoleDataBase> list = new List<RoleDataBase>();
			using (List<int>.Enumerator enumerator = this.UnlockRoleList.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					int role = enumerator.Current;
					if (!ModelBase<RoleModel>.Instance.IsMainRole(role) || ModelBase<RoleModel>.Instance.GetRoleInstanceById(role) != null)
					{
						RoleInstance roleInstance = roleList.FirstOrDefault((RoleInstance r) => r.GetRoleId() == role);
						if (roleInstance != null)
						{
							list.Add(roleInstance);
						}
						else
						{
							list.Add(new RoleInstance(role));
						}
					}
				}
			}
			List<RoleDataBase> list2 = new List<RoleDataBase>();
			using (List<int>.Enumerator enumerator = this.LockRoleList.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					int roleId = enumerator.Current;
					RoleInstance roleInstance2 = roleList.FirstOrDefault((RoleInstance r) => r.GetRoleId() == roleId);
					if (roleInstance2 != null)
					{
						list2.Add(roleInstance2);
					}
					else
					{
						list2.Add(new RoleInstance(roleId));
					}
				}
			}
			list.Sort(delegate(RoleDataBase a, RoleDataBase b)
			{
				bool flag = showRoleList.Contains(a.GetRoleId()) && a.GetLevelData().GetLevel() != 0;
				bool flag2 = showRoleList.Contains(b.GetRoleId()) && b.GetLevelData().GetLevel() != 0;
				if (flag != flag2)
				{
					if (!flag)
					{
						return 1;
					}
					return -1;
				}
				else
				{
					bool flag3 = formationConfig.Value.RecommendFormation().Contains(a.GetRoleId());
					bool flag4 = formationConfig.Value.RecommendFormation().Contains(b.GetRoleId());
					if (flag3 != flag4)
					{
						if (!flag3)
						{
							return 1;
						}
						return -1;
					}
					else
					{
						int level = a.GetLevelData().GetLevel();
						int level2 = b.GetLevelData().GetLevel();
						if (level != level2)
						{
							if (level <= level2)
							{
								return 1;
							}
							return -1;
						}
						else
						{
							int qualityId = a.GetRoleConfig().QualityId;
							int qualityId2 = b.GetRoleConfig().QualityId;
							if (qualityId != qualityId2)
							{
								if (qualityId <= qualityId2)
								{
									return 1;
								}
								return -1;
							}
							else
							{
								int roleId = a.GetRoleId();
								int roleId2 = b.GetRoleId();
								if (roleId <= roleId2)
								{
									return (roleId < roleId2) ? 1 : 0;
								}
								return -1;
							}
						}
					}
				}
			});
			list2.Sort(delegate(RoleDataBase a, RoleDataBase b)
			{
				bool flag = showRoleList.Contains(a.GetRoleId()) && a.GetLevelData().GetLevel() != 0;
				bool flag2 = showRoleList.Contains(b.GetRoleId()) && b.GetLevelData().GetLevel() != 0;
				if (flag != flag2)
				{
					if (!flag)
					{
						return 1;
					}
					return -1;
				}
				else
				{
					bool flag3 = formationConfig.Value.RecommendFormation().Contains(a.GetRoleId());
					bool flag4 = formationConfig.Value.RecommendFormation().Contains(b.GetRoleId());
					if (flag3 != flag4)
					{
						if (!flag3)
						{
							return 1;
						}
						return -1;
					}
					else
					{
						int level = a.GetLevelData().GetLevel();
						int level2 = b.GetLevelData().GetLevel();
						if (level != level2)
						{
							if (level <= level2)
							{
								return 1;
							}
							return -1;
						}
						else
						{
							int qualityId = a.GetRoleConfig().QualityId;
							int qualityId2 = b.GetRoleConfig().QualityId;
							if (qualityId != qualityId2)
							{
								if (qualityId <= qualityId2)
								{
									return 1;
								}
								return -1;
							}
							else
							{
								int roleId = a.GetRoleId();
								int roleId2 = b.GetRoleId();
								if (roleId <= roleId2)
								{
									return (roleId < roleId2) ? 1 : 0;
								}
								return -1;
							}
						}
					}
				}
			});
			this.RoguelikeSelectRoleDataList.Add(new RoguelikeSelectRoleData(ERoguelikeSelectRoleType.Open, list.Cast<RoleDataBase>().ToList<RoleDataBase>(), this.AddRoleLevel, this.AddWeaponLevel, this.MaxLevel, showRoleList.ToList<int>(), formationConfig.Value.RecommendFormation().ToList<int>()));
			this.RoguelikeSelectRoleDataList.Add(new RoguelikeSelectRoleData(ERoguelikeSelectRoleType.UnOpen, list2.Cast<RoleDataBase>().ToList<RoleDataBase>(), this.AddRoleLevel, this.AddWeaponLevel, this.MaxLevel, showRoleList.ToList<int>(), formationConfig.Value.RecommendFormation().ToList<int>()));
			if (list.Count > 0)
			{
				this.SelectRoleData = list[0];
				this.SelectRoleType = ERoguelikeSelectRoleType.Open;
			}
			else if (list2.Count > 0)
			{
				this.SelectRoleData = list2[0];
				this.SelectRoleType = ERoguelikeSelectRoleType.UnOpen;
			}
			else
			{
				Singleton<Log>.Instance.Error(ELogModule.Roguelike, ELogAuthor.BB, "RoguelikeSelectRoleView没有角色数据", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			this.DynamicScrollViewComponent.RefreshByData(this.RoguelikeSelectRoleDataList.ToArray(), false, false);
			FilterSortEntrance<RoleDataBase> filterComponent = this.FilterComponent;
			if (filterComponent == null)
			{
				return;
			}
			filterComponent.UpdateData(EFilterSortGroupId.RogueRole, list.ToList<RoleDataBase>(), Array.Empty<object>());
		}

		// Token: 0x06035B84 RID: 220036 RVA: 0x00D80120 File Offset: 0x00D7E320
		protected override void OnBeforeDestroy()
		{
			Singleton<UiSceneManager>.Instance.DestroyRoleSystemRoleActor(this.UiSceneRoleActor);
		}

		// Token: 0x06035B85 RID: 220037 RVA: 0x00D80133 File Offset: 0x00D7E333
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add<IReadOnlyList<int>>(EEventName.RoguelikePopularEntriesChange, new Action<IReadOnlyList<int>>(this.OnRoguelikePopularEntriesChange));
		}

		// Token: 0x06035B86 RID: 220038 RVA: 0x00D80151 File Offset: 0x00D7E351
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.RoguelikePopularEntriesChange, new Action<IReadOnlyList<int>>(this.OnRoguelikePopularEntriesChange));
		}

		// Token: 0x06035B87 RID: 220039 RVA: 0x00D80170 File Offset: 0x00D7E370
		protected override void OnHandleLoadScene()
		{
			UiModelBase model = Singleton<UiSceneManager>.Instance.GetRoleSystemRoleActor().Model;
			UiModelActorComponent uiModelActorComponent = (model != null) ? model.CheckGetComponent<UiModelActorComponent>() : null;
			if (uiModelActorComponent != null)
			{
				uiModelActorComponent.SetTransformByTag("RoleCase");
			}
			ControllerBase<RoleController>.Instance.OnSelectedRoleChangeByConfig(this.SelectRoleData.GetRoleId(), -1, null);
			this.OnSelectRoleCallBack(this.SelectRoleData, (int)this.SelectRoleType);
		}

		// Token: 0x06035B88 RID: 220040 RVA: 0x00D801D4 File Offset: 0x00D7E3D4
		protected List<RoleDataBase> GetTrailRoleInstanceList(List<int> roleIdList)
		{
			List<RoleDataBase> list = new List<RoleDataBase>();
			foreach (int id in roleIdList)
			{
				RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(ConfigBase<RoleConfig>.Instance.GetTrialRoleIdConfigByGroupId(id), true);
				if (roleDataById != null)
				{
					list.Add(roleDataById);
				}
			}
			return list;
		}

		// Token: 0x06035B89 RID: 220041 RVA: 0x00D80244 File Offset: 0x00D7E444
		private void OnFilterSort(List<RoleDataBase> dataList, bool isOutSideChange, EFilterSortType operationType)
		{
			if (this.IsFirstIn)
			{
				return;
			}
			this.DynamicScrollViewComponent.GetScrollItemItems().ToList<RoguelikeSelectRoleGrid>().ForEach(delegate(RoguelikeSelectRoleGrid item)
			{
				RoguelikeSelectRoleData data = item.Data;
				if (data != null && data.Type == ERoguelikeSelectRoleType.Open)
				{
					item.Data.RoleIdList = dataList;
					item.RefreshData().AsTask();
				}
			});
		}

		// Token: 0x06035B8A RID: 220042 RVA: 0x00D80288 File Offset: 0x00D7E488
		private RoguelikeSelectRoleGrid CreateItem(RoguelikeSelectRoleData data, UUIItem uiItem, int index)
		{
			RoguelikeSelectRoleGrid roguelikeSelectRoleGrid = new RoguelikeSelectRoleGrid(data);
			roguelikeSelectRoleGrid.BindSelectRoleCallBack(new Action<RoleDataBase, int>(this.OnSelectRoleCallBack));
			return roguelikeSelectRoleGrid;
		}

		// Token: 0x06035B8B RID: 220043 RVA: 0x00D802A4 File Offset: 0x00D7E4A4
		private void OnSelectRoleCallBack(RoleDataBase roleData, int roleType)
		{
			this.SelectRoleData = roleData;
			int recommendLevel = ConfigBase<InstanceDungeonConfig>.Instance.GetRecommendLevel(this.InstanceId, ModelBase<WorldLevelModel>.Instance.CurWorldLevel);
			InstanceDungeon? config = ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(this.InstanceId);
			Aki.Config.FightFormation? fightFormationConfig = ConfigBase<EditBattleTeamConfig>.Instance.GetFightFormationConfig(config.Value.FightFormationId);
			int num = (this.AddRoleLevel > 0) ? ((this.AddRoleLevel > roleData.GetLevelData().GetLevel()) ? this.AddRoleLevel : roleData.GetLevelData().GetLevel()) : roleData.GetLevelData().GetLevel();
			int dataId = roleData.GetDataId();
			bool flag = ModelBase<RoleModel>.Instance.GetRoleInstanceById(dataId) != null;
			bool flag2 = fightFormationConfig.Value.LimitRole().Contains(dataId);
			bool uiactive = recommendLevel > num && flag2 && flag;
			bool uiactive2 = dataId > 100000 || (flag2 && flag);
			bool flag3 = (flag ? ModelBase<WeaponModel>.Instance.GetWeaponDataByRoleDataId(roleData.GetDataId(), true).GetLevel() : 0) < this.AddWeaponLevel && !roleData.IsTrialRole() && flag && flag2;
			bool flag4 = roleData.GetLevelData().GetLevel() < this.AddRoleLevel && !roleData.IsTrialRole() && flag && flag2;
			base.GetItem(9).SetUIActive(uiactive);
			base.GetButton(10).RootUIComp.Get().SetUIActive(uiactive2);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(14), "Text_RoleAddLevel_Text", new <>z__ReadOnlySingleElementList<object>(this.AddRoleLevel));
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(15), "Text_WeaponAddLevel_Text", new <>z__ReadOnlySingleElementList<object>(this.AddWeaponLevel));
			base.GetText(15).SetUIActive(flag3);
			base.GetText(14).SetUIActive(flag4);
			base.GetItem(13).SetUIActive(flag4 || flag3);
		}

		// Token: 0x06035B8C RID: 220044 RVA: 0x00D80491 File Offset: 0x00D7E691
		private void OnBtnBack()
		{
			ControllerBase<InstanceDungeonEntranceController>.Instance.RevertEntranceFlowStep();
			base.CloseMe(null);
		}

		// Token: 0x06035B8D RID: 220045 RVA: 0x00D804A4 File Offset: 0x00D7E6A4
		private void OnBtnConfirm()
		{
			int id = (int)this.OpenParam;
			InstanceDungeon? config = ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(id);
			if (!ConfigBase<EditBattleTeamConfig>.Instance.GetFightFormationConfig(config.Value.FightFormationId).Value.LimitRole().Contains(this.SelectRoleData.GetRoleId()))
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("Roguelike_SelectRole_CannotUse", Array.Empty<object>());
				return;
			}
			if (ModelBase<RoleModel>.Instance.GetRoleDataById(this.SelectRoleData.GetDataId(), true) == null)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("Rogue_Dont_Have_Role", Array.Empty<object>());
				return;
			}
			ControllerBase<InstanceDungeonEntranceController>.Instance.ContinueEntranceFlow();
		}

		// Token: 0x06035B8E RID: 220046 RVA: 0x00D80554 File Offset: 0x00D7E754
		private void OnRoguelikePopularEntriesChange(IReadOnlyList<int> entries)
		{
			int num = 10000;
			this.Entries.Entries.Clear();
			this.Entries.Entries.AddRange(entries);
			foreach (int id in entries)
			{
				RougePopularEntrie? roguelikePopularEntriesById = ConfigBase<RoguelikeConfig>.Instance.GetRoguelikePopularEntriesById(id);
				if (roguelikePopularEntriesById != null)
				{
					num += roguelikePopularEntriesById.Value.Rate;
				}
			}
			FColor color = FColor.FromHex("adadad");
			if (num > 10000)
			{
				color = FColor.FromHex("c25757");
			}
			else if (num < 10000)
			{
				color = FColor.FromHex("36cd33");
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(11), "Rogue_Entry_Multiple", new <>z__ReadOnlySingleElementList<object>(num / 100));
			UUIText text = base.GetText(11);
			if (text == null)
			{
				return;
			}
			text.SetColor(color);
		}

		// Token: 0x06035B8F RID: 220047 RVA: 0x00D80650 File Offset: 0x00D7E850
		private bool CheckHasCanSelectEntry()
		{
			foreach (RougePopularEntrie rougePopularEntrie in ConfigBase<RoguelikeConfig>.Instance.GetRoguelikePopularEntries())
			{
				if (rougePopularEntrie.Insts().Contains(this.Entries.InstId))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06035B90 RID: 220048 RVA: 0x00D806BC File Offset: 0x00D7E8BC
		private void OnBtnEntrySelect()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.RoguelikeInstanceEntrySelectView, this.Entries, null);
		}

		// Token: 0x06035B91 RID: 220049 RVA: 0x00D806D4 File Offset: 0x00D7E8D4
		private unsafe void OnBtnDetail()
		{
			int num;
			Span<int> span;
			int num2;
			if (this.SelectRoleType == ERoguelikeSelectRoleType.UnOpen)
			{
				RoleController instance = ControllerBase<RoleController>.Instance;
				ERoleAgentType agentType = ERoleAgentType.Preview;
				int selectRoleId = 0;
				num = 1;
				List<int> list = new List<int>(num);
				CollectionsMarshal.SetCount<int>(list, num);
				span = CollectionsMarshal.AsSpan<int>(list);
				num2 = 0;
				*span[num2] = this.SelectRoleData.GetDataId();
				instance.OpenRoleMainView(agentType, selectRoleId, list, null, null);
				return;
			}
			RoleController instance2 = ControllerBase<RoleController>.Instance;
			ERoleAgentType agentType2 = ERoleAgentType.Normal;
			int selectRoleId2 = 0;
			num2 = 1;
			List<int> list2 = new List<int>(num2);
			CollectionsMarshal.SetCount<int>(list2, num2);
			span = CollectionsMarshal.AsSpan<int>(list2);
			num = 0;
			*span[num] = this.SelectRoleData.GetDataId();
			instance2.OpenRoleMainView(agentType2, selectRoleId2, list2, null, null);
		}

		// Token: 0x06035B92 RID: 220050 RVA: 0x00D8076F File Offset: 0x00D7E96F
		private void OnBtnHelp()
		{
			ControllerBase<HelpController>.Instance.OpenHelpById(76);
		}

		// Token: 0x0401ED3C RID: 126268
		protected DynamicScrollView<RoguelikeSelectRoleGrid, RoguelikeSelectRoleBaseGrid, RoguelikeSelectRoleData> DynamicScrollViewComponent;

		// Token: 0x0401ED3D RID: 126269
		private RoguelikeSelectRoleBaseGrid RoguelikeBaseItem;

		// Token: 0x0401ED3E RID: 126270
		private readonly List<RoguelikeSelectRoleData> RoguelikeSelectRoleDataList = new List<RoguelikeSelectRoleData>();

		// Token: 0x0401ED3F RID: 126271
		public List<RoleDataBase> ShowRoleList = new List<RoleDataBase>();

		// Token: 0x0401ED40 RID: 126272
		private List<int> TrialRoleIdList = new List<int>();

		// Token: 0x0401ED41 RID: 126273
		private int InstanceId;

		// Token: 0x0401ED42 RID: 126274
		private RoleDataBase SelectRoleData;

		// Token: 0x0401ED43 RID: 126275
		private ERoguelikeSelectRoleType SelectRoleType = ERoguelikeSelectRoleType.Open;

		// Token: 0x0401ED44 RID: 126276
		private TsUiSceneRoleActor UiSceneRoleActor;

		// Token: 0x0401ED45 RID: 126277
		private FilterSortEntrance<RoleDataBase> FilterComponent;

		// Token: 0x0401ED46 RID: 126278
		private PopularEntrie Entries;

		// Token: 0x0401ED47 RID: 126279
		private int AddRoleLevel;

		// Token: 0x0401ED48 RID: 126280
		private int AddWeaponLevel;

		// Token: 0x0401ED49 RID: 126281
		private int MaxLevel;

		// Token: 0x0401ED4A RID: 126282
		private bool IsFirstIn = true;

		// Token: 0x0401ED4B RID: 126283
		private List<int> UnlockRoleList = new List<int>();

		// Token: 0x0401ED4C RID: 126284
		private List<int> LockRoleList = new List<int>();

		// Token: 0x0200B158 RID: 45400
		[NullableContext(0)]
		private class ERoguelikeSelectRoleViewDefine
		{
			// Token: 0x04036FEE RID: 225262
			public const int TopItem = 0;

			// Token: 0x04036FEF RID: 225263
			public const int BtnBack = 1;

			// Token: 0x04036FF0 RID: 225264
			public const int BtnConfirm = 2;

			// Token: 0x04036FF1 RID: 225265
			public const int DynamicScrollView = 3;

			// Token: 0x04036FF2 RID: 225266
			public const int DynamicScrollViewGridItem = 4;

			// Token: 0x04036FF3 RID: 225267
			public const int FilterItem = 5;

			// Token: 0x04036FF4 RID: 225268
			public const int TxtTitle = 6;

			// Token: 0x04036FF5 RID: 225269
			public const int TxtDescription = 7;

			// Token: 0x04036FF6 RID: 225270
			public const int BtnEntrySelect = 8;

			// Token: 0x04036FF7 RID: 225271
			public const int PanelTips = 9;

			// Token: 0x04036FF8 RID: 225272
			public const int BtnDetail = 10;

			// Token: 0x04036FF9 RID: 225273
			public const int TxtEntryNumber = 11;

			// Token: 0x04036FFA RID: 225274
			public const int BtnHelp = 12;

			// Token: 0x04036FFB RID: 225275
			public const int RoleAddItem = 13;

			// Token: 0x04036FFC RID: 225276
			public const int TxtRoleAddLevel = 14;

			// Token: 0x04036FFD RID: 225277
			public const int TxtWeaponAddLevel = 15;
		}
	}
}
