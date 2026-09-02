using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.Activity.ActivityContent.BossRush;
using CSharpScript.Game.Module.RoleUi;

// Token: 0x02001274 RID: 4724
[NullableContext(1)]
[Nullable(0)]
public class BossRushLevelDetailInfo
{
	// Token: 0x06007E38 RID: 32312 RVA: 0x00215910 File Offset: 0x00213B10
	public void Phrase(int activityId, BossRushLevelData data, int[] unlockBuffs)
	{
		this.ActivityId = activityId;
		this.SetId(data.InstId);
		this.SetScore(data.Score);
		this.SetUnLockTime((double)data.StartTime / 1000.0);
		this.IsOpen = data.IsOpen;
		this.BuffInfo = new List<BossRushBuffInfo>();
		this.UnlockBuffInfo = new List<BossRushBuffInfo>();
		this.OptionBuffInfo = new List<BossRushBuffInfo>();
		this.ScoreBuffInfo = new List<BossRushBuffInfo>();
		this.AllScoreBuffInfo = new List<BossRushBuffInfo>();
		foreach (BuffSelection buffSelection in data.BuffSelectionRecord)
		{
			BossRushBuffInfo bossRushBuffInfo = new BossRushBuffInfo();
			bossRushBuffInfo.BuffId = buffSelection.BuffId;
			bossRushBuffInfo.Slot = buffSelection.Slot;
			bossRushBuffInfo.ChangeAble = (buffSelection.BuffSelectionStatus != BossRushBuffSelectionStatus.BuffLocked && buffSelection.BuffSelectionStatus != BossRushBuffSelectionStatus.BuffInactive);
			bossRushBuffInfo.State = buffSelection.BuffSelectionStatus;
			this.BuffInfo.Add(bossRushBuffInfo);
		}
		foreach (int buffId in this.GetConfig().Value.OptionalBuff())
		{
			BossRushBuffInfo bossRushBuffInfo2 = new BossRushBuffInfo();
			bossRushBuffInfo2.BuffId = buffId;
			bossRushBuffInfo2.Slot = -1;
			bossRushBuffInfo2.ChangeAble = true;
			this.OptionBuffInfo.Add(bossRushBuffInfo2);
		}
		foreach (int buffId2 in unlockBuffs)
		{
			BossRushBuffInfo bossRushBuffInfo3 = new BossRushBuffInfo();
			bossRushBuffInfo3.BuffId = buffId2;
			bossRushBuffInfo3.Slot = -1;
			bossRushBuffInfo3.ChangeAble = true;
			this.UnlockBuffInfo.Add(bossRushBuffInfo3);
		}
		int num = 1;
		foreach (int buffId3 in data.ScoreBuff)
		{
			BossRushBuffInfo bossRushBuffInfo4 = new BossRushBuffInfo();
			bossRushBuffInfo4.BuffId = buffId3;
			bossRushBuffInfo4.Slot = num++;
			bossRushBuffInfo4.ChangeAble = true;
			bossRushBuffInfo4.State = BossRushBuffSelectionStatus.BuffSelected;
			this.ScoreBuffInfo.Add(bossRushBuffInfo4);
		}
		for (int j = num; j <= 2; j++)
		{
			BossRushBuffInfo bossRushBuffInfo5 = new BossRushBuffInfo();
			bossRushBuffInfo5.BuffId = 0;
			bossRushBuffInfo5.Slot = num++;
			bossRushBuffInfo5.ChangeAble = (this.GetConfig().Value.ScoreBuffCount >= j);
			bossRushBuffInfo5.State = ((this.GetConfig().Value.ScoreBuffCount >= j) ? BossRushBuffSelectionStatus.BuffEmpty : BossRushBuffSelectionStatus.BuffInactive);
			this.ScoreBuffInfo.Add(bossRushBuffInfo5);
		}
		foreach (int buffId4 in this.GetConfig().Value.ScoreBuff())
		{
			BossRushBuffInfo bossRushBuffInfo6 = new BossRushBuffInfo();
			bossRushBuffInfo6.BuffId = buffId4;
			bossRushBuffInfo6.Slot = -1;
			bossRushBuffInfo6.ChangeAble = true;
			this.AllScoreBuffInfo.Add(bossRushBuffInfo6);
		}
		this.RoleInfo = new List<BossRushRoleInfo>();
		int num2 = 0;
		foreach (int roleId in data.CharacterSelectionRecord)
		{
			BossRushRoleInfo bossRushRoleInfo = new BossRushRoleInfo();
			bossRushRoleInfo.RoleId = roleId;
			bossRushRoleInfo.Slot = num2;
			num2++;
			this.RoleInfo.Add(bossRushRoleInfo);
		}
	}

