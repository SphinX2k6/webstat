using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Map.Marks.MarkItem;
using CSharpScript.Game.Module.Map.Marks.MarkItemView.Components;
using CSharpScript.Game.Module.WorldMap;
using UnrealEngine;

namespace CSharpScript.Game.Module.Map.Marks.MarkItemView
{
	// Token: 0x02005882 RID: 22658
	[NullableContext(1)]
	[Nullable(0)]
	public class SheriffQuestMarkItemView : ConfigMarkItemView
	{
		// Token: 0x060399AA RID: 235946 RVA: 0x00E9CD2E File Offset: 0x00E9AF2E
		public SheriffQuestMarkItemView(SheriffQuestMarkItem holder) : base(holder)
		{
		}

		// Token: 0x060399AB RID: 235947 RVA: 0x00E9CD54 File Offset: 0x00E9AF54
		protected override void OnViewRefresh()
		{
			base.OnViewRefresh();
			SheriffQuestMarkItem sheriffQuestMarkItem = (SheriffQuestMarkItem)this.Holder;
			base.MarkItemNameHandle.SetName(new MarkItemParam
			{
				Txt = Singleton<PublicUtil>.Instance.GetConfigTextByKey(ModelBase<QuestNewModel>.Instance.GetQuestConfig(sheriffQuestMarkItem.QuestId).TidName),
				FontSize = new int?(SheriffQuestMarkItemView.FONT_SIZE),
				AnchorOffset = new FVector2D?(this.NameAnchorOffset.ToUeVector2D(false)),
				OutlineSize = new float?((float)2),
				OutlineColor = new FColor?(FColor.FromHex("#292929"))
			});
			if (this.Holder.NeedPlayStartSequence)
			{
				this.Holder.NeedPlayStartSequence = false;
				this.Holder.NeedPlayShowOrHideSeq = null;
				LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
				if (levelSequencePlayer != null)
				{
					levelSequencePlayer.StopCurrentSequence(false, false);
				}
				LevelSequencePlayer levelSequencePlayer2 = this.LevelSequencePlayer;
				if (levelSequencePlayer2 == null)
				{
					return;
				}
				levelSequencePlayer2.PlayLevelSequenceByName("Start", false, null, false);
			}
		}

		// Token: 0x060399AC RID: 235948 RVA: 0x00E9CE4C File Offset: 0x00E9B04C
		protected override void OnSafeUpdate(Vector playerLocation, bool bDragging = false, bool bIsScale = false)
		{
			float num = ModelBase<WorldMapModel>.Instance.MapScale * 100f;
			SheriffQuestMarkItem sheriffQuestMarkItem = (SheriffQuestMarkItem)this.Holder;
			bool visible = num > (float)sheriffQuestMarkItem.TextVisibleScale;
			base.MarkItemNameHandle.SetVisible(visible);
		}

		// Token: 0x04020AD7 RID: 133847
		private static readonly int FONT_SIZE = 36;

		// Token: 0x04020AD8 RID: 133848
		private readonly Vector2D NameAnchorOffset = new Vector2D(0.0, -60.0);
	}
}
