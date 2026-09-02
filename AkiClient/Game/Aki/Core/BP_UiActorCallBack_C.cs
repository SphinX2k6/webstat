using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Core
{
	// Token: 0x02003F3C RID: 16188
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Core/BP_UiActorCallBack.BP_UiActorCallBack_C")]
	[UnrealStructLayout(1112, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1112)]
	public class BP_UiActorCallBack_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060286C8 RID: 165576 RVA: 0x00A0A2CF File Offset: 0x00A084CF
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_UiActorCallBack_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Core/BP_UiActorCallBack.BP_UiActorCallBack_C");
			}
			return BP_UiActorCallBack_C._ClassPtr;
		}

		// Token: 0x060286C9 RID: 165577 RVA: 0x00A0A2F4 File Offset: 0x00A084F4
		public BP_UiActorCallBack_C() : this(BuiltinUtils.AllocNativeUObject(BP_UiActorCallBack_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060286CA RID: 165578 RVA: 0x00A0A31C File Offset: 0x00A0851C
		public BP_UiActorCallBack_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_UiActorCallBack_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700623F RID: 25151
		// (get) Token: 0x060286CB RID: 165579 RVA: 0x00A0A34F File Offset: 0x00A0854F
		// (set) Token: 0x060286CC RID: 165580 RVA: 0x00A0A363 File Offset: 0x00A08563
		[Nullable(2)]
		public unsafe USceneComponent DefaultSceneRoot
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_UiActorCallBack_C.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_UiActorCallBack_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x17006240 RID: 25152
		// (get) Token: 0x060286CD RID: 165581 RVA: 0x00A0A378 File Offset: 0x00A08578
		// (set) Token: 0x060286CE RID: 165582 RVA: 0x00A0A3B1 File Offset: 0x00A085B1
		public UiAnimNotifyStateEffectPlay UiAnimNotifyStateEffectPlay
		{
			get
			{
				base.FastCheckIsValid();
				UiAnimNotifyStateEffectPlay result;
				if ((result = this._UiAnimNotifyStateEffectPlay) == null)
				{
					result = (this._UiAnimNotifyStateEffectPlay = new UiAnimNotifyStateEffectPlay(base.NativePtr + (IntPtr)BP_UiActorCallBack_C.__PropertyOffset_1, this));
				}
				return result;
			}
			set
			{
				FMulticastScriptDelegate.NativeCopy(base.NativePtr + (IntPtr)BP_UiActorCallBack_C.__PropertyOffset_1, (value != null) ? value.NativePtr : ((IntPtr)0));
			}
		}

		// Token: 0x17006241 RID: 25153
		// (get) Token: 0x060286CF RID: 165583 RVA: 0x00A0A3D4 File Offset: 0x00A085D4
		// (set) Token: 0x060286D0 RID: 165584 RVA: 0x00A0A40D File Offset: 0x00A0860D
		public UiAnimNotifyStateEffectStop UiAnimNotifyStateEffectStop
		{
			get
			{
				base.FastCheckIsValid();
				UiAnimNotifyStateEffectStop result;
				if ((result = this._UiAnimNotifyStateEffectStop) == null)
				{
					result = (this._UiAnimNotifyStateEffectStop = new UiAnimNotifyStateEffectStop(base.NativePtr + (IntPtr)BP_UiActorCallBack_C.__PropertyOffset_2, this));
				}
				return result;
			}
			set
			{
				FMulticastScriptDelegate.NativeCopy(base.NativePtr + (IntPtr)BP_UiActorCallBack_C.__PropertyOffset_2, (value != null) ? value.NativePtr : ((IntPtr)0));
			}
		}

		// Token: 0x17006242 RID: 25154
		// (get) Token: 0x060286D1 RID: 165585 RVA: 0x00A0A430 File Offset: 0x00A08630
		// (set) Token: 0x060286D2 RID: 165586 RVA: 0x00A0A469 File Offset: 0x00A08669
		public UiAnimNotifyEffect UiAnimNotifyEffect
		{
			get
			{
				base.FastCheckIsValid();
				UiAnimNotifyEffect result;
				if ((result = this._UiAnimNotifyEffect) == null)
				{
					result = (this._UiAnimNotifyEffect = new UiAnimNotifyEffect(base.NativePtr + (IntPtr)BP_UiActorCallBack_C.__PropertyOffset_3, this));
				}
				return result;
			}
			set
			{
				FMulticastScriptDelegate.NativeCopy(base.NativePtr + (IntPtr)BP_UiActorCallBack_C.__PropertyOffset_3, (value != null) ? value.NativePtr : ((IntPtr)0));
			}
		}

		// Token: 0x17006243 RID: 25155
		// (get) Token: 0x060286D3 RID: 165587 RVA: 0x00A0A48C File Offset: 0x00A0868C
		// (set) Token: 0x060286D4 RID: 165588 RVA: 0x00A0A4C5 File Offset: 0x00A086C5
		public UiAnimNotifyModel UiAnimNotifyModel
		{
			get
			{
				base.FastCheckIsValid();
				UiAnimNotifyModel result;
				if ((result = this._UiAnimNotifyModel) == null)
				{
					result = (this._UiAnimNotifyModel = new UiAnimNotifyModel(base.NativePtr + (IntPtr)BP_UiActorCallBack_C.__PropertyOffset_4, this));
				}
				return result;
			}
			set
			{
				FMulticastScriptDelegate.NativeCopy(base.NativePtr + (IntPtr)BP_UiActorCallBack_C.__PropertyOffset_4, (value != null) ? value.NativePtr : ((IntPtr)0));
			}
		}

		// Token: 0x17006244 RID: 25156
		// (get) Token: 0x060286D5 RID: 165589 RVA: 0x00A0A4E8 File Offset: 0x00A086E8
		// (set) Token: 0x060286D6 RID: 165590 RVA: 0x00A0A521 File Offset: 0x00A08721
		public UiAnimNotifyEndPoint UiAnimNotifyEndPoint
		{
			get
			{
				base.FastCheckIsValid();
				UiAnimNotifyEndPoint result;
				if ((result = this._UiAnimNotifyEndPoint) == null)
				{
					result = (this._UiAnimNotifyEndPoint = new UiAnimNotifyEndPoint(base.NativePtr + (IntPtr)BP_UiActorCallBack_C.__PropertyOffset_5, this));
				}
				return result;
			}
			set
			{
				FMulticastScriptDelegate.NativeCopy(base.NativePtr + (IntPtr)BP_UiActorCallBack_C.__PropertyOffset_5, (value != null) ? value.NativePtr : ((IntPtr)0));
			}
		}

		// Token: 0x060286D7 RID: 165591 RVA: 0x00A0A542 File Offset: 0x00A08742
		protected BP_UiActorCallBack_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04015438 RID: 87096
		public new const string __ObjectPath = "/Game/Aki/Core/BP_UiActorCallBack.BP_UiActorCallBack_C";

		// Token: 0x04015439 RID: 87097
		private static IntPtr _ClassPtr;

		// Token: 0x0401543A RID: 87098
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401543B RID: 87099
		public static IntPtr __UiAnimNotifyEndPoint__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0401543C RID: 87100
		public static IntPtr __UiAnimNotifyModel__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0401543D RID: 87101
		public static IntPtr __UiAnimNotifyEffect__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0401543E RID: 87102
		public static IntPtr __UiAnimNotifyStateEffectStop__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0401543F RID: 87103
		public static IntPtr __UiAnimNotifyStateEffectPlay__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04015440 RID: 87104
		internal static int __PropertyOffset_0;

		// Token: 0x04015441 RID: 87105
		internal static int __PropertyOffset_1;

		// Token: 0x04015442 RID: 87106
		[Nullable(2)]
		private UiAnimNotifyStateEffectPlay _UiAnimNotifyStateEffectPlay;

		// Token: 0x04015443 RID: 87107
		internal static int __PropertyOffset_2;

		// Token: 0x04015444 RID: 87108
		[Nullable(2)]
		private UiAnimNotifyStateEffectStop _UiAnimNotifyStateEffectStop;

		// Token: 0x04015445 RID: 87109
		internal static int __PropertyOffset_3;

		// Token: 0x04015446 RID: 87110
		[Nullable(2)]
		private UiAnimNotifyEffect _UiAnimNotifyEffect;

		// Token: 0x04015447 RID: 87111
		internal static int __PropertyOffset_4;

		// Token: 0x04015448 RID: 87112
		[Nullable(2)]
		private UiAnimNotifyModel _UiAnimNotifyModel;

		// Token: 0x04015449 RID: 87113
		internal static int __PropertyOffset_5;

		// Token: 0x0401544A RID: 87114
		[Nullable(2)]
		private UiAnimNotifyEndPoint _UiAnimNotifyEndPoint;
	}
}
