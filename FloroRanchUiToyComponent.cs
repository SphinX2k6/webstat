using System;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x02001BED RID: 7149
[NullableContext(2)]
[Nullable(0)]
[FloroRanchEntityComponent(EFloroRanchEntityComponent.FloroRanchUiToyComponent)]
public class FloroRanchUiToyComponent : FloroRanchUiItemBaseComponent
{
	// Token: 0x0600CFFF RID: 53247 RVA: 0x00373554 File Offset: 0x00371754
	[return: Nullable(new byte[]
	{
		0,
		2
	})]
	public override UniTask<FloroRanchUiItemBase> PlayShowAnim()
	{
		FloroRanchUiToyComponent.<PlayShowAnim>d__1 <PlayShowAnim>d__;
		<PlayShowAnim>d__.<>t__builder = AsyncUniTaskMethodBuilder<FloroRanchUiItemBase>.Create();
		<PlayShowAnim>d__.<>4__this = this;
		<PlayShowAnim>d__.<>1__state = -1;
		<PlayShowAnim>d__.<>t__builder.Start<FloroRanchUiToyComponent.<PlayShowAnim>d__1>(ref <PlayShowAnim>d__);
		return <PlayShowAnim>d__.<>t__builder.Task;
	}

	// Token: 0x0600D000 RID: 53248 RVA: 0x00373598 File Offset: 0x00371798
	[return: Nullable(new byte[]
	{
		0,
		2
	})]
	public override UniTask<FloroRanchUiItemBase> CreateUiItem()
	{
		FloroRanchUiToyComponent.<CreateUiItem>d__2 <CreateUiItem>d__;
		<CreateUiItem>d__.<>t__builder = AsyncUniTaskMethodBuilder<FloroRanchUiItemBase>.Create();
		<CreateUiItem>d__.<>4__this = this;
		<CreateUiItem>d__.<>1__state = -1;
		<CreateUiItem>d__.<>t__builder.Start<FloroRanchUiToyComponent.<CreateUiItem>d__2>(ref <CreateUiItem>d__);
		return <CreateUiItem>d__.<>t__builder.Task;
	}

	// Token: 0x0600D001 RID: 53249 RVA: 0x003735DC File Offset: 0x003717DC
	public override UniTask PlayHideAnim()
	{
		FloroRanchUiToyComponent.<PlayHideAnim>d__3 <PlayHideAnim>d__;
		<PlayHideAnim>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PlayHideAnim>d__.<>4__this = this;
		<PlayHideAnim>d__.<>1__state = -1;
		<PlayHideAnim>d__.<>t__builder.Start<FloroRanchUiToyComponent.<PlayHideAnim>d__3>(ref <PlayHideAnim>d__);
		return <PlayHideAnim>d__.<>t__builder.Task;
	}

	// Token: 0x0600D002 RID: 53250 RVA: 0x00373620 File Offset: 0x00371820
	public override UniTask PlayNormalAnim()
	{
		FloroRanchUiToyComponent.<PlayNormalAnim>d__4 <PlayNormalAnim>d__;
		<PlayNormalAnim>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PlayNormalAnim>d__.<>4__this = this;
		<PlayNormalAnim>d__.<>1__state = -1;
		<PlayNormalAnim>d__.<>t__builder.Start<FloroRanchUiToyComponent.<PlayNormalAnim>d__4>(ref <PlayNormalAnim>d__);
		return <PlayNormalAnim>d__.<>t__builder.Task;
	}

	// Token: 0x0600D003 RID: 53251 RVA: 0x00373664 File Offset: 0x00371864
	public UniTask PlayToyLevelUpAnim()
	{
		FloroRanchUiToyComponent.<PlayToyLevelUpAnim>d__5 <PlayToyLevelUpAnim>d__;
		<PlayToyLevelUpAnim>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PlayToyLevelUpAnim>d__.<>4__this = this;
		<PlayToyLevelUpAnim>d__.<>1__state = -1;
		<PlayToyLevelUpAnim>d__.<>t__builder.Start<FloroRanchUiToyComponent.<PlayToyLevelUpAnim>d__5>(ref <PlayToyLevelUpAnim>d__);
		return <PlayToyLevelUpAnim>d__.<>t__builder.Task;
	}

	// Token: 0x0600D004 RID: 53252 RVA: 0x003736A8 File Offset: 0x003718A8
	[PreserveBaseOverrides]
	public new virtual FloroRanchUiToyItem GetUiItem()
	{
		if (this._floroRanchUiToyItem == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.FloroRanchGamePlay;
			ELogAuthor author = ELogAuthor.LRC;
			string message = "FloroRanchUiToyComponent GetUiItem 实体不存在";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("entityId", this.OwnerEntity.EntityId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}
		return this._floroRanchUiToyItem;
	}

	// Token: 0x040062F4 RID: 25332
	private FloroRanchUiToyItem _floroRanchUiToyItem;
}
