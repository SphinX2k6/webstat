using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.Role.Common.Data.Structure;

// Token: 0x0200306B RID: 12395
[NullableContext(1)]
[Nullable(0)]
public class CharacterSpecialTagComponent : EntityComponent
{
	// Token: 0x0601978F RID: 104335 RVA: 0x0075D88B File Offset: 0x0075BA8B
	protected override bool OnStart()
	{
		this.TagComp = base.Entity.GetComponent<BaseTagComponent>();
		return true;
	}

	// Token: 0x06019790 RID: 104336 RVA: 0x0075D8A0 File Offset: 0x0075BAA0
	protected override void OnTick(float delta)
	{
		if (this.TagListenerConfig.Count > 0)
		{
			foreach (SpecialTagConfig specialTagConfig in this.TagListenerConfig.Values)
			{
				specialTagConfig.UpdateCondition((double)delta);
			}
		}
	}

	// Token: 0x06019791 RID: 104337 RVA: 0x0075D908 File Offset: 0x0075BB08
	protected override bool OnEnd()
	{
		foreach (KeyValuePair<int, SpecialTagConfig> keyValuePair in this.TagListenerConfig)
		{
			keyValuePair.Value.Clear();
		}
		return true;
	}

	// Token: 0x06019792 RID: 104338 RVA: 0x0075D964 File Offset: 0x0075BB64
	public int InitTagListenerConfig(string daPath, Func<double, bool> condition)
	{
		CharacterSpecialTagComponent.<>c__DisplayClass6_0 CS$<>8__locals1 = new CharacterSpecialTagComponent.<>c__DisplayClass6_0();
		CS$<>8__locals1.daPath = daPath;
		CS$<>8__locals1.<>4__this = this;
		CS$<>8__locals1.condition = condition;
		CharacterSpecialTagComponent.<>c__DisplayClass6_0 CS$<>8__locals2 = CS$<>8__locals1;
		int configHandleCount = this.ConfigHandleCount;
		this.ConfigHandleCount = configHandleCount + 1;
		CS$<>8__locals2.handle = configHandleCount;
		Singleton<ResourceSystem>.Instance.LoadTypeAsync("BP_SpecialTagConfig_C", delegate
		{
			ResourceSystem instance = Singleton<ResourceSystem>.Instance;
			string daPath2 = CS$<>8__locals1.daPath;
			Action<BP_SpecialTagConfig_C, string> callback;
			if ((callback = CS$<>8__locals1.<>9__1) == null)
			{
				callback = (CS$<>8__locals1.<>9__1 = delegate([Nullable(2)] BP_SpecialTagConfig_C asset, string _)
				{
					if (asset == null || CS$<>8__locals1.<>4__this.TagComp == null)
					{
						return;
					}
					SpecialTagConfig specialTagConfig = new SpecialTagConfig();
					specialTagConfig.Init(CS$<>8__locals1.<>4__this.TagComp, asset, CS$<>8__locals1.condition);
					CS$<>8__locals1.<>4__this.TagListenerConfig[CS$<>8__locals1.handle] = specialTagConfig;
				});
			}
			instance.LoadAsync<BP_SpecialTagConfig_C>(daPath2, callback, 100, "js_undefined");
		}, "js_undefined");
		return CS$<>8__locals1.handle;
	}

	// Token: 0x06019793 RID: 104339 RVA: 0x0075D9CC File Offset: 0x0075BBCC
	public void RemoveTagListenerConfig(int handle)
	{
		SpecialTagConfig specialTagConfig;
		if (this.TagListenerConfig.TryGetValue(handle, out specialTagConfig))
		{
			specialTagConfig.Clear();
			this.TagListenerConfig.Remove(handle);
		}
	}

	// Token: 0x06019794 RID: 104340 RVA: 0x0075D9FC File Offset: 0x0075BBFC
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		CharacterSpecialTagComponent characterSpecialTagComponent = (CharacterSpecialTagComponent)componentTemplate;
		if (base.CanResetComponentProperty("ConfigHandleCount"))
		{
			this.ConfigHandleCount = characterSpecialTagComponent.ConfigHandleCount;
		}
		if (base.CanResetComponentProperty("TagListenerConfig"))
		{
			if (characterSpecialTagComponent.TagListenerConfig == null)
			{
				this.TagListenerConfig = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<int, SpecialTagConfig>>(this.TagListenerConfig), "TagListenerConfig"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("TagComp"))
		{
			if (characterSpecialTagComponent.TagComp == null)
			{
				this.TagComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BaseTagComponent>(this.TagComp), "TagComp"))
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x0400C9E5 RID: 51685
	private int ConfigHandleCount;

	// Token: 0x0400C9E6 RID: 51686
	private Dictionary<int, SpecialTagConfig> TagListenerConfig = new Dictionary<int, SpecialTagConfig>();

	// Token: 0x0400C9E7 RID: 51687
	[Nullable(2)]
	private BaseTagComponent TagComp;
}
