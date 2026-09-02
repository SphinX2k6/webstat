using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PSOSwitchSettingDebug.Niagara
{
	// Token: 0x02003B48 RID: 15176
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PSOSwitchSettingDebug/Niagara/BP_PSONiagaraPreviwer.BP_PSONiagaraPreviwer_C")]
	[UnrealStructLayout(1384, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1384)]
	public class BP_PSONiagaraPreviwer_C : AKuroEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06020E9E RID: 134814 RVA: 0x0093AA9F File Offset: 0x00938C9F
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_PSONiagaraPreviwer_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PSOSwitchSettingDebug/Niagara/BP_PSONiagaraPreviwer.BP_PSONiagaraPreviwer_C");
			}
			return BP_PSONiagaraPreviwer_C._ClassPtr;
		}

		// Token: 0x06020E9F RID: 134815 RVA: 0x0093AAC4 File Offset: 0x00938CC4
		public BP_PSONiagaraPreviwer_C() : this(BuiltinUtils.AllocNativeUObject(BP_PSONiagaraPreviwer_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06020EA0 RID: 134816 RVA: 0x0093AAEC File Offset: 0x00938CEC
		public BP_PSONiagaraPreviwer_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_PSONiagaraPreviwer_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170037F6 RID: 14326
		// (get) Token: 0x06020EA1 RID: 134817 RVA: 0x0093AB20 File Offset: 0x00938D20
		// (set) Token: 0x06020EA2 RID: 134818 RVA: 0x0093AB59 File Offset: 0x00938D59
		public FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_PSONiagaraPreviwer_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_PSONiagaraPreviwer_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170037F7 RID: 14327
		// (get) Token: 0x06020EA3 RID: 134819 RVA: 0x0093AB7A File Offset: 0x00938D7A
		// (set) Token: 0x06020EA4 RID: 134820 RVA: 0x0093AB8E File Offset: 0x00938D8E
		[Nullable(2)]
		public unsafe UNiagaraComponent Niagara
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PSONiagaraPreviwer_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PSONiagaraPreviwer_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170037F8 RID: 14328
		// (get) Token: 0x06020EA5 RID: 134821 RVA: 0x0093ABA3 File Offset: 0x00938DA3
		// (set) Token: 0x06020EA6 RID: 134822 RVA: 0x0093ABB7 File Offset: 0x00938DB7
		[Nullable(2)]
		public unsafe PDA_PSONiagaraMaterialList_C Config
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<PDA_PSONiagaraMaterialList_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PSONiagaraPreviwer_C.__PropertyOffset_2);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PSONiagaraPreviwer_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x170037F9 RID: 14329
		// (get) Token: 0x06020EA7 RID: 134823 RVA: 0x0093ABCC File Offset: 0x00938DCC
		// (set) Token: 0x06020EA8 RID: 134824 RVA: 0x0093ABDC File Offset: 0x00938DDC
		public unsafe int SpriteCounter
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PSONiagaraPreviwer_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PSONiagaraPreviwer_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x170037FA RID: 14330
		// (get) Token: 0x06020EA9 RID: 134825 RVA: 0x0093ABED File Offset: 0x00938DED
		// (set) Token: 0x06020EAA RID: 134826 RVA: 0x0093ABFD File Offset: 0x00938DFD
		public unsafe int MeshCounter
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PSONiagaraPreviwer_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PSONiagaraPreviwer_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x170037FB RID: 14331
		// (get) Token: 0x06020EAB RID: 134827 RVA: 0x0093AC0E File Offset: 0x00938E0E
		// (set) Token: 0x06020EAC RID: 134828 RVA: 0x0093AC1E File Offset: 0x00938E1E
		public unsafe bool Found
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PSONiagaraPreviwer_C.__PropertyOffset_5) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PSONiagaraPreviwer_C.__PropertyOffset_5) = (value ? 1 : 0);
			}
		}

		// Token: 0x170037FC RID: 14332
		// (get) Token: 0x06020EAD RID: 134829 RVA: 0x0093AC2F File Offset: 0x00938E2F
		// (set) Token: 0x06020EAE RID: 134830 RVA: 0x0093AC3F File Offset: 0x00938E3F
		public unsafe int StartSearchIndex
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PSONiagaraPreviwer_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PSONiagaraPreviwer_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x170037FD RID: 14333
		// (get) Token: 0x06020EAF RID: 134831 RVA: 0x0093AC50 File Offset: 0x00938E50
		// (set) Token: 0x06020EB0 RID: 134832 RVA: 0x0093AC60 File Offset: 0x00938E60
		public unsafe int ArrayLength
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PSONiagaraPreviwer_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PSONiagaraPreviwer_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x170037FE RID: 14334
		// (get) Token: 0x06020EB1 RID: 134833 RVA: 0x0093AC71 File Offset: 0x00938E71
		// (set) Token: 0x06020EB2 RID: 134834 RVA: 0x0093AC81 File Offset: 0x00938E81
		public unsafe float TickCounter
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PSONiagaraPreviwer_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PSONiagaraPreviwer_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x170037FF RID: 14335
		// (get) Token: 0x06020EB3 RID: 134835 RVA: 0x0093AC92 File Offset: 0x00938E92
		// (set) Token: 0x06020EB4 RID: 134836 RVA: 0x0093ACA2 File Offset: 0x00938EA2
		public unsafe int RibbonCounter
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PSONiagaraPreviwer_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PSONiagaraPreviwer_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17003800 RID: 14336
		// (get) Token: 0x06020EB5 RID: 134837 RVA: 0x0093ACB3 File Offset: 0x00938EB3
		// (set) Token: 0x06020EB6 RID: 134838 RVA: 0x0093ACC7 File Offset: 0x00938EC7
		public unsafe string MaterialsFilePath
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)BP_PSONiagaraPreviwer_C.__PropertyOffset_10)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)BP_PSONiagaraPreviwer_C.__PropertyOffset_10)), value);
			}
		}

		// Token: 0x06020EB7 RID: 134839 RVA: 0x0093ACDC File Offset: 0x00938EDC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void WriteToConfig()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PSONiagaraPreviwer_C.__WriteToConfig_NativeFunctionPtr, null);
		}

		// Token: 0x06020EB8 RID: 134840 RVA: 0x0093ACF0 File Offset: 0x00938EF0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PSONiagaraPreviwer_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06020EB9 RID: 134841 RVA: 0x0093AD04 File Offset: 0x00938F04
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_PSONiagaraPreviwer_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06020EBA RID: 134842 RVA: 0x0093AD1C File Offset: 0x00938F1C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_PSONiagaraPreviwer_C.__EditorTick_FunctionParams* ptr = stackalloc BP_PSONiagaraPreviwer_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_PSONiagaraPreviwer_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_PSONiagaraPreviwer_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PSONiagaraPreviwer_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06020EBB RID: 134843 RVA: 0x0093AD64 File Offset: 0x00938F64
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_PSONiagaraPreviwer_C.__EditorTick_FunctionParams* ptr = stackalloc BP_PSONiagaraPreviwer_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_PSONiagaraPreviwer_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_PSONiagaraPreviwer_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_PSONiagaraPreviwer_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06020EBC RID: 134844 RVA: 0x0093ADAC File Offset: 0x00938FAC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_PSONiagaraPreviwer_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_PSONiagaraPreviwer_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_PSONiagaraPreviwer_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_PSONiagaraPreviwer_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PSONiagaraPreviwer_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06020EBD RID: 134845 RVA: 0x0093ADF4 File Offset: 0x00938FF4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_PSONiagaraPreviwer_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_PSONiagaraPreviwer_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_PSONiagaraPreviwer_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_PSONiagaraPreviwer_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_PSONiagaraPreviwer_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06020EBE RID: 134846 RVA: 0x0093AE3C File Offset: 0x0093903C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_PSONiagaraPreviwer(int EntryPoint)
		{
			BP_PSONiagaraPreviwer_C.__ExecuteUbergraph_BP_PSONiagaraPreviwer_FunctionParams* ptr = stackalloc BP_PSONiagaraPreviwer_C.__ExecuteUbergraph_BP_PSONiagaraPreviwer_FunctionParams[(UIntPtr)319] + 15L / (long)sizeof(BP_PSONiagaraPreviwer_C.__ExecuteUbergraph_BP_PSONiagaraPreviwer_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_PSONiagaraPreviwer_C.__ExecuteUbergraph_BP_PSONiagaraPreviwer_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_PSONiagaraPreviwer_C.__ExecuteUbergraph_BP_PSONiagaraPreviwer_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06020EBF RID: 134847 RVA: 0x0093AE86 File Offset: 0x00939086
		protected BP_PSONiagaraPreviwer_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401084E RID: 67662
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PSOSwitchSettingDebug/Niagara/BP_PSONiagaraPreviwer.BP_PSONiagaraPreviwer_C";

		// Token: 0x0401084F RID: 67663
		private static IntPtr _ClassPtr;

		// Token: 0x04010850 RID: 67664
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04010851 RID: 67665
		internal static int __PropertyOffset_0;

		// Token: 0x04010852 RID: 67666
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04010853 RID: 67667
		internal static int __PropertyOffset_1;

		// Token: 0x04010854 RID: 67668
		internal static int __PropertyOffset_2;

		// Token: 0x04010855 RID: 67669
		internal static int __PropertyOffset_3;

		// Token: 0x04010856 RID: 67670
		internal static int __PropertyOffset_4;

		// Token: 0x04010857 RID: 67671
		internal static int __PropertyOffset_5;

		// Token: 0x04010858 RID: 67672
		internal static int __PropertyOffset_6;

		// Token: 0x04010859 RID: 67673
		internal static int __PropertyOffset_7;

		// Token: 0x0401085A RID: 67674
		internal static int __PropertyOffset_8;

		// Token: 0x0401085B RID: 67675
		internal static int __PropertyOffset_9;

		// Token: 0x0401085C RID: 67676
		internal static int __PropertyOffset_10;

		// Token: 0x0401085D RID: 67677
		private static IntPtr __WriteToConfig_NativeFunctionPtr;

		// Token: 0x0401085E RID: 67678
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x0401085F RID: 67679
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x04010860 RID: 67680
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04010861 RID: 67681
		private static IntPtr __ExecuteUbergraph_BP_PSONiagaraPreviwer_NativeFunctionPtr;

		// Token: 0x02009A4C RID: 39500
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x0403214D RID: 205133
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009A4D RID: 39501
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x0403214E RID: 205134
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009A4E RID: 39502
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 304)]
		protected ref struct __ExecuteUbergraph_BP_PSONiagaraPreviwer_FunctionParams
		{
			// Token: 0x0403214F RID: 205135
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
