using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02002FFD RID: 12285
[NullableContext(1)]
[Nullable(0)]
public class FoleySynthController
{
	// Token: 0x170021B5 RID: 8629
	// (get) Token: 0x06019089 RID: 102537 RVA: 0x0071ADBF File Offset: 0x00718FBF
	// (set) Token: 0x0601908A RID: 102538 RVA: 0x0071ADC7 File Offset: 0x00718FC7
	public CharacterActorComponent ActorComp { get; private set; }

	// Token: 0x170021B6 RID: 8630
	// (get) Token: 0x0601908B RID: 102539 RVA: 0x0071ADD0 File Offset: 0x00718FD0
	// (set) Token: 0x0601908C RID: 102540 RVA: 0x0071ADD8 File Offset: 0x00718FD8
	public CharacterAkComponent AkComp { get; private set; }

	// Token: 0x170021B7 RID: 8631
	// (get) Token: 0x0601908D RID: 102541 RVA: 0x0071ADE1 File Offset: 0x00718FE1
	// (set) Token: 0x0601908E RID: 102542 RVA: 0x0071ADE9 File Offset: 0x00718FE9
	public BaseTagComponent TagComp { get; private set; }

	// Token: 0x0601908F RID: 102543 RVA: 0x0071ADF2 File Offset: 0x00718FF2
	public FoleySynthController(CharacterActorComponent actorComp, CharacterAkComponent akComp, BaseTagComponent tagComp)
	{
		this.ActorComp = actorComp;
		this.AkComp = akComp;
		this.TagComp = tagComp;
	}

	// Token: 0x06019090 RID: 102544 RVA: 0x0071AE1A File Offset: 0x0071901A
	[NullableContext(2)]
	public void Init(FoleySynthAllConfig allConfig)
	{
		if (allConfig == null)
		{
			return;
		}
		this.Config = allConfig;
		this.InitConfig(allConfig);
	}

	// Token: 0x06019091 RID: 102545 RVA: 0x0071AE30 File Offset: 0x00719030
	public void Tick(float deltaTime)
	{
		FoleySynthAllConfig config = this.Config;
		if (config == null || !config.IsLoadSuccess())
		{
			return;
		}
		if (this.TagComp.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.技能中"]) && !this.TagComp.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.动作状态.冲刺"]))
		{
			return;
		}
		foreach (FoleySynthHandlerBase foleySynthHandlerBase in this.Handlers)
		{
			foleySynthHandlerBase.Tick(deltaTime);
		}
	}

	// Token: 0x06019092 RID: 102546 RVA: 0x0071AED4 File Offset: 0x007190D4
	public void Clear()
	{
		foreach (FoleySynthHandlerBase foleySynthHandlerBase in this.Handlers)
		{
			foleySynthHandlerBase.Clear();
		}
		this.Handlers.Clear();
		this.Config = null;
	}

	// Token: 0x06019093 RID: 102547 RVA: 0x0071AF38 File Offset: 0x00719138
	public void SetDebug(bool debug, int[] models)
	{
		foreach (int num in models)
		{
			if (num < this.Handlers.Count)
			{
				this.Handlers[num].SetDebug(debug);
			}
		}
	}

	// Token: 0x06019094 RID: 102548 RVA: 0x0071AF7C File Offset: 0x0071917C
	private void InitConfig(FoleySynthAllConfig allConfig)
	{
		if (allConfig.FoleySynthModel1Configs.Count > 0)
		{
			FoleySynthModel1Handler foleySynthModel1Handler = new FoleySynthModel1Handler(this.ActorComp, this.AkComp, 2);
			foleySynthModel1Handler.Init(allConfig.FoleySynthModel1Configs);
			this.Handlers.Add(foleySynthModel1Handler);
		}
		if (allConfig.FoleySynthModel2Configs.Count > 0)
		{
			FoleySynthModel2Handler foleySynthModel2Handler = new FoleySynthModel2Handler(this.ActorComp, this.AkComp, allConfig.Model2AccelerationMaxCount);
			foleySynthModel2Handler.Init(allConfig.FoleySynthModel2Configs);
			foleySynthModel2Handler.VelocityMaxCount = allConfig.Model2VelocityMaxCount;
			this.Handlers.Add(foleySynthModel2Handler);
		}
	}

	// Token: 0x0400C3F2 RID: 50162
	private readonly List<FoleySynthHandlerBase> Handlers = new List<FoleySynthHandlerBase>();

	// Token: 0x0400C3F3 RID: 50163
	[Nullable(2)]
	private FoleySynthAllConfig Config;
}
