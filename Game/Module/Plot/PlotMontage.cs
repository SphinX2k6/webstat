using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.Module.Plot
{
	// Token: 0x02005374 RID: 21364
	public class PlotMontage
	{
		// Token: 0x060367AD RID: 223149 RVA: 0x00DBFCB0 File Offset: 0x00DBDEB0
		[NullableContext(2)]
		public void StartPlayMontage(PlayMontage inMontageData)
		{
			if (inMontageData == null)
			{
				return;
			}
			if (string.IsNullOrEmpty(inMontageData.ActionMontage.Path) || inMontageData.ActionMontage.Path == "Empty")
			{
				return;
			}
			EntityHandle entityHandle = (inMontageData.EntityId == 0) ? ModelBase<PlotModel>.Instance.CurrentInteractEntity : ModelBase<CreatureModel>.Instance.GetEntityByPbDataId(inMontageData.EntityId);
			if (entityHandle == null || !entityHandle.IsInit)
			{
				return;
			}
			WorldEntity entity = entityHandle.Entity;
			BasePerformComponent basePerformComponent = (entity != null) ? entity.GetComponent<BasePerformComponent>() : null;
			if (basePerformComponent == null)
			{
				return;
			}
			basePerformComponent.OnNpcInPlot(true);
			basePerformComponent.PlayPerformMontage(EPerformMode.Plot, new IPlayMontageParam
			{
				MontagePath = inMontageData.ActionMontage.Path,
				IsLoop = new bool?(false)
			}, null, null, false);
			this.EntitySet.Add(entityHandle);
		}

		// Token: 0x060367AE RID: 223150 RVA: 0x00DBFD7C File Offset: 0x00DBDF7C
		public void StopAllMontage()
		{
			foreach (EntityHandle entityHandle in this.EntitySet)
			{
				if (entityHandle.Valid)
				{
					WorldEntity entity = entityHandle.Entity;
					CommonNpcPerformComponent commonNpcPerformComponent = (entity != null) ? entity.GetComponent<CommonNpcPerformComponent>() : null;
					if (commonNpcPerformComponent == null)
					{
						return;
					}
					commonNpcPerformComponent.StopPerformMontage(EPerformMode.Plot, new IStopMontageParam
					{
						Method = new EStopMethod?(EStopMethod.BlendOut)
					}, null, null);
					commonNpcPerformComponent.OnNpcInPlot(false);
				}
			}
			this.EntitySet.Clear();
		}

		// Token: 0x0401F5D4 RID: 128468
		[Nullable(1)]
		private readonly HashSet<EntityHandle> EntitySet = new HashSet<EntityHandle>();
	}
}
