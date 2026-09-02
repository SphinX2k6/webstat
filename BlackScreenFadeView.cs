using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.LevelLoading;
using CSharpScript.Game.Module.Plot;
using CSharpScript.Game.Ui;
using CSharpScript.Game.Utils;
using UnrealEngine;

// Token: 0x020017BD RID: 6077
public class BlackScreenFadeView : UiPanelBase
{
	// Token: 0x0600AB6D RID: 43885 RVA: 0x002DCF38 File Offset: 0x002DB138
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600AB6E RID: 43886 RVA: 0x002DCFA4 File Offset: 0x002DB1A4
	protected override void OnStart()
	{
		this.ViewData.RegisterStateDelegate(BlackScreenViewData.EState.Show, new Action(this.ShowDelegate));
		this.ViewData.RegisterStateDelegate(BlackScreenViewData.EState.Hide, new Action(this.HideDelegate));
		this.TextureWidget = base.GetTexture(1);
		this.TextureWidget2 = base.GetTexture(0);
		Singleton<LguiUtil>.Instance.SetActorIsPermanent(this.RootActor, true, true);
		this.ViewData.TriggerCurrentStateDelegate();
		Singleton<EventSystem>.Instance.Add(EEventName.UIViewPortSizeChanged, new Action(this.OnUiViewPortSizeChanged));
	}

	// Token: 0x0600AB6F RID: 43887 RVA: 0x002DD034 File Offset: 0x002DB234
	protected override void OnBeforeDestroy()
	{
		ModelBase<LevelLoadingModel>.Instance.CameraFadeShowPromise = null;
		ModelBase<LevelLoadingModel>.Instance.CameraFadeHidePromise = null;
		this.IsFadeIn = true;
		this.FullFadeTime = 0f;
		this.FadeTime = 0f;
		this.TextureWidget = null;
		this.TextureWidget2 = null;
		this.RemoveTick(this.TickIdFade);
		this.RemoveTick(this.TickIdSave);
		Singleton<EventSystem>.Instance.Remove(EEventName.UIViewPortSizeChanged, new Action(this.OnUiViewPortSizeChanged));
	}

	// Token: 0x0600AB70 RID: 43888 RVA: 0x002DD0B4 File Offset: 0x002DB2B4
	private void OnCloseEvent()
	{
		if (this.IsFadeIn)
		{
			Singleton<global::Log>.Instance.Info(ELogModule.BlackScreen, ELogAuthor.JYS, "黑幕FadeIn结束", default(ReadOnlySpan<ValueTuple<string, object>>));
			ModelBase<LevelLoadingModel>.Instance.FinishCameraShowPromise();
			return;
		}
		Singleton<global::Log>.Instance.Info(ELogModule.BlackScreen, ELogAuthor.JYS, "黑幕FadeOut结束", default(ReadOnlySpan<ValueTuple<string, object>>));
		ModelBase<LevelLoadingModel>.Instance.FinishCameraHidePromise();
		this.SetActive(false);
		ControllerBase<BlackScreenFadeController>.Instance.NeedInputDis = false;
		ModelBase<InputDistributeModel>.Instance.RefreshInputDistributeTag();
		global::Log instance = Singleton<global::Log>.Instance;
		ELogModule module = ELogModule.BlackScreen;
		ELogAuthor author = ELogAuthor.JYS;
		string message = "黑幕输入恢复";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("BlackScreenFadeController.NeedInputDis", ControllerBase<BlackScreenFadeController>.Instance.NeedInputDis);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		Singleton<UiManager>.Instance.RemoveOpenViewCheckFunction(EUiViewName.All, new Func<EUiViewName, object, bool>(ControllerBase<BlackScreenFadeController>.Instance.CheckCanOpen));
		Singleton<EventSystem>.Instance.Emit(EEventName.OnBlackFadeScreenFinish);
		Singleton<GameSettingsDeviceRender>.Instance.CancelTemporaryDisableFrameGeneration("BlackScreen");
	}

	// Token: 0x0600AB71 RID: 43889 RVA: 0x002DD1AE File Offset: 0x002DB3AE
	private void ShowDelegate()
	{
		Singleton<EventSystem>.Instance.Emit(EEventName.OnBlackFadeScreenStart);
		this.AddTick(this.TickIdFade);
		this.SetActive(true);
		this.UpdateTextureWidgetVisibility();
	}

	// Token: 0x0600AB72 RID: 43890 RVA: 0x002DD1D9 File Offset: 0x002DB3D9
	private void HideDelegate()
	{
		this.SetActive(true);
		this.AddTick(this.TickIdFade);
		this.UpdateTextureWidgetVisibility();
		ModelBase<PlotModel>.Instance.LastPlotColor = -1;
	}

