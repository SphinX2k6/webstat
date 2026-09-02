using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Interaction;
using AkiClient.Game.Aki.UI.Module.Common.View.Widget;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.GI.UI
{
	// Token: 0x02003C9E RID: 15518
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/GI/UI/BP_DebugInteractionControl.BP_DebugInteractionControl_C")]
	[UnrealStructLayout(1264, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1264)]
	public class BP_DebugInteractionControl_C : UUserWidget, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060248E9 RID: 149737 RVA: 0x009A0E07 File Offset: 0x0099F007
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_DebugInteractionControl_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/GI/UI/BP_DebugInteractionControl.BP_DebugInteractionControl_C");
			}
			return BP_DebugInteractionControl_C._ClassPtr;
		}

		// Token: 0x060248EA RID: 149738 RVA: 0x009A0E2C File Offset: 0x0099F02C
		public BP_DebugInteractionControl_C() : this(BuiltinUtils.AllocNativeUObject(BP_DebugInteractionControl_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060248EB RID: 149739 RVA: 0x009A0E54 File Offset: 0x0099F054
		[NullableContext(1)]
		public BP_DebugInteractionControl_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_DebugInteractionControl_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17004CB6 RID: 19638
		// (get) Token: 0x060248EC RID: 149740 RVA: 0x009A0E88 File Offset: 0x0099F088
		// (set) Token: 0x060248ED RID: 149741 RVA: 0x009A0EC1 File Offset: 0x0099F0C1
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_DebugInteractionControl_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_DebugInteractionControl_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17004CB7 RID: 19639
		// (get) Token: 0x060248EE RID: 149742 RVA: 0x009A0EE2 File Offset: 0x0099F0E2
		// (set) Token: 0x060248EF RID: 149743 RVA: 0x009A0EF6 File Offset: 0x0099F0F6
		public unsafe UButton Btn_停止水模拟
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UButton>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DebugInteractionControl_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DebugInteractionControl_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17004CB8 RID: 19640
		// (get) Token: 0x060248F0 RID: 149744 RVA: 0x009A0F0B File Offset: 0x0099F10B
		// (set) Token: 0x060248F1 RID: 149745 RVA: 0x009A0F1F File Offset: 0x0099F11F
		public unsafe UButton Btn_停止草模拟
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UButton>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DebugInteractionControl_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DebugInteractionControl_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17004CB9 RID: 19641
		// (get) Token: 0x060248F2 RID: 149746 RVA: 0x009A0F34 File Offset: 0x0099F134
		// (set) Token: 0x060248F3 RID: 149747 RVA: 0x009A0F48 File Offset: 0x0099F148
		public unsafe UButton Btn_允许水模拟
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UButton>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DebugInteractionControl_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DebugInteractionControl_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17004CBA RID: 19642
		// (get) Token: 0x060248F4 RID: 149748 RVA: 0x009A0F5D File Offset: 0x0099F15D
		// (set) Token: 0x060248F5 RID: 149749 RVA: 0x009A0F71 File Offset: 0x0099F171
		public unsafe UButton Btn_允许草模拟
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UButton>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DebugInteractionControl_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DebugInteractionControl_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17004CBB RID: 19643
		// (get) Token: 0x060248F6 RID: 149750 RVA: 0x009A0F86 File Offset: 0x0099F186
		// (set) Token: 0x060248F7 RID: 149751 RVA: 0x009A0F9A File Offset: 0x0099F19A
		public unsafe UButton Btn_启用水交互物
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UButton>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DebugInteractionControl_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DebugInteractionControl_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x17004CBC RID: 19644
		// (get) Token: 0x060248F8 RID: 149752 RVA: 0x009A0FAF File Offset: 0x0099F1AF
		// (set) Token: 0x060248F9 RID: 149753 RVA: 0x009A0FC3 File Offset: 0x0099F1C3
		public unsafe UButton Btn_启用草交互物
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UButton>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DebugInteractionControl_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DebugInteractionControl_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x17004CBD RID: 19645
		// (get) Token: 0x060248FA RID: 149754 RVA: 0x009A0FD8 File Offset: 0x0099F1D8
		// (set) Token: 0x060248FB RID: 149755 RVA: 0x009A0FEC File Offset: 0x0099F1EC
		public unsafe UButton Btn_屏蔽水交互物
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UButton>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DebugInteractionControl_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DebugInteractionControl_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x17004CBE RID: 19646
		// (get) Token: 0x060248FC RID: 149756 RVA: 0x009A1001 File Offset: 0x0099F201
		// (set) Token: 0x060248FD RID: 149757 RVA: 0x009A1015 File Offset: 0x0099F215
		public unsafe UButton Btn_屏蔽草交互物
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UButton>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DebugInteractionControl_C.__PropertyOffset_8);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DebugInteractionControl_C.__PropertyOffset_8, value);
			}
		}

		// Token: 0x17004CBF RID: 19647
		// (get) Token: 0x060248FE RID: 149758 RVA: 0x009A102A File Offset: 0x0099F22A
		// (set) Token: 0x060248FF RID: 149759 RVA: 0x009A103E File Offset: 0x0099F23E
		public unsafe UButton Button_0
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UButton>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DebugInteractionControl_C.__PropertyOffset_9);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DebugInteractionControl_C.__PropertyOffset_9, value);
			}
		}

		// Token: 0x17004CC0 RID: 19648
		// (get) Token: 0x06024900 RID: 149760 RVA: 0x009A1053 File Offset: 0x0099F253
		// (set) Token: 0x06024901 RID: 149761 RVA: 0x009A1067 File Offset: 0x0099F267
		public unsafe KuroImage_C KuroImage_C_1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<KuroImage_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DebugInteractionControl_C.__PropertyOffset_10);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DebugInteractionControl_C.__PropertyOffset_10, value);
			}
		}

		// Token: 0x17004CC1 RID: 19649
		// (get) Token: 0x06024902 RID: 149762 RVA: 0x009A107C File Offset: 0x0099F27C
		// (set) Token: 0x06024903 RID: 149763 RVA: 0x009A1090 File Offset: 0x0099F290
		public unsafe PDA_InteractionGlobalConfig_C InteractionGlobalConfig
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<PDA_InteractionGlobalConfig_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DebugInteractionControl_C.__PropertyOffset_11);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DebugInteractionControl_C.__PropertyOffset_11, value);
			}
		}

		// Token: 0x06024904 RID: 149764 RVA: 0x009A10A5 File Offset: 0x0099F2A5
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void BndEvt__BP_DebugInteractionControl_Button_0_K2Node_ComponentBoundEvent_0_OnButtonClickedEvent__DelegateSignature()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DebugInteractionControl_C.__BndEvt__BP_DebugInteractionControl_Button_0_K2Node_ComponentBoundEvent_0_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr, null);
		}

		// Token: 0x06024905 RID: 149765 RVA: 0x009A10B9 File Offset: 0x0099F2B9
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void BndEvt__BP_DebugInteractionControl_Btn_开启场景水交互_K2Node_ComponentBoundEvent_1_OnButtonClickedEvent__DelegateSignature()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DebugInteractionControl_C.__BndEvt__BP_DebugInteractionControl_Btn_开启场景水交互_K2Node_ComponentBoundEvent_1_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr, null);
		}

		// Token: 0x06024906 RID: 149766 RVA: 0x009A10CD File Offset: 0x0099F2CD
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void BndEvt__BP_DebugInteractionControl_Btn_关闭场景水交互_K2Node_ComponentBoundEvent_2_OnButtonClickedEvent__DelegateSignature()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DebugInteractionControl_C.__BndEvt__BP_DebugInteractionControl_Btn_关闭场景水交互_K2Node_ComponentBoundEvent_2_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr, null);
		}

		// Token: 0x06024907 RID: 149767 RVA: 0x009A10E1 File Offset: 0x0099F2E1
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void BndEvt__BP_DebugInteractionControl_Btn_屏蔽草交互物_K2Node_ComponentBoundEvent_3_OnButtonClickedEvent__DelegateSignature()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DebugInteractionControl_C.__BndEvt__BP_DebugInteractionControl_Btn_屏蔽草交互物_K2Node_ComponentBoundEvent_3_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr, null);
		}

		// Token: 0x06024908 RID: 149768 RVA: 0x009A10F5 File Offset: 0x0099F2F5
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void BndEvt__BP_DebugInteractionControl_Btn_启用草交互物_K2Node_ComponentBoundEvent_4_OnButtonClickedEvent__DelegateSignature()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DebugInteractionControl_C.__BndEvt__BP_DebugInteractionControl_Btn_启用草交互物_K2Node_ComponentBoundEvent_4_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr, null);
		}

		// Token: 0x06024909 RID: 149769 RVA: 0x009A1109 File Offset: 0x0099F309
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void BndEvt__BP_DebugInteractionControl_Btn_停止水模拟_K2Node_ComponentBoundEvent_5_OnButtonClickedEvent__DelegateSignature()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DebugInteractionControl_C.__BndEvt__BP_DebugInteractionControl_Btn_停止水模拟_K2Node_ComponentBoundEvent_5_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr, null);
		}

		// Token: 0x0602490A RID: 149770 RVA: 0x009A111D File Offset: 0x0099F31D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void BndEvt__BP_DebugInteractionControl_Btn_停止草模拟_K2Node_ComponentBoundEvent_6_OnButtonClickedEvent__DelegateSignature()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DebugInteractionControl_C.__BndEvt__BP_DebugInteractionControl_Btn_停止草模拟_K2Node_ComponentBoundEvent_6_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr, null);
		}

		// Token: 0x0602490B RID: 149771 RVA: 0x009A1131 File Offset: 0x0099F331
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void BndEvt__BP_DebugInteractionControl_Btn_允许水模拟_K2Node_ComponentBoundEvent_7_OnButtonClickedEvent__DelegateSignature()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DebugInteractionControl_C.__BndEvt__BP_DebugInteractionControl_Btn_允许水模拟_K2Node_ComponentBoundEvent_7_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr, null);
		}

		// Token: 0x0602490C RID: 149772 RVA: 0x009A1145 File Offset: 0x0099F345
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void BndEvt__BP_DebugInteractionControl_Btn_允许草模拟_K2Node_ComponentBoundEvent_8_OnButtonClickedEvent__DelegateSignature()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DebugInteractionControl_C.__BndEvt__BP_DebugInteractionControl_Btn_允许草模拟_K2Node_ComponentBoundEvent_8_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr, null);
		}

		// Token: 0x0602490D RID: 149773 RVA: 0x009A115C File Offset: 0x0099F35C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_DebugInteractionControl(int EntryPoint)
		{
			BP_DebugInteractionControl_C.__ExecuteUbergraph_BP_DebugInteractionControl_FunctionParams* ptr = stackalloc BP_DebugInteractionControl_C.__ExecuteUbergraph_BP_DebugInteractionControl_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_DebugInteractionControl_C.__ExecuteUbergraph_BP_DebugInteractionControl_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_DebugInteractionControl_C.__ExecuteUbergraph_BP_DebugInteractionControl_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_DebugInteractionControl_C.__ExecuteUbergraph_BP_DebugInteractionControl_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602490E RID: 149774 RVA: 0x009A11A3 File Offset: 0x0099F3A3
		protected BP_DebugInteractionControl_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04012BC2 RID: 76738
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/GI/UI/BP_DebugInteractionControl.BP_DebugInteractionControl_C";

		// Token: 0x04012BC3 RID: 76739
		private static IntPtr _ClassPtr;

		// Token: 0x04012BC4 RID: 76740
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04012BC5 RID: 76741
		internal static int __PropertyOffset_0;

		// Token: 0x04012BC6 RID: 76742
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04012BC7 RID: 76743
		internal static int __PropertyOffset_1;

		// Token: 0x04012BC8 RID: 76744
		internal static int __PropertyOffset_2;

		// Token: 0x04012BC9 RID: 76745
		internal static int __PropertyOffset_3;

		// Token: 0x04012BCA RID: 76746
		internal static int __PropertyOffset_4;

		// Token: 0x04012BCB RID: 76747
		internal static int __PropertyOffset_5;

		// Token: 0x04012BCC RID: 76748
		internal static int __PropertyOffset_6;

		// Token: 0x04012BCD RID: 76749
		internal static int __PropertyOffset_7;

		// Token: 0x04012BCE RID: 76750
		internal static int __PropertyOffset_8;

		// Token: 0x04012BCF RID: 76751
		internal static int __PropertyOffset_9;

		// Token: 0x04012BD0 RID: 76752
		internal static int __PropertyOffset_10;

		// Token: 0x04012BD1 RID: 76753
		internal static int __PropertyOffset_11;

		// Token: 0x04012BD2 RID: 76754
		private static IntPtr __BndEvt__BP_DebugInteractionControl_Button_0_K2Node_ComponentBoundEvent_0_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04012BD3 RID: 76755
		private static IntPtr __BndEvt__BP_DebugInteractionControl_Btn_开启场景水交互_K2Node_ComponentBoundEvent_1_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04012BD4 RID: 76756
		private static IntPtr __BndEvt__BP_DebugInteractionControl_Btn_关闭场景水交互_K2Node_ComponentBoundEvent_2_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04012BD5 RID: 76757
		private static IntPtr __BndEvt__BP_DebugInteractionControl_Btn_屏蔽草交互物_K2Node_ComponentBoundEvent_3_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04012BD6 RID: 76758
		private static IntPtr __BndEvt__BP_DebugInteractionControl_Btn_启用草交互物_K2Node_ComponentBoundEvent_4_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04012BD7 RID: 76759
		private static IntPtr __BndEvt__BP_DebugInteractionControl_Btn_停止水模拟_K2Node_ComponentBoundEvent_5_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04012BD8 RID: 76760
		private static IntPtr __BndEvt__BP_DebugInteractionControl_Btn_停止草模拟_K2Node_ComponentBoundEvent_6_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04012BD9 RID: 76761
		private static IntPtr __BndEvt__BP_DebugInteractionControl_Btn_允许水模拟_K2Node_ComponentBoundEvent_7_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04012BDA RID: 76762
		private static IntPtr __BndEvt__BP_DebugInteractionControl_Btn_允许草模拟_K2Node_ComponentBoundEvent_8_OnButtonClickedEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04012BDB RID: 76763
		private static IntPtr __ExecuteUbergraph_BP_DebugInteractionControl_NativeFunctionPtr;

		// Token: 0x02009E0C RID: 40460
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __ExecuteUbergraph_BP_DebugInteractionControl_FunctionParams
		{
			// Token: 0x04032853 RID: 206931
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
