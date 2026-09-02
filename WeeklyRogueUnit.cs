using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.BattleUi;
using CSharpScript.Game.Module.BattleUi.Views;
using CSharpScript.Game.Module.GenericPrompt;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001FCE RID: 8142
[NullableContext(2)]
[Nullable(0)]
public class WeeklyRogueUnit : HudUnitBase
{
	// Token: 0x0600F5C6 RID: 62918 RVA: 0x00434BB0 File Offset: 0x00432DB0
	protected unsafe override void OnRegisterComponent()
	{
		int num = 6;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		if (!Singleton<Info>.Instance.IsInTouch())
		{
			this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(6, typeof(UUIItem)));
		}
	}

	// Token: 0x0600F5C7 RID: 62919 RVA: 0x00434CC4 File Offset: 0x00432EC4
	protected override UniTask OnBeforeStartAsync()
	{
		WeeklyRogueUnit.<OnBeforeStartAsync>d__19 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<WeeklyRogueUnit.<OnBeforeStartAsync>d__19>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600F5C8 RID: 62920 RVA: 0x00434D08 File Offset: 0x00432F08
	protected override void OnStart()
	{
		base.OnStart();
		this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
		base.InitTweenAnim(5);
		UUIItem item = base.GetItem(4);
		if (item != null)
		{
			item.SetAlpha(1f);
		}
		this.ArtifactId = ModelBase<WeeklyRogueModel>.Instance.GetArtifactBuffId();
		if (this.ArtifactId != 0)
		{
			this.ArtifactConfig = ConfigBase<WeeklyRogueConfig>.Instance.GetRogueWeeklyBuffPool(this.ArtifactId);
		}
		RogueWeeklyCycle? cycleConfig = ModelBase<WeeklyRogueModel>.Instance.ActivityData.GetCycleConfig();
		if (cycleConfig != null)
		{
			long? battleBuffIdMap = cycleConfig.Value.GetBattleBuffIdMap(this.ArtifactId);
			long? num = battleBuffIdMap;
			long num2 = 0L;
			if ((num.GetValueOrDefault() == num2 & num != null) || battleBuffIdMap == null)
			{
				battleBuffIdMap = cycleConfig.Value.GetBattleBuffIdMap(0);
			}
			this.BuffId = battleBuffIdMap.GetValueOrDefault();
		}
		this.BarTex = base.GetTexture(0);
		this.PointItem = base.GetItem(1);
		this.PointRotator = new FRotator(0f, 0f, 0f);
		if (!Singleton<Info>.Instance.IsInTouch())
		{
			CombineKeyItem keyItemPc = this.KeyItemPc;
			if (keyItemPc != null)
			{
				keyItemPc.SetUiActive(true);
			}
		}
		this.RefreshIcon();
	}

	// Token: 0x0600F5C9 RID: 62921 RVA: 0x00434E44 File Offset: 0x00433044
	private void RefreshIcon()
	{
		UUITexture iconTexture = base.GetTexture(2);
		iconTexture.SetUIActive(false);
		string text = (this.ArtifactConfig != null) ? this.ArtifactConfig.GetValueOrDefault().ButtonIcon : null;
		if (!string.IsNullOrEmpty(text))
		{
			this.LoadIconId = Singleton<ResourceSystem>.Instance.LoadAsync<UTexture2D>(text, delegate([Nullable(2)] UTexture2D iconTextureData, string _)
			{
				this.LoadIconId = -1;
				if (iconTextureData == null)
				{
					return;
				}
				iconTexture.SetUIActive(true);
				iconTexture.SetTexture(iconTextureData);
			}, 103, this.MemoryTag);
			return;
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.WeeklyRogue;
		ELogAuthor author = ELogAuthor.CFT;
		string message = "神器图标路径为空";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("神器Id", this.ArtifactId);
		instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
	}

	// Token: 0x0600F5CA RID: 62922 RVA: 0x00434EFC File Offset: 0x004330FC
	protected override void OnBeforeShow()
	{
		base.OnBeforeShow();
		Singleton<EventSystem>.Instance.Add<int, int>(EEventName.BattleUiCurRoleDataChanged, new Action<int, int>(this.OnBattleUiCurRoleDataChanged));
		this.RefreshRoleData();
		this.LevelSequencePlayer.PlaySequencePurely("Start", false, false, null, null, false);
		this.RefreshTriggerConfig();
		string text = (this.TriggerConfig != null) ? this.TriggerConfig.GetValueOrDefault().BuffTriggerActionName : null;
		if (!string.IsNullOrEmpty(text))
		{
			CombineKeyItem keyItemPc = this.KeyItemPc;
			if (keyItemPc != null)
			{
				keyItemPc.RefreshAction(text);
			}
			CombineKeyItem keyItemPc2 = this.KeyItemPc;
			if (keyItemPc2 != null)
			{
				keyItemPc2.SetUiActive(true);
			}
		}
		else
		{
			CombineKeyItem keyItemPc3 = this.KeyItemPc;
			if (keyItemPc3 != null)
			{
				keyItemPc3.SetUiActive(false);
			}
		}
		int? num = (this.TriggerConfig != null) ? new int?(this.TriggerConfig.GetValueOrDefault().BuffTriggerTagId) : null;
		if (num == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.WeeklyRogue;
			ELogAuthor author = ELogAuthor.CFT;
			string message = "神器触发tag为空";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("神器Id", this.ArtifactId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		RogueWeekTag? rogueWeekTagConfig = ConfigBase<WeeklyRogueConfig>.Instance.GetRogueWeekTagConfig(num.Value);
		if (rogueWeekTagConfig == null)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.WeeklyRogue;
			ELogAuthor author2 = ELogAuthor.CFT;
			string message2 = "神器触发tag缺少配置";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("BuffTriggerTagId", num);
			instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			return;
		}
		string name = rogueWeekTagConfig.Value.Name;
		UUIText text2 = base.GetText(3);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(text2, name, Array.Empty<object>());
		string text3 = ConfigMultiTextLang.GetLocalTextNew(name, null) ?? name;
		ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("WeeklyRogueUseArtifact", new object[]
		{
			text3
		});
	}

	// Token: 0x0600F5CB RID: 62923 RVA: 0x004350C4 File Offset: 0x004332C4
	private void RefreshRoleData()
	{
		BattleUiRoleData curRoleData = ModelBase<BattleUiModel>.Instance.GetCurRoleData();
		if (curRoleData != null)
		{
			this.BuffComponent = curRoleData.BuffComponent;
		}
	}

	// Token: 0x0600F5CC RID: 62924 RVA: 0x004350EB File Offset: 0x004332EB
	private void OnBattleUiCurRoleDataChanged(int newEntityId, int oldEntityId)
	{
		this.RefreshRoleData();
	}

	// Token: 0x0600F5CD RID: 62925 RVA: 0x004350F3 File Offset: 0x004332F3
	protected override void OnBeforeHide()
	{
		Singleton<EventSystem>.Instance.Remove<int, int>(EEventName.BattleUiCurRoleDataChanged, new Action<int, int>(this.OnBattleUiCurRoleDataChanged));
	}

	// Token: 0x0600F5CE RID: 62926 RVA: 0x00435114 File Offset: 0x00433314
	protected override void OnBeforeDestroy()
	{
		base.StopTweenAnim(5);
		base.OnBeforeDestroy();
		LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		if (levelSequencePlayer != null)
		{
			levelSequencePlayer.Clear();
		}
		this.LevelSequencePlayer = null;
		if (this.LoadIconId != -1)
		{
			Singleton<ResourceSystem>.Instance.CancelAsyncLoad(this.LoadIconId);
			this.LoadIconId = -1;
		}
		this.DestroyPromise();
		this.DestroyTimer();
	}

	// Token: 0x0600F5CF RID: 62927 RVA: 0x00435174 File Offset: 0x00433374
	protected override UniTask OnBeforeHideAsync()
	{
		WeeklyRogueUnit.<OnBeforeHideAsync>d__27 <OnBeforeHideAsync>d__;
		<OnBeforeHideAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeHideAsync>d__.<>4__this = this;
		<OnBeforeHideAsync>d__.<>1__state = -1;
		<OnBeforeHideAsync>d__.<>t__builder.Start<WeeklyRogueUnit.<OnBeforeHideAsync>d__27>(ref <OnBeforeHideAsync>d__);
		return <OnBeforeHideAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600F5D0 RID: 62928 RVA: 0x004351B7 File Offset: 0x004333B7
	private void DestroyPromise()
	{
		if (this.Promise != null)
		{
			this.Promise.SetResult();
			this.Promise = null;
		}
	}

	// Token: 0x0600F5D1 RID: 62929 RVA: 0x004351D3 File Offset: 0x004333D3
	private void DestroyTimer()
	{
		if (this.Timer != null)
		{
			TimerSystem.Instance.Remove(this.Timer);
			this.Timer = null;
		}
	}

	// Token: 0x0600F5D2 RID: 62930 RVA: 0x004351F8 File Offset: 0x004333F8
	private void RefreshTriggerConfig()
	{
		List<int> buffIdListByType = ModelBase<WeeklyRogueModel>.Instance.GetBuffIdListByType(EWeeklyRogueBuffType.Modifier);
		if (buffIdListByType.Count > 0)
		{
			this.TriggerConfig = ConfigBase<WeeklyRogueConfig>.Instance.GetRogueWeeklyBuffPool(buffIdListByType[0]);
			return;
		}
		this.TriggerConfig = this.ArtifactConfig;
	}

	// Token: 0x0600F5D3 RID: 62931 RVA: 0x00435240 File Offset: 0x00433440
	public override void Tick(float delta)
	{
		base.Tick(delta);
		if (!base.IsShowOrShowing)
		{
			return;
		}
		if (this.Buff != null)
		{
			CharacterBuffComponent buffComponent = this.BuffComponent;
			if (((buffComponent != null) ? buffComponent.GetBuffByHandle(this.BuffHandle) : null) != null)
			{
				goto IL_68;
			}
		}
		CharacterBuffComponent buffComponent2 = this.BuffComponent;
		this.Buff = ((buffComponent2 != null) ? buffComponent2.GetBuffById(this.BuffId) : null);
		IActiveBuff buff = this.Buff;
		this.BuffHandle = ((buff != null) ? buff.Handle : 0);
		IL_68:
		if (this.Buff != null)
		{
			float remainDuration = this.Buff.GetRemainDuration();
			this.SetProgress(remainDuration / this.Buff.Duration);
			this.PlayWarnAnim(remainDuration < 1f);
			return;
		}
		this.SetProgress(0f);
	}

	// Token: 0x0600F5D4 RID: 62932 RVA: 0x004352F6 File Offset: 0x004334F6
	private void SetProgress(float progress)
	{
		this.PointRotator.Yaw = progress * -360f;
		UUIItem pointItem = this.PointItem;
		if (pointItem != null)
		{
			pointItem.SetUIRelativeRotation(this.PointRotator);
		}
		UUITexture barTex = this.BarTex;
		if (barTex == null)
		{
			return;
		}
		barTex.SetFillAmount(progress);
	}

	// Token: 0x0600F5D5 RID: 62933 RVA: 0x00435332 File Offset: 0x00433532
	private void PlayWarnAnim(bool bPlay)
	{
		if (this.IsPlayWarnAnim == bPlay)
		{
			return;
		}
		this.IsPlayWarnAnim = bPlay;
		if (bPlay)
		{
			base.PlayTweenAnim(5);
			return;
		}
		base.StopTweenAnim(5);
		UUIItem item = base.GetItem(4);
		if (item == null)
		{
			return;
		}
		item.SetAlpha(1f);
	}

	// Token: 0x040076D0 RID: 30416
	private const float CLOSE_ANIM_TIME = 550f;

	// Token: 0x040076D1 RID: 30417
	private LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x040076D2 RID: 30418
	private CombineKeyItem KeyItemPc;

	// Token: 0x040076D3 RID: 30419
	private UUITexture BarTex;

	// Token: 0x040076D4 RID: 30420
	private UUIItem PointItem;

	// Token: 0x040076D5 RID: 30421
	private FRotator PointRotator;

	// Token: 0x040076D6 RID: 30422
	private CharacterBuffComponent BuffComponent;

	// Token: 0x040076D7 RID: 30423
	private long BuffId;

	// Token: 0x040076D8 RID: 30424
	private IActiveBuff Buff;

	// Token: 0x040076D9 RID: 30425
	private int BuffHandle;

	// Token: 0x040076DA RID: 30426
	private int ArtifactId;

	// Token: 0x040076DB RID: 30427
	private RogueWeeklyBuffPool? ArtifactConfig;

	// Token: 0x040076DC RID: 30428
	private RogueWeeklyBuffPool? TriggerConfig;

	// Token: 0x040076DD RID: 30429
	private int LoadIconId = -1;

	// Token: 0x040076DE RID: 30430
	private CustomPromise Promise;

	// Token: 0x040076DF RID: 30431
	private TimerHandle Timer;

	// Token: 0x040076E0 RID: 30432
	private bool IsPlayWarnAnim;

	// Token: 0x0200835D RID: 33629
	[NullableContext(0)]
	private enum EChildType
	{
		// Token: 0x0402C8E5 RID: 182501
		BarTex,
		// Token: 0x0402C8E6 RID: 182502
		PointItem,
		// Token: 0x0402C8E7 RID: 182503
		IconTex,
		// Token: 0x0402C8E8 RID: 182504
		DescText,
		// Token: 0x0402C8E9 RID: 182505
		ContentItem,
		// Token: 0x0402C8EA RID: 182506
		AniWarn,
		// Token: 0x0402C8EB RID: 182507
		KeyItem
	}
}
