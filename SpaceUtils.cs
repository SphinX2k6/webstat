using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02000C21 RID: 3105
[NullableContext(1)]
[Nullable(0)]
public class SpaceUtils : IStaticVariableResetter
{
	// Token: 0x06003586 RID: 13702 RVA: 0x000316D4 File Offset: 0x0002F8D4
	static SpaceUtils()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(SpaceUtils.CreateStaticDefaultValue), new Action(SpaceUtils.ResetStaticDefaultValue));
	}

	// Token: 0x06003587 RID: 13703 RVA: 0x000318A4 File Offset: 0x0002FAA4
	private static Vector GetVectorFromPool()
	{
		if (SpaceUtils.VectorPool.Count > 0)
		{
			Vector result = SpaceUtils.VectorPool[SpaceUtils.VectorPool.Count - 1];
			SpaceUtils.VectorPool.RemoveAt(SpaceUtils.VectorPool.Count - 1);
			return result;
		}
		return Vector.Create();
	}

	// Token: 0x06003588 RID: 13704 RVA: 0x000318F0 File Offset: 0x0002FAF0
	private static void ReleaseVectorArray(List<Vector> array)
	{
		SpaceUtils.VectorPool.AddRange(array);
		array.Clear();
	}

	// Token: 0x06003589 RID: 13705 RVA: 0x00031904 File Offset: 0x0002FB04
	public static bool IsComponentInRingArea(Vector ringCenter, Vector ringSize, UPrimitiveComponent component, [Nullable(2)] Vector upVector = null)
	{
		FBoxSphereBounds fboxSphereBounds = component.D_GetComponentBounds();
		SpaceUtils.BoundsCenter.FromUeVector(fboxSphereBounds.Origin);
		SpaceUtils.BoundsExtent.FromUeVector(fboxSphereBounds.BoxExtent);
		double num = ringSize.X * ringSize.X;
		if (num < SpaceUtils.BoundsExtent.X * SpaceUtils.BoundsExtent.X || num < SpaceUtils.BoundsExtent.Y * SpaceUtils.BoundsExtent.Y)
		{
			SpaceUtils.BoundsCenter.Z = 0.0;
			SpaceUtils.BoundsExtent.Z = 0.0;
			SpaceUtils.TempVectorForHugComponent.Set(ringCenter.X, ringCenter.Y, 0.0);
			return SpaceUtils.IsComponentInRingAreaWhenCompHuge(SpaceUtils.BoundsCenter, SpaceUtils.BoundsExtent, SpaceUtils.TempVectorForHugComponent, ringSize.X);
		}
		SpaceUtils.BoundsQuat.FromUeQuat(component.K2_GetComponentQuaternion());
		SpaceUtils.BoundsCenter.Subtraction(ringCenter, SpaceUtils.TmpVector2);
		double z = ringSize.Z;
		double num2 = ringSize.Y * ringSize.Y;
		ERangeValid erangeValid = ERangeValid.None;
		ERangeValid erangeValid2 = ERangeValid.None;
		foreach (Vector inB in SpaceUtils.boundPoints)
		{
			SpaceUtils.BoundsExtent.Multiply(inB, SpaceUtils.TmpVector);
			SpaceUtils.BoundsQuat.RotateVector(SpaceUtils.TmpVector, SpaceUtils.TmpVector);
			SpaceUtils.TmpVector.AdditionEqual(SpaceUtils.TmpVector2);
			if (upVector != null)
			{
				double num3 = SpaceUtils.TmpVector.DotProduct(upVector);
				if (erangeValid2 != ERangeValid.InRange)
				{
					if (num3 > z)
					{
						erangeValid2 |= ERangeValid.Above;
					}
					else if (-num3 > z)
					{
						erangeValid2 |= ERangeValid.Below;
					}
					else
					{
						erangeValid2 = ERangeValid.InRange;
					}
				}
			}
			else if (erangeValid2 != ERangeValid.InRange)
			{
				if (SpaceUtils.TmpVector.Z > z)
				{
					erangeValid2 |= ERangeValid.Above;
				}
				else if (-SpaceUtils.TmpVector.Z > z)
				{
					erangeValid2 |= ERangeValid.Below;
				}
				else
				{
					erangeValid2 = ERangeValid.InRange;
				}
			}
			if (upVector != null)
			{
				Vector.VectorPlaneProject(SpaceUtils.TmpVector, upVector, SpaceUtils.TmpVector3);
				double num4 = SpaceUtils.TmpVector3.SizeSquared();
				if (erangeValid != ERangeValid.InRange)
				{
					if (num4 > num)
					{
						erangeValid |= ERangeValid.Above;
					}
					else if (num4 < num2)
					{
						erangeValid |= ERangeValid.Below;
					}
					else
					{
						erangeValid = ERangeValid.InRange;
					}
				}
			}
			else
			{
				double num5 = SpaceUtils.TmpVector.SizeSquared2D();
				if (erangeValid != ERangeValid.InRange)
				{
					if (num5 > num)
					{
						erangeValid |= ERangeValid.Above;
					}
					else if (num5 < num2)
					{
						erangeValid |= ERangeValid.Below;
					}
					else
					{
						erangeValid = ERangeValid.InRange;
					}
				}
			}
			if (erangeValid2 == ERangeValid.InRange && erangeValid == ERangeValid.InRange)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x0600358A RID: 13706 RVA: 0x00031B58 File Offset: 0x0002FD58
	private static bool IsComponentInRingAreaWhenCompHuge(Vector componentLocation, Vector boxExt, Vector ringLocation, double maxRadius)
	{
		ringLocation.Subtraction(componentLocation, SpaceUtils.TempMinDistance);
		if (SpaceUtils.TempMinDistance.X < 0.0)
		{
			SpaceUtils.TempMinDistance.X = -SpaceUtils.TempMinDistance.X;
		}
		if (SpaceUtils.TempMinDistance.Y < 0.0)
		{
			SpaceUtils.TempMinDistance.Y = -SpaceUtils.TempMinDistance.Y;
		}
		SpaceUtils.TempMinDistance.SubtractionEqual(boxExt);
		bool flag = false;
		if (SpaceUtils.TempMinDistance.X < 0.0)
		{
			SpaceUtils.TempMinDistance.X = 0.0;
			flag = true;
		}
		if (SpaceUtils.TempMinDistance.Y < 0.0)
		{
			if (flag)
			{
				return true;
			}
			SpaceUtils.TempMinDistance.Y = 0.0;
		}
		return SpaceUtils.TempMinDistance.DotProduct(SpaceUtils.TempMinDistance) <= maxRadius * maxRadius;
	}

	// Token: 0x0600358B RID: 13707 RVA: 0x00031C42 File Offset: 0x0002FE42
	private static bool IgnoreInSectorArea(double sectorRadius)
	{
		return SpaceUtils.BoundsExtent.X > sectorRadius || SpaceUtils.BoundsExtent.Y > sectorRadius;
	}

	// Token: 0x0600358C RID: 13708 RVA: 0x00031C60 File Offset: 0x0002FE60
	public static bool IsComponentInSectorArea(Vector sectorCenter, Vector sectorSize, Quat sectorQuat, UPrimitiveComponent component)
	{
		FBoxSphereBounds fboxSphereBounds = component.D_GetComponentBounds();
		SpaceUtils.BoundsExtent.FromUeVector(fboxSphereBounds.BoxExtent);
		if (SpaceUtils.IgnoreInSectorArea(sectorSize.X))
		{
			return true;
		}
		SpaceUtils.BoundsCenter.FromUeVector(fboxSphereBounds.Origin);
		SpaceUtils.BoundsQuat.FromUeQuat(component.K2_GetComponentQuaternion());
		SpaceUtils.BoundsCenter.Subtraction(sectorCenter, SpaceUtils.TmpVector2);
		sectorQuat.Inverse(SpaceUtils.InverseQuat);
		double num = sectorSize.X * sectorSize.X;
		double num2 = 0.01745329238474369 * sectorSize.Y * 0.5;
		bool flag = num2 < 1.5707963267948966;
		double z = sectorSize.Z;
		ERangeValid erangeValid = ERangeValid.None;
		ERangeValid erangeValid2 = ERangeValid.None;
		ERangeValid erangeValid3 = ERangeValid.None;
		foreach (Vector inB in SpaceUtils.boundPoints)
		{
			SpaceUtils.BoundsExtent.Multiply(inB, SpaceUtils.TmpVector);
			SpaceUtils.BoundsQuat.RotateVector(SpaceUtils.TmpVector, SpaceUtils.TmpVector);
			SpaceUtils.TmpVector.AdditionEqual(SpaceUtils.TmpVector2);
			SpaceUtils.InverseQuat.RotateVector(SpaceUtils.TmpVector, SpaceUtils.TmpVector);
			if (erangeValid2 != ERangeValid.InRange)
			{
				if (SpaceUtils.TmpVector.Z > z)
				{
					erangeValid2 |= ERangeValid.Above;
				}
				else if (-SpaceUtils.TmpVector.Z > z)
				{
					erangeValid2 |= ERangeValid.Below;
				}
				else
				{
					erangeValid2 = ERangeValid.InRange;
				}
			}
			double num3 = SpaceUtils.TmpVector.SizeSquared2D();
			if (erangeValid != ERangeValid.InRange && num3 <= num)
			{
				erangeValid = ERangeValid.InRange;
			}
			double num4 = Math.Atan2(SpaceUtils.TmpVector.Y, SpaceUtils.TmpVector.X);
			if (erangeValid3 != ERangeValid.InRange)
			{
				if (flag)
				{
					if (num4 > num2)
					{
						Vector vectorFromPool = SpaceUtils.GetVectorFromPool();
						vectorFromPool.DeepCopy(SpaceUtils.TmpVector);
						SpaceUtils.RightPoints.Add(vectorFromPool);
					}
					else if (-num4 > num2)
					{
						Vector vectorFromPool2 = SpaceUtils.GetVectorFromPool();
						vectorFromPool2.DeepCopy(SpaceUtils.TmpVector);
						SpaceUtils.LeftPoints.Add(vectorFromPool2);
					}
					else
					{
						erangeValid3 = ERangeValid.InRange;
					}
				}
				else if (Math.Abs(num4) <= num2)
				{
					erangeValid3 = ERangeValid.InRange;
				}
			}
			if (erangeValid2 == ERangeValid.InRange && erangeValid == ERangeValid.InRange && erangeValid3 == ERangeValid.InRange)
			{
				if (flag)
				{
					SpaceUtils.ReleaseVectorArray(SpaceUtils.LeftPoints);
					SpaceUtils.ReleaseVectorArray(SpaceUtils.RightPoints);
				}
				return true;
			}
		}
		if (flag)
		{
			if (erangeValid2 == ERangeValid.InRange && erangeValid == ERangeValid.InRange && SpaceUtils.CheckLineCrossX())
			{
				SpaceUtils.ReleaseVectorArray(SpaceUtils.LeftPoints);
				SpaceUtils.ReleaseVectorArray(SpaceUtils.RightPoints);
				return true;
			}
			SpaceUtils.ReleaseVectorArray(SpaceUtils.LeftPoints);
			SpaceUtils.ReleaseVectorArray(SpaceUtils.RightPoints);
		}
		return false;
	}

	// Token: 0x0600358D RID: 13709 RVA: 0x00031EC0 File Offset: 0x000300C0
	private static bool CheckLineCrossX()
	{
		foreach (Vector vector in SpaceUtils.LeftPoints)
		{
			foreach (Vector vector2 in SpaceUtils.RightPoints)
			{
				if (Math.Abs(vector2.Y - vector.Y) >= 1E-08 && vector2.X - (vector2.X - vector.X) / (vector2.Y - vector.Y) * vector2.Y >= 0.0)
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x0600358E RID: 13710 RVA: 0x00031FA8 File Offset: 0x000301A8
	public static bool IsLocationInSideBullet(BulletInfo bulletInfo, Vector location)
	{
		double num = Vector.DistSquared(bulletInfo.GetCollisionLocation(true), location);
		BulletDataBase @base = bulletInfo.BulletDataMain.Base;
		Vector size = @base.Size;
		switch (@base.Shape)
		{
		case EBulletShape.Cube:
			return num < size.X * size.X && num < size.Y * size.Y && num < size.Z * size.Z;
		case EBulletShape.Sphere:
			return num < size.X * size.X;
		case EBulletShape.Cylinder:
			return num < size.Y * size.Y;
		}
		return false;
	}

	// Token: 0x0600358F RID: 13711 RVA: 0x00032050 File Offset: 0x00030250
	public static void CreateStaticDefaultValue()
	{
		SpaceUtils.VectorPool = new List<Vector>();
		SpaceUtils.LeftPoints = new List<Vector>();
		SpaceUtils.RightPoints = new List<Vector>();
	}

	// Token: 0x06003590 RID: 13712 RVA: 0x00032070 File Offset: 0x00030270
	public static void ResetStaticDefaultValue()
	{
		SpaceUtils.VectorPool = null;
		SpaceUtils.LeftPoints = null;
		SpaceUtils.RightPoints = null;
	}

	// Token: 0x04000670 RID: 1648
	[StaticVariableRuleIgnore]
	private static readonly Vector[] boundPoints = new Vector[]
	{
		Vector.Create(1.0, 1.0, 1.0),
		Vector.Create(1.0, 1.0, -1.0),
		Vector.Create(1.0, -1.0, 1.0),
		Vector.Create(1.0, -1.0, -1.0),
		Vector.Create(-1.0, 1.0, 1.0),
		Vector.Create(-1.0, 1.0, -1.0),
		Vector.Create(-1.0, -1.0, 1.0),
		Vector.Create(-1.0, -1.0, -1.0)
	};

	// Token: 0x04000671 RID: 1649
	[StaticVariableRuleIgnore]
	private static readonly Vector BoundsCenter = Vector.Create();

	// Token: 0x04000672 RID: 1650
	[StaticVariableRuleIgnore]
	private static readonly Vector BoundsExtent = Vector.Create();

	// Token: 0x04000673 RID: 1651
	[StaticVariableRuleIgnore]
	private static readonly Quat BoundsQuat = Quat.Create(0f, 0f, 0f, 1f);

	// Token: 0x04000674 RID: 1652
	[StaticVariableRuleIgnore]
	private static readonly Vector TmpVector = Vector.Create();

	// Token: 0x04000675 RID: 1653
	[StaticVariableRuleIgnore]
	private static readonly Vector TmpVector2 = Vector.Create();

	// Token: 0x04000676 RID: 1654
	[StaticVariableRuleIgnore]
	private static readonly Vector TmpVector3 = Vector.Create();

	// Token: 0x04000677 RID: 1655
	[StaticVariableRuleIgnore]
	private static readonly Quat InverseQuat = Quat.Create(0f, 0f, 0f, 1f);

	// Token: 0x04000678 RID: 1656
	private static List<Vector> VectorPool;

	// Token: 0x04000679 RID: 1657
	private static List<Vector> LeftPoints;

	// Token: 0x0400067A RID: 1658
	private static List<Vector> RightPoints;

	// Token: 0x0400067B RID: 1659
	[StaticVariableRuleIgnore]
	private static readonly Vector TempVectorForHugComponent = Vector.Create();

	// Token: 0x0400067C RID: 1660
	[StaticVariableRuleIgnore]
	private static readonly Vector TempMinDistance = Vector.Create();
}
