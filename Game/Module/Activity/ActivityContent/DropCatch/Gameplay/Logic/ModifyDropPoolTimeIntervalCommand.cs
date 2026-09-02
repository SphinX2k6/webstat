using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.DropCatch.Gameplay.Logic
{
	// Token: 0x02006929 RID: 26921
	public class ModifyDropPoolTimeIntervalCommand : IDropCatchCommand
	{
		// Token: 0x06042D49 RID: 273737 RVA: 0x0112717C File Offset: 0x0112537C
		[NullableContext(1)]
		public void Execute(ICommandContext context, [Nullable(2)] object @params)
		{
			IModifyDropPoolTimeInterval[] modifiers = ((IModifyDropPoolTimeIntervalCommandParams)@params).Modifiers;
			int i = 0;
			while (i < modifiers.Length)
			{
				IModifyDropPoolTimeInterval modifyDropPoolTimeInterval = modifiers[i];
				if (modifyDropPoolTimeInterval.PoolId == null)
				{
					using (Dictionary<int, IDropPoolRuntime>.ValueCollection.Enumerator enumerator = context.GetLogicContext().GetGameplayDropItemMgr().GetDropPools().Values.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							IDropPoolRuntime dropPoolRuntime = enumerator.Current;
							DropCatchGameplayAttribute spawnTimeInterval = dropPoolRuntime.SpawnTimeInterval;
							if (spawnTimeInterval == null)
							{
								Log instance = Singleton<Log>.Instance;
								ELogModule module = ELogModule.DropCatch;
								ELogAuthor author = ELogAuthor.CB;
								string message = "掉落池时间间隔属性不存在";
								ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("PoolId", modifyDropPoolTimeInterval.PoolId);
								instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
							}
							else
							{
								context.GetLogicContext().GetGameplayModifierMgr().AddModifierToAttr(spawnTimeInterval, modifyDropPoolTimeInterval.Type, modifyDropPoolTimeInterval.Value, new float?(modifyDropPoolTimeInterval.Duration));
							}
						}
						goto IL_15E;
					}
					goto IL_D8;
				}
				goto IL_D8;
				IL_15E:
				i++;
				continue;
				IL_D8:
				DropCatchGameplayAttribute spawnTimeIntervalAttrByPoolId = context.GetLogicContext().GetGameplayDropItemMgr().GetSpawnTimeIntervalAttrByPoolId(modifyDropPoolTimeInterval.PoolId.Value);
				if (spawnTimeIntervalAttrByPoolId == null)
				{
					Log instance2 = Singleton<Log>.Instance;
					ELogModule module2 = ELogModule.DropCatch;
					ELogAuthor author2 = ELogAuthor.CB;
					string message2 = "掉落池时间间隔属性不存在";
					ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("PoolId", modifyDropPoolTimeInterval.PoolId);
					instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
					goto IL_15E;
				}
				context.GetLogicContext().GetGameplayModifierMgr().AddModifierToAttr(spawnTimeIntervalAttrByPoolId, modifyDropPoolTimeInterval.Type, modifyDropPoolTimeInterval.Value, new float?(modifyDropPoolTimeInterval.Duration));
				goto IL_15E;
			}
		}
	}
}
