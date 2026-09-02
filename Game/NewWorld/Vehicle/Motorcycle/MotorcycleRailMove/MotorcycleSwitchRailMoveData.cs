using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.NewWorld.Common.Component;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.Vehicle.Motorcycle.MotorcycleRailMove
{
	// Token: 0x020047D0 RID: 18384
	[NullableContext(1)]
	[Nullable(0)]
	public class MotorcycleSwitchRailMoveData : MotorcycleRailMoveDataBase
	{
		// Token: 0x0602FB0F RID: 195343 RVA: 0x00B686A4 File Offset: 0x00B668A4
		public MotorcycleSwitchRailMoveData(Entity owner, [Nullable(2)] MotorcycleRailComponent relatedRail) : base(EMotorcycleRailMoveDataType.SwitchRail, owner, relatedRail)
		{
		}

		// Token: 0x170081D9 RID: 33241
		// (get) Token: 0x0602FB10 RID: 195344 RVA: 0x00B6876A File Offset: 0x00B6696A
		private SwitchRailConfig SwitchRailConfig
		{
			get
			{
				return this.MoveConfig.SwitchRailConfig;
			}
		}

		// Token: 0x170081DA RID: 33242
		// (get) Token: 0x0602FB11 RID: 195345 RVA: 0x00B68777 File Offset: 0x00B66977
		private ParabolaMoveConfig ParabolaMoveConfig
		{
			get
			{
				return this.MoveConfig.SwitchRailConfig.ParabolaMoveConfig;
			}
		}

		// Token: 0x170081DB RID: 33243
		// (get) Token: 0x0602FB12 RID: 195346 RVA: 0x00B68789 File Offset: 0x00B66989
		private CommonConfig CommonConfig
		{
			get
			{
				return this.MoveConfig.SwitchRailConfig.CommonConfig;
			}
		}

		// Token: 0x170081DC RID: 33244
		// (get) Token: 0x0602FB13 RID: 195347 RVA: 0x00B6879B File Offset: 0x00B6699B
		private BasicRailMoveConfig BasicRailMoveConfig
		{
			get
			{
				return this.MoveConfig.BasicRailMoveConfig;
			}
		}

		// Token: 0x0602FB14 RID: 195348 RVA: 0x00B687A8 File Offset: 0x00B669A8
		public override void OnTick(float deltaSeconds)
		{
			this.TickUpdateMove(deltaSeconds);
			this.UpdateIsBlocked(deltaSeconds);
			this.ApplyMove();
			this.UpdateIsFinishMove();
		}

		// Token: 0x0602FB15 RID: 195349 RVA: 0x00B687C4 File Offset: 0x00B669C4
		[NullableContext(2)]
		public unsafe override bool OnEnter(MotorcycleRailMoveDataBase lastRailMoveData)
		{
			if (this.TargetSpline == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.MotorRailMove;
				ELogAuthor author = ELogAuthor.ZYL;
				string message = "[MotorcycleSwitchRailMoveData] OnEnter Failed: Spline is undefined";
				string item = "SplineId";
				MotorcycleRailComponent relatedRail = this.RelatedRail;
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>(item, (relatedRail != null) ? new int?(relatedRail.GetRailSplineId()) : null);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return false;
			}
			if (this.ParabolaMoveConfig.Duration <= 0f)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.MotorRailMove;
				ELogAuthor author2 = ELogAuthor.ZYL;
				string message2 = "[MotorcycleSwitchRailMoveData] OnEnter Failed: Duration有误";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0);
				string item2 = "SplineId";
				MotorcycleRailComponent relatedRail2 = this.RelatedRail;
				ptr = new ValueTuple<string, object>(item2, (relatedRail2 != null) ? new int?(relatedRail2.GetRailSplineId()) : null);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Duration", this.ParabolaMoveConfig.Duration);
				instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return false;
			}
			if (this.MoveGetter == null || !this.MoveGetter(this.StartLocation, this.StartRotation, null))
			{
				Log instance3 = Singleton<Log>.Instance;
				ELogModule module3 = ELogModule.MotorRailMove;
				ELogAuthor author3 = ELogAuthor.ZYL;
				string message3 = "[MotorcycleSwitchRailMoveData] OnEnter Failed: 拿不到位置旋转";
				string item3 = "SplineId";
				MotorcycleRailComponent relatedRail3 = this.RelatedRail;
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>(item3, (relatedRail3 != null) ? new int?(relatedRail3.GetRailSplineId()) : null);
				instance3.Error(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				return false;
			}
			this.CurrentLocation.FromUeVector(this.StartLocation);
			this.CurrentRotator.FromUeRotator(this.StartRotation);
			this.RailMoveContext.SourceLoc.FromUeVector(this.StartLocation);
			this.RailMoveContext.SourceRot.FromUeRotator(this.StartRotation);
			this.RailMoveContext.RailSpline = this.TargetSpline;
			if ((lastRailMoveData == null || !lastRailMoveData.GetVelocity(this.RailMoveContext.SourceVel)) && (this.MoveGetter == null || !this.MoveGetter(null, null, this.RailMoveContext.SourceVel)))
			{
				Log instance4 = Singleton<Log>.Instance;
				ELogModule module4 = ELogModule.MotorRailMove;
				ELogAuthor author4 = ELogAuthor.ZYL;
				string message4 = "[MotorcycleSwitchRailMoveData] OnEnter Failed: 拿不到速度";
				string item4 = "SplineId";
				MotorcycleRailComponent relatedRail4 = this.RelatedRail;
				ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>(item4, (relatedRail4 != null) ? new int?(relatedRail4.GetRailSplineId()) : null);
				instance4.Error(module4, author4, message4, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
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
			bool flag = Singleton<MotorcycleRailMoveUtils>.Instance.CalcRailMoveTargetAdvanceBySpeed(this.RailMoveContext, (double)this.ParabolaMoveConfig.Duration, (double)this.ParabolaMoveConfig.MinSpeedAlongRail, (double)this.ParabolaMoveConfig.MaxSpeedAlongRail);
			if (flag)
			{
				flag = Singleton<MotorcycleRailMoveUtils>.Instance.ExecCheckList(this.RailMoveContext, this.SwitchRailConfig.EnterRailCondition, checkList, true, base.GetType().Name);
			}
			if (!flag)
			{
				this.RailMoveContext.IsForward = false;
				flag = Singleton<MotorcycleRailMoveUtils>.Instance.CalcRailMoveTargetAdvanceBySpeed(this.RailMoveContext, (double)this.ParabolaMoveConfig.Duration, (double)this.ParabolaMoveConfig.MinSpeedAlongRail, (double)this.ParabolaMoveConfig.MaxSpeedAlongRail);
				if (flag)
				{
					flag = Singleton<MotorcycleRailMoveUtils>.Instance.ExecCheckList(this.RailMoveContext, this.SwitchRailConfig.EnterRailCondition, checkList, true, base.GetType().Name);
				}
			}
			if (!flag)
			{
				Log instance5 = Singleton<Log>.Instance;
				ELogModule module5 = ELogModule.MotorRailMove;
				ELogAuthor author5 = ELogAuthor.ZYL;
				string message5 = "[MotorcycleSwitchRailMoveData] OnEnter Failed: 计算终点并检查失败";
				string item5 = "SplineId";
				MotorcycleRailComponent relatedRail5 = this.RelatedRail;
				ValueTuple<string, object> valueTuple4 = new ValueTuple<string, object>(item5, (relatedRail5 != null) ? new int?(relatedRail5.GetRailSplineId()) : null);
				instance5.Warn(module5, author5, message5, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple4));
				return false;
			}
			this.EndLocation.FromUeVector(this.RailMoveContext.RailMoveTarget.TargetLoc);
			this.EndRotation.FromUeRotator(this.RailMoveContext.RailMoveTarget.TargetRot);
			Vector tmpVector = this.TmpVector1;
			Vector tmpVector2 = this.TmpVector2;
			Vector tmpVector3 = this.TmpVector3;
			Vector tmpVector4 = this.TmpVector4;
			this.EndLocation.Subtraction(this.StartLocation, tmpVector);
			double inB = Vector.DotProduct(tmpVector, this.GravityDir);
			this.GravityDir.Multiply(inB, tmpVector2);
			tmpVector.Subtraction(tmpVector2, tmpVector3);
			tmpVector3.Division((double)this.ParabolaMoveConfig.Duration, this.PlaneVelocity);
			this.GravityDir.Multiply((double)this.ParabolaMoveConfig.GravityAccelerationAbs, tmpVector4);
			tmpVector2.Addition(tmpVector4.MultiplyEqual(-0.5 * (double)this.ParabolaMoveConfig.Duration * (double)this.ParabolaMoveConfig.Duration), this.CurrentGravityUpVelocity);
			this.CurrentGravityUpVelocity.DivisionEqual((double)this.ParabolaMoveConfig.Duration);
			BaseTagComponent component = this.OwnerEntity.GetComponent<BaseTagComponent>();
			foreach (KeyValuePair<int, bool> keyValuePair in this.CommonConfig.ModifyVehicleTagsOnEnter)
			{
				int num;
				bool flag2;
				keyValuePair.Deconstruct(out num, out flag2);
				int value = num;
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

		// Token: 0x0602FB16 RID: 195350 RVA: 0x00B68DA8 File Offset: 0x00B66FA8
		public override void OnExit()
		{
			BaseTagComponent component = this.OwnerEntity.GetComponent<BaseTagComponent>();
			foreach (KeyValuePair<int, bool> keyValuePair in this.CommonConfig.ModifyVehicleTagsOnExit)
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

		// Token: 0x0602FB17 RID: 195351 RVA: 0x00B68E38 File Offset: 0x00B67038
		public override bool GetVelocity(Vector outVelocity)
		{
			this.CurrentGravityUpVelocity.Addition(this.PlaneVelocity, outVelocity);
			return true;
		}

		// Token: 0x0602FB18 RID: 195352 RVA: 0x00B68E50 File Offset: 0x00B67050
		public void TickUpdateMove(float deltaSeconds)
		{
			float num = Math.Min(this.ParabolaMoveConfig.Duration - this.CurrentMovingTime, deltaSeconds);
			num = Math.Min(num, this.BasicRailMoveConfig.MaxDeltaTimeForMoveUpdate);
			this.CurrentMovingTime += num;
			Vector tmpVector = this.TmpVector1;
			Vector tmpVector2 = this.TmpVector2;
			Vector tmpVector3 = this.TmpVector3;
			this.PlaneVelocity.Addition(this.CurrentGravityUpVelocity, tmpVector2);
			tmpVector2.Multiply((double)num, tmpVector3);
			this.GravityDir.Multiply(0.5 * (double)this.ParabolaMoveConfig.GravityAccelerationAbs * (double)num * (double)num, tmpVector);
			tmpVector3.AdditionEqual(tmpVector);
			this.CurrentLocation.AdditionEqual(tmpVector3);
			Vector tmpVector4 = this.TmpVector1;
			this.GravityDir.Multiply((double)(this.ParabolaMoveConfig.GravityAccelerationAbs * num), tmpVector4);
			this.CurrentGravityUpVelocity.AdditionEqual(tmpVector4);
			Rotator.Lerp(this.StartRotation, this.EndRotation, this.CurrentMovingTime / this.ParabolaMoveConfig.Duration, this.CurrentRotator);
		}

		// Token: 0x0602FB19 RID: 195353 RVA: 0x00B68F64 File Offset: 0x00B67164
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

		// Token: 0x0602FB1A RID: 195354 RVA: 0x00B68FC4 File Offset: 0x00B671C4
		private unsafe void UpdateIsFinishMove()
		{
			if (this.CommonConfig.EnableBlockingCheck && this.IsBlocked && this.BlockingTime > this.CommonConfig.MaxBlockingTimeOut)
			{
				this.IsFinishMove = true;
				this.IsFinishMoveOnFailure = true;
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.MotorRailMove;
				ELogAuthor author = ELogAuthor.ZYL;
				string message = "[MotorcycleSwitchRailMoveData] Finish move on blocking";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("BlockingTime", this.BlockingTime);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("CurrentLocation", this.CurrentLocation);
				instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return;
			}
			this.IsFinishMove = (this.CurrentMovingTime >= this.ParabolaMoveConfig.Duration);
		}

		// Token: 0x0602FB1B RID: 195355 RVA: 0x00B69090 File Offset: 0x00B67290
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

		// Token: 0x0401B510 RID: 111888
		public readonly MotorcycleRailMoveConfig MoveConfig = new MotorcycleRailMoveConfig();

		// Token: 0x0401B511 RID: 111889
		[Nullable(2)]
		public SplineCurve TargetSpline;

		// Token: 0x0401B512 RID: 111890
		public Vector GravityDir = Vector.Create();

		// Token: 0x0401B513 RID: 111891
		[Nullable(2)]
		public TRailMoveUpdater MoveUpdater;

		// Token: 0x0401B514 RID: 111892
		[Nullable(2)]
		public TRailMoveGetter MoveGetter;

		// Token: 0x0401B515 RID: 111893
		private readonly Vector StartLocation = Vector.Create();

		// Token: 0x0401B516 RID: 111894
		private readonly Vector EndLocation = Vector.Create();

		// Token: 0x0401B517 RID: 111895
		private readonly Rotator StartRotation = Rotator.Create();

		// Token: 0x0401B518 RID: 111896
		private readonly Rotator EndRotation = Rotator.Create();

		// Token: 0x0401B519 RID: 111897
		private readonly Vector PlaneVelocity = Vector.Create();

		// Token: 0x0401B51A RID: 111898
		private readonly Vector CurrentGravityUpVelocity = Vector.Create();

		// Token: 0x0401B51B RID: 111899
		private readonly Vector CurrentLocation = Vector.Create();

		// Token: 0x0401B51C RID: 111900
		private readonly Rotator CurrentRotator = Rotator.Create();

		// Token: 0x0401B51D RID: 111901
		private float CurrentMovingTime;

		// Token: 0x0401B51E RID: 111902
		private readonly RailMoveContext RailMoveContext = new RailMoveContext();

		// Token: 0x0401B51F RID: 111903
		private readonly Vector TmpVector1 = Vector.Create();

		// Token: 0x0401B520 RID: 111904
		private readonly Vector TmpVector2 = Vector.Create();

		// Token: 0x0401B521 RID: 111905
		private readonly Vector TmpVector3 = Vector.Create();

		// Token: 0x0401B522 RID: 111906
		private readonly Vector TmpVector4 = Vector.Create();

		// Token: 0x0401B523 RID: 111907
		private readonly Transform TmpTransform1 = Transform.Create();

		// Token: 0x0401B524 RID: 111908
		private bool IsBlocked;

		// Token: 0x0401B525 RID: 111909
		private float BlockingTime;
	}
}
