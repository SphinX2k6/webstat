using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.TrailFields.Runtime.Drawers
{
	// Token: 0x02003A35 RID: 14901
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/TrailFields/Runtime/Drawers/BP_TrailDrawComponent_Snow.BP_TrailDrawComponent_Snow_C")]
	[UnrealStructLayout(720, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 710)]
	public class BP_TrailDrawComponent_Snow_C : BP_TrailDrawComponent_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601EB63 RID: 125795 RVA: 0x008FC62F File Offset: 0x008FA82F
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_TrailDrawComponent_Snow_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/TrailFields/Runtime/Drawers/BP_TrailDrawComponent_Snow.BP_TrailDrawComponent_Snow_C");
			}
			return BP_TrailDrawComponent_Snow_C._ClassPtr;
		}

		// Token: 0x0601EB64 RID: 125796 RVA: 0x008FC654 File Offset: 0x008FA854
		public BP_TrailDrawComponent_Snow_C() : this(BuiltinUtils.AllocNativeUObject(BP_TrailDrawComponent_Snow_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601EB65 RID: 125797 RVA: 0x008FC67C File Offset: 0x008FA87C
		[NullableContext(1)]
		public BP_TrailDrawComponent_Snow_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_TrailDrawComponent_Snow_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17002C07 RID: 11271
		// (get) Token: 0x0601EB66 RID: 125798 RVA: 0x008FC6B0 File Offset: 0x008FA8B0
		// (set) Token: 0x0601EB67 RID: 125799 RVA: 0x008FC6E9 File Offset: 0x008FA8E9
		[Nullable(1)]
		public new FPointerToUberGraphFrame UberGraphFrame
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_TrailDrawComponent_Snow_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_TrailDrawComponent_Snow_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17002C08 RID: 11272
		// (get) Token: 0x0601EB68 RID: 125800 RVA: 0x008FC70A File Offset: 0x008FA90A
		// (set) Token: 0x0601EB69 RID: 125801 RVA: 0x008FC71E File Offset: 0x008FA91E
		public unsafe UTexture SignetTexture
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture>(base.NativePtr / (IntPtr)sizeof(void*) + BP_TrailDrawComponent_Snow_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_TrailDrawComponent_Snow_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17002C09 RID: 11273
		// (get) Token: 0x0601EB6A RID: 125802 RVA: 0x008FC733 File Offset: 0x008FA933
		// (set) Token: 0x0601EB6B RID: 125803 RVA: 0x008FC747 File Offset: 0x008FA947
		public unsafe AActor father
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + BP_TrailDrawComponent_Snow_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_TrailDrawComponent_Snow_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17002C0A RID: 11274
		// (get) Token: 0x0601EB6C RID: 125804 RVA: 0x008FC75C File Offset: 0x008FA95C
		// (set) Token: 0x0601EB6D RID: 125805 RVA: 0x008FC770 File Offset: 0x008FA970
		public unsafe FVectorDouble LastLocation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TrailDrawComponent_Snow_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_TrailDrawComponent_Snow_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17002C0B RID: 11275
		// (get) Token: 0x0601EB6E RID: 125806 RVA: 0x008FC788 File Offset: 0x008FA988
		// (set) Token: 0x0601EB6F RID: 125807 RVA: 0x008FC7C1 File Offset: 0x008FA9C1
		[Nullable(new byte[]
		{
			1,
			0
		})]
		public TArray<TEnumAsByte<EObjectTypeQuery>> Object_Types
		{
			[return: Nullable(new byte[]
			{
				1,
				0
			})]
			get
			{
				base.FastCheckIsValid();
				TArray<TEnumAsByte<EObjectTypeQuery>> result;
				if ((result = this._Object_Types) == null)
				{
					result = (this._Object_Types = new TArray<TEnumAsByte<EObjectTypeQuery>>(base.NativePtr + (IntPtr)BP_TrailDrawComponent_Snow_C.__PropertyOffset_4, this));
				}
				return result;
			}
			[param: Nullable(new byte[]
			{
				1,
				0
			})]
			set
			{
				this.Object_Types.CopyAssign(value);
			}
		}

		// Token: 0x17002C0C RID: 11276
		// (get) Token: 0x0601EB70 RID: 125808 RVA: 0x008FC7CF File Offset: 0x008FA9CF
		// (set) Token: 0x0601EB71 RID: 125809 RVA: 0x008FC7DF File Offset: 0x008FA9DF
		public unsafe float SnowfieldThickness
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TrailDrawComponent_Snow_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_TrailDrawComponent_Snow_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17002C0D RID: 11277
		// (get) Token: 0x0601EB72 RID: 125810 RVA: 0x008FC7F0 File Offset: 0x008FA9F0
		// (set) Token: 0x0601EB73 RID: 125811 RVA: 0x008FC800 File Offset: 0x008FAA00
		public unsafe bool UseBounds
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TrailDrawComponent_Snow_C.__PropertyOffset_6) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_TrailDrawComponent_Snow_C.__PropertyOffset_6) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002C0E RID: 11278
		// (get) Token: 0x0601EB74 RID: 125812 RVA: 0x008FC811 File Offset: 0x008FAA11
		// (set) Token: 0x0601EB75 RID: 125813 RVA: 0x008FC821 File Offset: 0x008FAA21
		public unsafe bool IsEnable
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TrailDrawComponent_Snow_C.__PropertyOffset_7) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_TrailDrawComponent_Snow_C.__PropertyOffset_7) = (value ? 1 : 0);
			}
		}

		// Token: 0x0601EB76 RID: 125814 RVA: 0x008FC832 File Offset: 0x008FAA32
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Update()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_TrailDrawComponent_Snow_C.__Update_NativeFunctionPtr, null);
		}

		// Token: 0x0601EB77 RID: 125815 RVA: 0x008FC846 File Offset: 0x008FAA46
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Init()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_TrailDrawComponent_Snow_C.__Init_NativeFunctionPtr, null);
		}

		// Token: 0x0601EB78 RID: 125816 RVA: 0x008FC85A File Offset: 0x008FAA5A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_TrailDrawComponent_Snow_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0601EB79 RID: 125817 RVA: 0x008FC86E File Offset: 0x008FAA6E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_TrailDrawComponent_Snow_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601EB7A RID: 125818 RVA: 0x008FC884 File Offset: 0x008FAA84
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_TrailDrawComponent_Snow_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_TrailDrawComponent_Snow_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_TrailDrawComponent_Snow_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_TrailDrawComponent_Snow_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_TrailDrawComponent_Snow_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601EB7B RID: 125819 RVA: 0x008FC8CC File Offset: 0x008FAACC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_TrailDrawComponent_Snow_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_TrailDrawComponent_Snow_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_TrailDrawComponent_Snow_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_TrailDrawComponent_Snow_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_TrailDrawComponent_Snow_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601EB7C RID: 125820 RVA: 0x008FC914 File Offset: 0x008FAB14
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_TrailDrawComponent_Snow(int EntryPoint)
		{
			BP_TrailDrawComponent_Snow_C.__ExecuteUbergraph_BP_TrailDrawComponent_Snow_FunctionParams* ptr = stackalloc BP_TrailDrawComponent_Snow_C.__ExecuteUbergraph_BP_TrailDrawComponent_Snow_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_TrailDrawComponent_Snow_C.__ExecuteUbergraph_BP_TrailDrawComponent_Snow_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_TrailDrawComponent_Snow_C.__ExecuteUbergraph_BP_TrailDrawComponent_Snow_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_TrailDrawComponent_Snow_C.__ExecuteUbergraph_BP_TrailDrawComponent_Snow_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601EB7D RID: 125821 RVA: 0x008FC95B File Offset: 0x008FAB5B
		protected BP_TrailDrawComponent_Snow_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400F279 RID: 62073
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/TrailFields/Runtime/Drawers/BP_TrailDrawComponent_Snow.BP_TrailDrawComponent_Snow_C";

		// Token: 0x0400F27A RID: 62074
		private static IntPtr _ClassPtr;

		// Token: 0x0400F27B RID: 62075
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400F27C RID: 62076
		internal new static int __PropertyOffset_0;

		// Token: 0x0400F27D RID: 62077
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400F27E RID: 62078
		internal new static int __PropertyOffset_1;

		// Token: 0x0400F27F RID: 62079
		internal new static int __PropertyOffset_2;

		// Token: 0x0400F280 RID: 62080
		internal new static int __PropertyOffset_3;

		// Token: 0x0400F281 RID: 62081
		internal new static int __PropertyOffset_4;

		// Token: 0x0400F282 RID: 62082
		[Nullable(new byte[]
		{
			2,
			0
		})]
		private TArray<TEnumAsByte<EObjectTypeQuery>> _Object_Types;

		// Token: 0x0400F283 RID: 62083
		internal new static int __PropertyOffset_5;

		// Token: 0x0400F284 RID: 62084
		internal new static int __PropertyOffset_6;

		// Token: 0x0400F285 RID: 62085
		internal static int __PropertyOffset_7;

		// Token: 0x0400F286 RID: 62086
		private static IntPtr __Update_NativeFunctionPtr;

		// Token: 0x0400F287 RID: 62087
		private static IntPtr __Init_NativeFunctionPtr;

		// Token: 0x0400F288 RID: 62088
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0400F289 RID: 62089
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0400F28A RID: 62090
		private static IntPtr __ExecuteUbergraph_BP_TrailDrawComponent_Snow_NativeFunctionPtr;

		// Token: 0x020097F0 RID: 38896
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04031DE4 RID: 204260
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x020097F1 RID: 38897
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __ExecuteUbergraph_BP_TrailDrawComponent_Snow_FunctionParams
		{
			// Token: 0x04031DE5 RID: 204261
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
