using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Light
{
	// Token: 0x02003A7D RID: 14973
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Light/BP_CustomFFT_Seq.BP_CustomFFT_Seq_C")]
	[UnrealStructLayout(1488, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1488)]
	public class BP_CustomFFT_Seq_C : AKuroEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601F477 RID: 128119 RVA: 0x0090DB7B File Offset: 0x0090BD7B
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_CustomFFT_Seq_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/Light/BP_CustomFFT_Seq.BP_CustomFFT_Seq_C");
			}
			return BP_CustomFFT_Seq_C._ClassPtr;
		}

		// Token: 0x0601F478 RID: 128120 RVA: 0x0090DBA0 File Offset: 0x0090BDA0
		public BP_CustomFFT_Seq_C() : this(BuiltinUtils.AllocNativeUObject(BP_CustomFFT_Seq_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601F479 RID: 128121 RVA: 0x0090DBC8 File Offset: 0x0090BDC8
		[NullableContext(1)]
		public BP_CustomFFT_Seq_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_CustomFFT_Seq_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17002EEB RID: 12011
		// (get) Token: 0x0601F47A RID: 128122 RVA: 0x0090DBFC File Offset: 0x0090BDFC
		// (set) Token: 0x0601F47B RID: 128123 RVA: 0x0090DC35 File Offset: 0x0090BE35
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_CustomFFT_Seq_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_CustomFFT_Seq_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17002EEC RID: 12012
		// (get) Token: 0x0601F47C RID: 128124 RVA: 0x0090DC56 File Offset: 0x0090BE56
		// (set) Token: 0x0601F47D RID: 128125 RVA: 0x0090DC6A File Offset: 0x0090BE6A
		public unsafe UKuroPostProcessComponent KuroPostProcess
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroPostProcessComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CustomFFT_Seq_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CustomFFT_Seq_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17002EED RID: 12013
		// (get) Token: 0x0601F47E RID: 128126 RVA: 0x0090DC7F File Offset: 0x0090BE7F
		// (set) Token: 0x0601F47F RID: 128127 RVA: 0x0090DC93 File Offset: 0x0090BE93
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CustomFFT_Seq_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CustomFFT_Seq_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17002EEE RID: 12014
		// (get) Token: 0x0601F480 RID: 128128 RVA: 0x0090DCA8 File Offset: 0x0090BEA8
		// (set) Token: 0x0601F481 RID: 128129 RVA: 0x0090DCB8 File Offset: 0x0090BEB8
		public unsafe float Intensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CustomFFT_Seq_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CustomFFT_Seq_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17002EEF RID: 12015
		// (get) Token: 0x0601F482 RID: 128130 RVA: 0x0090DCC9 File Offset: 0x0090BEC9
		// (set) Token: 0x0601F483 RID: 128131 RVA: 0x0090DCD9 File Offset: 0x0090BED9
		public unsafe float InvSize
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CustomFFT_Seq_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CustomFFT_Seq_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17002EF0 RID: 12016
		// (get) Token: 0x0601F484 RID: 128132 RVA: 0x0090DCEA File Offset: 0x0090BEEA
		// (set) Token: 0x0601F485 RID: 128133 RVA: 0x0090DCFE File Offset: 0x0090BEFE
		public unsafe UMaterialInstanceDynamic DynamicMaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CustomFFT_Seq_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CustomFFT_Seq_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x17002EF1 RID: 12017
		// (get) Token: 0x0601F486 RID: 128134 RVA: 0x0090DD13 File Offset: 0x0090BF13
		// (set) Token: 0x0601F487 RID: 128135 RVA: 0x0090DD27 File Offset: 0x0090BF27
		public unsafe UTexture2D Texture
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CustomFFT_Seq_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CustomFFT_Seq_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x17002EF2 RID: 12018
		// (get) Token: 0x0601F488 RID: 128136 RVA: 0x0090DD3C File Offset: 0x0090BF3C
		// (set) Token: 0x0601F489 RID: 128137 RVA: 0x0090DD4C File Offset: 0x0090BF4C
		public unsafe float FadeRange
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CustomFFT_Seq_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CustomFFT_Seq_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17002EF3 RID: 12019
		// (get) Token: 0x0601F48A RID: 128138 RVA: 0x0090DD5D File Offset: 0x0090BF5D
		// (set) Token: 0x0601F48B RID: 128139 RVA: 0x0090DD6D File Offset: 0x0090BF6D
		public unsafe float Size
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CustomFFT_Seq_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CustomFFT_Seq_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17002EF4 RID: 12020
		// (get) Token: 0x0601F48C RID: 128140 RVA: 0x0090DD7E File Offset: 0x0090BF7E
		// (set) Token: 0x0601F48D RID: 128141 RVA: 0x0090DD92 File Offset: 0x0090BF92
		public unsafe FLinearColor Color
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CustomFFT_Seq_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CustomFFT_Seq_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17002EF5 RID: 12021
		// (get) Token: 0x0601F48E RID: 128142 RVA: 0x0090DDA7 File Offset: 0x0090BFA7
		// (set) Token: 0x0601F48F RID: 128143 RVA: 0x0090DDB7 File Offset: 0x0090BFB7
		public unsafe float Angle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CustomFFT_Seq_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CustomFFT_Seq_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17002EF6 RID: 12022
		// (get) Token: 0x0601F490 RID: 128144 RVA: 0x0090DDC8 File Offset: 0x0090BFC8
		// (set) Token: 0x0601F491 RID: 128145 RVA: 0x0090DE01 File Offset: 0x0090C001
		[Nullable(1)]
		public TArray<AActor> ActorReference
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<AActor> result;
				if ((result = this._ActorReference) == null)
				{
					result = (this._ActorReference = new TArray<AActor>(base.NativePtr + (IntPtr)BP_CustomFFT_Seq_C.__PropertyOffset_11, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.ActorReference.CopyAssign(value);
			}
		}

		// Token: 0x17002EF7 RID: 12023
		// (get) Token: 0x0601F492 RID: 128146 RVA: 0x0090DE0F File Offset: 0x0090C00F
		// (set) Token: 0x0601F493 RID: 128147 RVA: 0x0090DE1F File Offset: 0x0090C01F
		public unsafe float Intensity_2
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CustomFFT_Seq_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CustomFFT_Seq_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17002EF8 RID: 12024
		// (get) Token: 0x0601F494 RID: 128148 RVA: 0x0090DE30 File Offset: 0x0090C030
		// (set) Token: 0x0601F495 RID: 128149 RVA: 0x0090DE40 File Offset: 0x0090C040
		public unsafe float Intensity_3
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CustomFFT_Seq_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CustomFFT_Seq_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x17002EF9 RID: 12025
		// (get) Token: 0x0601F496 RID: 128150 RVA: 0x0090DE51 File Offset: 0x0090C051
		// (set) Token: 0x0601F497 RID: 128151 RVA: 0x0090DE61 File Offset: 0x0090C061
		public unsafe float InvSize_2
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CustomFFT_Seq_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CustomFFT_Seq_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x17002EFA RID: 12026
		// (get) Token: 0x0601F498 RID: 128152 RVA: 0x0090DE72 File Offset: 0x0090C072
		// (set) Token: 0x0601F499 RID: 128153 RVA: 0x0090DE82 File Offset: 0x0090C082
		public unsafe float InvSize_3
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CustomFFT_Seq_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CustomFFT_Seq_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x17002EFB RID: 12027
		// (get) Token: 0x0601F49A RID: 128154 RVA: 0x0090DE93 File Offset: 0x0090C093
		// (set) Token: 0x0601F49B RID: 128155 RVA: 0x0090DEA7 File Offset: 0x0090C0A7
		public unsafe UTexture2D Texture_2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CustomFFT_Seq_C.__PropertyOffset_16);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CustomFFT_Seq_C.__PropertyOffset_16, value);
			}
		}

		// Token: 0x17002EFC RID: 12028
		// (get) Token: 0x0601F49C RID: 128156 RVA: 0x0090DEBC File Offset: 0x0090C0BC
		// (set) Token: 0x0601F49D RID: 128157 RVA: 0x0090DED0 File Offset: 0x0090C0D0
		public unsafe UTexture2D Texture_3
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CustomFFT_Seq_C.__PropertyOffset_17);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CustomFFT_Seq_C.__PropertyOffset_17, value);
			}
		}

		// Token: 0x17002EFD RID: 12029
		// (get) Token: 0x0601F49E RID: 128158 RVA: 0x0090DEE5 File Offset: 0x0090C0E5
		// (set) Token: 0x0601F49F RID: 128159 RVA: 0x0090DEF5 File Offset: 0x0090C0F5
		public unsafe float Size_2
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CustomFFT_Seq_C.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CustomFFT_Seq_C.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x17002EFE RID: 12030
		// (get) Token: 0x0601F4A0 RID: 128160 RVA: 0x0090DF06 File Offset: 0x0090C106
		// (set) Token: 0x0601F4A1 RID: 128161 RVA: 0x0090DF16 File Offset: 0x0090C116
		public unsafe float Size_3
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CustomFFT_Seq_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CustomFFT_Seq_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x17002EFF RID: 12031
		// (get) Token: 0x0601F4A2 RID: 128162 RVA: 0x0090DF27 File Offset: 0x0090C127
		// (set) Token: 0x0601F4A3 RID: 128163 RVA: 0x0090DF3B File Offset: 0x0090C13B
		public unsafe FLinearColor Color_2
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CustomFFT_Seq_C.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CustomFFT_Seq_C.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x17002F00 RID: 12032
		// (get) Token: 0x0601F4A4 RID: 128164 RVA: 0x0090DF50 File Offset: 0x0090C150
		// (set) Token: 0x0601F4A5 RID: 128165 RVA: 0x0090DF64 File Offset: 0x0090C164
		public unsafe FLinearColor Color_3
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CustomFFT_Seq_C.__PropertyOffset_21);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CustomFFT_Seq_C.__PropertyOffset_21) = value;
			}
		}

		// Token: 0x17002F01 RID: 12033
		// (get) Token: 0x0601F4A6 RID: 128166 RVA: 0x0090DF79 File Offset: 0x0090C179
		// (set) Token: 0x0601F4A7 RID: 128167 RVA: 0x0090DF89 File Offset: 0x0090C189
		public unsafe float Angle_2
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CustomFFT_Seq_C.__PropertyOffset_22);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CustomFFT_Seq_C.__PropertyOffset_22) = value;
			}
		}

		// Token: 0x17002F02 RID: 12034
		// (get) Token: 0x0601F4A8 RID: 128168 RVA: 0x0090DF9A File Offset: 0x0090C19A
		// (set) Token: 0x0601F4A9 RID: 128169 RVA: 0x0090DFAA File Offset: 0x0090C1AA
		public unsafe float Angle_3
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CustomFFT_Seq_C.__PropertyOffset_23);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CustomFFT_Seq_C.__PropertyOffset_23) = value;
			}
		}

		// Token: 0x0601F4AA RID: 128170 RVA: 0x0090DFBB File Offset: 0x0090C1BB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void TickFunction()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CustomFFT_Seq_C.__TickFunction_NativeFunctionPtr, null);
		}

		// Token: 0x0601F4AB RID: 128171 RVA: 0x0090DFCF File Offset: 0x0090C1CF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CustomFFT_Seq_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x0601F4AC RID: 128172 RVA: 0x0090DFE3 File Offset: 0x0090C1E3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_CustomFFT_Seq_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601F4AD RID: 128173 RVA: 0x0090DFF8 File Offset: 0x0090C1F8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CustomFFT_Seq_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0601F4AE RID: 128174 RVA: 0x0090E00C File Offset: 0x0090C20C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_CustomFFT_Seq_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601F4AF RID: 128175 RVA: 0x0090E024 File Offset: 0x0090C224
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_CustomFFT_Seq_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_CustomFFT_Seq_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_CustomFFT_Seq_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CustomFFT_Seq_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CustomFFT_Seq_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F4B0 RID: 128176 RVA: 0x0090E06C File Offset: 0x0090C26C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_CustomFFT_Seq_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_CustomFFT_Seq_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_CustomFFT_Seq_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CustomFFT_Seq_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_CustomFFT_Seq_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601F4B1 RID: 128177 RVA: 0x0090E0B3 File Offset: 0x0090C2B3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveDestroyed()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CustomFFT_Seq_C.__ReceiveDestroyed_NativeFunctionPtr, null);
		}

		// Token: 0x0601F4B2 RID: 128178 RVA: 0x0090E0C7 File Offset: 0x0090C2C7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveDestroyed_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_CustomFFT_Seq_C.__ReceiveDestroyed_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601F4B3 RID: 128179 RVA: 0x0090E0DC File Offset: 0x0090C2DC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_CustomFFT_Seq_C.__EditorTick_FunctionParams* ptr = stackalloc BP_CustomFFT_Seq_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_CustomFFT_Seq_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CustomFFT_Seq_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CustomFFT_Seq_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F4B4 RID: 128180 RVA: 0x0090E124 File Offset: 0x0090C324
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_CustomFFT_Seq_C.__EditorTick_FunctionParams* ptr = stackalloc BP_CustomFFT_Seq_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_CustomFFT_Seq_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CustomFFT_Seq_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_CustomFFT_Seq_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601F4B5 RID: 128181 RVA: 0x0090E16C File Offset: 0x0090C36C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_CustomFFT_Seq(int EntryPoint)
		{
			BP_CustomFFT_Seq_C.__ExecuteUbergraph_BP_CustomFFT_Seq_FunctionParams* ptr = stackalloc BP_CustomFFT_Seq_C.__ExecuteUbergraph_BP_CustomFFT_Seq_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(BP_CustomFFT_Seq_C.__ExecuteUbergraph_BP_CustomFFT_Seq_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CustomFFT_Seq_C.__ExecuteUbergraph_BP_CustomFFT_Seq_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_CustomFFT_Seq_C.__ExecuteUbergraph_BP_CustomFFT_Seq_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601F4B6 RID: 128182 RVA: 0x0090E1B3 File Offset: 0x0090C3B3
		protected BP_CustomFFT_Seq_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400F857 RID: 63575
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Light/BP_CustomFFT_Seq.BP_CustomFFT_Seq_C";

		// Token: 0x0400F858 RID: 63576
		private static IntPtr _ClassPtr;

		// Token: 0x0400F859 RID: 63577
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400F85A RID: 63578
		internal static int __PropertyOffset_0;

		// Token: 0x0400F85B RID: 63579
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400F85C RID: 63580
		internal static int __PropertyOffset_1;

		// Token: 0x0400F85D RID: 63581
		internal static int __PropertyOffset_2;

		// Token: 0x0400F85E RID: 63582
		internal static int __PropertyOffset_3;

		// Token: 0x0400F85F RID: 63583
		internal static int __PropertyOffset_4;

		// Token: 0x0400F860 RID: 63584
		internal static int __PropertyOffset_5;

		// Token: 0x0400F861 RID: 63585
		internal static int __PropertyOffset_6;

		// Token: 0x0400F862 RID: 63586
		internal static int __PropertyOffset_7;

		// Token: 0x0400F863 RID: 63587
		internal static int __PropertyOffset_8;

		// Token: 0x0400F864 RID: 63588
		internal static int __PropertyOffset_9;

		// Token: 0x0400F865 RID: 63589
		internal static int __PropertyOffset_10;

		// Token: 0x0400F866 RID: 63590
		internal static int __PropertyOffset_11;

		// Token: 0x0400F867 RID: 63591
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<AActor> _ActorReference;

		// Token: 0x0400F868 RID: 63592
		internal static int __PropertyOffset_12;

		// Token: 0x0400F869 RID: 63593
		internal static int __PropertyOffset_13;

		// Token: 0x0400F86A RID: 63594
		internal static int __PropertyOffset_14;

		// Token: 0x0400F86B RID: 63595
		internal static int __PropertyOffset_15;

		// Token: 0x0400F86C RID: 63596
		internal static int __PropertyOffset_16;

		// Token: 0x0400F86D RID: 63597
		internal static int __PropertyOffset_17;

		// Token: 0x0400F86E RID: 63598
		internal static int __PropertyOffset_18;

		// Token: 0x0400F86F RID: 63599
		internal static int __PropertyOffset_19;

		// Token: 0x0400F870 RID: 63600
		internal static int __PropertyOffset_20;

		// Token: 0x0400F871 RID: 63601
		internal static int __PropertyOffset_21;

		// Token: 0x0400F872 RID: 63602
		internal static int __PropertyOffset_22;

		// Token: 0x0400F873 RID: 63603
		internal static int __PropertyOffset_23;

		// Token: 0x0400F874 RID: 63604
		private static IntPtr __TickFunction_NativeFunctionPtr;

		// Token: 0x0400F875 RID: 63605
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x0400F876 RID: 63606
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0400F877 RID: 63607
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0400F878 RID: 63608
		private static IntPtr __ReceiveDestroyed_NativeFunctionPtr;

		// Token: 0x0400F879 RID: 63609
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x0400F87A RID: 63610
		private static IntPtr __ExecuteUbergraph_BP_CustomFFT_Seq_NativeFunctionPtr;

		// Token: 0x020098C2 RID: 39106
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04031F13 RID: 204563
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x020098C3 RID: 39107
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x04031F14 RID: 204564
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x020098C4 RID: 39108
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __ExecuteUbergraph_BP_CustomFFT_Seq_FunctionParams
		{
			// Token: 0x04031F15 RID: 204565
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
