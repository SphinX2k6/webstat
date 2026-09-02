using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02002591 RID: 9617
public class PhonographAlbumItem : GridProxyAbstract<int>
{
	// Token: 0x06012BC2 RID: 76738 RVA: 0x0052B010 File Offset: 0x00529210
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(1, typeof(UUISprite)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIText))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClick))
		};
	}

	// Token: 0x06012BC3 RID: 76739 RVA: 0x0052B0B9 File Offset: 0x005292B9
	protected override void OnStart()
	{
		this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
	}

	// Token: 0x06012BC4 RID: 76740 RVA: 0x0052B0CC File Offset: 0x005292CC
	private void OnClick(EToggleState state)
	{
		if (state == EToggleState.ETT_Checked)
		{
			Action<int, int> onClickAlbumItem = this.OnClickAlbumItem;
			if (onClickAlbumItem == null)
			{
				return;
			}
			onClickAlbumItem(this.AlbumId, base.GridIndex);
		}
	}

	// Token: 0x06012BC5 RID: 76741 RVA: 0x0052B0EE File Offset: 0x005292EE
	protected override void OnBeforeShow()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnPhonographRemoveNewTag, new Action(this.OnRemoveNewTag));
		Singleton<EventSystem>.Instance.Add(EEventName.OnPhonographSwitchMusic, new Action(this.OnSwitchMusic));
	}

	// Token: 0x06012BC6 RID: 76742 RVA: 0x0052B128 File Offset: 0x00529328
	protected override void OnBeforeHide()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnPhonographRemoveNewTag, new Action(this.OnRemoveNewTag));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnPhonographSwitchMusic, new Action(this.OnSwitchMusic));
	}

	// Token: 0x06012BC7 RID: 76743 RVA: 0x0052B164 File Offset: 0x00529364
	private void OnSwitchMusic()
	{
		PhonographModel instance = ModelBase<PhonographModel>.Instance;
		if (instance != null && instance.CurrentPlayMusicId == 0 && this.IsPlayMusic)
		{
			this.IsPlayMusic = false;
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer == null)
			{
				return;
			}
			levelSequencePlayer.PlaySequencePurely("Stop", false, false, null, null, false);
			return;
		}
		else
		{
			PhonographModel instance2 = ModelBase<PhonographModel>.Instance;
			int? num = (instance2 != null) ? new int?(instance2.CurrentPlayMusicId) : null;
			int? num2 = num;
			int num3 = 0;
			if (num2.GetValueOrDefault() == num3 & num2 != null)
			{
				return;
			}
			PhonographConfig instance3 = ConfigBase<PhonographConfig>.Instance;
			PhonographMusic? phonographMusic = (instance3 != null) ? instance3.GetMusicById(num.Value) : null;
			if (phonographMusic == null)
			{
				return;
			}
			bool flag = false;
			PhonographMusic value = phonographMusic.Value;
			for (int i = 0; i < value.AlbumLength; i++)
			{
				if (value.Album(i) == this.AlbumId)
				{
					flag = true;
					break;
				}
			}
			if (!flag || this.IsPlayMusic)
			{
				if (!flag && this.IsPlayMusic)
				{
					this.IsPlayMusic = false;
					LevelSequencePlayer levelSequencePlayer2 = this.LevelSequencePlayer;
					if (levelSequencePlayer2 == null)
					{
						return;
					}
					levelSequencePlayer2.PlaySequencePurely("Stop", false, false, null, null, false);
				}
				return;
			}
			this.IsPlayMusic = true;
			LevelSequencePlayer levelSequencePlayer3 = this.LevelSequencePlayer;
			if (levelSequencePlayer3 == null)
			{
				return;
			}
			levelSequencePlayer3.PlaySequencePurely("Play", false, false, null, null, false);
			return;
		}
	}

	// Token: 0x06012BC8 RID: 76744 RVA: 0x0052B2C4 File Offset: 0x005294C4
	private void OnRemoveNewTag()
	{
		bool uiactive = ModelBase<PhonographModel>.Instance.CheckAlbumHasNewMusic(this.AlbumId);
		base.GetItem(2).SetUIActive(uiactive);
	}

	// Token: 0x06012BC9 RID: 76745 RVA: 0x0052B2F0 File Offset: 0x005294F0
	public override void Refresh(int albumId, bool isSelected, int gridIndex)
	{
		this.AlbumId = albumId;
		PhonographConfig instance = ConfigBase<PhonographConfig>.Instance;
		PhonographAlbum? phonographAlbum = (instance != null) ? instance.GetMusicAlbumById(albumId) : null;
		if (phonographAlbum == null)
		{
			return;
		}
		base.GetExtendToggle(0).SetToggleStateForce(isSelected ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
		bool uiactive = ModelBase<PhonographModel>.Instance.CheckAlbumHasNewMusic(albumId);
		base.GetItem(2).SetUIActive(uiactive);
		this.SetSpriteByPath(phonographAlbum.Value.Icon, base.GetSprite(1), false, null, null);
		MotorcycleMusicPlayerModel instance2 = ModelBase<MotorcycleMusicPlayerModel>.Instance;
		bool flag = instance2 != null && instance2.IsTimeLimitAlbum(albumId);
		base.GetItem(3).SetUIActive(flag);
		if (flag)
		{
			MotorcycleMusicPlayerModel instance3 = ModelBase<MotorcycleMusicPlayerModel>.Instance;
			string newText = ((instance3 != null) ? instance3.GetAlbumTimeLimitRemainText(albumId) : null) ?? "";
			base.GetText(4).SetText(newText, true);
		}
	}

	// Token: 0x06012BCA RID: 76746 RVA: 0x0052B3D0 File Offset: 0x005295D0
	public override void OnSelected(bool fireEvent)
	{
		base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_Checked, false, false, false);
		if (fireEvent)
		{
			Action<int, int> onClickAlbumItem = this.OnClickAlbumItem;
			if (onClickAlbumItem != null)
			{
				onClickAlbumItem(this.AlbumId, base.GridIndex);
			}
		}
		if (this.IsPlayMusic)
		{
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer == null)
			{
				return;
			}
			levelSequencePlayer.PlaySequencePurely("Play", false, false, null, null, false);
		}
	}

	// Token: 0x06012BCB RID: 76747 RVA: 0x0052B438 File Offset: 0x00529638
	public override void OnDeselected(bool fireEvent)
	{
		base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
	}

	// Token: 0x04009259 RID: 37465
	[Nullable(2)]
	public Action<int, int> OnClickAlbumItem;

	// Token: 0x0400925A RID: 37466
	protected int AlbumId;

	// Token: 0x0400925B RID: 37467
	protected bool IsPlayMusic;

	// Token: 0x0400925C RID: 37468
	[Nullable(2)]
	protected LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x020088DC RID: 35036
	private static class EPhonographAlbumItemDefine
	{
		// Token: 0x0402E351 RID: 189265
		public const int ExtendToggle = 0;

		// Token: 0x0402E352 RID: 189266
		public const int SpriteIcon = 1;

		// Token: 0x0402E353 RID: 189267
		public const int NewItem = 2;

		// Token: 0x0402E354 RID: 189268
		public const int PnlTimeLimit = 3;

		// Token: 0x0402E355 RID: 189269
		public const int TxtTimeLimit = 4;
	}
}
