using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Level.KeepFollowing;
using UnrealEngine;

// Token: 0x020030D9 RID: 12505
public class FollowingMoveParams
{
	// Token: 0x06019CCB RID: 105675 RVA: 0x00788098 File Offset: 0x00786298
	[NullableContext(2)]
	public FollowingMoveParams(BP_KeepFollowingConfig_C data = null)
	{
		if (data != null)
		{
			this.KeepStandDistance = (float)data.保持站立距离;
			this.WalkRunDivideSpeed = (float)data.走跑状态分界速度;
			this.WalkRunDivideFloat = (float)data.走跑分界速度浮动;
			this.RunSprintDivideSpeed = (float)data.跑冲刺分界速度;
			this.RunSprintDivideFloat = (float)data.跑冲刺分界速度浮动;
			this.ChangeSpeedAcceleration = (float)data.变速加速度;
			this.ToleranceDistance = (float)data.跟随距离容差;
			this.WalkOffsetLocation = new ValueTuple<double, double>((double)data.步行跟随方位向量.X, (double)data.步行跟随方位向量.Y);
			this.RunOffsetLocation = new ValueTuple<double, double>((double)data.跑步跟随方位向量.X, (double)data.跑步跟随方位向量.Y);
			this.FollowingSpeedRange = new ValueTuple<double, double>((double)data.跟随变速范围.X, (double)data.跟随变速范围.Y);
			this.EnableCompensate = data.是否启用位移修正;
			this.CompensateDistance = (float)data.位移修正距离;
			this.CompensateSpeed = (float)data.位移修正速度;
			this.EnableTimeOutTeleport = data.是否启用超时传送;
			this.IllegalDistance = (float)data.异常距离;
			this.TimeOutDuration = (float)data.超时时间;
			this.HeightDifference = (float)data.高低差允许范围;
			this.ObstacleTime = (float)data.被阻挡触发传送时间;
			this.StandardWalkSpeed = (float)data.StandardWalkSpeed;
			this.StandardRunSpeed = (float)data.StandardRunSpeed;
			this.StandardSprintSpeed = (float)data.StandardSprintSpeed;
			this.UseStandardSpeed = data.只使用标准速度;
			this.KeepStandDistanceWithTarget = (float)data.保持站立角色距离;
			this.StartMoveDelayTime = (float)data.移动延迟时间;
			this.ChangeRunDelayTime = (float)data.加速延迟时间;
			this.NotKeepSync = data.非近距离同步跟随;
			this.AutoTurnToTarget = data.自动转向目标;
			this.FreeFollowing = new FreeFollowingParams(data.自动跟随信息);
			SFollowSitConfig 跟随坐下信息 = data.跟随坐下信息;
			this.FollowSitEnable = 跟随坐下信息.Enable;
			this.FollowSitFindChairRadius = (float)跟随坐下信息.FindChairRadius;
			this.FollowSitExitDistance = (float)跟随坐下信息.ExitSitDownDistance;
			this.FollowSitExitDistanceSquared = this.FollowSitExitDistance * this.FollowSitExitDistance;
			for (int i = 0; i < data.步行跟随方位备选.Num(); i++)
			{
				FVector2D fvector2D = data.步行跟随方位备选.Get(i);
				ValueTuple<double, double> valueTuple = new ValueTuple<double, double>((double)fvector2D.X, (double)fvector2D.Y);
				if ((Math.Abs(valueTuple.Item1) >= 0.0001 || Math.Abs(valueTuple.Item2) >= 0.0001) && !this.WalkOffsetList.Contains(valueTuple))
				{
					this.WalkOffsetList.Add(valueTuple);
				}
			}
			for (int j = 0; j < data.跑步跟随方位备选.Num(); j++)
			{
				FVector2D fvector2D2 = data.跑步跟随方位备选.Get(j);
				ValueTuple<double, double> valueTuple2 = new ValueTuple<double, double>((double)fvector2D2.X, (double)fvector2D2.Y);
				if ((Math.Abs(valueTuple2.Item1) >= 0.0001 || Math.Abs(valueTuple2.Item2) >= 0.0001) && !this.RunOffsetList.Contains(valueTuple2))
				{
					this.RunOffsetList.Add(valueTuple2);
				}
			}
			for (int k = 0; k < data.传送特效buffID.Num(); k++)
			{
				int item = data.传送特效buffID.Get(k);
				if (!this.TeleportEffectBuffId.Contains(item))
				{
					this.TeleportEffectBuffId.Add(item);
				}
			}
			this.CompensateDistanceSquared = this.CompensateDistance * this.CompensateDistance;
			this.MinFollowingSpeed = (float)(this.FollowingSpeedRange.Item1 * 0.30000001192092896);
		}
	}

