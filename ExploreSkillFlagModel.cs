using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

// Token: 0x02001CAB RID: 7339
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class ExploreSkillFlagModel : ModelBase<ExploreSkillFlagModel>
{
	// Token: 0x0600D774 RID: 55156 RVA: 0x00399EF4 File Offset: 0x003980F4
	protected override bool OnInit()
	{
		foreach (KeyValuePair<EExploreSkillType, bool> keyValuePair in ExploreSkillFlagDefine.levelExploreSkillFlagDefaultVal)
		{
			this.SkillFlags.Add(keyValuePair.Key, keyValuePair.Value);
		}
		return true;
	}

	// Token: 0x0600D775 RID: 55157 RVA: 0x00399F5C File Offset: 0x0039815C
	protected override bool OnClear()
	{
		this.SkillFlags.Clear();
		return true;
	}

	// Token: 0x0600D776 RID: 55158 RVA: 0x00399F6C File Offset: 0x0039816C
	public bool GetExploreSkillFlagEnable(EExploreSkillType skillType)
	{
		bool flag;
		return !this.SkillFlags.TryGetValue(skillType, out flag) || flag;
	}

	// Token: 0x0600D777 RID: 55159 RVA: 0x00399F8C File Offset: 0x0039818C
	public unsafe void SetExploreSkillFlagEnable(EExploreSkillType skillType, bool enable)
	{
		bool flag;
		this.SkillFlags.TryGetValue(skillType, out flag);
		if (flag != enable)
		{
			this.SkillFlags[skillType] = enable;
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.Functional;
			ELogAuthor author = ELogAuthor.CH;
			string message = "探索技能标记更新";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("skillType", skillType);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("enable", enable);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		}
	}

	// Token: 0x0600D778 RID: 55160 RVA: 0x0039A018 File Offset: 0x00398218
	public void DisableAllExploreSkillFlag()
	{
		foreach (KeyValuePair<EExploreSkillType, bool> keyValuePair in this.SkillFlags)
		{
			this.SetExploreSkillFlagEnable(keyValuePair.Key, false);
		}
	}

	// Token: 0x0600D779 RID: 55161 RVA: 0x0039A074 File Offset: 0x00398274
	public void EnableAllExploreSkillFlag()
	{
		foreach (KeyValuePair<EExploreSkillType, bool> keyValuePair in this.SkillFlags)
		{
			this.SetExploreSkillFlagEnable(keyValuePair.Key, true);
		}
	}

	// Token: 0x04006619 RID: 26137
	private readonly Dictionary<EExploreSkillType, bool> SkillFlags = new Dictionary<EExploreSkillType, bool>();
}
