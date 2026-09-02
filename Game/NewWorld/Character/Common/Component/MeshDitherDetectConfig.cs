using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.Character.Common.Component
{
	// Token: 0x02004907 RID: 18695
	[NullableContext(1)]
	[Nullable(0)]
	public class MeshDitherDetectConfig
	{
		// Token: 0x06030DC3 RID: 200131 RVA: 0x00C1A000 File Offset: 0x00C18200
		public MeshDitherDetectConfig(SMeshDitherDetectConfig meshDitherDetectConfig, int id)
		{
			this.Id = id;
			this.Priority = meshDitherDetectConfig.Priority;
			this.BaseBoneName = meshDitherDetectConfig.TraceConfig.BaseBoneName;
			this.TargetBoneName = meshDitherDetectConfig.TraceConfig.TargetBoneName;
			this.BasisBoneName = meshDitherDetectConfig.TraceConfig.BasisBoneName;
			this.CapsuleAdditionRadius = meshDitherDetectConfig.TraceConfig.AdditionCapsuleSize.X;
			this.CapsuleAdditionHeight = meshDitherDetectConfig.TraceConfig.AdditionCapsuleSize.Y;
			Vector capsuleAdditionOffset = this.CapsuleAdditionOffset;
			FVector additionCapsuleOffset = meshDitherDetectConfig.TraceConfig.AdditionCapsuleOffset;
			FVectorDouble fvectorDouble = additionCapsuleOffset;
			capsuleAdditionOffset.DeepCopy(fvectorDouble);
			Rotator capsuleAdditionRotator = this.CapsuleAdditionRotator;
			FRotator additionCapsuleRotator = meshDitherDetectConfig.TraceConfig.AdditionCapsuleRotator;
			capsuleAdditionRotator.DeepCopy(additionCapsuleRotator);
			this.EnableDebug = meshDitherDetectConfig.TraceConfig.Debug;
			this.OverrideDitherConfig = meshDitherDetectConfig.DitherConfig.OverrideDefaultDitherConfig;
			this.StartHideDistance = meshDitherDetectConfig.DitherConfig.StartHideDistance;
			this.CompleteHideDistance = meshDitherDetectConfig.DitherConfig.CompleteHideDistance;
			this.StartDitherValue = meshDitherDetectConfig.DitherConfig.StartDitherValue;
		}

		// Token: 0x0401C13D RID: 115005
		public int Id;

		// Token: 0x0401C13E RID: 115006
		public bool MarkDelete;

		// Token: 0x0401C13F RID: 115007
		public int Priority;

		// Token: 0x0401C140 RID: 115008
		public FName BaseBoneName = Singleton<CharacterNameDefines>.Instance.BIP_001_SPINE;

		// Token: 0x0401C141 RID: 115009
		public FName TargetBoneName = Singleton<CharacterNameDefines>.Instance.BIP_001_NECK;

		// Token: 0x0401C142 RID: 115010
		public FName BasisBoneName = Singleton<CharacterNameDefines>.Instance.BIP_001_SPINE;

		// Token: 0x0401C143 RID: 115011
		public float CapsuleAdditionRadius;

		// Token: 0x0401C144 RID: 115012
		public float CapsuleAdditionHeight;

		// Token: 0x0401C145 RID: 115013
		public Vector CapsuleAdditionOffset = Vector.Create();

		// Token: 0x0401C146 RID: 115014
		public Rotator CapsuleAdditionRotator = Rotator.Create();

		// Token: 0x0401C147 RID: 115015
		public bool EnableDebug;

		// Token: 0x0401C148 RID: 115016
		public bool OverrideDitherConfig;

		// Token: 0x0401C149 RID: 115017
		public float StartHideDistance;

		// Token: 0x0401C14A RID: 115018
		public float CompleteHideDistance;

		// Token: 0x0401C14B RID: 115019
		public float StartDitherValue;
	}
}
