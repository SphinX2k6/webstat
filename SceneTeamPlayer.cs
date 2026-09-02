using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Module.Plot;

// Token: 0x02002954 RID: 10580
[NullableContext(1)]
[Nullable(0)]
public class SceneTeamPlayer
{
	// Token: 0x06015085 RID: 86149 RVA: 0x005D2379 File Offset: 0x005D0579
	public static SceneTeamPlayer Create(int playerId)
	{
		return new SceneTeamPlayer
		{
			PlayerId = playerId
		};
	}

	// Token: 0x06015086 RID: 86150 RVA: 0x005D2388 File Offset: 0x005D0588
	public void Clear()
	{
		this.CurrentGroupType = null;
		foreach (SceneTeamGroup sceneTeamGroup in this.GroupMap.Values)
		{
			sceneTeamGroup.Clear();
		}
		this.GroupMap.Clear();
	}

	// Token: 0x06015087 RID: 86151 RVA: 0x005D23F4 File Offset: 0x005D05F4
	public ETeamGroupType? GetCurrentGroupType()
	{
		return this.CurrentGroupType;
	}

	// Token: 0x06015088 RID: 86152 RVA: 0x005D23FC File Offset: 0x005D05FC
	[NullableContext(2)]
	public SceneTeamGroup GetCurrentGroup()
	{
		if (this.CurrentGroupType == null)
		{
			return null;
		}
		if (!this.GroupMap.ContainsKey(this.CurrentGroupType.Value))
		{
			return null;
		}
		return this.GroupMap[this.CurrentGroupType.Value];
	}

	// Token: 0x06015089 RID: 86153 RVA: 0x005D2448 File Offset: 0x005D0648
	[NullableContext(2)]
	public SceneTeamGroup GetGroup(ETeamGroupType groupType)
	{
		if (!this.GroupMap.ContainsKey(groupType))
		{
			return null;
		}
		return this.GroupMap[groupType];
	}

	// Token: 0x0601508A RID: 86154 RVA: 0x005D2468 File Offset: 0x005D0668
	public List<SceneTeamGroup> GetGroupList()
	{
		List<SceneTeamGroup> list = new List<SceneTeamGroup>();
		foreach (SceneTeamGroup item in this.GroupMap.Values)
		{
			list.Add(item);
		}
		return list;
	}

	// Token: 0x0601508B RID: 86155 RVA: 0x005D24C8 File Offset: 0x005D06C8
	public void SwitchGroup(ETeamGroupType groupType)
	{
		this.CurrentGroupType = new ETeamGroupType?(groupType);
	}

	// Token: 0x0601508C RID: 86156 RVA: 0x005D24D8 File Offset: 0x005D06D8
	public void UpdateGroup(ETeamGroupType groupType, IList<SceneTeamRole> groupRoleList, int currentRoleId, ETeamLivingState livingState, bool isFixedLocation)
	{
		SceneTeamGroup sceneTeamGroup = this.GroupMap.ContainsKey(groupType) ? this.GroupMap[groupType] : null;
		if (sceneTeamGroup == null)
		{
			sceneTeamGroup = SceneTeamGroup.Create(this.PlayerId, groupType);
			this.GroupMap[groupType] = sceneTeamGroup;
		}
		sceneTeamGroup.Update(groupRoleList, currentRoleId, livingState, isFixedLocation);
	}

