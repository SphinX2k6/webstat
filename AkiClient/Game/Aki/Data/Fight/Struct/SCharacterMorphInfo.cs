using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Data.Fight.Struct
{
	// Token: 0x02003ECA RID: 16074
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Data/Fight/Struct/SCharacterMorphInfo.SCharacterMorphInfo")]
	[UnrealStructLayout(440, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 440)]
	public class SCharacterMorphInfo : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06027F05 RID: 163589 RVA: 0x009FE7F0 File Offset: 0x009FC9F0
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SCharacterMorphInfo._ScriptStructPtr != 0) ? SCharacterMorphInfo._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Fight/Struct/SCharacterMorphInfo.SCharacterMorphInfo", ref SCharacterMorphInfo._ScriptStructPtr);
		}

		// Token: 0x17005F9E RID: 24478
		// (get) Token: 0x06027F06 RID: 163590 RVA: 0x009FE814 File Offset: 0x009FCA14
		// (set) Token: 0x06027F07 RID: 163591 RVA: 0x009FE824 File Offset: 0x009FCA24
		public unsafe int ModelId
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCharacterMorphInfo.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCharacterMorphInfo.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17005F9F RID: 24479
		// (get) Token: 0x06027F08 RID: 163592 RVA: 0x009FE835 File Offset: 0x009FCA35
		// (set) Token: 0x06027F09 RID: 163593 RVA: 0x009FE854 File Offset: 0x009FCA54
		public TSoftObjectPtr<UPrimaryDataAsset> PartHitEffect
		{
			get
			{
				return new TSoftObjectPtr<UPrimaryDataAsset>(base.NativePtr + (IntPtr)SCharacterMorphInfo.__PropertyOffset_1, base.MemoryOwner ?? this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)SCharacterMorphInfo.__PropertyOffset_1, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005FA0 RID: 24480
		// (get) Token: 0x06027F0A RID: 163594 RVA: 0x009FE879 File Offset: 0x009FCA79
		// (set) Token: 0x06027F0B RID: 163595 RVA: 0x009FE898 File Offset: 0x009FCA98
		public TSoftObjectPtr<UDataTable> DtBaseMovementSetting
		{
			get
			{
				return new TSoftObjectPtr<UDataTable>(base.NativePtr + (IntPtr)SCharacterMorphInfo.__PropertyOffset_2, base.MemoryOwner ?? this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)SCharacterMorphInfo.__PropertyOffset_2, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005FA1 RID: 24481
		// (get) Token: 0x06027F0C RID: 163596 RVA: 0x009FE8BD File Offset: 0x009FCABD
		// (set) Token: 0x06027F0D RID: 163597 RVA: 0x009FE8DC File Offset: 0x009FCADC
		public TSoftObjectPtr<UDataTable> DtCameraConfig
		{
			get
			{
				return new TSoftObjectPtr<UDataTable>(base.NativePtr + (IntPtr)SCharacterMorphInfo.__PropertyOffset_3, base.MemoryOwner ?? this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)SCharacterMorphInfo.__PropertyOffset_3, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005FA2 RID: 24482
		// (get) Token: 0x06027F0E RID: 163598 RVA: 0x009FE904 File Offset: 0x009FCB04
		// (set) Token: 0x06027F0F RID: 163599 RVA: 0x009FE947 File Offset: 0x009FCB47
		public FSoftClassPath InputComponentClass
		{
			get
			{
				base.FastCheckIsValid();
				FSoftClassPath result;
				if ((result = this._InputComponentClass) == null)
				{
					result = (this._InputComponentClass = new FSoftClassPath(base.NativePtr + (IntPtr)SCharacterMorphInfo.__PropertyOffset_4, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FSoftClassPath.StaticStruct(), base.NativePtr + (IntPtr)SCharacterMorphInfo.__PropertyOffset_4, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005FA3 RID: 24483
		// (get) Token: 0x06027F10 RID: 163600 RVA: 0x009FE968 File Offset: 0x009FCB68
		// (set) Token: 0x06027F11 RID: 163601 RVA: 0x009FE9AB File Offset: 0x009FCBAB
		public TMap<string, float> ComponentFloatParams
		{
			get
			{
				base.FastCheckIsValid();
				TMap<string, float> result;
				if ((result = this._ComponentFloatParams) == null)
				{
					result = (this._ComponentFloatParams = new TMap<string, float>(base.NativePtr + (IntPtr)SCharacterMorphInfo.__PropertyOffset_5, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.ComponentFloatParams.CopyAssign(value);
			}
		}

		// Token: 0x17005FA4 RID: 24484
		// (get) Token: 0x06027F12 RID: 163602 RVA: 0x009FE9BC File Offset: 0x009FCBBC
		// (set) Token: 0x06027F13 RID: 163603 RVA: 0x009FE9FF File Offset: 0x009FCBFF
		public TMap<string, FVector> ComponentVectorParams
		{
			get
			{
				base.FastCheckIsValid();
				TMap<string, FVector> result;
				if ((result = this._ComponentVectorParams) == null)
				{
					result = (this._ComponentVectorParams = new TMap<string, FVector>(base.NativePtr + (IntPtr)SCharacterMorphInfo.__PropertyOffset_6, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.ComponentVectorParams.CopyAssign(value);
			}
		}

		// Token: 0x17005FA5 RID: 24485
		// (get) Token: 0x06027F14 RID: 163604 RVA: 0x009FEA10 File Offset: 0x009FCC10
		// (set) Token: 0x06027F15 RID: 163605 RVA: 0x009FEA53 File Offset: 0x009FCC53
		public TMap<string, string> ComponentStringParams
		{
			get
			{
				base.FastCheckIsValid();
				TMap<string, string> result;
				if ((result = this._ComponentStringParams) == null)
				{
					result = (this._ComponentStringParams = new TMap<string, string>(base.NativePtr + (IntPtr)SCharacterMorphInfo.__PropertyOffset_7, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.ComponentStringParams.CopyAssign(value);
			}
		}

		// Token: 0x17005FA6 RID: 24486
		// (get) Token: 0x06027F16 RID: 163606 RVA: 0x009FEA64 File Offset: 0x009FCC64
		// (set) Token: 0x06027F17 RID: 163607 RVA: 0x009FEAA7 File Offset: 0x009FCCA7
		public TArray<string> MontageSubPathNames
		{
			get
			{
				base.FastCheckIsValid();
				TArray<string> result;
				if ((result = this._MontageSubPathNames) == null)
				{
					result = (this._MontageSubPathNames = new TArray<string>(base.NativePtr + (IntPtr)SCharacterMorphInfo.__PropertyOffset_8, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.MontageSubPathNames.CopyAssign(value);
			}
		}

		// Token: 0x06027F18 RID: 163608 RVA: 0x009FEAB5 File Offset: 0x009FCCB5
		public SCharacterMorphInfo()
		{
		}

		// Token: 0x06027F19 RID: 163609 RVA: 0x009FEAC0 File Offset: 0x009FCCC0
		public SCharacterMorphInfo(int ModelId, TSoftObjectPtr<UPrimaryDataAsset> PartHitEffect, TSoftObjectPtr<UDataTable> DtBaseMovementSetting, TSoftObjectPtr<UDataTable> DtCameraConfig, FSoftClassPath InputComponentClass, TMap<string, float> ComponentFloatParams, TMap<string, FVector> ComponentVectorParams, TMap<string, string> ComponentStringParams, TArray<string> MontageSubPathNames)
		{
			this.ModelId = ModelId;
			this.PartHitEffect = PartHitEffect;
			this.DtBaseMovementSetting = DtBaseMovementSetting;
			this.DtCameraConfig = DtCameraConfig;
			this.InputComponentClass = InputComponentClass;
			this.ComponentFloatParams = ComponentFloatParams;
			this.ComponentVectorParams = ComponentVectorParams;
			this.ComponentStringParams = ComponentStringParams;
			this.MontageSubPathNames = MontageSubPathNames;
		}

		// Token: 0x06027F1A RID: 163610 RVA: 0x009FEB18 File Offset: 0x009FCD18
		protected override IntPtr GetUStructPtr()
		{
			return SCharacterMorphInfo.StaticStruct();
		}

		// Token: 0x06027F1B RID: 163611 RVA: 0x009FEB24 File Offset: 0x009FCD24
		[NullableContext(2)]
		public SCharacterMorphInfo(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06027F1C RID: 163612 RVA: 0x009FEB2E File Offset: 0x009FCD2E
		public SCharacterMorphInfo(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06027F1D RID: 163613 RVA: 0x009FEB39 File Offset: 0x009FCD39
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SCharacterMorphInfo(Pointer, false, true);
		}

		// Token: 0x06027F1E RID: 163614 RVA: 0x009FEB43 File Offset: 0x009FCD43
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SCharacterMorphInfo(Pointer, MemoryOwner);
		}

		// Token: 0x04014F7D RID: 85885
		public const string __ObjectPath = "/Game/Aki/Data/Fight/Struct/SCharacterMorphInfo.SCharacterMorphInfo";

		// Token: 0x04014F7E RID: 85886
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04014F7F RID: 85887
		internal static int __PropertyOffset_0;

		// Token: 0x04014F80 RID: 85888
		internal static int __PropertyOffset_1;

		// Token: 0x04014F81 RID: 85889
		internal static int __PropertyOffset_2;

		// Token: 0x04014F82 RID: 85890
		internal static int __PropertyOffset_3;

		// Token: 0x04014F83 RID: 85891
		internal static int __PropertyOffset_4;

		// Token: 0x04014F84 RID: 85892
		[Nullable(2)]
		private FSoftClassPath _InputComponentClass;

		// Token: 0x04014F85 RID: 85893
		internal static int __PropertyOffset_5;

		// Token: 0x04014F86 RID: 85894
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<string, float> _ComponentFloatParams;

		// Token: 0x04014F87 RID: 85895
		internal static int __PropertyOffset_6;

		// Token: 0x04014F88 RID: 85896
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<string, FVector> _ComponentVectorParams;

		// Token: 0x04014F89 RID: 85897
		internal static int __PropertyOffset_7;

		// Token: 0x04014F8A RID: 85898
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private TMap<string, string> _ComponentStringParams;

		// Token: 0x04014F8B RID: 85899
		internal static int __PropertyOffset_8;

		// Token: 0x04014F8C RID: 85900
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<string> _MontageSubPathNames;
	}
}
