using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.WaterSim.BP
{
	// Token: 0x02003B53 RID: 15187
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/WaterSim/BP/BP_WaterSimulation_DepthCapture.BP_WaterSimulation_DepthCapture_C")]
	[UnrealStructLayout(1368, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1368)]
	public class BP_WaterSimulation_DepthCapture_C : AKuroBPActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060211DC RID: 135644 RVA: 0x00940363 File Offset: 0x0093E563
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_WaterSimulation_DepthCapture_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/WaterSim/BP/BP_WaterSimulation_DepthCapture.BP_WaterSimulation_DepthCapture_C");
			}
			return BP_WaterSimulation_DepthCapture_C._ClassPtr;
		}

		// Token: 0x060211DD RID: 135645 RVA: 0x00940388 File Offset: 0x0093E588
		public BP_WaterSimulation_DepthCapture_C() : this(BuiltinUtils.AllocNativeUObject(BP_WaterSimulation_DepthCapture_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060211DE RID: 135646 RVA: 0x009403B0 File Offset: 0x0093E5B0
		public BP_WaterSimulation_DepthCapture_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_WaterSimulation_DepthCapture_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700393E RID: 14654
		// (get) Token: 0x060211DF RID: 135647 RVA: 0x009403E3 File Offset: 0x0093E5E3
		// (set) Token: 0x060211E0 RID: 135648 RVA: 0x009403F7 File Offset: 0x0093E5F7
		[Nullable(2)]
		public unsafe USceneCaptureComponent2D SceneCaptureComponent2D
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneCaptureComponent2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_DepthCapture_C.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_DepthCapture_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x1700393F RID: 14655
		// (get) Token: 0x060211E1 RID: 135649 RVA: 0x0094040C File Offset: 0x0093E60C
		// (set) Token: 0x060211E2 RID: 135650 RVA: 0x00940420 File Offset: 0x0093E620
		[Nullable(2)]
		public unsafe USceneComponent DefaultSceneRoot
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_DepthCapture_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_DepthCapture_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17003940 RID: 14656
		// (get) Token: 0x060211E3 RID: 135651 RVA: 0x00940435 File Offset: 0x0093E635
		// (set) Token: 0x060211E4 RID: 135652 RVA: 0x00940449 File Offset: 0x0093E649
		public unsafe string SavePath
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)BP_WaterSimulation_DepthCapture_C.__PropertyOffset_2)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)BP_WaterSimulation_DepthCapture_C.__PropertyOffset_2)), value);
			}
		}

		// Token: 0x17003941 RID: 14657
		// (get) Token: 0x060211E5 RID: 135653 RVA: 0x0094045E File Offset: 0x0093E65E
		// (set) Token: 0x060211E6 RID: 135654 RVA: 0x00940472 File Offset: 0x0093E672
		public unsafe string Name
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)BP_WaterSimulation_DepthCapture_C.__PropertyOffset_3)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)BP_WaterSimulation_DepthCapture_C.__PropertyOffset_3)), value);
			}
		}

		// Token: 0x17003942 RID: 14658
		// (get) Token: 0x060211E7 RID: 135655 RVA: 0x00940487 File Offset: 0x0093E687
		// (set) Token: 0x060211E8 RID: 135656 RVA: 0x00940497 File Offset: 0x0093E697
		public unsafe int SimSize_M_
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_DepthCapture_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_DepthCapture_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17003943 RID: 14659
		// (get) Token: 0x060211E9 RID: 135657 RVA: 0x009404A8 File Offset: 0x0093E6A8
		// (set) Token: 0x060211EA RID: 135658 RVA: 0x009404B8 File Offset: 0x0093E6B8
		public unsafe int TextureSize
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_DepthCapture_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_DepthCapture_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17003944 RID: 14660
		// (get) Token: 0x060211EB RID: 135659 RVA: 0x009404CC File Offset: 0x0093E6CC
		// (set) Token: 0x060211EC RID: 135660 RVA: 0x00940505 File Offset: 0x0093E705
		public TArray<AActor> Hidden_Actors
		{
			get
			{
				base.FastCheckIsValid();
				TArray<AActor> result;
				if ((result = this._Hidden_Actors) == null)
				{
					result = (this._Hidden_Actors = new TArray<AActor>(base.NativePtr + (IntPtr)BP_WaterSimulation_DepthCapture_C.__PropertyOffset_6, this));
				}
				return result;
			}
			set
			{
				this.Hidden_Actors.CopyAssign(value);
			}
		}

		// Token: 0x060211ED RID: 135661 RVA: 0x00940513 File Offset: 0x0093E713
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void SaveCaptureDepthMap()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WaterSimulation_DepthCapture_C.__SaveCaptureDepthMap_NativeFunctionPtr, null);
		}

		// Token: 0x060211EE RID: 135662 RVA: 0x00940527 File Offset: 0x0093E727
		protected BP_WaterSimulation_DepthCapture_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04010A2B RID: 68139
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/WaterSim/BP/BP_WaterSimulation_DepthCapture.BP_WaterSimulation_DepthCapture_C";

		// Token: 0x04010A2C RID: 68140
		private static IntPtr _ClassPtr;

		// Token: 0x04010A2D RID: 68141
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04010A2E RID: 68142
		internal static int __PropertyOffset_0;

		// Token: 0x04010A2F RID: 68143
		internal static int __PropertyOffset_1;

		// Token: 0x04010A30 RID: 68144
		internal static int __PropertyOffset_2;

		// Token: 0x04010A31 RID: 68145
		internal static int __PropertyOffset_3;

		// Token: 0x04010A32 RID: 68146
		internal static int __PropertyOffset_4;

		// Token: 0x04010A33 RID: 68147
		internal static int __PropertyOffset_5;

		// Token: 0x04010A34 RID: 68148
		internal static int __PropertyOffset_6;

		// Token: 0x04010A35 RID: 68149
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<AActor> _Hidden_Actors;

		// Token: 0x04010A36 RID: 68150
		private static IntPtr __SaveCaptureDepthMap_NativeFunctionPtr;
	}
}
