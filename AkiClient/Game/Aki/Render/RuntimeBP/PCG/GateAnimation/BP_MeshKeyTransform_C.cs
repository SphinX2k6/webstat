using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.GateAnimation
{
	// Token: 0x02003C31 RID: 15409
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/GateAnimation/BP_MeshKeyTransform.BP_MeshKeyTransform_C")]
	[UnrealStructLayout(1184, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1184)]
	public class BP_MeshKeyTransform_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060234E8 RID: 144616 RVA: 0x0097E580 File Offset: 0x0097C780
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_MeshKeyTransform_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/GateAnimation/BP_MeshKeyTransform.BP_MeshKeyTransform_C");
			}
			return BP_MeshKeyTransform_C._ClassPtr;
		}

		// Token: 0x060234E9 RID: 144617 RVA: 0x0097E5A4 File Offset: 0x0097C7A4
		public BP_MeshKeyTransform_C() : this(BuiltinUtils.AllocNativeUObject(BP_MeshKeyTransform_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060234EA RID: 144618 RVA: 0x0097E5CC File Offset: 0x0097C7CC
		[NullableContext(1)]
		public BP_MeshKeyTransform_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_MeshKeyTransform_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170045AC RID: 17836
		// (get) Token: 0x060234EB RID: 144619 RVA: 0x0097E5FF File Offset: 0x0097C7FF
		// (set) Token: 0x060234EC RID: 144620 RVA: 0x0097E613 File Offset: 0x0097C813
		public unsafe UStaticMeshComponent StaticMeshComponent
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_MeshKeyTransform_C.__PropertyOffset_0);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_MeshKeyTransform_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x170045AD RID: 17837
		// (get) Token: 0x060234ED RID: 144621 RVA: 0x0097E628 File Offset: 0x0097C828
		// (set) Token: 0x060234EE RID: 144622 RVA: 0x0097E63C File Offset: 0x0097C83C
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_MeshKeyTransform_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_MeshKeyTransform_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170045AE RID: 17838
		// (get) Token: 0x060234EF RID: 144623 RVA: 0x0097E651 File Offset: 0x0097C851
		// (set) Token: 0x060234F0 RID: 144624 RVA: 0x0097E665 File Offset: 0x0097C865
		public unsafe UStaticMesh Static_Mesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMesh>(base.NativePtr / (IntPtr)sizeof(void*) + BP_MeshKeyTransform_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_MeshKeyTransform_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x170045AF RID: 17839
		// (get) Token: 0x060234F1 RID: 144625 RVA: 0x0097E67A File Offset: 0x0097C87A
		// (set) Token: 0x060234F2 RID: 144626 RVA: 0x0097E68E File Offset: 0x0097C88E
		public unsafe FTransformDouble NewTransform
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MeshKeyTransform_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MeshKeyTransform_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x170045B0 RID: 17840
		// (get) Token: 0x060234F3 RID: 144627 RVA: 0x0097E6A3 File Offset: 0x0097C8A3
		// (set) Token: 0x060234F4 RID: 144628 RVA: 0x0097E6B7 File Offset: 0x0097C8B7
		public unsafe FTransformDouble OldTransform
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MeshKeyTransform_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MeshKeyTransform_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x060234F5 RID: 144629 RVA: 0x0097E6CC File Offset: 0x0097C8CC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MeshKeyTransform_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x060234F6 RID: 144630 RVA: 0x0097E6E0 File Offset: 0x0097C8E0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_MeshKeyTransform_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060234F7 RID: 144631 RVA: 0x0097E6F5 File Offset: 0x0097C8F5
		protected BP_MeshKeyTransform_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04011F5E RID: 73566
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/GateAnimation/BP_MeshKeyTransform.BP_MeshKeyTransform_C";

		// Token: 0x04011F5F RID: 73567
		private static IntPtr _ClassPtr;

		// Token: 0x04011F60 RID: 73568
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04011F61 RID: 73569
		internal static int __PropertyOffset_0;

		// Token: 0x04011F62 RID: 73570
		internal static int __PropertyOffset_1;

		// Token: 0x04011F63 RID: 73571
		internal static int __PropertyOffset_2;

		// Token: 0x04011F64 RID: 73572
		internal static int __PropertyOffset_3;

		// Token: 0x04011F65 RID: 73573
		internal static int __PropertyOffset_4;

		// Token: 0x04011F66 RID: 73574
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;
	}
}
