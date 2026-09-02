using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x0200293B RID: 10555
[NullableContext(1)]
[Nullable(0)]
public class AngleCalculator : IStaticVariableResetter
{
	// Token: 0x06014F30 RID: 85808 RVA: 0x005CC22E File Offset: 0x005CA42E
	static AngleCalculator()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(AngleCalculator.CreateStaticDefaultValue), new Action(AngleCalculator.ResetStaticDefaultValue));
	}

	// Token: 0x06014F31 RID: 85809 RVA: 0x005CC24D File Offset: 0x005CA44D
	public static void CreateStaticDefaultValue()
	{
		AngleCalculator.AngleList = new double[]
		{
			-180.0,
			-157.5,
			-112.5,
			-67.5,
			-22.5,
			22.5,
			67.5,
			112.5,
			157.5,
			180.0
		};
	}

	// Token: 0x06014F32 RID: 85810 RVA: 0x005CC266 File Offset: 0x005CA466
	public static void ResetStaticDefaultValue()
	{
		AngleCalculator.AngleList = null;
	}

	// Token: 0x06014F33 RID: 85811 RVA: 0x005CC270 File Offset: 0x005CA470
	public static float GetVectorAngle(Vector aVector, Vector bVector)
	{
		Vector vector = Vector.Create();
		Vector.CrossProduct(aVector, bVector, vector);
		float num = UKismetMathLibrary.DegAcos((float)(Singleton<MathUtils>.Instance.DotProduct(aVector, bVector) / (aVector.Size() * bVector.Size())));
		if (vector.Z > 0.0)
		{
			return num * -1f;
		}
		return num;
	}

	// Token: 0x06014F34 RID: 85812 RVA: 0x005CC2C8 File Offset: 0x005CA4C8
	public static int AngleToAreaIndex(double angle)
	{
		int num = AngleCalculator.AngleList.Length - 2;
		int i = 0;
		while (i < AngleCalculator.AngleList.Length - 1)
		{
			if (AngleCalculator.AngleList[i] <= angle && angle < AngleCalculator.AngleList[i + 1])
			{
				int num2 = num - i;
				if (num2 != 0)
				{
					return num2;
				}
				return num;
			}
			else
			{
				i++;
			}
		}
		return num;
	}

	// Token: 0x06014F35 RID: 85813 RVA: 0x005CC318 File Offset: 0x005CA518
	public static Vector2D ConvertLguiPosToScreenPos(double x, double y)
	{
		UUIItem uiRootItem = Singleton<UiLayer>.Instance.UiRootItem;
		Vector2D vector2D = Vector2D.Create(x, y);
		ULGUICanvasScaler canvasScaler = Singleton<UiLayer>.Instance.UiRootItem.GetCanvasScaler();
		FVector2D fvector2D = vector2D.ToUeVector2D(false);
		FVector2D fvector2D2 = canvasScaler.ConvertPositionFromLGUICanvasToViewport(fvector2D);
		fvector2D2.X = MathCommon.Clamp(fvector2D2.X, 0f, uiRootItem.GetWidth());
		fvector2D2.Y = MathCommon.Clamp(fvector2D2.Y, 0f, uiRootItem.GetHeight());
		return new Vector2D((double)fvector2D2.X, (double)fvector2D2.Y);
	}

	// Token: 0x0400A177 RID: 41335
	public static double[] AngleList;
}
