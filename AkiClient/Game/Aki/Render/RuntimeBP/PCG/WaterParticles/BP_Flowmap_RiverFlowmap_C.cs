using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.WaterParticles
{
	// Token: 0x02003B56 RID: 15190
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/WaterParticles/BP_Flowmap_RiverFlowmap.BP_Flowmap_RiverFlowmap_C")]
	[UnrealStructLayout(1408, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1400)]
	public class BP_Flowmap_RiverFlowmap_C : AKuroBPActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06021248 RID: 135752 RVA: 0x00940F7F File Offset: 0x0093F17F
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_Flowmap_RiverFlowmap_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/WaterParticles/BP_Flowmap_RiverFlowmap.BP_Flowmap_RiverFlowmap_C");
			}
			return BP_Flowmap_RiverFlowmap_C._ClassPtr;
		}

		// Token: 0x06021249 RID: 135753 RVA: 0x00940FA4 File Offset: 0x0093F1A4
		public BP_Flowmap_RiverFlowmap_C() : this(BuiltinUtils.AllocNativeUObject(BP_Flowmap_RiverFlowmap_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602124A RID: 135754 RVA: 0x00940FCC File Offset: 0x0093F1CC
		[NullableContext(1)]
		public BP_Flowmap_RiverFlowmap_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_Flowmap_RiverFlowmap_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003965 RID: 14693
		// (get) Token: 0x0602124B RID: 135755 RVA: 0x00941000 File Offset: 0x0093F200
		// (set) Token: 0x0602124C RID: 135756 RVA: 0x00941039 File Offset: 0x0093F239
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_Flowmap_RiverFlowmap_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_Flowmap_RiverFlowmap_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17003966 RID: 14694
		// (get) Token: 0x0602124D RID: 135757 RVA: 0x0094105A File Offset: 0x0093F25A
		// (set) Token: 0x0602124E RID: 135758 RVA: 0x0094106E File Offset: 0x0093F26E
		public unsafe UNiagaraComponent NS_WaterParticles_RiverFlowmap
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Flowmap_RiverFlowmap_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Flowmap_RiverFlowmap_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17003967 RID: 14695
		// (get) Token: 0x0602124F RID: 135759 RVA: 0x00941083 File Offset: 0x0093F283
		// (set) Token: 0x06021250 RID: 135760 RVA: 0x00941097 File Offset: 0x0093F297
		public unsafe FVector BoxSize
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Flowmap_RiverFlowmap_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Flowmap_RiverFlowmap_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17003968 RID: 14696
		// (get) Token: 0x06021251 RID: 135761 RVA: 0x009410AC File Offset: 0x0093F2AC
		// (set) Token: 0x06021252 RID: 135762 RVA: 0x009410BC File Offset: 0x0093F2BC
		public unsafe float FlowVelocity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Flowmap_RiverFlowmap_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Flowmap_RiverFlowmap_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17003969 RID: 14697
		// (get) Token: 0x06021253 RID: 135763 RVA: 0x009410CD File Offset: 0x0093F2CD
		// (set) Token: 0x06021254 RID: 135764 RVA: 0x009410E1 File Offset: 0x0093F2E1
		public unsafe UTexture T_Ground
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Flowmap_RiverFlowmap_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Flowmap_RiverFlowmap_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x1700396A RID: 14698
		// (get) Token: 0x06021255 RID: 135765 RVA: 0x009410F6 File Offset: 0x0093F2F6
		// (set) Token: 0x06021256 RID: 135766 RVA: 0x0094110A File Offset: 0x0093F30A
		public unsafe UTexture T_VelocityDepthFoam
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Flowmap_RiverFlowmap_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Flowmap_RiverFlowmap_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x1700396B RID: 14699
		// (get) Token: 0x06021257 RID: 135767 RVA: 0x0094111F File Offset: 0x0093F31F
		// (set) Token: 0x06021258 RID: 135768 RVA: 0x00941133 File Offset: 0x0093F333
		public unsafe FVector4 RG_Particle_Range
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Flowmap_RiverFlowmap_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Flowmap_RiverFlowmap_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x1700396C RID: 14700
		// (get) Token: 0x06021259 RID: 135769 RVA: 0x00941148 File Offset: 0x0093F348
		// (set) Token: 0x0602125A RID: 135770 RVA: 0x0094115C File Offset: 0x0093F35C
		public unsafe FVector2D RandomSize
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Flowmap_RiverFlowmap_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Flowmap_RiverFlowmap_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x1700396D RID: 14701
		// (get) Token: 0x0602125B RID: 135771 RVA: 0x00941171 File Offset: 0x0093F371
		// (set) Token: 0x0602125C RID: 135772 RVA: 0x00941181 File Offset: 0x0093F381
		public unsafe int SpawnCount
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Flowmap_RiverFlowmap_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Flowmap_RiverFlowmap_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x1700396E RID: 14702
		// (get) Token: 0x0602125D RID: 135773 RVA: 0x00941192 File Offset: 0x0093F392
		// (set) Token: 0x0602125E RID: 135774 RVA: 0x009411A6 File Offset: 0x0093F3A6
		public unsafe UTexture T_Mask
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Flowmap_RiverFlowmap_C.__PropertyOffset_9);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Flowmap_RiverFlowmap_C.__PropertyOffset_9, value);
			}
		}

		// Token: 0x0602125F RID: 135775 RVA: 0x009411BB File Offset: 0x0093F3BB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void SetParameter()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Flowmap_RiverFlowmap_C.__SetParameter_NativeFunctionPtr, null);
		}

		// Token: 0x06021260 RID: 135776 RVA: 0x009411CF File Offset: 0x0093F3CF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Flowmap_RiverFlowmap_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06021261 RID: 135777 RVA: 0x009411E3 File Offset: 0x0093F3E3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Flowmap_RiverFlowmap_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06021262 RID: 135778 RVA: 0x009411F8 File Offset: 0x0093F3F8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Flowmap_RiverFlowmap_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06021263 RID: 135779 RVA: 0x0094120C File Offset: 0x0093F40C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Flowmap_RiverFlowmap_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06021264 RID: 135780 RVA: 0x00941224 File Offset: 0x0093F424
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_Flowmap_RiverFlowmap(int EntryPoint)
		{
			BP_Flowmap_RiverFlowmap_C.__ExecuteUbergraph_BP_Flowmap_RiverFlowmap_FunctionParams* ptr = stackalloc BP_Flowmap_RiverFlowmap_C.__ExecuteUbergraph_BP_Flowmap_RiverFlowmap_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Flowmap_RiverFlowmap_C.__ExecuteUbergraph_BP_Flowmap_RiverFlowmap_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Flowmap_RiverFlowmap_C.__ExecuteUbergraph_BP_Flowmap_RiverFlowmap_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Flowmap_RiverFlowmap_C.__ExecuteUbergraph_BP_Flowmap_RiverFlowmap_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06021265 RID: 135781 RVA: 0x0094126B File Offset: 0x0093F46B
		protected BP_Flowmap_RiverFlowmap_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04010A6E RID: 68206
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/WaterParticles/BP_Flowmap_RiverFlowmap.BP_Flowmap_RiverFlowmap_C";

		// Token: 0x04010A6F RID: 68207
		private static IntPtr _ClassPtr;

		// Token: 0x04010A70 RID: 68208
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04010A71 RID: 68209
		internal static int __PropertyOffset_0;

		// Token: 0x04010A72 RID: 68210
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04010A73 RID: 68211
		internal static int __PropertyOffset_1;

		// Token: 0x04010A74 RID: 68212
		internal static int __PropertyOffset_2;

		// Token: 0x04010A75 RID: 68213
		internal static int __PropertyOffset_3;

		// Token: 0x04010A76 RID: 68214
		internal static int __PropertyOffset_4;

		// Token: 0x04010A77 RID: 68215
		internal static int __PropertyOffset_5;

		// Token: 0x04010A78 RID: 68216
		internal static int __PropertyOffset_6;

		// Token: 0x04010A79 RID: 68217
		internal static int __PropertyOffset_7;

		// Token: 0x04010A7A RID: 68218
		internal static int __PropertyOffset_8;

		// Token: 0x04010A7B RID: 68219
		internal static int __PropertyOffset_9;

		// Token: 0x04010A7C RID: 68220
		private static IntPtr __SetParameter_NativeFunctionPtr;

		// Token: 0x04010A7D RID: 68221
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04010A7E RID: 68222
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04010A7F RID: 68223
		private static IntPtr __ExecuteUbergraph_BP_Flowmap_RiverFlowmap_NativeFunctionPtr;

		// Token: 0x02009A84 RID: 39556
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __ExecuteUbergraph_BP_Flowmap_RiverFlowmap_FunctionParams
		{
			// Token: 0x040321D8 RID: 205272
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
