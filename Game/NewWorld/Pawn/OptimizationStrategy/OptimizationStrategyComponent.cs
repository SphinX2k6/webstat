using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Component;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.NewWorld.Character.Custom.Components;

namespace CSharpScript.Game.NewWorld.Pawn.OptimizationStrategy
{
	// Token: 0x020048A4 RID: 18596
	[NullableContext(1)]
	[Nullable(0)]
	public class OptimizationStrategyComponent : EntityComponent
	{
		// Token: 0x0603073E RID: 198462 RVA: 0x00BE0960 File Offset: 0x00BDEB60
		[NullableContext(2)]
		protected override bool OnInitData(IEntityArgs args = null)
		{
			object param = args.GetP1<CreateEntityData>().GetParam<OptimizationStrategyComponent>();
			if (param == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.SceneItem, ELogAuthor.LJM, "[OptimizationStrategyComponent] 初始化基础数据失败", default(ReadOnlySpan<ValueTuple<string, object>>));
				return false;
			}
			PerformanceOptimizationComponent performanceOptimizationComponent = param as PerformanceOptimizationComponent;
			if (performanceOptimizationComponent == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.SceneItem, ELogAuthor.LJM, "[OptimizationStrategyComponent] 初始化数据失败", default(ReadOnlySpan<ValueTuple<string, object>>));
				return false;
			}
			this.OptimizationTypeList = performanceOptimizationComponent.PerformanceOptimizationList;
			return true;
		}

		// Token: 0x0603073F RID: 198463 RVA: 0x00BE09D0 File Offset: 0x00BDEBD0
		protected override bool OnStart()
		{
			this.RangeComp = base.Entity.GetComponent<CSharpScript.Game.NewWorld.Character.Custom.Components.RangeComponent>();
			if (this.RangeComp == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Optimization;
				ELogAuthor author = ELogAuthor.LJM;
				string message = "[OptimizationStrategyComponent] 组件缺失";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("RangeComponent", this.RangeComp != null);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return false;
			}
			this.BaseOptimizationStrategyList = new List<BaseOptimizationStrategy>();
			this.InitOptimizationStrategy();
			this.EnableOptimizationStrategy();
			if (!Singleton<EventSystem>.Instance.HasWithTarget(base.Entity, EEventName.OnMyPlayerInOutRangeLocal, new Action<bool>(this.OnMyPlayerEntityInOutRange)))
			{
				Singleton<EventSystem>.Instance.AddWithTarget(base.Entity, EEventName.OnMyPlayerInOutRangeLocal, new Action<bool>(this.OnMyPlayerEntityInOutRange));
			}
			if (!Singleton<EventSystem>.Instance.HasWithTarget(base.Entity, EEventName.OnEntityInOutRangeLocal, new Action<bool, EntityHandle>(this.OnEntityInOutRangeLocal)))
			{
				Singleton<EventSystem>.Instance.AddWithTarget(base.Entity, EEventName.OnEntityInOutRangeLocal, new Action<bool, EntityHandle>(this.OnEntityInOutRangeLocal));
			}
			this.OnSceneInteractionLoadCompleted();
			Singleton<Log>.Instance.Info(ELogModule.Optimization, ELogAuthor.LJM, "[OptimizationStrategyComponent] OnStart", default(ReadOnlySpan<ValueTuple<string, object>>));
			return true;
		}

		// Token: 0x06030740 RID: 198464 RVA: 0x00BE0AF8 File Offset: 0x00BDECF8
		private void InitOptimizationStrategy()
		{
			if (this.OptimizationTypeList == null || this.OptimizationTypeList.Count == 0)
			{
				return;
			}
			foreach (IPerformanceOptimization performanceOptimization in this.OptimizationTypeList)
			{
				this.AddOptimizationStrategy<EPerformanceOptimizationType>(performanceOptimization.Type);
			}
		}

		// Token: 0x06030741 RID: 198465 RVA: 0x00BE0B68 File Offset: 0x00BDED68
		public void AddOptimizationStrategy<[Nullable(0)] T>(T type) where T : Enum
		{
			EPerformanceOptimizationType key = (EPerformanceOptimizationType)((object)type);
			if (!EPerformanceOptimizationMap.Map.ContainsKey(key))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Optimization;
				ELogAuthor author = ELogAuthor.LJM;
				string message = "[OptimizationStrategyComponent] 未找到对应的Profile";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("type", type);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			BaseOptimizationStrategy item = (BaseOptimizationStrategy)Activator.CreateInstance(EPerformanceOptimizationMap.Map[key]);
			this.BaseOptimizationStrategyList.Add(item);
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Optimization;
			ELogAuthor author2 = ELogAuthor.LJM;
			string message2 = "[OptimizationStrategyComponent] AddOptimizationStrategy";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("type", type);
			instance2.Info(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
		}

		// Token: 0x06030742 RID: 198466 RVA: 0x00BE0C10 File Offset: 0x00BDEE10
		private void EnableOptimizationStrategy()
		{
			foreach (BaseOptimizationStrategy baseOptimizationStrategy in this.BaseOptimizationStrategyList)
			{
				baseOptimizationStrategy.Enable();
			}
		}

		// Token: 0x06030743 RID: 198467 RVA: 0x00BE0C60 File Offset: 0x00BDEE60
		private void MyPlayerEntityInOutRange(bool isEnterRange)
		{
			foreach (BaseOptimizationStrategy baseOptimizationStrategy in this.BaseOptimizationStrategyList)
			{
				baseOptimizationStrategy.MyPlayerEntityInOutRange(isEnterRange);
			}
		}

		// Token: 0x06030744 RID: 198468 RVA: 0x00BE0CB4 File Offset: 0x00BDEEB4
		private void EntityInOutRange(bool isEnterRange, EntityHandle handle)
		{
			foreach (BaseOptimizationStrategy baseOptimizationStrategy in this.BaseOptimizationStrategyList)
			{
				baseOptimizationStrategy.EntityInOutRange(isEnterRange, handle);
			}
		}

		// Token: 0x06030745 RID: 198469 RVA: 0x00BE0D08 File Offset: 0x00BDEF08
		private void DisableOptimizationStrategy()
		{
			foreach (BaseOptimizationStrategy baseOptimizationStrategy in this.BaseOptimizationStrategyList)
			{
				baseOptimizationStrategy.Disable();
			}
		}

		// Token: 0x06030746 RID: 198470 RVA: 0x00BE0D58 File Offset: 0x00BDEF58
		private void OnSceneInteractionLoadCompleted()
		{
			this.IsReady = true;
		}

		// Token: 0x06030747 RID: 198471 RVA: 0x00BE0D61 File Offset: 0x00BDEF61
		private void OnMyPlayerEntityInOutRange(bool isEnter)
		{
			if (!this.IsReady)
			{
				return;
			}
			this.MyPlayerEntityInOutRange(isEnter);
		}

		// Token: 0x06030748 RID: 198472 RVA: 0x00BE0D73 File Offset: 0x00BDEF73
		private void OnEntityInOutRangeLocal(bool isEnter, EntityHandle handle)
		{
			if (!this.IsReady)
			{
				return;
			}
			this.EntityInOutRange(isEnter, handle);
		}

		// Token: 0x06030749 RID: 198473 RVA: 0x00BE0D88 File Offset: 0x00BDEF88
		protected override bool OnEnd()
		{
			this.DisableOptimizationStrategy();
			this.BaseOptimizationStrategyList = null;
			this.IsReady = false;
			if (!Singleton<EventSystem>.Instance.HasWithTarget(base.Entity, EEventName.OnMyPlayerInOutRangeLocal, new Action<bool>(this.OnMyPlayerEntityInOutRange)))
			{
				Singleton<EventSystem>.Instance.RemoveWithTarget(base.Entity, EEventName.OnMyPlayerInOutRangeLocal, new Action<bool>(this.OnMyPlayerEntityInOutRange));
			}
			if (!Singleton<EventSystem>.Instance.HasWithTarget(base.Entity, EEventName.OnEntityInOutRangeLocal, new Action<bool, EntityHandle>(this.OnEntityInOutRangeLocal)))
			{
				Singleton<EventSystem>.Instance.RemoveWithTarget(base.Entity, EEventName.OnEntityInOutRangeLocal, new Action<bool, EntityHandle>(this.OnEntityInOutRangeLocal));
			}
			if (Singleton<EventSystem>.Instance.HasWithTarget(base.Entity, EEventName.OnSceneInteractionLoadCompleted, new Action(this.OnSceneInteractionLoadCompleted)))
			{
				Singleton<EventSystem>.Instance.RemoveWithTarget(base.Entity, EEventName.OnSceneInteractionLoadCompleted, new Action(this.OnSceneInteractionLoadCompleted));
			}
			Singleton<Log>.Instance.Info(ELogModule.Optimization, ELogAuthor.LJM, "[OptimizationStrategyComponent] OnEnd", default(ReadOnlySpan<ValueTuple<string, object>>));
			return true;
		}

		// Token: 0x0603074A RID: 198474 RVA: 0x00BE0E98 File Offset: 0x00BDF098
		public override bool ClearComponent(EntityComponent componentTemplate)
		{
			if (!base.ClearComponent(componentTemplate))
			{
				return false;
			}
			OptimizationStrategyComponent optimizationStrategyComponent = (OptimizationStrategyComponent)componentTemplate;
			if (base.CanResetComponentProperty("RangeComp"))
			{
				if (optimizationStrategyComponent.RangeComp == null)
				{
					this.RangeComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CSharpScript.Game.NewWorld.Character.Custom.Components.RangeComponent>(this.RangeComp), "RangeComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("BaseOptimizationStrategyList"))
			{
				if (optimizationStrategyComponent.BaseOptimizationStrategyList == null)
				{
					this.BaseOptimizationStrategyList = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<List<BaseOptimizationStrategy>>(this.BaseOptimizationStrategyList), "BaseOptimizationStrategyList"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("IsReady"))
			{
				this.IsReady = optimizationStrategyComponent.IsReady;
			}
			if (base.CanResetComponentProperty("OptimizationTypeList"))
			{
				if (optimizationStrategyComponent.OptimizationTypeList == null)
				{
					this.OptimizationTypeList = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<List<IPerformanceOptimization>>(this.OptimizationTypeList), "OptimizationTypeList"))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x0401BD50 RID: 114000
		[Nullable(2)]
		private CSharpScript.Game.NewWorld.Character.Custom.Components.RangeComponent RangeComp;

		// Token: 0x0401BD51 RID: 114001
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private List<BaseOptimizationStrategy> BaseOptimizationStrategyList;

		// Token: 0x0401BD52 RID: 114002
		private bool IsReady;

		// Token: 0x0401BD53 RID: 114003
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private List<IPerformanceOptimization> OptimizationTypeList;
	}
}
