using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Module.Plot.Flow;

namespace CSharpScript.Game.Module.Plot.FlowActions
{
	// Token: 0x0200540E RID: 21518
	[NullableContext(1)]
	[Nullable(0)]
	public class FlowActionAwakeEntity : FlowActionServerAction
	{
		// Token: 0x06036F04 RID: 225028 RVA: 0x00DF1D78 File Offset: 0x00DEFF78
		protected unsafe override void OnExecute()
		{
			if (ModelBase<AutoRunModel>.Instance.IsInLogicTreeGmMode())
			{
				base.FinishExecute(true, true);
				return;
			}
			if (this.ActionInfo.Params == null)
			{
				base.FinishExecute(true, true);
				return;
			}
			AwakeEntity awakeEntity = this.ActionInfo.Params as AwakeEntity;
			if (((awakeEntity != null) ? awakeEntity.EntityIds : null) == null || awakeEntity.EntityIds.Count == 0)
			{
				base.FinishExecute(true, true);
				return;
			}
			bool flag = false;
			List<int> list = new List<int>();
			foreach (int num in awakeEntity.EntityIds)
			{
				bool? flag2 = FlowActionUtils.CheckEntityInAoi(num);
				bool flag3 = false;
				if (flag2.GetValueOrDefault() == flag3 & flag2 != null)
				{
					global::Log instance = Singleton<global::Log>.Instance;
					ELogModule module = ELogModule.Plot;
					ELogAuthor author = ELogAuthor.FZX;
					string message = "剧情中唤醒实体过远，请检查配置";
					<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("pbDataId", num);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("flow", this.Context.FormatId);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("id", this.ActionInfo.ActionId);
					instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
					flag = true;
				}
				else
				{
					list.Add(num);
				}
			}
			if (!flag)
			{
				this.AwakeEntity(awakeEntity.EntityIds);
				return;
			}
			base.RequestServerAction(false, null);
			if (list.Count == 0)
			{
				base.FinishExecute(true, true);
				return;
			}
			this.AwakeEntity(list);
		}

		// Token: 0x06036F05 RID: 225029 RVA: 0x00DF1F20 File Offset: 0x00DF0120
		private void AwakeEntity(List<int> entityIds)
		{
			if (entityIds.Count == 0)
			{
				return;
			}
			foreach (int pbDataId in entityIds)
			{
				ControllerBase<CreatureController>.Instance.RecoverDensityEntity(pbDataId, "Plot");
			}
			this.AwakeEntityIds = entityIds;
			this.Task = WaitEntityTask.CreateWithPbDataId("FlowActionAwakeEntity.OnExecute", entityIds, new Action<bool?>(this.OnEntityReady), 20000, false, false);
		}

		// Token: 0x06036F06 RID: 225030 RVA: 0x00DF1FAC File Offset: 0x00DF01AC
		private void OnEntityReady(bool? result)
		{
			this.Task = null;
			if (!result.GetValueOrDefault())
			{
				ControllerBase<FlowController>.Instance.LogError("加载实体失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			if (this.AwakeEntityIds != null)
			{
				List<int> list = new List<int>();
				foreach (int num in this.AwakeEntityIds)
				{
					EntityHandle entityByPbDataId = ModelBase<CreatureModel>.Instance.GetEntityByPbDataId(num);
					if (entityByPbDataId == null)
					{
						list.Add(num);
					}
					else
					{
						ControllerBase<CreatureController>.Instance.SetEntityEnable(entityByPbDataId.Entity, true, "FlowActionAwakeEntity.OnEntityReady", false);
					}
				}
				if (list.Count > 0)
				{
					FlowController instance = ControllerBase<FlowController>.Instance;
					string text = "AwakeEntity失败的实体列表";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("pbDataIds", list);
					instance.LogError(text, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				}
			}
			this.AwakeEntityIds = null;
			base.RecordAction(null);
			base.FinishExecute(true, true);
		}

		// Token: 0x06036F07 RID: 225031 RVA: 0x00DF20A8 File Offset: 0x00DF02A8
		protected override void OnBackgroundExecute()
		{
			this.OnExecute();
		}

		// Token: 0x06036F08 RID: 225032 RVA: 0x00DF20B0 File Offset: 0x00DF02B0
		protected override void OnInterruptExecute()
		{
			WaitEntityTask task = this.Task;
			if (task != null)
			{
				task.Cancel();
			}
			this.Task = null;
			this.AwakeEntityIds = null;
			base.FinishExecute(true, true);
		}

		// Token: 0x06036F09 RID: 225033 RVA: 0x00DF20DC File Offset: 0x00DF02DC
		protected override void OnRollback(ActionRecord actionRecord, FlowContext context)
		{
			foreach (int pbDataId in (actionRecord.ActionInfo.Params as AwakeEntity).EntityIds)
			{
				EntityHandle entityByPbDataId = ModelBase<CreatureModel>.Instance.GetEntityByPbDataId(pbDataId);
				if (entityByPbDataId != null && entityByPbDataId.IsInit)
				{
					ControllerBase<CreatureController>.Instance.SetEntityEnable(entityByPbDataId.Entity, false, "FlowActionAwakeEntity.OnRollback", false);
				}
			}
		}

		// Token: 0x0401F9F8 RID: 129528
		[Nullable(2)]
		public WaitEntityTask Task;

		// Token: 0x0401F9F9 RID: 129529
		[Nullable(2)]
		private List<int> AwakeEntityIds;
	}
}
