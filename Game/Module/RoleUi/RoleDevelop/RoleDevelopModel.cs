using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.Item.Data;
using CSharpScript.Game.Module.Manufacture.Compose.QuicklyPopup;
using CSharpScript.Game.Module.RoleUi.RoleDevelop.Data;
using CSharpScript.Game.Module.RoleUi.RoleDevelop.RoleDevelopWorldDropEnoughTips;
using Google.Protobuf.Collections;

namespace CSharpScript.Game.Module.RoleUi.RoleDevelop
{
	// Token: 0x020050AD RID: 20653
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Model(0)]
	public class RoleDevelopModel : ModelBase<RoleDevelopModel>
	{
		// Token: 0x17008C05 RID: 35845
		// (get) Token: 0x0603530A RID: 217866 RVA: 0x00D532BB File Offset: 0x00D514BB
		// (set) Token: 0x0603530B RID: 217867 RVA: 0x00D532C3 File Offset: 0x00D514C3
		public bool IsWorldDropTipShowing { get; set; }

		// Token: 0x0603530C RID: 217868 RVA: 0x00D532CC File Offset: 0x00D514CC
		protected override bool OnInit()
		{
			Singleton<EventSystem>.Instance.Add<int, int, int>(EEventName.RoleLevelUp, new Action<int, int, int>(this.OnRoleLevelUp));
			Singleton<EventSystem>.Instance.Add<int, int>(EEventName.RoleBreakUp, new Action<int, int>(this.OnRoleBreakUp));
			Singleton<EventSystem>.Instance.Add<int, ArrayIntInt>(EEventName.RoleSkillLevelUp, new Action<int, ArrayIntInt>(this.OnRoleSkillLevelUp));
			Singleton<EventSystem>.Instance.Add<int>(EEventName.WeaponRoleEquipChanged, new Action<int>(this.OnTargetRoleChanged));
			Singleton<EventSystem>.Instance.Add<int>(EEventName.WeaponRoleLevelUp, new Action<int>(this.OnTargetRoleChanged));
			Singleton<EventSystem>.Instance.Add<int>(EEventName.WeaponRoleBreakUp, new Action<int>(this.OnTargetRoleChanged));
			Singleton<EventSystem>.Instance.Add<int, int, int, int, int, int, int>(EEventName.OnPlayerLevelChanged, new Action<int, int, int, int, int, int, int>(this.OnPlayerLevelChanged));
			Singleton<EventSystem>.Instance.Add<ItemRewardNotify>(EEventName.OnItemRewardNotify, new Action<ItemRewardNotify>(this.OnItemRewardNotify));
			Singleton<EventSystem>.Instance.Add<int, int>(EEventName.OnCommonItemCountAnyChange, new Action<int, int>(this.OnCommonItemCountAnyChange));
			Singleton<EventSystem>.Instance.Add<int>(EEventName.ActiveRole, new Action<int>(this.OnActiveRole));
			Singleton<EventSystem>.Instance.Add<int>(EEventName.RoleSystemChangeRole, new Action<int>(this.OnMainRoleChanged));
			Singleton<EventSystem>.Instance.Add<EFunctionType, bool>(EEventName.OnFunctionOpenUpdate, new Action<EFunctionType, bool>(this.OnFunctionOpenUpdate));
			return true;
		}

		// Token: 0x0603530D RID: 217869 RVA: 0x00D5342C File Offset: 0x00D5162C
		protected override bool OnClear()
		{
			Singleton<EventSystem>.Instance.Remove<int, int, int>(EEventName.RoleLevelUp, new Action<int, int, int>(this.OnRoleLevelUp));
			Singleton<EventSystem>.Instance.Remove<int, int>(EEventName.RoleBreakUp, new Action<int, int>(this.OnRoleBreakUp));
			Singleton<EventSystem>.Instance.Remove<int, ArrayIntInt>(EEventName.RoleSkillLevelUp, new Action<int, ArrayIntInt>(this.OnRoleSkillLevelUp));
			Singleton<EventSystem>.Instance.Remove<int>(EEventName.WeaponRoleEquipChanged, new Action<int>(this.OnTargetRoleChanged));
			Singleton<EventSystem>.Instance.Remove<int>(EEventName.WeaponRoleLevelUp, new Action<int>(this.OnTargetRoleChanged));
			Singleton<EventSystem>.Instance.Remove<int>(EEventName.WeaponRoleBreakUp, new Action<int>(this.OnTargetRoleChanged));
			Singleton<EventSystem>.Instance.Remove<int, int, int, int, int, int, int>(EEventName.OnPlayerLevelChanged, new Action<int, int, int, int, int, int, int>(this.OnPlayerLevelChanged));
			Singleton<EventSystem>.Instance.Remove<ItemRewardNotify>(EEventName.OnItemRewardNotify, new Action<ItemRewardNotify>(this.OnItemRewardNotify));
			Singleton<EventSystem>.Instance.Remove<int, int>(EEventName.OnCommonItemCountAnyChange, new Action<int, int>(this.OnCommonItemCountAnyChange));
			Singleton<EventSystem>.Instance.Remove<int>(EEventName.ActiveRole, new Action<int>(this.OnActiveRole));
			Singleton<EventSystem>.Instance.Remove<int>(EEventName.RoleSystemChangeRole, new Action<int>(this.OnMainRoleChanged));
			Singleton<EventSystem>.Instance.Remove<EFunctionType, bool>(EEventName.OnFunctionOpenUpdate, new Action<EFunctionType, bool>(this.OnFunctionOpenUpdate));
			return true;
		}

		// Token: 0x0603530E RID: 217870 RVA: 0x00D5358A File Offset: 0x00D5178A
		private void OnRoleLevelUp(int roleId, int exp, int level)
		{
			this.OnTargetRoleChanged(roleId);
		}

		// Token: 0x0603530F RID: 217871 RVA: 0x00D53593 File Offset: 0x00D51793
		private void OnRoleBreakUp(int roleId, int level)
		{
			this.OnTargetRoleChanged(roleId);
		}

		// Token: 0x06035310 RID: 217872 RVA: 0x00D5359C File Offset: 0x00D5179C
		private void OnRoleSkillLevelUp(int roleId, ArrayIntInt skillInfo)
		{
			this.OnTargetRoleChanged(roleId);
		}

		// Token: 0x06035311 RID: 217873 RVA: 0x00D535A5 File Offset: 0x00D517A5
		private void OnTargetRoleChanged(int roleId)
		{
			if (roleId == this.DevTargetRoleIdInternal)
			{
				this.InvalidateNeedItemCache();
			}
		}

		// Token: 0x06035312 RID: 217874 RVA: 0x00D535B6 File Offset: 0x00D517B6
		private void OnPlayerLevelChanged(int i, int i1, int arg3, int arg4, int arg5, int arg6, int arg7)
		{
			this.InvalidateNeedItemCache();
		}

		// Token: 0x06035313 RID: 217875 RVA: 0x00D535C0 File Offset: 0x00D517C0
		private void OnActiveRole(int roleId)
		{
			if (this.RoleDevelopDataMap.Count == 0)
			{
				return;
			}
			if (!this.RoleDevelopDataMap.ContainsKey(roleId) && ConfigBase<RoleDevConfig>.Instance.GetRoleDevProjectConfig(roleId) != null)
			{
				this.CreateRoleDevelopData(roleId);
			}
			this.InvalidateNeedItemCache();
		}

		// Token: 0x06035314 RID: 217876 RVA: 0x00D5360C File Offset: 0x00D5180C
		private void OnMainRoleChanged(int roleId)
		{
			if (!ModelBase<RoleModel>.Instance.IsMainRole(roleId))
			{
				return;
			}
			if (this.RoleDevelopDataMap.Count == 0)
			{
				return;
			}
			int? num = null;
			foreach (int num2 in this.RoleDevelopDataMap.Keys)
			{
				if (ModelBase<RoleModel>.Instance.IsMainRole(num2) && num2 != roleId)
				{
					num = new int?(num2);
					break;
				}
			}
			if (num != null)
			{
				int valueOrDefault = num.GetValueOrDefault();
				this.RoleDevelopDataMap.Remove(valueOrDefault);
			}
			if (!this.RoleDevelopDataMap.ContainsKey(roleId) && ConfigBase<RoleDevConfig>.Instance.GetRoleDevProjectConfig(roleId) != null)
			{
				this.CreateRoleDevelopData(roleId);
			}
			if (this.DevTargetRoleIdInternal != 0 && ModelBase<RoleModel>.Instance.IsMainRole(this.DevTargetRoleIdInternal) && this.DevTargetRoleIdInternal != roleId)
			{
				this.SetDevTargetRoleId(roleId);
			}
			this.InvalidateNeedItemCache();
		}

		// Token: 0x06035315 RID: 217877 RVA: 0x00D53718 File Offset: 0x00D51918
		private void OnFunctionOpenUpdate(EFunctionType functionType, bool isOpen)
		{
			if (functionType == EFunctionType.RoleDev && isOpen)
			{
				int? curSelectMainRoleId = ModelBase<RoleModel>.Instance.GetCurSelectMainRoleId();
				if (curSelectMainRoleId != null)
				{
					ControllerBase<RoleController>.Instance.LogRoleDevelopSkillRecommendClick(curSelectMainRoleId.Value, true);
				}
			}
		}

		// Token: 0x17008C06 RID: 35846
		// (get) Token: 0x06035316 RID: 217878 RVA: 0x00D53757 File Offset: 0x00D51957
		public string Version
		{
			get
			{
				return this.VersionInternal;
			}
		}

		// Token: 0x17008C07 RID: 35847
		// (get) Token: 0x06035317 RID: 217879 RVA: 0x00D5375F File Offset: 0x00D5195F
		public int DevTargetRoleId
		{
			get
			{
				return this.DevTargetRoleIdInternal;
			}
		}

		// Token: 0x06035318 RID: 217880 RVA: 0x00D53768 File Offset: 0x00D51968
		public void UpdateRoleDevConfig(RoleDevelopConfigs configs)
		{
			RepeatedField<RoleDevPropsConfig> devPropsList = configs.DevPropsList;
			if (devPropsList != null && devPropsList.Count > 0)
			{
				ConfigBase<RoleDevConfig>.Instance.UpdateDevProsListConfig(devPropsList);
			}
			if (configs.DevTargetRole != 0)
			{
				this.SetDevTargetRoleId(configs.DevTargetRole);
			}
			RepeatedField<RoleDevPropsProjectConfig> devPropsProjectList = configs.DevPropsProjectList;
			if (devPropsProjectList != null && devPropsProjectList.Count > 0)
			{
				ConfigBase<RoleDevConfig>.Instance.UpdateDevPropsProjectConfig(devPropsProjectList);
			}
			if (!string.IsNullOrEmpty(configs.Version))
			{
				this.VersionInternal = configs.Version;
			}
		}

		// Token: 0x06035319 RID: 217881 RVA: 0x00D537DE File Offset: 0x00D519DE
		public void UpdateDevTargetRoleId(int roleId)
		{
			this.SetDevTargetRoleId(roleId);
			this.InvalidateNeedItemCache();
		}

		// Token: 0x0603531A RID: 217882 RVA: 0x00D537F0 File Offset: 0x00D519F0
		private void SetDevTargetRoleId(int roleId)
		{
			if (!RoleDevelopUtil.IsProspectRole(roleId))
			{
				IEnumerable<RoleInfo> roleList = ConfigBase<RoleConfig>.Instance.GetRoleList();
				bool flag = false;
				foreach (RoleInfo roleInfo in roleList)
				{
					if (roleInfo.RoleType == 1 && roleInfo.Id == roleId)
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					this.DevTargetRoleIdInternal = 0;
					return;
				}
			}
			RoleModel instance = ModelBase<RoleModel>.Instance;
			if (instance.IsMainRole(roleId))
			{
				int? curSelectMainRoleId = instance.GetCurSelectMainRoleId();
				if (curSelectMainRoleId != null)
				{
					int valueOrDefault = curSelectMainRoleId.GetValueOrDefault();
					if (valueOrDefault != roleId)
					{
						this.DevTargetRoleIdInternal = valueOrDefault;
						return;
					}
				}
			}
			this.DevTargetRoleIdInternal = roleId;
		}

		// Token: 0x0603531B RID: 217883 RVA: 0x00D538A8 File Offset: 0x00D51AA8
		public bool IsShowInHotRoleList(int id)
		{
			if (!RoleDevelopUtil.IsHotRole(id))
			{
				return false;
			}
			int typeId = ConfigBase<RoleDevConfig>.Instance.GetRoleDevProsListConfig(id).TypeId;
			if (typeId == 4 || typeId == 0)
			{
				return false;
			}
			if (typeId == 1)
			{
				return RoleDevelopUtil.IsProspectRoleValid(id);
			}
			if (typeId == 2)
			{
				return RoleDevelopUtil.IsCurrentVersionProspectRoleValid(id);
			}
			if (typeId == 3)
			{
				return RoleDevelopUtil.IsReturningRoleValid(id);
			}
			return RoleDevelopUtil.GetHotRoleGachaId(id, true) != null;
		}

		// Token: 0x0603531C RID: 217884 RVA: 0x00D5390C File Offset: 0x00D51B0C
		private List<int> GetAllConfigRoleIdList()
		{
			List<int> list = new List<int>();
			IEnumerable<RoleInfo> roleList = ConfigBase<RoleConfig>.Instance.GetRoleList();
			RoleModel instance = ModelBase<RoleModel>.Instance;
			foreach (RoleInfo roleInfo in roleList)
			{
				if (roleInfo.RoleType == 1)
				{
					int id = roleInfo.Id;
					if (instance.IsMainRole(id))
					{
						int? curSelectMainRoleId = instance.GetCurSelectMainRoleId();
						int num = id;
						if (!(curSelectMainRoleId.GetValueOrDefault() == num & curSelectMainRoleId != null))
						{
							continue;
						}
					}
					if (ModelBase<HandBookModel>.Instance.GetRoleCanShowInHandBook(id) && !RoleDevelopUtil.IsRoleInProspectTime(id))
					{
						list.Add(id);
					}
				}
			}
			return list;
		}

		// Token: 0x0603531D RID: 217885 RVA: 0x00D539C0 File Offset: 0x00D51BC0
		[NullableContext(2)]
		public RoleDevelopData GetRoleDevelopData(int id)
		{
			this.CreateAllRoleDevelopData();
			RoleDevelopData result;
			this.RoleDevelopDataMap.TryGetValue(id, out result);
			return result;
		}

		// Token: 0x0603531E RID: 217886 RVA: 0x00D539E4 File Offset: 0x00D51BE4
		private void CreateAllRoleDevelopData()
		{
			if (this.RoleDevelopDataMap.Count > 0)
			{
				return;
			}
			foreach (IRoleDevProsConfig roleDevProsConfig in ConfigBase<RoleDevConfig>.Instance.GetAllRoleDevProsListConfig())
			{
				int id = roleDevProsConfig.Id;
				if (!this.RoleDevelopDataMap.ContainsKey(id))
				{
					IRoleDevProsConfig roleDevProsListConfig = ConfigBase<RoleDevConfig>.Instance.GetRoleDevProsListConfig(id);
					if (roleDevProsListConfig != null && roleDevProsListConfig.TypeId != 4 && roleDevProsListConfig.TypeId != 0)
					{
						if (RoleDevelopUtil.IsProspectRole(id) && ConfigBase<RoleDevConfig>.Instance.GetRoleDevProsProjectConfig(id) == null)
						{
							Log instance = Singleton<Log>.Instance;
							ELogModule module = ELogModule.RoleDev;
							ELogAuthor author = ELogAuthor.LJS;
							string message = "跨版本前瞻角色未配置RoleDevProsProject";
							ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", id);
							instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
						}
						else if (roleDevProsListConfig.TypeId == 2 && RoleDevelopUtil.IsRoleInProspectTime(id) && ConfigBase<RoleDevConfig>.Instance.GetRoleDevProsProjectConfig(id) == null)
						{
							Log instance2 = Singleton<Log>.Instance;
							ELogModule module2 = ELogModule.RoleDev;
							ELogAuthor author2 = ELogAuthor.LJS;
							string message2 = "在前瞻时间内的当前版本前瞻角色未配置RoleDevProsProject";
							ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("id", id);
							instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
						}
						else if (!RoleDevelopUtil.IsProspectRole(id) && ConfigBase<RoleDevConfig>.Instance.GetRoleDevProjectConfig(id) == null)
						{
							Log instance3 = Singleton<Log>.Instance;
							ELogModule module3 = ELogModule.RoleDev;
							ELogAuthor author3 = ELogAuthor.LJS;
							string message3 = "非前瞻的热门角色未配置RoleDevProject";
							ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("id", id);
							instance3.Error(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
						}
						else
						{
							this.CreateRoleDevelopData(roleDevProsConfig.Id);
						}
					}
				}
			}
			foreach (int num in this.GetAllConfigRoleIdList())
			{
				if (!this.RoleDevelopDataMap.ContainsKey(num))
				{
					if (ConfigBase<RoleDevConfig>.Instance.GetRoleDevProjectConfig(num) == null)
					{
						Log instance4 = Singleton<Log>.Instance;
						ELogModule module4 = ELogModule.RoleDev;
						ELogAuthor author4 = ELogAuthor.LJS;
						string message4 = "角色未配置RoleDevProject";
						ValueTuple<string, object> valueTuple4 = new ValueTuple<string, object>("id", num);
						instance4.Error(module4, author4, message4, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple4));
					}
					else
					{
						this.CreateRoleDevelopData(num);
					}
				}
			}
		}

		// Token: 0x0603531F RID: 217887 RVA: 0x00D53C44 File Offset: 0x00D51E44
		private RoleDevelopData CreateRoleDevelopData(int id)
		{
			RoleDevelopData roleDevelopData = new RoleDevelopData(id);
			this.RoleDevelopDataMap[id] = roleDevelopData;
			return roleDevelopData;
		}

		// Token: 0x06035320 RID: 217888 RVA: 0x00D53C66 File Offset: 0x00D51E66
		public List<RoleDevelopData> GetAllRoleDevelopData()
		{
			this.CreateAllRoleDevelopData();
			return new List<RoleDevelopData>(this.RoleDevelopDataMap.Values);
		}

		// Token: 0x06035321 RID: 217889 RVA: 0x00D53C80 File Offset: 0x00D51E80
		public List<RoleDevelopData> GetAllHotRoleDevelopData(bool sort = false)
		{
			List<RoleDevelopData> allRoleDevelopData = this.GetAllRoleDevelopData();
			List<RoleDevelopData> list = new List<RoleDevelopData>();
			foreach (RoleDevelopData roleDevelopData in allRoleDevelopData)
			{
				if (RoleDevelopUtil.IsHotRole(roleDevelopData.GetId()) && this.IsShowInHotRoleList(roleDevelopData.GetId()))
				{
					list.Add(roleDevelopData);
				}
			}
			if (sort)
			{
				this.SortHotRoleDevelopData(list);
			}
			return list;
		}

		// Token: 0x06035322 RID: 217890 RVA: 0x00D53D00 File Offset: 0x00D51F00
		private void SortHotRoleDevelopData(List<RoleDevelopData> dataList)
		{
			dataList.Sort(delegate(RoleDevelopData a, RoleDevelopData b)
			{
				IRoleDevProsConfig roleDevProsListConfig = ConfigBase<RoleDevConfig>.Instance.GetRoleDevProsListConfig(a.GetId());
				int num = (roleDevProsListConfig != null) ? roleDevProsListConfig.SortId : int.MaxValue;
				IRoleDevProsConfig roleDevProsListConfig2 = ConfigBase<RoleDevConfig>.Instance.GetRoleDevProsListConfig(b.GetId());
				int num2 = (roleDevProsListConfig2 != null) ? roleDevProsListConfig2.SortId : int.MaxValue;
				return num - num2;
			});
		}

		// Token: 0x06035323 RID: 217891 RVA: 0x00D53D28 File Offset: 0x00D51F28
		public List<RoleDevelopData> GetNormalRoleDevelopData()
		{
			List<RoleDevelopData> allRoleDevelopData = this.GetAllRoleDevelopData();
			List<RoleDevelopData> list = new List<RoleDevelopData>();
			foreach (RoleDevelopData roleDevelopData in allRoleDevelopData)
			{
				if (!RoleDevelopUtil.IsProspectRole(roleDevelopData.GetId()) && !RoleDevelopUtil.IsCurrentVersionProspectRoleInProspect(roleDevelopData.GetId()) && ModelBase<HandBookModel>.Instance.GetRoleCanShowInHandBook(roleDevelopData.GetId()))
				{
					list.Add(roleDevelopData);
				}
			}
			return list;
		}

		// Token: 0x06035324 RID: 217892 RVA: 0x00D53DB0 File Offset: 0x00D51FB0
		public EItemRequirementState GetItemGroupRequirementState(RoleDevelopItemGroup itemGroup, [Nullable(2)] IReadOnlyDictionary<int, int> excludeCountMap = null)
		{
			List<RoleDevelopNeedItem> list = new List<RoleDevelopNeedItem>();
			if (itemGroup.Items != null)
			{
				foreach (RoleDevelopNeedItem roleDevelopNeedItem in itemGroup.Items)
				{
					if (!RoleDevelopUtil.IsUnknownItem(roleDevelopNeedItem.ItemId))
					{
						list.Add(roleDevelopNeedItem);
					}
				}
			}
			List<string> list2 = new List<string>();
			foreach (RoleDevelopNeedItem roleDevelopNeedItem2 in list)
			{
				List<string> list3 = list2;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
				defaultInterpolatedStringHandler.AppendFormatted<int>(roleDevelopNeedItem2.ItemId);
				defaultInterpolatedStringHandler.AppendLiteral(":");
				defaultInterpolatedStringHandler.AppendFormatted<int>(roleDevelopNeedItem2.Count);
				list3.Add(defaultInterpolatedStringHandler.ToStringAndClear());
			}
			if (list.Count == 0)
			{
				return EItemRequirementState.Satisfied;
			}
			InventoryModel instance = ModelBase<InventoryModel>.Instance;
			ComposePopupModel instance2 = ModelBase<ComposePopupModel>.Instance;
			RoleDevConfig instance3 = ConfigBase<RoleDevConfig>.Instance;
			CSharpScript.Game.Module.Item.ItemConfig instance4 = ConfigBase<CSharpScript.Game.Module.Item.ItemConfig>.Instance;
			List<RoleDevelopModel.ItemCalcInfo> list4 = new List<RoleDevelopModel.ItemCalcInfo>();
			Dictionary<int, RoleDevelopModel.ItemCalcInfo> dictionary = new Dictionary<int, RoleDevelopModel.ItemCalcInfo>();
			bool flag = true;
			foreach (RoleDevelopNeedItem roleDevelopNeedItem3 in list)
			{
				int num = Math.Max(0, instance.GetItemCountByConfigId(roleDevelopNeedItem3.ItemId, 0) - ((excludeCountMap != null) ? excludeCountMap.GetValueOrDefault(roleDevelopNeedItem3.ItemId, 0) : 0));
				if (num < roleDevelopNeedItem3.Count)
				{
					flag = false;
				}
				int maxGiftExchangeCount = instance2.GetMaxGiftExchangeCount(roleDevelopNeedItem3.ItemId, null);
				int num2 = num + maxGiftExchangeCount;
				int synthesisValue = instance3.GetItemJumpGroupConfig(roleDevelopNeedItem3.ItemId).Value.SynthesisValue;
				int qualityId = instance4.GetConfig(roleDevelopNeedItem3.ItemId).Value.QualityId;
				int num3 = Math.Max(0, roleDevelopNeedItem3.Count - num2);
				int num4 = Math.Max(0, num2 - roleDevelopNeedItem3.Count);
				RoleDevelopModel.ItemCalcInfo itemCalcInfo = new RoleDevelopModel.ItemCalcInfo
				{
					ItemId = roleDevelopNeedItem3.ItemId,
					QualityId = qualityId,
					Deficit = num3,
					NeededPoints = synthesisValue * num3,
					AvailablePoints = synthesisValue * num4
				};
				list4.Add(itemCalcInfo);
				dictionary[roleDevelopNeedItem3.ItemId] = itemCalcInfo;
			}
			if (flag)
			{
				return EItemRequirementState.Satisfied;
			}
			list4.Sort((RoleDevelopModel.ItemCalcInfo a, RoleDevelopModel.ItemCalcInfo b) => a.QualityId - b.QualityId);
			foreach (RoleDevelopModel.ItemCalcInfo itemCalcInfo2 in list4)
			{
				if (itemCalcInfo2.Deficit > 0)
				{
					if (itemCalcInfo2.NeededPoints <= 0)
					{
						return EItemRequirementState.NotSatisfied;
					}
					if (itemCalcInfo2.AvailablePoints >= itemCalcInfo2.NeededPoints)
					{
						itemCalcInfo2.AvailablePoints -= itemCalcInfo2.NeededPoints;
					}
					else if (!RoleDevelopModel.TrySupplementFromMaterials(itemCalcInfo2, dictionary, excludeCountMap))
					{
						return EItemRequirementState.NotSatisfied;
					}
				}
			}
			return EItemRequirementState.Supplement;
		}

		// Token: 0x06035325 RID: 217893 RVA: 0x00D54104 File Offset: 0x00D52304
		private static bool TrySupplementFromMaterials(RoleDevelopModel.ItemCalcInfo calcItem, Dictionary<int, RoleDevelopModel.ItemCalcInfo> itemCalcMap, [Nullable(2)] IReadOnlyDictionary<int, int> excludeCountMap = null)
		{
			int num = calcItem.NeededPoints - calcItem.AvailablePoints;
			if (num <= 0)
			{
				return true;
			}
			HashSet<int> visited = new HashSet<int>
			{
				calcItem.ItemId
			};
			num = RoleDevelopModel.ConsumeFromSynthesisTree(num, calcItem.ItemId, itemCalcMap, visited, excludeCountMap);
			calcItem.AvailablePoints = 0;
			return num <= 0;
		}

		// Token: 0x06035326 RID: 217894 RVA: 0x00D54158 File Offset: 0x00D52358
		private static int ConsumeFromSynthesisTree(int needed, int itemId, Dictionary<int, RoleDevelopModel.ItemCalcInfo> itemCalcMap, HashSet<int> visited, [Nullable(2)] IReadOnlyDictionary<int, int> excludeCountMap = null)
		{
			ComposePopupModel instance = ModelBase<ComposePopupModel>.Instance;
			List<IComposeItemData> composeMaterialList = instance.GetComposeMaterialList(itemId);
			if (composeMaterialList == null || composeMaterialList.Count == 0)
			{
				return needed;
			}
			InventoryModel instance2 = ModelBase<InventoryModel>.Instance;
			RoleDevConfig instance3 = ConfigBase<RoleDevConfig>.Instance;
			CSharpScript.Game.Module.Item.ItemConfig instance4 = ConfigBase<CSharpScript.Game.Module.Item.ItemConfig>.Instance;
			int num = needed;
			foreach (IComposeItemData composeItemData in composeMaterialList)
			{
				if (num <= 0)
				{
					break;
				}
				if (!visited.Contains(composeItemData.ItemId))
				{
					visited.Add(composeItemData.ItemId);
					RoleDevelopModel.ItemCalcInfo itemCalcInfo;
					if (!itemCalcMap.TryGetValue(composeItemData.ItemId, out itemCalcInfo))
					{
						RoleDevItemJumpGroup? itemJumpGroupConfig = instance3.GetItemJumpGroupConfig(composeItemData.ItemId);
						if (itemJumpGroupConfig == null)
						{
							continue;
						}
						int num2 = Math.Max(0, instance2.GetItemCountByConfigId(composeItemData.ItemId, 0) - ((excludeCountMap != null) ? excludeCountMap.GetValueOrDefault(composeItemData.ItemId, 0) : 0));
						int maxGiftExchangeCount = instance.GetMaxGiftExchangeCount(composeItemData.ItemId, null);
						int num3 = num2 + maxGiftExchangeCount;
						int synthesisValue = itemJumpGroupConfig.Value.SynthesisValue;
						ItemInfo? itemInfo;
						int qualityId = (instance4.GetConfig(composeItemData.ItemId) != null) ? itemInfo.GetValueOrDefault().QualityId : 0;
						itemCalcInfo = new RoleDevelopModel.ItemCalcInfo
						{
							ItemId = composeItemData.ItemId,
							QualityId = qualityId,
							Deficit = 0,
							NeededPoints = 0,
							AvailablePoints = synthesisValue * num3
						};
						itemCalcMap[composeItemData.ItemId] = itemCalcInfo;
					}
					int num4 = Math.Min(itemCalcInfo.AvailablePoints, num);
					itemCalcInfo.AvailablePoints -= num4;
					num -= num4;
					if (num > 0)
					{
						num = RoleDevelopModel.ConsumeFromSynthesisTree(num, composeItemData.ItemId, itemCalcMap, visited, excludeCountMap);
					}
				}
			}
			return num;
		}

		// Token: 0x06035327 RID: 217895 RVA: 0x00D54344 File Offset: 0x00D52544
		public bool IsItemGroupCanBeSupplemented(RoleDevelopItemGroup itemGroup)
		{
			return this.GetItemGroupRequirementState(itemGroup, null) == EItemRequirementState.Supplement;
		}

		// Token: 0x06035328 RID: 217896 RVA: 0x00D54354 File Offset: 0x00D52554
		public EItemRequirementState GetItemRequirementState(int itemId, int needCount)
		{
			if (RoleDevelopUtil.IsUnknownItem(itemId))
			{
				return EItemRequirementState.Satisfied;
			}
			InventoryModel instance = ModelBase<InventoryModel>.Instance;
			ComposePopupModel instance2 = ModelBase<ComposePopupModel>.Instance;
			RoleDevConfig instance3 = ConfigBase<RoleDevConfig>.Instance;
			int itemCountByConfigId = instance.GetItemCountByConfigId(itemId, 0);
			if (itemCountByConfigId >= needCount)
			{
				return EItemRequirementState.Satisfied;
			}
			int maxGiftExchangeCount = instance2.GetMaxGiftExchangeCount(itemId, null);
			if (itemCountByConfigId + maxGiftExchangeCount >= needCount)
			{
				return EItemRequirementState.Supplement;
			}
			RoleDevItemJumpGroup? itemJumpGroupConfig = instance3.GetItemJumpGroupConfig(itemId);
			if (itemJumpGroupConfig == null || itemJumpGroupConfig.Value.SynthesisValue <= 0)
			{
				return EItemRequirementState.NotSatisfied;
			}
			int num = needCount - itemCountByConfigId - maxGiftExchangeCount;
			int neededPoints = itemJumpGroupConfig.Value.SynthesisValue * num;
			HashSet<int> visited = new HashSet<int>
			{
				itemId
			};
			if (this.BorrowSynthesisPointsFromMaterials(itemId, neededPoints, visited) > 0)
			{
				return EItemRequirementState.NotSatisfied;
			}
			return EItemRequirementState.Supplement;
		}

		// Token: 0x06035329 RID: 217897 RVA: 0x00D54400 File Offset: 0x00D52600
		private int BorrowSynthesisPointsFromMaterials(int parentId, int neededPoints, HashSet<int> visited)
		{
			ComposePopupModel instance = ModelBase<ComposePopupModel>.Instance;
			InventoryModel instance2 = ModelBase<InventoryModel>.Instance;
			RoleDevConfig instance3 = ConfigBase<RoleDevConfig>.Instance;
			List<IComposeItemData> composeMaterialList = instance.GetComposeMaterialList(parentId);
			if (composeMaterialList == null || composeMaterialList.Count == 0)
			{
				return neededPoints;
			}
			int num = neededPoints;
			foreach (IComposeItemData composeItemData in composeMaterialList)
			{
				if (num <= 0)
				{
					break;
				}
				if (!visited.Contains(composeItemData.ItemId))
				{
					visited.Add(composeItemData.ItemId);
					RoleDevItemJumpGroup? itemJumpGroupConfig = instance3.GetItemJumpGroupConfig(composeItemData.ItemId);
					if (itemJumpGroupConfig != null && itemJumpGroupConfig.Value.SynthesisValue > 0)
					{
						int itemCountByConfigId = instance2.GetItemCountByConfigId(composeItemData.ItemId, 0);
						int maxGiftExchangeCount = instance.GetMaxGiftExchangeCount(composeItemData.ItemId, null);
						int developRoleNeedItemCount = this.GetDevelopRoleNeedItemCount(composeItemData.ItemId);
						int num2 = Math.Min(Math.Max(0, itemCountByConfigId + maxGiftExchangeCount - developRoleNeedItemCount) * itemJumpGroupConfig.Value.SynthesisValue, num);
						num -= num2;
						if (num > 0)
						{
							num = this.BorrowSynthesisPointsFromMaterials(composeItemData.ItemId, num, visited);
						}
					}
				}
			}
			return num;
		}

		// Token: 0x0603532A RID: 217898 RVA: 0x00D54548 File Offset: 0x00D52748
		public bool IsItemCanBeSupplemented(int itemId, int needCount)
		{
			return this.GetItemRequirementState(itemId, needCount) == EItemRequirementState.Supplement;
		}

		// Token: 0x0603532B RID: 217899 RVA: 0x00D54558 File Offset: 0x00D52758
		public int GetItemComposeChainSupplyCount(int itemId)
		{
			RoleDevConfig instance = ConfigBase<RoleDevConfig>.Instance;
			RoleDevItemJumpGroup? itemJumpGroupConfig = instance.GetItemJumpGroupConfig(itemId);
			if (itemJumpGroupConfig == null || itemJumpGroupConfig.Value.SynthesisValue <= 0)
			{
				return 0;
			}
			ComposePopupModel instance2 = ModelBase<ComposePopupModel>.Instance;
			InventoryModel instance3 = ModelBase<InventoryModel>.Instance;
			HashSet<int> visited = new HashSet<int>
			{
				itemId
			};
			long num = 0L;
			this.AccumulateComposeChainPoints(itemId, visited, instance, instance2, instance3, ref num);
			return (int)(num / (long)itemJumpGroupConfig.Value.SynthesisValue);
		}

		// Token: 0x0603532C RID: 217900 RVA: 0x00D545D4 File Offset: 0x00D527D4
		private void AccumulateComposeChainPoints(int currentItemId, HashSet<int> visited, RoleDevConfig roleDevConfig, ComposePopupModel composePopupModel, InventoryModel inventoryModel, ref long totalAvailablePoints)
		{
			List<IComposeItemData> composeMaterialList = composePopupModel.GetComposeMaterialList(currentItemId);
			if (composeMaterialList == null || composeMaterialList.Count == 0)
			{
				return;
			}
			foreach (IComposeItemData composeItemData in composeMaterialList)
			{
				if (!visited.Contains(composeItemData.ItemId))
				{
					visited.Add(composeItemData.ItemId);
					RoleDevItemJumpGroup? itemJumpGroupConfig = roleDevConfig.GetItemJumpGroupConfig(composeItemData.ItemId);
					if (itemJumpGroupConfig != null)
					{
						int itemCountByConfigId = inventoryModel.GetItemCountByConfigId(composeItemData.ItemId, 0);
						int maxGiftExchangeCount = composePopupModel.GetMaxGiftExchangeCount(composeItemData.ItemId, null);
						totalAvailablePoints += (long)itemJumpGroupConfig.Value.SynthesisValue * (long)(itemCountByConfigId + maxGiftExchangeCount);
						this.AccumulateComposeChainPoints(composeItemData.ItemId, visited, roleDevConfig, composePopupModel, inventoryModel, ref totalAvailablePoints);
					}
				}
			}
		}

		// Token: 0x0603532D RID: 217901 RVA: 0x00D546BC File Offset: 0x00D528BC
		public bool IsDevelopRoleNeedItem(int itemId)
		{
			return this.GetNeedItemCache().ContainsKey(itemId);
		}

		// Token: 0x0603532E RID: 217902 RVA: 0x00D546CA File Offset: 0x00D528CA
		public bool IsDevelopRoleNeedItemCanBeSupplemented(int itemId)
		{
			return this.IsDevelopRoleNeedItem(itemId) && this.IsItemCanBeSupplemented(itemId, this.GetDevelopRoleNeedItemCount(itemId));
		}

		// Token: 0x0603532F RID: 217903 RVA: 0x00D546E8 File Offset: 0x00D528E8
		public EItemRequirementState GetItemBelongingGroupRequirementState(int itemId)
		{
			RoleDevelopItemGroup roleDevelopItemGroup = this.BuildNeedItemGroupByItemId(itemId);
			if (roleDevelopItemGroup == null)
			{
				return EItemRequirementState.Satisfied;
			}
			return this.GetItemGroupRequirementState(roleDevelopItemGroup, null);
		}

		// Token: 0x06035330 RID: 217904 RVA: 0x00D5470A File Offset: 0x00D5290A
		public bool IsItemBelongingGroupCanBeSupplemented(int itemId)
		{
			return this.GetItemBelongingGroupRequirementState(itemId) == EItemRequirementState.Supplement;
		}

		// Token: 0x06035331 RID: 217905 RVA: 0x00D54718 File Offset: 0x00D52918
		[NullableContext(2)]
		private RoleDevelopItemGroup BuildNeedItemGroupByItemId(int itemId)
		{
			RoleDevItemJumpGroup? itemJumpGroupConfig = ConfigBase<RoleDevConfig>.Instance.GetItemJumpGroupConfig(itemId);
			if (itemJumpGroupConfig == null)
			{
				return null;
			}
			EItemMaterialType itemType = (EItemMaterialType)itemJumpGroupConfig.Value.ItemType;
			RoleDevelopItemGroup roleDevelopItemGroup;
			if (!this.GetNeedItemGroupByTypeCache().TryGetValue(itemType, out roleDevelopItemGroup))
			{
				return null;
			}
			int subGroup = itemJumpGroupConfig.Value.SubGroup;
			List<RoleDevelopNeedItem> list = new List<RoleDevelopNeedItem>();
			foreach (RoleDevelopNeedItem roleDevelopNeedItem in roleDevelopItemGroup.Items)
			{
				RoleDevItemJumpGroup? itemJumpGroupConfig2 = ConfigBase<RoleDevConfig>.Instance.GetItemJumpGroupConfig(roleDevelopNeedItem.ItemId);
				if (itemJumpGroupConfig2 != null && itemJumpGroupConfig2.Value.SubGroup == subGroup)
				{
					list.Add(roleDevelopNeedItem);
				}
			}
			if (list.Count == 0)
			{
				return null;
			}
			return new RoleDevelopItemGroup
			{
				Type = itemType,
				Items = list
			};
		}

		// Token: 0x06035332 RID: 217906 RVA: 0x00D54810 File Offset: 0x00D52A10
		private Dictionary<EItemMaterialType, RoleDevelopItemGroup> GetNeedItemGroupByTypeCache()
		{
			if (this.NeedItemGroupByTypeCache == null)
			{
				this.NeedItemGroupByTypeCache = this.BuildNeedItemGroupByTypeMap();
			}
			return this.NeedItemGroupByTypeCache;
		}

		// Token: 0x06035333 RID: 217907 RVA: 0x00D5482C File Offset: 0x00D52A2C
		private Dictionary<EItemMaterialType, RoleDevelopItemGroup> BuildNeedItemGroupByTypeMap()
		{
			Dictionary<EItemMaterialType, RoleDevelopItemGroup> dictionary = new Dictionary<EItemMaterialType, RoleDevelopItemGroup>();
			foreach (KeyValuePair<int, int> keyValuePair in this.GetNeedItemCache())
			{
				int key = keyValuePair.Key;
				int value = keyValuePair.Value;
				if (value > 0)
				{
					RoleDevItemJumpGroup? itemJumpGroupConfig = ConfigBase<RoleDevConfig>.Instance.GetItemJumpGroupConfig(key);
					if (itemJumpGroupConfig != null)
					{
						EItemMaterialType itemType = (EItemMaterialType)itemJumpGroupConfig.Value.ItemType;
						RoleDevelopItemGroup roleDevelopItemGroup;
						if (!dictionary.TryGetValue(itemType, out roleDevelopItemGroup))
						{
							roleDevelopItemGroup = new RoleDevelopItemGroup
							{
								Type = itemType,
								Items = new List<RoleDevelopNeedItem>()
							};
							dictionary[itemType] = roleDevelopItemGroup;
						}
						roleDevelopItemGroup.Items.Add(new RoleDevelopNeedItem
						{
							ItemId = key,
							Count = value
						});
					}
				}
			}
			return dictionary;
		}

		// Token: 0x06035334 RID: 217908 RVA: 0x00D54914 File Offset: 0x00D52B14
		public int GetDevelopRoleNeedItemCount(int itemId)
		{
			int result;
			this.GetNeedItemCache().TryGetValue(itemId, out result);
			return result;
		}

		// Token: 0x06035335 RID: 217909 RVA: 0x00D54934 File Offset: 0x00D52B34
		public List<RoleDevelopNeedItem> GetAllDevelopRoleNeedItems()
		{
			List<RoleDevelopNeedItem> list = new List<RoleDevelopNeedItem>();
			foreach (KeyValuePair<int, int> keyValuePair in this.GetNeedItemCache())
			{
				list.Add(new RoleDevelopNeedItem
				{
					ItemId = keyValuePair.Key,
					Count = keyValuePair.Value
				});
			}
			return list;
		}

		// Token: 0x06035336 RID: 217910 RVA: 0x00D549AC File Offset: 0x00D52BAC
		public List<RoleDevelopItemGroup> GetAllDevelopRoleNeedItemGroups()
		{
			return RoleDevelopUtil.BuildGroupItemDataByNeedItems(this.GetAllDevelopRoleNeedItems(), false, true, false);
		}

		// Token: 0x06035337 RID: 217911 RVA: 0x00D549BC File Offset: 0x00D52BBC
		public EItemMaterialType? GetDevelopRoleItemMaterialType(int itemId)
		{
			RoleDevItemJumpGroup? itemJumpGroupConfig = ConfigBase<RoleDevConfig>.Instance.GetItemJumpGroupConfig(itemId);
			if (itemJumpGroupConfig == null)
			{
				return null;
			}
			return new EItemMaterialType?((EItemMaterialType)itemJumpGroupConfig.Value.ItemType);
		}

		// Token: 0x06035338 RID: 217912 RVA: 0x00D549FC File Offset: 0x00D52BFC
		public RoleDevelopSettlementJumpData CheckSettlementQuickJumpData(IReadOnlyList<RoleDevelopSettlementRewardItem> rewardItems, ERoleDevelopSettlementSourceDungeonType sourceDungeonType)
		{
			RoleDevelopSettlementJumpData roleDevelopSettlementJumpData = this.CreateEmptySettlementJumpData(sourceDungeonType);
			if (this.DevTargetRoleIdInternal == 0 || sourceDungeonType == ERoleDevelopSettlementSourceDungeonType.None || rewardItems.Count <= 0)
			{
				return roleDevelopSettlementJumpData;
			}
			string developRoleIconPath = this.GetDevelopRoleIconPath();
			if (string.IsNullOrEmpty(developRoleIconPath))
			{
				return roleDevelopSettlementJumpData;
			}
			roleDevelopSettlementJumpData.RoleId = this.DevTargetRoleIdInternal;
			roleDevelopSettlementJumpData.RoleIconPath = developRoleIconPath;
			foreach (RoleDevelopSettlementRewardItem roleDevelopSettlementRewardItem in rewardItems)
			{
				if (roleDevelopSettlementRewardItem != null && roleDevelopSettlementRewardItem.ItemId > 0 && roleDevelopSettlementRewardItem.Count > 0 && this.IsDevelopRoleNeedItem(roleDevelopSettlementRewardItem.ItemId))
				{
					roleDevelopSettlementJumpData.MatchedItemIds.Add(roleDevelopSettlementRewardItem.ItemId);
					EItemMaterialType? developRoleItemMaterialType = this.GetDevelopRoleItemMaterialType(roleDevelopSettlementRewardItem.ItemId);
					if (developRoleItemMaterialType != null && developRoleItemMaterialType.GetValueOrDefault() != EItemMaterialType.Drop && ((developRoleItemMaterialType.GetValueOrDefault() != EItemMaterialType.RoleExp && developRoleItemMaterialType.GetValueOrDefault() != EItemMaterialType.WeaponExp) || sourceDungeonType == ERoleDevelopSettlementSourceDungeonType.Simulation))
					{
						roleDevelopSettlementJumpData.NeedCheckItemIds.Add(roleDevelopSettlementRewardItem.ItemId);
						int developRoleNeedItemCount = this.GetDevelopRoleNeedItemCount(roleDevelopSettlementRewardItem.ItemId);
						if (ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(roleDevelopSettlementRewardItem.ItemId, 0) + roleDevelopSettlementRewardItem.Count < developRoleNeedItemCount)
						{
							int needCount = Math.Max(0, developRoleNeedItemCount - roleDevelopSettlementRewardItem.Count);
							if (!this.IsItemCanBeSupplemented(roleDevelopSettlementRewardItem.ItemId, needCount))
							{
								return this.CreateEmptySettlementJumpData(sourceDungeonType);
							}
						}
					}
				}
			}
			roleDevelopSettlementJumpData.CanShow = (roleDevelopSettlementJumpData.MatchedItemIds.Count > 0);
			return roleDevelopSettlementJumpData;
		}

		// Token: 0x06035339 RID: 217913 RVA: 0x00D54B80 File Offset: 0x00D52D80
		public int GetDevelopRoleHaveItemCount(int itemId)
		{
			return ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(itemId, 0);
		}

		// Token: 0x0603533A RID: 217914 RVA: 0x00D54B8E File Offset: 0x00D52D8E
		[NullableContext(0)]
		[return: TupleElementNames(new string[]
		{
			"HaveCount",
			"NeedCount"
		})]
		public ValueTuple<int, int> GetDevelopRoleHaveAndNeedCount(int itemId)
		{
			return new ValueTuple<int, int>(this.GetDevelopRoleHaveItemCount(itemId), this.GetDevelopRoleNeedItemCount(itemId));
		}

		// Token: 0x0603533B RID: 217915 RVA: 0x00D54BA4 File Offset: 0x00D52DA4
		public string GetDevelopRoleIconPath()
		{
			if (this.DevTargetRoleIdInternal == 0)
			{
				return "";
			}
			RoleDevelopData roleDevelopData = this.GetRoleDevelopData(this.DevTargetRoleIdInternal);
			if (roleDevelopData == null)
			{
				return "";
			}
			return roleDevelopData.GetDevelopRoleData().GetRoleIconPath();
		}

		// Token: 0x0603533C RID: 217916 RVA: 0x00D54BE0 File Offset: 0x00D52DE0
		public string GetDevelopRoleSmallIconPath()
		{
			if (this.DevTargetRoleIdInternal == 0)
			{
				return "";
			}
			RoleDevelopData roleDevelopData = this.GetRoleDevelopData(this.DevTargetRoleIdInternal);
			if (roleDevelopData == null)
			{
				return "";
			}
			return roleDevelopData.GetDevelopRoleData().GetRoleSmallIconPath();
		}

		// Token: 0x0603533D RID: 217917 RVA: 0x00D54C1C File Offset: 0x00D52E1C
		public string GetDevelopRoleCircleIconPath()
		{
			if (this.DevTargetRoleIdInternal == 0)
			{
				return "";
			}
			RoleDevelopData roleDevelopData = this.GetRoleDevelopData(this.DevTargetRoleIdInternal);
			if (roleDevelopData == null)
			{
				return "";
			}
			return roleDevelopData.GetDevelopRoleData().GetRoleCircleIconPath();
		}

		// Token: 0x0603533E RID: 217918 RVA: 0x00D54C58 File Offset: 0x00D52E58
		public EItemRequirementState GetRoleExpItemRequirementState()
		{
			RoleDevelopData roleDevelopData = this.GetRoleDevelopData(this.DevTargetRoleIdInternal);
			if (roleDevelopData == null)
			{
				return EItemRequirementState.NotSatisfied;
			}
			int roleUpgradeExp = roleDevelopData.GetProjectData().GetRoleUpgradeExp();
			if (roleUpgradeExp <= 0)
			{
				return EItemRequirementState.Satisfied;
			}
			RoleModel instance = ModelBase<RoleModel>.Instance;
			InventoryModel instance2 = ModelBase<InventoryModel>.Instance;
			ComposePopupModel instance3 = ModelBase<ComposePopupModel>.Instance;
			ItemInfo[] roleCostExpList = instance.GetRoleCostExpList();
			int num = 0;
			int num2 = 0;
			foreach (ItemInfo itemInfo in roleCostExpList)
			{
				int valueOrDefault = instance.GetRoleExpItemExp(itemInfo.Id).GetValueOrDefault();
				num += valueOrDefault * instance2.GetCommonItemCount(itemInfo.Id, 0);
				num2 += valueOrDefault * instance3.GetMaxGiftExchangeCount(itemInfo.Id, null);
			}
			if (num >= roleUpgradeExp)
			{
				return EItemRequirementState.Satisfied;
			}
			if (num + num2 >= roleUpgradeExp)
			{
				return EItemRequirementState.Supplement;
			}
			return EItemRequirementState.NotSatisfied;
		}

		// Token: 0x0603533F RID: 217919 RVA: 0x00D54D20 File Offset: 0x00D52F20
		public EItemRequirementState GetWeaponExpItemRequirementState()
		{
			RoleDevelopData roleDevelopData = this.GetRoleDevelopData(this.DevTargetRoleIdInternal);
			if (roleDevelopData == null)
			{
				return EItemRequirementState.NotSatisfied;
			}
			int weaponUpgradeExp = roleDevelopData.GetProjectData().GetWeaponUpgradeExp();
			if (weaponUpgradeExp <= 0)
			{
				return EItemRequirementState.Satisfied;
			}
			InventoryModel instance = ModelBase<InventoryModel>.Instance;
			ComposePopupModel instance2 = ModelBase<ComposePopupModel>.Instance;
			WeaponModel instance3 = ModelBase<WeaponModel>.Instance;
			List<ItemInfo> weaponExpItemConfigList = instance3.GetWeaponExpItemConfigList();
			int num = 0;
			int num2 = 0;
			foreach (ItemInfo itemInfo in weaponExpItemConfigList)
			{
				int weaponItemExp = instance3.GetWeaponItemExp(0, itemInfo.Id);
				num += weaponItemExp * instance.GetCommonItemCount(itemInfo.Id, 0);
				num2 += weaponItemExp * instance2.GetMaxGiftExchangeCount(itemInfo.Id, null);
			}
			if (num >= weaponUpgradeExp)
			{
				return EItemRequirementState.Satisfied;
			}
			if (num + num2 >= weaponUpgradeExp)
			{
				return EItemRequirementState.Supplement;
			}
			return EItemRequirementState.NotSatisfied;
		}

		// Token: 0x06035340 RID: 217920 RVA: 0x00D54DFC File Offset: 0x00D52FFC
		public EItemRequirementState GetExpItemRequirementState(int itemId)
		{
			foreach (ItemInfo itemInfo in ModelBase<RoleModel>.Instance.GetRoleCostExpList())
			{
				if (itemInfo.Id == itemId)
				{
					return this.GetRoleExpItemRequirementState();
				}
			}
			foreach (ItemInfo itemInfo2 in ModelBase<WeaponModel>.Instance.GetWeaponExpItemConfigList())
			{
				if (itemInfo2.Id == itemId)
				{
					return this.GetWeaponExpItemRequirementState();
				}
			}
			return EItemRequirementState.NotSatisfied;
		}

		// Token: 0x06035341 RID: 217921 RVA: 0x00D54E98 File Offset: 0x00D53098
		public void InvalidateNeedItemCache()
		{
			this.NeedItemCache = null;
			this.NeedItemChainItemSet = null;
			this.NeedItemGroupByTypeCache = null;
			this.DeficitDetectionIdSetCache = null;
			this.ClearWorldDropTip();
			Singleton<EventSystem>.Instance.Emit(EEventName.RoleDevelopNeedItemsChanged);
		}

		// Token: 0x06035342 RID: 217922 RVA: 0x00D54ECC File Offset: 0x00D530CC
		private void OnCommonItemCountAnyChange(int configId, int count)
		{
			if (this.DevTargetRoleIdInternal != 0 && this.GetNeedItemChainItemSet().Contains(configId))
			{
				this.InvalidateNeedItemCache();
			}
			if (this.DevTargetRoleIdInternal != 0 && (this.IsDevelopRoleNeedItem(configId) || this.GetNeedItemChainItemSet().Contains(configId)))
			{
				this.DeficitDetectionIdSetCache = null;
			}
			if (!this.WorldDropTipShownItemIds.Contains(configId))
			{
				return;
			}
			if (this.DevTargetRoleIdInternal == 0)
			{
				return;
			}
			if (!this.IsDevelopRoleNeedItem(configId))
			{
				return;
			}
			int developRoleNeedItemCount = this.GetDevelopRoleNeedItemCount(configId);
			if (count < developRoleNeedItemCount)
			{
				this.WorldDropTipShownItemIds.Remove(configId);
				return;
			}
			RoleDevelopItemGroup roleDevelopItemGroup = this.BuildNeedItemGroupByItemId(configId);
			if (roleDevelopItemGroup == null)
			{
				return;
			}
			EItemRequirementState itemGroupRequirementState = this.GetItemGroupRequirementState(roleDevelopItemGroup, null);
			if (itemGroupRequirementState != EItemRequirementState.Satisfied && itemGroupRequirementState != EItemRequirementState.Supplement)
			{
				this.WorldDropTipShownItemIds.Remove(configId);
			}
		}

		// Token: 0x06035343 RID: 217923 RVA: 0x00D54F88 File Offset: 0x00D53188
		private void OnItemRewardNotify(ItemRewardNotify notify)
		{
			if (notify == null || this.DevTargetRoleIdInternal == 0)
			{
				return;
			}
			Dictionary<int, int> dictionary = this.AggregateRewardItemCounts(notify);
			if (dictionary.Count <= 0)
			{
				return;
			}
			RoleDevConfig instance = ConfigBase<RoleDevConfig>.Instance;
			if (instance == null)
			{
				return;
			}
			Dictionary<int, int> dictionary2 = new Dictionary<int, int>();
			int? num = null;
			foreach (KeyValuePair<int, int> keyValuePair in dictionary)
			{
				int key = keyValuePair.Key;
				int value = keyValuePair.Value;
				if (this.IsDevelopRoleNeedItem(key))
				{
					RoleDevItemJumpGroup? itemJumpGroupConfig = instance.GetItemJumpGroupConfig(key);
					if (itemJumpGroupConfig != null)
					{
						EItemMaterialType itemType = (EItemMaterialType)itemJumpGroupConfig.Value.ItemType;
						if (itemType == EItemMaterialType.Map || itemType == EItemMaterialType.Drop)
						{
							dictionary2[key] = value;
							if (num == null)
							{
								num = new int?(key);
							}
						}
					}
				}
			}
			if (num != null)
			{
				this.HandleDropTypeReward(num.Value, dictionary2);
			}
		}

		// Token: 0x06035344 RID: 217924 RVA: 0x00D55084 File Offset: 0x00D53284
		private Dictionary<int, int> AggregateRewardItemCounts(ItemRewardNotify notify)
		{
			Dictionary<int, int> dictionary = new Dictionary<int, int>();
			MapField<int, RewardItemInfoList> rewardItems = notify.RewardItems;
			if (rewardItems == null)
			{
				return dictionary;
			}
			foreach (int key in rewardItems.Keys)
			{
				RewardItemInfoList rewardItemInfoList;
				if (rewardItems.TryGetValue(key, out rewardItemInfoList) && rewardItemInfoList != null)
				{
					RepeatedField<RewardItemInfo> itemList = rewardItemInfoList.ItemList;
					if (itemList != null)
					{
						foreach (RewardItemInfo rewardItemInfo in itemList)
						{
							int itemId = rewardItemInfo.ItemId;
							int count = rewardItemInfo.Count;
							if (itemId > 0 && count > 0)
							{
								dictionary[itemId] = dictionary.GetValueOrDefault(itemId, 0) + count;
							}
						}
					}
				}
			}
			return dictionary;
		}

		// Token: 0x06035345 RID: 217925 RVA: 0x00D55160 File Offset: 0x00D53360
		private void HandleDropTypeReward(int representativeItemId, Dictionary<int, int> dropExcludeMap)
		{
			RoleDevelopItemGroup roleDevelopItemGroup = this.BuildNeedItemGroupByItemId(representativeItemId);
			if (roleDevelopItemGroup == null)
			{
				return;
			}
			EItemRequirementState itemGroupRequirementState = this.GetItemGroupRequirementState(roleDevelopItemGroup, dropExcludeMap);
			EItemRequirementState itemGroupRequirementState2 = this.GetItemGroupRequirementState(roleDevelopItemGroup, null);
			if (!RoleDevelopModel.<HandleDropTypeReward>g__Enough|76_0(itemGroupRequirementState) && RoleDevelopModel.<HandleDropTypeReward>g__Enough|76_0(itemGroupRequirementState2))
			{
				this.ShowDropEnoughTip(representativeItemId);
			}
		}

		// Token: 0x06035346 RID: 217926 RVA: 0x00D551A0 File Offset: 0x00D533A0
		private void ShowDropEnoughTip(int itemId)
		{
			int? dropPromptDisplayItemId = this.GetDropPromptDisplayItemId(itemId);
			if (dropPromptDisplayItemId != null)
			{
				RoleDevelopWorldDropEnoughTipsController.TryShow(itemId, dropPromptDisplayItemId.Value);
			}
		}

		// Token: 0x06035347 RID: 217927 RVA: 0x00D551CC File Offset: 0x00D533CC
		private int? GetDropPromptDisplayItemId(int itemId)
		{
			ComposePopupModel instance = ModelBase<ComposePopupModel>.Instance;
			CSharpScript.Game.Module.Item.ItemConfig instance2 = ConfigBase<CSharpScript.Game.Module.Item.ItemConfig>.Instance;
			HashSet<int> hashSet = new HashSet<int>
			{
				itemId
			};
			Queue<int> queue = new Queue<int>(4);
			queue.Push(itemId);
			while (queue.Size > 0)
			{
				int itemId2 = queue.Pop();
				List<IComposeItemData> composeMaterialList = instance.GetComposeMaterialList(itemId2);
				if (composeMaterialList != null && composeMaterialList.Count != 0)
				{
					foreach (IComposeItemData composeItemData in composeMaterialList)
					{
						int itemId3 = composeItemData.ItemId;
						if (itemId3 != 0 && !hashSet.Contains(itemId3))
						{
							hashSet.Add(itemId3);
							queue.Push(itemId3);
						}
					}
				}
			}
			if (hashSet.Count < 2)
			{
				return new int?(itemId);
			}
			InventoryDefine.EQuality equality = (ModelBase<WorldLevelModel>.Instance.OriginWorldLevel > 5) ? InventoryDefine.EQuality.Orange : InventoryDefine.EQuality.Purple;
			foreach (int num in hashSet)
			{
				ItemInfo? itemInfo;
				if (((instance2.GetConfig(num) != null) ? itemInfo.GetValueOrDefault().QualityId : 0) == (int)equality)
				{
					return new int?(num);
				}
			}
			return new int?(itemId);
		}

		// Token: 0x06035348 RID: 217928 RVA: 0x00D55328 File Offset: 0x00D53528
		public bool EnqueueWorldDropTip(int itemId, int displayItemId)
		{
			if (this.WorldDropTipShownItemIds.Contains(itemId))
			{
				return false;
			}
			this.WorldDropTipShownItemIds.Add(itemId);
			this.WorldDropTipQueue.Add(new RoleDevelopWorldDropTipEntry
			{
				ItemId = itemId,
				DisplayItemId = displayItemId
			});
			return true;
		}

		// Token: 0x06035349 RID: 217929 RVA: 0x00D55368 File Offset: 0x00D53568
		public bool AdvanceWorldDropTipToNext()
		{
			if (this.WorldDropTipQueue.Count <= 0)
			{
				this.WorldDropTipCurrentEntry = null;
				this.IsWorldDropTipShowing = false;
				return false;
			}
			this.WorldDropTipCurrentEntry = this.WorldDropTipQueue[0];
			this.WorldDropTipQueue.RemoveAt(0);
			this.IsWorldDropTipShowing = true;
			return true;
		}

		// Token: 0x0603534A RID: 217930 RVA: 0x00D553B9 File Offset: 0x00D535B9
		[NullableContext(2)]
		public RoleDevelopWorldDropTipEntry GetWorldDropTipCurrentEntry()
		{
			return this.WorldDropTipCurrentEntry;
		}

		// Token: 0x0603534B RID: 217931 RVA: 0x00D553C1 File Offset: 0x00D535C1
		public bool HasPendingWorldDropTip()
		{
			return this.WorldDropTipQueue.Count > 0;
		}

		// Token: 0x0603534C RID: 217932 RVA: 0x00D553D1 File Offset: 0x00D535D1
		public void ClearWorldDropTip()
		{
			this.WorldDropTipQueue.Clear();
			this.WorldDropTipShownItemIds.Clear();
			this.WorldDropTipCurrentEntry = null;
			this.IsWorldDropTipShowing = false;
		}

		// Token: 0x0603534D RID: 217933 RVA: 0x00D553F7 File Offset: 0x00D535F7
		private Dictionary<int, int> GetNeedItemCache()
		{
			if (this.NeedItemCache == null)
			{
				this.BuildNeedItemCaches();
			}
			return this.NeedItemCache;
		}

		// Token: 0x0603534E RID: 217934 RVA: 0x00D5540D File Offset: 0x00D5360D
		public HashSet<int> GetNeedItemChainItemSet()
		{
			if (this.NeedItemChainItemSet == null)
			{
				this.BuildNeedItemCaches();
			}
			return this.NeedItemChainItemSet;
		}

		// Token: 0x0603534F RID: 217935 RVA: 0x00D55424 File Offset: 0x00D53624
		private Dictionary<EItemMaterialType, List<int>> GetItemIdsByMaterialType()
		{
			if (this.ItemIdsByMaterialTypeCache != null)
			{
				return this.ItemIdsByMaterialTypeCache;
			}
			Dictionary<EItemMaterialType, List<int>> dictionary = new Dictionary<EItemMaterialType, List<int>>();
			IReadOnlyList<RoleDevItemJumpGroup> allItemJumpGroupConfigs = ConfigBase<RoleDevConfig>.Instance.GetAllItemJumpGroupConfigs();
			if (allItemJumpGroupConfigs != null)
			{
				foreach (RoleDevItemJumpGroup roleDevItemJumpGroup in allItemJumpGroupConfigs)
				{
					EItemMaterialType itemType = (EItemMaterialType)roleDevItemJumpGroup.ItemType;
					List<int> list;
					if (!dictionary.TryGetValue(itemType, out list))
					{
						list = new List<int>();
						dictionary[itemType] = list;
					}
					list.Add(roleDevItemJumpGroup.ItemId);
				}
			}
			this.ItemIdsByMaterialTypeCache = dictionary;
			return dictionary;
		}

		// Token: 0x06035350 RID: 217936 RVA: 0x00D554C4 File Offset: 0x00D536C4
		private void BuildNeedItemCaches()
		{
			Dictionary<int, int> dictionary = new Dictionary<int, int>();
			HashSet<int> hashSet = new HashSet<int>();
			RoleDevelopData roleDevelopData = this.GetRoleDevelopData(this.DevTargetRoleIdInternal);
			if (roleDevelopData == null)
			{
				this.NeedItemCache = dictionary;
				this.NeedItemChainItemSet = hashSet;
				return;
			}
			RoleDevelopProjectBaseData projectData = roleDevelopData.GetProjectData();
			foreach (List<RoleDevelopNeedItem> list in new List<List<RoleDevelopNeedItem>>
			{
				projectData.GetRoleUpgradeNeedItems(),
				projectData.GetRoleBreachNeedItems(),
				projectData.GetWeaponUpgradeNeedItems(),
				projectData.GetWeaponBreachNeedItems(),
				projectData.GetSkillPlanNeedItems()
			})
			{
				foreach (RoleDevelopNeedItem roleDevelopNeedItem in list)
				{
					if (!RoleDevelopUtil.IsUnknownItem(roleDevelopNeedItem.ItemId))
					{
						int num;
						dictionary.TryGetValue(roleDevelopNeedItem.ItemId, out num);
						dictionary[roleDevelopNeedItem.ItemId] = num + roleDevelopNeedItem.Count;
					}
				}
			}
			ComposePopupModel instance = ModelBase<ComposePopupModel>.Instance;
			ItemAccessedFromGiftPathConfig instance2 = ConfigBase<ItemAccessedFromGiftPathConfig>.Instance;
			RoleDevConfig instance3 = ConfigBase<RoleDevConfig>.Instance;
			HashSet<int> hashSet2 = new HashSet<int>(dictionary.Keys);
			Queue<int> queue = new Queue<int>(4);
			foreach (int element in dictionary.Keys)
			{
				queue.Push(element);
			}
			HashSet<EItemMaterialType> hashSet3 = new HashSet<EItemMaterialType>();
			foreach (int itemId in dictionary.Keys)
			{
				RoleDevItemJumpGroup? itemJumpGroupConfig = instance3.GetItemJumpGroupConfig(itemId);
				if (itemJumpGroupConfig != null)
				{
					EItemMaterialType itemType = (EItemMaterialType)itemJumpGroupConfig.Value.ItemType;
					if (itemType == EItemMaterialType.RoleExp || itemType == EItemMaterialType.WeaponExp)
					{
						hashSet3.Add(itemType);
					}
				}
			}
			if (hashSet3.Count <= 0)
			{
				goto IL_331;
			}
			Dictionary<EItemMaterialType, List<int>> itemIdsByMaterialType = this.GetItemIdsByMaterialType();
			using (HashSet<EItemMaterialType>.Enumerator enumerator4 = hashSet3.GetEnumerator())
			{
				while (enumerator4.MoveNext())
				{
					EItemMaterialType key = enumerator4.Current;
					List<int> list2;
					if (itemIdsByMaterialType.TryGetValue(key, out list2))
					{
						foreach (int num2 in list2)
						{
							hashSet.Add(num2);
							if (hashSet2.Add(num2))
							{
								queue.Push(num2);
							}
						}
					}
				}
				goto IL_331;
			}
			IL_26E:
			int num3 = queue.Pop();
			List<IComposeItemData> composeMaterialList = instance.GetComposeMaterialList(num3);
			if (composeMaterialList != null)
			{
				foreach (IComposeItemData composeItemData in composeMaterialList)
				{
					if (hashSet2.Add(composeItemData.ItemId))
					{
						hashSet.Add(composeItemData.ItemId);
						queue.Push(composeItemData.ItemId);
					}
				}
			}
			foreach (int num4 in instance2.GetGiftItemGroupById(num3, true))
			{
				if (hashSet2.Add(num4))
				{
					hashSet.Add(num4);
					queue.Push(num4);
				}
			}
			IL_331:
			if (queue.Empty)
			{
				this.NeedItemCache = dictionary;
				this.NeedItemChainItemSet = hashSet;
				return;
			}
			goto IL_26E;
		}

		// Token: 0x06035351 RID: 217937 RVA: 0x00D55880 File Offset: 0x00D53A80
		public HashSet<int> GetDevelopRoleDeficitDetectionIdSet()
		{
			if (this.DeficitDetectionIdSetCache == null)
			{
				this.DeficitDetectionIdSetCache = this.BuildDeficitDetectionIdSet();
			}
			HashSet<int> hashSet = new HashSet<int>(this.DeficitDetectionIdSetCache);
			foreach (int item in this.BuildPhantomPlanDetectionIdSet())
			{
				hashSet.Add(item);
			}
			return hashSet;
		}

		// Token: 0x06035352 RID: 217938 RVA: 0x00D558F8 File Offset: 0x00D53AF8
		public int GetDevelopRoleNeedItemDeficitCount(int itemId)
		{
			int developRoleNeedItemCount = this.GetDevelopRoleNeedItemCount(itemId);
			int itemCountByConfigId = ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(itemId, 0);
			return Math.Max(0, developRoleNeedItemCount - itemCountByConfigId);
		}

		// Token: 0x06035353 RID: 217939 RVA: 0x00D55924 File Offset: 0x00D53B24
		private HashSet<int> BuildDeficitDetectionIdSet()
		{
			HashSet<int> hashSet = new HashSet<int>();
			if (this.DevTargetRoleIdInternal == 0)
			{
				return hashSet;
			}
			RoleDevConfig instance = ConfigBase<RoleDevConfig>.Instance;
			foreach (KeyValuePair<int, int> keyValuePair in this.GetNeedItemCache())
			{
				int key = keyValuePair.Key;
				int value = keyValuePair.Value;
				if (!RoleDevelopUtil.IsUnknownItem(key) && ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(key, 0) < value)
				{
					RoleDevItemJumpGroup? itemJumpGroupConfig = instance.GetItemJumpGroupConfig(key);
					if (itemJumpGroupConfig != null)
					{
						int itemType = itemJumpGroupConfig.Value.ItemType;
						if (itemType >= 1 && itemType <= 5)
						{
							int detectionType = itemJumpGroupConfig.Value.DetectionType;
							if (detectionType == 1 || detectionType == 2)
							{
								int detectionIDLength = itemJumpGroupConfig.Value.DetectionIDLength;
								if (detectionIDLength > 0)
								{
									for (int i = 0; i < detectionIDLength; i++)
									{
										int num = itemJumpGroupConfig.Value.DetectionID(i);
										if (num != 0)
										{
											hashSet.Add(num);
										}
									}
								}
							}
						}
					}
				}
			}
			return hashSet;
		}

		// Token: 0x06035354 RID: 217940 RVA: 0x00D55A58 File Offset: 0x00D53C58
		private unsafe HashSet<int> BuildPhantomPlanDetectionIdSet()
		{
			HashSet<int> hashSet = new HashSet<int>();
			if (this.DevTargetRoleIdInternal == 0)
			{
				return hashSet;
			}
			RoleDevConfig instance = ConfigBase<RoleDevConfig>.Instance;
			foreach (int fetterGroupId in RoleDevelopUtil.GetDefaultRecommendFetterGroupIdList(this.DevTargetRoleIdInternal))
			{
				RoleDevPhantomJumpGroup? phantomJumpGroupConfig = instance.GetPhantomJumpGroupConfig(fetterGroupId);
				if (phantomJumpGroupConfig != null)
				{
					Span<int> phantomJumpIdBytes = phantomJumpGroupConfig.Value.GetPhantomJumpIdBytes();
					for (int i = 0; i < phantomJumpIdBytes.Length; i++)
					{
						int num = *phantomJumpIdBytes[i];
						if (num != 0)
						{
							hashSet.Add(num);
						}
					}
				}
			}
			return hashSet;
		}

		// Token: 0x06035355 RID: 217941 RVA: 0x00D55B14 File Offset: 0x00D53D14
		private RoleDevelopSettlementJumpData CreateEmptySettlementJumpData(ERoleDevelopSettlementSourceDungeonType sourceDungeonType)
		{
			return new RoleDevelopSettlementJumpData
			{
				CanShow = false,
				RoleId = 0,
				RoleIconPath = "",
				MatchedItemIds = new List<int>(),
				NeedCheckItemIds = new List<int>(),
				SourceDungeonType = sourceDungeonType
			};
		}

		// Token: 0x06035357 RID: 217943 RVA: 0x00D55B85 File Offset: 0x00D53D85
		[CompilerGenerated]
		internal static bool <HandleDropTypeReward>g__Enough|76_0(EItemRequirementState s)
		{
			return s == EItemRequirementState.Satisfied || s == EItemRequirementState.Supplement;
		}

		// Token: 0x0401EA0F RID: 125455
		private int DevTargetRoleIdInternal;

		// Token: 0x0401EA10 RID: 125456
		private string VersionInternal = "";

		// Token: 0x0401EA11 RID: 125457
		private Dictionary<int, RoleDevelopData> RoleDevelopDataMap = new Dictionary<int, RoleDevelopData>();

		// Token: 0x0401EA12 RID: 125458
		[Nullable(2)]
		private Dictionary<int, int> NeedItemCache;

		// Token: 0x0401EA13 RID: 125459
		[Nullable(2)]
		private HashSet<int> NeedItemChainItemSet;

		// Token: 0x0401EA14 RID: 125460
		[Nullable(2)]
		private HashSet<int> DeficitDetectionIdSetCache;

		// Token: 0x0401EA15 RID: 125461
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Dictionary<EItemMaterialType, RoleDevelopItemGroup> NeedItemGroupByTypeCache;

		// Token: 0x0401EA16 RID: 125462
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Dictionary<EItemMaterialType, List<int>> ItemIdsByMaterialTypeCache;

		// Token: 0x0401EA17 RID: 125463
		private List<RoleDevelopWorldDropTipEntry> WorldDropTipQueue = new List<RoleDevelopWorldDropTipEntry>();

		// Token: 0x0401EA18 RID: 125464
		private HashSet<int> WorldDropTipShownItemIds = new HashSet<int>();

		// Token: 0x0401EA19 RID: 125465
		[Nullable(2)]
		private RoleDevelopWorldDropTipEntry WorldDropTipCurrentEntry;

		// Token: 0x0401EA1B RID: 125467
		public int SelectPlanId;

		// Token: 0x0401EA1C RID: 125468
		public int SelectFirstVisionMonsterId;

		// Token: 0x0200B034 RID: 45108
		[NullableContext(0)]
		private class ItemCalcInfo
		{
			// Token: 0x04036AA1 RID: 223905
			public int ItemId;

			// Token: 0x04036AA2 RID: 223906
			public int QualityId;

			// Token: 0x04036AA3 RID: 223907
			public int Deficit;

			// Token: 0x04036AA4 RID: 223908
			public int NeededPoints;

			// Token: 0x04036AA5 RID: 223909
			public int AvailablePoints;
		}
	}
}
