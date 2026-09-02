using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using AkiClient.Game.Aki.Core.Fight;
using UnrealEngine;

// Token: 0x02002DA2 RID: 11682
[NullableContext(1)]
[Nullable(0)]
public class BulletDataMain
{
	// Token: 0x06017948 RID: 96584 RVA: 0x0068EEB4 File Offset: 0x0068D0B4
	public BulletDataMain(SReBulletDataMain data, string bulletRowName, bool isPerformance)
	{
		this.Data = data;
		this.BulletRowName = bulletRowName;
		this.BulletFName = data.子弹名称;
		this.BulletName = data.子弹名称.ToString();
		this.Base = new BulletDataBase(data.基础设置);
		this.Logic = new BulletDataLogic(data.逻辑设置.预设);
		this.Aimed = new BulletDataAimed(data.瞄准设置);
		this.Move = new BulletDataMove(data.移动设置);
		this.Render = new BulletDataRender(data.表现效果设置);
		this.TimeScale = new BulletDataTimeScale(data.时间膨胀);
		this.Execution = new BulletDataExecution(data.执行逻辑);
		this.Scale = new BulletDataScale(data.缩放设置);
		this.Summon = new BulletDataSummon(data.召唤实体);
		this.Children = new BulletDataChild[data.子子弹设置.Num()];
		for (int i = 0; i < data.子子弹设置.Num(); i++)
		{
			SReBulletDataChildren data2 = data.子子弹设置.Get(i);
			this.Children[i] = new BulletDataChild(data2);
		}
		this.Obstacle = new BulletDataObstacle(data.障碍检测);
		this.Interact = new BulletDataInteract(data.环境交互);
		this.IsPerformance = isPerformance;
		this.SimpleBullet = BulletDataMain.CheckSimpleBullet(this);
	}

	// Token: 0x06017949 RID: 96585 RVA: 0x0068F018 File Offset: 0x0068D218
	private static bool CheckSimpleBullet(BulletDataMain data)
	{
		BulletDataBase @base = data.Base;
		if (@base.SpecialParams.Count > 0 || @base.BornPositionStandard != EPositionStandard.发射者位置 || @base.BlackboardKey != BulletDataMain.StrNone || !@base.CenterOffset.IsZero() || !@base.BornPositionRandom.IsZero() || !@base.Rotator.IsNearlyZero() || !@base.BornDistLimit.IsZero() || @base.CollisionActiveDuration > 0f || @base.CollisionActiveDelay > 0f || @base.HitType != 2 || @base.DaHitTypePreset != BulletDataMain.StrNone || @base.HitConditionTagId != 0 || @base.BanHitTagId != 0 || @base.VictimCount != -1 || @base.HitCountPerVictim != -1 || @base.HitCountMax != -1 || @base.Interval > 0f || @base.ShareCounter || @base.HitEffectWeakness == FNameUtil.EMPTY || !@base.AttackDirection.IsNearlyZero() || @base.DestroyOnSkillEnd || @base.BornRequireTagIds != null || @base.BornForbidTagIds != null || @base.ContinuesCollision || @base.StickGround || @base.IgnoreGradient || @base.SyncType != EBulletSyncTypeTs.Local || @base.TagId != 0)
		{
			return false;
		}
		if (data.Aimed.AimedCtrlDir)
		{
			return false;
		}
		if (data.Move.Speed > 0f || data.Move.FollowType != EBulletFollowType.固定位置)
		{
			return false;
		}
		BulletDataExecution execution = data.Execution;
		FGameplayTag fgameplayTag = execution.SendGameplayEventTagToAttackerOnStart;
		if (fgameplayTag.TagName.ToString().Length == 0)
		{
			fgameplayTag = execution.SendGameplayEventTagToAttacker;
			if (fgameplayTag.TagName.ToString().Length == 0)
			{
				fgameplayTag = execution.SendGameplayEventTagToVictim;
				if (fgameplayTag.TagName.ToString().Length == 0)
				{
					fgameplayTag = execution.SendGameplayEventTagToAttackerOnEnd;
					if (fgameplayTag.TagName.ToString().Length == 0 && execution.SendGeIdToAttacker.Length == 0 && execution.SendGeIdToVictim.Length == 0 && execution.EnergyRecoverGeIds.Length == 0 && execution.SendGeIdToRoleInGame.Length == 0 && execution.GeIdApplyToVictim.Length == 0 && (execution.GbDataList == null || execution.GbDataList.Count <= 0))
					{
						BulletDataScale scale = data.Scale;
						return scale.SizeScale == Vector.OneVectorProxy && scale.ScaleCurve == null && !scale.ShapeSwitch && data.Summon.EntityId <= 0 && data.Children.Length == 0 && data.Obstacle.Center.IsZero() && data.Obstacle.Radius <= 0f && !(data.Interact.SceneInteract != BulletDataMain.StrNone);
					}
				}
			}
		}
		return false;
	}

