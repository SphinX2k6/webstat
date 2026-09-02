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
	// Token: 0x02004081 RID: 16513
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Abilities/GA/GA_Execute_Dajian.GA_Execute_Dajian_C")]
	[UnrealStructLayout(1512, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1512)]
	public class GA_Execute_Dajian_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602AF08 RID: 175880 RVA: 0x00A6AA7B File Offset: 0x00A68C7B
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_Execute_Dajian_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Execute_Dajian.GA_Execute_Dajian_C");
			}
			return GA_Execute_Dajian_C._ClassPtr;
		}

		// Token: 0x0602AF09 RID: 175881 RVA: 0x00A6AAA0 File Offset: 0x00A68CA0
		public GA_Execute_Dajian_C() : this(BuiltinUtils.AllocNativeUObject(GA_Execute_Dajian_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602AF0A RID: 175882 RVA: 0x00A6AAC8 File Offset: 0x00A68CC8
		[NullableContext(1)]
		public GA_Execute_Dajian_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_Execute_Dajian_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007048 RID: 28744
		// (get) Token: 0x0602AF0B RID: 175883 RVA: 0x00A6AAFC File Offset: 0x00A68CFC
		// (set) Token: 0x0602AF0C RID: 175884 RVA: 0x00A6AB35 File Offset: 0x00A68D35
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_Execute_Dajian_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_Execute_Dajian_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007049 RID: 28745
		// (get) Token: 0x0602AF0D RID: 175885 RVA: 0x00A6AB56 File Offset: 0x00A68D56
		// (set) Token: 0x0602AF0E RID: 175886 RVA: 0x00A6AB66 File Offset: 0x00A68D66
		public unsafe bool 落地攻击
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Execute_Dajian_C.__PropertyOffset_1) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Execute_Dajian_C.__PropertyOffset_1) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700704A RID: 28746
		// (get) Token: 0x0602AF0F RID: 175887 RVA: 0x00A6AB77 File Offset: 0x00A68D77
		// (set) Token: 0x0602AF10 RID: 175888 RVA: 0x00A6AB87 File Offset: 0x00A68D87
		public unsafe float BlockTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Execute_Dajian_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Execute_Dajian_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x1700704B RID: 28747
		// (get) Token: 0x0602AF11 RID: 175889 RVA: 0x00A6AB98 File Offset: 0x00A68D98
		// (set) Token: 0x0602AF12 RID: 175890 RVA: 0x00A6ABAC File Offset: 0x00A68DAC
		public unsafe FName 追踪插槽
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Execute_Dajian_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Execute_Dajian_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x1700704C RID: 28748
		// (get) Token: 0x0602AF13 RID: 175891 RVA: 0x00A6ABC1 File Offset: 0x00A68DC1
		// (set) Token: 0x0602AF14 RID: 175892 RVA: 0x00A6ABD1 File Offset: 0x00A68DD1
		public unsafe int 特效Handle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Execute_Dajian_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Execute_Dajian_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x0602AF15 RID: 175893 RVA: 0x00A6ABE2 File Offset: 0x00A68DE2
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnTick_5D118C384AE61F1C80292E8171BB25F0()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Execute_Dajian_C.__OnTick_5D118C384AE61F1C80292E8171BB25F0_NativeFunctionPtr, null);
		}

		// Token: 0x0602AF16 RID: 175894 RVA: 0x00A6ABF6 File Offset: 0x00A68DF6
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCancelled_5D118C384AE61F1C80292E8171BB25F0()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Execute_Dajian_C.__OnCancelled_5D118C384AE61F1C80292E8171BB25F0_NativeFunctionPtr, null);
		}

		// Token: 0x0602AF17 RID: 175895 RVA: 0x00A6AC0A File Offset: 0x00A68E0A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnInterrupted_5D118C384AE61F1C80292E8171BB25F0()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Execute_Dajian_C.__OnInterrupted_5D118C384AE61F1C80292E8171BB25F0_NativeFunctionPtr, null);
		}

		// Token: 0x0602AF18 RID: 175896 RVA: 0x00A6AC1E File Offset: 0x00A68E1E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnBlendOut_5D118C384AE61F1C80292E8171BB25F0()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Execute_Dajian_C.__OnBlendOut_5D118C384AE61F1C80292E8171BB25F0_NativeFunctionPtr, null);
		}

		// Token: 0x0602AF19 RID: 175897 RVA: 0x00A6AC32 File Offset: 0x00A68E32
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCompleted_5D118C384AE61F1C80292E8171BB25F0()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Execute_Dajian_C.__OnCompleted_5D118C384AE61F1C80292E8171BB25F0_NativeFunctionPtr, null);
		}

		// Token: 0x0602AF1A RID: 175898 RVA: 0x00A6AC48 File Offset: 0x00A68E48
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void K2_OnEndAbility(bool bWasCancelled)
		{
			GA_Execute_Dajian_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Execute_Dajian_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Execute_Dajian_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Execute_Dajian_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Execute_Dajian_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602AF1B RID: 175899 RVA: 0x00A6AC90 File Offset: 0x00A68E90
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void K2_OnEndAbility_Implementation(bool bWasCancelled)
		{
			GA_Execute_Dajian_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Execute_Dajian_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Execute_Dajian_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Execute_Dajian_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Execute_Dajian_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602AF1C RID: 175900 RVA: 0x00A6ACD7 File Offset: 0x00A68ED7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Execute_Dajian_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x0602AF1D RID: 175901 RVA: 0x00A6ACEB File Offset: 0x00A68EEB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Execute_Dajian_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602AF1E RID: 175902 RVA: 0x00A6AD00 File Offset: 0x00A68F00
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_Execute_Dajian(int EntryPoint)
		{
			GA_Execute_Dajian_C.__ExecuteUbergraph_GA_Execute_Dajian_FunctionParams* ptr = stackalloc GA_Execute_Dajian_C.__ExecuteUbergraph_GA_Execute_Dajian_FunctionParams[(UIntPtr)879] + 15L / (long)sizeof(GA_Execute_Dajian_C.__ExecuteUbergraph_GA_Execute_Dajian_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Execute_Dajian_C.__ExecuteUbergraph_GA_Execute_Dajian_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Execute_Dajian_C.__ExecuteUbergraph_GA_Execute_Dajian_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602AF1F RID: 175903 RVA: 0x00A6AD4A File Offset: 0x00A68F4A
		protected GA_Execute_Dajian_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401775C RID: 96092
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Execute_Dajian.GA_Execute_Dajian_C";

		// Token: 0x0401775D RID: 96093
		private static IntPtr _ClassPtr;

		// Token: 0x0401775E RID: 96094
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401775F RID: 96095
		internal new static int __PropertyOffset_0;

		// Token: 0x04017760 RID: 96096
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04017761 RID: 96097
		internal new static int __PropertyOffset_1;

		// Token: 0x04017762 RID: 96098
		internal new static int __PropertyOffset_2;

		// Token: 0x04017763 RID: 96099
		internal new static int __PropertyOffset_3;

		// Token: 0x04017764 RID: 96100
		internal static int __PropertyOffset_4;

		// Token: 0x04017765 RID: 96101
		private static IntPtr __OnTick_5D118C384AE61F1C80292E8171BB25F0_NativeFunctionPtr;

		// Token: 0x04017766 RID: 96102
		private static IntPtr __OnCancelled_5D118C384AE61F1C80292E8171BB25F0_NativeFunctionPtr;

		// Token: 0x04017767 RID: 96103
		private static IntPtr __OnInterrupted_5D118C384AE61F1C80292E8171BB25F0_NativeFunctionPtr;

		// Token: 0x04017768 RID: 96104
		private static IntPtr __OnBlendOut_5D118C384AE61F1C80292E8171BB25F0_NativeFunctionPtr;

		// Token: 0x04017769 RID: 96105
		private static IntPtr __OnCompleted_5D118C384AE61F1C80292E8171BB25F0_NativeFunctionPtr;

		// Token: 0x0401776A RID: 96106
		private static IntPtr __K2_OnEndAbility_NativeFunctionPtr;

		// Token: 0x0401776B RID: 96107
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x0401776C RID: 96108
		private static IntPtr __ExecuteUbergraph_GA_Execute_Dajian_NativeFunctionPtr;

		// Token: 0x0200A29C RID: 41628
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __K2_OnEndAbility_FunctionParams
		{
			// Token: 0x0403304F RID: 208975
			[FieldOffset(0)]
			public bool bWasCancelled;
		}

		// Token: 0x0200A29D RID: 41629
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 864)]
		protected ref struct __ExecuteUbergraph_GA_Execute_Dajian_FunctionParams
		{
			// Token: 0x04033050 RID: 208976
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
