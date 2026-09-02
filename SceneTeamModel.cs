using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Module.SeamlessTravel;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002965 RID: 10597
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class SceneTeamModel : ModelBase<SceneTeamModel>
{
	// Token: 0x17001BBF RID: 7103
	// (get) Token: 0x060150FE RID: 86270 RVA: 0x005D30E8 File Offset: 0x005D12E8
	// (set) Token: 0x060150FF RID: 86271 RVA: 0x005D3128 File Offset: 0x005D1328
	public bool ChangingRole
	{
		get
		{
			if (this.ChangingRoleTime <= 0L)
			{
				return false;
			}
			if (DateTimeOffset.Now.ToUnixTimeMilliseconds() - this.ChangingRoleTime > 2000L)
			{
				this.ChangingRoleTime = 0L;
				return false;
			}
			return true;
		}
		set
		{
			this.RequestingChangeRole = value;
			this.ChangingRoleTime = (value ? DateTimeOffset.Now.ToUnixTimeMilliseconds() : 0L);
		}
	}

	// Token: 0x06015100 RID: 86272 RVA: 0x005D3158 File Offset: 0x005D1358
	protected override bool OnInit()
	{
		this.DefaultChangeRoleCooldown = (double)ConfigCommonParamById.GetFloatConfig("change_role_cooldown").Value;
		this.ResetChangeRoleCooldown();
		this.OnChangeRoleStat = Stat.Create("SceneTeamModel.OnChangeRoleStat", "", "STATGROUP_KuroBattle");
		this.MarkTeamNotReady();
		Singleton<EventSystem>.Instance.Add(EEventName.OnGlobalFootstepMaterialChange, new Action<UPhysicalMaterial>(this.OnPhysicalMaterialChange));
		return true;
	}

	// Token: 0x06015101 RID: 86273 RVA: 0x005D31C1 File Offset: 0x005D13C1
	protected override bool OnClear()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnGlobalFootstepMaterialChange, new Action<UPhysicalMaterial>(this.OnPhysicalMaterialChange));
		return true;
	}

	// Token: 0x06015102 RID: 86274 RVA: 0x005D31E0 File Offset: 0x005D13E0
	protected override bool OnLeaveLevel()
	{
		this.FinishSeamlessUpdateTeam();
		this.ResetChangeRoleCooldown();
		if (ModelBase<SeamlessTravelModel>.Instance.IsSeamlessTravel)
		{
			return true;
		}
		this.ClearTeam();
		return true;
	}

	// Token: 0x06015103 RID: 86275 RVA: 0x005D3203 File Offset: 0x005D1403
	protected override bool OnChangeMode()
	{
		this.FinishSeamlessUpdateTeam();
		this.ResetChangeRoleCooldown();
		this.ClearTeam();
		return true;
	}

	// Token: 0x06015104 RID: 86276 RVA: 0x005D3218 File Offset: 0x005D1418
	private void ClearTeam()
	{
		this.LastTransform = null;
		foreach (SceneTeamPlayer sceneTeamPlayer in this.TeamPlayerMap.Values)
		{
			sceneTeamPlayer.Clear();
		}
		this.TeamPlayerMap.Clear();
		foreach (SceneTeamItem sceneTeamItem in this.TeamItems)
		{
			sceneTeamItem.Reset();
		}
		this.TeamItems.Clear();
		this.PlayerIdSet.Clear();
		this.PreloadEntitySet.Clear();
		this.PanelQteHandleId = 0;
		this.PanelQteRoleIdSet.Clear();
		this.WaitTask = null;
		this.CurrentItem = null;
		this.IsPhantomTeam = false;
		this.LastRoleIdList = null;
		GameModePromise loadTeamPromise = this.LoadTeamPromise;
		if (loadTeamPromise != null)
		{
			loadTeamPromise.SetResult(false);
		}
		this.LoadTeamPromise = null;
		this.MarkTeamNotReady();
	}

	// Token: 0x06015105 RID: 86277 RVA: 0x005D3334 File Offset: 0x005D1534
	public void FinishSeamlessUpdateTeam()
	{
		this.IsSeamlessUpdateTeam = false;
		this.SeamlessUpdateTeamStartTime = 0L;
		if (this.IsSeamlessUpdateTeamBlockInput)
		{
			this.IsSeamlessUpdateTeamBlockInput = false;
			ControllerBase<InputDistributeController>.Instance.RefreshInputTag();
		}
		EntityHandle seamlessDelayRemoveEntityHandle = this.SeamlessDelayRemoveEntityHandle;
		if (seamlessDelayRemoveEntityHandle != null)
		{
			ControllerBase<CreatureController>.Instance.DelayRemoveEntityFinished(seamlessDelayRemoveEntityHandle);
			this.SeamlessDelayRemoveEntityHandle = null;
		}
	}

	// Token: 0x06015106 RID: 86278 RVA: 0x005D3385 File Offset: 0x005D1585
	[NullableContext(2)]
	private void OnPhysicalMaterialChange(UPhysicalMaterial material)
	{
		if (this.PhysMaterial != material)
		{
			this.PhysMaterial = material;
		}
	}

	// Token: 0x06015107 RID: 86279 RVA: 0x005D3398 File Offset: 0x005D1598
	public unsafe void SwitchGroup(int playerId, ETeamGroupType groupType, bool useGoBattleSkill = false, bool forceInheritState = false)
	{
		SceneTeamPlayer sceneTeamPlayer = this.TeamPlayerMap.ContainsKey(playerId) ? this.TeamPlayerMap[playerId] : null;
		if (sceneTeamPlayer == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.SceneTeam;
			ELogAuthor author = ELogAuthor.LYY;
			string message = "切换编队组玩家不存在";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("PlayerId", playerId);
			instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		Log instance2 = Singleton<Log>.Instance;
		ELogModule module2 = ELogModule.SceneTeam;
		ELogAuthor author2 = ELogAuthor.LYY;
		string message2 = "切换编队组";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("PlayerId", playerId);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("GroupType", groupType);
		instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		ETeamGroupType? currentGroupType = sceneTeamPlayer.GetCurrentGroupType();
		if (groupType == currentGroupType.GetValueOrDefault() & currentGroupType != null)
		{
			return;
		}
		this.SwitchGroupInternal(playerId, sceneTeamPlayer, groupType);
		bool flag = forceInheritState;
		if (!flag)
		{
			ETeamGroupType? currentGroupType2 = this.CurrentGroupType;
			flag = this.IsNeedInherit(currentGroupType2.GetValueOrDefault(), groupType);
		}
		this.TeamGoBattle(flag, useGoBattleSkill);
	}

	// Token: 0x06015108 RID: 86280 RVA: 0x005D349C File Offset: 0x005D169C
	private void SwitchGroupInternal(int playerId, SceneTeamPlayer player, ETeamGroupType groupType)
	{
		player.SwitchGroup(groupType);
		int? id = ModelBase<PlayerInfoModel>.Instance.GetId();
		if (playerId == id.GetValueOrDefault() & id != null)
		{
			this.CurrentGroupType = new ETeamGroupType?(groupType);
			this.IsPhantomTeam = (groupType == ETeamGroupType.Phantom);
			Singleton<EventSystem>.Instance.Emit(EEventName.OnUpdateTeamGroupType);
		}
	}

	// Token: 0x06015109 RID: 86281 RVA: 0x005D34F8 File Offset: 0x005D16F8
	public void UpdateGroupData(int playerId, IUpdateGroupParams @params)
	{
		SceneTeamPlayer sceneTeamPlayer = this.TeamPlayerMap.ContainsKey(playerId) ? this.TeamPlayerMap[playerId] : null;
		if (sceneTeamPlayer == null)
		{
			sceneTeamPlayer = SceneTeamPlayer.Create(playerId);
			this.TeamPlayerMap[playerId] = sceneTeamPlayer;
		}
		sceneTeamPlayer.UpdateGroup(@params.GroupType, @params.GroupRoleList, @params.CurrentRoleId, @params.LivingState.GetValueOrDefault(ETeamLivingState.Alive), @params.IsFixedLocation.GetValueOrDefault());
		sceneTeamPlayer.RefreshEntityEnable();
		SceneTeamPlayer valueOrDefault = this.TeamPlayerMap.GetValueOrDefault(playerId);
		ETeamGroupType? eteamGroupType = (valueOrDefault != null) ? valueOrDefault.GetCurrentGroupType() : null;
		ETeamGroupType groupType = @params.GroupType;
		ETeamGroupType? eteamGroupType2 = eteamGroupType;
		if (groupType == eteamGroupType2.GetValueOrDefault() & eteamGroupType2 != null)
		{
			this.TeamGoBattle(true, false);
		}
	}

	// Token: 0x0601510A RID: 86282 RVA: 0x005D35BC File Offset: 0x005D17BC
	public void UpdateGroupDataAndSwitchGroup(int playerId, IUpdateGroupParams @params)
	{
		SceneTeamPlayer sceneTeamPlayer = this.TeamPlayerMap.ContainsKey(playerId) ? this.TeamPlayerMap[playerId] : null;
		if (sceneTeamPlayer == null)
		{
			sceneTeamPlayer = SceneTeamPlayer.Create(playerId);
			this.TeamPlayerMap[playerId] = sceneTeamPlayer;
		}
		ETeamGroupType groupType = @params.GroupType;
		sceneTeamPlayer.UpdateGroup(groupType, @params.GroupRoleList, @params.CurrentRoleId, @params.LivingState.GetValueOrDefault(ETeamLivingState.Alive), @params.IsFixedLocation.GetValueOrDefault());
		this.SwitchGroupInternal(playerId, sceneTeamPlayer, groupType);
		sceneTeamPlayer.RefreshEntityEnable();
		this.TeamGoBattle(true, false);
	}

	// Token: 0x0601510B RID: 86283 RVA: 0x005D364C File Offset: 0x005D184C
	public void AddRoleAndSwitchGroup(int playerId, ETeamGroupType groupType, SceneTeamRole[] roleList)
	{
		SceneTeamPlayer sceneTeamPlayer = this.TeamPlayerMap.ContainsKey(playerId) ? this.TeamPlayerMap[playerId] : null;
		if (sceneTeamPlayer == null)
		{
			return;
		}
		SceneTeamGroup group = sceneTeamPlayer.GetGroup(groupType);
		if (group == null || group.GetLivingState() == ETeamLivingState.Dead)
		{
			return;
		}
		group.AddRoleList(roleList);
		this.SwitchGroupInternal(playerId, sceneTeamPlayer, groupType);
		sceneTeamPlayer.RefreshEntityEnable();
		this.TeamGoBattle(true, false);
	}

	// Token: 0x0601510C RID: 86284 RVA: 0x005D36B0 File Offset: 0x005D18B0
	public unsafe void UpdateAllPlayerData(IList<IUpdatePlayerParams> paramsList)
	{
		List<int> list = new List<int>();
		foreach (int num in this.TeamPlayerMap.Keys)
		{
			bool flag = false;
			using (IEnumerator<IUpdatePlayerParams> enumerator2 = paramsList.GetEnumerator())
			{
				while (enumerator2.MoveNext())
				{
					if (enumerator2.Current.PlayerId == num)
					{
						flag = true;
						break;
					}
				}
			}
			if (!flag)
			{
				list.Add(num);
			}
		}
		foreach (int key in list)
		{
			if (this.TeamPlayerMap.ContainsKey(key))
			{
				this.TeamPlayerMap[key].Clear();
			}
			this.TeamPlayerMap.Remove(key);
		}
		int playerId = ModelBase<CreatureModel>.Instance.GetPlayerId();
		ETeamGroupType? currentGroupType = this.CurrentGroupType;
		foreach (IUpdatePlayerParams updatePlayerParams in paramsList)
		{
			int playerId2 = updatePlayerParams.PlayerId;
			ETeamGroupType currentGroupType2 = updatePlayerParams.CurrentGroupType;
			SceneTeamPlayer sceneTeamPlayer = this.TeamPlayerMap.ContainsKey(playerId2) ? this.TeamPlayerMap[playerId2] : null;
			if (sceneTeamPlayer == null)
			{
				sceneTeamPlayer = SceneTeamPlayer.Create(playerId2);
				this.TeamPlayerMap[playerId2] = sceneTeamPlayer;
			}
			SceneTeamGroup currentGroup = sceneTeamPlayer.GetCurrentGroup();
			int? num2;
			if (currentGroup == null)
			{
				num2 = null;
			}
			else
			{
				SceneTeamRole currentRole = currentGroup.GetCurrentRole();
				num2 = ((currentRole != null) ? new int?(currentRole.RoleId) : null);
			}
			int? num3 = num2;
			bool flag2 = playerId == playerId2 && this.RequestingChangeRole;
			this.SwitchGroupInternal(playerId2, sceneTeamPlayer, currentGroupType2);
			foreach (IUpdateGroupParams updateGroupParams in updatePlayerParams.Groups)
			{
				int num4 = updateGroupParams.CurrentRoleId;
				if (flag2 && updateGroupParams.GroupType == currentGroupType2)
				{
					foreach (SceneTeamRole sceneTeamRole in updateGroupParams.GroupRoleList)
					{
						int roleId = sceneTeamRole.RoleId;
						int? num5 = num3;
						if (roleId == num5.GetValueOrDefault() & num5 != null)
						{
							Log instance = Singleton<Log>.Instance;
							ELogModule module = ELogModule.SceneTeam;
							ELogAuthor author = ELogAuthor.LYY;
							string message = "更新编队组数据时，覆盖服务端当前角色";
							<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
							*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("ServerRoleId", num4);
							*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("ClientRoleId", num3);
							instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
							num4 = num3.Value;
							break;
						}
					}
				}
				sceneTeamPlayer.UpdateGroup(updateGroupParams.GroupType, updateGroupParams.GroupRoleList, num4, updateGroupParams.LivingState.GetValueOrDefault(ETeamLivingState.Alive), updateGroupParams.IsFixedLocation.GetValueOrDefault());
			}
			sceneTeamPlayer.RefreshEntityEnable();
		}
		ETeamGroupType? currentGroupType3 = this.CurrentGroupType;
		bool needInheritState = this.IsNeedInherit(currentGroupType.GetValueOrDefault(), currentGroupType3.GetValueOrDefault());
		this.TeamGoBattle(needInheritState, false);
	}

	// Token: 0x0601510D RID: 86285 RVA: 0x005D3A80 File Offset: 0x005D1C80
	private bool IsNeedInherit(ETeamGroupType lastType = ETeamGroupType.Default, ETeamGroupType newType = ETeamGroupType.Default)
	{
		return newType == lastType || SceneTeamDefine.needInheritTypeSet.Contains(lastType) || SceneTeamDefine.needInheritTypeSet.Contains(newType);
	}

	// Token: 0x0601510E RID: 86286 RVA: 0x005D3AA0 File Offset: 0x005D1CA0
	public void UpdateGroupLivingStates(int playerId, Dictionary<ETeamGroupType, ETeamLivingState> teamLivingStateMap)
	{
		SceneTeamPlayer sceneTeamPlayer = this.TeamPlayerMap.ContainsKey(playerId) ? this.TeamPlayerMap[playerId] : null;
		if (sceneTeamPlayer != null)
		{
			foreach (KeyValuePair<ETeamGroupType, ETeamLivingState> keyValuePair in teamLivingStateMap)
			{
				SceneTeamGroup group = sceneTeamPlayer.GetGroup(keyValuePair.Key);
				if (group != null)
				{
					group.UpdateLivingState(keyValuePair.Value);
				}
			}
		}
	}

	// Token: 0x0601510F RID: 86287 RVA: 0x005D3B28 File Offset: 0x005D1D28
	private void TeamGoBattle(bool needInheritState, bool useGoBattleSkill = false)
	{
		Singleton<Log>.Instance.Info(ELogModule.SceneTeam, ELogAuthor.LYY, "刷新出战编队，开始", default(ReadOnlySpan<ValueTuple<string, object>>));
		this.MarkTeamNotReady();
		this.RefreshLastTransform();
		this.TeamItems.Clear();
		this.PlayerIdSet.Clear();
		if (this.SeamlessWaitUpdateTeamTimer != null)
		{
			this.SeamlessWaitUpdateTeamTimer.Remove();
			this.SeamlessWaitUpdateTeamTimer = null;
		}
		if (this.WaitTask != null)
		{
			Singleton<Log>.Instance.Info(ELogModule.SceneTeam, ELogAuthor.LYY, "刷新出战编队，中断等待", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.WaitTask.Cancel();
		}
		this.TeamGoBattleStartTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();
		SceneTeamItem goBattleItem = null;
		bool allowRefreshTransform = false;
		List<long> list = new List<long>();
		int selfPlayerId = ModelBase<CreatureModel>.Instance.GetPlayerId();
		int[] array;
		if (!ModelBase<GameModeModel>.Instance.IsMulti)
		{
			(array = new int[1])[0] = selfPlayerId;
		}
		else
		{
			array = ModelBase<OnlineModel>.Instance.GetAllWorldTeamPlayer();
		}
		foreach (int num in array)
		{
			SceneTeamPlayer sceneTeamPlayer;
			SceneTeamGroup sceneTeamGroup = this.TeamPlayerMap.TryGetValue(num, out sceneTeamPlayer) ? ((sceneTeamPlayer != null) ? sceneTeamPlayer.GetCurrentGroup() : null) : null;
			List<SceneTeamRole> list2 = (sceneTeamGroup != null) ? sceneTeamGroup.GetRoleList() : null;
			if (list2 != null && list2.Count != 0)
			{
				if (num == selfPlayerId)
				{
					allowRefreshTransform = !sceneTeamGroup.IsFixedLocation;
				}
				ETeamGroupType groupType = sceneTeamGroup.GetGroupType();
				SceneTeamRole currentRole = sceneTeamGroup.GetCurrentRole();
				foreach (SceneTeamRole sceneTeamRole in list2)
				{
					long creatureDataId = sceneTeamRole.CreatureDataId;
					if (creatureDataId > 0L)
					{
						int roleId = sceneTeamRole.RoleId;
						bool flag = sceneTeamRole == currentRole;
						SceneTeamItem sceneTeamItem = SceneTeamItem.Create(groupType, num, roleId, creatureDataId);
						this.TeamItems.Add(sceneTeamItem);
						this.PlayerIdSet.Add(num);
						list.Add(creatureDataId);
						if (!sceneTeamItem.IsMyRole())
						{
							sceneTeamItem.SetRemoteIsControl(flag);
						}
						else if (flag)
						{
							goBattleItem = sceneTeamItem;
						}
					}
				}
			}
		}
		if (this.GetTeamItems(true).Count <= 0)
		{
			Singleton<Log>.Instance.Warn(ELogModule.SceneTeam, ELogAuthor.LYY, "刷新出战编队，当前玩家无角色实体", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		Singleton<Log>.Instance.Info(ELogModule.SceneTeam, ELogAuthor.LYY, "刷新出战编队，等待加载开始", default(ReadOnlySpan<ValueTuple<string, object>>));
		this.WaitTask = WaitEntityTask.Create("SceneTeamModel.TeamGoBattle", list, delegate(bool? result)
		{
			if (result == null || !result.Value)
			{
				Singleton<Log>.Instance.Warn(ELogModule.SceneTeam, ELogAuthor.LYY, "刷新出战编队，加载角色失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			Singleton<Log>.Instance.Info(ELogModule.SceneTeam, ELogAuthor.LYY, "刷新出战编队，等待加载结束", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.RefreshLastTransform();
			this.ResetCurrentItem(needInheritState);
			SceneTeamItem goBattleItem = goBattleItem;
			EntityHandle entityHandle = (goBattleItem != null) ? goBattleItem.EntityHandle : null;
			SceneTeamItem currentItem = this.CurrentItem;
			EntityHandle entityHandle2 = (currentItem != null) ? currentItem.EntityHandle : null;
			Singleton<EventSystem>.Instance.Emit<EntityHandle, EntityHandle>(EEventName.OnBeforeUpdateSceneTeam, entityHandle, entityHandle2);
			WorldEntity worldEntity = (entityHandle != null) ? entityHandle.Entity : null;
			if (worldEntity != null && worldEntity.Valid && worldEntity.Active)
			{
				BaseTagComponent component = worldEntity.GetComponent<BaseTagComponent>();
				if (component != null && component.HasAnyTag(new int[]
				{
					GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.前台"],
					GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.前台不受控制"]
				}))
				{
					allowRefreshTransform = false;
				}
			}
			if (goBattleItem != null && goBattleItem.CanControl(false))
			{
				if (entityHandle != null)
				{
					int id = entityHandle.Id;
					int? num2 = (entityHandle2 != null) ? new int?(entityHandle2.Id) : null;
					if (id == num2.GetValueOrDefault() & num2 != null)
					{
						this.CurrentItem = goBattleItem;
						goto IL_1D0;
					}
				}
				if (goBattleItem.GetGroupType() > ETeamGroupType.Default)
				{
					ControllerBase<SceneTeamController>.Instance.SendSwitchRole(goBattleItem);
				}
				ChangeRoleParams @params = new ChangeRoleParams
				{
					UseGoBattleSkill = new bool?(useGoBattleSkill),
					AllowRefreshTransform = new bool?(allowRefreshTransform)
				};
				this.ChangeRole(goBattleItem.GetCreatureDataId(), @params);
				IL_1D0:
				this.TeamGoBattleFinish();
				return;
			}
			Singleton<Log>.Instance.Warn(ELogModule.SceneTeam, ELogAuthor.LYY, "刷新出战编队，当前角色不可上阵", default(ReadOnlySpan<ValueTuple<string, object>>));
			foreach (SceneTeamItem sceneTeamItem2 in this.TeamItems)
			{
				if (sceneTeamItem2.IsMyRole() && sceneTeamItem2.CanControl(false))
				{
					if (goBattleItem != null && goBattleItem.IsDead())
					{
						EntityHandle entityHandle3 = goBattleItem.EntityHandle;
						WorldEntity worldEntity2 = (entityHandle3 != null) ? entityHandle3.Entity : null;
						if (worldEntity2 != null)
						{
							worldEntity2.DisableByKey(EEntityDisableKey.GoDown, true);
							RoleTeamComponent component2 = worldEntity2.GetComponent<RoleTeamComponent>();
							if (component2 != null)
							{
								component2.SetTeamTag(ETeamState.UnderStage);
							}
						}
					}
					RequestChangeRoleParams params2 = new RequestChangeRoleParams
					{
						FilterSameRole = new bool?(false)
					};
					ControllerBase<SceneTeamController>.Instance.RequestChangeRole(sceneTeamItem2.GetCreatureDataId(), params2);
					this.TeamGoBattleFinish();
					return;
				}
			}
			Singleton<Log>.Instance.Warn(ELogModule.SceneTeam, ELogAuthor.LYY, "刷新出战编队，未找到存活角色", default(ReadOnlySpan<ValueTuple<string, object>>));
			if (goBattleItem == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.SceneTeam;
				ELogAuthor author = ELogAuthor.LYY;
				string message = "刷新出战编队，数据错误，当前玩家找不到可上阵角色";
				string item = "CurrentRole";
				object item2;
				if (!this.TeamPlayerMap.ContainsKey(selfPlayerId))
				{
					item2 = null;
				}
				else
				{
					SceneTeamPlayer sceneTeamPlayer2 = this.TeamPlayerMap[selfPlayerId];
					if (sceneTeamPlayer2 == null)
					{
						item2 = null;
					}
					else
					{
						SceneTeamGroup currentGroup = sceneTeamPlayer2.GetCurrentGroup();
						item2 = ((currentGroup != null) ? currentGroup.GetCurrentRole() : null);
					}
				}
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>(item, item2);
				instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				this.TeamGoBattleFinish();
				return;
			}
			ChangeRoleParams params3 = new ChangeRoleParams
			{
				ForceChangeRole = new bool?(true),
				AllowRefreshTransform = new bool?(true)
			};
			this.ChangeRole(goBattleItem.GetCreatureDataId(), params3);
			EntityHandle entityHandle4 = goBattleItem.EntityHandle;
			WorldEntity worldEntity3 = (entityHandle4 != null) ? entityHandle4.Entity : null;
			if (worldEntity3 != null)
			{
				worldEntity3.DisableByKey(EEntityDisableKey.GoDown, true);
			}
			this.TeamGoBattleFinish();
		}, -1, true, false);
	}

	// Token: 0x06015110 RID: 86288 RVA: 0x005D3DE8 File Offset: 0x005D1FE8
	private void ResetCurrentItem(bool needInheritState)
	{
		if (this.CurrentItem == null)
		{
			return;
		}
		EntityHandle entityHandle = this.CurrentItem.EntityHandle;
		WorldEntity worldEntity = (entityHandle != null) ? entityHandle.Entity : null;
		if (worldEntity != null)
		{
			TsBaseCharacter baseCharacter = Global.BaseCharacter;
			if (baseCharacter != null && baseCharacter.IsValid())
			{
				if (needInheritState)
				{
					return;
				}
				SceneTeamPlayer teamPlayerData = this.GetTeamPlayerData(ModelBase<CreatureModel>.Instance.GetPlayerId());
				if (!((teamPlayerData != null) ? new bool?(teamPlayerData.IsRoleOnStageWithoutControl(this.CurrentItem.GetCreatureDataId())) : null).GetValueOrDefault())
				{
					worldEntity.DisableByKey(EEntityDisableKey.GoDown, true);
					RoleTeamComponent component = worldEntity.GetComponent<RoleTeamComponent>();
					if (component != null)
					{
						component.SetTeamTag(ETeamState.UnderStage);
					}
				}
				this.CurrentItem = null;
				return;
			}
		}
		this.CurrentItem = null;
	}

	// Token: 0x06015111 RID: 86289 RVA: 0x005D3E9C File Offset: 0x005D209C
	private void TeamGoBattleFinish()
	{
		if (this.SeamlessUpdateTeamStartTime > 0L && this.TeamGoBattleStartTime > this.SeamlessUpdateTeamStartTime)
		{
			this.FinishSeamlessUpdateTeam();
		}
		this.WaitTask = null;
		this.IsTeamReady = true;
		GameModePromise loadTeamPromise = this.LoadTeamPromise;
		if (loadTeamPromise != null)
		{
			loadTeamPromise.SetResult(true);
		}
		this.LoadTeamPromise = null;
		this.NotifyTeamChange();
		Singleton<Log>.Instance.Info(ELogModule.SceneTeam, ELogAuthor.LYY, "刷新出战编队，结束", default(ReadOnlySpan<ValueTuple<string, object>>));
	}

	// Token: 0x06015112 RID: 86290 RVA: 0x005D3F10 File Offset: 0x005D2110
	private void NotifyTeamChange()
	{
		ETeamGroupType? currentGroupType = this.CurrentGroupType;
		if (currentGroupType == null || SceneTeamDefine.innerGroupType.Contains(currentGroupType.Value))
		{
			return;
		}
		if (!ModelBase<GameModeModel>.Instance.IsMulti && currentGroupType.GetValueOrDefault() == ETeamGroupType.Battle)
		{
			int[] array = this.LastRoleIdList ?? new int[0];
			List<int> list = new List<int>();
			foreach (SceneTeamItem sceneTeamItem in this.GetTeamItems(false))
			{
				list.Add(sceneTeamItem.GetConfigId);
			}
			for (int i = 0; i < 4; i++)
			{
				int num = (i < array.Length) ? array[i] : 0;
				int num2 = (i < list.Count) ? list[i] : 0;
				if (num != num2)
				{
					if (num > 0)
					{
						Singleton<EventSystem>.Instance.Emit<int>(EEventName.RedDotRoleChange, num);
					}
					if (num2 > 0)
					{
						Singleton<EventSystem>.Instance.Emit<int>(EEventName.RedDotRoleChange, num2);
					}
				}
			}
			this.LastRoleIdList = list.ToArray();
		}
		Singleton<EventSystem>.Instance.Emit(EEventName.OnUpdateSceneTeam);
		if (GlobalData.GameInstance != null)
		{
			GlobalData.BpEventManager.当编队更新时.Broadcast();
		}
	}

	// Token: 0x06015113 RID: 86291 RVA: 0x005D4060 File Offset: 0x005D2260
	public void OnAddEntity(EntityHandle handle)
	{
		if (!ModelBase<GameModeModel>.Instance.IsMulti)
		{
			return;
		}
		CreatureDataComponent component = handle.Entity.GetComponent<CreatureDataComponent>();
		if (component.GetEntityType() != EEntityType.Player)
		{
			return;
		}
		long creatureDataId = component.GetCreatureDataId();
		CreatureModel instance = ModelBase<CreatureModel>.Instance;
		foreach (SceneTeamItem sceneTeamItem in this.GetTeamItems(false))
		{
			if (creatureDataId == sceneTeamItem.GetCreatureDataId())
			{
				EntityHandle entity = instance.GetEntity(creatureDataId);
				WorldEntity worldEntity = (entity != null) ? entity.Entity : null;
				ScenePlayerData scenePlayerData = instance.GetScenePlayerData(sceneTeamItem.GetPlayerId());
				bool? flag = (scenePlayerData != null) ? new bool?(scenePlayerData.IsRemoteSceneLoading()) : null;
				if (worldEntity != null && flag.GetValueOrDefault())
				{
					worldEntity.DisableByKey(EEntityDisableKey.GoDown, true);
				}
			}
		}
		if (ModelBase<SceneTeamModel>.Instance.IsTeamReady)
		{
			foreach (SceneTeamItem sceneTeamItem2 in this.TeamItems)
			{
				if (sceneTeamItem2.GetCreatureDataId() == creatureDataId)
				{
					Singleton<Log>.Instance.Info(ELogModule.SceneTeam, ELogAuthor.LYY, "更新联机场景队伍", default(ReadOnlySpan<ValueTuple<string, object>>));
					sceneTeamItem2.UpdateEntityHandle();
					this.NotifyTeamChange();
					break;
				}
			}
		}
	}

	// Token: 0x06015114 RID: 86292 RVA: 0x005D41BC File Offset: 0x005D23BC
	public void OnRemoveEntity(EntityHandle handle)
	{
		WorldEntity entity = handle.Entity;
		long creatureDataId = entity.GetComponent<CreatureDataComponent>().GetCreatureDataId();
		this.PreloadEntitySet.Remove(creatureDataId);
		int id = handle.Id;
		EntityHandle getCurrentEntity = this.GetCurrentEntity;
		int? num = (getCurrentEntity != null) ? new int?(getCurrentEntity.Id) : null;
		if (id == num.GetValueOrDefault() & num != null)
		{
			this.LastEntityIsOnGround = (entity.GetComponent<BaseUnifiedStateComponent>().PositionState == global::ECharPositionState.Ground);
			if (!ModelBase<GameModeModel>.Instance.IsMulti)
			{
				this.RefreshLastTransform();
			}
			this.MarkTeamNotReady();
		}
	}

	// Token: 0x06015115 RID: 86293 RVA: 0x005D424E File Offset: 0x005D244E
	private void MarkTeamNotReady()
	{
		this.IsTeamReady = false;
		if (this.LoadTeamPromise == null)
		{
			this.LoadTeamPromise = new GameModePromise();
		}
	}

	// Token: 0x06015116 RID: 86294 RVA: 0x005D426C File Offset: 0x005D246C
	public void AddPreloadEntity(long creatureDataId)
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.SceneTeam;
		ELogAuthor author = ELogAuthor.LYY;
		string message = "添加预加载角色实体";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("CreatureDataId", creatureDataId);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		this.PreloadEntitySet.Add(creatureDataId);
	}

	// Token: 0x06015117 RID: 86295 RVA: 0x005D42B4 File Offset: 0x005D24B4
	[return: Nullable(new byte[]
	{
		0,
		1
	})]
	public ValueTuple<long, EntityHandle>? GetPreloadEntityData(int roleId)
	{
		int playerId = ModelBase<CreatureModel>.Instance.GetPlayerId();
		foreach (long num in this.PreloadEntitySet)
		{
			EntityHandle entity = ModelBase<CreatureModel>.Instance.GetEntity(num);
			WorldEntity worldEntity = (entity != null) ? entity.Entity : null;
			if (worldEntity != null && worldEntity.Valid)
			{
				CreatureDataComponent component = worldEntity.GetComponent<CreatureDataComponent>();
				if (component != null && component.GetPlayerId() == playerId)
				{
					int roleId2 = component.GetRoleId();
					if (this.IsRoleMatch(roleId2, roleId))
					{
						return new ValueTuple<long, EntityHandle>?(new ValueTuple<long, EntityHandle>(num, entity));
					}
				}
			}
		}
		return null;
	}

	// Token: 0x06015118 RID: 86296 RVA: 0x005D4380 File Offset: 0x005D2580
	private bool IsRoleMatch(int realRoleId, int targetRoleId)
	{
		if (realRoleId == targetRoleId)
		{
			return true;
		}
		if (realRoleId > 100000)
		{
			TrialRoleInfo? config = ConfigTrialRoleInfoById.GetConfig(realRoleId, true);
			if (config != null && config.GetValueOrDefault().GroupId == targetRoleId)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x17001BC0 RID: 7104
	// (get) Token: 0x06015119 RID: 86297 RVA: 0x005D43C6 File Offset: 0x005D25C6
	[Nullable(2)]
	public SceneTeamItem GetCurrentTeamItem
	{
		[NullableContext(2)]
		get
		{
			return this.CurrentItem;
		}
	}

	// Token: 0x17001BC1 RID: 7105
	// (get) Token: 0x0601511A RID: 86298 RVA: 0x005D43CE File Offset: 0x005D25CE
	[Nullable(2)]
	public EntityHandle GetCurrentEntity
	{
		[NullableContext(2)]
		get
		{
			SceneTeamItem currentItem = this.CurrentItem;
			if (currentItem == null)
			{
				return null;
			}
			return currentItem.EntityHandle;
		}
	}

	// Token: 0x17001BC2 RID: 7106
	// (get) Token: 0x0601511B RID: 86299 RVA: 0x005D43E1 File Offset: 0x005D25E1
	[Nullable(2)]
	public UPhysicalMaterial GetPhysMaterial
	{
		[NullableContext(2)]
		get
		{
			return this.PhysMaterial;
		}
	}

	// Token: 0x0601511C RID: 86300 RVA: 0x005D43E9 File Offset: 0x005D25E9
	public int GetTeamLength()
	{
		return this.TeamItems.Count;
	}

	// Token: 0x0601511D RID: 86301 RVA: 0x005D43F6 File Offset: 0x005D25F6
	public int GetTeamPlayerSize()
	{
		return this.PlayerIdSet.Count;
	}

	// Token: 0x0601511E RID: 86302 RVA: 0x005D4404 File Offset: 0x005D2604
	[return: Nullable(2)]
	public SceneTeamItem GetTeamItem(long param, IGetTeamItemOptions options)
	{
		foreach (SceneTeamItem sceneTeamItem in this.TeamItems)
		{
			if (this.IsItemMatch(sceneTeamItem, param, options))
			{
				return sceneTeamItem;
			}
		}
		return null;
	}

	// Token: 0x0601511F RID: 86303 RVA: 0x005D4464 File Offset: 0x005D2664
	private bool IsItemMatch(SceneTeamItem item, long param, IGetTeamItemOptions options)
	{
		if (options.OnlyMyRole.GetValueOrDefault() && !item.IsMyRole())
		{
			return false;
		}
		if (options.IsControl.GetValueOrDefault() && !item.IsControl())
		{
			return false;
		}
		switch (options.ParamType)
		{
		case ETeamParamType.ConfigId:
			return (long)item.GetConfigId == param;
		case ETeamParamType.EntityId:
		{
			EntityHandle entityHandle = item.EntityHandle;
			int? num = (entityHandle != null) ? new int?(entityHandle.Id) : null;
			long? num2 = (num != null) ? new long?((long)num.GetValueOrDefault()) : null;
			return num2.GetValueOrDefault() == param & num2 != null;
		}
		case ETeamParamType.PlayerId:
			return (long)item.GetPlayerId() == param;
		case ETeamParamType.CreatureDataId:
			return item.GetCreatureDataId() == param;
		default:
			return false;
		}
	}

	// Token: 0x06015120 RID: 86304 RVA: 0x005D4540 File Offset: 0x005D2740
	public List<SceneTeamItem> GetTeamItems(bool onlyMyRole = false)
	{
		List<SceneTeamItem> list = new List<SceneTeamItem>();
		foreach (SceneTeamItem sceneTeamItem in this.TeamItems)
		{
			if (!onlyMyRole || sceneTeamItem.IsMyRole())
			{
				list.Add(sceneTeamItem);
			}
		}
		return list;
	}

	// Token: 0x06015121 RID: 86305 RVA: 0x005D45A8 File Offset: 0x005D27A8
	public List<SceneTeamItem> GetTeamItemsByPlayer(int playerId)
	{
		List<SceneTeamItem> list = new List<SceneTeamItem>();
		foreach (SceneTeamItem sceneTeamItem in this.TeamItems)
		{
			if (sceneTeamItem.GetPlayerId() == playerId)
			{
				list.Add(sceneTeamItem);
			}
		}
		return list;
	}

	// Token: 0x06015122 RID: 86306 RVA: 0x005D460C File Offset: 0x005D280C
	public List<int> GetTeamRoleConfigIdList(bool onlyMyRole = false, bool getBaseRoleId = false)
	{
		List<int> list = new List<int>();
		foreach (SceneTeamItem sceneTeamItem in this.TeamItems)
		{
			if (!onlyMyRole || sceneTeamItem.IsMyRole())
			{
				if (!getBaseRoleId)
				{
					list.Add(sceneTeamItem.GetConfigId);
				}
				else
				{
					list.Add(ConfigBase<RoleConfig>.Instance.GetBaseRoleId(sceneTeamItem.GetConfigId));
				}
			}
		}
		return list;
	}

	// Token: 0x06015123 RID: 86307 RVA: 0x005D4694 File Offset: 0x005D2894
	public List<EntityHandle> GetTeamEntities(bool onlyMyRole = false)
	{
		List<EntityHandle> list = new List<EntityHandle>();
		foreach (SceneTeamItem sceneTeamItem in this.TeamItems)
		{
			if (!onlyMyRole || sceneTeamItem.IsMyRole())
			{
				EntityHandle entityHandle = sceneTeamItem.EntityHandle;
				if (entityHandle != null)
				{
					list.Add(entityHandle);
				}
			}
		}
		return list;
	}

	// Token: 0x06015124 RID: 86308 RVA: 0x005D4704 File Offset: 0x005D2904
	public List<EntityHandle> GetAllGroupEntities(int playerId)
	{
		List<EntityHandle> list = new List<EntityHandle>();
		SceneTeamPlayer sceneTeamPlayer = this.TeamPlayerMap.ContainsKey(playerId) ? this.TeamPlayerMap[playerId] : null;
		if (sceneTeamPlayer == null)
		{
			return list;
		}
		CreatureModel instance = ModelBase<CreatureModel>.Instance;
		foreach (SceneTeamGroup sceneTeamGroup in sceneTeamPlayer.GetGroupList())
		{
			foreach (SceneTeamRole sceneTeamRole in sceneTeamGroup.GetRoleList())
			{
				EntityHandle entity = instance.GetEntity(sceneTeamRole.CreatureDataId);
				if (entity != null && entity.IsInit)
				{
					list.Add(entity);
				}
			}
		}
		return list;
	}

	// Token: 0x06015125 RID: 86309 RVA: 0x005D47E0 File Offset: 0x005D29E0
	public List<SceneTeamItem> GetTeamItemsInRange(global::Vector location, float distance)
	{
		List<SceneTeamItem> list = new List<SceneTeamItem>();
		float num = distance * distance;
		foreach (SceneTeamItem sceneTeamItem in this.TeamItems)
		{
			EntityHandle entityHandle = sceneTeamItem.EntityHandle;
			if (((entityHandle != null) ? entityHandle.Entity : null) != null)
			{
				ScenePlayerData scenePlayerData = ModelBase<CreatureModel>.Instance.GetScenePlayerData(sceneTeamItem.GetPlayerId());
				global::Vector vector = (scenePlayerData != null) ? scenePlayerData.GetLocation() : null;
				if (vector != null && global::Vector.DistSquared(location, vector) <= (double)num)
				{
					list.Add(sceneTeamItem);
				}
			}
		}
		return list;
	}

	// Token: 0x06015126 RID: 86310 RVA: 0x005D4880 File Offset: 0x005D2A80
	[NullableContext(2)]
	public SceneTeamPlayer GetTeamPlayerData(int playerId)
	{
		if (!this.TeamPlayerMap.ContainsKey(playerId))
		{
			return null;
		}
		return this.TeamPlayerMap[playerId];
	}

	// Token: 0x06015127 RID: 86311 RVA: 0x005D48A0 File Offset: 0x005D2AA0
	public bool HasPhantomRole()
	{
		foreach (SceneTeamItem sceneTeamItem in this.GetTeamItems(true))
		{
			RoleInfo? roleConfig = ConfigBase<RoleConfig>.Instance.GetRoleConfig(sceneTeamItem.GetConfigId);
			if (roleConfig != null && roleConfig.GetValueOrDefault().RoleType == 2)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06015128 RID: 86312 RVA: 0x005D4928 File Offset: 0x005D2B28
	[NullableContext(2)]
	public void ChangeRole(long creatureDataId, IChangeRoleParams @params = null)
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.SceneTeam;
		ELogAuthor author = ELogAuthor.LYY;
		string message = "开始切换角色";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("CreatureDataId", creatureDataId);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		SceneTeamItem teamItem = this.GetTeamItem(creatureDataId, new GetTeamItemOptions
		{
			ParamType = ETeamParamType.CreatureDataId
		});
		if (teamItem == null || !teamItem.IsMyRole())
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.SceneTeam;
			ELogAuthor author2 = ELogAuthor.LYY;
			string message2 = "队伍实例不存在或非本机角色";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("CreatureDataId", creatureDataId);
			instance2.Warn(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			return;
		}
		bool valueOrDefault = ((@params != null) ? @params.ForceChangeRole : null).GetValueOrDefault();
		if (!teamItem.CanControl(valueOrDefault))
		{
			Log instance3 = Singleton<Log>.Instance;
			ELogModule module3 = ELogModule.SceneTeam;
			ELogAuthor author3 = ELogAuthor.LYY;
			string message3 = "角色不允许操控";
			ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("CreatureDataId", creatureDataId);
			instance3.Warn(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
			return;
		}
		SceneTeamItem getCurrentTeamItem = this.GetCurrentTeamItem;
		EntityHandle entityHandle = (getCurrentTeamItem != null) ? getCurrentTeamItem.EntityHandle : null;
		EntityHandle entityHandle2 = teamItem.EntityHandle;
		if (entityHandle2 == null)
		{
			Log instance4 = Singleton<Log>.Instance;
			ELogModule module4 = ELogModule.SceneTeam;
			ELogAuthor author4 = ELogAuthor.LYY;
			string message4 = "角色实体无效";
			ValueTuple<string, object> valueTuple4 = new ValueTuple<string, object>("CreatureDataId", creatureDataId);
			instance4.Warn(module4, author4, message4, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple4));
			return;
		}
		WorldEntity entity = entityHandle2.Entity;
		CreatureDataComponent creatureDataComponent = (entity != null) ? entity.GetComponent<CreatureDataComponent>() : null;
		if (creatureDataComponent == null || creatureDataComponent.GetRemoveState())
		{
			Log instance5 = Singleton<Log>.Instance;
			ELogModule module5 = ELogModule.SceneTeam;
			ELogAuthor author5 = ELogAuthor.HYJ;
			string message5 = "角色实体删除中";
			ValueTuple<string, object> valueTuple5 = new ValueTuple<string, object>("CreatureDataId", creatureDataId);
			instance5.Warn(module5, author5, message5, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple5));
		}
		int? id = ModelBase<PlayerInfoModel>.Instance.GetId();
		if (this.TeamPlayerMap.ContainsKey(id.Value))
		{
			SceneTeamGroup currentGroup = this.TeamPlayerMap[id.Value].GetCurrentGroup();
			if (currentGroup != null)
			{
				currentGroup.SetCurrentRole(teamItem.GetCreatureDataId());
			}
		}
		this.CurrentItem = teamItem;
		Singleton<EventSystem>.Instance.Emit<EntityHandle, EntityHandle>(EEventName.OnBeforeChangeRole, entityHandle2, entityHandle);
		bool valueOrDefault2 = ((@params != null) ? @params.UseGoBattleSkill : null).GetValueOrDefault();
		double valueOrDefault3 = ((@params != null) ? @params.CoolDown : null).GetValueOrDefault();
		bool valueOrDefault4 = ((@params != null) ? @params.GoDownWaitSkillEnd : null).GetValueOrDefault();
		bool? flag = (@params != null) ? @params.AllowRefreshTransform : null;
		bool? flag2;
		if (flag == null)
		{
			WorldEntity entity2 = entityHandle2.Entity;
			flag2 = ((entity2 != null) ? new bool?(!entity2.Active) : null);
		}
		else
		{
			flag2 = flag;
		}
		bool? flag3 = flag2;
		bool valueOrDefault5 = ((@params != null) ? @params.ForceInheritTransform : null).GetValueOrDefault(true);
		RoleTeamComponent.OnChangeRole(entityHandle, entityHandle2, valueOrDefault2, valueOrDefault3, valueOrDefault4, flag3.GetValueOrDefault(), valueOrDefault5);
		if (entityHandle != null)
		{
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnRoleGoDown, entityHandle.Id);
		}
		Singleton<EventSystem>.Instance.Emit<EntityHandle, EntityHandle>(EEventName.OnChangeRole, entityHandle2, entityHandle);
	}

	// Token: 0x06015129 RID: 86313 RVA: 0x005D4C04 File Offset: 0x005D2E04
	public void OtherPlayerChangeRole(int playerId, long newCreatureDataId)
	{
		if (this.TeamPlayerMap.ContainsKey(playerId))
		{
			SceneTeamGroup currentGroup = this.TeamPlayerMap[playerId].GetCurrentGroup();
			if (currentGroup == null)
			{
				return;
			}
			currentGroup.SetCurrentRole(newCreatureDataId);
		}
	}

	// Token: 0x0601512A RID: 86314 RVA: 0x005D4C30 File Offset: 0x005D2E30
	public void RefreshLastTransform()
	{
		EntityHandle getCurrentEntity = this.GetCurrentEntity;
		if (getCurrentEntity == null || !getCurrentEntity.Valid)
		{
			return;
		}
		AActor actor = ControllerBase<CharacterController>.Instance.GetActor(getCurrentEntity);
		if (actor == null || !actor.IsValid())
		{
			return;
		}
		FTransformDouble value = actor.D_GetTransform();
		this.LastTransform = new FTransformDouble?(value);
	}

	// Token: 0x0601512B RID: 86315 RVA: 0x005D4C87 File Offset: 0x005D2E87
	public void SetLastTransform(FTransformDouble? transform)
	{
		this.LastTransform = transform;
	}

	// Token: 0x0601512C RID: 86316 RVA: 0x005D4C90 File Offset: 0x005D2E90
	public FTransformDouble? GetSpawnTransform()
	{
		FTransformDouble? lastTransform = this.LastTransform;
		if (lastTransform != null)
		{
			return lastTransform;
		}
		EntityHandle getCurrentEntity = this.GetCurrentEntity;
		if (getCurrentEntity != null && getCurrentEntity.Valid)
		{
			return new FTransformDouble?(getCurrentEntity.Entity.GetComponent<CharacterActorComponent>().Actor.D_GetTransform());
		}
		UWorld world = GlobalData.World;
		if (world != null)
		{
			FVectorDouble? fvectorDouble = null;
			FRotator? frotator = null;
			EBornMode ebornMode = UiBlueprintFunctionLibrary.TestSceneLoadBornMode();
			if (ebornMode == EBornMode.PlayLocationCurrentCameraLocation)
			{
				fvectorDouble = new FVectorDouble?(UiBlueprintFunctionLibrary.TempLocation.ToUeVector(false));
				FRotator value = UiBlueprintFunctionLibrary.TempRotator.ToUeRotator();
				value.Roll = 0f;
				value.Pitch = 0f;
				frotator = new FRotator?(value);
			}
			else if (ebornMode == EBornMode.PlayLocationDefaultPlayerStart)
			{
				TArray<AActor> tarray = new TArray<AActor>();
				UGameplayStatics.GetAllActorsOfClass(world, APlayerStart.StaticClass(), ref tarray);
				FTransformDouble ftransformDouble = tarray.Get(0).D_GetTransform();
				fvectorDouble = new FVectorDouble?(ftransformDouble.GetLocation());
				frotator = new FRotator?(ftransformDouble.Rotator());
			}
			return new FTransformDouble?(UKismetMathLibrary.MakeTransformDouble(fvectorDouble.Value, frotator.Value, new FVector(1f, 1f, 1f)));
		}
		return null;
	}

	// Token: 0x0601512D RID: 86317 RVA: 0x005D4DC4 File Offset: 0x005D2FC4
	public double GetChangeRoleCooldown()
	{
		return this.ChangeRoleCooldown;
	}

	// Token: 0x0601512E RID: 86318 RVA: 0x005D4DCC File Offset: 0x005D2FCC
	public void ResetChangeRoleCooldown()
	{
		this.ChangeRoleCooldown = this.DefaultChangeRoleCooldown;
	}

	// Token: 0x0601512F RID: 86319 RVA: 0x005D4DDA File Offset: 0x005D2FDA
	public void UpdateChangeRoleCooldown(float time)
	{
		this.ChangeRoleCooldown = (double)time;
	}

	// Token: 0x06015130 RID: 86320 RVA: 0x005D4DE4 File Offset: 0x005D2FE4
	public unsafe void RoleDeathEnded(int entityId)
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.SceneTeam;
		ELogAuthor author = ELogAuthor.LYY;
		string message = "开始执行队伍角色死亡逻辑";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("EntityId", entityId);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		SceneTeamItem teamItem = this.GetTeamItem((long)entityId, new GetTeamItemOptions
		{
			ParamType = ETeamParamType.EntityId
		});
		WorldEntity worldEntity;
		if (teamItem == null)
		{
			worldEntity = null;
		}
		else
		{
			EntityHandle entityHandle = teamItem.EntityHandle;
			worldEntity = ((entityHandle != null) ? entityHandle.Entity : null);
		}
		WorldEntity worldEntity2 = worldEntity;
		if (worldEntity2 == null)
		{
			Singleton<Log>.Instance.Info(ELogModule.SceneTeam, ELogAuthor.LYY, "无法获取死亡角色Entity", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		ETeamGroupType groupType = teamItem.GetGroupType();
		int playerId = teamItem.GetPlayerId();
		SceneTeamGroup sceneTeamGroup;
		if (!this.TeamPlayerMap.ContainsKey(playerId))
		{
			sceneTeamGroup = null;
		}
		else
		{
			SceneTeamPlayer sceneTeamPlayer = this.TeamPlayerMap[playerId];
			sceneTeamGroup = ((sceneTeamPlayer != null) ? sceneTeamPlayer.GetCurrentGroup() : null);
		}
		SceneTeamGroup sceneTeamGroup2 = sceneTeamGroup;
		if (sceneTeamGroup2 == null || groupType != sceneTeamGroup2.GetGroupType())
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.SceneTeam;
			ELogAuthor author2 = ELogAuthor.LYY;
			string message2 = "死亡角色非玩家当前编队";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("DeadGroupType", groupType);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("CurrentGroupType", (sceneTeamGroup2 != null) ? new ETeamGroupType?(sceneTeamGroup2.GetGroupType()) : null);
			instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return;
		}
		if (sceneTeamGroup2.GetLivingState() == ETeamLivingState.Dead || teamItem.IsAutoRole())
		{
			Singleton<Log>.Instance.Info(ELogModule.SceneTeam, ELogAuthor.LYY, "隐藏死亡角色", default(ReadOnlySpan<ValueTuple<string, object>>));
			worldEntity2.DisableByKey(EEntityDisableKey.GoDown, true);
			return;
		}
		CharacterActorComponent component = worldEntity2.GetComponent<CharacterActorComponent>();
		if (component == null || !component.IsAutonomousProxy)
		{
			Singleton<Log>.Instance.Info(ELogModule.SceneTeam, ELogAuthor.LYY, "非逻辑主控死亡不进行切人", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		SceneTeamItem getCurrentTeamItem = this.GetCurrentTeamItem;
		if (getCurrentTeamItem == null)
		{
			Singleton<Log>.Instance.Info(ELogModule.SceneTeam, ELogAuthor.LYY, "死亡时编队无当前角色", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		if (!getCurrentTeamItem.IsDead())
		{
			Singleton<Log>.Instance.Info(ELogModule.SceneTeam, ELogAuthor.LYY, "当前角色未死亡", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		foreach (SceneTeamItem sceneTeamItem in this.GetTeamItems(true))
		{
			if (sceneTeamItem.CanControl(false))
			{
				long creatureDataId = sceneTeamItem.GetCreatureDataId();
				Log instance3 = Singleton<Log>.Instance;
				ELogModule module3 = ELogModule.SceneTeam;
				ELogAuthor author3 = ELogAuthor.LYY;
				string message3 = "前台角色死亡进行切人";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("CreatureDataId", creatureDataId);
				instance3.Info(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				RequestChangeRoleParams @params = new RequestChangeRoleParams
				{
					GoBattleInvincible = new bool?(true)
				};
				ControllerBase<SceneTeamController>.Instance.RequestChangeRole(creatureDataId, @params);
				break;
			}
		}
	}

	// Token: 0x06015131 RID: 86321 RVA: 0x005D5090 File Offset: 0x005D3290
	public bool IsAllDid()
	{
		using (List<SceneTeamItem>.Enumerator enumerator = this.TeamItems.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (!enumerator.Current.IsDead())
				{
					return false;
				}
			}
		}
		return true;
	}

	// Token: 0x06015132 RID: 86322 RVA: 0x005D50EC File Offset: 0x005D32EC
	public ETeamLivingState GetCurrentGroupLivingState(int playerId)
	{
		SceneTeamGroup sceneTeamGroup;
		if (!this.TeamPlayerMap.ContainsKey(playerId))
		{
			sceneTeamGroup = null;
		}
		else
		{
			SceneTeamPlayer sceneTeamPlayer = this.TeamPlayerMap[playerId];
			sceneTeamGroup = ((sceneTeamPlayer != null) ? sceneTeamPlayer.GetCurrentGroup() : null);
		}
		SceneTeamGroup sceneTeamGroup2 = sceneTeamGroup;
		if (sceneTeamGroup2 == null)
		{
			return ETeamLivingState.Unknown;
		}
		return sceneTeamGroup2.GetLivingState();
	}

	// Token: 0x06015133 RID: 86323 RVA: 0x005D5130 File Offset: 0x005D3330
	public ETeamLivingState GetGroupLivingState(int playerId, ETeamGroupType groupType)
	{
		SceneTeamGroup sceneTeamGroup;
		if (!this.TeamPlayerMap.ContainsKey(playerId))
		{
			sceneTeamGroup = null;
		}
		else
		{
			SceneTeamPlayer sceneTeamPlayer = this.TeamPlayerMap[playerId];
			sceneTeamGroup = ((sceneTeamPlayer != null) ? sceneTeamPlayer.GetGroup(groupType) : null);
		}
		SceneTeamGroup sceneTeamGroup2 = sceneTeamGroup;
		if (sceneTeamGroup2 == null)
		{
			return ETeamLivingState.Unknown;
		}
		return sceneTeamGroup2.GetLivingState();
	}

	// Token: 0x06015134 RID: 86324 RVA: 0x005D5174 File Offset: 0x005D3374
	public void InitializeOfflineSceneTeam(int aConfigId, int bConfigId, int cConfigId)
	{
		if (AActor.GetKuroNetMode() == EKuroNetMode.KNM_Net)
		{
			return;
		}
		long[] array = new long[]
		{
			ControllerBase<CreatureController>.Instance.GenUniqueId(),
			ControllerBase<CreatureController>.Instance.GenUniqueId(),
			ControllerBase<CreatureController>.Instance.GenUniqueId()
		};
		int num = 100003;
		int[] array2 = new int[]
		{
			(aConfigId > 0) ? aConfigId : num,
			(bConfigId > 0) ? bConfigId : num,
			(cConfigId > 0) ? cConfigId : num
		};
		FTransformDouble? spawnTransform = this.GetSpawnTransform();
		if (spawnTransform == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.SceneTeam, ELogAuthor.LYY, "初始化失败队伍失败，GetSpawnTransform为空。", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		List<SceneTeamRole> groupRoleList = new List<SceneTeamRole>();
		int num2 = array2.Length;
		int loadCount = num2;
		for (int i = 1; i <= num2; i++)
		{
			long num3 = array[i - 1];
			int playerId = ModelBase<CreatureModel>.Instance.GetPlayerId();
			int roleId = array2[i - 1];
			EntityPb entityPb = EntityPb.Create();
			entityPb.Id = Singleton<MathUtils>.Instance.NumberToLong(num3);
			entityPb.Pos = WorldGlobal.ToTsVector(spawnTransform.Value.GetLocation());
			entityPb.Rot = WorldGlobal.ToTsRotator(spawnTransform.Value.GetRotation().Rotator());
			entityPb.IsVisible = true;
			entityPb.PlayerId = ModelBase<CreatureModel>.Instance.GetPlayerId();
			entityPb.EntityType = 0;
			entityPb.ConfigType = EntityConfigType.Character;
			entityPb.ConfigId = array2[i - 1];
			EntityHandle entityHandle = ControllerBase<CreatureController>.Instance.CreateEntity(entityPb, "InitializeOfflineSceneTeam");
			SceneTeamRole sceneTeamRole = new SceneTeamRole();
			sceneTeamRole.CreatureDataId = num3;
			sceneTeamRole.RoleId = roleId;
			groupRoleList.Add(sceneTeamRole);
			ControllerBase<CreatureController>.Instance.LoadEntityAsync(entityHandle, delegate(ELoadResultType result)
			{
				if (result == ELoadResultType.None)
				{
					return;
				}
				int loadCount = loadCount;
				loadCount--;
				EntityHandle entityHandle = entityHandle;
				WorldEntity worldEntity = (entityHandle != null) ? entityHandle.Entity : null;
				if (worldEntity != null)
				{
					RoleTeamComponent roleTeamComponent = worldEntity.CheckGetComponent<RoleTeamComponent>();
					if (roleTeamComponent != null)
					{
						roleTeamComponent.SetTeamTag(ETeamState.UnderStage);
					}
					worldEntity.DisableByKey(EEntityDisableKey.GoDown, true);
				}
				if (loadCount == 0)
				{
					UpdateGroupParams @params = new UpdateGroupParams
					{
						GroupType = ETeamGroupType.Battle,
						GroupRoleList = groupRoleList,
						CurrentRoleId = groupRoleList[0].RoleId
					};
					this.UpdateGroupData(playerId, @params);
					this.SwitchGroup(playerId, ETeamGroupType.Battle, false, false);
				}
			}, false);
		}
	}

	// Token: 0x0400A231 RID: 41521
	[Nullable(2)]
	private Stat OnChangeRoleStat;

	// Token: 0x0400A232 RID: 41522
	private readonly Dictionary<int, SceneTeamPlayer> TeamPlayerMap = new Dictionary<int, SceneTeamPlayer>();

	// Token: 0x0400A233 RID: 41523
	private readonly List<SceneTeamItem> TeamItems = new List<SceneTeamItem>();

	// Token: 0x0400A234 RID: 41524
	private readonly HashSet<int> PlayerIdSet = new HashSet<int>();

	// Token: 0x0400A235 RID: 41525
	private readonly HashSet<long> PreloadEntitySet = new HashSet<long>();

	// Token: 0x0400A236 RID: 41526
	public ETeamGroupType? CurrentGroupType;

	// Token: 0x0400A237 RID: 41527
	[Nullable(2)]
	private WaitEntityTask WaitTask;

	// Token: 0x0400A238 RID: 41528
	[Nullable(2)]
	private int[] LastRoleIdList;

	// Token: 0x0400A239 RID: 41529
	private long TeamGoBattleStartTime;

	// Token: 0x0400A23A RID: 41530
	[Nullable(2)]
	private SceneTeamItem CurrentItem;

	// Token: 0x0400A23B RID: 41531
	public bool IsTeamReady;

	// Token: 0x0400A23C RID: 41532
	public bool IsPhantomTeam;

	// Token: 0x0400A23D RID: 41533
	public int PanelQteHandleId;

	// Token: 0x0400A23E RID: 41534
	public readonly HashSet<int> PanelQteRoleIdSet = new HashSet<int>();

	// Token: 0x0400A23F RID: 41535
	public bool PanelQteShowTrialRoleTips;

	// Token: 0x0400A240 RID: 41536
	private double ChangeRoleCooldown;

	// Token: 0x0400A241 RID: 41537
	private double DefaultChangeRoleCooldown;

	// Token: 0x0400A242 RID: 41538
	private FTransformDouble? LastTransform;

	// Token: 0x0400A243 RID: 41539
	public bool LastEntityIsOnGround = true;

	// Token: 0x0400A244 RID: 41540
	[Nullable(2)]
	public GameModePromise LoadTeamPromise;

	// Token: 0x0400A245 RID: 41541
	[Nullable(2)]
	private UPhysicalMaterial PhysMaterial;

	// Token: 0x0400A246 RID: 41542
	private long ChangingRoleTime;

	// Token: 0x0400A247 RID: 41543
	private bool RequestingChangeRole;

	// Token: 0x0400A248 RID: 41544
	public bool IsSeamlessUpdateTeam;

	// Token: 0x0400A249 RID: 41545
	public long SeamlessUpdateTeamStartTime;

	// Token: 0x0400A24A RID: 41546
	public bool IsSeamlessUpdateTeamBlockInput;

	// Token: 0x0400A24B RID: 41547
	[Nullable(2)]
	public EntityHandle SeamlessDelayRemoveEntityHandle;

	// Token: 0x0400A24C RID: 41548
	[Nullable(2)]
	public TimerHandle SeamlessWaitUpdateTeamTimer;
}
