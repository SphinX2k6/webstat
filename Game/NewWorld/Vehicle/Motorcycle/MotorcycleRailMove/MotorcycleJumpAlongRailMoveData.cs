using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.NewWorld.Common.Component;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.Vehicle.Motorcycle.MotorcycleRailMove
{
	// Token: 0x020047B4 RID: 18356
	[NullableContext(1)]
	[Nullable(0)]
	public class MotorcycleJumpAlongRailMoveData : MotorcycleRailMoveDataBase
	{
		// Token: 0x0602FA50 RID: 195152 RVA: 0x00B60ECC File Offset: 0x00B5F0CC
		public MotorcycleJumpAlongRailMoveData(Entity owner, [Nullable(2)] MotorcycleRailComponent relatedRail) : base(EMotorcycleRailMoveDataType.JumpAlongRail, owner, relatedRail)
		{
		}

		// Token: 0x170081C9 RID: 33225
		// (get) Token: 0x0602FA51 RID: 195153 RVA: 0x00B60F99 File Offset: 0x00B5F199
		private ParabolaMoveConfig ParabolaMoveConfig
		{
			get
			{
				return this.MoveConfig.JumpAlongRailConfig.ParabolaMoveConfig;
			}
		}

		// Token: 0x170081CA RID: 33226
		// (get) Token: 0x0602FA52 RID: 195154 RVA: 0x00B60FAB File Offset: 0x00B5F1AB
		private CommonConfig CommonConfig
		{
			get
			{
				return this.MoveConfig.JumpAlongRailConfig.CommonConfig;
			}
		}

		// Token: 0x170081CB RID: 33227
		// (get) Token: 0x0602FA53 RID: 195155 RVA: 0x00B60FBD File Offset: 0x00B5F1BD
		private BasicRailMoveConfig BasicRailMoveConfig
		{
			get
			{
				return this.MoveConfig.BasicRailMoveConfig;
			}
		}

		// Token: 0x0602FA54 RID: 195156 RVA: 0x00B60FCA File Offset: 0x00B5F1CA
		public override void OnTick(float deltaSeconds)
		{
			this.TickUpdateMove(deltaSeconds);
			this.UpdateIsBlocked(deltaSeconds);
			this.ApplyMove();
			this.UpdateIsFinishMove();
		}

		// Token: 0x0602FA55 RID: 195157 RVA: 0x00B60FE8 File Offset: 0x00B5F1E8
		[NullableContext(2)]
		public unsafe override bool OnEnter(MotorcycleRailMoveDataBase lastRailMoveData)
		{
			if (this.TargetSpline == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.MotorRailMove;
				ELogAuthor author = ELogAuthor.ZYL;
				string message = "[MotorcycleJumpAlongRailMoveData] OnEnter Failed: Spline is undefined";
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
				string message2 = "[MotorcycleJumpAlongRailMoveData] OnEnter Failed: Duration有误";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0);
				string item2 = "SplineId";
				MotorcycleRailComponent relatedRail2 = this.RelatedRail;
				ptr = new ValueTuple<string, object>(item2, (relatedRail2 != null) ? new int?(relatedRail2.GetRailSplineId()) : null);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Duration", this.ParabolaMoveConfig.Duration);
				instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return false;
			}
			TRailMoveGetter moveGetter = this.MoveGetter;
			if (moveGetter == null || !moveGetter(this.StartLocation, this.StartRotation, null))
			{
				Log instance3 = Singleton<Log>.Instance;
				ELogModule module3 = ELogModule.MotorRailMove;
				ELogAuthor author3 = ELogAuthor.ZYL;
				string message3 = "[MotorcycleJumpAlongRailMoveData] OnEnter Failed: 拿不到位置旋转";
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
			if ((lastRailMoveData == null || !lastRailMoveData.GetVelocity(this.RailMoveContext.SourceVel)) && !this.MoveGetter(null, null, this.RailMoveContext.SourceVel))
			{
				Log instance4 = Singleton<Log>.Instance;
				ELogModule module4 = ELogModule.MotorRailMove;
				ELogAuthor author4 = ELogAuthor.ZYL;
				string message4 = "[MotorcycleJumpAlongRailMoveData] OnEnter Failed: 拿不到速度";
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
			this.RailMoveContext.IsForward = this.TargetIsForward;
			if (!Singleton<MotorcycleRailMoveUtils>.Instance.CalcRailMoveTargetAdvanceBySpeed(this.RailMoveContext, (double)this.ParabolaMoveConfig.Duration, (double)this.ParabolaMoveConfig.MinSpeedAlongRail, (double)this.ParabolaMoveConfig.MaxSpeedAlongRail))
			{
				Log instance5 = Singleton<Log>.Instance;
				ELogModule module5 = ELogModule.MotorRailMove;
				ELogAuthor author5 = ELogAuthor.ZYL;
				string message5 = "[MotorcycleJumpAlongRailMoveData] OnEnter Failed: 计算终点失败";
				string item5 = "SplineId";
				MotorcycleRailComponent relatedRail5 = this.RelatedRail;
				ValueTuple<string, object> valueTuple4 = new ValueTuple<string, object>(item5, (relatedRail5 != null) ? new int?(relatedRail5.GetRailSplineId()) : null);
				instance5.Warn(module5, author5, message5, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple4));
				return false;
			}
			TRailMoveChecker[] checkList = new TRailMoveChecker[]
			{
				new TRailMoveChecker(Singleton<MotorcycleRailMoveUtils>.Instance.RailMoveCheckerCheckVehicleNotReverseMove),
				Singleton<MotorcycleRailMoveUtils>.Instance.RailMoveCheckerCheckRailLenLeft
			};
			if (!Singleton<MotorcycleRailMoveUtils>.Instance.ExecCheckList(this.RailMoveContext, null, checkList, true, "MotorcycleJumpAlongRailMoveData"))
			{
				Log instance6 = Singleton<Log>.Instance;
				ELogModule module6 = ELogModule.MotorRailMove;
				ELogAuthor author6 = ELogAuthor.ZYL;
				string message6 = "[MotorcycleJumpAlongRailMoveData] OnEnter Failed: 检查不通过";
				string item6 = "SplineId";
				MotorcycleRailComponent relatedRail6 = this.RelatedRail;
				ValueTuple<string, object> valueTuple5 = new ValueTuple<string, object>(item6, (relatedRail6 != null) ? new int?(relatedRail6.GetRailSplineId()) : null);
				instance6.Warn(module6, author6, message6, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple5));
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
			return true;
		}

		// Token: 0x0602FA56 RID: 195158 RVA: 0x00B6153C File Offset: 0x00B5F73C
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

		// Token: 0x0602FA57 RID: 195159 RVA: 0x00B615CC File Offset: 0x00B5F7CC
		public override bool GetVelocity(Vector outVelocity)
		{
			this.CurrentGravityUpVelocity.Addition(this.PlaneVelocity, outVelocity);
			return true;
		}

		// Token: 0x0602FA58 RID: 195160 RVA: 0x00B615E4 File Offset: 0x00B5F7E4
		public void TickUpdateMove(float deltaSeconds)
		{
			float num = Math.Min(Math.Min(this.ParabolaMoveConfig.Duration - this.CurrentMovingTime, deltaSeconds), this.BasicRailMoveConfig.MaxDeltaTimeForMoveUpdate);
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

		// Token: 0x0602FA59 RID: 195161 RVA: 0x00B616F4 File Offset: 0x00B5F8F4
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

		// Token: 0x0602FA5A RID: 195162 RVA: 0x00B61754 File Offset: 0x00B5F954
		private unsafe void UpdateIsFinishMove()
		{
			if (this.CommonConfig.EnableBlockingCheck && this.IsBlocked && this.BlockingTime > this.CommonConfig.MaxBlockingTimeOut)
			{
				this.IsFinishMove = true;
				this.IsFinishMoveOnFailure = true;
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.MotorRailMove;
				ELogAuthor author = ELogAuthor.ZYL;
				string message = "[MotorcycleJumpAlongRailMoveData] Finish move on blocking";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("BlockingTime", this.BlockingTime);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("CurrentLocation", this.CurrentLocation);
				instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return;
			}
			this.IsFinishMove = (this.CurrentMovingTime >= this.ParabolaMoveConfig.Duration);
		}

		// Token: 0x0602FA5B RID: 195163 RVA: 0x00B61820 File Offset: 0x00B5FA20
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

		// Token: 0x0401B43B RID: 111675
		public MotorcycleRailMoveConfig MoveConfig = new MotorcycleRailMoveConfig();

		// Token: 0x0401B43C RID: 111676
		[Nullable(2)]
		public SplineCurve TargetSpline;

		// Token: 0x0401B43D RID: 111677
		public bool TargetIsForward = true;

		// Token: 0x0401B43E RID: 111678
		public Vector GravityDir = Vector.Create();

		// Token: 0x0401B43F RID: 111679
		[Nullable(2)]
		public TRailMoveUpdater MoveUpdater;

		// Token: 0x0401B440 RID: 111680
		[Nullable(2)]
		public TRailMoveGetter MoveGetter;

		// Token: 0x0401B441 RID: 111681
		private readonly Vector StartLocation = Vector.Create();

		// Token: 0x0401B442 RID: 111682
		private readonly Vector EndLocation = Vector.Create();

		// Token: 0x0401B443 RID: 111683
		private readonly Rotator StartRotation = Rotator.Create();

		// Token: 0x0401B444 RID: 111684
		private readonly Rotator EndRotation = Rotator.Create();

		// Token: 0x0401B445 RID: 111685
		private readonly Vector PlaneVelocity = Vector.Create();

		// Token: 0x0401B446 RID: 111686
		private readonly Vector CurrentGravityUpVelocity = Vector.Create();

		// Token: 0x0401B447 RID: 111687
		private readonly Vector CurrentLocation = Vector.Create();

		// Token: 0x0401B448 RID: 111688
		private readonly Rotator CurrentRotator = Rotator.Create();

		// Token: 0x0401B449 RID: 111689
		private float CurrentMovingTime;

		// Token: 0x0401B44A RID: 111690
		private readonly RailMoveContext RailMoveContext = new RailMoveContext();

		// Token: 0x0401B44B RID: 111691
		private readonly Vector TmpVector1 = Vector.Create();

		// Token: 0x0401B44C RID: 111692
		private readonly Vector TmpVector2 = Vector.Create();

		// Token: 0x0401B44D RID: 111693
		private readonly Vector TmpVector3 = Vector.Create();

		// Token: 0x0401B44E RID: 111694
		private readonly Vector TmpVector4 = Vector.Create();

		// Token: 0x0401B44F RID: 111695
		private readonly Transform TmpTransform1 = Transform.Create();

		// Token: 0x0401B450 RID: 111696
		private bool IsBlocked;

		// Token: 0x0401B451 RID: 111697
		private float BlockingTime;
	}
}
