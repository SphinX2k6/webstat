using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.LevelGamePlay.Guarantee;
using CSharpScript.Game.Module.BattleUi;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006B8D RID: 27533
	public class LevelEventEnableKey4Func : LevelEventBase
	{
		// Token: 0x06043F49 RID: 278345 RVA: 0x0119AC44 File Offset: 0x01198E44
		public LevelEventEnableKey4Func(int id) : base(id)
		{
		}

		// Token: 0x06043F4A RID: 278346 RVA: 0x0119AC50 File Offset: 0x01198E50
		[NullableContext(1)]
		public unsafe override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			EnableKey4Func enableKey4Func = inParams as EnableKey4Func;
			if (enableKey4Func == null)
			{
				base.FinishExecute(false, false, true);
				return;
			}
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.Photograph;
			ELogAuthor author = ELogAuthor.LJM;
			string message = "[LevelEventEnableKey4Func]";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Enable", enableKey4Func.IsEnable);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("FuncKey", enableKey4Func.FuncKey);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			this.Enable = enableKey4Func.IsEnable;
			if (enableKey4Func.FuncKey == EEnableKey4FuncKey.TimeScaled)
			{
				ModelBase<BattleUiModel>.Instance.SetTimeDilationSkillButtonEnable(enableKey4Func.IsEnable);
			}
			base.FinishExecute(true, false, true);
		}

		// Token: 0x06043F4B RID: 278347 RVA: 0x0119AD08 File Offset: 0x01198F08
		protected override void OnUpdateGuarantee()
		{
			GuaranteeActionInfo p = new GuaranteeActionInfo
			{
				Name = EGuaranteeAction.DisableKey4Func
			};
			if (this.Enable)
			{
				Singleton<EventSystem>.Instance.Emit<string, GeneralContext, GuaranteeActionInfo, bool?>(EEventName.AddGuaranteeAction, this.Type, this.BaseContext, p, null);
				return;
			}
			Singleton<EventSystem>.Instance.Emit<string, GeneralContext, GuaranteeActionInfo, bool?>(EEventName.RemGuaranteeAction, this.Type, this.BaseContext, p, null);
		}

		// Token: 0x04026006 RID: 155654
		private bool Enable;
	}
}
