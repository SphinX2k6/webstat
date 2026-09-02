using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Render.RuntimeBP.ScreenEffect.Data;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Rain2
{
	// Token: 0x02003B3F RID: 15167
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Rain2/BP_WorldRainComponent_Common.BP_WorldRainComponent_Common_C")]
	[UnrealStructLayout(880, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 872)]
	public class BP_WorldRainComponent_Common_C : UKuroWorldRainComponent, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06020D97 RID: 134551 RVA: 0x0093895F File Offset: 0x00936B5F
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_WorldRainComponent_Common_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Rain2/BP_WorldRainComponent_Common.BP_WorldRainComponent_Common_C");
			}
			return BP_WorldRainComponent_Common_C._ClassPtr;
		}

		// Token: 0x06020D98 RID: 134552 RVA: 0x00938984 File Offset: 0x00936B84
		public BP_WorldRainComponent_Common_C() : this(BuiltinUtils.AllocNativeUObject(BP_WorldRainComponent_Common_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06020D99 RID: 134553 RVA: 0x009389AC File Offset: 0x00936BAC
		public BP_WorldRainComponent_Common_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_WorldRainComponent_Common_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700379A RID: 14234
		// (get) Token: 0x06020D9A RID: 134554 RVA: 0x009389E0 File Offset: 0x00936BE0
		// (set) Token: 0x06020D9B RID: 134555 RVA: 0x00938A19 File Offset: 0x00936C19
		public FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_WorldRainComponent_Common_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_WorldRainComponent_Common_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700379B RID: 14235
		// (get) Token: 0x06020D9C RID: 134556 RVA: 0x00938A3A File Offset: 0x00936C3A
		// (set) Token: 0x06020D9D RID: 134557 RVA: 0x00938A4E File Offset: 0x00936C4E
		[Nullable(2)]
		public unsafe UClusteredStuffDataAsset ClusteredStuff
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UClusteredStuffDataAsset>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WorldRainComponent_Common_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WorldRainComponent_Common_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x1700379C RID: 14236
		// (get) Token: 0x06020D9E RID: 134558 RVA: 0x00938A63 File Offset: 0x00936C63
		// (set) Token: 0x06020D9F RID: 134559 RVA: 0x00938A77 File Offset: 0x00936C77
		[Nullable(2)]
		public unsafe UAkAudioEvent AudioEvent
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UAkAudioEvent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WorldRainComponent_Common_C.__PropertyOffset_2);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WorldRainComponent_Common_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x1700379D RID: 14237
		// (get) Token: 0x06020DA0 RID: 134560 RVA: 0x00938A8C File Offset: 0x00936C8C
		// (set) Token: 0x06020DA1 RID: 134561 RVA: 0x00938AA0 File Offset: 0x00936CA0
		public unsafe string CommandOnStart
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)BP_WorldRainComponent_Common_C.__PropertyOffset_3)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)BP_WorldRainComponent_Common_C.__PropertyOffset_3)), value);
			}
		}

		// Token: 0x1700379E RID: 14238
		// (get) Token: 0x06020DA2 RID: 134562 RVA: 0x00938AB5 File Offset: 0x00936CB5
		// (set) Token: 0x06020DA3 RID: 134563 RVA: 0x00938AC9 File Offset: 0x00936CC9
		public unsafe string CommandOnDeactivate
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)BP_WorldRainComponent_Common_C.__PropertyOffset_4)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)BP_WorldRainComponent_Common_C.__PropertyOffset_4)), value);
			}
		}

		// Token: 0x1700379F RID: 14239
		// (get) Token: 0x06020DA4 RID: 134564 RVA: 0x00938ADE File Offset: 0x00936CDE
		// (set) Token: 0x06020DA5 RID: 134565 RVA: 0x00938AF2 File Offset: 0x00936CF2
		[Nullable(2)]
		public unsafe EffectScreenPlayData_C ScreenEffectToPlay
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<EffectScreenPlayData_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WorldRainComponent_Common_C.__PropertyOffset_5);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WorldRainComponent_Common_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x06020DA6 RID: 134566 RVA: 0x00938B07 File Offset: 0x00936D07
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void OnReceiveStartRain()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WorldRainComponent_Common_C.__OnReceiveStartRain_NativeFunctionPtr, null);
		}

		// Token: 0x06020DA7 RID: 134567 RVA: 0x00938B1B File Offset: 0x00936D1B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void OnReceiveStartRain_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_WorldRainComponent_Common_C.__OnReceiveStartRain_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06020DA8 RID: 134568 RVA: 0x00938B30 File Offset: 0x00936D30
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void OnReceiveDeactivateRain()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WorldRainComponent_Common_C.__OnReceiveDeactivateRain_NativeFunctionPtr, null);
		}

		// Token: 0x06020DA9 RID: 134569 RVA: 0x00938B44 File Offset: 0x00936D44
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void OnReceiveDeactivateRain_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_WorldRainComponent_Common_C.__OnReceiveDeactivateRain_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06020DAA RID: 134570 RVA: 0x00938B5C File Offset: 0x00936D5C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_WorldRainComponent_Common(int EntryPoint)
		{
			BP_WorldRainComponent_Common_C.__ExecuteUbergraph_BP_WorldRainComponent_Common_FunctionParams* ptr = stackalloc BP_WorldRainComponent_Common_C.__ExecuteUbergraph_BP_WorldRainComponent_Common_FunctionParams[(UIntPtr)111] + 15L / (long)sizeof(BP_WorldRainComponent_Common_C.__ExecuteUbergraph_BP_WorldRainComponent_Common_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WorldRainComponent_Common_C.__ExecuteUbergraph_BP_WorldRainComponent_Common_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_WorldRainComponent_Common_C.__ExecuteUbergraph_BP_WorldRainComponent_Common_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06020DAB RID: 134571 RVA: 0x00938BA3 File Offset: 0x00936DA3
		protected BP_WorldRainComponent_Common_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04010790 RID: 67472
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Rain2/BP_WorldRainComponent_Common.BP_WorldRainComponent_Common_C";

		// Token: 0x04010791 RID: 67473
		private static IntPtr _ClassPtr;

		// Token: 0x04010792 RID: 67474
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04010793 RID: 67475
		internal static int __PropertyOffset_0;

		// Token: 0x04010794 RID: 67476
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04010795 RID: 67477
		internal static int __PropertyOffset_1;

		// Token: 0x04010796 RID: 67478
		internal static int __PropertyOffset_2;

		// Token: 0x04010797 RID: 67479
		internal static int __PropertyOffset_3;

		// Token: 0x04010798 RID: 67480
		internal static int __PropertyOffset_4;

		// Token: 0x04010799 RID: 67481
		internal static int __PropertyOffset_5;

		// Token: 0x0401079A RID: 67482
		private static IntPtr __OnReceiveStartRain_NativeFunctionPtr;

		// Token: 0x0401079B RID: 67483
		private static IntPtr __OnReceiveDeactivateRain_NativeFunctionPtr;

		// Token: 0x0401079C RID: 67484
		private static IntPtr __ExecuteUbergraph_BP_WorldRainComponent_Common_NativeFunctionPtr;

		// Token: 0x02009A3F RID: 39487
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 96)]
		protected ref struct __ExecuteUbergraph_BP_WorldRainComponent_Common_FunctionParams
		{
			// Token: 0x0403213F RID: 205119
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
