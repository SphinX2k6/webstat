using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Character.WeaponLevelMaterial
{
	// Token: 0x02003D5E RID: 15710
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Character/WeaponLevelMaterial/SWeaponLevelMaterialData.SWeaponLevelMaterialData")]
	[UnrealStructLayout(80, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 80)]
	public class SWeaponLevelMaterialData : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06026309 RID: 156425 RVA: 0x009D0780 File Offset: 0x009CE980
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SWeaponLevelMaterialData._ScriptStructPtr != 0) ? SWeaponLevelMaterialData._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Render/RuntimeBP/Character/WeaponLevelMaterial/SWeaponLevelMaterialData.SWeaponLevelMaterialData", ref SWeaponLevelMaterialData._ScriptStructPtr);
		}

		// Token: 0x170055EA RID: 21994
		// (get) Token: 0x0602630A RID: 156426 RVA: 0x009D07A4 File Offset: 0x009CE9A4
		// (set) Token: 0x0602630B RID: 156427 RVA: 0x009D07E7 File Offset: 0x009CE9E7
		public TMap<string, SWeaponMaterialParams> SlotNewParamValues
		{
			get
			{
				base.FastCheckIsValid();
				TMap<string, SWeaponMaterialParams> result;
				if ((result = this._SlotNewParamValues) == null)
				{
					result = (this._SlotNewParamValues = new TMap<string, SWeaponMaterialParams>(base.NativePtr + (IntPtr)SWeaponLevelMaterialData.__PropertyOffset_0, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.SlotNewParamValues.CopyAssign(value);
			}
		}

		// Token: 0x0602630C RID: 156428 RVA: 0x009D07F5 File Offset: 0x009CE9F5
		public SWeaponLevelMaterialData()
		{
		}

		// Token: 0x0602630D RID: 156429 RVA: 0x009D07FD File Offset: 0x009CE9FD
		public SWeaponLevelMaterialData(TMap<string, SWeaponMaterialParams> SlotNewParamValues)
		{
			this.SlotNewParamValues = SlotNewParamValues;
		}

		// Token: 0x0602630E RID: 156430 RVA: 0x009D080C File Offset: 0x009CEA0C
		protected override IntPtr GetUStructPtr()
		{
			return SWeaponLevelMaterialData.StaticStruct();
		}

		// Token: 0x0602630F RID: 156431 RVA: 0x009D0818 File Offset: 0x009CEA18
		[NullableContext(2)]
		public SWeaponLevelMaterialData(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06026310 RID: 156432 RVA: 0x009D0822 File Offset: 0x009CEA22
		public SWeaponLevelMaterialData(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06026311 RID: 156433 RVA: 0x009D082D File Offset: 0x009CEA2D
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SWeaponLevelMaterialData(Pointer, false, true);
		}

		// Token: 0x06026312 RID: 156434 RVA: 0x009D0837 File Offset: 0x009CEA37
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SWeaponLevelMaterialData(Pointer, MemoryOwner);
		}

		// Token: 0x04013C96 RID: 81046
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Character/WeaponLevelMaterial/SWeaponLevelMaterialData.SWeaponLevelMaterialData";

		// Token: 0x04013C97 RID: 81047
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04013C98 RID: 81048
		internal static int __PropertyOffset_0;

		// Token: 0x04013C99 RID: 81049
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private TMap<string, SWeaponMaterialParams> _SlotNewParamValues;
	}
}
