using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.Gameplay.MotorRailMove.Struct
{
	// Token: 0x02003EAC RID: 16044
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Data/Gameplay/MotorRailMove/Struct/SMotorRailMove_CommonConfig.SMotorRailMove_CommonConfig")]
	[UnrealStructLayout(168, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 168)]
	public class SMotorRailMove_CommonConfig : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06027D76 RID: 163190 RVA: 0x009FBE00 File Offset: 0x009FA000
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SMotorRailMove_CommonConfig._ScriptStructPtr != 0) ? SMotorRailMove_CommonConfig._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Gameplay/MotorRailMove/Struct/SMotorRailMove_CommonConfig.SMotorRailMove_CommonConfig", ref SMotorRailMove_CommonConfig._ScriptStructPtr);
		}

		// Token: 0x17005F37 RID: 24375
		// (get) Token: 0x06027D77 RID: 163191 RVA: 0x009FBE24 File Offset: 0x009FA024
		// (set) Token: 0x06027D78 RID: 163192 RVA: 0x009FBE67 File Offset: 0x009FA067
		public TMap<FGameplayTag, bool> ModifyVehicleTagsOnEnter
		{
			get
			{
				base.FastCheckIsValid();
				TMap<FGameplayTag, bool> result;
				if ((result = this._ModifyVehicleTagsOnEnter) == null)
				{
					result = (this._ModifyVehicleTagsOnEnter = new TMap<FGameplayTag, bool>(base.NativePtr + (IntPtr)SMotorRailMove_CommonConfig.__PropertyOffset_0, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.ModifyVehicleTagsOnEnter.CopyAssign(value);
			}
		}

		// Token: 0x17005F38 RID: 24376
		// (get) Token: 0x06027D79 RID: 163193 RVA: 0x009FBE78 File Offset: 0x009FA078
		// (set) Token: 0x06027D7A RID: 163194 RVA: 0x009FBEBB File Offset: 0x009FA0BB
		public TMap<FGameplayTag, bool> ModifyVehicleTagsOnExit
		{
			get
			{
				base.FastCheckIsValid();
				TMap<FGameplayTag, bool> result;
				if ((result = this._ModifyVehicleTagsOnExit) == null)
				{
					result = (this._ModifyVehicleTagsOnExit = new TMap<FGameplayTag, bool>(base.NativePtr + (IntPtr)SMotorRailMove_CommonConfig.__PropertyOffset_1, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.ModifyVehicleTagsOnExit.CopyAssign(value);
			}
		}

		// Token: 0x17005F39 RID: 24377
		// (get) Token: 0x06027D7B RID: 163195 RVA: 0x009FBEC9 File Offset: 0x009FA0C9
		// (set) Token: 0x06027D7C RID: 163196 RVA: 0x009FBED9 File Offset: 0x009FA0D9
		public unsafe bool EnableBlockingCheck
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SMotorRailMove_CommonConfig.__PropertyOffset_2) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SMotorRailMove_CommonConfig.__PropertyOffset_2) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005F3A RID: 24378
		// (get) Token: 0x06027D7D RID: 163197 RVA: 0x009FBEEA File Offset: 0x009FA0EA
		// (set) Token: 0x06027D7E RID: 163198 RVA: 0x009FBEFA File Offset: 0x009FA0FA
		public unsafe float MaxBlockingTimeOut
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SMotorRailMove_CommonConfig.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SMotorRailMove_CommonConfig.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x06027D7F RID: 163199 RVA: 0x009FBF0B File Offset: 0x009FA10B
		public SMotorRailMove_CommonConfig()
		{
		}

		// Token: 0x06027D80 RID: 163200 RVA: 0x009FBF13 File Offset: 0x009FA113
		public SMotorRailMove_CommonConfig(TMap<FGameplayTag, bool> ModifyVehicleTagsOnEnter, TMap<FGameplayTag, bool> ModifyVehicleTagsOnExit, bool EnableBlockingCheck, float MaxBlockingTimeOut)
		{
			this.ModifyVehicleTagsOnEnter = ModifyVehicleTagsOnEnter;
			this.ModifyVehicleTagsOnExit = ModifyVehicleTagsOnExit;
			this.EnableBlockingCheck = EnableBlockingCheck;
			this.MaxBlockingTimeOut = MaxBlockingTimeOut;
		}

		// Token: 0x06027D81 RID: 163201 RVA: 0x009FBF38 File Offset: 0x009FA138
		protected override IntPtr GetUStructPtr()
		{
			return SMotorRailMove_CommonConfig.StaticStruct();
		}

		// Token: 0x06027D82 RID: 163202 RVA: 0x009FBF44 File Offset: 0x009FA144
		[NullableContext(2)]
		public SMotorRailMove_CommonConfig(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06027D83 RID: 163203 RVA: 0x009FBF4E File Offset: 0x009FA14E
		public SMotorRailMove_CommonConfig(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06027D84 RID: 163204 RVA: 0x009FBF59 File Offset: 0x009FA159
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SMotorRailMove_CommonConfig(Pointer, false, true);
		}

		// Token: 0x06027D85 RID: 163205 RVA: 0x009FBF63 File Offset: 0x009FA163
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SMotorRailMove_CommonConfig(Pointer, MemoryOwner);
		}

		// Token: 0x04014E7B RID: 85627
		public const string __ObjectPath = "/Game/Aki/Data/Gameplay/MotorRailMove/Struct/SMotorRailMove_CommonConfig.SMotorRailMove_CommonConfig";

		// Token: 0x04014E7C RID: 85628
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04014E7D RID: 85629
		internal static int __PropertyOffset_0;

		// Token: 0x04014E7E RID: 85630
		[Nullable(2)]
		private TMap<FGameplayTag, bool> _ModifyVehicleTagsOnEnter;

		// Token: 0x04014E7F RID: 85631
		internal static int __PropertyOffset_1;

		// Token: 0x04014E80 RID: 85632
		[Nullable(2)]
		private TMap<FGameplayTag, bool> _ModifyVehicleTagsOnExit;

		// Token: 0x04014E81 RID: 85633
		internal static int __PropertyOffset_2;

		// Token: 0x04014E82 RID: 85634
		internal static int __PropertyOffset_3;
	}
}
