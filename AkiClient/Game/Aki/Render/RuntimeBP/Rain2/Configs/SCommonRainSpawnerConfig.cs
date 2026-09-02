using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Rain2.Configs
{
	// Token: 0x02003B43 RID: 15171
	[HasGetTypeHash]
	[UnrealBlittableStruct(UnrealReflectionPropertyTypeCode.UnrealBlittableStruct)]
	[UnrealStructLayout(68, 4, UnrealReflectionPropertyTypeCode.UnrealBlittableStruct, PropertiesSize = 68)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Rain2/Configs/SCommonRainSpawnerConfig.SCommonRainSpawnerConfig")]
	[StructLayout(LayoutKind.Explicit, Pack = 4, Size = 68)]
	public struct SCommonRainSpawnerConfig : IEqualityOperators<SCommonRainSpawnerConfig, SCommonRainSpawnerConfig, bool>, IEquatable<SCommonRainSpawnerConfig>, IUnrealScriptStruct
	{
		// Token: 0x06020E12 RID: 134674 RVA: 0x0093984C File Offset: 0x00937A4C
		public SCommonRainSpawnerConfig(int Index, bool UseArraySpawner, int ArraySize, float ArrayLength, float ArraySpawnerRate, float ArraySpawnerTimeWiggle, float ArraySpawnerPositionWiggle, bool UseRandomSpawner, float RandomSpawnRate, float RandomSpawnInnerRadius, float RandomSpawnOuterRadius, float LifeTimeMin, float LifeTimeMax, float ScaleMin, float ScaleMax, float BaseMassMin, float BaseMassMax)
		{
			this.Index = Index;
			this.UseArraySpawner = UseArraySpawner;
			this.ArraySize = ArraySize;
			this.ArrayLength = ArrayLength;
			this.ArraySpawnerRate = ArraySpawnerRate;
			this.ArraySpawnerTimeWiggle = ArraySpawnerTimeWiggle;
			this.ArraySpawnerPositionWiggle = ArraySpawnerPositionWiggle;
			this.UseRandomSpawner = UseRandomSpawner;
			this.RandomSpawnRate = RandomSpawnRate;
			this.RandomSpawnInnerRadius = RandomSpawnInnerRadius;
			this.RandomSpawnOuterRadius = RandomSpawnOuterRadius;
			this.LifeTimeMin = LifeTimeMin;
			this.LifeTimeMax = LifeTimeMax;
			this.ScaleMin = ScaleMin;
			this.ScaleMax = ScaleMax;
			this.BaseMassMin = BaseMassMin;
			this.BaseMassMax = BaseMassMax;
		}

		// Token: 0x06020E13 RID: 134675 RVA: 0x009398E0 File Offset: 0x00937AE0
		public static bool operator ==(SCommonRainSpawnerConfig left, SCommonRainSpawnerConfig right)
		{
			return left.Index == right.Index && left.UseArraySpawner == right.UseArraySpawner && left.ArraySize == right.ArraySize && left.ArrayLength == right.ArrayLength && left.ArraySpawnerRate == right.ArraySpawnerRate && left.ArraySpawnerTimeWiggle == right.ArraySpawnerTimeWiggle && left.ArraySpawnerPositionWiggle == right.ArraySpawnerPositionWiggle && left.UseRandomSpawner == right.UseRandomSpawner && left.RandomSpawnRate == right.RandomSpawnRate && left.RandomSpawnInnerRadius == right.RandomSpawnInnerRadius && left.RandomSpawnOuterRadius == right.RandomSpawnOuterRadius && left.LifeTimeMin == right.LifeTimeMin && left.LifeTimeMax == right.LifeTimeMax && left.ScaleMin == right.ScaleMin && left.ScaleMax == right.ScaleMax && left.BaseMassMin == right.BaseMassMin && left.BaseMassMax == right.BaseMassMax;
		}

		// Token: 0x06020E14 RID: 134676 RVA: 0x009399F2 File Offset: 0x00937BF2
		public static bool operator !=(SCommonRainSpawnerConfig left, SCommonRainSpawnerConfig right)
		{
			return !(left == right);
		}

		// Token: 0x06020E15 RID: 134677 RVA: 0x009399FE File Offset: 0x00937BFE
		public bool Equals(SCommonRainSpawnerConfig other)
		{
			return this == other;
		}

		// Token: 0x06020E16 RID: 134678 RVA: 0x00939A0C File Offset: 0x00937C0C
		[NullableContext(2)]
		public override bool Equals(object obj)
		{
			if (obj is SCommonRainSpawnerConfig)
			{
				SCommonRainSpawnerConfig other = (SCommonRainSpawnerConfig)obj;
				return this.Equals(other);
			}
			return false;
		}

		// Token: 0x06020E17 RID: 134679 RVA: 0x00939A34 File Offset: 0x00937C34
		public override int GetHashCode()
		{
			HashCode hashCode = default(HashCode);
			hashCode.Add<int>(this.Index);
			hashCode.Add<bool>(this.UseArraySpawner);
			hashCode.Add<int>(this.ArraySize);
			hashCode.Add<float>(this.ArrayLength);
			hashCode.Add<float>(this.ArraySpawnerRate);
			hashCode.Add<float>(this.ArraySpawnerTimeWiggle);
			hashCode.Add<float>(this.ArraySpawnerPositionWiggle);
			hashCode.Add<bool>(this.UseRandomSpawner);
			hashCode.Add<float>(this.RandomSpawnRate);
			hashCode.Add<float>(this.RandomSpawnInnerRadius);
			hashCode.Add<float>(this.RandomSpawnOuterRadius);
			hashCode.Add<float>(this.LifeTimeMin);
			hashCode.Add<float>(this.LifeTimeMax);
			hashCode.Add<float>(this.ScaleMin);
			hashCode.Add<float>(this.ScaleMax);
			hashCode.Add<float>(this.BaseMassMin);
			hashCode.Add<float>(this.BaseMassMax);
			return hashCode.ToHashCode();
		}

		// Token: 0x06020E18 RID: 134680 RVA: 0x00939B2D File Offset: 0x00937D2D
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SCommonRainSpawnerConfig._ScriptStructPtr != 0) ? SCommonRainSpawnerConfig._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Render/RuntimeBP/Rain2/Configs/SCommonRainSpawnerConfig.SCommonRainSpawnerConfig", ref SCommonRainSpawnerConfig._ScriptStructPtr);
		}

		// Token: 0x040107EA RID: 67562
		[FieldOffset(0)]
		public int Index;

		// Token: 0x040107EB RID: 67563
		[FieldOffset(4)]
		public bool UseArraySpawner;

		// Token: 0x040107EC RID: 67564
		[FieldOffset(8)]
		public int ArraySize;

		// Token: 0x040107ED RID: 67565
		[FieldOffset(12)]
		public float ArrayLength;

		// Token: 0x040107EE RID: 67566
		[FieldOffset(16)]
		public float ArraySpawnerRate;

		// Token: 0x040107EF RID: 67567
		[FieldOffset(20)]
		public float ArraySpawnerTimeWiggle;

		// Token: 0x040107F0 RID: 67568
		[FieldOffset(24)]
		public float ArraySpawnerPositionWiggle;

		// Token: 0x040107F1 RID: 67569
		[FieldOffset(28)]
		public bool UseRandomSpawner;

		// Token: 0x040107F2 RID: 67570
		[FieldOffset(32)]
		public float RandomSpawnRate;

		// Token: 0x040107F3 RID: 67571
		[FieldOffset(36)]
		public float RandomSpawnInnerRadius;

		// Token: 0x040107F4 RID: 67572
		[FieldOffset(40)]
		public float RandomSpawnOuterRadius;

		// Token: 0x040107F5 RID: 67573
		[FieldOffset(44)]
		public float LifeTimeMin;

		// Token: 0x040107F6 RID: 67574
		[FieldOffset(48)]
		public float LifeTimeMax;

		// Token: 0x040107F7 RID: 67575
		[FieldOffset(52)]
		public float ScaleMin;

		// Token: 0x040107F8 RID: 67576
		[FieldOffset(56)]
		public float ScaleMax;

		// Token: 0x040107F9 RID: 67577
		[FieldOffset(60)]
		public float BaseMassMin;

		// Token: 0x040107FA RID: 67578
		[FieldOffset(64)]
		public float BaseMassMax;

		// Token: 0x040107FB RID: 67579
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Rain2/Configs/SCommonRainSpawnerConfig.SCommonRainSpawnerConfig";

		// Token: 0x040107FC RID: 67580
		private static IntPtr _ScriptStructPtr;
	}
}