	// Token: 0x0601794A RID: 96586 RVA: 0x0068F316 File Offset: 0x0068D516
	public bool CheckValid()
	{
		BulletDataLogic logic = this.Logic;
		if (((logic != null) ? logic.Data : null) == null)
		{
			return false;
		}
		this.CheckIsOverSizeForTrace();
		return true;
	}

	// Token: 0x0601794B RID: 96587 RVA: 0x0068F338 File Offset: 0x0068D538
	private bool CheckIsOverSizeForTrace()
	{
		switch (this.Base.Shape)
		{
		case global::EBulletShape.Cube:
			this.Base.IsOversizeForTrace = (this.Base.Size.GetMax() > 600.0);
			goto IL_FE;
		case global::EBulletShape.Sphere:
			this.Base.IsOversizeForTrace = (this.Base.Size.X > 600.0);
			goto IL_FE;
		case global::EBulletShape.Sector:
		case global::EBulletShape.Cylinder:
			this.Base.IsOversizeForTrace = (this.Base.Size.X > 600.0 || this.Base.Size.Z > 600.0);
			goto IL_FE;
		case global::EBulletShape.Ray:
		case global::EBulletShape.BigCube:
		case global::EBulletShape.BigSphere:
		case global::EBulletShape.BigSector:
		case global::EBulletShape.BigCylinder:
			goto IL_FE;
		}
		this.Base.IsOversizeForTrace = (this.Base.Size.GetMax() > 600.0);
		IL_FE:
		return this.Base.IsOversizeForTrace;
	}

	// Token: 0x0601794C RID: 96588 RVA: 0x0068F450 File Offset: 0x0068D650
	public void Preload()
	{
		this.Base.Preload();
		this.Logic.Preload();
		this.Move.Preload();
		this.Execution.Preload();
		this.Scale.Preload();
		this.Obstacle.Preload();
	}

	// Token: 0x0400B517 RID: 46359
	private const float TRACE_SIZE_MAX = 600f;

	// Token: 0x0400B518 RID: 46360
	public SReBulletDataMain Data;

	// Token: 0x0400B519 RID: 46361
	public string BulletRowName;

	// Token: 0x0400B51A RID: 46362
	public FName BulletFName;

	// Token: 0x0400B51B RID: 46363
	public string BulletName;

	// Token: 0x0400B51C RID: 46364
	public readonly bool SimpleBullet;

	// Token: 0x0400B51D RID: 46365
	public readonly BulletDataBase Base;

	// Token: 0x0400B51E RID: 46366
	public readonly BulletDataLogic Logic;

	// Token: 0x0400B51F RID: 46367
	public readonly BulletDataAimed Aimed;

	// Token: 0x0400B520 RID: 46368
	public readonly BulletDataMove Move;

	// Token: 0x0400B521 RID: 46369
	public readonly BulletDataRender Render;

	// Token: 0x0400B522 RID: 46370
	public readonly BulletDataTimeScale TimeScale;

	// Token: 0x0400B523 RID: 46371
	public readonly BulletDataExecution Execution;

	// Token: 0x0400B524 RID: 46372
	public readonly BulletDataScale Scale;

	// Token: 0x0400B525 RID: 46373
	public readonly BulletDataSummon Summon;

	// Token: 0x0400B526 RID: 46374
	public readonly BulletDataChild[] Children;

	// Token: 0x0400B527 RID: 46375
	public readonly BulletDataObstacle Obstacle;

	// Token: 0x0400B528 RID: 46376
	public readonly BulletDataInteract Interact;

	// Token: 0x0400B529 RID: 46377
	public readonly bool IsPerformance;

	// Token: 0x0400B52A RID: 46378
	private static readonly string StrNone = "None";
}
