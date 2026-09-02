using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.PhantomArena.Battle.Card;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Battle.Area.Functional
{
	// Token: 0x02005631 RID: 22065
	[NullableContext(1)]
	[Nullable(0)]
	public class PhantomArenaAreaFunctionalItem : PhantomArenaAreaItemBase
	{
		// Token: 0x060383FE RID: 230398 RVA: 0x00E3E4B8 File Offset: 0x00E3C6B8
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUISprite)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIItem))
			};
		}

		// Token: 0x060383FF RID: 230399 RVA: 0x00E3E512 File Offset: 0x00E3C712
		protected override void OnStartImplement()
		{
			this.Sequence = new UiSequencePlayer(this.RootItem);
			this.Sequence.BindOnEndSequenceEvent(new Action<string>(this.OnEndSequenceEvent));
		}

		// Token: 0x06038400 RID: 230400 RVA: 0x00E3E53C File Offset: 0x00E3C73C
		protected override void OnBeforeDestroy()
		{
			this.Sequence.Clear();
		}

		// Token: 0x06038401 RID: 230401 RVA: 0x00E3E549 File Offset: 0x00E3C749
		private void OnEndSequenceEvent(string sequenceName)
		{
			if (sequenceName == "Close".ToString())
			{
				base.GetSprite(0).SetUIActive(false);
			}
		}

		// Token: 0x06038402 RID: 230402 RVA: 0x00E3E56A File Offset: 0x00E3C76A
		public override void Refresh(PhantomArenaCard card)
		{
		}

		// Token: 0x06038403 RID: 230403 RVA: 0x00E3E56C File Offset: 0x00E3C76C
		public override void SetHoverStateActive(bool value)
		{
		}

		// Token: 0x06038404 RID: 230404 RVA: 0x00E3E570 File Offset: 0x00E3C770
		public override void SetCanUseStateActive(bool value)
		{
			this.Sequence.StopPrevSequence(false, true);
			if (value)
			{
				base.GetSprite(0).SetUIActive(true);
				this.Sequence.PlaySequence("Start", false, null);
				return;
			}
			this.Sequence.PlaySequence("Close", false, null);
		}

		// Token: 0x06038405 RID: 230405 RVA: 0x00E3E5D0 File Offset: 0x00E3C7D0
		public UniTask SetIncreaseActive(bool isActive)
		{
			PhantomArenaAreaFunctionalItem.<SetIncreaseActive>d__10 <SetIncreaseActive>d__;
			<SetIncreaseActive>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<SetIncreaseActive>d__.<>4__this = this;
			<SetIncreaseActive>d__.isActive = isActive;
			<SetIncreaseActive>d__.<>1__state = -1;
			<SetIncreaseActive>d__.<>t__builder.Start<PhantomArenaAreaFunctionalItem.<SetIncreaseActive>d__10>(ref <SetIncreaseActive>d__);
			return <SetIncreaseActive>d__.<>t__builder.Task;
		}

		// Token: 0x06038406 RID: 230406 RVA: 0x00E3E61B File Offset: 0x00E3C81B
		public UUIItem GetCardRootItem()
		{
			return base.GetItem(1);
		}

		// Token: 0x040201C7 RID: 131527
		private PhantomArenaCardComponentLogic UseSkill;

		// Token: 0x040201C8 RID: 131528
		protected UiSequencePlayer Sequence;

		// Token: 0x0200B6BD RID: 46781
		[NullableContext(0)]
		private static class EComponentDefine
		{
			// Token: 0x040388A5 RID: 231589
			public const int BgTexture = 0;

			// Token: 0x040388A6 RID: 231590
			public const int CardRootItem = 1;

			// Token: 0x040388A7 RID: 231591
			public const int ContentItem = 2;
		}
	}
}
