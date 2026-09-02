using System;

namespace CSharpScript.Game.Ui
{
	// Token: 0x02004A08 RID: 18952
	public class UiProhibitFightInputDistribute : InputDistributeSetup
	{
		// Token: 0x060318D5 RID: 202965 RVA: 0x00C59D44 File Offset: 0x00C57F44
		public unsafe override bool OnRefresh()
		{
			InputDistributeModel instance = ModelBase<InputDistributeModel>.Instance;
			if (instance == null)
			{
				return false;
			}
			if (!instance.HasAnyNotAllowFightInputViewIsOpen())
			{
				return false;
			}
			string text = Singleton<UiProhibitFightInputCenter>.Instance.CheckExtraRefreshData();
			if (!StringUtils.IsBlank(text))
			{
				string[] distributeTags = Singleton<UiProhibitFightInputCenter>.Instance.GetExtraRefreshData(text).GetDistributeTags();
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Input;
				ELogAuthor author = ELogAuthor.XXJ;
				string message = "[InputDistribute]禁止战斗输入的界面的输入分发,检测到额外注册的刷新数据条件判断成功";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("NotAllowFightInputViewNameSet", instance.GetNotAllowFightInputViewNameSet());
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("额外注册名字", text);
				instance2.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				base.SetInputDistributeTags(distributeTags);
				return true;
			}
			Log instance3 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Input;
			ELogAuthor author2 = ELogAuthor.XXJ;
			string message2 = "[InputDistribute]禁止战斗输入的界面的输入分发，有不允许战斗输入的界面打开";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("NotAllowFightInputViewNameSet", instance.GetNotAllowFightInputViewNameSet());
			instance3.Info(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			base.SetInputDistributeTags(new string[]
			{
				"UiInputRoot.ShortcutKeyTag",
				"UiInputRoot.MouseInputTag",
				"UiInputRoot.Navigation"
			});
			return true;
		}
	}
}
