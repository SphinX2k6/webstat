using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Scene.Interaction;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.GamePlay.StaticSceneInteraction
{
	// Token: 0x02003DC8 RID: 15816
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/GamePlay/StaticSceneInteraction/SInteractiveConfig.SInteractiveConfig")]
	[UnrealStructLayout(304, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 304)]
	public class SInteractiveConfig : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06026BA2 RID: 158626 RVA: 0x009E0733 File Offset: 0x009DE933
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SInteractiveConfig._ScriptStructPtr != 0) ? SInteractiveConfig._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/GamePlay/StaticSceneInteraction/SInteractiveConfig.SInteractiveConfig", ref SInteractiveConfig._ScriptStructPtr);
		}

		// Token: 0x170058CC RID: 22732
		// (get) Token: 0x06026BA3 RID: 158627 RVA: 0x009E0758 File Offset: 0x009DE958
		// (set) Token: 0x06026BA4 RID: 158628 RVA: 0x009E079B File Offset: 0x009DE99B
		public TArray<AStaticMeshActor> ReferActors
		{
			get
			{
				base.FastCheckIsValid();
				TArray<AStaticMeshActor> result;
				if ((result = this._ReferActors) == null)
				{
					result = (this._ReferActors = new TArray<AStaticMeshActor>(base.NativePtr + (IntPtr)SInteractiveConfig.__PropertyOffset_0, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.ReferActors.CopyAssign(value);
			}
		}

		// Token: 0x170058CD RID: 22733
		// (get) Token: 0x06026BA5 RID: 158629 RVA: 0x009E07A9 File Offset: 0x009DE9A9
		// (set) Token: 0x06026BA6 RID: 158630 RVA: 0x009E07B9 File Offset: 0x009DE9B9
		public unsafe int WuYinQuState
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SInteractiveConfig.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SInteractiveConfig.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x170058CE RID: 22734
		// (get) Token: 0x06026BA7 RID: 158631 RVA: 0x009E07CA File Offset: 0x009DE9CA
		// (set) Token: 0x06026BA8 RID: 158632 RVA: 0x009E07E9 File Offset: 0x009DE9E9
		public TSoftObjectPtr<ItemMaterialControllerActorData> MaterialData
		{
			get
			{
				return new TSoftObjectPtr<ItemMaterialControllerActorData>(base.NativePtr + (IntPtr)SInteractiveConfig.__PropertyOffset_2, base.MemoryOwner ?? this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)SInteractiveConfig.__PropertyOffset_2, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x170058CF RID: 22735
		// (get) Token: 0x06026BA9 RID: 158633 RVA: 0x009E0810 File Offset: 0x009DEA10
		// (set) Token: 0x06026BAA RID: 158634 RVA: 0x009E0853 File Offset: 0x009DEA53
		public TArray<AActor> HideActors
		{
			get
			{
				base.FastCheckIsValid();
				TArray<AActor> result;
				if ((result = this._HideActors) == null)
				{
					result = (this._HideActors = new TArray<AActor>(base.NativePtr + (IntPtr)SInteractiveConfig.__PropertyOffset_3, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.HideActors.CopyAssign(value);
			}
		}

		// Token: 0x170058D0 RID: 22736
		// (get) Token: 0x06026BAB RID: 158635 RVA: 0x009E0864 File Offset: 0x009DEA64
		// (set) Token: 0x06026BAC RID: 158636 RVA: 0x009E08A7 File Offset: 0x009DEAA7
		public TArray<AActor> ShowActors
		{
			get
			{
				base.FastCheckIsValid();
				TArray<AActor> result;
				if ((result = this._ShowActors) == null)
				{
					result = (this._ShowActors = new TArray<AActor>(base.NativePtr + (IntPtr)SInteractiveConfig.__PropertyOffset_4, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.ShowActors.CopyAssign(value);
			}
		}

		// Token: 0x170058D1 RID: 22737
		// (get) Token: 0x06026BAD RID: 158637 RVA: 0x009E08B8 File Offset: 0x009DEAB8
		// (set) Token: 0x06026BAE RID: 158638 RVA: 0x009E08FB File Offset: 0x009DEAFB
		public TArray<SInteractivePPVConfig> PPVConfig
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SInteractivePPVConfig> result;
				if ((result = this._PPVConfig) == null)
				{
					result = (this._PPVConfig = new TArray<SInteractivePPVConfig>(base.NativePtr + (IntPtr)SInteractiveConfig.__PropertyOffset_5, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.PPVConfig.CopyAssign(value);
			}
		}

		// Token: 0x170058D2 RID: 22738
		// (get) Token: 0x06026BAF RID: 158639 RVA: 0x009E090C File Offset: 0x009DEB0C
		// (set) Token: 0x06026BB0 RID: 158640 RVA: 0x009E094F File Offset: 0x009DEB4F
		public SInteractiveLevelSequenceConfig LevelSequenceConfig
		{
			get
			{
				base.FastCheckIsValid();
				SInteractiveLevelSequenceConfig result;
				if ((result = this._LevelSequenceConfig) == null)
				{
					result = (this._LevelSequenceConfig = new SInteractiveLevelSequenceConfig(base.NativePtr + (IntPtr)SInteractiveConfig.__PropertyOffset_6, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SInteractiveLevelSequenceConfig.StaticStruct(), base.NativePtr + (IntPtr)SInteractiveConfig.__PropertyOffset_6, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170058D3 RID: 22739
		// (get) Token: 0x06026BB1 RID: 158641 RVA: 0x009E0970 File Offset: 0x009DEB70
		// (set) Token: 0x06026BB2 RID: 158642 RVA: 0x009E09B3 File Offset: 0x009DEBB3
		public SSceneInteractionMaterialParameterCollection MPCParams
		{
			get
			{
				base.FastCheckIsValid();
				SSceneInteractionMaterialParameterCollection result;
				if ((result = this._MPCParams) == null)
				{
					result = (this._MPCParams = new SSceneInteractionMaterialParameterCollection(base.NativePtr + (IntPtr)SInteractiveConfig.__PropertyOffset_7, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SSceneInteractionMaterialParameterCollection.StaticStruct(), base.NativePtr + (IntPtr)SInteractiveConfig.__PropertyOffset_7, value.NativePtr, 1, false);
			}
		}

		// Token: 0x06026BB3 RID: 158643 RVA: 0x009E09D4 File Offset: 0x009DEBD4
		public SInteractiveConfig()
		{
		}

		// Token: 0x06026BB4 RID: 158644 RVA: 0x009E09DC File Offset: 0x009DEBDC
		public SInteractiveConfig(TArray<AStaticMeshActor> ReferActors, int WuYinQuState, TSoftObjectPtr<ItemMaterialControllerActorData> MaterialData, TArray<AActor> HideActors, TArray<AActor> ShowActors, TArray<SInteractivePPVConfig> PPVConfig, SInteractiveLevelSequenceConfig LevelSequenceConfig, SSceneInteractionMaterialParameterCollection MPCParams)
		{
			this.ReferActors = ReferActors;
			this.WuYinQuState = WuYinQuState;
			this.MaterialData = MaterialData;
			this.HideActors = HideActors;
			this.ShowActors = ShowActors;
			this.PPVConfig = PPVConfig;
			this.LevelSequenceConfig = LevelSequenceConfig;
			this.MPCParams = MPCParams;
		}

		// Token: 0x06026BB5 RID: 158645 RVA: 0x009E0A2C File Offset: 0x009DEC2C
		protected override IntPtr GetUStructPtr()
		{
			return SInteractiveConfig.StaticStruct();
		}

		// Token: 0x06026BB6 RID: 158646 RVA: 0x009E0A38 File Offset: 0x009DEC38
		[NullableContext(2)]
		public SInteractiveConfig(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06026BB7 RID: 158647 RVA: 0x009E0A42 File Offset: 0x009DEC42
		public SInteractiveConfig(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06026BB8 RID: 158648 RVA: 0x009E0A4D File Offset: 0x009DEC4D
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SInteractiveConfig(Pointer, false, true);
		}

		// Token: 0x06026BB9 RID: 158649 RVA: 0x009E0A57 File Offset: 0x009DEC57
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SInteractiveConfig(Pointer, MemoryOwner);
		}

		// Token: 0x04014326 RID: 82726
		public const string __ObjectPath = "/Game/Aki/GamePlay/StaticSceneInteraction/SInteractiveConfig.SInteractiveConfig";

		// Token: 0x04014327 RID: 82727
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04014328 RID: 82728
		internal static int __PropertyOffset_0;

		// Token: 0x04014329 RID: 82729
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<AStaticMeshActor> _ReferActors;

		// Token: 0x0401432A RID: 82730
		internal static int __PropertyOffset_1;

		// Token: 0x0401432B RID: 82731
		internal static int __PropertyOffset_2;

		// Token: 0x0401432C RID: 82732
		internal static int __PropertyOffset_3;

		// Token: 0x0401432D RID: 82733
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<AActor> _HideActors;

		// Token: 0x0401432E RID: 82734
		internal static int __PropertyOffset_4;

		// Token: 0x0401432F RID: 82735
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<AActor> _ShowActors;

		// Token: 0x04014330 RID: 82736
		internal static int __PropertyOffset_5;

		// Token: 0x04014331 RID: 82737
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<SInteractivePPVConfig> _PPVConfig;

		// Token: 0x04014332 RID: 82738
		internal static int __PropertyOffset_6;

		// Token: 0x04014333 RID: 82739
		[Nullable(2)]
		private SInteractiveLevelSequenceConfig _LevelSequenceConfig;

		// Token: 0x04014334 RID: 82740
		internal static int __PropertyOffset_7;

		// Token: 0x04014335 RID: 82741
		[Nullable(2)]
		private SSceneInteractionMaterialParameterCollection _MPCParams;
	}
}
