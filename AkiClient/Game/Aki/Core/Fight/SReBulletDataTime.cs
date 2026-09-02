using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Core.Fight
{
	// Token: 0x02003F79 RID: 16249
	[NullableContext(1)]
	[Nullable(0)]
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Core/Fight/SReBulletDataTime.SReBulletDataTime")]
	[UnrealStructLayout(136, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 133)]
	public class SReBulletDataTime : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x060289F5 RID: 166389 RVA: 0x00A10924 File Offset: 0x00A0EB24
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SReBulletDataTime._ScriptStructPtr != 0) ? SReBulletDataTime._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Core/Fight/SReBulletDataTime.SReBulletDataTime", ref SReBulletDataTime._ScriptStructPtr);
		}

		// Token: 0x17006337 RID: 25399
		// (get) Token: 0x060289F6 RID: 166390 RVA: 0x00A10948 File Offset: 0x00A0EB48
		// (set) Token: 0x060289F7 RID: 166391 RVA: 0x00A10958 File Offset: 0x00A0EB58
		public unsafe bool 是否跟随攻击者顿帧
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SReBulletDataTime.__PropertyOffset_0) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SReBulletDataTime.__PropertyOffset_0) = (value ? 1 : 0);
			}
		}

		// Token: 0x17006338 RID: 25400
		// (get) Token: 0x060289F8 RID: 166392 RVA: 0x00A10969 File Offset: 0x00A0EB69
		// (set) Token: 0x060289F9 RID: 166393 RVA: 0x00A10979 File Offset: 0x00A0EB79
		public unsafe bool 攻击顿帧忽略攻击者
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SReBulletDataTime.__PropertyOffset_1) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SReBulletDataTime.__PropertyOffset_1) = (value ? 1 : 0);
			}
		}

		// Token: 0x17006339 RID: 25401
		// (get) Token: 0x060289FA RID: 166394 RVA: 0x00A1098C File Offset: 0x00A0EB8C
		// (set) Token: 0x060289FB RID: 166395 RVA: 0x00A109CF File Offset: 0x00A0EBCF
		public STimeScale 攻击顿帧
		{
			get
			{
				base.FastCheckIsValid();
				STimeScale result;
				if ((result = this._攻击顿帧) == null)
				{
					result = (this._攻击顿帧 = new STimeScale(base.NativePtr + (IntPtr)SReBulletDataTime.__PropertyOffset_2, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(STimeScale.StaticStruct(), base.NativePtr + (IntPtr)SReBulletDataTime.__PropertyOffset_2, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700633A RID: 25402
		// (get) Token: 0x060289FC RID: 166396 RVA: 0x00A109F0 File Offset: 0x00A0EBF0
		// (set) Token: 0x060289FD RID: 166397 RVA: 0x00A10A33 File Offset: 0x00A0EC33
		public STimeScale 受击顿帧
		{
			get
			{
				base.FastCheckIsValid();
				STimeScale result;
				if ((result = this._受击顿帧) == null)
				{
					result = (this._受击顿帧 = new STimeScale(base.NativePtr + (IntPtr)SReBulletDataTime.__PropertyOffset_3, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(STimeScale.StaticStruct(), base.NativePtr + (IntPtr)SReBulletDataTime.__PropertyOffset_3, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700633B RID: 25403
		// (get) Token: 0x060289FE RID: 166398 RVA: 0x00A10A54 File Offset: 0x00A0EC54
		// (set) Token: 0x060289FF RID: 166399 RVA: 0x00A10A97 File Offset: 0x00A0EC97
		public STimeScale 命中弱点攻击者顿帧
		{
			get
			{
				base.FastCheckIsValid();
				STimeScale result;
				if ((result = this._命中弱点攻击者顿帧) == null)
				{
					result = (this._命中弱点攻击者顿帧 = new STimeScale(base.NativePtr + (IntPtr)SReBulletDataTime.__PropertyOffset_4, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(STimeScale.StaticStruct(), base.NativePtr + (IntPtr)SReBulletDataTime.__PropertyOffset_4, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700633C RID: 25404
		// (get) Token: 0x06028A00 RID: 166400 RVA: 0x00A10AB8 File Offset: 0x00A0ECB8
		// (set) Token: 0x06028A01 RID: 166401 RVA: 0x00A10AFB File Offset: 0x00A0ECFB
		public STimeScale 命中弱点受击者顿帧
		{
			get
			{
				base.FastCheckIsValid();
				STimeScale result;
				if ((result = this._命中弱点受击者顿帧) == null)
				{
					result = (this._命中弱点受击者顿帧 = new STimeScale(base.NativePtr + (IntPtr)SReBulletDataTime.__PropertyOffset_5, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(STimeScale.StaticStruct(), base.NativePtr + (IntPtr)SReBulletDataTime.__PropertyOffset_5, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700633D RID: 25405
		// (get) Token: 0x06028A02 RID: 166402 RVA: 0x00A10B1C File Offset: 0x00A0ED1C
		// (set) Token: 0x06028A03 RID: 166403 RVA: 0x00A10B2C File Offset: 0x00A0ED2C
		public unsafe bool 强制影响区域内子弹
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SReBulletDataTime.__PropertyOffset_6) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SReBulletDataTime.__PropertyOffset_6) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700633E RID: 25406
		// (get) Token: 0x06028A04 RID: 166404 RVA: 0x00A10B3D File Offset: 0x00A0ED3D
		// (set) Token: 0x06028A05 RID: 166405 RVA: 0x00A10B4D File Offset: 0x00A0ED4D
		public unsafe bool 区域受击者时间膨胀
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SReBulletDataTime.__PropertyOffset_7) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SReBulletDataTime.__PropertyOffset_7) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700633F RID: 25407
		// (get) Token: 0x06028A06 RID: 166406 RVA: 0x00A10B5E File Offset: 0x00A0ED5E
		// (set) Token: 0x06028A07 RID: 166407 RVA: 0x00A10B72 File Offset: 0x00A0ED72
		public unsafe string 自定义连携顿帧单位key
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SReBulletDataTime.__PropertyOffset_8)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SReBulletDataTime.__PropertyOffset_8)), value);
			}
		}

		// Token: 0x17006340 RID: 25408
		// (get) Token: 0x06028A08 RID: 166408 RVA: 0x00A10B87 File Offset: 0x00A0ED87
		// (set) Token: 0x06028A09 RID: 166409 RVA: 0x00A10B97 File Offset: 0x00A0ED97
		public unsafe float 时间膨胀失效
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SReBulletDataTime.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SReBulletDataTime.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17006341 RID: 25409
		// (get) Token: 0x06028A0A RID: 166410 RVA: 0x00A10BA8 File Offset: 0x00A0EDA8
		// (set) Token: 0x06028A0B RID: 166411 RVA: 0x00A10BB8 File Offset: 0x00A0EDB8
		public unsafe bool 子弹销毁时移除受击顿帧
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SReBulletDataTime.__PropertyOffset_10) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SReBulletDataTime.__PropertyOffset_10) = (value ? 1 : 0);
			}
		}

		// Token: 0x06028A0C RID: 166412 RVA: 0x00A10BC9 File Offset: 0x00A0EDC9
		public SReBulletDataTime()
		{
		}

		// Token: 0x06028A0D RID: 166413 RVA: 0x00A10BD4 File Offset: 0x00A0EDD4
		public SReBulletDataTime(bool 是否跟随攻击者顿帧, bool 攻击顿帧忽略攻击者, STimeScale 攻击顿帧, STimeScale 受击顿帧, STimeScale 命中弱点攻击者顿帧, STimeScale 命中弱点受击者顿帧, bool 强制影响区域内子弹, bool 区域受击者时间膨胀, string 自定义连携顿帧单位key, float 时间膨胀失效, bool 子弹销毁时移除受击顿帧)
		{
			this.是否跟随攻击者顿帧 = 是否跟随攻击者顿帧;
			this.攻击顿帧忽略攻击者 = 攻击顿帧忽略攻击者;
			this.攻击顿帧 = 攻击顿帧;
			this.受击顿帧 = 受击顿帧;
			this.命中弱点攻击者顿帧 = 命中弱点攻击者顿帧;
			this.命中弱点受击者顿帧 = 命中弱点受击者顿帧;
			this.强制影响区域内子弹 = 强制影响区域内子弹;
			this.区域受击者时间膨胀 = 区域受击者时间膨胀;
			this.自定义连携顿帧单位key = 自定义连携顿帧单位key;
			this.时间膨胀失效 = 时间膨胀失效;
			this.子弹销毁时移除受击顿帧 = 子弹销毁时移除受击顿帧;
		}

		// Token: 0x06028A0E RID: 166414 RVA: 0x00A10C3C File Offset: 0x00A0EE3C
		protected override IntPtr GetUStructPtr()
		{
			return SReBulletDataTime.StaticStruct();
		}

		// Token: 0x06028A0F RID: 166415 RVA: 0x00A10C48 File Offset: 0x00A0EE48
		[NullableContext(2)]
		public SReBulletDataTime(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06028A10 RID: 166416 RVA: 0x00A10C52 File Offset: 0x00A0EE52
		public SReBulletDataTime(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06028A11 RID: 166417 RVA: 0x00A10C5D File Offset: 0x00A0EE5D
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SReBulletDataTime(Pointer, false, true);
		}

		// Token: 0x06028A12 RID: 166418 RVA: 0x00A10C67 File Offset: 0x00A0EE67
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SReBulletDataTime(Pointer, MemoryOwner);
		}

		// Token: 0x040156C6 RID: 87750
		public const string __ObjectPath = "/Game/Aki/Core/Fight/SReBulletDataTime.SReBulletDataTime";

		// Token: 0x040156C7 RID: 87751
		private static IntPtr _ScriptStructPtr;

		// Token: 0x040156C8 RID: 87752
		internal static int __PropertyOffset_0;

		// Token: 0x040156C9 RID: 87753
		internal static int __PropertyOffset_1;

		// Token: 0x040156CA RID: 87754
		internal static int __PropertyOffset_2;

		// Token: 0x040156CB RID: 87755
		[Nullable(2)]
		private STimeScale _攻击顿帧;

		// Token: 0x040156CC RID: 87756
		internal static int __PropertyOffset_3;

		// Token: 0x040156CD RID: 87757
		[Nullable(2)]
		private STimeScale _受击顿帧;

		// Token: 0x040156CE RID: 87758
		internal static int __PropertyOffset_4;

		// Token: 0x040156CF RID: 87759
		[Nullable(2)]
		private STimeScale _命中弱点攻击者顿帧;

		// Token: 0x040156D0 RID: 87760
		internal static int __PropertyOffset_5;

		// Token: 0x040156D1 RID: 87761
		[Nullable(2)]
		private STimeScale _命中弱点受击者顿帧;

		// Token: 0x040156D2 RID: 87762
		internal static int __PropertyOffset_6;

		// Token: 0x040156D3 RID: 87763
		internal static int __PropertyOffset_7;

		// Token: 0x040156D4 RID: 87764
		internal static int __PropertyOffset_8;

		// Token: 0x040156D5 RID: 87765
		internal static int __PropertyOffset_9;

		// Token: 0x040156D6 RID: 87766
		internal static int __PropertyOffset_10;
	}
}
