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
	// Token: 0x02003FD0 RID: 16336
	[UnrealObjectPath("/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_FP.GA_Motor_FP_C")]
	[UnrealStructLayout(1536, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1536)]
	public class GA_Motor_FP_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060290F0 RID: 168176 RVA: 0x00A1FA3F File Offset: 0x00A1DC3F
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_Motor_FP_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_FP.GA_Motor_FP_C");
			}
			return GA_Motor_FP_C._ClassPtr;
		}

		// Token: 0x060290F1 RID: 168177 RVA: 0x00A1FA64 File Offset: 0x00A1DC64
		public GA_Motor_FP_C() : this(BuiltinUtils.AllocNativeUObject(GA_Motor_FP_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060290F2 RID: 168178 RVA: 0x00A1FA8C File Offset: 0x00A1DC8C
		[NullableContext(1)]
		public GA_Motor_FP_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_Motor_FP_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700654C RID: 25932
		// (get) Token: 0x060290F3 RID: 168179 RVA: 0x00A1FAC0 File Offset: 0x00A1DCC0
		// (set) Token: 0x060290F4 RID: 168180 RVA: 0x00A1FAF9 File Offset: 0x00A1DCF9
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_Motor_FP_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_Motor_FP_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700654D RID: 25933
		// (get) Token: 0x060290F5 RID: 168181 RVA: 0x00A1FB1A File Offset: 0x00A1DD1A
		// (set) Token: 0x060290F6 RID: 168182 RVA: 0x00A1FB2E File Offset: 0x00A1DD2E
		[Nullable(2)]
		public unsafe AActor 被控物
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + GA_Motor_FP_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GA_Motor_FP_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x1700654E RID: 25934
		// (get) Token: 0x060290F7 RID: 168183 RVA: 0x00A1FB44 File Offset: 0x00A1DD44
		// (set) Token: 0x060290F8 RID: 168184 RVA: 0x00A1FB7D File Offset: 0x00A1DD7D
		[Nullable(1)]
		public FMotorBoostConfig 摩托_喷射与超速配置
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				FMotorBoostConfig result;
				if ((result = this._摩托_喷射与超速配置) == null)
				{
					result = (this._摩托_喷射与超速配置 = new FMotorBoostConfig(base.NativePtr + (IntPtr)GA_Motor_FP_C.__PropertyOffset_2, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FMotorBoostConfig.StaticStruct(), base.NativePtr + (IntPtr)GA_Motor_FP_C.__PropertyOffset_2, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700654F RID: 25935
		// (get) Token: 0x060290F9 RID: 168185 RVA: 0x00A1FB9E File Offset: 0x00A1DD9E
		// (set) Token: 0x060290FA RID: 168186 RVA: 0x00A1FBB2 File Offset: 0x00A1DDB2
		[Nullable(2)]
		public unsafe TsBaseCharacter 当前角色
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<TsBaseCharacter>(base.NativePtr / (IntPtr)sizeof(void*) + GA_Motor_FP_C.__PropertyOffset_3);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GA_Motor_FP_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x060290FB RID: 168187 RVA: 0x00A1FBC8 File Offset: 0x00A1DDC8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 开启头部跟随旋转(int id)
		{
			GA_Motor_FP_C.__开启头部跟随旋转_FunctionParams* ptr = stackalloc GA_Motor_FP_C.__开启头部跟随旋转_FunctionParams[(UIntPtr)111] + 15L / (long)sizeof(GA_Motor_FP_C.__开启头部跟随旋转_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_FP_C.__开启头部跟随旋转_NativeFunctionPtr, (void*)ptr, 1);
			ptr->id = id;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_FP_C.__开启头部跟随旋转_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060290FC RID: 168188 RVA: 0x00A1FC10 File Offset: 0x00A1DE10
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 关闭头部跟随旋转开动态模糊(int id)
		{
			GA_Motor_FP_C.__关闭头部跟随旋转开动态模糊_FunctionParams* ptr = stackalloc GA_Motor_FP_C.__关闭头部跟随旋转开动态模糊_FunctionParams[(UIntPtr)55] + 15L / (long)sizeof(GA_Motor_FP_C.__关闭头部跟随旋转开动态模糊_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_FP_C.__关闭头部跟随旋转开动态模糊_NativeFunctionPtr, (void*)ptr, 1);
			ptr->id = id;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_FP_C.__关闭头部跟随旋转开动态模糊_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060290FD RID: 168189 RVA: 0x00A1FC58 File Offset: 0x00A1DE58
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Removed_DB9F64004F8908FEAD99D3818185D810(in FGameplayTag Tag)
		{
			GA_Motor_FP_C.__Removed_DB9F64004F8908FEAD99D3818185D810_FunctionParams* ptr = stackalloc GA_Motor_FP_C.__Removed_DB9F64004F8908FEAD99D3818185D810_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(GA_Motor_FP_C.__Removed_DB9F64004F8908FEAD99D3818185D810_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_FP_C.__Removed_DB9F64004F8908FEAD99D3818185D810_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Tag = Tag;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_FP_C.__Removed_DB9F64004F8908FEAD99D3818185D810_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060290FE RID: 168190 RVA: 0x00A1FCA4 File Offset: 0x00A1DEA4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Removed_DB9F64004F8908FEAD99D381B592EC70(in FGameplayTag Tag)
		{
			GA_Motor_FP_C.__Removed_DB9F64004F8908FEAD99D381B592EC70_FunctionParams* ptr = stackalloc GA_Motor_FP_C.__Removed_DB9F64004F8908FEAD99D381B592EC70_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(GA_Motor_FP_C.__Removed_DB9F64004F8908FEAD99D381B592EC70_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_FP_C.__Removed_DB9F64004F8908FEAD99D381B592EC70_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Tag = Tag;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_FP_C.__Removed_DB9F64004F8908FEAD99D381B592EC70_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060290FF RID: 168191 RVA: 0x00A1FCF0 File Offset: 0x00A1DEF0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Added_21071CB943CD992BF8EFD6A3ECEFA05A(in FGameplayTag Tag)
		{
			GA_Motor_FP_C.__Added_21071CB943CD992BF8EFD6A3ECEFA05A_FunctionParams* ptr = stackalloc GA_Motor_FP_C.__Added_21071CB943CD992BF8EFD6A3ECEFA05A_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(GA_Motor_FP_C.__Added_21071CB943CD992BF8EFD6A3ECEFA05A_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_FP_C.__Added_21071CB943CD992BF8EFD6A3ECEFA05A_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Tag = Tag;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_FP_C.__Added_21071CB943CD992BF8EFD6A3ECEFA05A_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06029100 RID: 168192 RVA: 0x00A1FD3C File Offset: 0x00A1DF3C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Removed_DB9F64004F8908FEAD99D381AB958228(in FGameplayTag Tag)
		{
			GA_Motor_FP_C.__Removed_DB9F64004F8908FEAD99D381AB958228_FunctionParams* ptr = stackalloc GA_Motor_FP_C.__Removed_DB9F64004F8908FEAD99D381AB958228_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(GA_Motor_FP_C.__Removed_DB9F64004F8908FEAD99D381AB958228_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_FP_C.__Removed_DB9F64004F8908FEAD99D381AB958228_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Tag = Tag;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_FP_C.__Removed_DB9F64004F8908FEAD99D381AB958228_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06029101 RID: 168193 RVA: 0x00A1FD88 File Offset: 0x00A1DF88
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Added_21071CB943CD992BF8EFD6A3F51FE60F(in FGameplayTag Tag)
		{
			GA_Motor_FP_C.__Added_21071CB943CD992BF8EFD6A3F51FE60F_FunctionParams* ptr = stackalloc GA_Motor_FP_C.__Added_21071CB943CD992BF8EFD6A3F51FE60F_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(GA_Motor_FP_C.__Added_21071CB943CD992BF8EFD6A3F51FE60F_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_FP_C.__Added_21071CB943CD992BF8EFD6A3F51FE60F_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Tag = Tag;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_FP_C.__Added_21071CB943CD992BF8EFD6A3F51FE60F_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06029102 RID: 168194 RVA: 0x00A1FDD4 File Offset: 0x00A1DFD4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Added_21071CB943CD992BF8EFD6A30BC0D67E(in FGameplayTag Tag)
		{
			GA_Motor_FP_C.__Added_21071CB943CD992BF8EFD6A30BC0D67E_FunctionParams* ptr = stackalloc GA_Motor_FP_C.__Added_21071CB943CD992BF8EFD6A30BC0D67E_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(GA_Motor_FP_C.__Added_21071CB943CD992BF8EFD6A30BC0D67E_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_FP_C.__Added_21071CB943CD992BF8EFD6A30BC0D67E_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Tag = Tag;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_FP_C.__Added_21071CB943CD992BF8EFD6A30BC0D67E_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06029103 RID: 168195 RVA: 0x00A1FE1F File Offset: 0x00A1E01F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_FP_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x06029104 RID: 168196 RVA: 0x00A1FE33 File Offset: 0x00A1E033
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_FP_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06029105 RID: 168197 RVA: 0x00A1FE48 File Offset: 0x00A1E048
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void K2_OnEndAbility(bool bWasCancelled)
		{
			GA_Motor_FP_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Motor_FP_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Motor_FP_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_FP_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_FP_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06029106 RID: 168198 RVA: 0x00A1FE90 File Offset: 0x00A1E090
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void K2_OnEndAbility_Implementation(bool bWasCancelled)
		{
			GA_Motor_FP_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Motor_FP_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Motor_FP_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_FP_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_FP_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06029107 RID: 168199 RVA: 0x00A1FED7 File Offset: 0x00A1E0D7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 自定义事件_0()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_FP_C.__自定义事件_0_NativeFunctionPtr, null);
		}

		// Token: 0x06029108 RID: 168200 RVA: 0x00A1FEEC File Offset: 0x00A1E0EC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_Motor_FP(int EntryPoint)
		{
			GA_Motor_FP_C.__ExecuteUbergraph_GA_Motor_FP_FunctionParams* ptr = stackalloc GA_Motor_FP_C.__ExecuteUbergraph_GA_Motor_FP_FunctionParams[(UIntPtr)727] + 15L / (long)sizeof(GA_Motor_FP_C.__ExecuteUbergraph_GA_Motor_FP_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_FP_C.__ExecuteUbergraph_GA_Motor_FP_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_FP_C.__ExecuteUbergraph_GA_Motor_FP_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06029109 RID: 168201 RVA: 0x00A1FF36 File Offset: 0x00A1E136
		protected GA_Motor_FP_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04015BE3 RID: 89059
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_FP.GA_Motor_FP_C";

		// Token: 0x04015BE4 RID: 89060
		private static IntPtr _ClassPtr;

		// Token: 0x04015BE5 RID: 89061
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04015BE6 RID: 89062
		internal new static int __PropertyOffset_0;

		// Token: 0x04015BE7 RID: 89063
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04015BE8 RID: 89064
		internal new static int __PropertyOffset_1;

		// Token: 0x04015BE9 RID: 89065
		internal new static int __PropertyOffset_2;

		// Token: 0x04015BEA RID: 89066
		[Nullable(2)]
		private FMotorBoostConfig _摩托_喷射与超速配置;

		// Token: 0x04015BEB RID: 89067
		internal new static int __PropertyOffset_3;

		// Token: 0x04015BEC RID: 89068
		private static IntPtr __开启头部跟随旋转_NativeFunctionPtr;

		// Token: 0x04015BED RID: 89069
		private static IntPtr __关闭头部跟随旋转开动态模糊_NativeFunctionPtr;

		// Token: 0x04015BEE RID: 89070
		private static IntPtr __Removed_DB9F64004F8908FEAD99D3818185D810_NativeFunctionPtr;

		// Token: 0x04015BEF RID: 89071
		private static IntPtr __Removed_DB9F64004F8908FEAD99D381B592EC70_NativeFunctionPtr;

		// Token: 0x04015BF0 RID: 89072
		private static IntPtr __Added_21071CB943CD992BF8EFD6A3ECEFA05A_NativeFunctionPtr;

		// Token: 0x04015BF1 RID: 89073
		private static IntPtr __Removed_DB9F64004F8908FEAD99D381AB958228_NativeFunctionPtr;

		// Token: 0x04015BF2 RID: 89074
		private static IntPtr __Added_21071CB943CD992BF8EFD6A3F51FE60F_NativeFunctionPtr;

		// Token: 0x04015BF3 RID: 89075
		private static IntPtr __Added_21071CB943CD992BF8EFD6A30BC0D67E_NativeFunctionPtr;

		// Token: 0x04015BF4 RID: 89076
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x04015BF5 RID: 89077
		private static IntPtr __K2_OnEndAbility_NativeFunctionPtr;

		// Token: 0x04015BF6 RID: 89078
		private static IntPtr __自定义事件_0_NativeFunctionPtr;

		// Token: 0x04015BF7 RID: 89079
		private static IntPtr __ExecuteUbergraph_GA_Motor_FP_NativeFunctionPtr;

		// Token: 0x0200A1B5 RID: 41397
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 96)]
		protected ref struct __开启头部跟随旋转_FunctionParams
		{
			// Token: 0x04032F12 RID: 208658
			[FieldOffset(0)]
			public int id;
		}

		// Token: 0x0200A1B6 RID: 41398
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 40)]
		protected ref struct __关闭头部跟随旋转开动态模糊_FunctionParams
		{
			// Token: 0x04032F13 RID: 208659
			[FieldOffset(0)]
			public int id;
		}

		// Token: 0x0200A1B7 RID: 41399
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __Removed_DB9F64004F8908FEAD99D3818185D810_FunctionParams
		{
			// Token: 0x04032F14 RID: 208660
			[FieldOffset(0)]
			public FGameplayTag Tag;
		}

		// Token: 0x0200A1B8 RID: 41400
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __Removed_DB9F64004F8908FEAD99D381B592EC70_FunctionParams
		{
			// Token: 0x04032F15 RID: 208661
			[FieldOffset(0)]
			public FGameplayTag Tag;
		}

		// Token: 0x0200A1B9 RID: 41401
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __Added_21071CB943CD992BF8EFD6A3ECEFA05A_FunctionParams
		{
			// Token: 0x04032F16 RID: 208662
			[FieldOffset(0)]
			public FGameplayTag Tag;
		}

		// Token: 0x0200A1BA RID: 41402
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __Removed_DB9F64004F8908FEAD99D381AB958228_FunctionParams
		{
			// Token: 0x04032F17 RID: 208663
			[FieldOffset(0)]
			public FGameplayTag Tag;
		}

		// Token: 0x0200A1BB RID: 41403
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __Added_21071CB943CD992BF8EFD6A3F51FE60F_FunctionParams
		{
			// Token: 0x04032F18 RID: 208664
			[FieldOffset(0)]
			public FGameplayTag Tag;
		}

		// Token: 0x0200A1BC RID: 41404
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __Added_21071CB943CD992BF8EFD6A30BC0D67E_FunctionParams
		{
			// Token: 0x04032F19 RID: 208665
			[FieldOffset(0)]
			public FGameplayTag Tag;
		}

		// Token: 0x0200A1BD RID: 41405
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __K2_OnEndAbility_FunctionParams
		{
			// Token: 0x04032F1A RID: 208666
			[FieldOffset(0)]
			public bool bWasCancelled;
		}

		// Token: 0x0200A1BE RID: 41406
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 712)]
		protected ref struct __ExecuteUbergraph_GA_Motor_FP_FunctionParams
		{
			// Token: 0x04032F1B RID: 208667
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
