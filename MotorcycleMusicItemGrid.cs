using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002320 RID: 8992
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
public class MotorcycleMusicItemGrid : GridProxyAbstract<IMusicUiData>
{
	// Token: 0x060111B9 RID: 70073 RVA: 0x004B35D0 File Offset: 0x004B17D0
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUISprite)),
			new ValueTuple<int, Type>(8, typeof(UUIItem)),
			new ValueTuple<int, Type>(9, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnExtendToggleTogDiscList)),
			new ValueTuple<int, Delegate>(3, new Action<EToggleState>(this.OnExtendToggleTogLike))
		};
	}

	// Token: 0x060111BA RID: 70074 RVA: 0x004B3700 File Offset: 0x004B1900
	public override void OnSelected(bool fireEvent)
	{
		base.GetExtendToggle(0).SetToggleStateForce(EToggleState.ETT_Checked, false, false, false);
	}

	// Token: 0x060111BB RID: 70075 RVA: 0x004B3712 File Offset: 0x004B1912
	public override void OnDeselected(bool fireEvent)
	{
		base.GetExtendToggle(0).SetToggleStateForce(EToggleState.ETT_UnChecked, false, false, false);
	}

	// Token: 0x060111BC RID: 70076 RVA: 0x004B3724 File Offset: 0x004B1924
	protected override void OnStart()
	{
		base.GetExtendToggle(0).OnUndeterminedClicked.Add(new Action(this.OnTogLockClick));
	}

	// Token: 0x060111BD RID: 70077 RVA: 0x004B3743 File Offset: 0x004B1943
	private void OnTogLockClick()
	{
		if (this.Id == -1)
		{
			return;
		}
		Singleton<UiManager>.Instance.OpenView(EUiViewName.MotorcycleMusicDetailView, this.Id, null);
	}

	// Token: 0x060111BE RID: 70078 RVA: 0x004B376A File Offset: 0x004B196A
	private void OnExtendToggleTogDiscList(EToggleState toggleState)
	{
		if (this.Id == -1)
		{
			return;
		}
		if (ModelBase<MotorcycleMusicPlayerModel>.Instance.IsMusicUnlock(this.Id))
		{
			Action<int> onClickCallback = this.OnClickCallback;
			if (onClickCallback == null)
			{
				return;
			}
			onClickCallback(this.Id);
		}
	}

	// Token: 0x060111BF RID: 70079 RVA: 0x004B37A0 File Offset: 0x004B19A0
	private void OnExtendToggleTogLike(EToggleState toggleState)
	{
		if (this.Id == -1)
		{
			return;
		}
		if (!ModelBase<MotorcycleMusicPlayerModel>.Instance.IsMusicUnlock(this.Id))
		{
			this.RefreshLikeToggle();
			Singleton<UiManager>.Instance.OpenView(EUiViewName.MotorcycleMusicDetailView, this.Id, null);
			return;
		}
		Action<int> onClickLikeCallback = this.OnClickLikeCallback;
		if (onClickLikeCallback == null)
		{
			return;
		}
		onClickLikeCallback(this.Id);
	}

	// Token: 0x060111C0 RID: 70080 RVA: 0x004B3801 File Offset: 0x004B1A01
	private void RefreshLikeToggle()
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(3);
		if (extendToggle == null)
		{
			return;
		}
		extendToggle.SetToggleStateForce(ModelBase<MotorcycleMusicPlayerModel>.Instance.IsMusicFavorite(this.Id) ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, true, false);
	}

	// Token: 0x060111C1 RID: 70081 RVA: 0x004B3830 File Offset: 0x004B1A30
	[NullableContext(1)]
	public override void Refresh(IMusicUiData data, bool isSelected, int gridIndex)
	{
		this.Id = data.Id;
		int id = data.Id;
		PhonographConfig instance = ConfigBase<PhonographConfig>.Instance;
		PhonographMusic? phonographMusic = (instance != null) ? instance.GetMusicById(id) : null;
		if (phonographMusic == null)
		{
			return;
		}
		this.Id = id;
		bool flag = ModelBase<MotorcycleMusicPlayerModel>.Instance.IsMusicUnlock(id);
		bool flag2 = flag && ModelBase<MotorcycleMusicPlayerModel>.Instance.GetCurPlayMusicId() == id;
		bool isPause = ModelBase<MotorcycleMusicPlayerModel>.Instance.GetIsPause();
		this.RefreshLikeToggle();
		UUIItem item = base.GetItem(4);
		if (item != null)
		{
			item.SetUIActive(ModelBase<MotorcycleMusicPlayerModel>.Instance.IsMusicNew(this.Id));
		}
		base.GetExtendToggle(0).SetToggleStateForce((ModelBase<MotorcycleMusicPlayerModel>.Instance.GetCurPlayMusicId() == this.Id) ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, true);
		if (!flag)
		{
			base.GetExtendToggle(0).SetToggleStateForce(EToggleState.ETT_UnDetermined, false, false, false);
		}
		UUISprite sprite = base.GetSprite(7);
		if (sprite != null)
		{
			sprite.SetUIActive(!flag);
		}
		UUIItem item2 = base.GetItem(6);
		if (item2 != null)
		{
			item2.SetUIActive(flag2 && !isPause);
		}
		UUIItem item3 = base.GetItem(5);
		if (item3 != null)
		{
			item3.SetUIActive(flag && !flag2);
		}
		UUIItem item4 = base.GetItem(8);
		if (item4 != null)
		{
			item4.SetUIActive(flag2 && isPause);
		}
		UUIText text = base.GetText(1);
		if (text != null)
		{
			text.ShowTextNew(phonographMusic.Value.Title);
		}
		bool uiactive = ModelBase<MotorcycleMusicPlayerModel>.Instance.IsTimeLimitMusic(this.Id);
		UUIItem item5 = base.GetItem(9);
		if (item5 != null)
		{
			item5.SetUIActive(uiactive);
		}
		UUIItem uuiitem = base.GetExtendToggle(3).RootUIComp.Get();
		if (uuiitem != null)
		{
			uuiitem.SetUIActive(flag);
		}
		this.RefreshMusicDurationAsync(this.Id);
	}

	// Token: 0x060111C2 RID: 70082 RVA: 0x004B39E8 File Offset: 0x004B1BE8
	private UniTask RefreshMusicDurationAsync(int musicId)
	{
		MotorcycleMusicItemGrid.<RefreshMusicDurationAsync>d__13 <RefreshMusicDurationAsync>d__;
		<RefreshMusicDurationAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshMusicDurationAsync>d__.<>4__this = this;
		<RefreshMusicDurationAsync>d__.musicId = musicId;
		<RefreshMusicDurationAsync>d__.<>1__state = -1;
		<RefreshMusicDurationAsync>d__.<>t__builder.Start<MotorcycleMusicItemGrid.<RefreshMusicDurationAsync>d__13>(ref <RefreshMusicDurationAsync>d__);
		return <RefreshMusicDurationAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0400868B RID: 34443
	public Action<int> OnClickCallback;

	// Token: 0x0400868C RID: 34444
	public Action<int> OnClickLikeCallback;

	// Token: 0x0400868D RID: 34445
	private int Id = -1;

	// Token: 0x02008631 RID: 34353
	[NullableContext(0)]
	private class EMusicComponents
	{
		// Token: 0x0402D625 RID: 185893
		public const int Tog = 0;

		// Token: 0x0402D626 RID: 185894
		public const int TxtListName = 1;

		// Token: 0x0402D627 RID: 185895
		public const int TxtListName1 = 2;

		// Token: 0x0402D628 RID: 185896
		public const int TogLike = 3;

		// Token: 0x0402D629 RID: 185897
		public const int UiItemTagNew = 4;

		// Token: 0x0402D62A RID: 185898
		public const int SpriteStatePlay = 5;

		// Token: 0x0402D62B RID: 185899
		public const int SpriteStatePlaying = 6;

		// Token: 0x0402D62C RID: 185900
		public const int SpriteLock = 7;

		// Token: 0x0402D62D RID: 185901
		public const int PanelPause = 8;

		// Token: 0x0402D62E RID: 185902
		public const int SprTimeLimit = 9;
	}
}
