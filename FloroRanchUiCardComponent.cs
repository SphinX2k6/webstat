using System;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x02001BE8 RID: 7144
[NullableContext(1)]
[Nullable(0)]
[FloroRanchEntityComponent(EFloroRanchEntityComponent.FloroRanchUiCardComponent)]
public class FloroRanchUiCardComponent : FloroRanchUiItemBaseComponent
{
	// Token: 0x0600CFC1 RID: 53185 RVA: 0x00372C6C File Offset: 0x00370E6C
	[return: Nullable(new byte[]
	{
		0,
		2
	})]
	public override UniTask<FloroRanchUiItemBase> PlayShowAnim()
	{
		FloroRanchUiCardComponent.<PlayShowAnim>d__1 <PlayShowAnim>d__;
		<PlayShowAnim>d__.<>t__builder = AsyncUniTaskMethodBuilder<FloroRanchUiItemBase>.Create();
		<PlayShowAnim>d__.<>4__this = this;
		<PlayShowAnim>d__.<>1__state = -1;
		<PlayShowAnim>d__.<>t__builder.Start<FloroRanchUiCardComponent.<PlayShowAnim>d__1>(ref <PlayShowAnim>d__);
		return <PlayShowAnim>d__.<>t__builder.Task;
	}

	// Token: 0x0600CFC2 RID: 53186 RVA: 0x00372CB0 File Offset: 0x00370EB0
	[return: Nullable(new byte[]
	{
		0,
		2
	})]
	public override UniTask<FloroRanchUiItemBase> CreateUiItem()
	{
		FloroRanchUiCardComponent.<CreateUiItem>d__2 <CreateUiItem>d__;
		<CreateUiItem>d__.<>t__builder = AsyncUniTaskMethodBuilder<FloroRanchUiItemBase>.Create();
		<CreateUiItem>d__.<>4__this = this;
		<CreateUiItem>d__.<>1__state = -1;
		<CreateUiItem>d__.<>t__builder.Start<FloroRanchUiCardComponent.<CreateUiItem>d__2>(ref <CreateUiItem>d__);
		return <CreateUiItem>d__.<>t__builder.Task;
	}

	// Token: 0x0600CFC3 RID: 53187 RVA: 0x00372CF4 File Offset: 0x00370EF4
	public override UniTask PlayHideAnim()
	{
		FloroRanchUiCardComponent.<PlayHideAnim>d__3 <PlayHideAnim>d__;
		<PlayHideAnim>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PlayHideAnim>d__.<>4__this = this;
		<PlayHideAnim>d__.<>1__state = -1;
		<PlayHideAnim>d__.<>t__builder.Start<FloroRanchUiCardComponent.<PlayHideAnim>d__3>(ref <PlayHideAnim>d__);
		return <PlayHideAnim>d__.<>t__builder.Task;
	}

	// Token: 0x0600CFC4 RID: 53188 RVA: 0x00372D38 File Offset: 0x00370F38
	public override UniTask ShowUiItem()
	{
		FloroRanchUiCardComponent.<ShowUiItem>d__4 <ShowUiItem>d__;
		<ShowUiItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<ShowUiItem>d__.<>4__this = this;
		<ShowUiItem>d__.<>1__state = -1;
		<ShowUiItem>d__.<>t__builder.Start<FloroRanchUiCardComponent.<ShowUiItem>d__4>(ref <ShowUiItem>d__);
		return <ShowUiItem>d__.<>t__builder.Task;
	}

	// Token: 0x0600CFC5 RID: 53189 RVA: 0x00372D7C File Offset: 0x00370F7C
	public override UniTask HideUiItem()
	{
		FloroRanchUiCardComponent.<HideUiItem>d__5 <HideUiItem>d__;
		<HideUiItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<HideUiItem>d__.<>4__this = this;
		<HideUiItem>d__.<>1__state = -1;
		<HideUiItem>d__.<>t__builder.Start<FloroRanchUiCardComponent.<HideUiItem>d__5>(ref <HideUiItem>d__);
		return <HideUiItem>d__.<>t__builder.Task;
	}

	// Token: 0x0600CFC6 RID: 53190 RVA: 0x00372DC0 File Offset: 0x00370FC0
	public override UniTask PlayNormalAnim()
	{
		FloroRanchUiCardComponent.<PlayNormalAnim>d__6 <PlayNormalAnim>d__;
		<PlayNormalAnim>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PlayNormalAnim>d__.<>4__this = this;
		<PlayNormalAnim>d__.<>1__state = -1;
		<PlayNormalAnim>d__.<>t__builder.Start<FloroRanchUiCardComponent.<PlayNormalAnim>d__6>(ref <PlayNormalAnim>d__);
		return <PlayNormalAnim>d__.<>t__builder.Task;
	}

