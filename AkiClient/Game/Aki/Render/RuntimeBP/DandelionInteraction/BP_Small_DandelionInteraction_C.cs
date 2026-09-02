using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.DandelionInteraction
{
	// Token: 0x02003D51 RID: 15697
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/DandelionInteraction/BP_Small_DandelionInteraction.BP_Small_DandelionInteraction_C")]
	[UnrealStructLayout(1336, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1336)]
	public class BP_Small_DandelionInteraction_C : AKuroBPActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060261E8 RID: 156136 RVA: 0x009CE7A1 File Offset: 0x009CC9A1
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_Small_DandelionInteraction_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/DandelionInteraction/BP_Small_DandelionInteraction.BP_Small_DandelionInteraction_C");
			}
			return BP_Small_DandelionInteraction_C._ClassPtr;
		}

		// Token: 0x060261E9 RID: 156137 RVA: 0x009CE7C8 File Offset: 0x009CC9C8
		public BP_Small_DandelionInteraction_C() : this(BuiltinUtils.AllocNativeUObject(BP_Small_DandelionInteraction_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060261EA RID: 156138 RVA: 0x009CE7F0 File Offset: 0x009CC9F0
		[NullableContext(1)]
		public BP_Small_DandelionInteraction_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_Small_DandelionInteraction_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17005592 RID: 21906
		// (get) Token: 0x060261EB RID: 156139 RVA: 0x009CE824 File Offset: 0x009CCA24
		// (set) Token: 0x060261EC RID: 156140 RVA: 0x009CE85D File Offset: 0x009CCA5D
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_Small_DandelionInteraction_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_Small_DandelionInteraction_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005593 RID: 21907
		// (get) Token: 0x060261ED RID: 156141 RVA: 0x009CE87E File Offset: 0x009CCA7E
		// (set) Token: 0x060261EE RID: 156142 RVA: 0x009CE892 File Offset: 0x009CCA92
		public unsafe UNiagaraComponent NS_Fx_DandelionInteraction
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Small_DandelionInteraction_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Small_DandelionInteraction_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17005594 RID: 21908
		// (get) Token: 0x060261EF RID: 156143 RVA: 0x009CE8A7 File Offset: 0x009CCAA7
		// (set) Token: 0x060261F0 RID: 156144 RVA: 0x009CE8BB File Offset: 0x009CCABB
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Small_DandelionInteraction_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Small_DandelionInteraction_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17005595 RID: 21909
		// (get) Token: 0x060261F1 RID: 156145 RVA: 0x009CE8D0 File Offset: 0x009CCAD0
		// (set) Token: 0x060261F2 RID: 156146 RVA: 0x009CE8E4 File Offset: 0x009CCAE4
		public unsafe UKuroPointCloudCache KuroPointCloud
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroPointCloudCache>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Small_DandelionInteraction_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Small_DandelionInteraction_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x060261F3 RID: 156147 RVA: 0x009CE8F9 File Offset: 0x009CCAF9
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void SetParam()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Small_DandelionInteraction_C.__SetParam_NativeFunctionPtr, null);
		}

		// Token: 0x060261F4 RID: 156148 RVA: 0x009CE90D File Offset: 0x009CCB0D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Small_DandelionInteraction_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x060261F5 RID: 156149 RVA: 0x009CE921 File Offset: 0x009CCB21
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Small_DandelionInteraction_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060261F6 RID: 156150 RVA: 0x009CE936 File Offset: 0x009CCB36
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Small_DandelionInteraction_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x060261F7 RID: 156151 RVA: 0x009CE94A File Offset: 0x009CCB4A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Small_DandelionInteraction_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060261F8 RID: 156152 RVA: 0x009CE960 File Offset: 0x009CCB60
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_Small_DandelionInteraction_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_Small_DandelionInteraction_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Small_DandelionInteraction_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Small_DandelionInteraction_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Small_DandelionInteraction_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060261F9 RID: 156153 RVA: 0x009CE9A8 File Offset: 0x009CCBA8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_Small_DandelionInteraction_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_Small_DandelionInteraction_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Small_DandelionInteraction_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Small_DandelionInteraction_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Small_DandelionInteraction_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060261FA RID: 156154 RVA: 0x009CE9F0 File Offset: 0x009CCBF0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_Small_DandelionInteraction(int EntryPoint)
		{
			BP_Small_DandelionInteraction_C.__ExecuteUbergraph_BP_Small_DandelionInteraction_FunctionParams* ptr = stackalloc BP_Small_DandelionInteraction_C.__ExecuteUbergraph_BP_Small_DandelionInteraction_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_Small_DandelionInteraction_C.__ExecuteUbergraph_BP_Small_DandelionInteraction_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Small_DandelionInteraction_C.__ExecuteUbergraph_BP_Small_DandelionInteraction_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Small_DandelionInteraction_C.__ExecuteUbergraph_BP_Small_DandelionInteraction_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060261FB RID: 156155 RVA: 0x009CEA37 File Offset: 0x009CCC37
		protected BP_Small_DandelionInteraction_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04013BE9 RID: 80873
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/DandelionInteraction/BP_Small_DandelionInteraction.BP_Small_DandelionInteraction_C";

		// Token: 0x04013BEA RID: 80874
		private static IntPtr _ClassPtr;

		// Token: 0x04013BEB RID: 80875
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04013BEC RID: 80876
		internal static int __PropertyOffset_0;

		// Token: 0x04013BED RID: 80877
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04013BEE RID: 80878
		internal static int __PropertyOffset_1;

		// Token: 0x04013BEF RID: 80879
		internal static int __PropertyOffset_2;

		// Token: 0x04013BF0 RID: 80880
		internal static int __PropertyOffset_3;

		// Token: 0x04013BF1 RID: 80881
		private static IntPtr __SetParam_NativeFunctionPtr;

		// Token: 0x04013BF2 RID: 80882
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04013BF3 RID: 80883
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04013BF4 RID: 80884
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04013BF5 RID: 80885
		private static IntPtr __ExecuteUbergraph_BP_Small_DandelionInteraction_NativeFunctionPtr;

		// Token: 0x0200A007 RID: 40967
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032BE6 RID: 207846
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x0200A008 RID: 40968
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __ExecuteUbergraph_BP_Small_DandelionInteraction_FunctionParams
		{
			// Token: 0x04032BE7 RID: 207847
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
