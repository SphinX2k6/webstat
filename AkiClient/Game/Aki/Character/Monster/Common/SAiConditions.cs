using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Condition.Enum;
using AkiClient.Game.Aki.Protocol;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Character.Monster.Common
{
	// Token: 0x0200419E RID: 16798
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/Monster/Common/SAiConditions.SAiConditions")]
	[UnrealStructLayout(184, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 177)]
	public class SAiConditions : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602C953 RID: 182611 RVA: 0x00AA7196 File Offset: 0x00AA5396
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SAiConditions._ScriptStructPtr != 0) ? SAiConditions._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/Monster/Common/SAiConditions.SAiConditions", ref SAiConditions._ScriptStructPtr);
		}

		// Token: 0x17007829 RID: 30761
		// (get) Token: 0x0602C954 RID: 182612 RVA: 0x00AA71BC File Offset: 0x00AA53BC
		// (set) Token: 0x0602C955 RID: 182613 RVA: 0x00AA71FF File Offset: 0x00AA53FF
		public TMap<FGameplayTag, FFloatRange> Tags
		{
			get
			{
				base.FastCheckIsValid();
				TMap<FGameplayTag, FFloatRange> result;
				if ((result = this._Tags) == null)
				{
					result = (this._Tags = new TMap<FGameplayTag, FFloatRange>(base.NativePtr + (IntPtr)SAiConditions.__PropertyOffset_0, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.Tags.CopyAssign(value);
			}
		}

		// Token: 0x1700782A RID: 30762
		// (get) Token: 0x0602C956 RID: 182614 RVA: 0x00AA7210 File Offset: 0x00AA5410
		// (set) Token: 0x0602C957 RID: 182615 RVA: 0x00AA7253 File Offset: 0x00AA5453
		[Nullable(new byte[]
		{
			1,
			0
		})]
		public TMap<TEnumAsByte<EAttributeType>, FFloatRange> Attributes
		{
			[return: Nullable(new byte[]
			{
				1,
				0
			})]
			get
			{
				base.FastCheckIsValid();
				TMap<TEnumAsByte<EAttributeType>, FFloatRange> result;
				if ((result = this._Attributes) == null)
				{
					result = (this._Attributes = new TMap<TEnumAsByte<EAttributeType>, FFloatRange>(base.NativePtr + (IntPtr)SAiConditions.__PropertyOffset_1, base.MemoryOwner ?? this));
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
				this.Attributes.CopyAssign(value);
			}
		}

		// Token: 0x1700782B RID: 30763
		// (get) Token: 0x0602C958 RID: 182616 RVA: 0x00AA7264 File Offset: 0x00AA5464
		// (set) Token: 0x0602C959 RID: 182617 RVA: 0x00AA72A7 File Offset: 0x00AA54A7
		public TArray<SAiAttributeRate> AttributeRates
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SAiAttributeRate> result;
				if ((result = this._AttributeRates) == null)
				{
					result = (this._AttributeRates = new TArray<SAiAttributeRate>(base.NativePtr + (IntPtr)SAiConditions.__PropertyOffset_2, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.AttributeRates.CopyAssign(value);
			}
		}

		// Token: 0x1700782C RID: 30764
		// (get) Token: 0x0602C95A RID: 182618 RVA: 0x00AA72B5 File Offset: 0x00AA54B5
		// (set) Token: 0x0602C95B RID: 182619 RVA: 0x00AA72C9 File Offset: 0x00AA54C9
		[Nullable(0)]
		public unsafe TEnumAsByte<SConditionGroupType> Logic
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)SAiConditions.__PropertyOffset_3);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)SAiConditions.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x0602C95C RID: 182620 RVA: 0x00AA72DE File Offset: 0x00AA54DE
		public SAiConditions()
		{
		}

		// Token: 0x0602C95D RID: 182621 RVA: 0x00AA72E6 File Offset: 0x00AA54E6
		public SAiConditions(TMap<FGameplayTag, FFloatRange> Tags, [Nullable(new byte[]
		{
			1,
			0
		})] TMap<TEnumAsByte<EAttributeType>, FFloatRange> Attributes, TArray<SAiAttributeRate> AttributeRates, [Nullable(0)] TEnumAsByte<SConditionGroupType> Logic)
		{
			this.Tags = Tags;
			this.Attributes = Attributes;
			this.AttributeRates = AttributeRates;
			this.Logic = Logic;
		}

		// Token: 0x0602C95E RID: 182622 RVA: 0x00AA730B File Offset: 0x00AA550B
		protected override IntPtr GetUStructPtr()
		{
			return SAiConditions.StaticStruct();
		}

		// Token: 0x0602C95F RID: 182623 RVA: 0x00AA7317 File Offset: 0x00AA5517
		[NullableContext(2)]
		public SAiConditions(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602C960 RID: 182624 RVA: 0x00AA7321 File Offset: 0x00AA5521
		public SAiConditions(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602C961 RID: 182625 RVA: 0x00AA732C File Offset: 0x00AA552C
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SAiConditions(Pointer, false, true);
		}

		// Token: 0x0602C962 RID: 182626 RVA: 0x00AA7336 File Offset: 0x00AA5536
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SAiConditions(Pointer, MemoryOwner);
		}

		// Token: 0x04018CE0 RID: 101600
		public const string __ObjectPath = "/Game/Aki/Character/Monster/Common/SAiConditions.SAiConditions";

		// Token: 0x04018CE1 RID: 101601
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04018CE2 RID: 101602
		internal static int __PropertyOffset_0;

		// Token: 0x04018CE3 RID: 101603
		[Nullable(2)]
		private TMap<FGameplayTag, FFloatRange> _Tags;

		// Token: 0x04018CE4 RID: 101604
		internal static int __PropertyOffset_1;

		// Token: 0x04018CE5 RID: 101605
		[Nullable(new byte[]
		{
			2,
			0
		})]
		private TMap<TEnumAsByte<EAttributeType>, FFloatRange> _Attributes;

		// Token: 0x04018CE6 RID: 101606
		internal static int __PropertyOffset_2;

		// Token: 0x04018CE7 RID: 101607
		[Nullable(2)]
		private TArray<SAiAttributeRate> _AttributeRates;

		// Token: 0x04018CE8 RID: 101608
		internal static int __PropertyOffset_3;
	}
}
