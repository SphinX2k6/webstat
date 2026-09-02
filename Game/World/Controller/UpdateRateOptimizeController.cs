using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Core.Framework;
using CSharpScript.Game.Common.Event;
using UnrealEngine;

namespace CSharpScript.Game.World.Controller
{
	// Token: 0x020046EB RID: 18155
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[TickController(0)]
	public class UpdateRateOptimizeController : ControllerBase<UpdateRateOptimizeController>
	{
		// Token: 0x17008146 RID: 33094
		// (get) Token: 0x0602F39C RID: 193436 RVA: 0x00B31C82 File Offset: 0x00B2FE82
		protected HashSet<EntityHandle> CurFrameValidEntityHandles
		{
			get
			{
				return this.EntityHandlesCache[this.CurIndex];
			}
		}

		// Token: 0x17008147 RID: 33095
		// (get) Token: 0x0602F39D RID: 193437 RVA: 0x00B31C95 File Offset: 0x00B2FE95
		protected HashSet<EntityHandle> LastFrameValidEntityHandles
		{
			get
			{
				return this.EntityHandlesCache[1 - this.CurIndex];
			}
		}

		// Token: 0x0602F39E RID: 193438 RVA: 0x00B31CAC File Offset: 0x00B2FEAC
		protected override bool OnInit()
		{
			this.IsEnableRayTraceReflection = (Singleton<GameSettingsManager>.Instance.GetCurrentValueSafely(EFunction.RayTracedReflection, 0, true) != 0);
			Singleton<EventSystem>.Instance.Add<bool>(EEventName.UpdateRayTraceReflection, new Action<bool>(this.UpdateRayTraceReflection));
			return base.OnInit();
		}

		// Token: 0x0602F39F RID: 193439 RVA: 0x00B31CF8 File Offset: 0x00B2FEF8
		protected override void OnTick(float delta)
		{
			if (!this.IsEnableRayTraceReflection)
			{
				this.EnableUpdateRateOptimizationForSet(true, this.LastFrameValidEntityHandles, null);
				this.EnableUpdateRateOptimizationForMap(true, this.PendingEnableEntityHandles, null);
				this.ResetState();
				return;
			}
			this.TempEntities.Clear();
			if (UKuroRenderingRuntimeBPPluginBPLibrary.GetDisableNPCOptAsRayTracing(GlobalData.World))
			{
				ModelBase<CreatureModel>.Instance.GetEntitiesInRange(120000f, EEntityTypeQuery.Character, this.TempEntities, true, false);
			}
			this.EnableUpdateRateOptimizationForArray(false, this.TempEntities, delegate(EntityHandle handle)
			{
				this.CurFrameValidEntityHandles.Add(handle);
				this.LastFrameValidEntityHandles.Remove(handle);
				this.PendingEnableEntityHandles.Remove(handle);
			});
			foreach (EntityHandle key in this.LastFrameValidEntityHandles)
			{
				this.PendingEnableEntityHandles[key] = 0f;
			}
			this.LastFrameValidEntityHandles.Clear();
			this.TempEntities.Clear();
			foreach (KeyValuePair<EntityHandle, float> keyValuePair in this.PendingEnableEntityHandles)
			{
				EntityHandle entityHandle;
				float num;
				keyValuePair.Deconstruct(out entityHandle, out num);
				EntityHandle entityHandle2 = entityHandle;
				float num2 = num;
				if (entityHandle2.Valid && num2 < 3000f)
				{
					this.PendingEnableEntityHandles[entityHandle2] = num2 + delta;
				}
				else
				{
					this.TempEntities.Add(entityHandle2);
					this.PendingEnableEntityHandles.Remove(entityHandle2);
				}
			}
			this.EnableUpdateRateOptimizationForArray(true, this.TempEntities, null);
			this.CurIndex = 1 - this.CurIndex;
		}

		// Token: 0x0602F3A0 RID: 193440 RVA: 0x00B31E88 File Offset: 0x00B30088
		protected override bool OnClear()
		{
			this.ResetState();
			Singleton<EventSystem>.Instance.Remove<bool>(EEventName.UpdateRayTraceReflection, new Action<bool>(this.UpdateRayTraceReflection));
			return true;
		}

		// Token: 0x0602F3A1 RID: 193441 RVA: 0x00B31EAD File Offset: 0x00B300AD
		protected override bool OnLeaveLevel()
		{
			this.ResetState();
			return true;
		}

		// Token: 0x0602F3A2 RID: 193442 RVA: 0x00B31EB6 File Offset: 0x00B300B6
		protected void ResetState()
		{
			this.TempEntities.Clear();
			this.CurFrameValidEntityHandles.Clear();
			this.LastFrameValidEntityHandles.Clear();
			this.PendingEnableEntityHandles.Clear();
		}

		// Token: 0x0602F3A3 RID: 193443 RVA: 0x00B31EE4 File Offset: 0x00B300E4
		protected void UpdateRayTraceReflection(bool enable)
		{
			if (this.IsEnableRayTraceReflection == enable)
			{
				return;
			}
			this.IsEnableRayTraceReflection = enable;
		}

