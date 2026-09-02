using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Render.RuntimeBP.PCG.Physics_Actor;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.SwingInteraction
{
	// Token: 0x02003A41 RID: 14913
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/SwingInteraction/BP_QiuQian.BP_QiuQian_C")]
	[UnrealStructLayout(1584, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1580)]
	public class BP_QiuQian_C : BP_PhysicsActor_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601ECEC RID: 126188 RVA: 0x008FF0EF File Offset: 0x008FD2EF
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_QiuQian_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/SwingInteraction/BP_QiuQian.BP_QiuQian_C");
			}
			return BP_QiuQian_C._ClassPtr;
		}

		// Token: 0x0601ECED RID: 126189 RVA: 0x008FF114 File Offset: 0x008FD314
		public BP_QiuQian_C() : this(BuiltinUtils.AllocNativeUObject(BP_QiuQian_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601ECEE RID: 126190 RVA: 0x008FF13C File Offset: 0x008FD33C
		[NullableContext(1)]
		public BP_QiuQian_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_QiuQian_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17002C89 RID: 11401
		// (get) Token: 0x0601ECEF RID: 126191 RVA: 0x008FF170 File Offset: 0x008FD370
		// (set) Token: 0x0601ECF0 RID: 126192 RVA: 0x008FF1A9 File Offset: 0x008FD3A9
		[Nullable(1)]
		public new FPointerToUberGraphFrame UberGraphFrame
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_QiuQian_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_QiuQian_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17002C8A RID: 11402
		// (get) Token: 0x0601ECF1 RID: 126193 RVA: 0x008FF1CA File Offset: 0x008FD3CA
		// (set) Token: 0x0601ECF2 RID: 126194 RVA: 0x008FF1DE File Offset: 0x008FD3DE
		public unsafe UStaticMeshComponent SM_SwingSingleRopeR
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_QiuQian_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_QiuQian_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17002C8B RID: 11403
		// (get) Token: 0x0601ECF3 RID: 126195 RVA: 0x008FF1F3 File Offset: 0x008FD3F3
		// (set) Token: 0x0601ECF4 RID: 126196 RVA: 0x008FF207 File Offset: 0x008FD407
		public unsafe UStaticMeshComponent SM_SwingSingleRopeL
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_QiuQian_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_QiuQian_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17002C8C RID: 11404
		// (get) Token: 0x0601ECF5 RID: 126197 RVA: 0x008FF21C File Offset: 0x008FD41C
		// (set) Token: 0x0601ECF6 RID: 126198 RVA: 0x008FF230 File Offset: 0x008FD430
		public unsafe UStaticMeshComponent SM_SwingTop
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_QiuQian_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_QiuQian_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17002C8D RID: 11405
		// (get) Token: 0x0601ECF7 RID: 126199 RVA: 0x008FF245 File Offset: 0x008FD445
		// (set) Token: 0x0601ECF8 RID: 126200 RVA: 0x008FF259 File Offset: 0x008FD459
		public unsafe UStaticMeshComponent StaticMesh_0
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_QiuQian_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_QiuQian_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17002C8E RID: 11406
		// (get) Token: 0x0601ECF9 RID: 126201 RVA: 0x008FF270 File Offset: 0x008FD470
		// (set) Token: 0x0601ECFA RID: 126202 RVA: 0x008FF2A9 File Offset: 0x008FD4A9
		[Nullable(1)]
		public TArray<FName> NameList
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<FName> result;
				if ((result = this._NameList) == null)
				{
					result = (this._NameList = new TArray<FName>(base.NativePtr + (IntPtr)BP_QiuQian_C.__PropertyOffset_5, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.NameList.CopyAssign(value);
			}
		}

		// Token: 0x17002C8F RID: 11407
		// (get) Token: 0x0601ECFB RID: 126203 RVA: 0x008FF2B7 File Offset: 0x008FD4B7
		// (set) Token: 0x0601ECFC RID: 126204 RVA: 0x008FF2C7 File Offset: 0x008FD4C7
		public unsafe bool debugDraw
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_QiuQian_C.__PropertyOffset_6) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_QiuQian_C.__PropertyOffset_6) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002C90 RID: 11408
		// (get) Token: 0x0601ECFD RID: 126205 RVA: 0x008FF2D8 File Offset: 0x008FD4D8
		// (set) Token: 0x0601ECFE RID: 126206 RVA: 0x008FF2E8 File Offset: 0x008FD4E8
		public unsafe bool bUseConstantDt
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_QiuQian_C.__PropertyOffset_7) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_QiuQian_C.__PropertyOffset_7) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002C91 RID: 11409
		// (get) Token: 0x0601ECFF RID: 126207 RVA: 0x008FF2F9 File Offset: 0x008FD4F9
		// (set) Token: 0x0601ED00 RID: 126208 RVA: 0x008FF309 File Offset: 0x008FD509
		public unsafe float ConstantDt
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_QiuQian_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_QiuQian_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17002C92 RID: 11410
		// (get) Token: 0x0601ED01 RID: 126209 RVA: 0x008FF31A File Offset: 0x008FD51A
		// (set) Token: 0x0601ED02 RID: 126210 RVA: 0x008FF32E File Offset: 0x008FD52E
		public unsafe FVector StartOffset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_QiuQian_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_QiuQian_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17002C93 RID: 11411
		// (get) Token: 0x0601ED03 RID: 126211 RVA: 0x008FF343 File Offset: 0x008FD543
		// (set) Token: 0x0601ED04 RID: 126212 RVA: 0x008FF353 File Offset: 0x008FD553
		public unsafe int particleCount
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_QiuQian_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_QiuQian_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17002C94 RID: 11412
		// (get) Token: 0x0601ED05 RID: 126213 RVA: 0x008FF364 File Offset: 0x008FD564
		// (set) Token: 0x0601ED06 RID: 126214 RVA: 0x008FF374 File Offset: 0x008FD574
		public unsafe float linkDis
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_QiuQian_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_QiuQian_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17002C95 RID: 11413
		// (get) Token: 0x0601ED07 RID: 126215 RVA: 0x008FF385 File Offset: 0x008FD585
		// (set) Token: 0x0601ED08 RID: 126216 RVA: 0x008FF399 File Offset: 0x008FD599
		public unsafe FVector accel_ext
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_QiuQian_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_QiuQian_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17002C96 RID: 11414
		// (get) Token: 0x0601ED09 RID: 126217 RVA: 0x008FF3AE File Offset: 0x008FD5AE
		// (set) Token: 0x0601ED0A RID: 126218 RVA: 0x008FF3BE File Offset: 0x008FD5BE
		public unsafe float collisionR
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_QiuQian_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_QiuQian_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x17002C97 RID: 11415
		// (get) Token: 0x0601ED0B RID: 126219 RVA: 0x008FF3CF File Offset: 0x008FD5CF
		// (set) Token: 0x0601ED0C RID: 126220 RVA: 0x008FF3DF File Offset: 0x008FD5DF
		public unsafe float volDamping
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_QiuQian_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_QiuQian_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x17002C98 RID: 11416
		// (get) Token: 0x0601ED0D RID: 126221 RVA: 0x008FF3F0 File Offset: 0x008FD5F0
		// (set) Token: 0x0601ED0E RID: 126222 RVA: 0x008FF404 File Offset: 0x008FD604
		public unsafe FVector startPos
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_QiuQian_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_QiuQian_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x17002C99 RID: 11417
		// (get) Token: 0x0601ED0F RID: 126223 RVA: 0x008FF419 File Offset: 0x008FD619
		// (set) Token: 0x0601ED10 RID: 126224 RVA: 0x008FF42D File Offset: 0x008FD62D
		public unsafe FVector endPos
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_QiuQian_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_QiuQian_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x17002C9A RID: 11418
		// (get) Token: 0x0601ED11 RID: 126225 RVA: 0x008FF442 File Offset: 0x008FD642
		// (set) Token: 0x0601ED12 RID: 126226 RVA: 0x008FF456 File Offset: 0x008FD656
		public unsafe FVector leftPos
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_QiuQian_C.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_QiuQian_C.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x17002C9B RID: 11419
		// (get) Token: 0x0601ED13 RID: 126227 RVA: 0x008FF46B File Offset: 0x008FD66B
		// (set) Token: 0x0601ED14 RID: 126228 RVA: 0x008FF47F File Offset: 0x008FD67F
		public unsafe FVector rightPos
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_QiuQian_C.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_QiuQian_C.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x17002C9C RID: 11420
		// (get) Token: 0x0601ED15 RID: 126229 RVA: 0x008FF494 File Offset: 0x008FD694
		// (set) Token: 0x0601ED16 RID: 126230 RVA: 0x008FF4A8 File Offset: 0x008FD6A8
		public unsafe FVector leftNorm
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_QiuQian_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_QiuQian_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x17002C9D RID: 11421
		// (get) Token: 0x0601ED17 RID: 126231 RVA: 0x008FF4C0 File Offset: 0x008FD6C0
		// (set) Token: 0x0601ED18 RID: 126232 RVA: 0x008FF4F9 File Offset: 0x008FD6F9
		[Nullable(1)]
		public TArray<FParticle_QiuQian> particleArr
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<FParticle_QiuQian> result;
				if ((result = this._particleArr) == null)
				{
					result = (this._particleArr = new TArray<FParticle_QiuQian>(base.NativePtr + (IntPtr)BP_QiuQian_C.__PropertyOffset_20, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.particleArr.CopyAssign(value);
			}
		}

		// Token: 0x17002C9E RID: 11422
		// (get) Token: 0x0601ED19 RID: 126233 RVA: 0x008FF507 File Offset: 0x008FD707
		// (set) Token: 0x0601ED1A RID: 126234 RVA: 0x008FF51B File Offset: 0x008FD71B
		public unsafe FVector rightNorm
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_QiuQian_C.__PropertyOffset_21);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_QiuQian_C.__PropertyOffset_21) = value;
			}
		}

		// Token: 0x17002C9F RID: 11423
		// (get) Token: 0x0601ED1B RID: 126235 RVA: 0x008FF530 File Offset: 0x008FD730
		// (set) Token: 0x0601ED1C RID: 126236 RVA: 0x008FF540 File Offset: 0x008FD740
		public unsafe float pushStrength
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_QiuQian_C.__PropertyOffset_22);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_QiuQian_C.__PropertyOffset_22) = value;
			}
		}

		// Token: 0x17002CA0 RID: 11424
		// (get) Token: 0x0601ED1D RID: 126237 RVA: 0x008FF551 File Offset: 0x008FD751
		// (set) Token: 0x0601ED1E RID: 126238 RVA: 0x008FF561 File Offset: 0x008FD761
		public unsafe float endParticleMassScale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_QiuQian_C.__PropertyOffset_23);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_QiuQian_C.__PropertyOffset_23) = value;
			}
		}

		// Token: 0x17002CA1 RID: 11425
		// (get) Token: 0x0601ED1F RID: 126239 RVA: 0x008FF572 File Offset: 0x008FD772
		// (set) Token: 0x0601ED20 RID: 126240 RVA: 0x008FF582 File Offset: 0x008FD782
		public unsafe float debugDrawDuration
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_QiuQian_C.__PropertyOffset_24);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_QiuQian_C.__PropertyOffset_24) = value;
			}
		}

		// Token: 0x17002CA2 RID: 11426
		// (get) Token: 0x0601ED21 RID: 126241 RVA: 0x008FF593 File Offset: 0x008FD793
		// (set) Token: 0x0601ED22 RID: 126242 RVA: 0x008FF5A3 File Offset: 0x008FD7A3
		public unsafe bool IsEnable
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_QiuQian_C.__PropertyOffset_25) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_QiuQian_C.__PropertyOffset_25) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002CA3 RID: 11427
		// (get) Token: 0x0601ED23 RID: 126243 RVA: 0x008FF5B4 File Offset: 0x008FD7B4
		// (set) Token: 0x0601ED24 RID: 126244 RVA: 0x008FF5C4 File Offset: 0x008FD7C4
		public unsafe bool IsPC
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_QiuQian_C.__PropertyOffset_26) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_QiuQian_C.__PropertyOffset_26) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002CA4 RID: 11428
		// (get) Token: 0x0601ED25 RID: 126245 RVA: 0x008FF5D5 File Offset: 0x008FD7D5
		// (set) Token: 0x0601ED26 RID: 126246 RVA: 0x008FF5E9 File Offset: 0x008FD7E9
		public unsafe UMaterialInstanceDynamic DMI_RopeL
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_QiuQian_C.__PropertyOffset_27);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_QiuQian_C.__PropertyOffset_27, value);
			}
		}

		// Token: 0x17002CA5 RID: 11429
		// (get) Token: 0x0601ED27 RID: 126247 RVA: 0x008FF5FE File Offset: 0x008FD7FE
		// (set) Token: 0x0601ED28 RID: 126248 RVA: 0x008FF612 File Offset: 0x008FD812
		public unsafe UMaterialInstanceDynamic DMI_RopeR
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_QiuQian_C.__PropertyOffset_28);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_QiuQian_C.__PropertyOffset_28, value);
			}
		}

		// Token: 0x17002CA6 RID: 11430
		// (get) Token: 0x0601ED29 RID: 126249 RVA: 0x008FF627 File Offset: 0x008FD827
		// (set) Token: 0x0601ED2A RID: 126250 RVA: 0x008FF637 File Offset: 0x008FD837
		public unsafe float MaxDistance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_QiuQian_C.__PropertyOffset_29);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_QiuQian_C.__PropertyOffset_29) = value;
			}
		}

		// Token: 0x17002CA7 RID: 11431
		// (get) Token: 0x0601ED2B RID: 126251 RVA: 0x008FF648 File Offset: 0x008FD848
		// (set) Token: 0x0601ED2C RID: 126252 RVA: 0x008FF658 File Offset: 0x008FD858
		public unsafe bool IsWarm
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_QiuQian_C.__PropertyOffset_30) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_QiuQian_C.__PropertyOffset_30) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002CA8 RID: 11432
		// (get) Token: 0x0601ED2D RID: 126253 RVA: 0x008FF669 File Offset: 0x008FD869
		// (set) Token: 0x0601ED2E RID: 126254 RVA: 0x008FF679 File Offset: 0x008FD879
		public unsafe float WarmTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_QiuQian_C.__PropertyOffset_31);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_QiuQian_C.__PropertyOffset_31) = value;
			}
		}

		// Token: 0x0601ED2F RID: 126255 RVA: 0x008FF68A File Offset: 0x008FD88A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void InitializeParticleArr()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_QiuQian_C.__InitializeParticleArr_NativeFunctionPtr, null);
		}

		// Token: 0x0601ED30 RID: 126256 RVA: 0x008FF6A0 File Offset: 0x008FD8A0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetDMIOffsetEnable(bool OffsetEnable)
		{
			BP_QiuQian_C.__SetDMIOffsetEnable_FunctionParams* ptr = stackalloc BP_QiuQian_C.__SetDMIOffsetEnable_FunctionParams[(UIntPtr)20] + 15L / (long)sizeof(BP_QiuQian_C.__SetDMIOffsetEnable_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_QiuQian_C.__SetDMIOffsetEnable_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OffsetEnable = OffsetEnable;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_QiuQian_C.__SetDMIOffsetEnable_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601ED31 RID: 126257 RVA: 0x008FF6E6 File Offset: 0x008FD8E6
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateaDMI()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_QiuQian_C.__UpdateaDMI_NativeFunctionPtr, null);
		}

		// Token: 0x0601ED32 RID: 126258 RVA: 0x008FF6FA File Offset: 0x008FD8FA
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void InitializeDMI()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_QiuQian_C.__InitializeDMI_NativeFunctionPtr, null);
		}

		// Token: 0x0601ED33 RID: 126259 RVA: 0x008FF710 File Offset: 0x008FD910
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void solve(bool isPinned, FVector pos, FVector linkPos, float targetLen, FVector emitterOriginPos, ref FVector pos_new)
		{
			BP_QiuQian_C.__solve_FunctionParams* ptr = stackalloc BP_QiuQian_C.__solve_FunctionParams[(UIntPtr)131] + 15L / (long)sizeof(BP_QiuQian_C.__solve_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_QiuQian_C.__solve_NativeFunctionPtr, (void*)ptr, 1);
			ptr->isPinned = isPinned;
			ptr->pos = pos;
			ptr->linkPos = linkPos;
			ptr->targetLen = targetLen;
			ptr->emitterOriginPos = emitterOriginPos;
			ptr->pos_new = pos_new;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_QiuQian_C.__solve_NativeFunctionPtr, (void*)ptr);
			pos_new = ptr->pos_new;
		}

		// Token: 0x0601ED34 RID: 126260 RVA: 0x008FF791 File Offset: 0x008FD991
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_QiuQian_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x0601ED35 RID: 126261 RVA: 0x008FF7A5 File Offset: 0x008FD9A5
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_QiuQian_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601ED36 RID: 126262 RVA: 0x008FF7BA File Offset: 0x008FD9BA
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_QiuQian_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0601ED37 RID: 126263 RVA: 0x008FF7CE File Offset: 0x008FD9CE
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_QiuQian_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601ED38 RID: 126264 RVA: 0x008FF7E4 File Offset: 0x008FD9E4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_QiuQian_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_QiuQian_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_QiuQian_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_QiuQian_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_QiuQian_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601ED39 RID: 126265 RVA: 0x008FF82C File Offset: 0x008FDA2C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_QiuQian_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_QiuQian_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_QiuQian_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_QiuQian_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_QiuQian_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601ED3A RID: 126266 RVA: 0x008FF873 File Offset: 0x008FDA73
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void place_plank_event()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_QiuQian_C.__place_plank_event_NativeFunctionPtr, null);
		}

		// Token: 0x0601ED3B RID: 126267 RVA: 0x008FF887 File Offset: 0x008FDA87
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void OnLogicEnable()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_QiuQian_C.__OnLogicEnable_NativeFunctionPtr, null);
		}

		// Token: 0x0601ED3C RID: 126268 RVA: 0x008FF89B File Offset: 0x008FDA9B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void OnLogicEnable_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_QiuQian_C.__OnLogicEnable_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601ED3D RID: 126269 RVA: 0x008FF8B0 File Offset: 0x008FDAB0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void OnLogicDisable()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_QiuQian_C.__OnLogicDisable_NativeFunctionPtr, null);
		}

		// Token: 0x0601ED3E RID: 126270 RVA: 0x008FF8C4 File Offset: 0x008FDAC4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void OnLogicDisable_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_QiuQian_C.__OnLogicDisable_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601ED3F RID: 126271 RVA: 0x008FF8DC File Offset: 0x008FDADC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_QiuQian(int EntryPoint)
		{
			BP_QiuQian_C.__ExecuteUbergraph_BP_QiuQian_FunctionParams* ptr = stackalloc BP_QiuQian_C.__ExecuteUbergraph_BP_QiuQian_FunctionParams[(UIntPtr)1855] + 15L / (long)sizeof(BP_QiuQian_C.__ExecuteUbergraph_BP_QiuQian_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_QiuQian_C.__ExecuteUbergraph_BP_QiuQian_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_QiuQian_C.__ExecuteUbergraph_BP_QiuQian_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601ED40 RID: 126272 RVA: 0x008FF926 File Offset: 0x008FDB26
		protected BP_QiuQian_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400F36A RID: 62314
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/SwingInteraction/BP_QiuQian.BP_QiuQian_C";

		// Token: 0x0400F36B RID: 62315
		private static IntPtr _ClassPtr;

		// Token: 0x0400F36C RID: 62316
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400F36D RID: 62317
		internal new static int __PropertyOffset_0;

		// Token: 0x0400F36E RID: 62318
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400F36F RID: 62319
		internal new static int __PropertyOffset_1;

		// Token: 0x0400F370 RID: 62320
		internal static int __PropertyOffset_2;

		// Token: 0x0400F371 RID: 62321
		internal static int __PropertyOffset_3;

		// Token: 0x0400F372 RID: 62322
		internal static int __PropertyOffset_4;

		// Token: 0x0400F373 RID: 62323
		internal static int __PropertyOffset_5;

		// Token: 0x0400F374 RID: 62324
		private TArray<FName> _NameList;

		// Token: 0x0400F375 RID: 62325
		internal static int __PropertyOffset_6;

		// Token: 0x0400F376 RID: 62326
		internal static int __PropertyOffset_7;

		// Token: 0x0400F377 RID: 62327
		internal static int __PropertyOffset_8;

		// Token: 0x0400F378 RID: 62328
		internal static int __PropertyOffset_9;

		// Token: 0x0400F379 RID: 62329
		internal static int __PropertyOffset_10;

		// Token: 0x0400F37A RID: 62330
		internal static int __PropertyOffset_11;

		// Token: 0x0400F37B RID: 62331
		internal static int __PropertyOffset_12;

		// Token: 0x0400F37C RID: 62332
		internal static int __PropertyOffset_13;

		// Token: 0x0400F37D RID: 62333
		internal static int __PropertyOffset_14;

		// Token: 0x0400F37E RID: 62334
		internal static int __PropertyOffset_15;

		// Token: 0x0400F37F RID: 62335
		internal static int __PropertyOffset_16;

		// Token: 0x0400F380 RID: 62336
		internal static int __PropertyOffset_17;

		// Token: 0x0400F381 RID: 62337
		internal static int __PropertyOffset_18;

		// Token: 0x0400F382 RID: 62338
		internal static int __PropertyOffset_19;

		// Token: 0x0400F383 RID: 62339
		internal static int __PropertyOffset_20;

		// Token: 0x0400F384 RID: 62340
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<FParticle_QiuQian> _particleArr;

		// Token: 0x0400F385 RID: 62341
		internal static int __PropertyOffset_21;

		// Token: 0x0400F386 RID: 62342
		internal static int __PropertyOffset_22;

		// Token: 0x0400F387 RID: 62343
		internal static int __PropertyOffset_23;

		// Token: 0x0400F388 RID: 62344
		internal static int __PropertyOffset_24;

		// Token: 0x0400F389 RID: 62345
		internal static int __PropertyOffset_25;

		// Token: 0x0400F38A RID: 62346
		internal static int __PropertyOffset_26;

		// Token: 0x0400F38B RID: 62347
		internal static int __PropertyOffset_27;

		// Token: 0x0400F38C RID: 62348
		internal static int __PropertyOffset_28;

		// Token: 0x0400F38D RID: 62349
		internal static int __PropertyOffset_29;

		// Token: 0x0400F38E RID: 62350
		internal static int __PropertyOffset_30;

		// Token: 0x0400F38F RID: 62351
		internal static int __PropertyOffset_31;

		// Token: 0x0400F390 RID: 62352
		private static IntPtr __InitializeParticleArr_NativeFunctionPtr;

		// Token: 0x0400F391 RID: 62353
		private static IntPtr __SetDMIOffsetEnable_NativeFunctionPtr;

		// Token: 0x0400F392 RID: 62354
		private static IntPtr __UpdateaDMI_NativeFunctionPtr;

		// Token: 0x0400F393 RID: 62355
		private static IntPtr __InitializeDMI_NativeFunctionPtr;

		// Token: 0x0400F394 RID: 62356
		private static IntPtr __solve_NativeFunctionPtr;

		// Token: 0x0400F395 RID: 62357
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x0400F396 RID: 62358
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0400F397 RID: 62359
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0400F398 RID: 62360
		private static IntPtr __place_plank_event_NativeFunctionPtr;

		// Token: 0x0400F399 RID: 62361
		private static IntPtr __OnLogicEnable_NativeFunctionPtr;

		// Token: 0x0400F39A RID: 62362
		private static IntPtr __OnLogicDisable_NativeFunctionPtr;

		// Token: 0x0400F39B RID: 62363
		private static IntPtr __ExecuteUbergraph_BP_QiuQian_NativeFunctionPtr;

		// Token: 0x02009807 RID: 38919
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 5)]
		protected ref struct __SetDMIOffsetEnable_FunctionParams
		{
			// Token: 0x04031E06 RID: 204294
			[FieldOffset(0)]
			public bool OffsetEnable;
		}

		// Token: 0x02009808 RID: 38920
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 116)]
		protected ref struct __solve_FunctionParams
		{
			// Token: 0x04031E07 RID: 204295
			[FieldOffset(0)]
			public bool isPinned;

			// Token: 0x04031E08 RID: 204296
			[FieldOffset(4)]
			public FVector pos;

			// Token: 0x04031E09 RID: 204297
			[FieldOffset(16)]
			public FVector linkPos;

			// Token: 0x04031E0A RID: 204298
			[FieldOffset(28)]
			public float targetLen;

			// Token: 0x04031E0B RID: 204299
			[FieldOffset(32)]
			public FVector emitterOriginPos;

			// Token: 0x04031E0C RID: 204300
			[FieldOffset(44)]
			public FVector pos_new;
		}

		// Token: 0x02009809 RID: 38921
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04031E0D RID: 204301
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x0200980A RID: 38922
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1840)]
		protected ref struct __ExecuteUbergraph_BP_QiuQian_FunctionParams
		{
			// Token: 0x04031E0E RID: 204302
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
