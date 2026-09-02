using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using AkiClient.Game.Aki.Core.Fight;
using UnrealEngine;

// Token: 0x02002DA3 RID: 11683
[NullableContext(1)]
[Nullable(0)]
public class BulletDataMove
{
	// Token: 0x17001F60 RID: 8032
	// (get) Token: 0x0601794E RID: 96590 RVA: 0x0068F4B0 File Offset: 0x0068D6B0
	public EInitialVelocityDirection InitVelocityDirStandard
	{
		get
		{
			if (this.InitVelocityDirStandardInternal == null)
			{
				this.InitVelocityDirStandardInternal = new EInitialVelocityDirection?(this.Data.出生初速度方向基准);
			}
			return this.InitVelocityDirStandardInternal.Value;
		}
	}

	// Token: 0x17001F61 RID: 8033
	// (get) Token: 0x0601794F RID: 96591 RVA: 0x0068F4E5 File Offset: 0x0068D6E5
	public bool InitVelocityKeepUp
	{
		get
		{
			if (this.InitVelocityKeepUpInternal == null)
			{
				this.InitVelocityKeepUpInternal = new bool?(this.Data.初速度仅Z轴朝向);
			}
			return this.InitVelocityKeepUpInternal.Value;
		}
	}

	// Token: 0x17001F62 RID: 8034
	// (get) Token: 0x06017950 RID: 96592 RVA: 0x0068F515 File Offset: 0x0068D715
	public string InitVelocityDirParam
	{
		get
		{
			if (this.InitVelocityDirParamInternal == null)
			{
				this.InitVelocityDirParamInternal = this.Data.出生初速度方向基准参数;
			}
			return this.InitVelocityDirParamInternal;
		}
	}

	// Token: 0x17001F63 RID: 8035
	// (get) Token: 0x06017951 RID: 96593 RVA: 0x0068F536 File Offset: 0x0068D736
	public Rotator InitVelocityRot
	{
		get
		{
			if (this.InitVelocityRotInternal == null)
			{
				this.InitVelocityRotInternal = Rotator.Create(this.Data.初速度偏移方向);
			}
			return this.InitVelocityRotInternal;
		}
	}

	// Token: 0x17001F64 RID: 8036
	// (get) Token: 0x06017952 RID: 96594 RVA: 0x0068F561 File Offset: 0x0068D761
	public Vector InitVelocityDirRandom
	{
		get
		{
			if (this.InitVelocityDirRandomInternal == null)
			{
				this.InitVelocityDirRandomInternal = Vector.Create(this.Data.初速度方向随机);
			}
			return this.InitVelocityDirRandomInternal;
		}
	}

	// Token: 0x17001F65 RID: 8037
	// (get) Token: 0x06017953 RID: 96595 RVA: 0x0068F58C File Offset: 0x0068D78C
	public float UpDownAngleLimit
	{
		get
		{
			if (this.UpDownAngleLimitInternal == null)
			{
				this.UpDownAngleLimitInternal = new float?(this.Data.发射上下角度限制);
			}
			return this.UpDownAngleLimitInternal.Value;
		}
	}

	// Token: 0x17001F66 RID: 8038
	// (get) Token: 0x06017954 RID: 96596 RVA: 0x0068F5BC File Offset: 0x0068D7BC
	public EBulletFollowType FollowType
	{
		get
		{
			if (this.FollowTypeInternal == null)
			{
				this.FollowTypeInternal = new EBulletFollowType?(this.Data.子弹跟随类型);
			}
			return this.FollowTypeInternal.Value;
		}
	}

	// Token: 0x17001F67 RID: 8039
	// (get) Token: 0x06017955 RID: 96597 RVA: 0x0068F5F1 File Offset: 0x0068D7F1
	public bool IsLockScale
	{
		get
		{
			if (this.IsLockScaleInternal == null)
			{
				this.IsLockScaleInternal = new bool?(this.Data.是否锁定缩放);
			}
			return this.IsLockScaleInternal.Value;
		}
	}

