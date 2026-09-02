using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Sequence
{
	// Token: 0x02003A5C RID: 14940
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Sequence/BP_RemoveEffectPostprocessMaterial.BP_RemoveEffectPostprocessMaterial_C")]
	[UnrealStructLayout(1056, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1052)]
	public class BP_RemoveEffectPostprocessMaterial_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601F0C8 RID: 127176 RVA: 0x0090605B File Offset: 0x0090425B
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_RemoveEffectPostprocessMaterial_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Sequence/BP_RemoveEffectPostprocessMaterial.BP_RemoveEffectPostprocessMaterial_C");
			}
			return BP_RemoveEffectPostprocessMaterial_C._ClassPtr;
		}

		// Token: 0x0601F0C9 RID: 127177 RVA: 0x00906080 File Offset: 0x00904280
		public BP_RemoveEffectPostprocessMaterial_C() : this(BuiltinUtils.AllocNativeUObject(BP_RemoveEffectPostprocessMaterial_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601F0CA RID: 127178 RVA: 0x009060A8 File Offset: 0x009042A8
		[NullableContext(1)]
		public BP_RemoveEffectPostprocessMaterial_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_RemoveEffectPostprocessMaterial_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17002DCF RID: 11727
		// (get) Token: 0x0601F0CB RID: 127179 RVA: 0x009060DC File Offset: 0x009042DC
		// (set) Token: 0x0601F0CC RID: 127180 RVA: 0x00906115 File Offset: 0x00904315
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_RemoveEffectPostprocessMaterial_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_RemoveEffectPostprocessMaterial_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17002DD0 RID: 11728
		// (get) Token: 0x0601F0CD RID: 127181 RVA: 0x00906136 File Offset: 0x00904336
		// (set) Token: 0x0601F0CE RID: 127182 RVA: 0x0090614A File Offset: 0x0090434A
		[Nullable(2)]
		public unsafe USceneComponent DefaultSceneRoot
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_RemoveEffectPostprocessMaterial_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_RemoveEffectPostprocessMaterial_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17002DD1 RID: 11729
		// (get) Token: 0x0601F0CF RID: 127183 RVA: 0x0090615F File Offset: 0x0090435F
		// (set) Token: 0x0601F0D0 RID: 127184 RVA: 0x0090616F File Offset: 0x0090436F
		public unsafe int handle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RemoveEffectPostprocessMaterial_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RemoveEffectPostprocessMaterial_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x0601F0D1 RID: 127185 RVA: 0x00906180 File Offset: 0x00904380
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_RemoveEffectPostprocessMaterial_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0601F0D2 RID: 127186 RVA: 0x00906194 File Offset: 0x00904394
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_RemoveEffectPostprocessMaterial_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601F0D3 RID: 127187 RVA: 0x009061AC File Offset: 0x009043AC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveEndPlay(EEndPlayReason EndPlayReason)
		{
			BP_RemoveEffectPostprocessMaterial_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_RemoveEffectPostprocessMaterial_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_RemoveEffectPostprocessMaterial_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_RemoveEffectPostprocessMaterial_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_RemoveEffectPostprocessMaterial_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F0D4 RID: 127188 RVA: 0x009061F8 File Offset: 0x009043F8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveEndPlay_Implementation(EEndPlayReason EndPlayReason)
		{
			BP_RemoveEffectPostprocessMaterial_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_RemoveEffectPostprocessMaterial_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_RemoveEffectPostprocessMaterial_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_RemoveEffectPostprocessMaterial_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_RemoveEffectPostprocessMaterial_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601F0D5 RID: 127189 RVA: 0x00906244 File Offset: 0x00904444
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_RemoveEffectPostprocessMaterial(int EntryPoint)
		{
			BP_RemoveEffectPostprocessMaterial_C.__ExecuteUbergraph_BP_RemoveEffectPostprocessMaterial_FunctionParams* ptr = stackalloc BP_RemoveEffectPostprocessMaterial_C.__ExecuteUbergraph_BP_RemoveEffectPostprocessMaterial_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(BP_RemoveEffectPostprocessMaterial_C.__ExecuteUbergraph_BP_RemoveEffectPostprocessMaterial_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_RemoveEffectPostprocessMaterial_C.__ExecuteUbergraph_BP_RemoveEffectPostprocessMaterial_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_RemoveEffectPostprocessMaterial_C.__ExecuteUbergraph_BP_RemoveEffectPostprocessMaterial_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601F0D6 RID: 127190 RVA: 0x0090628B File Offset: 0x0090448B
		protected BP_RemoveEffectPostprocessMaterial_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400F5D7 RID: 62935
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Sequence/BP_RemoveEffectPostprocessMaterial.BP_RemoveEffectPostprocessMaterial_C";

		// Token: 0x0400F5D8 RID: 62936
		private static IntPtr _ClassPtr;

		// Token: 0x0400F5D9 RID: 62937
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400F5DA RID: 62938
		internal static int __PropertyOffset_0;

		// Token: 0x0400F5DB RID: 62939
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400F5DC RID: 62940
		internal static int __PropertyOffset_1;

		// Token: 0x0400F5DD RID: 62941
		internal static int __PropertyOffset_2;

		// Token: 0x0400F5DE RID: 62942
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0400F5DF RID: 62943
		private static IntPtr __ReceiveEndPlay_NativeFunctionPtr;

		// Token: 0x0400F5E0 RID: 62944
		private static IntPtr __ExecuteUbergraph_BP_RemoveEffectPostprocessMaterial_NativeFunctionPtr;

		// Token: 0x0200984B RID: 38987
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __ReceiveEndPlay_FunctionParams
		{
			// Token: 0x04031E7E RID: 204414
			[FieldOffset(0)]
			public TEnumAsByte<EEndPlayReason> EndPlayReason;
		}

		// Token: 0x0200984C RID: 38988
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __ExecuteUbergraph_BP_RemoveEffectPostprocessMaterial_FunctionParams
		{
			// Token: 0x04031E7F RID: 204415
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
