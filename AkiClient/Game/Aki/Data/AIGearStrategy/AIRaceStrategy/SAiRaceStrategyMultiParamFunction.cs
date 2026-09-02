using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.AIGearStrategy.AIRaceStrategy
{
	// Token: 0x02003F26 RID: 16166
	[HasGetTypeHash]
	[UnrealBlittableStruct(UnrealReflectionPropertyTypeCode.UnrealBlittableStruct)]
	[UnrealStructLayout(1, 1, UnrealReflectionPropertyTypeCode.UnrealBlittableStruct, PropertiesSize = 1)]
	[UnrealObjectPath("/Game/Aki/Data/AIGearStrategy/AIRaceStrategy/SAiRaceStrategyMultiParamFunction.SAiRaceStrategyMultiParamFunction")]
	[StructLayout(LayoutKind.Explicit, Pack = 1, Size = 1)]
	public struct SAiRaceStrategyMultiParamFunction : IEqualityOperators<SAiRaceStrategyMultiParamFunction, SAiRaceStrategyMultiParamFunction, bool>, IEquatable<SAiRaceStrategyMultiParamFunction>, IUnrealScriptStruct
	{
		// Token: 0x0602858D RID: 165261 RVA: 0x00A0839B File Offset: 0x00A0659B
		public SAiRaceStrategyMultiParamFunction(TEnumAsByte<EAiRaceStrategyMultiParamFuncType> FunctionType)
		{
			this.FunctionType = FunctionType;
		}

		// Token: 0x0602858E RID: 165262 RVA: 0x00A083A4 File Offset: 0x00A065A4
		public static bool operator ==(SAiRaceStrategyMultiParamFunction left, SAiRaceStrategyMultiParamFunction right)
		{
			return left.FunctionType == right.FunctionType;
		}

		// Token: 0x0602858F RID: 165263 RVA: 0x00A083B7 File Offset: 0x00A065B7
		public static bool operator !=(SAiRaceStrategyMultiParamFunction left, SAiRaceStrategyMultiParamFunction right)
		{
			return !(left == right);
		}

		// Token: 0x06028590 RID: 165264 RVA: 0x00A083C3 File Offset: 0x00A065C3
		public bool Equals(SAiRaceStrategyMultiParamFunction other)
		{
			return this == other;
		}

		// Token: 0x06028591 RID: 165265 RVA: 0x00A083D4 File Offset: 0x00A065D4
		[NullableContext(2)]
		public override bool Equals(object obj)
		{
			if (obj is SAiRaceStrategyMultiParamFunction)
			{
				SAiRaceStrategyMultiParamFunction other = (SAiRaceStrategyMultiParamFunction)obj;
				return this.Equals(other);
			}
			return false;
		}

		// Token: 0x06028592 RID: 165266 RVA: 0x00A083F9 File Offset: 0x00A065F9
		public override int GetHashCode()
		{
			return HashCode.Combine<TEnumAsByte<EAiRaceStrategyMultiParamFuncType>>(this.FunctionType);
		}

		// Token: 0x06028593 RID: 165267 RVA: 0x00A08406 File Offset: 0x00A06606
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SAiRaceStrategyMultiParamFunction._ScriptStructPtr != 0) ? SAiRaceStrategyMultiParamFunction._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/AIGearStrategy/AIRaceStrategy/SAiRaceStrategyMultiParamFunction.SAiRaceStrategyMultiParamFunction", ref SAiRaceStrategyMultiParamFunction._ScriptStructPtr);
		}

		// Token: 0x0401538D RID: 86925
		[FieldOffset(0)]
		public TEnumAsByte<EAiRaceStrategyMultiParamFuncType> FunctionType;

		// Token: 0x0401538E RID: 86926
		public const string __ObjectPath = "/Game/Aki/Data/AIGearStrategy/AIRaceStrategy/SAiRaceStrategyMultiParamFunction.SAiRaceStrategyMultiParamFunction";

		// Token: 0x0401538F RID: 86927
		private static IntPtr _ScriptStructPtr;
	}
}
