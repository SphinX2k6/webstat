using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Water.BP
{
	// Token: 0x02003A0B RID: 14859
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Water/BP/BP_WaterBuoyancyCollision.BP_WaterBuoyancyCollision_C")]
	[UnrealStructLayout(1376, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1370)]
	public class BP_WaterBuoyancyCollision_C : AKuroBPActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601E52A RID: 124202 RVA: 0x008F2DF3 File Offset: 0x008F0FF3
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_WaterBuoyancyCollision_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Water/BP/BP_WaterBuoyancyCollision.BP_WaterBuoyancyCollision_C");
			}
			return BP_WaterBuoyancyCollision_C._ClassPtr;
		}

		// Token: 0x0601E52B RID: 124203 RVA: 0x008F2E18 File Offset: 0x008F1018
		public BP_WaterBuoyancyCollision_C() : this(BuiltinUtils.AllocNativeUObject(BP_WaterBuoyancyCollision_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601E52C RID: 124204 RVA: 0x008F2E40 File Offset: 0x008F1040
		[NullableContext(1)]
		public BP_WaterBuoyancyCollision_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_WaterBuoyancyCollision_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17002998 RID: 10648
		// (get) Token: 0x0601E52D RID: 124205 RVA: 0x008F2E74 File Offset: 0x008F1074
		// (set) Token: 0x0601E52E RID: 124206 RVA: 0x008F2EAD File Offset: 0x008F10AD
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_WaterBuoyancyCollision_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_WaterBuoyancyCollision_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17002999 RID: 10649
		// (get) Token: 0x0601E52F RID: 124207 RVA: 0x008F2ECE File Offset: 0x008F10CE
		// (set) Token: 0x0601E530 RID: 124208 RVA: 0x008F2EE2 File Offset: 0x008F10E2
		public unsafe UStaticMeshComponent Sphere1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterBuoyancyCollision_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterBuoyancyCollision_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x1700299A RID: 10650
		// (get) Token: 0x0601E531 RID: 124209 RVA: 0x008F2EF7 File Offset: 0x008F10F7
		// (set) Token: 0x0601E532 RID: 124210 RVA: 0x008F2F0B File Offset: 0x008F110B
		public unsafe UStaticMeshComponent Sphere
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterBuoyancyCollision_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterBuoyancyCollision_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x1700299B RID: 10651
		// (get) Token: 0x0601E533 RID: 124211 RVA: 0x008F2F20 File Offset: 0x008F1120
		// (set) Token: 0x0601E534 RID: 124212 RVA: 0x008F2F34 File Offset: 0x008F1134
		public unsafe USceneComponent Scene
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterBuoyancyCollision_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterBuoyancyCollision_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x1700299C RID: 10652
		// (get) Token: 0x0601E535 RID: 124213 RVA: 0x008F2F49 File Offset: 0x008F1149
		// (set) Token: 0x0601E536 RID: 124214 RVA: 0x008F2F5D File Offset: 0x008F115D
		public unsafe UBoxComponent Box
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterBuoyancyCollision_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterBuoyancyCollision_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x1700299D RID: 10653
		// (get) Token: 0x0601E537 RID: 124215 RVA: 0x008F2F72 File Offset: 0x008F1172
		// (set) Token: 0x0601E538 RID: 124216 RVA: 0x008F2F86 File Offset: 0x008F1186
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterBuoyancyCollision_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterBuoyancyCollision_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x1700299E RID: 10654
		// (get) Token: 0x0601E539 RID: 124217 RVA: 0x008F2F9B File Offset: 0x008F119B
		// (set) Token: 0x0601E53A RID: 124218 RVA: 0x008F2FAF File Offset: 0x008F11AF
		public unsafe FVector BoxExtent
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterBuoyancyCollision_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterBuoyancyCollision_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x1700299F RID: 10655
		// (get) Token: 0x0601E53B RID: 124219 RVA: 0x008F2FC4 File Offset: 0x008F11C4
		// (set) Token: 0x0601E53C RID: 124220 RVA: 0x008F2FD4 File Offset: 0x008F11D4
		public unsafe float Timer
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterBuoyancyCollision_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterBuoyancyCollision_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x170029A0 RID: 10656
		// (get) Token: 0x0601E53D RID: 124221 RVA: 0x008F2FE5 File Offset: 0x008F11E5
		// (set) Token: 0x0601E53E RID: 124222 RVA: 0x008F2FF5 File Offset: 0x008F11F5
		public unsafe bool InBox
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterBuoyancyCollision_C.__PropertyOffset_8) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterBuoyancyCollision_C.__PropertyOffset_8) = (value ? 1 : 0);
			}
		}

		// Token: 0x170029A1 RID: 10657
		// (get) Token: 0x0601E53F RID: 124223 RVA: 0x008F3006 File Offset: 0x008F1206
		// (set) Token: 0x0601E540 RID: 124224 RVA: 0x008F3016 File Offset: 0x008F1216
		public unsafe bool AlwaysFlow
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterBuoyancyCollision_C.__PropertyOffset_9) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterBuoyancyCollision_C.__PropertyOffset_9) = (value ? 1 : 0);
			}
		}

		// Token: 0x0601E541 RID: 124225 RVA: 0x008F3027 File Offset: 0x008F1227
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WaterBuoyancyCollision_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x0601E542 RID: 124226 RVA: 0x008F303B File Offset: 0x008F123B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_WaterBuoyancyCollision_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601E543 RID: 124227 RVA: 0x008F3050 File Offset: 0x008F1250
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WaterBuoyancyCollision_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0601E544 RID: 124228 RVA: 0x008F3064 File Offset: 0x008F1264
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_WaterBuoyancyCollision_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601E545 RID: 124229 RVA: 0x008F307C File Offset: 0x008F127C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_WaterBuoyancyCollision_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_WaterBuoyancyCollision_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_WaterBuoyancyCollision_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WaterBuoyancyCollision_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WaterBuoyancyCollision_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601E546 RID: 124230 RVA: 0x008F30C4 File Offset: 0x008F12C4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_WaterBuoyancyCollision_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_WaterBuoyancyCollision_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_WaterBuoyancyCollision_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WaterBuoyancyCollision_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_WaterBuoyancyCollision_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601E547 RID: 124231 RVA: 0x008F310C File Offset: 0x008F130C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_WaterBuoyancyCollision(int EntryPoint)
		{
			BP_WaterBuoyancyCollision_C.__ExecuteUbergraph_BP_WaterBuoyancyCollision_FunctionParams* ptr = stackalloc BP_WaterBuoyancyCollision_C.__ExecuteUbergraph_BP_WaterBuoyancyCollision_FunctionParams[(UIntPtr)287] + 15L / (long)sizeof(BP_WaterBuoyancyCollision_C.__ExecuteUbergraph_BP_WaterBuoyancyCollision_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WaterBuoyancyCollision_C.__ExecuteUbergraph_BP_WaterBuoyancyCollision_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_WaterBuoyancyCollision_C.__ExecuteUbergraph_BP_WaterBuoyancyCollision_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601E548 RID: 124232 RVA: 0x008F3156 File Offset: 0x008F1356
		protected BP_WaterBuoyancyCollision_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400EEAE RID: 61102
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Water/BP/BP_WaterBuoyancyCollision.BP_WaterBuoyancyCollision_C";

		// Token: 0x0400EEAF RID: 61103
		private static IntPtr _ClassPtr;

		// Token: 0x0400EEB0 RID: 61104
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400EEB1 RID: 61105
		internal static int __PropertyOffset_0;

		// Token: 0x0400EEB2 RID: 61106
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400EEB3 RID: 61107
		internal static int __PropertyOffset_1;

		// Token: 0x0400EEB4 RID: 61108
		internal static int __PropertyOffset_2;

		// Token: 0x0400EEB5 RID: 61109
		internal static int __PropertyOffset_3;

		// Token: 0x0400EEB6 RID: 61110
		internal static int __PropertyOffset_4;

		// Token: 0x0400EEB7 RID: 61111
		internal static int __PropertyOffset_5;

		// Token: 0x0400EEB8 RID: 61112
		internal static int __PropertyOffset_6;

		// Token: 0x0400EEB9 RID: 61113
		internal static int __PropertyOffset_7;

		// Token: 0x0400EEBA RID: 61114
		internal static int __PropertyOffset_8;

		// Token: 0x0400EEBB RID: 61115
		internal static int __PropertyOffset_9;

		// Token: 0x0400EEBC RID: 61116
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x0400EEBD RID: 61117
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0400EEBE RID: 61118
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0400EEBF RID: 61119
		private static IntPtr __ExecuteUbergraph_BP_WaterBuoyancyCollision_NativeFunctionPtr;

		// Token: 0x020097A6 RID: 38822
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04031D72 RID: 204146
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x020097A7 RID: 38823
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 272)]
		protected ref struct __ExecuteUbergraph_BP_WaterBuoyancyCollision_FunctionParams
		{
			// Token: 0x04031D73 RID: 204147
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
