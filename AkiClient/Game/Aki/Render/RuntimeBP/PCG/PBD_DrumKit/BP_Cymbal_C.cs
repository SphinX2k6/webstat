using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Core.Fight;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.PBD_DrumKit
{
	// Token: 0x02003BB6 RID: 15286
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/PBD_DrumKit/BP_Cymbal.BP_Cymbal_C")]
	[UnrealStructLayout(1424, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1420)]
	public class BP_Cymbal_C : AKuroBPActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06022389 RID: 140169 RVA: 0x0095F18A File Offset: 0x0095D38A
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_Cymbal_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/PBD_DrumKit/BP_Cymbal.BP_Cymbal_C");
			}
			return BP_Cymbal_C._ClassPtr;
		}

		// Token: 0x0602238A RID: 140170 RVA: 0x0095F1B0 File Offset: 0x0095D3B0
		public BP_Cymbal_C() : this(BuiltinUtils.AllocNativeUObject(BP_Cymbal_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602238B RID: 140171 RVA: 0x0095F1D8 File Offset: 0x0095D3D8
		[NullableContext(1)]
		public BP_Cymbal_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_Cymbal_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003FB6 RID: 16310
		// (get) Token: 0x0602238C RID: 140172 RVA: 0x0095F20C File Offset: 0x0095D40C
		// (set) Token: 0x0602238D RID: 140173 RVA: 0x0095F245 File Offset: 0x0095D445
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_Cymbal_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_Cymbal_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17003FB7 RID: 16311
		// (get) Token: 0x0602238E RID: 140174 RVA: 0x0095F266 File Offset: 0x0095D466
		// (set) Token: 0x0602238F RID: 140175 RVA: 0x0095F27A File Offset: 0x0095D47A
		public unsafe UStaticMeshComponent SM_Col_Box_35IS
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Cymbal_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Cymbal_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17003FB8 RID: 16312
		// (get) Token: 0x06022390 RID: 140176 RVA: 0x0095F28F File Offset: 0x0095D48F
		// (set) Token: 0x06022391 RID: 140177 RVA: 0x0095F2A3 File Offset: 0x0095D4A3
		public unsafe UPhysicsConstraintComponent Axis
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UPhysicsConstraintComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Cymbal_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Cymbal_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17003FB9 RID: 16313
		// (get) Token: 0x06022392 RID: 140178 RVA: 0x0095F2B8 File Offset: 0x0095D4B8
		// (set) Token: 0x06022393 RID: 140179 RVA: 0x0095F2CC File Offset: 0x0095D4CC
		public unsafe UStaticMeshComponent Board
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Cymbal_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Cymbal_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17003FBA RID: 16314
		// (get) Token: 0x06022394 RID: 140180 RVA: 0x0095F2E1 File Offset: 0x0095D4E1
		// (set) Token: 0x06022395 RID: 140181 RVA: 0x0095F2F5 File Offset: 0x0095D4F5
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Cymbal_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Cymbal_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17003FBB RID: 16315
		// (get) Token: 0x06022396 RID: 140182 RVA: 0x0095F30A File Offset: 0x0095D50A
		// (set) Token: 0x06022397 RID: 140183 RVA: 0x0095F31A File Offset: 0x0095D51A
		public unsafe float MeshBoundRadius
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Cymbal_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Cymbal_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17003FBC RID: 16316
		// (get) Token: 0x06022398 RID: 140184 RVA: 0x0095F32B File Offset: 0x0095D52B
		// (set) Token: 0x06022399 RID: 140185 RVA: 0x0095F33F File Offset: 0x0095D53F
		public unsafe FVectorDouble MeshPos
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Cymbal_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Cymbal_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17003FBD RID: 16317
		// (get) Token: 0x0602239A RID: 140186 RVA: 0x0095F354 File Offset: 0x0095D554
		// (set) Token: 0x0602239B RID: 140187 RVA: 0x0095F364 File Offset: 0x0095D564
		public unsafe float PlayerImpulseLerpTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Cymbal_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Cymbal_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17003FBE RID: 16318
		// (get) Token: 0x0602239C RID: 140188 RVA: 0x0095F375 File Offset: 0x0095D575
		// (set) Token: 0x0602239D RID: 140189 RVA: 0x0095F385 File Offset: 0x0095D585
		public unsafe float DeltaSeconds
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Cymbal_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Cymbal_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17003FBF RID: 16319
		// (get) Token: 0x0602239E RID: 140190 RVA: 0x0095F396 File Offset: 0x0095D596
		// (set) Token: 0x0602239F RID: 140191 RVA: 0x0095F3A6 File Offset: 0x0095D5A6
		public unsafe float PlayerImpulse
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Cymbal_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Cymbal_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17003FC0 RID: 16320
		// (get) Token: 0x060223A0 RID: 140192 RVA: 0x0095F3B7 File Offset: 0x0095D5B7
		// (set) Token: 0x060223A1 RID: 140193 RVA: 0x0095F3CB File Offset: 0x0095D5CB
		public unsafe FVector CurWeaponPosition
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Cymbal_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Cymbal_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17003FC1 RID: 16321
		// (get) Token: 0x060223A2 RID: 140194 RVA: 0x0095F3E0 File Offset: 0x0095D5E0
		// (set) Token: 0x060223A3 RID: 140195 RVA: 0x0095F3F4 File Offset: 0x0095D5F4
		public unsafe FVector LastWeaponPosition
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Cymbal_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Cymbal_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17003FC2 RID: 16322
		// (get) Token: 0x060223A4 RID: 140196 RVA: 0x0095F409 File Offset: 0x0095D609
		// (set) Token: 0x060223A5 RID: 140197 RVA: 0x0095F419 File Offset: 0x0095D619
		public unsafe float HitRadius
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Cymbal_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Cymbal_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17003FC3 RID: 16323
		// (get) Token: 0x060223A6 RID: 140198 RVA: 0x0095F42A File Offset: 0x0095D62A
		// (set) Token: 0x060223A7 RID: 140199 RVA: 0x0095F43A File Offset: 0x0095D63A
		public unsafe float DamageForce
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Cymbal_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Cymbal_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x060223A8 RID: 140200 RVA: 0x0095F44B File Offset: 0x0095D64B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Cymbal_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x060223A9 RID: 140201 RVA: 0x0095F45F File Offset: 0x0095D65F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Cymbal_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060223AA RID: 140202 RVA: 0x0095F474 File Offset: 0x0095D674
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Completed_F4DF745A4AA730C766F9CC8F60ED218B(int PlayingID)
		{
			BP_Cymbal_C.__Completed_F4DF745A4AA730C766F9CC8F60ED218B_FunctionParams* ptr = stackalloc BP_Cymbal_C.__Completed_F4DF745A4AA730C766F9CC8F60ED218B_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Cymbal_C.__Completed_F4DF745A4AA730C766F9CC8F60ED218B_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Cymbal_C.__Completed_F4DF745A4AA730C766F9CC8F60ED218B_NativeFunctionPtr, (void*)ptr, 1);
			ptr->PlayingID = PlayingID;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Cymbal_C.__Completed_F4DF745A4AA730C766F9CC8F60ED218B_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060223AB RID: 140203 RVA: 0x0095F4BA File Offset: 0x0095D6BA
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void OnLogicEnable()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Cymbal_C.__OnLogicEnable_NativeFunctionPtr, null);
		}

		// Token: 0x060223AC RID: 140204 RVA: 0x0095F4CE File Offset: 0x0095D6CE
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void OnLogicEnable_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Cymbal_C.__OnLogicEnable_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060223AD RID: 140205 RVA: 0x0095F4E3 File Offset: 0x0095D6E3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void OnLogicDisable()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Cymbal_C.__OnLogicDisable_NativeFunctionPtr, null);
		}

		// Token: 0x060223AE RID: 140206 RVA: 0x0095F4F7 File Offset: 0x0095D6F7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void OnLogicDisable_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Cymbal_C.__OnLogicDisable_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060223AF RID: 140207 RVA: 0x0095F50C File Offset: 0x0095D70C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_Cymbal_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_Cymbal_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Cymbal_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Cymbal_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Cymbal_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060223B0 RID: 140208 RVA: 0x0095F554 File Offset: 0x0095D754
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_Cymbal_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_Cymbal_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Cymbal_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Cymbal_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Cymbal_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060223B1 RID: 140209 RVA: 0x0095F59C File Offset: 0x0095D79C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void OnWeaponInteraction(FVectorDouble OriginPoint, BP_SceneBattleInteract_C Config, int Id)
		{
			BP_Cymbal_C.__OnWeaponInteraction_FunctionParams* ptr = stackalloc BP_Cymbal_C.__OnWeaponInteraction_FunctionParams[(UIntPtr)55] + 15L / (long)sizeof(BP_Cymbal_C.__OnWeaponInteraction_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Cymbal_C.__OnWeaponInteraction_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OriginPoint = OriginPoint;
			ptr->Config = ((Config != null) ? Config.NativePtr : IntPtr.Zero);
			ptr->Id = Id;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Cymbal_C.__OnWeaponInteraction_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060223B2 RID: 140210 RVA: 0x0095F5FF File Offset: 0x0095D7FF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Cymbal_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x060223B3 RID: 140211 RVA: 0x0095F613 File Offset: 0x0095D813
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Cymbal_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060223B4 RID: 140212 RVA: 0x0095F628 File Offset: 0x0095D828
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_Cymbal(int EntryPoint)
		{
			BP_Cymbal_C.__ExecuteUbergraph_BP_Cymbal_FunctionParams* ptr = stackalloc BP_Cymbal_C.__ExecuteUbergraph_BP_Cymbal_FunctionParams[(UIntPtr)831] + 15L / (long)sizeof(BP_Cymbal_C.__ExecuteUbergraph_BP_Cymbal_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Cymbal_C.__ExecuteUbergraph_BP_Cymbal_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Cymbal_C.__ExecuteUbergraph_BP_Cymbal_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060223B5 RID: 140213 RVA: 0x0095F672 File Offset: 0x0095D872
		protected BP_Cymbal_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040114CA RID: 70858
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/PBD_DrumKit/BP_Cymbal.BP_Cymbal_C";

		// Token: 0x040114CB RID: 70859
		private static IntPtr _ClassPtr;

		// Token: 0x040114CC RID: 70860
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040114CD RID: 70861
		internal static int __PropertyOffset_0;

		// Token: 0x040114CE RID: 70862
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040114CF RID: 70863
		internal static int __PropertyOffset_1;

		// Token: 0x040114D0 RID: 70864
		internal static int __PropertyOffset_2;

		// Token: 0x040114D1 RID: 70865
		internal static int __PropertyOffset_3;

		// Token: 0x040114D2 RID: 70866
		internal static int __PropertyOffset_4;

		// Token: 0x040114D3 RID: 70867
		internal static int __PropertyOffset_5;

		// Token: 0x040114D4 RID: 70868
		internal static int __PropertyOffset_6;

		// Token: 0x040114D5 RID: 70869
		internal static int __PropertyOffset_7;

		// Token: 0x040114D6 RID: 70870
		internal static int __PropertyOffset_8;

		// Token: 0x040114D7 RID: 70871
		internal static int __PropertyOffset_9;

		// Token: 0x040114D8 RID: 70872
		internal static int __PropertyOffset_10;

		// Token: 0x040114D9 RID: 70873
		internal static int __PropertyOffset_11;

		// Token: 0x040114DA RID: 70874
		internal static int __PropertyOffset_12;

		// Token: 0x040114DB RID: 70875
		internal static int __PropertyOffset_13;

		// Token: 0x040114DC RID: 70876
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x040114DD RID: 70877
		private static IntPtr __Completed_F4DF745A4AA730C766F9CC8F60ED218B_NativeFunctionPtr;

		// Token: 0x040114DE RID: 70878
		private static IntPtr __OnLogicEnable_NativeFunctionPtr;

		// Token: 0x040114DF RID: 70879
		private static IntPtr __OnLogicDisable_NativeFunctionPtr;

		// Token: 0x040114E0 RID: 70880
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x040114E1 RID: 70881
		private static IntPtr __OnWeaponInteraction_NativeFunctionPtr;

		// Token: 0x040114E2 RID: 70882
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x040114E3 RID: 70883
		private static IntPtr __ExecuteUbergraph_BP_Cymbal_NativeFunctionPtr;

		// Token: 0x02009BA3 RID: 39843
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __Completed_F4DF745A4AA730C766F9CC8F60ED218B_FunctionParams
		{
			// Token: 0x040323D2 RID: 205778
			[FieldOffset(0)]
			public int PlayingID;
		}

		// Token: 0x02009BA4 RID: 39844
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x040323D3 RID: 205779
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009BA5 RID: 39845
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 40)]
		protected ref struct __OnWeaponInteraction_FunctionParams
		{
			// Token: 0x040323D4 RID: 205780
			[FieldOffset(0)]
			public FVectorDouble OriginPoint;

			// Token: 0x040323D5 RID: 205781
			[FieldOffset(24)]
			public IntPtr Config;

			// Token: 0x040323D6 RID: 205782
			[FieldOffset(32)]
			public int Id;
		}

		// Token: 0x02009BA6 RID: 39846
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 816)]
		protected ref struct __ExecuteUbergraph_BP_Cymbal_FunctionParams
		{
			// Token: 0x040323D7 RID: 205783
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
