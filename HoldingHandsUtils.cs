using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Entity.Enum;
using CSharpScript.Game.Utils;
using UnrealEngine;
using UnrealEngine.Extension;

// Token: 0x02001ECE RID: 7886
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class HoldingHandsUtils : Singleton<HoldingHandsUtils>
{
	// Token: 0x0600E90A RID: 59658 RVA: 0x003F1964 File Offset: 0x003EFB64
	public HoldingHandsUtils()
	{
		this.Debug = false;
		this.TempVector = Vector.Create();
		this.TempVector2 = Vector.Create();
		this.TempQuat = Quat.Create(0f, 0f, 0f, 1f);
		this.WorldOrigin = new FIntVector(0, 0, 0);
		this.ClavicleNames = new Dictionary<EHandType, FName>();
		this.ClavicleNames[EHandType.Left] = (FNameUtil.GetDynamicFName("Bip001LClavicle") ?? FNameUtil.EMPTY);
		this.ClavicleNames[EHandType.Right] = (FNameUtil.GetDynamicFName("Bip001RClavicle") ?? FNameUtil.EMPTY);
		this.ShoulderNames = new Dictionary<EHandType, FName>();
		this.ShoulderNames[EHandType.Left] = (FNameUtil.GetDynamicFName("Bip001LUpperArm") ?? FNameUtil.EMPTY);
		this.ShoulderNames[EHandType.Right] = (FNameUtil.GetDynamicFName("Bip001RUpperArm") ?? FNameUtil.EMPTY);
		this.HandNames = new Dictionary<EHandType, FName>();
		this.HandNames[EHandType.Left] = (FNameUtil.GetDynamicFName("Bip001LHand") ?? FNameUtil.EMPTY);
		this.HandNames[EHandType.Right] = (FNameUtil.GetDynamicFName("Bip001RHand") ?? FNameUtil.EMPTY);
		this.RingFingerNames = new Dictionary<EHandType, FName>();
		this.RingFingerNames[EHandType.Left] = (FNameUtil.GetDynamicFName("Bip001LFinger3") ?? FNameUtil.EMPTY);
		this.RingFingerNames[EHandType.Right] = (FNameUtil.GetDynamicFName("Bip001RFinger3") ?? FNameUtil.EMPTY);
		this.RingFingerNamesMs = new Dictionary<EHandType, FName>();
		this.RingFingerNamesMs[EHandType.Left] = (FNameUtil.GetDynamicFName("Bip001LFinger31") ?? FNameUtil.EMPTY);
		this.RingFingerNamesMs[EHandType.Right] = (FNameUtil.GetDynamicFName("Bip001RFinger31") ?? FNameUtil.EMPTY);
	}

	// Token: 0x0600E90B RID: 59659 RVA: 0x003F1BC4 File Offset: 0x003EFDC4
	[NullableContext(2)]
	public void UpdateBinding(Binding binding, double deltaTime)
	{
		if (binding == null || binding.State == EBindingState.None)
		{
			return;
		}
		binding.LastReachable = binding.Reachable;
		binding.Reachable = false;
		HandRuntime leaderRuntime = binding.LeaderRuntime;
		HandRuntime followerRuntime = binding.FollowerRuntime;
		if (binding.Leader == null || binding.Follower == null || leaderRuntime == null || followerRuntime == null)
		{
			return;
		}
		this.PrepareBindingRuntimeData(binding);
		double deltaTime2 = deltaTime;
		if (binding.NoLerpNextUpdate)
		{
			deltaTime2 = 2147483647.0;
			binding.NoLerpNextUpdate = false;
		}
		HoldingHandsParams @params = binding.Leader.Params;
		this.UpdateBindingReachable(binding, deltaTime2);
		if (binding.State == EBindingState.LeaderAnim)
		{
			leaderRuntime.BindVec.DeepCopy(leaderRuntime.AnimBindVec);
		}
		else if (!this.SolveTriangle(binding.ShoulderDeltaUnit, binding.ShoulderDelta.Size(), leaderRuntime.BendLength, followerRuntime.BendLength, binding.Down, leaderRuntime.BindVec))
		{
			leaderRuntime.BindVec = leaderRuntime.AnimBindVec;
		}
		leaderRuntime.BindVec.GetUnsafeNormal(leaderRuntime.BindDir);
		float reachableExtra = (float)binding.Leader.Params.ReachableExtraAngle;
		float reachableExtra2 = (float)binding.Follower.Params.ReachableExtraAngle;
		bool flag = binding.Reachable;
		this.ClampBindDir(leaderRuntime, binding.Leader.Params.PitchRange, binding.Leader.Params.YawRange, binding.LastReachable, reachableExtra);
		this.ClampShoulderDirection(leaderRuntime, binding.Leader.Params.ShoulderPitchRange, binding.Leader.Params.ShoulderYawRange, binding.LastReachable, reachableExtra);
		this.SmoothBindDir(leaderRuntime.BindDirSmooth, leaderRuntime.BindDir, binding.BindDirDamping, deltaTime2);
		leaderRuntime.BindDirSmooth.Multiply(leaderRuntime.BendLength, leaderRuntime.BindVec);
		leaderRuntime.Shoulder.GetLocation().Addition(leaderRuntime.BindVec, leaderRuntime.BindPos);
		leaderRuntime.BindPos.Subtraction(followerRuntime.Shoulder.GetLocation(), followerRuntime.BindVec);
		followerRuntime.BindVec.GetUnsafeNormal(followerRuntime.BindDir);
		followerRuntime.BendLength = Math.Min(followerRuntime.MaxBendLength, followerRuntime.BindVec.Size());
		flag = (flag && this.ClampBindDir(followerRuntime, binding.Follower.Params.PitchRange, binding.Follower.Params.YawRange, binding.LastReachable, reachableExtra2));
		flag = (flag && this.ClampShoulderDirection(followerRuntime, binding.Follower.Params.ShoulderPitchRange, binding.Follower.Params.ShoulderYawRange, binding.LastReachable, reachableExtra2));
		followerRuntime.BindDir.Multiply(followerRuntime.BendLength, followerRuntime.BindVec);
		followerRuntime.Shoulder.GetLocation().Addition(followerRuntime.BindVec, followerRuntime.BindPos);
		if (!flag)
		{
			followerRuntime.BindPos.Subtraction(leaderRuntime.Shoulder.GetLocation(), leaderRuntime.BindVec);
			leaderRuntime.BindVec.GetUnsafeNormal(leaderRuntime.BindDir);
			flag = this.ClampBindDir(leaderRuntime, binding.Leader.Params.PitchRange, binding.Leader.Params.YawRange, binding.LastReachable, reachableExtra);
			flag = (flag && this.ClampShoulderDirection(leaderRuntime, binding.Leader.Params.ShoulderPitchRange, binding.Leader.Params.ShoulderYawRange, binding.LastReachable, reachableExtra));
			if (!flag)
			{
				leaderRuntime.BendLength = Singleton<MathUtils>.Instance.InterpTo(leaderRuntime.BendLength, Math.Min(leaderRuntime.MaxBendLength, leaderRuntime.BindVec.Size()), deltaTime, 0.005);
			}
			this.SmoothBindDir(leaderRuntime.BindDirSmooth, leaderRuntime.BindDir, binding.BindDirDamping, deltaTime2);
			leaderRuntime.BindDirSmooth.Multiply(leaderRuntime.BendLength, leaderRuntime.BindVec);
			leaderRuntime.Shoulder.GetLocation().Addition(leaderRuntime.BindVec, leaderRuntime.BindPos);
		}
		followerRuntime.BindPos.Subtraction(leaderRuntime.BindPos, binding.BindPosDelta);
		if (!flag)
		{
			binding.Reachable = (binding.Reachable && binding.BindPosDelta.Size() < (binding.LastReachable ? @params.BindDistanceReachable : @params.BindDistanceUnReachable));
		}
		this.CalLeaderHandTarget(leaderRuntime, binding.Down, binding.State == EBindingState.LeaderAnim);
		this.CalFollowerHandTarget(followerRuntime, leaderRuntime, @params.BindPosDistance, @params.HandMinAngle);
		bool flag2 = this.CheckBindingObstacle(binding);
		binding.Reachable = (binding.Reachable && !flag2);
		bool flag3 = this.CheckHeightReachable(binding);
		binding.Reachable = (binding.Reachable && flag3);
		if (binding.Reachable && (this.Debug || binding.Leader.Params.Debug))
		{
			UKismetSystemLibrary.DrawDebugLine(GlobalData.World, leaderRuntime.BindPos.ToUeVectorOld(), leaderRuntime.HandPosTarget.ToUeVectorOld(), ColorUtils.LinearRed, 0f, 1f);
			UKismetSystemLibrary.DrawDebugLine(GlobalData.World, followerRuntime.BindPos.ToUeVectorOld(), followerRuntime.HandPosTarget.ToUeVectorOld(), ColorUtils.LinearBlue, 0f, 1f);
			UObject world = GlobalData.World;
			FVector lineStart = leaderRuntime.BindPos.ToUeVectorOld();
			FVector fvector = leaderRuntime.BindPos.ToUeVectorOld();
			FVector fvector2 = leaderRuntime.HandNormal.ToUeVectorOld();
			FVector fvector3 = fvector2 * 10f;
			UKismetSystemLibrary.DrawDebugLine(world, lineStart, fvector + fvector3, ColorUtils.LinearRed, 0f, 1f);
		}
		leaderRuntime.RootAfterIk.InverseTransformPosition(leaderRuntime.HandPosTarget, leaderRuntime.IkTarget.Location);
		leaderRuntime.RootAfterIk.InverseTransformRotation(leaderRuntime.HandRotTarget, leaderRuntime.IkTarget.Rotation);
		followerRuntime.RootAfterIk.InverseTransformPosition(followerRuntime.HandPosTarget, followerRuntime.IkTarget.Location);
		followerRuntime.RootAfterIk.InverseTransformRotation(followerRuntime.HandRotTarget, followerRuntime.IkTarget.Rotation);
		if (binding.Reachable)
		{
			leaderRuntime.TargetAlpha = (followerRuntime.TargetAlpha = 1f);
		}
		else
		{
			leaderRuntime.TargetAlpha = (followerRuntime.TargetAlpha = 0f);
		}
		leaderRuntime.LerpAlphas(binding.Leader.Params.IkAlphaDamping, deltaTime2);
		followerRuntime.LerpAlphas(binding.Follower.Params.IkAlphaDamping, deltaTime2);
		if (binding.Reachable)
		{
			binding.ReachableTime += deltaTime;
			binding.UnReachableTime = 0.0;
			return;
		}
		binding.ReachableTime = 0.0;
		binding.UnReachableTime += deltaTime;
	}

	// Token: 0x0600E90C RID: 59660 RVA: 0x003F224C File Offset: 0x003F044C
	private bool PrepareBindingRuntimeData(Binding binding)
	{
		HandRuntime leaderRuntime = binding.LeaderRuntime;
		HandRuntime followerRuntime = binding.FollowerRuntime;
		bool isMsBody = binding.Follower.ActorComp.CreatureData.GetModelConfig().体型类型 == EBodyType.FemaleMS;
		if (!this.PrepareRuntimeData(leaderRuntime, binding.Leader.AnimInstance, binding.Leader.SkelMesh, binding.Leader.Params, true, false) || !this.PrepareRuntimeData(followerRuntime, binding.Follower.AnimInstance, binding.Follower.SkelMesh, binding.Follower.Params, false, isMsBody))
		{
			return false;
		}
		binding.Down = Singleton<GravityUtils>.Instance.GetGravityDirectForActor(binding.Leader.ActorComp);
		followerRuntime.Shoulder.GetLocation().Subtraction(leaderRuntime.Shoulder.GetLocation(), binding.ShoulderDelta);
		double inB = binding.ShoulderDelta.Size();
		binding.ShoulderDelta.Division(inB, binding.ShoulderDeltaUnit);
		leaderRuntime.AnimBindPos.Subtraction(followerRuntime.Shoulder.GetLocation(), binding.FoShoulderToLeAnimBindPos);
		if (!binding.Updated)
		{
			leaderRuntime.BendLength = leaderRuntime.AnimBendLength;
			followerRuntime.BendLength = followerRuntime.AnimBendLength;
		}
		binding.Updated = true;
		return true;
	}

	// Token: 0x0600E90D RID: 59661 RVA: 0x003F2388 File Offset: 0x003F0588
	private bool PrepareRuntimeData(HandRuntime runtime, UKuroAnimInstanceChar animInstance, USkeletalMeshComponent skelMesh, HoldingHandsParams @params, bool isLeader, bool isMsBody)
	{
		EHandType handType = runtime.HandType;
		FName name = (!isMsBody) ? this.RingFingerNames[handType] : this.RingFingerNamesMs[handType];
		if (runtime.MaxBendLength == 0.0)
		{
			FName fname = this.ShoulderNames[handType];
			FTransform defaultBoneComponentPoseByName = UKuroAnimLibrary.GetDefaultBoneComponentPoseByName(skelMesh, fname);
			FVector location = UKuroAnimLibrary.GetDefaultBoneComponentPoseByName(skelMesh, name).GetLocation();
			FVector location2 = defaultBoneComponentPoseByName.GetLocation();
			runtime.MaxBendLength = (double)(location - location2).Size();
		}
		runtime.CachedClavicle = new FTransform?(animInstance.GetKuroCachedBoneTransform(this.ClavicleNames[handType]));
		runtime.CachedShoulder = new FTransform?(animInstance.GetKuroCachedBoneTransform(this.ShoulderNames[handType]));
		runtime.CachedHand = new FTransform?(animInstance.GetKuroCachedBoneTransform(this.HandNames[handType]));
		runtime.CachedRingFinger = new FTransform?(animInstance.GetKuroCachedBoneTransform(name));
		if (runtime.CachedClavicle == null || runtime.CachedShoulder == null || runtime.CachedHand == null || runtime.CachedRingFinger == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Character;
			ELogAuthor author = ELogAuthor.LJF;
			string message = "[HoldingHandsUtils.PrepareRuntimeData] KuroCacheBones未正确配置BoneName";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("AnimInstance", animInstance);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return false;
		}
		Transform rootAfterIk = runtime.RootAfterIk;
		FTransform ftransform = skelMesh.GetSocketTransform(FNameUtil.GetDynamicFName("Root") ?? FNameUtil.EMPTY, ERelativeTransformSpace.RTS_World);
		rootAfterIk.FromUeTransform(ftransform);
		Transform clavicle = runtime.Clavicle;
		ftransform = runtime.CachedClavicle.Value;
		clavicle.FromUeTransform(ftransform);
		runtime.Clavicle.ComposeTransforms(runtime.RootAfterIk, runtime.Clavicle);
		Transform shoulder = runtime.Shoulder;
		ftransform = runtime.CachedShoulder.Value;
		shoulder.FromUeTransform(ftransform);
		runtime.Shoulder.ComposeTransforms(runtime.RootAfterIk, runtime.Shoulder);
		Transform hand = runtime.Hand;
		ftransform = runtime.CachedHand.Value;
		hand.FromUeTransform(ftransform);
		runtime.Hand.ComposeTransforms(runtime.RootAfterIk, runtime.Hand);
		Transform ringFinger = runtime.RingFinger;
		ftransform = runtime.CachedRingFinger.Value;
		ringFinger.FromUeTransform(ftransform);
		runtime.RingFinger.ComposeTransforms(runtime.RootAfterIk, runtime.RingFinger);
		runtime.Hand.InverseTransformPosition(runtime.RingFinger.GetLocation(), runtime.FingerLocalPos);
		runtime.Hand.InverseTransformRotation(runtime.RingFinger.GetRotation(), runtime.FingerLocalRot);
		runtime.FingerLocalPos.Y = (runtime.FingerLocalPos.Z = 0.0);
		if (isLeader)
		{
			runtime.FingerLocalPos.X *= @params.LeaderBindPosScale;
		}
		else
		{
			runtime.FingerLocalPos.X *= @params.FollowerBindPosScale;
		}
		runtime.FingerOffsetSize = runtime.FingerLocalPos.X;
		runtime.Hand.TransformPosition(runtime.FingerLocalPos, runtime.AnimBindPos);
		runtime.AnimBindPos.Subtraction(runtime.Shoulder.GetLocation(), runtime.AnimBindVec);
		runtime.AnimBendLength = Math.Min(runtime.AnimBindVec.Size(), runtime.MaxBendLength);
		runtime.Hand.TransformVector(Vector.RightVectorProxy, runtime.AnimHandNormal);
		runtime.RingFinger.TransformVector(Vector.RightVectorProxy, runtime.AnimFingerNormal);
		runtime.Clavicle.TransformVector(Vector.RightVectorProxy, runtime.ClavicleDir);
		return true;
	}

	// Token: 0x0600E90E RID: 59662 RVA: 0x003F2714 File Offset: 0x003F0914
	private void UpdateBindingReachable(Binding binding, double deltaTime)
	{
		HandRuntime leaderRuntime = binding.LeaderRuntime;
		HandRuntime followerRuntime = binding.FollowerRuntime;
		HoldingHandsParams @params = binding.Leader.Params;
		bool flag = binding.State == EBindingState.LeaderAnim;
		double num = binding.ShoulderDelta.Size();
		double num2 = 1.0 / (binding.LastReachable ? @params.ReachableDistanceScale : @params.UnReachableDistanceScale);
		double num3 = num * num2;
		double num4 = (flag ? leaderRuntime.AnimBendLength : leaderRuntime.MaxBendLength) + followerRuntime.MaxBendLength;
		double num5 = num3 - num4;
		if (flag)
		{
			num5 = binding.FoShoulderToLeAnimBindPos.Size() - followerRuntime.MaxBendLength;
		}
		binding.ToReachableDistance = num5;
		binding.Reachable = (num5 < 0.0);
		this.ModifyBindingBendLength(binding, num3, deltaTime);
	}

	// Token: 0x0600E90F RID: 59663 RVA: 0x003F27D0 File Offset: 0x003F09D0
	private void ModifyBindingBendLength(Binding binding, double requiredLength, double deltaTime)
	{
		HandRuntime leaderRuntime = binding.LeaderRuntime;
		HandRuntime followerRuntime = binding.FollowerRuntime;
		bool flag = binding.State == EBindingState.LeaderAnim;
		double num = leaderRuntime.AnimBendLength + followerRuntime.AnimBendLength;
		double num2 = flag ? leaderRuntime.AnimBendLength : leaderRuntime.MaxBendLength;
		double num3 = num2 + followerRuntime.MaxBendLength;
		bool flag2 = requiredLength <= num;
		bool flag3 = !flag2 && requiredLength <= num3;
		if (flag)
		{
			double num4 = binding.FoShoulderToLeAnimBindPos.Size();
			flag2 = (num4 <= followerRuntime.AnimBendLength);
			flag3 = (!flag2 && num4 <= followerRuntime.MaxBendLength);
		}
		double bendLength = followerRuntime.AnimBendLength;
		double bendLength2 = leaderRuntime.AnimBendLength;
		if (flag2)
		{
			double num5 = Vector.DotProduct(binding.ShoulderDelta, binding.Down);
			double num6 = 1.0 - Math.Pow(Math.Abs(num5 / binding.ShoulderDelta.Size()), 2.0);
			num6 = Math.Max(num6, 0.2);
			double num7 = num - requiredLength;
			if (num5 > 0.0)
			{
				bendLength = Math.Max(followerRuntime.AnimBendLength * num6, followerRuntime.AnimBendLength - num7);
			}
			else
			{
				bendLength2 = Math.Max(leaderRuntime.AnimBendLength * num6, leaderRuntime.AnimBendLength - num7);
			}
		}
		else if (flag3)
		{
			double num8 = requiredLength - num;
			if (!flag)
			{
				double num9 = leaderRuntime.MaxBendLength - leaderRuntime.AnimBendLength;
				double num10 = followerRuntime.MaxBendLength - followerRuntime.AnimBendLength;
				double num11 = num8 * (num9 / (num9 + num10));
				double num12 = num8 * (num10 / (num9 + num10));
				bendLength = followerRuntime.AnimBendLength + num12;
				bendLength2 = leaderRuntime.AnimBendLength + num11;
			}
			else
			{
				bendLength = followerRuntime.AnimBendLength + num8;
			}
		}
		else
		{
			bendLength2 = num2 * 0.95;
			bendLength = followerRuntime.MaxBendLength * 0.95;
		}
		leaderRuntime.BendLength = bendLength2;
		followerRuntime.BendLength = bendLength;
	}

	// Token: 0x0600E910 RID: 59664 RVA: 0x003F29C0 File Offset: 0x003F0BC0
	private bool SolveTriangle(Vector abUnit, double abSize, double acSize, double bcSize, Vector vert, Vector @out)
	{
		if (abSize > acSize + bcSize)
		{
			return false;
		}
		double num = Singleton<MathUtils>.Instance.Clamp((acSize * acSize + abSize * abSize - bcSize * bcSize) / (2.0 * acSize * abSize), -1.0, 1.0);
		double num2 = Math.Sqrt(1.0 - num * num);
		Vector.CrossProduct(abUnit, vert, this.TempVector);
		Vector.CrossProduct(abUnit, this.TempVector, this.TempVector);
		this.TempVector.Normalize(9.99999993922529E-09);
		this.TempVector.Multiply(-num2 * acSize, this.TempVector);
		abUnit.Multiply(num * acSize, this.TempVector2);
		this.TempVector2.Addition(this.TempVector, @out);
		return true;
	}

	// Token: 0x0600E911 RID: 59665 RVA: 0x003F2A94 File Offset: 0x003F0C94
	private void SmoothBindDir(Vector inBindDir, Vector bindDirTarget, double damping, double deltaTime)
	{
		if (inBindDir.IsZero() || damping == 0.0)
		{
			inBindDir.DeepCopy(bindDirTarget);
			return;
		}
		inBindDir.X = Singleton<MathUtils>.Instance.InterpTo(inBindDir.X, bindDirTarget.X, deltaTime, 1.0 / damping);
		inBindDir.Y = Singleton<MathUtils>.Instance.InterpTo(inBindDir.Y, bindDirTarget.Y, deltaTime, 1.0 / damping);
		inBindDir.Z = Singleton<MathUtils>.Instance.InterpTo(inBindDir.Z, bindDirTarget.Z, deltaTime, 1.0 / damping);
		inBindDir.Normalize(9.99999993922529E-09);
	}

	// Token: 0x0600E912 RID: 59666 RVA: 0x003F2B48 File Offset: 0x003F0D48
	private bool ClampBindDir(HandRuntime runtime, HoldingHandsRange pitchRange, HoldingHandsRange yawRange, bool lastReachable, float reachableExtra)
	{
		float num = pitchRange.Min;
		float num2 = pitchRange.Max;
		float num3 = yawRange.Min;
		float num4 = yawRange.Max;
		if (lastReachable)
		{
			num -= reachableExtra;
			num2 += reachableExtra;
			num3 -= reachableExtra;
			num4 += reachableExtra;
		}
		runtime.RootAfterIk.InverseTransformVector(runtime.BindDir, runtime.BindDirRootSpace);
		if (runtime.HandType == EHandType.Right)
		{
			runtime.BindDirRootSpace.X = -runtime.BindDirRootSpace.X;
		}
		runtime.BindDirRootSpace.ToOrientationRotator(runtime.BindDirRsEuler);
		int num5 = (runtime.BindDirRsEuler.Pitch < num || runtime.BindDirRsEuler.Pitch > num2 || runtime.BindDirRsEuler.Yaw < num3 || runtime.BindDirRsEuler.Yaw > num4) ? 1 : 0;
		runtime.BindDirRsEuler.Pitch = Singleton<MathUtils>.Instance.Clamp(runtime.BindDirRsEuler.Pitch, num, num2);
		runtime.BindDirRsEuler.Yaw = Singleton<MathUtils>.Instance.Clamp(runtime.BindDirRsEuler.Yaw, num3, num4);
		runtime.BindDirRsEuler.Vector(runtime.BindDirRootSpace);
		if (runtime.HandType == EHandType.Right)
		{
			runtime.BindDirRootSpace.X = -runtime.BindDirRootSpace.X;
		}
		runtime.RootAfterIk.TransformVector(runtime.BindDirRootSpace, runtime.BindDir);
		return num5 == 0;
	}

	// Token: 0x0600E913 RID: 59667 RVA: 0x003F2C9C File Offset: 0x003F0E9C
	private bool ClampShoulderDirection(HandRuntime runtime, HoldingHandsRange pitchRange, HoldingHandsRange yawRange, bool lastReachable, float reachableExtra)
	{
		float num = pitchRange.Min;
		float num2 = pitchRange.Max;
		float num3 = yawRange.Min;
		float num4 = yawRange.Max;
		if (lastReachable)
		{
			num -= reachableExtra;
			num2 += reachableExtra;
			num3 -= reachableExtra;
			num4 += reachableExtra;
		}
		float num5 = num;
		float num6 = num2;
		if (runtime.HandType == EHandType.Right)
		{
			num = -num6;
			num2 = -num5;
		}
		Quat.FindBetweenVectors(runtime.AnimBindVec, runtime.BindDir, runtime.BindDirDeltaRot);
		runtime.Shoulder.GetRotation().RotateVector(Vector.ForwardVectorProxy, runtime.ShoulderDir);
		Quat.FindBetweenVectors(runtime.ShoulderDir, runtime.AnimBindVec, runtime.ArmDeltaRot);
		runtime.BindDirDeltaRot.RotateVector(runtime.ShoulderDir, runtime.ShoulderDir);
		runtime.Clavicle.InverseTransformVector(runtime.ShoulderDir, runtime.ShoulderDirLocal);
		runtime.ShoulderDirLocal.ToOrientationRotator(runtime.ShoulderLocalEuler);
		int num7 = (runtime.ShoulderLocalEuler.Pitch < num || runtime.ShoulderLocalEuler.Pitch > num2 || runtime.ShoulderLocalEuler.Yaw < num3 || runtime.ShoulderLocalEuler.Yaw > num4) ? 1 : 0;
		runtime.ShoulderLocalEuler.Pitch = Singleton<MathUtils>.Instance.Clamp(runtime.ShoulderLocalEuler.Pitch, num, num2);
		runtime.ShoulderLocalEuler.Yaw = Singleton<MathUtils>.Instance.Clamp(runtime.ShoulderLocalEuler.Yaw, num3, num4);
		runtime.ShoulderLocalEuler.Vector(runtime.ShoulderDirLocal);
		runtime.Clavicle.TransformVector(runtime.ShoulderDirLocal, runtime.ShoulderDir);
		runtime.ArmDeltaRot.RotateVector(runtime.ShoulderDir, runtime.BindDir);
		runtime.BindDir.Normalize(9.99999993922529E-09);
		return num7 == 0;
	}

	// Token: 0x0600E914 RID: 59668 RVA: 0x003F2E54 File Offset: 0x003F1054
	private void GetLeaderHandNormal(Vector targetDir, Vector right, Vector down, Vector animNormal, Vector @out)
	{
		Vector.CrossProduct(targetDir, down, @out);
		@out.Normalize(9.99999993922529E-09);
		@out.MultiplyEqual(-1.0);
		Vector.CrossProduct(right, down, this.TempVector);
		this.TempVector.MultiplyEqual(-1.0);
		if (Vector.DotProduct(targetDir, this.TempVector) > 0.0)
		{
			double num = Vector.DotProduct(@out, right);
			right.Multiply(num * 2.0, this.TempVector2);
			@out.SubtractionEqual(this.TempVector2);
		}
		double num2 = Vector.DotProduct(@out, animNormal);
		if (num2 < 0.0)
		{
			animNormal.GetSafeNormal(this.TempVector2, 9.99999993922529E-09);
			this.TempVector2.MultiplyEqual(num2 * 2.0);
			@out.SubtractionEqual(this.TempVector2);
		}
		Vector.Lerp(animNormal, @out, 0.5, @out);
	}

	// Token: 0x0600E915 RID: 59669 RVA: 0x003F2F5C File Offset: 0x003F115C
	private void CalLeaderHandTarget(HandRuntime runtime, Vector gravity, bool useLeaderAnim)
	{
		if (useLeaderAnim)
		{
			runtime.HandNormal = runtime.AnimHandNormal;
		}
		else
		{
			this.GetLeaderHandNormal(runtime.BindVec, runtime.ClavicleDir, gravity, runtime.AnimFingerNormal, runtime.FingerNormal);
			runtime.FingerLocalRot.UnRotateVector(runtime.FingerNormal, runtime.HandNormal);
		}
		Quat.FindBetweenVectors(runtime.AnimBindVec, runtime.BindVec, runtime.BindDirDeltaRot);
		runtime.AnimBindPos.Subtraction(runtime.Hand.GetLocation(), this.TempVector);
		runtime.BindDirDeltaRot.RotateVector(this.TempVector, this.TempVector);
		runtime.BindPos.Subtraction(this.TempVector, runtime.HandPosTarget);
		this.TempVector.CrossProduct(runtime.HandNormal, this.TempVector2);
		Singleton<MathUtils>.Instance.LookRotationForwardFirst(this.TempVector, this.TempVector2, runtime.HandRotTarget);
	}

	// Token: 0x0600E916 RID: 59670 RVA: 0x003F3048 File Offset: 0x003F1248
	private void CalFollowerHandTarget(HandRuntime foRuntime, HandRuntime leRuntime, double bindPosDistance, double minAngle)
	{
		leRuntime.FingerNormal.Multiply(-1.0, foRuntime.FingerNormal);
		foRuntime.FingerLocalRot.UnRotateVector(foRuntime.FingerNormal, foRuntime.HandNormal);
		foRuntime.FingerNormal.Multiply(bindPosDistance, this.TempVector);
		foRuntime.BindPos.Addition(this.TempVector, foRuntime.BindPos);
		leRuntime.FingerNormal.Multiply(Vector.DotProduct(foRuntime.BindVec, leRuntime.FingerNormal), this.TempVector);
		foRuntime.BindVec.Subtraction(this.TempVector, foRuntime.BindVecOnNormal);
		foRuntime.BindVecOnNormal.Normalize(9.99999993922529E-09);
		leRuntime.FingerNormal.Multiply(Vector.DotProduct(leRuntime.BindVec, leRuntime.FingerNormal), this.TempVector);
		leRuntime.BindVec.Subtraction(this.TempVector, leRuntime.BindVecOnNormal);
		leRuntime.BindVecOnNormal.Normalize(9.99999993922529E-09);
		double num = Math.Acos(Vector.DotProduct(leRuntime.BindVecOnNormal, foRuntime.BindVecOnNormal));
		Vector.CrossProduct(leRuntime.BindVecOnNormal, foRuntime.BindVecOnNormal, this.TempVector);
		if (Vector.DotProduct(this.TempVector, leRuntime.FingerNormal) < 0.0)
		{
			num = -num;
		}
		double num2 = minAngle * 0.01745329238474369;
		if (num < 0.0)
		{
			num = Math.Min(-num2, num);
		}
		else
		{
			num = Math.Max(num2, num);
		}
		Quat.ConstructorByAxisAngle(leRuntime.FingerNormal, (float)num, this.TempQuat);
		leRuntime.BindPos.Subtraction(leRuntime.HandPosTarget, this.TempVector);
		this.TempQuat.RotateVector(this.TempVector, this.TempVector);
		this.TempVector.Normalize(9.99999993922529E-09);
		this.TempVector.MultiplyEqual(foRuntime.FingerOffsetSize);
		foRuntime.BindPos.Subtraction(this.TempVector, foRuntime.HandPosTarget);
		this.TempVector.CrossProduct(foRuntime.HandNormal, this.TempVector2);
		Singleton<MathUtils>.Instance.LookRotationForwardFirst(this.TempVector, this.TempVector2, foRuntime.HandRotTarget);
	}

	// Token: 0x0600E917 RID: 59671 RVA: 0x003F3280 File Offset: 0x003F1480
	private bool CheckBindingObstacle(Binding binding)
	{
		CharacterHoldingHandsComponent leader = binding.Leader;
		if (leader == null)
		{
			return false;
		}
		if (leader.TraceElement == null)
		{
			leader.CreateTraceElement();
		}
		UTraceSphereElement traceElement = leader.TraceElement;
		bool flag = this.Debug || leader.Params.Debug;
		traceElement.ActorsToIgnore.Empty(true);
		foreach (AActor value in ModelBase<WorldModel>.Instance.ActorsToIgnoreSet)
		{
			traceElement.ActorsToIgnore.Add(value);
		}
		traceElement.WorldContextObject = GlobalData.World;
		Vector handPosTarget = binding.LeaderRuntime.HandPosTarget;
		Vector handPosTarget2 = binding.FollowerRuntime.HandPosTarget;
		this.WorldOrigin = UGameplayStatics.GetWorldOriginLocation(GlobalData.World.GetWorld());
		FVector fvector = new FVector((float)this.WorldOrigin.X, (float)this.WorldOrigin.Y, (float)this.WorldOrigin.Z);
		this.TempVector.FromUeVector(fvector);
		this.TempVector.AdditionEqual(handPosTarget);
		this.TempVector2.FromUeVector(fvector);
		this.TempVector2.AdditionEqual(handPosTarget2);
		Singleton<TraceElementCommon>.Instance.SetStartLocation(traceElement, this.TempVector);
		Singleton<TraceElementCommon>.Instance.SetEndLocation(traceElement, this.TempVector2);
		bool flag2 = Singleton<TraceElementCommon>.Instance.SphereTrace(traceElement, "CharacterHoldingHandsComponent.CheckBindingObstacle");
		if (flag2 && flag)
		{
			UKismetSystemLibrary.D_DrawDebugLine(GlobalData.World, this.TempVector.ToUeVector(false), this.TempVector2.ToUeVector(false), ColorUtils.LinearRed, 0f, 1f);
			Singleton<Log>.Instance.Info(ELogModule.Character, ELogAuthor.LJF, "[HoldingHandsUtils] CheckBindingObstacle", default(ReadOnlySpan<ValueTuple<string, object>>));
		}
		return flag2;
	}

	// Token: 0x0600E918 RID: 59672 RVA: 0x003F3444 File Offset: 0x003F1644
	private bool CheckHeightReachable(Binding binding)
	{
		CharacterActorComponent actorComp = binding.Leader.ActorComp;
		CharacterActorComponent actorComp2 = binding.Follower.ActorComp;
		Vector actorLocationProxy = actorComp.ActorLocationProxy;
		Vector actorLocationProxy2 = actorComp2.ActorLocationProxy;
		Vector tempVector = this.TempVector;
		actorLocationProxy.Subtraction(actorLocationProxy2, tempVector);
		Vector gravityDirectForActor = Singleton<GravityUtils>.Instance.GetGravityDirectForActor(actorComp);
		double num = Math.Abs(Vector.DotProduct(tempVector, gravityDirectForActor));
		double num2 = (double)Math.Min(actorComp.HalfHeight, actorComp2.HalfHeight);
		Vector tempVector2 = this.TempVector;
		binding.LeaderRuntime.Shoulder.GetLocation().Subtraction(binding.FollowerRuntime.Shoulder.GetLocation(), tempVector2);
		double num3 = Math.Abs(Vector.DotProduct(tempVector2, gravityDirectForActor));
		double num4 = binding.LastReachable ? binding.Leader.Params.ShoulderDeltaHeightReachable : binding.Leader.Params.ShoulderDeltaHeightUnReachable;
		return num < num2 && num3 < num4;
	}

	// Token: 0x04007083 RID: 28803
	public readonly bool Debug;

	// Token: 0x04007084 RID: 28804
	public Vector TempVector;

	// Token: 0x04007085 RID: 28805
	public Vector TempVector2;

	// Token: 0x04007086 RID: 28806
	public Quat TempQuat;

	// Token: 0x04007087 RID: 28807
	public FIntVector WorldOrigin;

	// Token: 0x04007088 RID: 28808
	private Dictionary<EHandType, FName> ClavicleNames;

	// Token: 0x04007089 RID: 28809
	private Dictionary<EHandType, FName> ShoulderNames;

	// Token: 0x0400708A RID: 28810
	private Dictionary<EHandType, FName> HandNames;

	// Token: 0x0400708B RID: 28811
	private Dictionary<EHandType, FName> RingFingerNames;

	// Token: 0x0400708C RID: 28812
	private Dictionary<EHandType, FName> RingFingerNamesMs;
}
