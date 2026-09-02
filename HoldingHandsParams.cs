using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.Role.Common.Data.Structure;
using AkiClient.Game.Aki.Data.Level.KeepFollowing;
using UnrealEngine;

// Token: 0x02003046 RID: 12358
[NullableContext(1)]
[Nullable(0)]
public class HoldingHandsParams
{
	// Token: 0x06019509 RID: 103689 RVA: 0x00749E9C File Offset: 0x0074809C
	[NullableContext(2)]
	public HoldingHandsParams(BP_HoldingHandsConfig_C asset = null)
	{
		if (asset == null)
		{
			return;
		}
		this.Debug = asset.Debug;
		this.ReachableTag = asset.牵手范围内.TagId();
		this.InvitingTags = GameplayTagUtils.ConvertFromUeContainer(asset.邀请中);
		this.LeadingTags = GameplayTagUtils.ConvertFromUeContainer(asset.牵手中);
		this.FollowingTags = GameplayTagUtils.ConvertFromUeContainer(asset.被牵手中);
		this.DisableTags = GameplayTagUtils.ConvertFromUeContainer(asset.牵手禁止);
		this.EndTime = (double)asset.超时终止时长;
		this.LongPressDuration = (double)asset.长按退出时长;
		this.IkAlphaDamping = (double)asset.进出牵手阻尼;
		this.BindVecDamping = (double)asset.牵手点阻尼;
		this.WalkRotateSpeedMax = (double)asset.走路最大旋转速度;
		this.RunRotateSpeedMax = (double)asset.跑步最大旋转速度;
		this.InputScaleRun = (double)asset.跑步速度缩放;
		FFloatRange 牵手点偏转角范围 = asset.牵手点偏转角范围;
		this.YawRange = new HoldingHandsRange(牵手点偏转角范围.LowerBound.Value, 牵手点偏转角范围.UpperBound.Value);
		FFloatRange 牵手点俯仰角范围 = asset.牵手点俯仰角范围;
		this.PitchRange = new HoldingHandsRange(牵手点俯仰角范围.LowerBound.Value, 牵手点俯仰角范围.UpperBound.Value);
		FFloatRange 肩部偏转角范围 = asset.肩部偏转角范围;
		this.ShoulderYawRange = new HoldingHandsRange(肩部偏转角范围.LowerBound.Value, 肩部偏转角范围.UpperBound.Value);
		FFloatRange 肩部俯仰角范围 = asset.肩部俯仰角范围;
		this.ShoulderPitchRange = new HoldingHandsRange(肩部俯仰角范围.LowerBound.Value, 肩部俯仰角范围.UpperBound.Value);
		this.ReachableExtraAngle = (double)asset.范围内额外角度;
		this.BindDistanceUnReachable = (double)asset.范围外牵手点最大距离;
		this.BindDistanceReachable = (double)asset.范围内牵手点最大距离;
		this.ReachableDistanceScale = (double)asset.范围内可达距离缩放;
		this.UnReachableDistanceScale = (double)asset.范围外可达距离缩放;
		this.ShoulderDeltaHeightReachable = (double)asset.范围内肩部最大高度差;
		this.ShoulderDeltaHeightUnReachable = (double)asset.范围外肩部最大高度差;
		this.LeaderHitPriority = asset.牵手者碰撞优先级;
		this.FollowerHitPriority = asset.被牵手者碰撞优先级;
		this.LeaderMass = asset.牵手者质量;
		this.FollowerMass = asset.被牵手者质量;
		this.InvitationDistance = (double)asset.邀请距离;
		this.InvitationDistanceTolerance = asset.邀请距离容差;
		this.InvitationEndDistance = (double)asset.邀请结束距离;
		this.InvitationEndDistanceTolerance = asset.邀请结束距离容差;
		this.InvitationEndMoveSpeed = asset.邀请结束移动速度;
		this.InvitationTurnSpeed = asset.邀请旋转速度;
		this.BindVecDampingInvitation = (double)asset.邀请时牵手点阻尼;
		this.HandMinAngle = (double)asset.手掌最小夹角;
		this.LeaderBindPosScale = (double)asset.牵手者牵手点位置缩放;
		this.FollowerBindPosScale = (double)asset.被牵手者牵手点位置缩放;
		this.BindPosDistance = (double)asset.贴合距离;
		this.KeepFollowingDa = asset.跟随配置;
	}

