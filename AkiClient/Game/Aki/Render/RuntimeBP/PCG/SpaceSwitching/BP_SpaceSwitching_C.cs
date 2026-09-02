using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.SpaceSwitching
{
	// Token: 0x02003B69 RID: 15209
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/SpaceSwitching/BP_SpaceSwitching.BP_SpaceSwitching_C")]
	[UnrealStructLayout(1384, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1384)]
	public class BP_SpaceSwitching_C : AKuroBPActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060216F0 RID: 136944 RVA: 0x0094910C File Offset: 0x0094730C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SpaceSwitching_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/SpaceSwitching/BP_SpaceSwitching.BP_SpaceSwitching_C");
			}
			return BP_SpaceSwitching_C._ClassPtr;
		}

		// Token: 0x060216F1 RID: 136945 RVA: 0x00949130 File Offset: 0x00947330
		public BP_SpaceSwitching_C() : this(BuiltinUtils.AllocNativeUObject(BP_SpaceSwitching_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060216F2 RID: 136946 RVA: 0x00949158 File Offset: 0x00947358
		[NullableContext(1)]
		public BP_SpaceSwitching_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SpaceSwitching_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003B23 RID: 15139
		// (get) Token: 0x060216F3 RID: 136947 RVA: 0x0094918C File Offset: 0x0094738C
		// (set) Token: 0x060216F4 RID: 136948 RVA: 0x009491C5 File Offset: 0x009473C5
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_SpaceSwitching_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_SpaceSwitching_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17003B24 RID: 15140
		// (get) Token: 0x060216F5 RID: 136949 RVA: 0x009491E6 File Offset: 0x009473E6
		// (set) Token: 0x060216F6 RID: 136950 RVA: 0x009491FA File Offset: 0x009473FA
		public unsafe UStaticMeshComponent Plane
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SpaceSwitching_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SpaceSwitching_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17003B25 RID: 15141
		// (get) Token: 0x060216F7 RID: 136951 RVA: 0x0094920F File Offset: 0x0094740F
		// (set) Token: 0x060216F8 RID: 136952 RVA: 0x00949223 File Offset: 0x00947423
		public unsafe UStaticMeshComponent SM_Div_Doo_01AM1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SpaceSwitching_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SpaceSwitching_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17003B26 RID: 15142
		// (get) Token: 0x060216F9 RID: 136953 RVA: 0x00949238 File Offset: 0x00947438
		// (set) Token: 0x060216FA RID: 136954 RVA: 0x0094924C File Offset: 0x0094744C
		public unsafe UStaticMeshComponent SM_Div_Doo_01AM
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SpaceSwitching_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SpaceSwitching_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17003B27 RID: 15143
		// (get) Token: 0x060216FB RID: 136955 RVA: 0x00949261 File Offset: 0x00947461
		// (set) Token: 0x060216FC RID: 136956 RVA: 0x00949275 File Offset: 0x00947475
		public unsafe UNiagaraComponent NS_Fx_SpaceSwitching
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SpaceSwitching_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SpaceSwitching_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17003B28 RID: 15144
		// (get) Token: 0x060216FD RID: 136957 RVA: 0x0094928A File Offset: 0x0094748A
		// (set) Token: 0x060216FE RID: 136958 RVA: 0x0094929E File Offset: 0x0094749E
		public unsafe USplineComponent Spline
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USplineComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SpaceSwitching_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SpaceSwitching_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x17003B29 RID: 15145
		// (get) Token: 0x060216FF RID: 136959 RVA: 0x009492B3 File Offset: 0x009474B3
		// (set) Token: 0x06021700 RID: 136960 RVA: 0x009492C7 File Offset: 0x009474C7
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SpaceSwitching_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SpaceSwitching_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x17003B2A RID: 15146
		// (get) Token: 0x06021701 RID: 136961 RVA: 0x009492DC File Offset: 0x009474DC
		// (set) Token: 0x06021702 RID: 136962 RVA: 0x009492EC File Offset: 0x009474EC
		public unsafe float DoorDissolveTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SpaceSwitching_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SpaceSwitching_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17003B2B RID: 15147
		// (get) Token: 0x06021703 RID: 136963 RVA: 0x009492FD File Offset: 0x009474FD
		// (set) Token: 0x06021704 RID: 136964 RVA: 0x0094930D File Offset: 0x0094750D
		public unsafe float ParticleDisplayTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SpaceSwitching_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SpaceSwitching_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17003B2C RID: 15148
		// (get) Token: 0x06021705 RID: 136965 RVA: 0x00949320 File Offset: 0x00947520
		// (set) Token: 0x06021706 RID: 136966 RVA: 0x00949359 File Offset: 0x00947559
		[Nullable(1)]
		public TArray<UMaterialInstanceDynamic> DMI
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<UMaterialInstanceDynamic> result;
				if ((result = this._DMI) == null)
				{
					result = (this._DMI = new TArray<UMaterialInstanceDynamic>(base.NativePtr + (IntPtr)BP_SpaceSwitching_C.__PropertyOffset_9, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.DMI.CopyAssign(value);
			}
		}

		// Token: 0x06021707 RID: 136967 RVA: 0x00949367 File Offset: 0x00947567
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void SetParam()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SpaceSwitching_C.__SetParam_NativeFunctionPtr, null);
		}

		// Token: 0x06021708 RID: 136968 RVA: 0x0094937B File Offset: 0x0094757B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SpaceSwitching_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06021709 RID: 136969 RVA: 0x0094938F File Offset: 0x0094758F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SpaceSwitching_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602170A RID: 136970 RVA: 0x009493A4 File Offset: 0x009475A4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void SetParamFromSequence()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SpaceSwitching_C.__SetParamFromSequence_NativeFunctionPtr, null);
		}

		// Token: 0x0602170B RID: 136971 RVA: 0x009493B8 File Offset: 0x009475B8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_SpaceSwitching(int EntryPoint)
		{
			BP_SpaceSwitching_C.__ExecuteUbergraph_BP_SpaceSwitching_FunctionParams* ptr = stackalloc BP_SpaceSwitching_C.__ExecuteUbergraph_BP_SpaceSwitching_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SpaceSwitching_C.__ExecuteUbergraph_BP_SpaceSwitching_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SpaceSwitching_C.__ExecuteUbergraph_BP_SpaceSwitching_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SpaceSwitching_C.__ExecuteUbergraph_BP_SpaceSwitching_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602170C RID: 136972 RVA: 0x009493FF File Offset: 0x009475FF
		protected BP_SpaceSwitching_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04010D4F RID: 68943
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/SpaceSwitching/BP_SpaceSwitching.BP_SpaceSwitching_C";

		// Token: 0x04010D50 RID: 68944
		private static IntPtr _ClassPtr;

		// Token: 0x04010D51 RID: 68945
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04010D52 RID: 68946
		internal static int __PropertyOffset_0;

		// Token: 0x04010D53 RID: 68947
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04010D54 RID: 68948
		internal static int __PropertyOffset_1;

		// Token: 0x04010D55 RID: 68949
		internal static int __PropertyOffset_2;

		// Token: 0x04010D56 RID: 68950
		internal static int __PropertyOffset_3;

		// Token: 0x04010D57 RID: 68951
		internal static int __PropertyOffset_4;

		// Token: 0x04010D58 RID: 68952
		internal static int __PropertyOffset_5;

		// Token: 0x04010D59 RID: 68953
		internal static int __PropertyOffset_6;

		// Token: 0x04010D5A RID: 68954
		internal static int __PropertyOffset_7;

		// Token: 0x04010D5B RID: 68955
		internal static int __PropertyOffset_8;

		// Token: 0x04010D5C RID: 68956
		internal static int __PropertyOffset_9;

		// Token: 0x04010D5D RID: 68957
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UMaterialInstanceDynamic> _DMI;

		// Token: 0x04010D5E RID: 68958
		private static IntPtr __SetParam_NativeFunctionPtr;

		// Token: 0x04010D5F RID: 68959
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04010D60 RID: 68960
		private static IntPtr __SetParamFromSequence_NativeFunctionPtr;

		// Token: 0x04010D61 RID: 68961
		private static IntPtr __ExecuteUbergraph_BP_SpaceSwitching_NativeFunctionPtr;

		// Token: 0x02009ADA RID: 39642
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __ExecuteUbergraph_BP_SpaceSwitching_FunctionParams
		{
			// Token: 0x0403225E RID: 205406
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
