using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Map.Marks.MarkItem;

namespace CSharpScript.Game.Module.Map.Marks.MarkItemView
{
	// Token: 0x0200586E RID: 22638
	[NullableContext(1)]
	[Nullable(0)]
	public class FixedSceneGamePlayMarkItemView : ConfigMarkItemView
	{
		// Token: 0x060398FC RID: 235772 RVA: 0x00E9ABBD File Offset: 0x00E98DBD
		public FixedSceneGamePlayMarkItemView(FixedSceneGameplayMarkItem holder) : base(holder)
		{
		}

		// Token: 0x060398FD RID: 235773 RVA: 0x00E9ABC6 File Offset: 0x00E98DC6
		protected override void OnViewRefresh()
		{
			this.UpdateIcon();
		}

		// Token: 0x060398FE RID: 235774 RVA: 0x00E9ABD0 File Offset: 0x00E98DD0
		protected override void OnSafeUpdate(Vector playerLocation, bool bDragging = false, bool bIsScale = false)
		{
			FixedSceneGameplayMarkItem fixedSceneGameplayMarkItem = (FixedSceneGameplayMarkItem)this.Holder;
			string iconPath = fixedSceneGameplayMarkItem.IconPath;
			LevelPlayInfo levelPlayInfo = ModelBase<LevelPlayModel>.Instance.GetLevelPlayInfo(fixedSceneGameplayMarkItem.MarkConfig.Value.RelativeId);
			if (levelPlayInfo == null || levelPlayInfo.IsClose)
			{
				fixedSceneGameplayMarkItem.IconPath = fixedSceneGameplayMarkItem.MarkConfig.Value.LockMarkPic;
			}
			else
			{
				fixedSceneGameplayMarkItem.IconPath = fixedSceneGameplayMarkItem.MarkConfig.Value.UnlockMarkPic;
			}
			if (iconPath != fixedSceneGameplayMarkItem.IconPath)
			{
				this.OnIconPathChanged(fixedSceneGameplayMarkItem.IconPath);
			}
		}
	}
}
