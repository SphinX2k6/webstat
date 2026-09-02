using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.PBD_Cymbal1
{
	// Token: 0x02003BB9 RID: 15289
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/PBD_Cymbal1/BP_PBD_Cymbal.BP_PBD_Cymbal_C")]
	[UnrealStructLayout(1360, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1356)]
	public class BP_PBD_Cymbal_C : AKuroBPActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06022406 RID: 140294 RVA: 0x0095FF7F File Offset: 0x0095E17F
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_PBD_Cymbal_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/PBD_Cymbal1/BP_PBD_Cymbal.BP_PBD_Cymbal_C");
			}
			return BP_PBD_Cymbal_C._ClassPtr;
		}

		// Token: 0x06022407 RID: 140295 RVA: 0x0095FFA4 File Offset: 0x0095E1A4
		public BP_PBD_Cymbal_C() : this(BuiltinUtils.AllocNativeUObject(BP_PBD_Cymbal_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06022408 RID: 140296 RVA: 0x0095FFCC File Offset: 0x0095E1CC
		[NullableContext(1)]
		public BP_PBD_Cymbal_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_PBD_Cymbal_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003FE0 RID: 16352
		// (get) Token: 0x06022409 RID: 140297 RVA: 0x00960000 File Offset: 0x0095E200
		// (set) Token: 0x0602240A RID: 140298 RVA: 0x00960039 File Offset: 0x0095E239
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_PBD_Cymbal_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_PBD_Cymbal_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17003FE1 RID: 16353
		// (get) Token: 0x0602240B RID: 140299 RVA: 0x0096005A File Offset: 0x0095E25A
		// (set) Token: 0x0602240C RID: 140300 RVA: 0x0096006E File Offset: 0x0095E26E
		public unsafe USceneComponent Scene
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PBD_Cymbal_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PBD_Cymbal_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17003FE2 RID: 16354
		// (get) Token: 0x0602240D RID: 140301 RVA: 0x00960083 File Offset: 0x0095E283
		// (set) Token: 0x0602240E RID: 140302 RVA: 0x00960097 File Offset: 0x0095E297
		public unsafe UStaticMeshComponent Base
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PBD_Cymbal_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PBD_Cymbal_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17003FE3 RID: 16355
		// (get) Token: 0x0602240F RID: 140303 RVA: 0x009600AC File Offset: 0x0095E2AC
		// (set) Token: 0x06022410 RID: 140304 RVA: 0x009600BC File Offset: 0x0095E2BC
		public unsafe float PlayerImpulse
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PBD_Cymbal_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PBD_Cymbal_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17003FE4 RID: 16356
		// (get) Token: 0x06022411 RID: 140305 RVA: 0x009600CD File Offset: 0x0095E2CD
		// (set) Token: 0x06022412 RID: 140306 RVA: 0x009600DD File Offset: 0x0095E2DD
		public unsafe float LerpSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PBD_Cymbal_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PBD_Cymbal_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17003FE5 RID: 16357
		// (get) Token: 0x06022413 RID: 140307 RVA: 0x009600EE File Offset: 0x0095E2EE
		// (set) Token: 0x06022414 RID: 140308 RVA: 0x00960102 File Offset: 0x0095E302
		public unsafe FRotator Delta_Rotation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PBD_Cymbal_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PBD_Cymbal_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17003FE6 RID: 16358
		// (get) Token: 0x06022415 RID: 140309 RVA: 0x00960117 File Offset: 0x0095E317
		// (set) Token: 0x06022416 RID: 140310 RVA: 0x00960127 File Offset: 0x0095E327
		public unsafe float X
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PBD_Cymbal_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PBD_Cymbal_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17003FE7 RID: 16359
		// (get) Token: 0x06022417 RID: 140311 RVA: 0x00960138 File Offset: 0x0095E338
		// (set) Token: 0x06022418 RID: 140312 RVA: 0x00960148 File Offset: 0x0095E348
		public unsafe float Y
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PBD_Cymbal_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PBD_Cymbal_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x06022419 RID: 140313 RVA: 0x0096015C File Offset: 0x0095E35C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_PBD_Cymbal_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_PBD_Cymbal_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_PBD_Cymbal_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_PBD_Cymbal_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PBD_Cymbal_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602241A RID: 140314 RVA: 0x009601A4 File Offset: 0x0095E3A4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_PBD_Cymbal_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_PBD_Cymbal_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_PBD_Cymbal_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_PBD_Cymbal_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_PBD_Cymbal_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602241B RID: 140315 RVA: 0x009601EC File Offset: 0x0095E3EC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_PBD_Cymbal(int EntryPoint)
		{
			BP_PBD_Cymbal_C.__ExecuteUbergraph_BP_PBD_Cymbal_FunctionParams* ptr = stackalloc BP_PBD_Cymbal_C.__ExecuteUbergraph_BP_PBD_Cymbal_FunctionParams[(UIntPtr)687] + 15L / (long)sizeof(BP_PBD_Cymbal_C.__ExecuteUbergraph_BP_PBD_Cymbal_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_PBD_Cymbal_C.__ExecuteUbergraph_BP_PBD_Cymbal_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_PBD_Cymbal_C.__ExecuteUbergraph_BP_PBD_Cymbal_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602241C RID: 140316 RVA: 0x00960236 File Offset: 0x0095E436
		protected BP_PBD_Cymbal_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04011515 RID: 70933
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/PBD_Cymbal1/BP_PBD_Cymbal.BP_PBD_Cymbal_C";

		// Token: 0x04011516 RID: 70934
		private static IntPtr _ClassPtr;

		// Token: 0x04011517 RID: 70935
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04011518 RID: 70936
		internal static int __PropertyOffset_0;

		// Token: 0x04011519 RID: 70937
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0401151A RID: 70938
		internal static int __PropertyOffset_1;

		// Token: 0x0401151B RID: 70939
		internal static int __PropertyOffset_2;

		// Token: 0x0401151C RID: 70940
		internal static int __PropertyOffset_3;

		// Token: 0x0401151D RID: 70941
		internal static int __PropertyOffset_4;

		// Token: 0x0401151E RID: 70942
		internal static int __PropertyOffset_5;

		// Token: 0x0401151F RID: 70943
		internal static int __PropertyOffset_6;

		// Token: 0x04011520 RID: 70944
		internal static int __PropertyOffset_7;

		// Token: 0x04011521 RID: 70945
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04011522 RID: 70946
		private static IntPtr __ExecuteUbergraph_BP_PBD_Cymbal_NativeFunctionPtr;

		// Token: 0x02009BAD RID: 39853
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x040323E0 RID: 205792
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009BAE RID: 39854
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 672)]
		protected ref struct __ExecuteUbergraph_BP_PBD_Cymbal_FunctionParams
		{
			// Token: 0x040323E1 RID: 205793
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