	// Token: 0x06007E39 RID: 32313 RVA: 0x00215CA4 File Offset: 0x00213EA4
	public void SetId(int id)
	{
		this.Id = id;
	}

	// Token: 0x06007E3A RID: 32314 RVA: 0x00215CAD File Offset: 0x00213EAD
	public void SetScore(int score)
	{
		this.Score = score;
	}

	// Token: 0x06007E3B RID: 32315 RVA: 0x00215CB6 File Offset: 0x00213EB6
	public void SetUnLockTime(double unLockTime)
	{
		this.UnLockTime = unLockTime;
	}

	// Token: 0x06007E3C RID: 32316 RVA: 0x00215CBF File Offset: 0x00213EBF
	public int GetId()
	{
		return this.Id;
	}

	// Token: 0x06007E3D RID: 32317 RVA: 0x00215CC8 File Offset: 0x00213EC8
	public string GetMonsterTexturePath()
	{
		return this.GetConfig().Value.PreviewTexture;
	}

	// Token: 0x06007E3E RID: 32318 RVA: 0x00215CEC File Offset: 0x00213EEC
	public string GetBigMonsterTexturePath()
	{
		return this.GetConfig().Value.StageTexture;
	}

	// Token: 0x06007E3F RID: 32319 RVA: 0x00215D10 File Offset: 0x00213F10
	public string GetMonsterName()
	{
		int bossInfo = this.GetConfig().Value.BossInfo;
		Aki.Config.MonsterInfo? monsterInfoConfig = ConfigBase<MonsterInfoConfig>.Instance.GetMonsterInfoConfig(bossInfo);
		if (monsterInfoConfig == null)
		{
			return "";
		}
		return monsterInfoConfig.Value.Name;
	}

	// Token: 0x06007E40 RID: 32320 RVA: 0x00215D60 File Offset: 0x00213F60
	public string GetLevelDesc()
	{
		return this.GetConfig().Value.LevelDesc;
	}

	// Token: 0x06007E41 RID: 32321 RVA: 0x00215D84 File Offset: 0x00213F84
	public int[] GetRecommendElementIdArray()
	{
		return this.GetInstanceDungeonConfig().Value.RecommendElement().ToArray<int>();
	}

	// Token: 0x06007E42 RID: 32322 RVA: 0x00215DAC File Offset: 0x00213FAC
	public bool GetUnLockState()
	{
		return this.IsOpen;
	}

	// Token: 0x06007E43 RID: 32323 RVA: 0x00215DB4 File Offset: 0x00213FB4
	public int GetScore()
	{
		return this.Score;
	}

	// Token: 0x06007E44 RID: 32324 RVA: 0x00215DBC File Offset: 0x00213FBC
	public string GetUnlockTimeText()
	{
		if (Singleton<TimeUtil>.Instance.GetServerTime() >= this.UnLockTime)
		{
			return ConfigMultiTextLang.GetLocalTextNew("BossRushUnlockCondition", null) ?? "";
		}
		CommonDefine.ICountDown remainTimeDataFormat = Singleton<TimeUtil>.Instance.GetRemainTimeDataFormat3(this.UnLockTime - Singleton<TimeUtil>.Instance.GetServerTime());
		string localTextNew = ConfigMultiTextLang.GetLocalTextNew("BossRushUnLockTime", null);
		if (localTextNew == null)
		{
			return "";
		}
		return StringUtils.Format(localTextNew, new string[]
		{
			remainTimeDataFormat.CountDownText ?? ""
		});
	}

	// Token: 0x06007E45 RID: 32325 RVA: 0x00215E3F File Offset: 0x0021403F
	public double GetUnLockTime()
	{
		return this.UnLockTime;
	}

	// Token: 0x06007E46 RID: 32326 RVA: 0x00215E47 File Offset: 0x00214047
	public BossRushActivity? GetConfig()
	{
		return ConfigBase<BossRushConfig>.Instance.GetBossRushByActivityIdAndInstanceId(this.ActivityId, this.Id);
	}

	// Token: 0x06007E47 RID: 32327 RVA: 0x00215E60 File Offset: 0x00214060
	public int GetMaxBuffCount()
	{
		if (ModelBase<BossRushModel>.Instance.CurrentSelectBuffTabName != EBuffTabName.Normal)
		{
			return this.GetConfig().Value.ScoreBuffCount;
		}
		return this.GetConfig().Value.BuffCount;
	}

