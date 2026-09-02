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
	// Token: 0x02004090 RID: 16528
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Abilities/GA/GA_Interaction_DurationInteract.GA_Interaction_DurationInteract_C")]
	[UnrealStructLayout(1496, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1496)]
	public class GA_Interaction_DurationInteract_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602B00E RID: 176142 RVA: 0x00A6CF80 File Offset: 0x00A6B180
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_Interaction_DurationInteract_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Interaction_DurationInteract.GA_Interaction_DurationInteract_C");
			}
			return GA_Interaction_DurationInteract_C._ClassPtr;
		}

		// Token: 0x0602B00F RID: 176143 RVA: 0x00A6CFA4 File Offset: 0x00A6B1A4
		public GA_Interaction_DurationInteract_C() : this(BuiltinUtils.AllocNativeUObject(GA_Interaction_DurationInteract_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602B010 RID: 176144 RVA: 0x00A6CFCC File Offset: 0x00A6B1CC
		public GA_Interaction_DurationInteract_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_Interaction_DurationInteract_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007070 RID: 28784
		// (get) Token: 0x0602B011 RID: 176145 RVA: 0x00A6D000 File Offset: 0x00A6B200
		// (set) Token: 0x0602B012 RID: 176146 RVA: 0x00A6D039 File Offset: 0x00A6B239
		public new FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_Interaction_DurationInteract_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_Interaction_DurationInteract_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007071 RID: 28785
		// (get) Token: 0x0602B013 RID: 176147 RVA: 0x00A6D05A File Offset: 0x00A6B25A
		// (set) Token: 0x0602B014 RID: 176148 RVA: 0x00A6D06E File Offset: 0x00A6B26E
		[Nullable(2)]
		public unsafe AActor 被控物
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + GA_Interaction_DurationInteract_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GA_Interaction_DurationInteract_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x0602B015 RID: 176149 RVA: 0x00A6D083 File Offset: 0x00A6B283
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnTick_5D118C384AE61F1C80292E81303EAA5E()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Interaction_DurationInteract_C.__OnTick_5D118C384AE61F1C80292E81303EAA5E_NativeFunctionPtr, null);
		}

		// Token: 0x0602B016 RID: 176150 RVA: 0x00A6D097 File Offset: 0x00A6B297
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCancelled_5D118C384AE61F1C80292E81303EAA5E()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Interaction_DurationInteract_C.__OnCancelled_5D118C384AE61F1C80292E81303EAA5E_NativeFunctionPtr, null);
		}

		// Token: 0x0602B017 RID: 176151 RVA: 0x00A6D0AB File Offset: 0x00A6B2AB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnInterrupted_5D118C384AE61F1C80292E81303EAA5E()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Interaction_DurationInteract_C.__OnInterrupted_5D118C384AE61F1C80292E81303EAA5E_NativeFunctionPtr, null);
		}

		// Token: 0x0602B018 RID: 176152 RVA: 0x00A6D0BF File Offset: 0x00A6B2BF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnBlendOut_5D118C384AE61F1C80292E81303EAA5E()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Interaction_DurationInteract_C.__OnBlendOut_5D118C384AE61F1C80292E81303EAA5E_NativeFunctionPtr, null);
		}

		// Token: 0x0602B019 RID: 176153 RVA: 0x00A6D0D3 File Offset: 0x00A6B2D3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCompleted_5D118C384AE61F1C80292E81303EAA5E()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Interaction_DurationInteract_C.__OnCompleted_5D118C384AE61F1C80292E81303EAA5E_NativeFunctionPtr, null);
		}

		// Token: 0x0602B01A RID: 176154 RVA: 0x00A6D0E7 File Offset: 0x00A6B2E7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Interaction_DurationInteract_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x0602B01B RID: 176155 RVA: 0x00A6D0FB File Offset: 0x00A6B2FB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Interaction_DurationInteract_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602B01C RID: 176156 RVA: 0x00A6D110 File Offset: 0x00A6B310
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_Interaction_DurationInteract(int EntryPoint)
		{
			GA_Interaction_DurationInteract_C.__ExecuteUbergraph_GA_Interaction_DurationInteract_FunctionParams* ptr = stackalloc GA_Interaction_DurationInteract_C.__ExecuteUbergraph_GA_Interaction_DurationInteract_FunctionParams[(UIntPtr)767] + 15L / (long)sizeof(GA_Interaction_DurationInteract_C.__ExecuteUbergraph_GA_Interaction_DurationInteract_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Interaction_DurationInteract_C.__ExecuteUbergraph_GA_Interaction_DurationInteract_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Interaction_DurationInteract_C.__ExecuteUbergraph_GA_Interaction_DurationInteract_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602B01D RID: 176157 RVA: 0x00A6D15A File Offset: 0x00A6B35A
		protected GA_Interaction_DurationInteract_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04017821 RID: 96289
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Interaction_DurationInteract.GA_Interaction_DurationInteract_C";

		// Token: 0x04017822 RID: 96290
		private static IntPtr _ClassPtr;

		// Token: 0x04017823 RID: 96291
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04017824 RID: 96292
		internal new static int __PropertyOffset_0;

		// Token: 0x04017825 RID: 96293
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04017826 RID: 96294
		internal new static int __PropertyOffset_1;

		// Token: 0x04017827 RID: 96295
		private static IntPtr __OnTick_5D118C384AE61F1C80292E81303EAA5E_NativeFunctionPtr;

		// Token: 0x04017828 RID: 96296
		private static IntPtr __OnCancelled_5D118C384AE61F1C80292E81303EAA5E_NativeFunctionPtr;

		// Token: 0x04017829 RID: 96297
		private static IntPtr __OnInterrupted_5D118C384AE61F1C80292E81303EAA5E_NativeFunctionPtr;

		// Token: 0x0401782A RID: 96298
		private static IntPtr __OnBlendOut_5D118C384AE61F1C80292E81303EAA5E_NativeFunctionPtr;

		// Token: 0x0401782B RID: 96299
		private static IntPtr __OnCompleted_5D118C384AE61F1C80292E81303EAA5E_NativeFunctionPtr;

		// Token: 0x0401782C RID: 96300
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x0401782D RID: 96301
		private static IntPtr __ExecuteUbergraph_GA_Interaction_DurationInteract_NativeFunctionPtr;

		// Token: 0x0200A2BE RID: 41662
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 752)]
		protected ref struct __ExecuteUbergraph_GA_Interaction_DurationInteract_FunctionParams
		{
			// Token: 0x04033078 RID: 209016
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
