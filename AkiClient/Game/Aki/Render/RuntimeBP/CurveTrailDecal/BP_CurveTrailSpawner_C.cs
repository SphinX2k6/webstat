using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.CurveTrailDecal
{
	// Token: 0x02003D56 RID: 15702
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/CurveTrailDecal/BP_CurveTrailSpawner.BP_CurveTrailSpawner_C")]
	[UnrealStructLayout(1080, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1073)]
	public class BP_CurveTrailSpawner_C : AKuroCurveTrailDecalSpawner, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602622D RID: 156205 RVA: 0x009CEEA8 File Offset: 0x009CD0A8
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_CurveTrailSpawner_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/CurveTrailDecal/BP_CurveTrailSpawner.BP_CurveTrailSpawner_C");
			}
			return BP_CurveTrailSpawner_C._ClassPtr;
		}

		// Token: 0x0602622E RID: 156206 RVA: 0x009CEECC File Offset: 0x009CD0CC
		public BP_CurveTrailSpawner_C() : this(BuiltinUtils.AllocNativeUObject(BP_CurveTrailSpawner_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602622F RID: 156207 RVA: 0x009CEEF4 File Offset: 0x009CD0F4
		[NullableContext(1)]
		public BP_CurveTrailSpawner_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_CurveTrailSpawner_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170055A2 RID: 21922
		// (get) Token: 0x06026230 RID: 156208 RVA: 0x009CEF28 File Offset: 0x009CD128
		// (set) Token: 0x06026231 RID: 156209 RVA: 0x009CEF61 File Offset: 0x009CD161
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_CurveTrailSpawner_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_CurveTrailSpawner_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170055A3 RID: 21923
		// (get) Token: 0x06026232 RID: 156210 RVA: 0x009CEF82 File Offset: 0x009CD182
		// (set) Token: 0x06026233 RID: 156211 RVA: 0x009CEF96 File Offset: 0x009CD196
		[Nullable(2)]
		public unsafe UBillboardComponent Billboard
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBillboardComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CurveTrailSpawner_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CurveTrailSpawner_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170055A4 RID: 21924
		// (get) Token: 0x06026234 RID: 156212 RVA: 0x009CEFAB File Offset: 0x009CD1AB
		// (set) Token: 0x06026235 RID: 156213 RVA: 0x009CEFBB File Offset: 0x009CD1BB
		public unsafe bool Position
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CurveTrailSpawner_C.__PropertyOffset_2) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CurveTrailSpawner_C.__PropertyOffset_2) = (value ? 1 : 0);
			}
		}

		// Token: 0x06026236 RID: 156214 RVA: 0x009CEFCC File Offset: 0x009CD1CC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_CurveTrailSpawner_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_CurveTrailSpawner_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_CurveTrailSpawner_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CurveTrailSpawner_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CurveTrailSpawner_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06026237 RID: 156215 RVA: 0x009CF014 File Offset: 0x009CD214
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_CurveTrailSpawner_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_CurveTrailSpawner_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_CurveTrailSpawner_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CurveTrailSpawner_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_CurveTrailSpawner_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06026238 RID: 156216 RVA: 0x009CF05C File Offset: 0x009CD25C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_CurveTrailSpawner(int EntryPoint)
		{
			BP_CurveTrailSpawner_C.__ExecuteUbergraph_BP_CurveTrailSpawner_FunctionParams* ptr = stackalloc BP_CurveTrailSpawner_C.__ExecuteUbergraph_BP_CurveTrailSpawner_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_CurveTrailSpawner_C.__ExecuteUbergraph_BP_CurveTrailSpawner_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CurveTrailSpawner_C.__ExecuteUbergraph_BP_CurveTrailSpawner_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_CurveTrailSpawner_C.__ExecuteUbergraph_BP_CurveTrailSpawner_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06026239 RID: 156217 RVA: 0x009CF0A3 File Offset: 0x009CD2A3
		protected BP_CurveTrailSpawner_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04013C0F RID: 80911
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/CurveTrailDecal/BP_CurveTrailSpawner.BP_CurveTrailSpawner_C";

		// Token: 0x04013C10 RID: 80912
		private static IntPtr _ClassPtr;

		// Token: 0x04013C11 RID: 80913
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04013C12 RID: 80914
		internal static int __PropertyOffset_0;

		// Token: 0x04013C13 RID: 80915
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04013C14 RID: 80916
		internal static int __PropertyOffset_1;

		// Token: 0x04013C15 RID: 80917
		internal static int __PropertyOffset_2;

		// Token: 0x04013C16 RID: 80918
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04013C17 RID: 80919
		private static IntPtr __ExecuteUbergraph_BP_CurveTrailSpawner_NativeFunctionPtr;

		// Token: 0x0200A009 RID: 40969
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032BE8 RID: 207848
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x0200A00A RID: 40970
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __ExecuteUbergraph_BP_CurveTrailSpawner_FunctionParams
		{
			// Token: 0x04032BE9 RID: 207849
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
