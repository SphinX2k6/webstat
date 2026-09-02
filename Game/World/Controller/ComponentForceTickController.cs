using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Core.Framework;

namespace CSharpScript.Game.World.Controller
{
	// Token: 0x020046E2 RID: 18146
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[TickController(0)]
	public class ComponentForceTickController : ControllerBase<ComponentForceTickController>
	{
		// Token: 0x0602F31E RID: 193310 RVA: 0x00B2ED74 File Offset: 0x00B2CF74
		protected unsafe override bool OnInit()
		{
			int num = 2;
			List<EComponent> list = new List<EComponent>(num);
			CollectionsMarshal.SetCount<EComponent>(list, num);
			Span<EComponent> span = CollectionsMarshal.AsSpan<EComponent>(list);
			int num2 = 0;
			*span[num2] = EComponent.GamePlayElevatorComponent;
			num2++;
			*span[num2] = EComponent.RoadNetworkNavigationComponent;
			this.ApproveRegisterPreTickComponents = list;
			num2 = 11;
			List<EComponent> list2 = new List<EComponent>(num2);
			CollectionsMarshal.SetCount<EComponent>(list2, num2);
			span = CollectionsMarshal.AsSpan<EComponent>(list2);
			num = 0;
			*span[num] = EComponent.CharacterCombatMessageComponent;
			num++;
			*span[num] = EComponent.CharacterMovementSyncComponent;
			num++;
			*span[num] = EComponent.GamePlayElevatorComponent;
			num++;
			*span[num] = EComponent.PostProcessBridgeComponent;
			num++;
			*span[num] = EComponent.SceneItemManipulatableComponent;
			num++;
			*span[num] = EComponent.SceneItemMovementSyncComponent;
			num++;
			*span[num] = EComponent.SceneItemDropItemComponent;
			num++;
			*span[num] = EComponent.SceneItemConveyorBeltComponent;
			num++;
			*span[num] = EComponent.SceneItemFanComponent;
			num++;
			*span[num] = EComponent.SceneItemMultiInteractionActorComponent;
			num++;
			*span[num] = EComponent.SceneItemCameraAlertComponent;
			this.ApproveRegisterTickComponents = list2;
			num = 3;
			List<EComponent> list3 = new List<EComponent>(num);
			CollectionsMarshal.SetCount<EComponent>(list3, num);
			span = CollectionsMarshal.AsSpan<EComponent>(list3);
			num2 = 0;
			*span[num2] = EComponent.CharacterLogicStateSyncComponent;
			num2++;
			*span[num2] = EComponent.CharacterMovementSyncComponent;
			num2++;
			*span[num2] = EComponent.SceneItemMovementSyncComponent;
			this.ApproveRegisterAfterTickComponents = list3;
			return true;
		}

		// Token: 0x0602F31F RID: 193311 RVA: 0x00B2EEE8 File Offset: 0x00B2D0E8
		public void RegisterPreMoveTick(EntityComponent comp, Action<float> func)
		{
			if (!this.IsTypeApproveRegisterPreTick(comp))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.TickController;
				ELogAuthor author = ELogAuthor.ZFJ;
				string message = "[ComponentForceTickController.RegisterPreMoveTick] 当前Comp不允许注册到ForceTickController";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Comp", comp.ToString());
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			if (this.PreMoveTickFunctions.ContainsKey(comp))
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.TickController;
				ELogAuthor author2 = ELogAuthor.ZFJ;
				string message2 = "[ComponentForceTickController.RegisterPreMoveTick] 当前Comp已经注册过ForceTick";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("Comp", comp.ToString());
				instance2.Warn(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				return;
			}
			this.PreMoveTickFunctions[comp] = func;
		}

		// Token: 0x0602F320 RID: 193312 RVA: 0x00B2EF7C File Offset: 0x00B2D17C
		public void RegisterPreTick(EntityComponent comp, Action<float> func)
		{
			if (!this.IsTypeApproveRegisterPreTick(comp))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.TickController;
				ELogAuthor author = ELogAuthor.CH;
				string message = "[ComponentForceTickController.RegisterTick] 当前Comp不允许注册到ForceTickController";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Comp", comp.ToString());
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			Singleton<Core>.Instance.RegisterPreTick(func);
		}

		// Token: 0x0602F321 RID: 193313 RVA: 0x00B2EFCD File Offset: 0x00B2D1CD
		public void UnregisterPreTick(Action<float> func)
		{
			Singleton<Core>.Instance.UnRegisterPreTick(func);
		}

		// Token: 0x0602F322 RID: 193314 RVA: 0x00B2EFDC File Offset: 0x00B2D1DC
		public void RegisterTick(EntityComponent comp, Action<float> func)
		{
			if (!this.IsTypeApproveRegisterTick(comp))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.TickController;
				ELogAuthor author = ELogAuthor.CH;
				string message = "[ComponentForceTickController.RegisterTick] 当前Comp不允许注册到ForceTickController";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Comp", comp.ToString());
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			if (this.TickFunctions.ContainsKey(comp))
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.TickController;
				ELogAuthor author2 = ELogAuthor.CH;
				string message2 = "[ComponentForceTickController.RegisterTick] 当前Comp已经注册过ForceTick";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("Comp", comp.ToString());
				instance2.Warn(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				return;
			}
			this.TickFunctions[comp] = func;
		}

