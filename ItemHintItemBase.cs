using System;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x0200205C RID: 8284
[NullableContext(2)]
[Nullable(0)]
public abstract class ItemHintItemBase<T> : SliderItem
{
	// Token: 0x0600FC73 RID: 64627 RVA: 0x00455535 File Offset: 0x00453735
	public void SetShiftData([Nullable(new byte[]
	{
		1,
		2
	})] Func<T> shiftData)
	{
		this.ShiftData = shiftData;
	}

	// Token: 0x0600FC74 RID: 64628 RVA: 0x00455540 File Offset: 0x00453740
	public override UniTask AsyncLoadUiResource()
	{
		ItemHintItemBase<T>.<AsyncLoadUiResource>d__3 <AsyncLoadUiResource>d__;
		<AsyncLoadUiResource>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<AsyncLoadUiResource>d__.<>4__this = this;
		<AsyncLoadUiResource>d__.<>1__state = -1;
		<AsyncLoadUiResource>d__.<>t__builder.Start<ItemHintItemBase<T>.<AsyncLoadUiResource>d__3>(ref <AsyncLoadUiResource>d__);
		return <AsyncLoadUiResource>d__.<>t__builder.Task;
	}

	// Token: 0x0600FC75 RID: 64629 RVA: 0x00455583 File Offset: 0x00453783
	protected virtual UniTask OnRefresh(T data)
	{
		return UniTask.CompletedTask;
	}

	// Token: 0x04007917 RID: 30999
	protected T Data;

	// Token: 0x04007918 RID: 31000
	protected Func<T> ShiftData;
}
