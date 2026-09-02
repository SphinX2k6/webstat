using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Vehicle.Motor.Data
{
	// Token: 0x02003FAA RID: 16298
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/Vehicle/Motor/Data/SMotorConfigs.SMotorConfigs")]
	[UnrealStructLayout(64, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 64)]
	public class SMotorConfigs : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06028EAA RID: 167594 RVA: 0x00A1A987 File Offset: 0x00A18B87
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SMotorConfigs._ScriptStructPtr != 0) ? SMotorConfigs._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/Vehicle/Motor/Data/SMotorConfigs.SMotorConfigs", ref SMotorConfigs._ScriptStructPtr);
		}

		// Token: 0x170064D6 RID: 25814
		// (get) Token: 0x06028EAB RID: 167595 RVA: 0x00A1A9AC File Offset: 0x00A18BAC
		// (set) Token: 0x06028EAC RID: 167596 RVA: 0x00A1A9EF File Offset: 0x00A18BEF
		public FGameplayTagContainer ActivateTags
		{
			get
			{
				base.FastCheckIsValid();
				FGameplayTagContainer result;
				if ((result = this._ActivateTags) == null)
				{
					result = (this._ActivateTags = new FGameplayTagContainer(base.NativePtr + (IntPtr)SMotorConfigs.__PropertyOffset_0, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FGameplayTagContainer.StaticStruct(), base.NativePtr + (IntPtr)SMotorConfigs.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170064D7 RID: 25815
		// (get) Token: 0x06028EAD RID: 167597 RVA: 0x00A1AA10 File Offset: 0x00A18C10
		// (set) Token: 0x06028EAE RID: 167598 RVA: 0x00A1AA20 File Offset: 0x00A18C20
		public unsafe int Priority
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SMotorConfigs.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SMotorConfigs.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x170064D8 RID: 25816
		// (get) Token: 0x06028EAF RID: 167599 RVA: 0x00A1AA34 File Offset: 0x00A18C34
		// (set) Token: 0x06028EB0 RID: 167600 RVA: 0x00A1AA77 File Offset: 0x00A18C77
		[Nullable(new byte[]
		{
			1,
			0
		})]
		public TArray<TEnumAsByte<EMotorPropertyName>> VarNames
		{
			[return: Nullable(new byte[]
			{
				1,
				0
			})]
			get
			{
				base.FastCheckIsValid();
				TArray<TEnumAsByte<EMotorPropertyName>> result;
				if ((result = this._VarNames) == null)
				{
					result = (this._VarNames = new TArray<TEnumAsByte<EMotorPropertyName>>(base.NativePtr + (IntPtr)SMotorConfigs.__PropertyOffset_2, base.MemoryOwner ?? this));
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
				this.VarNames.CopyAssign(value);
			}
		}

		// Token: 0x170064D9 RID: 25817
		// (get) Token: 0x06028EB1 RID: 167601 RVA: 0x00A1AA85 File Offset: 0x00A18C85
		// (set) Token: 0x06028EB2 RID: 167602 RVA: 0x00A1AA99 File Offset: 0x00A18C99
		[Nullable(2)]
		public unsafe UMotorcycleConfigs Configs
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMotorcycleConfigs>(base.NativePtr / (IntPtr)sizeof(void*) + SMotorConfigs.__PropertyOffset_3);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + SMotorConfigs.__PropertyOffset_3, value);
			}
		}

		// Token: 0x06028EB3 RID: 167603 RVA: 0x00A1AAAE File Offset: 0x00A18CAE
		public SMotorConfigs()
		{
		}

		// Token: 0x06028EB4 RID: 167604 RVA: 0x00A1AAB6 File Offset: 0x00A18CB6
		public SMotorConfigs(FGameplayTagContainer ActivateTags, int Priority, [Nullable(new byte[]
		{
			1,
			0
		})] TArray<TEnumAsByte<EMotorPropertyName>> VarNames, UMotorcycleConfigs Configs)
		{
			this.ActivateTags = ActivateTags;
			this.Priority = Priority;
			this.VarNames = VarNames;
			this.Configs = Configs;
		}

		// Token: 0x06028EB5 RID: 167605 RVA: 0x00A1AADB File Offset: 0x00A18CDB
		protected override IntPtr GetUStructPtr()
		{
			return SMotorConfigs.StaticStruct();
		}

		// Token: 0x06028EB6 RID: 167606 RVA: 0x00A1AAE7 File Offset: 0x00A18CE7
		[NullableContext(2)]
		public SMotorConfigs(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06028EB7 RID: 167607 RVA: 0x00A1AAF1 File Offset: 0x00A18CF1
		public SMotorConfigs(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06028EB8 RID: 167608 RVA: 0x00A1AAFC File Offset: 0x00A18CFC
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SMotorConfigs(Pointer, false, true);
		}

		// Token: 0x06028EB9 RID: 167609 RVA: 0x00A1AB06 File Offset: 0x00A18D06
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SMotorConfigs(Pointer, MemoryOwner);
		}

		// Token: 0x04015A49 RID: 88649
		public const string __ObjectPath = "/Game/Aki/Character/Vehicle/Motor/Data/SMotorConfigs.SMotorConfigs";

		// Token: 0x04015A4A RID: 88650
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04015A4B RID: 88651
		internal static int __PropertyOffset_0;

		// Token: 0x04015A4C RID: 88652
		[Nullable(2)]
		private FGameplayTagContainer _ActivateTags;

		// Token: 0x04015A4D RID: 88653
		internal static int __PropertyOffset_1;

		// Token: 0x04015A4E RID: 88654
		internal static int __PropertyOffset_2;

		// Token: 0x04015A4F RID: 88655
		[Nullable(new byte[]
		{
			2,
			0
		})]
		private TArray<TEnumAsByte<EMotorPropertyName>> _VarNames;

		// Token: 0x04015A50 RID: 88656
		internal static int __PropertyOffset_3;
	}
}
