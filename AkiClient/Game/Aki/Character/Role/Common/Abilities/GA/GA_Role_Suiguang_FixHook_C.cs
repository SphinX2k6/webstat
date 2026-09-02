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
	// Token: 0x020040B7 RID: 16567
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Abilities/GA/GA_Role_Suiguang_FixHook.GA_Role_Suiguang_FixHook_C")]
	[UnrealStructLayout(1592, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1592)]
	public class GA_Role_Suiguang_FixHook_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602B42E RID: 177198 RVA: 0x00A75BAB File Offset: 0x00A73DAB
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_Role_Suiguang_FixHook_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Role_Suiguang_FixHook.GA_Role_Suiguang_FixHook_C");
			}
			return GA_Role_Suiguang_FixHook_C._ClassPtr;
		}

		// Token: 0x0602B42F RID: 177199 RVA: 0x00A75BD0 File Offset: 0x00A73DD0
		public GA_Role_Suiguang_FixHook_C() : this(BuiltinUtils.AllocNativeUObject(GA_Role_Suiguang_FixHook_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602B430 RID: 177200 RVA: 0x00A75BF8 File Offset: 0x00A73DF8
		[NullableContext(1)]
		public GA_Role_Suiguang_FixHook_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_Role_Suiguang_FixHook_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700714C RID: 29004
		// (get) Token: 0x0602B431 RID: 177201 RVA: 0x00A75C2C File Offset: 0x00A73E2C
		// (set) Token: 0x0602B432 RID: 177202 RVA: 0x00A75C65 File Offset: 0x00A73E65
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_Role_Suiguang_FixHook_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_Role_Suiguang_FixHook_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700714D RID: 29005
		// (get) Token: 0x0602B433 RID: 177203 RVA: 0x00A75C86 File Offset: 0x00A73E86
		// (set) Token: 0x0602B434 RID: 177204 RVA: 0x00A75C9A File Offset: 0x00A73E9A
		public unsafe TsBaseCharacter 施法者_0
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<TsBaseCharacter>(base.NativePtr / (IntPtr)sizeof(void*) + GA_Role_Suiguang_FixHook_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GA_Role_Suiguang_FixHook_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x1700714E RID: 29006
		// (get) Token: 0x0602B435 RID: 177205 RVA: 0x00A75CAF File Offset: 0x00A73EAF
		// (set) Token: 0x0602B436 RID: 177206 RVA: 0x00A75CC3 File Offset: 0x00A73EC3
		public unsafe FVectorDouble FixHookLocation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Role_Suiguang_FixHook_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Role_Suiguang_FixHook_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x1700714F RID: 29007
		// (get) Token: 0x0602B437 RID: 177207 RVA: 0x00A75CD8 File Offset: 0x00A73ED8
		// (set) Token: 0x0602B438 RID: 177208 RVA: 0x00A75CEC File Offset: 0x00A73EEC
		public unsafe FVector 牵引速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Role_Suiguang_FixHook_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Role_Suiguang_FixHook_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17007150 RID: 29008
		// (get) Token: 0x0602B439 RID: 177209 RVA: 0x00A75D01 File Offset: 0x00A73F01
		// (set) Token: 0x0602B43A RID: 177210 RVA: 0x00A75D11 File Offset: 0x00A73F11
		public unsafe float BlockTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Role_Suiguang_FixHook_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Role_Suiguang_FixHook_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17007151 RID: 29009
		// (get) Token: 0x0602B43B RID: 177211 RVA: 0x00A75D22 File Offset: 0x00A73F22
		// (set) Token: 0x0602B43C RID: 177212 RVA: 0x00A75D32 File Offset: 0x00A73F32
		public unsafe float 角色胶囊体半高
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Role_Suiguang_FixHook_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Role_Suiguang_FixHook_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17007152 RID: 29010
		// (get) Token: 0x0602B43D RID: 177213 RVA: 0x00A75D43 File Offset: 0x00A73F43
		// (set) Token: 0x0602B43E RID: 177214 RVA: 0x00A75D57 File Offset: 0x00A73F57
		public unsafe FVector LastDirect
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Role_Suiguang_FixHook_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Role_Suiguang_FixHook_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17007153 RID: 29011
		// (get) Token: 0x0602B43F RID: 177215 RVA: 0x00A75D6C File Offset: 0x00A73F6C
		// (set) Token: 0x0602B440 RID: 177216 RVA: 0x00A75D7C File Offset: 0x00A73F7C
		public unsafe bool IsSuiGuangType
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Role_Suiguang_FixHook_C.__PropertyOffset_7) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Role_Suiguang_FixHook_C.__PropertyOffset_7) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007154 RID: 29012
		// (get) Token: 0x0602B441 RID: 177217 RVA: 0x00A75D8D File Offset: 0x00A73F8D
		// (set) Token: 0x0602B442 RID: 177218 RVA: 0x00A75DA1 File Offset: 0x00A73FA1
		public unsafe AActor FixHookActor
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + GA_Role_Suiguang_FixHook_C.__PropertyOffset_8);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GA_Role_Suiguang_FixHook_C.__PropertyOffset_8, value);
			}
		}

		// Token: 0x17007155 RID: 29013
		// (get) Token: 0x0602B443 RID: 177219 RVA: 0x00A75DB6 File Offset: 0x00A73FB6
		// (set) Token: 0x0602B444 RID: 177220 RVA: 0x00A75DCA File Offset: 0x00A73FCA
		public unsafe FVectorDouble FixHookLocation_NUpdate
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Role_Suiguang_FixHook_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Role_Suiguang_FixHook_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x0602B445 RID: 177221 RVA: 0x00A75DDF File Offset: 0x00A73FDF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void RefreshFixHookLocation()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_Suiguang_FixHook_C.__RefreshFixHookLocation_NativeFunctionPtr, null);
		}

		// Token: 0x0602B446 RID: 177222 RVA: 0x00A75DF3 File Offset: 0x00A73FF3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 是否继承速度()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_Suiguang_FixHook_C.__是否继承速度_NativeFunctionPtr, null);
		}

		// Token: 0x0602B447 RID: 177223 RVA: 0x00A75E07 File Offset: 0x00A74007
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void FixHookTick()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_Suiguang_FixHook_C.__FixHookTick_NativeFunctionPtr, null);
		}

		// Token: 0x0602B448 RID: 177224 RVA: 0x00A75E1B File Offset: 0x00A7401B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void FixHookStart()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_Suiguang_FixHook_C.__FixHookStart_NativeFunctionPtr, null);
		}

		// Token: 0x0602B449 RID: 177225 RVA: 0x00A75E2F File Offset: 0x00A7402F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnFinish_AD5ADDBF47997B989A9016A78CAC22E7()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_Suiguang_FixHook_C.__OnFinish_AD5ADDBF47997B989A9016A78CAC22E7_NativeFunctionPtr, null);
		}

		// Token: 0x0602B44A RID: 177226 RVA: 0x00A75E43 File Offset: 0x00A74043
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnTick_AD5ADDBF47997B989A9016A78CAC22E7()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_Suiguang_FixHook_C.__OnTick_AD5ADDBF47997B989A9016A78CAC22E7_NativeFunctionPtr, null);
		}

		// Token: 0x0602B44B RID: 177227 RVA: 0x00A75E58 File Offset: 0x00A74058
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void MovementModeChange(ACharacter Character, EMovementMode PrevMovementMode, byte PreviousCustomMode)
		{
			GA_Role_Suiguang_FixHook_C.__MovementModeChange_FunctionParams* ptr = stackalloc GA_Role_Suiguang_FixHook_C.__MovementModeChange_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(GA_Role_Suiguang_FixHook_C.__MovementModeChange_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Role_Suiguang_FixHook_C.__MovementModeChange_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Character = ((Character != null) ? Character.NativePtr : IntPtr.Zero);
			ptr->PrevMovementMode = PrevMovementMode;
			ptr->PreviousCustomMode = PreviousCustomMode;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_Suiguang_FixHook_C.__MovementModeChange_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B44C RID: 177228 RVA: 0x00A75EC0 File Offset: 0x00A740C0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void K2_OnEndAbility(bool bWasCancelled)
		{
			GA_Role_Suiguang_FixHook_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Role_Suiguang_FixHook_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Role_Suiguang_FixHook_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Role_Suiguang_FixHook_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_Suiguang_FixHook_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B44D RID: 177229 RVA: 0x00A75F08 File Offset: 0x00A74108
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void K2_OnEndAbility_Implementation(bool bWasCancelled)
		{
			GA_Role_Suiguang_FixHook_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Role_Suiguang_FixHook_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Role_Suiguang_FixHook_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Role_Suiguang_FixHook_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Role_Suiguang_FixHook_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602B44E RID: 177230 RVA: 0x00A75F4F File Offset: 0x00A7414F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_Suiguang_FixHook_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x0602B44F RID: 177231 RVA: 0x00A75F63 File Offset: 0x00A74163
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Role_Suiguang_FixHook_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602B450 RID: 177232 RVA: 0x00A75F78 File Offset: 0x00A74178
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_Role_Suiguang_FixHook(int EntryPoint)
		{
			GA_Role_Suiguang_FixHook_C.__ExecuteUbergraph_GA_Role_Suiguang_FixHook_FunctionParams* ptr = stackalloc GA_Role_Suiguang_FixHook_C.__ExecuteUbergraph_GA_Role_Suiguang_FixHook_FunctionParams[(UIntPtr)335] + 15L / (long)sizeof(GA_Role_Suiguang_FixHook_C.__ExecuteUbergraph_GA_Role_Suiguang_FixHook_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Role_Suiguang_FixHook_C.__ExecuteUbergraph_GA_Role_Suiguang_FixHook_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Role_Suiguang_FixHook_C.__ExecuteUbergraph_GA_Role_Suiguang_FixHook_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602B451 RID: 177233 RVA: 0x00A75FC2 File Offset: 0x00A741C2
		protected GA_Role_Suiguang_FixHook_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04017B26 RID: 97062
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Role_Suiguang_FixHook.GA_Role_Suiguang_FixHook_C";

		// Token: 0x04017B27 RID: 97063
		private static IntPtr _ClassPtr;

		// Token: 0x04017B28 RID: 97064
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04017B29 RID: 97065
		internal new static int __PropertyOffset_0;

		// Token: 0x04017B2A RID: 97066
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04017B2B RID: 97067
		internal new static int __PropertyOffset_1;

		// Token: 0x04017B2C RID: 97068
		internal new static int __PropertyOffset_2;

		// Token: 0x04017B2D RID: 97069
		internal new static int __PropertyOffset_3;

		// Token: 0x04017B2E RID: 97070
		internal static int __PropertyOffset_4;

		// Token: 0x04017B2F RID: 97071
		internal static int __PropertyOffset_5;

		// Token: 0x04017B30 RID: 97072
		internal static int __PropertyOffset_6;

		// Token: 0x04017B31 RID: 97073
		internal static int __PropertyOffset_7;

		// Token: 0x04017B32 RID: 97074
		internal static int __PropertyOffset_8;

		// Token: 0x04017B33 RID: 97075
		internal static int __PropertyOffset_9;

		// Token: 0x04017B34 RID: 97076
		private static IntPtr __RefreshFixHookLocation_NativeFunctionPtr;

		// Token: 0x04017B35 RID: 97077
		private static IntPtr __是否继承速度_NativeFunctionPtr;

		// Token: 0x04017B36 RID: 97078
		private static IntPtr __FixHookTick_NativeFunctionPtr;

		// Token: 0x04017B37 RID: 97079
		private static IntPtr __FixHookStart_NativeFunctionPtr;

		// Token: 0x04017B38 RID: 97080
		private static IntPtr __OnFinish_AD5ADDBF47997B989A9016A78CAC22E7_NativeFunctionPtr;

		// Token: 0x04017B39 RID: 97081
		private static IntPtr __OnTick_AD5ADDBF47997B989A9016A78CAC22E7_NativeFunctionPtr;

		// Token: 0x04017B3A RID: 97082
		private static IntPtr __MovementModeChange_NativeFunctionPtr;

		// Token: 0x04017B3B RID: 97083
		private static IntPtr __K2_OnEndAbility_NativeFunctionPtr;

		// Token: 0x04017B3C RID: 97084
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x04017B3D RID: 97085
		private static IntPtr __ExecuteUbergraph_GA_Role_Suiguang_FixHook_NativeFunctionPtr;

		// Token: 0x0200A33A RID: 41786
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __MovementModeChange_FunctionParams
		{
			// Token: 0x04033115 RID: 209173
			[FieldOffset(0)]
			public IntPtr Character;

			// Token: 0x04033116 RID: 209174
			[FieldOffset(8)]
			public TEnumAsByte<EMovementMode> PrevMovementMode;

			// Token: 0x04033117 RID: 209175
			[FieldOffset(9)]
			public byte PreviousCustomMode;
		}

		// Token: 0x0200A33B RID: 41787
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __K2_OnEndAbility_FunctionParams
		{
			// Token: 0x04033118 RID: 209176
			[FieldOffset(0)]
			public bool bWasCancelled;
		}

		// Token: 0x0200A33C RID: 41788
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 320)]
		protected ref struct __ExecuteUbergraph_GA_Role_Suiguang_FixHook_FunctionParams
		{
			// Token: 0x04033119 RID: 209177
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
