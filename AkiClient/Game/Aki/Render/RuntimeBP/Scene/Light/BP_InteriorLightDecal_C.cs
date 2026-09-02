using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Light
{
	// Token: 0x02003A83 RID: 14979
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Light/BP_InteriorLightDecal.BP_InteriorLightDecal_C")]
	[UnrealStructLayout(1136, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1132)]
	public class BP_InteriorLightDecal_C : ADecalActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601F5CA RID: 128458 RVA: 0x0090FC18 File Offset: 0x0090DE18
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_InteriorLightDecal_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/Light/BP_InteriorLightDecal.BP_InteriorLightDecal_C");
			}
			return BP_InteriorLightDecal_C._ClassPtr;
		}

		// Token: 0x0601F5CB RID: 128459 RVA: 0x0090FC3C File Offset: 0x0090DE3C
		public BP_InteriorLightDecal_C() : this(BuiltinUtils.AllocNativeUObject(BP_InteriorLightDecal_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601F5CC RID: 128460 RVA: 0x0090FC64 File Offset: 0x0090DE64
		[NullableContext(1)]
		public BP_InteriorLightDecal_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_InteriorLightDecal_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17002F6C RID: 12140
		// (get) Token: 0x0601F5CD RID: 128461 RVA: 0x0090FC98 File Offset: 0x0090DE98
		// (set) Token: 0x0601F5CE RID: 128462 RVA: 0x0090FCD1 File Offset: 0x0090DED1
		[Nullable(1)]
		public FPointerToUberGraphFrame UberGraphFrame
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_InteriorLightDecal_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_InteriorLightDecal_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17002F6D RID: 12141
		// (get) Token: 0x0601F5CF RID: 128463 RVA: 0x0090FCF2 File Offset: 0x0090DEF2
		// (set) Token: 0x0601F5D0 RID: 128464 RVA: 0x0090FD06 File Offset: 0x0090DF06
		public unsafe UKuroGameBudgetComponent KuroGameBudget
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroGameBudgetComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_InteriorLightDecal_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_InteriorLightDecal_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17002F6E RID: 12142
		// (get) Token: 0x0601F5D1 RID: 128465 RVA: 0x0090FD1B File Offset: 0x0090DF1B
		// (set) Token: 0x0601F5D2 RID: 128466 RVA: 0x0090FD2F File Offset: 0x0090DF2F
		public unsafe UMaterialInstanceDynamic DYMaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_InteriorLightDecal_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_InteriorLightDecal_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17002F6F RID: 12143
		// (get) Token: 0x0601F5D3 RID: 128467 RVA: 0x0090FD44 File Offset: 0x0090DF44
		// (set) Token: 0x0601F5D4 RID: 128468 RVA: 0x0090FD58 File Offset: 0x0090DF58
		public unsafe UTexture2D ShadowTexture
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_InteriorLightDecal_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_InteriorLightDecal_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17002F70 RID: 12144
		// (get) Token: 0x0601F5D5 RID: 128469 RVA: 0x0090FD6D File Offset: 0x0090DF6D
		// (set) Token: 0x0601F5D6 RID: 128470 RVA: 0x0090FD7D File Offset: 0x0090DF7D
		public unsafe float ShadowIntensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_InteriorLightDecal_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_InteriorLightDecal_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17002F71 RID: 12145
		// (get) Token: 0x0601F5D7 RID: 128471 RVA: 0x0090FD8E File Offset: 0x0090DF8E
		// (set) Token: 0x0601F5D8 RID: 128472 RVA: 0x0090FD9E File Offset: 0x0090DF9E
		public unsafe float InvShadow
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_InteriorLightDecal_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_InteriorLightDecal_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17002F72 RID: 12146
		// (get) Token: 0x0601F5D9 RID: 128473 RVA: 0x0090FDAF File Offset: 0x0090DFAF
		// (set) Token: 0x0601F5DA RID: 128474 RVA: 0x0090FDBF File Offset: 0x0090DFBF
		public unsafe int DALayer
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_InteriorLightDecal_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_InteriorLightDecal_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17002F73 RID: 12147
		// (get) Token: 0x0601F5DB RID: 128475 RVA: 0x0090FDD0 File Offset: 0x0090DFD0
		// (set) Token: 0x0601F5DC RID: 128476 RVA: 0x0090FDE4 File Offset: 0x0090DFE4
		public unsafe FName MPC_Name
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_InteriorLightDecal_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_InteriorLightDecal_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17002F74 RID: 12148
		// (get) Token: 0x0601F5DD RID: 128477 RVA: 0x0090FDF9 File Offset: 0x0090DFF9
		// (set) Token: 0x0601F5DE RID: 128478 RVA: 0x0090FE09 File Offset: 0x0090E009
		public unsafe bool bEnable
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_InteriorLightDecal_C.__PropertyOffset_8) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_InteriorLightDecal_C.__PropertyOffset_8) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002F75 RID: 12149
		// (get) Token: 0x0601F5DF RID: 128479 RVA: 0x0090FE1A File Offset: 0x0090E01A
		// (set) Token: 0x0601F5E0 RID: 128480 RVA: 0x0090FE2A File Offset: 0x0090E02A
		public unsafe float RestoreVal
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_InteriorLightDecal_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_InteriorLightDecal_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17002F76 RID: 12150
		// (get) Token: 0x0601F5E1 RID: 128481 RVA: 0x0090FE3B File Offset: 0x0090E03B
		// (set) Token: 0x0601F5E2 RID: 128482 RVA: 0x0090FE4B File Offset: 0x0090E04B
		public unsafe float DeltaTimeTick
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_InteriorLightDecal_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_InteriorLightDecal_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x0601F5E3 RID: 128483 RVA: 0x0090FE5C File Offset: 0x0090E05C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void FromDa()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InteriorLightDecal_C.__FromDa_NativeFunctionPtr, null);
		}

		// Token: 0x0601F5E4 RID: 128484 RVA: 0x0090FE70 File Offset: 0x0090E070
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InteriorLightDecal_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x0601F5E5 RID: 128485 RVA: 0x0090FE84 File Offset: 0x0090E084
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_InteriorLightDecal_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601F5E6 RID: 128486 RVA: 0x0090FE9C File Offset: 0x0090E09C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_InteriorLightDecal_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_InteriorLightDecal_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_InteriorLightDecal_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InteriorLightDecal_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InteriorLightDecal_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F5E7 RID: 128487 RVA: 0x0090FEE4 File Offset: 0x0090E0E4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_InteriorLightDecal_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_InteriorLightDecal_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_InteriorLightDecal_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InteriorLightDecal_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_InteriorLightDecal_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601F5E8 RID: 128488 RVA: 0x0090FF2C File Offset: 0x0090E12C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_InteriorLightDecal(int EntryPoint)
		{
			BP_InteriorLightDecal_C.__ExecuteUbergraph_BP_InteriorLightDecal_FunctionParams* ptr = stackalloc BP_InteriorLightDecal_C.__ExecuteUbergraph_BP_InteriorLightDecal_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_InteriorLightDecal_C.__ExecuteUbergraph_BP_InteriorLightDecal_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InteriorLightDecal_C.__ExecuteUbergraph_BP_InteriorLightDecal_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_InteriorLightDecal_C.__ExecuteUbergraph_BP_InteriorLightDecal_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601F5E9 RID: 128489 RVA: 0x0090FF73 File Offset: 0x0090E173
		protected BP_InteriorLightDecal_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400F919 RID: 63769
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Light/BP_InteriorLightDecal.BP_InteriorLightDecal_C";

		// Token: 0x0400F91A RID: 63770
		private static IntPtr _ClassPtr;

		// Token: 0x0400F91B RID: 63771
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400F91C RID: 63772
		internal static int __PropertyOffset_0;

		// Token: 0x0400F91D RID: 63773
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400F91E RID: 63774
		internal static int __PropertyOffset_1;

		// Token: 0x0400F91F RID: 63775
		internal static int __PropertyOffset_2;

		// Token: 0x0400F920 RID: 63776
		internal static int __PropertyOffset_3;

		// Token: 0x0400F921 RID: 63777
		internal static int __PropertyOffset_4;

		// Token: 0x0400F922 RID: 63778
		internal static int __PropertyOffset_5;

		// Token: 0x0400F923 RID: 63779
		internal static int __PropertyOffset_6;

		// Token: 0x0400F924 RID: 63780
		internal static int __PropertyOffset_7;

		// Token: 0x0400F925 RID: 63781
		internal static int __PropertyOffset_8;

		// Token: 0x0400F926 RID: 63782
		internal static int __PropertyOffset_9;

		// Token: 0x0400F927 RID: 63783
		internal static int __PropertyOffset_10;

		// Token: 0x0400F928 RID: 63784
		private static IntPtr __FromDa_NativeFunctionPtr;

		// Token: 0x0400F929 RID: 63785
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x0400F92A RID: 63786
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0400F92B RID: 63787
		private static IntPtr __ExecuteUbergraph_BP_InteriorLightDecal_NativeFunctionPtr;

		// Token: 0x020098D2 RID: 39122
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04031F27 RID: 204583
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x020098D3 RID: 39123
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __ExecuteUbergraph_BP_InteriorLightDecal_FunctionParams
		{
			// Token: 0x04031F28 RID: 204584
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
