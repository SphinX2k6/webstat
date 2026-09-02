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
	// Token: 0x02004091 RID: 16529
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Abilities/GA/GA_Interaction_Giant.GA_Interaction_Giant_C")]
	[UnrealStructLayout(1496, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1496)]
	public class GA_Interaction_Giant_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602B01E RID: 176158 RVA: 0x00A6D163 File Offset: 0x00A6B363
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_Interaction_Giant_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Interaction_Giant.GA_Interaction_Giant_C");
			}
			return GA_Interaction_Giant_C._ClassPtr;
		}

		// Token: 0x0602B01F RID: 176159 RVA: 0x00A6D188 File Offset: 0x00A6B388
		public GA_Interaction_Giant_C() : this(BuiltinUtils.AllocNativeUObject(GA_Interaction_Giant_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602B020 RID: 176160 RVA: 0x00A6D1B0 File Offset: 0x00A6B3B0
		public GA_Interaction_Giant_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_Interaction_Giant_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007072 RID: 28786
		// (get) Token: 0x0602B021 RID: 176161 RVA: 0x00A6D1E4 File Offset: 0x00A6B3E4
		// (set) Token: 0x0602B022 RID: 176162 RVA: 0x00A6D21D File Offset: 0x00A6B41D
		public new FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_Interaction_Giant_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_Interaction_Giant_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007073 RID: 28787
		// (get) Token: 0x0602B023 RID: 176163 RVA: 0x00A6D23E File Offset: 0x00A6B43E
		// (set) Token: 0x0602B024 RID: 176164 RVA: 0x00A6D252 File Offset: 0x00A6B452
		[Nullable(2)]
		public unsafe AActor 被控物
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + GA_Interaction_Giant_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GA_Interaction_Giant_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x0602B025 RID: 176165 RVA: 0x00A6D267 File Offset: 0x00A6B467
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnTick_5D118C384AE61F1C80292E81C63D3F9C()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Interaction_Giant_C.__OnTick_5D118C384AE61F1C80292E81C63D3F9C_NativeFunctionPtr, null);
		}

		// Token: 0x0602B026 RID: 176166 RVA: 0x00A6D27B File Offset: 0x00A6B47B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCancelled_5D118C384AE61F1C80292E81C63D3F9C()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Interaction_Giant_C.__OnCancelled_5D118C384AE61F1C80292E81C63D3F9C_NativeFunctionPtr, null);
		}

		// Token: 0x0602B027 RID: 176167 RVA: 0x00A6D28F File Offset: 0x00A6B48F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnInterrupted_5D118C384AE61F1C80292E81C63D3F9C()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Interaction_Giant_C.__OnInterrupted_5D118C384AE61F1C80292E81C63D3F9C_NativeFunctionPtr, null);
		}

		// Token: 0x0602B028 RID: 176168 RVA: 0x00A6D2A3 File Offset: 0x00A6B4A3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnBlendOut_5D118C384AE61F1C80292E81C63D3F9C()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Interaction_Giant_C.__OnBlendOut_5D118C384AE61F1C80292E81C63D3F9C_NativeFunctionPtr, null);
		}

		// Token: 0x0602B029 RID: 176169 RVA: 0x00A6D2B7 File Offset: 0x00A6B4B7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCompleted_5D118C384AE61F1C80292E81C63D3F9C()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Interaction_Giant_C.__OnCompleted_5D118C384AE61F1C80292E81C63D3F9C_NativeFunctionPtr, null);
		}

		// Token: 0x0602B02A RID: 176170 RVA: 0x00A6D2CB File Offset: 0x00A6B4CB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Interaction_Giant_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x0602B02B RID: 176171 RVA: 0x00A6D2DF File Offset: 0x00A6B4DF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Interaction_Giant_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602B02C RID: 176172 RVA: 0x00A6D2F4 File Offset: 0x00A6B4F4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_Interaction_Giant(int EntryPoint)
		{
			GA_Interaction_Giant_C.__ExecuteUbergraph_GA_Interaction_Giant_FunctionParams* ptr = stackalloc GA_Interaction_Giant_C.__ExecuteUbergraph_GA_Interaction_Giant_FunctionParams[(UIntPtr)791] + 15L / (long)sizeof(GA_Interaction_Giant_C.__ExecuteUbergraph_GA_Interaction_Giant_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Interaction_Giant_C.__ExecuteUbergraph_GA_Interaction_Giant_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Interaction_Giant_C.__ExecuteUbergraph_GA_Interaction_Giant_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602B02D RID: 176173 RVA: 0x00A6D33E File Offset: 0x00A6B53E
		protected GA_Interaction_Giant_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401782E RID: 96302
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Interaction_Giant.GA_Interaction_Giant_C";

		// Token: 0x0401782F RID: 96303
		private static IntPtr _ClassPtr;

		// Token: 0x04017830 RID: 96304
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04017831 RID: 96305
		internal new static int __PropertyOffset_0;

		// Token: 0x04017832 RID: 96306
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04017833 RID: 96307
		internal new static int __PropertyOffset_1;

		// Token: 0x04017834 RID: 96308
		private static IntPtr __OnTick_5D118C384AE61F1C80292E81C63D3F9C_NativeFunctionPtr;

		// Token: 0x04017835 RID: 96309
		private static IntPtr __OnCancelled_5D118C384AE61F1C80292E81C63D3F9C_NativeFunctionPtr;

		// Token: 0x04017836 RID: 96310
		private static IntPtr __OnInterrupted_5D118C384AE61F1C80292E81C63D3F9C_NativeFunctionPtr;

		// Token: 0x04017837 RID: 96311
		private static IntPtr __OnBlendOut_5D118C384AE61F1C80292E81C63D3F9C_NativeFunctionPtr;

		// Token: 0x04017838 RID: 96312
		private static IntPtr __OnCompleted_5D118C384AE61F1C80292E81C63D3F9C_NativeFunctionPtr;

		// Token: 0x04017839 RID: 96313
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x0401783A RID: 96314
		private static IntPtr __ExecuteUbergraph_GA_Interaction_Giant_NativeFunctionPtr;

		// Token: 0x0200A2BF RID: 41663
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 776)]
		protected ref struct __ExecuteUbergraph_GA_Interaction_Giant_FunctionParams
		{
			// Token: 0x04033079 RID: 209017
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
