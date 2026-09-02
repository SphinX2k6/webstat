using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.ClothWindField
{
	// Token: 0x02003D58 RID: 15704
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/ClothWindField/BP_Cloth.BP_Cloth_C")]
	[UnrealStructLayout(1096, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1096)]
	public class BP_Cloth_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602623E RID: 156222 RVA: 0x009CF134 File Offset: 0x009CD334
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_Cloth_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/ClothWindField/BP_Cloth.BP_Cloth_C");
			}
			return BP_Cloth_C._ClassPtr;
		}

		// Token: 0x0602623F RID: 156223 RVA: 0x009CF158 File Offset: 0x009CD358
		public BP_Cloth_C() : this(BuiltinUtils.AllocNativeUObject(BP_Cloth_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06026240 RID: 156224 RVA: 0x009CF180 File Offset: 0x009CD380
		[NullableContext(1)]
		public BP_Cloth_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_Cloth_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170055A5 RID: 21925
		// (get) Token: 0x06026241 RID: 156225 RVA: 0x009CF1B4 File Offset: 0x009CD3B4
		// (set) Token: 0x06026242 RID: 156226 RVA: 0x009CF1ED File Offset: 0x009CD3ED
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_Cloth_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_Cloth_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170055A6 RID: 21926
		// (get) Token: 0x06026243 RID: 156227 RVA: 0x009CF20E File Offset: 0x009CD40E
		// (set) Token: 0x06026244 RID: 156228 RVA: 0x009CF222 File Offset: 0x009CD422
		public unsafe UKuroCSClothWindComponent KuroCSClothWind2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroCSClothWindComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Cloth_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Cloth_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170055A7 RID: 21927
		// (get) Token: 0x06026245 RID: 156229 RVA: 0x009CF237 File Offset: 0x009CD437
		// (set) Token: 0x06026246 RID: 156230 RVA: 0x009CF24B File Offset: 0x009CD44B
		public unsafe UKuroCSClothWindComponent KuroCSClothWind1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroCSClothWindComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Cloth_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Cloth_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x170055A8 RID: 21928
		// (get) Token: 0x06026247 RID: 156231 RVA: 0x009CF260 File Offset: 0x009CD460
		// (set) Token: 0x06026248 RID: 156232 RVA: 0x009CF274 File Offset: 0x009CD474
		public unsafe UKuroCSClothWindComponent KuroCSClothWind
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroCSClothWindComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Cloth_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Cloth_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x170055A9 RID: 21929
		// (get) Token: 0x06026249 RID: 156233 RVA: 0x009CF289 File Offset: 0x009CD489
		// (set) Token: 0x0602624A RID: 156234 RVA: 0x009CF29D File Offset: 0x009CD49D
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Cloth_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Cloth_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x170055AA RID: 21930
		// (get) Token: 0x0602624B RID: 156235 RVA: 0x009CF2B2 File Offset: 0x009CD4B2
		// (set) Token: 0x0602624C RID: 156236 RVA: 0x009CF2C6 File Offset: 0x009CD4C6
		public unsafe FVector Grid_Start_Position
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Cloth_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Cloth_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x170055AB RID: 21931
		// (get) Token: 0x0602624D RID: 156237 RVA: 0x009CF2DB File Offset: 0x009CD4DB
		// (set) Token: 0x0602624E RID: 156238 RVA: 0x009CF2EF File Offset: 0x009CD4EF
		public unsafe UTextureRenderTarget2D WindAtlasRT
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Cloth_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Cloth_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x0602624F RID: 156239 RVA: 0x009CF304 File Offset: 0x009CD504
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Cloth_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06026250 RID: 156240 RVA: 0x009CF318 File Offset: 0x009CD518
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Cloth_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06026251 RID: 156241 RVA: 0x009CF32D File Offset: 0x009CD52D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveDestroyed()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Cloth_C.__ReceiveDestroyed_NativeFunctionPtr, null);
		}

		// Token: 0x06026252 RID: 156242 RVA: 0x009CF341 File Offset: 0x009CD541
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveDestroyed_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Cloth_C.__ReceiveDestroyed_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06026253 RID: 156243 RVA: 0x009CF358 File Offset: 0x009CD558
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_Cloth_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_Cloth_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Cloth_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Cloth_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Cloth_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06026254 RID: 156244 RVA: 0x009CF3A0 File Offset: 0x009CD5A0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_Cloth_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_Cloth_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Cloth_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Cloth_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Cloth_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06026255 RID: 156245 RVA: 0x009CF3E7 File Offset: 0x009CD5E7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Cloth_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06026256 RID: 156246 RVA: 0x009CF3FB File Offset: 0x009CD5FB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Cloth_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06026257 RID: 156247 RVA: 0x009CF410 File Offset: 0x009CD610
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_Cloth(int EntryPoint)
		{
			BP_Cloth_C.__ExecuteUbergraph_BP_Cloth_FunctionParams* ptr = stackalloc BP_Cloth_C.__ExecuteUbergraph_BP_Cloth_FunctionParams[(UIntPtr)87] + 15L / (long)sizeof(BP_Cloth_C.__ExecuteUbergraph_BP_Cloth_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Cloth_C.__ExecuteUbergraph_BP_Cloth_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Cloth_C.__ExecuteUbergraph_BP_Cloth_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06026258 RID: 156248 RVA: 0x009CF457 File Offset: 0x009CD657
		protected BP_Cloth_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04013C1B RID: 80923
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/ClothWindField/BP_Cloth.BP_Cloth_C";

		// Token: 0x04013C1C RID: 80924
		private static IntPtr _ClassPtr;

		// Token: 0x04013C1D RID: 80925
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04013C1E RID: 80926
		internal static int __PropertyOffset_0;

		// Token: 0x04013C1F RID: 80927
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04013C20 RID: 80928
		internal static int __PropertyOffset_1;

		// Token: 0x04013C21 RID: 80929
		internal static int __PropertyOffset_2;

		// Token: 0x04013C22 RID: 80930
		internal static int __PropertyOffset_3;

		// Token: 0x04013C23 RID: 80931
		internal static int __PropertyOffset_4;

		// Token: 0x04013C24 RID: 80932
		internal static int __PropertyOffset_5;

		// Token: 0x04013C25 RID: 80933
		internal static int __PropertyOffset_6;

		// Token: 0x04013C26 RID: 80934
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04013C27 RID: 80935
		private static IntPtr __ReceiveDestroyed_NativeFunctionPtr;

		// Token: 0x04013C28 RID: 80936
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04013C29 RID: 80937
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04013C2A RID: 80938
		private static IntPtr __ExecuteUbergraph_BP_Cloth_NativeFunctionPtr;

		// Token: 0x0200A00B RID: 40971
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032BEA RID: 207850
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x0200A00C RID: 40972
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 72)]
		protected ref struct __ExecuteUbergraph_BP_Cloth_FunctionParams
		{
			// Token: 0x04032BEB RID: 207851
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
