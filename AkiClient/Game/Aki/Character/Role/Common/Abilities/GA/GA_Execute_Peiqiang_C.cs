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
	// Token: 0x02004082 RID: 16514
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Abilities/GA/GA_Execute_Peiqiang.GA_Execute_Peiqiang_C")]
	[UnrealStructLayout(1512, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1512)]
	public class GA_Execute_Peiqiang_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602AF20 RID: 175904 RVA: 0x00A6AD53 File Offset: 0x00A68F53
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_Execute_Peiqiang_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Execute_Peiqiang.GA_Execute_Peiqiang_C");
			}
			return GA_Execute_Peiqiang_C._ClassPtr;
		}

		// Token: 0x0602AF21 RID: 175905 RVA: 0x00A6AD78 File Offset: 0x00A68F78
		public GA_Execute_Peiqiang_C() : this(BuiltinUtils.AllocNativeUObject(GA_Execute_Peiqiang_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602AF22 RID: 175906 RVA: 0x00A6ADA0 File Offset: 0x00A68FA0
		[NullableContext(1)]
		public GA_Execute_Peiqiang_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_Execute_Peiqiang_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700704D RID: 28749
		// (get) Token: 0x0602AF23 RID: 175907 RVA: 0x00A6ADD4 File Offset: 0x00A68FD4
		// (set) Token: 0x0602AF24 RID: 175908 RVA: 0x00A6AE0D File Offset: 0x00A6900D
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_Execute_Peiqiang_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_Execute_Peiqiang_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700704E RID: 28750
		// (get) Token: 0x0602AF25 RID: 175909 RVA: 0x00A6AE2E File Offset: 0x00A6902E
		// (set) Token: 0x0602AF26 RID: 175910 RVA: 0x00A6AE3E File Offset: 0x00A6903E
		public unsafe bool 落地攻击
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Execute_Peiqiang_C.__PropertyOffset_1) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Execute_Peiqiang_C.__PropertyOffset_1) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700704F RID: 28751
		// (get) Token: 0x0602AF27 RID: 175911 RVA: 0x00A6AE4F File Offset: 0x00A6904F
		// (set) Token: 0x0602AF28 RID: 175912 RVA: 0x00A6AE5F File Offset: 0x00A6905F
		public unsafe float BlockTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Execute_Peiqiang_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Execute_Peiqiang_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17007050 RID: 28752
		// (get) Token: 0x0602AF29 RID: 175913 RVA: 0x00A6AE70 File Offset: 0x00A69070
		// (set) Token: 0x0602AF2A RID: 175914 RVA: 0x00A6AE84 File Offset: 0x00A69084
		public unsafe FName 追踪插槽
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Execute_Peiqiang_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Execute_Peiqiang_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17007051 RID: 28753
		// (get) Token: 0x0602AF2B RID: 175915 RVA: 0x00A6AE99 File Offset: 0x00A69099
		// (set) Token: 0x0602AF2C RID: 175916 RVA: 0x00A6AEA9 File Offset: 0x00A690A9
		public unsafe int 特效Handle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Execute_Peiqiang_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Execute_Peiqiang_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x0602AF2D RID: 175917 RVA: 0x00A6AEBA File Offset: 0x00A690BA
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnTick_5D118C384AE61F1C80292E815C4E2C76()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Execute_Peiqiang_C.__OnTick_5D118C384AE61F1C80292E815C4E2C76_NativeFunctionPtr, null);
		}

		// Token: 0x0602AF2E RID: 175918 RVA: 0x00A6AECE File Offset: 0x00A690CE
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCancelled_5D118C384AE61F1C80292E815C4E2C76()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Execute_Peiqiang_C.__OnCancelled_5D118C384AE61F1C80292E815C4E2C76_NativeFunctionPtr, null);
		}

		// Token: 0x0602AF2F RID: 175919 RVA: 0x00A6AEE2 File Offset: 0x00A690E2
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnInterrupted_5D118C384AE61F1C80292E815C4E2C76()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Execute_Peiqiang_C.__OnInterrupted_5D118C384AE61F1C80292E815C4E2C76_NativeFunctionPtr, null);
		}

		// Token: 0x0602AF30 RID: 175920 RVA: 0x00A6AEF6 File Offset: 0x00A690F6
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnBlendOut_5D118C384AE61F1C80292E815C4E2C76()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Execute_Peiqiang_C.__OnBlendOut_5D118C384AE61F1C80292E815C4E2C76_NativeFunctionPtr, null);
		}

		// Token: 0x0602AF31 RID: 175921 RVA: 0x00A6AF0A File Offset: 0x00A6910A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCompleted_5D118C384AE61F1C80292E815C4E2C76()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Execute_Peiqiang_C.__OnCompleted_5D118C384AE61F1C80292E815C4E2C76_NativeFunctionPtr, null);
		}

		// Token: 0x0602AF32 RID: 175922 RVA: 0x00A6AF20 File Offset: 0x00A69120
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void K2_OnEndAbility(bool bWasCancelled)
		{
			GA_Execute_Peiqiang_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Execute_Peiqiang_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Execute_Peiqiang_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Execute_Peiqiang_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Execute_Peiqiang_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602AF33 RID: 175923 RVA: 0x00A6AF68 File Offset: 0x00A69168
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void K2_OnEndAbility_Implementation(bool bWasCancelled)
		{
			GA_Execute_Peiqiang_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Execute_Peiqiang_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Execute_Peiqiang_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Execute_Peiqiang_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Execute_Peiqiang_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602AF34 RID: 175924 RVA: 0x00A6AFAF File Offset: 0x00A691AF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Execute_Peiqiang_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x0602AF35 RID: 175925 RVA: 0x00A6AFC3 File Offset: 0x00A691C3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Execute_Peiqiang_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602AF36 RID: 175926 RVA: 0x00A6AFD8 File Offset: 0x00A691D8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_Execute_Peiqiang(int EntryPoint)
		{
			GA_Execute_Peiqiang_C.__ExecuteUbergraph_GA_Execute_Peiqiang_FunctionParams* ptr = stackalloc GA_Execute_Peiqiang_C.__ExecuteUbergraph_GA_Execute_Peiqiang_FunctionParams[(UIntPtr)879] + 15L / (long)sizeof(GA_Execute_Peiqiang_C.__ExecuteUbergraph_GA_Execute_Peiqiang_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Execute_Peiqiang_C.__ExecuteUbergraph_GA_Execute_Peiqiang_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Execute_Peiqiang_C.__ExecuteUbergraph_GA_Execute_Peiqiang_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602AF37 RID: 175927 RVA: 0x00A6B022 File Offset: 0x00A69222
		protected GA_Execute_Peiqiang_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401776D RID: 96109
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Execute_Peiqiang.GA_Execute_Peiqiang_C";

		// Token: 0x0401776E RID: 96110
		private static IntPtr _ClassPtr;

		// Token: 0x0401776F RID: 96111
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04017770 RID: 96112
		internal new static int __PropertyOffset_0;

		// Token: 0x04017771 RID: 96113
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04017772 RID: 96114
		internal new static int __PropertyOffset_1;

		// Token: 0x04017773 RID: 96115
		internal new static int __PropertyOffset_2;

		// Token: 0x04017774 RID: 96116
		internal new static int __PropertyOffset_3;

		// Token: 0x04017775 RID: 96117
		internal static int __PropertyOffset_4;

		// Token: 0x04017776 RID: 96118
		private static IntPtr __OnTick_5D118C384AE61F1C80292E815C4E2C76_NativeFunctionPtr;

		// Token: 0x04017777 RID: 96119
		private static IntPtr __OnCancelled_5D118C384AE61F1C80292E815C4E2C76_NativeFunctionPtr;

		// Token: 0x04017778 RID: 96120
		private static IntPtr __OnInterrupted_5D118C384AE61F1C80292E815C4E2C76_NativeFunctionPtr;

		// Token: 0x04017779 RID: 96121
		private static IntPtr __OnBlendOut_5D118C384AE61F1C80292E815C4E2C76_NativeFunctionPtr;

		// Token: 0x0401777A RID: 96122
		private static IntPtr __OnCompleted_5D118C384AE61F1C80292E815C4E2C76_NativeFunctionPtr;

		// Token: 0x0401777B RID: 96123
		private static IntPtr __K2_OnEndAbility_NativeFunctionPtr;

		// Token: 0x0401777C RID: 96124
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x0401777D RID: 96125
		private static IntPtr __ExecuteUbergraph_GA_Execute_Peiqiang_NativeFunctionPtr;

		// Token: 0x0200A29E RID: 41630
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __K2_OnEndAbility_FunctionParams
		{
			// Token: 0x04033051 RID: 208977
			[FieldOffset(0)]
			public bool bWasCancelled;
		}

		// Token: 0x0200A29F RID: 41631
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 864)]
		protected ref struct __ExecuteUbergraph_GA_Execute_Peiqiang_FunctionParams
		{
			// Token: 0x04033052 RID: 208978
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
