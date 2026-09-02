using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x02004287 RID: 17031
	[NullableContext(1)]
	[Nullable(0)]
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/SWeaponMesh.SWeaponMesh")]
	[UnrealStructLayout(112, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 112)]
	public class SWeaponMesh : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602D3E8 RID: 185320 RVA: 0x00ABAEA5 File Offset: 0x00AB90A5
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SWeaponMesh._ScriptStructPtr != 0) ? SWeaponMesh._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/BaseCharacter/SWeaponMesh.SWeaponMesh", ref SWeaponMesh._ScriptStructPtr);
		}

		// Token: 0x17007B52 RID: 31570
		// (get) Token: 0x0602D3E9 RID: 185321 RVA: 0x00ABAEC9 File Offset: 0x00AB90C9
		// (set) Token: 0x0602D3EA RID: 185322 RVA: 0x00ABAEDD File Offset: 0x00AB90DD
		public unsafe FName SocketName
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SWeaponMesh.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SWeaponMesh.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17007B53 RID: 31571
		// (get) Token: 0x0602D3EB RID: 185323 RVA: 0x00ABAEF2 File Offset: 0x00AB90F2
		// (set) Token: 0x0602D3EC RID: 185324 RVA: 0x00ABAF11 File Offset: 0x00AB9111
		public TSoftObjectPtr<USkeletalMesh> MeshSoftPtr
		{
			get
			{
				return new TSoftObjectPtr<USkeletalMesh>(base.NativePtr + (IntPtr)SWeaponMesh.__PropertyOffset_1, base.MemoryOwner ?? this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)SWeaponMesh.__PropertyOffset_1, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17007B54 RID: 31572
		// (get) Token: 0x0602D3ED RID: 185325 RVA: 0x00ABAF36 File Offset: 0x00AB9136
		// (set) Token: 0x0602D3EE RID: 185326 RVA: 0x00ABAF55 File Offset: 0x00AB9155
		public TSoftClassPtr<UAnimInstance> AnimInstanceSoftPtr
		{
			get
			{
				return new TSoftClassPtr<UAnimInstance>(base.NativePtr + (IntPtr)SWeaponMesh.__PropertyOffset_2, base.MemoryOwner ?? this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)SWeaponMesh.__PropertyOffset_2, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x0602D3EF RID: 185327 RVA: 0x00ABAF7A File Offset: 0x00AB917A
		public SWeaponMesh()
		{
		}

		// Token: 0x0602D3F0 RID: 185328 RVA: 0x00ABAF82 File Offset: 0x00AB9182
		public SWeaponMesh(FName SocketName, TSoftObjectPtr<USkeletalMesh> MeshSoftPtr, TSoftClassPtr<UAnimInstance> AnimInstanceSoftPtr)
		{
			this.SocketName = SocketName;
			this.MeshSoftPtr = MeshSoftPtr;
			this.AnimInstanceSoftPtr = AnimInstanceSoftPtr;
		}

		// Token: 0x0602D3F1 RID: 185329 RVA: 0x00ABAF9F File Offset: 0x00AB919F
		protected override IntPtr GetUStructPtr()
		{
			return SWeaponMesh.StaticStruct();
		}

		// Token: 0x0602D3F2 RID: 185330 RVA: 0x00ABAFAB File Offset: 0x00AB91AB
		[NullableContext(2)]
		public SWeaponMesh(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602D3F3 RID: 185331 RVA: 0x00ABAFB5 File Offset: 0x00AB91B5
		public SWeaponMesh(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602D3F4 RID: 185332 RVA: 0x00ABAFC0 File Offset: 0x00AB91C0
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SWeaponMesh(Pointer, false, true);
		}

		// Token: 0x0602D3F5 RID: 185333 RVA: 0x00ABAFCA File Offset: 0x00AB91CA
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SWeaponMesh(Pointer, MemoryOwner);
		}

		// Token: 0x040195CD RID: 103885
		public const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/SWeaponMesh.SWeaponMesh";

		// Token: 0x040195CE RID: 103886
		private static IntPtr _ScriptStructPtr;

		// Token: 0x040195CF RID: 103887
		internal static int __PropertyOffset_0;

		// Token: 0x040195D0 RID: 103888
		internal static int __PropertyOffset_1;

		// Token: 0x040195D1 RID: 103889
		internal static int __PropertyOffset_2;
	}
}
