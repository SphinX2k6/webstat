using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.KuroCS.PlantAnim
{
	// Token: 0x02003BF9 RID: 15353
	[HasGetTypeHash]
	[UnrealBlittableStruct(UnrealReflectionPropertyTypeCode.UnrealBlittableStruct)]
	[UnrealStructLayout(40, 4, UnrealReflectionPropertyTypeCode.UnrealBlittableStruct, PropertiesSize = 40)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/KuroCS/PlantAnim/CSPlantAnim_Ini.CSPlantAnim_Ini")]
	[StructLayout(LayoutKind.Explicit, Pack = 4, Size = 40)]
	public struct CSPlantAnim_Ini : IEqualityOperators<CSPlantAnim_Ini, CSPlantAnim_Ini, bool>, IEquatable<CSPlantAnim_Ini>, IUnrealScriptStruct
	{
		// Token: 0x06022B94 RID: 142228 RVA: 0x0096D13B File Offset: 0x0096B33B
		public CSPlantAnim_Ini(int ID, FVector P, FVector N, FVector DIr)
		{
			this.ID = ID;
			this.P = P;
			this.N = N;
			this.DIr = DIr;
		}

		// Token: 0x06022B95 RID: 142229 RVA: 0x0096D15C File Offset: 0x0096B35C
		public static bool operator ==(CSPlantAnim_Ini left, CSPlantAnim_Ini right)
		{
			return left.ID == right.ID && left.P == right.P && left.N == right.N && left.DIr == right.DIr;
		}

		// Token: 0x06022B96 RID: 142230 RVA: 0x0096D1B0 File Offset: 0x0096B3B0
		public static bool operator !=(CSPlantAnim_Ini left, CSPlantAnim_Ini right)
		{
			return !(left == right);
		}

		// Token: 0x06022B97 RID: 142231 RVA: 0x0096D1BC File Offset: 0x0096B3BC
		public bool Equals(CSPlantAnim_Ini other)
		{
			return this == other;
		}

		// Token: 0x06022B98 RID: 142232 RVA: 0x0096D1CC File Offset: 0x0096B3CC
		[NullableContext(2)]
		public override bool Equals(object obj)
		{
			if (obj is CSPlantAnim_Ini)
			{
				CSPlantAnim_Ini other = (CSPlantAnim_Ini)obj;
				return this.Equals(other);
			}
			return false;
		}

		// Token: 0x06022B99 RID: 142233 RVA: 0x0096D1F1 File Offset: 0x0096B3F1
		public override int GetHashCode()
		{
			return HashCode.Combine<int, FVector, FVector, FVector>(this.ID, this.P, this.N, this.DIr);
		}

		// Token: 0x06022B9A RID: 142234 RVA: 0x0096D210 File Offset: 0x0096B410
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (CSPlantAnim_Ini._ScriptStructPtr != 0) ? CSPlantAnim_Ini._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Render/RuntimeBP/PCG/KuroCS/PlantAnim/CSPlantAnim_Ini.CSPlantAnim_Ini", ref CSPlantAnim_Ini._ScriptStructPtr);
		}

		// Token: 0x040119AB RID: 72107
		[FieldOffset(0)]
		public int ID;

		// Token: 0x040119AC RID: 72108
		[FieldOffset(4)]
		public FVector P;

		// Token: 0x040119AD RID: 72109
		[FieldOffset(16)]
		public FVector N;

		// Token: 0x040119AE RID: 72110
		[FieldOffset(28)]
		public FVector DIr;

		// Token: 0x040119AF RID: 72111
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/KuroCS/PlantAnim/CSPlantAnim_Ini.CSPlantAnim_Ini";

		// Token: 0x040119B0 RID: 72112
		private static IntPtr _ScriptStructPtr;
	}
}
