using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Utils
{
	// Token: 0x020046EF RID: 18159
	[NullableContext(1)]
	[Nullable(0)]
	public class ActionUtils
	{
		// Token: 0x0602F3C1 RID: 193473 RVA: 0x00B32C60 File Offset: 0x00B30E60
		public static void CalcCatapultToTargetConfigByGravity(Vector startPos, Vector targetLocation, Vector locationOffset, float heightOffset, float gravityMagnitude, Vector gravityDirect, Vector defaultForward, CatapultToTargetResult @out)
		{
			targetLocation.Subtraction(startPos, ActionUtils.TmpVector);
			ActionUtils.TmpVector.Normalize(9.99999993922529E-09);
			gravityDirect.UnaryNegation(ActionUtils.TmpVector2);
			if (Math.Abs(ActionUtils.TmpVector.DotProduct(ActionUtils.TmpVector2)) < 0.9999)
			{
				Singleton<MathUtils>.Instance.LookRotationUpFirst(ActionUtils.TmpVector, ActionUtils.TmpVector2, ActionUtils.TmpQuat);
			}
			else
			{
				ActionUtils.TmpVector.DeepCopy(defaultForward);
				Singleton<MathUtils>.Instance.LookRotationUpFirst(ActionUtils.TmpVector, ActionUtils.TmpVector2, ActionUtils.TmpQuat);
			}
			ActionUtils.TmpQuat.Rotator(@out.EndRotator);
			ActionUtils.TmpQuat.RotateVector(locationOffset, ActionUtils.TmpVector);
			@out.EndPoint.Set(targetLocation.X + ActionUtils.TmpVector.X, targetLocation.Y + ActionUtils.TmpVector.Y, targetLocation.Z + ActionUtils.TmpVector.Z);
			double znInGravity = Singleton<GravityUtils>.Instance.GetZnInGravity(gravityDirect, startPos);
			double znInGravity2 = Singleton<GravityUtils>.Instance.GetZnInGravity(gravityDirect, @out.EndPoint);
			double num = Math.Max(znInGravity, znInGravity2) + (double)heightOffset;
			float num2 = (float)Math.Sqrt(2.0 * Math.Max(0.0, num - znInGravity) / (double)gravityMagnitude);
			float num3 = (float)Math.Sqrt(2.0 * Math.Max(0.0, num - znInGravity2) / (double)gravityMagnitude);
			@out.MiddlePoint.DeepCopy(@out.EndPoint);
			@out.MiddlePoint.SubtractionEqual(startPos);
			Singleton<GravityUtils>.Instance.ConvertToPlanarVectorForDirect(gravityDirect, @out.MiddlePoint);
			@out.MiddlePoint.MultiplyEqual((double)(num2 / (num2 + num3)));
			@out.MiddlePoint.AdditionEqual(startPos);
			Singleton<GravityUtils>.Instance.SetZnInGravity(gravityDirect, @out.MiddlePoint, num);
			@out.Time1 = num2;
			@out.StartPoint.DeepCopy(startPos);
			@out.GravityMagnitude = gravityMagnitude;
			@out.GravityDirect.DeepCopy(gravityDirect);
		}

		// Token: 0x0602F3C2 RID: 193474 RVA: 0x00B32E6C File Offset: 0x00B3106C
		public static void CalcCatapultToTargetConfigByTime(Vector startPos, Vector targetLocation, Vector locationOffset, float time1, Vector gravityDirect, Vector defaultForward, CatapultToTargetResult @out)
		{
			targetLocation.Subtraction(startPos, ActionUtils.TmpVector);
			ActionUtils.TmpVector.Normalize(9.99999993922529E-09);
			gravityDirect.UnaryNegation(ActionUtils.TmpVector2);
			if (Math.Abs(ActionUtils.TmpVector.DotProduct(ActionUtils.TmpVector2)) < 0.9999)
			{
				Singleton<MathUtils>.Instance.LookRotationUpFirst(ActionUtils.TmpVector, ActionUtils.TmpVector2, ActionUtils.TmpQuat);
			}
			else
			{
				ActionUtils.TmpVector.DeepCopy(defaultForward);
				Singleton<MathUtils>.Instance.LookRotationUpFirst(ActionUtils.TmpVector, ActionUtils.TmpVector2, ActionUtils.TmpQuat);
			}
			ActionUtils.TmpQuat.Rotator(@out.EndRotator);
			ActionUtils.TmpQuat.RotateVector(locationOffset, ActionUtils.TmpVector);
			@out.EndPoint.Set(targetLocation.X + ActionUtils.TmpVector.X, targetLocation.Y + ActionUtils.TmpVector.Y, targetLocation.Z + ActionUtils.TmpVector.Z);
			@out.MiddlePoint.DeepCopy(@out.EndPoint);
			@out.Time1 = time1;
			@out.StartPoint.DeepCopy(startPos);
			@out.GravityMagnitude = 0f;
			@out.GravityDirect.DeepCopy(gravityDirect);
		}

		// Token: 0x0401AE87 RID: 110215
		[StaticVariableRuleIgnore]
		private static readonly Vector TmpVector = Vector.Create();

		// Token: 0x0401AE88 RID: 110216
		[StaticVariableRuleIgnore]
		private static readonly Vector TmpVector2 = Vector.Create();

		// Token: 0x0401AE89 RID: 110217
		[StaticVariableRuleIgnore]
		private static readonly Quat TmpQuat = Quat.Create(0f, 0f, 0f, 1f);
	}
}
