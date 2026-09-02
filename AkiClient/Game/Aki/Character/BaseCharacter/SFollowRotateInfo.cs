using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x02004261 RID: 16993
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/SFollowRotateInfo.SFollowRotateInfo")]
	[UnrealStructLayout(48, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 48)]
	public class SFollowRotateInfo : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602D082 RID: 184450 RVA: 0x00AB5D18 File Offset: 0x00AB3F18
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SFollowRotateInfo._ScriptStructPtr != 0) ? SFollowRotateInfo._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/BaseCharacter/SFollowRotateInfo.SFollowRotateInfo", ref SFollowRotateInfo._ScriptStructPtr);
		}

		// Token: 0x17007A34 RID: 31284
		// (get) Token: 0x0602D083 RID: 184451 RVA: 0x00AB5D3C File Offset: 0x00AB3F3C
		// (set) Token: 0x0602D084 RID: 184452 RVA: 0x00AB5D4C File Offset: 0x00AB3F4C
		public unsafe int RotateSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SFollowRotateInfo.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SFollowRotateInfo.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17007A35 RID: 31285
		// (get) Token: 0x0602D085 RID: 184453 RVA: 0x00AB5D5D File Offset: 0x00AB3F5D
		// (set) Token: 0x0602D086 RID: 184454 RVA: 0x00AB5D71 File Offset: 0x00AB3F71
		public unsafe TEnumAsByte<EFollowRotateType> RotateType
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SFollowRotateInfo.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SFollowRotateInfo.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17007A36 RID: 31286
		// (get) Token: 0x0602D087 RID: 184455 RVA: 0x00AB5D86 File Offset: 0x00AB3F86
		// (set) Token: 0x0602D088 RID: 184456 RVA: 0x00AB5D96 File Offset: 0x00AB3F96
		public unsafe int CameraDistance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SFollowRotateInfo.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SFollowRotateInfo.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17007A37 RID: 31287
		// (get) Token: 0x0602D089 RID: 184457 RVA: 0x00AB5DA7 File Offset: 0x00AB3FA7
		// (set) Token: 0x0602D08A RID: 184458 RVA: 0x00AB5DBB File Offset: 0x00AB3FBB
		[Nullable(1)]
		public unsafe string EntityIdBlackboardKey
		{
			[NullableContext(1)]
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SFollowRotateInfo.__PropertyOffset_3)));
			}
			[NullableContext(1)]
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SFollowRotateInfo.__PropertyOffset_3)), value);
			}
		}

		// Token: 0x17007A38 RID: 31288
		// (get) Token: 0x0602D08B RID: 184459 RVA: 0x00AB5DD0 File Offset: 0x00AB3FD0
		// (set) Token: 0x0602D08C RID: 184460 RVA: 0x00AB5E13 File Offset: 0x00AB4013
		[Nullable(new byte[]
		{
			1,
			0
		})]
		public TArray<TEnumAsByte<ECommonAxis>> NotSyncAxisList
		{
			[return: Nullable(new byte[]
			{
				1,
				0
			})]
			get
			{
				base.FastCheckIsValid();
				TArray<TEnumAsByte<ECommonAxis>> result;
				if ((result = this._NotSyncAxisList) == null)
				{
					result = (this._NotSyncAxisList = new TArray<TEnumAsByte<ECommonAxis>>(base.NativePtr + (IntPtr)SFollowRotateInfo.__PropertyOffset_4, base.MemoryOwner ?? this));
				}
				return result;
			}
			[param: Nullable(new byte[]
			{
				1,
				0
			})]
			set
			{
				this.NotSyncAxisList.CopyAssign(value);
			}
		}

		// Token: 0x0602D08D RID: 184461 RVA: 0x00AB5E21 File Offset: 0x00AB4021
		public SFollowRotateInfo()
		{
		}

		// Token: 0x0602D08E RID: 184462 RVA: 0x00AB5E29 File Offset: 0x00AB4029
		public SFollowRotateInfo(int RotateSpeed, TEnumAsByte<EFollowRotateType> RotateType, int CameraDistance, [Nullable(1)] string EntityIdBlackboardKey, [Nullable(new byte[]
		{
			1,
			0
		})] TArray<TEnumAsByte<ECommonAxis>> NotSyncAxisList)
		{
			this.RotateSpeed = RotateSpeed;
			this.RotateType = RotateType;
			this.CameraDistance = CameraDistance;
			this.EntityIdBlackboardKey = EntityIdBlackboardKey;
			this.NotSyncAxisList = NotSyncAxisList;
		}

		// Token: 0x0602D08F RID: 184463 RVA: 0x00AB5E56 File Offset: 0x00AB4056
		protected override IntPtr GetUStructPtr()
		{
			return SFollowRotateInfo.StaticStruct();
		}

		// Token: 0x0602D090 RID: 184464 RVA: 0x00AB5E62 File Offset: 0x00AB4062
		[NullableContext(2)]
		public SFollowRotateInfo(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602D091 RID: 184465 RVA: 0x00AB5E6C File Offset: 0x00AB406C
		public SFollowRotateInfo(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602D092 RID: 184466 RVA: 0x00AB5E77 File Offset: 0x00AB4077
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SFollowRotateInfo(Pointer, false, true);
		}

		// Token: 0x0602D093 RID: 184467 RVA: 0x00AB5E81 File Offset: 0x00AB4081
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SFollowRotateInfo(Pointer, MemoryOwner);
		}

		// Token: 0x04019413 RID: 103443
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/SFollowRotateInfo.SFollowRotateInfo";

		// Token: 0x04019414 RID: 103444
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04019415 RID: 103445
		internal static int __PropertyOffset_0;

		// Token: 0x04019416 RID: 103446
		internal static int __PropertyOffset_1;

		// Token: 0x04019417 RID: 103447
		internal static int __PropertyOffset_2;

		// Token: 0x04019418 RID: 103448
		internal static int __PropertyOffset_3;

		// Token: 0x04019419 RID: 103449
		internal static int __PropertyOffset_4;

		// Token: 0x0401941A RID: 103450
		[Nullable(new byte[]
		{
			2,
			0
		})]
		private TArray<TEnumAsByte<ECommonAxis>> _NotSyncAxisList;
	}
}
