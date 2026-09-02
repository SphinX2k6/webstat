using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Character.Role.FemaleM.YinLin.Abilities
{
	// Token: 0x02003FF4 RID: 16372
	[HasGetTypeHash]
	[UnrealBlittableStruct(UnrealReflectionPropertyTypeCode.UnrealBlittableStruct)]
	[UnrealStructLayout(16, 4, UnrealReflectionPropertyTypeCode.UnrealBlittableStruct, PropertiesSize = 16)]
	[UnrealObjectPath("/Game/Aki/Character/Role/FemaleM/YinLin/Abilities/SYinlin_MeshSocket.SYinlin_MeshSocket")]
	[StructLayout(LayoutKind.Explicit, Pack = 4, Size = 16)]
	public struct SYinlin_MeshSocket : IEqualityOperators<SYinlin_MeshSocket, SYinlin_MeshSocket, bool>, IEquatable<SYinlin_MeshSocket>, IUnrealScriptStruct
	{
		// Token: 0x060296C0 RID: 169664 RVA: 0x00A2DB5C File Offset: 0x00A2BD5C
		public SYinlin_MeshSocket(TEnumAsByte<EYinlin_Type> Type, FName SocketName)
		{
			this.Type = Type;
			this.SocketName = SocketName;
		}

		// Token: 0x060296C1 RID: 169665 RVA: 0x00A2DB6C File Offset: 0x00A2BD6C
		public static bool operator ==(SYinlin_MeshSocket left, SYinlin_MeshSocket right)
		{
			return left.Type == right.Type && left.SocketName == right.SocketName;
		}

		// Token: 0x060296C2 RID: 169666 RVA: 0x00A2DB94 File Offset: 0x00A2BD94
		public static bool operator !=(SYinlin_MeshSocket left, SYinlin_MeshSocket right)
		{
			return !(left == right);
		}

		// Token: 0x060296C3 RID: 169667 RVA: 0x00A2DBA0 File Offset: 0x00A2BDA0
		public bool Equals(SYinlin_MeshSocket other)
		{
			return this == other;
		}

		// Token: 0x060296C4 RID: 169668 RVA: 0x00A2DBB0 File Offset: 0x00A2BDB0
		[NullableContext(2)]
		public override bool Equals(object obj)
		{
			if (obj is SYinlin_MeshSocket)
			{
				SYinlin_MeshSocket other = (SYinlin_MeshSocket)obj;
				return this.Equals(other);
			}
			return false;
		}

		// Token: 0x060296C5 RID: 169669 RVA: 0x00A2DBD5 File Offset: 0x00A2BDD5
		public override int GetHashCode()
		{
			return HashCode.Combine<TEnumAsByte<EYinlin_Type>, FName>(this.Type, this.SocketName);
		}

		// Token: 0x060296C6 RID: 169670 RVA: 0x00A2DBE8 File Offset: 0x00A2BDE8
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SYinlin_MeshSocket._ScriptStructPtr != 0) ? SYinlin_MeshSocket._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/Role/FemaleM/YinLin/Abilities/SYinlin_MeshSocket.SYinlin_MeshSocket", ref SYinlin_MeshSocket._ScriptStructPtr);
		}

		// Token: 0x0401610E RID: 90382
		[FieldOffset(0)]
		public TEnumAsByte<EYinlin_Type> Type;

		// Token: 0x0401610F RID: 90383
		[FieldOffset(4)]
		public FName SocketName;

		// Token: 0x04016110 RID: 90384
		public const string __ObjectPath = "/Game/Aki/Character/Role/FemaleM/YinLin/Abilities/SYinlin_MeshSocket.SYinlin_MeshSocket";

		// Token: 0x04016111 RID: 90385
		private static IntPtr _ScriptStructPtr;
	}
}