	// Token: 0x06007E48 RID: 32328 RVA: 0x00215EA8 File Offset: 0x002140A8
	public int GetInstanceDungeonId()
	{
		return this.GetConfig().Value.InstId;
	}

	// Token: 0x06007E49 RID: 32329 RVA: 0x00215ECC File Offset: 0x002140CC
	public int GetInstanceDungeonFormationId()
	{
		return this.GetInstanceDungeonConfig().Value.FightFormationId;
	}

	// Token: 0x06007E4A RID: 32330 RVA: 0x00215EF0 File Offset: 0x002140F0
	public int GetInstanceDungeonFormationNumb()
	{
		Aki.Config.FightFormation? fightFormationConfig = ConfigBase<EditBattleTeamConfig>.Instance.GetFightFormationConfig(this.GetInstanceDungeonFormationId());
		if (fightFormationConfig == null)
		{
			return 0;
		}
		return fightFormationConfig.Value.LimitCount().Length;
	}

	// Token: 0x06007E4B RID: 32331 RVA: 0x00215F2C File Offset: 0x0021412C
	public InstanceDungeon? GetInstanceDungeonConfig()
	{
		int instId = this.GetConfig().Value.InstId;
		return ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(instId);
	}

	// Token: 0x06007E4C RID: 32332 RVA: 0x00215F5C File Offset: 0x0021415C
	public BossRushTeamInfo ConvertToTeamInfo()
	{
		BossRushTeamInfo bossRushTeamInfo = new BossRushTeamInfo();
		bossRushTeamInfo.SetCurrentSelectLevel(this);
		List<int> list = new List<int>();
		foreach (BossRushRoleInfo bossRushRoleInfo in this.RoleInfo)
		{
			int roleId = bossRushRoleInfo.RoleId;
			if (roleId >= 100000)
			{
				TrialRoleInfo? trialRoleConfig = ConfigBase<RoleConfig>.Instance.GetTrialRoleConfig(roleId);
				if (trialRoleConfig != null)
				{
					TrialRoleInfo? trialRoleConfigByGroupId = ConfigBase<RoleConfig>.Instance.GetTrialRoleConfigByGroupId(trialRoleConfig.Value.GroupId);
					if (trialRoleConfigByGroupId != null)
					{
						list.Add(trialRoleConfigByGroupId.Value.Id);
					}
				}
			}
			else
			{
				list.Add(roleId);
			}
		}
		bossRushTeamInfo.SetCurrentTeamMembers(list.ToArray());
		bossRushTeamInfo.LevelInfo = this;
		bossRushTeamInfo.InitLevelBuff(this.BuffInfo.ToArray(), this.UnlockBuffInfo.ToArray(), this.OptionBuffInfo.ToArray(), this.ScoreBuffInfo.ToArray(), this.AllScoreBuffInfo.ToArray());
		bossRushTeamInfo.InitPrepareSelectBuff();
		bossRushTeamInfo.InitPrepareSelectScoreBuff();
		bossRushTeamInfo.ActivityId = this.ActivityId;
		return bossRushTeamInfo;
	}

	// Token: 0x04003C85 RID: 15493
	private int ActivityId;

	// Token: 0x04003C86 RID: 15494
	private int Id;

	// Token: 0x04003C87 RID: 15495
	private int Score;

	// Token: 0x04003C88 RID: 15496
	private double UnLockTime;

	// Token: 0x04003C89 RID: 15497
	private List<BossRushBuffInfo> BuffInfo = new List<BossRushBuffInfo>();

	// Token: 0x04003C8A RID: 15498
	private List<BossRushBuffInfo> UnlockBuffInfo = new List<BossRushBuffInfo>();

	// Token: 0x04003C8B RID: 15499
	private List<BossRushBuffInfo> OptionBuffInfo = new List<BossRushBuffInfo>();

	// Token: 0x04003C8C RID: 15500
	private List<BossRushBuffInfo> ScoreBuffInfo = new List<BossRushBuffInfo>();

	// Token: 0x04003C8D RID: 15501
	private List<BossRushBuffInfo> AllScoreBuffInfo = new List<BossRushBuffInfo>();

	// Token: 0x04003C8E RID: 15502
	private List<BossRushRoleInfo> RoleInfo = new List<BossRushRoleInfo>();

	// Token: 0x04003C8F RID: 15503
	private bool IsOpen;
}
