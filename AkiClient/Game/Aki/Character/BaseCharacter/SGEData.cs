using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x02004264 RID: 16996
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/SGEData.SGEData")]
	[UnrealStructLayout(64, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 64)]
	public class SGEData : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602D0A9 RID: 184489 RVA: 0x00AB6018 File Offset: 0x00AB4218
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SGEData._ScriptStructPtr != 0) ? SGEData._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/BaseCharacter/SGEData.SGEData", ref SGEData._ScriptStructPtr);
		}

		// Token: 0x17007A3C RID: 31292
		// (get) Token: 0x0602D0AA RID: 184490 RVA: 0x00AB603C File Offset: 0x00AB423C
		// (set) Token: 0x0602D0AB RID: 184491 RVA: 0x00AB6050 File Offset: 0x00AB4250
		public unsafe FName GEName
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SGEData.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SGEData.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17007A3D RID: 31293
		// (get) Token: 0x0602D0AC RID: 184492 RVA: 0x00AB6068 File Offset: 0x00AB4268
		// (set) Token: 0x0602D0AD RID: 184493 RVA: 0x00AB60AB File Offset: 0x00AB42AB
		public unsafe FText Comment
		{
			get
			{
				base.FastCheckIsValid();
				FText result;
				if ((result = this._Comment) == null)
				{
					result = (this._Comment = new FText(base.NativePtr + (IntPtr)SGEData.__PropertyOffset_1, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				FText.NativeCopy((void*)(base.NativePtr + (byte*)((IntPtr)SGEData.__PropertyOffset_1)), value.NativePtr, 1);
			}
		}

		// Token: 0x17007A3E RID: 31294
		// (get) Token: 0x0602D0AE RID: 184494 RVA: 0x00AB60C6 File Offset: 0x00AB42C6
		// (set) Token: 0x0602D0AF RID: 184495 RVA: 0x00AB60DA File Offset: 0x00AB42DA
		[Nullable(new byte[]
		{
			0,
			1
		})]
		public unsafe TSubclassOf<UGameplayEffect> GE
		{
			[return: Nullable(new byte[]
			{
				0,
				1
			})]
			get
			{
				return *(base.NativePtr + (IntPtr)SGEData.__PropertyOffset_2);
			}
			[param: Nullable(new byte[]
			{
				0,
				1
			})]
			set
			{
				*(base.NativePtr + (IntPtr)SGEData.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17007A3F RID: 31295
		// (get) Token: 0x0602D0B0 RID: 184496 RVA: 0x00AB60F0 File Offset: 0x00AB42F0
		// (set) Token: 0x0602D0B1 RID: 184497 RVA: 0x00AB6133 File Offset: 0x00AB4333
		public TArray<SFloatPayload> Payload
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SFloatPayload> result;
				if ((result = this._Payload) == null)
				{
					result = (this._Payload = new TArray<SFloatPayload>(base.NativePtr + (IntPtr)SGEData.__PropertyOffset_3, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.Payload.CopyAssign(value);
			}
		}

		// Token: 0x0602D0B2 RID: 184498 RVA: 0x00AB6141 File Offset: 0x00AB4341
		public SGEData()
		{
		}

		// Token: 0x0602D0B3 RID: 184499 RVA: 0x00AB6149 File Offset: 0x00AB4349
		public SGEData(FName GEName, FText Comment, [Nullable(new byte[]
		{
			0,
			1
		})] TSubclassOf<UGameplayEffect> GE, TArray<SFloatPayload> Payload)
		{
			this.GEName = GEName;
			this.Comment = Comment;
			this.GE = GE;
			this.Payload = Payload;
		}

		// Token: 0x0602D0B4 RID: 184500 RVA: 0x00AB616E File Offset: 0x00AB436E
		protected override IntPtr GetUStructPtr()
		{
			return SGEData.StaticStruct();
		}

		// Token: 0x0602D0B5 RID: 184501 RVA: 0x00AB617A File Offset: 0x00AB437A
		[NullableContext(2)]
		public SGEData(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602D0B6 RID: 184502 RVA: 0x00AB6184 File Offset: 0x00AB4384
		public SGEData(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602D0B7 RID: 184503 RVA: 0x00AB618F File Offset: 0x00AB438F
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SGEData(Pointer, false, true);
		}

		// Token: 0x0602D0B8 RID: 184504 RVA: 0x00AB6199 File Offset: 0x00AB4399
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SGEData(Pointer, MemoryOwner);
		}

		// Token: 0x04019424 RID: 103460
		public const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/SGEData.SGEData";

		// Token: 0x04019425 RID: 103461
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04019426 RID: 103462
		internal static int __PropertyOffset_0;

		// Token: 0x04019427 RID: 103463
		internal static int __PropertyOffset_1;

		// Token: 0x04019428 RID: 103464
		[Nullable(2)]
		private FText _Comment;

		// Token: 0x04019429 RID: 103465
		internal static int __PropertyOffset_2;

		// Token: 0x0401942A RID: 103466
		internal static int __PropertyOffset_3;

		// Token: 0x0401942B RID: 103467
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<SFloatPayload> _Payload;
	}
}
