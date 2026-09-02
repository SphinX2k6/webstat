using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.UltraDynamicSky.Blueprints.Weather_Effects
{
	// Token: 0x02003A15 RID: 14869
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/UltraDynamicSky/Blueprints/Weather_Effects/Rain_Drip_Spline.Rain_Drip_Spline_C")]
	[UnrealStructLayout(1144, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1142)]
	public class Rain_Drip_Spline_C : AActor, IUnrealUObject, IUnrealObject, IWeather_Effects_Interface_C, IUnrealBlueprintInterface, IUnrealInterface
	{
		// Token: 0x0601E940 RID: 125248 RVA: 0x008F863F File Offset: 0x008F683F
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (Rain_Drip_Spline_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/UltraDynamicSky/Blueprints/Weather_Effects/Rain_Drip_Spline.Rain_Drip_Spline_C");
			}
			return Rain_Drip_Spline_C._ClassPtr;
		}

		// Token: 0x0601E941 RID: 125249 RVA: 0x008F8664 File Offset: 0x008F6864
		public Rain_Drip_Spline_C() : this(BuiltinUtils.AllocNativeUObject(Rain_Drip_Spline_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601E942 RID: 125250 RVA: 0x008F868C File Offset: 0x008F688C
		[NullableContext(1)]
		public Rain_Drip_Spline_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(Rain_Drip_Spline_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17002B5B RID: 11099
		// (get) Token: 0x0601E943 RID: 125251 RVA: 0x008F86C0 File Offset: 0x008F68C0
		// (set) Token: 0x0601E944 RID: 125252 RVA: 0x008F86F9 File Offset: 0x008F68F9
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)Rain_Drip_Spline_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)Rain_Drip_Spline_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17002B5C RID: 11100
		// (get) Token: 0x0601E945 RID: 125253 RVA: 0x008F871A File Offset: 0x008F691A
		// (set) Token: 0x0601E946 RID: 125254 RVA: 0x008F872E File Offset: 0x008F692E
		public unsafe USplineComponent Spline
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USplineComponent>(base.NativePtr / (IntPtr)sizeof(void*) + Rain_Drip_Spline_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + Rain_Drip_Spline_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17002B5D RID: 11101
		// (get) Token: 0x0601E947 RID: 125255 RVA: 0x008F8743 File Offset: 0x008F6943
		// (set) Token: 0x0601E948 RID: 125256 RVA: 0x008F8757 File Offset: 0x008F6957
		public unsafe USceneComponent Floor
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + Rain_Drip_Spline_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + Rain_Drip_Spline_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17002B5E RID: 11102
		// (get) Token: 0x0601E949 RID: 125257 RVA: 0x008F876C File Offset: 0x008F696C
		// (set) Token: 0x0601E94A RID: 125258 RVA: 0x008F8780 File Offset: 0x008F6980
		public unsafe USceneComponent End_Point
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + Rain_Drip_Spline_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + Rain_Drip_Spline_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17002B5F RID: 11103
		// (get) Token: 0x0601E94B RID: 125259 RVA: 0x008F8795 File Offset: 0x008F6995
		// (set) Token: 0x0601E94C RID: 125260 RVA: 0x008F87A9 File Offset: 0x008F69A9
		public unsafe UNiagaraComponent Dripping_Curve
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraComponent>(base.NativePtr / (IntPtr)sizeof(void*) + Rain_Drip_Spline_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + Rain_Drip_Spline_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17002B60 RID: 11104
		// (get) Token: 0x0601E94D RID: 125261 RVA: 0x008F87BE File Offset: 0x008F69BE
		// (set) Token: 0x0601E94E RID: 125262 RVA: 0x008F87D2 File Offset: 0x008F69D2
		public unsafe UBillboardComponent Root
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBillboardComponent>(base.NativePtr / (IntPtr)sizeof(void*) + Rain_Drip_Spline_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + Rain_Drip_Spline_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x17002B61 RID: 11105
		// (get) Token: 0x0601E94F RID: 125263 RVA: 0x008F87E7 File Offset: 0x008F69E7
		// (set) Token: 0x0601E950 RID: 125264 RVA: 0x008F87F7 File Offset: 0x008F69F7
		public unsafe bool Refresh
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Rain_Drip_Spline_C.__PropertyOffset_6) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)Rain_Drip_Spline_C.__PropertyOffset_6) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002B62 RID: 11106
		// (get) Token: 0x0601E951 RID: 125265 RVA: 0x008F8808 File Offset: 0x008F6A08
		// (set) Token: 0x0601E952 RID: 125266 RVA: 0x008F8818 File Offset: 0x008F6A18
		public unsafe float Spawn_Rate_Per_Meter
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Rain_Drip_Spline_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Rain_Drip_Spline_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17002B63 RID: 11107
		// (get) Token: 0x0601E953 RID: 125267 RVA: 0x008F8829 File Offset: 0x008F6A29
		// (set) Token: 0x0601E954 RID: 125268 RVA: 0x008F8839 File Offset: 0x008F6A39
		public unsafe float Additional_Spawn_Rate
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Rain_Drip_Spline_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Rain_Drip_Spline_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17002B64 RID: 11108
		// (get) Token: 0x0601E955 RID: 125269 RVA: 0x008F884A File Offset: 0x008F6A4A
		// (set) Token: 0x0601E956 RID: 125270 RVA: 0x008F885A File Offset: 0x008F6A5A
		public unsafe float Splash_Frequency
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Rain_Drip_Spline_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Rain_Drip_Spline_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17002B65 RID: 11109
		// (get) Token: 0x0601E957 RID: 125271 RVA: 0x008F886C File Offset: 0x008F6A6C
		// (set) Token: 0x0601E958 RID: 125272 RVA: 0x008F88A5 File Offset: 0x008F6AA5
		[Nullable(new byte[]
		{
			1,
			0
		})]
		public TArray<TEnumAsByte<EObjectTypeQuery>> Collision_Object_Types
		{
			[return: Nullable(new byte[]
			{
				1,
				0
			})]
			get
			{
				base.FastCheckIsValid();
				TArray<TEnumAsByte<EObjectTypeQuery>> result;
				if ((result = this._Collision_Object_Types) == null)
				{
					result = (this._Collision_Object_Types = new TArray<TEnumAsByte<EObjectTypeQuery>>(base.NativePtr + (IntPtr)Rain_Drip_Spline_C.__PropertyOffset_10, this));
				}
				return result;
			}
			[param: Nullable(new byte[]
			{
				1,
				0
			})]
			set
			{
				this.Collision_Object_Types.CopyAssign(value);
			}
		}

		// Token: 0x17002B66 RID: 11110
		// (get) Token: 0x0601E959 RID: 125273 RVA: 0x008F88B4 File Offset: 0x008F6AB4
		// (set) Token: 0x0601E95A RID: 125274 RVA: 0x008F88ED File Offset: 0x008F6AED
		[Nullable(1)]
		public TArray<AActor> Collision_Actors_to_Ignore
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<AActor> result;
				if ((result = this._Collision_Actors_to_Ignore) == null)
				{
					result = (this._Collision_Actors_to_Ignore = new TArray<AActor>(base.NativePtr + (IntPtr)Rain_Drip_Spline_C.__PropertyOffset_11, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.Collision_Actors_to_Ignore.CopyAssign(value);
			}
		}

		// Token: 0x17002B67 RID: 11111
		// (get) Token: 0x0601E95B RID: 125275 RVA: 0x008F88FB File Offset: 0x008F6AFB
		// (set) Token: 0x0601E95C RID: 125276 RVA: 0x008F890B File Offset: 0x008F6B0B
		public unsafe float Collision_Line_Trace_Head_Start
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Rain_Drip_Spline_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Rain_Drip_Spline_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17002B68 RID: 11112
		// (get) Token: 0x0601E95D RID: 125277 RVA: 0x008F891C File Offset: 0x008F6B1C
		// (set) Token: 0x0601E95E RID: 125278 RVA: 0x008F892C File Offset: 0x008F6B2C
		public unsafe float Point_Spacing
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Rain_Drip_Spline_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Rain_Drip_Spline_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x17002B69 RID: 11113
		// (get) Token: 0x0601E95F RID: 125279 RVA: 0x008F893D File Offset: 0x008F6B3D
		// (set) Token: 0x0601E960 RID: 125280 RVA: 0x008F894D File Offset: 0x008F6B4D
		public unsafe float Curl_Noise_Force
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Rain_Drip_Spline_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Rain_Drip_Spline_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x17002B6A RID: 11114
		// (get) Token: 0x0601E961 RID: 125281 RVA: 0x008F895E File Offset: 0x008F6B5E
		// (set) Token: 0x0601E962 RID: 125282 RVA: 0x008F896E File Offset: 0x008F6B6E
		public unsafe bool Update_Collision_Regularly
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Rain_Drip_Spline_C.__PropertyOffset_15) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)Rain_Drip_Spline_C.__PropertyOffset_15) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002B6B RID: 11115
		// (get) Token: 0x0601E963 RID: 125283 RVA: 0x008F897F File Offset: 0x008F6B7F
		// (set) Token: 0x0601E964 RID: 125284 RVA: 0x008F898F File Offset: 0x008F6B8F
		public unsafe bool Runtime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Rain_Drip_Spline_C.__PropertyOffset_16) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)Rain_Drip_Spline_C.__PropertyOffset_16) = (value ? 1 : 0);
			}
		}

		// Token: 0x0601E965 RID: 125285 RVA: 0x008F89A0 File Offset: 0x008F6BA0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Create_Curve_Data()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, Rain_Drip_Spline_C.__Create_Curve_Data_NativeFunctionPtr, null);
		}

		// Token: 0x0601E966 RID: 125286 RVA: 0x008F89B4 File Offset: 0x008F6BB4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Update_with_Weather()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, Rain_Drip_Spline_C.__Update_with_Weather_NativeFunctionPtr, null);
		}

		// Token: 0x0601E967 RID: 125287 RVA: 0x008F89C8 File Offset: 0x008F6BC8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, Rain_Drip_Spline_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x0601E968 RID: 125288 RVA: 0x008F89DC File Offset: 0x008F6BDC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, Rain_Drip_Spline_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601E969 RID: 125289 RVA: 0x008F89F1 File Offset: 0x008F6BF1
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Editor_Update()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, Rain_Drip_Spline_C.__Editor_Update_NativeFunctionPtr, null);
		}

		// Token: 0x0601E96A RID: 125290 RVA: 0x008F8A08 File Offset: 0x008F6C08
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			Rain_Drip_Spline_C.__ReceiveTick_FunctionParams* ptr = stackalloc Rain_Drip_Spline_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(Rain_Drip_Spline_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(Rain_Drip_Spline_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, Rain_Drip_Spline_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601E96B RID: 125291 RVA: 0x008F8A50 File Offset: 0x008F6C50
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			Rain_Drip_Spline_C.__ReceiveTick_FunctionParams* ptr = stackalloc Rain_Drip_Spline_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(Rain_Drip_Spline_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(Rain_Drip_Spline_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, Rain_Drip_Spline_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601E96C RID: 125292 RVA: 0x008F8A97 File Offset: 0x008F6C97
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, Rain_Drip_Spline_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0601E96D RID: 125293 RVA: 0x008F8AAB File Offset: 0x008F6CAB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, Rain_Drip_Spline_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601E96E RID: 125294 RVA: 0x008F8AC0 File Offset: 0x008F6CC0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Reset_Emitters()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, Rain_Drip_Spline_C.__Reset_Emitters_NativeFunctionPtr, null);
		}

		// Token: 0x0601E96F RID: 125295 RVA: 0x008F8AD4 File Offset: 0x008F6CD4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_Rain_Drip_Spline(int EntryPoint)
		{
			Rain_Drip_Spline_C.__ExecuteUbergraph_Rain_Drip_Spline_FunctionParams* ptr = stackalloc Rain_Drip_Spline_C.__ExecuteUbergraph_Rain_Drip_Spline_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(Rain_Drip_Spline_C.__ExecuteUbergraph_Rain_Drip_Spline_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(Rain_Drip_Spline_C.__ExecuteUbergraph_Rain_Drip_Spline_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, Rain_Drip_Spline_C.__ExecuteUbergraph_Rain_Drip_Spline_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601E970 RID: 125296 RVA: 0x008F8B1B File Offset: 0x008F6D1B
		protected Rain_Drip_Spline_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400F0E5 RID: 61669
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/UltraDynamicSky/Blueprints/Weather_Effects/Rain_Drip_Spline.Rain_Drip_Spline_C";

		// Token: 0x0400F0E6 RID: 61670
		private static IntPtr _ClassPtr;

		// Token: 0x0400F0E7 RID: 61671
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400F0E8 RID: 61672
		internal static int __PropertyOffset_0;

		// Token: 0x0400F0E9 RID: 61673
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400F0EA RID: 61674
		internal static int __PropertyOffset_1;

		// Token: 0x0400F0EB RID: 61675
		internal static int __PropertyOffset_2;

		// Token: 0x0400F0EC RID: 61676
		internal static int __PropertyOffset_3;

		// Token: 0x0400F0ED RID: 61677
		internal static int __PropertyOffset_4;

		// Token: 0x0400F0EE RID: 61678
		internal static int __PropertyOffset_5;

		// Token: 0x0400F0EF RID: 61679
		internal static int __PropertyOffset_6;

		// Token: 0x0400F0F0 RID: 61680
		internal static int __PropertyOffset_7;

		// Token: 0x0400F0F1 RID: 61681
		internal static int __PropertyOffset_8;

		// Token: 0x0400F0F2 RID: 61682
		internal static int __PropertyOffset_9;

		// Token: 0x0400F0F3 RID: 61683
		internal static int __PropertyOffset_10;

		// Token: 0x0400F0F4 RID: 61684
		[Nullable(new byte[]
		{
			2,
			0
		})]
		private TArray<TEnumAsByte<EObjectTypeQuery>> _Collision_Object_Types;

		// Token: 0x0400F0F5 RID: 61685
		internal static int __PropertyOffset_11;

		// Token: 0x0400F0F6 RID: 61686
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<AActor> _Collision_Actors_to_Ignore;

		// Token: 0x0400F0F7 RID: 61687
		internal static int __PropertyOffset_12;

		// Token: 0x0400F0F8 RID: 61688
		internal static int __PropertyOffset_13;

		// Token: 0x0400F0F9 RID: 61689
		internal static int __PropertyOffset_14;

		// Token: 0x0400F0FA RID: 61690
		internal static int __PropertyOffset_15;

		// Token: 0x0400F0FB RID: 61691
		internal static int __PropertyOffset_16;

		// Token: 0x0400F0FC RID: 61692
		private static IntPtr __Create_Curve_Data_NativeFunctionPtr;

		// Token: 0x0400F0FD RID: 61693
		private static IntPtr __Update_with_Weather_NativeFunctionPtr;

		// Token: 0x0400F0FE RID: 61694
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x0400F0FF RID: 61695
		private static IntPtr __Editor_Update_NativeFunctionPtr;

		// Token: 0x0400F100 RID: 61696
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0400F101 RID: 61697
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0400F102 RID: 61698
		private static IntPtr __Reset_Emitters_NativeFunctionPtr;

		// Token: 0x0400F103 RID: 61699
		private static IntPtr __ExecuteUbergraph_Rain_Drip_Spline_NativeFunctionPtr;

		// Token: 0x020097C2 RID: 38850
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04031DA7 RID: 204199
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x020097C3 RID: 38851
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __ExecuteUbergraph_Rain_Drip_Spline_FunctionParams
		{
			// Token: 0x04031DA8 RID: 204200
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
