using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.PageTurning
{
	// Token: 0x02003BBA RID: 15290
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/PageTurning/BP_BookPaving.BP_BookPaving_C")]
	[UnrealStructLayout(1080, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1079)]
	public class BP_BookPaving_C : AKuroBookPavingActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602241D RID: 140317 RVA: 0x0096023F File Offset: 0x0095E43F
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_BookPaving_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/PageTurning/BP_BookPaving.BP_BookPaving_C");
			}
			return BP_BookPaving_C._ClassPtr;
		}

		// Token: 0x0602241E RID: 140318 RVA: 0x00960264 File Offset: 0x0095E464
		public BP_BookPaving_C() : this(BuiltinUtils.AllocNativeUObject(BP_BookPaving_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602241F RID: 140319 RVA: 0x0096028C File Offset: 0x0095E48C
		[NullableContext(1)]
		public BP_BookPaving_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_BookPaving_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003FE8 RID: 16360
		// (get) Token: 0x06022420 RID: 140320 RVA: 0x009602C0 File Offset: 0x0095E4C0
		// (set) Token: 0x06022421 RID: 140321 RVA: 0x009602F9 File Offset: 0x0095E4F9
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_BookPaving_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_BookPaving_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17003FE9 RID: 16361
		// (get) Token: 0x06022422 RID: 140322 RVA: 0x0096031A File Offset: 0x0095E51A
		// (set) Token: 0x06022423 RID: 140323 RVA: 0x0096032E File Offset: 0x0095E52E
		[Nullable(2)]
		public unsafe USceneComponent DefaultSceneRoot
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BookPaving_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BookPaving_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17003FEA RID: 16362
		// (get) Token: 0x06022424 RID: 140324 RVA: 0x00960343 File Offset: 0x0095E543
		// (set) Token: 0x06022425 RID: 140325 RVA: 0x00960353 File Offset: 0x0095E553
		public unsafe int BookNum
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BookPaving_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BookPaving_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17003FEB RID: 16363
		// (get) Token: 0x06022426 RID: 140326 RVA: 0x00960364 File Offset: 0x0095E564
		// (set) Token: 0x06022427 RID: 140327 RVA: 0x00960374 File Offset: 0x0095E574
		public unsafe bool bReady
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BookPaving_C.__PropertyOffset_3) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BookPaving_C.__PropertyOffset_3) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003FEC RID: 16364
		// (get) Token: 0x06022428 RID: 140328 RVA: 0x00960385 File Offset: 0x0095E585
		// (set) Token: 0x06022429 RID: 140329 RVA: 0x00960395 File Offset: 0x0095E595
		public unsafe bool bInSeq
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BookPaving_C.__PropertyOffset_4) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BookPaving_C.__PropertyOffset_4) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003FED RID: 16365
		// (get) Token: 0x0602242A RID: 140330 RVA: 0x009603A6 File Offset: 0x0095E5A6
		// (set) Token: 0x0602242B RID: 140331 RVA: 0x009603B6 File Offset: 0x0095E5B6
		public unsafe bool bComplete
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BookPaving_C.__PropertyOffset_5) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BookPaving_C.__PropertyOffset_5) = (value ? 1 : 0);
			}
		}

		// Token: 0x0602242C RID: 140332 RVA: 0x009603C7 File Offset: 0x0095E5C7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void GetBookNum()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BookPaving_C.__GetBookNum_NativeFunctionPtr, null);
		}

		// Token: 0x0602242D RID: 140333 RVA: 0x009603DB File Offset: 0x0095E5DB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Collect_Books()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BookPaving_C.__Collect_Books_NativeFunctionPtr, null);
		}

		// Token: 0x0602242E RID: 140334 RVA: 0x009603EF File Offset: 0x0095E5EF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BookPaving_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0602242F RID: 140335 RVA: 0x00960403 File Offset: 0x0095E603
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_BookPaving_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06022430 RID: 140336 RVA: 0x00960418 File Offset: 0x0095E618
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_BookPaving_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_BookPaving_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_BookPaving_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BookPaving_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BookPaving_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06022431 RID: 140337 RVA: 0x00960460 File Offset: 0x0095E660
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_BookPaving_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_BookPaving_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_BookPaving_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BookPaving_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_BookPaving_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06022432 RID: 140338 RVA: 0x009604A8 File Offset: 0x0095E6A8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_BookPaving(int EntryPoint)
		{
			BP_BookPaving_C.__ExecuteUbergraph_BP_BookPaving_FunctionParams* ptr = stackalloc BP_BookPaving_C.__ExecuteUbergraph_BP_BookPaving_FunctionParams[(UIntPtr)223] + 15L / (long)sizeof(BP_BookPaving_C.__ExecuteUbergraph_BP_BookPaving_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BookPaving_C.__ExecuteUbergraph_BP_BookPaving_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_BookPaving_C.__ExecuteUbergraph_BP_BookPaving_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06022433 RID: 140339 RVA: 0x009604F2 File Offset: 0x0095E6F2
		protected BP_BookPaving_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04011523 RID: 70947
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/PageTurning/BP_BookPaving.BP_BookPaving_C";

		// Token: 0x04011524 RID: 70948
		private static IntPtr _ClassPtr;

		// Token: 0x04011525 RID: 70949
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04011526 RID: 70950
		internal static int __PropertyOffset_0;

		// Token: 0x04011527 RID: 70951
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04011528 RID: 70952
		internal static int __PropertyOffset_1;

		// Token: 0x04011529 RID: 70953
		internal static int __PropertyOffset_2;

		// Token: 0x0401152A RID: 70954
		internal static int __PropertyOffset_3;

		// Token: 0x0401152B RID: 70955
		internal static int __PropertyOffset_4;

		// Token: 0x0401152C RID: 70956
		internal static int __PropertyOffset_5;

		// Token: 0x0401152D RID: 70957
		private static IntPtr __GetBookNum_NativeFunctionPtr;

		// Token: 0x0401152E RID: 70958
		private static IntPtr __Collect_Books_NativeFunctionPtr;

		// Token: 0x0401152F RID: 70959
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04011530 RID: 70960
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04011531 RID: 70961
		private static IntPtr __ExecuteUbergraph_BP_BookPaving_NativeFunctionPtr;

		// Token: 0x02009BAF RID: 39855
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x040323E2 RID: 205794
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009BB0 RID: 39856
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 208)]
		protected ref struct __ExecuteUbergraph_BP_BookPaving_FunctionParams
		{
			// Token: 0x040323E3 RID: 205795
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
