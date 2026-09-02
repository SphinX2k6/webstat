using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Map.Mark;
using CSharpScript.Game.Module.Map.Mark.Component;

namespace CSharpScript.Game.Module.Map.Marks.MarkItemView.Handles
{
	// Token: 0x02005899 RID: 22681
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class MarkItemTopRightIconHandle : MarkItemComponentHandle<MarkPanelBase>
	{
		// Token: 0x06039A58 RID: 236120 RVA: 0x00E9E7A7 File Offset: 0x00E9C9A7
		public MarkItemTopRightIconHandle(IMarkItemComponentContext context) : base(context)
		{
		}

		// Token: 0x06039A59 RID: 236121 RVA: 0x00E9E7B0 File Offset: 0x00E9C9B0
		protected override void OnInit()
		{
			this.Context.MarkItemEntity.Resource.TopRightIconPath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("SP_ComIconFinish");
			base.Update();
			base.ApplyModified();
		}

		// Token: 0x06039A5A RID: 236122 RVA: 0x00E9E7E4 File Offset: 0x00E9C9E4
		protected override void OnUpdate()
		{
			MarkItemEntity markItemEntity = this.Context.MarkItemEntity;
			MarkGamePlayComponent gamePlay = markItemEntity.GamePlay;
			bool isDisable = gamePlay.IsDisable;
			string markTopRightIconPath = MarkItemDataUtil.GetMarkTopRightIconPath(gamePlay.MarkId, gamePlay.MarkType, isDisable, !isDisable && gamePlay.IsFinish);
			if (!string.IsNullOrEmpty(markTopRightIconPath))
			{
				base.SetVisible(true);
				markItemEntity.Resource.TopRightIconPath = markTopRightIconPath;
				this.Context.SetSpriteByPathAction(markTopRightIconPath, this.Context.TopRightIconSprite, false, null, null);
				return;
			}
			base.SetVisible(false);
		}

		// Token: 0x06039A5B RID: 236123 RVA: 0x00E9E875 File Offset: 0x00E9CA75
		protected override void OnSetVisible(bool active)
		{
			this.Context.MarkItemEntity.ViewLifeCircle.SetChildViewVisibility(EMarkViewComponentType.TopRightIcon, active);
		}

		// Token: 0x06039A5C RID: 236124 RVA: 0x00E9E890 File Offset: 0x00E9CA90
		protected override void OnApplyModified()
		{
			MarkViewLifeCircleComponent viewLifeCircle = this.Context.MarkItemEntity.ViewLifeCircle;
			if (viewLifeCircle.IsChildViewStateDirty(EMarkViewComponentType.TopRightIcon))
			{
				bool uiactive = viewLifeCircle.IsChildViewVisible(EMarkViewComponentType.TopRightIcon, false);
				viewLifeCircle.SetChildViewVisibleClean(EMarkViewComponentType.TopRightIcon);
				this.Context.TopRightIconSprite.SetUIActive(uiactive);
				Singleton<EventSystem>.Instance.Emit(EEventName.OnMarkTopRightIconUpdate);
			}
		}
	}
}
