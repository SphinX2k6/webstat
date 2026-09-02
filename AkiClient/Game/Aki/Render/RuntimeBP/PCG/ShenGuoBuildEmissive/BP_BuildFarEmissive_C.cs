using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.ShenGuoBuildEmissive
{
	// Token: 0x02003B79 RID: 15225
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/ShenGuoBuildEmissive/BP_BuildFarEmissive.BP_BuildFarEmissive_C")]
	[UnrealStructLayout(1416, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1416)]
	public class BP_BuildFarEmissive_C : AKuroEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060218C6 RID: 137414 RVA: 0x0094C639 File Offset: 0x0094A839
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_BuildFarEmissive_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/ShenGuoBuildEmissive/BP_BuildFarEmissive.BP_BuildFarEmissive_C");
			}
			return BP_BuildFarEmissive_C._ClassPtr;
		}

		// Token: 0x060218C7 RID: 137415 RVA: 0x0094C660 File Offset: 0x0094A860
		public BP_BuildFarEmissive_C() : this(BuiltinUtils.AllocNativeUObject(BP_BuildFarEmissive_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060218C8 RID: 137416 RVA: 0x0094C688 File Offset: 0x0094A888
		[NullableContext(1)]
		public BP_BuildFarEmissive_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_BuildFarEmissive_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003BB5 RID: 15285
		// (get) Token: 0x060218C9 RID: 137417 RVA: 0x0094C6BC File Offset: 0x0094A8BC
		// (set) Token: 0x060218CA RID: 137418 RVA: 0x0094C6F5 File Offset: 0x0094A8F5
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_BuildFarEmissive_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_BuildFarEmissive_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17003BB6 RID: 15286
		// (get) Token: 0x060218CB RID: 137419 RVA: 0x0094C716 File Offset: 0x0094A916
		// (set) Token: 0x060218CC RID: 137420 RVA: 0x0094C72A File Offset: 0x0094A92A
		public unsafe UStaticMeshComponent Sphere
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BuildFarEmissive_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BuildFarEmissive_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17003BB7 RID: 15287
		// (get) Token: 0x060218CD RID: 137421 RVA: 0x0094C73F File Offset: 0x0094A93F
		// (set) Token: 0x060218CE RID: 137422 RVA: 0x0094C753 File Offset: 0x0094A953
		public unsafe UStaticMeshComponent SM_LifePlaySphere
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BuildFarEmissive_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BuildFarEmissive_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17003BB8 RID: 15288
		// (get) Token: 0x060218CF RID: 137423 RVA: 0x0094C768 File Offset: 0x0094A968
		// (set) Token: 0x060218D0 RID: 137424 RVA: 0x0094C77C File Offset: 0x0094A97C
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BuildFarEmissive_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BuildFarEmissive_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17003BB9 RID: 15289
		// (get) Token: 0x060218D1 RID: 137425 RVA: 0x0094C791 File Offset: 0x0094A991
		// (set) Token: 0x060218D2 RID: 137426 RVA: 0x0094C7A1 File Offset: 0x0094A9A1
		public unsafe bool DebugFadeDistance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BuildFarEmissive_C.__PropertyOffset_4) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BuildFarEmissive_C.__PropertyOffset_4) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003BBA RID: 15290
		// (get) Token: 0x060218D3 RID: 137427 RVA: 0x0094C7B2 File Offset: 0x0094A9B2
		// (set) Token: 0x060218D4 RID: 137428 RVA: 0x0094C7C2 File Offset: 0x0094A9C2
		public unsafe float Sphere_Scale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BuildFarEmissive_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BuildFarEmissive_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17003BBB RID: 15291
		// (get) Token: 0x060218D5 RID: 137429 RVA: 0x0094C7D3 File Offset: 0x0094A9D3
		// (set) Token: 0x060218D6 RID: 137430 RVA: 0x0094C7E7 File Offset: 0x0094A9E7
		public unsafe FVectorDouble Sphere_WorldPosition
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BuildFarEmissive_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BuildFarEmissive_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17003BBC RID: 15292
		// (get) Token: 0x060218D7 RID: 137431 RVA: 0x0094C7FC File Offset: 0x0094A9FC
		// (set) Token: 0x060218D8 RID: 137432 RVA: 0x0094C810 File Offset: 0x0094AA10
		public unsafe UMaterialInstance Material
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BuildFarEmissive_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BuildFarEmissive_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x17003BBD RID: 15293
		// (get) Token: 0x060218D9 RID: 137433 RVA: 0x0094C825 File Offset: 0x0094AA25
		// (set) Token: 0x060218DA RID: 137434 RVA: 0x0094C835 File Offset: 0x0094AA35
		public unsafe float FadeStartDistance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BuildFarEmissive_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BuildFarEmissive_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17003BBE RID: 15294
		// (get) Token: 0x060218DB RID: 137435 RVA: 0x0094C846 File Offset: 0x0094AA46
		// (set) Token: 0x060218DC RID: 137436 RVA: 0x0094C856 File Offset: 0x0094AA56
		public unsafe float FadeAttenuationDistance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BuildFarEmissive_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BuildFarEmissive_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17003BBF RID: 15295
		// (get) Token: 0x060218DD RID: 137437 RVA: 0x0094C867 File Offset: 0x0094AA67
		// (set) Token: 0x060218DE RID: 137438 RVA: 0x0094C87B File Offset: 0x0094AA7B
		public unsafe UMaterialInstance DebugMaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BuildFarEmissive_C.__PropertyOffset_10);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BuildFarEmissive_C.__PropertyOffset_10, value);
			}
		}

		// Token: 0x17003BC0 RID: 15296
		// (get) Token: 0x060218DF RID: 137439 RVA: 0x0094C890 File Offset: 0x0094AA90
		// (set) Token: 0x060218E0 RID: 137440 RVA: 0x0094C8A4 File Offset: 0x0094AAA4
		public unsafe UMaterialInstanceDynamic Material_DMI
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BuildFarEmissive_C.__PropertyOffset_11);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BuildFarEmissive_C.__PropertyOffset_11, value);
			}
		}

		// Token: 0x17003BC1 RID: 15297
		// (get) Token: 0x060218E1 RID: 137441 RVA: 0x0094C8B9 File Offset: 0x0094AAB9
		// (set) Token: 0x060218E2 RID: 137442 RVA: 0x0094C8CD File Offset: 0x0094AACD
		public unsafe UMaterialInstanceDynamic DebugMaterial_DMI
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BuildFarEmissive_C.__PropertyOffset_12);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BuildFarEmissive_C.__PropertyOffset_12, value);
			}
		}

		// Token: 0x060218E3 RID: 137443 RVA: 0x0094C8E2 File Offset: 0x0094AAE2
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void set_Parameter()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BuildFarEmissive_C.__set_Parameter_NativeFunctionPtr, null);
		}

		// Token: 0x060218E4 RID: 137444 RVA: 0x0094C8F6 File Offset: 0x0094AAF6
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Fade_Distance_Debug()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BuildFarEmissive_C.__Fade_Distance_Debug_NativeFunctionPtr, null);
		}

		// Token: 0x060218E5 RID: 137445 RVA: 0x0094C90A File Offset: 0x0094AB0A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BuildFarEmissive_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x060218E6 RID: 137446 RVA: 0x0094C91E File Offset: 0x0094AB1E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_BuildFarEmissive_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060218E7 RID: 137447 RVA: 0x0094C933 File Offset: 0x0094AB33
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BuildFarEmissive_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x060218E8 RID: 137448 RVA: 0x0094C947 File Offset: 0x0094AB47
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_BuildFarEmissive_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060218E9 RID: 137449 RVA: 0x0094C95C File Offset: 0x0094AB5C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_BuildFarEmissive(int EntryPoint)
		{
			BP_BuildFarEmissive_C.__ExecuteUbergraph_BP_BuildFarEmissive_FunctionParams* ptr = stackalloc BP_BuildFarEmissive_C.__ExecuteUbergraph_BP_BuildFarEmissive_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_BuildFarEmissive_C.__ExecuteUbergraph_BP_BuildFarEmissive_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BuildFarEmissive_C.__ExecuteUbergraph_BP_BuildFarEmissive_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_BuildFarEmissive_C.__ExecuteUbergraph_BP_BuildFarEmissive_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060218EA RID: 137450 RVA: 0x0094C9A3 File Offset: 0x0094ABA3
		protected BP_BuildFarEmissive_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04010E6D RID: 69229
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/ShenGuoBuildEmissive/BP_BuildFarEmissive.BP_BuildFarEmissive_C";

		// Token: 0x04010E6E RID: 69230
		private static IntPtr _ClassPtr;

		// Token: 0x04010E6F RID: 69231
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04010E70 RID: 69232
		internal static int __PropertyOffset_0;

		// Token: 0x04010E71 RID: 69233
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04010E72 RID: 69234
		internal static int __PropertyOffset_1;

		// Token: 0x04010E73 RID: 69235
		internal static int __PropertyOffset_2;

		// Token: 0x04010E74 RID: 69236
		internal static int __PropertyOffset_3;

		// Token: 0x04010E75 RID: 69237
		internal static int __PropertyOffset_4;

		// Token: 0x04010E76 RID: 69238
		internal static int __PropertyOffset_5;

		// Token: 0x04010E77 RID: 69239
		internal static int __PropertyOffset_6;

		// Token: 0x04010E78 RID: 69240
		internal static int __PropertyOffset_7;

		// Token: 0x04010E79 RID: 69241
		internal static int __PropertyOffset_8;

		// Token: 0x04010E7A RID: 69242
		internal static int __PropertyOffset_9;

		// Token: 0x04010E7B RID: 69243
		internal static int __PropertyOffset_10;

		// Token: 0x04010E7C RID: 69244
		internal static int __PropertyOffset_11;

		// Token: 0x04010E7D RID: 69245
		internal static int __PropertyOffset_12;

		// Token: 0x04010E7E RID: 69246
		private static IntPtr __set_Parameter_NativeFunctionPtr;

		// Token: 0x04010E7F RID: 69247
		private static IntPtr __Fade_Distance_Debug_NativeFunctionPtr;

		// Token: 0x04010E80 RID: 69248
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04010E81 RID: 69249
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04010E82 RID: 69250
		private static IntPtr __ExecuteUbergraph_BP_BuildFarEmissive_NativeFunctionPtr;

		// Token: 0x02009AF7 RID: 39671
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __ExecuteUbergraph_BP_BuildFarEmissive_FunctionParams
		{
			// Token: 0x04032297 RID: 205463
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