	// Token: 0x17001F68 RID: 8040
	// (get) Token: 0x06017956 RID: 96598 RVA: 0x0068F621 File Offset: 0x0068D821
	public bool IsDetachOnSkillEnd
	{
		get
		{
			if (this.IsDetachOnSkillEndInternal == null)
			{
				this.IsDetachOnSkillEndInternal = new bool?(this.Data.技能结束解除跟随骨骼);
			}
			return this.IsDetachOnSkillEndInternal.Value;
		}
	}

	// Token: 0x17001F69 RID: 8041
	// (get) Token: 0x06017957 RID: 96599 RVA: 0x0068F651 File Offset: 0x0068D851
	public float Speed
	{
		get
		{
			if (this.SpeedInternal == null)
			{
				this.SpeedInternal = new float?(this.Data.移动速度);
			}
			return this.SpeedInternal.Value;
		}
	}

	// Token: 0x17001F6A RID: 8042
	// (get) Token: 0x06017958 RID: 96600 RVA: 0x0068F681 File Offset: 0x0068D881
	public UCurveFloat SpeedCurve
	{
		get
		{
			if (!this.SpeedCurveInit)
			{
				this.SpeedCurveInit = true;
				this.SpeedCurveInternal = this.Data.移动速度曲线;
			}
			return this.SpeedCurveInternal;
		}
	}

	// Token: 0x17001F6B RID: 8043
	// (get) Token: 0x06017959 RID: 96601 RVA: 0x0068F6A9 File Offset: 0x0068D8A9
	public Vector FollowSkeletonRotLimit
	{
		get
		{
			if (this.FollowSkeletonRotLimitInternal == null)
			{
				this.FollowSkeletonRotLimitInternal = Vector.Create(this.Data.跟随骨骼限制旋转);
			}
			return this.FollowSkeletonRotLimitInternal;
		}
	}

	// Token: 0x17001F6C RID: 8044
	// (get) Token: 0x0601795A RID: 96602 RVA: 0x0068F6D4 File Offset: 0x0068D8D4
	public Vector[] TrackParams
	{
		get
		{
			if (this.TrackParamsInternal == null)
			{
				TArray<FVector> 运动轨迹参数数据 = this.Data.运动轨迹参数数据;
				int num = 运动轨迹参数数据.Num();
				this.TrackParamsInternal = new Vector[num];
				for (int i = 0; i < num; i++)
				{
					FVector fvector = 运动轨迹参数数据.Get(i);
					this.TrackParamsInternal[i] = Vector.Create(fvector);
				}
			}
			return this.TrackParamsInternal;
		}
	}

	// Token: 0x17001F6D RID: 8045
	// (get) Token: 0x0601795B RID: 96603 RVA: 0x0068F738 File Offset: 0x0068D938
	public UCurveVector[] TrackCurves
	{
		get
		{
			if (this.TrackCurvesInternal == null)
			{
				TArray<UCurveVector> 运动轨迹参数曲线 = this.Data.运动轨迹参数曲线;
				int num = 运动轨迹参数曲线.Num();
				this.TrackCurvesInternal = new UCurveVector[num];
				for (int i = 0; i < num; i++)
				{
					this.TrackCurvesInternal[i] = 运动轨迹参数曲线.Get(i);
				}
			}
			return this.TrackCurvesInternal;
		}
	}

	// Token: 0x17001F6E RID: 8046
	// (get) Token: 0x0601795C RID: 96604 RVA: 0x0068F78D File Offset: 0x0068D98D
	public EBulletTarget TrackTarget
	{
		get
		{
			if (this.TrackTargetInternal == null)
			{
				this.TrackTargetInternal = new EBulletTarget?((EBulletTarget)this.Data.运动轨迹参数目标);
			}
			return this.TrackTargetInternal.Value;
		}
	}

	// Token: 0x17001F6F RID: 8047
	// (get) Token: 0x0601795D RID: 96605 RVA: 0x0068F7C2 File Offset: 0x0068D9C2
	public string TrackTargetBlackboardKey
	{
		get
		{
			if (this.TrackTargetBlackboardKeyInternal == null)
			{
				this.TrackTargetBlackboardKeyInternal = this.Data.运动轨迹目标黑板Key值;
			}
			return this.TrackTargetBlackboardKeyInternal;
		}
	}

