using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Core.Fight;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.GPUBoxSimulation
{
	// Token: 0x02003C27 RID: 15399
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/GPUBoxSimulation/BP_genCloth.BP_genCloth_C")]
	[UnrealStructLayout(1720, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1716)]
	public class BP_genCloth_C : AKuroCSGenericCloth, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06023361 RID: 144225 RVA: 0x0097C063 File Offset: 0x0097A263
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_genCloth_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/GPUBoxSimulation/BP_genCloth.BP_genCloth_C");
			}
			return BP_genCloth_C._ClassPtr;
		}

		// Token: 0x06023362 RID: 144226 RVA: 0x0097C088 File Offset: 0x0097A288
		public BP_genCloth_C() : this(BuiltinUtils.AllocNativeUObject(BP_genCloth_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06023363 RID: 144227 RVA: 0x0097C0B0 File Offset: 0x0097A2B0
		[NullableContext(1)]
		public BP_genCloth_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_genCloth_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17004512 RID: 17682
		// (get) Token: 0x06023364 RID: 144228 RVA: 0x0097C0E4 File Offset: 0x0097A2E4
		// (set) Token: 0x06023365 RID: 144229 RVA: 0x0097C11D File Offset: 0x0097A31D
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_genCloth_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_genCloth_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17004513 RID: 17683
		// (get) Token: 0x06023366 RID: 144230 RVA: 0x0097C13E File Offset: 0x0097A33E
		// (set) Token: 0x06023367 RID: 144231 RVA: 0x0097C152 File Offset: 0x0097A352
		public unsafe UBoxComponent ValidBox
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_genCloth_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_genCloth_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17004514 RID: 17684
		// (get) Token: 0x06023368 RID: 144232 RVA: 0x0097C167 File Offset: 0x0097A367
		// (set) Token: 0x06023369 RID: 144233 RVA: 0x0097C17B File Offset: 0x0097A37B
		public unsafe UStaticMeshComponent xpbd_test
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_genCloth_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_genCloth_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17004515 RID: 17685
		// (get) Token: 0x0602336A RID: 144234 RVA: 0x0097C190 File Offset: 0x0097A390
		// (set) Token: 0x0602336B RID: 144235 RVA: 0x0097C1A4 File Offset: 0x0097A3A4
		public unsafe UTextureRenderTarget2D RT_Pos
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_genCloth_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_genCloth_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17004516 RID: 17686
		// (get) Token: 0x0602336C RID: 144236 RVA: 0x0097C1B9 File Offset: 0x0097A3B9
		// (set) Token: 0x0602336D RID: 144237 RVA: 0x0097C1CD File Offset: 0x0097A3CD
		public unsafe UDataTable DT
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UDataTable>(base.NativePtr / (IntPtr)sizeof(void*) + BP_genCloth_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_genCloth_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17004517 RID: 17687
		// (get) Token: 0x0602336E RID: 144238 RVA: 0x0097C1E2 File Offset: 0x0097A3E2
		// (set) Token: 0x0602336F RID: 144239 RVA: 0x0097C1F6 File Offset: 0x0097A3F6
		public unsafe UMaterialInstanceDynamic MID
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_genCloth_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_genCloth_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x17004518 RID: 17688
		// (get) Token: 0x06023370 RID: 144240 RVA: 0x0097C20B File Offset: 0x0097A40B
		// (set) Token: 0x06023371 RID: 144241 RVA: 0x0097C21B File Offset: 0x0097A41B
		public unsafe bool debugDraw
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_genCloth_C.__PropertyOffset_6) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_genCloth_C.__PropertyOffset_6) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004519 RID: 17689
		// (get) Token: 0x06023372 RID: 144242 RVA: 0x0097C22C File Offset: 0x0097A42C
		// (set) Token: 0x06023373 RID: 144243 RVA: 0x0097C240 File Offset: 0x0097A440
		public unsafe UMaterialInstance InputMat
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_genCloth_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_genCloth_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x1700451A RID: 17690
		// (get) Token: 0x06023374 RID: 144244 RVA: 0x0097C255 File Offset: 0x0097A455
		// (set) Token: 0x06023375 RID: 144245 RVA: 0x0097C265 File Offset: 0x0097A465
		public unsafe float force
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_genCloth_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_genCloth_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x1700451B RID: 17691
		// (get) Token: 0x06023376 RID: 144246 RVA: 0x0097C276 File Offset: 0x0097A476
		// (set) Token: 0x06023377 RID: 144247 RVA: 0x0097C286 File Offset: 0x0097A486
		public unsafe bool Pressing
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_genCloth_C.__PropertyOffset_9) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_genCloth_C.__PropertyOffset_9) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700451C RID: 17692
		// (get) Token: 0x06023378 RID: 144248 RVA: 0x0097C297 File Offset: 0x0097A497
		// (set) Token: 0x06023379 RID: 144249 RVA: 0x0097C2A7 File Offset: 0x0097A4A7
		public unsafe bool FS_isPhysicSimulation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_genCloth_C.__PropertyOffset_10) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_genCloth_C.__PropertyOffset_10) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700451D RID: 17693
		// (get) Token: 0x0602337A RID: 144250 RVA: 0x0097C2B8 File Offset: 0x0097A4B8
		// (set) Token: 0x0602337B RID: 144251 RVA: 0x0097C2C8 File Offset: 0x0097A4C8
		public unsafe float mass_in_kg
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_genCloth_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_genCloth_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x1700451E RID: 17694
		// (get) Token: 0x0602337C RID: 144252 RVA: 0x0097C2D9 File Offset: 0x0097A4D9
		// (set) Token: 0x0602337D RID: 144253 RVA: 0x0097C2E9 File Offset: 0x0097A4E9
		public unsafe bool bEditorTick
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_genCloth_C.__PropertyOffset_12) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_genCloth_C.__PropertyOffset_12) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700451F RID: 17695
		// (get) Token: 0x0602337E RID: 144254 RVA: 0x0097C2FA File Offset: 0x0097A4FA
		// (set) Token: 0x0602337F RID: 144255 RVA: 0x0097C30A File Offset: 0x0097A50A
		public unsafe bool _2DRT
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_genCloth_C.__PropertyOffset_13) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_genCloth_C.__PropertyOffset_13) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004520 RID: 17696
		// (get) Token: 0x06023380 RID: 144256 RVA: 0x0097C31B File Offset: 0x0097A51B
		// (set) Token: 0x06023381 RID: 144257 RVA: 0x0097C32B File Offset: 0x0097A52B
		public unsafe int XCount_0
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_genCloth_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_genCloth_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x17004521 RID: 17697
		// (get) Token: 0x06023382 RID: 144258 RVA: 0x0097C33C File Offset: 0x0097A53C
		// (set) Token: 0x06023383 RID: 144259 RVA: 0x0097C34C File Offset: 0x0097A54C
		public unsafe bool ReadFromBPL
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_genCloth_C.__PropertyOffset_15) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_genCloth_C.__PropertyOffset_15) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004522 RID: 17698
		// (get) Token: 0x06023384 RID: 144260 RVA: 0x0097C35D File Offset: 0x0097A55D
		// (set) Token: 0x06023385 RID: 144261 RVA: 0x0097C36D File Offset: 0x0097A56D
		public unsafe bool extraOneMaterial
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_genCloth_C.__PropertyOffset_16) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_genCloth_C.__PropertyOffset_16) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004523 RID: 17699
		// (get) Token: 0x06023386 RID: 144262 RVA: 0x0097C37E File Offset: 0x0097A57E
		// (set) Token: 0x06023387 RID: 144263 RVA: 0x0097C392 File Offset: 0x0097A592
		public unsafe UMaterialInstance InputMat1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_genCloth_C.__PropertyOffset_17);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_genCloth_C.__PropertyOffset_17, value);
			}
		}

		// Token: 0x17004524 RID: 17700
		// (get) Token: 0x06023388 RID: 144264 RVA: 0x0097C3A7 File Offset: 0x0097A5A7
		// (set) Token: 0x06023389 RID: 144265 RVA: 0x0097C3BB File Offset: 0x0097A5BB
		public unsafe UMaterialInstanceDynamic MID1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_genCloth_C.__PropertyOffset_18);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_genCloth_C.__PropertyOffset_18, value);
			}
		}

		// Token: 0x17004525 RID: 17701
		// (get) Token: 0x0602338A RID: 144266 RVA: 0x0097C3D0 File Offset: 0x0097A5D0
		// (set) Token: 0x0602338B RID: 144267 RVA: 0x0097C3E0 File Offset: 0x0097A5E0
		public unsafe bool StopBP
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_genCloth_C.__PropertyOffset_19) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_genCloth_C.__PropertyOffset_19) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004526 RID: 17702
		// (get) Token: 0x0602338C RID: 144268 RVA: 0x0097C3F1 File Offset: 0x0097A5F1
		// (set) Token: 0x0602338D RID: 144269 RVA: 0x0097C401 File Offset: 0x0097A601
		public unsafe bool UseYCount
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_genCloth_C.__PropertyOffset_20) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_genCloth_C.__PropertyOffset_20) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004527 RID: 17703
		// (get) Token: 0x0602338E RID: 144270 RVA: 0x0097C412 File Offset: 0x0097A612
		// (set) Token: 0x0602338F RID: 144271 RVA: 0x0097C422 File Offset: 0x0097A622
		public unsafe int YCount
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_genCloth_C.__PropertyOffset_21);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_genCloth_C.__PropertyOffset_21) = value;
			}
		}

		// Token: 0x17004528 RID: 17704
		// (get) Token: 0x06023390 RID: 144272 RVA: 0x0097C433 File Offset: 0x0097A633
		// (set) Token: 0x06023391 RID: 144273 RVA: 0x0097C447 File Offset: 0x0097A647
		public unsafe FVector WeaponPosition
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_genCloth_C.__PropertyOffset_22);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_genCloth_C.__PropertyOffset_22) = value;
			}
		}

		// Token: 0x17004529 RID: 17705
		// (get) Token: 0x06023392 RID: 144274 RVA: 0x0097C45C File Offset: 0x0097A65C
		// (set) Token: 0x06023393 RID: 144275 RVA: 0x0097C470 File Offset: 0x0097A670
		public unsafe FVector LastWeaponPosition
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_genCloth_C.__PropertyOffset_23);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_genCloth_C.__PropertyOffset_23) = value;
			}
		}

		// Token: 0x1700452A RID: 17706
		// (get) Token: 0x06023394 RID: 144276 RVA: 0x0097C485 File Offset: 0x0097A685
		// (set) Token: 0x06023395 RID: 144277 RVA: 0x0097C499 File Offset: 0x0097A699
		public unsafe UTextureRenderTarget2D RT_N
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_genCloth_C.__PropertyOffset_24);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_genCloth_C.__PropertyOffset_24, value);
			}
		}

		// Token: 0x1700452B RID: 17707
		// (get) Token: 0x06023396 RID: 144278 RVA: 0x0097C4AE File Offset: 0x0097A6AE
		// (set) Token: 0x06023397 RID: 144279 RVA: 0x0097C4C2 File Offset: 0x0097A6C2
		public unsafe FVector gravity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_genCloth_C.__PropertyOffset_25);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_genCloth_C.__PropertyOffset_25) = value;
			}
		}

		// Token: 0x1700452C RID: 17708
		// (get) Token: 0x06023398 RID: 144280 RVA: 0x0097C4D7 File Offset: 0x0097A6D7
		// (set) Token: 0x06023399 RID: 144281 RVA: 0x0097C4E7 File Offset: 0x0097A6E7
		public unsafe bool UseStaticCollision
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_genCloth_C.__PropertyOffset_26) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_genCloth_C.__PropertyOffset_26) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700452D RID: 17709
		// (get) Token: 0x0602339A RID: 144282 RVA: 0x0097C4F8 File Offset: 0x0097A6F8
		// (set) Token: 0x0602339B RID: 144283 RVA: 0x0097C50C File Offset: 0x0097A70C
		public unsafe UChildActorComponent editorTicker
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_genCloth_C.__PropertyOffset_27);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_genCloth_C.__PropertyOffset_27, value);
			}
		}

		// Token: 0x1700452E RID: 17710
		// (get) Token: 0x0602339C RID: 144284 RVA: 0x0097C524 File Offset: 0x0097A724
		// (set) Token: 0x0602339D RID: 144285 RVA: 0x0097C55D File Offset: 0x0097A75D
		[Nullable(1)]
		public TArray<FKuroCSUnifiedCollider_genericCloth> ColArr
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<FKuroCSUnifiedCollider_genericCloth> result;
				if ((result = this._ColArr) == null)
				{
					result = (this._ColArr = new TArray<FKuroCSUnifiedCollider_genericCloth>(base.NativePtr + (IntPtr)BP_genCloth_C.__PropertyOffset_28, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.ColArr.CopyAssign(value);
			}
		}

		// Token: 0x1700452F RID: 17711
		// (get) Token: 0x0602339E RID: 144286 RVA: 0x0097C56B File Offset: 0x0097A76B
		// (set) Token: 0x0602339F RID: 144287 RVA: 0x0097C57B File Offset: 0x0097A77B
		public unsafe bool Start
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_genCloth_C.__PropertyOffset_29) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_genCloth_C.__PropertyOffset_29) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004530 RID: 17712
		// (get) Token: 0x060233A0 RID: 144288 RVA: 0x0097C58C File Offset: 0x0097A78C
		// (set) Token: 0x060233A1 RID: 144289 RVA: 0x0097C59C File Offset: 0x0097A79C
		public unsafe float FadeOut
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_genCloth_C.__PropertyOffset_30);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_genCloth_C.__PropertyOffset_30) = value;
			}
		}

		// Token: 0x17004531 RID: 17713
		// (get) Token: 0x060233A2 RID: 144290 RVA: 0x0097C5AD File Offset: 0x0097A7AD
		// (set) Token: 0x060233A3 RID: 144291 RVA: 0x0097C5BD File Offset: 0x0097A7BD
		public unsafe bool initOverlap
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_genCloth_C.__PropertyOffset_31) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_genCloth_C.__PropertyOffset_31) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004532 RID: 17714
		// (get) Token: 0x060233A4 RID: 144292 RVA: 0x0097C5CE File Offset: 0x0097A7CE
		// (set) Token: 0x060233A5 RID: 144293 RVA: 0x0097C5DE File Offset: 0x0097A7DE
		public unsafe bool alreadyBuildArr
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_genCloth_C.__PropertyOffset_32) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_genCloth_C.__PropertyOffset_32) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004533 RID: 17715
		// (get) Token: 0x060233A6 RID: 144294 RVA: 0x0097C5EF File Offset: 0x0097A7EF
		// (set) Token: 0x060233A7 RID: 144295 RVA: 0x0097C5FF File Offset: 0x0097A7FF
		public unsafe bool bAfterBeginplay
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_genCloth_C.__PropertyOffset_33) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_genCloth_C.__PropertyOffset_33) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004534 RID: 17716
		// (get) Token: 0x060233A8 RID: 144296 RVA: 0x0097C610 File Offset: 0x0097A810
		// (set) Token: 0x060233A9 RID: 144297 RVA: 0x0097C620 File Offset: 0x0097A820
		public unsafe bool PlatformCheck
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_genCloth_C.__PropertyOffset_34) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_genCloth_C.__PropertyOffset_34) = (value ? 1 : 0);
			}
		}

		// Token: 0x060233AA RID: 144298 RVA: 0x0097C631 File Offset: 0x0097A831
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_genCloth_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x060233AB RID: 144299 RVA: 0x0097C645 File Offset: 0x0097A845
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_genCloth_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060233AC RID: 144300 RVA: 0x0097C65A File Offset: 0x0097A85A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_genCloth_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x060233AD RID: 144301 RVA: 0x0097C66E File Offset: 0x0097A86E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_genCloth_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060233AE RID: 144302 RVA: 0x0097C684 File Offset: 0x0097A884
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_genCloth_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_genCloth_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_genCloth_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_genCloth_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_genCloth_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060233AF RID: 144303 RVA: 0x0097C6CC File Offset: 0x0097A8CC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_genCloth_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_genCloth_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_genCloth_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_genCloth_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_genCloth_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060233B0 RID: 144304 RVA: 0x0097C714 File Offset: 0x0097A914
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveEndPlay(EEndPlayReason EndPlayReason)
		{
			BP_genCloth_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_genCloth_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_genCloth_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_genCloth_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_genCloth_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060233B1 RID: 144305 RVA: 0x0097C760 File Offset: 0x0097A960
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveEndPlay_Implementation(EEndPlayReason EndPlayReason)
		{
			BP_genCloth_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_genCloth_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_genCloth_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_genCloth_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_genCloth_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060233B2 RID: 144306 RVA: 0x0097C7AC File Offset: 0x0097A9AC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_RPBD_xpbd_test_K2Node_ComponentBoundEvent_1_ComponentHitSignature__DelegateSignature(UPrimitiveComponent HitComponent, AActor OtherActor, UPrimitiveComponent OtherComp, FVector NormalImpulse, in FHitResult Hit)
		{
			BP_genCloth_C.__BndEvt__BP_RPBD_xpbd_test_K2Node_ComponentBoundEvent_1_ComponentHitSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_genCloth_C.__BndEvt__BP_RPBD_xpbd_test_K2Node_ComponentBoundEvent_1_ComponentHitSignature__DelegateSignature_FunctionParams[(UIntPtr)199] + 15L / (long)sizeof(BP_genCloth_C.__BndEvt__BP_RPBD_xpbd_test_K2Node_ComponentBoundEvent_1_ComponentHitSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_genCloth_C.__BndEvt__BP_RPBD_xpbd_test_K2Node_ComponentBoundEvent_1_ComponentHitSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->HitComponent = ((HitComponent != null) ? HitComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->NormalImpulse = NormalImpulse;
			if (Hit != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FHitResult.StaticStruct(), &ptr->Hit, Hit.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_genCloth_C.__BndEvt__BP_RPBD_xpbd_test_K2Node_ComponentBoundEvent_1_ComponentHitSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060233B3 RID: 144307 RVA: 0x0097C860 File Offset: 0x0097AA60
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex, bool bFromSweep, in FHitResult SweepResult)
		{
			BP_genCloth_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_genCloth_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)199] + 15L / (long)sizeof(BP_genCloth_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_genCloth_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			ptr->bFromSweep = bFromSweep;
			if (SweepResult != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FHitResult.StaticStruct(), &ptr->SweepResult, SweepResult.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_genCloth_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060233B4 RID: 144308 RVA: 0x0097C91C File Offset: 0x0097AB1C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex)
		{
			BP_genCloth_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_genCloth_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_genCloth_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_genCloth_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_genCloth_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060233B5 RID: 144309 RVA: 0x0097C9A8 File Offset: 0x0097ABA8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void OnWeaponInteraction(FVectorDouble OriginPoint, BP_SceneBattleInteract_C Config, int Id)
		{
			BP_genCloth_C.__OnWeaponInteraction_FunctionParams* ptr = stackalloc BP_genCloth_C.__OnWeaponInteraction_FunctionParams[(UIntPtr)55] + 15L / (long)sizeof(BP_genCloth_C.__OnWeaponInteraction_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_genCloth_C.__OnWeaponInteraction_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OriginPoint = OriginPoint;
			ptr->Config = ((Config != null) ? Config.NativePtr : IntPtr.Zero);
			ptr->Id = Id;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_genCloth_C.__OnWeaponInteraction_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060233B6 RID: 144310 RVA: 0x0097CA0B File Offset: 0x0097AC0B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EditorTick()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_genCloth_C.__EditorTick_NativeFunctionPtr, null);
		}

		// Token: 0x060233B7 RID: 144311 RVA: 0x0097CA20 File Offset: 0x0097AC20
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_genCloth(int EntryPoint)
		{
			BP_genCloth_C.__ExecuteUbergraph_BP_genCloth_FunctionParams* ptr = stackalloc BP_genCloth_C.__ExecuteUbergraph_BP_genCloth_FunctionParams[(UIntPtr)3551] + 15L / (long)sizeof(BP_genCloth_C.__ExecuteUbergraph_BP_genCloth_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_genCloth_C.__ExecuteUbergraph_BP_genCloth_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_genCloth_C.__ExecuteUbergraph_BP_genCloth_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060233B8 RID: 144312 RVA: 0x0097CA6A File Offset: 0x0097AC6A
		protected BP_genCloth_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04011E8E RID: 73358
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/GPUBoxSimulation/BP_genCloth.BP_genCloth_C";

		// Token: 0x04011E8F RID: 73359
		private static IntPtr _ClassPtr;

		// Token: 0x04011E90 RID: 73360
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04011E91 RID: 73361
		internal static int __PropertyOffset_0;

		// Token: 0x04011E92 RID: 73362
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04011E93 RID: 73363
		internal static int __PropertyOffset_1;

		// Token: 0x04011E94 RID: 73364
		internal static int __PropertyOffset_2;

		// Token: 0x04011E95 RID: 73365
		internal static int __PropertyOffset_3;

		// Token: 0x04011E96 RID: 73366
		internal static int __PropertyOffset_4;

		// Token: 0x04011E97 RID: 73367
		internal static int __PropertyOffset_5;

		// Token: 0x04011E98 RID: 73368
		internal static int __PropertyOffset_6;

		// Token: 0x04011E99 RID: 73369
		internal static int __PropertyOffset_7;

		// Token: 0x04011E9A RID: 73370
		internal static int __PropertyOffset_8;

		// Token: 0x04011E9B RID: 73371
		internal static int __PropertyOffset_9;

		// Token: 0x04011E9C RID: 73372
		internal static int __PropertyOffset_10;

		// Token: 0x04011E9D RID: 73373
		internal static int __PropertyOffset_11;

		// Token: 0x04011E9E RID: 73374
		internal static int __PropertyOffset_12;

		// Token: 0x04011E9F RID: 73375
		internal static int __PropertyOffset_13;

		// Token: 0x04011EA0 RID: 73376
		internal static int __PropertyOffset_14;

		// Token: 0x04011EA1 RID: 73377
		internal static int __PropertyOffset_15;

		// Token: 0x04011EA2 RID: 73378
		internal static int __PropertyOffset_16;

		// Token: 0x04011EA3 RID: 73379
		internal static int __PropertyOffset_17;

		// Token: 0x04011EA4 RID: 73380
		internal static int __PropertyOffset_18;

		// Token: 0x04011EA5 RID: 73381
		internal static int __PropertyOffset_19;

		// Token: 0x04011EA6 RID: 73382
		internal static int __PropertyOffset_20;

		// Token: 0x04011EA7 RID: 73383
		internal static int __PropertyOffset_21;

		// Token: 0x04011EA8 RID: 73384
		internal static int __PropertyOffset_22;

		// Token: 0x04011EA9 RID: 73385
		internal static int __PropertyOffset_23;

		// Token: 0x04011EAA RID: 73386
		internal static int __PropertyOffset_24;

		// Token: 0x04011EAB RID: 73387
		internal static int __PropertyOffset_25;

		// Token: 0x04011EAC RID: 73388
		internal static int __PropertyOffset_26;

		// Token: 0x04011EAD RID: 73389
		internal static int __PropertyOffset_27;

		// Token: 0x04011EAE RID: 73390
		internal static int __PropertyOffset_28;

		// Token: 0x04011EAF RID: 73391
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<FKuroCSUnifiedCollider_genericCloth> _ColArr;

		// Token: 0x04011EB0 RID: 73392
		internal static int __PropertyOffset_29;

		// Token: 0x04011EB1 RID: 73393
		internal static int __PropertyOffset_30;

		// Token: 0x04011EB2 RID: 73394
		internal static int __PropertyOffset_31;

		// Token: 0x04011EB3 RID: 73395
		internal static int __PropertyOffset_32;

		// Token: 0x04011EB4 RID: 73396
		internal static int __PropertyOffset_33;

		// Token: 0x04011EB5 RID: 73397
		internal static int __PropertyOffset_34;

		// Token: 0x04011EB6 RID: 73398
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04011EB7 RID: 73399
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04011EB8 RID: 73400
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04011EB9 RID: 73401
		private static IntPtr __ReceiveEndPlay_NativeFunctionPtr;

		// Token: 0x04011EBA RID: 73402
		private static IntPtr __BndEvt__BP_RPBD_xpbd_test_K2Node_ComponentBoundEvent_1_ComponentHitSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04011EBB RID: 73403
		private static IntPtr __BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04011EBC RID: 73404
		private static IntPtr __BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04011EBD RID: 73405
		private static IntPtr __OnWeaponInteraction_NativeFunctionPtr;

		// Token: 0x04011EBE RID: 73406
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x04011EBF RID: 73407
		private static IntPtr __ExecuteUbergraph_BP_genCloth_NativeFunctionPtr;

		// Token: 0x02009CB2 RID: 40114
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032606 RID: 206342
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009CB3 RID: 40115
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __ReceiveEndPlay_FunctionParams
		{
			// Token: 0x04032607 RID: 206343
			[FieldOffset(0)]
			public TEnumAsByte<EEndPlayReason> EndPlayReason;
		}

		// Token: 0x02009CB4 RID: 40116
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 184)]
		protected ref struct __BndEvt__BP_RPBD_xpbd_test_K2Node_ComponentBoundEvent_1_ComponentHitSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x04032608 RID: 206344
			[FieldOffset(0)]
			public IntPtr HitComponent;

			// Token: 0x04032609 RID: 206345
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x0403260A RID: 206346
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x0403260B RID: 206347
			[FieldOffset(24)]
			public FVector NormalImpulse;

			// Token: 0x0403260C RID: 206348
			[FieldOffset(36)]
			public byte Hit;
		}

		// Token: 0x02009CB5 RID: 40117
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 184)]
		protected ref struct __BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x0403260D RID: 206349
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x0403260E RID: 206350
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x0403260F RID: 206351
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x04032610 RID: 206352
			[FieldOffset(24)]
			public int OtherBodyIndex;

			// Token: 0x04032611 RID: 206353
			[FieldOffset(28)]
			public bool bFromSweep;

			// Token: 0x04032612 RID: 206354
			[FieldOffset(32)]
			public byte SweepResult;
		}

		// Token: 0x02009CB6 RID: 40118
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x04032613 RID: 206355
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x04032614 RID: 206356
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x04032615 RID: 206357
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x04032616 RID: 206358
			[FieldOffset(24)]
			public int OtherBodyIndex;
		}

		// Token: 0x02009CB7 RID: 40119
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 40)]
		protected ref struct __OnWeaponInteraction_FunctionParams
		{
			// Token: 0x04032617 RID: 206359
			[FieldOffset(0)]
			public FVectorDouble OriginPoint;

			// Token: 0x04032618 RID: 206360
			[FieldOffset(24)]
			public IntPtr Config;

			// Token: 0x04032619 RID: 206361
			[FieldOffset(32)]
			public int Id;
		}

		// Token: 0x02009CB8 RID: 40120
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 3536)]
		protected ref struct __ExecuteUbergraph_BP_genCloth_FunctionParams
		{
			// Token: 0x0403261A RID: 206362
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
