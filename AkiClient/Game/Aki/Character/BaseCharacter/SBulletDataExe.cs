using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter.Abilities.GB;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x02004242 RID: 16962
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/SBulletDataExe.SBulletDataExe")]
	[UnrealStructLayout(144, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 144)]
	public class SBulletDataExe : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602CE35 RID: 183861 RVA: 0x00AB25D2 File Offset: 0x00AB07D2
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SBulletDataExe._ScriptStructPtr != 0) ? SBulletDataExe._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/BaseCharacter/SBulletDataExe.SBulletDataExe", ref SBulletDataExe._ScriptStructPtr);
		}

		// Token: 0x17007987 RID: 31111
		// (get) Token: 0x0602CE36 RID: 183862 RVA: 0x00AB25F6 File Offset: 0x00AB07F6
		// (set) Token: 0x0602CE37 RID: 183863 RVA: 0x00AB2615 File Offset: 0x00AB0815
		public TSoftClassPtr<BP_BulletLogicBase_C> 命中执行逻辑
		{
			get
			{
				return new TSoftClassPtr<BP_BulletLogicBase_C>(base.NativePtr + (IntPtr)SBulletDataExe.__PropertyOffset_0, base.MemoryOwner ?? this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)SBulletDataExe.__PropertyOffset_0, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17007988 RID: 31112
		// (get) Token: 0x0602CE38 RID: 183864 RVA: 0x00AB263A File Offset: 0x00AB083A
		// (set) Token: 0x0602CE39 RID: 183865 RVA: 0x00AB2659 File Offset: 0x00AB0859
		public TSoftClassPtr<BP_BulletLogicBase_C> 更新执行逻辑
		{
			get
			{
				return new TSoftClassPtr<BP_BulletLogicBase_C>(base.NativePtr + (IntPtr)SBulletDataExe.__PropertyOffset_1, base.MemoryOwner ?? this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)SBulletDataExe.__PropertyOffset_1, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17007989 RID: 31113
		// (get) Token: 0x0602CE3A RID: 183866 RVA: 0x00AB2680 File Offset: 0x00AB0880
		// (set) Token: 0x0602CE3B RID: 183867 RVA: 0x00AB26C3 File Offset: 0x00AB08C3
		public TArray<SBulletGE> 命中后对攻击者应用GE类数组
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SBulletGE> result;
				if ((result = this._命中后对攻击者应用GE类数组) == null)
				{
					result = (this._命中后对攻击者应用GE类数组 = new TArray<SBulletGE>(base.NativePtr + (IntPtr)SBulletDataExe.__PropertyOffset_2, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.命中后对攻击者应用GE类数组.CopyAssign(value);
			}
		}

		// Token: 0x1700798A RID: 31114
		// (get) Token: 0x0602CE3C RID: 183868 RVA: 0x00AB26D4 File Offset: 0x00AB08D4
		// (set) Token: 0x0602CE3D RID: 183869 RVA: 0x00AB2717 File Offset: 0x00AB0917
		public TArray<SBulletGE> 命中后对受击者应用GE类数组
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SBulletGE> result;
				if ((result = this._命中后对受击者应用GE类数组) == null)
				{
					result = (this._命中后对受击者应用GE类数组 = new TArray<SBulletGE>(base.NativePtr + (IntPtr)SBulletDataExe.__PropertyOffset_3, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.命中后对受击者应用GE类数组.CopyAssign(value);
			}
		}

		// Token: 0x1700798B RID: 31115
		// (get) Token: 0x0602CE3E RID: 183870 RVA: 0x00AB2728 File Offset: 0x00AB0928
		// (set) Token: 0x0602CE3F RID: 183871 RVA: 0x00AB276B File Offset: 0x00AB096B
		public TArray<SBulletGE> 能量恢复类GE数组
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SBulletGE> result;
				if ((result = this._能量恢复类GE数组) == null)
				{
					result = (this._能量恢复类GE数组 = new TArray<SBulletGE>(base.NativePtr + (IntPtr)SBulletDataExe.__PropertyOffset_4, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.能量恢复类GE数组.CopyAssign(value);
			}
		}

		// Token: 0x0602CE40 RID: 183872 RVA: 0x00AB2779 File Offset: 0x00AB0979
		public SBulletDataExe()
		{
		}

		// Token: 0x0602CE41 RID: 183873 RVA: 0x00AB2781 File Offset: 0x00AB0981
		public SBulletDataExe(TSoftClassPtr<BP_BulletLogicBase_C> 命中执行逻辑, TSoftClassPtr<BP_BulletLogicBase_C> 更新执行逻辑, TArray<SBulletGE> 命中后对攻击者应用GE类数组, TArray<SBulletGE> 命中后对受击者应用GE类数组, TArray<SBulletGE> 能量恢复类GE数组)
		{
			this.命中执行逻辑 = 命中执行逻辑;
			this.更新执行逻辑 = 更新执行逻辑;
			this.命中后对攻击者应用GE类数组 = 命中后对攻击者应用GE类数组;
			this.命中后对受击者应用GE类数组 = 命中后对受击者应用GE类数组;
			this.能量恢复类GE数组 = 能量恢复类GE数组;
		}

		// Token: 0x0602CE42 RID: 183874 RVA: 0x00AB27AE File Offset: 0x00AB09AE
		protected override IntPtr GetUStructPtr()
		{
			return SBulletDataExe.StaticStruct();
		}

		// Token: 0x0602CE43 RID: 183875 RVA: 0x00AB27BA File Offset: 0x00AB09BA
		[NullableContext(2)]
		public SBulletDataExe(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602CE44 RID: 183876 RVA: 0x00AB27C4 File Offset: 0x00AB09C4
		public SBulletDataExe(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602CE45 RID: 183877 RVA: 0x00AB27CF File Offset: 0x00AB09CF
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SBulletDataExe(Pointer, false, true);
		}

		// Token: 0x0602CE46 RID: 183878 RVA: 0x00AB27D9 File Offset: 0x00AB09D9
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SBulletDataExe(Pointer, MemoryOwner);
		}

		// Token: 0x040192ED RID: 103149
		public const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/SBulletDataExe.SBulletDataExe";

		// Token: 0x040192EE RID: 103150
		private static IntPtr _ScriptStructPtr;

		// Token: 0x040192EF RID: 103151
		internal static int __PropertyOffset_0;

		// Token: 0x040192F0 RID: 103152
		internal static int __PropertyOffset_1;

		// Token: 0x040192F1 RID: 103153
		internal static int __PropertyOffset_2;

		// Token: 0x040192F2 RID: 103154
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<SBulletGE> _命中后对攻击者应用GE类数组;

		// Token: 0x040192F3 RID: 103155
		internal static int __PropertyOffset_3;

		// Token: 0x040192F4 RID: 103156
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<SBulletGE> _命中后对受击者应用GE类数组;

		// Token: 0x040192F5 RID: 103157
		internal static int __PropertyOffset_4;

		// Token: 0x040192F6 RID: 103158
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<SBulletGE> _能量恢复类GE数组;
	}
}
