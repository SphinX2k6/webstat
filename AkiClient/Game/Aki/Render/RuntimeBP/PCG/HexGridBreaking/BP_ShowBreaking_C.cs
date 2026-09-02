using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.HexGridBreaking
{
	// Token: 0x02003C12 RID: 15378
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/HexGridBreaking/BP_ShowBreaking.BP_ShowBreaking_C")]
	[UnrealStructLayout(1384, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1380)]
	public class BP_ShowBreaking_C : AKuroEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06022F8A RID: 143242 RVA: 0x00974B72 File Offset: 0x00972D72
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_ShowBreaking_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/HexGridBreaking/BP_ShowBreaking.BP_ShowBreaking_C");
			}
			return BP_ShowBreaking_C._ClassPtr;
		}

		// Token: 0x06022F8B RID: 143243 RVA: 0x00974B98 File Offset: 0x00972D98
		public BP_ShowBreaking_C() : this(BuiltinUtils.AllocNativeUObject(BP_ShowBreaking_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06022F8C RID: 143244 RVA: 0x00974BC0 File Offset: 0x00972DC0
		[NullableContext(1)]
		public BP_ShowBreaking_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_ShowBreaking_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170043B9 RID: 17337
		// (get) Token: 0x06022F8D RID: 143245 RVA: 0x00974BF4 File Offset: 0x00972DF4
		// (set) Token: 0x06022F8E RID: 143246 RVA: 0x00974C2D File Offset: 0x00972E2D
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_ShowBreaking_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_ShowBreaking_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170043BA RID: 17338
		// (get) Token: 0x06022F8F RID: 143247 RVA: 0x00974C4E File Offset: 0x00972E4E
		// (set) Token: 0x06022F90 RID: 143248 RVA: 0x00974C62 File Offset: 0x00972E62
		public unsafe UStaticMeshComponent SM_Sev_Flo_01GS
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_ShowBreaking_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_ShowBreaking_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170043BB RID: 17339
		// (get) Token: 0x06022F91 RID: 143249 RVA: 0x00974C77 File Offset: 0x00972E77
		// (set) Token: 0x06022F92 RID: 143250 RVA: 0x00974C8B File Offset: 0x00972E8B
		public unsafe UStaticMeshComponent SM_Sev_Flo_01FS
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_ShowBreaking_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_ShowBreaking_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x170043BC RID: 17340
		// (get) Token: 0x06022F93 RID: 143251 RVA: 0x00974CA0 File Offset: 0x00972EA0
		// (set) Token: 0x06022F94 RID: 143252 RVA: 0x00974CB4 File Offset: 0x00972EB4
		public unsafe UStaticMeshComponent SM_Sev_Flo_01ES
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_ShowBreaking_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_ShowBreaking_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x170043BD RID: 17341
		// (get) Token: 0x06022F95 RID: 143253 RVA: 0x00974CC9 File Offset: 0x00972EC9
		// (set) Token: 0x06022F96 RID: 143254 RVA: 0x00974CDD File Offset: 0x00972EDD
		public unsafe UStaticMeshComponent SM_Sev_Flo_01DS
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_ShowBreaking_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_ShowBreaking_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x170043BE RID: 17342
		// (get) Token: 0x06022F97 RID: 143255 RVA: 0x00974CF2 File Offset: 0x00972EF2
		// (set) Token: 0x06022F98 RID: 143256 RVA: 0x00974D06 File Offset: 0x00972F06
		public unsafe UStaticMeshComponent SM_Sev_Flo_01CS
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_ShowBreaking_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_ShowBreaking_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x170043BF RID: 17343
		// (get) Token: 0x06022F99 RID: 143257 RVA: 0x00974D1B File Offset: 0x00972F1B
		// (set) Token: 0x06022F9A RID: 143258 RVA: 0x00974D2F File Offset: 0x00972F2F
		public unsafe UStaticMeshComponent SM_Sev_Flo_01BS
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_ShowBreaking_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_ShowBreaking_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x170043C0 RID: 17344
		// (get) Token: 0x06022F9B RID: 143259 RVA: 0x00974D44 File Offset: 0x00972F44
		// (set) Token: 0x06022F9C RID: 143260 RVA: 0x00974D58 File Offset: 0x00972F58
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_ShowBreaking_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_ShowBreaking_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x170043C1 RID: 17345
		// (get) Token: 0x06022F9D RID: 143261 RVA: 0x00974D6D File Offset: 0x00972F6D
		// (set) Token: 0x06022F9E RID: 143262 RVA: 0x00974D7D File Offset: 0x00972F7D
		public unsafe float CustomTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ShowBreaking_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ShowBreaking_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x06022F9F RID: 143263 RVA: 0x00974D8E File Offset: 0x00972F8E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void SetCustomData()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ShowBreaking_C.__SetCustomData_NativeFunctionPtr, null);
		}

		// Token: 0x06022FA0 RID: 143264 RVA: 0x00974DA4 File Offset: 0x00972FA4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_ShowBreaking_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_ShowBreaking_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_ShowBreaking_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_ShowBreaking_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ShowBreaking_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06022FA1 RID: 143265 RVA: 0x00974DEC File Offset: 0x00972FEC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_ShowBreaking_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_ShowBreaking_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_ShowBreaking_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_ShowBreaking_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_ShowBreaking_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06022FA2 RID: 143266 RVA: 0x00974E34 File Offset: 0x00973034
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_ShowBreaking_C.__EditorTick_FunctionParams* ptr = stackalloc BP_ShowBreaking_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_ShowBreaking_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_ShowBreaking_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ShowBreaking_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06022FA3 RID: 143267 RVA: 0x00974E7C File Offset: 0x0097307C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_ShowBreaking_C.__EditorTick_FunctionParams* ptr = stackalloc BP_ShowBreaking_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_ShowBreaking_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_ShowBreaking_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_ShowBreaking_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06022FA4 RID: 143268 RVA: 0x00974EC4 File Offset: 0x009730C4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_ShowBreaking(int EntryPoint)
		{
			BP_ShowBreaking_C.__ExecuteUbergraph_BP_ShowBreaking_FunctionParams* ptr = stackalloc BP_ShowBreaking_C.__ExecuteUbergraph_BP_ShowBreaking_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(BP_ShowBreaking_C.__ExecuteUbergraph_BP_ShowBreaking_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_ShowBreaking_C.__ExecuteUbergraph_BP_ShowBreaking_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_ShowBreaking_C.__ExecuteUbergraph_BP_ShowBreaking_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06022FA5 RID: 143269 RVA: 0x00974F0B File Offset: 0x0097310B
		protected BP_ShowBreaking_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04011C43 RID: 72771
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/HexGridBreaking/BP_ShowBreaking.BP_ShowBreaking_C";

		// Token: 0x04011C44 RID: 72772
		private static IntPtr _ClassPtr;

		// Token: 0x04011C45 RID: 72773
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04011C46 RID: 72774
		internal static int __PropertyOffset_0;

		// Token: 0x04011C47 RID: 72775
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04011C48 RID: 72776
		internal static int __PropertyOffset_1;

		// Token: 0x04011C49 RID: 72777
		internal static int __PropertyOffset_2;

		// Token: 0x04011C4A RID: 72778
		internal static int __PropertyOffset_3;

		// Token: 0x04011C4B RID: 72779
		internal static int __PropertyOffset_4;

		// Token: 0x04011C4C RID: 72780
		internal static int __PropertyOffset_5;

		// Token: 0x04011C4D RID: 72781
		internal static int __PropertyOffset_6;

		// Token: 0x04011C4E RID: 72782
		internal static int __PropertyOffset_7;

		// Token: 0x04011C4F RID: 72783
		internal static int __PropertyOffset_8;

		// Token: 0x04011C50 RID: 72784
		private static IntPtr __SetCustomData_NativeFunctionPtr;

		// Token: 0x04011C51 RID: 72785
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04011C52 RID: 72786
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x04011C53 RID: 72787
		private static IntPtr __ExecuteUbergraph_BP_ShowBreaking_NativeFunctionPtr;

		// Token: 0x02009C64 RID: 40036
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032538 RID: 206136
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009C65 RID: 40037
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x04032539 RID: 206137
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009C66 RID: 40038
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __ExecuteUbergraph_BP_ShowBreaking_FunctionParams
		{
			// Token: 0x0403253A RID: 206138
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
