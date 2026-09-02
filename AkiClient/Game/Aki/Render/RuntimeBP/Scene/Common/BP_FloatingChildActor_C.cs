using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Common
{
	// Token: 0x02003AD7 RID: 15063
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Common/BP_FloatingChildActor.BP_FloatingChildActor_C")]
	[UnrealStructLayout(1392, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1392)]
	public class BP_FloatingChildActor_C : AKuroEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06020390 RID: 131984 RVA: 0x00925C38 File Offset: 0x00923E38
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_FloatingChildActor_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/Common/BP_FloatingChildActor.BP_FloatingChildActor_C");
			}
			return BP_FloatingChildActor_C._ClassPtr;
		}

		// Token: 0x06020391 RID: 131985 RVA: 0x00925C5C File Offset: 0x00923E5C
		public BP_FloatingChildActor_C() : this(BuiltinUtils.AllocNativeUObject(BP_FloatingChildActor_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06020392 RID: 131986 RVA: 0x00925C84 File Offset: 0x00923E84
		[NullableContext(1)]
		public BP_FloatingChildActor_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_FloatingChildActor_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700347C RID: 13436
		// (get) Token: 0x06020393 RID: 131987 RVA: 0x00925CB8 File Offset: 0x00923EB8
		// (set) Token: 0x06020394 RID: 131988 RVA: 0x00925CF1 File Offset: 0x00923EF1
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_FloatingChildActor_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_FloatingChildActor_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700347D RID: 13437
		// (get) Token: 0x06020395 RID: 131989 RVA: 0x00925D12 File Offset: 0x00923F12
		// (set) Token: 0x06020396 RID: 131990 RVA: 0x00925D26 File Offset: 0x00923F26
		public unsafe USceneComponent Scene
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FloatingChildActor_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FloatingChildActor_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x1700347E RID: 13438
		// (get) Token: 0x06020397 RID: 131991 RVA: 0x00925D3B File Offset: 0x00923F3B
		// (set) Token: 0x06020398 RID: 131992 RVA: 0x00925D4B File Offset: 0x00923F4B
		public unsafe float Age
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FloatingChildActor_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FloatingChildActor_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x1700347F RID: 13439
		// (get) Token: 0x06020399 RID: 131993 RVA: 0x00925D5C File Offset: 0x00923F5C
		// (set) Token: 0x0602039A RID: 131994 RVA: 0x00925D70 File Offset: 0x00923F70
		public unsafe FVector Movement
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FloatingChildActor_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FloatingChildActor_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17003480 RID: 13440
		// (get) Token: 0x0602039B RID: 131995 RVA: 0x00925D85 File Offset: 0x00923F85
		// (set) Token: 0x0602039C RID: 131996 RVA: 0x00925D95 File Offset: 0x00923F95
		public unsafe float Frequency
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FloatingChildActor_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FloatingChildActor_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17003481 RID: 13441
		// (get) Token: 0x0602039D RID: 131997 RVA: 0x00925DA6 File Offset: 0x00923FA6
		// (set) Token: 0x0602039E RID: 131998 RVA: 0x00925DBA File Offset: 0x00923FBA
		public unsafe FVector RotateCenter
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FloatingChildActor_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FloatingChildActor_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17003482 RID: 13442
		// (get) Token: 0x0602039F RID: 131999 RVA: 0x00925DCF File Offset: 0x00923FCF
		// (set) Token: 0x060203A0 RID: 132000 RVA: 0x00925DE3 File Offset: 0x00923FE3
		public unsafe FRotator Rotation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FloatingChildActor_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FloatingChildActor_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17003483 RID: 13443
		// (get) Token: 0x060203A1 RID: 132001 RVA: 0x00925DF8 File Offset: 0x00923FF8
		// (set) Token: 0x060203A2 RID: 132002 RVA: 0x00925E0C File Offset: 0x0092400C
		public unsafe UChildActorComponent ChildActorComponent
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FloatingChildActor_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FloatingChildActor_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x17003484 RID: 13444
		// (get) Token: 0x060203A3 RID: 132003 RVA: 0x00925E21 File Offset: 0x00924021
		// (set) Token: 0x060203A4 RID: 132004 RVA: 0x00925E35 File Offset: 0x00924035
		[Nullable(new byte[]
		{
			0,
			1
		})]
		public unsafe TSubclassOf<AActor> BPClass
		{
			[return: Nullable(new byte[]
			{
				0,
				1
			})]
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FloatingChildActor_C.__PropertyOffset_8);
			}
			[param: Nullable(new byte[]
			{
				0,
				1
			})]
			set
			{
				*(base.NativePtr + (IntPtr)BP_FloatingChildActor_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x060203A5 RID: 132005 RVA: 0x00925E4A File Offset: 0x0092404A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FloatingChildActor_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x060203A6 RID: 132006 RVA: 0x00925E5E File Offset: 0x0092405E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_FloatingChildActor_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060203A7 RID: 132007 RVA: 0x00925E74 File Offset: 0x00924074
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_FloatingChildActor_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_FloatingChildActor_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_FloatingChildActor_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FloatingChildActor_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FloatingChildActor_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060203A8 RID: 132008 RVA: 0x00925EBC File Offset: 0x009240BC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_FloatingChildActor_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_FloatingChildActor_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_FloatingChildActor_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FloatingChildActor_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_FloatingChildActor_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060203A9 RID: 132009 RVA: 0x00925F04 File Offset: 0x00924104
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_FloatingChildActor_C.__EditorTick_FunctionParams* ptr = stackalloc BP_FloatingChildActor_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_FloatingChildActor_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FloatingChildActor_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FloatingChildActor_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060203AA RID: 132010 RVA: 0x00925F4C File Offset: 0x0092414C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_FloatingChildActor_C.__EditorTick_FunctionParams* ptr = stackalloc BP_FloatingChildActor_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_FloatingChildActor_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FloatingChildActor_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_FloatingChildActor_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060203AB RID: 132011 RVA: 0x00925F94 File Offset: 0x00924194
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_FloatingChildActor(int EntryPoint)
		{
			BP_FloatingChildActor_C.__ExecuteUbergraph_BP_FloatingChildActor_FunctionParams* ptr = stackalloc BP_FloatingChildActor_C.__ExecuteUbergraph_BP_FloatingChildActor_FunctionParams[(UIntPtr)719] + 15L / (long)sizeof(BP_FloatingChildActor_C.__ExecuteUbergraph_BP_FloatingChildActor_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FloatingChildActor_C.__ExecuteUbergraph_BP_FloatingChildActor_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_FloatingChildActor_C.__ExecuteUbergraph_BP_FloatingChildActor_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060203AC RID: 132012 RVA: 0x00925FDE File Offset: 0x009241DE
		protected BP_FloatingChildActor_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04010119 RID: 65817
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Common/BP_FloatingChildActor.BP_FloatingChildActor_C";

		// Token: 0x0401011A RID: 65818
		private static IntPtr _ClassPtr;

		// Token: 0x0401011B RID: 65819
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401011C RID: 65820
		internal static int __PropertyOffset_0;

		// Token: 0x0401011D RID: 65821
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0401011E RID: 65822
		internal static int __PropertyOffset_1;

		// Token: 0x0401011F RID: 65823
		internal static int __PropertyOffset_2;

		// Token: 0x04010120 RID: 65824
		internal static int __PropertyOffset_3;

		// Token: 0x04010121 RID: 65825
		internal static int __PropertyOffset_4;

		// Token: 0x04010122 RID: 65826
		internal static int __PropertyOffset_5;

		// Token: 0x04010123 RID: 65827
		internal static int __PropertyOffset_6;

		// Token: 0x04010124 RID: 65828
		internal static int __PropertyOffset_7;

		// Token: 0x04010125 RID: 65829
		internal static int __PropertyOffset_8;

		// Token: 0x04010126 RID: 65830
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04010127 RID: 65831
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04010128 RID: 65832
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x04010129 RID: 65833
		private static IntPtr __ExecuteUbergraph_BP_FloatingChildActor_NativeFunctionPtr;

		// Token: 0x0200997A RID: 39290
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032000 RID: 204800
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x0200997B RID: 39291
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x04032001 RID: 204801
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x0200997C RID: 39292
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 704)]
		protected ref struct __ExecuteUbergraph_BP_FloatingChildActor_FunctionParams
		{
			// Token: 0x04032002 RID: 204802
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
