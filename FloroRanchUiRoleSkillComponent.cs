using System;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x02001BEB RID: 7147
[NullableContext(2)]
[Nullable(0)]
[FloroRanchEntityComponent(EFloroRanchEntityComponent.FloroRanchUiRoleSkillComponent)]
public class FloroRanchUiRoleSkillComponent : FloroRanchUiItemBaseComponent
{
	// Token: 0x0600CFF0 RID: 53232 RVA: 0x0037320C File Offset: 0x0037140C
	[PreserveBaseOverrides]
	public new virtual FloroRanchUiRoleSkillItem GetUiItem()
	{
		if (this.UiRoleSkillItem == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.FloroRanchGamePlay;
			ELogAuthor author = ELogAuthor.LRC;
			string message = "FloroRanchUiRoleSkillComponent GetUiItem 实体不存在";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("entityId", this.OwnerEntity.EntityId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}
		return this.UiRoleSkillItem;
	}

	// Token: 0x0600CFF1 RID: 53233 RVA: 0x00373260 File Offset: 0x00371460
	[return: Nullable(new byte[]
	{
		0,
		2
	})]
	public override UniTask<FloroRanchUiItemBase> PlayShowAnim()
	{
		FloroRanchUiRoleSkillComponent.<PlayShowAnim>d__2 <PlayShowAnim>d__;
		<PlayShowAnim>d__.<>t__builder = AsyncUniTaskMethodBuilder<FloroRanchUiItemBase>.Create();
		<PlayShowAnim>d__.<>4__this = this;
		<PlayShowAnim>d__.<>1__state = -1;
		<PlayShowAnim>d__.<>t__builder.Start<FloroRanchUiRoleSkillComponent.<PlayShowAnim>d__2>(ref <PlayShowAnim>d__);
		return <PlayShowAnim>d__.<>t__builder.Task;
	}

	// Token: 0x0600CFF2 RID: 53234 RVA: 0x003732A4 File Offset: 0x003714A4
	[return: Nullable(new byte[]
	{
		0,
		2
	})]
	public override UniTask<FloroRanchUiItemBase> CreateUiItem()
	{
		FloroRanchUiRoleSkillComponent.<CreateUiItem>d__3 <CreateUiItem>d__;
		<CreateUiItem>d__.<>t__builder = AsyncUniTaskMethodBuilder<FloroRanchUiItemBase>.Create();
		<CreateUiItem>d__.<>4__this = this;
		<CreateUiItem>d__.<>1__state = -1;
		<CreateUiItem>d__.<>t__builder.Start<FloroRanchUiRoleSkillComponent.<CreateUiItem>d__3>(ref <CreateUiItem>d__);
		return <CreateUiItem>d__.<>t__builder.Task;
	}

	// Token: 0x0600CFF3 RID: 53235 RVA: 0x003732E8 File Offset: 0x003714E8
	public override UniTask PlayHideAnim()
	{
		FloroRanchUiRoleSkillComponent.<PlayHideAnim>d__4 <PlayHideAnim>d__;
		<PlayHideAnim>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PlayHideAnim>d__.<>4__this = this;
		<PlayHideAnim>d__.<>1__state = -1;
		<PlayHideAnim>d__.<>t__builder.Start<FloroRanchUiRoleSkillComponent.<PlayHideAnim>d__4>(ref <PlayHideAnim>d__);
		return <PlayHideAnim>d__.<>t__builder.Task;
	}

	// Token: 0x0600CFF4 RID: 53236 RVA: 0x0037332C File Offset: 0x0037152C
	public override UniTask PlayNormalAnim()
	{
		FloroRanchUiRoleSkillComponent.<PlayNormalAnim>d__5 <PlayNormalAnim>d__;
		<PlayNormalAnim>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PlayNormalAnim>d__.<>4__this = this;
		<PlayNormalAnim>d__.<>1__state = -1;
		<PlayNormalAnim>d__.<>t__builder.Start<FloroRanchUiRoleSkillComponent.<PlayNormalAnim>d__5>(ref <PlayNormalAnim>d__);
		return <PlayNormalAnim>d__.<>t__builder.Task;
	}

	// Token: 0x0600CFF5 RID: 53237 RVA: 0x00373370 File Offset: 0x00371570
	public override UniTask PlaySkillAnim()
	{
		FloroRanchUiRoleSkillComponent.<PlaySkillAnim>d__6 <PlaySkillAnim>d__;
		<PlaySkillAnim>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PlaySkillAnim>d__.<>4__this = this;
		<PlaySkillAnim>d__.<>1__state = -1;
		<PlaySkillAnim>d__.<>t__builder.Start<FloroRanchUiRoleSkillComponent.<PlaySkillAnim>d__6>(ref <PlaySkillAnim>d__);
		return <PlaySkillAnim>d__.<>t__builder.Task;
	}

	// Token: 0x0600CFF6 RID: 53238 RVA: 0x003733B3 File Offset: 0x003715B3
	public override void Pause()
	{
		if (this.UiRoleSkillItem == null)
		{
			return;
		}
		this.UiRoleSkillItem.Pause();
	}

	// Token: 0x0600CFF7 RID: 53239 RVA: 0x003733C9 File Offset: 0x003715C9
	public override void Resume()
	{
		if (this.UiRoleSkillItem == null)
		{
			return;
		}
		this.UiRoleSkillItem.Resume();
	}

	// Token: 0x040062F2 RID: 25330
	private FloroRanchUiRoleSkillItem UiRoleSkillItem;
}
