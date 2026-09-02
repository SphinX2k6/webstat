using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.SlidingBlocks.View.Mission
{
	// Token: 0x02004F19 RID: 20249
	[NullableContext(1)]
	[Nullable(0)]
	public class ParentStepItem : UiPanelBase
	{
		// Token: 0x06034552 RID: 214354 RVA: 0x00D18C14 File Offset: 0x00D16E14
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06034553 RID: 214355 RVA: 0x00D18CC0 File Offset: 0x00D16EC0
		protected override UniTask OnBeforeStartAsync()
		{
			ParentStepItem.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<ParentStepItem.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06034554 RID: 214356 RVA: 0x00D18D04 File Offset: 0x00D16F04
		public void OnTick(float delta)
		{
			foreach (ChildStepItem childStepItem in this.ChildSteps)
			{
				childStepItem.OnTick(delta);
			}
		}

		// Token: 0x06034555 RID: 214357 RVA: 0x00D18D58 File Offset: 0x00D16F58
		private UniTask SetShowInfoOnNormalMode(SlidingBlocksGameServerData serverData)
		{
			ParentStepItem.<SetShowInfoOnNormalMode>d__6 <SetShowInfoOnNormalMode>d__;
			<SetShowInfoOnNormalMode>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<SetShowInfoOnNormalMode>d__.<>4__this = this;
			<SetShowInfoOnNormalMode>d__.serverData = serverData;
			<SetShowInfoOnNormalMode>d__.<>1__state = -1;
			<SetShowInfoOnNormalMode>d__.<>t__builder.Start<ParentStepItem.<SetShowInfoOnNormalMode>d__6>(ref <SetShowInfoOnNormalMode>d__);
			return <SetShowInfoOnNormalMode>d__.<>t__builder.Task;
		}

		// Token: 0x06034556 RID: 214358 RVA: 0x00D18DA4 File Offset: 0x00D16FA4
		private UniTask SetShowInfoOnEndlessMode(SlidingBlocksGameData gameData, SlidingBlocksGameServerData serverData)
		{
			ParentStepItem.<SetShowInfoOnEndlessMode>d__7 <SetShowInfoOnEndlessMode>d__;
			<SetShowInfoOnEndlessMode>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<SetShowInfoOnEndlessMode>d__.<>4__this = this;
			<SetShowInfoOnEndlessMode>d__.gameData = gameData;
			<SetShowInfoOnEndlessMode>d__.serverData = serverData;
			<SetShowInfoOnEndlessMode>d__.<>1__state = -1;
			<SetShowInfoOnEndlessMode>d__.<>t__builder.Start<ParentStepItem.<SetShowInfoOnEndlessMode>d__7>(ref <SetShowInfoOnEndlessMode>d__);
			return <SetShowInfoOnEndlessMode>d__.<>t__builder.Task;
		}

		// Token: 0x0401E2F2 RID: 123634
		[Nullable(2)]
		protected LevelSequencePlayer TitleSequencePlayer;

		// Token: 0x0401E2F3 RID: 123635
		private readonly List<ChildStepItem> ChildSteps = new List<ChildStepItem>();

		// Token: 0x0200AF5E RID: 44894
		[NullableContext(0)]
		private enum EChildComponent
		{
			// Token: 0x040366C4 RID: 222916
			StepDescribeText,
			// Token: 0x040366C5 RID: 222917
			StepDistanceText,
			// Token: 0x040366C6 RID: 222918
			ChildStep,
			// Token: 0x040366C7 RID: 222919
			TitleNode
		}
	}
}
