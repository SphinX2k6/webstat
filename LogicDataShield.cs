using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Core.Fight;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02002DF2 RID: 11762
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/NewWorld/Bullet/LogicDataClass/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/NewWorld/Bullet/LogicDataClass/LogicDataShield.LogicDataShield_C")]
public class LogicDataShield : LogicDataBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17001FF1 RID: 8177
	// (get) Token: 0x06017BD2 RID: 97234 RVA: 0x0069F714 File Offset: 0x0069D914
	// (set) Token: 0x06017BD3 RID: 97235 RVA: 0x0069F724 File Offset: 0x0069D924
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool DefenseCanDodgeBullet
	{
		get
		{
			return *(base.NativePtr + (IntPtr)LogicDataShield.__PropertyOffset_DefenseCanDodgeBullet) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)LogicDataShield.__PropertyOffset_DefenseCanDodgeBullet) = (value ? 1 : 0);
		}
	}

	// Token: 0x17001FF2 RID: 8178
	// (get) Token: 0x06017BD4 RID: 97236 RVA: 0x0069F735 File Offset: 0x0069D935
	// (set) Token: 0x06017BD5 RID: 97237 RVA: 0x0069F745 File Offset: 0x0069D945
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool DefenseCaughtTrigger
	{
		get
		{
			return *(base.NativePtr + (IntPtr)LogicDataShield.__PropertyOffset_DefenseCaughtTrigger) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)LogicDataShield.__PropertyOffset_DefenseCaughtTrigger) = (value ? 1 : 0);
		}
	}

	// Token: 0x17001FF3 RID: 8179
	// (get) Token: 0x06017BD6 RID: 97238 RVA: 0x0069F758 File Offset: 0x0069D958
	// (set) Token: 0x06017BD7 RID: 97239 RVA: 0x0069F791 File Offset: 0x0069D991
	[UProperty(EPropertyFlags.CPF_None)]
	public TArray<string> DefenseBulletIdList
	{
		get
		{
			base.FastCheckIsValid();
			TArray<string> result;
			if ((result = this._DefenseBulletIdList) == null)
			{
				result = (this._DefenseBulletIdList = new TArray<string>(base.NativePtr + (IntPtr)LogicDataShield.__PropertyOffset_DefenseBulletIdList, this));
			}
			return result;
		}
		set
		{
			this.DefenseBulletIdList.CopyAssign(value);
		}
	}

	// Token: 0x17001FF4 RID: 8180
	// (get) Token: 0x06017BD8 RID: 97240 RVA: 0x0069F7A0 File Offset: 0x0069D9A0
	// (set) Token: 0x06017BD9 RID: 97241 RVA: 0x0069F7D9 File Offset: 0x0069D9D9
	[UProperty(EPropertyFlags.CPF_None)]
	public TArray<string> NotDefenseBulletIdList
	{
		get
		{
			base.FastCheckIsValid();
			TArray<string> result;
			if ((result = this._NotDefenseBulletIdList) == null)
			{
				result = (this._NotDefenseBulletIdList = new TArray<string>(base.NativePtr + (IntPtr)LogicDataShield.__PropertyOffset_NotDefenseBulletIdList, this));
			}
			return result;
		}
		set
		{
			this.NotDefenseBulletIdList.CopyAssign(value);
		}
	}

	// Token: 0x17001FF5 RID: 8181
	// (get) Token: 0x06017BDA RID: 97242 RVA: 0x0069F7E7 File Offset: 0x0069D9E7
	// (set) Token: 0x06017BDB RID: 97243 RVA: 0x0069F7F7 File Offset: 0x0069D9F7
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe ECampType SelfCampType
	{
		get
		{
			return (ECampType)(*(base.NativePtr + (IntPtr)LogicDataShield.__PropertyOffset_SelfCampType));
		}
		set
		{
			*(base.NativePtr + (IntPtr)LogicDataShield.__PropertyOffset_SelfCampType) = (byte)value;
		}
	}

	// Token: 0x17001FF6 RID: 8182
	// (get) Token: 0x06017BDC RID: 97244 RVA: 0x0069F808 File Offset: 0x0069DA08
	// (set) Token: 0x06017BDD RID: 97245 RVA: 0x0069F818 File Offset: 0x0069DA18
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe ECampType FriendCampType
	{
		get
		{
			return (ECampType)(*(base.NativePtr + (IntPtr)LogicDataShield.__PropertyOffset_FriendCampType));
		}
		set
		{
			*(base.NativePtr + (IntPtr)LogicDataShield.__PropertyOffset_FriendCampType) = (byte)value;
		}
	}

	// Token: 0x17001FF7 RID: 8183
	// (get) Token: 0x06017BDE RID: 97246 RVA: 0x0069F829 File Offset: 0x0069DA29
	// (set) Token: 0x06017BDF RID: 97247 RVA: 0x0069F839 File Offset: 0x0069DA39
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe ECampType EnemyCampType
	{
		get
		{
			return (ECampType)(*(base.NativePtr + (IntPtr)LogicDataShield.__PropertyOffset_EnemyCampType));
		}
		set
		{
			*(base.NativePtr + (IntPtr)LogicDataShield.__PropertyOffset_EnemyCampType) = (byte)value;
		}
	}

	// Token: 0x17001FF8 RID: 8184
	// (get) Token: 0x06017BE0 RID: 97248 RVA: 0x0069F84A File Offset: 0x0069DA4A
	// (set) Token: 0x06017BE1 RID: 97249 RVA: 0x0069F85A File Offset: 0x0069DA5A
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int DefenseAngle
	{
		get
		{
			return *(base.NativePtr + (IntPtr)LogicDataShield.__PropertyOffset_DefenseAngle);
		}
		set
		{
			*(base.NativePtr + (IntPtr)LogicDataShield.__PropertyOffset_DefenseAngle) = value;
		}
	}

	// Token: 0x17001FF9 RID: 8185
	// (get) Token: 0x06017BE2 RID: 97250 RVA: 0x0069F86C File Offset: 0x0069DA6C
	// (set) Token: 0x06017BE3 RID: 97251 RVA: 0x0069F8A5 File Offset: 0x0069DAA5
	[UProperty(EPropertyFlags.CPF_None)]
	public TArray<long> AddBuffToSelf
	{
		get
		{
			base.FastCheckIsValid();
			TArray<long> result;
			if ((result = this._AddBuffToSelf) == null)
			{
				result = (this._AddBuffToSelf = new TArray<long>(base.NativePtr + (IntPtr)LogicDataShield.__PropertyOffset_AddBuffToSelf, this));
			}
			return result;
		}
		set
		{
			this.AddBuffToSelf.CopyAssign(value);
		}
	}

	// Token: 0x17001FFA RID: 8186
	// (get) Token: 0x06017BE4 RID: 97252 RVA: 0x0069F8B4 File Offset: 0x0069DAB4
	// (set) Token: 0x06017BE5 RID: 97253 RVA: 0x0069F8ED File Offset: 0x0069DAED
	[UProperty(EPropertyFlags.CPF_None)]
	public TArray<long> AddBuffToEnemy
	{
		get
		{
			base.FastCheckIsValid();
			TArray<long> result;
			if ((result = this._AddBuffToEnemy) == null)
			{
				result = (this._AddBuffToEnemy = new TArray<long>(base.NativePtr + (IntPtr)LogicDataShield.__PropertyOffset_AddBuffToEnemy, this));
			}
			return result;
		}
		set
		{
			this.AddBuffToEnemy.CopyAssign(value);
		}
	}

	// Token: 0x17001FFB RID: 8187
	// (get) Token: 0x06017BE6 RID: 97254 RVA: 0x0069F8FB File Offset: 0x0069DAFB
	// (set) Token: 0x06017BE7 RID: 97255 RVA: 0x0069F90B File Offset: 0x0069DB0B
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int DecreaseBulletHitCount
	{
		get
		{
			return *(base.NativePtr + (IntPtr)LogicDataShield.__PropertyOffset_DecreaseBulletHitCount);
		}
		set
		{
			*(base.NativePtr + (IntPtr)LogicDataShield.__PropertyOffset_DecreaseBulletHitCount) = value;
		}
	}

	// Token: 0x17001FFC RID: 8188
	// (get) Token: 0x06017BE8 RID: 97256 RVA: 0x0069F91C File Offset: 0x0069DB1C
	// (set) Token: 0x06017BE9 RID: 97257 RVA: 0x0069F955 File Offset: 0x0069DB55
	[UProperty(EPropertyFlags.CPF_None)]
	public TArray<int> SelfCalcTypeArray
	{
		get
		{
			base.FastCheckIsValid();
			TArray<int> result;
			if ((result = this._SelfCalcTypeArray) == null)
			{
				result = (this._SelfCalcTypeArray = new TArray<int>(base.NativePtr + (IntPtr)LogicDataShield.__PropertyOffset_SelfCalcTypeArray, this));
			}
			return result;
		}
		set
		{
			this.SelfCalcTypeArray.CopyAssign(value);
		}
	}

	// Token: 0x17001FFD RID: 8189
	// (get) Token: 0x06017BEA RID: 97258 RVA: 0x0069F964 File Offset: 0x0069DB64
	// (set) Token: 0x06017BEB RID: 97259 RVA: 0x0069F99D File Offset: 0x0069DB9D
	[UProperty(EPropertyFlags.CPF_None)]
	public TArray<int> FriendCalcTypeArray
	{
		get
		{
			base.FastCheckIsValid();
			TArray<int> result;
			if ((result = this._FriendCalcTypeArray) == null)
			{
				result = (this._FriendCalcTypeArray = new TArray<int>(base.NativePtr + (IntPtr)LogicDataShield.__PropertyOffset_FriendCalcTypeArray, this));
			}
			return result;
		}
		set
		{
			this.FriendCalcTypeArray.CopyAssign(value);
		}
	}

	// Token: 0x17001FFE RID: 8190
	// (get) Token: 0x06017BEC RID: 97260 RVA: 0x0069F9AC File Offset: 0x0069DBAC
	// (set) Token: 0x06017BED RID: 97261 RVA: 0x0069F9E5 File Offset: 0x0069DBE5
	[UProperty(EPropertyFlags.CPF_None)]
	public TArray<int> EnemyCalcTypeArray
	{
		get
		{
			base.FastCheckIsValid();
			TArray<int> result;
			if ((result = this._EnemyCalcTypeArray) == null)
			{
				result = (this._EnemyCalcTypeArray = new TArray<int>(base.NativePtr + (IntPtr)LogicDataShield.__PropertyOffset_EnemyCalcTypeArray, this));
			}
			return result;
		}
		set
		{
			this.EnemyCalcTypeArray.CopyAssign(value);
		}
	}

	// Token: 0x06017BEE RID: 97262 RVA: 0x0069F9F3 File Offset: 0x0069DBF3
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (LogicDataShield._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/NewWorld/Bullet/LogicDataClass/LogicDataShield.LogicDataShield_C");
		}
		return LogicDataShield._ClassPtr;
	}

	// Token: 0x06017BEF RID: 97263 RVA: 0x0069FA18 File Offset: 0x0069DC18
	public LogicDataShield() : this(BuiltinUtils.AllocNativeUObject(LogicDataShield.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06017BF0 RID: 97264 RVA: 0x0069FA40 File Offset: 0x0069DC40
	public LogicDataShield(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(LogicDataShield.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06017BF1 RID: 97265 RVA: 0x0069FA73 File Offset: 0x0069DC73
	protected LogicDataShield(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0400B744 RID: 46916
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/NewWorld/Bullet/LogicDataClass/LogicDataShield.LogicDataShield_C";

	// Token: 0x0400B745 RID: 46917
	private static IntPtr _ClassPtr;

	// Token: 0x0400B746 RID: 46918
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400B747 RID: 46919
	private static int __PropertyOffset_DefenseCanDodgeBullet;

	// Token: 0x0400B748 RID: 46920
	private static int __PropertyOffset_DefenseCaughtTrigger;

	// Token: 0x0400B749 RID: 46921
	private static int __PropertyOffset_DefenseBulletIdList;

	// Token: 0x0400B74A RID: 46922
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TArray<string> _DefenseBulletIdList;

	// Token: 0x0400B74B RID: 46923
	private static int __PropertyOffset_NotDefenseBulletIdList;

	// Token: 0x0400B74C RID: 46924
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TArray<string> _NotDefenseBulletIdList;

	// Token: 0x0400B74D RID: 46925
	private static int __PropertyOffset_SelfCampType;

	// Token: 0x0400B74E RID: 46926
	private static int __PropertyOffset_FriendCampType;

	// Token: 0x0400B74F RID: 46927
	private static int __PropertyOffset_EnemyCampType;

	// Token: 0x0400B750 RID: 46928
	private static int __PropertyOffset_DefenseAngle;

	// Token: 0x0400B751 RID: 46929
	private static int __PropertyOffset_AddBuffToSelf;

	// Token: 0x0400B752 RID: 46930
	[Nullable(2)]
	private TArray<long> _AddBuffToSelf;

	// Token: 0x0400B753 RID: 46931
	private static int __PropertyOffset_AddBuffToEnemy;

	// Token: 0x0400B754 RID: 46932
	[Nullable(2)]
	private TArray<long> _AddBuffToEnemy;

	// Token: 0x0400B755 RID: 46933
	private static int __PropertyOffset_DecreaseBulletHitCount;

	// Token: 0x0400B756 RID: 46934
	private static int __PropertyOffset_SelfCalcTypeArray;

	// Token: 0x0400B757 RID: 46935
	[Nullable(2)]
	private TArray<int> _SelfCalcTypeArray;

	// Token: 0x0400B758 RID: 46936
	private static int __PropertyOffset_FriendCalcTypeArray;

	// Token: 0x0400B759 RID: 46937
	[Nullable(2)]
	private TArray<int> _FriendCalcTypeArray;

	// Token: 0x0400B75A RID: 46938
	private static int __PropertyOffset_EnemyCalcTypeArray;

	// Token: 0x0400B75B RID: 46939
	[Nullable(2)]
	private TArray<int> _EnemyCalcTypeArray;
}
