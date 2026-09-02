using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.Common.Struct
{
	// Token: 0x02003F09 RID: 16137
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Data/Common/Struct/SCharacterLocationsAndRadius.SCharacterLocationsAndRadius")]
	[UnrealStructLayout(48, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 48)]
	public class SCharacterLocationsAndRadius : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602831D RID: 164637 RVA: 0x00A04EEF File Offset: 0x00A030EF
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SCharacterLocationsAndRadius._ScriptStructPtr != 0) ? SCharacterLocationsAndRadius._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Common/Struct/SCharacterLocationsAndRadius.SCharacterLocationsAndRadius", ref SCharacterLocationsAndRadius._ScriptStructPtr);
		}

		// Token: 0x170060FF RID: 24831
		// (get) Token: 0x0602831E RID: 164638 RVA: 0x00A04F14 File Offset: 0x00A03114
		// (set) Token: 0x0602831F RID: 164639 RVA: 0x00A04F57 File Offset: 0x00A03157
		public TArray<FVectorDouble> Locations
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FVectorDouble> result;
				if ((result = this._Locations) == null)
				{
					result = (this._Locations = new TArray<FVectorDouble>(base.NativePtr + (IntPtr)SCharacterLocationsAndRadius.__PropertyOffset_0, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.Locations.CopyAssign(value);
			}
		}

		// Token: 0x17006100 RID: 24832
		// (get) Token: 0x06028320 RID: 164640 RVA: 0x00A04F68 File Offset: 0x00A03168
		// (set) Token: 0x06028321 RID: 164641 RVA: 0x00A04FAB File Offset: 0x00A031AB
		public TArray<float> Radius
		{
			get
			{
				base.FastCheckIsValid();
				TArray<float> result;
				if ((result = this._Radius) == null)
				{
					result = (this._Radius = new TArray<float>(base.NativePtr + (IntPtr)SCharacterLocationsAndRadius.__PropertyOffset_1, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.Radius.CopyAssign(value);
			}
		}

		// Token: 0x17006101 RID: 24833
		// (get) Token: 0x06028322 RID: 164642 RVA: 0x00A04FBC File Offset: 0x00A031BC
		// (set) Token: 0x06028323 RID: 164643 RVA: 0x00A04FFF File Offset: 0x00A031FF
		public TArray<float> HalfHeight
		{
			get
			{
				base.FastCheckIsValid();
				TArray<float> result;
				if ((result = this._HalfHeight) == null)
				{
					result = (this._HalfHeight = new TArray<float>(base.NativePtr + (IntPtr)SCharacterLocationsAndRadius.__PropertyOffset_2, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.HalfHeight.CopyAssign(value);
			}
		}

		// Token: 0x06028324 RID: 164644 RVA: 0x00A0500D File Offset: 0x00A0320D
		public SCharacterLocationsAndRadius()
		{
		}

		// Token: 0x06028325 RID: 164645 RVA: 0x00A05015 File Offset: 0x00A03215
		public SCharacterLocationsAndRadius(TArray<FVectorDouble> Locations, TArray<float> Radius, TArray<float> HalfHeight)
		{
			this.Locations = Locations;
			this.Radius = Radius;
			this.HalfHeight = HalfHeight;
		}

		// Token: 0x06028326 RID: 164646 RVA: 0x00A05032 File Offset: 0x00A03232
		protected override IntPtr GetUStructPtr()
		{
			return SCharacterLocationsAndRadius.StaticStruct();
		}

		// Token: 0x06028327 RID: 164647 RVA: 0x00A0503E File Offset: 0x00A0323E
		[NullableContext(2)]
		public SCharacterLocationsAndRadius(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06028328 RID: 164648 RVA: 0x00A05048 File Offset: 0x00A03248
		public SCharacterLocationsAndRadius(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06028329 RID: 164649 RVA: 0x00A05053 File Offset: 0x00A03253
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SCharacterLocationsAndRadius(Pointer, false, true);
		}

		// Token: 0x0602832A RID: 164650 RVA: 0x00A0505D File Offset: 0x00A0325D
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SCharacterLocationsAndRadius(Pointer, MemoryOwner);
		}

		// Token: 0x04015219 RID: 86553
		public const string __ObjectPath = "/Game/Aki/Data/Common/Struct/SCharacterLocationsAndRadius.SCharacterLocationsAndRadius";

		// Token: 0x0401521A RID: 86554
		private static IntPtr _ScriptStructPtr;

		// Token: 0x0401521B RID: 86555
		internal static int __PropertyOffset_0;

		// Token: 0x0401521C RID: 86556
		[Nullable(2)]
		private TArray<FVectorDouble> _Locations;

		// Token: 0x0401521D RID: 86557
		internal static int __PropertyOffset_1;

		// Token: 0x0401521E RID: 86558
		[Nullable(2)]
		private TArray<float> _Radius;

		// Token: 0x0401521F RID: 86559
		internal static int __PropertyOffset_2;

		// Token: 0x04015220 RID: 86560
		[Nullable(2)]
		private TArray<float> _HalfHeight;
	}
}
