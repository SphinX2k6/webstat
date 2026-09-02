using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.World.Model;
using CSharpScript.Utils;

// Token: 0x02003463 RID: 13411
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class ExpressionTreeController : ControllerBase<ExpressionTreeController>
{
	// Token: 0x0601C21F RID: 115231 RVA: 0x00864F2C File Offset: 0x0086312C
	public ExpressionTree GetDamageExpression(Damage damageData)
	{
		ExpressionTree expressionTree = ModelBase<ExpressionTreeModel>.Instance.Get(damageData.Id);
		if (expressionTree != null)
		{
			return expressionTree;
		}
		ExpressionTree expressionTree2 = new ExpressionTree();
		ExpressionTree expressionTree3 = expressionTree2;
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(2, 1);
		defaultInterpolatedStringHandler.AppendLiteral("结算");
		defaultInterpolatedStringHandler.AppendFormatted<long>(damageData.Id);
		expressionTree3.Parse(defaultInterpolatedStringHandler.ToStringAndClear(), damageData.Condition, damageData.ConstVariables());
		ModelBase<ExpressionTreeModel>.Instance.Add(damageData.Id, expressionTree2);
		return expressionTree2;
	}

	// Token: 0x0601C220 RID: 115232 RVA: 0x00864FA8 File Offset: 0x008631A8
	public void DoDamageExpression(IExpressionContext context, Damage damageData, Entity attacker)
	{
		ExpressionTree damageExpression = this.GetDamageExpression(damageData);
		Dictionary<string, TFormulaValue> dictionary = new Dictionary<string, TFormulaValue>();
		dictionary["Attacker"] = attacker;
		damageExpression.Evaluate(context, dictionary);
	}

	// Token: 0x0601C221 RID: 115233 RVA: 0x00864FD0 File Offset: 0x008631D0
	public long GetEffectDamageId(long damageId, Entity attacker)
	{
		Damage? damageConfigById = ModelBase<DamageModel>.Instance.GetDamageConfigById(damageId);
		if (!string.IsNullOrEmpty((damageConfigById != null) ? damageConfigById.GetValueOrDefault().Condition : null))
		{
			long replaceDamageId = 0L;
			this.DoDamageExpression(new ReplaceDamageContext
			{
				ContextType = EContextType.ReplaceDamage,
				DamageCb = delegate(long id)
				{
					replaceDamageId = id;
				}
			}, damageConfigById.Value, attacker);
			return replaceDamageId;
		}
		return damageId;
	}

	// Token: 0x0601C222 RID: 115234 RVA: 0x00865050 File Offset: 0x00863250
	public bool ShouldPreResolveDamageIdByExecutionTiming(long damageId)
	{
		Damage? damageConfigById = ModelBase<DamageModel>.Instance.GetDamageConfigById(damageId);
		return damageConfigById != null && damageConfigById.GetValueOrDefault().ExecutionTiming == 1 && !string.IsNullOrEmpty((damageConfigById != null) ? damageConfigById.GetValueOrDefault().Condition : null);
	}

	// Token: 0x0601C223 RID: 115235 RVA: 0x008650B0 File Offset: 0x008632B0
	public bool CheckReplaceDamageWhenHit(long damageId)
	{
		Damage? damageConfigById = ModelBase<DamageModel>.Instance.GetDamageConfigById(damageId);
		return (damageConfigById == null || damageConfigById.GetValueOrDefault().ExecutionTiming != 0) && !string.IsNullOrEmpty((damageConfigById != null) ? damageConfigById.GetValueOrDefault().Condition : null);
	}

	// Token: 0x0400E31E RID: 58142
	private readonly Stat GetExpressionStat = Stat.Create("GetDamageExpression", "", "");

	// Token: 0x0400E31F RID: 58143
	private readonly Stat DoExpressionStat = Stat.Create("DoDamageExpression", "", "");
}
