using System;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x02001BE0 RID: 7136
[FloroRanchEntityComponent(EFloroRanchEntityComponent.FloroRanchEmptyUiComponent)]
public class FloroRanchEmptyUiComponent : FloroRanchUiItemBaseComponent
{
	// Token: 0x0600CF90 RID: 53136 RVA: 0x00372184 File Offset: 0x00370384
	[NullableContext(2)]
	public override FloroRanchUiItemBase GetUiItem()
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.FloroRanchGamePlay;
		ELogAuthor author = ELogAuthor.LRC;
		string message = "FloroRanchEmptyUiComponent GetUiItem 实体不存在";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("entityId", this.OwnerEntity.EntityId);
		instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		return null;
	}

	// Token: 0x0600CF91 RID: 53137 RVA: 0x003721CC File Offset: 0x003703CC
	[return: Nullable(new byte[]
	{
		0,
		2
	})]
	public override UniTask<FloroRanchUiItemBase> PlayShowAnim()
	{
		FloroRanchEmptyUiComponent.<PlayShowAnim>d__1 <PlayShowAnim>d__;
		<PlayShowAnim>d__.<>t__builder = AsyncUniTaskMethodBuilder<FloroRanchUiItemBase>.Create();
		<PlayShowAnim>d__.<>1__state = -1;
		<PlayShowAnim>d__.<>t__builder.Start<FloroRanchEmptyUiComponent.<PlayShowAnim>d__1>(ref <PlayShowAnim>d__);
		return <PlayShowAnim>d__.<>t__builder.Task;
	}

	// Token: 0x0600CF92 RID: 53138 RVA: 0x00372208 File Offset: 0x00370408
	[return: Nullable(new byte[]
	{
		0,
		2
	})]
	public override UniTask<FloroRanchUiItemBase> CreateUiItem()
	{
		FloroRanchEmptyUiComponent.<CreateUiItem>d__2 <CreateUiItem>d__;
		<CreateUiItem>d__.<>t__builder = AsyncUniTaskMethodBuilder<FloroRanchUiItemBase>.Create();
		<CreateUiItem>d__.<>1__state = -1;
		<CreateUiItem>d__.<>t__builder.Start<FloroRanchEmptyUiComponent.<CreateUiItem>d__2>(ref <CreateUiItem>d__);
		return <CreateUiItem>d__.<>t__builder.Task;
	}

	// Token: 0x0600CF93 RID: 53139 RVA: 0x00372244 File Offset: 0x00370444
	public override UniTask PlayHideAnim()
	{
		FloroRanchEmptyUiComponent.<PlayHideAnim>d__3 <PlayHideAnim>d__;
		<PlayHideAnim>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PlayHideAnim>d__.<>1__state = -1;
		<PlayHideAnim>d__.<>t__builder.Start<FloroRanchEmptyUiComponent.<PlayHideAnim>d__3>(ref <PlayHideAnim>d__);
		return <PlayHideAnim>d__.<>t__builder.Task;
	}

	// Token: 0x0600CF94 RID: 53140 RVA: 0x00372280 File Offset: 0x00370480
	public override UniTask PlayNormalAnim()
	{
		FloroRanchEmptyUiComponent.<PlayNormalAnim>d__4 <PlayNormalAnim>d__;
		<PlayNormalAnim>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PlayNormalAnim>d__.<>1__state = -1;
		<PlayNormalAnim>d__.<>t__builder.Start<FloroRanchEmptyUiComponent.<PlayNormalAnim>d__4>(ref <PlayNormalAnim>d__);
		return <PlayNormalAnim>d__.<>t__builder.Task;
	}

	// Token: 0x0600CF95 RID: 53141 RVA: 0x003722BC File Offset: 0x003704BC
	public override UniTask ShowUiItem()
	{
		FloroRanchEmptyUiComponent.<ShowUiItem>d__5 <ShowUiItem>d__;
		<ShowUiItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<ShowUiItem>d__.<>1__state = -1;
		<ShowUiItem>d__.<>t__builder.Start<FloroRanchEmptyUiComponent.<ShowUiItem>d__5>(ref <ShowUiItem>d__);
		return <ShowUiItem>d__.<>t__builder.Task;
	}

	// Token: 0x0600CF96 RID: 53142 RVA: 0x003722F8 File Offset: 0x003704F8
	public override UniTask HideUiItem()
	{
		FloroRanchEmptyUiComponent.<HideUiItem>d__6 <HideUiItem>d__;
		<HideUiItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<HideUiItem>d__.<>1__state = -1;
		<HideUiItem>d__.<>t__builder.Start<FloroRanchEmptyUiComponent.<HideUiItem>d__6>(ref <HideUiItem>d__);
		return <HideUiItem>d__.<>t__builder.Task;
	}
}
