using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;

namespace CSharpScript.Utils
{
	// Token: 0x020046C9 RID: 18121
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class ExpressionTreeModel : ModelBase<ExpressionTreeModel>
	{
		// Token: 0x0602F1F3 RID: 193011 RVA: 0x00B2A4A4 File Offset: 0x00B286A4
		protected override bool OnInit()
		{
			this._builtinFunc["EntityTagContainer"] = delegate(IExpressionContext context, TFormulaValue[] args)
			{
				Entity entity;
				if (args.Length < 1 || !args[0].TryGetEntity(out entity) || entity == null)
				{
					ExpressionTreeModel.AddContextError(context, "EntityTagContainer函数执行失败: entity为空");
					return default(TFormulaValue);
				}
				BaseTagComponent component = entity.GetComponent<BaseTagComponent>();
				if (component != null)
				{
					return TFormulaValue.FromTagContainer(component.TagContainer);
				}
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(23, 1);
				defaultInterpolatedStringHandler.AppendLiteral("获取实体TagContainer失败 实体ID");
				defaultInterpolatedStringHandler.AppendFormatted<int>(entity.Id);
				ExpressionTreeModel.AddContextError(context, defaultInterpolatedStringHandler.ToStringAndClear());
				return default(TFormulaValue);
			};
			this._builtinFunc["GetAttr"] = delegate(IExpressionContext context, TFormulaValue[] args)
			{
				Entity entity;
				if (args.Length < 2 || !args[0].TryGetEntity(out entity) || entity == null)
				{
					ExpressionTreeModel.AddContextError(context, "GetAttr函数执行失败: entity为空或不是有效实体");
					return TFormulaValue.FromDouble(0.0);
				}
				int num;
				if (!args[1].TryGetInt(out num))
				{
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(25, 1);
					defaultInterpolatedStringHandler.AppendLiteral("GetAttr函数执行失败: attrId不合法 ");
					defaultInterpolatedStringHandler.AppendFormatted<TFormulaValue>(args[1]);
					ExpressionTreeModel.AddContextError(context, defaultInterpolatedStringHandler.ToStringAndClear());
					return TFormulaValue.FromDouble(0.0);
				}
				EAttributeType eattributeType = (EAttributeType)num;
				if (eattributeType <= EAttributeType.None || num >= 143)
				{
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(25, 1);
					defaultInterpolatedStringHandler.AppendLiteral("GetAttr函数执行失败: attrId不合法 ");
					defaultInterpolatedStringHandler.AppendFormatted<int>(num);
					ExpressionTreeModel.AddContextError(context, defaultInterpolatedStringHandler.ToStringAndClear());
					return TFormulaValue.FromDouble(0.0);
				}
				BaseAttributeComponent component = entity.GetComponent<BaseAttributeComponent>();
				if (component == null)
				{
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(30, 1);
					defaultInterpolatedStringHandler.AppendLiteral("GetAttr函数执行失败: 获取实体属性组件失败 实体ID");
					defaultInterpolatedStringHandler.AppendFormatted<int>(entity.Id);
					ExpressionTreeModel.AddContextError(context, defaultInterpolatedStringHandler.ToStringAndClear());
					return TFormulaValue.FromDouble(0.0);
				}
				return TFormulaValue.FromDouble(Math.Floor((double)component.GetCurrentValue(eattributeType)));
			};
			this._builtinFunc["HasAnyTag"] = delegate(IExpressionContext context, TFormulaValue[] args)
			{
				TagContainer tagContainer;
				TagContainer tagContainer2;
				if (args.Length < 2 || !args[0].TryGetTagContainer(out tagContainer) || !args[1].TryGetTagContainer(out tagContainer2) || tagContainer == null || tagContainer2 == null)
				{
					ExpressionTreeModel.AddContextError(context, "HasAnyTag函数执行失败: tagContainerA为空");
					return TFormulaValue.FromBool(false);
				}
				return TFormulaValue.FromBool(tagContainer.HasAnyTag(tagContainer2));
			};
			this._builtinFunc["HasAllTag"] = delegate(IExpressionContext context, TFormulaValue[] args)
			{
				TagContainer tagContainer;
				TagContainer tagContainer2;
				if (args.Length < 2 || !args[0].TryGetTagContainer(out tagContainer) || !args[1].TryGetTagContainer(out tagContainer2) || tagContainer == null || tagContainer2 == null)
				{
					ExpressionTreeModel.AddContextError(context, "HasAllTag函数执行失败: tagContainerA为空");
					return TFormulaValue.FromBool(false);
				}
				return TFormulaValue.FromBool(tagContainer.HasAllTag(tagContainer2));
			};
			this._builtinFunc["ExecDamage"] = delegate(IExpressionContext context, TFormulaValue[] args)
			{
				double num;
				if (args.Length < 1 || !args[0].TryGetDouble(out num))
				{
					ExpressionTreeModel.AddContextError(context, "ExecDamage函数执行失败: damageId为空");
					return TFormulaValue.FromBool(false);
				}
				long num2 = (long)num;
				BulletDamageContext bulletDamageContext = context as BulletDamageContext;
				if (bulletDamageContext != null)
				{
					bulletDamageContext.DamageParam.DamageDataId = num2;
					BulletDamageResult bulletDamageResult = bulletDamageContext.Victim.ExecuteBulletDamage(bulletDamageContext.BulletEntityId, bulletDamageContext.DamageParam, bulletDamageContext.ContextId);
					BulletDamageResult result = bulletDamageContext.Result;
					result.ToughResult += bulletDamageResult.ToughResult;
					result.IsAddEnergy = (result.IsAddEnergy || bulletDamageResult.IsAddEnergy);
					return TFormulaValue.FromBool(true);
				}
				BuffDamageContext buffDamageContext = context as BuffDamageContext;
				if (buffDamageContext != null)
				{
					buffDamageContext.DamageParam.DamageDataId = num2;
					buffDamageContext.Victim.ExecuteBuffDamage(buffDamageContext.DamageParam, buffDamageContext.Payload, buffDamageContext.ContextId);
					return TFormulaValue.FromBool(true);
				}
				BuffShareDamageContext buffShareDamageContext = context as BuffShareDamageContext;
				if (buffShareDamageContext != null)
				{
					buffShareDamageContext.DamageParam.DamageDataId = num2;
					buffShareDamageContext.Victim.ExecuteBuffShareDamage(buffShareDamageContext.DamageParam, buffShareDamageContext.Payload, buffShareDamageContext.ExtraRate, buffShareDamageContext.ContextId);
					return TFormulaValue.FromBool(true);
				}
				ReplaceDamageContext replaceDamageContext = context as ReplaceDamageContext;
				if (replaceDamageContext != null)
				{
					replaceDamageContext.DamageCb(num2);
					return TFormulaValue.FromBool(true);
				}
				return TFormulaValue.FromBool(false);
			};
			this._builtinFunc["NotHasAnyTag"] = delegate(IExpressionContext context, TFormulaValue[] args)
			{
				TagContainer tagContainer;
				TagContainer tagContainer2;
				if (args.Length < 2 || !args[0].TryGetTagContainer(out tagContainer) || !args[1].TryGetTagContainer(out tagContainer2) || tagContainer == null || tagContainer2 == null)
				{
					ExpressionTreeModel.AddContextError(context, "NotHasAnyTag函数执行失败: tagContainerA为空");
					return TFormulaValue.FromBool(false);
				}
				return TFormulaValue.FromBool(tagContainer.NotHasAnyTag(tagContainer2));
			};
			this._builtinFunc["NotHasAllTag"] = delegate(IExpressionContext context, TFormulaValue[] args)
			{
				TagContainer tagContainer;
				TagContainer tagContainer2;
				if (args.Length < 2 || !args[0].TryGetTagContainer(out tagContainer) || !args[1].TryGetTagContainer(out tagContainer2) || tagContainer == null || tagContainer2 == null)
				{
					ExpressionTreeModel.AddContextError(context, "NotHasAllTag函数执行失败: tagContainerA为空");
					return TFormulaValue.FromBool(false);
				}
				return TFormulaValue.FromBool(tagContainer.NotHasAllTag(tagContainer2));
			};
			return base.OnInit();
		}

		// Token: 0x0602F1F4 RID: 193012 RVA: 0x00B2A600 File Offset: 0x00B28800
		protected override bool OnClear()
		{
			this._expressionCache.Clear();
			return base.OnClear();
		}

		// Token: 0x0602F1F5 RID: 193013 RVA: 0x00B2A614 File Offset: 0x00B28814
		[NullableContext(2)]
		public ExpressionTree Get(long damageId)
		{
			ExpressionTree result;
			this._expressionCache.TryGetValue(damageId, out result);
			return result;
		}

		// Token: 0x0602F1F6 RID: 193014 RVA: 0x00B2A634 File Offset: 0x00B28834
		public void Add(long damageId, ExpressionTree expression)
		{
			this._expressionCache[damageId] = expression;
			if (this._expressionCache.Count > 100)
			{
				using (Dictionary<long, ExpressionTree>.KeyCollection.Enumerator enumerator = this._expressionCache.Keys.GetEnumerator())
				{
					if (enumerator.MoveNext())
					{
						this._expressionCache.Remove(enumerator.Current);
					}
				}
			}
		}

		// Token: 0x0602F1F7 RID: 193015 RVA: 0x00B2A6AC File Offset: 0x00B288AC
		public void Remove(long damageId)
		{
			this._expressionCache.Remove(damageId);
		}

		// Token: 0x0602F1F8 RID: 193016 RVA: 0x00B2A6BC File Offset: 0x00B288BC
		[return: Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		public Func<IExpressionContext, TFormulaValue[], TFormulaValue> GetBuiltinFunc(string funcName)
		{
			Func<IExpressionContext, TFormulaValue[], TFormulaValue> result;
			if (this._builtinFunc.TryGetValue(funcName, out result))
			{
				return result;
			}
			return null;
		}

		// Token: 0x0602F1F9 RID: 193017 RVA: 0x00B2A6DC File Offset: 0x00B288DC
		private static void AddContextError([Nullable(2)] IExpressionContext context, string error)
		{
			BaseContext baseContext = context as BaseContext;
			if (baseContext == null)
			{
				return;
			}
			BaseContext baseContext2 = baseContext;
			if (baseContext2.ErrorMsg == null)
			{
				baseContext2.ErrorMsg = new List<string>();
			}
			baseContext.ErrorMsg.Add(error);
		}

		// Token: 0x0401AD82 RID: 109954
		private const int DAMAGE_EXPRESSION_CACHE = 100;

		// Token: 0x0401AD83 RID: 109955
		private readonly Dictionary<long, ExpressionTree> _expressionCache = new Dictionary<long, ExpressionTree>();

		// Token: 0x0401AD84 RID: 109956
		private readonly Dictionary<string, Func<IExpressionContext, TFormulaValue[], TFormulaValue>> _builtinFunc = new Dictionary<string, Func<IExpressionContext, TFormulaValue[], TFormulaValue>>();
	}
}