	// Token: 0x0600AB73 RID: 43891 RVA: 0x002DD1FF File Offset: 0x002DB3FF
	private void UpdateTextureWidgetVisibility()
	{
		if (ModelBase<PlotModel>.Instance.LastPlotColor == 1)
		{
			UUITexture textureWidget = this.TextureWidget;
			if (textureWidget == null)
			{
				return;
			}
			textureWidget.SetUIActive(false);
			return;
		}
		else
		{
			UUITexture textureWidget2 = this.TextureWidget;
			if (textureWidget2 == null)
			{
				return;
			}
			textureWidget2.SetUIActive(true);
			return;
		}
	}

	// Token: 0x0600AB74 RID: 43892 RVA: 0x002DD234 File Offset: 0x002DB434
	private void AddTick(int tickId)
	{
		if (tickId != -1)
		{
			return;
		}
		if (tickId == this.TickIdFade)
		{
			ControllerBase<InputDistributeController>.Instance.RefreshInputTag();
			this.TickIdFade = Singleton<TickSystem>.Instance.Add(new Action<float>(this.OnFadeTick), "BlackScreenTransitionView", ETickingGroup.TG_PrePhysics, true, 0, true).Id;
			return;
		}
		if (tickId == this.TickIdSave)
		{
			this.TickIdSave = Singleton<TickSystem>.Instance.Add(new Action<float>(this.OnSaveTick), "BlackScreenTransitionView", ETickingGroup.TG_PrePhysics, true, 0, true).Id;
		}
	}

	// Token: 0x0600AB75 RID: 43893 RVA: 0x002DD2B8 File Offset: 0x002DB4B8
	private void RemoveTick(int tickId)
	{
		if (tickId != -1)
		{
			if (tickId == this.TickIdFade)
			{
				Singleton<TickSystem>.Instance.Remove(this.TickIdFade);
				this.TickIdFade = -1;
				if (!this.IsFadeIn)
				{
					ControllerBase<InputDistributeController>.Instance.RefreshInputTag();
					return;
				}
			}
			else if (tickId == this.TickIdSave)
			{
				Singleton<TickSystem>.Instance.Remove(this.TickIdSave);
				this.TickIdSave = -1;
			}
		}
	}

	// Token: 0x0600AB76 RID: 43894 RVA: 0x002DD320 File Offset: 0x002DB520
	private void OnFadeTick(float deltaTime)
	{
		if (this.LerpTime > 0f)
		{
			float rangePct = Singleton<MathUtils>.Instance.GetRangePct(0f, this.FullLerpTime, this.FullLerpTime - this.LerpTime);
			float blackScreenLastAspect = ModelBase<PlotModel>.Instance.BlackScreenLastAspect;
			float blackScreenNowAspect = ModelBase<PlotModel>.Instance.BlackScreenNowAspect;
			float aspect = blackScreenLastAspect + (blackScreenNowAspect - blackScreenLastAspect) * rangePct;
			this.SetAspect(aspect);
			this.SetFadeTime(0f);
			this.LerpTime -= deltaTime;
		}
		if (this.FadeTime > 0f)
		{
			this.FadeTime -= deltaTime;
			if (this.FadeTime <= 0f)
			{
				this.FadeTime = 0f;
			}
			this.UpdateBlackScreen();
		}
		if (this.FadeTime <= 0f)
		{
			this.FadeTime = 0f;
		}
		if (this.LerpTime <= 0f)
		{
			this.LerpTime = 0f;
		}
		if (this.FadeTime == 0f && this.LerpTime == 0f)
		{
			if (this.IsFadeIn)
			{
				Global.CharacterCameraManager.FadeAmount = 0f;
			}
			this.OnCloseEvent();
			this.RemoveTick(this.TickIdFade);
		}
	}

	// Token: 0x0600AB77 RID: 43895 RVA: 0x002DD447 File Offset: 0x002DB647
	private void OnSaveTick(float deltaTime)
	{
		this.SaveTime += deltaTime;
		if (this.SaveTime > 10000f)
		{
			this.HideItem();
		}
	}

	// Token: 0x0600AB78 RID: 43896 RVA: 0x002DD46A File Offset: 0x002DB66A
	public void ShowItem()
	{
		this.ViewData.SwitchState(BlackScreenViewData.EState.Show);
	}

	// Token: 0x0600AB79 RID: 43897 RVA: 0x002DD479 File Offset: 0x002DB679
	public void HideItem()
	{
		bool flag = this.ViewData.SwitchState(BlackScreenViewData.EState.Hide);
		ModelBase<LevelLoadingModel>.Instance.CameraFadeHidePromise = new CustomPromise();
		if (!flag)
		{
			ModelBase<LevelLoadingModel>.Instance.FinishCameraShowPromise();
			ModelBase<LevelLoadingModel>.Instance.FinishCameraHidePromise();
		}
	}

