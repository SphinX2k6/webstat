using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using UnrealEngine;

// Token: 0x02000F5A RID: 3930
[NullableContext(1)]
[Nullable(0)]
public class MotorcycleArrowSubModel : KscSubModelBase
{
	// Token: 0x06006316 RID: 25366 RVA: 0x0018EAF8 File Offset: 0x0018CCF8
	public MotorcycleArrowSubModel()
	{
		this.ViewModeCollectionSelect = MotorcycleArrowCollectionSelectViewModel.Create(this);
	}

	// Token: 0x06006317 RID: 25367 RVA: 0x0018EBE1 File Offset: 0x0018CDE1
	public override string GetSkillDtPath()
	{
		return MotorcycleArrowSubModel.SkillDtPath;
	}

	// Token: 0x06006318 RID: 25368 RVA: 0x0018EBE8 File Offset: 0x0018CDE8
	public override string GetEntityDtPath()
	{
		return MotorcycleArrowSubModel.EntityDtPath;
	}

	// Token: 0x06006319 RID: 25369 RVA: 0x0018EBEF File Offset: 0x0018CDEF
	public string SceneSegmentDtPathMethod()
	{
		return MotorcycleArrowSubModel.SceneSegmentDtPath;
	}

	// Token: 0x0600631A RID: 25370 RVA: 0x0018EBF6 File Offset: 0x0018CDF6
	public void SetMotorcycleKscEntity(AKSC_Entity entity)
	{
		this.MotorcycleKscEntity = entity;
		this.MotorcycleKscEntityId = entity.EntityId_;
	}

	// Token: 0x0600631B RID: 25371 RVA: 0x0018EC0B File Offset: 0x0018CE0B
	public MotorcycleArrowBattleSkillData GetMotorcycleArrowBattleSkillData()
	{
		if (this.MotorcycleArrowBattleSkillData == null)
		{
			this.MotorcycleArrowBattleSkillData = new MotorcycleArrowBattleSkillData(220003);
			this.MotorcycleArrowBattleSkillData.InitData("载具漂移");
		}
		return this.MotorcycleArrowBattleSkillData;
	}

	// Token: 0x0600631C RID: 25372 RVA: 0x0018EC3B File Offset: 0x0018CE3B
	protected override bool OnInit()
	{
		this.HeadStateManager.Init();
		return true;
	}

	// Token: 0x0600631D RID: 25373 RVA: 0x0018EC4C File Offset: 0x0018CE4C
	protected override bool OnClear()
	{
		this.SubLevelIndex = 0;
		this.CurrentGroupWaveIndex = 0;
		this.LevelConfig = null;
		this.SceneSegmentDataDt.Clear();
		this.Generate.Clear();
		this.HeadStateManager.Clear();
		this.MotorcycleCreatureDataId = 0L;
		this.MotorcycleKscEntityId = 0;
		this.MotorcycleKscEntity = null;
		this.Score = 0;
		this.LevelStartTime = 0;
		this.MotorFightRoundInfo = null;
		this.WaveGroupCount.Clear();
		this.PendingMotorFightRefreshNotify = null;
		this.MotorPropertyConfigs.Clear();
		this.MotorHorizontalMoveDistance = 0;
		this.BossFightTime = 0;
		this.IsInBossBattle = false;
		this.ActiveBossCount = 0;
		this.InLoopSceneSegment = false;
		this.SubLevelConfig = null;
		this.CurrentSubLevelId = 0;
		this.EndDistance = 0;
		this.BossCreatureDataId = 0;
		this.ViewModeCollectionSelect.Clear();
		MotorcycleArrowBattleSkillData motorcycleArrowBattleSkillData = this.MotorcycleArrowBattleSkillData;
		if (motorcycleArrowBattleSkillData != null)
		{
			motorcycleArrowBattleSkillData.Clear();
		}
		this.MotorcycleArrowBattleSkillData = null;
		this.MotorRollRot = 0;
		this.IsCountDownEnd = false;
		this.IsGameOver = false;
		this.PendingPlayerBuff.Clear();
		this.BossIconPathList.Clear();
		this.DelayShowCollectionSelectViewTimer = null;
		this.MotorArrowCurSpeed = 0;
		this.AudioEventHandle = 0;
		return true;
	}

	// Token: 0x04002F52 RID: 12114
	public const int TRACK_HALF_WIDTH = 500;

	// Token: 0x04002F53 RID: 12115
	public const int MOTOR_HORIZONTAL_MOVE_LIMIT = 1000;

	// Token: 0x04002F54 RID: 12116
	private const int ACTIVE_SKILL_ID = 220003;

	// Token: 0x04002F55 RID: 12117
	public MotorcycleArrowCollectionSelectViewModel ViewModeCollectionSelect;

	// Token: 0x04002F56 RID: 12118
	public float DelayShowCollectionSelectView;

	// Token: 0x04002F57 RID: 12119
	[Nullable(2)]
	public TimerHandle DelayShowCollectionSelectViewTimer;

	// Token: 0x04002F58 RID: 12120
	public static readonly string SceneSegmentDtPath = "/Game/Aki/Data/SimpleCombat/3_1Jianjianjian/Scene/DT_KSCSceneSegment.DT_KSCSceneSegment";

	// Token: 0x04002F59 RID: 12121
	public static readonly string SkillDtPath = "/Game/Aki/Data/SimpleCombat/3_1Jianjianjian/Player/DT_KscSkill.DT_KscSkill";

