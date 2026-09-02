using System;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x020019D3 RID: 6611
public class MediumItemGridProhibitComponent : MediumItemGridVisibleComponent
{
	// Token: 0x0600BDB5 RID: 48565 RVA: 0x00324752 File Offset: 0x00322952
	[NullableContext(1)]
	protected override string GetResourceId()
	{
		return "UiItem_ItemLock";
	}

	// Token: 0x0600BDB6 RID: 48566 RVA: 0x0032475C File Offset: 0x0032295C
	public UniTask PlayUnlockAnim()
	{
		MediumItemGridProhibitComponent.<PlayUnlockAnim>d__1 <PlayUnlockAnim>d__;
		<PlayUnlockAnim>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PlayUnlockAnim>d__.<>4__this = this;
		<PlayUnlockAnim>d__.<>1__state = -1;
		<PlayUnlockAnim>d__.<>t__builder.Start<MediumItemGridProhibitComponent.<PlayUnlockAnim>d__1>(ref <PlayUnlockAnim>d__);
		return <PlayUnlockAnim>d__.<>t__builder.Task;
	}
}
