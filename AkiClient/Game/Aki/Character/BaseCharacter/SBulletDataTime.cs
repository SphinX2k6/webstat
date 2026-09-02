using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x02004246 RID: 16966
	[NullableContext(1)]
	[Nullable(0)]
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/SBulletDataTime.SBulletDataTime")]
	[UnrealStructLayout(56, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 56)]
	public class SBulletDataTime : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602CE9F RID: 183967 RVA: 0x00AB30C4 File Offset: 0x00AB12C4
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SBulletDataTime._ScriptStructPtr != 0) ? SBulletDataTime._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/BaseCharacter/SBulletDataTime.SBulletDataTime", ref SBulletDataTime._ScriptStructPtr);
		}

		// Token: 0x170079AC RID: 31148
		// (get) Token: 0x0602CEA0 RID: 183968 RVA: 0x00AB30E8 File Offset: 0x00AB12E8
		// (set) Token: 0x0602CEA1 RID: 183969 RVA: 0x00AB30F8 File Offset: 0x00AB12F8
		public unsafe bool 是否受顿帧影响
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SBulletDataTime.__PropertyOffset_0) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SBulletDataTime.__PropertyOffset_0) = (value ? 1 : 0);
			}
		}

		// Token: 0x170079AD RID: 31149
		// (get) Token: 0x0602CEA2 RID: 183970 RVA: 0x00AB310C File Offset: 0x00AB130C
		// (set) Token: 0x0602CEA3 RID: 183971 RVA: 0x00AB314F File Offset: 0x00AB134F
		public STimeScale 攻击顿帧
		{
			get
			{
				base.FastCheckIsValid();
				STimeScale result;
				if ((result = this._攻击顿帧) == null)
				{
					result = (this._攻击顿帧 = new STimeScale(base.NativePtr + (IntPtr)SBulletDataTime.__PropertyOffset_1, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(STimeScale.StaticStruct(), base.NativePtr + (IntPtr)SBulletDataTime.__PropertyOffset_1, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170079AE RID: 31150
		// (get) Token: 0x0602CEA4 RID: 183972 RVA: 0x00AB3170 File Offset: 0x00AB1370
		// (set) Token: 0x0602CEA5 RID: 183973 RVA: 0x00AB31B3 File Offset: 0x00AB13B3
		public STimeScale 受击顿帧
		{
			get
			{
				base.FastCheckIsValid();
				STimeScale result;
				if ((result = this._受击顿帧) == null)
				{
					result = (this._受击顿帧 = new STimeScale(base.NativePtr + (IntPtr)SBulletDataTime.__PropertyOffset_2, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(STimeScale.StaticStruct(), base.NativePtr + (IntPtr)SBulletDataTime.__PropertyOffset_2, value.NativePtr, 1, false);
			}
		}

		// Token: 0x0602CEA6 RID: 183974 RVA: 0x00AB31D4 File Offset: 0x00AB13D4
		public SBulletDataTime()
		{
		}

		// Token: 0x0602CEA7 RID: 183975 RVA: 0x00AB31DC File Offset: 0x00AB13DC
		public SBulletDataTime(bool 是否受顿帧影响, STimeScale 攻击顿帧, STimeScale 受击顿帧)
		{
			this.是否受顿帧影响 = 是否受顿帧影响;
			this.攻击顿帧 = 攻击顿帧;
			this.受击顿帧 = 受击顿帧;
		}

		// Token: 0x0602CEA8 RID: 183976 RVA: 0x00AB31F9 File Offset: 0x00AB13F9
		protected override IntPtr GetUStructPtr()
		{
			return SBulletDataTime.StaticStruct();
		}

		// Token: 0x0602CEA9 RID: 183977 RVA: 0x00AB3205 File Offset: 0x00AB1405
		[NullableContext(2)]
		public SBulletDataTime(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602CEAA RID: 183978 RVA: 0x00AB320F File Offset: 0x00AB140F
		public SBulletDataTime(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602CEAB RID: 183979 RVA: 0x00AB321A File Offset: 0x00AB141A
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SBulletDataTime(Pointer, false, true);
		}

		// Token: 0x0602CEAC RID: 183980 RVA: 0x00AB3224 File Offset: 0x00AB1424
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SBulletDataTime(Pointer, MemoryOwner);
		}

		// Token: 0x04019325 RID: 103205
		public const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/SBulletDataTime.SBulletDataTime";

		// Token: 0x04019326 RID: 103206
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04019327 RID: 103207
		internal static int __PropertyOffset_0;

		// Token: 0x04019328 RID: 103208
		internal static int __PropertyOffset_1;

		// Token: 0x04019329 RID: 103209
		[Nullable(2)]
		private STimeScale _攻击顿帧;

		// Token: 0x0401932A RID: 103210
		internal static int __PropertyOffset_2;

		// Token: 0x0401932B RID: 103211
		[Nullable(2)]
		private STimeScale _受击顿帧;
	}
}
