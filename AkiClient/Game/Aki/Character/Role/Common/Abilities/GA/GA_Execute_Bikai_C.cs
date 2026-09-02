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
	// Token: 0x02004080 RID: 16512
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Abilities/GA/GA_Execute_Bikai.GA_Execute_Bikai_C")]
	[UnrealStructLayout(1512, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1512)]
	public class GA_Execute_Bikai_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602AEF0 RID: 175856 RVA: 0x00A6A7A3 File Offset: 0x00A689A3
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_Execute_Bikai_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Execute_Bikai.GA_Execute_Bikai_C");
			}
			return GA_Execute_Bikai_C._ClassPtr;
		}

		// Token: 0x0602AEF1 RID: 175857 RVA: 0x00A6A7C8 File Offset: 0x00A689C8
		public GA_Execute_Bikai_C() : this(BuiltinUtils.AllocNativeUObject(GA_Execute_Bikai_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602AEF2 RID: 175858 RVA: 0x00A6A7F0 File Offset: 0x00A689F0
		[NullableContext(1)]
		public GA_Execute_Bikai_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_Execute_Bikai_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007043 RID: 28739
		// (get) Token: 0x0602AEF3 RID: 175859 RVA: 0x00A6A824 File Offset: 0x00A68A24
		// (set) Token: 0x0602AEF4 RID: 175860 RVA: 0x00A6A85D File Offset: 0x00A68A5D
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_Execute_Bikai_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_Execute_Bikai_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007044 RID: 28740
		// (get) Token: 0x0602AEF5 RID: 175861 RVA: 0x00A6A87E File Offset: 0x00A68A7E
		// (set) Token: 0x0602AEF6 RID: 175862 RVA: 0x00A6A88E File Offset: 0x00A68A8E
		public unsafe bool 落地攻击
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Execute_Bikai_C.__PropertyOffset_1) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Execute_Bikai_C.__PropertyOffset_1) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007045 RID: 28741
		// (get) Token: 0x0602AEF7 RID: 175863 RVA: 0x00A6A89F File Offset: 0x00A68A9F
		// (set) Token: 0x0602AEF8 RID: 175864 RVA: 0x00A6A8AF File Offset: 0x00A68AAF
		public unsafe float BlockTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Execute_Bikai_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Execute_Bikai_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17007046 RID: 28742
		// (get) Token: 0x0602AEF9 RID: 175865 RVA: 0x00A6A8C0 File Offset: 0x00A68AC0
		// (set) Token: 0x0602AEFA RID: 175866 RVA: 0x00A6A8D4 File Offset: 0x00A68AD4
		public unsafe FName 追踪插槽
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Execute_Bikai_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Execute_Bikai_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17007047 RID: 28743
		// (get) Token: 0x0602AEFB RID: 175867 RVA: 0x00A6A8E9 File Offset: 0x00A68AE9
		// (set) Token: 0x0602AEFC RID: 175868 RVA: 0x00A6A8F9 File Offset: 0x00A68AF9
		public unsafe int 特效Handle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Execute_Bikai_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Execute_Bikai_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x0602AEFD RID: 175869 RVA: 0x00A6A90A File Offset: 0x00A68B0A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnTick_5D118C384AE61F1C80292E81152A15CB()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Execute_Bikai_C.__OnTick_5D118C384AE61F1C80292E81152A15CB_NativeFunctionPtr, null);
		}

		// Token: 0x0602AEFE RID: 175870 RVA: 0x00A6A91E File Offset: 0x00A68B1E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCancelled_5D118C384AE61F1C80292E81152A15CB()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Execute_Bikai_C.__OnCancelled_5D118C384AE61F1C80292E81152A15CB_NativeFunctionPtr, null);
		}

		// Token: 0x0602AEFF RID: 175871 RVA: 0x00A6A932 File Offset: 0x00A68B32
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnInterrupted_5D118C384AE61F1C80292E81152A15CB()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Execute_Bikai_C.__OnInterrupted_5D118C384AE61F1C80292E81152A15CB_NativeFunctionPtr, null);
		}

		// Token: 0x0602AF00 RID: 175872 RVA: 0x00A6A946 File Offset: 0x00A68B46
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnBlendOut_5D118C384AE61F1C80292E81152A15CB()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Execute_Bikai_C.__OnBlendOut_5D118C384AE61F1C80292E81152A15CB_NativeFunctionPtr, null);
		}

		// Token: 0x0602AF01 RID: 175873 RVA: 0x00A6A95A File Offset: 0x00A68B5A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCompleted_5D118C384AE61F1C80292E81152A15CB()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Execute_Bikai_C.__OnCompleted_5D118C384AE61F1C80292E81152A15CB_NativeFunctionPtr, null);
		}

		// Token: 0x0602AF02 RID: 175874 RVA: 0x00A6A970 File Offset: 0x00A68B70
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void K2_OnEndAbility(bool bWasCancelled)
		{
			GA_Execute_Bikai_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Execute_Bikai_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Execute_Bikai_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Execute_Bikai_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Execute_Bikai_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602AF03 RID: 175875 RVA: 0x00A6A9B8 File Offset: 0x00A68BB8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void K2_OnEndAbility_Implementation(bool bWasCancelled)
		{
			GA_Execute_Bikai_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Execute_Bikai_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Execute_Bikai_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Execute_Bikai_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Execute_Bikai_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602AF04 RID: 175876 RVA: 0x00A6A9FF File Offset: 0x00A68BFF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Execute_Bikai_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x0602AF05 RID: 175877 RVA: 0x00A6AA13 File Offset: 0x00A68C13
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Execute_Bikai_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602AF06 RID: 175878 RVA: 0x00A6AA28 File Offset: 0x00A68C28
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_Execute_Bikai(int EntryPoint)
		{
			GA_Execute_Bikai_C.__ExecuteUbergraph_GA_Execute_Bikai_FunctionParams* ptr = stackalloc GA_Execute_Bikai_C.__ExecuteUbergraph_GA_Execute_Bikai_FunctionParams[(UIntPtr)879] + 15L / (long)sizeof(GA_Execute_Bikai_C.__ExecuteUbergraph_GA_Execute_Bikai_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Execute_Bikai_C.__ExecuteUbergraph_GA_Execute_Bikai_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Execute_Bikai_C.__ExecuteUbergraph_GA_Execute_Bikai_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602AF07 RID: 175879 RVA: 0x00A6AA72 File Offset: 0x00A68C72
		protected GA_Execute_Bikai_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401774B RID: 96075
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Execute_Bikai.GA_Execute_Bikai_C";

		// Token: 0x0401774C RID: 96076
		private static IntPtr _ClassPtr;

		// Token: 0x0401774D RID: 96077
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401774E RID: 96078
		internal new static int __PropertyOffset_0;

		// Token: 0x0401774F RID: 96079
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04017750 RID: 96080
		internal new static int __PropertyOffset_1;

		// Token: 0x04017751 RID: 96081
		internal new static int __PropertyOffset_2;

		// Token: 0x04017752 RID: 96082
		internal new static int __PropertyOffset_3;

		// Token: 0x04017753 RID: 96083
		internal static int __PropertyOffset_4;

		// Token: 0x04017754 RID: 96084
		private static IntPtr __OnTick_5D118C384AE61F1C80292E81152A15CB_NativeFunctionPtr;

		// Token: 0x04017755 RID: 96085
		private static IntPtr __OnCancelled_5D118C384AE61F1C80292E81152A15CB_NativeFunctionPtr;

		// Token: 0x04017756 RID: 96086
		private static IntPtr __OnInterrupted_5D118C384AE61F1C80292E81152A15CB_NativeFunctionPtr;

		// Token: 0x04017757 RID: 96087
		private static IntPtr __OnBlendOut_5D118C384AE61F1C80292E81152A15CB_NativeFunctionPtr;

		// Token: 0x04017758 RID: 96088
		private static IntPtr __OnCompleted_5D118C384AE61F1C80292E81152A15CB_NativeFunctionPtr;

		// Token: 0x04017759 RID: 96089
		private static IntPtr __K2_OnEndAbility_NativeFunctionPtr;

		// Token: 0x0401775A RID: 96090
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x0401775B RID: 96091
		private static IntPtr __ExecuteUbergraph_GA_Execute_Bikai_NativeFunctionPtr;

		// Token: 0x0200A29A RID: 41626
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __K2_OnEndAbility_FunctionParams
		{
			// Token: 0x0403304D RID: 208973
			[FieldOffset(0)]
			public bool bWasCancelled;
		}

		// Token: 0x0200A29B RID: 41627
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 864)]
		protected ref struct __ExecuteUbergraph_GA_Execute_Bikai_FunctionParams
		{
			// Token: 0x0403304E RID: 208974
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
