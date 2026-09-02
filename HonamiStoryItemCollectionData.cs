using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.HonamiStory;

// Token: 0x02001ED3 RID: 7891
[NullableContext(1)]
[Nullable(0)]
public class HonamiStoryItemCollectionData
{
	// Token: 0x0600E998 RID: 59800 RVA: 0x003F5B2A File Offset: 0x003F3D2A
	public HonamiStoryItemCollectionData(HonamiStoryItemCollection config)
	{
		this.Config = config;
	}

	// Token: 0x0600E999 RID: 59801 RVA: 0x003F5B39 File Offset: 0x003F3D39
	public void UpdateData(HonamiStoryItemCollectionInfo areaSecretInfo)
	{
		this.StateInternal = (EHonamiStoryCollectState)areaSecretInfo.Status;
	}

	// Token: 0x0600E99A RID: 59802 RVA: 0x003F5B47 File Offset: 0x003F3D47
	public void UpdateState(EHonamiStoryCollectState state)
	{
		this.StateInternal = state;
	}

	// Token: 0x170011EF RID: 4591
	// (get) Token: 0x0600E99B RID: 59803 RVA: 0x003F5B50 File Offset: 0x003F3D50
	public EHonamiStoryCollectState State
	{
		get
		{
			return this.StateInternal;
		}
	}

	// Token: 0x170011F0 RID: 4592
	// (get) Token: 0x0600E99C RID: 59804 RVA: 0x003F5B58 File Offset: 0x003F3D58
	public int Id
	{
		get
		{
			return this.Config.ItemId;
		}
	}

	// Token: 0x170011F1 RID: 4593
	// (get) Token: 0x0600E99D RID: 59805 RVA: 0x003F5B74 File Offset: 0x003F3D74
	public string Name
	{
		get
		{
			return this.Config.Name;
		}
	}

	// Token: 0x170011F2 RID: 4594
	// (get) Token: 0x0600E99E RID: 59806 RVA: 0x003F5B90 File Offset: 0x003F3D90
	public string Desc
	{
		get
		{
			return this.Config.Desc;
		}
	}

	// Token: 0x170011F3 RID: 4595
	// (get) Token: 0x0600E99F RID: 59807 RVA: 0x003F5BAC File Offset: 0x003F3DAC
	public int DropId
	{
		get
		{
			return this.Config.DropId;
		}
	}

	// Token: 0x170011F4 RID: 4596
	// (get) Token: 0x0600E9A0 RID: 59808 RVA: 0x003F5BC7 File Offset: 0x003F3DC7
	public HonamiStoryItemCollection GetConfig
	{
		get
		{
			return this.Config;
		}
	}

	// Token: 0x040070B0 RID: 28848
	private readonly HonamiStoryItemCollection Config;

	// Token: 0x040070B1 RID: 28849
	private EHonamiStoryCollectState StateInternal;
}
