using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Interaction
{
	// Token: 0x02003C80 RID: 15488
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Interaction/BP_Harquebus.BP_Harquebus_C")]
	[UnrealStructLayout(1384, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1384)]
	public class BP_Harquebus_C : AKuroEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06024023 RID: 147491 RVA: 0x0099237C File Offset: 0x0099057C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_Harquebus_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Interaction/BP_Harquebus.BP_Harquebus_C");
			}
			return BP_Harquebus_C._ClassPtr;
		}

		// Token: 0x06024024 RID: 147492 RVA: 0x009923A0 File Offset: 0x009905A0
		public BP_Harquebus_C() : this(BuiltinUtils.AllocNativeUObject(BP_Harquebus_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06024025 RID: 147493 RVA: 0x009923C8 File Offset: 0x009905C8
		[NullableContext(1)]
		public BP_Harquebus_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_Harquebus_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700497E RID: 18814
		// (get) Token: 0x06024026 RID: 147494 RVA: 0x009923FC File Offset: 0x009905FC
		// (set) Token: 0x06024027 RID: 147495 RVA: 0x00992435 File Offset: 0x00990635
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_Harquebus_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_Harquebus_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700497F RID: 18815
		// (get) Token: 0x06024028 RID: 147496 RVA: 0x00992456 File Offset: 0x00990656
		// (set) Token: 0x06024029 RID: 147497 RVA: 0x0099246A File Offset: 0x0099066A
		public unsafe UNiagaraComponent Niagara
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Harquebus_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Harquebus_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17004980 RID: 18816
		// (get) Token: 0x0602402A RID: 147498 RVA: 0x0099247F File Offset: 0x0099067F
		// (set) Token: 0x0602402B RID: 147499 RVA: 0x00992493 File Offset: 0x00990693
		public unsafe URopeEffectComponent RopeEffect
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<URopeEffectComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Harquebus_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Harquebus_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17004981 RID: 18817
		// (get) Token: 0x0602402C RID: 147500 RVA: 0x009924A8 File Offset: 0x009906A8
		// (set) Token: 0x0602402D RID: 147501 RVA: 0x009924BC File Offset: 0x009906BC
		public unsafe URopeVerletComponent RopeVerlet
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<URopeVerletComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Harquebus_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Harquebus_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17004982 RID: 18818
		// (get) Token: 0x0602402E RID: 147502 RVA: 0x009924D1 File Offset: 0x009906D1
		// (set) Token: 0x0602402F RID: 147503 RVA: 0x009924E5 File Offset: 0x009906E5
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Harquebus_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Harquebus_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17004983 RID: 18819
		// (get) Token: 0x06024030 RID: 147504 RVA: 0x009924FA File Offset: 0x009906FA
		// (set) Token: 0x06024031 RID: 147505 RVA: 0x0099250E File Offset: 0x0099070E
		public unsafe URopeVerletDataAsset RopeStaticDA
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<URopeVerletDataAsset>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Harquebus_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Harquebus_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x17004984 RID: 18820
		// (get) Token: 0x06024032 RID: 147506 RVA: 0x00992523 File Offset: 0x00990723
		// (set) Token: 0x06024033 RID: 147507 RVA: 0x00992537 File Offset: 0x00990737
		public unsafe URopeVerletDataAsset RopeDynamicDA
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<URopeVerletDataAsset>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Harquebus_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Harquebus_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x17004985 RID: 18821
		// (get) Token: 0x06024034 RID: 147508 RVA: 0x0099254C File Offset: 0x0099074C
		// (set) Token: 0x06024035 RID: 147509 RVA: 0x00992560 File Offset: 0x00990760
		public unsafe URopeVerletDataAsset LocalRopeDA
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<URopeVerletDataAsset>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Harquebus_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Harquebus_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x17004986 RID: 18822
		// (get) Token: 0x06024036 RID: 147510 RVA: 0x00992575 File Offset: 0x00990775
		// (set) Token: 0x06024037 RID: 147511 RVA: 0x00992589 File Offset: 0x00990789
		public unsafe UEffectModelNiagara NiagaraDA
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UEffectModelNiagara>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Harquebus_C.__PropertyOffset_8);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Harquebus_C.__PropertyOffset_8, value);
			}
		}

		// Token: 0x06024038 RID: 147512 RVA: 0x0099259E File Offset: 0x0099079E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 设置特效DA()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Harquebus_C.__设置特效DA_NativeFunctionPtr, null);
		}

		// Token: 0x06024039 RID: 147513 RVA: 0x009925B2 File Offset: 0x009907B2
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 设置空放DA()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Harquebus_C.__设置空放DA_NativeFunctionPtr, null);
		}

		// Token: 0x0602403A RID: 147514 RVA: 0x009925C6 File Offset: 0x009907C6
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 设置战斗DA()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Harquebus_C.__设置战斗DA_NativeFunctionPtr, null);
		}

		// Token: 0x0602403B RID: 147515 RVA: 0x009925DA File Offset: 0x009907DA
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Harquebus_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x0602403C RID: 147516 RVA: 0x009925EE File Offset: 0x009907EE
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Harquebus_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602403D RID: 147517 RVA: 0x00992604 File Offset: 0x00990804
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_Harquebus_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_Harquebus_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Harquebus_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Harquebus_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Harquebus_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602403E RID: 147518 RVA: 0x0099264C File Offset: 0x0099084C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_Harquebus_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_Harquebus_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Harquebus_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Harquebus_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Harquebus_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602403F RID: 147519 RVA: 0x00992694 File Offset: 0x00990894
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_Harquebus_C.__EditorTick_FunctionParams* ptr = stackalloc BP_Harquebus_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Harquebus_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Harquebus_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Harquebus_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024040 RID: 147520 RVA: 0x009926DC File Offset: 0x009908DC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_Harquebus_C.__EditorTick_FunctionParams* ptr = stackalloc BP_Harquebus_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Harquebus_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Harquebus_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Harquebus_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06024041 RID: 147521 RVA: 0x00992723 File Offset: 0x00990923
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Harquebus_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06024042 RID: 147522 RVA: 0x00992737 File Offset: 0x00990937
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Harquebus_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06024043 RID: 147523 RVA: 0x0099274C File Offset: 0x0099094C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_Harquebus(int EntryPoint)
		{
			BP_Harquebus_C.__ExecuteUbergraph_BP_Harquebus_FunctionParams* ptr = stackalloc BP_Harquebus_C.__ExecuteUbergraph_BP_Harquebus_FunctionParams[(UIntPtr)63] + 15L / (long)sizeof(BP_Harquebus_C.__ExecuteUbergraph_BP_Harquebus_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Harquebus_C.__ExecuteUbergraph_BP_Harquebus_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Harquebus_C.__ExecuteUbergraph_BP_Harquebus_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06024044 RID: 147524 RVA: 0x00992793 File Offset: 0x00990993
		protected BP_Harquebus_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04012672 RID: 75378
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Interaction/BP_Harquebus.BP_Harquebus_C";

		// Token: 0x04012673 RID: 75379
		private static IntPtr _ClassPtr;

		// Token: 0x04012674 RID: 75380
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04012675 RID: 75381
		internal static int __PropertyOffset_0;

		// Token: 0x04012676 RID: 75382
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04012677 RID: 75383
		internal static int __PropertyOffset_1;

		// Token: 0x04012678 RID: 75384
		internal static int __PropertyOffset_2;

		// Token: 0x04012679 RID: 75385
		internal static int __PropertyOffset_3;

		// Token: 0x0401267A RID: 75386
		internal static int __PropertyOffset_4;

		// Token: 0x0401267B RID: 75387
		internal static int __PropertyOffset_5;

		// Token: 0x0401267C RID: 75388
		internal static int __PropertyOffset_6;

		// Token: 0x0401267D RID: 75389
		internal static int __PropertyOffset_7;

		// Token: 0x0401267E RID: 75390
		internal static int __PropertyOffset_8;

		// Token: 0x0401267F RID: 75391
		private static IntPtr __设置特效DA_NativeFunctionPtr;

		// Token: 0x04012680 RID: 75392
		private static IntPtr __设置空放DA_NativeFunctionPtr;

		// Token: 0x04012681 RID: 75393
		private static IntPtr __设置战斗DA_NativeFunctionPtr;

		// Token: 0x04012682 RID: 75394
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04012683 RID: 75395
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04012684 RID: 75396
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x04012685 RID: 75397
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04012686 RID: 75398
		private static IntPtr __ExecuteUbergraph_BP_Harquebus_NativeFunctionPtr;

		// Token: 0x02009D79 RID: 40313
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x0403276E RID: 206702
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009D7A RID: 40314
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x0403276F RID: 206703
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009D7B RID: 40315
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 48)]
		protected ref struct __ExecuteUbergraph_BP_Harquebus_FunctionParams
		{
			// Token: 0x04032770 RID: 206704
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
