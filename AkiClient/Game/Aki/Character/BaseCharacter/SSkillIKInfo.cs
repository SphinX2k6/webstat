using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x0200427E RID: 17022
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/SSkillIKInfo.SSkillIKInfo")]
	[UnrealStructLayout(64, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 64)]
	public class SSkillIKInfo : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602D30B RID: 185099 RVA: 0x00AB98B4 File Offset: 0x00AB7AB4
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SSkillIKInfo._ScriptStructPtr != 0) ? SSkillIKInfo._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/BaseCharacter/SSkillIKInfo.SSkillIKInfo", ref SSkillIKInfo._ScriptStructPtr);
		}

		// Token: 0x17007B07 RID: 31495
		// (get) Token: 0x0602D30C RID: 185100 RVA: 0x00AB98D8 File Offset: 0x00AB7AD8
		// (set) Token: 0x0602D30D RID: 185101 RVA: 0x00AB991B File Offset: 0x00AB7B1B
		public TArray<FName> IK曲线名
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FName> result;
				if ((result = this._IK曲线名) == null)
				{
					result = (this._IK曲线名 = new TArray<FName>(base.NativePtr + (IntPtr)SSkillIKInfo.__PropertyOffset_0, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.IK曲线名.CopyAssign(value);
			}
		}

		// Token: 0x17007B08 RID: 31496
		// (get) Token: 0x0602D30E RID: 185102 RVA: 0x00AB992C File Offset: 0x00AB7B2C
		// (set) Token: 0x0602D30F RID: 185103 RVA: 0x00AB996F File Offset: 0x00AB7B6F
		public TArray<FVector> IK点的骨骼位置
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FVector> result;
				if ((result = this._IK点的骨骼位置) == null)
				{
					result = (this._IK点的骨骼位置 = new TArray<FVector>(base.NativePtr + (IntPtr)SSkillIKInfo.__PropertyOffset_1, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.IK点的骨骼位置.CopyAssign(value);
			}
		}

		// Token: 0x17007B09 RID: 31497
		// (get) Token: 0x0602D310 RID: 185104 RVA: 0x00AB9980 File Offset: 0x00AB7B80
		// (set) Token: 0x0602D311 RID: 185105 RVA: 0x00AB99C3 File Offset: 0x00AB7BC3
		public TArray<FVector> IK点的相对位置
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FVector> result;
				if ((result = this._IK点的相对位置) == null)
				{
					result = (this._IK点的相对位置 = new TArray<FVector>(base.NativePtr + (IntPtr)SSkillIKInfo.__PropertyOffset_2, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.IK点的相对位置.CopyAssign(value);
			}
		}

		// Token: 0x17007B0A RID: 31498
		// (get) Token: 0x0602D312 RID: 185106 RVA: 0x00AB99D4 File Offset: 0x00AB7BD4
		// (set) Token: 0x0602D313 RID: 185107 RVA: 0x00AB9A17 File Offset: 0x00AB7C17
		public TArray<float> IK范围
		{
			get
			{
				base.FastCheckIsValid();
				TArray<float> result;
				if ((result = this._IK范围) == null)
				{
					result = (this._IK范围 = new TArray<float>(base.NativePtr + (IntPtr)SSkillIKInfo.__PropertyOffset_3, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.IK范围.CopyAssign(value);
			}
		}

		// Token: 0x0602D314 RID: 185108 RVA: 0x00AB9A25 File Offset: 0x00AB7C25
		public SSkillIKInfo()
		{
		}

		// Token: 0x0602D315 RID: 185109 RVA: 0x00AB9A2D File Offset: 0x00AB7C2D
		public SSkillIKInfo(TArray<FName> IK曲线名, TArray<FVector> IK点的骨骼位置, TArray<FVector> IK点的相对位置, TArray<float> IK范围)
		{
			this.IK曲线名 = IK曲线名;
			this.IK点的骨骼位置 = IK点的骨骼位置;
			this.IK点的相对位置 = IK点的相对位置;
			this.IK范围 = IK范围;
		}

		// Token: 0x0602D316 RID: 185110 RVA: 0x00AB9A52 File Offset: 0x00AB7C52
		protected override IntPtr GetUStructPtr()
		{
			return SSkillIKInfo.StaticStruct();
		}

		// Token: 0x0602D317 RID: 185111 RVA: 0x00AB9A5E File Offset: 0x00AB7C5E
		[NullableContext(2)]
		public SSkillIKInfo(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602D318 RID: 185112 RVA: 0x00AB9A68 File Offset: 0x00AB7C68
		public SSkillIKInfo(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602D319 RID: 185113 RVA: 0x00AB9A73 File Offset: 0x00AB7C73
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SSkillIKInfo(Pointer, false, true);
		}

		// Token: 0x0602D31A RID: 185114 RVA: 0x00AB9A7D File Offset: 0x00AB7C7D
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SSkillIKInfo(Pointer, MemoryOwner);
		}

		// Token: 0x04019555 RID: 103765
		public const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/SSkillIKInfo.SSkillIKInfo";

		// Token: 0x04019556 RID: 103766
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04019557 RID: 103767
		internal static int __PropertyOffset_0;

		// Token: 0x04019558 RID: 103768
		[Nullable(2)]
		private TArray<FName> _IK曲线名;

		// Token: 0x04019559 RID: 103769
		internal static int __PropertyOffset_1;

		// Token: 0x0401955A RID: 103770
		[Nullable(2)]
		private TArray<FVector> _IK点的骨骼位置;

		// Token: 0x0401955B RID: 103771
		internal static int __PropertyOffset_2;

		// Token: 0x0401955C RID: 103772
		[Nullable(2)]
		private TArray<FVector> _IK点的相对位置;

		// Token: 0x0401955D RID: 103773
		internal static int __PropertyOffset_3;

		// Token: 0x0401955E RID: 103774
		[Nullable(2)]
		private TArray<float> _IK范围;
	}
}