		// Token: 0x0602F323 RID: 193315 RVA: 0x00B2F070 File Offset: 0x00B2D270
		public void RegisterAfterTick(EntityComponent comp, Action<float> func)
		{
			if (!this.IsTypeApproveRegisterAfterTick(comp))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.TickController;
				ELogAuthor author = ELogAuthor.CH;
				string message = "[ComponentForceTickController.RegisterAfterTick] 当前Comp不允许注册到ForceTickController";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Comp", comp.ToString());
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			if (this.AfterTickFunctions.ContainsKey(comp))
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.TickController;
				ELogAuthor author2 = ELogAuthor.CH;
				string message2 = "[ComponentForceTickController.RegisterAfterTick] 当前Comp已经注册过ForceAfterTick";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("Comp", comp.ToString());
				instance2.Warn(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				return;
			}
			this.AfterTickFunctions[comp] = func;
		}

		// Token: 0x0602F324 RID: 193316 RVA: 0x00B2F104 File Offset: 0x00B2D304
		public void UnregisterPreMoveTick(EntityComponent comp)
		{
			if (!this.PreMoveTickFunctions.ContainsKey(comp))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.TickController;
				ELogAuthor author = ELogAuthor.ZFJ;
				string message = "[ComponentForceTickController.UnregisterPreTick] 当前Comp未注册过";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Comp", comp.ToString());
				instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			this.PreMoveTickFunctions.Remove(comp);
		}

		// Token: 0x0602F325 RID: 193317 RVA: 0x00B2F15C File Offset: 0x00B2D35C
		public void UnregisterTick(EntityComponent comp)
		{
			if (!this.TickFunctions.ContainsKey(comp))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.TickController;
				ELogAuthor author = ELogAuthor.CH;
				string message = "[ComponentForceTickController.UnregisterTick] 当前Comp未注册过ForceTick";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Comp", comp.ToString());
				instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			this.TickFunctions.Remove(comp);
		}

		// Token: 0x0602F326 RID: 193318 RVA: 0x00B2F1B4 File Offset: 0x00B2D3B4
		public void UnregisterAfterTick(EntityComponent comp)
		{
			if (!this.AfterTickFunctions.ContainsKey(comp))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.TickController;
				ELogAuthor author = ELogAuthor.CH;
				string message = "[ComponentForceTickController.UnregisterAfterTick] 当前Comp未注册过ForceAfterTick";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Comp", comp.ToString());
				instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			this.AfterTickFunctions.Remove(comp);
		}

