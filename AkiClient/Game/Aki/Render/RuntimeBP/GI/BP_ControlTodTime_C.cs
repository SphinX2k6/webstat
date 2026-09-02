using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.GI
{
	// Token: 0x02003C92 RID: 15506
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/GI/BP_ControlTodTime.BP_ControlTodTime_C")]
	[UnrealStructLayout(1328, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1328)]
	public class BP_ControlTodTime_C : AKuroControlTodTime, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06024328 RID: 148264 RVA: 0x009974A0 File Offset: 0x009956A0
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_ControlTodTime_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/GI/BP_ControlTodTime.BP_ControlTodTime_C");
			}
			return BP_ControlTodTime_C._ClassPtr;
		}

		// Token: 0x06024329 RID: 148265 RVA: 0x009974C4 File Offset: 0x009956C4
		public BP_ControlTodTime_C() : this(BuiltinUtils.AllocNativeUObject(BP_ControlTodTime_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602432A RID: 148266 RVA: 0x009974EC File Offset: 0x009956EC
		public BP_ControlTodTime_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_ControlTodTime_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17004A9A RID: 19098
		// (get) Token: 0x0602432B RID: 148267 RVA: 0x00997520 File Offset: 0x00995720
		// (set) Token: 0x0602432C RID: 148268 RVA: 0x00997559 File Offset: 0x00995759
		public FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_ControlTodTime_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_ControlTodTime_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17004A9B RID: 19099
		// (get) Token: 0x0602432D RID: 148269 RVA: 0x0099757A File Offset: 0x0099577A
		// (set) Token: 0x0602432E RID: 148270 RVA: 0x0099758E File Offset: 0x0099578E
		[Nullable(2)]
		public unsafe USceneComponent DefaultSceneRoot
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_ControlTodTime_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_ControlTodTime_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17004A9C RID: 19100
		// (get) Token: 0x0602432F RID: 148271 RVA: 0x009975A3 File Offset: 0x009957A3
		// (set) Token: 0x06024330 RID: 148272 RVA: 0x009975B3 File Offset: 0x009957B3
		public unsafe float TodTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ControlTodTime_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ControlTodTime_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17004A9D RID: 19101
		// (get) Token: 0x06024331 RID: 148273 RVA: 0x009975C4 File Offset: 0x009957C4
		// (set) Token: 0x06024332 RID: 148274 RVA: 0x009975D4 File Offset: 0x009957D4
		public unsafe bool EnableTodTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ControlTodTime_C.__PropertyOffset_3) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ControlTodTime_C.__PropertyOffset_3) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004A9E RID: 19102
		// (get) Token: 0x06024333 RID: 148275 RVA: 0x009975E5 File Offset: 0x009957E5
		// (set) Token: 0x06024334 RID: 148276 RVA: 0x009975F5 File Offset: 0x009957F5
		public unsafe float SunVerticalAngle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ControlTodTime_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ControlTodTime_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17004A9F RID: 19103
		// (get) Token: 0x06024335 RID: 148277 RVA: 0x00997606 File Offset: 0x00995806
		// (set) Token: 0x06024336 RID: 148278 RVA: 0x00997616 File Offset: 0x00995816
		public unsafe bool EnableSunVerticalAngle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ControlTodTime_C.__PropertyOffset_5) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ControlTodTime_C.__PropertyOffset_5) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004AA0 RID: 19104
		// (get) Token: 0x06024337 RID: 148279 RVA: 0x00997627 File Offset: 0x00995827
		// (set) Token: 0x06024338 RID: 148280 RVA: 0x00997637 File Offset: 0x00995837
		public unsafe float SunHorizontalAngle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ControlTodTime_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ControlTodTime_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17004AA1 RID: 19105
		// (get) Token: 0x06024339 RID: 148281 RVA: 0x00997648 File Offset: 0x00995848
		// (set) Token: 0x0602433A RID: 148282 RVA: 0x00997658 File Offset: 0x00995858
		public unsafe bool EnableSunHorizontalAngle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ControlTodTime_C.__PropertyOffset_7) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ControlTodTime_C.__PropertyOffset_7) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004AA2 RID: 19106
		// (get) Token: 0x0602433B RID: 148283 RVA: 0x00997669 File Offset: 0x00995869
		// (set) Token: 0x0602433C RID: 148284 RVA: 0x00997679 File Offset: 0x00995879
		public unsafe float MainLightAngelLimit
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ControlTodTime_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ControlTodTime_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17004AA3 RID: 19107
		// (get) Token: 0x0602433D RID: 148285 RVA: 0x0099768A File Offset: 0x0099588A
		// (set) Token: 0x0602433E RID: 148286 RVA: 0x0099769A File Offset: 0x0099589A
		public unsafe bool EnableMainLightAngelLimit
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ControlTodTime_C.__PropertyOffset_9) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ControlTodTime_C.__PropertyOffset_9) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004AA4 RID: 19108
		// (get) Token: 0x0602433F RID: 148287 RVA: 0x009976AB File Offset: 0x009958AB
		// (set) Token: 0x06024340 RID: 148288 RVA: 0x009976BB File Offset: 0x009958BB
		public unsafe float AccumulatedTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ControlTodTime_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ControlTodTime_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17004AA5 RID: 19109
		// (get) Token: 0x06024341 RID: 148289 RVA: 0x009976CC File Offset: 0x009958CC
		// (set) Token: 0x06024342 RID: 148290 RVA: 0x00997705 File Offset: 0x00995905
		public TSet<int> CameraChangedTime
		{
			get
			{
				base.FastCheckIsValid();
				TSet<int> result;
				if ((result = this._CameraChangedTime) == null)
				{
					result = (this._CameraChangedTime = new TSet<int>(base.NativePtr + (IntPtr)BP_ControlTodTime_C.__PropertyOffset_11, this));
				}
				return result;
			}
			set
			{
				this.CameraChangedTime.CopyAssign(value);
			}
		}

		// Token: 0x17004AA6 RID: 19110
		// (get) Token: 0x06024343 RID: 148291 RVA: 0x00997714 File Offset: 0x00995914
		// (set) Token: 0x06024344 RID: 148292 RVA: 0x0099774D File Offset: 0x0099594D
		public TSet<int> TSetCall
		{
			get
			{
				base.FastCheckIsValid();
				TSet<int> result;
				if ((result = this._TSetCall) == null)
				{
					result = (this._TSetCall = new TSet<int>(base.NativePtr + (IntPtr)BP_ControlTodTime_C.__PropertyOffset_12, this));
				}
				return result;
			}
			set
			{
				this.TSetCall.CopyAssign(value);
			}
		}

		// Token: 0x17004AA7 RID: 19111
		// (get) Token: 0x06024345 RID: 148293 RVA: 0x0099775C File Offset: 0x0099595C
		// (set) Token: 0x06024346 RID: 148294 RVA: 0x00997795 File Offset: 0x00995995
		public TSet<int> TSetUncall
		{
			get
			{
				base.FastCheckIsValid();
				TSet<int> result;
				if ((result = this._TSetUncall) == null)
				{
					result = (this._TSetUncall = new TSet<int>(base.NativePtr + (IntPtr)BP_ControlTodTime_C.__PropertyOffset_13, this));
				}
				return result;
			}
			set
			{
				this.TSetUncall.CopyAssign(value);
			}
		}

		// Token: 0x06024347 RID: 148295 RVA: 0x009977A3 File Offset: 0x009959A3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Update()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ControlTodTime_C.__Update_NativeFunctionPtr, null);
		}

		// Token: 0x06024348 RID: 148296 RVA: 0x009977B7 File Offset: 0x009959B7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ControlTodTime_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06024349 RID: 148297 RVA: 0x009977CB File Offset: 0x009959CB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_ControlTodTime_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602434A RID: 148298 RVA: 0x009977E0 File Offset: 0x009959E0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveEndPlay(EEndPlayReason EndPlayReason)
		{
			BP_ControlTodTime_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_ControlTodTime_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_ControlTodTime_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_ControlTodTime_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ControlTodTime_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602434B RID: 148299 RVA: 0x0099782C File Offset: 0x00995A2C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveEndPlay_Implementation(EEndPlayReason EndPlayReason)
		{
			BP_ControlTodTime_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_ControlTodTime_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_ControlTodTime_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_ControlTodTime_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_ControlTodTime_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602434C RID: 148300 RVA: 0x00997878 File Offset: 0x00995A78
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveDestroyed()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ControlTodTime_C.__ReceiveDestroyed_NativeFunctionPtr, null);
		}

		// Token: 0x0602434D RID: 148301 RVA: 0x0099788C File Offset: 0x00995A8C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveDestroyed_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_ControlTodTime_C.__ReceiveDestroyed_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602434E RID: 148302 RVA: 0x009978A4 File Offset: 0x00995AA4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void DoUpdate(float DeltaTime)
		{
			BP_ControlTodTime_C.__DoUpdate_FunctionParams* ptr = stackalloc BP_ControlTodTime_C.__DoUpdate_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_ControlTodTime_C.__DoUpdate_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_ControlTodTime_C.__DoUpdate_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaTime = DeltaTime;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ControlTodTime_C.__DoUpdate_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602434F RID: 148303 RVA: 0x009978EC File Offset: 0x00995AEC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void DoUpdate_Implementation(float DeltaTime)
		{
			BP_ControlTodTime_C.__DoUpdate_FunctionParams* ptr = stackalloc BP_ControlTodTime_C.__DoUpdate_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_ControlTodTime_C.__DoUpdate_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_ControlTodTime_C.__DoUpdate_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaTime = DeltaTime;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_ControlTodTime_C.__DoUpdate_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06024350 RID: 148304 RVA: 0x00997934 File Offset: 0x00995B34
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_ControlTodTime(int EntryPoint)
		{
			BP_ControlTodTime_C.__ExecuteUbergraph_BP_ControlTodTime_FunctionParams* ptr = stackalloc BP_ControlTodTime_C.__ExecuteUbergraph_BP_ControlTodTime_FunctionParams[(UIntPtr)63] + 15L / (long)sizeof(BP_ControlTodTime_C.__ExecuteUbergraph_BP_ControlTodTime_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_ControlTodTime_C.__ExecuteUbergraph_BP_ControlTodTime_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_ControlTodTime_C.__ExecuteUbergraph_BP_ControlTodTime_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06024351 RID: 148305 RVA: 0x0099797B File Offset: 0x00995B7B
		protected BP_ControlTodTime_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04012845 RID: 75845
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/GI/BP_ControlTodTime.BP_ControlTodTime_C";

		// Token: 0x04012846 RID: 75846
		private static IntPtr _ClassPtr;

		// Token: 0x04012847 RID: 75847
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04012848 RID: 75848
		internal static int __PropertyOffset_0;

		// Token: 0x04012849 RID: 75849
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0401284A RID: 75850
		internal static int __PropertyOffset_1;

		// Token: 0x0401284B RID: 75851
		internal static int __PropertyOffset_2;

		// Token: 0x0401284C RID: 75852
		internal static int __PropertyOffset_3;

		// Token: 0x0401284D RID: 75853
		internal static int __PropertyOffset_4;

		// Token: 0x0401284E RID: 75854
		internal static int __PropertyOffset_5;

		// Token: 0x0401284F RID: 75855
		internal static int __PropertyOffset_6;

		// Token: 0x04012850 RID: 75856
		internal static int __PropertyOffset_7;

		// Token: 0x04012851 RID: 75857
		internal static int __PropertyOffset_8;

		// Token: 0x04012852 RID: 75858
		internal static int __PropertyOffset_9;

		// Token: 0x04012853 RID: 75859
		internal static int __PropertyOffset_10;

		// Token: 0x04012854 RID: 75860
		internal static int __PropertyOffset_11;

		// Token: 0x04012855 RID: 75861
		[Nullable(2)]
		private TSet<int> _CameraChangedTime;

		// Token: 0x04012856 RID: 75862
		internal static int __PropertyOffset_12;

		// Token: 0x04012857 RID: 75863
		[Nullable(2)]
		private TSet<int> _TSetCall;

		// Token: 0x04012858 RID: 75864
		internal static int __PropertyOffset_13;

		// Token: 0x04012859 RID: 75865
		[Nullable(2)]
		private TSet<int> _TSetUncall;

		// Token: 0x0401285A RID: 75866
		private static IntPtr __Update_NativeFunctionPtr;

		// Token: 0x0401285B RID: 75867
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0401285C RID: 75868
		private static IntPtr __ReceiveEndPlay_NativeFunctionPtr;

		// Token: 0x0401285D RID: 75869
		private static IntPtr __ReceiveDestroyed_NativeFunctionPtr;

		// Token: 0x0401285E RID: 75870
		private static IntPtr __DoUpdate_NativeFunctionPtr;

		// Token: 0x0401285F RID: 75871
		private static IntPtr __ExecuteUbergraph_BP_ControlTodTime_NativeFunctionPtr;

		// Token: 0x02009D9D RID: 40349
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __ReceiveEndPlay_FunctionParams
		{
			// Token: 0x04032794 RID: 206740
			[FieldOffset(0)]
			public TEnumAsByte<EEndPlayReason> EndPlayReason;
		}

		// Token: 0x02009D9E RID: 40350
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __DoUpdate_FunctionParams
		{
			// Token: 0x04032795 RID: 206741
			[FieldOffset(0)]
			public float DeltaTime;
		}

		// Token: 0x02009D9F RID: 40351
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 48)]
		protected ref struct __ExecuteUbergraph_BP_ControlTodTime_FunctionParams
		{
			// Token: 0x04032796 RID: 206742
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
