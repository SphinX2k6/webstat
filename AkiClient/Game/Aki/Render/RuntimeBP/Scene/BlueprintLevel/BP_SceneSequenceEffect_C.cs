using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.BlueprintLevel
{
	// Token: 0x02003B22 RID: 15138
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/BlueprintLevel/BP_SceneSequenceEffect.BP_SceneSequenceEffect_C")]
	[UnrealStructLayout(1392, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1392)]
	public class BP_SceneSequenceEffect_C : AKuroEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06020904 RID: 133380 RVA: 0x00930324 File Offset: 0x0092E524
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SceneSequenceEffect_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/BlueprintLevel/BP_SceneSequenceEffect.BP_SceneSequenceEffect_C");
			}
			return BP_SceneSequenceEffect_C._ClassPtr;
		}

		// Token: 0x06020905 RID: 133381 RVA: 0x00930348 File Offset: 0x0092E548
		public BP_SceneSequenceEffect_C() : this(BuiltinUtils.AllocNativeUObject(BP_SceneSequenceEffect_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06020906 RID: 133382 RVA: 0x00930370 File Offset: 0x0092E570
		[NullableContext(1)]
		public BP_SceneSequenceEffect_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SceneSequenceEffect_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003627 RID: 13863
		// (get) Token: 0x06020907 RID: 133383 RVA: 0x009303A4 File Offset: 0x0092E5A4
		// (set) Token: 0x06020908 RID: 133384 RVA: 0x009303DD File Offset: 0x0092E5DD
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_SceneSequenceEffect_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_SceneSequenceEffect_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17003628 RID: 13864
		// (get) Token: 0x06020909 RID: 133385 RVA: 0x009303FE File Offset: 0x0092E5FE
		// (set) Token: 0x0602090A RID: 133386 RVA: 0x00930412 File Offset: 0x0092E612
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SceneSequenceEffect_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SceneSequenceEffect_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17003629 RID: 13865
		// (get) Token: 0x0602090B RID: 133387 RVA: 0x00930427 File Offset: 0x0092E627
		// (set) Token: 0x0602090C RID: 133388 RVA: 0x00930437 File Offset: 0x0092E637
		public unsafe float DissolveProcess
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneSequenceEffect_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneSequenceEffect_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x1700362A RID: 13866
		// (get) Token: 0x0602090D RID: 133389 RVA: 0x00930448 File Offset: 0x0092E648
		// (set) Token: 0x0602090E RID: 133390 RVA: 0x0093045C File Offset: 0x0092E65C
		public unsafe AActor DissolveActor1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SceneSequenceEffect_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SceneSequenceEffect_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x1700362B RID: 13867
		// (get) Token: 0x0602090F RID: 133391 RVA: 0x00930471 File Offset: 0x0092E671
		// (set) Token: 0x06020910 RID: 133392 RVA: 0x00930485 File Offset: 0x0092E685
		public unsafe AActor DissolveActor2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SceneSequenceEffect_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SceneSequenceEffect_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x1700362C RID: 13868
		// (get) Token: 0x06020911 RID: 133393 RVA: 0x0093049A File Offset: 0x0092E69A
		// (set) Token: 0x06020912 RID: 133394 RVA: 0x009304AE File Offset: 0x0092E6AE
		public unsafe AActor DissolveActor3
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SceneSequenceEffect_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SceneSequenceEffect_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x1700362D RID: 13869
		// (get) Token: 0x06020913 RID: 133395 RVA: 0x009304C3 File Offset: 0x0092E6C3
		// (set) Token: 0x06020914 RID: 133396 RVA: 0x009304D7 File Offset: 0x0092E6D7
		public unsafe AActor DissolveActor4
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SceneSequenceEffect_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SceneSequenceEffect_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x1700362E RID: 13870
		// (get) Token: 0x06020915 RID: 133397 RVA: 0x009304EC File Offset: 0x0092E6EC
		// (set) Token: 0x06020916 RID: 133398 RVA: 0x00930500 File Offset: 0x0092E700
		public unsafe AActor DissolveActor5
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SceneSequenceEffect_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SceneSequenceEffect_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x1700362F RID: 13871
		// (get) Token: 0x06020917 RID: 133399 RVA: 0x00930515 File Offset: 0x0092E715
		// (set) Token: 0x06020918 RID: 133400 RVA: 0x00930529 File Offset: 0x0092E729
		public unsafe AActor DissolveActor6
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SceneSequenceEffect_C.__PropertyOffset_8);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SceneSequenceEffect_C.__PropertyOffset_8, value);
			}
		}

		// Token: 0x17003630 RID: 13872
		// (get) Token: 0x06020919 RID: 133401 RVA: 0x0093053E File Offset: 0x0092E73E
		// (set) Token: 0x0602091A RID: 133402 RVA: 0x00930552 File Offset: 0x0092E752
		public unsafe AActor DissolveActor7
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SceneSequenceEffect_C.__PropertyOffset_9);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SceneSequenceEffect_C.__PropertyOffset_9, value);
			}
		}

		// Token: 0x0602091B RID: 133403 RVA: 0x00930568 File Offset: 0x0092E768
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void UpdateSM(AActor SM, float Dissolve)
		{
			BP_SceneSequenceEffect_C.__UpdateSM_FunctionParams* ptr = stackalloc BP_SceneSequenceEffect_C.__UpdateSM_FunctionParams[(UIntPtr)71] + 15L / (long)sizeof(BP_SceneSequenceEffect_C.__UpdateSM_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SceneSequenceEffect_C.__UpdateSM_NativeFunctionPtr, (void*)ptr, 1);
			ptr->SM = ((SM != null) ? SM.NativePtr : IntPtr.Zero);
			ptr->Dissolve = Dissolve;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SceneSequenceEffect_C.__UpdateSM_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602091C RID: 133404 RVA: 0x009305C4 File Offset: 0x0092E7C4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateDissolveProcess()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SceneSequenceEffect_C.__UpdateDissolveProcess_NativeFunctionPtr, null);
		}

		// Token: 0x0602091D RID: 133405 RVA: 0x009305D8 File Offset: 0x0092E7D8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SceneSequenceEffect_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x0602091E RID: 133406 RVA: 0x009305EC File Offset: 0x0092E7EC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SceneSequenceEffect_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602091F RID: 133407 RVA: 0x00930604 File Offset: 0x0092E804
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_SceneSequenceEffect_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_SceneSequenceEffect_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SceneSequenceEffect_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SceneSequenceEffect_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SceneSequenceEffect_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06020920 RID: 133408 RVA: 0x0093064C File Offset: 0x0092E84C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_SceneSequenceEffect_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_SceneSequenceEffect_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SceneSequenceEffect_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SceneSequenceEffect_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SceneSequenceEffect_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06020921 RID: 133409 RVA: 0x00930694 File Offset: 0x0092E894
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_SceneSequenceEffect_C.__EditorTick_FunctionParams* ptr = stackalloc BP_SceneSequenceEffect_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SceneSequenceEffect_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SceneSequenceEffect_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SceneSequenceEffect_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06020922 RID: 133410 RVA: 0x009306DC File Offset: 0x0092E8DC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_SceneSequenceEffect_C.__EditorTick_FunctionParams* ptr = stackalloc BP_SceneSequenceEffect_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SceneSequenceEffect_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SceneSequenceEffect_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SceneSequenceEffect_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06020923 RID: 133411 RVA: 0x00930723 File Offset: 0x0092E923
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SceneSequenceEffect_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06020924 RID: 133412 RVA: 0x00930737 File Offset: 0x0092E937
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SceneSequenceEffect_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06020925 RID: 133413 RVA: 0x0093074C File Offset: 0x0092E94C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_SceneSequenceEffect(int EntryPoint)
		{
			BP_SceneSequenceEffect_C.__ExecuteUbergraph_BP_SceneSequenceEffect_FunctionParams* ptr = stackalloc BP_SceneSequenceEffect_C.__ExecuteUbergraph_BP_SceneSequenceEffect_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(BP_SceneSequenceEffect_C.__ExecuteUbergraph_BP_SceneSequenceEffect_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SceneSequenceEffect_C.__ExecuteUbergraph_BP_SceneSequenceEffect_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SceneSequenceEffect_C.__ExecuteUbergraph_BP_SceneSequenceEffect_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06020926 RID: 133414 RVA: 0x00930793 File Offset: 0x0092E993
		protected BP_SceneSequenceEffect_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040104B5 RID: 66741
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/BlueprintLevel/BP_SceneSequenceEffect.BP_SceneSequenceEffect_C";

		// Token: 0x040104B6 RID: 66742
		private static IntPtr _ClassPtr;

		// Token: 0x040104B7 RID: 66743
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040104B8 RID: 66744
		internal static int __PropertyOffset_0;

		// Token: 0x040104B9 RID: 66745
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040104BA RID: 66746
		internal static int __PropertyOffset_1;

		// Token: 0x040104BB RID: 66747
		internal static int __PropertyOffset_2;

		// Token: 0x040104BC RID: 66748
		internal static int __PropertyOffset_3;

		// Token: 0x040104BD RID: 66749
		internal static int __PropertyOffset_4;

		// Token: 0x040104BE RID: 66750
		internal static int __PropertyOffset_5;

		// Token: 0x040104BF RID: 66751
		internal static int __PropertyOffset_6;

		// Token: 0x040104C0 RID: 66752
		internal static int __PropertyOffset_7;

		// Token: 0x040104C1 RID: 66753
		internal static int __PropertyOffset_8;

		// Token: 0x040104C2 RID: 66754
		internal static int __PropertyOffset_9;

		// Token: 0x040104C3 RID: 66755
		private static IntPtr __UpdateSM_NativeFunctionPtr;

		// Token: 0x040104C4 RID: 66756
		private static IntPtr __UpdateDissolveProcess_NativeFunctionPtr;

		// Token: 0x040104C5 RID: 66757
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x040104C6 RID: 66758
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x040104C7 RID: 66759
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x040104C8 RID: 66760
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x040104C9 RID: 66761
		private static IntPtr __ExecuteUbergraph_BP_SceneSequenceEffect_NativeFunctionPtr;

		// Token: 0x020099E1 RID: 39393
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 56)]
		protected ref struct __UpdateSM_FunctionParams
		{
			// Token: 0x040320A7 RID: 204967
			[FieldOffset(0)]
			public IntPtr SM;

			// Token: 0x040320A8 RID: 204968
			[FieldOffset(8)]
			public float Dissolve;
		}

		// Token: 0x020099E2 RID: 39394
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x040320A9 RID: 204969
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x020099E3 RID: 39395
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x040320AA RID: 204970
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x020099E4 RID: 39396
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __ExecuteUbergraph_BP_SceneSequenceEffect_FunctionParams
		{
			// Token: 0x040320AB RID: 204971
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
