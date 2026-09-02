using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Core.Fight;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.LeavesInteraction
{
	// Token: 0x02003C67 RID: 15463
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/LeavesInteraction/BP_WindFieldInteraction.BP_WindFieldInteraction_C")]
	[UnrealStructLayout(1632, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1632)]
	public class BP_WindFieldInteraction_C : AKuroWindFieldInteraction, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06023D1C RID: 146716 RVA: 0x0098D037 File Offset: 0x0098B237
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_WindFieldInteraction_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/LeavesInteraction/BP_WindFieldInteraction.BP_WindFieldInteraction_C");
			}
			return BP_WindFieldInteraction_C._ClassPtr;
		}

		// Token: 0x06023D1D RID: 146717 RVA: 0x0098D05C File Offset: 0x0098B25C
		public BP_WindFieldInteraction_C() : this(BuiltinUtils.AllocNativeUObject(BP_WindFieldInteraction_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06023D1E RID: 146718 RVA: 0x0098D084 File Offset: 0x0098B284
		[NullableContext(1)]
		public BP_WindFieldInteraction_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_WindFieldInteraction_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17004882 RID: 18562
		// (get) Token: 0x06023D1F RID: 146719 RVA: 0x0098D0B8 File Offset: 0x0098B2B8
		// (set) Token: 0x06023D20 RID: 146720 RVA: 0x0098D0F1 File Offset: 0x0098B2F1
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_WindFieldInteraction_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_WindFieldInteraction_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17004883 RID: 18563
		// (get) Token: 0x06023D21 RID: 146721 RVA: 0x0098D112 File Offset: 0x0098B312
		// (set) Token: 0x06023D22 RID: 146722 RVA: 0x0098D126 File Offset: 0x0098B326
		public unsafe UBoxComponent AreaBox
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WindFieldInteraction_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WindFieldInteraction_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17004884 RID: 18564
		// (get) Token: 0x06023D23 RID: 146723 RVA: 0x0098D13B File Offset: 0x0098B33B
		// (set) Token: 0x06023D24 RID: 146724 RVA: 0x0098D14F File Offset: 0x0098B34F
		public unsafe UNiagaraComponent NS_WindField
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WindFieldInteraction_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WindFieldInteraction_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17004885 RID: 18565
		// (get) Token: 0x06023D25 RID: 146725 RVA: 0x0098D164 File Offset: 0x0098B364
		// (set) Token: 0x06023D26 RID: 146726 RVA: 0x0098D178 File Offset: 0x0098B378
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WindFieldInteraction_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WindFieldInteraction_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17004886 RID: 18566
		// (get) Token: 0x06023D27 RID: 146727 RVA: 0x0098D18D File Offset: 0x0098B38D
		// (set) Token: 0x06023D28 RID: 146728 RVA: 0x0098D1A1 File Offset: 0x0098B3A1
		public unsafe UMaterialParameterCollection Global_MPC
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialParameterCollection>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WindFieldInteraction_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WindFieldInteraction_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17004887 RID: 18567
		// (get) Token: 0x06023D29 RID: 146729 RVA: 0x0098D1B6 File Offset: 0x0098B3B6
		// (set) Token: 0x06023D2A RID: 146730 RVA: 0x0098D1CA File Offset: 0x0098B3CA
		public unsafe UMaterialParameterCollection Leaves_MPC
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialParameterCollection>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WindFieldInteraction_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WindFieldInteraction_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x06023D2B RID: 146731 RVA: 0x0098D1DF File Offset: 0x0098B3DF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateMotorcycleData()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WindFieldInteraction_C.__UpdateMotorcycleData_NativeFunctionPtr, null);
		}

		// Token: 0x06023D2C RID: 146732 RVA: 0x0098D1F4 File Offset: 0x0098B3F4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetWeaponPosition(FVector Position, int Type)
		{
			BP_WindFieldInteraction_C.__SetWeaponPosition_FunctionParams* ptr = stackalloc BP_WindFieldInteraction_C.__SetWeaponPosition_FunctionParams[(UIntPtr)35] + 15L / (long)sizeof(BP_WindFieldInteraction_C.__SetWeaponPosition_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WindFieldInteraction_C.__SetWeaponPosition_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Position = Position;
			ptr->Type = Type;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WindFieldInteraction_C.__SetWeaponPosition_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06023D2D RID: 146733 RVA: 0x0098D241 File Offset: 0x0098B441
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void SetParam()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WindFieldInteraction_C.__SetParam_NativeFunctionPtr, null);
		}

		// Token: 0x06023D2E RID: 146734 RVA: 0x0098D258 File Offset: 0x0098B458
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void ForceFieldDara(BP_SceneBattleInteract_C config)
		{
			BP_WindFieldInteraction_C.__ForceFieldDara_FunctionParams* ptr = stackalloc BP_WindFieldInteraction_C.__ForceFieldDara_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(BP_WindFieldInteraction_C.__ForceFieldDara_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WindFieldInteraction_C.__ForceFieldDara_NativeFunctionPtr, (void*)ptr, 1);
			ptr->config = ((config != null) ? config.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WindFieldInteraction_C.__ForceFieldDara_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06023D2F RID: 146735 RVA: 0x0098D2AD File Offset: 0x0098B4AD
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateWeaponData()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WindFieldInteraction_C.__UpdateWeaponData_NativeFunctionPtr, null);
		}

		// Token: 0x06023D30 RID: 146736 RVA: 0x0098D2C4 File Offset: 0x0098B4C4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void UpdateParam(float dt)
		{
			BP_WindFieldInteraction_C.__UpdateParam_FunctionParams* ptr = stackalloc BP_WindFieldInteraction_C.__UpdateParam_FunctionParams[(UIntPtr)783] + 15L / (long)sizeof(BP_WindFieldInteraction_C.__UpdateParam_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WindFieldInteraction_C.__UpdateParam_NativeFunctionPtr, (void*)ptr, 1);
			ptr->dt = dt;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WindFieldInteraction_C.__UpdateParam_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06023D31 RID: 146737 RVA: 0x0098D30D File Offset: 0x0098B50D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WindFieldInteraction_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06023D32 RID: 146738 RVA: 0x0098D321 File Offset: 0x0098B521
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_WindFieldInteraction_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06023D33 RID: 146739 RVA: 0x0098D336 File Offset: 0x0098B536
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WindFieldInteraction_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06023D34 RID: 146740 RVA: 0x0098D34A File Offset: 0x0098B54A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_WindFieldInteraction_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06023D35 RID: 146741 RVA: 0x0098D360 File Offset: 0x0098B560
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_WindFieldInteraction_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_WindFieldInteraction_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_WindFieldInteraction_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WindFieldInteraction_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WindFieldInteraction_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06023D36 RID: 146742 RVA: 0x0098D3A8 File Offset: 0x0098B5A8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_WindFieldInteraction_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_WindFieldInteraction_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_WindFieldInteraction_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WindFieldInteraction_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_WindFieldInteraction_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06023D37 RID: 146743 RVA: 0x0098D3F0 File Offset: 0x0098B5F0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void OnWeaponInteraction(FVectorDouble OriginPoint, BP_SceneBattleInteract_C Config, int Id)
		{
			BP_WindFieldInteraction_C.__OnWeaponInteraction_FunctionParams* ptr = stackalloc BP_WindFieldInteraction_C.__OnWeaponInteraction_FunctionParams[(UIntPtr)55] + 15L / (long)sizeof(BP_WindFieldInteraction_C.__OnWeaponInteraction_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WindFieldInteraction_C.__OnWeaponInteraction_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OriginPoint = OriginPoint;
			ptr->Config = ((Config != null) ? Config.NativePtr : IntPtr.Zero);
			ptr->Id = Id;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WindFieldInteraction_C.__OnWeaponInteraction_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06023D38 RID: 146744 RVA: 0x0098D454 File Offset: 0x0098B654
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_WindFieldInteraction(int EntryPoint)
		{
			BP_WindFieldInteraction_C.__ExecuteUbergraph_BP_WindFieldInteraction_FunctionParams* ptr = stackalloc BP_WindFieldInteraction_C.__ExecuteUbergraph_BP_WindFieldInteraction_FunctionParams[(UIntPtr)287] + 15L / (long)sizeof(BP_WindFieldInteraction_C.__ExecuteUbergraph_BP_WindFieldInteraction_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WindFieldInteraction_C.__ExecuteUbergraph_BP_WindFieldInteraction_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_WindFieldInteraction_C.__ExecuteUbergraph_BP_WindFieldInteraction_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06023D39 RID: 146745 RVA: 0x0098D49E File Offset: 0x0098B69E
		protected BP_WindFieldInteraction_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04012493 RID: 74899
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/LeavesInteraction/BP_WindFieldInteraction.BP_WindFieldInteraction_C";

		// Token: 0x04012494 RID: 74900
		private static IntPtr _ClassPtr;

		// Token: 0x04012495 RID: 74901
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04012496 RID: 74902
		internal static int __PropertyOffset_0;

		// Token: 0x04012497 RID: 74903
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04012498 RID: 74904
		internal static int __PropertyOffset_1;

		// Token: 0x04012499 RID: 74905
		internal static int __PropertyOffset_2;

		// Token: 0x0401249A RID: 74906
		internal static int __PropertyOffset_3;

		// Token: 0x0401249B RID: 74907
		internal static int __PropertyOffset_4;

		// Token: 0x0401249C RID: 74908
		internal static int __PropertyOffset_5;

		// Token: 0x0401249D RID: 74909
		private static IntPtr __UpdateMotorcycleData_NativeFunctionPtr;

		// Token: 0x0401249E RID: 74910
		private static IntPtr __SetWeaponPosition_NativeFunctionPtr;

		// Token: 0x0401249F RID: 74911
		private static IntPtr __SetParam_NativeFunctionPtr;

		// Token: 0x040124A0 RID: 74912
		private static IntPtr __ForceFieldDara_NativeFunctionPtr;

		// Token: 0x040124A1 RID: 74913
		private static IntPtr __UpdateWeaponData_NativeFunctionPtr;

		// Token: 0x040124A2 RID: 74914
		private static IntPtr __UpdateParam_NativeFunctionPtr;

		// Token: 0x040124A3 RID: 74915
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x040124A4 RID: 74916
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x040124A5 RID: 74917
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x040124A6 RID: 74918
		private static IntPtr __OnWeaponInteraction_NativeFunctionPtr;

		// Token: 0x040124A7 RID: 74919
		private static IntPtr __ExecuteUbergraph_BP_WindFieldInteraction_NativeFunctionPtr;

		// Token: 0x02009D4A RID: 40266
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 20)]
		protected ref struct __SetWeaponPosition_FunctionParams
		{
			// Token: 0x0403272B RID: 206635
			[FieldOffset(0)]
			public FVector Position;

			// Token: 0x0403272C RID: 206636
			[FieldOffset(12)]
			public int Type;
		}

		// Token: 0x02009D4B RID: 40267
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __ForceFieldDara_FunctionParams
		{
			// Token: 0x0403272D RID: 206637
			[FieldOffset(0)]
			public IntPtr config;
		}

		// Token: 0x02009D4C RID: 40268
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 768)]
		protected ref struct __UpdateParam_FunctionParams
		{
			// Token: 0x0403272E RID: 206638
			[FieldOffset(0)]
			public float dt;
		}

		// Token: 0x02009D4D RID: 40269
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x0403272F RID: 206639
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009D4E RID: 40270
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 40)]
		protected ref struct __OnWeaponInteraction_FunctionParams
		{
			// Token: 0x04032730 RID: 206640
			[FieldOffset(0)]
			public FVectorDouble OriginPoint;

			// Token: 0x04032731 RID: 206641
			[FieldOffset(24)]
			public IntPtr Config;

			// Token: 0x04032732 RID: 206642
			[FieldOffset(32)]
			public int Id;
		}

		// Token: 0x02009D4F RID: 40271
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 272)]
		protected ref struct __ExecuteUbergraph_BP_WindFieldInteraction_FunctionParams
		{
			// Token: 0x04032733 RID: 206643
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
