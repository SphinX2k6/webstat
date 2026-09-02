using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02006113 RID: 24851
	[NullableContext(1)]
	[Nullable(0)]
	public class GroundSwordStackItem : GridProxyAbstract<ESwordStackState>
	{
		// Token: 0x0603EC58 RID: 257112 RVA: 0x01013144 File Offset: 0x01011344
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603EC59 RID: 257113 RVA: 0x010131CE File Offset: 0x010113CE
		protected override void OnStart()
		{
			this.SequencePlayer = new LevelSequencePlayer(base.GetRootItem());
		}

		// Token: 0x0603EC5A RID: 257114 RVA: 0x010131E1 File Offset: 0x010113E1
		protected override void OnBeforeDestroy()
		{
			this.TransitionToken++;
			LevelSequencePlayer sequencePlayer = this.SequencePlayer;
			if (sequencePlayer != null)
			{
				sequencePlayer.Clear();
			}
			this.SequencePlayer = null;
		}

		// Token: 0x0603EC5B RID: 257115 RVA: 0x0101320C File Offset: 0x0101140C
		public override void Refresh(ESwordStackState data, bool isSelected, int gridIndex)
		{
			if (this.State == data)
			{
				return;
			}
			ESwordStackState state = this.State;
			this.State = data;
			this.PlayTransition(state, data);
		}

		// Token: 0x0603EC5C RID: 257116 RVA: 0x0101323C File Offset: 0x0101143C
		private void PlayTransition(ESwordStackState oldState, ESwordStackState newState)
		{
			int num = this.TransitionToken + 1;
			this.TransitionToken = num;
			int token = num;
			this.PlayTransitionAsync(oldState, newState, token).Forget();
		}

		// Token: 0x0603EC5D RID: 257117 RVA: 0x0101326C File Offset: 0x0101146C
		private UniTask PlayTransitionAsync(ESwordStackState oldState, ESwordStackState newState, int token)
		{
			GroundSwordStackItem.<PlayTransitionAsync>d__13 <PlayTransitionAsync>d__;
			<PlayTransitionAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayTransitionAsync>d__.<>4__this = this;
			<PlayTransitionAsync>d__.oldState = oldState;
			<PlayTransitionAsync>d__.newState = newState;
			<PlayTransitionAsync>d__.token = token;
			<PlayTransitionAsync>d__.<>1__state = -1;
			<PlayTransitionAsync>d__.<>t__builder.Start<GroundSwordStackItem.<PlayTransitionAsync>d__13>(ref <PlayTransitionAsync>d__);
			return <PlayTransitionAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603EC5E RID: 257118 RVA: 0x010132C8 File Offset: 0x010114C8
		[NullableContext(0)]
		private UniTask<bool> PlaySequenceAsync([Nullable(1)] string sequenceName, int token)
		{
			GroundSwordStackItem.<PlaySequenceAsync>d__14 <PlaySequenceAsync>d__;
			<PlaySequenceAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<PlaySequenceAsync>d__.<>4__this = this;
			<PlaySequenceAsync>d__.sequenceName = sequenceName;
			<PlaySequenceAsync>d__.token = token;
			<PlaySequenceAsync>d__.<>1__state = -1;
			<PlaySequenceAsync>d__.<>t__builder.Start<GroundSwordStackItem.<PlaySequenceAsync>d__14>(ref <PlaySequenceAsync>d__);
			return <PlaySequenceAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0402335C RID: 144220
		private const string SequenceFull = "Full";

		// Token: 0x0402335D RID: 144221
		private const string SequencePreUse = "PreUse";

		// Token: 0x0402335E RID: 144222
		private const string SequenceUse = "Use";

		// Token: 0x0402335F RID: 144223
		private const string SequenceUnlock = "Unlock";

		// Token: 0x04023360 RID: 144224
		[Nullable(2)]
		private LevelSequencePlayer SequencePlayer;

		// Token: 0x04023361 RID: 144225
		private ESwordStackState State = ESwordStackState.Lock;

		// Token: 0x04023362 RID: 144226
		private int TransitionToken;

		// Token: 0x0200C299 RID: 49817
		[NullableContext(0)]
		private enum EChildType
		{
			// Token: 0x0403BFE8 RID: 245736
			SprIconNor,
			// Token: 0x0403BFE9 RID: 245737
			PnlLight,
			// Token: 0x0403BFEA RID: 245738
			SprIconLock
		}
	}
}
