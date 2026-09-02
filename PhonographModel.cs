using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Inventory;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002598 RID: 9624
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class PhonographModel : ModelBase<PhonographModel>
{
	// Token: 0x06012BFF RID: 76799 RVA: 0x0052C40C File Offset: 0x0052A60C
	protected override bool OnInit()
	{
		PhonographConfig instance = ConfigBase<PhonographConfig>.Instance;
		IReadOnlyList<PhonographMusic> readOnlyList = (instance != null) ? instance.GetMusicList() : null;
		if (readOnlyList == null)
		{
			return true;
		}
		foreach (PhonographMusic phonographMusic in readOnlyList)
		{
			this.MusicItemIdSet.Add(phonographMusic.ItemId);
		}
		return true;
	}

	// Token: 0x17001795 RID: 6037
	// (get) Token: 0x06012C01 RID: 76801 RVA: 0x0052C48C File Offset: 0x0052A68C
	// (set) Token: 0x06012C00 RID: 76800 RVA: 0x0052C478 File Offset: 0x0052A678
	public int RecordMusicId
	{
		get
		{
			int result;
			if (!this.RecordMusicIdMap.TryGetValue(this.CurrentPlayActorEntityId, out result))
			{
				return 0;
			}
			return result;
		}
		set
		{
			this.RecordMusicIdMap[this.CurrentPlayActorEntityId] = value;
		}
	}

	// Token: 0x06012C02 RID: 76802 RVA: 0x0052C4B4 File Offset: 0x0052A6B4
	public int GetRecordMusicId(int actorEntityId)
	{
		int result;
		if (!this.RecordMusicIdMap.TryGetValue(actorEntityId, out result))
		{
			return 0;
		}
		return result;
	}

	// Token: 0x06012C03 RID: 76803 RVA: 0x0052C4D4 File Offset: 0x0052A6D4
	public int GetPlayIdRecord(int actorEntityId)
	{
		int result;
		if (!this.PlayIdRecordMap.TryGetValue(actorEntityId, out result))
		{
			return 0;
		}
		return result;
	}

	// Token: 0x06012C04 RID: 76804 RVA: 0x0052C4F4 File Offset: 0x0052A6F4
	public void SetPlayIdRecord(int actorEntityId, int musicId)
	{
		this.PlayIdRecordMap[actorEntityId] = musicId;
	}

	// Token: 0x06012C05 RID: 76805 RVA: 0x0052C503 File Offset: 0x0052A703
	public void RemovePlayIdRecord(int actorEntityId)
	{
		this.PlayIdRecordMap.Remove(actorEntityId);
	}

	// Token: 0x06012C06 RID: 76806 RVA: 0x0052C514 File Offset: 0x0052A714
	public bool IsUnlockMusic(int musicId)
	{
		PhonographConfig instance = ConfigBase<PhonographConfig>.Instance;
		PhonographMusic? phonographMusic = (instance != null) ? instance.GetMusicById(musicId) : null;
		return (phonographMusic != null && phonographMusic.Value.Lock) || this.UnlockMusicIds.Contains(musicId);
	}

	// Token: 0x06012C07 RID: 76807 RVA: 0x0052C564 File Offset: 0x0052A764
	public bool IsNewMusic(int musicId)
	{
		return this.NewMusicIds.Contains(musicId);
	}

	// Token: 0x06012C08 RID: 76808 RVA: 0x0052C574 File Offset: 0x0052A774
	public void RemoveNewMusic(int musicId)
	{
		int num = this.NewMusicIds.IndexOf(musicId);
		if (num >= 0)
		{
			this.NewMusicIds.RemoveAt(num);
		}
	}

	// Token: 0x17001796 RID: 6038
	// (get) Token: 0x06012C09 RID: 76809 RVA: 0x0052C5A0 File Offset: 0x0052A7A0
	[Nullable(2)]
	public AActor EntityActor
	{
		[NullableContext(2)]
		get
		{
			CreatureModel instance = ModelBase<CreatureModel>.Instance;
			EntityHandle entityHandle = (instance != null) ? instance.GetEntityByPbDataId(this.CurrentPlayActorEntityId) : null;
			if (entityHandle == null)
			{
				return null;
			}
			WorldEntity entity = entityHandle.Entity;
			BaseActorComponent baseActorComponent = (entity != null) ? entity.GetComponent<BaseActorComponent>() : null;
			if (baseActorComponent == null)
			{
				return null;
			}
			return baseActorComponent.Owner;
		}
	}

	// Token: 0x17001797 RID: 6039
	// (get) Token: 0x06012C0A RID: 76810 RVA: 0x0052C5E8 File Offset: 0x0052A7E8
	public int? EntityId
	{
		get
		{
			CreatureModel instance = ModelBase<CreatureModel>.Instance;
			EntityHandle entityHandle = (instance != null) ? instance.GetEntityByPbDataId(this.CurrentPlayActorEntityId) : null;
			if (entityHandle == null)
			{
				return null;
			}
			WorldEntity entity = entityHandle.Entity;
			if (entity == null)
			{
				return null;
			}
			return new int?(entity.Id);
		}
	}

	// Token: 0x06012C0B RID: 76811 RVA: 0x0052C638 File Offset: 0x0052A838
	public bool CheckAlbumHasNewMusic(int albumId)
	{
		PhonographConfig instance = ConfigBase<PhonographConfig>.Instance;
		foreach (PhonographMusic phonographMusic in (((instance != null) ? instance.GetMusicList() : null) ?? new List<PhonographMusic>()))
		{
			if (this.IsNewMusic(phonographMusic.Id))
			{
				int[] albumArray = phonographMusic.GetAlbumArray();
				if (albumArray != null && albumArray.Contains(albumId))
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x06012C0C RID: 76812 RVA: 0x0052C6BC File Offset: 0x0052A8BC
	public void ClearPlayInfo()
	{
		this.CurrentPlayMusicId = 0;
		this.CurrentPlayActorEntityId = 0;
		this.CurrentPlayMusicTime = 0;
		this.CurrentPlayMusicTotalTime = 0;
	}

	// Token: 0x06012C0D RID: 76813 RVA: 0x0052C6DC File Offset: 0x0052A8DC
	[NullableContext(0)]
	public UniTask<float> GetMusicDuration(int musicId)
	{
		PhonographModel.<GetMusicDuration>d__30 <GetMusicDuration>d__;
		<GetMusicDuration>d__.<>t__builder = AsyncUniTaskMethodBuilder<float>.Create();
		<GetMusicDuration>d__.musicId = musicId;
		<GetMusicDuration>d__.<>1__state = -1;
		<GetMusicDuration>d__.<>t__builder.Start<PhonographModel.<GetMusicDuration>d__30>(ref <GetMusicDuration>d__);
		return <GetMusicDuration>d__.<>t__builder.Task;
	}

	// Token: 0x06012C0E RID: 76814 RVA: 0x0052C720 File Offset: 0x0052A920
	public int GetCurrentPlayTimeFromAudio()
	{
		if (this.CurrentMusicHandleId == -1)
		{
			return 0;
		}
		int? sourcePlayPosition = Singleton<AudioSystem>.Instance.GetSourcePlayPosition(this.CurrentMusicHandleId, false);
		if (sourcePlayPosition == null)
		{
			return 0;
		}
		return (int)Math.Floor((double)((float)sourcePlayPosition.Value * 0.001f));
	}

	// Token: 0x06012C0F RID: 76815 RVA: 0x0052C76C File Offset: 0x0052A96C
	public List<int> GetUnlockItemIds()
	{
		List<int> list = new List<int>();
		InventoryModel instance = ModelBase<InventoryModel>.Instance;
		List<CommonItemData> list2 = (instance != null) ? instance.GetCommonItemByItemType(InventoryDefine.EItemType.Phonograph) : null;
		if (list2 == null)
		{
			return list;
		}
		foreach (CommonItemData commonItemData in list2)
		{
			if (this.MusicItemIdSet.Contains(commonItemData.GetConfigId()))
			{
				list.Add(commonItemData.GetConfigId());
			}
		}
		return list;
	}

	// Token: 0x04009265 RID: 37477
	public int CurrentPlayMusicId;

	// Token: 0x04009266 RID: 37478
	public int CurrentSelectMusicId;

	// Token: 0x04009267 RID: 37479
	public int CurrentPlayActorEntityId;

	// Token: 0x04009268 RID: 37480
	public bool IsGlobal;

	// Token: 0x04009269 RID: 37481
	public int CurrentPlayMusicTime;

	// Token: 0x0400926A RID: 37482
	public int CurrentPlayMusicTotalTime;

	// Token: 0x0400926B RID: 37483
	public List<int> UnlockMusicIds = new List<int>();

	// Token: 0x0400926C RID: 37484
	public List<int> NewMusicIds = new List<int>();

	// Token: 0x0400926D RID: 37485
	public int GlobalMusicId;

	// Token: 0x0400926E RID: 37486
	public int CurrentMusicHandleId;

	// Token: 0x0400926F RID: 37487
	public readonly Dictionary<int, int> RecordMusicIdMap = new Dictionary<int, int>();

	// Token: 0x04009270 RID: 37488
	private readonly Dictionary<int, int> PlayIdRecordMap = new Dictionary<int, int>();

	// Token: 0x04009271 RID: 37489
	private readonly HashSet<int> MusicItemIdSet = new HashSet<int>();
}
