using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter.Camera;

// Token: 0x02000BFA RID: 3066
[NullableContext(1)]
[Nullable(0)]
public class CurveUtils
{
	// Token: 0x060032B0 RID: 12976 RVA: 0x000241BA File Offset: 0x000223BA
	public static T CreateCurve<[Nullable(0)] T>(ECurveType curveType, params float[] @params) where T : CurveBase
	{
		return CurveUtils.CreateCurve(curveType, @params) as T;
	}

	// Token: 0x060032B1 RID: 12977 RVA: 0x000241D0 File Offset: 0x000223D0
	public static CurveBase CreateCurve(ECurveType curveType, params float[] @params)
	{
		if (curveType == ECurveType.Linear)
		{
			return CurveUtils.DefaultLinear;
		}
		switch (curveType)
		{
		case ECurveType.Cubic:
			return new CubicCurve(@params);
		case ECurveType.CubicWithStartSlope:
			return new CubicCurveWithStartSlope(@params);
		case ECurveType.Squared:
			return new SquaredCurve(@params);
		case ECurveType.Power:
			return new PowerCurve(@params);
		case ECurveType.Power2:
			return new PowerCurve2(@params);
		default:
			return CurveUtils.DefaultLinear;
		}
	}

	// Token: 0x060032B2 RID: 12978 RVA: 0x0002422C File Offset: 0x0002242C
	public static CurveBase CreateCurveByStruct([Nullable(2)] SBaseCurve curveStruct)
	{
		if (curveStruct == null)
		{
			return CurveUtils.DefaultLinear;
		}
		return CurveUtils.CreateCurveByStructInternal(curveStruct);
	}

	// Token: 0x060032B3 RID: 12979 RVA: 0x00024248 File Offset: 0x00022448
	public static CurveBase CreateCurveByStruct([Nullable(2)] SFloatCurve curveStruct)
	{
		if (curveStruct == null)
		{
			return CurveUtils.DefaultLinear;
		}
		return CurveUtils.CreateCurveByStructInternal(curveStruct);
	}

