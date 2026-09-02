using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;

// Token: 0x02001CB3 RID: 7347
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class LevelFuncFlagModel : ModelBase<LevelFuncFlagModel>
{
	// Token: 0x0600D7AB RID: 55211 RVA: 0x0039AD88 File Offset: 0x00398F88
	protected override bool OnInit()
	{
		if (LevelFuncFlagDefine.levelFuncFlagDefaultVal != null)
		{
			foreach (KeyValuePair<ELevelFuncFlagId, bool> keyValuePair in LevelFuncFlagDefine.levelFuncFlagDefaultVal)
			{
				this.FuncFlags.Add(keyValuePair.Key, keyValuePair.Value);
			}
		}
		foreach (KeyValuePair<ELevelFuncFlagId, bool> keyValuePair2 in this.FuncFlags)
		{
			Singleton<EventSystem>.Instance.Emit<ELevelFuncFlagId, bool>(EEventName.OnLevelFuncFlagSet, keyValuePair2.Key, keyValuePair2.Value);
		}
		return true;
	}

	// Token: 0x0600D7AC RID: 55212 RVA: 0x0039AE50 File Offset: 0x00399050
	protected override bool OnClear()
	{
		this.FuncFlags.Clear();
		return true;
	}

	// Token: 0x0600D7AD RID: 55213 RVA: 0x0039AE60 File Offset: 0x00399060
	public bool GetFuncFlagEnable(ELevelFuncFlagId funcFlagId)
	{
		bool flag;
		return this.FuncFlags.TryGetValue(funcFlagId, out flag) && flag;
	}

	// Token: 0x0600D7AE RID: 55214 RVA: 0x0039AE80 File Offset: 0x00399080
	public bool GetFuncFlagDefault(ELevelFuncFlagId funcFlagId)
	{
		bool flag;
		return LevelFuncFlagDefine.levelFuncFlagDefaultVal != null && LevelFuncFlagDefine.levelFuncFlagDefaultVal.TryGetValue(funcFlagId, out flag) && flag;
	}

	// Token: 0x0600D7AF RID: 55215 RVA: 0x0039AEA8 File Offset: 0x003990A8
	public unsafe void SetFuncFlagEnable(ELevelFuncFlagId funcFlagId, bool enable)
	{
		bool flag;
		if (!this.FuncFlags.TryGetValue(funcFlagId, out flag) || flag != enable)
		{
			this.FuncFlags[funcFlagId] = enable;
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Functional;
			ELogAuthor author = ELogAuthor.ZYL;
			string message = "关卡功能标记更新";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("funcFlagId", funcFlagId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("enable", enable);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			Singleton<EventSystem>.Instance.Emit<ELevelFuncFlagId, bool>(EEventName.OnLevelFuncFlagChanged, funcFlagId, enable);
		}
	}

	// Token: 0x0600D7B0 RID: 55216 RVA: 0x0039AF48 File Offset: 0x00399148
	public void ResetFuncFlagToDefault(ELevelFuncFlagId funcFlagId)
	{
		bool funcFlagDefault = this.GetFuncFlagDefault(funcFlagId);
		this.SetFuncFlagEnable(funcFlagId, funcFlagDefault);
	}

	// Token: 0x040066B2 RID: 26290
	private readonly Dictionary<ELevelFuncFlagId, bool> FuncFlags = new Dictionary<ELevelFuncFlagId, bool>();
}
