using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.RoleUi.RoleDevelop.Data;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.RoleUi.RoleDevelop.View
{
	// Token: 0x020050CE RID: 20686
	[NullableContext(1)]
	[Nullable(0)]
	public class RoleDevelopSelectTargetView : UiViewBase
	{
		// Token: 0x060354D9 RID: 218329 RVA: 0x00D5F138 File Offset: 0x00D5D338
		public RoleDevelopSelectTargetView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x060354DA RID: 218330 RVA: 0x00D5F158 File Offset: 0x00D5D358
		protected unsafe override void OnRegisterComponent()
		{
			int num = 15;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIGridLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIGridLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIVerticalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIScrollViewWithScrollbarComponent));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x060354DB RID: 218331 RVA: 0x00D5F378 File Offset: 0x00D5D578
		protected override UniTask OnBeforeStartAsync()
		{
			RoleDevelopSelectTargetView.<OnBeforeStartAsync>d__18 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RoleDevelopSelectTargetView.<OnBeforeStartAsync>d__18>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060354DC RID: 218332 RVA: 0x00D5F3BC File Offset: 0x00D5D5BC
		protected override void OnStart()
		{
			this.WeaponQualityThreshold = ConfigBase<RoleDevConfig>.Instance.GetRoleDevStaticConfig().Value.WeaponQualityThreshold;
			this.PhantomNumThreshold = ConfigBase<RoleDevConfig>.Instance.GetRoleDevStaticConfig().Value.PhantomNumThreshold;
			this.PhantomQualityThreshold = ConfigBase<RoleDevConfig>.Instance.GetRoleDevStaticConfig().Value.PhantomQualityThreshold;
			this.PhantomLevelThreshold = ConfigBase<RoleDevConfig>.Instance.GetRoleDevStaticConfig().Value.PhantomLevelThreshold;
			this.RefreshRoleGridLayout();
			this.RefreshHotRoleGridLayout();
			Singleton<EventSystem>.Instance.Add(EEventName.RoleDevTargetRoleIdChange, new Action(this.OnRoleDevTargetRoleIdChange));
		}

		// Token: 0x060354DD RID: 218333 RVA: 0x00D5F471 File Offset: 0x00D5D671
		protected override void OnBeforeDestroy()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.RoleDevTargetRoleIdChange, new Action(this.OnRoleDevTargetRoleIdChange));
		}

		// Token: 0x060354DE RID: 218334 RVA: 0x00D5F490 File Offset: 0x00D5D690
		private void InitData()
		{
			this.RoleDevelopDataList = ModelBase<RoleDevelopModel>.Instance.GetNormalRoleDevelopData();
			List<RoleDevelopData> allHotRoleDevelopData = ModelBase<RoleDevelopModel>.Instance.GetAllHotRoleDevelopData(false);
			RoleDevelopSelectTargetViewData roleDevelopSelectTargetViewData = this.OpenParam as RoleDevelopSelectTargetViewData;
			int? roleId = (roleDevelopSelectTargetViewData != null) ? roleDevelopSelectTargetViewData.RoleId : null;
			if (roleId != null && roleId.GetValueOrDefault() != 0)
			{
				this.CurSelectRoleDevelopData = (this.RoleDevelopDataList.Find((RoleDevelopData d) => d.GetId() == roleId.Value) ?? allHotRoleDevelopData.Find((RoleDevelopData d) => d.GetId() == roleId.Value));
			}
		}

		// Token: 0x060354DF RID: 218335 RVA: 0x00D5F534 File Offset: 0x00D5D734
		private void RefreshRoleGridLayout()
		{
			List<RoleDevelopData> roleDevelopDataList = this.RoleDevelopDataList;
			if (this.RoleDataList.Count <= 0)
			{
				foreach (RoleDevelopData roleDevelopData in roleDevelopDataList)
				{
					int id = roleDevelopData.GetId();
					RoleInstance roleInstance = ModelBase<RoleModel>.Instance.GetRoleInstanceById(id);
					if (roleInstance == null)
					{
						roleInstance = new RoleInstance(id);
					}
					this.RoleDataList.Add(roleInstance);
				}
				this.FilterSortEntrance.UpdateData(EFilterSortGroupId.RoleDev, this.RoleDataList, Array.Empty<object>());
				return;
			}
			this.RoleLayout.RefreshByData(this.RoleDevelopDataList, new Action(this.OnRoleGridLayoutRefresh), true);
		}

		// Token: 0x060354E0 RID: 218336 RVA: 0x00D5F5F0 File Offset: 0x00D5D7F0
		private void OnUpdateSortList(List<RoleDataBase> dataList, bool isOutSideChange, EFilterSortType operationType)
		{
			this.RoleDataList = dataList;
			Dictionary<int, int> orderMap = new Dictionary<int, int>();
			for (int i = 0; i < dataList.Count; i++)
			{
				orderMap[dataList[i].GetRoleId()] = i;
			}
			int targetRoleId = ModelBase<RoleDevelopModel>.Instance.DevTargetRoleId;
			this.RoleDevelopDataList.Sort(delegate(RoleDevelopData a, RoleDevelopData b)
			{
				int id = a.GetId();
				int id2 = b.GetId();
				if (targetRoleId > 0)
				{
					if (id == targetRoleId)
					{
						return -1;
					}
					if (id2 == targetRoleId)
					{
						return 1;
					}
				}
				int num = orderMap.ContainsKey(id) ? orderMap[id] : int.MaxValue;
				int num2 = orderMap.ContainsKey(id2) ? orderMap[id2] : int.MaxValue;
				return num - num2;
			});
			base.GetScrollViewWithScrollbar(14).SetScrollProgress(0f);
			this.RoleLayout.RefreshByData(this.RoleDevelopDataList, new Action(this.OnRoleGridLayoutRefresh), true);
		}

		// Token: 0x060354E1 RID: 218337 RVA: 0x00D5F698 File Offset: 0x00D5D898
		private void RefreshHotRoleGridLayout()
		{
			List<RoleDevelopData> allHotRoleDevelopData = ModelBase<RoleDevelopModel>.Instance.GetAllHotRoleDevelopData(true);
			if (allHotRoleDevelopData.Count <= 0)
			{
				this.HotRoleLayout.SetActive(false);
				return;
			}
			this.HotRoleLayout.SetActive(true);
			this.HotRoleLayout.RefreshByData(allHotRoleDevelopData, new Action(this.OnHotRoleGridLayoutRefresh), true);
		}

		// Token: 0x060354E2 RID: 218338 RVA: 0x00D5F6EC File Offset: 0x00D5D8EC
		private void RefreshRoleView()
		{
			RoleDevelopRoleBaseData developRoleData = this.CurSelectRoleDevelopData.GetDevelopRoleData();
			base.SetTextureShowUntilLoaded(developRoleData.GetRoleIllustrationPath(), base.GetTexture(5), null);
			base.GetText(8).SetText(developRoleData.GetName(), true);
			ERoleDevelopHotRoleTag hotRoleTag = this.CurSelectRoleDevelopData.GetHotRoleTag();
			this.RoleDevelopTagItem.RefreshByData(hotRoleTag);
			int elementId = developRoleData.GetElementId();
			ElementInfo? elementConfig = ConfigBase<CommonConfig>.Instance.GetElementConfig(elementId);
			UUITexture texture = base.GetTexture(7);
			UUITexture texture2 = base.GetTexture(6);
			UUIText text = base.GetText(10);
			if (elementConfig != null)
			{
				base.SetElementIcon(elementConfig.Value.Icon2, texture, elementId, null);
				base.SetElementIcon(elementConfig.Value.Icon2, texture2, elementId, null);
				texture.SetColor(FColor.FromHex(elementConfig.Value.ElementColor));
				texture.SetUIActive(true);
				texture2.SetUIActive(true);
				Singleton<LguiUtil>.Instance.SetLocalTextNew(text, elementConfig.Value.Name, Array.Empty<object>());
				text.SetUIActive(true);
			}
			else
			{
				texture.SetUIActive(false);
				texture2.SetUIActive(false);
				text.SetUIActive(false);
			}
			this.ConditionLayout.RefreshByData(this.GetConditionItemDataList(), null, false);
			string textId = (ModelBase<RoleDevelopModel>.Instance.DevTargetRoleId == this.CurSelectRoleDevelopData.GetId()) ? "RoleProject_CancelRoleButton" : "RoleProject_ConfirmRoleButton";
			this.ConfirmButton.SetLocalTextNew(textId, Array.Empty<object>());
		}

		// Token: 0x060354E3 RID: 218339 RVA: 0x00D5F880 File Offset: 0x00D5DA80
		private List<RoleDevelopSelectTargetHintItemData> GetConditionItemDataList()
		{
			RoleDevelopData curSelectRoleDevelopData = this.CurSelectRoleDevelopData;
			if (curSelectRoleDevelopData == null)
			{
				return new List<RoleDevelopSelectTargetHintItemData>();
			}
			int id = curSelectRoleDevelopData.GetId();
			int num = ModelBase<RoleModel>.Instance.IsRoleOwned(id) ? 1 : 0;
			bool flag = RoleDevelopUtil.IsAnyProspectRole(id);
			RoleDevelopProjectBaseData projectData = curSelectRoleDevelopData.GetProjectData();
			if (num == 0 || flag)
			{
				List<RoleDevelopSelectTargetHintItemData> result = new List<RoleDevelopSelectTargetHintItemData>();
				this.AddMaterialHint(projectData, flag, result);
				return result;
			}
			RoleDevelopRoleBaseData developRoleData = curSelectRoleDevelopData.GetDevelopRoleData();
			List<RoleDevelopSelectTargetHintItemData> result2 = new List<RoleDevelopSelectTargetHintItemData>();
			bool flag2 = this.CheckRoleCondition(developRoleData, result2);
			bool flag3 = this.CheckWeaponCondition(developRoleData, result2);
			bool flag4 = this.CheckPhantomCondition(id, result2);
			bool flag5 = this.CheckSkillCondition(id, projectData, result2);
			if (flag2 && flag3 && flag4 && flag5)
			{
				return new List<RoleDevelopSelectTargetHintItemData>
				{
					new RoleDevelopSelectTargetHintItemData
					{
						IconKey = "T_RoleDevelopTag1",
						DescKey = "RoleProject_ChoseRole_FinishTips"
					}
				};
			}
			this.AddMaterialHint(projectData, false, result2);
			return result2;
		}

		// Token: 0x060354E4 RID: 218340 RVA: 0x00D5F954 File Offset: 0x00D5DB54
		private bool CheckRoleCondition(RoleDevelopRoleBaseData developRoleData, List<RoleDevelopSelectTargetHintItemData> result)
		{
			int roleLevel = developRoleData.GetRoleLevel();
			int roleTargetLevel = developRoleData.GetRoleTargetLevel();
			if (roleLevel < roleTargetLevel)
			{
				result.Add(new RoleDevelopSelectTargetHintItemData
				{
					IconKey = "T_RoleDevelopTag3",
					DescKey = "RoleProject_ChoseRole_RoleTips01"
				});
				return false;
			}
			return true;
		}

		// Token: 0x060354E5 RID: 218341 RVA: 0x00D5F998 File Offset: 0x00D5DB98
		private bool CheckWeaponCondition(RoleDevelopRoleBaseData developRoleData, List<RoleDevelopSelectTargetHintItemData> result)
		{
			WeaponInstance weaponInstance = developRoleData.GetWeaponInstance();
			if (weaponInstance == null || weaponInstance.GetItemConfig().QualityId < this.WeaponQualityThreshold)
			{
				result.Add(new RoleDevelopSelectTargetHintItemData
				{
					IconKey = "T_RoleDevelopTag2",
					DescKey = "RoleProject_ChoseRole_WeaponTips01"
				});
				return false;
			}
			int weaponLevel = developRoleData.GetWeaponLevel();
			int weaponTargetLevel = developRoleData.GetWeaponTargetLevel();
			if (weaponLevel < weaponTargetLevel)
			{
				result.Add(new RoleDevelopSelectTargetHintItemData
				{
					IconKey = "T_RoleDevelopTag3",
					DescKey = "RoleProject_ChoseRole_WeaponTips02"
				});
				return false;
			}
			return true;
		}

		// Token: 0x060354E6 RID: 218342 RVA: 0x00D5FA1C File Offset: 0x00D5DC1C
		private bool CheckPhantomCondition(int roleId, List<RoleDevelopSelectTargetHintItemData> result)
		{
			List<int> incrIdList = ModelBase<PhantomBattleModel>.Instance.GetBattleDataById(roleId).GetIncrIdList();
			int num = (this.PhantomNumThreshold > 0) ? this.PhantomNumThreshold : incrIdList.Count;
			List<PhantomBattleData> list = new List<PhantomBattleData>();
			foreach (int num2 in incrIdList)
			{
				if (num2 > 0)
				{
					PhantomBattleData phantomBattleData = ModelBase<PhantomBattleModel>.Instance.GetPhantomBattleData(num2);
					if (phantomBattleData != null)
					{
						list.Add(phantomBattleData);
					}
				}
			}
			if (list.Count < num)
			{
				result.Add(new RoleDevelopSelectTargetHintItemData
				{
					IconKey = "T_RoleDevelopTag2",
					DescKey = "RoleProject_ChoseRole_PhantomTips01"
				});
				return false;
			}
			if (this.GetFetterTriggerCount(list) < 5)
			{
				result.Add(new RoleDevelopSelectTargetHintItemData
				{
					IconKey = "T_RoleDevelopTag2",
					DescKey = "RoleProject_ChoseRole_PhantomTips01"
				});
				return false;
			}
			using (List<PhantomBattleData>.Enumerator enumerator2 = list.GetEnumerator())
			{
				while (enumerator2.MoveNext())
				{
					if (enumerator2.Current.GetQuality() < this.PhantomQualityThreshold)
					{
						result.Add(new RoleDevelopSelectTargetHintItemData
						{
							IconKey = "T_RoleDevelopTag2",
							DescKey = "RoleProject_ChoseRole_PhantomTips02"
						});
						return false;
					}
				}
			}
			foreach (PhantomBattleData phantomBattleData2 in list)
			{
				int num3 = (this.PhantomLevelThreshold > 0) ? this.PhantomLevelThreshold : phantomBattleData2.GetLevelLimit();
				if (phantomBattleData2.GetPhantomLevel() < num3)
				{
					result.Add(new RoleDevelopSelectTargetHintItemData
					{
						IconKey = "T_RoleDevelopTag2",
						DescKey = "RoleProject_ChoseRole_PhantomTips03"
					});
					return false;
				}
			}
			foreach (PhantomBattleData phantomBattleData3 in list)
			{
				if (phantomBattleData3.GetIfHaveUnIdentifySubProp() || phantomBattleData3.GetIfHaveLockSubProp())
				{
					result.Add(new RoleDevelopSelectTargetHintItemData
					{
						IconKey = "T_RoleDevelopTag2",
						DescKey = "RoleProject_ChoseRole_PhantomTips04"
					});
					return false;
				}
			}
			return true;
		}

		// Token: 0x060354E7 RID: 218343 RVA: 0x00D5FC70 File Offset: 0x00D5DE70
		private int GetFetterTriggerCount(List<PhantomBattleData> phantomDataList)
		{
			Dictionary<int, int> dictionary = PhantomDataBase.CalculateFetterByPhantomBattleData(new List<PhantomDataBase>(phantomDataList));
			if (dictionary == null)
			{
				return 0;
			}
			int num = 0;
			foreach (KeyValuePair<int, int> keyValuePair in dictionary)
			{
				int num2;
				int num3;
				keyValuePair.Deconstruct(out num2, out num3);
				int groupId = num2;
				int num4 = num3;
				Dictionary<int, int> fetterGroupFetterDataById = ConfigBase<PhantomBattleConfig>.Instance.GetFetterGroupFetterDataById(groupId);
				if (fetterGroupFetterDataById != null)
				{
					int num5 = 0;
					foreach (int num6 in fetterGroupFetterDataById.Keys)
					{
						if (num6 <= num4 && num6 > num5)
						{
							num5 = num6;
						}
					}
					num += num5;
				}
			}
			return num;
		}

		// Token: 0x060354E8 RID: 218344 RVA: 0x00D5FD48 File Offset: 0x00D5DF48
		private bool CheckSkillCondition(int roleId, RoleDevelopProjectBaseData projectData, List<RoleDevelopSelectTargetHintItemData> result)
		{
			if (!projectData.IsSkillPlanFinished())
			{
				result.Add(new RoleDevelopSelectTargetHintItemData
				{
					IconKey = "T_RoleDevelopTag3",
					DescKey = "RoleProject_ChoseRole_SkillTips01"
				});
				return false;
			}
			return true;
		}

		// Token: 0x060354E9 RID: 218345 RVA: 0x00D5FD78 File Offset: 0x00D5DF78
		private void AddMaterialHint(RoleDevelopProjectBaseData projectData, bool isProspect, List<RoleDevelopSelectTargetHintItemData> result)
		{
			List<RoleDevelopNeedItem> list = new List<RoleDevelopNeedItem>();
			list.AddRange(projectData.GetRoleUpgradeNeedItems());
			list.AddRange(projectData.GetRoleBreachNeedItems());
			list.AddRange(projectData.GetWeaponUpgradeNeedItems());
			list.AddRange(projectData.GetWeaponBreachNeedItems());
			list.AddRange(projectData.GetSkillPlanNeedItems());
			Dictionary<int, int> dictionary = new Dictionary<int, int>();
			foreach (RoleDevelopNeedItem roleDevelopNeedItem in list)
			{
				int num;
				dictionary.TryGetValue(roleDevelopNeedItem.ItemId, out num);
				dictionary[roleDevelopNeedItem.ItemId] = num + roleDevelopNeedItem.Count;
			}
			List<RoleDevelopNeedItem> list2 = new List<RoleDevelopNeedItem>();
			foreach (KeyValuePair<int, int> keyValuePair in dictionary)
			{
				int num2;
				int num3;
				keyValuePair.Deconstruct(out num2, out num3);
				int itemId = num2;
				int count = num3;
				list2.Add(new RoleDevelopNeedItem
				{
					ItemId = itemId,
					Count = count
				});
			}
			List<RoleDevelopNeedItem> needItems = list2;
			if (isProspect)
			{
				int unknownItemId = ConfigBase<RoleDevConfig>.Instance.GetRoleDevStaticConfig().Value.UnknownItemId;
				needItems = list2.FindAll((RoleDevelopNeedItem item) => item.ItemId != unknownItemId);
			}
			if (RoleDevelopUtil.CheckIsAllNeedItemsEnough(needItems))
			{
				result.Add(new RoleDevelopSelectTargetHintItemData
				{
					IconKey = "T_RoleDevelopTag1",
					DescKey = "RoleProject_ChoseRole_ItemTips02"
				});
				return;
			}
			result.Add(new RoleDevelopSelectTargetHintItemData
			{
				IconKey = "T_RoleDevelopTag2",
				DescKey = "RoleProject_ChoseRole_ItemTips01"
			});
		}

		// Token: 0x060354EA RID: 218346 RVA: 0x00D5FF28 File Offset: 0x00D5E128
		private void OnHotRoleGridItemSelected(RoleDevelopData data)
		{
			this.RoleLayout.DeselectCurrentGridProxy();
			this.HotRoleLayout.DeselectCurrentGridProxy();
			this.HotRoleLayout.SelectGridProxyByKey(data.GetId(), false);
			this.CurSelectRoleDevelopData = data;
			this.IsSelectedFromHotRole = true;
			this.RefreshRoleView();
		}

		// Token: 0x060354EB RID: 218347 RVA: 0x00D5FF78 File Offset: 0x00D5E178
		private void OnRoleGridItemSelected(RoleDevelopData data)
		{
			this.RoleLayout.DeselectCurrentGridProxy();
			this.HotRoleLayout.DeselectCurrentGridProxy();
			this.RoleLayout.SelectGridProxyByKey(data.GetId(), false);
			this.CurSelectRoleDevelopData = data;
			this.IsSelectedFromHotRole = false;
			this.RefreshRoleView();
		}

		// Token: 0x060354EC RID: 218348 RVA: 0x00D5FFC8 File Offset: 0x00D5E1C8
		private void OnClickConfirmButton(int value)
		{
			int id = this.CurSelectRoleDevelopData.GetId();
			int num = (ModelBase<RoleDevelopModel>.Instance.DevTargetRoleId == id) ? 0 : id;
			RoleDevelopSelectTargetViewData roleDevelopSelectTargetViewData = this.OpenParam as RoleDevelopSelectTargetViewData;
			ERoleDevelopUpdateTargetSource source = (roleDevelopSelectTargetViewData != null) ? roleDevelopSelectTargetViewData.Source : ERoleDevelopUpdateTargetSource.Detection;
			ControllerBase<RoleController>.Instance.RequestUpdateDevelopTarget(num, source, null, null);
			if (num != 0)
			{
				base.CloseMe(null);
			}
		}

		// Token: 0x060354ED RID: 218349 RVA: 0x00D60033 File Offset: 0x00D5E233
		private void OnCloseButtonClick()
		{
			base.CloseMe(null);
		}

		// Token: 0x060354EE RID: 218350 RVA: 0x00D6003C File Offset: 0x00D5E23C
		private RoleDevelopHotRoleGridItem CreateHotRoleGridItem()
		{
			RoleDevelopHotRoleGridItem roleDevelopHotRoleGridItem = new RoleDevelopHotRoleGridItem();
			roleDevelopHotRoleGridItem.BindOnExtendToggleStateChanged(new Action<MediumItemGridExtendCallback>(this.OnHotRoleGridItemToggleChanged));
			roleDevelopHotRoleGridItem.BindOnCanExecuteChange(new Func<object, bool, EToggleState, bool>(this.OnHotRoleGridItemCanExecuteChange));
			return roleDevelopHotRoleGridItem;
		}

		// Token: 0x060354EF RID: 218351 RVA: 0x00D60067 File Offset: 0x00D5E267
		private RoleDevelopGridItem CreateRoleGridItem()
		{
			RoleDevelopGridItem roleDevelopGridItem = new RoleDevelopGridItem();
			roleDevelopGridItem.BindOnExtendToggleStateChanged(new Action<MediumItemGridExtendCallback>(this.OnRoleGridItemToggleChanged));
			roleDevelopGridItem.BindOnCanExecuteChange(new Func<object, bool, EToggleState, bool>(this.OnRoleGridItemCanExecuteChange));
			return roleDevelopGridItem;
		}

		// Token: 0x060354F0 RID: 218352 RVA: 0x00D60092 File Offset: 0x00D5E292
		private RoleDevelopSelectTargetHintItem CreateConditionItem()
		{
			return new RoleDevelopSelectTargetHintItem();
		}

		// Token: 0x060354F1 RID: 218353 RVA: 0x00D60099 File Offset: 0x00D5E299
		private bool IsNormalRole(int roleId)
		{
			return !RoleDevelopUtil.IsAnyProspectRole(roleId);
		}

		// Token: 0x060354F2 RID: 218354 RVA: 0x00D600A4 File Offset: 0x00D5E2A4
		private void OnRoleGridLayoutRefresh()
		{
			if (this.CurSelectRoleDevelopData == null)
			{
				this.CurSelectRoleDevelopData = this.RoleDevelopDataList[0];
			}
			int id = this.CurSelectRoleDevelopData.GetId();
			if (!this.IsNormalRole(id))
			{
				return;
			}
			this.RoleLayout.SelectGridProxyByKey(id, false);
			this.OnRoleGridItemSelected(this.CurSelectRoleDevelopData);
		}

		// Token: 0x060354F3 RID: 218355 RVA: 0x00D60100 File Offset: 0x00D5E300
		private void OnHotRoleGridLayoutRefresh()
		{
			int id = this.CurSelectRoleDevelopData.GetId();
			if (this.IsNormalRole(id))
			{
				return;
			}
			this.HotRoleLayout.SelectGridProxyByKey(id, false);
			this.OnHotRoleGridItemSelected(this.CurSelectRoleDevelopData);
		}

		// Token: 0x060354F4 RID: 218356 RVA: 0x00D60144 File Offset: 0x00D5E344
		private void OnHotRoleGridItemToggleChanged(MediumItemGridExtendCallback callbackParameter)
		{
			this.OnHotRoleGridItemSelected((RoleDevelopData)callbackParameter.Data);
			base.PlayOrReplaySequence("Switch", false, null);
		}

		// Token: 0x060354F5 RID: 218357 RVA: 0x00D60178 File Offset: 0x00D5E378
		private bool OnHotRoleGridItemCanExecuteChange(object data, bool isForceSelected, EToggleState state)
		{
			if (!this.IsSelectedFromHotRole)
			{
				return true;
			}
			int id = ((RoleDevelopData)data).GetId();
			RoleDevelopData curSelectRoleDevelopData = this.CurSelectRoleDevelopData;
			int? num = (curSelectRoleDevelopData != null) ? new int?(curSelectRoleDevelopData.GetId()) : null;
			return !(id == num.GetValueOrDefault() & num != null);
		}

		// Token: 0x060354F6 RID: 218358 RVA: 0x00D601D0 File Offset: 0x00D5E3D0
		private void OnRoleGridItemToggleChanged(MediumItemGridExtendCallback callbackParameter)
		{
			this.OnRoleGridItemSelected((RoleDevelopData)callbackParameter.Data);
			base.PlayOrReplaySequence("Switch", false, null);
		}

		// Token: 0x060354F7 RID: 218359 RVA: 0x00D60204 File Offset: 0x00D5E404
		private bool OnRoleGridItemCanExecuteChange(object data, bool isForceSelected, EToggleState state)
		{
			if (this.IsSelectedFromHotRole)
			{
				return true;
			}
			int id = ((RoleDevelopData)data).GetId();
			RoleDevelopData curSelectRoleDevelopData = this.CurSelectRoleDevelopData;
			int? num = (curSelectRoleDevelopData != null) ? new int?(curSelectRoleDevelopData.GetId()) : null;
			return !(id == num.GetValueOrDefault() & num != null);
		}

		// Token: 0x060354F8 RID: 218360 RVA: 0x00D6025A File Offset: 0x00D5E45A
		private void OnRoleDevTargetRoleIdChange()
		{
			if (ModelBase<RoleDevelopModel>.Instance.DevTargetRoleId != 0)
			{
				return;
			}
			this.HotRoleLayout.RefreshWithoutDataSync();
			this.RoleLayout.RefreshWithoutDataSync();
			this.RefreshRoleView();
		}

		// Token: 0x0401EA86 RID: 125574
		private PopupCaptionItem CaptionItem;

		// Token: 0x0401EA87 RID: 125575
		private GenericLayout<RoleDevelopHotRoleGridItem, RoleDevelopData> HotRoleLayout;

		// Token: 0x0401EA88 RID: 125576
		private GenericLayout<RoleDevelopGridItem, RoleDevelopData> RoleLayout;

		// Token: 0x0401EA89 RID: 125577
		private FilterSortEntrance<RoleDataBase> FilterSortEntrance;

		// Token: 0x0401EA8A RID: 125578
		private RoleDevelopTagItem RoleDevelopTagItem;

		// Token: 0x0401EA8B RID: 125579
		private List<RoleDataBase> RoleDataList = new List<RoleDataBase>();

		// Token: 0x0401EA8C RID: 125580
		private List<RoleDevelopData> RoleDevelopDataList = new List<RoleDevelopData>();

		// Token: 0x0401EA8D RID: 125581
		[Nullable(2)]
		private RoleDevelopData CurSelectRoleDevelopData;

		// Token: 0x0401EA8E RID: 125582
		private bool IsSelectedFromHotRole;

		// Token: 0x0401EA8F RID: 125583
		private int WeaponQualityThreshold;

		// Token: 0x0401EA90 RID: 125584
		private int PhantomNumThreshold;

		// Token: 0x0401EA91 RID: 125585
		private int PhantomQualityThreshold;

		// Token: 0x0401EA92 RID: 125586
		private int PhantomLevelThreshold;

		// Token: 0x0401EA93 RID: 125587
		private ButtonItem ConfirmButton;

		// Token: 0x0401EA94 RID: 125588
		private GenericLayout<RoleDevelopSelectTargetHintItem, RoleDevelopSelectTargetHintItemData> ConditionLayout;

		// Token: 0x0200B06A RID: 45162
		[NullableContext(0)]
		public static class EComponentType
		{
			// Token: 0x04036BDA RID: 224218
			public const int CaptionItem = 0;

			// Token: 0x04036BDB RID: 224219
			public const int HotRoleGrid = 1;

			// Token: 0x04036BDC RID: 224220
			public const int HotRoleItem = 2;

			// Token: 0x04036BDD RID: 224221
			public const int RoleGrid = 3;

			// Token: 0x04036BDE RID: 224222
			public const int FilterSortItem = 4;

			// Token: 0x04036BDF RID: 224223
			public const int RoleTexture = 5;

			// Token: 0x04036BE0 RID: 224224
			public const int ElementBgTexture = 6;

			// Token: 0x04036BE1 RID: 224225
			public const int ElementIconTexture = 7;

			// Token: 0x04036BE2 RID: 224226
			public const int NameText = 8;

			// Token: 0x04036BE3 RID: 224227
			public const int DevelopTag = 9;

			// Token: 0x04036BE4 RID: 224228
			public const int ElementText = 10;

			// Token: 0x04036BE5 RID: 224229
			public const int ConditionVerticalLayout = 11;

			// Token: 0x04036BE6 RID: 224230
			public const int ConditionItem = 12;

			// Token: 0x04036BE7 RID: 224231
			public const int ConfirmButton = 13;

			// Token: 0x04036BE8 RID: 224232
			public const int ScrollView = 14;
		}
	}
}
