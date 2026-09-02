using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Light
{
	// Token: 0x02003A77 RID: 14967
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Light/BP_CharacterPostOutline.BP_CharacterPostOutline_C")]
	[UnrealStructLayout(1624, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1624)]
	public class BP_CharacterPostOutline_C : AKuroEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601F38F RID: 127887 RVA: 0x0090C017 File Offset: 0x0090A217
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_CharacterPostOutline_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/Light/BP_CharacterPostOutline.BP_CharacterPostOutline_C");
			}
			return BP_CharacterPostOutline_C._ClassPtr;
		}

		// Token: 0x0601F390 RID: 127888 RVA: 0x0090C03C File Offset: 0x0090A23C
		public BP_CharacterPostOutline_C() : this(BuiltinUtils.AllocNativeUObject(BP_CharacterPostOutline_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601F391 RID: 127889 RVA: 0x0090C064 File Offset: 0x0090A264
		[NullableContext(1)]
		public BP_CharacterPostOutline_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_CharacterPostOutline_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17002E9E RID: 11934
		// (get) Token: 0x0601F392 RID: 127890 RVA: 0x0090C098 File Offset: 0x0090A298
		// (set) Token: 0x0601F393 RID: 127891 RVA: 0x0090C0D1 File Offset: 0x0090A2D1
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_CharacterPostOutline_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_CharacterPostOutline_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17002E9F RID: 11935
		// (get) Token: 0x0601F394 RID: 127892 RVA: 0x0090C0F2 File Offset: 0x0090A2F2
		// (set) Token: 0x0601F395 RID: 127893 RVA: 0x0090C106 File Offset: 0x0090A306
		public unsafe UKuroPostProcessComponent KuroPostProcess
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroPostProcessComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CharacterPostOutline_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CharacterPostOutline_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17002EA0 RID: 11936
		// (get) Token: 0x0601F396 RID: 127894 RVA: 0x0090C11B File Offset: 0x0090A31B
		// (set) Token: 0x0601F397 RID: 127895 RVA: 0x0090C12F File Offset: 0x0090A32F
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CharacterPostOutline_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CharacterPostOutline_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17002EA1 RID: 11937
		// (get) Token: 0x0601F398 RID: 127896 RVA: 0x0090C144 File Offset: 0x0090A344
		// (set) Token: 0x0601F399 RID: 127897 RVA: 0x0090C158 File Offset: 0x0090A358
		public unsafe UMaterialInstanceDynamic DynamicMaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CharacterPostOutline_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CharacterPostOutline_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17002EA2 RID: 11938
		// (get) Token: 0x0601F39A RID: 127898 RVA: 0x0090C170 File Offset: 0x0090A370
		// (set) Token: 0x0601F39B RID: 127899 RVA: 0x0090C1A9 File Offset: 0x0090A3A9
		[Nullable(1)]
		public TMap<FName, float> Scalar_Parameters
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TMap<FName, float> result;
				if ((result = this._Scalar_Parameters) == null)
				{
					result = (this._Scalar_Parameters = new TMap<FName, float>(base.NativePtr + (IntPtr)BP_CharacterPostOutline_C.__PropertyOffset_4, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.Scalar_Parameters.CopyAssign(value);
			}
		}

		// Token: 0x17002EA3 RID: 11939
		// (get) Token: 0x0601F39C RID: 127900 RVA: 0x0090C1B8 File Offset: 0x0090A3B8
		// (set) Token: 0x0601F39D RID: 127901 RVA: 0x0090C1F1 File Offset: 0x0090A3F1
		[Nullable(1)]
		public TMap<FName, FLinearColor> Vector_Parameters
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TMap<FName, FLinearColor> result;
				if ((result = this._Vector_Parameters) == null)
				{
					result = (this._Vector_Parameters = new TMap<FName, FLinearColor>(base.NativePtr + (IntPtr)BP_CharacterPostOutline_C.__PropertyOffset_5, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.Vector_Parameters.CopyAssign(value);
			}
		}

		// Token: 0x17002EA4 RID: 11940
		// (get) Token: 0x0601F39E RID: 127902 RVA: 0x0090C200 File Offset: 0x0090A400
		// (set) Token: 0x0601F39F RID: 127903 RVA: 0x0090C239 File Offset: 0x0090A439
		[Nullable(1)]
		public TMap<FName, UTexture> Texture_Parameters
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TMap<FName, UTexture> result;
				if ((result = this._Texture_Parameters) == null)
				{
					result = (this._Texture_Parameters = new TMap<FName, UTexture>(base.NativePtr + (IntPtr)BP_CharacterPostOutline_C.__PropertyOffset_6, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.Texture_Parameters.CopyAssign(value);
			}
		}

		// Token: 0x17002EA5 RID: 11941
		// (get) Token: 0x0601F3A0 RID: 127904 RVA: 0x0090C247 File Offset: 0x0090A447
		// (set) Token: 0x0601F3A1 RID: 127905 RVA: 0x0090C25B File Offset: 0x0090A45B
		public unsafe UMaterialInstance Material
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CharacterPostOutline_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CharacterPostOutline_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x17002EA6 RID: 11942
		// (get) Token: 0x0601F3A2 RID: 127906 RVA: 0x0090C270 File Offset: 0x0090A470
		// (set) Token: 0x0601F3A3 RID: 127907 RVA: 0x0090C280 File Offset: 0x0090A480
		public unsafe float Size
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CharacterPostOutline_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CharacterPostOutline_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17002EA7 RID: 11943
		// (get) Token: 0x0601F3A4 RID: 127908 RVA: 0x0090C291 File Offset: 0x0090A491
		// (set) Token: 0x0601F3A5 RID: 127909 RVA: 0x0090C2A5 File Offset: 0x0090A4A5
		public unsafe FLinearColor Color
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CharacterPostOutline_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CharacterPostOutline_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17002EA8 RID: 11944
		// (get) Token: 0x0601F3A6 RID: 127910 RVA: 0x0090C2BA File Offset: 0x0090A4BA
		// (set) Token: 0x0601F3A7 RID: 127911 RVA: 0x0090C2CE File Offset: 0x0090A4CE
		public unsafe UTexture2D Tex
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CharacterPostOutline_C.__PropertyOffset_10);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CharacterPostOutline_C.__PropertyOffset_10, value);
			}
		}

		// Token: 0x0601F3A8 RID: 127912 RVA: 0x0090C2E3 File Offset: 0x0090A4E3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void SetParameter()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CharacterPostOutline_C.__SetParameter_NativeFunctionPtr, null);
		}

		// Token: 0x0601F3A9 RID: 127913 RVA: 0x0090C2F7 File Offset: 0x0090A4F7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CharacterPostOutline_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x0601F3AA RID: 127914 RVA: 0x0090C30B File Offset: 0x0090A50B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_CharacterPostOutline_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601F3AB RID: 127915 RVA: 0x0090C320 File Offset: 0x0090A520
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CharacterPostOutline_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0601F3AC RID: 127916 RVA: 0x0090C334 File Offset: 0x0090A534
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_CharacterPostOutline_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601F3AD RID: 127917 RVA: 0x0090C34C File Offset: 0x0090A54C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_CharacterPostOutline_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_CharacterPostOutline_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_CharacterPostOutline_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CharacterPostOutline_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CharacterPostOutline_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F3AE RID: 127918 RVA: 0x0090C394 File Offset: 0x0090A594
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_CharacterPostOutline_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_CharacterPostOutline_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_CharacterPostOutline_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CharacterPostOutline_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_CharacterPostOutline_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601F3AF RID: 127919 RVA: 0x0090C3DB File Offset: 0x0090A5DB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveDestroyed()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CharacterPostOutline_C.__ReceiveDestroyed_NativeFunctionPtr, null);
		}

		// Token: 0x0601F3B0 RID: 127920 RVA: 0x0090C3EF File Offset: 0x0090A5EF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveDestroyed_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_CharacterPostOutline_C.__ReceiveDestroyed_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601F3B1 RID: 127921 RVA: 0x0090C404 File Offset: 0x0090A604
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_CharacterPostOutline_C.__EditorTick_FunctionParams* ptr = stackalloc BP_CharacterPostOutline_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_CharacterPostOutline_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CharacterPostOutline_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CharacterPostOutline_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F3B2 RID: 127922 RVA: 0x0090C44C File Offset: 0x0090A64C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_CharacterPostOutline_C.__EditorTick_FunctionParams* ptr = stackalloc BP_CharacterPostOutline_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_CharacterPostOutline_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CharacterPostOutline_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_CharacterPostOutline_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601F3B3 RID: 127923 RVA: 0x0090C494 File Offset: 0x0090A694
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_CharacterPostOutline(int EntryPoint)
		{
			BP_CharacterPostOutline_C.__ExecuteUbergraph_BP_CharacterPostOutline_FunctionParams* ptr = stackalloc BP_CharacterPostOutline_C.__ExecuteUbergraph_BP_CharacterPostOutline_FunctionParams[(UIntPtr)95] + 15L / (long)sizeof(BP_CharacterPostOutline_C.__ExecuteUbergraph_BP_CharacterPostOutline_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CharacterPostOutline_C.__ExecuteUbergraph_BP_CharacterPostOutline_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_CharacterPostOutline_C.__ExecuteUbergraph_BP_CharacterPostOutline_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601F3B4 RID: 127924 RVA: 0x0090C4DB File Offset: 0x0090A6DB
		protected BP_CharacterPostOutline_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400F7C8 RID: 63432
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Light/BP_CharacterPostOutline.BP_CharacterPostOutline_C";

		// Token: 0x0400F7C9 RID: 63433
		private static IntPtr _ClassPtr;

		// Token: 0x0400F7CA RID: 63434
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400F7CB RID: 63435
		internal static int __PropertyOffset_0;

		// Token: 0x0400F7CC RID: 63436
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400F7CD RID: 63437
		internal static int __PropertyOffset_1;

		// Token: 0x0400F7CE RID: 63438
		internal static int __PropertyOffset_2;

		// Token: 0x0400F7CF RID: 63439
		internal static int __PropertyOffset_3;

		// Token: 0x0400F7D0 RID: 63440
		internal static int __PropertyOffset_4;

		// Token: 0x0400F7D1 RID: 63441
		private TMap<FName, float> _Scalar_Parameters;

		// Token: 0x0400F7D2 RID: 63442
		internal static int __PropertyOffset_5;

		// Token: 0x0400F7D3 RID: 63443
		private TMap<FName, FLinearColor> _Vector_Parameters;

		// Token: 0x0400F7D4 RID: 63444
		internal static int __PropertyOffset_6;

		// Token: 0x0400F7D5 RID: 63445
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<FName, UTexture> _Texture_Parameters;

		// Token: 0x0400F7D6 RID: 63446
		internal static int __PropertyOffset_7;

		// Token: 0x0400F7D7 RID: 63447
		internal static int __PropertyOffset_8;

		// Token: 0x0400F7D8 RID: 63448
		internal static int __PropertyOffset_9;

		// Token: 0x0400F7D9 RID: 63449
		internal static int __PropertyOffset_10;

		// Token: 0x0400F7DA RID: 63450
		private static IntPtr __SetParameter_NativeFunctionPtr;

		// Token: 0x0400F7DB RID: 63451
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x0400F7DC RID: 63452
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0400F7DD RID: 63453
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0400F7DE RID: 63454
		private static IntPtr __ReceiveDestroyed_NativeFunctionPtr;

		// Token: 0x0400F7DF RID: 63455
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x0400F7E0 RID: 63456
		private static IntPtr __ExecuteUbergraph_BP_CharacterPostOutline_NativeFunctionPtr;

		// Token: 0x020098B0 RID: 39088
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04031F01 RID: 204545
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x020098B1 RID: 39089
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x04031F02 RID: 204546
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x020098B2 RID: 39090
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 80)]
		protected ref struct __ExecuteUbergraph_BP_CharacterPostOutline_FunctionParams
		{
			// Token: 0x04031F03 RID: 204547
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
