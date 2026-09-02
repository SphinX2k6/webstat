using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x02004249 RID: 16969
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/SCaughtBindingInfo.SCaughtBindingInfo")]
	[UnrealStructLayout(192, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 192)]
	public class SCaughtBindingInfo : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602CEC5 RID: 184005 RVA: 0x00AB340E File Offset: 0x00AB160E
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SCaughtBindingInfo._ScriptStructPtr != 0) ? SCaughtBindingInfo._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/BaseCharacter/SCaughtBindingInfo.SCaughtBindingInfo", ref SCaughtBindingInfo._ScriptStructPtr);
		}

		// Token: 0x170079B3 RID: 31155
		// (get) Token: 0x0602CEC6 RID: 184006 RVA: 0x00AB3432 File Offset: 0x00AB1632
		// (set) Token: 0x0602CEC7 RID: 184007 RVA: 0x00AB3446 File Offset: 0x00AB1646
		public unsafe string BulletId
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SCaughtBindingInfo.__PropertyOffset_0)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SCaughtBindingInfo.__PropertyOffset_0)), value);
			}
		}

		// Token: 0x170079B4 RID: 31156
		// (get) Token: 0x0602CEC8 RID: 184008 RVA: 0x00AB345B File Offset: 0x00AB165B
		// (set) Token: 0x0602CEC9 RID: 184009 RVA: 0x00AB346B File Offset: 0x00AB166B
		public unsafe bool DestroyBullet
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCaughtBindingInfo.__PropertyOffset_1) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCaughtBindingInfo.__PropertyOffset_1) = (value ? 1 : 0);
			}
		}

		// Token: 0x170079B5 RID: 31157
		// (get) Token: 0x0602CECA RID: 184010 RVA: 0x00AB347C File Offset: 0x00AB167C
		// (set) Token: 0x0602CECB RID: 184011 RVA: 0x00AB348C File Offset: 0x00AB168C
		public unsafe bool SummonChildBullet
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCaughtBindingInfo.__PropertyOffset_2) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCaughtBindingInfo.__PropertyOffset_2) = (value ? 1 : 0);
			}
		}

		// Token: 0x170079B6 RID: 31158
		// (get) Token: 0x0602CECC RID: 184012 RVA: 0x00AB349D File Offset: 0x00AB169D
		// (set) Token: 0x0602CECD RID: 184013 RVA: 0x00AB34B1 File Offset: 0x00AB16B1
		public unsafe string EndBulletId
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SCaughtBindingInfo.__PropertyOffset_3)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SCaughtBindingInfo.__PropertyOffset_3)), value);
			}
		}

		// Token: 0x170079B7 RID: 31159
		// (get) Token: 0x0602CECE RID: 184014 RVA: 0x00AB34C6 File Offset: 0x00AB16C6
		// (set) Token: 0x0602CECF RID: 184015 RVA: 0x00AB34DA File Offset: 0x00AB16DA
		public unsafe string TargetMontagePath
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SCaughtBindingInfo.__PropertyOffset_4)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SCaughtBindingInfo.__PropertyOffset_4)), value);
			}
		}

		// Token: 0x170079B8 RID: 31160
		// (get) Token: 0x0602CED0 RID: 184016 RVA: 0x00AB34EF File Offset: 0x00AB16EF
		// (set) Token: 0x0602CED1 RID: 184017 RVA: 0x00AB3503 File Offset: 0x00AB1703
		public unsafe string TargetBoneName
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SCaughtBindingInfo.__PropertyOffset_5)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SCaughtBindingInfo.__PropertyOffset_5)), value);
			}
		}

		// Token: 0x170079B9 RID: 31161
		// (get) Token: 0x0602CED2 RID: 184018 RVA: 0x00AB3518 File Offset: 0x00AB1718
		// (set) Token: 0x0602CED3 RID: 184019 RVA: 0x00AB352C File Offset: 0x00AB172C
		[Nullable(0)]
		public unsafe TEnumAsByte<ECaughtDirectionType> CaughtDirectionType
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)SCaughtBindingInfo.__PropertyOffset_6);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)SCaughtBindingInfo.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x170079BA RID: 31162
		// (get) Token: 0x0602CED4 RID: 184020 RVA: 0x00AB3544 File Offset: 0x00AB1744
		// (set) Token: 0x0602CED5 RID: 184021 RVA: 0x00AB3587 File Offset: 0x00AB1787
		[Nullable(new byte[]
		{
			1,
			0,
			0
		})]
		public TMap<TEnumAsByte<ECollisionChannel>, TEnumAsByte<ECollisionResponse>> CollisionResponseToChannel
		{
			[return: Nullable(new byte[]
			{
				1,
				0,
				0
			})]
			get
			{
				base.FastCheckIsValid();
				TMap<TEnumAsByte<ECollisionChannel>, TEnumAsByte<ECollisionResponse>> result;
				if ((result = this._CollisionResponseToChannel) == null)
				{
					result = (this._CollisionResponseToChannel = new TMap<TEnumAsByte<ECollisionChannel>, TEnumAsByte<ECollisionResponse>>(base.NativePtr + (IntPtr)SCaughtBindingInfo.__PropertyOffset_7, base.MemoryOwner ?? this));
				}
				return result;
			}
			[param: Nullable(new byte[]
			{
				1,
				0,
				0
			})]
			set
			{
				this.CollisionResponseToChannel.CopyAssign(value);
			}
		}

		// Token: 0x170079BB RID: 31163
		// (get) Token: 0x0602CED6 RID: 184022 RVA: 0x00AB3598 File Offset: 0x00AB1798
		// (set) Token: 0x0602CED7 RID: 184023 RVA: 0x00AB35DB File Offset: 0x00AB17DB
		public TArray<long> SourceBuffIds
		{
			get
			{
				base.FastCheckIsValid();
				TArray<long> result;
				if ((result = this._SourceBuffIds) == null)
				{
					result = (this._SourceBuffIds = new TArray<long>(base.NativePtr + (IntPtr)SCaughtBindingInfo.__PropertyOffset_8, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.SourceBuffIds.CopyAssign(value);
			}
		}

		// Token: 0x170079BC RID: 31164
		// (get) Token: 0x0602CED8 RID: 184024 RVA: 0x00AB35EC File Offset: 0x00AB17EC
		// (set) Token: 0x0602CED9 RID: 184025 RVA: 0x00AB362F File Offset: 0x00AB182F
		public TArray<long> TargetBuffIds
		{
			get
			{
				base.FastCheckIsValid();
				TArray<long> result;
				if ((result = this._TargetBuffIds) == null)
				{
					result = (this._TargetBuffIds = new TArray<long>(base.NativePtr + (IntPtr)SCaughtBindingInfo.__PropertyOffset_9, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.TargetBuffIds.CopyAssign(value);
			}
		}

		// Token: 0x0602CEDA RID: 184026 RVA: 0x00AB363D File Offset: 0x00AB183D
		public SCaughtBindingInfo()
		{
		}

		// Token: 0x0602CEDB RID: 184027 RVA: 0x00AB3648 File Offset: 0x00AB1848
		public SCaughtBindingInfo(string BulletId, bool DestroyBullet, bool SummonChildBullet, string EndBulletId, string TargetMontagePath, string TargetBoneName, [Nullable(0)] TEnumAsByte<ECaughtDirectionType> CaughtDirectionType, [Nullable(new byte[]
		{
			1,
			0,
			0
		})] TMap<TEnumAsByte<ECollisionChannel>, TEnumAsByte<ECollisionResponse>> CollisionResponseToChannel, TArray<long> SourceBuffIds, TArray<long> TargetBuffIds)
		{
			this.BulletId = BulletId;
			this.DestroyBullet = DestroyBullet;
			this.SummonChildBullet = SummonChildBullet;
			this.EndBulletId = EndBulletId;
			this.TargetMontagePath = TargetMontagePath;
			this.TargetBoneName = TargetBoneName;
			this.CaughtDirectionType = CaughtDirectionType;
			this.CollisionResponseToChannel = CollisionResponseToChannel;
			this.SourceBuffIds = SourceBuffIds;
			this.TargetBuffIds = TargetBuffIds;
		}

		// Token: 0x0602CEDC RID: 184028 RVA: 0x00AB36A8 File Offset: 0x00AB18A8
		protected override IntPtr GetUStructPtr()
		{
			return SCaughtBindingInfo.StaticStruct();
		}

		// Token: 0x0602CEDD RID: 184029 RVA: 0x00AB36B4 File Offset: 0x00AB18B4
		[NullableContext(2)]
		public SCaughtBindingInfo(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602CEDE RID: 184030 RVA: 0x00AB36BE File Offset: 0x00AB18BE
		public SCaughtBindingInfo(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602CEDF RID: 184031 RVA: 0x00AB36C9 File Offset: 0x00AB18C9
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SCaughtBindingInfo(Pointer, false, true);
		}

		// Token: 0x0602CEE0 RID: 184032 RVA: 0x00AB36D3 File Offset: 0x00AB18D3
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SCaughtBindingInfo(Pointer, MemoryOwner);
		}

		// Token: 0x04019335 RID: 103221
		public const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/SCaughtBindingInfo.SCaughtBindingInfo";

		// Token: 0x04019336 RID: 103222
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04019337 RID: 103223
		internal static int __PropertyOffset_0;

		// Token: 0x04019338 RID: 103224
		internal static int __PropertyOffset_1;

		// Token: 0x04019339 RID: 103225
		internal static int __PropertyOffset_2;

		// Token: 0x0401933A RID: 103226
		internal static int __PropertyOffset_3;

		// Token: 0x0401933B RID: 103227
		internal static int __PropertyOffset_4;

		// Token: 0x0401933C RID: 103228
		internal static int __PropertyOffset_5;

		// Token: 0x0401933D RID: 103229
		internal static int __PropertyOffset_6;

		// Token: 0x0401933E RID: 103230
		internal static int __PropertyOffset_7;

		// Token: 0x0401933F RID: 103231
		[Nullable(new byte[]
		{
			2,
			0,
			0
		})]
		private TMap<TEnumAsByte<ECollisionChannel>, TEnumAsByte<ECollisionResponse>> _CollisionResponseToChannel;

		// Token: 0x04019340 RID: 103232
		internal static int __PropertyOffset_8;

		// Token: 0x04019341 RID: 103233
		[Nullable(2)]
		private TArray<long> _SourceBuffIds;

		// Token: 0x04019342 RID: 103234
		internal static int __PropertyOffset_9;

		// Token: 0x04019343 RID: 103235
		[Nullable(2)]
		private TArray<long> _TargetBuffIds;
	}
}