		// Token: 0x0602F3A4 RID: 193444 RVA: 0x00B31EF8 File Offset: 0x00B300F8
		protected void EnableUpdateRateOptimizationForArray(bool enable, List<EntityHandle> entityHandles, [Nullable(new byte[]
		{
			2,
			1
		})] Action<EntityHandle> action = null)
		{
			if (entityHandles.Count == 0)
			{
				return;
			}
			foreach (EntityHandle eHandle in entityHandles)
			{
				UpdateRateOptimizeController.ApplyOptimizationToEntity(enable, eHandle, action);
			}
		}

		// Token: 0x0602F3A5 RID: 193445 RVA: 0x00B31F50 File Offset: 0x00B30150
		protected void EnableUpdateRateOptimizationForSet(bool enable, HashSet<EntityHandle> entityHandles, [Nullable(new byte[]
		{
			2,
			1
		})] Action<EntityHandle> action = null)
		{
			if (entityHandles.Count == 0)
			{
				return;
			}
			foreach (EntityHandle eHandle in entityHandles)
			{
				UpdateRateOptimizeController.ApplyOptimizationToEntity(enable, eHandle, action);
			}
		}

		// Token: 0x0602F3A6 RID: 193446 RVA: 0x00B31FA8 File Offset: 0x00B301A8
		protected void EnableUpdateRateOptimizationForMap(bool enable, Dictionary<EntityHandle, float> entityHandlesMap, [Nullable(new byte[]
		{
			2,
			1
		})] Action<EntityHandle> action = null)
		{
			if (entityHandlesMap.Count == 0)
			{
				return;
			}
			foreach (EntityHandle eHandle in entityHandlesMap.Keys)
			{
				UpdateRateOptimizeController.ApplyOptimizationToEntity(enable, eHandle, action);
			}
		}

		// Token: 0x0602F3A7 RID: 193447 RVA: 0x00B32008 File Offset: 0x00B30208
		private static void ApplyOptimizationToEntity(bool enable, EntityHandle eHandle, [Nullable(new byte[]
		{
			2,
			1
		})] Action<EntityHandle> action = null)
		{
			if (eHandle.EntityType != 10)
			{
				WorldEntity entity = eHandle.Entity;
				BaseAnimationComponent baseAnimationComponent = (entity != null) ? entity.GetComponent<BaseAnimationComponent>() : null;
				if (baseAnimationComponent == null)
				{
					return;
				}
				if (enable)
				{
					baseAnimationComponent.CancelForceDisableAnimOptimization(EForceDisableAnimOptimization.RayTrace);
				}
				else
				{
					baseAnimationComponent.StartForceDisableAnimOptimization2(EForceDisableAnimOptimization.RayTrace);
				}
			}
			else
			{
				WorldEntity entity2 = eHandle.Entity;
				VehicleAnimationComponent vehicleAnimationComponent = (entity2 != null) ? entity2.GetComponent<VehicleAnimationComponent>() : null;
				if (vehicleAnimationComponent == null)
				{
					return;
				}
				if (enable)
				{
					vehicleAnimationComponent.CancelForceDisableAnimOptimization(EForceDisableAnimOptimization.RayTrace);
				}
				else
				{
					vehicleAnimationComponent.StartForceDisableAnimOptimization2(EForceDisableAnimOptimization.RayTrace);
				}
			}
			if (action != null)
			{
				action(eHandle);
			}
		}

		// Token: 0x0602F3A8 RID: 193448 RVA: 0x00B32084 File Offset: 0x00B30284
		public unsafe UpdateRateOptimizeController()
		{
			int num = 2;
			List<HashSet<EntityHandle>> list = new List<HashSet<EntityHandle>>(num);
			CollectionsMarshal.SetCount<HashSet<EntityHandle>>(list, num);
			Span<HashSet<EntityHandle>> span = CollectionsMarshal.AsSpan<HashSet<EntityHandle>>(list);
			int num2 = 0;
			*span[num2] = new HashSet<EntityHandle>();
			num2++;
			*span[num2] = new HashSet<EntityHandle>();
			this.EntityHandlesCache = list;
			this.PendingEnableEntityHandles = new Dictionary<EntityHandle, float>();
			this.TempEntities = new List<EntityHandle>();
			base..ctor();
		}

		// Token: 0x0401AE74 RID: 110196
		private const int RAYTRACING_URO_CHECK_DISTANCE = 120000;

		// Token: 0x0401AE75 RID: 110197
		private const int DELAY_ENABLE_URO_TIME = 3000;

		// Token: 0x0401AE76 RID: 110198
		protected bool IsEnableRayTraceReflection;

		// Token: 0x0401AE77 RID: 110199
		protected int CurIndex;

		// Token: 0x0401AE78 RID: 110200
		protected List<HashSet<EntityHandle>> EntityHandlesCache;

		// Token: 0x0401AE79 RID: 110201
		protected Dictionary<EntityHandle, float> PendingEnableEntityHandles;

		// Token: 0x0401AE7A RID: 110202
		protected List<EntityHandle> TempEntities;
	}
}
