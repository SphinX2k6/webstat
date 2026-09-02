using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Effect;
using CSharpScript.Game.Module.Plot;
using CSharpScript.Game.Ui;
using CSharpScript.Game.Utils;
using UnrealEngine;

// Token: 0x020022C4 RID: 8900
[NullableContext(1)]
[Nullable(0)]
public class MotorcycleLevelUpView : UiViewBase
{
	// Token: 0x06010D49 RID: 68937 RVA: 0x0049B1CC File Offset: 0x004993CC
	public MotorcycleLevelUpView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06010D4A RID: 68938 RVA: 0x0049B204 File Offset: 0x00499404
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUITexture)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem))
		};
	}

	// Token: 0x06010D4B RID: 68939 RVA: 0x0049B28C File Offset: 0x0049948C
	protected override void OnStart()
	{
		ILevelUpViewViedData cacheData = ModelBase<MotorcycleDevelopModel>.Instance.GetCacheData();
		ModelBase<MotorcycleDevelopModel>.Instance.ClearCacheData();
		this.IsLevelUp = (cacheData.CurLevel > cacheData.PreLevel);
		this.IsExpUp = cacheData.AddExp;
		this.IsOverLevel = false;
		this.IsOverLoop = false;
		this.CurrentLevel = cacheData.CurLevel;
		this.IsLevelUpAnimeDown = !this.IsLevelUp;
		base.GetText(0).SetText(this.IsExpUp ? cacheData.PreLevel.ToString() : cacheData.CurLevel.ToString(), true);
		this.ShowingExp = (float)(this.IsExpUp ? cacheData.PreExp : cacheData.CurExp);
		this.CurMaxExp = (float)ConfigBase<MotorConfig>.Instance.GetMotorLevelConfig(cacheData.CurLevel).Value.Exp;
		float num;
		if (cacheData.PreLevel == 1)
		{
			num = this.CurMaxExp;
		}
		else
		{
			num = (float)ConfigBase<MotorConfig>.Instance.GetMotorLevelConfig(cacheData.PreLevel).Value.Exp;
		}
		this.PreMaxExp = (this.IsExpUp ? num : this.CurMaxExp);
		this.TargetExp = (this.IsLevelUp ? ((float)cacheData.CurExp + this.PreMaxExp) : ((float)cacheData.CurExp));
		this.AddExp = (this.TargetExp - this.ShowingExp) / (float)this.AnimeTime;
		base.GetItem(3).SetUIActive(true);
		base.GetItem(4).SetUIActive(false);
		this.RefreshExp();
		if (this.IsLevelUp)
		{
			this.UiViewSequence.AddSequenceFinishEvent("LevelUp", delegate(string _)
			{
				this.IsLevelUpAnimeDown = true;
				this.LevelUpTryCloseMe();
			}, false);
		}
	}

	// Token: 0x06010D4C RID: 68940 RVA: 0x0049B446 File Offset: 0x00499646
	private void LevelUpTryCloseMe()
	{
		if (this.IsLevelUpAnimeDown && this.ShowingExp >= this.TargetExp)
		{
			this.TryCloseMe();
		}
	}

	// Token: 0x06010D4D RID: 68941 RVA: 0x0049B464 File Offset: 0x00499664
	private void TryCloseMe()
	{
		if (this.IsInClosing)
		{
			return;
		}
		this.IsInClosing = true;
		base.CloseMe(null);
	}

	// Token: 0x06010D4E RID: 68942 RVA: 0x0049B47D File Offset: 0x0049967D
	protected override void OnBeforeShow()
	{
		if (this.IsLevelUp)
		{
			this.PlayLevelUpEffect();
		}
	}

	// Token: 0x06010D4F RID: 68943 RVA: 0x0049B48D File Offset: 0x0049968D
	protected override void OnAfterShow()
	{
		if (this.IsExpUp)
		{
			this.AnimePlayer = TimerSystem.GameplayTimeInstance.Forever(new TTimerAction(this.BarExpAnime), 20f, 1f, null, null, true);
		}
	}

	// Token: 0x170014DE RID: 5342
	// (get) Token: 0x06010D50 RID: 68944 RVA: 0x0049B4C0 File Offset: 0x004996C0
	private bool GetIsOverLoop
	{
		get
		{
			return this.IsLevelUp && this.ShowingExp >= this.PreMaxExp;
		}
	}

	// Token: 0x06010D51 RID: 68945 RVA: 0x0049B4E0 File Offset: 0x004996E0
	private void RefreshExp()
	{
		if (this.AnimePlayer != null && !this.IsOverLoop && this.GetIsOverLoop)
		{
			this.IsOverLoop = true;
			base.GetText(0).SetText(this.CurrentLevel.ToString(), true);
			base.GetItem(3).SetUIActive(false);
			base.GetItem(4).SetUIActive(true);
			UiBehaviorLevelSequence uiViewSequence = this.UiViewSequence;
			if (uiViewSequence != null)
			{
				uiViewSequence.PlaySequence("LevelUp", false, null);
			}
		}
		float num = this.IsOverLoop ? (this.ShowingExp - this.PreMaxExp) : this.ShowingExp;
		float num2 = this.IsOverLoop ? this.CurMaxExp : this.PreMaxExp;
		base.GetTexture(1).SetFillAmount(num / num2);
		this.CurrentRotator.Yaw = -360f * (num / num2);
		UUIItem item = base.GetItem(2);
		FRotator frotator = this.CurrentRotator.ToUeRotator();
		item.SetUIRelativeRotation(frotator);
		if (this.AnimePlayer != null && num > num2 && !this.IsOverLevel)
		{
			this.IsOverLevel = true;
		}
	}

	// Token: 0x06010D52 RID: 68946 RVA: 0x0049B5EC File Offset: 0x004997EC
	private void BarExpAnime(float delta)
	{
		this.ShowingExp += this.AddExp * delta;
		if (this.ShowingExp >= this.TargetExp)
		{
			this.ShowingExp = this.TargetExp;
			TimerSystem.GameplayTimeInstance.Remove(this.AnimePlayer);
			this.LevelUpTryCloseMe();
		}
		this.RefreshExp();
	}

	// Token: 0x06010D53 RID: 68947 RVA: 0x0049B645 File Offset: 0x00499845
	protected override void OnBeforeDestroy()
	{
		if (this.AnimePlayer != null && TimerSystem.GameplayTimeInstance.Has(this.AnimePlayer))
		{
			TimerSystem.GameplayTimeInstance.Remove(this.AnimePlayer);
		}
		this.RecycleEffect();
	}

	// Token: 0x06010D54 RID: 68948 RVA: 0x0049B678 File Offset: 0x00499878
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<PlotInfo>(EEventName.PlotNetworkStart, new Action<PlotInfo>(this.OnSequenceNetworkStart));
	}

	// Token: 0x06010D55 RID: 68949 RVA: 0x0049B696 File Offset: 0x00499896
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.PlotNetworkStart, new Action<PlotInfo>(this.OnSequenceNetworkStart));
	}

	// Token: 0x06010D56 RID: 68950 RVA: 0x0049B6B4 File Offset: 0x004998B4
	private void OnSequenceNetworkStart(PlotInfo plotInfo)
	{
		this.TryCloseMe();
	}

	// Token: 0x06010D57 RID: 68951 RVA: 0x0049B6BC File Offset: 0x004998BC
	private void PlayLevelUpEffect()
	{
		if (Global.BaseCharacter == null)
		{
			return;
		}
		string effectPath = EffectUtil.GetEffectPath("WorldLevelUpEffect");
		if (effectPath == null || effectPath.Length == 0)
		{
			return;
		}
		TsBaseCharacter baseCharacter = Global.BaseCharacter;
		FTransformDouble value = baseCharacter.D_GetTransform();
		float capsuleHalfHeight = baseCharacter.CapsuleComponent.CapsuleHalfHeight;
		FVectorDouble location = value.GetLocation();
		location.Z -= (double)capsuleHalfHeight;
		value.SetLocation(location);
		if (!Singleton<EffectSystem>.Instance.IsValid(this.EffectHandle))
		{
			EffectSystem instance = Singleton<EffectSystem>.Instance;
			UObject world = GlobalData.World;
			FTransformDouble? ftransformDouble = new FTransformDouble?(value);
			this.EffectHandle = instance.SpawnUnloopedEffect(world, ftransformDouble, effectPath, "[MotorcycleLevelUpView.PlayLevelUpEffect]", null, EEffectType.Scene, null, null, null, false, false);
			if (!Singleton<EffectSystem>.Instance.IsValid(this.EffectHandle))
			{
				this.EffectHandle = 0;
			}
		}
	}

	// Token: 0x06010D58 RID: 68952 RVA: 0x0049B774 File Offset: 0x00499974
	private void RecycleEffect()
	{
		if (Singleton<EffectSystem>.Instance.IsValid(this.EffectHandle))
		{
			Singleton<EffectSystem>.Instance.StopEffectById(this.EffectHandle, "[MotorcycleLevelUpView.RecycleEffect]", true, null);
			this.EffectHandle = 0;
		}
	}

	// Token: 0x040084AB RID: 33963
	private int EffectHandle;

	// Token: 0x040084AC RID: 33964
	private bool IsLevelUp;

	// Token: 0x040084AD RID: 33965
	private bool IsExpUp;

	// Token: 0x040084AE RID: 33966
	private bool IsOverLevel;

	// Token: 0x040084AF RID: 33967
	private bool IsOverLoop;

	// Token: 0x040084B0 RID: 33968
	private float ShowingExp;

	// Token: 0x040084B1 RID: 33969
	private float PreMaxExp;

	// Token: 0x040084B2 RID: 33970
	private float TargetExp;

	// Token: 0x040084B3 RID: 33971
	private float CurMaxExp;

	// Token: 0x040084B4 RID: 33972
	private float AddExp;

	// Token: 0x040084B5 RID: 33973
	private int CurrentLevel;

	// Token: 0x040084B6 RID: 33974
	private bool IsLevelUpAnimeDown;

	// Token: 0x040084B7 RID: 33975
	[Nullable(2)]
	private TimerHandle AnimePlayer;

	// Token: 0x040084B8 RID: 33976
	private bool IsInClosing;

	// Token: 0x040084B9 RID: 33977
	private readonly int AnimeTime = ConfigCommonParamById.GetIntConfig("ExpDisplayTime").Value;

	// Token: 0x040084BA RID: 33978
	private readonly Rotator CurrentRotator = Rotator.Create();

	// Token: 0x02008587 RID: 34183
	[NullableContext(0)]
	private class EChildType
	{
		// Token: 0x0402D2EA RID: 185066
		public const int LevelTxt = 0;

		// Token: 0x0402D2EB RID: 185067
		public const int BarExp = 1;

		// Token: 0x0402D2EC RID: 185068
		public const int ArrowItem = 2;

		// Token: 0x0402D2ED RID: 185069
		public const int ExpUpItem = 3;

		// Token: 0x0402D2EE RID: 185070
		public const int LevelUpItem = 4;
	}
}
