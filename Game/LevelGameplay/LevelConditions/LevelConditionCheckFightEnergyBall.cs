using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006CFA RID: 27898
	public class LevelConditionCheckFightEnergyBall : LevelConditionBase
	{
		// Token: 0x06044428 RID: 279592 RVA: 0x011BB2F8 File Offset: 0x011B94F8
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			if (inConditionInfo.LimitParamsLength == 0)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.LevelCondition;
				ELogAuthor author = ELogAuthor.TL;
				string message = "配置错误！条件的参数不应该为空";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("inConditionInfo.Id", inConditionInfo.Id);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return false;
			}
			int num = int.Parse(inConditionInfo.GetLimitParams("能量球状态"));
			if (num < 0 || num > 2)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.LevelCondition;
				ELogAuthor author2 = ELogAuthor.TL;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(19, 1);
				defaultInterpolatedStringHandler.AppendLiteral("配置错误！条件");
				defaultInterpolatedStringHandler.AppendFormatted<int>(inConditionInfo.Id);
				defaultInterpolatedStringHandler.AppendLiteral("的能量球状态只能是0，1");
				instance2.Error(module2, author2, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
				return false;
			}
			EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
			float? num2;
			if (getCurrentEntity == null)
			{
				num2 = null;
			}
			else
			{
				WorldEntity entity = getCurrentEntity.Entity;
				if (entity == null)
				{
					num2 = null;
				}
				else
				{
					RoleElementComponent component = entity.GetComponent<RoleElementComponent>();
					num2 = ((component != null) ? new float?(component.RoleElementEnergy) : null);
				}
			}
			float? num3 = num2;
			float? num4;
			if (getCurrentEntity == null)
			{
				num4 = null;
			}
			else
			{
				WorldEntity entity2 = getCurrentEntity.Entity;
				if (entity2 == null)
				{
					num4 = null;
				}
				else
				{
					RoleElementComponent component2 = entity2.GetComponent<RoleElementComponent>();
					num4 = ((component2 != null) ? new float?(component2.RoleElementEnergyMax) : null);
				}
			}
			float? num5 = num4;
			float? num6 = num3;
			float num7 = 0f;
			if ((num6.GetValueOrDefault() == num7 & num6 != null) && num == 0)
			{
				return true;
			}
			num6 = num3;
			num7 = 0f;
			float? num8;
			if (num6.GetValueOrDefault() > num7 & num6 != null)
			{
				num6 = num3;
				num8 = num5;
				if ((num6.GetValueOrDefault() < num8.GetValueOrDefault() & (num6 != null & num8 != null)) && num == 2)
				{
					return true;
				}
			}
			num8 = num3;
			num6 = num5;
			return (num8.GetValueOrDefault() >= num6.GetValueOrDefault() & (num8 != null & num6 != null)) && num == 1;
		}
	}
}