	// Token: 0x0600AB7A RID: 43898 RVA: 0x002DD4AC File Offset: 0x002DB6AC
	public void UpdateScreenColor(EFadeInScreenShowType screenType)
	{
		if (screenType != EFadeInScreenShowType.White)
		{
			if (screenType == EFadeInScreenShowType.Black)
			{
				UUITexture textureWidget = this.TextureWidget;
				if (textureWidget != null)
				{
					textureWidget.SetColor(ColorUtils.ColorBlack);
				}
				ModelBase<PlotModel>.Instance.LastPlotColor = 1;
			}
		}
		else
		{
			UUITexture textureWidget2 = this.TextureWidget;
			if (textureWidget2 != null)
			{
				textureWidget2.SetColor(ColorUtils.ColorWhile);
			}
			ModelBase<PlotModel>.Instance.LastPlotColor = 0;
		}
		UUITexture textureWidget3 = this.TextureWidget2;
		if (textureWidget3 == null)
		{
			return;
		}
		textureWidget3.SetColor(ColorUtils.ColorBlack);
	}

	// Token: 0x0600AB7B RID: 43899 RVA: 0x002DD51C File Offset: 0x002DB71C
	public void UpdateScreenColorAndChangeVisible(EFadeInScreenShowType screenType)
	{
		if (screenType != EFadeInScreenShowType.White)
		{
			if (screenType == EFadeInScreenShowType.Black)
			{
				UUITexture textureWidget = this.TextureWidget;
				if (textureWidget != null)
				{
					textureWidget.SetColor(ColorUtils.ColorBlack);
				}
				ModelBase<PlotModel>.Instance.LastPlotColor = 1;
			}
		}
		else
		{
			UUITexture textureWidget2 = this.TextureWidget;
			if (textureWidget2 != null)
			{
				textureWidget2.SetColor(ColorUtils.ColorWhile);
			}
			ModelBase<PlotModel>.Instance.LastPlotColor = 0;
		}
		UUITexture textureWidget3 = this.TextureWidget2;
		if (textureWidget3 != null)
		{
			textureWidget3.SetColor(ColorUtils.ColorBlack);
		}
		this.UpdateTextureWidgetVisibility();
	}

	// Token: 0x0600AB7C RID: 43900 RVA: 0x002DD590 File Offset: 0x002DB790
	public bool ChangeAspect(float aspectRatio, bool? bInstantly = null)
	{
		float num = Singleton<UiLayer>.Instance.UiRootItem.GetWidth() / Singleton<UiLayer>.Instance.UiRootItem.GetHeight();
		if (num < 1f)
		{
			return false;
		}
		if (bInstantly.GetValueOrDefault())
		{
			ModelBase<PlotModel>.Instance.BlackScreenLastAspect = ModelBase<PlotModel>.Instance.BlackScreenNowAspect;
			ModelBase<PlotModel>.Instance.BlackScreenNowAspect = (((double)aspectRatio > 2.3) ? aspectRatio : num);
			this.SetAspect(ModelBase<PlotModel>.Instance.BlackScreenNowAspect);
			return false;
		}
		if ((double)ModelBase<PlotModel>.Instance.BlackScreenNowAspect > 2.3 != (double)aspectRatio > 2.3 && ModelBase<PlotModel>.Instance.LastPlotAspect != -1f && ModelBase<PlotModel>.Instance.LastPlotColor == 0)
		{
			ModelBase<PlotModel>.Instance.BlackScreenLastAspect = ModelBase<PlotModel>.Instance.BlackScreenNowAspect;
			ModelBase<PlotModel>.Instance.BlackScreenNowAspect = (((double)aspectRatio > 2.3) ? aspectRatio : num);
			int valueOrDefault = ConfigCommonParamById.GetIntConfig("BlackScreenFadeLerpFullTime").GetValueOrDefault(3);
			this.LerpTime = (float)(valueOrDefault * 1000);
			this.FullLerpTime = (float)(valueOrDefault * 1000);
			UUITexture textureWidget = this.TextureWidget;
			if (textureWidget != null)
			{
				textureWidget.SetUIActive(true);
			}
			return true;
		}
		ModelBase<PlotModel>.Instance.BlackScreenNowAspect = (((double)aspectRatio > 2.3) ? aspectRatio : num);
		this.SetAspect(ModelBase<PlotModel>.Instance.BlackScreenNowAspect);
		return false;
	}

