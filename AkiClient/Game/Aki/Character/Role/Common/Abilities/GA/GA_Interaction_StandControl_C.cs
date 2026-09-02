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
	// Token: 0x02004094 RID: 16532
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Abilities/GA/GA_Interaction_StandControl.GA_Interaction_StandControl_C")]
	[UnrealStructLayout(1496, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1496)]
	public class GA_Interaction_StandControl_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602B044 RID: 176196 RVA: 0x00A6D6A8 File Offset: 0x00A6B8A8
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_Interaction_StandControl_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Interaction_StandControl.GA_Interaction_StandControl_C");
			}
			return GA_Interaction_StandControl_C._ClassPtr;
		}

		// Token: 0x0602B045 RID: 176197 RVA: 0x00A6D6CC File Offset: 0x00A6B8CC
		public GA_Interaction_StandControl_C() : this(BuiltinUtils.AllocNativeUObject(GA_Interaction_StandControl_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602B046 RID: 176198 RVA: 0x00A6D6F4 File Offset: 0x00A6B8F4
		public GA_Interaction_StandControl_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_Interaction_StandControl_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007077 RID: 28791
		// (get) Token: 0x0602B047 RID: 176199 RVA: 0x00A6D728 File Offset: 0x00A6B928
		// (set) Token: 0x0602B048 RID: 176200 RVA: 0x00A6D761 File Offset: 0x00A6B961
		public new FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_Interaction_StandControl_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_Interaction_StandControl_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007078 RID: 28792
		// (get) Token: 0x0602B049 RID: 176201 RVA: 0x00A6D782 File Offset: 0x00A6B982
		// (set) Token: 0x0602B04A RID: 176202 RVA: 0x00A6D796 File Offset: 0x00A6B996
		[Nullable(2)]
		public unsafe AActor 被控物
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + GA_Interaction_StandControl_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GA_Interaction_StandControl_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x0602B04B RID: 176203 RVA: 0x00A6D7AB File Offset: 0x00A6B9AB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnTick_5D118C384AE61F1C80292E8166FD408C()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Interaction_StandControl_C.__OnTick_5D118C384AE61F1C80292E8166FD408C_NativeFunctionPtr, null);
		}

		// Token: 0x0602B04C RID: 176204 RVA: 0x00A6D7BF File Offset: 0x00A6B9BF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCancelled_5D118C384AE61F1C80292E8166FD408C()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Interaction_StandControl_C.__OnCancelled_5D118C384AE61F1C80292E8166FD408C_NativeFunctionPtr, null);
		}

		// Token: 0x0602B04D RID: 176205 RVA: 0x00A6D7D3 File Offset: 0x00A6B9D3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnInterrupted_5D118C384AE61F1C80292E8166FD408C()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Interaction_StandControl_C.__OnInterrupted_5D118C384AE61F1C80292E8166FD408C_NativeFunctionPtr, null);
		}

		// Token: 0x0602B04E RID: 176206 RVA: 0x00A6D7E7 File Offset: 0x00A6B9E7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnBlendOut_5D118C384AE61F1C80292E8166FD408C()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Interaction_StandControl_C.__OnBlendOut_5D118C384AE61F1C80292E8166FD408C_NativeFunctionPtr, null);
		}

		// Token: 0x0602B04F RID: 176207 RVA: 0x00A6D7FB File Offset: 0x00A6B9FB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCompleted_5D118C384AE61F1C80292E8166FD408C()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Interaction_StandControl_C.__OnCompleted_5D118C384AE61F1C80292E8166FD408C_NativeFunctionPtr, null);
		}

		// Token: 0x0602B050 RID: 176208 RVA: 0x00A6D80F File Offset: 0x00A6BA0F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnTick_5D118C384AE61F1C80292E81AD69BEF1()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Interaction_StandControl_C.__OnTick_5D118C384AE61F1C80292E81AD69BEF1_NativeFunctionPtr, null);
		}

		// Token: 0x0602B051 RID: 176209 RVA: 0x00A6D823 File Offset: 0x00A6BA23
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCancelled_5D118C384AE61F1C80292E81AD69BEF1()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Interaction_StandControl_C.__OnCancelled_5D118C384AE61F1C80292E81AD69BEF1_NativeFunctionPtr, null);
		}

		// Token: 0x0602B052 RID: 176210 RVA: 0x00A6D837 File Offset: 0x00A6BA37
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnInterrupted_5D118C384AE61F1C80292E81AD69BEF1()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Interaction_StandControl_C.__OnInterrupted_5D118C384AE61F1C80292E81AD69BEF1_NativeFunctionPtr, null);
		}

		// Token: 0x0602B053 RID: 176211 RVA: 0x00A6D84B File Offset: 0x00A6BA4B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnBlendOut_5D118C384AE61F1C80292E81AD69BEF1()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Interaction_StandControl_C.__OnBlendOut_5D118C384AE61F1C80292E81AD69BEF1_NativeFunctionPtr, null);
		}

		// Token: 0x0602B054 RID: 176212 RVA: 0x00A6D85F File Offset: 0x00A6BA5F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCompleted_5D118C384AE61F1C80292E81AD69BEF1()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Interaction_StandControl_C.__OnCompleted_5D118C384AE61F1C80292E81AD69BEF1_NativeFunctionPtr, null);
		}

		// Token: 0x0602B055 RID: 176213 RVA: 0x00A6D873 File Offset: 0x00A6BA73
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Interaction_StandControl_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x0602B056 RID: 176214 RVA: 0x00A6D887 File Offset: 0x00A6BA87
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Interaction_StandControl_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602B057 RID: 176215 RVA: 0x00A6D89C File Offset: 0x00A6BA9C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_Interaction_StandControl(int EntryPoint)
		{
			GA_Interaction_StandControl_C.__ExecuteUbergraph_GA_Interaction_StandControl_FunctionParams* ptr = stackalloc GA_Interaction_StandControl_C.__ExecuteUbergraph_GA_Interaction_StandControl_FunctionParams[(UIntPtr)1607] + 15L / (long)sizeof(GA_Interaction_StandControl_C.__ExecuteUbergraph_GA_Interaction_StandControl_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Interaction_StandControl_C.__ExecuteUbergraph_GA_Interaction_StandControl_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Interaction_StandControl_C.__ExecuteUbergraph_GA_Interaction_StandControl_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602B058 RID: 176216 RVA: 0x00A6D8E6 File Offset: 0x00A6BAE6
		protected GA_Interaction_StandControl_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401784B RID: 96331
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Interaction_StandControl.GA_Interaction_StandControl_C";

		// Token: 0x0401784C RID: 96332
		private static IntPtr _ClassPtr;

		// Token: 0x0401784D RID: 96333
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401784E RID: 96334
		internal new static int __PropertyOffset_0;

		// Token: 0x0401784F RID: 96335
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04017850 RID: 96336
		internal new static int __PropertyOffset_1;

		// Token: 0x04017851 RID: 96337
		private static IntPtr __OnTick_5D118C384AE61F1C80292E8166FD408C_NativeFunctionPtr;

		// Token: 0x04017852 RID: 96338
		private static IntPtr __OnCancelled_5D118C384AE61F1C80292E8166FD408C_NativeFunctionPtr;

		// Token: 0x04017853 RID: 96339
		private static IntPtr __OnInterrupted_5D118C384AE61F1C80292E8166FD408C_NativeFunctionPtr;

		// Token: 0x04017854 RID: 96340
		private static IntPtr __OnBlendOut_5D118C384AE61F1C80292E8166FD408C_NativeFunctionPtr;

		// Token: 0x04017855 RID: 96341
		private static IntPtr __OnCompleted_5D118C384AE61F1C80292E8166FD408C_NativeFunctionPtr;

		// Token: 0x04017856 RID: 96342
		private static IntPtr __OnTick_5D118C384AE61F1C80292E81AD69BEF1_NativeFunctionPtr;

		// Token: 0x04017857 RID: 96343
		private static IntPtr __OnCancelled_5D118C384AE61F1C80292E81AD69BEF1_NativeFunctionPtr;

		// Token: 0x04017858 RID: 96344
		private static IntPtr __OnInterrupted_5D118C384AE61F1C80292E81AD69BEF1_NativeFunctionPtr;

		// Token: 0x04017859 RID: 96345
		private static IntPtr __OnBlendOut_5D118C384AE61F1C80292E81AD69BEF1_NativeFunctionPtr;

		// Token: 0x0401785A RID: 96346
		private static IntPtr __OnCompleted_5D118C384AE61F1C80292E81AD69BEF1_NativeFunctionPtr;

		// Token: 0x0401785B RID: 96347
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x0401785C RID: 96348
		private static IntPtr __ExecuteUbergraph_GA_Interaction_StandControl_NativeFunctionPtr;

		// Token: 0x0200A2C3 RID: 41667
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1592)]
		protected ref struct __ExecuteUbergraph_GA_Interaction_StandControl_FunctionParams
		{
			// Token: 0x0403307D RID: 209021
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
