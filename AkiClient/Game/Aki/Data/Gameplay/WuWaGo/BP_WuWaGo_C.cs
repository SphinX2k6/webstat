using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.MaterialController;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Data.Gameplay.WuWaGo
{
	// Token: 0x02003E95 RID: 16021
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Data/Gameplay/WuWaGo/BP_WuWaGo.BP_WuWaGo_C")]
	[UnrealStructLayout(1952, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1948)]
	public class BP_WuWaGo_C : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06027B1A RID: 162586 RVA: 0x009F8317 File Offset: 0x009F6517
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_WuWaGo_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Data/Gameplay/WuWaGo/BP_WuWaGo.BP_WuWaGo_C");
			}
			return BP_WuWaGo_C._ClassPtr;
		}

		// Token: 0x06027B1B RID: 162587 RVA: 0x009F833C File Offset: 0x009F653C
		public BP_WuWaGo_C() : this(BuiltinUtils.AllocNativeUObject(BP_WuWaGo_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06027B1C RID: 162588 RVA: 0x009F8364 File Offset: 0x009F6564
		public BP_WuWaGo_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_WuWaGo_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17005E50 RID: 24144
		// (get) Token: 0x06027B1D RID: 162589 RVA: 0x009F8397 File Offset: 0x009F6597
		// (set) Token: 0x06027B1E RID: 162590 RVA: 0x009F83AC File Offset: 0x009F65AC
		public TSoftClassPtr<TsBaseCharacter> MainControlClass
		{
			get
			{
				return new TSoftClassPtr<TsBaseCharacter>(base.NativePtr + (IntPtr)BP_WuWaGo_C.__PropertyOffset_0, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)BP_WuWaGo_C.__PropertyOffset_0, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005E51 RID: 24145
		// (get) Token: 0x06027B1F RID: 162591 RVA: 0x009F83D1 File Offset: 0x009F65D1
		// (set) Token: 0x06027B20 RID: 162592 RVA: 0x009F83E6 File Offset: 0x009F65E6
		public TSoftClassPtr<TsBaseCharacter> StaticMonsterClass
		{
			get
			{
				return new TSoftClassPtr<TsBaseCharacter>(base.NativePtr + (IntPtr)BP_WuWaGo_C.__PropertyOffset_1, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)BP_WuWaGo_C.__PropertyOffset_1, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005E52 RID: 24146
		// (get) Token: 0x06027B21 RID: 162593 RVA: 0x009F840B File Offset: 0x009F660B
		// (set) Token: 0x06027B22 RID: 162594 RVA: 0x009F8420 File Offset: 0x009F6620
		public TSoftClassPtr<TsBaseCharacter> MoveMonsterClass
		{
			get
			{
				return new TSoftClassPtr<TsBaseCharacter>(base.NativePtr + (IntPtr)BP_WuWaGo_C.__PropertyOffset_2, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)BP_WuWaGo_C.__PropertyOffset_2, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005E53 RID: 24147
		// (get) Token: 0x06027B23 RID: 162595 RVA: 0x009F8445 File Offset: 0x009F6645
		// (set) Token: 0x06027B24 RID: 162596 RVA: 0x009F8455 File Offset: 0x009F6655
		public unsafe int SingleGridSize
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WuWaGo_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WuWaGo_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17005E54 RID: 24148
		// (get) Token: 0x06027B25 RID: 162597 RVA: 0x009F8466 File Offset: 0x009F6666
		// (set) Token: 0x06027B26 RID: 162598 RVA: 0x009F847B File Offset: 0x009F667B
		public TSoftObjectPtr<UMaterialInstance> SingleLinkGridMaterial
		{
			get
			{
				return new TSoftObjectPtr<UMaterialInstance>(base.NativePtr + (IntPtr)BP_WuWaGo_C.__PropertyOffset_4, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)BP_WuWaGo_C.__PropertyOffset_4, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005E55 RID: 24149
		// (get) Token: 0x06027B27 RID: 162599 RVA: 0x009F84A0 File Offset: 0x009F66A0
		// (set) Token: 0x06027B28 RID: 162600 RVA: 0x009F84B5 File Offset: 0x009F66B5
		public TSoftObjectPtr<UMaterialInstance> RightAngleLinkGridMaterial
		{
			get
			{
				return new TSoftObjectPtr<UMaterialInstance>(base.NativePtr + (IntPtr)BP_WuWaGo_C.__PropertyOffset_5, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)BP_WuWaGo_C.__PropertyOffset_5, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005E56 RID: 24150
		// (get) Token: 0x06027B29 RID: 162601 RVA: 0x009F84DA File Offset: 0x009F66DA
		// (set) Token: 0x06027B2A RID: 162602 RVA: 0x009F84EF File Offset: 0x009F66EF
		public TSoftObjectPtr<UMaterialInstance> StraightLinkGridMaterial
		{
			get
			{
				return new TSoftObjectPtr<UMaterialInstance>(base.NativePtr + (IntPtr)BP_WuWaGo_C.__PropertyOffset_6, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)BP_WuWaGo_C.__PropertyOffset_6, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005E57 RID: 24151
		// (get) Token: 0x06027B2B RID: 162603 RVA: 0x009F8514 File Offset: 0x009F6714
		// (set) Token: 0x06027B2C RID: 162604 RVA: 0x009F8529 File Offset: 0x009F6729
		public TSoftObjectPtr<UMaterialInstance> ThreeLinkGridMaterial
		{
			get
			{
				return new TSoftObjectPtr<UMaterialInstance>(base.NativePtr + (IntPtr)BP_WuWaGo_C.__PropertyOffset_7, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)BP_WuWaGo_C.__PropertyOffset_7, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005E58 RID: 24152
		// (get) Token: 0x06027B2D RID: 162605 RVA: 0x009F854E File Offset: 0x009F674E
		// (set) Token: 0x06027B2E RID: 162606 RVA: 0x009F8563 File Offset: 0x009F6763
		public TSoftObjectPtr<UMaterialInstance> AllLinkGridMaterial
		{
			get
			{
				return new TSoftObjectPtr<UMaterialInstance>(base.NativePtr + (IntPtr)BP_WuWaGo_C.__PropertyOffset_8, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)BP_WuWaGo_C.__PropertyOffset_8, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005E59 RID: 24153
		// (get) Token: 0x06027B2F RID: 162607 RVA: 0x009F8588 File Offset: 0x009F6788
		// (set) Token: 0x06027B30 RID: 162608 RVA: 0x009F85C1 File Offset: 0x009F67C1
		public SWuWaGoRoleAnim StaticMonsterAnim
		{
			get
			{
				base.FastCheckIsValid();
				SWuWaGoRoleAnim result;
				if ((result = this._StaticMonsterAnim) == null)
				{
					result = (this._StaticMonsterAnim = new SWuWaGoRoleAnim(base.NativePtr + (IntPtr)BP_WuWaGo_C.__PropertyOffset_9, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SWuWaGoRoleAnim.StaticStruct(), base.NativePtr + (IntPtr)BP_WuWaGo_C.__PropertyOffset_9, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005E5A RID: 24154
		// (get) Token: 0x06027B31 RID: 162609 RVA: 0x009F85E2 File Offset: 0x009F67E2
		// (set) Token: 0x06027B32 RID: 162610 RVA: 0x009F85F7 File Offset: 0x009F67F7
		public TSoftClassPtr<UKuroAnimInstanceMonster> MoveMonsterAnimationBlueprint
		{
			get
			{
				return new TSoftClassPtr<UKuroAnimInstanceMonster>(base.NativePtr + (IntPtr)BP_WuWaGo_C.__PropertyOffset_10, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)BP_WuWaGo_C.__PropertyOffset_10, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005E5B RID: 24155
		// (get) Token: 0x06027B33 RID: 162611 RVA: 0x009F861C File Offset: 0x009F681C
		// (set) Token: 0x06027B34 RID: 162612 RVA: 0x009F8655 File Offset: 0x009F6855
		public SWuWaGoRoleAnim MoveMonsterAnim
		{
			get
			{
				base.FastCheckIsValid();
				SWuWaGoRoleAnim result;
				if ((result = this._MoveMonsterAnim) == null)
				{
					result = (this._MoveMonsterAnim = new SWuWaGoRoleAnim(base.NativePtr + (IntPtr)BP_WuWaGo_C.__PropertyOffset_11, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SWuWaGoRoleAnim.StaticStruct(), base.NativePtr + (IntPtr)BP_WuWaGo_C.__PropertyOffset_11, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005E5C RID: 24156
		// (get) Token: 0x06027B35 RID: 162613 RVA: 0x009F8676 File Offset: 0x009F6876
		// (set) Token: 0x06027B36 RID: 162614 RVA: 0x009F868B File Offset: 0x009F688B
		public TSoftClassPtr<UKuroAnimInstanceMonster> MainControlAnimationBlueprint
		{
			get
			{
				return new TSoftClassPtr<UKuroAnimInstanceMonster>(base.NativePtr + (IntPtr)BP_WuWaGo_C.__PropertyOffset_12, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)BP_WuWaGo_C.__PropertyOffset_12, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005E5D RID: 24157
		// (get) Token: 0x06027B37 RID: 162615 RVA: 0x009F86B0 File Offset: 0x009F68B0
		// (set) Token: 0x06027B38 RID: 162616 RVA: 0x009F86E9 File Offset: 0x009F68E9
		public SWuWaGoRoleAnim MainControlAnim
		{
			get
			{
				base.FastCheckIsValid();
				SWuWaGoRoleAnim result;
				if ((result = this._MainControlAnim) == null)
				{
					result = (this._MainControlAnim = new SWuWaGoRoleAnim(base.NativePtr + (IntPtr)BP_WuWaGo_C.__PropertyOffset_13, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SWuWaGoRoleAnim.StaticStruct(), base.NativePtr + (IntPtr)BP_WuWaGo_C.__PropertyOffset_13, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005E5E RID: 24158
		// (get) Token: 0x06027B39 RID: 162617 RVA: 0x009F870A File Offset: 0x009F690A
		// (set) Token: 0x06027B3A RID: 162618 RVA: 0x009F871F File Offset: 0x009F691F
		public TSoftObjectPtr<UEffectModelGroup> GridHoverRedArrowEffect
		{
			get
			{
				return new TSoftObjectPtr<UEffectModelGroup>(base.NativePtr + (IntPtr)BP_WuWaGo_C.__PropertyOffset_14, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)BP_WuWaGo_C.__PropertyOffset_14, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005E5F RID: 24159
		// (get) Token: 0x06027B3B RID: 162619 RVA: 0x009F8744 File Offset: 0x009F6944
		// (set) Token: 0x06027B3C RID: 162620 RVA: 0x009F8759 File Offset: 0x009F6959
		public TSoftObjectPtr<UEffectModelGroup> GridHoverEffect
		{
			get
			{
				return new TSoftObjectPtr<UEffectModelGroup>(base.NativePtr + (IntPtr)BP_WuWaGo_C.__PropertyOffset_15, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)BP_WuWaGo_C.__PropertyOffset_15, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005E60 RID: 24160
		// (get) Token: 0x06027B3D RID: 162621 RVA: 0x009F877E File Offset: 0x009F697E
		// (set) Token: 0x06027B3E RID: 162622 RVA: 0x009F8793 File Offset: 0x009F6993
		public TSoftObjectPtr<UEffectModelGroup> StartPositionGridEffect
		{
			get
			{
				return new TSoftObjectPtr<UEffectModelGroup>(base.NativePtr + (IntPtr)BP_WuWaGo_C.__PropertyOffset_16, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)BP_WuWaGo_C.__PropertyOffset_16, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005E61 RID: 24161
		// (get) Token: 0x06027B3F RID: 162623 RVA: 0x009F87B8 File Offset: 0x009F69B8
		// (set) Token: 0x06027B40 RID: 162624 RVA: 0x009F87CD File Offset: 0x009F69CD
		public TSoftObjectPtr<UEffectModelGroup> EndPositionGridEffect
		{
			get
			{
				return new TSoftObjectPtr<UEffectModelGroup>(base.NativePtr + (IntPtr)BP_WuWaGo_C.__PropertyOffset_17, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)BP_WuWaGo_C.__PropertyOffset_17, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005E62 RID: 24162
		// (get) Token: 0x06027B41 RID: 162625 RVA: 0x009F87F2 File Offset: 0x009F69F2
		// (set) Token: 0x06027B42 RID: 162626 RVA: 0x009F8807 File Offset: 0x009F6A07
		public TSoftObjectPtr<UMaterialInstance> CanMoveGridTipsMaterial1
		{
			get
			{
				return new TSoftObjectPtr<UMaterialInstance>(base.NativePtr + (IntPtr)BP_WuWaGo_C.__PropertyOffset_18, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)BP_WuWaGo_C.__PropertyOffset_18, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005E63 RID: 24163
		// (get) Token: 0x06027B43 RID: 162627 RVA: 0x009F882C File Offset: 0x009F6A2C
		// (set) Token: 0x06027B44 RID: 162628 RVA: 0x009F8841 File Offset: 0x009F6A41
		public TSoftObjectPtr<UMaterialInstance> CanMoveGridTipsMaterial2
		{
			get
			{
				return new TSoftObjectPtr<UMaterialInstance>(base.NativePtr + (IntPtr)BP_WuWaGo_C.__PropertyOffset_19, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)BP_WuWaGo_C.__PropertyOffset_19, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005E64 RID: 24164
		// (get) Token: 0x06027B45 RID: 162629 RVA: 0x009F8866 File Offset: 0x009F6A66
		// (set) Token: 0x06027B46 RID: 162630 RVA: 0x009F887B File Offset: 0x009F6A7B
		public TSoftObjectPtr<UMaterialInstance> CanMoveGridTipsMaterial3
		{
			get
			{
				return new TSoftObjectPtr<UMaterialInstance>(base.NativePtr + (IntPtr)BP_WuWaGo_C.__PropertyOffset_20, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)BP_WuWaGo_C.__PropertyOffset_20, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005E65 RID: 24165
		// (get) Token: 0x06027B47 RID: 162631 RVA: 0x009F88A0 File Offset: 0x009F6AA0
		// (set) Token: 0x06027B48 RID: 162632 RVA: 0x009F88B5 File Offset: 0x009F6AB5
		public TSoftObjectPtr<UEffectModelGroup> StaticMonsterAttackRangeEffect
		{
			get
			{
				return new TSoftObjectPtr<UEffectModelGroup>(base.NativePtr + (IntPtr)BP_WuWaGo_C.__PropertyOffset_21, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)BP_WuWaGo_C.__PropertyOffset_21, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005E66 RID: 24166
		// (get) Token: 0x06027B49 RID: 162633 RVA: 0x009F88DA File Offset: 0x009F6ADA
		// (set) Token: 0x06027B4A RID: 162634 RVA: 0x009F88EF File Offset: 0x009F6AEF
		public TSoftObjectPtr<UEffectModelGroup> MoveMonsterAttackRangeEffect
		{
			get
			{
				return new TSoftObjectPtr<UEffectModelGroup>(base.NativePtr + (IntPtr)BP_WuWaGo_C.__PropertyOffset_22, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)BP_WuWaGo_C.__PropertyOffset_22, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005E67 RID: 24167
		// (get) Token: 0x06027B4B RID: 162635 RVA: 0x009F8914 File Offset: 0x009F6B14
		// (set) Token: 0x06027B4C RID: 162636 RVA: 0x009F8924 File Offset: 0x009F6B24
		public unsafe int TipButtonShowDeadCount
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WuWaGo_C.__PropertyOffset_23);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WuWaGo_C.__PropertyOffset_23) = value;
			}
		}

		// Token: 0x17005E68 RID: 24168
		// (get) Token: 0x06027B4D RID: 162637 RVA: 0x009F8935 File Offset: 0x009F6B35
		// (set) Token: 0x06027B4E RID: 162638 RVA: 0x009F8945 File Offset: 0x009F6B45
		public unsafe int SwipeMinPixelDistance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WuWaGo_C.__PropertyOffset_24);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WuWaGo_C.__PropertyOffset_24) = value;
			}
		}

		// Token: 0x17005E69 RID: 24169
		// (get) Token: 0x06027B4F RID: 162639 RVA: 0x009F8956 File Offset: 0x009F6B56
		// (set) Token: 0x06027B50 RID: 162640 RVA: 0x009F8966 File Offset: 0x009F6B66
		public unsafe int HoverMinPixel
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WuWaGo_C.__PropertyOffset_25);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WuWaGo_C.__PropertyOffset_25) = value;
			}
		}

		// Token: 0x17005E6A RID: 24170
		// (get) Token: 0x06027B51 RID: 162641 RVA: 0x009F8977 File Offset: 0x009F6B77
		// (set) Token: 0x06027B52 RID: 162642 RVA: 0x009F898B File Offset: 0x009F6B8B
		public unsafe string BottomTipsKeyTouch
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)BP_WuWaGo_C.__PropertyOffset_26)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)BP_WuWaGo_C.__PropertyOffset_26)), value);
			}
		}

		// Token: 0x17005E6B RID: 24171
		// (get) Token: 0x06027B53 RID: 162643 RVA: 0x009F89A0 File Offset: 0x009F6BA0
		// (set) Token: 0x06027B54 RID: 162644 RVA: 0x009F89B4 File Offset: 0x009F6BB4
		public unsafe string BottomTipsKeyKeyBoard
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)BP_WuWaGo_C.__PropertyOffset_27)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)BP_WuWaGo_C.__PropertyOffset_27)), value);
			}
		}

		// Token: 0x17005E6C RID: 24172
		// (get) Token: 0x06027B55 RID: 162645 RVA: 0x009F89C9 File Offset: 0x009F6BC9
		// (set) Token: 0x06027B56 RID: 162646 RVA: 0x009F89DD File Offset: 0x009F6BDD
		public unsafe string BottomTipsKeyGamepad
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)BP_WuWaGo_C.__PropertyOffset_28)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)BP_WuWaGo_C.__PropertyOffset_28)), value);
			}
		}

		// Token: 0x17005E6D RID: 24173
		// (get) Token: 0x06027B57 RID: 162647 RVA: 0x009F89F2 File Offset: 0x009F6BF2
		// (set) Token: 0x06027B58 RID: 162648 RVA: 0x009F8A07 File Offset: 0x009F6C07
		public TSoftObjectPtr<UAnimMontage> MainControlPullRodOpenMontage
		{
			get
			{
				return new TSoftObjectPtr<UAnimMontage>(base.NativePtr + (IntPtr)BP_WuWaGo_C.__PropertyOffset_29, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)BP_WuWaGo_C.__PropertyOffset_29, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005E6E RID: 24174
		// (get) Token: 0x06027B59 RID: 162649 RVA: 0x009F8A2C File Offset: 0x009F6C2C
		// (set) Token: 0x06027B5A RID: 162650 RVA: 0x009F8A41 File Offset: 0x009F6C41
		public TSoftObjectPtr<UAnimMontage> MainControlPullRodCloseMontage
		{
			get
			{
				return new TSoftObjectPtr<UAnimMontage>(base.NativePtr + (IntPtr)BP_WuWaGo_C.__PropertyOffset_30, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)BP_WuWaGo_C.__PropertyOffset_30, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005E6F RID: 24175
		// (get) Token: 0x06027B5B RID: 162651 RVA: 0x009F8A66 File Offset: 0x009F6C66
		// (set) Token: 0x06027B5C RID: 162652 RVA: 0x009F8A76 File Offset: 0x009F6C76
		public unsafe int HelpId
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WuWaGo_C.__PropertyOffset_31);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WuWaGo_C.__PropertyOffset_31) = value;
			}
		}

		// Token: 0x17005E70 RID: 24176
		// (get) Token: 0x06027B5D RID: 162653 RVA: 0x009F8A87 File Offset: 0x009F6C87
		// (set) Token: 0x06027B5E RID: 162654 RVA: 0x009F8A9B File Offset: 0x009F6C9B
		public unsafe string PlayTipsBubbleText
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)BP_WuWaGo_C.__PropertyOffset_32)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)BP_WuWaGo_C.__PropertyOffset_32)), value);
			}
		}

		// Token: 0x17005E71 RID: 24177
		// (get) Token: 0x06027B5F RID: 162655 RVA: 0x009F8AB0 File Offset: 0x009F6CB0
		// (set) Token: 0x06027B60 RID: 162656 RVA: 0x009F8AC0 File Offset: 0x009F6CC0
		public unsafe int MaxRollbackCount
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WuWaGo_C.__PropertyOffset_33);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WuWaGo_C.__PropertyOffset_33) = value;
			}
		}

		// Token: 0x17005E72 RID: 24178
		// (get) Token: 0x06027B61 RID: 162657 RVA: 0x009F8AD1 File Offset: 0x009F6CD1
		// (set) Token: 0x06027B62 RID: 162658 RVA: 0x009F8AE1 File Offset: 0x009F6CE1
		public unsafe int MovableFloorMoveSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WuWaGo_C.__PropertyOffset_34);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WuWaGo_C.__PropertyOffset_34) = value;
			}
		}

		// Token: 0x17005E73 RID: 24179
		// (get) Token: 0x06027B63 RID: 162659 RVA: 0x009F8AF2 File Offset: 0x009F6CF2
		// (set) Token: 0x06027B64 RID: 162660 RVA: 0x009F8B02 File Offset: 0x009F6D02
		public unsafe int GearMoveDurationMs
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WuWaGo_C.__PropertyOffset_35);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WuWaGo_C.__PropertyOffset_35) = value;
			}
		}

		// Token: 0x17005E74 RID: 24180
		// (get) Token: 0x06027B65 RID: 162661 RVA: 0x009F8B13 File Offset: 0x009F6D13
		// (set) Token: 0x06027B66 RID: 162662 RVA: 0x009F8B23 File Offset: 0x009F6D23
		public unsafe int ArrowNoHitWaitMs
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WuWaGo_C.__PropertyOffset_36);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WuWaGo_C.__PropertyOffset_36) = value;
			}
		}

		// Token: 0x17005E75 RID: 24181
		// (get) Token: 0x06027B67 RID: 162663 RVA: 0x009F8B34 File Offset: 0x009F6D34
		// (set) Token: 0x06027B68 RID: 162664 RVA: 0x009F8B44 File Offset: 0x009F6D44
		public unsafe int CharacterMoveSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WuWaGo_C.__PropertyOffset_37);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WuWaGo_C.__PropertyOffset_37) = value;
			}
		}

		// Token: 0x17005E76 RID: 24182
		// (get) Token: 0x06027B69 RID: 162665 RVA: 0x009F8B55 File Offset: 0x009F6D55
		// (set) Token: 0x06027B6A RID: 162666 RVA: 0x009F8B65 File Offset: 0x009F6D65
		public unsafe float MontagePlayRate
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WuWaGo_C.__PropertyOffset_38);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WuWaGo_C.__PropertyOffset_38) = value;
			}
		}

		// Token: 0x17005E77 RID: 24183
		// (get) Token: 0x06027B6B RID: 162667 RVA: 0x009F8B76 File Offset: 0x009F6D76
		// (set) Token: 0x06027B6C RID: 162668 RVA: 0x009F8B8B File Offset: 0x009F6D8B
		public TSoftObjectPtr<UAnimMontage> AlertMontage
		{
			get
			{
				return new TSoftObjectPtr<UAnimMontage>(base.NativePtr + (IntPtr)BP_WuWaGo_C.__PropertyOffset_39, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)BP_WuWaGo_C.__PropertyOffset_39, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005E78 RID: 24184
		// (get) Token: 0x06027B6D RID: 162669 RVA: 0x009F8BB0 File Offset: 0x009F6DB0
		// (set) Token: 0x06027B6E RID: 162670 RVA: 0x009F8BC5 File Offset: 0x009F6DC5
		public TSoftObjectPtr<UAnimMontage> BeHitFallMontage
		{
			get
			{
				return new TSoftObjectPtr<UAnimMontage>(base.NativePtr + (IntPtr)BP_WuWaGo_C.__PropertyOffset_40, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)BP_WuWaGo_C.__PropertyOffset_40, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005E79 RID: 24185
		// (get) Token: 0x06027B6F RID: 162671 RVA: 0x009F8BEA File Offset: 0x009F6DEA
		// (set) Token: 0x06027B70 RID: 162672 RVA: 0x009F8BFA File Offset: 0x009F6DFA
		public unsafe int SpikeFallHeight
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WuWaGo_C.__PropertyOffset_41);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WuWaGo_C.__PropertyOffset_41) = value;
			}
		}

		// Token: 0x17005E7A RID: 24186
		// (get) Token: 0x06027B71 RID: 162673 RVA: 0x009F8C0B File Offset: 0x009F6E0B
		// (set) Token: 0x06027B72 RID: 162674 RVA: 0x009F8C20 File Offset: 0x009F6E20
		public TSoftObjectPtr<UAnimMontage> IdleMontage
		{
			get
			{
				return new TSoftObjectPtr<UAnimMontage>(base.NativePtr + (IntPtr)BP_WuWaGo_C.__PropertyOffset_42, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)BP_WuWaGo_C.__PropertyOffset_42, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005E7B RID: 24187
		// (get) Token: 0x06027B73 RID: 162675 RVA: 0x009F8C45 File Offset: 0x009F6E45
		// (set) Token: 0x06027B74 RID: 162676 RVA: 0x009F8C55 File Offset: 0x009F6E55
		public unsafe int BowDelayMs
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WuWaGo_C.__PropertyOffset_43);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WuWaGo_C.__PropertyOffset_43) = value;
			}
		}

		// Token: 0x17005E7C RID: 24188
		// (get) Token: 0x06027B75 RID: 162677 RVA: 0x009F8C66 File Offset: 0x009F6E66
		// (set) Token: 0x06027B76 RID: 162678 RVA: 0x009F8C76 File Offset: 0x009F6E76
		public unsafe int BowFlySpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WuWaGo_C.__PropertyOffset_44);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WuWaGo_C.__PropertyOffset_44) = value;
			}
		}

		// Token: 0x17005E7D RID: 24189
		// (get) Token: 0x06027B77 RID: 162679 RVA: 0x009F8C88 File Offset: 0x009F6E88
		// (set) Token: 0x06027B78 RID: 162680 RVA: 0x009F8CC1 File Offset: 0x009F6EC1
		public TArray<string> AudioEvents
		{
			get
			{
				base.FastCheckIsValid();
				TArray<string> result;
				if ((result = this._AudioEvents) == null)
				{
					result = (this._AudioEvents = new TArray<string>(base.NativePtr + (IntPtr)BP_WuWaGo_C.__PropertyOffset_45, this));
				}
				return result;
			}
			set
			{
				this.AudioEvents.CopyAssign(value);
			}
		}

		// Token: 0x17005E7E RID: 24190
		// (get) Token: 0x06027B79 RID: 162681 RVA: 0x009F8CCF File Offset: 0x009F6ECF
		// (set) Token: 0x06027B7A RID: 162682 RVA: 0x009F8CE4 File Offset: 0x009F6EE4
		public TSoftObjectPtr<UPrimaryDataAsset> BowHitFx
		{
			get
			{
				return new TSoftObjectPtr<UPrimaryDataAsset>(base.NativePtr + (IntPtr)BP_WuWaGo_C.__PropertyOffset_46, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)BP_WuWaGo_C.__PropertyOffset_46, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005E7F RID: 24191
		// (get) Token: 0x06027B7B RID: 162683 RVA: 0x009F8D09 File Offset: 0x009F6F09
		// (set) Token: 0x06027B7C RID: 162684 RVA: 0x009F8D1E File Offset: 0x009F6F1E
		public TSoftObjectPtr<UAnimMontage> SpikeFallMontage
		{
			get
			{
				return new TSoftObjectPtr<UAnimMontage>(base.NativePtr + (IntPtr)BP_WuWaGo_C.__PropertyOffset_47, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)BP_WuWaGo_C.__PropertyOffset_47, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005E80 RID: 24192
		// (get) Token: 0x06027B7D RID: 162685 RVA: 0x009F8D43 File Offset: 0x009F6F43
		// (set) Token: 0x06027B7E RID: 162686 RVA: 0x009F8D53 File Offset: 0x009F6F53
		public unsafe float BeforeAttackMoveDistance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WuWaGo_C.__PropertyOffset_48);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WuWaGo_C.__PropertyOffset_48) = value;
			}
		}

		// Token: 0x17005E81 RID: 24193
		// (get) Token: 0x06027B7F RID: 162687 RVA: 0x009F8D64 File Offset: 0x009F6F64
		// (set) Token: 0x06027B80 RID: 162688 RVA: 0x009F8D79 File Offset: 0x009F6F79
		public TSoftObjectPtr<UPrimaryDataAsset> MoveFloorFx
		{
			get
			{
				return new TSoftObjectPtr<UPrimaryDataAsset>(base.NativePtr + (IntPtr)BP_WuWaGo_C.__PropertyOffset_49, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)BP_WuWaGo_C.__PropertyOffset_49, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005E82 RID: 24194
		// (get) Token: 0x06027B81 RID: 162689 RVA: 0x009F8D9E File Offset: 0x009F6F9E
		// (set) Token: 0x06027B82 RID: 162690 RVA: 0x009F8DB2 File Offset: 0x009F6FB2
		[Nullable(2)]
		public unsafe PD_CharacterControllerData_C PetrifyEffect
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<PD_CharacterControllerData_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WuWaGo_C.__PropertyOffset_50);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WuWaGo_C.__PropertyOffset_50, value);
			}
		}

		// Token: 0x17005E83 RID: 24195
		// (get) Token: 0x06027B83 RID: 162691 RVA: 0x009F8DC7 File Offset: 0x009F6FC7
		// (set) Token: 0x06027B84 RID: 162692 RVA: 0x009F8DDB File Offset: 0x009F6FDB
		[Nullable(2)]
		public unsafe PD_CharacterControllerData_C PetrifyDissolveEffect_0
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<PD_CharacterControllerData_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WuWaGo_C.__PropertyOffset_51);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WuWaGo_C.__PropertyOffset_51, value);
			}
		}

		// Token: 0x17005E84 RID: 24196
		// (get) Token: 0x06027B85 RID: 162693 RVA: 0x009F8DF0 File Offset: 0x009F6FF0
		// (set) Token: 0x06027B86 RID: 162694 RVA: 0x009F8E04 File Offset: 0x009F7004
		[Nullable(2)]
		public unsafe PD_CharacterControllerData_C PetrifyDissolveEffect_1
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<PD_CharacterControllerData_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WuWaGo_C.__PropertyOffset_52);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WuWaGo_C.__PropertyOffset_52, value);
			}
		}

		// Token: 0x17005E85 RID: 24197
		// (get) Token: 0x06027B87 RID: 162695 RVA: 0x009F8E19 File Offset: 0x009F7019
		// (set) Token: 0x06027B88 RID: 162696 RVA: 0x009F8E29 File Offset: 0x009F7029
		public unsafe int ConfirmBoxId
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WuWaGo_C.__PropertyOffset_53);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WuWaGo_C.__PropertyOffset_53) = value;
			}
		}

		// Token: 0x06027B89 RID: 162697 RVA: 0x009F8E3A File Offset: 0x009F703A
		protected BP_WuWaGo_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04014D1A RID: 85274
		public new const string __ObjectPath = "/Game/Aki/Data/Gameplay/WuWaGo/BP_WuWaGo.BP_WuWaGo_C";

		// Token: 0x04014D1B RID: 85275
		private static IntPtr _ClassPtr;

		// Token: 0x04014D1C RID: 85276
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04014D1D RID: 85277
		internal static int __PropertyOffset_0;

		// Token: 0x04014D1E RID: 85278
		internal static int __PropertyOffset_1;

		// Token: 0x04014D1F RID: 85279
		internal static int __PropertyOffset_2;

		// Token: 0x04014D20 RID: 85280
		internal static int __PropertyOffset_3;

		// Token: 0x04014D21 RID: 85281
		internal static int __PropertyOffset_4;

		// Token: 0x04014D22 RID: 85282
		internal static int __PropertyOffset_5;

		// Token: 0x04014D23 RID: 85283
		internal static int __PropertyOffset_6;

		// Token: 0x04014D24 RID: 85284
		internal static int __PropertyOffset_7;

		// Token: 0x04014D25 RID: 85285
		internal static int __PropertyOffset_8;

		// Token: 0x04014D26 RID: 85286
		internal static int __PropertyOffset_9;

		// Token: 0x04014D27 RID: 85287
		[Nullable(2)]
		private SWuWaGoRoleAnim _StaticMonsterAnim;

		// Token: 0x04014D28 RID: 85288
		internal static int __PropertyOffset_10;

		// Token: 0x04014D29 RID: 85289
		internal static int __PropertyOffset_11;

		// Token: 0x04014D2A RID: 85290
		[Nullable(2)]
		private SWuWaGoRoleAnim _MoveMonsterAnim;

		// Token: 0x04014D2B RID: 85291
		internal static int __PropertyOffset_12;

		// Token: 0x04014D2C RID: 85292
		internal static int __PropertyOffset_13;

		// Token: 0x04014D2D RID: 85293
		[Nullable(2)]
		private SWuWaGoRoleAnim _MainControlAnim;

		// Token: 0x04014D2E RID: 85294
		internal static int __PropertyOffset_14;

		// Token: 0x04014D2F RID: 85295
		internal static int __PropertyOffset_15;

		// Token: 0x04014D30 RID: 85296
		internal static int __PropertyOffset_16;

		// Token: 0x04014D31 RID: 85297
		internal static int __PropertyOffset_17;

		// Token: 0x04014D32 RID: 85298
		internal static int __PropertyOffset_18;

		// Token: 0x04014D33 RID: 85299
		internal static int __PropertyOffset_19;

		// Token: 0x04014D34 RID: 85300
		internal static int __PropertyOffset_20;

		// Token: 0x04014D35 RID: 85301
		internal static int __PropertyOffset_21;

		// Token: 0x04014D36 RID: 85302
		internal static int __PropertyOffset_22;

		// Token: 0x04014D37 RID: 85303
		internal static int __PropertyOffset_23;

		// Token: 0x04014D38 RID: 85304
		internal static int __PropertyOffset_24;

		// Token: 0x04014D39 RID: 85305
		internal static int __PropertyOffset_25;

		// Token: 0x04014D3A RID: 85306
		internal static int __PropertyOffset_26;

		// Token: 0x04014D3B RID: 85307
		internal static int __PropertyOffset_27;

		// Token: 0x04014D3C RID: 85308
		internal static int __PropertyOffset_28;

		// Token: 0x04014D3D RID: 85309
		internal static int __PropertyOffset_29;

		// Token: 0x04014D3E RID: 85310
		internal static int __PropertyOffset_30;

		// Token: 0x04014D3F RID: 85311
		internal static int __PropertyOffset_31;

		// Token: 0x04014D40 RID: 85312
		internal static int __PropertyOffset_32;

		// Token: 0x04014D41 RID: 85313
		internal static int __PropertyOffset_33;

		// Token: 0x04014D42 RID: 85314
		internal static int __PropertyOffset_34;

		// Token: 0x04014D43 RID: 85315
		internal static int __PropertyOffset_35;

		// Token: 0x04014D44 RID: 85316
		internal static int __PropertyOffset_36;

		// Token: 0x04014D45 RID: 85317
		internal static int __PropertyOffset_37;

		// Token: 0x04014D46 RID: 85318
		internal static int __PropertyOffset_38;

		// Token: 0x04014D47 RID: 85319
		internal static int __PropertyOffset_39;

		// Token: 0x04014D48 RID: 85320
		internal static int __PropertyOffset_40;

		// Token: 0x04014D49 RID: 85321
		internal static int __PropertyOffset_41;

		// Token: 0x04014D4A RID: 85322
		internal static int __PropertyOffset_42;

		// Token: 0x04014D4B RID: 85323
		internal static int __PropertyOffset_43;

		// Token: 0x04014D4C RID: 85324
		internal static int __PropertyOffset_44;

		// Token: 0x04014D4D RID: 85325
		internal static int __PropertyOffset_45;

		// Token: 0x04014D4E RID: 85326
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<string> _AudioEvents;

		// Token: 0x04014D4F RID: 85327
		internal static int __PropertyOffset_46;

		// Token: 0x04014D50 RID: 85328
		internal static int __PropertyOffset_47;

		// Token: 0x04014D51 RID: 85329
		internal static int __PropertyOffset_48;

		// Token: 0x04014D52 RID: 85330
		internal static int __PropertyOffset_49;

		// Token: 0x04014D53 RID: 85331
		internal static int __PropertyOffset_50;

		// Token: 0x04014D54 RID: 85332
		internal static int __PropertyOffset_51;

		// Token: 0x04014D55 RID: 85333
		internal static int __PropertyOffset_52;

		// Token: 0x04014D56 RID: 85334
		internal static int __PropertyOffset_53;
	}
}
