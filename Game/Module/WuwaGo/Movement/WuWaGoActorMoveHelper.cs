using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.WuwaGo.Model;
using CSharpScript.Game.Module.WuwaGo.Model.GameplayEntity;
using CSharpScript.Game.Module.WuwaGo.Model.Role;
using UnrealEngine;

namespace CSharpScript.Game.Module.WuwaGo.Movement
{
	// Token: 0x02004AC8 RID: 19144
	[NullableContext(1)]
	[Nullable(0)]
	public class WuWaGoActorMoveHelper
	{
		// Token: 0x06031E93 RID: 204435 RVA: 0x00C7D7D8 File Offset: 0x00C7B9D8
		public static void SnapMoveTargetsByGridCoordinateDelta(Transform originTransform, Vector fromCoordinate, Vector toCoordinate, IReadOnlyList<IWuWaGoWorldMoveTarget> moveTargets)
		{
			if (moveTargets.Count == 0)
			{
				return;
			}
			WuWaGoUtil.GetWorldPositionByCoordinate(originTransform, fromCoordinate, WuWaGoActorMoveHelper.FromWorldPosition);
			WuWaGoUtil.GetWorldPositionByCoordinate(originTransform, toCoordinate, WuWaGoActorMoveHelper.ToWorldPosition);
			WuWaGoActorMoveHelper.WorldDelta.Set(WuWaGoActorMoveHelper.ToWorldPosition.X - WuWaGoActorMoveHelper.FromWorldPosition.X, WuWaGoActorMoveHelper.ToWorldPosition.Y - WuWaGoActorMoveHelper.FromWorldPosition.Y, WuWaGoActorMoveHelper.ToWorldPosition.Z - WuWaGoActorMoveHelper.FromWorldPosition.Z);
			if (WuWaGoActorMoveHelper.WorldDelta.IsNearlyZero(9.999999747378752E-05))
			{
				return;
			}
			foreach (IWuWaGoWorldMoveTarget wuWaGoWorldMoveTarget in moveTargets)
			{
				if (wuWaGoWorldMoveTarget.Unit != null)
				{
					if (wuWaGoWorldMoveTarget.Unit.IsActorValid())
					{
						FVectorDouble? worldLocation = wuWaGoWorldMoveTarget.Unit.GetWorldLocation();
						if (worldLocation != null)
						{
							WuWaGoActorMoveHelper.InterpLocation.Set(worldLocation.Value.X, worldLocation.Value.Y, worldLocation.Value.Z);
							WuWaGoActorMoveHelper.InterpLocation.AdditionEqual(WuWaGoActorMoveHelper.WorldDelta);
							wuWaGoWorldMoveTarget.Unit.SetActorWorldLocation(WuWaGoActorMoveHelper.InterpLocation, false);
						}
					}
				}
				else
				{
					AActor actor = wuWaGoWorldMoveTarget.Actor;
					if (actor != null && actor.IsValid())
					{
						Vector interpLocation = WuWaGoActorMoveHelper.InterpLocation;
						FVectorDouble fvectorDouble = actor.D_K2_GetActorLocation();
						interpLocation.DeepCopy(fvectorDouble);
						WuWaGoActorMoveHelper.InterpLocation.AdditionEqual(WuWaGoActorMoveHelper.WorldDelta);
						actor.D_K2_SetActorLocation(WuWaGoActorMoveHelper.InterpLocation.ToUeVector(false), false, ref WorldGlobal.SweepHitResult, false);
					}
				}
			}
		}

		// Token: 0x06031E94 RID: 204436 RVA: 0x00C7D978 File Offset: 0x00C7BB78
		public static List<IWuWaGoWorldMoveTarget> BuildGridMoveTargets(WuWaGoGrid grid, [Nullable(2)] WuWaGoGameplayEntityBase gameplayEntity = null, [Nullable(2)] WuWaGoRole role = null, [Nullable(new byte[]
		{
			2,
			1
		})] IReadOnlyList<IWuWaGoWorldMoveTarget> extraTargets = null)
		{
			List<IWuWaGoWorldMoveTarget> list = new List<IWuWaGoWorldMoveTarget>();
			HashSet<WuWaGoBaseUnit> seenUnits = new HashSet<WuWaGoBaseUnit>();
			HashSet<AActor> seenActors = new HashSet<AActor>();
			WuWaGoActorMoveHelper.AppendUnitMoveTarget(list, seenUnits, grid);
			WuWaGoActorMoveHelper.AppendActorMoveTarget(list, seenActors, grid.Applique);
			WuWaGoActorMoveHelper.AppendUnitMoveTarget(list, seenUnits, gameplayEntity);
			WuWaGoActorMoveHelper.AppendUnitMoveTarget(list, seenUnits, role);
			if (extraTargets != null)
			{
				foreach (IWuWaGoWorldMoveTarget target in extraTargets)
				{
					WuWaGoActorMoveHelper.AppendMoveTarget(list, seenUnits, seenActors, target);
				}
			}
			return list;
		}

