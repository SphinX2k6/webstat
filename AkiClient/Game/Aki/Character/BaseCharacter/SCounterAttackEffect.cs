using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x02004252 RID: 16978
	[NullableContext(1)]
	[Nullable(0)]
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/SCounterAttackEffect.SCounterAttackEffect")]
	[UnrealStructLayout(528, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 524)]
	public class SCounterAttackEffect : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602CF84 RID: 184196 RVA: 0x00AB46D5 File Offset: 0x00AB28D5
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SCounterAttackEffect._ScriptStructPtr != 0) ? SCounterAttackEffect._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/BaseCharacter/SCounterAttackEffect.SCounterAttackEffect", ref SCounterAttackEffect._ScriptStructPtr);
		}

		// Token: 0x170079F0 RID: 31216
		// (get) Token: 0x0602CF85 RID: 184197 RVA: 0x00AB46F9 File Offset: 0x00AB28F9
		// (set) Token: 0x0602CF86 RID: 184198 RVA: 0x00AB470D File Offset: 0x00AB290D
		[Nullable(new byte[]
		{
			0,
			1
		})]
		public unsafe TSubclassOf<UCameraShakeBase> 震屏
		{
			[return: Nullable(new byte[]
			{
				0,
				1
			})]
			get
			{
				return *(base.NativePtr + (IntPtr)SCounterAttackEffect.__PropertyOffset_0);
			}
			[param: Nullable(new byte[]
			{
				0,
				1
			})]
			set
			{
				*(base.NativePtr + (IntPtr)SCounterAttackEffect.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x170079F1 RID: 31217
		// (get) Token: 0x0602CF87 RID: 184199 RVA: 0x00AB4724 File Offset: 0x00AB2924
		// (set) Token: 0x0602CF88 RID: 184200 RVA: 0x00AB4767 File Offset: 0x00AB2967
		public FSoftObjectPath 特效DA
		{
			get
			{
				base.FastCheckIsValid();
				FSoftObjectPath result;
				if ((result = this._特效DA) == null)
				{
					result = (this._特效DA = new FSoftObjectPath(base.NativePtr + (IntPtr)SCounterAttackEffect.__PropertyOffset_1, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FSoftObjectPath.StaticStruct(), base.NativePtr + (IntPtr)SCounterAttackEffect.__PropertyOffset_1, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170079F2 RID: 31218
		// (get) Token: 0x0602CF89 RID: 184201 RVA: 0x00AB4788 File Offset: 0x00AB2988
		// (set) Token: 0x0602CF8A RID: 184202 RVA: 0x00AB47CB File Offset: 0x00AB29CB
		public STimeScale 攻击者顿帧
		{
			get
			{
				base.FastCheckIsValid();
				STimeScale result;
				if ((result = this._攻击者顿帧) == null)
				{
					result = (this._攻击者顿帧 = new STimeScale(base.NativePtr + (IntPtr)SCounterAttackEffect.__PropertyOffset_2, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(STimeScale.StaticStruct(), base.NativePtr + (IntPtr)SCounterAttackEffect.__PropertyOffset_2, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170079F3 RID: 31219
		// (get) Token: 0x0602CF8B RID: 184203 RVA: 0x00AB47EC File Offset: 0x00AB29EC
		// (set) Token: 0x0602CF8C RID: 184204 RVA: 0x00AB482F File Offset: 0x00AB2A2F
		public STimeScale 被击者顿帧
		{
			get
			{
				base.FastCheckIsValid();
				STimeScale result;
				if ((result = this._被击者顿帧) == null)
				{
					result = (this._被击者顿帧 = new STimeScale(base.NativePtr + (IntPtr)SCounterAttackEffect.__PropertyOffset_3, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(STimeScale.StaticStruct(), base.NativePtr + (IntPtr)SCounterAttackEffect.__PropertyOffset_3, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170079F4 RID: 31220
		// (get) Token: 0x0602CF8D RID: 184205 RVA: 0x00AB4850 File Offset: 0x00AB2A50
		// (set) Token: 0x0602CF8E RID: 184206 RVA: 0x00AB4893 File Offset: 0x00AB2A93
		public SCounterAttackCamera 摄像机设置
		{
			get
			{
				base.FastCheckIsValid();
				SCounterAttackCamera result;
				if ((result = this._摄像机设置) == null)
				{
					result = (this._摄像机设置 = new SCounterAttackCamera(base.NativePtr + (IntPtr)SCounterAttackEffect.__PropertyOffset_4, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SCounterAttackCamera.StaticStruct(), base.NativePtr + (IntPtr)SCounterAttackEffect.__PropertyOffset_4, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170079F5 RID: 31221
		// (get) Token: 0x0602CF8F RID: 184207 RVA: 0x00AB48B4 File Offset: 0x00AB2AB4
		// (set) Token: 0x0602CF90 RID: 184208 RVA: 0x00AB48C8 File Offset: 0x00AB2AC8
		public unsafe FVector 特效Offset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCounterAttackEffect.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCounterAttackEffect.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x170079F6 RID: 31222
		// (get) Token: 0x0602CF91 RID: 184209 RVA: 0x00AB48DD File Offset: 0x00AB2ADD
		// (set) Token: 0x0602CF92 RID: 184210 RVA: 0x00AB48F1 File Offset: 0x00AB2AF1
		public unsafe FVector 特效Scale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCounterAttackEffect.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCounterAttackEffect.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x170079F7 RID: 31223
		// (get) Token: 0x0602CF93 RID: 184211 RVA: 0x00AB4906 File Offset: 0x00AB2B06
		// (set) Token: 0x0602CF94 RID: 184212 RVA: 0x00AB4916 File Offset: 0x00AB2B16
		public unsafe float 特效位置
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCounterAttackEffect.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCounterAttackEffect.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x0602CF95 RID: 184213 RVA: 0x00AB4927 File Offset: 0x00AB2B27
		public SCounterAttackEffect()
		{
		}

		// Token: 0x0602CF96 RID: 184214 RVA: 0x00AB4930 File Offset: 0x00AB2B30
		public SCounterAttackEffect([Nullable(new byte[]
		{
			0,
			1
		})] TSubclassOf<UCameraShakeBase> 震屏, FSoftObjectPath 特效DA, STimeScale 攻击者顿帧, STimeScale 被击者顿帧, SCounterAttackCamera 摄像机设置, FVector 特效Offset, FVector 特效Scale, float 特效位置)
		{
			this.震屏 = 震屏;
			this.特效DA = 特效DA;
			this.攻击者顿帧 = 攻击者顿帧;
			this.被击者顿帧 = 被击者顿帧;
			this.摄像机设置 = 摄像机设置;
			this.特效Offset = 特效Offset;
			this.特效Scale = 特效Scale;
			this.特效位置 = 特效位置;
		}

		// Token: 0x0602CF97 RID: 184215 RVA: 0x00AB4980 File Offset: 0x00AB2B80
		protected override IntPtr GetUStructPtr()
		{
			return SCounterAttackEffect.StaticStruct();
		}

		// Token: 0x0602CF98 RID: 184216 RVA: 0x00AB498C File Offset: 0x00AB2B8C
		[NullableContext(2)]
		public SCounterAttackEffect(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602CF99 RID: 184217 RVA: 0x00AB4996 File Offset: 0x00AB2B96
		public SCounterAttackEffect(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602CF9A RID: 184218 RVA: 0x00AB49A1 File Offset: 0x00AB2BA1
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SCounterAttackEffect(Pointer, false, true);
		}

		// Token: 0x0602CF9B RID: 184219 RVA: 0x00AB49AB File Offset: 0x00AB2BAB
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SCounterAttackEffect(Pointer, MemoryOwner);
		}

		// Token: 0x0401939D RID: 103325
		public const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/SCounterAttackEffect.SCounterAttackEffect";

		// Token: 0x0401939E RID: 103326
		private static IntPtr _ScriptStructPtr;

		// Token: 0x0401939F RID: 103327
		internal static int __PropertyOffset_0;

		// Token: 0x040193A0 RID: 103328
		internal static int __PropertyOffset_1;

		// Token: 0x040193A1 RID: 103329
		[Nullable(2)]
		private FSoftObjectPath _特效DA;

		// Token: 0x040193A2 RID: 103330
		internal static int __PropertyOffset_2;

		// Token: 0x040193A3 RID: 103331
		[Nullable(2)]
		private STimeScale _攻击者顿帧;

		// Token: 0x040193A4 RID: 103332
		internal static int __PropertyOffset_3;

		// Token: 0x040193A5 RID: 103333
		[Nullable(2)]
		private STimeScale _被击者顿帧;

		// Token: 0x040193A6 RID: 103334
		internal static int __PropertyOffset_4;

		// Token: 0x040193A7 RID: 103335
		[Nullable(2)]
		private SCounterAttackCamera _摄像机设置;

		// Token: 0x040193A8 RID: 103336
		internal static int __PropertyOffset_5;

		// Token: 0x040193A9 RID: 103337
		internal static int __PropertyOffset_6;

		// Token: 0x040193AA RID: 103338
		internal static int __PropertyOffset_7;
	}
}
