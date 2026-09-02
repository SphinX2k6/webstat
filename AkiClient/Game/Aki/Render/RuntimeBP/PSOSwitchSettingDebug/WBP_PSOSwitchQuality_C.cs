using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.UI.Module.Common.View.Widget;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PSOSwitchSettingDebug
{
	// Token: 0x02003B47 RID: 15175
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PSOSwitchSettingDebug/WBP_PSOSwitchQuality.WBP_PSOSwitchQuality_C")]
	[UnrealStructLayout(1352, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1349)]
	public class WBP_PSOSwitchQuality_C : UUserWidget, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06020E50 RID: 134736 RVA: 0x0093A220 File Offset: 0x00938420
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (WBP_PSOSwitchQuality_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PSOSwitchSettingDebug/WBP_PSOSwitchQuality.WBP_PSOSwitchQuality_C");
			}
			return WBP_PSOSwitchQuality_C._ClassPtr;
		}

		// Token: 0x06020E51 RID: 134737 RVA: 0x0093A244 File Offset: 0x00938444
		public WBP_PSOSwitchQuality_C() : this(BuiltinUtils.AllocNativeUObject(WBP_PSOSwitchQuality_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06020E52 RID: 134738 RVA: 0x0093A26C File Offset: 0x0093846C
		[NullableContext(1)]
		public WBP_PSOSwitchQuality_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(WBP_PSOSwitchQuality_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170037DC RID: 14300
		// (get) Token: 0x06020E53 RID: 134739 RVA: 0x0093A2A0 File Offset: 0x009384A0
		// (set) Token: 0x06020E54 RID: 134740 RVA: 0x0093A2D9 File Offset: 0x009384D9
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)WBP_PSOSwitchQuality_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)WBP_PSOSwitchQuality_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170037DD RID: 14301
		// (get) Token: 0x06020E55 RID: 134741 RVA: 0x0093A2FA File Offset: 0x009384FA
		// (set) Token: 0x06020E56 RID: 134742 RVA: 0x0093A30E File Offset: 0x0093850E
		public unsafe UButton BtnClose
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UButton>(base.NativePtr / (IntPtr)sizeof(void*) + WBP_PSOSwitchQuality_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WBP_PSOSwitchQuality_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170037DE RID: 14302
		// (get) Token: 0x06020E57 RID: 134743 RVA: 0x0093A323 File Offset: 0x00938523
		// (set) Token: 0x06020E58 RID: 134744 RVA: 0x0093A337 File Offset: 0x00938537
		public unsafe UButton Button
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UButton>(base.NativePtr / (IntPtr)sizeof(void*) + WBP_PSOSwitchQuality_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WBP_PSOSwitchQuality_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x170037DF RID: 14303
		// (get) Token: 0x06020E59 RID: 134745 RVA: 0x0093A34C File Offset: 0x0093854C
		// (set) Token: 0x06020E5A RID: 134746 RVA: 0x0093A360 File Offset: 0x00938560
		public unsafe UButton Button_1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UButton>(base.NativePtr / (IntPtr)sizeof(void*) + WBP_PSOSwitchQuality_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WBP_PSOSwitchQuality_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x170037E0 RID: 14304
		// (get) Token: 0x06020E5B RID: 134747 RVA: 0x0093A375 File Offset: 0x00938575
		// (set) Token: 0x06020E5C RID: 134748 RVA: 0x0093A389 File Offset: 0x00938589
		public unsafe UButton Button_2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UButton>(base.NativePtr / (IntPtr)sizeof(void*) + WBP_PSOSwitchQuality_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WBP_PSOSwitchQuality_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x170037E1 RID: 14305
		// (get) Token: 0x06020E5D RID: 134749 RVA: 0x0093A39E File Offset: 0x0093859E
		// (set) Token: 0x06020E5E RID: 134750 RVA: 0x0093A3B2 File Offset: 0x009385B2
		public unsafe UButton Button_3
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UButton>(base.NativePtr / (IntPtr)sizeof(void*) + WBP_PSOSwitchQuality_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WBP_PSOSwitchQuality_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x170037E2 RID: 14306
		// (get) Token: 0x06020E5F RID: 134751 RVA: 0x0093A3C7 File Offset: 0x009385C7
		// (set) Token: 0x06020E60 RID: 134752 RVA: 0x0093A3DB File Offset: 0x009385DB
		public unsafe UButton Button_4
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UButton>(base.NativePtr / (IntPtr)sizeof(void*) + WBP_PSOSwitchQuality_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WBP_PSOSwitchQuality_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x170037E3 RID: 14307
		// (get) Token: 0x06020E61 RID: 134753 RVA: 0x0093A3F0 File Offset: 0x009385F0
		// (set) Token: 0x06020E62 RID: 134754 RVA: 0x0093A404 File Offset: 0x00938604
		public unsafe UButton Button_5
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UButton>(base.NativePtr / (IntPtr)sizeof(void*) + WBP_PSOSwitchQuality_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WBP_PSOSwitchQuality_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x170037E4 RID: 14308
		// (get) Token: 0x06020E63 RID: 134755 RVA: 0x0093A419 File Offset: 0x00938619
		// (set) Token: 0x06020E64 RID: 134756 RVA: 0x0093A42D File Offset: 0x0093862D
		public unsafe UButton Button_6
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UButton>(base.NativePtr / (IntPtr)sizeof(void*) + WBP_PSOSwitchQuality_C.__PropertyOffset_8);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WBP_PSOSwitchQuality_C.__PropertyOffset_8, value);
			}
		}

		// Token: 0x170037E5 RID: 14309
		// (get) Token: 0x06020E65 RID: 134757 RVA: 0x0093A442 File Offset: 0x00938642
		// (set) Token: 0x06020E66 RID: 134758 RVA: 0x0093A456 File Offset: 0x00938656
		public unsafe UButton Button_7
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UButton>(base.NativePtr / (IntPtr)sizeof(void*) + WBP_PSOSwitchQuality_C.__PropertyOffset_9);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WBP_PSOSwitchQuality_C.__PropertyOffset_9, value);
			}
		}

		// Token: 0x170037E6 RID: 14310
		// (get) Token: 0x06020E67 RID: 134759 RVA: 0x0093A46B File Offset: 0x0093866B
		// (set) Token: 0x06020E68 RID: 134760 RVA: 0x0093A47F File Offset: 0x0093867F
		public unsafe UButton Button_8
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UButton>(base.NativePtr / (IntPtr)sizeof(void*) + WBP_PSOSwitchQuality_C.__PropertyOffset_10);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WBP_PSOSwitchQuality_C.__PropertyOffset_10, value);
			}
		}

		// Token: 0x170037E7 RID: 14311
		// (get) Token: 0x06020E69 RID: 134761 RVA: 0x0093A494 File Offset: 0x00938694
		// (set) Token: 0x06020E6A RID: 134762 RVA: 0x0093A4A8 File Offset: 0x009386A8
		public unsafe UButton Button_9
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UButton>(base.NativePtr / (IntPtr)sizeof(void*) + WBP_PSOSwitchQuality_C.__PropertyOffset_11);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WBP_PSOSwitchQuality_C.__PropertyOffset_11, value);
			}
		}

		// Token: 0x170037E8 RID: 14312
		// (get) Token: 0x06020E6B RID: 134763 RVA: 0x0093A4BD File Offset: 0x009386BD
		// (set) Token: 0x06020E6C RID: 134764 RVA: 0x0093A4D1 File Offset: 0x009386D1
		public unsafe UButton Button_10
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UButton>(base.NativePtr / (IntPtr)sizeof(void*) + WBP_PSOSwitchQuality_C.__PropertyOffset_12);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WBP_PSOSwitchQuality_C.__PropertyOffset_12, value);
			}
		}

		// Token: 0x170037E9 RID: 14313
		// (get) Token: 0x06020E6D RID: 134765 RVA: 0x0093A4E6 File Offset: 0x009386E6
		// (set) Token: 0x06020E6E RID: 134766 RVA: 0x0093A4FA File Offset: 0x009386FA
		public unsafe UButton Button_11
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UButton>(base.NativePtr / (IntPtr)sizeof(void*) + WBP_PSOSwitchQuality_C.__PropertyOffset_13);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WBP_PSOSwitchQuality_C.__PropertyOffset_13, value);
			}
		}

		// Token: 0x170037EA RID: 14314
		// (get) Token: 0x06020E6F RID: 134767 RVA: 0x0093A50F File Offset: 0x0093870F
		// (set) Token: 0x06020E70 RID: 134768 RVA: 0x0093A523 File Offset: 0x00938723
		public unsafe UButton Button_12
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UButton>(base.NativePtr / (IntPtr)sizeof(void*) + WBP_PSOSwitchQuality_C.__PropertyOffset_14);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WBP_PSOSwitchQuality_C.__PropertyOffset_14, value);
			}
		}

		// Token: 0x170037EB RID: 14315
		// (get) Token: 0x06020E71 RID: 134769 RVA: 0x0093A538 File Offset: 0x00938738
		// (set) Token: 0x06020E72 RID: 134770 RVA: 0x0093A54C File Offset: 0x0093874C
		public unsafe KuroImage_C KuroImage_C_76
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<KuroImage_C>(base.NativePtr / (IntPtr)sizeof(void*) + WBP_PSOSwitchQuality_C.__PropertyOffset_15);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WBP_PSOSwitchQuality_C.__PropertyOffset_15, value);
			}
		}

		// Token: 0x170037EC RID: 14316
		// (get) Token: 0x06020E73 RID: 134771 RVA: 0x0093A561 File Offset: 0x00938761
		// (set) Token: 0x06020E74 RID: 134772 RVA: 0x0093A575 File Offset: 0x00938775
		public unsafe UEditableTextBox TextQuality
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UEditableTextBox>(base.NativePtr / (IntPtr)sizeof(void*) + WBP_PSOSwitchQuality_C.__PropertyOffset_16);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WBP_PSOSwitchQuality_C.__PropertyOffset_16, value);
			}
		}

		// Token: 0x170037ED RID: 14317
		// (get) Token: 0x06020E75 RID: 134773 RVA: 0x0093A58A File Offset: 0x0093878A
		// (set) Token: 0x06020E76 RID: 134774 RVA: 0x0093A59E File Offset: 0x0093879E
		public unsafe UEditableTextBox TextRenderPass
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UEditableTextBox>(base.NativePtr / (IntPtr)sizeof(void*) + WBP_PSOSwitchQuality_C.__PropertyOffset_17);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WBP_PSOSwitchQuality_C.__PropertyOffset_17, value);
			}
		}

		// Token: 0x170037EE RID: 14318
		// (get) Token: 0x06020E77 RID: 134775 RVA: 0x0093A5B3 File Offset: 0x009387B3
		// (set) Token: 0x06020E78 RID: 134776 RVA: 0x0093A5C3 File Offset: 0x009387C3
		public unsafe bool SceneLoad
		{
			get
			{
				return *(base.NativePtr + (IntPtr)WBP_PSOSwitchQuality_C.__PropertyOffset_18) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)WBP_PSOSwitchQuality_C.__PropertyOffset_18) = (value ? 1 : 0);
			}
		}

		// Token: 0x170037EF RID: 14319
		// (get) Token: 0x06020E79 RID: 134777 RVA: 0x0093A5D4 File Offset: 0x009387D4
		// (set) Token: 0x06020E7A RID: 134778 RVA: 0x0093A5E8 File Offset: 0x009387E8
		public unsafe ULevelSequence PSOSeq
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<ULevelSequence>(base.NativePtr / (IntPtr)sizeof(void*) + WBP_PSOSwitchQuality_C.__PropertyOffset_19);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WBP_PSOSwitchQuality_C.__PropertyOffset_19, value);
			}
		}

		// Token: 0x170037F0 RID: 14320
		// (get) Token: 0x06020E7B RID: 134779 RVA: 0x0093A5FD File Offset: 0x009387FD
		// (set) Token: 0x06020E7C RID: 134780 RVA: 0x0093A611 File Offset: 0x00938811
		public unsafe ULevelSequencePlayer SequencePlayer
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<ULevelSequencePlayer>(base.NativePtr / (IntPtr)sizeof(void*) + WBP_PSOSwitchQuality_C.__PropertyOffset_20);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + WBP_PSOSwitchQuality_C.__PropertyOffset_20, value);
			}
		}

		// Token: 0x170037F1 RID: 14321
		// (get) Token: 0x06020E7D RID: 134781 RVA: 0x0093A626 File Offset: 0x00938826
		// (set) Token: 0x06020E7E RID: 134782 RVA: 0x0093A636 File Offset: 0x00938836
		public unsafe bool SequenceFinish
		{
			get
			{
				return *(base.NativePtr + (IntPtr)WBP_PSOSwitchQuality_C.__PropertyOffset_21) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)WBP_PSOSwitchQuality_C.__PropertyOffset_21) = (value ? 1 : 0);
			}
		}

		// Token: 0x170037F2 RID: 14322
		// (get) Token: 0x06020E7F RID: 134783 RVA: 0x0093A647 File Offset: 0x00938847
		// (set) Token: 0x06020E80 RID: 134784 RVA: 0x0093A657 File Offset: 0x00938857
		public unsafe bool StartCollect
		{
			get
			{
				return *(base.NativePtr + (IntPtr)WBP_PSOSwitchQuality_C.__PropertyOffset_22) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)WBP_PSOSwitchQuality_C.__PropertyOffset_22) = (value ? 1 : 0);
			}
		}

		// Token: 0x170037F3 RID: 14323
		// (get) Token: 0x06020E81 RID: 134785 RVA: 0x0093A668 File Offset: 0x00938868
		// (set) Token: 0x06020E82 RID: 134786 RVA: 0x0093A678 File Offset: 0x00938878
		public unsafe int IOSCollectionCount
		{
			get
			{
				return *(base.NativePtr + (IntPtr)WBP_PSOSwitchQuality_C.__PropertyOffset_23);
			}
			set
			{
				*(base.NativePtr + (IntPtr)WBP_PSOSwitchQuality_C.__PropertyOffset_23) = value;
			}
		}

		// Token: 0x170037F4 RID: 14324
		// (get) Token: 0x06020E83 RID: 134787 RVA: 0x0093A689 File Offset: 0x00938889
		// (set) Token: 0x06020E84 RID: 134788 RVA: 0x0093A699 File Offset: 0x00938899
		public unsafe int AndroidCollectionCount
		{
			get
			{
				return *(base.NativePtr + (IntPtr)WBP_PSOSwitchQuality_C.__PropertyOffset_24);
			}
			set
			{
				*(base.NativePtr + (IntPtr)WBP_PSOSwitchQuality_C.__PropertyOffset_24) = value;
			}
		}

		// Token: 0x170037F5 RID: 14325
		// (get) Token: 0x06020E85 RID: 134789 RVA: 0x0093A6AA File Offset: 0x009388AA
		// (set) Token: 0x06020E86 RID: 134790 RVA: 0x0093A6BA File Offset: 0x009388BA
		public unsafe bool IsIOS
		{
			get
			{
				return *(base.NativePtr + (IntPtr)WBP_PSOSwitchQuality_C.__PropertyOffset_25) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)WBP_PSOSwitchQuality_C.__PropertyOffset_25) = (value ? 1 : 0);
			}
		}

		// Token: 0x06020E87 RID: 134791 RVA: 0x0093A6CB File Offset: 0x009388CB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void FinishOneTimeCollection()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, WBP_PSOSwitchQuality_C.__FinishOneTimeCollection_NativeFunctionPtr, null);
		}

		// Token: 0x06020E88 RID: 134792 RVA: 0x0093A6E0 File Offset: 0x009388E0
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetHighQaulity(string MaterialQuality)
		{
			WBP_PSOSwitchQuality_C.__SetHighQaulity_FunctionParams* ptr = stackalloc WBP_PSOSwitchQuality_C.__SetHighQaulity_FunctionParams[(UIntPtr)63] + 15L / (long)sizeof(WBP_PSOSwitchQuality_C.__SetHighQaulity_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(WBP_PSOSwitchQuality_C.__SetHighQaulity_NativeFunctionPtr, (void*)ptr, 1);
			FString.CopyFrom((void*)(&ptr->MaterialQuality), MaterialQuality);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, WBP_PSOSwitchQuality_C.__SetHighQaulity_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(WBP_PSOSwitchQuality_C.__SetHighQaulity_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x06020E89 RID: 134793 RVA: 0x0093A740 File Offset: 0x00938940
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetMiddleQuality(string MaterialQuality)
		{
			WBP_PSOSwitchQuality_C.__SetMiddleQuality_FunctionParams* ptr = stackalloc WBP_PSOSwitchQuality_C.__SetMiddleQuality_FunctionParams[(UIntPtr)63] + 15L / (long)sizeof(WBP_PSOSwitchQuality_C.__SetMiddleQuality_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(WBP_PSOSwitchQuality_C.__SetMiddleQuality_NativeFunctionPtr, (void*)ptr, 1);
			FString.CopyFrom((void*)(&ptr->MaterialQuality), MaterialQuality);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, WBP_PSOSwitchQuality_C.__SetMiddleQuality_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(WBP_PSOSwitchQuality_C.__SetMiddleQuality_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x06020E8A RID: 134794 RVA: 0x0093A7A0 File Offset: 0x009389A0
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetLowQuality(string MaterialQuality)
		{
			WBP_PSOSwitchQuality_C.__SetLowQuality_FunctionParams* ptr = stackalloc WBP_PSOSwitchQuality_C.__SetLowQuality_FunctionParams[(UIntPtr)63] + 15L / (long)sizeof(WBP_PSOSwitchQuality_C.__SetLowQuality_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(WBP_PSOSwitchQuality_C.__SetLowQuality_NativeFunctionPtr, (void*)ptr, 1);
			FString.CopyFrom((void*)(&ptr->MaterialQuality), MaterialQuality);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, WBP_PSOSwitchQuality_C.__SetLowQuality_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(WBP_PSOSwitchQuality_C.__SetLowQuality_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x06020E8B RID: 134795 RVA: 0x0093A800 File Offset: 0x00938A00
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetlowestQuality(string MaterialQuality)
		{
			WBP_PSOSwitchQuality_C.__SetlowestQuality_FunctionParams* ptr = stackalloc WBP_PSOSwitchQuality_C.__SetlowestQuality_FunctionParams[(UIntPtr)63] + 15L / (long)sizeof(WBP_PSOSwitchQuality_C.__SetlowestQuality_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(WBP_PSOSwitchQuality_C.__SetlowestQuality_NativeFunctionPtr, (void*)ptr, 1);
			FString.CopyFrom((void*)(&ptr->MaterialQuality), MaterialQuality);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, WBP_PSOSwitchQuality_C.__SetlowestQuality_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(WBP_PSOSwitchQuality_C.__SetlowestQuality_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x06020E8C RID: 134796 RVA: 0x0093A85D File Offset: 0x00938A5D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void PlayerSequence()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, WBP_PSOSwitchQuality_C.__PlayerSequence_NativeFunctionPtr, null);
		}

		// Token: 0x06020E8D RID: 134797 RVA: 0x0093A871 File Offset: 0x00938A71
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void BndEvt__PSOSwitchQuality_Button_5_K2Node_ComponentBoundEvent_2_OnButtonClickedEvent__DelegateSignature()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, WBP_PSOSwitchQuality_C.__BndEvt__PSOSwitchQuality_Button_5_K2Node_ComponentBoundEvent_2_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr, null);
		}

		// Token: 0x06020E8E RID: 134798 RVA: 0x0093A885 File Offset: 0x00938A85
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void BndEvt__PSOSwitchQuality_Button_6_K2Node_ComponentBoundEvent_3_OnButtonClickedEvent__DelegateSignature()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, WBP_PSOSwitchQuality_C.__BndEvt__PSOSwitchQuality_Button_6_K2Node_ComponentBoundEvent_3_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr, null);
		}

		// Token: 0x06020E8F RID: 134799 RVA: 0x0093A899 File Offset: 0x00938A99
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void BndEvt__PSOSwitchQuality_Button_7_K2Node_ComponentBoundEvent_4_OnButtonClickedEvent__DelegateSignature()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, WBP_PSOSwitchQuality_C.__BndEvt__PSOSwitchQuality_Button_7_K2Node_ComponentBoundEvent_4_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr, null);
		}

		// Token: 0x06020E90 RID: 134800 RVA: 0x0093A8AD File Offset: 0x00938AAD
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void BndEvt__PSOSwitchQuality_Button_4_K2Node_ComponentBoundEvent_1_OnButtonClickedEvent__DelegateSignature()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, WBP_PSOSwitchQuality_C.__BndEvt__PSOSwitchQuality_Button_4_K2Node_ComponentBoundEvent_1_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr, null);
		}

		// Token: 0x06020E91 RID: 134801 RVA: 0x0093A8C1 File Offset: 0x00938AC1
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void BndEvt__PSOSwitchQuality_Button_K2Node_ComponentBoundEvent_6_OnButtonClickedEvent__DelegateSignature()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, WBP_PSOSwitchQuality_C.__BndEvt__PSOSwitchQuality_Button_K2Node_ComponentBoundEvent_6_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr, null);
		}

		// Token: 0x06020E92 RID: 134802 RVA: 0x0093A8D5 File Offset: 0x00938AD5
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void BndEvt__PSOSwitchQuality_Button_1_K2Node_ComponentBoundEvent_7_OnButtonClickedEvent__DelegateSignature()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, WBP_PSOSwitchQuality_C.__BndEvt__PSOSwitchQuality_Button_1_K2Node_ComponentBoundEvent_7_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr, null);
		}

		// Token: 0x06020E93 RID: 134803 RVA: 0x0093A8E9 File Offset: 0x00938AE9
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void BndEvt__PSOSwitchQuality_BtnClose_K2Node_ComponentBoundEvent_0_OnButtonClickedEvent__DelegateSignature()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, WBP_PSOSwitchQuality_C.__BndEvt__PSOSwitchQuality_BtnClose_K2Node_ComponentBoundEvent_0_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr, null);
		}

		// Token: 0x06020E94 RID: 134804 RVA: 0x0093A900 File Offset: 0x00938B00
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void Tick(FGeometry MyGeometry, float InDeltaTime)
		{
			WBP_PSOSwitchQuality_C.__Tick_FunctionParams* ptr = stackalloc WBP_PSOSwitchQuality_C.__Tick_FunctionParams[(UIntPtr)75] + 15L / (long)sizeof(WBP_PSOSwitchQuality_C.__Tick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(WBP_PSOSwitchQuality_C.__Tick_NativeFunctionPtr, (void*)ptr, 1);
			if (MyGeometry != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FGeometry.StaticStruct(), &ptr->MyGeometry, MyGeometry.NativePtr, 1, false);
			}
			ptr->InDeltaTime = InDeltaTime;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, WBP_PSOSwitchQuality_C.__Tick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06020E95 RID: 134805 RVA: 0x0093A968 File Offset: 0x00938B68
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void Tick_Implementation(FGeometry MyGeometry, float InDeltaTime)
		{
			WBP_PSOSwitchQuality_C.__Tick_FunctionParams* ptr = stackalloc WBP_PSOSwitchQuality_C.__Tick_FunctionParams[(UIntPtr)75] + 15L / (long)sizeof(WBP_PSOSwitchQuality_C.__Tick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(WBP_PSOSwitchQuality_C.__Tick_NativeFunctionPtr, (void*)ptr, 1);
			if (MyGeometry != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FGeometry.StaticStruct(), &ptr->MyGeometry, MyGeometry.NativePtr, 1, false);
			}
			ptr->InDeltaTime = InDeltaTime;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, WBP_PSOSwitchQuality_C.__Tick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06020E96 RID: 134806 RVA: 0x0093A9D1 File Offset: 0x00938BD1
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void BndEvt__PSOSwitchQuality_Button_2_K2Node_ComponentBoundEvent_8_OnButtonClickedEvent__DelegateSignature()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, WBP_PSOSwitchQuality_C.__BndEvt__PSOSwitchQuality_Button_2_K2Node_ComponentBoundEvent_8_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr, null);
		}

		// Token: 0x06020E97 RID: 134807 RVA: 0x0093A9E5 File Offset: 0x00938BE5
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void BndEvt__WBP_PSOSwitchQuality_Button_3_K2Node_ComponentBoundEvent_9_OnButtonClickedEvent__DelegateSignature()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, WBP_PSOSwitchQuality_C.__BndEvt__WBP_PSOSwitchQuality_Button_3_K2Node_ComponentBoundEvent_9_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr, null);
		}

		// Token: 0x06020E98 RID: 134808 RVA: 0x0093A9F9 File Offset: 0x00938BF9
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void BndEvt__WBP_PSOSwitchQuality_Button_8_K2Node_ComponentBoundEvent_5_OnButtonClickedEvent__DelegateSignature()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, WBP_PSOSwitchQuality_C.__BndEvt__WBP_PSOSwitchQuality_Button_8_K2Node_ComponentBoundEvent_5_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr, null);
		}

		// Token: 0x06020E99 RID: 134809 RVA: 0x0093AA0D File Offset: 0x00938C0D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void BndEvt__WBP_PSOSwitchQuality_Button_12_K2Node_ComponentBoundEvent_10_OnButtonClickedEvent__DelegateSignature()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, WBP_PSOSwitchQuality_C.__BndEvt__WBP_PSOSwitchQuality_Button_12_K2Node_ComponentBoundEvent_10_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr, null);
		}

		// Token: 0x06020E9A RID: 134810 RVA: 0x0093AA21 File Offset: 0x00938C21
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void Construct()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, WBP_PSOSwitchQuality_C.__Construct_NativeFunctionPtr, null);
		}

		// Token: 0x06020E9B RID: 134811 RVA: 0x0093AA35 File Offset: 0x00938C35
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void Construct_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, WBP_PSOSwitchQuality_C.__Construct_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06020E9C RID: 134812 RVA: 0x0093AA4C File Offset: 0x00938C4C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_WBP_PSOSwitchQuality(int EntryPoint)
		{
			WBP_PSOSwitchQuality_C.__ExecuteUbergraph_WBP_PSOSwitchQuality_FunctionParams* ptr = stackalloc WBP_PSOSwitchQuality_C.__ExecuteUbergraph_WBP_PSOSwitchQuality_FunctionParams[(UIntPtr)239] + 15L / (long)sizeof(WBP_PSOSwitchQuality_C.__ExecuteUbergraph_WBP_PSOSwitchQuality_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(WBP_PSOSwitchQuality_C.__ExecuteUbergraph_WBP_PSOSwitchQuality_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, WBP_PSOSwitchQuality_C.__ExecuteUbergraph_WBP_PSOSwitchQuality_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06020E9D RID: 134813 RVA: 0x0093AA96 File Offset: 0x00938C96
		protected WBP_PSOSwitchQuality_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401081C RID: 67612
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PSOSwitchSettingDebug/WBP_PSOSwitchQuality.WBP_PSOSwitchQuality_C";

		// Token: 0x0401081D RID: 67613
		private static IntPtr _ClassPtr;

		// Token: 0x0401081E RID: 67614
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401081F RID: 67615
		internal static int __PropertyOffset_0;

		// Token: 0x04010820 RID: 67616
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04010821 RID: 67617
		internal static int __PropertyOffset_1;

		// Token: 0x04010822 RID: 67618
		internal static int __PropertyOffset_2;

		// Token: 0x04010823 RID: 67619
		internal static int __PropertyOffset_3;

		// Token: 0x04010824 RID: 67620
		internal static int __PropertyOffset_4;

		// Token: 0x04010825 RID: 67621
		internal static int __PropertyOffset_5;

		// Token: 0x04010826 RID: 67622
		internal static int __PropertyOffset_6;

		// Token: 0x04010827 RID: 67623
		internal static int __PropertyOffset_7;

		// Token: 0x04010828 RID: 67624
		internal static int __PropertyOffset_8;

		// Token: 0x04010829 RID: 67625
		internal static int __PropertyOffset_9;

		// Token: 0x0401082A RID: 67626
		internal static int __PropertyOffset_10;

		// Token: 0x0401082B RID: 67627
		internal static int __PropertyOffset_11;

		// Token: 0x0401082C RID: 67628
		internal static int __PropertyOffset_12;

		// Token: 0x0401082D RID: 67629
		internal static int __PropertyOffset_13;

		// Token: 0x0401082E RID: 67630
		internal static int __PropertyOffset_14;

		// Token: 0x0401082F RID: 67631
		internal static int __PropertyOffset_15;

		// Token: 0x04010830 RID: 67632
		internal static int __PropertyOffset_16;

		// Token: 0x04010831 RID: 67633
		internal static int __PropertyOffset_17;

		// Token: 0x04010832 RID: 67634
		internal static int __PropertyOffset_18;

		// Token: 0x04010833 RID: 67635
		internal static int __PropertyOffset_19;

		// Token: 0x04010834 RID: 67636
		internal static int __PropertyOffset_20;

		// Token: 0x04010835 RID: 67637
		internal static int __PropertyOffset_21;

		// Token: 0x04010836 RID: 67638
		internal static int __PropertyOffset_22;

		// Token: 0x04010837 RID: 67639
		internal static int __PropertyOffset_23;

		// Token: 0x04010838 RID: 67640
		internal static int __PropertyOffset_24;

		// Token: 0x04010839 RID: 67641
		internal static int __PropertyOffset_25;

		// Token: 0x0401083A RID: 67642
		private static IntPtr __FinishOneTimeCollection_NativeFunctionPtr;

		// Token: 0x0401083B RID: 67643
		private static IntPtr __SetHighQaulity_NativeFunctionPtr;

		// Token: 0x0401083C RID: 67644
		private static IntPtr __SetMiddleQuality_NativeFunctionPtr;

		// Token: 0x0401083D RID: 67645
		private static IntPtr __SetLowQuality_NativeFunctionPtr;

		// Token: 0x0401083E RID: 67646
		private static IntPtr __SetlowestQuality_NativeFunctionPtr;

		// Token: 0x0401083F RID: 67647
		private static IntPtr __PlayerSequence_NativeFunctionPtr;

		// Token: 0x04010840 RID: 67648
		private static IntPtr __BndEvt__PSOSwitchQuality_Button_5_K2Node_ComponentBoundEvent_2_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04010841 RID: 67649
		private static IntPtr __BndEvt__PSOSwitchQuality_Button_6_K2Node_ComponentBoundEvent_3_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04010842 RID: 67650
		private static IntPtr __BndEvt__PSOSwitchQuality_Button_7_K2Node_ComponentBoundEvent_4_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04010843 RID: 67651
		private static IntPtr __BndEvt__PSOSwitchQuality_Button_4_K2Node_ComponentBoundEvent_1_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04010844 RID: 67652
		private static IntPtr __BndEvt__PSOSwitchQuality_Button_K2Node_ComponentBoundEvent_6_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04010845 RID: 67653
		private static IntPtr __BndEvt__PSOSwitchQuality_Button_1_K2Node_ComponentBoundEvent_7_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04010846 RID: 67654
		private static IntPtr __BndEvt__PSOSwitchQuality_BtnClose_K2Node_ComponentBoundEvent_0_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04010847 RID: 67655
		private static IntPtr __Tick_NativeFunctionPtr;

		// Token: 0x04010848 RID: 67656
		private static IntPtr __BndEvt__PSOSwitchQuality_Button_2_K2Node_ComponentBoundEvent_8_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04010849 RID: 67657
		private static IntPtr __BndEvt__WBP_PSOSwitchQuality_Button_3_K2Node_ComponentBoundEvent_9_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0401084A RID: 67658
		private static IntPtr __BndEvt__WBP_PSOSwitchQuality_Button_8_K2Node_ComponentBoundEvent_5_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0401084B RID: 67659
		private static IntPtr __BndEvt__WBP_PSOSwitchQuality_Button_12_K2Node_ComponentBoundEvent_10_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0401084C RID: 67660
		private static IntPtr __Construct_NativeFunctionPtr;

		// Token: 0x0401084D RID: 67661
		private static IntPtr __ExecuteUbergraph_WBP_PSOSwitchQuality_NativeFunctionPtr;

		// Token: 0x02009A46 RID: 39494
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 48)]
		protected ref struct __SetHighQaulity_FunctionParams
		{
			// Token: 0x04032146 RID: 205126
			[FieldOffset(0)]
			public FString MaterialQuality;
		}

		// Token: 0x02009A47 RID: 39495
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 48)]
		protected ref struct __SetMiddleQuality_FunctionParams
		{
			// Token: 0x04032147 RID: 205127
			[FieldOffset(0)]
			public FString MaterialQuality;
		}

		// Token: 0x02009A48 RID: 39496
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 48)]
		protected ref struct __SetLowQuality_FunctionParams
		{
			// Token: 0x04032148 RID: 205128
			[FieldOffset(0)]
			public FString MaterialQuality;
		}

		// Token: 0x02009A49 RID: 39497
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 48)]
		protected ref struct __SetlowestQuality_FunctionParams
		{
			// Token: 0x04032149 RID: 205129
			[FieldOffset(0)]
			public FString MaterialQuality;
		}

		// Token: 0x02009A4A RID: 39498
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 60)]
		protected new ref struct __Tick_FunctionParams
		{
			// Token: 0x0403214A RID: 205130
			[FieldOffset(0)]
			public byte MyGeometry;

			// Token: 0x0403214B RID: 205131
			[FieldOffset(56)]
			public float InDeltaTime;
		}

		// Token: 0x02009A4B RID: 39499
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 224)]
		protected ref struct __ExecuteUbergraph_WBP_PSOSwitchQuality_FunctionParams
		{
			// Token: 0x0403214C RID: 205132
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
