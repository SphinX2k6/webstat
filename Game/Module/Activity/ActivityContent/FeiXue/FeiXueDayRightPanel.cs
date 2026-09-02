using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.FeiXue
{
	// Token: 0x02006847 RID: 26695
	public class FeiXueDayRightPanel : UiPanelBase
	{
		// Token: 0x06042893 RID: 272531 RVA: 0x01113DA8 File Offset: 0x01111FA8
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUISprite)),
				new ValueTuple<int, Type>(3, typeof(UUIItem))
			};
		}

		// Token: 0x06042894 RID: 272532 RVA: 0x01113E18 File Offset: 0x01112018
		protected override void OnStart()
		{
			this.LevelSequencePlayer = new LevelSequencePlayer(base.GetRootItem());
		}

		// Token: 0x06042895 RID: 272533 RVA: 0x01113E2C File Offset: 0x0111202C
		public UniTask PlaySearchInSequence()
		{
			FeiXueDayRightPanel.<PlaySearchInSequence>d__3 <PlaySearchInSequence>d__;
			<PlaySearchInSequence>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlaySearchInSequence>d__.<>4__this = this;
			<PlaySearchInSequence>d__.<>1__state = -1;
			<PlaySearchInSequence>d__.<>t__builder.Start<FeiXueDayRightPanel.<PlaySearchInSequence>d__3>(ref <PlaySearchInSequence>d__);
			return <PlaySearchInSequence>d__.<>t__builder.Task;
		}

		// Token: 0x06042896 RID: 272534 RVA: 0x01113E70 File Offset: 0x01112070
		public UniTask PlayDoneSequence()
		{
			FeiXueDayRightPanel.<PlayDoneSequence>d__4 <PlayDoneSequence>d__;
			<PlayDoneSequence>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayDoneSequence>d__.<>4__this = this;
			<PlayDoneSequence>d__.<>1__state = -1;
			<PlayDoneSequence>d__.<>t__builder.Start<FeiXueDayRightPanel.<PlayDoneSequence>d__4>(ref <PlayDoneSequence>d__);
			return <PlayDoneSequence>d__.<>t__builder.Task;
		}

		// Token: 0x06042897 RID: 272535 RVA: 0x01113EB4 File Offset: 0x011120B4
		public UniTask PlaySearchingLoopSequence()
		{
			FeiXueDayRightPanel.<PlaySearchingLoopSequence>d__5 <PlaySearchingLoopSequence>d__;
			<PlaySearchingLoopSequence>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlaySearchingLoopSequence>d__.<>4__this = this;
			<PlaySearchingLoopSequence>d__.<>1__state = -1;
			<PlaySearchingLoopSequence>d__.<>t__builder.Start<FeiXueDayRightPanel.<PlaySearchingLoopSequence>d__5>(ref <PlaySearchingLoopSequence>d__);
			return <PlaySearchingLoopSequence>d__.<>t__builder.Task;
		}

		// Token: 0x06042898 RID: 272536 RVA: 0x01113EF8 File Offset: 0x011120F8
		public void SetPanelItemActive(EFeiXueQuestState state)
		{
			switch (state)
			{
			case EFeiXueQuestState.Lock:
			{
				UUIItem item = base.GetItem(0);
				if (item != null)
				{
					item.SetUIActive(true);
				}
				UUIItem item2 = base.GetItem(1);
				if (item2 != null)
				{
					item2.SetUIActive(false);
				}
				UUISprite sprite = base.GetSprite(2);
				if (sprite != null)
				{
					sprite.SetUIActive(true);
				}
				UUIItem item3 = base.GetItem(3);
				if (item3 == null)
				{
					return;
				}
				item3.SetUIActive(false);
				return;
			}
			case EFeiXueQuestState.IsDoing:
			{
				UUIItem item4 = base.GetItem(0);
				if (item4 != null)
				{
					item4.SetUIActive(true);
				}
				UUIItem item5 = base.GetItem(1);
				if (item5 != null)
				{
					item5.SetUIActive(false);
				}
				UUISprite sprite2 = base.GetSprite(2);
				if (sprite2 != null)
				{
					sprite2.SetUIActive(false);
				}
				UUIItem item6 = base.GetItem(3);
				if (item6 == null)
				{
					return;
				}
				item6.SetUIActive(true);
				return;
			}
			case EFeiXueQuestState.Finish:
			{
				UUIItem item7 = base.GetItem(0);
				if (item7 != null)
				{
					item7.SetUIActive(false);
				}
				UUIItem item8 = base.GetItem(1);
				if (item8 == null)
				{
					return;
				}
				item8.SetUIActive(true);
				return;
			}
			default:
				return;
			}
		}

		// Token: 0x0402508B RID: 151691
		[Nullable(2)]
		private LevelSequencePlayer LevelSequencePlayer;
	}
}
