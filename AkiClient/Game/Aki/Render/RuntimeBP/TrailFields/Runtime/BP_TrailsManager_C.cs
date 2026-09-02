using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Render.RuntimeBP.TrailFields.Runtime.Sensors;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.TrailFields.Runtime
{
	// Token: 0x02003A2B RID: 14891
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/TrailFields/Runtime/BP_TrailsManager.BP_TrailsManager_C")]
	[UnrealStructLayout(1224, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1218)]
	public class BP_TrailsManager_C : AKuroHighResLandscapeActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601EA4D RID: 125517 RVA: 0x008FA6D8 File Offset: 0x008F88D8
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_TrailsManager_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/TrailFields/Runtime/BP_TrailsManager.BP_TrailsManager_C");
			}
			return BP_TrailsManager_C._ClassPtr;
		}

		// Token: 0x0601EA4E RID: 125518 RVA: 0x008FA6FC File Offset: 0x008F88FC
		public BP_TrailsManager_C() : this(BuiltinUtils.AllocNativeUObject(BP_TrailsManager_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601EA4F RID: 125519 RVA: 0x008FA724 File Offset: 0x008F8924
		public BP_TrailsManager_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_TrailsManager_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17002BAB RID: 11179
		// (get) Token: 0x0601EA50 RID: 125520 RVA: 0x008FA758 File Offset: 0x008F8958
		// (set) Token: 0x0601EA51 RID: 125521 RVA: 0x008FA791 File Offset: 0x008F8991
		public FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_TrailsManager_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_TrailsManager_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17002BAC RID: 11180
		// (get) Token: 0x0601EA52 RID: 125522 RVA: 0x008FA7B2 File Offset: 0x008F89B2
		// (set) Token: 0x0601EA53 RID: 125523 RVA: 0x008FA7C6 File Offset: 0x008F89C6
		[Nullable(2)]
		public unsafe UBillboardComponent Billboard
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBillboardComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_TrailsManager_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_TrailsManager_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17002BAD RID: 11181
		// (get) Token: 0x0601EA54 RID: 125524 RVA: 0x008FA7DB File Offset: 0x008F89DB
		// (set) Token: 0x0601EA55 RID: 125525 RVA: 0x008FA7EF File Offset: 0x008F89EF
		[Nullable(2)]
		public unsafe USceneComponent DefaultSceneRoot
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_TrailsManager_C.__PropertyOffset_2);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_TrailsManager_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17002BAE RID: 11182
		// (get) Token: 0x0601EA56 RID: 125526 RVA: 0x008FA804 File Offset: 0x008F8A04
		// (set) Token: 0x0601EA57 RID: 125527 RVA: 0x008FA83D File Offset: 0x008F8A3D
		public TArray<BP_TrailDrawComponent_C> Drawers
		{
			get
			{
				base.FastCheckIsValid();
				TArray<BP_TrailDrawComponent_C> result;
				if ((result = this._Drawers) == null)
				{
					result = (this._Drawers = new TArray<BP_TrailDrawComponent_C>(base.NativePtr + (IntPtr)BP_TrailsManager_C.__PropertyOffset_3, this));
				}
				return result;
			}
			set
			{
				this.Drawers.CopyAssign(value);
			}
		}

		// Token: 0x17002BAF RID: 11183
		// (get) Token: 0x0601EA58 RID: 125528 RVA: 0x008FA84C File Offset: 0x008F8A4C
		// (set) Token: 0x0601EA59 RID: 125529 RVA: 0x008FA885 File Offset: 0x008F8A85
		public TArray<BP_TrailSensorActor_C> TrailFields
		{
			get
			{
				base.FastCheckIsValid();
				TArray<BP_TrailSensorActor_C> result;
				if ((result = this._TrailFields) == null)
				{
					result = (this._TrailFields = new TArray<BP_TrailSensorActor_C>(base.NativePtr + (IntPtr)BP_TrailsManager_C.__PropertyOffset_4, this));
				}
				return result;
			}
			set
			{
				this.TrailFields.CopyAssign(value);
			}
		}

		// Token: 0x17002BB0 RID: 11184
		// (get) Token: 0x0601EA5A RID: 125530 RVA: 0x008FA893 File Offset: 0x008F8A93
		// (set) Token: 0x0601EA5B RID: 125531 RVA: 0x008FA8A7 File Offset: 0x008F8AA7
		public unsafe FVector2D Position
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TrailsManager_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_TrailsManager_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17002BB1 RID: 11185
		// (get) Token: 0x0601EA5C RID: 125532 RVA: 0x008FA8BC File Offset: 0x008F8ABC
		// (set) Token: 0x0601EA5D RID: 125533 RVA: 0x008FA8CC File Offset: 0x008F8ACC
		public unsafe float Rotation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TrailsManager_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_TrailsManager_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17002BB2 RID: 11186
		// (get) Token: 0x0601EA5E RID: 125534 RVA: 0x008FA8DD File Offset: 0x008F8ADD
		// (set) Token: 0x0601EA5F RID: 125535 RVA: 0x008FA8F1 File Offset: 0x008F8AF1
		public unsafe FVector2D DrawSize
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TrailsManager_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_TrailsManager_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17002BB3 RID: 11187
		// (get) Token: 0x0601EA60 RID: 125536 RVA: 0x008FA908 File Offset: 0x008F8B08
		// (set) Token: 0x0601EA61 RID: 125537 RVA: 0x008FA941 File Offset: 0x008F8B41
		public TArray<STrailDrawInfo> DrawInfo
		{
			get
			{
				base.FastCheckIsValid();
				TArray<STrailDrawInfo> result;
				if ((result = this._DrawInfo) == null)
				{
					result = (this._DrawInfo = new TArray<STrailDrawInfo>(base.NativePtr + (IntPtr)BP_TrailsManager_C.__PropertyOffset_8, this));
				}
				return result;
			}
			set
			{
				this.DrawInfo.CopyAssign(value);
			}
		}

		// Token: 0x17002BB4 RID: 11188
		// (get) Token: 0x0601EA62 RID: 125538 RVA: 0x008FA94F File Offset: 0x008F8B4F
		// (set) Token: 0x0601EA63 RID: 125539 RVA: 0x008FA95F File Offset: 0x008F8B5F
		public unsafe bool ShouldDraw
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TrailsManager_C.__PropertyOffset_9) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_TrailsManager_C.__PropertyOffset_9) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002BB5 RID: 11189
		// (get) Token: 0x0601EA64 RID: 125540 RVA: 0x008FA970 File Offset: 0x008F8B70
		// (set) Token: 0x0601EA65 RID: 125541 RVA: 0x008FA980 File Offset: 0x008F8B80
		public unsafe float PixelWidth_Save
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TrailsManager_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_TrailsManager_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17002BB6 RID: 11190
		// (get) Token: 0x0601EA66 RID: 125542 RVA: 0x008FA991 File Offset: 0x008F8B91
		// (set) Token: 0x0601EA67 RID: 125543 RVA: 0x008FA9A1 File Offset: 0x008F8BA1
		public unsafe float PixelWidth_Blur
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TrailsManager_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_TrailsManager_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17002BB7 RID: 11191
		// (get) Token: 0x0601EA68 RID: 125544 RVA: 0x008FA9B2 File Offset: 0x008F8BB2
		// (set) Token: 0x0601EA69 RID: 125545 RVA: 0x008FA9C2 File Offset: 0x008F8BC2
		public unsafe float EdgeWidth
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TrailsManager_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_TrailsManager_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17002BB8 RID: 11192
		// (get) Token: 0x0601EA6A RID: 125546 RVA: 0x008FA9D3 File Offset: 0x008F8BD3
		// (set) Token: 0x0601EA6B RID: 125547 RVA: 0x008FA9E3 File Offset: 0x008F8BE3
		public unsafe float BlurWidth
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TrailsManager_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_TrailsManager_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x17002BB9 RID: 11193
		// (get) Token: 0x0601EA6C RID: 125548 RVA: 0x008FA9F4 File Offset: 0x008F8BF4
		// (set) Token: 0x0601EA6D RID: 125549 RVA: 0x008FAA04 File Offset: 0x008F8C04
		public unsafe float PixelWidth_Capture
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TrailsManager_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_TrailsManager_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x17002BBA RID: 11194
		// (get) Token: 0x0601EA6E RID: 125550 RVA: 0x008FAA18 File Offset: 0x008F8C18
		// (set) Token: 0x0601EA6F RID: 125551 RVA: 0x008FAA51 File Offset: 0x008F8C51
		public TArray<BP_TrailSensorActor_C> TrailFields_NeedRemove
		{
			get
			{
				base.FastCheckIsValid();
				TArray<BP_TrailSensorActor_C> result;
				if ((result = this._TrailFields_NeedRemove) == null)
				{
					result = (this._TrailFields_NeedRemove = new TArray<BP_TrailSensorActor_C>(base.NativePtr + (IntPtr)BP_TrailsManager_C.__PropertyOffset_15, this));
				}
				return result;
			}
			set
			{
				this.TrailFields_NeedRemove.CopyAssign(value);
			}
		}

		// Token: 0x17002BBB RID: 11195
		// (get) Token: 0x0601EA70 RID: 125552 RVA: 0x008FAA5F File Offset: 0x008F8C5F
		// (set) Token: 0x0601EA71 RID: 125553 RVA: 0x008FAA6F File Offset: 0x008F8C6F
		public unsafe bool DebugLog
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TrailsManager_C.__PropertyOffset_16) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_TrailsManager_C.__PropertyOffset_16) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002BBC RID: 11196
		// (get) Token: 0x0601EA72 RID: 125554 RVA: 0x008FAA80 File Offset: 0x008F8C80
		// (set) Token: 0x0601EA73 RID: 125555 RVA: 0x008FAA90 File Offset: 0x008F8C90
		public unsafe bool ActiveHighResLandscape
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TrailsManager_C.__PropertyOffset_17) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_TrailsManager_C.__PropertyOffset_17) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002BBD RID: 11197
		// (get) Token: 0x0601EA74 RID: 125556 RVA: 0x008FAAA4 File Offset: 0x008F8CA4
		// (set) Token: 0x0601EA75 RID: 125557 RVA: 0x008FAADD File Offset: 0x008F8CDD
		public TArray<ALandscapeStreamingProxy> LowLandscapes
		{
			get
			{
				base.FastCheckIsValid();
				TArray<ALandscapeStreamingProxy> result;
				if ((result = this._LowLandscapes) == null)
				{
					result = (this._LowLandscapes = new TArray<ALandscapeStreamingProxy>(base.NativePtr + (IntPtr)BP_TrailsManager_C.__PropertyOffset_18, this));
				}
				return result;
			}
			set
			{
				this.LowLandscapes.CopyAssign(value);
			}
		}

		// Token: 0x17002BBE RID: 11198
		// (get) Token: 0x0601EA76 RID: 125558 RVA: 0x008FAAEC File Offset: 0x008F8CEC
		// (set) Token: 0x0601EA77 RID: 125559 RVA: 0x008FAB25 File Offset: 0x008F8D25
		public TArray<ALandscapeStreamingProxy> HighLandscapes
		{
			get
			{
				base.FastCheckIsValid();
				TArray<ALandscapeStreamingProxy> result;
				if ((result = this._HighLandscapes) == null)
				{
					result = (this._HighLandscapes = new TArray<ALandscapeStreamingProxy>(base.NativePtr + (IntPtr)BP_TrailsManager_C.__PropertyOffset_19, this));
				}
				return result;
			}
			set
			{
				this.HighLandscapes.CopyAssign(value);
			}
		}

		// Token: 0x17002BBF RID: 11199
		// (get) Token: 0x0601EA78 RID: 125560 RVA: 0x008FAB33 File Offset: 0x008F8D33
		// (set) Token: 0x0601EA79 RID: 125561 RVA: 0x008FAB43 File Offset: 0x008F8D43
		public unsafe bool LandscapeDirty
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TrailsManager_C.__PropertyOffset_20) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_TrailsManager_C.__PropertyOffset_20) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002BC0 RID: 11200
		// (get) Token: 0x0601EA7A RID: 125562 RVA: 0x008FAB54 File Offset: 0x008F8D54
		// (set) Token: 0x0601EA7B RID: 125563 RVA: 0x008FAB64 File Offset: 0x008F8D64
		public unsafe bool Old_Enabled
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TrailsManager_C.__PropertyOffset_21) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_TrailsManager_C.__PropertyOffset_21) = (value ? 1 : 0);
			}
		}

		// Token: 0x0601EA7C RID: 125564 RVA: 0x008FAB75 File Offset: 0x008F8D75
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void test()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_TrailsManager_C.__test_NativeFunctionPtr, null);
		}

		// Token: 0x0601EA7D RID: 125565 RVA: 0x008FAB89 File Offset: 0x008F8D89
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateLandscapes()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_TrailsManager_C.__UpdateLandscapes_NativeFunctionPtr, null);
		}

		// Token: 0x0601EA7E RID: 125566 RVA: 0x008FABA0 File Offset: 0x008F8DA0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetTag([Nullable(2)] ALandscapeStreamingProxy Proxy, int Index, ref string Tag)
		{
			BP_TrailsManager_C.__GetTag_FunctionParams* ptr = stackalloc BP_TrailsManager_C.__GetTag_FunctionParams[(UIntPtr)79] + 15L / (long)sizeof(BP_TrailsManager_C.__GetTag_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_TrailsManager_C.__GetTag_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Proxy = ((Proxy != null) ? Proxy.NativePtr : IntPtr.Zero);
			ptr->Index = Index;
			FString.CopyFrom((void*)(&ptr->Tag), Tag);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_TrailsManager_C.__GetTag_NativeFunctionPtr, (void*)ptr);
			Tag = FString.ToString((void*)(&ptr->Tag));
			UnrealReflectionUtils.DestroyStruct(BP_TrailsManager_C.__GetTag_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0601EA7F RID: 125567 RVA: 0x008FAC2C File Offset: 0x008F8E2C
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void ContainsTag(ALandscapeStreamingProxy Actor, FName Str, ref bool Ret, ref int Index)
		{
			BP_TrailsManager_C.__ContainsTag_FunctionParams* ptr = stackalloc BP_TrailsManager_C.__ContainsTag_FunctionParams[(UIntPtr)119] + 15L / (long)sizeof(BP_TrailsManager_C.__ContainsTag_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_TrailsManager_C.__ContainsTag_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Actor = ((Actor != null) ? Actor.NativePtr : IntPtr.Zero);
			ptr->Str = Str;
			ptr->Ret = Ret;
			ptr->Index = Index;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_TrailsManager_C.__ContainsTag_NativeFunctionPtr, (void*)ptr);
			Ret = ptr->Ret;
			Index = ptr->Index;
		}

		// Token: 0x0601EA80 RID: 125568 RVA: 0x008FACAC File Offset: 0x008F8EAC
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void HideProxy(ALandscapeStreamingProxy Proxy)
		{
			BP_TrailsManager_C.__HideProxy_FunctionParams* ptr = stackalloc BP_TrailsManager_C.__HideProxy_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_TrailsManager_C.__HideProxy_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_TrailsManager_C.__HideProxy_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Proxy = ((Proxy != null) ? Proxy.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_TrailsManager_C.__HideProxy_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601EA81 RID: 125569 RVA: 0x008FAD04 File Offset: 0x008F8F04
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void ShowProxy(ALandscapeStreamingProxy Proxy)
		{
			BP_TrailsManager_C.__ShowProxy_FunctionParams* ptr = stackalloc BP_TrailsManager_C.__ShowProxy_FunctionParams[(UIntPtr)55] + 15L / (long)sizeof(BP_TrailsManager_C.__ShowProxy_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_TrailsManager_C.__ShowProxy_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Proxy = ((Proxy != null) ? Proxy.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_TrailsManager_C.__ShowProxy_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601EA82 RID: 125570 RVA: 0x008FAD5C File Offset: 0x008F8F5C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void IsEnable(ref bool IsEnable)
		{
			BP_TrailsManager_C.__IsEnable_FunctionParams* ptr = stackalloc BP_TrailsManager_C.__IsEnable_FunctionParams[(UIntPtr)18] + 15L / (long)sizeof(BP_TrailsManager_C.__IsEnable_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_TrailsManager_C.__IsEnable_NativeFunctionPtr, (void*)ptr, 1);
			ptr->IsEnable = IsEnable;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_TrailsManager_C.__IsEnable_NativeFunctionPtr, (void*)ptr);
			IsEnable = ptr->IsEnable;
		}

		// Token: 0x0601EA83 RID: 125571 RVA: 0x008FADAC File Offset: 0x008F8FAC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_TrailsManager_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_TrailsManager_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_TrailsManager_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_TrailsManager_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_TrailsManager_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601EA84 RID: 125572 RVA: 0x008FADF4 File Offset: 0x008F8FF4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_TrailsManager_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_TrailsManager_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_TrailsManager_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_TrailsManager_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_TrailsManager_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601EA85 RID: 125573 RVA: 0x008FAE3B File Offset: 0x008F903B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_TrailsManager_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0601EA86 RID: 125574 RVA: 0x008FAE4F File Offset: 0x008F904F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_TrailsManager_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601EA87 RID: 125575 RVA: 0x008FAE64 File Offset: 0x008F9064
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void OnProxyShow(ALandscapeStreamingProxy Proxy)
		{
			BP_TrailsManager_C.__OnProxyShow_FunctionParams* ptr = stackalloc BP_TrailsManager_C.__OnProxyShow_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_TrailsManager_C.__OnProxyShow_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_TrailsManager_C.__OnProxyShow_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Proxy = ((Proxy != null) ? Proxy.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_TrailsManager_C.__OnProxyShow_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601EA88 RID: 125576 RVA: 0x008FAEBC File Offset: 0x008F90BC
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void OnProxyShow_Implementation(ALandscapeStreamingProxy Proxy)
		{
			BP_TrailsManager_C.__OnProxyShow_FunctionParams* ptr = stackalloc BP_TrailsManager_C.__OnProxyShow_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_TrailsManager_C.__OnProxyShow_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_TrailsManager_C.__OnProxyShow_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Proxy = ((Proxy != null) ? Proxy.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_TrailsManager_C.__OnProxyShow_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601EA89 RID: 125577 RVA: 0x008FAF14 File Offset: 0x008F9114
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void OnProxyHide(ALandscapeStreamingProxy Proxy)
		{
			BP_TrailsManager_C.__OnProxyHide_FunctionParams* ptr = stackalloc BP_TrailsManager_C.__OnProxyHide_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_TrailsManager_C.__OnProxyHide_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_TrailsManager_C.__OnProxyHide_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Proxy = ((Proxy != null) ? Proxy.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_TrailsManager_C.__OnProxyHide_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601EA8A RID: 125578 RVA: 0x008FAF6C File Offset: 0x008F916C
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void OnProxyHide_Implementation(ALandscapeStreamingProxy Proxy)
		{
			BP_TrailsManager_C.__OnProxyHide_FunctionParams* ptr = stackalloc BP_TrailsManager_C.__OnProxyHide_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_TrailsManager_C.__OnProxyHide_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_TrailsManager_C.__OnProxyHide_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Proxy = ((Proxy != null) ? Proxy.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_TrailsManager_C.__OnProxyHide_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601EA8B RID: 125579 RVA: 0x008FAFC4 File Offset: 0x008F91C4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_TrailsManager(int EntryPoint)
		{
			BP_TrailsManager_C.__ExecuteUbergraph_BP_TrailsManager_FunctionParams* ptr = stackalloc BP_TrailsManager_C.__ExecuteUbergraph_BP_TrailsManager_FunctionParams[(UIntPtr)519] + 15L / (long)sizeof(BP_TrailsManager_C.__ExecuteUbergraph_BP_TrailsManager_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_TrailsManager_C.__ExecuteUbergraph_BP_TrailsManager_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_TrailsManager_C.__ExecuteUbergraph_BP_TrailsManager_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601EA8C RID: 125580 RVA: 0x008FB00E File Offset: 0x008F920E
		protected BP_TrailsManager_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400F1C8 RID: 61896
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/TrailFields/Runtime/BP_TrailsManager.BP_TrailsManager_C";

		// Token: 0x0400F1C9 RID: 61897
		private static IntPtr _ClassPtr;

		// Token: 0x0400F1CA RID: 61898
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400F1CB RID: 61899
		internal static int __PropertyOffset_0;

		// Token: 0x0400F1CC RID: 61900
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400F1CD RID: 61901
		internal static int __PropertyOffset_1;

		// Token: 0x0400F1CE RID: 61902
		internal static int __PropertyOffset_2;

		// Token: 0x0400F1CF RID: 61903
		internal static int __PropertyOffset_3;

		// Token: 0x0400F1D0 RID: 61904
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<BP_TrailDrawComponent_C> _Drawers;

		// Token: 0x0400F1D1 RID: 61905
		internal static int __PropertyOffset_4;

		// Token: 0x0400F1D2 RID: 61906
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<BP_TrailSensorActor_C> _TrailFields;

		// Token: 0x0400F1D3 RID: 61907
		internal static int __PropertyOffset_5;

		// Token: 0x0400F1D4 RID: 61908
		internal static int __PropertyOffset_6;

		// Token: 0x0400F1D5 RID: 61909
		internal static int __PropertyOffset_7;

		// Token: 0x0400F1D6 RID: 61910
		internal static int __PropertyOffset_8;

		// Token: 0x0400F1D7 RID: 61911
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<STrailDrawInfo> _DrawInfo;

		// Token: 0x0400F1D8 RID: 61912
		internal static int __PropertyOffset_9;

		// Token: 0x0400F1D9 RID: 61913
		internal static int __PropertyOffset_10;

		// Token: 0x0400F1DA RID: 61914
		internal static int __PropertyOffset_11;

		// Token: 0x0400F1DB RID: 61915
		internal static int __PropertyOffset_12;

		// Token: 0x0400F1DC RID: 61916
		internal static int __PropertyOffset_13;

		// Token: 0x0400F1DD RID: 61917
		internal static int __PropertyOffset_14;

		// Token: 0x0400F1DE RID: 61918
		internal static int __PropertyOffset_15;

		// Token: 0x0400F1DF RID: 61919
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<BP_TrailSensorActor_C> _TrailFields_NeedRemove;

		// Token: 0x0400F1E0 RID: 61920
		internal static int __PropertyOffset_16;

		// Token: 0x0400F1E1 RID: 61921
		internal static int __PropertyOffset_17;

		// Token: 0x0400F1E2 RID: 61922
		internal static int __PropertyOffset_18;

		// Token: 0x0400F1E3 RID: 61923
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<ALandscapeStreamingProxy> _LowLandscapes;

		// Token: 0x0400F1E4 RID: 61924
		internal static int __PropertyOffset_19;

		// Token: 0x0400F1E5 RID: 61925
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<ALandscapeStreamingProxy> _HighLandscapes;

		// Token: 0x0400F1E6 RID: 61926
		internal static int __PropertyOffset_20;

		// Token: 0x0400F1E7 RID: 61927
		internal static int __PropertyOffset_21;

		// Token: 0x0400F1E8 RID: 61928
		private static IntPtr __test_NativeFunctionPtr;

		// Token: 0x0400F1E9 RID: 61929
		private static IntPtr __UpdateLandscapes_NativeFunctionPtr;

		// Token: 0x0400F1EA RID: 61930
		private static IntPtr __GetTag_NativeFunctionPtr;

		// Token: 0x0400F1EB RID: 61931
		private static IntPtr __ContainsTag_NativeFunctionPtr;

		// Token: 0x0400F1EC RID: 61932
		private static IntPtr __HideProxy_NativeFunctionPtr;

		// Token: 0x0400F1ED RID: 61933
		private static IntPtr __ShowProxy_NativeFunctionPtr;

		// Token: 0x0400F1EE RID: 61934
		private static IntPtr __IsEnable_NativeFunctionPtr;

		// Token: 0x0400F1EF RID: 61935
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0400F1F0 RID: 61936
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0400F1F1 RID: 61937
		private static IntPtr __OnProxyShow_NativeFunctionPtr;

		// Token: 0x0400F1F2 RID: 61938
		private static IntPtr __OnProxyHide_NativeFunctionPtr;

		// Token: 0x0400F1F3 RID: 61939
		private static IntPtr __ExecuteUbergraph_BP_TrailsManager_NativeFunctionPtr;

		// Token: 0x020097DB RID: 38875
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 64)]
		protected ref struct __GetTag_FunctionParams
		{
			// Token: 0x04031DC8 RID: 204232
			[FieldOffset(0)]
			public IntPtr Proxy;

			// Token: 0x04031DC9 RID: 204233
			[FieldOffset(8)]
			public int Index;

			// Token: 0x04031DCA RID: 204234
			[FieldOffset(16)]
			public FString Tag;
		}

		// Token: 0x020097DC RID: 38876
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 104)]
		protected ref struct __ContainsTag_FunctionParams
		{
			// Token: 0x04031DCB RID: 204235
			[FieldOffset(0)]
			public IntPtr Actor;

			// Token: 0x04031DCC RID: 204236
			[FieldOffset(8)]
			public FName Str;

			// Token: 0x04031DCD RID: 204237
			[FieldOffset(20)]
			public bool Ret;

			// Token: 0x04031DCE RID: 204238
			[FieldOffset(24)]
			public int Index;
		}

		// Token: 0x020097DD RID: 38877
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __HideProxy_FunctionParams
		{
			// Token: 0x04031DCF RID: 204239
			[FieldOffset(0)]
			public IntPtr Proxy;
		}

		// Token: 0x020097DE RID: 38878
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 40)]
		protected ref struct __ShowProxy_FunctionParams
		{
			// Token: 0x04031DD0 RID: 204240
			[FieldOffset(0)]
			public IntPtr Proxy;
		}

		// Token: 0x020097DF RID: 38879
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 3)]
		protected ref struct __IsEnable_FunctionParams
		{
			// Token: 0x04031DD1 RID: 204241
			[FieldOffset(0)]
			public bool IsEnable;
		}

		// Token: 0x020097E0 RID: 38880
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04031DD2 RID: 204242
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x020097E1 RID: 38881
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected new ref struct __OnProxyShow_FunctionParams
		{
			// Token: 0x04031DD3 RID: 204243
			[FieldOffset(0)]
			public IntPtr Proxy;
		}

		// Token: 0x020097E2 RID: 38882
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected new ref struct __OnProxyHide_FunctionParams
		{
			// Token: 0x04031DD4 RID: 204244
			[FieldOffset(0)]
			public IntPtr Proxy;
		}

		// Token: 0x020097E3 RID: 38883
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 504)]
		protected ref struct __ExecuteUbergraph_BP_TrailsManager_FunctionParams
		{
			// Token: 0x04031DD5 RID: 204245
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
