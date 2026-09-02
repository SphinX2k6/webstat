using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using Aki.Config;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.AutoAttach;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200231A RID: 8986
[NullableContext(1)]
[Nullable(0)]
public class MotorcycleMusicPlayerView : UiViewBase
{
	// Token: 0x06011153 RID: 69971 RVA: 0x004B1044 File Offset: 0x004AF244
	public MotorcycleMusicPlayerView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06011154 RID: 69972 RVA: 0x004B10B8 File Offset: 0x004AF2B8
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIText)),
			new ValueTuple<int, Type>(5, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIText)),
			new ValueTuple<int, Type>(9, typeof(UUIItem)),
			new ValueTuple<int, Type>(10, typeof(UUIText)),
			new ValueTuple<int, Type>(11, typeof(UUIText)),
			new ValueTuple<int, Type>(12, typeof(UUISprite)),
			new ValueTuple<int, Type>(13, typeof(UUIText)),
			new ValueTuple<int, Type>(14, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(15, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(16, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(17, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(18, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(19, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(20, typeof(UUILoopScrollViewComponent)),
			new ValueTuple<int, Type>(21, typeof(UUISprite)),
			new ValueTuple<int, Type>(22, typeof(UUISprite)),
			new ValueTuple<int, Type>(23, typeof(UUIItem)),
			new ValueTuple<int, Type>(24, typeof(UUIItem)),
			new ValueTuple<int, Type>(25, typeof(UUIItem)),
			new ValueTuple<int, Type>(26, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(27, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(28, typeof(UUISprite)),
			new ValueTuple<int, Type>(29, typeof(UUIButtonComponent))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(5, new Action(this.OnClickBtnSort)),
			new ValueTuple<int, Delegate>(14, new Action<EToggleState>(this.OnExtendToggleLike)),
			new ValueTuple<int, Delegate>(15, new Action(this.OnClickBtnBack)),
			new ValueTuple<int, Delegate>(16, new Action<EToggleState>(this.OnExtendToggleTogPlay)),
			new ValueTuple<int, Delegate>(17, new Action(this.OnClickBtnNext)),
			new ValueTuple<int, Delegate>(18, new Action(this.OnClickBtnType)),
			new ValueTuple<int, Delegate>(19, new Action(this.OnClickBtnLikeMarkPos)),
			new ValueTuple<int, Delegate>(26, new Action(this.OnClickBtnNextAlbum)),
			new ValueTuple<int, Delegate>(27, new Action(this.OnClickBtnPrevAlbum)),
			new ValueTuple<int, Delegate>(29, new Action(this.OnClickBtnHelp))
		};
	}

	// Token: 0x06011155 RID: 69973 RVA: 0x004B147D File Offset: 0x004AF67D
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnMotorSwitchMusic, new Action(this.OnMotorSwitchMusic));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.OnMotorMusicForceRefresh, new Action<int>(this.OnMotorMusicForceRefresh));
	}

	// Token: 0x06011156 RID: 69974 RVA: 0x004B14B7 File Offset: 0x004AF6B7
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnMotorSwitchMusic, new Action(this.OnMotorSwitchMusic));
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.OnMotorMusicForceRefresh, new Action<int>(this.OnMotorMusicForceRefresh));
	}

	// Token: 0x06011157 RID: 69975 RVA: 0x004B14F4 File Offset: 0x004AF6F4
	private void OnMotorMusicForceRefresh(int albumId)
	{
		this.StartAlbumIndex = null;
		this.SelectAlbumId = -1;
		this.InitAlbumUiDataList(albumId);
		this.AlbumListView.ReloadView(this.AlbumUiDataList.Length, this.AlbumUiDataList, 0);
		int num = this.AlbumUiDataList.ToList<IAlbumUiData>().FindIndex((IAlbumUiData x) => x.Id == albumId);
		if (num == -1)
		{
			num = 0;
		}
		this.AlbumListView.AttachToIndex(Math.Max(num - 3, 0), true);
		this.AlbumListView.AttachToIndex(num, false);
		this.RefreshCurMusicInfo();
		this.RefreshMusicInfoAndList();
		this.RefreshPointerTween();
		int albumId2 = (num >= 0 && num < this.AlbumUiDataList.Length) ? this.AlbumUiDataList[num].Id : albumId;
		this.RefreshTimeLimitSprite(albumId2);
	}

	// Token: 0x06011158 RID: 69976 RVA: 0x004B15CC File Offset: 0x004AF7CC
	protected UniTask LoadCurveResource()
	{
		MotorcycleMusicPlayerView.<LoadCurveResource>d__27 <LoadCurveResource>d__;
		<LoadCurveResource>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<LoadCurveResource>d__.<>1__state = -1;
		<LoadCurveResource>d__.<>t__builder.Start<MotorcycleMusicPlayerView.<LoadCurveResource>d__27>(ref <LoadCurveResource>d__);
		return <LoadCurveResource>d__.<>t__builder.Task;
	}

	// Token: 0x06011159 RID: 69977 RVA: 0x004B1608 File Offset: 0x004AF808
	protected override UniTask OnBeforeStartAsync()
	{
		MotorcycleMusicPlayerView.<OnBeforeStartAsync>d__28 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<MotorcycleMusicPlayerView.<OnBeforeStartAsync>d__28>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0601115A RID: 69978 RVA: 0x004B164C File Offset: 0x004AF84C
	private void RefreshTimeLimitSprite(int albumId)
	{
		IAlbumTimeInfo albumTimeInfo = ModelBase<MotorcycleMusicPlayerModel>.Instance.GetAlbumTimeInfo(albumId);
		bool flag = false;
		if (albumTimeInfo != null && albumTimeInfo.MusicIds.Count > 0)
		{
			foreach (int musicId in albumTimeInfo.MusicIds)
			{
				if (ModelBase<MotorcycleMusicPlayerModel>.Instance.IsTimeLimitMusic(musicId))
				{
					flag = true;
					break;
				}
			}
		}
		UUISprite sprite = base.GetSprite(28);
		if (sprite != null)
		{
			sprite.SetUIActive(flag);
		}
		UUIButtonComponent button = base.GetButton(29);
		if (button != null)
		{
			UUIItem uuiitem = button.RootUIComp.Get();
			if (uuiitem != null)
			{
				uuiitem.SetUIActive(flag);
			}
		}
		if (flag)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), "MotorMusic_TimeLimited_Title", Array.Empty<object>());
			return;
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), "MotorMusicList", Array.Empty<object>());
	}

	// Token: 0x0601115B RID: 69979 RVA: 0x004B1740 File Offset: 0x004AF940
	private void OnClickBtnHelp()
	{
		ControllerBase<HelpController>.Instance.OpenHelpById(653);
	}

	// Token: 0x0601115C RID: 69980 RVA: 0x004B1751 File Offset: 0x004AF951
	private void CloseView()
	{
		base.CloseMe(null);
	}

	// Token: 0x0601115D RID: 69981 RVA: 0x004B175C File Offset: 0x004AF95C
	private void InitScrollView()
	{
		this.AlbumListView = new NoCircleAttachView<IAlbumUiData, MotorcycleAlbumItemGrid>(base.GetItem(2).GetOwner(), true);
		UUIItem item = base.GetItem(3);
		if (item != null)
		{
			item.SetUIActive(false);
		}
		this.AlbumListView.CreateItems(base.GetItem(3).GetOwner(), -(base.GetItem(3).GetWidth() - 276f), new Func<AActor, int, int, MotorcycleAlbumItemGrid>(this.CreateAlbumItem), EAttachDirection.Horizontal);
		this.AlbumListView.SetShowItemNum(7);
		this.AlbumListView.SetMoveItemsCallback(new Action(this.OnMoveItemsCallback));
		this.AlbumListView.SetMoveMultiFactor(ConfigBase<MotorcycleMusicPlayerConfig>.Instance.GetAlbumVelocity());
		UUILoopScrollViewComponent loopScrollViewComponent = base.GetLoopScrollViewComponent(20);
		UUIItem item2 = base.GetItem(7);
		AUIBaseActor auibaseActor = ((item2 != null) ? item2.GetOwner() : null) as AUIBaseActor;
		if (loopScrollViewComponent == null || auibaseActor == null)
		{
			return;
		}
		this.ScrollView = new LoopScrollView<MotorcycleMusicItemGrid, IMusicUiData>(loopScrollViewComponent, auibaseActor, new Func<MotorcycleMusicItemGrid>(this.CreateMusicItem), false);
	}

	// Token: 0x0601115E RID: 69982 RVA: 0x004B1848 File Offset: 0x004AFA48
	private void InitMusicListData()
	{
		PhonographConfig instance = ConfigBase<PhonographConfig>.Instance;
		foreach (PhonographMusic phonographMusic in (((instance != null) ? instance.GetMusicList() : null) ?? new List<PhonographMusic>()))
		{
			int[] albumArray = phonographMusic.GetAlbumArray();
			if (albumArray != null)
			{
				foreach (int key in albumArray)
				{
					if (!this.Album2MusicMap.ContainsKey(key))
					{
						this.Album2MusicMap[key] = new List<int>();
					}
					this.Album2MusicMap[key].Add(phonographMusic.Id);
				}
			}
		}
		this.FavoriteMusicList = ModelBase<MotorcycleMusicPlayerModel>.Instance.GetFavoriteMusicList().ToList<int>();
		foreach (List<int> list in this.Album2MusicMap.Values)
		{
			MotorcycleMusicPlayerModel model = ModelBase<MotorcycleMusicPlayerModel>.Instance;
			list.Sort(delegate(int aId, int bId)
			{
				bool flag = model.IsMusicUnlock(aId);
				bool flag2 = model.IsMusicUnlock(bId);
				if (flag == flag2)
				{
					return aId - bId;
				}
				if (!flag)
				{
					return 1;
				}
				return -1;
			});
		}
	}

	// Token: 0x0601115F RID: 69983 RVA: 0x004B197C File Offset: 0x004AFB7C
	private void InitLongPressButton()
	{
		LongPressButtonItem longPressButtonItem = new LongPressButtonItem(new OneOf<UUIButtonComponent, UUIExtendToggle>?(base.GetButton(26)), new LongPressButtonItem.ELongPressConfigId?(LongPressButtonItem.ELongPressConfigId.LongPressOne), new Action<bool>(this.OnLongPressNextButton));
		LongPressButtonItem longPressButtonItem2 = new LongPressButtonItem(new OneOf<UUIButtonComponent, UUIExtendToggle>?(base.GetButton(27)), new LongPressButtonItem.ELongPressConfigId?(LongPressButtonItem.ELongPressConfigId.LongPressOne), new Action<bool>(this.OnLongPressPreButton));
		longPressButtonItem.ShouldPlayLongPressSound = true;
		longPressButtonItem2.ShouldPlayLongPressSound = true;
	}

	// Token: 0x06011160 RID: 69984 RVA: 0x004B19EC File Offset: 0x004AFBEC
	protected override void OnBeforeShow()
	{
		FIntPoint viewportSize = this.RootItem.GetRootCanvas().GetViewportSize();
		float num = Singleton<MathUtils>.Instance.RangeClamp(base.GetItem(2).GetPositionInScreen(true).X, 0f, (float)viewportSize.X, -1f, 1f);
		float num2 = Singleton<MathUtils>.Instance.RangeClamp(base.GetItem(2).GetPositionInScreen(true).Y, 0f, (float)viewportSize.Y, 1f, -1f);
		this.ProjectOffset.X = (double)(-(double)num);
		this.ProjectOffset.Y = (double)(-(double)num2);
		Singleton<UiLayer>.Instance.UiRootItem.GetRootCanvas().ProjectCenterOffset = this.ProjectOffset.ToUeVector2D(false);
	}

	// Token: 0x06011161 RID: 69985 RVA: 0x004B1AAC File Offset: 0x004AFCAC
	protected override void OnAfterHide()
	{
		Singleton<UiLayer>.Instance.UiRootItem.GetRootCanvas().ProjectCenterOffset = Vector2D.ZeroVector;
	}

	// Token: 0x06011162 RID: 69986 RVA: 0x004B1AC8 File Offset: 0x004AFCC8
	private void OnMoveItemsCallback()
	{
		List<MotorcycleAlbumItemGrid> items = this.AlbumListView.GetItems();
		this.TempAlbumSortDataList.Clear();
		for (int i = 0; i < items.Count; i++)
		{
			if (i >= this.TempAlbumSortDataList.Count)
			{
				this.TempAlbumSortDataList.Add(new MotorcycleMusicPlayerView.TempAlbumSortData
				{
					UiItem = items[i].GetRootItem(),
					Distance = Math.Abs(items[i].GetCurrentMovePercentage() - 0.5f)
				});
			}
			else
			{
				this.TempAlbumSortDataList[i].UiItem = items[i].GetRootItem();
				this.TempAlbumSortDataList[i].Distance = Math.Abs(items[i].GetCurrentMovePercentage() - 0.5f);
			}
		}
		this.TempAlbumSortDataList = (from x in this.TempAlbumSortDataList
		orderby x.Distance
		select x).ToList<MotorcycleMusicPlayerView.TempAlbumSortData>();
		bool flag = false;
		for (int j = 1; j < this.TempAlbumSortDataList.Count; j += 2)
		{
			int hierarchyIndex = this.TempAlbumSortDataList[j - 1].UiItem.GetHierarchyIndex();
			if (this.TempAlbumSortDataList[j].UiItem.GetHierarchyIndex() > hierarchyIndex || (j + 1 < this.TempAlbumSortDataList.Count && this.TempAlbumSortDataList[j + 1].UiItem.GetHierarchyIndex() > hierarchyIndex))
			{
				flag = true;
				break;
			}
		}
		if (flag)
		{
			foreach (MotorcycleMusicPlayerView.TempAlbumSortData tempAlbumSortData in this.TempAlbumSortDataList)
			{
				tempAlbumSortData.UiItem.SetHierarchyIndex(-1);
			}
		}
	}

	// Token: 0x06011163 RID: 69987 RVA: 0x004B1C98 File Offset: 0x004AFE98
	private void TimerUpdate(float delta)
	{
		if (ModelBase<MotorcycleMusicPlayerModel>.Instance.GetIsPause())
		{
			return;
		}
		this.RotateAngle -= 0.2f;
		if (this.RotateAngle < -360f)
		{
			this.RotateAngle += 360f;
		}
		this.CdRotator.Yaw = this.RotateAngle;
		UUIItem sprite = base.GetSprite(22);
		FRotator frotator = this.CdRotator.ToUeRotator();
		sprite.SetUIRelativeRotation(frotator);
	}

	// Token: 0x06011164 RID: 69988 RVA: 0x004B1D0F File Offset: 0x004AFF0F
	private void OnRefreshProgressTimer(float delta)
	{
		this.RefreshCurMusicProgress();
	}

	// Token: 0x06011165 RID: 69989 RVA: 0x004B1D18 File Offset: 0x004AFF18
	private void InitAlbumUiDataList(int curPlayAlbum)
	{
		PhonographConfig instance = ConfigBase<PhonographConfig>.Instance;
		List<IAlbumUiData> list = (from x in (from x in ((instance != null) ? instance.GetMusicAlbumList() : null) ?? new List<PhonographAlbum>()
		where ModelBase<MotorcycleMusicPlayerModel>.Instance.IsAlbumInTimeRange(x.Id)
		select x).ToList<PhonographAlbum>()
		select new AlbumUiData
		{
			Id = x.Id,
			Config = x,
			UnlockMusicNum = ModelBase<MotorcycleMusicPlayerModel>.Instance.GetUnlockMusicByAlbum(x.Id).Count,
			AllMusicNum = (this.Album2MusicMap.ContainsKey(x.Id) ? this.Album2MusicMap[x.Id].Count : 0),
			IsSelected = new bool?(x.Id == curPlayAlbum)
		}).ToList<IAlbumUiData>();
		list.Sort((IAlbumUiData a, IAlbumUiData b) => a.Config.SortIndex - b.Config.SortIndex);
		this.AlbumUiDataList = list.ToArray();
	}

	// Token: 0x06011166 RID: 69990 RVA: 0x004B1DC4 File Offset: 0x004AFFC4
	protected override void OnBeforeDestroy()
	{
		if (this.DescTweenDelegate != null)
		{
			global::DelegateUtils.ReleaseManualReleaseDelegate(new Action<float>(this.OnSetDescOffsetX));
			this.DescTweenDelegate = null;
		}
		if (TimerSystem.Instance.Has(this.MusicDescTimer))
		{
			TimerSystem.Instance.Remove(this.MusicDescTimer);
			this.MusicDescTimer = null;
		}
		if (this.TimerHandle != null)
		{
			TimerSystem.Instance.Remove(this.TimerHandle);
			this.TimerHandle = null;
		}
		if (this.PlayTimeTimer != null)
		{
			TimerSystem.Instance.Remove(this.PlayTimeTimer);
			this.PlayTimeTimer = null;
		}
		this.ClearDescTween();
		if (this.SelectAlbumId == ConfigBase<MotorcycleMusicPlayerConfig>.Instance.GetFavoriteAlbumId())
		{
			this.SaveTempFavoriteMusicList(true);
			if (ModelBase<MotorcycleMusicPlayerModel>.Instance.GetCurPlayAlbum() == ConfigBase<MotorcycleMusicPlayerConfig>.Instance.GetFavoriteAlbumId())
			{
				ModelBase<MotorcycleMusicPlayerModel>.Instance.SetPlayList(ModelBase<MotorcycleMusicPlayerModel>.Instance.GetFavoriteMusicList().ToList<int>());
			}
		}
		ControllerBase<MotorcycleMusicPlayerController>.Instance.SendFavoriteUpdateRequest();
		Singleton<UiLayer>.Instance.UiRootItem.GetRootCanvas().ProjectCenterOffset = Vector2D.ZeroVector;
		ModelBase<MotorcycleMusicPlayerModel>.Instance.ClearAlbum2MusicCache();
		MotorcycleAlbumItemGrid.RotateCurve = null;
		MotorcycleAlbumItemGrid.ScaleCurve = null;
		MotorcycleAlbumItemGrid.AlphaCurve = null;
	}

	// Token: 0x06011167 RID: 69991 RVA: 0x004B1EE8 File Offset: 0x004B00E8
	private void SaveTempFavoriteMusicList(bool isSendRequest = false)
	{
		if (this.FavoriteMusicList == null)
		{
			return;
		}
		List<int> favoriteMusicList = (from x in this.FavoriteMusicList
		where ModelBase<MotorcycleMusicPlayerModel>.Instance.IsMusicFavorite(x)
		select x).ToList<int>();
		ModelBase<MotorcycleMusicPlayerModel>.Instance.SetFavoriteMusicList(favoriteMusicList);
	}

	// Token: 0x06011168 RID: 69992 RVA: 0x004B1F3C File Offset: 0x004B013C
	private void OnMotorSwitchMusic()
	{
		int curPlayAlbum = ModelBase<MotorcycleMusicPlayerModel>.Instance.GetCurPlayAlbum();
		int curPlayMusicId = ModelBase<MotorcycleMusicPlayerModel>.Instance.GetCurPlayMusicId();
		if (curPlayAlbum != -1 && curPlayMusicId != -1 && this.SelectAlbumId == curPlayAlbum)
		{
			this.RefreshCurMusicInfo();
			Predicate<IMusicUiData> <>9__1;
			this.RefreshMusicList(this.SelectAlbumId, false, false, delegate
			{
				if (this.ScrollView != null)
				{
					List<IMusicUiData> musicUiDataList = this.MusicUiDataList;
					Predicate<IMusicUiData> match;
					if ((match = <>9__1) == null)
					{
						match = (<>9__1 = ((IMusicUiData x) => x.Id == curPlayMusicId));
					}
					int num = musicUiDataList.FindIndex(match);
					if (num != -1 && !this.IsItemInViewport(num, 0))
					{
						this.ScrollView.ScrollToGridIndex(num, false);
					}
				}
			});
			this.AlbumListView.RefreshItems();
		}
		else
		{
			this.RefreshMusicInfoAndList();
		}
		this.PlayDescTween();
	}

	// Token: 0x06011169 RID: 69993 RVA: 0x004B1FC0 File Offset: 0x004B01C0
	private MotorcycleAlbumItemGrid CreateAlbumItem(AActor actor, int index, int showNum)
	{
		return new MotorcycleAlbumItemGrid(actor)
		{
			OnSelectAlbumItem = new Action<int>(this.OnSelectAlbumItem),
			OnClickAlbumItem = new Action<MotorcycleAlbumItemGrid, int>(this.OnClickAlbumItem),
			OnClickBtnPlay = new Action<MotorcycleAlbumItemGrid, int>(this.OnClickAlbumPlay)
		};
	}

	// Token: 0x0601116A RID: 69994 RVA: 0x004B1FFE File Offset: 0x004B01FE
	private MotorcycleMusicItemGrid CreateMusicItem()
	{
		return new MotorcycleMusicItemGrid
		{
			OnClickCallback = new Action<int>(this.OnClickMusicItem),
			OnClickLikeCallback = new Action<int>(this.OnClickLikeMusic)
		};
	}

	// Token: 0x0601116B RID: 69995 RVA: 0x004B2029 File Offset: 0x004B0229
	private void OnClickMusicItem(int musicId)
	{
		this.PlayMusic(musicId);
	}

	// Token: 0x0601116C RID: 69996 RVA: 0x004B2034 File Offset: 0x004B0234
	private void OnDescTweenComplete()
	{
		if (TimerSystem.Instance.Has(this.MusicDescTimer))
		{
			TimerSystem.Instance.Remove(this.MusicDescTimer);
			this.MusicDescTimer = null;
		}
		this.MusicDescTimer = TimerSystem.Instance.Delay(delegate(float _)
		{
			this.OnSetDescOffsetX(0f);
		}, 3000f, null, null, true, 1f);
	}

	// Token: 0x0601116D RID: 69997 RVA: 0x004B2094 File Offset: 0x004B0294
	private void OnSetDescOffsetX(float value)
	{
		base.GetText(10).SetAnchorOffsetX(value);
	}

	// Token: 0x0601116E RID: 69998 RVA: 0x004B20A4 File Offset: 0x004B02A4
	private void PlayDescTween()
	{
		this.OnSetDescOffsetX(0f);
		if (TimerSystem.Instance.Has(this.MusicDescTimer))
		{
			TimerSystem.Instance.Remove(this.MusicDescTimer);
		}
		this.ClearDescTween();
		this.MusicDescTimer = TimerSystem.Instance.Delay(delegate(float _)
		{
			float width = base.GetItem(9).GetWidth();
			float width2 = base.GetText(10).GetWidth();
			if (width2 > width)
			{
				this.ClearDescTween();
				this.DescTween = ULTweenBPLibrary.FloatTo(GlobalData.World, this.DescTweenDelegate, 0f, width - width2, (width2 - width) / 30f, 0f, LTweenEase.Linear);
				this.DescTween.OnCompleteCallBack.Bind(new Action(this.OnDescTweenComplete));
			}
		}, 1500f, null, null, true, 1f);
	}

	// Token: 0x0601116F RID: 69999 RVA: 0x004B210E File Offset: 0x004B030E
	private void ClearDescTween()
	{
		if (this.DescTween != null)
		{
			this.DescTween.Kill(false);
			this.DescTween = null;
		}
	}

	// Token: 0x06011170 RID: 70000 RVA: 0x004B212C File Offset: 0x004B032C
	private void PlayMusic(int musicId)
	{
		int albumId = this.SelectAlbumId;
		if (this.SelectAlbumId == ConfigBase<MotorcycleMusicPlayerConfig>.Instance.GetFavoriteAlbumId())
		{
			ModelBase<MotorcycleMusicPlayerModel>.Instance.SetPlayList(this.FavoriteMusicList ?? new List<int>());
			MotorcycleMusicPlayerModel instance = ModelBase<MotorcycleMusicPlayerModel>.Instance;
			if (instance.IsTimeLimitMusic(musicId))
			{
				PhonographConfig instance2 = ConfigBase<PhonographConfig>.Instance;
				PhonographMusic? phonographMusic = (instance2 != null) ? instance2.GetMusicById(musicId) : null;
				int[] array = (phonographMusic != null) ? phonographMusic.GetValueOrDefault().GetAlbumArray() : null;
				if (array != null)
				{
					foreach (int num in array)
					{
						if (instance.IsTimeLimitAlbum(num))
						{
							albumId = num;
							break;
						}
					}
				}
			}
		}
		else if (ModelBase<MotorcycleMusicPlayerModel>.Instance.GetCurPlayAlbum() != this.SelectAlbumId && this.SelectAlbumId != ConfigBase<MotorcycleMusicPlayerConfig>.Instance.GetFavoriteAlbumId())
		{
			ModelBase<MotorcycleMusicPlayerModel>.Instance.SetPlayList((from x in ModelBase<MotorcycleMusicPlayerModel>.Instance.GetUnlockMusicByAlbum(this.SelectAlbumId)
			select x.Id).ToList<int>());
		}
		ControllerBase<MotorcycleMusicPlayerController>.Instance.PlayAlbumMusic(albumId, musicId);
		this.RefreshPointerTween();
	}

	// Token: 0x06011171 RID: 70001 RVA: 0x004B2268 File Offset: 0x004B0468
	private void OnClickLikeMusic(int musicId)
	{
		if (musicId == -1)
		{
			return;
		}
		if (ModelBase<MotorcycleMusicPlayerModel>.Instance.IsMusicNew(musicId))
		{
			ModelBase<MotorcycleMusicPlayerModel>.Instance.ClearMusicNew(musicId);
		}
		bool flag = ControllerBase<MotorcycleMusicPlayerController>.Instance.RequestToggleMusicFavorite(musicId);
		if (ModelBase<MotorcycleMusicPlayerModel>.Instance.IsMusicFavorite(musicId))
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("MotorMusicTips05", Array.Empty<object>());
		}
		if (this.SelectAlbumId != ConfigBase<MotorcycleMusicPlayerConfig>.Instance.GetFavoriteAlbumId())
		{
			if (ModelBase<MotorcycleMusicPlayerModel>.Instance.GetCurPlayAlbum() == ConfigBase<MotorcycleMusicPlayerConfig>.Instance.GetFavoriteAlbumId())
			{
				ModelBase<MotorcycleMusicPlayerModel>.Instance.SetPlayList(ModelBase<MotorcycleMusicPlayerModel>.Instance.GetFavoriteMusicList().ToList<int>());
			}
			this.RefreshMusicInfoAndList();
			return;
		}
		this.RefreshCurMusicInfo();
		bool flag2 = ModelBase<MotorcycleMusicPlayerModel>.Instance.IsMusicFavorite(musicId);
		if (flag && flag2 && !this.FavoriteMusicList.Contains(musicId))
		{
			this.FavoriteMusicList.Insert(0, musicId);
			this.RefreshMusicList(ConfigBase<MotorcycleMusicPlayerConfig>.Instance.GetFavoriteAlbumId(), false, true, null);
		}
		else
		{
			if (flag && !flag2)
			{
				int num = this.FavoriteMusicList.IndexOf(musicId);
				if (num != -1)
				{
					this.FavoriteMusicList.RemoveAt(num);
				}
			}
			this.RefreshMusicList(ConfigBase<MotorcycleMusicPlayerConfig>.Instance.GetFavoriteAlbumId(), false, false, null);
		}
		this.AlbumListView.RefreshItems();
	}

	// Token: 0x06011172 RID: 70002 RVA: 0x004B2390 File Offset: 0x004B0590
	private void OnClickAlbumPlay(MotorcycleAlbumItemGrid itemGrid, int albumId)
	{
		if (this.SelectAlbumId != albumId)
		{
			NoCircleAttachView<IAlbumUiData, MotorcycleAlbumItemGrid> albumListView = this.AlbumListView;
			if (albumListView != null)
			{
				albumListView.AttachToIndex(this.AlbumUiDataList.ToList<IAlbumUiData>().FindIndex((IAlbumUiData x) => x.Id == albumId), false);
			}
			this.SelectAlbumId = albumId;
		}
		List<int> musicList = this.GetMusicList(albumId);
		int? num = (musicList != null && musicList.Count > 0) ? new int?(musicList[0]) : null;
		if (num != null && num.Value != 0)
		{
			this.PlayMusic(num.Value);
		}
		this.AlbumListView.RefreshItems();
	}

	// Token: 0x06011173 RID: 70003 RVA: 0x004B244D File Offset: 0x004B064D
	private void OnClickAlbumItem(MotorcycleAlbumItemGrid itemGrid, int _)
	{
		NoCircleAttachView<IAlbumUiData, MotorcycleAlbumItemGrid> albumListView = this.AlbumListView;
		if (albumListView == null)
		{
			return;
		}
		albumListView.AttachToIndex(itemGrid.GetCurrentShowItemIndex(), false);
	}

	// Token: 0x06011174 RID: 70004 RVA: 0x004B2468 File Offset: 0x004B0668
	private void OnSelectAlbumItem(int albumId)
	{
		if (this.StartAlbumIndex != null)
		{
			if (albumId != this.StartAlbumIndex.Value)
			{
				return;
			}
			this.StartAlbumIndex = null;
		}
		if (this.SelectAlbumId == albumId)
		{
			return;
		}
		IReadOnlyList<int> favoriteMusicList = ModelBase<MotorcycleMusicPlayerModel>.Instance.GetFavoriteMusicList();
		if (this.SelectAlbumId == ConfigBase<MotorcycleMusicPlayerConfig>.Instance.GetFavoriteAlbumId())
		{
			if (ModelBase<MotorcycleMusicPlayerModel>.Instance.GetCurPlayAlbum() == ConfigBase<MotorcycleMusicPlayerConfig>.Instance.GetFavoriteAlbumId())
			{
				ModelBase<MotorcycleMusicPlayerModel>.Instance.SetPlayList(favoriteMusicList.ToList<int>());
			}
			this.SaveTempFavoriteMusicList(false);
		}
		this.SelectAlbumId = albumId;
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), "MotorMusicAlbum", new <>z__ReadOnlyArray<object>(new object[]
		{
			this.AlbumUiDataList.ToList<IAlbumUiData>().FindIndex((IAlbumUiData x) => x.Id == albumId) + 1,
			this.AlbumUiDataList.Length
		}));
		this.RefreshMusicList(albumId, true, false, delegate
		{
			int num = this.MusicUiDataList.FindIndex((IMusicUiData x) => x.Id == ModelBase<MotorcycleMusicPlayerModel>.Instance.GetCurPlayMusicId());
			int gridIndex = (num != -1) ? num : 0;
			if (this.ScrollView.GetDisplayGridNum() == 0)
			{
				return;
			}
			if (!this.IsItemInViewport(gridIndex, 0))
			{
				this.ScrollView.ScrollToGridIndex(gridIndex, true);
			}
			else
			{
				this.ScrollView.ResetGridController();
			}
			UUIItem grid = this.ScrollView.GetGrid(gridIndex);
			if (grid != null && Singleton<Info>.Instance.IsInGamepad())
			{
				ControllerBase<UiNavigationNewController>.Instance.SetNavigationFocusForView(grid, false, false, false);
			}
		});
		UUIItem uuiitem = base.GetButton(5).RootUIComp.Get();
		bool uiactive;
		if (this.SelectAlbumId == ConfigBase<MotorcycleMusicPlayerConfig>.Instance.GetFavoriteAlbumId())
		{
			List<int> favoriteMusicList2 = this.FavoriteMusicList;
			uiactive = (((favoriteMusicList2 != null) ? favoriteMusicList2.Count : 0) >= 2);
		}
		else
		{
			uiactive = false;
		}
		uuiitem.SetUIActive(uiactive);
		UUIButtonComponent button = base.GetButton(26);
		if (button != null)
		{
			UUIItem uuiitem2 = button.RootUIComp.Get();
			if (uuiitem2 != null)
			{
				uuiitem2.SetUIActive(this.AlbumListView.GetCurrentSelectIndex() < this.AlbumUiDataList.Length - 1);
			}
		}
		UUIButtonComponent button2 = base.GetButton(27);
		if (button2 != null)
		{
			UUIItem uuiitem3 = button2.RootUIComp.Get();
			if (uuiitem3 != null)
			{
				uuiitem3.SetUIActive(this.AlbumListView.GetCurrentSelectIndex() > 0);
			}
		}
		base.GetButton(19).RootUIComp.Get().SetUIActive(this.SelectAlbumId != ConfigBase<MotorcycleMusicPlayerConfig>.Instance.GetFavoriteAlbumId());
		foreach (IAlbumUiData albumUiData in this.AlbumUiDataList)
		{
			albumUiData.IsSelected = new bool?(albumUiData.Id == this.SelectAlbumId);
		}
		NoCircleAttachView<IAlbumUiData, MotorcycleAlbumItemGrid> albumListView = this.AlbumListView;
		if (albumListView != null)
		{
			albumListView.RefreshItems();
		}
		this.RefreshTimeLimitSprite(this.SelectAlbumId);
	}

	// Token: 0x06011175 RID: 70005 RVA: 0x004B26C8 File Offset: 0x004B08C8
	private void RefreshCurMusicInfo()
	{
		int curPlayMusicId = ModelBase<MotorcycleMusicPlayerModel>.Instance.GetCurPlayMusicId();
		if (curPlayMusicId == -1)
		{
			return;
		}
		PhonographConfig instance = ConfigBase<PhonographConfig>.Instance;
		PhonographMusic? phonographMusic = (instance != null) ? instance.GetMusicById(curPlayMusicId) : null;
		if (phonographMusic == null)
		{
			return;
		}
		base.GetText(8).ShowTextNew(phonographMusic.Value.Title);
		string multiText = ConfigBase<TextConfig>.Instance.GetMultiText(phonographMusic.Value.Desc, Array.Empty<string>());
		string newText = (multiText != null) ? Regex.Replace(multiText, "[\\n]+", " ") : "";
		base.GetText(10).SetText(newText, true);
		bool flag = !ModelBase<MotorcycleMusicPlayerModel>.Instance.GetIsPause();
		base.GetExtendToggle(16).SetToggleStateForce(flag ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
		MotorcycleMusicPlayerModel instance2 = ModelBase<MotorcycleMusicPlayerModel>.Instance;
		bool flag2 = instance2 != null && instance2.IsMusicFavorite(curPlayMusicId);
		base.GetExtendToggle(14).SetToggleStateForce(flag2 ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
		this.RefreshCurMusicProgress();
	}

	// Token: 0x06011176 RID: 70006 RVA: 0x004B27CC File Offset: 0x004B09CC
	private void RefreshCurMusicProgress()
	{
		MotorcycleMusicPlayerModel instance = ModelBase<MotorcycleMusicPlayerModel>.Instance;
		int currentPlayTimeFromAudio = ControllerBase<MotorcycleMusicPlayerController>.Instance.GetCurrentPlayTimeFromAudio();
		float fillAmount = (float)currentPlayTimeFromAudio / (float)instance.CurrentPlayMusicTotalTime;
		if (instance.CurrentPlayMusicTotalTime == 0)
		{
			fillAmount = 0f;
		}
		base.GetSprite(12).SetFillAmount(fillAmount);
		base.GetText(11).SetText(Singleton<TimeUtil>.Instance.GetTimeDataFormat((double)currentPlayTimeFromAudio), true);
		base.GetText(13).SetText("/" + Singleton<TimeUtil>.Instance.GetTimeDataFormat((double)instance.CurrentPlayMusicTotalTime), true);
	}

	// Token: 0x06011177 RID: 70007 RVA: 0x004B2854 File Offset: 0x004B0A54
	[NullableContext(2)]
	private List<int> GetMusicList(int albumId)
	{
		if (albumId == ConfigBase<MotorcycleMusicPlayerConfig>.Instance.GetFavoriteAlbumId())
		{
			return this.FavoriteMusicList;
		}
		if (!this.Album2MusicMap.ContainsKey(albumId))
		{
			return null;
		}
		return this.Album2MusicMap[albumId];
	}

	// Token: 0x06011178 RID: 70008 RVA: 0x004B2888 File Offset: 0x004B0A88
	private bool IsFavoriteMusicExpired(int musicId)
	{
		MotorcycleMusicPlayerModel model = ModelBase<MotorcycleMusicPlayerModel>.Instance;
		if (!model.IsTimeLimitMusic(musicId))
		{
			return false;
		}
		PhonographConfig instance = ConfigBase<PhonographConfig>.Instance;
		PhonographMusic? phonographMusic = (instance != null) ? instance.GetMusicById(musicId) : null;
		if (phonographMusic == null)
		{
			return false;
		}
		int[] albumArray = phonographMusic.Value.GetAlbumArray();
		return albumArray != null && !albumArray.Any((int id) => model.IsAlbumInTimeRange(id));
	}

	// Token: 0x06011179 RID: 70009 RVA: 0x004B2908 File Offset: 0x004B0B08
	[NullableContext(2)]
	private void RefreshMusicList(int albumId, bool isClick = false, bool isPlayAnim = false, Action onComplete = null)
	{
		List<int> list = this.Album2MusicMap.ContainsKey(albumId) ? this.Album2MusicMap[albumId] : null;
		if (albumId == ConfigBase<MotorcycleMusicPlayerConfig>.Instance.GetFavoriteAlbumId())
		{
			if (isClick)
			{
				list = ModelBase<MotorcycleMusicPlayerModel>.Instance.GetFavoriteMusicList().ToList<int>();
				this.FavoriteMusicList = list;
			}
			else
			{
				list = this.FavoriteMusicList;
			}
			list = ((list != null) ? (from id in list
			where !this.IsFavoriteMusicExpired(id)
			select id).ToList<int>() : null);
			this.FavoriteMusicList = list;
			ModelBase<MotorcycleMusicPlayerModel>.Instance.SetFavoriteMusicList(list ?? new List<int>());
		}
		if (list == null)
		{
			list = new List<int>();
		}
		List<IMusicUiData> list2 = (from id in list
		select new MusicUiData
		{
			Id = id,
			IsFavorite = new bool?(ModelBase<MotorcycleMusicPlayerModel>.Instance.IsMusicFavorite(id))
		}).ToList<IMusicUiData>();
		this.MusicUiDataList = list2;
		this.ScrollView.RefreshByData(list2, false, onComplete, isPlayAnim);
		UUIItem item = base.GetItem(23);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(list2.Count == 0);
	}

	// Token: 0x0601117A RID: 70010 RVA: 0x004B2A02 File Offset: 0x004B0C02
	private void RefreshMusicInfoAndList()
	{
		this.RefreshCurMusicInfo();
		this.RefreshMusicList(this.SelectAlbumId, false, false, null);
		this.AlbumListView.RefreshItems();
	}

	// Token: 0x0601117B RID: 70011 RVA: 0x004B2A24 File Offset: 0x004B0C24
	private void OnPlayModeChanged()
	{
		this.SetSpriteByPath(ConfigBase<UiResourceConfig>.Instance.GetResourcePath(MotorcycleMusicPlayerDefine.motorMusicPlayModeIcon[ModelBase<MotorcycleMusicPlayerModel>.Instance.GetPlayMode()]), base.GetSprite(21), false, null, null);
	}

	// Token: 0x0601117C RID: 70012 RVA: 0x004B2A68 File Offset: 0x004B0C68
	private void OnClickBtnSort()
	{
		if (ModelBase<MotorcycleMusicPlayerModel>.Instance.GetFavoriteMusicList().Count >= 2)
		{
			MusicSortViewOpenParams param = new MusicSortViewOpenParams
			{
				MusicList = this.FavoriteMusicList,
				OnCallback = new Action<List<int>>(this.OnSortFinishCallback)
			};
			Singleton<UiManager>.Instance.OpenView(EUiViewName.MotorcycleMusicSortView, param, null);
		}
	}

	// Token: 0x0601117D RID: 70013 RVA: 0x004B2ABC File Offset: 0x004B0CBC
	private void OnSortFinishCallback(List<int> musicList)
	{
		this.FavoriteMusicList = musicList;
		this.RefreshMusicList(this.SelectAlbumId, false, true, null);
		if (ModelBase<MotorcycleMusicPlayerModel>.Instance.GetCurPlayAlbum() == ConfigBase<MotorcycleMusicPlayerConfig>.Instance.GetFavoriteAlbumId())
		{
			ModelBase<MotorcycleMusicPlayerModel>.Instance.SetPlayList(this.FavoriteMusicList.ToList<int>());
		}
	}

	// Token: 0x0601117E RID: 70014 RVA: 0x004B2B0A File Offset: 0x004B0D0A
	private void OnExtendToggleLike(EToggleState toggleState)
	{
		this.OnClickLikeMusic(ModelBase<MotorcycleMusicPlayerModel>.Instance.GetCurPlayMusicId());
	}

	// Token: 0x0601117F RID: 70015 RVA: 0x004B2B1C File Offset: 0x004B0D1C
	private void OnClickBtnBack()
	{
		ControllerBase<MotorcycleMusicPlayerController>.Instance.QuickPlayMusic(false);
		this.RefreshPointerTween();
	}

	// Token: 0x06011180 RID: 70016 RVA: 0x004B2B2F File Offset: 0x004B0D2F
	private void OnExtendToggleTogPlay(EToggleState toggleState)
	{
		if (ModelBase<MotorcycleMusicPlayerModel>.Instance.GetIsPause())
		{
			ControllerBase<MotorcycleMusicPlayerController>.Instance.ResumeMusic();
		}
		else
		{
			ControllerBase<MotorcycleMusicPlayerController>.Instance.PauseMusic();
		}
		this.RefreshPointerTween();
		this.RefreshMusicInfoAndList();
	}

	// Token: 0x06011181 RID: 70017 RVA: 0x004B2B60 File Offset: 0x004B0D60
	private void RefreshPointerTween()
	{
		bool isPause = ModelBase<MotorcycleMusicPlayerModel>.Instance.GetIsPause();
		if (isPause == this.IsPointerPause)
		{
			return;
		}
		this.IsPointerPause = isPause;
		if (isPause)
		{
			ULGUIPlayTweenComponent startTweenComp = this.StartTweenComp;
			if (startTweenComp != null)
			{
				startTweenComp.Stop();
			}
			ULGUIPlayTweenComponent stopTweenComp = this.StopTweenComp;
			if (stopTweenComp == null)
			{
				return;
			}
			stopTweenComp.Play();
			return;
		}
		else
		{
			ULGUIPlayTweenComponent startTweenComp2 = this.StartTweenComp;
			if (startTweenComp2 != null)
			{
				startTweenComp2.Play();
			}
			ULGUIPlayTweenComponent stopTweenComp2 = this.StopTweenComp;
			if (stopTweenComp2 == null)
			{
				return;
			}
			stopTweenComp2.Stop();
			return;
		}
	}

	// Token: 0x06011182 RID: 70018 RVA: 0x004B2BCF File Offset: 0x004B0DCF
	private void OnClickBtnNext()
	{
		ControllerBase<MotorcycleMusicPlayerController>.Instance.QuickPlayMusic(true);
		this.RefreshPointerTween();
	}

	// Token: 0x06011183 RID: 70019 RVA: 0x004B2BE2 File Offset: 0x004B0DE2
	private void OnLongPressNextButton(bool isShortPress)
	{
		ControllerBase<UiNavigationNewController>.Instance.ResetNavigationFocusForViewWithDirtyCheck();
		NoCircleAttachView<IAlbumUiData, MotorcycleAlbumItemGrid> albumListView = this.AlbumListView;
		if (albumListView == null)
		{
			return;
		}
		albumListView.AttachToNextItem(1);
	}

	// Token: 0x06011184 RID: 70020 RVA: 0x004B2BFF File Offset: 0x004B0DFF
	private void OnClickBtnNextAlbum()
	{
		ControllerBase<UiNavigationNewController>.Instance.ResetNavigationFocusForViewWithDirtyCheck();
		NoCircleAttachView<IAlbumUiData, MotorcycleAlbumItemGrid> albumListView = this.AlbumListView;
		if (albumListView == null)
		{
			return;
		}
		albumListView.AttachToNextItem(1);
	}

	// Token: 0x06011185 RID: 70021 RVA: 0x004B2C1C File Offset: 0x004B0E1C
	private void OnLongPressPreButton(bool isShortPress)
	{
		ControllerBase<UiNavigationNewController>.Instance.ResetNavigationFocusForViewWithDirtyCheck();
		NoCircleAttachView<IAlbumUiData, MotorcycleAlbumItemGrid> albumListView = this.AlbumListView;
		if (albumListView == null)
		{
			return;
		}
		albumListView.AttachToNextItem(-1);
	}

	// Token: 0x06011186 RID: 70022 RVA: 0x004B2C39 File Offset: 0x004B0E39
	private void OnClickBtnPrevAlbum()
	{
		ControllerBase<UiNavigationNewController>.Instance.ResetNavigationFocusForViewWithDirtyCheck();
		NoCircleAttachView<IAlbumUiData, MotorcycleAlbumItemGrid> albumListView = this.AlbumListView;
		if (albumListView == null)
		{
			return;
		}
		albumListView.AttachToNextItem(-1);
	}

	// Token: 0x06011187 RID: 70023 RVA: 0x004B2C58 File Offset: 0x004B0E58
	private void OnClickBtnType()
	{
		EMotorMusicPlayMode emotorMusicPlayMode = ModelBase<MotorcycleMusicPlayerModel>.Instance.GetPlayMode();
		switch (emotorMusicPlayMode)
		{
		case EMotorMusicPlayMode.Order:
			emotorMusicPlayMode = EMotorMusicPlayMode.Random;
			break;
		case EMotorMusicPlayMode.Random:
			emotorMusicPlayMode = EMotorMusicPlayMode.Repeat;
			break;
		case EMotorMusicPlayMode.Repeat:
			emotorMusicPlayMode = EMotorMusicPlayMode.Order;
			break;
		}
		ModelBase<MotorcycleMusicPlayerModel>.Instance.SetCurPlayMode(emotorMusicPlayMode);
		ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId(MotorcycleMusicPlayerDefine.motorPlayModeName[emotorMusicPlayMode], Array.Empty<object>());
		this.OnPlayModeChanged();
	}

	// Token: 0x06011188 RID: 70024 RVA: 0x004B2CBC File Offset: 0x004B0EBC
	private void OnClickBtnLikeMarkPos()
	{
		NoCircleAttachView<IAlbumUiData, MotorcycleAlbumItemGrid> albumListView = this.AlbumListView;
		if (albumListView == null)
		{
			return;
		}
		albumListView.AttachToIndex(this.AlbumUiDataList.ToList<IAlbumUiData>().FindIndex((IAlbumUiData x) => x.Id == ConfigBase<MotorcycleMusicPlayerConfig>.Instance.GetFavoriteAlbumId()), false);
	}

	// Token: 0x06011189 RID: 70025 RVA: 0x004B2D0C File Offset: 0x004B0F0C
	public bool IsItemInViewport(int gridIndex, int tolerance = 0)
	{
		if (this.ScrollView == null)
		{
			return false;
		}
		if (!this.ScrollView.IsGridDisplaying(gridIndex))
		{
			return false;
		}
		UUIItem grid = this.ScrollView.GetGrid(gridIndex);
		if (grid == null)
		{
			return false;
		}
		UUILoopScrollViewComponent loopScrollViewComponent = base.GetLoopScrollViewComponent(20);
		UUIItem uuiitem = loopScrollViewComponent.ContentUIItem.Get();
		AUIBaseActor viewport = loopScrollViewComponent.GetViewport();
		UUIItem uuiitem2 = (viewport != null) ? viewport.GetUIItem() : null;
		if (uuiitem == null || uuiitem2 == null)
		{
			return false;
		}
		float anchorOffsetY = grid.GetAnchorOffsetY();
		float height = grid.GetHeight();
		float height2 = uuiitem2.GetHeight();
		return -anchorOffsetY >= uuiitem.GetAnchorOffsetY() && -anchorOffsetY + height <= uuiitem.GetAnchorOffsetY() + height2;
	}

	// Token: 0x04008667 RID: 34407
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private LoopScrollView<MotorcycleMusicItemGrid, IMusicUiData> ScrollView;

	// Token: 0x04008668 RID: 34408
	private readonly Dictionary<int, List<int>> Album2MusicMap = new Dictionary<int, List<int>>();

	// Token: 0x04008669 RID: 34409
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private NoCircleAttachView<IAlbumUiData, MotorcycleAlbumItemGrid> AlbumListView;

	// Token: 0x0400866A RID: 34410
	private int SelectAlbumId = -1;

	// Token: 0x0400866B RID: 34411
	private IAlbumUiData[] AlbumUiDataList;

	// Token: 0x0400866C RID: 34412
	[Nullable(2)]
	private List<int> FavoriteMusicList;

	// Token: 0x0400866D RID: 34413
	[Nullable(2)]
	private FLTweenFloatSetterDynamic DescTweenDelegate;

	// Token: 0x0400866E RID: 34414
	[Nullable(2)]
	private ULTweener DescTween;

	// Token: 0x0400866F RID: 34415
	[Nullable(2)]
	private TimerHandle MusicDescTimer;

	// Token: 0x04008670 RID: 34416
	[Nullable(2)]
	private TimerHandle TimerHandle;

	// Token: 0x04008671 RID: 34417
	[Nullable(2)]
	private TimerHandle PlayTimeTimer;

	// Token: 0x04008672 RID: 34418
	private float RotateAngle;

	// Token: 0x04008673 RID: 34419
	[Nullable(2)]
	private ULGUIPlayTweenComponent StartTweenComp;

	// Token: 0x04008674 RID: 34420
	[Nullable(2)]
	private ULGUIPlayTweenComponent StopTweenComp;

	// Token: 0x04008675 RID: 34421
	private readonly Rotator CdRotator = Rotator.Create(0f, 0f, 0f);

	// Token: 0x04008676 RID: 34422
	private bool IsPointerPause;

	// Token: 0x04008677 RID: 34423
	private readonly Vector2D ProjectOffset = Vector2D.Create(0.0, 0.0);

	// Token: 0x04008678 RID: 34424
	private List<MotorcycleMusicPlayerView.TempAlbumSortData> TempAlbumSortDataList = new List<MotorcycleMusicPlayerView.TempAlbumSortData>();

	// Token: 0x04008679 RID: 34425
	private List<IMusicUiData> MusicUiDataList = new List<IMusicUiData>();

	// Token: 0x0400867A RID: 34426
	private int? StartAlbumIndex;

	// Token: 0x02008622 RID: 34338
	[NullableContext(0)]
	private class EComponents
	{
		// Token: 0x0402D5D7 RID: 185815
		public const int UiItemCaption = 0;

		// Token: 0x0402D5D8 RID: 185816
		public const int TxtAlbumNum = 1;

		// Token: 0x0402D5D9 RID: 185817
		public const int PanelDrag = 2;

		// Token: 0x0402D5DA RID: 185818
		public const int TogAlbum = 3;

		// Token: 0x0402D5DB RID: 185819
		public const int TxtDescName = 4;

		// Token: 0x0402D5DC RID: 185820
		public const int BtnSort = 5;

		// Token: 0x0402D5DD RID: 185821
		public const int Content = 6;

		// Token: 0x0402D5DE RID: 185822
		public const int TogCommon2 = 7;

		// Token: 0x0402D5DF RID: 185823
		public const int TxtMusicName = 8;

		// Token: 0x0402D5E0 RID: 185824
		public const int PanelClip = 9;

		// Token: 0x0402D5E1 RID: 185825
		public const int TxtDesc = 10;

		// Token: 0x0402D5E2 RID: 185826
		public const int TxtDescTimeL = 11;

		// Token: 0x0402D5E3 RID: 185827
		public const int SpriteProgressBar = 12;

		// Token: 0x0402D5E4 RID: 185828
		public const int TxtDescTimeR = 13;

		// Token: 0x0402D5E5 RID: 185829
		public const int TogLike = 14;

		// Token: 0x0402D5E6 RID: 185830
		public const int BtnBack = 15;

		// Token: 0x0402D5E7 RID: 185831
		public const int TogPlay = 16;

		// Token: 0x0402D5E8 RID: 185832
		public const int BtnNext = 17;

		// Token: 0x0402D5E9 RID: 185833
		public const int BtnType = 18;

		// Token: 0x0402D5EA RID: 185834
		public const int BtnLikeMarkPos = 19;

		// Token: 0x0402D5EB RID: 185835
		public const int SvDefault = 20;

		// Token: 0x0402D5EC RID: 185836
		public const int SpritePlayMode = 21;

		// Token: 0x0402D5ED RID: 185837
		public const int SpriteCDIcon = 22;

		// Token: 0x0402D5EE RID: 185838
		public const int PanelEmpty = 23;

		// Token: 0x0402D5EF RID: 185839
		public const int StartTween = 24;

		// Token: 0x0402D5F0 RID: 185840
		public const int StopTween = 25;

		// Token: 0x0402D5F1 RID: 185841
		public const int BtnNextAlbum = 26;

		// Token: 0x0402D5F2 RID: 185842
		public const int BtnPrevAlbum = 27;

		// Token: 0x0402D5F3 RID: 185843
		public const int SprTimeLimit = 28;

		// Token: 0x0402D5F4 RID: 185844
		public const int BtnHelpB = 29;
	}

	// Token: 0x02008623 RID: 34339
	[NullableContext(0)]
	private class TempAlbumSortData
	{
		// Token: 0x0402D5F5 RID: 185845
		[Nullable(1)]
		public UUIItem UiItem;

		// Token: 0x0402D5F6 RID: 185846
		public float Distance;
	}
}