	// Token: 0x04002F5A RID: 12122
	public static readonly string EntityDtPath = "/Game/Aki/Data/SimpleCombat/3_1Jianjianjian/Player/DT_KscEntity.DT_KscEntity";

	// Token: 0x04002F5B RID: 12123
	[Nullable(new byte[]
	{
		1,
		0,
		1,
		1
	})]
	public readonly Dictionary<int, ValueTuple<FKSCSceneSegmentTableRow, string>> SceneSegmentDataDt = new Dictionary<int, ValueTuple<FKSCSceneSegmentTableRow, string>>();

	// Token: 0x04002F5C RID: 12124
	public static readonly string BulletDtPath = "/Game/Aki/Data/SimpleCombat/3_1Jianjianjian/DT_KuroBulletData_Jianjianjian.DT_KuroBulletData_Jianjianjian";

	// Token: 0x04002F5D RID: 12125
	[Nullable(2)]
	public UDataTable BulletDataTable;

	// Token: 0x04002F5E RID: 12126
	public MotorFightMainLevel? LevelConfig;

	// Token: 0x04002F5F RID: 12127
	public global::Vector PlayerBornPos = global::Vector.Create(0.0, 0.0, 0.0);

	// Token: 0x04002F60 RID: 12128
	public global::Vector PlayerDirect = global::Vector.Create(0.0, 0.0, 0.0);

	// Token: 0x04002F61 RID: 12129
	public global::Vector PlayerRight = global::Vector.Create(0.0, 0.0, 0.0);

	// Token: 0x04002F62 RID: 12130
	public global::Rotator PlayerBornRot = global::Rotator.Create();

	// Token: 0x04002F63 RID: 12131
	public int MotorPosZ;

	// Token: 0x04002F64 RID: 12132
	public int Score;

	// Token: 0x04002F65 RID: 12133
	public int LevelStartTime;

	// Token: 0x04002F66 RID: 12134
	[Nullable(2)]
	public MotorFightRoundInfoNotify MotorFightRoundInfo;

	// Token: 0x04002F67 RID: 12135
	public List<MotorFightRoundBuffPb> PendingPlayerBuff = new List<MotorFightRoundBuffPb>();

	// Token: 0x04002F68 RID: 12136
	public int MotorArrowDropThreshold;

	// Token: 0x04002F69 RID: 12137
	public bool IsCountDownEnd;

	// Token: 0x04002F6A RID: 12138
	public bool IsGameOver;

	// Token: 0x04002F6B RID: 12139
	public List<string> BossIconPathList = new List<string>();

	// Token: 0x04002F6C RID: 12140
	public MotorcycleArrowGenerate Generate = new MotorcycleArrowGenerate();

	// Token: 0x04002F6D RID: 12141
	[Nullable(2)]
	public MotorFightRefreshSubLevelNotify PendingMotorFightRefreshNotify;

	// Token: 0x04002F6E RID: 12142
	public int SubLevelIndex;

	// Token: 0x04002F6F RID: 12143
	public int CurrentSubLevelId;

	// Token: 0x04002F70 RID: 12144
	public List<int> WaveGroupCount = new List<int>();

	// Token: 0x04002F71 RID: 12145
	public int CurrentGroupWaveIndex;

	// Token: 0x04002F72 RID: 12146
	public MotorFightSubLevel? SubLevelConfig;

	// Token: 0x04002F73 RID: 12147
	public bool InLoopSceneSegment;

	// Token: 0x04002F74 RID: 12148
	public int EndDistance;

	// Token: 0x04002F75 RID: 12149
	public bool IsInBossBattle;

	// Token: 0x04002F76 RID: 12150
	public int ActiveBossCount;

	// Token: 0x04002F77 RID: 12151
	public int BossFightTime;

	// Token: 0x04002F78 RID: 12152
	public int BossFightStartTime;

	// Token: 0x04002F79 RID: 12153
	public int BossCreatureDataId;

	// Token: 0x04002F7A RID: 12154
	public MotorcycleHeadStateManager HeadStateManager = new MotorcycleHeadStateManager();

	// Token: 0x04002F7B RID: 12155
	public Dictionary<int, MotorFightAttr> MotorPropertyConfigs = new Dictionary<int, MotorFightAttr>();

	// Token: 0x04002F7C RID: 12156
	public long MotorcycleCreatureDataId;

	// Token: 0x04002F7D RID: 12157
	public int MotorcycleKscEntityId;

	// Token: 0x04002F7E RID: 12158
	[Nullable(2)]
	public AKSC_Entity MotorcycleKscEntity;

	// Token: 0x04002F7F RID: 12159
	public int MotorHorizontalMoveDistance;

	// Token: 0x04002F80 RID: 12160
	public float MotorArrowAccelerateTime;

	// Token: 0x04002F81 RID: 12161
	public int MotorRollRot;

	// Token: 0x04002F82 RID: 12162
	public float MotorArrowDecelerateTime;

	// Token: 0x04002F83 RID: 12163
	public int MotorArrowCurSpeed;

	// Token: 0x04002F84 RID: 12164
	public int AudioEventHandle;

	// Token: 0x04002F85 RID: 12165
	[Nullable(2)]
	private MotorcycleArrowBattleSkillData MotorcycleArrowBattleSkillData;
}
