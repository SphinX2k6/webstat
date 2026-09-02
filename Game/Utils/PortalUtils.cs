using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Effect.Portal;
using CSharpScript.Game.NewWorld.SceneItem.Model;
using UnrealEngine;

namespace CSharpScript.Game.Utils
{
	// Token: 0x020046FA RID: 18170
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class PortalUtils : Singleton<PortalUtils>
	{
		// Token: 0x0602F3E2 RID: 193506 RVA: 0x00B33EE4 File Offset: 0x00B320E4
		static PortalUtils()
		{
			FQuat fquat = new FQuat(ref Vector.ZAxisVector, 3.1415927f);
			PortalUtils.PortalRotateTf = new FTransformDouble(ref fquat);
			PortalUtils.DebugColorCyanInstance = null;
			PortalUtils.DebugColorGreenInstance = null;
			PortalUtils.DebugColorOrangeInstance = null;
			PortalUtils.DebugColorLightBlueInstance = null;
			PortalUtils.DebugColorRedInstance = null;
			PortalUtils.DebugColorYellowInstance = null;
			PortalUtils.DebugColorMintGreenInstance = null;
			StaticVariableRegister.RegisterAndExecute(new Action(PortalUtils.CreateStaticDefaultValue), new Action(PortalUtils.ResetStaticDefaultValue));
		}

		// Token: 0x0602F3E3 RID: 193507 RVA: 0x00B33F77 File Offset: 0x00B32177
		public new static void CreateStaticDefaultValue()
		{
			PortalUtils.TempVectors = new List<Vector>();
		}

		// Token: 0x0602F3E4 RID: 193508 RVA: 0x00B33F84 File Offset: 0x00B32184
		public new static void ResetStaticDefaultValue()
		{
			PortalUtils.TempVectors = null;
			PortalUtils.DebugColorCyanInstance = null;
			PortalUtils.DebugColorGreenInstance = null;
			PortalUtils.DebugColorOrangeInstance = null;
			PortalUtils.DebugColorLightBlueInstance = null;
			PortalUtils.DebugColorRedInstance = null;
			PortalUtils.DebugColorYellowInstance = null;
			PortalUtils.DebugColorMintGreenInstance = null;
		}

		// Token: 0x17008148 RID: 33096
		// (get) Token: 0x0602F3E5 RID: 193509 RVA: 0x00B33FE4 File Offset: 0x00B321E4
		private static FLinearColor DebugColorCyan
		{
			get
			{
				FLinearColor valueOrDefault = PortalUtils.DebugColorCyanInstance.GetValueOrDefault();
				if (PortalUtils.DebugColorCyanInstance == null)
				{
					valueOrDefault = new FLinearColor(0f, 1f, 1f, 1f);
					PortalUtils.DebugColorCyanInstance = new FLinearColor?(valueOrDefault);
					return valueOrDefault;
				}
				return valueOrDefault;
			}
		}

		// Token: 0x17008149 RID: 33097
		// (get) Token: 0x0602F3E6 RID: 193510 RVA: 0x00B34034 File Offset: 0x00B32234
		private static FLinearColor DebugColorGreen
		{
			get
			{
				FLinearColor valueOrDefault = PortalUtils.DebugColorGreenInstance.GetValueOrDefault();
				if (PortalUtils.DebugColorGreenInstance == null)
				{
					valueOrDefault = new FLinearColor(0f, 1f, 0f, 1f);
					PortalUtils.DebugColorGreenInstance = new FLinearColor?(valueOrDefault);
					return valueOrDefault;
				}
				return valueOrDefault;
			}
		}

		// Token: 0x1700814A RID: 33098
		// (get) Token: 0x0602F3E7 RID: 193511 RVA: 0x00B34084 File Offset: 0x00B32284
		private static FLinearColor DebugColorOrange
		{
			get
			{
				FLinearColor valueOrDefault = PortalUtils.DebugColorOrangeInstance.GetValueOrDefault();
				if (PortalUtils.DebugColorOrangeInstance == null)
				{
					valueOrDefault = new FLinearColor(1f, 0.5f, 0f, 1f);
					PortalUtils.DebugColorOrangeInstance = new FLinearColor?(valueOrDefault);
					return valueOrDefault;
				}
				return valueOrDefault;
			}
		}

		// Token: 0x1700814B RID: 33099
		// (get) Token: 0x0602F3E8 RID: 193512 RVA: 0x00B340D4 File Offset: 0x00B322D4
		private static FLinearColor DebugColorLightBlue
		{
			get
			{
				FLinearColor valueOrDefault = PortalUtils.DebugColorLightBlueInstance.GetValueOrDefault();
				if (PortalUtils.DebugColorLightBlueInstance == null)
				{
					valueOrDefault = new FLinearColor(0.2f, 0.8f, 1f, 1f);
					PortalUtils.DebugColorLightBlueInstance = new FLinearColor?(valueOrDefault);
					return valueOrDefault;
				}
				return valueOrDefault;
			}
		}

		// Token: 0x1700814C RID: 33100
		// (get) Token: 0x0602F3E9 RID: 193513 RVA: 0x00B34124 File Offset: 0x00B32324
		private static FLinearColor DebugColorRed
		{
			get
			{
				FLinearColor valueOrDefault = PortalUtils.DebugColorRedInstance.GetValueOrDefault();
				if (PortalUtils.DebugColorRedInstance == null)
				{
					valueOrDefault = new FLinearColor(1f, 0.3f, 0.3f, 1f);
					PortalUtils.DebugColorRedInstance = new FLinearColor?(valueOrDefault);
					return valueOrDefault;
				}
				return valueOrDefault;
			}
		}

		// Token: 0x1700814D RID: 33101
		// (get) Token: 0x0602F3EA RID: 193514 RVA: 0x00B34174 File Offset: 0x00B32374
		private static FLinearColor DebugColorYellow
		{
			get
			{
				FLinearColor valueOrDefault = PortalUtils.DebugColorYellowInstance.GetValueOrDefault();
				if (PortalUtils.DebugColorYellowInstance == null)
				{
					valueOrDefault = new FLinearColor(1f, 1f, 0f, 1f);
					PortalUtils.DebugColorYellowInstance = new FLinearColor?(valueOrDefault);
					return valueOrDefault;
				}
				return valueOrDefault;
			}
		}

		// Token: 0x1700814E RID: 33102
		// (get) Token: 0x0602F3EB RID: 193515 RVA: 0x00B341C4 File Offset: 0x00B323C4
		private static FLinearColor DebugColorMintGreen
		{
			get
			{
				FLinearColor valueOrDefault = PortalUtils.DebugColorMintGreenInstance.GetValueOrDefault();
				if (PortalUtils.DebugColorMintGreenInstance == null)
				{
					valueOrDefault = new FLinearColor(0f, 1f, 0.2f, 1f);
					PortalUtils.DebugColorMintGreenInstance = new FLinearColor?(valueOrDefault);
					return valueOrDefault;
				}
				return valueOrDefault;
			}
		}

		// Token: 0x1700814F RID: 33103
		// (get) Token: 0x0602F3EC RID: 193516 RVA: 0x00B34211 File Offset: 0x00B32411
		private static Vector TempTargetTfUpVec
		{
			get
			{
				PortalUtils.EnsureTempVectors();
				return PortalUtils.TempVectors[0];
			}
		}

		// Token: 0x17008150 RID: 33104
		// (get) Token: 0x0602F3ED RID: 193517 RVA: 0x00B34223 File Offset: 0x00B32423
		private static Vector TempMappedForwardVec
		{
			get
			{
				PortalUtils.EnsureTempVectors();
				return PortalUtils.TempVectors[1];
			}
		}

		// Token: 0x17008151 RID: 33105
		// (get) Token: 0x0602F3EE RID: 193518 RVA: 0x00B34235 File Offset: 0x00B32435
		private static Vector TempMappedRightVec
		{
			get
			{
				PortalUtils.EnsureTempVectors();
				return PortalUtils.TempVectors[2];
			}
		}

		// Token: 0x17008152 RID: 33106
		// (get) Token: 0x0602F3EF RID: 193519 RVA: 0x00B34247 File Offset: 0x00B32447
		private static Vector TempCrossResult
		{
			get
			{
				PortalUtils.EnsureTempVectors();
				return PortalUtils.TempVectors[3];
			}
		}

		// Token: 0x17008153 RID: 33107
		// (get) Token: 0x0602F3F0 RID: 193520 RVA: 0x00B34259 File Offset: 0x00B32459
		private static Vector TempMappedOffsetVelocity
		{
			get
			{
				PortalUtils.EnsureTempVectors();
				return PortalUtils.TempVectors[4];
			}
		}

		// Token: 0x17008154 RID: 33108
		// (get) Token: 0x0602F3F1 RID: 193521 RVA: 0x00B3426B File Offset: 0x00B3246B
		private static Vector TempOffsetUpProjection
		{
			get
			{
				PortalUtils.EnsureTempVectors();
				return PortalUtils.TempVectors[5];
			}
		}

		// Token: 0x17008155 RID: 33109
		// (get) Token: 0x0602F3F2 RID: 193522 RVA: 0x00B3427D File Offset: 0x00B3247D
		private static Vector TempSourceForwardVec
		{
			get
			{
				PortalUtils.EnsureTempVectors();
				return PortalUtils.TempVectors[6];
			}
		}

		// Token: 0x17008156 RID: 33110
		// (get) Token: 0x0602F3F3 RID: 193523 RVA: 0x00B3428F File Offset: 0x00B3248F
		private static Vector TempSourceRightVec
		{
			get
			{
				PortalUtils.EnsureTempVectors();
				return PortalUtils.TempVectors[7];
			}
		}

		// Token: 0x17008157 RID: 33111
		// (get) Token: 0x0602F3F4 RID: 193524 RVA: 0x00B342A1 File Offset: 0x00B324A1
		private static Vector TempGroundFixGravityDir
		{
			get
			{
				PortalUtils.EnsureTempVectors();
				return PortalUtils.TempVectors[8];
			}
		}

		// Token: 0x17008158 RID: 33112
		// (get) Token: 0x0602F3F5 RID: 193525 RVA: 0x00B342B3 File Offset: 0x00B324B3
		private static Vector TempGroundFixPortalOutLocation
		{
			get
			{
				PortalUtils.EnsureTempVectors();
				return PortalUtils.TempVectors[9];
			}
		}

		// Token: 0x17008159 RID: 33113
		// (get) Token: 0x0602F3F6 RID: 193526 RVA: 0x00B342C6 File Offset: 0x00B324C6
		private static Vector TempGroundFixMapToLocation
		{
			get
			{
				PortalUtils.EnsureTempVectors();
				return PortalUtils.TempVectors[10];
			}
		}

		// Token: 0x1700815A RID: 33114
		// (get) Token: 0x0602F3F7 RID: 193527 RVA: 0x00B342D9 File Offset: 0x00B324D9
		private static Vector TempGroundFixProjectedOffset
		{
			get
			{
				PortalUtils.EnsureTempVectors();
				return PortalUtils.TempVectors[11];
			}
		}

		// Token: 0x1700815B RID: 33115
		// (get) Token: 0x0602F3F8 RID: 193528 RVA: 0x00B342EC File Offset: 0x00B324EC
		private static Vector TempGroundFixGravityProjection
		{
			get
			{
				PortalUtils.EnsureTempVectors();
				return PortalUtils.TempVectors[12];
			}
		}

		// Token: 0x1700815C RID: 33116
		// (get) Token: 0x0602F3F9 RID: 193529 RVA: 0x00B342FF File Offset: 0x00B324FF
		private static Vector TempGroundFixTraceStart
		{
			get
			{
				PortalUtils.EnsureTempVectors();
				return PortalUtils.TempVectors[13];
			}
		}

		// Token: 0x1700815D RID: 33117
		// (get) Token: 0x0602F3FA RID: 193530 RVA: 0x00B34312 File Offset: 0x00B32512
		private static Vector TempGroundFixTraceEnd
		{
			get
			{
				PortalUtils.EnsureTempVectors();
				return PortalUtils.TempVectors[14];
			}
		}

		// Token: 0x1700815E RID: 33118
		// (get) Token: 0x0602F3FB RID: 193531 RVA: 0x00B34325 File Offset: 0x00B32525
		private static Vector TempGroundFixHitPoint
		{
			get
			{
				PortalUtils.EnsureTempVectors();
				return PortalUtils.TempVectors[15];
			}
		}

		// Token: 0x0602F3FC RID: 193532 RVA: 0x00B34338 File Offset: 0x00B32538
		private static void EnsureTempVectors()
		{
			if (PortalUtils.TempVectors == null)
			{
				PortalUtils.TempVectors = new List<Vector>();
			}
			while (PortalUtils.TempVectors.Count < 16)
			{
				PortalUtils.TempVectors.Add(Vector.Create());
			}
		}

		// Token: 0x0602F3FD RID: 193533 RVA: 0x00B3436A File Offset: 0x00B3256A
		private static bool IsPortalDebugEnabled()
		{
			return false;
		}

		// Token: 0x0602F3FE RID: 193534 RVA: 0x00B3436D File Offset: 0x00B3256D
		private static void DrawDebugSphere(FVectorDouble position, FLinearColor color, float radius = 18f)
		{
			UKismetSystemLibrary.D_DrawDebugSphere(GlobalData.World, position, radius, 12, new FLinearColor?(color), 5f, 2f);
		}

		// Token: 0x0602F3FF RID: 193535 RVA: 0x00B3438D File Offset: 0x00B3258D
		private static void DrawDebugArrow(FVectorDouble start, FVectorDouble end, FLinearColor color)
		{
			UKismetSystemLibrary.D_DrawDebugArrow(GlobalData.World, start, end, 24f, color, 5f, 2f);
		}

		// Token: 0x0602F400 RID: 193536 RVA: 0x00B343AC File Offset: 0x00B325AC
		private static void DrawDebugDirection(FVectorDouble start, IVector direction, FLinearColor color, float scale = 120f)
		{
			FVectorDouble end = new FVectorDouble(start.X + direction.X * (double)scale, start.Y + direction.Y * (double)scale, start.Z + direction.Z * (double)scale);
			PortalUtils.DrawDebugArrow(start, end, color);
		}

		// Token: 0x0602F401 RID: 193537 RVA: 0x00B343F8 File Offset: 0x00B325F8
		private static void DrawDebugTransform(FTransformDouble transform, float scale = 80f)
		{
			UKismetSystemLibrary.D_DrawDebugCoordinateSystem(GlobalData.World, transform.GetLocation(), transform.Rotator(), scale, 5f, 2f);
		}

		// Token: 0x0602F402 RID: 193538 RVA: 0x00B3441D File Offset: 0x00B3261D
		private static void DrawDebugLine(FVectorDouble start, FVectorDouble end, FLinearColor color)
		{
			UKismetSystemLibrary.D_DrawDebugLine(GlobalData.World, start, end, color, 5f, 2f);
		}

		// Token: 0x0602F403 RID: 193539 RVA: 0x00B34438 File Offset: 0x00B32638
		private static void DrawDebugVecMapping(Vector mapFromVec, FTransformDouble portalInTf, FTransformDouble portalOutTf, FVectorDouble reversedRelVec, FVectorDouble mapToVec)
		{
			if (!PortalUtils.IsPortalDebugEnabled())
			{
				return;
			}
			FVectorDouble location = portalInTf.GetLocation();
			FVectorDouble location2 = portalOutTf.GetLocation();
			FVectorDouble fvectorDouble = portalInTf.TransformVector(reversedRelVec);
			PortalUtils.DrawDebugDirection(location, mapFromVec, PortalUtils.DebugColorCyan, 120f);
			PortalUtils.DrawDebugArrow(location, new FVectorDouble(location.X + fvectorDouble.X, location.Y + fvectorDouble.Y, location.Z + fvectorDouble.Z), PortalUtils.DebugColorYellow);
			PortalUtils.DrawDebugArrow(location2, new FVectorDouble(location2.X + mapToVec.X, location2.Y + mapToVec.Y, location2.Z + mapToVec.Z), PortalUtils.DebugColorGreen);
		}

		// Token: 0x0602F404 RID: 193540 RVA: 0x00B344EC File Offset: 0x00B326EC
		[return: Nullable(2)]
		public Vector GetMappingPosToOtherPortal(Vector mapFromPos, long portalId, bool bA2B, Vector outPos)
		{
			if (portalId == 0L)
			{
				outPos.DeepCopy(mapFromPos);
				return outPos;
			}
			BP_Portal_C portal = ModelBase<PortalModel>.Instance.GetPortal(portalId);
			if (portal == null || !portal.Portal1Enable || !portal.Portal2Enable)
			{
				return null;
			}
			FTransformDouble portalOutTf;
			FTransformDouble portalInTf;
			if (!bA2B)
			{
				FTransformDouble portalWorldTransform = portal.PortalWorldTransform2;
				FTransformDouble ftransformDouble = portal.PortalWorldTransform1;
				portalOutTf = ftransformDouble;
				portalInTf = portalWorldTransform;
			}
			else
			{
				FTransformDouble portalWorldTransform2 = portal.PortalWorldTransform1;
				FTransformDouble ftransformDouble = portal.PortalWorldTransform2;
				portalOutTf = ftransformDouble;
				portalInTf = portalWorldTransform2;
			}
			return this.GetMappingPosByPortalTransform(mapFromPos, portalInTf, portalOutTf, outPos);
		}

		// Token: 0x0602F405 RID: 193541 RVA: 0x00B3455C File Offset: 0x00B3275C
		public Vector GetMappingPosByPortalTransform(Vector mapFromPos, FTransformDouble portalInTf, FTransformDouble portalOutTf, Vector outPos)
		{
			FVectorDouble fvectorDouble = mapFromPos.ToUeVector(false);
			FVectorDouble fvectorDouble2 = portalInTf.InverseTransformPosition(fvectorDouble);
			FVectorDouble fvectorDouble3 = PortalUtils.PortalRotateTf.TransformPosition(fvectorDouble2);
			FVectorDouble fvectorDouble4 = portalOutTf.TransformPosition(fvectorDouble3);
			outPos.DeepCopy(fvectorDouble4);
			return outPos;
		}

		// Token: 0x0602F406 RID: 193542 RVA: 0x00B345A0 File Offset: 0x00B327A0
		public Vector GetMappingVecByPortalTransform(Vector mapFromVec, FTransformDouble portalInTf, FTransformDouble portalOutTf, Vector outVec)
		{
			FVectorDouble fvectorDouble = mapFromVec.ToUeVector(false);
			FVectorDouble fvectorDouble2 = portalInTf.InverseTransformVector(fvectorDouble);
			FVectorDouble reversedRelVec = PortalUtils.PortalRotateTf.TransformVector(fvectorDouble2);
			FVectorDouble mapToVec = portalOutTf.TransformVector(reversedRelVec);
			if (PortalUtils.IsPortalDebugEnabled())
			{
				PortalUtils.DrawDebugVecMapping(mapFromVec, portalInTf, portalOutTf, reversedRelVec, mapToVec);
			}
			outVec.DeepCopy(mapToVec);
			return outVec;
		}

		// Token: 0x0602F407 RID: 193543 RVA: 0x00B345F4 File Offset: 0x00B327F4
		public FTransformDouble? GetMappingTransformToOtherPortal(FTransformDouble mapFromTf, long portalId, bool bA2B)
		{
			if (portalId == 0L)
			{
				return new FTransformDouble?(mapFromTf);
			}
			BP_Portal_C portal = ModelBase<PortalModel>.Instance.GetPortal(portalId);
			if (portal == null || !portal.Portal1Enable || !portal.Portal2Enable)
			{
				return null;
			}
			FTransformDouble portalOutTf;
			FTransformDouble portalInTf;
			if (!bA2B)
			{
				FTransformDouble portalWorldTransform = portal.PortalWorldTransform2;
				FTransformDouble ftransformDouble = portal.PortalWorldTransform1;
				portalOutTf = ftransformDouble;
				portalInTf = portalWorldTransform;
			}
			else
			{
				FTransformDouble portalWorldTransform2 = portal.PortalWorldTransform1;
				FTransformDouble ftransformDouble = portal.PortalWorldTransform2;
				portalOutTf = ftransformDouble;
				portalInTf = portalWorldTransform2;
			}
			return new FTransformDouble?(this.GetMappingTransformByPortalTransform(mapFromTf, portalInTf, portalOutTf));
		}

		// Token: 0x0602F408 RID: 193544 RVA: 0x00B34670 File Offset: 0x00B32870
		public FTransformDouble GetMappingTransformByPortalTransform(FTransformDouble mapFromTf, FTransformDouble portalInTf, FTransformDouble portalOutTf)
		{
			FTransformDouble relativeTransform = mapFromTf.GetRelativeTransform(portalInTf);
			FTransformDouble ftransformDouble = relativeTransform * portalOutTf;
			if (PortalUtils.IsPortalDebugEnabled())
			{
				PortalUtils.DrawDebugTransform(portalInTf, 80f);
				PortalUtils.DrawDebugTransform(portalOutTf, 80f);
				PortalUtils.DrawDebugTransform(mapFromTf, 60f);
				PortalUtils.DrawDebugTransform(ftransformDouble, 100f);
				PortalUtils.DrawDebugArrow(mapFromTf.GetLocation(), ftransformDouble.GetLocation(), PortalUtils.DebugColorGreen);
			}
			return ftransformDouble;
		}

		// Token: 0x0602F409 RID: 193545 RVA: 0x00B346E0 File Offset: 0x00B328E0
		[NullableContext(2)]
		public FTransformDouble? GetMappingOffsetTransformToOtherPortal(FTransformDouble mapFromTf, long portalId, bool bA2B, IVector mapFromOffsetDir = null, float offset = 0f, bool enableGroundFix = false)
		{
			if (portalId == 0L)
			{
				return new FTransformDouble?(mapFromTf);
			}
			BP_Portal_C portal = ModelBase<PortalModel>.Instance.GetPortal(portalId);
			if (portal == null || !portal.Portal1Enable || !portal.Portal2Enable)
			{
				return null;
			}
			FTransformDouble ftransformDouble2;
			FTransformDouble ftransformDouble3;
			if (!bA2B)
			{
				FTransformDouble portalWorldTransform = portal.PortalWorldTransform2;
				FTransformDouble ftransformDouble = portal.PortalWorldTransform1;
				ftransformDouble2 = ftransformDouble;
				ftransformDouble3 = portalWorldTransform;
			}
			else
			{
				FTransformDouble portalWorldTransform2 = portal.PortalWorldTransform1;
				FTransformDouble ftransformDouble = portal.PortalWorldTransform2;
				ftransformDouble2 = ftransformDouble;
				ftransformDouble3 = portalWorldTransform2;
			}
			return this.GetMappingOffsetTransformByPortalTransform(mapFromTf, ftransformDouble3, ftransformDouble2, null, mapFromOffsetDir, offset, enableGroundFix);
		}

		// Token: 0x0602F40A RID: 193546 RVA: 0x00B34760 File Offset: 0x00B32960
		[NullableContext(2)]
		public FTransformDouble? GetMappingOffsetTransformByPortalTransform(in FTransformDouble mapFromTf, in FTransformDouble portalInTf, in FTransformDouble portalOutTf, IVector portalOutGravityDirect = null, IVector mapFromOffsetDir = null, float offset = 0f, bool enableGroundFix = false)
		{
			if (portalOutGravityDirect == null)
			{
				portalOutGravityDirect = Vector.DownVectorProxy;
			}
			FTransformDouble mappingTransformByPortalTransform = this.GetMappingTransformByPortalTransform(mapFromTf, portalInTf, portalOutTf);
			Quat quat = Quat.Create(mappingTransformByPortalTransform.GetRotation());
			Vector tempTargetTfUpVec = PortalUtils.TempTargetTfUpVec;
			tempTargetTfUpVec.FromConfigVector(portalOutGravityDirect);
			tempTargetTfUpVec.UnaryNegation(tempTargetTfUpVec);
			tempTargetTfUpVec.GetSafeNormal(tempTargetTfUpVec, 9.99999993922529E-09);
			Vector tempMappedForwardVec = PortalUtils.TempMappedForwardVec;
			Vector tempSourceForwardVec = PortalUtils.TempSourceForwardVec;
			Quat.Create(mapFromTf.GetRotation()).GetForwardVector(tempSourceForwardVec);
			this.GetMappingVecByPortalTransform(tempSourceForwardVec, portalInTf, portalOutTf, tempMappedForwardVec);
			tempMappedForwardVec.GetSafeNormal(tempMappedForwardVec, 9.99999993922529E-09);
			Vector tempMappedRightVec = PortalUtils.TempMappedRightVec;
			Vector tempSourceRightVec = PortalUtils.TempSourceRightVec;
			Quat.Create(mapFromTf.GetRotation()).GetRightVector(tempSourceRightVec);
			this.GetMappingVecByPortalTransform(tempSourceRightVec, portalInTf, portalOutTf, tempMappedRightVec);
			tempMappedRightVec.GetSafeNormal(tempMappedRightVec, 9.99999993922529E-09);
			Vector tempCrossResult = PortalUtils.TempCrossResult;
			tempTargetTfUpVec.CrossProduct(tempMappedForwardVec, tempCrossResult);
			double num = tempCrossResult.SizeSquared();
			tempTargetTfUpVec.CrossProduct(tempMappedRightVec, tempCrossResult);
			double num2 = tempCrossResult.SizeSquared();
			if (num > num2)
			{
				Singleton<MathUtils>.Instance.LookRotationUpFirst(tempMappedForwardVec, tempTargetTfUpVec, quat);
			}
			else
			{
				Singleton<MathUtils>.Instance.LookRotationUpFirst(tempMappedRightVec, tempTargetTfUpVec, quat);
				Vector tempCrossResult2 = PortalUtils.TempCrossResult;
				quat.GetForwardVector(tempCrossResult2);
				Vector forward = tempCrossResult2.CrossProductEqual(tempTargetTfUpVec);
				Singleton<MathUtils>.Instance.LookRotationUpFirst(forward, tempTargetTfUpVec, quat);
			}
			FQuat fquat = quat.ToUeQuat();
			mappingTransformByPortalTransform.SetRotation(fquat);
			if (mapFromOffsetDir != null && offset != 0f)
			{
				Vector tempMappedOffsetVelocity = PortalUtils.TempMappedOffsetVelocity;
				Singleton<MathUtils>.Instance.CommonTempVector.FromUeVector(mapFromOffsetDir);
				this.GetMappingVecByPortalTransform(Singleton<MathUtils>.Instance.CommonTempVector, portalInTf, portalOutTf, tempMappedOffsetVelocity);
				Vector tempOffsetUpProjection = PortalUtils.TempOffsetUpProjection;
				tempTargetTfUpVec.Multiply(tempMappedOffsetVelocity.DotProduct(tempTargetTfUpVec), tempOffsetUpProjection);
				tempMappedOffsetVelocity.Subtraction(tempOffsetUpProjection, tempMappedOffsetVelocity);
				tempMappedOffsetVelocity.GetSafeNormal(tempMappedOffsetVelocity, 9.99999993922529E-09);
				Vector vector = tempMappedOffsetVelocity.IsNearlyZero(9.999999747378752E-05) ? tempMappedForwardVec : tempMappedOffsetVelocity;
				FVectorDouble fvectorDouble = vector.Multiply((double)offset, PortalUtils.TempOffsetUpProjection).ToUeVector(false);
				FVectorDouble fvectorDouble2 = new FVectorDouble(fvectorDouble.X, fvectorDouble.Y, fvectorDouble.Z);
				mappingTransformByPortalTransform.AddToTranslation(fvectorDouble2);
				if (PortalUtils.IsPortalDebugEnabled())
				{
					FVectorDouble location = mappingTransformByPortalTransform.GetLocation();
					PortalUtils.DrawDebugDirection(new FVectorDouble(location.X - fvectorDouble.X, location.Y - fvectorDouble.Y, location.Z - fvectorDouble.Z), vector, PortalUtils.DebugColorOrange, 120f);
					PortalUtils.DrawDebugSphere(location, PortalUtils.DebugColorOrange, 22f);
				}
			}
			if (enableGroundFix)
			{
				PortalUtils.TryFixUndergroundByProjectedGravityColumn(ref mappingTransformByPortalTransform, portalOutTf, portalOutGravityDirect);
			}
			return new FTransformDouble?(mappingTransformByPortalTransform);
		}

		// Token: 0x0602F40B RID: 193547 RVA: 0x00B34A2C File Offset: 0x00B32C2C
		private static void TryFixUndergroundByProjectedGravityColumn(ref FTransformDouble mapToTf, FTransformDouble portalOutTf, IVector portalOutGravityDirect)
		{
			Vector tempGroundFixGravityDir = PortalUtils.TempGroundFixGravityDir;
			tempGroundFixGravityDir.FromConfigVector(portalOutGravityDirect);
			if (!tempGroundFixGravityDir.Normalize(9.99999993922529E-09))
			{
				return;
			}
			Vector tempGroundFixPortalOutLocation = PortalUtils.TempGroundFixPortalOutLocation;
			Vector vector = tempGroundFixPortalOutLocation;
			FVectorDouble fvectorDouble = portalOutTf.GetLocation();
			vector.FromUeVector(fvectorDouble);
			Vector tempGroundFixMapToLocation = PortalUtils.TempGroundFixMapToLocation;
			Vector vector2 = tempGroundFixMapToLocation;
			fvectorDouble = mapToTf.GetLocation();
			vector2.FromUeVector(fvectorDouble);
			tempGroundFixMapToLocation.Subtraction(tempGroundFixPortalOutLocation, Singleton<MathUtils>.Instance.CommonTempVector);
			double num = Singleton<MathUtils>.Instance.CommonTempVector.DotProduct(tempGroundFixGravityDir);
			if (num <= 25.0)
			{
				return;
			}
			Vector tempGroundFixProjectedOffset = PortalUtils.TempGroundFixProjectedOffset;
			Vector.VectorPlaneProject(Singleton<MathUtils>.Instance.CommonTempVector, tempGroundFixGravityDir, tempGroundFixProjectedOffset);
			Vector vector3 = tempGroundFixProjectedOffset.Addition(tempGroundFixPortalOutLocation, PortalUtils.TempGroundFixTraceStart);
			Vector vector4 = tempGroundFixGravityDir.Multiply(num, PortalUtils.TempGroundFixTraceEnd).AdditionEqual(vector3);
			UTraceLineElement lineTrace = ModelBase<TraceElementModel>.Instance.GetLineTrace();
			lineTrace.WorldContextObject = GlobalData.World;
			lineTrace.ActorsToIgnore.Empty(true);
			Singleton<TraceElementCommon>.Instance.SetStartLocation(lineTrace, vector3);
			Singleton<TraceElementCommon>.Instance.SetEndLocation(lineTrace, vector4);
			if (PortalUtils.IsPortalDebugEnabled())
			{
				lineTrace.SetDrawDebugTrace(EDrawDebugTrace.None);
				PortalUtils.DrawDebugSphere(vector3.ToUeVector(false), PortalUtils.DebugColorLightBlue, 14f);
				PortalUtils.DrawDebugSphere(mapToTf.GetLocation(), PortalUtils.DebugColorRed, 16f);
				PortalUtils.DrawDebugLine(vector3.ToUeVector(false), vector4.ToUeVector(false), PortalUtils.DebugColorLightBlue);
			}
			bool flag = Singleton<TraceElementCommon>.Instance.LineTrace(lineTrace, "PortalUtils.TryFixUndergroundByProjectedGravityColumn");
			UKuroHitResult hitResult = lineTrace.HitResult;
			lineTrace.ClearCacheData(false);
			if (!flag || (hitResult == null || !hitResult.bBlockingHit))
			{
				return;
			}
			Vector tempGroundFixHitPoint = PortalUtils.TempGroundFixHitPoint;
			Singleton<TraceElementCommon>.Instance.GetHitLocation(hitResult, 0, tempGroundFixHitPoint);
			tempGroundFixGravityDir.Multiply(25.0, PortalUtils.TempGroundFixGravityProjection);
			tempGroundFixHitPoint.Subtraction(PortalUtils.TempGroundFixGravityProjection, tempGroundFixMapToLocation);
			fvectorDouble = tempGroundFixMapToLocation.ToUeVector(false);
			mapToTf.SetLocation(fvectorDouble);
			if (PortalUtils.IsPortalDebugEnabled())
			{
				PortalUtils.DrawDebugSphere(tempGroundFixHitPoint.ToUeVector(false), PortalUtils.DebugColorYellow, 18f);
				PortalUtils.DrawDebugSphere(mapToTf.GetLocation(), PortalUtils.DebugColorMintGreen, 20f);
				PortalUtils.DrawDebugLine(tempGroundFixHitPoint.ToUeVector(false), mapToTf.GetLocation(), PortalUtils.DebugColorMintGreen);
			}
		}

		// Token: 0x0401AEAD RID: 110253
		private const int TEMP_VECTOR_COUNT = 16;

		// Token: 0x0401AEAE RID: 110254
		private const float PORTAL_DEBUG_DURATION = 5f;

		// Token: 0x0401AEAF RID: 110255
		private const float PORTAL_DEBUG_THICKNESS = 2f;

		// Token: 0x0401AEB0 RID: 110256
		private const float PORTAL_DEBUG_AXIS_SCALE = 80f;

		// Token: 0x0401AEB1 RID: 110257
		private const float PORTAL_DEBUG_ARROW_SCALE = 120f;

		// Token: 0x0401AEB2 RID: 110258
		private const float GROUND_FIX_LIFT_DISTANCE = 25f;

		// Token: 0x0401AEB3 RID: 110259
		private const float GROUND_FIX_MIN_TRACE_DISTANCE = 25f;

		// Token: 0x0401AEB4 RID: 110260
		private static readonly FTransformDouble PortalRotateTf;

		// Token: 0x0401AEB5 RID: 110261
		private static List<Vector> TempVectors;

		// Token: 0x0401AEB6 RID: 110262
		private static FLinearColor? DebugColorCyanInstance;

		// Token: 0x0401AEB7 RID: 110263
		private static FLinearColor? DebugColorGreenInstance;

		// Token: 0x0401AEB8 RID: 110264
		private static FLinearColor? DebugColorOrangeInstance;

		// Token: 0x0401AEB9 RID: 110265
		private static FLinearColor? DebugColorLightBlueInstance;

		// Token: 0x0401AEBA RID: 110266
		private static FLinearColor? DebugColorRedInstance;

		// Token: 0x0401AEBB RID: 110267
		private static FLinearColor? DebugColorYellowInstance;

		// Token: 0x0401AEBC RID: 110268
		private static FLinearColor? DebugColorMintGreenInstance;
	}
}
