using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.AutoPaving
{
	// Token: 0x02003C49 RID: 15433
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/AutoPaving/BP_PCGFlowerBloom.BP_PCGFlowerBloom_C")]
	[UnrealStructLayout(1352, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1350)]
	public class BP_PCGFlowerBloom_C : AKuroEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602386A RID: 145514 RVA: 0x00984A07 File Offset: 0x00982C07
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_PCGFlowerBloom_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/AutoPaving/BP_PCGFlowerBloom.BP_PCGFlowerBloom_C");
			}
			return BP_PCGFlowerBloom_C._ClassPtr;
		}

		// Token: 0x0602386B RID: 145515 RVA: 0x00984A2C File Offset: 0x00982C2C
		public BP_PCGFlowerBloom_C() : this(BuiltinUtils.AllocNativeUObject(BP_PCGFlowerBloom_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602386C RID: 145516 RVA: 0x00984A54 File Offset: 0x00982C54
		[NullableContext(1)]
		public BP_PCGFlowerBloom_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_PCGFlowerBloom_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170046E9 RID: 18153
		// (get) Token: 0x0602386D RID: 145517 RVA: 0x00984A88 File Offset: 0x00982C88
		// (set) Token: 0x0602386E RID: 145518 RVA: 0x00984AC1 File Offset: 0x00982CC1
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_PCGFlowerBloom_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_PCGFlowerBloom_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170046EA RID: 18154
		// (get) Token: 0x0602386F RID: 145519 RVA: 0x00984AE2 File Offset: 0x00982CE2
		// (set) Token: 0x06023870 RID: 145520 RVA: 0x00984AF6 File Offset: 0x00982CF6
		public unsafe UStaticMeshComponent StaticMesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PCGFlowerBloom_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PCGFlowerBloom_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170046EB RID: 18155
		// (get) Token: 0x06023871 RID: 145521 RVA: 0x00984B0B File Offset: 0x00982D0B
		// (set) Token: 0x06023872 RID: 145522 RVA: 0x00984B1F File Offset: 0x00982D1F
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PCGFlowerBloom_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PCGFlowerBloom_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x170046EC RID: 18156
		// (get) Token: 0x06023873 RID: 145523 RVA: 0x00984B34 File Offset: 0x00982D34
		// (set) Token: 0x06023874 RID: 145524 RVA: 0x00984B44 File Offset: 0x00982D44
		public unsafe bool EdirotTick
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PCGFlowerBloom_C.__PropertyOffset_3) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PCGFlowerBloom_C.__PropertyOffset_3) = (value ? 1 : 0);
			}
		}

		// Token: 0x170046ED RID: 18157
		// (get) Token: 0x06023875 RID: 145525 RVA: 0x00984B55 File Offset: 0x00982D55
		// (set) Token: 0x06023876 RID: 145526 RVA: 0x00984B65 File Offset: 0x00982D65
		public unsafe float Delta_Seconds
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PCGFlowerBloom_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PCGFlowerBloom_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x170046EE RID: 18158
		// (get) Token: 0x06023877 RID: 145527 RVA: 0x00984B76 File Offset: 0x00982D76
		// (set) Token: 0x06023878 RID: 145528 RVA: 0x00984B86 File Offset: 0x00982D86
		public unsafe float CustomTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PCGFlowerBloom_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PCGFlowerBloom_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x170046EF RID: 18159
		// (get) Token: 0x06023879 RID: 145529 RVA: 0x00984B97 File Offset: 0x00982D97
		// (set) Token: 0x0602387A RID: 145530 RVA: 0x00984BA7 File Offset: 0x00982DA7
		public unsafe bool Finished
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PCGFlowerBloom_C.__PropertyOffset_6) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PCGFlowerBloom_C.__PropertyOffset_6) = (value ? 1 : 0);
			}
		}

		// Token: 0x170046F0 RID: 18160
		// (get) Token: 0x0602387B RID: 145531 RVA: 0x00984BB8 File Offset: 0x00982DB8
		// (set) Token: 0x0602387C RID: 145532 RVA: 0x00984BC8 File Offset: 0x00982DC8
		public unsafe bool Started
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PCGFlowerBloom_C.__PropertyOffset_7) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PCGFlowerBloom_C.__PropertyOffset_7) = (value ? 1 : 0);
			}
		}

		// Token: 0x0602387D RID: 145533 RVA: 0x00984BD9 File Offset: 0x00982DD9
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PCGFlowerBloom_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0602387E RID: 145534 RVA: 0x00984BED File Offset: 0x00982DED
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_PCGFlowerBloom_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602387F RID: 145535 RVA: 0x00984C04 File Offset: 0x00982E04
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_PCGFlowerBloom_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_PCGFlowerBloom_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_PCGFlowerBloom_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_PCGFlowerBloom_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PCGFlowerBloom_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06023880 RID: 145536 RVA: 0x00984C4C File Offset: 0x00982E4C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_PCGFlowerBloom_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_PCGFlowerBloom_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_PCGFlowerBloom_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_PCGFlowerBloom_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_PCGFlowerBloom_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06023881 RID: 145537 RVA: 0x00984C94 File Offset: 0x00982E94
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_PCGFlowerBloom_C.__EditorTick_FunctionParams* ptr = stackalloc BP_PCGFlowerBloom_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_PCGFlowerBloom_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_PCGFlowerBloom_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PCGFlowerBloom_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06023882 RID: 145538 RVA: 0x00984CDC File Offset: 0x00982EDC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_PCGFlowerBloom_C.__EditorTick_FunctionParams* ptr = stackalloc BP_PCGFlowerBloom_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_PCGFlowerBloom_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_PCGFlowerBloom_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_PCGFlowerBloom_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06023883 RID: 145539 RVA: 0x00984D24 File Offset: 0x00982F24
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_PCGFlowerBloom(int EntryPoint)
		{
			BP_PCGFlowerBloom_C.__ExecuteUbergraph_BP_PCGFlowerBloom_FunctionParams* ptr = stackalloc BP_PCGFlowerBloom_C.__ExecuteUbergraph_BP_PCGFlowerBloom_FunctionParams[(UIntPtr)175] + 15L / (long)sizeof(BP_PCGFlowerBloom_C.__ExecuteUbergraph_BP_PCGFlowerBloom_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_PCGFlowerBloom_C.__ExecuteUbergraph_BP_PCGFlowerBloom_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_PCGFlowerBloom_C.__ExecuteUbergraph_BP_PCGFlowerBloom_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06023884 RID: 145540 RVA: 0x00984D6E File Offset: 0x00982F6E
		protected BP_PCGFlowerBloom_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04012173 RID: 74099
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/AutoPaving/BP_PCGFlowerBloom.BP_PCGFlowerBloom_C";

		// Token: 0x04012174 RID: 74100
		private static IntPtr _ClassPtr;

		// Token: 0x04012175 RID: 74101
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04012176 RID: 74102
		internal static int __PropertyOffset_0;

		// Token: 0x04012177 RID: 74103
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04012178 RID: 74104
		internal static int __PropertyOffset_1;

		// Token: 0x04012179 RID: 74105
		internal static int __PropertyOffset_2;

		// Token: 0x0401217A RID: 74106
		internal static int __PropertyOffset_3;

		// Token: 0x0401217B RID: 74107
		internal static int __PropertyOffset_4;

		// Token: 0x0401217C RID: 74108
		internal static int __PropertyOffset_5;

		// Token: 0x0401217D RID: 74109
		internal static int __PropertyOffset_6;

		// Token: 0x0401217E RID: 74110
		internal static int __PropertyOffset_7;

		// Token: 0x0401217F RID: 74111
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04012180 RID: 74112
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04012181 RID: 74113
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x04012182 RID: 74114
		private static IntPtr __ExecuteUbergraph_BP_PCGFlowerBloom_NativeFunctionPtr;

		// Token: 0x02009CF8 RID: 40184
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032698 RID: 206488
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009CF9 RID: 40185
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x04032699 RID: 206489
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009CFA RID: 40186
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 160)]
		protected ref struct __ExecuteUbergraph_BP_PCGFlowerBloom_FunctionParams
		{
			// Token: 0x0403269A RID: 206490
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
