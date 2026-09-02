using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.TrailFields.Runtime.Sensors
{
	// Token: 0x02003A31 RID: 14897
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/TrailFields/Runtime/Sensors/BP_TrailSensor_Snow.BP_TrailSensor_Snow_C")]
	[UnrealStructLayout(1296, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1292)]
	public class BP_TrailSensor_Snow_C : BP_TrailSensorActor_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601EB1B RID: 125723 RVA: 0x008FBE40 File Offset: 0x008FA040
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_TrailSensor_Snow_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/TrailFields/Runtime/Sensors/BP_TrailSensor_Snow.BP_TrailSensor_Snow_C");
			}
			return BP_TrailSensor_Snow_C._ClassPtr;
		}

		// Token: 0x0601EB1C RID: 125724 RVA: 0x008FBE64 File Offset: 0x008FA064
		public BP_TrailSensor_Snow_C() : this(BuiltinUtils.AllocNativeUObject(BP_TrailSensor_Snow_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601EB1D RID: 125725 RVA: 0x008FBE8C File Offset: 0x008FA08C
		public BP_TrailSensor_Snow_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_TrailSensor_Snow_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17002BF0 RID: 11248
		// (get) Token: 0x0601EB1E RID: 125726 RVA: 0x008FBEC0 File Offset: 0x008FA0C0
		// (set) Token: 0x0601EB1F RID: 125727 RVA: 0x008FBEF9 File Offset: 0x008FA0F9
		public new FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_TrailSensor_Snow_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_TrailSensor_Snow_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17002BF1 RID: 11249
		// (get) Token: 0x0601EB20 RID: 125728 RVA: 0x008FBF1A File Offset: 0x008FA11A
		// (set) Token: 0x0601EB21 RID: 125729 RVA: 0x008FBF2E File Offset: 0x008FA12E
		public unsafe FName UVXY
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TrailSensor_Snow_C.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_TrailSensor_Snow_C.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x0601EB22 RID: 125730 RVA: 0x008FBF43 File Offset: 0x008FA143
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void DrawFinished()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_TrailSensor_Snow_C.__DrawFinished_NativeFunctionPtr, null);
		}

		// Token: 0x0601EB23 RID: 125731 RVA: 0x008FBF58 File Offset: 0x008FA158
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_TrailSensor_Snow(int EntryPoint)
		{
			BP_TrailSensor_Snow_C.__ExecuteUbergraph_BP_TrailSensor_Snow_FunctionParams* ptr = stackalloc BP_TrailSensor_Snow_C.__ExecuteUbergraph_BP_TrailSensor_Snow_FunctionParams[(UIntPtr)51] + 15L / (long)sizeof(BP_TrailSensor_Snow_C.__ExecuteUbergraph_BP_TrailSensor_Snow_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_TrailSensor_Snow_C.__ExecuteUbergraph_BP_TrailSensor_Snow_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_TrailSensor_Snow_C.__ExecuteUbergraph_BP_TrailSensor_Snow_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601EB24 RID: 125732 RVA: 0x008FBF9F File Offset: 0x008FA19F
		protected BP_TrailSensor_Snow_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400F24C RID: 62028
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/TrailFields/Runtime/Sensors/BP_TrailSensor_Snow.BP_TrailSensor_Snow_C";

		// Token: 0x0400F24D RID: 62029
		private static IntPtr _ClassPtr;

		// Token: 0x0400F24E RID: 62030
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400F24F RID: 62031
		internal new static int __PropertyOffset_0;

		// Token: 0x0400F250 RID: 62032
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400F251 RID: 62033
		internal new static int __PropertyOffset_1;

		// Token: 0x0400F252 RID: 62034
		private static IntPtr __DrawFinished_NativeFunctionPtr;

		// Token: 0x0400F253 RID: 62035
		private static IntPtr __ExecuteUbergraph_BP_TrailSensor_Snow_NativeFunctionPtr;

		// Token: 0x020097EC RID: 38892
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 36)]
		protected ref struct __ExecuteUbergraph_BP_TrailSensor_Snow_FunctionParams
		{
			// Token: 0x04031DE0 RID: 204256
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
