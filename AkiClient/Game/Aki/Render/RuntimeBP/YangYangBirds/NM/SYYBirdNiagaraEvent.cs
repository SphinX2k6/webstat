using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Render.RuntimeBP.YangYangBirds.NM
{
	// Token: 0x020039FA RID: 14842
	[HasGetTypeHash]
	[UnrealBlittableStruct(UnrealReflectionPropertyTypeCode.UnrealBlittableStruct)]
	[UnrealStructLayout(80, 16, UnrealReflectionPropertyTypeCode.UnrealBlittableStruct, PropertiesSize = 80)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/YangYangBirds/NM/SYYBirdNiagaraEvent.SYYBirdNiagaraEvent")]
	[StructLayout(LayoutKind.Explicit, Pack = 16, Size = 80)]
	public struct SYYBirdNiagaraEvent : IEqualityOperators<SYYBirdNiagaraEvent, SYYBirdNiagaraEvent, bool>, IEquatable<SYYBirdNiagaraEvent>, IUnrealScriptStruct
	{
		// Token: 0x0601E2FA RID: 123642 RVA: 0x008EEE7C File Offset: 0x008ED07C
		public SYYBirdNiagaraEvent(FVector Position, FVector Velocity, FVector TargetPosition, FVector TargetTangent, int CurrAnimId, int TargetAnimId, float AnimFrame, bool InTransition, FVector4 CustomData)
		{
			this.Position = Position;
			this.Velocity = Velocity;
			this.TargetPosition = TargetPosition;
			this.TargetTangent = TargetTangent;
			this.CurrAnimId = CurrAnimId;
			this.TargetAnimId = TargetAnimId;
			this.AnimFrame = AnimFrame;
			this.InTransition = InTransition;
			this.CustomData = CustomData;
		}

		// Token: 0x0601E2FB RID: 123643 RVA: 0x008EEED0 File Offset: 0x008ED0D0
		public static bool operator ==(SYYBirdNiagaraEvent left, SYYBirdNiagaraEvent right)
		{
			return left.Position == right.Position && left.Velocity == right.Velocity && left.TargetPosition == right.TargetPosition && left.TargetTangent == right.TargetTangent && left.CurrAnimId == right.CurrAnimId && left.TargetAnimId == right.TargetAnimId && left.AnimFrame == right.AnimFrame && left.InTransition == right.InTransition && left.CustomData == right.CustomData;
		}

		// Token: 0x0601E2FC RID: 123644 RVA: 0x008EEF77 File Offset: 0x008ED177
		public static bool operator !=(SYYBirdNiagaraEvent left, SYYBirdNiagaraEvent right)
		{
			return !(left == right);
		}

		// Token: 0x0601E2FD RID: 123645 RVA: 0x008EEF83 File Offset: 0x008ED183
		public bool Equals(SYYBirdNiagaraEvent other)
		{
			return this == other;
		}

		// Token: 0x0601E2FE RID: 123646 RVA: 0x008EEF94 File Offset: 0x008ED194
		[NullableContext(2)]
		public override bool Equals(object obj)
		{
			if (obj is SYYBirdNiagaraEvent)
			{
				SYYBirdNiagaraEvent other = (SYYBirdNiagaraEvent)obj;
				return this.Equals(other);
			}
			return false;
		}

		// Token: 0x0601E2FF RID: 123647 RVA: 0x008EEFBC File Offset: 0x008ED1BC
		public override int GetHashCode()
		{
			HashCode hashCode = default(HashCode);
			hashCode.Add<FVector>(this.Position);
			hashCode.Add<FVector>(this.Velocity);
			hashCode.Add<FVector>(this.TargetPosition);
			hashCode.Add<FVector>(this.TargetTangent);
			hashCode.Add<int>(this.CurrAnimId);
			hashCode.Add<int>(this.TargetAnimId);
			hashCode.Add<float>(this.AnimFrame);
			hashCode.Add<bool>(this.InTransition);
			hashCode.Add<FVector4>(this.CustomData);
			return hashCode.ToHashCode();
		}

		// Token: 0x0601E300 RID: 123648 RVA: 0x008EF04D File Offset: 0x008ED24D
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SYYBirdNiagaraEvent._ScriptStructPtr != 0) ? SYYBirdNiagaraEvent._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Render/RuntimeBP/YangYangBirds/NM/SYYBirdNiagaraEvent.SYYBirdNiagaraEvent", ref SYYBirdNiagaraEvent._ScriptStructPtr);
		}

		// Token: 0x0400ED50 RID: 60752
		[FieldOffset(0)]
		public FVector Position;

		// Token: 0x0400ED51 RID: 60753
		[FieldOffset(12)]
		public FVector Velocity;

		// Token: 0x0400ED52 RID: 60754
		[FieldOffset(24)]
		public FVector TargetPosition;

		// Token: 0x0400ED53 RID: 60755
		[FieldOffset(36)]
		public FVector TargetTangent;

		// Token: 0x0400ED54 RID: 60756
		[FieldOffset(48)]
		public int CurrAnimId;

		// Token: 0x0400ED55 RID: 60757
		[FieldOffset(52)]
		public int TargetAnimId;

		// Token: 0x0400ED56 RID: 60758
		[FieldOffset(56)]
		public float AnimFrame;

		// Token: 0x0400ED57 RID: 60759
		[FieldOffset(60)]
		public bool InTransition;

		// Token: 0x0400ED58 RID: 60760
		[FieldOffset(64)]
		public FVector4 CustomData;

		// Token: 0x0400ED59 RID: 60761
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/YangYangBirds/NM/SYYBirdNiagaraEvent.SYYBirdNiagaraEvent";

		// Token: 0x0400ED5A RID: 60762
		private static IntPtr _ScriptStructPtr;
	}
}
