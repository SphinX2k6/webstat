using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001B25 RID: 6949
[NullableContext(1)]
[Nullable(0)]
public class DeadEyeAimItem : UiPanelBase
{
	// Token: 0x0600C82F RID: 51247 RVA: 0x0034FB3C File Offset: 0x0034DD3C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 1;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int index = 0;
		*span[index] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600C830 RID: 51248 RVA: 0x0034FB84 File Offset: 0x0034DD84
	protected override void OnStart()
	{
		UUIItem item = base.GetItem(0);
		item.SetUIActive(true);
		this.Size.Set((double)item.Width, (double)item.Height);
		this.SequencePlayer = new LevelSequencePlayer(this.RootItem);
		this.SequencePlayer.BindSequenceCloseEvent(new TSequenceEndEvent(this.OnSequenceClose), false);
	}

	// Token: 0x0600C831 RID: 51249 RVA: 0x0034FBE4 File Offset: 0x0034DDE4
	protected override void OnAfterShow()
	{
		LevelSequencePlayer sequencePlayer = this.SequencePlayer;
		if (sequencePlayer == null)
		{
			return;
		}
		sequencePlayer.PlayLevelSequenceByName("Start", false, null, false);
	}

	// Token: 0x0600C832 RID: 51250 RVA: 0x0034FC14 File Offset: 0x0034DE14
	protected override UniTask OnBeforeHideAsync()
	{
		DeadEyeAimItem.<OnBeforeHideAsync>d__6 <OnBeforeHideAsync>d__;
		<OnBeforeHideAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeHideAsync>d__.<>4__this = this;
		<OnBeforeHideAsync>d__.<>1__state = -1;
		<OnBeforeHideAsync>d__.<>t__builder.Start<DeadEyeAimItem.<OnBeforeHideAsync>d__6>(ref <OnBeforeHideAsync>d__);
		return <OnBeforeHideAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600C833 RID: 51251 RVA: 0x0034FC57 File Offset: 0x0034DE57
	public Vector2D GetAimRange()
	{
		return this.Size;
	}

	// Token: 0x0600C834 RID: 51252 RVA: 0x0034FC60 File Offset: 0x0034DE60
	private void OnSequenceClose(string sequenceName)
	{
		if (sequenceName == "Start")
		{
			ModelBase<DeadEyeModeModel>.Instance.ViewStartSequenceFinish = true;
			Singleton<Log>.Instance.Info(ELogModule.DeadEye, ELogAuthor.YSQ, "死眼玩法：播放AimItem动画完成", default(ReadOnlySpan<ValueTuple<string, object>>));
		}
	}

	// Token: 0x04006019 RID: 24601
	private readonly Vector2D Size = Vector2D.Create();

	// Token: 0x0400601A RID: 24602
	[Nullable(2)]
	private LevelSequencePlayer SequencePlayer;

	// Token: 0x02007DFF RID: 32255
	[NullableContext(0)]
	private class EViewComponent
	{
		// Token: 0x0402AE99 RID: 175769
		public const int NormalItem = 0;
	}
}
