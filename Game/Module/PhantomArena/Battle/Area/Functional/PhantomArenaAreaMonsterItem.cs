using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.PhantomArena.Battle.Card;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Battle.Area.Functional
{
	// Token: 0x02005634 RID: 22068
	[NullableContext(1)]
	[Nullable(0)]
	public class PhantomArenaAreaMonsterItem : PhantomArenaAreaItemBase
	{
		// Token: 0x06038423 RID: 230435 RVA: 0x00E3EAB4 File Offset: 0x00E3CCB4
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIItem))
			};
		}

		// Token: 0x06038424 RID: 230436 RVA: 0x00E3EB24 File Offset: 0x00E3CD24
		public override void Refresh(PhantomArenaCard card)
		{
		}

		// Token: 0x06038425 RID: 230437 RVA: 0x00E3EB26 File Offset: 0x00E3CD26
		public override void SetHoverStateActive(bool value)
		{
			base.GetItem(2).SetUIActive(value);
		}

		// Token: 0x06038426 RID: 230438 RVA: 0x00E3EB35 File Offset: 0x00E3CD35
		public override void SetCanUseStateActive(bool value)
		{
			base.GetItem(0).SetUIActive(value);
		}

		// Token: 0x06038427 RID: 230439 RVA: 0x00E3EB44 File Offset: 0x00E3CD44
		public UUIItem GetCardRootItem()
		{
			return base.GetItem(1);
		}

		// Token: 0x06038428 RID: 230440 RVA: 0x00E3EB50 File Offset: 0x00E3CD50
		public UniTask SetBuffUpActive(bool isActive)
		{
			PhantomArenaAreaMonsterItem.<SetBuffUpActive>d__10 <SetBuffUpActive>d__;
			<SetBuffUpActive>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<SetBuffUpActive>d__.<>4__this = this;
			<SetBuffUpActive>d__.isActive = isActive;
			<SetBuffUpActive>d__.<>1__state = -1;
			<SetBuffUpActive>d__.<>t__builder.Start<PhantomArenaAreaMonsterItem.<SetBuffUpActive>d__10>(ref <SetBuffUpActive>d__);
			return <SetBuffUpActive>d__.<>t__builder.Task;
		}

		// Token: 0x06038429 RID: 230441 RVA: 0x00E3EB9C File Offset: 0x00E3CD9C
		public UniTask SetBuffDownActive(bool isActive)
		{
			PhantomArenaAreaMonsterItem.<SetBuffDownActive>d__11 <SetBuffDownActive>d__;
			<SetBuffDownActive>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<SetBuffDownActive>d__.<>4__this = this;
			<SetBuffDownActive>d__.isActive = isActive;
			<SetBuffDownActive>d__.<>1__state = -1;
			<SetBuffDownActive>d__.<>t__builder.Start<PhantomArenaAreaMonsterItem.<SetBuffDownActive>d__11>(ref <SetBuffDownActive>d__);
			return <SetBuffDownActive>d__.<>t__builder.Task;
		}

		// Token: 0x0603842A RID: 230442 RVA: 0x00E3EBE8 File Offset: 0x00E3CDE8
		public UniTask SetEvolveActive(bool isActive)
		{
			PhantomArenaAreaMonsterItem.<SetEvolveActive>d__12 <SetEvolveActive>d__;
			<SetEvolveActive>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<SetEvolveActive>d__.<>4__this = this;
			<SetEvolveActive>d__.isActive = isActive;
			<SetEvolveActive>d__.<>1__state = -1;
			<SetEvolveActive>d__.<>t__builder.Start<PhantomArenaAreaMonsterItem.<SetEvolveActive>d__12>(ref <SetEvolveActive>d__);
			return <SetEvolveActive>d__.<>t__builder.Task;
		}

		// Token: 0x0603842B RID: 230443 RVA: 0x00E3EC34 File Offset: 0x00E3CE34
		public UniTask SetIncreaseActive(bool isActive)
		{
			PhantomArenaAreaMonsterItem.<SetIncreaseActive>d__13 <SetIncreaseActive>d__;
			<SetIncreaseActive>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<SetIncreaseActive>d__.<>4__this = this;
			<SetIncreaseActive>d__.isActive = isActive;
			<SetIncreaseActive>d__.<>1__state = -1;
			<SetIncreaseActive>d__.<>t__builder.Start<PhantomArenaAreaMonsterItem.<SetIncreaseActive>d__13>(ref <SetIncreaseActive>d__);
			return <SetIncreaseActive>d__.<>t__builder.Task;
		}

		// Token: 0x040201CC RID: 131532
		private PhantomArenaCardComponentLogic UseSkill;

		// Token: 0x040201CD RID: 131533
		private PhantomArenaCardComponentLogic BuffUp;

		// Token: 0x040201CE RID: 131534
		private PhantomArenaCardComponentLogic BuffDown;

		// Token: 0x040201CF RID: 131535
		private PhantomArenaCardComponentLogic Evolve;

		// Token: 0x0200B6C2 RID: 46786
		[NullableContext(0)]
		private static class EComponentDefine
		{
			// Token: 0x040388BC RID: 231612
			public const int UseItem = 0;

			// Token: 0x040388BD RID: 231613
			public const int CardRootItem = 1;

			// Token: 0x040388BE RID: 231614
			public const int BgTexture = 2;

			// Token: 0x040388BF RID: 231615
			public const int ContentItem = 3;
		}
	}
}
