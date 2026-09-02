using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Character.BaseCharacter.Abilities.GA;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Vehicle.Motor.Abilities.GA
{
	// Token: 0x02003FCC RID: 16332
	[UnrealObjectPath("/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_FetchHook.GA_Motor_FetchHook_C")]
	[UnrealStructLayout(1512, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1512)]
	public class GA_Motor_FetchHook_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602901E RID: 167966 RVA: 0x00A1E35C File Offset: 0x00A1C55C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_Motor_FetchHook_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_FetchHook.GA_Motor_FetchHook_C");
			}
			return GA_Motor_FetchHook_C._ClassPtr;
		}

		// Token: 0x0602901F RID: 167967 RVA: 0x00A1E380 File Offset: 0x00A1C580
		public GA_Motor_FetchHook_C() : this(BuiltinUtils.AllocNativeUObject(GA_Motor_FetchHook_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06029020 RID: 167968 RVA: 0x00A1E3A8 File Offset: 0x00A1C5A8
		[NullableContext(1)]
		public GA_Motor_FetchHook_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_Motor_FetchHook_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700650B RID: 25867
		// (get) Token: 0x06029021 RID: 167969 RVA: 0x00A1E3DC File Offset: 0x00A1C5DC
		// (set) Token: 0x06029022 RID: 167970 RVA: 0x00A1E415 File Offset: 0x00A1C615
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_Motor_FetchHook_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_Motor_FetchHook_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700650C RID: 25868
		// (get) Token: 0x06029023 RID: 167971 RVA: 0x00A1E436 File Offset: 0x00A1C636
		// (set) Token: 0x06029024 RID: 167972 RVA: 0x00A1E44A File Offset: 0x00A1C64A
		[Nullable(2)]
		public unsafe TsBaseVehicle 施法载具
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<TsBaseVehicle>(base.NativePtr / (IntPtr)sizeof(void*) + GA_Motor_FetchHook_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GA_Motor_FetchHook_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x1700650D RID: 25869
		// (get) Token: 0x06029025 RID: 167973 RVA: 0x00A1E45F File Offset: 0x00A1C65F
		// (set) Token: 0x06029026 RID: 167974 RVA: 0x00A1E46F File Offset: 0x00A1C66F
		public unsafe int 施法载具Id
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Motor_FetchHook_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Motor_FetchHook_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x1700650E RID: 25870
		// (get) Token: 0x06029027 RID: 167975 RVA: 0x00A1E480 File Offset: 0x00A1C680
		// (set) Token: 0x06029028 RID: 167976 RVA: 0x00A1E490 File Offset: 0x00A1C690
		public unsafe bool 是否移除特效Buff
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Motor_FetchHook_C.__PropertyOffset_3) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Motor_FetchHook_C.__PropertyOffset_3) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700650F RID: 25871
		// (get) Token: 0x06029029 RID: 167977 RVA: 0x00A1E4A1 File Offset: 0x00A1C6A1
		// (set) Token: 0x0602902A RID: 167978 RVA: 0x00A1E4B1 File Offset: 0x00A1C6B1
		public unsafe long BuffId
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Motor_FetchHook_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Motor_FetchHook_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x0602902B RID: 167979 RVA: 0x00A1E4C2 File Offset: 0x00A1C6C2
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnFinish_CD17688C48A6C8D5BFCE9AA72A8C5696()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_FetchHook_C.__OnFinish_CD17688C48A6C8D5BFCE9AA72A8C5696_NativeFunctionPtr, null);
		}

		// Token: 0x0602902C RID: 167980 RVA: 0x00A1E4D6 File Offset: 0x00A1C6D6
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnTick_CD17688C48A6C8D5BFCE9AA72A8C5696()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_FetchHook_C.__OnTick_CD17688C48A6C8D5BFCE9AA72A8C5696_NativeFunctionPtr, null);
		}

		// Token: 0x0602902D RID: 167981 RVA: 0x00A1E4EA File Offset: 0x00A1C6EA
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnFinish_7FAAD89C4FA0ED181321D7B5F80D462C()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_FetchHook_C.__OnFinish_7FAAD89C4FA0ED181321D7B5F80D462C_NativeFunctionPtr, null);
		}

		// Token: 0x0602902E RID: 167982 RVA: 0x00A1E4FE File Offset: 0x00A1C6FE
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnFinish_C5EAE3EE4939CB19D2C47DADF3E097A4()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_FetchHook_C.__OnFinish_C5EAE3EE4939CB19D2C47DADF3E097A4_NativeFunctionPtr, null);
		}

		// Token: 0x0602902F RID: 167983 RVA: 0x00A1E512 File Offset: 0x00A1C712
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_FetchHook_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x06029030 RID: 167984 RVA: 0x00A1E526 File Offset: 0x00A1C726
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_FetchHook_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06029031 RID: 167985 RVA: 0x00A1E53C File Offset: 0x00A1C73C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void K2_OnEndAbility(bool bWasCancelled)
		{
			GA_Motor_FetchHook_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Motor_FetchHook_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Motor_FetchHook_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_FetchHook_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_FetchHook_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06029032 RID: 167986 RVA: 0x00A1E584 File Offset: 0x00A1C784
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void K2_OnEndAbility_Implementation(bool bWasCancelled)
		{
			GA_Motor_FetchHook_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Motor_FetchHook_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Motor_FetchHook_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_FetchHook_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_FetchHook_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06029033 RID: 167987 RVA: 0x00A1E5CC File Offset: 0x00A1C7CC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_Motor_FetchHook(int EntryPoint)
		{
			GA_Motor_FetchHook_C.__ExecuteUbergraph_GA_Motor_FetchHook_FunctionParams* ptr = stackalloc GA_Motor_FetchHook_C.__ExecuteUbergraph_GA_Motor_FetchHook_FunctionParams[(UIntPtr)279] + 15L / (long)sizeof(GA_Motor_FetchHook_C.__ExecuteUbergraph_GA_Motor_FetchHook_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_FetchHook_C.__ExecuteUbergraph_GA_Motor_FetchHook_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_FetchHook_C.__ExecuteUbergraph_GA_Motor_FetchHook_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06029034 RID: 167988 RVA: 0x00A1E616 File Offset: 0x00A1C816
		protected GA_Motor_FetchHook_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04015B5A RID: 88922
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_FetchHook.GA_Motor_FetchHook_C";

		// Token: 0x04015B5B RID: 88923
		private static IntPtr _ClassPtr;

		// Token: 0x04015B5C RID: 88924
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04015B5D RID: 88925
		internal new static int __PropertyOffset_0;

		// Token: 0x04015B5E RID: 88926
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04015B5F RID: 88927
		internal new static int __PropertyOffset_1;

		// Token: 0x04015B60 RID: 88928
		internal new static int __PropertyOffset_2;

		// Token: 0x04015B61 RID: 88929
		internal new static int __PropertyOffset_3;

		// Token: 0x04015B62 RID: 88930
		internal static int __PropertyOffset_4;

		// Token: 0x04015B63 RID: 88931
		private static IntPtr __OnFinish_CD17688C48A6C8D5BFCE9AA72A8C5696_NativeFunctionPtr;

		// Token: 0x04015B64 RID: 88932
		private static IntPtr __OnTick_CD17688C48A6C8D5BFCE9AA72A8C5696_NativeFunctionPtr;

		// Token: 0x04015B65 RID: 88933
		private static IntPtr __OnFinish_7FAAD89C4FA0ED181321D7B5F80D462C_NativeFunctionPtr;

		// Token: 0x04015B66 RID: 88934
		private static IntPtr __OnFinish_C5EAE3EE4939CB19D2C47DADF3E097A4_NativeFunctionPtr;

		// Token: 0x04015B67 RID: 88935
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x04015B68 RID: 88936
		private static IntPtr __K2_OnEndAbility_NativeFunctionPtr;

		// Token: 0x04015B69 RID: 88937
		private static IntPtr __ExecuteUbergraph_GA_Motor_FetchHook_NativeFunctionPtr;

		// Token: 0x0200A1A3 RID: 41379
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __K2_OnEndAbility_FunctionParams
		{
			// Token: 0x04032EFB RID: 208635
			[FieldOffset(0)]
			public bool bWasCancelled;
		}

		// Token: 0x0200A1A4 RID: 41380
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 264)]
		protected ref struct __ExecuteUbergraph_GA_Motor_FetchHook_FunctionParams
		{
			// Token: 0x04032EFC RID: 208636
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
