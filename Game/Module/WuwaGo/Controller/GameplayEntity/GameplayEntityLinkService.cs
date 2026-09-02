using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using Aki.TDConfigMgr.Component;
using CSharpScript.Game.Module.WuwaGo.Model;
using CSharpScript.Game.Module.WuwaGo.Model.GameplayEntity;

namespace CSharpScript.Game.Module.WuwaGo.Controller.GameplayEntity
{
	// Token: 0x02004B0B RID: 19211
	[NullableContext(1)]
	[Nullable(0)]
	public class GameplayEntityLinkService : IGameplayEntityLinkService
	{
		// Token: 0x0603219A RID: 205210 RVA: 0x00C893E1 File Offset: 0x00C875E1
		public GameplayEntityLinkService(WuWaGoGameData gameData)
		{
		}

		// Token: 0x0603219B RID: 205211 RVA: 0x00C893FB File Offset: 0x00C875FB
		public IReadOnlyList<int> GetLinkedGroupPbDataIds(int sourcePbDataId)
		{
			return this.<gameData>P.GetLinkedGameplayEntityGroupPbDataIds(sourcePbDataId);
		}

		// Token: 0x0603219C RID: 205212 RVA: 0x00C89409 File Offset: 0x00C87609
		public int GetLinkedGroupRootPbDataId(int sourcePbDataId)
		{
			return this.<gameData>P.GetLinkedGameplayEntityGroupRootPbDataId(sourcePbDataId);
		}

		// Token: 0x0603219D RID: 205213 RVA: 0x00C89417 File Offset: 0x00C87617
		public IReadOnlyList<ActionInfo> FilterLinkedActionList(int sourcePbDataId, IReadOnlyList<ActionInfo> actionList)
		{
			return this.<gameData>P.FilterLinkedGameplayEntityActionList(sourcePbDataId, actionList);
		}

		// Token: 0x0603219E RID: 205214 RVA: 0x00C89428 File Offset: 0x00C87628
		public void SyncLinkedEntityState(int sourcePbDataId, EGameplayEntityState targetState)
		{
			foreach (int num in this.GetLinkedGroupPbDataIds(sourcePbDataId))
			{
				WuWaGoGameplayEntityBase gameplayEntityByPbDataId = this.<gameData>P.GetGameplayEntityByPbDataId(num);
				if (gameplayEntityByPbDataId == null)
				{
					global::Log instance = Singleton<global::Log>.Instance;
					ELogModule module = ELogModule.WuWaGo;
					ELogAuthor author = ELogAuthor.YSQ;
					string message = "联通机关同步失败，目标实体不存在";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("pbDataId", num);
					instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				}
				else
				{
					gameplayEntityByPbDataId.SetState(targetState);
				}
			}
		}

		// Token: 0x0603219F RID: 205215 RVA: 0x00C894B8 File Offset: 0x00C876B8
		public void OnRollbackRestore()
		{
			this.RebuildPressureTriggerGroupPressedState();
		}

