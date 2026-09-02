using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.PhantomArena.Battle.Area.Functional;
using CSharpScript.Game.Module.PhantomArena.Battle.Model;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Battle.Opponent
{
	// Token: 0x020055F2 RID: 22002
	[NullableContext(1)]
	[Nullable(0)]
	public class OpponentFunctionalProxy : OpponentFunctionAreaProxy
	{
		// Token: 0x17008FFC RID: 36860
		// (get) Token: 0x060380CC RID: 229580 RVA: 0x00E33042 File Offset: 0x00E31242
		// (set) Token: 0x060380CD RID: 229581 RVA: 0x00E3304F File Offset: 0x00E3124F
		public new PhantomArenaAreaFunctionalItem AreaItem
		{
			get
			{
				return base.AreaItem as PhantomArenaAreaFunctionalItem;
			}
			set
			{
				base.AreaItem = value;
			}
		}

		// Token: 0x17008FFD RID: 36861
		// (get) Token: 0x060380CE RID: 229582 RVA: 0x00E33058 File Offset: 0x00E31258
		public override bool IsMonster
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17008FFE RID: 36862
		// (get) Token: 0x060380CF RID: 229583 RVA: 0x00E3305B File Offset: 0x00E3125B
		public override bool IsNeedPreload
		{
			get
			{
				return false;
			}
		}

		// Token: 0x060380D0 RID: 229584 RVA: 0x00E3305E File Offset: 0x00E3125E
		public OpponentFunctionalProxy(int index, OpponentFunctionArea area) : base(index, area)
		{
		}

		// Token: 0x060380D1 RID: 229585 RVA: 0x00E33068 File Offset: 0x00E31268
		protected override UUIItem GetCardAttachItem()
		{
			return this.AreaItem.GetRootItem();
		}

		// Token: 0x060380D2 RID: 229586 RVA: 0x00E33078 File Offset: 0x00E31278
		public UniTask UseCardSkill(PhantomCardData cardData)
		{
			OpponentFunctionalProxy.<UseCardSkill>d__9 <UseCardSkill>d__;
			<UseCardSkill>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<UseCardSkill>d__.<>4__this = this;
			<UseCardSkill>d__.cardData = cardData;
			<UseCardSkill>d__.<>1__state = -1;
			<UseCardSkill>d__.<>t__builder.Start<OpponentFunctionalProxy.<UseCardSkill>d__9>(ref <UseCardSkill>d__);
			return <UseCardSkill>d__.<>t__builder.Task;
		}
	}
}
