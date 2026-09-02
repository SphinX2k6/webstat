using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Effect.BluePrint.BP_FX_Common;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common.Abilities.GC
{
	// Token: 0x02004074 RID: 16500
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Abilities/GC/GC_Control_Obj_Hand.GC_Control_Obj_Hand_C")]
	[UnrealStructLayout(1216, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1212)]
	public class GC_Control_Obj_Hand_C : AGameplayCueNotify_Actor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602ADF0 RID: 175600 RVA: 0x00A67FFC File Offset: 0x00A661FC
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GC_Control_Obj_Hand_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Abilities/GC/GC_Control_Obj_Hand.GC_Control_Obj_Hand_C");
			}
			return GC_Control_Obj_Hand_C._ClassPtr;
		}

		// Token: 0x0602ADF1 RID: 175601 RVA: 0x00A68020 File Offset: 0x00A66220
		public GC_Control_Obj_Hand_C() : this(BuiltinUtils.AllocNativeUObject(GC_Control_Obj_Hand_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602ADF2 RID: 175602 RVA: 0x00A68048 File Offset: 0x00A66248
		[NullableContext(1)]
		public GC_Control_Obj_Hand_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GC_Control_Obj_Hand_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700700A RID: 28682
		// (get) Token: 0x0602ADF3 RID: 175603 RVA: 0x00A6807C File Offset: 0x00A6627C
		// (set) Token: 0x0602ADF4 RID: 175604 RVA: 0x00A680B5 File Offset: 0x00A662B5
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GC_Control_Obj_Hand_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GC_Control_Obj_Hand_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700700B RID: 28683
		// (get) Token: 0x0602ADF5 RID: 175605 RVA: 0x00A680D6 File Offset: 0x00A662D6
		// (set) Token: 0x0602ADF6 RID: 175606 RVA: 0x00A680EA File Offset: 0x00A662EA
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + GC_Control_Obj_Hand_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GC_Control_Obj_Hand_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x1700700C RID: 28684
		// (get) Token: 0x0602ADF7 RID: 175607 RVA: 0x00A680FF File Offset: 0x00A662FF
		// (set) Token: 0x0602ADF8 RID: 175608 RVA: 0x00A68113 File Offset: 0x00A66313
		public unsafe EffectModelGroup 手部特效DA
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<EffectModelGroup>(base.NativePtr / (IntPtr)sizeof(void*) + GC_Control_Obj_Hand_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GC_Control_Obj_Hand_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x1700700D RID: 28685
		// (get) Token: 0x0602ADF9 RID: 175609 RVA: 0x00A68128 File Offset: 0x00A66328
		// (set) Token: 0x0602ADFA RID: 175610 RVA: 0x00A6813C File Offset: 0x00A6633C
		public unsafe TsBaseCharacter As_Ts_Base_Character
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<TsBaseCharacter>(base.NativePtr / (IntPtr)sizeof(void*) + GC_Control_Obj_Hand_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GC_Control_Obj_Hand_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x1700700E RID: 28686
		// (get) Token: 0x0602ADFB RID: 175611 RVA: 0x00A68151 File Offset: 0x00A66351
		// (set) Token: 0x0602ADFC RID: 175612 RVA: 0x00A68165 File Offset: 0x00A66365
		public unsafe BP_Fx_Control_Obj_C 连线特效
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_Fx_Control_Obj_C>(base.NativePtr / (IntPtr)sizeof(void*) + GC_Control_Obj_Hand_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GC_Control_Obj_Hand_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x1700700F RID: 28687
		// (get) Token: 0x0602ADFD RID: 175613 RVA: 0x00A6817A File Offset: 0x00A6637A
		// (set) Token: 0x0602ADFE RID: 175614 RVA: 0x00A6818E File Offset: 0x00A6638E
		public unsafe AActor Effect_Causer
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + GC_Control_Obj_Hand_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GC_Control_Obj_Hand_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x17007010 RID: 28688
		// (get) Token: 0x0602ADFF RID: 175615 RVA: 0x00A681A3 File Offset: 0x00A663A3
		// (set) Token: 0x0602AE00 RID: 175616 RVA: 0x00A681B7 File Offset: 0x00A663B7
		[Nullable(new byte[]
		{
			0,
			1
		})]
		public unsafe TSubclassOf<BP_Fx_Control_Obj_C> 连线特效BP
		{
			[return: Nullable(new byte[]
			{
				0,
				1
			})]
			get
			{
				return *(base.NativePtr + (IntPtr)GC_Control_Obj_Hand_C.__PropertyOffset_6);
			}
			[param: Nullable(new byte[]
			{
				0,
				1
			})]
			set
			{
				*(base.NativePtr + (IntPtr)GC_Control_Obj_Hand_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17007011 RID: 28689
		// (get) Token: 0x0602AE01 RID: 175617 RVA: 0x00A681CC File Offset: 0x00A663CC
		// (set) Token: 0x0602AE02 RID: 175618 RVA: 0x00A681E0 File Offset: 0x00A663E0
		public unsafe EffectModelGroup 物体控制中特效DA
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<EffectModelGroup>(base.NativePtr / (IntPtr)sizeof(void*) + GC_Control_Obj_Hand_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GC_Control_Obj_Hand_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x17007012 RID: 28690
		// (get) Token: 0x0602AE03 RID: 175619 RVA: 0x00A681F5 File Offset: 0x00A663F5
		// (set) Token: 0x0602AE04 RID: 175620 RVA: 0x00A68209 File Offset: 0x00A66409
		public unsafe EffectViewComponent 物体控制中特效handle
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<EffectViewComponent>(base.NativePtr / (IntPtr)sizeof(void*) + GC_Control_Obj_Hand_C.__PropertyOffset_8);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GC_Control_Obj_Hand_C.__PropertyOffset_8, value);
			}
		}

		// Token: 0x17007013 RID: 28691
		// (get) Token: 0x0602AE05 RID: 175621 RVA: 0x00A6821E File Offset: 0x00A6641E
		// (set) Token: 0x0602AE06 RID: 175622 RVA: 0x00A6822E File Offset: 0x00A6642E
		public unsafe int 手部特效句柄
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GC_Control_Obj_Hand_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GC_Control_Obj_Hand_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x0602AE07 RID: 175623 RVA: 0x00A6823F File Offset: 0x00A6643F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 生成手特效()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GC_Control_Obj_Hand_C.__生成手特效_NativeFunctionPtr, null);
		}

		// Token: 0x0602AE08 RID: 175624 RVA: 0x00A68254 File Offset: 0x00A66454
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override bool OnRemove(AActor MyTarget, in FGameplayCueParameters Parameters)
		{
			GC_Control_Obj_Hand_C.__OnRemove_FunctionParams* ptr = stackalloc GC_Control_Obj_Hand_C.__OnRemove_FunctionParams[(UIntPtr)223] + 15L / (long)sizeof(GC_Control_Obj_Hand_C.__OnRemove_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GC_Control_Obj_Hand_C.__OnRemove_NativeFunctionPtr, (void*)ptr, 1);
			ptr->MyTarget = ((MyTarget != null) ? MyTarget.NativePtr : IntPtr.Zero);
			if (Parameters != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FGameplayCueParameters.StaticStruct(), &ptr->Parameters, Parameters.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GC_Control_Obj_Hand_C.__OnRemove_NativeFunctionPtr, (void*)ptr);
			bool _Result = ptr->__Result;
			UnrealReflectionUtils.DestroyStruct(GC_Control_Obj_Hand_C.__OnRemove_NativeFunctionPtr, (void*)ptr, 1);
			return _Result;
		}

		// Token: 0x0602AE09 RID: 175625 RVA: 0x00A682E8 File Offset: 0x00A664E8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override bool OnRemove_Implementation(AActor MyTarget, in FGameplayCueParameters Parameters)
		{
			GC_Control_Obj_Hand_C.__OnRemove_FunctionParams* ptr = stackalloc GC_Control_Obj_Hand_C.__OnRemove_FunctionParams[(UIntPtr)223] + 15L / (long)sizeof(GC_Control_Obj_Hand_C.__OnRemove_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GC_Control_Obj_Hand_C.__OnRemove_NativeFunctionPtr, (void*)ptr, 1);
			ptr->MyTarget = ((MyTarget != null) ? MyTarget.NativePtr : IntPtr.Zero);
			if (Parameters != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FGameplayCueParameters.StaticStruct(), &ptr->Parameters, Parameters.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GC_Control_Obj_Hand_C.__OnRemove_NativeFunctionPtr, (void*)ptr, 0);
			bool _Result = ptr->__Result;
			UnrealReflectionUtils.DestroyStruct(GC_Control_Obj_Hand_C.__OnRemove_NativeFunctionPtr, (void*)ptr, 1);
			return _Result;
		}

		// Token: 0x0602AE0A RID: 175626 RVA: 0x00A6837C File Offset: 0x00A6657C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override bool OnActive(AActor MyTarget, in FGameplayCueParameters Parameters)
		{
			GC_Control_Obj_Hand_C.__OnActive_FunctionParams* ptr = stackalloc GC_Control_Obj_Hand_C.__OnActive_FunctionParams[(UIntPtr)527] + 15L / (long)sizeof(GC_Control_Obj_Hand_C.__OnActive_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GC_Control_Obj_Hand_C.__OnActive_NativeFunctionPtr, (void*)ptr, 1);
			ptr->MyTarget = ((MyTarget != null) ? MyTarget.NativePtr : IntPtr.Zero);
			if (Parameters != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FGameplayCueParameters.StaticStruct(), &ptr->Parameters, Parameters.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GC_Control_Obj_Hand_C.__OnActive_NativeFunctionPtr, (void*)ptr);
			bool _Result = ptr->__Result;
			UnrealReflectionUtils.DestroyStruct(GC_Control_Obj_Hand_C.__OnActive_NativeFunctionPtr, (void*)ptr, 1);
			return _Result;
		}

		// Token: 0x0602AE0B RID: 175627 RVA: 0x00A68410 File Offset: 0x00A66610
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override bool OnActive_Implementation(AActor MyTarget, in FGameplayCueParameters Parameters)
		{
			GC_Control_Obj_Hand_C.__OnActive_FunctionParams* ptr = stackalloc GC_Control_Obj_Hand_C.__OnActive_FunctionParams[(UIntPtr)527] + 15L / (long)sizeof(GC_Control_Obj_Hand_C.__OnActive_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GC_Control_Obj_Hand_C.__OnActive_NativeFunctionPtr, (void*)ptr, 1);
			ptr->MyTarget = ((MyTarget != null) ? MyTarget.NativePtr : IntPtr.Zero);
			if (Parameters != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FGameplayCueParameters.StaticStruct(), &ptr->Parameters, Parameters.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GC_Control_Obj_Hand_C.__OnActive_NativeFunctionPtr, (void*)ptr, 0);
			bool _Result = ptr->__Result;
			UnrealReflectionUtils.DestroyStruct(GC_Control_Obj_Hand_C.__OnActive_NativeFunctionPtr, (void*)ptr, 1);
			return _Result;
		}

		// Token: 0x0602AE0C RID: 175628 RVA: 0x00A684A4 File Offset: 0x00A666A4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			GC_Control_Obj_Hand_C.__ReceiveTick_FunctionParams* ptr = stackalloc GC_Control_Obj_Hand_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(GC_Control_Obj_Hand_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GC_Control_Obj_Hand_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GC_Control_Obj_Hand_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602AE0D RID: 175629 RVA: 0x00A684EC File Offset: 0x00A666EC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			GC_Control_Obj_Hand_C.__ReceiveTick_FunctionParams* ptr = stackalloc GC_Control_Obj_Hand_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(GC_Control_Obj_Hand_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GC_Control_Obj_Hand_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GC_Control_Obj_Hand_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602AE0E RID: 175630 RVA: 0x00A68534 File Offset: 0x00A66734
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GC_Control_Obj_Hand(int EntryPoint)
		{
			GC_Control_Obj_Hand_C.__ExecuteUbergraph_GC_Control_Obj_Hand_FunctionParams* ptr = stackalloc GC_Control_Obj_Hand_C.__ExecuteUbergraph_GC_Control_Obj_Hand_FunctionParams[(UIntPtr)63] + 15L / (long)sizeof(GC_Control_Obj_Hand_C.__ExecuteUbergraph_GC_Control_Obj_Hand_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GC_Control_Obj_Hand_C.__ExecuteUbergraph_GC_Control_Obj_Hand_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GC_Control_Obj_Hand_C.__ExecuteUbergraph_GC_Control_Obj_Hand_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602AE0F RID: 175631 RVA: 0x00A6857B File Offset: 0x00A6677B
		protected GC_Control_Obj_Hand_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04017695 RID: 95893
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Abilities/GC/GC_Control_Obj_Hand.GC_Control_Obj_Hand_C";

		// Token: 0x04017696 RID: 95894
		private static IntPtr _ClassPtr;

		// Token: 0x04017697 RID: 95895
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04017698 RID: 95896
		internal static int __PropertyOffset_0;

		// Token: 0x04017699 RID: 95897
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0401769A RID: 95898
		internal static int __PropertyOffset_1;

		// Token: 0x0401769B RID: 95899
		internal static int __PropertyOffset_2;

		// Token: 0x0401769C RID: 95900
		internal static int __PropertyOffset_3;

		// Token: 0x0401769D RID: 95901
		internal static int __PropertyOffset_4;

		// Token: 0x0401769E RID: 95902
		internal static int __PropertyOffset_5;

		// Token: 0x0401769F RID: 95903
		internal static int __PropertyOffset_6;

		// Token: 0x040176A0 RID: 95904
		internal static int __PropertyOffset_7;

		// Token: 0x040176A1 RID: 95905
		internal static int __PropertyOffset_8;

		// Token: 0x040176A2 RID: 95906
		internal static int __PropertyOffset_9;

		// Token: 0x040176A3 RID: 95907
		private static IntPtr __生成手特效_NativeFunctionPtr;

		// Token: 0x040176A4 RID: 95908
		private static IntPtr __OnRemove_NativeFunctionPtr;

		// Token: 0x040176A5 RID: 95909
		private static IntPtr __OnActive_NativeFunctionPtr;

		// Token: 0x040176A6 RID: 95910
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x040176A7 RID: 95911
		private static IntPtr __ExecuteUbergraph_GC_Control_Obj_Hand_NativeFunctionPtr;

		// Token: 0x0200A26C RID: 41580
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 208)]
		protected new ref struct __OnRemove_FunctionParams
		{
			// Token: 0x04033016 RID: 208918
			[FieldOffset(0)]
			public IntPtr MyTarget;

			// Token: 0x04033017 RID: 208919
			[FieldOffset(8)]
			public byte Parameters;

			// Token: 0x04033018 RID: 208920
			[FieldOffset(200)]
			public bool __Result;
		}

		// Token: 0x0200A26D RID: 41581
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 512)]
		protected new ref struct __OnActive_FunctionParams
		{
			// Token: 0x04033019 RID: 208921
			[FieldOffset(0)]
			public IntPtr MyTarget;

			// Token: 0x0403301A RID: 208922
			[FieldOffset(8)]
			public byte Parameters;

			// Token: 0x0403301B RID: 208923
			[FieldOffset(200)]
			public bool __Result;
		}

		// Token: 0x0200A26E RID: 41582
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x0403301C RID: 208924
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x0200A26F RID: 41583
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 48)]
		protected ref struct __ExecuteUbergraph_GC_Control_Obj_Hand_FunctionParams
		{
			// Token: 0x0403301D RID: 208925
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