	// Token: 0x0601508D RID: 86157 RVA: 0x005D252C File Offset: 0x005D072C
	public void RefreshEntityEnable()
	{
		HashSet<long> hashSet = new HashSet<long>();
		HashSet<long> hashSet2 = new HashSet<long>();
		foreach (SceneTeamGroup sceneTeamGroup in this.GroupMap.Values)
		{
			foreach (SceneTeamRole sceneTeamRole in sceneTeamGroup.GetRoleList())
			{
				long creatureDataId = sceneTeamRole.CreatureDataId;
				if (creatureDataId > 0L)
				{
					hashSet2.Add(creatureDataId);
				}
			}
			SceneTeamRole currentRole = sceneTeamGroup.GetCurrentRole();
			ETeamGroupType groupType = sceneTeamGroup.GetGroupType();
			ETeamGroupType? currentGroupType = this.CurrentGroupType;
			if (!(groupType == currentGroupType.GetValueOrDefault() & currentGroupType != null) && currentRole != null && currentRole.OnStageWithoutControl)
			{
				hashSet.Add(currentRole.CreatureDataId);
			}
		}
		if (hashSet2.Count <= 0)
		{
			return;
		}
		bool inSeamlessFormation = ModelBase<PlotModel>.Instance.InSeamlessFormation;
		int playerId = this.PlayerId;
		int? id = ModelBase<PlayerInfoModel>.Instance.GetId();
		bool flag = playerId == id.GetValueOrDefault() & id != null;
		ScenePlayerData scenePlayerData = ModelBase<CreatureModel>.Instance.GetScenePlayerData(this.PlayerId);
		bool flag2 = scenePlayerData == null || scenePlayerData.IsRemoteSceneLoading();
		SceneTeamModel instance = ModelBase<SceneTeamModel>.Instance;
		bool isSeamlessUpdateTeam = instance.IsSeamlessUpdateTeam;
		SceneTeamItem getCurrentTeamItem = instance.GetCurrentTeamItem;
		long num = (getCurrentTeamItem != null) ? getCurrentTeamItem.GetCreatureDataId() : 0L;
		SceneTeamGroup currentGroup = this.GetCurrentGroup();
		long? num2;
		if (currentGroup == null)
		{
			num2 = null;
		}
		else
		{
			SceneTeamRole currentRole2 = currentGroup.GetCurrentRole();
			num2 = ((currentRole2 != null) ? new long?(currentRole2.CreatureDataId) : null);
		}
		long? num3 = num2;
		long valueOrDefault = num3.GetValueOrDefault();
		foreach (long num4 in hashSet2)
		{
			EntityHandle entity = ModelBase<CreatureModel>.Instance.GetEntity(num4);
			if (entity == null || !entity.Valid)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Formation;
				ELogAuthor author = ELogAuthor.LYY;
				string message = "更新编队实体时无法获取";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("CreatureDataId", num4);
				instance2.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			else
			{
				WorldEntity entity2 = entity.Entity;
				if (inSeamlessFormation)
				{
					this.SetEntityEnable(entity2, false);
				}
				else
				{
					CreatureDataComponent component = entity2.GetComponent<CreatureDataComponent>();
					BaseDeathComponent component2 = entity2.GetComponent<BaseDeathComponent>();
					if (entity2.IsInit ? component2.IsDead() : (component.GetLivingStatus().GetValueOrDefault() == LivingStatus.Dead))
					{
						this.SetEntityEnable(entity2, false);
					}
					else if (!flag)
					{
						bool enable = num4 == valueOrDefault && !flag2;
						this.SetEntityEnable(entity2, enable);
					}
					else if (component.IsAutoRole())
					{
						bool enable2 = currentGroup != null && currentGroup.HasRole(num4);
						this.SetEntityEnable(entity2, enable2);
					}
					else
					{
						bool flag3 = hashSet.Contains(num4);
						bool enable3 = num4 == num || (num4 == valueOrDefault && !isSeamlessUpdateTeam) || flag3;
						this.SetEntityEnable(entity2, enable3);
						if (flag3)
						{
							RoleTeamComponent component3 = entity2.GetComponent<RoleTeamComponent>();
							if (component3 != null)
							{
								component3.OutOfControl();
							}
						}
					}
				}
			}
		}
	}

	// Token: 0x0601508E RID: 86158 RVA: 0x005D2884 File Offset: 0x005D0A84
	public bool IsRoleOnStageWithoutControl(long creatureDataId)
	{
		foreach (SceneTeamGroup sceneTeamGroup in this.GroupMap.Values)
		{
			SceneTeamRole currentRole = sceneTeamGroup.GetCurrentRole();
			if (currentRole != null && currentRole.CreatureDataId == creatureDataId && currentRole.OnStageWithoutControl)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x0601508F RID: 86159 RVA: 0x005D28F8 File Offset: 0x005D0AF8
	private void SetEntityEnable(Entity entity, bool enable)
	{
		if (enable)
		{
			entity.GetComponent<CreatureDataComponent>().SetVisible(true);
			entity.EnableByKey(EEntityDisableKey.GoDown, true);
			return;
		}
		entity.DisableByKey(EEntityDisableKey.GoDown, true);
		RoleTeamComponent component = entity.GetComponent<RoleTeamComponent>();
		if (component == null)
		{
			return;
		}
		component.SetTeamTag(ETeamState.UnderStage);
	}

	// Token: 0x0400A1DF RID: 41439
	private int PlayerId;

	// Token: 0x0400A1E0 RID: 41440
	private ETeamGroupType? CurrentGroupType;

	// Token: 0x0400A1E1 RID: 41441
	private readonly Dictionary<ETeamGroupType, SceneTeamGroup> GroupMap = new Dictionary<ETeamGroupType, SceneTeamGroup>();
}
