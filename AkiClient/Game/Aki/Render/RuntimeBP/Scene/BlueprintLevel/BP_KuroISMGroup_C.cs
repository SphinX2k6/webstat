using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.BlueprintLevel
{
	// Token: 0x02003B20 RID: 15136
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/BlueprintLevel/BP_KuroISMGroup.BP_KuroISMGroup_C")]
	[UnrealStructLayout(1096, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1096)]
	public class BP_KuroISMGroup_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602089F RID: 133279 RVA: 0x0092F13F File Offset: 0x0092D33F
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_KuroISMGroup_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/BlueprintLevel/BP_KuroISMGroup.BP_KuroISMGroup_C");
			}
			return BP_KuroISMGroup_C._ClassPtr;
		}

		// Token: 0x060208A0 RID: 133280 RVA: 0x0092F164 File Offset: 0x0092D364
		public BP_KuroISMGroup_C() : this(BuiltinUtils.AllocNativeUObject(BP_KuroISMGroup_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060208A1 RID: 133281 RVA: 0x0092F18C File Offset: 0x0092D38C
		[NullableContext(1)]
		public BP_KuroISMGroup_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_KuroISMGroup_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003608 RID: 13832
		// (get) Token: 0x060208A2 RID: 133282 RVA: 0x0092F1C0 File Offset: 0x0092D3C0
		// (set) Token: 0x060208A3 RID: 133283 RVA: 0x0092F1F9 File Offset: 0x0092D3F9
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_KuroISMGroup_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_KuroISMGroup_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17003609 RID: 13833
		// (get) Token: 0x060208A4 RID: 133284 RVA: 0x0092F21A File Offset: 0x0092D41A
		// (set) Token: 0x060208A5 RID: 133285 RVA: 0x0092F22E File Offset: 0x0092D42E
		[Nullable(2)]
		public unsafe USceneComponent DefaultSceneRoot
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroISMGroup_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroISMGroup_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x1700360A RID: 13834
		// (get) Token: 0x060208A6 RID: 133286 RVA: 0x0092F243 File Offset: 0x0092D443
		// (set) Token: 0x060208A7 RID: 133287 RVA: 0x0092F253 File Offset: 0x0092D453
		public unsafe bool HideLogicallyOnBeginPlay
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroISMGroup_C.__PropertyOffset_2) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroISMGroup_C.__PropertyOffset_2) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700360B RID: 13835
		// (get) Token: 0x060208A8 RID: 133288 RVA: 0x0092F264 File Offset: 0x0092D464
		// (set) Token: 0x060208A9 RID: 133289 RVA: 0x0092F274 File Offset: 0x0092D474
		public unsafe float DitherProgress
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroISMGroup_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroISMGroup_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x1700360C RID: 13836
		// (get) Token: 0x060208AA RID: 133290 RVA: 0x0092F285 File Offset: 0x0092D485
		// (set) Token: 0x060208AB RID: 133291 RVA: 0x0092F295 File Offset: 0x0092D495
		public unsafe float Duration
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroISMGroup_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroISMGroup_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x1700360D RID: 13837
		// (get) Token: 0x060208AC RID: 133292 RVA: 0x0092F2A6 File Offset: 0x0092D4A6
		// (set) Token: 0x060208AD RID: 133293 RVA: 0x0092F2B6 File Offset: 0x0092D4B6
		public unsafe bool IsTick
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroISMGroup_C.__PropertyOffset_5) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroISMGroup_C.__PropertyOffset_5) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700360E RID: 13838
		// (get) Token: 0x060208AE RID: 133294 RVA: 0x0092F2C7 File Offset: 0x0092D4C7
		// (set) Token: 0x060208AF RID: 133295 RVA: 0x0092F2D7 File Offset: 0x0092D4D7
		public unsafe float DeltaSeconds
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroISMGroup_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroISMGroup_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x1700360F RID: 13839
		// (get) Token: 0x060208B0 RID: 133296 RVA: 0x0092F2E8 File Offset: 0x0092D4E8
		// (set) Token: 0x060208B1 RID: 133297 RVA: 0x0092F2F8 File Offset: 0x0092D4F8
		public unsafe float Time
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroISMGroup_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroISMGroup_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17003610 RID: 13840
		// (get) Token: 0x060208B2 RID: 133298 RVA: 0x0092F309 File Offset: 0x0092D509
		// (set) Token: 0x060208B3 RID: 133299 RVA: 0x0092F319 File Offset: 0x0092D519
		public unsafe bool IsShow
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroISMGroup_C.__PropertyOffset_8) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroISMGroup_C.__PropertyOffset_8) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003611 RID: 13841
		// (get) Token: 0x060208B4 RID: 133300 RVA: 0x0092F32A File Offset: 0x0092D52A
		// (set) Token: 0x060208B5 RID: 133301 RVA: 0x0092F33E File Offset: 0x0092D53E
		public unsafe FName ParameterName
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroISMGroup_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroISMGroup_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17003612 RID: 13842
		// (get) Token: 0x060208B6 RID: 133302 RVA: 0x0092F353 File Offset: 0x0092D553
		// (set) Token: 0x060208B7 RID: 133303 RVA: 0x0092F363 File Offset: 0x0092D563
		public unsafe float FloatPar_Start
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroISMGroup_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroISMGroup_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17003613 RID: 13843
		// (get) Token: 0x060208B8 RID: 133304 RVA: 0x0092F374 File Offset: 0x0092D574
		// (set) Token: 0x060208B9 RID: 133305 RVA: 0x0092F384 File Offset: 0x0092D584
		public unsafe float FloatPar_End
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroISMGroup_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroISMGroup_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x060208BA RID: 133306 RVA: 0x0092F398 File Offset: 0x0092D598
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Timer(ref float ElapsedTime)
		{
			BP_KuroISMGroup_C.__Timer_FunctionParams* ptr = stackalloc BP_KuroISMGroup_C.__Timer_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_KuroISMGroup_C.__Timer_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroISMGroup_C.__Timer_NativeFunctionPtr, (void*)ptr, 1);
			ptr->ElapsedTime = ElapsedTime;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroISMGroup_C.__Timer_NativeFunctionPtr, (void*)ptr);
			ElapsedTime = ptr->ElapsedTime;
		}

		// Token: 0x060208BB RID: 133307 RVA: 0x0092F3E8 File Offset: 0x0092D5E8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void MaterialParameterGradient(float DeltalTime)
		{
			BP_KuroISMGroup_C.__MaterialParameterGradient_FunctionParams* ptr = stackalloc BP_KuroISMGroup_C.__MaterialParameterGradient_FunctionParams[(UIntPtr)295] + 15L / (long)sizeof(BP_KuroISMGroup_C.__MaterialParameterGradient_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroISMGroup_C.__MaterialParameterGradient_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltalTime = DeltalTime;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroISMGroup_C.__MaterialParameterGradient_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060208BC RID: 133308 RVA: 0x0092F431 File Offset: 0x0092D631
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void SeyLogicallyShowForAllChildren()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroISMGroup_C.__SeyLogicallyShowForAllChildren_NativeFunctionPtr, null);
		}

		// Token: 0x060208BD RID: 133309 RVA: 0x0092F445 File Offset: 0x0092D645
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void SeyLogicallyHiddenForAllChildren()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroISMGroup_C.__SeyLogicallyHiddenForAllChildren_NativeFunctionPtr, null);
		}

		// Token: 0x060208BE RID: 133310 RVA: 0x0092F459 File Offset: 0x0092D659
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EditorValidCheck()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroISMGroup_C.__EditorValidCheck_NativeFunctionPtr, null);
		}

		// Token: 0x060208BF RID: 133311 RVA: 0x0092F470 File Offset: 0x0092D670
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void IsEditor(ref bool IsEditor)
		{
			BP_KuroISMGroup_C.__IsEditor_FunctionParams* ptr = stackalloc BP_KuroISMGroup_C.__IsEditor_FunctionParams[(UIntPtr)20] + 15L / (long)sizeof(BP_KuroISMGroup_C.__IsEditor_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroISMGroup_C.__IsEditor_NativeFunctionPtr, (void*)ptr, 1);
			ptr->IsEditor = IsEditor;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroISMGroup_C.__IsEditor_NativeFunctionPtr, (void*)ptr);
			IsEditor = ptr->IsEditor;
		}

		// Token: 0x060208C0 RID: 133312 RVA: 0x0092F4BF File Offset: 0x0092D6BF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroISMGroup_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x060208C1 RID: 133313 RVA: 0x0092F4D3 File Offset: 0x0092D6D3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroISMGroup_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060208C2 RID: 133314 RVA: 0x0092F4E8 File Offset: 0x0092D6E8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroISMGroup_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x060208C3 RID: 133315 RVA: 0x0092F4FC File Offset: 0x0092D6FC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroISMGroup_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060208C4 RID: 133316 RVA: 0x0092F514 File Offset: 0x0092D714
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_KuroISMGroup_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_KuroISMGroup_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_KuroISMGroup_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroISMGroup_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroISMGroup_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060208C5 RID: 133317 RVA: 0x0092F55C File Offset: 0x0092D75C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_KuroISMGroup_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_KuroISMGroup_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_KuroISMGroup_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroISMGroup_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroISMGroup_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060208C6 RID: 133318 RVA: 0x0092F5A4 File Offset: 0x0092D7A4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_KuroISMGroup(int EntryPoint)
		{
			BP_KuroISMGroup_C.__ExecuteUbergraph_BP_KuroISMGroup_FunctionParams* ptr = stackalloc BP_KuroISMGroup_C.__ExecuteUbergraph_BP_KuroISMGroup_FunctionParams[(UIntPtr)119] + 15L / (long)sizeof(BP_KuroISMGroup_C.__ExecuteUbergraph_BP_KuroISMGroup_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroISMGroup_C.__ExecuteUbergraph_BP_KuroISMGroup_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroISMGroup_C.__ExecuteUbergraph_BP_KuroISMGroup_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060208C7 RID: 133319 RVA: 0x0092F5EB File Offset: 0x0092D7EB
		protected BP_KuroISMGroup_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04010469 RID: 66665
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/BlueprintLevel/BP_KuroISMGroup.BP_KuroISMGroup_C";

		// Token: 0x0401046A RID: 66666
		private static IntPtr _ClassPtr;

		// Token: 0x0401046B RID: 66667
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401046C RID: 66668
		internal static int __PropertyOffset_0;

		// Token: 0x0401046D RID: 66669
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0401046E RID: 66670
		internal static int __PropertyOffset_1;

		// Token: 0x0401046F RID: 66671
		internal static int __PropertyOffset_2;

		// Token: 0x04010470 RID: 66672
		internal static int __PropertyOffset_3;

		// Token: 0x04010471 RID: 66673
		internal static int __PropertyOffset_4;

		// Token: 0x04010472 RID: 66674
		internal static int __PropertyOffset_5;

		// Token: 0x04010473 RID: 66675
		internal static int __PropertyOffset_6;

		// Token: 0x04010474 RID: 66676
		internal static int __PropertyOffset_7;

		// Token: 0x04010475 RID: 66677
		internal static int __PropertyOffset_8;

		// Token: 0x04010476 RID: 66678
		internal static int __PropertyOffset_9;

		// Token: 0x04010477 RID: 66679
		internal static int __PropertyOffset_10;

		// Token: 0x04010478 RID: 66680
		internal static int __PropertyOffset_11;

		// Token: 0x04010479 RID: 66681
		private static IntPtr __Timer_NativeFunctionPtr;

		// Token: 0x0401047A RID: 66682
		private static IntPtr __MaterialParameterGradient_NativeFunctionPtr;

		// Token: 0x0401047B RID: 66683
		private static IntPtr __SeyLogicallyShowForAllChildren_NativeFunctionPtr;

		// Token: 0x0401047C RID: 66684
		private static IntPtr __SeyLogicallyHiddenForAllChildren_NativeFunctionPtr;

		// Token: 0x0401047D RID: 66685
		private static IntPtr __EditorValidCheck_NativeFunctionPtr;

		// Token: 0x0401047E RID: 66686
		private static IntPtr __IsEditor_NativeFunctionPtr;

		// Token: 0x0401047F RID: 66687
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04010480 RID: 66688
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04010481 RID: 66689
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04010482 RID: 66690
		private static IntPtr __ExecuteUbergraph_BP_KuroISMGroup_NativeFunctionPtr;

		// Token: 0x020099CE RID: 39374
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __Timer_FunctionParams
		{
			// Token: 0x04032082 RID: 204930
			[FieldOffset(0)]
			public float ElapsedTime;
		}

		// Token: 0x020099CF RID: 39375
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 280)]
		protected ref struct __MaterialParameterGradient_FunctionParams
		{
			// Token: 0x04032083 RID: 204931
			[FieldOffset(0)]
			public float DeltalTime;
		}

		// Token: 0x020099D0 RID: 39376
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 5)]
		protected ref struct __IsEditor_FunctionParams
		{
			// Token: 0x04032084 RID: 204932
			[FieldOffset(0)]
			public bool IsEditor;
		}

		// Token: 0x020099D1 RID: 39377
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032085 RID: 204933
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x020099D2 RID: 39378
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 104)]
		protected ref struct __ExecuteUbergraph_BP_KuroISMGroup_FunctionParams
		{
			// Token: 0x04032086 RID: 204934
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
