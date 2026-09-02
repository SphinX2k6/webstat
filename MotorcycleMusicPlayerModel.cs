using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common;
using CSharpScript.Game.Module.BattleUi;

// Token: 0x02002314 RID: 8980
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class MotorcycleMusicPlayerModel : ModelBase<MotorcycleMusicPlayerModel>
{
	// Token: 0x1700151C RID: 5404
	// (get) Token: 0x060110FF RID: 69887 RVA: 0x004AF2AE File Offset: 0x004AD4AE
	public bool IsEnable
	{
		get
		{
			return VisibleStateUtil.GetVisible(this.VisibleState);
		}
	}

	// Token: 0x06011100 RID: 69888 RVA: 0x004AF2BB File Offset: 0x004AD4BB
	public void IncreaseDisableCount()
	{
		this.DisableCount++;
		this.UpdateDisableVisibleState();
	}

	// Token: 0x06011101 RID: 69889 RVA: 0x004AF2D1 File Offset: 0x004AD4D1
	public void DecreaseDisableCount()
	{
		this.DisableCount--;
		this.UpdateDisableVisibleState();
	}

	// Token: 0x06011102 RID: 69890 RVA: 0x004AF2E7 File Offset: 0x004AD4E7
	public void SetFunctionEnable(bool isEnable)
	{
		this.VisibleState = VisibleStateUtil.SetVisible(this.VisibleState, isEnable, 0);
	}

	// Token: 0x06011103 RID: 69891 RVA: 0x004AF2FC File Offset: 0x004AD4FC
	public void SetFightMusicEnable(bool isEnable)
	{
		this.VisibleState = VisibleStateUtil.SetVisible(this.VisibleState, isEnable, 2);
	}

	// Token: 0x06011104 RID: 69892 RVA: 0x004AF314 File Offset: 0x004AD514
	private void UpdateDisableVisibleState()
	{
		bool bVisible = this.DisableCount == 0;
		this.VisibleState = VisibleStateUtil.SetVisible(this.VisibleState, bVisible, 1);
	}

	// Token: 0x06011105 RID: 69893 RVA: 0x004AF33E File Offset: 0x004AD53E
	public bool LoadLocalStorageData()
	{
		this.MusicNewSet = LocalStorage.GetPlayer<HashSet<int>>(ELocalStoragePlayerKey.MotorcycleMusicRedDot, null);
		this.PlayMode = LocalStorage.GetPlayer<EMotorMusicPlayMode>(ELocalStoragePlayerKey.MotorcyclePlayMode, EMotorMusicPlayMode.Order);
		return true;
	}

	// Token: 0x06011106 RID: 69894 RVA: 0x004AF363 File Offset: 0x004AD563
	public bool IsMusicFavorite(int id)
	{
		return this.FavoriteMusicList.Contains(id);
	}

	// Token: 0x06011107 RID: 69895 RVA: 0x004AF374 File Offset: 0x004AD574
	public bool ToggleMusicFavorite(int id)
	{
		if (this.IsMusicFavorite(id))
		{
			int num = this.FavoriteMusicList.IndexOf(id);
			if (num != -1)
			{
				this.FavoriteMusicList.RemoveAt(num);
			}
		}
		else
		{
			if (this.FavoriteMusicList.Count >= ConfigBase<MotorcycleMusicPlayerConfig>.Instance.GetFavoriteCountLimit())
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("MotorMusicTips06", Array.Empty<object>());
				return false;
			}
			this.FavoriteMusicList.Insert(0, id);
		}
		return true;
	}

	// Token: 0x06011108 RID: 69896 RVA: 0x004AF3E4 File Offset: 0x004AD5E4
	public IReadOnlyList<int> GetFavoriteMusicList()
	{
		return this.FavoriteMusicList;
	}

	// Token: 0x06011109 RID: 69897 RVA: 0x004AF3EC File Offset: 0x004AD5EC
	public void SetFavoriteMusicList(IReadOnlyList<int> musicList)
	{
		this.FavoriteMusicList = new List<int>(musicList);
	}

	// Token: 0x0601110A RID: 69898 RVA: 0x004AF3FA File Offset: 0x004AD5FA
	public IReadOnlyList<int> GetCurrentPlayList()
	{
		return this.CurrentPlayList;
	}

	// Token: 0x0601110B RID: 69899 RVA: 0x004AF402 File Offset: 0x004AD602
	public void SetPlayList(List<int> musicList)
	{
		this.CurrentPlayList = musicList;
	}

	// Token: 0x0601110C RID: 69900 RVA: 0x004AF40B File Offset: 0x004AD60B
	public bool IsMusicUnlock(int id)
	{
		return ModelBase<PhonographModel>.Instance.IsUnlockMusic(id);
	}

	// Token: 0x0601110D RID: 69901 RVA: 0x004AF418 File Offset: 0x004AD618
	public List<PhonographMusic> GetMusicByAlbum(int albumId)
	{
		if (albumId == ConfigBase<MotorcycleMusicPlayerConfig>.Instance.GetFavoriteAlbumId())
		{
			List<PhonographMusic> list = new List<PhonographMusic>();
			foreach (int id in this.FavoriteMusicList)
			{
				PhonographMusic? musicById = ConfigBase<PhonographConfig>.Instance.GetMusicById(id);
				if (musicById != null)
				{
					list.Add(musicById.Value);
				}
			}
			return list;
		}
		if (this.Album2MusicCache.ContainsKey(albumId))
		{
			return this.Album2MusicCache[albumId];
		}
		IEnumerable<PhonographMusic> enumerable = ConfigBase<PhonographConfig>.Instance.GetMusicList() ?? new List<PhonographMusic>();
		List<PhonographMusic> list2 = new List<PhonographMusic>();
		foreach (PhonographMusic item in enumerable)
		{
			if (item.GetAlbumArray().Contains(albumId))
			{
				list2.Add(item);
			}
		}
		this.Album2MusicCache[albumId] = list2;
		return list2;
	}

	// Token: 0x0601110E RID: 69902 RVA: 0x004AF52C File Offset: 0x004AD72C
	public List<PhonographMusic> GetUnlockMusicByAlbum(int albumId)
	{
		List<PhonographMusic> musicByAlbum = this.GetMusicByAlbum(albumId);
		if (albumId == ConfigBase<MotorcycleMusicPlayerConfig>.Instance.GetFavoriteAlbumId())
		{
			return musicByAlbum;
		}
		List<PhonographMusic> list = new List<PhonographMusic>();
		foreach (PhonographMusic item in musicByAlbum)
		{
			if (this.IsMusicUnlock(item.Id))
			{
				list.Add(item);
			}
		}
		list.Sort((PhonographMusic a, PhonographMusic b) => a.Id.CompareTo(b.Id));
		return list;
	}

	// Token: 0x0601110F RID: 69903 RVA: 0x004AF5CC File Offset: 0x004AD7CC
	public int GetCurPlayMusicId()
	{
		return this.CurPlayMusicId;
	}

	// Token: 0x06011110 RID: 69904 RVA: 0x004AF5D4 File Offset: 0x004AD7D4
	public void SetCurPlayMusic(int albumId, int id)
	{
		if (albumId == this.CurPlayAlbum)
		{
			this.PrevMusicId = this.CurPlayMusicId;
		}
		else
		{
			this.CurPlayAlbum = albumId;
			this.PrevMusicId = -1;
		}
		this.CurPlayMusicId = id;
		this.IsPause = false;
		LocalStorage.SetPlayer<int>(ELocalStoragePlayerKey.MotorcycleCurPlayAlbumId, albumId);
		LocalStorage.SetPlayer<int>(ELocalStoragePlayerKey.MotorcycleCurPlayMusicId, id);
	}

	// Token: 0x06011111 RID: 69905 RVA: 0x004AF62C File Offset: 0x004AD82C
	public int GetPrevMusicId()
	{
		return this.PrevMusicId;
	}

	// Token: 0x06011112 RID: 69906 RVA: 0x004AF634 File Offset: 0x004AD834
	public void ClearPrevMusicId()
	{
		this.PrevMusicId = -1;
	}

	// Token: 0x06011113 RID: 69907 RVA: 0x004AF63D File Offset: 0x004AD83D
	public int GetCurPlayAlbum()
	{
		return this.CurPlayAlbum;
	}

	// Token: 0x06011114 RID: 69908 RVA: 0x004AF648 File Offset: 0x004AD848
	public int GetDefaultMusicId()
	{
		List<PhonographMusic> unlockMusicByAlbum = this.GetUnlockMusicByAlbum(1);
		if (unlockMusicByAlbum.Count <= 0)
		{
			return -1;
		}
		return unlockMusicByAlbum[0].Id;
	}

	// Token: 0x06011115 RID: 69909 RVA: 0x004AF678 File Offset: 0x004AD878
	public void SwitchToDefaultAlbumWithoutPlay()
	{
		int defaultMusicId = this.GetDefaultMusicId();
		if (defaultMusicId == -1)
		{
			return;
		}
		this.SetCurPlayMusic(1, defaultMusicId);
		this.SetIsPause(true);
		this.ClearPrevMusicId();
	}

	// Token: 0x06011116 RID: 69910 RVA: 0x004AF6A6 File Offset: 0x004AD8A6
	public bool GetIsPause()
	{
		return this.IsPause;
	}

	// Token: 0x06011117 RID: 69911 RVA: 0x004AF6AE File Offset: 0x004AD8AE
	public void SetIsPause(bool isPause)
	{
		this.IsPause = isPause;
	}

	// Token: 0x06011118 RID: 69912 RVA: 0x004AF6B7 File Offset: 0x004AD8B7
	public EMotorMusicPlayMode GetPlayMode()
	{
		return this.PlayMode;
	}

	// Token: 0x06011119 RID: 69913 RVA: 0x004AF6BF File Offset: 0x004AD8BF
	public void SetCurPlayMode(EMotorMusicPlayMode mode)
	{
		this.PlayMode = mode;
		LocalStorage.SetPlayer<EMotorMusicPlayMode>(ELocalStoragePlayerKey.MotorcyclePlayMode, mode);
	}

	// Token: 0x0601111A RID: 69914 RVA: 0x004AF6D4 File Offset: 0x004AD8D4
	public bool IsMusicNew(int id)
	{
		if (this.MusicNewSet == null)
		{
			this.MusicNewSet = LocalStorage.GetPlayer<HashSet<int>>(ELocalStoragePlayerKey.MotorcycleMusicRedDot, null);
		}
		if (this.IsMusicUnlock(id))
		{
			HashSet<int> musicNewSet = this.MusicNewSet;
			return musicNewSet != null && musicNewSet.Contains(id);
		}
		return false;
	}

	// Token: 0x0601111B RID: 69915 RVA: 0x004AF70C File Offset: 0x004AD90C
	public void AddMusicListToNew(List<int> musicList)
	{
		if (this.MusicNewSet == null)
		{
			this.MusicNewSet = new HashSet<int>();
		}
		foreach (int item in musicList)
		{
			if (!this.MusicNewSet.Contains(item))
			{
				this.MusicNewSet.Add(item);
			}
		}
		this.SaveCacheMusicNewData();
	}

	// Token: 0x0601111C RID: 69916 RVA: 0x004AF788 File Offset: 0x004AD988
	public void ClearMusicNew(int id)
	{
		if (this.MusicNewSet == null)
		{
			return;
		}
		if (this.MusicNewSet.Contains(id))
		{
			this.MusicNewSet.Remove(id);
			this.SaveCacheMusicNewData();
		}
	}

	// Token: 0x0601111D RID: 69917 RVA: 0x004AF7B4 File Offset: 0x004AD9B4
	public void SaveCacheMusicNewData()
	{
		if (this.MusicNewSet != null)
		{
			LocalStorage.SetPlayer<HashSet<int>>(ELocalStoragePlayerKey.MotorcycleMusicRedDot, this.MusicNewSet);
		}
	}

	// Token: 0x0601111E RID: 69918 RVA: 0x004AF7D0 File Offset: 0x004AD9D0
	public bool CheckAlbumHasNewMusic(int albumId)
	{
		foreach (PhonographMusic phonographMusic in this.GetMusicByAlbum(albumId))
		{
			if (this.IsMusicNew(phonographMusic.Id))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x0601111F RID: 69919 RVA: 0x004AF834 File Offset: 0x004ADA34
	public void ClearAlbum2MusicCache()
	{
		this.Album2MusicCache.Clear();
	}

	// Token: 0x06011120 RID: 69920 RVA: 0x004AF844 File Offset: 0x004ADA44
	public void SetAlbumTimeInfoMaps(IReadOnlyDictionary<int, IAlbumTimeInfo> albumMap, IReadOnlyDictionary<int, IAlbumTimeInfo> musicMap)
	{
		this.AlbumTimeInfoMap.Clear();
		this.MusicId2TimeInfoMap.Clear();
		foreach (KeyValuePair<int, IAlbumTimeInfo> keyValuePair in albumMap)
		{
			this.AlbumTimeInfoMap[keyValuePair.Key] = keyValuePair.Value;
		}
		foreach (KeyValuePair<int, IAlbumTimeInfo> keyValuePair2 in musicMap)
		{
			this.MusicId2TimeInfoMap[keyValuePair2.Key] = keyValuePair2.Value;
		}
	}

	// Token: 0x06011121 RID: 69921 RVA: 0x004AF900 File Offset: 0x004ADB00
	public void ClearAlbumTimeInfos()
	{
		this.AlbumTimeInfoMap.Clear();
		this.MusicId2TimeInfoMap.Clear();
	}

	// Token: 0x06011122 RID: 69922 RVA: 0x004AF918 File Offset: 0x004ADB18
	public bool IsTimeLimitAlbum(int albumId)
	{
		IAlbumTimeInfo albumTimeInfo;
		return this.AlbumTimeInfoMap.TryGetValue(albumId, out albumTimeInfo) && albumTimeInfo != null && (albumTimeInfo.BeginTime != 0L || albumTimeInfo.EndTime != 0L);
	}

	// Token: 0x06011123 RID: 69923 RVA: 0x004AF94B File Offset: 0x004ADB4B
	public bool ShouldFallbackForExpired(int albumId)
	{
		return albumId != -1 && this.GetAlbumTimeState(albumId).Item1 == EAlbumTimeState.Expired;
	}

	// Token: 0x06011124 RID: 69924 RVA: 0x004AF964 File Offset: 0x004ADB64
	[return: TupleElementNames(new string[]
	{
		"State",
		"Info",
		"NowSec"
	})]
	[return: Nullable(new byte[]
	{
		0,
		2
	})]
	private ValueTuple<EAlbumTimeState, IAlbumTimeInfo, long> GetAlbumTimeState(int albumId)
	{
		long num = 0L;
		IAlbumTimeInfo albumTimeInfo;
		this.AlbumTimeInfoMap.TryGetValue(albumId, out albumTimeInfo);
		if (albumTimeInfo == null)
		{
			return new ValueTuple<EAlbumTimeState, IAlbumTimeInfo, long>(EAlbumTimeState.Expired, null, num);
		}
		if (albumTimeInfo.BeginTime == 0L && albumTimeInfo.EndTime == 0L)
		{
			return new ValueTuple<EAlbumTimeState, IAlbumTimeInfo, long>(EAlbumTimeState.NoLimit, albumTimeInfo, num);
		}
		num = (long)Math.Floor(Singleton<TimeUtil>.Instance.GetServerTime());
		if (albumTimeInfo.BeginTime != 0L && num < albumTimeInfo.BeginTime)
		{
			return new ValueTuple<EAlbumTimeState, IAlbumTimeInfo, long>(EAlbumTimeState.NotStarted, albumTimeInfo, num);
		}
		if (albumTimeInfo.EndTime != 0L && num >= albumTimeInfo.EndTime)
		{
			return new ValueTuple<EAlbumTimeState, IAlbumTimeInfo, long>(EAlbumTimeState.Expired, albumTimeInfo, num);
		}
		return new ValueTuple<EAlbumTimeState, IAlbumTimeInfo, long>(EAlbumTimeState.InRange, albumTimeInfo, num);
	}

	// Token: 0x06011125 RID: 69925 RVA: 0x004AF9F8 File Offset: 0x004ADBF8
	public bool IsAlbumInTimeRange(int albumId)
	{
		EAlbumTimeState item = this.GetAlbumTimeState(albumId).Item1;
		return item == EAlbumTimeState.NoLimit || item == EAlbumTimeState.InRange;
	}

	// Token: 0x06011126 RID: 69926 RVA: 0x004AFA20 File Offset: 0x004ADC20
	public bool IsTimeLimitMusic(int musicId)
	{
		IAlbumTimeInfo albumTimeInfo;
		return this.MusicId2TimeInfoMap.TryGetValue(musicId, out albumTimeInfo) && albumTimeInfo != null && (albumTimeInfo.BeginTime != 0L || albumTimeInfo.EndTime != 0L);
	}

	// Token: 0x06011127 RID: 69927 RVA: 0x004AFA54 File Offset: 0x004ADC54
	[NullableContext(2)]
	public IAlbumTimeInfo GetAlbumTimeInfo(int albumId)
	{
		IAlbumTimeInfo result;
		this.AlbumTimeInfoMap.TryGetValue(albumId, out result);
		return result;
	}

	// Token: 0x06011128 RID: 69928 RVA: 0x004AFA74 File Offset: 0x004ADC74
	public string GetAlbumTimeLimitRemainText(int albumId)
	{
		ValueTuple<EAlbumTimeState, IAlbumTimeInfo, long> albumTimeState = this.GetAlbumTimeState(albumId);
		EAlbumTimeState item = albumTimeState.Item1;
		IAlbumTimeInfo item2 = albumTimeState.Item2;
		long item3 = albumTimeState.Item3;
		if (item != EAlbumTimeState.InRange || item2 == null)
		{
			if (item == EAlbumTimeState.NotStarted)
			{
			}
			return string.Empty;
		}
		long num = item2.EndTime - item3;
		return Singleton<TimeUtil>.Instance.GetRemainTimeDataFormat8((double)num).CountDownText;
	}

	// Token: 0x04008630 RID: 34352
	private List<int> FavoriteMusicList = new List<int>();

	// Token: 0x04008631 RID: 34353
	private int CurPlayMusicId = -1;

	// Token: 0x04008632 RID: 34354
	private int CurPlayAlbum = -1;

	// Token: 0x04008633 RID: 34355
	public HashSet<int> UnlockMusicIds = new HashSet<int>();

	// Token: 0x04008634 RID: 34356
	private EMotorMusicPlayMode PlayMode;

	// Token: 0x04008635 RID: 34357
	private bool IsPause;

	// Token: 0x04008636 RID: 34358
	private int PrevMusicId = -1;

	// Token: 0x04008637 RID: 34359
	[Nullable(2)]
	private HashSet<int> MusicNewSet;

	// Token: 0x04008638 RID: 34360
	public int CurrentPlayMusicTotalTime;

	// Token: 0x04008639 RID: 34361
	private List<int> CurrentPlayList = new List<int>();

	// Token: 0x0400863A RID: 34362
	private readonly Dictionary<int, List<PhonographMusic>> Album2MusicCache = new Dictionary<int, List<PhonographMusic>>();

	// Token: 0x0400863B RID: 34363
	private readonly Dictionary<int, IAlbumTimeInfo> AlbumTimeInfoMap = new Dictionary<int, IAlbumTimeInfo>();

	// Token: 0x0400863C RID: 34364
	private readonly Dictionary<int, IAlbumTimeInfo> MusicId2TimeInfoMap = new Dictionary<int, IAlbumTimeInfo>();

	// Token: 0x0400863D RID: 34365
	private int DisableCount;

	// Token: 0x0400863E RID: 34366
	private int VisibleState;
}