	// Token: 0x17001F70 RID: 8048
	// (get) Token: 0x0601795E RID: 96606 RVA: 0x0068F7E3 File Offset: 0x0068D9E3
	public EMoveTrajectory Trajectory
	{
		get
		{
			if (this.TrajectoryInternal == null)
			{
				this.TrajectoryInternal = new EMoveTrajectory?((EMoveTrajectory)this.Data.运动轨迹类型);
			}
			return this.TrajectoryInternal.Value;
		}
	}

	// Token: 0x17001F71 RID: 8049
	// (get) Token: 0x0601795F RID: 96607 RVA: 0x0068F818 File Offset: 0x0068DA18
	public FName BoneName
	{
		get
		{
			if (this.BoneNameInternal == null)
			{
				this.BoneNameInternal = new FName?(this.Data.骨骼名字);
			}
			return this.BoneNameInternal.Value;
		}
	}

	// Token: 0x17001F72 RID: 8050
	// (get) Token: 0x06017960 RID: 96608 RVA: 0x0068F848 File Offset: 0x0068DA48
	public string BoneNameString
	{
		get
		{
			if (this.BoneNameStringInternal == null)
			{
				this.BoneNameStringInternal = this.BoneName.ToString();
			}
			return this.BoneNameStringInternal;
		}
	}

	// Token: 0x17001F73 RID: 8051
	// (get) Token: 0x06017961 RID: 96609 RVA: 0x0068F87D File Offset: 0x0068DA7D
	public string SkeletonComponentName
	{
		get
		{
			if (this.SkeletonComponentNameInternal == null)
			{
				this.SkeletonComponentNameInternal = this.Data.骨骼网格体名字;
			}
			return this.SkeletonComponentNameInternal;
		}
	}

	// Token: 0x17001F74 RID: 8052
	// (get) Token: 0x06017962 RID: 96610 RVA: 0x0068F8A0 File Offset: 0x0068DAA0
	public Dictionary<EBulletBeginVelocityLimit, float> BeginVelocityLimitMap
	{
		get
		{
			if (this.BeginVelocityLimitMapInternal == null)
			{
				TMap<TEnumAsByte<EBulletBeginVelocityLimit>, float> 初速度角度限制 = this.Data.初速度角度限制;
				this.BeginVelocityLimitMapInternal = new Dictionary<EBulletBeginVelocityLimit, float>();
				foreach (KeyValuePair<TEnumAsByte<EBulletBeginVelocityLimit>, float> keyValuePair in 初速度角度限制)
				{
					TEnumAsByte<EBulletBeginVelocityLimit> tenumAsByte;
					float num;
					keyValuePair.Deconstruct(out tenumAsByte, out num);
					TEnumAsByte<EBulletBeginVelocityLimit> value = tenumAsByte;
					float value2 = num;
					this.BeginVelocityLimitMapInternal.Add(value, value2);
				}
			}
			return this.BeginVelocityLimitMapInternal;
		}
	}

	// Token: 0x17001F75 RID: 8053
	// (get) Token: 0x06017963 RID: 96611 RVA: 0x0068F928 File Offset: 0x0068DB28
	public EBulletDestOffset DestOffsetForward
	{
		get
		{
			if (this.DestOffsetForwardInternal == null)
			{
				this.DestOffsetForwardInternal = new EBulletDestOffset?(this.Data.终点偏移基准朝向);
			}
			return this.DestOffsetForwardInternal.Value;
		}
	}

	// Token: 0x17001F76 RID: 8054
	// (get) Token: 0x06017964 RID: 96612 RVA: 0x0068F95D File Offset: 0x0068DB5D
	public Vector DestOffset
	{
		get
		{
			if (this.DestOffsetInternal == null)
			{
				this.DestOffsetInternal = Vector.Create(this.Data.终点偏移);
			}
			return this.DestOffsetInternal;
		}
	}

	// Token: 0x17001F77 RID: 8055
	// (get) Token: 0x06017965 RID: 96613 RVA: 0x0068F988 File Offset: 0x0068DB88
	public string TrackTargetBone
	{
		get
		{
			if (this.TrackTargetBoneInternal == null)
			{
				this.TrackTargetBoneInternal = this.Data.运动轨迹目标骨骼;
			}
			return this.TrackTargetBoneInternal;
		}
	}

