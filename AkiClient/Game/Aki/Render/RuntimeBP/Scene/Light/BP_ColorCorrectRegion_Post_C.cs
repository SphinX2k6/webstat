using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Light
{
	// Token: 0x02003A79 RID: 14969
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Light/BP_ColorCorrectRegion_Post.BP_ColorCorrectRegion_Post_C")]
	[UnrealStructLayout(1640, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1640)]
	public class BP_ColorCorrectRegion_Post_C : AKuroEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601F3F3 RID: 127987 RVA: 0x0090CB4B File Offset: 0x0090AD4B
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_ColorCorrectRegion_Post_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/Light/BP_ColorCorrectRegion_Post.BP_ColorCorrectRegion_Post_C");
			}
			return BP_ColorCorrectRegion_Post_C._ClassPtr;
		}

		// Token: 0x0601F3F4 RID: 127988 RVA: 0x0090CB70 File Offset: 0x0090AD70
		public BP_ColorCorrectRegion_Post_C() : this(BuiltinUtils.AllocNativeUObject(BP_ColorCorrectRegion_Post_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601F3F5 RID: 127989 RVA: 0x0090CB98 File Offset: 0x0090AD98
		[NullableContext(1)]
		public BP_ColorCorrectRegion_Post_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_ColorCorrectRegion_Post_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17002EC0 RID: 11968
		// (get) Token: 0x0601F3F6 RID: 127990 RVA: 0x0090CBCC File Offset: 0x0090ADCC
		// (set) Token: 0x0601F3F7 RID: 127991 RVA: 0x0090CC05 File Offset: 0x0090AE05
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_ColorCorrectRegion_Post_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_ColorCorrectRegion_Post_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17002EC1 RID: 11969
		// (get) Token: 0x0601F3F8 RID: 127992 RVA: 0x0090CC26 File Offset: 0x0090AE26
		// (set) Token: 0x0601F3F9 RID: 127993 RVA: 0x0090CC3A File Offset: 0x0090AE3A
		public unsafe UKuroPostProcessComponent KuroPostProcess
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroPostProcessComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_ColorCorrectRegion_Post_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_ColorCorrectRegion_Post_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17002EC2 RID: 11970
		// (get) Token: 0x0601F3FA RID: 127994 RVA: 0x0090CC4F File Offset: 0x0090AE4F
		// (set) Token: 0x0601F3FB RID: 127995 RVA: 0x0090CC63 File Offset: 0x0090AE63
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_ColorCorrectRegion_Post_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_ColorCorrectRegion_Post_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17002EC3 RID: 11971
		// (get) Token: 0x0601F3FC RID: 127996 RVA: 0x0090CC78 File Offset: 0x0090AE78
		// (set) Token: 0x0601F3FD RID: 127997 RVA: 0x0090CC8C File Offset: 0x0090AE8C
		public unsafe UMaterialInstanceDynamic DynamicMaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_ColorCorrectRegion_Post_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_ColorCorrectRegion_Post_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17002EC4 RID: 11972
		// (get) Token: 0x0601F3FE RID: 127998 RVA: 0x0090CCA4 File Offset: 0x0090AEA4
		// (set) Token: 0x0601F3FF RID: 127999 RVA: 0x0090CCDD File Offset: 0x0090AEDD
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
					result = (this._Scalar_Parameters = new TMap<FName, float>(base.NativePtr + (IntPtr)BP_ColorCorrectRegion_Post_C.__PropertyOffset_4, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.Scalar_Parameters.CopyAssign(value);
			}
		}

		// Token: 0x17002EC5 RID: 11973
		// (get) Token: 0x0601F400 RID: 128000 RVA: 0x0090CCEC File Offset: 0x0090AEEC
		// (set) Token: 0x0601F401 RID: 128001 RVA: 0x0090CD25 File Offset: 0x0090AF25
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
					result = (this._Vector_Parameters = new TMap<FName, FLinearColor>(base.NativePtr + (IntPtr)BP_ColorCorrectRegion_Post_C.__PropertyOffset_5, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.Vector_Parameters.CopyAssign(value);
			}
		}

		// Token: 0x17002EC6 RID: 11974
		// (get) Token: 0x0601F402 RID: 128002 RVA: 0x0090CD34 File Offset: 0x0090AF34
		// (set) Token: 0x0601F403 RID: 128003 RVA: 0x0090CD6D File Offset: 0x0090AF6D
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
					result = (this._Texture_Parameters = new TMap<FName, UTexture>(base.NativePtr + (IntPtr)BP_ColorCorrectRegion_Post_C.__PropertyOffset_6, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.Texture_Parameters.CopyAssign(value);
			}
		}

		// Token: 0x17002EC7 RID: 11975
		// (get) Token: 0x0601F404 RID: 128004 RVA: 0x0090CD7B File Offset: 0x0090AF7B
		// (set) Token: 0x0601F405 RID: 128005 RVA: 0x0090CD8B File Offset: 0x0090AF8B
		public unsafe float Intensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ColorCorrectRegion_Post_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ColorCorrectRegion_Post_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17002EC8 RID: 11976
		// (get) Token: 0x0601F406 RID: 128006 RVA: 0x0090CD9C File Offset: 0x0090AF9C
		// (set) Token: 0x0601F407 RID: 128007 RVA: 0x0090CDB0 File Offset: 0x0090AFB0
		public unsafe UMaterialInstance Material
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_ColorCorrectRegion_Post_C.__PropertyOffset_8);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_ColorCorrectRegion_Post_C.__PropertyOffset_8, value);
			}
		}

		// Token: 0x17002EC9 RID: 11977
		// (get) Token: 0x0601F408 RID: 128008 RVA: 0x0090CDC5 File Offset: 0x0090AFC5
		// (set) Token: 0x0601F409 RID: 128009 RVA: 0x0090CDD5 File Offset: 0x0090AFD5
		public unsafe float Radius
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ColorCorrectRegion_Post_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ColorCorrectRegion_Post_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17002ECA RID: 11978
		// (get) Token: 0x0601F40A RID: 128010 RVA: 0x0090CDE6 File Offset: 0x0090AFE6
		// (set) Token: 0x0601F40B RID: 128011 RVA: 0x0090CDF6 File Offset: 0x0090AFF6
		public unsafe float Falloff
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ColorCorrectRegion_Post_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ColorCorrectRegion_Post_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17002ECB RID: 11979
		// (get) Token: 0x0601F40C RID: 128012 RVA: 0x0090CE07 File Offset: 0x0090B007
		// (set) Token: 0x0601F40D RID: 128013 RVA: 0x0090CE1B File Offset: 0x0090B01B
		public unsafe FLinearColor Color
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ColorCorrectRegion_Post_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ColorCorrectRegion_Post_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17002ECC RID: 11980
		// (get) Token: 0x0601F40E RID: 128014 RVA: 0x0090CE30 File Offset: 0x0090B030
		// (set) Token: 0x0601F40F RID: 128015 RVA: 0x0090CE40 File Offset: 0x0090B040
		public unsafe float Temperature
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ColorCorrectRegion_Post_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ColorCorrectRegion_Post_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17002ECD RID: 11981
		// (get) Token: 0x0601F410 RID: 128016 RVA: 0x0090CE51 File Offset: 0x0090B051
		// (set) Token: 0x0601F411 RID: 128017 RVA: 0x0090CE61 File Offset: 0x0090B061
		public unsafe float Saturation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ColorCorrectRegion_Post_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ColorCorrectRegion_Post_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x17002ECE RID: 11982
		// (get) Token: 0x0601F412 RID: 128018 RVA: 0x0090CE72 File Offset: 0x0090B072
		// (set) Token: 0x0601F413 RID: 128019 RVA: 0x0090CE82 File Offset: 0x0090B082
		public unsafe float Contrast
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ColorCorrectRegion_Post_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ColorCorrectRegion_Post_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x17002ECF RID: 11983
		// (get) Token: 0x0601F414 RID: 128020 RVA: 0x0090CE93 File Offset: 0x0090B093
		// (set) Token: 0x0601F415 RID: 128021 RVA: 0x0090CEA3 File Offset: 0x0090B0A3
		public unsafe float Hue
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ColorCorrectRegion_Post_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ColorCorrectRegion_Post_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x0601F416 RID: 128022 RVA: 0x0090CEB4 File Offset: 0x0090B0B4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void SetParameter()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ColorCorrectRegion_Post_C.__SetParameter_NativeFunctionPtr, null);
		}

		// Token: 0x0601F417 RID: 128023 RVA: 0x0090CEC8 File Offset: 0x0090B0C8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ColorCorrectRegion_Post_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x0601F418 RID: 128024 RVA: 0x0090CEDC File Offset: 0x0090B0DC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_ColorCorrectRegion_Post_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601F419 RID: 128025 RVA: 0x0090CEF1 File Offset: 0x0090B0F1
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ColorCorrectRegion_Post_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0601F41A RID: 128026 RVA: 0x0090CF05 File Offset: 0x0090B105
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_ColorCorrectRegion_Post_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601F41B RID: 128027 RVA: 0x0090CF1C File Offset: 0x0090B11C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_ColorCorrectRegion_Post_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_ColorCorrectRegion_Post_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_ColorCorrectRegion_Post_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_ColorCorrectRegion_Post_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ColorCorrectRegion_Post_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F41C RID: 128028 RVA: 0x0090CF64 File Offset: 0x0090B164
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_ColorCorrectRegion_Post_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_ColorCorrectRegion_Post_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_ColorCorrectRegion_Post_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_ColorCorrectRegion_Post_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_ColorCorrectRegion_Post_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601F41D RID: 128029 RVA: 0x0090CFAB File Offset: 0x0090B1AB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveDestroyed()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ColorCorrectRegion_Post_C.__ReceiveDestroyed_NativeFunctionPtr, null);
		}

		// Token: 0x0601F41E RID: 128030 RVA: 0x0090CFBF File Offset: 0x0090B1BF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveDestroyed_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_ColorCorrectRegion_Post_C.__ReceiveDestroyed_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601F41F RID: 128031 RVA: 0x0090CFD4 File Offset: 0x0090B1D4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_ColorCorrectRegion_Post_C.__EditorTick_FunctionParams* ptr = stackalloc BP_ColorCorrectRegion_Post_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_ColorCorrectRegion_Post_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_ColorCorrectRegion_Post_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ColorCorrectRegion_Post_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F420 RID: 128032 RVA: 0x0090D01C File Offset: 0x0090B21C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_ColorCorrectRegion_Post_C.__EditorTick_FunctionParams* ptr = stackalloc BP_ColorCorrectRegion_Post_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_ColorCorrectRegion_Post_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_ColorCorrectRegion_Post_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_ColorCorrectRegion_Post_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601F421 RID: 128033 RVA: 0x0090D064 File Offset: 0x0090B264
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_ColorCorrectRegion_Post(int EntryPoint)
		{
			BP_ColorCorrectRegion_Post_C.__ExecuteUbergraph_BP_ColorCorrectRegion_Post_FunctionParams* ptr = stackalloc BP_ColorCorrectRegion_Post_C.__ExecuteUbergraph_BP_ColorCorrectRegion_Post_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(BP_ColorCorrectRegion_Post_C.__ExecuteUbergraph_BP_ColorCorrectRegion_Post_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_ColorCorrectRegion_Post_C.__ExecuteUbergraph_BP_ColorCorrectRegion_Post_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_ColorCorrectRegion_Post_C.__ExecuteUbergraph_BP_ColorCorrectRegion_Post_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601F422 RID: 128034 RVA: 0x0090D0AB File Offset: 0x0090B2AB
		protected BP_ColorCorrectRegion_Post_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400F806 RID: 63494
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Light/BP_ColorCorrectRegion_Post.BP_ColorCorrectRegion_Post_C";

		// Token: 0x0400F807 RID: 63495
		private static IntPtr _ClassPtr;

		// Token: 0x0400F808 RID: 63496
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400F809 RID: 63497
		internal static int __PropertyOffset_0;

		// Token: 0x0400F80A RID: 63498
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400F80B RID: 63499
		internal static int __PropertyOffset_1;

		// Token: 0x0400F80C RID: 63500
		internal static int __PropertyOffset_2;

		// Token: 0x0400F80D RID: 63501
		internal static int __PropertyOffset_3;

		// Token: 0x0400F80E RID: 63502
		internal static int __PropertyOffset_4;

		// Token: 0x0400F80F RID: 63503
		private TMap<FName, float> _Scalar_Parameters;

		// Token: 0x0400F810 RID: 63504
		internal static int __PropertyOffset_5;

		// Token: 0x0400F811 RID: 63505
		private TMap<FName, FLinearColor> _Vector_Parameters;

		// Token: 0x0400F812 RID: 63506
		internal static int __PropertyOffset_6;

		// Token: 0x0400F813 RID: 63507
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<FName, UTexture> _Texture_Parameters;

		// Token: 0x0400F814 RID: 63508
		internal static int __PropertyOffset_7;

		// Token: 0x0400F815 RID: 63509
		internal static int __PropertyOffset_8;

		// Token: 0x0400F816 RID: 63510
		internal static int __PropertyOffset_9;

		// Token: 0x0400F817 RID: 63511
		internal static int __PropertyOffset_10;

		// Token: 0x0400F818 RID: 63512
		internal static int __PropertyOffset_11;

		// Token: 0x0400F819 RID: 63513
		internal static int __PropertyOffset_12;

		// Token: 0x0400F81A RID: 63514
		internal static int __PropertyOffset_13;

		// Token: 0x0400F81B RID: 63515
		internal static int __PropertyOffset_14;

		// Token: 0x0400F81C RID: 63516
		internal static int __PropertyOffset_15;

		// Token: 0x0400F81D RID: 63517
		private static IntPtr __SetParameter_NativeFunctionPtr;

		// Token: 0x0400F81E RID: 63518
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x0400F81F RID: 63519
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0400F820 RID: 63520
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0400F821 RID: 63521
		private static IntPtr __ReceiveDestroyed_NativeFunctionPtr;

		// Token: 0x0400F822 RID: 63522
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x0400F823 RID: 63523
		private static IntPtr __ExecuteUbergraph_BP_ColorCorrectRegion_Post_NativeFunctionPtr;

		// Token: 0x020098B6 RID: 39094
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04031F07 RID: 204551
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x020098B7 RID: 39095
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x04031F08 RID: 204552
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x020098B8 RID: 39096
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __ExecuteUbergraph_BP_ColorCorrectRegion_Post_FunctionParams
		{
			// Token: 0x04031F09 RID: 204553
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