	// Token: 0x060032B4 RID: 12980 RVA: 0x00024264 File Offset: 0x00022464
	private static CurveBase CreateCurveByStructInternal([Nullable(new byte[]
	{
		0,
		1,
		1
	})] OneOf<SFloatCurve, SBaseCurve> curveStruct)
	{
		if (curveStruct.IsT1)
		{
			SFloatCurve asT = curveStruct.AsT1;
			if (asT.FloatCurve == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.Core, ELogAuthor.LJM, "浮点曲线参数不合法", default(ReadOnlySpan<ValueTuple<string, object>>));
				return CurveUtils.DefaultLinear;
			}
			return new FloatCurve(asT.FloatCurve);
		}
		else
		{
			if (!curveStruct.IsT2)
			{
				return CurveUtils.DefaultLinear;
			}
			SBaseCurve asT2 = curveStruct.AsT2;
			switch (asT2.CurveType)
			{
			case EBaseCurveType.线性:
				return CurveUtils.DefaultLinear;
			case EBaseCurveType.二阶_凹函数:
				if (asT2.N == 0f)
				{
					Singleton<Log>.Instance.Error(ELogModule.Core, ELogAuthor.LCZ, "二阶 - 凹函数不接受0作为N", default(ReadOnlySpan<ValueTuple<string, object>>));
					return CurveUtils.DefaultLinear;
				}
				return new SquaredCurve(new float[]
				{
					1f / asT2.N
				});
			case EBaseCurveType.二阶_凸函数:
				return new SquaredCurve(new float[]
				{
					asT2.N
				});
			case EBaseCurveType.三阶_凹函数:
				if (asT2.N == 0f)
				{
					Singleton<Log>.Instance.Error(ELogModule.Core, ELogAuthor.LCZ, "三阶 - 凹函数不接受0作为N", default(ReadOnlySpan<ValueTuple<string, object>>));
					return CurveUtils.DefaultLinear;
				}
				return new CubicCurveWithStartSlope(new float[]
				{
					1f / asT2.N
				});
			case EBaseCurveType.三阶_凸函数:
				return new CubicCurveWithStartSlope(new float[]
				{
					asT2.N
				});
			case EBaseCurveType.三阶_S函数:
				return new CubicCurve(new float[]
				{
					asT2.N
				});
			case EBaseCurveType.三阶_反S函数:
				if (asT2.N == 0f)
				{
					Singleton<Log>.Instance.Error(ELogModule.Core, ELogAuthor.LCZ, "三阶 - 反S函数不接受0作为N", default(ReadOnlySpan<ValueTuple<string, object>>));
					return CurveUtils.DefaultLinear;
				}
				return new CubicCurve(new float[]
				{
					1f / asT2.N
				});
			case EBaseCurveType.幂函数_凹函数:
				return new PowerCurve3(new float[]
				{
					asT2.N
				});
			case EBaseCurveType.幂函数_凸函数:
				if (asT2.N == 0f)
				{
					Singleton<Log>.Instance.Error(ELogModule.Core, ELogAuthor.LCZ, "幂函数 - 凸函数不接受0作为N", default(ReadOnlySpan<ValueTuple<string, object>>));
					return CurveUtils.DefaultLinear;
				}
				return new PowerCurve3(new float[]
				{
					1f / asT2.N
				});
			case EBaseCurveType.幂函数_S函数:
				if (asT2.N == 0f)
				{
					Singleton<Log>.Instance.Error(ELogModule.Core, ELogAuthor.LCZ, "幂函数 - S函数不接受0作为N", default(ReadOnlySpan<ValueTuple<string, object>>));
					return CurveUtils.DefaultLinear;
				}
				return new PowerCurve(new float[]
				{
					1f / asT2.N
				});
			case EBaseCurveType.幂函数_反S函数:
				return new PowerCurve(new float[]
				{
					asT2.N
				});
			case EBaseCurveType.幂函数_抛物线:
				return new PowerCurve2(new float[]
				{
					asT2.N
				});
			case EBaseCurveType.缓入缓出:
				return new CubicBezierCurve(new float[]
				{
					0.75f,
					0f,
					0.25f,
					1f
				});
			case EBaseCurveType.缓入急出:
				return new CubicBezierCurve(new float[]
				{
					0.6f,
					0f,
					1f,
					0.4f
				});
			case EBaseCurveType.急入缓出:
				return new CubicBezierCurve(new float[]
				{
					0f,
					0.6f,
					0.4f,
					1f
				});
			case EBaseCurveType.急入急出:
				return new CubicBezierCurve(new float[]
				{
					0f,
					0.75f,
					1f,
					0.25f
				});
			case EBaseCurveType.资产曲线:
				if (asT2.FloatCurve == null)
				{
					Singleton<Log>.Instance.Error(ELogModule.Core, ELogAuthor.ZJL, "资产曲线 FloatCurve 为空,回退到默认线性曲线", default(ReadOnlySpan<ValueTuple<string, object>>));
					return CurveUtils.DefaultLinear;
				}
				return new FloatCurve(asT2.FloatCurve);
			default:
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Core;
				ELogAuthor author = ELogAuthor.LCZ;
				string message = "无效曲线类型";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Type", asT2.CurveType);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return CurveUtils.DefaultLinear;
			}
			}
		}
	}

	// Token: 0x0400057E RID: 1406
	[StaticVariableRuleIgnore]
	public static readonly LinearCurve DefaultLinear = new LinearCurve();

	// Token: 0x0400057F RID: 1407
	[StaticVariableRuleIgnore]
	public static readonly SquaredCurve DefaultPara = new SquaredCurve(new float[]
	{
		2f
	});

	// Token: 0x04000580 RID: 1408
	[StaticVariableRuleIgnore]
	public static readonly CubicCurve DefaultCubic = new CubicCurve(new float[1]);
}
