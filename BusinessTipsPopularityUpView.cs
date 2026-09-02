using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020013E0 RID: 5088
[NullableContext(1)]
[Nullable(0)]
public class BusinessTipsPopularityUpView : UiViewBase
{
	// Token: 0x06008CB4 RID: 36020 RVA: 0x0024FD01 File Offset: 0x0024DF01
	public BusinessTipsPopularityUpView(UiViewInfo info) : base(info)
	{
	}

	// Token: 0x06008CB5 RID: 36021 RVA: 0x0024FD0C File Offset: 0x0024DF0C
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(5, typeof(UUIText)),
			new ValueTuple<int, Type>(6, typeof(UUIText)),
			new ValueTuple<int, Type>(7, typeof(UUISprite)),
			new ValueTuple<int, Type>(8, typeof(UUISprite)),
			new ValueTuple<int, Type>(9, typeof(UUIItem)),
			new ValueTuple<int, Type>(10, typeof(UUIItem)),
			new ValueTuple<int, Type>(11, typeof(USpineSkeletonAnimationComponent)),
			new ValueTuple<int, Type>(12, typeof(UUIItem)),
			new ValueTuple<int, Type>(13, typeof(UUITexture))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(4, new Action(this.OnConfirm))
		};
	}

	// Token: 0x06008CB6 RID: 36022 RVA: 0x0024FE80 File Offset: 0x0024E080
	private void OnConfirm()
	{
		base.CloseMe(null);
	}

	// Token: 0x06008CB7 RID: 36023 RVA: 0x0024FE8C File Offset: 0x0024E08C
	private void InitSequenceData()
	{
		if (this.PopularityUpData.LastPopularity >= this.PopularityUpData.CurrentPopularity)
		{
			UiViewData uiViewData = new UiViewData();
			uiViewData.StartSequenceName = "Start01";
			UiBehaviorLevelSequence uiViewSequence = this.UiViewSequence;
			if (uiViewSequence == null)
			{
				return;
			}
			uiViewSequence.SetSequenceName(uiViewData);
		}
	}

	// Token: 0x06008CB8 RID: 36024 RVA: 0x0024FED4 File Offset: 0x0024E0D4
	protected override UniTask OnBeforeStartAsync()
	{
		BusinessTipsPopularityUpView.<OnBeforeStartAsync>d__15 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<BusinessTipsPopularityUpView.<OnBeforeStartAsync>d__15>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06008CB9 RID: 36025 RVA: 0x0024FF18 File Offset: 0x0024E118
	protected override void OnAfterPlayStartSequence()
	{
		UiBehaviorLevelSequence uiViewSequence = this.UiViewSequence;
		if (uiViewSequence != null)
		{
			uiViewSequence.PlaySequencePurely("PopStart", false, false);
		}
		int currentPopularity = this.PopularityUpData.CurrentPopularity;
		int lastPopularity = this.PopularityUpData.LastPopularity;
		int num = currentPopularity - lastPopularity;
		this.PlayBtnShow();
		if (num > 0)
		{
			this.StartTween(lastPopularity);
		}
	}

	// Token: 0x06008CBA RID: 36026 RVA: 0x0024FF68 File Offset: 0x0024E168
	protected override void OnBeforeDestroy()
	{
		if (this.Delegate != null)
		{
			global::DelegateUtils.ReleaseManualReleaseDelegate(new Action<int>(this.PlayFillAmount));
			this.Delegate = null;
		}
		this.StopTween();
		Singleton<AudioSystem>.Instance.ExecuteAction("play_ui_figure_up_2s", EAudioActionType.Stop, null);
	}

	// Token: 0x06008CBB RID: 36027 RVA: 0x0024FFB4 File Offset: 0x0024E1B4
	protected override void OnAfterDestroy()
	{
		ModelBase<MoonChasingBusinessModel>.Instance.SetIsInDelegate(false);
	}

	// Token: 0x06008CBC RID: 36028 RVA: 0x0024FFC4 File Offset: 0x0024E1C4
	private UniTask InitRoleSpine(bool isLevelUp)
	{
		BusinessTipsPopularityUpView.<InitRoleSpine>d__19 <InitRoleSpine>d__;
		<InitRoleSpine>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitRoleSpine>d__.<>4__this = this;
		<InitRoleSpine>d__.isLevelUp = isLevelUp;
		<InitRoleSpine>d__.<>1__state = -1;
		<InitRoleSpine>d__.<>t__builder.Start<BusinessTipsPopularityUpView.<InitRoleSpine>d__19>(ref <InitRoleSpine>d__);
		return <InitRoleSpine>d__.<>t__builder.Task;
	}

	// Token: 0x06008CBD RID: 36029 RVA: 0x00250010 File Offset: 0x0024E210
	private UniTask InitBgTexture(bool isLevelUp)
	{
		BusinessTipsPopularityUpView.<InitBgTexture>d__20 <InitBgTexture>d__;
		<InitBgTexture>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitBgTexture>d__.<>4__this = this;
		<InitBgTexture>d__.isLevelUp = isLevelUp;
		<InitBgTexture>d__.<>1__state = -1;
		<InitBgTexture>d__.<>t__builder.Start<BusinessTipsPopularityUpView.<InitBgTexture>d__20>(ref <InitBgTexture>d__);
		return <InitBgTexture>d__.<>t__builder.Task;
	}

	// Token: 0x06008CBE RID: 36030 RVA: 0x0025005B File Offset: 0x0024E25B
	private void InitDialog()
	{
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), this.PopularityUpData.DialogName, Array.Empty<object>());
	}

	// Token: 0x06008CBF RID: 36031 RVA: 0x0025007E File Offset: 0x0024E27E
	private void InitLantern(bool isLevelUp)
	{
		UUIItem item = base.GetItem(9);
		if (item != null)
		{
			item.SetUIActive(isLevelUp);
		}
		UUIItem item2 = base.GetItem(10);
		if (item2 != null)
		{
			item2.SetUIActive(!isLevelUp);
		}
		UUIItem item3 = base.GetItem(12);
		if (item3 == null)
		{
			return;
		}
		item3.SetUIActive(isLevelUp);
	}

	// Token: 0x06008CC0 RID: 36032 RVA: 0x002500BE File Offset: 0x0024E2BE
	private void InitTitle()
	{
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), this.PopularityUpData.Title, Array.Empty<object>());
	}

	// Token: 0x06008CC1 RID: 36033 RVA: 0x002500E4 File Offset: 0x0024E2E4
	private void InitBar()
	{
		Popularity currentPopularityConfig = ModelBase<MoonChasingBusinessModel>.Instance.GetCurrentPopularityConfig();
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), currentPopularityConfig.PopularityRating, Array.Empty<object>());
		int currentPopularity = this.PopularityUpData.CurrentPopularity;
		int lastPopularity = this.PopularityUpData.LastPopularity;
		int num = currentPopularity - lastPopularity;
		UUIText text = base.GetText(5);
		if (text != null)
		{
			text.SetUIActive(num > 0);
		}
		if (num > 0)
		{
			UUIText text2 = base.GetText(5);
			if (text2 != null)
			{
				text2.SetText("+" + num.ToString(), true);
			}
		}
		UUISprite sprite = base.GetSprite(8);
		if (sprite != null)
		{
			sprite.SetFillAmount((float)lastPopularity / (float)this.PopularityValue);
		}
		this.CurrentBar.SetFillAmount((float)lastPopularity / (float)this.PopularityValue);
		this.CurrentText.SetText("<color=#ffd52b>" + lastPopularity.ToString() + "</color>/" + this.PopularityValue.ToString(), true);
	}

	// Token: 0x06008CC2 RID: 36034 RVA: 0x002501CF File Offset: 0x0024E3CF
	private void StartTween(int startValue)
	{
		Singleton<AudioSystem>.Instance.PostEvent("play_ui_figure_up_2s");
		this.TweenTime = 2f / (float)this.PlayCount;
		this.PlayTween(startValue, 1);
	}

	// Token: 0x06008CC3 RID: 36035 RVA: 0x002501FC File Offset: 0x0024E3FC
	private void PlayTween(int popularityValue, int playCount)
	{
		this.PopularityValue = ModelBase<MoonChasingBusinessModel>.Instance.GetPopularityConfigByValue(popularityValue).PopularityValue;
		if (this.PlayCount > playCount)
		{
			this.CurrentBar.SetFillAmount(1f);
			this.ExpTweener = ULTweenBPLibrary.IntTo(GlobalData.World, this.Delegate, popularityValue, this.PopularityValue, this.TweenTime, 0f, LTweenEase.OutCubic);
			ULTweener expTweener = this.ExpTweener;
			if (expTweener == null)
			{
				return;
			}
			expTweener.OnCompleteCallBack.Bind(delegate()
			{
				this.OnComplete(this.PopularityValue, playCount);
			});
			return;
		}
		else
		{
			int ownCount = ModelBase<MoonChasingModel>.Instance.GetPopularityValue();
			this.CurrentBar.SetFillAmount((float)ownCount / (float)this.PopularityValue);
			this.ExpTweener = ULTweenBPLibrary.IntTo(GlobalData.World, this.Delegate, popularityValue, ownCount, this.TweenTime, 0f, LTweenEase.OutCubic);
			ULTweener expTweener2 = this.ExpTweener;
			if (expTweener2 == null)
			{
				return;
			}
			expTweener2.OnCompleteCallBack.Bind(delegate()
			{
				this.OnComplete(ownCount, playCount);
			});
			return;
		}
	}

	// Token: 0x06008CC4 RID: 36036 RVA: 0x00250320 File Offset: 0x0024E520
	private void StopTween()
	{
		if (this.ExpTweener != null)
		{
			this.ExpTweener.Kill(false);
			this.ExpTweener = null;
		}
	}

	// Token: 0x06008CC5 RID: 36037 RVA: 0x00250340 File Offset: 0x0024E540
	private void PlayBtnShow()
	{
		UUIButtonComponent button = base.GetButton(4);
		if (button != null)
		{
			button.RootUIComp.Get().SetUIActive(true);
		}
		UiBehaviorLevelSequence uiViewSequence = this.UiViewSequence;
		if (uiViewSequence == null)
		{
			return;
		}
		uiViewSequence.PlaySequencePurely("BtnStart", false, false);
	}

	// Token: 0x06008CC6 RID: 36038 RVA: 0x00250384 File Offset: 0x0024E584
	private void PlayFillAmount(int value)
	{
		this.LastBar.SetFillAmount((float)value / (float)this.PopularityValue);
		this.CurrentText.SetText("<color=#ffd52b>" + value.ToString() + "</color>/" + this.PopularityValue.ToString(), true);
	}

	// Token: 0x06008CC7 RID: 36039 RVA: 0x002503D3 File Offset: 0x0024E5D3
	private void OnComplete(int endValue, int playCount)
	{
		this.StopTween();
		if (playCount >= this.PlayCount)
		{
			return;
		}
		this.PlayTween(endValue, playCount + 1);
		Singleton<AudioSystem>.Instance.PostEvent("play_ui_zhuiyuejie_levelup");
	}

	// Token: 0x0400418E RID: 16782
	[Nullable(2)]
	protected ULTweener ExpTweener;

	// Token: 0x0400418F RID: 16783
	[Nullable(2)]
	protected FLTweenIntSetterDynamic Delegate;

	// Token: 0x04004190 RID: 16784
	[Nullable(2)]
	private MoonChasingPopularityUpData PopularityUpData;

	// Token: 0x04004191 RID: 16785
	protected int PopularityValue;

	// Token: 0x04004192 RID: 16786
	private int PlayCount;

	// Token: 0x04004193 RID: 16787
	private float TweenTime;

	// Token: 0x04004194 RID: 16788
	private UUISprite CurrentBar;

	// Token: 0x04004195 RID: 16789
	private UUIText CurrentText;

	// Token: 0x04004196 RID: 16790
	private UUISprite LastBar;

	// Token: 0x04004197 RID: 16791
	private const float TWEEN_TIME = 2f;

	// Token: 0x020077C2 RID: 30658
	[NullableContext(0)]
	private static class EComponentDefine
	{
		// Token: 0x04029367 RID: 168807
		public const int Title = 0;

		// Token: 0x04029368 RID: 168808
		public const int Name = 1;

		// Token: 0x04029369 RID: 168809
		public const int Content = 2;

		// Token: 0x0402936A RID: 168810
		public const int ExpItem = 3;

		// Token: 0x0402936B RID: 168811
		public const int ConfirmBtn = 4;

		// Token: 0x0402936C RID: 168812
		public const int AddValue = 5;

		// Token: 0x0402936D RID: 168813
		public const int CurrentValue = 6;

		// Token: 0x0402936E RID: 168814
		public const int CurrentBar = 7;

		// Token: 0x0402936F RID: 168815
		public const int LastBar = 8;

		// Token: 0x04029370 RID: 168816
		public const int LevelUpItem = 9;

		// Token: 0x04029371 RID: 168817
		public const int NormalItem = 10;

		// Token: 0x04029372 RID: 168818
		public const int RoleSpine = 11;

		// Token: 0x04029373 RID: 168819
		public const int LanternItem = 12;

		// Token: 0x04029374 RID: 168820
		public const int BgTexture = 13;
	}
}
