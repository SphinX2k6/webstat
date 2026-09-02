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
	// Token: 0x020040AA RID: 16554
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Abilities/GA/GA_Role_Guqin.GA_Role_Guqin_C")]
	[UnrealStructLayout(1512, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1508)]
	public class GA_Role_Guqin_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602B268 RID: 176744 RVA: 0x00A71CF4 File Offset: 0x00A6FEF4
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_Role_Guqin_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Role_Guqin.GA_Role_Guqin_C");
			}
			return GA_Role_Guqin_C._ClassPtr;
		}

		// Token: 0x0602B269 RID: 176745 RVA: 0x00A71D18 File Offset: 0x00A6FF18
		public GA_Role_Guqin_C() : this(BuiltinUtils.AllocNativeUObject(GA_Role_Guqin_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602B26A RID: 176746 RVA: 0x00A71D40 File Offset: 0x00A6FF40
		[NullableContext(1)]
		public GA_Role_Guqin_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_Role_Guqin_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170070F1 RID: 28913
		// (get) Token: 0x0602B26B RID: 176747 RVA: 0x00A71D74 File Offset: 0x00A6FF74
		// (set) Token: 0x0602B26C RID: 176748 RVA: 0x00A71DAD File Offset: 0x00A6FFAD
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_Role_Guqin_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_Role_Guqin_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170070F2 RID: 28914
		// (get) Token: 0x0602B26D RID: 176749 RVA: 0x00A71DCE File Offset: 0x00A6FFCE
		// (set) Token: 0x0602B26E RID: 176750 RVA: 0x00A71DE2 File Offset: 0x00A6FFE2
		[Nullable(2)]
		public unsafe UBaseAbilitySystemComponent AbilitySystemComponent
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBaseAbilitySystemComponent>(base.NativePtr / (IntPtr)sizeof(void*) + GA_Role_Guqin_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GA_Role_Guqin_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170070F3 RID: 28915
		// (get) Token: 0x0602B26F RID: 176751 RVA: 0x00A71DF7 File Offset: 0x00A6FFF7
		// (set) Token: 0x0602B270 RID: 176752 RVA: 0x00A71E0B File Offset: 0x00A7000B
		public unsafe FGameplayTag Tag
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Role_Guqin_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Role_Guqin_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x0602B271 RID: 176753 RVA: 0x00A71E20 File Offset: 0x00A70020
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override bool K2_CanActivateAbility(FGameplayAbilityActorInfo ActorInfo, ref FGameplayTagContainer RelevantTags)
		{
			GA_Role_Guqin_C.__K2_CanActivateAbility_FunctionParams* ptr = stackalloc GA_Role_Guqin_C.__K2_CanActivateAbility_FunctionParams[(UIntPtr)215] + 15L / (long)sizeof(GA_Role_Guqin_C.__K2_CanActivateAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Role_Guqin_C.__K2_CanActivateAbility_NativeFunctionPtr, (void*)ptr, 1);
			if (ActorInfo != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FGameplayAbilityActorInfo.StaticStruct(), &ptr->ActorInfo, ActorInfo.NativePtr, 1, false);
			}
			if (RelevantTags != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FGameplayTagContainer.StaticStruct(), &ptr->RelevantTags, RelevantTags.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_Guqin_C.__K2_CanActivateAbility_NativeFunctionPtr, (void*)ptr);
			if (RelevantTags != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FGameplayTagContainer.StaticStruct(), RelevantTags.NativePtr, &ptr->RelevantTags, 1, false);
			}
			bool _Result = ptr->__Result;
			UnrealReflectionUtils.DestroyStruct(GA_Role_Guqin_C.__K2_CanActivateAbility_NativeFunctionPtr, (void*)ptr, 1);
			return _Result;
		}

		// Token: 0x0602B272 RID: 176754 RVA: 0x00A71EE4 File Offset: 0x00A700E4
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override bool K2_CanActivateAbility_Implementation(FGameplayAbilityActorInfo ActorInfo, ref FGameplayTagContainer RelevantTags)
		{
			GA_Role_Guqin_C.__K2_CanActivateAbility_FunctionParams* ptr = stackalloc GA_Role_Guqin_C.__K2_CanActivateAbility_FunctionParams[(UIntPtr)215] + 15L / (long)sizeof(GA_Role_Guqin_C.__K2_CanActivateAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Role_Guqin_C.__K2_CanActivateAbility_NativeFunctionPtr, (void*)ptr, 1);
			if (ActorInfo != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FGameplayAbilityActorInfo.StaticStruct(), &ptr->ActorInfo, ActorInfo.NativePtr, 1, false);
			}
			if (RelevantTags != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FGameplayTagContainer.StaticStruct(), &ptr->RelevantTags, RelevantTags.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Role_Guqin_C.__K2_CanActivateAbility_NativeFunctionPtr, (void*)ptr, 0);
			if (RelevantTags != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FGameplayTagContainer.StaticStruct(), RelevantTags.NativePtr, &ptr->RelevantTags, 1, false);
			}
			bool _Result = ptr->__Result;
			UnrealReflectionUtils.DestroyStruct(GA_Role_Guqin_C.__K2_CanActivateAbility_NativeFunctionPtr, (void*)ptr, 1);
			return _Result;
		}

		// Token: 0x0602B273 RID: 176755 RVA: 0x00A71FA8 File Offset: 0x00A701A8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnTick_5D118C384AE61F1C80292E81265D3DA7()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_Guqin_C.__OnTick_5D118C384AE61F1C80292E81265D3DA7_NativeFunctionPtr, null);
		}

		// Token: 0x0602B274 RID: 176756 RVA: 0x00A71FBC File Offset: 0x00A701BC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCancelled_5D118C384AE61F1C80292E81265D3DA7()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_Guqin_C.__OnCancelled_5D118C384AE61F1C80292E81265D3DA7_NativeFunctionPtr, null);
		}

		// Token: 0x0602B275 RID: 176757 RVA: 0x00A71FD0 File Offset: 0x00A701D0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnInterrupted_5D118C384AE61F1C80292E81265D3DA7()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_Guqin_C.__OnInterrupted_5D118C384AE61F1C80292E81265D3DA7_NativeFunctionPtr, null);
		}

		// Token: 0x0602B276 RID: 176758 RVA: 0x00A71FE4 File Offset: 0x00A701E4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnBlendOut_5D118C384AE61F1C80292E81265D3DA7()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_Guqin_C.__OnBlendOut_5D118C384AE61F1C80292E81265D3DA7_NativeFunctionPtr, null);
		}

		// Token: 0x0602B277 RID: 176759 RVA: 0x00A71FF8 File Offset: 0x00A701F8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCompleted_5D118C384AE61F1C80292E81265D3DA7()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_Guqin_C.__OnCompleted_5D118C384AE61F1C80292E81265D3DA7_NativeFunctionPtr, null);
		}

		// Token: 0x0602B278 RID: 176760 RVA: 0x00A7200C File Offset: 0x00A7020C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnTick_5D118C384AE61F1C80292E81E2F3D5F7()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_Guqin_C.__OnTick_5D118C384AE61F1C80292E81E2F3D5F7_NativeFunctionPtr, null);
		}

		// Token: 0x0602B279 RID: 176761 RVA: 0x00A72020 File Offset: 0x00A70220
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCancelled_5D118C384AE61F1C80292E81E2F3D5F7()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_Guqin_C.__OnCancelled_5D118C384AE61F1C80292E81E2F3D5F7_NativeFunctionPtr, null);
		}

		// Token: 0x0602B27A RID: 176762 RVA: 0x00A72034 File Offset: 0x00A70234
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnInterrupted_5D118C384AE61F1C80292E81E2F3D5F7()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_Guqin_C.__OnInterrupted_5D118C384AE61F1C80292E81E2F3D5F7_NativeFunctionPtr, null);
		}

		// Token: 0x0602B27B RID: 176763 RVA: 0x00A72048 File Offset: 0x00A70248
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnBlendOut_5D118C384AE61F1C80292E81E2F3D5F7()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_Guqin_C.__OnBlendOut_5D118C384AE61F1C80292E81E2F3D5F7_NativeFunctionPtr, null);
		}

		// Token: 0x0602B27C RID: 176764 RVA: 0x00A7205C File Offset: 0x00A7025C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCompleted_5D118C384AE61F1C80292E81E2F3D5F7()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_Guqin_C.__OnCompleted_5D118C384AE61F1C80292E81E2F3D5F7_NativeFunctionPtr, null);
		}

		// Token: 0x0602B27D RID: 176765 RVA: 0x00A72070 File Offset: 0x00A70270
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Added_21071CB943CD992BF8EFD6A3B7128487(in FGameplayTag Tag)
		{
			GA_Role_Guqin_C.__Added_21071CB943CD992BF8EFD6A3B7128487_FunctionParams* ptr = stackalloc GA_Role_Guqin_C.__Added_21071CB943CD992BF8EFD6A3B7128487_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(GA_Role_Guqin_C.__Added_21071CB943CD992BF8EFD6A3B7128487_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Role_Guqin_C.__Added_21071CB943CD992BF8EFD6A3B7128487_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Tag = Tag;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_Guqin_C.__Added_21071CB943CD992BF8EFD6A3B7128487_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B27E RID: 176766 RVA: 0x00A720BB File Offset: 0x00A702BB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnTick_5D118C384AE61F1C80292E814B8FA4E5()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_Guqin_C.__OnTick_5D118C384AE61F1C80292E814B8FA4E5_NativeFunctionPtr, null);
		}

		// Token: 0x0602B27F RID: 176767 RVA: 0x00A720CF File Offset: 0x00A702CF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCancelled_5D118C384AE61F1C80292E814B8FA4E5()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_Guqin_C.__OnCancelled_5D118C384AE61F1C80292E814B8FA4E5_NativeFunctionPtr, null);
		}

		// Token: 0x0602B280 RID: 176768 RVA: 0x00A720E3 File Offset: 0x00A702E3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnInterrupted_5D118C384AE61F1C80292E814B8FA4E5()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_Guqin_C.__OnInterrupted_5D118C384AE61F1C80292E814B8FA4E5_NativeFunctionPtr, null);
		}

		// Token: 0x0602B281 RID: 176769 RVA: 0x00A720F7 File Offset: 0x00A702F7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnBlendOut_5D118C384AE61F1C80292E814B8FA4E5()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_Guqin_C.__OnBlendOut_5D118C384AE61F1C80292E814B8FA4E5_NativeFunctionPtr, null);
		}

		// Token: 0x0602B282 RID: 176770 RVA: 0x00A7210B File Offset: 0x00A7030B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCompleted_5D118C384AE61F1C80292E814B8FA4E5()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_Guqin_C.__OnCompleted_5D118C384AE61F1C80292E814B8FA4E5_NativeFunctionPtr, null);
		}

		// Token: 0x0602B283 RID: 176771 RVA: 0x00A7211F File Offset: 0x00A7031F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnTick_5D118C384AE61F1C80292E81D2544D50()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_Guqin_C.__OnTick_5D118C384AE61F1C80292E81D2544D50_NativeFunctionPtr, null);
		}

		// Token: 0x0602B284 RID: 176772 RVA: 0x00A72133 File Offset: 0x00A70333
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCancelled_5D118C384AE61F1C80292E81D2544D50()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_Guqin_C.__OnCancelled_5D118C384AE61F1C80292E81D2544D50_NativeFunctionPtr, null);
		}

		// Token: 0x0602B285 RID: 176773 RVA: 0x00A72147 File Offset: 0x00A70347
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnInterrupted_5D118C384AE61F1C80292E81D2544D50()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_Guqin_C.__OnInterrupted_5D118C384AE61F1C80292E81D2544D50_NativeFunctionPtr, null);
		}

		// Token: 0x0602B286 RID: 176774 RVA: 0x00A7215B File Offset: 0x00A7035B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnBlendOut_5D118C384AE61F1C80292E81D2544D50()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_Guqin_C.__OnBlendOut_5D118C384AE61F1C80292E81D2544D50_NativeFunctionPtr, null);
		}

		// Token: 0x0602B287 RID: 176775 RVA: 0x00A7216F File Offset: 0x00A7036F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCompleted_5D118C384AE61F1C80292E81D2544D50()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_Guqin_C.__OnCompleted_5D118C384AE61F1C80292E81D2544D50_NativeFunctionPtr, null);
		}

		// Token: 0x0602B288 RID: 176776 RVA: 0x00A72184 File Offset: 0x00A70384
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Added_21071CB943CD992BF8EFD6A3C86BB420(in FGameplayTag Tag)
		{
			GA_Role_Guqin_C.__Added_21071CB943CD992BF8EFD6A3C86BB420_FunctionParams* ptr = stackalloc GA_Role_Guqin_C.__Added_21071CB943CD992BF8EFD6A3C86BB420_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(GA_Role_Guqin_C.__Added_21071CB943CD992BF8EFD6A3C86BB420_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Role_Guqin_C.__Added_21071CB943CD992BF8EFD6A3C86BB420_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Tag = Tag;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_Guqin_C.__Added_21071CB943CD992BF8EFD6A3C86BB420_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B289 RID: 176777 RVA: 0x00A721CF File Offset: 0x00A703CF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_Guqin_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x0602B28A RID: 176778 RVA: 0x00A721E3 File Offset: 0x00A703E3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Role_Guqin_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602B28B RID: 176779 RVA: 0x00A721F8 File Offset: 0x00A703F8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_Role_Guqin(int EntryPoint)
		{
			GA_Role_Guqin_C.__ExecuteUbergraph_GA_Role_Guqin_FunctionParams* ptr = stackalloc GA_Role_Guqin_C.__ExecuteUbergraph_GA_Role_Guqin_FunctionParams[(UIntPtr)3263] + 15L / (long)sizeof(GA_Role_Guqin_C.__ExecuteUbergraph_GA_Role_Guqin_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Role_Guqin_C.__ExecuteUbergraph_GA_Role_Guqin_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Role_Guqin_C.__ExecuteUbergraph_GA_Role_Guqin_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602B28C RID: 176780 RVA: 0x00A72242 File Offset: 0x00A70442
		protected GA_Role_Guqin_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040179D9 RID: 96729
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Role_Guqin.GA_Role_Guqin_C";

		// Token: 0x040179DA RID: 96730
		private static IntPtr _ClassPtr;

		// Token: 0x040179DB RID: 96731
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040179DC RID: 96732
		internal new static int __PropertyOffset_0;

		// Token: 0x040179DD RID: 96733
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040179DE RID: 96734
		internal new static int __PropertyOffset_1;

		// Token: 0x040179DF RID: 96735
		internal new static int __PropertyOffset_2;

		// Token: 0x040179E0 RID: 96736
		private static IntPtr __K2_CanActivateAbility_NativeFunctionPtr;

		// Token: 0x040179E1 RID: 96737
		private static IntPtr __OnTick_5D118C384AE61F1C80292E81265D3DA7_NativeFunctionPtr;

		// Token: 0x040179E2 RID: 96738
		private static IntPtr __OnCancelled_5D118C384AE61F1C80292E81265D3DA7_NativeFunctionPtr;

		// Token: 0x040179E3 RID: 96739
		private static IntPtr __OnInterrupted_5D118C384AE61F1C80292E81265D3DA7_NativeFunctionPtr;

		// Token: 0x040179E4 RID: 96740
		private static IntPtr __OnBlendOut_5D118C384AE61F1C80292E81265D3DA7_NativeFunctionPtr;

		// Token: 0x040179E5 RID: 96741
		private static IntPtr __OnCompleted_5D118C384AE61F1C80292E81265D3DA7_NativeFunctionPtr;

		// Token: 0x040179E6 RID: 96742
		private static IntPtr __OnTick_5D118C384AE61F1C80292E81E2F3D5F7_NativeFunctionPtr;

		// Token: 0x040179E7 RID: 96743
		private static IntPtr __OnCancelled_5D118C384AE61F1C80292E81E2F3D5F7_NativeFunctionPtr;

		// Token: 0x040179E8 RID: 96744
		private static IntPtr __OnInterrupted_5D118C384AE61F1C80292E81E2F3D5F7_NativeFunctionPtr;

		// Token: 0x040179E9 RID: 96745
		private static IntPtr __OnBlendOut_5D118C384AE61F1C80292E81E2F3D5F7_NativeFunctionPtr;

		// Token: 0x040179EA RID: 96746
		private static IntPtr __OnCompleted_5D118C384AE61F1C80292E81E2F3D5F7_NativeFunctionPtr;

		// Token: 0x040179EB RID: 96747
		private static IntPtr __Added_21071CB943CD992BF8EFD6A3B7128487_NativeFunctionPtr;

		// Token: 0x040179EC RID: 96748
		private static IntPtr __OnTick_5D118C384AE61F1C80292E814B8FA4E5_NativeFunctionPtr;

		// Token: 0x040179ED RID: 96749
		private static IntPtr __OnCancelled_5D118C384AE61F1C80292E814B8FA4E5_NativeFunctionPtr;

		// Token: 0x040179EE RID: 96750
		private static IntPtr __OnInterrupted_5D118C384AE61F1C80292E814B8FA4E5_NativeFunctionPtr;

		// Token: 0x040179EF RID: 96751
		private static IntPtr __OnBlendOut_5D118C384AE61F1C80292E814B8FA4E5_NativeFunctionPtr;

		// Token: 0x040179F0 RID: 96752
		private static IntPtr __OnCompleted_5D118C384AE61F1C80292E814B8FA4E5_NativeFunctionPtr;

		// Token: 0x040179F1 RID: 96753
		private static IntPtr __OnTick_5D118C384AE61F1C80292E81D2544D50_NativeFunctionPtr;

		// Token: 0x040179F2 RID: 96754
		private static IntPtr __OnCancelled_5D118C384AE61F1C80292E81D2544D50_NativeFunctionPtr;

		// Token: 0x040179F3 RID: 96755
		private static IntPtr __OnInterrupted_5D118C384AE61F1C80292E81D2544D50_NativeFunctionPtr;

		// Token: 0x040179F4 RID: 96756
		private static IntPtr __OnBlendOut_5D118C384AE61F1C80292E81D2544D50_NativeFunctionPtr;

		// Token: 0x040179F5 RID: 96757
		private static IntPtr __OnCompleted_5D118C384AE61F1C80292E81D2544D50_NativeFunctionPtr;

		// Token: 0x040179F6 RID: 96758
		private static IntPtr __Added_21071CB943CD992BF8EFD6A3C86BB420_NativeFunctionPtr;

		// Token: 0x040179F7 RID: 96759
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x040179F8 RID: 96760
		private static IntPtr __ExecuteUbergraph_GA_Role_Guqin_NativeFunctionPtr;

		// Token: 0x0200A300 RID: 41728
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 200)]
		protected new ref struct __K2_CanActivateAbility_FunctionParams
		{
			// Token: 0x040330CB RID: 209099
			[FieldOffset(0)]
			public byte ActorInfo;

			// Token: 0x040330CC RID: 209100
			[FieldOffset(80)]
			public byte RelevantTags;

			// Token: 0x040330CD RID: 209101
			[FieldOffset(112)]
			public bool __Result;
		}

		// Token: 0x0200A301 RID: 41729
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __Added_21071CB943CD992BF8EFD6A3B7128487_FunctionParams
		{
			// Token: 0x040330CE RID: 209102
			[FieldOffset(0)]
			public FGameplayTag Tag;
		}

		// Token: 0x0200A302 RID: 41730
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __Added_21071CB943CD992BF8EFD6A3C86BB420_FunctionParams
		{
			// Token: 0x040330CF RID: 209103
			[FieldOffset(0)]
			public FGameplayTag Tag;
		}

		// Token: 0x0200A303 RID: 41731
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 3248)]
		protected ref struct __ExecuteUbergraph_GA_Role_Guqin_FunctionParams
		{
			// Token: 0x040330D0 RID: 209104
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
