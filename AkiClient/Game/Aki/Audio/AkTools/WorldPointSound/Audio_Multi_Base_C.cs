using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Audio.AkTools.WorldPointSound
{
	// Token: 0x02004384 RID: 17284
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Audio/AkTools/WorldPointSound/Audio_Multi_Base.Audio_Multi_Base_C")]
	[UnrealStructLayout(1120, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1117)]
	public class Audio_Multi_Base_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602DD00 RID: 187648 RVA: 0x00ACCA90 File Offset: 0x00ACAC90
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (Audio_Multi_Base_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Audio/AkTools/WorldPointSound/Audio_Multi_Base.Audio_Multi_Base_C");
			}
			return Audio_Multi_Base_C._ClassPtr;
		}

		// Token: 0x0602DD01 RID: 187649 RVA: 0x00ACCAB4 File Offset: 0x00ACACB4
		public Audio_Multi_Base_C() : this(BuiltinUtils.AllocNativeUObject(Audio_Multi_Base_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602DD02 RID: 187650 RVA: 0x00ACCADC File Offset: 0x00ACACDC
		[NullableContext(1)]
		public Audio_Multi_Base_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(Audio_Multi_Base_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007D90 RID: 32144
		// (get) Token: 0x0602DD03 RID: 187651 RVA: 0x00ACCB10 File Offset: 0x00ACAD10
		// (set) Token: 0x0602DD04 RID: 187652 RVA: 0x00ACCB49 File Offset: 0x00ACAD49
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)Audio_Multi_Base_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)Audio_Multi_Base_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007D91 RID: 32145
		// (get) Token: 0x0602DD05 RID: 187653 RVA: 0x00ACCB6A File Offset: 0x00ACAD6A
		// (set) Token: 0x0602DD06 RID: 187654 RVA: 0x00ACCB7E File Offset: 0x00ACAD7E
		public unsafe UInstancedStaticMeshComponent ISM可视化显示
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UInstancedStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + Audio_Multi_Base_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + Audio_Multi_Base_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17007D92 RID: 32146
		// (get) Token: 0x0602DD07 RID: 187655 RVA: 0x00ACCB93 File Offset: 0x00ACAD93
		// (set) Token: 0x0602DD08 RID: 187656 RVA: 0x00ACCBA7 File Offset: 0x00ACADA7
		public unsafe UAkComponent Ak
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UAkComponent>(base.NativePtr / (IntPtr)sizeof(void*) + Audio_Multi_Base_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + Audio_Multi_Base_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17007D93 RID: 32147
		// (get) Token: 0x0602DD09 RID: 187657 RVA: 0x00ACCBBC File Offset: 0x00ACADBC
		// (set) Token: 0x0602DD0A RID: 187658 RVA: 0x00ACCBD0 File Offset: 0x00ACADD0
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + Audio_Multi_Base_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + Audio_Multi_Base_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17007D94 RID: 32148
		// (get) Token: 0x0602DD0B RID: 187659 RVA: 0x00ACCBE5 File Offset: 0x00ACADE5
		// (set) Token: 0x0602DD0C RID: 187660 RVA: 0x00ACCBF9 File Offset: 0x00ACADF9
		public unsafe UAkAudioEvent Event
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UAkAudioEvent>(base.NativePtr / (IntPtr)sizeof(void*) + Audio_Multi_Base_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + Audio_Multi_Base_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17007D95 RID: 32149
		// (get) Token: 0x0602DD0D RID: 187661 RVA: 0x00ACCC0E File Offset: 0x00ACAE0E
		// (set) Token: 0x0602DD0E RID: 187662 RVA: 0x00ACCC1E File Offset: 0x00ACAE1E
		public unsafe float 内径缩放因子系数
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Audio_Multi_Base_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Audio_Multi_Base_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17007D96 RID: 32150
		// (get) Token: 0x0602DD0F RID: 187663 RVA: 0x00ACCC30 File Offset: 0x00ACAE30
		// (set) Token: 0x0602DD10 RID: 187664 RVA: 0x00ACCC69 File Offset: 0x00ACAE69
		[Nullable(1)]
		public TArray<FTransform> MultiPos
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<FTransform> result;
				if ((result = this._MultiPos) == null)
				{
					result = (this._MultiPos = new TArray<FTransform>(base.NativePtr + (IntPtr)Audio_Multi_Base_C.__PropertyOffset_6, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.MultiPos.CopyAssign(value);
			}
		}

		// Token: 0x17007D97 RID: 32151
		// (get) Token: 0x0602DD11 RID: 187665 RVA: 0x00ACCC77 File Offset: 0x00ACAE77
		// (set) Token: 0x0602DD12 RID: 187666 RVA: 0x00ACCC87 File Offset: 0x00ACAE87
		public unsafe float 流送距离
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Audio_Multi_Base_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Audio_Multi_Base_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17007D98 RID: 32152
		// (get) Token: 0x0602DD13 RID: 187667 RVA: 0x00ACCC98 File Offset: 0x00ACAE98
		// (set) Token: 0x0602DD14 RID: 187668 RVA: 0x00ACCCA8 File Offset: 0x00ACAEA8
		public unsafe float 多点内径_不含缩放因子_
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Audio_Multi_Base_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Audio_Multi_Base_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17007D99 RID: 32153
		// (get) Token: 0x0602DD15 RID: 187669 RVA: 0x00ACCCB9 File Offset: 0x00ACAEB9
		// (set) Token: 0x0602DD16 RID: 187670 RVA: 0x00ACCCCD File Offset: 0x00ACAECD
		public unsafe FVector 材质颜色
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Audio_Multi_Base_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Audio_Multi_Base_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17007D9A RID: 32154
		// (get) Token: 0x0602DD17 RID: 187671 RVA: 0x00ACCCE2 File Offset: 0x00ACAEE2
		// (set) Token: 0x0602DD18 RID: 187672 RVA: 0x00ACCCF2 File Offset: 0x00ACAEF2
		public unsafe bool 是否在开始时播放声音
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Audio_Multi_Base_C.__PropertyOffset_10) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)Audio_Multi_Base_C.__PropertyOffset_10) = (value ? 1 : 0);
			}
		}

		// Token: 0x0602DD19 RID: 187673 RVA: 0x00ACCD03 File Offset: 0x00ACAF03
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Hide()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, Audio_Multi_Base_C.__Hide_NativeFunctionPtr, null);
		}

		// Token: 0x0602DD1A RID: 187674 RVA: 0x00ACCD17 File Offset: 0x00ACAF17
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Show()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, Audio_Multi_Base_C.__Show_NativeFunctionPtr, null);
		}

		// Token: 0x0602DD1B RID: 187675 RVA: 0x00ACCD2B File Offset: 0x00ACAF2B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void GamePlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, Audio_Multi_Base_C.__GamePlay_NativeFunctionPtr, null);
		}

		// Token: 0x0602DD1C RID: 187676 RVA: 0x00ACCD3F File Offset: 0x00ACAF3F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 重设中心点()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, Audio_Multi_Base_C.__重设中心点_NativeFunctionPtr, null);
		}

		// Token: 0x0602DD1D RID: 187677 RVA: 0x00ACCD53 File Offset: 0x00ACAF53
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 显示流送距离()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, Audio_Multi_Base_C.__显示流送距离_NativeFunctionPtr, null);
		}

		// Token: 0x0602DD1E RID: 187678 RVA: 0x00ACCD68 File Offset: 0x00ACAF68
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 获取中心点(ref FVector 中心点)
		{
			Audio_Multi_Base_C.__获取中心点_FunctionParams* ptr = stackalloc Audio_Multi_Base_C.__获取中心点_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(Audio_Multi_Base_C.__获取中心点_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(Audio_Multi_Base_C.__获取中心点_NativeFunctionPtr, (void*)ptr, 1);
			ptr->中心点 = 中心点;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, Audio_Multi_Base_C.__获取中心点_NativeFunctionPtr, (void*)ptr);
			中心点 = ptr->中心点;
		}

		// Token: 0x0602DD1F RID: 187679 RVA: 0x00ACCDBF File Offset: 0x00ACAFBF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 打印()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, Audio_Multi_Base_C.__打印_NativeFunctionPtr, null);
		}

		// Token: 0x0602DD20 RID: 187680 RVA: 0x00ACCDD4 File Offset: 0x00ACAFD4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 衰减半径缩放因子计算(ref float 衰减半径)
		{
			Audio_Multi_Base_C.__衰减半径缩放因子计算_FunctionParams* ptr = stackalloc Audio_Multi_Base_C.__衰减半径缩放因子计算_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(Audio_Multi_Base_C.__衰减半径缩放因子计算_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(Audio_Multi_Base_C.__衰减半径缩放因子计算_NativeFunctionPtr, (void*)ptr, 1);
			ptr->衰减半径 = 衰减半径;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, Audio_Multi_Base_C.__衰减半径缩放因子计算_NativeFunctionPtr, (void*)ptr);
			衰减半径 = ptr->衰减半径;
		}

		// Token: 0x0602DD21 RID: 187681 RVA: 0x00ACCE23 File Offset: 0x00ACB023
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Stop()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, Audio_Multi_Base_C.__Stop_NativeFunctionPtr, null);
		}

		// Token: 0x0602DD22 RID: 187682 RVA: 0x00ACCE37 File Offset: 0x00ACB037
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Play()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, Audio_Multi_Base_C.__Play_NativeFunctionPtr, null);
		}

		// Token: 0x0602DD23 RID: 187683 RVA: 0x00ACCE4B File Offset: 0x00ACB04B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 清除可视化()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, Audio_Multi_Base_C.__清除可视化_NativeFunctionPtr, null);
		}

		// Token: 0x0602DD24 RID: 187684 RVA: 0x00ACCE5F File Offset: 0x00ACB05F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 流送距离计算()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, Audio_Multi_Base_C.__流送距离计算_NativeFunctionPtr, null);
		}

		// Token: 0x0602DD25 RID: 187685 RVA: 0x00ACCE73 File Offset: 0x00ACB073
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 根据内径缩放衰减因子()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, Audio_Multi_Base_C.__根据内径缩放衰减因子_NativeFunctionPtr, null);
		}

		// Token: 0x0602DD26 RID: 187686 RVA: 0x00ACCE87 File Offset: 0x00ACB087
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 可视化()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, Audio_Multi_Base_C.__可视化_NativeFunctionPtr, null);
		}

		// Token: 0x0602DD27 RID: 187687 RVA: 0x00ACCE9B File Offset: 0x00ACB09B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, Audio_Multi_Base_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0602DD28 RID: 187688 RVA: 0x00ACCEAF File Offset: 0x00ACB0AF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, Audio_Multi_Base_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602DD29 RID: 187689 RVA: 0x00ACCEC4 File Offset: 0x00ACB0C4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveEndPlay(EEndPlayReason EndPlayReason)
		{
			Audio_Multi_Base_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc Audio_Multi_Base_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(Audio_Multi_Base_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(Audio_Multi_Base_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, Audio_Multi_Base_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602DD2A RID: 187690 RVA: 0x00ACCF10 File Offset: 0x00ACB110
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveEndPlay_Implementation(EEndPlayReason EndPlayReason)
		{
			Audio_Multi_Base_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc Audio_Multi_Base_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(Audio_Multi_Base_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(Audio_Multi_Base_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, Audio_Multi_Base_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602DD2B RID: 187691 RVA: 0x00ACCF5C File Offset: 0x00ACB15C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_Audio_Multi_Base(int EntryPoint)
		{
			Audio_Multi_Base_C.__ExecuteUbergraph_Audio_Multi_Base_FunctionParams* ptr = stackalloc Audio_Multi_Base_C.__ExecuteUbergraph_Audio_Multi_Base_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(Audio_Multi_Base_C.__ExecuteUbergraph_Audio_Multi_Base_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(Audio_Multi_Base_C.__ExecuteUbergraph_Audio_Multi_Base_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, Audio_Multi_Base_C.__ExecuteUbergraph_Audio_Multi_Base_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602DD2C RID: 187692 RVA: 0x00ACCFA3 File Offset: 0x00ACB1A3
		protected Audio_Multi_Base_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04019DD8 RID: 105944
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Audio/AkTools/WorldPointSound/Audio_Multi_Base.Audio_Multi_Base_C";

		// Token: 0x04019DD9 RID: 105945
		private static IntPtr _ClassPtr;

		// Token: 0x04019DDA RID: 105946
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04019DDB RID: 105947
		internal static int __PropertyOffset_0;

		// Token: 0x04019DDC RID: 105948
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04019DDD RID: 105949
		internal static int __PropertyOffset_1;

		// Token: 0x04019DDE RID: 105950
		internal static int __PropertyOffset_2;

		// Token: 0x04019DDF RID: 105951
		internal static int __PropertyOffset_3;

		// Token: 0x04019DE0 RID: 105952
		internal static int __PropertyOffset_4;

		// Token: 0x04019DE1 RID: 105953
		internal static int __PropertyOffset_5;

		// Token: 0x04019DE2 RID: 105954
		internal static int __PropertyOffset_6;

		// Token: 0x04019DE3 RID: 105955
		private TArray<FTransform> _MultiPos;

		// Token: 0x04019DE4 RID: 105956
		internal static int __PropertyOffset_7;

		// Token: 0x04019DE5 RID: 105957
		internal static int __PropertyOffset_8;

		// Token: 0x04019DE6 RID: 105958
		internal static int __PropertyOffset_9;

		// Token: 0x04019DE7 RID: 105959
		internal static int __PropertyOffset_10;

		// Token: 0x04019DE8 RID: 105960
		private static IntPtr __Hide_NativeFunctionPtr;

		// Token: 0x04019DE9 RID: 105961
		private static IntPtr __Show_NativeFunctionPtr;

		// Token: 0x04019DEA RID: 105962
		private static IntPtr __GamePlay_NativeFunctionPtr;

		// Token: 0x04019DEB RID: 105963
		private static IntPtr __重设中心点_NativeFunctionPtr;

		// Token: 0x04019DEC RID: 105964
		private static IntPtr __显示流送距离_NativeFunctionPtr;

		// Token: 0x04019DED RID: 105965
		private static IntPtr __获取中心点_NativeFunctionPtr;

		// Token: 0x04019DEE RID: 105966
		private static IntPtr __打印_NativeFunctionPtr;

		// Token: 0x04019DEF RID: 105967
		private static IntPtr __衰减半径缩放因子计算_NativeFunctionPtr;

		// Token: 0x04019DF0 RID: 105968
		private static IntPtr __Stop_NativeFunctionPtr;

		// Token: 0x04019DF1 RID: 105969
		private static IntPtr __Play_NativeFunctionPtr;

		// Token: 0x04019DF2 RID: 105970
		private static IntPtr __清除可视化_NativeFunctionPtr;

		// Token: 0x04019DF3 RID: 105971
		private static IntPtr __流送距离计算_NativeFunctionPtr;

		// Token: 0x04019DF4 RID: 105972
		private static IntPtr __根据内径缩放衰减因子_NativeFunctionPtr;

		// Token: 0x04019DF5 RID: 105973
		private static IntPtr __可视化_NativeFunctionPtr;

		// Token: 0x04019DF6 RID: 105974
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04019DF7 RID: 105975
		private static IntPtr __ReceiveEndPlay_NativeFunctionPtr;

		// Token: 0x04019DF8 RID: 105976
		private static IntPtr __ExecuteUbergraph_Audio_Multi_Base_NativeFunctionPtr;

		// Token: 0x0200A5AB RID: 42411
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __获取中心点_FunctionParams
		{
			// Token: 0x0403350B RID: 210187
			[FieldOffset(0)]
			public FVector 中心点;
		}

		// Token: 0x0200A5AC RID: 42412
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __衰减半径缩放因子计算_FunctionParams
		{
			// Token: 0x0403350C RID: 210188
			[FieldOffset(0)]
			public float 衰减半径;
		}

		// Token: 0x0200A5AD RID: 42413
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __ReceiveEndPlay_FunctionParams
		{
			// Token: 0x0403350D RID: 210189
			[FieldOffset(0)]
			public TEnumAsByte<EEndPlayReason> EndPlayReason;
		}

		// Token: 0x0200A5AE RID: 42414
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __ExecuteUbergraph_Audio_Multi_Base_FunctionParams
		{
			// Token: 0x0403350E RID: 210190
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
