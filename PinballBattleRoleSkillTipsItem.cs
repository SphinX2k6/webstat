using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001D6F RID: 7535
internal class PinballBattleRoleSkillTipsItem : GridProxyAbstract<int>
{
	// Token: 0x0600DDA3 RID: 56739 RVA: 0x003B98BC File Offset: 0x003B7ABC
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600DDA4 RID: 56740 RVA: 0x003B9928 File Offset: 0x003B7B28
	protected override void OnStart()
	{
		this.SeqPlayer = new LevelSequencePlayer(this.RootItem);
		this.SeqPlayer.PlayLevelSequenceByName("Start", false, null, false);
	}

	// Token: 0x0600DDA5 RID: 56741 RVA: 0x003B9961 File Offset: 0x003B7B61
	protected override void OnBeforeDestroy()
	{
		LevelSequencePlayer seqPlayer = this.SeqPlayer;
		if (seqPlayer == null)
		{
			return;
		}
		seqPlayer.Clear();
	}

	// Token: 0x0600DDA6 RID: 56742 RVA: 0x003B9974 File Offset: 0x003B7B74
	public UniTask PlayCloseSequence()
	{
		PinballBattleRoleSkillTipsItem.<PlayCloseSequence>d__4 <PlayCloseSequence>d__;
		<PlayCloseSequence>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PlayCloseSequence>d__.<>4__this = this;
		<PlayCloseSequence>d__.<>1__state = -1;
		<PlayCloseSequence>d__.<>t__builder.Start<PinballBattleRoleSkillTipsItem.<PlayCloseSequence>d__4>(ref <PlayCloseSequence>d__);
		return <PlayCloseSequence>d__.<>t__builder.Task;
	}

	// Token: 0x0600DDA7 RID: 56743 RVA: 0x003B99B8 File Offset: 0x003B7BB8
	public override void Refresh(int data, bool isSelected, int gridIndex)
	{
		PinballRoleConfig value = ConfigBase<PinballConfig>.Instance.GetPinballRoleConfigById(data).Value;
		base.SetTextureShowUntilLoaded(value.RoleSkillReleaseIcon, base.GetTexture(0), null);
		UUIText text = base.GetText(1);
		if (text == null)
		{
			return;
		}
		text.ShowTextNew(value.RoleSkillReleaseDesc);
	}

	// Token: 0x04006A6D RID: 27245
	[Nullable(2)]
	private LevelSequencePlayer SeqPlayer;
}
