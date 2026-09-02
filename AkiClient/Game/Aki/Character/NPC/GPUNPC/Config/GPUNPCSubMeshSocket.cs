using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.GPUNPC.Config
{
	// Token: 0x020040E3 RID: 16611
	[UnrealObjectPath("/Game/Aki/Character/NPC/GPUNPC/Config/GPUNPCSubMeshSocket.GPUNPCSubMeshSocket")]
	[UnrealStructLayout(80, 16, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 80)]
	public class GPUNPCSubMeshSocket : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602BC35 RID: 179253 RVA: 0x00A88810 File Offset: 0x00A86A10
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (GPUNPCSubMeshSocket._ScriptStructPtr != 0) ? GPUNPCSubMeshSocket._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/NPC/GPUNPC/Config/GPUNPCSubMeshSocket.GPUNPCSubMeshSocket", ref GPUNPCSubMeshSocket._ScriptStructPtr);
		}

		// Token: 0x17007407 RID: 29703
		// (get) Token: 0x0602BC36 RID: 179254 RVA: 0x00A88834 File Offset: 0x00A86A34
		// (set) Token: 0x0602BC37 RID: 179255 RVA: 0x00A88848 File Offset: 0x00A86A48
		[Nullable(2)]
		public unsafe USkeletalMesh SubMesh
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkeletalMesh>(base.NativePtr / (IntPtr)sizeof(void*) + GPUNPCSubMeshSocket.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GPUNPCSubMeshSocket.__PropertyOffset_0, value);
			}
		}

		// Token: 0x17007408 RID: 29704
		// (get) Token: 0x0602BC38 RID: 179256 RVA: 0x00A8885D File Offset: 0x00A86A5D
		// (set) Token: 0x0602BC39 RID: 179257 RVA: 0x00A88871 File Offset: 0x00A86A71
		public unsafe FName SocketName
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GPUNPCSubMeshSocket.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GPUNPCSubMeshSocket.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17007409 RID: 29705
		// (get) Token: 0x0602BC3A RID: 179258 RVA: 0x00A88886 File Offset: 0x00A86A86
		// (set) Token: 0x0602BC3B RID: 179259 RVA: 0x00A8889A File Offset: 0x00A86A9A
		public unsafe FTransform SocketTransform
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GPUNPCSubMeshSocket.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GPUNPCSubMeshSocket.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x0602BC3C RID: 179260 RVA: 0x00A888AF File Offset: 0x00A86AAF
		public GPUNPCSubMeshSocket()
		{
		}

		// Token: 0x0602BC3D RID: 179261 RVA: 0x00A888B7 File Offset: 0x00A86AB7
		[NullableContext(1)]
		public GPUNPCSubMeshSocket(USkeletalMesh SubMesh, FName SocketName, FTransform SocketTransform)
		{
			this.SubMesh = SubMesh;
			this.SocketName = SocketName;
			this.SocketTransform = SocketTransform;
		}

		// Token: 0x0602BC3E RID: 179262 RVA: 0x00A888D4 File Offset: 0x00A86AD4
		protected override IntPtr GetUStructPtr()
		{
			return GPUNPCSubMeshSocket.StaticStruct();
		}

		// Token: 0x0602BC3F RID: 179263 RVA: 0x00A888E0 File Offset: 0x00A86AE0
		[NullableContext(2)]
		public GPUNPCSubMeshSocket(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602BC40 RID: 179264 RVA: 0x00A888EA File Offset: 0x00A86AEA
		public GPUNPCSubMeshSocket(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602BC41 RID: 179265 RVA: 0x00A888F5 File Offset: 0x00A86AF5
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new GPUNPCSubMeshSocket(Pointer, false, true);
		}

		// Token: 0x0602BC42 RID: 179266 RVA: 0x00A888FF File Offset: 0x00A86AFF
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new GPUNPCSubMeshSocket(Pointer, MemoryOwner);
		}

		// Token: 0x040181C8 RID: 98760
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Character/NPC/GPUNPC/Config/GPUNPCSubMeshSocket.GPUNPCSubMeshSocket";

		// Token: 0x040181C9 RID: 98761
		private static IntPtr _ScriptStructPtr;

		// Token: 0x040181CA RID: 98762
		internal static int __PropertyOffset_0;

		// Token: 0x040181CB RID: 98763
		internal static int __PropertyOffset_1;

		// Token: 0x040181CC RID: 98764
		internal static int __PropertyOffset_2;
	}
}
