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
	// Token: 0x020040BB RID: 16571
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Abilities/GA/GA_summonShouAnRen.GA_summonShouAnRen_C")]
	[UnrealStructLayout(1648, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1648)]
	public class GA_summonShouAnRen_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602B47D RID: 177277 RVA: 0x00A76593 File Offset: 0x00A74793
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_summonShouAnRen_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Abilities/GA/GA_summonShouAnRen.GA_summonShouAnRen_C");
			}
			return GA_summonShouAnRen_C._ClassPtr;
		}

		// Token: 0x0602B47E RID: 177278 RVA: 0x00A765B8 File Offset: 0x00A747B8
		public GA_summonShouAnRen_C() : this(BuiltinUtils.AllocNativeUObject(GA_summonShouAnRen_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602B47F RID: 177279 RVA: 0x00A765E0 File Offset: 0x00A747E0
		public GA_summonShouAnRen_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_summonShouAnRen_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700715F RID: 29023
		// (get) Token: 0x0602B480 RID: 177280 RVA: 0x00A76614 File Offset: 0x00A74814
		// (set) Token: 0x0602B481 RID: 177281 RVA: 0x00A7664D File Offset: 0x00A7484D
		public new FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_summonShouAnRen_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_summonShouAnRen_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007160 RID: 29024
		// (get) Token: 0x0602B482 RID: 177282 RVA: 0x00A7666E File Offset: 0x00A7486E
		// (set) Token: 0x0602B483 RID: 177283 RVA: 0x00A7667E File Offset: 0x00A7487E
		public unsafe float 原来质量
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_summonShouAnRen_C.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_summonShouAnRen_C.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17007161 RID: 29025
		// (get) Token: 0x0602B484 RID: 177284 RVA: 0x00A76690 File Offset: 0x00A74890
		// (set) Token: 0x0602B485 RID: 177285 RVA: 0x00A766C9 File Offset: 0x00A748C9
		public TMap<int, bool> NewVar_0
		{
			get
			{
				base.FastCheckIsValid();
				TMap<int, bool> result;
				if ((result = this._NewVar_0) == null)
				{
					result = (this._NewVar_0 = new TMap<int, bool>(base.NativePtr + (IntPtr)GA_summonShouAnRen_C.__PropertyOffset_2, this));
				}
				return result;
			}
			set
			{
				this.NewVar_0.CopyAssign(value);
			}
		}

		// Token: 0x17007162 RID: 29026
		// (get) Token: 0x0602B486 RID: 177286 RVA: 0x00A766D7 File Offset: 0x00A748D7
		// (set) Token: 0x0602B487 RID: 177287 RVA: 0x00A766E7 File Offset: 0x00A748E7
		public unsafe bool NewVar_1
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_summonShouAnRen_C.__PropertyOffset_3) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_summonShouAnRen_C.__PropertyOffset_3) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007163 RID: 29027
		// (get) Token: 0x0602B488 RID: 177288 RVA: 0x00A766F8 File Offset: 0x00A748F8
		// (set) Token: 0x0602B489 RID: 177289 RVA: 0x00A7670C File Offset: 0x00A7490C
		[Nullable(2)]
		public unsafe TsBaseCharacter 守岸人
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<TsBaseCharacter>(base.NativePtr / (IntPtr)sizeof(void*) + GA_summonShouAnRen_C.__PropertyOffset_4);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GA_summonShouAnRen_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17007164 RID: 29028
		// (get) Token: 0x0602B48A RID: 177290 RVA: 0x00A76721 File Offset: 0x00A74921
		// (set) Token: 0x0602B48B RID: 177291 RVA: 0x00A76735 File Offset: 0x00A74935
		[Nullable(2)]
		public unsafe TsBaseCharacter 辅助闪避的角色
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<TsBaseCharacter>(base.NativePtr / (IntPtr)sizeof(void*) + GA_summonShouAnRen_C.__PropertyOffset_5);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GA_summonShouAnRen_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x17007165 RID: 29029
		// (get) Token: 0x0602B48C RID: 177292 RVA: 0x00A7674A File Offset: 0x00A7494A
		// (set) Token: 0x0602B48D RID: 177293 RVA: 0x00A7675E File Offset: 0x00A7495E
		public unsafe FTransform Transform
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_summonShouAnRen_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_summonShouAnRen_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x0602B48E RID: 177294 RVA: 0x00A76773 File Offset: 0x00A74973
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnFinish_338799594D3547E86A8DB6A3E235B50C()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_summonShouAnRen_C.__OnFinish_338799594D3547E86A8DB6A3E235B50C_NativeFunctionPtr, null);
		}

		// Token: 0x0602B48F RID: 177295 RVA: 0x00A76787 File Offset: 0x00A74987
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_summonShouAnRen_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x0602B490 RID: 177296 RVA: 0x00A7679B File Offset: 0x00A7499B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_summonShouAnRen_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602B491 RID: 177297 RVA: 0x00A767B0 File Offset: 0x00A749B0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void K2_OnEndAbility(bool bWasCancelled)
		{
			GA_summonShouAnRen_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_summonShouAnRen_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_summonShouAnRen_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_summonShouAnRen_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_summonShouAnRen_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B492 RID: 177298 RVA: 0x00A767F8 File Offset: 0x00A749F8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void K2_OnEndAbility_Implementation(bool bWasCancelled)
		{
			GA_summonShouAnRen_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_summonShouAnRen_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_summonShouAnRen_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_summonShouAnRen_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_summonShouAnRen_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602B493 RID: 177299 RVA: 0x00A76840 File Offset: 0x00A74A40
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_summonShouAnRen(int EntryPoint)
		{
			GA_summonShouAnRen_C.__ExecuteUbergraph_GA_summonShouAnRen_FunctionParams* ptr = stackalloc GA_summonShouAnRen_C.__ExecuteUbergraph_GA_summonShouAnRen_FunctionParams[(UIntPtr)1439] + 15L / (long)sizeof(GA_summonShouAnRen_C.__ExecuteUbergraph_GA_summonShouAnRen_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_summonShouAnRen_C.__ExecuteUbergraph_GA_summonShouAnRen_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_summonShouAnRen_C.__ExecuteUbergraph_GA_summonShouAnRen_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602B494 RID: 177300 RVA: 0x00A7688A File Offset: 0x00A74A8A
		protected GA_summonShouAnRen_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04017B5D RID: 97117
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Abilities/GA/GA_summonShouAnRen.GA_summonShouAnRen_C";

		// Token: 0x04017B5E RID: 97118
		private static IntPtr _ClassPtr;

		// Token: 0x04017B5F RID: 97119
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04017B60 RID: 97120
		internal new static int __PropertyOffset_0;

		// Token: 0x04017B61 RID: 97121
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04017B62 RID: 97122
		internal new static int __PropertyOffset_1;

		// Token: 0x04017B63 RID: 97123
		internal new static int __PropertyOffset_2;

		// Token: 0x04017B64 RID: 97124
		[Nullable(2)]
		private TMap<int, bool> _NewVar_0;

		// Token: 0x04017B65 RID: 97125
		internal new static int __PropertyOffset_3;

		// Token: 0x04017B66 RID: 97126
		internal static int __PropertyOffset_4;

		// Token: 0x04017B67 RID: 97127
		internal static int __PropertyOffset_5;

		// Token: 0x04017B68 RID: 97128
		internal static int __PropertyOffset_6;

		// Token: 0x04017B69 RID: 97129
		private static IntPtr __OnFinish_338799594D3547E86A8DB6A3E235B50C_NativeFunctionPtr;

		// Token: 0x04017B6A RID: 97130
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x04017B6B RID: 97131
		private static IntPtr __K2_OnEndAbility_NativeFunctionPtr;

		// Token: 0x04017B6C RID: 97132
		private static IntPtr __ExecuteUbergraph_GA_summonShouAnRen_NativeFunctionPtr;

		// Token: 0x0200A341 RID: 41793
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __K2_OnEndAbility_FunctionParams
		{
			// Token: 0x0403311E RID: 209182
			[FieldOffset(0)]
			public bool bWasCancelled;
		}

		// Token: 0x0200A342 RID: 41794
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1424)]
		protected ref struct __ExecuteUbergraph_GA_summonShouAnRen_FunctionParams
		{
			// Token: 0x0403311F RID: 209183
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
