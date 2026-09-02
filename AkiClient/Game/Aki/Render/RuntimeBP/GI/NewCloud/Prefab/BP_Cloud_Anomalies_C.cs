using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Render.RuntimeBP.GI.NewCloud.BP;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.GI.NewCloud.Prefab
{
	// Token: 0x02003CB4 RID: 15540
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/GI/NewCloud/Prefab/BP_Cloud_Anomalies.BP_Cloud_Anomalies_C")]
	[UnrealStructLayout(1816, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1816)]
	public class BP_Cloud_Anomalies_C : BP_CloudPrefab_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06024C00 RID: 150528 RVA: 0x009A648C File Offset: 0x009A468C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_Cloud_Anomalies_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/GI/NewCloud/Prefab/BP_Cloud_Anomalies.BP_Cloud_Anomalies_C");
			}
			return BP_Cloud_Anomalies_C._ClassPtr;
		}

		// Token: 0x06024C01 RID: 150529 RVA: 0x009A64B0 File Offset: 0x009A46B0
		public BP_Cloud_Anomalies_C() : this(BuiltinUtils.AllocNativeUObject(BP_Cloud_Anomalies_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06024C02 RID: 150530 RVA: 0x009A64D8 File Offset: 0x009A46D8
		[NullableContext(1)]
		public BP_Cloud_Anomalies_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_Cloud_Anomalies_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17004DD9 RID: 19929
		// (get) Token: 0x06024C03 RID: 150531 RVA: 0x009A650C File Offset: 0x009A470C
		// (set) Token: 0x06024C04 RID: 150532 RVA: 0x009A6545 File Offset: 0x009A4745
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_Cloud_Anomalies_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_Cloud_Anomalies_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17004DDA RID: 19930
		// (get) Token: 0x06024C05 RID: 150533 RVA: 0x009A6566 File Offset: 0x009A4766
		// (set) Token: 0x06024C06 RID: 150534 RVA: 0x009A657A File Offset: 0x009A477A
		[Nullable(2)]
		public unsafe UStaticMeshComponent Cloud_Anomalies
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Cloud_Anomalies_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Cloud_Anomalies_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x06024C07 RID: 150535 RVA: 0x009A658F File Offset: 0x009A478F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Cloud_Anomalies_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06024C08 RID: 150536 RVA: 0x009A65A3 File Offset: 0x009A47A3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Cloud_Anomalies_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06024C09 RID: 150537 RVA: 0x009A65B8 File Offset: 0x009A47B8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Cloud_Anomalies_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06024C0A RID: 150538 RVA: 0x009A65CC File Offset: 0x009A47CC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Cloud_Anomalies_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06024C0B RID: 150539 RVA: 0x009A65E4 File Offset: 0x009A47E4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_Cloud_Anomalies_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_Cloud_Anomalies_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Cloud_Anomalies_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Cloud_Anomalies_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Cloud_Anomalies_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024C0C RID: 150540 RVA: 0x009A662C File Offset: 0x009A482C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_Cloud_Anomalies_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_Cloud_Anomalies_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Cloud_Anomalies_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Cloud_Anomalies_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Cloud_Anomalies_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06024C0D RID: 150541 RVA: 0x009A6674 File Offset: 0x009A4874
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_Cloud_Anomalies_C.__EditorTick_FunctionParams* ptr = stackalloc BP_Cloud_Anomalies_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Cloud_Anomalies_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Cloud_Anomalies_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Cloud_Anomalies_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024C0E RID: 150542 RVA: 0x009A66BC File Offset: 0x009A48BC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_Cloud_Anomalies_C.__EditorTick_FunctionParams* ptr = stackalloc BP_Cloud_Anomalies_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Cloud_Anomalies_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Cloud_Anomalies_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Cloud_Anomalies_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06024C0F RID: 150543 RVA: 0x009A6704 File Offset: 0x009A4904
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_Cloud_Anomalies(int EntryPoint)
		{
			BP_Cloud_Anomalies_C.__ExecuteUbergraph_BP_Cloud_Anomalies_FunctionParams* ptr = stackalloc BP_Cloud_Anomalies_C.__ExecuteUbergraph_BP_Cloud_Anomalies_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(BP_Cloud_Anomalies_C.__ExecuteUbergraph_BP_Cloud_Anomalies_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Cloud_Anomalies_C.__ExecuteUbergraph_BP_Cloud_Anomalies_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Cloud_Anomalies_C.__ExecuteUbergraph_BP_Cloud_Anomalies_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06024C10 RID: 150544 RVA: 0x009A674B File Offset: 0x009A494B
		protected BP_Cloud_Anomalies_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04012D8A RID: 77194
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/GI/NewCloud/Prefab/BP_Cloud_Anomalies.BP_Cloud_Anomalies_C";

		// Token: 0x04012D8B RID: 77195
		private static IntPtr _ClassPtr;

		// Token: 0x04012D8C RID: 77196
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04012D8D RID: 77197
		internal new static int __PropertyOffset_0;

		// Token: 0x04012D8E RID: 77198
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04012D8F RID: 77199
		internal new static int __PropertyOffset_1;

		// Token: 0x04012D90 RID: 77200
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04012D91 RID: 77201
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04012D92 RID: 77202
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04012D93 RID: 77203
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x04012D94 RID: 77204
		private static IntPtr __ExecuteUbergraph_BP_Cloud_Anomalies_NativeFunctionPtr;

		// Token: 0x02009E40 RID: 40512
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032893 RID: 206995
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009E41 RID: 40513
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x04032894 RID: 206996
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009E42 RID: 40514
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __ExecuteUbergraph_BP_Cloud_Anomalies_FunctionParams
		{
			// Token: 0x04032895 RID: 206997
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
