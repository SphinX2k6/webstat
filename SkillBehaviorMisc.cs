using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using CSharpScript.Game.Utils;
using UnrealEngine;

// Token: 0x0200312E RID: 12590
[NullableContext(1)]
[Nullable(0)]
public class SkillBehaviorMisc : IStaticVariableResetter
{
	// Token: 0x0601A133 RID: 106803 RVA: 0x007A66A2 File Offset: 0x007A48A2
	static SkillBehaviorMisc()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(SkillBehaviorMisc.CreateStaticDefaultValue), new Action(SkillBehaviorMisc.ResetStaticDefaultValue));
	}

	// Token: 0x0601A134 RID: 106804 RVA: 0x007A66D7 File Offset: 0x007A48D7
	public static List<EndSkillBehaviorParam> GetEndSkillBehaviorParamList(Skill skill)
	{
		if (!SkillBehaviorMisc.ParamMap.ContainsKey(skill))
		{
			SkillBehaviorMisc.ParamMap.Add(skill, new List<EndSkillBehaviorParam>());
		}
		return SkillBehaviorMisc.ParamMap[skill];
	}

	// Token: 0x0601A135 RID: 106805 RVA: 0x007A6701 File Offset: 0x007A4901
	[NullableContext(0)]
	public static ValueTuple<FVectorDouble, FVectorDouble> GetLocationAndDirection([Nullable(1)] AActor actor)
	{
		return new ValueTuple<FVectorDouble, FVectorDouble>(actor.D_K2_GetActorLocation(), actor.D_GetActorForwardVector());
	}

	// Token: 0x0601A136 RID: 106806 RVA: 0x007A6714 File Offset: 0x007A4914
	private static void SetupLineTrace(UTraceLineElement lineTrace, FLinearColor traceColor, FLinearColor hitColor, object queryType)
	{
		lineTrace.bIsSingle = true;
		lineTrace.bIgnoreSelf = true;
		lineTrace.DrawTime = 5f;
		Singleton<TraceElementCommon>.Instance.SetTraceColor(lineTrace, traceColor);
		Singleton<TraceElementCommon>.Instance.SetTraceHitColor(lineTrace, hitColor);
		Array array = queryType as Array;
		if (array != null)
		{
			for (int i = 0; i < array.Length; i++)
			{
				lineTrace.AddObjectTypeQuery((EObjectTypeQuery)array.GetValue(i));
			}
			return;
		}
		lineTrace.SetTraceTypeQuery((ETraceTypeQuery)queryType);
	}

	// Token: 0x0601A137 RID: 106807 RVA: 0x007A678C File Offset: 0x007A498C
	private static UTraceLineElement GetLineTrace(AActor myActor, bool draw, SkillBehaviorMisc.ETraceType type)
	{
		UTraceLineElement utraceLineElement = null;
		if (type != SkillBehaviorMisc.ETraceType.Static)
		{
			if (type == SkillBehaviorMisc.ETraceType.Water)
			{
				if (SkillBehaviorMisc._lineTraceWater == null)
				{
					SkillBehaviorMisc._lineTraceWater = new UTraceLineElement();
					SkillBehaviorMisc.SetupLineTrace(SkillBehaviorMisc._lineTraceWater, ColorUtils.LinearBlue, ColorUtils.LinearYellow, KuroTraceTypeQuery.Water);
				}
				utraceLineElement = SkillBehaviorMisc._lineTraceWater;
			}
		}
		else
		{
			if (SkillBehaviorMisc._lineTraceStatic == null)
			{
				SkillBehaviorMisc._lineTraceStatic = new UTraceLineElement();
				SkillBehaviorMisc.SetupLineTrace(SkillBehaviorMisc._lineTraceStatic, ColorUtils.LinearGreen, ColorUtils.LinearRed, new EObjectTypeQuery[]
				{
					KuroObjectTypeQuery.WorldStatic,
					KuroObjectTypeQuery.WorldStaticIgnoreBullet
				});
			}
			utraceLineElement = SkillBehaviorMisc._lineTraceStatic;
		}
		if (draw)
		{
			utraceLineElement.SetDrawDebugTrace(EDrawDebugTrace.ForDuration);
		}
		else
		{
			utraceLineElement.SetDrawDebugTrace(EDrawDebugTrace.None);
		}
		utraceLineElement.WorldContextObject = myActor;
		utraceLineElement.ClearCacheData(false);
		return utraceLineElement;
	}

	// Token: 0x0601A138 RID: 106808 RVA: 0x007A6840 File Offset: 0x007A4A40
	private static void Backward(float distance, Vector start, Vector end, Vector @out)
	{
		Vector vector = Vector.Create();
		end.Subtraction(start, vector);
		vector.Normalize(9.99999993922529E-09);
		vector.Multiply((double)distance, vector);
		@out.Subtraction(vector, @out);
	}

	// Token: 0x0601A139 RID: 106809 RVA: 0x007A6880 File Offset: 0x007A4A80
	[return: Nullable(new byte[]
	{
		0,
		2,
		1
	})]
	public static ValueTuple<UKuroHitResult, Vector>? TraceWall(CharacterActorComponent myActorComp, Vector start, Vector end, bool draw)
	{
		UTraceLineElement lineTrace = SkillBehaviorMisc.GetLineTrace(myActorComp.Actor, draw, SkillBehaviorMisc.ETraceType.Static);
		Singleton<TraceElementCommon>.Instance.SetStartLocation(lineTrace, start);
		Singleton<TraceElementCommon>.Instance.SetEndLocation(lineTrace, end);
		bool flag = Singleton<TraceElementCommon>.Instance.LineTrace(lineTrace, "SkillBehaviorAction.SetLocation.traceWall");
		UKuroHitResult hitResult = lineTrace.HitResult;
		if (!flag || !hitResult.bBlockingHit)
		{
			return new ValueTuple<UKuroHitResult, Vector>?(new ValueTuple<UKuroHitResult, Vector>(null, end));
		}
		Singleton<TraceElementCommon>.Instance.GetHitLocation(hitResult, 0, end);
		if (start.Equals(end, 9.999999747378752E-05))
		{
			return null;
		}
		SkillBehaviorMisc.Backward(myActorComp.ScaledRadius, start, end, end);
		return new ValueTuple<UKuroHitResult, Vector>?(new ValueTuple<UKuroHitResult, Vector>(hitResult, end));
	}

	// Token: 0x0601A13A RID: 106810 RVA: 0x007A6924 File Offset: 0x007A4B24
	[return: Nullable(new byte[]
	{
		0,
		2
	})]
	private static ValueTuple<bool, Vector> TraceWater(CharacterActorComponent myActorComp, Vector start, Vector end, bool draw)
	{
		UTraceLineElement lineTrace = SkillBehaviorMisc.GetLineTrace(myActorComp.Actor, draw, SkillBehaviorMisc.ETraceType.Water);
		Singleton<TraceElementCommon>.Instance.SetStartLocation(lineTrace, start);
		Singleton<TraceElementCommon>.Instance.SetEndLocation(lineTrace, end);
		bool flag = Singleton<TraceElementCommon>.Instance.LineTrace(lineTrace, "SkillBehaviorAction.SetLocation.traceWater");
		UKuroHitResult hitResult = lineTrace.HitResult;
		if (flag && hitResult.bBlockingHit)
		{
			Vector vector = Vector.Create();
			Singleton<TraceElementCommon>.Instance.GetHitLocation(hitResult, 0, vector);
			return new ValueTuple<bool, Vector>(true, vector);
		}
		return new ValueTuple<bool, Vector>(false, null);
	}

	// Token: 0x0601A13B RID: 106811 RVA: 0x007A699C File Offset: 0x007A4B9C
	[return: Nullable(new byte[]
	{
		0,
		2
	})]
	public static ValueTuple<bool, Vector> TraceGroundWithGravity(CharacterActorComponent myActorComp, Vector start, bool draw, float traceHeight = 2500f)
	{
		CharacterMoveComponent component = myActorComp.Entity.GetComponent<CharacterMoveComponent>();
		CharacterSwimComponent component2 = myActorComp.Entity.GetComponent<CharacterSwimComponent>();
		Vector vector = Vector.Create();
		Vector vector2 = vector;
		component.GravityUp.Multiply((double)traceHeight, vector2);
		start.Subtraction(vector2, vector);
		UTraceLineElement lineTrace = SkillBehaviorMisc.GetLineTrace(myActorComp.Actor, draw, SkillBehaviorMisc.ETraceType.Static);
		Singleton<TraceElementCommon>.Instance.SetStartLocation(lineTrace, start);
		Singleton<TraceElementCommon>.Instance.SetEndLocation(lineTrace, vector);
		bool flag = Singleton<TraceElementCommon>.Instance.LineTrace(lineTrace, "SkillBehaviorAction.SetLocation.traceGround");
		UKuroHitResult hitResult = lineTrace.HitResult;
		if (!flag || !hitResult.bBlockingHit)
		{
			return new ValueTuple<bool, Vector>(false, null);
		}
		Vector vector3 = Vector.Create();
		Vector vector4 = Vector.Create();
		Singleton<TraceElementCommon>.Instance.GetHitLocation(hitResult, 0, vector3);
		component.GravityUp.Multiply((double)myActorComp.ScaledHalfHeight, vector2);
		start.Addition(vector2, vector4);
		ValueTuple<bool, Vector> valueTuple = SkillBehaviorMisc.TraceWater(myActorComp, vector4, vector3, draw);
		if (valueTuple.Item1 && valueTuple.Item2.Subtraction(vector3, vector4).DotProduct(component.GravityUp) >= (double)(myActorComp.ScaledHalfHeight * 2f) * 0.7)
		{
			return new ValueTuple<bool, Vector>(false, null);
		}
		if (component2 != null)
		{
			Vector vector5 = Vector.Create();
			start.Addition(vector2, vector5);
			Vector vector6 = Vector.Create();
			component.GravityUp.Multiply(500.0, vector6);
			vector6.AdditionEqual(vector5);
			if (SkillBehaviorMisc.TraceWater(myActorComp, vector6, vector5, draw).Item1)
			{
				return new ValueTuple<bool, Vector>(false, null);
			}
		}
		vector3.AdditionEqual(vector2);
		return new ValueTuple<bool, Vector>(true, vector3);
	}

	// Token: 0x0601A13C RID: 106812 RVA: 0x007A6B34 File Offset: 0x007A4D34
	public static bool Compare(ESkillBehaviorComparisonLogic logic, float lValue, float rValue, float lRange, float rRange)
	{
		switch (logic)
		{
		case ESkillBehaviorComparisonLogic.Greater:
			return lValue > rValue;
		case ESkillBehaviorComparisonLogic.GreaterEqual:
			return lValue >= rValue;
		case ESkillBehaviorComparisonLogic.Equal:
			return lValue == rValue;
		case ESkillBehaviorComparisonLogic.Less:
			return lValue < rValue;
		case ESkillBehaviorComparisonLogic.LessEqual:
			return lValue <= rValue;
		case ESkillBehaviorComparisonLogic.Range:
			return lValue >= lRange && lValue <= rRange;
		default:
			return false;
		}
	}

	// Token: 0x0601A13D RID: 106813 RVA: 0x007A6B90 File Offset: 0x007A4D90
	public static void CreateStaticDefaultValue()
	{
		SkillBehaviorMisc.ParamMap = new Dictionary<Skill, List<EndSkillBehaviorParam>>();
	}

	// Token: 0x0601A13E RID: 106814 RVA: 0x007A6B9C File Offset: 0x007A4D9C
	public static void ResetStaticDefaultValue()
	{
		SkillBehaviorMisc.ParamMap = null;
		SkillBehaviorMisc._lineTraceStatic = null;
		SkillBehaviorMisc._lineTraceWater = null;
	}

	// Token: 0x0400D135 RID: 53557
	[StaticVariableRuleIgnore]
	public static readonly int[] Angles = new int[]
	{
		0,
		270,
		90,
		180
	};

	// Token: 0x0400D136 RID: 53558
	public static Dictionary<Skill, List<EndSkillBehaviorParam>> ParamMap;

	// Token: 0x0400D137 RID: 53559
	public const string CONTEXT = "SkillBehaviorAction.SetLocation";

	// Token: 0x0400D138 RID: 53560
	private const float DELTA_HEIGHT = 2500f;

	// Token: 0x0400D139 RID: 53561
	private const float WATER_DETECT_HEIGHT = 500f;

	// Token: 0x0400D13A RID: 53562
	[Nullable(2)]
	private static UTraceLineElement _lineTraceStatic;

	// Token: 0x0400D13B RID: 53563
	[Nullable(2)]
	private static UTraceLineElement _lineTraceWater;

	// Token: 0x020093CA RID: 37834
	[NullableContext(0)]
	private enum ETraceType
	{
		// Token: 0x0403125F RID: 201311
		Static,
		// Token: 0x04031260 RID: 201312
		Water
	}
}