	// Token: 0x0400CE39 RID: 52793
	public float KeepStandDistance = 10f;

	// Token: 0x0400CE3A RID: 52794
	public float WalkRunDivideSpeed = 250f;

	// Token: 0x0400CE3B RID: 52795
	public float WalkRunDivideFloat = 30f;

	// Token: 0x0400CE3C RID: 52796
	public float RunSprintDivideSpeed = 550f;

	// Token: 0x0400CE3D RID: 52797
	public float RunSprintDivideFloat = 50f;

	// Token: 0x0400CE3E RID: 52798
	public float ChangeSpeedAcceleration = 20f;

	// Token: 0x0400CE3F RID: 52799
	public float ToleranceDistance = 20f;

	// Token: 0x0400CE40 RID: 52800
	public bool EnableCompensate = true;

	// Token: 0x0400CE41 RID: 52801
	public float CompensateDistance = 50f;

	// Token: 0x0400CE42 RID: 52802
	public float CompensateDistanceSquared = 2500f;

	// Token: 0x0400CE43 RID: 52803
	public float CompensateSpeed = 600f;

	// Token: 0x0400CE44 RID: 52804
	public bool EnableTimeOutTeleport = true;

	// Token: 0x0400CE45 RID: 52805
	public float IllegalDistance = 500f;

	// Token: 0x0400CE46 RID: 52806
	public float TimeOutDuration = 3000f;

	// Token: 0x0400CE47 RID: 52807
	[TupleElementNames(new string[]
	{
		"X",
		"Y"
	})]
	public ValueTuple<double, double> WalkOffsetLocation = new ValueTuple<double, double>(0.0, 60.0);

	// Token: 0x0400CE48 RID: 52808
	[TupleElementNames(new string[]
	{
		"X",
		"Y"
	})]
	public ValueTuple<double, double> RunOffsetLocation = new ValueTuple<double, double>(0.0, 80.0);

	// Token: 0x0400CE49 RID: 52809
	[TupleElementNames(new string[]
	{
		"X",
		"Y"
	})]
	public ValueTuple<double, double> FollowingSpeedRange = new ValueTuple<double, double>(50.0, 600.0);

	// Token: 0x0400CE4A RID: 52810
	public float MinFollowingSpeed = 15.000001f;

	// Token: 0x0400CE4B RID: 52811
	public float HeightDifference = 30f;

	// Token: 0x0400CE4C RID: 52812
	public float ObstacleTime = 2000f;

	// Token: 0x0400CE4D RID: 52813
	[Nullable(1)]
	public List<int> TeleportEffectBuffId = new List<int>();

	// Token: 0x0400CE4E RID: 52814
	public float StandardWalkSpeed = 100f;

	// Token: 0x0400CE4F RID: 52815
	public float StandardRunSpeed = 400f;

	// Token: 0x0400CE50 RID: 52816
	public float StandardSprintSpeed = 700f;

	// Token: 0x0400CE51 RID: 52817
	public bool UseStandardSpeed;

	// Token: 0x0400CE52 RID: 52818
	public bool NotKeepSync;

	// Token: 0x0400CE53 RID: 52819
	public bool AutoTurnToTarget;

	// Token: 0x0400CE54 RID: 52820
	public float StartMoveDelayTime;

	// Token: 0x0400CE55 RID: 52821
	public float ChangeRunDelayTime;

	// Token: 0x0400CE56 RID: 52822
	public float KeepStandDistanceWithTarget;

	// Token: 0x0400CE57 RID: 52823
	[Nullable(1)]
	public FreeFollowingParams FreeFollowing = new FreeFollowingParams();

	// Token: 0x0400CE58 RID: 52824
	public bool FollowSitEnable;

	// Token: 0x0400CE59 RID: 52825
	public float FollowSitFindChairRadius;

	// Token: 0x0400CE5A RID: 52826
	public float FollowSitExitDistance;

	// Token: 0x0400CE5B RID: 52827
	public float FollowSitExitDistanceSquared;

	// Token: 0x0400CE5C RID: 52828
	[TupleElementNames(new string[]
	{
		"X",
		"Y"
	})]
	[Nullable(new byte[]
	{
		1,
		0
	})]
	public List<ValueTuple<double, double>> WalkOffsetList = new List<ValueTuple<double, double>>();

	// Token: 0x0400CE5D RID: 52829
	[TupleElementNames(new string[]
	{
		"X",
		"Y"
	})]
	[Nullable(new byte[]
	{
		1,
		0
	})]
	public List<ValueTuple<double, double>> RunOffsetList = new List<ValueTuple<double, double>>();
}
