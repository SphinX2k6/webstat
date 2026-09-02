using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200259B RID: 9627
[NullableContext(1)]
[Nullable(0)]
public class PhonographView : UiTickViewBase
{
	// Token: 0x06012C18 RID: 76824 RVA: 0x0052C937 File Offset: 0x0052AB37
	public PhonographView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06012C19 RID: 76825 RVA: 0x0052C94C File Offset: 0x0052AB4C
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIVerticalLayout)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUIVerticalLayout)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIText)),
			new ValueTuple<int, Type>(7, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(8, typeof(UUIText)),
			new ValueTuple<int, Type>(9, typeof(UUIText)),
			new ValueTuple<int, Type>(10, typeof(UUIText)),
			new ValueTuple<int, Type>(11, typeof(UUIScrollViewWithScrollbarComponent)),
			new ValueTuple<int, Type>(12, typeof(UUIButtonComponent))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(7, new Action(this.OnClickSetBgMusic)),
			new ValueTuple<int, Delegate>(12, new Action(this.OnClickLimitTimeRule))
		};
	}

	// Token: 0x06012C1A RID: 76826 RVA: 0x0052CAC4 File Offset: 0x0052ACC4
	protected override UniTask OnBeforeStartAsync()
	{
		PhonographView.<OnBeforeStartAsync>d__11 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<PhonographView.<OnBeforeStartAsync>d__11>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06012C1B RID: 76827 RVA: 0x0052CB07 File Offset: 0x0052AD07
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.OnPhonographMusicForceRefresh, new Action<int>(this.OnMusicForceRefresh));
	}

	// Token: 0x06012C1C RID: 76828 RVA: 0x0052CB25 File Offset: 0x0052AD25
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.OnPhonographMusicForceRefresh, new Action<int>(this.OnMusicForceRefresh));
	}

	// Token: 0x06012C1D RID: 76829 RVA: 0x0052CB44 File Offset: 0x0052AD44
	protected override void OnTick(float delta)
	{
		if (this.MusicGenericLayout.IsLock)
		{
			return;
		}
		foreach (PhonographMusicPlayItem phonographMusicPlayItem in this.MusicGenericLayout.GetLayoutItemList())
		{
			phonographMusicPlayItem.OnTick();
		}
	}

	// Token: 0x06012C1E RID: 76830 RVA: 0x0052CBA8 File Offset: 0x0052ADA8
	protected override void OnBeforeDestroy()
	{
		ModelBase<PhonographModel>.Instance.NewMusicIds = new List<int>();
		if (ModelBase<PhonographModel>.Instance.IsGlobal)
		{
			if (ModelBase<PhonographModel>.Instance.CurrentPlayMusicId != ModelBase<PhonographModel>.Instance.RecordMusicId)
			{
				ControllerBase<PhonographController>.Instance.StopMusic(false);
				if (ModelBase<PhonographModel>.Instance.RecordMusicId != 0)
				{
					ControllerBase<PhonographController>.Instance.PlayGlobalMusic(ModelBase<PhonographModel>.Instance.RecordMusicId, true);
					return;
				}
			}
		}
		else if (ModelBase<PhonographModel>.Instance.CurrentPlayMusicId != ModelBase<PhonographModel>.Instance.RecordMusicId)
		{
			ControllerBase<PhonographController>.Instance.StopMusic(false);
			PhonographModel instance = ModelBase<PhonographModel>.Instance;
			int? num = (instance != null) ? instance.EntityId : null;
			if (ModelBase<PhonographModel>.Instance.RecordMusicId != 0)
			{
				int musicId = ControllerBase<PhonographController>.Instance.PlayMusic(ModelBase<PhonographModel>.Instance.RecordMusicId, false);
				ModelBase<PhonographModel>.Instance.SetPlayIdRecord(num.Value, musicId);
			}
		}
	}

	// Token: 0x06012C1F RID: 76831 RVA: 0x0052CC8C File Offset: 0x0052AE8C
	protected UniTask RefreshAlbumList(int selectMusicId)
	{
		PhonographView.<RefreshAlbumList>d__16 <RefreshAlbumList>d__;
		<RefreshAlbumList>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshAlbumList>d__.<>4__this = this;
		<RefreshAlbumList>d__.selectMusicId = selectMusicId;
		<RefreshAlbumList>d__.<>1__state = -1;
		<RefreshAlbumList>d__.<>t__builder.Start<PhonographView.<RefreshAlbumList>d__16>(ref <RefreshAlbumList>d__);
		return <RefreshAlbumList>d__.<>t__builder.Task;
	}

	// Token: 0x06012C20 RID: 76832 RVA: 0x0052CCD8 File Offset: 0x0052AED8
	protected void RefreshAlbumInfo(int albumId)
	{
		PhonographConfig instance = ConfigBase<PhonographConfig>.Instance;
		PhonographAlbum? phonographAlbum = (instance != null) ? instance.GetMusicAlbumById(albumId) : null;
		if (phonographAlbum == null)
		{
			return;
		}
		PhonographAlbum value = phonographAlbum.Value;
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(6), value.Title, Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(8), value.Desc, Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), value.Title, Array.Empty<object>());
		MotorcycleMusicPlayerModel instance2 = ModelBase<MotorcycleMusicPlayerModel>.Instance;
		if (instance2 != null && instance2.IsTimeLimitAlbum(albumId))
		{
			UUIButtonComponent button = base.GetButton(12);
			if (button == null)
			{
				return;
			}
			UUIItem uuiitem = button.RootUIComp.Get();
			if (uuiitem == null)
			{
				return;
			}
			uuiitem.SetUIActive(true);
			return;
		}
		else
		{
			UUIButtonComponent button2 = base.GetButton(12);
			if (button2 == null)
			{
				return;
			}
			UUIItem uuiitem2 = button2.RootUIComp.Get();
			if (uuiitem2 == null)
			{
				return;
			}
			uuiitem2.SetUIActive(false);
			return;
		}
	}

	// Token: 0x06012C21 RID: 76833 RVA: 0x0052CDC8 File Offset: 0x0052AFC8
	protected void OnClickLimitTimeRule()
	{
		ControllerBase<HelpController>.Instance.OpenHelpById(653);
	}

	// Token: 0x06012C22 RID: 76834 RVA: 0x0052CDDC File Offset: 0x0052AFDC
	protected void RefreshMusicInfo(int musicId)
	{
		PhonographConfig instance = ConfigBase<PhonographConfig>.Instance;
		PhonographMusic? phonographMusic = (instance != null) ? instance.GetMusicById(musicId) : null;
		if (phonographMusic == null)
		{
			return;
		}
		PhonographMusic value = phonographMusic.Value;
		if (ModelBase<PhonographModel>.Instance.IsUnlockMusic(musicId))
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(8), value.Desc, Array.Empty<object>());
		}
		else
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(8), value.UnlockConditionText, Array.Empty<object>());
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(6), value.Title, Array.Empty<object>());
		this.RefreshSwitchBtn(musicId);
	}

	// Token: 0x06012C23 RID: 76835 RVA: 0x0052CE84 File Offset: 0x0052B084
	protected void RefreshSwitchBtn(int musicId)
	{
		UUIItem rootComponent = base.GetButton(7).GetRootComponent();
		if (rootComponent != null)
		{
			rootComponent.SetUIActive(musicId != 0 && ModelBase<PhonographModel>.Instance.IsUnlockMusic(musicId));
		}
		bool flag = ModelBase<PhonographModel>.Instance.RecordMusicId == musicId;
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(10), flag ? "PhonographSwitchBtnNormal" : "PhonographSwitchBtnSelect", Array.Empty<object>());
	}

	// Token: 0x06012C24 RID: 76836 RVA: 0x0052CEED File Offset: 0x0052B0ED
	protected PhonographAlbumItem OnCreateAlbumItem()
	{
		return new PhonographAlbumItem
		{
			OnClickAlbumItem = new Action<int, int>(this.OnClickAlbumItem)
		};
	}

	// Token: 0x06012C25 RID: 76837 RVA: 0x0052CF06 File Offset: 0x0052B106
	protected PhonographMusicPlayItem OnCreateMusicItem()
	{
		return new PhonographMusicPlayItem
		{
			OnClickMusicItem = new Action<int, int>(this.OnClickMusicItem)
		};
	}

	// Token: 0x06012C26 RID: 76838 RVA: 0x0052CF20 File Offset: 0x0052B120
	protected void OnClickAlbumItem(int albumId, int gridIndex)
	{
		PhonographView.<>c__DisplayClass23_0 CS$<>8__locals1 = new PhonographView.<>c__DisplayClass23_0();
		CS$<>8__locals1.<>4__this = this;
		this.CurrentAlbumId = albumId;
		this.AlbumGenericLayout.SelectGridProxy(gridIndex, false);
		List<int> list;
		List<int> collection = this.MusicMap.TryGetValue(albumId, out list) ? list : new List<int>();
		CS$<>8__locals1.filterList = new List<int>(collection);
		CS$<>8__locals1.filterList.Sort(delegate(int a, int b)
		{
			bool flag = ModelBase<PhonographModel>.Instance.CurrentPlayMusicId == a;
			bool flag2 = ModelBase<PhonographModel>.Instance.CurrentPlayMusicId == b;
			if (flag && !flag2)
			{
				return -1;
			}
			if (!flag && flag2)
			{
				return 1;
			}
			if (ModelBase<PhonographModel>.Instance.IsNewMusic(a) && !ModelBase<PhonographModel>.Instance.IsNewMusic(b))
			{
				return -1;
			}
			if (!ModelBase<PhonographModel>.Instance.IsNewMusic(a) && ModelBase<PhonographModel>.Instance.IsNewMusic(b))
			{
				return 1;
			}
			if (ModelBase<PhonographModel>.Instance.IsUnlockMusic(a) && !ModelBase<PhonographModel>.Instance.IsUnlockMusic(b))
			{
				return -1;
			}
			if (!ModelBase<PhonographModel>.Instance.IsUnlockMusic(a) && ModelBase<PhonographModel>.Instance.IsUnlockMusic(b))
			{
				return 1;
			}
			return a - b;
		});
		int num = 0;
		CS$<>8__locals1.selectIndex = -1;
		foreach (int num2 in CS$<>8__locals1.filterList)
		{
			if (ModelBase<PhonographModel>.Instance.IsUnlockMusic(num2))
			{
				num++;
			}
			PhonographModel instance = ModelBase<PhonographModel>.Instance;
			if (instance != null && instance.CurrentPlayMusicId == num2)
			{
				CS$<>8__locals1.selectIndex = CS$<>8__locals1.filterList.IndexOf(num2);
			}
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(9), "PrefabTextItem_1090321532_Text", new <>z__ReadOnlyArray<object>(new object[]
		{
			num,
			CS$<>8__locals1.filterList.Count
		}));
		ModelBase<PhonographModel>.Instance.CurrentSelectMusicId = ((CS$<>8__locals1.selectIndex != -1) ? CS$<>8__locals1.filterList[CS$<>8__locals1.selectIndex] : 0);
		this.RefreshSwitchBtn(ModelBase<PhonographModel>.Instance.CurrentSelectMusicId);
		GenericLayout<PhonographMusicPlayItem, IPhonographMusicItemData> musicGenericLayout = this.MusicGenericLayout;
		if (musicGenericLayout != null)
		{
			UUIInturnAnimController uiAnimController = musicGenericLayout.GetUiAnimController();
			if (uiAnimController != null)
			{
				uiAnimController.Stop();
			}
		}
		UiAsyncTask task = new UiAsyncTask("PhonographView.OnClickAlbumItem", delegate()
		{
			PhonographView.<>c__DisplayClass23_0.<<OnClickAlbumItem>b__1>d <<OnClickAlbumItem>b__1>d;
			<<OnClickAlbumItem>b__1>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<<OnClickAlbumItem>b__1>d.<>4__this = CS$<>8__locals1;
			<<OnClickAlbumItem>b__1>d.<>1__state = -1;
			<<OnClickAlbumItem>b__1>d.<>t__builder.Start<PhonographView.<>c__DisplayClass23_0.<<OnClickAlbumItem>b__1>d>(ref <<OnClickAlbumItem>b__1>d);
			return <<OnClickAlbumItem>b__1>d.<>t__builder.Task;
		}, null);
		base.RunAsyncTask(task);
		LevelSequencePlayer sequencePlayer = this.SequencePlayer;
		if (sequencePlayer != null)
		{
			sequencePlayer.PlaySequencePurely("Album", false, false, null, null, false);
		}
		this.RefreshAlbumInfo(albumId);
	}

	// Token: 0x06012C27 RID: 76839 RVA: 0x0052D104 File Offset: 0x0052B304
	protected void OnClickMusicItem(int musicId, int gridIndex)
	{
		ModelBase<PhonographModel>.Instance.CurrentSelectMusicId = musicId;
		if (!ModelBase<PhonographModel>.Instance.IsUnlockMusic(musicId))
		{
			this.RefreshMusicInfo(musicId);
			this.MusicGenericLayout.SelectGridProxy(gridIndex, false);
			return;
		}
		this.MusicGenericLayout.SelectGridProxy(gridIndex, false);
		this.EventHandleId = ControllerBase<PhonographController>.Instance.PlayMusic(musicId, ModelBase<PhonographModel>.Instance.IsGlobal);
		PhonographModel instance = ModelBase<PhonographModel>.Instance;
		if (instance != null)
		{
			instance.RemoveNewMusic(musicId);
		}
		this.RefreshMusicInfo(musicId);
		LevelSequencePlayer sequencePlayer = this.SequencePlayer;
		if (sequencePlayer != null)
		{
			sequencePlayer.PlaySequencePurely("Single", false, false, null, null, false);
		}
		Singleton<EventSystem>.Instance.Emit(EEventName.OnPhonographRemoveNewTag);
		Singleton<EventSystem>.Instance.Emit(EEventName.OnPhonographSwitchMusic);
		PhonographPlayLogEvent phonographPlayLogEvent = new PhonographPlayLogEvent();
		phonographPlayLogEvent.i_item_id = musicId;
		phonographPlayLogEvent.i_album_id = this.CurrentAlbumId;
		ControllerBase<LogReportController>.Instance.LogReport(phonographPlayLogEvent);
	}

	// Token: 0x06012C28 RID: 76840 RVA: 0x0052D1E8 File Offset: 0x0052B3E8
	protected void OnClickSetBgMusic()
	{
		int currentSelectMusicId = ModelBase<PhonographModel>.Instance.CurrentSelectMusicId;
		int num = (ModelBase<PhonographModel>.Instance.RecordMusicId == currentSelectMusicId) ? 0 : currentSelectMusicId;
		ModelBase<PhonographModel>.Instance.RecordMusicId = num;
		if (ModelBase<PhonographModel>.Instance.IsGlobal)
		{
			ModelBase<PhonographModel>.Instance.GlobalMusicId = num;
			ControllerBase<PhonographController>.Instance.SendMusicSaveRequest(num);
		}
		else
		{
			PhonographModel instance = ModelBase<PhonographModel>.Instance;
			int? num2 = (instance != null) ? instance.EntityId : null;
			if (num2 != null)
			{
				if (num == 0)
				{
					ModelBase<PhonographModel>.Instance.RemovePlayIdRecord(num2.Value);
				}
				else
				{
					ModelBase<PhonographModel>.Instance.SetPlayIdRecord(num2.Value, this.EventHandleId);
				}
			}
		}
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnPhonographSetBgm, num);
		this.RefreshSwitchBtn(currentSelectMusicId);
		if (num != 0)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("PhonographSwitchMusicSuccess", Array.Empty<object>());
			return;
		}
		ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("PhonographSwitchMusicCancel", Array.Empty<object>());
	}

	// Token: 0x06012C29 RID: 76841 RVA: 0x0052D2D8 File Offset: 0x0052B4D8
	protected void OnMusicForceRefresh(int albumId)
	{
		PhonographView.<>c__DisplayClass26_0 CS$<>8__locals1 = new PhonographView.<>c__DisplayClass26_0();
		CS$<>8__locals1.<>4__this = this;
		CS$<>8__locals1.defaultMusicId = ModelBase<MotorcycleMusicPlayerModel>.Instance.GetDefaultMusicId();
		UiAsyncTask task = new UiAsyncTask("PhonographView.OnMusicForceRefresh", delegate()
		{
			PhonographView.<>c__DisplayClass26_0.<<OnMusicForceRefresh>b__0>d <<OnMusicForceRefresh>b__0>d;
			<<OnMusicForceRefresh>b__0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<<OnMusicForceRefresh>b__0>d.<>4__this = CS$<>8__locals1;
			<<OnMusicForceRefresh>b__0>d.<>1__state = -1;
			<<OnMusicForceRefresh>b__0>d.<>t__builder.Start<PhonographView.<>c__DisplayClass26_0.<<OnMusicForceRefresh>b__0>d>(ref <<OnMusicForceRefresh>b__0>d);
			return <<OnMusicForceRefresh>b__0>d.<>t__builder.Task;
		}, null);
		base.RunAsyncTask(task);
	}

	// Token: 0x04009276 RID: 37494
	private const int PHONO_MUSIC_HELP_ID = 653;

	// Token: 0x04009277 RID: 37495
	[Nullable(new byte[]
	{
		2,
		1
	})]
	protected GenericLayout<PhonographAlbumItem, int> AlbumGenericLayout;

	// Token: 0x04009278 RID: 37496
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	protected GenericLayout<PhonographMusicPlayItem, IPhonographMusicItemData> MusicGenericLayout;

	// Token: 0x04009279 RID: 37497
	protected Dictionary<int, List<int>> MusicMap = new Dictionary<int, List<int>>();

	// Token: 0x0400927A RID: 37498
	[Nullable(2)]
	protected PopupCaptionItem CaptionComponent;

	// Token: 0x0400927B RID: 37499
	[Nullable(2)]
	protected LevelSequencePlayer SequencePlayer;

	// Token: 0x0400927C RID: 37500
	private int EventHandleId;

	// Token: 0x0400927D RID: 37501
	private int CurrentAlbumId;

	// Token: 0x020088E7 RID: 35047
	[NullableContext(0)]
	private static class EComponentDefine
	{
		// Token: 0x0402E37A RID: 189306
		public const int CaptionItem = 0;

		// Token: 0x0402E37B RID: 189307
		public const int AlbumVerticalLayout = 1;

		// Token: 0x0402E37C RID: 189308
		public const int AlbumItem = 2;

		// Token: 0x0402E37D RID: 189309
		public const int TxtAlbumName = 3;

		// Token: 0x0402E37E RID: 189310
		public const int MusicVerticalLayout = 4;

		// Token: 0x0402E37F RID: 189311
		public const int MusicItem = 5;

		// Token: 0x0402E380 RID: 189312
		public const int TxtAlbumTitle = 6;

		// Token: 0x0402E381 RID: 189313
		public const int BtnSetBgMusic = 7;

		// Token: 0x0402E382 RID: 189314
		public const int TxtDescription = 8;

		// Token: 0x0402E383 RID: 189315
		public const int TxtMusicNum = 9;

		// Token: 0x0402E384 RID: 189316
		public const int TxtSwitchBtn = 10;

		// Token: 0x0402E385 RID: 189317
		public const int ScrollView = 11;

		// Token: 0x0402E386 RID: 189318
		public const int BtnTimeLimit = 12;
	}
}
