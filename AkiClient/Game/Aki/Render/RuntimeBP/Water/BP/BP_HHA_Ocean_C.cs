using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Render.Data.Water;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Water.BP
{
	// Token: 0x02003A08 RID: 14856
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Water/BP/BP_HHA_Ocean.BP_HHA_Ocean_C")]
	[UnrealStructLayout(1464, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1460)]
	public class BP_HHA_Ocean_C : AKuroBPActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601E4A7 RID: 124071 RVA: 0x008F1E40 File Offset: 0x008F0040
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_HHA_Ocean_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Water/BP/BP_HHA_Ocean.BP_HHA_Ocean_C");
			}
			return BP_HHA_Ocean_C._ClassPtr;
		}

		// Token: 0x0601E4A8 RID: 124072 RVA: 0x008F1E64 File Offset: 0x008F0064
		public BP_HHA_Ocean_C() : this(BuiltinUtils.AllocNativeUObject(BP_HHA_Ocean_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601E4A9 RID: 124073 RVA: 0x008F1E8C File Offset: 0x008F008C
		[NullableContext(1)]
		public BP_HHA_Ocean_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_HHA_Ocean_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17002969 RID: 10601
		// (get) Token: 0x0601E4AA RID: 124074 RVA: 0x008F1EC0 File Offset: 0x008F00C0
		// (set) Token: 0x0601E4AB RID: 124075 RVA: 0x008F1EF9 File Offset: 0x008F00F9
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_HHA_Ocean_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_HHA_Ocean_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700296A RID: 10602
		// (get) Token: 0x0601E4AC RID: 124076 RVA: 0x008F1F1A File Offset: 0x008F011A
		// (set) Token: 0x0601E4AD RID: 124077 RVA: 0x008F1F2E File Offset: 0x008F012E
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_HHA_Ocean_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_HHA_Ocean_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x1700296B RID: 10603
		// (get) Token: 0x0601E4AE RID: 124078 RVA: 0x008F1F43 File Offset: 0x008F0143
		// (set) Token: 0x0601E4AF RID: 124079 RVA: 0x008F1F53 File Offset: 0x008F0153
		public unsafe float CurTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_HHA_Ocean_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_HHA_Ocean_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x1700296C RID: 10604
		// (get) Token: 0x0601E4B0 RID: 124080 RVA: 0x008F1F64 File Offset: 0x008F0164
		// (set) Token: 0x0601E4B1 RID: 124081 RVA: 0x008F1F78 File Offset: 0x008F0178
		public unsafe BP_Ocean_Data_C ZhongWu_12
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_Ocean_Data_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_HHA_Ocean_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_HHA_Ocean_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x1700296D RID: 10605
		// (get) Token: 0x0601E4B2 RID: 124082 RVA: 0x008F1F8D File Offset: 0x008F018D
		// (set) Token: 0x0601E4B3 RID: 124083 RVA: 0x008F1FA1 File Offset: 0x008F01A1
		public unsafe BP_Ocean_Data_C YeWan_0
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_Ocean_Data_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_HHA_Ocean_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_HHA_Ocean_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x1700296E RID: 10606
		// (get) Token: 0x0601E4B4 RID: 124084 RVA: 0x008F1FB6 File Offset: 0x008F01B6
		// (set) Token: 0x0601E4B5 RID: 124085 RVA: 0x008F1FC6 File Offset: 0x008F01C6
		public unsafe float TimeLerp
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_HHA_Ocean_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_HHA_Ocean_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x1700296F RID: 10607
		// (get) Token: 0x0601E4B6 RID: 124086 RVA: 0x008F1FD7 File Offset: 0x008F01D7
		// (set) Token: 0x0601E4B7 RID: 124087 RVA: 0x008F1FEB File Offset: 0x008F01EB
		public unsafe BP_Ocean_Data_C OceanData
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_Ocean_Data_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_HHA_Ocean_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_HHA_Ocean_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x17002970 RID: 10608
		// (get) Token: 0x0601E4B8 RID: 124088 RVA: 0x008F2000 File Offset: 0x008F0200
		// (set) Token: 0x0601E4B9 RID: 124089 RVA: 0x008F2014 File Offset: 0x008F0214
		public unsafe UMaterialInstanceDynamic OceanMaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_HHA_Ocean_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_HHA_Ocean_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x17002971 RID: 10609
		// (get) Token: 0x0601E4BA RID: 124090 RVA: 0x008F2029 File Offset: 0x008F0229
		// (set) Token: 0x0601E4BB RID: 124091 RVA: 0x008F2039 File Offset: 0x008F0239
		public unsafe int Timer
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_HHA_Ocean_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_HHA_Ocean_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17002972 RID: 10610
		// (get) Token: 0x0601E4BC RID: 124092 RVA: 0x008F204A File Offset: 0x008F024A
		// (set) Token: 0x0601E4BD RID: 124093 RVA: 0x008F205A File Offset: 0x008F025A
		public unsafe bool EditorOceanLerpMaterial
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_HHA_Ocean_C.__PropertyOffset_9) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_HHA_Ocean_C.__PropertyOffset_9) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002973 RID: 10611
		// (get) Token: 0x0601E4BE RID: 124094 RVA: 0x008F206B File Offset: 0x008F026B
		// (set) Token: 0x0601E4BF RID: 124095 RVA: 0x008F207B File Offset: 0x008F027B
		public unsafe bool SetTex_Noon
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_HHA_Ocean_C.__PropertyOffset_10) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_HHA_Ocean_C.__PropertyOffset_10) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002974 RID: 10612
		// (get) Token: 0x0601E4C0 RID: 124096 RVA: 0x008F208C File Offset: 0x008F028C
		// (set) Token: 0x0601E4C1 RID: 124097 RVA: 0x008F209C File Offset: 0x008F029C
		public unsafe bool SetTex_Night
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_HHA_Ocean_C.__PropertyOffset_11) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_HHA_Ocean_C.__PropertyOffset_11) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002975 RID: 10613
		// (get) Token: 0x0601E4C2 RID: 124098 RVA: 0x008F20AD File Offset: 0x008F02AD
		// (set) Token: 0x0601E4C3 RID: 124099 RVA: 0x008F20C1 File Offset: 0x008F02C1
		public unsafe AStaticMeshActor OceanMeshActor_0
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AStaticMeshActor>(base.NativePtr / (IntPtr)sizeof(void*) + BP_HHA_Ocean_C.__PropertyOffset_12);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_HHA_Ocean_C.__PropertyOffset_12, value);
			}
		}

		// Token: 0x17002976 RID: 10614
		// (get) Token: 0x0601E4C4 RID: 124100 RVA: 0x008F20D6 File Offset: 0x008F02D6
		// (set) Token: 0x0601E4C5 RID: 124101 RVA: 0x008F20EA File Offset: 0x008F02EA
		public unsafe AStaticMeshActor OceanMeshActor_1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AStaticMeshActor>(base.NativePtr / (IntPtr)sizeof(void*) + BP_HHA_Ocean_C.__PropertyOffset_13);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_HHA_Ocean_C.__PropertyOffset_13, value);
			}
		}

		// Token: 0x17002977 RID: 10615
		// (get) Token: 0x0601E4C6 RID: 124102 RVA: 0x008F20FF File Offset: 0x008F02FF
		// (set) Token: 0x0601E4C7 RID: 124103 RVA: 0x008F2113 File Offset: 0x008F0313
		public unsafe AStaticMeshActor OceanMeshActor_2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AStaticMeshActor>(base.NativePtr / (IntPtr)sizeof(void*) + BP_HHA_Ocean_C.__PropertyOffset_14);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_HHA_Ocean_C.__PropertyOffset_14, value);
			}
		}

		// Token: 0x17002978 RID: 10616
		// (get) Token: 0x0601E4C8 RID: 124104 RVA: 0x008F2128 File Offset: 0x008F0328
		// (set) Token: 0x0601E4C9 RID: 124105 RVA: 0x008F213C File Offset: 0x008F033C
		public unsafe AStaticMeshActor OceanMeshActor_3
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AStaticMeshActor>(base.NativePtr / (IntPtr)sizeof(void*) + BP_HHA_Ocean_C.__PropertyOffset_15);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_HHA_Ocean_C.__PropertyOffset_15, value);
			}
		}

		// Token: 0x17002979 RID: 10617
		// (get) Token: 0x0601E4CA RID: 124106 RVA: 0x008F2151 File Offset: 0x008F0351
		// (set) Token: 0x0601E4CB RID: 124107 RVA: 0x008F2161 File Offset: 0x008F0361
		public unsafe float ShaderTimer
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_HHA_Ocean_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_HHA_Ocean_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x1700297A RID: 10618
		// (get) Token: 0x0601E4CC RID: 124108 RVA: 0x008F2172 File Offset: 0x008F0372
		// (set) Token: 0x0601E4CD RID: 124109 RVA: 0x008F2186 File Offset: 0x008F0386
		public unsafe FLinearColor RippleTimer
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_HHA_Ocean_C.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_HHA_Ocean_C.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x1700297B RID: 10619
		// (get) Token: 0x0601E4CE RID: 124110 RVA: 0x008F219C File Offset: 0x008F039C
		// (set) Token: 0x0601E4CF RID: 124111 RVA: 0x008F21D5 File Offset: 0x008F03D5
		[Nullable(1)]
		public TArray<FName> RipplePos
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<FName> result;
				if ((result = this._RipplePos) == null)
				{
					result = (this._RipplePos = new TArray<FName>(base.NativePtr + (IntPtr)BP_HHA_Ocean_C.__PropertyOffset_18, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.RipplePos.CopyAssign(value);
			}
		}

		// Token: 0x1700297C RID: 10620
		// (get) Token: 0x0601E4D0 RID: 124112 RVA: 0x008F21E3 File Offset: 0x008F03E3
		// (set) Token: 0x0601E4D1 RID: 124113 RVA: 0x008F21F3 File Offset: 0x008F03F3
		public unsafe int RippleIndex
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_HHA_Ocean_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_HHA_Ocean_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x1700297D RID: 10621
		// (get) Token: 0x0601E4D2 RID: 124114 RVA: 0x008F2204 File Offset: 0x008F0404
		// (set) Token: 0x0601E4D3 RID: 124115 RVA: 0x008F2214 File Offset: 0x008F0414
		public unsafe bool bMobliePlatform
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_HHA_Ocean_C.__PropertyOffset_20) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_HHA_Ocean_C.__PropertyOffset_20) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700297E RID: 10622
		// (get) Token: 0x0601E4D4 RID: 124116 RVA: 0x008F2225 File Offset: 0x008F0425
		// (set) Token: 0x0601E4D5 RID: 124117 RVA: 0x008F2235 File Offset: 0x008F0435
		public unsafe bool bRipple
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_HHA_Ocean_C.__PropertyOffset_21) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_HHA_Ocean_C.__PropertyOffset_21) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700297F RID: 10623
		// (get) Token: 0x0601E4D6 RID: 124118 RVA: 0x008F2246 File Offset: 0x008F0446
		// (set) Token: 0x0601E4D7 RID: 124119 RVA: 0x008F2256 File Offset: 0x008F0456
		public unsafe bool bDrawDebugSphere
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_HHA_Ocean_C.__PropertyOffset_22) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_HHA_Ocean_C.__PropertyOffset_22) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002980 RID: 10624
		// (get) Token: 0x0601E4D8 RID: 124120 RVA: 0x008F2267 File Offset: 0x008F0467
		// (set) Token: 0x0601E4D9 RID: 124121 RVA: 0x008F2277 File Offset: 0x008F0477
		public unsafe float fTODEnableRange
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_HHA_Ocean_C.__PropertyOffset_23);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_HHA_Ocean_C.__PropertyOffset_23) = value;
			}
		}

		// Token: 0x0601E4DA RID: 124122 RVA: 0x008F2288 File Offset: 0x008F0488
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void WaterRipple()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_HHA_Ocean_C.__WaterRipple_NativeFunctionPtr, null);
		}

		// Token: 0x0601E4DB RID: 124123 RVA: 0x008F229C File Offset: 0x008F049C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_HHA_Ocean_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x0601E4DC RID: 124124 RVA: 0x008F22B0 File Offset: 0x008F04B0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_HHA_Ocean_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601E4DD RID: 124125 RVA: 0x008F22C5 File Offset: 0x008F04C5
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_HHA_Ocean_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0601E4DE RID: 124126 RVA: 0x008F22D9 File Offset: 0x008F04D9
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_HHA_Ocean_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601E4DF RID: 124127 RVA: 0x008F22EE File Offset: 0x008F04EE
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EditorTick()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_HHA_Ocean_C.__EditorTick_NativeFunctionPtr, null);
		}

		// Token: 0x0601E4E0 RID: 124128 RVA: 0x008F2304 File Offset: 0x008F0504
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void CustomEvent_0(AActor 被控物, AActor 水面)
		{
			BP_HHA_Ocean_C.__CustomEvent_0_FunctionParams* ptr = stackalloc BP_HHA_Ocean_C.__CustomEvent_0_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(BP_HHA_Ocean_C.__CustomEvent_0_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_HHA_Ocean_C.__CustomEvent_0_NativeFunctionPtr, (void*)ptr, 1);
			ptr->被控物 = ((被控物 != null) ? 被控物.NativePtr : IntPtr.Zero);
			ptr->水面 = ((水面 != null) ? 水面.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_HHA_Ocean_C.__CustomEvent_0_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601E4E1 RID: 124129 RVA: 0x008F2370 File Offset: 0x008F0570
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_HHA_Ocean_OceanMeshActor_3_K2Node_ComponentBoundEvent_3_ActorBeginOverlapSignature__DelegateSignature(AActor OverlappedActor, AActor OtherActor)
		{
			BP_HHA_Ocean_C.__BndEvt__BP_HHA_Ocean_OceanMeshActor_3_K2Node_ComponentBoundEvent_3_ActorBeginOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_HHA_Ocean_C.__BndEvt__BP_HHA_Ocean_OceanMeshActor_3_K2Node_ComponentBoundEvent_3_ActorBeginOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(BP_HHA_Ocean_C.__BndEvt__BP_HHA_Ocean_OceanMeshActor_3_K2Node_ComponentBoundEvent_3_ActorBeginOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_HHA_Ocean_C.__BndEvt__BP_HHA_Ocean_OceanMeshActor_3_K2Node_ComponentBoundEvent_3_ActorBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedActor = ((OverlappedActor != null) ? OverlappedActor.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_HHA_Ocean_C.__BndEvt__BP_HHA_Ocean_OceanMeshActor_3_K2Node_ComponentBoundEvent_3_ActorBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601E4E2 RID: 124130 RVA: 0x008F23DC File Offset: 0x008F05DC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_HHA_Ocean_OceanMeshActor_2_K2Node_ComponentBoundEvent_2_ActorBeginOverlapSignature__DelegateSignature(AActor OverlappedActor, AActor OtherActor)
		{
			BP_HHA_Ocean_C.__BndEvt__BP_HHA_Ocean_OceanMeshActor_2_K2Node_ComponentBoundEvent_2_ActorBeginOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_HHA_Ocean_C.__BndEvt__BP_HHA_Ocean_OceanMeshActor_2_K2Node_ComponentBoundEvent_2_ActorBeginOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(BP_HHA_Ocean_C.__BndEvt__BP_HHA_Ocean_OceanMeshActor_2_K2Node_ComponentBoundEvent_2_ActorBeginOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_HHA_Ocean_C.__BndEvt__BP_HHA_Ocean_OceanMeshActor_2_K2Node_ComponentBoundEvent_2_ActorBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedActor = ((OverlappedActor != null) ? OverlappedActor.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_HHA_Ocean_C.__BndEvt__BP_HHA_Ocean_OceanMeshActor_2_K2Node_ComponentBoundEvent_2_ActorBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601E4E3 RID: 124131 RVA: 0x008F2448 File Offset: 0x008F0648
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_HHA_Ocean_OceanMeshActor_1_K2Node_ComponentBoundEvent_1_ActorBeginOverlapSignature__DelegateSignature(AActor OverlappedActor, AActor OtherActor)
		{
			BP_HHA_Ocean_C.__BndEvt__BP_HHA_Ocean_OceanMeshActor_1_K2Node_ComponentBoundEvent_1_ActorBeginOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_HHA_Ocean_C.__BndEvt__BP_HHA_Ocean_OceanMeshActor_1_K2Node_ComponentBoundEvent_1_ActorBeginOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(BP_HHA_Ocean_C.__BndEvt__BP_HHA_Ocean_OceanMeshActor_1_K2Node_ComponentBoundEvent_1_ActorBeginOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_HHA_Ocean_C.__BndEvt__BP_HHA_Ocean_OceanMeshActor_1_K2Node_ComponentBoundEvent_1_ActorBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedActor = ((OverlappedActor != null) ? OverlappedActor.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_HHA_Ocean_C.__BndEvt__BP_HHA_Ocean_OceanMeshActor_1_K2Node_ComponentBoundEvent_1_ActorBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601E4E4 RID: 124132 RVA: 0x008F24B4 File Offset: 0x008F06B4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_HHA_Ocean_OceanMeshActor_0_K2Node_ComponentBoundEvent_0_ActorBeginOverlapSignature__DelegateSignature(AActor OverlappedActor, AActor OtherActor)
		{
			BP_HHA_Ocean_C.__BndEvt__BP_HHA_Ocean_OceanMeshActor_0_K2Node_ComponentBoundEvent_0_ActorBeginOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_HHA_Ocean_C.__BndEvt__BP_HHA_Ocean_OceanMeshActor_0_K2Node_ComponentBoundEvent_0_ActorBeginOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(BP_HHA_Ocean_C.__BndEvt__BP_HHA_Ocean_OceanMeshActor_0_K2Node_ComponentBoundEvent_0_ActorBeginOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_HHA_Ocean_C.__BndEvt__BP_HHA_Ocean_OceanMeshActor_0_K2Node_ComponentBoundEvent_0_ActorBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedActor = ((OverlappedActor != null) ? OverlappedActor.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_HHA_Ocean_C.__BndEvt__BP_HHA_Ocean_OceanMeshActor_0_K2Node_ComponentBoundEvent_0_ActorBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601E4E5 RID: 124133 RVA: 0x008F2520 File Offset: 0x008F0720
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_HHA_Ocean_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_HHA_Ocean_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_HHA_Ocean_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_HHA_Ocean_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_HHA_Ocean_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601E4E6 RID: 124134 RVA: 0x008F2568 File Offset: 0x008F0768
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_HHA_Ocean_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_HHA_Ocean_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_HHA_Ocean_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_HHA_Ocean_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_HHA_Ocean_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601E4E7 RID: 124135 RVA: 0x008F25B0 File Offset: 0x008F07B0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_HHA_Ocean(int EntryPoint)
		{
			BP_HHA_Ocean_C.__ExecuteUbergraph_BP_HHA_Ocean_FunctionParams* ptr = stackalloc BP_HHA_Ocean_C.__ExecuteUbergraph_BP_HHA_Ocean_FunctionParams[(UIntPtr)791] + 15L / (long)sizeof(BP_HHA_Ocean_C.__ExecuteUbergraph_BP_HHA_Ocean_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_HHA_Ocean_C.__ExecuteUbergraph_BP_HHA_Ocean_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_HHA_Ocean_C.__ExecuteUbergraph_BP_HHA_Ocean_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601E4E8 RID: 124136 RVA: 0x008F25FA File Offset: 0x008F07FA
		protected BP_HHA_Ocean_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400EE5A RID: 61018
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Water/BP/BP_HHA_Ocean.BP_HHA_Ocean_C";

		// Token: 0x0400EE5B RID: 61019
		private static IntPtr _ClassPtr;

		// Token: 0x0400EE5C RID: 61020
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400EE5D RID: 61021
		internal static int __PropertyOffset_0;

		// Token: 0x0400EE5E RID: 61022
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400EE5F RID: 61023
		internal static int __PropertyOffset_1;

		// Token: 0x0400EE60 RID: 61024
		internal static int __PropertyOffset_2;

		// Token: 0x0400EE61 RID: 61025
		internal static int __PropertyOffset_3;

		// Token: 0x0400EE62 RID: 61026
		internal static int __PropertyOffset_4;

		// Token: 0x0400EE63 RID: 61027
		internal static int __PropertyOffset_5;

		// Token: 0x0400EE64 RID: 61028
		internal static int __PropertyOffset_6;

		// Token: 0x0400EE65 RID: 61029
		internal static int __PropertyOffset_7;

		// Token: 0x0400EE66 RID: 61030
		internal static int __PropertyOffset_8;

		// Token: 0x0400EE67 RID: 61031
		internal static int __PropertyOffset_9;

		// Token: 0x0400EE68 RID: 61032
		internal static int __PropertyOffset_10;

		// Token: 0x0400EE69 RID: 61033
		internal static int __PropertyOffset_11;

		// Token: 0x0400EE6A RID: 61034
		internal static int __PropertyOffset_12;

		// Token: 0x0400EE6B RID: 61035
		internal static int __PropertyOffset_13;

		// Token: 0x0400EE6C RID: 61036
		internal static int __PropertyOffset_14;

		// Token: 0x0400EE6D RID: 61037
		internal static int __PropertyOffset_15;

		// Token: 0x0400EE6E RID: 61038
		internal static int __PropertyOffset_16;

		// Token: 0x0400EE6F RID: 61039
		internal static int __PropertyOffset_17;

		// Token: 0x0400EE70 RID: 61040
		internal static int __PropertyOffset_18;

		// Token: 0x0400EE71 RID: 61041
		private TArray<FName> _RipplePos;

		// Token: 0x0400EE72 RID: 61042
		internal static int __PropertyOffset_19;

		// Token: 0x0400EE73 RID: 61043
		internal static int __PropertyOffset_20;

		// Token: 0x0400EE74 RID: 61044
		internal static int __PropertyOffset_21;

		// Token: 0x0400EE75 RID: 61045
		internal static int __PropertyOffset_22;

		// Token: 0x0400EE76 RID: 61046
		internal static int __PropertyOffset_23;

		// Token: 0x0400EE77 RID: 61047
		private static IntPtr __WaterRipple_NativeFunctionPtr;

		// Token: 0x0400EE78 RID: 61048
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x0400EE79 RID: 61049
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0400EE7A RID: 61050
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x0400EE7B RID: 61051
		private static IntPtr __CustomEvent_0_NativeFunctionPtr;

		// Token: 0x0400EE7C RID: 61052
		private static IntPtr __BndEvt__BP_HHA_Ocean_OceanMeshActor_3_K2Node_ComponentBoundEvent_3_ActorBeginOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0400EE7D RID: 61053
		private static IntPtr __BndEvt__BP_HHA_Ocean_OceanMeshActor_2_K2Node_ComponentBoundEvent_2_ActorBeginOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0400EE7E RID: 61054
		private static IntPtr __BndEvt__BP_HHA_Ocean_OceanMeshActor_1_K2Node_ComponentBoundEvent_1_ActorBeginOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0400EE7F RID: 61055
		private static IntPtr __BndEvt__BP_HHA_Ocean_OceanMeshActor_0_K2Node_ComponentBoundEvent_0_ActorBeginOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0400EE80 RID: 61056
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0400EE81 RID: 61057
		private static IntPtr __ExecuteUbergraph_BP_HHA_Ocean_NativeFunctionPtr;

		// Token: 0x0200979C RID: 38812
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __CustomEvent_0_FunctionParams
		{
			// Token: 0x04031D62 RID: 204130
			[FieldOffset(0)]
			public IntPtr 被控物;

			// Token: 0x04031D63 RID: 204131
			[FieldOffset(8)]
			public IntPtr 水面;
		}

		// Token: 0x0200979D RID: 38813
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __BndEvt__BP_HHA_Ocean_OceanMeshActor_3_K2Node_ComponentBoundEvent_3_ActorBeginOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x04031D64 RID: 204132
			[FieldOffset(0)]
			public IntPtr OverlappedActor;

			// Token: 0x04031D65 RID: 204133
			[FieldOffset(8)]
			public IntPtr OtherActor;
		}

		// Token: 0x0200979E RID: 38814
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __BndEvt__BP_HHA_Ocean_OceanMeshActor_2_K2Node_ComponentBoundEvent_2_ActorBeginOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x04031D66 RID: 204134
			[FieldOffset(0)]
			public IntPtr OverlappedActor;

			// Token: 0x04031D67 RID: 204135
			[FieldOffset(8)]
			public IntPtr OtherActor;
		}

		// Token: 0x0200979F RID: 38815
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __BndEvt__BP_HHA_Ocean_OceanMeshActor_1_K2Node_ComponentBoundEvent_1_ActorBeginOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x04031D68 RID: 204136
			[FieldOffset(0)]
			public IntPtr OverlappedActor;

			// Token: 0x04031D69 RID: 204137
			[FieldOffset(8)]
			public IntPtr OtherActor;
		}

		// Token: 0x020097A0 RID: 38816
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __BndEvt__BP_HHA_Ocean_OceanMeshActor_0_K2Node_ComponentBoundEvent_0_ActorBeginOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x04031D6A RID: 204138
			[FieldOffset(0)]
			public IntPtr OverlappedActor;

			// Token: 0x04031D6B RID: 204139
			[FieldOffset(8)]
			public IntPtr OtherActor;
		}

		// Token: 0x020097A1 RID: 38817
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04031D6C RID: 204140
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x020097A2 RID: 38818
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 776)]
		protected ref struct __ExecuteUbergraph_BP_HHA_Ocean_FunctionParams
		{
			// Token: 0x04031D6D RID: 204141
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
