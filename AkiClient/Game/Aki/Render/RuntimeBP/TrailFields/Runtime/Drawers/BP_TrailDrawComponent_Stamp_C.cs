using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.TrailFields.Runtime.Drawers
{
	// Token: 0x02003A36 RID: 14902
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/TrailFields/Runtime/Drawers/BP_TrailDrawComponent_Stamp.BP_TrailDrawComponent_Stamp_C")]
	[UnrealStructLayout(720, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 709)]
	public class BP_TrailDrawComponent_Stamp_C : BP_TrailDrawComponent_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601EB7E RID: 125822 RVA: 0x008FC964 File Offset: 0x008FAB64
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_TrailDrawComponent_Stamp_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/TrailFields/Runtime/Drawers/BP_TrailDrawComponent_Stamp.BP_TrailDrawComponent_Stamp_C");
			}
			return BP_TrailDrawComponent_Stamp_C._ClassPtr;
		}

		// Token: 0x0601EB7F RID: 125823 RVA: 0x008FC988 File Offset: 0x008FAB88
		public BP_TrailDrawComponent_Stamp_C() : this(BuiltinUtils.AllocNativeUObject(BP_TrailDrawComponent_Stamp_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601EB80 RID: 125824 RVA: 0x008FC9B0 File Offset: 0x008FABB0
		[NullableContext(1)]
		public BP_TrailDrawComponent_Stamp_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_TrailDrawComponent_Stamp_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17002C0F RID: 11279
		// (get) Token: 0x0601EB81 RID: 125825 RVA: 0x008FC9E4 File Offset: 0x008FABE4
		// (set) Token: 0x0601EB82 RID: 125826 RVA: 0x008FCA1D File Offset: 0x008FAC1D
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_TrailDrawComponent_Stamp_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_TrailDrawComponent_Stamp_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17002C10 RID: 11280
		// (get) Token: 0x0601EB83 RID: 125827 RVA: 0x008FCA3E File Offset: 0x008FAC3E
		// (set) Token: 0x0601EB84 RID: 125828 RVA: 0x008FCA52 File Offset: 0x008FAC52
		public unsafe UTexture SignetTexture
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture>(base.NativePtr / (IntPtr)sizeof(void*) + BP_TrailDrawComponent_Stamp_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_TrailDrawComponent_Stamp_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17002C11 RID: 11281
		// (get) Token: 0x0601EB85 RID: 125829 RVA: 0x008FCA67 File Offset: 0x008FAC67
		// (set) Token: 0x0601EB86 RID: 125830 RVA: 0x008FCA7B File Offset: 0x008FAC7B
		public unsafe AActor father
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + BP_TrailDrawComponent_Stamp_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_TrailDrawComponent_Stamp_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17002C12 RID: 11282
		// (get) Token: 0x0601EB87 RID: 125831 RVA: 0x008FCA90 File Offset: 0x008FAC90
		// (set) Token: 0x0601EB88 RID: 125832 RVA: 0x008FCAA4 File Offset: 0x008FACA4
		public unsafe FVectorDouble LastLocation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TrailDrawComponent_Stamp_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_TrailDrawComponent_Stamp_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17002C13 RID: 11283
		// (get) Token: 0x0601EB89 RID: 125833 RVA: 0x008FCABC File Offset: 0x008FACBC
		// (set) Token: 0x0601EB8A RID: 125834 RVA: 0x008FCAF5 File Offset: 0x008FACF5
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
					result = (this._Object_Types = new TArray<TEnumAsByte<EObjectTypeQuery>>(base.NativePtr + (IntPtr)BP_TrailDrawComponent_Stamp_C.__PropertyOffset_4, this));
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

		// Token: 0x17002C14 RID: 11284
		// (get) Token: 0x0601EB8B RID: 125835 RVA: 0x008FCB03 File Offset: 0x008FAD03
		// (set) Token: 0x0601EB8C RID: 125836 RVA: 0x008FCB13 File Offset: 0x008FAD13
		public unsafe float SnowfieldThickness
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TrailDrawComponent_Stamp_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_TrailDrawComponent_Stamp_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17002C15 RID: 11285
		// (get) Token: 0x0601EB8D RID: 125837 RVA: 0x008FCB24 File Offset: 0x008FAD24
		// (set) Token: 0x0601EB8E RID: 125838 RVA: 0x008FCB34 File Offset: 0x008FAD34
		public unsafe bool UseBounds
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TrailDrawComponent_Stamp_C.__PropertyOffset_6) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_TrailDrawComponent_Stamp_C.__PropertyOffset_6) = (value ? 1 : 0);
			}
		}

		// Token: 0x0601EB8F RID: 125839 RVA: 0x008FCB48 File Offset: 0x008FAD48
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_TrailDrawComponent_Stamp_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_TrailDrawComponent_Stamp_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_TrailDrawComponent_Stamp_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_TrailDrawComponent_Stamp_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_TrailDrawComponent_Stamp_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601EB90 RID: 125840 RVA: 0x008FCB90 File Offset: 0x008FAD90
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_TrailDrawComponent_Stamp_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_TrailDrawComponent_Stamp_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_TrailDrawComponent_Stamp_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_TrailDrawComponent_Stamp_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_TrailDrawComponent_Stamp_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601EB91 RID: 125841 RVA: 0x008FCBD7 File Offset: 0x008FADD7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_TrailDrawComponent_Stamp_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0601EB92 RID: 125842 RVA: 0x008FCBEB File Offset: 0x008FADEB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_TrailDrawComponent_Stamp_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601EB93 RID: 125843 RVA: 0x008FCC00 File Offset: 0x008FAE00
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_TrailDrawComponent_Stamp(int EntryPoint)
		{
			BP_TrailDrawComponent_Stamp_C.__ExecuteUbergraph_BP_TrailDrawComponent_Stamp_FunctionParams* ptr = stackalloc BP_TrailDrawComponent_Stamp_C.__ExecuteUbergraph_BP_TrailDrawComponent_Stamp_FunctionParams[(UIntPtr)663] + 15L / (long)sizeof(BP_TrailDrawComponent_Stamp_C.__ExecuteUbergraph_BP_TrailDrawComponent_Stamp_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_TrailDrawComponent_Stamp_C.__ExecuteUbergraph_BP_TrailDrawComponent_Stamp_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_TrailDrawComponent_Stamp_C.__ExecuteUbergraph_BP_TrailDrawComponent_Stamp_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601EB94 RID: 125844 RVA: 0x008FCC4A File Offset: 0x008FAE4A
		protected BP_TrailDrawComponent_Stamp_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400F28B RID: 62091
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/TrailFields/Runtime/Drawers/BP_TrailDrawComponent_Stamp.BP_TrailDrawComponent_Stamp_C";

		// Token: 0x0400F28C RID: 62092
		private static IntPtr _ClassPtr;

		// Token: 0x0400F28D RID: 62093
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400F28E RID: 62094
		internal new static int __PropertyOffset_0;

		// Token: 0x0400F28F RID: 62095
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400F290 RID: 62096
		internal new static int __PropertyOffset_1;

		// Token: 0x0400F291 RID: 62097
		internal new static int __PropertyOffset_2;

		// Token: 0x0400F292 RID: 62098
		internal new static int __PropertyOffset_3;

		// Token: 0x0400F293 RID: 62099
		internal new static int __PropertyOffset_4;

		// Token: 0x0400F294 RID: 62100
		[Nullable(new byte[]
		{
			2,
			0
		})]
		private TArray<TEnumAsByte<EObjectTypeQuery>> _Object_Types;

		// Token: 0x0400F295 RID: 62101
		internal new static int __PropertyOffset_5;

		// Token: 0x0400F296 RID: 62102
		internal new static int __PropertyOffset_6;

		// Token: 0x0400F297 RID: 62103
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0400F298 RID: 62104
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0400F299 RID: 62105
		private static IntPtr __ExecuteUbergraph_BP_TrailDrawComponent_Stamp_NativeFunctionPtr;

		// Token: 0x020097F2 RID: 38898
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04031DE6 RID: 204262
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x020097F3 RID: 38899
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 648)]
		protected ref struct __ExecuteUbergraph_BP_TrailDrawComponent_Stamp_FunctionParams
		{
			// Token: 0x04031DE7 RID: 204263
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
