using System;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02001E23 RID: 7715
[NullableContext(1)]
[Nullable(0)]
public class GuideTestUtil : IStaticVariableResetter
{
	// Token: 0x0600E3D2 RID: 58322 RVA: 0x003D51F5 File Offset: 0x003D33F5
	static GuideTestUtil()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(GuideTestUtil.CreateStaticDefaultValue), new Action(GuideTestUtil.ResetStaticDefaultValue));
	}

	// Token: 0x0600E3D3 RID: 58323 RVA: 0x003D5214 File Offset: 0x003D3414
	public static void CreateStaticDefaultValue()
	{
		GuideTestUtil.GuideTestParams = new GuideTestParam();
	}

	// Token: 0x0600E3D4 RID: 58324 RVA: 0x003D5220 File Offset: 0x003D3420
	public static void ResetStaticDefaultValue()
	{
		GuideTestUtil.GuideTestParams = null;
	}

	// Token: 0x0600E3D5 RID: 58325 RVA: 0x003D5228 File Offset: 0x003D3428
	public static void Debug(string message, [ParamCollection] [ScopedRef] [Nullable(new byte[]
	{
		0,
		0,
		1,
		2
	})] ReadOnlySpan<ValueTuple<string, object>> pairs)
	{
	}

	// Token: 0x0600E3D6 RID: 58326 RVA: 0x003D522A File Offset: 0x003D342A
	public static void Error(string message, [ParamCollection] [ScopedRef] [Nullable(new byte[]
	{
		0,
		0,
		1,
		2
	})] ReadOnlySpan<ValueTuple<string, object>> pairs)
	{
		Singleton<Log>.Instance.Error(ELogModule.Guide, ELogAuthor.TZJ, message, pairs);
	}

	// Token: 0x0600E3D7 RID: 58327 RVA: 0x003D523C File Offset: 0x003D343C
	public static bool CheckIsTestGroup(int groupId)
	{
		return false;
	}

	// Token: 0x0600E3D8 RID: 58328 RVA: 0x003D523F File Offset: 0x003D343F
	public static bool CheckIsTestStep(int stepId)
	{
		return false;
	}

	// Token: 0x0600E3D9 RID: 58329 RVA: 0x003D5244 File Offset: 0x003D3444
	public static bool CheckIsGmTest(GuideFocusNew focusConfig)
	{
		return false;
	}

	// Token: 0x0600E3DA RID: 58330 RVA: 0x003D5254 File Offset: 0x003D3454
	public static bool TestGuideFocus(string[] gmArgs)
	{
		return false;
	}

	// Token: 0x04006D8F RID: 28047
	private const int TEST_GROUP_ID = 90036;

	// Token: 0x04006D90 RID: 28048
	private const int TEST_STEP_ID = 1090028005;

	// Token: 0x04006D91 RID: 28049
	private const string GM_TEST_PARAM = "GuideTestFocus";

	// Token: 0x04006D92 RID: 28050
	[Nullable(2)]
	public static GuideTestParam GuideTestParams;

	// Token: 0x02008188 RID: 33160
	[NullableContext(0)]
	private enum ETestType
	{
		// Token: 0x0402BFBF RID: 180159
		GuideHook,
		// Token: 0x0402BFC0 RID: 180160
		GuideMark,
		// Token: 0x0402BFC1 RID: 180161
		ExtraParam,
		// Token: 0x0402BFC2 RID: 180162
		MockStep
	}
}