	// Token: 0x0400C7F9 RID: 51193
	public bool Debug;

	// Token: 0x0400C7FA RID: 51194
	public int ReachableTag;

	// Token: 0x0400C7FB RID: 51195
	public List<int> InvitingTags = new List<int>();

	// Token: 0x0400C7FC RID: 51196
	public List<int> LeadingTags = new List<int>();

	// Token: 0x0400C7FD RID: 51197
	public List<int> FollowingTags = new List<int>();

	// Token: 0x0400C7FE RID: 51198
	public List<int> DisableTags = new List<int>();

	// Token: 0x0400C7FF RID: 51199
	public double EndTime = 5.0;

	// Token: 0x0400C800 RID: 51200
	public double LongPressDuration = 1.0;

	// Token: 0x0400C801 RID: 51201
	public double IkAlphaDamping = 500.0;

	// Token: 0x0400C802 RID: 51202
	public double BindVecDamping = 100.0;

	// Token: 0x0400C803 RID: 51203
	public double BindVecDampingInvitation = 400.0;

	// Token: 0x0400C804 RID: 51204
	public double WalkRotateSpeedMax = 180.0;

	// Token: 0x0400C805 RID: 51205
	public double RunRotateSpeedMax = 180.0;

	// Token: 0x0400C806 RID: 51206
	public double InputScaleRun = 1.0;

	// Token: 0x0400C807 RID: 51207
	public HoldingHandsRange YawRange = new HoldingHandsRange(-90f, 90f);

	// Token: 0x0400C808 RID: 51208
	public HoldingHandsRange PitchRange = new HoldingHandsRange(-90f, 90f);

	// Token: 0x0400C809 RID: 51209
	public HoldingHandsRange ShoulderYawRange = new HoldingHandsRange(-90f, 90f);

	// Token: 0x0400C80A RID: 51210
	public HoldingHandsRange ShoulderPitchRange = new HoldingHandsRange(-90f, 90f);

	// Token: 0x0400C80B RID: 51211
	public double ReachableExtraAngle = 5.0;

	// Token: 0x0400C80C RID: 51212
	public double BindDistanceUnReachable = 10.0;

	// Token: 0x0400C80D RID: 51213
	public double BindDistanceReachable = 30.0;

	// Token: 0x0400C80E RID: 51214
	public double UnReachableDistanceScale = 0.8;

	// Token: 0x0400C80F RID: 51215
	public double ReachableDistanceScale = 1.0;

	// Token: 0x0400C810 RID: 51216
	public double ShoulderDeltaHeightUnReachable = 35.0;

	// Token: 0x0400C811 RID: 51217
	public double ShoulderDeltaHeightReachable = 40.0;

	// Token: 0x0400C812 RID: 51218
	public int LeaderHitPriority = 50;

	// Token: 0x0400C813 RID: 51219
	public int FollowerHitPriority = 49;

	// Token: 0x0400C814 RID: 51220
	public float LeaderMass = 90f;

	// Token: 0x0400C815 RID: 51221
	public float FollowerMass = 60f;

	// Token: 0x0400C816 RID: 51222
	public double InvitationDistance = 83.0;

	// Token: 0x0400C817 RID: 51223
	public float InvitationDistanceTolerance = 5f;

	// Token: 0x0400C818 RID: 51224
	public double InvitationEndDistance = 55.0;

	// Token: 0x0400C819 RID: 51225
	public float InvitationEndDistanceTolerance;

	// Token: 0x0400C81A RID: 51226
	public float InvitationEndMoveSpeed = 50f;

	// Token: 0x0400C81B RID: 51227
	public float InvitationTurnSpeed = 200f;

	// Token: 0x0400C81C RID: 51228
	public double HandMinAngle = 45.0;

	// Token: 0x0400C81D RID: 51229
	public double LeaderBindPosScale = 1.0;

	// Token: 0x0400C81E RID: 51230
	public double FollowerBindPosScale = 1.0;

	// Token: 0x0400C81F RID: 51231
	public double BindPosDistance = 2.0;

	// Token: 0x0400C820 RID: 51232
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public TSoftObjectPtr<BP_KeepFollowingConfig_C> KeepFollowingDa;
}
