using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Character.MaterialController
{
	// Token: 0x02003D83 RID: 15747
	[HasGetTypeHash]
	[UnrealBlittableStruct(UnrealReflectionPropertyTypeCode.UnrealBlittableStruct)]
	[UnrealStructLayout(12, 4, UnrealReflectionPropertyTypeCode.UnrealBlittableStruct, PropertiesSize = 12)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Character/MaterialController/SMaterialControllerLoopTime.SMaterialControllerLoopTime")]
	[StructLayout(LayoutKind.Explicit, Pack = 4, Size = 12)]
	public struct SMaterialControllerLoopTime : IEqualityOperators<SMaterialControllerLoopTime, SMaterialControllerLoopTime, bool>, IEquatable<SMaterialControllerLoopTime>, IUnrealScriptStruct
	{
		// Token: 0x0602670C RID: 157452 RVA: 0x009D7DC6 File Offset: 0x009D5FC6
		public SMaterialControllerLoopTime(float Start, float Loop, float End)
		{
			this.Start = Start;
			this.Loop = Loop;
			this.End = End;
		}

		// Token: 0x0602670D RID: 157453 RVA: 0x009D7DDD File Offset: 0x009D5FDD
		public static bool operator ==(SMaterialControllerLoopTime left, SMaterialControllerLoopTime right)
		{
			return left.Start == right.Start && left.Loop == right.Loop && left.End == right.End;
		}

		// Token: 0x0602670E RID: 157454 RVA: 0x009D7E0B File Offset: 0x009D600B
		public static bool operator !=(SMaterialControllerLoopTime left, SMaterialControllerLoopTime right)
		{
			return !(left == right);
		}

		// Token: 0x0602670F RID: 157455 RVA: 0x009D7E17 File Offset: 0x009D6017
		public bool Equals(SMaterialControllerLoopTime other)
		{
			return this == other;
		}

		// Token: 0x06026710 RID: 157456 RVA: 0x009D7E28 File Offset: 0x009D6028
		[NullableContext(2)]
		public override bool Equals(object obj)
		{
			if (obj is SMaterialControllerLoopTime)
			{
				SMaterialControllerLoopTime other = (SMaterialControllerLoopTime)obj;
				return this.Equals(other);
			}
			return false;
		}

		// Token: 0x06026711 RID: 157457 RVA: 0x009D7E4D File Offset: 0x009D604D
		public override int GetHashCode()
		{
			return HashCode.Combine<float, float, float>(this.Start, this.Loop, this.End);
		}

		// Token: 0x06026712 RID: 157458 RVA: 0x009D7E66 File Offset: 0x009D6066
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SMaterialControllerLoopTime._ScriptStructPtr != 0) ? SMaterialControllerLoopTime._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Render/RuntimeBP/Character/MaterialController/SMaterialControllerLoopTime.SMaterialControllerLoopTime", ref SMaterialControllerLoopTime._ScriptStructPtr);
		}

		// Token: 0x04013F69 RID: 81769
		[FieldOffset(0)]
		public float Start;

		// Token: 0x04013F6A RID: 81770
		[FieldOffset(4)]
		public float Loop;

		// Token: 0x04013F6B RID: 81771
		[FieldOffset(8)]
		public float End;

		// Token: 0x04013F6C RID: 81772
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Character/MaterialController/SMaterialControllerLoopTime.SMaterialControllerLoopTime";

		// Token: 0x04013F6D RID: 81773
		private static IntPtr _ScriptStructPtr;
	}
}
