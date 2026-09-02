using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Vehicle.Motor.Abilities.GA
{
	// Token: 0x02003FC7 RID: 16327
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_Drone_DyStart.GA_Motor_Drone_DyStart_C")]
	[UnrealStructLayout(1560, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1560)]
	public class GA_Motor_Drone_DyStart_C : GA_Motor_DroneBase_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06028FD5 RID: 167893 RVA: 0x00A1D658 File Offset: 0x00A1B858
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_Motor_Drone_DyStart_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_Drone_DyStart.GA_Motor_Drone_DyStart_C");
			}
			return GA_Motor_Drone_DyStart_C._ClassPtr;
		}

		// Token: 0x06028FD6 RID: 167894 RVA: 0x00A1D67C File Offset: 0x00A1B87C
		public GA_Motor_Drone_DyStart_C() : this(BuiltinUtils.AllocNativeUObject(GA_Motor_Drone_DyStart_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06028FD7 RID: 167895 RVA: 0x00A1D6A4 File Offset: 0x00A1B8A4
		public GA_Motor_Drone_DyStart_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_Motor_Drone_DyStart_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17006500 RID: 25856
		// (get) Token: 0x06028FD8 RID: 167896 RVA: 0x00A1D6D8 File Offset: 0x00A1B8D8
		// (set) Token: 0x06028FD9 RID: 167897 RVA: 0x00A1D711 File Offset: 0x00A1B911
		public new FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_Motor_Drone_DyStart_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_Motor_Drone_DyStart_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006501 RID: 25857
		// (get) Token: 0x06028FDA RID: 167898 RVA: 0x00A1D734 File Offset: 0x00A1B934
		// (set) Token: 0x06028FDB RID: 167899 RVA: 0x00A1D76D File Offset: 0x00A1B96D
		public TArray<FGameplayTag> 挂点Tags
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FGameplayTag> result;
				if ((result = this._挂点Tags) == null)
				{
					result = (this._挂点Tags = new TArray<FGameplayTag>(base.NativePtr + (IntPtr)GA_Motor_Drone_DyStart_C.__PropertyOffset_1, this));
				}
				return result;
			}
			set
			{
				this.挂点Tags.CopyAssign(value);
			}
		}

		// Token: 0x17006502 RID: 25858
		// (get) Token: 0x06028FDC RID: 167900 RVA: 0x00A1D77C File Offset: 0x00A1B97C
		// (set) Token: 0x06028FDD RID: 167901 RVA: 0x00A1D7B5 File Offset: 0x00A1B9B5
		public TArray<FGameplayTag> 死眼Tag
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FGameplayTag> result;
				if ((result = this._死眼Tag) == null)
				{
					result = (this._死眼Tag = new TArray<FGameplayTag>(base.NativePtr + (IntPtr)GA_Motor_Drone_DyStart_C.__PropertyOffset_2, this));
				}
				return result;
			}
			set
			{
				this.死眼Tag.CopyAssign(value);
			}
		}

		// Token: 0x06028FDE RID: 167902 RVA: 0x00A1D7C3 File Offset: 0x00A1B9C3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Drone_DyStart_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x06028FDF RID: 167903 RVA: 0x00A1D7D7 File Offset: 0x00A1B9D7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_Drone_DyStart_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06028FE0 RID: 167904 RVA: 0x00A1D7EC File Offset: 0x00A1B9EC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void K2_OnEndAbility(bool bWasCancelled)
		{
			GA_Motor_Drone_DyStart_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Motor_Drone_DyStart_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Motor_Drone_DyStart_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_Drone_DyStart_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Drone_DyStart_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06028FE1 RID: 167905 RVA: 0x00A1D834 File Offset: 0x00A1BA34
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void K2_OnEndAbility_Implementation(bool bWasCancelled)
		{
			GA_Motor_Drone_DyStart_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Motor_Drone_DyStart_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Motor_Drone_DyStart_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_Drone_DyStart_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_Drone_DyStart_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06028FE2 RID: 167906 RVA: 0x00A1D87C File Offset: 0x00A1BA7C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_Motor_Drone_DyStart(int EntryPoint)
		{
			GA_Motor_Drone_DyStart_C.__ExecuteUbergraph_GA_Motor_Drone_DyStart_FunctionParams* ptr = stackalloc GA_Motor_Drone_DyStart_C.__ExecuteUbergraph_GA_Motor_Drone_DyStart_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(GA_Motor_Drone_DyStart_C.__ExecuteUbergraph_GA_Motor_Drone_DyStart_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_Drone_DyStart_C.__ExecuteUbergraph_GA_Motor_Drone_DyStart_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_Drone_DyStart_C.__ExecuteUbergraph_GA_Motor_Drone_DyStart_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06028FE3 RID: 167907 RVA: 0x00A1D8C3 File Offset: 0x00A1BAC3
		protected GA_Motor_Drone_DyStart_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04015B22 RID: 88866
		public new const string __ObjectPath = "/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_Drone_DyStart.GA_Motor_Drone_DyStart_C";

		// Token: 0x04015B23 RID: 88867
		private static IntPtr _ClassPtr;

		// Token: 0x04015B24 RID: 88868
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04015B25 RID: 88869
		internal new static int __PropertyOffset_0;

		// Token: 0x04015B26 RID: 88870
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04015B27 RID: 88871
		internal new static int __PropertyOffset_1;

		// Token: 0x04015B28 RID: 88872
		[Nullable(2)]
		private TArray<FGameplayTag> _挂点Tags;

		// Token: 0x04015B29 RID: 88873
		internal new static int __PropertyOffset_2;

		// Token: 0x04015B2A RID: 88874
		[Nullable(2)]
		private TArray<FGameplayTag> _死眼Tag;

		// Token: 0x04015B2B RID: 88875
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x04015B2C RID: 88876
		private static IntPtr __K2_OnEndAbility_NativeFunctionPtr;

		// Token: 0x04015B2D RID: 88877
		private static IntPtr __ExecuteUbergraph_GA_Motor_Drone_DyStart_NativeFunctionPtr;

		// Token: 0x0200A192 RID: 41362
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __K2_OnEndAbility_FunctionParams
		{
			// Token: 0x04032EE6 RID: 208614
			[FieldOffset(0)]
			public bool bWasCancelled;
		}

		// Token: 0x0200A193 RID: 41363
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __ExecuteUbergraph_GA_Motor_Drone_DyStart_FunctionParams
		{
			// Token: 0x04032EE7 RID: 208615
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
