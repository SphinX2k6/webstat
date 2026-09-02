using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Effect;
using CSharpScript.Game.Module.BattleUi.Views;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x0200232F RID: 9007
[NullableContext(2)]
[Nullable(0)]
public class NpcIconComponentView : UiPanelBase
{
	// Token: 0x17001538 RID: 5432
	// (get) Token: 0x0601124C RID: 70220 RVA: 0x004B50CA File Offset: 0x004B32CA
	// (set) Token: 0x0601124D RID: 70221 RVA: 0x004B50D2 File Offset: 0x004B32D2
	public bool ForceHideRootItem
	{
		get
		{
			return this.ForceHideRootItemInner;
		}
		set
		{
			bool flag = this.ForceHideRootItemInner != value;
			this.ForceHideRootItemInner = value;
			if (flag)
			{
				this.SetRootItemState(this.IsRootItemActive, true);
			}
		}
	}

	// Token: 0x17001539 RID: 5433
	// (get) Token: 0x0601124E RID: 70222 RVA: 0x004B50F6 File Offset: 0x004B32F6
	// (set) Token: 0x0601124F RID: 70223 RVA: 0x004B50FE File Offset: 0x004B32FE
	public bool ForceHideDialog
	{
		get
		{
			return this.ForceHideDialogInner;
		}
		set
		{
			bool flag = this.ForceHideDialogInner != value;
			this.ForceHideDialogInner = value;
			if (flag)
			{
				this.SetDialogueActive(this.IsDialogActive, this.IsDialogRedDotActive, true);
			}
		}
	}

