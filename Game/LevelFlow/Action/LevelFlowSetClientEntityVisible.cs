using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.LevelFlow.Action
{
	// Token: 0x02006FA9 RID: 28585
	public class LevelFlowSetClientEntityVisible : LevelFlowActionBase
	{
		// Token: 0x06045224 RID: 283172 RVA: 0x012099EF File Offset: 0x01207BEF
		[NullableContext(1)]
		public LevelFlowSetClientEntityVisible Init(SetEntityClientVisible param)
		{
			this.Param = param;
			return this;
		}

		// Token: 0x06045225 RID: 283173 RVA: 0x012099FC File Offset: 0x01207BFC
		protected override void OnExecute()
		{
			SetEntityClientVisible param = this.Param;
			if (param == null)
			{
				Singleton<global::Log>.Instance.Error(ELogModule.LevelFlow, ELogAuthor.BB, "参数类型错误", default(ReadOnlySpan<ValueTuple<string, object>>));
				base.FinishExecute(false);
				return;
			}
			if (param.EntityIds == null || param.EntityIds.Count == 0)
			{
				Singleton<global::Log>.Instance.Error(ELogModule.LevelEvent, ELogAuthor.CH, "目标Entity未配置", default(ReadOnlySpan<ValueTuple<string, object>>));
				base.FinishExecute(false);
				return;
			}
			foreach (int num in param.EntityIds)
			{
				EntityHandle entityByPbDataId = ModelBase<CreatureModel>.Instance.GetEntityByPbDataId(num);
				WorldEntity worldEntity = (entityByPbDataId != null) ? entityByPbDataId.Entity : null;
				if (worldEntity == null || !worldEntity.Valid)
				{
					global::Log instance = Singleton<global::Log>.Instance;
					ELogModule module = ELogModule.LevelEvent;
					ELogAuthor author = ELogAuthor.CH;
					string message = "目标Entity不存在";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("PbDataId", num);
					instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				}
				else
				{
					ControllerBase<CreatureController>.Instance.SetEntityEnable(worldEntity, param.Visible, "LevelEventSetClientEntityVisible", true);
				}
			}
			base.FinishExecute(true);
		}

		// Token: 0x06045226 RID: 283174 RVA: 0x01209B30 File Offset: 0x01207D30
		protected unsafe override void LogExecuteInfo()
		{
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.LevelFlow;
			ELogAuthor author = ELogAuthor.BB;
			string message = "执行行为";
			<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("ActionId", this.ActionId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("ActionName", base.GetType().Name);
			ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2);
			string item = "EntityIds";
			SetEntityClientVisible param = this.Param;
			ptr = new ValueTuple<string, object>(item, (((param != null) ? param.EntityIds : null) != null) ? string.Join<int>(",", this.Param.EntityIds) : null);
			ref ValueTuple<string, object> ptr2 = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3);
			string item2 = "Visible";
			SetEntityClientVisible param2 = this.Param;
			ptr2 = new ValueTuple<string, object>(item2, (param2 != null) ? new bool?(param2.Visible) : null);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
		}

		// Token: 0x04026929 RID: 157993
		[Nullable(2)]
		private SetEntityClientVisible Param;
	}
}
