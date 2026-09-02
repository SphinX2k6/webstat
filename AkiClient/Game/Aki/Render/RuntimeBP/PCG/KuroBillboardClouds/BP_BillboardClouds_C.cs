using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.KuroBillboardClouds
{
	// Token: 0x02003C08 RID: 15368
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/KuroBillboardClouds/BP_BillboardClouds.BP_BillboardClouds_C")]
	[UnrealStructLayout(1104, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1098)]
	public class BP_BillboardClouds_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06022E1C RID: 142876 RVA: 0x00971EDF File Offset: 0x009700DF
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_BillboardClouds_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/KuroBillboardClouds/BP_BillboardClouds.BP_BillboardClouds_C");
			}
			return BP_BillboardClouds_C._ClassPtr;
		}

		// Token: 0x06022E1D RID: 142877 RVA: 0x00971F04 File Offset: 0x00970104
		public BP_BillboardClouds_C() : this(BuiltinUtils.AllocNativeUObject(BP_BillboardClouds_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06022E1E RID: 142878 RVA: 0x00971F2C File Offset: 0x0097012C
		[NullableContext(1)]
		public BP_BillboardClouds_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_BillboardClouds_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700433D RID: 17213
		// (get) Token: 0x06022E1F RID: 142879 RVA: 0x00971F60 File Offset: 0x00970160
		// (set) Token: 0x06022E20 RID: 142880 RVA: 0x00971F99 File Offset: 0x00970199
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_BillboardClouds_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_BillboardClouds_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700433E RID: 17214
		// (get) Token: 0x06022E21 RID: 142881 RVA: 0x00971FBA File Offset: 0x009701BA
		// (set) Token: 0x06022E22 RID: 142882 RVA: 0x00971FCE File Offset: 0x009701CE
		public unsafe UNiagaraComponent NS_BillboardClouds
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BillboardClouds_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BillboardClouds_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x1700433F RID: 17215
		// (get) Token: 0x06022E23 RID: 142883 RVA: 0x00971FE3 File Offset: 0x009701E3
		// (set) Token: 0x06022E24 RID: 142884 RVA: 0x00971FF7 File Offset: 0x009701F7
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BillboardClouds_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BillboardClouds_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17004340 RID: 17216
		// (get) Token: 0x06022E25 RID: 142885 RVA: 0x0097200C File Offset: 0x0097020C
		// (set) Token: 0x06022E26 RID: 142886 RVA: 0x0097201C File Offset: 0x0097021C
		public unsafe float Velocity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BillboardClouds_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BillboardClouds_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17004341 RID: 17217
		// (get) Token: 0x06022E27 RID: 142887 RVA: 0x0097202D File Offset: 0x0097022D
		// (set) Token: 0x06022E28 RID: 142888 RVA: 0x0097203D File Offset: 0x0097023D
		public unsafe float lifetime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BillboardClouds_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BillboardClouds_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17004342 RID: 17218
		// (get) Token: 0x06022E29 RID: 142889 RVA: 0x0097204E File Offset: 0x0097024E
		// (set) Token: 0x06022E2A RID: 142890 RVA: 0x0097205E File Offset: 0x0097025E
		public unsafe float CloudScale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BillboardClouds_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BillboardClouds_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17004343 RID: 17219
		// (get) Token: 0x06022E2B RID: 142891 RVA: 0x0097206F File Offset: 0x0097026F
		// (set) Token: 0x06022E2C RID: 142892 RVA: 0x0097207F File Offset: 0x0097027F
		public unsafe float CloudMinAlpha
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BillboardClouds_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BillboardClouds_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17004344 RID: 17220
		// (get) Token: 0x06022E2D RID: 142893 RVA: 0x00972090 File Offset: 0x00970290
		// (set) Token: 0x06022E2E RID: 142894 RVA: 0x009720A0 File Offset: 0x009702A0
		public unsafe float CloudMaxAlpha
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BillboardClouds_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BillboardClouds_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17004345 RID: 17221
		// (get) Token: 0x06022E2F RID: 142895 RVA: 0x009720B1 File Offset: 0x009702B1
		// (set) Token: 0x06022E30 RID: 142896 RVA: 0x009720C1 File Offset: 0x009702C1
		public unsafe float CloudSpriteSizeX
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BillboardClouds_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BillboardClouds_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17004346 RID: 17222
		// (get) Token: 0x06022E31 RID: 142897 RVA: 0x009720D2 File Offset: 0x009702D2
		// (set) Token: 0x06022E32 RID: 142898 RVA: 0x009720E2 File Offset: 0x009702E2
		public unsafe float CloudSpriteSizeY
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BillboardClouds_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BillboardClouds_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17004347 RID: 17223
		// (get) Token: 0x06022E33 RID: 142899 RVA: 0x009720F3 File Offset: 0x009702F3
		// (set) Token: 0x06022E34 RID: 142900 RVA: 0x00972107 File Offset: 0x00970307
		public unsafe UHoudiniPointCache houd
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UHoudiniPointCache>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BillboardClouds_C.__PropertyOffset_10);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BillboardClouds_C.__PropertyOffset_10, value);
			}
		}

		// Token: 0x17004348 RID: 17224
		// (get) Token: 0x06022E35 RID: 142901 RVA: 0x0097211C File Offset: 0x0097031C
		// (set) Token: 0x06022E36 RID: 142902 RVA: 0x0097212C File Offset: 0x0097032C
		public unsafe bool bEditorTick
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BillboardClouds_C.__PropertyOffset_11) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BillboardClouds_C.__PropertyOffset_11) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004349 RID: 17225
		// (get) Token: 0x06022E37 RID: 142903 RVA: 0x0097213D File Offset: 0x0097033D
		// (set) Token: 0x06022E38 RID: 142904 RVA: 0x0097214D File Offset: 0x0097034D
		public unsafe bool bVisible
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BillboardClouds_C.__PropertyOffset_12) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BillboardClouds_C.__PropertyOffset_12) = (value ? 1 : 0);
			}
		}

		// Token: 0x06022E39 RID: 142905 RVA: 0x0097215E File Offset: 0x0097035E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BillboardClouds_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06022E3A RID: 142906 RVA: 0x00972172 File Offset: 0x00970372
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_BillboardClouds_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06022E3B RID: 142907 RVA: 0x00972187 File Offset: 0x00970387
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EditorTick()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BillboardClouds_C.__EditorTick_NativeFunctionPtr, null);
		}

		// Token: 0x06022E3C RID: 142908 RVA: 0x0097219C File Offset: 0x0097039C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_BillboardClouds(int EntryPoint)
		{
			BP_BillboardClouds_C.__ExecuteUbergraph_BP_BillboardClouds_FunctionParams* ptr = stackalloc BP_BillboardClouds_C.__ExecuteUbergraph_BP_BillboardClouds_FunctionParams[(UIntPtr)87] + 15L / (long)sizeof(BP_BillboardClouds_C.__ExecuteUbergraph_BP_BillboardClouds_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BillboardClouds_C.__ExecuteUbergraph_BP_BillboardClouds_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_BillboardClouds_C.__ExecuteUbergraph_BP_BillboardClouds_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06022E3D RID: 142909 RVA: 0x009721E3 File Offset: 0x009703E3
		protected BP_BillboardClouds_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04011B5F RID: 72543
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/KuroBillboardClouds/BP_BillboardClouds.BP_BillboardClouds_C";

		// Token: 0x04011B60 RID: 72544
		private static IntPtr _ClassPtr;

		// Token: 0x04011B61 RID: 72545
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04011B62 RID: 72546
		internal static int __PropertyOffset_0;

		// Token: 0x04011B63 RID: 72547
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04011B64 RID: 72548
		internal static int __PropertyOffset_1;

		// Token: 0x04011B65 RID: 72549
		internal static int __PropertyOffset_2;

		// Token: 0x04011B66 RID: 72550
		internal static int __PropertyOffset_3;

		// Token: 0x04011B67 RID: 72551
		internal static int __PropertyOffset_4;

		// Token: 0x04011B68 RID: 72552
		internal static int __PropertyOffset_5;

		// Token: 0x04011B69 RID: 72553
		internal static int __PropertyOffset_6;

		// Token: 0x04011B6A RID: 72554
		internal static int __PropertyOffset_7;

		// Token: 0x04011B6B RID: 72555
		internal static int __PropertyOffset_8;

		// Token: 0x04011B6C RID: 72556
		internal static int __PropertyOffset_9;

		// Token: 0x04011B6D RID: 72557
		internal static int __PropertyOffset_10;

		// Token: 0x04011B6E RID: 72558
		internal static int __PropertyOffset_11;

		// Token: 0x04011B6F RID: 72559
		internal static int __PropertyOffset_12;

		// Token: 0x04011B70 RID: 72560
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04011B71 RID: 72561
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x04011B72 RID: 72562
		private static IntPtr __ExecuteUbergraph_BP_BillboardClouds_NativeFunctionPtr;

		// Token: 0x02009C44 RID: 40004
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 72)]
		protected ref struct __ExecuteUbergraph_BP_BillboardClouds_FunctionParams
		{
			// Token: 0x040324E9 RID: 206057
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
