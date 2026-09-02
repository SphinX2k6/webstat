using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Sequence
{
	// Token: 0x02003A62 RID: 14946
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Sequence/ExecuteCommandsTool.ExecuteCommandsTool_C")]
	[UnrealStructLayout(1088, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1088)]
	public class ExecuteCommandsTool_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601F178 RID: 127352 RVA: 0x0090785C File Offset: 0x00905A5C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (ExecuteCommandsTool_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Sequence/ExecuteCommandsTool.ExecuteCommandsTool_C");
			}
			return ExecuteCommandsTool_C._ClassPtr;
		}

		// Token: 0x0601F179 RID: 127353 RVA: 0x00907880 File Offset: 0x00905A80
		public ExecuteCommandsTool_C() : this(BuiltinUtils.AllocNativeUObject(ExecuteCommandsTool_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601F17A RID: 127354 RVA: 0x009078A8 File Offset: 0x00905AA8
		public ExecuteCommandsTool_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(ExecuteCommandsTool_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17002E05 RID: 11781
		// (get) Token: 0x0601F17B RID: 127355 RVA: 0x009078DC File Offset: 0x00905ADC
		// (set) Token: 0x0601F17C RID: 127356 RVA: 0x00907915 File Offset: 0x00905B15
		public FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)ExecuteCommandsTool_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)ExecuteCommandsTool_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17002E06 RID: 11782
		// (get) Token: 0x0601F17D RID: 127357 RVA: 0x00907936 File Offset: 0x00905B36
		// (set) Token: 0x0601F17E RID: 127358 RVA: 0x0090794A File Offset: 0x00905B4A
		[Nullable(2)]
		public unsafe USceneComponent DefaultSceneRoot
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + ExecuteCommandsTool_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + ExecuteCommandsTool_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17002E07 RID: 11783
		// (get) Token: 0x0601F17F RID: 127359 RVA: 0x0090795F File Offset: 0x00905B5F
		// (set) Token: 0x0601F180 RID: 127360 RVA: 0x0090796F File Offset: 0x00905B6F
		public unsafe bool NeedRunEndCommand
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ExecuteCommandsTool_C.__PropertyOffset_2) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ExecuteCommandsTool_C.__PropertyOffset_2) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002E08 RID: 11784
		// (get) Token: 0x0601F181 RID: 127361 RVA: 0x00907980 File Offset: 0x00905B80
		// (set) Token: 0x0601F182 RID: 127362 RVA: 0x009079B9 File Offset: 0x00905BB9
		public TArray<string> StartCommandArray
		{
			get
			{
				base.FastCheckIsValid();
				TArray<string> result;
				if ((result = this._StartCommandArray) == null)
				{
					result = (this._StartCommandArray = new TArray<string>(base.NativePtr + (IntPtr)ExecuteCommandsTool_C.__PropertyOffset_3, this));
				}
				return result;
			}
			set
			{
				this.StartCommandArray.CopyAssign(value);
			}
		}

		// Token: 0x17002E09 RID: 11785
		// (get) Token: 0x0601F183 RID: 127363 RVA: 0x009079C8 File Offset: 0x00905BC8
		// (set) Token: 0x0601F184 RID: 127364 RVA: 0x00907A01 File Offset: 0x00905C01
		public TArray<string> EndCommandArray
		{
			get
			{
				base.FastCheckIsValid();
				TArray<string> result;
				if ((result = this._EndCommandArray) == null)
				{
					result = (this._EndCommandArray = new TArray<string>(base.NativePtr + (IntPtr)ExecuteCommandsTool_C.__PropertyOffset_4, this));
				}
				return result;
			}
			set
			{
				this.EndCommandArray.CopyAssign(value);
			}
		}

		// Token: 0x0601F185 RID: 127365 RVA: 0x00907A0F File Offset: 0x00905C0F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ExecuteCommandsTool_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x0601F186 RID: 127366 RVA: 0x00907A23 File Offset: 0x00905C23
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, ExecuteCommandsTool_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601F187 RID: 127367 RVA: 0x00907A38 File Offset: 0x00905C38
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveEndPlay(EEndPlayReason EndPlayReason)
		{
			ExecuteCommandsTool_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc ExecuteCommandsTool_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(ExecuteCommandsTool_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ExecuteCommandsTool_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ExecuteCommandsTool_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F188 RID: 127368 RVA: 0x00907A84 File Offset: 0x00905C84
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveEndPlay_Implementation(EEndPlayReason EndPlayReason)
		{
			ExecuteCommandsTool_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc ExecuteCommandsTool_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(ExecuteCommandsTool_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ExecuteCommandsTool_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, ExecuteCommandsTool_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601F189 RID: 127369 RVA: 0x00907AD0 File Offset: 0x00905CD0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_ExecuteCommandsTool(int EntryPoint)
		{
			ExecuteCommandsTool_C.__ExecuteUbergraph_ExecuteCommandsTool_FunctionParams* ptr = stackalloc ExecuteCommandsTool_C.__ExecuteUbergraph_ExecuteCommandsTool_FunctionParams[(UIntPtr)63] + 15L / (long)sizeof(ExecuteCommandsTool_C.__ExecuteUbergraph_ExecuteCommandsTool_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ExecuteCommandsTool_C.__ExecuteUbergraph_ExecuteCommandsTool_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, ExecuteCommandsTool_C.__ExecuteUbergraph_ExecuteCommandsTool_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601F18A RID: 127370 RVA: 0x00907B17 File Offset: 0x00905D17
		protected ExecuteCommandsTool_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400F64C RID: 63052
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Sequence/ExecuteCommandsTool.ExecuteCommandsTool_C";

		// Token: 0x0400F64D RID: 63053
		private static IntPtr _ClassPtr;

		// Token: 0x0400F64E RID: 63054
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400F64F RID: 63055
		internal static int __PropertyOffset_0;

		// Token: 0x0400F650 RID: 63056
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400F651 RID: 63057
		internal static int __PropertyOffset_1;

		// Token: 0x0400F652 RID: 63058
		internal static int __PropertyOffset_2;

		// Token: 0x0400F653 RID: 63059
		internal static int __PropertyOffset_3;

		// Token: 0x0400F654 RID: 63060
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<string> _StartCommandArray;

		// Token: 0x0400F655 RID: 63061
		internal static int __PropertyOffset_4;

		// Token: 0x0400F656 RID: 63062
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<string> _EndCommandArray;

		// Token: 0x0400F657 RID: 63063
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x0400F658 RID: 63064
		private static IntPtr __ReceiveEndPlay_NativeFunctionPtr;

		// Token: 0x0400F659 RID: 63065
		private static IntPtr __ExecuteUbergraph_ExecuteCommandsTool_NativeFunctionPtr;

		// Token: 0x0200985D RID: 39005
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __ReceiveEndPlay_FunctionParams
		{
			// Token: 0x04031E92 RID: 204434
			[FieldOffset(0)]
			public TEnumAsByte<EEndPlayReason> EndPlayReason;
		}

		// Token: 0x0200985E RID: 39006
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 48)]
		protected ref struct __ExecuteUbergraph_ExecuteCommandsTool_FunctionParams
		{
			// Token: 0x04031E93 RID: 204435
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
