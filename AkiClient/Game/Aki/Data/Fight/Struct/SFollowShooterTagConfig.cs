using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Data.Fight.Struct
{
	// Token: 0x02003ECE RID: 16078
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Data/Fight/Struct/SFollowShooterTagConfig.SFollowShooterTagConfig")]
	[UnrealStructLayout(72, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 66)]
	public class SFollowShooterTagConfig : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06027F50 RID: 163664 RVA: 0x009FF01C File Offset: 0x009FD21C
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SFollowShooterTagConfig._ScriptStructPtr != 0) ? SFollowShooterTagConfig._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Fight/Struct/SFollowShooterTagConfig.SFollowShooterTagConfig", ref SFollowShooterTagConfig._ScriptStructPtr);
		}

		// Token: 0x17005FB4 RID: 24500
		// (get) Token: 0x06027F51 RID: 163665 RVA: 0x009FF040 File Offset: 0x009FD240
		// (set) Token: 0x06027F52 RID: 163666 RVA: 0x009FF083 File Offset: 0x009FD283
		public FGameplayTagContainer AddTags
		{
			get
			{
				base.FastCheckIsValid();
				FGameplayTagContainer result;
				if ((result = this._AddTags) == null)
				{
					result = (this._AddTags = new FGameplayTagContainer(base.NativePtr + (IntPtr)SFollowShooterTagConfig.__PropertyOffset_0, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FGameplayTagContainer.StaticStruct(), base.NativePtr + (IntPtr)SFollowShooterTagConfig.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005FB5 RID: 24501
		// (get) Token: 0x06027F53 RID: 163667 RVA: 0x009FF0A4 File Offset: 0x009FD2A4
		// (set) Token: 0x06027F54 RID: 163668 RVA: 0x009FF0E7 File Offset: 0x009FD2E7
		public FGameplayTagContainer CheckTags
		{
			get
			{
				base.FastCheckIsValid();
				FGameplayTagContainer result;
				if ((result = this._CheckTags) == null)
				{
					result = (this._CheckTags = new FGameplayTagContainer(base.NativePtr + (IntPtr)SFollowShooterTagConfig.__PropertyOffset_1, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FGameplayTagContainer.StaticStruct(), base.NativePtr + (IntPtr)SFollowShooterTagConfig.__PropertyOffset_1, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005FB6 RID: 24502
		// (get) Token: 0x06027F55 RID: 163669 RVA: 0x009FF108 File Offset: 0x009FD308
		// (set) Token: 0x06027F56 RID: 163670 RVA: 0x009FF118 File Offset: 0x009FD318
		public unsafe bool CheckHasTag
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SFollowShooterTagConfig.__PropertyOffset_2) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SFollowShooterTagConfig.__PropertyOffset_2) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005FB7 RID: 24503
		// (get) Token: 0x06027F57 RID: 163671 RVA: 0x009FF129 File Offset: 0x009FD329
		// (set) Token: 0x06027F58 RID: 163672 RVA: 0x009FF13D File Offset: 0x009FD33D
		[Nullable(0)]
		public unsafe TEnumAsByte<ETagLogicType> LogicType
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)SFollowShooterTagConfig.__PropertyOffset_3);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)SFollowShooterTagConfig.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x06027F59 RID: 163673 RVA: 0x009FF152 File Offset: 0x009FD352
		public SFollowShooterTagConfig()
		{
		}

		// Token: 0x06027F5A RID: 163674 RVA: 0x009FF15A File Offset: 0x009FD35A
		public SFollowShooterTagConfig(FGameplayTagContainer AddTags, FGameplayTagContainer CheckTags, bool CheckHasTag, [Nullable(0)] TEnumAsByte<ETagLogicType> LogicType)
		{
			this.AddTags = AddTags;
			this.CheckTags = CheckTags;
			this.CheckHasTag = CheckHasTag;
			this.LogicType = LogicType;
		}

		// Token: 0x06027F5B RID: 163675 RVA: 0x009FF17F File Offset: 0x009FD37F
		protected override IntPtr GetUStructPtr()
		{
			return SFollowShooterTagConfig.StaticStruct();
		}

		// Token: 0x06027F5C RID: 163676 RVA: 0x009FF18B File Offset: 0x009FD38B
		[NullableContext(2)]
		public SFollowShooterTagConfig(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06027F5D RID: 163677 RVA: 0x009FF195 File Offset: 0x009FD395
		public SFollowShooterTagConfig(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06027F5E RID: 163678 RVA: 0x009FF1A0 File Offset: 0x009FD3A0
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SFollowShooterTagConfig(Pointer, false, true);
		}

		// Token: 0x06027F5F RID: 163679 RVA: 0x009FF1AA File Offset: 0x009FD3AA
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SFollowShooterTagConfig(Pointer, MemoryOwner);
		}

		// Token: 0x04014FA8 RID: 85928
		public const string __ObjectPath = "/Game/Aki/Data/Fight/Struct/SFollowShooterTagConfig.SFollowShooterTagConfig";

		// Token: 0x04014FA9 RID: 85929
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04014FAA RID: 85930
		internal static int __PropertyOffset_0;

		// Token: 0x04014FAB RID: 85931
		[Nullable(2)]
		private FGameplayTagContainer _AddTags;

		// Token: 0x04014FAC RID: 85932
		internal static int __PropertyOffset_1;

		// Token: 0x04014FAD RID: 85933
		[Nullable(2)]
		private FGameplayTagContainer _CheckTags;

		// Token: 0x04014FAE RID: 85934
		internal static int __PropertyOffset_2;

		// Token: 0x04014FAF RID: 85935
		internal static int __PropertyOffset_3;
	}
}
