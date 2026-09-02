using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Interaction
{
	// Token: 0x02003ABE RID: 15038
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Interaction/BP_InteractionMaterialController.BP_InteractionMaterialController_C")]
	[UnrealStructLayout(1120, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1120)]
	public class BP_InteractionMaterialController_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06020160 RID: 131424 RVA: 0x00921E20 File Offset: 0x00920020
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_InteractionMaterialController_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/Interaction/BP_InteractionMaterialController.BP_InteractionMaterialController_C");
			}
			return BP_InteractionMaterialController_C._ClassPtr;
		}

		// Token: 0x06020161 RID: 131425 RVA: 0x00921E44 File Offset: 0x00920044
		public BP_InteractionMaterialController_C() : this(BuiltinUtils.AllocNativeUObject(BP_InteractionMaterialController_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06020162 RID: 131426 RVA: 0x00921E6C File Offset: 0x0092006C
		public BP_InteractionMaterialController_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_InteractionMaterialController_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170033DA RID: 13274
		// (get) Token: 0x06020163 RID: 131427 RVA: 0x00921EA0 File Offset: 0x009200A0
		// (set) Token: 0x06020164 RID: 131428 RVA: 0x00921ED9 File Offset: 0x009200D9
		public FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_InteractionMaterialController_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_InteractionMaterialController_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170033DB RID: 13275
		// (get) Token: 0x06020165 RID: 131429 RVA: 0x00921EFA File Offset: 0x009200FA
		// (set) Token: 0x06020166 RID: 131430 RVA: 0x00921F0E File Offset: 0x0092010E
		[Nullable(2)]
		public unsafe USceneComponent DefaultSceneRoot
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_InteractionMaterialController_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_InteractionMaterialController_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170033DC RID: 13276
		// (get) Token: 0x06020167 RID: 131431 RVA: 0x00921F23 File Offset: 0x00920123
		// (set) Token: 0x06020168 RID: 131432 RVA: 0x00921F33 File Offset: 0x00920133
		public unsafe float Float
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_InteractionMaterialController_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_InteractionMaterialController_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x170033DD RID: 13277
		// (get) Token: 0x06020169 RID: 131433 RVA: 0x00921F44 File Offset: 0x00920144
		// (set) Token: 0x0602016A RID: 131434 RVA: 0x00921F58 File Offset: 0x00920158
		public unsafe string ScalarName
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)BP_InteractionMaterialController_C.__PropertyOffset_3)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)BP_InteractionMaterialController_C.__PropertyOffset_3)), value);
			}
		}

		// Token: 0x170033DE RID: 13278
		// (get) Token: 0x0602016B RID: 131435 RVA: 0x00921F70 File Offset: 0x00920170
		// (set) Token: 0x0602016C RID: 131436 RVA: 0x00921FA9 File Offset: 0x009201A9
		public TArray<AActor> Actor
		{
			get
			{
				base.FastCheckIsValid();
				TArray<AActor> result;
				if ((result = this._Actor) == null)
				{
					result = (this._Actor = new TArray<AActor>(base.NativePtr + (IntPtr)BP_InteractionMaterialController_C.__PropertyOffset_4, this));
				}
				return result;
			}
			set
			{
				this.Actor.CopyAssign(value);
			}
		}

		// Token: 0x170033DF RID: 13279
		// (get) Token: 0x0602016D RID: 131437 RVA: 0x00921FB7 File Offset: 0x009201B7
		// (set) Token: 0x0602016E RID: 131438 RVA: 0x00921FCB File Offset: 0x009201CB
		public unsafe string VectorName
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)BP_InteractionMaterialController_C.__PropertyOffset_5)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)BP_InteractionMaterialController_C.__PropertyOffset_5)), value);
			}
		}

		// Token: 0x170033E0 RID: 13280
		// (get) Token: 0x0602016F RID: 131439 RVA: 0x00921FE0 File Offset: 0x009201E0
		// (set) Token: 0x06020170 RID: 131440 RVA: 0x00921FF4 File Offset: 0x009201F4
		public unsafe FLinearColor Vector
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_InteractionMaterialController_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_InteractionMaterialController_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x06020171 RID: 131441 RVA: 0x0092200C File Offset: 0x0092020C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void ChangeVectorParameter(FLinearColor VectorParameter, string VectorParameterName)
		{
			BP_InteractionMaterialController_C.__ChangeVectorParameter_FunctionParams* ptr = stackalloc BP_InteractionMaterialController_C.__ChangeVectorParameter_FunctionParams[(UIntPtr)119] + 15L / (long)sizeof(BP_InteractionMaterialController_C.__ChangeVectorParameter_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InteractionMaterialController_C.__ChangeVectorParameter_NativeFunctionPtr, (void*)ptr, 1);
			ptr->VectorParameter = VectorParameter;
			FString.CopyFrom((void*)(&ptr->VectorParameterName), VectorParameterName);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InteractionMaterialController_C.__ChangeVectorParameter_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(BP_InteractionMaterialController_C.__ChangeVectorParameter_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x06020172 RID: 131442 RVA: 0x00922070 File Offset: 0x00920270
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void ChangeScalarParameter(float FloatParameter, string FloatParameterName)
		{
			BP_InteractionMaterialController_C.__ChangeScalarParameter_FunctionParams* ptr = stackalloc BP_InteractionMaterialController_C.__ChangeScalarParameter_FunctionParams[(UIntPtr)95] + 15L / (long)sizeof(BP_InteractionMaterialController_C.__ChangeScalarParameter_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InteractionMaterialController_C.__ChangeScalarParameter_NativeFunctionPtr, (void*)ptr, 1);
			ptr->FloatParameter = FloatParameter;
			FString.CopyFrom((void*)(&ptr->FloatParameterName), FloatParameterName);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InteractionMaterialController_C.__ChangeScalarParameter_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(BP_InteractionMaterialController_C.__ChangeScalarParameter_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x06020173 RID: 131443 RVA: 0x009220D4 File Offset: 0x009202D4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void ForEach()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InteractionMaterialController_C.__ForEach_NativeFunctionPtr, null);
		}

		// Token: 0x06020174 RID: 131444 RVA: 0x009220E8 File Offset: 0x009202E8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Test()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InteractionMaterialController_C.__Test_NativeFunctionPtr, null);
		}

		// Token: 0x06020175 RID: 131445 RVA: 0x009220FC File Offset: 0x009202FC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InteractionMaterialController_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06020176 RID: 131446 RVA: 0x00922110 File Offset: 0x00920310
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_InteractionMaterialController_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06020177 RID: 131447 RVA: 0x00922128 File Offset: 0x00920328
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_InteractionMaterialController(int EntryPoint)
		{
			BP_InteractionMaterialController_C.__ExecuteUbergraph_BP_InteractionMaterialController_FunctionParams* ptr = stackalloc BP_InteractionMaterialController_C.__ExecuteUbergraph_BP_InteractionMaterialController_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_InteractionMaterialController_C.__ExecuteUbergraph_BP_InteractionMaterialController_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InteractionMaterialController_C.__ExecuteUbergraph_BP_InteractionMaterialController_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_InteractionMaterialController_C.__ExecuteUbergraph_BP_InteractionMaterialController_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06020178 RID: 131448 RVA: 0x0092216F File Offset: 0x0092036F
		protected BP_InteractionMaterialController_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400FFCE RID: 65486
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Interaction/BP_InteractionMaterialController.BP_InteractionMaterialController_C";

		// Token: 0x0400FFCF RID: 65487
		private static IntPtr _ClassPtr;

		// Token: 0x0400FFD0 RID: 65488
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400FFD1 RID: 65489
		internal static int __PropertyOffset_0;

		// Token: 0x0400FFD2 RID: 65490
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400FFD3 RID: 65491
		internal static int __PropertyOffset_1;

		// Token: 0x0400FFD4 RID: 65492
		internal static int __PropertyOffset_2;

		// Token: 0x0400FFD5 RID: 65493
		internal static int __PropertyOffset_3;

		// Token: 0x0400FFD6 RID: 65494
		internal static int __PropertyOffset_4;

		// Token: 0x0400FFD7 RID: 65495
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<AActor> _Actor;

		// Token: 0x0400FFD8 RID: 65496
		internal static int __PropertyOffset_5;

		// Token: 0x0400FFD9 RID: 65497
		internal static int __PropertyOffset_6;

		// Token: 0x0400FFDA RID: 65498
		private static IntPtr __ChangeVectorParameter_NativeFunctionPtr;

		// Token: 0x0400FFDB RID: 65499
		private static IntPtr __ChangeScalarParameter_NativeFunctionPtr;

		// Token: 0x0400FFDC RID: 65500
		private static IntPtr __ForEach_NativeFunctionPtr;

		// Token: 0x0400FFDD RID: 65501
		private static IntPtr __Test_NativeFunctionPtr;

		// Token: 0x0400FFDE RID: 65502
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0400FFDF RID: 65503
		private static IntPtr __ExecuteUbergraph_BP_InteractionMaterialController_NativeFunctionPtr;

		// Token: 0x0200995E RID: 39262
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 104)]
		protected ref struct __ChangeVectorParameter_FunctionParams
		{
			// Token: 0x04031FCA RID: 204746
			[FieldOffset(0)]
			public FLinearColor VectorParameter;

			// Token: 0x04031FCB RID: 204747
			[FieldOffset(16)]
			public FString VectorParameterName;
		}

		// Token: 0x0200995F RID: 39263
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 80)]
		protected ref struct __ChangeScalarParameter_FunctionParams
		{
			// Token: 0x04031FCC RID: 204748
			[FieldOffset(0)]
			public float FloatParameter;

			// Token: 0x04031FCD RID: 204749
			[FieldOffset(8)]
			public FString FloatParameterName;
		}

		// Token: 0x02009960 RID: 39264
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __ExecuteUbergraph_BP_InteractionMaterialController_FunctionParams
		{
			// Token: 0x04031FCE RID: 204750
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