	// Token: 0x0600CFC7 RID: 53191 RVA: 0x00372E03 File Offset: 0x00371003
	public override void Pause()
	{
		if (this.FloroRanchUiCardItem == null)
		{
			return;
		}
		this.FloroRanchUiCardItem.Pause();
	}

	// Token: 0x0600CFC8 RID: 53192 RVA: 0x00372E19 File Offset: 0x00371019
	public override void Resume()
	{
		if (this.FloroRanchUiCardItem == null)
		{
			return;
		}
		this.FloroRanchUiCardItem.Resume();
	}

	// Token: 0x0600CFC9 RID: 53193 RVA: 0x00372E2F File Offset: 0x0037102F
	protected override void OnExit()
	{
		if (this.FloroRanchUiCardItem != null)
		{
			this.FloroRanchUiCardItem.UnbindData();
			this.FloroRanchUiCardItem = null;
		}
	}

	// Token: 0x0600CFCA RID: 53194 RVA: 0x00372E4C File Offset: 0x0037104C
	[PreserveBaseOverrides]
	public new virtual FloroRanchUiCardItem GetUiItem()
	{
		if (this.FloroRanchUiCardItem == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.FloroRanchGamePlay;
			ELogAuthor author = ELogAuthor.LRC;
			string message = "FloroRanchUiCardComponent GetUiItem 实体不存在";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("entityId", this.OwnerEntity.EntityId);
			instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}
		return this.FloroRanchUiCardItem;
	}

	// Token: 0x0600CFCB RID: 53195 RVA: 0x00372EA0 File Offset: 0x003710A0
	public override UniTask MoveToTarget(FloroRanchUiItemBase uiItemBase)
	{
		FloroRanchUiCardComponent.<MoveToTarget>d__11 <MoveToTarget>d__;
		<MoveToTarget>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<MoveToTarget>d__.<>4__this = this;
		<MoveToTarget>d__.uiItemBase = uiItemBase;
		<MoveToTarget>d__.<>1__state = -1;
		<MoveToTarget>d__.<>t__builder.Start<FloroRanchUiCardComponent.<MoveToTarget>d__11>(ref <MoveToTarget>d__);
		return <MoveToTarget>d__.<>t__builder.Task;
	}

	// Token: 0x0600CFCC RID: 53196 RVA: 0x00372EEC File Offset: 0x003710EC
	public override UniTask MoveToOriginalPosition()
	{
		FloroRanchUiCardComponent.<MoveToOriginalPosition>d__12 <MoveToOriginalPosition>d__;
		<MoveToOriginalPosition>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<MoveToOriginalPosition>d__.<>4__this = this;
		<MoveToOriginalPosition>d__.<>1__state = -1;
		<MoveToOriginalPosition>d__.<>t__builder.Start<FloroRanchUiCardComponent.<MoveToOriginalPosition>d__12>(ref <MoveToOriginalPosition>d__);
		return <MoveToOriginalPosition>d__.<>t__builder.Task;
	}

	// Token: 0x0600CFCD RID: 53197 RVA: 0x00372F2F File Offset: 0x0037112F
	public void RefreshEvolveItem()
	{
		if (this.FloroRanchUiCardItem == null)
		{
			return;
		}
		this.FloroRanchUiCardItem.RefreshEvolveItem();
	}

	// Token: 0x0600CFCE RID: 53198 RVA: 0x00372F45 File Offset: 0x00371145
	public void RefreshRemainTimeItem()
	{
		if (this.FloroRanchUiCardItem == null)
		{
			return;
		}
		this.FloroRanchUiCardItem.RefreshRemainTimeItem();
	}

	// Token: 0x0600CFCF RID: 53199 RVA: 0x00372F5C File Offset: 0x0037115C
	public override UniTask PlayEatAnim()
	{
		FloroRanchUiCardComponent.<PlayEatAnim>d__15 <PlayEatAnim>d__;
		<PlayEatAnim>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PlayEatAnim>d__.<>4__this = this;
		<PlayEatAnim>d__.<>1__state = -1;
		<PlayEatAnim>d__.<>t__builder.Start<FloroRanchUiCardComponent.<PlayEatAnim>d__15>(ref <PlayEatAnim>d__);
		return <PlayEatAnim>d__.<>t__builder.Task;
	}

