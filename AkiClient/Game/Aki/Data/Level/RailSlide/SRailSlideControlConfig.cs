using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.Level.RailSlide
{
	// Token: 0x02003E76 RID: 15990
	[HasGetTypeHash]
	[UnrealBlittableStruct(UnrealReflectionPropertyTypeCode.UnrealBlittableStruct)]
	[UnrealStructLayout(20, 4, UnrealReflectionPropertyTypeCode.UnrealBlittableStruct, PropertiesSize = 20)]
	[UnrealObjectPath("/Game/Aki/Data/Level/RailSlide/SRailSlideControlConfig.SRailSlideControlConfig")]
	[StructLayout(LayoutKind.Explicit, Pack = 4, Size = 20)]
	public struct SRailSlideControlConfig : IEqualityOperators<SRailSlideControlConfig, SRailSlideControlConfig, bool>, IEquatable<SRailSlideControlConfig>, IUnrealScriptStruct
	{
		// Token: 0x060278BE RID: 161982 RVA: 0x009F432E File Offset: 0x009F252E
		public SRailSlideControlConfig(float 阻尼, float 最大角速度, float 最大线速度, float 回归强度, float 输入系数)
		{
			this.阻尼 = 阻尼;
			this.最大角速度 = 最大角速度;
			this.最大线速度 = 最大线速度;
			this.回归强度 = 回归强度;
			this.输入系数 = 输入系数;
		}

		// Token: 0x060278BF RID: 161983 RVA: 0x009F4358 File Offset: 0x009F2558
		public static bool operator ==(SRailSlideControlConfig left, SRailSlideControlConfig right)
		{
			return left.阻尼 == right.阻尼 && left.最大角速度 == right.最大角速度 && left.最大线速度 == right.最大线速度 && left.回归强度 == right.回归强度 && left.输入系数 == right.输入系数;
		}

		// Token: 0x060278C0 RID: 161984 RVA: 0x009F43AD File Offset: 0x009F25AD
		public static bool operator !=(SRailSlideControlConfig left, SRailSlideControlConfig right)
		{
			return !(left == right);
		}

		// Token: 0x060278C1 RID: 161985 RVA: 0x009F43B9 File Offset: 0x009F25B9
		public bool Equals(SRailSlideControlConfig other)
		{
			return this == other;
		}

		// Token: 0x060278C2 RID: 161986 RVA: 0x009F43C8 File Offset: 0x009F25C8
		[NullableContext(2)]
		public override bool Equals(object obj)
		{
			if (obj is SRailSlideControlConfig)
			{
				SRailSlideControlConfig other = (SRailSlideControlConfig)obj;
				return this.Equals(other);
			}
			return false;
		}

		// Token: 0x060278C3 RID: 161987 RVA: 0x009F43ED File Offset: 0x009F25ED
		public override int GetHashCode()
		{
			return HashCode.Combine<float, float, float, float, float>(this.阻尼, this.最大角速度, this.最大线速度, this.回归强度, this.输入系数);
		}

		// Token: 0x060278C4 RID: 161988 RVA: 0x009F4412 File Offset: 0x009F2612
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SRailSlideControlConfig._ScriptStructPtr != 0) ? SRailSlideControlConfig._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Level/RailSlide/SRailSlideControlConfig.SRailSlideControlConfig", ref SRailSlideControlConfig._ScriptStructPtr);
		}

		// Token: 0x04014B7A RID: 84858
		[FieldOffset(0)]
		public float 阻尼;

		// Token: 0x04014B7B RID: 84859
		[FieldOffset(4)]
		public float 最大角速度;

		// Token: 0x04014B7C RID: 84860
		[FieldOffset(8)]
		public float 最大线速度;

		// Token: 0x04014B7D RID: 84861
		[FieldOffset(12)]
		public float 回归强度;

		// Token: 0x04014B7E RID: 84862
		[FieldOffset(16)]
		public float 输入系数;

		// Token: 0x04014B7F RID: 84863
		public const string __ObjectPath = "/Game/Aki/Data/Level/RailSlide/SRailSlideControlConfig.SRailSlideControlConfig";

		// Token: 0x04014B80 RID: 84864
		private static IntPtr _ScriptStructPtr;
	}
}
