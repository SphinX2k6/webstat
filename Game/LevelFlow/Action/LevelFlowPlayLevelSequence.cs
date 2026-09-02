using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.LevelFlow.Action
{
	// Token: 0x02006F9E RID: 28574
	public class LevelFlowPlayLevelSequence : LevelFlowActionBase
	{
		// Token: 0x060451F2 RID: 283122 RVA: 0x01208B5E File Offset: 0x01206D5E
		[NullableContext(1)]
		public LevelFlowPlayLevelSequence Init(PlayLevelSequence params_)
		{
			this.Params = params_;
			return this;
		}

		// Token: 0x060451F3 RID: 283123 RVA: 0x01208B68 File Offset: 0x01206D68
		protected override void OnExecute()
		{
			if (this.Params == null)
			{
				Singleton<global::Log>.Instance.Error(ELogModule.LevelFlow, ELogAuthor.BB, "参数类型错误", default(ReadOnlySpan<ValueTuple<string, object>>));
				base.FinishExecute(false);
				return;
			}
			if (string.IsNullOrEmpty(this.Params.LevelSequencePath))
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.LevelFlow;
				ELogAuthor author = ELogAuthor.BB;
				string message = "LevelSequence路径为空";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Context", null);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				base.FinishExecute(false);
			}
			LevelFlowResourceManager.HandleSequence(this.Params);
			base.FinishExecute(true);
		}

		// Token: 0x060451F4 RID: 283124 RVA: 0x01208BFC File Offset: 0x01206DFC
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
			string item = "LevelSequencePath";
			PlayLevelSequence @params = this.Params;
			ptr = new ValueTuple<string, object>(item, (@params != null) ? @params.LevelSequencePath : null);
			ref ValueTuple<string, object> ptr2 = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3);
			string item2 = "Mark";
			PlayLevelSequence params2 = this.Params;
			ptr2 = new ValueTuple<string, object>(item2, (params2 != null) ? params2.Mark : null);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
		}

		// Token: 0x0402690B RID: 157963
		[Nullable(2)]
		private PlayLevelSequence Params;
	}
}
