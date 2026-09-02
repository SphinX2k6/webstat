using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;

namespace CSharpScript.Game.LevelGamePlay
{
	// Token: 0x02006A46 RID: 27206
	[NullableContext(1)]
	[Nullable(0)]
	public class GeneralContext : IStaticVariableResetter
	{
		// Token: 0x060434F2 RID: 275698 RVA: 0x0114D44B File Offset: 0x0114B64B
		static GeneralContext()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(GeneralContext.CreateStaticDefaultValue), new Action(GeneralContext.ResetStaticDefaultValue));
		}

		// Token: 0x060434F3 RID: 275699 RVA: 0x0114D46A File Offset: 0x0114B66A
		public virtual void Reset()
		{
			this.SubType = null;
		}

		// Token: 0x060434F4 RID: 275700 RVA: 0x0114D478 File Offset: 0x0114B678
		protected static GeneralContext GetObj(EGeneralContextType type, GameCtxType? subType, Func<GeneralContext> ctor)
		{
			List<GeneralContext> list;
			if (!GeneralContext.Pool.TryGetValue((int)type, out list))
			{
				list = new List<GeneralContext>();
				GeneralContext.Pool[(int)type] = list;
			}
			GeneralContext generalContext;
			if (list.Count > 0)
			{
				generalContext = list[list.Count - 1];
				list.RemoveAt(list.Count - 1);
				generalContext.InPool = false;
			}
			else
			{
				generalContext = ctor();
			}
			generalContext.SubType = subType;
			return generalContext;
		}

		// Token: 0x060434F5 RID: 275701 RVA: 0x0114D4E8 File Offset: 0x0114B6E8
		public void Release()
		{
			this.Reset();
			if (this.InPool)
			{
				return;
			}
			List<GeneralContext> list;
			if (!GeneralContext.Pool.TryGetValue((int)this.Type.Value, out list))
			{
				list = new List<GeneralContext>();
				GeneralContext.Pool[(int)this.Type.Value] = list;
			}
			list.Add(this);
			this.InPool = true;
		}

		// Token: 0x060434F6 RID: 275702 RVA: 0x0114D548 File Offset: 0x0114B748
		[return: Nullable(2)]
		public static GeneralContext Copy(GeneralContext obj)
		{
			if (obj == null)
			{
				return null;
			}
			GeneralContext result = null;
			EGeneralContextType? type = obj.Type;
			if (type != null)
			{
				switch (type.GetValueOrDefault())
				{
				case EGeneralContextType.Entity:
					result = EntityContext.Create((obj as EntityContext).EntityId.GetValueOrDefault(), obj.SubType);
					break;
				case EGeneralContextType.Quest:
					result = QuestContext.Create((obj as QuestContext).QuestId, obj.SubType);
					break;
				case EGeneralContextType.LevelPlay:
					result = LevelPlayContext.Create((obj as LevelPlayContext).LevelPlayId, obj.SubType);
					break;
				case EGeneralContextType.InstanceDungeon:
					result = InstanceDungeonContext.Create((obj as InstanceDungeonContext).InstanceDungeonId.GetValueOrDefault(), 0, obj.SubType);
					break;
				case EGeneralContextType.Trigger:
				{
					TriggerContext triggerContext = obj as TriggerContext;
					result = TriggerContext.Create(triggerContext.TriggerEntityId.GetValueOrDefault(), triggerContext.OtherEntityId.GetValueOrDefault(), obj.SubType, new ETriggerEventType?(triggerContext.TriggerType), null);
					break;
				}
				case EGeneralContextType.GeneralLogicTree:
				{
					GeneralLogicTreeContext generalLogicTreeContext = obj as GeneralLogicTreeContext;
					result = GeneralLogicTreeContext.Create(generalLogicTreeContext.BtType, generalLogicTreeContext.TreeIncId, generalLogicTreeContext.TreeConfigId, generalLogicTreeContext.NodeId, obj.SubType);
					break;
				}
				case EGeneralContextType.Guarantee:
				{
					GuaranteeContext guaranteeContext = obj as GuaranteeContext;
					result = GuaranteeContext.Create(obj.SubType, guaranteeContext.GuaranteeReason);
					break;
				}
				case EGeneralContextType.Plot:
					result = PlotContext.Create((obj as PlotContext).FlowIncId, obj.SubType);
					break;
				case EGeneralContextType.ClientEvent:
				{
					ClientEventContext clientEventContext = obj as ClientEventContext;
					result = ClientEventContext.Create(clientEventContext.EventName.Value, clientEventContext.Params);
					break;
				}
				case EGeneralContextType.Combination:
					result = CombinationContext.Create((obj as CombinationContext).Contexts.ToArray());
					break;
				case EGeneralContextType.DynamicInteract:
				{
					DynamicInteractContext dynamicInteractContext = obj as DynamicInteractContext;
					result = DynamicInteractContext.Create(dynamicInteractContext.EntityId.GetValueOrDefault(), dynamicInteractContext.FinalContext, obj.SubType);
					break;
				}
				case EGeneralContextType.SplinePointArrival:
				{
					SplinePointArrivalContext splinePointArrivalContext = obj as SplinePointArrivalContext;
					result = SplinePointArrivalContext.Create(splinePointArrivalContext.EntityId, splinePointArrivalContext.SplineId, splinePointArrivalContext.PointIndex);
					break;
				}
				}
			}
			return result;
		}

		// Token: 0x060434F7 RID: 275703 RVA: 0x0114D778 File Offset: 0x0114B978
		[return: Nullable(2)]
		public static T ExtractContext<[Nullable(0)] T>(GeneralContext context, EGeneralContextType targetType) where T : GeneralContext
		{
			EGeneralContextType? type = context.Type;
			if (type.GetValueOrDefault() == targetType & type != null)
			{
				return context as T;
			}
			if (context.Type != EGeneralContextType.Combination)
			{
				return default(T);
			}
			GeneralContext contextByType = (context as CombinationContext).GetContextByType<GeneralContext>(targetType);
			if (contextByType == null)
			{
				return default(T);
			}
			return contextByType as T;
		}

		// Token: 0x060434F8 RID: 275704 RVA: 0x0114D7F8 File Offset: 0x0114B9F8
		public static void CreateStaticDefaultValue()
		{
			GeneralContext.Pool = new Dictionary<int, List<GeneralContext>>();
		}

		// Token: 0x060434F9 RID: 275705 RVA: 0x0114D804 File Offset: 0x0114BA04
		public static void ResetStaticDefaultValue()
		{
			GeneralContext.Pool = null;
		}

		// Token: 0x0402588D RID: 153741
		private static Dictionary<int, List<GeneralContext>> Pool;

		// Token: 0x0402588E RID: 153742
		public EGeneralContextType? Type;

		// Token: 0x0402588F RID: 153743
		public GameCtxType? SubType;

		// Token: 0x04025890 RID: 153744
		private bool InPool;
	}
}