	// Token: 0x06011250 RID: 70224 RVA: 0x004B5128 File Offset: 0x004B3328
	protected unsafe override void OnRegisterComponent()
	{
		int num = 17;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(17, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(18, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06011251 RID: 70225 RVA: 0x004B538C File Offset: 0x004B358C
	protected override void OnStart()
	{
		this.InitTweenAnim();
		this.RootActorRotation = this.RootActor.K2_GetActorRotation();
		this.RootActorLocationOffset = new FVectorDouble(0.0, 0.0, 0.0);
		this.HeadItem = base.GetItem(6);
		this.CacheHeadScale = this.HeadItem.D_K2_GetComponentScale().X;
		this.DialogItem = base.GetItem(2);
		this.CacheDialogScale = this.DialogItem.D_K2_GetComponentScale().X;
		this.NameText = base.GetText(0);
		this.NameMessageItem = base.GetItem(5);
		this.HeadIcon = base.GetTexture(4);
		this.RedDotItem = base.GetItem(8);
		this.QuestTrackCellItem = base.GetItem(10);
		this.PlayerInfoItem = base.GetSprite(11);
		this.IsHeadIconActive = this.HeadIcon.bIsUIActive;
		this.IsHeadItemActive = this.HeadItem.bIsUIActive;
		this.IsRootItemActive = this.RootItem.bIsUIActive;
		this.IsHeadInfoNameActive = this.NameMessageItem.bIsUIActive;
		this.IsQuestTrackCellActive = this.QuestTrackCellItem.bIsUIActive;
		this.ForceHideDialogInner = false;
		this.IsDialogRedDotActive = false;
		this.SetDialogueActive(false, false, false);
		this.SetPlayerInfoItemState(false);
	}

	// Token: 0x06011252 RID: 70226 RVA: 0x004B54E0 File Offset: 0x004B36E0
	private void InitTweenAnim()
	{
		this.TweenAnimPlayer = new BattleUiTweenAnimPlayer();
		this.TweenAnimPlayer.InitTweenAnim(12, base.GetItem(12), false);
		this.TweenAnimPlayer.InitTweenAnim(13, base.GetItem(13), false);
		this.TweenAnimPlayer.InitTweenAnim(14, base.GetItem(14), false);
		this.TweenAnimPlayer.InitTweenAnim(17, base.GetItem(17), false);
		this.TweenAnimPlayer.InitTweenAnim(18, base.GetItem(18), false);
		this.TweenAnimPlayer.InitTweenAnim(15, base.GetItem(15), false);
		this.TweenAnimPlayer.InitTweenAnim(16, base.GetItem(16), false);
		this.TweenAnimPlayer.RegisterOnComplete(14, delegate
		{
			this.DialogItem.SetUIActive(false);
		});
		this.TweenAnimPlayer.RegisterOnComplete(18, delegate
		{
			if (!this.IsPlayingHiddenSequence)
			{
				return;
			}
			this.IsPlayingHiddenSequence = false;
			this.HeadItem.SetUIActive(false);
			if (this.PendingQuestTrackCellActive != null)
			{
				this.SetQuestTrackCellState(this.PendingQuestTrackCellActive.Value);
				this.PendingQuestTrackCellActive = null;
			}
		});
	}

	// Token: 0x06011253 RID: 70227 RVA: 0x004B55C4 File Offset: 0x004B37C4
	public void SetNpcName(string name)
	{
		UUIText text = base.GetText(0);
		if (StringUtils.IsEmpty(name))
		{
			text.SetUIActive(false);
			return;
		}
		text.SetUIActive(true);
		text.SetText(name, true);
	}

	// Token: 0x06011254 RID: 70228 RVA: 0x004B55F8 File Offset: 0x004B37F8
	public void InitItemLocation(FVectorDouble location, double offsetZ)
	{
		this.RootActorLocationOffset = location;
		FVectorDouble rootActorLocationOffset = this.RootActorLocationOffset;
		rootActorLocationOffset.Z = location.Z + offsetZ;
		this.RootActor.D_K2_SetActorLocation(rootActorLocationOffset, false, ref WorldGlobal.SweepHitResult, false);
	}

	// Token: 0x06011255 RID: 70229 RVA: 0x004B5638 File Offset: 0x004B3838
	public void UpdateRotation(float yaw, float pitch)
	{
		float roll = pitch - 90f;
		float yaw2 = yaw + 90f;
		this.RootActorRotation.Roll = roll;
		this.RootActorRotation.Pitch = 0f;
		this.RootActorRotation.Yaw = yaw2;
		this.RootItem.SetUIWorldRotation(this.RootActorRotation);
	}

	// Token: 0x06011256 RID: 70230 RVA: 0x004B5690 File Offset: 0x004B3890
	public void SetDialogueActive(bool bActive, bool redDot = false, bool force = false)
	{
		if (this.ForceHideDialog)
		{
			if (this.DialogItem.bIsUIActive)
			{
				this.DialogItem.SetUIActive(false);
			}
			this.IsDialogActive = bActive;
			return;
		}
		if (bActive == this.IsDialogActive && !force)
		{
			return;
		}
		this.IsDialogActive = bActive;
		if (bActive)
		{
			this.DialogItem.SetUIActive(true);
			this.TweenAnimPlayer.PlayTweenAnim(13);
			this.RedDotItem.SetUIActive(redDot);
			this.IsDialogRedDotActive = redDot;
			return;
		}
		this.TweenAnimPlayer.PlayTweenAnim(14);
	}

	// Token: 0x06011257 RID: 70231 RVA: 0x004B5717 File Offset: 0x004B3917
	public bool GetDialogueActive()
	{
		return this.IsDialogActive;
	}

	// Token: 0x06011258 RID: 70232 RVA: 0x004B571F File Offset: 0x004B391F
	[NullableContext(1)]
	public void SetDialogueText(string text)
	{
		base.GetText(3).SetText(text, true);
	}

	// Token: 0x06011259 RID: 70233 RVA: 0x004B5730 File Offset: 0x004B3930
	public void SetHeadItemState(bool bState)
	{
		if (this.IsHeadItemActive == bState)
		{
			return;
		}
		this.IsHeadItemActive = bState;
		if (bState)
		{
			this.HeadItem.SetUIActive(true);
			if (this.IsPlayingHiddenSequence)
			{
				this.TweenAnimPlayer.StopAll();
				this.IsPlayingHiddenSequence = false;
			}
			this.TweenAnimPlayer.PlayTweenAnim(17);
			if (this.IsHeadIconActive)
			{
				EHeadIconType? headIconType = this.HeadIconType;
				EHeadIconType eheadIconType = EHeadIconType.Function;
				if (headIconType.GetValueOrDefault() == eheadIconType & headIconType != null)
				{
					this.TweenAnimPlayer.PlayTweenAnim(12);
					return;
				}
				if (this.HeadIconType.GetValueOrDefault() == EHeadIconType.Quest)
				{
					this.TweenAnimPlayer.PlayTweenAnim(15);
					return;
				}
			}
		}
		else
		{
			this.TweenAnimPlayer.PlayTweenAnim(18);
			this.TweenAnimPlayer.PlayTweenAnim(16);
			this.IsPlayingHiddenSequence = true;
		}
	}

	// Token: 0x0601125A RID: 70234 RVA: 0x004B57F7 File Offset: 0x004B39F7
	public bool GetHeadItemState()
	{
		return this.IsHeadItemActive;
	}

	// Token: 0x0601125B RID: 70235 RVA: 0x004B57FF File Offset: 0x004B39FF
	public bool GetHeadIconActive()
	{
		return this.IsHeadIconActive;
	}

	// Token: 0x0601125C RID: 70236 RVA: 0x004B5808 File Offset: 0x004B3A08
	public void SetQuestTrackCellState(bool bState)
	{
		if (this.IsQuestTrackCellActive == bState)
		{
			return;
		}
		if (this.TweenAnimPlayer != null && this.TweenAnimPlayer.CheckIsPlaying(18))
		{
			this.PendingQuestTrackCellActive = new bool?(bState);
			return;
		}
		this.IsQuestTrackCellActive = bState;
		this.QuestTrackCellItem.SetUIActive(bState);
	}

	// Token: 0x0601125D RID: 70237 RVA: 0x004B5856 File Offset: 0x004B3A56
	public void SetPlayerInfoItemState(bool bState)
	{
		this.PlayerInfoItem.SetUIActive(bState);
	}

	// Token: 0x0601125E RID: 70238 RVA: 0x004B5864 File Offset: 0x004B3A64
	public void SetNameTextItemState(bool bState)
	{
		this.NameText.SetUIActive(bState);
	}

	// Token: 0x0601125F RID: 70239 RVA: 0x004B5874 File Offset: 0x004B3A74
	public void SetRootItemState(bool bState, bool force = false)
	{
		if (this.ForceHideRootItem)
		{
			if (this.RootItem.bIsUIActive)
			{
				this.SetActive(false);
			}
			this.IsRootItemActive = bState;
			return;
		}
		if (this.IsRootItemActive == bState && !force)
		{
			return;
		}
		this.IsRootItemActive = bState;
		this.SetActive(bState && !Singleton<UiLayer>.Instance.IsForceHideUi());
	}

	// Token: 0x06011260 RID: 70240 RVA: 0x004B58D2 File Offset: 0x004B3AD2
	public bool GetRootItemState()
	{
		return this.IsRootItemActive;
	}

	// Token: 0x06011261 RID: 70241 RVA: 0x004B58DA File Offset: 0x004B3ADA
	public void SetTrackEffectState(bool bState)
	{
		if (this.IsTrackEffectActive == bState)
		{
			return;
		}
		this.IsTrackEffectActive = bState;
		Singleton<EffectSystem>.Instance.SetEffectHidden(this.TrackedEffect, bState, "NpcIconComponentView", false);
	}

	// Token: 0x06011262 RID: 70242 RVA: 0x004B5904 File Offset: 0x004B3B04
	public void SetHeadInfoNameState(bool bState)
	{
		if (this.IsHeadInfoNameActive == bState)
		{
			return;
		}
		this.IsHeadInfoNameActive = bState;
		this.NameMessageItem.SetUIActive(bState);
		this.DialogItem.SetUIActive(bState && this.IsDialogActive);
	}

	// Token: 0x06011263 RID: 70243 RVA: 0x004B593A File Offset: 0x004B3B3A
	public bool GetHeadInfoNameState()
	{
		return this.IsHeadInfoNameActive;
	}

	// Token: 0x06011264 RID: 70244 RVA: 0x004B5942 File Offset: 0x004B3B42
	public void SetNpcQuestIconState(bool bState)
	{
		this.SetHeadIconState(bState);
	}

	// Token: 0x06011265 RID: 70245 RVA: 0x004B594C File Offset: 0x004B3B4C
	public void SetNpcSecondName(string name)
	{
		UUIText text = base.GetText(1);
		if (!string.IsNullOrEmpty(name))
		{
			text.SetUIActive(true);
			text.ShowTextNew(name);
			return;
		}
		text.SetUIActive(false);
	}

	// Token: 0x06011266 RID: 70246 RVA: 0x004B5980 File Offset: 0x004B3B80
	public void SetFunctionIcon(string path, Action<bool> doneCallback = null)
	{
		if (!string.IsNullOrEmpty(path))
		{
			this.SetHeadIconState(true);
			base.SetTextureByPath(path, this.HeadIcon, null, doneCallback);
			this.HeadIconType = new EHeadIconType?(EHeadIconType.Function);
			return;
		}
		this.SetHeadIconState(false);
	}

	// Token: 0x06011267 RID: 70247 RVA: 0x004B59C8 File Offset: 0x004B3BC8
	public void SetNpcQuestIcon(string path)
	{
		if (!string.IsNullOrEmpty(path))
		{
			base.SetTextureByPath(path, this.HeadIcon, null, null);
			this.SetHeadIconState(true);
			this.HeadIconType = new EHeadIconType?(EHeadIconType.Quest);
			return;
		}
		this.SetHeadIconState(false);
	}

	// Token: 0x06011268 RID: 70248 RVA: 0x004B5A10 File Offset: 0x004B3C10
	public void SetPlayerInfoIcon(string path, Action<bool> callback)
	{
		if (string.IsNullOrEmpty(path) || this.PlayerInfoItem == null)
		{
			return;
		}
		this.SetSpriteByPath(path, this.PlayerInfoItem, true, null, callback);
	}

	// Token: 0x06011269 RID: 70249 RVA: 0x004B5A46 File Offset: 0x004B3C46
	public void SnapSizeFromTexture()
	{
		UUITexture headIcon = this.HeadIcon;
		if (headIcon == null)
		{
			return;
		}
		headIcon.SetSizeFromTexture();
	}

	// Token: 0x0601126A RID: 70250 RVA: 0x004B5A58 File Offset: 0x004B3C58
	public void SetHeadWorldScale3D(float scale)
	{
		if (!this.IsHeadItemActive)
		{
			return;
		}
		if (Singleton<MathUtils>.Instance.IsNearlyEqual(this.CacheHeadScale, (double)scale, new double?(0.01)))
		{
			return;
		}
		this.CacheHeadScale = (double)scale;
		this.CurrentHeadScale.X = (double)scale;
		this.CurrentHeadScale.Y = (double)scale;
		this.CurrentHeadScale.Z = (double)scale;
		this.HeadItem.D_SetWorldScale3D(this.CurrentHeadScale);
	}

	// Token: 0x0601126B RID: 70251 RVA: 0x004B5AD4 File Offset: 0x004B3CD4
	public void SetDialogWorldScale3D(float scale)
	{
		if (this.CacheDialogScale == (double)scale)
		{
			return;
		}
		this.CacheDialogScale = (double)scale;
		this.CurrentDialogScale.X = (double)scale;
		this.CurrentDialogScale.Y = (double)scale;
		this.CurrentDialogScale.Z = (double)scale;
		this.DialogItem.D_SetWorldScale3D(this.CurrentDialogScale);
	}

	// Token: 0x0601126C RID: 70252 RVA: 0x004B5B2C File Offset: 0x004B3D2C
	private void SetHeadIconState(bool state)
	{
		if (state == this.IsHeadIconActive)
		{
			return;
		}
		this.IsHeadIconActive = state;
		this.HeadIcon.SetUIActive(state);
	}

	// Token: 0x0601126D RID: 70253 RVA: 0x004B5B4C File Offset: 0x004B3D4C
	protected override void OnBeforeDestroy()
	{
		if (Singleton<EffectSystem>.Instance.IsValid(this.TrackedEffect))
		{
			Singleton<EffectSystem>.Instance.StopEffectById(this.TrackedEffect, "[NpcIconComponentView.OnBeforeDestroy]", true, null);
			this.TrackedEffect = 0;
		}
		BattleUiTweenAnimPlayer tweenAnimPlayer = this.TweenAnimPlayer;
		if (tweenAnimPlayer == null)
		{
			return;
		}
		tweenAnimPlayer.Clear(false);
	}

	// Token: 0x040086CC RID: 34508
	protected FRotator RootActorRotation;

	// Token: 0x040086CD RID: 34509
	private FVectorDouble RootActorLocationOffset;

	// Token: 0x040086CE RID: 34510
	private bool IsHeadInfoNameActive;

	// Token: 0x040086CF RID: 34511
	private bool IsRootItemActive;

	// Token: 0x040086D0 RID: 34512
	private bool ForceHideRootItemInner;

	// Token: 0x040086D1 RID: 34513
	private bool IsHeadItemActive;

	// Token: 0x040086D2 RID: 34514
	private bool IsTrackEffectActive;

	// Token: 0x040086D3 RID: 34515
	private bool IsHeadIconActive;

	// Token: 0x040086D4 RID: 34516
	private bool IsDialogActive;

	// Token: 0x040086D5 RID: 34517
	private bool IsDialogRedDotActive;

	// Token: 0x040086D6 RID: 34518
	private bool ForceHideDialogInner;

	// Token: 0x040086D7 RID: 34519
	private bool? PendingQuestTrackCellActive;

	// Token: 0x040086D8 RID: 34520
	private UUIText NameText;

	// Token: 0x040086D9 RID: 34521
	private UUIItem NameMessageItem;

	// Token: 0x040086DA RID: 34522
	private UUITexture HeadIcon;

	// Token: 0x040086DB RID: 34523
	private FVectorDouble CurrentHeadScale = new FVectorDouble(1.0, 1.0, 1.0);

	// Token: 0x040086DC RID: 34524
	private double CacheHeadScale;

	// Token: 0x040086DD RID: 34525
	private UUIItem HeadItem;

	// Token: 0x040086DE RID: 34526
	private UUIItem QuestTrackCellItem;

	// Token: 0x040086DF RID: 34527
	private UUISprite PlayerInfoItem;

	// Token: 0x040086E0 RID: 34528
	private UUIItem RedDotItem;

	// Token: 0x040086E1 RID: 34529
	private FVectorDouble CurrentDialogScale = new FVectorDouble(1.0, 1.0, 1.0);

	// Token: 0x040086E2 RID: 34530
	private double CacheDialogScale;

	// Token: 0x040086E3 RID: 34531
	private UUIItem DialogItem;

	// Token: 0x040086E4 RID: 34532
	private int TrackedEffect;

	// Token: 0x040086E5 RID: 34533
	private EHeadIconType? HeadIconType;

	// Token: 0x040086E6 RID: 34534
	private bool IsQuestTrackCellActive;

	// Token: 0x040086E7 RID: 34535
	private bool IsPlayingHiddenSequence;

	// Token: 0x040086E8 RID: 34536
	private BattleUiTweenAnimPlayer TweenAnimPlayer;
}
