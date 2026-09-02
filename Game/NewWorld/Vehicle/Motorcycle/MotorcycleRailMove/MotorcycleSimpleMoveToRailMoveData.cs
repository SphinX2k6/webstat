using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.NewWorld.Common.Component;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.Vehicle.Motorcycle.MotorcycleRailMove
{
	// Token: 0x020047CF RID: 18383
	[NullableContext(1)]
	[Nullable(0)]
	public class MotorcycleSimpleMoveToRailMoveData : MotorcycleRailMoveDataBase
	{
		// Token: 0x0602FB02 RID: 195330 RVA: 0x00B67D60 File Offset: 0x00B65F60
		public MotorcycleSimpleMoveToRailMoveData(Entity owner, [Nullable(2)] MotorcycleRailComponent relatedRail) : base(EMotorcycleRailMoveDataType.SimpleMoveToRail, owner, relatedRail)
		{
		}

		// Token: 0x170081D5 RID: 33237
		// (get) Token: 0x0602FB03 RID: 195331 RVA: 0x00B67E22 File Offset: 0x00B66022
		private DirectlyEnterRailConfig DirectlyEnterRailConfig
		{
			get
			{
				return this.MoveConfig.DirectlyEnterRailConfig;
			}
		}

		// Token: 0x170081D6 RID: 33238
		// (get) Token: 0x0602FB04 RID: 195332 RVA: 0x00B67E2F File Offset: 0x00B6602F
		private LinearMoveConfig LinearMoveConfig
		{
			get
			{
				return this.MoveConfig.DirectlyEnterRailConfig.LinearMoveConfig;
			}
		}

		// Token: 0x170081D7 RID: 33239
		// (get) Token: 0x0602FB05 RID: 195333 RVA: 0x00B67E41 File Offset: 0x00B66041
		private CommonConfig CommonConfig
		{
			get
			{
				return this.MoveConfig.DirectlyEnterRailConfig.CommonConfig;
			}
		}

		// Token: 0x170081D8 RID: 33240
		// (get) Token: 0x0602FB06 RID: 195334 RVA: 0x00B67E53 File Offset: 0x00B66053
		private BasicRailMoveConfig BasicRailMoveConfig
		{
			get
			{
				return this.MoveConfig.BasicRailMoveConfig;
			}
		}

		// Token: 0x0602FB07 RID: 195335 RVA: 0x00B67E60 File Offset: 0x00B66060
		[NullableContext(2)]
		public override bool OnEnter(MotorcycleRailMoveDataBase lastRailMoveData)
		{
			if (this.TargetSpline == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.MotorRailMove;
				ELogAuthor author = ELogAuthor.ZYL;
				string message = "[MotorcycleSimpleMoveToRailMoveData] OnEnter Failed: Spline is undefined";
				string item = "SplineId";
				MotorcycleRailComponent relatedRail = this.RelatedRail;
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>(item, (relatedRail != null) ? new int?(relatedRail.GetRailSplineId()) : null);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return false;
			}
			Rotator tmpRotator = this.TmpRotator1;
			if (this.MoveGetter == null || !this.MoveGetter(this.StartLocation, tmpRotator, null))
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.MotorRailMove;
				ELogAuthor author2 = ELogAuthor.ZYL;
				string message2 = "[MotorcycleSimpleMoveToRailMoveData] OnEnter Failed: 拿不到位置旋转";
				string item2 = "SplineId";
				MotorcycleRailComponent relatedRail2 = this.RelatedRail;
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>(item2, (relatedRail2 != null) ? new int?(relatedRail2.GetRailSplineId()) : null);
				instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				return false;
			}
			tmpRotator.Quaternion(this.StartQuat);
			this.RailMoveContext.SourceLoc.FromUeVector(this.StartLocation);
			this.StartQuat.Rotator(this.RailMoveContext.SourceRot);
			this.RailMoveContext.RailSpline = this.TargetSpline;
			if ((lastRailMoveData == null || !lastRailMoveData.GetVelocity(this.RailMoveContext.SourceVel)) && (this.MoveGetter == null || !this.MoveGetter(null, null, this.RailMoveContext.SourceVel)))
			{
				Log instance3 = Singleton<Log>.Instance;
				ELogModule module3 = ELogModule.MotorRailMove;
				ELogAuthor author3 = ELogAuthor.ZYL;
				string message3 = "[MotorcycleSimpleMoveToRailMoveData] OnEnter Failed: 拿不到速度";
				string item3 = "SplineId";
				MotorcycleRailComponent relatedRail3 = this.RelatedRail;
				ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>(item3, (relatedRail3 != null) ? new int?(relatedRail3.GetRailSplineId()) : null);
				instance3.Error(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
				return false;
			}
			if (this.RailMoveContext.SourceVel.IsNearlyZero(1.0))
			{
				this.RailMoveContext.SourceVel.Reset();
			}
			List<TRailMoveChecker> checkList = new List<TRailMoveChecker>
			{
				new TRailMoveChecker(Singleton<MotorcycleRailMoveUtils>.Instance.RailMoveCheckerCheckVehicleNotReverseMove),
				new TRailMoveChecker(Singleton<MotorcycleRailMoveUtils>.Instance.RailMoveCheckerCheckAngleBetweenVehicleUpAndRailUp),
				new TRailMoveChecker(Singleton<MotorcycleRailMoveUtils>.Instance.RailMoveCheckerCheckAngleBetweenVehicleForwardAndRailTangent),
				new TRailMoveChecker(Singleton<MotorcycleRailMoveUtils>.Instance.RailMoveCheckerCheckAngleBetweenVehicleVelocityAndRailTangent),
				Singleton<MotorcycleRailMoveUtils>.Instance.RailMoveCheckerCheckRailLenLeft,
				new TRailMoveChecker(Singleton<MotorcycleRailMoveUtils>.Instance.RailMoveCheckerCheckRelativeLocation)
			};
			this.RailMoveContext.IsForward = true;
			bool flag = Singleton<MotorcycleRailMoveUtils>.Instance.CalcRailMoveTargetNotAdvanceBySpeed(this.RailMoveContext, (double)this.DirectlyEnterRailConfig.LinearMoveConfig.MinSpeed, (double)this.DirectlyEnterRailConfig.LinearMoveConfig.MaxSpeed);
			if (flag)
			{
				flag = Singleton<MotorcycleRailMoveUtils>.Instance.ExecCheckList(this.RailMoveContext, this.DirectlyEnterRailConfig.EnterRailCondition, checkList, true, base.GetType().Name);
			}
			if (!flag)
			{
				this.RailMoveContext.IsForward = false;
				flag = Singleton<MotorcycleRailMoveUtils>.Instance.CalcRailMoveTargetNotAdvanceBySpeed(this.RailMoveContext, (double)this.DirectlyEnterRailConfig.LinearMoveConfig.MinSpeed, (double)this.DirectlyEnterRailConfig.LinearMoveConfig.MaxSpeed);
				if (flag)
				{
					flag = Singleton<MotorcycleRailMoveUtils>.Instance.ExecCheckList(this.RailMoveContext, this.DirectlyEnterRailConfig.EnterRailCondition, checkList, true, base.GetType().Name);
				}
			}
			if (!flag)
			{
				Log instance4 = Singleton<Log>.Instance;
				ELogModule module4 = ELogModule.MotorRailMove;
				ELogAuthor author4 = ELogAuthor.ZYL;
				string message4 = "[MotorcycleSimpleMoveToRailMoveData] OnEnter Failed: 计算终点并检查失败";
				string item4 = "SplineId";
				MotorcycleRailComponent relatedRail4 = this.RelatedRail;
				ValueTuple<string, object> valueTuple4 = new ValueTuple<string, object>(item4, (relatedRail4 != null) ? new int?(relatedRail4.GetRailSplineId()) : null);
				instance4.Warn(module4, author4, message4, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple4));
				return false;
			}
			this.TargetLocation.FromUeVector(this.RailMoveContext.RailMoveTarget.TargetLoc);
			this.RailMoveContext.RailMoveTarget.TargetRot.Quaternion(this.TargetQuat);
			Vector tmpVector = this.TmpVector1;
			this.TargetLocation.Subtraction(this.StartLocation, tmpVector);
			double num = tmpVector.Size();
			tmpVector.Normalize(9.99999993922529E-09);
			double num2 = this.RailMoveContext.SourceVel.DotProduct(tmpVector);
			if (Singleton<MathUtils>.Instance.IsNearlyZero(num2, null) || num2 < 0.0)
			{
				num2 = (double)this.BasicRailMoveConfig.DefaultMoveSpeed;
			}
			num2 = Singleton<MathUtils>.Instance.Clamp(num2, (double)this.LinearMoveConfig.MinSpeed, (double)this.LinearMoveConfig.MaxSpeed);
			tmpVector.Multiply(num2, this.Velocity);
			this.Time = (float)(num / num2);
			BaseTagComponent component = this.OwnerEntity.GetComponent<BaseTagComponent>();
			foreach (KeyValuePair<int, bool> keyValuePair in this.DirectlyEnterRailConfig.CommonConfig.ModifyVehicleTagsOnEnter)
			{
				int num3;
				bool flag2;
				keyValuePair.Deconstruct(out num3, out flag2);
				int value = num3;
				if (flag2)
				{
					if (component != null)
					{
						component.AddTag(new int?(value));
					}
				}
				else if (component != null)
				{
					component.RemoveTag(new int?(value));
				}
			}
			return true;
		}

		// Token: 0x0602FB08 RID: 195336 RVA: 0x00B68370 File Offset: 0x00B66570
		public override void OnExit()
		{
			BaseTagComponent component = this.OwnerEntity.GetComponent<BaseTagComponent>();
			foreach (KeyValuePair<int, bool> keyValuePair in this.DirectlyEnterRailConfig.CommonConfig.ModifyVehicleTagsOnExit)
			{
				int num;
				bool flag;
				keyValuePair.Deconstruct(out num, out flag);
				int value = num;
				if (flag)
				{
					if (component != null)
					{
						component.AddTag(new int?(value));
					}
				}
				else if (component != null)
				{
					component.RemoveTag(new int?(value));
				}
			}
		}

		// Token: 0x0602FB09 RID: 195337 RVA: 0x00B68408 File Offset: 0x00B66608
		public override void OnTick(float deltaSeconds)
		{
			this.TickUpdateMove(deltaSeconds);
			this.UpdateIsBlocked(deltaSeconds);
			this.ApplyMove();
			this.UpdateIsFinishMove();
		}

		// Token: 0x0602FB0A RID: 195338 RVA: 0x00B68424 File Offset: 0x00B66624
		public override bool GetVelocity(Vector outVelocity)
		{
			outVelocity.DeepCopy(this.Velocity);
			return true;
		}

		// Token: 0x0602FB0B RID: 195339 RVA: 0x00B68434 File Offset: 0x00B66634
		public void TickUpdateMove(float deltaSeconds)
		{
			float num = Math.Min(this.Time - this.CurrentTime, deltaSeconds);
			num = Math.Min(num, this.BasicRailMoveConfig.MaxDeltaTimeForMoveUpdate);
			this.CurrentTime += num;
			this.Velocity.Multiply((double)this.CurrentTime, this.CurrentLocation);
			this.CurrentLocation.AdditionEqual(this.StartLocation);
			Quat.Slerp(this.StartQuat, this.TargetQuat, this.CurrentTime / this.Time, Singleton<MathUtils>.Instance.CommonTempQuat);
			Singleton<MathUtils>.Instance.CommonTempQuat.Rotator(this.CurrentRotator);
		}

		// Token: 0x0602FB0C RID: 195340 RVA: 0x00B684E0 File Offset: 0x00B666E0
		private void ApplyMove()
		{
			if (this.CommonConfig.EnableBlockingCheck && this.IsBlocked)
			{
				return;
			}
			Vector tmpVector = this.TmpVector1;
			bool velocity = this.GetVelocity(tmpVector);
			TRailMoveUpdater moveUpdater = this.MoveUpdater;
			if (moveUpdater == null)
			{
				return;
			}
			moveUpdater(this.CurrentLocation, this.CurrentRotator, velocity ? tmpVector : null, this.CommonConfig.EnableBlockingCheck);
		}

		// Token: 0x0602FB0D RID: 195341 RVA: 0x00B68540 File Offset: 0x00B66740
		private void UpdateIsFinishMove()
		{
			if (this.CommonConfig.EnableBlockingCheck && this.IsBlocked && this.BlockingTime > this.CommonConfig.MaxBlockingTimeOut)
			{
				this.IsFinishMove = true;
				this.IsFinishMoveOnFailure = true;
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.MotorRailMove;
				ELogAuthor author = ELogAuthor.ZYL;
				string message = "[MotorcycleSimpleMoveToRailMoveData] Finish move on blocking";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("BlockingTime", this.BlockingTime);
				instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			this.IsFinishMove = (this.CurrentTime >= this.Time);
		}

		// Token: 0x0602FB0E RID: 195342 RVA: 0x00B685D0 File Offset: 0x00B667D0
		private void UpdateIsBlocked(float deltaSeconds)
		{
			if (!this.CommonConfig.EnableBlockingCheck)
			{
				return;
			}
			if (this.IsFinishMove)
			{
				return;
			}
			bool component = this.OwnerEntity.GetComponent<VehicleActorComponent>() != null;
			VehicleMoveComponent component2 = this.OwnerEntity.GetComponent<VehicleMoveComponent>();
			if (!component || component2 == null || component2.VehicleMovement == null)
			{
				return;
			}
			bool isBlocked = this.IsBlocked;
			this.TmpTransform1.Set(this.CurrentLocation, this.CurrentRotator.Quaternion(null), Vector.OneVectorProxy);
			this.IsBlocked = !component2.VehicleMovement.IsValidTransform(this.TmpTransform1.ToUeTransform(), new TArray<AActor>());
			if (this.IsBlocked)
			{
				float num = isBlocked ? Math.Min(deltaSeconds, this.BasicRailMoveConfig.MaxDeltaTimeForMoveUpdate) : 0f;
				this.BlockingTime += num;
				return;
			}
			this.BlockingTime = 0f;
		}

		// Token: 0x0401B4FD RID: 111869
		public readonly MotorcycleRailMoveConfig MoveConfig = new MotorcycleRailMoveConfig();

		// Token: 0x0401B4FE RID: 111870
		[Nullable(2)]
		public SplineCurve TargetSpline;

		// Token: 0x0401B4FF RID: 111871
		[Nullable(2)]
		public TRailMoveUpdater MoveUpdater;

		// Token: 0x0401B500 RID: 111872
		[Nullable(2)]
		public TRailMoveGetter MoveGetter;

		// Token: 0x0401B501 RID: 111873
		private readonly Vector StartLocation = Vector.Create();

		// Token: 0x0401B502 RID: 111874
		private readonly Vector TargetLocation = Vector.Create();

		// Token: 0x0401B503 RID: 111875
		private readonly Vector Velocity = Vector.Create();

		// Token: 0x0401B504 RID: 111876
		private readonly Quat StartQuat = Quat.Create(0f, 0f, 0f, 1f);

		// Token: 0x0401B505 RID: 111877
		private readonly Quat TargetQuat = Quat.Create(0f, 0f, 0f, 1f);

		// Token: 0x0401B506 RID: 111878
		private float Time;

		// Token: 0x0401B507 RID: 111879
		private float CurrentTime;

		// Token: 0x0401B508 RID: 111880
		private readonly Vector CurrentLocation = Vector.Create();

		// Token: 0x0401B509 RID: 111881
		private readonly Rotator CurrentRotator = Rotator.Create();

		// Token: 0x0401B50A RID: 111882
		private readonly RailMoveContext RailMoveContext = new RailMoveContext();

		// Token: 0x0401B50B RID: 111883
		private readonly Vector TmpVector1 = Vector.Create();

		// Token: 0x0401B50C RID: 111884
		private readonly Rotator TmpRotator1 = Rotator.Create();

		// Token: 0x0401B50D RID: 111885
		private readonly Transform TmpTransform1 = Transform.Create();

		// Token: 0x0401B50E RID: 111886
		private bool IsBlocked;

		// Token: 0x0401B50F RID: 111887
		private float BlockingTime;
	}
}
