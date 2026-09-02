using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.MaterialController;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Core.Fight
{
	// Token: 0x02003F77 RID: 16247
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Core/Fight/SReBulletDataPerformance.SReBulletDataPerformance")]
	[UnrealStructLayout(584, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 584)]
	public class SReBulletDataPerformance : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x060289C1 RID: 166337 RVA: 0x00A103B8 File Offset: 0x00A0E5B8
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SReBulletDataPerformance._ScriptStructPtr != 0) ? SReBulletDataPerformance._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Core/Fight/SReBulletDataPerformance.SReBulletDataPerformance", ref SReBulletDataPerformance._ScriptStructPtr);
		}

		// Token: 0x17006325 RID: 25381
		// (get) Token: 0x060289C2 RID: 166338 RVA: 0x00A103DC File Offset: 0x00A0E5DC
		// (set) Token: 0x060289C3 RID: 166339 RVA: 0x00A103EC File Offset: 0x00A0E5EC
		public unsafe bool 接手父子弹的特效
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SReBulletDataPerformance.__PropertyOffset_0) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SReBulletDataPerformance.__PropertyOffset_0) = (value ? 1 : 0);
			}
		}

		// Token: 0x17006326 RID: 25382
		// (get) Token: 0x060289C4 RID: 166340 RVA: 0x00A103FD File Offset: 0x00A0E5FD
		// (set) Token: 0x060289C5 RID: 166341 RVA: 0x00A1041C File Offset: 0x00A0E61C
		public TSoftObjectPtr<UEffectModelBase> 子弹特效DA
		{
			get
			{
				return new TSoftObjectPtr<UEffectModelBase>(base.NativePtr + (IntPtr)SReBulletDataPerformance.__PropertyOffset_1, base.MemoryOwner ?? this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)SReBulletDataPerformance.__PropertyOffset_1, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17006327 RID: 25383
		// (get) Token: 0x060289C6 RID: 166342 RVA: 0x00A10444 File Offset: 0x00A0E644
		// (set) Token: 0x060289C7 RID: 166343 RVA: 0x00A10487 File Offset: 0x00A0E687
		[Nullable(new byte[]
		{
			1,
			0,
			1
		})]
		public TMap<TEnumAsByte<EBulletEffectParam>, string> 子弹特效DA参数
		{
			[return: Nullable(new byte[]
			{
				1,
				0,
				1
			})]
			get
			{
				base.FastCheckIsValid();
				TMap<TEnumAsByte<EBulletEffectParam>, string> result;
				if ((result = this._子弹特效DA参数) == null)
				{
					result = (this._子弹特效DA参数 = new TMap<TEnumAsByte<EBulletEffectParam>, string>(base.NativePtr + (IntPtr)SReBulletDataPerformance.__PropertyOffset_2, base.MemoryOwner ?? this));
				}
				return result;
			}
			[param: Nullable(new byte[]
			{
				1,
				0,
				1
			})]
			set
			{
				this.子弹特效DA参数.CopyAssign(value);
			}
		}

		// Token: 0x17006328 RID: 25384
		// (get) Token: 0x060289C8 RID: 166344 RVA: 0x00A10498 File Offset: 0x00A0E698
		// (set) Token: 0x060289C9 RID: 166345 RVA: 0x00A104DB File Offset: 0x00A0E6DB
		[Nullable(new byte[]
		{
			1,
			0,
			1,
			1
		})]
		public TMap<TEnumAsByte<EBulletSpecificEffect>, TSoftObjectPtr<UObject>> 特殊特效DA
		{
			[return: Nullable(new byte[]
			{
				1,
				0,
				1,
				1
			})]
			get
			{
				base.FastCheckIsValid();
				TMap<TEnumAsByte<EBulletSpecificEffect>, TSoftObjectPtr<UObject>> result;
				if ((result = this._特殊特效DA) == null)
				{
					result = (this._特殊特效DA = new TMap<TEnumAsByte<EBulletSpecificEffect>, TSoftObjectPtr<UObject>>(base.NativePtr + (IntPtr)SReBulletDataPerformance.__PropertyOffset_3, base.MemoryOwner ?? this));
				}
				return result;
			}
			[param: Nullable(new byte[]
			{
				1,
				0,
				1,
				1
			})]
			set
			{
				this.特殊特效DA.CopyAssign(value);
			}
		}

		// Token: 0x17006329 RID: 25385
		// (get) Token: 0x060289CA RID: 166346 RVA: 0x00A104E9 File Offset: 0x00A0E6E9
		// (set) Token: 0x060289CB RID: 166347 RVA: 0x00A104F9 File Offset: 0x00A0E6F9
		public unsafe bool 子弹销毁调用子弹停止特效
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SReBulletDataPerformance.__PropertyOffset_4) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SReBulletDataPerformance.__PropertyOffset_4) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700632A RID: 25386
		// (get) Token: 0x060289CC RID: 166348 RVA: 0x00A1050C File Offset: 0x00A0E70C
		// (set) Token: 0x060289CD RID: 166349 RVA: 0x00A1054F File Offset: 0x00A0E74F
		[Nullable(new byte[]
		{
			1,
			0,
			1,
			1
		})]
		public TMap<TEnumAsByte<EBulletHitEffect>, TSoftObjectPtr<UObject>> 命中特效DA
		{
			[return: Nullable(new byte[]
			{
				1,
				0,
				1,
				1
			})]
			get
			{
				base.FastCheckIsValid();
				TMap<TEnumAsByte<EBulletHitEffect>, TSoftObjectPtr<UObject>> result;
				if ((result = this._命中特效DA) == null)
				{
					result = (this._命中特效DA = new TMap<TEnumAsByte<EBulletHitEffect>, TSoftObjectPtr<UObject>>(base.NativePtr + (IntPtr)SReBulletDataPerformance.__PropertyOffset_5, base.MemoryOwner ?? this));
				}
				return result;
			}
			[param: Nullable(new byte[]
			{
				1,
				0,
				1,
				1
			})]
			set
			{
				this.命中特效DA.CopyAssign(value);
			}
		}

		// Token: 0x1700632B RID: 25387
		// (get) Token: 0x060289CE RID: 166350 RVA: 0x00A1055D File Offset: 0x00A0E75D
		// (set) Token: 0x060289CF RID: 166351 RVA: 0x00A10571 File Offset: 0x00A0E771
		public unsafe string 命中音效
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SReBulletDataPerformance.__PropertyOffset_6)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SReBulletDataPerformance.__PropertyOffset_6)), value);
			}
		}

		// Token: 0x1700632C RID: 25388
		// (get) Token: 0x060289D0 RID: 166352 RVA: 0x00A10586 File Offset: 0x00A0E786
		// (set) Token: 0x060289D1 RID: 166353 RVA: 0x00A105A5 File Offset: 0x00A0E7A5
		public TSoftClassPtr<UMatineeCameraShake> 生成时攻击者震屏
		{
			get
			{
				return new TSoftClassPtr<UMatineeCameraShake>(base.NativePtr + (IntPtr)SReBulletDataPerformance.__PropertyOffset_7, base.MemoryOwner ?? this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)SReBulletDataPerformance.__PropertyOffset_7, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x1700632D RID: 25389
		// (get) Token: 0x060289D2 RID: 166354 RVA: 0x00A105CA File Offset: 0x00A0E7CA
		// (set) Token: 0x060289D3 RID: 166355 RVA: 0x00A105E9 File Offset: 0x00A0E7E9
		public TSoftClassPtr<UMatineeCameraShake> 命中时攻击者震屏
		{
			get
			{
				return new TSoftClassPtr<UMatineeCameraShake>(base.NativePtr + (IntPtr)SReBulletDataPerformance.__PropertyOffset_8, base.MemoryOwner ?? this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)SReBulletDataPerformance.__PropertyOffset_8, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x1700632E RID: 25390
		// (get) Token: 0x060289D4 RID: 166356 RVA: 0x00A1060E File Offset: 0x00A0E80E
		// (set) Token: 0x060289D5 RID: 166357 RVA: 0x00A1062D File Offset: 0x00A0E82D
		public TSoftClassPtr<UMatineeCameraShake> 命中时受击者震屏
		{
			get
			{
				return new TSoftClassPtr<UMatineeCameraShake>(base.NativePtr + (IntPtr)SReBulletDataPerformance.__PropertyOffset_9, base.MemoryOwner ?? this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)SReBulletDataPerformance.__PropertyOffset_9, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x1700632F RID: 25391
		// (get) Token: 0x060289D6 RID: 166358 RVA: 0x00A10652 File Offset: 0x00A0E852
		// (set) Token: 0x060289D7 RID: 166359 RVA: 0x00A10671 File Offset: 0x00A0E871
		public TSoftClassPtr<UMatineeCameraShake> 命中弱点时攻击者震屏
		{
			get
			{
				return new TSoftClassPtr<UMatineeCameraShake>(base.NativePtr + (IntPtr)SReBulletDataPerformance.__PropertyOffset_10, base.MemoryOwner ?? this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)SReBulletDataPerformance.__PropertyOffset_10, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17006330 RID: 25392
		// (get) Token: 0x060289D8 RID: 166360 RVA: 0x00A10696 File Offset: 0x00A0E896
		// (set) Token: 0x060289D9 RID: 166361 RVA: 0x00A106A6 File Offset: 0x00A0E8A6
		public unsafe int 最大震动次数
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SReBulletDataPerformance.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SReBulletDataPerformance.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17006331 RID: 25393
		// (get) Token: 0x060289DA RID: 166362 RVA: 0x00A106B7 File Offset: 0x00A0E8B7
		// (set) Token: 0x060289DB RID: 166363 RVA: 0x00A106C7 File Offset: 0x00A0E8C7
		public unsafe bool 震屏关联到召唤兽主人
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SReBulletDataPerformance.__PropertyOffset_12) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SReBulletDataPerformance.__PropertyOffset_12) = (value ? 1 : 0);
			}
		}

		// Token: 0x17006332 RID: 25394
		// (get) Token: 0x060289DC RID: 166364 RVA: 0x00A106D8 File Offset: 0x00A0E8D8
		// (set) Token: 0x060289DD RID: 166365 RVA: 0x00A1071B File Offset: 0x00A0E91B
		public TArray<SBulletEffectOnHitConf> 命中特效配置
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SBulletEffectOnHitConf> result;
				if ((result = this._命中特效配置) == null)
				{
					result = (this._命中特效配置 = new TArray<SBulletEffectOnHitConf>(base.NativePtr + (IntPtr)SReBulletDataPerformance.__PropertyOffset_13, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.命中特效配置.CopyAssign(value);
			}
		}

		// Token: 0x17006333 RID: 25395
		// (get) Token: 0x060289DE RID: 166366 RVA: 0x00A10729 File Offset: 0x00A0E929
		// (set) Token: 0x060289DF RID: 166367 RVA: 0x00A10748 File Offset: 0x00A0E948
		public TSoftObjectPtr<PD_CharacterControllerData_C> 受击闪白
		{
			get
			{
				return new TSoftObjectPtr<PD_CharacterControllerData_C>(base.NativePtr + (IntPtr)SReBulletDataPerformance.__PropertyOffset_14, base.MemoryOwner ?? this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)SReBulletDataPerformance.__PropertyOffset_14, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x060289E0 RID: 166368 RVA: 0x00A1076D File Offset: 0x00A0E96D
		public SReBulletDataPerformance()
		{
		}

		// Token: 0x060289E1 RID: 166369 RVA: 0x00A10778 File Offset: 0x00A0E978
		public SReBulletDataPerformance(bool 接手父子弹的特效, TSoftObjectPtr<UEffectModelBase> 子弹特效DA, [Nullable(new byte[]
		{
			1,
			0,
			1
		})] TMap<TEnumAsByte<EBulletEffectParam>, string> 子弹特效DA参数, [Nullable(new byte[]
		{
			1,
			0,
			1,
			1
		})] TMap<TEnumAsByte<EBulletSpecificEffect>, TSoftObjectPtr<UObject>> 特殊特效DA, bool 子弹销毁调用子弹停止特效, [Nullable(new byte[]
		{
			1,
			0,
			1,
			1
		})] TMap<TEnumAsByte<EBulletHitEffect>, TSoftObjectPtr<UObject>> 命中特效DA, string 命中音效, TSoftClassPtr<UMatineeCameraShake> 生成时攻击者震屏, TSoftClassPtr<UMatineeCameraShake> 命中时攻击者震屏, TSoftClassPtr<UMatineeCameraShake> 命中时受击者震屏, TSoftClassPtr<UMatineeCameraShake> 命中弱点时攻击者震屏, int 最大震动次数, bool 震屏关联到召唤兽主人, TArray<SBulletEffectOnHitConf> 命中特效配置, TSoftObjectPtr<PD_CharacterControllerData_C> 受击闪白)
		{
			this.接手父子弹的特效 = 接手父子弹的特效;
			this.子弹特效DA = 子弹特效DA;
			this.子弹特效DA参数 = 子弹特效DA参数;
			this.特殊特效DA = 特殊特效DA;
			this.子弹销毁调用子弹停止特效 = 子弹销毁调用子弹停止特效;
			this.命中特效DA = 命中特效DA;
			this.命中音效 = 命中音效;
			this.生成时攻击者震屏 = 生成时攻击者震屏;
			this.命中时攻击者震屏 = 命中时攻击者震屏;
			this.命中时受击者震屏 = 命中时受击者震屏;
			this.命中弱点时攻击者震屏 = 命中弱点时攻击者震屏;
			this.最大震动次数 = 最大震动次数;
			this.震屏关联到召唤兽主人 = 震屏关联到召唤兽主人;
			this.命中特效配置 = 命中特效配置;
			this.受击闪白 = 受击闪白;
		}

		// Token: 0x060289E2 RID: 166370 RVA: 0x00A10800 File Offset: 0x00A0EA00
		protected override IntPtr GetUStructPtr()
		{
			return SReBulletDataPerformance.StaticStruct();
		}

		// Token: 0x060289E3 RID: 166371 RVA: 0x00A1080C File Offset: 0x00A0EA0C
		[NullableContext(2)]
		public SReBulletDataPerformance(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x060289E4 RID: 166372 RVA: 0x00A10816 File Offset: 0x00A0EA16
		public SReBulletDataPerformance(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x060289E5 RID: 166373 RVA: 0x00A10821 File Offset: 0x00A0EA21
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SReBulletDataPerformance(Pointer, false, true);
		}

		// Token: 0x060289E6 RID: 166374 RVA: 0x00A1082B File Offset: 0x00A0EA2B
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SReBulletDataPerformance(Pointer, MemoryOwner);
		}

		// Token: 0x040156AC RID: 87724
		public const string __ObjectPath = "/Game/Aki/Core/Fight/SReBulletDataPerformance.SReBulletDataPerformance";

		// Token: 0x040156AD RID: 87725
		private static IntPtr _ScriptStructPtr;

		// Token: 0x040156AE RID: 87726
		internal static int __PropertyOffset_0;

		// Token: 0x040156AF RID: 87727
		internal static int __PropertyOffset_1;

		// Token: 0x040156B0 RID: 87728
		internal static int __PropertyOffset_2;

		// Token: 0x040156B1 RID: 87729
		[Nullable(new byte[]
		{
			2,
			0,
			1
		})]
		private TMap<TEnumAsByte<EBulletEffectParam>, string> _子弹特效DA参数;

		// Token: 0x040156B2 RID: 87730
		internal static int __PropertyOffset_3;

		// Token: 0x040156B3 RID: 87731
		[Nullable(new byte[]
		{
			2,
			0,
			1,
			1
		})]
		private TMap<TEnumAsByte<EBulletSpecificEffect>, TSoftObjectPtr<UObject>> _特殊特效DA;

		// Token: 0x040156B4 RID: 87732
		internal static int __PropertyOffset_4;

		// Token: 0x040156B5 RID: 87733
		internal static int __PropertyOffset_5;

		// Token: 0x040156B6 RID: 87734
		[Nullable(new byte[]
		{
			2,
			0,
			1,
			1
		})]
		private TMap<TEnumAsByte<EBulletHitEffect>, TSoftObjectPtr<UObject>> _命中特效DA;

		// Token: 0x040156B7 RID: 87735
		internal static int __PropertyOffset_6;

		// Token: 0x040156B8 RID: 87736
		internal static int __PropertyOffset_7;

		// Token: 0x040156B9 RID: 87737
		internal static int __PropertyOffset_8;

		// Token: 0x040156BA RID: 87738
		internal static int __PropertyOffset_9;

		// Token: 0x040156BB RID: 87739
		internal static int __PropertyOffset_10;

		// Token: 0x040156BC RID: 87740
		internal static int __PropertyOffset_11;

		// Token: 0x040156BD RID: 87741
		internal static int __PropertyOffset_12;

		// Token: 0x040156BE RID: 87742
		internal static int __PropertyOffset_13;

		// Token: 0x040156BF RID: 87743
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<SBulletEffectOnHitConf> _命中特效配置;

		// Token: 0x040156C0 RID: 87744
		internal static int __PropertyOffset_14;
	}
}
