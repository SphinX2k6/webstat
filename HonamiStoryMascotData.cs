using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.HonamiStory;

// Token: 0x02001ED6 RID: 7894
[NullableContext(1)]
[Nullable(0)]
public class HonamiStoryMascotData
{
	// Token: 0x0600E9D1 RID: 59857 RVA: 0x003F62DF File Offset: 0x003F44DF
	public HonamiStoryMascotData(int configId)
	{
		this.IdInternal = configId;
	}

	// Token: 0x170011FA RID: 4602
	// (get) Token: 0x0600E9D2 RID: 59858 RVA: 0x003F62EE File Offset: 0x003F44EE
	public HonamiStoryMascot? Config
	{
		get
		{
			return ConfigBase<HonamiStoryConfig>.Instance.GetHonamiStoryMascotConfig(this.IdInternal);
		}
	}

	// Token: 0x0600E9D3 RID: 59859 RVA: 0x003F6300 File Offset: 0x003F4500
	public void UpdateState(EHonamiStoryCollectState state)
	{
		this.StateInternal = state;
	}

	// Token: 0x170011FB RID: 4603
	// (get) Token: 0x0600E9D4 RID: 59860 RVA: 0x003F6309 File Offset: 0x003F4509
	public EHonamiStoryCollectState State
	{
		get
		{
			return this.StateInternal;
		}
	}

	// Token: 0x170011FC RID: 4604
	// (get) Token: 0x0600E9D5 RID: 59861 RVA: 0x003F6311 File Offset: 0x003F4511
	public int Id
	{
		get
		{
			return this.IdInternal;
		}
	}

	// Token: 0x170011FD RID: 4605
	// (get) Token: 0x0600E9D6 RID: 59862 RVA: 0x003F631C File Offset: 0x003F451C
	public string Name
	{
		get
		{
			return this.Config.Value.Name;
		}
	}

	// Token: 0x170011FE RID: 4606
	// (get) Token: 0x0600E9D7 RID: 59863 RVA: 0x003F6340 File Offset: 0x003F4540
	public string FeatureDesc
	{
		get
		{
			return this.Config.Value.FeatureDesc;
		}
	}

	// Token: 0x170011FF RID: 4607
	// (get) Token: 0x0600E9D8 RID: 59864 RVA: 0x003F6364 File Offset: 0x003F4564
	public string ClueDesc
	{
		get
		{
			return this.Config.Value.ClueDesc;
		}
	}

	// Token: 0x17001200 RID: 4608
	// (get) Token: 0x0600E9D9 RID: 59865 RVA: 0x003F6388 File Offset: 0x003F4588
	public int DropId
	{
		get
		{
			return this.Config.Value.DropId;
		}
	}

	// Token: 0x17001201 RID: 4609
	// (get) Token: 0x0600E9DA RID: 59866 RVA: 0x003F63AC File Offset: 0x003F45AC
	public int AreaId
	{
		get
		{
			return this.Config.Value.AreaId;
		}
	}

	// Token: 0x040070C7 RID: 28871
	private readonly int IdInternal;

	// Token: 0x040070C8 RID: 28872
	private EHonamiStoryCollectState StateInternal;
}
