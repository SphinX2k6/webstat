using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Map.UISceneLevel.UI_Scene.UI_BP
{
	// Token: 0x02003DB2 RID: 15794
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Map/UISceneLevel/UI_Scene/UI_BP/BP_UIShowRoom.BP_UIShowRoom_C")]
	[UnrealStructLayout(1432, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1432)]
	public class BP_UIShowRoom_C : AKuroEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06026AC3 RID: 158403 RVA: 0x009DE990 File Offset: 0x009DCB90
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_UIShowRoom_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Map/UISceneLevel/UI_Scene/UI_BP/BP_UIShowRoom.BP_UIShowRoom_C");
			}
			return BP_UIShowRoom_C._ClassPtr;
		}

		// Token: 0x06026AC4 RID: 158404 RVA: 0x009DE9B4 File Offset: 0x009DCBB4
		public BP_UIShowRoom_C() : this(BuiltinUtils.AllocNativeUObject(BP_UIShowRoom_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06026AC5 RID: 158405 RVA: 0x009DE9DC File Offset: 0x009DCBDC
		[NullableContext(1)]
		public BP_UIShowRoom_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_UIShowRoom_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700589E RID: 22686
		// (get) Token: 0x06026AC6 RID: 158406 RVA: 0x009DEA10 File Offset: 0x009DCC10
		// (set) Token: 0x06026AC7 RID: 158407 RVA: 0x009DEA49 File Offset: 0x009DCC49
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_UIShowRoom_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_UIShowRoom_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700589F RID: 22687
		// (get) Token: 0x06026AC8 RID: 158408 RVA: 0x009DEA6A File Offset: 0x009DCC6A
		// (set) Token: 0x06026AC9 RID: 158409 RVA: 0x009DEA7E File Offset: 0x009DCC7E
		public unsafe UStaticMeshComponent SM_MilkyWay
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_UIShowRoom_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_UIShowRoom_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170058A0 RID: 22688
		// (get) Token: 0x06026ACA RID: 158410 RVA: 0x009DEA93 File Offset: 0x009DCC93
		// (set) Token: 0x06026ACB RID: 158411 RVA: 0x009DEAA7 File Offset: 0x009DCCA7
		public unsafe UStaticMeshComponent SkyMesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_UIShowRoom_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_UIShowRoom_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x170058A1 RID: 22689
		// (get) Token: 0x06026ACC RID: 158412 RVA: 0x009DEABC File Offset: 0x009DCCBC
		// (set) Token: 0x06026ACD RID: 158413 RVA: 0x009DEAD0 File Offset: 0x009DCCD0
		public unsafe UPlanarReflectionComponent PlanarReflection
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UPlanarReflectionComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_UIShowRoom_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_UIShowRoom_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x170058A2 RID: 22690
		// (get) Token: 0x06026ACE RID: 158414 RVA: 0x009DEAE5 File Offset: 0x009DCCE5
		// (set) Token: 0x06026ACF RID: 158415 RVA: 0x009DEAF9 File Offset: 0x009DCCF9
		public unsafe UStaticMeshComponent FloorMesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_UIShowRoom_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_UIShowRoom_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x170058A3 RID: 22691
		// (get) Token: 0x06026AD0 RID: 158416 RVA: 0x009DEB0E File Offset: 0x009DCD0E
		// (set) Token: 0x06026AD1 RID: 158417 RVA: 0x009DEB22 File Offset: 0x009DCD22
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_UIShowRoom_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_UIShowRoom_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x170058A4 RID: 22692
		// (get) Token: 0x06026AD2 RID: 158418 RVA: 0x009DEB37 File Offset: 0x009DCD37
		// (set) Token: 0x06026AD3 RID: 158419 RVA: 0x009DEB4B File Offset: 0x009DCD4B
		public unsafe UMaterialInterface MilkyWayMaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInterface>(base.NativePtr / (IntPtr)sizeof(void*) + BP_UIShowRoom_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_UIShowRoom_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x170058A5 RID: 22693
		// (get) Token: 0x06026AD4 RID: 158420 RVA: 0x009DEB60 File Offset: 0x009DCD60
		// (set) Token: 0x06026AD5 RID: 158421 RVA: 0x009DEB74 File Offset: 0x009DCD74
		public unsafe FRotator MilkyWayRotation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_UIShowRoom_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_UIShowRoom_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x170058A6 RID: 22694
		// (get) Token: 0x06026AD6 RID: 158422 RVA: 0x009DEB89 File Offset: 0x009DCD89
		// (set) Token: 0x06026AD7 RID: 158423 RVA: 0x009DEB9D File Offset: 0x009DCD9D
		public unsafe UMaterialInterface SkyMaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInterface>(base.NativePtr / (IntPtr)sizeof(void*) + BP_UIShowRoom_C.__PropertyOffset_8);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_UIShowRoom_C.__PropertyOffset_8, value);
			}
		}

		// Token: 0x170058A7 RID: 22695
		// (get) Token: 0x06026AD8 RID: 158424 RVA: 0x009DEBB2 File Offset: 0x009DCDB2
		// (set) Token: 0x06026AD9 RID: 158425 RVA: 0x009DEBC6 File Offset: 0x009DCDC6
		public unsafe UMaterialInterface FloorMaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInterface>(base.NativePtr / (IntPtr)sizeof(void*) + BP_UIShowRoom_C.__PropertyOffset_9);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_UIShowRoom_C.__PropertyOffset_9, value);
			}
		}

		// Token: 0x170058A8 RID: 22696
		// (get) Token: 0x06026ADA RID: 158426 RVA: 0x009DEBDB File Offset: 0x009DCDDB
		// (set) Token: 0x06026ADB RID: 158427 RVA: 0x009DEBEF File Offset: 0x009DCDEF
		public unsafe UMaterialInstanceDynamic SkyMID
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_UIShowRoom_C.__PropertyOffset_10);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_UIShowRoom_C.__PropertyOffset_10, value);
			}
		}

		// Token: 0x170058A9 RID: 22697
		// (get) Token: 0x06026ADC RID: 158428 RVA: 0x009DEC04 File Offset: 0x009DCE04
		// (set) Token: 0x06026ADD RID: 158429 RVA: 0x009DEC14 File Offset: 0x009DCE14
		public unsafe bool bShowMilkyWay
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_UIShowRoom_C.__PropertyOffset_11) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_UIShowRoom_C.__PropertyOffset_11) = (value ? 1 : 0);
			}
		}

		// Token: 0x170058AA RID: 22698
		// (get) Token: 0x06026ADE RID: 158430 RVA: 0x009DEC25 File Offset: 0x009DCE25
		// (set) Token: 0x06026ADF RID: 158431 RVA: 0x009DEC35 File Offset: 0x009DCE35
		public unsafe bool bShowSky
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_UIShowRoom_C.__PropertyOffset_12) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_UIShowRoom_C.__PropertyOffset_12) = (value ? 1 : 0);
			}
		}

		// Token: 0x170058AB RID: 22699
		// (get) Token: 0x06026AE0 RID: 158432 RVA: 0x009DEC46 File Offset: 0x009DCE46
		// (set) Token: 0x06026AE1 RID: 158433 RVA: 0x009DEC56 File Offset: 0x009DCE56
		public unsafe bool bShowFloor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_UIShowRoom_C.__PropertyOffset_13) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_UIShowRoom_C.__PropertyOffset_13) = (value ? 1 : 0);
			}
		}

		// Token: 0x170058AC RID: 22700
		// (get) Token: 0x06026AE2 RID: 158434 RVA: 0x009DEC68 File Offset: 0x009DCE68
		// (set) Token: 0x06026AE3 RID: 158435 RVA: 0x009DECA1 File Offset: 0x009DCEA1
		[Nullable(1)]
		public TArray<AActor> ShowActors
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<AActor> result;
				if ((result = this._ShowActors) == null)
				{
					result = (this._ShowActors = new TArray<AActor>(base.NativePtr + (IntPtr)BP_UIShowRoom_C.__PropertyOffset_14, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.ShowActors.CopyAssign(value);
			}
		}

		// Token: 0x06026AE4 RID: 158436 RVA: 0x009DECB0 File Offset: 0x009DCEB0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void RemoveShowActor(ref AActor Actor, bool IncludefromChildActors)
		{
			BP_UIShowRoom_C.__RemoveShowActor_FunctionParams* ptr = stackalloc BP_UIShowRoom_C.__RemoveShowActor_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(BP_UIShowRoom_C.__RemoveShowActor_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_UIShowRoom_C.__RemoveShowActor_NativeFunctionPtr, (void*)ptr, 1);
			ref BP_UIShowRoom_C.__RemoveShowActor_FunctionParams ptr2 = ref *ptr;
			AActor aactor = Actor;
			ptr2.Actor = ((aactor != null) ? aactor.NativePtr : IntPtr.Zero);
			ptr->IncludefromChildActors = IncludefromChildActors;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_UIShowRoom_C.__RemoveShowActor_NativeFunctionPtr, (void*)ptr);
			Actor = BuiltinUtils.GetOrCreateUObjectByNativePointer<AActor>(ptr->Actor);
		}

		// Token: 0x06026AE5 RID: 158437 RVA: 0x009DED1C File Offset: 0x009DCF1C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void AddShowActor(ref AActor Actor, bool IncludefromChildActors)
		{
			BP_UIShowRoom_C.__AddShowActor_FunctionParams* ptr = stackalloc BP_UIShowRoom_C.__AddShowActor_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(BP_UIShowRoom_C.__AddShowActor_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_UIShowRoom_C.__AddShowActor_NativeFunctionPtr, (void*)ptr, 1);
			ref BP_UIShowRoom_C.__AddShowActor_FunctionParams ptr2 = ref *ptr;
			AActor aactor = Actor;
			ptr2.Actor = ((aactor != null) ? aactor.NativePtr : IntPtr.Zero);
			ptr->IncludefromChildActors = IncludefromChildActors;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_UIShowRoom_C.__AddShowActor_NativeFunctionPtr, (void*)ptr);
			Actor = BuiltinUtils.GetOrCreateUObjectByNativePointer<AActor>(ptr->Actor);
		}

		// Token: 0x06026AE6 RID: 158438 RVA: 0x009DED87 File Offset: 0x009DCF87
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_UIShowRoom_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06026AE7 RID: 158439 RVA: 0x009DED9B File Offset: 0x009DCF9B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_UIShowRoom_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06026AE8 RID: 158440 RVA: 0x009DEDB0 File Offset: 0x009DCFB0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_UIShowRoom_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_UIShowRoom_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_UIShowRoom_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_UIShowRoom_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_UIShowRoom_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06026AE9 RID: 158441 RVA: 0x009DEDF8 File Offset: 0x009DCFF8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_UIShowRoom_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_UIShowRoom_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_UIShowRoom_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_UIShowRoom_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_UIShowRoom_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06026AEA RID: 158442 RVA: 0x009DEE40 File Offset: 0x009DD040
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_UIShowRoom_C.__EditorTick_FunctionParams* ptr = stackalloc BP_UIShowRoom_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_UIShowRoom_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_UIShowRoom_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_UIShowRoom_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06026AEB RID: 158443 RVA: 0x009DEE88 File Offset: 0x009DD088
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_UIShowRoom_C.__EditorTick_FunctionParams* ptr = stackalloc BP_UIShowRoom_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_UIShowRoom_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_UIShowRoom_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_UIShowRoom_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06026AEC RID: 158444 RVA: 0x009DEED0 File Offset: 0x009DD0D0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_UIShowRoom(int EntryPoint)
		{
			BP_UIShowRoom_C.__ExecuteUbergraph_BP_UIShowRoom_FunctionParams* ptr = stackalloc BP_UIShowRoom_C.__ExecuteUbergraph_BP_UIShowRoom_FunctionParams[(UIntPtr)95] + 15L / (long)sizeof(BP_UIShowRoom_C.__ExecuteUbergraph_BP_UIShowRoom_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_UIShowRoom_C.__ExecuteUbergraph_BP_UIShowRoom_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_UIShowRoom_C.__ExecuteUbergraph_BP_UIShowRoom_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06026AED RID: 158445 RVA: 0x009DEF17 File Offset: 0x009DD117
		protected BP_UIShowRoom_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04014277 RID: 82551
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Map/UISceneLevel/UI_Scene/UI_BP/BP_UIShowRoom.BP_UIShowRoom_C";

		// Token: 0x04014278 RID: 82552
		private static IntPtr _ClassPtr;

		// Token: 0x04014279 RID: 82553
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401427A RID: 82554
		internal static int __PropertyOffset_0;

		// Token: 0x0401427B RID: 82555
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0401427C RID: 82556
		internal static int __PropertyOffset_1;

		// Token: 0x0401427D RID: 82557
		internal static int __PropertyOffset_2;

		// Token: 0x0401427E RID: 82558
		internal static int __PropertyOffset_3;

		// Token: 0x0401427F RID: 82559
		internal static int __PropertyOffset_4;

		// Token: 0x04014280 RID: 82560
		internal static int __PropertyOffset_5;

		// Token: 0x04014281 RID: 82561
		internal static int __PropertyOffset_6;

		// Token: 0x04014282 RID: 82562
		internal static int __PropertyOffset_7;

		// Token: 0x04014283 RID: 82563
		internal static int __PropertyOffset_8;

		// Token: 0x04014284 RID: 82564
		internal static int __PropertyOffset_9;

		// Token: 0x04014285 RID: 82565
		internal static int __PropertyOffset_10;

		// Token: 0x04014286 RID: 82566
		internal static int __PropertyOffset_11;

		// Token: 0x04014287 RID: 82567
		internal static int __PropertyOffset_12;

		// Token: 0x04014288 RID: 82568
		internal static int __PropertyOffset_13;

		// Token: 0x04014289 RID: 82569
		internal static int __PropertyOffset_14;

		// Token: 0x0401428A RID: 82570
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<AActor> _ShowActors;

		// Token: 0x0401428B RID: 82571
		private static IntPtr __RemoveShowActor_NativeFunctionPtr;

		// Token: 0x0401428C RID: 82572
		private static IntPtr __AddShowActor_NativeFunctionPtr;

		// Token: 0x0401428D RID: 82573
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x0401428E RID: 82574
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0401428F RID: 82575
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x04014290 RID: 82576
		private static IntPtr __ExecuteUbergraph_BP_UIShowRoom_NativeFunctionPtr;

		// Token: 0x0200A097 RID: 41111
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __RemoveShowActor_FunctionParams
		{
			// Token: 0x04032D38 RID: 208184
			[FieldOffset(0)]
			public IntPtr Actor;

			// Token: 0x04032D39 RID: 208185
			[FieldOffset(8)]
			public bool IncludefromChildActors;
		}

		// Token: 0x0200A098 RID: 41112
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __AddShowActor_FunctionParams
		{
			// Token: 0x04032D3A RID: 208186
			[FieldOffset(0)]
			public IntPtr Actor;

			// Token: 0x04032D3B RID: 208187
			[FieldOffset(8)]
			public bool IncludefromChildActors;
		}

		// Token: 0x0200A099 RID: 41113
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032D3C RID: 208188
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x0200A09A RID: 41114
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x04032D3D RID: 208189
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x0200A09B RID: 41115
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 80)]
		protected ref struct __ExecuteUbergraph_BP_UIShowRoom_FunctionParams
		{
			// Token: 0x04032D3E RID: 208190
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
