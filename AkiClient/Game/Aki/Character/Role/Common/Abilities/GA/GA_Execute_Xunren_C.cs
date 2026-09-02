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
	// Token: 0x02004083 RID: 16515
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Abilities/GA/GA_Execute_Xunren.GA_Execute_Xunren_C")]
	[UnrealStructLayout(1512, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1512)]
	public class GA_Execute_Xunren_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602AF38 RID: 175928 RVA: 0x00A6B02B File Offset: 0x00A6922B
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_Execute_Xunren_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Execute_Xunren.GA_Execute_Xunren_C");
			}
			return GA_Execute_Xunren_C._ClassPtr;
		}

		// Token: 0x0602AF39 RID: 175929 RVA: 0x00A6B050 File Offset: 0x00A69250
		public GA_Execute_Xunren_C() : this(BuiltinUtils.AllocNativeUObject(GA_Execute_Xunren_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602AF3A RID: 175930 RVA: 0x00A6B078 File Offset: 0x00A69278
		[NullableContext(1)]
		public GA_Execute_Xunren_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_Execute_Xunren_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007052 RID: 28754
		// (get) Token: 0x0602AF3B RID: 175931 RVA: 0x00A6B0AC File Offset: 0x00A692AC
		// (set) Token: 0x0602AF3C RID: 175932 RVA: 0x00A6B0E5 File Offset: 0x00A692E5
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_Execute_Xunren_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_Execute_Xunren_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007053 RID: 28755
		// (get) Token: 0x0602AF3D RID: 175933 RVA: 0x00A6B106 File Offset: 0x00A69306
		// (set) Token: 0x0602AF3E RID: 175934 RVA: 0x00A6B116 File Offset: 0x00A69316
		public unsafe bool 落地攻击
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Execute_Xunren_C.__PropertyOffset_1) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Execute_Xunren_C.__PropertyOffset_1) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007054 RID: 28756
		// (get) Token: 0x0602AF3F RID: 175935 RVA: 0x00A6B127 File Offset: 0x00A69327
		// (set) Token: 0x0602AF40 RID: 175936 RVA: 0x00A6B137 File Offset: 0x00A69337
		public unsafe float BlockTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Execute_Xunren_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Execute_Xunren_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17007055 RID: 28757
		// (get) Token: 0x0602AF41 RID: 175937 RVA: 0x00A6B148 File Offset: 0x00A69348
		// (set) Token: 0x0602AF42 RID: 175938 RVA: 0x00A6B15C File Offset: 0x00A6935C
		public unsafe FName 追踪插槽
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Execute_Xunren_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Execute_Xunren_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17007056 RID: 28758
		// (get) Token: 0x0602AF43 RID: 175939 RVA: 0x00A6B171 File Offset: 0x00A69371
		// (set) Token: 0x0602AF44 RID: 175940 RVA: 0x00A6B181 File Offset: 0x00A69381
		public unsafe int 特效Handle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Execute_Xunren_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Execute_Xunren_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x0602AF45 RID: 175941 RVA: 0x00A6B192 File Offset: 0x00A69392
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnTick_5D118C384AE61F1C80292E81FF123CC3()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Execute_Xunren_C.__OnTick_5D118C384AE61F1C80292E81FF123CC3_NativeFunctionPtr, null);
		}

		// Token: 0x0602AF46 RID: 175942 RVA: 0x00A6B1A6 File Offset: 0x00A693A6
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCancelled_5D118C384AE61F1C80292E81FF123CC3()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Execute_Xunren_C.__OnCancelled_5D118C384AE61F1C80292E81FF123CC3_NativeFunctionPtr, null);
		}

		// Token: 0x0602AF47 RID: 175943 RVA: 0x00A6B1BA File Offset: 0x00A693BA
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnInterrupted_5D118C384AE61F1C80292E81FF123CC3()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Execute_Xunren_C.__OnInterrupted_5D118C384AE61F1C80292E81FF123CC3_NativeFunctionPtr, null);
		}

		// Token: 0x0602AF48 RID: 175944 RVA: 0x00A6B1CE File Offset: 0x00A693CE
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnBlendOut_5D118C384AE61F1C80292E81FF123CC3()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Execute_Xunren_C.__OnBlendOut_5D118C384AE61F1C80292E81FF123CC3_NativeFunctionPtr, null);
		}

		// Token: 0x0602AF49 RID: 175945 RVA: 0x00A6B1E2 File Offset: 0x00A693E2
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCompleted_5D118C384AE61F1C80292E81FF123CC3()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Execute_Xunren_C.__OnCompleted_5D118C384AE61F1C80292E81FF123CC3_NativeFunctionPtr, null);
		}

		// Token: 0x0602AF4A RID: 175946 RVA: 0x00A6B1F8 File Offset: 0x00A693F8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void K2_OnEndAbility(bool bWasCancelled)
		{
			GA_Execute_Xunren_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Execute_Xunren_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Execute_Xunren_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Execute_Xunren_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Execute_Xunren_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602AF4B RID: 175947 RVA: 0x00A6B240 File Offset: 0x00A69440
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void K2_OnEndAbility_Implementation(bool bWasCancelled)
		{
			GA_Execute_Xunren_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Execute_Xunren_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Execute_Xunren_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Execute_Xunren_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Execute_Xunren_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602AF4C RID: 175948 RVA: 0x00A6B287 File Offset: 0x00A69487
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Execute_Xunren_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x0602AF4D RID: 175949 RVA: 0x00A6B29B File Offset: 0x00A6949B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Execute_Xunren_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602AF4E RID: 175950 RVA: 0x00A6B2B0 File Offset: 0x00A694B0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_Execute_Xunren(int EntryPoint)
		{
			GA_Execute_Xunren_C.__ExecuteUbergraph_GA_Execute_Xunren_FunctionParams* ptr = stackalloc GA_Execute_Xunren_C.__ExecuteUbergraph_GA_Execute_Xunren_FunctionParams[(UIntPtr)879] + 15L / (long)sizeof(GA_Execute_Xunren_C.__ExecuteUbergraph_GA_Execute_Xunren_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Execute_Xunren_C.__ExecuteUbergraph_GA_Execute_Xunren_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Execute_Xunren_C.__ExecuteUbergraph_GA_Execute_Xunren_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602AF4F RID: 175951 RVA: 0x00A6B2FA File Offset: 0x00A694FA
		protected GA_Execute_Xunren_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401777E RID: 96126
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Execute_Xunren.GA_Execute_Xunren_C";

		// Token: 0x0401777F RID: 96127
		private static IntPtr _ClassPtr;

		// Token: 0x04017780 RID: 96128
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04017781 RID: 96129
		internal new static int __PropertyOffset_0;

		// Token: 0x04017782 RID: 96130
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04017783 RID: 96131
		internal new static int __PropertyOffset_1;

		// Token: 0x04017784 RID: 96132
		internal new static int __PropertyOffset_2;

		// Token: 0x04017785 RID: 96133
		internal new static int __PropertyOffset_3;

		// Token: 0x04017786 RID: 96134
		internal static int __PropertyOffset_4;

		// Token: 0x04017787 RID: 96135
		private static IntPtr __OnTick_5D118C384AE61F1C80292E81FF123CC3_NativeFunctionPtr;

		// Token: 0x04017788 RID: 96136
		private static IntPtr __OnCancelled_5D118C384AE61F1C80292E81FF123CC3_NativeFunctionPtr;

		// Token: 0x04017789 RID: 96137
		private static IntPtr __OnInterrupted_5D118C384AE61F1C80292E81FF123CC3_NativeFunctionPtr;

		// Token: 0x0401778A RID: 96138
		private static IntPtr __OnBlendOut_5D118C384AE61F1C80292E81FF123CC3_NativeFunctionPtr;

		// Token: 0x0401778B RID: 96139
		private static IntPtr __OnCompleted_5D118C384AE61F1C80292E81FF123CC3_NativeFunctionPtr;

		// Token: 0x0401778C RID: 96140
		private static IntPtr __K2_OnEndAbility_NativeFunctionPtr;

		// Token: 0x0401778D RID: 96141
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x0401778E RID: 96142
		private static IntPtr __ExecuteUbergraph_GA_Execute_Xunren_NativeFunctionPtr;

		// Token: 0x0200A2A0 RID: 41632
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __K2_OnEndAbility_FunctionParams
		{
			// Token: 0x04033053 RID: 208979
			[FieldOffset(0)]
			public bool bWasCancelled;
		}

		// Token: 0x0200A2A1 RID: 41633
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 864)]
		protected ref struct __ExecuteUbergraph_GA_Execute_Xunren_FunctionParams
		{
			// Token: 0x04033054 RID: 208980
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
