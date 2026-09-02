using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.Gameplay.RhythmGame
{
	// Token: 0x02003EA1 RID: 16033
	[UnrealBlittableStruct(UnrealReflectionPropertyTypeCode.UnrealBlittableStruct)]
	[UnrealStructLayout(48, 8, UnrealReflectionPropertyTypeCode.UnrealBlittableStruct, PropertiesSize = 44)]
	[UnrealObjectPath("/Game/Aki/Data/Gameplay/RhythmGame/RhythmGamePerformanceCameraConfig.RhythmGamePerformanceCameraConfig")]
	[StructLayout(LayoutKind.Explicit, Pack = 8, Size = 48)]
	public struct RhythmGamePerformanceCameraConfig : IEqualityOperators<RhythmGamePerformanceCameraConfig, RhythmGamePerformanceCameraConfig, bool>, IEquatable<RhythmGamePerformanceCameraConfig>, IUnrealScriptStruct
	{
		// Token: 0x06027C8F RID: 162959 RVA: 0x009FA73A File Offset: 0x009F893A
		public RhythmGamePerformanceCameraConfig(FVectorDouble TargetLoc, FRotator TargetRot, float Time, float Fov)
		{
			this.TargetLoc = TargetLoc;
			this.TargetRot = TargetRot;
			this.Time = Time;
			this.Fov = Fov;
		}

		// Token: 0x06027C90 RID: 162960 RVA: 0x009FA75C File Offset: 0x009F895C
		public static bool operator ==(RhythmGamePerformanceCameraConfig left, RhythmGamePerformanceCameraConfig right)
		{
			return left.TargetLoc == right.TargetLoc && left.TargetRot == right.TargetRot && left.Time == right.Time && left.Fov == right.Fov;
		}

		// Token: 0x06027C91 RID: 162961 RVA: 0x009FA7AD File Offset: 0x009F89AD
		public static bool operator !=(RhythmGamePerformanceCameraConfig left, RhythmGamePerformanceCameraConfig right)
		{
			return !(left == right);
		}

		// Token: 0x06027C92 RID: 162962 RVA: 0x009FA7B9 File Offset: 0x009F89B9
		public bool Equals(RhythmGamePerformanceCameraConfig other)
		{
			return this == other;
		}

		// Token: 0x06027C93 RID: 162963 RVA: 0x009FA7C8 File Offset: 0x009F89C8
		[NullableContext(2)]
		public override bool Equals(object obj)
		{
			if (obj is RhythmGamePerformanceCameraConfig)
			{
				RhythmGamePerformanceCameraConfig other = (RhythmGamePerformanceCameraConfig)obj;
				return this.Equals(other);
			}
			return false;
		}

		// Token: 0x06027C94 RID: 162964 RVA: 0x009FA7ED File Offset: 0x009F89ED
		public override int GetHashCode()
		{
			return HashCode.Combine<FVectorDouble, FRotator, float, float>(this.TargetLoc, this.TargetRot, this.Time, this.Fov);
		}

		// Token: 0x06027C95 RID: 162965 RVA: 0x009FA80C File Offset: 0x009F8A0C
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (RhythmGamePerformanceCameraConfig._ScriptStructPtr != 0) ? RhythmGamePerformanceCameraConfig._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Gameplay/RhythmGame/RhythmGamePerformanceCameraConfig.RhythmGamePerformanceCameraConfig", ref RhythmGamePerformanceCameraConfig._ScriptStructPtr);
		}

		// Token: 0x04014DFF RID: 85503
		[FieldOffset(0)]
		public FVectorDouble TargetLoc;

		// Token: 0x04014E00 RID: 85504
		[FieldOffset(24)]
		public FRotator TargetRot;

		// Token: 0x04014E01 RID: 85505
		[FieldOffset(36)]
		public float Time;

		// Token: 0x04014E02 RID: 85506
		[FieldOffset(40)]
		public float Fov;

		// Token: 0x04014E03 RID: 85507
		public const string __ObjectPath = "/Game/Aki/Data/Gameplay/RhythmGame/RhythmGamePerformanceCameraConfig.RhythmGamePerformanceCameraConfig";

		// Token: 0x04014E04 RID: 85508
		private static IntPtr _ScriptStructPtr;
	}
}
