using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x02004262 RID: 16994
	[HasGetTypeHash]
	[UnrealBlittableStruct(UnrealReflectionPropertyTypeCode.UnrealBlittableStruct)]
	[UnrealStructLayout(8, 4, UnrealReflectionPropertyTypeCode.UnrealBlittableStruct, PropertiesSize = 8)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/SFrameAbstractData.SFrameAbstractData")]
	[StructLayout(LayoutKind.Explicit, Pack = 4, Size = 8)]
	public struct SFrameAbstractData : IEqualityOperators<SFrameAbstractData, SFrameAbstractData, bool>, IEquatable<SFrameAbstractData>, IUnrealScriptStruct
	{
		// Token: 0x0602D094 RID: 184468 RVA: 0x00AB5E8A File Offset: 0x00AB408A
		public SFrameAbstractData(bool EnableFrameAbstract, float EnableFrameAbstractDelta)
		{
			this.EnableFrameAbstract = EnableFrameAbstract;
			this.EnableFrameAbstractDelta = EnableFrameAbstractDelta;
		}

		// Token: 0x0602D095 RID: 184469 RVA: 0x00AB5E9A File Offset: 0x00AB409A
		public static bool operator ==(SFrameAbstractData left, SFrameAbstractData right)
		{
			return left.EnableFrameAbstract == right.EnableFrameAbstract && left.EnableFrameAbstractDelta == right.EnableFrameAbstractDelta;
		}

		// Token: 0x0602D096 RID: 184470 RVA: 0x00AB5EBA File Offset: 0x00AB40BA
		public static bool operator !=(SFrameAbstractData left, SFrameAbstractData right)
		{
			return !(left == right);
		}

		// Token: 0x0602D097 RID: 184471 RVA: 0x00AB5EC6 File Offset: 0x00AB40C6
		public bool Equals(SFrameAbstractData other)
		{
			return this == other;
		}

		// Token: 0x0602D098 RID: 184472 RVA: 0x00AB5ED4 File Offset: 0x00AB40D4
		[NullableContext(2)]
		public override bool Equals(object obj)
		{
			if (obj is SFrameAbstractData)
			{
				SFrameAbstractData other = (SFrameAbstractData)obj;
				return this.Equals(other);
			}
			return false;
		}

		// Token: 0x0602D099 RID: 184473 RVA: 0x00AB5EF9 File Offset: 0x00AB40F9
		public override int GetHashCode()
		{
			return HashCode.Combine<bool, float>(this.EnableFrameAbstract, this.EnableFrameAbstractDelta);
		}

		// Token: 0x0602D09A RID: 184474 RVA: 0x00AB5F0C File Offset: 0x00AB410C
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SFrameAbstractData._ScriptStructPtr != 0) ? SFrameAbstractData._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/BaseCharacter/SFrameAbstractData.SFrameAbstractData", ref SFrameAbstractData._ScriptStructPtr);
		}

		// Token: 0x0401941B RID: 103451
		[FieldOffset(0)]
		public bool EnableFrameAbstract;

		// Token: 0x0401941C RID: 103452
		[FieldOffset(4)]
		public float EnableFrameAbstractDelta;

		// Token: 0x0401941D RID: 103453
		public const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/SFrameAbstractData.SFrameAbstractData";

		// Token: 0x0401941E RID: 103454
		private static IntPtr _ScriptStructPtr;
	}
}
