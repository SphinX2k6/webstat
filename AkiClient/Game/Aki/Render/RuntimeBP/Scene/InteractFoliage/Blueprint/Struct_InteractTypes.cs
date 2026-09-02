using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Scene.InteractFoliage.Blueprint.MeshActor;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.InteractFoliage.Blueprint
{
	// Token: 0x02003AD4 RID: 15060
	[NullableContext(2)]
	[Nullable(0)]
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/InteractFoliage/Blueprint/Struct_InteractTypes.Struct_InteractTypes")]
	[UnrealStructLayout(32, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 32)]
	public class Struct_InteractTypes : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06020372 RID: 131954 RVA: 0x0092598B File Offset: 0x00923B8B
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (Struct_InteractTypes._ScriptStructPtr != 0) ? Struct_InteractTypes._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Render/RuntimeBP/Scene/InteractFoliage/Blueprint/Struct_InteractTypes.Struct_InteractTypes", ref Struct_InteractTypes._ScriptStructPtr);
		}

		// Token: 0x17003477 RID: 13431
		// (get) Token: 0x06020373 RID: 131955 RVA: 0x009259AF File Offset: 0x00923BAF
		// (set) Token: 0x06020374 RID: 131956 RVA: 0x009259C3 File Offset: 0x00923BC3
		public unsafe UStaticMesh StaticMesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMesh>(base.NativePtr / (IntPtr)sizeof(void*) + Struct_InteractTypes.__PropertyOffset_0);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + Struct_InteractTypes.__PropertyOffset_0, value);
			}
		}

		// Token: 0x17003478 RID: 13432
		// (get) Token: 0x06020375 RID: 131957 RVA: 0x009259D8 File Offset: 0x00923BD8
		// (set) Token: 0x06020376 RID: 131958 RVA: 0x009259EC File Offset: 0x00923BEC
		public unsafe USkeletalMesh SkeletonMesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkeletalMesh>(base.NativePtr / (IntPtr)sizeof(void*) + Struct_InteractTypes.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + Struct_InteractTypes.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17003479 RID: 13433
		// (get) Token: 0x06020377 RID: 131959 RVA: 0x00925A01 File Offset: 0x00923C01
		// (set) Token: 0x06020378 RID: 131960 RVA: 0x00925A11 File Offset: 0x00923C11
		public unsafe float TraceRadius
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Struct_InteractTypes.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Struct_InteractTypes.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x1700347A RID: 13434
		// (get) Token: 0x06020379 RID: 131961 RVA: 0x00925A22 File Offset: 0x00923C22
		// (set) Token: 0x0602037A RID: 131962 RVA: 0x00925A36 File Offset: 0x00923C36
		public unsafe KUROInteractFoliage_C FoliageType
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<KUROInteractFoliage_C>(base.NativePtr / (IntPtr)sizeof(void*) + Struct_InteractTypes.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + Struct_InteractTypes.__PropertyOffset_3, value);
			}
		}

		// Token: 0x0602037B RID: 131963 RVA: 0x00925A4B File Offset: 0x00923C4B
		public Struct_InteractTypes()
		{
		}

		// Token: 0x0602037C RID: 131964 RVA: 0x00925A53 File Offset: 0x00923C53
		[NullableContext(1)]
		public Struct_InteractTypes(UStaticMesh StaticMesh, USkeletalMesh SkeletonMesh, float TraceRadius, KUROInteractFoliage_C FoliageType)
		{
			this.StaticMesh = StaticMesh;
			this.SkeletonMesh = SkeletonMesh;
			this.TraceRadius = TraceRadius;
			this.FoliageType = FoliageType;
		}

		// Token: 0x0602037D RID: 131965 RVA: 0x00925A78 File Offset: 0x00923C78
		protected override IntPtr GetUStructPtr()
		{
			return Struct_InteractTypes.StaticStruct();
		}

		// Token: 0x0602037E RID: 131966 RVA: 0x00925A84 File Offset: 0x00923C84
		public Struct_InteractTypes(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602037F RID: 131967 RVA: 0x00925A8E File Offset: 0x00923C8E
		public Struct_InteractTypes(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06020380 RID: 131968 RVA: 0x00925A99 File Offset: 0x00923C99
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new Struct_InteractTypes(Pointer, false, true);
		}

		// Token: 0x06020381 RID: 131969 RVA: 0x00925AA3 File Offset: 0x00923CA3
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new Struct_InteractTypes(Pointer, MemoryOwner);
		}

		// Token: 0x04010108 RID: 65800
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/InteractFoliage/Blueprint/Struct_InteractTypes.Struct_InteractTypes";

		// Token: 0x04010109 RID: 65801
		private static IntPtr _ScriptStructPtr;

		// Token: 0x0401010A RID: 65802
		internal static int __PropertyOffset_0;

		// Token: 0x0401010B RID: 65803
		internal static int __PropertyOffset_1;

		// Token: 0x0401010C RID: 65804
		internal static int __PropertyOffset_2;

		// Token: 0x0401010D RID: 65805
		internal static int __PropertyOffset_3;
	}
}
