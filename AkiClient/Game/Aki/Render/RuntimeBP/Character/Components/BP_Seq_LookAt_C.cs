using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Character.Components
{
	// Token: 0x02003D93 RID: 15763
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Character/Components/BP_Seq_LookAt.BP_Seq_LookAt_C")]
	[UnrealStructLayout(1360, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1357)]
	public class BP_Seq_LookAt_C : AKuroEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060267FE RID: 157694 RVA: 0x009D9F5C File Offset: 0x009D815C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_Seq_LookAt_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Character/Components/BP_Seq_LookAt.BP_Seq_LookAt_C");
			}
			return BP_Seq_LookAt_C._ClassPtr;
		}

		// Token: 0x060267FF RID: 157695 RVA: 0x009D9F80 File Offset: 0x009D8180
		public BP_Seq_LookAt_C() : this(BuiltinUtils.AllocNativeUObject(BP_Seq_LookAt_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06026800 RID: 157696 RVA: 0x009D9FA8 File Offset: 0x009D81A8
		[NullableContext(1)]
		public BP_Seq_LookAt_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_Seq_LookAt_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170057A3 RID: 22435
		// (get) Token: 0x06026801 RID: 157697 RVA: 0x009D9FDC File Offset: 0x009D81DC
		// (set) Token: 0x06026802 RID: 157698 RVA: 0x009DA015 File Offset: 0x009D8215
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_Seq_LookAt_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_Seq_LookAt_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170057A4 RID: 22436
		// (get) Token: 0x06026803 RID: 157699 RVA: 0x009DA036 File Offset: 0x009D8236
		// (set) Token: 0x06026804 RID: 157700 RVA: 0x009DA04A File Offset: 0x009D824A
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Seq_LookAt_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Seq_LookAt_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170057A5 RID: 22437
		// (get) Token: 0x06026805 RID: 157701 RVA: 0x009DA05F File Offset: 0x009D825F
		// (set) Token: 0x06026806 RID: 157702 RVA: 0x009DA073 File Offset: 0x009D8273
		public unsafe ANiagaraActor Niagara
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<ANiagaraActor>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Seq_LookAt_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Seq_LookAt_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x170057A6 RID: 22438
		// (get) Token: 0x06026807 RID: 157703 RVA: 0x009DA088 File Offset: 0x009D8288
		// (set) Token: 0x06026808 RID: 157704 RVA: 0x009DA09C File Offset: 0x009D829C
		public unsafe AActor Target
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Seq_LookAt_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Seq_LookAt_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x170057A7 RID: 22439
		// (get) Token: 0x06026809 RID: 157705 RVA: 0x009DA0B1 File Offset: 0x009D82B1
		// (set) Token: 0x0602680A RID: 157706 RVA: 0x009DA0C1 File Offset: 0x009D82C1
		public unsafe float Pitch
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Seq_LookAt_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Seq_LookAt_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x170057A8 RID: 22440
		// (get) Token: 0x0602680B RID: 157707 RVA: 0x009DA0D2 File Offset: 0x009D82D2
		// (set) Token: 0x0602680C RID: 157708 RVA: 0x009DA0E2 File Offset: 0x009D82E2
		public unsafe float Yaw
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Seq_LookAt_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Seq_LookAt_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x170057A9 RID: 22441
		// (get) Token: 0x0602680D RID: 157709 RVA: 0x009DA0F3 File Offset: 0x009D82F3
		// (set) Token: 0x0602680E RID: 157710 RVA: 0x009DA103 File Offset: 0x009D8303
		public unsafe float Roll
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Seq_LookAt_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Seq_LookAt_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x170057AA RID: 22442
		// (get) Token: 0x0602680F RID: 157711 RVA: 0x009DA114 File Offset: 0x009D8314
		// (set) Token: 0x06026810 RID: 157712 RVA: 0x009DA124 File Offset: 0x009D8324
		public unsafe bool bOverrideNiagaraRotation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Seq_LookAt_C.__PropertyOffset_7) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Seq_LookAt_C.__PropertyOffset_7) = (value ? 1 : 0);
			}
		}

		// Token: 0x06026811 RID: 157713 RVA: 0x009DA138 File Offset: 0x009D8338
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_Seq_LookAt_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_Seq_LookAt_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Seq_LookAt_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Seq_LookAt_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Seq_LookAt_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06026812 RID: 157714 RVA: 0x009DA180 File Offset: 0x009D8380
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_Seq_LookAt_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_Seq_LookAt_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Seq_LookAt_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Seq_LookAt_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Seq_LookAt_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06026813 RID: 157715 RVA: 0x009DA1C8 File Offset: 0x009D83C8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_Seq_LookAt_C.__EditorTick_FunctionParams* ptr = stackalloc BP_Seq_LookAt_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Seq_LookAt_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Seq_LookAt_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Seq_LookAt_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06026814 RID: 157716 RVA: 0x009DA210 File Offset: 0x009D8410
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_Seq_LookAt_C.__EditorTick_FunctionParams* ptr = stackalloc BP_Seq_LookAt_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Seq_LookAt_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Seq_LookAt_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Seq_LookAt_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06026815 RID: 157717 RVA: 0x009DA258 File Offset: 0x009D8458
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_Seq_LookAt(int EntryPoint)
		{
			BP_Seq_LookAt_C.__ExecuteUbergraph_BP_Seq_LookAt_FunctionParams* ptr = stackalloc BP_Seq_LookAt_C.__ExecuteUbergraph_BP_Seq_LookAt_FunctionParams[(UIntPtr)439] + 15L / (long)sizeof(BP_Seq_LookAt_C.__ExecuteUbergraph_BP_Seq_LookAt_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Seq_LookAt_C.__ExecuteUbergraph_BP_Seq_LookAt_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Seq_LookAt_C.__ExecuteUbergraph_BP_Seq_LookAt_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06026816 RID: 157718 RVA: 0x009DA2A2 File Offset: 0x009D84A2
		protected BP_Seq_LookAt_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401403B RID: 81979
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Character/Components/BP_Seq_LookAt.BP_Seq_LookAt_C";

		// Token: 0x0401403C RID: 81980
		private static IntPtr _ClassPtr;

		// Token: 0x0401403D RID: 81981
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401403E RID: 81982
		internal static int __PropertyOffset_0;

		// Token: 0x0401403F RID: 81983
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04014040 RID: 81984
		internal static int __PropertyOffset_1;

		// Token: 0x04014041 RID: 81985
		internal static int __PropertyOffset_2;

		// Token: 0x04014042 RID: 81986
		internal static int __PropertyOffset_3;

		// Token: 0x04014043 RID: 81987
		internal static int __PropertyOffset_4;

		// Token: 0x04014044 RID: 81988
		internal static int __PropertyOffset_5;

		// Token: 0x04014045 RID: 81989
		internal static int __PropertyOffset_6;

		// Token: 0x04014046 RID: 81990
		internal static int __PropertyOffset_7;

		// Token: 0x04014047 RID: 81991
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04014048 RID: 81992
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x04014049 RID: 81993
		private static IntPtr __ExecuteUbergraph_BP_Seq_LookAt_NativeFunctionPtr;

		// Token: 0x0200A078 RID: 41080
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032D00 RID: 208128
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x0200A079 RID: 41081
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x04032D01 RID: 208129
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x0200A07A RID: 41082
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 424)]
		protected ref struct __ExecuteUbergraph_BP_Seq_LookAt_FunctionParams
		{
			// Token: 0x04032D02 RID: 208130
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
