using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.UI.Module.HotFix
{
	// Token: 0x0200397C RID: 14716
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/UI/Module/HotFix/HotFixLGUIEventSystemActor.HotFixLGUIEventSystemActor_C")]
	[UnrealStructLayout(1128, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1128)]
	public class HotFixLGUIEventSystemActor_C : ALGUIEventSystemActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601DA61 RID: 121441 RVA: 0x008DC293 File Offset: 0x008DA493
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (HotFixLGUIEventSystemActor_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/UI/Module/HotFix/HotFixLGUIEventSystemActor.HotFixLGUIEventSystemActor_C");
			}
			return HotFixLGUIEventSystemActor_C._ClassPtr;
		}

		// Token: 0x0601DA62 RID: 121442 RVA: 0x008DC2B8 File Offset: 0x008DA4B8
		public HotFixLGUIEventSystemActor_C() : this(BuiltinUtils.AllocNativeUObject(HotFixLGUIEventSystemActor_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601DA63 RID: 121443 RVA: 0x008DC2E0 File Offset: 0x008DA4E0
		[NullableContext(1)]
		public HotFixLGUIEventSystemActor_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(HotFixLGUIEventSystemActor_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17002710 RID: 10000
		// (get) Token: 0x0601DA64 RID: 121444 RVA: 0x008DC313 File Offset: 0x008DA513
		// (set) Token: 0x0601DA65 RID: 121445 RVA: 0x008DC327 File Offset: 0x008DA527
		public unsafe ULGUI_TouchInputModule LGUI_TouchInputModule
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<ULGUI_TouchInputModule>(base.NativePtr / (IntPtr)sizeof(void*) + HotFixLGUIEventSystemActor_C.__PropertyOffset_0);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + HotFixLGUIEventSystemActor_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x17002711 RID: 10001
		// (get) Token: 0x0601DA66 RID: 121446 RVA: 0x008DC33C File Offset: 0x008DA53C
		// (set) Token: 0x0601DA67 RID: 121447 RVA: 0x008DC350 File Offset: 0x008DA550
		public unsafe ULGUI_StandaloneInputModule LGUI_StandaloneInputModule
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<ULGUI_StandaloneInputModule>(base.NativePtr / (IntPtr)sizeof(void*) + HotFixLGUIEventSystemActor_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + HotFixLGUIEventSystemActor_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17002712 RID: 10002
		// (get) Token: 0x0601DA68 RID: 121448 RVA: 0x008DC365 File Offset: 0x008DA565
		// (set) Token: 0x0601DA69 RID: 121449 RVA: 0x008DC379 File Offset: 0x008DA579
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + HotFixLGUIEventSystemActor_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + HotFixLGUIEventSystemActor_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17002713 RID: 10003
		// (get) Token: 0x0601DA6A RID: 121450 RVA: 0x008DC38E File Offset: 0x008DA58E
		// (set) Token: 0x0601DA6B RID: 121451 RVA: 0x008DC3A2 File Offset: 0x008DA5A2
		public unsafe ULGUI_PointerInputModule ValidInputModule
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<ULGUI_PointerInputModule>(base.NativePtr / (IntPtr)sizeof(void*) + HotFixLGUIEventSystemActor_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + HotFixLGUIEventSystemActor_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17002714 RID: 10004
		// (get) Token: 0x0601DA6C RID: 121452 RVA: 0x008DC3B8 File Offset: 0x008DA5B8
		// (set) Token: 0x0601DA6D RID: 121453 RVA: 0x008DC3F1 File Offset: 0x008DA5F1
		[Nullable(1)]
		public OnMiddleMouseScroll OnMiddleMouseScroll
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				OnMiddleMouseScroll result;
				if ((result = this._OnMiddleMouseScroll) == null)
				{
					result = (this._OnMiddleMouseScroll = new OnMiddleMouseScroll(base.NativePtr + (IntPtr)HotFixLGUIEventSystemActor_C.__PropertyOffset_4, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				FMulticastScriptDelegate.NativeCopy(base.NativePtr + (IntPtr)HotFixLGUIEventSystemActor_C.__PropertyOffset_4, (value != null) ? value.NativePtr : ((IntPtr)0));
			}
		}

		// Token: 0x17002715 RID: 10005
		// (get) Token: 0x0601DA6E RID: 121454 RVA: 0x008DC414 File Offset: 0x008DA614
		// (set) Token: 0x0601DA6F RID: 121455 RVA: 0x008DC44D File Offset: 0x008DA64D
		[Nullable(1)]
		public OnTouch OnTouch
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				OnTouch result;
				if ((result = this._OnTouch) == null)
				{
					result = (this._OnTouch = new OnTouch(base.NativePtr + (IntPtr)HotFixLGUIEventSystemActor_C.__PropertyOffset_5, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				FMulticastScriptDelegate.NativeCopy(base.NativePtr + (IntPtr)HotFixLGUIEventSystemActor_C.__PropertyOffset_5, (value != null) ? value.NativePtr : ((IntPtr)0));
			}
		}

		// Token: 0x17002716 RID: 10006
		// (get) Token: 0x0601DA70 RID: 121456 RVA: 0x008DC470 File Offset: 0x008DA670
		// (set) Token: 0x0601DA71 RID: 121457 RVA: 0x008DC4A9 File Offset: 0x008DA6A9
		[Nullable(1)]
		public OnTouchMove OnTouchMove
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				OnTouchMove result;
				if ((result = this._OnTouchMove) == null)
				{
					result = (this._OnTouchMove = new OnTouchMove(base.NativePtr + (IntPtr)HotFixLGUIEventSystemActor_C.__PropertyOffset_6, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				FMulticastScriptDelegate.NativeCopy(base.NativePtr + (IntPtr)HotFixLGUIEventSystemActor_C.__PropertyOffset_6, (value != null) ? value.NativePtr : ((IntPtr)0));
			}
		}

		// Token: 0x17002717 RID: 10007
		// (get) Token: 0x0601DA72 RID: 121458 RVA: 0x008DC4CC File Offset: 0x008DA6CC
		// (set) Token: 0x0601DA73 RID: 121459 RVA: 0x008DC505 File Offset: 0x008DA705
		[Nullable(1)]
		public OnClickKey OnClickKey
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				OnClickKey result;
				if ((result = this._OnClickKey) == null)
				{
					result = (this._OnClickKey = new OnClickKey(base.NativePtr + (IntPtr)HotFixLGUIEventSystemActor_C.__PropertyOffset_7, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				FMulticastScriptDelegate.NativeCopy(base.NativePtr + (IntPtr)HotFixLGUIEventSystemActor_C.__PropertyOffset_7, (value != null) ? value.NativePtr : ((IntPtr)0));
			}
		}

		// Token: 0x0601DA74 RID: 121460 RVA: 0x008DC526 File Offset: 0x008DA726
		protected HotFixLGUIEventSystemActor_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400E848 RID: 59464
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/UI/Module/HotFix/HotFixLGUIEventSystemActor.HotFixLGUIEventSystemActor_C";

		// Token: 0x0400E849 RID: 59465
		private static IntPtr _ClassPtr;

		// Token: 0x0400E84A RID: 59466
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400E84B RID: 59467
		public static IntPtr __OnClickKey__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0400E84C RID: 59468
		public static IntPtr __OnTouchMove__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0400E84D RID: 59469
		public static IntPtr __OnTouch__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0400E84E RID: 59470
		public static IntPtr __OnMiddleMouseScroll__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0400E84F RID: 59471
		internal static int __PropertyOffset_0;

		// Token: 0x0400E850 RID: 59472
		internal static int __PropertyOffset_1;

		// Token: 0x0400E851 RID: 59473
		internal static int __PropertyOffset_2;

		// Token: 0x0400E852 RID: 59474
		internal static int __PropertyOffset_3;

		// Token: 0x0400E853 RID: 59475
		internal static int __PropertyOffset_4;

		// Token: 0x0400E854 RID: 59476
		private OnMiddleMouseScroll _OnMiddleMouseScroll;

		// Token: 0x0400E855 RID: 59477
		internal static int __PropertyOffset_5;

		// Token: 0x0400E856 RID: 59478
		private OnTouch _OnTouch;

		// Token: 0x0400E857 RID: 59479
		internal static int __PropertyOffset_6;

		// Token: 0x0400E858 RID: 59480
		private OnTouchMove _OnTouchMove;

		// Token: 0x0400E859 RID: 59481
		internal static int __PropertyOffset_7;

		// Token: 0x0400E85A RID: 59482
		private OnClickKey _OnClickKey;
	}
}