		// Token: 0x0602F327 RID: 193319 RVA: 0x00B2F20C File Offset: 0x00B2D40C
		public unsafe void MoveTickPriority1(float delta)
		{
			foreach (KeyValuePair<EntityComponent, Action<float>> keyValuePair in this.PreMoveTickFunctions)
			{
				EntityComponent entityComponent;
				Action<float> action;
				keyValuePair.Deconstruct(out entityComponent, out action);
				EntityComponent entityComponent2 = entityComponent;
				Action<float> action2 = action;
				if (entityComponent2.Active)
				{
					try
					{
						this.CreateStat(this.PreTickStatMap, entityComponent2.GetType().Name, "ComponentForceTickController.PreMoveTick");
						action2(delta * this.TimeDilationInternal);
					}
					catch (Exception ex)
					{
						Log instance = Singleton<Log>.Instance;
						ELogModule module = ELogModule.TickController;
						ELogAuthor author = ELogAuthor.ZFJ;
						string message = "处理方法执行异常";
						Exception error = ex;
						<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("comp", entityComponent2.ToString());
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("error", ex.Message);
						instance.ErrorWithStack(module, author, message, error, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
					}
				}
			}
		}

		// Token: 0x0602F328 RID: 193320 RVA: 0x00B2F31C File Offset: 0x00B2D51C
		protected unsafe override void OnTick(float delta)
		{
			foreach (KeyValuePair<EntityComponent, Action<float>> keyValuePair in this.TickFunctions)
			{
				EntityComponent entityComponent;
				Action<float> action;
				keyValuePair.Deconstruct(out entityComponent, out action);
				EntityComponent entityComponent2 = entityComponent;
				Action<float> action2 = action;
				if (entityComponent2.Active)
				{
					try
					{
						this.CreateStat(this.TickStatMap, entityComponent2.GetType().Name, "ComponentForceTickController.OnTick.");
						action2(delta * this.TimeDilationInternal);
					}
					catch (Exception ex)
					{
						Log instance = Singleton<Log>.Instance;
						ELogModule module = ELogModule.TickController;
						ELogAuthor author = ELogAuthor.CH;
						string message = "处理方法执行异常";
						Exception error = ex;
						<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("comp", entityComponent2.ToString());
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("error", ex.Message);
						instance.ErrorWithStack(module, author, message, error, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
					}
				}
			}
		}

		// Token: 0x0602F329 RID: 193321 RVA: 0x00B2F42C File Offset: 0x00B2D62C
		protected unsafe override void OnAfterTick(float delta)
		{
			foreach (KeyValuePair<EntityComponent, Action<float>> keyValuePair in this.AfterTickFunctions)
			{
				EntityComponent entityComponent;
				Action<float> action;
				keyValuePair.Deconstruct(out entityComponent, out action);
				EntityComponent entityComponent2 = entityComponent;
				Action<float> action2 = action;
				try
				{
					if (entityComponent2.Active)
					{
						this.CreateStat(this.AfterTickStatMap, entityComponent2.GetType().Name, "ComponentForceTickController.OnAfterTick.");
						action2(delta * this.TimeDilationInternal);
					}
				}
				catch (Exception ex)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.TickController;
					ELogAuthor author = ELogAuthor.CH;
					string message = "处理方法执行异常";
					Exception error = ex;
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("comp", entityComponent2.ToString());
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("error", ex.Message);
					instance.ErrorWithStack(module, author, message, error, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				}
			}
		}

		// Token: 0x0602F32A RID: 193322 RVA: 0x00B2F540 File Offset: 0x00B2D740
		private bool IsTypeApproveRegisterPreTick(EntityComponent comp)
		{
			foreach (EComponent compId in this.ApproveRegisterPreTickComponents)
			{
				if (this.IsComponentInstance(comp, compId))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0602F32B RID: 193323 RVA: 0x00B2F5A0 File Offset: 0x00B2D7A0
		private bool IsTypeApproveRegisterTick(EntityComponent comp)
		{
			foreach (EComponent compId in this.ApproveRegisterTickComponents)
			{
				if (this.IsComponentInstance(comp, compId))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0602F32C RID: 193324 RVA: 0x00B2F600 File Offset: 0x00B2D800
		private bool IsTypeApproveRegisterAfterTick(EntityComponent comp)
		{
			foreach (EComponent compId in this.ApproveRegisterAfterTickComponents)
			{
				if (this.IsComponentInstance(comp, compId))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0602F32D RID: 193325 RVA: 0x00B2F660 File Offset: 0x00B2D860
		[return: Nullable(2)]
		private Stat CreateStat(Dictionary<string, Stat> map, string type, string prefix)
		{
			if (!Stat.Enable)
			{
				return null;
			}
			Stat stat;
			if (!map.TryGetValue(type, out stat))
			{
				stat = Stat.CreateNoFlameGraph(prefix + type, "", "");
				map[type] = stat;
			}
			return stat;
		}

		// Token: 0x0602F32E RID: 193326 RVA: 0x00B2F6A1 File Offset: 0x00B2D8A1
		public void SetTimeDilation(float timeDilation)
		{
			this.TimeDilationInternal = timeDilation;
		}

		// Token: 0x0602F32F RID: 193327 RVA: 0x00B2F6AC File Offset: 0x00B2D8AC
		private bool IsComponentInstance(EntityComponent comp, EComponent compId)
		{
			Type type = comp.GetType();
			while (type != null && type != typeof(EntityComponent))
			{
				if (EntityComponent.GetByType(type.Name) == (int)compId)
				{
					return true;
				}
				type = type.BaseType;
			}
			return false;
		}

		// Token: 0x0401AE40 RID: 110144
		private List<EComponent> ApproveRegisterTickComponents = new List<EComponent>();

		// Token: 0x0401AE41 RID: 110145
		private List<EComponent> ApproveRegisterAfterTickComponents = new List<EComponent>();

		// Token: 0x0401AE42 RID: 110146
		private List<EComponent> ApproveRegisterPreTickComponents = new List<EComponent>();

		// Token: 0x0401AE43 RID: 110147
		private readonly Dictionary<string, Stat> PreTickStatMap = new Dictionary<string, Stat>();

		// Token: 0x0401AE44 RID: 110148
		private readonly Dictionary<string, Stat> TickStatMap = new Dictionary<string, Stat>();

		// Token: 0x0401AE45 RID: 110149
		private readonly Dictionary<string, Stat> AfterTickStatMap = new Dictionary<string, Stat>();

		// Token: 0x0401AE46 RID: 110150
		private float TimeDilationInternal = 1f;

		// Token: 0x0401AE47 RID: 110151
		private readonly Dictionary<EntityComponent, Action<float>> PreMoveTickFunctions = new Dictionary<EntityComponent, Action<float>>();

		// Token: 0x0401AE48 RID: 110152
		private readonly Dictionary<EntityComponent, Action<float>> TickFunctions = new Dictionary<EntityComponent, Action<float>>();

		// Token: 0x0401AE49 RID: 110153
		private readonly Dictionary<EntityComponent, Action<float>> AfterTickFunctions = new Dictionary<EntityComponent, Action<float>>();
	}
}
