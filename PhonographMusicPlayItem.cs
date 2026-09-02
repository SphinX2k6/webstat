using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02002594 RID: 9620
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
public class PhonographMusicPlayItem : GridProxyAbstract<IPhonographMusicItemData>
{
	// Token: 0x06012BD4 RID: 76756 RVA: 0x0052B480 File Offset: 0x00529680
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUISprite)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUISprite)),
			new ValueTuple<int, Type>(7, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClick))
		};
	}

	// Token: 0x06012BD5 RID: 76757 RVA: 0x0052B56B File Offset: 0x0052976B
	protected override void OnStart()
	{
		this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
	}

	// Token: 0x06012BD6 RID: 76758 RVA: 0x0052B580 File Offset: 0x00529780
	protected override void OnBeforeShow()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnPhonographPlayStop, new Action(this.OnPlayStop));
		Singleton<EventSystem>.Instance.Add(EEventName.OnPhonographSelectDisable, new Action<int>(this.OnSelectDisable));
		base.GetExtendToggle(0).bCanClickWhenDisable = true;
		base.GetExtendToggle(0).OnUndeterminedClicked.Add(new Action(this.OnClickUndetermined));
		Singleton<EventSystem>.Instance.Add(EEventName.OnPhonographSetBgm, new Action<int>(this.OnSetBgm));
	}

	// Token: 0x06012BD7 RID: 76759 RVA: 0x0052B60B File Offset: 0x0052980B
	public void OnTick()
	{
		if (this.MusicId != ModelBase<PhonographModel>.Instance.CurrentPlayMusicId)
		{
			return;
		}
		this.RefreshTime();
	}

	// Token: 0x06012BD8 RID: 76760 RVA: 0x0052B628 File Offset: 0x00529828
	protected override void OnBeforeHide()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnPhonographPlayStop, new Action(this.OnPlayStop));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnPhonographSelectDisable, new Action<int>(this.OnSelectDisable));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnPhonographSetBgm, new Action<int>(this.OnSetBgm));
	}

	// Token: 0x06012BD9 RID: 76761 RVA: 0x0052B689 File Offset: 0x00529889
	private void OnSetBgm(int musicId)
	{
		base.GetItem(7).SetUIActive(musicId == this.MusicId);
	}

	// Token: 0x06012BDA RID: 76762 RVA: 0x0052B6A0 File Offset: 0x005298A0
	private void OnSelectDisable(int musicId)
	{
		if (this.MusicId == musicId)
		{
			return;
		}
		base.GetSprite(6).SetAlpha(0f);
	}

	// Token: 0x06012BDB RID: 76763 RVA: 0x0052B6C0 File Offset: 0x005298C0
	private void OnClickUndetermined()
	{
		Action<int, int> onClickMusicItem = this.OnClickMusicItem;
		if (onClickMusicItem != null)
		{
			onClickMusicItem(this.MusicId, base.GridIndex);
		}
		base.GetSprite(6).SetAlpha(1f);
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnPhonographSelectDisable, this.MusicId);
	}

	// Token: 0x06012BDC RID: 76764 RVA: 0x0052B714 File Offset: 0x00529914
	private void OnClick(EToggleState state)
	{
		PhonographModel instance = ModelBase<PhonographModel>.Instance;
		int? num = (instance != null) ? new int?(instance.CurrentPlayMusicId) : null;
		int musicId = this.MusicId;
		if (num.GetValueOrDefault() == musicId & num != null)
		{
			base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_Checked, false, false, false);
		}
		Action<int, int> onClickMusicItem = this.OnClickMusicItem;
		if (onClickMusicItem != null)
		{
			onClickMusicItem(this.MusicId, base.GridIndex);
		}
		if (!ModelBase<PhonographModel>.Instance.IsUnlockMusic(this.MusicId))
		{
			return;
		}
		this.RefreshTime();
		base.GetItem(4).SetUIActive(false);
		this.LevelSequencePlayer.PlaySequencePurely("Play", false, false, null, null, false);
	}

	// Token: 0x06012BDD RID: 76765 RVA: 0x0052B7CC File Offset: 0x005299CC
	public void OnPlayStop()
	{
		if (this.MusicId != ModelBase<PhonographModel>.Instance.CurrentPlayMusicId)
		{
			return;
		}
		base.GetText(3).SetText(Singleton<TimeUtil>.Instance.GetTimeString((double)this.TotalTime), true);
		base.GetSprite(2).SetFillAmount(0f);
		base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
		LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		if (levelSequencePlayer == null)
		{
			return;
		}
		levelSequencePlayer.PlaySequencePurely("Stop", false, false, null, null, false);
	}

	// Token: 0x06012BDE RID: 76766 RVA: 0x0052B850 File Offset: 0x00529A50
	public void RefreshTime()
	{
		int currentPlayTimeFromAudio = ModelBase<PhonographModel>.Instance.GetCurrentPlayTimeFromAudio();
		base.GetText(3).SetText(Singleton<TimeUtil>.Instance.GetTimeString((double)currentPlayTimeFromAudio) + "/" + Singleton<TimeUtil>.Instance.GetTimeString((double)this.TotalTime), true);
		base.GetSprite(2).SetFillAmount((float)currentPlayTimeFromAudio / (float)this.TotalTime);
	}

	// Token: 0x06012BDF RID: 76767 RVA: 0x0052B8B4 File Offset: 0x00529AB4
	[NullableContext(1)]
	public override void Refresh(IPhonographMusicItemData data, bool isSelected, int gridIndex)
	{
		this.MusicId = data.Id;
		PhonographConfig instance = ConfigBase<PhonographConfig>.Instance;
		PhonographMusic? phonographMusic = (instance != null) ? instance.GetMusicById(data.Id) : null;
		if (phonographMusic == null)
		{
			return;
		}
		base.GetItem(7).SetUIActive(ModelBase<PhonographModel>.Instance.RecordMusicId == data.Id);
		this.TotalTime = (int)Math.Floor((double)data.Duration);
		bool flag = ModelBase<PhonographModel>.Instance.CurrentPlayMusicId == data.Id;
		if (flag)
		{
			this.RefreshTime();
		}
		else
		{
			base.GetSprite(2).SetFillAmount(0f);
			base.GetText(3).SetText(Singleton<TimeUtil>.Instance.GetTimeString((double)this.TotalTime), true);
		}
		if (ModelBase<PhonographModel>.Instance.IsUnlockMusic(data.Id))
		{
			this.LevelSequencePlayer.PlaySequencePurely("Unlock", false, false, null, null, false);
		}
		else
		{
			this.LevelSequencePlayer.PlaySequencePurely("Lock", false, false, null, null, false);
		}
		if (flag)
		{
			this.LevelSequencePlayer.PlaySequencePurely("Play", false, false, null, null, false);
		}
		else
		{
			this.LevelSequencePlayer.PlaySequencePurely("Stop", false, false, null, null, false);
		}
		EToggleState state = flag ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
		base.GetSprite(6).SetAlpha(isSelected > false);
		base.GetExtendToggle(0).CanExecuteChange.Unbind();
		base.GetExtendToggle(0).SetToggleState(state, false, false, false);
		base.GetExtendToggle(0).CanExecuteChange.Bind(delegate()
		{
			PhonographModel instance2 = ModelBase<PhonographModel>.Instance;
			int? num = (instance2 != null) ? new int?(instance2.CurrentPlayMusicId) : null;
			int musicId = this.MusicId;
			if (num.GetValueOrDefault() == musicId & num != null)
			{
				PhonographModel instance3 = ModelBase<PhonographModel>.Instance;
				num = ((instance3 != null) ? new int?(instance3.CurrentSelectMusicId) : null);
				musicId = this.MusicId;
				if (!(num.GetValueOrDefault() == musicId & num != null))
				{
					return true;
				}
			}
			PhonographModel instance4 = ModelBase<PhonographModel>.Instance;
			num = ((instance4 != null) ? new int?(instance4.CurrentPlayMusicId) : null);
			musicId = this.MusicId;
			if (!(num.GetValueOrDefault() == musicId & num != null))
			{
				PhonographModel instance5 = ModelBase<PhonographModel>.Instance;
				num = ((instance5 != null) ? new int?(instance5.CurrentSelectMusicId) : null);
				musicId = this.MusicId;
				if (num.GetValueOrDefault() == musicId & num != null)
				{
					this.OnClick(EToggleState.ETT_UnChecked);
					return false;
				}
			}
			return ModelBase<PhonographModel>.Instance.CurrentSelectMusicId != this.MusicId;
		});
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), phonographMusic.Value.Title, Array.Empty<object>());
		base.GetItem(4).SetUIActive(ModelBase<PhonographModel>.Instance.IsNewMusic(data.Id));
	}

	// Token: 0x06012BE0 RID: 76768 RVA: 0x0052BA9A File Offset: 0x00529C9A
	public override void OnSelected(bool fireEvent)
	{
		base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_Checked, false, false, false);
	}

	// Token: 0x06012BE1 RID: 76769 RVA: 0x0052BAAD File Offset: 0x00529CAD
	public override void OnDeselected(bool fireEvent)
	{
		base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
	}

	// Token: 0x06012BE2 RID: 76770 RVA: 0x0052BAC0 File Offset: 0x00529CC0
	protected override void OnBeforeDestroy()
	{
		if (this.UpdateTimeHandle != null)
		{
			TimerSystem.Instance.Remove(this.UpdateTimeHandle);
			this.UpdateTimeHandle = null;
		}
	}

	// Token: 0x0400925F RID: 37471
	public Action<int, int> OnClickMusicItem;

	// Token: 0x04009260 RID: 37472
	protected int MusicId;

	// Token: 0x04009261 RID: 37473
	protected int TotalTime;

	// Token: 0x04009262 RID: 37474
	protected int CurrentTime;

	// Token: 0x04009263 RID: 37475
	protected TimerHandle UpdateTimeHandle;

	// Token: 0x04009264 RID: 37476
	protected LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x020088DD RID: 35037
	[NullableContext(0)]
	private static class EPhonographMusicPlayItemDefine
	{
		// Token: 0x0402E356 RID: 189270
		public const int ExtendToggle = 0;

		// Token: 0x0402E357 RID: 189271
		public const int TxtName = 1;

		// Token: 0x0402E358 RID: 189272
		public const int SpriteProgress = 2;

		// Token: 0x0402E359 RID: 189273
		public const int TxtTime = 3;

		// Token: 0x0402E35A RID: 189274
		public const int NewItem = 4;

		// Token: 0x0402E35B RID: 189275
		public const int LockItem = 5;

		// Token: 0x0402E35C RID: 189276
		public const int SelectItem = 6;

		// Token: 0x0402E35D RID: 189277
		public const int BgmTagItem = 7;
	}
}
