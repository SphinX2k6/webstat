using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Audio;

// Token: 0x02003208 RID: 12808
[NullableContext(1)]
[Nullable(0)]
public class RoleAudioCoolDownTime
{
	// Token: 0x0601A91F RID: 108831 RVA: 0x007E00F0 File Offset: 0x007DE2F0
	public RoleAudioCoolDownTime(ERoleAudioType type)
	{
		this.Type = type;
		RoleAudioRules? config = ConfigRoleAudioRulesById.GetConfig((int)type, true);
		this.TeamIntervalTime = (double)((config != null) ? config.GetValueOrDefault().TeamColdTime : 10000);
		int defaultCooldownTime = (config != null) ? config.GetValueOrDefault().CharacterColdTime : 10000;
		double defaultProbability = (double)((config != null) ? config.GetValueOrDefault().PostProbability : 100) / 100.0;
		this.ProbabilityCooldown = new AudioCoolDownWithTagInfo
		{
			DefaultCooldownTime = defaultCooldownTime,
			DefaultProbability = defaultProbability
		};
		this.GroupId = 0;
		if (config != null)
		{
			switch (config.Value.GroupID)
			{
			case 1:
				this.GroupId = 1;
				return;
			case 2:
				this.GroupId = 2;
				return;
			case 3:
				this.GroupId = 4;
				return;
			case 4:
				this.GroupId = 8;
				return;
			default:
				this.GroupId = 0;
				break;
			}
		}
	}

	// Token: 0x0601A920 RID: 108832 RVA: 0x007E0229 File Offset: 0x007DE429
	public void RefreshCoolDownTime(int entityId, bool log = true)
	{
		GameAudioModel instance = ModelBase<GameAudioModel>.Instance;
		if (instance == null)
		{
			return;
		}
		instance.UpdateAudioCooldownRecord(entityId, (int)this.Type, this.ProbabilityCooldown.DefaultProbability, this.ProbabilityCooldown.DefaultCooldownTime, log);
	}

	// Token: 0x0601A921 RID: 108833 RVA: 0x007E0260 File Offset: 0x007DE460
	public bool CheckCoolDownTime(int roleId, int entityId, bool update = true, bool log = true)
	{
		bool flag = true;
		SceneTeamModel instance = ModelBase<SceneTeamModel>.Instance;
		List<SceneTeamItem> list = (instance != null) ? instance.GetTeamItems(false) : null;
		if (list == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.Audio, ELogAuthor.CWZ, "[CheckAndUpdateCoolDownTime] GetTeamItems失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		int playerId = ModelBase<CreatureModel>.Instance.GetPlayerId();
		foreach (SceneTeamItem sceneTeamItem in list)
		{
			if (sceneTeamItem.GetConfigId == roleId)
			{
				playerId = sceneTeamItem.GetPlayerId();
				break;
			}
		}
		int num = 0;
		if (ModelBase<GameModeModel>.Instance.IsMulti)
		{
			OnlineTeamData currentTeamListById = ModelBase<OnlineModel>.Instance.GetCurrentTeamListById(playerId);
			num = ((currentTeamListById != null) ? currentTeamListById.PlayerNumber : 1) - 1;
			if (num < 0)
			{
				Singleton<Log>.Instance.Error(ELogModule.Audio, ELogAuthor.CWZ, "[CheckAndUpdateCoolDownTime] GetCurrentTeamListById失败", default(ReadOnlySpan<ValueTuple<string, object>>));
				return false;
			}
		}
		double num2 = Singleton<Time>.Instance.Now - this.CurrentTeamTime[num];
		flag = (flag && num2 >= this.TeamIntervalTime);
		bool flag2 = num2 < this.TeamIntervalTime && log;
		bool flag3;
		if (flag)
		{
			GameAudioModel instance2 = ModelBase<GameAudioModel>.Instance;
			flag3 = (instance2 != null && instance2.CheckAudioProbabilityInfo(entityId, (int)this.Type, this.ProbabilityCooldown, false, log, true));
		}
		else
		{
			flag3 = false;
		}
		flag = flag3;
		if (flag && update)
		{
			this.CurrentTeamTime[num] = Singleton<Time>.Instance.Now;
			this.RefreshCoolDownTime(entityId, log);
		}
		return flag;
	}

	// Token: 0x0400D71C RID: 55068
	public ERoleAudioType Type;

	// Token: 0x0400D71D RID: 55069
	public double[] CurrentTeamTime = new double[3];

	// Token: 0x0400D71E RID: 55070
	public double TeamIntervalTime;

	// Token: 0x0400D71F RID: 55071
	public int GroupId;

	// Token: 0x0400D720 RID: 55072
	public AudioCoolDownWithTagInfo ProbabilityCooldown = new AudioCoolDownWithTagInfo
	{
		DefaultCooldownTime = 0,
		DefaultProbability = 1.0
	};
}
