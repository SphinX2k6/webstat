using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.GoldenBoughGround.YueGuiJinZhi_ES3
{
	// Token: 0x02003C2F RID: 15407
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/GoldenBoughGround/YueGuiJinZhi_ES3/BP_YGJZ_ActorChangeMaterial_Static.BP_YGJZ_ActorChangeMaterial_Static_C")]
	[UnrealStructLayout(256, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 256)]
	public class BP_YGJZ_ActorChangeMaterial_Static_C : UActorComponent, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060234B9 RID: 144569 RVA: 0x0097DFC0 File Offset: 0x0097C1C0
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_YGJZ_ActorChangeMaterial_Static_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/GoldenBoughGround/YueGuiJinZhi_ES3/BP_YGJZ_ActorChangeMaterial_Static.BP_YGJZ_ActorChangeMaterial_Static_C");
			}
			return BP_YGJZ_ActorChangeMaterial_Static_C._ClassPtr;
		}

		// Token: 0x060234BA RID: 144570 RVA: 0x0097DFE4 File Offset: 0x0097C1E4
		public BP_YGJZ_ActorChangeMaterial_Static_C() : this(BuiltinUtils.AllocNativeUObject(BP_YGJZ_ActorChangeMaterial_Static_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060234BB RID: 144571 RVA: 0x0097E00C File Offset: 0x0097C20C
		[NullableContext(1)]
		public BP_YGJZ_ActorChangeMaterial_Static_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_YGJZ_ActorChangeMaterial_Static_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700459F RID: 17823
		// (get) Token: 0x060234BC RID: 144572 RVA: 0x0097E040 File Offset: 0x0097C240
		// (set) Token: 0x060234BD RID: 144573 RVA: 0x0097E079 File Offset: 0x0097C279
		[Nullable(1)]
		public FPointerToUberGraphFrame UberGraphFrame
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_YGJZ_ActorChangeMaterial_Static_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_YGJZ_ActorChangeMaterial_Static_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170045A0 RID: 17824
		// (get) Token: 0x060234BE RID: 144574 RVA: 0x0097E09A File Offset: 0x0097C29A
		// (set) Token: 0x060234BF RID: 144575 RVA: 0x0097E0AA File Offset: 0x0097C2AA
		public unsafe bool Is_Android
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_YGJZ_ActorChangeMaterial_Static_C.__PropertyOffset_1) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_YGJZ_ActorChangeMaterial_Static_C.__PropertyOffset_1) = (value ? 1 : 0);
			}
		}

		// Token: 0x170045A1 RID: 17825
		// (get) Token: 0x060234C0 RID: 144576 RVA: 0x0097E0BB File Offset: 0x0097C2BB
		// (set) Token: 0x060234C1 RID: 144577 RVA: 0x0097E0CF File Offset: 0x0097C2CF
		public unsafe UMaterialInstance StaticMesh_ShuGan
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_YGJZ_ActorChangeMaterial_Static_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_YGJZ_ActorChangeMaterial_Static_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x170045A2 RID: 17826
		// (get) Token: 0x060234C2 RID: 144578 RVA: 0x0097E0E4 File Offset: 0x0097C2E4
		// (set) Token: 0x060234C3 RID: 144579 RVA: 0x0097E0F8 File Offset: 0x0097C2F8
		public unsafe UMaterialInstance StaticMesh_ShuZhi
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_YGJZ_ActorChangeMaterial_Static_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_YGJZ_ActorChangeMaterial_Static_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x170045A3 RID: 17827
		// (get) Token: 0x060234C4 RID: 144580 RVA: 0x0097E10D File Offset: 0x0097C30D
		// (set) Token: 0x060234C5 RID: 144581 RVA: 0x0097E121 File Offset: 0x0097C321
		public unsafe UMaterialInstance StaticMesh_ShuZhi_LOD1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_YGJZ_ActorChangeMaterial_Static_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_YGJZ_ActorChangeMaterial_Static_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x170045A4 RID: 17828
		// (get) Token: 0x060234C6 RID: 144582 RVA: 0x0097E136 File Offset: 0x0097C336
		// (set) Token: 0x060234C7 RID: 144583 RVA: 0x0097E14A File Offset: 0x0097C34A
		public unsafe UMaterialInstance StaticMesh_ShuGan_LOD1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_YGJZ_ActorChangeMaterial_Static_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_YGJZ_ActorChangeMaterial_Static_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x060234C8 RID: 144584 RVA: 0x0097E15F File Offset: 0x0097C35F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Is_ES3()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_YGJZ_ActorChangeMaterial_Static_C.__Is_ES3_NativeFunctionPtr, null);
		}

		// Token: 0x060234C9 RID: 144585 RVA: 0x0097E173 File Offset: 0x0097C373
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_YGJZ_ActorChangeMaterial_Static_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x060234CA RID: 144586 RVA: 0x0097E187 File Offset: 0x0097C387
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_YGJZ_ActorChangeMaterial_Static_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060234CB RID: 144587 RVA: 0x0097E19C File Offset: 0x0097C39C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_YGJZ_ActorChangeMaterial_Static(int EntryPoint)
		{
			BP_YGJZ_ActorChangeMaterial_Static_C.__ExecuteUbergraph_BP_YGJZ_ActorChangeMaterial_Static_FunctionParams* ptr = stackalloc BP_YGJZ_ActorChangeMaterial_Static_C.__ExecuteUbergraph_BP_YGJZ_ActorChangeMaterial_Static_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_YGJZ_ActorChangeMaterial_Static_C.__ExecuteUbergraph_BP_YGJZ_ActorChangeMaterial_Static_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_YGJZ_ActorChangeMaterial_Static_C.__ExecuteUbergraph_BP_YGJZ_ActorChangeMaterial_Static_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_YGJZ_ActorChangeMaterial_Static_C.__ExecuteUbergraph_BP_YGJZ_ActorChangeMaterial_Static_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060234CC RID: 144588 RVA: 0x0097E1E3 File Offset: 0x0097C3E3
		protected BP_YGJZ_ActorChangeMaterial_Static_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04011F3F RID: 73535
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/GoldenBoughGround/YueGuiJinZhi_ES3/BP_YGJZ_ActorChangeMaterial_Static.BP_YGJZ_ActorChangeMaterial_Static_C";

		// Token: 0x04011F40 RID: 73536
		private static IntPtr _ClassPtr;

		// Token: 0x04011F41 RID: 73537
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04011F42 RID: 73538
		internal static int __PropertyOffset_0;

		// Token: 0x04011F43 RID: 73539
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04011F44 RID: 73540
		internal static int __PropertyOffset_1;

		// Token: 0x04011F45 RID: 73541
		internal static int __PropertyOffset_2;

		// Token: 0x04011F46 RID: 73542
		internal static int __PropertyOffset_3;

		// Token: 0x04011F47 RID: 73543
		internal static int __PropertyOffset_4;

		// Token: 0x04011F48 RID: 73544
		internal static int __PropertyOffset_5;

		// Token: 0x04011F49 RID: 73545
		private static IntPtr __Is_ES3_NativeFunctionPtr;

		// Token: 0x04011F4A RID: 73546
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04011F4B RID: 73547
		private static IntPtr __ExecuteUbergraph_BP_YGJZ_ActorChangeMaterial_Static_NativeFunctionPtr;

		// Token: 0x02009CB9 RID: 40121
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __ExecuteUbergraph_BP_YGJZ_ActorChangeMaterial_Static_FunctionParams
		{
			// Token: 0x0403261B RID: 206363
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