	// Token: 0x0600CFD0 RID: 53200 RVA: 0x00372FA0 File Offset: 0x003711A0
	public override UniTask PlayBeEatAnim()
	{
		FloroRanchUiCardComponent.<PlayBeEatAnim>d__16 <PlayBeEatAnim>d__;
		<PlayBeEatAnim>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PlayBeEatAnim>d__.<>4__this = this;
		<PlayBeEatAnim>d__.<>1__state = -1;
		<PlayBeEatAnim>d__.<>t__builder.Start<FloroRanchUiCardComponent.<PlayBeEatAnim>d__16>(ref <PlayBeEatAnim>d__);
		return <PlayBeEatAnim>d__.<>t__builder.Task;
	}

	// Token: 0x0600CFD1 RID: 53201 RVA: 0x00372FE4 File Offset: 0x003711E4
	public override UniTask PlaySacrificeAnim()
	{
		FloroRanchUiCardComponent.<PlaySacrificeAnim>d__17 <PlaySacrificeAnim>d__;
		<PlaySacrificeAnim>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PlaySacrificeAnim>d__.<>4__this = this;
		<PlaySacrificeAnim>d__.<>1__state = -1;
		<PlaySacrificeAnim>d__.<>t__builder.Start<FloroRanchUiCardComponent.<PlaySacrificeAnim>d__17>(ref <PlaySacrificeAnim>d__);
		return <PlaySacrificeAnim>d__.<>t__builder.Task;
	}

	// Token: 0x0600CFD2 RID: 53202 RVA: 0x00373028 File Offset: 0x00371228
	public override UniTask PlayFusionHideAnim()
	{
		FloroRanchUiCardComponent.<PlayFusionHideAnim>d__18 <PlayFusionHideAnim>d__;
		<PlayFusionHideAnim>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PlayFusionHideAnim>d__.<>4__this = this;
		<PlayFusionHideAnim>d__.<>1__state = -1;
		<PlayFusionHideAnim>d__.<>t__builder.Start<FloroRanchUiCardComponent.<PlayFusionHideAnim>d__18>(ref <PlayFusionHideAnim>d__);
		return <PlayFusionHideAnim>d__.<>t__builder.Task;
	}

	// Token: 0x0600CFD3 RID: 53203 RVA: 0x0037306C File Offset: 0x0037126C
	public override UniTask PlayFusionShowAnim()
	{
		FloroRanchUiCardComponent.<PlayFusionShowAnim>d__19 <PlayFusionShowAnim>d__;
		<PlayFusionShowAnim>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PlayFusionShowAnim>d__.<>4__this = this;
		<PlayFusionShowAnim>d__.<>1__state = -1;
		<PlayFusionShowAnim>d__.<>t__builder.Start<FloroRanchUiCardComponent.<PlayFusionShowAnim>d__19>(ref <PlayFusionShowAnim>d__);
		return <PlayFusionShowAnim>d__.<>t__builder.Task;
	}

	// Token: 0x0600CFD4 RID: 53204 RVA: 0x003730B0 File Offset: 0x003712B0
	public override UniTask PlayEvolveUpAnim()
	{
		FloroRanchUiCardComponent.<PlayEvolveUpAnim>d__20 <PlayEvolveUpAnim>d__;
		<PlayEvolveUpAnim>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PlayEvolveUpAnim>d__.<>4__this = this;
		<PlayEvolveUpAnim>d__.<>1__state = -1;
		<PlayEvolveUpAnim>d__.<>t__builder.Start<FloroRanchUiCardComponent.<PlayEvolveUpAnim>d__20>(ref <PlayEvolveUpAnim>d__);
		return <PlayEvolveUpAnim>d__.<>t__builder.Task;
	}

	// Token: 0x0600CFD5 RID: 53205 RVA: 0x003730F4 File Offset: 0x003712F4
	public override void PlayVideo()
	{
		if (this.FloroRanchUiCardItem == null)
		{
			return;
		}
		if (ModelBase<FloroRanchGamePlayModel>.Instance.IsSkip)
		{
			return;
		}
		FloroRanchCardData cardData = this.OwnerEntity.CheckGetComponent<FloroRanchCardDataComponent>().CardData;
		Singleton<AudioSystem>.Instance.PostEvent(cardData.Video);
	}

	// Token: 0x040062F0 RID: 25328
	private FloroRanchUiCardItem FloroRanchUiCardItem;
}