		// Token: 0x060321A0 RID: 205216 RVA: 0x00C894C0 File Offset: 0x00C876C0
		[return: Nullable(new byte[]
		{
			0,
			1,
			1
		})]
		public ValueTuple<bool, IReadOnlyList<ActionInfo>>? ConsumePressureTriggerGroupChange(int sourcePbDataId)
		{
			WuWaGoPressureTriggerEntity wuWaGoPressureTriggerEntity = this.<gameData>P.GetGameplayEntityByPbDataId(sourcePbDataId) as WuWaGoPressureTriggerEntity;
			if (wuWaGoPressureTriggerEntity == null)
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.WuWaGo;
				ELogAuthor author = ELogAuthor.YSQ;
				string message = "联通压力板结算失败，源实体类型不正确";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("pbDataId", sourcePbDataId);
				instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return null;
			}
			int linkedGroupRootPbDataId = this.GetLinkedGroupRootPbDataId(sourcePbDataId);
			bool flag2;
			bool flag = this.PressureTriggerGroupPressedState.TryGetValue(linkedGroupRootPbDataId, out flag2) && flag2;
			bool flag3 = this.IsPressureTriggerGroupPressed(sourcePbDataId);
			this.PressureTriggerGroupPressedState[linkedGroupRootPbDataId] = flag3;
			this.SyncLinkedEntityState(sourcePbDataId, flag3 ? EGameplayEntityState.Activated : EGameplayEntityState.Normal);
			if (!flag && flag3)
			{
				return new ValueTuple<bool, IReadOnlyList<ActionInfo>>?(new ValueTuple<bool, IReadOnlyList<ActionInfo>>(true, this.FilterLinkedActionList(sourcePbDataId, wuWaGoPressureTriggerEntity.EnterActionList)));
			}
			if (flag && !flag3)
			{
				return new ValueTuple<bool, IReadOnlyList<ActionInfo>>?(new ValueTuple<bool, IReadOnlyList<ActionInfo>>(false, this.FilterLinkedActionList(sourcePbDataId, wuWaGoPressureTriggerEntity.ExitActionList)));
			}
			return null;
		}

		// Token: 0x060321A1 RID: 205217 RVA: 0x00C895A8 File Offset: 0x00C877A8
		private void RebuildPressureTriggerGroupPressedState()
		{
			this.PressureTriggerGroupPressedState.Clear();
			IReadOnlyList<WuWaGoGameplayEntityBase> gameplayEntitiesByType = this.<gameData>P.GetGameplayEntitiesByType(EWuWaGoEntityType.PressureTrigger);
			HashSet<int> hashSet = new HashSet<int>();
			foreach (WuWaGoGameplayEntityBase wuWaGoGameplayEntityBase in gameplayEntitiesByType)
			{
				WuWaGoPressureTriggerEntity wuWaGoPressureTriggerEntity = wuWaGoGameplayEntityBase as WuWaGoPressureTriggerEntity;
				if (wuWaGoPressureTriggerEntity != null && wuWaGoPressureTriggerEntity.Dirty)
				{
					hashSet.Add(this.GetLinkedGroupRootPbDataId(wuWaGoPressureTriggerEntity.EntityPbDataId));
				}
			}
			foreach (WuWaGoGameplayEntityBase wuWaGoGameplayEntityBase2 in gameplayEntitiesByType)
			{
				if (wuWaGoGameplayEntityBase2 is WuWaGoPressureTriggerEntity)
				{
					int linkedGroupRootPbDataId = this.GetLinkedGroupRootPbDataId(wuWaGoGameplayEntityBase2.EntityPbDataId);
					bool flag;
					if (!hashSet.Contains(linkedGroupRootPbDataId) && (!this.PressureTriggerGroupPressedState.TryGetValue(linkedGroupRootPbDataId, out flag) || !flag))
					{
						bool value = this.IsPressureTriggerGroupPressed(wuWaGoGameplayEntityBase2.EntityPbDataId);
						this.PressureTriggerGroupPressedState[linkedGroupRootPbDataId] = value;
					}
				}
			}
		}

		// Token: 0x060321A2 RID: 205218 RVA: 0x00C896B0 File Offset: 0x00C878B0
		private bool IsPressureTriggerGroupPressed(int sourcePbDataId)
		{
			foreach (int pbDataId in this.GetLinkedGroupPbDataIds(sourcePbDataId))
			{
				WuWaGoPressureTriggerEntity wuWaGoPressureTriggerEntity = this.<gameData>P.GetGameplayEntityByPbDataId(pbDataId) as WuWaGoPressureTriggerEntity;
				if (wuWaGoPressureTriggerEntity != null && wuWaGoPressureTriggerEntity.IsOccupied)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0401D493 RID: 119955
		[CompilerGenerated]
		private WuWaGoGameData <gameData>P = gameData;

		// Token: 0x0401D494 RID: 119956
		private readonly Dictionary<int, bool> PressureTriggerGroupPressedState = new Dictionary<int, bool>();
	}
}
