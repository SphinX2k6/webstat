using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Gameplay.MotorRailMove;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.Vehicle.Motorcycle.MotorcycleRailMove
{
	// Token: 0x020047CE RID: 18382
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class MotorcycleRailMoveUtils : Singleton<MotorcycleRailMoveUtils>
	{
		// Token: 0x0602FAF6 RID: 195318 RVA: 0x00B673E4 File Offset: 0x00B655E4
		[NullableContext(2)]
		public unsafe bool ExecCheckList([Nullable(1)] RailMoveContext checkRailMoveContext, EnterRailCondition enterRailCondition = null, [Nullable(new byte[]
		{
			2,
			1
		})] IList<TRailMoveChecker> checkList = null, bool bEnableLog = false, string logSource = null)
		{
			if (checkList == null)
			{
				return true;
			}
			for (int i = 0; i < checkList.Count; i++)
			{
				if (!checkList[i](checkRailMoveContext, enterRailCondition))
				{
					if (bEnableLog)
					{
						Log instance = Singleton<Log>.Instance;
						ELogModule module = ELogModule.MotorRailMove;
						ELogAuthor author = ELogAuthor.ZYL;
						string message = "[MotorcycleRailMoveUtils] ExecCheckList not pass";
						<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Source", logSource);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("CheckerIndex", i);
						instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
					}
					return false;
				}
			}
			if (bEnableLog)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.MotorRailMove;
				ELogAuthor author2 = ELogAuthor.ZYL;
				string message2 = "[MotorcycleRailMoveUtils] ExecCheckList pass";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Source", logSource);
				instance2.Info(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			return true;
		}

		// Token: 0x0602FAF7 RID: 195319 RVA: 0x00B674AC File Offset: 0x00B656AC
		public bool CalcRailMoveTargetNotAdvanceBySpeed(RailMoveContext checkRailMoveContext, double minSpeed, double maxSpeed)
		{
			SplineCurve railSpline = checkRailMoveContext.RailSpline;
			if (railSpline == null)
			{
				return false;
			}
			bool isForward = checkRailMoveContext.IsForward;
			RailMoveTarget railMoveTarget = checkRailMoveContext.RailMoveTarget;
			Vector sourceLoc = checkRailMoveContext.SourceLoc;
			Vector sourceVel = checkRailMoveContext.SourceVel;
			railMoveTarget.TargetSpline = railSpline;
			railMoveTarget.IsForward = isForward;
			railMoveTarget.TargetSplineInputKey = railSpline.FindInputKeyClosestToWorldLocation(sourceLoc);
			railMoveTarget.TargetSplineDist = railSpline.GetDistanceAlongSplineAtSplineInputKey(railMoveTarget.TargetSplineInputKey);
			railSpline.GetDirectionAtSplineInputKey(railMoveTarget.TargetSplineInputKey, ESplineCoordinateSpace.World, railMoveTarget.TargetSplineDir);
			railSpline.GetRotationAtSplineInputKey(railMoveTarget.TargetSplineInputKey, ESplineCoordinateSpace.World, railMoveTarget.TargetSplineRot);
			railSpline.GetLocationAtSplineInputKey(railMoveTarget.TargetSplineInputKey, ESplineCoordinateSpace.World, railMoveTarget.TargetLoc);
			Vector tmpVector = this.TmpVector1;
			Vector tmpVector2 = this.TmpVector2;
			if (isForward)
			{
				tmpVector2.DeepCopy(railMoveTarget.TargetSplineDir);
			}
			else
			{
				railMoveTarget.TargetSplineDir.UnaryNegation(tmpVector2);
			}
			double num = sourceVel.DotProduct(tmpVector2);
			num = ((num > 0.0) ? num : 0.0);
			num = Singleton<MathUtils>.Instance.Clamp(num, minSpeed, maxSpeed);
			railMoveTarget.TargetSplineDir.Multiply(num, railMoveTarget.TargetVel);
			if (tmpVector2.IsZero())
			{
				return false;
			}
			Singleton<MathUtils>.Instance.LookRotationForwardFirst(tmpVector2, railMoveTarget.TargetSplineRot.Quaternion(null).GetUpVector(tmpVector), railMoveTarget.TargetRot);
			return true;
		}

		// Token: 0x0602FAF8 RID: 195320 RVA: 0x00B675F0 File Offset: 0x00B657F0
		public bool CalcRailMoveTargetAdvanceBySpeed(RailMoveContext checkRailMoveContext, double duration, double minSpeed, double maxSpeed)
		{
			SplineCurve railSpline = checkRailMoveContext.RailSpline;
			if (railSpline == null)
			{
				return false;
			}
			bool isForward = checkRailMoveContext.IsForward;
			RailMoveTarget railMoveTarget = checkRailMoveContext.RailMoveTarget;
			Vector sourceLoc = checkRailMoveContext.SourceLoc;
			Vector sourceVel = checkRailMoveContext.SourceVel;
			railMoveTarget.TargetSpline = railSpline;
			railMoveTarget.IsForward = isForward;
			float splineLength = railSpline.GetSplineLength();
			float input = railSpline.FindInputKeyClosestToWorldLocation(sourceLoc);
			float num = Singleton<MathUtils>.Instance.Clamp(railSpline.GetDistanceAlongSplineAtSplineInputKey(input), 0f, splineLength);
			Vector tmpVector = this.TmpVector1;
			Vector tmpVector2 = this.TmpVector2;
			Vector tmpVector3 = this.TmpVector3;
			Vector tmpVector4 = this.TmpVector4;
			Vector tmpVector5 = this.TmpVector5;
			railSpline.GetDirectionAtSplineInputKey(input, ESplineCoordinateSpace.World, tmpVector);
			railSpline.GetLocationAtSplineInputKey(input, ESplineCoordinateSpace.World, tmpVector2);
			if (isForward)
			{
				tmpVector4.DeepCopy(tmpVector);
			}
			else
			{
				tmpVector.UnaryNegation(tmpVector4);
			}
			double num2 = Vector.PointPlaneDist(sourceLoc, tmpVector2, tmpVector4);
			double num3 = sourceVel.DotProduct(tmpVector4);
			num3 = ((num3 > 0.0) ? num3 : 0.0);
			num3 = Singleton<MathUtils>.Instance.Clamp(num3, minSpeed, maxSpeed);
			double num4;
			if (Singleton<MathUtils>.Instance.IsNearlyZero(num3, new double?((double)0.0001f)))
			{
				num4 = 0.0;
			}
			else if (num2 < 0.0)
			{
				double num5 = -num2 / num3;
				double num6 = Math.Max(0.0, duration - num5);
				num4 = num3 * num6;
			}
			else
			{
				num4 = num3 * duration;
			}
			if (isForward)
			{
				railMoveTarget.TargetSplineDist = (float)Singleton<MathUtils>.Instance.Clamp((double)num + num4, 0.0, (double)splineLength);
			}
			else
			{
				railMoveTarget.TargetSplineDist = (float)Singleton<MathUtils>.Instance.Clamp((double)num - num4, 0.0, (double)splineLength);
			}
			railMoveTarget.TargetSplineInputKey = railSpline.GetInputKeyAtDistanceAlongSpline(railMoveTarget.TargetSplineDist);
			railSpline.GetRotationAtSplineInputKey(railMoveTarget.TargetSplineInputKey, ESplineCoordinateSpace.World, railMoveTarget.TargetSplineRot);
			railSpline.GetDirectionAtSplineInputKey(railMoveTarget.TargetSplineInputKey, ESplineCoordinateSpace.World, railMoveTarget.TargetSplineDir);
			railSpline.GetLocationAtSplineInputKey(railMoveTarget.TargetSplineInputKey, ESplineCoordinateSpace.World, railMoveTarget.TargetLoc);
			if (isForward)
			{
				tmpVector5.DeepCopy(railMoveTarget.TargetSplineDir);
			}
			else
			{
				railMoveTarget.TargetSplineDir.UnaryNegation(tmpVector5);
			}
			if (tmpVector5.IsZero())
			{
				return false;
			}
			Singleton<MathUtils>.Instance.LookRotationForwardFirst(tmpVector5, railMoveTarget.TargetSplineRot.Quaternion(null).GetUpVector(tmpVector3), railMoveTarget.TargetRot);
			tmpVector5.Multiply(num3, railMoveTarget.TargetVel);
			return true;
		}

		// Token: 0x0602FAF9 RID: 195321 RVA: 0x00B67854 File Offset: 0x00B65A54
		public bool RailMoveCheckerCheckRelativeLocation(RailMoveContext checkRailMoveContext, [Nullable(2)] EnterRailCondition enterRailCondition = null)
		{
			if (enterRailCondition == null)
			{
				return false;
			}
			RailMoveTarget railMoveTarget = checkRailMoveContext.RailMoveTarget;
			Vector sourceLoc = checkRailMoveContext.SourceLoc;
			bool isForward = railMoveTarget.IsForward;
			if (railMoveTarget.TargetSpline == null)
			{
				return false;
			}
			if ((isForward && Singleton<MathUtils>.Instance.IsNearlyZero((double)railMoveTarget.TargetSplineDist, new double?((double)0.0001f))) || (!isForward && Singleton<MathUtils>.Instance.IsNearlyZero((double)(railMoveTarget.TargetSpline.GetSplineLength() - railMoveTarget.TargetSplineDist), new double?((double)0.0001f))))
			{
				return true;
			}
			Vector tmpVector = this.TmpVector1;
			sourceLoc.Subtraction(railMoveTarget.TargetLoc, tmpVector);
			railMoveTarget.TargetRot.Quaternion(null).UnRotateVector(tmpVector, tmpVector);
			double num;
			if (Singleton<MathUtils>.Instance.IsNearlyZero(tmpVector.Z, new double?((double)0.0001f)))
			{
				num = (double)(Singleton<MathUtils>.Instance.IsNearlyZero(tmpVector.Y, new double?((double)0.0001f)) ? 0 : 90);
			}
			else
			{
				num = Math.Atan(Math.Abs(tmpVector.Y) / tmpVector.Z) * 57.295780181884766;
				if (num < 0.0)
				{
					num += 180.0;
				}
			}
			return num <= (double)enterRailCondition.MaxAngleBetweenTargetUpAndDirPlaneProjectionOfTargetToCurrent;
		}

		// Token: 0x0602FAFA RID: 195322 RVA: 0x00B67998 File Offset: 0x00B65B98
		public bool RailMoveCheckerCheckVehicleNotReverseMove(RailMoveContext checkRailMoveContext, [Nullable(2)] EnterRailCondition enterRailCondition = null)
		{
			Vector tmpVector = this.TmpVector1;
			checkRailMoveContext.SourceRot.Quaternion(null).GetForwardVector(tmpVector);
			return checkRailMoveContext.SourceVel.DotProduct(tmpVector) >= 0.0;
		}

		// Token: 0x0602FAFB RID: 195323 RVA: 0x00B679DC File Offset: 0x00B65BDC
		public bool RailMoveCheckerCheckAngleBetweenVehicleUpAndRailUp(RailMoveContext checkRailMoveContext, [Nullable(2)] EnterRailCondition enterRailCondition = null)
		{
			if (enterRailCondition == null)
			{
				return false;
			}
			Vector tmpVector = this.TmpVector1;
			Vector tmpVector2 = this.TmpVector1;
			checkRailMoveContext.RailMoveTarget.TargetSplineRot.Quaternion(null).GetUpVector(tmpVector2);
			checkRailMoveContext.SourceRot.Quaternion(null).GetUpVector(tmpVector);
			return Singleton<MathUtils>.Instance.GetAngleByVectorDot(tmpVector2, tmpVector) <= (double)enterRailCondition.MaxAngleBetweenUpAndRailUp;
		}

		// Token: 0x0602FAFC RID: 195324 RVA: 0x00B67A40 File Offset: 0x00B65C40
		public bool RailMoveCheckerCheckAngleBetweenVehicleForwardAndRailTangent(RailMoveContext checkRailMoveContext, [Nullable(2)] EnterRailCondition enterRailCondition = null)
		{
			if (enterRailCondition == null)
			{
				return false;
			}
			Vector tmpVector = this.TmpVector1;
			Vector tmpVector2 = this.TmpVector2;
			if (!checkRailMoveContext.RailMoveTarget.IsForward)
			{
				checkRailMoveContext.RailMoveTarget.TargetSplineDir.UnaryNegation(tmpVector2);
			}
			else
			{
				tmpVector2.DeepCopy(checkRailMoveContext.RailMoveTarget.TargetSplineDir);
			}
			if (tmpVector2.IsZero())
			{
				return false;
			}
			checkRailMoveContext.SourceRot.Quaternion(null).GetForwardVector(tmpVector);
			return Math.Abs(Singleton<MathUtils>.Instance.GetAngleByVectorDot(tmpVector2, tmpVector)) <= (double)enterRailCondition.MaxAngleBetweenForwardAndRailTangent;
		}

		// Token: 0x0602FAFD RID: 195325 RVA: 0x00B67ACC File Offset: 0x00B65CCC
		public bool RailMoveCheckerCheckAngleBetweenVehicleVelocityAndRailTangent(RailMoveContext checkRailMoveContext, [Nullable(2)] EnterRailCondition enterRailCondition = null)
		{
			if (enterRailCondition == null)
			{
				return false;
			}
			Vector tmpVector = this.TmpVector1;
			if (!checkRailMoveContext.RailMoveTarget.IsForward)
			{
				checkRailMoveContext.RailMoveTarget.TargetSplineDir.UnaryNegation(tmpVector);
			}
			else
			{
				tmpVector.DeepCopy(checkRailMoveContext.RailMoveTarget.TargetSplineDir);
			}
			return !tmpVector.IsZero() && (checkRailMoveContext.SourceVel.IsNearlyZero(9.999999747378752E-05) || Math.Abs(Singleton<MathUtils>.Instance.GetAngleByVectorDot(tmpVector, checkRailMoveContext.SourceVel)) <= (double)enterRailCondition.MaxAngleBetweenVelocityAndRailTangent);
		}

		// Token: 0x0602FAFE RID: 195326 RVA: 0x00B67B58 File Offset: 0x00B65D58
		public double GetDistanceFromTargetToRail(USplineComponent targetSplineComp, TRailMoveGetter targetMoveGetter)
		{
			if (!targetMoveGetter(Singleton<MathUtils>.Instance.CommonTempVector, null, null))
			{
				return -1.0;
			}
			FVectorDouble fvectorDouble = Singleton<MathUtils>.Instance.CommonTempVector.ToUeVector(false);
			float inKey = targetSplineComp.D_FindInputKeyClosestToWorldLocation(fvectorDouble);
			FVectorDouble fvectorDouble2 = targetSplineComp.D_GetLocationAtSplineInputKey(inKey, ESplineCoordinateSpace.World);
			return Singleton<MathUtils>.Instance.VectorDistance(fvectorDouble2, Singleton<MathUtils>.Instance.CommonTempVector);
		}

		// Token: 0x0602FAFF RID: 195327 RVA: 0x00B67BC0 File Offset: 0x00B65DC0
		public EMotorcycleSide? GetRailRelativeSideOfTarget(USplineComponent targetSplineComp, TRailMoveGetter vehicleMoveGetter)
		{
			Vector tmpVector = this.TmpVector1;
			Vector tmpVector2 = this.TmpVector2;
			Rotator tmpRotator = this.TmpRotator1;
			if (!vehicleMoveGetter(tmpVector, tmpRotator, null))
			{
				return null;
			}
			FVectorDouble fvectorDouble = tmpVector.ToUeVector(false);
			float inKey = targetSplineComp.D_FindInputKeyClosestToWorldLocation(fvectorDouble);
			Vector vector = tmpVector2;
			fvectorDouble = targetSplineComp.D_GetLocationAtSplineInputKey(inKey, ESplineCoordinateSpace.World);
			vector.FromUeVector(fvectorDouble);
			tmpVector2.SubtractionEqual(tmpVector);
			tmpRotator.Quaternion(Singleton<MathUtils>.Instance.CommonTempQuat).UnRotateVector(tmpVector2, tmpVector2);
			if (Singleton<MathUtils>.Instance.IsNearlyZero(tmpVector2.Y, new double?((double)0.0001f)))
			{
				return new EMotorcycleSide?(EMotorcycleSide.Middle);
			}
			return new EMotorcycleSide?((tmpVector2.Y < 0.0) ? EMotorcycleSide.Left : EMotorcycleSide.Right);
		}

		// Token: 0x0602FB00 RID: 195328 RVA: 0x00B67C7C File Offset: 0x00B65E7C
		public void UpdateRailMoveConfig(string targetRowName, MotorcycleRailMoveConfig targetConfig, [Nullable(new byte[]
		{
			1,
			1,
			2
		})] Func<string, SMotorRailMoveConfig> ueConfigGetter)
		{
			string text = "Default";
			if (targetRowName != text)
			{
				this.UpdateRailMoveConfig(text, targetConfig, ueConfigGetter);
			}
			SMotorRailMoveConfig smotorRailMoveConfig = ueConfigGetter(targetRowName);
			if (smotorRailMoveConfig == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.MotorRailMove;
				ELogAuthor author = ELogAuthor.ZYL;
				string message = "[MotorcycleRailMoveUtils] UpdateRailMoveConfig失败，找不到对应行的数据";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("targetRowName", targetRowName);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			targetConfig.UpdateFromUeData(smotorRailMoveConfig);
		}

		// Token: 0x0401B4F6 RID: 111862
		private readonly Vector TmpVector1 = Vector.Create();

		// Token: 0x0401B4F7 RID: 111863
		private readonly Vector TmpVector2 = Vector.Create();

		// Token: 0x0401B4F8 RID: 111864
		private readonly Vector TmpVector3 = Vector.Create();

		// Token: 0x0401B4F9 RID: 111865
		private readonly Vector TmpVector4 = Vector.Create();

		// Token: 0x0401B4FA RID: 111866
		private readonly Vector TmpVector5 = Vector.Create();

		// Token: 0x0401B4FB RID: 111867
		private readonly Rotator TmpRotator1 = Rotator.Create();

		// Token: 0x0401B4FC RID: 111868
		public TRailMoveChecker RailMoveCheckerCheckRailLenLeft = delegate(RailMoveContext checkRailMoveContext, [Nullable(2)] EnterRailCondition enterRailCondition = null)
		{
			RailMoveTarget railMoveTarget = checkRailMoveContext.RailMoveTarget;
			bool isForward = railMoveTarget.IsForward;
			if (railMoveTarget.TargetSpline == null)
			{
				return false;
			}
			if (isForward)
			{
				return railMoveTarget.TargetSpline.GetSplineLength() - railMoveTarget.TargetSplineDist > ((enterRailCondition != null) ? enterRailCondition.MinRailLenLeftAfterEnterRail : 0f);
			}
			return railMoveTarget.TargetSplineDist > ((enterRailCondition != null) ? enterRailCondition.MinRailLenLeftAfterEnterRail : 0f);
		};
	}
}