	// Token: 0x06017966 RID: 96614 RVA: 0x0068F9A9 File Offset: 0x0068DBA9
	public BulletDataMove(SReBulletDataMove data)
	{
		this.Data = data;
	}

	// Token: 0x06017967 RID: 96615 RVA: 0x0068F9B8 File Offset: 0x0068DBB8
	public bool Preload()
	{
		EInitialVelocityDirection initVelocityDirStandard = this.InitVelocityDirStandard;
		string initVelocityDirParam = this.InitVelocityDirParam;
		Rotator initVelocityRot = this.InitVelocityRot;
		EBulletFollowType followType = this.FollowType;
		float speed = this.Speed;
		UCurveFloat speedCurve = this.SpeedCurve;
		Vector[] trackParams = this.TrackParams;
		UCurveVector[] trackCurves = this.TrackCurves;
		EBulletTarget trackTarget = this.TrackTarget;
		EMoveTrajectory trajectory = this.Trajectory;
		FName boneName = this.BoneName;
		string skeletonComponentName = this.SkeletonComponentName;
		return (bool)true;
	}

	// Token: 0x0400B52B RID: 46379
	private readonly SReBulletDataMove Data;

	// Token: 0x0400B52C RID: 46380
	private EInitialVelocityDirection? InitVelocityDirStandardInternal;

	// Token: 0x0400B52D RID: 46381
	private bool? InitVelocityKeepUpInternal;

	// Token: 0x0400B52E RID: 46382
	[Nullable(2)]
	private string InitVelocityDirParamInternal;

	// Token: 0x0400B52F RID: 46383
	[Nullable(2)]
	private Rotator InitVelocityRotInternal;

	// Token: 0x0400B530 RID: 46384
	[Nullable(2)]
	private Vector InitVelocityDirRandomInternal;

	// Token: 0x0400B531 RID: 46385
	private float? UpDownAngleLimitInternal;

	// Token: 0x0400B532 RID: 46386
	private EBulletFollowType? FollowTypeInternal;

	// Token: 0x0400B533 RID: 46387
	private bool? IsLockScaleInternal;

	// Token: 0x0400B534 RID: 46388
	private bool? IsDetachOnSkillEndInternal;

	// Token: 0x0400B535 RID: 46389
	private float? SpeedInternal;

	// Token: 0x0400B536 RID: 46390
	[Nullable(2)]
	private UCurveFloat SpeedCurveInternal;

	// Token: 0x0400B537 RID: 46391
	private bool SpeedCurveInit;

	// Token: 0x0400B538 RID: 46392
	[Nullable(2)]
	private Vector FollowSkeletonRotLimitInternal;

	// Token: 0x0400B539 RID: 46393
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Vector[] TrackParamsInternal;

	// Token: 0x0400B53A RID: 46394
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private UCurveVector[] TrackCurvesInternal;

	// Token: 0x0400B53B RID: 46395
	private EBulletTarget? TrackTargetInternal;

	// Token: 0x0400B53C RID: 46396
	[Nullable(2)]
	private string TrackTargetBlackboardKeyInternal;

	// Token: 0x0400B53D RID: 46397
	private EMoveTrajectory? TrajectoryInternal;

	// Token: 0x0400B53E RID: 46398
	private FName? BoneNameInternal;

	// Token: 0x0400B53F RID: 46399
	[Nullable(2)]
	private string BoneNameStringInternal;

	// Token: 0x0400B540 RID: 46400
	[Nullable(2)]
	private string SkeletonComponentNameInternal;

	// Token: 0x0400B541 RID: 46401
	[Nullable(2)]
	private Dictionary<EBulletBeginVelocityLimit, float> BeginVelocityLimitMapInternal;

	// Token: 0x0400B542 RID: 46402
	private EBulletDestOffset? DestOffsetForwardInternal;

	// Token: 0x0400B543 RID: 46403
	[Nullable(2)]
	private Vector DestOffsetInternal;

	// Token: 0x0400B544 RID: 46404
	[Nullable(2)]
	private string TrackTargetBoneInternal;
}