		// Token: 0x06031E95 RID: 204437 RVA: 0x00C7DA00 File Offset: 0x00C7BC00
		public static List<IWuWaGoWorldMoveTarget> BuildEntityMoveTargets([Nullable(2)] WuWaGoGameplayEntityBase gameplayEntity = null)
		{
			List<IWuWaGoWorldMoveTarget> list = new List<IWuWaGoWorldMoveTarget>();
			WuWaGoActorMoveHelper.AppendUnitMoveTarget(list, new HashSet<WuWaGoBaseUnit>(), gameplayEntity);
			return list;
		}

		// Token: 0x06031E96 RID: 204438 RVA: 0x00C7DA13 File Offset: 0x00C7BC13
		public static List<IWuWaGoWorldMoveTarget> BuildRoleMoveTargets([Nullable(2)] WuWaGoRole role = null)
		{
			List<IWuWaGoWorldMoveTarget> list = new List<IWuWaGoWorldMoveTarget>();
			WuWaGoActorMoveHelper.AppendUnitMoveTarget(list, new HashSet<WuWaGoBaseUnit>(), role);
			return list;
		}

		// Token: 0x06031E97 RID: 204439 RVA: 0x00C7DA26 File Offset: 0x00C7BC26
		private static void AppendUnitMoveTarget(List<IWuWaGoWorldMoveTarget> targets, HashSet<WuWaGoBaseUnit> seenUnits, [Nullable(2)] WuWaGoBaseUnit unit = null)
		{
			if (unit == null || !unit.IsActorValid() || !seenUnits.Add(unit))
			{
				return;
			}
			targets.Add(new WuWaGoWorldMoveTarget
			{
				Unit = unit
			});
		}

		// Token: 0x06031E98 RID: 204440 RVA: 0x00C7DA4F File Offset: 0x00C7BC4F
		private static void AppendActorMoveTarget(List<IWuWaGoWorldMoveTarget> targets, HashSet<AActor> seenActors, [Nullable(2)] AActor actor = null)
		{
			if (actor == null || !actor.IsValid() || !seenActors.Add(actor))
			{
				return;
			}
			targets.Add(new WuWaGoWorldMoveTarget
			{
				Actor = actor
			});
		}

		// Token: 0x06031E99 RID: 204441 RVA: 0x00C7DA80 File Offset: 0x00C7BC80
		private static void AppendMoveTarget(List<IWuWaGoWorldMoveTarget> targets, HashSet<WuWaGoBaseUnit> seenUnits, HashSet<AActor> seenActors, IWuWaGoWorldMoveTarget target)
		{
			if (target.Unit != null)
			{
				if (!target.Unit.IsActorValid() || !seenUnits.Add(target.Unit))
				{
					return;
				}
				targets.Add(target);
				return;
			}
			else
			{
				AActor actor = target.Actor;
				if (actor == null || !actor.IsValid() || !seenActors.Add(target.Actor))
				{
					return;
				}
				targets.Add(target);
				return;
			}
		}

		// Token: 0x0401D353 RID: 119635
		[StaticVariableRuleIgnore]
		private static readonly Vector InterpLocation = Vector.Create();

		// Token: 0x0401D354 RID: 119636
		[StaticVariableRuleIgnore]
		private static readonly Vector FromWorldPosition = Vector.Create();

		// Token: 0x0401D355 RID: 119637
		[StaticVariableRuleIgnore]
		private static readonly Vector ToWorldPosition = Vector.Create();

		// Token: 0x0401D356 RID: 119638
		[StaticVariableRuleIgnore]
		private static readonly Vector WorldDelta = Vector.Create();
	}
}