	// Token: 0x0600AB7D RID: 43901 RVA: 0x002DD6F8 File Offset: 0x002DB8F8
	private void SetAspect(float aspectRatio)
	{
		float height = Singleton<UiLayer>.Instance.UiRootItem.GetWidth() / aspectRatio;
		UUITexture textureWidget = this.TextureWidget;
		if (textureWidget != null)
		{
			textureWidget.SetHeight(height);
		}
		UUITexture textureWidget2 = this.TextureWidget;
		if (textureWidget2 == null)
		{
			return;
		}
		textureWidget2.SetWidth(Singleton<UiLayer>.Instance.UiRootItem.GetWidth());
	}

	// Token: 0x0600AB7E RID: 43902 RVA: 0x002DD748 File Offset: 0x002DB948
	private void UpdateBlackScreen()
	{
		float nowAlpha = this.GetNowAlpha();
		UUITexture textureWidget = this.TextureWidget2;
		if (textureWidget != null)
		{
			textureWidget.SetAlpha(nowAlpha);
		}
		UUITexture textureWidget2 = this.TextureWidget;
		if (textureWidget2 == null)
		{
			return;
		}
		textureWidget2.SetAlpha(nowAlpha);
	}

	// Token: 0x0600AB7F RID: 43903 RVA: 0x002DD780 File Offset: 0x002DB980
	private float GetNowAlpha()
	{
		if (this.IsFadeIn)
		{
			if (Global.CharacterCameraManager.FadeAmount >= 0.9f)
			{
				return 1f;
			}
			if (this.FullFadeTime == 0f)
			{
				return 1f;
			}
			return 1f - Singleton<MathUtils>.Instance.GetRangePct(0f, this.FullFadeTime, this.FadeTime);
		}
		else
		{
			if (this.FullFadeTime == 0f)
			{
				return 0f;
			}
			return Singleton<MathUtils>.Instance.GetRangePct(0f, this.FullFadeTime, this.FadeTime);
		}
	}

	// Token: 0x0600AB80 RID: 43904 RVA: 0x002DD80F File Offset: 0x002DBA0F
	public void SetFadeTime(float num)
	{
		this.FadeTime = num;
		this.FullFadeTime = num;
	}

	// Token: 0x0600AB81 RID: 43905 RVA: 0x002DD81F File Offset: 0x002DBA1F
	public void SetIsFadeIn(bool value)
	{
		this.IsFadeIn = value;
	}

	// Token: 0x0600AB82 RID: 43906 RVA: 0x002DD828 File Offset: 0x002DBA28
	public EFadeInScreenShowType? GetScreenColorType()
	{
		if (this.TextureWidget == null)
		{
			return null;
		}
		return new EFadeInScreenShowType?(this.TextureWidget.GetColor().Equals(ColorUtils.ColorBlack) ? EFadeInScreenShowType.Black : EFadeInScreenShowType.White);
	}

	// Token: 0x0600AB83 RID: 43907 RVA: 0x002DD86A File Offset: 0x002DBA6A
	private void OnUiViewPortSizeChanged()
	{
		this.SetAspect(ModelBase<PlotModel>.Instance.BlackScreenNowAspect);
	}

	// Token: 0x0400518A RID: 20874
	private float SaveTime;

	// Token: 0x0400518B RID: 20875
	private float FadeTime;

	// Token: 0x0400518C RID: 20876
	private float FullFadeTime;

	// Token: 0x0400518D RID: 20877
	private float LerpTime;

	// Token: 0x0400518E RID: 20878
	private float FullLerpTime;

	// Token: 0x0400518F RID: 20879
	private bool IsFadeIn = true;

	// Token: 0x04005190 RID: 20880
	private int TickIdFade = -1;

	// Token: 0x04005191 RID: 20881
	private int TickIdSave = -1;

	// Token: 0x04005192 RID: 20882
	[Nullable(1)]
	private readonly BlackScreenViewData ViewData = new BlackScreenViewData();

	// Token: 0x04005193 RID: 20883
	[Nullable(2)]
	private UUITexture TextureWidget;

	// Token: 0x04005194 RID: 20884
	[Nullable(2)]
	private UUITexture TextureWidget2;

	// Token: 0x04005195 RID: 20885
	private const float GUARANTEED_TIME = 10000f;

	// Token: 0x04005196 RID: 20886
	private const float MAX_FADE_VALUE = 0.9f;

	// Token: 0x02007B01 RID: 31489
	private static class ECompDefine
	{
		// Token: 0x0402A1F1 RID: 172529
		public const int BlackTexture = 0;

		// Token: 0x0402A1F2 RID: 172530
		public const int BlackTexture2 = 1;
	}
}
