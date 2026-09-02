using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Character.BaseCharacter.Abilities.GA;
using AkiClient.Game.Aki.Data.Fight.FollowShooter;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Vehicle.Motor.Abilities.GA
{
	// Token: 0x02003FC1 RID: 16321
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_DroneBase.GA_Motor_DroneBase_C")]
	[UnrealStructLayout(1512, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1512)]
	public class GA_Motor_DroneBase_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06028F7B RID: 167803 RVA: 0x00A1C808 File Offset: 0x00A1AA08
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_Motor_DroneBase_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_DroneBase.GA_Motor_DroneBase_C");
			}
			return GA_Motor_DroneBase_C._ClassPtr;
		}

		// Token: 0x06028F7C RID: 167804 RVA: 0x00A1C82C File Offset: 0x00A1AA2C
		public GA_Motor_DroneBase_C() : this(BuiltinUtils.AllocNativeUObject(GA_Motor_DroneBase_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06028F7D RID: 167805 RVA: 0x00A1C854 File Offset: 0x00A1AA54
		[NullableContext(1)]
		public GA_Motor_DroneBase_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_Motor_DroneBase_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170064F2 RID: 25842
		// (get) Token: 0x06028F7E RID: 167806 RVA: 0x00A1C888 File Offset: 0x00A1AA88
		// (set) Token: 0x06028F7F RID: 167807 RVA: 0x00A1C8C1 File Offset: 0x00A1AAC1
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_Motor_DroneBase_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_Motor_DroneBase_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170064F3 RID: 25843
		// (get) Token: 0x06028F80 RID: 167808 RVA: 0x00A1C8E2 File Offset: 0x00A1AAE2
		// (set) Token: 0x06028F81 RID: 167809 RVA: 0x00A1C8F2 File Offset: 0x00A1AAF2
		public unsafe int Drone_Entity_Id
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Motor_DroneBase_C.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Motor_DroneBase_C.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x170064F4 RID: 25844
		// (get) Token: 0x06028F82 RID: 167810 RVA: 0x00A1C903 File Offset: 0x00A1AB03
		// (set) Token: 0x06028F83 RID: 167811 RVA: 0x00A1C917 File Offset: 0x00A1AB17
		public unsafe BP_FollowShooterConfig_C FollowShooterConfig
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_FollowShooterConfig_C>(base.NativePtr / (IntPtr)sizeof(void*) + GA_Motor_DroneBase_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GA_Motor_DroneBase_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x170064F5 RID: 25845
		// (get) Token: 0x06028F84 RID: 167812 RVA: 0x00A1C92C File Offset: 0x00A1AB2C
		// (set) Token: 0x06028F85 RID: 167813 RVA: 0x00A1C940 File Offset: 0x00A1AB40
		public unsafe AActor DroneEntity
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + GA_Motor_DroneBase_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GA_Motor_DroneBase_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x06028F86 RID: 167814 RVA: 0x00A1C958 File Offset: 0x00A1AB58
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 删除Tags(ref TArray<FGameplayTag> Tags)
		{
			GA_Motor_DroneBase_C.__删除Tags_FunctionParams* ptr = stackalloc GA_Motor_DroneBase_C.__删除Tags_FunctionParams[(UIntPtr)63] + 15L / (long)sizeof(GA_Motor_DroneBase_C.__删除Tags_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_DroneBase_C.__删除Tags_NativeFunctionPtr, (void*)ptr, 1);
			TArray<FGameplayTag> tarray = Tags;
			if (tarray != null)
			{
				tarray.MoveTo(&ptr->Tags);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_DroneBase_C.__删除Tags_NativeFunctionPtr, (void*)ptr);
			TArray<FGameplayTag> tarray2 = Tags;
			if (tarray2 != null)
			{
				tarray2.MoveAssign(&ptr->Tags);
			}
			UnrealReflectionUtils.DestroyStruct(GA_Motor_DroneBase_C.__删除Tags_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x06028F87 RID: 167815 RVA: 0x00A1C9D0 File Offset: 0x00A1ABD0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 添加Tags(ref TArray<FGameplayTag> Tags)
		{
			GA_Motor_DroneBase_C.__添加Tags_FunctionParams* ptr = stackalloc GA_Motor_DroneBase_C.__添加Tags_FunctionParams[(UIntPtr)63] + 15L / (long)sizeof(GA_Motor_DroneBase_C.__添加Tags_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_DroneBase_C.__添加Tags_NativeFunctionPtr, (void*)ptr, 1);
			TArray<FGameplayTag> tarray = Tags;
			if (tarray != null)
			{
				tarray.MoveTo(&ptr->Tags);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_DroneBase_C.__添加Tags_NativeFunctionPtr, (void*)ptr);
			TArray<FGameplayTag> tarray2 = Tags;
			if (tarray2 != null)
			{
				tarray2.MoveAssign(&ptr->Tags);
			}
			UnrealReflectionUtils.DestroyStruct(GA_Motor_DroneBase_C.__添加Tags_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x06028F88 RID: 167816 RVA: 0x00A1CA48 File Offset: 0x00A1AC48
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 删除禁止瞄准Tag()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_DroneBase_C.__删除禁止瞄准Tag_NativeFunctionPtr, null);
		}

		// Token: 0x06028F89 RID: 167817 RVA: 0x00A1CA5C File Offset: 0x00A1AC5C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 添加禁止瞄准Tag()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_DroneBase_C.__添加禁止瞄准Tag_NativeFunctionPtr, null);
		}

		// Token: 0x06028F8A RID: 167818 RVA: 0x00A1CA70 File Offset: 0x00A1AC70
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 校验浮游炮有效性(ref bool Valid)
		{
			GA_Motor_DroneBase_C.__校验浮游炮有效性_FunctionParams* ptr = stackalloc GA_Motor_DroneBase_C.__校验浮游炮有效性_FunctionParams[(UIntPtr)18] + 15L / (long)sizeof(GA_Motor_DroneBase_C.__校验浮游炮有效性_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_DroneBase_C.__校验浮游炮有效性_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Valid = Valid;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_DroneBase_C.__校验浮游炮有效性_NativeFunctionPtr, (void*)ptr);
			Valid = ptr->Valid;
		}

		// Token: 0x06028F8B RID: 167819 RVA: 0x00A1CABF File Offset: 0x00A1ACBF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 反转浮游炮()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_DroneBase_C.__反转浮游炮_NativeFunctionPtr, null);
		}

		// Token: 0x06028F8C RID: 167820 RVA: 0x00A1CAD3 File Offset: 0x00A1ACD3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 关闭浮游炮()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_DroneBase_C.__关闭浮游炮_NativeFunctionPtr, null);
		}

		// Token: 0x06028F8D RID: 167821 RVA: 0x00A1CAE7 File Offset: 0x00A1ACE7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 删除常驻挂点_Tag()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_DroneBase_C.__删除常驻挂点_Tag_NativeFunctionPtr, null);
		}

		// Token: 0x06028F8E RID: 167822 RVA: 0x00A1CAFB File Offset: 0x00A1ACFB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 添加常驻挂点Tag()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_DroneBase_C.__添加常驻挂点Tag_NativeFunctionPtr, null);
		}

		// Token: 0x06028F8F RID: 167823 RVA: 0x00A1CB0F File Offset: 0x00A1AD0F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 开启浮游炮()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_DroneBase_C.__开启浮游炮_NativeFunctionPtr, null);
		}

		// Token: 0x06028F90 RID: 167824 RVA: 0x00A1CB23 File Offset: 0x00A1AD23
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_DroneBase_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x06028F91 RID: 167825 RVA: 0x00A1CB37 File Offset: 0x00A1AD37
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_DroneBase_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06028F92 RID: 167826 RVA: 0x00A1CB4C File Offset: 0x00A1AD4C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_Motor_DroneBase(int EntryPoint)
		{
			GA_Motor_DroneBase_C.__ExecuteUbergraph_GA_Motor_DroneBase_FunctionParams* ptr = stackalloc GA_Motor_DroneBase_C.__ExecuteUbergraph_GA_Motor_DroneBase_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(GA_Motor_DroneBase_C.__ExecuteUbergraph_GA_Motor_DroneBase_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_DroneBase_C.__ExecuteUbergraph_GA_Motor_DroneBase_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_DroneBase_C.__ExecuteUbergraph_GA_Motor_DroneBase_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06028F93 RID: 167827 RVA: 0x00A1CB93 File Offset: 0x00A1AD93
		protected GA_Motor_DroneBase_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04015ADD RID: 88797
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_DroneBase.GA_Motor_DroneBase_C";

		// Token: 0x04015ADE RID: 88798
		private static IntPtr _ClassPtr;

		// Token: 0x04015ADF RID: 88799
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04015AE0 RID: 88800
		internal new static int __PropertyOffset_0;

		// Token: 0x04015AE1 RID: 88801
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04015AE2 RID: 88802
		internal new static int __PropertyOffset_1;

		// Token: 0x04015AE3 RID: 88803
		internal new static int __PropertyOffset_2;

		// Token: 0x04015AE4 RID: 88804
		internal new static int __PropertyOffset_3;

		// Token: 0x04015AE5 RID: 88805
		private static IntPtr __删除Tags_NativeFunctionPtr;

		// Token: 0x04015AE6 RID: 88806
		private static IntPtr __添加Tags_NativeFunctionPtr;

		// Token: 0x04015AE7 RID: 88807
		private static IntPtr __删除禁止瞄准Tag_NativeFunctionPtr;

		// Token: 0x04015AE8 RID: 88808
		private static IntPtr __添加禁止瞄准Tag_NativeFunctionPtr;

		// Token: 0x04015AE9 RID: 88809
		private static IntPtr __校验浮游炮有效性_NativeFunctionPtr;

		// Token: 0x04015AEA RID: 88810
		private static IntPtr __反转浮游炮_NativeFunctionPtr;

		// Token: 0x04015AEB RID: 88811
		private static IntPtr __关闭浮游炮_NativeFunctionPtr;

		// Token: 0x04015AEC RID: 88812
		private static IntPtr __删除常驻挂点_Tag_NativeFunctionPtr;

		// Token: 0x04015AED RID: 88813
		private static IntPtr __添加常驻挂点Tag_NativeFunctionPtr;

		// Token: 0x04015AEE RID: 88814
		private static IntPtr __开启浮游炮_NativeFunctionPtr;

		// Token: 0x04015AEF RID: 88815
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x04015AF0 RID: 88816
		private static IntPtr __ExecuteUbergraph_GA_Motor_DroneBase_NativeFunctionPtr;

		// Token: 0x0200A184 RID: 41348
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 48)]
		protected ref struct __删除Tags_FunctionParams
		{
			// Token: 0x04032ED8 RID: 208600
			[FieldOffset(0)]
			public byte Tags;
		}

		// Token: 0x0200A185 RID: 41349
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 48)]
		protected ref struct __添加Tags_FunctionParams
		{
			// Token: 0x04032ED9 RID: 208601
			[FieldOffset(0)]
			public byte Tags;
		}

		// Token: 0x0200A186 RID: 41350
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 3)]
		protected ref struct __校验浮游炮有效性_FunctionParams
		{
			// Token: 0x04032EDA RID: 208602
			[FieldOffset(0)]
			public bool Valid;
		}

		// Token: 0x0200A187 RID: 41351
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __ExecuteUbergraph_GA_Motor_DroneBase_FunctionParams
		{
			// Token: 0x04032EDB RID: 208603
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
