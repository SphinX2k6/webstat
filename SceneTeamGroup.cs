using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;

// Token: 0x02002955 RID: 10581
[NullableContext(1)]
[Nullable(0)]
public class SceneTeamGroup
{
	// Token: 0x06015091 RID: 86161 RVA: 0x005D293E File Offset: 0x005D0B3E
	public static SceneTeamGroup Create(int playerId, ETeamGroupType type)
	{
		return new SceneTeamGroup
		{
			PlayerId = playerId,
			GroupType = type
		};
	}

	// Token: 0x06015092 RID: 86162 RVA: 0x005D2953 File Offset: 0x005D0B53
	public void Clear()
	{
		this.GroupType = ETeamGroupType.Default;
		this.RoleList.Clear();
		this.LivingState = ETeamLivingState.Unknown;
		this.CurrentRole = null;
	}

	// Token: 0x06015093 RID: 86163 RVA: 0x005D2975 File Offset: 0x005D0B75
	public ETeamGroupType GetGroupType()
	{
		return this.GroupType;
	}

	// Token: 0x06015094 RID: 86164 RVA: 0x005D2980 File Offset: 0x005D0B80
	public List<SceneTeamRole> GetRoleList()
	{
		List<SceneTeamRole> list = new List<SceneTeamRole>();
		foreach (SceneTeamRole item in this.RoleList)
		{
			list.Add(item);
		}
		return list;
	}

	// Token: 0x06015095 RID: 86165 RVA: 0x005D29DC File Offset: 0x005D0BDC
	[NullableContext(2)]
	public SceneTeamRole GetCurrentRole()
	{
		return this.CurrentRole;
	}

	// Token: 0x06015096 RID: 86166 RVA: 0x005D29E4 File Offset: 0x005D0BE4
	public bool HasRole(long creatureDataId)
	{
		using (List<SceneTeamRole>.Enumerator enumerator = this.RoleList.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.CreatureDataId == creatureDataId)
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x06015097 RID: 86167 RVA: 0x005D2A40 File Offset: 0x005D0C40
	public void SetCurrentRole(long creatureDataId)
	{
		foreach (SceneTeamRole sceneTeamRole in this.RoleList)
		{
			if (sceneTeamRole.CreatureDataId == creatureDataId)
			{
				this.CurrentRole = sceneTeamRole;
			}
		}
	}

	// Token: 0x06015098 RID: 86168 RVA: 0x005D2A9C File Offset: 0x005D0C9C
	public ETeamLivingState GetLivingState()
	{
		return this.LivingState;
	}

	// Token: 0x06015099 RID: 86169 RVA: 0x005D2AA4 File Offset: 0x005D0CA4
	public void UpdateLivingState(ETeamLivingState state)
	{
		ETeamLivingState livingState = this.LivingState;
		this.LivingState = state;
		if (livingState != state)
		{
			bool p = this.PlayerId == ModelBase<CreatureModel>.Instance.GetPlayerId();
			Singleton<EventSystem>.Instance.Emit<bool, ETeamGroupType, ETeamLivingState, ETeamLivingState>(EEventName.OnTeamLivingStateChange, p, this.GroupType, state, livingState);
		}
	}

	// Token: 0x0601509A RID: 86170 RVA: 0x005D2AF0 File Offset: 0x005D0CF0
	public void Update(IList<SceneTeamRole> groupRoleList, int currentRoleId, ETeamLivingState livingState, bool isFixedLocation)
	{
		this.RoleList.Clear();
		this.CurrentRole = null;
		this.UpdateLivingState(livingState);
		if (groupRoleList.Count <= 0)
		{
			return;
		}
		this.IsFixedLocation = isFixedLocation;
		foreach (SceneTeamRole sceneTeamRole in groupRoleList)
		{
			this.RoleList.Add(sceneTeamRole);
			if (sceneTeamRole.RoleId == currentRoleId)
			{
				this.CurrentRole = sceneTeamRole;
			}
		}
	}

	// Token: 0x0601509B RID: 86171 RVA: 0x005D2B78 File Offset: 0x005D0D78
	public void AddRoleList(SceneTeamRole[] groupRoleList)
	{
		foreach (SceneTeamRole item in groupRoleList)
		{
			this.RoleList.Add(item);
		}
	}

	// Token: 0x0400A1E2 RID: 41442
	private int PlayerId;

	// Token: 0x0400A1E3 RID: 41443
	private ETeamGroupType GroupType;

	// Token: 0x0400A1E4 RID: 41444
	private readonly List<SceneTeamRole> RoleList = new List<SceneTeamRole>();

	// Token: 0x0400A1E5 RID: 41445
	[Nullable(2)]
	private SceneTeamRole CurrentRole;

	// Token: 0x0400A1E6 RID: 41446
	public bool IsFixedLocation;

	// Token: 0x0400A1E7 RID: 41447
	private ETeamLivingState LivingState;
}
