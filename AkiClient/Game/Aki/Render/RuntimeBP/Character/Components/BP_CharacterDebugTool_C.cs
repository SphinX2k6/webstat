using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.MaterialContainer;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.MaterialController;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Character.Components
{
	// Token: 0x02003D91 RID: 15761
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Character/Components/BP_CharacterDebugTool.BP_CharacterDebugTool_C")]
	[UnrealStructLayout(1256, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1252)]
	public class BP_CharacterDebugTool_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06026775 RID: 157557 RVA: 0x009D91AF File Offset: 0x009D73AF
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_CharacterDebugTool_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Character/Components/BP_CharacterDebugTool.BP_CharacterDebugTool_C");
			}
			return BP_CharacterDebugTool_C._ClassPtr;
		}

		// Token: 0x06026776 RID: 157558 RVA: 0x009D91D4 File Offset: 0x009D73D4
		public BP_CharacterDebugTool_C() : this(BuiltinUtils.AllocNativeUObject(BP_CharacterDebugTool_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06026777 RID: 157559 RVA: 0x009D91FC File Offset: 0x009D73FC
		[NullableContext(1)]
		public BP_CharacterDebugTool_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_CharacterDebugTool_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17005774 RID: 22388
		// (get) Token: 0x06026778 RID: 157560 RVA: 0x009D9230 File Offset: 0x009D7430
		// (set) Token: 0x06026779 RID: 157561 RVA: 0x009D9269 File Offset: 0x009D7469
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_CharacterDebugTool_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_CharacterDebugTool_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005775 RID: 22389
		// (get) Token: 0x0602677A RID: 157562 RVA: 0x009D928A File Offset: 0x009D748A
		// (set) Token: 0x0602677B RID: 157563 RVA: 0x009D929E File Offset: 0x009D749E
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CharacterDebugTool_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CharacterDebugTool_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17005776 RID: 22390
		// (get) Token: 0x0602677C RID: 157564 RVA: 0x009D92B3 File Offset: 0x009D74B3
		// (set) Token: 0x0602677D RID: 157565 RVA: 0x009D92C7 File Offset: 0x009D74C7
		public unsafe TsBaseCharacter Character
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<TsBaseCharacter>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CharacterDebugTool_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CharacterDebugTool_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17005777 RID: 22391
		// (get) Token: 0x0602677E RID: 157566 RVA: 0x009D92DC File Offset: 0x009D74DC
		// (set) Token: 0x0602677F RID: 157567 RVA: 0x009D92F0 File Offset: 0x009D74F0
		public unsafe ASkeletalMeshActor SkeletalMesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<ASkeletalMeshActor>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CharacterDebugTool_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CharacterDebugTool_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17005778 RID: 22392
		// (get) Token: 0x06026780 RID: 157568 RVA: 0x009D9305 File Offset: 0x009D7505
		// (set) Token: 0x06026781 RID: 157569 RVA: 0x009D9319 File Offset: 0x009D7519
		public unsafe TsBaseCharacter LastCharacter
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<TsBaseCharacter>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CharacterDebugTool_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CharacterDebugTool_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17005779 RID: 22393
		// (get) Token: 0x06026782 RID: 157570 RVA: 0x009D932E File Offset: 0x009D752E
		// (set) Token: 0x06026783 RID: 157571 RVA: 0x009D933E File Offset: 0x009D753E
		public unsafe int 材质控制器handle1
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CharacterDebugTool_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CharacterDebugTool_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x1700577A RID: 22394
		// (get) Token: 0x06026784 RID: 157572 RVA: 0x009D934F File Offset: 0x009D754F
		// (set) Token: 0x06026785 RID: 157573 RVA: 0x009D935F File Offset: 0x009D755F
		public unsafe int 材质控制器handle2
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CharacterDebugTool_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CharacterDebugTool_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x1700577B RID: 22395
		// (get) Token: 0x06026786 RID: 157574 RVA: 0x009D9370 File Offset: 0x009D7570
		// (set) Token: 0x06026787 RID: 157575 RVA: 0x009D9384 File Offset: 0x009D7584
		public unsafe PD_CharacterControllerData_C 材质控制器数据1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<PD_CharacterControllerData_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CharacterDebugTool_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CharacterDebugTool_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x1700577C RID: 22396
		// (get) Token: 0x06026788 RID: 157576 RVA: 0x009D9399 File Offset: 0x009D7599
		// (set) Token: 0x06026789 RID: 157577 RVA: 0x009D93AD File Offset: 0x009D75AD
		public unsafe PD_CharacterControllerData_C 材质控制器数据2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<PD_CharacterControllerData_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CharacterDebugTool_C.__PropertyOffset_8);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CharacterDebugTool_C.__PropertyOffset_8, value);
			}
		}

		// Token: 0x1700577D RID: 22397
		// (get) Token: 0x0602678A RID: 157578 RVA: 0x009D93C2 File Offset: 0x009D75C2
		// (set) Token: 0x0602678B RID: 157579 RVA: 0x009D93D2 File Offset: 0x009D75D2
		public unsafe bool dirty
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CharacterDebugTool_C.__PropertyOffset_9) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CharacterDebugTool_C.__PropertyOffset_9) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700577E RID: 22398
		// (get) Token: 0x0602678C RID: 157580 RVA: 0x009D93E3 File Offset: 0x009D75E3
		// (set) Token: 0x0602678D RID: 157581 RVA: 0x009D93F7 File Offset: 0x009D75F7
		public unsafe PD_CharacterControllerDataGroup_C 材质控制器组数据
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<PD_CharacterControllerDataGroup_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CharacterDebugTool_C.__PropertyOffset_10);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CharacterDebugTool_C.__PropertyOffset_10, value);
			}
		}

		// Token: 0x1700577F RID: 22399
		// (get) Token: 0x0602678E RID: 157582 RVA: 0x009D940C File Offset: 0x009D760C
		// (set) Token: 0x0602678F RID: 157583 RVA: 0x009D941C File Offset: 0x009D761C
		public unsafe int GroupHandle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CharacterDebugTool_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CharacterDebugTool_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17005780 RID: 22400
		// (get) Token: 0x06026790 RID: 157584 RVA: 0x009D942D File Offset: 0x009D762D
		// (set) Token: 0x06026791 RID: 157585 RVA: 0x009D9441 File Offset: 0x009D7641
		public unsafe PD_CurveLinearColorData_C ColorCurveData
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<PD_CurveLinearColorData_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CharacterDebugTool_C.__PropertyOffset_12);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CharacterDebugTool_C.__PropertyOffset_12, value);
			}
		}

		// Token: 0x17005781 RID: 22401
		// (get) Token: 0x06026792 RID: 157586 RVA: 0x009D9456 File Offset: 0x009D7656
		// (set) Token: 0x06026793 RID: 157587 RVA: 0x009D946A File Offset: 0x009D766A
		public unsafe PD_CurveFloatData_C FloatCurveData
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<PD_CurveFloatData_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CharacterDebugTool_C.__PropertyOffset_13);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CharacterDebugTool_C.__PropertyOffset_13, value);
			}
		}

		// Token: 0x17005782 RID: 22402
		// (get) Token: 0x06026794 RID: 157588 RVA: 0x009D947F File Offset: 0x009D767F
		// (set) Token: 0x06026795 RID: 157589 RVA: 0x009D9493 File Offset: 0x009D7693
		[Nullable(1)]
		public unsafe string 属性名称
		{
			[NullableContext(1)]
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)BP_CharacterDebugTool_C.__PropertyOffset_14)));
			}
			[NullableContext(1)]
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)BP_CharacterDebugTool_C.__PropertyOffset_14)), value);
			}
		}

		// Token: 0x17005783 RID: 22403
		// (get) Token: 0x06026796 RID: 157590 RVA: 0x009D94A8 File Offset: 0x009D76A8
		// (set) Token: 0x06026797 RID: 157591 RVA: 0x009D94B8 File Offset: 0x009D76B8
		public unsafe float SectionIndex
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CharacterDebugTool_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CharacterDebugTool_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x17005784 RID: 22404
		// (get) Token: 0x06026798 RID: 157592 RVA: 0x009D94C9 File Offset: 0x009D76C9
		// (set) Token: 0x06026799 RID: 157593 RVA: 0x009D94DD File Offset: 0x009D76DD
		[Nullable(0)]
		public unsafe TEnumAsByte<ECharacterBodySpecifiedType> BodyType
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CharacterDebugTool_C.__PropertyOffset_16);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)BP_CharacterDebugTool_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x17005785 RID: 22405
		// (get) Token: 0x0602679A RID: 157594 RVA: 0x009D94F2 File Offset: 0x009D76F2
		// (set) Token: 0x0602679B RID: 157595 RVA: 0x009D9506 File Offset: 0x009D7706
		[Nullable(0)]
		public unsafe TEnumAsByte<ECharacterSlotSpecifiedType> SlotType
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CharacterDebugTool_C.__PropertyOffset_17);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)BP_CharacterDebugTool_C.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x17005786 RID: 22406
		// (get) Token: 0x0602679C RID: 157596 RVA: 0x009D951B File Offset: 0x009D771B
		// (set) Token: 0x0602679D RID: 157597 RVA: 0x009D952F File Offset: 0x009D772F
		public unsafe FLinearColor ColorValue
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CharacterDebugTool_C.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CharacterDebugTool_C.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x17005787 RID: 22407
		// (get) Token: 0x0602679E RID: 157598 RVA: 0x009D9544 File Offset: 0x009D7744
		// (set) Token: 0x0602679F RID: 157599 RVA: 0x009D9554 File Offset: 0x009D7754
		public unsafe float Factor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CharacterDebugTool_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CharacterDebugTool_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x17005788 RID: 22408
		// (get) Token: 0x060267A0 RID: 157600 RVA: 0x009D9565 File Offset: 0x009D7765
		// (set) Token: 0x060267A1 RID: 157601 RVA: 0x009D9575 File Offset: 0x009D7775
		public unsafe float FloatValue
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CharacterDebugTool_C.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CharacterDebugTool_C.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x17005789 RID: 22409
		// (get) Token: 0x060267A2 RID: 157602 RVA: 0x009D9586 File Offset: 0x009D7786
		// (set) Token: 0x060267A3 RID: 157603 RVA: 0x009D9596 File Offset: 0x009D7796
		public unsafe bool IsDebug
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CharacterDebugTool_C.__PropertyOffset_21) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CharacterDebugTool_C.__PropertyOffset_21) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700578A RID: 22410
		// (get) Token: 0x060267A4 RID: 157604 RVA: 0x009D95A7 File Offset: 0x009D77A7
		// (set) Token: 0x060267A5 RID: 157605 RVA: 0x009D95B7 File Offset: 0x009D77B7
		public unsafe float 材质控制1进度_仅Manul类型
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CharacterDebugTool_C.__PropertyOffset_22);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CharacterDebugTool_C.__PropertyOffset_22) = value;
			}
		}

		// Token: 0x1700578B RID: 22411
		// (get) Token: 0x060267A6 RID: 157606 RVA: 0x009D95C8 File Offset: 0x009D77C8
		// (set) Token: 0x060267A7 RID: 157607 RVA: 0x009D95D8 File Offset: 0x009D77D8
		public unsafe float 材质控制2进度_仅Manul类型
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CharacterDebugTool_C.__PropertyOffset_23);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CharacterDebugTool_C.__PropertyOffset_23) = value;
			}
		}

		// Token: 0x1700578C RID: 22412
		// (get) Token: 0x060267A8 RID: 157608 RVA: 0x009D95E9 File Offset: 0x009D77E9
		// (set) Token: 0x060267A9 RID: 157609 RVA: 0x009D95F9 File Offset: 0x009D77F9
		public unsafe float Dither
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CharacterDebugTool_C.__PropertyOffset_24);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CharacterDebugTool_C.__PropertyOffset_24) = value;
			}
		}

		// Token: 0x1700578D RID: 22413
		// (get) Token: 0x060267AA RID: 157610 RVA: 0x009D960A File Offset: 0x009D780A
		// (set) Token: 0x060267AB RID: 157611 RVA: 0x009D961F File Offset: 0x009D781F
		[Nullable(1)]
		public TSoftObjectPtr<UEffectModelBase> 特效数据
		{
			[NullableContext(1)]
			get
			{
				return new TSoftObjectPtr<UEffectModelBase>(base.NativePtr + (IntPtr)BP_CharacterDebugTool_C.__PropertyOffset_25, this);
			}
			[NullableContext(1)]
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)BP_CharacterDebugTool_C.__PropertyOffset_25, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x1700578E RID: 22414
		// (get) Token: 0x060267AC RID: 157612 RVA: 0x009D9644 File Offset: 0x009D7844
		// (set) Token: 0x060267AD RID: 157613 RVA: 0x009D9654 File Offset: 0x009D7854
		public unsafe int EffectId
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CharacterDebugTool_C.__PropertyOffset_26);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CharacterDebugTool_C.__PropertyOffset_26) = value;
			}
		}

		// Token: 0x060267AE RID: 157614 RVA: 0x009D9665 File Offset: 0x009D7865
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 移除材质控制器1和附身特效()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CharacterDebugTool_C.__移除材质控制器1和附身特效_NativeFunctionPtr, null);
		}

		// Token: 0x060267AF RID: 157615 RVA: 0x009D9679 File Offset: 0x009D7879
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 添加材质控制器1和附身特效()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CharacterDebugTool_C.__添加材质控制器1和附身特效_NativeFunctionPtr, null);
		}

		// Token: 0x060267B0 RID: 157616 RVA: 0x009D968D File Offset: 0x009D788D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 移除附身特效()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CharacterDebugTool_C.__移除附身特效_NativeFunctionPtr, null);
		}

		// Token: 0x060267B1 RID: 157617 RVA: 0x009D96A1 File Offset: 0x009D78A1
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 添加附身特效()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CharacterDebugTool_C.__添加附身特效_NativeFunctionPtr, null);
		}

		// Token: 0x060267B2 RID: 157618 RVA: 0x009D96B5 File Offset: 0x009D78B5
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 更新Dither值()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CharacterDebugTool_C.__更新Dither值_NativeFunctionPtr, null);
		}

		// Token: 0x060267B3 RID: 157619 RVA: 0x009D96C9 File Offset: 0x009D78C9
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 减少材质控制1进度_仅Manul类型()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CharacterDebugTool_C.__减少材质控制1进度_仅Manul类型_NativeFunctionPtr, null);
		}

		// Token: 0x060267B4 RID: 157620 RVA: 0x009D96DD File Offset: 0x009D78DD
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 增加材质控制1进度_仅Manul类型()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CharacterDebugTool_C.__增加材质控制1进度_仅Manul类型_NativeFunctionPtr, null);
		}

		// Token: 0x060267B5 RID: 157621 RVA: 0x009D96F1 File Offset: 0x009D78F1
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 去掉胶囊体Dither()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CharacterDebugTool_C.__去掉胶囊体Dither_NativeFunctionPtr, null);
		}

		// Token: 0x060267B6 RID: 157622 RVA: 0x009D9705 File Offset: 0x009D7905
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 添加胶囊体Dither()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CharacterDebugTool_C.__添加胶囊体Dither_NativeFunctionPtr, null);
		}

		// Token: 0x060267B7 RID: 157623 RVA: 0x009D9719 File Offset: 0x009D7919
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 设置浮点数属性()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CharacterDebugTool_C.__设置浮点数属性_NativeFunctionPtr, null);
		}

		// Token: 0x060267B8 RID: 157624 RVA: 0x009D972D File Offset: 0x009D792D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 设置颜色属性()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CharacterDebugTool_C.__设置颜色属性_NativeFunctionPtr, null);
		}

		// Token: 0x060267B9 RID: 157625 RVA: 0x009D9741 File Offset: 0x009D7941
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 设置曲线浮点数属性()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CharacterDebugTool_C.__设置曲线浮点数属性_NativeFunctionPtr, null);
		}

		// Token: 0x060267BA RID: 157626 RVA: 0x009D9755 File Offset: 0x009D7955
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 设置曲线颜色属性()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CharacterDebugTool_C.__设置曲线颜色属性_NativeFunctionPtr, null);
		}

		// Token: 0x060267BB RID: 157627 RVA: 0x009D9769 File Offset: 0x009D7969
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 初始化()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CharacterDebugTool_C.__初始化_NativeFunctionPtr, null);
		}

		// Token: 0x060267BC RID: 157628 RVA: 0x009D977D File Offset: 0x009D797D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 移除材质控制器1_ToEnd()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CharacterDebugTool_C.__移除材质控制器1_ToEnd_NativeFunctionPtr, null);
		}

		// Token: 0x060267BD RID: 157629 RVA: 0x009D9791 File Offset: 0x009D7991
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 移除材质控制器组()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CharacterDebugTool_C.__移除材质控制器组_NativeFunctionPtr, null);
		}

		// Token: 0x060267BE RID: 157630 RVA: 0x009D97A5 File Offset: 0x009D79A5
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 添加材质控制器组()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CharacterDebugTool_C.__添加材质控制器组_NativeFunctionPtr, null);
		}

		// Token: 0x060267BF RID: 157631 RVA: 0x009D97B9 File Offset: 0x009D79B9
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 移除所有状态()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CharacterDebugTool_C.__移除所有状态_NativeFunctionPtr, null);
		}

		// Token: 0x060267C0 RID: 157632 RVA: 0x009D97CD File Offset: 0x009D79CD
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 移除材质控制器2()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CharacterDebugTool_C.__移除材质控制器2_NativeFunctionPtr, null);
		}

		// Token: 0x060267C1 RID: 157633 RVA: 0x009D97E1 File Offset: 0x009D79E1
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 添加材质控制器2()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CharacterDebugTool_C.__添加材质控制器2_NativeFunctionPtr, null);
		}

		// Token: 0x060267C2 RID: 157634 RVA: 0x009D97F5 File Offset: 0x009D79F5
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 移除材质控制器1()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CharacterDebugTool_C.__移除材质控制器1_NativeFunctionPtr, null);
		}

		// Token: 0x060267C3 RID: 157635 RVA: 0x009D9809 File Offset: 0x009D7A09
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 添加材质控制器1()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CharacterDebugTool_C.__添加材质控制器1_NativeFunctionPtr, null);
		}

		// Token: 0x060267C4 RID: 157636 RVA: 0x009D9820 File Offset: 0x009D7A20
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_CharacterDebugTool_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_CharacterDebugTool_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_CharacterDebugTool_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CharacterDebugTool_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CharacterDebugTool_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060267C5 RID: 157637 RVA: 0x009D9868 File Offset: 0x009D7A68
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_CharacterDebugTool_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_CharacterDebugTool_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_CharacterDebugTool_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CharacterDebugTool_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_CharacterDebugTool_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060267C6 RID: 157638 RVA: 0x009D98B0 File Offset: 0x009D7AB0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_CharacterDebugTool(int EntryPoint)
		{
			BP_CharacterDebugTool_C.__ExecuteUbergraph_BP_CharacterDebugTool_FunctionParams* ptr = stackalloc BP_CharacterDebugTool_C.__ExecuteUbergraph_BP_CharacterDebugTool_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(BP_CharacterDebugTool_C.__ExecuteUbergraph_BP_CharacterDebugTool_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CharacterDebugTool_C.__ExecuteUbergraph_BP_CharacterDebugTool_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_CharacterDebugTool_C.__ExecuteUbergraph_BP_CharacterDebugTool_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060267C7 RID: 157639 RVA: 0x009D98F7 File Offset: 0x009D7AF7
		protected BP_CharacterDebugTool_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04013FDF RID: 81887
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Character/Components/BP_CharacterDebugTool.BP_CharacterDebugTool_C";

		// Token: 0x04013FE0 RID: 81888
		private static IntPtr _ClassPtr;

		// Token: 0x04013FE1 RID: 81889
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04013FE2 RID: 81890
		internal static int __PropertyOffset_0;

		// Token: 0x04013FE3 RID: 81891
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04013FE4 RID: 81892
		internal static int __PropertyOffset_1;

		// Token: 0x04013FE5 RID: 81893
		internal static int __PropertyOffset_2;

		// Token: 0x04013FE6 RID: 81894
		internal static int __PropertyOffset_3;

		// Token: 0x04013FE7 RID: 81895
		internal static int __PropertyOffset_4;

		// Token: 0x04013FE8 RID: 81896
		internal static int __PropertyOffset_5;

		// Token: 0x04013FE9 RID: 81897
		internal static int __PropertyOffset_6;

		// Token: 0x04013FEA RID: 81898
		internal static int __PropertyOffset_7;

		// Token: 0x04013FEB RID: 81899
		internal static int __PropertyOffset_8;

		// Token: 0x04013FEC RID: 81900
		internal static int __PropertyOffset_9;

		// Token: 0x04013FED RID: 81901
		internal static int __PropertyOffset_10;

		// Token: 0x04013FEE RID: 81902
		internal static int __PropertyOffset_11;

		// Token: 0x04013FEF RID: 81903
		internal static int __PropertyOffset_12;

		// Token: 0x04013FF0 RID: 81904
		internal static int __PropertyOffset_13;

		// Token: 0x04013FF1 RID: 81905
		internal static int __PropertyOffset_14;

		// Token: 0x04013FF2 RID: 81906
		internal static int __PropertyOffset_15;

		// Token: 0x04013FF3 RID: 81907
		internal static int __PropertyOffset_16;

		// Token: 0x04013FF4 RID: 81908
		internal static int __PropertyOffset_17;

		// Token: 0x04013FF5 RID: 81909
		internal static int __PropertyOffset_18;

		// Token: 0x04013FF6 RID: 81910
		internal static int __PropertyOffset_19;

		// Token: 0x04013FF7 RID: 81911
		internal static int __PropertyOffset_20;

		// Token: 0x04013FF8 RID: 81912
		internal static int __PropertyOffset_21;

		// Token: 0x04013FF9 RID: 81913
		internal static int __PropertyOffset_22;

		// Token: 0x04013FFA RID: 81914
		internal static int __PropertyOffset_23;

		// Token: 0x04013FFB RID: 81915
		internal static int __PropertyOffset_24;

		// Token: 0x04013FFC RID: 81916
		internal static int __PropertyOffset_25;

		// Token: 0x04013FFD RID: 81917
		internal static int __PropertyOffset_26;

		// Token: 0x04013FFE RID: 81918
		private static IntPtr __移除材质控制器1和附身特效_NativeFunctionPtr;

		// Token: 0x04013FFF RID: 81919
		private static IntPtr __添加材质控制器1和附身特效_NativeFunctionPtr;

		// Token: 0x04014000 RID: 81920
		private static IntPtr __移除附身特效_NativeFunctionPtr;

		// Token: 0x04014001 RID: 81921
		private static IntPtr __添加附身特效_NativeFunctionPtr;

		// Token: 0x04014002 RID: 81922
		private static IntPtr __更新Dither值_NativeFunctionPtr;

		// Token: 0x04014003 RID: 81923
		private static IntPtr __减少材质控制1进度_仅Manul类型_NativeFunctionPtr;

		// Token: 0x04014004 RID: 81924
		private static IntPtr __增加材质控制1进度_仅Manul类型_NativeFunctionPtr;

		// Token: 0x04014005 RID: 81925
		private static IntPtr __去掉胶囊体Dither_NativeFunctionPtr;

		// Token: 0x04014006 RID: 81926
		private static IntPtr __添加胶囊体Dither_NativeFunctionPtr;

		// Token: 0x04014007 RID: 81927
		private static IntPtr __设置浮点数属性_NativeFunctionPtr;

		// Token: 0x04014008 RID: 81928
		private static IntPtr __设置颜色属性_NativeFunctionPtr;

		// Token: 0x04014009 RID: 81929
		private static IntPtr __设置曲线浮点数属性_NativeFunctionPtr;

		// Token: 0x0401400A RID: 81930
		private static IntPtr __设置曲线颜色属性_NativeFunctionPtr;

		// Token: 0x0401400B RID: 81931
		private static IntPtr __初始化_NativeFunctionPtr;

		// Token: 0x0401400C RID: 81932
		private static IntPtr __移除材质控制器1_ToEnd_NativeFunctionPtr;

		// Token: 0x0401400D RID: 81933
		private static IntPtr __移除材质控制器组_NativeFunctionPtr;

		// Token: 0x0401400E RID: 81934
		private static IntPtr __添加材质控制器组_NativeFunctionPtr;

		// Token: 0x0401400F RID: 81935
		private static IntPtr __移除所有状态_NativeFunctionPtr;

		// Token: 0x04014010 RID: 81936
		private static IntPtr __移除材质控制器2_NativeFunctionPtr;

		// Token: 0x04014011 RID: 81937
		private static IntPtr __添加材质控制器2_NativeFunctionPtr;

		// Token: 0x04014012 RID: 81938
		private static IntPtr __移除材质控制器1_NativeFunctionPtr;

		// Token: 0x04014013 RID: 81939
		private static IntPtr __添加材质控制器1_NativeFunctionPtr;

		// Token: 0x04014014 RID: 81940
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04014015 RID: 81941
		private static IntPtr __ExecuteUbergraph_BP_CharacterDebugTool_NativeFunctionPtr;

		// Token: 0x0200A072 RID: 41074
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032CFA RID: 208122
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x0200A073 RID: 41075
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __ExecuteUbergraph_BP_CharacterDebugTool_FunctionParams
		{
			// Token: 0x04032CFB RID: 208123
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
