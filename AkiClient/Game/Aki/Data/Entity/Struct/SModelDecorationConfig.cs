using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.Entity.Struct
{
	// Token: 0x02003EF7 RID: 16119
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Data/Entity/Struct/SModelDecorationConfig.SModelDecorationConfig")]
	[UnrealStructLayout(112, 16, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 112)]
	public class SModelDecorationConfig : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x060282BC RID: 164540 RVA: 0x00A04588 File Offset: 0x00A02788
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SModelDecorationConfig._ScriptStructPtr != 0) ? SModelDecorationConfig._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Entity/Struct/SModelDecorationConfig.SModelDecorationConfig", ref SModelDecorationConfig._ScriptStructPtr);
		}

		// Token: 0x170060EC RID: 24812
		// (get) Token: 0x060282BD RID: 164541 RVA: 0x00A045AC File Offset: 0x00A027AC
		// (set) Token: 0x060282BE RID: 164542 RVA: 0x00A045C0 File Offset: 0x00A027C0
		public unsafe string SocketName
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SModelDecorationConfig.__PropertyOffset_0)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SModelDecorationConfig.__PropertyOffset_0)), value);
			}
		}

		// Token: 0x170060ED RID: 24813
		// (get) Token: 0x060282BF RID: 164543 RVA: 0x00A045D5 File Offset: 0x00A027D5
		// (set) Token: 0x060282C0 RID: 164544 RVA: 0x00A045E9 File Offset: 0x00A027E9
		public unsafe FTransform Transform
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SModelDecorationConfig.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SModelDecorationConfig.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x170060EE RID: 24814
		// (get) Token: 0x060282C1 RID: 164545 RVA: 0x00A045FE File Offset: 0x00A027FE
		// (set) Token: 0x060282C2 RID: 164546 RVA: 0x00A0461D File Offset: 0x00A0281D
		public TSoftObjectPtr<USkeletalMesh> SkeletalMesh
		{
			get
			{
				return new TSoftObjectPtr<USkeletalMesh>(base.NativePtr + (IntPtr)SModelDecorationConfig.__PropertyOffset_2, base.MemoryOwner ?? this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)SModelDecorationConfig.__PropertyOffset_2, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x060282C3 RID: 164547 RVA: 0x00A04642 File Offset: 0x00A02842
		public SModelDecorationConfig()
		{
		}

		// Token: 0x060282C4 RID: 164548 RVA: 0x00A0464A File Offset: 0x00A0284A
		public SModelDecorationConfig(string SocketName, FTransform Transform, TSoftObjectPtr<USkeletalMesh> SkeletalMesh)
		{
			this.SocketName = SocketName;
			this.Transform = Transform;
			this.SkeletalMesh = SkeletalMesh;
		}

		// Token: 0x060282C5 RID: 164549 RVA: 0x00A04667 File Offset: 0x00A02867
		protected override IntPtr GetUStructPtr()
		{
			return SModelDecorationConfig.StaticStruct();
		}

		// Token: 0x060282C6 RID: 164550 RVA: 0x00A04673 File Offset: 0x00A02873
		[NullableContext(2)]
		public SModelDecorationConfig(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x060282C7 RID: 164551 RVA: 0x00A0467D File Offset: 0x00A0287D
		public SModelDecorationConfig(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x060282C8 RID: 164552 RVA: 0x00A04688 File Offset: 0x00A02888
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SModelDecorationConfig(Pointer, false, true);
		}

		// Token: 0x060282C9 RID: 164553 RVA: 0x00A04692 File Offset: 0x00A02892
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SModelDecorationConfig(Pointer, MemoryOwner);
		}

		// Token: 0x0401519C RID: 86428
		public const string __ObjectPath = "/Game/Aki/Data/Entity/Struct/SModelDecorationConfig.SModelDecorationConfig";

		// Token: 0x0401519D RID: 86429
		private static IntPtr _ScriptStructPtr;

		// Token: 0x0401519E RID: 86430
		internal static int __PropertyOffset_0;

		// Token: 0x0401519F RID: 86431
		internal static int __PropertyOffset_1;

		// Token: 0x040151A0 RID: 86432
		internal static int __PropertyOffset_2;
	}
}
