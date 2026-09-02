using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Roulette.View
{
	// Token: 0x0200501C RID: 20508
	[NullableContext(2)]
	[Nullable(0)]
	public class TrapDefenseRouletteItemTips : UiPanelBase
	{
		// Token: 0x06034DC0 RID: 216512 RVA: 0x00D460E8 File Offset: 0x00D442E8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 1;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int index = 0;
			*span[index] = new ValueTuple<int, Type>(0, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06034DC1 RID: 216513 RVA: 0x00D46130 File Offset: 0x00D44330
		protected override void OnStart()
		{
			this.Sequence = new UiSequencePlayer(this.RootItem);
		}

		// Token: 0x06034DC2 RID: 216514 RVA: 0x00D46144 File Offset: 0x00D44344
		protected override UniTask OnBeforeHideAsync()
		{
			TrapDefenseRouletteItemTips.<OnBeforeHideAsync>d__4 <OnBeforeHideAsync>d__;
			<OnBeforeHideAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeHideAsync>d__.<>4__this = this;
			<OnBeforeHideAsync>d__.<>1__state = -1;
			<OnBeforeHideAsync>d__.<>t__builder.Start<TrapDefenseRouletteItemTips.<OnBeforeHideAsync>d__4>(ref <OnBeforeHideAsync>d__);
			return <OnBeforeHideAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06034DC3 RID: 216515 RVA: 0x00D46187 File Offset: 0x00D44387
		protected override void OnBeforeDestroy()
		{
			this.Sequence.Clear();
		}

		// Token: 0x06034DC4 RID: 216516 RVA: 0x00D46194 File Offset: 0x00D44394
		public void RefreshTips(string tips)
		{
			if (tips != null)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), tips, Array.Empty<object>());
				this.SetActive(true);
				if (this.Tips != null)
				{
					this.Sequence.PlaySequencePurely("UiSwitch", false, false);
				}
				else
				{
					this.Sequence.PlaySequencePurely("UiIn", false, false);
				}
			}
			else
			{
				this.SetActive(false);
			}
			this.Tips = tips;
		}

		// Token: 0x0401E77C RID: 124796
		[Nullable(1)]
		protected UiSequencePlayer Sequence;

		// Token: 0x0401E77D RID: 124797
		protected string Tips;
	}
}
