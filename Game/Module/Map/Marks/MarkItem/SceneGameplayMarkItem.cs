using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.Map.Mark;
using CSharpScript.Game.Module.Map.Marks.MarkItemView;
using CSharpScript.Game.Module.WorldMap;
using UnrealEngine;

namespace CSharpScript.Game.Module.Map.Marks.MarkItem
{
	// Token: 0x02005854 RID: 22612
	[NullableContext(1)]
	[Nullable(0)]
	public class SceneGameplayMarkItem : ConfigMarkItem
	{
		// Token: 0x06039827 RID: 235559 RVA: 0x00E97D7A File Offset: 0x00E95F7A
		public SceneGameplayMarkItem(int markId, MapMark markConfig, UUIItem parent, EMapType mapType, float markScale, ETrackSource? trackSource = null) : base(markId, markConfig, parent, mapType, markScale, trackSource)
		{
		}

		// Token: 0x06039828 RID: 235560 RVA: 0x00E97D8B File Offset: 0x00E95F8B
		protected override EMarkItemViewType GetMarkItemViewType()
		{
			return EMarkItemViewType.SceneGameplayMarkItemView;
		}

		// Token: 0x06039829 RID: 235561 RVA: 0x00E97D8F File Offset: 0x00E95F8F
		protected override MarkItemView CreateView()
		{
			return new SceneGameplayMarkItemView(this);
		}

		// Token: 0x0603982A RID: 235562 RVA: 0x00E97D98 File Offset: 0x00E95F98
		public override bool CheckCanShowView()
		{
			LevelPlayInfo levelPlayInfo = ModelBase<LevelPlayModel>.Instance.GetLevelPlayInfo(this.MarkConfig.Value.RelativeId);
			return levelPlayInfo != null && !levelPlayInfo.IsClose && base.CheckCanShowView();
		}

		// Token: 0x0603982B RID: 235563 RVA: 0x00E97DD8 File Offset: 0x00E95FD8
		protected override void InitIcon()
		{
			LevelPlayInfo levelPlayInfo = ModelBase<LevelPlayModel>.Instance.GetLevelPlayInfo(this.MarkConfig.Value.RelativeId);
			if (levelPlayInfo == null || levelPlayInfo.IsClose)
			{
				this.IconPath = this.MarkConfig.Value.LockMarkPic;
			}
			this.IconPath = this.MarkConfig.Value.UnlockMarkPic;
		}

		// Token: 0x0603982C RID: 235564 RVA: 0x00E97E40 File Offset: 0x00E96040
		public override ESecondaryPanel GetSecondaryUiType()
		{
			if (this.MarkType == EMarkType.CorniceMeeting)
			{
				return ESecondaryPanel.CorniceMeetingPanel;
			}
			if (base.IsLordGym() || base.IsNewLordGym())
			{
				return ESecondaryPanel.LordGymPanel;
			}
			return ESecondaryPanel.SceneGameplayPanel;
		}
	}
}
