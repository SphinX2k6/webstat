using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200257E RID: 9598
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
public class TipsChatItem : SyncGridProxyAbstract<PhoneMsgChatData>
{
	// Token: 0x06012AA4 RID: 76452 RVA: 0x00525694 File Offset: 0x00523894
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIText))
		};
	}

	// Token: 0x06012AA5 RID: 76453 RVA: 0x005256F0 File Offset: 0x005238F0
	protected override void OnStart()
	{
		this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
		UUIText text = base.GetText(1);
		UUIText text2 = base.GetText(2);
		text.bGameRichText = true;
		text.richText = true;
		text2.bGameRichText = true;
		text2.richText = true;
	}

	// Token: 0x06012AA6 RID: 76454 RVA: 0x00525738 File Offset: 0x00523938
	[NullableContext(1)]
	public override void Refresh(PhoneMsgChatData data)
	{
		this.PhoneMsgChatData = data;
		bool flag = true;
		base.GetItem(0).SetUIActive(flag);
		base.GetText(1).SetUIActive(flag);
		base.GetText(2).SetUIActive(!flag);
		if (flag)
		{
			base.GetText(1).SetText(this.PhoneMsgChatData.ContentStr, true);
			return;
		}
		base.GetText(2).SetText(this.PhoneMsgChatData.ContentStr, true);
	}

	// Token: 0x06012AA7 RID: 76455 RVA: 0x005257AC File Offset: 0x005239AC
	public UniTask PlayTipsAnimationAsync()
	{
		TipsChatItem.<PlayTipsAnimationAsync>d__6 <PlayTipsAnimationAsync>d__;
		<PlayTipsAnimationAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PlayTipsAnimationAsync>d__.<>4__this = this;
		<PlayTipsAnimationAsync>d__.<>1__state = -1;
		<PlayTipsAnimationAsync>d__.<>t__builder.Start<TipsChatItem.<PlayTipsAnimationAsync>d__6>(ref <PlayTipsAnimationAsync>d__);
		return <PlayTipsAnimationAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06012AA8 RID: 76456 RVA: 0x005257EF File Offset: 0x005239EF
	public void StopTipsAnimation()
	{
		this.LevelSequencePlayer.StopSequenceByKey("In", false, true);
	}

	// Token: 0x040091D7 RID: 37335
	private PhoneMsgChatData PhoneMsgChatData;

	// Token: 0x040091D8 RID: 37336
	private LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x02008899 RID: 34969
	[NullableContext(0)]
	private enum EItemTipsComponent
	{
		// Token: 0x0402E227 RID: 188967
		PnlWarn,
		// Token: 0x0402E228 RID: 188968
		TxtWarn,
		// Token: 0x0402E229 RID: 188969
		TxtTips
	}
}
