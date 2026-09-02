using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.PhantomArena.Battle.Area.Functional;
using CSharpScript.Game.Module.PhantomArena.Battle.Card;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Battle.Opponent
{
	// Token: 0x020055F7 RID: 22007
	[NullableContext(1)]
	[Nullable(0)]
	public class OpponentMonsterProxy : OpponentFunctionAreaProxy
	{
		// Token: 0x17009002 RID: 36866
		// (get) Token: 0x06038123 RID: 229667 RVA: 0x00E345D3 File Offset: 0x00E327D3
		// (set) Token: 0x06038124 RID: 229668 RVA: 0x00E345E0 File Offset: 0x00E327E0
		public new PhantomArenaAreaMonsterItem AreaItem
		{
			get
			{
				return base.AreaItem as PhantomArenaAreaMonsterItem;
			}
			set
			{
				base.AreaItem = value;
			}
		}

		// Token: 0x17009003 RID: 36867
		// (get) Token: 0x06038125 RID: 229669 RVA: 0x00E345E9 File Offset: 0x00E327E9
		public override bool IsMonster
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17009004 RID: 36868
		// (get) Token: 0x06038126 RID: 229670 RVA: 0x00E345EC File Offset: 0x00E327EC
		public override bool IsNeedPreload
		{
			get
			{
				return this.Card != null && this.Card.Data.IsNormal;
			}
		}

		// Token: 0x06038127 RID: 229671 RVA: 0x00E34608 File Offset: 0x00E32808
		public OpponentMonsterProxy(int index, OpponentFunctionArea area) : base(index, area)
		{
		}

		// Token: 0x06038128 RID: 229672 RVA: 0x00E34612 File Offset: 0x00E32812
		protected override UUIItem GetCardAttachItem()
		{
			return this.AreaItem.GetCardRootItem();
		}

		// Token: 0x06038129 RID: 229673 RVA: 0x00E34620 File Offset: 0x00E32820
		public UniTask EvolveCard(int cardId)
		{
			OpponentMonsterProxy.<EvolveCard>d__9 <EvolveCard>d__;
			<EvolveCard>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<EvolveCard>d__.<>4__this = this;
			<EvolveCard>d__.cardId = cardId;
			<EvolveCard>d__.<>1__state = -1;
			<EvolveCard>d__.<>t__builder.Start<OpponentMonsterProxy.<EvolveCard>d__9>(ref <EvolveCard>d__);
			return <EvolveCard>d__.<>t__builder.Task;
		}

		// Token: 0x0603812A RID: 229674 RVA: 0x00E3466C File Offset: 0x00E3286C
		public UniTask CopyCard(int cardId)
		{
			OpponentMonsterProxy.<CopyCard>d__10 <CopyCard>d__;
			<CopyCard>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CopyCard>d__.<>4__this = this;
			<CopyCard>d__.cardId = cardId;
			<CopyCard>d__.<>1__state = -1;
			<CopyCard>d__.<>t__builder.Start<OpponentMonsterProxy.<CopyCard>d__10>(ref <CopyCard>d__);
			return <CopyCard>d__.<>t__builder.Task;
		}

		// Token: 0x0603812B RID: 229675 RVA: 0x00E346B8 File Offset: 0x00E328B8
		private UniTask DestroyLastCard(PhantomArenaCard lastCard)
		{
			OpponentMonsterProxy.<DestroyLastCard>d__11 <DestroyLastCard>d__;
			<DestroyLastCard>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<DestroyLastCard>d__.lastCard = lastCard;
			<DestroyLastCard>d__.<>1__state = -1;
			<DestroyLastCard>d__.<>t__builder.Start<OpponentMonsterProxy.<DestroyLastCard>d__11>(ref <DestroyLastCard>d__);
			return <DestroyLastCard>d__.<>t__builder.Task;
		}
	}
}
