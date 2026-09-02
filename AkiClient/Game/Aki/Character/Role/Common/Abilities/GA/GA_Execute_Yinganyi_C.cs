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
	// Token: 0x02004084 RID: 16516
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Abilities/GA/GA_Execute_Yinganyi.GA_Execute_Yinganyi_C")]
	[UnrealStructLayout(1512, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1512)]
	public class GA_Execute_Yinganyi_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602AF50 RID: 175952 RVA: 0x00A6B303 File Offset: 0x00A69503
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_Execute_Yinganyi_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Execute_Yinganyi.GA_Execute_Yinganyi_C");
			}
			return GA_Execute_Yinganyi_C._ClassPtr;
		}

		// Token: 0x0602AF51 RID: 175953 RVA: 0x00A6B328 File Offset: 0x00A69528
		public GA_Execute_Yinganyi_C() : this(BuiltinUtils.AllocNativeUObject(GA_Execute_Yinganyi_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602AF52 RID: 175954 RVA: 0x00A6B350 File Offset: 0x00A69550
		[NullableContext(1)]
		public GA_Execute_Yinganyi_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_Execute_Yinganyi_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007057 RID: 28759
		// (get) Token: 0x0602AF53 RID: 175955 RVA: 0x00A6B384 File Offset: 0x00A69584
		// (set) Token: 0x0602AF54 RID: 175956 RVA: 0x00A6B3BD File Offset: 0x00A695BD
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_Execute_Yinganyi_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_Execute_Yinganyi_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007058 RID: 28760
		// (get) Token: 0x0602AF55 RID: 175957 RVA: 0x00A6B3DE File Offset: 0x00A695DE
		// (set) Token: 0x0602AF56 RID: 175958 RVA: 0x00A6B3EE File Offset: 0x00A695EE
		public unsafe bool 落地攻击
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Execute_Yinganyi_C.__PropertyOffset_1) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Execute_Yinganyi_C.__PropertyOffset_1) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007059 RID: 28761
		// (get) Token: 0x0602AF57 RID: 175959 RVA: 0x00A6B3FF File Offset: 0x00A695FF
		// (set) Token: 0x0602AF58 RID: 175960 RVA: 0x00A6B40F File Offset: 0x00A6960F
		public unsafe float BlockTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Execute_Yinganyi_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Execute_Yinganyi_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x1700705A RID: 28762
		// (get) Token: 0x0602AF59 RID: 175961 RVA: 0x00A6B420 File Offset: 0x00A69620
		// (set) Token: 0x0602AF5A RID: 175962 RVA: 0x00A6B434 File Offset: 0x00A69634
		public unsafe FName 追踪插槽
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Execute_Yinganyi_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Execute_Yinganyi_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x1700705B RID: 28763
		// (get) Token: 0x0602AF5B RID: 175963 RVA: 0x00A6B449 File Offset: 0x00A69649
		// (set) Token: 0x0602AF5C RID: 175964 RVA: 0x00A6B459 File Offset: 0x00A69659
		public unsafe int 特效Handle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Execute_Yinganyi_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Execute_Yinganyi_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x0602AF5D RID: 175965 RVA: 0x00A6B46A File Offset: 0x00A6966A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnTick_5D118C384AE61F1C80292E812000D24B()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Execute_Yinganyi_C.__OnTick_5D118C384AE61F1C80292E812000D24B_NativeFunctionPtr, null);
		}

		// Token: 0x0602AF5E RID: 175966 RVA: 0x00A6B47E File Offset: 0x00A6967E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCancelled_5D118C384AE61F1C80292E812000D24B()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Execute_Yinganyi_C.__OnCancelled_5D118C384AE61F1C80292E812000D24B_NativeFunctionPtr, null);
		}

		// Token: 0x0602AF5F RID: 175967 RVA: 0x00A6B492 File Offset: 0x00A69692
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnInterrupted_5D118C384AE61F1C80292E812000D24B()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Execute_Yinganyi_C.__OnInterrupted_5D118C384AE61F1C80292E812000D24B_NativeFunctionPtr, null);
		}

		// Token: 0x0602AF60 RID: 175968 RVA: 0x00A6B4A6 File Offset: 0x00A696A6
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnBlendOut_5D118C384AE61F1C80292E812000D24B()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Execute_Yinganyi_C.__OnBlendOut_5D118C384AE61F1C80292E812000D24B_NativeFunctionPtr, null);
		}

		// Token: 0x0602AF61 RID: 175969 RVA: 0x00A6B4BA File Offset: 0x00A696BA
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCompleted_5D118C384AE61F1C80292E812000D24B()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Execute_Yinganyi_C.__OnCompleted_5D118C384AE61F1C80292E812000D24B_NativeFunctionPtr, null);
		}

		// Token: 0x0602AF62 RID: 175970 RVA: 0x00A6B4D0 File Offset: 0x00A696D0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void K2_OnEndAbility(bool bWasCancelled)
		{
			GA_Execute_Yinganyi_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Execute_Yinganyi_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Execute_Yinganyi_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Execute_Yinganyi_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Execute_Yinganyi_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602AF63 RID: 175971 RVA: 0x00A6B518 File Offset: 0x00A69718
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void K2_OnEndAbility_Implementation(bool bWasCancelled)
		{
			GA_Execute_Yinganyi_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Execute_Yinganyi_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Execute_Yinganyi_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Execute_Yinganyi_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Execute_Yinganyi_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602AF64 RID: 175972 RVA: 0x00A6B55F File Offset: 0x00A6975F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Execute_Yinganyi_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x0602AF65 RID: 175973 RVA: 0x00A6B573 File Offset: 0x00A69773
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Execute_Yinganyi_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602AF66 RID: 175974 RVA: 0x00A6B588 File Offset: 0x00A69788
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_Execute_Yinganyi(int EntryPoint)
		{
			GA_Execute_Yinganyi_C.__ExecuteUbergraph_GA_Execute_Yinganyi_FunctionParams* ptr = stackalloc GA_Execute_Yinganyi_C.__ExecuteUbergraph_GA_Execute_Yinganyi_FunctionParams[(UIntPtr)879] + 15L / (long)sizeof(GA_Execute_Yinganyi_C.__ExecuteUbergraph_GA_Execute_Yinganyi_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Execute_Yinganyi_C.__ExecuteUbergraph_GA_Execute_Yinganyi_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Execute_Yinganyi_C.__ExecuteUbergraph_GA_Execute_Yinganyi_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602AF67 RID: 175975 RVA: 0x00A6B5D2 File Offset: 0x00A697D2
		protected GA_Execute_Yinganyi_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401778F RID: 96143
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Execute_Yinganyi.GA_Execute_Yinganyi_C";

		// Token: 0x04017790 RID: 96144
		private static IntPtr _ClassPtr;

		// Token: 0x04017791 RID: 96145
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04017792 RID: 96146
		internal new static int __PropertyOffset_0;

		// Token: 0x04017793 RID: 96147
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04017794 RID: 96148
		internal new static int __PropertyOffset_1;

		// Token: 0x04017795 RID: 96149
		internal new static int __PropertyOffset_2;

		// Token: 0x04017796 RID: 96150
		internal new static int __PropertyOffset_3;

		// Token: 0x04017797 RID: 96151
		internal static int __PropertyOffset_4;

		// Token: 0x04017798 RID: 96152
		private static IntPtr __OnTick_5D118C384AE61F1C80292E812000D24B_NativeFunctionPtr;

		// Token: 0x04017799 RID: 96153
		private static IntPtr __OnCancelled_5D118C384AE61F1C80292E812000D24B_NativeFunctionPtr;

		// Token: 0x0401779A RID: 96154
		private static IntPtr __OnInterrupted_5D118C384AE61F1C80292E812000D24B_NativeFunctionPtr;

		// Token: 0x0401779B RID: 96155
		private static IntPtr __OnBlendOut_5D118C384AE61F1C80292E812000D24B_NativeFunctionPtr;

		// Token: 0x0401779C RID: 96156
		private static IntPtr __OnCompleted_5D118C384AE61F1C80292E812000D24B_NativeFunctionPtr;

		// Token: 0x0401779D RID: 96157
		private static IntPtr __K2_OnEndAbility_NativeFunctionPtr;

		// Token: 0x0401779E RID: 96158
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x0401779F RID: 96159
		private static IntPtr __ExecuteUbergraph_GA_Execute_Yinganyi_NativeFunctionPtr;

		// Token: 0x0200A2A2 RID: 41634
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __K2_OnEndAbility_FunctionParams
		{
			// Token: 0x04033055 RID: 208981
			[FieldOffset(0)]
			public bool bWasCancelled;
		}

		// Token: 0x0200A2A3 RID: 41635
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 864)]
		protected ref struct __ExecuteUbergraph_GA_Execute_Yinganyi_FunctionParams
		{
			// Token: 0x04033056 RID: 208982
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
