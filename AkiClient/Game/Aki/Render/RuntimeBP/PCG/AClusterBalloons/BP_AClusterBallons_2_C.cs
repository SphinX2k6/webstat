using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Core.Fight;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.AClusterBalloons
{
	// Token: 0x02003C4B RID: 15435
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/AClusterBalloons/BP_AClusterBallons_2.BP_AClusterBallons_2_C")]
	[UnrealStructLayout(1752, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1752)]
	public class BP_AClusterBallons_2_C : AKuroCSBalloons, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060238AB RID: 145579 RVA: 0x0098526C File Offset: 0x0098346C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_AClusterBallons_2_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/AClusterBalloons/BP_AClusterBallons_2.BP_AClusterBallons_2_C");
			}
			return BP_AClusterBallons_2_C._ClassPtr;
		}

		// Token: 0x060238AC RID: 145580 RVA: 0x00985290 File Offset: 0x00983490
		public BP_AClusterBallons_2_C() : this(BuiltinUtils.AllocNativeUObject(BP_AClusterBallons_2_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060238AD RID: 145581 RVA: 0x009852B8 File Offset: 0x009834B8
		[NullableContext(1)]
		public BP_AClusterBallons_2_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_AClusterBallons_2_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170046FC RID: 18172
		// (get) Token: 0x060238AE RID: 145582 RVA: 0x009852EC File Offset: 0x009834EC
		// (set) Token: 0x060238AF RID: 145583 RVA: 0x00985325 File Offset: 0x00983525
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_AClusterBallons_2_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_AClusterBallons_2_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170046FD RID: 18173
		// (get) Token: 0x060238B0 RID: 145584 RVA: 0x00985346 File Offset: 0x00983546
		// (set) Token: 0x060238B1 RID: 145585 RVA: 0x0098535A File Offset: 0x0098355A
		public unsafe UBoxComponent ValidBox
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_AClusterBallons_2_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_AClusterBallons_2_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170046FE RID: 18174
		// (get) Token: 0x060238B2 RID: 145586 RVA: 0x0098536F File Offset: 0x0098356F
		// (set) Token: 0x060238B3 RID: 145587 RVA: 0x00985383 File Offset: 0x00983583
		public unsafe UStaticMeshComponent xpbd_test
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_AClusterBallons_2_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_AClusterBallons_2_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x170046FF RID: 18175
		// (get) Token: 0x060238B4 RID: 145588 RVA: 0x00985398 File Offset: 0x00983598
		// (set) Token: 0x060238B5 RID: 145589 RVA: 0x009853AC File Offset: 0x009835AC
		public unsafe UTextureRenderTarget2D RT_Pos
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_AClusterBallons_2_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_AClusterBallons_2_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17004700 RID: 18176
		// (get) Token: 0x060238B6 RID: 145590 RVA: 0x009853C1 File Offset: 0x009835C1
		// (set) Token: 0x060238B7 RID: 145591 RVA: 0x009853D5 File Offset: 0x009835D5
		public unsafe UDataTable DT
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UDataTable>(base.NativePtr / (IntPtr)sizeof(void*) + BP_AClusterBallons_2_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_AClusterBallons_2_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17004701 RID: 18177
		// (get) Token: 0x060238B8 RID: 145592 RVA: 0x009853EA File Offset: 0x009835EA
		// (set) Token: 0x060238B9 RID: 145593 RVA: 0x009853FE File Offset: 0x009835FE
		public unsafe UMaterialInstanceDynamic MID
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_AClusterBallons_2_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_AClusterBallons_2_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x17004702 RID: 18178
		// (get) Token: 0x060238BA RID: 145594 RVA: 0x00985413 File Offset: 0x00983613
		// (set) Token: 0x060238BB RID: 145595 RVA: 0x00985423 File Offset: 0x00983623
		public unsafe bool debugDraw
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_AClusterBallons_2_C.__PropertyOffset_6) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_AClusterBallons_2_C.__PropertyOffset_6) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004703 RID: 18179
		// (get) Token: 0x060238BC RID: 145596 RVA: 0x00985434 File Offset: 0x00983634
		// (set) Token: 0x060238BD RID: 145597 RVA: 0x00985448 File Offset: 0x00983648
		public unsafe UMaterialInstance InputMat
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_AClusterBallons_2_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_AClusterBallons_2_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x17004704 RID: 18180
		// (get) Token: 0x060238BE RID: 145598 RVA: 0x0098545D File Offset: 0x0098365D
		// (set) Token: 0x060238BF RID: 145599 RVA: 0x0098546D File Offset: 0x0098366D
		public unsafe float force
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_AClusterBallons_2_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_AClusterBallons_2_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17004705 RID: 18181
		// (get) Token: 0x060238C0 RID: 145600 RVA: 0x0098547E File Offset: 0x0098367E
		// (set) Token: 0x060238C1 RID: 145601 RVA: 0x0098548E File Offset: 0x0098368E
		public unsafe bool Pressing
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_AClusterBallons_2_C.__PropertyOffset_9) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_AClusterBallons_2_C.__PropertyOffset_9) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004706 RID: 18182
		// (get) Token: 0x060238C2 RID: 145602 RVA: 0x0098549F File Offset: 0x0098369F
		// (set) Token: 0x060238C3 RID: 145603 RVA: 0x009854AF File Offset: 0x009836AF
		public unsafe bool FS_isPhysicSimulation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_AClusterBallons_2_C.__PropertyOffset_10) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_AClusterBallons_2_C.__PropertyOffset_10) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004707 RID: 18183
		// (get) Token: 0x060238C4 RID: 145604 RVA: 0x009854C0 File Offset: 0x009836C0
		// (set) Token: 0x060238C5 RID: 145605 RVA: 0x009854D0 File Offset: 0x009836D0
		public unsafe float mass_in_kg
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_AClusterBallons_2_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_AClusterBallons_2_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17004708 RID: 18184
		// (get) Token: 0x060238C6 RID: 145606 RVA: 0x009854E1 File Offset: 0x009836E1
		// (set) Token: 0x060238C7 RID: 145607 RVA: 0x009854F1 File Offset: 0x009836F1
		public unsafe bool beditorTick
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_AClusterBallons_2_C.__PropertyOffset_12) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_AClusterBallons_2_C.__PropertyOffset_12) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004709 RID: 18185
		// (get) Token: 0x060238C8 RID: 145608 RVA: 0x00985502 File Offset: 0x00983702
		// (set) Token: 0x060238C9 RID: 145609 RVA: 0x00985512 File Offset: 0x00983712
		public unsafe bool _2DRT
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_AClusterBallons_2_C.__PropertyOffset_13) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_AClusterBallons_2_C.__PropertyOffset_13) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700470A RID: 18186
		// (get) Token: 0x060238CA RID: 145610 RVA: 0x00985523 File Offset: 0x00983723
		// (set) Token: 0x060238CB RID: 145611 RVA: 0x00985533 File Offset: 0x00983733
		public unsafe int XCount_0
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_AClusterBallons_2_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_AClusterBallons_2_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x1700470B RID: 18187
		// (get) Token: 0x060238CC RID: 145612 RVA: 0x00985544 File Offset: 0x00983744
		// (set) Token: 0x060238CD RID: 145613 RVA: 0x00985554 File Offset: 0x00983754
		public unsafe bool ReadDataInBeginPlay
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_AClusterBallons_2_C.__PropertyOffset_15) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_AClusterBallons_2_C.__PropertyOffset_15) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700470C RID: 18188
		// (get) Token: 0x060238CE RID: 145614 RVA: 0x00985565 File Offset: 0x00983765
		// (set) Token: 0x060238CF RID: 145615 RVA: 0x00985579 File Offset: 0x00983779
		public unsafe UStaticMesh inputStaticMesh_ForBPL_
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMesh>(base.NativePtr / (IntPtr)sizeof(void*) + BP_AClusterBallons_2_C.__PropertyOffset_16);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_AClusterBallons_2_C.__PropertyOffset_16, value);
			}
		}

		// Token: 0x1700470D RID: 18189
		// (get) Token: 0x060238D0 RID: 145616 RVA: 0x0098558E File Offset: 0x0098378E
		// (set) Token: 0x060238D1 RID: 145617 RVA: 0x0098559E File Offset: 0x0098379E
		public unsafe bool extraOneMaterial
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_AClusterBallons_2_C.__PropertyOffset_17) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_AClusterBallons_2_C.__PropertyOffset_17) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700470E RID: 18190
		// (get) Token: 0x060238D2 RID: 145618 RVA: 0x009855AF File Offset: 0x009837AF
		// (set) Token: 0x060238D3 RID: 145619 RVA: 0x009855C3 File Offset: 0x009837C3
		public unsafe UMaterialInstance InputMat1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_AClusterBallons_2_C.__PropertyOffset_18);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_AClusterBallons_2_C.__PropertyOffset_18, value);
			}
		}

		// Token: 0x1700470F RID: 18191
		// (get) Token: 0x060238D4 RID: 145620 RVA: 0x009855D8 File Offset: 0x009837D8
		// (set) Token: 0x060238D5 RID: 145621 RVA: 0x009855EC File Offset: 0x009837EC
		public unsafe UMaterialInstanceDynamic MID1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_AClusterBallons_2_C.__PropertyOffset_19);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_AClusterBallons_2_C.__PropertyOffset_19, value);
			}
		}

		// Token: 0x17004710 RID: 18192
		// (get) Token: 0x060238D6 RID: 145622 RVA: 0x00985601 File Offset: 0x00983801
		// (set) Token: 0x060238D7 RID: 145623 RVA: 0x00985611 File Offset: 0x00983811
		public unsafe bool StopBP
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_AClusterBallons_2_C.__PropertyOffset_20) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_AClusterBallons_2_C.__PropertyOffset_20) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004711 RID: 18193
		// (get) Token: 0x060238D8 RID: 145624 RVA: 0x00985622 File Offset: 0x00983822
		// (set) Token: 0x060238D9 RID: 145625 RVA: 0x00985632 File Offset: 0x00983832
		public unsafe bool UseYCount
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_AClusterBallons_2_C.__PropertyOffset_21) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_AClusterBallons_2_C.__PropertyOffset_21) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004712 RID: 18194
		// (get) Token: 0x060238DA RID: 145626 RVA: 0x00985643 File Offset: 0x00983843
		// (set) Token: 0x060238DB RID: 145627 RVA: 0x00985657 File Offset: 0x00983857
		public unsafe FVector WeaponPosition
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_AClusterBallons_2_C.__PropertyOffset_22);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_AClusterBallons_2_C.__PropertyOffset_22) = value;
			}
		}

		// Token: 0x17004713 RID: 18195
		// (get) Token: 0x060238DC RID: 145628 RVA: 0x0098566C File Offset: 0x0098386C
		// (set) Token: 0x060238DD RID: 145629 RVA: 0x00985680 File Offset: 0x00983880
		public unsafe FVector LastWeaponPosition
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_AClusterBallons_2_C.__PropertyOffset_23);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_AClusterBallons_2_C.__PropertyOffset_23) = value;
			}
		}

		// Token: 0x17004714 RID: 18196
		// (get) Token: 0x060238DE RID: 145630 RVA: 0x00985695 File Offset: 0x00983895
		// (set) Token: 0x060238DF RID: 145631 RVA: 0x009856A5 File Offset: 0x009838A5
		public unsafe bool alreadyBuildArr
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_AClusterBallons_2_C.__PropertyOffset_24) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_AClusterBallons_2_C.__PropertyOffset_24) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004715 RID: 18197
		// (get) Token: 0x060238E0 RID: 145632 RVA: 0x009856B6 File Offset: 0x009838B6
		// (set) Token: 0x060238E1 RID: 145633 RVA: 0x009856C6 File Offset: 0x009838C6
		public unsafe bool initOverlap
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_AClusterBallons_2_C.__PropertyOffset_25) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_AClusterBallons_2_C.__PropertyOffset_25) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004716 RID: 18198
		// (get) Token: 0x060238E2 RID: 145634 RVA: 0x009856D7 File Offset: 0x009838D7
		// (set) Token: 0x060238E3 RID: 145635 RVA: 0x009856E7 File Offset: 0x009838E7
		public unsafe bool PlatformCheck
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_AClusterBallons_2_C.__PropertyOffset_26) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_AClusterBallons_2_C.__PropertyOffset_26) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004717 RID: 18199
		// (get) Token: 0x060238E4 RID: 145636 RVA: 0x009856F8 File Offset: 0x009838F8
		// (set) Token: 0x060238E5 RID: 145637 RVA: 0x00985708 File Offset: 0x00983908
		public unsafe bool bAfterBeginplay
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_AClusterBallons_2_C.__PropertyOffset_27) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_AClusterBallons_2_C.__PropertyOffset_27) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004718 RID: 18200
		// (get) Token: 0x060238E6 RID: 145638 RVA: 0x00985719 File Offset: 0x00983919
		// (set) Token: 0x060238E7 RID: 145639 RVA: 0x0098572D File Offset: 0x0098392D
		public unsafe UChildActorComponent EditorTicker
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_AClusterBallons_2_C.__PropertyOffset_28);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_AClusterBallons_2_C.__PropertyOffset_28, value);
			}
		}

		// Token: 0x17004719 RID: 18201
		// (get) Token: 0x060238E8 RID: 145640 RVA: 0x00985742 File Offset: 0x00983942
		// (set) Token: 0x060238E9 RID: 145641 RVA: 0x00985752 File Offset: 0x00983952
		public unsafe int YCount_0
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_AClusterBallons_2_C.__PropertyOffset_29);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_AClusterBallons_2_C.__PropertyOffset_29) = value;
			}
		}

		// Token: 0x1700471A RID: 18202
		// (get) Token: 0x060238EA RID: 145642 RVA: 0x00985763 File Offset: 0x00983963
		// (set) Token: 0x060238EB RID: 145643 RVA: 0x00985777 File Offset: 0x00983977
		public unsafe UTextureRenderTarget2D RT_N
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_AClusterBallons_2_C.__PropertyOffset_30);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_AClusterBallons_2_C.__PropertyOffset_30, value);
			}
		}

		// Token: 0x060238EC RID: 145644 RVA: 0x0098578C File Offset: 0x0098398C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_AClusterBallons_2_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x060238ED RID: 145645 RVA: 0x009857A0 File Offset: 0x009839A0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_AClusterBallons_2_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060238EE RID: 145646 RVA: 0x009857B5 File Offset: 0x009839B5
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_AClusterBallons_2_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x060238EF RID: 145647 RVA: 0x009857C9 File Offset: 0x009839C9
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_AClusterBallons_2_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060238F0 RID: 145648 RVA: 0x009857E0 File Offset: 0x009839E0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_AClusterBallons_2_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_AClusterBallons_2_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_AClusterBallons_2_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_AClusterBallons_2_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_AClusterBallons_2_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060238F1 RID: 145649 RVA: 0x00985828 File Offset: 0x00983A28
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_AClusterBallons_2_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_AClusterBallons_2_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_AClusterBallons_2_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_AClusterBallons_2_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_AClusterBallons_2_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060238F2 RID: 145650 RVA: 0x00985870 File Offset: 0x00983A70
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveEndPlay(EEndPlayReason EndPlayReason)
		{
			BP_AClusterBallons_2_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_AClusterBallons_2_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_AClusterBallons_2_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_AClusterBallons_2_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_AClusterBallons_2_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060238F3 RID: 145651 RVA: 0x009858BC File Offset: 0x00983ABC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveEndPlay_Implementation(EEndPlayReason EndPlayReason)
		{
			BP_AClusterBallons_2_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_AClusterBallons_2_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_AClusterBallons_2_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_AClusterBallons_2_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_AClusterBallons_2_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060238F4 RID: 145652 RVA: 0x00985908 File Offset: 0x00983B08
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_RPBD_xpbd_test_K2Node_ComponentBoundEvent_1_ComponentHitSignature__DelegateSignature(UPrimitiveComponent HitComponent, AActor OtherActor, UPrimitiveComponent OtherComp, FVector NormalImpulse, in FHitResult Hit)
		{
			BP_AClusterBallons_2_C.__BndEvt__BP_RPBD_xpbd_test_K2Node_ComponentBoundEvent_1_ComponentHitSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_AClusterBallons_2_C.__BndEvt__BP_RPBD_xpbd_test_K2Node_ComponentBoundEvent_1_ComponentHitSignature__DelegateSignature_FunctionParams[(UIntPtr)199] + 15L / (long)sizeof(BP_AClusterBallons_2_C.__BndEvt__BP_RPBD_xpbd_test_K2Node_ComponentBoundEvent_1_ComponentHitSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_AClusterBallons_2_C.__BndEvt__BP_RPBD_xpbd_test_K2Node_ComponentBoundEvent_1_ComponentHitSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->HitComponent = ((HitComponent != null) ? HitComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->NormalImpulse = NormalImpulse;
			if (Hit != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FHitResult.StaticStruct(), &ptr->Hit, Hit.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_AClusterBallons_2_C.__BndEvt__BP_RPBD_xpbd_test_K2Node_ComponentBoundEvent_1_ComponentHitSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060238F5 RID: 145653 RVA: 0x009859BC File Offset: 0x00983BBC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex, bool bFromSweep, in FHitResult SweepResult)
		{
			BP_AClusterBallons_2_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_AClusterBallons_2_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)199] + 15L / (long)sizeof(BP_AClusterBallons_2_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_AClusterBallons_2_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			ptr->bFromSweep = bFromSweep;
			if (SweepResult != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FHitResult.StaticStruct(), &ptr->SweepResult, SweepResult.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_AClusterBallons_2_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060238F6 RID: 145654 RVA: 0x00985A78 File Offset: 0x00983C78
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex)
		{
			BP_AClusterBallons_2_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_AClusterBallons_2_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_AClusterBallons_2_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_AClusterBallons_2_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_AClusterBallons_2_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060238F7 RID: 145655 RVA: 0x00985B04 File Offset: 0x00983D04
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void OnWeaponInteraction(FVectorDouble OriginPoint, BP_SceneBattleInteract_C Config, int Id)
		{
			BP_AClusterBallons_2_C.__OnWeaponInteraction_FunctionParams* ptr = stackalloc BP_AClusterBallons_2_C.__OnWeaponInteraction_FunctionParams[(UIntPtr)55] + 15L / (long)sizeof(BP_AClusterBallons_2_C.__OnWeaponInteraction_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_AClusterBallons_2_C.__OnWeaponInteraction_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OriginPoint = OriginPoint;
			ptr->Config = ((Config != null) ? Config.NativePtr : IntPtr.Zero);
			ptr->Id = Id;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_AClusterBallons_2_C.__OnWeaponInteraction_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060238F8 RID: 145656 RVA: 0x00985B67 File Offset: 0x00983D67
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EditorTick()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_AClusterBallons_2_C.__EditorTick_NativeFunctionPtr, null);
		}

		// Token: 0x060238F9 RID: 145657 RVA: 0x00985B7C File Offset: 0x00983D7C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_AClusterBallons_2(int EntryPoint)
		{
			BP_AClusterBallons_2_C.__ExecuteUbergraph_BP_AClusterBallons_2_FunctionParams* ptr = stackalloc BP_AClusterBallons_2_C.__ExecuteUbergraph_BP_AClusterBallons_2_FunctionParams[(UIntPtr)3007] + 15L / (long)sizeof(BP_AClusterBallons_2_C.__ExecuteUbergraph_BP_AClusterBallons_2_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_AClusterBallons_2_C.__ExecuteUbergraph_BP_AClusterBallons_2_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_AClusterBallons_2_C.__ExecuteUbergraph_BP_AClusterBallons_2_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060238FA RID: 145658 RVA: 0x00985BC6 File Offset: 0x00983DC6
		protected BP_AClusterBallons_2_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401219A RID: 74138
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/AClusterBalloons/BP_AClusterBallons_2.BP_AClusterBallons_2_C";

		// Token: 0x0401219B RID: 74139
		private static IntPtr _ClassPtr;

		// Token: 0x0401219C RID: 74140
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401219D RID: 74141
		internal static int __PropertyOffset_0;

		// Token: 0x0401219E RID: 74142
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0401219F RID: 74143
		internal static int __PropertyOffset_1;

		// Token: 0x040121A0 RID: 74144
		internal static int __PropertyOffset_2;

		// Token: 0x040121A1 RID: 74145
		internal static int __PropertyOffset_3;

		// Token: 0x040121A2 RID: 74146
		internal static int __PropertyOffset_4;

		// Token: 0x040121A3 RID: 74147
		internal static int __PropertyOffset_5;

		// Token: 0x040121A4 RID: 74148
		internal static int __PropertyOffset_6;

		// Token: 0x040121A5 RID: 74149
		internal static int __PropertyOffset_7;

		// Token: 0x040121A6 RID: 74150
		internal static int __PropertyOffset_8;

		// Token: 0x040121A7 RID: 74151
		internal static int __PropertyOffset_9;

		// Token: 0x040121A8 RID: 74152
		internal static int __PropertyOffset_10;

		// Token: 0x040121A9 RID: 74153
		internal static int __PropertyOffset_11;

		// Token: 0x040121AA RID: 74154
		internal static int __PropertyOffset_12;

		// Token: 0x040121AB RID: 74155
		internal static int __PropertyOffset_13;

		// Token: 0x040121AC RID: 74156
		internal static int __PropertyOffset_14;

		// Token: 0x040121AD RID: 74157
		internal static int __PropertyOffset_15;

		// Token: 0x040121AE RID: 74158
		internal static int __PropertyOffset_16;

		// Token: 0x040121AF RID: 74159
		internal static int __PropertyOffset_17;

		// Token: 0x040121B0 RID: 74160
		internal static int __PropertyOffset_18;

		// Token: 0x040121B1 RID: 74161
		internal static int __PropertyOffset_19;

		// Token: 0x040121B2 RID: 74162
		internal static int __PropertyOffset_20;

		// Token: 0x040121B3 RID: 74163
		internal static int __PropertyOffset_21;

		// Token: 0x040121B4 RID: 74164
		internal static int __PropertyOffset_22;

		// Token: 0x040121B5 RID: 74165
		internal static int __PropertyOffset_23;

		// Token: 0x040121B6 RID: 74166
		internal static int __PropertyOffset_24;

		// Token: 0x040121B7 RID: 74167
		internal static int __PropertyOffset_25;

		// Token: 0x040121B8 RID: 74168
		internal static int __PropertyOffset_26;

		// Token: 0x040121B9 RID: 74169
		internal static int __PropertyOffset_27;

		// Token: 0x040121BA RID: 74170
		internal static int __PropertyOffset_28;

		// Token: 0x040121BB RID: 74171
		internal static int __PropertyOffset_29;

		// Token: 0x040121BC RID: 74172
		internal static int __PropertyOffset_30;

		// Token: 0x040121BD RID: 74173
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x040121BE RID: 74174
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x040121BF RID: 74175
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x040121C0 RID: 74176
		private static IntPtr __ReceiveEndPlay_NativeFunctionPtr;

		// Token: 0x040121C1 RID: 74177
		private static IntPtr __BndEvt__BP_RPBD_xpbd_test_K2Node_ComponentBoundEvent_1_ComponentHitSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x040121C2 RID: 74178
		private static IntPtr __BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x040121C3 RID: 74179
		private static IntPtr __BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x040121C4 RID: 74180
		private static IntPtr __OnWeaponInteraction_NativeFunctionPtr;

		// Token: 0x040121C5 RID: 74181
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x040121C6 RID: 74182
		private static IntPtr __ExecuteUbergraph_BP_AClusterBallons_2_NativeFunctionPtr;

		// Token: 0x02009CFF RID: 40191
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x0403269F RID: 206495
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009D00 RID: 40192
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __ReceiveEndPlay_FunctionParams
		{
			// Token: 0x040326A0 RID: 206496
			[FieldOffset(0)]
			public TEnumAsByte<EEndPlayReason> EndPlayReason;
		}

		// Token: 0x02009D01 RID: 40193
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 184)]
		protected ref struct __BndEvt__BP_RPBD_xpbd_test_K2Node_ComponentBoundEvent_1_ComponentHitSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x040326A1 RID: 206497
			[FieldOffset(0)]
			public IntPtr HitComponent;

			// Token: 0x040326A2 RID: 206498
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x040326A3 RID: 206499
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x040326A4 RID: 206500
			[FieldOffset(24)]
			public FVector NormalImpulse;

			// Token: 0x040326A5 RID: 206501
			[FieldOffset(36)]
			public byte Hit;
		}

		// Token: 0x02009D02 RID: 40194
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 184)]
		protected ref struct __BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x040326A6 RID: 206502
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x040326A7 RID: 206503
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x040326A8 RID: 206504
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x040326A9 RID: 206505
			[FieldOffset(24)]
			public int OtherBodyIndex;

			// Token: 0x040326AA RID: 206506
			[FieldOffset(28)]
			public bool bFromSweep;

			// Token: 0x040326AB RID: 206507
			[FieldOffset(32)]
			public byte SweepResult;
		}

		// Token: 0x02009D03 RID: 40195
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x040326AC RID: 206508
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x040326AD RID: 206509
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x040326AE RID: 206510
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x040326AF RID: 206511
			[FieldOffset(24)]
			public int OtherBodyIndex;
		}

		// Token: 0x02009D04 RID: 40196
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 40)]
		protected ref struct __OnWeaponInteraction_FunctionParams
		{
			// Token: 0x040326B0 RID: 206512
			[FieldOffset(0)]
			public FVectorDouble OriginPoint;

			// Token: 0x040326B1 RID: 206513
			[FieldOffset(24)]
			public IntPtr Config;

			// Token: 0x040326B2 RID: 206514
			[FieldOffset(32)]
			public int Id;
		}

		// Token: 0x02009D05 RID: 40197
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 2992)]
		protected ref struct __ExecuteUbergraph_BP_AClusterBallons_2_FunctionParams
		{
			// Token: 0x040326B3 RID: 206515
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
