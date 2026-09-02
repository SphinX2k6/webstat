using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Effect.BluePrint.BP_FX_Common
{
	// Token: 0x02003DF0 RID: 15856
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Effect/BluePrint/BP_FX_Common/SBeamYinlinEffect.SBeamYinlinEffect")]
	[UnrealStructLayout(40, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 40)]
	public class SBeamYinlinEffect : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06027013 RID: 159763 RVA: 0x009E79F8 File Offset: 0x009E5BF8
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SBeamYinlinEffect._ScriptStructPtr != 0) ? SBeamYinlinEffect._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Effect/BluePrint/BP_FX_Common/SBeamYinlinEffect.SBeamYinlinEffect", ref SBeamYinlinEffect._ScriptStructPtr);
		}

		// Token: 0x17005A80 RID: 23168
		// (get) Token: 0x06027014 RID: 159764 RVA: 0x009E7A1C File Offset: 0x009E5C1C
		// (set) Token: 0x06027015 RID: 159765 RVA: 0x009E7A2C File Offset: 0x009E5C2C
		public unsafe float Time
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SBeamYinlinEffect.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SBeamYinlinEffect.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17005A81 RID: 23169
		// (get) Token: 0x06027016 RID: 159766 RVA: 0x009E7A40 File Offset: 0x009E5C40
		// (set) Token: 0x06027017 RID: 159767 RVA: 0x009E7A83 File Offset: 0x009E5C83
		public TArray<FVector> Poses
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FVector> result;
				if ((result = this._Poses) == null)
				{
					result = (this._Poses = new TArray<FVector>(base.NativePtr + (IntPtr)SBeamYinlinEffect.__PropertyOffset_1, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.Poses.CopyAssign(value);
			}
		}

		// Token: 0x17005A82 RID: 23170
		// (get) Token: 0x06027018 RID: 159768 RVA: 0x009E7A94 File Offset: 0x009E5C94
		// (set) Token: 0x06027019 RID: 159769 RVA: 0x009E7AD7 File Offset: 0x009E5CD7
		public TArray<bool> ChangedPoints
		{
			get
			{
				base.FastCheckIsValid();
				TArray<bool> result;
				if ((result = this._ChangedPoints) == null)
				{
					result = (this._ChangedPoints = new TArray<bool>(base.NativePtr + (IntPtr)SBeamYinlinEffect.__PropertyOffset_2, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.ChangedPoints.CopyAssign(value);
			}
		}

		// Token: 0x0602701A RID: 159770 RVA: 0x009E7AE5 File Offset: 0x009E5CE5
		public SBeamYinlinEffect()
		{
		}

		// Token: 0x0602701B RID: 159771 RVA: 0x009E7AED File Offset: 0x009E5CED
		public SBeamYinlinEffect(float Time, TArray<FVector> Poses, TArray<bool> ChangedPoints)
		{
			this.Time = Time;
			this.Poses = Poses;
			this.ChangedPoints = ChangedPoints;
		}

		// Token: 0x0602701C RID: 159772 RVA: 0x009E7B0A File Offset: 0x009E5D0A
		protected override IntPtr GetUStructPtr()
		{
			return SBeamYinlinEffect.StaticStruct();
		}

		// Token: 0x0602701D RID: 159773 RVA: 0x009E7B16 File Offset: 0x009E5D16
		[NullableContext(2)]
		public SBeamYinlinEffect(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602701E RID: 159774 RVA: 0x009E7B20 File Offset: 0x009E5D20
		public SBeamYinlinEffect(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602701F RID: 159775 RVA: 0x009E7B2B File Offset: 0x009E5D2B
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SBeamYinlinEffect(Pointer, false, true);
		}

		// Token: 0x06027020 RID: 159776 RVA: 0x009E7B35 File Offset: 0x009E5D35
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SBeamYinlinEffect(Pointer, MemoryOwner);
		}

		// Token: 0x040145E7 RID: 83431
		public const string __ObjectPath = "/Game/Aki/Effect/BluePrint/BP_FX_Common/SBeamYinlinEffect.SBeamYinlinEffect";

		// Token: 0x040145E8 RID: 83432
		private static IntPtr _ScriptStructPtr;

		// Token: 0x040145E9 RID: 83433
		internal static int __PropertyOffset_0;

		// Token: 0x040145EA RID: 83434
		internal static int __PropertyOffset_1;

		// Token: 0x040145EB RID: 83435
		[Nullable(2)]
		private TArray<FVector> _Poses;

		// Token: 0x040145EC RID: 83436
		internal static int __PropertyOffset_2;

		// Token: 0x040145ED RID: 83437
		[Nullable(2)]
		private TArray<bool> _ChangedPoints;
	}
}
