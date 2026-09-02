using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.HonamiStory;

// Token: 0x02001EE9 RID: 7913
[NullableContext(1)]
[Nullable(0)]
public class HonamiStoryWeaponData
{
	// Token: 0x0600EA76 RID: 60022 RVA: 0x003F9AF0 File Offset: 0x003F7CF0
	public HonamiStoryWeaponData(int id)
	{
		this.Id = id;
		this.IsUnlockInternal = false;
		HonamiStoryWeapon? config = this.Config;
		this.PluginTags = config.Value.PluginTags().ToList<int>();
		this.SuitId = config.Value.SuitId().ToList<int>();
		this.ExtraSuitAddEnhanceLevel = new Dictionary<int, int>();
		foreach (KeyValuePair<int, int> keyValuePair in config.Value.ExtraSuitAddEnhanceLevel())
		{
			this.ExtraSuitAddEnhanceLevel.Add(keyValuePair.Key, keyValuePair.Value);
		}
		this.IsShowReward = config.Value.IsShowReward;
		this.Desc = config.Value.AttributesDescription;
		this.DescArgs = config.Value.AttributesDescriptionArgs().ToList<string>();
		this.DescSimple = config.Value.AttributesDescriptionSimple;
		this.DescSimpleArgs = config.Value.AttributesDescriptionSimpleArgs().ToList<string>();
	}

	// Token: 0x17001218 RID: 4632
	// (get) Token: 0x0600EA77 RID: 60023 RVA: 0x003F9C78 File Offset: 0x003F7E78
	public int WeaponId
	{
		get
		{
			return this.Id;
		}
	}

	// Token: 0x17001219 RID: 4633
	// (get) Token: 0x0600EA78 RID: 60024 RVA: 0x003F9C80 File Offset: 0x003F7E80
	public bool IsUnlock
	{
		get
		{
			return this.IsUnlockInternal;
		}
	}

	// Token: 0x0600EA79 RID: 60025 RVA: 0x003F9C88 File Offset: 0x003F7E88
	public void SetUnlock(bool isUnlock)
	{
		this.IsUnlockInternal = isUnlock;
	}

	// Token: 0x1700121A RID: 4634
	// (get) Token: 0x0600EA7A RID: 60026 RVA: 0x003F9C91 File Offset: 0x003F7E91
	public HonamiStoryWeapon? Config
	{
		get
		{
			return ConfigBase<HonamiStoryConfig>.Instance.GetWeaponConfig(this.Id);
		}
	}

	// Token: 0x1700121B RID: 4635
	// (get) Token: 0x0600EA7B RID: 60027 RVA: 0x003F9CA4 File Offset: 0x003F7EA4
	public EHonamiStoryWeaponType WeaponType
	{
		get
		{
			return (EHonamiStoryWeaponType)this.Config.Value.Type;
		}
	}

	// Token: 0x04007107 RID: 28935
	private readonly int Id;

	// Token: 0x04007108 RID: 28936
	private bool IsUnlockInternal;

	// Token: 0x04007109 RID: 28937
	public List<int> PluginTags = new List<int>();

	// Token: 0x0400710A RID: 28938
	public List<int> SuitId = new List<int>();

	// Token: 0x0400710B RID: 28939
	public Dictionary<int, int> ExtraSuitAddEnhanceLevel = new Dictionary<int, int>();

	// Token: 0x0400710C RID: 28940
	public bool IsShowReward;

	// Token: 0x0400710D RID: 28941
	public string Desc = "";

	// Token: 0x0400710E RID: 28942
	public List<string> DescArgs = new List<string>();

	// Token: 0x0400710F RID: 28943
	public string DescSimple = "";

	// Token: 0x04007110 RID: 28944
	public List<string> DescSimpleArgs = new List<string>();
}
