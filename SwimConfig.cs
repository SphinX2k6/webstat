using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02003157 RID: 12631
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class SwimConfig : ConfigBase<SwimConfig>
{
	// Token: 0x0601A2B9 RID: 107193 RVA: 0x007AFC2E File Offset: 0x007ADE2E
	protected override bool OnInit()
	{
		this.CacheConfig = new Dictionary<string, Swim>();
		this.BuffIdWithInputForNormalSwim = new long?(0L);
		this.BuffIdWithInputForFastSwim = new long?(0L);
		this.BuffIdWithNoInput = new long?(0L);
		this.InitSwimBuffConfig();
		return true;
	}

	// Token: 0x0601A2BA RID: 107194 RVA: 0x007AFC69 File Offset: 0x007ADE69
	protected override bool OnClear()
	{
		this.CacheConfig = null;
		this.BuffIdWithInputForNormalSwim = null;
		this.BuffIdWithInputForFastSwim = null;
		this.BuffIdWithNoInput = null;
		return true;
	}

	// Token: 0x0601A2BB RID: 107195 RVA: 0x007AFC98 File Offset: 0x007ADE98
	public Swim? GetSwimConfigByRoleBodyId(string roleBodyId)
	{
		Swim value;
		if (this.CacheConfig.TryGetValue(roleBodyId, out value))
		{
			return new Swim?(value);
		}
		Swim? config = ConfigSwimById.GetConfig(roleBodyId, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Movement;
			ELogAuthor author = ELogAuthor.LJM;
			string message = "以下身高没有配置游泳";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("RoleBody", roleBodyId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}
		this.CacheConfig.Add(roleBodyId, config.Value);
		return config;
	}

	// Token: 0x0601A2BC RID: 107196 RVA: 0x007AFD08 File Offset: 0x007ADF08
	public long? GetSwimBuffId(bool hasInput, bool bFastSwim)
	{
		if (!hasInput)
		{
			return this.BuffIdWithNoInput;
		}
		if (bFastSwim)
		{
			return this.BuffIdWithInputForFastSwim;
		}
		return this.BuffIdWithInputForNormalSwim;
	}

	// Token: 0x0601A2BD RID: 107197 RVA: 0x007AFD24 File Offset: 0x007ADF24
	public void InitSwimBuffConfig()
	{
		SwimBuff? config = ConfigSwimBuffById.GetConfig(0, true);
		if (config == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.Movement, ELogAuthor.LJM, "游泳Buff表没有配置Id为0的基础配置", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		this.BuffIdWithInputForNormalSwim = new long?((long)config.Value.BuffId);
		SwimBuff? config2 = ConfigSwimBuffById.GetConfig(1, true);
		if (config2 == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.Movement, ELogAuthor.LJM, "游泳Buff表没有配置Id为1的基础配置", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		this.BuffIdWithNoInput = new long?((long)config2.Value.BuffId);
		SwimBuff? config3 = ConfigSwimBuffById.GetConfig(3, true);
		if (config3 == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.Movement, ELogAuthor.LJM, "游泳Buff表没有配置Id为3的基础配置", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		this.BuffIdWithInputForFastSwim = new long?((long)config3.Value.BuffId);
	}

	// Token: 0x0400D274 RID: 53876
	private const int NORMAL_SWIM_CONFIG_ID = 0;

	// Token: 0x0400D275 RID: 53877
	private const int NO_INPUT_CONFIG_ID = 1;

	// Token: 0x0400D276 RID: 53878
	private const int FAST_SWIM_CONFIG_ID = 3;

	// Token: 0x0400D277 RID: 53879
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Dictionary<string, Swim> CacheConfig;

	// Token: 0x0400D278 RID: 53880
	private long? BuffIdWithInputForNormalSwim;

	// Token: 0x0400D279 RID: 53881
	private long? BuffIdWithInputForFastSwim;

	// Token: 0x0400D27A RID: 53882
	private long? BuffIdWithNoInput;
}
