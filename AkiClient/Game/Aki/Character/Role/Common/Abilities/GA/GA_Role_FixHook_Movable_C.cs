using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Character.BaseCharacter.Abilities.GA;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common.Abilities.GA
{
	// Token: 0x020040A7 RID: 16551
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Abilities/GA/GA_Role_FixHook_Movable.GA_Role_FixHook_Movable_C")]
	[UnrealStructLayout(1608, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1608)]
	public class GA_Role_FixHook_Movable_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602B234 RID: 176692 RVA: 0x00A71647 File Offset: 0x00A6F847
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_Role_FixHook_Movable_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Role_FixHook_Movable.GA_Role_FixHook_Movable_C");
			}
			return GA_Role_FixHook_Movable_C._ClassPtr;
		}

		// Token: 0x0602B235 RID: 176693 RVA: 0x00A7166C File Offset: 0x00A6F86C
		public GA_Role_FixHook_Movable_C() : this(BuiltinUtils.AllocNativeUObject(GA_Role_FixHook_Movable_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602B236 RID: 176694 RVA: 0x00A71694 File Offset: 0x00A6F894
		[NullableContext(1)]
		public GA_Role_FixHook_Movable_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_Role_FixHook_Movable_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170070E6 RID: 28902
		// (get) Token: 0x0602B237 RID: 176695 RVA: 0x00A716C8 File Offset: 0x00A6F8C8
		// (set) Token: 0x0602B238 RID: 176696 RVA: 0x00A71701 File Offset: 0x00A6F901
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_Role_FixHook_Movable_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_Role_FixHook_Movable_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170070E7 RID: 28903
		// (get) Token: 0x0602B239 RID: 176697 RVA: 0x00A71722 File Offset: 0x00A6F922
		// (set) Token: 0x0602B23A RID: 176698 RVA: 0x00A71736 File Offset: 0x00A6F936
		public unsafe TsBaseCharacter 施法者_0
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<TsBaseCharacter>(base.NativePtr / (IntPtr)sizeof(void*) + GA_Role_FixHook_Movable_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GA_Role_FixHook_Movable_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170070E8 RID: 28904
		// (get) Token: 0x0602B23B RID: 176699 RVA: 0x00A7174B File Offset: 0x00A6F94B
		// (set) Token: 0x0602B23C RID: 176700 RVA: 0x00A7175F File Offset: 0x00A6F95F
		public unsafe FVectorDouble FixHookLocation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Role_FixHook_Movable_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Role_FixHook_Movable_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x170070E9 RID: 28905
		// (get) Token: 0x0602B23D RID: 176701 RVA: 0x00A71774 File Offset: 0x00A6F974
		// (set) Token: 0x0602B23E RID: 176702 RVA: 0x00A71788 File Offset: 0x00A6F988
		public unsafe FVectorDouble 牵引速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Role_FixHook_Movable_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Role_FixHook_Movable_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x170070EA RID: 28906
		// (get) Token: 0x0602B23F RID: 176703 RVA: 0x00A7179D File Offset: 0x00A6F99D
		// (set) Token: 0x0602B240 RID: 176704 RVA: 0x00A717AD File Offset: 0x00A6F9AD
		public unsafe float BlockTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Role_FixHook_Movable_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Role_FixHook_Movable_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x170070EB RID: 28907
		// (get) Token: 0x0602B241 RID: 176705 RVA: 0x00A717BE File Offset: 0x00A6F9BE
		// (set) Token: 0x0602B242 RID: 176706 RVA: 0x00A717CE File Offset: 0x00A6F9CE
		public unsafe float 角色胶囊体半高
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Role_FixHook_Movable_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Role_FixHook_Movable_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x170070EC RID: 28908
		// (get) Token: 0x0602B243 RID: 176707 RVA: 0x00A717DF File Offset: 0x00A6F9DF
		// (set) Token: 0x0602B244 RID: 176708 RVA: 0x00A717F3 File Offset: 0x00A6F9F3
		public unsafe FVectorDouble LastDirect
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Role_FixHook_Movable_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Role_FixHook_Movable_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x170070ED RID: 28909
		// (get) Token: 0x0602B245 RID: 176709 RVA: 0x00A71808 File Offset: 0x00A6FA08
		// (set) Token: 0x0602B246 RID: 176710 RVA: 0x00A7181C File Offset: 0x00A6FA1C
		public unsafe AActor FixHookActor
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + GA_Role_FixHook_Movable_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GA_Role_FixHook_Movable_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x170070EE RID: 28910
		// (get) Token: 0x0602B247 RID: 176711 RVA: 0x00A71831 File Offset: 0x00A6FA31
		// (set) Token: 0x0602B248 RID: 176712 RVA: 0x00A71845 File Offset: 0x00A6FA45
		public unsafe FVectorDouble FixHookLocation_NUpdate
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Role_FixHook_Movable_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Role_FixHook_Movable_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x0602B249 RID: 176713 RVA: 0x00A7185A File Offset: 0x00A6FA5A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void RefreshFixHookLocation()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_FixHook_Movable_C.__RefreshFixHookLocation_NativeFunctionPtr, null);
		}

		// Token: 0x0602B24A RID: 176714 RVA: 0x00A7186E File Offset: 0x00A6FA6E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 是否继承速度()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_FixHook_Movable_C.__是否继承速度_NativeFunctionPtr, null);
		}

		// Token: 0x0602B24B RID: 176715 RVA: 0x00A71882 File Offset: 0x00A6FA82
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void FixHookTick()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_FixHook_Movable_C.__FixHookTick_NativeFunctionPtr, null);
		}

		// Token: 0x0602B24C RID: 176716 RVA: 0x00A71896 File Offset: 0x00A6FA96
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void FixHookStart()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_FixHook_Movable_C.__FixHookStart_NativeFunctionPtr, null);
		}

		// Token: 0x0602B24D RID: 176717 RVA: 0x00A718AA File Offset: 0x00A6FAAA
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnFinish_1F93562B4ABB3E70057EE3B61762403F()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_FixHook_Movable_C.__OnFinish_1F93562B4ABB3E70057EE3B61762403F_NativeFunctionPtr, null);
		}

		// Token: 0x0602B24E RID: 176718 RVA: 0x00A718BE File Offset: 0x00A6FABE
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnTick_1F93562B4ABB3E70057EE3B61762403F()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_FixHook_Movable_C.__OnTick_1F93562B4ABB3E70057EE3B61762403F_NativeFunctionPtr, null);
		}

		// Token: 0x0602B24F RID: 176719 RVA: 0x00A718D4 File Offset: 0x00A6FAD4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void MovementModeChange(ACharacter Character, EMovementMode PrevMovementMode, byte PreviousCustomMode)
		{
			GA_Role_FixHook_Movable_C.__MovementModeChange_FunctionParams* ptr = stackalloc GA_Role_FixHook_Movable_C.__MovementModeChange_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(GA_Role_FixHook_Movable_C.__MovementModeChange_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Role_FixHook_Movable_C.__MovementModeChange_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Character = ((Character != null) ? Character.NativePtr : IntPtr.Zero);
			ptr->PrevMovementMode = PrevMovementMode;
			ptr->PreviousCustomMode = PreviousCustomMode;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_FixHook_Movable_C.__MovementModeChange_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B250 RID: 176720 RVA: 0x00A7193C File Offset: 0x00A6FB3C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void K2_OnEndAbility(bool bWasCancelled)
		{
			GA_Role_FixHook_Movable_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Role_FixHook_Movable_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Role_FixHook_Movable_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Role_FixHook_Movable_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_FixHook_Movable_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B251 RID: 176721 RVA: 0x00A71984 File Offset: 0x00A6FB84
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void K2_OnEndAbility_Implementation(bool bWasCancelled)
		{
			GA_Role_FixHook_Movable_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Role_FixHook_Movable_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Role_FixHook_Movable_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Role_FixHook_Movable_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Role_FixHook_Movable_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602B252 RID: 176722 RVA: 0x00A719CB File Offset: 0x00A6FBCB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_FixHook_Movable_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x0602B253 RID: 176723 RVA: 0x00A719DF File Offset: 0x00A6FBDF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Role_FixHook_Movable_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602B254 RID: 176724 RVA: 0x00A719F4 File Offset: 0x00A6FBF4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_Role_FixHook_Movable(int EntryPoint)
		{
			GA_Role_FixHook_Movable_C.__ExecuteUbergraph_GA_Role_FixHook_Movable_FunctionParams* ptr = stackalloc GA_Role_FixHook_Movable_C.__ExecuteUbergraph_GA_Role_FixHook_Movable_FunctionParams[(UIntPtr)311] + 15L / (long)sizeof(GA_Role_FixHook_Movable_C.__ExecuteUbergraph_GA_Role_FixHook_Movable_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Role_FixHook_Movable_C.__ExecuteUbergraph_GA_Role_FixHook_Movable_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Role_FixHook_Movable_C.__ExecuteUbergraph_GA_Role_FixHook_Movable_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602B255 RID: 176725 RVA: 0x00A71A3E File Offset: 0x00A6FC3E
		protected GA_Role_FixHook_Movable_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040179B4 RID: 96692
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Role_FixHook_Movable.GA_Role_FixHook_Movable_C";

		// Token: 0x040179B5 RID: 96693
		private static IntPtr _ClassPtr;

		// Token: 0x040179B6 RID: 96694
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040179B7 RID: 96695
		internal new static int __PropertyOffset_0;

		// Token: 0x040179B8 RID: 96696
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040179B9 RID: 96697
		internal new static int __PropertyOffset_1;

		// Token: 0x040179BA RID: 96698
		internal new static int __PropertyOffset_2;

		// Token: 0x040179BB RID: 96699
		internal new static int __PropertyOffset_3;

		// Token: 0x040179BC RID: 96700
		internal static int __PropertyOffset_4;

		// Token: 0x040179BD RID: 96701
		internal static int __PropertyOffset_5;

		// Token: 0x040179BE RID: 96702
		internal static int __PropertyOffset_6;

		// Token: 0x040179BF RID: 96703
		internal static int __PropertyOffset_7;

		// Token: 0x040179C0 RID: 96704
		internal static int __PropertyOffset_8;

		// Token: 0x040179C1 RID: 96705
		private static IntPtr __RefreshFixHookLocation_NativeFunctionPtr;

		// Token: 0x040179C2 RID: 96706
		private static IntPtr __是否继承速度_NativeFunctionPtr;

		// Token: 0x040179C3 RID: 96707
		private static IntPtr __FixHookTick_NativeFunctionPtr;

		// Token: 0x040179C4 RID: 96708
		private static IntPtr __FixHookStart_NativeFunctionPtr;

		// Token: 0x040179C5 RID: 96709
		private static IntPtr __OnFinish_1F93562B4ABB3E70057EE3B61762403F_NativeFunctionPtr;

		// Token: 0x040179C6 RID: 96710
		private static IntPtr __OnTick_1F93562B4ABB3E70057EE3B61762403F_NativeFunctionPtr;

		// Token: 0x040179C7 RID: 96711
		private static IntPtr __MovementModeChange_NativeFunctionPtr;

		// Token: 0x040179C8 RID: 96712
		private static IntPtr __K2_OnEndAbility_NativeFunctionPtr;

		// Token: 0x040179C9 RID: 96713
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x040179CA RID: 96714
		private static IntPtr __ExecuteUbergraph_GA_Role_FixHook_Movable_NativeFunctionPtr;

		// Token: 0x0200A2FB RID: 41723
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __MovementModeChange_FunctionParams
		{
			// Token: 0x040330C4 RID: 209092
			[FieldOffset(0)]
			public IntPtr Character;

			// Token: 0x040330C5 RID: 209093
			[FieldOffset(8)]
			public TEnumAsByte<EMovementMode> PrevMovementMode;

			// Token: 0x040330C6 RID: 209094
			[FieldOffset(9)]
			public byte PreviousCustomMode;
		}

		// Token: 0x0200A2FC RID: 41724
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __K2_OnEndAbility_FunctionParams
		{
			// Token: 0x040330C7 RID: 209095
			[FieldOffset(0)]
			public bool bWasCancelled;
		}

		// Token: 0x0200A2FD RID: 41725
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 296)]
		protected ref struct __ExecuteUbergraph_GA_Role_FixHook_Movable_FunctionParams
		{
			// Token: 0x040330C8 RID: 209096
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
